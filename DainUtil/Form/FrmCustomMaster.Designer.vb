<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCustomMaster
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
        Dim Office2010Blue1 As DainUtil.ManiX.Office2010Blue = New DainUtil.ManiX.Office2010Blue()
        Me.cmbStandard = New System.Windows.Forms.ComboBox()
        Me.lblMasterCombo = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnDelete = New DainUtil.ManiX.XButton()
        Me.btnClose = New DainUtil.ManiX.XButton()
        Me.btnUpdate = New DainUtil.ManiX.XButton()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbStandard
        '
        Me.cmbStandard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStandard.FormattingEnabled = True
        Me.cmbStandard.Location = New System.Drawing.Point(90, 16)
        Me.cmbStandard.Name = "cmbStandard"
        Me.cmbStandard.Size = New System.Drawing.Size(296, 20)
        Me.cmbStandard.TabIndex = 0
        '
        'lblMasterCombo
        '
        Me.lblMasterCombo.AutoSize = True
        Me.lblMasterCombo.Location = New System.Drawing.Point(13, 20)
        Me.lblMasterCombo.Name = "lblMasterCombo"
        Me.lblMasterCombo.Size = New System.Drawing.Size(73, 12)
        Me.lblMasterCombo.TabIndex = 1
        Me.lblMasterCombo.Text = "커스텀코드 :"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 48)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(760, 501)
        Me.DataGridView1.TabIndex = 2
        '
        'btnDelete
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
        Me.btnDelete.ColorTable = Office2010Blue1
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Location = New System.Drawing.Point(616, 9)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "삭제"
        Me.btnDelete.Theme = DainUtil.ManiX.Theme.MSOffice2010_BLUE
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.ColorTable = Office2010Blue1
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.Location = New System.Drawing.Point(697, 9)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "종료"
        Me.btnClose.Theme = DainUtil.ManiX.Theme.MSOffice2010_BLUE
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.ColorTable = Office2010Blue1
        Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdate.Location = New System.Drawing.Point(535, 9)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 3
        Me.btnUpdate.Text = "갱신"
        Me.btnUpdate.Theme = DainUtil.ManiX.Theme.MSOffice2010_BLUE
        Me.btnUpdate.UseVisualStyleBackColor = True
        Me.btnUpdate.Visible = False
        '
        'FrmCustomMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.lblMasterCombo)
        Me.Controls.Add(Me.cmbStandard)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCustomMaster"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "커스텀마스터"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbStandard As ComboBox
    Friend WithEvents lblMasterCombo As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents btnUpdate As ManiX.XButton
    Friend WithEvents btnClose As ManiX.XButton
    Friend WithEvents btnDelete As ManiX.XButton
End Class
