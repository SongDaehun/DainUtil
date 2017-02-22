
Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Namespace ManiX
    Partial Public Class XButton
        Inherits Button
#Region "Fields"

        Private thm As Theme = Theme.MSOffice2010_BLUE

        Private Enum MouseState
            None = 1
            Down = 2
            Up = 3
            Enter = 4
            Leave = 5
            Move = 6
        End Enum

        Private MState As MouseState = MouseState.None

#End Region

#Region "Constructor"

        Public Sub New()
            ' We gain about 2% in painting by avoiding extra GetWindowText calls
            Me.SetStyle(ControlStyles.SupportsTransparentBackColor Or ControlStyles.Opaque Or ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.CacheText Or ControlStyles.StandardClick, True)

            Me.m_colorTable = New Colortable()

            AddHandler Me.MouseLeave, AddressOf _MouseLeave
            AddHandler Me.MouseDown, AddressOf _MouseDown
            AddHandler Me.MouseUp, AddressOf _MouseUp
            AddHandler Me.MouseMove, AddressOf _MouseMove
        End Sub

#End Region

#Region "Events"

#Region "Paint Transparent Background"

        Protected Sub PaintTransparentBackground(g As Graphics, clipRect As Rectangle)
            ' check if we have a parent
            If Me.Parent IsNot Nothing Then
                ' convert the clipRects coordinates from ours to our parents
                clipRect.Offset(Me.Location)

                Dim e As New PaintEventArgs(g, clipRect)

                ' save the graphics state so that if anything goes wrong 
                ' we're not fubar
                Dim state As GraphicsState = g.Save()

                Try
                    ' move the graphics object so that we are drawing in 
                    ' the correct place
                    g.TranslateTransform(CSng(-Me.Location.X), CSng(-Me.Location.Y))

                    ' draw the parents background and foreground
                    Me.InvokePaintBackground(Me.Parent, e)
                    Me.InvokePaint(Me.Parent, e)

                    Return
                Finally
                    ' reset everything back to where they were before
                    g.Restore(state)
                    clipRect.Offset(-Me.Location.X, -Me.Location.Y)
                End Try
            End If

            ' we don't have a parent, so fill the rect with
            ' the default control color
            g.FillRectangle(SystemBrushes.Control, clipRect)
        End Sub

#End Region

#Region "Mouse Events"

        Private Sub _MouseDown(sender As Object, mevent As MouseEventArgs)
            MState = MouseState.Down
            Invalidate()
        End Sub

        Private Sub _MouseUp(sender As Object, mevent As MouseEventArgs)
            MState = MouseState.Up
            Invalidate()
        End Sub

        Private Sub _MouseMove(sender As Object, mevent As MouseEventArgs)
            MState = MouseState.Move
            Invalidate()
        End Sub

        Private Sub _MouseLeave(sender As Object, e As EventArgs)
            MState = MouseState.Leave
            Invalidate()
        End Sub

#End Region

#Region "Path"

        Public Shared Function GetRoundedRect(r As RectangleF, radius As Single) As GraphicsPath
            Dim gp As New GraphicsPath()
            gp.StartFigure()
            r = New RectangleF(r.Left, r.Top, r.Width, r.Height)
            If radius <= 0F OrElse radius <= 0F Then
                gp.AddRectangle(r)
            Else
                gp.AddArc(CSng(r.X), CSng(r.Y), radius, radius, 180, 90)
                gp.AddArc(CSng(r.Right) - radius, CSng(r.Y), radius - 1, radius, 270, 90)
                gp.AddArc(CSng(r.Right) - radius, CSng(r.Bottom) - radius - 1, radius - 1, radius, 0, 90)
                gp.AddArc(CSng(r.X), CSng(r.Bottom) - radius - 1, radius - 1, radius, 90, 90)
            End If
            gp.CloseFigure()
            Return gp
        End Function

#End Region

