Imports System.Data.SqlClient

Public Class FrmMain

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'G_IPUser
        GetIPUser()
        If DbConnect() = False Then Application.Exit()
        If Interval() = False Then Application.Exit()
        If GetEnv() = False Then Application.Exit()
        Me.Text = G_APPNAME + "(" + G_Version + ")"
        ClearData()
        WriteLog("프로그램실행")
    End Sub

    Private Sub btnInvoice_Click(sender As Object, e As EventArgs) Handles btnInvoice.Click
        Dim sform As Form
        sform = New FrmInvoicePacking
        sform.ShowDialog()
        Me.Refresh()
    End Sub
    Public Sub btnExcelImport_Click(sender As Object, e As EventArgs) Handles btnExcelImport.Click

        If MsgBoxConfirm("엑셀파일을 임포트 하시겠습니까?") = DialogResult.Yes Then
            ProccessExcelImport = New FrmProcessExcelImport
            ProccessExcelImport.ShowDialog()
            Me.Refresh()
        End If
    End Sub

    Private Sub btnTextOutput_Click(sender As Object, e As EventArgs) Handles btnTextOutput.Click
        Dim sform As Form
        sform = New FrmProcessTextOutput
        sform.ShowDialog()
        Me.Refresh()
    End Sub

    Private Sub btnGenEnv_Click(sender As Object, e As EventArgs) Handles btnGenEnv.Click
        Dim sform As Form
        sform = New FrmGenEnv
        sform.ShowDialog()
        Me.Refresh()
    End Sub

    Private Sub FrmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            dbConn.Close()
            WriteLog("프로그램 종료", N)
        Catch ex As Exception
            MsgBoxFail(ex.Message)
        End Try
    End Sub

    Private Sub btnItemMaster_Click(sender As Object, e As EventArgs) Handles btnItemMaster.Click
        Dim sform As Form
        sform = New FrmItem
        sform.ShowDialog()
        Me.Refresh()
    End Sub

    Private Sub btnStandardMaster_Click(sender As Object, e As EventArgs) Handles btnStandardMaster.Click
        Dim sform As Form
        sform = New FrmStandardMaster
        sform.ShowDialog()
        Me.Refresh()
    End Sub

    Private Sub btnCustom_Click(sender As Object, e As EventArgs) Handles btnCustom.Click
        Dim sform As Form
        sform = New FrmCustomMaster
        sform.ShowDialog()
        Me.Refresh()
    End Sub

    Private Sub ClearData()
        Dim cmd As New SqlCommand
        Dim strSQL As String

        strSQL = " DELETE FROM D_CIPL_D  "
        strSQL &= " WHERE SEQNO In ( "
        strSQL &= " SELECT SEQNO FROM D_CIPL_H "
        strSQL &= " WHERE CONVERT(DATETIME, "
        strSQL &= " LEFT(IMPORTDATEANDTIME,4) "
        strSQL &= " +'-' +SUBSTRING(IMPORTDATEANDTIME,5,2) "
        strSQL &= " +'-' +SUBSTRING(IMPORTDATEANDTIME,7,2) "
        strSQL &= " )  <= dateadd(day," & (G_DATAKEEPDAYS * -1).ToString & ",getdate()) "
        If G_FILEOUTFLAG Then
            strSQL &= " AND OUTPUTFLAG <> '1'"
        End If
        strSQL &= " ) "
        cmd = New SqlCommand(strSQL, dbConn)
        cmd.ExecuteNonQuery()
        cmd.Dispose()

        strSQL = " DELETE FROM D_CIPL_H "
        strSQL &= " WHERE CONVERT(DATETIME, "
        strSQL &= " LEFT(IMPORTDATEANDTIME,4) "
        strSQL &= " +'-' +SUBSTRING(IMPORTDATEANDTIME,5,2) "
        strSQL &= " +'-' +SUBSTRING(IMPORTDATEANDTIME,7,2) "
        strSQL &= " )  <= dateadd(day," & (G_DATAKEEPDAYS * -1).ToString & ",getdate()) "
        If G_FILEOUTFLAG Then
            strSQL &= " AND OUTPUTFLAG <> '1'"
        End If
        cmd = New SqlCommand(strSQL, dbConn)
        cmd.ExecuteNonQuery()
        cmd.Dispose()

    End Sub

End Class
