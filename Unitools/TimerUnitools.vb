Imports System.Timers
Imports System.ComponentModel

Public Class TimerUnitools

    Private ReadOnly Log As New Utx.ApplicationLog("Interop.log")

    Public WithEvents bw As New BackgroundWorker
    Public Const IntervalloStandardTimer As Integer = 120000 '2 minuti

    Private WithEvents Timer1 As New Timer
    Private WithEvents Postalizzazione As UniCom.Postalizzazione
    Private BloccoTimer As Utx.Sessione.Blocco
    Private WithEvents Esporta As UniFeed.Esporta
    Private Notifica As Utx.FormNotifica

    Public Event Chiusura()

    Sub New()
        Me.IntervalloTimer = 15000 'prima attivazione dopo 15 secondi
        Timer1.Enabled = True
        Utx.Globale.SessioneCorrente.ProssimoControlloTimerUnitools = Now.AddMilliseconds(Timer1.Interval)

        'attività da controllare solo all'avvio
        Dim nt As New Threading.Thread(Sub()
#If Not DEBUG Then
                                           Utx.Servizi.AvviaComunicazioni()
                                           'aggiornamento web del file liveupdate. deve stare qui a setting interop già inizializzato
                                           Utx.Servizi.AggiornaLiveUpdate()
                                           'InviaDatiAnag() 'disattivato il 14/02/2024
                                           Using s As New Utx.ServiziOMW.ServizioDatiOMW
                                               s.Proxy = Utx.Globale.UniProxy.Proxy
                                               s.SettingBackup(IO.File.ReadAllBytes(Utx.Globale.SettingGlobale.FileSetting),
                                                               Utx.Globale.AgenziaRichiesta.CodiceAgenzia, Utx.Globale.Token)
                                           End Using
                                           'InviaDatiDocumenti()
#End If
                                           Utx.Servizi.AggiornaLiveUpdate()
                                           'Utx.Utente.CancellaUtentiScaduti()
                                           UnitoolsDocumenti.DocumentiUpload.AggiornaXml()
                                           ImportazioneListeRete()
                                           AvvisoPostalizzazioneManuale()
                                       End Sub)
        nt.SetApartmentState(Threading.ApartmentState.STA)
        nt.Start()
    End Sub

    Public Sub Close()
        bw.Dispose()
        Timer1.Dispose()
    End Sub

    Public Property TimerAbilitato() As Boolean
        Get
            Return Timer1.Enabled
        End Get
        Set(value As Boolean)
            Timer1.Enabled = value
        End Set
    End Property

    Private _IntervalloTimer As Integer
    Public Property IntervalloTimer() As Integer
        Get
            Return _IntervalloTimer
        End Get
        Set(value As Integer)
            _IntervalloTimer = value
            Timer1.Interval = _IntervalloTimer
        End Set
    End Property

    Public Sub ForzaTimer()
        On Error Resume Next
        Utx.Globale.Log.Info("background worker occupato: {0}", {bw.IsBusy})
        If bw.IsBusy = False Then
            Timer1_Elapsed(Me, Nothing)
        End If
    End Sub

    Private Sub Timer1_Elapsed(sender As Object, e As ElapsedEventArgs) Handles Timer1.Elapsed
        On Error Resume Next
        If Utx.Globale.SessioneCorrente.Chiusura = True Then
            RaiseEvent Chiusura()
            Exit Sub
        End If

        Dim nt As New Threading.Thread(AddressOf AvviaTwitt)
        nt.SetApartmentState(Threading.ApartmentState.STA)
        nt.Start()

        If bw.IsBusy = False Then
            bw.RunWorkerAsync()
        End If
    End Sub

    Private Sub bw_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw.DoWork
#If DEBUG Then
        'fermo il timer
        Timer1.Enabled = False
        Utx.Globale.SessioneCorrente.CicliTimer += 1

        RefreshLogin()

        Me.IntervalloTimer = IntervalloStandardTimer
        'riavvio il timer
        Timer1.Enabled = True
        Utx.Globale.SessioneCorrente.ProssimoControlloTimerUnitools = Now.AddMilliseconds(Me.IntervalloTimer)
        If Utx.Globale.Ambiente = "TEST" Then
            Exit Sub
        End If
#End If
        'fermo il timer
        Timer1.Enabled = False
        Utx.Globale.SessioneCorrente.CicliTimer += 1

        RefreshLogin()

        'controllo blocco automatismi
        If Utx.BloccoAutomatismi.Attivo = False Then
            Try
                Utx.Globale.Log.Info("AVVIO CONTROLLI AUTOMATICI")
                'il blocco viene rimosso in bw_RunWorkerCompleted
                BloccoTimer = Utx.Globale.SessioneCorrente.AggiungiBlocco(Utx.Sessione.TipoBlocco.TIMER_UNITOOLS, "Controlli automatici")
                ControlloRiavvio()
                ControlloRichiestaChiusura()
                AnalizzaTutto() 'attualmente disabilitato

                'controlli
                ControlloAggiornamenti()

                If Utx.Globale.SessioneCorrente.RichiestaChiusura = True Then GoTo Uscita
                InvioDatiMigrazione()
                If Utx.Globale.SessioneCorrente.RichiestaChiusura = True Then GoTo Uscita
                AutoPostalizzazione()
                If Utx.Globale.SessioneCorrente.RichiestaChiusura = True Then GoTo Uscita
                ControlloSinistriControparte()
                If Utx.Globale.SessioneCorrente.RichiestaChiusura = True Then GoTo Uscita
                'ControlloImportazioniInAttesa()
                'If Utx.Globale.SessioneCorrente.RichiestaChiusura = True Then GoTo Uscita
                ExportLib.JobEsitati.Controllo()
                If Utx.Globale.SessioneCorrente.RichiestaChiusura = True Then GoTo Uscita
                'RiletturaFileIncassiAuto(CDate("01/07/2020"), CDate("09/11/2020"))
                If Utx.Globale.SessioneCorrente.RichiestaChiusura = True Then GoTo Uscita
                ImportazioneIncassi()
                If Utx.Globale.SessioneCorrente.RichiestaChiusura = True Then GoTo Uscita
                ImportazioneOmnia()
                If Utx.Globale.SessioneCorrente.RichiestaChiusura = True Then GoTo Uscita
                ImportazioneDownloadAgenzie()
                If Utx.Globale.SessioneCorrente.RichiestaChiusura = True Then GoTo Uscita
                CercaNotificheSms()
            Catch ex As Exception
                Utx.Globale.Log.Info(ex)
            End Try
