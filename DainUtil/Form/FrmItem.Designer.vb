<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmItem
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
        Dim Office2010Yellow1 As DainUtil.ManiX.Office2010Yellow = New DainUtil.ManiX.Office2010Yellow()
        Dim Office2010Blue1 As DainUtil.ManiX.Office2010Blue = New DainUtil.ManiX.Office2010Blue()
        Dim Office2010Green1 As DainUtil.ManiX.Office2010Green = New DainUtil.ManiX.Office2010Green()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSearch103 = New System.Windows.Forms.TextBox()
        Me.txtSearch102 = New System.Windows.Forms.TextBox()
        Me.txtSearch101 = New System.Windows.Forms.TextBox()
        Me.cmbSearch103 = New System.Windows.Forms.ComboBox()
        Me.cmbSearch102 = New System.Windows.Forms.ComboBox()
        Me.cmbSearch101 = New System.Windows.Forms.ComboBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.btnExcelImport = New DainUtil.ManiX.XButton()
        Me.btnExcelout = New DainUtil.ManiX.XButton()
        Me.btnDelete = New DainUtil.ManiX.XButton()
        Me.btnUpdate = New DainUtil.ManiX.XButton()
        Me.btnClose = New DainUtil.ManiX.XButton()
        Me.btnSearch = New DainUtil.ManiX.XButton()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 118)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(957, 339)
        Me.DataGridView1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.txtSearch103)
        Me.GroupBox1.Controls.Add(Me.txtSearch102)
        Me.GroupBox1.Controls.Add(Me.txtSearch101)
        Me.GroupBox1.Controls.Add(Me.cmbSearch103)
        Me.GroupBox1.Controls.Add(Me.cmbSearch102)
        Me.GroupBox1.Controls.Add(Me.cmbSearch101)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(429, 100)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "검색조건"
        '
        'txtSearch103
        '
        Me.txtSearch103.Location = New System.Drawing.Point(134, 73)
        Me.txtSearch103.MaxLength = 255
        Me.txtSearch103.Name = "txtSearch103"
        Me.txtSearch103.Size = New System.Drawing.Size(226, 21)
        Me.txtSearch103.TabIndex = 5
        '
        'txtSearch102
        '
        Me.txtSearch102.Location = New System.Drawing.Point(134, 48)
        Me.txtSearch102.MaxLength = 255
        Me.txtSearch102.Name = "txtSearch102"
        Me.txtSearch102.Size = New System.Drawing.Size(226, 21)
        Me.txtSearch102.TabIndex = 4
        '
        'txtSearch101
        '
        Me.txtSearch101.Location = New System.Drawing.Point(135, 21)
        Me.txtSearch101.MaxLength = 255
        Me.txtSearch101.Name = "txtSearch101"
        Me.txtSearch101.Size = New System.Drawing.Size(226, 21)
        Me.txtSearch101.TabIndex = 3
        '
        'cmbSearch103
        '
        Me.cmbSearch103.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearch103.FormattingEnabled = True
        Me.cmbSearch103.Location = New System.Drawing.Point(7, 73)
        Me.cmbSearch103.Name = "cmbSearch103"
        Me.cmbSearch103.Size = New System.Drawing.Size(121, 20)
        Me.cmbSearch103.TabIndex = 2
        '
        'cmbSearch102
        '
        Me.cmbSearch102.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearch102.FormattingEnabled = True
        Me.cmbSearch102.Location = New System.Drawing.Point(7, 47)
        Me.cmbSearch102.Name = "cmbSearch102"
        Me.cmbSearch102.Size = New System.Drawing.Size(121, 20)
        Me.cmbSearch102.TabIndex = 1
        '
        'cmbSearch101
        '
        Me.cmbSearch101.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearch101.FormattingEnabled = True
        Me.cmbSearch101.Location = New System.Drawing.Point(7, 21)
        Me.cmbSearch101.Name = "cmbSearch101"
        Me.cmbSearch101.Size = New System.Drawing.Size(121, 20)
        Me.cmbSearch101.TabIndex = 0
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnExcelImport
        '
        Me.btnExcelImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.btnExcelImport.Location = New System.Drawing.Point(545, 12)
        Me.btnExcelImport.Name = "btnExcelImport"
        Me.btnExcelImport.Size = New System.Drawing.Size(75, 23)
        Me.btnExcelImport.TabIndex = 9
        Me.btnExcelImport.Text = "엑셀임포트"
        Me.btnExcelImport.Theme = DainUtil.ManiX.Theme.MSOffice2010_Yellow
        Me.btnExcelImport.UseVisualStyleBackColor = True
        '
        'btnExcelout
        '
        Me.btnExcelout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcelout.ColorTable = Office2010Yellow1
        Me.btnExcelout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExcelout.Location = New System.Drawing.Point(464, 12)
        Me.btnExcelout.Name = "btnExcelout"
        Me.btnExcelout.Size = New System.Drawing.Size(75, 23)
        Me.btnExcelout.TabIndex = 8
        Me.btnExcelout.Text = "엑셀출력"
        Me.btnExcelout.Theme = DainUtil.ManiX.Theme.MSOffice2010_Yellow
        Me.btnExcelout.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.btnDelete.ColorTable = Office2010Blue1
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Location = New System.Drawing.Point(813, 12)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 7
        Me.btnDelete.Text = "삭제"
        Me.btnDelete.Theme = DainUtil.ManiX.Theme.MSOffice2010_BLUE
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdate.ColorTable = Office2010Blue1
        Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdate.Location = New System.Drawing.Point(732, 12)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 6
        Me.btnUpdate.Text = "저장"
        Me.btnUpdate.Theme = DainUtil.ManiX.Theme.MSOffice2010_BLUE
        Me.btnUpdate.UseVisualStyleBackColor = True
        Me.btnUpdate.Visible = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.ColorTable = Office2010Blue1
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.Location = New System.Drawing.Point(894, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "종료"
        Me.btnClose.Theme = DainUtil.ManiX.Theme.MSOffice2010_BLUE
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSearch
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
        Me.btnSearch.ColorTable = Office2010Green1
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.Location = New System.Drawing.Point(368, 18)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(55, 75)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "검색"
        Me.btnSearch.Theme = DainUtil.ManiX.Theme.MSOffice2010_Green
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'FrmItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(981, 469)
        Me.Controls.Add(Me.btnExcelImport)
        Me.Controls.Add(Me.btnExcelout)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.MinimumSize = New System.Drawing.Size(990, 490)
        Me.Name = "FrmItem"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "상품마스터"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnSearch As ManiX.XButton
    Friend WithEvents txtSearch103 As TextBox
    Friend WithEvents txtSearch102 As TextBox
    Friend WithEvents txtSearch101 As TextBox
    Friend WithEvents cmbSearch103 As ComboBox
    Friend WithEvents cmbSearch102 As ComboBox
    Friend WithEvents cmbSearch101 As ComboBox
    Friend WithEvents btnDelete As ManiX.XButton
    Friend WithEvents btnUpdate As ManiX.XButton
    Friend WithEvents btnClose As ManiX.XButton
    Friend WithEvents btnExcelout As ManiX.XButton
    Friend WithEvents btnExcelImport As ManiX.XButton
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
