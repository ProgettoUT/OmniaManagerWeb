Namespace Essig
    <Serializable()> Public Class Esito
        <NonSerialized> Public Messaggio As String
        <NonSerialized> Public ErrorCode As Integer

        Public PremioAnnuoLordo As Decimal
        <NonSerialized> Public Params As List(Of KeyValuePair(Of String, String))

        Public Sub New()
            ErrorCode = 0 ' nessun errore
        End Sub
        Public Sub New(messaggio As String)
            Me.Messaggio = messaggio
            ErrorCode = -1 ' errore generico
        End Sub

        Public Sub New(ErrorCode As Integer, messaggio As String)
            Me.ErrorCode = ErrorCode 'errore > 0 errore gestito
            Me.Messaggio = messaggio
        End Sub

        Public Sub InviaEmail(preventivo As Prodotto)
            If Math.Abs(PremioAnnuoLordo - preventivo.PremioAnnuo) > 0D Then
                preventivo.EssigEsito = Me
                Dim emailMe As New EmailLog
                emailMe.Add(preventivo)
                Application.DoEvents()
            End If
        End Sub

        Public Shared Function Errore(Messaggio As String) As Esito
            Return New Esito(Messaggio)
        End Function
    End Class
End Namespace
