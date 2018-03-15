Imports System.Data.SqlClient

Public Class FrmGenEnv
    Dim load_flag As Boolean = False
    Private Sub ObjectChanged(sender As Object, e As EventArgs) Handles txtReporterCode.TextChanged, txtReporterName.TextChanged
        btnUpdate.Visible = True
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim strSQL As String
        'Dim cmd As OleDb.OleDbCommand
        Dim cmd As sqlcommand

        Try
            strSQL = " UPDATE F_GENENV SET "
            strSQL += "DATAKEEPDAYS = " + ColumnSet(txtDataKeepDays.Value)
            G_DATAKEEPDAYS = txtDataKeepDays.Value
            If ChkFileOutFlag.Checked Then
                strSQL += ",FILEOUTFLAG = " + ColumnSet("1")
                G_FILEOUTFLAG = True
            Else
                strSQL += ",FILEOUTFLAG = " + ColumnSet("0")
                G_FILEOUTFLAG = False
            End If
            strSQL += ",REPORTCODE = " + ColumnSet(txtReporterCode.Text)
            strSQL += ",REPORTNAME = " + ColumnSet(txtReporterName.Text)
            strSQL += ",REPORTPRESENTER = " + ColumnSet(txtReportPresenter.Text)

            strSQL += ",SHIPPERSEXPORT1CODE = " + ColumnSet(txtSHIPPERSEXPORT1CODE.Text)
            strSQL += ",SHIPPERSEXPORT1NAME = " + ColumnSet(txtSHIPPERSEXPORT1NAME.Text)
            strSQL += ",SHIPPERSEXPORT1PRESENTER = " + ColumnSet(txtSHIPPERSEXPORT1PRESENTER.Text)
            strSQL += ",SHIPPERSEXPORT1POSTALCODE = " + ColumnSet(txtSHIPPERSEXPORT1POSTALCODE.Text)
            strSQL += ",SHIPPERSEXPORT1ADDRESS = " + ColumnSet(txtSHIPPERSEXPORT1ADDRESS.Text)
            strSQL += ",SHIPPERSEXPORT1CUSTOMSCODE = " + ColumnSet(txtSHIPPERSEXPORT1CUSTOMSCODE.Text)

            strSQL += ",SHIPPERSEXPORTELSECODE = " + ColumnSet(txtSHIPPERSEXPORTELSECODE.Text)
            strSQL += ",SHIPPERSEXPORTELSENAME = " + ColumnSet(txtSHIPPERSEXPORTELSENAME.Text)
            strSQL += ",SHIPPERSEXPORTELSEPRESENTER = " + ColumnSet(txtSHIPPERSEXPORTELSEPRESENTER.Text)
            strSQL += ",SHIPPERSEXPORTELSEPOSTALCODE = " + ColumnSet(txtSHIPPERSEXPORTELSEPOSTALCODE.Text)
            strSQL += ",SHIPPERSEXPORTELSEADDRESS = " + ColumnSet(txtSHIPPERSEXPORTELSEADDRESS.Text)
            strSQL += ",SHIPPERSEXPORTELSECUSTOMSCODE = " + ColumnSet(txtSHIPPERSEXPORTELSECUSTOMSCODE.Text)

            cmd = New SqlCommand(strSQL, dbConn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            MsgBoxOK("환경설정이 갱신되었습니다. ")
            Me.Close()
        Catch ex As Exception
            MsgBoxFail(ex.Message)
        Finally
            cmd.Dispose()
        End Try

    End Sub

    Private Sub FrmGenEnv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        'Dim cmd As OleDb.OleDbCommand
        'Dim dr As OleDb.OleDbDataReader

        Try
            load_flag = True
            btnUpdate.Visible = False

            strSQL = "SELECT TOP 1 * FROM F_GENENV"
            cmd = New SqlCommand(strSQL, dbConn)
            dr = cmd.ExecuteReader
            While dr.Read

                txtDataKeepDays.Value = dr("DATAKEEPDAYS")
                If dr("FILEOUTFLAG") = 1 Then
                    ChkFileOutFlag.Checked = True
                Else
                    ChkFileOutFlag.Checked = False
                End If
                txtReporterCode.Text = dr("REPORTCODE")
                txtReporterName.Text = dr("REPORTNAME")
                txtReportPresenter.Text = dr("REPORTPRESENTER")

                txtSHIPPERSEXPORT1CODE.Text = dr("SHIPPERSEXPORT1CODE")
                txtSHIPPERSEXPORT1NAME.Text = dr("SHIPPERSEXPORT1NAME")
                txtSHIPPERSEXPORT1PRESENTER.Text = dr("SHIPPERSEXPORT1PRESENTER")
                txtSHIPPERSEXPORT1POSTALCODE.Text = dr("SHIPPERSEXPORT1POSTALCODE")
                txtSHIPPERSEXPORT1ADDRESS.Text = dr("SHIPPERSEXPORT1ADDRESS")
                txtSHIPPERSEXPORT1CUSTOMSCODE.Text = dr("SHIPPERSEXPORT1CUSTOMSCODE")

                txtSHIPPERSEXPORTELSECODE.Text = dr("SHIPPERSEXPORTELSECODE")
                txtSHIPPERSEXPORTELSENAME.Text = dr("SHIPPERSEXPORTELSENAME")
                txtSHIPPERSEXPORTELSEPRESENTER.Text = dr("SHIPPERSEXPORTELSEPRESENTER")
                txtSHIPPERSEXPORTELSEPOSTALCODE.Text = dr("SHIPPERSEXPORTELSEPOSTALCODE")
                txtSHIPPERSEXPORTELSEADDRESS.Text = dr("SHIPPERSEXPORTELSEADDRESS")
                txtSHIPPERSEXPORTELSECUSTOMSCODE.Text = dr("SHIPPERSEXPORTELSECUSTOMSCODE")

            End While
            dr.Close()
            cmd.Dispose()

            load_flag = False
        Catch ex As Exception
            MsgBoxFail(ex.Message)
        Finally
            dr.Close()
            cmd.Dispose()
        End Try

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class