Uscita:
            If Utx.Globale.SessioneCorrente.RichiestaChiusura = True Then
                Utx.Globale.Log.Info("Uscita automatismi richiesta dall'utente")
            End If
            Utx.Globale.Log.Info("FINE CONTROLLI AUTOMATICI")
        Else
            Utx.Globale.Log.Info("E' attivo il blocco degli automatismi")
        End If

        If Utx.Globale.SessioneCorrente.Nascosta = False Then
            'controlli successivi al primo (se sessione non nascosta) ogni 2 minuti
            'se la sessione è nascosta l'intervallo resta quello iniziale
            Me.IntervalloTimer = IntervalloStandardTimer
        End If
        'riavvio il timer
        Timer1.Enabled = True
        Utx.Globale.SessioneCorrente.ProssimoControlloTimerUnitools = Now.AddMilliseconds(Me.IntervalloTimer)
    End Sub

    'Private Sub ImportazioneIncassi()
    '    Utx.Globale.Log.Info("ImportazioneIncassi")
    '    'se non è domenica
    '    If Today.DayOfWeek <> DayOfWeek.Sunday Then
    '        'leggo chiave con ora prossimo controllo
    '        Dim Chiave As String = Utx.WsFlag.LeggiChiaveInterop("AUTO_INCASSI", Utx.Globale.ProfiloEnteGestore.AgenziaMadre)

    '        If (IsDate(Chiave) AndAlso Chiave < Now) OrElse (IsDate(Chiave) = False) Then
    '            'se siamo oltre la data/ora fissata per il prossimo controllo
    '            If Utx.WsFlag.EsisteFlag(Utx.Globale.ProfiloEnteGestore.AgenziaMadre, "IMPORTAZIONE_INCASSI") = False Then
    '                'creo blocco per gli altri utenti
    '                Utx.WsFlag.CreaFlag(Utx.Globale.ProfiloEnteGestore.AgenziaMadre,
    '                                    Utx.Globale.UtenteCorrente.UniageUser, "IMPORTAZIONE_INCASSI", "")

    '                'controllo se serve una rilettura dai file incassi già scaricati
    '                'ExportLib.Azioni.RiletturaIncassi(CDate("01/07/2020"))

    '                'se esiste un job non faccio la lettura
    '                Dim Job As New ExportLib.JobEsitati
    '                If Job.Esiste = False Then
    '                    'avvia processo
    '                    Dim az As New ExportLib.Azioni
    '                    If az.Login = True Then
    '                        Try
    '                            az.AggiornaIncassi()
    '                            az.AggiornaVariazioni()
    '                            az.AggiornaListeEssig()
    '                        Catch ex As Exception
    '                            Utx.Globale.Log.Errore(ex)
    '                        End Try
    '                        az.ChiudiNotifica()
    '                    Else
    '                        'in caso di errore nel login controllo automatico fra un'ora
    '                        Utx.WsFlag.SalvaChiaveInterop("AUTO_INCASSI", Now.AddHours(1).ToString, Utx.Globale.ProfiloEnteGestore.AgenziaMadre)
    '                    End If
    '                End If
    '            End If
    '            'rimuovo blocco
    '            Utx.WsFlag.EliminaFlag(Utx.Globale.ProfiloEnteGestore.AgenziaMadre, "IMPORTAZIONE_INCASSI")
    '        End If
    '    End If
    'End Sub
    Private Sub ImportazioneIncassi(Optional Forzatura As Boolean = False)
        If Utx.Globale.UtenteCorrente.Profilo.ProfiloUnipol.ToUpper <> "A" Then Exit Sub

        'leggo chiave con ora prossimo controllo
        Dim Chiave As New Utx.SettingItem(Utx.SettingItem.Sezioni.AUTOMATISMI, Utx.SettingItem.Chiavi.IMPORTAZIONE_INCASSI,
                                          Utx.SettingOMW.TipoOperazione.LETTURA)

        'se siamo oltre la data/ora fissata per il prossimo controllo
        If Chiave.ItemResult.Valore < Now OrElse Forzatura = True Then
            Utx.Globale.Log.Info("ImportazioneIncassi")
            'se non è domenica
            If Today.DayOfWeek <> DayOfWeek.Sunday Then
                'se esiste un job non faccio la lettura
                Dim Job As New ExportLib.JobEsitati
                If Job.Esiste = False Then
                    'avvia processo
                    Dim az As New ExportLib.Azioni
                    az.AggiornaIncassi()
                    'az.AggiornaVariazioni()
                    az.ChiudiNotifica()
                End If
            End If
        End If
    End Sub

    Private Sub ImportazioneOmnia()
        Dim Chiave As Utx.SettingItem
        Try
            Chiave = New Utx.SettingItem(Utx.SettingItem.Sezioni.AUTOMATISMI, Utx.SettingItem.Chiavi.IMPORTAZIONE_MA,
                                         Utx.SettingOMW.TipoOperazione.LETTURA)

            If Chiave.ItemResult.Valore < Now Then
                'controllo se è già in corso un aggiornamento
                Chiave.SetItem(Utx.SettingItem.Sezioni.INTEROP, Utx.SettingItem.Chiavi.IMPORTAZIONE_MA, "",
                               Utx.SettingOMW.TipoOperazione.LETTURA)

                If Chiave.ItemResult.Esiste = False Then
                    Utx.Globale.Log.Info("ImportazioneOmnia")

                    If Utx.SettingItem.VersioneMinima(Utx.SettingItem.Chiavi.UNIFEED) > Utx.NetFunc.DataModulo(Utx.NetFunc.VersioneModulo("unifeed.dll")).Date Then
                        Utx.Globale.Log.Info("versione modulo inferiore alla versione minima richiesta")
                        Exit Try
                    End If

                    Utx.ApplicationLog.LogUso("Importazione file MA")

                    Try
                        'creo blocco per gli altri utenti
                        Chiave.SetItem(Utx.SettingItem.Sezioni.INTEROP, Utx.SettingItem.Chiavi.IMPORTAZIONE_MA,
                               Utx.SettingItem.Valori.BLOCCO.ToString, Utx.SettingOMW.TipoOperazione.SCRITTURA)

                        'avvia processo
                        Dim ImportaFile As New UniFeed.FileIntoDatabase
                        ImportaFile.ImportaTutto()

                        'prossimo controllo fra 3 ore
                        Chiave.SetItem(Utx.SettingItem.Sezioni.AUTOMATISMI, Utx.SettingItem.Chiavi.IMPORTAZIONE_MA, Now.AddHours(6).ToString,
                               Utx.SettingOMW.TipoOperazione.SCRITTURA)

                    Catch ex As Exception
                        Utx.Globale.Log.Info(ex.Message)
                        'in caso di errore prossimo controllo fra 1 ora
                        Chiave.SetItem(Utx.SettingItem.Sezioni.AUTOMATISMI, Utx.SettingItem.Chiavi.IMPORTAZIONE_MA, Now.AddHours(1).ToString,
                               Utx.SettingOMW.TipoOperazione.SCRITTURA)
                    Finally
                        'rimuovo blocco
                        Chiave.SetItem(Utx.SettingItem.Sezioni.INTEROP, Utx.SettingItem.Chiavi.IMPORTAZIONE_MA, "",
                               Utx.SettingOMW.TipoOperazione.CANCELLAZIONE)
                    End Try
                End If
            End If

        Catch ex As Exception
            Utx.Globale.Log.Info(ex.Message)
        End Try
    End Sub

    Public Shared Sub ImportazioneOmnia(Inizio As Date, Fine As Date, TipoRecord As String, Agenzia As String)
        Dim Chiave As Utx.SettingItem
        Try
            'controllo se è già in corso un aggiornamento
            Chiave = New Utx.SettingItem(Utx.SettingItem.Sezioni.INTEROP, Utx.SettingItem.Chiavi.IMPORTAZIONE_MA,
                                         Utx.SettingOMW.TipoOperazione.LETTURA)

            If Chiave.ItemResult.Esiste = False Then
                Utx.Globale.Log.Info("ImportazioneOmnia")

                If Utx.SettingItem.VersioneMinima(Utx.SettingItem.Chiavi.UNIFEED) > Utx.NetFunc.DataModulo(Utx.NetFunc.VersioneModulo("unifeed.dll")).Date Then
                    Utx.Globale.Log.Info("versione modulo inferiore alla versione minima richiesta")
                    Exit Try
                End If

                Utx.ApplicationLog.LogUso("Importazione file MA")

                Try
                    'creo blocco per gli altri utenti
                    Chiave.SetItem(Utx.SettingItem.Sezioni.INTEROP, Utx.SettingItem.Chiavi.IMPORTAZIONE_MA,
                               Utx.SettingItem.Valori.BLOCCO.ToString, Utx.SettingOMW.TipoOperazione.SCRITTURA)

                    'avvia processo
                    Dim ImportaFile As New UniFeed.FileIntoDatabase
                    ImportaFile.ImportaTutto(Inizio, Fine, TipoRecord, Agenzia)

                    'prossimo controllo fra 3 ore
                    Chiave.SetItem(Utx.SettingItem.Sezioni.AUTOMATISMI, Utx.SettingItem.Chiavi.IMPORTAZIONE_MA, Now.AddHours(6).ToString,
                               Utx.SettingOMW.TipoOperazione.SCRITTURA)

                Catch ex As Exception
                    Utx.Globale.Log.Info(ex.Message)
                    'in caso di errore prossimo controllo fra 1 ora
                    Chiave.SetItem(Utx.SettingItem.Sezioni.AUTOMATISMI, Utx.SettingItem.Chiavi.IMPORTAZIONE_MA, Now.AddHours(1).ToString,
                               Utx.SettingOMW.TipoOperazione.SCRITTURA)
                Finally
                    'rimuovo blocco
                    Chiave.SetItem(Utx.SettingItem.Sezioni.INTEROP, Utx.SettingItem.Chiavi.IMPORTAZIONE_MA, "",
                               Utx.SettingOMW.TipoOperazione.CANCELLAZIONE)
                End Try
            End If

        Catch ex As Exception
            Utx.Globale.Log.Info(ex.Message)
        End Try
    End Sub

    Private Sub ImportazioneDownloadAgenzie()
        Dim Chiave As Utx.SettingItem
        Try
