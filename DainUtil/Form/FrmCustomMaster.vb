Imports System.Data.SqlClient
Public Class FrmCustomMaster
    Dim Load_flag As Boolean
    Dim headerdatatable As DataTable = New DataTable
    Dim gOrder As String
    Dim gMessageNumber As Integer = 902
    Dim CheckboxColumn As New DataGridViewCheckBoxColumn
    Dim gWhere As String
    Dim RowCountAdjust As Integer

    Dim cmbdatatable As DataTable

    Private Sub frmCodesetMente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'strSQL = " CREATE TABLE M_STANDARDCODENAME "
        'strSQL &= " ( "
        'strSQL &= " STANDARDCODE                          NVARCHAR(30)             Not NULL, "
        'strSQL &= " STANDARDNAME                          NVARCHAR(40)             Not NULL, "
        'strSQL &= " PRIMARY KEY (STANDARDCODE, STANDARDNAME) "
        'strSQL &= " ) "
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Try
            Load_flag = True


            If DataGridView1.AllowUserToAddRows Then
                RowCountAdjust = -1
            Else
                RowCountAdjust = 0
            End If

            cmbdatatable = New DataTable
            cmd = New SqlCommand("SELECT * FROM M_CUSTOMCODENAME ORDER BY STANDARDNAME ", dbConn)
            cmbdatatable.Load(cmd.ExecuteReader())
            cmd.Dispose()

            For i As Integer = 0 To cmbdatatable.Rows.Count - 1
                cmbStandard.Items.Add(cmbdatatable.Rows(i)("STANDARDNAME"))
            Next
            cmbStandard.SelectedIndex = 0
            If SetHeader() = False Then
                Me.Close()
            End If

            gWhere = " AND CODEDIV = '" & cmbdatatable.Rows(cmbStandard.SelectedIndex)("STANDARDNAME") & "'"

            If setdetail() = False Then
                Me.Close()
            End If



        Catch ex As Exception
            MsgBoxFail(ex.Message)
        Finally
            Load_flag = False
        End Try

    End Sub
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

            strSQL &= " CONTENTS"
            strSQL &= " FROM M_CUSTOMCODESET "
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

                DataGridView1.Rows(rowIndex).Cells(DataGridView1.ColumnCount - 1).Value = dr("CONTENTS")
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
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Me.Focus()
        Dim Count As Integer

        Try

            For i As Integer = 0 To DataGridView1.Rows.Count + RowCountAdjust - 1
                If DataGridView1.Rows(i).Cells(0).Value Then
                    DataGridView1.Rows.RemoveAt(i)
                    Count = Count + 1
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

    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Focus()
        Me.Close()
    End Sub
    Private Sub DataGridView1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        btnUpdate.Visible = True
        datagridviewSetColor()
    End Sub
    ''표준 화면 여기까지

    Private Sub cmbStandard_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStandard.SelectedIndexChanged
        If Load_flag Then Exit Sub
        gWhere = " AND CODEDIV = '" & cmbdatatable.Rows(cmbStandard.SelectedIndex)("STANDARDNAME") & "'"
        datagridiewclear()
        setdetail()
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim i As Integer = 0
        Try
            strSQL = " DELETE FROM M_CUSTOMCODESET WHERE 1 = 1 AND CODEDIV = '" & cmbdatatable.Rows(cmbStandard.SelectedIndex)("STANDARDNAME") & "'"
            cmd = New SqlCommand(strSQL, dbConn)
            cmd.ExecuteNonQuery()

            While DataGridView1.Rows(i).Cells(1).Value <> ""
                strSQL = "INSERT INTO M_CUSTOMCODESET VALUES("
                strSQL &= ColumnSet(cmbdatatable.Rows(cmbStandard.SelectedIndex)("STANDARDNAME"))
                strSQL &= "," & ColumnSet(DataGridView1.Rows(i).Cells(1).Value) & ")"
                cmd = New SqlCommand(strSQL, dbConn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                i = i + 1
            End While
            MsgBoxInformation("데이터 갱신에 성공했습니다.")
        Catch ex As Exception
            MsgBoxFail("데이타 갱신에 실패했습니다." & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        If Load_flag Then Exit Sub
        btnUpdate.Visible = True
    End Sub
End Class