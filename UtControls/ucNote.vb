Imports System.Windows.Forms
Imports System.IO

Public Class ucNote

    Public Event TipoNotaChanged(Tipo As Utx.Nota.TipoNota)
    Public Event StampaSinistro(StampaNote As Boolean)
    Public Event RichiestaConsap()
    Public Event RipristinaNoteSinistro()
    Public Event RipristinaNoteSinistroCompletato(IdSinistro As String)

    Private WithEvents NotaCorrente As Utx.Nota
    Private mContestoSinistri As Boolean

    Sub New(Documenti As Boolean, Optional ContestoSinistri As Boolean = False)
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Dock = Windows.Forms.DockStyle.Fill
        Me.Margin = New Padding(3)
        Me.Padding = New Padding(3)

        mContestoSinistri = ContestoSinistri

        ImpostaControlli()

        If Documenti = False Then
            SplitContainer3.Panel2Collapsed = True
        End If

        AddHandler RadioButtonNote.CheckedChanged, AddressOf RadioButtonNote_CheckedChanged
        RadioButtonNote.Checked = True
    End Sub

    Private mIdNote As String
    Public Property IdNote() As String
        Get
            Return mIdNote
        End Get
        Set(value As String)
            mIdNote = value
        End Set
    End Property

    Private mCF As String
    Public Property CF() As String
        Get
            Return mCF
        End Get
        Set(value As String)
            mCF = value
        End Set
    End Property

    Public ReadOnly Property Tipo() As Utx.Nota.TipoNota
        Get
            If RadioButtonNote.Checked = True Then
                Return Utx.Nota.TipoNota.NOTA
            Else
                Return Utx.Nota.TipoNota.ATTIVITA
            End If
        End Get
    End Property

    Private mCartellaDocumenti As String
    Public Property CartellaDocumenti() As String
        Get
            Return mCartellaDocumenti
        End Get
        Set(value As String)
            mCartellaDocumenti = value

            Dim dt As New DataTable()
            dt.Columns.Add(New DataColumn("Documento"))
            For Each file In Directory.GetFiles(mCartellaDocumenti)
                Dim filename As String = IO.Path.GetFileName(file)
                dt.Rows.Add(filename)
            Next
            dgvDocumenti.DataSource = dt
            dgvDocumenti.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgvDocumenti.Tag = mCartellaDocumenti
            If mContestoSinistri = True Then
                dgvDocumenti.Columns(0).HeaderText = "Documenti sinistro"
            Else
                dgvDocumenti.Columns(0).HeaderText = "Documenti cliente"
            End If
        End Set
    End Property

    Public Sub SalvaNota()
        Try
            If NotaCorrente IsNot Nothing Then
                NotaCorrente.Testo = TextBoxNota.Text
                NotaCorrente.SalvaNota(TextBoxNota, CheckBoxAggiornaData.Checked)
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ImpostaControlli()
        SplitContainer1.SplitterDistance = Me.Width * 0.2
        SplitContainer2.SplitterDistance = Me.Height * 0.7
        SplitContainer3.SplitterDistance = Me.Height * 0.7

        tlpNote.BackColor = Drawing.Color.Transparent

        With RadioButtonNote
            .Text = "Note"
            .TextAlign = Drawing.ContentAlignment.MiddleLeft
        End With
        With RadioButtonAttivita
            .Text = "Attività"
            .TextAlign = Drawing.ContentAlignment.MiddleLeft
        End With
        ImpostaColoriNota()

        With ButtonNuovaNota
            .Padding = New Padding(5)
            .FlatAppearance.MouseDownBackColor = Drawing.Color.Moccasin
            .Text = "Nuova nota"
            .TextAlign = Drawing.ContentAlignment.BottomCenter
            .Image = Risorse.Immagini.Bitmap("notifica")
            .ImageAlign = Drawing.ContentAlignment.TopCenter
        End With
        With ButtonSalvaNota
            .Padding = New Padding(5)
            .FlatAppearance.MouseDownBackColor = Drawing.Color.Moccasin
            .Text = "Salva nota"
            .TextAlign = Drawing.ContentAlignment.BottomCenter
            .Image = Risorse.Immagini.Bitmap("salva")
            .ImageAlign = Drawing.ContentAlignment.TopCenter
        End With
        With ButtonCopiaNota
            .Padding = New Padding(5)
            .FlatAppearance.MouseDownBackColor = Drawing.Color.Moccasin
            .Text = "Copia nota"
            .TextAlign = Drawing.ContentAlignment.BottomCenter
            .Image = Risorse.Immagini.Bitmap("copia")
            .ImageAlign = Drawing.ContentAlignment.TopCenter
        End With
        With ButtonCancellaNota
            .Padding = New Padding(5)
            .FlatAppearance.MouseDownBackColor = Drawing.Color.Moccasin
            .Text = "Cancella nota"
            .TextAlign = Drawing.ContentAlignment.BottomCenter
            .Image = Risorse.Immagini.Bitmap("cancel")
            .ImageAlign = Drawing.ContentAlignment.TopCenter
        End With
        With ButtonStampaNota
            .Padding = New Padding(5)
            .FlatAppearance.MouseDownBackColor = Drawing.Color.Moccasin
            .Image = Risorse.Immagini.Bitmap("print")
            .ImageAlign = Drawing.ContentAlignment.TopCenter
            .Text = "Stampa nota"
            .TextAlign = Drawing.ContentAlignment.BottomCenter
        End With
        With ButtonNotifiche
            .Padding = New Padding(5)
            .FlatAppearance.MouseDownBackColor = Drawing.Color.Moccasin
            .Image = Risorse.Immagini.Bitmap("ricevuta")
            .ImageAlign = Drawing.ContentAlignment.TopCenter
            .Text = "Notifiche sms"
            .TextAlign = Drawing.ContentAlignment.BottomCenter
        End With
        With ButtonStampaDettaglio
            .Padding = New Padding(5)
            .FlatAppearance.MouseDownBackColor = Drawing.Color.Moccasin
            .Image = Risorse.Immagini.Bitmap("print")
            .ImageAlign = Drawing.ContentAlignment.TopCenter
            .Text = "Stampa sinistro"
            .TextAlign = Drawing.ContentAlignment.BottomCenter
            .Visible = mContestoSinistri
        End With
        With ButtonStampaDettaglioNote
            .Padding = New Padding(5)
            .FlatAppearance.MouseDownBackColor = Drawing.Color.Moccasin
            .Image = Risorse.Immagini.Bitmap("print")
            .ImageAlign = Drawing.ContentAlignment.TopCenter
            .Text = "Stampa sinistro con note"
            .TextAlign = Drawing.ContentAlignment.BottomCenter
            .Visible = mContestoSinistri
        End With
        With ButtonConsap
            .Padding = New Padding(5)
            .FlatAppearance.MouseDownBackColor = Drawing.Color.Moccasin
            .Image = Risorse.Immagini.Bitmap("clock")
            .ImageAlign = Drawing.ContentAlignment.TopCenter
            .Text = "Crea attività CONSAP"
            .TextAlign = Drawing.ContentAlignment.BottomCenter
            .Visible = mContestoSinistri
        End With
        With CheckBoxAggiornaData
            .Padding = New Padding(5)
            .Margin = New Padding(0)
            .Appearance = Appearance.Button
            .FlatStyle = FlatStyle.Flat
            .Image = Risorse.Immagini.Bitmap("edit")
            .ImageAlign = Drawing.ContentAlignment.TopCenter
            .TextAlign = Drawing.ContentAlignment.BottomCenter
            .Checked = Convert.ToBoolean(Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.AGGIORNA_DATA_NOTE, "False"))
            CheckBoxAggiornaData_CheckedChanged(Me, New EventArgs)
        End With
        With ButtonRipristinoNote
            .Padding = New Padding(0)
            .FlatAppearance.BorderSize = 1
            .BackColor = Drawing.Color.LightPink
            .FlatAppearance.BorderColor = Drawing.Color.Red
            .Text = "Manutenzione tabella note"
        End With
        With ButtonRipristinoBackup
            .Padding = New Padding(0)
            .FlatAppearance.BorderSize = 1
            .BackColor = Drawing.Color.PaleGreen
            .FlatAppearance.BorderColor = Drawing.Color.Green
            .Text = "Recupero note di questo sinistro da backup"
            .Visible = mContestoSinistri
        End With

        dtpAttivita.Format = DateTimePickerFormat.Short

        'imposta griglia elenco note
        With dgvNote
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .RowHeadersVisible = False
            .ColumnHeadersVisible = False
            .AllowUserToResizeColumns = False
            .AllowUserToResizeRows = False
            .MultiSelect = False
            .CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal
            .ScrollBars = ScrollBars.Vertical
            .BackgroundColor = Drawing.Color.LightYellow
        End With
        Utx.NetFunc.DoppioBuffer(dgvNote)

        TextBoxNota.Font = New Drawing.Font(TextBoxNota.Font.Name, 12)
    End Sub

    Private Sub ImpostaColoriNota()
        Dim Normale As New Drawing.Font(RadioButtonNote.Font.Name, RadioButtonNote.Font.Size, Drawing.FontStyle.Regular)
        Dim Grassetto As New Drawing.Font(RadioButtonNote.Font.Name, RadioButtonNote.Font.Size, Drawing.FontStyle.Bold)

        If Me.Tipo = Utx.Nota.TipoNota.NOTA Then
            Panel1.BackColor = Drawing.Color.LightYellow
            RadioButtonNote.Font = Grassetto
            RadioButtonAttivita.Font = Normale
        Else
            Panel1.BackColor = Drawing.Color.LightSalmon
            RadioButtonNote.Font = Normale
            RadioButtonAttivita.Font = Grassetto
        End If
        Panel1.Refresh()
    End Sub

    Private Sub RadioButtonNote_CheckedChanged(sender As Object, e As EventArgs)
        SalvaNota()
        NotaCorrente = Nothing

        ImpostaColoriNota()

        If RadioButtonNote.Checked = True Then
            ButtonNuovaNota.Text = "Nuova nota"
            ButtonSalvaNota.Text = "Salva nota"
            ButtonCopiaNota.Text = "Copia nota"
            ButtonCancellaNota.Text = "Cancella nota"
            ButtonStampaNota.Text = "Stampa nota"
        Else
            ButtonNuovaNota.Text = "Nuova attività"
            ButtonSalvaNota.Text = "Salva attività"
            ButtonCopiaNota.Text = "Copia attività"
            ButtonCancellaNota.Text = "Cancella attività"
            ButtonStampaNota.Text = "Stampa attività"
        End If
        GroupBoxScadenzaAttivita.Enabled = (Me.Tipo = Utx.Nota.TipoNota.ATTIVITA)
        SplitContainer2.Panel2.Refresh()

        RaiseEvent TipoNotaChanged(Me.Tipo)
    End Sub

    Private Sub dgvNote_CurrentCellChanged(sender As Object, e As EventArgs)
        Try
            dgvNote.AutoResizeRows()

            If dgvNote.CurrentRow Is Nothing Then
                NotaCorrente = Nothing
                TextBoxNota.Text = ""
                dtpAttivita.Value = Today
                dtpAttivita.Checked = False
            Else
                'salvo la nota che sto lasciando
                SalvaNota()
                'aumento l'altezza della riga selezionata
                dgvNote.CurrentRow.Height = dgvNote.CurrentRow.Height * 2

                NotaCorrente = New Utx.Nota(dgvNote.DataSource.Rows(dgvNote.CurrentRow.Index))
                NotaCorrente_CambioTipoNota()

                'visualizzo la nota
                TextBoxNota.Text = NotaCorrente.Testo

                If NotaCorrente.EsisteAllarme Then
                    dtpAttivita.Value = NotaCorrente.Allarme
                    dtpAttivita.Checked = True
                Else
                    dtpAttivita.Value = Today
                    dtpAttivita.Checked = False
                End If
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub FormattaElencoNote()
        If dgvNote.Rows.Count > 0 Then

            With dgvNote
                .ScrollBars = ScrollBars.Both
                'visibili solo utente e elenco(data e completato)
                .Columns("DataModifica").Visible = False
                .Columns("Memo").Visible = False
                .Columns("Allarme").Visible = False
                .Columns("Tipo").Visible = False
                .Columns("Id").Visible = False
                .Columns("IdNota").Visible = False
                .Columns("CodiceFiscale").Visible = False
                .Columns("DataCommit").Visible = False

                .Columns("Utente").DisplayIndex = 0
                .Columns("Utente").DefaultCellStyle.BackColor = Drawing.Color.LightSteelBlue
                .Columns("Utente").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns("Elenco").DisplayIndex = 1
                .Columns("Elenco").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
        End If
    End Sub

    Public Sub LeggiNote()
        Try
            Me.Cursor = Cursors.WaitCursor

            RemoveHandler dgvNote.CurrentCellChanged, AddressOf dgvNote_CurrentCellChanged

            dgvNote.DataSource = Utx.Nota.LeggiNote(IdNote, Me.Tipo)

            FormattaElencoNote()

            If Me.Visible = True Then
                dgvNote_CurrentCellChanged(Me, New EventArgs)
                AddHandler dgvNote.CurrentCellChanged, AddressOf dgvNote_CurrentCellChanged
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ButtonSalvaNota_Click(sender As Object, e As EventArgs) Handles ButtonSalvaNota.Click
        If NotaCorrente IsNot Nothing Then
            SalvaNota()
        Else
            MsgBox("Non esiste una nota corrente. Utilizzare 'Nuova nota' per crearne una o selezionare una nota esistente", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
        End If
    End Sub

    Private Sub ButtonNuovaNota_Click(sender As Object, e As EventArgs) Handles ButtonNuovaNota.Click
        Try
            Dim Redattore As String = InputBox("Annotazione redatta da:", "Nuova annotazione", Utx.Globale.UtenteCorrente.UniageUser.ToUpper)
            If String.IsNullOrEmpty(Redattore) Then
                Exit Sub
            End If

            Dim NuovaNota As New Utx.Nota
            With NuovaNota
                .NuovaNota = True
                .IdNota = mIdNote
                .CodiceFiscale = mCF
                .Utente = Microsoft.VisualBasic.Left(Redattore, 14)
                .DataModifica = Now
                .Testo = ""
                .Tipo = Me.Tipo
                If Me.Tipo = Utx.Nota.TipoNota.NOTA Then
                    .Allarme = DBNull.Value
                Else
                    .Allarme = Today
                End If
                .SalvaNota()
            End With

            LeggiNote()
            TextBoxNota.Focus()

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub dtpAttivita_ValueChanged(sender As Object, e As EventArgs) Handles dtpAttivita.ValueChanged
        If NotaCorrente IsNot Nothing Then
            Select Case NotaCorrente.Tipo
                Case Utx.Nota.TipoNota.NOTA
                    dtpAttivita.Checked = False
                    NotaCorrente.Allarme = DBNull.Value
                Case Utx.Nota.TipoNota.ATTIVITA, Utx.Nota.TipoNota.ATTIVITA_COMPLETATA
                    dtpAttivita.Checked = True
                    NotaCorrente.Allarme = dtpAttivita.Value.Date
            End Select
        End If
    End Sub

    Private Sub ButtonCancellaNota_Click(sender As Object, e As EventArgs) Handles ButtonCancellaNota.Click
        If NotaCorrente IsNot Nothing Then
            NotaCorrente.CancellaNota()
            LeggiNote()
        End If
    End Sub

    Private Sub ButtonCopiaNota_Click(sender As Object, e As EventArgs) Handles ButtonCopiaNota.Click
        Try
            Clipboard.Clear()
            'Sleep 100 'evita l'errore 521 in VB6
            Clipboard.SetText(TextBoxNota.Text)

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonStampaNota_Click(sender As Object, e As EventArgs) Handles ButtonStampaNota.Click
        Try
            Dim Stampa As New Utx.TextPrint(TextBoxNota.Text)
            'seleziono la stampante
            Dim pd As New PrintDialog
            pd.ShowDialog()
            Stampa.PrinterSettings = pd.PrinterSettings
            'stampo
            Stampa.Print()

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub dgvDocumenti_DoubleClick(sender As Object, e As EventArgs) Handles dgvDocumenti.DoubleClick
        If dgvDocumenti.CurrentRow IsNot Nothing Then
            Process.Start(Path.Combine(dgvDocumenti.Tag, dgvDocumenti.CurrentRow.Cells("Documento").Value))
        End If
    End Sub

    Private Sub TextBoxNota_LostFocus(sender As Object, e As EventArgs) Handles TextBoxNota.LostFocus
        SalvaNota()
    End Sub

    Private Sub ButtonNotifiche_Click(sender As Object, e As EventArgs) Handles ButtonNotifiche.Click
        Try
            Using f As New UniCom.FormNotifiche

                Dim contatti As Utx.Recapiti = Utx.Recapiti.GetRecapitiCliente(mCF).Filtra(Utx.TipoRecapitoEnum.Cellulare)
                If contatti.Count > 0 Then
                    Dim ListaTelefoni As New List(Of String)
                    For Each r In contatti
                        ListaTelefoni.Add(r.Contatto)
                    Next
                    f.Telefoni = ListaTelefoni
                End If

                f.ShowDialog()
            End Using

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonStampaDettaglio_Click(sender As Object, e As EventArgs) Handles ButtonStampaDettaglio.Click
        RaiseEvent StampaSinistro(False)
    End Sub

    Private Sub ButtonStampaDettaglioNote_Click(sender As Object, e As EventArgs) Handles ButtonStampaDettaglioNote.Click
        RaiseEvent StampaSinistro(True)
    End Sub

    Private Sub ButtonAttivitaCompletata_Click(sender As Object, e As EventArgs) Handles ButtonAttivitaCompletata.Click
        Try
            If NotaCorrente IsNot Nothing Then
                Select Case NotaCorrente.Tipo
                    Case Utx.Nota.TipoNota.NOTA
                        'non fare niente. non dovrebbe mai arrivare qui perchè il button è disabilitato
                    Case Utx.Nota.TipoNota.ATTIVITA
                        If String.IsNullOrEmpty(NotaCorrente.Testo) Then
                            MsgBox("Inserire prima un testo che descriva l'attività", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                        Else
                            NotaCorrente.Tipo = Utx.Nota.TipoNota.ATTIVITA_COMPLETATA
                            NotaCorrente.SalvaNota()
                        End If
                    Case Utx.Nota.TipoNota.ATTIVITA_COMPLETATA
                        If MsgBox("Volete ripristinare l'attività completata?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            NotaCorrente.Tipo = Utx.Nota.TipoNota.ATTIVITA
                            NotaCorrente.SalvaNota()
                        End If
                End Select
                LeggiNote()
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub NotaCorrente_CambioTipoNota() Handles NotaCorrente.CambioTipoNota
        Select Case NotaCorrente.Tipo
            Case Utx.Nota.TipoNota.NOTA
                TextBoxNota.Enabled = True
                ButtonAttivitaCompletata.Text = "Completa attività"
            Case Utx.Nota.TipoNota.ATTIVITA
                TextBoxNota.Enabled = True
                ButtonAttivitaCompletata.Text = "Completa attività"
            Case Utx.Nota.TipoNota.ATTIVITA_COMPLETATA
                TextBoxNota.Enabled = False
                ButtonAttivitaCompletata.Text = "Ripristina attività"
        End Select
    End Sub

    Private Sub ucNote_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible = True Then
            dgvNote_CurrentCellChanged(Me, New EventArgs)
            AddHandler dgvNote.CurrentCellChanged, AddressOf dgvNote_CurrentCellChanged
        Else
            RemoveHandler dgvNote.CurrentCellChanged, AddressOf dgvNote_CurrentCellChanged
        End If
    End Sub

    Private Sub CheckBoxAggiornaData_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxAggiornaData.CheckedChanged
        With CheckBoxAggiornaData
            If .Checked = True Then
                .FlatAppearance.BorderColor = Drawing.Color.Green
                .FlatAppearance.CheckedBackColor = Drawing.Color.PaleGreen
                .Text = "Aggiorna la data quando modifico la nota"
            Else
                .BackColor = Drawing.Color.Moccasin
                .FlatAppearance.BorderColor = Drawing.Color.Salmon
                .Text = "Non aggiornare la data quando modifico la nota"
            End If
            'registro la variazione
            Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.AGGIORNA_DATA_NOTE, .Checked.ToString)
        End With
    End Sub

    Private Sub ButtonConsap_Click(sender As Object, e As EventArgs) Handles ButtonConsap.Click
        RaiseEvent RichiestaConsap()
    End Sub

    Private Sub ButtonRipristinoBackup_Click(sender As Object, e As EventArgs) Handles ButtonRipristinoBackup.Click
        If MsgBox("Procedere con il recupero delle note del sinistro dai backup? Il processo può durare alcuni minuti.",
                  MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then
            RaiseEvent RipristinaNoteSinistro()
        End If
    End Sub
End Class
