Imports System.Data.SqlClient

Public Class FrmInvoicePackingPrint
    Dim load_flag As Boolean = False
    Dim gMessageNumber As Integer = 1
    Dim headerdatatable As New DataTable
    Dim gWhere As String

    Private Sub FrmPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            load_flag = True
            rdbCIPLlist.Checked = True
            SetCombo()
        Catch ex As Exception

        End Try
        load_flag = False
    End Sub
    Private Function SetCombo()
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim strSQL As String

        Try
            strSQL = "SELECT * FROM F_LISTOUTITEM "
            strSQL &= " WHERE Visible = '1' "
            strSQL &= " And MESSAGEID = '" & gMessageNumber & "'"
            strSQL &= " AND PRECESSINGCLASS = 'H'"
            strSQL &= " ORDER BY INDICATIONORDER "
            cmd = New SqlCommand(strSQL, dbConn)
            headerdatatable = New DataTable
            headerdatatable.Load(cmd.ExecuteReader())
            cmd.Dispose()

            cmbSearch101.Items.Clear()
            cmbSearch102.Items.Clear()
            cmbSearch103.Items.Clear()

            cmbSearch101.Items.Add("--지정없음--")
            cmbSearch102.Items.Add("--지정없음--")
            cmbSearch103.Items.Add("--지정없음--")
            For i As Integer = 0 To headerdatatable.Rows.Count - 1
                cmbSearch101.Items.Add(headerdatatable.Rows(i)("INDICATIONNAME"))
                cmbSearch102.Items.Add(headerdatatable.Rows(i)("INDICATIONNAME"))
                cmbSearch103.Items.Add(headerdatatable.Rows(i)("INDICATIONNAME"))
            Next
            cmbSearch101.SelectedIndex = 0
            cmbSearch102.SelectedIndex = 0
            cmbSearch103.SelectedIndex = 0

            txtSearch101.Text = ""
            txtSearch102.Text = ""
            txtSearch103.Text = ""
            Return True
        Catch ex As Exception
            MsgBoxFail(ex.Message)
            Return False
        End Try


    End Function

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        'gWhere = ""
        'If cmbSearch101.SelectedIndex <> 0 Then
        '    gWhere &= " AND " & headerdatatable.Rows(cmbSearch101.SelectedIndex - 1)("COLUMNNAME")
        '    gWhere &= " LIKE '%" & txtSearch101.Text & "%'"
        'End If

        'If cmbSearch102.SelectedIndex <> 0 Then
        '    gWhere &= " AND " & headerdatatable.Rows(cmbSearch102.SelectedIndex - 1)("COLUMNNAME")
        '    gWhere &= " LIKE '%" & txtSearch102.Text & "%'"
        'End If

        'If cmbSearch103.SelectedIndex <> 0 Then
        '    gWhere &= " AND " & headerdatatable.Rows(cmbSearch103.SelectedIndex - 1)("COLUMNNAME")
        '    gWhere &= " LIKE '%" & txtSearch103.Text & "%'"
        'End If

        'R_WHERE = gWhere

        'SaveFileDialog1.FileName = ""
        'SaveFileDialog1.Filter = "엑셀파일(*.xls;*.xlsx)|*.xls;*.xlsx"
        'SaveFileDialog1.ShowDialog()

        Dim sform As New Form
        If rdbCIPLlist.Checked Then
            sform = New FrmProcessItemExport(R_CIPL_LIST)
            'sform = New FrmProcessItemExport(SaveFileDialog1.FileName, R_CIPL_LIST)
            sform.ShowDialog()
        End If
    End Sub

    Private Sub cmbSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearch101.SelectedIndexChanged
        If load_flag Then Exit Sub
        If cmbSearch101.SelectedIndex = 0 Then
            txtSearch101.Text = ""
        End If
    End Sub

    Private Sub cmbSearch102_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearch102.SelectedIndexChanged
        If load_flag Then Exit Sub
        If cmbSearch102.SelectedIndex = 0 Then
            txtSearch102.Text = ""
        End If
    End Sub

    Private Sub cmbSearch103_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearch103.SelectedIndexChanged
        If load_flag Then Exit Sub
        If cmbSearch103.SelectedIndex = 0 Then
            txtSearch103.Text = ""
        End If
    End Sub
End Class