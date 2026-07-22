Imports System.Windows.Forms
Imports System.Drawing

Public Class frmGrid
    Private WithEvents mFrame As New FrameParametri()
    Private WithEvents mCheckBoxHeaderCell As DataGridViewCheckBoxHeaderCell
    Private ReadOnly mFormFiltro As New Utx.FormGestioneFiltro

    Private mMfs As CManifestoSql
    'Private mDatiGridFilename As String = ""
    Private mUnicoverExists As Boolean = False
    Private mAgenzia As String
    Public Annulla As Boolean = False
    Public UsoStampa As Boolean = False
    Public ParentPage As TabPage = Nothing
    Public AutoEsegui As Boolean = False

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(scalaX As Integer, scalaY As Integer)
        InitializeComponent()
        If scalaX < 10 Then scalaX = 10
        If scalaX > 100 Then scalaX = 100

        If scalaY < 10 Then scalaY = 10
        If scalaY > 100 Then scalaY = 100

        If scalaX < 100 Or scalaY < 100 Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.MinimumSize = New Size(Screen.PrimaryScreen.WorkingArea.Width * 0.5,
                               Screen.PrimaryScreen.WorkingArea.Height * 0.5)
            Me.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width * scalaX / 100,
                               Screen.PrimaryScreen.WorkingArea.Height * scalaY / 100)
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub btnAnagCliente_Click(sender As Object, e As EventArgs) Handles btnAnagCliente.Click
        Dim dt As DataTable = grdResult.DataSource

        Dim codiceFiscaleIndex As Integer = -1
        For i As Integer = 1 To grdResult.ColumnCount - 1
            If Replace(grdResult.Columns(i).HeaderText, " ", "").ToUpper Like "*CODICEFISCALE*" Then
                codiceFiscaleIndex = i
                Exit For
            End If
        Next
        Dim f As Anag.FormAnagrafiche

        If Utx.OggettoForm.Show(Utx.OggettoForm.TipoForm.ANAG) = False Then
            f = New Anag.FormAnagrafiche()
            Utx.OggettoForm.Show(Utx.OggettoForm.TipoForm.ANAG)
        Else
            f = Utx.OggettoForm.Esiste(Utx.OggettoForm.TipoForm.ANAG)
        End If
        Application.DoEvents()

        If codiceFiscaleIndex >= 0 AndAlso grdResult.SelectedRows.Count > 0 Then
            f.SelezionaClientePerCodiceFiscale(grdResult.SelectedRows(0).Cells(codiceFiscaleIndex).Value)
        End If
    End Sub

    Private Sub frmGrid_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If ParentPage IsNot Nothing Then
            CType(ParentPage.Parent, TabControl).TabPages.Remove(ParentPage)
        End If
    End Sub

    Private Sub frmGrid_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Font = Utx.AppFont.Normal
        LabelCaption.Font = Utx.AppFont.Bold(16)
        LabelCaption.ForeColor = Utx.AppColor.AzzurroScuro
        lblHelp.Font = Utx.AppFont.Bold
        lblHelp.ForeColor = Utx.AppColor.AzzurroScuro
        With lblGridMsg
            .Font = Utx.AppFont.Bold
            .ForeColor = Utx.AppColor.AzzurroScuro
            .TextAlign = ContentAlignment.BottomRight
        End With
        With grdResult
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
        Utx.NetFunc.DoppioBuffer(grdResult)

        GridMessage("")
        PanelStampa.Visible = UsoStampa

        mUnicoverExists = IO.File.Exists(IO.Path.Combine(UniSql.GetCartellaExe(), "UniCover.exe"))
        btnStampaCopertinaA3.Visible = mUnicoverExists
        btnStampaCopertinaA3.Visible = mUnicoverExists

        btnComunica.Image = Risorse.Immagini.Bitmap("comunica")
        btnRiesegui.Image = Risorse.Immagini.Bitmap("aggiorna")
        btnFileCsv.Image = Risorse.Immagini.Bitmap("csv")
        btnStampaCopertinaA3.Image = Risorse.Immagini.Bitmap("print")
        btnEsci.Image = Risorse.Immagini.Bitmap("esci")
        btnAnagCliente.Image = Risorse.Immagini.Bitmap("cliente")
        btnGestioneBda.Image = Risorse.Immagini.Bitmap("ania")
        With ButtonNota
            .Image = Risorse.Immagini.Bitmap("evidenza")
            If mMfs IsNot Nothing Then
                .Visible = mMfs.Applicazioni.Contains("NOTA")
            Else
                .Visible = False
            End If
            SeparatoreNota.Visible = .Visible
        End With

        If UsoStampa Then
            EnableControls()
            CaricaEstrazioniPerStampe()
        End If

        'esecuzione automatica in fase di load 
        If AutoEsegui Then
            ExecuteSql()
        End If
    End Sub

    Private Sub CheckBoxHeaderCell_CheckBoxClicked(sender As Object, e As DataGridViewCheckBoxHeaderCellEventArgs) Handles mCheckBoxHeaderCell.CheckBoxClicked
        mCheckBoxHeaderCell.CheckUncheckEntireColumn(e.Checked)
        mCheckBoxHeaderCell.RefreshCheckState()
        UpdateRowCount()
    End Sub

    Private Sub grdResult_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdResult.CellClick
        If e.ColumnIndex = 0 And e.RowIndex >= 0 Then
            ChangeRowSelection(e.RowIndex)
        End If
    End Sub

    Private Sub grdResult_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdResult.CellDoubleClick
        If e.RowIndex >= 0 Then
            ChangeRowSelection(e.RowIndex)
        End If
    End Sub

    Private Sub ChangeRowSelection(RowIndex As Integer)
        grdResult.Rows(RowIndex).Cells(0).Value = Not grdResult.Rows(RowIndex).Cells(0).Value

        Dim th As New Threading.Thread(Sub()
                                           RowColor(RowIndex)
                                           mCheckBoxHeaderCell.RefreshCheckState()
                                           UpdateRowCount()
                                       End Sub)
        th.Start()
    End Sub

    Private Sub RowColor(Optional RowIndex As Integer = -1)
        If RowIndex < 0 Then
            For Each row As DataGridViewRow In grdResult.Rows
                If row.Cells(0).Value = True Then
                    row.DefaultCellStyle.BackColor = Color.White
                Else
                    row.DefaultCellStyle.BackColor = Color.Gainsboro
                End If
            Next
        Else
            If grdResult.Rows(RowIndex).Cells(0).Value = True Then
                grdResult.Rows(RowIndex).DefaultCellStyle.BackColor = Color.White
            Else
                grdResult.Rows(RowIndex).DefaultCellStyle.BackColor = Color.Gainsboro
            End If
        End If
    End Sub

    Private Sub EnableControls()
        Dim gridAsRows As Boolean = grdResult.Rows.Count > 0

        ' TOOL BAR
        btnRiesegui.Enabled = (mMfs IsNot Nothing)
        btnFileCsv.Enabled = (mMfs IsNot Nothing) And gridAsRows
        btnProprieta.Enabled = (mMfs IsNot Nothing) And gridAsRows
        btnStampaCopertinaA3.Enabled = gridAsRows And (mMfs IsNot Nothing)
        btnComunica.Enabled = gridAsRows And (mMfs IsNot Nothing)
        btnAnagCliente.Enabled = btnComunica.Enabled
        btnGestioneBda.Enabled = btnComunica.Enabled
        ButtonNota.Enabled = btnComunica.Enabled

        'STAMPA UNIONE (stampa lettere)
        ButtonSelezioneEtStampa.Enabled = (mMfs IsNot Nothing) And gridAsRows
    End Sub

    Public Sub ApplyButton(Descrizione As String, ToolTip As String, ApplyButtonImage As Image)
        If Descrizione IsNot Nothing Then

            Dim btnOpt As New System.Windows.Forms.ToolStripButton
            With btnOpt
                .AutoSize = False
                .Image = ApplyButtonImage
                .ImageTransparentColor = System.Drawing.Color.White
                .ForeColor = Color.Blue
                .BackColor = Color.LightCyan
                .Name = "btnOpt"
                .Size = New System.Drawing.Size(120, 49)
                .Text = Descrizione
                .ToolTipText = ToolTip
                .TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
            End With
            Me.ToolStrip1.Items.Add(btnOpt)
            AddHandler btnOpt.Click, AddressOf btnEsci_Click

            btnEsci.Text = "Annulla"
            btnEsci.Text = btnEsci.Text
        End If
    End Sub

    Public Sub ExecuteMfs(mfsName As String)
        ExecuteMfs(New UniSql().GetSqlAsObject(mfsName))
        ButtonNota.Visible = mMfs.Applicazioni.Contains("NOTA")
        SeparatoreNota.Visible = ButtonNota.Visible
    End Sub

    Public Sub ExecuteMfs(oMfs As CManifestoSql)
        Try
            Me.Cursor = Cursors.WaitCursor

            If (oMfs.GetAutorizzazioni(Utente) And EAutType.AUT_ESECUZIONE) = 0 Then
                Utente.MessaggioNotAutorizzato()
            Else
                mMfs = oMfs
            End If

            UpdateCaption()

            If mMfs Is Nothing Then
                grdResult.DataSource = Nothing
            Else
                If mMfs.Parametri IsNot Nothing Then
                    mFrame.GroupboxRicerca = Me.frmRicerca
                    mFrame.Parametri = mMfs.Parametri
                    mFrame.Inizializza()
                End If
                mFormFiltro.AppName = mMfs.Nome
                mFormFiltro.FilterFolder = mMfs.ObjPath
            End If
            EnableControls()
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub PulisciGriglia() Handles mFrame.ParametroCambiato
        grdResult.DataSource = Nothing
        grdResult.Columns.Clear()
        GridMessage("")
        lblHelp.ForeColor = Color.Blue
        EnableControls()
    End Sub

    Public Sub ExecuteSql() Handles btnRiesegui.Click
        Try
            lblHelp.ForeColor = Color.LightGray
            GridMessage("sto eseguendo ...")
            Cursor = Cursors.WaitCursor
            Windows.Forms.Application.DoEvents()

            If mFrame.GroupboxRicerca IsNot Nothing Then
                mFrame.GroupboxRicerca.Enabled = False
            End If
            If PanelStampa.Visible = True Then
                PanelStampa.Enabled = False
            End If
            grdResult.SuspendLayout()

            mFormFiltro.CancellaFiltri()

            Dim Ripetizione As Boolean = False
