Imports UMenu
Imports System.IO

Public Class FormMain

    Public Event ConnessioneEmme()
    Public Event DisconnessioneEmme()

    Public Shared TitoloFinestra As String = Utx.Globale.TitoloApp

    Public WithEvents UniMenu As PagesMenu
    Private WithEvents IconaNotifica As NotifyIcon
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
    Private WithEvents UtxEventi As New Utx.Eventi
    Private WithEvents MsgTimer As Timer
    Private Const LarghezzaMenu As Integer = 170

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        With Me
            .Text = TitoloFinestra
            .Icon = My.Resources.unitools
            .Font = New Font("Microsoft Sans Serif", 9)
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            .ControlBox = False
            .ShowInTaskbar = True
            .Size = New Size(LarghezzaMenu, Screen.PrimaryScreen.WorkingArea.Height)
            'posizione e dimensione del menù
            .StartPosition = FormStartPosition.Manual
            .Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - LarghezzaMenu, 0)
        End With

        ImpostaMenu()
    End Sub

    Public ReadOnly Property Pagina(Key As String) As UMenu.Page
        Get
            Return UniMenu.Pagina(Key)
        End Get
    End Property

    Public Sub ForzaChiusura()
        Me.Close()
    End Sub

    Private Sub ImpostaMenu()
        Select Case Utx.Globale.ProfiloEnteGestore.ProfiloApp
            Case Utx.Enumerazioni.ProfiloApp.COMPLETO
                MenuCompleto()
            Case Utx.Enumerazioni.ProfiloApp.SINISTRI
                MenuSinistri()
            Case Utx.Enumerazioni.ProfiloApp.POSTALIZZAZIONE
                MenuPostalizzazione()
            Case Utx.Enumerazioni.ProfiloApp.SINISTRI_POSTALIZZAZIONE
                MenuSinistriPostalizzazione()
        End Select
    End Sub

    Private Sub MenuCompleto()
        PagesMenu.TrackColor = Color.DodgerBlue
        PagesMenu.ButtonPageHeight = 27

        UniMenu = New PagesMenu(True)

        With UniMenu
            .Dock = DockStyle.Fill

            'altezza di default dei bottoni di pagina
            .ButtonStyle = PageButton.Style.FLAT
            .ButtonBackColor = Color.Gainsboro

            'label info
            If .ViewInfoLabel = True Then
                .InfoLabel.Margin = New Padding(0)
                .InfoLabel.Font = Utx.AppFont.Normal
                .InfoLabel.Text = ""
            End If
        End With

        Page.ButtonMenuHeight = 50
        Page.ButtonMenuBackColor = Color.White
        Page.ButtonMenuStyle = MenuButton.Style.FLAT
        Page.ButtonPageStyle = PageButton.Style.FLAT

        'main
        With UniMenu.AddPage(DeskMainMenu, "main")
            If Utx.EnteGestore.CodiciGestiti.Count > 1 Then
                .AddButtonMenu("Cambia agenzia", "cambioagenzia", Risorse.Immagini.Bitmap("cambiaagenzia"))
            End If
            .AddButtonMenu("Importa dati", "importa", Risorse.Immagini.Bitmap("importa"))
            .AddButtonMenu("Configura", "config", Risorse.Immagini.Bitmap("config"))
            'per i PP
            If Utx.FunzioniRete.PcInDominio = False Then
                .AddButtonMenu("Sincronizza dati", "sincro", Risorse.Immagini.Bitmap("sincro"))
                .AddButtonMenu("Connetti M:", "connetti", Risorse.Immagini.Bitmap("connetti"))
            End If
            .AddButtonMenu("Cambia utente{0}e/o password", "cambiautente", Risorse.Immagini.Bitmap("user"))
            AddHandler .MenuButtonClick, AddressOf PaginaMain
        End With
        'pagina uniarea
        With UniMenu.AddPage("Uniarea", "uniarea")
            .AddButtonMenu("Uniarea", "uniarea", Risorse.Immagini.Bitmap("uniarea"))
            If Utx.Globale.ProfiloEnteGestore.ProfiloApp = Utx.Enumerazioni.ProfiloApp.COMPLETO Then
                .AddButtonMenu("Formazione", "formazione", Risorse.Immagini.Bitmap("formazione"))
            End If
            .AddButtonMenu("Comunicazioni", "rss", Risorse.Immagini.Bitmap("rss"))
            .AddButtonMenu("uTwitt", "utwitt", Risorse.Immagini.Bitmap("utwitt"))
            .AddButtonMenu("Guida", "help", Risorse.Immagini.Bitmap("help"))
            .AddButtonMenu("Assistenza", "assistenza", Risorse.Immagini.Bitmap("kermit")).BackColor = Color.Lavender
            AddHandler .MenuButtonClick, AddressOf PaginaUniarea
        End With
        'portafoglio
        If Utx.Globale.ProfiloEnteGestore.ProfiloApp = Utx.Enumerazioni.ProfiloApp.COMPLETO Then
            With UniMenu.AddPage("Portafoglio", "portafoglio")
                .AddButtonMenu("Clienti", "anag", Risorse.Immagini.Bitmap("clienti"))
                .AddButtonMenu("Evidenze", "evidenze", Risorse.Immagini.Bitmap("evidenze"))
                .AddButtonMenu("Quotatore", "quota", Risorse.Immagini.Bitmap("quota"))
                .AddButtonMenu("Estrattore dati", "estrai", Risorse.Immagini.Bitmap("estrai"))
                AddHandler .MenuButtonClick, AddressOf PaginaPortafoglio
            End With
        End If
        'quietanzamento
        If Utx.Globale.ProfiloEnteGestore.ProfiloApp = Utx.Enumerazioni.ProfiloApp.COMPLETO Then
            With UniMenu.AddPage("Quietanzamento", "quietanzamento")
                .AddButtonMenu("Monitor Rca", "monitorqt", Risorse.Immagini.Bitmap("monitor"))
                .AddButtonMenu("Lista polizze{0}non quietanzate", "listanonqt", Risorse.Immagini.Bitmap("list32"))
                .AddButtonMenu("Liste QT", "listeqt", Risorse.Immagini.Bitmap("folder_giallo"))
                If Utx.Tester.BDA(Utx.Globale.AgenziaRichiesta.CodiceAgenzia) = True Then
                    .AddButtonMenu("Gestione BDA", "bda", Risorse.Immagini.Bitmap("ania"))
                End If
                AddHandler .MenuButtonClick, AddressOf PaginaQuietanzamento
            End With
        End If
        'postalizzazione
        If Utx.Globale.ProfiloEnteGestore.ProfiloApp = Utx.Enumerazioni.ProfiloApp.COMPLETO Then
            With UniMenu.AddPage("Comunicatore", "postalizzazione")
                .AddButtonMenu("Attiva{0}il servizio", "attivapost", Risorse.Immagini.Bitmap("uniarea"))
                .AddButtonMenu("Configura{0}il servizio", "configpost", Risorse.Immagini.Bitmap("config"))
                .AddButtonMenu("Avvisi{0}di scadenza", "avvisipost", Risorse.Immagini.Bitmap("posta"))
                .AddButtonMenu("Traccia{0}le comunicazioni", "tracciapost", Risorse.Immagini.Bitmap("posizione"))
                .AddButtonMenu("Lista polizze{0}non quietanzate", "listanonqtpost", Risorse.Immagini.Bitmap("list32"))
                GestioneMenuPostalizzazione()
                AddHandler .MenuButtonClick, AddressOf PaginaPostalizzazione
            End With
        End If
        'sinistri
        With UniMenu.AddPage("Sinistri", "sinistri")
            .AddButtonMenu("Scheda sinistri", "schedasinistri", Risorse.Immagini.Bitmap("sinistro"))
            .AddButtonMenu("Statistiche", "statistiche", Risorse.Immagini.Bitmap("torta"))
            .AddButtonMenu("Consap", "consap", Risorse.Immagini.Bitmap("consap"))
            .AddButtonMenu("Compila CAI", "cai", Risorse.Immagini.Bitmap("cai"))
            .AddButtonMenu("Barèmes", "baremes", Risorse.Immagini.Bitmap("check"))
            .AddButtonMenu("Referenti sinistri", "referenti", Risorse.Immagini.Bitmap("referenti"))
            AddHandler .MenuButtonClick, AddressOf PaginaSinistri
        End With
        'adempimenti
        If Utx.Globale.ProfiloEnteGestore.ProfiloApp = Utx.Enumerazioni.ProfiloApp.COMPLETO Then
            With UniMenu.AddPage("Adempimenti", "adempimenti")
                .AddButtonMenu("Invio documenti", "adempimenti", Risorse.Immagini.Bitmap("spunta"))
                .AddButtonMenu("File decadali", "buste", Risorse.Immagini.Bitmap("busta"))
                AddHandler .MenuButtonClick, AddressOf PaginaAdempimenti
            End With
        End If
        'gestione
        If Utx.Globale.ProfiloEnteGestore.ProfiloApp = Utx.Enumerazioni.ProfiloApp.COMPLETO Then
            With UniMenu.AddPage("Gestione", "gestione")
                .AddButtonMenu("Analisi incassi{0}e budget", "budget", Risorse.Immagini.Bitmap("budget"))
                .AddButtonMenu("Nuova produzione", "np", Risorse.Immagini.Bitmap("report"))
                .AddButtonMenu("Aggiorna{0}incassi", "incassi", Risorse.Immagini.Bitmap("aggiorna"))
                .AddButtonMenu("Aggiorna{0}arretrati", "arretrati", Risorse.Immagini.Bitmap("aggiorna2"))
                .AddButtonMenu("Contabilità", "unicont", Risorse.Immagini.Bitmap("euro"))
                If Utx.Globale.ProfiloEnteGestore.Abilitazioni.SISTEMA = True Then
                    .AddButtonMenu("Sistema", "sistema", Risorse.Immagini.Bitmap("sistema"))
                End If
                If Utx.Tester.GestioneCassa(Utx.Globale.ProfiloEnteGestore.AgenziaMadre) = True Then
                    .AddButtonMenu("Cassa", "cassa", Risorse.Immagini.Bitmap("coin"))
                End If
                AddHandler .MenuButtonClick, AddressOf PaginaGestione
            End With
        End If
        'patto unipol
        With UniMenu.AddPage("Patto Unipol", "patto")
            .AddButtonMenu("Patto Unipol{0}2017", "vademecum", Risorse.Immagini.Bitmap("books"))
            If Utx.Globale.ProfiloEnteGestore.ProfiloApp = Utx.Enumerazioni.ProfiloApp.COMPLETO Then
                .AddButtonMenu("Remunerazione{0}Rca", "pattorca", Risorse.Immagini.Bitmap("evidenza"))
                .AddButtonMenu("Prodotti liberi", "liberi", Risorse.Immagini.Bitmap("torta"))
                .AddButtonMenu("Simulatore{0}rappel", "rappel", Risorse.Immagini.Bitmap("rubik"))
            End If