#If DEBUG Then
            'Exit Sub
#End If
            Chiave = New Utx.SettingItem(Utx.SettingItem.Sezioni.AUTOMATISMI, Utx.SettingItem.Chiavi.IMPORTAZIONE_DL,
                                         Utx.SettingOMW.TipoOperazione.LETTURA)

            If (Chiave.ItemResult.Esiste = False) OrElse (Chiave.ItemResult.Valore < Now) Then
                'controllo se è già in corso un aggiornamento
                Chiave.SetItem(Utx.SettingItem.Sezioni.INTEROP, Utx.SettingItem.Chiavi.IMPORTAZIONE_DL, "",
                               Utx.SettingOMW.TipoOperazione.LETTURA)

                If Chiave.ItemResult.Esiste = False Then
                    Utx.Globale.Log.Info("ImportazioneDownloadAgenzie")
                    Utx.ApplicationLog.LogUso("Importazione da download")

                    Try
                        'creo blocco per gli altri utenti
                        Chiave.SetItem(Utx.SettingItem.Sezioni.INTEROP, Utx.SettingItem.Chiavi.IMPORTAZIONE_DL,
                                   Utx.SettingItem.Valori.BLOCCO.ToString, Utx.SettingOMW.TipoOperazione.SCRITTURA)

                        'avvia processo
                        Dim ImportaFile As New ImportaDati.FileIntoDatabase
                        ImportaFile.Avvio()

                        'prossimo controllo dalle 7 del giorno successivo
                        Chiave.SetItem(Utx.SettingItem.Sezioni.AUTOMATISMI, Utx.SettingItem.Chiavi.IMPORTAZIONE_DL, Format(Now.AddDays(1), "dd/MM/yyyy 07:00:00"),
                                   Utx.SettingOMW.TipoOperazione.SCRITTURA)

                    Catch ex As Exception
                        Utx.Globale.Log.Info(ex.Message)
                        'in caso di errore prossimo controllo fra 1 ora
                        Chiave.SetItem(Utx.SettingItem.Sezioni.AUTOMATISMI, Utx.SettingItem.Chiavi.IMPORTAZIONE_DL, Now.AddHours(1).ToString,
                                   Utx.SettingOMW.TipoOperazione.SCRITTURA)
                    Finally
                        'rimuovo blocco
                        Chiave.SetItem(Utx.SettingItem.Sezioni.INTEROP, Utx.SettingItem.Chiavi.IMPORTAZIONE_DL, "",
                                   Utx.SettingOMW.TipoOperazione.CANCELLAZIONE)
                    End Try
                End If
            End If
        Catch ex As Exception
            Utx.Globale.Log.Info(ex.Message)
        End Try
    End Sub

    Public Shared Sub ImportazioneListeRete(Optional Forzatura As Boolean = False)
        Try
#If DEBUG Then
            Dim Blocco As New Utx.SettingItem(Utx.SettingItem.Sezioni.INTEROP, Utx.SettingItem.Chiavi.LISTE_UTENTI, "",
                                              Utx.SettingOMW.TipoOperazione.CANCELLAZIONE)
