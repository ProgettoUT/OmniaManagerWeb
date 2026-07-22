Imports System.Text
Imports System.IO
Imports System.Data.OleDb
Imports System.Xml.Serialization

Public Class FormMain

    Private Const LinkDoc As String = "http://www.utools.it/Unitools/Doc/Assegni/IndexDoc.htm"

    Friend Enum StatoLicenza
        ATTIVA = 0
        NON_ATTIVA = 1
    End Enum

    Private Importa As ExportLib.Export
    Private ReadOnly Notifica As Utx.FormNotifica

    Private StatoUniarea As AbilitazioneAgenzia
    Private WithEvents C4 As Emmedi.C4Cheque
    Private WithEvents Titolo As Assegno
    Private AbbinamentoAssegni As Abbinamento
    Private Deposito As DepositoAssegni
    Private CartellaAssegni As String
    Private C4InitFlag As Boolean
    Private ReadOnly FormFiltro As New Utx.FormGestioneFiltro(1000)
    Private Login As Utx.AutenticazioneEssig

    Private WithEvents ScannerTimer As Timer
    Private WithEvents ButtonStampaAssegni As New Button

    Private StatoAgenzia As StatoLicenza

    Sub New()
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Size = New Size(1113, 562)
        Utx.Globale.IdApp(System.Text.Encoding.UTF8.GetString(New Byte() {57, 60, 88, 93, 65, 58, 71}))
        Utx.Globale.Init()
        Utx.Globale.UtenteCorrente = New Utx.Utente

        Globale.ImpostaDebug()

        Me.BackColor = Color.YellowGreen
    End Sub

    Private Sub FormMain_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Globale.Log.Info("Load Assegni.exe")
        'controllo chiamata
        Environment.SetEnvironmentVariable("UNITOOLS_ASSEGNI_ID", "Uniarea." + Format(Today, "yyyy-MM.dddd"))
        If Utx.NetFunc.GetEnvironmentVar("UNITOOLS_ASSEGNI_ID") <> Globale.IdApp Then
            Me.Close()
            Exit Sub
        End If

        'imposta per agenzia fonsai
        If Globale.AgenziaSai = True Then

            If Globale.ImpostaSai() = False Then
                Me.Close()
                Exit Sub
            End If
        End If

        Globale.ImpostaVariabiliGlobali()

        AbbinamentoAssegni = New Abbinamento

        If ImpostaControlli() = False Then
            Me.Close()
            Exit Sub
        End If

        Login = New Utx.AutenticazioneEssig
    End Sub

    Private Sub FormMain_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If Utx.NetFunc.GetEnvironmentVar("UNITOOLS_DATA_INCASSO_AGGIORNA") = "S" Then
            LetturaIncassi()
        End If
    End Sub

    Private Sub FormMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If C4 IsNot Nothing Then C4.Close(0)
    End Sub

    Private Function ImpostaControlli() As Boolean
        Try
            Dim tt As New ToolTip

            With Me
                .Text = String.Format("Gestione assegni: agenzia madre {0}", Globale.AgenziaMadre) ' utx.Setting.PcToAgenzia)
                .Icon = My.Resources.assegno
                .MinimumSize = New Size(.Width, .Height)
            End With

            TabControl1.HotTrack = True
            StatusStrip1.BackColor = Drawing.SystemColors.Control

            LabelMessaggio.BackColor = StatusStrip1.BackColor
            LabelMessaggio.Text = ""
            LabelLicenza.BackColor = Color.Gainsboro

            With dtpDataIncasso
                .Format = DateTimePickerFormat.Custom
                .CustomFormat = "ddd dd/MM/yyyy"
                .MaxDate = Today

                If IsDate(Utx.NetFunc.GetEnvironmentVar("UNITOOLS_DATA_INCASSO")) Then
                    .Value = CDate(Utx.NetFunc.GetEnvironmentVar("UNITOOLS_DATA_INCASSO")).Date
                Else
                    .Value = Today
                End If
            End With

            With TextBoxAgenzia
                .Text = Globale.AgenziaRichiesta
                .TextAlign = HorizontalAlignment.Center
            End With
            With TextBoxSub
                .Text = ""
                .TextAlign = HorizontalAlignment.Center
            End With

            With LabelUtente
                .ForeColor = Color.Yellow
                .TextAlign = ContentAlignment.MiddleCenter
                .Text = "..."
            End With

            With btnAcquisisci
                .Padding = New Padding(5)
                .BackColor = SystemColors.Control
                .Text = "Acquisisci assegno"
                .TextAlign = ContentAlignment.MiddleRight
                .Image = My.Resources.assegno.ToBitmap
                .ImageAlign = ContentAlignment.MiddleLeft
                .Enabled = False
            End With

            With btnSalva
                .Padding = New Padding(5)
                .BackColor = SystemColors.Control
                .Text = "Salva"
                .TextAlign = ContentAlignment.MiddleRight
                .Image = My.Resources.Salva.ToBitmap
                .ImageAlign = ContentAlignment.MiddleLeft
                .Enabled = False
            End With
            With btnAnnulla
                .Padding = New Padding(5)
                .BackColor = SystemColors.Control
                .Text = "Annulla"
                .TextAlign = ContentAlignment.BottomCenter
                .Image = My.Resources.cancel.ToBitmap
                .ImageAlign = ContentAlignment.MiddleCenter
                .Enabled = False
            End With
            With ButtonStampaAssegni
                .Padding = New Padding(5)
                .Margin = New Padding(1)
                .Dock = DockStyle.Fill
                .FlatStyle = FlatStyle.Flat
                .FlatAppearance.BorderColor = Color.Gainsboro
                .BackColor = SystemColors.Control
                .Text = "Stampa assegni del giorno"
                .TextAlign = ContentAlignment.MiddleRight
                .Image = My.Resources.print.ToBitmap
                .ImageAlign = ContentAlignment.MiddleLeft
                .Enabled = True
            End With
            With tlpBottoni
                .Controls.Remove(btnLicenza)
                .Controls.Add(ButtonStampaAssegni)
                .SetCellPosition(ButtonStampaAssegni, New TableLayoutPanelCellPosition(0, 5))
                .SetColumnSpan(ButtonStampaAssegni, 4)
            End With

            With ButtonCambiaUtente
                .Padding = New Padding(0)
                .BackColor = SystemColors.Control
                .Text = "Cambia"
                .TextAlign = ContentAlignment.MiddleCenter
            End With
            tt.SetToolTip(ButtonCambiaUtente, "Cambia utente")

            With btnAggiornaIncassi
                .Padding = New Padding(0)
                .BackColor = SystemColors.Control
                .Text = "Aggiorna"
                .TextAlign = ContentAlignment.MiddleCenter
            End With
            tt.SetToolTip(btnAggiornaIncassi, "Aggiorna incassi")

            With btnLicenza
                .Visible = False
                .Padding = New Padding(5)
                .BackColor = SystemColors.Control
                .Text = "Attiva licenza"
                .TextAlign = ContentAlignment.MiddleRight
                .Image = My.Resources.licence
                .ImageAlign = ContentAlignment.MiddleLeft
            End With

            With btnEsci
                .Padding = New Padding(5)
                .BackColor = SystemColors.Control
                .Text = "Esci"
                .TextAlign = ContentAlignment.MiddleRight
                .Image = My.Resources.Esci.ToBitmap
                .ImageAlign = ContentAlignment.MiddleLeft
            End With

            With txtNote
                .BackColor = Color.LightYellow
                .TextAlign = HorizontalAlignment.Left
                .MaxLength = 100
            End With

            txtCodeLine.TextAlign = HorizontalAlignment.Center
            txtCodeLine.BackColor = Color.Gainsboro

            With btnImportoAssegno
                .BackColor = Color.Gainsboro
                .TextAlign = HorizontalAlignment.Center
                .Text = ""
            End With
            tt.SetToolTip(btnImportoAssegno, "clicca per modificare l'importo dell'assegno")

            With LabelTotaleTitoli
                .BackColor = Color.Gainsboro
                .AutoSize = False
                .Dock = DockStyle.Fill
                .BorderStyle = BorderStyle.FixedSingle
                .Text = ""
            End With

            With ListViewIncassi
                .View = View.Details
                .LabelEdit = False
                .FullRowSelect = True
                .GridLines = True
                .Sorting = SortOrder.Ascending

                .Columns.Add("Contraente", 10, HorizontalAlignment.Left)
                .Columns.Add("Euro", 10, HorizontalAlignment.Right)
                .Columns.Add("Ramo", 10, HorizontalAlignment.Right)
                .Columns.Add("Polizza", 10, HorizontalAlignment.Left)
                .Columns.Add("Cassa", 10, HorizontalAlignment.Center)

                .AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
            End With

            With dgvRicerca
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .MultiSelect = False
                .EditMode = DataGridViewEditMode.EditProgrammatically
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .CellBorderStyle = DataGridViewCellBorderStyle.Raised
            End With
            Globale.DoppioBuffer(dgvRicerca)

            PanelCerca.BackColor = Color.GreenYellow
            btnCerca.BackColor = Color.Gold
            btnCancellaAssegno.BackColor = Color.LightSalmon

            With txtImportoAssegno
                .TextAlign = HorizontalAlignment.Center
                .Text = 0
            End With

            With txtAbi
                .TextAlign = HorizontalAlignment.Center
                .Text = ""
            End With

            With txtContraente
                .TextAlign = HorizontalAlignment.Left
                .Text = ""
            End With

            btnAltroAssegno.BackColor = SystemColors.Control
            CheckBoxAnteprima.Checked = False

            SplitContainerCerca.Panel2Collapsed = True

            CaricaLogo(pbAnteprima)

            Return True

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Private Sub Form1_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        Me.Refresh()

        Deposito = New DepositoAssegni()

        If Deposito.Pronto Then
            CartellaAssegni = Deposito.CartellaAssegni(dtpDataIncasso.Value)

            'in InitC4Lib verifico la licenza e inizializzo lo scanner
            C4InitFlag = InitC4Lib()

            If C4InitFlag = True Then
                LetturaIncassi()
            End If

            txtNote.Focus()
        Else
            MsgBox("Cartella assegni non disponibile", MsgBoxStyle.Exclamation)
            Me.Close()
        End If

        With Globale.Log
            .Info("Impostazioni:")
            .Info("Agenzia madre: {0}", {Globale.AgenziaMadre})
            .Info("Agenzia richiesta: {0}", {Globale.AgenziaRichiesta})
            .Info("Connessione: {0}", {Globale.CnString})
            .Info("Deposito assegni: {0}", {Deposito.DepositoAssegni})
            .Info("Cartella assegni: {0}", {CartellaAssegni})
        End With
    End Sub