#If Not Debug Then
            .BottoneMenu("rappel").Enabled = Utx.Globale.UtenteCorrente.IsAgente
#End If
            AddHandler .MenuButtonClick, AddressOf PaginaPatto
        End With
        'contatti
        If Utx.Globale.ProfiloEnteGestore.ProfiloApp = Utx.Enumerazioni.ProfiloApp.COMPLETO Then
            With UniMenu.AddPage("Contatti", "contatti")
                .AddButtonMenu("Invia e-mail{0}e sms", "mail", Risorse.Immagini.Bitmap("mail"))
                .AddButtonMenu("Estrai e invia{0}un messaggio", "estrai", Risorse.Immagini.Bitmap("estrai_com"))
                .AddButtonMenu("Invia sms{0}a lista", "comunica", Risorse.Immagini.Bitmap("comunica"))
                .AddButtonMenu("Account sms", "account", Risorse.Immagini.Bitmap("account"))
                .AddButtonMenu("Notifiche sms", "notifiche", Risorse.Immagini.Bitmap("ricevuta"))
                If Utx.Tester.Lettere(Utx.Globale.AgenziaRichiesta.CodiceAgenzia) Then
                    .AddButtonMenu("Stampa lettere", "lettere", Risorse.Immagini.Bitmap("lettera"))
                End If
                'If Ut.Tester.WhatsApp(Ut.Globale.AgenziaRichiesta.CodiceAgenzia) Then
                '    .AddButtonMenu("WhatsApp", "wapp", Risorse.Immagini.Bitmap("wapp"))
                'End If
                AddHandler .MenuButtonClick, AddressOf PaginaContatti
            End With
        End If
        'utilità
        With UniMenu.AddPage("Utilità", "utilita")
            If Utx.Globale.ProfiloEnteGestore.ProfiloApp = Utx.Enumerazioni.ProfiloApp.COMPLETO Then
                .AddButtonMenu("Scansione{0}assegni", "assegni", Risorse.Immagini.Bitmap("assegno"))
                .AddButtonMenu("Documenti{0}personali", "doc_personali", Risorse.Immagini.Bitmap("folder_verde"))
                .AddButtonMenu("Dossier{0}d'agenzia", "doc_agenzia", Risorse.Immagini.Bitmap("folder_blu"))
            End If
            .AddButtonMenu("Visure PRA", "visure", Risorse.Immagini.Bitmap("aci"))
            .AddButtonMenu("Scanner", "scanner", Risorse.Immagini.Bitmap("scandoc")).BackColor = Color.Lavender
            .AddButtonMenu("Monitor centralino", "centralino", Risorse.Immagini.Bitmap("telefono"))
            'unicoop
            If IO.File.Exists(IO.Path.Combine(Utx.Globale.Paths.CartellaApp, "Unicoop.exe")) Then
                .AddButtonMenu("Trattenute{0}Unicoop", "unicoop", Risorse.Immagini.Bitmap("unicoop"))
            End If
            .AddButtonMenu("Informazioni", "infout", Risorse.Immagini.Bitmap("info"))
            If Utx.Globale.ProfiloEnteGestore.ProfiloApp = Utx.Enumerazioni.ProfiloApp.COMPLETO Then
                .AddButtonMenu("Link utili", "link", Risorse.Immagini.Bitmap("link"))
            End If
            AddHandler .MenuButtonClick, AddressOf PaginaUtilita
        End With
        'manutenzione
        With UniMenu.AddPage("Manutenzione", "manutenzione")
