
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
<DefaultEvent("_TextChangedd")>
<DefaultBindingProperty("Texts")>
Public Class usercontrol2
    'Private Sub CustomTextbox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Private borderColor As Color = Color.MediumSlateBlue

    Private borderFocusColor As Color = Color.HotPink

    Private borderSize As Integer = 2

    Private underlinedStyle As Boolean = False

    Private isFocused As Boolean = False

    Private borderRadius As Integer = 0

    Private placeholderColor As Color = Color.DarkGray
    Private tag2 As String = ""
    Private placeholderText As String = ""

    Private isPlaceholder As Boolean = False

    Private isPasswordChar As Boolean = False

    'Events
    Public Event _TextChangedd As EventHandler



    Public Sub New()
        MyBase.New
        'Created by designer
        InitializeComponent()
    End Sub
#Region "-> Properties"

    <Category("Extra features")>
    Public Property Border_Color As Color
        Get
            Return Me.borderColor
        End Get
        Set
            Me.borderColor = Value
            Me.Invalidate()
        End Set
    End Property

    <Category("Extra features")>
    Public Property Border_FocusColor As Color
        Get
            Return Me.borderFocusColor
        End Get
        Set
            Me.borderFocusColor = Value
        End Set
    End Property
    <Category("Extra features")>
    Public Property tag_2 As String
        Get
            Return Me.tag2
        End Get
        Set
            Me.tag2 = Value
        End Set
    End Property

    <Category("Extra features")>
    Public Property Border_Size As Integer
        Get
            Return Me.borderSize
        End Get
        Set
            If (Value >= 1) Then
                Me.borderSize = Value
                Me.Invalidate()
            End If

        End Set
    End Property

    <Category("Extra features")>
    Public Property UnderlineStyle As Boolean
        Get
            Return Me.underlinedStyle
        End Get
        Set(value As Boolean)
            Me.underlinedStyle = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Extra features")>
    Public Property PasswordChar As Boolean
        Get
            Return Me.isPasswordChar
        End Get
        Set
            Me.isPasswordChar = Value
            If Not Me.isPlaceholder Then
                TextBox1.UseSystemPasswordChar = Value
            End If

        End Set
    End Property

    <Category("Extra features")>
    Public Property Multiline As Boolean
        Get
            Return TextBox1.Multiline
        End Get
        Set
            TextBox1.Multiline = Value
        End Set
    End Property

    <Category("Extra features")>
    Public Overrides Property BackColor As Color
        Get
            Return MyBase.BackColor
        End Get
        Set
            MyBase.BackColor = Value
            TextBox1.BackColor = Value
        End Set
    End Property

    <Category("Extra features")>
    Public Overrides Property ForeColor As Color
        Get
            Return MyBase.ForeColor
        End Get
        Set
            MyBase.ForeColor = Value
            TextBox1.ForeColor = Value
        End Set
    End Property

    <Category("Extra features")>
    Public Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set
            MyBase.Font = Value
            TextBox1.Font = Value
            If Me.DesignMode Then
                Me.UpdateControlHeight()
            End If

        End Set
    End Property

    <Category("Extra features")>
    Public Property Texts As String
        Get
            If Me.isPlaceholder Then
                Return ""
            Else
                Return TextBox1.Text
            End If

        End Get
        Set(value As String)
            TextBox1.Text = value
            Me.SetPlaceholder()
        End Set
    End Property

    <Category("Extra features")>
    Public Property Border_Radius As Integer
        Get
            Return Me.borderRadius
        End Get
        Set
            If (Value >= 0) Then
                Me.borderRadius = Value
                Me.Invalidate()
                'Redraw control
            End If

        End Set
    End Property

    <Category("Extra features")>
    Public Property PlaceHolderTextColor As Color
        Get
            Return Me.placeholderColor
        End Get
        Set
            Me.placeholderColor = Value
            If Me.isPlaceholder Then
                TextBox1.ForeColor = Value
            End If

        End Set
    End Property

    <Category("Extra features")>
    Public Property PlaceHolder_Text As String
        Get
            Return Me.placeholderText
        End Get
        Set
            Me.placeholderText = Value
            TextBox1.Text = ""
            Me.SetPlaceholder()
        End Set
    End Property
