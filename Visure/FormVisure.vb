Imports System.Net
Imports System.IO

Public Class FormVisure
    Private Const TargaTest As String = "AC194SY" 'Massimo Patrizio
    Private ReadOnly Log As New Utx.ApplicationLog("Visure.log")

    Private ReadOnly VisureWeb As New Utx.ServiziUniarea.accessoCasa
    Private WithEvents TextBoxTarga As New TextBox
    Private WithEvents ComboBoxTipoVeicolo As New ComboBox
    Private WithEvents ButtonEseguiVisura As New Button
    Private WithEvents ButtonDettaglio As New Button
    Private WithEvents ButtonTotali As New Button
    Private WithEvents dtpInizio As New DateTimePicker
    Private WithEvents dtpFine As New DateTimePicker
    Private Listino As Integer = 0

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        If Utx.Globale.IdAppOk = False Then
            Application.Exit()
        End If

        Me.StartPosition = FormStartPosition.CenterScreen
        Me.WindowState = FormWindowState.Normal
        Me.ShowInTaskbar = True
        Me.Font = Utx.AppFont.Normal
        Me.Icon = Risorse.Immagini.Icon("anteprima")
        Me.Padding = New Padding(5)

        Select Case Utx.Globale.ProfiloEnteGestore.ProfiloApp
            Case Utx.Enumerazioni.ProfiloApp.COMPLETO
                Me.Text = "OmniaManager - Visure Aci/Pra"
            Case Utx.Enumerazioni.ProfiloApp.SINISTRI
                Me.Text = "UniSinistri - Visure Aci/Pra"
        End Select
    End Sub

    Public Property Targa() As String
        Get
            Return TextBoxTarga.Text.Replace(Space(1), Space(0)).Trim.ToUpper
        End Get
        Set(value As String)
            TextBoxTarga.Text = value
        End Set
    End Property

    Private mClasseVeicolo As String
    Public Property ClasseVeicolo() As String
        Get
            Return mClasseVeicolo
        End Get
        Set(value As String)
            mClasseVeicolo = value
        End Set
    End Property

    Private mPathDocumenti As String
    Public Property PathDocumenti() As String
        Get
            Return mPathDocumenti
        End Get
        Set(value As String)
            mPathDocumenti = value
        End Set
    End Property

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        TabControlMain.SelectedTab = Condizioni 'parte sempre visualizzando le condizioni
        TabControlMain.Dock = DockStyle.Fill
        Utx.NetFunc.DoppioBuffer(dgvStat)

        TabControlMain.ColorStyle = Utx.UtTabControl.TabColorStyle.CONTROL
        Me.Padding = New Padding(0, 5, 0, 5)
        Me.BackColor = Color.Orange
        Me.Refresh()

        StatusStrip1.SizingGrip = False
        StatusStrip1.BackColor = SystemColors.Control 'altrimenti prende orange

        lbStato.Text = ""
        ImpostaToolStripVisura()
        ImpostaToolStripStat()

        'servizio uniarea
        VisureWeb.Proxy = Utx.Globale.UniProxy.Proxy

        'aggancia gli eventi
        AddHandler ButtonEseguiVisura.Click, AddressOf ButtonEseguiVisura_Click
        AddHandler ComboBoxTipoVeicolo.SelectedIndexChanged, AddressOf MessaggioRimorchi
        AddHandler ButtonDettaglio.Click, AddressOf ButtonDettaglio_Click
        AddHandler ButtonTotali.Click, AddressOf ButtonTotali_Click

#If DEBUG Then
        TextBoxTarga.Text = TargaTest
        ComboBoxTipoVeicolo.SelectedIndex = 1
