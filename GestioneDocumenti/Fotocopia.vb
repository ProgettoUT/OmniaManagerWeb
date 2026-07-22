Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO

Public Class Fotocopia

    Private Const ChiaroScuro As Integer = 35
    Private Const DeskStato As String = "In attesa..."

    Private Log As New Utx.ApplicationLog("Fotocopia.log")
    Private ScansioneCorrente As Scansione
    Private WithEvents UtScanners As Scanners = Globale.UtScanners

    Sub New()
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.MinimumSize = New Size(600, 500)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Padding = New Padding(3)
        Me.Font = Utx.AppFont.Normal
        Me.Icon = Risorse.Immagini.Icon("scandoc")
        Me.Text = "Scanner " & Utx.Globale.TitoloApp

        ImpostaControlli()
        ImpostaOpzioniScanner()
    End Sub

    Private Sub Fotocopia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Twain.LicenseKeys = Utx.Licenze.DynamicDotNetTwain_5_2_508_0
    End Sub

    Private Sub FormMain_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'blocco la chiusura se il bottone fine doc è abilitato
        e.Cancel = btnFineDoc.Enabled

        If e.Cancel Then
            MsgBox("Completare la scansione in sospeso.", vbInformation, Utx.Globale.TitoloApp)
        End If

        UtScanners.SalvaPredefinito()
    End Sub

    Private Sub Fotocopia_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Twain.Dispose()
    End Sub

    Private Sub ImpostaControlli()
        TableLayoutPanelScanner.BackColor = Colori.BcOpzioniScanner
        LabelChiaroScuro.BackColor = Colori.BcOpzioniScanner

        ComboBoxSource.DisplayMember = "Name"

        With btnSelezionaScanner
            .BackColor = SystemColors.Control
            .Margin = New Padding(1)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .FlatAppearance.MouseOverBackColor = Utx.AppColor.VerdeAcido
            .Image = Risorse.Immagini.Bitmap("aggiorna")
            .ImageAlign = ContentAlignment.MiddleCenter
            .Text = ""
        End With
        With btnScanNuovo
            .BackColor = SystemColors.Control
            .Margin = New Padding(1)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Padding = New Padding(10, 0, 10, 0)
            .Text = "Acquisisci nuovo documento"
            .TextAlign = ContentAlignment.MiddleLeft
            .Image = Risorse.Immagini.Bitmap("scandoc")
            .ImageAlign = ContentAlignment.MiddleRight
        End With
        With LabelStato
            .Margin = New Padding(1)
            .FlatStyle = FlatStyle.Flat
            .BorderStyle = BorderStyle.None
            .BackColor = Colori.BcLabelStato
            .ForeColor = Colori.FcLabelStato
            .Text = DeskStato
        End With
        With btnFineDoc
            .BackColor = SystemColors.Control
            .Margin = New Padding(1)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Padding = New Padding(10)
            .Image = Risorse.Immagini.Bitmap("disk")
            .ImageAlign = ContentAlignment.MiddleRight
            .Text = "Fine documento"
            .TextAlign = ContentAlignment.MiddleLeft
            .Enabled = False
        End With
        With btnSalva
            .BackColor = SystemColors.Control
            .Margin = New Padding(1)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Salva"
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With btnStampa
            .BackColor = SystemColors.Control
            .Margin = New Padding(1)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Stampa"
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        'uscita
        With btnEsci
            .BackColor = SystemColors.Control
            .Margin = New Padding(1)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Orange
            .Padding = New Padding(10, 0, 10, 0)
            .Image = Risorse.Immagini.Bitmap("esci")
            .ImageAlign = ContentAlignment.MiddleRight
            .Text = "Esci"
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        LinkLabelPDF.Links.Add(0, 100, "https://tools.pdf24.org/it/")

        With Twain
            .Dock = DockStyle.Fill
            .Visible = True
            .BorderStyle = Dynamsoft.DotNet.TWAIN.Enums.DWTWndBorderStyle.Single3D
        End With

        Dim tt As New ToolTip
        tt.IsBalloon = True
        tt.SetToolTip(btnSelezionaScanner, "Rileva scanner")
    End Sub

    Private Sub ImpostaOpzioniScanner()
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
            If Globale.UtScanners.Ready Then

                ComboBoxSource.Items.Clear()

                If Globale.UtScanners.ScannerDisponibili > 0 Then
                    'riempio il combo con i nomi degli scanner
                    For Each scanner As Scanner In Globale.UtScanners.ListaScanner
                        ComboBoxSource.Items.Add(scanner)
                    Next
                    'seleziono lo scanner predefinito
                    If Globale.UtScanners.ScannerSelezionato IsNot Nothing Then
                        ComboBoxSource.SelectedIndex = Globale.UtScanners.ScannerSelezionato.Index
                    Else
                        ComboBoxSource.SelectedIndex = 0
                    End If
                Else
                    ComboBoxSource.Items.Add(New Scanner(0, Scanners.NO_SCANNER))
                    ComboBoxSource.SelectedIndex = 0
                End If
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Globale.Log.Info(Twain.ErrorString)
        End Try

        ComboBoxSource.Refresh()
        ComboBoxFormato.Refresh()
        ComboBoxRisoluzione.Refresh()

        'controlla se è necessario usare lo scanner RDP
        UsaScannerRDP()
    End Sub

    Private Sub UsaScannerRDP()
        If SessioneRDP() AndAlso UtScanners.ScannerDisponibili = 0 Then
            Invia2RDP()
        End If
    End Sub

    Private Sub btnSelezionaScanner_Click(sender As System.Object, e As System.EventArgs) Handles btnSelezionaScanner.Click
        Globale.UtScanners.Init(True)
    End Sub