#End Region
#Region "-> Overridden methods"

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        If Me.DesignMode Then
            Me.UpdateControlHeight()
        End If

    End Sub

    Protected Overrides Sub OnLoad(ByVal e As EventArgs)
        MyBase.OnLoad(e)
        Me.UpdateControlHeight()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim graph As Graphics = e.Graphics
        If (Me.borderRadius > 1) Then
            '-Fields
            Dim rectBorderSmooth = Me.ClientRectangle
            Dim rectBorder = Rectangle.Inflate(rectBorderSmooth, (Me.borderSize * -1), (Me.borderSize * -1))
            Dim smoothSize As Integer = Me.borderSize
            'TODO: Warning!!!, inline IF is not supported ?
            If Not (Me.borderSize > 0) Then
                Me.borderSize = 1
            End If

            Dim pathBorderSmooth As GraphicsPath = Me.GetFigurePath(rectBorderSmooth, Me.borderRadius)
            Dim pathBorder As GraphicsPath = Me.GetFigurePath(rectBorder, (Me.borderRadius - Me.borderSize))
            Dim penBorderSmooth As Pen = New Pen(Me.Parent.BackColor, smoothSize)
            Dim penBorder As Pen = New Pen(Me.Border_Color, Me.borderSize)
            '-Drawing
            Me.Region = New Region(pathBorderSmooth)
            'Set the rounded region of UserControl
            If (Me.borderRadius > 15) Then
                Me.SetTextBoxRoundedRegion()
            End If

            'Set the rounded region of TextBox component
            graph.SmoothingMode = SmoothingMode.AntiAlias
            penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Center
            If Me.isFocused Then
                penBorder.Color = Me.borderFocusColor
            End If

            If Me.underlinedStyle Then
                'Draw border smoothing
                graph.DrawPath(penBorderSmooth, pathBorderSmooth)
                'Draw border
                graph.SmoothingMode = SmoothingMode.None
                graph.DrawLine(penBorder, 0, (Me.Height - 1), Me.Width, (Me.Height - 1))
            Else
                'Draw border smoothing
                graph.DrawPath(penBorderSmooth, pathBorderSmooth)
                'Draw border
                graph.DrawPath(penBorder, pathBorder)
            End If

        Else
            'Draw border
            Dim penBorder As Pen = New Pen(Me.Border_Color, Me.borderSize)
            Me.Region = New Region(Me.ClientRectangle)
            penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset
            If Me.isFocused Then
                penBorder.Color = Me.Border_FocusColor
            End If

            If Me.underlinedStyle Then
                graph.DrawLine(penBorder, 0, (Me.Height - 1), Me.Width, (Me.Height - 1))
            Else
                graph.DrawRectangle(penBorder, 0, 0, (Me.Width - 0.5!), (Me.Height - 0.5!))
            End If

        End If

    End Sub
#End Region
#Region "-> Private methods"

    Private Sub SetPlaceholder()
        If (String.IsNullOrWhiteSpace(TextBox1.Text) _
                        AndAlso (Me.placeholderText <> "")) Then
            Me.isPlaceholder = True
            TextBox1.Text = Me.placeholderText
            TextBox1.ForeColor = Me.placeholderColor
            If Me.isPasswordChar Then
                TextBox1.UseSystemPasswordChar = False
            End If

        End If

    End Sub

    Private Sub RemovePlaceholder()
        If (Me.isPlaceholder _
                        AndAlso (Me.placeholderText <> "")) Then
            Me.isPlaceholder = False
            TextBox1.Text = ""
            TextBox1.ForeColor = Me.ForeColor
            If Me.isPasswordChar Then
                TextBox1.UseSystemPasswordChar = True
            End If

        End If

    End Sub

    Private Function GetFigurePath(ByVal rect As Rectangle, ByVal radius As Integer) As GraphicsPath
        Dim path As GraphicsPath = New GraphicsPath
        Dim curveSize As Single = (radius * 2.0!)
        path.StartFigure()
        path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90)
        path.AddArc((rect.Right - curveSize), rect.Y, curveSize, curveSize, 270, 90)
        path.AddArc((rect.Right - curveSize), (rect.Bottom - curveSize), curveSize, curveSize, 0, 90)
        path.AddArc(rect.X, (rect.Bottom - curveSize), curveSize, curveSize, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    Private Sub SetTextBoxRoundedRegion()
        Dim pathTxt As GraphicsPath
        If Me.Multiline Then
            pathTxt = Me.GetFigurePath(TextBox1.ClientRectangle, (Me.borderRadius - Me.borderSize))
            TextBox1.Region = New Region(pathTxt)
        Else
            pathTxt = Me.GetFigurePath(TextBox1.ClientRectangle, (Me.Border_Size * 2))
            TextBox1.Region = New Region(pathTxt)
        End If

        pathTxt.Dispose()
    End Sub

    Private Sub UpdateControlHeight()
        If (TextBox1.Multiline = False) Then
            Dim txtHeight As Integer = (TextRenderer.MeasureText("Text", Me.Font).Height + 1)
            TextBox1.Multiline = True
            TextBox1.MinimumSize = New Size(0, txtHeight)
            TextBox1.Multiline = False
            Me.Height = (TextBox1.Height _
                            + (Me.Padding.Top + Me.Padding.Bottom))
        End If

    End Sub
#End Region
#Region "-> TextBox events"


#End Region
    Private Sub textBox1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.OnClick(e)
    End Sub

    Private Sub textBox1_MouseEnter(ByVal sender As Object, ByVal e As EventArgs)
        Me.OnMouseEnter(e)
    End Sub

    Private Sub textBox1_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
        Me.OnMouseLeave(e)
    End Sub

    Private Sub textBox1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextBox1.KeyPress
        Me.OnKeyPress(e)
    End Sub

    Private Sub textBox1_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox1.Enter
        Me.isFocused = True
        Me.Invalidate()
        Me.RemovePlaceholder()
    End Sub

    Private Sub textBox1_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox1.Leave
        Me.isFocused = False
        Me.Invalidate()
        Me.SetPlaceholder()
    End Sub

    Private Sub CustomTextbox_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown

    End Sub
End Class

