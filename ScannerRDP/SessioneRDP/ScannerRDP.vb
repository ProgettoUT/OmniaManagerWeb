Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO

Public Class ScannerRDP

    Private Const ChiaroScuro As Integer = 35
    Private Const DeskStato As String = "In attesa..."

    Private PathDestinazioneDoc As String = ""
    Private WithEvents DatiRdp As New RDP
    Private ScansioneCorrente As Scansione
    'Private WithEvents Timeout As MyTimeout

    Private Sub Fotocopia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Application.EnableVisualStyles()

        Twain.LicenseKeys = "7A062F0BFD060F5E784BE4E96BE26F0C"

        With Me
            .Icon = My.Resources.scan24
            .Text = "Scanner RDP"
            .Padding = New Padding(0, 3, 0, 0)
            .Size = New Size(600, 580)
            .MinimumSize = Me.Size
        End With

        ImpostaControlli()
        ImpostaOpzioniScanner()
    End Sub

    Private Sub FormMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'se il bottone fine doc è abilitato
        If btnFineDoc.Enabled Then
            If MsgBox("Attenzione: scansione in sospeso. Uscire?",
                      MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2,
                      TitoloApp) = MsgBoxResult.No Then

                e.Cancel = True
            End If
        Else
#If Not DEBUG Then
            If MsgBox("Confermate la chiusura dello scanner RDP?",
                      MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2,
                      TitoloApp) = MsgBoxResult.No Then

                e.Cancel = True
            End If