#End If
            'avvia processo
            Dim az As New ExportLib.Azioni
            az.AggiornaListeEssig(Forzatura)
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub RiletturaFileIncassiAuto(ScaricareDal As Date,
                                        ScaricatiPrimaDel As Date)
        Try
            If Utx.Globale.Paths.UnitaDati.Name.StartsWith("U") Then
                Exit Sub
            End If

            'se siamo fuori dalla fascia oraria consentita esco
            'If ExportLib.JobEsitati.FasciaOrariaConsentita = False Then
            '    Exit Sub
            'End If

            'se la rilettura completa non è ancora avvenuta, rileggo i file da essig
            If (Utx.Globale.SettingInterop.LeggiValore(Utx.GestioneFlag.TipoFlag.DATA_RILETTURA_FILE_INCASSI, CDate("01/01/1900")) < ScaricatiPrimaDel) Or
               (Utx.Globale.SettingInterop.EsisteChiave(Utx.GestioneFlag.TipoFlag.VERIFICA_RILETTURA_FILE) = False) Then

                Using s As New Utx.SettingAgenzia.ConfiguraSede
                    s.Proxy = Utx.Globale.UniProxy.Proxy

                    If s.ConsensoOnLine(Utx.Enumerazioni.TipoOperazioneOnLine.ESSIG_ON_DEMAND, Utx.Globale.AgenziaRichiesta.CodiceAgenzia, Utx.NetFunc.GuidUtente) = True Then
                        'se non è già in corso una lettura dei file da essig
                        If Utx.GestioneFlag.EsisteFlag(Utx.GestioneFlag.TipoFlag.RILETTURA_INCASSI, 60) = False Then
                            'creo blocco per la chiusura
                            Dim b As Utx.Sessione.Blocco = Utx.Globale.SessioneCorrente.AggiungiBlocco(Utx.Sessione.TipoBlocco.MANUTENZIONE, "Rilettura file incassi")
                            'creo blocco per gli altri utenti
                            Utx.GestioneFlag.CreaFlag(Utx.GestioneFlag.TipoFlag.RILETTURA_INCASSI)
                            'avvia processo
                            Dim az As New ExportLib.Azioni
                            Try
                                az.RiletturaFileIncassi(ScaricareDal, ScaricatiPrimaDel)
                            Catch ex As Exception
                                Utx.Globale.Log.Errore(ex)
                            End Try
                            'rimuovo blocco chiusura
                            Utx.Globale.SessioneCorrente.RimuoviBlocco(b)
                            'rimuovo blocco utenti
                            Utx.GestioneFlag.CancellaFlag(Utx.GestioneFlag.TipoFlag.RILETTURA_INCASSI)
                            'reimposto auto incassi per far ripartire l'automatismo
                            Utx.GestioneFlag.CreaFlag(Utx.GestioneFlag.TipoFlag.AUTO_INCASSI, Now.AddDays(-1))
                        End If
                        s.RimuoviConsensoOnLine(Utx.Enumerazioni.TipoOperazioneOnLine.ESSIG_ON_DEMAND, Utx.Globale.AgenziaRichiesta.CodiceAgenzia, Utx.NetFunc.GuidUtente)
                    Else
                        Utx.Globale.Log.Info("Rilettura file incassi: consenso on-line NON concesso")
                    End If
                End Using
            Else
                Utx.Globale.Log.Info("Rilettura file incassi non necessaria")
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    '    Private Sub BackupDati()
    '        Try
    '            Utx.Globale.Log.Info("BackupDati")
    '            'se siamo oltre la data/ora fissata per il prossimo controllo
    '            If CDate(Utx.Globale.SettingInterop.LeggiValore(Utx.GestioneFlag.TipoFlag.AUTO_BACKUP, Today.AddDays(-1))) < Now Then
    '                'avvio backup
    '                If Utx.Servizi.AvviaBackupArchivi(Utx.EnteGestore.StringaCodiciGestiti) = True Then
    '                    'aggiorno data prossimo backup. backup ogni 2 ore
    '                    Utx.GestioneFlag.CreaFlag(Utx.GestioneFlag.TipoFlag.AUTO_BACKUP, Now.AddHours(2))
    '                Else
    '                    'riprovo fra 15 minuti
    '                    Utx.GestioneFlag.CreaFlag(Utx.GestioneFlag.TipoFlag.AUTO_BACKUP, Now.AddMinutes(15))
    '                End If
    '            End If
    '        Catch ex As Exception
    '            Utx.Globale.Log.Errore(ex)
    '        End Try
    '    End Sub

    '    Public Shared Sub ControlloImportazioniInAttesa()
    '        Try
    '            Utx.Globale.Log.Info("ControlloImportazioniInAttesa")
    '            'se è già in corso una importazione
    '            If Utx.GestioneFlag.EsisteFlag(Utx.GestioneFlag.TipoFlag.IMPORTA_DATI_OMNIA, 30) = True Then
    '                Exit Sub
    '            End If
    '            If Utx.GestioneFlag.EsisteFlag(Utx.GestioneFlag.TipoFlag.IMPORTA_DATI_DOWNLOAD, 30) = True Then
    '                Exit Sub
    '            End If
    '            'se non è già in corso un consolidamento
    '            If Utx.GestioneFlag.EsisteFlag(Utx.GestioneFlag.TipoFlag.ESECUZIONE_MERGE_DATI, 10) = True Then
    '                Exit Sub
    '            End If

    '            'controllo riavvio
    '            If Utx.GestioneFlag.EsisteFlag(Utx.GestioneFlag.TipoFlag.DATI_OMNIA_DISPONIBILI) OrElse
    '               Utx.GestioneFlag.EsisteFlag(Utx.GestioneFlag.TipoFlag.DATI_DOWNLOAD_DISPONIBILI) Then

    '                If BloccoRiavvio("E' necessario riavviare Unitools per procedere con l'importazione dei dati.") Then
    '                    Exit Sub
    '                End If
    '            End If

    '            Dim Importazione As Boolean = False
    '            Dim b As Utx.Sessione.Blocco

    '            'se ci sono i flag di dati da flusso giornaliero
    '            If Utx.GestioneFlag.EsisteFlag(Utx.GestioneFlag.TipoFlag.DATI_OMNIA_DISPONIBILI) Then
    '                Utx.ApplicationLog.LogUso("Consolidamento dati MA")
    '                'creo flag di blocco
    '                Utx.GestioneFlag.CreaFlag(Utx.GestioneFlag.TipoFlag.ESECUZIONE_MERGE_DATI) 'per gli altri utenti
    '                b = Utx.Globale.SessioneCorrente.AggiungiBlocco(Utx.Sessione.TipoBlocco.MERGE_DATI) 'per bloccare l'uscita da questa sessione
    '                Utx.Globale.SettingInterop.AggiungiModifica(Utx.GestioneFlag.TipoFlag.UTENTE_MERGE_DATI_OMNIA, Utx.Globale.UtenteCorrente.UniageUser)
    '                Utx.Globale.SessioneCorrente.RimuoviBlocco(b)
    '            End If
    '            'se ci sono dati da download agenzia
    '            If Utx.GestioneFlag.EsisteFlag(Utx.GestioneFlag.TipoFlag.DATI_DOWNLOAD_DISPONIBILI) Then
    '                Utx.ApplicationLog.LogUso("Consolidamento dati download")
    '                'creo flag di blocco
    '                Utx.GestioneFlag.CreaFlag(Utx.GestioneFlag.TipoFlag.ESECUZIONE_MERGE_DATI)
    '                b = Utx.Globale.SessioneCorrente.AggiungiBlocco(Utx.Sessione.TipoBlocco.MERGE_DATI)
    '                Utx.Globale.SettingInterop.AggiungiModifica(Utx.GestioneFlag.TipoFlag.UTENTE_MERGE_DATI_DL, Utx.Globale.UtenteCorrente.UniageUser)
    '                Utx.Globale.SessioneCorrente.RimuoviBlocco(b)
    '            End If

    '#If Not DEBUG Then
    '            If Importazione = True Then
    '                Using Notifica As New Utx.FormNotifica
    '                    With Notifica
    '                        .ColoreSfondo = Color.Aquamarine
    '                        .Opacity = 0.9
    '                        .Altezza = Utx.FormNotifica.AltezzaNotifica.MEZZA
    '                        .Show()
    '                    End With

    '                    'manutenzione
    '                    Notifica.Messaggio = "Controllo chiavi..."
    '                    Utx.FunzioniDb.CreaChiaviDb(Notifica.LabelMessaggio)
    '                    Notifica.Messaggio = "Importazione completata"
    '                    Notifica.Chiudi()
    '                End Using
    '            End If
    '#End If
    '            'cancello flag di blocco
    '            Utx.GestioneFlag.CancellaFlag(Utx.GestioneFlag.TipoFlag.ESECUZIONE_MERGE_DATI)

    '        Catch ex As Exception
    '            Utx.Globale.Log.Errore(ex)
    '        End Try
    '    End Sub

    Private Sub ControlloRiavvio()
        Try
            Utx.Globale.Log.Info("ControlloRiavvio")
            If Utx.Globale.SessioneCorrente.VisualizzaNotificaRiavvio = True Then
                Dim Notifica As New Utx.FormNotifica
                With Notifica
                    .ColoreSfondo = Color.Yellow
                    .Opacity = 0.9
                    .LabelMessaggio.Font = Utx.AppFont.Bold
                    .Messaggio = String.Format("E' necessario riavviare Unitools per rendere effettivi gli aggiornamenti scaricati il{0}{0}{1}",
                                               Environment.NewLine, Utx.Globale.SessioneCorrente.UltimoAggiornamento)
                    .Show()
                    .Chiudi(10)
                End With
            End If
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub bw_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw.RunWorkerCompleted
        Utx.Globale.SessioneCorrente.RimuoviBlocco(BloccoTimer)

        If Utx.Globale.SessioneCorrente.Nascosta AndAlso ConsensoCicli(2) Then
            'se la sessione è nascosta faccio almeno 3 cicli (lettura dati, consolidamento)
#If DEBUG Then
            Console.Beep(700, 500)