#If DEBUG Then
            .BottonePagina.BackColor = Color.YellowGreen
#End If
            .AddButtonMenu("Assistenza", "assistenza", Risorse.Immagini.Bitmap("kermit")).BackColor = Color.Lavender
            .AddButtonMenu("Strumenti", "strumenti", Risorse.Immagini.Bitmap("strumenti"))
            .AddButtonMenu("Visualizza log", "vedilog", Risorse.Immagini.Image("list"))
            If Utx.Tester.TestUtente(Utx.Globale.AgenziaRichiesta.CodiceAgenzia) Then
                .AddButtonMenu("Prima nota", "testutente").BackColor = Color.Gold
            End If
            If Utx.Tester.BottoneTest(Utx.Globale.AgenziaRichiesta.CodiceAgenzia) Then
                .AddButtonMenu("Test debug", "testdebug").BackColor = Color.Orange
            End If
            AddHandler .MenuButtonClick, AddressOf PaginaManutenzione
        End With
        'uscita
        With UniMenu.AddPage("Esci", "chiudi")
            .BottonePagina.BackColor = Color.FromArgb(130, 150, 170)
            .BottonePagina.TrackColor = Color.Red
        End With
        'aggiungo il menù al form
        Me.Controls.Add(UniMenu)
    End Sub

    Private Sub MenuSinistri()
        PagesMenu.TrackColor = Color.DodgerBlue
        PagesMenu.ButtonPageHeight = 27

        UniMenu = New PagesMenu(True)

        With UniMenu
            .Dock = DockStyle.Fill

            'altezza di default dei bottoni di pagina
            .ButtonStyle = PageButton.Style.FLAT
            .ButtonBackColor = Color.Gainsboro

            'label info
            If .ViewInfoLabel = True Then
                .InfoLabel.Margin = New Padding(0)
                .InfoLabel.Font = Utx.AppFont.Normal
                .InfoLabel.Text = ""
            End If
        End With

        Page.ButtonMenuHeight = 50
        Page.ButtonMenuBackColor = Color.White
        Page.ButtonMenuStyle = MenuButton.Style.FLAT
        Page.ButtonPageStyle = PageButton.Style.FLAT

        'main
        With UniMenu.AddPage(DeskMainMenu, "main")
            If Utx.EnteGestore.CodiciGestiti.Count > 1 Then
                .AddButtonMenu("Cambia agenzia", "cambioagenzia", Risorse.Immagini.Bitmap("cambiaagenzia"))
            End If
            .AddButtonMenu("Importa dati", "importa", Risorse.Immagini.Bitmap("importa"))
            .AddButtonMenu("Configura", "config", Risorse.Immagini.Bitmap("config"))
            'per i PP
            If Utx.FunzioniRete.PcInDominio = False Then
                .AddButtonMenu("Sincronizza dati", "sincro", Risorse.Immagini.Bitmap("sincro"))
                .AddButtonMenu("Connetti M:", "connetti", Risorse.Immagini.Bitmap("connetti"))
            End If
            .AddButtonMenu("Cambia utente{0}e/o password", "cambiautente", Risorse.Immagini.Bitmap("user"))
            AddHandler .MenuButtonClick, AddressOf PaginaMain
        End With
        'pagina uniarea
        With UniMenu.AddPage("Uniarea", "uniarea")
            .AddButtonMenu("Uniarea", "uniarea", Risorse.Immagini.Bitmap("uniarea"))
            If Utx.Globale.ProfiloEnteGestore.ProfiloApp = Utx.Enumerazioni.ProfiloApp.COMPLETO Then
                .AddButtonMenu("Formazione", "formazione", Risorse.Immagini.Bitmap("formazione"))
            End If
            .AddButtonMenu("Comunicazioni", "rss", Risorse.Immagini.Bitmap("rss"))
            .AddButtonMenu("uTwitt", "utwitt", Risorse.Immagini.Bitmap("utwitt"))
            .AddButtonMenu("Guida", "help", Risorse.Immagini.Bitmap("help"))
            .AddButtonMenu("Assistenza", "assistenza", Risorse.Immagini.Bitmap("kermit")).BackColor = Color.Lavender
            AddHandler .MenuButtonClick, AddressOf PaginaUniarea
        End With
        'sinistri
        With UniMenu.AddPage("Sinistri", "sinistri")
            .AddButtonMenu("Scheda sinistri", "schedasinistri", Risorse.Immagini.Bitmap("sinistro"))
            .AddButtonMenu("Statistiche", "statistiche", Risorse.Immagini.Bitmap("torta"))
            .AddButtonMenu("Consap", "consap", Risorse.Immagini.Bitmap("consap"))
            .AddButtonMenu("Compila CAI", "cai", Risorse.Immagini.Bitmap("cai"))
            .AddButtonMenu("Barèmes", "baremes", Risorse.Immagini.Bitmap("check"))
            .AddButtonMenu("Referenti sinistri", "referenti", Risorse.Immagini.Bitmap("referenti"))
            AddHandler .MenuButtonClick, AddressOf PaginaSinistri
        End With
        'patto unipol
        With UniMenu.AddPage("Patto Unipol", "patto")
            .AddButtonMenu("Patto Unipol{0}2017", "vademecum", Risorse.Immagini.Bitmap("books"))
            AddHandler .MenuButtonClick, AddressOf PaginaPatto
        End With
        'utilità
        With UniMenu.AddPage("Utilità", "utilita")
            .AddButtonMenu("Visure PRA", "visure", Risorse.Immagini.Bitmap("aci"))
            .AddButtonMenu("Scanner", "scanner", Risorse.Immagini.Bitmap("scandoc")).BackColor = Color.Lavender
            .AddButtonMenu("Informazioni", "infout", Risorse.Immagini.Bitmap("info"))
            'unicoop
            If IO.File.Exists(IO.Path.Combine(Utx.Globale.Paths.CartellaApp, "Unicoop.exe")) Then
                .AddButtonMenu("Trattenute{0}Unicoop", "unicoop", Risorse.Immagini.Bitmap("unicoop"))
            End If
            AddHandler .MenuButtonClick, AddressOf PaginaUtilita
        End With
        'manutenzione
        With UniMenu.AddPage("Manutenzione", "manutenzione")
