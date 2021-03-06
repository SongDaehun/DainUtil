﻿Imports System.IO
'Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports System.Data.SqlClient

Module KVPA
    Public Function ImportKVPA_CI_Check(ByVal filepath As String) As Boolean
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
            ImportKVPA_CI_Check = False
            ProccessExcelImport.addlog("파일체크를 시작합니다.", 0)

            If System.IO.File.Exists(filepath) = False Then
                ProccessExcelImport.addlog("임포트할 엑셀파일이 존재하지 않습니다.", 2)
                Return False
            End If

            ProccessExcelImport.addlog("상품마스터를 체크합니다.", 0)
            strSQL = "SELECT COUNT(*) AS ITEMCOUNT FROM M_ITEM "
            cmd = New SqlCommand(strSQL, dbConn)
            dr = cmd.ExecuteReader()
            dr.Read()
            ItemCount = dr("ITEMCOUNT")
            dr.Close()
            cmd.Dispose()
            If ItemCount = 0 Then
                ProccessExcelImport.addlog("상품마스타에 데이타가 없습니다. 데이터를 임포트해주세요.", 2)
                Return False
            End If

            FailMessage = ""
            ProccessExcelImport.addlog("상품마스터의 자릿수를 체크합니다.", 0)
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
                ProccessExcelImport.addlog(FailMessage, 2)
                Return False
            End If

            FailMessage = ""
            '엑셀파일 검증
            ProccessExcelImport.addlog("엑셀파일의 서식을 체크합니다.", 0)
            ExistFlag = False

            Excel = New Excel.Application
            Workbook = Excel.Workbooks.Open(filepath)
            For j As Integer = 1 To Workbook.Worksheets.Count
                If Workbook.Worksheets(j).name.ToString.Contains("INVOICE") Then
                    ExistFlag = True
                End If
            Next

            Workbook.Close(False)
            Excel.Quit()
            Excel = Nothing

            If ExistFlag = False Then
                ProccessExcelImport.addlog("서식에 맞는 시트( ""INVOICE""  )가 없습니다.", 2)
                FailMessage &= "서식에 맞는 시트( ""INVOICE""  )가 없습니다." & vbCrLf
                Return False
            End If

            '엑셀파일 검증(CI PL 갯수 확인)
            ProccessExcelImport.addlog("INVOICE시트와 Packing_List시트의 갯수를 체크합니다.", 0)
            FailMessage = ""

            Excel = New Excel.Application
            Workbook = Excel.Workbooks.Open(filepath)
            For j As Integer = 1 To Workbook.Worksheets.Count
                If Workbook.Worksheets(j).name.ToString.Contains("INVOICE") Then
                    CISheetCount = CISheetCount + 1
                ElseIf Workbook.Worksheets(j).name.ToString.ToUpper.Contains("PACKING LIST") Then
                    PLSheetCount = PLSheetCount + 1
                End If
            Next

            If CISheetCount <> PLSheetCount Then
                ProccessExcelImport.addlog("INVOICE시트와 Packing List시트의 갯수가 틀립니다. INVOICE : " & CISheetCount & "개 / Packing List : " & PLSheetCount & "개", 2)
                FailMessage &= "INVOICE시트와 Packing List시트의 갯수가 틀립니다. INVOICE : " & CISheetCount & "개 / Packing List : " & PLSheetCount & "개" & vbCrLf
            End If

            Workbook.Close(False)
            Excel.Quit()
            Excel = Nothing

            If FailMessage <> "" Then
                Return False
            End If
            '엑셀파일 검증(CI PL 갯수 확인)

            '상품마스터 포함 체크 및 한글 포함체크 
            ProccessExcelImport.addlog("INVOICE시트와 Packing List시트의 상품이 마스터에 존재하는지 체크합니다.", 0)
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
            Excel = New Excel.Application
            Workbook = Excel.Workbooks.Open(filepath)
            For j = 1 To Workbook.Worksheets.Count
                If Workbook.Worksheets(j).Name.ToString.Contains("INVOICE") Then
                    WorksheetCI = Workbook.Worksheets(j)
                    For k = 0 To 15
                        'If WorksheetCI.Cells((k + 21), 2).Value IsNot Nothing Then
                        '    If WorksheetCI.Cells((k + 21), 2).Value.ToString <> "" Then
                        If WorksheetCI.Cells((k + 24), 2).Value IsNot Nothing Then
                            If WorksheetCI.Cells((k + 24), 2).Value.ToString <> "" Then
                                strSQL = "INSERT INTO #temp_PARTNO VALUES('" & filepath & "','" & WorksheetCI.Name.ToString & "','" & WorksheetCI.Cells((k + 24), 2).Value & "')"
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
            strSQL = "SELECT * FROM #temp_PARTNO WHERE PARTNO NOT IN (SELECT PARTNO FROM M_ITEM)"
            cmd = New SqlCommand(strSQL, dbConn)
            dr = cmd.ExecuteReader
            While dr.Read
                FailMessage &= dr("FAILENAME") & "의 " & dr("SHEETNAME") & " 시트에 " & dr("PARTNO") & " 가 상품마스터에 존재하지 않습니다." & vbCrLf
            End While
            dr.Close()
            cmd.Dispose()

            If FailMessage <> "" Then
                ProccessExcelImport.addlog(FailMessage, 2)
                MsgBoxFail(FailMessage)
                Return False
            End If
            '상품마스터 포함 체크 및 한글 포함체크


            '상품마스터 거래품명 체크
            ProccessExcelImport.addlog("CI시트와 PL시트에 있는 상품이 마스터에 거래품명이 한글로 등록되어 있는 데이타가 없는지 체크합니다.", 0)
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
                ProccessExcelImport.addlog(FailMessage, 2)
                MsgBoxFail(FailMessage)
                Return False
            End If
            '상품마스터 거래품명 체크

            '상품마스터 표준품명 체크
            ProccessExcelImport.addlog("CI시트와 PL시트에 있는 상품이 마스터에 표준품명이 한글로 등록되어 있는 데이타가 없는지 체크합니다.", 0)
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
                ProccessExcelImport.addlog(FailMessage, 2)
                MsgBoxFail(FailMessage)
                Return False
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

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function ImportKVPA_CI(ByVal filepath As String) As Boolean

        If ImportKVPA_CI_Check(filepath) = False Then Return False

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
        Dim detailCount As Integer = 1

        Dim strSQL As String

        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim Existflag As Boolean = False

        Dim detailCount_adjust As Integer = 0
        Dim ItemCount As Integer = 0
        Dim InvoiceNumber As String = ""
        Dim Loading_Port_Code As String = ""

        Dim UpdateFlag As Boolean = False
        Dim PLSeqNo As String = ""

        Try
            strSQL = "DELETE FROM W_CIPL_H "
            cmd = New SqlCommand(strSQL, dbConn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            WriteLog(strSQL, W)

            strSQL = "DELETE FROM W_CIPL_D "
            cmd = New SqlCommand(strSQL, dbConn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            WriteLog(strSQL, W)

            strSQL = "DELETE FROM W_SINGLETABLE "
            cmd = New SqlCommand(strSQL, dbConn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            WriteLog(strSQL, W)

            Excel = New Excel.Application
            Workbook = Excel.Workbooks.Open(filepath)

            For j = 1 To Workbook.Worksheets.Count
                If Workbook.Worksheets(j).Name.ToString.Contains("INVOICE") And Workbook.Worksheets(j).Visible = -1 Then
                    WorksheetCI = Workbook.Worksheets(j)
                    WorksheetPL = Workbook.Worksheets(WorksheetCI.Name.ToString.Replace("INVOICE", "Packing List"))

                    RowNumber = RowNumber + 1

                    strSQL = "INSERT INTO " & W_CIPL_H & " VALUES("
                    strSQL &= ColumnSet(RowNumber)
                    ',INVOICENO NVARCHAR(20)
                    strSQL &= " , " & ColumnSet(WorksheetCI.Cells(3, 5).Value)
                    INVOICENO = WorksheetCI.Cells(3, 5).Value
                    ',PACKINGLISTNO NVARCHAR(20)
                    strSQL &= ", " & ColumnSet(WorksheetCI.Cells(4, 5).Value)
                    ',INVOICEDATE NVARCHAR(8)
                    If DateTime.TryParse(WorksheetCI.Cells(5, 5).Value, InvoiceDate) Then
                        InvoiceDate = WorksheetCI.Cells(5, 5).Value
                        strSQL &= ", " & ColumnSet(InvoiceDate.ToString("yyyyMMdd"))
                    Else
                        strSQL &= " ,'' "
                    End If

                    'DECLARERATIONNUMBER
                    If (WorksheetCI.Cells(3, 1).Value & WorksheetCI.Cells(3, 2).Value & WorksheetCI.Cells(3, 3).Value).ToString.ToUpper.Contains("KEFICO") Then
                        strSQL &= " ,'0001'"
                    Else
                        strSQL &= " ,'0002'"
                    End If

                    ',SHIPPEREXPORTER NVARCHAR(100)
                    strSQL &= " ," & ColumnSet(LTrim(RTrim(WorksheetCI.Cells(3, 1).Value _
                        & WorksheetCI.Cells(3, 2).Value _
                        & WorksheetCI.Cells(3, 3).Value)))

                    ',SHIPPEREXPORTERADDRESS NVARCHAR(255)
                    strSQL &= " ,'" & LTrim(WorksheetCI.Cells(4, 1).Value &
                                            WorksheetCI.Cells(4, 2).Value &
                                            WorksheetCI.Cells(4, 3).Value & vbCrLf &
                                            WorksheetCI.Cells(5, 1).Value &
                                            WorksheetCI.Cells(5, 2).Value &
                                            WorksheetCI.Cells(5, 3).Value) & "'"

                    ',CONSIGNEE NVARCHAR(100)
                    strSQL &= " ," & ColumnSet(
                        LTrim(
                        WorksheetCI.Cells(7, 1).Value &
                        WorksheetCI.Cells(7, 2).Value &
                        WorksheetCI.Cells(7, 3).Value))

                    ',CONSIGNEEADDRESS NVARCHAR(255)
                    strSQL &= " ,'" & ColumnSetLine(LTrim(RTrim(WorksheetCI.Cells(8, 1).Value &
                          WorksheetCI.Cells(8, 2).Value &
                            WorksheetCI.Cells(8, 3).Value))) &
                            ColumnSetLine(LTrim(RTrim(WorksheetCI.Cells(9, 1).Value &
                            WorksheetCI.Cells(9, 2).Value &
                            WorksheetCI.Cells(9, 3).Value))) &
                            ColumnSetLine(LTrim(RTrim(WorksheetCI.Cells(10, 1).Value &
                            WorksheetCI.Cells(10, 2).Value &
                            WorksheetCI.Cells(10, 3).Value))) &
                            ColumnSetLine(LTrim(RTrim(WorksheetCI.Cells(11, 1).Value &
                            WorksheetCI.Cells(11, 2).Value &
                            WorksheetCI.Cells(11, 3).Value))) &
                            ColumnSetLine(LTrim(RTrim(WorksheetCI.Cells(12, 1).Value &
                            WorksheetCI.Cells(12, 2).Value &
                            WorksheetCI.Cells(12, 3).Value))) &
                            ColumnSetLine(LTrim(RTrim(WorksheetCI.Cells(13, 1).Value &
                            WorksheetCI.Cells(13, 2).Value &
                            WorksheetCI.Cells(13, 3).Value))) &
                            ColumnSetLine(LTrim(RTrim(WorksheetCI.Cells(14, 1).Value &
                            WorksheetCI.Cells(14, 2).Value &
                            WorksheetCI.Cells(14, 3).Value))) & "'"

                    ',TERMSOFDELIVERY NVARCHAR(10)
                    strSQL &= " ," & ColumnSet(WorksheetCI.Cells(7, 4).Value.ToString.ToUpper.Replace(" ", "").Replace("TERMSOFDELIVERY", "").Replace(":", ""))
                    ',SHIPPINGMODE NVARCHAR(30)
                    strSQL &= " ," & ColumnSet(WorksheetCI.Cells(8, 4).Value.ToString.ToUpper.Replace(" ", "").Replace("SHIPPINGMODE", "").Replace(":", ""))
                    ',PAYMENT NVARCHAR(30)
                    strSQL &= " ," & ColumnSet(WorksheetCI.Cells(9, 4).Value.ToString.ToUpper.Replace(" ", "").Replace("PAYMENT", "").Replace(":", ""))
                    ',PAYMENTBANK NVARCHAR(30)
                    strSQL &= " ," & ColumnSet(WorksheetCI.Cells(10, 4).Value.ToString.ToUpper.Replace(" ", "").Replace("PAYMENTBANK", "").Replace(":", ""))
                    'ACCOUNTNO NVARCHAR(30)
                    strSQL &= " ," & ColumnSet(WorksheetCI.Cells(11, 4).Value.ToString.ToUpper.Replace(" ", "").Replace("ACCOUNTNO.", "").Replace(":", ""))

                    'PURCHASEORDER NVARCHAR(30)                 ---뭐가 들어가는지 잘 모르겠음
                    'strSQL &= " ," & ColumnSet(WorksheetCI.Cells(13, 6).Value.ToString.Replace(" ", "").Replace("PURCHASEORDER", "").Replace(":", ""))
                    strSQL &= " , '' "

                    'LOADINGPORTCODE NVARCHAR(100)

                    cmd = New SqlCommand("SELECT top 1 ISNULL(CONTENTSCODE,'') AS CONTENTSCODE FROM M_CUSTOMCODESET WHERE CODEDIV = 'LOADING PORT'  AND UPPER(REPLACE(CONTENTS,' ','')) LIKE '%" & WorksheetCI.Cells(16, 3).Value.ToString.ToUpper.Replace(" ", "") & "%'", dbConn)
                    dr = cmd.ExecuteReader
                    If dr.HasRows Then
                        dr.Read()
                        Loading_Port_Code = dr("CONTENTSCODE")
                    End If
                    dr.Close()
                    cmd.Dispose()

                    'LOADINGPORTNAME NVARCHAR(100)
                    strSQL &= " ,'" & Loading_Port_Code & "'"
                    strSQL &= " ," & ColumnSet(WorksheetCI.Cells(16, 3).Value & WorksheetCI.Cells(17, 3).Value)
                    'DESTINATION NVARCHAR(100)
                    strSQL &= " ," & ColumnSet(WorksheetCI.Cells(18, 3).Value & WorksheetCI.Cells(19, 3).Value)
                    'NOTIFY NVARCHAR(255)
                    strSQL &= " ,'" & ColumnSetLine(LTrim(RTrim(WorksheetCI.Cells(16, 4).Value &
                            WorksheetCI.Cells(16, 5).Value &
                            WorksheetCI.Cells(16, 6).Value &
                            WorksheetCI.Cells(16, 7).Value &
                            WorksheetCI.Cells(16, 8).Value &
                            WorksheetCI.Cells(16, 9).Value &
                            WorksheetCI.Cells(16, 10).Value))) &
                        ColumnSetLine(LTrim(RTrim(WorksheetCI.Cells(17, 4).Value &
                        WorksheetCI.Cells(17, 5).Value &
                        WorksheetCI.Cells(17, 6).Value &
                        WorksheetCI.Cells(17, 7).Value &
                        WorksheetCI.Cells(17, 8).Value &
                        WorksheetCI.Cells(17, 9).Value &
                        WorksheetCI.Cells(17, 10).Value))) &
                          ColumnSetLine(LTrim(RTrim(WorksheetCI.Cells(18, 4).Value &
                        WorksheetCI.Cells(18, 5).Value &
                        WorksheetCI.Cells(18, 6).Value &
                        WorksheetCI.Cells(18, 7).Value &
                        WorksheetCI.Cells(18, 8).Value &
                        WorksheetCI.Cells(18, 9).Value &
                        WorksheetCI.Cells(18, 10).Value))) &
                         ColumnSet(LTrim(RTrim(WorksheetCI.Cells(19, 4).Value &
                        WorksheetCI.Cells(19, 5).Value &
                        WorksheetCI.Cells(19, 6).Value &
                        WorksheetCI.Cells(19, 7).Value &
                        WorksheetCI.Cells(19, 8).Value &
                        WorksheetCI.Cells(19, 9).Value &
                        WorksheetCI.Cells(19, 10).Value))) & "'"

                    'PICKING LIST START

                    'PL_CONTACTPERSON NVARCHAR(255)   ---뭐가 들어가는지 잘 모르겠음
                    'strSQL &= "," & ColumnSet(WorksheetPL.Cells(19, 6).Value & WorksheetPL.Cells(19, 7).Value & WorksheetPL.Cells(19, 8).Value & WorksheetPL.Cells(19, 9).Value)
                    strSQL &= ",''"

                    'PL_CONTACTPERSON_EMAIL NVARCHAR(255)     ---뭐가 들어가는지 잘 모르겠음
                    'strSQL &= "," & ColumnSet(WorksheetPL.Cells(20, 6).Value)
                    strSQL &= ",''"

                    'PL_ETD NVARCHAR(8)
                    strSQL &= " ," & ColumnSet(CDate(WorksheetPL.Cells(18, 3).Value).ToString("yyyyMMdd"))
                    'PL_ETA NVARCHAR(8)
                    strSQL &= " ," & ColumnSet(CDate(WorksheetPL.Cells(18, 6).Value).ToString("yyyyMMdd"))

                    'PL_TOTAL_MESURMENT Decimal(14,2)
                    'strSQL &= " ," & ColumnSet(WorksheetPL.Cells(22, 5).Value.ToString.ToUpper.Replace(" ", "").Replace("TOTALMEASURMENT:", "").Replace("CBM", ""))
                    'PL_TOTAL_NWEIGHT DECIMAL(14,2)
                    'strSQL &= " ," & ColumnSet(WorksheetPL.Cells(22, 6).Value.ToString.ToUpper.Replace(" ", "").Replace("TOTALN/WEIGHT:", "").Replace("KG", ""))
                    'PL_TOTAL_NWEIGHT_PLTS Decimal(14,0)
                    'strSQL &= " ," & ColumnSet(WorksheetPL.Cells(22, 8).Value.ToString.ToUpper.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("PLTS", ""))
                    'TotalPallet = WorksheetPL.Cells(24, 8).Value.ToString.ToUpper.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("PLTS", "")
                    'PL_TOTAL_GWEIGHT DECIMAL(14,2)
                    'strSQL &= " ," & ColumnSet(WorksheetPL.Cells(22, 7).Value.ToString.ToUpper.Replace(" ", "").Replace("TOTALG/WEIGHT:", "").Replace("KG", ""))

                    Dim iRow As Integer = 24
                    While WorksheetPL.Cells(iRow, 3).Value Is Nothing
                        iRow = iRow + 1
                    End While

                    'While WorksheetPL.Cells(iRow, 3).Value Is Nothing Or WorksheetPL.Cells(iRow, 3).Value.ToString.Replace(" ", "").ToUpper <> "TOTAL"
                    '    iRow = iRow + 1
                    'End While

                    'PL_TOTAL_MESURMENT Decimal(14,2)
                    strSQL &= " ," & ColumnSet(WorksheetPL.Cells(iRow, 5).Value.ToString.ToUpper.Replace(" ", ""))
                    'PL_TOTAL_NWEIGHT DECIMAL(14,2)
                    strSQL &= " ," & ColumnSet(WorksheetPL.Cells(iRow, 6).Value.ToString.ToUpper.Replace(" ", ""))
                    'PL_TOTAL_NWEIGHT_PLTS Decimal(14, 0)
                    strSQL &= " ," & ColumnSet(WorksheetPL.Cells(iRow, 10).Value.ToString.ToUpper.Replace(" ", ""))
                    'TotalPallet = WorksheetPL.Cells(iRow, 8).Value.ToString.ToUpper.Replace(" ", "")
                    TotalPallet = WorksheetPL.Cells(iRow, 10).Value.ToString.ToUpper.Replace(" ", "")
                    'PL_TOTAL_GWEIGHT DECIMAL(14,2)         --
                    strSQL &= " ," & ColumnSet(WorksheetPL.Cells(iRow, 7).Value.ToString.ToUpper.Replace(" ", ""))

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
                    WriteLog(strSQL, W)

                    eRowNumber = 20
                    While True
                        eRowNumber = eRowNumber + 1
                        If WorksheetCI.Cells(eRowNumber, 1).Value IsNot Nothing And WorksheetCI.Cells(eRowNumber, 2).Value IsNot Nothing Then
                            If WorksheetCI.Cells(eRowNumber, 1).Value.ToString.Replace(" ", "").ToUpper.Contains("NO") And
                                    WorksheetCI.Cells(eRowNumber, 2).Value.ToString.Replace(" ", "").ToUpper.Contains("PARTNO") Then
                                eRowNumber = eRowNumber + 2
                                Exit While
                            End If
                        End If
                    End While

                    detailCount = 1
                    While WorksheetCI.Cells(eRowNumber, 2).Value IsNot Nothing
                        If WorksheetCI.Cells(eRowNumber, 2).Value = "0" Or
                           WorksheetCI.Cells(eRowNumber, 2).Value.ToString = "" Or
                           WorksheetCI.Cells(eRowNumber, 2).Value.ToString = "-2146826246" Then _
                            Exit While
                        'While WorksheetCI.Cells(iRow, 2).Value IsNot Nothing Or WorksheetCI.Cells(iRow, 2).Value <> ""

                        strSQL = "INSERT INTO " & W_CIPL_D & " VALUES("
                        'SEQNO BIGINT  Not NULL 
                        strSQL &= "'" & RowNumber.ToString & "'"
                        'DETAILSEQNO INT NOT NULL
                        'strSQL &= ",'" & (detailCount + detailCount_adjust + 1).ToString & "'"
                        strSQL &= ",'" & detailCount & "'"
                        'ORIGINALDETAILSEQNO INT NOT NULL
                        strSQL &= "," & ColumnSet(WorksheetCI.Cells(eRowNumber, 1).Value)
                        'CONVENTIONCODE NVARCHAR(100) 
                        strSQL &= "," & GetConventionCode(WorksheetCI.Cells(eRowNumber, 2).Value).Replace("#N/A", "")
                        'RANNUMBER NVARCHAR(3) 
                        strSQL &= ",NULL"                       'RANNUMBER
                        'RANDETAILNUMBER NVARCHAR(2) 
                        strSQL &= ",NULL"                       'RANDETAILNUMBER
                        'PARTNO NVARCHAR(20) Not NULL
                        strSQL &= "," & ColumnSet(WorksheetCI.Cells(eRowNumber, 2).Value)
                        'PARTNAME NVARCHAR(100)
                        strSQL &= "," & ColumnSet(WorksheetCI.Cells(eRowNumber, 3).Value).ToString.ToUpper
                        'PRODUCT NVARCHAR(100)
                        strSQL &= ",''"
                        'HSCODE NVARCHAR(20)
                        strSQL &= "," & GetHSCode(WorksheetCI.Cells(eRowNumber, 2).Value)
                        'CI_REV NVARCHAR(10) 
                        strSQL &= ",''"
                        'CI_PUN NVARCHAR(5) 
                        strSQL &= "," & ColumnSet(WorksheetCI.Cells(eRowNumber, 5).Value.ToString.ToUpper.Replace("PCS", "PC"))
                        'CI_MPQ NVARCHAR(10) 
                        strSQL &= ",''"
                        'CI_QTY Decimal(14,0) 
                        strSQL &= "," & ColumnSet(WorksheetCI.Cells(eRowNumber, 7).Value)
                        'CI_KGS Decimal(14,1) 
                        strSQL &= ",'0.0'"
                        'CI_UPRICE_USD Decimal(14,2)
                        strSQL &= "," & ColumnSet(WorksheetCI.Cells(eRowNumber, 8).Value)
                        'CI_AMOUNT_USD Decimal(14,2) 
                        strSQL &= "," & ColumnSet(WorksheetCI.Cells(eRowNumber, 9).Value)

                        'PL_SUPPLIERCODE NVARCHAR(10) 
                        strSQL &= ",'' "
                        'PL_PUN NVARCHAR(5) 
                        strSQL &= "," & ColumnSet(WorksheetCI.Cells(eRowNumber, 5).Value.ToString.ToUpper.Replace("PCS", "PC"))
                        'PL_CBM NVARCHAR(10) 
                        strSQL &= ",'' "
                        'PL_QTY Decimal(14'0) 
                        strSQL &= "," & ColumnSet(WorksheetCI.Cells(eRowNumber, 7).Value)
                        'PL_NWEIGHTKGS Decimal(14,2) 
                        strSQL &= ",NULL "
                        'PL_GWEIGHTKGS Decimal(14,2) 
                        strSQL &= ",NULL "
                        '포장개수
                        strSQL &= ",'0' "
                        'Vendor
                        strSQL &= "," & ColumnSet(WorksheetCI.Cells(eRowNumber, 4).Value)
                        strSQL &= ")"
                        cmd = New SqlCommand(strSQL, dbConn)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()
                        WriteLog(strSQL, W)

                        detailCount = detailCount + 1
                        eRowNumber = eRowNumber + 1
                    End While

                    strSQL = "DELETE FROM W_SINGLETABLE "
                    cmd = New SqlCommand(strSQL, dbConn)
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                    WriteLog(strSQL, W)

                    strSQL = " INSERT INTO W_SINGLETABLE "
                    strSQL &= " SELECT DETAILSEQNO,PARTNO "
                    strSQL &= " ,1 AS PALLETRATE "
                    strSQL &= " ,0 AS PALLAETAMOUNT "
                    strSQL &= " ,0 AS ADJUSTFLAG "
                    strSQL &= " FROM W_CIPL_D WHERE LEN(PARTNO) > 5 "
                    cmd = New SqlCommand(strSQL, dbConn)
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                    WriteLog(strSQL, W)


                    'WorksheetPL
                    eRowNumber = 1
                    While True
                        eRowNumber = eRowNumber + 1
                        If WorksheetPL.Cells(eRowNumber, 1).Value IsNot Nothing Then
                            If WorksheetPL.Cells(eRowNumber, 1).Value.ToString.Replace(" ", "").ToUpper.Contains("PKGNO") Then
                                eRowNumber = eRowNumber + 2
                                Exit While
                            End If
                        End If
                    End While

                    PLSeqNo = ""
                    UpdateFlag = False
                    While WorksheetPL.Cells(eRowNumber, 2).Value IsNot Nothing
                        If WorksheetPL.Cells(eRowNumber, 2).Value = "0" Then Exit While

                        If PLSeqNo = "0" Then
                            UpdateFlag = True
                            PLSeqNo = WorksheetPL.Cells(eRowNumber, 1).Value.ToString
                        ElseIf PLSeqNo <> WorksheetPL.Cells(eRowNumber, 1).Value.ToString Then
                            UpdateFlag = True
                            PLSeqNo = WorksheetPL.Cells(eRowNumber, 1).Value.ToString
                        Else
                            UpdateFlag = False
                            PLSeqNo = WorksheetPL.Cells(eRowNumber, 1).Value.ToString
                        End If

                        strSQL = "UPDATE " & W_CIPL_D & " SET "
                        strSQL &= " PARTNO = PARTNO"
                        If UpdateFlag Then
                            strSQL &= " ,PACKAGEAMOUNT = PACKAGEAMOUNT + " & WorksheetPL.Cells(eRowNumber, 10).Value
                        End If
                        strSQL &= " ,PL_QTY = ISNULL(PL_QTY,0) + " & WorksheetPL.Cells(eRowNumber, 5).Value
                        strSQL &= " ,PL_NWEIGHTKGS = ISNULL(PL_NWEIGHTKGS,0) + " & WorksheetPL.Cells(eRowNumber, 6).Value
                        strSQL &= " ,PL_GWEIGHTKGS = ISNULL(PL_GWEIGHTKGS,0) + " & WorksheetPL.Cells(eRowNumber, 7).Value
                        strSQL &= " WHERE  PARTNO = " & ColumnSet(WorksheetPL.Cells(eRowNumber, 2).Value)

                        cmd = New SqlCommand(strSQL, dbConn)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()
                        WriteLog(strSQL, W)

                        eRowNumber = eRowNumber + 1
                    End While

                    eRowNumber = eRowNumber + 1
                    While True
                        eRowNumber = eRowNumber + 1
                        If WorksheetPL.Cells(eRowNumber, 1).Value IsNot Nothing Then
                            If WorksheetPL.Cells(eRowNumber, 1).Value.ToString.Replace(" ", "").ToUpper.Contains("PKGNO") Then
                                eRowNumber = eRowNumber + 1
                                Exit While
                            End If
                        End If
                    End While


                    While WorksheetPL.Cells(eRowNumber, 1).Value IsNot Nothing
                        If WorksheetPL.Cells(eRowNumber, 1).Value.ToString.ToUpper.Contains("TOTAL") Or WorksheetPL.Cells(eRowNumber, 2).Value = "0" Then Exit While

                        strSQL = "UPDATE " & W_CIPL_D & " SET "
                        strSQL &= " PARTNO = PARTNO"

                        strSQL &= " ,PL_QTY = ISNULL(PL_QTY,0) + " & WorksheetPL.Cells(eRowNumber, 5).Value
                        strSQL &= " ,PL_NWEIGHTKGS = ISNULL(PL_NWEIGHTKGS,0) + " & WorksheetPL.Cells(eRowNumber, 6).Value
                        strSQL &= " ,PL_GWEIGHTKGS = ISNULL(PL_GWEIGHTKGS,0) + " & WorksheetPL.Cells(eRowNumber, 7).Value
                        strSQL &= " WHERE  1 = 1 "
                        'strSQL &= " And " & ColumnSet(WorksheetPL.Cells(eRowNumber, 3).Value.ToString.ToUpper.Replace(" ", "")) & " Like '%' + REPLACE(UPPER(PARTNAME),' ','') +'%' "
                        'strSQL &= " AND PL_QTY = '" & WorksheetPL.Cells(eRowNumber, 5).Value & "'"
                        strSQL &= " AND CONVERT(INT,REPLACE(PARTNO,'RB','')) = '" & CInt(WorksheetPL.Cells(eRowNumber, 1).Value) & "'"
                        strSQL &= " AND LEN(PARTNO) < 10 "
                        cmd = New SqlCommand(strSQL, dbConn)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()
                        WriteLog(strSQL, W)

                        PLSeqNo = WorksheetPL.Cells(eRowNumber, 1).Value.ToString

                        eRowNumber = eRowNumber + 1
                    End While

                End If
            Next

            strSQL = " UPDATE " & W_CIPL_D & " Set  "
            strSQL &= " CI_AMOUNT_USD = CI_QTY * CI_UPRICE_USD "
            strSQL &= " WHERE ISNULL(CI_AMOUNT_USD ,0) = 0 "
            cmd = New SqlCommand(strSQL, dbConn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            WriteLog(strSQL, W)

            ''2018/03/15
            Dim ProcessCount As Integer = 1
            While XmlReadVal(GetQueryFullPath, "root/IMPORT/KVPO/PROCESS_" & ProcessCount) <> ""
                If XmlReadVal(GetQueryFullPath, "root/IMPORT/KVPO/PROCESS_" & ProcessCount).ToUpper <> "ITEMCHECK" Then

                    strSQL = XmlReadVal(GetQueryFullPath, "root/IMPORT/KVPO/PROCESS_" & ProcessCount)
                    WriteLog(strSQL, W)
                    cmd = New SqlCommand(strSQL, dbConn)
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()

                    'XmlReadAttribute

                Else        ''상품마스터 검색

                    Dim DataCount As Integer = 0
                    Dim Message As String = ""
                    strSQL = " Select INVOICENO,PARTNO FROM " & W_CIPL_H & " HD "
                    strSQL &= " INNER JOIN " & W_CIPL_D & " DD On HD.SEQNO = DD.SEQNO "
                    strSQL &= " WHERE PARTNO Not In (Select PARTNO FROM M_ITEM)"
                    strSQL &= " AND LEN(PARTNO) > 5"
                    cmd = New SqlCommand(strSQL, dbConn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        DataCount = DataCount + 1
                        Message &= dr("INVOICENO") & "-" & dr("PARTNO") & vbCrLf
                    End While
                    dr.Dispose()
                    cmd.Dispose()
                    WriteLog(strSQL, W)

                    If DataCount <> 0 Then
                        'MsgBoxFail("아래의 데이타가 상품마스타에 존재하지 않습니다." & vbCrLf & Message)
                        ProccessExcelImport.addlog("아래의 데이타가 상품마스타에 존재하지 않습니다." & vbCrLf & Message, 2)
                        Return False
                    End If

                End If
                ProcessCount = ProcessCount + 1
            End While
            ''2018/03/15

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Module