#Region "Paint"

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            Me.PaintTransparentBackground(e.Graphics, e.ClipRectangle)

            '#Region "Painting"

            'now let's we begin painting
            Dim g As Graphics = e.Graphics
            g.SmoothingMode = SmoothingMode.HighQuality
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit

            '#End Region

            '#Region "Color"

            Dim tTopColorBegin As Color = Me.m_colorTable.ButtonNormalColor1
            Dim tTopColorEnd As Color = Me.m_colorTable.ButtonNormalColor2
            Dim tBottomColorBegin As Color = Me.m_colorTable.ButtonNormalColor3
            Dim tBottomColorEnd As Color = Me.m_colorTable.ButtonNormalColor4
            Dim Textcol As Color = Me.m_colorTable.TextColor


            If Not Me.Enabled Then
                tTopColorBegin = Color.FromArgb(CInt(tTopColorBegin.GetBrightness() * 255), CInt(tTopColorBegin.GetBrightness() * 255), CInt(tTopColorBegin.GetBrightness() * 255))
                tBottomColorEnd = Color.FromArgb(CInt(tBottomColorEnd.GetBrightness() * 255), CInt(tBottomColorEnd.GetBrightness() * 255), CInt(tBottomColorEnd.GetBrightness() * 255))
            Else
                If MState = MouseState.None OrElse MState = MouseState.Leave Then
                    tTopColorBegin = Me.m_colorTable.ButtonNormalColor1
                    tTopColorEnd = Me.m_colorTable.ButtonNormalColor2
                    tBottomColorBegin = Me.m_colorTable.ButtonNormalColor3
                    tBottomColorEnd = Me.m_colorTable.ButtonNormalColor4
                    Textcol = Me.m_colorTable.TextColor
                ElseIf MState = MouseState.Down Then
                    tTopColorBegin = Me.m_colorTable.ButtonSelectedColor1
                    tTopColorEnd = Me.m_colorTable.ButtonSelectedColor2
                    tBottomColorBegin = Me.m_colorTable.ButtonSelectedColor3
                    tBottomColorEnd = Me.m_colorTable.ButtonSelectedColor4
                    Textcol = Me.m_colorTable.SelectedTextColor
                ElseIf MState = MouseState.Move OrElse MState = MouseState.Up Then
                    tTopColorBegin = Me.m_colorTable.ButtonMouseOverColor1
                    tTopColorEnd = Me.m_colorTable.ButtonMouseOverColor2
                    tBottomColorBegin = Me.m_colorTable.ButtonMouseOverColor3
                    tBottomColorEnd = Me.m_colorTable.ButtonMouseOverColor4
                    Textcol = Me.m_colorTable.HoverTextColor
                End If
            End If


            '#End Region

            '#Region "Theme 2010"

            If thm = Theme.MSOffice2010_BLUE OrElse thm = Theme.MSOffice2010_Green OrElse thm = Theme.MSOffice2010_Yellow OrElse thm = Theme.MSOffice2010_Publisher OrElse thm = Theme.MSOffice2010_RED OrElse thm = Theme.MSOffice2010_WHITE OrElse thm = Theme.MSOffice2010_Pink Then
                Paint2010Background(e, g, tTopColorBegin, tTopColorEnd, tBottomColorBegin, tBottomColorEnd)
                TEXTandIMAGE(e.ClipRectangle, g, Textcol)
            End If

            '#End Region
        End Sub

#End Region