#If DEBUG Then
            .BottonePagina.BackColor = Color.YellowGreen
#End If
            .AddButtonMenu("Assistenza", "assistenza", Risorse.Immagini.Bitmap("kermit")).BackColor = Color.Lavender
            .AddButtonMenu("Strumenti", "strumenti", Risorse.Immagini.Bitmap("strumenti"))
            .AddButtonMenu("Visualizza log", "vedilog", Risorse.Immagini.Image("list"))
            AddHandler .MenuButtonClick, AddressOf PaginaManutenzione
        End With
        'uscita
        With UniMenu.AddPage("Esci", "chiudi")
            .BottonePagina.BackColor = Color.FromArgb(130, 150, 170)
            .BottonePagina.TrackColor = Color.Red
        End With
        'aggiungo il menù al form
        Me.Controls.Add(UniMenu)
    End Sub

    Private Sub MenuPostalizzazione()
        PagesMenu.TrackColor = Color.DodgerBlue
        PagesMenu.ButtonPageHeight = 27

        UniMenu = New PagesMenu(True)

        With UniMenu
            .Dock = DockStyle.Fill

            'altezza di default dei bottoni di pagina
            .ButtonStyle = PageButton.Style.FLAT
            .ButtonBackColor = Color.Gainsboro

            'label info
            If .ViewInfoLabel = True Then
                .InfoLabel.Margin = New Padding(0)
                .InfoLabel.Font = Utx.AppFont.Normal
                .InfoLabel.Text = ""
            End If
        End With

        Page.ButtonMenuHeight = 50
        Page.ButtonMenuBackColor = Color.White
        Page.ButtonMenuStyle = MenuButton.Style.FLAT
        Page.ButtonPageStyle = PageButton.Style.FLAT

        'main
        With UniMenu.AddPage(DeskMainMenu, "main")
            If Utx.EnteGestore.CodiciGestiti.Count > 1 Then
                .AddButtonMenu("Cambia agenzia", "cambioagenzia", Risorse.Immagini.Bitmap("cambiaagenzia"))
            End If
            .AddButtonMenu("Importa dati", "importa", Risorse.Immagini.Bitmap("importa"))
            .AddButtonMenu("Configura", "config", Risorse.Immagini.Bitmap("config"))
            'per i PP
            If Utx.FunzioniRete.PcInDominio = False Then
                .AddButtonMenu("Sincronizza dati", "sincro", Risorse.Immagini.Bitmap("sincro"))
                .AddButtonMenu("Connetti M:", "connetti", Risorse.Immagini.Bitmap("connetti"))
            End If
            .AddButtonMenu("Cambia utente{0}e/o password", "cambiautente", Risorse.Immagini.Bitmap("user"))
            AddHandler .MenuButtonClick, AddressOf PaginaMain
        End With
        'pagina uniarea
        With UniMenu.AddPage("Uniarea", "uniarea")
            .AddButtonMenu("Uniarea", "uniarea", Risorse.Immagini.Bitmap("uniarea"))
            If Utx.Globale.ProfiloEnteGestore.ProfiloApp = Utx.Enumerazioni.ProfiloApp.COMPLETO Then
                .AddButtonMenu("Formazione", "formazione", Risorse.Immagini.Bitmap("formazione"))
            End If
            .AddButtonMenu("Comunicazioni", "rss", Risorse.Immagini.Bitmap("rss"))
            .AddButtonMenu("uTwitt", "utwitt", Risorse.Immagini.Bitmap("utwitt"))
            .AddButtonMenu("Guida", "help", Risorse.Immagini.Bitmap("help"))
            .AddButtonMenu("Assistenza", "assistenza", Risorse.Immagini.Bitmap("kermit")).BackColor = Color.Lavender
            AddHandler .MenuButtonClick, AddressOf PaginaUniarea
        End With
        'postalizzazione
        With UniMenu.AddPage("Comunicatore", "postalizzazione")
            .AddButtonMenu("Attiva{0}il servizio", "attivapost", Risorse.Immagini.Bitmap("uniarea"))
            .AddButtonMenu("Configura{0}il servizio", "configpost", Risorse.Immagini.Bitmap("config"))
            .AddButtonMenu("Avvisi{0}di scadenza", "avvisipost", Risorse.Immagini.Bitmap("posta"))
            .AddButtonMenu("Traccia{0}le comunicazioni", "tracciapost", Risorse.Immagini.Bitmap("posizione"))
            .AddButtonMenu("Lista polizze{0}non quietanzate", "listanonqtpost", Risorse.Immagini.Bitmap("list32"))
            GestioneMenuPostalizzazione()
            AddHandler .MenuButtonClick, AddressOf PaginaPostalizzazione
        End With
        'contatti
        'With UniMenu.AddPage("Contatti", "contatti")
        '    .AddButtonMenu("Invia e-mail{0}e sms", "mail", Risorse.Immagini.Bitmap("mail"))
        '    .AddButtonMenu("Estrai e invia{0}un messaggio", "estrai", Risorse.Immagini.Bitmap("estrai_com"))
        '    .AddButtonMenu("Invia sms{0}a lista", "comunica", Risorse.Immagini.Bitmap("comunica"))
        '    .AddButtonMenu("Account sms", "account", Risorse.Immagini.Bitmap("account"))
        '    .AddButtonMenu("Notifiche sms", "notifiche", Risorse.Immagini.Bitmap("ricevuta"))
        '    AddHandler .MenuButtonClick, AddressOf PaginaContatti
        'End With
        'utilità
        With UniMenu.AddPage("Utilità", "utilita")
            '.AddButtonMenu("Visure PRA", "visure", Risorse.Immagini.Bitmap("aci"))
            '.AddButtonMenu("Scanner", "scanner", Risorse.Immagini.Bitmap("scandoc")).BackColor = Color.Lavender
            .AddButtonMenu("Informazioni", "infout", Risorse.Immagini.Bitmap("info"))
            'unicoop
            If IO.File.Exists(IO.Path.Combine(Utx.Globale.Paths.CartellaApp, "Unicoop.exe")) Then
                .AddButtonMenu("Trattenute{0}Unicoop", "unicoop", Risorse.Immagini.Bitmap("unicoop"))
            End If
            AddHandler .MenuButtonClick, AddressOf PaginaUtilita
        End With
        'manutenzione
        With UniMenu.AddPage("Manutenzione", "manutenzione")
            .AddButtonMenu("Assistenza", "assistenza", Risorse.Immagini.Bitmap("kermit")).BackColor = Color.Lavender
            .AddButtonMenu("Strumenti", "strumenti", Risorse.Immagini.Bitmap("strumenti"))
            .AddButtonMenu("Visualizza log", "vedilog", Risorse.Immagini.Image("list"))
            AddHandler .MenuButtonClick, AddressOf PaginaManutenzione
        End With
        'uscita
        With UniMenu.AddPage("Esci", "chiudi")
            .BottonePagina.BackColor = Color.FromArgb(130, 150, 170)
            .BottonePagina.TrackColor = Color.Red
        End With
        'aggiungo il menù al form
        Me.Controls.Add(UniMenu)
    End Sub

    Private Sub MenuSinistriPostalizzazione()
        PagesMenu.TrackColor = Color.DodgerBlue
        PagesMenu.ButtonPageHeight = 27

        UniMenu = New PagesMenu(True)

        With UniMenu
            .Dock = DockStyle.Fill

            'altezza di default dei bottoni di pagina
            .ButtonStyle = PageButton.Style.FLAT
            .ButtonBackColor = Color.Gainsboro

            'label info
            If .ViewInfoLabel = True Then
                .InfoLabel.Margin = New Padding(0)
                .InfoLabel.Font = Utx.AppFont.Normal
                .InfoLabel.Text = ""
            End If
        End With

        Page.ButtonMenuHeight = 50
        Page.ButtonMenuBackColor = Color.White
        Page.ButtonMenuStyle = MenuButton.Style.FLAT
        Page.ButtonPageStyle = PageButton.Style.FLAT

        'main
        With UniMenu.AddPage(DeskMainMenu, "main")
            If Utx.EnteGestore.CodiciGestiti.Count > 1 Then
                .AddButtonMenu("Cambia agenzia", "cambioagenzia", Risorse.Immagini.Bitmap("cambiaagenzia"))
            End If
            .AddButtonMenu("Importa dati", "importa", Risorse.Immagini.Bitmap("importa"))
            .AddButtonMenu("Configura", "config", Risorse.Immagini.Bitmap("config"))
            'per i PP
            If Utx.FunzioniRete.PcInDominio = False Then
                .AddButtonMenu("Sincronizza dati", "sincro", Risorse.Immagini.Bitmap("sincro"))
                .AddButtonMenu("Connetti M:", "connetti", Risorse.Immagini.Bitmap("connetti"))
            End If
            .AddButtonMenu("Cambia utente{0}e/o password", "cambiautente", Risorse.Immagini.Bitmap("user"))
            AddHandler .MenuButtonClick, AddressOf PaginaMain
        End With
        'pagina uniarea
        With UniMenu.AddPage("Uniarea", "uniarea")
            .AddButtonMenu("Uniarea", "uniarea", Risorse.Immagini.Bitmap("uniarea"))
            .AddButtonMenu("Formazione", "formazione", Risorse.Immagini.Bitmap("formazione"))
            .AddButtonMenu("Comunicazioni", "rss", Risorse.Immagini.Bitmap("rss"))
            .AddButtonMenu("uTwitt", "utwitt", Risorse.Immagini.Bitmap("utwitt"))
            .AddButtonMenu("Guida", "help", Risorse.Immagini.Bitmap("help"))
            .AddButtonMenu("Assistenza", "assistenza", Risorse.Immagini.Bitmap("kermit")).BackColor = Color.Lavender
            AddHandler .MenuButtonClick, AddressOf PaginaUniarea
        End With
        'postalizzazione
        With UniMenu.AddPage("Comunicatore", "postalizzazione")
            .AddButtonMenu("Attiva{0}il servizio", "attivapost", Risorse.Immagini.Bitmap("uniarea"))
            .AddButtonMenu("Configura{0}il servizio", "configpost", Risorse.Immagini.Bitmap("config"))
            .AddButtonMenu("Avvisi{0}di scadenza", "avvisipost", Risorse.Immagini.Bitmap("posta"))
            .AddButtonMenu("Traccia{0}le comunicazioni", "tracciapost", Risorse.Immagini.Bitmap("posizione"))
            .AddButtonMenu("Lista polizze{0}non quietanzate", "listanonqtpost", Risorse.Immagini.Bitmap("list32"))
            GestioneMenuPostalizzazione()
            AddHandler .MenuButtonClick, AddressOf PaginaPostalizzazione
        End With
        'sinistri
        With UniMenu.AddPage("Sinistri", "sinistri")
            .AddButtonMenu("Scheda sinistri", "schedasinistri", Risorse.Immagini.Bitmap("sinistro"))
            .AddButtonMenu("Statistiche", "statistiche", Risorse.Immagini.Bitmap("torta"))
            .AddButtonMenu("Consap", "consap", Risorse.Immagini.Bitmap("consap"))
            .AddButtonMenu("Compila CAI", "cai", Risorse.Immagini.Bitmap("cai"))
            .AddButtonMenu("Barèmes", "baremes", Risorse.Immagini.Bitmap("check"))
            .AddButtonMenu("Referenti sinistri", "referenti", Risorse.Immagini.Bitmap("referenti"))
            AddHandler .MenuButtonClick, AddressOf PaginaSinistri
        End With
        'patto unipol
        With UniMenu.AddPage("Patto Unipol", "patto")
            .AddButtonMenu("Patto Unipol{0}2017", "vademecum", Risorse.Immagini.Bitmap("books"))
            AddHandler .MenuButtonClick, AddressOf PaginaPatto
        End With
        'utilità
        With UniMenu.AddPage("Utilità", "utilita")
            .AddButtonMenu("Visure PRA", "visure", Risorse.Immagini.Bitmap("aci"))
            .AddButtonMenu("Scanner", "scanner", Risorse.Immagini.Bitmap("scandoc")).BackColor = Color.Lavender
            .AddButtonMenu("Informazioni", "infout", Risorse.Immagini.Bitmap("info"))
            'unicoop
            If IO.File.Exists(IO.Path.Combine(Utx.Globale.Paths.CartellaApp, "Unicoop.exe")) Then
                .AddButtonMenu("Trattenute{0}Unicoop", "unicoop", Risorse.Immagini.Bitmap("unicoop"))
            End If
            AddHandler .MenuButtonClick, AddressOf PaginaUtilita
        End With
        'manutenzione
        With UniMenu.AddPage("Manutenzione", "manutenzione")
