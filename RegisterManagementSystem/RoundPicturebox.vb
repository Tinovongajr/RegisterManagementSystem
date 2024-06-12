Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Public Class RoundPicturebox
    Inherits PictureBox

    'Fields
    Private borderSize As Integer = 2

    Private borderColor As Color = Color.RoyalBlue

    Private borderColor2 As Color = Color.HotPink

    Private borderLineStyle As DashStyle = DashStyle.Solid

    Private borderCapStyle As DashCap = DashCap.Flat

    Private gradientAngle As Single = 50.0!

    'Constructor
    Public Sub New()
        MyBase.New
        Me.Size = New Size(100, 100)
        Me.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    'Properties
    <Category("Extra features")>
    Public Property Border_Size As Integer
        Get
            Return Me.borderSize
        End Get
        Set
            Me.borderSize = Value
            Me.Invalidate()
        End Set
    End Property

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
    Public Property Border_Color2 As Color
        Get
            Return Me.borderColor2
        End Get
        Set
            Me.borderColor2 = Value
            Me.Invalidate()
        End Set
    End Property

    <Category("Extra features")>
    Public Property Border_LineStyle As DashStyle
        Get
            Return Me.borderLineStyle
        End Get
        Set
            Me.borderLineStyle = Value
            Me.Invalidate()
        End Set
    End Property

    <Category("Extra features")>
    Public Property Border_CapStyle As DashCap
        Get
            Return Me.borderCapStyle
        End Get
        Set
            Me.borderCapStyle = Value
            Me.Invalidate()
        End Set
    End Property

    <Category("Extra features")>
    Public Property Gradient_Angle As Single
        Get
            Return Me.gradientAngle
        End Get
        Set
            Me.gradientAngle = Value
            Me.Invalidate()
        End Set
    End Property

    'Overridden methods
    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        Me.Size = New Size(Me.Width, Me.Width)
    End Sub

    Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
        MyBase.OnPaint(pe)
        'Fields
        Dim graph = pe.Graphics
        Dim rectContourSmooth = Rectangle.Inflate(Me.ClientRectangle, -1, -1)
        Dim rectBorder = Rectangle.Inflate(rectContourSmooth, (Me.borderSize * -1), (Me.borderSize * -1))
        Dim smoothSize = (Me.borderSize * 3)
        'TODO: Warning!!!, inline IF is not supported ?
        If Not (Me.borderSize > 0) Then
            Me.borderSize = 1
        End If

        Dim borderGColor = New LinearGradientBrush(rectBorder, Me.borderColor, Me.borderColor2, Me.gradientAngle)
        Dim pathRegion = New GraphicsPath
        Dim penSmooth = New Pen(Me.Parent.BackColor, smoothSize)
        Dim penBorder = New Pen(borderGColor, Me.borderSize)
        graph.SmoothingMode = SmoothingMode.AntiAlias
        penBorder.DashStyle = Me.borderLineStyle
        penBorder.DashCap = Me.borderCapStyle
        pathRegion.AddEllipse(rectContourSmooth)
        'Set rounded region 
        Me.Region = New Region(pathRegion)
        'Drawing
        graph.DrawEllipse(penSmooth, rectContourSmooth)
        'Draw contour smoothing
        If (Me.borderSize > 0) Then
            graph.DrawEllipse(penBorder, rectBorder)
        End If

    End Sub
End Class
