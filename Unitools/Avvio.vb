Imports System.IO

Module Avvio

    Public WithEvents UtTimer As TimerUnitools
    Public Splash As FormSplash
    Public WithEvents UtenteCorrente As Utx.Utente 'mi serve per catturare l'evento Utente.RichiestaAggiornamentoEssigReti()
    Friend Menu As Menu
    Private LiveUpThread As Threading.Thread

    Sub New()
        Try
            'AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf AssemblyResolver
            Application.EnableVisualStyles()

            If Utx.NetFunc.AltraIstanzaUtente("Unitools", ProcessoAvviato:=True) = True Then
                'nuova versione 14/05/2026
                Dim procs = Process.GetProcessesByName("Unitools")
                If procs.Length > 0 Then
                    Dim hwnd As IntPtr = procs(0).MainWindowHandle
                    If hwnd <> IntPtr.Zero Then
                        Utx.API.ShowWindow(hwnd, Utx.API.SW.SW_RESTORE)
                        Utx.API.SetForegroundWindow(hwnd)
                    Else
                        'ci sono più sessioni ma non trova l'handle (è probabilmente bloccato) lo chiudo con kill
                        Shell("taskkill /F /IM Unitools.exe", AppWinStyle.Hide)
                    End If
                Else
                    'incongruenza: ci sono altre istanze ma procs.Length = 0
                    Shell("taskkill /F /IM Unitools.exe", AppWinStyle.Hide)
                End If
                End
            End If

#If DEBUG Then
            'Using s As New Utx.ServizioCassa.ServizioCassa
            '    MsgBox(s.ScaricaEsitati("101197ab", "Pilletta1197@", "uniage", "0B55F1D54907522BBE34ACA093F60155"))
            'End Using

            'Dim aut As New Utx.WebLogin.Autenticazione
            'Dim result As Utx.WebLogin.LoginResult = aut.Login("101197ab", "Pilletta1197@", "uniage", Utx.WebLogin.TipoLogin.ESSIG)

            'Utx.Globale.LoginUniage.Stato = result.Stato
            'Utx.Globale.LoginUniage.CookieContainer = New Net.CookieContainer

            'For Each c As Utx.WebLogin.MyCookie In result.Cookies
            '    Dim cookie As New Net.Cookie With {
            '        .Name = c.Nome,
            '        .Value = c.Valore,
            '        .Domain = c.Dominio
            '    }

            '    Utx.Globale.LoginUniage.CookieContainer.Add(cookie)
            'Next
#End If

            If Utx.Sessione.Hide Then
                'aspetto per consentire il corretto avvio di google drive
                Threading.Thread.Sleep(60000) '1 minuto
            End If

            Utx.Globale.VerificaGoogleDrive()

            If Utx.Sessione.Hide AndAlso (New DriveInfo("M").IsReady = False) Then
                'se la sessione è nascosta e M: non è disponibile termino
                End
            End If

            Net.ServicePointManager.SecurityProtocol = 3072 'fondamentale con il FW 2.0 TSL 1.2

            'imposto id
            Utx.Globale.IdApp(System.Text.Encoding.UTF8.GetString(New Byte() {57, 60, 88, 93, 65, 58, 71}))

#If Not DEBUG Then
            Using s As New Utx.SettingAgenzia.ConfiguraSede
                If s.BloccoManutenzione = True Then
                    MsgBox($"Accesso all'applicazione momentaneamente non disponibile.
E' in corso una manutenzione ai server.
Riprovare fra poco.",
                           MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                    End
                End If
            End Using
#End If

            'definisco i dischi e i percorsi dell'applicazione
            Utx.Globale.Init()
            Utx.Globale.Log.Info()
            Utx.Globale.Log.Info("--- INIZIO SESSIONE ---")
            Utx.Globale.Log.Info()

            If Utx.Globale.Paths.UnitaDati.IsReady = False Then
                MsgBox($"Disco dati {Utx.Globale.Paths.NomeUnitaDati} non disponibile. Impossibile avviare OmniaManager",
                       MsgBoxStyle.Critical, Utx.Globale.TitoloApp)
                End
            End If

            'compatibilità date/ore
            If System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator <> "/" OrElse
               System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator <> ":" Then
                MsgBox("Per evitare problemi di incompatibilità fra più utenti è necessario impostare, in Windows, i caratteri / come separatore delle date e : come separatore delle ore.",
                       MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                End
            End If
            'splash
            Splash = New FormSplash
            With Splash
                .TopMost = Splash.PrimoPiano
                .Show()
                .Refresh()
            End With

            If Utx.ConfigError.Errore = True Then
                MsgBox(Utx.ConfigError.MessaggioErrore, MsgBoxStyle.Exclamation)
                End
            End If

            'scompattazione pacchetti zip (paginehtml, eo)
            Dim PagineHtml As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "PagineHtml.zip")
            If File.Exists(PagineHtml) Then
                Call New Utx.NotificaRapida(Utx.FormNotifica.AltezzaNotifica.MEZZA).Visualizza("Elaborazione pacchetto PagineHtml", 5)
                Utx.LibreriaZip.UnZipFileEx(PagineHtml, Utx.Globale.Paths.CartellaApp)
                File.Delete(PagineHtml)
            End If
            Dim EO As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "EO.zip")
            If File.Exists(EO) Then
                Call New Utx.NotificaRapida(Utx.FormNotifica.AltezzaNotifica.MEZZA).Visualizza("Elaborazione pacchetto EO", 5)
                Utx.LibreriaZip.UnZipFileEx(EO, Utx.Globale.Paths.CartellaApp)
                File.Delete(EO)
            End If

            'inizializzo il setting globale
            Utx.Globale.SettingGlobale = New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.GLOBALE)
            Utx.Globale.SettingGlobale.AggiungiModifica(Utx.GestioneFlag.TipoFlag.ID_APP, "UTW")
            'inizializzo il setting dell'utente della sessione windows
            Utx.Globale.SettingUtente = New Utx.ApplicationUserSetting($"{Environment.UserName}-[{Environment.MachineName}]")
            'inizializza l'utente
            Utx.Globale.UtenteCorrente = New Utx.Utente
            UtenteCorrente = Utx.Globale.UtenteCorrente '***************************************************************************************
            If VerificaCredenziali() = False Then
                Application.Exit()
                End
            End If
            'aggiungo l'utente al token
            Utx.Globale.Token &= "|" & Utx.Globale.UtenteCorrente.UniageUser

            If ResetGoogleCache() = True Then
                End
            End If

            'imposta profilo ente e le abilitazioni
            Utx.Globale.ProfiloEnteGestore = New Utx.EnteGestore
            Utx.Globale.AgenziaRichiesta = New Utx.Agenzia(Utx.Globale.ProfiloEnteGestore.AgenziaMadre)
            Utx.Globale.ProfiloEnteGestore.LeggiConfigurazioneServer()

            'per i test
            If Utx.Tester.EsisteAgenziaXml Then
                Dim sett As Utx.ApplicationUserSetting = Utx.Tester.SettingAgenziaXml
                Utx.Globale.ProfiloEnteGestore.AgenziaMadre = sett.LeggiValore("AGENZIA")
                Utx.EnteGestore.CodiciGestiti.Clear()
                Utx.EnteGestore.CodiciGestiti.Add(Utx.Globale.ProfiloEnteGestore.AgenziaMadre)
            End If

            'se il profilo non esiste
            If Utx.Globale.ProfiloEnteGestore.Esiste = False Then
                'visualizzo form per i dati dell'agenzia
                Using f As New FormProfiloEnte
                    f.Profilo = Utx.Globale.ProfiloEnteGestore
                    f.ShowDialog()

                    If Utx.Globale.ProfiloEnteGestore.Esiste = False Then
                        End
                    End If
                End Using
                Splash.TopMost = Splash.PrimoPiano
            End If

            'avvio live update
#If Not DEBUG Then
            AvviaLiveUpdate()
#End If
            'imposta agenzia e posizione dati dei codici gestiti
            For Each codice As String In Utx.EnteGestore.CodiciGestiti
                If codice <> Utx.Globale.ProfiloEnteGestore.AgenziaMadre Then
                    Utx.Globale.AgenziaRichiesta = New Utx.Agenzia(codice)
                End If
            Next
            'imposto agenzia madre
            Utx.Globale.AgenziaRichiesta.CodiceAgenzia = Utx.Globale.ProfiloEnteGestore.AgenziaMadre
            Utx.Globale.ImpostaVariabiliAmbiente()

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            End
        End Try
    End Sub

    Sub Main()
        Try
            CreaLinkAutoStart()

            'inizializza il setting interop
            Utx.Globale.SettingInterop = New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.INTEROP)

            'init sessione (dopo l'inizializzazione dei setting)
            Utx.Globale.SessioneCorrente = New Utx.Sessione With {.Nascosta = Utx.Sessione.Hide}

            If Utx.Globale.SessioneCorrente.Nascosta Then
