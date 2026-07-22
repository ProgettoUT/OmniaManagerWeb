Imports Microsoft.Web.WebView2.WinForms
Imports Microsoft.Web.WebView2.Core

Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO
Imports Utx
Imports System.Runtime.InteropServices
Imports EO.Base

Public Class FormSinistri
    'per forzare i cookie nel browser
    <DllImport("wininet.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Public Shared Function InternetSetCookie(lpszUrl As String,
      lpszCookieName As String, lpszCookieDataAs As String) As Boolean
    End Function

    Public Event RichiestaAnagrafiche()
    Public Event RichiestaCliente(CodiceFiscale As String)
    Public Event RichiestaCambioAgenzia(Codice As String)

    Private WithEvents BwLogin As New System.ComponentModel.BackgroundWorker
    Private WithEvents FormDocumenti As UnitoolsDocumenti.FormDocumenti
    Private WithEvents FormImportaSinistri As FormImportaSinistri

    'bottoni per il menù
    Private WithEvents ButtonAddSinistro As New ToolStripSplitButton
    Private WithEvents MenuItemCancellaSinistro As New ToolStripMenuItem
    Private WithEvents MenuItemCatturaEvento As New ToolStripMenuItem
    Private WithEvents ButtonDocumenti As New UtControls.UtFlatButton
    Private WithEvents ButtonDocumentiLiquido As New UtControls.UtFlatButton
    Private WithEvents ButtonSomma As New UtControls.UtFlatButton
    Private WithEvents ButtonViste As New UtControls.UtFlatButton
    Private WithEvents ButtonEsci As New UtControls.UtFlatButton
    Private WithEvents ButtonEsportaCsv As New UtControls.UtFlatButton
    Private WithEvents ButtonUeba As New UtControls.UtFlatButton
    Private WithEvents ButtonEssig As New UtControls.UtFlatButton
    Private WithEvents ButtonOWA As New UtControls.UtFlatButton
    Private WithEvents ButtonAnag As New UtControls.UtFlatButton
    Private WithEvents ButtonAnagCliente As New UtControls.UtFlatButton
    Private WithEvents ButtonLayout As New UtControls.UtFlatButton
    Private WithEvents ButtonNoteAttivita As New UtControls.UtFlatButton
    Private WithEvents ButtonConsap As New UtControls.UtFlatButton
    Private WithEvents ButtonCopia As New UtControls.UtFlatButton
    Private WithEvents ButtonFiltri As New UtControls.UtFlatButton
    Private WithEvents ButtonReferenti As New UtControls.UtFlatButton
    Private WithEvents ButtonSinistriCliente As New UtControls.UtFlatButton
    Private WithEvents ButtonRipristinoStorico As New UtControls.UtFlatButton
    Private WithEvents ButtonCambiaAgenzia As New UtControls.UtFlatButton

    'tab e page
    Private WithEvents TabSinistri As New Utx.UtTabControl
    Private WithEvents TabPageElenco As New TabPage
    Private WithEvents TabPageDettaglio As New TabPage
    Private WithEvents TabPageAndamento As New TabPage
    Private WithEvents TabPageNote As New TabPage
    Private WithEvents TabPageLiquido As New TabPage
    'Private WithEvents TabPageSertel As New TabPage
    Private WithEvents TabPageUeba As UtControls.Ueba
    Private WithEvents TabPageEssig As UtControls.Essig
    'altri controlli
    Private WithEvents ElencoSinistri As New ucSinistri()
    Private WithEvents DettaglioSinistro As New ucDettaglio
    Private WithEvents AndamentoSinistro As New ucAndamento
    Private WithEvents NoteSinistro As New UtControls.ucNote(True, True)
    Private WithEvents TimerCerca As New Timer
    Private WithEvents NavBar As New UtControls.ucNavigationBar()
    Private WithEvents WbLiquido As New EO.WinForm.WebControl
    'Private WithEvents WvLiquido As New EO.WebBrowser.WebView
    Private WithEvents WebViewLiquido As New WebView2
    Private WithEvents CoreWebView2 As CoreWebView2

    Private ReadOnly RicercaSertel As Boolean
    Private ReadOnly ColoreEsercizio As Color = Color.SteelBlue
    Public WithEvents Query As QuerySinistri
    Public WithEvents SinistroCorrente As Sinistro

    Private ReadOnly LoginLiquido As New Utx.AutenticazioneLiquido
    Private ReadOnly LoginSertel As New Utx.AutenticazioneSertel
    Private LoginEssig As New Utx.AutenticazioneEssig
    Private ReadOnly LoginUniage As New Utx.AutenticazioneUeba

    Private mTipoChiusura As Utx.OggettoForm.ChiusuraForm
    Private WithEvents Runtime As New EO.Base.Runtime
    Private ThreadDecodifiche As Threading.Thread

    Private WithEvents dgvSinistri As DataGridView = ElencoSinistri.dgvSinistri 'per agganciare gli eventi della griglia
    Private Legenda As DataTable

    Sub New()
        EO.WebBrowser.Runtime.AddLicense(Utx.Licenze.EO_2018)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

        If Utx.Globale.IdAppOk = False Then
            Application.Exit()
            Exit Sub
        End If

        Me.SuspendLayout()
        With Me
            .MinimumSize = New Size(Screen.PrimaryScreen.WorkingArea.Width * 0.65, Screen.PrimaryScreen.WorkingArea.Height * 0.5)
            .WindowState = Windows.Forms.FormWindowState.Maximized
            .Icon = Risorse.Immagini.Icon("sinistro")
            .Font = Utx.AppFont.Normal
            .Padding = New Padding(3)
            .Text = "Gestione sinistri"
        End With

        Query = New QuerySinistri With {.Abilitata = False}
        SinistroCorrente = New Sinistro(Query.NomeTabella)
        ElencoSinistri.Visible = False

        Dim t1 As New Threading.Thread(Sub()
                                           ElencoSinistri.Consolidato =
                                           Utx.WsCommand.ExecuteScalar("SELECT Consolida FROM CalendarioOmnia WHERE TipoFile = '05'",
                                                                       ValoreDefault:=#1/1/1900#).Valore
                                       End Sub)
        t1.Start()

        ImpostaToolStripMain()
        ImpostaControlli()

        'Utx.Globale.ScalaControlli(Me)
        'Utx.Globale.ScalaFont(ElencoSinistri.dgvSinistri)

        ElencoSinistri.MenuViste = False
        ElencoSinistri.RigaTotali = True
        Me.ResumeLayout()

        Utx.OggettoForm.Add(Utx.OggettoForm.TipoForm.SINISTRI, Me)
    End Sub

#Region "impostacontrolli"
    Private Sub ImpostaToolStripMain()
        On Error Resume Next

        Dim tt As New ToolTip

        With tsMainMenu
            .SuspendLayout()
            .GripStyle = ToolStripGripStyle.Hidden
            .BackColor = Color.Transparent
            .Items.Clear()
        End With

        Dim ttch As ToolStripControlHost

        MenuItemCatturaEvento.Text = "Cattura sinistro da evento"
        MenuItemCancellaSinistro.Text = "Cancella il sinistro selezionato"

        With ButtonAddSinistro
            .DisplayStyle = ToolStripItemDisplayStyle.Image
            .ImageScaling = ToolStripItemImageScaling.None
            .Image = Risorse.Immagini.Bitmap("addsinistro")
            .ImageAlign = ContentAlignment.MiddleCenter
            .TextAlign = ContentAlignment.MiddleRight
            .DropDown.Items.Add(MenuItemCatturaEvento)
            .DropDown.Items.Add(MenuItemCancellaSinistro)
        End With
        tsMainMenu.Items.Add(ButtonAddSinistro)

        With ButtonDocumenti
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Image = Risorse.Immagini.Bitmap("scandoc")
            .SetToolTip("Scanner e documenti del sinistro")
        End With
        ttch = New ToolStripControlHost(ButtonDocumenti)
        tsMainMenu.Items.Add(ttch)

        With ButtonDocumentiLiquido
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Image = Risorse.Immagini.Bitmap("webdoc")
            .SetToolTip("Documenti Liquido e Sertel del sinistro")
        End With
        ttch = New ToolStripControlHost(ButtonDocumentiLiquido)
        tsMainMenu.Items.Add(ttch)

        With ButtonNoteAttivita
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Image = Risorse.Immagini.Bitmap("clock")
            .SetToolTip("Attività in scadenza")
        End With
        ttch = New ToolStripControlHost(ButtonNoteAttivita)
        tsMainMenu.Items.Add(ttch)

        With ButtonFiltri
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Image = Risorse.Immagini.Bitmap("filter")
            .SetToolTip("Filtra dati")
        End With
        ttch = New ToolStripControlHost(ButtonFiltri)
        tsMainMenu.Items.Add(ttch)

        With ButtonConsap
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Image = Risorse.Immagini.Bitmap("consap")
            .SetToolTip("Richieste Consap")
        End With
        ttch = New ToolStripControlHost(ButtonConsap)
        tsMainMenu.Items.Add(ttch)

        With ButtonReferenti
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Image = Risorse.Immagini.Bitmap("referenti")
            .SetToolTip("Referenti sinistri")
        End With
        ttch = New ToolStripControlHost(ButtonReferenti)
        tsMainMenu.Items.Add(ttch)

        If Utx.Globale.ProfiloEnteGestore.ProfiloApp = Utx.Enumerazioni.ProfiloApp.COMPLETO Then
            With ButtonAnagCliente
                .AutoSize = False
                .Width = tsMainMenu.Height
                .Image = Risorse.Immagini.Bitmap("cliente")
                .SetToolTip("Scheda anagrafica del cliente")
            End With
            ttch = New ToolStripControlHost(ButtonAnagCliente)
            tsMainMenu.Items.Add(ttch)
        End If

        With ButtonSinistriCliente
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Image = Risorse.Immagini.Bitmap("filtrocliente")
            .SetToolTip("Tutti i sinistri del cliente")
        End With
        ttch = New ToolStripControlHost(ButtonSinistriCliente)
        tsMainMenu.Items.Add(ttch)

        tsMainMenu.Items.Add(New ToolStripSeparator)

        With ButtonSomma
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Image = Risorse.Immagini.Bitmap("somma")
            .SetToolTip("Vedi/nascondi riga somma")
        End With
        ttch = New ToolStripControlHost(ButtonSomma)
        tsMainMenu.Items.Add(ttch)

        With ButtonEsportaCsv
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Image = Risorse.Immagini.Bitmap("csv")
            .SetToolTip("Esporta in csv")
        End With
        ttch = New ToolStripControlHost(ButtonEsportaCsv)
        tsMainMenu.Items.Add(ttch)

        With ButtonCopia
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Image = Risorse.Immagini.Bitmap("copia")
            .SetToolTip("Copia dati")
        End With
        ttch = New ToolStripControlHost(ButtonCopia)
        tsMainMenu.Items.Add(ttch)

        tsMainMenu.Items.Add(New ToolStripSeparator)

        With ButtonViste
            .Image = Risorse.Immagini.Bitmap("menuextra")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Menù Viste"
            .TextAlign = ContentAlignment.MiddleRight
            .SetToolTip("Vedi/nascondi menù Viste")
        End With
        ttch = New ToolStripControlHost(ButtonViste) With {.Dock = DockStyle.Fill, .Width = 120, .Alignment = ToolStripItemAlignment.Left}
        tsMainMenu.Items.Add(ttch)

        tsMainMenu.Items.Add(New ToolStripSeparator)

        With ButtonUeba
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Image = Risorse.Immagini.Bitmap("ueba")
            .SetToolTip("Apri scheda Ueba")
        End With
        ttch = New ToolStripControlHost(ButtonUeba)
        tsMainMenu.Items.Add(ttch)
        With ButtonEssig
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Image = Risorse.Immagini.Bitmap("essig")
            .SetToolTip("Apri scheda Essig")
        End With
        ttch = New ToolStripControlHost(ButtonEssig)
        tsMainMenu.Items.Add(ttch)
        With ButtonOWA
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Image = Risorse.Immagini.Bitmap("owa")
            .SetToolTip("Apri posta OWA")
        End With
        tsMainMenu.Items.Add(New ToolStripControlHost(ButtonOWA))

        tsMainMenu.Items.Add(New ToolStripSeparator)

        'combo dei layout
        With ButtonLayout
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Text = "Layout"
            .TextAlign = ContentAlignment.MiddleCenter
            .SetToolTip("Gestisci i layout")
        End With
        ttch = New ToolStripControlHost(ButtonLayout)
        tsMainMenu.Items.Add(ttch)

        With ComboBoxLayout
            .Dock = DockStyle.Top
            .ForeColor = Color.DodgerBlue
        End With
        ttch = New ToolStripControlHost(ComboBoxLayout) With {.AutoSize = False, .Width = 150}
        tsMainMenu.Items.Add(ttch)

        tsMainMenu.Items.Add(New ToolStripSeparator)

        'anagrafiche
        If Utx.Globale.ProfiloEnteGestore.ProfiloApp = Utx.Enumerazioni.ProfiloApp.COMPLETO Then
            With ButtonAnag
                .Height = tsMainMenu.Height
                .Dock = DockStyle.Fill
                .Image = Risorse.Immagini.Bitmap("clienti")
                .ImageAlign = ContentAlignment.MiddleLeft
                .Text = "Anagrafiche"
                .TextAlign = ContentAlignment.MiddleRight
            End With
            ttch = New ToolStripControlHost(ButtonAnag) With {.Dock = DockStyle.Fill, .Width = 120, .Alignment = ToolStripItemAlignment.Left}
            tsMainMenu.Items.Add(ttch)
        End If
        'ripristino storico
        With ButtonRipristinoStorico
            .Height = tsMainMenu.Height
            .Dock = DockStyle.Fill
            .Image = Risorse.Immagini.Bitmap("sincro")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Ripristino storico"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        ttch = New ToolStripControlHost(ButtonRipristinoStorico) With {.Dock = DockStyle.Fill, .Width = 140, .Alignment = ToolStripItemAlignment.Left}
        tsMainMenu.Items.Add(ttch)

        tsMainMenu.Items.Add(New ToolStripSeparator)

        'cambio agenzia
        If Utx.EnteGestore.CodiciGestiti.Count > 1 Then
            With ButtonCambiaAgenzia
                .Height = tsMainMenu.Height
                .Dock = DockStyle.Fill
                .BackColor = Color.Gold
                .TextAlign = ContentAlignment.MiddleCenter
            End With
            AggiornaBottoneCodice()
            ttch = New ToolStripControlHost(ButtonCambiaAgenzia) With {.Dock = DockStyle.Fill, .Width = 150, .Alignment = ToolStripItemAlignment.Left}
            tsMainMenu.Items.Add(ttch)
        End If

        With ButtonEsci
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Image = Risorse.Immagini.Bitmap("esci")
            .SetToolTip("Esci")
        End With
        ttch = New ToolStripControlHost(ButtonEsci) With {.Alignment = ToolStripItemAlignment.Right}
        tsMainMenu.Items.Add(ttch)
        tsMainMenu.ResumeLayout()
    End Sub

    Private Sub ImpostaControlli()
        Dim tt As New ToolTip
        StatusStripSinistri.Height = 25
        'pagina elenco
        With TabPageElenco
            .Name = "Elenco"
            .Text = "Elenco sinistri"
            .Controls.Add(ElencoSinistri)
        End With
        'pagina dettaglio
        With TabPageDettaglio
            .Name = "Dettaglio"
            .Text = "Dettaglio sinistro"
            .Controls.Add(DettaglioSinistro)
        End With
        'pagina dettaglio
        With TabPageAndamento
            .Name = "Andamento"
            .Text = "Andamento sinistro"
            .Controls.Add(AndamentoSinistro)
        End With
        'pagina note
        With TabPageNote
            .Name = "Note"
            .Text = "Note sinistro"
            .Controls.Add(NoteSinistro)
        End With
        'pagina liquido
        With TabPageLiquido
            .Name = "Liquido"
            .Text = "Liquido"
            WebViewLiquido.Dock = DockStyle.Fill
            .Controls.Add(WebViewLiquido)
            'WebViewLiquido.EnsureCoreWebView2Async()
            'WbLiquido.Dock = DockStyle.Fill
            '.Controls.Add(WbLiquido)
            'WbLiquido.WebView = WvLiquido
        End With
        With TabSinistri
            .Dock = DockStyle.Fill
            'aggiungo le pagine
            .Controls.Add(TabPageElenco)
            .Controls.Add(TabPageDettaglio)
            .Controls.Add(TabPageNote)
            .Controls.Add(TabPageAndamento)
            .Controls.Add(TabPageLiquido)
            .Margin = New Padding(0, 10, 0, 0)
            'colore del tab selezionato
            .ColorStyle = Utx.UtTabControl.TabColorStyle.ROSSO
        End With

        NavBar.Dock = DockStyle.Fill

        'imposto tablelayoupanel
        With tlpSinistri
            .SuspendLayout()
            .Padding = New Padding(3)
            With .RowStyles.Item(0)
                .SizeType = SizeType.Absolute
                .Height = 40
            End With
            With .RowStyles.Item(1)
                .SizeType = SizeType.Absolute
                .Height = 5
            End With
            With .RowStyles.Item(2)
                .SizeType = SizeType.Absolute
                .Height = 23
            End With
            With .RowStyles.Item(3)
                .SizeType = SizeType.Absolute
                .Height = 5
            End With
            With .RowStyles.Item(4)
                .SizeType = SizeType.Absolute
                .Height = 23
            End With
            'tab sinistri
            .Controls.Add(TabSinistri)
            .SetCellPosition(TabSinistri, New TableLayoutPanelCellPosition(0, 5))
            .SetColumnSpan(TabSinistri, 18)
            'barra di navigazione
            .Controls.Add(NavBar)
            .SetCellPosition(NavBar, New TableLayoutPanelCellPosition(1, 4))
            .SetColumnSpan(NavBar, 4)
            .ResumeLayout()
        End With

        With LabelCerca
            .AutoSize = True
            .Dock = DockStyle.Fill
            .BorderStyle = BorderStyle.None
            .BackColor = Color.Transparent
            .Text = "Cerca"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With ButtonPulisciCerca
            .Margin = New Padding(0, 0, 0, 2)
            .Text = ""
            .Image = Risorse.Immagini.Bitmap("cancel16")
            .ImageAlign = ContentAlignment.MiddleCenter
        End With
        tt.SetToolTip(ButtonPulisciCerca, "pulisci campo ricerca")

        ImpostaChiaviRicerca()
        ImpostaTipoTabella()
        ImpostaTipoChiusura()

        With LabelNumeroSinistri
            .AutoSize = True
            .Dock = DockStyle.Fill
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = Color.Gold
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = "..."
        End With
        With LabelNumeroSinistro
            .AutoSize = True
            .Margin = New Padding(1, 0, 1, 0)
            .Dock = DockStyle.Fill
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = Color.Yellow
            .TextAlign = ContentAlignment.MiddleCenter
            .Font = Utx.AppFont.Bold
            .Text = ""
        End With
        With LabelAssicurato
            .Margin = New Padding(1, 0, 1, 0)
            .AutoSize = True 'importante per non far sfarfallare la label
            .Dock = DockStyle.Fill
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = Color.GreenYellow
            .TextAlign = ContentAlignment.MiddleCenter
            .Font = Utx.AppFont.Bold
            .Text = ""
            .AutoEllipsis = True
        End With
        With LabelValore
            .Margin = New Padding(1, 0, 1, 0)
            .AutoSize = True 'importante per non far sfarfallare la label
            .Dock = DockStyle.Fill
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = Color.Gainsboro
            .TextAlign = ContentAlignment.MiddleCenter
            .Font = Utx.AppFont.Bold
            .Text = ""
        End With
        With LabelChiusura
            .Margin = New Padding(1, 0, 1, 0)
            .AutoSize = True 'importante per non far sfarfallare la label
            .Dock = DockStyle.Fill
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = Color.Gainsboro
            .TextAlign = ContentAlignment.MiddleCenter
            .Font = Utx.AppFont.Bold
            .Text = ""
            tt.SetToolTip(LabelChiusura, "stato tecnico - stato bilancistico")
        End With
        With ButtonSelezionaEsercizi
            .Dock = DockStyle.Fill
            .BackColor = ColoreEsercizio
            .ForeColor = Color.White
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Text = "Esercizi (tutti)"
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With ButtonReset
            .Margin = New Padding(1, 0, 1, 1)
            .Dock = DockStyle.Fill
            .BackColor = Color.Moccasin
            .ForeColor = Color.Black
            .DefaultBorderSize = 1
            .FlatAppearance.BorderColor = Color.Salmon
            .Text = "Reset"
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        'With ButtonResetLiquido
        '    .Margin = New Padding(1, 0, 1, 1)
        '    .Dock = DockStyle.Fill
        '    .BackColor = Color.Gainsboro
        '    .ForeColor = Color.Black
        '    .DefaultBorderSize = 1
        '    .FlatAppearance.BorderColor = Color.Gray
        '    .Text = "Reset Liquido"
        '    .TextAlign = ContentAlignment.MiddleCenter
        'End With
        With ButtonCercaLiquido
            .Margin = New Padding(1, 0, 1, 0)
            .Dock = DockStyle.Fill
            .BackColor = Color.Lavender
            .ForeColor = Color.Black
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.SteelBlue
            .Image = Risorse.Immagini.Bitmap("cerca16")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Cerca in Liquido"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With ButtonCercaOM
            .Margin = New Padding(1, 0, 1, 0)
            .Dock = DockStyle.Fill
            .BackColor = Color.Lavender
            .ForeColor = Color.Black
            .DefaultBorderSize = 1
            .FlatAppearance.BorderColor = Color.SteelBlue
            .Image = Risorse.Immagini.Bitmap("cerca16")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Cerca in Omnia"
            .TextAlign = ContentAlignment.MiddleRight
        End With

        With CheckBoxEsatto
            .Text = "Corrispondenza esatta"
            .TextAlign = ContentAlignment.MiddleLeft
            .Checked = True
        End With

        With LabelSemaforoRicerca
            .Margin = New Padding(3, 0, 3, 0)
            .BackColor = Color.DodgerBlue
        End With
        With LabelSemaforoSelezione
            .Margin = New Padding(3, 0, 3, 0)
            .BackColor = Color.Orange
        End With

        'progress bar
        pbSinistri.Visible = False
        'messaggio di stato
        tssMessaggio.Text = ""

        ElencoSinistri_NoRow()

        'impostazioni iniziale query
        With Query
            .ChiaveRicerca = ""
            .CorrispondenzaEsatta = True
            .Chiusura = QuerySinistri.TipoChiusura.TUTTI
            .TipoElenco = QuerySinistri.DefaultElenco.SELEZIONE
        End With

        'imposta timer ricerca
        TimerCerca.Enabled = False
        If Utx.Globale.RitardoTimer > 0 Then
            TimerCerca.Interval = Utx.Globale.RitardoTimer
        End If
    End Sub

    Private Sub ImpostaChiaviRicerca()
        Try
            With ComboBoxCercaIn
                .BackColor = Color.Black
                .ForeColor = Color.Yellow
                .Font = New Font(ComboBoxCercaIn.Font.Name, ComboBoxCercaIn.Font.Size, FontStyle.Bold)
                .DropDownStyle = ComboBoxStyle.DropDown
                .Items.Clear()
                .Sorted = False
                .IntegralHeight = False
                .DropDownHeight = 200

                .Items.Add(New ItemRicerca("", QuerySinistri.CercaIn.NO_RICERCA))
                .Items.Add(New ItemRicerca("Assicurato", QuerySinistri.CercaIn.ASSICURATO))
                .Items.Add(New ItemRicerca("Controparte", QuerySinistri.CercaIn.CONTROPARTE))
                .Items.Add(New ItemRicerca("Targa assicurato", QuerySinistri.CercaIn.TARGA_ASSICURATO, DescrizioneBreve:="Targa ass."))
                .Items.Add(New ItemRicerca("Targa controparte", QuerySinistri.CercaIn.TARGA_CONTROPARTE, DescrizioneBreve:="Targa cont."))
                .Items.Add(New ItemRicerca("Codice fiscale assicurato", QuerySinistri.CercaIn.CF_ASSICURATO, DescrizioneBreve:="CF assic."))
                .Items.Add(New ItemRicerca("Numero sinistro", QuerySinistri.CercaIn.NUMERO_SINISTRO, DescrizioneBreve:="Num.Sinistro"))
                .Items.Add(New ItemRicerca("Data sinistro", QuerySinistri.CercaIn.DATA_SINISTRO))
                .Items.Add(New ItemRicerca("Note", QuerySinistri.CercaIn.NOTE_SINISTRO_CORPO))
                .Items.Add(New ItemRicerca("Note (redattore)", QuerySinistri.CercaIn.NOTE_SINISTRO_REDATTORE, DescrizioneBreve:="Red.nota"))

                .DisplayMember = "Descrizione"

                .SelectedIndex = 1
                .Text = ""
            End With

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ImpostaTipoTabella()
        Try
            With ComboBoxTipoTabella
                .ForeColor = Color.Red
                .DropDownStyle = ComboBoxStyle.DropDownList
                .Items.Clear()
                .Sorted = False

                .Items.Add(New ItemTipoTabella("1.DELEGA PROPRIA-100%", QuerySinistri.TipoTabella.SINISTRI_DELEGA_PROPRIA))
                .Items.Add(New ItemTipoTabella("2.DELEGA ALTRUI", QuerySinistri.TipoTabella.SINISTRI_DELEGA_ALTRUI))
                .Items.Add(New ItemTipoTabella("3.CAUTELATIVE-ALTRI", QuerySinistri.TipoTabella.SINISTRI_ALTRA_COMPAGNIA))
                .Items.Add(New ItemTipoTabella("4.DELEGA PROPRIA-100%-ALTRI (1+3)", QuerySinistri.TipoTabella.SINISTRI_DP_ALTRI))

                .DisplayMember = "Descrizione"

                .SelectedIndex = QuerySinistri.TipoTabella.SINISTRI_DELEGA_PROPRIA
            End With

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ImpostaTipoChiusura()
        Try
            With ComboBoxChiusura
                .ForeColor = Color.Blue
                .DropDownStyle = ComboBoxStyle.DropDownList
                .Items.Clear()
                .Sorted = False

                .Items.Add(New ItemTipoChiusura("TUTTI", QuerySinistri.TipoChiusura.TUTTI))
                .Items.Add(New ItemTipoChiusura("SINISTRI APERTI", QuerySinistri.TipoChiusura.APERTI))
                .Items.Add(New ItemTipoChiusura("SINISTRI CHIUSI", QuerySinistri.TipoChiusura.CHIUSI))

                .DisplayMember = "Descrizione"

                .SelectedIndex = 0
            End With

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub
#End Region

    Public Sub SinistriCliente(CodiceFiscale As String)
        ButtonReset.PerformClick()
        ComboBoxCercaIn.SelectedIndex = QuerySinistri.CercaIn.CF_ASSICURATO
        ComboBoxCercaIn.Text = CodiceFiscale
    End Sub

    Private Sub FormSinistri_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        mTipoChiusura = Utx.OggettoForm.ChiusuraForm.NORMALE
        Me.Text = String.Format("Gestione sinistri {0}", Utx.Globale.AgenziaRichiesta.CodiceAgenzia)

        If LoginLiquido.IsLogged = False AndAlso BwLogin.IsBusy = False Then
            BwLogin.RunWorkerAsync(LoginLiquido)
        End If
    End Sub

    Private Sub FormSinistri_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        LoginEssig = Nothing
    End Sub

    Private Sub FormSinistri_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ElencoSinistri.ImpostaLayoutPredefinito(ComboBoxLayout.Text)
        NoteSinistro.SalvaNota()
        TimerCerca.Dispose()

        If mTipoChiusura = Utx.OggettoForm.ChiusuraForm.HIDE Then
            Utx.OggettoForm.Close(Utx.OggettoForm.TipoForm.DOCUMENTI, FormDocumenti)
            Utx.OggettoForm.Close(Utx.OggettoForm.TipoForm.SINISTRI, Me)
            e.Cancel = True
        Else
            WbLiquido = Nothing
            Me.Enabled = False
            Do While BwLogin.IsBusy : Application.DoEvents() : Loop
            Utx.OggettoForm.Dispose(Utx.OggettoForm.TipoForm.SINISTRI)
        End If
    End Sub

    Private Async Sub FormSinistri_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim EnvironmentOptions As New CoreWebView2EnvironmentOptions With {.Language = "it-IT"}
        Dim Environment As CoreWebView2Environment = Await CoreWebView2Environment.CreateAsync(Nothing, Nothing, EnvironmentOptions)
        Await WebViewLiquido.EnsureCoreWebView2Async(Environment)

        Dim MyUri As New Uri("https://essig.unipolsai.it/essigSXCC/ClaimCenter.do")
        Utx.Autenticazione.SetWebView2Cookies(MyUri, WebViewLiquido.CoreWebView2.CookieManager) 'imposto i coockies

        WebViewLiquido.Source = MyUri 'navigo

        TabSinistri.ItemSize = New Size(TabSinistri.Width / 10 - 12, 25)
        RegolaCaratteriBrowser(0) 'con il valore salvato
        'creo il link alla tabella delega propria (default)
        Query.Tabella = QuerySinistri.TipoTabella.SINISTRI_DELEGA_PROPRIA
        'aggancio eventi
        AddHandler ComboBoxTipoTabella.SelectedIndexChanged, AddressOf ComboBoxTipoTabella_SelectedIndexChanged
        AddHandler ComboBoxChiusura.SelectedIndexChanged, AddressOf ComboBoxChiusura_SelectedIndexChanged
        AddHandler ComboBoxCercaIn.TextChanged, AddressOf ComboBoxCercaIn_TextChanged
        'aggancio la finestra di popup
        AddHandler WebViewLiquido.CoreWebView2.NewWindowRequested, AddressOf CoreWebView2_NewWindowRequested
    End Sub

    Private Sub FormSinistri_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        dgvSinistri.TopLeftHeaderCell.Value = "Totali per TAG"
        dgvSinistri.TopLeftHeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        TabSinistri.SelectedTab = TabPageElenco
        ElencoSinistri.Visible = True
        Query.Abilitata = True
        Me.Refresh()
    End Sub

    Public Sub AggiornaQuery()
        Try
            Me.Cursor = Cursors.WaitCursor

            RemoveHandler ElencoSinistri.RowChanged, AddressOf ElencoSinistri_RowChanged
            ElencoSinistri.FormFiltro.CancellaFiltri()
            ElencoSinistri.dgvSinistri.DataSource = Nothing
            TabSinistri.SelectedTab = TabPageElenco

            Dim CommandText As String = Query.CommandText

            If CommandText.Length = 0 Then
                SinistroCorrente = New Sinistro(ElencoSinistri.VistaCorrente.TipoVista, Query.NomeTabella) 'altrimenti resta in canna l'ultimo
                LabelNumeroSinistri.Text = "..."
            Else
                LabelNumeroSinistri.Text = "..."
                tssMessaggio.Text = "Lettura sinistri in corso..."

                Globale.Log.Info("richiesta")
                Dim RispostaWeb As ServiziOMW.Risposta = Utx.WsCommand.ExecuteNonQuery(CommandText)
                Globale.Log.Info("ricevuto")

                If RispostaWeb IsNot Nothing Then
                    ElencoSinistri.dgvSinistri.DataSource = RispostaWeb.DataTable
                End If

                If ElencoSinistri.dgvSinistri.Rows.Count = 0 Then
                    SinistroCorrente = New Sinistro(ElencoSinistri.VistaCorrente.TipoVista, Query.NomeTabella) 'altrimenti resta in canna l'ultimo
                Else
                    ElencoSinistri_RowChanged(ElencoSinistri.dgvSinistri.CurrentRow)
                End If
            End If
            Globale.Log.Info("finito")

            AddHandler ElencoSinistri.RowChanged, AddressOf ElencoSinistri_RowChanged

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
            tlpSinistri.Enabled = True
            tssMessaggio.Text = ""
        End Try
    End Sub

    Public Sub SelezionaSinistro(Compagnia As Integer, Agenzia As Integer, Esercizio As Integer, Numero As Long)
        Try
            Me.Cursor = Cursors.WaitCursor
            tlpSinistri.Enabled = False
            ComboBoxCercaIn.Text = ""

            RemoveHandler ElencoSinistri.RowChanged, AddressOf ElencoSinistri_RowChanged

            ElencoSinistri.dgvSinistri.DataSource = Nothing

            Dim Comando As String = String.Format(Query.CommandTextRicercaSinistro(Compagnia, Agenzia, Esercizio, Numero))
            ElencoSinistri.dgvSinistri.DataSource = Utx.WsCommand.ExecuteNonQuery(Comando).DataTable

            If ElencoSinistri.dgvSinistri.Rows.Count > 0 Then
                ElencoSinistri_RowChanged(ElencoSinistri.dgvSinistri.CurrentRow)
            End If

            AddHandler ElencoSinistri.RowChanged, AddressOf ElencoSinistri_RowChanged

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
            tlpSinistri.Enabled = True
        End Try
    End Sub

    Private Sub tssMessaggio_TextChanged(sender As Object, e As EventArgs) Handles tssMessaggio.TextChanged
        StatusStripSinistri.Refresh()
    End Sub

    Private Sub ElencoSinistri_RowChanged(ByRef Sinistro As DataGridViewRow)
        If Sinistro IsNot Nothing Then
            SinistroCorrente.NomeTabella = Query.NomeTabella
            SinistroCorrente.Dati = Sinistro.DataBoundItem.row

            If ElencoSinistri.VistaCorrente.TipoVista = Vista.ElencoViste.APERTI_CONTROPARTE Then
                With ElencoSinistri.dgvSinistri
                    For Each r As DataGridViewRow In .Rows
                        r.HeaderCell.Value = ""
                    Next
                    .CurrentRow.HeaderCell.Value = "Gestione"
                    .AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders)
                End With
            ElseIf ElencoSinistri.VistaCorrente.TipoVista = Vista.ElencoViste.NORMALE Then
                dgvSinistri.CurrentRow.HeaderCell.ToolTipText = "Vedi tag del sinistro"
                dgvSinistri.CurrentRow.HeaderCell.Value = "Tag"
            End If
        End If
    End Sub

    Private Sub ElencoSinistri_CercaCliente(CodiceFiscale As String) Handles ElencoSinistri.CercaCliente
        ComboBoxCercaIn.SelectedIndex = QuerySinistri.CercaIn.CF_ASSICURATO
        ComboBoxCercaIn.Text = CodiceFiscale
    End Sub

    Private Sub ElencoSinistri_EditCell(ByRef Dgv As DataGridView, ea As DataGridViewCellMouseEventArgs) Handles ElencoSinistri.EditCell
        Try
            If ea.ColumnIndex < 0 Then
                TabSinistri.SelectedTab = TabPageDettaglio
                Exit Sub
            End If

            Dim Tabella As String
            Select Case ComboBoxTipoTabella.SelectedIndex
                Case 0 : Tabella = "SinistriDP"
                Case 1 : Tabella = "SinistriDA"
                Case 2 : Tabella = "SinistriAC"
                Case Else
                    MsgBox("Per effetuare la modifica cambiare tipo di visualizzazione", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                    ComboBoxTipoTabella.DroppedDown = True
                    Exit Sub
            End Select

            Using f As New FormEditCell
                f.Dgv = Dgv
                f.ea = ea
                f.ShowDialog()

                Try
                    If f.DialogResult = Windows.Forms.DialogResult.OK Then
                        'aggiornare il db
                        Dim Query As String = String.Format("UPDATE {0} SET {1} = @0
                        WHERE Compagnia = @1 AND AgenziaSinistro = @2 AND EsercizioSinistro = @3 AND NumeroSinistro = @4",
                                                        Tabella, Dgv.Columns(ea.ColumnIndex).DataPropertyName)

                        Dim Parametri As String() = {f.TextBoxValore.Text.ToUpper.Trim,
                        Dgv.Rows(ea.RowIndex).Cells("Compagnia").Value,
                        Dgv.Rows(ea.RowIndex).Cells("AgenziaSinistro").Value,
                        Dgv.Rows(ea.RowIndex).Cells("EsercizioSinistro").Value,
                        Dgv.Rows(ea.RowIndex).Cells("NumeroSinistro").Value}

                        If Utx.WsCommand.ExecuteNonQueryRecord(Query, Parametri) > 0 Then
                            'aggionare la griglia
                            Dgv.Rows(ea.RowIndex).Cells(ea.ColumnIndex).Value = f.TextBoxValore.Text.ToUpper.Trim
                        End If
                    End If
                Catch ex As Exception
                    MsgBox(String.Format("Impossibile aggiornare il campo {0}", Dgv.Columns(ea.ColumnIndex).DataPropertyName), MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                End Try
            End Using
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ElencoSinistri_Errore(ex As Exception, Procedura As String) Handles ElencoSinistri.Errore
        Globale.Log.Info(String.Format("Errore in {0}", Procedura))
        Globale.Log.Errore(ex)
    End Sub

    Private Sub TimerCerca_Tick(sender As Object, e As EventArgs) Handles TimerCerca.Tick
        CercaSelezione()
    End Sub

    Private Sub CercaSelezione()
        Try
            'prima della ricerca fermo il timer e rimuovo l'evento
            RemoveHandler ComboBoxCercaIn.TextChanged, AddressOf ComboBoxCercaIn_TextChanged
            TimerCerca.Enabled = False

            If ComboBoxCercaIn.Text.Trim.Length > 0 Then
                Select Case Query.TipoRicerca
                    Case QuerySinistri.CercaIn.DATA_SINISTRO
                        'blocco ricerca se non è una data
                        If IsDate(ComboBoxCercaIn.Text) = False Then
                            Exit Try
                        End If

                        'se sto cercando per numero sinistro e NON è un numero cancello ed esco
                    Case QuerySinistri.CercaIn.NUMERO_SINISTRO
                        If IsNumeric(ComboBoxCercaIn.Text) = False Then
                            ComboBoxCercaIn.Text = ""
                            Exit Try
                        End If
                End Select
            End If

            Select Case Query.TipoRicerca
                Case QuerySinistri.CercaIn.ASSICURATO
                    ComboBoxCercaIn.Text = ComboBoxCercaIn.Text.Trim.Replace("'", "").Replace("""", "")
                Case QuerySinistri.CercaIn.NUMERO_SINISTRO
                    ComboBoxCercaIn.Text = Utx.NetFunc.EstraiCaratteri(ComboBoxCercaIn.Text, Utx.NetFunc.Funzioni.TipoCaratteri.SoloNumerici)
                Case QuerySinistri.CercaIn.DATA_SINISTRO
                    If IsDate(ComboBoxCercaIn.Text) = False Then
                        MsgBox("Data errata", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                        ComboBoxCercaIn.Text = ""
                        Exit Sub
                    End If
            End Select

            Query.ChiaveRicerca = ComboBoxCercaIn.Text

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            AddHandler ComboBoxCercaIn.TextChanged, AddressOf ComboBoxCercaIn_TextChanged
        End Try
    End Sub

    Private Sub CheckBoxEsatto_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxEsatto.CheckedChanged
        If CheckBoxEsatto.Checked = True Then
            CheckBoxEsatto.ForeColor = Drawing.SystemColors.ControlText
        Else
            CheckBoxEsatto.ForeColor = Color.Red
        End If
        Query.CorrispondenzaEsatta = CheckBoxEsatto.Checked
        ComboBoxCercaIn.Focus()
    End Sub

    Private Sub NavBar_ButtonClick(ButtonIndex As UtControls.ucNavigationBar.ButtonType) Handles NavBar.ButtonClick
        NavBar.AbilitaNavigazione(False)

        Select Case ButtonIndex

            Case UtControls.ucNavigationBar.ButtonType.CENTO,
                 UtControls.ucNavigationBar.ButtonType.PIU,
                 UtControls.ucNavigationBar.ButtonType.MENO

                If TabSinistri.SelectedTab Is TabPageElenco Then
                    ModificaCarattereGriglia(ButtonIndex)
                ElseIf TabSinistri.SelectedTab Is TabPageLiquido Then
                    RegolaCaratteriBrowser(ButtonIndex)
                End If

            Case Else
                NavigaRecord(ButtonIndex)
        End Select

        NavBar.AbilitaNavigazione(True)
    End Sub

    Private Sub NavigaRecord(ButtonIndex As UtControls.ucNavigationBar.ButtonType)
        If ElencoSinistri.dgvSinistri.DataSource IsNot Nothing Then

            Dim col As Integer = ElencoSinistri.dgvSinistri.CurrentCell.ColumnIndex

            Select Case ButtonIndex

                Case UtControls.ucNavigationBar.ButtonType.PRIMO
                    ElencoSinistri.dgvSinistri.CurrentCell = ElencoSinistri.dgvSinistri.Rows(0).Cells(col)

                Case UtControls.ucNavigationBar.ButtonType.ULTIMO
                    ElencoSinistri.dgvSinistri.CurrentCell =
                        ElencoSinistri.dgvSinistri.Rows(ElencoSinistri.dgvSinistri.Rows.Count - 1).Cells(col)

                Case UtControls.ucNavigationBar.ButtonType.PROSSIMO
                    If ElencoSinistri.dgvSinistri.CurrentRow.Index + 1 <= ElencoSinistri.dgvSinistri.Rows.Count - 1 Then
                        ElencoSinistri.dgvSinistri.CurrentCell =
                            ElencoSinistri.dgvSinistri.Rows(ElencoSinistri.dgvSinistri.CurrentRow.Index + 1).Cells(col)
                    End If

                Case UtControls.ucNavigationBar.ButtonType.PRECEDENTE
                    If ElencoSinistri.dgvSinistri.CurrentRow.Index - 1 >= 0 Then
                        ElencoSinistri.dgvSinistri.CurrentCell =
                            ElencoSinistri.dgvSinistri.Rows(ElencoSinistri.dgvSinistri.CurrentRow.Index - 1).Cells(col)
                    End If
            End Select
        End If
    End Sub

    Private Sub ModificaCarattereGriglia(ButtonIndex As UtControls.ucNavigationBar.ButtonType)
        If TabSinistri.SelectedTab Is TabPageElenco Then
            Select Case ButtonIndex
                Case UtControls.ucNavigationBar.ButtonType.PIU
                    ElencoSinistri.dgvSinistri.Font = New Font(ElencoSinistri.dgvSinistri.Font.Name,
                                                               Math.Min(20, ElencoSinistri.dgvSinistri.Font.Size + 1))

                Case UtControls.ucNavigationBar.ButtonType.MENO
                    ElencoSinistri.dgvSinistri.Font = New Font(ElencoSinistri.dgvSinistri.Font.Name,
                                                               Math.Max(6, ElencoSinistri.dgvSinistri.Font.Size - 1))

                Case UtControls.ucNavigationBar.ButtonType.CENTO
                    ElencoSinistri.dgvSinistri.Font = New Font(ElencoSinistri.dgvSinistri.Font.Name, 9)
            End Select
        End If
    End Sub

    Private Sub ButtonDocumenti_Click(sender As Object, e As EventArgs) Handles ButtonDocumenti.Click
        Try
            If EsisteSinistroCorrente() Then
                FormDocumenti = Utx.OggettoForm.Esiste(Utx.OggettoForm.TipoForm.DOCUMENTI)

                If FormDocumenti Is Nothing Then
                    FormDocumenti = New UnitoolsDocumenti.FormDocumenti
                End If
                UnitoolsDocumenti.FormDocumenti.LiquidoCookie = LoginLiquido.CookieContainer

                AddHandler FormDocumenti.ActivateDoc, AddressOf FormDocumenti_ActivateDoc
                AddHandler FormDocumenti.CloseDoc, AddressOf FormDocumenti_CloseDoc

                With FormDocumenti
                    .Reset()
                    .CodiceFiscale = SinistroCorrente.CfAssicurato
                    .NomeCliente = SinistroCorrente.Assicurato
                    .IdSinistro = SinistroCorrente.IdSinistro
                End With

                Utx.OggettoForm.Show(Utx.OggettoForm.TipoForm.DOCUMENTI)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonDocumentiLiquido_Click(sender As Object, e As EventArgs) Handles ButtonDocumentiLiquido.Click
        Try
            If EsisteSinistroCorrente() Then
                If String.IsNullOrEmpty(SinistroCorrente.CfAssicurato) = True Then
                    MsgBox("Per accedere ai documenti è necessario fornire un codice fiscale.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Else
                    Dim dp As New UnitoolsDocumenti.DepositoPratica(SinistroCorrente.CfAssicurato, SinistroCorrente.IdSinistro)

                    Using f As New UnitoolsDocumenti.FormDownloadLiquido
                        'parametri per l'operazione da eseguire (lista doc)
                        f.Operazione = UnitoolsDocumenti.Globale.TipoOperazioneLiquido.LISTALIQUIDO
                        f.IdSinistro = dp.Id
                        f.CartellaLocaleSinistro = dp.FullPathPratica

                        f.ShowDialog()
                    End Using
                End If
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub NoteSinistro_RichiestaConsap() Handles NoteSinistro.RichiestaConsap
        Try
            Select Case SinistroCorrente.RamoSinistro
                Case 30, 130, 230
                    'ok
                Case Else
                    MsgBox("Attenzione: non si tratta di un ramo sinistro 30", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            End Select

            If SinistroCorrente IsNot Nothing Then
                Using f As New Consap.FormAttivita
                    f.IdSinistro = SinistroCorrente.IdSinistro
                    f.CodiceFiscale = SinistroCorrente.CfAssicurato
                    f.Ramo = SinistroCorrente.RamoPolizza
                    f.Polizza = SinistroCorrente.Polizza
                    f.ShowDialog()
                End Using
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub NoteSinistro_StampaSinistro(StampaNote As Boolean) Handles NoteSinistro.StampaSinistro
        StampaSchedaSinistro(StampaNote)
    End Sub

    Private Sub NoteSinistro_TipoNotaChanged(Tipo As Utx.Nota.TipoNota) Handles NoteSinistro.TipoNotaChanged
        NoteSinistro.LeggiNote()
    End Sub

    Private Sub ComboBoxLayout_SelectedIndexChanged(sender As Object, e As EventArgs)
        ElencoSinistri.CaricaLayout(ComboBoxLayout.Text)
    End Sub

    Private Sub ButtonSomma_Click(sender As Object, e As EventArgs) Handles ButtonSomma.Click
        ElencoSinistri.RigaTotali = Not ElencoSinistri.RigaTotali
    End Sub

    Private Sub WebViewLiquido_NavigationCompleted(sender As Object, e As CoreWebView2NavigationCompletedEventArgs) Handles WebViewLiquido.NavigationCompleted
        Try
            If e.IsSuccess Then
                If RicercaSinistroLiquido.Attiva = True Then
                    ButtonCercaLiquido.PerformClick()
                    Exit Sub
                End If

                If TabSinistri.SelectedTab Is TabPageElenco Then
                    ComboBoxCercaIn.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub RegolaCaratteriBrowser(ButtonIndex As UtControls.ucNavigationBar.ButtonType)
        On Error Resume Next
        Dim zoom As Integer = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.ZOOM)

        'i numeri negativi producono strani effetti
        If zoom <= 0 Then
            zoom = 100
        End If

        Select Case ButtonIndex
            Case 0
                'valore letto
            Case UtControls.ucNavigationBar.ButtonType.CENTO
                zoom = 100
            Case UtControls.ucNavigationBar.ButtonType.MENO
                zoom -= 5
            Case UtControls.ucNavigationBar.ButtonType.PIU
                zoom += 5
        End Select

        WebViewLiquido.ZoomFactor = zoom / 100
        Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.ZOOM, zoom.ToString)
    End Sub

    Private Sub AddSinistro()
        Try
            EventoLiquido.WebView2 = WebViewLiquido

            'chiamo la pagina evento
            NavigaLiquido("Claim-MenuLinks-Claim_EventLocationGroup")

            'mi serve uno sleep in modo che la lettura della pagina evento che avviene nel form funzioni correttamente
            Threading.Thread.Sleep(1000)

            'apro il form per la compilazione del sinistro
            Using f As New FormEditSinistro
                f.ShowDialog()

                If f.DialogResult = Windows.Forms.DialogResult.OK Then
                    'imposto tabella e cambio link sinistri in dblink
                    ComboBoxTipoTabella.SelectedIndex = f.Evento.Tipo

                    'aggiungo il sinistro al db
                    If AggiungiSinistro(f.Evento) = True Then

                        If f.Evento.Tipo = QuerySinistri.TipoTabella.SINISTRI_DELEGA_PROPRIA Then
                            AggiungiNotaApertura(f.Evento)
                        End If

                        SelezionaSinistro(f.Evento.Compagnia, f.Evento.AgenziaSinistro, f.Evento.EsercizioSinistro, f.Evento.NumeroSinistro)
                        MsgBox("Il sinistro è stato aggiunto ed è selezionato.", vbInformation)
                    End If
                End If
            End Using
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Function AggiungiSinistro(ByRef Evento As EventoLiquido) As Boolean
        Try
            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery("SELECT * FROM SinistriDP WHERE 1=0").DataTable

            Dim dr As DataRow = dt.NewRow
            With Evento
                dr("AnnoMeseCompetenza") = Utx.FunzioniData.InizioAnno(Today)
                dr("Compagnia") = .Compagnia
                dr("AgenziaSinistro") = .AgenziaSinistro
                dr("EsercizioSinistro") = .EsercizioSinistro
                dr("NumeroSinistro") = .NumeroSinistro
                dr("Ispettorato") = .Ufficio
                dr("AgenziaPolizza") = Utx.Globale.AgenziaRichiesta.CodiceAgenzia
                dr("TargaAssicurato") = .Targa
                dr("RamoPolizza") = .Ramo
                dr("Polizza") = .Polizza
                dr("DataDenuncia") = Utx.FunzioniDb.Str2Data(.DataDenuncia)
                dr("DataSinistro") = Utx.FunzioniDb.Str2Data(.DataSinistro)
                dr("DataApertura") = Utx.FunzioniDb.Str2Data(.DataApertura)
                If IsDate(dr("DataApertura")) Then
                    dr("DataProtocollo") = Utx.FunzioniData.FineMese(.DataApertura)
                Else
                    dr("DataProtocollo") = DBNull.Value
                End If
                dr("CODICEFISCCONTRPOL") = .CF
                dr("CognomeAssicurato") = Microsoft.VisualBasic.Left(.Contraente, 20)
                dr("NomeAssicurato") = Microsoft.VisualBasic.Mid(.Contraente, 21, 10)
                dr("TipoChiusura") = ".." 'altrimenti il valore null può dare problemi
                dr("StatoTecnico") = ".."
                dr("StatoBilancistico") = ".."
                dr("Lira") = "N"
                dr("CodiceLiquidatore") = .CodiceLiquidatore
                dr("Convenzione") = "00000" 'fondamentale per evitare un errore nella decodifica del dettaglio

                If .Gestore <> "MIGUSER" Then
                    dr("IdGestione") = .Gestore
                End If
            End With

            dt.Rows.Add(dr)

            'aggiorno il db
            Select Case Evento.Tipo
                Case QuerySinistri.TipoTabella.SINISTRI_DELEGA_PROPRIA
                    Dim ds As New DataSet
                    ds.Tables.Add(dt)
                    dt.TableName = Utx.ServiziOMW.TipoEvento.IMPORTA_SINISTRI_WS.ToString
                    Utx.OmWeb.InviaDataSet(Utx.Globale.AgenziaRichiesta.CodiceAgenzia, ds)
                Case QuerySinistri.TipoTabella.SINISTRI_ALTRA_COMPAGNIA
                    Using s As New Utx.SinistriOMW.Sinistri
                        s.Proxy = Utx.Globale.UniProxy.Proxy
                        s.ImportaSinistriAC(Utx.Globale.AgenziaRichiesta.CodiceAgenzia, dt, Utx.Globale.Token)
                    End Using
            End Select

            Return True

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Private Sub AggiungiNotaApertura(ByRef Evento As EventoLiquido)
        Try
            'se è disponibile la descrizione
            If Evento.Descrizione IsNot Nothing Then
                'aggiungo nota al sinistro
                If Evento.Descrizione.Length > 0 Then

                    Dim Nota As New Utx.Nota
                    With Nota
                        .NuovaNota = True
                        .Utente = "Apertura"
                        .DataModifica = Now
                        .IdNota = String.Format("{0}-{1}-{2}-{3:0000000}",
                                                Evento.Compagnia,
                                                Evento.AgenziaSinistro,
                                                Evento.EsercizioSinistro,
                                                Evento.NumeroSinistro)
                        .CodiceFiscale = Evento.CF
                        .Tipo = Utx.Nota.TipoNota.NOTA
                        .Testo = Evento.NotaApertura

                        .SalvaNota()
                    End With
                End If
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ImportaSinistri()
        Try
            ButtonAddSinistro.Enabled = False

            'i sinistri importati sono sempre in delega propria DP
            ButtonReset.PerformClick()
            Application.DoEvents()

            FormImportaSinistri = New FormImportaSinistri
            FormImportaSinistri.ShowDialog()

            If FormImportaSinistri.DialogResult = Windows.Forms.DialogResult.OK Then
                Dim sin() As String = FormImportaSinistri.SinistroSelezionato.Split("-")
                SelezionaSinistro(sin(0), sin(1), sin(2), sin(3))
            ElseIf FormImportaSinistri.DialogResult = Windows.Forms.DialogResult.Retry Then
                'vecchio sistema
                AddSinistro()
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            ButtonAddSinistro.Enabled = True
        End Try
    End Sub

    Private Sub CancellaSinistro()
        Try
            If ElencoSinistri.dgvSinistri.CurrentRow Is Nothing Then
                Exit Sub
            End If

            If MsgBox(String.Format("Confermate la cancellazione del sinistro {0}", SinistroCorrente.IdSinistro),
                      MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then

                Dim Sql As String = "DELETE FROM {0}
                    WHERE Compagnia = {1} AND AgenziaSinistro = {2} AND EsercizioSinistro = {3} AND NumeroSinistro = {4}"

                With ElencoSinistri.dgvSinistri.CurrentRow
                    Sql = String.Format(Sql, Query.NomeTabella, .Cells("Compagnia").Value, .Cells("AgenziaSinistro").Value,
                                        .Cells("EsercizioSinistro").Value, .Cells("NumeroSinistro").Value)
                    Utx.WsCommand.ExecuteNonQueryRecord(Sql)
                End With
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonAddSinistro_ButtonClick(sender As Object, e As EventArgs) Handles ButtonAddSinistro.ButtonClick
        ImportaSinistri()
    End Sub

    Private Sub MenuItemCancellaSinistro_Click(sender As Object, e As EventArgs) Handles MenuItemCancellaSinistro.Click
        CancellaSinistro()
        AggiornaQuery()
    End Sub

    Private Sub MenuItemCatturaEvento_Click(sender As Object, e As EventArgs) Handles MenuItemCatturaEvento.Click
        AddSinistro()
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        mTipoChiusura = Utx.OggettoForm.ChiusuraForm.HIDE
        Me.Close()
    End Sub

    Private Sub ButtonViste_Click(sender As Object, e As EventArgs) Handles ButtonViste.Click
        'seleziono tab elenco
        TabSinistri.SelectedTab = TabPageElenco
        'resetto i filtri
        ButtonReset.PerformClick()
        'blocco controlli di flitro
        AbilitazioneControlliFiltro(False)
        'attivo il menù viste
        ElencoSinistri.MenuViste = True
        ElencoSinistri.dgvSinistri.Columns.Clear()
        'il tipo di vista si attiva poi a seconda del bottone scelto
        If Vista.Persistenza.Tipo <> Vista.ElencoViste.NESSUNA Then
            ElencoSinistri.VistaCorrente.TipoVista = Vista.Persistenza.Tipo
            ElencoSinistri.dgvSinistri.DataSource = Vista.Persistenza.DataSource
            ElencoSinistri.FormFiltro = Vista.Persistenza.FiltroCorrente
        Else
            ElencoSinistri.VistaCorrente.TipoVista = Vista.ElencoViste.NESSUNA
        End If
    End Sub

#Region "Eventi Combo ricerche"
    Private Sub ComboBoxCercaIn_TextChanged(sender As Object, e As EventArgs)
        Try
            If ComboBoxCercaIn.Text.Trim.Length = 0 Then
                'aggiorno subito
                CercaSelezione()
            Else
                TimerCerca.Enabled = False
                TimerCerca.Enabled = (Utx.Globale.RitardoTimer > 0)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ComboBoxCercaIn_DropDown(sender As Object, e As EventArgs) Handles ComboBoxCercaIn.DropDown
        With ComboBoxCercaIn
            .Items.RemoveAt(0)
            .BackColor = Color.LightYellow
            .ForeColor = Color.Black
            .Font = New Font(ComboBoxCercaIn.Font.Name, ComboBoxCercaIn.Font.Size, FontStyle.Regular)
        End With
    End Sub

    Private Sub ComboBoxCercaIn_DropDownClosed(sender As Object, e As EventArgs) Handles ComboBoxCercaIn.DropDownClosed
        With ComboBoxCercaIn
            .Items.Insert(0, New ItemRicerca("", QuerySinistri.CercaIn.ASSICURATO, ""))
            .BackColor = Color.Black
            .ForeColor = Color.Yellow
            .Font = New Font(ComboBoxCercaIn.Font.Name, ComboBoxCercaIn.Font.Size, FontStyle.Bold)
        End With
    End Sub

    Private Sub ComboBoxCercaIn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBoxCercaIn.KeyPress
        Try
            If Asc(e.KeyChar) = Keys.Enter Then
                e.Handled = True
                CercaSelezione()
                Exit Try
            End If

            'controllo numeri per ricerca su numero sinistri
            If ComboBoxCercaIn.SelectedIndex = QuerySinistri.CercaIn.NUMERO_SINISTRO Then
                Select Case Asc(e.KeyChar)
                    Case 48 To 57, 8
                        'numeri e backspace non fare niente
                    Case Else
                        e.KeyChar = ""
                End Select

            ElseIf ComboBoxCercaIn.SelectedIndex = QuerySinistri.CercaIn.DATA_SINISTRO Then
                Select Case Asc(e.KeyChar)
                    Case 48 To 57, 47, 8
                        'numeri,backspace e /
                    Case Else
                        e.KeyChar = ""
                End Select
            Else
                Select Case Asc(e.KeyChar)
                    Case 8, 32, 39, 46 To 57, 64 To 90, 97 To 122
                        'backspace,spazio,',/,.,numeri per le date,numeri,@,lettere
                        e.KeyChar = e.KeyChar.ToString.ToUpper()
                    Case Else
                        e.KeyChar = ""
                End Select
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ComboBoxCercaIn_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBoxCercaIn.KeyDown
        Try
            'il controllo viene fatto solo sul primo carattere quando text non è stato ancora modificato
            If ComboBoxCercaIn.Text.Length = 0 OrElse
               (ComboBoxCercaIn.SelectionLength = ComboBoxCercaIn.Text.Length) Then

                Select Case Query.TipoRicerca

                    Case QuerySinistri.CercaIn.NUMERO_SINISTRO
                        'attiva la ricerca per assicurato se viene battuta una lettera e siamo su ricerca per numero
                        If Utx.NetFunc.InIntervallo(e.KeyCode, 65, 90) Then
                            ComboBoxCercaIn.SelectedIndex = QuerySinistri.CercaIn.ASSICURATO
                        End If

                    Case QuerySinistri.CercaIn.ASSICURATO, QuerySinistri.CercaIn.CF_ASSICURATO
                        'attiva la ricerca per numero sinistro se il numero viene battuto sul tastierino numerico
                        If Utx.NetFunc.InIntervallo(e.KeyCode, 96, 105) Then
                            ComboBoxCercaIn.SelectedIndex = QuerySinistri.CercaIn.NUMERO_SINISTRO
                        End If
                End Select
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ComboBoxCercaIn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxCercaIn.SelectedIndexChanged
        If ComboBoxCercaIn.SelectedIndex > 0 Then
            LabelCerca.Text = ComboBoxCercaIn.SelectedItem.DescrizioneBreve
            Query.TipoRicerca = ComboBoxCercaIn.SelectedItem.TipoRicerca
            ComboBoxCercaIn.SelectedIndex = 0
        End If
    End Sub
#End Region

    Private Sub Sopravvenienze()
        Try
            Me.Cursor = Cursors.WaitCursor
            tlpSinistri.Enabled = False

            RemoveHandler ElencoSinistri.RowChanged, AddressOf ElencoSinistri_RowChanged

            ElencoSinistri.dgvSinistri.DataSource = Nothing

            Dim CommandText As String = Query.CommandTextSopravvenienze

            If CommandText.Length = 0 Then
                ElencoSinistri.dgvSinistri.DataSource = Nothing
                LabelNumeroSinistri.Text = "..."
            Else
                LabelNumeroSinistri.Text = "..."
                tssMessaggio.Text = "Lettura sopravvenienze in corso..."

                ElencoSinistri.dgvSinistri.DataSource = Utx.WsCommand.ExecuteNonQuery(CommandText).DataTable

                If ElencoSinistri.dgvSinistri.Rows.Count > 0 Then
                    ElencoSinistri_RowChanged(ElencoSinistri.dgvSinistri.CurrentRow)
                End If
            End If

            AddHandler ElencoSinistri.RowChanged, AddressOf ElencoSinistri_RowChanged

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
            tlpSinistri.Enabled = True
            tssMessaggio.Text = ""
        End Try
    End Sub

    Private Sub Perizie()
        Try
            Me.Cursor = Cursors.WaitCursor
            tlpSinistri.Enabled = False

            RemoveHandler ElencoSinistri.RowChanged, AddressOf ElencoSinistri_RowChanged

            ElencoSinistri.dgvSinistri.DataSource = Nothing

            Dim CommandText As String = Query.CommandTextPerizie

            If CommandText.Length = 0 Then
                ElencoSinistri.dgvSinistri.DataSource = Nothing
                LabelNumeroSinistri.Text = "..."
            Else
                LabelNumeroSinistri.Text = "..."
                tssMessaggio.Text = "Lettura incarichi in corso..."

                ElencoSinistri.dgvSinistri.DataSource = Utx.WsCommand.ExecuteNonQuery(CommandText).DataTable

                If ElencoSinistri.dgvSinistri.Rows.Count > 0 Then
                    ElencoSinistri_RowChanged(ElencoSinistri.dgvSinistri.CurrentRow)
                End If
            End If

            AddHandler ElencoSinistri.RowChanged, AddressOf ElencoSinistri_RowChanged

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
            tlpSinistri.Enabled = True
            tssMessaggio.Text = ""
        End Try
    End Sub

    Private Sub IndicatoreCliente()
        Try
            If Vista.Persistenza.Tipo = Vista.ElencoViste.INDICATORE_CLIENTE Then
                ElencoSinistri.dgvSinistri.DataSource = Vista.Persistenza.DataSource
                Exit Sub
            End If

            Dim Convenzione As String = InputBox("Convenzione (0 = TUTTE)", "Indicatore cliente", "0")
            If String.IsNullOrEmpty(Convenzione) Then
                Exit Sub
            ElseIf IsNumeric(Convenzione) = False Then
                MsgBox("Codice convenzione non valido", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor
            tlpSinistri.Enabled = False

            RemoveHandler ElencoSinistri.RowChanged, AddressOf ElencoSinistri_RowChanged

            ElencoSinistri.dgvSinistri.DataSource = Nothing

            LabelNumeroSinistri.Text = "..."
            tssMessaggio.Text = "Lettura in corso..."

            Dim Inizio As Integer = Utx.WsCommand.ExecuteScalar("SELECT Min(Year(AnnoMeseCompetenza)) FROM SinistriDP", ValoreDefault:=2010).Valore
            Inizio = Math.Max(Inizio, Utx.WsCommand.ExecuteScalar("SELECT Min(Year(DataFoglioCassa)) FROM Incassi").Valore)

            ElencoSinistri.LabelDesk.Text = String.Format("Indicatori sinistri per cliente {0}-{1}", Inizio, Today.Year)

            Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteNonQueryStored("IndicatoreCliente", {Inizio, Convenzione})
            If Risposta.Errore = True Then
                Exit Sub
            End If

            Dim dt As DataTable = Risposta.DataTable
            'calcolo percentuali
            For Each dr As DataRow In dt.Rows
                'auto
                If dr("PremiStoriciAuto") > 0 Then
                    dr("PercAuto") = dr("SinistriStoriciAuto") / dr("PremiStoriciAuto") * 100
                End If
                'RE
                If dr("PremiStoriciRE") > 0 Then
                    dr("PercRE") = dr("SinistriStoriciRe") / dr("PremiStoriciRe") * 100
                End If
                'totale
                If dr("PremiStoriciTotali") > 0 Then
                    dr("PercTotale") = dr("SinistriStoriciTotali") / dr("PremiStoriciTotali") * 100
                End If
            Next

            ElencoSinistri.dgvSinistri.DataSource = dt

            If ElencoSinistri.dgvSinistri.Rows.Count > 0 Then
                ElencoSinistri_RowChanged(ElencoSinistri.dgvSinistri.CurrentRow)
            End If

            AddHandler ElencoSinistri.RowChanged, AddressOf ElencoSinistri_RowChanged

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
            tlpSinistri.Enabled = True
            tssMessaggio.Text = ""
        End Try
    End Sub

    Private Sub SinistriControparte()
        'Try
        '    Me.Cursor = Cursors.WaitCursor
        '    tlpSinistri.Enabled = False

        '    RemoveHandler ElencoSinistri.RowChanged, AddressOf ElencoSinistri_RowChanged

        '    ElencoSinistri.dgvSinistri.DataSource = Nothing

        '    LabelNumeroSinistri.Text = "..."
        '    tssMessaggio.Text = "Lettura in corso..."

        '    ElencoSinistri.LabelDesk.Text = "Sinistri aperti da controparte"

        '    Using cmd As New OleDbCommand
        '        cmd.CommandType = CommandType.StoredProcedure
        '        cmd.CommandText = "ListaSinistriControparte"

        '        ElencoSinistri.dgvSinistri.DataSource = Utx.FunzioniDb.CreaDataTable(cmd)
        '    End Using

        '    If ElencoSinistri.dgvSinistri.Rows.Count > 0 Then
        '        ElencoSinistri_RowChanged(ElencoSinistri.dgvSinistri.CurrentRow)
        '    End If

        '    AddHandler ElencoSinistri.RowChanged, AddressOf ElencoSinistri_RowChanged

        'Catch ex As Exception
        '    Globale.Log.Errore(ex)
        'Finally
        '    Me.Cursor = Cursors.Default
        '    tlpSinistri.Enabled = True
        '    tssMessaggio.Text = ""
        'End Try
    End Sub

    Private Sub ElencoSinistri_AfterVistaChanged(TipoVista As Vista.ElencoViste) Handles ElencoSinistri.AfterVistaChange
        RemoveHandler ComboBoxLayout.SelectedIndexChanged, AddressOf ComboBoxLayout_SelectedIndexChanged

        ComboBoxLayout.DataSource = Nothing

        AddHandler ComboBoxLayout.SelectedIndexChanged, AddressOf ComboBoxLayout_SelectedIndexChanged
        SinistroCorrente.VistaAssociata = TipoVista
        ElencoSinistri.FormFiltro.CancellaFiltri()

        Select Case TipoVista
            Case Vista.ElencoViste.NESSUNA
                'non fare niente
            Case Vista.ElencoViste.NORMALE
                'qui viene caricato il layout predefinito fra quelli associati alla vista
                ComboBoxLayout.DataSource = ElencoSinistri.ListaLayout
            Case Vista.ElencoViste.SOPRAVVENIENZE
                ComboBoxLayout.DataSource = ElencoSinistri.ListaLayout
                Sopravvenienze()
            Case Vista.ElencoViste.PERIZIE
                ComboBoxLayout.DataSource = ElencoSinistri.ListaLayout
                Perizie()
            Case Vista.ElencoViste.INDICATORE_CLIENTE
                ComboBoxLayout.DataSource = ElencoSinistri.ListaLayout
                IndicatoreCliente()
            Case Vista.ElencoViste.APERTI_CONTROPARTE
                ComboBoxLayout.DataSource = ElencoSinistri.ListaLayout
                SinistriControparte()
            Case Vista.ElencoViste.VARIAZIONE_COSTI_MESE_ANNO
                ComboBoxLayout.DataSource = ElencoSinistri.ListaLayout
                VariazioniCostoMeseAnno()
        End Select
    End Sub

    Private Sub ElencoSinistri_MenuVistaChange(MenuAttivo As Boolean) Handles ElencoSinistri.MenuVistaChange
        ElencoSinistri.dgvSinistri.DataSource = Nothing
    End Sub

    Private Sub ButtonEsportaCsv_Click(sender As Object, e As EventArgs) Handles ButtonEsportaCsv.Click
        If ElencoSinistri.dgvSinistri.Rows.Count > 0 Then
            Utx.NetFunc.Esporta2Csv(ElencoSinistri.dgvSinistri, "Sinistri", Color.Khaki)
        End If
    End Sub

    Private Sub TabSinistri_Deselected(sender As Object, e As TabControlEventArgs) Handles TabSinistri.Deselected
        If e.TabPage Is TabPageNote Then
            NoteSinistro.SalvaNota()
        End If
    End Sub

    Private Sub TabSinistri_Selected(sender As Object, e As TabControlEventArgs) Handles TabSinistri.Selected
        Cursor = Cursors.WaitCursor

        e.TabPage.Refresh()

        Select Case e.TabPage.Name
            Case TabPageElenco.Name
                NavBar.AbilitaZoom = True
                ComboBoxCercaIn.Focus()

            Case TabPageDettaglio.Name
                NavBar.AbilitaZoom = False
                'DettaglioSinistro.SinistroCorrente = SinistroCorrente
                'DettaglioSinistro.VisualizzaDettaglio()

            Case TabPageNote.Name
                NavBar.AbilitaZoom = False
                NoteSinistro.LeggiNote()
                LeggiDocumenti()

            Case TabPageAndamento.Name
                NavBar.AbilitaZoom = False
                AndamentoSinistro.Sinistro = SinistroCorrente
                AndamentoSinistro.LeggiAndamento()

            Case TabPageLiquido.Name
                TabSinistri.Refresh()
                TabPageLiquido.Refresh()
                WbLiquido.Refresh()
                NavBar.AbilitaZoom = True
        End Select
        Cursor = Cursors.Default
    End Sub

    Private Sub TabSinistri_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles TabSinistri.Selecting
        Select Case e.TabPage.Name
            Case TabPageDettaglio.Name, TabPageNote.Name, TabPageAndamento.Name
                If EsisteSinistroCorrente() = False Then
                    e.Cancel = True
                ElseIf ElencoSinistri.VistaCorrente.TipoVista = Vista.ElencoViste.INDICATORE_CLIENTE Then
                    Call New Utx.NotificaRapida().Visualizza("Nessun sinistro selezionato")
                    e.Cancel = True
                End If
        End Select
    End Sub

    Private Sub ButtonUeba_Click(sender As Object, e As EventArgs) Handles ButtonUeba.Click
        Dim Pagina As UtControls.Ueba = UtControls.Ueba.PaginaUeba(TabSinistri)

        If Pagina Is Nothing Then

            TabPageUeba = New UtControls.Ueba
            TabPageUeba.Text = String.Format("Ueba")

            TabSinistri.Controls.Add(TabPageUeba)
            TabSinistri.SelectedTab = TabPageUeba

            If TabPageUeba.EsistePaginaWeb = False Then
                If LoginUniage.IsLogged Then
                    TabPageUeba.Naviga(LoginUniage.LoggedUrl)
                Else
                    tssMessaggio.Text = "Login a uniage..."

                    LoginUniage.LogIn()

                    Select Case LoginUniage.Stato
                        Case Utx.Autenticazione.StatoLogin.LOGIN
                            tssMessaggio.Text = ""
                            TabPageUeba.Naviga(LoginUniage.LoggedUrl)
                        Case Utx.Autenticazione.StatoLogin.RETE_NON_DISPONIBILE
                            tssMessaggio.Text = "Ueba non raggiungibile"
                        Case Else
                            tssMessaggio.Text = "Login a uniage fallito"
                            TabPageUeba.Naviga(LoginEssig.LoggedUrl)
                    End Select
                End If
            End If
        Else
            TabSinistri.SelectedTab = Pagina
        End If
    End Sub

    Private Sub ButtonEssig_Click(sender As Object, e As EventArgs) Handles ButtonEssig.Click
        Dim NumeroPagine As Integer = UtControls.Essig.NumeroPagineEssig(TabSinistri)

        If NumeroPagine < 1 Then

            TabPageEssig = New UtControls.Essig
            TabPageEssig.Text = String.Format("Essig", NumeroPagine + 1)

            TabSinistri.Controls.Add(TabPageEssig)
            TabSinistri.SelectedTab = TabPageEssig

            If TabPageEssig.EsistePaginaWeb = False Then

                If LoginEssig.IsLogged Then
                    TabPageEssig.Naviga(LoginEssig.LoggedUrl)
                Else
                    tssMessaggio.Text = "Login a Essig..."

                    LoginEssig.LogIn()

                    Select Case LoginEssig.Stato
                        Case Utx.Autenticazione.StatoLogin.LOGIN
                            tssMessaggio.Text = ""
                            TabPageEssig.Naviga(LoginEssig.LoggedUrl)
                        Case Utx.Autenticazione.StatoLogin.RETE_NON_DISPONIBILE
                            tssMessaggio.Text = "Essig non raggiungibile"
                        Case Else
                            tssMessaggio.Text = "Login a Essig fallito"
                            TabPageEssig.Naviga(LoginEssig.LoggedUrl)
                    End Select
                End If
            End If
        Else
            TabSinistri.SelectedTab = TabPageEssig
        End If
    End Sub

    Private Sub ButtonSelezionaEsercizi_Click(sender As Object, e As EventArgs) Handles ButtonSelezionaEsercizi.Click
        Dim p As Point = PointToScreen(New Point(ButtonSelezionaEsercizi.Left,
                                                 ButtonSelezionaEsercizi.Top + ButtonSelezionaEsercizi.Height))

        Using f As New FormEsercizi(p)
            f.BackColor = ColoreEsercizio
            f.Esercizi = Query.ListaEsercizi
            f.Mesi = Query.ListaMesi

            f.ShowDialog()

            If f.DialogResult = Windows.Forms.DialogResult.OK Then
                Query.ImpostaEserciziMesi(f.Esercizi, f.Mesi)
            End If
        End Using
    End Sub

    Private Sub ComboBoxTipoTabella_SelectedIndexChanged(sender As Object, e As EventArgs)
        TabSinistri.SelectedTab = TabPageElenco
        ElencoSinistri.Focus()
        Query.Tabella = ComboBoxTipoTabella.SelectedItem.Tipo
    End Sub

    Private Sub ComboBoxChiusura_SelectedIndexChanged(sender As Object, e As EventArgs)
        TabSinistri.SelectedTab = TabPageElenco
        ElencoSinistri.Focus()
        Query.Chiusura = ComboBoxChiusura.SelectedItem.Tipo
    End Sub

    Private Sub CheckBoxElencoCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxElencoCompleto.CheckedChanged
        CheckBoxElencoCompleto.Refresh()
        'trasmetto l'informazione alla query
        If CheckBoxElencoCompleto.Checked = True Then
            Query.TipoElenco = QuerySinistri.DefaultElenco.COMPLETO
        Else
            Query.TipoElenco = QuerySinistri.DefaultElenco.SELEZIONE
        End If
    End Sub

    Private Sub LabelNumeroSinistri_TextChanged(sender As Object, e As EventArgs) Handles LabelNumeroSinistri.TextChanged
        LabelNumeroSinistri.Refresh()
    End Sub

    Private Sub SinistroCorrente_SinistroChanged() Handles SinistroCorrente.SinistroChanged
        Try
            If ElencoSinistri.VistaCorrente.TipoVista = Vista.ElencoViste.NORMALE Then
                DettaglioSinistro.SinistroCorrente = SinistroCorrente

                'in questo thread preparo la scheda dettaglio del sinistro
                ThreadDecodifiche = New Threading.Thread(Sub()
                                                             SinistroCorrente.Decodifica.LeggiDecodifiche()
                                                             DettaglioSinistro.VisualizzaDettaglio()
                                                         End Sub) With {.Priority = Threading.ThreadPriority.BelowNormal}
                ThreadDecodifiche.Start()
            End If

            NoteSinistro.IdNote = SinistroCorrente.IdSinistro
            NoteSinistro.CF = SinistroCorrente.CfAssicurato

            LabelNumeroSinistro.Text = SinistroCorrente.IdSinistro
            LabelAssicurato.Text = SinistroCorrente.Assicurato
            LabelValore.Text = SinistroCorrente.Valore
            LabelChiusura.Text = SinistroCorrente.DeskChiusura

            LabelNumeroSinistri.Text = String.Format("{0} di {1}",
                                                     ElencoSinistri.dgvSinistri.CurrentRow.Index + 1,
                                                     ElencoSinistri.dgvSinistri.Rows.Count)

            Select Case TabSinistri.SelectedTab.Name
                'Case TabPageDettaglio.Name
                    'DettaglioSinistro.SinistroCorrente = SinistroCorrente
                    'DettaglioSinistro.VisualizzaDettaglio()

                Case TabPageNote.Name
                    LeggiDocumenti()
                    NoteSinistro.LeggiNote()

                Case TabPageAndamento.Name
                    AndamentoSinistro.LeggiAndamento()
            End Select

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ElencoSinistri_NoRow() Handles ElencoSinistri.NoRow
        SinistroCorrente = New Sinistro(ElencoSinistri.VistaCorrente.TipoVista, Query.NomeTabella) 'altrimenti resta in canna l'ultimo
        LabelNumeroSinistro.Text = "..."
        LabelAssicurato.Text = "..."
        LabelValore.Text = "..."
        LabelChiusura.Text = "..."
        LabelNumeroSinistri.Text = "..."
    End Sub

    Private Sub ButtonAnag_Click(sender As Object, e As EventArgs) Handles ButtonAnag.Click
        RaiseEvent RichiestaAnagrafiche()
    End Sub

    Private Sub ButtonAnagCliente_Click(sender As Object, e As EventArgs) Handles ButtonAnagCliente.Click
        If EsisteSinistroCorrente() Then
            RaiseEvent RichiestaCliente(SinistroCorrente.CfAssicurato)
        End If
    End Sub

    Private Sub ComboBoxCercaIn_GotFocus(sender As Object, e As EventArgs) Handles ComboBoxCercaIn.GotFocus
        ComboBoxCercaIn.SelectionStart = ComboBoxCercaIn.Text.Length
        ComboBoxCercaIn.SelectionLength = 0
    End Sub

    Private Sub Query_EserciziChanged() Handles Query.EserciziChanged
        If Query.ListaEsercizi.Count = 0 AndAlso Query.ListaMesi.Count = 0 Then
            'tutti gli esercizi/mesi
            With ButtonSelezionaEsercizi
                .BackColor = ColoreEsercizio
                .ForeColor = Color.White
                .Text = "Esercizi (tutti)"
                .Refresh()
            End With
        Else
            'solo alcuni esercizi e/o mesi
            With ButtonSelezionaEsercizi
                .BackColor = Color.Gainsboro
                .ForeColor = Color.Black
                'fino a 2 esercizi li visualizzo sul tasto
                If Query.ListaEsercizi.Count = 0 Then
                    .Text = "Esercizi (tutti)"
                ElseIf Query.ListaEsercizi.Count < 3 Then
                    .Text = String.Format("Esercizi ({0})", Query.ListaEserciziStringa)
                Else
                    .Text = String.Format("Esercizi ({0})", Query.ListaEsercizi.Count)
                End If
                'setto tooltip con l'elenco degli esercizi selezionati
                Dim tt As New ToolTip
                tt.IsBalloon = True
                tt.SetToolTip(ButtonSelezionaEsercizi, Query.ListaEserciziStringa)

                .Refresh()
            End With
        End If
    End Sub

    Private Sub Query_QueryChanged() Handles Query.QueryChanged
        AggiornaQuery()
    End Sub

    Private Sub LabelChiusura_TextChanged(sender As Object, e As EventArgs) Handles LabelChiusura.TextChanged
        Select Case LabelChiusura.Text
            Case "LT - LT"
                LabelChiusura.BackColor = Color.PaleGreen
            Case "SS - SS"
                LabelChiusura.BackColor = Color.WhiteSmoke
            Case Else
                LabelChiusura.BackColor = Color.LightSalmon
        End Select
    End Sub

    Private Sub ButtonCercaLiquido_Click(sender As Object, e As EventArgs) Handles ButtonCercaLiquido.Click
        Try
            If SinistroCorrente.Dati IsNot Nothing Then

                If TabSinistri.SelectedTab IsNot TabPageLiquido Then
                    TabSinistri.SelectedTab = TabPageLiquido
                End If

                WebViewLiquido.Focus()

                RicercaSinistroLiquido.Attiva = True
                RicercaSinistroLiquido.RicercaCompletata = False
                RicercaSinistroLiquido.Wv = WebViewLiquido
                RicercaSinistroLiquido.CercaWV2(SinistroCorrente)

                'Do While RicercaSinistroLiquido.RicercaCompletata = False
                '    Application.DoEvents()
                'Loop

                'If LoginLiquido.IsLogged AndAlso WvLiquido.IsReady Then
                '    'cerca
                '    If TabSinistri.SelectedTab IsNot TabPageLiquido Then
                '        TabSinistri.SelectedTab = TabPageLiquido

                '    End If
                '    'TabSinistri.SelectedTab = TabPageLiquido
                '    'TabSinistri.Refresh()

                '    RicercaSinistroLiquido.CercaWV2(SinistroCorrente)
                '    'RicercaSinistroLiquido.Cerca(WvLiquido, SinistroCorrente)
                'Else
                '    'innesca il login
                '    'TabSinistri.SelectedTab = TabPageLiquido
                'End If
            Else
                MsgBox("Selezionare prima un sinistro in OmniaManager", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub ButtonReset_Click(sender As Object, e As EventArgs) Handles ButtonReset.Click
        Try
            Dim AbilitazioneQuery As Boolean = Query.Abilitata

            CheckBoxElencoCompleto.Checked = False
            ComboBoxCercaIn.Text = ""
            ComboBoxCercaIn.SelectedIndex = QuerySinistri.CercaIn.ASSICURATO
            CheckBoxEsatto.Checked = True
            ComboBoxTipoTabella.SelectedIndex = QuerySinistri.TipoTabella.SINISTRI_DELEGA_PROPRIA
            ComboBoxChiusura.SelectedIndex = QuerySinistri.TipoChiusura.TUTTI
            Query.ResetEsercizi()

            Query.Abilitata = AbilitazioneQuery
            ElencoSinistri.dgvSinistri.DataSource = Nothing
            Me.Text = String.Format("Gestione sinistri {0}", Utx.Globale.AgenziaRichiesta.CodiceAgenzia)

            ComboBoxCercaIn.Focus()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ElencoSinistri_VistaClose() Handles ElencoSinistri.VistaClose
        'disattivo il menù viste
        ElencoSinistri.MenuViste = False
        'attivo controlli
        AbilitazioneControlliFiltro(True)
        'ritorno alla vista normale
        ElencoSinistri.VistaCorrente.TipoVista = Vista.ElencoViste.NORMALE
        ElencoSinistri_NoRow() 'reset numero sinistro e altro
        'focus
        ComboBoxCercaIn.Focus()
    End Sub

    Private Sub ButtonLayout_Click(sender As Object, e As EventArgs) Handles ButtonLayout.Click
        ElencoSinistri.ImpostaLayout()
    End Sub

    Private Sub ElencoSinistri_SalvatoLayout(NomeLayout As String) Handles ElencoSinistri.SalvatoLayout
        'se è cambiato il layout
        If ComboBoxLayout.Text <> NomeLayout Then
            'ricarica layout nel combo e applica il predefinito
            RemoveHandler ComboBoxLayout.SelectedIndexChanged, AddressOf ComboBoxLayout_SelectedIndexChanged
            ComboBoxLayout.DataSource = Nothing

            AddHandler ComboBoxLayout.SelectedIndexChanged, AddressOf ComboBoxLayout_SelectedIndexChanged
            ComboBoxLayout.DataSource = ElencoSinistri.AggiornaListaLayout
            ComboBoxLayout.SelectedIndex = 0
        End If
    End Sub

    Private Sub ElencoSinistri_EliminatoLayout(NomeLayout As String) Handles ElencoSinistri.EliminatoLayout
        'ricarica layout nel combo e applica il predefinito
        RemoveHandler ComboBoxLayout.SelectedIndexChanged, AddressOf ComboBoxLayout_SelectedIndexChanged
        ComboBoxLayout.DataSource = Nothing

        AddHandler ComboBoxLayout.SelectedIndexChanged, AddressOf ComboBoxLayout_SelectedIndexChanged
        ComboBoxLayout.DataSource = ElencoSinistri.AggiornaListaLayout
        ComboBoxLayout.SelectedIndex = 0
    End Sub

    Private Sub ButtonConsap_Click(sender As Object, e As EventArgs) Handles ButtonConsap.Click
        Try
            If ElencoSinistri.dgvSinistri.CurrentRow IsNot Nothing Then
                Select Case SinistroCorrente.RamoSinistro
                    Case 30, 130
                        Dim f As New Consap.FormConsap
                        f.CodiceFiscale = SinistroCorrente.CfAssicurato
                        f.IdSinistro = SinistroCorrente.IdSinistro
                        f.Show()
                    Case Else
                        MsgBox("Attenzione: non si tratta di un ramo sinistro 30", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                End Select
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonNoteAttivita_Click(sender As Object, e As EventArgs) Handles ButtonNoteAttivita.Click
        Try
            Using f As New UtControls.FormAttivita
                f.ShowDialog()

                Select Case f.DialogResult
                    Case Windows.Forms.DialogResult.Cancel
                    Case Windows.Forms.DialogResult.OK
                        'elenco in griglia
                        Query.Abilitata = False 'altrimenti si genera 2 volte l'evento che aggiorna la query

                        ButtonReset.PerformClick()

                        Query.TipoElenco = QuerySinistri.DefaultElenco.ATTIVITA
                        Query.AttivitaDal = f.InizioPeriodo
                        Query.AttivitaAl = f.FinePeriodo
                        Query.Utente = f.Utente
                        Query.Abilitata = True
                    Case Windows.Forms.DialogResult.Yes
                        'stampa
                        Using Anteprima As New UtControls.FormAnteprima
                            Anteprima.NomeFile = StampaAttivita(f.InizioPeriodo, f.FinePeriodo, f.Utente)
                            Anteprima.ShowDialog()
                            'cancello il file di anteprima
                            File.Delete(Anteprima.NomeFile)
                        End Using
                End Select
            End Using
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Function StampaAttivita(Inizio As Date, Fine As Date, Utente As String) As String
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim Sql As String = String.Format("SELECT N.*,Trim(S.CognomeAssicurato) + Space(1) + Trim(S.NomeAssicurato) AS Assicurato,S.IdGestione 
                FROM SinistriMemo AS N
                LEFT JOIN 
                (SELECT AgenziaSinistro,EsercizioSinistro,NumeroSinistro,CognomeAssicurato,NomeAssicurato,IdGestione FROM SinistriDP 
                    UNION ALL
                 SELECT AgenziaSinistro,EsercizioSinistro,NumeroSinistro,CognomeAssicurato,NomeAssicurato,IdGestione FROM SinistriAC) AS S ON 
                    Cast(SUBSTRING(N.IdNota,3,4) AS Int) = S.AgenziaSinistro AND 
                    Cast(SUBSTRING(N.IdNota,8,4) AS Int) = S.EsercizioSinistro AND 
                    Cast(SUBSTRING(N.IdNota,13,7) AS Int) = S.NumeroSinistro 
                WHERE (Tipo = 'A') AND (N.Allarme BETWEEN '{0:dd/MM/yyyy}' AND '{1:dd/MM/yyyy}') AND (N.IdNota <> N.CodiceFiscale) AND
                    (N.Utente LIKE '%{2}%')
                ORDER BY N.Allarme", Inizio, Fine, Utente)
            'IdNota=1-8101-2015-0377839

            Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteNonQuery(Sql)
            If Risposta.Errore Then
                Return ""
            End If

            Dim dt As DataTable = Risposta.DataTable
            Dim AntHtml As New Utx.PaginaHtml(String.Format("Attivita_{0}", Format(Today, "ddMMyyyy")))

            If dt.Rows.Count > 0 Then
                With AntHtml
                    .Size = Utx.PaginaHtml.TextSize.medium
                    .Titolo = "Attività in scadenza"
                    .AddRow(String.Format("Attività in scadenza dal {0:d} al {1:d} - Utente: {2}", Inizio, Fine, Utente), Grassetto:=True)
                    .Size = Utx.PaginaHtml.TextSize.small
                    .AddRow(String.Format("Report del {0}", Now))
                    .AddLine()

                    Dim Giorno As Date
                    Dim EndOfReader As Boolean = False
                    Dim Progressivo As Integer = 0

                    For k As Integer = 0 To dt.Rows.Count - 1
                        Giorno = dt.Rows(k)("Allarme")

                        'data scadenza
                        .Tab = 0
                        .AddRow(Format(dt.Rows(k)("Allarme"), "dddd dd-MM-yyyy:").ToUpper,
                                Grassetto:=True, ColoreTesto:=Utx.PaginaHtml.Colori.ROSSO)
                        .AddRow()

                        Do While Giorno = dt.Rows(k)("Allarme")
                            Progressivo += 1
                            .Tab = 1

                            'numero sinistro e utente
                            .AddRow(String.Format("{4} - Sinistro: {0} (<strong>{1}</strong>) - (Referente: {2} - Autore: {3})",
                                    dt.Rows(k)("IdNota"),
                                    dt.Rows(k)("Assicurato"),
                                    dt.Rows(k)("IdGestione"),
                                    dt.Rows(k)("Utente"),
                                    Progressivo),
                                    ColoreTesto:=Utx.PaginaHtml.Colori.AZZURRO,
                                    Grassetto:=True)

                            'corpo nota
                            .Tab = 2
                            AntHtml.AddRow(dt.Rows(k)("Memo").ToString.Replace(vbLf, vbCrLf))
                            AntHtml.AddLine(1)

                            'avanzo al record successivo
                            k += 1
                            If k = dt.Rows.Count Then
                                Exit Do 'se fine esco
                            End If
                        Loop

                        AntHtml.AddLine() 'riga per chiudere la giornata
                        If k = dt.Rows.Count Then
                            Exit For 'se fine esco
                        End If
                    Next
                End With
            Else
                AntHtml.AddRow("Nessuna scadenza nel periodo selezionato.")
            End If
            'crea il file
            AntHtml.CreaFileHtml()
            'ritorna il path
            Return AntHtml.NomeFile

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Private Sub StampaSchedaSinistro(StampaNote As Boolean)
        Try
            SinistroCorrente.Decodifica.LeggiDecodifiche()

            Dim AntHtml As New Utx.PaginaHtml("Anteprima")

            'intestazione con generalità del sinistro
            AntHtml.AddRow(String.Format("Sinistro {0} ({1}) - Stampa del {2:d}",
                                         SinistroCorrente.IdSinistro,
                                         SinistroCorrente.Assicurato,
                                         Today), ColoreTesto:=Utx.PaginaHtml.Colori.AZZURRO, Grassetto:=True)
            AntHtml.AddLine()

            'template della riga
            Dim Riga As String = "{0}: <strong>{1}</strong>{2}"

            For k As Integer = 0 To ElencoSinistri.dgvSinistri.Columns.Count - 1

                With ElencoSinistri.dgvSinistri
                    'valore campo
                    Dim Valore As String = ""

                    Select Case .Columns(k).Name.ToLower
                        Case "pagatoal", "pagatodel", "primopreventivo", "riserva", "recuperoal", "recuperodel"
                            Valore = Format(Utx.FunzioniDb.NullToNumber(.CurrentRow.Cells(k).Value), "€ ###,##0.00")
                        Case "nostraquota"
                            Valore = Utx.FunzioniDb.NullToString(.CurrentRow.Cells(k).Value).ToString + "%"
                        Case Else
                            Valore = Utx.FunzioniDb.NullToString(.CurrentRow.Cells(k).Value)
                    End Select

                    'decodifica
                    Dim Desk As String = ""

                    Select Case .Columns(k).Name.ToLower
                        Case "ramosinistro"
                            Desk = SinistroCorrente.Decodifica.RamoSinistro
                        Case "flagcosepersone"
                            Desk = SinistroCorrente.Decodifica.DanniPersoneCose
                        Case "agenziasinistro"
                            Desk = SinistroCorrente.Decodifica.Ispettorato
                        Case "codicesubagentesima"
                            Desk = SinistroCorrente.Decodifica.Figura
                        Case "ispettorato"
                            Desk = SinistroCorrente.Decodifica.Ispettorato
                        Case "tipocid"
                            Desk = SinistroCorrente.Decodifica.TipoCid
                        Case "tiposinistro"
                            Desk = SinistroCorrente.Decodifica.TipoSinistro
                        Case "statotecnico", "statobilancistico"
                            Desk = Sinistro.Decodifiche.Stato(Utx.FunzioniDb.NullToString(.CurrentRow.Cells(k).Value))
                        Case "codiceliquidatore"
                            Desk = SinistroCorrente.Decodifica.Liquidatore
                        Case "compcontroparte"
                            Desk = SinistroCorrente.Decodifica.CompagniaControparte
                    End Select

                    'aggiungo la riga alla pagina
                    If String.IsNullOrEmpty(Desk) Then
                        AntHtml.AddRow(String.Format(Riga, .Columns(k).HeaderText, Valore, Desk))
                    Else
                        Desk = " (" + Desk + ")"
                        AntHtml.AddRow(String.Format(Riga, .Columns(k).HeaderText, Valore, Desk))
                    End If
                End With
            Next k

            'carattere più piccolo
            AntHtml.Size = Utx.PaginaHtml.TextSize.small

            'stampa le note
            If StampaNote Then
                Dim Sql As String = String.Format("SELECT *,Utente + Format(DataModifica,' (dd.mm.yy - hh:mm)') AS Elenco 
                    FROM SinistriMemo AS N
                    WHERE N.IdNota = '{0}'
                    ORDER BY N.DataModifica", SinistroCorrente.IdSinistro)

                Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteNonQuery(Sql)
                If Risposta.Errore Then
                    Exit Sub
                End If
                Dim dt As DataTable = Risposta.DataTable

                If dt.Rows.Count > 0 Then
                    AntHtml.AddLine()
                    Riga = "Nota: {1}{0}{2}"

                    For Each Nota As DataRow In dt.Rows
                        AntHtml.AddRow(String.Format("Nota: {0}", Nota("Elenco")), ColoreTesto:=Utx.PaginaHtml.Colori.ROSSO, Grassetto:=True)
                        AntHtml.AddRow(Nota("Memo").ToString.Replace(vbLf, vbCrLf))
                        AntHtml.AddLine(1)
                    Next
                End If
            End If

            AntHtml.CreaFileHtml()

            Using Anteprima As New UtControls.FormAnteprima
                Anteprima.CodiceFiscale = SinistroCorrente.CfAssicurato
                Anteprima.NomeFile = AntHtml.NomeFile
                Anteprima.ShowDialog()
                'cancello il file di anteprima
                File.Delete(Anteprima.NomeFile)
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub DettaglioSinistro_SinistroCollegato(AgenziaSinistro As Integer, Eserciosinistro As Integer, NumeroSinistro As Integer) Handles DettaglioSinistro.SinistroCollegato
        TabSinistri.SelectedTab = TabPageElenco
        SelezionaSinistro(1, AgenziaSinistro, Eserciosinistro, NumeroSinistro)
    End Sub

    Private Sub DettaglioSinistro_StampaSinistro(StampaNote As Boolean) Handles DettaglioSinistro.StampaSinistro
        StampaSchedaSinistro(StampaNote)
    End Sub

    Private Sub ButtonOWA_Click(sender As Object, e As EventArgs) Handles ButtonOWA.Click
        Dim Pagina As UtControls.OWA = UtControls.OWA.PaginaOWA(TabSinistri)

        If Pagina Is Nothing Then

            Pagina = New UtControls.OWA

            TabSinistri.Controls.Add(Pagina)
            TabSinistri.SelectedTab = Pagina
        Else
            TabSinistri.SelectedTab = Pagina
        End If
        Pagina.Naviga()
    End Sub

    Private Sub bwLogin_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BwLogin.DoWork
        'Utx.AutenticazioneLiquido.SetCookies("https://essig.unipolsai.it/essigSXCC", Utx.Globale.LoginUniage.CookieContainer)

        'WebViewLiquido.Source = New Uri("https://essig.unipolsai.it/essigSXCC/ClaimCenter.do")

        'WvLiquido.LoadUrl("https://essig.unipolsai.it/essigSXCC/ClaimCenter.do")
        'Select Case e.Argument
        '    Case Utx.Autenticazione.TipoLogin.LIQUIDO
        '        LoginLiquido.LogIn()
        '        If LoginLiquido.Stato = Autenticazione.StatoLogin.LOGIN Then
        '        End If
        '    Case Utx.Autenticazione.TipoLogin.SERTEL
        '        'non più attivo da 25/01/2021
        '        LoginSertel.LogIn()
        'End Select
        'e.Argument.login()
        'e.Result = e.Argument
    End Sub

    Private Sub bwLogin_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BwLogin.RunWorkerCompleted
        'Select Case LoginLiquido.Stato
        '    Case Utx.Autenticazione.StatoLogin.LOGIN
        '        tssMessaggio.Text = "Carico Liquido..."
        '        Utx.Globale.Log.Info("imposto cookies per il browser - bwLogin_RunWorkerCompleted")
        '        'For Each c As Net.Cookie In Utx.Autenticazione.GetCookies(LoginLiquido.CookieContainer)
        '        '    '& "; expires = Sun, 01-Jul-2014 00:00:00 GMT")
        '        '    ' "; expires = " & format(now,"ddd, dd-MMM-yyyy 23:59:59")
        '        '    If InternetSetCookie(Utx.AutenticazioneLiquido.UrlBase, c.Name, c.Value) = False Then
        '        '        Utx.Globale.Log.Info("SetCookie fallito: name = " & c.Name)
        '        '    End If
        '        'Next
        '        tssMessaggio.Text = ""
        '        Utx.AutenticazioneLiquido.SetCookies("https://essig.unipolsai.it/essigSXCC/ClaimCenter.do", Utx.Globale.LoginUniage.CookieContainer)
        '        WvLiquido.LoadUrl("https://essig.unipolsai.it/essigSXCC/ClaimCenter.do")

        '        'Utx.AutenticazioneLiquido.SetCookies(Utx.AutenticazioneLiquido.UrlBase, LoginLiquido.CookieContainer)
        '        'WvLiquido.LoadUrl(LoginLiquido.LoggedUrl)
        '    Case Utx.Autenticazione.StatoLogin.RETE_NON_DISPONIBILE
        '        tssMessaggio.Text = "Liquido non raggiungibile"
        '    Case Else
        '        tssMessaggio.Text = "Login a Liquido fallito"
        'End Select
    End Sub

    Private Sub AbilitazioneControlliFiltro(Attiva As Boolean)
        TimerCerca.Enabled = Attiva
        ButtonViste.Enabled = Attiva
        ComboBoxCercaIn.Enabled = Attiva
        ComboBoxCercaIn.Text = ""
        CheckBoxEsatto.Enabled = Attiva
        ComboBoxTipoTabella.Enabled = Attiva
        ComboBoxChiusura.Enabled = Attiva
        ButtonSelezionaEsercizi.Enabled = Attiva
        CheckBoxElencoCompleto.Enabled = Attiva
        ButtonReset.Enabled = Attiva
    End Sub

    Private Sub ButtonCopia_Click(sender As Object, e As EventArgs) Handles ButtonCopia.Click
        Try
            If EsisteSinistroCorrente() Then
                Using f As New UtControls.FormCopiaDati
                    f.CodiceFiscale = SinistroCorrente.CfAssicurato
                    f.ShowDialog()
                End Using
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Function EsisteSinistroCorrente() As Boolean
        If SinistroCorrente.Esiste = True Then
            Return True
        Else
            MsgBox("Selezionare un sinistro.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            ComboBoxCercaIn.Focus()
            Return False
        End If
    End Function

    Private Sub LeggiDocumenti()
        'avvia la lettura dei codumenti nel box verde nelle note
        If SinistroCorrente Is Nothing Then
            NoteSinistro.CartellaDocumenti = ""
        Else
            Dim deposito As New UnitoolsDocumenti.DepositoPratica(SinistroCorrente.CfAssicurato,
                                                                  SinistroCorrente.IdSinistro)
            NoteSinistro.CartellaDocumenti = deposito.FullPathPratica
        End If
    End Sub

    Private Function WaitPage() As String
        Return Path.Combine(Utx.Globale.Paths.CartellaModelli, "ut_wait.html")
    End Function

    Private Function NoLoginPage() As String
        Return Path.Combine(Utx.Globale.Paths.CartellaModelli, "ut_no_login.html")
    End Function

    Private Sub ButtonPulisciCerca_Click(sender As Object, e As EventArgs) Handles ButtonPulisciCerca.Click
        ComboBoxCercaIn.Text = ""
        ComboBoxCercaIn.Focus()
    End Sub

    Private Sub ButtonFiltri_Click(sender As Object, e As EventArgs) Handles ButtonFiltri.Click
        If ElencoSinistri.dgvSinistri.Rows.Count > 0 Then
            Using f As New FormFiltri(ElencoSinistri.dgvSinistri)
                f.ShowDialog()

                Select Case f.DialogResult
                    Case Windows.Forms.DialogResult.OK
                        ElencoSinistri.VisualizzaFiltro(f.IndiceColonna, Centra:=True)
                    Case Windows.Forms.DialogResult.Yes
                        ElencoSinistri.VisualizzaDettaglio()
                    Case Windows.Forms.DialogResult.Retry
                        ElencoSinistri.FormFiltro.CancellaFiltri()
                End Select
            End Using
        Else
            MsgBox("Selezionare prima i dati su cui applicare i filtri", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
        End If
    End Sub

    Private Sub ButtonReferenti_Click(sender As Object, e As EventArgs) Handles ButtonReferenti.Click
        Dim f As New Referenti.FormReferenti
        f.Show()
    End Sub

    Private Sub FormDocumenti_ActivateDoc()
        If Me.WindowState <> FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Minimized
        End If
    End Sub

    Private Sub FormDocumenti_CloseDoc()
        RemoveHandler FormDocumenti.ActivateDoc, AddressOf FormDocumenti_ActivateDoc
        RemoveHandler FormDocumenti.CloseDoc, AddressOf FormDocumenti_CloseDoc

        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub ElencoSinistri_CercaSinistro(Agenzia As Integer, Esercizio As Integer, Numero As Long) Handles ElencoSinistri.CercaSinistro
        SelezionaSinistro(1, Agenzia, Esercizio, Numero)
    End Sub

    Public Sub VariazioniCostoMeseAnno()
        Try
            Me.Cursor = Cursors.WaitCursor
            tlpSinistri.Enabled = False

            RemoveHandler ElencoSinistri.RowChanged, AddressOf ElencoSinistri_RowChanged

            ElencoSinistri.dgvSinistri.DataSource = Nothing

            LabelNumeroSinistri.Text = "..."
            tssMessaggio.Text = "Analisi in corso..."
            ElencoSinistri.LabelDesk.Text = "Variazione costi su mese/anno - Sinistri esercizio " & Today.Year.ToString

            Dim Plafonamento As Double = InputBox("Importo plafonamento", "Plafonamento", 150000)

            'tabella anno corrente
            Dim QueryAC As String = String.Format("SELECT A.Compagnia,A.AgenziaSinistro,A.EsercizioSinistro,A.NumeroSinistro,
                A.CognomeAssicurato + A.NomeAssicurato AS Cliente,B.UltimoAggiornamento,C.Riserva,A.Statotecnico,A.DataStatoTecnico,
                A.TipoCid,A.RamoGestione,COM.Descrizione AS Comparto 
                FROM SinistriDP AS A 
                INNER JOIN 
                    (SELECT AgenziaSinistro,EsercizioSinistro,NumeroSinistro,MAX(AnnoMeseCompetenza) AS UltimoAggiornamento 
                    FROM AndamentoSinistri 
                    WHERE AnnoMeseCompetenza >= '{0:dd/MM/yyyy}' 
                    GROUP BY AgenziaSinistro,EsercizioSinistro,NumeroSinistro) AS B 
                ON B.AgenziaSinistro = A.AgenziaSinistro AND B.EsercizioSinistro = A.EsercizioSinistro AND B.NumeroSinistro = A.NumeroSinistro 
                LEFT JOIN Comparto AS COM ON COM.Codice = A.Comparto
                INNER JOIN AndamentoSinistri AS C 
                ON C.AgenziaSinistro = A.AgenziaSinistro AND C.EsercizioSinistro = A.EsercizioSinistro AND 
                    C.NumeroSinistro = A.NumeroSinistro AND C.AnnoMeseCompetenza = B.UltimoAggiornamento 
                WHERE A.StatoBilancistico <> 'LT' OR (A.StatoBilancistico = 'LT' AND A.DataStatoBilancistico >= '{0:dd/MM/yyyy}') 
                ORDER BY A.EsercizioSinistro DESC,A.CognomeAssicurato + A.NomeAssicurato", Utx.FunzioniData.InizioAnno(Today))
            Dim dtAC As DataTable = Utx.WsCommand.ExecuteNonQuery(QueryAC).DataTable

            'tabella anno precedente
            Dim QueryAP As String = String.Format("SELECT A.Compagnia,A.AgenziaSinistro,A.EsercizioSinistro,A.NumeroSinistro,
                B.UltimoAggiornamentoAP,C.Riserva,C.PagatoAl
                FROM SinistriDP AS A 
                INNER JOIN 
                    (SELECT AgenziaSinistro,EsercizioSinistro,NumeroSinistro,MAX(AnnoMeseCompetenza) AS UltimoAggiornamentoAP 
                    FROM AndamentoSinistri 
                    WHERE (AnnoMeseCompetenza <= '{0:dd/MM/yyyy}') 
                    GROUP BY AgenziaSinistro,EsercizioSinistro,NumeroSinistro) AS B 
                ON B.AgenziaSinistro = A.AgenziaSinistro AND B.EsercizioSinistro = A.EsercizioSinistro AND B.NumeroSinistro = A.NumeroSinistro
                INNER JOIN (SELECT DISTINCT AgenziaSinistro,EsercizioSinistro,NumeroSinistro,AnnoMeseCompetenza,
                    MAX(Iif(Riserva IS NULL,RiservaBilancio,Riserva)) AS Riserva,MAX(PagatoAl) AS PagatoAl
                    FROM AndamentoSinistri 
                    GROUP BY AgenziaSinistro,EsercizioSinistro,NumeroSinistro,AnnoMeseCompetenza) AS C 
                ON C.AgenziaSinistro = A.AgenziaSinistro AND C.EsercizioSinistro = A.EsercizioSinistro AND C.NumeroSinistro = A.NumeroSinistro AND 
                    C.AnnoMeseCompetenza = B.UltimoAggiornamentoAP", Utx.FunzioniData.FineAnno(Today.AddYears(-1)))
            Dim dtAP As DataTable = Utx.WsCommand.ExecuteNonQuery(QueryAP).DataTable

            'tabella mese precedente
            Dim QueryMP As String = String.Format("SELECT A.Compagnia,A.AgenziaSinistro,A.EsercizioSinistro,A.NumeroSinistro,
                B.AggiornamentoMesePrecedente,C.Riserva 
                FROM SinistriDP AS A 
                INNER JOIN 
                    (SELECT AgenziaSinistro,EsercizioSinistro,NumeroSinistro,MAX(AnnoMeseCompetenza) AS AggiornamentoMesePrecedente 
                    FROM AndamentoSinistri 
                    WHERE AnnoMeseCompetenza BETWEEN '{0:dd/MM/yyyy}' AND '{1:dd/MM/yyyy}' 
                    GROUP BY AgenziaSinistro,EsercizioSinistro,NumeroSinistro) AS B 
                ON B.AgenziaSinistro = A.AgenziaSinistro AND B.EsercizioSinistro = A.EsercizioSinistro AND B.NumeroSinistro = A.NumeroSinistro
                INNER JOIN (SELECT DISTINCT AgenziaSinistro,EsercizioSinistro,NumeroSinistro,AnnoMeseCompetenza,
                    MAX(Iif(Riserva IS NULL,RiservaBilancio,Riserva)) AS Riserva 
                    FROM AndamentoSinistri 
                    WHERE AnnoMeseCompetenza BETWEEN '{0:dd/MM/yyyy}' AND '{1:dd/MM/yyyy}'
                    GROUP BY AgenziaSinistro,EsercizioSinistro,NumeroSinistro,AnnoMeseCompetenza) AS C 
                ON C.AgenziaSinistro = A.AgenziaSinistro AND C.EsercizioSinistro = A.EsercizioSinistro AND C.NumeroSinistro = A.NumeroSinistro AND 
                    C.AnnoMeseCompetenza = B.AggiornamentoMesePrecedente",
                                  Utx.FunzioniData.InizioAnno(Today), Utx.FunzioniData.FineMese(Today.AddMonths(-2)))
            Dim dtMP As DataTable = Utx.WsCommand.ExecuteNonQuery(QueryMP).DataTable

            dtAC.Columns.Add("ValoreAnnoPrecedente", System.Type.GetType("System.Double"))
            dtAC.Columns.Add("ValoreMesePrecedente", System.Type.GetType("System.Double"))
            dtAC.Columns.Add("DifferenzaMese", System.Type.GetType("System.Double"))
            dtAC.Columns.Add("DifferenzaAnno", System.Type.GetType("System.Double"))
            dtAC.Columns.Add("ImpattoAnno", System.Type.GetType("System.Double"))

            'chiavi di ricerca
            dtAP.PrimaryKey = {dtAP.Columns("AgenziaSinistro"), dtAP.Columns("EsercizioSinistro"), dtAP.Columns("NumeroSinistro")}
            dtMP.PrimaryKey = {dtMP.Columns("AgenziaSinistro"), dtMP.Columns("EsercizioSinistro"), dtMP.Columns("NumeroSinistro")}

            For Each row As DataRow In dtAC.Rows
                'cerco il sinistro nella tabella anno precedente
                Dim rowAP As DataRow = dtAP.Rows.Find({row("AgenziaSinistro"), row("EsercizioSinistro"), row("NumeroSinistro")})
                'se lo trovo
                If rowAP IsNot Nothing Then
                    row("ValoreAnnoPrecedente") = rowAP("Riserva") + rowAP("PagatoAl")
                Else
                    row("ValoreAnnoPrecedente") = 0
                End If

                'cerco il sinistro nella tabella mese precedente
                Dim rowMP As DataRow = dtMP.Rows.Find({row("AgenziaSinistro"), row("EsercizioSinistro"), row("NumeroSinistro")})
                'se lo trovo
                If rowMP IsNot Nothing Then
                    row("ValoreMesePrecedente") = rowMP("Riserva")
                Else
                    row("ValoreMesePrecedente") = row("ValoreAnnoPrecedente")
                End If
                'differenza
                Try
                    row("DifferenzaMese") = row("Riserva") - row("ValoreMesePrecedente")
                    row("DifferenzaAnno") = row("Riserva") - row("ValoreAnnoPrecedente")
                    row("ImpattoAnno") = Math.Min(row("Riserva") - row("ValoreAnnoPrecedente"), Plafonamento)
                Catch ex As Exception
                    row("DifferenzaMese") = 0
                    row("DifferenzaAnno") = 0
                    row("ImpattoAnno") = 0
                End Try
            Next

            ElencoSinistri.dgvSinistri.DataSource = dtAC

            If ElencoSinistri.dgvSinistri.Rows.Count > 0 Then
                ElencoSinistri_RowChanged(ElencoSinistri.dgvSinistri.CurrentRow)
            End If

            AddHandler ElencoSinistri.RowChanged, AddressOf ElencoSinistri_RowChanged

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
            tlpSinistri.Enabled = True
            tssMessaggio.Text = ""
        End Try
    End Sub

    Private Sub ElencoSinistri_GestioneSinistroControparte(ByRef Sinistro As DataGridViewRow) Handles ElencoSinistri.GestioneSinistroControparte
        Using f As New FormAzioni(ElencoSinistri.dgvSinistri.CurrentRow.DataBoundItem.Row, SinistroCorrente.IdSinistro)
            f.ShowDialog()
        End Using
    End Sub

    Private Sub FormDocumenti_ModificaDocumenti() Handles FormDocumenti.ModificaDocumenti
        If TabSinistri.SelectedTab Is TabPageNote Then
            LeggiDocumenti()
        End If
    End Sub

    Private Sub ButtonSinistriCliente_Click(sender As Object, e As EventArgs) Handles ButtonSinistriCliente.Click
        If SinistroCorrente IsNot Nothing AndAlso SinistroCorrente.Dati IsNot Nothing Then
            SinistriCliente(SinistroCorrente.CfAssicurato)
        End If
    End Sub

    Private Sub NoteSinistro_RipristinaNoteSinistroCompletato(IdSinistro As String) Handles NoteSinistro.RipristinaNoteSinistroCompletato
        Try
            If IdSinistro = SinistroCorrente.IdSinistro Then
                NoteSinistro.LeggiNote()
            End If
        Catch ex As Exception
            'non fare niente
#If DEBUG Then
            Console.Beep(600, 600)
#End If
        End Try
    End Sub

    Private Sub ButtonRipristinoStorico_Click(sender As Object, e As EventArgs) Handles ButtonRipristinoStorico.Click
        Try
            Using f As New FormRipristino
                If SinistroCorrente.Dati IsNot Nothing Then
                    f.CodiceFiscale = SinistroCorrente.CfAssicurato
                ElseIf Utx.FunzioniFormato.IsCodiceFiscale(Clipboard.GetText.Trim) OrElse Utx.FunzioniFormato.IsPiva(Clipboard.GetText.Trim) Then
                    f.CodiceFiscale = Clipboard.GetText.Trim
                End If
                f.ShowDialog()
                If f.CodiceFiscale.Trim.Length > 0 Then
                    ComboBoxCercaIn.SelectedIndex = QuerySinistri.CercaIn.CF_ASSICURATO
                    ComboBoxCercaIn.Text = f.CodiceFiscale
                Else
                    AggiornaQuery()
                End If
            End Using
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonCambiaAgenzia_Click(sender As Object, e As EventArgs) Handles ButtonCambiaAgenzia.Click
        RaiseEvent RichiestaCambioAgenzia("")
    End Sub

    Private Sub FormImportaSinistri_RichiestaCambioAgenzia(Codice As String) Handles FormImportaSinistri.RichiestaCambioAgenzia
        ButtonCambiaAgenzia.Text = String.Format("{1}{0}cambio agenzia", Environment.NewLine, Codice)
        RaiseEvent RichiestaCambioAgenzia(Codice)
    End Sub

    Public Sub AggiornaBottoneCodice()
        ButtonCambiaAgenzia.Text = Utx.Globale.AgenziaRichiesta.CodiceAgenzia & " - Cambia codice"
    End Sub

    Private Async Sub NavigaLiquido(IdOggetto As String)
        Try
            Await WebViewLiquido.ExecuteScriptAsync(String.Format("parent.gwUtil.fireEvent(document.getElementById('{0}').id+'_act');", IdOggetto))
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub Runtime_Exception(sender As Object, e As ExceptionEventArgs) Handles Runtime.Exception
        Globale.Log.Info(e.ErrorException.Message)
    End Sub

    Private Async Sub ButtonCercaOM_Click(sender As Object, e As EventArgs) Handles ButtonCercaOM.Click
        Try
            Dim Agenzia As String = Await WebViewLiquido.ExecuteScriptAsync("$('div#Claim-ClaimInfoBar-combinedid div.gw-infoValue').text();")
            'Dim Agenzia As String = WvLiquido.EvalScript("$('div#Claim-ClaimInfoBar-combinedid div.gw-infoValue').text();").ToString.Split("/")(0)
            Agenzia = Format(Val(Agenzia.Replace("""", "").Split("/")(0)), "00000") 'il dato restituito dallo script è un JSON
            If Agenzia <> "null" Then
                If Agenzia <> Utx.Globale.AgenziaRichiesta.CodiceAgenzia AndAlso Utx.EnteGestore.CodiciGestiti.Contains(Agenzia) Then
                    RaiseEvent RichiestaCambioAgenzia(Agenzia) 'cambio agenzia
                End If
                Dim Sinistro As String = Await WebViewLiquido.ExecuteScriptAsync("$('div#Claim-ClaimInfoBar-DefaultClaimNumber div.gw-infoValue').text();")
                'Sinistro = Await WebViewLiquido.ExecuteScriptAsync("$('gw-label gw-infoValue');")
                If Sinistro <> "null" Then
                    Sinistro = Utx.NetFunc.EstraiCaratteri(Sinistro.Replace("""", "").Split("-")(3), NetFunc.Funzioni.TipoCaratteri.SoloNumerici)
                    ComboBoxCercaIn.SelectedIndex = 6
                    ComboBoxCercaIn.Text = Sinistro
                End If
            End If
        Catch ex As Exception
            Globale.Log.Info(ex)
        End Try
    End Sub

    Private Sub dgvSinistri_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvSinistri.RowHeaderMouseClick
        If Legenda Is Nothing Then
            Legenda = Utx.WsCommand.ExecuteNonQuery("SELECT * FROM LegendaSinistro ORDER BY Descrizione", "00000").DataTable
        End If

        Dim FormLegenda As New FormLegenda(FormLegenda.TipoVista.INSERIMENTO)
        With FormLegenda
            .Legenda = Legenda
            .SinistroCorrente = SinistroCorrente
            .Show()
        End With
    End Sub

    Private Sub dgvSinistri_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSinistri.CellClick
        ' Verificare se la cella cliccata è la cella dell'angolo in alto a sinistra
        If e.RowIndex = -1 AndAlso e.ColumnIndex = -1 Then
            Dim FormLegenda As New FormLegenda(FormLegenda.TipoVista.FILTRO)
            FormLegenda.Show()
        End If
    End Sub

    Private Sub dgvSinistri_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSinistri.RowLeave
        dgvSinistri.CurrentRow.HeaderCell.Value = ""
    End Sub

    Private Sub CoreWebView2_NewWindowRequested(sender As Object, e As CoreWebView2NewWindowRequestedEventArgs) Handles CoreWebView2.NewWindowRequested
        Try
            e.Handled = True

            ' Crea un nuovo form per il popup
            Dim popupForm As New Utx.FormPopUp(Utx.Globale.TitoloApp) With {.UrlDoc = e.Uri}
            popupForm.Show()
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

End Class
