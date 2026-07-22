Imports System.IO

Public Class frmScanner

    Friend Giorno As Date
    Friend FileAssegni As String

    Private Dpi() As Integer = {75, 100, 150, 200, 300, 400, 600}

    Private Sub frmScanner_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.scan16

        With btnScan
            .Image = My.Resources.scan.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
            .TextAlign = ContentAlignment.MiddleRight
            .Padding = New Padding(10, 0, 10, 0)
        End With
        With txtPeriferica
            .ReadOnly = True
            .BackColor = Color.Yellow
        End With

        'tipo scansione
        With cboTipoScans
            .DropDownStyle = ComboBoxStyle.DropDownList

            .Items.Add("Scansione in bianco e nero")
            .Items.Add("Scansione in scala di grigi")
            .Items.Add("Scansione a colori")

            .SelectedIndex = 1
        End With

        'risoluzioni consentite
        With cboRisoluzione
            .DropDownStyle = ComboBoxStyle.DropDownList

            For Each r As Int16 In Dpi
                .Items.Add("Risoluzione " & r.ToString & " (dpi)")
            Next

            .SelectedIndex = 3
        End With

        chkDuplex.Checked = True
        chkCrop.Checked = True
        With tbChiaroScuro
            .SmallChange = 1
            .LargeChange = 5
            .TickStyle = TickStyle.BottomRight
            .TickFrequency = 5
            .Minimum = 0
            .Maximum = 100
            .Value = 50
        End With

        With txtChiaroScuro
            .TextAlign = HorizontalAlignment.Center
            .BackColor = Color.Beige
        End With

        lbStato.Text = ""

        'esiste un profilo salvato
        If My.Settings.Impo Then
            With My.Settings
                cboTipoScans.SelectedIndex = .TipoScan
                cboRisoluzione.SelectedIndex = .Risoluzione
                chkDuplex.Checked = .Duplex
                chkCrop.Checked = .Crop
                tbChiaroScuro.Value = .ChiaroScuro
            End With
        Else 'impostazioni di default
            With My.Settings
                cboTipoScans.SelectedIndex = 2
                cboRisoluzione.SelectedIndex = 3
                chkDuplex.Checked = False
                chkCrop.Checked = True
                tbChiaroScuro.Value = 20
            End With
        End If
    End Sub

    Private Sub frmScanner_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Cursor.Current = Cursors.WaitCursor

        txtPeriferica.Text = "Rilevazione periferica..."
        Application.DoEvents()

        txtPeriferica.Text = EZTwain.DefaultSourceName().Trim

        If txtPeriferica.Text = String.Empty Then txtPeriferica.Text = "Periferica non rilevata..."

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnSalvaImpo_Click(sender As System.Object, e As System.EventArgs) Handles btnSalvaImpo.Click
        With My.Settings
            .Impo = True
            .TipoScan = cboTipoScans.SelectedIndex
            .Risoluzione = cboRisoluzione.SelectedIndex
            .Duplex = chkDuplex.Checked
            .Crop = chkCrop.Checked
            .ChiaroScuro = tbChiaroScuro.Value
            .Save()
        End With
    End Sub

    Private Sub btnSelezionaPeriferica_Click(sender As System.Object, e As System.EventArgs) Handles btnSelezionaPeriferica.Click
        If EZTwain.SelectImageSource(0) = 0 Then
            txtPeriferica.Text = "Errore nella selezione dello scanner."
        Else
            txtPeriferica.Text = EZTwain.DefaultSourceName().Trim
        End If
    End Sub

    Private Sub tbChiaroScuro_ValueChanged(sender As Object, e As System.EventArgs) Handles tbChiaroScuro.ValueChanged
        txtChiaroScuro.Text = tbChiaroScuro.Value
    End Sub

    Private Sub btnScan_Click(sender As System.Object, e As System.EventArgs) Handles btnScan.Click
        Cursor.Current = Cursors.WaitCursor
        btnScan.Enabled = False

        lbStato.Text = "Acquisizione documento in corso..."
        Application.DoEvents()

        EZScanPagina()

        lbStato.Text = ""

        btnScan.Enabled = True
        Cursor.Current = Cursors.Default
    End Sub

    Private Function EZScanPagina() As Boolean

