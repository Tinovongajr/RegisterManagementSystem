Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class CustomButton
    Inherits Button

    'Fields
    Private borderSize As Integer = 0

    Private borderRadius As Integer = 0

    Private borderColor As Color = Color.PaleVioletRed

    Private tag2 As String = ""
    Private tag3 As String = ""
    'Properties
    <Category("Extra features")>
    Public Property BorderSizes As Integer
        Get
            Return Me.borderSize
        End Get
        Set
            Me.borderSize = Value
            Me.Invalidate()
        End Set
    End Property

    <Category("Extra features")>
    Public Property BorderRadiuses As Integer
        Get
            Return Me.borderRadius
        End Get
        Set
            Me.borderRadius = Value
            Me.Invalidate()
        End Set
    End Property

    <Category("Extra features")>
    Public Property BorderColor1 As Color
        Get
            Return Me.borderColor
        End Get
        Set
            Me.borderColor = Value
            Me.Invalidate()
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
    Public Property tag_3 As String
        Get
            Return Me.tag3
        End Get
        Set
            Me.tag3 = Value
        End Set
    End Property
    <Category("Extra features")>
    Public Property BackgroundColor As Color
        Get
            Return Me.BackColor
        End Get
        Set
            Me.BackColor = Value
        End Set
    End Property

    <Category("Extra features")>
    Public Property TextColor As Color
        Get
            Return Me.ForeColor
        End Get
        Set
            Me.ForeColor = Value
        End Set
    End Property

    'Constructor
    Public Sub New()
        MyBase.New
        Me.FlatStyle = FlatStyle.Flat
        Me.FlatAppearance.BorderSize = 0
        Me.Size = New Size(150, 40)
        Me.BackColor = Color.MediumSlateBlue
        Me.ForeColor = Color.White
        AddHandler Resize, AddressOf Me.Button_Resize
    End Sub

    'Methods
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

    Protected Overrides Sub OnPaint(ByVal pevent As PaintEventArgs)
        MyBase.OnPaint(pevent)
        Dim rectSurface As Rectangle = Me.ClientRectangle
        Dim rectBorder As Rectangle = Rectangle.Inflate(rectSurface, (Me.borderSize * -1), (Me.borderSize * -1))
        Dim smoothSize As Integer = 2
        If (Me.borderSize > 0) Then
            smoothSize = Me.borderSize
        End If

        If (Me.borderRadius > 2) Then
            Dim pathSurface As GraphicsPath = Me.GetFigurePath(rectSurface, Me.borderRadius)
            Dim pathBorder As GraphicsPath = Me.GetFigurePath(rectBorder, (Me.borderRadius - Me.borderSize))
            Dim penSurface As Pen = New Pen(Me.Parent.BackColor, smoothSize)
            Dim penBorder As Pen = New Pen(Me.borderColor, Me.borderSize)
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            'Button surface
            Me.Region = New Region(pathSurface)
            'Draw surface border for HD result
            pevent.Graphics.DrawPath(penSurface, pathSurface)
            'Button border                    
            If (Me.borderSize >= 1) Then
                pevent.Graphics.DrawPath(penBorder, pathBorder)
            End If

        Else
            pevent.Graphics.SmoothingMode = SmoothingMode.None
            'Button surface
            Me.Region = New Region(rectSurface)
            'Button border
            If (Me.borderSize >= 1) Then
                Dim penBorder As Pen = New Pen(Me.borderColor, Me.borderSize)
                penBorder.Alignment = PenAlignment.Inset
                pevent.Graphics.DrawRectangle(penBorder, 0, 0, (Me.Width - 1), (Me.Height - 1))
            End If

        End If

    End Sub

    Protected Overrides Sub OnHandleCreated(ByVal e As EventArgs)
        MyBase.OnHandleCreated(e)
        AddHandler Me.Parent.BackColorChanged, AddressOf Me.Container_BackColorChanged
    End Sub

    Private Sub Container_BackColorChanged(ByVal sender As Object, ByVal e As EventArgs)
        Me.Invalidate()
    End Sub

    Private Sub Button_Resize(ByVal sender As Object, ByVal e As EventArgs)
        If (Me.borderRadius > Me.Height) Then
            Me.borderRadius = Me.Height
        End If

    End Sub
End Class

