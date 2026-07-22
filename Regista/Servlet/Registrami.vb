Public Class Registrami
    Inherits Servlet

    Public Shared ReadOnly Property GetInstance As Registrami
        Get
            Return New Registrami()
        End Get
    End Property

    Public Overrides Sub performRequest(ByRef richiesta As Richiesta, ByRef risposta As Risposta)
        Dim client As New ClientUnitools
        client.Interno = richiesta.Parametri(ClientUnitools.KEY_INTERNO)
        client.Utente = richiesta.Parametri(ClientUnitools.KEY_UTENTE)
        client.IndirizzoCallback = richiesta.Parametri(ClientUnitools.KEY_INDIRIZZOCALLBACK)
        client.PortaCallback = CInt(richiesta.Parametri(ClientUnitools.KEY_PORTACALLBACK))
        client.UltimaConnessione = Now.Ticks 'numero di secondi

        'todo: in un secondo momento si può mettere un controllo
        'per verificare che il client sia raggiungibile


        'Altro controllo: verificare che il client sia già registrato
        Centralino.ClientUnitoolsList.RemoveAll(Function(c) c.Utente = client.Utente)
        Centralino.ClientUnitoolsList.Add(client)

        risposta.RispondiOK("Registrazione OK!")
    End Sub

End Class


