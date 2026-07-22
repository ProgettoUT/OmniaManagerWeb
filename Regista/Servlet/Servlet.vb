Imports System.Net
Imports System.IO

Public MustInherit Class Servlet

    Public MustOverride Sub performRequest(ByRef richiesta As Richiesta, ByRef risposta As Risposta)

End Class