#Region "Scanner e immagini"

    Private Function InitC4Lib() As Boolean
        Try
            MessaggioStato.Messaggio("Inizializzazione in corso...")

            ImpostaHostName()

            C4 = New Emmedi.C4Cheque(Utx.Globale.Paths.CartellaApp)
            'C4 = New Emmedi.C4Cheque(Path.Combine(Utx.Globale.Paths.CartellaApp, "DLL"))

            Dim EsitoApertura As C4Enum.EmmediMsg = C4.Init(0, Path.Combine(Utx.Globale.Paths.CartellaSetting, "4Cheque.ini"))

            Globale.Log.Info(String.Format("Esito inizializzazione: {0}", C4Enum.DeskMsgEsteso(EsitoApertura)))

            If ControlloLicenza(EsitoApertura) = True Then
                StatoAgenzia = StatoLicenza.ATTIVA
                Return True
            Else
                StatoAgenzia = StatoLicenza.NON_ATTIVA
                Return False
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try

    End Function

    Private Function ControlloLicenza(ByVal Stato As C4Enum.EmmediMsg) As Boolean
        Try
            'senza questo si blocca tutto
            ScannerTimer = Nothing

            Select Case Stato

                Case C4Enum.EmmediMsg.FI_ATTIVATO
                    MessaggioStato.Messaggio(C4Enum.DeskMsg(Stato))
                    btnLicenza.Visible = False
                    Return ControllaScadenzaLicenza()

                Case C4Enum.EmmediMsg.FI_SOURCE_NOT_FOUND,
                     C4Enum.EmmediMsg.FI_SCANNER_NOT_SUPPORTED

                    'faccio partire il timer per rilevare lo scanner
                    ScannerTimer = New Timer
                    ScannerTimer.Interval = 5000
                    ScannerTimer.Enabled = True

                    MessaggioStato.Messaggio(C4Enum.DeskMsg(Stato), True)
                    btnLicenza.Visible = False
                    Return False

                Case C4Enum.EmmediMsg.FI_UNABLE_TO_OPEN_SOURCE,
                     C4Enum.EmmediMsg.FI_ERROR_LOADING_DLL,
                     C4Enum.EmmediMsg.FI_GENERIC_ERROR,
                     C4Enum.EmmediMsg.FI_NOT_INITIALIZED

                    MsgBox("Si è verificato un errore di inizializzazione dello scanner. " +
                           "Uscire dall'applicazione, spegnere e riaccendere lo scanner, " +
                           "chiudere altre applicazioni che stanno utilizzando lo scanner.",
                           MsgBoxStyle.Exclamation, Globale.TitoloApp)

                    Me.Close()
                    Return False

                Case Else '-99
                    'consulto il ws uniarea per decidere come comportarmi
                    StatoUniarea = New AbilitazioneAgenzia(Globale.AgenziaMadre)

                    If StatoUniarea.Esito.Errore = AbilitazioneAgenzia.CodiceErrore.OK Then

                        Select Case StatoUniarea.Esito.Stato

                            Case AbilitazioneAgenzia.StatoAgenzia.ATTIVATA
                                'NON dovrebbe arrivare mai qui (agenzia attivata uniarea/non attivata emmedi)
                                VisualizzaEtichettaDemo("...")
                                tlpBottoni.Controls.Remove(ButtonStampaAssegni)
                                tlpBottoni.Controls.Add(btnLicenza)
                                tlpBottoni.SetCellPosition(btnLicenza, New TableLayoutPanelCellPosition(0, 5))
                                tlpBottoni.SetColumnSpan(btnLicenza, 4)
                                btnLicenza.Visible = True
                                Return AttivaLicenza()

                            Case AbilitazioneAgenzia.StatoAgenzia.NON_ATTIVA
                                VisualizzaEtichettaDemo("Licenza non attivata")
                                tlpBottoni.Controls.Remove(ButtonStampaAssegni)
                                tlpBottoni.Controls.Add(btnLicenza)
                                tlpBottoni.SetCellPosition(btnLicenza, New TableLayoutPanelCellPosition(0, 5))
                                tlpBottoni.SetColumnSpan(btnLicenza, 4)
                                btnLicenza.Visible = True
                                Return AttivaLicenza()

                            Case AbilitazioneAgenzia.StatoAgenzia.DEMO
                                VisualizzaEtichettaDemo("Periodo di prova")
                                Return AttivaDemo()

                            Case AbilitazioneAgenzia.StatoAgenzia.BLOCCATA
                                btnLicenza.Visible = False
                                VisualizzaEtichettaDemo("Licenza non disponibile")
                                MsgBox("Contattare Uniarea 051.6313108", MsgBoxStyle.Information)
                                Return False
                            Case Else
                                btnLicenza.Visible = False
                                VisualizzaEtichettaDemo("Errore non previsto")
                                Return False
                        End Select

                    ElseIf StatoUniarea.Esito.Errore = AbilitazioneAgenzia.CodiceErrore.NO_DATI Then
                        MsgBox("Anagrafica agenzia non trovata. Contattare Uniarea al numero 051.6313108", MsgBoxStyle.Information)
                        Return False
                    Else
                        MsgBox("Richiesta attivazione con codice agenzia errato", MsgBoxStyle.Exclamation)
                        Return False
                    End If
            End Select

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Private Sub ScannerTimer_Tick(sender As Object, e As EventArgs) Handles ScannerTimer.Tick
        C4InitFlag = InitC4Lib()

        If C4InitFlag = True Then
            LetturaIncassi()
        End If
    End Sub

    Private Sub ImpostaHostName()
        Try
            Dim FileIni As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "4chequemdk.ini")
            File.WriteAllText(FileIni, String.Format("[GENERAL]{0}HOSTNAME={1}", Environment.NewLine, Globale.AgenziaMadre))
        Catch ex As Exception
            'possibili conflitti fra più utenti che scrivono contemporaneamente
            'non fare niente
        End Try
    End Sub

    Private Sub btnAcquisisci_Click(sender As System.Object, e As System.EventArgs) Handles btnAcquisisci.Click
        Try
            ControlloSalvataggio()

            MessaggioStato.Messaggio("Scansione in corso...")

            ListViewIncassi.Enabled = False
            btnAcquisisci.Enabled = False

            If C4InitFlag = False Then C4InitFlag = InitC4Lib()
            If C4InitFlag = False Then Exit Sub

            Cursor.Current = Cursors.WaitCursor

            Dim f, r, c As New StringBuilder

            C4.SetParam(C4Enum.ParametriScanner.CARTELLA_DESTINAZIONE, Utx.Globale.Paths.CartellaTempUtente)
            C4.SetParam(C4Enum.ParametriScanner.RISOLUZIONE, "200")
            C4.SetParam(C4Enum.ParametriScanner.TIPO_SCANSIONE, "1") 'colore
            C4.SetParam(C4Enum.ParametriScanner.FORMATO_IMMAGINE, "5") 'JPG

            'effettuo la scansione
            Dim EsitoScansione As Integer = C4.Scan(0, 1, 0, f, r, c)

            'scansione ok
            If EsitoScansione = 1 Then

                If c.ToString.Trim.Length > 0 Then
                    Titolo = New Assegno(Deposito, dtpDataIncasso.Value, "jpg") With {
                        .Fronte = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, f.ToString),
                        .Retro = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, r.ToString)}

                    UnisciFronteRetro()

                    AddHandler txtCodeLine.KeyPress, AddressOf txtCodeLine_KeyPress
                    AddHandler txtCodeLine.TextChanged, AddressOf txtCodeLine_TextChanged

                    txtCodeLine.ReadOnly = False
                    txtCodeLine.Enabled = True
                    txtCodeLine.Text = c.ToString
                Else
                    'in questo caso (codeline vuoto) l'assegno probabilmente non è stato inserito correttamente
                    MsgBox("La codeline dell'assegno è vuota. L'assegno non è stato inserito correttamente nello scanner. Guarda l'immagine.",
                           MsgBoxStyle.Exclamation, Globale.TitoloApp)
                End If
            Else
                MessaggioStato.Messaggio(C4Enum.DeskMsg(EsitoScansione), True)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            ListViewIncassi.Enabled = True
            btnAcquisisci.Enabled = True
        End Try
    End Sub

    Private Sub UnisciFronteRetro()
        Try
            If JoinImg.LoadJoinImg() = True Then

                If File.Exists(Titolo.PathTempImg) Then
                    File.Delete(Titolo.PathTempImg)
                End If

                Dim risultato_join As Integer = JoinImg.JOINImagesExt(Titolo.Fronte, Titolo.Retro, Titolo.PathTempImg, 0, 50, 0, 1)

                JoinImg.FreeJoinImg()

                If risultato_join = JoinImg.JoinResult.OK Then
                    Globale.Log.Info("Unione fronte/retro ok")
                Else
                    Globale.Log.Info(JoinImg.ResultDesk(risultato_join))
                    MsgBox(JoinImg.ResultDesk(risultato_join), MsgBoxStyle.Exclamation)
                End If

                File.Delete(Titolo.Fronte)
                File.Delete(Titolo.Retro)
            Else
                MessaggioStato.Messaggio("Impossibile caricare JoinImg", True)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub txtCodeLine_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) Then
            e.KeyChar = "?"
        End If
    End Sub

    Private Sub txtCodeLine_TextChanged(sender As Object, e As System.EventArgs)
        Titolo.CodeLine = txtCodeLine.Text
    End Sub

    Private Sub Titolo_CodeLineError() Handles Titolo.CodeLineError
        'se c'è l'errore sulla codeline carico l'immagine temporanea
        CaricaImmagine(pbAnteprima, Titolo.PathTempImg)

        'caratteri non identificati
        Dim PosizioneCarattereNonValido As Integer = Titolo.PosizioneCarattereNonValido

        If PosizioneCarattereNonValido >= 0 Then
            txtCodeLine.ForeColor = Color.Red
            txtCodeLine.BackColor = Color.Yellow

            txtCodeLine.SelectionStart = PosizioneCarattereNonValido
            txtCodeLine.SelectionLength = 1

            txtCodeLine.Focus()
        End If

    End Sub

    Private Sub Titolo_CodeLineOk() Handles Titolo.CodeLineOk
        Try
            MessaggioStato.Messaggio("Salvo immagine...")

            RemoveHandler txtCodeLine.KeyPress, AddressOf txtCodeLine_KeyPress
            RemoveHandler txtCodeLine.TextChanged, AddressOf txtCodeLine_TextChanged

            'blocco il textbox con il codeline
            txtCodeLine.Enabled = False
            txtCodeLine.ForeColor = Color.Black
            txtCodeLine.BackColor = Color.PaleGreen

            'cancello il file in caso esiste (scansiono l'assegno 2 volte)
            If File.Exists(Titolo.FullPathAssegno) Then
                File.Delete(Titolo.FullPathAssegno)
            End If

            'rinomino con il nome definitivo
            File.Move(Titolo.PathTempImg, Titolo.FullPathAssegno)

            'carico immagine se non è stata caricata prima
            MessaggioStato.Messaggio("Carico anteprima...")
            CaricaImmagine(pbAnteprima, Titolo.FullPathAssegno)

            btnSalva.Enabled = True
            Me.AcceptButton = btnSalva

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            MessaggioStato.Messaggio("")
        End Try
    End Sub

