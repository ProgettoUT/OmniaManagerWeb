Imports System.Timers

Public Class MyTimeout

    Public Event Timeout()

    ''' <summary>
    ''' Crea un timeout personalizzato
    ''' </summary>
    ''' <param name="Millisecondi">Timeout in millisecondi</param>
    ''' <remarks></remarks>
    Sub New(Millisecondi As Integer)
        Dim nt As New Threading.Thread(Sub()
                                           Threading.Thread.Sleep(Millisecondi)
                                           RaiseEvent Timeout()
                                       End Sub)
        nt.Start()
    End Sub
End Class
