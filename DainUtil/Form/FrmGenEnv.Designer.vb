<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGenEnv
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Office2010Blue1 As DainUtil.ManiX.Office2010Blue = New DainUtil.ManiX.Office2010Blue()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtReportSeqNo = New System.Windows.Forms.TextBox()
        Me.lblReportSeqNo = New System.Windows.Forms.Label()
        Me.txtReportPresenter = New System.Windows.Forms.TextBox()
        Me.lblReportPresenter = New System.Windows.Forms.Label()
        Me.txtReporterName = New System.Windows.Forms.TextBox()
        Me.lblReporterCode = New System.Windows.Forms.Label()
        Me.txtReporterCode = New System.Windows.Forms.TextBox()
        Me.lblReporter = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblSHIPPERSEXPORT1CUSTOMSCODE = New System.Windows.Forms.Label()
        Me.txtSHIPPERSEXPORT1CUSTOMSCODE = New System.Windows.Forms.TextBox()
        Me.lblSHIPPERSEXPORT1ADDRESS = New System.Windows.Forms.Label()
        Me.txtSHIPPERSEXPORT1POSTALCODE = New System.Windows.Forms.MaskedTextBox()
        Me.txtSHIPPERSEXPORT1ADDRESS = New System.Windows.Forms.TextBox()
        Me.lblSHIPPERSEXPORT1POSTALCODE = New System.Windows.Forms.Label()
        Me.txtSHIPPERSEXPORT1PRESENTER = New System.Windows.Forms.TextBox()
        Me.lblSHIPPERSEXPORT1PRESENTER = New System.Windows.Forms.Label()
        Me.txtSHIPPERSEXPORT1NAME = New System.Windows.Forms.TextBox()
        Me.lblSHIPPERSEXPORT1CODE = New System.Windows.Forms.Label()
        Me.txtSHIPPERSEXPORT1CODE = New System.Windows.Forms.TextBox()
        Me.lblSHIPPERSEXPORT1NAME = New System.Windows.Forms.Label()
        Me.btnUpdate = New DainUtil.ManiX.XButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblSHIPPERSEXPORTELSECUSTOMSCODE = New System.Windows.Forms.Label()
        Me.txtSHIPPERSEXPORTELSECUSTOMSCODE = New System.Windows.Forms.TextBox()
        Me.lblSHIPPERSEXPORTELSEADDRESS = New System.Windows.Forms.Label()
        Me.txtSHIPPERSEXPORTELSEPOSTALCODE = New System.Windows.Forms.MaskedTextBox()
        Me.txtSHIPPERSEXPORTELSEADDRESS = New System.Windows.Forms.TextBox()
        Me.lblSHIPPERSEXPORTELSEPOSTALCODE = New System.Windows.Forms.Label()
        Me.txtSHIPPERSEXPORTELSEPRESENTER = New System.Windows.Forms.TextBox()
        Me.lblSHIPPERSEXPORTELSEPRESENTER = New System.Windows.Forms.Label()
        Me.txtSHIPPERSEXPORTELSENAME = New System.Windows.Forms.TextBox()
        Me.lblSHIPPERSEXPORTELSECODE = New System.Windows.Forms.Label()
        Me.txtSHIPPERSEXPORTELSECODE = New System.Windows.Forms.TextBox()
        Me.lblSHIPPERSEXPORTELSENAME = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ChkFileOutFlag = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDataKeepDays = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClose = New DainUtil.ManiX.XButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.txtDataKeepDays, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtReportSeqNo)
        Me.GroupBox1.Controls.Add(Me.lblReportSeqNo)
        Me.GroupBox1.Controls.Add(Me.txtReportPresenter)
        Me.GroupBox1.Controls.Add(Me.lblReportPresenter)
        Me.GroupBox1.Controls.Add(Me.txtReporterName)
        Me.GroupBox1.Controls.Add(Me.lblReporterCode)
        Me.GroupBox1.Controls.Add(Me.txtReporterCode)
        Me.GroupBox1.Controls.Add(Me.lblReporter)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 114)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(338, 129)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "신고자"
        '
        'txtReportSeqNo
        '
        Me.txtReportSeqNo.Location = New System.Drawing.Point(104, 99)
        Me.txtReportSeqNo.MaxLength = 6
        Me.txtReportSeqNo.Name = "txtReportSeqNo"
        Me.txtReportSeqNo.ReadOnly = True
        Me.txtReportSeqNo.Size = New System.Drawing.Size(100, 21)
        Me.txtReportSeqNo.TabIndex = 7
        Me.txtReportSeqNo.Text = "000000"
        '
        'lblReportSeqNo
        '
        Me.lblReportSeqNo.AutoSize = True
        Me.lblReportSeqNo.Location = New System.Drawing.Point(14, 103)
        Me.lblReportSeqNo.Name = "lblReportSeqNo"
        Me.lblReportSeqNo.Size = New System.Drawing.Size(85, 12)
        Me.lblReportSeqNo.TabIndex = 6
        Me.lblReportSeqNo.Text = "신고번호연번 :"
        '
        'txtReportPresenter
        '
        Me.txtReportPresenter.Location = New System.Drawing.Point(104, 72)
        Me.txtReportPresenter.Name = "txtReportPresenter"
        Me.txtReportPresenter.Size = New System.Drawing.Size(199, 21)
        Me.txtReportPresenter.TabIndex = 4
        '
        'lblReportPresenter
        '
        Me.lblReportPresenter.AutoSize = True
        Me.lblReportPresenter.Location = New System.Drawing.Point(13, 76)
        Me.lblReportPresenter.Name = "lblReportPresenter"
        Me.lblReportPresenter.Size = New System.Drawing.Size(85, 12)
        Me.lblReportPresenter.TabIndex = 4
        Me.lblReportPresenter.Text = "신고자대표자 :"
        '
        'txtReporterName
        '
        Me.txtReporterName.Location = New System.Drawing.Point(104, 45)
        Me.txtReporterName.Name = "txtReporterName"
        Me.txtReporterName.Size = New System.Drawing.Size(199, 21)
        Me.txtReporterName.TabIndex = 3
        '
        'lblReporterCode
        '
        Me.lblReporterCode.AutoSize = True
        Me.lblReporterCode.Location = New System.Drawing.Point(21, 22)
        Me.lblReporterCode.Name = "lblReporterCode"
        Me.lblReporterCode.Size = New System.Drawing.Size(77, 12)
        Me.lblReporterCode.TabIndex = 2
        Me.lblReporterCode.Text = "신고자 부호 :"
        '
        'txtReporterCode
        '
        Me.txtReporterCode.Location = New System.Drawing.Point(104, 19)
        Me.txtReporterCode.MaxLength = 13
        Me.txtReporterCode.Name = "txtReporterCode"
        Me.txtReporterCode.Size = New System.Drawing.Size(100, 21)
        Me.txtReporterCode.TabIndex = 2
        '
        'lblReporter
        '
        Me.lblReporter.AutoSize = True
        Me.lblReporter.Location = New System.Drawing.Point(21, 49)
        Me.lblReporter.Name = "lblReporter"
        Me.lblReporter.Size = New System.Drawing.Size(77, 12)
        Me.lblReporter.TabIndex = 0
        Me.lblReporter.Text = "신고자 상호 :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblSHIPPERSEXPORT1CUSTOMSCODE)
        Me.GroupBox2.Controls.Add(Me.txtSHIPPERSEXPORT1CUSTOMSCODE)
        Me.GroupBox2.Controls.Add(Me.lblSHIPPERSEXPORT1ADDRESS)
        Me.GroupBox2.Controls.Add(Me.txtSHIPPERSEXPORT1POSTALCODE)
        Me.GroupBox2.Controls.Add(Me.txtSHIPPERSEXPORT1ADDRESS)
        Me.GroupBox2.Controls.Add(Me.lblSHIPPERSEXPORT1POSTALCODE)
        Me.GroupBox2.Controls.Add(Me.txtSHIPPERSEXPORT1PRESENTER)
        Me.GroupBox2.Controls.Add(Me.lblSHIPPERSEXPORT1PRESENTER)
        Me.GroupBox2.Controls.Add(Me.txtSHIPPERSEXPORT1NAME)
        Me.GroupBox2.Controls.Add(Me.lblSHIPPERSEXPORT1CODE)
        Me.GroupBox2.Controls.Add(Me.txtSHIPPERSEXPORT1CODE)
        Me.GroupBox2.Controls.Add(Me.lblSHIPPERSEXPORT1NAME)
        Me.GroupBox2.Location = New System.Drawing.Point(353, 44)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(335, 183)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "수출자(1)"
        '
        'lblSHIPPERSEXPORT1CUSTOMSCODE
        '
        Me.lblSHIPPERSEXPORT1CUSTOMSCODE.AutoSize = True
        Me.lblSHIPPERSEXPORT1CUSTOMSCODE.Location = New System.Drawing.Point(41, 154)
        Me.lblSHIPPERSEXPORT1CUSTOMSCODE.Name = "lblSHIPPERSEXPORT1CUSTOMSCODE"
        Me.lblSHIPPERSEXPORT1CUSTOMSCODE.Size = New System.Drawing.Size(61, 12)
        Me.lblSHIPPERSEXPORT1CUSTOMSCODE.TabIndex = 19
        Me.lblSHIPPERSEXPORT1CUSTOMSCODE.Text = "통관부호 :"
        '
        'txtSHIPPERSEXPORT1CUSTOMSCODE
        '
        Me.txtSHIPPERSEXPORT1CUSTOMSCODE.Location = New System.Drawing.Point(104, 151)
        Me.txtSHIPPERSEXPORT1CUSTOMSCODE.Name = "txtSHIPPERSEXPORT1CUSTOMSCODE"
        Me.txtSHIPPERSEXPORT1CUSTOMSCODE.Size = New System.Drawing.Size(225, 21)
        Me.txtSHIPPERSEXPORT1CUSTOMSCODE.TabIndex = 10
        '
        'lblSHIPPERSEXPORT1ADDRESS
        '
        Me.lblSHIPPERSEXPORT1ADDRESS.AutoSize = True
        Me.lblSHIPPERSEXPORT1ADDRESS.Location = New System.Drawing.Point(29, 128)
        Me.lblSHIPPERSEXPORT1ADDRESS.Name = "lblSHIPPERSEXPORT1ADDRESS"
        Me.lblSHIPPERSEXPORT1ADDRESS.Size = New System.Drawing.Size(73, 12)
        Me.lblSHIPPERSEXPORT1ADDRESS.TabIndex = 17
        Me.lblSHIPPERSEXPORT1ADDRESS.Text = "신고자주소 :"
        '
        'txtSHIPPERSEXPORT1POSTALCODE
        '
        Me.txtSHIPPERSEXPORT1POSTALCODE.Location = New System.Drawing.Point(104, 99)
        Me.txtSHIPPERSEXPORT1POSTALCODE.Mask = "00000"
        Me.txtSHIPPERSEXPORT1POSTALCODE.Name = "txtSHIPPERSEXPORT1POSTALCODE"
        Me.txtSHIPPERSEXPORT1POSTALCODE.Size = New System.Drawing.Size(100, 21)
        Me.txtSHIPPERSEXPORT1POSTALCODE.TabIndex = 8
        '
        'txtSHIPPERSEXPORT1ADDRESS
        '
        Me.txtSHIPPERSEXPORT1ADDRESS.Location = New System.Drawing.Point(104, 124)
        Me.txtSHIPPERSEXPORT1ADDRESS.Name = "txtSHIPPERSEXPORT1ADDRESS"
        Me.txtSHIPPERSEXPORT1ADDRESS.Size = New System.Drawing.Size(225, 21)
        Me.txtSHIPPERSEXPORT1ADDRESS.TabIndex = 9
        '
        'lblSHIPPERSEXPORT1POSTALCODE
        '
        Me.lblSHIPPERSEXPORT1POSTALCODE.AutoSize = True
        Me.lblSHIPPERSEXPORT1POSTALCODE.Location = New System.Drawing.Point(5, 104)
        Me.lblSHIPPERSEXPORT1POSTALCODE.Name = "lblSHIPPERSEXPORT1POSTALCODE"
        Me.lblSHIPPERSEXPORT1POSTALCODE.Size = New System.Drawing.Size(97, 12)
        Me.lblSHIPPERSEXPORT1POSTALCODE.TabIndex = 13
        Me.lblSHIPPERSEXPORT1POSTALCODE.Text = "신고자우편번호 :"
        '
        'txtSHIPPERSEXPORT1PRESENTER
        '
        Me.txtSHIPPERSEXPORT1PRESENTER.Location = New System.Drawing.Point(104, 73)
        Me.txtSHIPPERSEXPORT1PRESENTER.Name = "txtSHIPPERSEXPORT1PRESENTER"
        Me.txtSHIPPERSEXPORT1PRESENTER.Size = New System.Drawing.Size(225, 21)
        Me.txtSHIPPERSEXPORT1PRESENTER.TabIndex = 7
        '
        'lblSHIPPERSEXPORT1PRESENTER
        '
        Me.lblSHIPPERSEXPORT1PRESENTER.AutoSize = True
        Me.lblSHIPPERSEXPORT1PRESENTER.Location = New System.Drawing.Point(17, 77)
        Me.lblSHIPPERSEXPORT1PRESENTER.Name = "lblSHIPPERSEXPORT1PRESENTER"
        Me.lblSHIPPERSEXPORT1PRESENTER.Size = New System.Drawing.Size(85, 12)
        Me.lblSHIPPERSEXPORT1PRESENTER.TabIndex = 11
        Me.lblSHIPPERSEXPORT1PRESENTER.Text = "신고자대표자 :"
        '
        'txtSHIPPERSEXPORT1NAME
        '
        Me.txtSHIPPERSEXPORT1NAME.Location = New System.Drawing.Point(104, 46)
        Me.txtSHIPPERSEXPORT1NAME.Name = "txtSHIPPERSEXPORT1NAME"
        Me.txtSHIPPERSEXPORT1NAME.Size = New System.Drawing.Size(225, 21)
        Me.txtSHIPPERSEXPORT1NAME.TabIndex = 6
        '
        'lblSHIPPERSEXPORT1CODE
        '
        Me.lblSHIPPERSEXPORT1CODE.AutoSize = True
        Me.lblSHIPPERSEXPORT1CODE.Location = New System.Drawing.Point(24, 23)
        Me.lblSHIPPERSEXPORT1CODE.Name = "lblSHIPPERSEXPORT1CODE"
        Me.lblSHIPPERSEXPORT1CODE.Size = New System.Drawing.Size(77, 12)
        Me.lblSHIPPERSEXPORT1CODE.TabIndex = 9
        Me.lblSHIPPERSEXPORT1CODE.Text = "신고자 부호 :"
        '
        'txtSHIPPERSEXPORT1CODE
        '
        Me.txtSHIPPERSEXPORT1CODE.Location = New System.Drawing.Point(104, 20)
        Me.txtSHIPPERSEXPORT1CODE.MaxLength = 13
        Me.txtSHIPPERSEXPORT1CODE.Name = "txtSHIPPERSEXPORT1CODE"
        Me.txtSHIPPERSEXPORT1CODE.Size = New System.Drawing.Size(100, 21)
        Me.txtSHIPPERSEXPORT1CODE.TabIndex = 5
        '
        'lblSHIPPERSEXPORT1NAME
        '
        Me.lblSHIPPERSEXPORT1NAME.AutoSize = True
        Me.lblSHIPPERSEXPORT1NAME.Location = New System.Drawing.Point(25, 50)
        Me.lblSHIPPERSEXPORT1NAME.Name = "lblSHIPPERSEXPORT1NAME"
        Me.lblSHIPPERSEXPORT1NAME.Size = New System.Drawing.Size(77, 12)
        Me.lblSHIPPERSEXPORT1NAME.TabIndex = 7
        Me.lblSHIPPERSEXPORT1NAME.Text = "신고자 상호 :"
        '
        'btnUpdate
        '
        Office2010Blue1.BorderColor1 = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(161, Byte), Integer))
        Office2010Blue1.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(228, Byte), Integer))
        Office2010Blue1.ButtonMouseOverColor1 = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(87, Byte), Integer))
        Office2010Blue1.ButtonMouseOverColor2 = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(215, Byte), Integer))
        Office2010Blue1.ButtonMouseOverColor3 = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(137, Byte), Integer))
        Office2010Blue1.ButtonMouseOverColor4 = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(224, Byte), Integer))
        Office2010Blue1.ButtonNormalColor1 = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(161, Byte), Integer))
        Office2010Blue1.ButtonNormalColor2 = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(228, Byte), Integer))
        Office2010Blue1.ButtonNormalColor3 = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(181, Byte), Integer))
        Office2010Blue1.ButtonNormalColor4 = System.Drawing.Color.FromArgb(CType(CType(62, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(219, Byte), Integer))
        Office2010Blue1.ButtonSelectedColor1 = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(87, Byte), Integer))
        Office2010Blue1.ButtonSelectedColor2 = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(215, Byte), Integer))
        Office2010Blue1.ButtonSelectedColor3 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(117, Byte), Integer))
        Office2010Blue1.ButtonSelectedColor4 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(107, Byte), Integer))
        Office2010Blue1.HoverTextColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Office2010Blue1.SelectedTextColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Office2010Blue1.TextColor = System.Drawing.Color.White
        Me.btnUpdate.ColorTable = Office2010Blue1
        Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdate.Location = New System.Drawing.Point(532, 12)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 17
        Me.btnUpdate.Text = "갱신"
        Me.btnUpdate.Theme = DainUtil.ManiX.Theme.MSOffice2010_BLUE
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblSHIPPERSEXPORTELSECUSTOMSCODE)
        Me.GroupBox3.Controls.Add(Me.txtSHIPPERSEXPORTELSECUSTOMSCODE)
        Me.GroupBox3.Controls.Add(Me.lblSHIPPERSEXPORTELSEADDRESS)
        Me.GroupBox3.Controls.Add(Me.txtSHIPPERSEXPORTELSEPOSTALCODE)
        Me.GroupBox3.Controls.Add(Me.txtSHIPPERSEXPORTELSEADDRESS)
        Me.GroupBox3.Controls.Add(Me.lblSHIPPERSEXPORTELSEPOSTALCODE)
        Me.GroupBox3.Controls.Add(Me.txtSHIPPERSEXPORTELSEPRESENTER)
        Me.GroupBox3.Controls.Add(Me.lblSHIPPERSEXPORTELSEPRESENTER)
        Me.GroupBox3.Controls.Add(Me.txtSHIPPERSEXPORTELSENAME)
        Me.GroupBox3.Controls.Add(Me.lblSHIPPERSEXPORTELSECODE)
        Me.GroupBox3.Controls.Add(Me.txtSHIPPERSEXPORTELSECODE)
        Me.GroupBox3.Controls.Add(Me.lblSHIPPERSEXPORTELSENAME)
        Me.GroupBox3.Location = New System.Drawing.Point(353, 233)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(335, 183)
        Me.GroupBox3.TabIndex = 20
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "수출자(2) - etc"
        '
        'lblSHIPPERSEXPORTELSECUSTOMSCODE
        '
        Me.lblSHIPPERSEXPORTELSECUSTOMSCODE.AutoSize = True
        Me.lblSHIPPERSEXPORTELSECUSTOMSCODE.Location = New System.Drawing.Point(40, 155)
        Me.lblSHIPPERSEXPORTELSECUSTOMSCODE.Name = "lblSHIPPERSEXPORTELSECUSTOMSCODE"
        Me.lblSHIPPERSEXPORTELSECUSTOMSCODE.Size = New System.Drawing.Size(61, 12)
        Me.lblSHIPPERSEXPORTELSECUSTOMSCODE.TabIndex = 19
        Me.lblSHIPPERSEXPORTELSECUSTOMSCODE.Text = "통관부호 :"
        '
        'txtSHIPPERSEXPORTELSECUSTOMSCODE
        '
        Me.txtSHIPPERSEXPORTELSECUSTOMSCODE.Location = New System.Drawing.Point(104, 151)
        Me.txtSHIPPERSEXPORTELSECUSTOMSCODE.Name = "txtSHIPPERSEXPORTELSECUSTOMSCODE"
        Me.txtSHIPPERSEXPORTELSECUSTOMSCODE.Size = New System.Drawing.Size(225, 21)
        Me.txtSHIPPERSEXPORTELSECUSTOMSCODE.TabIndex = 16
        '
        'lblSHIPPERSEXPORTELSEADDRESS
        '
        Me.lblSHIPPERSEXPORTELSEADDRESS.AutoSize = True
        Me.lblSHIPPERSEXPORTELSEADDRESS.Location = New System.Drawing.Point(29, 127)
        Me.lblSHIPPERSEXPORTELSEADDRESS.Name = "lblSHIPPERSEXPORTELSEADDRESS"
        Me.lblSHIPPERSEXPORTELSEADDRESS.Size = New System.Drawing.Size(73, 12)
        Me.lblSHIPPERSEXPORTELSEADDRESS.TabIndex = 17
        Me.lblSHIPPERSEXPORTELSEADDRESS.Text = "신고자주소 :"
        '
        'txtSHIPPERSEXPORTELSEPOSTALCODE
        '
        Me.txtSHIPPERSEXPORTELSEPOSTALCODE.Location = New System.Drawing.Point(104, 99)
        Me.txtSHIPPERSEXPORTELSEPOSTALCODE.Mask = "00000"
        Me.txtSHIPPERSEXPORTELSEPOSTALCODE.Name = "txtSHIPPERSEXPORTELSEPOSTALCODE"
        Me.txtSHIPPERSEXPORTELSEPOSTALCODE.Size = New System.Drawing.Size(100, 21)
        Me.txtSHIPPERSEXPORTELSEPOSTALCODE.TabIndex = 14
        '
        'txtSHIPPERSEXPORTELSEADDRESS
        '
        Me.txtSHIPPERSEXPORTELSEADDRESS.Location = New System.Drawing.Point(104, 124)
        Me.txtSHIPPERSEXPORTELSEADDRESS.Name = "txtSHIPPERSEXPORTELSEADDRESS"
        Me.txtSHIPPERSEXPORTELSEADDRESS.Size = New System.Drawing.Size(225, 21)
        Me.txtSHIPPERSEXPORTELSEADDRESS.TabIndex = 15
        '
        'lblSHIPPERSEXPORTELSEPOSTALCODE
        '
        Me.lblSHIPPERSEXPORTELSEPOSTALCODE.AutoSize = True
        Me.lblSHIPPERSEXPORTELSEPOSTALCODE.Location = New System.Drawing.Point(5, 104)
        Me.lblSHIPPERSEXPORTELSEPOSTALCODE.Name = "lblSHIPPERSEXPORTELSEPOSTALCODE"
        Me.lblSHIPPERSEXPORTELSEPOSTALCODE.Size = New System.Drawing.Size(97, 12)
        Me.lblSHIPPERSEXPORTELSEPOSTALCODE.TabIndex = 13
        Me.lblSHIPPERSEXPORTELSEPOSTALCODE.Text = "신고자우편번호 :"
        '
        'txtSHIPPERSEXPORTELSEPRESENTER
        '
        Me.txtSHIPPERSEXPORTELSEPRESENTER.Location = New System.Drawing.Point(104, 73)
        Me.txtSHIPPERSEXPORTELSEPRESENTER.Name = "txtSHIPPERSEXPORTELSEPRESENTER"
        Me.txtSHIPPERSEXPORTELSEPRESENTER.Size = New System.Drawing.Size(225, 21)
        Me.txtSHIPPERSEXPORTELSEPRESENTER.TabIndex = 13
        '
        'lblSHIPPERSEXPORTELSEPRESENTER
        '
        Me.lblSHIPPERSEXPORTELSEPRESENTER.AutoSize = True
        Me.lblSHIPPERSEXPORTELSEPRESENTER.Location = New System.Drawing.Point(17, 77)
        Me.lblSHIPPERSEXPORTELSEPRESENTER.Name = "lblSHIPPERSEXPORTELSEPRESENTER"
        Me.lblSHIPPERSEXPORTELSEPRESENTER.Size = New System.Drawing.Size(85, 12)
        Me.lblSHIPPERSEXPORTELSEPRESENTER.TabIndex = 11
        Me.lblSHIPPERSEXPORTELSEPRESENTER.Text = "신고자대표자 :"
        '
        'txtSHIPPERSEXPORTELSENAME
        '
        Me.txtSHIPPERSEXPORTELSENAME.Location = New System.Drawing.Point(104, 46)
        Me.txtSHIPPERSEXPORTELSENAME.Name = "txtSHIPPERSEXPORTELSENAME"
        Me.txtSHIPPERSEXPORTELSENAME.Size = New System.Drawing.Size(225, 21)
        Me.txtSHIPPERSEXPORTELSENAME.TabIndex = 12
        '
        'lblSHIPPERSEXPORTELSECODE
        '
        Me.lblSHIPPERSEXPORTELSECODE.AutoSize = True
        Me.lblSHIPPERSEXPORTELSECODE.Location = New System.Drawing.Point(24, 23)
        Me.lblSHIPPERSEXPORTELSECODE.Name = "lblSHIPPERSEXPORTELSECODE"
        Me.lblSHIPPERSEXPORTELSECODE.Size = New System.Drawing.Size(77, 12)
        Me.lblSHIPPERSEXPORTELSECODE.TabIndex = 9
        Me.lblSHIPPERSEXPORTELSECODE.Text = "신고자 부호 :"
        '
        'txtSHIPPERSEXPORTELSECODE
        '
        Me.txtSHIPPERSEXPORTELSECODE.Location = New System.Drawing.Point(104, 20)
        Me.txtSHIPPERSEXPORTELSECODE.MaxLength = 13
        Me.txtSHIPPERSEXPORTELSECODE.Name = "txtSHIPPERSEXPORTELSECODE"
        Me.txtSHIPPERSEXPORTELSECODE.Size = New System.Drawing.Size(100, 21)
        Me.txtSHIPPERSEXPORTELSECODE.TabIndex = 11
        '
        'lblSHIPPERSEXPORTELSENAME
        '
        Me.lblSHIPPERSEXPORTELSENAME.AutoSize = True
        Me.lblSHIPPERSEXPORTELSENAME.Location = New System.Drawing.Point(25, 50)
        Me.lblSHIPPERSEXPORTELSENAME.Name = "lblSHIPPERSEXPORTELSENAME"
        Me.lblSHIPPERSEXPORTELSENAME.Size = New System.Drawing.Size(77, 12)
        Me.lblSHIPPERSEXPORTELSENAME.TabIndex = 7
        Me.lblSHIPPERSEXPORTELSENAME.Text = "신고자 상호 :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ChkFileOutFlag)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.txtDataKeepDays)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Location = New System.Drawing.Point(9, 44)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(338, 62)
        Me.GroupBox4.TabIndex = 21
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "일반"
        '
        'ChkFileOutFlag
        '
        Me.ChkFileOutFlag.AutoSize = True
        Me.ChkFileOutFlag.Location = New System.Drawing.Point(99, 40)
        Me.ChkFileOutFlag.Name = "ChkFileOutFlag"
        Me.ChkFileOutFlag.Size = New System.Drawing.Size(236, 16)
        Me.ChkFileOutFlag.TabIndex = 5
        Me.ChkFileOutFlag.Text = "파일 출력하지 않은 데이타를 삭제 않함"
        Me.ChkFileOutFlag.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(256, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "일 뒤 삭제"
        '
        'txtDataKeepDays
        '
        Me.txtDataKeepDays.Location = New System.Drawing.Point(203, 14)
        Me.txtDataKeepDays.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.txtDataKeepDays.Name = "txtDataKeepDays"
        Me.txtDataKeepDays.Size = New System.Drawing.Size(47, 21)
        Me.txtDataKeepDays.TabIndex = 1
        Me.txtDataKeepDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(201, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "테이타 보존기간 : 데이타 임포트 후 "
        '
        'btnClose
        '
        Me.btnClose.ColorTable = Office2010Blue1
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.Location = New System.Drawing.Point(613, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 18
        Me.btnClose.Text = "종료"
        Me.btnClose.Theme = DainUtil.ManiX.Theme.MSOffice2010_BLUE
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'FrmGenEnv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(695, 447)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmGenEnv"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "환경설정"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.txtDataKeepDays, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtReporterName As TextBox
    Friend WithEvents lblReporterCode As Label
    Friend WithEvents txtReporterCode As TextBox
    Friend WithEvents lblReporter As Label
    Friend WithEvents btnUpdate As ManiX.XButton
    Friend WithEvents txtReportPresenter As TextBox
    Friend WithEvents lblReportPresenter As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtSHIPPERSEXPORT1PRESENTER As TextBox
    Friend WithEvents lblSHIPPERSEXPORT1PRESENTER As Label
    Friend WithEvents txtSHIPPERSEXPORT1NAME As TextBox
    Friend WithEvents lblSHIPPERSEXPORT1CODE As Label
    Friend WithEvents txtSHIPPERSEXPORT1CODE As TextBox
    Friend WithEvents lblSHIPPERSEXPORT1NAME As Label
    Friend WithEvents lblReportSeqNo As Label
    Friend WithEvents txtReportSeqNo As TextBox
    Friend WithEvents lblSHIPPERSEXPORT1CUSTOMSCODE As Label
    Friend WithEvents txtSHIPPERSEXPORT1CUSTOMSCODE As TextBox
    Friend WithEvents lblSHIPPERSEXPORT1ADDRESS As Label
    Friend WithEvents txtSHIPPERSEXPORT1POSTALCODE As MaskedTextBox
    Friend WithEvents txtSHIPPERSEXPORT1ADDRESS As TextBox
    Friend WithEvents lblSHIPPERSEXPORT1POSTALCODE As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lblSHIPPERSEXPORTELSECUSTOMSCODE As Label
    Friend WithEvents txtSHIPPERSEXPORTELSECUSTOMSCODE As TextBox
    Friend WithEvents lblSHIPPERSEXPORTELSEADDRESS As Label
    Friend WithEvents txtSHIPPERSEXPORTELSEPOSTALCODE As MaskedTextBox
    Friend WithEvents txtSHIPPERSEXPORTELSEADDRESS As TextBox
    Friend WithEvents lblSHIPPERSEXPORTELSEPOSTALCODE As Label
    Friend WithEvents txtSHIPPERSEXPORTELSEPRESENTER As TextBox
    Friend WithEvents lblSHIPPERSEXPORTELSEPRESENTER As Label
    Friend WithEvents txtSHIPPERSEXPORTELSENAME As TextBox
    Friend WithEvents lblSHIPPERSEXPORTELSECODE As Label
    Friend WithEvents txtSHIPPERSEXPORTELSECODE As TextBox
    Friend WithEvents lblSHIPPERSEXPORTELSENAME As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btnClose As ManiX.XButton
    Friend WithEvents txtDataKeepDays As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ChkFileOutFlag As CheckBox
End Class
