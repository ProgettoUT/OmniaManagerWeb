Imports System.ComponentModel

Public Class FormPostalizzazione

    Public Event RichiestaArretrati(Agenzia As AgenziaConfigPostalizzazione, InizioPeriodo As Date, FinePeriodo As Date)
    Public Event ServizioAttivato()
    Private Event ModificaConfigUT()
    Private Event ModificaSelezionati()

    Public Enum Modalita
        CONFIG
        AVVISI
        TRACKING
    End Enum

    Private WithEvents AgenziaAvvisi As AgenziaConfigPostalizzazione
    Private WithEvents Avvisi As UniCom.Koine.Avvisi
    Private WithEvents bw As BackgroundWorker
    Private WithEvents TimerAttivazione As Timer
    Private ReadOnly CodiciAbilitatiUT As New List(Of AgenziaConfigPostalizzazione)
    Private ReadOnly Immagini As New ImageList
    Private mNonSelezionati As Integer

    Private ThreadVerificaClienti As Threading.Thread
    Private Cts As Threading.CancellationTokenSource

    Friend WithEvents FormFiltro As New Utx.FormGestioneFiltro(1000)

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.WindowState = FormWindowState.Maximized
        Me.Font = Utx.AppFont.Normal
        Me.Icon = Risorse.Immagini.Icon("aua")
        Me.Text = "Postalizzazione AUA Soluzioni"
        Me.BackColor = Color.White
        Me.BackgroundImage = Risorse.Immagini.Image("logo_aua_small")
        Me.BackgroundImageLayout = ImageLayout.Center

        'creo blocco
        Using s As New Utx.SettingAgenzia.ConfiguraSede With {.Proxy = Utx.Globale.UniProxy.Proxy}
            s.CreaBloccoPostalizzazione(Utx.Globale.ProfiloEnteGestore.AgenziaMadre, Utx.Globale.UtenteCorrente.UserAndPc)
        End Using

        ImpostaControlli()
    End Sub

    Private mTipochiamata As Modalita
    Public Property TipoChiamata() As Modalita
        Get
            Return mTipochiamata
        End Get
        Set(value As Modalita)
            mTipochiamata = value
        End Set
    End Property

    Private Sub ImpostaControlli()
        Me.Controls.Remove(TabMain)
        TabMain.ItemSize = New Size(250, 50)

        Immagini.Images.Add(Risorse.Immagini.Bitmap("esci"))
        TabMain.ImageList = Immagini
        TabPageAvvisi.ImageKey = "esci"

        Dim tt As New ToolTip

        'tab config
        With LabelAgenziaConfig
            .Font = Utx.AppFont.Extra(11, FontStyle.Regular)
            .BackColor = Color.Gainsboro
            .Text = "Codice agenzia"
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        With ComboBoxAgenziaConfig
            .Font = Utx.AppFont.Extra(11, FontStyle.Regular)
            .DropDownStyle = ComboBoxStyle.DropDownList
            .Margin = New Padding(0)
            .FlatStyle = FlatStyle.Popup
            .ForeColor = Utx.AppColor.RossoScuro
        End With
        With LabelMessaggioConfig
            .Font = Utx.AppFont.Extra(14, FontStyle.Regular)
            .BackColor = Color.Gainsboro
            .ForeColor = Utx.AppColor.RossoScuro
            .Text = ""
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With ButtonAggiornaCip
            .Dock = DockStyle.Fill
            .Margin = New Padding(0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .FlatAppearance.MouseOverBackColor = Color.Moccasin
            .Text = "Aggiorna CIP-Soggetti-Punti vendita"
        End With
        'track
        With LabelTrack
            .Font = Utx.AppFont.Extra(11, FontStyle.Regular)
            .BackColor = Utx.AppColor.GrigioAzzurro
            .Text = "Traccia i messaggi del codice"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With ComboBoxAgenziaTrack
            .Font = Utx.AppFont.Extra(11, FontStyle.Regular)
            .DropDownStyle = ComboBoxStyle.DropDownList
        End With
        'config UT
        With LabelConfigUT
            .FlatStyle = FlatStyle.Flat
            .Font = Utx.AppFont.Extra(14, FontStyle.Regular)
            .BackColor = Color.LightYellow
            .Text = String.Format("Qui potete decidere per quali codici, fra quelli gestiti, si desidera attivare la postalizzazione.{0}" +
                                  "(Questa scelta potrà essere modificata dall'utente in qualsiasi momento)", Environment.NewLine)
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With LabelCodiciAbilitati
            .Font = Utx.AppFont.Extra(11, FontStyle.Regular)
            .Text = "Postalizzazione abilitata per i codici:"
        End With
        CheckedListBoxAgenzieAbilitate.Font = Utx.AppFont.Extra(14, FontStyle.Regular)
        With LabelNotifica
            .Font = Utx.AppFont.Extra(11, FontStyle.Regular)
            .Text = "Indirizzo e-mail a cui verranno inviate le notifiche relative alla postalizzazione:"
        End With
        TextBoxMailNotifica.Font = Utx.AppFont.Extra(14, FontStyle.Regular)
        With LabelUtentiAbilitati
            .Font = Utx.AppFont.Extra(11, FontStyle.Regular)
            .Text = "Utenti abilitati a modificare la configurazione oltre gli agenti (separati da una virgola) es.101234ab:"
        End With
        TextBoxUtentiAbilitati.Font = Utx.AppFont.Extra(14, FontStyle.Regular)
        With ButtonSalvaConfigUT
            .Text = "Salva le modifiche alla configurazione"
            .Image = Risorse.Immagini.Bitmap("salva")
            .ImageAlign = ContentAlignment.MiddleRight
        End With
        With CheckBoxRID
            .Font = Utx.AppFont.Extra(11, FontStyle.Regular)
            .Text = "Non inviare avvisi per titoli pagati con RID"
            .TextAlign = ContentAlignment.BottomLeft
        End With
        With CheckBoxDomicilio
            .Font = Utx.AppFont.Extra(11, FontStyle.Regular)
            .Text = "Inviare gli avvisi al domicilio quando diverso dalla residenza"
            .TextAlign = ContentAlignment.BottomLeft
        End With
        With LabelInfoCoass
            .Font = Utx.AppFont.Extra(11, FontStyle.Regular)
            .FlatStyle = FlatStyle.Flat
            .BackColor = Color.Moccasin
            .Text = String.Format("L'invio degli avvisi per le polizze in COASS e dei rami 110-118-126-315 è disabilitato per default.{0}" +
                                  "Nel caso si voglia inviare l'avviso l'utente deve selezionare manualmente ed esplicitamente l'invio.", Environment.NewLine)
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        With LabelInfoCoass2
            .FlatStyle = FlatStyle.Flat
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = Color.Gainsboro
            .Text = LabelInfoCoass.Text
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        'invio avvisi
        With ComboBoxAgenzia
            .Font = Utx.AppFont.Extra(11, FontStyle.Bold)
            .DropDownStyle = ComboBoxStyle.DropDownList
        End With
        With LabelNumeroAvvisi
            .Margin = New Padding(0, 1, 0, 1)
            .FlatStyle = FlatStyle.Flat
            .Font = Utx.AppFont.Extra(10, FontStyle.Bold)
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = Color.White
            .Text = "..."
        End With
        tt.SetToolTip(LabelNumeroAvvisi, "scadenze selezionate/visualizzate")
        With LabelNumeroCoass
            .Margin = New Padding(0, 1, 0, 1)
            .FlatStyle = FlatStyle.Flat
            .Font = Utx.AppFont.Extra(10, FontStyle.Bold)
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = Color.Gainsboro
            .Text = "..."
        End With
        With LabelMese
            .Margin = New Padding(0, 1, 0, 1)
            .Font = Utx.AppFont.Extra(11, FontStyle.Bold)
            .ForeColor = Utx.AppColor.RossoScuro
            .BackColor = Color.White
        End With
        With LabelAgenzia
            .Margin = New Padding(0, 1, 0, 1)
            .Font = Utx.AppFont.Extra(11, FontStyle.Regular)
            .BackColor = Color.White
            .Text = "Codice agenzia"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With CheckBoxAggiornaDati
            .Margin = New Padding(0, 2, 0, 2)
            .Padding = New Padding(5, 0, 0, 0)
            .Font = Utx.AppFont.Extra(11, FontStyle.Regular)
            .TextAlign = ContentAlignment.BottomLeft
#If DEBUG Then
            .Checked = False
#Else
            .Checked = True
#End If
        End With
        With ButtonDeseleziona
            .Margin = New Padding(1)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .BackColor = Color.White
            .Text = "Deseleziona tutti"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = Risorse.Immagini.Bitmap("uncheck16")
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonSeleziona
            .Margin = New Padding(1)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .BackColor = Color.White
            .Text = "Seleziona tutti"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = Risorse.Immagini.Bitmap("check16")
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonVisualizza
            .Margin = New Padding(1)
            .Padding = New Padding(1, 1, 30, 1)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Visualizza titoli"
            .Image = Risorse.Immagini.Bitmap("view")
            .ImageAlign = ContentAlignment.MiddleRight
        End With
        With ButtonAggiungi
            .Margin = New Padding(1)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .BackColor = Color.White
            .Text = "Aggiungi scadenza"
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With ButtonElimina
            .Margin = New Padding(1)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .BackColor = Color.White
            .Text = "Elimina scadenza"
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With ButtonInvia
            .Margin = New Padding(1)
            .Padding = New Padding(1, 1, 30, 1)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Text = String.Format("Invia avvisi (manuale dal {0:dd-MM} al {1:dd-MM})",
                                  Postalizzazione.InizioPostalizzazioneManuale, Postalizzazione.InizioAutoPostalizzazione.AddDays(-1))
            .Image = Risorse.Immagini.Bitmap("ricevuta")
            .ImageAlign = ContentAlignment.MiddleRight
            .Enabled = False
        End With
        With ButtonEsporta
            .Margin = New Padding(1)
            .Padding = New Padding(10, 1, 10, 1)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Esporta in csv"
            .TextAlign = ContentAlignment.MiddleLeft
            .Image = Risorse.Immagini.Bitmap("csv")
            .ImageAlign = ContentAlignment.MiddleRight
        End With
        With LabelInfo
            .BorderStyle = BorderStyle.FixedSingle
            .Text = String.Format("Le selezioni/de-selezioni dell'utente vengono salvate automaticamente{0}" +
                                  "Gli avvisi selezionati vengono inviati alla postalizzazione dove sono lavorati in base alle personalizzazioni impostate dall'utente sul portale", Environment.NewLine)
            .TextAlign = ContentAlignment.MiddleLeft
            .BackColor = Color.Moccasin
        End With
        'With LabelRamo89
        '    .Padding = Utx.AppFont.ButtonPadding
        '    .Font = Utx.AppFont.Bold
        '    .BorderStyle = BorderStyle.FixedSingle
        '    .Text = ""
        '    .BackColor = Color.Gainsboro
        '    .ImageAlign = ContentAlignment.MiddleLeft
        '    .TextAlign = ContentAlignment.MiddleRight
        'End With
        'dettaglio cliente
        SplitContainer1.SplitterDistance = SplitContainer1.Width * 0.85
        SplitContainer1.Panel2Collapsed = True
        With CheckBoxDettaglioCliente
            .Margin = New Padding(0, 2, 0, 2)
            .Padding = New Padding(5, 0, 0, 0)
            .BackColor = Color.Gainsboro
            .Font = Utx.AppFont.Extra(11, FontStyle.Regular)
            .TextAlign = ContentAlignment.BottomLeft
            .Checked = False
        End With
        With LabelInfoCliente
            .Padding = New Padding(3)
            .BorderStyle = BorderStyle.FixedSingle
            .FlatStyle = FlatStyle.Flat
            .Font = Utx.AppFont.Extra(11, FontStyle.Regular)
            .BackColor = Color.WhiteSmoke
            .Text = "Dettaglio cliente:"
        End With

        With dgvAvvisi
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
        Utx.NetFunc.DoppioBuffer(dgvAvvisi)
        With dgvReport
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .MultiSelect = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .Font = Utx.AppFont.Extra(11, FontStyle.Regular)
        End With
        Utx.NetFunc.DoppioBuffer(dgvReport)
    End Sub

    Private Sub ImpostaCodiciAbilitatiUT()
        Try
            Cursor = Cursors.WaitCursor

            If Utx.Globale.ProfiloEnteGestore.Abilitazioni.POSTALIZZAZIONE = True Then

                Dim Chiave As New Utx.SettingItem(Utx.SettingItem.Sezioni.COMUNICATORE,
                                          Utx.SettingItem.Chiavi.COMUNICATORE_CODICI_ABILITATI,
                                          "", Utx.SettingOMW.TipoOperazione.LETTURA)

                If Chiave.ItemResult.Esiste Then
                    'riempio la lista dei codici abilitati in UT
                    CodiciAbilitatiUT.Clear()
                    For Each agenzia As String In Postalizzazione.CodiciAbilitatiUT
                        'Koine.Agenzia = agenzia
                        CodiciAbilitatiUT.Add(New AgenziaConfigPostalizzazione(agenzia)) 'qui verifica dello stato
                    Next
                End If
            End If

            'imposto i combo
            ComboBoxAgenzia.Items.Clear()
            ComboBoxAgenziaConfig.Items.Clear()
            ComboBoxAgenziaTrack.Items.Clear()
            For Each agenzia As AgenziaConfigPostalizzazione In CodiciAbilitatiUT
                ComboBoxAgenzia.Items.Add(agenzia)
                ComboBoxAgenziaConfig.Items.Add(agenzia)
                ComboBoxAgenziaTrack.Items.Add(agenzia)
            Next
            ComboBoxAgenzia.DisplayMember = "Agenzia"
            ComboBoxAgenziaConfig.DisplayMember = "Descrizione"
            ComboBoxAgenziaTrack.DisplayMember = "Agenzia"

        Catch ex As Exception
            Koine.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ImpostaTab()
        Try
            'rimuovo tutti i tab
            For Each t As TabPage In TabMain.TabPages
                TabMain.TabPages.Remove(t)
            Next
            'verifico lo stato di configurazione
            VerificaStatoconfig()
        Catch ex As Exception
            Koine.Log.Errore(ex)
        End Try
    End Sub

    Private Sub VerificaStatoconfig()
        Try
            Cursor = Cursors.WaitCursor
            Me.Controls.Remove(TabMain)
            TabMain.Dock = DockStyle.None
            TabMain.Location = New Point(-1000, -1000)

            RemoveHandler TabPageConfig.Enter, AddressOf TabPageConfig_Enter
            RemoveHandler TabPageConfigUT.Enter, AddressOf TabPageConfigUT_Enter
            RemoveHandler TabPageAvvisi.Enter, AddressOf TabPageAvvisi_Enter
            RemoveHandler TabPageTracking.Enter, AddressOf TabPageTracking_Enter

            If Utx.Globale.ProfiloEnteGestore.Abilitazioni.POSTALIZZAZIONE = False Then
                'il processo è cambiato e qui non dovrebbe più arrivare
                'i link https non esistono più su auaonline
                'procedere con l'attivazione
                TabMain.TabPages.Add(TabPageAttivazione)
                TabMain.ColorStyle = Utx.UtTabControl.TabColorStyle.AZZURRO
#If DEBUG Then
                wbAttivazione.Navigate(String.Format("https://ws.auaonline.it/confermaPostalizzazione.aspx?codiceagenzia={0}&codicefiscale={1}", "02379", "DMRMSM63S21D649I"))
#Else
                                If Utx.Globale.UtenteCorrente.IsAgente Then
                                    wbAttivazione.Navigate(String.Format("http://ws.auaonline.it/confermaPostalizzazione.aspx?codiceagenzia={0}&codicefiscale={1}",
                                                                         Utx.EnteGestore.StringaCodiciPostalizzati, Utx.Globale.UtenteCorrente.CodiceFiscale))
                                Else
                                    wbAttivazione.Navigate("https://ws.auaonline.it/Postalizzazione_nonAgente.aspx")
                                End If
#End If
            ElseIf CodiciAbilitatiUT.Count = 0 Then
                'è necessario abilitare i codici in UT
                TabMain.TabPages.Add(TabPageConfigUT)
                TabPageConfigUT_Enter(Me, New EventArgs)
                TabMain.TabPages.Add(TabPageGuida)
                AddHandler TabPageConfigUT.Enter, AddressOf TabPageConfigUT_Enter
                TabMain.ColorStyle = Utx.UtTabControl.TabColorStyle.ROSSO
            ElseIf AgenziaConfigPostalizzazione.ConfigEnte = False Then
                LabelMessaggioConfig.Text = "E' necessario completare la configurazione dei codici da postalizzare."
                Me.TipoChiamata = Modalita.CONFIG
                TabMain.TabPages.Add(TabPageConfig)
                TabMain.TabPages.Add(TabPageConfigUT)
                TabMain.TabPages.Add(TabPageGuida)
                ComboBoxAgenziaConfig.SelectedIndex = 0
                ComboBoxAgenziaConfig_SelectedIndexChanged(Me, New EventArgs)
                TabPageConfig_Enter(Me, New EventArgs)
                AddHandler TabPageConfig.Enter, AddressOf TabPageConfig_Enter
                AddHandler TabPageConfigUT.Enter, AddressOf TabPageConfigUT_Enter
                TabMain.ColorStyle = Utx.UtTabControl.TabColorStyle.ROSSO
            Else
                Select Case Me.TipoChiamata
                    Case Modalita.CONFIG
                        LabelMessaggioConfig.Text = ""
                        TabMain.TabPages.Add(TabPageConfig)
                        TabMain.TabPages.Add(TabPageConfigUT)
                        TabMain.TabPages.Add(TabPageGuida)
                        ComboBoxAgenziaConfig.SelectedIndex = 0
                        TabPageConfig_Enter(Me, New EventArgs)
                        AddHandler TabPageConfig.Enter, AddressOf TabPageConfig_Enter
                        AddHandler TabPageConfigUT.Enter, AddressOf TabPageConfigUT_Enter
                        TabMain.ColorStyle = Utx.UtTabControl.TabColorStyle.ROSSOGRIGIO
                    Case Modalita.AVVISI
                        TabMain.TabPages.Add(TabPageAvvisi)
                        TabMain.TabPages.Add(TabPageGuida)
                        TabPageAvvisi_Enter(Me, New EventArgs)
                        AddHandler TabPageAvvisi.Enter, AddressOf TabPageAvvisi_Enter
                        ComboBoxAgenzia_SelectedIndexChanged(Me, New EventArgs)
                        AddHandler ComboBoxAgenzia.SelectedIndexChanged, AddressOf ComboBoxAgenzia_SelectedIndexChanged
                        TabMain.ColorStyle = Utx.UtTabControl.TabColorStyle.VERDE
                    Case Modalita.TRACKING
                        TabMain.TabPages.Add(TabPageTracking)
                        TabMain.TabPages.Add(TabPageReport)
                        TabMain.TabPages.Add(TabPageGuida)
                        TabPageTracking_Enter(Me, New EventArgs)
                        AddHandler TabPageTracking.Enter, AddressOf TabPageTracking_Enter
                        AddHandler TabPageReport.Enter, AddressOf TabPageReport_Enter
                        TabMain.ColorStyle = Utx.UtTabControl.TabColorStyle.ROSA
                        NavigaTracking()
                End Select
            End If
            Me.Controls.Add(TabMain)
            TabMain.Dock = DockStyle.Fill

        Catch ex As Exception
            Koine.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ComboBoxAgenziaConfig_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxAgenziaConfig.SelectedIndexChanged
        NavigaConfigurazione()
    End Sub

    Private Async Sub ComboBoxAgenziaTrack_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxAgenziaTrack.SelectedIndexChanged
        Try
            Cursor = Cursors.WaitCursor
            Koine.Agenzia = ComboBoxAgenziaTrack.Text
            Dim Link As String = Koine.Servizi.LinkTracking
            If String.IsNullOrEmpty(Link) Then
                MsgBox("Il servizio non risulta al momento disponibile", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Me.Close()
            Else
                wbTrack.Navigate(Link)
            End If
        Catch ex As Exception
            Koine.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormPostalizzazione_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If TimerAttivazione IsNot Nothing Then
            TimerAttivazione.Dispose()
        End If
        If bw IsNot Nothing Then Do While bw.IsBusy : Application.DoEvents() : Loop
        CheckBoxDettaglioCliente.Checked = False
        'salvo le modifiche per il campo selezionato
        SalvaModificheSelezionati()
    End Sub

    Private Sub SalvaModificheSelezionati()
        Try
            If TipoChiamata = Modalita.AVVISI Then
                If dgvAvvisi.DataSource IsNot Nothing Then
                    Dim dt As DataTable = dgvAvvisi.DataSource
                    dt.DefaultView.RowFilter = ""

                    'salvo le modifiche per il campo selezionato
                    Dim QueryUp As String = ""

                    Select Case dt.Select("Selezionato = True").Length
                        Case 0 'tutti deselezionati
                            QueryUp = "UPDATE Postalizzazione SET Selezionato = cast(0 as bit)"
                        Case dt.Rows.Count 'tutti selezionati
                            QueryUp = "UPDATE Postalizzazione SET Selezionato = cast(1 as bit)"
                        Case Else 'solo alcuni selezionati
                            Dim Query As String = "UPDATE Postalizzazione 
                                SET Selezionato = cast({0} as bit), SenzaPremio = cast({1} as bit)
                                WHERE (Ramo = {2}) AND (Polizza = {3}) AND (EffettoTitolo = '{4:dd/MM/yyyy}') AND (TipoCarico = '{5}');"

                            For Each row As DataRow In dt.Rows
                                If row.RowState = DataRowState.Modified Then
                                    QueryUp &= Environment.NewLine & String.Format(Query,
                                                                           IIf(row("Selezionato"), 1, 0),
                                                                           IIf(row("SenzaPremio"), 1, 0),
                                                                           row("Ramo"),
                                                                           row("Polizza"),
                                                                           row("EffettoTitolo"),
                                                                           row("TipoCarico"))
                                End If
                            Next
                    End Select

                    If String.IsNullOrEmpty(QueryUp) = False Then
                        Utx.WsCommand.ExecuteNonQueryRecordAsync(QueryUp, Agenzia:=AgenziaAvvisi.Agenzia)
                    End If
                    dt.AcceptChanges()
                End If
            End If

        Catch ex As Exception
            Koine.Log.Errore(ex)
        End Try
    End Sub

    Private Sub FormKoine_Load(sender As Object, e As EventArgs) Handles Me.Load
        wbConfig.ScriptErrorsSuppressed = True
        wbTrack.ScriptErrorsSuppressed = True
        MigrazioneSetting()
    End Sub

    Private Sub FormPostalizzazione_ModificaConfigUT() Handles Me.ModificaConfigUT
        ImpostaCodiciAbilitatiUT()
        Postalizzazione.ProssimaEsecuzione = Now 'per resettare il controllo di postalizzazione
        ImpostaTab()
    End Sub

    Private Sub FormPostalizzazione_ModificaSelezionati() Handles Me.ModificaSelezionati
        ColoraNonSelezionati()
        ColoraSenzaPremio()
        LabelNumeroAvvisi.Text = String.Format("{0}/{1}", dgvAvvisi.Rows.Count - mNonSelezionati, dgvAvvisi.Rows.Count)
    End Sub

    Private Sub FormPostalizzazione_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Refresh()
        ImpostaCodiciAbilitatiUT()
        ImpostaTab()
    End Sub

    Private Sub ComboBoxAgenzia_SelectedIndexChanged(sender As Object, e As EventArgs)
        'salvo eventuali mofifiche
        SalvaModificheSelezionati()
        'cambio codice
        dgvAvvisi.DataSource = Nothing
        AgenziaAvvisi = ComboBoxAgenzia.SelectedItem 'l'item è un tipo AgenziaConfigPostalizzazione
        Koine.Agenzia = AgenziaAvvisi.Agenzia
        AggiornaStatoPostalizzazione()
    End Sub

    Private Sub dgvAvvisi_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAvvisi.CellClick
        If e.RowIndex >= 0 Then
            Select Case dgvAvvisi.Columns(e.ColumnIndex).Name
                Case "Selezionato"
                    dgvAvvisi.CurrentCell.Value = Not dgvAvvisi.CurrentCell.Value
                Case "SenzaPremio"
                    dgvAvvisi.CurrentCell.Value = Not dgvAvvisi.CurrentCell.Value
            End Select
        End If
        RaiseEvent ModificaSelezionati()
    End Sub

    Private Sub dgvAvvisi_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvAvvisi.ColumnHeaderMouseClick
        VisualizzaFiltro(e.ColumnIndex)
    End Sub

    Public Sub VisualizzaFiltro(IndiceColonna As Integer, Optional Centra As Boolean = False)
        Try
            If (dgvAvvisi.DataSource IsNot Nothing) Then
                'cartella per salvataggio filtro
                With FormFiltro
                    .AppName = "Postalizzazione"
                    .FilterFolder = Utx.Globale.Paths.CartellaSettingRete
                    .TabVisibili(True, False)

                    'visualizzo la finestra del filtro
                    .Visualizza(dgvAvvisi.Columns(IndiceColonna), Centra)
                End With
                RaiseEvent ModificaSelezionati()
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonVisualizza_Click(sender As Object, e As EventArgs) Handles ButtonVisualizza.Click
        Try
            Try
                If Cts IsNot Nothing Then
                    Cts.Cancel()
                    ThreadVerificaClienti.Join()
                    Cts.Dispose()
                End If
            Catch ex As Exception
            End Try

            ButtonVisualizza.Enabled = False
            ButtonAggiungi.Enabled = False
            ButtonElimina.Enabled = False

            SalvaModificheSelezionati()
            dgvAvvisi.DataSource = Nothing

            If CheckBoxAggiornaDati.Checked Then
                RaiseEvent RichiestaArretrati(AgenziaAvvisi, Koine.Avvisi.InizioPeriodo, Koine.Avvisi.FinePeriodo)
            End If

            Cursor = Cursors.WaitCursor

            Avvisi = New UniCom.Koine.Avvisi()
            Dim dt As DataTable = Avvisi.DatiAvvisi

            Cts = New Threading.CancellationTokenSource 'creo cts per poter interrompere il thread

            ThreadVerificaClienti = New Threading.Thread(AddressOf VerificaClienti) With {.Priority = Threading.ThreadPriority.BelowNormal}
            ThreadVerificaClienti.Start(Cts.Token)

            dgvAvvisi.Visible = False
            dgvAvvisi.DataSource = dt
            FormFiltro.CancellaFiltri()
            FormattaGriglia()
            dgvAvvisi.Visible = True

            ControllaVita()

        Catch ex As Exception
            Koine.Log.Errore(ex)
        Finally
            ButtonVisualizza.Enabled = True
            ButtonAggiungi.Enabled = True
            ButtonElimina.Enabled = True
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormattaGriglia()
        With dgvAvvisi
            .Columns("Selezionato").HeaderText = "Sel."
            .Columns("SenzaPremio").HeaderText = String.Format("Invia{0}senza{0}premio", Environment.NewLine)
            .Columns("Agenzia").Visible = False
            .Columns("SubAgenzia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            With .Columns("SubAgenzia")
                .HeaderText = "Sub"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("Ramo")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = Color.Gainsboro
            End With
            With .Columns("EffettoTitolo")
                .HeaderText = "Effetto titolo"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("TipoCarico")
                .HeaderText = "Tipo carico"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            .Columns("Contraente").DefaultCellStyle.BackColor = Color.Yellow
            .Columns("CodiceFiscale").HeaderText = "Codice fiscale"
            With .Columns("TotaleTitolo")
                .HeaderText = "Totale titolo"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,##0.00"
                .DefaultCellStyle.BackColor = Color.Lavender
            End With
            With .Columns("Frazionamento")
                .HeaderText = "Fraz"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            .Columns("Targa").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Prodotto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            With .Columns("Convenzione")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.Format = "00000"
            End With
            With .Columns("RamoGestione")
                .HeaderText = "Ramo gestione"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("ScadenzaPolizza")
                .HeaderText = "Scadenza polizza"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("RataIntermedia")
                .HeaderText = "Rata intermedia"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            .Columns("Sesso").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("RID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            With .Columns("TotaleTitolo")
                .HeaderText = "Totale titolo"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,##0.00"
                .DefaultCellStyle.BackColor = Color.Lavender
            End With
            .Columns("Quota").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            With .Columns("ImportoQuota")
                .HeaderText = "Importo ns.quota"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,###,##0.00"
            End With
            With .Columns("Privacy")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Visible = False
            End With
            With .Columns("Delegataria")
                .HeaderText = "Deleg."
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With

            Utx.NetFunc.BloccaOrdinamento(dgvAvvisi)
            .AutoResizeColumns(DataGridViewAutoSizeColumnMode.DisplayedCells)
        End With
        RaiseEvent ModificaSelezionati()
        ColoraSenzaPremio()
    End Sub

    Private Sub ColoraNonSelezionati()
        mNonSelezionati = 0
        Dim Coass As Integer = 0
        For Each row As DataGridViewRow In dgvAvvisi.Rows
            If row.Cells("Selezionato").Value = True Then
                row.DefaultCellStyle.BackColor = Nothing
            Else
                row.DefaultCellStyle.BackColor = Color.Gainsboro
                mNonSelezionati += 1
            End If
            'coass
            If row.Cells("Delegataria").Value > 0 Then
                row.Cells("Delegataria").Style.BackColor = Color.Orange
                row.Cells("Ramo").Style.BackColor = Color.Orange
                row.Cells("Polizza").Style.BackColor = Color.Orange
                Coass += 1
            End If
        Next
        LabelNumeroCoass.Text = String.Format("{0} CoAss", Coass)
    End Sub

    Private Sub ColoraSenzaPremio()
        For Each row As DataGridViewRow In dgvAvvisi.Rows
            If row.Cells("SenzaPremio").Value = True Then
                row.Cells("TotaleTitolo").Style.BackColor = Color.Pink
            Else
                row.Cells("TotaleTitolo").Style.BackColor = Nothing
            End If
        Next
    End Sub

    Private Sub LabelNumeroAvvisi_TextChanged(sender As Object, e As EventArgs) Handles LabelNumeroAvvisi.TextChanged
        sender.Refresh()
    End Sub

    Private Sub ButtonInvia_Click(sender As Object, e As EventArgs) Handles ButtonInvia.Click
        Try
            If Cts IsNot Nothing Then
                Cts.Cancel()
                ThreadVerificaClienti.Join()
                Cts.Dispose()
            End If
        Catch ex As Exception
        End Try

#If DEBUG Then
        'resetto filtri
        FormFiltro.CancellaFiltri()
        RaiseEvent ModificaSelezionati()

        'chiedo conferma
        If MsgBox($"Confermate l'invio di {dgvAvvisi.Rows.Count - mNonSelezionati} titoli per la postalizzazione?",
                  MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then

            ButtonInvia.Enabled = False 'lo stato del bottone viene settato alla fine nell'evento post invio

            SalvaModificheSelezionati()
            '+gli elementi non selezionati vengono scartati durante la preparazione del doc di invio
            Avvisi.DatiAvvisi = dgvAvvisi.DataSource
            Avvisi.Invia(Postalizzazione.Modalita.MANUALE)

            RaiseEvent ModificaSelezionati()
        End If
#Else
        'ricontrollo nel caso fosse entrato in funzione l'automatismo
        If Postalizzazione.CodicePostalizzato(AgenziaAvvisi.Agenzia) = False Then
            'resetto filtri
            FormFiltro.CancellaFiltri()
            RaiseEvent ModificaSelezionati()

            'chiedo conferma
            If MsgBox($"Confermate l'invio di {dgvAvvisi.Rows.Count - mNonSelezionati} titoli per la postalizzazione?",
                      MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then

                ButtonInvia.Enabled = False 'lo stato del bottone viene settato alla fine nell'evento post invio

                SalvaModificheSelezionati()
                '+gli elementi non selezionati vengono scartati durante la preparazione del doc di invio
                Avvisi.DatiAvvisi = dgvAvvisi.DataSource
                Avvisi.Invia(Postalizzazione.Modalita.MANUALE)

                RaiseEvent ModificaSelezionati()
            End If
        Else
            MsgBox("Per questo codice agenzia è già stata effettuata la postalizzazione del periodo.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
        End If
#End If
    End Sub

    Private Sub CheckBoxAggiornaDati_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckBoxAggiornaDati.CheckStateChanged
        If CheckBoxAggiornaDati.Checked Then
            CheckBoxAggiornaDati.BackColor = Color.PaleGreen
        Else
            CheckBoxAggiornaDati.BackColor = SystemColors.Control
        End If
    End Sub

    Private Sub dgvAvvisi_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgvAvvisi.CurrentCellChanged
        If SplitContainer1.Panel2Collapsed = False Then
            DettaglioCliente()
        End If
    End Sub

    Private Sub dgvAvvisi_DataSourceChanged(sender As Object, e As EventArgs) Handles dgvAvvisi.DataSourceChanged
        AggiornaStatoInvio()
        dgvAvvisi.Refresh()
        Application.DoEvents()
    End Sub

    Private Sub TimerAttivazione_Tick(sender As Object, e As EventArgs) Handles TimerAttivazione.Tick
        TimerAttivazione.Enabled = False
        bw.RunWorkerAsync()
    End Sub

    Private Sub bw_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw.DoWork
        Using s As New Utx.ServiziUniarea.accessoCasa
            s.Proxy = Utx.Globale.UniProxy.Proxy
            Utx.Globale.ProfiloEnteGestore.Abilitazioni.POSTALIZZAZIONE = (s.checkPostalizzazioneW(Utx.Globale.ProfiloEnteGestore.AgenziaMadre,
                                                                                                   Utx.Globale.ProfiloEnteGestore.Compagnia,
                                                                                                   Utx.NetFunc.TokenAccessoCasa) = 1)
        End Using
    End Sub

    Private Sub bw_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw.RunWorkerCompleted
        If Utx.Globale.ProfiloEnteGestore.Abilitazioni.POSTALIZZAZIONE = True Then
            Utx.Globale.ProfiloEnteGestore.Abilitazioni.SalvaAbilitazioni() 'salvo la modifica
            TimerAttivazione.Enabled = False
            ImpostaTab()
            RaiseEvent ServizioAttivato()
        Else
            TimerAttivazione.Enabled = True
        End If
    End Sub

    Private Sub wbAttivazione_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles wbAttivazione.DocumentCompleted
        Try
            If wbAttivazione.Document.Title.Equals("postalizzazione step invio", StringComparison.InvariantCultureIgnoreCase) Then
                Koine.Log.Info("Eseguita richiesta attivazione postalizzazione dall'utente {0}", {Utx.Globale.UtenteCorrente.UniageUser})
                'avvio il processo che controlla se è avvenuta la conferma da mail
                bw = New BackgroundWorker
                TimerAttivazione = New Timer
                TimerAttivazione.Interval = 10000 'ogni 10 secondi
                TimerAttivazione.Enabled = True
            End If
        Catch ex As Exception
            Koine.Log.Errore(ex)
        End Try
    End Sub

    Private Sub TabPageConfigUT_Enter(sender As Object, e As EventArgs)
        Try
            CheckedListBoxAgenzieAbilitate.Items.Clear()
            For Each agenzia As String In Utx.EnteGestore.CodiciPostalizzati
                Dim check As Boolean = False
                For Each a As AgenziaConfigPostalizzazione In CodiciAbilitatiUT
                    If agenzia = a.Agenzia Then
                        check = True
                    End If
                Next
                CheckedListBoxAgenzieAbilitate.Items.Add(agenzia, check)
            Next

            Dim Sezione As New Utx.SettingItem(Utx.SettingItem.Sezioni.COMUNICATORE, "", "", Utx.SettingOMW.TipoOperazione.LETTURA)

            For Each i As String In Sezione.ItemResult.Valori
                Select Case i.Split("|")(0)
                    Case Utx.SettingItem.Chiavi.COMUNICATORE_NOTIFICHE.ToString : TextBoxMailNotifica.Text = i.Split("|")(1)
                    Case Utx.SettingItem.Chiavi.COMUNICATORE_UTENTI.ToString : TextBoxUtentiAbilitati.Text = i.Split("|")(1)
                    Case Utx.SettingItem.Chiavi.COMUNICATORE_RID.ToString : CheckBoxRID.Checked = CBool(i.Split("|")(1))
                    Case Utx.SettingItem.Chiavi.COMUNICATORE_DOMICILIO.ToString : CheckBoxDomicilio.Checked = CBool(i.Split("|")(1))
                End Select
            Next

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub TabPageConfig_Enter(sender As Object, e As EventArgs)
        TabPageConfig.Refresh()
        If ComboBoxAgenziaConfig.SelectedIndex < 0 AndAlso ComboBoxAgenziaConfig.Items.Count > 0 Then
            ComboBoxAgenziaConfig.SelectedIndex = 0
        End If
    End Sub

    Private Sub TabPageTracking_Enter(sender As Object, e As EventArgs)
        TabPageTracking.Refresh()
        If ComboBoxAgenziaTrack.SelectedIndex < 0 AndAlso ComboBoxAgenziaTrack.Items.Count > 0 Then
            ComboBoxAgenziaTrack.SelectedIndex = 0
        End If
    End Sub

    Private Sub TabPageAvvisi_Enter(sender As Object, e As EventArgs)
        TabPageAvvisi.Refresh()
        If ComboBoxAgenzia.SelectedIndex < 0 AndAlso ComboBoxAgenzia.Items.Count > 0 Then
            ComboBoxAgenzia.SelectedIndex = 0
        End If
    End Sub

    Private Sub TabPageGuida_Enter(sender As Object, e As EventArgs) Handles TabPageGuida.Enter
        If wbGuida.Document Is Nothing Then
            wbGuida.ScriptErrorsSuppressed = True
            wbGuida.Navigate("https://www.auasoluzioni.it/knowledge/article/1141")
        End If
    End Sub

    Private Sub TabPageReport_Enter(sender As Object, e As EventArgs)
        On Error Resume Next
        With dgvReport
            .DataSource = Postalizzazione.ReportInvio(ComboBoxAgenziaTrack.Text)

            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("DataInvio").HeaderText = "Data invio"
            .Columns("FileDati").HeaderText = "Nome file"
            .Columns("IdCampagna").HeaderText = "Id invio"
            .Columns("DataRevoca").HeaderText = "Data revoca"
            .Columns("Titoli").DefaultCellStyle.Format = "##,##0"
            .Columns("Clienti").DefaultCellStyle.Format = "##,##0"
            .Columns("Comunicazioni").DefaultCellStyle.Format = "##,##0"

            Utx.NetFunc.BloccaOrdinamento(dgvReport)

            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .AutoResizeColumns()
        End With
    End Sub

    Private Sub ButtonSalvaConfigUT_Click(sender As Object, e As EventArgs) Handles ButtonSalvaConfigUT.Click
        Try
#If DEBUG Then
            MsgBox("in debug non salva le impostazioni", MsgBoxStyle.Information)
            Exit Sub
#End If
            Dim Chiave As Utx.SettingItem
            'mail per notifiche
            If Utx.NetFunc.ValidEmail(TextBoxMailNotifica.Text, False, False) = False Then
                MsgBox("Inserire un indirizzo e-mail valido per l'invio delle notifiche", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Exit Sub
            Else
                Chiave = New Utx.SettingItem(Utx.SettingItem.Sezioni.COMUNICATORE,
                                             Utx.SettingItem.Chiavi.COMUNICATORE_NOTIFICHE,
                                             TextBoxMailNotifica.Text.Trim,
                                             Utx.SettingOMW.TipoOperazione.SCRITTURA)
            End If
            'utenti abilitati alla modifica
            Chiave.SetItem(Utx.SettingItem.Sezioni.COMUNICATORE,
                           Utx.SettingItem.Chiavi.COMUNICATORE_UTENTI,
                           TextBoxUtentiAbilitati.Text.Trim,
                           Utx.SettingOMW.TipoOperazione.SCRITTURA)
            'rid
            Chiave.SetItem(Utx.SettingItem.Sezioni.COMUNICATORE,
                           Utx.SettingItem.Chiavi.COMUNICATORE_RID,
                           CheckBoxRID.Checked.ToString,
                           Utx.SettingOMW.TipoOperazione.SCRITTURA)
            'domicilio
            Chiave.SetItem(Utx.SettingItem.Sezioni.COMUNICATORE,
                           Utx.SettingItem.Chiavi.COMUNICATORE_DOMICILIO,
                           CheckBoxDomicilio.Checked.ToString,
                           Utx.SettingOMW.TipoOperazione.SCRITTURA)
            'codici agenzia abilitati in UT
            Dim Codici As String = ""

            If CheckedListBoxAgenzieAbilitate.CheckedItems.Count > 0 Then
                For Each codice As String In CheckedListBoxAgenzieAbilitate.CheckedItems
                    Codici &= codice & ";"
                Next
                Codici = Codici.Substring(0, Codici.Length - 1)
                Chiave.SetItem(Utx.SettingItem.Sezioni.COMUNICATORE,
                               Utx.SettingItem.Chiavi.COMUNICATORE_CODICI_ABILITATI,
                               Codici,
                               Utx.SettingOMW.TipoOperazione.SCRITTURA)
            Else
                'nessun codice selezionato: elimino la chiave
                Chiave.SetItem(Utx.SettingItem.Sezioni.COMUNICATORE,
                               Utx.SettingItem.Chiavi.COMUNICATORE_CODICI_ABILITATI,
                               "",
                               Utx.SettingOMW.TipoOperazione.CANCELLAZIONE)
            End If

            'invio i codici attivi al server
            Codici = ""
            For k As Integer = 0 To CheckedListBoxAgenzieAbilitate.Items.Count - 1
                If CheckedListBoxAgenzieAbilitate.GetItemChecked(k) = True Then
                    Codici &= String.Format("{0};1|", CheckedListBoxAgenzieAbilitate.Items(k))
                Else
                    Codici &= String.Format("{0};0|", CheckedListBoxAgenzieAbilitate.Items(k))
                End If
            Next
            'tolgo l'ultimo |
            Codici = Codici.Substring(0, Codici.Length - 1)
            'invio al server utools.it
            Using s As New Utx.SettingAgenzia.ConfiguraSede
                s.Proxy = Utx.Globale.UniProxy.Proxy
                Dim Esito As String = s.CodiciAttiviPostalizzazione(Codici, Utx.Globale.ProfiloEnteGestore.Localita.ToUpper)
                If Esito = "+OK" Then
                    MsgBox("Configurazione postalizzazione in Unitools salvata correttamente", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Else
                    MsgBox(Esito.Split("|")(1), MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                End If
            End Using

            RaiseEvent ModificaConfigUT()
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonAggiornaCip_Click(sender As Object, e As EventArgs) Handles ButtonAggiornaCip.Click
        Dim Desk As String = ButtonAggiornaCip.Text
        Try
            ButtonAggiornaCip.Enabled = False
            ButtonAggiornaCip.Text = "Invio in corso..."
            Cursor = Cursors.WaitCursor
            '+il codice agenzia viene settata con il combo box agenziaconfig
            Dim Esito As String = Koine.Servizi.InviaStrutturaAgenzia()

            If Esito = "OK" Then
                MsgBox("Dati CIP-Soggetti-Punti vendita trasmessi correttamente", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                ComboBoxAgenziaConfig_SelectedIndexChanged(Me, New EventArgs)
            Else
                Globale.Log.Info("Invio dati agenzia {0}. Esito invio '{1}'", {Koine.Agenzia, Esito})
                MsgBox(String.Format("Invio dati agenzia {0}. Esito invio '{1}'", Koine.Agenzia, Esito), MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
            End If
        Catch ex As Exception
            Koine.Log.Errore(ex.Message)
        Finally
            ButtonAggiornaCip.Text = Desk
            ButtonAggiornaCip.Enabled = True
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ButtonEsporta_Click(sender As Object, e As EventArgs) Handles ButtonEsporta.Click
        If dgvAvvisi.Rows.Count > 0 Then
            Utx.NetFunc.Esporta2Csv(dgvAvvisi, String.Format("{0}_Avvisi_{1:MM_yyyy}", Koine.Agenzia, Koine.Avvisi.InizioPeriodo), Drawing.Color.Khaki)
        End If
    End Sub

    Private Sub wbConfig_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs)
#If DEBUG Then
        Koine.Log.Info(e.Url.ToString)
#End If
        If e.Url.ToString = "https://uni.sicomunica.it/index.php?r=auth/login" Then
            NavigaConfigurazione()
        End If
    End Sub

    Private Sub NavigaConfigurazione()
        Try
            Cursor = Cursors.WaitCursor
            Koine.Agenzia = ComboBoxAgenziaConfig.SelectedItem.Agenzia
            Dim Link As String = Koine.Servizi.LinkConfig
            If String.IsNullOrEmpty(Link) Then
                MsgBox("Il servizio non risulta al momento disponibile", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Me.Close()
            Else
                wbConfig.Navigate(Link)
            End If
        Catch ex As Exception
            Koine.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub NavigaTracking()
        Try
            Cursor = Cursors.WaitCursor
            Dim Link As String = Koine.Servizi.LinkTracking
            If String.IsNullOrEmpty(Link) Then
                MsgBox("Il servizio non risulta al momento disponibile", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Me.Close()
            Else
                wbConfig.Navigate(Link)
            End If
        Catch ex As Exception
            Koine.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormFiltro_ModificatoFiltro() Handles FormFiltro.ModificatoFiltro
        RaiseEvent ModificaSelezionati()
    End Sub

    Private Sub AgenziaAvvisi_ModificaStatoPostalizzazione(PeriodoPostalizzato As Boolean) Handles AgenziaAvvisi.ModificaStatoPostalizzazione
        AggiornaStatoPostalizzazione()
    End Sub

    Private Sub AggiornaStatoInvio()
        ButtonInvia.Enabled = (dgvAvvisi.DataSource IsNot Nothing) AndAlso (dgvAvvisi.Rows.Count > 0) AndAlso (AgenziaAvvisi.PeriodoPostalizzato = False) AndAlso
                              (Today >= Postalizzazione.InizioPostalizzazioneManuale)
#If DEBUG Then
        ButtonInvia.Enabled = (dgvAvvisi.DataSource IsNot Nothing) AndAlso (dgvAvvisi.Rows.Count > 0)
#End If
    End Sub

    Private Sub AggiornaStatoPostalizzazione()
        AggiornaStatoInvio()
        If AgenziaAvvisi.PeriodoPostalizzato = True Then
            LabelMese.Text = String.Format("Postalizzazione del mese {0:MM-yyyy} (già effettuata)", Koine.Avvisi.InizioPeriodo)
        Else
            LabelMese.Text = String.Format("Postalizzazione del mese {0:MM-yyyy}", Koine.Avvisi.InizioPeriodo)
        End If
    End Sub

    Private Sub Avvisi_InvioConcluso() Handles Avvisi.InvioConcluso
        AgenziaAvvisi.AggiornaStatoPostalizzazione()
    End Sub

    Private Sub ButtonDeseleziona_Click(sender As Object, e As EventArgs) Handles ButtonDeseleziona.Click
        If (dgvAvvisi IsNot Nothing) AndAlso (dgvAvvisi.Rows.Count > 0) Then
            If MsgBox(String.Format("Deselezionare tutti i {0} titoli visualizzati?", dgvAvvisi.Rows.Count),
                      MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then

                dgvAvvisi.Rows(0).Cells(0).Selected = True

                For Each row As DataGridViewRow In dgvAvvisi.Rows
                    If row.Cells("Selezionato").Value = True Then
                        row.Cells("Selezionato").Value = False
                        'SalvaFlag(row)
                    End If
                Next
                dgvAvvisi.Rows(dgvAvvisi.Rows.Count - 1).Cells(0).Selected = True
                dgvAvvisi.Rows(0).Cells(0).Selected = True
                RaiseEvent ModificaSelezionati()
            End If
        End If
    End Sub

    Private Sub ButtonSeleziona_Click(sender As Object, e As EventArgs) Handles ButtonSeleziona.Click
        If (dgvAvvisi IsNot Nothing) AndAlso (dgvAvvisi.Rows.Count > 0) Then
            If MsgBox(String.Format("Selezionare tutti i {0} titoli visualizzati?", dgvAvvisi.Rows.Count),
                      MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then

                dgvAvvisi.Rows(0).Cells(0).Selected = True

                For Each row As DataGridViewRow In dgvAvvisi.Rows
                    If row.Cells("Selezionato").Value = False Then
                        row.Cells("Selezionato").Value = True
                        'SalvaFlag(row)
                    End If
                Next
                dgvAvvisi.Rows(dgvAvvisi.Rows.Count - 1).Cells(0).Selected = True
                dgvAvvisi.Rows(0).Cells(0).Selected = True
                RaiseEvent ModificaSelezionati()
            End If
        End If
    End Sub

    Private Sub CheckBoxDettaglioCliente_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxDettaglioCliente.CheckedChanged
        If CheckBoxDettaglioCliente.Checked = True Then
            CheckBoxDettaglioCliente.BackColor = Color.Gold
            SplitContainer1.Panel2Collapsed = False
            dgvAvvisi_CurrentCellChanged(dgvAvvisi, New EventArgs)
        Else
            CheckBoxDettaglioCliente.BackColor = Color.Gainsboro
            SplitContainer1.Panel2Collapsed = True
        End If
    End Sub

    Private Sub DettaglioCliente()
        On Error Resume Next

        If dgvAvvisi.CurrentRow IsNot Nothing Then
            Dim dr As DataRow = Avvisi.LeggiCliente(dgvAvvisi.CurrentRow.Cells("CodiceFiscale").Value)

            If dr IsNot Nothing Then
                Dim IndirizzoDomicilio As String
                If dr("ToponimoDomicilio").ToString.EndsWith("'") Then
                    IndirizzoDomicilio = String.Format("{0}{1}, {2}", dr("ToponimoDomicilio"), dr("IndirizzoDomicilio"), dr("NumCivicoDomicilio"))
                Else
                    IndirizzoDomicilio = String.Format("{0} {1}, {2}", dr("ToponimoDomicilio"), dr("IndirizzoDomicilio"), dr("NumCivicoDomicilio"))
                End If

                Dim Rientro As String = Space(3)
                Dim sb As New System.Text.StringBuilder
                With sb
                    .AppendLine("Dettaglio cliente:")
                    .AppendLine()
                    .AppendLine(String.Format("{0} {1}", dr("Cognome").ToString.Trim, dr("Nome").ToString.Trim))
                    .AppendLine()
                    .AppendLine("Residenza:")
                    .AppendLine(dr("Indirizzo").ToString.Trim)
                    .AppendLine(String.Format("{0} {1} {2}", dr("Cap"), dr("Localita").ToString.Trim, dr("Provincia").ToString.Trim))
                    .AppendLine()
                    .AppendLine("Domicilio:")
                    .AppendLine(IndirizzoDomicilio)
                    .AppendLine(String.Format("{0} {1} {2}", dr("CapDomicilio"), dr("LocalitaDomicilio").ToString.Trim, dr("ProvinciaDomicilio").ToString.Trim))
                    .AppendLine()
                    .AppendLine("Cellulare:")
                    .AppendLine(Rientro & dr("Cellulare"))
                    .AppendLine(Rientro & dr("RisCellulare"))
                    .AppendLine()
                    .AppendLine("Telefono:")
                    .AppendLine(Rientro & dr("telNumero2"))
                    .AppendLine(Rientro & dr("telNumero4"))
                    .AppendLine()
                    .AppendLine("E-mail:")
                    .AppendLine(Rientro & dr("Email").ToString.Trim)
                    .AppendLine(Rientro & dr("RisMail").ToString.Trim)
                    .AppendLine(Rientro & dr("EmailIndirizzo1").ToString.Trim)
                    .AppendLine(Rientro & dr("EmailIndirizzo2").ToString.Trim)
                End With
                LabelInfoCliente.Text = sb.ToString
            Else
                LabelInfoCliente.Text = "Dettaglio cliente:"
            End If
        End If
    End Sub

    Private Sub ControllaVita()
#If DEBUG Then
        'Exit Sub
        Dim Query As String = "SELECT COUNT(*) FROM Postalizzazione WHERE Ramo = 89"

        If Utx.WsCommand.ExecuteScalar(Query).Valore > 0 Then
            Call New Utx.NotificaRapida(Utx.FormNotifica.AltezzaNotifica.NORMALE).Visualizza("VITA OK", 5)
            Beep()
        Else
            Call New Utx.NotificaRapida(Utx.FormNotifica.AltezzaNotifica.NORMALE).Visualizza("VITA non presente", 5)
        End If
#End If
    End Sub

    Public Shared Sub MigrazioneSetting()
        Try
            'leggo chiave con ora prossimo controllo
            Dim Chiave As New Utx.SettingItem(Utx.SettingItem.Sezioni.COMUNICATORE, Utx.SettingItem.Chiavi.COMUNICATORE_NOTIFICHE,
                                              Utx.SettingOMW.TipoOperazione.LETTURA)

            If Chiave.ItemResult.Esiste = False AndAlso UniCom.Postalizzazione.SettingPostalizzazione.EsisteSetting Then
                Dim P As New UniCom.Postalizzazione(Utx.Globale.ProfiloEnteGestore.AgenziaMadre)

                Chiave.SetItem(Utx.SettingItem.Sezioni.COMUNICATORE,
                               Utx.SettingItem.Chiavi.COMUNICATORE_CODICI_ABILITATI,
                               UniCom.Postalizzazione.SettingPostalizzazione.LeggiValore(Utx.GestioneFlag.TipoFlag.POSTALIZZAZIONE_CODICI_ABILITATI),
                               Utx.SettingOMW.TipoOperazione.SCRITTURA)
                Chiave.SetItem(Utx.SettingItem.Sezioni.COMUNICATORE,
                               Utx.SettingItem.Chiavi.COMUNICATORE_DOMICILIO,
                               UniCom.Postalizzazione.SettingPostalizzazione.LeggiValore(Utx.GestioneFlag.TipoFlag.POSTALIZZAZIONE_DOMICILIO),
                               Utx.SettingOMW.TipoOperazione.SCRITTURA)
                Chiave.SetItem(Utx.SettingItem.Sezioni.COMUNICATORE,
                               Utx.SettingItem.Chiavi.COMUNICATORE_NOTIFICHE,
                               UniCom.Postalizzazione.SettingPostalizzazione.LeggiValore(Utx.GestioneFlag.TipoFlag.POSTALIZZAZIONE_NOTIFICHE),
                               Utx.SettingOMW.TipoOperazione.SCRITTURA)
                Chiave.SetItem(Utx.SettingItem.Sezioni.COMUNICATORE,
                               Utx.SettingItem.Chiavi.COMUNICATORE_UTENTI,
                               UniCom.Postalizzazione.SettingPostalizzazione.LeggiValore(Utx.GestioneFlag.TipoFlag.POSTALIZZAZIONE_UTENTI),
                               Utx.SettingOMW.TipoOperazione.SCRITTURA)
                Chiave.SetItem(Utx.SettingItem.Sezioni.COMUNICATORE,
                               Utx.SettingItem.Chiavi.COMUNICATORE_RID,
                               UniCom.Postalizzazione.SettingPostalizzazione.LeggiValore(Utx.GestioneFlag.TipoFlag.POSTALIZZAZIONE_RID),
                               Utx.SettingOMW.TipoOperazione.SCRITTURA)
                Chiave.SetItem(Utx.SettingItem.Sezioni.COMUNICATORE,
                               Utx.SettingItem.Chiavi.COMUNICATORE_NOTIFICHE,
                               UniCom.Postalizzazione.SettingPostalizzazione.LeggiValore(Utx.GestioneFlag.TipoFlag.POSTALIZZAZIONE_NOTIFICHE),
                               Utx.SettingOMW.TipoOperazione.SCRITTURA)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub FormPostalizzazione_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Try
            If Cts IsNot Nothing Then
                Cts.Cancel()
                ThreadVerificaClienti.Join()
                Cts.Dispose()
            End If
        Catch ex As Exception
        End Try

        Try
            Using s As New Utx.SettingAgenzia.ConfiguraSede With {.Proxy = Utx.Globale.UniProxy.Proxy}
                s.EliminaBloccoPostalizzazione(Utx.Globale.ProfiloEnteGestore.AgenziaMadre)
            End Using
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub VerificaClienti(CancellationTokenObject As Object)
        Try
            Dim Token As Threading.CancellationToken = CType(CancellationTokenObject, Threading.CancellationToken)

            'creo la lista dei clienti che sono negli arretrati ma non nell'anagrafica
            Dim Query As String = "SELECT A.CodiceFiscale 
                FROM (SELECT DISTINCT CodiceFiscale FROM Postalizzazione) AS A 
                LEFT JOIN Clienti AS B 
                ON A.codicefiscale = B.codicefiscale
                WHERE B.CodiceFiscale IS NULL"

            Dim dtc As DataTable = Utx.WsCommand.ExecuteNonQuery(Query, ComboBoxAgenzia.Text).DataTable
            Dim Progressivo As Integer = 0

            Utx.Globale.Log.Info("Avvio verifica di {0} clienti", {dtc.Rows.Count})

            'se non trovo l'assicurato lo catturo da essig
            For Each row As DataRow In dtc.Rows
                If Utx.Essig.LeggiDatiCliente(row("CodiceFiscale"), ComboBoxAgenzia.Text) Is Nothing Then
                    Utx.Globale.Log.Info("essig non raggiungibile - interrompo ciclo di controllo")
                    Exit For
                End If

                Utx.Globale.Log.Info("Verificato da essig cliente {0}", {row("CodiceFiscale")})

                Progressivo += 1

                'controllo se è stata richiesta l'uscita dal thread
                If Token.IsCancellationRequested Then
                    Utx.Globale.Log.Info("Fermo la verifica clienti")
                    Exit For
                End If
            Next
            Utx.Globale.Log.Info("Verificati da essig {0} clienti del codice {1}", {Progressivo, ComboBoxAgenzia.Text})

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonAggiungi_Click(sender As Object, e As EventArgs) Handles ButtonAggiungi.Click
        Using f As New FormNuovoAvviso(ComboBoxAgenzia.Text)
            f.ShowDialog()

            If f.RecordAggiunti > 0 Then
                CheckBoxAggiornaDati.Checked = False
                ButtonVisualizza.PerformClick()
            End If
        End Using
    End Sub

    Private Sub ButtonElimina_Click(sender As Object, e As EventArgs) Handles ButtonElimina.Click
        Try
            If dgvAvvisi.CurrentRow Is Nothing Then
                Exit Try
            End If

            If dgvAvvisi.CurrentRow.Cells("Prodotto").Value <> "XXXXX" Then
                MsgBox("E' possibile eliminare solo gli avvisi inseriti manualmente.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Exit Try
            End If

            'i valori per la query vanno rilevati qui perché il salvataggio cambia la riga corrente
            Dim Contraente As String = dgvAvvisi.CurrentRow.Cells("Contraente").Value
            Dim Ramo As Integer = dgvAvvisi.CurrentRow.Cells("Ramo").Value
            Dim Polizza As Integer = dgvAvvisi.CurrentRow.Cells("Polizza").Value
            Dim Effetto As Date = dgvAvvisi.CurrentRow.Cells("EffettoTitolo").Value

            If MsgBox(String.Format("Confermate la cancellazione dell'avviso per {0} - {1}.{2}", Contraente, Ramo, Polizza),
                      MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question) = MsgBoxResult.No Then
                Exit Try
            End If

            SalvaModificheSelezionati()

            Dim Sql As String = String.Format("DELETE
                FROM Postalizzazione
                WHERE Ramo = {0} AND Polizza = {1} AND EffettoTitolo = '{2:dd/MM/yyyy}'", Ramo, Polizza, Effetto)

            Dim Risposta As Integer = Utx.WsCommand.ExecuteNonQueryRecord(Sql, ComboBoxAgenzia.Text)

            If Risposta = 1 Then
                CheckBoxAggiornaDati.Checked = False
                ButtonVisualizza.PerformClick()
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub
End Class
