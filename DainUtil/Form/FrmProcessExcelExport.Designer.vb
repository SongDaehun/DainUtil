<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProcessItemExport
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
        Me.lblPercent = New System.Windows.Forms.Label()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnClose = New DainUtil.ManiX.XButton()
        Me.SuspendLayout()
        '
        'lblPercent
        '
        Me.lblPercent.AutoSize = True
        Me.lblPercent.Location = New System.Drawing.Point(364, 32)
        Me.lblPercent.Name = "lblPercent"
        Me.lblPercent.Size = New System.Drawing.Size(21, 12)
        Me.lblPercent.TabIndex = 11
        Me.lblPercent.Text = "0%"
        '
        'txtLog
        '
        Me.txtLog.Location = New System.Drawing.Point(11, 48)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLog.Size = New System.Drawing.Size(377, 200)
        Me.txtLog.TabIndex = 10
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(11, 12)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(377, 17)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 9
        '
        'btnClose
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
        Me.btnClose.ColorTable = Office2010Blue1
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.Location = New System.Drawing.Point(310, 254)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 12
        Me.btnClose.Text = "닫기"
        Me.btnClose.Theme = DainUtil.ManiX.Theme.MSOffice2010_BLUE
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'FrmProcessItemExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 285)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblPercent)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.ProgressBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmProcessItemExport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FrmProcessExport"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnClose As ManiX.XButton
    Friend WithEvents lblPercent As Label
    Friend WithEvents txtLog As TextBox
    Friend WithEvents ProgressBar1 As ProgressBar
End Class