#Region "Paint 2010 Background"

        Protected Sub Paint2010Background(e As PaintEventArgs, g As Graphics, tTopColorBegin As Color, tTopColorEnd As Color, tBottomColorBegin As Color, tBottomColorEnd As Color)
            Dim _roundedRadiusX As Integer = 6

            Dim r As New Rectangle(e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width, e.ClipRectangle.Height)
            Dim j As Rectangle = r
            Dim r2 As Rectangle = r
            r2.Inflate(-1, -1)
            Dim r3 As Rectangle = r2
            r3.Inflate(-1, -1)

            'rectangle for gradient, half upper and lower
            Dim halfup As New RectangleF(r.Left, r.Top, r.Width, r.Height)
            Dim halfdown As New RectangleF(r.Left, r.Top + (r.Height / 2) - 1, r.Width, r.Height)

            'BEGIN PAINT BACKGROUND
            'for half upper, we paint using linear gradient
            Using thePath As GraphicsPath = GetRoundedRect(r, _roundedRadiusX)
                Dim lgb As New LinearGradientBrush(halfup, tBottomColorEnd, tBottomColorBegin, 90.0F, True)

                Dim blend As New Blend(4)
                blend.Positions = New Single() {0, 0.18F, 0.35F, 1.0F}
                blend.Factors = New Single() {0F, 0.4F, 0.9F, 1.0F}
                lgb.Blend = blend
                g.FillPath(lgb, thePath)
                lgb.Dispose()

                'for half lower, we paint using radial gradient
                Using p As New GraphicsPath()
                    p.AddEllipse(halfdown)
                    'make it radial
                    Using gradient As New PathGradientBrush(p)
                        gradient.WrapMode = WrapMode.Clamp
                        gradient.CenterPoint = New PointF(Convert.ToSingle(halfdown.Left + halfdown.Width / 2), Convert.ToSingle(halfdown.Bottom))
                        gradient.CenterColor = tBottomColorEnd
                        gradient.SurroundColors = New Color() {tBottomColorBegin}

                        blend = New Blend(4)
                        blend.Positions = New Single() {0, 0.15F, 0.4F, 1.0F}
                        blend.Factors = New Single() {0F, 0.3F, 1.0F, 1.0F}
                        gradient.Blend = blend

                        g.FillPath(gradient, thePath)
                    End Using
                End Using
                'END PAINT BACKGROUND

                'BEGIN PAINT BORDERS
                Using gborderDark As GraphicsPath = thePath
                    Using p As New Pen(tTopColorBegin, 1)
                        g.DrawPath(p, gborderDark)
                    End Using
                End Using
                Using gborderLight As GraphicsPath = GetRoundedRect(r2, _roundedRadiusX)
                    Using p As New Pen(tTopColorEnd, 1)
                        g.DrawPath(p, gborderLight)
                    End Using
                End Using
                Using gborderMed As GraphicsPath = GetRoundedRect(r3, _roundedRadiusX)
                    Dim bordermed As New SolidBrush(Color.FromArgb(50, tTopColorEnd))
                    Using p As New Pen(bordermed, 1)
                        g.DrawPath(p, gborderMed)
                    End Using
                    'END PAINT BORDERS
                End Using
            End Using
        End Sub

#End Region

#Region "Paint TEXT AND IMAGE"

        Protected Sub TEXTandIMAGE(Rec As Rectangle, g As Graphics, textColor As Color)
            'BEGIN PAINT TEXT
            Dim sf As New StringFormat()
            sf.Alignment = StringAlignment.Center
            sf.LineAlignment = StringAlignment.Center

            '#Region "Top"

            If Me.TextAlign = ContentAlignment.TopLeft Then
                sf.LineAlignment = StringAlignment.Near
                sf.Alignment = StringAlignment.Near
            ElseIf Me.TextAlign = ContentAlignment.TopCenter Then
                sf.LineAlignment = StringAlignment.Near
                sf.Alignment = StringAlignment.Center
            ElseIf Me.TextAlign = ContentAlignment.TopRight Then
                sf.LineAlignment = StringAlignment.Near
                sf.Alignment = StringAlignment.Far

                '#End Region

                '#Region "Middle"

            ElseIf Me.TextAlign = ContentAlignment.MiddleLeft Then
                sf.LineAlignment = StringAlignment.Center
                sf.Alignment = StringAlignment.Near
            ElseIf Me.TextAlign = ContentAlignment.MiddleCenter Then
                sf.LineAlignment = StringAlignment.Center
                sf.Alignment = StringAlignment.Center
            ElseIf Me.TextAlign = ContentAlignment.MiddleRight Then
                sf.LineAlignment = StringAlignment.Center
                sf.Alignment = StringAlignment.Far

                '#End Region

                '#Region "Bottom"

            ElseIf Me.TextAlign = ContentAlignment.BottomLeft Then
                sf.LineAlignment = StringAlignment.Far
                sf.Alignment = StringAlignment.Near
            ElseIf Me.TextAlign = ContentAlignment.BottomCenter Then
                sf.LineAlignment = StringAlignment.Far
                sf.Alignment = StringAlignment.Center
            ElseIf Me.TextAlign = ContentAlignment.BottomRight Then
                sf.LineAlignment = StringAlignment.Far
                sf.Alignment = StringAlignment.Far
            End If

            '#End Region

            If Me.ShowKeyboardCues Then
                sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Show
            Else
                sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.Hide
            End If
            g.DrawString(Me.Text, Me.Font, New SolidBrush(textColor), Rec, sf)
        End Sub

#End Region

#End Region

#Region "Properties"