#End If
    End Sub

    Private Sub Form1_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        'controllo abilitazione agenzia con messaggio
        AbilitazioneAgenzia()

        ButtonEseguiVisura.Enabled = (Listino > 0)

        Dim MyUri As New Uri("https://utools.auaonline.it/Condizioni_e_costi_visure_Aci_Pra.html") 'informazioni, norme e costi
        WebViewCosti.Source = MyUri
    End Sub

    Private Sub ImpostaToolStripVisura()

        On Error Resume Next

        With ToolStripVisura
            .Dock = DockStyle.Top
            .Font = Utx.AppFont.Normal
            .GripStyle = ToolStripGripStyle.Hidden
            .RenderMode = ToolStripRenderMode.ManagerRenderMode
            .Items.Clear()
        End With

        Dim ttch As ToolStripControlHost

        ToolStripVisura.Items.Add(New ToolStripLabel(" Targa:"))
        With TextBoxTarga
            .BorderStyle = BorderStyle.FixedSingle
            .Width = 120
            .TextAlign = HorizontalAlignment.Center
            .BackColor = Color.Yellow
        End With
        ttch = New ToolStripControlHost(TextBoxTarga) With {.AutoSize = False}
        ToolStripVisura.Items.Add(ttch)

        ToolStripVisura.Items.Add(New ToolStripLabel(" Tipo veicolo:"))
        With ComboBoxTipoVeicolo
            .FlatStyle = FlatStyle.Flat
            .BackColor = Color.Yellow
            .AutoSize = False
            .Width = 120
            .DropDownStyle = ComboBoxStyle.DropDownList

            .Items.Add("seleziona...")
            .Items.Add("Autoveicoli") 'codice 1
            .Items.Add("Motoveicoli") 'codice 4
            .Items.Add("Rimorchi") 'codice 2

            ttch = New ToolStripControlHost(ComboBoxTipoVeicolo)
            ToolStripVisura.Items.Add(ttch)

            .SelectedIndex = TipoVeicolo() 'recupera il tipo veicolo dalla classe
        End With

        ToolStripVisura.Items.Add(New ToolStripLabel(Space(1)))
        With ButtonEseguiVisura
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Gray
            .Text = "Esegui visura"
            .Width = 120
            '.BackColor = Color.PaleGreen
            .Enabled = False
        End With
        ttch = New ToolStripControlHost(ButtonEseguiVisura) With {.AutoSize = False}
        ToolStripVisura.Items.Add(ttch)
    End Sub

    Private Sub ImpostaToolStripStat()
        On Error Resume Next

        With ToolStripStat
            .Dock = DockStyle.Top
            .Font = Utx.AppFont.Normal
            .GripStyle = ToolStripGripStyle.Hidden
            .RenderMode = ToolStripRenderMode.ManagerRenderMode
            .Items.Clear()
        End With

        Dim ttch As ToolStripControlHost

        ToolStripStat.Items.Add(New ToolStripLabel(" Dal:"))
        With dtpInizio
            .Format = DateTimePickerFormat.Short
            .Width = 100
            .Value = Utx.FunzioniData.InizioMese(Today)
        End With
        ttch = New ToolStripControlHost(dtpInizio)
        ToolStripStat.Items.Add(ttch)

        ToolStripStat.Items.Add(New ToolStripLabel(" al:"))
        With dtpFine
            .Format = DateTimePickerFormat.Short
            .Width = 100
            .Value = Utx.FunzioniData.FineMese(Today)
        End With
        ttch = New ToolStripControlHost(dtpFine)
        ToolStripStat.Items.Add(ttch)

        ToolStripStat.Items.Add(New ToolStripLabel(Space(1)))
        With ButtonDettaglio
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Gray
            .Text = "Elenco visure"
            .Width = 120
        End With
        ttch = New ToolStripControlHost(ButtonDettaglio) With {.AutoSize = False}
        ToolStripStat.Items.Add(ttch)

        With ButtonTotali
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Gray
            .Text = "Totali"
            .Width = 120
        End With

        ttch = New ToolStripControlHost(ButtonTotali) With {.AutoSize = False}
        ToolStripStat.Items.Add(ttch)
    End Sub

    Private Sub ButtonEseguiVisura_Click(sender As System.Object, e As System.EventArgs)

        If Me.Targa.Length = 0 Then
            MsgBox("Inserire la targa.", MsgBoxStyle.Exclamation, "Visure")
            TextBoxTarga.Focus()
            Exit Sub
        End If
        If ComboBoxTipoVeicolo.SelectedIndex = 0 Then
            MsgBox("Selezionare il tipo di veicolo.", MsgBoxStyle.Exclamation, "Visure")
            ComboBoxTipoVeicolo.Focus()
            Exit Sub
        End If

        'controllo la raggiungibilità del servizio di registrazione uniarea
        Cursor.Current = Cursors.WaitCursor
        If AbilitazioneAgenzia() = False Then Exit Sub
        Cursor.Current = Cursors.Default

        Dim PdfFullPath As String

        Try
            If mPathDocumenti = String.Empty Then
                Log.Info("Richiesta nome file per il salvataggio")
                'seleziono il nome file
                PdfFullPath = Path.Combine(Utx.Globale.UtenteCorrente.Desktop, "Visura " + Me.Targa + ".pdf")

                Dim cd As New SaveFileDialog
                With cd
                    .AddExtension = True
                    .DefaultExt = "pdf"
                    .OverwritePrompt = False
                    .Filter = "*.pdf|*.pdf"
                    .FileName = PdfFullPath

                    If .ShowDialog(Me) = DialogResult.Cancel Then Exit Sub

                    PdfFullPath = .FileName
                End With
            Else
                PdfFullPath = Path.Combine(mPathDocumenti, "Visura " + Me.Targa + ".pdf")
            End If

            ButtonEseguiVisura.Enabled = False
            TextBoxTarga.ReadOnly = True
            ComboBoxTipoVeicolo.Enabled = False

            'controllo esistenza file
            If File.Exists(PdfFullPath) Then
                If MsgBox("Esiste già nella cartella un file visura relativo a questa targa." + Environment.NewLine +
                          "Continuare?", MsgBoxStyle.YesNo +
                                         MsgBoxStyle.Exclamation +
                                         MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then

                    ButtonEseguiVisura.Enabled = True
                    Exit Sub
                End If
            End If

        Catch ex As Exception
            Log.Errore(ex)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Visure")
            Exit Sub
        End Try

        Log.Info("Richiesta in esecuzione...")
        lbStato.Text = "Richiesta in esecuzione..."
        StatusStrip1.Refresh()
        Cursor.Current = Cursors.WaitCursor

        Try
            Dim Risposta As VisureOMW.Visura
            'chiamo il servizio e ottengo la visura
            Using s As New VisureOMW.Visure
                s.Proxy = Utx.Globale.UniProxy.Proxy
                Risposta = s.VisuraPra(Utx.Globale.ProfiloEnteGestore.AgenziaMadre,
                                       Utx.Globale.UtenteCorrente.UniageUser,
                                       Me.Targa,
                                       CodiceSerieTarga,
                                       Utx.Globale.Token)
            End Using

            Log.Info("Codice esito {0}", {Risposta.CodiceEsito})

            Select Case Risposta.CodiceEsito
                Case 0 'tutto ok
                    'salvo il pdf e lo visualizzo
                    File.WriteAllBytes(PdfFullPath, Risposta.VisuraRichiesta)
                    wbVisura.Navigate(PdfFullPath)
                    lbStato.Text = ""
                Case 1 'non presente al PRA
                    lbStato.Text = ""
                    MsgBox("Nessun dato recuperato. Targa non presente al nuovo PRA", MsgBoxStyle.Exclamation, "Visure PRA")
                    ButtonEseguiVisura.Enabled = True
                Case 3 'non ha validà giuridica
                    lbStato.Text = ""
                    MsgBox("Il dato non ha validità giuridica.", MsgBoxStyle.Exclamation, "Visure PRA")
                    ButtonEseguiVisura.Enabled = True
                Case 4 'errori formali - non si paga
                    lbStato.Text = ""
                    MsgBox("Errore nei dati della richiesta.", MsgBoxStyle.Exclamation, "Visure PRA")
                    ButtonEseguiVisura.Enabled = True
            End Select
            StatusStrip1.Refresh()

            'registra la visura sul server AUA
            If Risposta.CodiceEsito < 4 AndAlso Me.Targa <> TargaTest Then
                Try
                    Log.Info(String.Format("Compagnia {0} Agenzia {1} Utente {2} Targa {3} Tipo veicolo {4} Esito {5}",
                                           Utx.Globale.ProfiloEnteGestore.Compagnia,
                                           Utx.Globale.ProfiloEnteGestore.AgenziaMadre,
                                           Utx.Globale.UtenteCorrente.UniageUser,
                                           Me.Targa,
                                           CodiceSerieTarga,
                                           Risposta.CodiceEsito))

                    Dim RispostaServizio As String = VisureWeb.RegistraVisuraW("",
                                                                               Utx.Globale.ProfiloEnteGestore.Compagnia,
                                                                               Utx.Globale.ProfiloEnteGestore.AgenziaMadre,
                                                                               Utx.Globale.UtenteCorrente.UniageUser,
                                                                               Me.Targa,
                                                                               CodiceSerieTarga,
                                                                               Risposta.CodiceEsito,
                                                                               Utx.NetFunc.TokenAccessoCasa)

                    If RispostaServizio.Contains("-ERR") Then
                        MsgBox(RispostaServizio, MsgBoxStyle.Exclamation, "Visure PRA")
                        InviaLog(RispostaServizio, "Guarda risposta servizio", Risposta.CodiceEsito)
                    Else
                        'tutto ok - per controllo poi eliminare
                        InviaLog(RispostaServizio, "", Risposta.CodiceEsito)
                    End If

                Catch ex As Exception
                    InviaLog("", ex.Message, Risposta.CodiceEsito)
                    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Visure")
                End Try
            End If
            'fine registrazione---------------------------------------- 

            TextBoxTarga.ReadOnly = False
            ComboBoxTipoVeicolo.Enabled = True

        Catch ex As Exception
            lbStato.Text = "Si è verificato un errore."
            InviaLog("", ex.Message, -1)
            Log.Errore(ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function TipoVeicolo() As Integer
        Select Case Val(mClasseVeicolo)
            Case 1 To 9, 52, 60, 70 'autoveicoli
                TipoVeicolo = 1
            Case 30 To 32, 34 To 36, 38 'motoveicoli
                TipoVeicolo = 2
            Case 40, 41, 43, 44, 76 'rimorchi
                TipoVeicolo = 3
            Case Else
                TipoVeicolo = 0
        End Select
    End Function

    Private Function CodiceSerieTarga() As Integer
        'i codici aci-----------
        '1 – Autoveicolo
        '2 – Rimorchio
        '4 – Motoveicolo
        '-----------------------
        Select Case ComboBoxTipoVeicolo.SelectedIndex
            Case 1 : Return 1 'autoveicoli
            Case 2 : Return 4 'motoveicoli
            Case 3 : Return 2 'rimorchi
        End Select
    End Function

    Private Sub ButtonDettaglio_Click(sender As System.Object, e As System.EventArgs)
        Try
            Cursor.Current = Cursors.WaitCursor

            dgvStat.DataSource = Nothing
            dgvStat.Refresh()
            dgvStat.DataSource = VisureWeb.ElencoVisureW(Utx.Globale.ProfiloEnteGestore.Compagnia,
                                                         Utx.Globale.AgenziaRichiesta.CodiceAgenzia,
                                                         dtpInizio.Value,
                                                         dtpFine.Value,
                                                         Utx.NetFunc.TokenAccessoCasa).Tables(0)

            FormattaDettaglio()

        Catch ex As Exception
            Log.Errore(ex)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Visure")
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ButtonTotali_Click(sender As System.Object, e As System.EventArgs)
        Try
            Cursor.Current = Cursors.WaitCursor

            dgvStat.DataSource = Nothing
            dgvStat.Refresh()
            dgvStat.DataSource = VisureWeb.ReportTotaliW(Utx.Globale.ProfiloEnteGestore.Compagnia,
                                                         Utx.Globale.AgenziaRichiesta.CodiceAgenzia,
                                                         dtpInizio.Value,
                                                         dtpFine.Value,
                                                         Utx.NetFunc.TokenAccessoCasa).Tables(0)

            FormattaTotali()

        Catch ex As Exception
            Log.Errore(ex)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Visure")
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub FormattaDettaglio()
        On Error Resume Next

        With dgvStat
            .Font = Utx.AppFont.Normal
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .CellBorderStyle = DataGridViewCellBorderStyle.Raised
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("TipoVeicolo").HeaderText = "Tipo veicolo"
            .Columns("Targa").DefaultCellStyle.BackColor = Color.Moccasin

            .AutoResizeColumns()
        End With
    End Sub

    Private Sub FormattaTotali()
        On Error Resume Next

        With dgvStat
            .Font = Utx.AppFont.Normal
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .CellBorderStyle = DataGridViewCellBorderStyle.Raised
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("conta").HeaderText = "Esito"

            .AutoResizeColumns()
        End With
    End Sub

    Private Function AbilitazioneAgenzia() As Boolean
        Try
            Dim RispostaServizio As String = VisureWeb.checkVisureW(Utx.Globale.AgenziaRichiesta.CodiceAgenzia,
                                                                    Utx.Globale.ProfiloEnteGestore.Compagnia,
                                                                    Utx.NetFunc.TokenAccessoCasa)

            'il codice listino viene impostato a 0 se l'agenzia non è abilitata
            Listino = 0

            Select Case RispostaServizio
                Case "0", "-1"
                    MsgBox(String.Format("Agenzia non ancora abilitata al servizio visure.{0}" +
                                         "Per abilitare il servizio contattare AUA."), MsgBoxStyle.Information)
                    Return False

                Case Is > 0 'listini (abilitata)
                    Listino = RispostaServizio
                    Return True

                Case ""
                    'visualizzo un messaggio
                    Dim Messaggio As New System.Text.StringBuilder
                    With Messaggio
                        .Append("Impossibile effettuare la connessione al server remoto.")
                        .AppendLine()
                        .Append("User e/o password del dominio uniage probabilmente errate e/o bloccate.")
                    End With

                    Log.Info(Messaggio.ToString)
                    MsgBox(Messaggio.ToString, MsgBoxStyle.Exclamation)

                    Return False

                Case Else
                    'scrivo la risposta del servizio nel log
                    Log.Info(RispostaServizio)
                    MsgBox(RispostaServizio, MsgBoxStyle.Exclamation)
                    Return False

            End Select

        Catch ex As Exception
            Log.Errore(ex)
            Return False
        End Try
    End Function

    Friend Sub InviaLog(Risposta As String, Errore As String, Esito As Integer)
        Try
            If Me.Targa = TargaTest Then
                Exit Sub
            End If

            Dim Oggetto As String = String.Format("Visure PRA (Agenzia {0} - Targa {1} - Esito {2})",
                                                  Utx.Globale.AgenziaRichiesta.CodiceAgenzia,
                                                  Me.Targa,
                                                  Esito)

            If Errore.Trim.Length > 0 Then Oggetto += " Errore"

            'crea il testo della mail di notifica
            Dim Testo As String = String.Format("Agenzia: {1} - {2}{0}" +
                                                "Ambiente: {3}{0}" +
                                                "Pc: {4}{0}" +
                                                "Utente ACI: AGE{5}{0}" +
                                                "Utente: {6}{0}" +
                                                "Targa: {7}{0}" +
                                                "Tipo veicolo: {8}{0}" +
                                                "Risposta server: {9}{0}" +
                                                "Errore: {10}{0}" +
                                                "Esito: {11} ({12}){0}" +
                                                "Versione Visure: {13}",
                                                Environment.NewLine,
                                                Utx.Globale.ProfiloEnteGestore.AgenziaMadre,
                                                Utx.Globale.ProfiloEnteGestore.Localita,
                                                Utx.Setting.Ambiente,
                                                Environment.MachineName,
                                                Utx.Globale.ProfiloEnteGestore.AgenziaMadre,
                                                Utx.Globale.UtenteCorrente.UniageUser,
                                                Me.Targa,
                                                CodiceSerieTarga,
                                                Risposta,
                                                Errore,
                                                Esito,
                                                DeskEsito(Esito),
                                                Utx.NetFunc.VersioneModulo("Visure.dll"))

            'invia la mail
            Dim Postino As New UniCom.Postino
            With Postino
                .Mittente = "unitools@unipol.it"
                .InviaA.Add("gestione@auaonline.it")
                .InviaCc.Add("guidolampo@tiscali.it")
                .Oggetto = Oggetto
                .Testo = Testo
                .InviaMail()
            End With

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub MessaggioRimorchi(sender As System.Object, e As System.EventArgs)
        If ComboBoxTipoVeicolo.SelectedIndex = 3 Then
            MsgBox("ATTENZIONE:" + vbNewLine +
                   "Ai sensi dell'art.10 della legge 8.7.2003, a partire dal 29.7.2003 sono iscritti nel Pubblico Registro Automobilistico" + vbNewLine +
                   "i soli rimorchi con massa uguale o superiore a 3,5 tonnellate." + vbNewLine +
                   "Le risultanze degli archivi centrali ACI sono conseguentemente coerenti con la disposizione di legge sopra richiamata",
                   MsgBoxStyle.Exclamation, "Visure rimorchi")
        End If
    End Sub

    Private Function DeskEsito(CodiceEsito As Integer) As String
        Select Case CodiceEsito
            Case 0 : Return "OK"
            Case 1 : Return "Nessun dato recuperato"
            Case 3 : Return "Il dato non ha validità giuridica"
            Case 4 : Return "Errore nei dati della richiesta"
            Case Else : Return "Codice non previsto"
        End Select
    End Function
End Class
