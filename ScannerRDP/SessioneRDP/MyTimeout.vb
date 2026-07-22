Imports System.Timers

Public Class MyTimeout

    Public Event Timeout()

    Private WithEvents Timer1 As Timer

    ''' <summary>
    ''' Crea il timer
    ''' </summary>
    ''' <param name="Timeout">Timeout in millisecondi</param>
    ''' <remarks></remarks>
    Sub New(Timeout As Integer)

        Timer1 = New Timer
        Timer1.Interval = Timeout
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Elapsed(sender As Object, e As System.Timers.ElapsedEventArgs) Handles Timer1.Elapsed
        'fermo il timer e genero l'evento timeout
        Timer1.Enabled = False
        RaiseEvent Timeout()
    End Sub

End Class