#Region "ColorTable"

        Private m_colorTable As Colortable = Nothing

        <DefaultValue(GetType(Colortable), "Office2010Blue")>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Property ColorTable() As Colortable
            Get
                If m_colorTable Is Nothing Then
                    m_colorTable = New Colortable()
                End If

                Return m_colorTable
            End Get
            Set

                If Value Is Nothing Then
                    Value = Colortable.Office2010Blue
                End If

                m_colorTable = DirectCast(Value, Colortable)


                Me.Invalidate()
            End Set
        End Property

        Public Property Theme() As Theme
            Get
                If Me.m_colorTable Is Colortable.Office2010Green Then
                    Return Theme.MSOffice2010_Green
                ElseIf Me.m_colorTable Is Colortable.Office2010Red Then
                    Return Theme.MSOffice2010_RED
                ElseIf Me.m_colorTable Is Colortable.Office2010Pink Then
                    Return Theme.MSOffice2010_Pink
                ElseIf Me.m_colorTable Is Colortable.Office2010Yellow Then
                    Return Theme.MSOffice2010_Yellow
                ElseIf Me.m_colorTable Is Colortable.Office2010White Then
                    Return Theme.MSOffice2010_WHITE
                ElseIf Me.m_colorTable Is Colortable.Office2010Publisher Then
                    Return Theme.MSOffice2010_Publisher
                End If

                Return Theme.MSOffice2010_BLUE
            End Get

            Set
                Me.thm = Value

                If thm = Theme.MSOffice2010_Green Then
                    Me.m_colorTable = Colortable.Office2010Green
                ElseIf thm = Theme.MSOffice2010_RED Then
                    Me.m_colorTable = Colortable.Office2010Red
                ElseIf thm = Theme.MSOffice2010_Pink Then
                    Me.m_colorTable = Colortable.Office2010Pink
                ElseIf thm = Theme.MSOffice2010_WHITE Then
                    Me.m_colorTable = Colortable.Office2010White
                ElseIf thm = Theme.MSOffice2010_Yellow Then
                    Me.m_colorTable = Colortable.Office2010Yellow
                ElseIf thm = Theme.MSOffice2010_Publisher Then
                    Me.m_colorTable = Colortable.Office2010Publisher
                Else
                    Me.m_colorTable = Colortable.Office2010Blue
                End If
            End Set
        End Property

#End Region

#Region "Background Image"

        <Browsable(False)>
        Public Overrides Property BackgroundImage() As Image
            Get
                Return MyBase.BackgroundImage
            End Get
            Set
                MyBase.BackgroundImage = Value
            End Set
        End Property

        <Browsable(False)>
        Public Overrides Property BackgroundImageLayout() As ImageLayout
            Get
                Return MyBase.BackgroundImageLayout
            End Get
            Set
                MyBase.BackgroundImageLayout = Value
            End Set
        End Property

#End Region

#End Region
    End Class

#Region "ENUM"

    Public Enum Theme
        MSOffice2010_BLUE = 1
        MSOffice2010_WHITE = 2
        MSOffice2010_RED = 3
        MSOffice2010_Green = 4
        MSOffice2010_Pink = 5
        MSOffice2010_Yellow = 6
        MSOffice2010_Publisher = 7
    End Enum

#End Region

#Region "COLOR TABLE"

    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Class Colortable
#Region "Static Color Tables"

        Shared office2010blu As New Office2010Blue()

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public Shared ReadOnly Property Office2010Blue() As Colortable
            Get
                Return office2010blu
            End Get
        End Property

        Shared office2010gr As New Office2010Green()

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public Shared ReadOnly Property Office2010Green() As Colortable
            Get
                Return office2010gr
            End Get
        End Property

        Shared office2010rd As New Office2010Red()

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public Shared ReadOnly Property Office2010Red() As Colortable
            Get
                Return office2010rd
            End Get
        End Property

        Shared office2010pk As New Office2010Pink()

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public Shared ReadOnly Property Office2010Pink() As Colortable
            Get
                Return office2010pk
            End Get
        End Property

        Shared office2010yl As New Office2010Yellow()

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public Shared ReadOnly Property Office2010Yellow() As Colortable
            Get
                Return office2010yl
            End Get
        End Property

        Shared office2010wt As New Office2010White()

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public Shared ReadOnly Property Office2010White() As Colortable
            Get
                Return office2010wt
            End Get
        End Property


        Shared office2010pb As New Office2010Publisher()

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public Shared ReadOnly Property Office2010Publisher() As Colortable
            Get
                Return office2010pb
            End Get
        End Property


