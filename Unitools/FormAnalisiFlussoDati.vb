Imports System.IO

Public Class FormAnalisiFlussoDati

    Friend WithEvents FormFiltro As New Utx.FormGestioneFiltro(1000)

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.Size = New Size(Utx.InfoSistema.Desktop.Larghezza * 0.7, Utx.InfoSistema.Desktop.Altezza * 0.7)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Font = Utx.AppFont.Normal
        Me.Icon = Risorse.Immagini.Icon("unitools")
        Me.Text = "Analisi flusso dati"

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        On Error Resume Next

        CheckBox3Mesi.Checked = True

        With dgvAnalisi
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False
            .AllowUserToOrderColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
        Utx.NetFunc.DoppioBuffer(dgvAnalisi)
    End Sub

    Private Sub FormAnalisiFlussoDati_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LabelStato.Text = "In attesa di una scelta..."
    End Sub

    Private Sub LeggiDati()
        Try
            Cursor = Cursors.WaitCursor

            dgvAnalisi.DataSource = Nothing
            dgvAnalisi.Refresh()

            Dim Query As String
            If CheckBox3Mesi.Checked Then
                Query = $"SELECT A.*,B.Ambito,B.Descrizione 
                    FROM arp002_file AS A 
                    LEFT JOIN MA00000.dbo.TipoRecord AS B ON CAST(A.CodTipoRecord AS int) = B.TipoRecord 
                    WHERE RIGHT(TRIM(A.Nome),4) <> '.zip' AND DataImportazione >= '{Today.AddMonths(-3):dd/MM/yyyy}' 
                    ORDER BY DataImportazione DESC,TipoRecord"
            Else
                Query = "SELECT A.*,B.Ambito,B.Descrizione 
                    FROM arp002_file AS A 
                    LEFT JOIN MA00000.dbo.TipoRecord AS B ON CAST(A.CodTipoRecord AS int) = B.TipoRecord 
                    WHERE RIGHT(TRIM(A.Nome),4) <> '.zip' 
                    ORDER BY DataImportazione DESC,TipoRecord"
            End If
            dgvAnalisi.DataSource = Utx.WsCommand.ExecuteNonQueryMA({Query}).DataSet.Tables(0)
            FormattaColonne()

            LabelStato.Text = $"Agenzia: {Utx.Globale.AgenziaRichiesta.CodiceAgenzia} - Record totali: {dgvAnalisi.Rows.Count}"

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormattaColonne()
        On Error Resume Next
        With dgvAnalisi
            .SuspendLayout()

            With .Columns("nome")
                .HeaderText = "Nome file"
            End With
            With .Columns("codtiporecord")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = Color.PaleGreen
                .HeaderText = "Tipo record"
            End With
            With .Columns("dataestrazione")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Data estrazione"
            End With
            With .Columns("datacreazione")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Data creazione"
            End With
            With .Columns("dataimportazione")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = Color.LightCyan
                .HeaderText = "Data importazione"
            End With
            With .Columns("codtipofile")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Codice tipo file"
            End With
            With .Columns("numerorecords")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = Color.Gold
                .HeaderText = "Records"
            End With
            With .Columns("recordsimportati")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Records importati"
            End With
            With .Columns("recordsscartati")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Records scartati"
            End With

            .AutoResizeColumns()

            For Each col As DataGridViewColumn In .Columns
                col.SortMode = DataGridViewColumnSortMode.Programmatic
            Next

            .ResumeLayout()
        End With
    End Sub

    Private Sub dgvAnalisi_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvAnalisi.ColumnHeaderMouseClick
        VisualizzaFiltro(e.ColumnIndex)
    End Sub

    Public Sub VisualizzaFiltro(IndiceColonna As Integer, Optional Centra As Boolean = False)
        Try
            If (dgvAnalisi.DataSource IsNot Nothing) Then
                'cartella per salvataggio filtro
                With FormFiltro
                    .FilterFolder = Utx.Globale.Paths.CartellaSettingRete
                    .TabVisibili(True, False)

                    'visualizzo la finestra del filtro
                    .Visualizza(dgvAnalisi.Columns(IndiceColonna), Centra)

                    LabelStato.Text = $"Agenzia: {Utx.Globale.AgenziaRichiesta.CodiceAgenzia} - Record selezionati: {dgvAnalisi.Rows.Count}"
                End With
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonFileServer_Click(sender As Object, e As EventArgs) Handles ButtonFileServer.Click
        Try
            Cursor = Cursors.WaitCursor
            With dgvAnalisi
                .DataSource = Nothing
                .Refresh()

                'la vista mi serve per ordinare per data
                Dim Vista As New DataView(Utx.Direzione.GetFilesMAdalServerDiDirezione) With {.Sort = "Data DESC"}
                .DataSource = Vista

                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                .AutoResizeColumns()
            End With
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ButtonFileImportati_Click(sender As Object, e As EventArgs) Handles ButtonFileImportati.Click
        LeggiDati()
    End Sub

    Private Sub ButtonDownload_Click(sender As Object, e As EventArgs) Handles ButtonDownload.Click
        If MsgBox("Scaricare tutti i file mancanti?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then
            DownloadMAMancanti()
        Else
            DownloadSingoloMA()
        End If
    End Sub

    Private Sub dgvAnalisi_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAnalisi.CellContentClick
        Try
            If e.RowIndex >= 0 Then
                Dim FileMA As String = Path.Combine(Utx.Globale.Paths.CartellaArchivioDati,
                                                    dgvAnalisi.Rows(e.RowIndex).Cells(0).Value, "OMNIA\FileRicevuti",
                                                    dgvAnalisi.Rows(e.RowIndex).Cells(2).Value)
                If File.Exists(FileMA) Then
                    Dim fi As New FileInfo(FileMA)
                    LabelStato.Text = $"Download del {fi.CreationTime}"
                End If
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonCasellaK_Click(sender As Object, e As EventArgs) Handles ButtonCasellaK.Click
        Dim tt As New Threading.Thread(AddressOf RecuperoCasellaK)
        tt.Start()

        Me.Close()
    End Sub

    Private Sub RecuperoCasellaK()
        Dim Notifica As New Utx.FormNotifica
        Dim Progressivo As Integer = 0

        Try
            Dim Agenzia As String = InputBox("Codice agenzia (5 caratteri)", "Recupero da K", "00000")
            If (IsNumeric(Agenzia) = False) OrElse (Val(Agenzia) = 0) OrElse (Agenzia.Length <> 5) Then
                Exit Try
            End If

            Dim Inizio As String = InputBox("A partire dal", "Recupero da K", Nothing)
            Dim Fine As String = InputBox("...e fino al", "Recupero da K", Nothing)
            If (IsDate(Inizio) = False) OrElse (IsDate(Fine) = False) Then
                Exit Try
            End If

            With Notifica
                .Stile = Utx.FormNotifica.Style.BIANCO_ROSSO
                .AnnullaOperazione = True
                .Show()
                .Messaggio = "..."
            End With
            Application.DoEvents()

            Utx.Globale.Log.Info("CopiaFileDiscoK: inizio")
            Dim CartellaK As String = "K:\Casella\download"

            If IO.Directory.Exists(CartellaK) Then
                Dim CartellaM As String = IO.Path.Combine(Utx.Globale.Paths.CartellaArchivioDati, Agenzia, "OMNIA", "FileRicevuti")
                IO.Directory.CreateDirectory(CartellaM)

                Dim ModelloK As String = $"MA1{Agenzia}??????.???"

                For Each MA As String In IO.Directory.GetFiles(CartellaK, ModelloK)
                    Dim DataFile As New DateTime(Path.GetFileName(MA).Substring(8, 2) + 2000,
                                                 Path.GetFileName(MA).Substring(10, 2),
                                                 Path.GetFileName(MA).Substring(12, 2))

                    If DataFile >= Inizio AndAlso DataFile <= Fine Then
                        Dim NomeFile As String = IO.Path.GetFileName(MA)
                        Dim NomeZip As String = NomeFile.Replace(".", "") & ".zip"
                        Dim FileZip As String = IO.Path.Combine(Utx.Globale.Paths.CartellaArchivioDati, Agenzia, "OMNIA", "FileRicevuti", NomeZip)

                        'se il file non esiste già
                        If IO.File.Exists(FileZip) = False Then
                            'zippo e copio il file
                            Utx.LibreriaZip.SevenZip.ZipFile(MA, FileZip)
                            Progressivo += 1
                            'notifiche
                            Notifica.Messaggio = $"Recuperato il file {NomeFile} ({Progressivo})"
                            Utx.Globale.Log.Info($"Recuperato il file {NomeFile} ({Progressivo})")
                            Application.DoEvents()

                            If Notifica.RichiestaAnnullamento = True Then
                                Utx.Globale.Log.Info("Recopero MA annullato dall'utente")
                                Exit For
                            End If
                        End If
                    End If
                Next
            End If
            MsgBox("Recupero file dalla casella download completato", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
        Catch ex As Exception
            Utx.Globale.Log.Info(ex.Message)
        Finally
            Utx.Globale.Log.Info("CopiaFileDiscoK: fine")
            Notifica.Messaggio = $"Recupero di {Progressivo} file completato"
            Notifica.Chiudi()
        End Try
    End Sub

    Public Sub DownloadSingoloMA()
        Try
            Cursor = Cursors.WaitCursor

            Dim Figlia As New Utx.AgenziaFigliaOmnia(Utx.Globale.AgenziaRichiesta.CodiceAgenzia)

            If Directory.Exists(Figlia.Cartelle.ArchivioFileOmnia) Then
                Dim NomeFile As String = dgvAnalisi.CurrentRow.Cells("nome").Value

                If File.Exists(NomeFile) = False Then
                    'scarico il file
                    Dim Esito As Boolean = UniFeed.DownloadHttp(NomeFile, Figlia.Cartelle.ArchivioFileOmnia)
                    'visualizzo notifica in caso di errore
                    If Esito = False Then
                        MsgBox($"Download del file {NomeFile} non riuscito", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                    End If
                End If
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub DownloadMAMancanti()
        Try
            Cursor = Cursors.WaitCursor

            Dim Figlia As New Utx.AgenziaFigliaOmnia(Utx.Globale.AgenziaRichiesta.CodiceAgenzia)

            Dim dt = Utx.Direzione.GetFilesMAdalServerDiDirezione
            Directory.CreateDirectory(Figlia.Cartelle.ArchivioFileOmnia)

            Dim Progressivo As Integer = 0

            For Each row In dt.Rows
                Dim NomeFile As String = row("nome")

                If File.Exists(Path.Combine(Figlia.Cartelle.ArchivioFileOmnia, NomeFile)) = False Then
                    'scarico il file
                    Dim Esito As Boolean = UniFeed.DownloadHttp(NomeFile, Figlia.Cartelle.ArchivioFileOmnia)
                    'visualizzo notifica in caso di errore
                    If Esito = True Then
                        Progressivo += 1
                    Else
                        MsgBox($"Download del file {NomeFile} non riuscito", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                    End If
                End If
            Next

            MsgBox($"Scaricati dal server Unipolsai {Progressivo} file MA mancanti", MsgBoxStyle.Information, Utx.Globale.TitoloApp)

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
End Class