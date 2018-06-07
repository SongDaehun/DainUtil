Imports Microsoft.Office.Interop
Imports System.Data.SqlClient

Public Class FrmItem
    Dim Load_flag As Boolean
    Dim itemdatatable As DataTable = New DataTable
    Dim gOrder As String
    Dim gMessageNumber As Integer = 901
    Dim TextBoxColumn() As DataGridViewTextBoxColumn
    Dim CheckboxColumn() As DataGridViewCheckBoxColumn
    Dim ComboBoxColumn() As DataGridViewComboBoxColumn
    Dim TextBoxColumnIndex As Integer
    Dim CheckboxColumnIndex As Integer
    Dim ComboBoxColumnIndex As Integer
    Dim Length As Integer

    Dim gWhere As String
    Dim headerdatatable As DataTable = New DataTable
    Dim RowCountAdjust As Integer

    Private Sub FrmItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_flag = True

        Try
            DataGridView1.RowHeadersVisible = False

            itemdatatable = New DataTable

            If DataGridView1.AllowUserToAddRows Then
                RowCountAdjust = -1
            Else
                RowCountAdjust = 0
            End If

            gWhere = ""
            If SetHeader() = False Then
                Application.Exit()
            End If
            If setdetail() = False Then
                Application.Exit()
            End If
            If SetCombo() = False Then
                Application.Exit()
            End If
            btnUpdate.Visible = False
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
    Private Function SetHeader()
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim strSQL As String

        TextBoxColumnIndex = 0
        CheckboxColumnIndex = 0
        ComboBoxColumnIndex = 0


        Try
            strSQL = "SELECT COUNT(*) AS COLUMNCOUNT FROM F_LISTOUTITEM "
            strSQL &= " WHERE Visible = '1' "
            strSQL &= " AND MESSAGEID = '" & gMessageNumber & "'"
            strSQL &= " AND PRECESSINGCLASS = 'H'"
            strSQL &= " AND DATATYPE = '0'"
            cmd = New SqlCommand(strSQL, dbConn)
            dr = cmd.ExecuteReader
            dr.Read()
            ReDim Preserve TextBoxColumn(dr("COLUMNCOUNT"))
            dr.Close()
            cmd.Dispose()

            strSQL = "SELECT COUNT(*) AS COLUMNCOUNT FROM F_LISTOUTITEM "
            strSQL &= " WHERE Visible = '1' "
            strSQL &= " AND MESSAGEID = '" & gMessageNumber & "'"
            strSQL &= " AND PRECESSINGCLASS = 'H'"
            strSQL &= " AND DATATYPE = '1'"
            cmd = New SqlCommand(strSQL, dbConn)
            dr = cmd.ExecuteReader
            dr.Read()
            ReDim Preserve CheckboxColumn(dr("COLUMNCOUNT"))
            dr.Close()
            cmd.Dispose()

            strSQL = "SELECT COUNT(*) AS COLUMNCOUNT FROM F_LISTOUTITEM "
            strSQL &= " WHERE Visible = '1' "
            strSQL &= " AND MESSAGEID = '" & gMessageNumber & "'"
            strSQL &= " AND PRECESSINGCLASS = 'H'"
            strSQL &= " AND DATATYPE = '2'"
            cmd = New SqlCommand(strSQL, dbConn)
            dr = cmd.ExecuteReader
            dr.Read()
            ReDim Preserve ComboBoxColumn(dr("COLUMNCOUNT") + 1)
            dr.Close()
            cmd.Dispose()

            strSQL = "SELECT * FROM F_LISTOUTITEM "
            strSQL &= " WHERE Visible = '1' "
            strSQL &= " And MESSAGEID = '" & gMessageNumber & "'"
            strSQL &= " AND PRECESSINGCLASS = 'H'"
            strSQL &= " ORDER BY INDICATIONORDER "
            cmd = New SqlCommand(strSQL, dbConn)
            headerdatatable = New DataTable
            headerdatatable.Load(cmd.ExecuteReader())
            cmd.Dispose()
            CheckboxColumn(CheckboxColumnIndex) = New DataGridViewCheckBoxColumn
            CheckboxColumn(CheckboxColumnIndex).Width = 20



            While DataGridView1.Columns.Count <> 0
                DataGridView1.Columns.RemoveAt(0)
            End While
            DataGridView1.Columns.Add(CheckboxColumn(0))
            'DataGridView1.ColumnCount = headerdatatable.Rows.Count

            For colindex As Integer = 0 To headerdatatable.Rows.Count - 1
                '0 : text 1:number 2:date 3:checkbox 4:combobox
                Select Case headerdatatable.Rows(colindex)("DATATYPE")
                    Case 0
                        TextBoxColumn(TextBoxColumnIndex) = New DataGridViewTextBoxColumn
                        TextBoxColumn(TextBoxColumnIndex).Name = headerdatatable.Rows(colindex)("COLUMNNAME")
                        TextBoxColumn(TextBoxColumnIndex).HeaderText = headerdatatable.Rows(colindex)("INDICATIONNAME")

                        strSQL = " SELECT LENGTH FROM "
                        strSQL &= " SYSCOLUMNS WHERE ID In( "
                        strSQL &= " SELECT ID FROM SYSOBJECTS "
                        strSQL &= " WHERE NAME = '" & M_ITEM & "') "
                        strSQL &= " AND NAME = '" & headerdatatable.Rows(colindex)("COLUMNNAME") & "' "
                        cmd = New SqlCommand(strSQL, dbConn)
                        dr = cmd.ExecuteReader
                        dr.Read()
                        Length = dr("LENGTH")
                        dr.Close()
                        cmd.Dispose()

                        TextBoxColumn(TextBoxColumnIndex).MaxInputLength = Length
                        DataGridView1.Columns.Add(TextBoxColumn(TextBoxColumnIndex))
                        TextBoxColumnIndex = TextBoxColumnIndex + 1
                    Case 1
                        DataGridView1.Columns.Add(headerdatatable.Rows(colindex)("COLUMNNAME"), headerdatatable.Rows(colindex)("INDICATIONNAME"))
                    Case 2
                        ComboBoxColumn(ComboBoxColumnIndex) = New DataGridViewComboBoxColumn
                        ComboBoxColumn(ComboBoxColumnIndex).Name = headerdatatable.Rows(colindex)("COLUMNNAME")
                        ComboBoxColumn(ComboBoxColumnIndex).HeaderText = headerdatatable.Rows(colindex)("INDICATIONNAME")

                        strSQL = " Select * From M_CUSTOMCODESET INNER Join M_CUSTOMCODENAME "
                        strSQL &= "On M_CUSTOMCODESET.CODEDIV = M_CUSTOMCODENAME.STANDARDNAME "
                        strSQL &= " WHERE 1 = 1 "
                        strSQL &= " AND COLUMNSNAME = '" & headerdatatable.Rows(colindex)("COLUMNNAME") & "'"
                        cmd = New SqlCommand(strSQL, dbConn)
                        dr = cmd.ExecuteReader
                        While dr.Read()
                            ComboBoxColumn(ComboBoxColumnIndex).Items.Add(dr("CONTENTS"))
                        End While
                        dr.Close()
                        cmd.Dispose()
                        ComboBoxColumn(ComboBoxColumnIndex).Items.Add("해당없음")

                        DataGridView1.Columns.Add(ComboBoxColumn(ComboBoxColumnIndex))
                        ComboBoxColumnIndex = ComboBoxColumnIndex + 1
                End Select

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

    Private Function setdetail() As Boolean
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

            strSQL &= " PARTNO"
            strSQL &= " FROM M_ITEM "
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

                'If rowIndex Mod 2 = 0 Then
                '    DataGridView1.Rows(rowIndex).DefaultCellStyle.BackColor = Color.Lavender
                'End If

                DataGridView1.Rows(rowIndex).Cells(DataGridView1.ColumnCount - 1).Value = dr("PARTNO")
                rowIndex = rowIndex + 1
            End While
            cmd.Dispose()

            datagridviewSetColor()

        Catch ex As Exception
            MsgBoxFail(ex.Message)
            Application.Exit()
        End Try
        Return True
    End Function

    Private Function datagridiewclear()
        While DataGridView1.RowCount > 1
            DataGridView1.Rows.RemoveAt(0)
        End While
    End Function
    Private Sub datagridviewSetColor()
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If i Mod 2 = 0 Then
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Lavender
            Else
                DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.White
            End If
        Next
    End Sub
    Dim DeleteProcessflag As Boolean = False
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Me.Focus()
        Dim Count As Integer = 0
        Try
            For i As Integer = 0 To DataGridView1.Rows.Count + RowCountAdjust - 1
                If DataGridView1.Rows(i).Cells(0).Value Then
                    Count = Count + 1
                    DataGridView1.Rows.RemoveAt(i)
                End If
            Next

            If Count = 0 Then
                MsgBoxExclamation("데이터가 선택되어 있지 않습니다. ")
            End If
            datagridviewSetColor()
            btnUpdate.Visible = True
        Catch ex As Exception
            MsgBoxFail("데이터 삭제에 실패 했습니다.")
        End Try
        DeleteProcessflag = False
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub DataGridView1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        btnUpdate.Visible = True
        datagridviewSetColor()
    End Sub
    Private Sub cmbSearch101_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearch101.SelectedIndexChanged
        If Load_flag Then Exit Sub
        If cmbSearch101.SelectedIndex = 0 Then
            txtSearch101.Text = ""
        End If
    End Sub

    Private Sub cmbSearch102_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearch102.SelectedIndexChanged
        If Load_flag Then Exit Sub
        If cmbSearch102.SelectedIndex = 0 Then
            txtSearch102.Text = ""
        End If
    End Sub

    Private Sub cmbSearch103_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearch103.SelectedIndexChanged
        If Load_flag Then Exit Sub
        If cmbSearch103.SelectedIndex = 0 Then
            txtSearch102.Text = ""
        End If
    End Sub
    ''표준 화면 여기까지

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim strSQL As String
        Dim cmd As SqlCommand = dbConn.CreateCommand
        Dim i As Integer = 0
        Dim txn As SqlTransaction = dbConn.BeginTransaction
        Try
            cmd.Transaction = txn

            strSQL = " DELETE FROM M_ITEM "
            cmd.CommandText = strSQL
            cmd.ExecuteNonQuery()
            While DataGridView1.Rows(i).Cells(1).Value <> ""
                strSQL = "INSERT INTO M_ITEM VALUES("
                strSQL &= "'" & i + 1 & "'"
                strSQL &= "," & ColumnSet(DataGridView1.Rows(i).Cells(1).Value.ToString.ToUpper)
                strSQL &= "," & ColumnSet2(DataGridView1.Rows(i).Cells(2).Value.ToString.ToUpper)
                strSQL &= "," & ColumnSet2(DataGridView1.Rows(i).Cells(3).Value.ToString.ToUpper)
                strSQL &= "," & ColumnSet2(DataGridView1.Rows(i).Cells(4).Value.ToString.ToUpper)
                strSQL &= "," & ColumnSet2(DataGridView1.Rows(i).Cells(5).Value.ToString.ToUpper)
                strSQL &= "," & ColumnSet2(DataGridView1.Rows(i).Cells(6).Value.ToString.ToUpper)
                strSQL &= "," & ColumnSet2(DataGridView1.Rows(i).Cells(7).Value.ToString.ToUpper) & ")"

                cmd.CommandText = strSQL
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                i = i + 1
            End While
            txn.Commit()
            cmd.Dispose()
            btnUpdate.Visible = False
            datagridiewclear()
            setdetail()
            btnUpdate.Visible = False
            MsgBoxInformation("데이터 갱신에 성공했습니다.")
        Catch ex As Exception
            txn.Rollback()
            MsgBoxFail("데이타 갱신에 실패했습니다." & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If Load_flag Then Exit Sub
        btnUpdate.Visible = True
    End Sub

    Private Sub btnExcelImport_Click(sender As Object, e As EventArgs) Handles btnExcelImport.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "엑셀파일(*.xls;*.xlsx)|*.xls;*.xlsx"
        OpenFileDialog1.ShowDialog()


        Try
            If System.IO.File.Exists(OpenFileDialog1.FileName) Then
                Dim sForm As New FrmProcessItemImport(OpenFileDialog1.FileName)
                sForm.ShowDialog()
            End If

            datagridiewclear()
            setdetail()


        Catch ex As Exception
            MsgBoxFail("데이타 갱신에 실패했습니다." & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub btnExcelout_Click(sender As Object, e As EventArgs) Handles btnExcelout.Click
        SaveFileDialog1.FileName = ""
        SaveFileDialog1.Filter = "엑셀파일(*.xls;*.xlsx)|*.xls;*.xlsx"
        SaveFileDialog1.ShowDialog()
        Dim sForm As New FrmProcessItemExport(R_ITEM, SaveFileDialog1.FileName)
        sForm.ShowDialog()
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
        setdetail()
    End Sub

    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        Try

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class