#End Region

#Region "Custom Properties"

        Private m_textColor As Color = Color.White
        Private m_selectedTextColor As Color = Color.FromArgb(30, 57, 91)
        Private OverTextColor As Color = Color.FromArgb(30, 57, 91)
        Private borderColor As Color = Color.FromArgb(31, 72, 161)
        Private innerborderColor As Color = Color.FromArgb(68, 135, 228)

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Overridable Property TextColor() As Color
            Get
                Return m_textColor
            End Get
            Set
                m_textColor = Value
            End Set
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Overridable Property SelectedTextColor() As Color
            Get
                Return m_selectedTextColor
            End Get
            Set
                m_selectedTextColor = Value
            End Set
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Overridable Property HoverTextColor() As Color
            Get
                Return OverTextColor
            End Get
            Set
                OverTextColor = Value
            End Set
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Overridable Property BorderColor1() As Color
            Get
                Return borderColor
            End Get
            Set
                borderColor = Value
            End Set
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Overridable Property BorderColor2() As Color
            Get
                Return innerborderColor
            End Get
            Set
                innerborderColor = Value
            End Set
        End Property

#End Region

#Region "Button Normal"

        Private buttonNormalBegin As Color = Color.FromArgb(31, 72, 161)
        Private buttonNormalMiddleBegin As Color = Color.FromArgb(68, 135, 228)
        Private buttonNormalMiddleEnd As Color = Color.FromArgb(41, 97, 181)
        Private buttonNormalEnd As Color = Color.FromArgb(62, 125, 219)

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Overridable Property ButtonNormalColor1() As Color
            Get
                Return buttonNormalBegin
            End Get
            Set
                buttonNormalBegin = Value
            End Set
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Overridable Property ButtonNormalColor2() As Color
            Get
                Return buttonNormalMiddleBegin
            End Get
            Set
                buttonNormalMiddleBegin = Value
            End Set
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Overridable Property ButtonNormalColor3() As Color
            Get
                Return buttonNormalMiddleEnd
            End Get
            Set
                buttonNormalMiddleEnd = Value
            End Set
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Overridable Property ButtonNormalColor4() As Color
            Get
                Return buttonNormalEnd
            End Get
            Set
                buttonNormalEnd = Value
            End Set
        End Property

#End Region

#Region "Button Selected"

        Private buttonSelectedBegin As Color = Color.FromArgb(236, 199, 87)
        Private buttonSelectedMiddleBegin As Color = Color.FromArgb(252, 243, 215)
        Private buttonSelectedMiddleEnd As Color = Color.FromArgb(255, 229, 117)
        Private buttonSelectedEnd As Color = Color.FromArgb(255, 216, 107)

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Overridable Property ButtonSelectedColor1() As Color
            Get
                Return buttonSelectedBegin
            End Get
            Set
                buttonSelectedBegin = Value
            End Set
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Overridable Property ButtonSelectedColor2() As Color
            Get
                Return buttonSelectedMiddleBegin
            End Get
            Set
                buttonSelectedMiddleBegin = Value
            End Set
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Overridable Property ButtonSelectedColor3() As Color
            Get
                Return buttonSelectedMiddleEnd
            End Get
            Set
                buttonSelectedMiddleEnd = Value
            End Set
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Overridable Property ButtonSelectedColor4() As Color
            Get
                Return buttonSelectedEnd
            End Get
            Set
                buttonSelectedEnd = Value
            End Set
        End Property

#End Region

#Region "Button Mouse Over"

        Private buttonMouseOverBegin As Color = Color.FromArgb(236, 199, 87)
        Private buttonMouseOverMiddleBegin As Color = Color.FromArgb(252, 243, 215)
        Private buttonMouseOverMiddleEnd As Color = Color.FromArgb(249, 225, 137)
        Private buttonMouseOverEnd As Color = Color.FromArgb(251, 249, 224)

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Overridable Property ButtonMouseOverColor1() As Color
            Get
                Return buttonMouseOverBegin
            End Get
            Set
                buttonMouseOverBegin = Value
            End Set
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Overridable Property ButtonMouseOverColor2() As Color
            Get
                Return buttonMouseOverMiddleBegin
            End Get
            Set
                buttonMouseOverMiddleBegin = Value
            End Set
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Overridable Property ButtonMouseOverColor3() As Color
            Get
                Return buttonMouseOverMiddleEnd
            End Get
            Set
                buttonMouseOverMiddleEnd = Value
            End Set
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
        Public Overridable Property ButtonMouseOverColor4() As Color
            Get
                Return buttonMouseOverEnd
            End Get
            Set
                buttonMouseOverEnd = Value
            End Set
        End Property