#End If
            If Avvio.Menu IsNot Nothing Then
                Avvio.Menu.Chiudi()
            Else
                UtTimer.TimerAbilitato = False
                Utx.OggettoForm.DisposeAll()
                Application.Exit()
            End If
        End If
    End Sub

    Private Sub ControlloRichiestaChiusura()
        'Utx.Globale.Log.Info("ControlloRichiestaChiusura")
        'Dim Invito As New Utx.Sessione.InvitoAllaChiusura
        'Invito.Messaggio()
    End Sub

    Private Sub ControlloSinistriControparte()
        Exit Sub
        Try
            Utx.Globale.Log.Info("ControlloSinistriControparte")
            Dim ValoreChiave As String = Utx.Globale.SettingInterop.LeggiValore(Utx.GestioneFlag.TipoFlag.SINISTRI_CONTROPARTE)

            If ValoreChiave IsNot Nothing Then
                Dim CodiceUtente As String = Right(Utx.Globale.UtenteCorrente.UniageUser, 2).ToUpper

                If IsDate(ValoreChiave.Split("|")(0)) AndAlso ValoreChiave.Split("|")(0) = Today Then
                    If ValoreChiave.Contains(CodiceUtente) = False Then
                        Utx.Globale.SettingInterop.AggiungiModifica(Utx.GestioneFlag.TipoFlag.SINISTRI_CONTROPARTE, ValoreChiave + CodiceUtente + "/")
                        Dim Notifica As New Utx.FormNotifica
                        With Notifica
                            .ColoreSfondo = Utx.AppColor.AzzurroScuro
                            .ColoreTesto = Color.White
                            .Messaggio = String.Format("Sono arrivati {0} nuovi sinistri di controparte", ValoreChiave.Split("|")(1))
                            .Show()
                            .Chiudi(10)
                        End With
                    End If
                End If
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub AnalizzaTutto()
        Exit Sub
        Try
            Utx.Globale.Log.Info("AnalizzaTutto")
            Dim ProssimoControllo As Date = Utx.Globale.SettingGlobale.LeggiValore(Utx.GestioneFlag.TipoFlag.AUTO_ANALISI_DB, "01/01/2000")
            If ProssimoControllo <= Today Then
                'analisi della struttura dei database di tutti i codici gestiti
                Dim Analisi As New Utx.AnalisiDb

                Dim Errori As Boolean = False

                For Each agenzia As String In Utx.EnteGestore.CodiciGestiti
                    Analisi.Agenzia = agenzia
                    Dim dt As DataTable = Analisi.AnalisiDb()
                    Analisi.CorreggiTutto()
                    Errori = Errori Or Analisi.ErroreAnalisi

                    If Analisi.ErroriNonCorretti.Count > 0 Then
                        'se ci sono errori non corretti invia notifica a Raffaele/Guido
                        Dim p As New UniCom.Postino
                        With p
                            .EmailAutomatica = True
                            .Mittente = "unitools@unitools.it"
                            .InviaA.Add("raffaele.bonghi@auaonline.it")
                            .InviaCc.Add("guidolampo@tiscali.it")
                            .Oggetto = String.Format("Errore in analisi database. Agenzia {0}", agenzia)

                            For Each r As String In Analisi.ErroriNonCorretti
                                .Testo += .Testo + Environment.NewLine
                            Next

                            .InviaMail()
                        End With
                    End If
                Next

                If Errori = False Then
                    ProssimoControllo = Today.AddDays(15) '+controllo fra 15 giorni
                Else
                    ProssimoControllo = Today.AddDays(1) '+riprovo domani
                End If
                Utx.Globale.SettingGlobale.AggiungiModifica(Utx.GestioneFlag.TipoFlag.AUTO_ANALISI_DB, Format(ProssimoControllo, "dd/MM/yyyy"))
            End If
        Catch ex As Exception
            '+riprovo domani
            Utx.Globale.Log.Info(ex)
            Utx.Globale.SettingGlobale.AggiungiModifica(Utx.GestioneFlag.TipoFlag.AUTO_ANALISI_DB, Format(Today.AddDays(1), "dd/MM/yyyy"))
        End Try
    End Sub

    Private Function ConsensoPostalizzazioneAutomatica() As Boolean
        '============================================================
        'controlla se è necessario postalizzare
        '============================================================
        Try
            'solo per i profili A
            If UtenteCorrente.Profilo.ProfiloUnipol.ToUpper <> "A" Then
                Utx.Globale.Log.Info($"Utente con profilo {UtenteCorrente.Profilo.ProfiloUnipol} non abilitato alla postalizzazione")
                Return False
            End If

            'blocco chi postalizza con TTY/SIA - con avvtest passa per DEBUG
            Dim Ambiente As String = UniCom.Koine.Ambiente(Utx.Globale.ProfiloEnteGestore.AgenziaMadre)
            If "avvcom/avvtest".Contains(Ambiente) = False Then
                Utx.Globale.Log.Info($"Ambiente/App utente '{Ambiente}'")
                Return False
            End If

            'se è attiva la postalizzazione
            If Utx.Globale.ProfiloEnteGestore.Abilitazioni.POSTALIZZAZIONE = True Then
                Utx.Globale.Log.Info("Postalizzazione attiva: AutoPostalizzazione")

#If Not DEBUG Then
                'controllo unità dati
                If Utx.Globale.Paths.UnitaDati.Name <> "M:\" Then
                    Utx.Globale.Log.Info("Postalizzazione non attiva su unità di rete {0}", {Utx.Globale.Paths.UnitaDatiRete})
                    Exit Try
                End If
#End If
                'blocco con chiave inserita nel setting. serve a posticipare fino alla data/ora della chiave l'esecuzione dell'automatismo
                If UniCom.Postalizzazione.SettingPostalizzazione.LeggiValore(Utx.GestioneFlag.TipoFlag.POSTALIZZAZIONE_AUTO_BLOCCO, "01/01/2000 12:00:00") > Now Then
                    Utx.Globale.Log.Info("Postalizzazione bloccata con chiave")
                    Return False
                End If

                'rilevo il periodo per la postalizzazione automatica
                Dim InizioAuto As Date = UniCom.Postalizzazione.InizioAutoPostalizzazione
                Dim FineAuto As Date = UniCom.Postalizzazione.FineAutoPostalizzazione
                Utx.Globale.Log.Info($"Periodo postalizzazione automatica dal {InizioAuto:dd-MM-yyyy} al {FineAuto:dd-MM-yyyy}")
#If DEBUG Then
                'InizioAuto = Today
                'FineAuto = Today