#End If
        End If
    End Sub

    Private Sub ImpostaControlli()
        Globale.Log.Info("Imposta controlli")
        TableLayoutPanelScanner.BackColor = Color.Gainsboro
        LabelChiaroScuro.BackColor = Color.Gainsboro

        With Timer1
            .Interval = 1000
            .Enabled = True
        End With

        With btnScanNuovo
            .Padding = New Padding(10, 0, 10, 0)
            .Text = "Acquisisci nuovo documento"
            .TextAlign = ContentAlignment.MiddleLeft
            .Image = My.Resources.scan24.ToBitmap
            .ImageAlign = ContentAlignment.MiddleRight
            .Enabled = False
        End With

        With LabelStato
            .BorderStyle = BorderStyle.None
            .BackColor = Color.DodgerBlue
            .ForeColor = Color.White
            .Text = DeskStato
        End With

        With btnFineDoc
            .Padding = New Padding(10)
            .Image = My.Resources.disk.ToBitmap
            .ImageAlign = ContentAlignment.MiddleRight
            .Text = "Fine documento"
            .TextAlign = ContentAlignment.MiddleLeft
            .Enabled = False
        End With

        With Twain
            .Dock = DockStyle.Fill
            .Visible = True
            .BorderStyle = Dynamsoft.DotNet.TWAIN.Enums.DWTWndBorderStyle.Single3D
        End With

        'uscita
        With btnEsci
            .Padding = New Padding(10)
            .Image = My.Resources.Esci.ToBitmap
            .ImageAlign = ContentAlignment.MiddleRight
            .Text = "Esci"
            .TextAlign = ContentAlignment.MiddleLeft
        End With

        With lbCliente
            .BorderStyle = BorderStyle.Fixed3D
            .BackColor = Color.Gainsboro
            .ForeColor = Color.Blue
            .Text = ""
        End With
        With lbPratica
            .BorderStyle = BorderStyle.Fixed3D
            .BackColor = Color.Gainsboro
            .Text = ""
        End With

        With lbInvia
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = Color.Moccasin
            .Items.Add("Trascina qui il file da copiare...")
        End With

        Dim tt As New ToolTip
        tt.IsBalloon = True
        tt.SetToolTip(btnSelezionaScanner, "Selezione scanner")
    End Sub

    Private Sub ImpostaOpzioniScanner()
        Globale.Log.Info("Imposta controlli scanner")
        'opzioni di scansione
        rbBianoNero.Checked = True

        'risoluzione
        With ComboBoxRisoluzione
            .DisplayMember = "Descrizione"

            .Items.Add(New Risoluzione(75))
            .Items.Add(New Risoluzione(100))
            .Items.Add(New Risoluzione(150))
            .Items.Add(New Risoluzione(200))
            .Items.Add(New Risoluzione(300))
            .Items.Add(New Risoluzione(400))
            .Items.Add(New Risoluzione(600))

            .SelectedIndex = 3
        End With

        'formato
        With ComboBoxFormato
            .DisplayMember = "Descrizione"

            .Items.Add(New Formati("PDF"))
            .Items.Add(New Formati("TIF"))
            .Items.Add(New Formati("PNG"))
            .Items.Add(New Formati("JPG"))
            .Items.Add(New Formati("BMP"))

            .SelectedIndex = 0
        End With

        With tbChiaroScuro
            .TickStyle = TickStyle.BottomRight
            .TickFrequency = 5
            .Minimum = 0
            .Maximum = 100
            .Value = 35
        End With

        rbBianoNero.Checked = True 'b&w
        chkDuplex.Checked = False

        InitScanner()
    End Sub

    Private Sub InitScanner()
        Try
            Globale.Log.Info("Init scanner")
            'è importante chiudere il SM perchè altrimenti non aggiorna la lista delle periferiche
            '(accendo lo scanner ma non lo vede)
            Twain.IfThrowException = True
            Try
                Twain.CloseSourceManager()
            Catch ex As Exception
                Globale.Log.Info(ex)
            End Try

            Twain.SupportedDeviceType = Dynamsoft.DotNet.TWAIN.Enums.EnumSupportedDeviceType.SDT_TWAIN

            'riempio il combo con i nomi degli scanner
            'in ComboBoxSource.Tag conservo il numero di periferiche rilevate
            ComboBoxSource.Items.Clear()

            'attivo il timeout
            'Timeout = New MyTimeout(10000) '10 secondi

            'se ci sono periferiche twain rilevate
            If Twain.SourceCount > 0 Then
                Globale.Log.Info("periferiche rilevate {0}", Twain.SourceCount)

                For i As Integer = 0 To Twain.SourceCount - 1
                    ComboBoxSource.Items.Add(Twain.SourceNameItems(i))

                    'se lo scanner è l'ultimo che era stato impostato e salvato
                    If Twain.SourceNameItems(i) = My.Settings.NomeScanner Then
                        ComboBoxSource.SelectedIndex = i 'lo seleziono
                    End If
                Next

                ComboBoxSource.Tag = ComboBoxSource.Items.Count

                'se non ci sono selezioni prendo il primo della lista
                If ComboBoxSource.SelectedIndex < 0 Then ComboBoxSource.SelectedIndex = 0
            Else
                Globale.Log.Info("Periferiche non rilevate")
                ComboBoxSource.Items.Add("Periferiche non rilevate")
                ComboBoxSource.SelectedIndex = 0
                ComboBoxSource.Tag = 0
            End If

        Catch ex As Exception
            Log.Errore(ex)
            Log.Info(Twain.ErrorString)
            'Finally
            '    Timeout = Nothing
        End Try
    End Sub

    Private Sub btnSelezionaScanner_Click(sender As System.Object, e As System.EventArgs) Handles btnSelezionaScanner.Click
        InitScanner()
        ComboBoxSource.DroppedDown = True
    End Sub

