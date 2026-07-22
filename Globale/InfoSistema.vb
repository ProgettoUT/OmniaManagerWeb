Imports System.Windows.Forms

Public Class InfoSistema

    Public Class Desktop

        Public Shared ReadOnly Property Altezza() As String
            Get
                Return Screen.PrimaryScreen.WorkingArea.Height
            End Get
        End Property

        Public Shared ReadOnly Property Larghezza() As String
            Get
                Return Screen.PrimaryScreen.WorkingArea.Width
            End Get
        End Property
    End Class
End Class