#If Not DEBUG Then
                If CDate(Utx.Globale.SettingGlobale.LeggiValore(Utx.GestioneFlag.TipoFlag.PROSSIMO_AUTOSTART, Format(Today.AddDays(1), "dd/MM/yyyy 08:00:00"))) > Now Then
                    Exit Sub
                End If
#End If
            End If

            'manutenzione
            Utx.Manutenzione.LiveChange()

            'inizializzo le abilitazioni e il profilo dell'agenzia
            Utx.Globale.ProfiloEnteGestore.Abilitazioni = New Utx.AbilitazioniAgenzia
            Utx.Globale.ProfiloEnteGestore.ImpostaProfiloApp()
            'titolo app
            Utx.Globale.ImpostaTitoloApp()

#If DEBUG Then
            'Utx.GestioneFlag.CancellaFlag(Utx.GestioneFlag.TipoFlag.LIVE_CHANGE)
#End If
            'controllo manutenzione da altra sessione di ut
            'Do While Utx.GestioneFlag.EsisteFlag(Utx.GestioneFlag.TipoFlag.LIVE_CHANGE, MaxDurataMinuti:=2)
            '    Using Notifica As New Utx.FormNotifica
            '        With Notifica
            '            .ColoreSfondo = Color.WhiteSmoke
            '            .ColoreTesto = Utx.AppColor.RossoScuro
            '            .SpessoreBordo = 1
            '            .Opacity = 1
            '            .Altezza = Utx.FormNotifica.AltezzaNotifica.MEZZA
            '            .StartPosition = FormStartPosition.CenterScreen
            '            .Show()
            '            .Messaggio = "Manutenzione in corso da altra sessione. Attendere..."
            '        End With
            '    End Using
            '    Application.DoEvents()
            '    Threading.Thread.Sleep(2000)
            'Loop

            ''manutenzione
            'Utx.Manutenzione.LiveChange()

            'controllo profilo app
            If Utx.Globale.ProfiloEnteGestore.ProfiloApp = Utx.Enumerazioni.ProfiloApp.NESSUNO Then
                Splash.LabelInfo.Image = Risorse.Immagini.Bitmap("info")
                Splash.LabelInfo.Text = $"{Environment.NewLine}Nessun profilo associato all'agenzia {Utx.Globale.ProfiloEnteGestore.AgenziaMadre}."
                Threading.Thread.Sleep(3000)
                Exit Try
            End If

            'assegna l'utente
            'UtenteCorrente = Utx.Globale.UtenteCorrente
            Utx.EnteGestore.CodiciGestiti() 'per inizializzare, da server, i codici gestiti mentre è visualizzato lo splash

            'If Utx.Globale.SessioneCorrente.Nascosta = True Then
            '    'obbligo credenziali 5 richieste
            '    Dim Tentativo As Integer = 0
            '    Do While VerificaCredenziali() = False
            '        Tentativo += 1
            '        If Tentativo > 5 Then
            '            Utx.Globale.Log.Info("AUTO: login annullato dall'utente")
            '            Utx.ApplicationLog.LogUso("Login annullato dall'utente")
            '            Exit Try
            '        End If
            '    Loop
            'Else
            '    If VerificaCredenziali() = False Then
            '        Exit Try
            '    End If
            'End If

            'prossimo autostart domani alle 8
            'Utx.Globale.SettingGlobale.AggiungiModifica(Utx.GestioneFlag.TipoFlag.PROSSIMO_AUTOSTART, Format(Today.AddDays(1), "dd/MM/yyyy 08:00:00"))

            'dopo il login re-inizializzo il setting utente nel caso l'utente del pc non corrisponda all'utente uniage
            If Environment.UserName.ToLower <> Utx.Globale.UtenteCorrente.UniageUser.ToLower Then
                Utx.Globale.SettingUtente = New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.UTENTE)
            End If

            'leggo le impostazioni per la ricerca
            Utx.Globale.RitardoTimer = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.RITARDO_TIMER_RICERCA, "1500")
            'registro la sessione
            Utx.Globale.SessioneCorrente.RegistraSessione()
            'assegno le credenziali dell'utente uniage autenticato al proxy
            Utx.Globale.UniProxy.AssegnaCredenziali()

            'creo Bag
            CreaBag()

            'messaggio per eventuale errore di manutenzione. deve stare dopo l'inizializzazione del timer
            If Utx.Manutenzione.ErroreGlobale = True Then
                Utx.Manutenzione.MessaggioErroreManutenzione()
            Else
                'Dim Invito As New Utx.Sessione.InvitoAllaChiusura
                'Invito.CancellaInvito()
            End If

#If DEBUG Then
            ZonaTest()