#End Region

    Private Sub LetturaIncassi()
        Try
            If StatoAgenzia = StatoLicenza.NON_ATTIVA Then
                MsgBox("Licenza non disponibile. Agenzia non attivata.", MsgBoxStyle.Information, Globale.TitoloApp)
                Exit Sub
            End If

            If String.IsNullOrEmpty(Utx.Globale.UtenteCorrente.UniageUser) OrElse String.IsNullOrEmpty(Utx.Globale.UtenteCorrente.UniagePw) Then
                'richiesta login
                Using f As New FormLogin
                    f.ShowDialog()
                    If f.DialogResult = DialogResult.OK Then
                        Utx.Globale.UtenteCorrente.UniageUser = f.User
                        Utx.Globale.UtenteCorrente.UniagePw = f.Pw
                    Else
                        Exit Sub
                    End If
                End Using
            End If

            Cursor.Current = Cursors.WaitCursor

            'la pulizia la metto qui per un effetto visivo per l'utente
            ListViewIncassi.Items.Clear()
            ListViewIncassi.Refresh()

            AbbinamentoAssegni.Reset()

            MessaggioStato.Messaggio("Lettura incassi: login")

            Login.LogIn(Utx.Globale.UtenteCorrente.UniageUser, Utx.Globale.UtenteCorrente.UniagePw, Utx.Globale.UtenteCorrente.Dominio)

            If Login.Stato = Utx.Autenticazione.StatoLogin.LOGIN Then

                LabelUtente.Text = Utx.Globale.UtenteCorrente.UniageUser

                MessaggioStato.Messaggio("Lettura incassi: importa")

                Importa = New ExportLib.Export(Globale.AgenziaRichiesta) With {.Cookie = Login.CookieContainer}

                'leggo gli incassi
                Dim dt As DataTable = Importa.IncassiGiornalieri(dtpDataIncasso.Value, TextBoxSub.Text)

                MessaggioStato.Messaggio("Lettura incassi: abbinamenti")

                SommaUnibox(dt)
                CaricaIncassi(dt)
            Else
                LabelUtente.Text = Utx.Globale.UtenteCorrente.UniageUser
                MessaggioStato.Messaggio("Errore di connessione ad Essig", True)
                MsgBox("Errore di connessione ad Essig. User e/o password probabilmente errati.", MsgBoxStyle.Exclamation, Globale.TitoloApp)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            MessaggioStato.Messaggio(ex.Message, True)
        End Try
    End Sub

    Private Sub SommaUnibox(ByRef dt As DataTable)
        Try
            'la ricerca delle righe non si può fare con una chiave primaria perchè ci sono doppioni
            For Each r As DataRow In dt.Rows

                'se la riga è un canone
                If Trim(r("TipoMovimento")).ToUpper = "CANONE" Then

                    'cerco la polizza (non canone) rg=1
                    For Each rp As DataRow In dt.Rows

                        If rp("Ramo") = r("Ramo") AndAlso
                           rp("Polizza") = r("Polizza") AndAlso
                           rp("DataEffettoTitolo") = r("DataEffettoTitolo") AndAlso
                           rp("RamoGestione") = 1 Then

                            'così l'importo viene sommato a quello della polizza e la riga del canone
                            'non viene considerata fra gli incassi con assegno azzerando il tipo di pagamento
                            rp("ImportoIncassato") += r("TotaleTitolo")
                            r("TipoPagamento") = ""
                        End If
                    Next
                End If
            Next

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub LabelMessaggio_TextChanged(sender As Object, e As System.EventArgs)
        StatusStrip1.Refresh()
    End Sub

    Private Sub CalcolaTotale()
        Dim Totale As Double = 0

        If ListViewIncassi.Items.Count > 0 Then
            For Each i As ListViewItem In ListViewIncassi.CheckedItems
                Totale += i.SubItems(1).Text
            Next
        End If

        With AbbinamentoAssegni
            .TotaleTitoli = Totale
            'importo degli assegni residui ancora da abbinare agli incassi selezionati
            .AssegnoResiduo = .TotaleTitoli - .ImportoTotaleAssegni
            .AssegnoCorrente = .AssegnoResiduo
        End With

        'aggiorno la casella del totale
        AggiornaTotali()

        'bottone acquisisci
        btnAcquisisci.Enabled = (ListViewIncassi.CheckedItems.Count > 0)
    End Sub

    Private Sub AggiornaTotali()
        btnImportoAssegno.Text = String.Format("Assegno: {0:C}", AbbinamentoAssegni.AssegnoCorrente)
        LabelTotaleTitoli.Text = String.Format("Titoli selezionati: {0:C}", AbbinamentoAssegni.TotaleTitoli)

        'coloro lo sfondo
        If AbbinamentoAssegni.TotaleTitoli > 0 Then
            btnImportoAssegno.BackColor = Color.PaleGreen
            LabelTotaleTitoli.BackColor = Color.Gold
        Else
            btnImportoAssegno.BackColor = Color.Gainsboro
            LabelTotaleTitoli.BackColor = Color.Gainsboro
        End If

    End Sub

    Private Sub btnSalva_Click(sender As System.Object, e As System.EventArgs) Handles btnSalva.Click
        If SalvaAssegno() = True Then

            ListViewIncassi.Enabled = True
            btnAcquisisci.Enabled = True

            txtNote.Text = ""
            txtCodeLine.Text = ""
            txtCodeLine.BackColor = Color.Gainsboro
            CaricaLogo(pbAnteprima)
        Else
            btnSalva.Enabled = True
        End If
    End Sub

    Private Sub CaricaIncassi(ByRef Incassi As DataTable)
        Try
            RemoveHandler ListViewIncassi.ItemChecked, AddressOf ListViewIncassi_ItemChecked

            Dim Abbinate As DataTable = LeggiPolizzeAbbinate()

            'se ci sono incassi
            If Incassi.Rows.Count > 0 Then

                'per ogni incasso
                For Each dr As DataRow In Incassi.Rows

                    'se è stato pagato con assegno oppure è un pagamento misto
                    If (dr("TipoPagamento").ToString = "A") OrElse
                       (dr("TipoPagamento").ToString = "M") Then

                        Dim PolizzaAbbinata As Boolean = False

                        For Each row As DataRow In Abbinate.Rows

                            If dr("Ramo") = row("Ramo") AndAlso
                               dr("Polizza") = row("Polizza") AndAlso
                               dr("DataEffettoTitolo") = row("DataEffettoTitolo") Then

                                PolizzaAbbinata = True
                                Exit For
                            End If
                        Next

                        'se non è ancora abbinato in archivio
                        If PolizzaAbbinata = False Then

                            Dim i As New ListViewItem(Microsoft.VisualBasic.Left(dr("Contraente"), 20))

                            'nel tag memorizzo il datarow associato
                            i.Tag = dr

                            If Trim(dr("CodiceCassa")).ToUpper = Utx.Globale.UtenteCorrente.UniageUser.Substring(6).ToUpper Then
                                i.Checked = True
                            End If

                            With i.SubItems
                                .Add(Format(dr("ImportoIncassato"), "###,##0.00"))
                                .Add(Format(dr("Ramo"), "000"))
                                .Add(dr("Polizza"))
                                .Add(dr("CodiceCassa"))
                            End With

                            ListViewIncassi.Items.Add(i)
                        End If
                    End If
                Next
            End If

            FormattaListaIncassi()

            CalcolaTotale()

            AddHandler ListViewIncassi.ItemChecked, AddressOf ListViewIncassi_ItemChecked

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

    End Sub

    Private Sub ListViewIncassi_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs)
        CalcolaTotale()
    End Sub

    Private Sub btnAggiornaIncassi_Click(sender As System.Object, e As System.EventArgs) Handles btnAggiornaIncassi.Click
        LetturaIncassi()
    End Sub

    Private Sub ControlloSalvataggio()
        Try
            If btnSalva.Enabled = True Then

                If MsgBox("Salvare l'operazione in corso?",
                           MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton1,
                           Globale.TitoloApp) = MsgBoxResult.Yes Then

                    'se c'è stato un errore
                    If SalvaAssegno() = False Then

                        MsgBox("Si è verificato un errore nel salvataggio dei dati.",
                               MsgBoxStyle.Critical, Globale.TitoloApp)

                        File.Delete(Titolo.FullPathAssegno)
                    End If
                Else
                    File.Delete(Titolo.FullPathAssegno)
                End If
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            btnSalva.Enabled = False
            btnAcquisisci.Enabled = True
            ListViewIncassi.Enabled = True
        End Try
    End Sub

    Private Sub btnEsci_Click(sender As System.Object, e As System.EventArgs) Handles btnEsci.Click
        ControlloSalvataggio()
        Me.Close()
    End Sub

    Private Function SalvaAssegno() As Boolean
        Try
            btnSalva.Enabled = False

            SalvaAssegno = True

            'il tag contiene l'importo non formattato
            Titolo.ImportoAssegno = AbbinamentoAssegni.AssegnoCorrente
            Titolo.Note = txtNote.Text.Trim

            'salvo 
            For Each i As ListViewItem In ListViewIncassi.CheckedItems

                Titolo.DatiPolizza = i.Tag

                SalvaAssegno = Titolo.RegistraAssegno()
            Next

            'se è tutto ok 
            If SalvaAssegno = True Then

                'sommo l'assegno salvato al totale degli assegni
                AbbinamentoAssegni.ImportoTotaleAssegni += AbbinamentoAssegni.AssegnoCorrente

                'e se il totale titoli è minore o uguale al totale assegni > abbinamento concluso
                If AbbinamentoAssegni.TotaleTitoli <= AbbinamentoAssegni.ImportoTotaleAssegni Then
                    'rimuovo le righe selezionate
                    For Each i As ListViewItem In ListViewIncassi.CheckedItems
                        i.Remove()
                    Next

                    'abbinamento concluso
                    AbbinamentoAssegni.Reset()
                End If

                'ricalcolo i totali
                CalcolaTotale()
            Else
                'errore e quindi cancello assegno
                Assegno.CancellaRecordAssegno(Titolo.IdAssegno)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Private Function LeggiPolizzeAbbinate() As DataTable
        Try
            Using cn As New OleDbConnection(Globale.CnString)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT Ramo,Polizza,DataEffettoTitolo FROM Assegni WHERE DataFoglioCassa = ?"

                    cmd.Parameters.AddWithValue("Data", dtpDataIncasso.Value.Date)

                    Using da As New OleDbDataAdapter(cmd)
                        LeggiPolizzeAbbinate = New DataTable
                        da.Fill(LeggiPolizzeAbbinate)
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
            LeggiPolizzeAbbinate = New DataTable
        End Try
    End Function

    Private Sub TabPageRicerca_Enter(sender As Object, e As System.EventArgs) Handles TabPageRicerca.Enter
        Me.AcceptButton = btnCerca
        MessaggioStato.Messaggio()
        txtImportoAssegno.Focus()
    End Sub

    Private Sub CercaAssegni()
        Try
            Cursor = Cursors.WaitCursor

            Using cn As New OleDbConnection(Globale.CnString)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT * FROM Assegni " +
                                      "WHERE " + ClausolaImporto() + " AND " + ClausolaAbi() + " AND " + ClausolaContraente() +
                                      "ORDER BY DataFoglioCassa DESC,Contraente"

                    Using da As New OleDbDataAdapter(cmd)
                        Dim dt As New DataTable
                        da.Fill(dt)

                        dgvRicerca.DataSource = dt

                        FormattaColonne()

                        dgvRicerca.AutoResizeColumns()
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dgvRicerca_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvRicerca.MouseDoubleClick
        ApriFileAssegno()
    End Sub

    Private Sub pbAnteprimaCerca_DoubleClick(sender As Object, e As EventArgs) Handles pbAnteprimaCerca.DoubleClick
        ApriFileAssegno()
    End Sub

    Private Sub FormattaColonne()
        On Error Resume Next

        With dgvRicerca
            .SuspendLayout()

            With .Columns("Contraente")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With
            .Columns("Ramo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Polizza").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            With .Columns("DataEffettoTitolo")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Data effetto"
            End With
            With .Columns("DataFoglioCassa")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Data incasso"
            End With
            With .Columns("IdAssegno")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                .HeaderText = "Codeline"
            End With
            With .Columns("ImportoIncassato")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
                .HeaderText = "Incassato"
            End With
            With .Columns("ImportoAssegno")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
                .HeaderText = "Assegno"
                .DefaultCellStyle.BackColor = Color.NavajoWhite
            End With
            With .Columns("Annotazioni")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .HeaderText = "Note"
            End With

            .ResumeLayout()

            .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        End With

        For Each c As DataGridViewColumn In dgvRicerca.Columns
            c.SortMode = DataGridViewColumnSortMode.Programmatic
        Next

    End Sub

    Private Sub btnCerca_Click(sender As System.Object, e As System.EventArgs) Handles btnCerca.Click
        CercaAssegni()
        MessaggioStato.Messaggio(String.Format("Trovati {0} assegni", dgvRicerca.Rows.Count))
    End Sub

    Private Function ClausolaImporto() As String
        If IsNumeric(txtImportoAssegno.Text) Then
            If txtImportoAssegno.Text = 0 Then
                Return " True "
            Else
                Return String.Format(" ImportoAssegno = {0} ", txtImportoAssegno.Text.Replace(",", "."))
            End If
        Else
            txtImportoAssegno.Text = 0
            Return " True "
        End If
    End Function

    Private Function ClausolaAbi() As String
        If IsNumeric(txtAbi.Text) Then
            If txtAbi.Text = 0 Then
                txtAbi.Text = ""
                Return " True "
            Else
                txtAbi.Text = txtAbi.Text.PadLeft(5, "0")
                Return String.Format(" Mid(IdAssegno,12,5) = {0} ", txtAbi.Text)
            End If
        Else
            txtAbi.Text = ""
            Return " True "
        End If
    End Function

    Private Function ClausolaContraente() As String
        If String.IsNullOrEmpty(txtContraente.Text) Then
            Return " True "
        Else
            Return String.Format(" Contraente LIKE '%{0}%' ", txtContraente.Text)
        End If
    End Function

    Private Sub TabPageScan_Enter(sender As Object, e As System.EventArgs) Handles TabPageScan.Enter
        Me.AcceptButton = btnAcquisisci
    End Sub

    Private Sub CaricaImmagine(ByRef Pb As PictureBox,
                               ByVal ImgPath As String,
                               Optional ByVal Ricarica As Boolean = False)
        Try
            If (Pb.Tag <> ImgPath) OrElse (Ricarica = True) Then

                Using fs As New FileStream(ImgPath, FileMode.Open, FileAccess.Read)
                    Pb.Image = System.Drawing.Image.FromStream(fs)
                    Pb.Tag = ImgPath
                End Using
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub CaricaLogo(ByRef Pb As PictureBox)
        Pb.SizeMode = PictureBoxSizeMode.StretchImage
        Pb.Image = My.Resources.splash_assegni
        Pb.Tag = "LOGO"
    End Sub

    Private Sub btnCancellaAssegno_Click(sender As System.Object, e As System.EventArgs) Handles btnCancellaAssegno.Click
        If dgvRicerca.CurrentRow Is Nothing Then Exit Sub
        If dgvRicerca.CurrentRow.Index < 0 Then Exit Sub

        'se cancello i records cancello anche il file
        If Assegno.CancellaRecordAssegno(dgvRicerca.CurrentRow.Cells("IdAssegno").Value) = True Then

            Assegno.CancellaFileAssegno(Deposito,
                                        dgvRicerca.CurrentRow.Cells("DataFoglioCassa").Value,
                                        dgvRicerca.CurrentRow.Cells("IdAssegno").Value)

            dgvRicerca.DataSource = Nothing
        End If
    End Sub

    Private Sub btnAltroAssegno_Click(sender As System.Object, e As System.EventArgs) Handles btnAltroAssegno.Click
        Try
            If dgvRicerca.CurrentRow Is Nothing Then Exit Sub
            If dgvRicerca.CurrentRow.Index < 0 Then Exit Sub

            ListViewIncassi.Items.Clear()

            'riporto le righe selezionate nella list view (1 sola riga)
            For Each r As DataGridViewRow In dgvRicerca.SelectedRows

                Dim row As DataRow = dgvRicerca.DataSource.Rows(r.Index)

                Dim i As New ListViewItem(Microsoft.VisualBasic.Left(row("Contraente"), 20))

                'nel tag memorizzo il datarow associato
                i.Tag = row
                i.Checked = True

                With i.SubItems
                    .Add(Format(row("ImportoIncassato"), "###,##0.00"))
                    .Add(Format(row("Ramo"), "000"))
                    .Add(row("Polizza"))
                    .Add("")
                End With

                ListViewIncassi.Items.Add(i)

                'importantissimo per il corretto path in cui salvare il file
                dtpDataIncasso.Value = row("DataFoglioCassa")
            Next

            FormattaListaIncassi()

            TabControl1.SelectedTab = TabPageScan

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

    End Sub

    Private Sub btnImportoAssegno_Click(sender As System.Object, e As System.EventArgs) Handles btnImportoAssegno.Click
        If ListViewIncassi.CheckedItems.Count > 0 Then
            Dim Importo As String = InputBox("Importo assegno", Globale.TitoloApp, btnImportoAssegno.Tag)
            If IsNumeric(Importo) Then
                AbbinamentoAssegni.AssegnoCorrente = Importo
                AggiornaTotali()
            End If
        Else
            MsgBox("Selezionare prima gli incassi da associare all'assegno.", MsgBoxStyle.Information, Globale.TitoloApp)
        End If
    End Sub

    Private Sub FormattaListaIncassi()
        If ListViewIncassi.Items.Count > 0 Then
            With ListViewIncassi
                .Columns(0).Width = 135
                .Columns(1).Width = 67
                .Columns(2).Width = 33
                .Columns(3).Width = 75
                .Columns(4).Width = 30
            End With

            MessaggioStato.Messaggio(String.Format("Incassi trovati e non abbinati: {0}", ListViewIncassi.Items.Count))
        Else
            ListViewIncassi.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
            MessaggioStato.Messaggio("Non ci sono nuovi incassi con assegno.", True)
        End If
    End Sub

    Private Sub CheckBoxAnteprima_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBoxAnteprima.CheckedChanged
        If CheckBoxAnteprima.Checked = False Then
            RemoveHandler dgvRicerca.SelectionChanged, AddressOf dgvRicerca_SelectionChanged
            SplitContainerCerca.Panel2Collapsed = True
        Else
            SplitContainerCerca.SplitterDistance = SplitContainerCerca.Width / 2
            SplitContainerCerca.Panel2Collapsed = False

            If dgvRicerca.CurrentRow Is Nothing Then
                CaricaLogo(pbAnteprimaCerca)
            Else
                dgvRicerca_SelectionChanged(Me, New EventArgs)
            End If

            AddHandler dgvRicerca.SelectionChanged, AddressOf dgvRicerca_SelectionChanged
        End If
    End Sub

    Private Sub dgvRicerca_SelectionChanged(sender As Object, e As System.EventArgs)
        Try
            If dgvRicerca.SelectedRows.Count > 0 Then

                Dim FileImg As String = Assegno.PathAssegno(Deposito,
                                                            dgvRicerca.CurrentRow.Cells("DataFoglioCassa").Value,
                                                            dgvRicerca.CurrentRow.Cells("IdAssegno").Value)
                If File.Exists(FileImg) Then
                    CaricaImmagine(pbAnteprimaCerca, FileImg)
                    LabelMessaggio.Text = ""
                    LabelMessaggio.ForeColor = Color.Black
                Else
                    pbAnteprimaCerca.Image = Nothing
                    pbAnteprimaCerca.Tag = ""
                    LabelMessaggio.Text = "Impossibile trovare l'assegno " & dgvRicerca.CurrentRow.Cells("IdAssegno").Value
                    LabelMessaggio.ForeColor = Color.Red
                End If
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub btnDiminuisciCarattere_Click(sender As System.Object, e As System.EventArgs) Handles btnDiminuisciCarattere.Click
        ModificaCarattereGriglia(-1)
    End Sub

    Private Sub btnAumentaCarattere_Click(sender As System.Object, e As System.EventArgs) Handles btnAumentaCarattere.Click
        ModificaCarattereGriglia(1)
    End Sub

    Private Sub ModificaCarattereGriglia(ByVal Incremento As Integer)
        dgvRicerca.Font = New Font(dgvRicerca.Font.Name, dgvRicerca.Font.Size + Incremento)
        dgvRicerca.AutoResizeColumns()
    End Sub

    Private Function AttivaDemo() As Boolean
        Try
            If IsDate(StatoUniarea.Esito.DataAttivazione) Then
                'demo già attivato
                Me.Text = Me.Text + " (Periodo di prova)"
                Return (StatoUniarea.Esito.DataScadenza > Today)
            Else
                'demo non ancora attivato
                MessaggioStato.Messaggio("Attivazione periodo di prova...")

                StatoUniarea.AttivaLicenzaUniarea()

                If IsDate(StatoUniarea.Esito.DataAttivazione) Then
                    'attivazione uniarea riuscita
                    Using sw As New StreamWriter(Path.Combine(Utx.Globale.Paths.CartellaSettingRete, "SetTrial.txt"))
                        sw.WriteLine(String.Format("Attivazione demo: {0}", Now))
                    End Using

                    Globale.Log.Info("Attivato periodo di prova")

                    MsgBox("Licenza di prova attivata correttamente. E' necessario riavviare la scansione assegni.",
                           MsgBoxStyle.Information, Globale.TitoloApp)

                    Me.Close()

                    Return True
                Else
                    Return False
                End If
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        Finally
            If AttivaDemo = True Then
                MessaggioStato.Messaggio("Periodo di prova attivato")
            Else
                MessaggioStato.Messaggio("Attivazione Uniarea non riuscita", True)
            End If
        End Try

    End Function

    Private Function AttivaLicenza() As Boolean
        Try
            MessaggioStato.Messaggio("Attivazione licenza...")

            Dim f As New FormLicenza
            With f
                .Size = New Size(570, 290)
                .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
                .MaximizeBox = False
                .MinimizeBox = False
                .StartPosition = FormStartPosition.CenterScreen

                .StatoUniarea = StatoUniarea

                .ShowDialog()
            End With

            Select Case f.EsitoRichiesta

                Case FormLicenza.RichiestaEmmedi.OK
                    StatoUniarea.AttivaLicenzaUniarea()

                    If IsDate(StatoUniarea.Esito.DataAttivazione) Then

                        'segno la data di scadenza anche in locale. questa data verrà controllata ogni giorno
                        'accedendo al web service
                        Dim dl As AbilitazioneAgenzia.DatiLicenza
                        dl.ScadenzaLicenza = StatoUniarea.Esito.DataScadenza
                        dl.PingLicenza = Today
                        SalvaConfig(dl)

                        btnLicenza.Visible = False

                        MsgBox("Licenza attivata correttamente. E' necessario riavviare la scansione assegni.",
                               MsgBoxStyle.Information, Globale.TitoloApp)

                        Dim EsitoApertura As C4Enum.EmmediMsg = C4.Init(0, Path.Combine(Utx.Globale.Paths.CartellaSetting, "4Cheque.ini"))

                        Me.Close()

                        Return True
                    Else
                        Return False
                    End If

                Case FormLicenza.RichiestaEmmedi.ANNULLATA
                    Return False

                Case FormLicenza.RichiestaEmmedi.ERRORE
                    Return False

                Case Else
                    Return False
            End Select

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        Finally
            If AttivaLicenza = True Then
                MessaggioStato.Messaggio("Licenze attivate correttamente")
            Else
                MessaggioStato.Messaggio("Attivazione licenze non riuscita", True)
            End If
        End Try

    End Function

    Private Sub ApriFileAssegno()
        Try
            If dgvRicerca.SelectedRows.Count > 0 Then

                Dim Cartella As String = Deposito.CartellaAssegni(dgvRicerca.CurrentRow.Cells("DataFoglioCassa").Value)
                Dim FileImg As String = Path.Combine(Cartella, dgvRicerca.CurrentRow.Cells("IdAssegno").Value) + ".jpg"

                If File.Exists(FileImg) Then
                    Process.Start(FileImg)
                Else
                    MsgBox("Impossibile trovare l'assegno richiesto", MsgBoxStyle.Exclamation, Globale.TitoloApp)
                End If
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub btnLicenza_Click(sender As Object, e As EventArgs) Handles btnLicenza.Click
        AttivaLicenza()
    End Sub

    Public Function ControllaScadenzaLicenza() As Boolean
        Try
            'utilizzo 2 tag per ok e blocco salvati come MD5
            'anche la data di controllo (PingLicenza) viene salvata come MD%
            Dim TagOk As String = String.Format("Ut{0}Ok", Format(Today, "yyyyMMdd"))
            Dim TagBlocco As String = String.Format("Ut{0}Blocco", Format(Today, "yyyyMMdd"))

            Dim dl As AbilitazioneAgenzia.DatiLicenza = LoadConfig()

