<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmInvoicePackingSub
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblINVOICENO = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.lblPACKINGLISTNO = New System.Windows.Forms.Label()
        Me.lblINVOICEDATE = New System.Windows.Forms.Label()
        Me.lblSHIPPEREXPORTER = New System.Windows.Forms.Label()
        Me.lblSHIPPEREXPORTERADDRESS = New System.Windows.Forms.Label()
        Me.lblCONSIGNEE = New System.Windows.Forms.Label()
        Me.lblCONSIGNEEADDRESS = New System.Windows.Forms.Label()
        Me.lblTERMSOFDELIVERY = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPAYMENT = New System.Windows.Forms.Label()
        Me.lblPAYMENTBANK = New System.Windows.Forms.Label()
        Me.lblACCOUNTNO = New System.Windows.Forms.Label()
        Me.lblPURCHASEORDER = New System.Windows.Forms.Label()
        Me.lblLOADINGPORTNAME = New System.Windows.Forms.Label()
        Me.lblDESTINATION = New System.Windows.Forms.Label()
        Me.lblNOTIFY = New System.Windows.Forms.Label()
        Me.txtINVOICENO = New System.Windows.Forms.TextBox()
        Me.txtPACKINGLISTNO = New System.Windows.Forms.TextBox()
        Me.dtpINVOICEDATE = New System.Windows.Forms.DateTimePicker()
        Me.Grb1 = New System.Windows.Forms.GroupBox()
        Me.GrbShipper = New System.Windows.Forms.GroupBox()
        Me.txtSHIPPEREXPORTERADDRESS = New System.Windows.Forms.TextBox()
        Me.txtSHIPPEREXPORTER = New System.Windows.Forms.TextBox()
        Me.GrbConsign = New System.Windows.Forms.GroupBox()
        Me.txtCONSIGNEEADDRESS = New System.Windows.Forms.TextBox()
        Me.txtCONSIGNEE = New System.Windows.Forms.TextBox()
        Me.GrbCondition = New System.Windows.Forms.GroupBox()
        Me.txtSHIPPINGMODE = New System.Windows.Forms.TextBox()
        Me.txtTERMSOFDELIVERY = New System.Windows.Forms.TextBox()
        Me.GrbPayment = New System.Windows.Forms.GroupBox()
        Me.txtACCOUNTNO = New System.Windows.Forms.TextBox()
        Me.txtPAYMENTBANK = New System.Windows.Forms.TextBox()
        Me.txtPAYMENT = New System.Windows.Forms.TextBox()
        Me.GrbDestination = New System.Windows.Forms.GroupBox()
        Me.txtLOADINGPORTCODE = New System.Windows.Forms.TextBox()
        Me.lblLOADINGPORTCODE = New System.Windows.Forms.Label()
        Me.txtDESTINATION = New System.Windows.Forms.TextBox()
        Me.txtLOADINGPORTNAME = New System.Windows.Forms.TextBox()
        Me.txtPURCHASEORDER = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtNOTIFY = New System.Windows.Forms.TextBox()
        Me.GrpPickingList = New System.Windows.Forms.GroupBox()
        Me.lblPL_TOTAL_GWEIGHT = New System.Windows.Forms.Label()
        Me.lblPL_TOTAL_NWEIGHT = New System.Windows.Forms.Label()
        Me.txtPL_TOTAL_GWEIGHT = New System.Windows.Forms.TextBox()
        Me.txtPL_TOTAL_NWEIGHT = New System.Windows.Forms.TextBox()
        Me.txtPL_TOTAL_NWEIGHT_PLTS = New System.Windows.Forms.TextBox()
        Me.txtPL_TOTAL_MESURMENT = New System.Windows.Forms.TextBox()
        Me.lblPL_TOTAL_NWEIGHT_PLTS = New System.Windows.Forms.Label()
        Me.lblPL_TOTAL_MESURMENT = New System.Windows.Forms.Label()
        Me.lblPL_ETA = New System.Windows.Forms.Label()
        Me.txtPL_ETA = New System.Windows.Forms.TextBox()
        Me.txtPL_ETD = New System.Windows.Forms.TextBox()
        Me.lblPL_ETD = New System.Windows.Forms.Label()
        Me.lblPL_CONTACTPERSON_EMAIL = New System.Windows.Forms.Label()
        Me.txtPL_CONTACTPERSON_EMAIL = New System.Windows.Forms.TextBox()
        Me.txtPL_CONTACTPERSON = New System.Windows.Forms.TextBox()
        Me.lblPL_CONTACTPERSON = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grb1.SuspendLayout()
        Me.GrbShipper.SuspendLayout()
        Me.GrbConsign.SuspendLayout()
        Me.GrbCondition.SuspendLayout()
        Me.GrbPayment.SuspendLayout()
        Me.GrbDestination.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GrpPickingList.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblINVOICENO
        '
        Me.lblINVOICENO.AutoSize = True
        Me.lblINVOICENO.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblINVOICENO.Location = New System.Drawing.Point(6, 17)
        Me.lblINVOICENO.Name = "lblINVOICENO"
        Me.lblINVOICENO.Size = New System.Drawing.Size(76, 15)
        Me.lblINVOICENO.TabIndex = 0
        Me.lblINVOICENO.Text = "INVOICENO :"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridView1.Location = New System.Drawing.Point(10, 618)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(827, 276)
        Me.DataGridView1.TabIndex = 2
        '
        'lblPACKINGLISTNO
        '
        Me.lblPACKINGLISTNO.AutoSize = True
        Me.lblPACKINGLISTNO.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPACKINGLISTNO.Location = New System.Drawing.Point(194, 17)
        Me.lblPACKINGLISTNO.Name = "lblPACKINGLISTNO"
        Me.lblPACKINGLISTNO.Size = New System.Drawing.Size(103, 15)
        Me.lblPACKINGLISTNO.TabIndex = 3
        Me.lblPACKINGLISTNO.Text = "PACKINGLISTNO :"
        '
        'lblINVOICEDATE
        '
        Me.lblINVOICEDATE.AutoSize = True
        Me.lblINVOICEDATE.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblINVOICEDATE.Location = New System.Drawing.Point(409, 17)
        Me.lblINVOICEDATE.Name = "lblINVOICEDATE"
        Me.lblINVOICEDATE.Size = New System.Drawing.Size(87, 15)
        Me.lblINVOICEDATE.TabIndex = 4
        Me.lblINVOICEDATE.Text = "INVOICEDATE :"
        '
        'lblSHIPPEREXPORTER
        '
        Me.lblSHIPPEREXPORTER.AutoSize = True
        Me.lblSHIPPEREXPORTER.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSHIPPEREXPORTER.Location = New System.Drawing.Point(6, 17)
        Me.lblSHIPPEREXPORTER.Name = "lblSHIPPEREXPORTER"
        Me.lblSHIPPEREXPORTER.Size = New System.Drawing.Size(114, 15)
        Me.lblSHIPPEREXPORTER.TabIndex = 5
        Me.lblSHIPPEREXPORTER.Text = "SHIPPEREXPORTER :"
        '
        'lblSHIPPEREXPORTERADDRESS
        '
        Me.lblSHIPPEREXPORTERADDRESS.AutoSize = True
        Me.lblSHIPPEREXPORTERADDRESS.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSHIPPEREXPORTERADDRESS.Location = New System.Drawing.Point(6, 44)
        Me.lblSHIPPEREXPORTERADDRESS.Name = "lblSHIPPEREXPORTERADDRESS"
        Me.lblSHIPPEREXPORTERADDRESS.Size = New System.Drawing.Size(163, 15)
        Me.lblSHIPPEREXPORTERADDRESS.TabIndex = 6
        Me.lblSHIPPEREXPORTERADDRESS.Text = "SHIPPEREXPORTERADDRESS :"
        '
        'lblCONSIGNEE
        '
        Me.lblCONSIGNEE.AutoSize = True
        Me.lblCONSIGNEE.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCONSIGNEE.Location = New System.Drawing.Point(41, 16)
        Me.lblCONSIGNEE.Name = "lblCONSIGNEE"
        Me.lblCONSIGNEE.Size = New System.Drawing.Size(77, 15)
        Me.lblCONSIGNEE.TabIndex = 7
        Me.lblCONSIGNEE.Text = "CONSIGNEE :"
        '
        'lblCONSIGNEEADDRESS
        '
        Me.lblCONSIGNEEADDRESS.AutoSize = True
        Me.lblCONSIGNEEADDRESS.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCONSIGNEEADDRESS.Location = New System.Drawing.Point(-4, 43)
        Me.lblCONSIGNEEADDRESS.Name = "lblCONSIGNEEADDRESS"
        Me.lblCONSIGNEEADDRESS.Size = New System.Drawing.Size(126, 15)
        Me.lblCONSIGNEEADDRESS.TabIndex = 8
        Me.lblCONSIGNEEADDRESS.Text = "CONSIGNEEADDRESS :"
        '
        'lblTERMSOFDELIVERY
        '
        Me.lblTERMSOFDELIVERY.AutoSize = True
        Me.lblTERMSOFDELIVERY.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTERMSOFDELIVERY.Location = New System.Drawing.Point(6, 20)
        Me.lblTERMSOFDELIVERY.Name = "lblTERMSOFDELIVERY"
        Me.lblTERMSOFDELIVERY.Size = New System.Drawing.Size(115, 15)
        Me.lblTERMSOFDELIVERY.TabIndex = 9
        Me.lblTERMSOFDELIVERY.Text = "TERMSOFDELIVERY :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(396, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 15)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "SHIPPINGMODE :"
        '
        'lblPAYMENT
        '
        Me.lblPAYMENT.AutoSize = True
        Me.lblPAYMENT.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPAYMENT.Location = New System.Drawing.Point(50, 22)
        Me.lblPAYMENT.Name = "lblPAYMENT"
        Me.lblPAYMENT.Size = New System.Drawing.Size(68, 15)
        Me.lblPAYMENT.TabIndex = 11
        Me.lblPAYMENT.Text = "PAYMENT :"
        '
        'lblPAYMENTBANK
        '
        Me.lblPAYMENTBANK.AutoSize = True
        Me.lblPAYMENTBANK.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPAYMENTBANK.Location = New System.Drawing.Point(21, 47)
        Me.lblPAYMENTBANK.Name = "lblPAYMENTBANK"
        Me.lblPAYMENTBANK.Size = New System.Drawing.Size(99, 15)
        Me.lblPAYMENTBANK.TabIndex = 12
        Me.lblPAYMENTBANK.Text = "PAYMENTBANK :"
        '
        'lblACCOUNTNO
        '
        Me.lblACCOUNTNO.AutoSize = True
        Me.lblACCOUNTNO.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblACCOUNTNO.Location = New System.Drawing.Point(407, 48)
        Me.lblACCOUNTNO.Name = "lblACCOUNTNO"
        Me.lblACCOUNTNO.Size = New System.Drawing.Size(88, 15)
        Me.lblACCOUNTNO.TabIndex = 13
        Me.lblACCOUNTNO.Text = "ACCOUNTNO :"
        '
        'lblPURCHASEORDER
        '
        Me.lblPURCHASEORDER.AutoSize = True
        Me.lblPURCHASEORDER.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPURCHASEORDER.Location = New System.Drawing.Point(12, 21)
        Me.lblPURCHASEORDER.Name = "lblPURCHASEORDER"
        Me.lblPURCHASEORDER.Size = New System.Drawing.Size(109, 15)
        Me.lblPURCHASEORDER.TabIndex = 14
        Me.lblPURCHASEORDER.Text = "PURCHASEORDER :"
        '
        'lblLOADINGPORTNAME
        '
        Me.lblLOADINGPORTNAME.AutoSize = True
        Me.lblLOADINGPORTNAME.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLOADINGPORTNAME.Location = New System.Drawing.Point(26, 49)
        Me.lblLOADINGPORTNAME.Name = "lblLOADINGPORTNAME"
        Me.lblLOADINGPORTNAME.Size = New System.Drawing.Size(94, 15)
        Me.lblLOADINGPORTNAME.TabIndex = 15
        Me.lblLOADINGPORTNAME.Text = "LOADINGPORT :"
        '
        'lblDESTINATION
        '
        Me.lblDESTINATION.AutoSize = True
        Me.lblDESTINATION.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDESTINATION.Location = New System.Drawing.Point(407, 52)
        Me.lblDESTINATION.Name = "lblDESTINATION"
        Me.lblDESTINATION.Size = New System.Drawing.Size(88, 15)
        Me.lblDESTINATION.TabIndex = 16
        Me.lblDESTINATION.Text = "DESTINATION :"
        '
        'lblNOTIFY
        '
        Me.lblNOTIFY.AutoSize = True
        Me.lblNOTIFY.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNOTIFY.Location = New System.Drawing.Point(64, 17)
        Me.lblNOTIFY.Name = "lblNOTIFY"
        Me.lblNOTIFY.Size = New System.Drawing.Size(54, 15)
        Me.lblNOTIFY.TabIndex = 17
        Me.lblNOTIFY.Text = "NOTIFY :"
        '
        'txtINVOICENO
        '
        Me.txtINVOICENO.Location = New System.Drawing.Point(88, 14)
        Me.txtINVOICENO.MaxLength = 20
        Me.txtINVOICENO.Name = "txtINVOICENO"
        Me.txtINVOICENO.Size = New System.Drawing.Size(100, 21)
        Me.txtINVOICENO.TabIndex = 18
        '
        'txtPACKINGLISTNO
        '
        Me.txtPACKINGLISTNO.Location = New System.Drawing.Point(303, 14)
        Me.txtPACKINGLISTNO.MaxLength = 20
        Me.txtPACKINGLISTNO.Name = "txtPACKINGLISTNO"
        Me.txtPACKINGLISTNO.Size = New System.Drawing.Size(100, 21)
        Me.txtPACKINGLISTNO.TabIndex = 19
        '
        'dtpINVOICEDATE
        '
        Me.dtpINVOICEDATE.Location = New System.Drawing.Point(502, 14)
        Me.dtpINVOICEDATE.Name = "dtpINVOICEDATE"
        Me.dtpINVOICEDATE.Size = New System.Drawing.Size(113, 21)
        Me.dtpINVOICEDATE.TabIndex = 20
        '
        'Grb1
        '
        Me.Grb1.Controls.Add(Me.lblINVOICENO)
        Me.Grb1.Controls.Add(Me.dtpINVOICEDATE)
        Me.Grb1.Controls.Add(Me.txtINVOICENO)
        Me.Grb1.Controls.Add(Me.txtPACKINGLISTNO)
        Me.Grb1.Controls.Add(Me.lblPACKINGLISTNO)
        Me.Grb1.Controls.Add(Me.lblINVOICEDATE)
        Me.Grb1.Location = New System.Drawing.Point(10, 3)
        Me.Grb1.Name = "Grb1"
        Me.Grb1.Size = New System.Drawing.Size(829, 45)
        Me.Grb1.TabIndex = 21
        Me.Grb1.TabStop = False
        '
        'GrbShipper
        '
        Me.GrbShipper.Controls.Add(Me.txtSHIPPEREXPORTERADDRESS)
        Me.GrbShipper.Controls.Add(Me.txtSHIPPEREXPORTER)
        Me.GrbShipper.Controls.Add(Me.lblSHIPPEREXPORTERADDRESS)
        Me.GrbShipper.Controls.Add(Me.lblSHIPPEREXPORTER)
        Me.GrbShipper.Location = New System.Drawing.Point(10, 54)
        Me.GrbShipper.Name = "GrbShipper"
        Me.GrbShipper.Size = New System.Drawing.Size(829, 70)
        Me.GrbShipper.TabIndex = 22
        Me.GrbShipper.TabStop = False
        Me.GrbShipper.Text = "Shipper"
        '
        'txtSHIPPEREXPORTERADDRESS
        '
        Me.txtSHIPPEREXPORTERADDRESS.Location = New System.Drawing.Point(175, 39)
        Me.txtSHIPPEREXPORTERADDRESS.MaxLength = 255
        Me.txtSHIPPEREXPORTERADDRESS.Name = "txtSHIPPEREXPORTERADDRESS"
        Me.txtSHIPPEREXPORTERADDRESS.Size = New System.Drawing.Size(646, 21)
        Me.txtSHIPPEREXPORTERADDRESS.TabIndex = 22
        '
        'txtSHIPPEREXPORTER
        '
        Me.txtSHIPPEREXPORTER.Location = New System.Drawing.Point(126, 12)
        Me.txtSHIPPEREXPORTER.MaxLength = 100
        Me.txtSHIPPEREXPORTER.Name = "txtSHIPPEREXPORTER"
        Me.txtSHIPPEREXPORTER.Size = New System.Drawing.Size(171, 21)
        Me.txtSHIPPEREXPORTER.TabIndex = 21
        '
        'GrbConsign
        '
        Me.GrbConsign.Controls.Add(Me.txtCONSIGNEEADDRESS)
        Me.GrbConsign.Controls.Add(Me.txtCONSIGNEE)
        Me.GrbConsign.Controls.Add(Me.lblCONSIGNEEADDRESS)
        Me.GrbConsign.Controls.Add(Me.lblCONSIGNEE)
        Me.GrbConsign.Location = New System.Drawing.Point(12, 130)
        Me.GrbConsign.Name = "GrbConsign"
        Me.GrbConsign.Size = New System.Drawing.Size(827, 71)
        Me.GrbConsign.TabIndex = 23
        Me.GrbConsign.TabStop = False
        Me.GrbConsign.Text = "Consignee"
        '
        'txtCONSIGNEEADDRESS
        '
        Me.txtCONSIGNEEADDRESS.Location = New System.Drawing.Point(124, 44)
        Me.txtCONSIGNEEADDRESS.MaxLength = 255
        Me.txtCONSIGNEEADDRESS.Name = "txtCONSIGNEEADDRESS"
        Me.txtCONSIGNEEADDRESS.Size = New System.Drawing.Size(695, 21)
        Me.txtCONSIGNEEADDRESS.TabIndex = 23
        '
        'txtCONSIGNEE
        '
        Me.txtCONSIGNEE.Location = New System.Drawing.Point(124, 16)
        Me.txtCONSIGNEE.MaxLength = 100
        Me.txtCONSIGNEE.Name = "txtCONSIGNEE"
        Me.txtCONSIGNEE.Size = New System.Drawing.Size(171, 21)
        Me.txtCONSIGNEE.TabIndex = 23
        '
        'GrbCondition
        '
        Me.GrbCondition.Controls.Add(Me.txtSHIPPINGMODE)
        Me.GrbCondition.Controls.Add(Me.txtTERMSOFDELIVERY)
        Me.GrbCondition.Controls.Add(Me.lblTERMSOFDELIVERY)
        Me.GrbCondition.Controls.Add(Me.Label2)
        Me.GrbCondition.Location = New System.Drawing.Point(12, 207)
        Me.GrbCondition.Name = "GrbCondition"
        Me.GrbCondition.Size = New System.Drawing.Size(827, 48)
        Me.GrbCondition.TabIndex = 24
        Me.GrbCondition.TabStop = False
        Me.GrbCondition.Text = "Condition"
        '
        'txtSHIPPINGMODE
        '
        Me.txtSHIPPINGMODE.Location = New System.Drawing.Point(500, 16)
        Me.txtSHIPPINGMODE.MaxLength = 255
        Me.txtSHIPPINGMODE.Name = "txtSHIPPINGMODE"
        Me.txtSHIPPINGMODE.Size = New System.Drawing.Size(319, 21)
        Me.txtSHIPPINGMODE.TabIndex = 24
        '
        'txtTERMSOFDELIVERY
        '
        Me.txtTERMSOFDELIVERY.Location = New System.Drawing.Point(124, 16)
        Me.txtTERMSOFDELIVERY.MaxLength = 255
        Me.txtTERMSOFDELIVERY.Name = "txtTERMSOFDELIVERY"
        Me.txtTERMSOFDELIVERY.Size = New System.Drawing.Size(266, 21)
        Me.txtTERMSOFDELIVERY.TabIndex = 24
        '
        'GrbPayment
        '
        Me.GrbPayment.Controls.Add(Me.txtACCOUNTNO)
        Me.GrbPayment.Controls.Add(Me.txtPAYMENTBANK)
        Me.GrbPayment.Controls.Add(Me.txtPAYMENT)
        Me.GrbPayment.Controls.Add(Me.lblPAYMENT)
        Me.GrbPayment.Controls.Add(Me.lblPAYMENTBANK)
        Me.GrbPayment.Controls.Add(Me.lblACCOUNTNO)
        Me.GrbPayment.Location = New System.Drawing.Point(12, 261)
        Me.GrbPayment.Name = "GrbPayment"
        Me.GrbPayment.Size = New System.Drawing.Size(825, 75)
        Me.GrbPayment.TabIndex = 25
        Me.GrbPayment.TabStop = False
        Me.GrbPayment.Text = "Payment"
        '
        'txtACCOUNTNO
        '
        Me.txtACCOUNTNO.Location = New System.Drawing.Point(500, 46)
        Me.txtACCOUNTNO.MaxLength = 50
        Me.txtACCOUNTNO.Name = "txtACCOUNTNO"
        Me.txtACCOUNTNO.Size = New System.Drawing.Size(319, 21)
        Me.txtACCOUNTNO.TabIndex = 25
        '
        'txtPAYMENTBANK
        '
        Me.txtPAYMENTBANK.Location = New System.Drawing.Point(124, 45)
        Me.txtPAYMENTBANK.MaxLength = 255
        Me.txtPAYMENTBANK.Name = "txtPAYMENTBANK"
        Me.txtPAYMENTBANK.Size = New System.Drawing.Size(277, 21)
        Me.txtPAYMENTBANK.TabIndex = 24
        '
        'txtPAYMENT
        '
        Me.txtPAYMENT.Location = New System.Drawing.Point(124, 18)
        Me.txtPAYMENT.MaxLength = 255
        Me.txtPAYMENT.Name = "txtPAYMENT"
        Me.txtPAYMENT.Size = New System.Drawing.Size(109, 21)
        Me.txtPAYMENT.TabIndex = 24
        '
        'GrbDestination
        '
        Me.GrbDestination.Controls.Add(Me.txtLOADINGPORTCODE)
        Me.GrbDestination.Controls.Add(Me.lblLOADINGPORTCODE)
        Me.GrbDestination.Controls.Add(Me.txtDESTINATION)
        Me.GrbDestination.Controls.Add(Me.txtLOADINGPORTNAME)
        Me.GrbDestination.Controls.Add(Me.txtPURCHASEORDER)
        Me.GrbDestination.Controls.Add(Me.lblPURCHASEORDER)
        Me.GrbDestination.Controls.Add(Me.lblLOADINGPORTNAME)
        Me.GrbDestination.Controls.Add(Me.lblDESTINATION)
        Me.GrbDestination.Location = New System.Drawing.Point(12, 342)
        Me.GrbDestination.Name = "GrbDestination"
        Me.GrbDestination.Size = New System.Drawing.Size(825, 76)
        Me.GrbDestination.TabIndex = 26
        Me.GrbDestination.TabStop = False
        Me.GrbDestination.Text = "Destination"
        '
        'txtLOADINGPORTCODE
        '
        Me.txtLOADINGPORTCODE.Location = New System.Drawing.Point(500, 20)
        Me.txtLOADINGPORTCODE.MaxLength = 100
        Me.txtLOADINGPORTCODE.Name = "txtLOADINGPORTCODE"
        Me.txtLOADINGPORTCODE.ReadOnly = True
        Me.txtLOADINGPORTCODE.Size = New System.Drawing.Size(135, 21)
        Me.txtLOADINGPORTCODE.TabIndex = 30
        '
        'lblLOADINGPORTCODE
        '
        Me.lblLOADINGPORTCODE.AutoSize = True
        Me.lblLOADINGPORTCODE.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLOADINGPORTCODE.Location = New System.Drawing.Point(371, 21)
        Me.lblLOADINGPORTCODE.Name = "lblLOADINGPORTCODE"
        Me.lblLOADINGPORTCODE.Size = New System.Drawing.Size(125, 15)
        Me.lblLOADINGPORTCODE.TabIndex = 29
        Me.lblLOADINGPORTCODE.Text = "LOADINGPORTCODE :"
        '
        'txtDESTINATION
        '
        Me.txtDESTINATION.Location = New System.Drawing.Point(500, 49)
        Me.txtDESTINATION.MaxLength = 100
        Me.txtDESTINATION.Name = "txtDESTINATION"
        Me.txtDESTINATION.Size = New System.Drawing.Size(319, 21)
        Me.txtDESTINATION.TabIndex = 28
        '
        'txtLOADINGPORTNAME
        '
        Me.txtLOADINGPORTNAME.Location = New System.Drawing.Point(127, 49)
        Me.txtLOADINGPORTNAME.MaxLength = 100
        Me.txtLOADINGPORTNAME.Name = "txtLOADINGPORTNAME"
        Me.txtLOADINGPORTNAME.Size = New System.Drawing.Size(274, 21)
        Me.txtLOADINGPORTNAME.TabIndex = 27
        '
        'txtPURCHASEORDER
        '
        Me.txtPURCHASEORDER.Location = New System.Drawing.Point(127, 16)
        Me.txtPURCHASEORDER.MaxLength = 30
        Me.txtPURCHASEORDER.Name = "txtPURCHASEORDER"
        Me.txtPURCHASEORDER.Size = New System.Drawing.Size(109, 21)
        Me.txtPURCHASEORDER.TabIndex = 26
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtNOTIFY)
        Me.GroupBox2.Controls.Add(Me.lblNOTIFY)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 424)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(827, 56)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Notify"
        '
        'txtNOTIFY
        '
        Me.txtNOTIFY.Location = New System.Drawing.Point(129, 11)
        Me.txtNOTIFY.MaxLength = 255
        Me.txtNOTIFY.Multiline = True
        Me.txtNOTIFY.Name = "txtNOTIFY"
        Me.txtNOTIFY.Size = New System.Drawing.Size(692, 39)
        Me.txtNOTIFY.TabIndex = 29
        '
        'GrpPickingList
        '
        Me.GrpPickingList.Controls.Add(Me.lblPL_TOTAL_GWEIGHT)
        Me.GrpPickingList.Controls.Add(Me.lblPL_TOTAL_NWEIGHT)
        Me.GrpPickingList.Controls.Add(Me.txtPL_TOTAL_GWEIGHT)
        Me.GrpPickingList.Controls.Add(Me.txtPL_TOTAL_NWEIGHT)
        Me.GrpPickingList.Controls.Add(Me.txtPL_TOTAL_NWEIGHT_PLTS)
        Me.GrpPickingList.Controls.Add(Me.txtPL_TOTAL_MESURMENT)
        Me.GrpPickingList.Controls.Add(Me.lblPL_TOTAL_NWEIGHT_PLTS)
        Me.GrpPickingList.Controls.Add(Me.lblPL_TOTAL_MESURMENT)
        Me.GrpPickingList.Controls.Add(Me.lblPL_ETA)
        Me.GrpPickingList.Controls.Add(Me.txtPL_ETA)
        Me.GrpPickingList.Controls.Add(Me.txtPL_ETD)
        Me.GrpPickingList.Controls.Add(Me.lblPL_ETD)
        Me.GrpPickingList.Controls.Add(Me.lblPL_CONTACTPERSON_EMAIL)
        Me.GrpPickingList.Controls.Add(Me.txtPL_CONTACTPERSON_EMAIL)
        Me.GrpPickingList.Controls.Add(Me.txtPL_CONTACTPERSON)
        Me.GrpPickingList.Controls.Add(Me.lblPL_CONTACTPERSON)
        Me.GrpPickingList.Location = New System.Drawing.Point(10, 487)
        Me.GrpPickingList.Name = "GrpPickingList"
        Me.GrpPickingList.Size = New System.Drawing.Size(829, 125)
        Me.GrpPickingList.TabIndex = 27
        Me.GrpPickingList.TabStop = False
        Me.GrpPickingList.Text = "PickingList"
        '
        'lblPL_TOTAL_GWEIGHT
        '
        Me.lblPL_TOTAL_GWEIGHT.AutoSize = True
        Me.lblPL_TOTAL_GWEIGHT.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPL_TOTAL_GWEIGHT.Location = New System.Drawing.Point(393, 95)
        Me.lblPL_TOTAL_GWEIGHT.Name = "lblPL_TOTAL_GWEIGHT"
        Me.lblPL_TOTAL_GWEIGHT.Size = New System.Drawing.Size(107, 15)
        Me.lblPL_TOTAL_GWEIGHT.TabIndex = 45
        Me.lblPL_TOTAL_GWEIGHT.Text = "TOTAL_GWEIGHT :"
        '
        'lblPL_TOTAL_NWEIGHT
        '
        Me.lblPL_TOTAL_NWEIGHT.AutoSize = True
        Me.lblPL_TOTAL_NWEIGHT.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPL_TOTAL_NWEIGHT.Location = New System.Drawing.Point(392, 70)
        Me.lblPL_TOTAL_NWEIGHT.Name = "lblPL_TOTAL_NWEIGHT"
        Me.lblPL_TOTAL_NWEIGHT.Size = New System.Drawing.Size(108, 15)
        Me.lblPL_TOTAL_NWEIGHT.TabIndex = 44
        Me.lblPL_TOTAL_NWEIGHT.Text = "TOTAL_NWEIGHT :"
        '
        'txtPL_TOTAL_GWEIGHT
        '
        Me.txtPL_TOTAL_GWEIGHT.Location = New System.Drawing.Point(502, 92)
        Me.txtPL_TOTAL_GWEIGHT.MaxLength = 100
        Me.txtPL_TOTAL_GWEIGHT.Name = "txtPL_TOTAL_GWEIGHT"
        Me.txtPL_TOTAL_GWEIGHT.Size = New System.Drawing.Size(106, 21)
        Me.txtPL_TOTAL_GWEIGHT.TabIndex = 43
        Me.txtPL_TOTAL_GWEIGHT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPL_TOTAL_NWEIGHT
        '
        Me.txtPL_TOTAL_NWEIGHT.Location = New System.Drawing.Point(502, 67)
        Me.txtPL_TOTAL_NWEIGHT.MaxLength = 100
        Me.txtPL_TOTAL_NWEIGHT.Name = "txtPL_TOTAL_NWEIGHT"
        Me.txtPL_TOTAL_NWEIGHT.Size = New System.Drawing.Size(106, 21)
        Me.txtPL_TOTAL_NWEIGHT.TabIndex = 42
        Me.txtPL_TOTAL_NWEIGHT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPL_TOTAL_NWEIGHT_PLTS
        '
        Me.txtPL_TOTAL_NWEIGHT_PLTS.Location = New System.Drawing.Point(147, 95)
        Me.txtPL_TOTAL_NWEIGHT_PLTS.MaxLength = 100
        Me.txtPL_TOTAL_NWEIGHT_PLTS.Name = "txtPL_TOTAL_NWEIGHT_PLTS"
        Me.txtPL_TOTAL_NWEIGHT_PLTS.Size = New System.Drawing.Size(106, 21)
        Me.txtPL_TOTAL_NWEIGHT_PLTS.TabIndex = 41
        Me.txtPL_TOTAL_NWEIGHT_PLTS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPL_TOTAL_MESURMENT
        '
        Me.txtPL_TOTAL_MESURMENT.Location = New System.Drawing.Point(147, 70)
        Me.txtPL_TOTAL_MESURMENT.MaxLength = 100
        Me.txtPL_TOTAL_MESURMENT.Name = "txtPL_TOTAL_MESURMENT"
        Me.txtPL_TOTAL_MESURMENT.Size = New System.Drawing.Size(106, 21)
        Me.txtPL_TOTAL_MESURMENT.TabIndex = 40
        Me.txtPL_TOTAL_MESURMENT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPL_TOTAL_NWEIGHT_PLTS
        '
        Me.lblPL_TOTAL_NWEIGHT_PLTS.AutoSize = True
        Me.lblPL_TOTAL_NWEIGHT_PLTS.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPL_TOTAL_NWEIGHT_PLTS.Location = New System.Drawing.Point(6, 98)
        Me.lblPL_TOTAL_NWEIGHT_PLTS.Name = "lblPL_TOTAL_NWEIGHT_PLTS"
        Me.lblPL_TOTAL_NWEIGHT_PLTS.Size = New System.Drawing.Size(139, 15)
        Me.lblPL_TOTAL_NWEIGHT_PLTS.TabIndex = 39
        Me.lblPL_TOTAL_NWEIGHT_PLTS.Text = "TOTAL_NWEIGHT_PLTS :"
        '
        'lblPL_TOTAL_MESURMENT
        '
        Me.lblPL_TOTAL_MESURMENT.AutoSize = True
        Me.lblPL_TOTAL_MESURMENT.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPL_TOTAL_MESURMENT.Location = New System.Drawing.Point(19, 73)
        Me.lblPL_TOTAL_MESURMENT.Name = "lblPL_TOTAL_MESURMENT"
        Me.lblPL_TOTAL_MESURMENT.Size = New System.Drawing.Size(126, 15)
        Me.lblPL_TOTAL_MESURMENT.TabIndex = 38
        Me.lblPL_TOTAL_MESURMENT.Text = "TOTAL_MESURMENT :"
        '
        'lblPL_ETA
        '
        Me.lblPL_ETA.AutoSize = True
        Me.lblPL_ETA.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPL_ETA.Location = New System.Drawing.Point(448, 46)
        Me.lblPL_ETA.Name = "lblPL_ETA"
        Me.lblPL_ETA.Size = New System.Drawing.Size(34, 15)
        Me.lblPL_ETA.TabIndex = 37
        Me.lblPL_ETA.Text = "ETA :"
        '
        'txtPL_ETA
        '
        Me.txtPL_ETA.Location = New System.Drawing.Point(502, 43)
        Me.txtPL_ETA.MaxLength = 100
        Me.txtPL_ETA.Name = "txtPL_ETA"
        Me.txtPL_ETA.Size = New System.Drawing.Size(106, 21)
        Me.txtPL_ETA.TabIndex = 36
        '
        'txtPL_ETD
        '
        Me.txtPL_ETD.Location = New System.Drawing.Point(132, 43)
        Me.txtPL_ETD.MaxLength = 100
        Me.txtPL_ETD.Name = "txtPL_ETD"
        Me.txtPL_ETD.Size = New System.Drawing.Size(106, 21)
        Me.txtPL_ETD.TabIndex = 35
        '
        'lblPL_ETD
        '
        Me.lblPL_ETD.AutoSize = True
        Me.lblPL_ETD.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPL_ETD.Location = New System.Drawing.Point(95, 46)
        Me.lblPL_ETD.Name = "lblPL_ETD"
        Me.lblPL_ETD.Size = New System.Drawing.Size(34, 15)
        Me.lblPL_ETD.TabIndex = 34
        Me.lblPL_ETD.Text = "ETD :"
        '
        'lblPL_CONTACTPERSON_EMAIL
        '
        Me.lblPL_CONTACTPERSON_EMAIL.AutoSize = True
        Me.lblPL_CONTACTPERSON_EMAIL.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPL_CONTACTPERSON_EMAIL.Location = New System.Drawing.Point(452, 21)
        Me.lblPL_CONTACTPERSON_EMAIL.Name = "lblPL_CONTACTPERSON_EMAIL"
        Me.lblPL_CONTACTPERSON_EMAIL.Size = New System.Drawing.Size(47, 15)
        Me.lblPL_CONTACTPERSON_EMAIL.TabIndex = 33
        Me.lblPL_CONTACTPERSON_EMAIL.Text = "E-mail :"
        '
        'txtPL_CONTACTPERSON_EMAIL
        '
        Me.txtPL_CONTACTPERSON_EMAIL.Location = New System.Drawing.Point(502, 18)
        Me.txtPL_CONTACTPERSON_EMAIL.MaxLength = 100
        Me.txtPL_CONTACTPERSON_EMAIL.Name = "txtPL_CONTACTPERSON_EMAIL"
        Me.txtPL_CONTACTPERSON_EMAIL.Size = New System.Drawing.Size(274, 21)
        Me.txtPL_CONTACTPERSON_EMAIL.TabIndex = 32
        '
        'txtPL_CONTACTPERSON
        '
        Me.txtPL_CONTACTPERSON.Location = New System.Drawing.Point(131, 16)
        Me.txtPL_CONTACTPERSON.MaxLength = 100
        Me.txtPL_CONTACTPERSON.Name = "txtPL_CONTACTPERSON"
        Me.txtPL_CONTACTPERSON.Size = New System.Drawing.Size(274, 21)
        Me.txtPL_CONTACTPERSON.TabIndex = 31
        '
        'lblPL_CONTACTPERSON
        '
        Me.lblPL_CONTACTPERSON.AutoSize = True
        Me.lblPL_CONTACTPERSON.Font = New System.Drawing.Font("Segoe UI Symbol", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPL_CONTACTPERSON.Location = New System.Drawing.Point(9, 19)
        Me.lblPL_CONTACTPERSON.Name = "lblPL_CONTACTPERSON"
        Me.lblPL_CONTACTPERSON.Size = New System.Drawing.Size(120, 15)
        Me.lblPL_CONTACTPERSON.TabIndex = 18
        Me.lblPL_CONTACTPERSON.Text = "CONTRACTPERSON :"
        '
        'FrmInvoicePackingSub
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(849, 906)
        Me.Controls.Add(Me.GrpPickingList)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GrbShipper)
        Me.Controls.Add(Me.Grb1)
        Me.Controls.Add(Me.GrbConsign)
        Me.Controls.Add(Me.GrbCondition)
        Me.Controls.Add(Me.GrbPayment)
        Me.Controls.Add(Me.GrbDestination)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInvoicePackingSub"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Commercial Invoice 명세"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grb1.ResumeLayout(False)
        Me.Grb1.PerformLayout()
        Me.GrbShipper.ResumeLayout(False)
        Me.GrbShipper.PerformLayout()
        Me.GrbConsign.ResumeLayout(False)
        Me.GrbConsign.PerformLayout()
        Me.GrbCondition.ResumeLayout(False)
        Me.GrbCondition.PerformLayout()
        Me.GrbPayment.ResumeLayout(False)
        Me.GrbPayment.PerformLayout()
        Me.GrbDestination.ResumeLayout(False)
        Me.GrbDestination.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GrpPickingList.ResumeLayout(False)
        Me.GrpPickingList.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblINVOICENO As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents lblPACKINGLISTNO As Label
    Friend WithEvents lblINVOICEDATE As Label
    Friend WithEvents lblSHIPPEREXPORTER As Label
    Friend WithEvents lblSHIPPEREXPORTERADDRESS As Label
    Friend WithEvents lblCONSIGNEE As Label
    Friend WithEvents lblCONSIGNEEADDRESS As Label
    Friend WithEvents lblTERMSOFDELIVERY As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblPAYMENT As Label
    Friend WithEvents lblPAYMENTBANK As Label
    Friend WithEvents lblACCOUNTNO As Label
    Friend WithEvents lblPURCHASEORDER As Label
    Friend WithEvents lblLOADINGPORTNAME As Label
    Friend WithEvents lblDESTINATION As Label
    Friend WithEvents lblNOTIFY As Label
    Friend WithEvents txtINVOICENO As TextBox
    Friend WithEvents txtPACKINGLISTNO As TextBox
    Friend WithEvents dtpINVOICEDATE As DateTimePicker
    Friend WithEvents Grb1 As GroupBox
    Friend WithEvents GrbShipper As GroupBox
    Friend WithEvents txtSHIPPEREXPORTERADDRESS As TextBox
    Friend WithEvents txtSHIPPEREXPORTER As TextBox
    Friend WithEvents GrbConsign As GroupBox
    Friend WithEvents txtCONSIGNEEADDRESS As TextBox
    Friend WithEvents txtCONSIGNEE As TextBox
    Friend WithEvents GrbCondition As GroupBox
    Friend WithEvents txtSHIPPINGMODE As TextBox
    Friend WithEvents txtTERMSOFDELIVERY As TextBox
    Friend WithEvents GrbPayment As GroupBox
    Friend WithEvents txtACCOUNTNO As TextBox
    Friend WithEvents txtPAYMENTBANK As TextBox
    Friend WithEvents txtPAYMENT As TextBox
    Friend WithEvents GrbDestination As GroupBox
    Friend WithEvents txtDESTINATION As TextBox
    Friend WithEvents txtLOADINGPORTNAME As TextBox
    Friend WithEvents txtPURCHASEORDER As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtNOTIFY As TextBox
    Friend WithEvents txtLOADINGPORTCODE As TextBox
    Friend WithEvents lblLOADINGPORTCODE As Label
    Friend WithEvents GrpPickingList As GroupBox
    Friend WithEvents lblPL_ETA As Label
    Friend WithEvents txtPL_ETA As TextBox
    Friend WithEvents txtPL_ETD As TextBox
    Friend WithEvents lblPL_ETD As Label
    Friend WithEvents lblPL_CONTACTPERSON_EMAIL As Label
    Friend WithEvents txtPL_CONTACTPERSON_EMAIL As TextBox
    Friend WithEvents txtPL_CONTACTPERSON As TextBox
    Friend WithEvents lblPL_CONTACTPERSON As Label
    Friend WithEvents lblPL_TOTAL_GWEIGHT As Label
    Friend WithEvents lblPL_TOTAL_NWEIGHT As Label
    Friend WithEvents txtPL_TOTAL_GWEIGHT As TextBox
    Friend WithEvents txtPL_TOTAL_NWEIGHT As TextBox
    Friend WithEvents txtPL_TOTAL_NWEIGHT_PLTS As TextBox
    Friend WithEvents txtPL_TOTAL_MESURMENT As TextBox
    Friend WithEvents lblPL_TOTAL_NWEIGHT_PLTS As Label
    Friend WithEvents lblPL_TOTAL_MESURMENT As Label
End Class
