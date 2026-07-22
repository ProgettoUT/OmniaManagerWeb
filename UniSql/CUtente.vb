Public Class CUtente
    Public Enum RuoloEnum
        Agente
        Collaboratore
    End Enum
    Private ruolo As RuoloEnum

    Public Sub New()
        If Utx.Globale.UtenteCorrente.Ruolo.StartsWith("AG") Then
            ruolo = RuoloEnum.Agente
        Else
            ruolo = RuoloEnum.Collaboratore
        End If
    End Sub

    Public Function IsAdmin() As Boolean
        'Return (ruolo = RuoloEnum.Agente)
        Return False
    End Function

    Public Function Profili() As String()
        If ruolo = RuoloEnum.Agente Then
            Return {PRF_TUTTI, PRF_AGENTE}
        Else
            Return {PRF_TUTTI, PRF_COLLABORATORE}
        End If
    End Function

    Public Sub MessaggioNotAutorizzato()
        MsgBox("Utente non autorizzato.", vbCritical, Utx.Globale.TitoloApp)
    End Sub

    Public Function AutorizzatoAdEsportare(manifesto As CManifesto, conMessaggio As Boolean) As Boolean
        If AutorizzatoAdEsportare(manifesto) Then
            Return True
        ElseIf conMessaggio = True Then
            MessaggioNotAutorizzato()
        End If
        Return False
    End Function

    Public Function AutorizzatoAdEsportare(manifesto As CManifesto) As Boolean
        If (mgrPrf.CastPrf(manifesto).GetAutorizzazioni(Me) And EAutType.AUT_ESPORTAZIONE) = EAutType.AUT_ESPORTAZIONE Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function AutorizzatoAdLeggere(manifesto As CManifesto) As Boolean
        If (mgrPrf.CastPrf(manifesto).GetAutorizzazioni(Me) And EAutType.AUT_LETTURA) = EAutType.AUT_LETTURA Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