#End Region
    End Class

#Region "Office 2010 Blue"

    Public Class Office2010Blue
        Inherits Colortable
        Public Sub New()
            ' Border Color

            Me.BorderColor1 = Color.FromArgb(31, 72, 161)
            Me.BorderColor2 = Color.FromArgb(68, 135, 228)

            ' Button Text Color

            Me.TextColor = Color.White
            Me.SelectedTextColor = Color.FromArgb(30, 57, 91)
            Me.HoverTextColor = Color.FromArgb(30, 57, 91)

            ' Button normal color

            Me.ButtonNormalColor1 = Color.FromArgb(31, 72, 161)
            Me.ButtonNormalColor2 = Color.FromArgb(68, 135, 228)
            Me.ButtonNormalColor3 = Color.FromArgb(41, 97, 181)
            Me.ButtonNormalColor4 = Color.FromArgb(62, 125, 219)

            ' Button mouseover color

            Me.ButtonMouseOverColor1 = Color.FromArgb(236, 199, 87)
            Me.ButtonMouseOverColor2 = Color.FromArgb(252, 243, 215)
            Me.ButtonMouseOverColor3 = Color.FromArgb(249, 225, 137)
            Me.ButtonMouseOverColor4 = Color.FromArgb(251, 249, 224)

            ' Button selected color

            Me.ButtonSelectedColor1 = Color.FromArgb(236, 199, 87)
            Me.ButtonSelectedColor2 = Color.FromArgb(252, 243, 215)
            Me.ButtonSelectedColor3 = Color.FromArgb(255, 229, 117)
            Me.ButtonSelectedColor4 = Color.FromArgb(255, 216, 107)
        End Sub

        Public Overrides Function ToString() As String
            Return "Office2010Blue"
        End Function
    End Class

#End Region

#Region "Office 2010 GREEN"

    Public Class Office2010Green
        Inherits Colortable
        Public Sub New()
            ' Border Color

            Me.BorderColor1 = Color.FromArgb(31, 72, 161)
            Me.BorderColor2 = Color.FromArgb(68, 135, 228)

            ' Button Text Color

            Me.TextColor = Color.White
            Me.SelectedTextColor = Color.FromArgb(30, 57, 91)
            Me.HoverTextColor = Color.FromArgb(30, 57, 91)

            ' Button normal color

            Me.ButtonNormalColor1 = Color.FromArgb(42, 126, 43)
            Me.ButtonNormalColor2 = Color.FromArgb(94, 184, 67)
            Me.ButtonNormalColor3 = Color.FromArgb(42, 126, 43)
            Me.ButtonNormalColor4 = Color.FromArgb(94, 184, 67)

            ' Button mouseover color

            Me.ButtonMouseOverColor1 = Color.FromArgb(236, 199, 87)
            Me.ButtonMouseOverColor2 = Color.FromArgb(252, 243, 215)
            Me.ButtonMouseOverColor3 = Color.FromArgb(249, 225, 137)
            Me.ButtonMouseOverColor4 = Color.FromArgb(251, 249, 224)

            ' Button selected color

            Me.ButtonSelectedColor1 = Color.FromArgb(236, 199, 87)
            Me.ButtonSelectedColor2 = Color.FromArgb(252, 243, 215)
            Me.ButtonSelectedColor3 = Color.FromArgb(255, 229, 117)
            Me.ButtonSelectedColor4 = Color.FromArgb(255, 216, 107)
        End Sub

        Public Overrides Function ToString() As String
            Return "Office2010Green"
        End Function
    End Class

#End Region

