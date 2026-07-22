Imports System.Net
Imports System.IO

Public Class Centralino
    Inherits Servlet

    Public Shared ReadOnly Property GetInstance As Centralino
        Get
            Return New Centralino()
        End Get
    End Property


    Public Shared ClientUnitoolsList As New List(Of ClientUnitools)

    Public Overrides Sub performRequest(ByRef richiesta As Richiesta, ByRef risposta As Risposta)
        Dim active_user As String = richiesta.Parametri("active_user")

        'ListenerTcp.Log.Debug("active_user = " & active_user)

        'Dall'interno ricavo il client connesso
        Dim clientUnitools As ClientUnitools = ClientUnitoolsList.Find(Function(p) p.Interno = active_user)

        If clientUnitools IsNot Nothing Then
            giraChiamata(clientUnitools, richiesta)
            risposta.RispondiOK("Chiamata inoltrata a " & active_user)
            'ElseIf ClientUnitoolsList.Count > 0 Then
            '    ' notifico a tutti i client registrati 
            '    For Each clientUnitools In ClientUnitoolsList
            '        giraChiamata(clientUnitools, richiesta)
            '    Next
            'Else
            '    Dim client As New ClientUnitools
            '    client.IndirizzoCallback = "UNKNOWN"
            '    client.PortaCallback = 19999
            '    giraChiamata(client, richiesta)
        Else
            risposta.RispondiOK("Unitools non attivo per " & active_user)
        End If

    End Sub

    Private Sub giraChiamata(clientUnitools As ClientUnitools, ByRef richiesta As Richiesta)
        Dim url As String = clientUnitools.GetUrl("Telefono", richiesta.getQuerystring())
        ListenerFile.Invia(url)
    End Sub
End Class
