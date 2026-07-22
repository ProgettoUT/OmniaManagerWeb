Imports System.IO

Public Class FormMail

    Private WithEvents ChekBoxMittente As New CheckBox
    Private WithEvents FormDocumenti As UnitoolsDocumenti.FormDocumenti

    Private Sms As Sms
    Private Rubrica As DataTable
    Private ReadOnly mCartellaMail As String 'cartella della mail
    Private mCodiceFiscale As String 'codice piva fiscale del cliente
    Private mCartellaDocumenti As String 'cartella documenti selezionata
    Private mCartellaSms As String 'cartella predefinita sms
    Private mMittenti As String
    Private ReadOnly mOggetto As String
    Private ReadOnly mTesto As String

    Public Esito As New EsitoServizio
    Private ReadOnly TTip As New ToolTip
    Private ReadOnly ThRubrica As Threading.Thread

    Public Enum TipoMessaggio
        [NonImpostato] = -1
        [Email] = 0
        [Sms] = 1
        [Fax] = 2
    End Enum

    Public Enum TipoDestinatarioMail
        [A] = 0
        [Cc] = 1
        [Ccn] = 2
    End Enum

    Public Enum TipoDestinatarioSms
        [A] = 0
    End Enum

    Sub New()
        ' Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        'thread per leggere la rubrica
        ThRubrica = New Threading.Thread(Sub()
                                             If Rubrica IsNot Nothing Then Rubrica.Clear()
                                             Rubrica = Utx.WsCommand.ExecuteNonQuery("SELECT * FROM Rubrica").DataTable
                                         End Sub)
        ThRubrica.Start()

        Me.Text = "Composizione"
        Me.Icon = Risorse.Immagini.Icon("mail")

        If String.IsNullOrEmpty(Utx.Globale.UtenteCorrente.MittentiMail) Then
            MsgBox("E' opportuno inserire i mittenti da utilizzare per le e-mail utilizzando la sezione configurazione.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            Using f As New Utx.FormConfigura
                f.ShowDialog()
            End Using
        End If

        ImpostaControlli()

        mCartellaMail = UniCom.Postino.CartellaMail
        mBloccaInserimentoNota = False 'inserimento nota abilitato
        mMittenti = Utx.Globale.UtenteCorrente.MittentiMail
    End Sub

    Private Sub ImpostaControlli()
        With TextBoxNomeMittente
            .BackColor = Color.LightYellow
            .TextAlign = HorizontalAlignment.Center
        End With

        tsMenu.SuspendLayout()

        Dim ttch As ToolStripControlHost

        rbMail.Checked = False
        rbSms.Checked = False

        'separatore e checkbox
        tsMenu.Items.Add(New ToolStripSeparator)
        With ChekBoxMittente
            .Padding = New Padding(5, 0, 0, 0)
            .AutoSize = True
            .BackColor = Color.Transparent
            .Text = "Invia al mittente (Ccn)"
            .Checked = False
        End With
        ttch = New ToolStripControlHost(ChekBoxMittente)
        tsMenu.Items.Add(ttch)
        tsMenu.Items.Add(New ToolStripSeparator)

        With tsbEsci
            .Text = ""
            .Image = Risorse.Immagini.Bitmap("esci")
            .Alignment = ToolStripItemAlignment.Right
        End With
        tsbSalva.Image = Risorse.Immagini.Bitmap("salva")
        tsbInvia.Image = Risorse.Immagini.Bitmap("at")
        tsbRubrica.Image = Risorse.Immagini.Bitmap("rubrica")
        tsbFirma.Image = Risorse.Immagini.Bitmap("firma")

        With btnAggiungi
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Image = Risorse.Immagini.Bitmap("piu")
            .ImageAlign = ContentAlignment.MiddleCenter
            .Text = ""
        End With
        TTip.SetToolTip(btnAggiungi, "Aggiungi destinatario")
        With btnCancella
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Image = Risorse.Immagini.Bitmap("meno")
            .ImageAlign = ContentAlignment.MiddleCenter
            .Text = ""
        End With
        TTip.SetToolTip(btnCancella, "Cancella destinatario selezionato")
        With btnCancellaLista
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Image = Risorse.Immagini.Bitmap("cancel")
            .ImageAlign = ContentAlignment.MiddleCenter
            .Text = ""
        End With
        TTip.SetToolTip(btnCancellaLista, "Cancella lista destinatari")

        lbDimensioneAllegati.TextAlign = ContentAlignment.MiddleCenter

        ListAllegati.AllowDrop = True
        ListAllegati.DisplayMember = "Name"

        With lvDestinatari
            .View = View.Details
            .FullRowSelect = True
            .MultiSelect = False
            .GridLines = True
            .ForeColor = Color.Gray

            .Columns.Add("Tipo", 50, HorizontalAlignment.Right)
            .Columns.Add("Destinatario", 300, HorizontalAlignment.Left)
            .Columns.Add("Nome", .Width - 375, HorizontalAlignment.Left)
        End With

        tsbAggiungiDocumento.Enabled = False

        TTip.SetToolTip(txtCarUtilizzati, "Caratteri utilizzati")
        TTip.SetToolTip(txtCarDisponibili, "Caratteri disponibili")
        TTip.SetToolTip(txtNumeroSms, "Numero sms")

        'status strip
        StatusStrip1.GripStyle = ToolStripGripStyle.Hidden
        lbStato.Text = ""
        pbInvio.Visible = False

        tsMenu.ResumeLayout()
    End Sub

    'Public ReadOnly Property Smtp() As String
    '    Get
    '        Return Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.SMTP, "")
    '    End Get
    'End Property

    Public Property Messaggio() As TipoMessaggio
        Get
            If rbMail.Checked Then
                Return TipoMessaggio.Email
            ElseIf rbSms.Checked Then
                Return TipoMessaggio.Sms
            Else
                Return TipoMessaggio.NonImpostato
            End If
        End Get
        Set(Messaggio As TipoMessaggio)
            Select Case Messaggio
                Case TipoMessaggio.Email
                    rbMail.Checked = True
                Case TipoMessaggio.Sms
                    rbSms.Checked = True
            End Select
        End Set
    End Property

    Public WriteOnly Property Mittenti() As String
        Set(Email As String)
            If String.IsNullOrEmpty(Email) = False Then
                mMittenti = Email
                'aggiungo i mittenti al combo
                AddMittente(mMittenti)
            End If
        End Set
    End Property

    Public ReadOnly Property Mittente() As String
        Get
            Return cboMittente.Text
        End Get
    End Property

    Public Property CodiceFiscale() As String
        Get
            Return mCodiceFiscale
        End Get
        Set(CodiceFiscale As String)
            mCodiceFiscale = CodiceFiscale
            tsbAggiungiDocumento.Enabled = Not String.IsNullOrEmpty(mCodiceFiscale)
        End Set
    End Property

    Public Property CartellaDocumenti() As String
        Get
            Return mCartellaDocumenti
        End Get
        Set(CartellaDocumenti As String)
            mCartellaDocumenti = CartellaDocumenti
        End Set
    End Property

    Public Property CartellaSms() As String
        Get
            If String.IsNullOrEmpty(mCartellaSms) Then
                Return Utx.Globale.Paths.CartellaSms
            Else
                Return mCartellaSms
            End If
        End Get
        Set(CartellaSms As String)
            mCartellaSms = CartellaSms
            CaricaSmsPredefiniti()
        End Set
    End Property

    Public Property Oggetto() As String
        Get
            Return txtOggetto.Text
        End Get
        Set(OggettoMail As String)
            txtOggetto.Text = OggettoMail
        End Set
    End Property

    Public Property Testo() As String
        Get
            Return txtTesto.Text
        End Get
        Set(TestoMail As String)
            txtTesto.Text = TestoMail
        End Set
    End Property

    Private mIdPratica As String
    Public Property IdPratica() As String
        Get
            Return mIdPratica
        End Get
        Set(value As String)
            mIdPratica = value
        End Set
    End Property

    Private mNomeCliente As String
    Public Property NomeCliente() As String
        Get
            Return mNomeCliente
        End Get
        Set(value As String)
            mNomeCliente = value
        End Set
    End Property

    Private mBloccaInserimentoNota As Boolean
    Public Property BloccaInserimentoNota() As Boolean
        Get
            Return mBloccaInserimentoNota
        End Get
        Set(value As Boolean)
            mBloccaInserimentoNota = value
        End Set
    End Property

    Private mInserimentoNota As Date
    Public Property InserimentoNota() As Date
        Get
            Return mInserimentoNota
        End Get
        Set(value As Date)
            mInserimentoNota = value
        End Set
    End Property

    Public ReadOnly Property FileFirma() As String
        Get
            If rbMail.Checked = True Then
                Return Path.Combine(Utx.Globale.Paths.CartellaSettingRete, String.Format("Firma.{0}.txt", Utx.Globale.UtenteCorrente.UniageUser))
            Else
                Return Path.Combine(Utx.Globale.Paths.CartellaSettingRete, String.Format("FirmaSms.{0}.txt", Utx.Globale.UtenteCorrente.UniageUser))
            End If
        End Get
    End Property

    Public ReadOnly Property PesoAllegati() As Double
        Get
            Dim Peso As Double
            For Each i As FileInfo In New DirectoryInfo(mCartellaMail).GetFiles
                Peso += i.Length
            Next
            Return Peso
        End Get
    End Property

    Public Sub SShowDialog()
        Me.ShowDialog()
    End Sub

    Private Sub AddMittente(Email As String)

        cboMittente.Items.Clear()

        'più e-mail separate dal ;
        For Each indirizzo As String In Email.Split(";")
            If Utx.NetFunc.ValidEmail(indirizzo, False, True) Then
                cboMittente.Items.Add(indirizzo)
            End If
        Next
        cboMittente.SelectedIndex = 0
    End Sub

    Public Sub AddDestinatarioEmail(TipoDestinatario As TipoDestinatarioMail,
                                    Email As String)

        Try
            If rbMail.Checked = True Then

                If Not String.IsNullOrEmpty(Email) Then

                    Email = Email.Trim

                    If Utx.NetFunc.ValidEmail(Email, False, True) Then

                        If EsisteDestinatario(Email) Then
                            MsgBox("Destinatario già nella lista", MsgBoxStyle.Information)
                        Else
                            With lvDestinatari.Items.Add(TipoDestinatario.ToString)
                                .Checked = True
                                .SubItems.Add(Email)
                            End With
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub AddDestinatarioSms(Telefono As String)

        Telefono = Utx.FunzioniFormato.NormalizzaCellulare(Telefono)

        If Telefono.Length > 0 Then

            If EsisteDestinatario(Telefono) Then
                MsgBox("Destinatario già nella lista", MsgBoxStyle.Information)
            Else
                With lvDestinatari.Items.Add("A")
                    .Checked = True
                    .SubItems.Add(Telefono)
                    .SubItems.Add("")
                End With
            End If
        End If
    End Sub

    Private Function EsisteDestinatario(Email As String) As Boolean

        Try
            If lvDestinatari.Items.Count = 0 Then
                Return False
            Else
                For Each i As ListViewItem In lvDestinatari.Items
                    If i.SubItems(1).Text = Email Then
                        Return True
                    End If
                Next
            End If

            Return False

        Catch ex As Exception
            Globale.Log.Errore(ex)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try

    End Function

    Private Function EsisteTelefono(Telefono As String) As Boolean

        Try
            If lvDestinatari.Items.Count = 0 Then
                Return False
            Else
                For Each i As ListViewItem In lvDestinatari.Items
                    If i.SubItems(1).Text = Telefono Then
                        Return True
                    End If
                Next
            End If

            Return False

        Catch ex As Exception
            Globale.Log.Errore(ex)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
            Return False
        End Try

    End Function

    Public Sub AddAllegato(PathAllegato As String)
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim OrigineAllegato As New FileInfo(PathAllegato)
            Dim DestAllegato As New FileInfo(Path.Combine(mCartellaMail, OrigineAllegato.Name))

            If File.Exists(DestAllegato.FullName) OrElse File.Exists(DestAllegato.FullName + ".zip") Then
                MsgBox("Allegato già inserito", MsgBoxStyle.Exclamation)
            Else
                File.Copy(OrigineAllegato.FullName, DestAllegato.FullName)
                ListAllegati.Items.Add(DestAllegato)
                ListAllegati.BackColor = Color.White
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            MsgBox(ex.Message)
        Finally
            lbDimensioneAllegati.Text = DimensioneAllegati()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub FormMail_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If Messaggio = TipoMessaggio.NonImpostato Then Messaggio = TipoMessaggio.Email
        lbDimensioneAllegati.Text = DimensioneAllegati()
    End Sub

    Private Sub InitComboDestinatari()
        Try
            cboDestinatario.DropDownStyle = ComboBoxStyle.Simple
            cboDestinatario.DataSource = Nothing
            cboDestinatario.AutoCompleteMode = AutoCompleteMode.None

            If rbSms.Checked = False Then
                ThRubrica.Join()

                With cboDestinatario
                    .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                    .DropDownStyle = ComboBoxStyle.DropDown
                    .AutoCompleteSource = AutoCompleteSource.ListItems

                    .DataSource = Rubrica
                    .DisplayMember = "Email" 'mette l'indice selezionato a 0 (primo elemento)

                    .Text = ""
                End With
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub FormMail_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        cboDestinatario.DropDownWidth = cboDestinatario.Width
    End Sub

    Private Sub frmMail_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        cboDestinatario.Focus()
    End Sub

    Private Sub btnAggiungi_Click(sender As System.Object, e As System.EventArgs) Handles btnAggiungi.Click
        If rbMail.Checked Then
            AddDestinatarioEmail(cboTipoDestinatario.SelectedIndex, cboDestinatario.Text)
            AggiornaComboDestinatario()
        ElseIf rbSms.Checked Then
            AddDestinatarioSms(cboDestinatario.Text)
            cboDestinatario.Text = ""
        End If
        cboDestinatario.Focus()
    End Sub

    Private Sub rbMail_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbMail.CheckedChanged
        If rbMail.Checked Then
            Sms = Nothing

            PanelTipoMessaggio.BackColor = Color.Coral
            PanelTipoMessaggio.Refresh()

            'invia al mittente per conoscenza
            ChekBoxMittente.Enabled = True
            'bottone salva
            tsbSalva.Text = "Salva e-mail"

            'sms
            cboSmsPredefiniti.Visible = False
            txtCarUtilizzati.Visible = False
            txtCarDisponibili.Visible = False
            txtNumeroSms.Visible = False

            'oggetto mail
            TextBoxNomeMittente.Text = Utx.Globale.UtenteCorrente.NomeUtente
            TableLayoutPanel1.SetColumnSpan(txtOggetto, 7)
            lbOggetto.Visible = True
            txtOggetto.Visible = True

            'rimuovo massima lunghezza del mittente
            cboMittente.MaxLength = 255

            'riempio combo mittenti
            If Not String.IsNullOrEmpty(mMittenti) Then AddMittente(mMittenti)

            'aggancio rubrica
            InitComboDestinatari()

            'allegati
            tsAllegati.Enabled = True

            'massima lunghezza del testo
            txtTesto.MaxLength = 32767

            'tipologia e lista destinatari
            With cboTipoDestinatario
                .Items.Clear()
                .Items.Add(TipoDestinatarioMail.A)
                .Items.Add(TipoDestinatarioMail.Cc)
                .Items.Add(TipoDestinatarioMail.Ccn)
                .SelectedIndex = 0
            End With

            lvDestinatari.Items.Clear()
            cboDestinatario.Focus()
        End If
    End Sub

    Private Sub AggiornaLabelCredito()
        Dim th As New Threading.Thread(Sub()
                                           rbSms.Text = String.Format("Invia un SMS (credito {0})", Sms.CreditoSubaccount)
                                       End Sub)
        th.Start()
    End Sub

    Private Sub rbSms_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbSms.CheckedChanged
        If rbSms.Checked Then
            Sms = New Sms
            AggiornaLabelCredito()

            PanelTipoMessaggio.BackColor = Color.YellowGreen
            PanelTipoMessaggio.Refresh()

            'invia al mittente per conoscenza
            ChekBoxMittente.Checked = False
            ChekBoxMittente.Enabled = False
            tsbSalva.Text = "Salva modello SMS"

            'oggetto mail
            TextBoxNomeMittente.Text = ""
            lbOggetto.Visible = False
            txtOggetto.Visible = False

            'sms
            TableLayoutPanel1.SetColumn(cboSmsPredefiniti, 0)
            TableLayoutPanel1.SetColumnSpan(cboSmsPredefiniti, 5)
            cboSmsPredefiniti.Visible = True
            txtCarUtilizzati.Visible = True
            txtCarDisponibili.Visible = True
            txtNumeroSms.Visible = True

            'mittente max 11 caratteri alfanumerico
            cboMittente.MaxLength = 20
            cboMittente.Items.Clear()
            cboMittente.Items.Add(Sms.AutoSender(""))
            cboMittente.SelectedIndex = 0

            'sgancio rubrica
            InitComboDestinatari()

            'testo
            txtCarDisponibili.Text = UniCom.MessaggioSms.MaxDimensioneSms - txtTesto.Text.Length

            'allegati
            tsAllegati.Enabled = False
            CancellaAllegati()

            'tipo di destinatario (solo A)
            With cboTipoDestinatario
                .Items.Clear()
                .Items.Add(TipoDestinatarioMail.A)
                .SelectedIndex = 0
            End With

            'sms predefiniti
            CaricaSmsPredefiniti()

            lvDestinatari.Items.Clear()

            ControlloNumeroCaratteri()

            cboDestinatario.Focus()
        End If
    End Sub

    Private Sub CaricaSmsPredefiniti()
        Try
            'sms predefiniti
            cboSmsPredefiniti.Items.Clear()
            cboSmsPredefiniti.Items.Add("Scegliere un sms predefinito")

            If Not String.IsNullOrEmpty(Me.CartellaSms) Then
                For Each fi As String In Directory.GetFiles(Me.CartellaSms, "*.msgsms")
                    cboSmsPredefiniti.Items.Add(Path.GetFileNameWithoutExtension(fi))
                Next
            End If

            cboSmsPredefiniti.SelectedIndex = 0

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub tsbInvia_Click(sender As System.Object, e As System.EventArgs) Handles tsbInvia.Click

        If ControlloPreInvio() = False Then
            Exit Sub
        End If

        lbStato.Text = "Invio in corso..."

        With pbInvio
            .Style = ProgressBarStyle.Marquee
            .Value = .Minimum
            .Enabled = True
            .Visible = True
        End With

        Me.Enabled = False

        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Function ControlloPreInvio() As Boolean

        If rbMail.Checked = True Then
            'si tratta di una email
            If TextBoxNomeMittente.Text.Trim.Length = 0 Then
                MsgBox("Nome del mittente obbligatorio.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Return False
            End If
            'senza oggetto
            If txtOggetto.Text.Trim.Length = 0 Then
                If MsgBox("E-mail senza oggetto. Inviare comunque?",
                          MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question,
                          Utx.Globale.TitoloApp) = MsgBoxResult.No Then
                    Return False
                End If
            End If
            'niente da inviare
            If txtTesto.Text.Trim.Length = 0 And lvDestinatari.Items.Count = 0 And ListAllegati.Items.Count = 0 Then
                MsgBox("Niente da inviare.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Return False
            End If
            ''troppi allegati
            'If ListAllegati.Items.Count > 5 Then
            '    MsgBox("E' possibile inviare al massimo 5 allegati. Suggerimento: comprimete più allegati in un unico file compresso (zip).", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            '    Return False
            'End If
            'indirizzo e-mail/telefono in sospeso
            If cboDestinatario.Text.Trim.Length > 0 Then

                If MsgBox(String.Format("Aggiungere {0} alla lista dei destinatari?", cboDestinatario.Text),
                          MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Invia e-mail") = MsgBoxResult.Yes Then

                    Dim arg As New EventArgs
                    btnAggiungi_Click(Me, arg)

                    AggiornaComboDestinatario()
                End If
            End If
            'invio al mittente come notifica
            If ChekBoxMittente.Checked = True Then
                AddDestinatarioEmail(TipoDestinatarioMail.Ccn, cboMittente.Text)
            End If
            Return True
        Else
            'sms
            'telefono in sospeso
            If cboDestinatario.Text.Trim.Length > 0 Then

                If MsgBox(String.Format("Aggiungere {0} alla lista dei destinatari?", cboDestinatario.Text),
                          MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Invia sms") = MsgBoxResult.Yes Then

                    Dim arg As New EventArgs
                    btnAggiungi_Click(Me, arg)

                    AggiornaComboDestinatario()
                End If
            End If

            Return True
        End If

    End Function

    Private Sub InviaMail()
        Dim Postino As New Postino
        Try
            With Postino
                .Mittente = cboMittente.Text
                .NomeMittente = TextBoxNomeMittente.Text
                .PesoAllegati = Me.PesoAllegati

                'pulisce la lista prima di riempirla: importante in caso di errori e modifiche alla lista
                .ResetDestinatari()

                'destinatari
                For Each i As ListViewItem In lvDestinatari.Items
                    Select Case i.SubItems(0).Text.ToUpper
                        Case "A"
                            .InviaA.Add(i.SubItems(1).Text)
                        Case "CC"
                            .InviaCc.Add(i.SubItems(1).Text)
                        Case "CCN"
                            .InviaCcn.Add(i.SubItems(1).Text)
                    End Select
                Next

                .Oggetto = txtOggetto.Text
                .Testo = txtTesto.Text

                'allegati
                .CartellaAllegati = mCartellaMail
                For Each fi As FileInfo In ListAllegati.Items
                    .AddAllegato(fi.FullName)
                Next
                .InviaMail()
            End With
        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Me.Esito = Postino.Esito
        End Try
    End Sub

    Private Sub InviaSms()
        Try
            If String.IsNullOrEmpty(txtTesto.Text.Trim) Then
                Esito.EsitoChiamata = False
                Esito.MessaggioErrore = "Nessun testo da inviare"
                Exit Sub
            End If

            Dim Credito As String = Sms.CreditoSubaccount()

            If lvDestinatari.Items.Count <= Credito Then
                '+credito ok
                With Sms
                    .Compagnia = Utx.Globale.ProfiloEnteGestore.Compagnia
                    .AutoSender(cboMittente.Text)
                    .Messaggio = New MessaggioSms(txtTesto.Text)
                End With

                For Each i As ListViewItem In lvDestinatari.Items
                    Sms.AddDestinatario(New Destinatario(i.SubItems(2).Text, "", i.SubItems(1).Text))
                Next

                Sms.Invia()

                Esito = Sms.Esito
            Else
                '+credito insufficiente
                MsgBox(String.Format("Credito insufficiente ({0} sms). Effettuare prima una ricarica e poi riprovare con l'invio", Credito), MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Esito.MessaggioErrore = "Credito insufficiente"
                Esito.EsitoChiamata = False
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Esito.EsitoChiamata = False
            Esito.MessaggioErrore = ex.Message
        End Try
    End Sub

    Private Sub tsbRubrica_Click(sender As System.Object, e As System.EventArgs) Handles tsbRubrica.Click
        Using r As New FormRubrica
            r.ShowDialog()

            If r.DialogResult = Windows.Forms.DialogResult.Yes Then
                AddDestinatarioEmail(TipoDestinatarioMail.A, r.Email)
            End If
        End Using
    End Sub

    Private Sub lstAllegati_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles ListAllegati.DragDrop
        AddAllegato(CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString)
    End Sub

    Private Sub lstAllegati_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles ListAllegati.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
            ListAllegati.BackColor = Color.Yellow
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub lstAllegati_DragLeave(sender As Object, e As System.EventArgs) Handles ListAllegati.DragLeave
        ListAllegati.BackColor = Color.White
    End Sub

    Private Sub lstAllegati_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ListAllegati.SelectedIndexChanged
        Try
            If ListAllegati.SelectedItem Is Nothing Then ListAllegati.SelectedIndex = -1
            If ListAllegati.SelectedIndex < 0 Then Exit Sub

            Dim fi As FileInfo
            fi = ListAllegati.SelectedItem

            TTip.SetToolTip(ListAllegati, fi.Name)

        Catch ex As Exception
            Globale.Log.Errore(ex)
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub tsbEsci_Click(sender As System.Object, e As System.EventArgs) Handles tsbEsci.Click
        Try
            If Esito.EsitoChiamata = False Then

                If lvDestinatari.Items.Count > 0 OrElse
                   txtOggetto.Text.Trim.Length > 0 OrElse
                   txtTesto.Text.Trim.Length > 0 OrElse
                   ListAllegati.Items.Count > 0 Then

                    If MsgBox("Confermate l'annullamento della comunicazione?",
                              MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question,
                              Utx.Globale.TitoloApp) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
            End If
            'lvDestinatari.Items(0).SubItems(1).Text

            'aggiorno la tabella rubrica nel db
            For k As Integer = 0 To lvDestinatari.Items.Count - 1
                Dim Query As String = String.Format("If (SELECT COUNT(*) AS Nr FROM Rubrica WHERE Email='{0}') = 0
                    INSERT INTO Rubrica (Email) VALUES('{0}')", lvDestinatari.Items(k).SubItems(1).Text)
                Utx.WsCommand.ExecuteNonQuery(Query)
            Next

            Me.Close()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub tsComprimi_Click(sender As System.Object, e As System.EventArgs) Handles tsComprimi.Click
        Try
            Cursor.Current = Cursors.WaitCursor

            If ListAllegati.SelectedIndex >= 0 Then
                'zippo item selezionato
                Dim f As FileInfo = ListAllegati.SelectedItem
                If f.Extension <> ".zip" Then
                    Utx.LibreriaZip.ZipFile(f.FullName, Path.Combine(mCartellaMail, f.Name + ".zip"))
                    File.Delete(f.FullName)
                End If
            Else
                'zippo tutti i file
                For Each f As FileInfo In ListAllegati.Items
                    If f.Extension <> ".zip" Then
                        Utx.LibreriaZip.ZipFile(f.FullName, Path.Combine(mCartellaMail, f.Name + ".zip"))
                        File.Delete(f.FullName)
                    End If
                Next
            End If
            AggiornaListaAllegati()

        Catch ex As Exception
            Globale.Log.Errore(ex)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub tsbElimina_Click(sender As System.Object, e As System.EventArgs) Handles tsbElimina.Click
        'elimina 1 allegato
        Try
            If String.IsNullOrEmpty(ListAllegati.Text) Then Exit Sub

            File.Delete(Path.Combine(mCartellaMail, ListAllegati.Text))
            ListAllegati.Items.Remove(ListAllegati.SelectedItem)

            lbDimensioneAllegati.Text = DimensioneAllegati()

        Catch ex As Exception
            Globale.Log.Errore(ex)
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Function DimensioneAllegati() As String
        Try
            Dim d As Double = PesoAllegati

            If d / 1048576 >= 1 Then 'più di 1 MB
                Return String.Format("Allegati {0} - Dimensione {1:N2} Mb", ListAllegati.Items.Count.ToString, d / 1048576)
                DimensioneAllegati = String.Format("{0:N2} Mb", d / 1048576)
            ElseIf d / 1024 >= 1 Then 'più di 1 Kb
                Return String.Format("Allegati {0} - Dimensione {1:N2} Kb", ListAllegati.Items.Count.ToString, d / 1024)
                DimensioneAllegati = String.Format("{0:N0} Kb", d / 1024)
            Else
                Return String.Format("Allegati {0} - Dimensione {1:N2} byte", ListAllegati.Items.Count.ToString, d)
                DimensioneAllegati = String.Format("{0:N0} byte", d)
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return "ND"
        End Try
    End Function

    Private Sub CancellaAllegati()
        Try
            For Each i As FileInfo In New DirectoryInfo(mCartellaMail).GetFiles
                File.Delete(i.FullName)
            Next

            ListAllegati.Items.Clear()

        Catch ex As Exception
            Globale.Log.Errore(ex)
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub AggiornaListaAllegati()
        Try
            ListAllegati.Items.Clear()

            For Each f As FileInfo In New DirectoryInfo(mCartellaMail).GetFiles
                ListAllegati.Items.Add(f)
            Next

            lbDimensioneAllegati.Text = DimensioneAllegati()

        Catch ex As Exception
            Globale.Log.Errore(ex)
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cboMittente_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cboMittente.Validating
        If rbMail.Checked Then
            e.Cancel = Not Utx.NetFunc.ValidEmail(cboMittente.Text, False, True)
        End If
    End Sub

    Private Sub tsbAggiungiAllegato_Click(sender As System.Object, e As System.EventArgs) Handles tsbAggiungiAllegato.Click
        Dim cd As New OpenFileDialog
        If cd.ShowDialog() = Windows.Forms.DialogResult.OK Then AddAllegato(cd.FileName)
    End Sub

    Private Sub tsbAggiungiDocumento_Click(sender As System.Object, e As System.EventArgs) Handles tsbAggiungiDocumento.Click
        Try
            If String.IsNullOrEmpty(mCodiceFiscale) Then
                Exit Sub
            End If

            Me.WindowState = FormWindowState.Minimized

            FormDocumenti = Utx.OggettoForm.Esiste(Utx.OggettoForm.TipoForm.DOCUMENTI)
            If FormDocumenti Is Nothing Then
                FormDocumenti = New UnitoolsDocumenti.FormDocumenti
            End If

            AddHandler FormDocumenti.CloseDoc, AddressOf FormDocumenti_CloseDoc

            With FormDocumenti
                .CodiceFiscale = mCodiceFiscale
                .NomeCliente = mNomeCliente
                .Id = mIdPratica
                .CartellaAllegati = mCartellaMail
            End With
            Utx.OggettoForm.Show(Utx.OggettoForm.TipoForm.DOCUMENTI)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub btnCancella_Click(sender As System.Object, e As System.EventArgs) Handles btnCancella.Click
        If lvDestinatari.SelectedItems.Count > 0 Then lvDestinatari.SelectedItems(0).Remove()
        cboDestinatario.Focus()
    End Sub

    Private Sub btnCancellaLista_Click(sender As System.Object, e As System.EventArgs) Handles btnCancellaLista.Click
        lvDestinatari.Items.Clear()
        cboDestinatario.Focus()
    End Sub

    Private Sub txtTesto_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTesto.TextChanged
        ControlloNumeroCaratteri()
    End Sub

    Private Sub cboDestinatario_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboDestinatario.KeyDown
        If e.KeyCode = Keys.Enter Then
            If rbMail.Checked Then
                AggiungiEmailSelezionata()
            Else
                btnAggiungi.PerformClick()
                cboDestinatario.Text = ""
            End If
        End If
    End Sub

    Private Sub cboDestinatario_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles cboDestinatario.MouseClick
        AggiungiEmailSelezionata()
    End Sub

    Private Sub AggiungiEmailSelezionata()
        Try
            If rbMail.Checked AndAlso cboDestinatario.Text IsNot String.Empty Then

                If Not String.IsNullOrEmpty(cboDestinatario.Text) Then
                    AddDestinatarioEmail(cboTipoDestinatario.SelectedIndex, cboDestinatario.Text)
                    AggiornaComboDestinatario()
                End If
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            MsgBox(ex.StackTrace, MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
        End Try
    End Sub

    Private Function EstraiNumeri(Stringa As String) As String

        EstraiNumeri = ""

        For Each c As Char In Stringa
            If Asc(c) >= 48 And Asc(c) <= 57 Then
                EstraiNumeri += c
            End If
        Next
    End Function

    Private Sub cboSmsPredefiniti_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSmsPredefiniti.SelectedIndexChanged
        Try
            'se la cartella sms è stata impostata
            If cboSmsPredefiniti.SelectedIndex > 0 Then
                txtTesto.Text = File.ReadAllText(Path.Combine(Me.CartellaSms, cboSmsPredefiniti.Text + ".msgsms"), System.Text.Encoding.Default)
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub AggiornaComboDestinatario()
        Try
            'se l'indirizzo non è in rubrica lo aggiungo
            If cboDestinatario.SelectedIndex < 0 Then

                If Not String.IsNullOrEmpty(cboDestinatario.Text) Then

                    Dim newRow As DataRow = Rubrica.NewRow()
                    newRow("Email") = cboDestinatario.Text.Trim
                    Rubrica.Rows.Add(newRow)
                End If
            End If

            cboDestinatario.Text = ""

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub lbStato_TextChanged(sender As Object, e As System.EventArgs) Handles lbStato.TextChanged
        lbStato.Visible = (lbStato.Text.Trim.Length > 0)
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        CheckForIllegalCrossThreadCalls = False

        If rbMail.Checked Then
            InviaMail()
        ElseIf rbSms.Checked Then
            InviaSms()
            AggiornaLabelCredito()
        End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If Esito.EsitoChiamata = True Then
            lbStato.Text = "Invio completato correttamente"

            'se c'è l'id della pratica e il codice fiscale
            If (String.IsNullOrEmpty(IdPratica) = False) AndAlso (String.IsNullOrEmpty(mCodiceFiscale) = False) Then
                'se non c'è un blocco all'inserimento nota (come in consap) inserisce la nota
                If mBloccaInserimentoNota = False Then
                    InserisciNota()
                End If
            End If
        Else
            If String.IsNullOrEmpty(Esito.MessaggioErrore) = False Then lbStato.Text = Esito.MessaggioErrore
        End If

        With pbInvio
            .Style = ProgressBarStyle.Blocks
            .Value = .Maximum
            .Visible = False
        End With

        Me.Enabled = True
        Application.DoEvents()
    End Sub

    Public Sub ControlloNumeroCaratteri()
        Try
            'caratteri residui. Messaggio.MaxLength conserva il valore dei caratteri utilizzabili
            txtCarUtilizzati.Text = UniCom.MessaggioSms.NumeroCaratteriUtilizzati(txtTesto.Text)

            If txtCarUtilizzati.Text > txtTesto.MaxLength Then
                'se eccede la massima lunghezza taglia il carattere
                txtTesto.Text = txtTesto.Text.Substring(0, txtTesto.Text.Length - 1)
                txtCarUtilizzati.Text -= 1
            End If

            txtCarDisponibili.Text = UniCom.MessaggioSms.MaxDimensioneSms - txtCarUtilizzati.Text

            If txtCarDisponibili.Text > 0 Then
                txtCarDisponibili.BackColor = Color.LightGreen
            Else
                txtCarDisponibili.BackColor = Color.Coral
            End If

            'numero messaggi utilizzati
            txtNumeroSms.Text = UniCom.MessaggioSms.Msg2NumeroSms(txtTesto.Text)

        Catch ex As Exception
            Globale.Log.Errore(ex)
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub InserisciNota()
        Try
            Dim Nota As New Utx.Nota
            With Nota
                .NuovaNota = True
                .Tipo = Utx.Nota.TipoNota.NOTA
                .IdNota = IdPratica
                .CodiceFiscale = mCodiceFiscale
                .Utente = IIf(rbMail.Checked, "Mail", "Sms")
                .DataModifica = Now
                .Allarme = DBNull.Value
                .Testo = IIf(rbMail.Checked, TestoNotaMail, TestoNotaSms)
                .SalvaNota()
            End With

        Catch ex As Exception
            Globale.Log.Info(ex.Message)
            MsgBox("Impossibile aggiungere la comunicazione alle note.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
        End Try
    End Sub

    Private Function TestoNotaMail() As String
        'restituisce il testo formattato da inserire nelle note del sinistro
        Try
            Dim Rientro As String = Space(2)
            Dim Separatore As String = StrDup(60, "_") + Environment.NewLine

            '0=a capo, 1=rientro, 2=separatore
            Dim Testo As String = "Mittente: {3} ({12}) - {4}{0}" +
                                  "Data e ora invio: {5}{0}{2}" +
                                  "Destinatari:{0}" +
                                  "{1}A: {6}{0}" +
                                  "{1}Cc: {7}{0}" +
                                  "{1}Ccn: {8}{0}{2}" +
                                  "Oggetto:{0}{1}{9}{0}{2}" +
                                  "Testo del messaggio:{0}{10}{0}{2}" +
                                  "File allegati:{0}{11}{2}"

            'destinatari
            Dim A As String = ""
            Dim CC As String = ""
            Dim CCN As String = ""

            For Each i As ListViewItem In lvDestinatari.Items

                Select Case i.SubItems(0).Text.ToUpper
                    Case "A"
                        A += i.SubItems(1).Text + ";"
                    Case "CC"
                        CC += i.SubItems(1).Text + ";"
                    Case "CCN"
                        CCN += i.SubItems(1).Text + ";"
                End Select
            Next

            'allegati
            Dim Allegati As String = ""

            If ListAllegati.Items.Count = 0 Then
                Allegati += String.Format("{1}Nessun allegato al messaggio{0}", Environment.NewLine, Rientro)
            Else
                For Each fi As FileInfo In ListAllegati.Items
                    Allegati += String.Format("{1}{2}{0}", Environment.NewLine, Rientro, fi.Name)
                Next
            End If

            Return String.Format(Testo,
                                 Environment.NewLine,
                                 Rientro,
                                 Separatore,
                                 Utx.Globale.AgenziaRichiesta.CodiceAgenzia,
                                 cboMittente.Text,
                                 Now,
                                 A, CC, CCN,
                                 txtOggetto.Text, txtTesto.Text, Allegati,
                                 Utx.Globale.UtenteCorrente.UniageUser)

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return "Errore nella creazione del testo della nota."
        End Try
    End Function

    Private Function TestoNotaSms() As String
        'restituisce il testo formattato da inserire nelle note del sinistro
        Try
            Dim Separatore As String = StrDup(60, "_") + Environment.NewLine

            '0=a capo, 4=separatore
            Dim Testo As String = "Mittente: {1}{0}" +
                                  "Data e ora invio: {2}{0}" +
                                  "Destinatari: {3}{0}{4}" +
                                  "Testo del messaggio: {0}{5}"

            'destinatari
            Dim A As String = ""

            For Each i As ListViewItem In lvDestinatari.Items
                A += i.SubItems(1).Text + ";"
            Next

            Return String.Format(Testo,
                                 Environment.NewLine,
                                 cboMittente.Text,
                                 Now,
                                 A,
                                 Separatore,
                                 txtTesto.Text)

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return "Errore nella creazione del testo della nota."
        End Try
    End Function

    Private Sub tsbFirma_ButtonClick(sender As System.Object, e As System.EventArgs) Handles tsbFirma.ButtonClick
        Try
            If File.Exists(FileFirma) = False Then
                Using f As New FormFirma(Messaggio)
                    f.FileFirma = FileFirma
                    f.ShowDialog()
                End Using
            End If
            If File.Exists(FileFirma) Then
                txtTesto.Text += Environment.NewLine + Environment.NewLine + File.ReadAllText(FileFirma)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ChekBoxMittente_CheckedChanged(sender As Object, e As System.EventArgs) Handles ChekBoxMittente.CheckedChanged
        If ChekBoxMittente.Checked = True Then
            ChekBoxMittente.BackColor = Color.NavajoWhite
        Else
            ChekBoxMittente.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub ModificaFirmaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificaFirmaToolStripMenuItem.Click
        Try
            Using f As New FormFirma(Messaggio)
                f.FileFirma = FileFirma
                f.ShowDialog()
            End Using
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub FormDocumenti_CloseDoc()
        'per non far rimanere la finestra mail "appesa" al form documenti che viene nascosto ma non distrutto
        RemoveHandler FormDocumenti.CloseDoc, AddressOf FormDocumenti_CloseDoc
        Me.WindowState = FormWindowState.Normal
        'aggiorno il box con la lista degli allegati
        AggiornaListaAllegati()
    End Sub

    Private Sub tsbSalva_Click(sender As Object, e As EventArgs) Handles tsbSalva.Click
        Try
            If String.IsNullOrEmpty(txtTesto.Text) Then
                MsgBox("Nessun testo da salvare", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Exit Sub
            End If

            Using cd As New SaveFileDialog
                If rbMail.Checked Then
                    cd.InitialDirectory = Utx.Globale.UtenteCorrente.Desktop
                    cd.Filter = "File testo (*.txt)|*.txt"
                    cd.OverwritePrompt = True
                    cd.FileName = "E-mail"

                    If cd.ShowDialog = Windows.Forms.DialogResult.OK Then
                        Dim sb As New System.Text.StringBuilder
                        sb.AppendLine("Destinatari:")
                        For Each i As ListViewItem In lvDestinatari.Items
                            sb.AppendLine(i.SubItems(1).Text)
                        Next
                        sb.AppendLine()
                        sb.AppendLine("Allegati:")
                        For Each i As FileInfo In ListAllegati.Items
                            sb.AppendLine(i.FullName)
                        Next
                        sb.AppendLine()
                        sb.AppendLine("Oggetto:" & txtOggetto.Text)
                        sb.AppendLine()
                        sb.AppendLine("Testo della e-mail:")
                        sb.Append(txtTesto.Text)

                        File.WriteAllText(cd.FileName, sb.ToString)
                    End If
                Else
                    cd.InitialDirectory = Utx.Globale.Paths.CartellaSms
                    cd.Filter = "File messaggio (*.msgsms)|*.msgsms"
                    cd.OverwritePrompt = True
                    cd.FileName = "Modello sms"

                    If cd.ShowDialog = Windows.Forms.DialogResult.OK Then
                        File.WriteAllText(cd.FileName, txtTesto.Text)
                    End If

                    If rbSms.Checked Then
                        CaricaSmsPredefiniti()
                    End If
                End If
            End Using
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub FormMail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Directory.Delete(mCartellaMail, True)
    End Sub
End Class
