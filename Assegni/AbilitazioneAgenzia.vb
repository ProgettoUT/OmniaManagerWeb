
Public Class AbilitazioneAgenzia

    Public Enum StatoAgenzia
        ATTIVATA = 101 'attivata
        NON_ATTIVA = 102 'pagata licenza ma non ha attivato
        DEMO = 103 'demo
        BLOCCATA = 104 'non ha comprato la licenza
    End Enum

    Public Enum CodiceErrore
        OK = 0 'ok nessun errore
        NO_DATI = 1 'anagrafica agenzia non trovata
        NO_CODICE_AGENZIA = 2 'richiesta errata senza codice agenzia
    End Enum

    Public Structure DatiLicenza
        Dim PingLicenza As String 'md5
        Dim ScadenzaLicenza As String 'md5
        Dim Scadenza As Date
    End Structure

    Public Esito As LicenzeUniarea.Esito

    Sub New(ByVal Agenzia As String)
        Try
            mAgenzia = Agenzia

            Using UniareaAssegni As New LicenzeUniarea.Assegni

                'configuro il proxy
                UniareaAssegni.Proxy = Utx.Globale.UniProxy.Proxy
                UniareaAssegni.Timeout = 10000

                'controllo lo stato della licenza
                Esito = UniareaAssegni.controllaLicenza(mAgenzia)
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex, False)
        End Try
    End Sub

    Private mAgenzia As String
    Public ReadOnly Property Agenzia() As String
        Get
            Return mAgenzia
        End Get
    End Property

    Public Sub AttivaLicenzaUniarea()
        Try
            Using UniareaAssegni As New LicenzeUniarea.Assegni

                'configuro il proxy
                UniareaAssegni.Proxy = Utx.Globale.UniProxy.Proxy
                UniareaAssegni.Timeout = 10000

                Esito = UniareaAssegni.attivaLicenza(mAgenzia)

                If Esito.Errore Is Nothing Then
                    MsgBox("Impossibile contattare il server Uniarea.", MsgBoxStyle.Exclamation, Globale.TitoloApp)
                    Globale.Log.Info("Impossibile contattare il server Uniarea.")
                ElseIf Esito.Errore = CodiceErrore.OK Then
                    Globale.Log.Info("Licenza Uniarea attivata")
                Else
                    Globale.Log.Info(Esito.Messaggio)
                End If
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

End Class
