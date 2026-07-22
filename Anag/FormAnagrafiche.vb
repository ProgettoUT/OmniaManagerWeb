Imports Microsoft.Web.WebView2.WinForms
Imports Microsoft.Web.WebView2.Core

Imports System.Windows.Forms
Imports System.Drawing
Imports mshtml
Imports AxSHDocVw

Public Class FormAnagrafiche
    Public Event RichiestaSinistri()
    Public Event RichiestaSinistriCliente(CodiceFiscale As String)
    Public Event RichiestaCambioAgenzia()

    Private mCodiceFiscale As String
    Private mCodiceFiscale4Essig As String = Nothing
    Private mVaiaIncasso4Essig As Boolean = False

    Private ReadOnly LayoutClienti As New Utx.Layout()
    Private ReadOnly LayoutPolizze As New Utx.Layout()
    Private ReadOnly LayoutIncassi As New Utx.Layout()

    Private WithEvents FormFiltro As New Utx.FormGestioneFiltro
    Private WithEvents TabPageUeba As UtControls.Ueba

    Private WithEvents TimerCerca As New Timer
    Private WithEvents Query As New QueryClienti

    Private WithEvents SintesiCliente As New Anag.ucSintesi
    Private WithEvents TabPageEssig As New TabPage
    Private WithEvents TabPageCrm As New TabPage
    Private WithEvents WbEssig As New AxWebBrowser
    Private WithEvents WbCrm As New AxWebBrowser
    Private WithEvents ButtonLayout As New UtControls.UtFlatButton
    Private WithEvents ButtonNoteAttivita As New UtControls.UtFlatButton
    Private WithEvents ButtonAci As New UtControls.UtFlatButton
    Private WithEvents ButtonUnicoop As New UtControls.UtFlatButton
    Private WithEvents ButtonCambiaAgenzia As New UtControls.UtFlatButton

    Private WithEvents NoteSinistro As New UtControls.ucNote(True)

    Private KeyValuePairEmpty = New KeyValuePair(Of String, String)("", "")
    Private ShowTabPageElenco As Boolean = True

    Private WithEvents Cattura As New Cattura

    Private LoginEssig As New Utx.AutenticazioneEssig
    Private LoginCRM As New Utx.AutenticazioneCRM
    Private LoginUniage As New Utx.AutenticazioneUeba

    Private WithEvents bwLogin As New System.ComponentModel.BackgroundWorker
    Private WithEvents FormDocumenti As UnitoolsDocumenti.FormDocumenti
    Private WithEvents bwArretrati As New System.ComponentModel.BackgroundWorker

    Private mTipoChiusura As Utx.OggettoForm.ChiusuraForm

    Sub New()
        InitializeComponent()
        CheckForIllegalCrossThreadCalls = False

        Me.Text = "Clienti"

        With LayoutClienti
            ElencoClienti.FormFiltro = FormFiltro
            FormFiltro.GestoreLayout = LayoutClienti '????
            .Griglia = ElencoClienti.dgvClienti
            .GestoreLayout = FormFiltro
            .XmlSetting = "Clienti"
            ComboBoxLayout.DataSource = .ListaLayout
        End With
        With LayoutPolizze
            .Griglia = GrigliaPolizze
            .GestoreLayout = New Utx.FormGestioneFiltro(1000)
            .XmlSetting = "ClientiPolizze"
            .LayoutCorrente = "POLIZZE"
        End With
        With LayoutIncassi
            .Griglia = GrigliaIncassi
            .GestoreLayout = New Utx.FormGestioneFiltro(1000)
            .XmlSetting = "ClientiIncassi"
            .LayoutCorrente = "INCASSI"
        End With
        Utx.NetFunc.DoppioBuffer(ElencoClienti.dgvClienti)
        Utx.NetFunc.DoppioBuffer(GrigliaPolizze)
        Utx.NetFunc.DoppioBuffer(GrigliaIncassi)
        Utx.NetFunc.DoppioBuffer(GrigliaArretrati)

        With ComboBoxStatoCliente
            With .Items
                .Add(New KeyValuePair(Of String, String)("TT", "TT - Tutti i clienti in archivio"))
                .Add(New KeyValuePair(Of String, String)("CE", "CE - Clienti cessati"))
                .Add(New KeyValuePair(Of String, String)("EF", "EF - Clienti effettivi"))
                .Add(New KeyValuePair(Of String, String)("PO", "PO - Clienti potenziali"))
            End With

            .DisplayMember = "Value"
            .ValueMember = "Key"
            .SelectedIndex = 0
        End With

        With ComboBoxCercaIn
            With .Items
                '.Add(KeyValuePairEmpty)
                .Add(New KeyValuePair(Of String, String)("A", "Assicurato"))
                .Add(New KeyValuePair(Of String, String)("T", "Targa"))
                .Add(New KeyValuePair(Of String, String)("C", "Codice Fiscale"))
                .Add(New KeyValuePair(Of String, String)("N", "Note"))
                .Add(New KeyValuePair(Of String, String)("R", "Note (redattore)"))
            End With
            .DropDownStyle = ComboBoxStyle.DropDown
            .DisplayMember = "Value"
            .ValueMember = "Key"
            ComboBoxCercaIn_DropDownClosed(Nothing, Nothing)
            .SelectedIndex = 1
        End With

        ImpostaToolStripMain()
        ImpostaControlli()

        'imposta timer ricerca
        TimerCerca.Enabled = False
        If Utx.Globale.RitardoTimer > 0 Then
            TimerCerca.Interval = Utx.Globale.RitardoTimer
        End If

        Utx.OggettoForm.Add(Utx.OggettoForm.TipoForm.ANAG, Me)
    End Sub

    Private Sub ImpostaControlli()
        Me.Icon = Risorse.Immagini.Icon("clienti")
        InizializzaControllo({LabelNominativo, LabelIndirizzo, LabelTitoloPolizze, LabelTitoloIncassi, LabelTitoloArretrati})
        InizializzaControllo({ComboBoxLayout, ComboBoxStatoCliente})
        InizializzaControllo({buttonCercaInEssig, buttonCercaInCrm, buttonVaiAIncasso})

        With GrigliaArretrati
            .DefaultCellStyle.BackColor = Color.Moccasin
            .DefaultCellStyle.SelectionBackColor = Color.Gold
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .MultiSelect = True
        End With

        With buttonCercaInEssig
            .FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
            .Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
            .Image = Risorse.Immagini.Bitmap("cerca16")
            .ImageAlign = ContentAlignment.MiddleLeft
            .TextAlign = ContentAlignment.MiddleRight
        End With

        With buttonCercaInCrm
            .BackColor = Color.Moccasin
            .FlatAppearance.BorderColor = System.Drawing.Color.Salmon
            .Margin = New System.Windows.Forms.Padding(2, 1, 2, 1)
            .Image = Risorse.Immagini.Bitmap("cerca16")
            .ImageAlign = ContentAlignment.MiddleLeft
            .TextAlign = ContentAlignment.MiddleRight
        End With

        With buttonVaiAIncasso
            .FlatAppearance.BorderColor = Color.Silver
            .FlatAppearance.CheckedBackColor = Color.PaleGreen
            .Margin = New System.Windows.Forms.Padding(0, 2, 2, 0)
            .TextAlign = ContentAlignment.MiddleCenter
        End With

        ButtonPulisciCasellaCerca.Image = Risorse.Immagini.Bitmap("cancel16")

        With TabClienti
            .Margin = New Padding(0, 10, 0, 0)
        End With

        With TabPageEssig
            .Name = "TabPageEssig"
            .Text = "Essig"
            .Controls.Add(wbEssig)
        End With

        With wbEssig
            .CreateControl()
            .Dock = DockStyle.Fill
            .Silent = True
        End With
        TabClienti.Controls.Add(TabPageEssig)

        With TabPageCrm
            .Name = "TabPageCrm"
            .Text = "CRM"
            .Controls.Add(WbCrm)
        End With

        With WbCrm
            .CreateControl()
            .Dock = DockStyle.Fill
            .Silent = True
        End With
        TabClienti.Controls.Add(TabPageCrm)

        TabPageNote.Controls.Add(NoteSinistro)

        SintesiCliente.Dock = DockStyle.Fill
        TabPageSintesi.Controls.Add(SintesiCliente)
    End Sub

    Private Sub ImpostaToolStripMain()
        On Error Resume Next

        Dim tt As New ToolTip

        With tsMainMenu
            .GripStyle = ToolStripGripStyle.Hidden
            .BackColor = Color.Transparent
            .Items.Clear()
            .Name = "tsMainMenu"
            tlpClienti.SetColumnSpan(tsMainMenu, 10)
            tlpClienti.Controls.Add(tsMainMenu, 0, 0)
        End With

        With ButtonDocumenti
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Image = Risorse.Immagini.Bitmap("scandoc")
            .SetToolTip("Scanner e documenti")
        End With
        tsMainMenu.Items.Add(New ToolStripControlHost(ButtonDocumenti))

        With ButtonEvidenza
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Image = Risorse.Immagini.Bitmap("doccheck")
            .SetToolTip("Aggiungi evidenza polizza selezionata")
        End With
        tsMainMenu.Items.Add(New ToolStripControlHost(ButtonEvidenza))

        With ButtonEvidenzeCliente
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Image = Risorse.Immagini.Bitmap("docclock")
            .SetToolTip("Evidenze cliente")
        End With
        tsMainMenu.Items.Add(New ToolStripControlHost(ButtonEvidenzeCliente))

        With ButtonNoteAttivita
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Image = Risorse.Immagini.Bitmap("clock")
            .SetToolTip("Attività in scadenza")
        End With
        tsMainMenu.Items.Add(New ToolStripControlHost(ButtonNoteAttivita))

        With ButtonAci
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Image = Risorse.Immagini.Bitmap("aci")
            .SetToolTip("Visura")
        End With
        tsMainMenu.Items.Add(New ToolStripControlHost(ButtonAci))

        With ButtonLegami
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Image = Risorse.Immagini.Bitmap("legami")
            .SetToolTip("Imposta capofamiglia/ente")
        End With
        tsMainMenu.Items.Add(New ToolStripControlHost(ButtonLegami))

        With ButtonCai
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Image = Risorse.Immagini.Bitmap("cai")
            .SetToolTip("Stampa il modulo Cai eventualmente della polizza evidenziata")
        End With
        tsMainMenu.Items.Add(New ToolStripControlHost(ButtonCai))

        With ButtonSinistriCliente
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Dock = DockStyle.Fill
            .Image = Risorse.Immagini.Bitmap("sinistro")
            .SetToolTip("Scheda sinistri del cliente")
        End With
        tsMainMenu.Items.Add(New ToolStripControlHost(ButtonSinistriCliente))

        tsMainMenu.Items.Add(New ToolStripSeparator)

        With ButtonQuota
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Image = Risorse.Immagini.Bitmap("quota")
            .SetToolTip("Apri quotatore")
        End With
        tsMainMenu.Items.Add(New ToolStripControlHost(ButtonQuota))

        With ButtonAssegni
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Dock = DockStyle.Fill
            .Image = Risorse.Immagini.Bitmap("assegno")
            .SetToolTip("Scansione assegni")
        End With
        tsMainMenu.Items.Add(New ToolStripControlHost(ButtonAssegni))

        With ButtonCopia
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Image = Risorse.Immagini.Bitmap("copia")
            .SetToolTip("Copia dati")
        End With
        tsMainMenu.Items.Add(New ToolStripControlHost(ButtonCopia))

        If IO.File.Exists(IO.Path.Combine(Utx.Globale.Paths.CartellaApp, "Unicoop.exe")) Then
            With ButtonUnicoop
                .AutoSize = False
                .Width = tsMainMenu.Height
                .Image = Risorse.Immagini.Bitmap("unicoop")
                .SetToolTip("Trattenute Unicoop")
            End With
            tsMainMenu.Items.Add(New ToolStripControlHost(ButtonUnicoop))
        End If

        tsMainMenu.Items.Add(New ToolStripSeparator)

        'combo dei layout
        With ButtonLayout
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Text = "Layout"
            .TextAlign = ContentAlignment.MiddleCenter
            .SetToolTip("Gestisci i layout")
        End With
        tsMainMenu.Items.Add(New ToolStripControlHost(ButtonLayout))

        With ComboBoxLayout
            '.Dock = DockStyle.Top
            .ForeColor = Color.DodgerBlue
        End With

        Dim ttch = New ToolStripControlHost(ComboBoxLayout)
        ttch.AutoSize = False
        ttch.Width = 150
        tsMainMenu.Items.Add(ttch)

        tsMainMenu.Items.Add(New ToolStripSeparator)

        'sinistri
        With ButtonSinistri
            .AutoSize = False
            .Height = tsMainMenu.Height
            .Dock = DockStyle.Fill
            .Image = Risorse.Immagini.Bitmap("sinistro")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Scheda Sinistri"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        ttch = New ToolStripControlHost(ButtonSinistri) With {.AutoSize = False, .Dock = DockStyle.Fill, .Width = 140, .Alignment = ToolStripItemAlignment.Left}
        tsMainMenu.Items.Add(ttch)

        tsMainMenu.Items.Add(New ToolStripSeparator)

        With ButtonUeba
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Image = Risorse.Immagini.Bitmap("ueba")
            .SetToolTip("Apri scheda Ueba")
        End With
        tsMainMenu.Items.Add(New ToolStripControlHost(ButtonUeba))

        With ButtonOWA
            .AutoSize = False
            .Width = tsMainMenu.Height
            .Image = Risorse.Immagini.Bitmap("owa")
            .SetToolTip("Apri posta OWA")
        End With
        tsMainMenu.Items.Add(New ToolStripControlHost(ButtonOWA))

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
            .SetToolTip("Esci dalla scheda cliente")
        End With
        ttch = New ToolStripControlHost(ButtonEsci) With {.Alignment = ToolStripItemAlignment.Right}
        tsMainMenu.Items.Add(ttch)
    End Sub

    Private Sub AddHandlerControl()
        AddHandler ComboBoxCercaIn.TextChanged, AddressOf ComboBoxCercaIn_TextChanged
        AddHandler ComboBoxCercaIn.GotFocus, AddressOf ComboBoxCercaIn_GotFocus
        AddHandler CheckBoxTutti.CheckedChanged, AddressOf CheckBoxTutti_CheckedChanged
        AddHandler CheckBoxEsatto.CheckedChanged, AddressOf CheckBoxEsatto_CheckedChanged
        AddHandler ComboBoxStatoCliente.SelectedIndexChanged, AddressOf ComboBoxStatoCliente_SelectedIndexChanged
    End Sub

    Private Sub RemoveHandlerControl()
        RemoveHandler ComboBoxCercaIn.TextChanged, AddressOf ComboBoxCercaIn_TextChanged
        RemoveHandler ComboBoxCercaIn.GotFocus, AddressOf ComboBoxCercaIn_GotFocus
        RemoveHandler CheckBoxTutti.CheckedChanged, AddressOf CheckBoxTutti_CheckedChanged
        RemoveHandler CheckBoxEsatto.CheckedChanged, AddressOf CheckBoxEsatto_CheckedChanged
        RemoveHandler ComboBoxStatoCliente.SelectedIndexChanged, AddressOf ComboBoxStatoCliente_SelectedIndexChanged
    End Sub

    Private Sub TimerCerca_Tick(sender As Object, e As EventArgs) Handles TimerCerca.Tick
        AggiornaQuery()
    End Sub

    Private Sub CheckBoxTutti_CheckedChanged(sender As Object, e As EventArgs)
        If CheckBoxTutti.Checked = False Then
            CheckBoxTutti.ForeColor = Drawing.SystemColors.ControlText
        Else
            CheckBoxTutti.ForeColor = Color.Red
        End If
        ComboBoxCercaIn.Text = ""
        AggiornaQuery()
    End Sub

    Private Sub CheckBoxEsatto_CheckedChanged(sender As Object, e As EventArgs)

        If CheckBoxEsatto.Checked = True Then
            CheckBoxEsatto.ForeColor = Drawing.SystemColors.ControlText
        Else
            CheckBoxEsatto.ForeColor = Color.Red
        End If

        If CheckBoxTutti.Checked = False Then
            AggiornaQuery()
        End If

        ComboBoxCercaIn.Focus()
    End Sub

    Public Sub AggiornaQuery(Optional codicefiscale As String = Nothing)
        If ShowTabPageElenco Then
            TabClienti.SelectedTab = TabPageElenco
        End If
        TimerCerca.Enabled = False

        Try
            Me.Cursor = Cursors.WaitCursor
            tlpClienti.Enabled = False
            tssMessaggio.Text = "Lettura clienti in corso..."

            LabelNumeroClienti.Text = "..."
            mCodiceFiscale = ""

            If codicefiscale IsNot Nothing Then
                Query.TipoFiltro = "C"
                Query.ValoreFiltro = codicefiscale
            ElseIf Utx.NetFunc.IsTarga(ComboBoxCercaIn.Text) Then
                Query.TipoFiltro = "T"
                Query.ValoreFiltro = ComboBoxCercaIn.Text
            Else
                Query.TipoFiltro = ComboBoxCercaIn.Tag
                Query.ValoreFiltro = ComboBoxCercaIn.Text
            End If

            Query.IDStatoCliente = CType(ComboBoxStatoCliente.SelectedItem, KeyValuePair(Of String, String)).Key
            Query.CorrispondenzaEsatta = CheckBoxEsatto.Checked
            Query.EstraiTutti = CheckBoxTutti.Checked

            Dim CommandText As String = Query.CommandText

            If CommandText.Length > 0 Then
                Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteNonQuery(CommandText)
                If Risposta IsNot Nothing Then
                    ElencoClienti.dgvClienti.DataSource = Risposta.DataTable
                End If
            Else
                ElencoClienti.dgvClienti.DataSource = Nothing
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
            tlpClienti.Enabled = True
            tssMessaggio.Text = ""
        End Try
    End Sub

    Private Sub AggiornaQuery(Inizio As Date, Fine As Date)
        If ShowTabPageElenco Then
            TabClienti.SelectedTab = TabPageElenco
        End If
        TimerCerca.Enabled = False

        Try
            Me.Cursor = Cursors.WaitCursor
            tlpClienti.Enabled = False
            tssMessaggio.Text = "Lettura clienti in corso..."

            LabelNumeroClienti.Text = "..."

            ButtonReset_Click(Me, New EventArgs())

            Dim CommandText As String = QueryClienti.QueryBaseCompletaAttivita(Inizio, Fine)

            If CommandText.Length > 0 Then
                ElencoClienti.dgvClienti.DataSource = Utx.WsCommand.ExecuteNonQuery(CommandText).DataTable
            Else
                ElencoClienti.dgvClienti.DataSource = Nothing
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
            tlpClienti.Enabled = True
            tssMessaggio.Text = ""
        End Try
    End Sub

    Private Sub FormAnagrafiche_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        mTipoChiusura = Utx.OggettoForm.ChiusuraForm.NORMALE
        Me.Text = String.Format("Clienti {0}", Utx.Globale.AgenziaRichiesta.CodiceAgenzia)
        NavigateToEssig()
        ComboBoxCercaIn.Focus()
    End Sub

    Private Sub FormAnagrafiche_Load(sender As Object, e As EventArgs) Handles Me.Load
        TabClienti.ItemSize = New Size(TabClienti.Width / 10 - 12, 25)
        Globale.ModelloPrivacyPath = IO.Path.Combine(Utx.Globale.Paths.CartellaModelliRete, "PrivacyAgenzia.pdf")
        'aggancio la finestra di popup
        AddHandler wbEssig.NewWindow2, AddressOf wbEssig_NewWindow2
        AddHandler WbCrm.NewWindow2, AddressOf wbEssig_NewWindow2
    End Sub

    Private Sub FormAnagrafiche_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        TabClienti.ColorStyle = Utx.UtTabControl.TabColorStyle.AZZURRO
        Me.Refresh()

        RemoveHandlerControl()
        ComboBoxCercaIn.Focus()
        AddHandlerControl()
    End Sub

    Private Sub ComboBoxStatoCliente_SelectedIndexChanged(sender As Object, e As EventArgs)
        If ComboBoxStatoCliente.SelectedIndex = 3 Then
            ComboBoxStatoCliente.Font = Utx.AppFont.Normal
            CheckBoxTutti.ForeColor = Drawing.SystemColors.ControlText
        Else
            ComboBoxStatoCliente.Font = Utx.AppFont.Bold
            CheckBoxTutti.ForeColor = Color.Red
        End If
        AggiornaQuery()
    End Sub

    Private Sub ComboBoxLayout_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxLayout.SelectedIndexChanged

        Dim source As Object = ElencoClienti.dgvClienti.DataSource
        ElencoClienti.dgvClienti.DataSource = Nothing

        LayoutClienti.SalvaLayout()
        LayoutClienti.LayoutCorrente = ComboBoxLayout.Text

        ElencoClienti.dgvClienti.DataSource = source
    End Sub

    Private Sub Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        LayoutClienti.SalvaLayout()
        LayoutPolizze.SalvaLayout()
        LayoutIncassi.SalvaLayout()
        NoteSinistro.SalvaNota()

        If mTipoChiusura = Utx.OggettoForm.ChiusuraForm.HIDE Then
            Utx.OggettoForm.Close(Utx.OggettoForm.TipoForm.ANAG, Me)
            e.Cancel = True
        Else
            Me.Enabled = False
            If bwLogin IsNot Nothing Then Do While bwLogin.IsBusy : Application.DoEvents() : Loop
            If bwArretrati IsNot Nothing Then Do While bwArretrati.IsBusy : Application.DoEvents() : Loop
            Utx.OggettoForm.Dispose(Utx.OggettoForm.TipoForm.ANAG)
        End If
    End Sub

    Private Sub NavBar_ButtonClick(ButtonIndex As UtControls.ucNavigationBar.ButtonType) Handles NavBar.ButtonClick

        NavBar.AbilitaNavigazione(False)

        Select Case ButtonIndex

            Case UtControls.ucNavigationBar.ButtonType.CENTO,
                 UtControls.ucNavigationBar.ButtonType.PIU,
                 UtControls.ucNavigationBar.ButtonType.MENO

                Select Case True
                    Case TabClienti.SelectedTab Is TabPageElenco
                        ModificaCarattereGriglia(ButtonIndex)
                    Case TabClienti.SelectedTab Is TabPageEssig
                        RegolaCaratteriBrowser(wbEssig, ButtonIndex)
                    Case TabClienti.SelectedTab Is TabPageCrm
                        RegolaCaratteriBrowser(WbCrm, ButtonIndex)
                End Select

            Case Else
                NavigaRecord(ButtonIndex)
        End Select

        NavBar.AbilitaNavigazione(True)
    End Sub

    Private Sub NavigaRecord(ButtonIndex As UtControls.ucNavigationBar.ButtonType)
        If ElencoClienti.dgvClienti.DataSource IsNot Nothing Then

            Dim col As Integer = ElencoClienti.dgvClienti.CurrentCell.ColumnIndex

            Select Case ButtonIndex

                Case UtControls.ucNavigationBar.ButtonType.PRIMO
                    ElencoClienti.dgvClienti.CurrentCell = ElencoClienti.dgvClienti.Rows(0).Cells(col)

                Case UtControls.ucNavigationBar.ButtonType.ULTIMO
                    ElencoClienti.dgvClienti.CurrentCell =
                        ElencoClienti.dgvClienti.Rows(ElencoClienti.dgvClienti.Rows.Count - 1).Cells(col)

                Case UtControls.ucNavigationBar.ButtonType.PROSSIMO
                    If ElencoClienti.dgvClienti.CurrentRow.Index + 1 <= ElencoClienti.dgvClienti.Rows.Count - 1 Then
                        ElencoClienti.dgvClienti.CurrentCell =
                            ElencoClienti.dgvClienti.Rows(ElencoClienti.dgvClienti.CurrentRow.Index + 1).Cells(col)
                    End If

                Case UtControls.ucNavigationBar.ButtonType.PRECEDENTE
                    If ElencoClienti.dgvClienti.CurrentRow.Index - 1 >= 0 Then
                        ElencoClienti.dgvClienti.CurrentCell =
                            ElencoClienti.dgvClienti.Rows(ElencoClienti.dgvClienti.CurrentRow.Index - 1).Cells(col)
                    End If
            End Select
        End If
    End Sub

    Public Sub RegolaCaratteriBrowser(ByRef wb As AxWebBrowser, ButtonIndex As UtControls.ucNavigationBar.ButtonType)
        On Error Resume Next
        Dim zoom As Integer = Utx.Globale.SettingUtente.LeggiValore("zoom")

        'i numeri negativi producono strani effetti
        If zoom <= 0 Then
            zoom = 100
        End If

        Select Case ButtonIndex
            Case UtControls.ucNavigationBar.ButtonType.CENTO
                zoom = 100
            Case UtControls.ucNavigationBar.ButtonType.MENO
                zoom -= 5
            Case UtControls.ucNavigationBar.ButtonType.PIU
                zoom += 5
        End Select

        Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.ZOOM, zoom.ToString)

        'imposto il valore di default per i caratteri
        wb.ExecWB(SHDocVw.OLECMDID.OLECMDID_ZOOM, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER, CObj(2), CObj(IntPtr.Zero))

        'imposto il nuovo valore dello zoom
        wb.ExecWB(SHDocVw.OLECMDID.OLECMDID_OPTICAL_ZOOM, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER, CObj(zoom), CObj(IntPtr.Zero))
    End Sub

    Private Sub ModificaCarattereGriglia(ButtonIndex As UtControls.ucNavigationBar.ButtonType)

        If TabClienti.SelectedTab Is TabPageElenco Then
            Select Case ButtonIndex
                Case UtControls.ucNavigationBar.ButtonType.PIU
                    ElencoClienti.dgvClienti.Font = New Font(ElencoClienti.dgvClienti.Font.Name, Math.Min(20, ElencoClienti.dgvClienti.Font.Size + 1))

                Case UtControls.ucNavigationBar.ButtonType.MENO
                    ElencoClienti.dgvClienti.Font = New Font(ElencoClienti.dgvClienti.Font.Name, Math.Max(6, ElencoClienti.dgvClienti.Font.Size - 1))

                Case UtControls.ucNavigationBar.ButtonType.CENTO
                    ElencoClienti.dgvClienti.Font = New Font(ElencoClienti.dgvClienti.Font.Name, 9)
            End Select
        End If
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        mTipoChiusura = Utx.OggettoForm.ChiusuraForm.HIDE
        Me.Close()
    End Sub

    Private Sub CompilaCai(sender As Object, e As EventArgs) Handles ButtonCai.Click
        Dim agenzia As Integer = 0
        Dim ramo As Integer = 0
        Dim polizza As Integer = 0

        If TabClienti.SelectedTab Is TabPagePolizzeIncassi Then
            If GrigliaPolizze.CurrentRow IsNot Nothing Then
                agenzia = GrigliaPolizze.CurrentRow.Cells("Agenzia").Value
                ramo = GrigliaPolizze.CurrentRow.Cells("Ramo").Value
                polizza = GrigliaPolizze.CurrentRow.Cells("Polizza").Value
            End If
        End If

        UniCai.Modello.StampaEtVisualizza(agenzia, ramo, polizza)
    End Sub

    Private Sub TrattenuteUnicoop(sender As Object, e As EventArgs) Handles ButtonUnicoop.Click
        If GrigliaPolizze.CurrentRow IsNot Nothing Then
            Utx.Servizi.AvviaUnicoop(ElencoClienti.dgvClienti.CurrentRow.Cells("Cliente").Value,
                                    GrigliaPolizze.CurrentRow.Cells("Ramo").Value,
                                    GrigliaPolizze.CurrentRow.Cells("Polizza").Value,
                                    0,
                                    GrigliaPolizze.CurrentRow.Cells("Scadenza").Value)
        Else
            Utx.Servizi.AvviaUnicoop("", 0, 0, 0, Today)
        End If
    End Sub

    Private Sub ElencoClienti_ClienteDouubleClick() Handles ElencoClienti.ClienteDouubleClick
        TabClienti.SelectedTab = TabPageDettaglio
    End Sub

    Private Sub ElencoClienti_Errore(ex As Exception, Procedura As String) Handles ElencoClienti.Errore
        If Procedura = "DataGridError" Then
            Me.Close()
        End If
    End Sub

    Private Sub ElencoClienti_RowChanged(ByRef Cliente As DataGridViewRow) Handles ElencoClienti.RowChanged
        If Cliente IsNot Nothing Then
            With Cliente
                mCodiceFiscale = .Cells("CodiceFiscale").Value
                LabelNominativo.Text = Utx.FunzioniDb.NullToString(.Cells("Cliente").Value)
                LabelIndirizzo.Text = New Anax.Indirizzo(Utx.FunzioniDb.NullToString(.Cells("Indirizzo").Value),
                                                         Utx.FunzioniDb.NullToString(.Cells("Cap").Value),
                                                         Utx.FunzioniDb.NullToString(.Cells("Localita").Value),
                                                         Utx.FunzioniDb.NullToString(.Cells("Provincia").Value)).ToString
            End With

            TabClienti_SelectedIndexChanged(Nothing, Nothing)

            LabelNumeroClienti.Text = String.Format("{0} di {1}",
                                         Cliente.DataGridView.CurrentRow.Index + 1,
                                         Cliente.DataGridView.Rows.Count)
        End If
    End Sub

    Private Sub DettaglioCliente_ClienteChanged(nome As String, indirizzo As String) Handles DettaglioCliente.ClienteChanged
        LabelNominativo.Text = nome
        LabelIndirizzo.Text = indirizzo
    End Sub

    Private Sub TabClienti_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles TabClienti.Selecting
        If e.TabPage Is TabPageDettaglio OrElse
            e.TabPage Is TabPageNote OrElse
            e.TabPage Is TabPagePolizzeIncassi OrElse
            e.TabPage Is TabPageSintesi Then
            e.Cancel = Not AssertSelezioneCliente()
        End If
    End Sub

    Private Function AssertSelezioneCliente() As Boolean
        If String.IsNullOrEmpty(mCodiceFiscale) Then
            MsgBox("Seleziona prima un cliente.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub TabClienti_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabClienti.SelectedIndexChanged
        Application.DoEvents()
        Try
            Select Case True
                Case TabClienti.SelectedTab Is TabPageElenco
                    NavBar.AbilitaZoom = True
                'ComboBoxCercaIn.Focus()
                Case TabClienti.SelectedTab Is TabPageDettaglio
                    NavBar.AbilitaZoom = False
                    DettaglioCliente.SelezionaCliente(mCodiceFiscale)
                Case TabClienti.SelectedTab Is TabPagePolizzeIncassi
                    NavBar.AbilitaZoom = False
                    CaricaPolizzeEtArratrati()
                Case TabClienti.SelectedTab Is TabPageSintesi
                    NavBar.AbilitaZoom = False
                    SintesiCliente.CaricaValori(mCodiceFiscale)
                Case TabClienti.SelectedTab Is TabPageEssig
                    NavBar.AbilitaZoom = True
                    NavigateToEssig()
                Case TabClienti.SelectedTab Is TabPageCrm
                    NavBar.AbilitaZoom = True
                    NavigateToCrm()
                Case TabClienti.SelectedTab Is TabPageNote
                    NavBar.AbilitaZoom = False
                    NoteSinistro.IdNote = mCodiceFiscale
                    NoteSinistro.CF = mCodiceFiscale
                    NoteSinistro.LeggiNote()
                    NoteSinistro.CartellaDocumenti = New UnitoolsDocumenti.DepositoPratica(mCodiceFiscale).FullPathPratica
            End Select
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub CaricaPolizzeEtArratrati()
        CaricaPolizze(storico:=False)
        CaricaArretrati()
    End Sub

    Private Sub CaricaPolizze(storico As Boolean)
        If storico Then
            LabelStorico.Text = "passa a vigore"
            LabelTitoloPolizze.Text = "Storico polizze"
            Panel1.BackColor = Color.Moccasin
            GrigliaPolizze.DataSource = Utx.WsCommand.ExecuteNonQuery(Polizza.GetSqlStoricoPolizzePerCodiceFiscale(mCodiceFiscale)).DataTable
        Else
            LabelStorico.Text = "passa a storico"
            LabelTitoloPolizze.Text = "Polizze in vigore"
            Panel1.BackColor = Color.LightYellow
            GrigliaPolizze.DataSource = Utx.WsCommand.ExecuteNonQuery(Polizza.GetSqlPolizzePerCodiceFiscale(mCodiceFiscale)).DataTable
        End If
        If GrigliaPolizze.RowCount = 0 Then
            CaricaIncassi(tutto:=True)
        Else
            GrigliaPolizze.Rows(0).Selected = True
        End If
    End Sub

    Private Sub GrigliaPolizze_CurrentCellChanged(sender As Object, e As EventArgs) Handles GrigliaPolizze.CurrentCellChanged
        CaricaIncassi(tutto:=False)
        CaricaDocumentiPolizza()
    End Sub

    Private Sub CaricaIncassi(tutto As Boolean)
        If tutto Then
            LabelTitoloIncassi.Text = "Incassi del Cliente"
            GrigliaIncassi.DataSource = Utx.WsCommand.ExecuteNonQuery(Incasso.GetSqlIncassoPerCodiceFiscale(mCodiceFiscale)).DataTable
        ElseIf GrigliaPolizze.CurrentRow IsNot Nothing Then
            Dim agenzia As Integer = GrigliaPolizze.CurrentRow.Cells("Agenzia").Value
            Dim ramo As Integer = GrigliaPolizze.CurrentRow.Cells("Ramo").Value
            Dim polizza As Integer = GrigliaPolizze.CurrentRow.Cells("Polizza").Value

            GrigliaIncassi.DataSource = Utx.WsCommand.ExecuteNonQuery(Incasso.GetSqlIncassoPerPolizza(agenzia, ramo, polizza)).DataTable
            LabelTitoloIncassi.Text = String.Format("Incassi polizza {0}/{1}", ramo, polizza)
        Else
            LabelTitoloIncassi.Text = "Incassi"
            GrigliaIncassi.DataSource = Nothing
        End If
    End Sub

    Private Sub CaricaDocumentiPolizza()
        If GrigliaPolizze.CurrentRow Is Nothing Then
            dgvDocumenti.DataSource = Nothing
        Else
            Dim deposito As New UnitoolsDocumenti.DepositoPratica(mCodiceFiscale,
                                                                  GrigliaPolizze.CurrentRow.Cells("Ramo").Value,
                                                                  GrigliaPolizze.CurrentRow.Cells("Polizza").Value)

            Dim dt As New DataTable()
            dt.Columns.Add(New DataColumn("filepath"))
            dt.Columns.Add(New DataColumn(String.Format("Documenti polizza {0}.{1}",
                                                        GrigliaPolizze.CurrentRow.Cells("Ramo").Value,
                                                        GrigliaPolizze.CurrentRow.Cells("Polizza").Value)))

            If IO.Directory.Exists(deposito.FullPathPratica) Then
                Dim files = IO.Directory.GetFiles(deposito.FullPathPratica)
                For Each file In files
                    dt.Rows.Add({file, IO.Path.GetFileName(file)})
                Next
            End If

            dgvDocumenti.DataSource = dt
            dgvDocumenti.Columns(0).Visible = False
            dgvDocumenti.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If
    End Sub

    Private Sub dgvDocumenti_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDocumenti.CellDoubleClick
        If e.RowIndex >= 0 Then
            Process.Start(dgvDocumenti.Rows(e.RowIndex).Cells(0).Value)
        End If
    End Sub

    Private Sub buttonCercaInEssig_Click(sender As Object, e As EventArgs) Handles buttonCercaInEssig.Click
        If AssertSelezioneCliente() Then
            mCodiceFiscale4Essig = mCodiceFiscale
            TabClienti.SelectedTab = TabPageEssig
            If LoginEssig.IsLogged Then
                Naviga(WbEssig, LoginEssig.UrlBase & "essigSC/start.do?itemId=0101000000&parametri=SC++SC")
            End If
        End If
    End Sub

    Private Sub buttonCercaInCrm_Click(sender As Object, e As EventArgs) Handles buttonCercaInCrm.Click
        If AssertSelezioneCliente() Then
            TabClienti.SelectedTab = TabPageCrm
            Dim tiporicerca = IIf(mCodiceFiscale.Trim.Length = 16, 2, 4)
            Naviga(WbCrm, Utx.AutenticazioneCRM.UrlBase & String.Format("wps/myportal/CRM/SchedaAnagrafica/RicercaCliente/?tipoRicerca={0}&inputRicerca={1}", tiporicerca, mCodiceFiscale))
        End If
    End Sub

    Private Sub buttonVaiAIncasso_Click(sender As Object, e As EventArgs) Handles buttonVaiAIncasso.Click
        mVaiaIncasso4Essig = True
        buttonCercaInEssig_Click(sender, e)
    End Sub

    Private Sub wbEssig_DocumentComplete(sender As Object, e As AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEvent) Handles wbEssig.DocumentComplete
        Dim wb As AxWebBrowser = sender

        Try
            If wb.Document IsNot Nothing AndAlso DirectCast(wb.Document, mshtml.HTMLDocument).readyState <> "complete" Then
                Exit Sub
            ElseIf IO.Path.GetFileName(e.uRL) = "ut_wait.html" Then
                If LoginEssig.IsLogged Then
                    Utx.Globale.Log.Info("imposto cookies per il browser - wbEssig_DocumentComplete")
                    Utx.Autenticazione.SetCookies(LoginEssig.UrlBase, LoginCRM.CookieContainer)
                    Naviga(wb, LoginEssig.LoggedUrl)
                Else
                    bwLogin.RunWorkerAsync(LoginEssig)
                End If
            Else

                Dim d As IHTMLDocument3 = wb.Document
                Dim htmltitle As IHTMLTitleElement = d.getElementsByTagName("title").item(0)
                Dim title = htmltitle.text

                If title IsNot Nothing Then
                    Select Case title.Trim.ToUpper
                        Case "MENU DELLE APPLICAZIONI"
                            If mCodiceFiscale4Essig IsNot Nothing Then
                                Naviga(WbEssig, LoginEssig.UrlBase & "essigSC/start.do?itemId=0101000000&parametri=SC++SC")
                            End If
                        Case "SITUAZIONE CLIENTE - RICERCA ANAGRAFICA"
                            If mCodiceFiscale4Essig IsNot Nothing Then
                                Naviga(wb, LoginEssig.UrlBase & "essigSC/danni/situazionecliente/pagina00.do?nomePaginaAlbero=&flagDatiCambiati=&agenzia.value=" & Val(Utx.Globale.AgenziaRichiesta.CodiceAgenzia) &
                                       "&descrizioneAgenzia.value=&codiceFiscale.value=" & mCodiceFiscale4Essig & "&cognomeRagSociale.value=&ACTIONBUTTON018=Conferma")
                                mCodiceFiscale4Essig = Nothing
                            End If
                        Case "SITUAZIONE CLIENTE - DETTAGLIO"
                            If mVaiaIncasso4Essig Then
                                mVaiaIncasso4Essig = False
                                Dim parametri As String = String.Format("ACTIONBUTTON050=Albero&nomePaginaAlbero=AJMAP016&compagnia.value=1&agenzia.value={0}&codiceFiscale.value={1}",
                                                                        Val(Utx.Globale.AgenziaRichiesta.CodiceAgenzia), mCodiceFiscale)
                                Naviga(wb, LoginEssig.UrlBase & "essigSC/danni/situazionecliente/pagina03.do?" + parametri)
                            Else
                                Cattura.DaEssig(wb.Document)
                            End If
                        Case Else
                            Cattura.DaEssig(wb.Document)
                    End Select
                End If
                tssMessaggio.Text = ""
            End If
        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
        End Try
        wb.Tag = Nothing
    End Sub

    Private Sub wbEssig_NewWindow2(sender As Object, e As DWebBrowserEvents2_NewWindow2Event)
        Dim f As New UtControls.FormPopUp
        e.ppDisp = f.wbPopUp.Application
        f.Visible = True
    End Sub

    Private Sub wbCrm_DocumentComplete(sender As Object, e As AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEvent) Handles WbCrm.DocumentComplete
        Dim wb As AxWebBrowser = sender

        Try
            If wb.Document IsNot Nothing AndAlso DirectCast(wb.Document, mshtml.HTMLDocument).readyState <> "complete" Then
                Exit Sub
            ElseIf IO.Path.GetFileName(e.uRL) = "ut_wait.html" Then
                If LoginCRM.IsLogged Then
                    Utx.Globale.Log.Info("imposto cookies per il browser - wbCrm_DocumentComplete")
                    Utx.Autenticazione.SetCookies(Utx.AutenticazioneCRM.UrlBase, LoginCRM.CookieContainer)
                    Naviga(wb, LoginCRM.LoggedUrl)
                Else
                    bwLogin.RunWorkerAsync(LoginCRM)
                End If
            Else
                Dim d As IHTMLDocument3 = wb.Document
                Dim htmltitle As IHTMLTitleElement = d.getElementsByTagName("title").item(0)
                Dim title = htmltitle.text

                If title IsNot Nothing Then
                    title = title.Trim.ToUpper
                    Select Case title
                        Case "GESTIONE DELLA RELAZIONE CON LA CLIENTELA"
                            Dim partyidref As String = Nothing
                            For Each a In d.getElementsByTagName("a")
                                With CType(a, IHTMLAnchorElement)
                                    If .href IsNot Nothing AndAlso .href.Contains("?partyId=") Then
                                        partyidref = .href
                                        Exit For
                                    End If
                                End With
                            Next

                            If partyidref IsNot Nothing Then
                                Naviga(wb, partyidref)
                            End If
                    End Select
                End If
                tssMessaggio.Text = ""
            End If
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Exclamation, Ut.Globale.TitoloApp)
        End Try
        wb.Tag = Nothing
    End Sub

    Private Sub Naviga(sender As AxWebBrowser, url As String)
        sender.Silent = True
        sender.Tag = url
        sender.Navigate(url)
        Application.DoEvents()
    End Sub

    Private Sub labelIncassi_Click(sender As Object, e As EventArgs) Handles labelIncassi.Click
        If SplitContainer1.Panel2Collapsed = True Then
            labelIncassi.Text = "chiudi incassi >>"
            SplitContainer1.Panel2Collapsed = False
        Else
            labelIncassi.Text = "vedi incassi <<"
            SplitContainer1.Panel2Collapsed = True
        End If
    End Sub

    Private Sub ButtonUeba_Click(sender As Object, e As EventArgs) Handles ButtonUeba.Click

        Dim Pagina As UtControls.Ueba = UtControls.Ueba.PaginaUeba(TabClienti)

        If Pagina Is Nothing Then

            TabPageUeba = New UtControls.Ueba
            TabPageUeba.Text = String.Format("Ueba")

            TabClienti.Controls.Add(TabPageUeba)
            TabClienti.SelectedTab = TabPageUeba

            If TabPageUeba.EsistePaginaWeb = False Then
                If LoginUniage.IsLogged Then
                    TabPageUeba.Naviga(LoginUniage.LoggedUrl)
                Else
                    bwLogin.RunWorkerAsync(LoginUniage)
                End If
            End If
        Else
            TabClienti.SelectedTab = Pagina
        End If
    End Sub

    Private Sub ButtonOWA_Click(sender As Object, e As EventArgs) Handles ButtonOWA.Click
        Dim Pagina As UtControls.OWA = UtControls.OWA.PaginaOWA(TabClienti)

        If Pagina Is Nothing Then

            Pagina = New UtControls.OWA

            TabClienti.Controls.Add(Pagina)
            TabClienti.SelectedTab = Pagina
        Else
            TabClienti.SelectedTab = Pagina
        End If
        Pagina.Naviga()
    End Sub

    Private Sub ButtonQuota_Click(sender As Object, e As EventArgs) Handles ButtonQuota.Click
        If AssertSelezioneCliente() Then
            Utx.Servizi.AvviaQuotatore(mCodiceFiscale)
        End If
    End Sub

    Private Sub NavigateToEssig()
        Application.DoEvents()
        If LoginEssig.IsLogged Then
            If wbEssig.Document Is Nothing Then
                Utx.Globale.Log.Info("imposto cookies per il browser - NavigateToEssig")
                Utx.Autenticazione.SetCookies(LoginEssig.UrlBase, LoginEssig.CookieContainer)
                Naviga(WbEssig, LoginEssig.UrlBase)
            End If
        Else
            Naviga(wbEssig, IO.Path.Combine(Utx.Globale.Paths.CartellaModelli, "ut_wait.html"))
            Application.DoEvents()
        End If
    End Sub

    Private Sub NavigateToCrm()
        Application.DoEvents()
        If LoginCRM.IsLogged Then
            If WbCrm.Document Is Nothing Then
                Utx.Globale.Log.Info("imposto cookies per il browser - NavigateToCrm")
                Utx.Autenticazione.SetCookies(Utx.AutenticazioneCRM.UrlBase, LoginCRM.CookieContainer)
                Naviga(WbCrm, LoginCRM.LoggedUrl)
            End If
        Else
            Naviga(WbCrm, IO.Path.Combine(Utx.Globale.Paths.CartellaModelli, "ut_wait.html"))
        End If
        Application.DoEvents()
    End Sub