#Region "Scansione documento"
    Private Sub btnScanNuovo_Click(sender As System.Object, e As System.EventArgs) Handles btnScanNuovo.Click
        Try
            If ComboBoxSource.Tag = 0 Then
                MsgBox("Non sono state rilevate periferiche di acquisizione.", MsgBoxStyle.Exclamation, TitoloApp)
                Exit Sub
            End If

            If ScansioneCorrente Is Nothing Then
                ScansioneCorrente = New Scansione(Scansione.TipoScansione.Nuovo)

                Twain.RemoveAllImages()
            Else
                ScansioneCorrente.Stato = Scansione.StatoScansione.InCorso
            End If

            AbilitaControlliInScansione(ScansioneCorrente.Tipo, ScansioneCorrente.Stato)

            EseguiScansione()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, TitoloApp)
            InterrompiScansione()
        End Try

    End Sub

    Private Sub EseguiScansione()
        Try
            With Twain
                .SelectSourceByIndex(ComboBoxSource.SelectedIndex)

                If .OpenSource() = True Then

                    .IfThrowException = False

                    'se è stato richiesto il fronte retro
                    If chkDuplex.Checked = True Then

                        If .CapIfSupported(Dynamsoft.DotNet.TWAIN.Enums.TWCapability.CAP_DUPLEX) = True Then
                            .IfDuplexEnabled = True
                        Else
                            MsgBox("Modalità fronte/retro non supportata dal driver selezionato",
                                   MsgBoxStyle.Information, TitoloApp)
                            chkDuplex.Checked = False
                        End If
                    Else
                        .IfDuplexEnabled = False
                    End If

                    .IfThrowException = True
                    .IfShowUI = False
                    .IfDisableSourceAfterAcquire = True

                    .Resolution = ComboBoxRisoluzione.SelectedItem.Risoluzione
                    'per il fujitsu
                    .Brightness = Int(-128 + (383 * txtChiaroScuro.Text / 100)) 'valori da -128 a 255

                    'in caso di accodamento seleziono lo stesso tipo di pixeltype
                    If ScansioneCorrente.Tipo = Scansione.TipoScansione.Accoda Then

                        If .PixelType = Dynamsoft.DotNet.TWAIN.Enums.TWICapPixelType.TWPT_BW Then
                            rbBianoNero.Checked = True

                        ElseIf .PixelType = Dynamsoft.DotNet.TWAIN.Enums.TWICapPixelType.TWPT_GRAY Then
                            rbScalaGrigi.Checked = True
                        Else
                            rbColori.Checked = True
                        End If
                    End If

                    If rbBianoNero.Checked Then
                        .PixelType = Dynamsoft.DotNet.TWAIN.Enums.TWICapPixelType.TWPT_BW
                    ElseIf rbScalaGrigi.Checked Then
                        .PixelType = Dynamsoft.DotNet.TWAIN.Enums.TWICapPixelType.TWPT_GRAY
                    Else
                        .PixelType = Dynamsoft.DotNet.TWAIN.Enums.TWICapPixelType.TWPT_RGB
                    End If

                    .AcquireImage()
                Else
                    MsgBox("Comunicazione con lo scanner fallita", MsgBoxStyle.Exclamation, TitoloApp)
                    InterrompiScansione()
                End If

            End With

        Catch ex As Exception
            MsgBox(String.Format("Comunicazione con lo scanner fallita.{0}(Errore: {1})",
                                 Environment.NewLine, ex.Message), MsgBoxStyle.Exclamation, TitoloApp)
            InterrompiScansione()
        End Try
    End Sub

    Private Sub InterrompiScansione()
        On Error Resume Next
        Twain.RemoveAllImages()
        ScansioneCorrente = Nothing
        AbilitaControlliInScansione(Scansione.TipoScansione.Nuovo, Scansione.StatoScansione.Finita)
    End Sub

    Private Sub Twain_OnTransferCancelled() Handles Twain.OnTransferCancelled
        'si verifica quando non c'è carta e l'utente preme annulla
        ScansioneCorrente.Stato = Scansione.StatoScansione.Annulla
    End Sub

    Private Sub Twain_OnPostAllTransfers() Handles Twain.OnPostAllTransfers
        Try
            If ScansioneCorrente.Stato = Scansione.StatoScansione.Annulla Then
                InterrompiScansione()
            Else
                Select Case ComboBoxFormato.SelectedItem.Formato

                    Case "png", "jpg", "bmp"
                        'per i documenti a pagina singola chiudo automaticamente il doc
                        btnFineDoc_Click(Me, New EventArgs)

                    Case Else
                        'lo stato diventa di attesa per un'altra pagina
                        ScansioneCorrente.Stato = Scansione.StatoScansione.InPausa
                        AbilitaControlliInScansione(ScansioneCorrente.Tipo, ScansioneCorrente.Stato)
                End Select
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, TitoloApp)
            Log.Info(ex.Message)
        End Try
    End Sub

    Private Sub btnFineDoc_Click(sender As System.Object, e As System.EventArgs) Handles btnFineDoc.Click

        btnFineDoc.Enabled = False

        'per sicurezza ma non dovrebbe servire
        If ScansioneCorrente Is Nothing Then Exit Sub

        LabelStato.Text = "Salvataggio in corso..."
        LabelStato.Refresh()

        Dim f As Formati = ComboBoxFormato.SelectedItem

        If SalvaDocumento(Path.Combine(PathDestinazioneDoc, IDNomeFile(f)), f.Formato) = True Then

            RispostaPerHost()

            Twain.RemoveAllImages()
            Twain.CloseSource()

            ScansioneCorrente.Stato = Scansione.StatoScansione.Finita

            AbilitaControlliInScansione(ScansioneCorrente.Tipo, ScansioneCorrente.Stato)

            ScansioneCorrente = Nothing
        Else
            btnFineDoc.Enabled = True
        End If
    End Sub

    Private Function SalvaDocumento(Doc As String, Formato As String) As Boolean
        Try
            Twain.IfThrowException = True
            Select Case Formato
                Case "tif", "tiff"
                    Twain.SaveAllAsMultiPageTIFF(Doc)
                Case "pdf"
                    Twain.SaveAllAsPDF(Doc)
                Case "png"
                    Twain.SaveAsPNG(Doc, 0)
                Case "jpg"
                    Twain.SaveAsJPEG(Doc, 0)
                Case "bmp"
                    Twain.SaveAsBMP(Doc, 0)
            End Select
            Return True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, TitoloApp)
            Log.Info(ex.Message)
            Return False
        End Try
    End Function

    Private Sub AbilitaControlliInScansione(TipoScansione As Scansione.TipoScansione,
                                            StatoScansione As Scansione.StatoScansione)
        Try
            Select Case StatoScansione

                Case Scansione.StatoScansione.InCorso 'pagina in scansione

                    Twain.Enabled = False

                    'source
                    ComboBoxSource.Enabled = False
                    btnSelezionaScanner.Enabled = False
                    ComboBoxRisoluzione.Enabled = False
                    ComboBoxFormato.Enabled = False
                    rbBianoNero.Enabled = False
                    rbScalaGrigi.Enabled = False
                    rbColori.Enabled = False
                    chkDuplex.Enabled = False
                    tbChiaroScuro.Enabled = False
                    txtChiaroScuro.Enabled = False

                    btnScanNuovo.Enabled = False
                    btnFineDoc.Enabled = False
                    btnEsci.Enabled = False

                    LabelStato.Text = "Acquisizione in corso..."

                Case Scansione.StatoScansione.InPausa 'in attesa di altre pagine

                    Twain.Enabled = True

                    'source
                    ComboBoxRisoluzione.Enabled = True
                    ComboBoxFormato.Enabled = True
                    chkDuplex.Enabled = True
                    tbChiaroScuro.Enabled = True
                    txtChiaroScuro.Enabled = True

                    btnScanNuovo.Enabled = True
                    btnFineDoc.Enabled = True

                    LabelStato.Text = String.Format("In attesa della pagina {0}",
                                                    Twain.HowManyImagesInBuffer + 1)

                Case Scansione.StatoScansione.Finita

                    Twain.Enabled = True

                    'source
                    ComboBoxSource.Enabled = True
                    btnSelezionaScanner.Enabled = True
                    ComboBoxRisoluzione.Enabled = True
                    ComboBoxFormato.Enabled = True
                    rbBianoNero.Enabled = True
                    rbScalaGrigi.Enabled = True
                    rbColori.Enabled = True
                    chkDuplex.Enabled = True
                    tbChiaroScuro.Enabled = True
                    txtChiaroScuro.Enabled = True

                    btnScanNuovo.Enabled = True
                    'il bottone per l'aggiunta viene gestito nell'evento di selezione del doc nella list box
                    btnFineDoc.Enabled = False
                    btnEsci.Enabled = True

                    LabelStato.Text = DeskStato
            End Select

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, TitoloApp)
        End Try
    End Sub

