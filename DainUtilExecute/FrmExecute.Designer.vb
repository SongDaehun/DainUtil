<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmExecute
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
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.lblLog = New System.Windows.Forms.Label()
        Me.btnExecute = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtLog
        '
        Me.txtLog.Location = New System.Drawing.Point(13, 52)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLog.Size = New System.Drawing.Size(590, 69)
        Me.txtLog.TabIndex = 0
        '
        'lblLog
        '
        Me.lblLog.AutoSize = True
        Me.lblLog.Location = New System.Drawing.Point(16, 10)
        Me.lblLog.Name = "lblLog"
        Me.lblLog.Size = New System.Drawing.Size(42, 12)
        Me.lblLog.TabIndex = 1
        Me.lblLog.Text = "Label1"
        '
        'btnExecute
        '
        Me.btnExecute.Location = New System.Drawing.Point(471, 127)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(132, 23)
        Me.btnExecute.TabIndex = 2
        Me.btnExecute.Text = "다운로드 및 실행"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'FrmExecute
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 159)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.lblLog)
        Me.Controls.Add(Me.txtLog)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmExecute"
        Me.ShowIcon = False
        Me.Text = "업데이트 확인"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtLog As TextBox
    Friend WithEvents lblLog As Label
    Friend WithEvents btnExecute As Button
End Class
