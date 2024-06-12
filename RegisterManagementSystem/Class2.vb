Imports System.ComponentModel

<ToolboxItem(GetType(NoFocusCueBotton))>
Public Class NoFocusCueBotton
    Inherits Button

    Protected Overrides ReadOnly Property ShowFocusCues As Boolean
        Get
            Return False
        End Get
    End Property

    Public Sub New()
    End Sub

    Public Overrides Sub NotifyDefault(ByVal value As Boolean)
        MyBase.NotifyDefault(False)
    End Sub
End Class