#End If

            ControlloCartelleDoppie()

            'rilevazione scanner
            UnitoolsDocumenti.Globale.UtScanners.Init()
            'avvio il menù principale 

            Try
                Splash.TopMost = Splash.PrimoPiano
                Utx.Globale.Log.Info("Profilo {0}", {Utx.Globale.ProfiloEnteGestore.ProfiloApp.ToString})
                Select Case Utx.Globale.ProfiloEnteGestore.ProfiloApp
                    Case Utx.Enumerazioni.ProfiloApp.COMPLETO
                        Menu = New Menu
                        If Menu.ErroreInit = True Then
                            MsgBox("Impossibile inizializzare l'applicazione.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                            Exit Try
                        End If
                        Application.Run()
                    Case Else
                        'avvio il menù principale tipo unitools
                        Splash.Close()
                        Dim MainMenu = New FormMain
                        MainMenu.Show()
                        Application.Run()
                End Select
            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
            End Try

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            ChiusuraSessione()
        End Try
    End Sub

    Private Sub ChiusuraSessione()
        On Error Resume Next
        'in uscita salvo il setting dell'utente
        Utx.Globale.SettingUtente.Salva()

        Utx.ApplicationLog.LogUso("MENU.uscita")
        Utx.ApplicationLog.InviaLogUso()

        Utx.Globale.SessioneCorrente.DeRegistraSessione()
        PulizieUtente()

        If LiveUpThread IsNot Nothing AndAlso LiveUpThread.IsAlive Then
            Call New Utx.NotificaRapida().Visualizza("in attesa chiusura controllo aggiornamenti...")
            Utx.Globale.Log.Info("in attesa della chiusura del thread live update")
            LiveUpThread.Join()
        End If

        Utx.Globale.Log.Info("Durata sessione (d.hh:mm:ss): " & (Now - Utx.Globale.SessioneCorrente.Inizio).ToString("dd\.hh\:mm\:ss"))
        Utx.Globale.Log.Info()
        Utx.Globale.Log.Info("--- FINE SESSIONE ---")
        Utx.Globale.Log.Info()
    End Sub

    Private Function VerificaCredenziali() As Boolean
        'Try
        '    If Utx.Tester.EsisteAgenziaXml Then
        '        'per ambienti test salto la richiesta credenziali
        '        Utx.Globale.UtenteCorrente.UniageUser = String.Format("1{0}xx", Utx.Tester.SettingAgenziaXml.LeggiValore("AGENZIA"))
        '        Utx.Globale.UtenteCorrente.UniagePw = "pippo"
        '        Utx.Globale.UtenteCorrente.Autenticato = True
        '        Return True
        '    End If

        '    '+autenticazione uniage: inserimento credenziali
        '    Utx.Globale.Log.Info("Login richiesto - inserimento credenziali")
        '    If RichiestaLogin() = False Then
        '        Return False
        '    End If
        '    If ControlloCodiceFiscaleUtente() = False Then
        '        Return False
        '    End If

        '    VerificaCaratteriSpeciali()

        '    Splash.Show()
        '    Splash.Refresh()
        '    Return True

        'Catch ex As Exception
        '    Utx.Globale.Log.Errore(ex)
        '    Return False
        'End Try

        Try
            If Utx.Tester.EsisteAgenziaXml Then
                'per ambienti test salto la richiesta credenziali
                Utx.Globale.UtenteCorrente.UniageUser = $"1{Utx.Tester.SettingAgenziaXml.LeggiValore("AGENZIA")}xx"
                Utx.Globale.UtenteCorrente.UniagePw = "pippo"
                Utx.Globale.UtenteCorrente.Autenticato = True
                Return True
            End If

            If Utx.Sessione.Hide Then
                'già loggato in giornata: inizializzo l'utente
                Utx.Globale.UtenteCorrente.Autenticato = False
                Utx.Utente.LeggiCredenziali(Utx.Globale.UtenteCorrente.UniageUser, Utx.Globale.UtenteCorrente.UniagePw)
                'verifico le credenziali
                Try
                    Utx.Globale.LoginUniage.LogIn(Utx.Globale.UtenteCorrente.UniageUser, Utx.Globale.UtenteCorrente.UniagePw, Utx.Globale.UtenteCorrente.Dominio)
                    Utx.Globale.UtenteCorrente.Autenticato = Utx.Globale.LoginUniage.IsLogged
                Catch ex As Exception
                    Utx.Globale.Log.Info(ex)
                    Utx.Globale.UtenteCorrente.Autenticato = False
                End Try

                If Utx.Globale.UtenteCorrente.Autenticato = True Then
                    Return True
                Else
                    MsgBox("Per consentire il corretto funzionamento e aggiornamento dei dati in OmniaManager è necessario fornire le credenziali aggiornate.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                    Splash.Visualizzazione(True)
                    If RichiestaLogin() = False Then
                        Utx.Utente.CancellaUtente(Environment.UserName)
                        Return False
                    Else
                        Splash.Visualizzazione(False)
                        Return True
                    End If
                End If
            ElseIf CDate(Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.LOGIN_RICHIESTO, Format(Today.AddDays(-1), "dd/MM/yyyy 07:00:00"))) < Now Then
                'il login dura fino alle 7 del giorno successivo all'accesso. Dalle 7 in poi bisogna nuovamente autenticarsi
                'reset livello log a INFO
                Utx.Globale.SettingGlobale.AggiungiModifica(Utx.GestioneFlag.TipoFlag.LIVELLO_LOG, Val(Utx.ApplicationLog.Livello.INFO).ToString)

                '+autenticazione uniage: inserimento credenziali
                Utx.Globale.Log.Info("Login richiesto - inserimento credenziali")
                If RichiestaLogin() = False Then
                    Return False
                End If
                If ControlloCodiceFiscaleUtente() = False Then
                    Return False
                End If
            Else
                '+già loggato in giornata: inizializzo l'utente
                Utx.Globale.UtenteCorrente.Autenticato = False
                Utx.Utente.LeggiCredenziali(Utx.Globale.UtenteCorrente.UniageUser, Utx.Globale.UtenteCorrente.UniagePw)

                'verifico le credenziali
                Try
                    Utx.Globale.LoginUniage.LogIn(Utx.Globale.UtenteCorrente.UniageUser, Utx.Globale.UtenteCorrente.UniagePw, Utx.Globale.UtenteCorrente.Dominio)
                    Utx.Globale.UtenteCorrente.Autenticato = Utx.Globale.LoginUniage.IsLogged
                Catch ex As Exception
                    Utx.Globale.UtenteCorrente.Autenticato = False
                End Try

                '#If DEBUG Then
                '                'versione fino al 06/02/2023
                '                If String.IsNullOrEmpty(Utx.Globale.UtenteCorrente.UniageUser) OrElse String.IsNullOrEmpty(Utx.Globale.UtenteCorrente.UniagePw) Then
                '                    Utx.Globale.UtenteCorrente.Autenticato = False
                '                Else
                '                    Utx.Globale.UtenteCorrente.Autenticato = True
                '                End If
                '                'Utx.Globale.UtenteCorrente.Autenticato = False 'in debug forzo il login sempre per poter cambiare agenzia con facilità
                '#Else
                '                            'verifico le credenziali
                '                            Try
                '                                Utx.Globale.LoginUniage.LogIn(Utx.Globale.UtenteCorrente.UniageUser, Utx.Globale.UtenteCorrente.UniagePw, Utx.Globale.UtenteCorrente.Dominio)
                '                                Utx.Globale.UtenteCorrente.Autenticato = Utx.Globale.LoginUniage.IsLogged
                '                            Catch ex As Exception
                '                                Utx.Globale.UtenteCorrente.Autenticato = False
                '                            End Try
                '#End If
                If Utx.Globale.UtenteCorrente.Autenticato = True Then
                    Utx.Globale.Log.Info("Verifica credenziali OK")
                Else
                    Utx.Globale.Log.Info("Verifica credenziali fallita: inserimento nuove credenziali")
                    'l'autenticazione non è riuscita e richiedo le credenziali
                    If RichiestaLogin() = False Then
                        Return False
                    End If
                End If
                If ControlloCodiceFiscaleUtente() = False Then
                    Return False
                End If
            End If

            VerificaCaratteriSpeciali()

            Splash.Show()
            Splash.Refresh()
            Return True

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Private Sub VerificaCaratteriSpeciali()
        Try
            Dim CaratteriSpeciali As String = "&£$^àòèéìçÀÒÈÉÌÇ"

            For Each c As Char In Utx.Globale.UtenteCorrente.UniagePw
                If CaratteriSpeciali.Contains(c) Then
                    MsgBox($"Si consiglia il cambio della password.
Alcuni servizi potrebbero non funzionare correttamente quando nella password sono contenuti alcuni caratteri speciali, ad esempio

{CaratteriSpeciali}", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                    Exit For
                End If
            Next
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Function RichiestaLogin() As Boolean
        Try
            Splash.Hide()
            Splash.LoginRichiesto()
            Splash.ShowDialog()

            If Splash.DialogResult = DialogResult.Cancel Then
                Return False 'se annullo il login chiudo splash
            End If
            If Utx.Globale.UtenteCorrente.Autenticato = False Then
                Return False
            End If
            Return True
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Private Function ControlloCodiceFiscaleUtente() As Boolean
        'controllo CF utente
        Try
            If Utx.Globale.UtenteCorrente.CFValido = True Then
                Return True
            Else
                'esco
                Splash.LabelInfo.Font = Utx.AppFont.Normal
                Splash.LabelInfo.Image = Risorse.Immagini.Bitmap("info")
                Splash.LabelInfo.Text = $"{Utx.Utente.ErroreUtente}.

Aggiornare con un'altra utenza i dati CIP/Soggetti/Utenze da

Menù manutenzione > Strumenti > Gestione rete

e poi riprovare oppure contattare l'assistenza"

                Splash.Show()
                Splash.Refresh()
#If DEBUG Then
                Threading.Thread.Sleep(3000)
#Else
                Threading.Thread.Sleep(10000)
#End If
                Return False
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Private Sub CreaBag()
        Try
            Utx.Globale.FullPathBag = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "Utx.Bag")
            'serializzo oggetti
            Dim Bag As New Utx.Bag
            With Bag
                .Paths = Utx.Globale.Paths
                .Ente = Utx.Globale.ProfiloEnteGestore
                .Utente = Utx.Globale.UtenteCorrente
                .AgenziaRichiesta = Utx.Globale.AgenziaRichiesta
                .Proxy = Utx.Globale.UniProxy
            End With
            Utx.NetFunc.CryptoSerialize(Bag, Utx.Globale.FullPathBag, "guido&st")
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub PulizieUtente()
        Try
            'file liveupdate
            For Each f As String In Directory.GetFiles(Utx.Globale.Paths.CartellaApp, "LUP.*.*.exe")
                File.Delete(f)
            Next
            'vecchi file liveupdate 04/08/2022 - rimuovere a regime
            For Each f As String In Directory.GetFiles(Utx.Globale.Paths.CartellaApp, "LUP.*.exe")
                File.Delete(f)
            Next
            'cartelle mail
            For Each c As String In Directory.GetDirectories(Utx.Globale.Paths.CartellaTempUtente, "*.Mail")
                My.Computer.FileSystem.DeleteDirectory(c, FileIO.DeleteDirectoryOption.DeleteAllContents)
            Next
#If Not DEBUG Then
            'vecchie cartelle di importazione
            For Each c As String In Directory.GetDirectories(Path.Combine(Utx.Globale.Paths.CartellaApp, "Arrivi"))
                Dim Cartella As String = Path.GetFileName(c)
                If Cartella.Length = 5 AndAlso IsNumeric(Cartella) Then
                    'se non è un codice attualmente gestito
                    If Utx.EnteGestore.CodiciGestiti.Contains(Cartella) = False Then
                        My.Computer.FileSystem.DeleteDirectory(c, FileIO.DeleteDirectoryOption.DeleteAllContents)
                    End If
                End If
            Next
#End If
        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
        End Try
    End Sub

    Private Sub UtenteCorrente_RichiestaAggiornamentoEssigReti() Handles UtenteCorrente.RichiestaAggiornamentoEssigReti
        Splash.PrimoPiano = False 'per vedere eventuali errori
        Dim Chiave As New Utx.SettingItem(Utx.SettingItem.Sezioni.ESCLUSIONI, Utx.SettingItem.Chiavi.LISTE_UTENTI,
                                          Utx.SettingOMW.TipoOperazione.LETTURA_CON_VALORE)
        If Chiave.ItemResult.Esiste Then
            MsgBox("Utente non abilitato all'operazione richiesta")
        Else
            Chiave.SetItem(Utx.SettingItem.Sezioni.AUTOMATISMI, Utx.SettingItem.Chiavi.LISTE_UTENTI, "",
                           Utx.SettingOMW.TipoOperazione.CANCELLAZIONE)
            Dim az As New ExportLib.Azioni
            Try
                az.AggiornaListeEssig()
            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
            End Try
        End If
    End Sub

#If DEBUG Then
    Public Class OutputData
        Public Property Data As String
    End Class

    Private Sub ZonaTest()
        'Dim Bag As Utx.Bag = Utx.NetFunc.CryptoDeserialize(Of Utx.Bag)("C:\ApplicazioniDirezione\UTW\Temp\guido\Utx.Bag", "guido&st")
        'Dim Bag As Utx.Bag = Utx.NetFunc.CryptoDeserialize(Of Utx.Bag)("C:\Users\guido\Desktop\Utx.Bag", "guido&st")

        'CODICE PER REALIZZARE FILE KOINÈ PER DIFFERENZA FRA 2 XML
        'Try
        '    Dim uno As String = File.ReadAllText("C:\Users\guido\Desktop\36883\1.xml")
        '    Dim due As String = File.ReadAllText("C:\Users\guido\Desktop\36883\2.xml")

        '    Dim start As Integer = 0
        '    Dim elementi As Integer = 0
        '    Dim analizzati As Integer = 0

        '    Do While True
        '        Dim PosInizio As Integer = due.IndexOf("  <destinatario", start, StringComparison.InvariantCultureIgnoreCase)

        '        If PosInizio < 0 Then
        '            Exit Do
        '        End If
        '        Dim PosFine As Integer = due.IndexOf("</destinatario>", PosInizio, StringComparison.InvariantCultureIgnoreCase) + 15
        '        Dim blocco As String = due.Substring(PosInizio, PosFine - PosInizio)

        '        If uno.Contains(blocco) = False Then
        '            File.AppendAllText("C:\Users\guido\Desktop\36883\3.xml", blocco + Environment.NewLine)
        '            elementi += 1
        '        Else
        '            File.AppendAllText("C:\Users\guido\Desktop\36883\scartati.xml", blocco + Environment.NewLine)
        '        End If
        '        analizzati += 1

        '        start = PosFine + 1
        '    Loop

        '    Dim tre As String = File.ReadAllText("C:\Users\guido\Desktop\36883\3.xml")
        '    Dim Doppioni As Integer = 0
        '    Dim ConTelefono As Integer = 0
        '    Dim ConEmail As Integer = 0
        '    Dim ConLettera As Integer = 0
        '    start = 0
        '    Do While True
        '        Dim PosInizio As Integer = uno.IndexOf("codicesa=""", start, StringComparison.InvariantCultureIgnoreCase)

        '        If PosInizio < 0 Then
        '            Exit Do
        '        End If
        '        PosInizio += 10

        '        Dim CF As String = uno.Substring(PosInizio, uno.IndexOf("""", PosInizio, StringComparison.InvariantCultureIgnoreCase) - PosInizio)

        '        Dim telefono, email As String
        '        PosInizio = uno.IndexOf("<telefono>", PosInizio, StringComparison.InvariantCultureIgnoreCase) + 10
        '        telefono = uno.Substring(PosInizio, uno.IndexOf("</telefono>", PosInizio, StringComparison.InvariantCultureIgnoreCase) - PosInizio).Trim
        '        PosInizio = uno.IndexOf("<email>", PosInizio, StringComparison.InvariantCultureIgnoreCase) + 7
        '        email = uno.Substring(PosInizio, uno.IndexOf("</email>", PosInizio, StringComparison.InvariantCultureIgnoreCase) - PosInizio).Trim

        '        If tre.IndexOf(CF, 0) > 0 Then
        '            Doppioni += 1
        '            If telefono.Length > 0 Then
        '                ConTelefono += 1
        '            ElseIf email.Length > 0 Then
        '                ConEmail += 1
        '            Else
        '                ConLettera += 1
        '            End If
        '        End If
        '        start = PosInizio

        '        If start > uno.Length Then
        '            Exit Do
        '        End If
        '    Loop
        '    Utx.Globale.Log.Info("analizzati {0}", {elementi})
        '    Utx.Globale.Log.Info("elementi {0}", {elementi})
        '    Utx.Globale.Log.Info("doppioni {0}", {Doppioni})
        '    Utx.Globale.Log.Info("doppioni via sms {0}", {ConTelefono})
        '    Utx.Globale.Log.Info("doppioni via email {0}", {ConEmail})
        '    Utx.Globale.Log.Info("doppioni via lettera {0}", {ConLettera})

        '    MsgBox(String.Format("{0}/{1}", elementi, analizzati))

        'Catch ex As Exception
        '    Utx.Globale.Log.Errore(ex)
        'End Try
        'FINE KOINÈ

        'Dim url As String = "http://ai.auasoluzioni.it/ai/exqmd"

        'Dim jsonData As String = "{""agenzia"":""01949"",""sql"":""select ramogestione,sum(tassabile) as totale 
        'from incassi 
        'where year(datafogliocassa)=2024 
        'group by ramogestione
        'order by ramogestione"",""token"":""STEFANO&GUIDO""}"

        'Using client As Net.WebClient = New Net.WebClient()
        '    Try
        '        client.Headers.Add("Content-Type", "application/json") ' Imposta l'header Content-Type
        '        Dim response As New OutputData With {.Data = client.UploadString(url, "POST", jsonData)}

        '        MsgBox(response.Data)

        '    Catch ex As Net.WebException
        '        MsgBox(ex.Message)
        '    End Try
        'End Using

        'For Each tbl As String In "cip/soggetti/polizze".Split("/")
        '    Dim dati As DataTable = Utx.WsCommand.ExecuteNonQuery(String.Format("select top 15000 * from {0}", tbl), "01197").DataTable

        '    Using c As New OleDb.OleDbConnection(Utx.Globale.MDBDriver + "C:\Users\guido\Desktop\01197\01197.mdb")
        '        c.Open()

        '        Using cmd As New OleDb.OleDbCommand
        '            cmd.Connection = c
        '            cmd.CommandText = String.Format("delete * from {0}", tbl)
        '            cmd.ExecuteNonQuery()
        '        End Using

        '        Using da As New OleDb.OleDbDataAdapter(String.Format("select * from {0}", tbl), c)
        '            Using cmdBuilder As New OleDb.OleDbCommandBuilder(da)
        '                da.InsertCommand = cmdBuilder.GetInsertCommand

        '                Dim x As New DataTable
        '                da.Fill(x)

        '                Try
        '                    For Each row As DataRow In dati.Rows
        '                        x.Rows.Add(row.ItemArray)
        '                    Next

        '                Catch ex As Exception
        '                    Utx.Globale.Log.Errore(ex)
        '                End Try
        '                da.Update(x)
        '            End Using
        '        End Using
        '    End Using
        'Next
        'Dim pippo As String() = "1.2.3.4".Split(".")

        'ArchiviaDocumenti()
        'Using c As New OleDb.OleDbConnection(Utx.Globale.MDBDriver + "C:\Users\guido\Desktop\Test agenzie\02640\DbUno.mdb")
        '    c.Open()

        '    Using cmd As New OleDb.OleDbCommand
        '        cmd.Connection = c
        '        'cmd.CommandText = "select * into pippo_app from pippo where false"
        '        'cmd.ExecuteNonQuery()

        '        cmd.CommandText = "select * from pippo order by codicefiscale"
        '        Dim dt As New DataTable
        '        Using da As New OleDb.OleDbDataAdapter(cmd)
        '            da.Fill(dt)

        '            Dim CF As String = ""
        '            For Each row As DataRow In dt.Rows
        '                If CF = row("codicefiscale") Then
        '                    row("progressivofile") = "0"
        '                Else
        '                    For Each col As DataColumn In dt.Columns

        '                    Next
        '                End If
        '                CF = row("codicefiscale")
        '            Next

        '            Using cb As New OleDb.OleDbCommandBuilder(da)
        '                da.UpdateCommand = cb.GetUpdateCommand
        '            End Using

        '            da.Update(dt)
        '        End Using
        '    End Using
        'End Using

        'Using s As New Utx.DatabaseOMW.Database
        '    s.Proxy = Utx.Globale.UniProxy.Proxy
        '    MsgBox(s.CreaDbUtente(Utx.Globale.AgenziaRichiesta.CodiceAgenzia, Utx.Globale.Token))
        'End Using
        'End
        'PER CSV sinistri per SIA 20/02/2023
        'Using c As New OleDb.OleDbConnection(Utx.Globale.MDBDriver + "C:\ApplicazioniDirezione\UT\Dati\02379\Sinistri.mdb")
        '    c.Open()

        '    Using cmd As New OleDb.OleDbCommand
        '        cmd.Connection = c

        '        Dim dt As New DataTable
        '        Using da As New OleDb.OleDbDataAdapter(cmd)
        '            'corrente
        '            cmd.CommandText = "Select * from sinistridp"
        '            da.Fill(dt)
        '            Utx.NetFunc.DataTable2Csv(dt, Path.Combine(Utx.Globale.UtenteCorrente.Desktop, "Sinistri_02379.csv"))

        '            dt.Clear()
        '            cmd.CommandText = "Select * from sinistrida"
        '            da.Fill(dt)
        '            Utx.NetFunc.DataTable2Csv(dt, Path.Combine(Utx.Globale.UtenteCorrente.Desktop, "Sinistri_02379.csv"), True)

        '            'storico
        '            c.Close()
        '            c.ConnectionString = Utx.Globale.MDBDriver + "C:\ApplicazioniDirezione\UT\Dati\02379\UtStorico.mdb"
        '            c.Open()

        '            dt.Clear()
        '            cmd.CommandText = "Select * from sinistridp"
        '            da.Fill(dt)
        '            Utx.NetFunc.DataTable2Csv(dt, Path.Combine(Utx.Globale.UtenteCorrente.Desktop, "Sinistri_02379.csv"), True)
        '            dt.Clear()
        '            cmd.CommandText = "Select * from sinistrida"
        '            da.Fill(dt)
        '            Utx.NetFunc.DataTable2Csv(dt, Path.Combine(Utx.Globale.UtenteCorrente.Desktop, "Sinistri_02379.csv"), True)
        '        End Using
        '    End Using
        'End Using
        Exit Sub

        Dim Selezione As Integer = 0

        Splash.Close()

        Select Case Selezione
            Case -100
                Exit Sub
            Case -1
                Dim f As New Utx.FormLog
                f.Show()
                Utx.ApplicationLog.FormVisualizzazione = f
                f.Refresh()
                Application.DoEvents()

                'migrazione dati agenzia
                'Utx.Migrazione.MigraDbUno("02539")
                'Utx.Migrazione.MigraTutto("39484")

                'completa la migrazione quando i file sono già sul server
                Using s As New Utx.ServiziOMW.ServizioDatiOMW
                    's.MigraTutto("39484", Utx.ServiziOMW.TipoDatabase.AGENZIA, Utx.Globale.Token)
                    's.MigraTutto("36732", Utx.ServiziOMW.TipoDatabase.AGENZIA, Utx.Globale.Token)
                    's.MigraTutto("36782", Utx.ServiziOMW.TipoDatabase.AGENZIA, Utx.Globale.Token)
                End Using
                End
                Exit Sub
            Case 0
                'FORZA CONSOLIDAMENTO DATI SUL SERVER
                Dim ElencoAgenzie As String = "01197/01306/01949/02116/02372/02518/02539/02687/39484/39553/39582/39621/39769"

                'backup database
                'Dim sql As String = "BACKUP DATABASE DB{0}
                '    TO DISK = 'F:\siti\Utools\Database\Agenzie\{0}\Backup\DB{0}.bak'
                '    WITH FORMAT;"

                'For Each agenzia In ElencoAgenzie.Split("/")
                '    Utx.WsCommand.ExecuteNonQuery(String.Format(sql, agenzia), "00000")
                'Next
                '--------------------------------------

                Using s As New Utx.EventiOMW.GeneraEventi
                    'importa tutti i file in coda nella cartella ArriviMA sul server indipendentemente dal codice agenzia
                    'For Each agenzia In ElencoAgenzie.Split("/")
                    '    s.GeneraEvento(agenzia, "TEST_CONSOLIDA_MA", "", Utx.Globale.Token)
                    'Next

                    'forza rilettura da MAxxxxx in DBxxxxx
                    ElencoAgenzie = "39484"
                    For Each agenzia In ElencoAgenzie.Split("/")
                        'SISTEMAZIONE STORNATE
                        '                        Dim sql As String = "update CalendarioOmnia
                        'set UltimoAggiornamento='01/01/2024'
                        'where tipofile='11'"
                        '                        Utx.WsCommand.ExecuteNonQuery(sql, agenzia)

                        '                        sql = "delete from movpolizze where dataelaborazione >= '01/01/2024'"
                        '                        Utx.WsCommand.ExecuteNonQuery(sql, agenzia)
                        '------------------------------------------------------------------------------------------------

                        s.GeneraEvento(agenzia, "FORZATURA_CONSOLIDA_DB", "", Utx.Globale.Token)
                    Next
                End Using
                End
                Exit Sub
                '=====================================

                'Dim ds As New DataSet
                'Using c As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\guido\Desktop\All_2_Schemi_quantitativi.xls;Extended Properties=""Excel 8.0;HDR=NO;IMEX=1""")
                '    c.Open()

                '    Using cmd As New OleDb.OleDbCommand
                '        cmd.Connection = c

                '        cmd.CommandText = "SELECT *  FROM [CUBO ESG_1$B7:Q133]"
                '        Using da As New OleDb.OleDbDataAdapter(cmd)
                '            Dim dt As New DataTable
                '            da.Fill(dt)

                '            dt.TableName = "Cubo1"
                '            ds.Tables.Add(dt)

                '            Dim f As New Utx.FormDebug(dt)
                '            f.ShowDialog()
                '        End Using

                '        cmd.CommandText = "SELECT *  FROM [CUBO ESG_2$A6:B16]"
                '        Using da As New OleDb.OleDbDataAdapter(cmd)
                '            Dim dt As New DataTable
                '            da.Fill(dt)

                '            dt.TableName = "Cubo2"
                '            ds.Tables.Add(dt)

                '            Dim f As New Utx.FormDebug(dt)
                '            f.ShowDialog()
                '        End Using

                '        cmd.CommandText = "SELECT *  FROM [CUBO ESG_2$A4:L60]"
                '        Using da As New OleDb.OleDbDataAdapter(cmd)
                '            Dim dt As New DataTable
                '            da.Fill(dt)

                '            dt.TableName = "Cubo3"
                '            ds.Tables.Add(dt)

                '            Dim f As New Utx.FormDebug(dt)
                '            f.ShowDialog()
                '        End Using
                '    End Using
                'End Using
                'End
                'Try
                '    Dim strcnn As String = "Data Source=45.130.89.23,23389; Network Library=DBMSSOCN; Initial Catalog=SQLEXPRESS; User ID=utools;Password=Guido.2020"
                '    Dim con As New SqlClient.SqlConnection(strcnn)
                '    con.Open()
                'Catch ex As Exception
                '    MsgBox(ex.Message)
                'End Try

                'Using c As New OleDb.OleDbConnection(Utx.ConnessioniDb.ConnectionString(Utx.ConnessioniDb.Db.INCASSI))
                '    c.Open()

                '    Using da As New OleDb.OleDbDataAdapter("select top 1000 * from incassi", c)
                '        Dim dt As New DataTable
                '        da.Fill(dt)

                '        MsgBox(dt.Compute("min(datafogliocassa)", "true"))
                '    End Using
                'End Using

                'Using s As New Utx.DatabaseOMW.Database
                '    s.CreaTabella("02372", "Setting", Utx.Globale.Token)
                'End Using

                'Using s As New Utx.SettingOMW.GestioneSetting
                '    Dim ch As Utx.SettingOMW.SettingItem = s.ElaboraChiave("02372", New Utx.SettingOMW.SettingItem With {
                '                                                           .Operazione = Utx.SettingOMW.TipoOperazione.LETTURA,
                '                                                           .Sezione = "POSTALIZZAZIONE",
                '                                                           .Chiave = "TEST"}, Utx.Globale.Token)
                '    Dim chiave As New Utx.SettingOMW.SettingItem With {.Operazione = Utx.SettingOMW.TipoOperazione.LETTURA,
                '    .Sezione = "POSTALIZZAZIONE", .Chiave = "TEST2", .Valore = "x", .Utente = "guido"}
                '    chiave = s.ElaboraChiave("02372", chiave, Utx.Globale.Token)
                '    If chiave.Esiste = False Then
                '        MsgBox("la chiave non esiste")
                '    Else
                '        MsgBox(chiave.Valore)
                '    End If
                'End Using
                'Exit Sub
                'F:\siti\Utools\Database\Agenzie\ArriviMA
                'consolidamento MA
                'Using s As New Utx.EventiOMW.GeneraEventi
                '    s.GeneraEvento("02379",
                '                   Utx.ServiziOMW.TipoEvento.CONSOLIDA_MA.ToString,
                '                   "F:\siti\Utools\Database\Agenzie\02379\Temp\1b39398f-e598-47e9-840a-d79977858a35",
                '                   Utx.Globale.Token)
                'End Using
                'End
                'Dim ds As DataSet
                'Dim Arrivi, Sinistri As DataTable
                'Using s As New Utx.EventiOMW.GeneraEventi
                '    'ds = s.Test("02379", Utx.Globale.Token)
                '    'Arrivi = ds.Tables("Arrivi")
                '    'Sinistri = ds.Tables("Sinistri")
                '    'Dim f As New Utx.FormDebug(s.Test("02379", Utx.Globale.Token).Tables(0))
                '    'f.ShowDialog()
                '    's.GeneraEvento("02379", "TEST_MIGRADBUNO", "", Utx.Globale.Token)
                '    s.GeneraEvento("02379", "TEST_CONSOLIDA_MA", "", Utx.Globale.Token)
                '    's.GeneraEvento("02379", "TEST_CONSOLIDA_DB", "", Utx.Globale.Token)
                'End Using
                'End
                'confronto tabelle
                'Dim f As New Utx.FormDebug(Arrivi)
                'f.ShowDialog()
                'f.OrigineDati = Sinistri
                'f.ShowDialog()

                'For Each dr As DataRow In Arrivi.Rows
                '    Dim Esito As Boolean = False
                '    Dim PosArrivi As Integer = dr("ordinal_position")
                '    Utx.Globale.Log.Info("{3}.Arrivi    : {0}, {1}, {2}",
                '                         {dr("column_name"), dr("data_type"), dr("character_maximum_length").ToString, PosArrivi})
                '    For Each row As DataRow In Sinistri.Rows
                '        If row("column_name").ToString.ToUpper = dr("column_name").ToString.ToUpper Then
                '            Esito = True
                '            Dim PosSinistri As Integer = row("ordinal_position")
                '            Utx.Globale.Log.Info("{3}.SinistriDP: {0}, {1}, {2}",
                '                                 {row("column_name"), row("data_type"), row("character_maximum_length").ToString, PosSinistri})
                '            If PosArrivi <> PosSinistri Then
                '                MsgBox(PosArrivi.ToString & ":" & dr("column_name"))
                '            End If
                '            Exit For
                '        End If
                '    Next
                '    Utx.Globale.Log.Info()
                'Next
                'End

                'Exit Sub
                'Using c As New OleDb.OleDbConnection(Utx.ConnessioniDb.ConnectionString(Utx.ConnessioniDb.Db.INCASSI))
                '    c.Open()
                '    Dim tabelle As DataTable = c.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
                '    Dim f As New Utx.FormDebug(tabelle)
                '    f.ShowDialog()
                'End Using
                'AnalisiDatabase.AnalisiCampi()

                'For Each db As String In Directory.GetFiles(Path.Combine(Utx.Globale.Paths.CartellaDati, "02379"))
                '    Using c As New OleDb.OleDbConnection(Utx.ConnessioniDb.ConnectionString(Path.GetFileName(db)))
                '        c.Open()
                '        Dim tabelle As DataTable = c.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
                '        'Dim f As New Utx.FormDebug(tabelle)
                '        'f.ShowDialog()

                '        For Each tbl As DataRow In tabelle.Rows
                '            If tbl("TABLE_TYPE") = "TABLE" Then
                '                Using cn As New OleDb.OleDbConnection(Utx.ConnessioniDb.ConnectionString(Path.GetFileName(db)))
                '                    cn.Open()
                '                    Dim colonne As DataTable = c.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Columns, New Object() {Nothing, Nothing, tbl("TABLE_NAME"), Nothing})

                '                    Utx.Globale.Log.Info("Db: {0} - Tabella: {1} - Colonne: {2}", {Path.GetFileName(db), tbl("TABLE_NAME"), colonne.Rows.Count.ToString})
                '                    Dim f As New Utx.FormDebug(colonne)
                '                    f.ShowDialog()
                '                End Using
                '            End If
                '        Next
                '    End Using
                'Next
                'Exit Sub
                'Using s As New Utx.ServiziOMW.ServizioDatiOMW
                '    s.Proxy = Utx.Globale.UniProxy.Proxy

                '    Dim Agenzia As String = "00000"

                '    For Each db As String In Directory.GetFiles(Utx.Globale.Paths.CartellaDatiComuni)

                '        Dim FileZip As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "Db.zip")
                '        File.Delete(FileZip)

                '        Utx.LibreriaZip.SevenZip.ZipFile(db, FileZip)

                '        Dim CartellaUpload As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "Upload")
                '        Directory.CreateDirectory(CartellaUpload)

                '        Dim fileName As String = FileZip
                '        Dim fileSizeInMB As Integer = 20
                '        Dim baseFileName As String = Path.GetFileName(fileName)
                '        Dim MaxSize As Integer = fileSizeInMB * (1024 * 1024)
                '        Dim fsBuffer As Byte() = New Byte(1023) {}
                '        Using fileStream As New FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read)
                '            Dim totalFileParts As Integer = 0
                '            If fileStream.Length < MaxSize Then
                '                totalFileParts = 1
                '            Else
                '                Dim preciseFileParts As Single = (CSng(fileStream.Length) / CSng(MaxSize))
                '                totalFileParts = CInt(Math.Ceiling(preciseFileParts))
                '            End If

                '            Dim filePartCount As Integer = 0
                '            While fileStream.Position < fileStream.Length
                '                Dim filePartName As String = String.Format("{0}.part_{1}-{2}", baseFileName, (filePartCount + 1).ToString(), totalFileParts.ToString())
                '                filePartName = Path.Combine(CartellaUpload, filePartName)
                '                Using fsFilePart As New FileStream(filePartName, FileMode.Create)
                '                    Dim bytesRemaining As Integer = MaxSize
                '                    Dim bytesRead As Integer = 0
                '                    While bytesRemaining > 0
                '                        bytesRead = fileStream.Read(fsBuffer, 0, Math.Min(bytesRemaining, 1024))

                '                        If bytesRead = 0 Then
                '                            Exit While
                '                        End If

                '                        fsFilePart.Write(fsBuffer, 0, bytesRead)
                '                        bytesRemaining -= bytesRead
                '                    End While
                '                End Using
                '                filePartCount += 1
                '            End While
                '        End Using

                '        For Each fileChunk In Directory.GetFiles(CartellaUpload)
                '            Dim b As Byte() = File.ReadAllBytes(fileChunk)
                '            If s.UploadDatabaseChunk(Agenzia, b, Path.GetFileName(fileChunk), Path.GetFileName(db), False, Utx.Globale.Token) = False Then
                '                MsgBox("errore", MsgBoxStyle.Exclamation)
                '            End If
                '            File.Delete(fileChunk)
                '        Next
                '    Next
                '    s.MigraTutto(Agenzia, Utx.Globale.Token)
                'End Using
            Case 1
                'test serializzazione datatable
                Dim xml As String = Path.Combine(Utx.Globale.UtenteCorrente.Desktop, "sinistri.xml")
                'Dim Chiave As String = "19011957"
                Using c As New OleDb.OleDbConnection(Utx.ConnessioniDb.ConnectionString(Utx.ConnessioniDb.Db.SINISTRI))
                    c.Open()

                    Using cmd As New OleDb.OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "select * from sinistridp"

                        Using da As New OleDb.OleDbDataAdapter(cmd)
                            Dim dt As New DataTable
                            da.Fill(dt)

                            Utx.NetFunc.Serialize(dt, xml)
                        End Using
                    End Using
                End Using
                End
                'Dim dt2 As DataTable = Utx.NetFunc.CryptoDeserialize(Of DataTable)(xml, Chiave)
                'Using f As New Utx.FormDebug(dt2)
                '    f.ShowDialog()
                'End Using
            Case 3
                UtentiOnLine(1, 100)
            Case 5
                'download prima nota
                DownloadPN("02260", "01/01/2023", Today)
                End
            Case 7
                Dim Query As String = "Polizze con CIP incongruenti"
                UniSql.CriptaQuery.CreaQueryCriptata(Query)
                Dim sql As New UniSql.UniSql
                sql.ShowGridAndGetDataTable(Query, False)
            Case 8
                UniSql.CriptaQuery.CreaCatalogo(Today)
            Case 11
                Using s As New Utx.ServiziOMW.ServizioDatiOMW
                    Dim agenzia As String = "02699"
                    'MsgBox(s.VerificaMigrazione(Utx.Globale.Token))
                    'If s.EsisteDb(agenzia, Utx.Globale.Token) Then
                    '    MsgBox(s.ReportMigrazione(Utx.Globale.Token))
                    'End If
                End Using
                'Dim th As New Thread(Sub()
                '                         Dim s As New Utx.Uniweb.ServizioDatiEx
                '                         Dim agenzia As String = "02534"
                '                         If s.EsisteDb(agenzia, Utx.Globale.Token) Then
                '                             s.BackupSqlServer(agenzia, Utx.Globale.Token)
                '                         End If
                '                     End Sub)
                'th.Start()
                Exit Sub
                'Using s As New Utx.Uniweb.ServizioDatiEx
                '    Dim agenzia As String = "02534"
                '    If s.EsisteDb(agenzia, Utx.Globale.Token) Then
                '        s.BackupSqlServer(agenzia, Utx.Globale.Token)
                '    End If
                'End Using
        End Select
        End

        'Token = Format(Today, "yyyy_MM_dd_") & "19011957"
        'MsgBox(Utx.SIA.InizioInvioMA("02202"))
        'Using s As New Utx.SettingAgenzia.ConfiguraSede
        '    'MsgBox(s.CancellaSwitchMA("0"))
        '    'MsgBox(s.EseguiSwitchMA("UPDATE InvioMA SET [Note] = UCASE([Note])", Format(Today, "yyyy_MM_dd_") & "19011957"))
        'End Using

        'Using s As New Utx.SettingAgenzia.ConfiguraSede
        '    s.CancellaSwitchMA("01306")
        '    s.CancellaSwitchMA("02542")
        '    s.CancellaSwitchMA("64818")
        'End Using

        'abilita switch contabilità
        'Using s As New Utx.SettingAgenzia.ConfiguraSede
        '    Splash.Close()

        '    Dim Codici As String = "36431/65218"
        '    Dim Luogo As String = "IVREA/IVREA"

        '    If Codici.Split("/").Length <> Luogo.Split("/").Length Then
        '        MsgBox("Errore", MsgBoxStyle.Exclamation)
        '        End
        '    End If
        '    For k As Integer = 0 To Codici.Split("/").Length - 1
        '        Dim Codice As String = Codici.Split("/")(k).PadLeft(5, "0")
        '        Dim Sede As String = Luogo.Split("/")(k)
        '        MsgBox(String.Format("Agenzia {0} - {1}:  {2}", Codice, Sede, s.AbilitaSwitchMA(Codice, #7/24/2019#, #12/31/2100#, Sede)))
        '    Next
        'End Using

        'scarica immagini con url
        'Using wc As New System.Net.WebClient
        '    Dim UrlDownload As String = "https://image.slidesharecdn.com/20191108120556646-191108111409/85/addendum-al-contratto-di-affitto-con-obbligo-di-acquisto-di-rami-dazienda-{0}-320.jpg"
        '    Dim Dest As String = "C:\Users\guido\Desktop\xxx\Add_{0}.jpg"
        '    For pagina As Integer = 1 To 12
        '        wc.CachePolicy = New Net.Cache.RequestCachePolicy(Net.Cache.RequestCacheLevel.NoCacheNoStore)
        '        wc.DownloadFile(String.Format(UrlDownload, pagina), String.Format(Dest, pagina))
        '    Next
        'End Using
    End Sub

    Private Sub UtentiOnLine(Optional TipoOperazione As Integer = 1, Optional Utenti As Integer = 100)
        'per configurare il numero di utenti on-line
        Dim s As New Utx.SettingAgenzia.ConfiguraSede
        MsgBox(s.UpdateMaxUtenti(TipoOperazione, Utenti))
        MsgBox(s.UtentiOnLine(TipoOperazione))
    End Sub

    Private Sub DownloadPN(Agenzia As String, Inizio As Date, Fine As Date)
        'download prime note
        Dim Cartella As String = Path.Combine(Utx.Globale.UtenteCorrente.Desktop, "Prima nota " & Agenzia)
        Directory.CreateDirectory(Cartella)
        Do While Inizio <= Fine
            Dim File As String = $"{Agenzia}_PNOTA_{Inizio:yyyyMMdd}.exe"
            Dim url As String = $"https://ueba.unipolsai.it/dati/download1.asp?file={File}&percorso=DATI/ARCHIVIO/PRIMANOTA/"

            Try
                Using wc As New System.Net.WebClient
                    'assegno le credenziali al webclient
                    wc.Credentials = New Net.NetworkCredential("139718ak", "Firenze.1000", "uniage") 'Utx.Globale.UtenteCorrente.Credenziali
                    'scarico il file (non lo prendo dalla cache)
                    wc.CachePolicy = New Net.Cache.RequestCachePolicy(Net.Cache.RequestCacheLevel.NoCacheNoStore)
                    wc.DownloadFile(url, Path.Combine(Cartella, File))
                End Using
            Catch ex As Exception
                Utx.Globale.Log.Info(url)
            End Try
            Inizio = Inizio.AddDays(1)
        Loop
    End Sub

#End If

    Sub CreaLinkAutoStart()
#If Not DEBUG Then
        Try
            'avvio automatico UT disabilitato e viene cancellato dopo MFA
            Dim Link As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "AutoOM.lnk")

            If File.Exists(Link) Then
                File.Delete(Link)
            End If

            'avvio automatico live update all'avvio del PC
            Link = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "UpdateUT.lnk")

            If File.Exists(Link) = False Then
                Utx.Globale.Log.Info("creo file autoexexc UpdateUT")
                Dim WshShell As Object
                Dim oMyShortcut As Object

                WshShell = CreateObject("WScript.Shell")
                oMyShortcut = WshShell.CreateShortcut(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "UpdateUT.lnk"))
                oMyShortcut.TargetPath = Path.Combine(Utx.Globale.Paths.CartellaApp, "Assistenza.exe")
                oMyShortcut.Arguments = "HIDE"
                oMyShortcut.Save()
            Else
                Utx.Globale.Log.Info("file autoexexc UpdateUT già esistente")
            End If
        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
        End Try
