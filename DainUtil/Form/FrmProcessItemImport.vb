Imports Microsoft.Office.Interop
Imports System.Data.SqlClient

Public Class FrmProcessItemImport
    Dim FilePath As String
    Dim DataCount As Integer
    Public Sub New(ByVal pFilePath As String)

        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()
        FilePath = pFilePath
        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하세요.

    End Sub
    Private Sub FrmProcessItemImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

    Private Sub FrmProcessItemImport_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Dim strSQL As String
        Dim cmd As SqlCommand


        Dim Excel As Excel.Application = New Excel.Application
        Dim Workbook As Excel.Workbook
        Dim WorksheetMITEM As Excel.Worksheet
        Dim i As Integer = 2
        Dim SeqNO As Integer = 0

        Try

            strSQL = " DELETE FROM M_ITEM"
            cmd = New SqlCommand(strSQL, dbConn)
            cmd.ExecuteNonQuery()
            addlog("상품마스터를 초기화했습니다.", 3)

            Excel = New Excel.Application
            Workbook = Excel.Workbooks.Open(FilePath)
            WorksheetMITEM = Workbook.Worksheets(1)

            While WorksheetMITEM.Cells(i, 1).Value IsNot Nothing
                DataCount = DataCount + 1
                i = i + 1
            End While
            ProgressBar1.Maximum = DataCount

            i = 2

            While WorksheetMITEM.Cells(i, 1).Value IsNot Nothing
                SeqNO = SeqNO + 1
                strSQL = "INSERT INTO M_ITEM VALUES( "
                strSQL &= " '" & SeqNO & "'"
                strSQL &= " ," & ColumnSet(WorksheetMITEM.Cells(i, 1).Value).ToUpper
                strSQL &= " ," & ColumnSet(WorksheetMITEM.Cells(i, 2).Value).ToUpper
                strSQL &= " ," & ColumnSet(WorksheetMITEM.Cells(i, 3).Value).ToUpper
                strSQL &= " ," & ColumnSet(WorksheetMITEM.Cells(i, 4).Value).ToUpper
                strSQL &= " ," & ColumnSet(WorksheetMITEM.Cells(i, 5).Value).ToString().Replace("-2146826246", "해당없음")
                strSQL &= " ," & ColumnSet(WorksheetMITEM.Cells(i, 6).Value).ToUpper

                strSQL &= " ," & ColumnSet(WorksheetMITEM.Cells(i, 7).Value).ToUpper
                strSQL &= ")"
                cmd = New SqlCommand(strSQL, dbConn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                addlog("[" & WorksheetMITEM.Cells(i, 1).Value & "] 을 추가했습니다.", 1)

                i = i + 1
            End While
            WorksheetMITEM = Nothing
            Workbook.Close(False)
            Excel.Quit()

            strSQL = " UPDATE M_ITEM SET CONVENTIONCODE = '해당없음' WHERE CONVENTIONCODE = '' "
            cmd = New SqlCommand(strSQL, dbConn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            MsgBoxInformation("엑셀 임포트가 성공했습니다.")
            addlog("엑셀 임포트가 성공했습니다.", 3)
        Catch ex As Exception
            MsgBoxFail("데이타 갱신에 실패했습니다." & vbCrLf & ex.Message)
            addlog("엑셀 임포트가 성공했습니다.", 2)
        End Try
    End Sub
End Class