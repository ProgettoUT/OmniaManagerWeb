Public Class ElencoClient
    Inherits Servlet

    Public Shared ReadOnly Property GetInstance As ElencoClient
        Get
            Return New ElencoClient()
        End Get
    End Property

    Public Overrides Sub performRequest(ByRef richiesta As Richiesta, ByRef risposta As Risposta)
        Dim lista As New Text.StringBuilder
        lista.AppendLine("Numero client connessi: " & Centralino.ClientUnitoolsList.Count)
        For Each clientUnitools In Centralino.ClientUnitoolsList
            lista.AppendLine(clientUnitools.GetUrl() & " utente = " & clientUnitools.Utente & " ultimo ping (s): " & (Now.Ticks - clientUnitools.UltimaConnessione) \ 10000000)
        Next

        risposta.RispondiOK(lista.ToString)
    End Sub

End Class


