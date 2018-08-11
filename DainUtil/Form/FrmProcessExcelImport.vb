Imports System.IO
'Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports System.Data.SqlClient

Public Class FrmProcessExcelImport
    Dim load_flag As Boolean = False
    Dim Importfiles As String()
    Private Sub FrmProcessExcelImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        btnClose.Visible = True
    End Sub
    Public Sub addlog(ByVal log As String, ByVal type As Integer, Optional ByVal MessageFlag As Boolean = False)
        If txtLog.Text <> "" Then
            Select Case type
                Case 0      '검증
                    txtLog.Text = txtLog.Text & vbCrLf & "[검증]" & log
                    WriteLog(log, W)
                    If MessageFlag Then MsgBoxInformation(log)
                Case 1      '추가`
                    lblPercent.Text = CInt(ProgressBar1.Value / ProgressBar1.Maximum * 100).ToString & "%"
                    txtLog.Text = txtLog.Text & vbCrLf & "[추가]" & log
                    WriteLog(log, S)
                    If MessageFlag Then MsgBoxInformation(log)
                Case 2     '실패
                    txtLog.Text = txtLog.Text & vbCrLf & "[실패]" & log
                    WriteLog(log, E)
                    If MessageFlag Then MsgBoxFail(log)
                Case 3     '알림
                    txtLog.Text = txtLog.Text & vbCrLf & "[알림]" & log
                    WriteLog(log, N)
                    If MessageFlag Then MsgBoxInformation(log)
            End Select

        Else
            Select Case type
                Case 0      '검증
                    txtLog.Text = "[검증]" & log
                    WriteLog(log, W)
                    If MessageFlag Then MsgBoxInformation(log)
                Case 1      '추가
                    lblPercent.Text = CInt(ProgressBar1.Value / ProgressBar1.Maximum * 100).ToString & "%"
                    txtLog.Text = "[추가]" & log
                    WriteLog(log, N)
                    If MessageFlag Then MsgBoxInformation(log)
                Case 2     '실패
                    txtLog.Text = "[실패]" & log
                    WriteLog(log, E)
                    If MessageFlag Then MsgBoxFail(log)
                Case 3     '알림
                    txtLog.Text = "[알림]" & log
                    WriteLog(log, N)
                    If MessageFlag Then MsgBoxInformation(log)
            End Select
        End If
        txtLog.SelectionStart = txtLog.Text.Length
        txtLog.Focus()
        txtLog.ScrollToCaret()

        Me.Refresh()
    End Sub
    Private Sub FrmProcessExcelImport_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Dim cmd As SqlCommand
        Dim strSQL As String
        Dim ImportfilesTemp() As String

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

        Dim SuccessCount As Integer = 0
        Dim FailCount As Integer = 0
        Dim ImportFailFile As String = ""

        ImportfilesTemp = getFiles(G_ExcelInPath, "*.xls|*.xlsx", System.IO.SearchOption.TopDirectoryOnly)
        For i As Integer = 0 To ImportfilesTemp.Length - 1
            If ImportfilesTemp(i).ToUpper.Contains("~$") = False Then
                If Importfiles Is Nothing Then
                    ReDim Preserve Importfiles(0)
                Else
                    ReDim Preserve Importfiles(Importfiles.Length)
                End If

                Importfiles(Importfiles.Length - 1) = ImportfilesTemp(i)
            End If
        Next
        'Importfiles = getFiles(G_ExcelInPath, "*.xls|*.xlsx", System.IO.SearchOption.TopDirectoryOnly)

        If Importfiles.Length = 0 Then
            addlog("임포트할 파일이 없습니다.", 2)
            MsgBoxOK("임포트할 파일이 없습니다." & vbCrLf & ImportFailFile)
            Me.Close()
            Exit Sub
        End If

        ProgressBar1.Maximum = Importfiles.Length

        For i As Integer = 0 To Importfiles.Length - 1
            If txtLog.Text <> "" Then
                txtLog.Text &= vbCrLf
            End If
            txtLog.Text &= vbCrLf & "***************************************************"
            txtLog.Text &= vbCrLf & "** " & Importfiles(i) & "의 처리를 시작합니다. **"
            txtLog.Text &= vbCrLf & "***************************************************"

            If Importfiles(i).ToUpper.Contains("~$") = False Then
                Select Case GetInvoiceTypeFromFile(Importfiles(i).ToUpper)
                    Case "KVPO"
                        If ImportKVPO_CI(Importfiles(i)) Then
                            SuccessCount = SuccessCount + 1
                        Else
                            FailCount = FailCount + 1
                            ImportFailFile &= Importfiles(i)
                        End If
                    Case "KVPA"
                        If ImportKVPO_CI(Importfiles(i)) Then
                            SuccessCount = SuccessCount + 1
                        Else
                            FailCount = FailCount + 1
                            ImportFailFile &= Importfiles(i)
                        End If
                    Case "KCP"
                        If ImportKCP_CI(Importfiles(i)) Then
                            SuccessCount = SuccessCount + 1
                        Else
                            FailCount = FailCount + 1
                            ImportFailFile &= Importfiles(i)
                        End If
                    Case Else
                        If ImportKCP_CI(Importfiles(i)) Then
                            SuccessCount = SuccessCount + 1
                        Else
                            FailCount = FailCount + 1
                            ImportFailFile &= Importfiles(i)
                        End If
                End Select
            End If

            If ProgressBar1.Value + 1 <= ProgressBar1.Maximum Then
                ProgressBar1.Value = ProgressBar1.Value + 1
            End If
            lblPercent.Text = CInt(ProgressBar1.Value / ProgressBar1.Maximum * 100).ToString & "%"

        Next

        ExcelProcessKill()

        If FailCount > 0 Then
            '[알림]임포트를 완료했습니다. (성공1건/1건)
            addlog("임포트를 완료했습니다. (성공 : " & SuccessCount & " 건 / 총 " & (SuccessCount + FailCount).ToString & " 건) " & vbCrLf & "처리에 실패한 파일이 있습니다. 아래의 파일을 참고해주세요" & vbCrLf & ImportFailFile, 2)
            MsgBoxOK("임포트를 완료했습니다. (성공 : " & SuccessCount & " 건 / 총 " & (SuccessCount + FailCount).ToString & " 건) " & vbCrLf & "처리에 실패한 파일이 있습니다. 아래의 파일을 참고해주세요" & vbCrLf & ImportFailFile)
        Else
            addlog("임포트를 완료했습니다. (성공 : " & SuccessCount & " 건 / 총 " & (SuccessCount + FailCount).ToString & " 건) ", 3)
            MsgBoxOK("임포트를 완료했습니다. (성공 : " & SuccessCount & " 건 / 총 " & (SuccessCount + FailCount).ToString & " 건) ")
        End If

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim cmd As SqlCommand
        cmd = New SqlCommand(" If EXISTS (Select * from tempdb..sysobjects WHERE ID = object_id('tempdb..#temp_" & D_CIPL_H & "') )  DROP TABLE #temp_" & D_CIPL_H, dbConn)
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        cmd = New SqlCommand(" IF EXISTS (select * from tempdb..sysobjects WHERE ID = object_id('tempdb..#temp_" & D_CIPL_D & "') )  DROP TABLE #temp_" & D_CIPL_D, dbConn)
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        Me.Close()
    End Sub

End Class