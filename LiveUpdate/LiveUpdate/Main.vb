Option Compare Text

Imports System.IO
Imports System.Net
Imports System.Xml
Imports System.Data.OleDb

Public Module Main

    Friend WithEvents IconaNotifica As New NotifyIcon
    Public Log As Utx.ApplicationLog

    Private DestUpdate As String
    Private FlagUscita As Boolean
    Private ConfigAgenzia As New Utx.SettingAgenzia.DatiAgenzia
    Private Const UrlBase As String = "http://www.utools.it/Unitools/Update/"
    Private SettingLiveUpdate As Utx.ApplicationUserSetting
    Private WithEvents TimerChiusura As Timer
    Private CodiceAgenzia As String

    Public Sub ControlloAggiornamenti(IdApp As String,
                                      Utente As String,
                                      Optional Forzatura As Boolean = False)
        Try
            CodiceAgenzia = Utx.FunzioniAmbiente.UserToAgenzia(Utente)

            Log = New Utx.ApplicationLog("LiveUpdate.log")

            'controlla se c'è un'altra istanza in esecuzione
            If Utx.NetFunc.AltraIstanza(Diagnostics.Process.GetCurrentProcess.ProcessName, ProcessoAvviato:=True) Then
                Log.Info("altra istanza in esecuzione, attendo 5 secondi")
                Threading.Thread.Sleep(5000)
            End If

            Log.Info("Avvio LiveUpdate (DLL) " + Utx.NetFunc.VersioneModulo("LiveUpdate.dll"))
            Log.Info("Agenzia madre: " + CodiceAgenzia)
            Log.Info("Utente Pc    : " + Environment.UserName)
            Log.Info("Utente uniage: " + Utente)
            Log.Info("Ambiente     : " + Utx.Setting.Ambiente.ToString)
            Log.Info("Id App       : " + IdApp)

            'destinazione dell'eventuale download
            'controllo esistenza cartelle di destinazione del download
            If Utx.Setting.Ambiente = Utx.Enumerazioni.TipoAmbiente.PP Then
                DestUpdate = Utx.Globale.Paths.CartellaUpdateLocale
            Else
                DestUpdate = Utx.Globale.Paths.CartellaUnitoolsRete
            End If
            Log.Info("Destinazione update: " + DestUpdate)

            'controllo componenti
            If ControlloComponenti(IdApp, Forzatura) = True Then
                Log.Info("Controllo componenti completata correttamente")
            Else
                Log.Info("Controllo componenti con errori")
            End If

            IconaNotifica.Dispose()
            If TimerChiusura IsNot Nothing Then
                TimerChiusura.Dispose()
            End If

            Log.Info("Controllo update completato.")
            Log.Info()

        Catch ex As Exception
            Log.Info(ex)
        End Try
    End Sub

    Private Sub NotificaCorrezioniEffettuate()
        If Command().ToUpper <> "HIDE" Then
            With IconaNotifica
                .Icon = My.Resources.liveupdate
                .Visible = True
                .ShowBalloonTip(10000, "Unitools",
                            String.Format("Sono stati apportati dei miglioramenti all'installazione di Unitools.{0}{0}" +
                                          "Modifiche apportate:{0}{1}",
                                          Environment.NewLine, Versione.ComponentiModificati), ToolTipIcon.Info)
            End With

            FlagUscita = False

            Do While FlagUscita = False
                Application.DoEvents()
            Loop
        End If
    End Sub

    Private Sub NotificaRiavvio()
#If DEBUG Then
        Console.Beep(600, 600)
