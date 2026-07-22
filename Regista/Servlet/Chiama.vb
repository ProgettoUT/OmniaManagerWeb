Public Class Chiama
    Inherits Servlet

    Public Shared ReadOnly Property GetInstance As Chiama
        Get
            Static _instance As Chiama
            If _instance Is Nothing Then
                _instance = New Chiama()
            End If
            Return _instance
        End Get
    End Property

    'questa chiamata viene fatta dal centralino unitools 
    Public Overrides Sub performRequest(ByRef richiesta As Richiesta, ByRef risposta As Risposta)

        Dim LinkToCall As String = "http://admin:{0}@{1}/cgi-bin/cgiServer.exx?key={2}OK"

        Dim Link As String = String.Format(LinkToCall, richiesta.Parametri("password"), richiesta.Parametri("ip"), richiesta.Parametri("numero"))
        ListenerTcp.CallWebAsync(Link)
        risposta.RispondiOK("Chiamata inoltrata al telefono " & richiesta.Parametri("ip"))
    End Sub

End Class
