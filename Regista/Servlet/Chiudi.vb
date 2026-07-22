Public Class Chiudi
    Inherits Servlet

    Public Shared ReadOnly Property GetInstance As Chiudi
        Get
            Return New Chiudi()
        End Get
    End Property

    Public Overrides Sub performRequest(ByRef richiesta As Richiesta, ByRef risposta As Risposta)
        If ListenerTcp.Instance IsNot Nothing Then
            ListenerTcp.Instance.StopListener = True

            For Each clientUnitools In Centralino.ClientUnitoolsList
                'in modalita asincrona si crea un problema
                ListenerFile.Invia(clientUnitools.GetUrl("Chiudi"))
            Next
        End If
        risposta.RispondiOK(String.Format("{0} - Ricevuto Stop", ListenerTcp.ExeName))
    End Sub

End Class