#End If
        If Command().ToUpper <> "HIDE" Then
            TimerChiusura = New Timer With {.Interval = 30000, .Enabled = True}

            Dim Notifica As New Utx.FormNotifica
            With Notifica
                .ColoreSfondo = Color.Yellow
                .Opacity = 1
                .LabelMessaggio.Font = Utx.AppFont.Bold
                .OnClickClose = True
                .Messaggio = String.Format("E' necessario riavviare OmniaManager per rendere effettivi gli aggiornamenti scaricati{0}{0}Clicca qui per chiudere questo avviso", Environment.NewLine)
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub IconaNotifica_BalloonTipClicked(sender As Object, e As System.EventArgs) Handles IconaNotifica.BalloonTipClicked
        FlagUscita = True
    End Sub

    Private Sub IconaNotifica_BalloonTipClosed(sender As Object, e As System.EventArgs) Handles IconaNotifica.BalloonTipClosed
        FlagUscita = True
    End Sub

    Private Sub IconaNotifica_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles IconaNotifica.MouseClick
        FlagUscita = True
    End Sub

    Private Function ControlloComponenti(IdApp As String, Forzatura As Boolean) As Boolean
        Try
            Log.Info("Controllo componenti")

            Versione.IdVersioneCorrente = "OM"
            Const VersioneDeposito As String = "001"

            Log.Info($"Versione deposito: {VersioneDeposito}")

            'se trova il file di blocco (Controllo.OFF) non effettua il controllo
            If AggiornamentiBloccati() = True Then
                Log.Info("Controllo componenti disabilitato")
                Return True
            End If

            'definisco il deposito origine sul server da cui fare il download dei file
            Dim Destinazione As New DepositoLocale(VersioneDeposito)

            Log.Info(Destinazione.PathCorrezioni)
            Log.Info(Destinazione.PathDeposito)
            Log.Info(Destinazione.PathDepositoDIR)
            Log.Info(Destinazione.PathDepositoPP)
            Log.Info(Utx.Globale.Paths.CartellaUpdateLocale)

            'se il deposito non è disponibile genero un'eccezione
            If Destinazione.IsReady = False Then Throw New Exception

            'se non esiste il file di versione deposito nella cartella cancella tutto
            If Not File.Exists(Destinazione.FileversioneDeposito) Then
                SvuotaDir(Destinazione.PathDeposito)
            End If

            'pulire la cartella destinazione delle correzioni per assicurare la congruità del risultato
            SvuotaDir(Destinazione.PathCorrezioni)

            'il setting deve stare nella cartella locale perché riguarda l'aggiornamento del pc
            SettingLiveUpdate = New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.EXTRA, "LiveUpdate", Utx.Globale.Paths.CartellaSetting)
            'controllo MD5 database
            Dim MD5UltimoControllo As String = SettingLiveUpdate.LeggiValore("DB_MD5", "")
            Dim DataUltimoControllo As Date = SettingLiveUpdate.LeggiValore("ULTIMO_AGGIORNAMENTO", "01/01/1900")
            Log.Info($"Ultimo controllo: {DataUltimoControllo} - {MD5UltimoControllo}")

#If DEBUG Then
            Log.Info("Forzatura controllo componenti")
            MD5UltimoControllo = ""
#Else
            'gestione  eccezioni
            If Forzatura = True Then
                'se c'è forzatura 
                Log.Info("Forzatura controllo componenti")
                MD5UltimoControllo = ""
            ElseIf DataUltimoControllo.Date < Today Then
                'faccio almeno un controllo al giorno
                Log.Info("Controllo giornaliero")
                MD5UltimoControllo = ""
            End If
#End If
            'qui chiamo il servizio che mi restituisce il dataset di versione
            Dim Errore As String = ""

            'i dati restituiti sono già relativi al livello dell'agenzia, alla versione corrente e al tipo di ambiente
            Dim Esito As New Utx.SettingAgenzia.EsitoServizio

            ConfigAgenzia.Livello = Utx.NetFunc.GetEnvironmentVar("UNITOOLS_LIVEUP_LIVELLO") 'per livelli specifici tipo "ASSEGNI"

            Dim dsVersione As DataSet
            Using s As New Utx.SettingAgenzia.ConfiguraSede
                s.Proxy = Utx.Globale.UniProxy.Proxy
                'attenzione: l'ambiente va trasmesso come stringa (DIR/PP)
                dsVersione = s.VersioneLivello_0422(1,
                                                    CodiceAgenzia,
                                                    Versione.IdVersioneCorrente,
                                                    Globale.Ambiente.Tipo.ToString,
                                                    IdApp,
                                                    ConfigAgenzia,
                                                    Esito, MD5UltimoControllo)

            End Using
#If DEBUG Then
            ''per debug visualizza i dati restituiti dal ws
            'Dim f As New Utx.FormDebug
            'For Each t As DataTable In dsVersione.Tables
            '    f.OrigineDati = t
            '    f.ShowDialog()
            'Next
