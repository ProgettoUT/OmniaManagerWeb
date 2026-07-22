Imports System.IO

Public Class Menu

    Public Event ConnessioneEmme()
    Public Event DisconnessioneEmme()

    Public Shared TitoloFinestra As String = Utx.Globale.TitoloApp
    Public WithEvents OM As OmniaHtml.Maschera

    'Private WithEvents IconaNotifica As NotifyIcon
    Private WithEvents FormAnagrafiche As Anag.FormAnagrafiche
    Private WithEvents FormSinistri As Sinistri.FormSinistri
    Private WithEvents FormPatto As Patto.FormPattoRca
    Private WithEvents FormProdottiLiberi As Patto.FormProdotti
    Private WithEvents FormBudget As Budget.FormBudget
    Private WithEvents MonitorCentralino As Centralino.FormAvvioCentralino
    Private WithEvents TimerChiusura As Timer
    Private WithEvents FormPostalizzazione As UniCom.FormPostalizzazione
    Private WithEvents CambioAgenzia As Utx.FormCambioAgenzia
    Private NotificaChiusura As Utx.FormNotifica
    Private NotificaAttesa As Utx.FormNotifica
    Private Notifica As Utx.FormNotifica
    Private WithEvents Esporta As UniFeed.Esporta
    Private WithEvents UtxEventi As New Utx.Eventi
    Public WithEvents Estrazione As UniSql.frmEsplora

    Private WithEvents MsgTimer As Timer

    Sub New()
        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False 'per accesso illegale a altro thread (per chiusura centralino)
        ImpostaMenu()
        Start()
    End Sub

    Private Sub ImpostaMenu()
        Try
            OM = New OmniaHtml.Maschera
            OM.settaggio.Lancer = True 'per avviare show (false per avviare in showmodal)
#If DEBUG Then
            With OM.settaggio
                .AgenziaMadre = Utx.Globale.ProfiloEnteGestore.AgenziaMadre
                .CodiceSede = Utx.Globale.ProfiloEnteGestore.CodiceSede
                .CodiceFiscale = Utx.Globale.UtenteCorrente.CodiceFiscale
                .Nome = Utx.Globale.UtenteCorrente.NomeUtente
                .Ruolo = Utx.Globale.UtenteCorrente.Ruolo
                .DescrzioneRuolo = Utx.Globale.UtenteCorrente.DeskRuolo
                .IsAgente = Utx.Globale.UtenteCorrente.IsAgente
                .UniageUser = Utx.Globale.UtenteCorrente.UniageUser
                .UniagePw = Utx.Globale.UtenteCorrente.UniagePw
                .RUI = Utx.Globale.UtenteCorrente.RUI
                .DataRUI = Utx.Globale.UtenteCorrente.DataRUI
                .urlSia = UrlSia()
                .omProxy = Utx.Globale.UniProxy.Proxy
                'ridimensionamento finestra
                .cicliRidimensionamento = 4
                .riduzioneFinestra = False
                .labelAgenzia = .AgenziaMadre
                .labelMenuRidotto = InfoAgenzia()
                'login ow8
                .UserOW = Utx.Globale.SettingUtente.LeggiValoreCriptato(Utx.GestioneFlag.TipoFlag.OW1, "19011957", "")
                .PasswordOW = Utx.Globale.SettingUtente.LeggiValoreCriptato(Utx.GestioneFlag.TipoFlag.OW2, "19011957", "")
                '+personalizzazioni del menù: campi db
                '"chiave"
                '"descrizione"
                '"targetComando": U comando interno per unitools; L chiave è un link
                '"targetNuovaPagina": 0  pagina corrente; 1 nuova pagina
                '"id_menu": sinistri-menu; portafoglio-menu; quitenzamento-menu; comunicatore-menu; adempimenti-menu; gestione-menu; pattounipol-menu;
                'sms-menu;  utilita-menu; manutenzione-menu; impostazione-menu; personale-menu
                '.dtMenuPersonale = Utx.EnteGestore.MenuExtra(Utx.Globale.ProfiloEnteGestore.AgenziaMadre, Utx.Globale.ProfiloEnteGestore.CodiceSede, Utx.Globale.UtenteCorrente.UniageUser)
                .dtMenuPersonale = MenuExtra() 'per i test
            End With
#Else
            With OM.settaggio
                .AgenziaMadre = Utx.Globale.ProfiloEnteGestore.AgenziaMadre
                .CodiceSede = Utx.Globale.ProfiloEnteGestore.CodiceSede
                .CodiceFiscale = Utx.Globale.UtenteCorrente.CodiceFiscale
                .Nome = Utx.Globale.UtenteCorrente.NomeUtente
                .Ruolo = Utx.Globale.UtenteCorrente.Ruolo
                .DescrzioneRuolo = Utx.Globale.UtenteCorrente.DeskRuolo
                .IsAgente = Utx.Globale.UtenteCorrente.IsAgente
                .UniageUser = Utx.Globale.UtenteCorrente.UniageUser
                .UniagePw = Utx.Globale.UtenteCorrente.UniagePw
                .RUI = Utx.Globale.UtenteCorrente.RUI
                .DataRUI = Utx.Globale.UtenteCorrente.DataRUI
                .urlSia = UrlSia()
                .omProxy = Utx.Globale.UniProxy.Proxy
                .UserOW = Utx.Globale.SettingUtente.LeggiValoreCriptato(Utx.GestioneFlag.TipoFlag.OW1, "19011957", "")
                .PasswordOW = Utx.Globale.SettingUtente.LeggiValoreCriptato(Utx.GestioneFlag.TipoFlag.OW2, "19011957", "")
                'ridimensionamento finestra
                .cicliRidimensionamento = 8 'cicli da 300 ms
                .riduzioneFinestra = True
                .labelAgenzia = .AgenziaMadre
                .labelMenuRidotto = InfoAgenzia()
                .dtMenuPersonale = MenuExtra()
            End With
#End If
            'Utx.Globale.Log.Trace(Utx.Globale.ProfiloEnteGestore.AgenziaMadre)
            'Utx.Globale.Log.Trace(Utx.Globale.ProfiloEnteGestore.CodiceSede)
            'Utx.Globale.Log.Trace(Utx.Globale.UtenteCorrente.CodiceFiscale)
            'Utx.Globale.Log.Trace(Utx.Globale.UtenteCorrente.NomeUtente)
            'Utx.Globale.Log.Trace(Utx.Globale.UtenteCorrente.Ruolo)
            'Utx.Globale.Log.Trace(Utx.Globale.UtenteCorrente.DeskRuolo)
            'Utx.Globale.Log.Trace(Utx.Globale.UtenteCorrente.IsAgente)
            'Utx.Globale.Log.Trace(Utx.Globale.UtenteCorrente.UniageUser)
            'Utx.Globale.Log.Trace(Utx.Globale.UtenteCorrente.RUI)
            'Utx.Globale.Log.Trace(Utx.Globale.UtenteCorrente.DataRUI)
        Catch ex As Exception
            mErroreInit = True
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub Start()
        Try
            If Utx.Globale.SessioneCorrente.Nascosta Then
                Utx.ApplicationLog.LogUso("MENU.AvvioUT-AUTO")
