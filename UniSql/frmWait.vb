Imports System.Drawing

Public Class frmWait
    Private valore As Integer

    Public Property Value() As Integer
        Get
            Return valore
        End Get
        Set(value As Integer)
            valore = value
            ProgressBar1.Value = valore
            'Me.Opacity = 0.6 + valore * 0.3 / ProgressBar1.Maximum
        End Set
    End Property
End Class