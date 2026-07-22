Public Class Ping
    Inherits Servlet

    Public Shared ReadOnly Property GetInstance As Ping
        Get
            Return New Ping()
        End Get
    End Property

    Public Overrides Sub performRequest(ByRef richiesta As Richiesta, ByRef risposta As Risposta)
        risposta.RispondiOK("OK")
    End Sub

End Class