#End Region

    Private Sub tbChiaroScuro_ValueChanged(sender As Object, e As System.EventArgs) Handles tbChiaroScuro.ValueChanged
        txtChiaroScuro.Text = tbChiaroScuro.Value
    End Sub

    Private Sub txtChiaroScuro_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtChiaroScuro.TextChanged
        Try
            If IsNumeric(txtChiaroScuro.Text) Then

                If txtChiaroScuro.Text >= 0 And txtChiaroScuro.Text <= 100 Then
                    tbChiaroScuro.Value = txtChiaroScuro.Text
                Else
                    txtChiaroScuro.Text = ChiaroScuro
                End If
            Else
                If txtChiaroScuro.Text.Trim = "" Then
                    tbChiaroScuro.Value = 0
                Else
                    txtChiaroScuro.Text = ChiaroScuro
                End If
            End If

            txtChiaroScuro.ForeColor = ColoreChiaroScuro(txtChiaroScuro.Text)

        Catch ex As Exception
            txtChiaroScuro.Text = 50
        End Try
    End Sub

    Private Sub btnEsci_Click(sender As System.Object, e As System.EventArgs) Handles btnEsci.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        DatiRdp.Analisi(Clipboard.GetText(TextDataFormat.Text))
    End Sub

    Private Sub RispostaPerHost()
        Clipboard.Clear()
        Clipboard.SetText("UtScanOk:")
    End Sub

    Private Sub btnDesktop_Click(sender As System.Object, e As System.EventArgs) Handles btnDesktop.Click
        Clipboard.Clear()
        Clipboard.SetText("UTSCAN: ;Desktop locale;" + My.Computer.FileSystem.SpecialDirectories.Desktop)
    End Sub

    Private Function IDNomeFile(Formato As Formati) As String
        Return Path.Combine(PathDestinazioneDoc,
                            String.Format("Doc del {0}.{1}",
                                          Format(Now, "dd-MM-yyyy HH.mm.ss"),
                                          Formato.Formato))
    End Function

    Private Function IDNomeFile(NomeFile As String)
        NomeFile = Path.GetFileName(NomeFile)
        NomeFile = AggiungiProtocollo(NomeFile)

        Return Path.Combine(PathDestinazioneDoc, NomeFile)
    End Function

    Public Function AggiungiProtocollo(NomeFile As String) As String
        Try
            Dim Protocollo As String
            Protocollo = Microsoft.VisualBasic.Right(Path.GetFileNameWithoutExtension(NomeFile), 19)
            'sostituisco i punti con i :
            Protocollo = Protocollo.Replace(".", ":")

            'se c'era lascio il nome invariato
            If IsDate(Protocollo) Then
                Return NomeFile
            Else
                Return Path.GetFileNameWithoutExtension(NomeFile) +
                       " del " + Format(Now, "dd-MM-yyyy HH.mm.ss") +
                       Path.GetExtension(NomeFile)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return NomeFile
        End Try
    End Function

