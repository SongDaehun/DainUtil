<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
        Dim Office2010Yellow1 As DainUtil.ManiX.Office2010Yellow = New DainUtil.ManiX.Office2010Yellow()
        Dim Office2010Green1 As DainUtil.ManiX.Office2010Green = New DainUtil.ManiX.Office2010Green()
        Me.GrpExport = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GrpImport = New System.Windows.Forms.GroupBox()
        Me.XButton3 = New DainUtil.ManiX.XButton()
        Me.XButton2 = New DainUtil.ManiX.XButton()
        Me.XButton1 = New DainUtil.ManiX.XButton()
        Me.btnItemMaster = New DainUtil.ManiX.XButton()
        Me.btnStandardMaster = New DainUtil.ManiX.XButton()
        Me.btnGenEnv = New DainUtil.ManiX.XButton()
        Me.btnInvoice = New DainUtil.ManiX.XButton()
        Me.btnExcelImport = New DainUtil.ManiX.XButton()
        Me.btnTextOutput = New DainUtil.ManiX.XButton()
        Me.btnCustom = New DainUtil.ManiX.XButton()
        Me.GrpExport.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GrpImport.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpExport
        '
        Me.GrpExport.Controls.Add(Me.btnInvoice)
        Me.GrpExport.Controls.Add(Me.btnExcelImport)
        Me.GrpExport.Controls.Add(Me.btnTextOutput)
        Me.GrpExport.Location = New System.Drawing.Point(12, 12)
        Me.GrpExport.Name = "GrpExport"
        Me.GrpExport.Size = New System.Drawing.Size(140, 125)
        Me.GrpExport.TabIndex = 4
        Me.GrpExport.TabStop = False
        Me.GrpExport.Text = "수출"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnCustom)
        Me.GroupBox2.Controls.Add(Me.btnItemMaster)
        Me.GroupBox2.Controls.Add(Me.btnStandardMaster)
        Me.GroupBox2.Controls.Add(Me.btnGenEnv)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 158)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(286, 99)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "설정"
        '
        'GrpImport
        '
        Me.GrpImport.Controls.Add(Me.XButton3)
        Me.GrpImport.Controls.Add(Me.XButton2)
        Me.GrpImport.Controls.Add(Me.XButton1)
        Me.GrpImport.Enabled = False
        Me.GrpImport.Location = New System.Drawing.Point(158, 12)
        Me.GrpImport.Name = "GrpImport"
        Me.GrpImport.Size = New System.Drawing.Size(140, 125)
        Me.GrpImport.TabIndex = 6
        Me.GrpImport.TabStop = False
        Me.GrpImport.Text = "수입"
        '
        'XButton3
        '
        Me.XButton3.ColorTable = Office2010Yellow1
        Me.XButton3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.XButton3.Location = New System.Drawing.Point(75, 84)
        Me.XButton3.Name = "XButton3"
        Me.XButton3.Size = New System.Drawing.Size(59, 23)
        Me.XButton3.TabIndex = 3
        Me.XButton3.Text = "▼Output"
        Me.XButton3.Theme = DainUtil.ManiX.Theme.MSOffice2010_Yellow
        Me.XButton3.UseVisualStyleBackColor = True
        '
        'XButton2
        '
        Me.XButton2.ColorTable = Office2010Yellow1
        Me.XButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.XButton2.Location = New System.Drawing.Point(6, 84)
        Me.XButton2.Name = "XButton2"
        Me.XButton2.Size = New System.Drawing.Size(57, 23)
        Me.XButton2.TabIndex = 3
        Me.XButton2.Text = "▲Import"
        Me.XButton2.Theme = DainUtil.ManiX.Theme.MSOffice2010_Yellow
        Me.XButton2.UseVisualStyleBackColor = True
        '
        'XButton1
        '
        Me.XButton1.ColorTable = Office2010Blue1
        Me.XButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.XButton1.Location = New System.Drawing.Point(6, 18)
        Me.XButton1.Name = "XButton1"
        Me.XButton1.Size = New System.Drawing.Size(123, 58)
        Me.XButton1.TabIndex = 1
        Me.XButton1.Text = "Invoice/Packinglist"
        Me.XButton1.Theme = DainUtil.ManiX.Theme.MSOffice2010_BLUE
        Me.XButton1.UseVisualStyleBackColor = True
        '
        'btnItemMaster
        '
        Me.btnItemMaster.ColorTable = Office2010Green1
        Me.btnItemMaster.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnItemMaster.Location = New System.Drawing.Point(152, 20)
        Me.btnItemMaster.Name = "btnItemMaster"
        Me.btnItemMaster.Size = New System.Drawing.Size(123, 28)
        Me.btnItemMaster.TabIndex = 5
        Me.btnItemMaster.Text = "상품마스터"
        Me.btnItemMaster.Theme = DainUtil.ManiX.Theme.MSOffice2010_Green
        Me.btnItemMaster.UseVisualStyleBackColor = True
        '
        'btnStandardMaster
        '
        Me.btnStandardMaster.ColorTable = Office2010Green1
        Me.btnStandardMaster.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStandardMaster.Location = New System.Drawing.Point(6, 54)
        Me.btnStandardMaster.Name = "btnStandardMaster"
        Me.btnStandardMaster.Size = New System.Drawing.Size(123, 28)
        Me.btnStandardMaster.TabIndex = 4
        Me.btnStandardMaster.Text = "표준마스터"
        Me.btnStandardMaster.Theme = DainUtil.ManiX.Theme.MSOffice2010_Green
        Me.btnStandardMaster.UseVisualStyleBackColor = True
        '
        'btnGenEnv
        '
        Me.btnGenEnv.ColorTable = Office2010Green1
        Me.btnGenEnv.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGenEnv.Location = New System.Drawing.Point(6, 20)
        Me.btnGenEnv.Name = "btnGenEnv"
        Me.btnGenEnv.Size = New System.Drawing.Size(123, 28)
        Me.btnGenEnv.TabIndex = 3
        Me.btnGenEnv.Text = "환경설정"
        Me.btnGenEnv.Theme = DainUtil.ManiX.Theme.MSOffice2010_Green
        Me.btnGenEnv.UseVisualStyleBackColor = True
        '
        'btnInvoice
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
        Me.btnInvoice.ColorTable = Office2010Blue1
        Me.btnInvoice.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnInvoice.Location = New System.Drawing.Point(6, 20)
        Me.btnInvoice.Name = "btnInvoice"
        Me.btnInvoice.Size = New System.Drawing.Size(123, 58)
        Me.btnInvoice.TabIndex = 0
        Me.btnInvoice.Text = "Invoice/Packinglist"
        Me.btnInvoice.Theme = DainUtil.ManiX.Theme.MSOffice2010_BLUE
        Me.btnInvoice.UseVisualStyleBackColor = True
        '
        'btnExcelImport
        '
        Office2010Yellow1.BorderColor1 = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(161, Byte), Integer))
        Office2010Yellow1.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(228, Byte), Integer))
        Office2010Yellow1.ButtonMouseOverColor1 = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(87, Byte), Integer))
        Office2010Yellow1.ButtonMouseOverColor2 = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(215, Byte), Integer))
        Office2010Yellow1.ButtonMouseOverColor3 = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(137, Byte), Integer))
        Office2010Yellow1.ButtonMouseOverColor4 = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(224, Byte), Integer))
        Office2010Yellow1.ButtonNormalColor1 = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(8, Byte), Integer))
        Office2010Yellow1.ButtonNormalColor2 = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(45, Byte), Integer))
        Office2010Yellow1.ButtonNormalColor3 = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(8, Byte), Integer))
        Office2010Yellow1.ButtonNormalColor4 = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(45, Byte), Integer))
        Office2010Yellow1.ButtonSelectedColor1 = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(87, Byte), Integer))
        Office2010Yellow1.ButtonSelectedColor2 = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(215, Byte), Integer))
        Office2010Yellow1.ButtonSelectedColor3 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(117, Byte), Integer))
        Office2010Yellow1.ButtonSelectedColor4 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(107, Byte), Integer))
        Office2010Yellow1.HoverTextColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Office2010Yellow1.SelectedTextColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Office2010Yellow1.TextColor = System.Drawing.Color.White
        Me.btnExcelImport.ColorTable = Office2010Yellow1
        Me.btnExcelImport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExcelImport.Location = New System.Drawing.Point(6, 84)
        Me.btnExcelImport.Name = "btnExcelImport"
        Me.btnExcelImport.Size = New System.Drawing.Size(57, 23)
        Me.btnExcelImport.TabIndex = 1
        Me.btnExcelImport.Text = "▲Import"
        Me.btnExcelImport.Theme = DainUtil.ManiX.Theme.MSOffice2010_Yellow
        Me.btnExcelImport.UseVisualStyleBackColor = True
        '
        'btnTextOutput
        '
        Me.btnTextOutput.ColorTable = Office2010Yellow1
        Me.btnTextOutput.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTextOutput.Location = New System.Drawing.Point(70, 84)
        Me.btnTextOutput.Name = "btnTextOutput"
        Me.btnTextOutput.Size = New System.Drawing.Size(59, 23)
        Me.btnTextOutput.TabIndex = 2
        Me.btnTextOutput.Text = "▼Output"
        Me.btnTextOutput.Theme = DainUtil.ManiX.Theme.MSOffice2010_Yellow
        Me.btnTextOutput.UseVisualStyleBackColor = True
        '
        'btnCustom
        '
        Office2010Green1.BorderColor1 = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(161, Byte), Integer))
        Office2010Green1.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(228, Byte), Integer))
        Office2010Green1.ButtonMouseOverColor1 = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(87, Byte), Integer))
        Office2010Green1.ButtonMouseOverColor2 = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(215, Byte), Integer))
        Office2010Green1.ButtonMouseOverColor3 = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(137, Byte), Integer))
        Office2010Green1.ButtonMouseOverColor4 = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(224, Byte), Integer))
        Office2010Green1.ButtonNormalColor1 = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(43, Byte), Integer))
        Office2010Green1.ButtonNormalColor2 = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(67, Byte), Integer))
        Office2010Green1.ButtonNormalColor3 = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(43, Byte), Integer))
        Office2010Green1.ButtonNormalColor4 = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(67, Byte), Integer))
        Office2010Green1.ButtonSelectedColor1 = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(87, Byte), Integer))
        Office2010Green1.ButtonSelectedColor2 = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(215, Byte), Integer))
        Office2010Green1.ButtonSelectedColor3 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(117, Byte), Integer))
        Office2010Green1.ButtonSelectedColor4 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(107, Byte), Integer))
        Office2010Green1.HoverTextColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Office2010Green1.SelectedTextColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(91, Byte), Integer))
        Office2010Green1.TextColor = System.Drawing.Color.White
        Me.btnCustom.ColorTable = Office2010Green1
        Me.btnCustom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCustom.Location = New System.Drawing.Point(152, 54)
        Me.btnCustom.Name = "btnCustom"
        Me.btnCustom.Size = New System.Drawing.Size(123, 28)
        Me.btnCustom.TabIndex = 6
        Me.btnCustom.Text = "커스텀마스터"
        Me.btnCustom.Theme = DainUtil.ManiX.Theme.MSOffice2010_Green
        Me.btnCustom.UseVisualStyleBackColor = True
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(308, 270)
        Me.Controls.Add(Me.GrpImport)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GrpExport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMain"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.GrpExport.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GrpImport.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnInvoice As ManiX.XButton
    Friend WithEvents btnExcelImport As ManiX.XButton
    Friend WithEvents btnTextOutput As ManiX.XButton
    Friend WithEvents btnGenEnv As ManiX.XButton
    Friend WithEvents GrpExport As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnItemMaster As ManiX.XButton
    Friend WithEvents btnStandardMaster As ManiX.XButton
    Friend WithEvents GrpImport As GroupBox
    Friend WithEvents XButton3 As ManiX.XButton
    Friend WithEvents XButton2 As ManiX.XButton
    Friend WithEvents XButton1 As ManiX.XButton
    Friend WithEvents btnCustom As ManiX.XButton
End Class