#End If

            'controllo se si sono verificati errori
            If Esito.EsitoChiamata = False Then
                Log.Info($"* Errore nel recupero dei dati della versione: {Esito.MessaggioErrore}")
                Manutenzione.CancellaFileUTOLD()
                Return True
            End If

            If dsVersione Is Nothing Then
                Log.Info("Controllo componenti non necessario: nessun aggiornamento presente")
                Manutenzione.CancellaFileUTOLD()
                Return True
            End If

            Log.Info($"MD5 server: {dsVersione.DataSetName}")
            Log.Info($"Livello agenzia: {ConfigAgenzia.Livello}")

            'controllo file old/utold
            Manutenzione.CancellaFileOld(dsVersione.Tables("FileDaEliminare"))
            'controllo cartelle old
            Manutenzione.CancellaCartelleOld(dsVersione.Tables("CartelleDaEliminare"))

            Log.Info("Avvio controllo componenti:")

            'controllo versioni
            Versione.ComponentiControllati = 0

            Log.AumentaRientro()

            'cicla su tutte le righe della tabella: ogni riga un componente
            'i componenti sono già stati selezionati sul server per tipo ambiente e tipo agenzia
            Destinazione.SvuotaRollback()

            For Each dr As DataRow In dsVersione.Tables("Versione").Rows

                Dim Modulo As New Componente(Destinazione, dr)
                Modulo.AnalisiComponente()

                'se c'è un errore faccio il rollback
                If Modulo.ErroreInstallazione = True Then
                    Rollback(Destinazione, dsVersione)
                    Destinazione.SvuotaRollback()
                    'scrivo nell'xml in modo che al prossimo riavvio ci sia un nuovo tentativo
                    SettingLiveUpdate.AggiungiModifica("DB_MD5", "ERRORE")
                    SettingLiveUpdate.AggiungiModifica("ULTIMO_AGGIORNAMENTO", Format(Now, "dd/MM/yyyy HH:mm:ss"))
                    SettingLiveUpdate.AggiungiModifica("UTENTE_PC", Environment.UserName)
                    Exit Try
                End If

                Versione.ComponentiControllati += 1
            Next

            Destinazione.SvuotaRollback()

            Log.DiminuisciRientro()
            Log.Info($"Componenti controllati: {Versione.ComponentiControllati}")
            Log.Info($"Componenti in attesa  : {Versione.ComponentiInAttesa}")
            Log.Info($"Componenti installati : {Versione.ComponentiInstallati.Count}")
            Log.AumentaRientro()

            For Each comp As String In Versione.ComponentiInstallati
                Log.Info(comp)
            Next
            Log.DiminuisciRientro()

            'notifiche
            If (Versione.ComponentiInstallati.Count > 0) Then
                NotificaCorrezioniEffettuate()
                NotificaRiavvio()
                Log.Info("Controllo componenti concluso correttamente")
                'creo il flag che chiede il riavvio
                File.WriteAllText($"{Utx.Globale.Paths.CartellaFlag}\Riavvio", Format(Now, "dd/MM/yyy HH:mm:ss"))
            Else
                Log.Info("Controllo componenti concluso correttamente")
            End If

            'scrivo il file di controllo della versione per il deposito componenti
            File.AppendAllText(Path.Combine(Destinazione.PathDeposito, VersioneDeposito + ".cc"), $"[{Now:G}] controllo componenti{Environment.NewLine}")

            SettingLiveUpdate.AggiungiModifica("DB_MD5", dsVersione.DataSetName)
            SettingLiveUpdate.AggiungiModifica("ULTIMO_AGGIORNAMENTO", Format(Now, "dd/MM/yyyy HH:mm:ss"))
            SettingLiveUpdate.AggiungiModifica("UTENTE_PC", Environment.UserName)

            'se non ci sono correzioni/file in attesa ritorno true (tutto già fatto)
            Return (Versione.ComponentiInAttesa = 0)

        Catch ex As Exception
            Log.Info($"Controllo componenti concluso con errori: {ex.Message}")
            Return True
        End Try
    End Function

    Private Sub Rollback(Destinazione As DepositoLocale, ByRef dsVersione As DataSet)
        Try
            Log.Info("*** ATTENZIONE: Rollback aggiornamento")

            For Each dr As DataRow In dsVersione.Tables("Versione").Rows
                Dim Modulo As New Componente(Destinazione, dr)
                Modulo.RollbackComponente()
            Next

        Catch ex As Exception
            Log.Info(ex)
        End Try
    End Sub

    Private Function AggiornamentiBloccati() As Boolean
        If File.Exists(FileControlloUpdate) Then
            Dim Fine As String = Microsoft.VisualBasic.Right(File.ReadAllText(FileControlloUpdate), 10)
            'se è passata la data limite del blocco
            If IsDate(Fine) AndAlso (CDate(Fine)) < Today Then
                File.Delete(FileControlloUpdate)
            End If
            Return File.Exists(FileControlloUpdate)
        Else
            Return False
        End If
    End Function

    Private Function FileControlloUpdate()
        Return $"{Utx.Globale.Paths.CartellaUpdateLocale}\Versioni\Controllo.OFF"
    End Function

    Private Function PathBag() As String
        Return Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "Utx.Bag")
    End Function

    Private Sub TimerChiusura_Tick(sender As Object, e As EventArgs) Handles TimerChiusura.Tick
        Application.Exit()
    End Sub
End Module