#End If
    End Sub

    'Public Function AssemblyResolver(sender As Object, args As ResolveEventArgs)
    '    'Utx.Globale.Log.Info(args.Name)
    '    'If args.Name.Contains("Version=20.0.53.0") AndAlso args.Name.Contains("e92353a6bf73fffc") Then
    '    '    Dim Libreria As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "DLL", "EO.2020", args.Name.Split(",")(0) & ".dll")
    '    '    Utx.Globale.Log.Info("* >" & Libreria)
    '    '    Return Reflection.Assembly.LoadFrom(Libreria)
    '    'Else
    '    '    Return Nothing
    '    'End If
    'End Function

    Friend Sub AvviaLiveUpdate()
        Try
            LiveUpThread = New Threading.Thread(Sub()
                                                    Utx.Globale.Log.Info("richiamo live update - idapp UTW user {0}", {Utx.Globale.UtenteCorrente.UniageUser})
                                                    LiveUpdate.Main.ControlloAggiornamenti("UTW", Utx.Globale.UtenteCorrente.UniageUser)
                                                End Sub)
            LiveUpThread.Start()
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub Chiusura() Handles UtTimer.Chiusura
        On Error Resume Next
        If LiveUpThread IsNot Nothing AndAlso LiveUpThread.IsAlive Then
            Call New Utx.NotificaRapida().Visualizza("in attesa chiusura controllo aggiornamenti...")
            Utx.Globale.Log.Info("in attesa della chiusura del thread live update")
            LiveUpThread.Join()
        End If
        Menu.Chiudi()
    End Sub

    Private Sub ArchiviaDocumentiSinistri()
        Try
            Dim Query As String = $"SELECT CODICEFISCCONTRPOL,Compagnia,AgenziaSinistro,EsercizioSinistro,NumeroSinistro 
                FROM SinistriDP 
                WHERE StatoBilancistico IN ('LT','SS') 
                    AND YEAR(AnnoMeseCompetenza) < {Today.Year - 2}"

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query).DataTable

            Dim Notifica As New Utx.FormNotifica
            With Notifica
                .Stile = Utx.FormNotifica.Style.ANTRACITE
                .Messaggio = "..."
                .Show()
            End With

            Dim Progressivo As Integer = 0
            Dim Trasferiti As Integer = 0
            Notifica.Messaggio = $"Sinistri {Progressivo} su {dt.Rows.Count}"

            For Each row In dt.Rows
                Dim IdSinistro As String = $"{row("Compagnia"):0}-{row("AgenziaSinistro"):0000}-{row("EsercizioSinistro"):0000}-{row("NumeroSinistro"):0000000}"
                Dim dp As New UnitoolsDocumenti.DepositoPratica(row("CODICEFISCCONTRPOL"), IdSinistro)

                If Directory.Exists(dp.FullPathPratica) Then
                    If Directory.Exists(dp.FullPathStoricoPratica) Then
                        'se la directory nello storico già esiste copio i file che non ci sono e poi la cancello
                        For Each f As String In Directory.GetFiles(dp.FullPathPratica)
                            Dim Destinazione As String = Path.Combine(dp.FullPathStorico, Path.GetFileName(f))
                            If File.Exists(Destinazione) = False Then
                                File.Copy(f, Destinazione)
                            End If
                        Next
                        Directory.Delete(dp.FullPathPratica, True)
                    Else
                        My.Computer.FileSystem.MoveDirectory(dp.FullPathPratica, dp.FullPathStoricoPratica)
                    End If
                    Trasferiti += 1
                End If
                Progressivo += 1

                If Progressivo / 20 = Progressivo \ 20 Then
                    Notifica.Messaggio = $"Sinistri {Progressivo} su {dt.Rows.Count} ({Progressivo / dt.Rows.Count:##0.00%}){Environment.NewLine}Trasferiti {Trasferiti}"
                End If
            Next
            Notifica.Chiudi()

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
        End
    End Sub

    Private Function ResetGoogleCache() As Boolean
        Try