#End If
                'se siamo nel periodo di postalizzazione automatica
                If UniCom.Postalizzazione.OggiPostalizzazione >= InizioAuto And UniCom.Postalizzazione.OggiPostalizzazione <= FineAuto Then
                    'se arrivato il momento per prossima esecuzione anche per uno solo dei codici
                    If UniCom.Postalizzazione.ProssimaEsecuzione <= Now Then

                        Dim s As New Utx.SettingAgenzia.ConfiguraSede With {.Proxy = Utx.Globale.UniProxy.Proxy}
                        Dim Blocco As String = s.EsisteBloccoPostalizzazione(Utx.Globale.UtenteCorrente.UserAndPc) 'restituisce una stringa vuota o l'utente che blocca

                        'se non è già in esecuzione su un'altra istanza
                        If Blocco.Length = 0 Then 'max durata 1 ora
                            If BloccoRiavvio("E' necessario riavviare Unitools per procedere con la postalizzazione.") = True Then
                                Return False
                            End If

                            'consenso on-line max 40 utenti contemporaneamente, altrimenti riprova fra 2 minuti
                            If s.ConsensoOnLine(Utx.Enumerazioni.TipoOperazioneOnLine.ESSIG_ON_DEMAND, Utx.Globale.AgenziaRichiesta.CodiceAgenzia, Utx.NetFunc.GuidUtente) = True Then
                                'si deve eseguire postalizzazione automatica
                                Return True
                            Else
                                Utx.Globale.Log.Info("Postalizzazione: troppi utenti connessi")
                                Return False
                            End If
                        Else
                            Utx.Globale.Log.Info($"Attività di postalizzazione già in corso per l'utente {Utx.Utente.NomeUtenza(Blocco)}")
                            Return False
                        End If
                    Else
                        Utx.Globale.Log.Info("non è ancora arrivato il momento per il prossimo tentativo")
                        Return False
                    End If
                Else
                    Utx.Globale.Log.Info("siamo in postalizzazione manuale")
                    Return False
                End If
            Else
                Utx.Globale.Log.Info("Postalizzazione NON attiva")
                Return False
            End If

        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
            Return False
        End Try
    End Function

    Private Sub AvvisoPostalizzazioneManuale()
        '===================================================================
        'controlla se si può postalizzare manualmente e visualizza un avviso
        '===================================================================
        Try
            'se è attiva la postalizzazione
            If Utx.Globale.ProfiloEnteGestore.Abilitazioni.POSTALIZZAZIONE = True Then
                'blocco chi postalizza con TTY/SIA - con avvtest passa per DEBUG
                If "avvcom/avvtest".Contains(UniCom.Koine.Ambiente(Utx.Globale.ProfiloEnteGestore.AgenziaMadre)) = False Then
                    Exit Sub
                End If

                'rilevo il periodo per la postalizzazione automatica
                Dim InizioManuale As Date = UniCom.Postalizzazione.InizioPostalizzazioneManuale
                Dim FineManuale As Date = UniCom.Postalizzazione.InizioAutoPostalizzazione.AddDays(-1)

#If DEBUG Then
                'InizioManuale = Today
#End If

                'se siamo nel periodo di postalizzazione manuale
                If Today >= InizioManuale And Today <= FineManuale Then

                    Dim s As New Utx.SettingAgenzia.ConfiguraSede With {.Proxy = Utx.Globale.UniProxy.Proxy}

                    'per ogni codice postalizzato
                    For Each agenzia As String In UniCom.Postalizzazione.CodiciAbilitatiUT

                        Postalizzazione = New UniCom.Postalizzazione(agenzia)

                        UniCom.Koine.Agenzia = agenzia

                        If UniCom.Koine.Servizi.ConsensoProssimaPostalizzazione(agenzia) = False Then
                            'NON È ANCORA ARRIVATA LA DATA DI INIZIO DELL'ATTIVITÀ DI POSTALIZZAZIONE, LEGGO IL DATO SUI SERVIZI KOINÈ

                        ElseIf s.EsistePostalizzazioneAgenziaMeseAnno(agenzia, UniCom.Koine.Avvisi.InizioPeriodo) = False Then
                            'FACCIO UN CONTROLLO SUL SERVER UNIAREA E SE NON È STATA GIÀ POSTALIZZATA 
                            If Postalizzazione.AgenziaConfig.StatoConfig = UniCom.Koine.RispostaKoine.MessaggioStato.complete.ToString Then
                                'CONTROLLO LO STATO DELLA CONFIGURAZIONE E SE è COMPLETA AVVISO
                                Dim Notifica As New Utx.FormNotifica With {
                                    .Stile = Utx.FormNotifica.Style.OMNIA_MANAGER_2,
                                    .Altezza = Utx.FormNotifica.AltezzaNotifica.DOPPIA}
                                With Notifica.LabelMessaggio
                                    .Padding = New Padding(15)
                                    .TextAlign = ContentAlignment.TopCenter
                                    .Image = Risorse.Immagini.Bitmap("aua")
                                    .ImageAlign = ContentAlignment.BottomCenter
                                    .Font = Utx.AppFont.Extra(10, FontStyle.Regular)
                                End With

                                Notifica.Show()
                                Notifica.Messaggio = String.Format("ATTENZIONE:{0}{0}Dal {1:dd/MM} al {2:dd/MM}{0}" +
                                                                   "è possibile procedere all'invio degli avvisi di scadenza manualmente.{0}{0}" +
                                                                   "Dal {3:dd/MM} l'invio avverrà automaticamente all'avvio dell'applicazione.",
                                                                   Environment.NewLine, InizioManuale, FineManuale, FineManuale.AddDays(1))
                                Notifica.Chiudi(20)
                                Exit For
                            End If
                        End If
                    Next
                    Postalizzazione = Nothing
                End If
            End If

        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
        End Try
    End Sub

    Private Sub AutoPostalizzazione()
        '============================================================
        'IN DEBUG LA PROCEDURA COMUNQUE ELABORA MA NON INVIA IL LOTTO
        '============================================================
        Try
            'consenso on-line max 20 utenti contemporaneamente, altrimenti riprova fra 2 minuti
            If ConsensoPostalizzazioneAutomatica() = True Then
                Dim s As New Utx.SettingAgenzia.ConfiguraSede With {.Proxy = Utx.Globale.UniProxy.Proxy}

                Utx.Globale.Log.Info("Eseguo postalizzazione automatica")
                'blocco gli altri utenti
                s.CreaBloccoPostalizzazione(Utx.Globale.ProfiloEnteGestore.AgenziaMadre, Utx.Globale.UtenteCorrente.UserAndPc)

                Dim EsitoGlobale As Boolean = True

                'per ogni codice postalizzato
                For Each agenzia As String In UniCom.Postalizzazione.CodiciAbilitatiUT
                    Utx.Globale.Log.Info($"Postalizzazione codice {agenzia}")

                    Postalizzazione = New UniCom.Postalizzazione(agenzia)

                    UniCom.Koine.Agenzia = agenzia

                    If UniCom.Koine.Servizi.ConsensoProssimaPostalizzazione(agenzia) = False Then
                        'NON È ANCORA ARRIVATA LA DATA DI INIZIO DELL'ATTIVITÀ DI POSTALIZZAZIONE, LEGGO IL DATO SUI SERVIZI KOINÈ
                        Utx.Globale.Log.Info("Data prima postalizzazione codice non ancora arrivata.")
                        'non cambia l'esito globale

                    ElseIf s.EsistePostalizzazioneAgenziaMeseAnno(agenzia, UniCom.Koine.Avvisi.InizioPeriodo) = False Then
                        'FACCIO UN CONTROLLO SUL SERVER UNIAREA E SE NON È STATA GIÀ POSTALIZZATA PROCEDO
                        Dim EsitoAgenzia As Boolean

                        'controllo lo stato della configurazione e decido cosa fare
                        Select Case Postalizzazione.AgenziaConfig.StatoConfig
                            Case UniCom.Koine.RispostaKoine.MessaggioStato.complete.ToString
                                'se la configurazione è ok
                                Utx.Globale.Log.Info("Configurazione ok. Eseguo postalizzazione")
                                EsitoAgenzia = Postalizzazione.InviaAvvisi()
                                EsitoGlobale = EsitoGlobale And EsitoAgenzia
                                Postalizzazione.AgenziaConfig.PeriodoPostalizzato = EsitoAgenzia
                                Utx.Globale.Log.Info($"Postalizzazione automatica. Esito: {EsitoAgenzia}")
#If DEBUG Then
                                                'SOLO IN DEBUG PER TEST INVIO
                            Case UniCom.Koine.RispostaKoine.MessaggioStato.incomplete.ToString
                                'configurazione incompleta
                                EsitoAgenzia = Postalizzazione.InviaAvvisi()
                                EsitoGlobale = EsitoGlobale And EsitoAgenzia