#If DEBUG Then
            'per debug
            'dl.PingLicenza = utx.NetFunc.StringToMD5(Today.AddDays(-1))
#End If

            If dl.PingLicenza = Utx.NetFunc.StringToMD5(Today) Then
                'il controllo è già avvenuto oggi
                ControllaScadenzaLicenza = (Utx.NetFunc.StringToMD5(TagOk) = dl.ScadenzaLicenza)
            Else
                Globale.Log.Info("Controllo scadenza licenza")

                StatoUniarea = New AbilitazioneAgenzia(Globale.AgenziaMadre)

                If (StatoUniarea.Esito Is Nothing) OrElse
                   (IsDate(StatoUniarea.Esito.DataScadenza) = False) Then

                    'c'e stato un errore nel ws: faccio andare avanti
                    dl.PingLicenza = Utx.NetFunc.StringToMD5(Today.AddDays(-1)) 'così al prossimo avvio ricontrolla
                    dl.ScadenzaLicenza = Utx.NetFunc.StringToMD5(TagOk)
                    SalvaConfig(dl)

                    Globale.Log.Info("Il server non risponde: impossibile controllare la scadenza della licenza")
                    ControllaScadenzaLicenza = True

                ElseIf StatoUniarea.Esito.Errore = AbilitazioneAgenzia.CodiceErrore.OK Then

                    dl.PingLicenza = Utx.NetFunc.StringToMD5(Today)
                    dl.Scadenza = StatoUniarea.Esito.DataScadenza

                    If CDate(StatoUniarea.Esito.DataScadenza).AddDays(-7) > Today Then
                        'la data per l'alert non è ancora arrivata
                        dl.ScadenzaLicenza = Utx.NetFunc.StringToMD5(TagOk)
                        SalvaConfig(dl)
                        ControllaScadenzaLicenza = True

                    ElseIf CDate(StatoUniarea.Esito.DataScadenza) < Today Then
                        'licenza scaduta blocco
                        dl.ScadenzaLicenza = Utx.NetFunc.StringToMD5(TagBlocco)
                        SalvaConfig(dl)

                        MsgBox(String.Format("Attenzione: licenza scansione assegni scaduta il {1:d}.{0}" +
                                             "Contattare Uniarea per il rinnovo.",
                                             Environment.NewLine,
                                             StatoUniarea.Esito.DataScadenza),
                                         MsgBoxStyle.Information, Globale.TitoloApp)
                        ControllaScadenzaLicenza = False

                    Else
                        'scade fra meno di 7 giorni: alert e vado avanti
                        dl.ScadenzaLicenza = Utx.NetFunc.StringToMD5(TagOk)
                        SalvaConfig(dl)

                        MsgBox(String.Format("Attenzione: la licenza scansione assegni scadrà il {1:d}.{0}" +
                                             "Contattare Uniarea per il rinnovo.",
                                             Environment.NewLine,
                                             StatoUniarea.Esito.DataScadenza),
                                         MsgBoxStyle.Information, Globale.TitoloApp)
                        ControllaScadenzaLicenza = True
                    End If
                Else
                    'c'e stato un errore non previsto: faccio andare avanti
                    dl.PingLicenza = Utx.NetFunc.StringToMD5(Today.AddDays(-1)) 'così al prossimo avvio ricontrolla
                    dl.ScadenzaLicenza = Utx.NetFunc.StringToMD5(TagOk)
                    SalvaConfig(dl)

                    Globale.Log.Info("Errore nel controllo della licenza")

                    ControllaScadenzaLicenza = True
                End If

            End If

            VisualizzaEtichettaLicenza(dl.Scadenza)

        Catch ex As Exception
            Globale.Log.Errore(ex)
            ControllaScadenzaLicenza = False
        End Try

    End Function

    Public Sub SalvaConfig(ByVal Dati As AbilitazioneAgenzia.DatiLicenza)
        Try
            'salvo dati delegato
            Dim ser As New XmlSerializer(GetType(AbilitazioneAgenzia.DatiLicenza))
            Using fs As New StreamWriter(FileConfigXml)
                ser.Serialize(fs, Dati)
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

    End Sub

    Private Function LoadConfig() As AbilitazioneAgenzia.DatiLicenza
        If File.Exists(FileConfigXml) Then

            Dim ser As New XmlSerializer(GetType(AbilitazioneAgenzia.DatiLicenza))
            Using fs As New StreamReader(FileConfigXml)
                Return ser.Deserialize(fs)
            End Using
        Else
            Dim dl As AbilitazioneAgenzia.DatiLicenza
            dl.PingLicenza = ""
            dl.ScadenzaLicenza = ""
            dl.Scadenza = #1/1/2000#
            SalvaConfig(dl)
            Return dl
        End If

    End Function

    Private Function FileConfigXml() As String
        Return Path.Combine(Utx.Globale.Paths.CartellaSettingRete, "Assegni.xml")
    End Function

    Private Sub VisualizzaEtichettaDemo(ByVal Testo As String)
        'rimuovo il bottone licenza
        Me.Controls.Remove(btnLicenza)

        'etichetta demo
        With LabelLicenza
            .BorderStyle = BorderStyle.FixedSingle
            .Dock = DockStyle.Fill
            .Text = Testo
            .TextAlign = ContentAlignment.MiddleCenter
            .BackColor = Color.Coral
            .Refresh()
        End With

    End Sub

    Private Sub VisualizzaEtichettaLicenza(ByVal Scadenza As Date)
        With LabelLicenza
            .BorderStyle = BorderStyle.FixedSingle
            .Dock = DockStyle.Fill
            .Text = String.Format("Scadenza licenza {0:d}", Scadenza)
            .TextAlign = ContentAlignment.MiddleCenter

            If Scadenza > Today Then
                .BackColor = Color.PaleGreen
            Else
                .BackColor = Color.Coral
            End If

            .Refresh()
        End With

    End Sub

    Private Sub dgvRicerca_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvRicerca.ColumnHeaderMouseClick
        Try
            'cartella per salvataggio filtro
            FormFiltro.AppName = "ASSEGNI"
            FormFiltro.FilterFolder = Utx.Globale.Paths.CartellaSettingRete

            'visualizzo la finestra del filtro
            FormFiltro.Visualizza(dgvRicerca.Columns(e.ColumnIndex))

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

    End Sub

    Private Sub ButtonIndice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonIndice.Click
        wbDocumentazione.Navigate(LinkDoc)
    End Sub

    Private Sub TabPageDoc_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPageDoc.Enter
        Cursor.Current = Cursors.WaitCursor
        If wbDocumentazione.Url = Nothing Then wbDocumentazione.Navigate(LinkDoc)
    End Sub

    Private Sub wbDocumentazione_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles wbDocumentazione.DocumentCompleted
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub LabelUtente_TextChanged(sender As Object, e As EventArgs) Handles LabelUtente.TextChanged
        LabelUtente.Refresh()
    End Sub

    Private Sub ButtonCambiaUtente_Click(sender As Object, e As EventArgs) Handles ButtonCambiaUtente.Click
        Utx.Globale.UtenteCorrente.UniageUser = ""
        Utx.Globale.UtenteCorrente.UniagePw = ""

        'qui viene richiesto il nuvo utente
        LetturaIncassi()
    End Sub

    Private Sub TextBoxAgenzia_MouseUp(sender As Object, e As MouseEventArgs) Handles TextBoxAgenzia.MouseUp
        TextBoxAgenzia.SelectAll()
    End Sub

    Private Sub TextBoxAgenzia_Validated(sender As Object, e As EventArgs) Handles TextBoxAgenzia.Validated
        If (IsNumeric(TextBoxAgenzia.Text) = True) AndAlso (TextBoxAgenzia.Text > 0) Then
            TextBoxAgenzia.Text = TextBoxAgenzia.Text.PadLeft(5, "0")
            Globale.AgenziaRichiesta = TextBoxAgenzia.Text
        Else
            TextBoxAgenzia.Text = Globale.AgenziaRichiesta
        End If
    End Sub

    Private Sub TextBoxSub_MouseUp(sender As Object, e As MouseEventArgs) Handles TextBoxSub.MouseUp
        TextBoxSub.SelectAll()
    End Sub

    Private Sub TextBoxSub_Validated(sender As Object, e As EventArgs) Handles TextBoxSub.Validated
        If Val(TextBoxSub.Text) > 0 Then
            TextBoxSub.Text = Microsoft.VisualBasic.Left(TextBoxSub.Text, 3).Trim.PadLeft(3, "0")
        Else
            TextBoxSub.Text = ""
        End If
    End Sub

    Private Sub btnSalva_EnabledChanged(sender As Object, e As EventArgs)
        btnAnnulla.Enabled = btnSalva.Enabled
    End Sub

    Private Sub btnAnnulla_Click(sender As Object, e As EventArgs) Handles btnAnnulla.Click
        If MsgBox("Annullare l'operazione corrente?",
                  MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Globale.TitoloApp) = MsgBoxResult.Yes Then

            'carico il logo
            CaricaLogo(pbAnteprima)
            'cancello il file
            File.Delete(Titolo.FullPathAssegno)
            'svuoto la codeline e le note
            txtNote.Text = ""
            txtCodeLine.Text = ""
            txtCodeLine.BackColor = Color.Gainsboro

            btnSalva.Enabled = False
            btnAcquisisci.Enabled = True
            ListViewIncassi.Enabled = True
        End If
    End Sub

    Private Sub ButtonStampaAssegni_Click(sender As Object, e As EventArgs) Handles ButtonStampaAssegni.Click
        StampaAssegni()
    End Sub

    Private Sub StampaAssegni()
        Dim Giorno As Date = dtpDataIncasso.Value
        Dim Stampa As New Utx.PaginaHtml("Assegni.html", "C:\ApplicazioniDirezione\Unitools\Temp")

        Stampa.Titolo = "Assegni"
        Stampa.Size = Utx.PaginaHtml.TextSize.large
        Stampa.AddRow(String.Format("Assegni del {0:d}", Giorno), Grassetto:=True)
        Stampa.AddLine()
        Stampa.AddHtml("<div style=""font-family:Calibri""><table>")

        Dim CartellaAssegni As String = Deposito.CartellaAssegni(Giorno)

        Using c As New OleDbConnection(Globale.CnString)
            c.Open()

            Using cmd As New OleDb.OleDbCommand
                cmd.Connection = c
                cmd.CommandType = CommandType.Text
                cmd.CommandText = String.Format("SELECT DISTINCT IdAssegno FROM Assegni WHERE DataFoglioCassa = #{0}#", Format(Giorno, "MM/dd/yyyy"))

                Dim dr As OleDb.OleDbDataReader = cmd.ExecuteReader

                If dr.HasRows Then
                    Do While dr.Read
                        Dim Pagamento As String = Utx.FunzioniDb.ExecuteScalar(c, String.Format("SELECT TOP 1 Str(Ramo) + '/' + Str(Polizza) + ' di ' + Contraente FROM Assegni WHERE IdAssegno = '{0}'", dr("IdAssegno")))
                        Dim Immagine As String = String.Format("{0}\{1}.jpg", CartellaAssegni, dr("IdAssegno"))

                        If File.Exists(Immagine) Then
                            Stampa.AddHtml(String.Format("<tr><td style=""text-align: left""><img alt=""Codeline: {0}"" src=""file://{1}"" width=60%/></td></tr>",
                                                         dr("IdAssegno"), Immagine))
                        Else
                            Stampa.AddHtml(String.Format("<tr><td style=""text-align: left""><p>IMMAGINE ASSEGNO NON TROVATA ({0})</p></td></tr>", Immagine))
                        End If
                        'info assegno
                        Stampa.AddHtml(String.Format("<tr><td style=""text-align: left""><p>>> Assegno {0} - Pagamento: {1}</p></td></tr>",
                                                     dr("IdAssegno"), Pagamento))
                    Loop
                End If
            End Using
        End Using

        Stampa.AddHtml("</table></div>")
        Stampa.CreaFileHtml()

        Using Anteprima As New UtControls.FormAnteprima
            Anteprima.ControlloBottoni(Converti:=False, Email:=False)
            Anteprima.NomeFile = Stampa.NomeFile
            Anteprima.ShowDialog()
            'cancello il file di anteprima
            File.Delete(Anteprima.NomeFile)
        End Using
    End Sub
End Class