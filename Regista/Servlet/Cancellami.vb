Public Class Cancellami
    Inherits Servlet

    Public Shared ReadOnly Property GetInstance As Cancellami
        Get
            Return New Cancellami()
        End Get
    End Property

    Public Overrides Sub performRequest(ByRef richiesta As Richiesta, ByRef risposta As Risposta)
        Dim utente As String = richiesta.Parametri(ClientUnitools.KEY_UTENTE)

        Centralino.ClientUnitoolsList.RemoveAll(Function(client) client.Utente = utente)
        risposta.RispondiOK("Cancellazione OK!")

    End Sub
End Class