Esegui:
#If DEBUG Then
            'per DEBUG query in esecuzione
            Utx.Globale.Log.Info(mMfs.GetSql(False))
#End If
            Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteNonQuery(mMfs.GetSql(False), NomeTabella:="Estrazione")
            If Risposta Is Nothing Then
                Utx.Globale.Log.Info(mMfs.GetSql(False))
                Exit Try
            End If
            Dim dt As DataTable = Risposta.DataTable
            Dim col As New DataColumn("Check", System.Type.GetType("System.Boolean"))
            dt.Columns.Add(col)
            col.SetOrdinal(0)
            grdResult.DataSource = dt

            mCheckBoxHeaderCell = New DataGridViewCheckBoxHeaderCell() With {.Checked = True}
            grdResult.Columns(0).HeaderCell = mCheckBoxHeaderCell
            CheckBoxHeaderCell_CheckBoxClicked(Me, New DataGridViewCheckBoxHeaderCellEventArgs(True))
            'per visualizzare correttamente il check
            mCheckBoxHeaderCell.CheckState = CheckState.Indeterminate
            mCheckBoxHeaderCell.CheckState = CheckState.Checked

            If grdResult.RowCount = 0 Then
                grdResult.Columns.Clear()
            Else
                grdResult.AutoResizeColumns(DataGridViewAutoSizeColumnMode.DisplayedCells)

                For i As Integer = 1 To grdResult.ColumnCount - 1
                    grdResult.Columns(i).ReadOnly = True

                    With grdResult.Columns(i)
                        Select Case .ValueType.Name
                            Case "String"
                                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                            Case "DateTime"
                                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            Case "Int64", "Int32", "Int16", "Byte"
                                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            Case "Double", "Single"
                                .DefaultCellStyle.Format = "#,##0.00"
                                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                            Case Else
                                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        End Select
                    End With
                Next
                For k As Integer = 2 To grdResult.ColumnCount - 1
                    grdResult.Columns(k).SortMode = DataGridViewColumnSortMode.Programmatic
                Next
            End If

            grdResult.ResumeLayout()
            If mFrame.GroupboxRicerca IsNot Nothing Then
                mFrame.GroupboxRicerca.Enabled = True
            Else
                lblHelp.ForeColor = Color.Blue
            End If
            If PanelStampa.Visible = True Then
                PanelStampa.Enabled = True
            End If

            UpdateRowCount()

            If Ripetizione = False Then
                If mMfs.Key = "Piu3 auto" Then
                    Dim Aggiornamenti As Integer = GestioneBdaAutomatico(dt)
                    Call New Utx.NotificaRapida(Utx.FormNotifica.AltezzaNotifica.MEZZA).Visualizza(String.Format("Aggiornate {0} posizioni", Aggiornamenti))
                    If Aggiornamenti > 0 Then
                        Ripetizione = True 'ripetizione una sola volta
                        GoTo Esegui
                    End If
                End If
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            If mFrame.GroupboxRicerca IsNot Nothing Then
                mFrame.GroupboxRicerca.Enabled = True
            End If
            If PanelStampa.Visible = True Then
                PanelStampa.Enabled = True
            End If
            EnableControls()
            Cursor = Cursors.Default
            Windows.Forms.Application.DoEvents()
        End Try
    End Sub

    Private Sub grdResult_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles grdResult.ColumnHeaderMouseClick
        If e.ColumnIndex > 0 Then
            mFormFiltro.Visualizza(grdResult.Columns(e.ColumnIndex))
            RowColor()
            UpdateRowCount()
        End If
    End Sub

    Private Sub UpdateRowCount()
        mAgenzia = Utx.Globale.AgenziaRichiesta.CodiceAgenzia
        Select Case grdResult.RowCount
            Case 0 : GridMessage(String.Format("{0} - nessun elemento estratto", Utx.Globale.AgenziaRichiesta.CodiceAgenzia))
            Case 1 : GridMessage(String.Format("{0} - un elemento estratto", Utx.Globale.AgenziaRichiesta.CodiceAgenzia))
            Case Else : GridMessage(String.Format("{0} - estratti {1} elementi - (selezionati {2})",
                                                  Utx.Globale.AgenziaRichiesta.CodiceAgenzia, grdResult.RowCount, RowChecked))
        End Select
    End Sub

    Private Sub GridMessage(sMsg As String)
        lblGridMsg.Text = sMsg
    End Sub

    Private Sub UpdateCaption()
        Dim sCaption As String

        If Not mMfs Is Nothing Then
            sCaption = mMfs.DisplayNome
        Else
            sCaption = Application.ProductName
        End If

        Me.Text = sCaption
        LabelCaption.Text = sCaption
    End Sub

    Public Function gridHasItemCheck(conMessaggio As Boolean) As Boolean
        For Each row As DataGridViewRow In grdResult.Rows
            If row.Cells(0).Value = True Then
                Return True
            End If
        Next
        If conMessaggio Then
            MsgBox("Nessuna riga selezionata", vbExclamation)
        End If
        Return False
    End Function

    Private Sub btnEsci_Click(sender As System.Object, e As System.EventArgs) Handles btnEsci.Click
        Me.Close()
    End Sub

    Private Sub btnProprieta_Click(sender As System.Object, e As System.EventArgs) Handles btnProprieta.Click
        Using f As New frmProprieta()
            f.Manifesto = mMfs
            f.ShowDialog(Me)
        End Using
    End Sub

    Private Sub EsportaCsv(sender As System.Object, e As System.EventArgs) Handles btnFileCsv.Click
        Try
            If mMfs Is Nothing Then
                Exit Sub
            End If

            If Not mMfs Is Nothing Then
                If Not Utils.Utente.AutorizzatoAdEsportare(mMfs, True) Then
                    Exit Sub
                End If
            End If

            Dim NomeFile As String = GetNomefileStandard(mMfs.Nome)

            If gridHasItemCheck(True) Then
                Utx.NetFunc.Esporta2Csv(grdResult, NomeFile, Color.Khaki)
            End If

        Catch ex As Exception
            Utils.ErrorFound(Me.Name, "EsportaCsv", Err.Number, Err.Description, Err.Source)
        End Try
    End Sub

    Private Function GetNomefileStandard(Nome As String) As String
        Return IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), Nome & " (" & Date.Today.ToString("dd-MM-yyyy") & ")")
    End Function

    Private Function RowChecked() As Integer
        RowChecked = 0
        For Each row As DataGridViewRow In grdResult.Rows
            If row.Cells(0).Value = True Then
                RowChecked += 1
            End If
        Next
    End Function

    Private Sub StampaCopertina(sender As System.Object, e As System.EventArgs) Handles btnStampaCopertinaA3.Click
        Try
            If mMfs Is Nothing Then
                Exit Sub
            End If

            If Not mMfs Is Nothing Then
                If Not Utils.Utente.AutorizzatoAdEsportare(mMfs, True) Then
                    Exit Sub
                End If
            End If

            With Utils.CreaListaInvio(Utils.gridGetAsDataReader(grdResult))
                'Controllo è presente il codice fiscale
                Dim codiceFiscaleIndex As Integer = -1
                For i As Integer = 0 To .FieldCount - 1
                    If UCase(Replace(.GetName(i), " ", "")) Like "*CODICEFISCALE*" Then
                        codiceFiscaleIndex = i
                        Exit For
                    End If
                Next
                If codiceFiscaleIndex = -1 Then
                    MsgBox("Manca nell'estrazione il codice fiscale per creare la copertina.", vbExclamation)
                    Exit Sub
                End If

                Dim indice As Integer = 0
                Dim codiciFiscali As String = vbNullString
                Do While .Read()
                    If Len(codiciFiscali) > 10000 Then
                        System.Environment.SetEnvironmentVariable("UNITOOLS_CODICIFISCALI" & indice, Mid(codiciFiscali, 2))
                        codiciFiscali = ""
                        indice += 1
                    End If
                    codiciFiscali &= ";" & .GetString(codiceFiscaleIndex)
                Loop

                System.Environment.SetEnvironmentVariable("UNITOOLS_CODICIFISCALI" & indice, Mid(codiciFiscali, 2))
            End With


            Cursor = Cursors.WaitCursor
            Process.Start(IO.Path.Combine(UniSql.GetCartellaExe(), "UniCover.exe"))
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.Default
            Utils.ErrorFound(Me.Name, "StampaCopertina", Err.Number, Err.Description, Err.Source)
        End Try
    End Sub

    Private Sub btnComunica_Click(sender As Object, e As EventArgs) Handles btnComunica.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim s As String = lblGridMsg.Text
            lblGridMsg.Text = "Verifica destinatari in corso ..."
            Application.DoEvents()
            Using comunica As New UniCom.FormComunicazioni
                comunica.Destinatari = Utils.CreaListaComunica(Utils.gridGetAsDataReader(grdResult))
                lblGridMsg.Text = s
                comunica.ShowDialog(Me)
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub CaricaEstrazioniPerStampe()
        With ComboBoxEstrazioni
            .Items.Clear()
            For Each estrazione As CManifestoSql In mgrMfs.ManifestiLoad(Utente, "Stampe").Values
                If estrazione.Pacchetto = "Lettere" Then
                    .Items.Add(estrazione.Nome)
                End If
            Next
        End With
        ButtonSelezioneEtStampa.Enabled = False
    End Sub

    Private Sub ComboBoxEstrazioni_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEstrazioni.SelectedIndexChanged
        If ComboBoxEstrazioni.SelectedItem IsNot Nothing Then
            ExecuteMfs("Stampe\" & ComboBoxEstrazioni.SelectedItem.ToString)
        End If
        ButtonSelezioneEtStampa.Enabled = False
    End Sub

    Private Sub ButtonSelezioneEtStampa_Click(sender As Object, e As EventArgs) Handles ButtonSelezioneEtStampa.Click
        If RowChecked() > 0 Then
            Using f As New UniCom.FormLettere
                f.Destinatari = Utils.gridGetAsDataTable(grdResult)
                f.ShowDialog()
            End Using
        Else
            MsgBox("Nessun elemento selezionato", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
        End If
    End Sub

    Private Sub frmGrid_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.TopMost = True
        Me.TopMost = False
    End Sub

    Private Sub btnGestioneBda_Click(sender As Object, e As EventArgs) Handles btnGestioneBda.Click
        Try
            If mMfs.Applicazioni.Contains("*BDA*") = False Then
                Dim lista As String = Environment.NewLine
                For Each m As CManifestoLight In CManifestoLight.Load().Values
                    If m.Applicazioni IsNot Nothing AndAlso m.Applicazioni.Contains("*BDA*") Then
                        lista &= Environment.NewLine & "- " & m.DisplayNome
                    End If
                Next
                MsgBox("La funzione è abilitata solamente per le seguenti estrazioni: " & lista, MsgBoxStyle.Information, Title:=Utx.Globale.TitoloApp)
            ElseIf grdResult.SelectedRows.Count <> 1 Then
                MsgBox("Selezionare un solo movimento")
            Else
                Cursor = Cursors.WaitCursor

                Dim rataIntermediaIndex As Integer = -1
                Dim effettoTitoloIndex As Integer = -1
                Dim targaIndex As Integer = -1
                Dim classeRcaIndex As Integer = -1
                Dim altraCompagniaIndex As Integer = -1
                Dim letturaBDAIndex As Integer = -1
                Dim ScadenzaIndex As Integer = -1

                For i As Integer = 0 To grdResult.Columns.Count - 1
                    Dim nomecampo As String = grdResult.Columns(i).HeaderText.Replace(" ", "").ToUpper

                    If rataIntermediaIndex = -1 AndAlso nomecampo Like "*RATAINTERMEDIA*" Then
                        rataIntermediaIndex = i
                    ElseIf effettoTitoloIndex = -1 AndAlso nomecampo Like "*EFFETTOTITOLO*" Then
                        effettoTitoloIndex = i
                    ElseIf targaIndex = -1 AndAlso nomecampo Like "*TARGA*" Then
                        targaIndex = i
                    ElseIf classeRcaIndex = -1 AndAlso nomecampo Like "*CLASSERCA*" Then
                        classeRcaIndex = i
                    ElseIf altracompagniaIndex = -1 AndAlso nomecampo Like "*ALTRACOMPAGNIA*" Then
                        altraCompagniaIndex = i
                    ElseIf letturabdaIndex = -1 AndAlso nomecampo Like "*LETTURABDA*" Then
                        letturaBDAIndex = i
                    ElseIf scadenzaIndex = -1 AndAlso nomecampo Like "*SCADENZACONTRATTO*" Then
                        ScadenzaIndex = i
                    End If
                Next
                Dim targa As String = ""
                If targaIndex >= 0 Then
                    targa = grdResult.SelectedRows(0).Cells(targaIndex).Value
                End If
                If targaIndex = -1 Then
                    MsgBox("Targa non trovata")
                ElseIf targa = "" Then
                    MsgBox("Targa non valorizzata")
                Else
                    Dim RataIntermedia As String = ""
                    If rataIntermediaIndex >= 0 Then
                        RataIntermedia = Utx.FunzioniDb.NullToString(grdResult.SelectedRows(0).Cells(rataIntermediaIndex).Value)
                    End If
                    Dim classerca As String = ""
                    If classeRcaIndex >= 0 Then
                        classerca = Utx.FunzioniDb.NullToString(grdResult.SelectedRows(0).Cells(classeRcaIndex).Value)
                    End If
                    Dim effettoTitolo As String = "1/1/1900"
                    If effettoTitoloIndex >= 0 Then
                        effettoTitolo = Utx.FunzioniDb.NullToString(grdResult.SelectedRows(0).Cells(effettoTitoloIndex).Value)
                    End If

                    Dim bda As ExportLib.BancaDatiAnia.BDATarga = ExportLib.Azioni.VisualizzaBDATarga(targa,
                                                                                          effettoTitolo, RataIntermedia, classerca)
                    If (bda IsNot Nothing) AndAlso (bda.EsitoBDA = True) Then
                        If altraCompagniaIndex = -1 Then
                            MsgBox(String.Format("Targa: {1}{0}Compagnia: {2} - {3}{0}Scadenza contratto: {4:dd-MM-yyyy}",
                                                 Environment.NewLine, bda.TargaInterrogata, bda.CodiceCompagnia,
                                                 ExportLib.BancaDatiAnia.BDATarga.CompagniaAnia(bda.CodiceCompagnia), bda.ScadenzaContratto),
                                   MsgBoxStyle.Information, "Interrogazione BDA")
                        Else
                            grdResult.SelectedRows(0).Cells(altraCompagniaIndex).Value = bda.Compagnia
                        End If
                        If letturaBDAIndex >= 0 Then
                            grdResult.SelectedRows(0).Cells(letturaBDAIndex).Value = Format(bda.Aggiornato, "dd-MM-yyyy HH:mm")
                        End If
                        If ScadenzaIndex >= 0 Then
                            grdResult.SelectedRows(0).Cells(ScadenzaIndex).Value = Format(bda.ScadenzaContratto, "dd-MM-yyyy HH:mm")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Function GestioneBdaAutomatico(dt As DataTable) As Integer
        Try
            Cursor = Cursors.WaitCursor

            Dim rataIntermediaIndex As Integer = -1
            Dim effettoTitoloIndex As Integer = -1
            Dim targaIndex As Integer = -1
            Dim classeRcaIndex As Integer = -1
            Dim altraCompagniaIndex As Integer = -1
            Dim letturaBDAIndex As Integer = -1
            Dim ScadenzaContrattoIndex As Integer = -1

            For i As Integer = 0 To dt.Columns.Count - 1
                Dim nomecampo As String = grdResult.Columns(i).HeaderText.Replace(" ", "").ToUpper

                If rataIntermediaIndex = -1 AndAlso nomecampo Like "*RATAINTERMEDIA*" Then
                    rataIntermediaIndex = i
                ElseIf effettoTitoloIndex = -1 AndAlso nomecampo Like "*EFFETTOTITOLO*" Then
                    effettoTitoloIndex = i
                ElseIf targaIndex = -1 AndAlso nomecampo Like "*TARGA*" Then
                    targaIndex = i
                ElseIf classeRcaIndex = -1 AndAlso nomecampo Like "*CLASSERCA*" Then
                    classeRcaIndex = i
                ElseIf altraCompagniaIndex = -1 AndAlso nomecampo Like "*ALTRACOMPAGNIA*" Then
                    altraCompagniaIndex = i
                ElseIf letturaBDAIndex = -1 AndAlso nomecampo Like "*LETTURABDA*" Then
                    letturaBDAIndex = i
                ElseIf ScadenzaContrattoIndex = -1 AndAlso nomecampo Like "*SCADENZACONTRATTO*" Then
                    ScadenzaContrattoIndex = i
                End If
            Next

            grdResult.Columns(targaIndex).DefaultCellStyle.ForeColor = Color.Red
            grdResult.Columns(ScadenzaContrattoIndex).DefaultCellStyle.ForeColor = Color.Blue

            Return ExportLib.Azioni.InterrogaBDATarga(dt, targaIndex, letturaBDAIndex, altraCompagniaIndex, ScadenzaContrattoIndex)

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return 0
        Finally
            Cursor = Cursors.Default
        End Try
    End Function

    Private Sub ButtonNota_Click(sender As Object, e As EventArgs) Handles ButtonNota.Click
        If grdResult.CurrentRow IsNot Nothing Then
            Using f As New FormNota
                f.Agenzia = mAgenzia
                f.UsoStampa = UsoStampa
                f.Arretrato = grdResult.CurrentRow
                f.ShowDialog()

                If f.DialogResult = DialogResult.OK Then
                    Dim dt As DataTable = grdResult.DataSource
                    dt.Rows(grdResult.CurrentRow.Index).Item("Nota") = f.TestoNota
                    grdResult.CurrentRow.Cells("Nota").Value = f.TestoNota
                    grdResult.Refresh()
                End If
            End Using
        End If
    End Sub
End Class