#Region "Drag & drop"

    Private Sub lbInvia_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles lbInvia.DragDrop

        If PathDestinazioneDoc.Trim.Length = 0 Then
            MsgBox("Impostare prima la cartella di destinazione", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Cursor.Current = Cursors.WaitCursor

        Dim FileOrigine As String = e.Data.GetData(DataFormats.FileDrop, True)(0)
        Dim FileDest As String = IDNomeFile(FileOrigine)

        If File.Exists(FileDest) Then

            If MsgBox("Il file già esiste: sovrascrivere?",
                      MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Copia file") = MsgBoxResult.Yes Then

                lbInvia.Items.Add("copia in corso...")
                File.Copy(FileOrigine, FileDest, True)
                lbInvia.Items.Add(Path.GetFileName(FileOrigine) + ": copiato")
            End If
        Else
            lbInvia.Items.Add("copia in corso...")
            File.Copy(FileOrigine, FileDest)
            lbInvia.Items.Add(Path.GetFileName(FileOrigine) + ": copiato")
        End If

        RispostaPerHost()

        Cursor.Current = Cursors.Default

        lbInvia.SelectedIndex = lbInvia.Items.Count - 1
        lbInvia.BackColor = Color.Moccasin
    End Sub

    Private Sub lbInvia_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles lbInvia.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            lbInvia.Items.Add("Ora lascialo qui...")
            e.Effect = DragDropEffects.Copy
            lbInvia.BackColor = Color.PaleGreen
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub lbInvia_DragLeave(sender As Object, e As System.EventArgs) Handles lbInvia.DragLeave
        lbInvia.BackColor = Color.Moccasin
    End Sub

#End Region

    Private Sub ScannerRDP_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        AddHandler DatiRdp.ChiamataRDP, AddressOf ChiamataRDP
    End Sub

    Private Sub ChiamataRDP()
        Try
            lbCliente.Text = DatiRdp.Cliente
            lbPratica.Text = DatiRdp.Pratica
            PathDestinazioneDoc = DatiRdp.PathDestinazioneDoc

            btnScanNuovo.Enabled = Directory.Exists(DatiRdp.PathDestinazioneDoc)

            'avviso per l'utente. in genere M: non è connesso
            If btnScanNuovo.Enabled = False Then
                MsgBox("Il percorso per il salvataggio dei dati non è disponibile. Controllare l'unità/percorso.", MsgBoxStyle.Exclamation)
                btnDesktop.PerformClick()
            End If

            Globale.Log.Info(String.Format("Cliente: {0} - Path: {1}", DatiRdp.Cliente, DatiRdp.PathDestinazioneDoc))

            lbInvia.Items.Clear()
            lbInvia.Items.Add("Trascina qui il file da copiare...")

            Me.WindowState = FormWindowState.Normal
            Me.TopMost = True
            Me.TopMost = False

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonCartellaUtente_Click(sender As Object, e As EventArgs) Handles ButtonCartellaUtente.Click
        If String.IsNullOrEmpty(My.Settings.CartellaUtente) Then
            ButtonSelezionaCartellaUtente.PerformClick()
        Else
            Clipboard.Clear()
            Clipboard.SetText("UTSCAN: ;Cartella utente;" + My.Settings.CartellaUtente)
        End If
    End Sub

    Private Sub ButtonSelezionaCartellaUtente_Click(sender As Object, e As EventArgs) Handles ButtonSelezionaCartellaUtente.Click
        Try
            Dim d As New FolderBrowserDialog

            d.SelectedPath = My.Settings.CartellaUtente
            d.ShowDialog()

            If d.SelectedPath.Length > 0 Then
                My.Settings.CartellaUtente = d.SelectedPath
                My.Settings.Save()
                Clipboard.Clear()
                Clipboard.SetText("UTSCAN: ;Cartella utente;" + My.Settings.CartellaUtente)
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub
End Class