#If DEBUG Then
            Return False
#End If
            'identifico agenzia-pc-utente windows
            Dim Id As String = $"{Utx.Globale.UtenteCorrente.AgenziaUtente}-{Environment.MachineName}-{Environment.UserName}"

            Using s As New Utx.ServiziOMW.ServizioDatiOMW
                s.Proxy = Utx.Globale.UniProxy.Proxy
                'chiedo consenso al server per la cancellazione della cache
                If s.ConsensoGoogleFsCache(Id) Then
                    'chiudo tutti i processi della app google drive
                    For Each p As Process In System.Diagnostics.Process.GetProcessesByName("GoogleDriveFS")
                        Utx.Globale.Log.Info(p.ProcessName)
                        p.Kill()
                    Next
                    Threading.Thread.Sleep(6000)
                    'rilevo la cartella della cache e la cancello
                    Dim GoogleDriveCache As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AppData\Local\Google\DriveFS")
                    Directory.Delete(GoogleDriveCache, True)
                    'aggiorno il flag
                    s.FlagGoogleFsCache(Id)
                    'avviso l'utente
                    MsgBox($"E' stata cancellata la cache di Google drive.

E' necessario riavviare Google drive e successivamente OmniaManager.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

#If DEBUG Then
    Private Function DbConTabella(NomeTabella As String) As DataTable
        Try
            Dim Sql As String = String.Format("DECLARE @TableName NVARCHAR(256) = '{0}';
            DECLARE @SQL NVARCHAR(MAX) = N'';

            SELECT @SQL = @SQL + 
                'SELECT ''' + name + ''' AS DatabaseName FROM [' + name + '].INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = ''' + @TableName + ''' UNION ALL '
            FROM sys.databases
            WHERE state_desc = 'ONLINE' AND database_id > 4; -- esclude i database di sistema

            SET @SQL = LEFT(@SQL, LEN(@SQL) - 10); -- rimuove l'ultimo 'UNION ALL'

            EXEC sp_executesql @SQL;", NomeTabella)

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Sql).DataTable
            Dim f As New Utx.FormDebug(dt)
            f.ShowDialog()

            Return dt

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Private Sub EseguiSqlSuDb()
        Try
            Dim Sql As String
            'trova tutti i db in cui è presente la tabella
            For Each row As DataRow In DbConTabella("FigureProduttive").Rows
                Try
                    'cancello la view FigureProduttive
                    Sql = "IF EXISTS (SELECT * FROM sys.views WHERE name = 'FigureProduttive')
                    BEGIN
                         drop view FigureProduttive 
                    END"
                    Utx.WsCommand.ExecuteNonQuery(Sql, row(0).ToString.Substring(2, 5))
                    'cancello la tabella FigureProduttive
                    Sql = "IF EXISTS (SELECT * FROM sys.tables WHERE name = 'FigureProduttive')
                    BEGIN
                         drop table FigureProduttive 
                    END"
                    Utx.WsCommand.ExecuteNonQuery(Sql, row(0).ToString.Substring(2, 5))
                    'creo la nuova view
                    Sql = "Create view FigureProduttive AS  
		                SELECT A.Cip   AS IDFiguraProduttiva  
		                , A.DeskCip    AS FiguraProduttiva  
		                , A.DataInizio AS DataAttivazione  
		                , A.DataFine   AS DataDisattivazione,
		                CASE
		                    WHEN A.DataFine < GETDATE() THEN 'N'
		                    ELSE 'S'
		                END
		                AS Attiva
		                FROM Cip AS A  
		                LEFT JOIN ContattiCip AS B 
                            ON A.Cip = B.Cip
		                WHERE A.Cip > 0"
                    Utx.WsCommand.ExecuteNonQuery(Sql, row(0).ToString.Substring(2, 5))

                Catch ex As Exception
                    Utx.Globale.Log.Errore(ex)
                End Try
            Next
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub
#End If
    Private Sub ControlloCartelleDoppie()
        Try
            Utx.Globale.Log.Info("Verifica cartelle doppie su Google Drive")

            'flag di controllo
            Dim Flag As String = "Unitools.OK"

            Dim CartelleUT As String() = Directory.GetDirectories(Utx.Globale.Paths.NomeUnitaDati, "Unitools*", SearchOption.TopDirectoryOnly)

            'controllo se ci sono più di una cartella UT su M:
            If CartelleUT.Length > 1 Then
                Dim NumeroFlag As Integer = 0
                'se > 1 controllo se una ha il flag di controllo
                For Each d As String In CartelleUT
                    If File.Exists(Path.Combine(d, Flag)) Then
                        NumeroFlag += 1
                    End If
                Next

                Select Case NumeroFlag
                    Case 0 'PIÙ DI UNA CARTELLA E NESSUN FLAG
                        MsgBox(String.Format("Presenti cartelle Unitools duplicate: contattare l'assistenza.{0}{0}L'applicazione verrà chiusa.", Environment.NewLine),
                               MsgBoxStyle.Exclamation)
                        End

                    Case 1 'PIÙ DI UNA CARTELLA E UN SOLO FLAG
                        Dim CartellaBak As String = Path.Combine(Utx.Globale.Paths.NomeUnitaDati, "UT.Doppie")
                        Directory.CreateDirectory(CartellaBak)

                        Dim Notifica As New Utx.FormNotifica
                        With Notifica
                            .Stile = Utx.FormNotifica.Style.BIANCO_GRIGIO
                            .Show()
                            .Messaggio = "Recupero documenti"
                        End With

                        'rinominare le cartelle senza flag
                        For Each d As String In CartelleUT
                            If File.Exists(Path.Combine(d, Flag)) = False Then
                                'CARTELLA SBAGLIATA: rinominare con timestamp
                                Dim Destinazione As String = Path.Combine(CartellaBak, $"UT.{Now:ddMMyyyy_HHmm}")
                                Directory.Move(d, Destinazione)
                                'recupero ricorsivamente eventuali documenti dalla cartella spostata nei doc di unitools
                                RecuperoDocumenti(Path.Combine(Destinazione, "Documenti"), Utx.Globale.Paths.CartellaDocumenti, Notifica)
                            End If
                        Next
                        Notifica.ChiusuraImmediata()

                        'controllare il nome della cartella con flag
                        For Each d As String In CartelleUT
                            If Directory.Exists(d) Then
                                If File.Exists(Path.Combine(d, Flag)) Then
                                    'È LA CARTELLA GIUSTA CON IL FLAG
                                    If Path.GetFileName(d).ToLower = "unitools" Then
                                        'il nome è già corretto - non fare niente
                                    Else
                                        'nome sbagliato: rinominare come unitools
                                        Directory.Move(d, Path.Combine(Utx.Globale.Paths.NomeUnitaDati, "Unitools"))
                                    End If
                                End If
                            End If
                        Next

                    Case Else 'PIÙ DI UNA CARTELLA E PIÙ DI UN FLAG
                        MsgBox(String.Format("Presenti cartelle Unitools duplicate: contattare l'assistenza.{0}{0}L'applicazione verrà chiusa.", Environment.NewLine), MsgBoxStyle.Exclamation)
                        End
                End Select
            Else
                'una sola cartella, se non esiste scrivo il flag?
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub RecuperoDocumenti(Origine As String, Destinazione As String, Notifica As Utx.FormNotifica)
        Try
            If Directory.Exists(Origine) = False Then Exit Sub

            Notifica.Messaggio = $"Cartelle duplicate{Environment.NewLine}recupero documenti {Path.GetFileName(Origine)}"

            'Copia i file nella nuova posizione
            For Each f In Directory.GetFiles(Origine)
                Dim DestFile = Path.Combine(Destinazione, Path.GetFileName(f))
                If File.Exists(DestFile) Then
                    File.Delete(DestFile)
                Else
                    File.Copy(f, DestFile, True)
                    My.Computer.FileSystem.MoveFile(f, DestFile)
                End If
            Next

            'Copia le sottocartelle ricorsivamente
            For Each cartella In Directory.GetDirectories(Origine)
                Dim DestFolder = Path.Combine(Destinazione, Path.GetFileName(cartella))
                Directory.CreateDirectory(DestFolder)
                RecuperoDocumenti(cartella, DestFolder, Notifica) 'Chiamata ricorsiva
            Next

            'se la cartella è vuota la cancello
            If Directory.GetFiles(Origine).Length = 0 Then
                Directory.Delete(Origine)
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub
End Module