#If DEBUG Then
                Dim f As New Utx.FormLog
                f.Show()
                Utx.ApplicationLog.FormVisualizzazione = f
#End If
            Else
                Utx.ApplicationLog.LogUso("MENU.AvvioUT")
            End If
            'manutenzione tardiva
            'Utx.Manutenzione.LiveChangeTardivo()
            'Utx.Agenzia.CreaStoredTardive()
            'Utx.GestioneFileFlag.DisposeFlag()
            'avvia interfaccia OM
            OM.Start()
            OM.nascondi_finestra(True)
            Dim Testo As String
            'Testo = String.Format("ora disponibile il link per acquisto di{0}Agende, Calendari e Materiale di fine anno 2020", Environment.NewLine)
            Testo = "ci siamo quasi..."
            With Splash.LabelInfo
                .Font = Utx.AppFont.Extra(14, FontStyle.Regular)
                .Padding = New Padding(30)
                .Image = Risorse.Immagini.Bitmap("smile2")
                '.Padding = New Padding(20)
                '.Image = Risorse.Immagini.Image("ads")
                .ImageAlign = ContentAlignment.BottomCenter
                .TextAlign = ContentAlignment.TopCenter
                .Text = Testo 'qui refresh
            End With
        Catch ex As Exception
            mErroreInit = True
            Utx.Globale.Log.Errore(ex)
        End Try
        Try
            'controllo attività in scadenza
            Dim tt As New Threading.Thread(AddressOf Sinistri.Globale.ControlloAttivitaInScadenza)
            tt.SetApartmentState(Threading.ApartmentState.STA)
            tt.Start()
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private mErroreInit As Boolean
    Public ReadOnly Property ErroreInit() As Boolean
        Get
            Return mErroreInit
        End Get
    End Property

#Region "gestione pagine"
    Private Sub PaginaMain(key As String, Index As Integer)
        Try
            Select Case key.ToLower
                Case "cambioagenzia"
                    If Utx.FunzioniAmbiente.EsisteForm("FormCambioAgenzia") = False Then
                        CambioAgenzia = New Utx.FormCambioAgenzia
                        CambioAgenzia.Show()
                    End If
                Case "importa"
                    Dim f As New FormImportaDati
                    f.Show()
                Case "config"
                    Dim f As New Utx.FormConfigura
                    f.Show()
                Case "connetti"
                    If Utx.Setting.Ambiente = Utx.Enumerazioni.TipoAmbiente.PP Then
                        ConnettiEmme()
                    Else
                        RaiseEvent DisconnessioneEmme()
                    End If
                Case "sincro"
                    If Utx.Setting.Ambiente = Utx.Enumerazioni.TipoAmbiente.PP2DIR Then
                        Dim f As New FormSincroDati
                        f.Show()
                    Else
                        MsgBox("E' necessario essere connessi alla rete per effettuare la sincronizzazione",
                               MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                    End If
                Case "cambiautente"
                    If MsgBox("Per completare il cambio utente è necessario riavviare il programma. Continuare?",
                       MsgBoxStyle.Question + MsgBoxStyle.YesNo, Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then
                        Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.LOGIN_RICHIESTO, Format(Today.AddDays(-1), "dd/MM/yyyy 07:00:00"))
                        'nel caso l'utente loggato in UT sia diverso da quello della macchina
                        If Utx.Globale.UtenteCorrente.UniageUser <> String.Format("{0}-[{1}]", Environment.UserName, Environment.MachineName) Then
                            Dim temp As New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.EXTRA, String.Format("{0}-[{1}]", Environment.UserName, Environment.MachineName))
                            temp.Rimuovi(Utx.GestioneFlag.TipoFlag.LOGIN_RICHIESTO)
                        End If

#If Not DEBUG Then
                        Dim SelfRun As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "SelfRun.exe")
                        If File.Exists(SelfRun) Then
                            Process.Start(SelfRun)
                        End If
#End If
                        Chiudi()
                    End If
                Case Else
                    'non fare niente
            End Select
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub PaginaUniarea(key As String, Index As Integer)
        Try
            Select Case key.ToLower
                Case "uniarea"
                    Process.Start("http://www.uniarea.it")
                Case "formazione"
                    Process.Start("https://servizi.unipolgf.it/SSOPartners/Redirector/Default.aspx?id=gau")
                Case "utwitt"
                    TimerUnitools.AvviaTwitt(True)
                Case "assistenza"
                    Utx.Servizi.AvviaAssistenza()
                Case "rss"
                    Utx.Servizi.AvviaComunicazioni(True)
                Case "help"
                    Process.Start("http://lnx.utools.it/guida_ut/")
            End Select
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub PaginaPortafoglio(key As String, Index As Integer)
        Try
            Select Case key.ToLower
                Case "anag"
                    FormSinistri_RichiestaAnagrafiche()
                Case "evidenze"
                    Dim filetocheck As String = Utx.Servizi.AvviaEvidenze()
                    Dim evidenze As New TimerEvidenze(filetocheck)
                Case "quota"
                    Utx.Servizi.AvviaQuotatore()
                Case "estrai"
                    Dim f As UniSql.frmEsplora = New UniSql.UniSql().getEsploratore()
                    Estrazione = f 'puntatore a f per acchiappare gli eventi
                    f.Show()
                Case "telefonate"
                    Dim f As New FormTelefonate
                    f.Show()
            End Select
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub PaginaQuietanzamento(key As String, Index As Integer)
        Try
            Select Case key.ToLower
                Case "monitorqt"
#If DEBUG Then
                    Dim MonitorKMS As New MonitorQT.FormMainKMS
                    MonitorKMS.Show()
#Else
                    Dim Monitor As New MonitorQT.FormMain
                    Monitor.Show()