#End If
                            Case UniCom.Koine.RispostaKoine.MessaggioStato.none.ToString
                                'si verifica in genere quando c'è un problema di collegamento con il server. non fare niente,  riprovo più tardi
                                Utx.Globale.Log.Info("Risposta server koinè non valida")
                                EsitoGlobale = False

                            Case Else
                                'se la configurazione è incompleta
                                Utx.Globale.Log.Info("Configurazione incompleta")
                                MsgBox($"ATTENZIONE:{StrDup(2, Environment.NewLine)}la postalizzazione del codice {agenzia} risulta attivata ma la configurazione dell'agenzia non è completa.{StrDup(2, Environment.NewLine)}" +
                                       $"Andare in POSTALIZZAZIONE >> CONFIGURA IL SERVIZIO per completare la configurazione{StrDup(2, Environment.NewLine)}" +
                                       $"{agenzia}: IMPOSSIBILE COMPLETARE LA POSTALIZZAZIONE",
                                       MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                                EsitoGlobale = False
                        End Select
                    End If
                Next
                Postalizzazione = Nothing

                If EsitoGlobale = True Then
                    'se tutto è andato ok
                    Utx.Globale.Log.Info("Postalizzazione conclusa correttamente")
                    'prossima esecuzione a domani (potrebbe esserci qualcosa, come un gestionale, ancora da fare)
                    UniCom.Postalizzazione.ProssimaEsecuzione = Today.AddDays(1) 'a domani o al riavvio  del programma
                End If

                'reset chiave blocco
                UniCom.Postalizzazione.SettingPostalizzazione.AggiungiModifica(Utx.GestioneFlag.TipoFlag.POSTALIZZAZIONE_AUTO_BLOCCO, "01/01/2000 12:00:00")
                'rimuovo consenso on line
                s.RimuoviConsensoOnLine(Utx.Enumerazioni.TipoOperazioneOnLine.ESSIG_ON_DEMAND, Utx.Globale.AgenziaRichiesta.CodiceAgenzia, Utx.NetFunc.GuidUtente)
                'elimino blocco per gli altri utenti
                s.EliminaBloccoPostalizzazione(Utx.Globale.ProfiloEnteGestore.AgenziaMadre)
                Utx.Globale.Log.Debug("Postalizzazione: eliminati blocchi")
            End If

        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
        End Try
    End Sub

    Private Sub Postalizzazione_RichiestaArretrati(Agenzia As UniCom.AgenziaConfigPostalizzazione, InizioPeriodo As Date, FinePeriodo As Date) Handles Postalizzazione.RichiestaArretrati
        Dim az As New ExportLib.Azioni
        az.AggiornaPostalizzazione(Agenzia, InizioPeriodo, FinePeriodo)
        az.ChiudiNotifica()
    End Sub

    Private Sub CompattaDb()
        Try
            Utx.Globale.Log.Info("CompattaDb")
            If ConsensoCicli(5) Then
                'controllo la chiave
                If Utx.Globale.SettingInterop.LeggiValore(Utx.GestioneFlag.TipoFlag.PROSSIMA_COMPATTAZIONE_ARCHIVI, Format(Today, "dd/MM/yyyy 07:00:00")) < Now Then
                    If Utx.GestioneFlag.EsisteFlag(Utx.GestioneFlag.TipoFlag.COMPATTAZIONE_ARCHIVI, 60) = False Then
                        'creo blocco per gli altri utenti
                        Utx.GestioneFlag.CreaFlag(Utx.GestioneFlag.TipoFlag.COMPATTAZIONE_ARCHIVI)
                        'compatto
                        Log.Trace("Compattazione archivi")

                        Using Notifica As New Utx.FormNotifica
                            With Notifica
                                .Opacity = 0.9
                                .Stile = Utx.FormNotifica.Style.ANTRACITE
                                .Altezza = Utx.FormNotifica.AltezzaNotifica.MEZZA
                                .Show()
                            End With

                            'manutenzione e compattazione
                            Notifica.Messaggio = "Compattazione archivi..."
                            Utx.FunzioniDb.CompattaCartelleDati(Notifica.LabelMessaggio)
                            Notifica.Chiudi()
                        End Using
                    End If
                    'prossimo controllo domani dopo le 14
                    Utx.Globale.SettingInterop.AggiungiModifica(Utx.GestioneFlag.TipoFlag.PROSSIMA_COMPATTAZIONE_ARCHIVI, Format(Today.AddDays(1), "dd/MM/yyyy 14:00:00"))
                    'rimuovo blocco
                    Utx.GestioneFlag.CancellaFlag(Utx.GestioneFlag.TipoFlag.COMPATTAZIONE_ARCHIVI)
                End If
            End If

        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
        End Try
    End Sub

    Private Sub TrasmettiStrutturaDbUno()
        Exit Sub
        Try
            Dim Analisi As New Utx.AnalisiDb
            For Each codice As String In Utx.EnteGestore.CodiciGestiti
                Using ds As New DataSet
                    ds.Tables.Add(Analisi.AnalisiDbUno(codice))
                    Using s As New Utx.SettingAgenzia.ConfiguraSede
                        s.Proxy = Utx.Globale.UniProxy.Proxy
                        s.SalvaStatisticheDb(codice, ds)
                    End Using
                End Using
            Next
        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
        End Try
    End Sub

    Private Sub InviaDatiAnag()
        Try
            If Utx.Globale.SettingGlobale.EsisteChiave(Utx.GestioneFlag.TipoFlag.INVIO_LOG_ANAG) = False Then
                Dim analisi As New Utx.AnalisiDb
                If analisi.AnalisiDbAnag() = True Then
                    Utx.Globale.SettingGlobale.AggiungiModifica(Utx.GestioneFlag.TipoFlag.INVIO_LOG_ANAG, Format(Now, "dd/MM/yyyy HH:mm:ss"))
                End If
            End If
        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
        End Try
    End Sub

    'Private Sub InviaDatiDocumenti()
    '    Try
    '        If Utx.Globale.SettingGlobale.EsisteChiave(Utx.GestioneFlag.TipoFlag.INVIO_LOG_DOCUMENTI) = False Then
    '            Dim newThread As New Threading.Thread(AddressOf DimensioniCartella)
    '            newThread.Start()
    '        End If
    '    Catch ex As Exception
    '        Utx.Globale.Log.Info(ex)
    '    End Try
    'End Sub

    Public Shared Function BloccoRiavvio(Messaggio As String) As Boolean
        Try
            If Utx.Globale.SessioneCorrente.RiavvioRichiesto = True Then
                Dim Notifica As New Utx.FormNotifica
                With Notifica
                    .Stile = Utx.FormNotifica.Style.ROSSO_BIANCO
                    .Opacity = 1
                    .LabelMessaggio.Font = Utx.AppFont.Bold
                    .Messaggio = Messaggio
                    .Show()
                    .Chiudi(5)
                End With
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
            Return False 'non blocco
        End Try
    End Function

    'Private Sub DimensioniCartella()
    '    Try
    '        'Chiamando la function DimCartella con True come secondo parametro
    '        'effettua il conteggio del totale dimensione files
    '        'incluse le eventuali sottocartelle
    '        'Se il parametro e' False considera solo i files presenti  nella radice
    '        Dim Dimensione As Long = DimCartella(Utx.Globale.Paths.CartellaDocumenti, True)
    '        If Dimensione >= 0 Then
    '            Using s As New Utx.SettingAgenzia.ConfiguraSede
    '                s.Proxy = Utx.Globale.UniProxy.Proxy
    '                If s.RegistraLogDocumenti(Utx.Globale.ProfiloEnteGestore.AgenziaMadre, Utx.Globale.ProfiloEnteGestore.CodiceSede, Dimensione) = "+OK" Then
    '                    Utx.Globale.SettingGlobale.AggiungiModifica(Utx.GestioneFlag.TipoFlag.INVIO_LOG_DOCUMENTI, Format(Now, "dd/MM/yyyy HH:mm:ss"))
    '                End If
    '            End Using
    '        End If
    '    Catch ex As Exception
    '        Utx.Globale.Log.Info(ex)
    '    End Try
    'End Sub

    'Function DimCartella(sPath As String, bRecursive As Boolean) As Long
    '    Dim Size As Long = 0
    '    Dim lngNumberOfDirectories As Long = 0
    '    Dim diDir As New DirectoryInfo(sPath)
    '    Try
    '        Dim fil As FileInfo
    '        For Each fil In diDir.GetFiles()
    '            Size += fil.Length
    '        Next fil
    '        If bRecursive = True Then
    '            Dim diSubDir As DirectoryInfo
    '            For Each diSubDir In diDir.GetDirectories()
    '                Size += DimCartella(diSubDir.FullName, True)
    '                lngNumberOfDirectories += 1
    '            Next diSubDir
    '        End If
    '        Return Size

    '    Catch ex As Exception
    '        Utx.Globale.Log.Info(ex)
    '        Return -1
    '    End Try
    'End Function

    Public Shared Sub AvviaTwitt(Optional ForzaApertura As Boolean = False)
        Try
            If (ForzaApertura = True) OrElse (CDate(Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.AUTO_UTWITT, Now)) < Now) Then
                Utx.Globale.Log.Info("AvviaTwitt")
                Utwitt.PaginaNews.ControlloTwitt(ForzaApertura)
                'registra data prossimo controllo
                Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.AUTO_UTWITT, Now.AddMinutes(15))
            End If
        Catch ex As Exception
            Utx.Globale.Log.Info(ex.Message)
        End Try
    End Sub

    Public Sub InvioDatiMigrazione()
        'se la migrazione dati è stata completata
        If Utx.Globale.SettingInterop.EsisteChiave(Utx.GestioneFlag.TipoFlag.MIGRAZIONE_DATI) Then
            'se l'invio dati non è già in corso
            If Utx.GestioneFlag.EsisteFlag(Utx.GestioneFlag.TipoFlag.MIGRAZIONE_INVIO_IN_CORSO, 15) = False Then
                'se è arrivato il momento stabilito
                If Utx.Globale.SettingInterop.LeggiValore(Utx.GestioneFlag.TipoFlag.MIGRAZIONE_INVIO_DATI, #1/1/1900#) < Now Then
                    'creo chiave di blocco per gli altri utenti
                    Utx.Globale.SettingInterop.AggiungiModifica(Utx.GestioneFlag.TipoFlag.MIGRAZIONE_INVIO_IN_CORSO, Now)

                    ImportazioneListeRete(Forzatura:=True)

                    Notifica = New Utx.FormNotifica
                    With Notifica
                        .Stile = Utx.FormNotifica.Style.ANTRACITE
                        .Messaggio = "Invio dati migrati..."
                        .Show()
                    End With

                    Esporta = New UniFeed.Esporta
                    If Esporta.InviaDati2SIA() = False Then
                        'ci sono stati errori nell'invio e riprovo fra 15 minuti
                        Notifica.Messaggio = "Invio notifiche..."
                        Esporta.InviaNotifica()
                        Utx.Globale.SettingInterop.AggiungiModifica(Utx.GestioneFlag.TipoFlag.MIGRAZIONE_INVIO_DATI, Now.AddMinutes(15))
                        Utx.Globale.SettingInterop.Rimuovi(Utx.GestioneFlag.TipoFlag.MIGRAZIONE_INVIO_IN_CORSO)
                    Else
                        Notifica.Messaggio = "Invio notifiche..."
                        Esporta.InviaNotifica()
                        Utx.Globale.SettingInterop.Rimuovi(Utx.GestioneFlag.TipoFlag.MIGRAZIONE_DATI)
                        Utx.Globale.SettingInterop.Rimuovi(Utx.GestioneFlag.TipoFlag.MIGRAZIONE_INVIO_DATI)
                        Utx.Globale.SettingInterop.Rimuovi(Utx.GestioneFlag.TipoFlag.MIGRAZIONE_ERRORE)
                        Utx.Globale.SettingInterop.Rimuovi(Utx.GestioneFlag.TipoFlag.MIGRAZIONE_INVIO_IN_CORSO)
                    End If
                    Esporta = Nothing
                    Notifica.Messaggio = "Migrazione completata"
                    Notifica.Chiudi(3)
                End If
            End If
        End If
    End Sub

    Private Sub Esporta_Messaggio(Messaggio As String) Handles Esporta.Messaggio
        Notifica.Messaggio = Messaggio
        Application.DoEvents()
    End Sub

    Public Shared Function ElencoSinistri() As DataTable
        Try
            Using s As New Utx.ServiziOMW.ServizioDatiOMW
                s.Proxy = Utx.Globale.UniProxy.Proxy
                Return s.ElencoSinistri("02379", Utx.Globale.Token).Tables(0)
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return New DataTable
        End Try
    End Function

    Public Shared Sub CercaNotificheSms()
        Dim Chiave As Utx.SettingItem
        Try
            Chiave = New Utx.SettingItem(Utx.SettingItem.Sezioni.AUTOMATISMI, Utx.SettingItem.Chiavi.NOTIFICHE_SMS,
                                         Utx.SettingOMW.TipoOperazione.LETTURA)

            If (Chiave.ItemResult.Esiste = False) OrElse (Chiave.ItemResult.Valore < Now) Then
                Dim s As New UniCom.Servizi
                If s.CercaNotificheSms(2) = True Then
                    'prossimo controllo domani mattina alle 10
                    Chiave.SetItem(Utx.SettingItem.Sezioni.AUTOMATISMI, Utx.SettingItem.Chiavi.NOTIFICHE_SMS, Format(Now.AddDays(1), "dd/MM/yyyy 10:00:00"),
                                   Utx.SettingOMW.TipoOperazione.SCRITTURA)
                Else
                    'errore riprovo fra 2 ore
                    Chiave.SetItem(Utx.SettingItem.Sezioni.AUTOMATISMI, Utx.SettingItem.Chiavi.NOTIFICHE_SMS, Now.AddHours(2).ToString,
                                   Utx.SettingOMW.TipoOperazione.SCRITTURA)
                End If
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Shared Sub ControlloAggiornamenti()
        Try
            Dim NumeroCicli As Integer = 10 'ogni 20 minuti

            If ConsensoCicli(NumeroCicli) Then
                Using s As New Utx.SettingOMW.GestioneSetting
                    s.Proxy = Utx.Globale.UniProxy.Proxy
                    Utx.Globale.Log.Info("Controllo se ci sono aggiornamenti...")

                    If CDate(s.DataLiveUp(Utx.Globale.Token)).AddSeconds(NumeroCicli * 2 * 60 - 10) > Now Then 'numero dei secondi meno 10
#If Not DEBUG Then
                        AvviaLiveUpdate()
#End If
                    End If
                End Using
            End If
        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
        End Try
    End Sub

    Private Shared Function ConsensoCicli(NumeroCicli As Integer) As Boolean
        Return Utx.Globale.SessioneCorrente.CicliTimer / NumeroCicli = Utx.Globale.SessioneCorrente.CicliTimer \ NumeroCicli
    End Function

    Private Sub RefreshLogin()
        Try
            '5 cicli=10 minuti
            If ConsensoCicli(5) Then
                ExportLib.Azioni.LoginRefresh()
            End If
        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
        End Try
    End Sub
End Class