#Region "Eventi Combo ricerche"

    Private Sub ComboBoxCercaIn_TextChanged(sender As Object, e As EventArgs)
        RemoveHandlerControl()
        Try
            If ComboBoxCercaIn.Text.Trim.Length > 0 Then
                'quando cerco con chiave di ricerca vado sempre su elenco da selezione
                If CheckBoxTutti.Checked = True Then
                    CheckBoxTutti.Checked = False
                End If

                TimerCerca.Enabled = False
                TimerCerca.Enabled = (Utx.Globale.RitardoTimer > 0)
            Else
                TimerCerca.Enabled = False
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
        AddHandlerControl()
    End Sub

    Private Sub ComboBoxCercaIn_DropDown(sender As Object, e As EventArgs) Handles ComboBoxCercaIn.DropDown
        With ComboBoxCercaIn
            .Items.RemoveAt(0)
            .BackColor = Color.LightYellow
            .ForeColor = Color.Black
            .Font = Utx.AppFont.Normal
        End With
    End Sub

    Private Sub ComboBoxCercaIn_DropDownClosed(sender As Object, e As EventArgs) Handles ComboBoxCercaIn.DropDownClosed
        With ComboBoxCercaIn
            .Items.Insert(0, KeyValuePairEmpty)
            .BackColor = Color.Black
            .ForeColor = Color.Yellow
            .Font = Utx.AppFont.Bold
        End With
    End Sub

    Private Sub ComboBoxCercaIn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ComboBoxCercaIn.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            AggiornaQuery()
        Else
            Select Case Asc(e.KeyChar)
                Case 8, 32, 39, 46, 48 To 57, 47, 64 To 90, 97 To 122
                    'backspace,spazio,numeri, lettere e @
                    e.KeyChar = e.KeyChar.ToString.ToUpper
                Case 22 '^V (incolla)
                    'non fare niente
                Case Else
                    e.KeyChar = ""
            End Select
        End If
    End Sub

    Private Sub ComboBoxCercaIn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxCercaIn.SelectedIndexChanged
        If ComboBoxCercaIn.SelectedIndex > 0 Then
            LabelCerca.Text = ComboBoxCercaIn.SelectedItem.Value
            ComboBoxCercaIn.Tag = ComboBoxCercaIn.SelectedItem.key
            ComboBoxCercaIn.SelectedIndex = 0
        End If
    End Sub

    Private Sub ComboBoxCercaIn_GotFocus(sender As Object, e As EventArgs)
        ComboBoxCercaIn.SelectionStart = ComboBoxCercaIn.Text.Length
        ComboBoxCercaIn.SelectionLength = 0
    End Sub
