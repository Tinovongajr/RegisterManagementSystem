Imports System.ComponentModel


<ToolboxItem(True)>
Public Class Buttondefault
    Inherits NoFocusCueBotton

    Public Enum Type
        Close
        Maximize
        Minimize
    End Enum

    Private activeIconColorPen As Pen
    Private activeIconColorBrush As Brush
    Private activeColorBrush As Brush
    <EditorBrowsable(EditorBrowsableState.Always)>
    <Browsable(True)>
    <DefaultValue(Type.Close)>
    <Category("Appearance")>
    <Description("The type which defines the buttons behaviour.")>
    Public Property ButtonType As Type
    <EditorBrowsable(EditorBrowsableState.Always)>
    <Browsable(True)>
    <DefaultValue(vbNull)>
    <Category("Appearance")>
    <Description("The background color of the button when the mouse is inside the buttons bounds.")>
    Public Property HoverColor As Color
    <EditorBrowsable(EditorBrowsableState.Always)>
    <Browsable(True)>
    <DefaultValue(vbNull)>
    <Category("Appearance")>
    <Description("The background color of the button when the button is clicked.")>
    Public Property ClickColor As Color
    <EditorBrowsable(EditorBrowsableState.Always)>
    <Browsable(True)>
    <DefaultValue(vbNull)>
    <Category("Appearance")>
    <Description("The default color of the icon.")>
    Public Property IconColor As Color
    <EditorBrowsable(EditorBrowsableState.Always)>
    <Browsable(True)>
    <DefaultValue(vbNull)>
    <Category("Appearance")>
    <Description("The color of the icon when the mouse is inside the buttons bounds.")>
    Public Property HoverIconColor As Color
    <EditorBrowsable(EditorBrowsableState.Always)>
    <Browsable(True)>
    <DefaultValue(vbNull)>
    <Category("Appearance")>
    <Description("The color of the icon when the button is clicked.")>
    Public Property ClickIconColor As Color

    <EditorBrowsable(EditorBrowsableState.Never)>
    <Browsable(False)>
    Public Overridable ReadOnly Property ActiveColor As Color
        Get
            If Me.Clicked Then Return Me.ClickColor
            If Me.Hovered Then Return Me.HoverColor
            Return BackColor
        End Get
    End Property

    <EditorBrowsable(EditorBrowsableState.Never)>
    <Browsable(False)>
    Public Overridable ReadOnly Property ActiveIconColor As Color
        Get
            If Me.Clicked Then Return Me.ClickIconColor
            If Me.Hovered Then Return Me.HoverIconColor
            Return IconColor
        End Get
    End Property

    <EditorBrowsable(EditorBrowsableState.Never)>
    <Browsable(False)>
    <DefaultValue(False)>
    Public Property Hovered As Boolean
    <EditorBrowsable(EditorBrowsableState.Never)>
    <Browsable(False)>
    <DefaultValue(False)>
    Public Property Clicked As Boolean

    Public Sub New()
    End Sub

    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        MyBase.OnMouseEnter(e)
        Hovered = True
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        MyBase.OnMouseLeave(e)
        Hovered = False
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal mevent As MouseEventArgs)
        MyBase.OnMouseDown(mevent)
        Clicked = True
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal mevent As MouseEventArgs)
        MyBase.OnMouseUp(mevent)
        Clicked = False
    End Sub

    Protected Overrides Sub OnClick(ByVal e As EventArgs)
        If ButtonType = Type.Close Then
            Me.FindForm()?.Close()
        ElseIf ButtonType = Type.Maximize Then
            Me.FindForm().WindowState = If(Me.FindForm().WindowState = FormWindowState.Maximized, FormWindowState.Normal, FormWindowState.Maximized)
        Else
            Me.FindForm().WindowState = FormWindowState.Minimized
        End If

        MyBase.OnClick(e)
    End Sub

    Protected Overrides Sub OnPaint(ByVal pevent As PaintEventArgs)
        System.Diagnostics.Trace.WriteLine(pevent.ClipRectangle.ToString())
        activeColorBrush?.Dispose()
        activeColorBrush = New SolidBrush(ActiveColor)
        pevent.Graphics.FillRectangle(New SolidBrush(ActiveColor), pevent.ClipRectangle)
        pevent.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
        activeIconColorBrush?.Dispose()
        activeIconColorPen?.Dispose()
        activeIconColorBrush = New SolidBrush(ActiveIconColor)
        activeIconColorPen = New Pen(activeIconColorBrush, 1.0F)

        If ButtonType = Type.Close Then
            drawCloseIcon(pevent, New Rectangle(0, 0, Me.Width, Me.Height))
        ElseIf ButtonType = Type.Maximize Then
            drawMaximizeIcon(pevent, New Rectangle(0, 0, Me.Width, Me.Height))
        Else
            drawMinimizeIcon(pevent, New Rectangle(0, 0, Me.Width, Me.Height))
        End If
    End Sub

    Protected Overridable Sub drawCloseIcon(ByVal e As PaintEventArgs, ByVal drawRect As Rectangle)
        e.Graphics.DrawLine(activeIconColorPen, CSng(drawRect.X + drawRect.Width / 2 - 5), CSng(drawRect.Y + drawRect.Height / 2 - 5), CSng(drawRect.X + drawRect.Width / 2 + 5), CSng(drawRect.Y + drawRect.Height / 2 + 5))
        e.Graphics.DrawLine(activeIconColorPen, CSng(drawRect.X + drawRect.Width / 2 - 5), CSng(drawRect.Y + drawRect.Height / 2 + 5), CSng(drawRect.X + drawRect.Width / 2 + 5), CSng(drawRect.Y + drawRect.Height / 2 - 5))
    End Sub

    Protected Overridable Sub drawMaximizeIcon(ByVal e As PaintEventArgs, ByVal drawRect As Rectangle)
        If Me.FindForm().WindowState = FormWindowState.Normal Then
            e.Graphics.DrawRectangle(activeIconColorPen, New Rectangle(drawRect.X + drawRect.Width / 2 - 5, drawRect.Y + drawRect.Height / 2 - 5, 10, 10))
        ElseIf Me.FindForm().WindowState = FormWindowState.Maximized Then
            e.Graphics.DrawRectangle(activeIconColorPen, New Rectangle(drawRect.X + drawRect.Width / 2 - 3, drawRect.Y + drawRect.Height / 2 - 5, 8, 8))
            Dim rect As Rectangle = New Rectangle(drawRect.X + drawRect.Width / 2 - 5, drawRect.Y + drawRect.Height / 2 - 3, 8, 8)
            e.Graphics.FillRectangle(activeIconColorBrush, rect)
            e.Graphics.DrawRectangle(activeIconColorPen, rect)
        End If
    End Sub

    Protected Overridable Sub drawMinimizeIcon(ByVal e As PaintEventArgs, ByVal drawRect As Rectangle)
        e.Graphics.DrawLine(activeIconColorPen, CSng(drawRect.X + drawRect.Width / 2 - 5), CSng(drawRect.Y + drawRect.Height / 2), CSng(drawRect.X + drawRect.Width / 2 + 5), CSng(drawRect.Y + drawRect.Height / 2))
    End Sub
End Class
