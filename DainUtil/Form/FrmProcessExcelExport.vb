Imports Microsoft.Office.Interop
Imports System.Data.SqlClient

Public Class FrmProcessItemExport
    Dim FilePath As String
    Dim ReportNo As Integer
    Dim DataCount As Integer = 0
    Public Sub New(ByVal pReportNo As Integer)

        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()
        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하세요.
        ReportNo = pReportNo

    End Sub
    Private Sub FrmProcessItemExport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub addlog(ByVal log As String, ByVal type As Integer)
        If txtLog.Text <> "" Then
            Select Case type
                Case 0      '검증
                    txtLog.Text = txtLog.Text & vbCrLf & "[검증]" & log
                Case 1      '추가
                    'If ProgressBar1.Value + 1 <= ProgressBar1.Maximum Then
                    '    ProgressBar1.Value = ProgressBar1.Value + 1
                    'End If
                    txtLog.Text = txtLog.Text & vbCrLf & "[추가]" & log
                    lblPercent.Text = CInt(ProgressBar1.Value / ProgressBar1.Maximum * 100).ToString & "%"
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
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub FrmProcessItemExport_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        Dim Seqno() As String = Nothing

        If ReportNo = 0 Then
            Me.Close()
        End If
        If FilePath = "" Then
            Me.Close()
        End If

        Select Case ReportNo
            Case R_CIPL_LIST
                Seqno = R_Whare.Split(","c)
                ProgressBar1.Maximum = Seqno.Length

                For i As Integer = 0 To Seqno.Length - 1
                    CIPL_Report(Seqno(i))
                    ProgressBar1.Value = ProgressBar1.Value + 1
                    lblPercent.Text = (ProgressBar1.Value / ProgressBar1.Maximum * 100).ToString & "%"
                Next

                MsgBoxInformation("엑셀 출력이 성공했습니다.")
            Case R_ITEM
                ITEM_Report()
        End Select

    End Sub
    Private Sub CIPL_Report(ByVal seqno As String)
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        Dim xExcel As Excel.Application = New Excel.Application
        Dim Workbook As Excel.Workbook
        Dim WorksheetCIPL As Excel.Worksheet
        Dim RowNumber As Integer = 1
        Dim StartRowNumber As Integer
        Dim INVOICENUMBER As String = ""
        Dim SORT As String = ""
        Try

            addlog("인보이스 리스트를 추출하고 있습니다.", 3)

            strSQL = XmlReadVal(DirYenFix(G_APPPath) & gsXmlQuery, "root/EXPORT/CI")
            strSQL = strSQL.Replace("%1", " HD.SEQNO = ( " & seqno & " ) ")
            cmd = New SqlCommand(strSQL, dbConn)
            dr = cmd.ExecuteReader

            If dr.HasRows = False Then
                addlog("출력할 데이터가 없습니다. ", 3)
                MsgBoxFail("출력할 데이터가 없습니다.")
                Exit Sub
            End If

            xExcel.DisplayAlerts = False
            xExcel = New Excel.Application
            xExcel.Visible = False
            Workbook = xExcel.Workbooks.Add()
            WorksheetCIPL = Workbook.Worksheets(1)

            WorksheetCIPL.Cells(1, 1).Value = "Commercial Invoice & Packing List"
            DirectCast(WorksheetCIPL.Range("A1:A1"), Excel.Range).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

            WorksheetCIPL.Range("A1:P1").Merge()
            WorksheetCIPL.Range("A1:P1").Font.Size = 20

            WorksheetCIPL.Cells(3, 1).Value = "INVOICE NO"
            WorksheetCIPL.Range("A3:A4").Merge()

            WorksheetCIPL.Cells(3, 2).Value = "란번호"
            WorksheetCIPL.Range("B3:B4").Merge()

            WorksheetCIPL.Cells(3, 3).Value = "행번호"
            WorksheetCIPL.Range("C3:C4").Merge()

            WorksheetCIPL.Cells(3, 4).Value = "NO"
            WorksheetCIPL.Range("D3:D4").Merge()

            WorksheetCIPL.Cells(3, 5).Value = "PART NO"
            WorksheetCIPL.Range("E3:E4").Merge()

            WorksheetCIPL.Cells(3, 6).Value = "PART NAME"
            WorksheetCIPL.Range("F3:F4").Merge()

            WorksheetCIPL.Cells(3, 7).Value = "TOTAL"
            WorksheetCIPL.Cells(4, 7).Value = "Q'TY"

            WorksheetCIPL.Cells(3, 8).Value = "P/Un"
            WorksheetCIPL.Range("H3:H4").Merge()

            WorksheetCIPL.Cells(3, 9).Value = "U/PRICE"
            WorksheetCIPL.Cells(4, 9).Value = "(USD)"

            WorksheetCIPL.Cells(3, 10).Value = "AMOUNT"
            WorksheetCIPL.Cells(4, 10).Value = "(USD)"

            WorksheetCIPL.Cells(3, 11).Value = "N/WEIGHT"
            WorksheetCIPL.Cells(3, 11).Value = "(USD)"

            WorksheetCIPL.Cells(3, 12).Value = "G/WEIGHT"
            WorksheetCIPL.Cells(4, 12).Value = "(USD)"

            WorksheetCIPL.Cells(4, 13).Value = "포장개수"
            WorksheetCIPL.Cells(4, 14).Value = "신고세번"
            WorksheetCIPL.Cells(4, 15).Value = "제조사"
            WorksheetCIPL.Cells(4, 16).Value = "협정"

            WorksheetCIPL.Range("A1:P4").Interior.ColorIndex = 35

            RowNumber = 5
            StartRowNumber = 5
            While dr.Read


                If SORT & INVOICENUMBER <> "" And SORT & INVOICENUMBER <> dr("SORT") & dr("INVOICENO") Then
                    WorksheetCIPL.Range("A" & RowNumber.ToString & ":F" & RowNumber.ToString).Merge()
                    WorksheetCIPL.Cells(RowNumber, 1).Value = "합계"

                    DirectCast(WorksheetCIPL.Range("A" & StartRowNumber & ":A" & RowNumber.ToString), Excel.Range).HorizontalAlignment _
                             = Excel.XlHAlign.xlHAlignCenter
                    WorksheetCIPL.Cells(RowNumber, 10).Value = "=SUM(J" & StartRowNumber & ":J" & (RowNumber - 1).ToString & ")"
                    WorksheetCIPL.Cells(RowNumber, 11).Value = "=SUM(K" & StartRowNumber & ":K" & (RowNumber - 1).ToString & ")"
                    WorksheetCIPL.Cells(RowNumber, 12).Value = "=SUM(L" & StartRowNumber & ":L" & (RowNumber - 1).ToString & ")"
                    WorksheetCIPL.Cells(RowNumber, 13).Value = "=SUM(M" & StartRowNumber & ":M" & (RowNumber - 1).ToString & ")"
                    RowNumber = RowNumber + 1
                    StartRowNumber = RowNumber

                    INVOICENUMBER = dr("INVOICENO")
                    SORT = dr("SORT")
                End If

                If SORT = "" Then SORT = dr("SORT")
                If INVOICENUMBER = "" Then
                    INVOICENUMBER = dr("INVOICENO")
                    WorksheetCIPL.Cells(RowNumber, 1).Value = dr("INVOICENO")
                ElseIf INVOICENUMBER = dr("INVOICENO") Then
                    WorksheetCIPL.Cells(RowNumber, 1).Value = ""
                Else
                    WorksheetCIPL.Cells(RowNumber, 1).Value = dr("INVOICENO")
                End If

                WorksheetCIPL.Cells(RowNumber, 2).Value = dr("RANNUMBER")
                WorksheetCIPL.Cells(RowNumber, 3).Value = dr("RANDETAILNUMBER")

                WorksheetCIPL.Cells(RowNumber, 4).Value = dr("DETAILSEQNO")
                WorksheetCIPL.Cells(RowNumber, 5).Value = dr("PARTNO")
                WorksheetCIPL.Cells(RowNumber, 6).Value = dr("PARTNAME")
                WorksheetCIPL.Cells(RowNumber, 7).Value = dr("PL_QTY")
                WorksheetCIPL.Cells(RowNumber, 8).Value = dr("PL_PUN")
                WorksheetCIPL.Cells(RowNumber, 9).Value = dr("CI_UPRICE_USD")
                WorksheetCIPL.Cells(RowNumber, 10).Value = dr("CI_AMOUNT_USD")
                WorksheetCIPL.Cells(RowNumber, 11).Value = dr("PL_NWEIGHTKGS")
                WorksheetCIPL.Cells(RowNumber, 12).Value = dr("PL_GWEIGHTKGS")
                WorksheetCIPL.Cells(RowNumber, 13).Value = dr("PACKAGEAMOUNT")
                WorksheetCIPL.Cells(RowNumber, 14).Value = dr("HSCODE")
                WorksheetCIPL.Cells(RowNumber, 15).Value = dr("PRODUCT")
                WorksheetCIPL.Cells(RowNumber, 16).Value = dr("CONVENTIONCODE")

                addlog("[" & dr("PARTNO") & "] 출력", 1)

                RowNumber = RowNumber + 1

            End While

            dr.Close()
            cmd.Dispose()

            WorksheetCIPL.Range("A" & RowNumber.ToString & ":F" & RowNumber.ToString).Merge()
            WorksheetCIPL.Cells(RowNumber, 1).Value = "합계"

            DirectCast(WorksheetCIPL.Range("A" & StartRowNumber & ":A" & RowNumber.ToString), Excel.Range).HorizontalAlignment _
                             = Excel.XlHAlign.xlHAlignCenter
            WorksheetCIPL.Cells(RowNumber, 10).Value = "=SUM(J" & StartRowNumber & ":J" & (RowNumber - 1).ToString & ")"
            WorksheetCIPL.Cells(RowNumber, 11).Value = "=SUM(K" & StartRowNumber & ":K" & (RowNumber - 1).ToString & ")"
            WorksheetCIPL.Cells(RowNumber, 12).Value = "=SUM(L" & StartRowNumber & ":L" & (RowNumber - 1).ToString & ")"
            WorksheetCIPL.Cells(RowNumber, 13).Value = "=SUM(M" & StartRowNumber & ":M" & (RowNumber - 1).ToString & ")"

            WorksheetCIPL.Range("F8", "F8").Select()
            WorksheetCIPL.Pictures.Insert(G_Image & "ReturnableBox.png").Select()

            WorksheetCIPL.Cells.Columns("A:P").AutoFit()
            WorksheetCIPL.Range("A3", "P" & RowNumber.ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            WorksheetCIPL.Range("A3", "P" & RowNumber.ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            WorksheetCIPL.Range("A3", "P" & RowNumber.ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            WorksheetCIPL.Range("A3", "P" & RowNumber.ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            WorksheetCIPL.Range("A3", "P" & RowNumber.ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            WorksheetCIPL.Range("A3", "P" & RowNumber.ToString).Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            'G_ReportPath

            Workbook.SaveAs(G_ReportPath & INVOICENUMBER & ".xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel8)

            WorksheetCIPL = Nothing
            Workbook.Close(False)
            xExcel.Visible = True
            xExcel.Quit()
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xExcel)

            addlog("엑셀 출력이 성공했습니다.", 3)
            addlog("[" & G_ReportPath & INVOICENUMBER & ".xls" & "] 에 파일이 저장되었습니다.", 3)
            'txtLog.Text &= vbCrLf & "[" & FilePath & "] 에 파일이 저장되었습니다."
        Catch ex As Exception
            MsgBoxFail("엑셀 출력에 실패했습니다." & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub ITEM_Report()
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim Excel As Excel.Application = New Excel.Application
        Dim Workbook As Excel.Workbook
        Dim WorksheetMITEM As Excel.Worksheet
        Dim i As Integer = 2
        Dim SeqNO As Integer = 0

        Try
            strSQL = "SELECT COUNT(*) AS DATACOUNT FROM M_ITEM"
            cmd = New SqlCommand(strSQL, dbConn)
            dr = cmd.ExecuteReader
            dr.Read()
            DataCount = dr("DATACOUNT")
            dr.Close()
            cmd.Dispose()
            addlog("상품마스터를 추출하고 있습니다.", 3)

            ProgressBar1.Maximum = DataCount

            Excel = New Excel.Application
            Excel.Visible = False
            Workbook = Excel.Workbooks.Add()
            'Workbook = Excel.Workbooks.Open(FilePath)
            WorksheetMITEM = Workbook.Worksheets(1)
            WorksheetMITEM.Cells(1, 1).Value = "제품코드"
            WorksheetMITEM.Cells(1, 2).Value = "품명규격1(규격내역)"
            WorksheetMITEM.Cells(1, 3).Value = "세번부호"
            WorksheetMITEM.Cells(1, 4).Value = "제조자"
            WorksheetMITEM.Cells(1, 5).Value = "협정"
            WorksheetMITEM.Cells(1, 6).Value = "표준품명"
            WorksheetMITEM.Cells(1, 7).Value = "거래품명"
            WorksheetMITEM.Range("A1", "G1").Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous
            WorksheetMITEM.Cells.Columns("A:G").NumberFormatLocal = "@"

            strSQL = XmlReadVal(DirYenFix(G_APPPath) & gsXmlQuery, "root/EXPORT/ITEM")
            cmd = New SqlCommand(strSQL, dbConn)
            dr = cmd.ExecuteReader
            While dr.Read()

                WorksheetMITEM.Cells(i, 1).NumberFormatLocal = "G/표준"
                WorksheetMITEM.Cells(i, 1).Value = dr("PARTNO")

                WorksheetMITEM.Cells(i, 2).NumberFormatLocal = "@"
                WorksheetMITEM.Cells(i, 2).Value = dr("PARTNAME")

                WorksheetMITEM.Cells(i, 3).NumberFormatLocal = "G/표준"
                WorksheetMITEM.Cells(i, 3).Value = dr("HSCODE")

                WorksheetMITEM.Cells(i, 4).NumberFormatLocal = "@"
                WorksheetMITEM.Cells(i, 4).Value = dr("PRODUCT")

                WorksheetMITEM.Cells(i, 5).NumberFormatLocal = "@"
                WorksheetMITEM.Cells(i, 5).Value = dr("CONVENTIONCODE")

                WorksheetMITEM.Cells(i, 6).NumberFormatLocal = "@"
                WorksheetMITEM.Cells(i, 6).Value = dr("STANDARDPARTNAME")
                WorksheetMITEM.Cells(i, 7).Value = dr("TRADEPARTNAME")
                'ProgressBar1.Value = ProgressBar1.Value + 1
                addlog("[" & dr("PARTNO") & "] 출력", 1)
                Application.DoEvents()
                i = i + 1
            End While
            WorksheetMITEM.Cells.Columns("A:G").AutoFit()
            dr.Close()
            cmd.Dispose()
            Workbook.SaveAs(FilePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel8)

            WorksheetMITEM = Nothing
            Workbook.Close(False)
            Excel.Visible = True
            Excel.Quit()
            System.Runtime.InteropServices.Marshal.ReleaseComObject(Excel)

            addlog("엑셀 출력에 실패했습니다.", 3)
            MsgBoxInformation("엑셀 출력이 성공했습니다.")
            addlog("[" & FilePath & "] 에 파일이 저장되었습니다.", 3)

        Catch ex As Exception
            addlog("엑셀 출력에 실패했습니다.", 2)
            MsgBoxFail("엑셀 출력에 실패했습니다." & vbCrLf & ex.Message)
        End Try
    End Sub

End Class