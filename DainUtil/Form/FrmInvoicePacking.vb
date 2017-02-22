Imports System.Data.SqlClient

Public Class FrmInvoicePacking
    Dim Load_flag As Boolean
    Dim headerdatatable As DataTable = New DataTable
    Dim gOrder As String
    Dim gMessageNumber As Integer = 1
    Dim CheckboxColumn As New DataGridViewCheckBoxColumn
    Dim gWhere As String

    'Dim headerdatatable2 = New DataTable
    'Dim gOrder2 As String
    'Dim gMessageNumber2 As Integer = 2
    'Dim CheckboxColumn2 As New DataGridViewCheckBoxColumn
    'Dim gWhere2 As String

    Private Sub FrmInvoicePacking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_flag = True

        Try
            headerdatatable = New DataTable
            DataGridView1.ColumnCount = 0
            DataGridView1.RowCount = 0
            gWhere = ""
            If SetHeader() = False Then
                Application.Exit()
            End If
            If SetDetail() = False Then
                Application.Exit()
            End If
            If SetCombo() = False Then
                Application.Exit()
            End If

            'headerdatatable2 = New DataTable
            'DataGridView2.ColumnCount = 0
            'DataGridView2.RowCount = 0
            'gWhere = ""
            'If SetHeader2() = False Then
            '    Application.Exit()
            'End If
            'If SetDetail2() = False Then
            '    Application.Exit()
            'End If
            'If SetCombo2() = False Then
            '    Application.Exit()
            'End If

        Catch ex As Exception
            MsgBoxFail(ex.Message)
            Application.Exit()
        End Try
        Load_flag = False
    End Sub
    Private Function SetCombo()

        Try
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
    'Private Function SetCombo2()

    '    Try
    '        cmbSearch201.Items.Clear()
    '        cmbSearch202.Items.Clear()
    '        cmbSearch203.Items.Clear()

    '        cmbSearch201.Items.Add("--지정없음--")
    '        cmbSearch202.Items.Add("--지정없음--")
    '        cmbSearch203.Items.Add("--지정없음--")
    '        For i As Integer = 0 To headerdatatable2.Rows.Count - 1
    '            cmbSearch201.Items.Add(headerdatatable2.Rows(i)("INDICATIONNAME"))
    '            cmbSearch202.Items.Add(headerdatatable2.Rows(i)("INDICATIONNAME"))
    '            cmbSearch203.Items.Add(headerdatatable2.Rows(i)("INDICATIONNAME"))
    '        Next
    '        cmbSearch201.SelectedIndex = 0
    '        cmbSearch202.SelectedIndex = 0
    '        cmbSearch203.SelectedIndex = 0

    '        txtSearch201.Text = ""
    '        txtSearch202.Text = ""
    '        txtSearch203.Text = ""
    '        Return True
    '    Catch ex As Exception
    '        MsgBoxFail(ex.Message)
    '        Return False
    '    End Try


    'End Function
    Private Function SetHeader()
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
            CheckboxColumn = New DataGridViewCheckBoxColumn
            CheckboxColumn.Width = 20
            While DataGridView1.Columns.Count <> 0
                DataGridView1.Columns.RemoveAt(0)
            End While
            DataGridView1.Columns.Add(CheckboxColumn)
            'DataGridView1.ColumnCount = headerdatatable.Rows.Count

            For colindex As Integer = 0 To headerdatatable.Rows.Count - 1
                DataGridView1.Columns.Add(headerdatatable.Rows(colindex)("INDICATIONNAME"), headerdatatable.Rows(colindex)("INDICATIONNAME"))
                'DataGridView1.Columns(colindex).HeaderText = headerdatatable.Rows(colindex)("INDICATIONNAME")
                DataGridView1.Columns(colindex + 1).Width = headerdatatable.Rows(colindex)("INDICATIONWIDTH")
                DataGridView1.Columns(colindex + 1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
                Select Case headerdatatable.Rows(colindex)("INDICATIONWIDEPOSITION")
                    Case 1
                        DataGridView1.Columns(colindex + 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case 2
                        DataGridView1.Columns(colindex + 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case Else
                        DataGridView1.Columns(colindex + 1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End Select
            Next

            'SeqNo 추가
            DataGridView1.ColumnCount = DataGridView1.ColumnCount + 1
            DataGridView1.Columns(DataGridView1.ColumnCount - 1).Visible = False
            DataGridView1.DefaultCellStyle.Font = New Font("Segoe UI", 9)

        Catch ex As Exception
            MsgBoxFail(ex.Message)
            Application.Exit()
        End Try
        Return True
    End Function
    'Private Function SetHeader2()
    '    Dim cmd As SqlCommand
    '    Dim dr As SqlDataReader
    '    Dim strSQL As String


    '    Try
    '        strSQL = "SELECT * FROM F_LISTOUTITEM "
    '        strSQL &= " WHERE Visible = '1' "
    '        strSQL &= " And MESSAGEID = '" & gMessageNumber2 & "'"
    '        strSQL &= " AND PRECESSINGCLASS = 'H'"
    '        strSQL &= " ORDER BY INDICATIONORDER "
    '        cmd = New SqlCommand(strSQL, dbConn)
    '        headerdatatable2.Load(cmd.ExecuteReader())
    '        cmd.Dispose()
    '        CheckboxColumn2 = New DataGridViewCheckBoxColumn
    '        CheckboxColumn2.Width = 20
    '        DataGridView2.Columns.Add(CheckboxColumn2)
    '        'DataGridView1.ColumnCount = headerdatatable.Rows.Count

    '        For colindex As Integer = 0 To headerdatatable2.Rows.Count - 1
    '            DataGridView2.Columns.Add(headerdatatable2.Rows(colindex)("INDICATIONNAME"), headerdatatable2.Rows(colindex)("INDICATIONNAME"))
    '            'DataGridView1.Columns(colindex).HeaderText = headerdatatable.Rows(colindex)("INDICATIONNAME")
    '            DataGridView2.Columns(colindex).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
    '            Select Case headerdatatable2.Rows(colindex)("INDICATIONWIDEPOSITION")
    '                Case 1
    '                    DataGridView2.Columns(colindex).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '                Case 2
    '                    DataGridView2.Columns(colindex).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    '                Case Else
    '                    DataGridView2.Columns(colindex).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
    '            End Select
    '        Next

    '        'SeqNo 추가
    '        DataGridView2.ColumnCount = DataGridView2.ColumnCount + 1
    '        DataGridView2.Columns(DataGridView2.ColumnCount - 1).Visible = False
    '        DataGridView2.DefaultCellStyle.Font = New Font("Segoe UI", 9)

    '    Catch ex As Exception
    '        MsgBoxFail(ex.Message)
    '        Application.Exit()
    '    End Try
    '    Return True
    'End Function
    Private Function SetDetail()
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim strSQL As String
        Dim rowIndex As Integer = 0

        Try
            datagridiewclear()
            strSQL = "SELECT  "
            For i As Integer = 0 To headerdatatable.Rows.Count - 1
                If i <> 0 Then strSQL &= ","
                strSQL &= headerdatatable.Rows(i)("COLUMNNAME")
            Next

            If headerdatatable.Rows.Count <> 0 Then
                strSQL &= " ,"
            End If

            strSQL &= " SEQNO"
            strSQL &= " FROM D_CIPL_H "
            strSQL &= " WHERE 1=1 "
            strSQL &= gWhere
            cmd = New SqlCommand(strSQL, dbConn)
            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView1.Rows.Add()
                DataGridView1.Rows(rowIndex).Cells(0).Value = False
                For i As Integer = 0 To headerdatatable.Rows.Count - 1
                    DataGridView1.Rows(rowIndex).Cells(i + 1).Value = dr(headerdatatable.Rows(i)("COLUMNNAME"))
                Next

                If rowIndex Mod 2 = 0 Then
                    DataGridView1.Rows(rowIndex).DefaultCellStyle.BackColor = Color.Lavender
                End If

                DataGridView1.Rows(rowIndex).Cells(DataGridView1.ColumnCount - 1).Value = dr("SeqNo")
                rowIndex = rowIndex + 1
            End While
            cmd.Dispose()

        Catch ex As Exception
            MsgBoxFail(ex.Message)
            Application.Exit()
        End Try
        Return True
    End Function
    'Private Function SetDetail2()
    '    Dim cmd As SqlCommand
    '    Dim dr As SqlDataReader
    '    Dim strSQL As String
    '    Dim rowIndex As Integer = 0

    '    Try
    '        datagridiewclear2()
    '        strSQL = "SELECT  "
    '        For i As Integer = 0 To headerdatatable2.Rows.Count - 1
    '            If i <> 0 Then strSQL &= ","
    '            strSQL &= headerdatatable2.Rows(i)("COLUMNNAME")
    '        Next

    '        If headerdatatable2.Rows.Count <> 0 Then
    '            strSQL &= " ,"
    '        End If

    '        strSQL &= " SEQNO"
    '        strSQL &= " FROM D_PACKINGLIST_H "
    '        strSQL &= " WHERE 1=1 "
    '        strSQL &= gWhere2
    '        cmd = New SqlCommand(strSQL, dbConn)
    '        dr = cmd.ExecuteReader
    '        While dr.Read
    '            DataGridView2.Rows.Add()
    '            DataGridView2.Rows(rowIndex).Cells(0).Value = False
    '            For i As Integer = 0 To headerdatatable2.Rows.Count - 1
    '                DataGridView2.Rows(rowIndex).Cells(i + 1).Value = dr(headerdatatable2.Rows(i)("COLUMNNAME"))
    '            Next

    '            If rowIndex Mod 2 = 0 Then
    '                DataGridView2.Rows(rowIndex).DefaultCellStyle.BackColor = Color.Lavender
    '            End If

    '            DataGridView2.Rows(rowIndex).Cells(DataGridView2.ColumnCount - 1).Value = dr("SeqNo")
    '            rowIndex = rowIndex + 1
    '        End While
    '        cmd.Dispose()

    '    Catch ex As Exception
    '        MsgBoxFail(ex.Message)
    '        Application.Exit()
    '    End Try
    '    Return True
    'End Function
    Private Sub cmbSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearch101.SelectedIndexChanged
        If Load_flag Then Exit Sub
        If cmbSearch101.SelectedIndex = 0 Then
            txtSearch101.Text = ""
        End If
    End Sub
    Private Sub cmbSearch102_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearch102.SelectedIndexChanged
        If Load_flag Then Exit Sub
        If cmbSearch101.SelectedIndex = 0 Then
            txtSearch101.Text = ""
        End If
    End Sub

    Private Sub cmbSearch103_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearch103.SelectedIndexChanged
        If Load_flag Then Exit Sub
        If cmbSearch101.SelectedIndex = 0 Then
            txtSearch101.Text = ""
        End If
    End Sub



    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Focus()
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        gWhere = ""
        If cmbSearch101.SelectedIndex <> 0 Then
            gWhere &= " AND " & headerdatatable.Rows(cmbSearch101.SelectedIndex - 1)("COLUMNNAME")
            gWhere &= " LIKE '%" & txtSearch101.Text & "%'"
        End If

        If cmbSearch102.SelectedIndex <> 0 Then
            gWhere &= " AND " & headerdatatable.Rows(cmbSearch102.SelectedIndex - 1)("COLUMNNAME")
            gWhere &= " LIKE '%" & txtSearch102.Text & "%'"
        End If

        If cmbSearch103.SelectedIndex <> 0 Then
            gWhere &= " AND " & headerdatatable.Rows(cmbSearch103.SelectedIndex - 1)("COLUMNNAME")
            gWhere &= " LIKE '%" & txtSearch103.Text & "%'"
        End If
        SetDetail()
    End Sub

    'Private Sub btnSearch2_Click(sender As Object, e As EventArgs)
    '    gWhere2 = ""
    '    If cmbSearch201.SelectedIndex <> 0 Then
    '        gWhere2 &= " AND " & headerdatatable2.Rows(cmbSearch201.SelectedIndex - 1)("COLUMNNAME")
    '        gWhere2 &= " LIKE '%" & txtSearch201.Text & "%'"
    '    End If

    '    If cmbSearch202.SelectedIndex <> 0 Then
    '        gWhere2 &= " AND " & headerdatatable2.Rows(cmbSearch202.SelectedIndex - 1)("COLUMNNAME")
    '        gWhere2 &= " LIKE '%" & txtSearch202.Text & "%'"
    '    End If

    '    If cmbSearch203.SelectedIndex <> 0 Then
    '        gWhere2 &= " AND " & headerdatatable2.Rows(cmbSearch203.SelectedIndex - 1)("COLUMNNAME")
    '        gWhere2 &= " LIKE '%" & txtSearch203.Text & "%'"
    '    End If
    '    SetDetail()
    'End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'MsgBox(DataGridView1.CurrentCell.RowIndex)
        'MsgBox(DataGridView1.CurrentCell.ColumnIndex)
        'MsgBox(DataGridView1.CurrentCell.RowIndex)
        Dim rowIndex As Integer
        If Load_flag Then Exit Sub
        If DataGridView1.RowCount = 0 Then
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                If rowIndex Mod 2 = 0 Then
                    DataGridView1.Rows(rowIndex).DefaultCellStyle.BackColor = Color.Lavender

                Else
                    DataGridView1.Rows(rowIndex).DefaultCellStyle.BackColor = Color.Lavender
                End If
            Next

            Exit Sub
        End If
        If DataGridView1.CurrentCell.ColumnIndex = 0 Then
            If DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(0).Value Then
                DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(0).Value = False
            Else
                DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(0).Value = True
            End If
        End If
    End Sub

    'Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs)

    '    If Load_flag Then Exit Sub
    '    If DataGridView2.CurrentCell.ColumnIndex = 0 Then
    '        If DataGridView2.Rows(DataGridView2.CurrentCell.RowIndex).Cells(0).Value Then
    '            DataGridView2.Rows(DataGridView2.CurrentCell.RowIndex).Cells(0).Value = False
    '        Else
    '            DataGridView2.Rows(DataGridView2.CurrentCell.RowIndex).Cells(0).Value = True
    '        End If
    '    End If
    'End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If Load_flag Then Exit Sub
        If DataGridView1.RowCount = 0 Then Exit Sub
        Dim sform As Form
        sform = New FrmInvoicePackingSub(DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(DataGridView1.ColumnCount - 1).Value)
        sform.ShowDialog()

    End Sub

    Private Sub DataGridView2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If Load_flag Then Exit Sub
        If DataGridView1.RowCount = 0 Then Exit Sub
        Dim sform As Form
        sform = New FrmInvoicePackingSub(DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(DataGridView1.ColumnCount - 1).Value)
        sform.ShowDialog()

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim cmd As SqlCommand
        Dim strSQL As String
        Try
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                If DataGridView1.Rows(i).Cells(0).Value Then
                    strSQL = "DELETE FROM " & D_CIPL_H & " WHERE SEQNO ='" & DataGridView1.Rows(i).Cells(DataGridView1.ColumnCount - 1).Value & "'"
                    cmd = New SqlCommand(strSQL, dbConn)
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()

                    strSQL = "DELETE FROM " & D_CIPL_D & " WHERE SEQNO ='" & DataGridView1.Rows(i).Cells(DataGridView1.ColumnCount - 1).Value & "'"
                    cmd = New SqlCommand(strSQL, dbConn)
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                End If
            Next
            SetDetail()

            MsgBoxOK("삭제 완료")
        Catch ex As Exception
            MsgBoxFail(ex.Message)
        End Try
    End Sub
    'Private Sub btnDelete2_Click(sender As Object, e As EventArgs)
    '    Dim cmd As SqlCommand
    '    Dim strSQL As String
    '    Try
    '        For i As Integer = 0 To DataGridView2.Rows.Count - 1
    '            If DataGridView2.Rows(i).Cells(0).Value Then
    '                strSQL = "DELETE FROM D_PACKINGLIST_H WHERE SEQNO ='" & DataGridView2.Rows(i).Cells(DataGridView2.ColumnCount - 1).Value & "'"
    '                cmd = New SqlCommand(strSQL, dbConn)
    '                cmd.ExecuteNonQuery()
    '                cmd.Dispose()

    '                strSQL = "DELETE FROM D_PACKINGLIST_D WHERE SEQNO ='" & DataGridView2.Rows(i).Cells(DataGridView2.ColumnCount - 1).Value & "'"
    '                cmd = New SqlCommand(strSQL, dbConn)
    '                cmd.ExecuteNonQuery()
    '                cmd.Dispose()
    '            End If
    '        Next
    '        SetDetail()

    '        MsgBoxOK("삭제 완료")
    '    Catch ex As Exception
    '        MsgBoxFail(ex.Message)
    '    End Try
    'End Sub
    Private Function datagridiewclear()
        While DataGridView1.RowCount <> 0
            DataGridView1.Rows.RemoveAt(DataGridView1.RowCount - 1)
        End While
    End Function

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim sform As New FrmInvoicePackingPrint
        sform.ShowDialog()
    End Sub

    'Private Function datagridiewclear2()
    '    While DataGridView2.RowCount <> 0
    '        DataGridView2.Rows.RemoveAt(DataGridView1.RowCount - 1)
    '    End While
    'End Function


End Class