Public Class Telefono
    Inherits Servlet

    Public Event ChiamataInArrivo(Parametri As Dictionary(Of String, String))

    Public Shared ReadOnly Property GetInstance As Telefono
        Get
            Static _instance As Telefono
            If _instance Is Nothing Then
                _instance = New Telefono()
            End If
            Return _instance
        End Get
    End Property

    'questa chiamata viene fatta dal centralino unitools 
    Public Overrides Sub performRequest(ByRef richiesta As Richiesta, ByRef risposta As Risposta)
        RaiseEvent ChiamataInArrivo(richiesta.Parametri)
        risposta.RispondiOK("Chiamata notificata correttamente al client " & richiesta.Parametri("active_user"))
    End Sub
End Class