#If DEBUG Then
        'log
        EZTwain.LogFile(1)
        EZTwain.SetLogFolder("U:\Unitools\Temp")
#End If

        On Error GoTo Errore

        EZTwain.ClearError()

        If EZTwain.DefaultSourceName().Trim = String.Empty Then
            If EZTwain.SelectImageSource(0) = 0 Then
                MsgBox("Errore nella selezione dello scanner.", MsgBoxStyle.Exclamation)
                Exit Function
            End If
        End If

        'interfaccia
        EZTwain.SetHideUI(1)
        EZTwain.SetIndicators(0)

        'apre lo scanner
        If EZTwain.OpenDefaultSource() = False Then GoTo Errore

        EZTwain.SetFileAppendFlag(True)
        EZTwain.SelectFeeder(0)
        EZTwain.SetPixelType(cboTipoScans.SelectedIndex)
        EZTwain.SetResolution(Dpi(cboRisoluzione.SelectedIndex))
        EZTwain.SetPaperSize(EZTwain.PAPER_A4LETTER)
        EZTwain.SetXferCount(-1)
        'EZTwain.SetTiffCompression(EZTwain.TWPT_BW, EZTwain.TIFF_COMP_CCITTFAX4)

        If cboTipoScans.SelectedIndex = 0 Then 'bianco e nero
            EZTwain.SetThreshold(txtChiaroScuro.Text * 256 / 100)
        Else
            EZTwain.SetBrightness(txtChiaroScuro.Text * 50 - 1000)
        End If

        'imposta duplex se selezionata l'opzione
        EZTwain.EnableDuplex(IIf(chkDuplex.Checked, 1, 0))

        EZTwain.SetMultiTransfer(1)

        Dim Esito As Int16 = EZTwain.BeginMultipageFile(FileAssegni)
        If Esito = 0 Then
            Do
                'If you can't use Me.hwnd, pass 0:
                Dim hdib As Long = EZTwain.Acquire(0)

                If hdib = 0 Then Exit Do

                '<your image processing here>
                'aggiusta il contrasto in automatico
                EZTwain.DIB_AutoContrast(hdib)

                If chkCrop.Checked Then
                    'taglia i bordi in automatico
                    EZTwain.DibWritePage(EZTwain.DIB_AutoCrop(hdib, 0))
                Else
                    EZTwain.DibWritePage(hdib)
                End If

                'rilascia l'handle in memoria
                Call EZTwain.DIB_Free(hdib)

                If EZTwain.State < 6 Then Exit Do
            Loop
        End If
        EZTwain.EndMultipageFile()

        'chiudi scanner
        EZTwain.CloseSource()

        If EZTwain.LastErrorCode() = 0 Then
            EZScanPagina = True
        ElseIf EZTwain.LastErrorCode() = 19 Then 'errore 19 (user cancel)
            '???
        Else
            EZScanPagina = False
        End If

        Exit Function

Errore:
        Select Case Err.Number
            Case 6
                EZTwain.EndMultipageFile()
                EZTwain.UnloadSourceManager()

            Case 380, 381
                MsgBox("Attenzione: si è verificato un errore che Unitools ha provato a correggere automaticamente." & vbLf & _
                       "Provate nuovamente a scansire il documento.", vbExclamation)
        End Select

        EZTwain.CloseSource()
        EZScanPagina = False
    End Function

    Private Sub txtChiaroScuro_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtChiaroScuro.TextChanged
        If Not IsNumeric(txtChiaroScuro.Text) Then
            txtChiaroScuro.Text = ""
        Else
            If txtChiaroScuro.Text < 0 Then txtChiaroScuro.Text = 0
            If txtChiaroScuro.Text > 100 Then txtChiaroScuro.Text = 100

            tbChiaroScuro.Value = txtChiaroScuro.Text
        End If
    End Sub

End Class