#If DEBUG Then
            .BottonePagina.BackColor = Color.YellowGreen
#End If
            .AddButtonMenu("Assistenza", "assistenza", Risorse.Immagini.Bitmap("kermit")).BackColor = Color.Lavender
            .AddButtonMenu("Strumenti", "strumenti", Risorse.Immagini.Bitmap("strumenti"))
            .AddButtonMenu("Visualizza log", "vedilog", Risorse.Immagini.Image("list"))
            AddHandler .MenuButtonClick, AddressOf PaginaManutenzione
        End With
        'uscita
        With UniMenu.AddPage("Esci", "chiudi")
            .BottonePagina.BackColor = Color.FromArgb(130, 150, 170)
            .BottonePagina.TrackColor = Color.Red
        End With
        'aggiungo il menù al form
        Me.Controls.Add(UniMenu)
    End Sub

#Region "gestione pagine"
    Private Sub PaginaMain(key As String, Index As Integer)
        Utx.ApplicationLog.LogUso("MENU." + key)
        Try
            Select Case key
                Case "cambioagenzia"
                    CambioAgenzia = New Utx.FormCambioAgenzia
                    CambioAgenzia.ShowDialog()
                Case "importa"
                    Using f As New FormImportaDati
                        f.ShowDialog()
                    End Using
                Case "config"
                    Using f As New Utx.FormConfigura
                        f.ShowDialog()
                    End Using
                Case "connetti"
                    If Utx.Setting.Ambiente = Utx.Enumerazioni.TipoAmbiente.PP Then
                        ConnettiEmme()
                    Else
                        RaiseEvent DisconnessioneEmme()
                    End If
                Case "sincro"
                    If Utx.Setting.Ambiente = Utx.Enumerazioni.TipoAmbiente.PP2DIR Then
                        Using f As New FormSincroDati
                            f.ShowDialog()
                        End Using
                    Else
                        MsgBox("E' necessario essere connessi alla rete per effettuare la sincronizzazione",
                               MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                    End If
                Case "cambiautente"
                    If MsgBox("Per completare il cambio utente è necessario riavviare il programma. Continuare?",
                              MsgBoxStyle.Question + MsgBoxStyle.YesNo, Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then
                        Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.LOGIN_RICHIESTO, Format(Today.AddDays(-1), "dd/MM/yyyy 07:00:00"))
                        'nel caso l'utente loggato in UT sia diverso da quello della macchina
                        If Utx.Globale.UtenteCorrente.UniageUser <> Environment.UserName Then
                            Dim temp As New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.EXTRA, Environment.UserName)
                            temp.Rimuovi(Utx.GestioneFlag.TipoFlag.LOGIN_RICHIESTO)
                        End If

                        Dim SelfRun As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "SelfRun.exe")
                        If File.Exists(SelfRun) Then
                            Process.Start(SelfRun)
                        End If
                        Me.Close()
                    End If
                Case Else
                    MsgBox(key, MsgBoxStyle.Information)
            End Select
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub PaginaUniarea(key As String, Index As Integer)
        Utx.ApplicationLog.LogUso("MENU." + key)
        Try
            Select Case key
                Case "uniarea"
                    Process.Start("http://www.uniarea.it")
                Case "formazione"
                    Process.Start("https://servizi.unipolgf.it/SSOPartners/Redirector/Default.aspx?id=gau")
                Case "utwitt"
                    TimerUnitools.AvviaTwitt(ForzaApertura:=True)
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
        Utx.ApplicationLog.LogUso("MENU." + key)
        Try
            Select Case key
                Case "anag"
                    FormSinistri_RichiestaAnagrafiche()
                Case "evidenze"
                    Dim filetocheck As String = Utx.Servizi.AvviaEvidenze()
                    Dim evidenze As New TimerEvidenze(filetocheck)
                Case "quota"
                    Utx.Servizi.AvviaQuotatore()
                Case "estrai"
                    Dim f As UniSql.frmEsplora = New UniSql.UniSql().getEsploratore()
                    f.Show()
            End Select
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub PaginaQuietanzamento(key As String, Index As Integer)
        Utx.ApplicationLog.LogUso("MENU." + key)
        Try
            Select Case key
                Case "monitorqt"
