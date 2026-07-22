Public Class ClientUnitools
    Public Const KEY_INTERNO As String = "Interno"
    Public Const KEY_UTENTE As String = "Utente"
    Public Const KEY_INDIRIZZOCALLBACK As String = "IndirizzoCallback"
    Public Const KEY_PORTACALLBACK As String = "PortaCallback"

    Public Interno As String
    Public Utente As String
    Public IndirizzoCallback As String
    Public PortaCallback As Integer
    Public UltimaConnessione As Long

    Public Overrides Function ToString() As String
        Return IndirizzoCallback & ":" & PortaCallback & "\" & Utente & "(" & Interno & ")"
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Dim altro As ClientUnitools = CType(obj, ClientUnitools)

        If Me.Utente = altro.Utente AndAlso
            Me.Interno = altro.Interno AndAlso
            Me.IndirizzoCallback = altro.IndirizzoCallback AndAlso
            Me.PortaCallback = altro.PortaCallback Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetUrl(Optional ambito As String = "", Optional querystring As String = Nothing) As String
        Dim url As String = "http://" & IndirizzoCallback & ":" & PortaCallback & "/" & ambito

        If Not String.IsNullOrEmpty(querystring) Then
            If Not querystring.StartsWith("?") Then
                url &= "?"
            End If
            url &= querystring
        End If
        Return url
    End Function

End Class