#Region "Office 2010 Red"

    Public Class Office2010Red
        Inherits Colortable
        Public Sub New()
            ' Border Color

            Me.BorderColor1 = Color.FromArgb(31, 72, 161)
            Me.BorderColor2 = Color.FromArgb(68, 135, 228)

            ' Button Text Color

            Me.TextColor = Color.White
            Me.SelectedTextColor = Color.FromArgb(30, 57, 91)
            Me.HoverTextColor = Color.FromArgb(30, 57, 91)

            ' Button normal color

            Me.ButtonNormalColor1 = Color.FromArgb(227, 77, 45)
            Me.ButtonNormalColor2 = Color.FromArgb(245, 148, 64)
            Me.ButtonNormalColor3 = Color.FromArgb(227, 77, 45)
            Me.ButtonNormalColor4 = Color.FromArgb(245, 148, 64)

            ' Button mouseover color

            Me.ButtonMouseOverColor1 = Color.FromArgb(236, 199, 87)
            Me.ButtonMouseOverColor2 = Color.FromArgb(252, 243, 215)
            Me.ButtonMouseOverColor3 = Color.FromArgb(249, 225, 137)
            Me.ButtonMouseOverColor4 = Color.FromArgb(251, 249, 224)

            ' Button selected color

            Me.ButtonSelectedColor1 = Color.FromArgb(236, 199, 87)
            Me.ButtonSelectedColor2 = Color.FromArgb(252, 243, 215)
            Me.ButtonSelectedColor3 = Color.FromArgb(255, 229, 117)
            Me.ButtonSelectedColor4 = Color.FromArgb(255, 216, 107)
        End Sub

        Public Overrides Function ToString() As String
            Return "Office2010Red"
        End Function
    End Class

#End Region

#Region "Office 2010 Pink"

    Public Class Office2010Pink
        Inherits Colortable
        Public Sub New()
            ' Border Color

            Me.BorderColor1 = Color.FromArgb(31, 72, 161)
            Me.BorderColor2 = Color.FromArgb(68, 135, 228)

            ' Button Text Color

            Me.TextColor = Color.White
            Me.SelectedTextColor = Color.FromArgb(30, 57, 91)
            Me.HoverTextColor = Color.FromArgb(30, 57, 91)

            ' Button normal color

            Me.ButtonNormalColor1 = Color.FromArgb(175, 6, 77)
            Me.ButtonNormalColor2 = Color.FromArgb(222, 52, 119)
            Me.ButtonNormalColor3 = Color.FromArgb(175, 6, 77)
            Me.ButtonNormalColor4 = Color.FromArgb(222, 52, 119)

            ' Button mouseover color

            Me.ButtonMouseOverColor1 = Color.FromArgb(236, 199, 87)
            Me.ButtonMouseOverColor2 = Color.FromArgb(252, 243, 215)
            Me.ButtonMouseOverColor3 = Color.FromArgb(249, 225, 137)
            Me.ButtonMouseOverColor4 = Color.FromArgb(251, 249, 224)

            ' Button selected color

            Me.ButtonSelectedColor1 = Color.FromArgb(236, 199, 87)
            Me.ButtonSelectedColor2 = Color.FromArgb(252, 243, 215)
            Me.ButtonSelectedColor3 = Color.FromArgb(255, 229, 117)
            Me.ButtonSelectedColor4 = Color.FromArgb(255, 216, 107)
        End Sub

        Public Overrides Function ToString() As String
            Return "Office2010Pink"
        End Function
    End Class

#End Region

#Region "Office 2010 White"

    Public Class Office2010White
        Inherits Colortable
        Public Sub New()
            ' Border Color

            Me.BorderColor1 = Color.FromArgb(31, 72, 161)
            Me.BorderColor2 = Color.FromArgb(68, 135, 228)

            ' Button Text Color

            Me.TextColor = Color.Black
            Me.SelectedTextColor = Color.FromArgb(30, 57, 91)
            Me.HoverTextColor = Color.FromArgb(30, 57, 91)

            ' Button normal color

            Me.ButtonNormalColor1 = Color.FromArgb(154, 154, 154)
            Me.ButtonNormalColor2 = Color.FromArgb(255, 255, 255)
            Me.ButtonNormalColor3 = Color.FromArgb(235, 235, 235)
            Me.ButtonNormalColor4 = Color.FromArgb(255, 255, 255)

            ' Button mouseover color

            Me.ButtonMouseOverColor1 = Color.FromArgb(236, 199, 87)
            Me.ButtonMouseOverColor2 = Color.FromArgb(252, 243, 215)
            Me.ButtonMouseOverColor3 = Color.FromArgb(249, 225, 137)
            Me.ButtonMouseOverColor4 = Color.FromArgb(251, 249, 224)

            ' Button selected color

            Me.ButtonSelectedColor1 = Color.FromArgb(236, 199, 87)
            Me.ButtonSelectedColor2 = Color.FromArgb(252, 243, 215)
            Me.ButtonSelectedColor3 = Color.FromArgb(255, 229, 117)
            Me.ButtonSelectedColor4 = Color.FromArgb(255, 216, 107)
        End Sub

        Public Overrides Function ToString() As String
            Return "Office2010White"
        End Function
    End Class