#End If
                Case "listeqt"
                    Utx.Servizi.AvviaListeQT()
                Case "listanonqt"
                    Dim sql As New UniSql.UniSql
                    If sql.ShowGridAndGetDataTable("Polizze non quietanzate", False) Is Nothing Then
                        MsgBox("Accedere al menù Portafoglio >> Estrattore dati per consentire l'aggiornamento delle estrazioni", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                    End If
                Case "bda"
                    Dim BDA As New BDA.FormBDAMain
                    BDA.Show()
                Case "polizze_non_qt"
                    Dim sql As New UniSql.UniSql
                    If sql.ShowGridAndGetDataTable("Polizze non quietanzate", False) Is Nothing Then
                        MsgBox("Accedere al menù Portafoglio >> Estrattore dati per consentire l'aggiornamento delle estrazioni", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                    End If
            End Select
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub PaginaPostalizzazione(key As String, Index As Integer)
        Try
            Using s As New Utx.SettingAgenzia.ConfiguraSede
                s.Proxy = Utx.Globale.UniProxy.Proxy
                Dim Blocco As String = s.EsisteBloccoPostalizzazione(Utx.Globale.UtenteCorrente.UserAndPc) 'restituisce una stringa vuota o l'utente che blocca

                If Blocco.Length = 0 Then 'max durata 1 ora
                    If Utx.FunzioniAmbiente.EsisteForm("FormPostalizzazione") Then
                        FormPostalizzazione.TopMost = True
                        FormPostalizzazione.WindowState = FormWindowState.Maximized
                        FormPostalizzazione.TopMost = False
                    Else
                        If Utx.Globale.ProfiloEnteGestore.Abilitazioni.POSTALIZZAZIONE = True Then
                            Select Case key.ToLower
                                Case "attivapost"
                            'Using s As New Utx.SettingAgenzia.ConfiguraSede
                            '    s.Proxy = Utx.Globale.UniProxy.Proxy
                            '    If s.ConsensoPostalizzazione(Utx.Globale.ProfiloEnteGestore.AgenziaMadre) = True Then
                            '        FormPostalizzazione = New UniCom.FormPostalizzazione()
                            '        FormPostalizzazione.Show()
                            '    Else
                            '        Process.Start("https://comunicatore.auaonline.it")
                            '    End If
                            'End Using
                                Case "configpost"
#If DEBUG Then
                                    FormPostalizzazione = New UniCom.FormPostalizzazione With {.TipoChiamata = UniCom.FormPostalizzazione.Modalita.CONFIG}
                                    FormPostalizzazione.Show()
#Else
                                'leggo utenti abilitati
                                Dim UtentiAbilitati As New Utx.SettingItem(Utx.SettingItem.Sezioni.COMUNICATORE,
                                                                           Utx.SettingItem.Chiavi.COMUNICATORE_UTENTI,
                                                                           Utx.SettingOMW.TipoOperazione.LETTURA)

                                If Utx.Globale.UtenteCorrente.IsAgente OrElse
                                   UtentiAbilitati.ItemResult.Valore.ToUpper.Contains(Utx.Globale.UtenteCorrente.UniageUser.ToUpper) Then
                                    'se l'utente è un agente o è fra gli utenti abilitati
                                    FormPostalizzazione = New UniCom.FormPostalizzazione With {.TipoChiamata = UniCom.FormPostalizzazione.Modalita.CONFIG}
                                    FormPostalizzazione.Show()
                                Else
                                    MsgBox("Utente non abilitato a modificare la configurazione", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                                End If
#End If
                                Case "avvisipost"
                                    FormPostalizzazione = New UniCom.FormPostalizzazione With {.TipoChiamata = UniCom.FormPostalizzazione.Modalita.AVVISI}
                                    FormPostalizzazione.Show()
                                Case "tracciapost"
                                    FormPostalizzazione = New UniCom.FormPostalizzazione With {.TipoChiamata = UniCom.FormPostalizzazione.Modalita.TRACKING}
                                    FormPostalizzazione.Show()
                            End Select
                        Else
                            Process.Start("https://comunicatore.auaonline.it")
                        End If
                    End If
                Else
                    MsgBox(String.Format("E' già in corso un'attività di postalizzazione dell'utente {0}. Riprovare più tardi.",
                                             Utx.Utente.NomeUtenza(Blocco)), MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                End If
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub PaginaSinistri(key As String, Index As Integer)
        Try
            Select Case key.ToLower
                Case "schedasinistri"
                    FormAnagrafiche_RichiestaSinistri()
                Case "statistiche"
                    Dim f As New Sinistri.FormStatistiche
                    f.Show()
                Case "consap"
                    Dim f As New Consap.FormConsap
                    f.Show()
                Case "cai"
                    UniCai.Modello.StampaEtVisualizza(0, 0, 0)
                Case "baremes"
                    Dim f As New Sinistri.FormBaremes
                    f.Show()
                Case "referenti"
                    Dim f As New Referenti.FormReferenti
                    f.Show()
            End Select
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub PaginaAdempimenti(key As String, Index As Integer)
        Try
            Select Case key.ToLower
                Case "adempimenti"
                    If Utx.NetFunc.ResumeWindow(Adempimenti.FormAdempimenti.TitoloFinestra) = False Then
                        Dim f As New Adempimenti.FormAdempimenti
                        f.Show()
                    End If
                Case "buste"
                    Utx.Servizi.AvviaBuste()
            End Select
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub PaginaGestione(key As String, Index As Integer)
        Try
            Select Case key.ToLower
                Case "budget"
                    If Utx.NetFunc.ResumeWindow(Budget.FormBudget.TitoloFinestra) = False Then
                        FormBudget = New Budget.FormBudget
                        FormBudget.Show()
                    End If
                Case "np"
                    Dim f As New NuovaProduzione.frmParametri
                    f.Show()
                Case "incassi"
                    If Utx.Globale.UtenteCorrente.Profilo.ProfiloUnipol.ToUpper = "A" Then
                        Dim nt As New Threading.Thread(Sub()
                                                           Dim az As New ExportLib.Azioni
                                                           az.AggiornaIncassiConOpzioni()
                                                           az.ChiudiNotifica()
                                                       End Sub)
                        nt.Start()
                    Else
                        MsgBox("L'aggiornamento degli incassi è possibile solo agli utenti con profilo Essig A", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                        Exit Sub
                    End If
                Case "arretrati"
                    If Utx.Globale.UtenteCorrente.Profilo.ProfiloUnipol.ToUpper = "A" Then
                        Dim nt As New Threading.Thread(Sub()
                                                           Dim az As New ExportLib.Azioni
                                                           az.AggiornaArretrati()
                                                           az.ChiudiNotifica()
                                                       End Sub)
                        nt.Start()
                    Else
                        MsgBox("L'aggiornamento degli arretrati è possibile solo agli utenti con profilo Essig A", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                        Exit Sub
                    End If
                Case "unicont"
                    'link contabilità web: https://iweb.siaspa.com/iWeb/login.html?context=UNIPOL
                    'IP per l'accesso da internet alle importazioni 85.34.90.73:4300
                    Dim f As New FormUnicont
                    f.Show()
                Case "sistema"
                    Utx.Servizi.AvviaSistema()
                Case "cassa"
                    Dim f As New ChiusuraCassa.FormChiusura
                    f.Show()
            End Select
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub PaginaPatto(key As String, Index As Integer)
        Try
            Select Case key.ToLower
                Case "vademecum"
                    Utx.Servizi.AvviaVademecum()
                Case "pattorca"
                    If Utx.FunzioniAmbiente.EsisteForm("FormPattoRca") Then
                        FormPatto.TopMost = True
                        FormPatto.WindowState = FormWindowState.Maximized
                        FormPatto.TopMost = False
                    Else
                        FormPatto = New Patto.FormPattoRca
                        FormPatto.Show()
                    End If
                Case "liberi"
                    FormProdottiLiberi = New Patto.FormProdotti
                    FormProdottiLiberi.Show()
                Case "rappel"
                    Dim f As New Patto.FormRappel
                    f.Show()
            End Select
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub PaginaContatti(key As String, Index As Integer)
        Try
            Select Case key.ToLower
                Case "mail"
                    Dim f As New UniCom.FormMail
                    f.Show()
                Case "comunica"
                    Dim f As UniSql.frmEsplora = New UniSql.UniSql().getEsploratore()
                    Estrazione = f 'puntatore a f per acchiappare gli eventi
                    f.Show()
                Case "inviasmslista"
                    Dim f As New UniCom.FormRichiestaFile
                    f.Show()
                Case "account"
                    Dim tt As New Threading.Thread(Sub()
                                                       Dim f As New UniCom.FormGestioneAccount
                                                       f.ShowDialog()
                                                   End Sub)
                    tt.SetApartmentState(Threading.ApartmentState.STA)
                    tt.Start()
                Case "notifiche"
                    Dim f As New UniCom.FormNotifiche
                    f.Show()
                Case "lettere"
                    'If Utx.Tester.Lettere(Utx.Globale.AgenziaRichiesta.CodiceAgenzia) Then
                    Dim tt As New Threading.Thread(Sub()
                                                       Dim f As New UniSql.frmGrid
                                                       f.UsoStampa = True
                                                       f.ShowDialog()
                                                   End Sub)
                    tt.SetApartmentState(Threading.ApartmentState.STA)
                    tt.Start()
                    'End If
                Case "wapp"
                    'Dim f As New UniCom.FormWhatsApp
                    'f.Show()
            End Select
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub PaginaUtilita(key As String, Index As Integer)
        Try
            Select Case key.ToLower
                Case "assegni"
                    Utx.Servizi.AvviaGestioneAssegni()
                Case "visure"
                    Dim f As New Visure.FormVisure With {.Targa = "", .ClasseVeicolo = ""}
                    f.Show()
                Case "scanner"
                    Dim f As New UnitoolsDocumenti.Fotocopia
                    f.Show()
                Case "centralino"
                    AvviaCentralino(True)
                Case "infout"
                    Dim f As New InfoUt.FormInfo
                    f.Show()
                Case "link"
                    Utx.Servizi.LinkUtili()
                Case "doc_personali"
                    Dim f As UnitoolsDocumenti.FormDocumenti = Utx.OggettoForm.Esiste(Utx.OggettoForm.TipoForm.DOCUMENTI)
                    If f Is Nothing Then
                        f = New UnitoolsDocumenti.FormDocumenti
                        f.CodiceFiscale = "Documenti personali"
                        f.NomeCliente = "Documenti dell'agenzia"
                        f.CartellaAllegati = ""
                        f.Show()
                    Else
                        f.Reset()
                        f.CodiceFiscale = "Documenti personali"
                        f.NomeCliente = "Documenti dell'agenzia"
                        f.CartellaAllegati = ""
                        Utx.OggettoForm.Show(Utx.OggettoForm.TipoForm.DOCUMENTI)
                    End If
                Case "doc_agenzia"
                    Dim f As UnitoolsDocumenti.FormDocumenti = Utx.OggettoForm.Esiste(Utx.OggettoForm.TipoForm.DOCUMENTI)
                    If f Is Nothing Then
                        f = New UnitoolsDocumenti.FormDocumenti
                        f.CodiceFiscale = "DossierAgenzia"
                        f.NomeCliente = "Dossier d'agenzia"
                        f.CartellaAllegati = ""
                        f.Show()
                    Else
                        f.Reset()
                        f.CodiceFiscale = "DossierAgenzia"
                        f.NomeCliente = "Dossier d'agenzia"
                        f.CartellaAllegati = ""
                        Utx.OggettoForm.Show(Utx.OggettoForm.TipoForm.DOCUMENTI)
                    End If
            End Select
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub PaginaManutenzione(key As String, Index As Integer)
        Try
            Select Case key.ToLower
                Case "aremota"
                    Dim ARemota As String = Path.Combine(Utx.Globale.Paths.CartellaModelli, "auasupport-qs.exe")
                    If File.Exists(ARemota) Then
                        AvviaFormAttesa("Avvio assistenza remota...")
                        NotificaAttesa.NascondiAsync(5)
                        Process.Start(ARemota)
                    Else
                        Process.Start("http://www.utools.it")
                    End If
                Case "strumenti"
                    If Utx.NetFunc.ResumeWindow(FormManutenzione.TitoloFinestra) = False Then
                        Dim f As New FormManutenzione
                        f.Show()
                    End If
                Case "vedilog"
                    If Utx.NetFunc.ResumeWindow("Visualizzazione log") = False Then
                        Dim f As New Utx.FormLog
                        f.Show()
                        Utx.ApplicationLog.FormVisualizzazione = f
                    End If
                Case "testpn"
                    Try
                        Dim f As New Utx.FormDebug
                        Using c As New OleDb.OleDbConnection(Utx.ConnessioniDb.ConnectionString(Utx.ConnessioniDb.Db.DBUNO))
                            c.Open()

                            Using cmd As New OleDb.OleDbCommand
                                cmd.Connection = c
                                cmd.CommandType = CommandType.Text
                                cmd.CommandText = "SELECT * FROM MovimentiPrimaNota"

                                Dim dt As New DataTable
                                Using da As New OleDb.OleDbDataAdapter(cmd)
                                    da.Fill(dt)
                                End Using
                                f.OrigineDati = dt
                            End Using
                        End Using
                        f.Show()
                    Catch ex As Exception
                        Utx.Globale.Log.Errore(ex)
                    End Try
                Case "testdebug"
#If DEBUG Then
                    Select Case 3
                        Case 1
                            'Dim f As New Migra.FormMigrazione
                            'f.Show()
                        Case 2
                            Dim az As New ExportLib.Azioni
                            az.AnalisiOrariIncassi(Utx.Globale.AgenziaRichiesta.CodiceAgenzia, #7/4/2018#)
                        Case 3
                    End Select
#End If
            End Select
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub
#End Region

    Public Sub Chiudi()
        Try
            Utx.Globale.Log.Info("CHIUSURA APP")

            If OperazioniInCorso() = True Then
                Utx.Globale.SessioneCorrente.RichiestaChiusura = True

                Utx.Globale.Log.Info("sessione bloccata")
                If NotificaChiusura Is Nothing Then
                    Utx.Globale.Log.Info("visualizzo notifica")
                    NotificaChiusura = New Utx.FormNotifica
                    With NotificaChiusura
                        .Stile = Utx.FormNotifica.Style.OMNIA_MANAGER_2
                        .Opacity = 1
                        .Altezza = Utx.FormNotifica.AltezzaNotifica.NORMALE
                        .Messaggio = ""
                        .Show()
                        .Messaggio = String.Format("Elaborazioni in corso{0}{0}attendere la chiusura...", Environment.NewLine)
                    End With
                    Console.Beep(600, 500)
                    Utx.Globale.Log.Info("avvio timer chiusura")
                    TimerChiusura = New Timer With {.Interval = 2000, .Enabled = True}
                End If
            Else
                Utx.Globale.SessioneCorrente.RichiestaChiusura = False

                Utx.OggettoForm.DisposeAll()
                If NotificaChiusura IsNot Nothing Then
                    NotificaChiusura.ChiusuraImmediata()
                End If
                Dim tt As New Threading.Thread(AddressOf UscitaApp)
                tt.SetApartmentState(Threading.ApartmentState.STA)
                tt.Start()
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Function OperazioniInCorso() As Boolean
        Try
            If Utx.Globale.SessioneCorrente.Bloccata = True Then
                Return True
            End If
            If UtTimer.bw IsNot Nothing Then
                If UtTimer.bw.IsBusy Then
                    Return True
                End If
            End If
            Return False
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    'Private Sub IconaNotifica_Click(sender As Object, e As EventArgs) Handles IconaNotifica.Click
    '    IconaNotifica.Dispose()
    'End Sub

    Private Sub FormSinistri_RichiestaAnagrafiche() Handles FormSinistri.RichiestaAnagrafiche
        Try
            If Utx.OggettoForm.Show(Utx.OggettoForm.TipoForm.ANAG) = False Then
                FormAnagrafiche = New Anag.FormAnagrafiche
                FormAnagrafiche.Show()
            End If
            Application.DoEvents()

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub FormSinistri_RichiestaCliente(CodiceFiscale As String) Handles FormSinistri.RichiestaCliente
        FormSinistri_RichiestaAnagrafiche()
        FormAnagrafiche.SelezionaClientePerCodiceFiscale(CodiceFiscale)
    End Sub

    Private Sub FormAnagrafiche_RichiestaSinistri() Handles FormAnagrafiche.RichiestaSinistri
        Try
            If Utx.OggettoForm.Show(Utx.OggettoForm.TipoForm.SINISTRI) = False Then
                FormSinistri = New Sinistri.FormSinistri
                FormSinistri.Show()
            End If
            Application.DoEvents()

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub FormAnagrafiche_RichiestaSinistriCliente(CodiceFiscale As String) Handles FormAnagrafiche.RichiestaSinistriCliente
        Try
            If Utx.OggettoForm.Show(Utx.OggettoForm.TipoForm.SINISTRI) = False Then
                FormSinistri = New Sinistri.FormSinistri
                FormSinistri.Show()
            End If
            Application.DoEvents()

            FormSinistri.SinistriCliente(CodiceFiscale)

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub FormPatto_RichiestaNumeroSinistro(AgenziaSinistro As Integer,
                                                  EsercizioSinistro As Integer,
                                                  NumeroSinistro As Long) Handles FormPatto.RichiestaNumeroSinistro
        Try
            If Utx.OggettoForm.Show(Utx.OggettoForm.TipoForm.SINISTRI) = False Then
                FormSinistri = New Sinistri.FormSinistri
                FormSinistri.Show()
            End If
            Application.DoEvents()

            FormSinistri.SelezionaSinistro(1, AgenziaSinistro, EsercizioSinistro, NumeroSinistro)

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ConnettiEmme()
        Try
            'connetti al server di magia
            Dim Notifica As New Utx.FormNotifica
            With Notifica
                .ColoreSfondo = Color.Gold
                .Opacity = 0.8
                .Text = ""
                .Show()
                .Messaggio = String.Format("Connessione ad {0}...", Utx.Globale.Paths.UnitaDatiRete)
            End With

            Utx.Globale.Log.Info(String.Format("Unità di rete: {0}", Utx.Globale.Paths.UnitaDatiRete))

            If New DriveInfo(Utx.Globale.Paths.UnitaDatiRete).IsReady Then
                Utx.Globale.Log.Info("Unità di rete pronta")
                Utx.Globale.Log.Info("Genero evento di connessione")
                RaiseEvent ConnessioneEmme()
            Else
                If NetUse() = True Then
                    Utx.Globale.Log.Info("Unità di rete pronta")
                    RaiseEvent ConnessioneEmme()
                Else
                    Utx.Globale.Log.Info("Unità di rete NON pronta")
                    Notifica.Messaggio = "Connessione non riuscita"
                End If
            End If

            Notifica.Chiudi()

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Function NetUse() As Boolean
        Try
            Dim IP As String = Utx.Globale.SettingGlobale.LeggiValore(Utx.GestioneFlag.TipoFlag.IP_SERVER, "")

            'se IP non impostato in configura
            If String.IsNullOrEmpty(IP) Then
                MsgBox("Impostare prima il Nome/Ip dell'unità che ospita i dati", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Return False
            End If

            'Cursor = Cursors.WaitCursor

            Utx.Globale.Log.Info(String.Format("NET USE {0}: \\{1}\Direzione /user:{2}\{3} *** /persistent:yes",
                                               Utx.Globale.Paths.UnitaDatiRete, IP, Utx.Globale.UtenteCorrente.Dominio, Utx.Globale.UtenteCorrente.UniageUser))

            Dim ComandoNetUse As String = String.Format("NET USE {0}: \\{1}\Direzione /user:{2}\{3} {4} /persistent:yes",
                                                        Utx.Globale.Paths.UnitaDatiRete,
                                                        IP,
                                                        Utx.Globale.UtenteCorrente.Dominio,
                                                        Utx.Globale.UtenteCorrente.UniageUser,
                                                        Utx.Globale.UtenteCorrente.UniagePw)

            Shell(ComandoNetUse, AppWinStyle.Hide, True, 15000)
            Return New DriveInfo(Utx.Globale.Paths.UnitaDatiRete).IsReady

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return False
        Finally
            'Cursor = Cursors.Default
        End Try
    End Function

    Private Sub FormMain_ConnessioneEmme() Handles Me.ConnessioneEmme
        Utx.Setting.Ambiente = Utx.Enumerazioni.TipoAmbiente.PP2DIR
        Utx.Globale.Paths.UnitaDati = New DriveInfo(Utx.Globale.Paths.UnitaDatiRete)
        DeskMainBanner()
    End Sub

    Private Sub FormMain_DisconnessioneEmme() Handles Me.DisconnessioneEmme
        Utx.Setting.Ambiente = Utx.Enumerazioni.TipoAmbiente.PP
        Utx.Globale.Paths.UnitaDati = New DriveInfo(Utx.Globale.Paths.UnitaDatiLocale)
        DeskMainBanner()
    End Sub

    Public Function DeskMainBanner() As String
        Try
            Return String.Format("{0} {1} - Utente: {2} - Disco {3}",
                                 Utx.Globale.TitoloApp,
                                 InfoUt.InfoApp.VersioneApp,
                                 Utx.Globale.UtenteCorrente.UniageUser,
                                 Utx.Globale.Paths.NomeUnitaDati.Substring(0, 1))
        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
            Return "Errore"
        End Try
    End Function

    Private Sub MonitorCentralino_RichiestaAnagrafica(CodiceFiscale As String) Handles MonitorCentralino.RichiestaAnagrafica
        FormSinistri_RichiestaCliente(CodiceFiscale)
    End Sub

    Private Sub MonitorCentralino_RichiestaSinistri(CodiceFiscale As String) Handles MonitorCentralino.RichiestaSinistri
        FormAnagrafiche_RichiestaSinistriCliente(CodiceFiscale)
    End Sub

    Public Sub AvviaCentralino(Optional AvvioManuale As Boolean = False)
        Try
            If Utx.NetFunc.ResumeWindow("Monitor centralino") = False Then
                'se la chiave centralino non esiste inizializzo
                If Utx.Globale.SettingUtente.EsisteChiave(Utx.GestioneFlag.TipoFlag.CENTRALINO_AUTOSTART) = False Then
                    Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.CENTRALINO_AUTOSTART, "False", False)
                    Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.CENTRALINO_SECONDI, "20", False)
                    Utx.Globale.SettingGlobale.AggiungiModifica(Utx.GestioneFlag.TipoFlag.CENTRALINO_CARTELLA, "M:\Unitools\Temp\Centralino", False)
                    Utx.Globale.SettingGlobale.AggiungiModifica(Utx.GestioneFlag.TipoFlag.CENTRALINO_PATTERN, "3cx")
                End If

                If AvvioManuale OrElse Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.CENTRALINO_AUTOSTART, "False") = True Then
                    If Utx.FunzioniAmbiente.EsisteForm("FormAvvioCentralino") Then
                        MonitorCentralino.WindowState = FormWindowState.Normal
                    Else
                        MonitorCentralino = New Centralino.FormAvvioCentralino
                        MonitorCentralino.Show()
                    End If
                End If
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub TimerChiusura_Tick(sender As Object, e As EventArgs) Handles TimerChiusura.Tick
        If OperazioniInCorso() = False Then
            Chiudi()
        End If
    End Sub

    Private Sub FormProdottiLiberi_RichiestaCliente(CodiceFiscale As String) Handles FormProdottiLiberi.RichiestaCliente
        FormSinistri_RichiestaCliente(CodiceFiscale)
    End Sub

    Private Sub FormPostalizzazione_RichiestaArretrati(Agenzia As UniCom.AgenziaConfigPostalizzazione, InizioPeriodo As Date, FinePeriodo As Date) Handles FormPostalizzazione.RichiestaArretrati
        Dim az As New ExportLib.Azioni
        az.AggiornaPostalizzazione(Agenzia, InizioPeriodo, FinePeriodo)
        az.ChiudiNotifica()
    End Sub

    Private Function DeskMainMenu() As String
        Return String.Format("{0}-{1}", Utx.FunzioniAmbiente.AgenziaSedePc, Microsoft.VisualBasic.Right(Utx.Globale.UtenteCorrente.UniageUser, 2).ToUpper)
    End Function

    Private Sub GestioneMenuPostalizzazione(Optional ForzaLetturaServer As Boolean = False)
        If ForzaLetturaServer = True Then
            If Utx.Globale.ProfiloEnteGestore.Abilitazioni.POSTALIZZAZIONE = False Then
                'forzo la rilettura delle abilitazioni
                'Cursor = Cursors.WaitCursor
                Utx.Globale.ProfiloEnteGestore.Abilitazioni.LeggiAbilitazioni()
                'Cursor = Cursors.Default
            End If
        End If
        'imposto i bottoni
        'With UniMenu.Pagina("postalizzazione")
        '    With .BottoneMenu("attivapost")
        '        .Enabled = (Utx.Globale.ProfiloEnteGestore.Abilitazioni.POSTALIZZAZIONE = False)
        '        .Testo = IIf(Utx.Globale.ProfiloEnteGestore.Abilitazioni.POSTALIZZAZIONE = True, "Servizio attivo", "Attiva{0}il servizio")
        '    End With
        '    .BottoneMenu("configpost").Enabled = (Utx.Globale.ProfiloEnteGestore.Abilitazioni.POSTALIZZAZIONE = True)
        '    .BottoneMenu("avvisipost").Enabled = (Utx.Globale.ProfiloEnteGestore.Abilitazioni.POSTALIZZAZIONE = True)
        '    .BottoneMenu("tracciapost").Enabled = (Utx.Globale.ProfiloEnteGestore.Abilitazioni.POSTALIZZAZIONE = True)
        'End With
    End Sub

    Private Sub FormPostalizzazione_ServizioAttivato() Handles FormPostalizzazione.ServizioAttivato
        GestioneMenuPostalizzazione()
    End Sub

    Private Sub FormBudget_RichiestaAnagrafica(CodiceFiscale As String) Handles FormBudget.RichiestaAnagrafica
        Try
            If Utx.OggettoForm.Show(Utx.OggettoForm.TipoForm.ANAG) = False Then
                FormAnagrafiche = New Anag.FormAnagrafiche
                FormAnagrafiche.Show()
            End If
            Application.DoEvents()

            FormAnagrafiche.SelezionaClientePerCodiceFiscale(CodiceFiscale)

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub OM_chiudiSplash(sender As Object, e As OmniaHtml.EventoUniTools) Handles OM.chiudiSplash
        Avvio.Splash.Close()
        If Utx.Globale.SessioneCorrente.Nascosta = False Then
            OM.nascondi_finestra(False)
        Else
            OM.nascondi_finestra(True)
            MsgTimer = New Timer With {.Interval = 1000, .Enabled = True}
        End If

        'migrazione note disabilitata il 24/10/2023
        'Utx.Migrazione.MigraNote()

#If DEBUG Then
        'Finestra Log per debug
        If 0 = 1 Then
            OM_lancio(Me, New OmniaHtml.EventoUniTools With {.Parametro = "vedilog", .SchedeAperte = 0})
        End If
#End If
        'avvio le temporizzazioni
        UtTimer = New TimerUnitools
    End Sub

    Private Sub OM_chiusura(sender As Object, e As OmniaHtml.EventoUniTools) Handles OM.chiusura
#If Not DEBUG Then
        If (e.SchedeAperte > 1) OrElse (Utx.OggettoForm.FinestreVisibili > 0) Then
            If MsgBox("Attenzione: sono aperte più schede e/o finestre. Confermate la chiusura di Omnia manager?",
                      MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Utx.Globale.TitoloApp) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
#End If
        If DateDiff(DateInterval.Minute, Utx.Globale.SessioneCorrente.LetturaArretrati, Now) < 2 Then
            'per gestire la chiusura errata dopo l'aggiornamento arretrati
            Utx.Globale.SessioneCorrente.LetturaArretrati = Now.AddDays(-1)
            Exit Sub
        End If
        Chiudi()
    End Sub

    Private Sub OM_lancio(sender As Object, e As OmniaHtml.EventoUniTools) Handles OM.lancio
        Utx.ApplicationLog.LogUso("MENU." + e.Parametro.ToLower)
        Select Case e.Parametro
            Case "AVVIATO" 'non fare niente c'è l'evento chiudiSplash
            Case "SCHEDASINISTRI", "STATISTICHE", "CAI", "BAREMES", "REFERENTI", "CONSAP" : PaginaSinistri(e.Parametro, 0)
            Case "ANAG", "EVIDENZE", "QUOTA", "ESTRAI", "TELEFONATE" : PaginaPortafoglio(e.Parametro, 0)
            Case "MONITORQT", "LISTEQT", "BDA", "POLIZZE_NON_QT" : PaginaQuietanzamento(e.Parametro, 0)
            Case "ATTIVAPOST", "CONFIGPOST", "AVVISIPOST", "TRACCIAPOST" : PaginaPostalizzazione(e.Parametro, 0)
            Case "ADEMPIMENTI", "BUSTE" : PaginaAdempimenti(e.Parametro, 0)
            Case "BUDGET", "NP", "INCASSI", "ARRETRATI", "UNICONT", "SISTEMA", "CASSA" : PaginaGestione(e.Parametro, 0)
            Case "PATTORCA", "LIBERI", "RAPPEL" : PaginaPatto(e.Parametro, 0)
            Case "MAIL", "INVIASMSLISTA", "COMUNICA", "ACCOUNT", "NOTIFICHE", "LETTERE" : PaginaContatti(e.Parametro, 0)
            Case "ASSEGNI", "VISURE", "SCANNER", "CENTRALINO", "INFOUT", "LINK", "DOC_PERSONALI", "DOC_AGENZIA", "CENTRALINO" : PaginaUtilita(e.Parametro, 0)
            Case "IMPORTA", "CONFIG", "CAMBIOAGENZIA", "CAMBIAUTENTE" : PaginaMain(e.Parametro, 0)
            Case "STRUMENTI", "VEDILOG", "AREMOTA", "TESTPN" : PaginaManutenzione(e.Parametro, 0)
            Case "OW_ACCESSO" : RichiestaCredenzialiOWeb8()
            Case "OW_ACCESSO_ERROR"
                MsgBox("Le credenziali inserite sono errate", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                RichiestaCredenzialiOWeb8()
            Case "UTWITT" : PaginaUniarea(e.Parametro, 0)
            Case "TESTDEBUG"
                Dim f As New Utx.FormDebug
                f.Show()
            Case "MIGRA_DATI" : MigrazioneSIA()
            Case "INDICE_DOC"
                'esportazione documenti con notifica incorporata
                Dim tt As New Threading.Thread(Sub()
                                                   Dim EsportaDoc As New Ut40.EsportaDocumenti
                                                   EsportaDoc.Esporta2FTP()
                                               End Sub)
                tt.Start()
            Case "MIGRA_DOC"
                'Dim Cartella As String = Ut40.SIA40.FTPUpload.SelezionaCartellaDocumenti
                'If Directory.Exists(Cartella) Then
                '    Dim tt As New Threading.Thread(Sub()
                '                                       Dim Sia As New Ut40.SIA40.FTPUpload
                '                                       Sia.SincronizzaCartelle(Utx.Globale.ProfiloEnteGestore.AgenziaMadre, Cartella)
                '                                   End Sub)
                '    tt.Priority = Threading.ThreadPriority.BelowNormal
                '    tt.Start()
                'End If
            Case "DOC_DUPLICATI"
                Dim tt As New Threading.Thread(Sub()
                                                   Utx.AnalisiDb.CancellaDocumentiDuplicati()
                                               End Sub)
                tt.Start()
            Case "INVIA_MFEE"
                Dim tt As New Threading.Thread(AddressOf Utx.SIA.InviaManagementFee)
                tt.Start()
            Case "RESET_PW_OW"
                OM.setOW("", "")
                Utx.FormLoginOWeb.SalvaPasswordOW("", "")
                MsgBox("Utente e password di OmniaManager resettati.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            Case "RESET_PW_UNI"
                Process.Start("https://changepwd.unipol.it/")
            Case Else
                Utx.Globale.Log.Info("{0}: chiave menù non ancora attivata", {e.Parametro})
        End Select
    End Sub

    Private Function UrlSia() As String
        Return "https://oweb.siaspa.com/oweb20-mainweb/Login.xhtml"
    End Function

    Private Sub UscitaApp()
        Try
            'blocco il timer di chiusura
            If TimerChiusura IsNot Nothing Then
                TimerChiusura.Dispose()
            End If
            Utx.Globale.Log.Info("chiudo centralino")
            If Utx.FunzioniAmbiente.EsisteForm("FormAvvioCentralino") Then MonitorCentralino.Close()
            If UtTimer IsNot Nothing Then
                Utx.Globale.Log.Info("chiudo timer unitools")
                UtTimer.Close()
                UtTimer = Nothing
            End If
            Utx.Globale.Log.Info("chiudo interfaccia OM")
            OM.chiudi()
            Threading.Thread.Sleep(1500)
            Utx.Globale.Log.Info("application exit thread")
            Application.ExitThread()
            Utx.Globale.Log.Info("application exit")
            Application.Exit()
        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
#If DEBUG Then
            Console.Beep(600, 600)
            Utx.Globale.Log.Errore(ex)
#End If
        End Try
    End Sub

    Private Sub CambioAgenzia_CambioCodice(Codice As String) Handles CambioAgenzia.CambioCodice
        Try
            If Codice IsNot Nothing Then
                'cambio l'agenzia richiesta
                Utx.Globale.AgenziaRichiesta.CodiceAgenzia = Codice
                'cambio intestazione pagina
                OM.SetLabelAgenzia(Codice, InfoAgenzia)

                'sinistri 
                FormSinistri = Utx.OggettoForm.Esiste(Utx.OggettoForm.TipoForm.SINISTRI)
                If FormSinistri IsNot Nothing Then
                    FormSinistri.AggiornaBottoneCodice()
                    FormSinistri.AggiornaQuery()
                End If
                'anag
                FormAnagrafiche = Utx.OggettoForm.Esiste(Utx.OggettoForm.TipoForm.ANAG)
                If FormAnagrafiche IsNot Nothing Then
                    FormAnagrafiche.AggiornaBottoneCodice()
                    FormAnagrafiche.AggiornaQuery()
                End If
                If Estrazione IsNot Nothing Then
                    Estrazione.AggiornaBottoneCodice()
                    UniSql.ParametriBase.LeggiParametriBase()
                End If
                'chiudo doc
                Utx.OggettoForm.Dispose(Utx.OggettoForm.TipoForm.DOCUMENTI)
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub OM_messaggio(sender As Object, e As OmniaHtml.EventoMessaggio) Handles OM.messaggio
        Try
            If e.avvio = True Then
                AvviaFormAttesa()
            ElseIf e.avvio = False Then
                If NotificaAttesa IsNot Nothing Then NotificaAttesa.Hide()
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub AvviaFormAttesa(Optional Messaggio As String = "Attendere...")
        Try
            If NotificaAttesa Is Nothing Then
                NotificaAttesa = New Utx.FormNotifica
            End If
            With NotificaAttesa
                .Stile = Utx.FormNotifica.Style.BIANCO_GRIGIO
                .StartPosition = FormStartPosition.CenterScreen
                With .LabelMessaggio
                    .Padding = New Padding(60, 0, 60, 0)
                    .TextAlign = ContentAlignment.MiddleRight
                    .Image = Risorse.Immagini.Bitmap("clock")
                    .ImageAlign = ContentAlignment.MiddleLeft
                End With
                .Show()
                .Messaggio = Messaggio
            End With
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Function InfoAgenzia() As String
        Return String.Format("{0}-{1}-{2}", Utx.Globale.AgenziaRichiesta.CodiceAgenzia, Utx.Globale.ProfiloEnteGestore.CodiceSede, Utx.Globale.UtenteCorrente.UniageUser)
    End Function

    Private Function MenuExtra() As DataTable
        Try
            Dim Menu As DataTable = Utx.EnteGestore.MenuExtra(Utx.Globale.ProfiloEnteGestore.AgenziaMadre,
                                                              Utx.Globale.ProfiloEnteGestore.CodiceSede,
                                                              Utx.Globale.UtenteCorrente.UniageUser)
#If DEBUG Then
            Menu.Rows.Add({"TUTTE", "TUTTE", "TUTTI", "BDA", "Gestione BDA", "U", "0", "quitenzamento-menu"})
            Menu.Rows.Add({"TUTTE", "TUTTE", "TUTTI", "CASSA", "Gestione cassa", "U", "0", "gestione-menu"})
            Menu.Rows.Add({"TUTTE", "TUTTE", "TUTTI", "TESTDEBUG", "Form debug", "U", "0", "personale-menu"})
            Menu.Rows.Add({"TUTTE", "TUTTE", "TUTTI", "INDICE_DOC", "Invio documenti", "U", "0", "personale-menu"})
#End If
            Return Menu
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

    Private Sub MigrazioneSIA()
        Dim nt As New Threading.Thread(Sub()
                                           Dim BloccoMigrazione As Utx.Sessione.Blocco
                                           BloccoMigrazione = Utx.Globale.SessioneCorrente.AggiungiBlocco(Utx.Sessione.TipoBlocco.MIGRAZIONE_DATI, "Migrazione dati")

                                           Notifica = New Utx.FormNotifica
                                           With Notifica
                                               .Stile = Utx.FormNotifica.Style.ANTRACITE
                                               .Show()
                                               .Messaggio = "Migrazione dati..."
                                           End With

                                           Esporta = New UniFeed.Esporta
                                           Esporta.EsportaTutto()
                                           Esporta = Nothing
                                           Notifica.Chiudi(3)
                                           Utx.Globale.SessioneCorrente.RimuoviBlocco(BloccoMigrazione)

                                           UtTimer.InvioDatiMigrazione()
                                       End Sub) With {.Priority = Threading.ThreadPriority.BelowNormal}
        nt.Start()
    End Sub

    Private Sub Esporta_CompattazioneFile(Agenzia As String, Archivio As String) Handles Esporta.CompattazioneFile
        Dim Messaggio As String = String.Format("{0}: compattazione archivio {1}...", Agenzia, Archivio)
        Notifica.Messaggio = Messaggio
        Utx.Globale.Log.Info(Messaggio)
        Application.DoEvents()
    End Sub

    Private Sub Esporta_EsportazioneCompletata(Archivio As String, Errore As Boolean) Handles Esporta.EsportazioneCompletata
        Dim Messaggio As String
        If Errore = False Then
            Messaggio = String.Format("Esportazione {0} completata", Archivio)
        Else
            Messaggio = String.Format("Errore in esportazione {0}", Archivio)
        End If
        Utx.Globale.Log.Info(Messaggio)
        Application.DoEvents()
    End Sub

    Private Sub Esporta_Stato(Agenzia As String, Archivio As String, RecordEsportati As Integer, RecordTotali As Integer) Handles Esporta.Stato
        If RecordTotali = 0 Then
            Notifica.Messaggio = String.Format("{0}: esportazione {1} {2}", Agenzia, Archivio, RecordEsportati)
        Else
            Notifica.Messaggio = String.Format("{0}: esportazione {1} {2:##0%}", Agenzia, Archivio, RecordEsportati / RecordTotali)
        End If
        Application.DoEvents()
    End Sub

    Private Sub Esporta_Messaggio(Messaggio As String) Handles Esporta.Messaggio
        Notifica.Messaggio = Messaggio
        Application.DoEvents()
    End Sub

    Private Sub RichiestaCredenzialiOWeb8()
        Dim tt As New Threading.Thread(Sub()
                                           Dim f As New Utx.FormLoginOWeb
                                           f.ShowDialog()
                                           If f.DialogResult = DialogResult.OK Then
                                               OM.setOW(f.UserOW.ToUpper, f.PwOW)
                                               MsgBox("Cliccare nuovamente sul pulsante Omnia manager per accedere a OM web", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                                           Else
                                               OM.setOW("", "")
                                           End If
                                       End Sub)
        tt.Start()
    End Sub

    Private Sub UtxEventi_ApriStrumenti() Handles UtxEventi.ApriStrumenti
        PaginaManutenzione("strumenti", 0)
    End Sub

    Private Sub FormAnagrafiche_RichiestaCambioAgenzia() Handles FormAnagrafiche.RichiestaCambioAgenzia, Estrazione.RichiestaCambioAgenzia
        PaginaMain("cambioagenzia", 0)
    End Sub

    Private Sub FormSinistri_RichiestaCambioAgenzia(Codice As String) Handles FormSinistri.RichiestaCambioAgenzia
        If String.IsNullOrEmpty(Codice) Then
            PaginaMain("cambioagenzia", 0)
        Else
            If Utx.Globale.AgenziaRichiesta.CodiceAgenzia <> Codice Then
                CambioAgenzia_CambioCodice(Codice)
            End If
        End If
    End Sub

    Private Sub Estrazione_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Estrazione.FormClosed
        Estrazione = Nothing
    End Sub

    Private Sub MsgTimer_Tick(sender As Object, e As EventArgs) Handles MsgTimer.Tick
        Try
            Dim Tag As String = Clipboard.GetText
            If Tag = "TAGUT:RESUME" Then
                MsgTimer.Dispose()
                Clipboard.Clear()
                Utx.Globale.SessioneCorrente.Nascosta = False
                UtTimer.IntervalloTimer = TimerUnitools.IntervalloStandardTimer
                OM.nascondi_finestra(False)

                For Each n As Utx.FormNotifica In Utx.FormNotifica.ListaNotifiche
                    n.Altezza = n.y
                Next
            End If
        Catch ex As Exception
            'in alcuni casi, durante l'avvio del pc e quindi in AUTO, può andare in errore la clipboard
            Utx.Globale.Log.Info(ex)
        End Try
    End Sub
End Class