#Region "Scansione documento"
    Private Sub btnScanNuovo_Click(sender As System.Object, e As System.EventArgs) Handles btnScanNuovo.Click
        Try
            If UtScanners.ScannerDisponibili = 0 Then
                MsgBox("Non sono state rilevate periferiche di acquisizione.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
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
            Globale.Log.Errore(ex)
            InterrompiScansione()
        End Try
    End Sub

    Private Sub EseguiScansione()
        Try
            With Twain
                .IfThrowException = True

                .SelectSourceByIndex(ComboBoxSource.SelectedIndex)
                .OpenSource()

                .IfShowUI = False
                .IfDisableSourceAfterAcquire = True

                'se il f/r è supportato. il controllo è necessario perchè se non supportato il tentativo
                'di assegnazione di un qualsiasi valore genera un errore
                If UtScanners.ScannerSelezionato.Duplex = True Then
                    .IfDuplexEnabled = chkDuplex.Checked
                End If

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
            End With

        Catch ex As Exception
            Globale.Log.Info(String.Format("Errore {0}: {1}", Twain.ErrorCode, Twain.ErrorString))

            MsgBox(String.Format("Comunicazione con lo scanner fallita.{0}(Errore {1}: {2})",
                                 Environment.NewLine, Twain.ErrorCode, Twain.ErrorString),
                             MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)

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
            Globale.Log.Errore(ex)
            Globale.Log.Info(ex.Message)
        End Try
    End Sub

    Private Sub btnFineDoc_Click(sender As System.Object, e As System.EventArgs) Handles btnFineDoc.Click
        btnFineDoc.Enabled = False

        'per sicurezza ma non dovrebbe servire
        If ScansioneCorrente Is Nothing Then Exit Sub

        LabelStato.Text = "Salvataggio in corso..."
        LabelStato.Refresh()

        'è inutile. per sicurezza
        Twain.CloseSource()

        ScansioneCorrente.Stato = Scansione.StatoScansione.Finita

        AbilitaControlliInScansione(ScansioneCorrente.Tipo, ScansioneCorrente.Stato)

        ScansioneCorrente = Nothing

    End Sub

    Private Sub SalvaDocumento(Doc As String, Formato As String)
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

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Globale.Log.Info(ex.Message)
        End Try
    End Sub

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
                    btnSalva.Enabled = False
                    btnStampa.Enabled = False
                    btnEsci.Enabled = False

                    LabelStato.Text = "Acquisizione in corso..."

                Case Scansione.StatoScansione.InPausa 'in attesa di altre pagine

                    Twain.Enabled = True

                    'source
                    ComboBoxRisoluzione.Enabled = True
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
                    btnSalva.Enabled = True
                    btnStampa.Enabled = True
                    btnEsci.Enabled = True

                    LabelStato.Text = DeskStato
            End Select

        Catch ex As Exception
            Globale.Log.Errore(ex)
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

    Private Sub btnStampa_Click(sender As System.Object, e As System.EventArgs) Handles btnStampa.Click
        Twain.IfThrowException = False
        Twain.IfShowPrintUI = True
        Twain.Print()
    End Sub

    Private Sub btnSalva_Click(sender As System.Object, e As System.EventArgs) Handles btnSalva.Click
        Try
            Dim cd As New SaveFileDialog
            Dim f As Formati = ComboBoxFormato.SelectedItem

            With cd
                .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                .Filter = String.Format("File {0}|*.{1}", f.Formato, f.Formato)
                .AddExtension = True
                .FileName = "Fotocopia"
            End With

            If cd.ShowDialog = Windows.Forms.DialogResult.OK Then

                If cd.FileName.Trim.Length > 0 Then
                    SalvaDocumento(cd.FileName, f.Formato)
                End If
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

    End Sub

    Private Sub Invia2RDP()
        Try
            Clipboard.Clear()

            'pare che possa evitare l'errore 521
            Threading.Thread.Sleep(100)

            Clipboard.SetText(String.Format("UtScan:{0};{1};{2}",
                                            "Desktop remoto",
                                            "Desktop",
                                            My.Computer.FileSystem.SpecialDirectories.Desktop))

        Catch cb As System.Runtime.InteropServices.ExternalException
            MsgBox("Impossibile accedere ora agli appunti. Riprovate.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

    End Sub

    Private Sub ComboBoxSource_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxSource.SelectedIndexChanged
        Try
            If UtScanners.ScannerDisponibili > 0 Then
                'salvo ultimo scanner selezionato
                UtScanners.ScannerSelezionato = ComboBoxSource.SelectedItem

                If Globale.UtScanners.ScannerSelezionato.Duplex = True Then
                    chkDuplex.Text = "Fronte/Retro"
                    chkDuplex.Enabled = True
                    'lo stato non lo cambio
                    chkDuplex.Tag = True
                Else
                    chkDuplex.Text = "Fronte/Retro non supportato"
                    chkDuplex.Enabled = False
                    chkDuplex.Checked = False
                    chkDuplex.Tag = False
                End If
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)

            chkDuplex.Text = "Fronte/Retro non supportato"
            chkDuplex.Checked = False
            chkDuplex.Enabled = False
            chkDuplex.Tag = False
        End Try
    End Sub

    Private Sub UtScanner_InizializzazioneCompletata(Ready As Boolean) Handles UtScanners.InizializzazioneCompletata
        On Error Resume Next
        CheckForIllegalCrossThreadCalls = False
        InitScanner()
        ComboBoxSource.DroppedDown = True
    End Sub

    Private Sub ComboBoxSource_DropDownClosed(sender As Object, e As EventArgs) Handles ComboBoxSource.DropDownClosed
        ComboBoxSource.Refresh()
    End Sub

    Private Sub LabelColore_Paint(sender As Object, e As PaintEventArgs) Handles LabelColore.Paint
        Dim linGrBrush As New Drawing2D.LinearGradientBrush(e.ClipRectangle, Color.Yellow, Color.HotPink, Drawing2D.LinearGradientMode.Horizontal)
        Dim pen As New Pen(linGrBrush)
        e.Graphics.FillRectangle(linGrBrush, e.ClipRectangle)
    End Sub

    Private Sub LabelGrigi_Paint(sender As Object, e As PaintEventArgs) Handles LabelGrigi.Paint
        Dim linGrBrush As New Drawing2D.LinearGradientBrush(e.ClipRectangle, Color.White, Color.DimGray, Drawing2D.LinearGradientMode.Horizontal)
        Dim pen As New Pen(linGrBrush)
        e.Graphics.FillRectangle(linGrBrush, e.ClipRectangle)
    End Sub

    Private Sub LinkLabelPDF_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelPDF.LinkClicked
        Process.Start(e.Link.LinkData.ToString())
    End Sub
End Class