#End Region

#Region "Office 2010 Yellow"

    Public Class Office2010Yellow
        Inherits Colortable
        Public Sub New()
            ' Border Color

            Me.BorderColor1 = Color.FromArgb(31, 72, 161)
            Me.BorderColor2 = Color.FromArgb(68, 135, 228)

            ' Button Text Color

            Me.TextColor = Color.White
            Me.SelectedTextColor = Color.FromArgb(30, 57, 91)
            Me.HoverTextColor = Color.FromArgb(30, 57, 91)

            ' Button normal color

            Me.ButtonNormalColor1 = Color.FromArgb(252, 161, 8)
            Me.ButtonNormalColor2 = Color.FromArgb(251, 191, 45)
            Me.ButtonNormalColor3 = Color.FromArgb(252, 161, 8)
            Me.ButtonNormalColor4 = Color.FromArgb(251, 191, 45)

            ' Button mouseover color

            Me.ButtonMouseOverColor1 = Color.FromArgb(236, 199, 87)
            Me.ButtonMouseOverColor2 = Color.FromArgb(252, 243, 215)
            Me.ButtonMouseOverColor3 = Color.FromArgb(249, 225, 137)
            Me.ButtonMouseOverColor4 = Color.FromArgb(251, 249, 224)

            ' Button selected color

            Me.ButtonSelectedColor1 = Color.FromArgb(236, 199, 87)
            Me.ButtonSelectedColor2 = Color.FromArgb(252, 243, 215)
            Me.ButtonSelectedColor3 = Color.FromArgb(255, 229, 117)
            Me.ButtonSelectedColor4 = Color.FromArgb(255, 216, 107)
        End Sub

        Public Overrides Function ToString() As String
            Return "Office2010Yellow"
        End Function
    End Class

#End Region

#Region "Office 2010 Publisher"

    Public Class Office2010Publisher
        Inherits Colortable
        Public Sub New()
            ' Border Color

            Me.BorderColor1 = Color.FromArgb(31, 72, 161)
            Me.BorderColor2 = Color.FromArgb(68, 135, 228)

            ' Button Text Color

            Me.TextColor = Color.White
            Me.SelectedTextColor = Color.FromArgb(30, 57, 91)
            Me.HoverTextColor = Color.FromArgb(30, 57, 91)

            ' Button normal color

            Me.ButtonNormalColor1 = Color.FromArgb(0, 126, 126)
            Me.ButtonNormalColor2 = Color.FromArgb(31, 173, 167)
            Me.ButtonNormalColor3 = Color.FromArgb(0, 126, 126)
            Me.ButtonNormalColor4 = Color.FromArgb(31, 173, 167)

            ' Button mouseover color

            Me.ButtonMouseOverColor1 = Color.FromArgb(236, 199, 87)
            Me.ButtonMouseOverColor2 = Color.FromArgb(252, 243, 215)
            Me.ButtonMouseOverColor3 = Color.FromArgb(249, 225, 137)
            Me.ButtonMouseOverColor4 = Color.FromArgb(251, 249, 224)

            ' Button selected color

            Me.ButtonSelectedColor1 = Color.FromArgb(236, 199, 87)
            Me.ButtonSelectedColor2 = Color.FromArgb(252, 243, 215)
            Me.ButtonSelectedColor3 = Color.FromArgb(255, 229, 117)
            Me.ButtonSelectedColor4 = Color.FromArgb(255, 216, 107)
        End Sub

        Public Overrides Function ToString() As String
            Return "Office2010Publisher"
        End Function
    End Class

#End Region

#End Region
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
