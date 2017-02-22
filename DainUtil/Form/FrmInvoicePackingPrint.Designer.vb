<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInvoicePackingPrint
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
        Me.rdbCIPLlist = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbSearch103 = New System.Windows.Forms.ComboBox()
        Me.cmbSearch102 = New System.Windows.Forms.ComboBox()
        Me.cmbSearch101 = New System.Windows.Forms.ComboBox()
        Me.txtSearch103 = New System.Windows.Forms.TextBox()
        Me.txtSearch102 = New System.Windows.Forms.TextBox()
        Me.txtSearch101 = New System.Windows.Forms.TextBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.btnPrint = New DainUtil.ManiX.XButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdbCIPLlist)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 26)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(324, 100)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "레포트 종류"
        '
        'rdbCIPLlist
        '
        Me.rdbCIPLlist.AutoSize = True
        Me.rdbCIPLlist.Location = New System.Drawing.Point(16, 21)
        Me.rdbCIPLlist.Name = "rdbCIPLlist"
        Me.rdbCIPLlist.Size = New System.Drawing.Size(156, 16)
        Me.rdbCIPLlist.TabIndex = 0
        Me.rdbCIPLlist.TabStop = True
        Me.rdbCIPLlist.Text = "CI & PL 리트스(엑셀형식)"
        Me.rdbCIPLlist.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbSearch103)
        Me.GroupBox2.Controls.Add(Me.cmbSearch102)
        Me.GroupBox2.Controls.Add(Me.cmbSearch101)
        Me.GroupBox2.Controls.Add(Me.txtSearch103)
        Me.GroupBox2.Controls.Add(Me.txtSearch102)
        Me.GroupBox2.Controls.Add(Me.txtSearch101)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 133)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(324, 100)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "출력조건"
        '
        'cmbSearch103
        '
        Me.cmbSearch103.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearch103.FormattingEnabled = True
        Me.cmbSearch103.Location = New System.Drawing.Point(7, 74)
        Me.cmbSearch103.Name = "cmbSearch103"
        Me.cmbSearch103.Size = New System.Drawing.Size(121, 20)
        Me.cmbSearch103.TabIndex = 11
        '
        'cmbSearch102
        '
        Me.cmbSearch102.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearch102.FormattingEnabled = True
        Me.cmbSearch102.Location = New System.Drawing.Point(7, 48)
        Me.cmbSearch102.Name = "cmbSearch102"
        Me.cmbSearch102.Size = New System.Drawing.Size(121, 20)
        Me.cmbSearch102.TabIndex = 10
        '
        'cmbSearch101
        '
        Me.cmbSearch101.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearch101.FormattingEnabled = True
        Me.cmbSearch101.Location = New System.Drawing.Point(7, 22)
        Me.cmbSearch101.Name = "cmbSearch101"
        Me.cmbSearch101.Size = New System.Drawing.Size(121, 20)
        Me.cmbSearch101.TabIndex = 9
        '
        'txtSearch103
        '
        Me.txtSearch103.Location = New System.Drawing.Point(133, 73)
        Me.txtSearch103.MaxLength = 255
        Me.txtSearch103.Name = "txtSearch103"
        Me.txtSearch103.Size = New System.Drawing.Size(184, 21)
        Me.txtSearch103.TabIndex = 8
        '
        'txtSearch102
        '
        Me.txtSearch102.Location = New System.Drawing.Point(133, 48)
        Me.txtSearch102.MaxLength = 255
        Me.txtSearch102.Name = "txtSearch102"
        Me.txtSearch102.Size = New System.Drawing.Size(184, 21)
        Me.txtSearch102.TabIndex = 7
        '
        'txtSearch101
        '
        Me.txtSearch101.Location = New System.Drawing.Point(134, 21)
        Me.txtSearch101.MaxLength = 255
        Me.txtSearch101.Name = "txtSearch101"
        Me.txtSearch101.Size = New System.Drawing.Size(184, 21)
        Me.txtSearch101.TabIndex = 6
        '
        'btnPrint
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
        Me.btnPrint.ColorTable = Office2010Blue1
        Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrint.Location = New System.Drawing.Point(262, 5)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 4
        Me.btnPrint.Text = "출력"
        Me.btnPrint.Theme = DainUtil.ManiX.Theme.MSOffice2010_BLUE
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'FrmInvoicePackingPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(349, 247)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmInvoicePackingPrint"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "레포트 출력"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rdbCIPLlist As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnPrint As ManiX.XButton
    Friend WithEvents txtSearch103 As TextBox
    Friend WithEvents txtSearch102 As TextBox
    Friend WithEvents txtSearch101 As TextBox
    Friend WithEvents cmbSearch103 As ComboBox
    Friend WithEvents cmbSearch102 As ComboBox
    Friend WithEvents cmbSearch101 As ComboBox
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