#End Region

    Private Sub ButtonSinistri_Click(sender As Object, e As EventArgs) Handles ButtonSinistri.Click
        RaiseEvent RichiestaSinistri()
    End Sub

    Private Sub ButtonSinistriCliente_Click(sender As Object, e As EventArgs) Handles ButtonSinistriCliente.Click
        If String.IsNullOrEmpty(mCodiceFiscale) Then
            MsgBox("Seleziona prima un cliente", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
        Else
            RaiseEvent RichiestaSinistriCliente(mCodiceFiscale)
        End If
    End Sub

    Public Sub SelezionaClientePerCodiceFiscale(CodiceFiscale As String)
        RemoveHandlerControl()
        ShowTabPageElenco = False
        'ComboBoxCercaIn.SelectedIndex = 3
        'ComboBoxCercaIn.Items(0) = New KeyValuePair(Of String, String)("", CodiceFiscale)
        AggiornaQuery(CodiceFiscale)
        If mCodiceFiscale = CodiceFiscale Then
            TabClienti.SelectedTab = TabPageDettaglio
        End If
        ShowTabPageElenco = True
        AddHandlerControl()
    End Sub

    Private Sub DettaglioCliente_CodiceFiscaleChanged(CodiceFiscale As String) Handles DettaglioCliente.CodiceFiscaleChanged
        If mCodiceFiscale <> CodiceFiscale Then
            SelezionaClientePerCodiceFiscale(CodiceFiscale)
        End If
    End Sub

    Private Sub NoteSinistro_TipoNotaChanged(Tipo As Utx.Nota.TipoNota) Handles NoteSinistro.TipoNotaChanged
        NoteSinistro.LeggiNote()
    End Sub

    Private Sub ButtonAssegni_Click(sender As Object, e As EventArgs) Handles ButtonAssegni.Click
        Utx.Servizi.AvviaGestioneAssegni()
    End Sub

    Private Sub ButtonLayout_Click(sender As Object, e As EventArgs) Handles ButtonLayout.Click
        ElencoClienti.ImpostaLayout()
    End Sub

    Private Sub ButtonCopia_Click(sender As Object, e As EventArgs) Handles ButtonCopia.Click
        Try
            If String.IsNullOrEmpty(mCodiceFiscale) Then
                MsgBox("Seleziona prima un cliente.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                ComboBoxCercaIn.Focus()
            Else
                Using f As New UtControls.FormCopiaDati
                    f.CodiceFiscale = mCodiceFiscale
                    f.ShowDialog()
                End Using
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub FormFiltro_EliminatoLayout(NomeLayout As String) Handles FormFiltro.EliminatoLayout
        'ricarica layout nel combo e applica il predefinito
        RemoveHandler ComboBoxLayout.SelectedIndexChanged, AddressOf ComboBoxLayout_SelectedIndexChanged
        ComboBoxLayout.DataSource = Nothing

        AddHandler ComboBoxLayout.SelectedIndexChanged, AddressOf ComboBoxLayout_SelectedIndexChanged
        LayoutClienti.LeggiListaLayout()
        ComboBoxLayout.DataSource = LayoutClienti.ListaLayout
        ComboBoxLayout.SelectedIndex = 0

    End Sub

    Private Sub FormFiltro_SalvatoLayout(NomeLayout As String) Handles FormFiltro.SalvatoLayout
        'se è cambiato il layout
        If ComboBoxLayout.Text <> NomeLayout Then
            'ricarica layout nel combo e applica il predefinito
            RemoveHandler ComboBoxLayout.SelectedIndexChanged, AddressOf ComboBoxLayout_SelectedIndexChanged
            ComboBoxLayout.DataSource = Nothing

            AddHandler ComboBoxLayout.SelectedIndexChanged, AddressOf ComboBoxLayout_SelectedIndexChanged
            LayoutClienti.LeggiListaLayout()
            ComboBoxLayout.DataSource = LayoutClienti.ListaLayout
            ComboBoxLayout.SelectedIndex = 0
        End If
    End Sub

    Private Sub ButtonDocumenti_Click(sender As Object, e As EventArgs) Handles ButtonDocumenti.Click
        Try
            If String.IsNullOrEmpty(mCodiceFiscale) Then
                MsgBox("Seleziona prima un cliente.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Exit Sub
            Else
                FormDocumenti = Utx.OggettoForm.Esiste(Utx.OggettoForm.TipoForm.DOCUMENTI)

                If FormDocumenti Is Nothing Then
                    FormDocumenti = New UnitoolsDocumenti.FormDocumenti
                End If

                AddHandler FormDocumenti.ActivateDoc, AddressOf FormDocumenti_ActivateDoc
                AddHandler FormDocumenti.CloseDoc, AddressOf FormDocumenti_CloseDoc

                With FormDocumenti
                    If (TabClienti.SelectedTab Is TabPagePolizzeIncassi) AndAlso (GrigliaPolizze.CurrentRow IsNot Nothing) Then
                        .CodiceFiscale = mCodiceFiscale
                        .NomeCliente = LabelNominativo.Text
                        .Ramo = GrigliaPolizze.CurrentRow.Cells("Ramo").Value
                        .Polizza = GrigliaPolizze.CurrentRow.Cells("Polizza").Value
                        .CartellaAllegati = ""
                    Else
                        .CodiceFiscale = mCodiceFiscale
                        .NomeCliente = LabelNominativo.Text
                        .CartellaAllegati = ""
                    End If
                End With
                Utx.OggettoForm.Show(Utx.OggettoForm.TipoForm.DOCUMENTI)
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub tssMessaggio_TextChanged(sender As Object, e As EventArgs) Handles tssMessaggio.TextChanged
        Application.DoEvents()
    End Sub

    Private Sub Cattura_CatturatoCliente(codicefiscale As String) Handles Cattura.CatturatoCliente
        DettaglioCliente_CodiceFiscaleChanged(codicefiscale)
    End Sub

    Private Sub ButtonEvidenzeCliente_Click(sender As Object, e As EventArgs) Handles ButtonEvidenzeCliente.Click
        If String.IsNullOrEmpty(mCodiceFiscale) Then
            MsgBox("Seleziona prima un cliente.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            Exit Sub
        Else
            Utx.Servizi.AvviaEvidenze(Cf:=mCodiceFiscale)
        End If
    End Sub

    Private Sub ButtonEvidenza_Click(sender As Object, e As EventArgs) Handles ButtonEvidenza.Click
        If TabClienti.SelectedTab Is TabPagePolizzeIncassi Then
            If GrigliaPolizze.CurrentRow IsNot Nothing Then
                Utx.Servizi.AvviaEvidenze("POLIZZA", NumeroDoc:=String.Format("{0}/{1}/{2}",
                                                                             GrigliaPolizze.CurrentRow.Cells("Agenzia").Value,
                                                                             GrigliaPolizze.CurrentRow.Cells("Ramo").Value,
                                                                             GrigliaPolizze.CurrentRow.Cells("Polizza").Value))
            End If
        End If
    End Sub

    Private Function StampaAttivita(Inizio As Date, Fine As Date) As String
        Try
            Dim dt As DataTable
            Using s As New Utx.ServiziOMW.ServizioDatiOMW
                s.Proxy = Utx.Globale.UniProxy.Proxy
                dt = s.ElencoAttivitaInScadenzaClienti(Utx.Globale.AgenziaRichiesta.CodiceAgenzia, Inizio, Fine, Utx.Globale.Token).Tables(0)
            End Using

            Dim AntHtml As New Utx.PaginaHtml(String.Format("Attivita_{0}", Format(Today, "ddMMyyyy")))

            If dt.Rows.Count > 0 Then
                Dim PrepIn As String = ""
                For Each dr As DataRow In dt.Rows
                    PrepIn &= String.Format("'{0}',", dr("CodiceFiscale"))
                Next
                PrepIn = PrepIn.Substring(0, PrepIn.Length - 1)

                Dim Query As String = String.Format("SELECT DISTINCT TRIM(Cognome) + ' ' + TRIM(Nome) AS Assicurato,CodiceFiscale 
                    FROM Clienti 
                    WHERE CodiceFiscale IN ({0})", PrepIn)

                Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteNonQuery(Query)
                Dim dtClienti As DataTable

                If Risposta IsNot Nothing Then
                    dtClienti = Risposta.DataTable
                    dtClienti.PrimaryKey = {dtClienti.Columns("CodiceFiscale")}

                    With AntHtml
                        .Size = Utx.PaginaHtml.TextSize.medium
                        .Titolo = "Attività in scadenza"
                        .AddRow(String.Format("Attività in scadenza dal {0:d} al {1:d}", Inizio, Fine), Grassetto:=True)
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
                            .AddRow(Format(dt.Rows(k)("Allarme"), "dddd dd-MM-yyyy:"), Grassetto:=True, ColoreTesto:=Utx.PaginaHtml.Colori.AZZURRO)
                            .AddRow()

                            For j = k To dt.Rows.Count - 1
                                If dt.Rows(j)("Allarme") <> Giorno Then
                                    Exit For
                                End If
                                k = j

                                Progressivo += 1
                                .Tab = 1

                                Dim Assicurato As DataRow = dtClienti.Rows.Find({dt.Rows(j)("CodiceFiscale")})

                                'numero sinistro e utente
                                If IsNothing(Assicurato) Then
                                    .AddRow(String.Format("{3} - Assicurato: <strong>{0}</strong> ({1}) - (Autore: {2})",
                                                              "non disponibile", dt.Rows(j)("CodiceFiscale"), dt.Rows(j)("Utente"), Progressivo))
                                Else
                                    .AddRow(String.Format("{3} - Assicurato: <strong>{0}</strong> ({1}) - (Autore: {2})",
                                                              Assicurato("Assicurato"), dt.Rows(j)("CodiceFiscale"), dt.Rows(j)("Utente"), Progressivo))
                                End If
                                'corpo nota
                                .Tab = 2
                                Dim Righe() As String = dt.Rows(j)("Memo").ToString.Split(Environment.NewLine)

                                For Each r As String In Righe
                                    .AddRow(Utx.NetFunc.EstraiCaratteri(r, Utx.NetFunc.TipoCaratteri.SoloCaratteriStampabili))
                                Next
                                'riga vuota
                                .AddRow()
                            Next
                            AntHtml.AddLine() 'riga per chiudere la giornata
                        Next
                    End With
                End If
            Else
                AntHtml.AddRow("Nessuna scadenza nel periodo selezionato.")
            End If

            'crea il file
            AntHtml.CreaFileHtml()
            'ritorna il path
            Return AntHtml.NomeFile

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Private Sub ButtonNoteAttivita_Click(sender As Object, e As EventArgs) Handles ButtonNoteAttivita.Click
        Using f As New UtControls.FormAttivita
            f.ShowDialog()

            Select Case f.DialogResult
                Case Windows.Forms.DialogResult.Cancel
                Case Windows.Forms.DialogResult.OK
                    'elenco in griglia
                    AggiornaQuery(f.InizioPeriodo, f.FinePeriodo)
                Case Windows.Forms.DialogResult.Yes
                    'stampa
                    Using Anteprima As New UtControls.FormAnteprima
                        Anteprima.NomeFile = StampaAttivita(f.InizioPeriodo, f.FinePeriodo)
                        Anteprima.ShowDialog()
                        'cancello il file di anteprima
                        IO.File.Delete(Anteprima.NomeFile)
                    End Using
            End Select
        End Using
    End Sub

    Private Sub bwLogin_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwLogin.DoWork
        'tssMessaggio.Text = "Login in corso ..."
        'e.Argument.login()
        'e.Result = e.Argument
        Utx.Autenticazione.SetCookies("https://essig.unipolsai.it", Utx.Globale.LoginUniage.CookieContainer)
        WbEssig.Navigate("https://essig.unipolsai.it")
    End Sub

    Private Sub bwLogin_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwLogin.RunWorkerCompleted
        Exit Sub
        'Select Case e.Result.Stato
        '    Case Utx.Autenticazione.StatoLogin.LOGIN
        '        tssMessaggio.Text = "Carico portale ..."

        '        If e.Result.Equals(LoginEssig) Then
        '            Utx.Globale.Log.Info("imposto cookies per il browser - bwLogin_RunWorkerCompleted")
        '            Utx.Autenticazione.SetCookies(LoginEssig.UrlBase, LoginEssig.CookieContainer)
        '            WbEssig.Navigate(LoginEssig.LoggedUrl)
        '        ElseIf e.Result.Equals(LoginCRM) Then
        '            Utx.Globale.Log.Info("imposto cookies per il browser - bwLogin_RunWorkerCompleted")
        '            Utx.Autenticazione.SetCookies(Utx.AutenticazioneCRM.UrlBase, LoginCRM.CookieContainer)
        '            WbCrm.Navigate(LoginCRM.LoggedUrl)
        '        ElseIf e.Result.Equals(LoginUniage) Then
        '            TabPageUeba.Naviga(LoginUniage.LoggedUrl)
        '            tssMessaggio.Text = ""
        '        End If
        '    Case Utx.Autenticazione.StatoLogin.RETE_NON_DISPONIBILE
        '        tssMessaggio.Text = "Portale non raggiungibile"
        '    Case Else
        '        tssMessaggio.Text = "Login fallito"
        'End Select
    End Sub

    Private Sub ButtonPulisciCasellaCerca_Click(sender As Object, e As EventArgs) Handles ButtonPulisciCasellaCerca.Click
        ComboBoxCercaIn.Items(0) = KeyValuePairEmpty
        ComboBoxCercaIn.Text = vbNullString
        AggiornaQuery()
        ComboBoxCercaIn.Focus()
    End Sub

    Private Sub ButtonLegami_Click(sender As Object, e As EventArgs) Handles ButtonLegami.Click
        If String.IsNullOrEmpty(mCodiceFiscale) Then
            MsgBox("Seleziona prima un cliente.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
        Else
            TabClienti.SelectedTab = TabPageElenco

            Using f As New FormLegami
                f.CodiceFiscale = mCodiceFiscale
                f.NomeCompleto = ElencoClienti.dgvClienti.CurrentRow.Cells("Cliente").Value
                f.ShowDialog()

                Select Case f.DialogResult
                    Case Windows.Forms.DialogResult.OK 'imposta capofamiglia
                        ImpostaCapofamiglia(f.CapofamigliaCF)
                    Case Windows.Forms.DialogResult.Yes 'imposta ente
                        ImpostaEnte(f.EnteCF)
                    Case Windows.Forms.DialogResult.Retry 'elimina legami
                        EliminaLegami()
                End Select
            End Using
        End If
    End Sub

    Private Sub ImpostaCapofamiglia(CapofamigliaCF As String)
        Try
            'imposta il capofamiglia
            Dim Query As String = String.Format("UPDATE Clienti 
                SET CodiceFiscaleCF = '{0}', Capofamiglia = 'N' 
                WHERE CodiceFiscale = '{1}'", CapofamigliaCF, mCodiceFiscale)
            Utx.WsCommand.ExecuteNonQuery(Query)
            'imposta come capofamiglia
            Query = String.Format("UPDATE Clienti 
                SET CodiceFiscaleCF = '{0}', Capofamiglia = 'S'
                WHERE CodiceFiscale = '{0}'", CapofamigliaCF)
            Utx.WsCommand.ExecuteNonQuery(Query)
            'per aggiornare la griglia
            ElencoClienti.dgvClienti.CurrentRow.Cells("CodiceFiscaleCF").Value = CapofamigliaCF
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ImpostaEnte(EnteCF As String)
        Try
            'imposta l'ente
            Dim Query As String = String.Format("UPDATE Clienti 
                SET CodiceFiscaleEA = '{0}' 
                WHERE CodiceFiscale = '{1}'", EnteCF, mCodiceFiscale)
            Utx.WsCommand.ExecuteNonQuery(Query)
            'imposta l'ente anche per l'ente stesso
            Query = String.Format("UPDATE Clienti SET CodiceFiscaleEA = '{0}' WHERE CodiceFiscale = '{0}'", EnteCF)
            Utx.WsCommand.ExecuteNonQuery(Query)
            'per aggiornare la griglia
            ElencoClienti.dgvClienti.CurrentRow.Cells("CodiceFiscaleEA").Value = EnteCF
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub EliminaLegami()
        Try
            Dim Query As String = String.Format("UPDATE Clienti 
                SET CodiceFiscaleCF = '',Capofamiglia = 'X',CodiceFiscaleEA = '' 
                WHERE CodiceFiscale = '{0}'", mCodiceFiscale)
            Utx.WsCommand.ExecuteNonQuery(Query)
            'per aggiornare la griglia
            With ElencoClienti.dgvClienti.CurrentRow
                .Cells("CodiceFiscaleCF").Value = ""
                .Cells("CodiceFiscaleEA").Value = ""
            End With
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub DettaglioCliente_RichiestaMappa() Handles DettaglioCliente.RichiestaMappa
        Utx.Servizi.AvviaMappa(ElencoClienti.dgvClienti.CurrentRow.Cells("Indirizzo").Value,
                              ElencoClienti.dgvClienti.CurrentRow.Cells("Localita").Value,
                              "IT",
                              ElencoClienti.dgvClienti.CurrentRow.Cells("Cap").Value)
    End Sub

    Private Sub ButtonAci_Click(sender As Object, e As EventArgs) Handles ButtonAci.Click
        Try
            If TabClienti.SelectedTab IsNot TabPagePolizzeIncassi Or
                GrigliaPolizze.CurrentRow Is Nothing Then
                MsgBox("Selezionare una polizza nella scheda Polizze e Incassi.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Exit Sub
            End If

            Dim Targa As String = Utx.FunzioniDb.NullToString(GrigliaPolizze.CurrentRow.Cells("targa").Value)

            If String.IsNullOrEmpty(Targa) Then
                MsgBox("Targa non disponibile: impossibile eseguire la visura", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            Else
                Dim bm As BindingManagerBase = GrigliaPolizze.BindingContext(GrigliaPolizze.DataSource, GrigliaPolizze.DataMember)
                Dim dr As DataRow = CType(bm.Current, DataRowView).Row
                Using f As New Visure.FormVisure
                    f.Targa = Targa
                    f.ClasseVeicolo = dr.Item("ClasseRca")
                    'cartella dei doc della polizza
                    Dim deposito As New UnitoolsDocumenti.DepositoPratica(mCodiceFiscale, dr.Item("Ramo"), dr.Item("Polizza"))
                    f.PathDocumenti = deposito.FullPathPratica 'documenti della polizza
                    f.ShowDialog()
                End Using
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub FormDocumenti_ActivateDoc()
        If Me.WindowState <> FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Minimized
        End If
    End Sub

    Private Sub FormDocumenti_CloseDoc()
        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Public Sub ButtonReset_Click(sender As Object, e As EventArgs) Handles ButtonReset.Click
        Try
            ComboBoxCercaIn.Text = ""
            CheckBoxEsatto.Checked = True
            CheckBoxTutti.Checked = False
            LabelNominativo.Text = ""
            LabelIndirizzo.Text = ""
            ComboBoxStatoCliente.SelectedIndex = 0
            ComboBoxCercaIn.SelectedIndex = 1
            ElencoClienti.dgvClienti.DataSource = Nothing
            Me.Text = String.Format("Clienti {0}", Utx.Globale.AgenziaRichiesta.CodiceAgenzia)
            ComboBoxCercaIn.Focus()

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub CaricaArretrati()
        If mCodiceFiscale.Equals(GrigliaArretrati.Tag) = False Then
            With GrigliaArretrati
                .DataSource = Nothing
                .Rows.Clear()
                .Columns.Clear()
                .Refresh()
                .Columns.Add("Arretrati", "Arretrati")
                .Columns(.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Rows.Add({"Aggiornamento in corso ... (essig)"})
            End With

            If bwArretrati.IsBusy Then
                bwArretrati.CancelAsync()
            Else
                bwArretrati.WorkerSupportsCancellation = True
                bwArretrati.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub bwArretrati_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwArretrati.DoWork
        e.Result = Arretrati.GetArretratiAsList(LoginEssig, 1, Val(Utx.Globale.AgenziaRichiesta.CodiceAgenzia), mCodiceFiscale)
    End Sub

    Private Sub bwArretrati_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwArretrati.RunWorkerCompleted

        RemoveHandler GrigliaArretrati.SelectionChanged, AddressOf GrigliaArretrati_SelectionChanged

        With GrigliaArretrati
            .DataSource = Nothing
            .Rows.Clear()
            .Columns.Clear()
            .DataSource = e.Result
            .Columns(.Columns.Count - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            If .Columns.Count > 1 Then
                .Tag = mCodiceFiscale
                'formatta
                .Columns("Ramo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Effetto").HeaderText = "Eff.titolo"
                .Columns("Scadenza").HeaderText = "Scad.titolo"
                .Columns("Premio").HeaderText = "Premio totale arretrato"
                .Columns("Premio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Rows(.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Gainsboro
                .Rows(.Rows.Count - 1).DefaultCellStyle.Font = Utx.AppFont.Bold

                If GrigliaArretrati.Rows.Count > 1 Then
                    AddHandler GrigliaArretrati.SelectionChanged, AddressOf GrigliaArretrati_SelectionChanged
                End If
            Else
                .Tag = Nothing
            End If

            .Rows(0).Selected = False
            .Refresh()
        End With
    End Sub

    Private Sub GrigliaArretrati_SelectionChanged(sender As Object, e As EventArgs)
        Try
            Dim Somma As Single = 0
            For Each row As DataGridViewRow In GrigliaArretrati.SelectedRows
                If row.Cells("Scadenza").Value <> "TOTALE" Then Somma += row.Cells("Premio").Value
            Next
            LabelTitoloArretrati.Text = String.Format("Arretrati (selezionati {0})", Format(Somma, "###,##0.00"))
        Catch ex As Exception
            LabelTitoloArretrati.Text = "Arretrati (selezionati ND)"
        End Try
    End Sub

    Private Sub LabelStorico_Click(sender As Object, e As EventArgs) Handles LabelStorico.Click
        CaricaPolizze(storico:=(LabelStorico.Text = "passa a storico"))
    End Sub

    Private Sub FormAnagrafiche_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        LoginEssig = Nothing
    End Sub

    Private Sub DettaglioCliente_RichiestaScansione() Handles DettaglioCliente.RichiestaScansione
        ButtonDocumenti.PerformClick()
    End Sub

    Private Sub FormDocumenti_ModificaDocumenti() Handles FormDocumenti.ModificaDocumenti
        Select Case TabClienti.SelectedTab.Name
            Case TabPageDettaglio.Name
                DettaglioCliente.ImpostaDocumenti()
            Case TabPagePolizzeIncassi.Name
                CaricaDocumentiPolizza()
            Case TabPageNote.Name
                NoteSinistro.CartellaDocumenti = New UnitoolsDocumenti.DepositoPratica(mCodiceFiscale).FullPathPratica
        End Select
    End Sub

    Private Sub ButtonCambiaAgenzia_Click(sender As Object, e As EventArgs) Handles ButtonCambiaAgenzia.Click
        RaiseEvent RichiestaCambioAgenzia()
    End Sub

    Public Sub AggiornaBottoneCodice()
        ButtonCambiaAgenzia.Text = Utx.Globale.AgenziaRichiesta.CodiceAgenzia & " - Cambia codice"
    End Sub

    Private Sub TabPageDettaglio_VisibleChanged(sender As Object, e As EventArgs) Handles TabPageDettaglio.VisibleChanged
        If TabPageDettaglio.Visible = True Then
            TabPageDettaglio.Refresh()
        End If
    End Sub
End Class