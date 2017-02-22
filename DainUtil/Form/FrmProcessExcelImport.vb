Imports System.IO
'Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports System.Data.SqlClient

Public Class FrmProcessExcelImport
    Dim load_flag As Boolean = False
    Dim files As String()
    Private Sub FrmProcessExcelImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnClose.Visible = False
        Dim cmd As SqlCommand
        Dim strSQL As String
        'cmd = New SqlCommand(" IF EXISTS (select * from tempdb..sysobjects WHERE ID = object_id('tempdb..#temp_" & D_CIPL_H & "') )  DROP TABLE #temp_" & D_CIPL_H, dbConn)
        'cmd.ExecuteNonQuery()
        'cmd.Dispose()

        'cmd = New SqlCommand(" IF EXISTS (select * from tempdb..sysobjects WHERE ID = object_id('tempdb..#temp_" & D_CIPL_D & "') )  DROP TABLE #temp_" & D_CIPL_D, dbConn)
        'cmd.ExecuteNonQuery()
        'cmd.Dispose()

        'cmd = New SqlCommand("SELECT * INTO  #temp_" & D_CIPL_H & " FROM " & D_CIPL_H & " WHERE 1 = 0 ", dbConn)
        'cmd.ExecuteNonQuery()
        'cmd.Dispose()

        'cmd = New SqlCommand("SELECT * INTO  #temp_" & D_CIPL_D & " FROM " & D_CIPL_D & " WHERE 1 = 0 ", dbConn)
        'cmd.ExecuteNonQuery()
        'cmd.Dispose()

        cmd = New SqlCommand("TRUNCATE TABLE W_CIPL_H", dbConn)
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        cmd = New SqlCommand("TRUNCATE TABLE W_CIPL_D", dbConn)
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        strSQL = " IF EXISTS(SELECT * FROM   INFORMATION_SCHEMA.COLUMNS WHERE  TABLE_NAME = 'W_CIPL_D' AND COLUMN_NAME = 'ADJUSTDETAILSEQNO')  "
        strSQL &= " ALTER TABLE W_CIPL_D DROP COLUMN ADJUSTDETAILSEQNO"
        cmd = New SqlCommand(strSQL, dbConn)
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        btnClose.Visible = True
    End Sub
    Private Sub addlog(ByVal log As String, ByVal type As Integer)
        If txtLog.Text <> "" Then
            Select Case type
                Case 0      '검증
                    txtLog.Text = txtLog.Text & vbCrLf & "[검증]" & log
                Case 1      '추가
                    If ProgressBar1.Value + 1 <= ProgressBar1.Maximum Then
                        ProgressBar1.Value = ProgressBar1.Value + 1
                    End If
                    lblPercent.Text = CInt(ProgressBar1.Value / ProgressBar1.Maximum * 100).ToString & "%"
                    txtLog.Text = txtLog.Text & vbCrLf & "[추가]" & log
                Case 2     '실패
                    txtLog.Text = txtLog.Text & vbCrLf & "[실패]" & log
                Case 3     '알림
                    txtLog.Text = txtLog.Text & vbCrLf & "[알림]" & log
            End Select

        Else
            Select Case type
                Case 0      '검증
                    txtLog.Text = "[검증]" & log
                Case 1      '추가
                    If ProgressBar1.Value + 1 <= ProgressBar1.Maximum Then
                        ProgressBar1.Value = ProgressBar1.Value + 1
                    End If
                    lblPercent.Text = CInt(ProgressBar1.Value / ProgressBar1.Maximum * 100).ToString & "%"
                    txtLog.Text = "[추가]" & log
                Case 2     '실패
                    txtLog.Text = "[실패]" & log
                Case 3     '알림
                    txtLog.Text = "[알림]" & log
            End Select


        End If
        txtLog.SelectionStart = txtLog.Text.Length
        txtLog.Focus()
        txtLog.ScrollToCaret()

        Me.Refresh()
    End Sub
    Private Sub FrmProcessExcelImport_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If ImportCommercialInvoiceCheck() Then
            ImportCommercialInvoice()
        End If
    End Sub
    Private Function ImportCommercialInvoiceCheck() As Boolean
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim Excel As Excel.Application = New Excel.Application
        Dim Workbook As Excel.Workbook
        Dim WorksheetCI As Excel.Worksheet
        Dim WorksheetPL As Excel.Worksheet
        Dim ExistFlag As Boolean
        Dim FailMessage As String

        Dim CISheetCount As Integer = 0
        Dim PLSheetCount As Integer = 0
        Dim ItemCount As Integer


        Try

            ImportCommercialInvoiceCheck = False
            addlog(G_ExcelInPath & " 파일체크을 시작합니다.", 0)
            addlog(G_ExcelInPath & " 에 엑셀파일을 체크하고 있습니다.", 0)
            files = getFiles(G_ExcelInPath, "*.xls | *.xlsx", System.IO.SearchOption.TopDirectoryOnly)

            If files.Length = 0 Then
                MsgBoxFail("임포트할 엑셀파일이 존재하지 않습니다.")
                addlog("임포트할 엑셀파일이 존재하지 않습니다.", 2)
                Exit Function
            End If

            addlog("상품마스터를 체크합니다.", 0)
            strSQL = "SELECT COUNT(*) AS ITEMCOUNT FROM M_ITEM "
            cmd = New SqlCommand(strSQL, dbConn)
            dr = cmd.ExecuteReader()
            dr.Read()
            ItemCount = dr("ITEMCOUNT")
            dr.Close()
            cmd.Dispose()
            If ItemCount = 0 Then
                addlog("상품마스타에 데이타가 없습니다. 데이터를 임포트해주세요.", 2)
                MsgBoxFail("상품마스타에 데이타가 없습니다. 데이터를 임포트해주세요.")
                Exit Function
            End If

            FailMessage = ""
            addlog("상품마스터의 자릿수를 체크합니다.", 0)
            strSQL = "SELECT HSCODE FROM M_ITEM WHERE LEN(HSCODE ) <> 10 "
            cmd = New SqlCommand(strSQL, dbConn)
            dr = cmd.ExecuteReader()
            While dr.Read()
                If FailMessage = "" Then
                    FailMessage &= " 아래의 상품마스타 세번부호가 규격에 맞지 않습니다. (10자리 숫자)"
                End If
                FailMessage &= "제품코드 : " & dr("PARTNO") & " / 세번부호 : " & dr("HSCODE")
            End While
            dr.Close()
            cmd.Dispose()
            If FailMessage <> "" Then
                addlog(FailMessage, 2)
                MsgBoxFail(FailMessage)
                Exit Function
            End If


            FailMessage = ""
            '엑셀파일 검증
            addlog("엑셀파일의 서식을 체크합니다.", 0)
            For i As Integer = 0 To files.Length - 1
                ExistFlag = False

                Excel = New Excel.Application
                Workbook = Excel.Workbooks.Open(files(i))
                For j As Integer = 1 To Workbook.Worksheets.Count
                    If Workbook.Worksheets(j).name.ToString.Contains("CI") Then
                        ExistFlag = True
                    End If
                Next

                If ExistFlag = False Then
                    addlog("[" & files(i) & "] 에 서식에 맞는 시트가 없습니다.", 2)
                    FailMessage &= "[" & files(i) & "] 에 서식에 맞는 시트가 없습니다." & vbCrLf
                    Exit Function
                End If

                Workbook.Close(False)
                Excel.Quit()
                Excel = Nothing
            Next

            If FailMessage <> "" Then
                MsgBoxFail(FailMessage)
                Exit Function
            End If
            '엑셀파일 검증

            '엑셀파일 검증(CI PL 갯수 확인)
            addlog("CI시트와 PL시트의 갯수를 체크합니다.", 0)
            FailMessage = ""
            For i As Integer = 0 To files.Length - 1
                Excel = New Excel.Application
                Workbook = Excel.Workbooks.Open(files(i))
                For j As Integer = 1 To Workbook.Worksheets.Count
                    If Workbook.Worksheets(j).name.ToString.Contains("CI") Then
                        CISheetCount = CISheetCount + 1
                    ElseIf Workbook.Worksheets(j).name.ToString.Contains("PL") Then
                        PLSheetCount = PLSheetCount + 1
                    End If
                Next

                If CISheetCount <> PLSheetCount Then
                    addlog("[" & files(i) & "] 의 CI시트와 PL시트의 갯수가 틀립니다. CI : " & CISheetCount & "개 / PL : " & "개", 2)
                    FailMessage &= "[" & files(i) & "] 의 CI시트와 PL시트의 갯수가 틀립니다. CI : " & CISheetCount & "개 / PL : " & "개" & vbCrLf
                    Exit Function
                End If

                Workbook.Close(False)
                Excel.Quit()
                Excel = Nothing
            Next

            If FailMessage <> "" Then
                MsgBoxFail(FailMessage)
                Exit Function
            End If
            '엑셀파일 검증(CI PL 갯수 확인)

            '규격번호 체크 
            addlog("CI시트와 PL시트의 배열을 체크합니다.", 0)
            FailMessage = ""
            For i As Integer = 0 To files.Length - 1
                Excel = New Excel.Application
                Workbook = Excel.Workbooks.Open(files(i))
                For j = 1 To Workbook.Worksheets.Count
                    If Workbook.Worksheets(j).Name.ToString.Contains("CI") Then
                        WorksheetCI = Workbook.Worksheets(j)
                        WorksheetPL = Workbook.Worksheets(WorksheetCI.Name.ToString.Replace("CI", "PL"))
                        For k = 0 To 15
                            If WorksheetCI.Cells((k + 23), 1).Value & WorksheetCI.Cells((k + 23), 2).Value <> WorksheetPL.Cells((k + 30), 1).Value & WorksheetPL.Cells((k + 30), 2).Value Then
                                FailMessage &= "[" & files(i) & "] 의 " & WorksheetCI.Name.ToString & "의 " & (k + 23).ToString & "열과 " & WorksheetPL.Name.ToString & "의" & (k + 30).ToString & "열의 배열이 상이 합니다." & vbCrLf
                            End If
                        Next
                        WorksheetPL = Nothing
                        WorksheetCI = Nothing
                    End If
                Next
                Workbook.Close(False)
                Excel.Quit()
                Excel = Nothing
            Next

            If FailMessage <> "" Then
                MsgBoxFail(FailMessage)
                Exit Function
            End If
            '규격번호 체크 

            '상품마스터 포함 체크 및 한글 포함체크 
            addlog("CI시트와 PL시트의 상품이 마스터에 존재하는지 체크합니다.", 0)
            strSQL = " IF NOT EXISTS (select * from tempdb..sysobjects WHERE ID = object_id('tempdb..#temp_PARTNO') ) "
            strSQL &= " CREATE TABLE #temp_PARTNO ("
            strSQL &= " FAILENAME NVARCHAR(255) Not NULL "
            strSQL &= " ,SHEETNAME NVARCHAR(20) Not NULL "
            strSQL &= " ,PARTNO NVARCHAR(20) Not NULL "
            strSQL &= " )"
            cmd = New SqlCommand(strSQL, dbConn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            FailMessage = ""
            For i As Integer = 0 To files.Length - 1
                Excel = New Excel.Application
                Workbook = Excel.Workbooks.Open(files(i))
                For j = 1 To Workbook.Worksheets.Count
                    If Workbook.Worksheets(j).Name.ToString.Contains("CI") Then
                        WorksheetCI = Workbook.Worksheets(j)
                        For k = 0 To 15
                            If WorksheetCI.Cells((k + 23), 2).Value IsNot Nothing Then
                                If WorksheetCI.Cells((k + 23), 2).Value.ToString <> "" Then
                                    strSQL = "INSERT INTO #temp_PARTNO VALUES('" & files(i) & "','" & WorksheetCI.Name.ToString & "','" & WorksheetCI.Cells((k + 23), 2).Value & "')"
                                    cmd = New SqlCommand(strSQL, dbConn)
                                    cmd.ExecuteNonQuery()
                                    cmd.Dispose()
                                End If
                            End If
                        Next
                        WorksheetCI = Nothing
                    End If
                Next
                Workbook.Close(False)
                Excel.Quit()
                Excel = Nothing
            Next
            strSQL = "SELECT * FROM #temp_PARTNO WHERE PARTNO NOT IN (SELECT PARTNO FROM M_ITEM)"
            cmd = New SqlCommand(strSQL, dbConn)
            dr = cmd.ExecuteReader
            While dr.Read
                FailMessage &= dr("FAILENAME") & "의 " & dr("SHEETNAME") & " 시트에 " & dr("PARTNO") & " 가 상품마스터에 존재하지 않습니다." & vbCrLf
            End While
            dr.Close()
            cmd.Dispose()

            If FailMessage <> "" Then
                addlog(FailMessage, 2)
                MsgBoxFail(FailMessage)
                Exit Function
            End If
            '상품마스터 포함 체크 및 한글 포함체크 

            '상품마스터 거래품명 체크
            addlog("CI시트와 PL시트에 있는 상품이 마스터에 거래품명이 한글로 등록되어 있는 데이타가 없는지 체크합니다.", 0)
            FailMessage = ""
            strSQL = "SELECT PARTNO FROM M_ITEM WHERE TRADEPARTNAME like '%[가-힣]%' AND PARTNO IN (SELECT PARTNO FROM #temp_PARTNO)"
            cmd = New SqlCommand(strSQL, dbConn)
            dr = cmd.ExecuteReader
            While dr.Read
                FailMessage &= dr("PARTNO") & " 가 상품마스터의  거래품명이 한글명으로 등록된 부분이 있습니다. " & vbCrLf
            End While
            dr.Close()
            cmd.Dispose()
            If FailMessage <> "" Then
                addlog(FailMessage, 2)
                MsgBoxFail(FailMessage)
                Exit Function
            End If
            '상품마스터 거래품명 체크

            '상품마스터 표준품명 체크
            addlog("CI시트와 PL시트에 있는 상품이 마스터에 표준품명이 한글로 등록되어 있는 데이타가 없는지 체크합니다.", 0)
            FailMessage = ""
            strSQL = "SELECT PARTNO FROM M_ITEM WHERE STANDARDPARTNAME like '%[가-힣]%' AND PARTNO IN (SELECT PARTNO FROM #temp_PARTNO)"
            cmd = New SqlCommand(strSQL, dbConn)
            dr = cmd.ExecuteReader
            While dr.Read
                FailMessage &= dr("PARTNO") & " 가 상품마스터의  표준품명이 한글명으로 등록된 부분이 있습니다. " & vbCrLf
            End While
            dr.Close()
            cmd.Dispose()

            If FailMessage <> "" Then
                addlog(FailMessage, 2)
                MsgBoxFail(FailMessage)
                Exit Function
            End If
            '상품마스터 표준품명 체크

            strSQL = " IF NOT EXISTS (select * from tempdb..sysobjects WHERE ID = object_id('tempdb..#temp_PARTNO') ) "
            strSQL &= " DROP TABLE #temp_PARTNO "
            cmd = New SqlCommand(strSQL, dbConn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            Workbook = Nothing

            Excel = Nothing

            If WorksheetPL IsNot Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(WorksheetPL)
            End If

            If WorksheetCI IsNot Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(WorksheetCI)
            End If

            If Workbook IsNot Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Workbook)
            End If

            If Excel IsNot Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Excel)
            End If

            ImportCommercialInvoiceCheck = True
        Catch ex As Exception
            ImportCommercialInvoiceCheck = False
        Finally


        End Try
    End Function
    Private Function ImportCommercialInvoice() As Boolean
        Dim ImportFile As String = ""
        Dim Excel As Excel.Application = New Excel.Application
        Dim Workbook As Excel.Workbook
        Dim WorksheetCI As Excel.Worksheet
        Dim WorksheetPL As Excel.Worksheet
        Dim INVOICENO As String = ""
        ''안분로직
        Dim WorksheetSinge As Excel.Worksheet
        Dim RangeSingle As Excel.Range
        Dim NOT_Ajusted_SingleTotalPallet As Double = 0
        Dim Ajust_DetailSeqno As String
        Dim SingleTotalPallet As Integer
        Dim TotalPallet As Integer = 0
        Dim WS_RowNumber As Integer = 0
        ''안분로직
        Dim RowNumber As Integer = 0

        Dim InvoiceDate As DateTime

        Dim ImportSuccess As Integer = 0

        'Excel RowNumber
        Dim eRowNumber As Integer = 0

        Dim strSQL As String

        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim Existflag As Boolean = False

        Dim filecount As Integer
        Dim detailCount_adjust As Integer = 0
        Dim ItemCount As Integer = 0
        Dim InvoiceNumber As String = ""
        filecount = 0

        For i As Integer = 0 To files.Length - 1
            If files(i).Contains(".xls") Or files(i).Contains(".xlsx") Then
                filecount = filecount + 1
            End If
        Next

        ProgressBar1.Maximum = filecount
        filecount = 0

        Try

            For i As Integer = 0 To files.Length - 1

                strSQL = "DELETE FROM W_SINGLETABLE "
                cmd = New SqlCommand(strSQL, dbConn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                'If files(i).Replace(G_ExcelInPath, "").Contains("케피코") Then
                '    DeclarationNumber = 1
                'End If

                'If files(i).Contains(".xls") = False And files(i).Contains(".xlsx") = False Then
                '    Continue For
                'End If
                Excel = New Excel.Application
                Workbook = Excel.Workbooks.Open(files(i))

                '엑셀 시트 검사
                'For k As Integer = 1 To Workbook.Worksheets.Count
                '    WorksheetCI = Workbook.Worksheets(k)
                '    If WorksheetCI.Name.ToString.Contains("CI") Then
                '        Existflag = True
                '    End If
                'Next
                'If Existflag = False Then
                '    addlog("[" & files(i) & "] 에 서식에 맞는 시트가 없습니다.")
                '    WorksheetPL = Nothing
                '    WorksheetCI = Nothing
                '    WorksheetSinge = Nothing
                '    Workbook.Close(False)
                '    Excel.Quit()
                '    Excel = Nothing
                '    Return False
                'End If
                '엑셀 시트 검사

                For j = 1 To Workbook.Worksheets.Count

                    If Workbook.Worksheets(j).Name.ToString.Contains("CI") Then
                        WorksheetCI = Workbook.Worksheets(j)
                        'End If

                        'If WorksheetCI.Name.ToString.Contains("CI") Then

                        WorksheetPL = Workbook.Worksheets(WorksheetCI.Name.ToString.Replace("CI", "PL"))
                        If InvoiceNumber <> WorksheetCI.Cells(3, 6).Value Then
                            InvoiceNumber = WorksheetCI.Cells(3, 6).Value
                            detailCount_adjust = 0

                            RowNumber = RowNumber + 1
                            strSQL = "INSERT INTO " & W_CIPL_H & " VALUES("
                            strSQL &= ColumnSet(RowNumber)
                            ',INVOICENO NVARCHAR(20)
                            strSQL &= " , " & ColumnSet(WorksheetCI.Cells(3, 6).Value)
                            INVOICENO = WorksheetCI.Cells(3, 6).Value
                            ',PACKINGLISTNO NVARCHAR(20)
                            strSQL &= ", " & ColumnSet(WorksheetCI.Cells(4, 6).Value)
                            ',INVOICEDATE NVARCHAR(8)
                            If DateTime.TryParse(WorksheetCI.Cells(5, 6).Value, InvoiceDate) Then
                                InvoiceDate = WorksheetCI.Cells(5, 6).Value
                                strSQL &= ", " & ColumnSet(InvoiceDate.ToString("yyyyMMdd"))
                            Else
                                strSQL &= " ,'' "
                            End If

                            'DECLARERATIONNUMBER
                            If (WorksheetCI.Cells(3, 1).Value & WorksheetCI.Cells(3, 2).Value & WorksheetCI.Cells(3, 3).Value & WorksheetCI.Cells(3, 4).Value).ToString.ToUpper.Contains("KEFICO") Then
                                strSQL &= " ,'0001'"
                            Else
                                strSQL &= " ,'0002'"
                            End If

                            ',SHIPPEREXPORTER NVARCHAR(100)
                            strSQL &= " ," & ColumnSet(WorksheetCI.Cells(3, 1).Value & WorksheetCI.Cells(3, 2).Value & WorksheetCI.Cells(3, 3).Value & WorksheetCI.Cells(3, 4).Value)

                            ',SHIPPEREXPORTERADDRESS NVARCHAR(255)
                            strSQL &= " ,'" & WorksheetCI.Cells(5, 1).Value & WorksheetCI.Cells(4, 2).Value & WorksheetCI.Cells(4, 3).Value & WorksheetCI.Cells(4, 4).Value & vbCrLf &
                                WorksheetCI.Cells(5, 1).Value & WorksheetCI.Cells(5, 2).Value & WorksheetCI.Cells(5, 3).Value & WorksheetCI.Cells(5, 4).Value & vbCrLf &
                            WorksheetCI.Cells(6, 1).Value & WorksheetCI.Cells(6, 2).Value & WorksheetCI.Cells(6, 3).Value & WorksheetCI.Cells(6, 4).Value & "'"

                            ',CONSIGNEE NVARCHAR(100)
                            strSQL &= " ," & ColumnSet(WorksheetCI.Cells(8, 1).Value & WorksheetCI.Cells(8, 2).Value & WorksheetCI.Cells(8, 3).Value & WorksheetCI.Cells(8, 4).Value)
                            ',CONSIGNEEADDRESS NVARCHAR(255)
                            strSQL &= " ,'" & ColumnSetLine(WorksheetCI.Cells(9, 1).Value &
                              WorksheetCI.Cells(9, 2).Value &
                                WorksheetCI.Cells(9, 3).Value &
                                WorksheetCI.Cells(9, 4).Value) &
                                ColumnSetLine(WorksheetCI.Cells(10, 1).Value &
                                WorksheetCI.Cells(10, 2).Value &
                                WorksheetCI.Cells(10, 3).Value &
                                WorksheetCI.Cells(10, 4).Value) &
                                ColumnSetLine(WorksheetCI.Cells(11, 1).Value &
                                WorksheetCI.Cells(11, 2).Value &
                                WorksheetCI.Cells(11, 3).Value &
                                WorksheetCI.Cells(11, 4).Value) &
                                ColumnSetLine(WorksheetCI.Cells(12, 1).Value &
                                WorksheetCI.Cells(12, 2).Value &
                                WorksheetCI.Cells(12, 3).Value &
                                WorksheetCI.Cells(12, 4).Value) &
                                ColumnSetLine(WorksheetCI.Cells(13, 1).Value &
                                WorksheetCI.Cells(13, 2).Value &
                                WorksheetCI.Cells(13, 3).Value &
                                WorksheetCI.Cells(13, 4).Value) &
                                ColumnSet(WorksheetCI.Cells(14, 1).Value &
                                WorksheetCI.Cells(14, 2).Value &
                                WorksheetCI.Cells(14, 3).Value &
                                WorksheetCI.Cells(14, 4).Value) & "'"

                            ',TERMSOFDELIVERY NVARCHAR(10)
                            strSQL &= " ," & ColumnSet(WorksheetCI.Cells(8, 6).Value.ToString.Replace(" ", "").Replace("TERMSOFDELIVERY", "").Replace(":", ""))
                            ',SHIPPINGMODE NVARCHAR(30)
                            strSQL &= " ," & ColumnSet(WorksheetCI.Cells(9, 6).Value.ToString.Replace(" ", "").Replace("SHIPPINGMODE", "").Replace(":", ""))
                            ',PAYMENT NVARCHAR(30)
                            strSQL &= " ," & ColumnSet(WorksheetCI.Cells(10, 6).Value.ToString.Replace(" ", "").Replace("PAYMENT", "").Replace(":", ""))
                            ',PAYMENTBANK NVARCHAR(30)
                            strSQL &= " ," & ColumnSet(WorksheetCI.Cells(11, 6).Value.ToString.Replace(" ", "").Replace("PAYMENTBANK", "").Replace(":", ""))
                            'ACCOUNTNO NVARCHAR(30)
                            strSQL &= " ," & ColumnSet(WorksheetCI.Cells(12, 6).Value.ToString.Replace(" ", "").Replace("ACCOUNTNO.", "").Replace(":", ""))
                            'PURCHASEORDER NVARCHAR(30)
                            strSQL &= " ," & ColumnSet(WorksheetCI.Cells(13, 6).Value.ToString.Replace(" ", "").Replace("PURCHASEORDER", "").Replace(":", ""))
                            'LOADINGPORTCODE NVARCHAR(100)
                            If WorksheetCI.Cells(15, 4).Value.ToString.ToUpper.Contains("AIRPORT") Then
                                strSQL &= " ,'040'"
                            ElseIf WorksheetCI.Cells(15, 4).Value.ToString.ToUpper.Contains("PYEONGTAEK SEAPORT") Then
                                strSQL &= " ,'016'"
                            ElseIf WorksheetCI.Cells(15, 4).Value.ToString.ToUpper.Contains("INCHON SEAPORT") Then
                                strSQL &= " ,'020'"
                            End If
                            'LOADINGPORTNAME NVARCHAR(100)
                            strSQL &= " ," & ColumnSet(WorksheetCI.Cells(15, 4).Value)
                            'DESTINATION NVARCHAR(100)
                            strSQL &= " ," & ColumnSet(WorksheetCI.Cells(17, 4).Value)
                            'NOTIFY NVARCHAR(255)
                            strSQL &= " ,'" & ColumnSetLine(WorksheetCI.Cells(15, 6).Value &
                                WorksheetCI.Cells(15, 7).Value &
                                WorksheetCI.Cells(15, 8).Value &
                                WorksheetCI.Cells(15, 9).Value &
                                WorksheetCI.Cells(15, 10).Value &
                                WorksheetCI.Cells(15, 11).Value &
                                WorksheetCI.Cells(15, 12).Value) &
                            ColumnSetLine(WorksheetCI.Cells(16, 6).Value &
                            WorksheetCI.Cells(16, 7).Value &
                            WorksheetCI.Cells(16, 8).Value &
                            WorksheetCI.Cells(16, 9).Value &
                            WorksheetCI.Cells(16, 10).Value &
                            WorksheetCI.Cells(16, 11).Value &
                            WorksheetCI.Cells(16, 12).Value) &
                              ColumnSetLine(WorksheetCI.Cells(17, 6).Value &
                            WorksheetCI.Cells(17, 7).Value &
                            WorksheetCI.Cells(17, 8).Value &
                            WorksheetCI.Cells(17, 9).Value &
                            WorksheetCI.Cells(17, 10).Value &
                            WorksheetCI.Cells(17, 11).Value &
                            WorksheetCI.Cells(17, 12).Value) &
                             ColumnSet(WorksheetCI.Cells(18, 6).Value &
                            WorksheetCI.Cells(18, 7).Value &
                            WorksheetCI.Cells(18, 8).Value &
                            WorksheetCI.Cells(18, 9).Value &
                            WorksheetCI.Cells(18, 10).Value &
                            WorksheetCI.Cells(18, 11).Value &
                            WorksheetCI.Cells(18, 12).Value) & "'"

                            'PICKING LIST START
                            'PL_CONTACTPERSON NVARCHAR(255)
                            strSQL &= "," & ColumnSet(WorksheetPL.Cells(19, 6).Value & WorksheetPL.Cells(19, 7).Value & WorksheetPL.Cells(19, 8).Value & WorksheetPL.Cells(19, 9).Value)
                            'PL_CONTACTPERSON_EMAIL NVARCHAR(255)
                            strSQL &= "," & ColumnSet(WorksheetPL.Cells(20, 6).Value)
                            'PL_ETD NVARCHAR(8)
                            strSQL &= " ," & ColumnSet(CDate(WorksheetPL.Cells(22, 3).Value).ToString("yyyyMMdd"))
                            'PL_ETA NVARCHAR(8)
                            strSQL &= " ," & ColumnSet(CDate(WorksheetPL.Cells(22, 8).Value).ToString("yyyyMMdd"))
                            'PL_TOTAL_MESURMENT Decimal(14,2)
                            strSQL &= " ," & ColumnSet(WorksheetPL.Cells(23, 5).Value.ToString.ToUpper.Replace(" ", "").Replace("TOTALMEASURMENT:", "").Replace("CBM", ""))
                            'PL_TOTAL_NWEIGHT DECIMAL(14,2)
                            strSQL &= " ," & ColumnSet(WorksheetPL.Cells(24, 5).Value.ToString.ToUpper.Replace(" ", "").Replace("TOTALN/WEIGHT:", "").Replace("KG", ""))
                            'PL_TOTAL_NWEIGHT_PLTS Decimal(14,0)
                            strSQL &= " ," & ColumnSet(WorksheetPL.Cells(24, 8).Value.ToString.ToUpper.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("PLTS", ""))
                            TotalPallet = WorksheetPL.Cells(24, 8).Value.ToString.ToUpper.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("PLTS", "")
                            'PL_TOTAL_GWEIGHT DECIMAL(14,2)
                            strSQL &= " ," & ColumnSet(WorksheetPL.Cells(25, 5).Value.ToString.ToUpper.Replace(" ", "").Replace("TOTALG/WEIGHT:", "").Replace("KG", ""))

                            'PICKING LIST END
                            'IMPORTDATEANDTIME NVARCHAR(14)
                            strSQL &= ",REPLACE(REPLACE(REPLACE(CONVERT(VARCHAR,GETDATE(),120),' ',''),'-',''),':','')"
                            'OUTPUTFLAG INT
                            strSQL &= ",'0'"
                            'OUTPUTDATEANDTIME NVARCHAR(14)
                            strSQL &= ",''"

                            strSQL &= ")"
                            cmd = New SqlCommand(strSQL, dbConn)
                            cmd.ExecuteNonQuery()
                            cmd.Dispose()
                            'Else
                            '    detailCount_adjust = detailCount_adjust + 15
                        End If

                        For detailCount As Integer = 0 To 15
                            eRowNumber = detailCount + 23
                            If WorksheetCI.Cells(eRowNumber, 2).Value IsNot Nothing Then

                                strSQL = "INSERT INTO " & W_CIPL_D & " VALUES("
                                'SEQNO BIGINT  Not NULL 
                                strSQL &= "'" & RowNumber.ToString & "'"
                                'DETAILSEQNO INT NOT NULL
                                strSQL &= ",'" & (detailCount + detailCount_adjust + 1).ToString & "'"
                                'ORIGINALDETAILSEQNO INT NOT NULL
                                strSQL &= "," & ColumnSet(WorksheetCI.Cells(eRowNumber, 1).Value)
                                'CONVENTIONCODE NVARCHAR(100) 
                                strSQL &= "," & GetConventionCode(WorksheetCI.Cells(eRowNumber, 2).Value)
                                'RANNUMBER NVARCHAR(3) 
                                strSQL &= ",NULL"                       'RANNUMBER
                                'RANDETAILNUMBER NVARCHAR(2) 
                                strSQL &= ",NULL"                       'RANDETAILNUMBER
                                'PARTNO NVARCHAR(20) Not NULL
                                strSQL &= "," & ColumnSet(WorksheetCI.Cells(eRowNumber, 2).Value)
                                'PARTNAME NVARCHAR(100)
                                strSQL &= "," & ColumnSet(WorksheetCI.Cells(eRowNumber, 4).Value).ToString.ToUpper
                                'PRODUCT NVARCHAR(100)
                                strSQL &= ",''"
                                'HSCODE NVARCHAR(20)
                                strSQL &= "," & GetHSCode(WorksheetCI.Cells(eRowNumber, 2).Value)
                                'CI_REV NVARCHAR(10) 
                                strSQL &= "," & ColumnSet(WorksheetCI.Cells(eRowNumber, 5).Value)
                                'CI_PUN NVARCHAR(5) 
                                strSQL &= "," & ColumnSet(WorksheetCI.Cells(eRowNumber, 6).Value.ToString.ToUpper.Replace("PCS", "PC"))
                                'CI_MPQ NVARCHAR(10) 
                                strSQL &= "," & ColumnSet(WorksheetCI.Cells(eRowNumber, 7).Value)
                                'CI_QTY Decimal(14,0) 
                                strSQL &= "," & ColumnSet(WorksheetCI.Cells(eRowNumber, 8).Value)
                                'CI_KGS Decimal(14,1) 
                                strSQL &= "," & ColumnSet(WorksheetCI.Cells(eRowNumber, 10).Value)
                                'CI_UPRICE_USD Decimal(14,2)
                                strSQL &= "," & ColumnSet(WorksheetCI.Cells(eRowNumber, 11).Value)
                                'CI_AMOUNT_USD Decimal(14,2) 
                                strSQL &= "," & ColumnSet(WorksheetCI.Cells(eRowNumber, 12).Value)

                                'PL_SUPPLIERCODE NVARCHAR(10) 
                                strSQL &= "," & ColumnSet(WorksheetPL.Cells(eRowNumber + 7, 4).Value)
                                'PL_PUN NVARCHAR(5) 
                                strSQL &= "," & ColumnSet(WorksheetPL.Cells(eRowNumber + 7, 5).Value.ToString.ToUpper.Replace("PCS", "PC"))
                                'PL_CBM NVARCHAR(10) 
                                strSQL &= "," & ColumnSet(WorksheetPL.Cells(eRowNumber + 7, 6).Value)
                                'PL_QTY Decimal(14'0) 
                                strSQL &= "," & ColumnSet(WorksheetPL.Cells(eRowNumber + 7, 7).Value)
                                'PL_NWEIGHTKGS Decimal(14,2) 
                                strSQL &= "," & ColumnSet(WorksheetPL.Cells(eRowNumber + 7, 8).Value)
                                'PL_GWEIGHTKGS Decimal(14,2) 
                                strSQL &= "," & ColumnSet(WorksheetPL.Cells(eRowNumber + 7, 9).Value)
                                '포장개수
                                strSQL &= ",'0' "
                                strSQL &= ")"

                                cmd = New SqlCommand(strSQL, dbConn)
                                cmd.ExecuteNonQuery()
                                cmd.Dispose()

                                strSQL = " INSERT INTO W_SINGLETABLE VALUES( "
                                strSQL &= " '" & (detailCount + detailCount_adjust + 1).ToString & "'"
                                strSQL &= "," & ColumnSet(WorksheetCI.Cells(eRowNumber, 2).Value)
                                strSQL &= " ," & ColumnSet("0")
                                strSQL &= " ," & ColumnSet("0")
                                strSQL &= " ," & ColumnSet("0")
                                strSQL &= " )"
                                cmd = New SqlCommand(strSQL, dbConn)
                                cmd.ExecuteNonQuery()
                                cmd.Dispose()

                                addlog("[" & WorksheetCI.Cells(eRowNumber, 2).Value.ToString + "] 가 저장되었습니다.", 3)
                                eRowNumber = eRowNumber + 1
                            Else
                                detailCount_adjust = detailCount_adjust + 15
                                Exit For
                            End If
                        Next
                    End If
                Next

                '안분 테이블 
                addlog("[" & INVOICENO + "] 을 안분처리 합니다.", 3)

                WorksheetSinge = Workbook.Worksheets("단품무게")
                '속도개선

                WorksheetSinge.Range("1:2").AutoFilter(Field:=12, Criteria1:="<>")

                WS_RowNumber = 3
                SingleTotalPallet = 1

                With WorksheetSinge
                    While .Range("A1", .Range("C" & .Rows.Count).End(Microsoft.Office.Interop.Excel.XlDirection.xlUp)).SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeVisible).Cells(WS_RowNumber, 1).Value &
                        .Range("A1", .Range("C" & .Rows.Count).End(Microsoft.Office.Interop.Excel.XlDirection.xlUp)).SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeVisible).Cells(WS_RowNumber, 2).Value &
                    .Range("A1", .Range("C" & .Rows.Count).End(Microsoft.Office.Interop.Excel.XlDirection.xlUp)).SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeVisible).Cells(WS_RowNumber, 3).Value <> ""
                        If IsNumeric(.Cells(WS_RowNumber, 12).Value) Then
                            strSQL = " UPDATE W_SINGLETABLE Set "
                            strSQL &= " PALLETRATE = " & ColumnSet(Math.Round(.Cells(WS_RowNumber, 12).Value, 2))
                            strSQL &= " ,PALLETAMOUNT = " & ColumnSet(CInt(.Cells(WS_RowNumber, 12).Value).ToString)
                            strSQL &= " WHERE  PARTNO = " & ColumnSet(.Cells(WS_RowNumber, 2).Value)
                            cmd = New SqlCommand(strSQL, dbConn)
                            cmd.ExecuteNonQuery()
                            cmd.Dispose()
                        End If
                        WS_RowNumber = WS_RowNumber + 1
                    End While
                End With

                strSQL = "UPDATE W_SINGLETABLE "
                strSQL &= "  Set PALLETRATE = PALLETRATE / " & Math.Round(WorksheetSinge.Cells(WS_RowNumber, 12).Value, 2).ToString
                cmd = New SqlCommand(strSQL, dbConn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                strSQL = "UPDATE W_SINGLETABLE "
                strSQL &= "  Set PALLETAMOUNT = ROUND(PALLETRATE  * " & TotalPallet & ",0)"
                cmd = New SqlCommand(strSQL, dbConn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()


                NOT_Ajusted_SingleTotalPallet = 0
                While NOT_Ajusted_SingleTotalPallet <> TotalPallet
                    If NOT_Ajusted_SingleTotalPallet <> 0 Then
                        'strSQL = " Select MIN(WS.DETAILSEQNO) As DETAILSEQNO , MAX(WS.PALLETAMOUNT) As PALLETAMOUNT"
                        'strSQL &= " FROM " & W_CIPL_D & " DD  "
                        'strSQL &= " INNER JOIN W_SINGLETABLE WS  "
                        'strSQL &= " On DD.DETAILSEQNO = WS.DETAILSEQNO "
                        'strSQL &= " WHERE SEQNO = '" & RowNumber & "' "
                        'strSQL &= " And ADJUSTFLAG <> '1' "

                        strSQL = " SELECT TOP 1 DETAILSEQNO FROM W_SINGLETABLE "
                        strSQL &= " WHERE PALLETAMOUNT =( SELECT MAX(WS.PALLETAMOUNT) FROM W_SINGLETABLE WS "
                        strSQL &= " WHERE 1 = 1 AND ADJUSTFLAG <> '1' "
                        strSQL &= " ) "
                        cmd = New SqlCommand(strSQL, dbConn)
                        dr = cmd.ExecuteReader
                        dr.Read()
                        Ajust_DetailSeqno = dr("DETAILSEQNO")
                        dr.Close()
                        cmd.Dispose()

                        strSQL = " UPDATE W_SINGLETABLE SET "
                        If NOT_Ajusted_SingleTotalPallet > TotalPallet Then
                            strSQL &= " PALLETAMOUNT = PALLETAMOUNT - 1 "
                        Else
                            strSQL &= " PALLETAMOUNT = PALLETAMOUNT + 1 "
                        End If
                        strSQL &= " WHERE  1 = 1"
                        strSQL &= " AND DETAILSEQNO = " & ColumnSet(Ajust_DetailSeqno)
                        cmd = New SqlCommand(strSQL, dbConn)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()

                        strSQL = " UPDATE W_SINGLETABLE Set ADJUSTFLAG = '1' WHERE DETAILSEQNO = " & ColumnSet(Ajust_DetailSeqno.ToString)
                        cmd = New SqlCommand(strSQL, dbConn)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()
                    End If

                    strSQL = "Select SUM(PALLETAMOUNT) As NOT_Ajusted_SingleTotalPallet FROM W_SINGLETABLE"
                    cmd = New SqlCommand(strSQL, dbConn)
                    dr = cmd.ExecuteReader()
                    dr.Read()
                    NOT_Ajusted_SingleTotalPallet = dr("NOT_Ajusted_SingleTotalPallet")
                    dr.Close()
                    cmd.Dispose()
                End While

                strSQL = "  Update " & W_CIPL_D & "  "
                strSQL &= " Set PACKAGEAMOUNT = WS.PALLETAMOUNT  "
                strSQL &= " From " & W_CIPL_D & " DD INNER Join W_SINGLETABLE WS  "
                strSQL &= " On DD.DETAILSEQNO = WS.DETAILSEQNO  "
                strSQL &= " And DD.PARTNO = WS.PARTNO   "
                cmd = New SqlCommand(strSQL, dbConn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()


                '안분 테이블 
                WorksheetPL = Nothing
                WorksheetCI = Nothing
                WorksheetSinge = Nothing
                Workbook.Close(False)
                Excel.Quit()
                Excel = Nothing

                filecount = filecount + 1
                ProgressBar1.Value += 1
            Next

            strSQL = " UPDATE " & W_CIPL_D & " SET PRODUCT = (SELECT TOP 1 PRODUCT FROM M_ITEM WHERE " & W_CIPL_D & ".PARTNO = M_ITEM.PARTNO)"
            cmd = New SqlCommand(strSQL, dbConn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            strSQL = " ALTER TABLE " & W_CIPL_D & " ADD ADJUSTDETAILSEQNO BIGINT"
            cmd = New SqlCommand(strSQL, dbConn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            strSQL = " Update " & W_CIPL_D & " "
            strSQL &= " Set " & W_CIPL_D & ".ADJUSTDETAILSEQNO = ADJUSTDETAILSEQNOTABLE.ADJUSTDETAILSEQNO "
            strSQL &= " FROM " & W_CIPL_D
            strSQL &= " INNER JOIN (Select "
            strSQL &= " SEQNO,DETAILSEQNO,ROW_NUMBER() OVER(PARTITION BY SEQNO ORDER BY HSCODE) As ADJUSTDETAILSEQNO  "
            strSQL &= " FROM " & W_CIPL_D & ") As ADJUSTDETAILSEQNOTABLE "
            strSQL &= " On " & W_CIPL_D & ".SEQNO = ADJUSTDETAILSEQNOTABLE.SEQNO And " & W_CIPL_D & ".DETAILSEQNO = ADJUSTDETAILSEQNOTABLE.DETAILSEQNO  "
            cmd = New SqlCommand(strSQL, dbConn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            strSQL = " UPDATE " & W_CIPL_D & "  Set DETAILSEQNO = ADJUSTDETAILSEQNO "
            cmd = New SqlCommand(strSQL, dbConn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            strSQL = " ALTER TABLE " & W_CIPL_D & " DROP COLUMN ADJUSTDETAILSEQNO "
            cmd = New SqlCommand(strSQL, dbConn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            strSQL = " UPDATE W_CIPL_D "
            strSQL &= " Set W_CIPL_D.RANNUMBER = RANTABLE.RANNUMBER   "
            strSQL &= "  FROM W_CIPL_D INNER JOIN (   "
            strSQL &= " Select  "
            strSQL &= "  RIGHT('000' + CONVERT(NVARCHAR,DENSE_RANK() OVER (  PARTITION BY SEQNO,SORT ORDER BY SEQNO,SORT,CONVENTIONCODE ,DETAILSEQNO_RANK,HSCODE ASC) ),3) AS RANNUMBER      "
            strSQL &= " ,* FROM (   "
            strSQL &= " SELECT    "
            strSQL &= " SEQNO   "
            strSQL &= " ,DETAILSEQNO  "
            strSQL &= " ,( Select MIN(WD2.ORIGINALDETAILSEQNO) FROM W_CIPL_D WD2 WHERE WD2.SEQNO = WD.SEQNO And WD2.CONVENTIONCODE=WD.CONVENTIONCODE And WD.HSCODE=WD2.HSCODE ) As DETAILSEQNO_RANK "
            strSQL &= " ,Case CONVENTIONCODE When '한-중 FTA' THEN '0' WHEN 'APTA' THEN '1' WHEN '해당없음' THEN '2' END AS CONVENTIONCODE  "
            strSQL &= " ,PRODUCT   "
            strSQL &= " ,HSCODE    "
            strSQL &= " ,PARTNO   "
            strSQL &= " ,Case REPLACE(PRODUCT,'(주)','') WHEN  '현대케피코' THEN '1' ELSE '0' END SORT   "
            strSQL &= " FROM W_CIPL_D WD ) A   "
            strSQL &= " ) As RANTABLE   "
            strSQL &= " On W_CIPL_D.SEQNO = RANTABLE.SEQNO And W_CIPL_D.DETAILSEQNO = RANTABLE.DETAILSEQNO  "
            cmd = New SqlCommand(strSQL, dbConn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            strSQL = " UPDATE W_CIPL_D "
            strSQL &= " Set W_CIPL_D.RANDETAILNUMBER = RIGHT('00'+CONVERT(NVARCHAR,RANTABLE.ORIGINALDETAILSEQNO),2)   "
            'strSQL &= " Set W_CIPL_D.ORIGINALDETAILSEQNO = RANTABLE.ORIGINALDETAILSEQNO   "
            strSQL &= "  FROM W_CIPL_D INNER JOIN (   "
            strSQL &= " Select  "
            strSQL &= " RIGHT('000' + CONVERT(NVARCHAR,RANK() OVER (PARTITION BY SEQNO,SORT,CONVENTIONCODE,HSCODE ORDER BY PRODUCT,PARTNO ASC) ),3) AS ORIGINALDETAILSEQNO        "
            strSQL &= " ,* FROM (   "
            strSQL &= " SELECT    "
            strSQL &= " SEQNO   "
            strSQL &= " ,DETAILSEQNO  "
            strSQL &= " ,( SELECT MIN(WD2.ORIGINALDETAILSEQNO) FROM W_CIPL_D WD2 WHERE WD2.SEQNO = WD.SEQNO AND WD2.CONVENTIONCODE=WD.CONVENTIONCODE AND WD.HSCODE=WD2.HSCODE ) AS DETAILSEQNO_RANK "
            strSQL &= " ,Case CONVENTIONCODE When '한-중 FTA' THEN '0' WHEN 'APTA' THEN '1' WHEN '해당없음' THEN '2' END AS CONVENTIONCODE  "
            strSQL &= " ,PRODUCT   "
            strSQL &= " ,HSCODE    "
            strSQL &= " ,PARTNO   "
            strSQL &= " ,Case REPLACE(PRODUCT,'(주)','') WHEN  '현대케피코' THEN '1' ELSE '0' END SORT   "
            strSQL &= " FROM W_CIPL_D WD ) A   "
            strSQL &= " ) As RANTABLE   "
            strSQL &= " On W_CIPL_D.SEQNO = RANTABLE.SEQNO And W_CIPL_D.DETAILSEQNO = RANTABLE.DETAILSEQNO  "
            cmd = New SqlCommand(strSQL, dbConn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            Dim DataCount As Integer = 0
            Dim Message As String = ""
            strSQL = " Select INVOICENO,PARTNO FROM " & W_CIPL_H & " HD "
            strSQL &= " INNER JOIN " & W_CIPL_D & " DD On HD.SEQNO = DD.SEQNO "
            strSQL &= " WHERE PARTNO Not In (Select PARTNO FROM M_ITEM)"
            cmd = New SqlCommand(strSQL, dbConn)
            dr = cmd.ExecuteReader
            While dr.Read
                DataCount = DataCount + 1
                Message &= dr("INVOICENO") & "-" & dr("PARTNO") & vbCrLf
            End While
            dr.Dispose()
            cmd.Dispose()

            If DataCount <> 0 Then
                MsgBoxFail("아래의 데이타가 상품마스타에 존재하지 않습니다." & vbCrLf & Message)
                addlog("아래의 데이타가 상품마스타에 존재하지 않습니다." & vbCrLf & Message, 2)
                Return False
                Exit Function
            Else

            End If
            ''안분처리

            ''안분처리
            strSQL = " UPDATE W_CIPL_D Set "
            strSQL &= " W_CIPL_D.PARTNAME = M_ITEM.PARTNAME "
            strSQL &= " FROM M_ITEM INNER JOIN W_CIPL_D "
            strSQL &= " On M_ITEM.PARTNO = W_CIPL_D.PARTNO "
            cmd = New SqlCommand(strSQL, dbConn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()


            cmd = New SqlCommand(" UPDATE  " & W_CIPL_H & " Set PL_TOTAL_NWEIGHT_PLTS = Case When PL_TOTAL_NWEIGHT <50 Then 0 Else PL_TOTAL_NWEIGHT_PLTS End ", dbConn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            cmd = New SqlCommand(" UPDATE  " & W_CIPL_H & " Set SEQNO= (Select ISNULL(MAX(SEQNO),0) As MAXROW FROM " & D_CIPL_H & ") + SEQNO ", dbConn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            cmd = New SqlCommand(" UPDATE  " & W_CIPL_D & " Set SEQNO = (Select ISNULL(MAX(SEQNO),0) As MAXROW FROM " & D_CIPL_D & ") + SEQNO ", dbConn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            cmd = New SqlCommand(" INSERT INTO " & D_CIPL_H & " Select * FROM " & W_CIPL_H, dbConn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            cmd = New SqlCommand(" INSERT INTO " & D_CIPL_D & " Select * FROM " & W_CIPL_D, dbConn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            addlog("임포트를 성공했습니다. (" & filecount & "건 )", 3)
            MsgBoxOK("임포트를 성공했습니다. ")
            Return True
        Catch ex As Exception
            addlog("임포트를 실패했습니다. ", 2)
            MsgBoxFail(ex.Message)
            Return False
        Finally
            If WorksheetPL IsNot Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(WorksheetPL)
            End If

            If WorksheetCI IsNot Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(WorksheetCI)
            End If

            If WorksheetSinge IsNot Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(WorksheetCI)
            End If

            If Workbook IsNot Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Workbook)
            End If

            If Excel IsNot Nothing Then
                System.Runtime.InteropServices.Marshal.ReleaseComObject(Excel)
            End If

        End Try

    End Function



    Function ColumnSetLine(ByVal column As String)
        If column = "" Then
            Return column
        Else
            Return column.Replace("'", "''") & vbCrLf
        End If
    End Function



    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim cmd As SqlCommand
        cmd = New SqlCommand(" IF EXISTS (select * from tempdb..sysobjects WHERE ID = object_id('tempdb..#temp_" & D_CIPL_H & "') )  DROP TABLE #temp_" & D_CIPL_H, dbConn)
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        cmd = New SqlCommand(" IF EXISTS (select * from tempdb..sysobjects WHERE ID = object_id('tempdb..#temp_" & D_CIPL_D & "') )  DROP TABLE #temp_" & D_CIPL_D, dbConn)
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        Me.Close()
    End Sub
End Class