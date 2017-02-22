Imports System.Data.SqlClient
Public Class FrmInvoicePackingSub
    Dim load_flag As Boolean = False
    Dim detaildatatable As DataTable
    Dim SeqNo As Integer = 0
    Dim gMessageNumber As Integer = 1
    Dim gWhere As String
    Dim gOrder As String
    Dim CheckboxColumn = New DataGridViewCheckBoxColumn
    Public Sub New(Optional ByVal pSeqNo As Integer = 0)

        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()
        SeqNo = pSeqNo
        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하세요.

    End Sub
    Private Sub FrmInvoicePackingSub_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        load_flag = True

        Try
            Select Case SeqNo
                Case 0
                Case Else
                    strSQL = " SELECT * FROM D_CIPL_H "
                    strSQL &= " WHERE SEQNO = '" & SeqNo & "'"
                    cmd = New SqlCommand(strSQL, dbConn)
                    dr = cmd.ExecuteReader
                    While dr.Read()

                        txtINVOICENO.ReadOnly = True
                        txtPACKINGLISTNO.ReadOnly = True
                        dtpINVOICEDATE.Enabled = False
                        txtSHIPPEREXPORTER.ReadOnly = True
                        txtSHIPPEREXPORTERADDRESS.ReadOnly = True
                        txtCONSIGNEE.ReadOnly = True
                        txtCONSIGNEEADDRESS.ReadOnly = True
                        txtTERMSOFDELIVERY.ReadOnly = True
                        txtSHIPPINGMODE.ReadOnly = True
                        txtPAYMENT.ReadOnly = True
                        txtPAYMENTBANK.ReadOnly = True
                        txtACCOUNTNO.ReadOnly = True
                        txtSHIPPEREXPORTER.ReadOnly = True
                        txtSHIPPEREXPORTERADDRESS.ReadOnly = True
                        txtCONSIGNEE.ReadOnly = True
                        txtCONSIGNEEADDRESS.ReadOnly = True
                        txtTERMSOFDELIVERY.ReadOnly = True
                        txtSHIPPINGMODE.ReadOnly = True
                        txtPAYMENT.ReadOnly = True
                        txtPAYMENTBANK.ReadOnly = True
                        txtACCOUNTNO.ReadOnly = True
                        txtPURCHASEORDER.ReadOnly = True
                        txtLOADINGPORTNAME.ReadOnly = True
                        txtDESTINATION.ReadOnly = True
                        txtNOTIFY.ReadOnly = True
                        txtPL_CONTACTPERSON.ReadOnly = True
                        txtPL_CONTACTPERSON_EMAIL.ReadOnly = True
                        txtPL_ETD.ReadOnly = True
                        txtPL_ETA.ReadOnly = True
                        txtPL_TOTAL_MESURMENT.ReadOnly = True
                        txtPL_TOTAL_NWEIGHT.ReadOnly = True
                        txtPL_TOTAL_NWEIGHT_PLTS.ReadOnly = True
                        txtPL_TOTAL_GWEIGHT.ReadOnly = True

                        txtINVOICENO.Text = dr("INVOICENO")
                        txtPACKINGLISTNO.Text = dr("PACKINGLISTNO")
                        dtpINVOICEDATE.Value = CDate(dr("INVOICEDATE").ToString.Substring(0, 4) _
                           & "/" & dr("INVOICEDATE").ToString.Substring(4, 2) _
                           & "/" & dr("INVOICEDATE").ToString.Substring(6, 2)
                            )
                        txtSHIPPEREXPORTER.Text = dr("SHIPPEREXPORTER")
                        txtSHIPPEREXPORTERADDRESS.Text = dr("SHIPPEREXPORTERADDRESS")
                        txtCONSIGNEE.Text = dr("CONSIGNEE")
                        txtCONSIGNEEADDRESS.Text = dr("CONSIGNEEADDRESS")
                        txtTERMSOFDELIVERY.Text = dr("TERMSOFDELIVERY")
                        txtSHIPPINGMODE.Text = dr("SHIPPINGMODE")
                        txtPAYMENT.Text = dr("PAYMENT")
                        txtPAYMENTBANK.Text = dr("PAYMENTBANK")
                        txtACCOUNTNO.Text = dr("ACCOUNTNO")
                        txtSHIPPEREXPORTER.Text = dr("SHIPPEREXPORTER")
                        txtSHIPPEREXPORTERADDRESS.Text = dr("SHIPPEREXPORTERADDRESS")
                        txtCONSIGNEE.Text = dr("CONSIGNEE")
                        txtCONSIGNEEADDRESS.Text = dr("CONSIGNEEADDRESS")
                        txtTERMSOFDELIVERY.Text = dr("TERMSOFDELIVERY")
                        txtSHIPPINGMODE.Text = dr("SHIPPINGMODE")
                        txtPAYMENT.Text = dr("PAYMENT")
                        txtPAYMENTBANK.Text = dr("PAYMENTBANK")
                        txtACCOUNTNO.Text = dr("ACCOUNTNO")
                        txtPURCHASEORDER.Text = dr("PURCHASEORDER")
                        txtLOADINGPORTCODE.Text = dr("LOADINGPORTCODE")
                        txtLOADINGPORTNAME.Text = dr("LOADINGPORTNAME")
                        txtDESTINATION.Text = dr("DESTINATION")
                        txtNOTIFY.Text = dr("NOTIFY")

                        txtPL_CONTACTPERSON.Text = dr("PL_CONTACTPERSON")
                        txtPL_CONTACTPERSON_EMAIL.Text = dr("PL_CONTACTPERSON_EMAIL")
                        txtPL_ETD.Text = dr("PL_ETD")
                        txtPL_ETA.Text = dr("PL_ETA")
                        txtPL_TOTAL_MESURMENT.Text = dr("PL_TOTAL_MESURMENT")
                        txtPL_TOTAL_NWEIGHT.Text = dr("PL_TOTAL_NWEIGHT")
                        txtPL_TOTAL_NWEIGHT_PLTS.Text = dr("PL_TOTAL_NWEIGHT_PLTS")
                        txtPL_TOTAL_GWEIGHT.Text = dr("PL_TOTAL_GWEIGHT")

                    End While
                    dr.Close()
                    cmd.Dispose()

                    SetHeader()
                    SetDetail()

            End Select

        Catch ex As Exception
            MsgBoxFail(ex.Message)
            Me.Close()
        End Try
        load_flag = False
    End Sub
    Private Function SetHeader()
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim strSQL As String


        Try
            detaildatatable = New DataTable
            strSQL = "SELECT * FROM F_LISTOUTITEM "
            strSQL &= " WHERE Visible = '1' "
            strSQL &= " And MESSAGEID = '" & gMessageNumber & "'"
            strSQL &= " AND PRECESSINGCLASS = 'D'"
            strSQL &= " ORDER BY INDICATIONORDER "
            cmd = New SqlCommand(strSQL, dbConn)
            detaildatatable.Load(cmd.ExecuteReader())
            cmd.Dispose()
            CheckboxColumn = New DataGridViewCheckBoxColumn
            CheckboxColumn.Width = 20
            DataGridView1.Columns.Add(CheckboxColumn)
            'DataGridView1.ColumnCount = headerdatatable.Rows.Count

            For colindex As Integer = 0 To detaildatatable.Rows.Count - 1
                DataGridView1.Columns.Add(detaildatatable.Rows(colindex)("INDICATIONNAME"), detaildatatable.Rows(colindex)("INDICATIONNAME"))
                'DataGridView1.Columns(colindex).HeaderText = headerdatatable.Rows(colindex)("INDICATIONNAME")
                DataGridView1.Columns(colindex).Width = detaildatatable.Rows(colindex)("INDICATIONWIDTH")
                DataGridView1.Columns(colindex).HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter
                Select Case detaildatatable.Rows(colindex)("INDICATIONWIDEPOSITION")
                    Case 1
                        DataGridView1.Columns(colindex).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Case 2
                        DataGridView1.Columns(colindex).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Case Else
                        DataGridView1.Columns(colindex).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
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
    Private Function SetDetail() As Boolean
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim strSQL As String
        Dim rowIndex As Integer = 0

        Try
            datagridiewclear()
            strSQL = "SELECT  "
            For i As Integer = 0 To detaildatatable.Rows.Count - 1
                If i <> 0 Then strSQL &= ","
                strSQL &= detaildatatable.Rows(i)("COLUMNNAME")
            Next
            strSQL &= " ,SEQNO"
            strSQL &= " FROM " & D_CIPL_D
            strSQL &= " WHERE 1=1 "
            strSQL &= " AND SEQNO =  '" & SeqNo & "' "
            strSQL &= gWhere
            cmd = New SqlCommand(strSQL, dbConn)
            dr = cmd.ExecuteReader
            While dr.Read
                DataGridView1.Rows.Add()
                DataGridView1.Rows(rowIndex).Cells(0).Value = False
                For i As Integer = 0 To detaildatatable.Rows.Count - 1
                    DataGridView1.Rows(rowIndex).Cells(i + 1).Value = dr(detaildatatable.Rows(i)("COLUMNNAME"))
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
    Private Function datagridiewclear()
        While DataGridView1.RowCount <> 0
            DataGridView1.Rows.RemoveAt(DataGridView1.RowCount - 1)
        End While
    End Function
End Class