Imports System.IO

Public Class JobEsitati

    Sub New()
    End Sub

    Public ReadOnly Property Esiste() As Boolean
        Get
            Return File.Exists(Me.FullPath)
        End Get
    End Property

    Public ReadOnly Property FullPath() As String
        Get
            Return Path.Combine(Utx.Globale.Paths.CartellaSettingRete, "Esitati.Job")
        End Get
    End Property

    Public Function Salva(ByRef Opzioni As ConfigScaricoIncassi) As Boolean
        Try
            'salvo job
            Dim ser As New Xml.Serialization.XmlSerializer(GetType(ConfigScaricoIncassi))
            Using fs As New StreamWriter(Me.FullPath)
                ser.Serialize(fs, Opzioni)
            End Using
            Return True
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Function Leggi() As ConfigScaricoIncassi
        Try
            'deserializzo leggendo le opzioni di scarico e cancello il job
            Dim ser As New Xml.Serialization.XmlSerializer(GetType(ExportLib.ConfigScaricoIncassi))
            Using fs As New StreamReader(Me.FullPath)
                Return ser.Deserialize(fs)
            End Using
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Public Sub Esegui()
        Try
            'se c'è il consenso on-line
            Dim s As New Utx.SettingAgenzia.ConfiguraSede
            s.Proxy = Utx.Globale.UniProxy.Proxy
            If s.ConsensoOnLine(Utx.Enumerazioni.TipoOperazioneOnLine.ESSIG_ON_DEMAND, Utx.Globale.AgenziaRichiesta.CodiceAgenzia, Utx.NetFunc.GuidUtente) = True Then
                'eseguo il job
                Try
                    Dim az As New ExportLib.Azioni
                    az.OpzioniScarico = Me.Leggi
                    Me.Elimina()

                    Globale.Log.Info(String.Format("Eseguo job. Inizio periodo: {0:d}", az.OpzioniScarico.InizioPeriodo))

                    az.RiletturaFileIncassi()
                    az.OpzioniScarico.ScaricaFile = False 'sono stati già scaricati
                    az.AggiornaIncassi()
                    az.AggiornaVariazioni()
                    az.ChiudiNotifica()
                Catch ex As Exception
                    Globale.Log.Errore(ex)
                End Try
            Else
                Globale.Log.Info("Consenso on-line negato per raggiundimento numero max utenti")
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Shared Sub Controllo()
        Utx.Globale.Log.Info("Controllo job esitati")
        'se siamo nella fascia oraria consentita
        If FasciaOrariaConsentita() = True Then
            Dim Job As New ExportLib.JobEsitati
            'se esiste il job
            If Job.Esiste Then Job.Esegui()
        End If
    End Sub

    Public Sub Elimina()
        File.Delete(Me.FullPath)
    End Sub

    Public Shared Sub Messaggio()
        MsgBox(String.Format("L'operazione richiesta può essere eseguita nelle seguenti fasce orarie:{0}{0}" +
                             "dalle 07:00 alle 09:00{0}dalle 13:00 alle 14:30{0}dalle 19:00 alle 21:00{0}{0}" +
                             "L'operazione è stata programmata e verrà automaticamente eseguita nelle fasce orarie consentite se Unitools sarà in esecuzione",
                     Environment.NewLine), MsgBoxStyle.Information, Utx.Globale.TitoloApp)
    End Sub

    Public Shared Function FasciaOrariaConsentita() As Boolean
        Try
#If DEBUG Then
            'Return True
#End If
            Select Case Now.TimeOfDay.TotalHours
                Case 7 To 9, 13 To 14.5, 19 To 21
                    Return True
                Case Else
                    Return False
            End Select
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Shared Function ConsensoFasceOrarie(InizioPeriodo As Date) As Boolean
        Try
            'per intervalli superiori a un mese (2 accessi) restrizione sulle fasce orarie
            If DateDiff(DateInterval.Day, InizioPeriodo, Today) <= 30 Then
                Return True
            Else
                Return JobEsitati.FasciaOrariaConsentita = True
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function
End Class