#If DEBUG Then
                    Dim MonitorKMS As New MonitorQT.FormMainKMS
                    MonitorKMS.Show()
#Else
                    Dim Monitor As New MonitorQT.FormMain
                    Monitor.Show()
#End If
                Case "listanonqt"
                    Dim sql As New UniSql.UniSql
                    If sql.ShowGridAndGetDataTable("Polizze non quietanzate", False) Is Nothing Then
                        MsgBox("Accedere al menù Portafoglio >> Estrattore dati per consentire l'aggiornamento delle estrazioni", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                    End If
                Case "listeqt"
                    Utx.Servizi.AvviaListeQT()
                Case "bda"
                    Dim BDA As New BDA.FormBDAMain
                    BDA.Show()
            End Select
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub PaginaPostalizzazione(key As String, Index As Integer)
        Utx.ApplicationLog.LogUso("MENU." + key)
        Try
            Using s As New Utx.SettingAgenzia.ConfiguraSede
                s.Proxy = Utx.Globale.UniProxy.Proxy
                Dim Blocco As String = s.EsisteBloccoPostalizzazione(Utx.Globale.UtenteCorrente.UserAndPc) 'restituisce una stringa vuota o l'utente che blocca

                If Blocco.Length = 0 Then 'max durata 1 ora
                    If Utx.GestioneFlag.EsisteFlag(Utx.GestioneFlag.TipoFlag.POSTALIZZAZIONE_ESECUZIONE, 60, UniCom.Postalizzazione.SettingPostalizzazione) = False Then 'max durata 1 ora
                        If Utx.FunzioniAmbiente.EsisteForm("FormPostalizzazione") Then
                            FormPostalizzazione.TopMost = True
                            FormPostalizzazione.WindowState = FormWindowState.Maximized
                            FormPostalizzazione.TopMost = False
                        Else
                            Select Case key
                                Case "attivapost"
                                    'Using s As New Utx.SettingAgenzia.ConfiguraSede
                                    '    s.Proxy = Utx.Globale.UniProxy.Proxy
                                    '    If s.ConsensoPostalizzazione(Utx.Globale.ProfiloEnteGestore.AgenziaMadre) = True Then
                                    '        FormPostalizzazione = New UniCom.FormPostalizzazione()
                                    '        FormPostalizzazione.Show()
                                    '    Else
                                    '        '        Process.Start("https://comunicatore.auaonline.it")
                                    '    End If
                                    'End Using
                                Case "configpost"
#If DEBUG Then
                                    FormPostalizzazione = New UniCom.FormPostalizzazione() With {.TipoChiamata = UniCom.FormPostalizzazione.Modalita.CONFIG}
                                    FormPostalizzazione.Show()
#Else
                                    If Utx.Globale.UtenteCorrente.IsAgente OrElse
                                        UniCom.Postalizzazione.SettingPostalizzazione.LeggiValore(Utx.GestioneFlag.TipoFlag.POSTALIZZAZIONE_UTENTI, "").ToLower.Contains(Utx.Globale.UtenteCorrente.UniageUser.ToLower) Then
                                        FormPostalizzazione = New UniCom.FormPostalizzazione() With {.TipoChiamata = UniCom.FormPostalizzazione.Modalita.CONFIG}
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
                                Case "listanonqtpost"
                                    Dim sql As New UniSql.UniSql
                                    If sql.ShowGridAndGetDataTable("Polizze non quietanzate", False) Is Nothing Then
                                        MsgBox("Accedere al menù Portafoglio >> Estrattore dati per consentire l'aggiornamento delle estrazioni", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                                    End If
                            End Select
                        End If
                    Else
                        MsgBox(String.Format("E' già in corso un'attività di postalizzazione dell'utente {0}. Riprovare più tardi.",
                                             Utx.Utente.NomeUtenza(Blocco)), MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                    End If
                End If
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub PaginaSinistri(key As String, Index As Integer)
        Utx.ApplicationLog.LogUso("MENU." + key)
        Try
            Select Case key
                Case "schedasinistri"
                    FormAnagrafiche_RichiestaSinistri()
                Case "statistiche"
                    Dim f As New Sinistri.FormStatistiche
                    f.Show()
                Case "consap"
                    Using f As New Consap.FormConsap
                        f.ShowDialog()
                    End Using
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
        Utx.ApplicationLog.LogUso("MENU." + key)
        Try
            Select Case key
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
        Utx.ApplicationLog.LogUso("MENU." + key)
        Try
            Select Case key
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
                    Using f As New FormUnicont
                        f.ShowDialog()
                    End Using
                Case "sistema"
                    Utx.Servizi.AvviaSistema()
                Case "cassa"
                    'ChiusuraCassa.Globale.Avvio()
            End Select
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub PaginaPatto(key As String, Index As Integer)
        Utx.ApplicationLog.LogUso("MENU." + key)
        Try
            Select Case key
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
        Utx.ApplicationLog.LogUso("MENU." + key)
        Try
            Select Case key
                Case "mail"
                    Using f As New UniCom.FormMail
                        f.ShowDialog()
                    End Using
                Case "estrai"
                    Dim f As UniSql.frmEsplora = New UniSql.UniSql().getEsploratore()
                    f.Show()
                Case "comunica"
                    Using f As New UniCom.FormRichiestaFile
                        f.ShowDialog()
                    End Using
                Case "account"
                    Using f As New UniCom.FormGestioneAccount
                        f.ShowDialog()
                    End Using
                Case "notifiche"
                    Using f As New UniCom.FormNotifiche
                        f.ShowDialog()
                    End Using
                Case "lettere"
                    If Utx.Tester.Lettere(Utx.Globale.AgenziaRichiesta.CodiceAgenzia) Then
                        Dim f As New UniSql.frmGrid
                        f.UsoStampa = True
                        f.Show()
                    End If
                Case "wapp"
                    'Dim f As New UniCom.FormWhatsApp
                    'f.Show()
            End Select
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub PaginaUtilita(key As String, Index As Integer)
        Utx.ApplicationLog.LogUso("MENU." + key)
        Try
            Select Case key
                Case "assegni"
                    Utx.Servizi.AvviaGestioneAssegni()
                Case "visure"
                    Dim f As New Visure.FormVisure With {.Targa = "", .ClasseVeicolo = ""}
                    f.Show()
                Case "scanner"
                    Using f As New UnitoolsDocumenti.Fotocopia
                        f.ShowDialog()
                    End Using
                Case "centralino"
                    AvviaCentralino(True)
                Case "infout"
                    Using f As New InfoUt.FormInfo
                        f.ShowDialog()
                    End Using
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
                Case "unicoop"
                    Utx.Servizi.AvviaUnicoop("", 0, 0, 0, Today)
            End Select
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub PaginaManutenzione(key As String, Index As Integer)
        Utx.ApplicationLog.LogUso("MENU." + key)
        Try
            Select Case key
                Case "assistenza"
                    Utx.Servizi.AvviaAssistenza()
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
                Case "testutente"
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
                        f.ShowDialog()
                    Catch ex As Exception
                        Utx.Globale.Log.Errore(ex)
                    End Try
                Case "testdebug"
#If DEBUG Then
                    Select Case 3
                        Case 1
                            'Dim f As New Migra.FormMigrazione
                            'f.ShowDialog()
                        Case 2
                            Dim az As New ExportLib.Azioni
                            'az.AnalisiOrariIncassi(Utx.Globale.AgenziaRichiesta.CodiceAgenzia, today)
                            az.AnalisiOrariIncassi("02372", #7/4/2018#)
                        Case 3
                            Dim esporta As New UniFeed.Esporta
                            esporta.EsportaPolizze()
                    End Select
#End If
            End Select
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub
#End Region

    Public Sub UniMenu_Chiudi() Handles UniMenu.Chiudi
        Try
            If Utx.Globale.SessioneCorrente.Bloccata = True Then

                If Utx.Globale.SessioneCorrente.RichiestaChiusura = False Then
                    'invio una richiesta di chiusura alla sessione
                    Utx.Globale.SessioneCorrente.RichiestaChiusura = True

                    'per evitare la visualizzazione della pagina esci bianca in casi particolari
                    UniMenu.ClickPage("uniarea")
                    UniMenu.Refresh()

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
                If UtTimer.bw IsNot Nothing Then Do While UtTimer.bw.IsBusy : Application.DoEvents() : Loop
                If Utx.FunzioniAmbiente.EsisteForm("FormAvvioCentralino") Then MonitorCentralino.Close()
                UtTimer.TimerAbilitato = False
                Utx.OggettoForm.DisposeAll()
                If NotificaChiusura IsNot Nothing Then
                    NotificaChiusura.ChiusuraImmediata()
                End If
                Me.Visible = False
                Me.Refresh()
                Me.Close()
                Application.Exit()
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub UniMenu_Minimizza() Handles UniMenu.Minimizza
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
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
        AggiornaInfoLabel()
        'pagina iniziale
        UniMenu.ClickPage("uniarea")
        Me.Refresh()
        Utx.GestioneFileFlag.DisposeFlag()
        'centralino
        If Utx.Globale.SessioneCorrente.Nascosta = False Then
            AvviaCentralino()
        End If

        If Utx.Globale.SessioneCorrente.Nascosta Then
            MsgTimer = New Timer
            MsgTimer.Interval = 1000
            MsgTimer.Enabled = True
        End If

        'migrazione note disabilitata il 24/10/2023
        'Utx.Migrazione.MigraNote()

        'avvio le temporizzazioni
        UtTimer = New TimerUnitools
    End Sub

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

    Private Sub UniMenu_PageClick(key As String, Index As Integer) Handles UniMenu.PageClick
        Select Case key
            Case "chiudi"
                UniMenu_Chiudi()
            Case "postalizzazione"
                GestioneMenuPostalizzazione(True)
        End Select
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

            Cursor = Cursors.WaitCursor

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
            Cursor = Cursors.Default
        End Try
    End Function

    Private Sub FormMain_ConnessioneEmme() Handles Me.ConnessioneEmme
        Utx.Setting.Ambiente = Utx.Enumerazioni.TipoAmbiente.PP2DIR
        Utx.Globale.Paths.UnitaDati = New DriveInfo(Utx.Globale.Paths.UnitaDatiRete)
        DeskMainBanner()
        AggiornaInfoLabel()
        'modifica bottone
        With UniMenu.Pagina("main").BottoneMenu("connetti")
            .Text = "Disconnetti M:"
            .Image = Risorse.Immagini.Bitmap("disconnetti")
            .Refresh()
        End With
    End Sub

    Private Sub FormMain_DisconnessioneEmme() Handles Me.DisconnessioneEmme
        Utx.Setting.Ambiente = Utx.Enumerazioni.TipoAmbiente.PP
        Utx.Globale.Paths.UnitaDati = New DriveInfo(Utx.Globale.Paths.UnitaDatiLocale)
        DeskMainBanner()
        AggiornaInfoLabel()
        'modifica bottone
        With UniMenu.Pagina("main").BottoneMenu("connetti")
            .Text = "Connetti M:"
            .Image = Risorse.Immagini.Bitmap("connetti")
            .Refresh()
        End With
    End Sub

    Private Sub AggiornaInfoLabel()
        If UniMenu.ViewInfoLabel = True Then
            If Utx.Setting.Ambiente = Utx.Enumerazioni.TipoAmbiente.PP Then
                UniMenu.InfoLabel.BackColor = Color.DarkOrange
            Else
                UniMenu.InfoLabel.BackColor = Color.Green
            End If
            UniMenu.InfoLabelText = DeskMainBanner()
        End If
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
            If Utx.NetFunc.ResumeWindow("Centralino") = False Then
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
        If Utx.Globale.SessioneCorrente.Bloccata = False Then
            UtTimer.TimerAbilitato = False
            Utx.OggettoForm.DisposeAll()
            If NotificaChiusura IsNot Nothing Then
                NotificaChiusura.ChiusuraImmediata()
            End If
            Me.Visible = False
            Me.Refresh()
            Me.Close()
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
                Cursor = Cursors.WaitCursor
                Utx.Globale.ProfiloEnteGestore.Abilitazioni.LeggiAbilitazioni()
                Cursor = Cursors.Default
            End If
        End If
        'imposto i bottoni
        With UniMenu.Pagina("postalizzazione")
            With .BottoneMenu("attivapost")
                .Enabled = (Utx.Globale.ProfiloEnteGestore.Abilitazioni.POSTALIZZAZIONE = False)
                .Testo = IIf(Utx.Globale.ProfiloEnteGestore.Abilitazioni.POSTALIZZAZIONE = True, "Servizio attivo", "Attiva{0}il servizio")
            End With
            .BottoneMenu("configpost").Enabled = (Utx.Globale.ProfiloEnteGestore.Abilitazioni.POSTALIZZAZIONE = True)
            .BottoneMenu("avvisipost").Enabled = (Utx.Globale.ProfiloEnteGestore.Abilitazioni.POSTALIZZAZIONE = True)
            .BottoneMenu("tracciapost").Enabled = (Utx.Globale.ProfiloEnteGestore.Abilitazioni.POSTALIZZAZIONE = True)
        End With
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

    Private Sub CambioAgenzia_CambioCodice(Codice As String) Handles CambioAgenzia.CambioCodice
        Try
            Me.Cursor = Cursors.WaitCursor
            'chiudo le finestre eventualmente aperte/nascoste
            Utx.OggettoForm.Dispose(Utx.OggettoForm.TipoForm.SINISTRI)
            Utx.OggettoForm.Dispose(Utx.OggettoForm.TipoForm.ANAG)
            Utx.OggettoForm.Dispose(Utx.OggettoForm.TipoForm.DOCUMENTI)
            'cambio l'agenzia richiesta
            Utx.Globale.AgenziaRichiesta.CodiceAgenzia = Codice
            'cambio intestazione pagina
            UniMenu.Pages(0).BottonePagina.Text = DeskMainMenu()
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            CambioAgenzia.Close()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UtxEventi_ApriStrumenti() Handles UtxEventi.ApriStrumenti
        PaginaManutenzione("strumenti", 0)
    End Sub

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Utx.Globale.SessioneCorrente.Nascosta Then
            Me.Location = New Point(-10000, 0)
            Me.ShowInTaskbar = False
            Me.WindowState = FormWindowState.Minimized
            Me.Hide()
        End If
    End Sub

    Private Sub MsgTimer_Tick(sender As Object, e As EventArgs) Handles MsgTimer.Tick
        Dim Tag As String = Clipboard.GetText
        If Tag = "TAGUT:RESUME" Then
            MsgTimer.Dispose()
            Clipboard.Clear()
            Utx.Globale.SessioneCorrente.Nascosta = False
            UtTimer.IntervalloTimer = TimerUnitools.IntervalloStandardTimer
            Me.Visible = True
            Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - LarghezzaMenu, 0)
            Me.WindowState = FormWindowState.Normal

            For Each n As Utx.FormNotifica In Utx.FormNotifica.ListaNotifiche
                n.Altezza = n.y
            Next
        End If
    End Sub
End Class
