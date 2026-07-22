Imports System.Windows.Forms

Public Class CercaInFiles
    Private specifica As Specifica
    Private WithEvents scansione As New Scansione()
    Private Annulla As Boolean

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Padding = New Padding(3)
        Me.Font = Utx.AppFont.Normal
        Me.Icon = Risorse.Immagini.Icon("cerca16")

        DateTimePickerMin.Value = Utx.FunzioniData.InizioAnno(Today)
        DateTimePickerMax.Value = Today
    End Sub

    Private Sub UtFlatButtonCerca_Click(sender As Object, e As EventArgs) Handles UtFlatButtonCerca.Click
        Try
            UtFlatButtonCerca.Enabled = False
            UtFlatButtonAnnulla.Enabled = True
            UtFlatButtonApriLog.Enabled = False

            lblMessaggio3.Focus()

            lblMessaggio2.Text = "Numero occorrenze trovate 0"
            scansione.Agenzie.Clear()
            scansione.TipiRecord.Clear()
            scansione.ChiaveValore.Clear()

            TextBoxCampo1.Text = TextBoxCampo1.Text.ToUpper
            TextBoxCampo2.Text = TextBoxCampo2.Text.ToUpper
            TextBoxCampo3.Text = TextBoxCampo3.Text.ToUpper
            TextBoxContiene.Text = TextBoxContiene.Text.ToUpper

            For Each item As String In CheckedListBoxAgenzie.CheckedItems
                scansione.Agenzie.Add(item)
            Next
            If ComboBoxTipoRecord.SelectedItem IsNot Nothing Then
                scansione.TipiRecord.Add(CStr(ComboBoxTipoRecord.SelectedItem.key))
            End If
            If ComboBoxCampo1.SelectedItem IsNot Nothing Then
                scansione.ChiaveValore.Add(CStr(ComboBoxCampo1.SelectedItem.Key), TextBoxCampo1.Text)
            End If
            If ComboBoxCampo2.SelectedItem IsNot Nothing Then
                scansione.ChiaveValore.Add(CStr(ComboBoxCampo2.SelectedItem.Key), TextBoxCampo2.Text)
            End If
            If ComboBoxCampo3.SelectedItem IsNot Nothing Then
                scansione.ChiaveValore.Add(CStr(ComboBoxCampo3.SelectedItem.Key), TextBoxCampo3.Text)
            End If

            scansione.DataInizio = DateTimePickerMin.Value
            scansione.DataFine = DateTimePickerMax.Value
            scansione.Contiene = TextBoxContiene.Text

            Dim messaggio As String = "FILTRI: " & vbNewLine
            For Each t In scansione.TipiRecord
                messaggio &= "Tipo Record: " & t & vbNewLine
            Next
            For Each t In scansione.ChiaveValore
                If t.Value <> "" Then
                    messaggio &= t.Key & ": " & t.Value & vbNewLine
                End If
            Next
            If scansione.DataInizio <> #1/1/2001# Then
                messaggio &= "Data Inizio: " & scansione.DataInizio.ToString("dd/MM/yyyy") & vbNewLine
            End If
            If scansione.DataFine <> #12/31/2099# Then
                messaggio &= "Data Fine: " & scansione.DataFine.ToString("dd/MM/yyyy") & vbNewLine
            End If
            If scansione.Contiene <> "" Then
                messaggio &= "Testo: " & scansione.Contiene & vbNewLine
            End If

            messaggio &= vbNewLine & "CAMPI VISUALIZZATI:" & vbNewLine

            For Each t In scansione.ChiaveValore
                messaggio &= t.Key & ": " & t.Value & vbNewLine
            Next
            lblMessaggio3.Text = messaggio

            Annulla = False
            scansione.Cerca()


            lblMessaggio1.Text = "Ricerca " & CStr(IIf(Annulla, "Annullata", "Terminata"))

            UtFlatButtonCerca.Enabled = True
            UtFlatButtonApriLog.Enabled = True
            UtFlatButtonAnnulla.Enabled = False

            Utx.FunzioniAmbiente.Play("ok")

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub CercaInFiles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckBoxAgenzie.Checked = True
        CheckedListBoxAgenzie.Items.Clear()
        For Each file In IO.Directory.GetDirectories(Utx.Globale.Paths.CartellaArchivioDati)
            If IO.Path.GetFileName(file) Like "#####" Then
                CheckedListBoxAgenzie.Items.Add(IO.Path.GetFileName(file), True)
            End If
        Next
        CheckedListBoxAgenzie.CheckOnClick = True

        ComboBoxTipoRecord.Items.Clear()
        specifica = New Specifica()
        For Each f As File In specifica.Files.Values
            For Each t As KeyValuePair(Of String, Tracciato) In f.Tracciati
                Dim chiave As String = t.Key.Split("/"c)(1)
                ComboBoxTipoRecord.Items.Add(New KeyValuePair(Of String, String)(f.FilePatterns & t.Key, chiave))
            Next
        Next
        ComboBoxTipoRecord.ValueMember = "Key"
        ComboBoxTipoRecord.DisplayMember = "Value"

        UtFlatButtonApriLog.Enabled = False
        UtFlatButtonAnnulla.Enabled = False
    End Sub

    Private Sub ComboBoxTipoRecord_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxTipoRecord.SelectedIndexChanged
        Dim key As String = ComboBoxTipoRecord.SelectedItem.Key.ToString
        Dim keyFile = key.Substring(0, key.IndexOf("/"))
        Dim keyTracciato = key.Substring(key.IndexOf("/"))

        Dim tracciato As Tracciato = specifica.Files.GetFile(keyFile).Tracciati(keyTracciato)

        TextBoxCampo1.Text = ""
        TextBoxCampo2.Text = ""
        TextBoxCampo3.Text = ""

        ComboBoxCampo1.Text = ""
        ComboBoxCampo2.Text = ""
        ComboBoxCampo3.Text = ""

        ComboBoxCampo1.Items.Clear()
        ComboBoxCampo2.Items.Clear()
        ComboBoxCampo3.Items.Clear()
        For Each f In tracciato.Campi
            Dim i As New KeyValuePair(Of String, String)(f.Key, f.Value.Nome & " [" & f.Value.Lunghezza & "]")
            ComboBoxCampo1.Items.Add(i)
            ComboBoxCampo2.Items.Add(i)
            ComboBoxCampo3.Items.Add(i)
        Next
        ComboBoxCampo1.ValueMember = "Key"
        ComboBoxCampo1.DisplayMember = "Value"
        ComboBoxCampo2.ValueMember = "Key"
        ComboBoxCampo2.DisplayMember = "Value"
        ComboBoxCampo3.ValueMember = "Key"
        ComboBoxCampo3.DisplayMember = "Value"
    End Sub

    Private Sub scansione_FileInElaborazione(nomefile As String, ByRef Cancel As Boolean) Handles scansione.FileInElaborazione
        Cancel = Annulla
        lblMessaggio1.Text = "Ricerca in corso nel file " & nomefile
        Application.DoEvents()
    End Sub

    Private Sub scansione_RigheElaborate(numeroRigheTrovate As Integer, RigheElaborate As Integer) Handles scansione.RigheElaborate
        lblMessaggio2.Text = String.Format("Numero occorrenze trovate-righe elaborate {0}-{1}", numeroRigheTrovate, RigheElaborate)
        Application.DoEvents()
    End Sub

    Private Sub UtFlatButtonApriLog_Click(sender As Object, e As EventArgs) Handles UtFlatButtonApriLog.Click
        Process.Start(scansione.FileLog())
    End Sub

    Private Sub CheckBoxAgenzie_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxAgenzie.CheckedChanged
        For k As Integer = 0 To CheckedListBoxAgenzie.Items.Count - 1
            CheckedListBoxAgenzie.SetItemChecked(k, CheckBoxAgenzie.Checked)
        Next
    End Sub

    Private Sub UtFlatButtonAnnulla_Click(sender As Object, e As EventArgs) Handles UtFlatButtonAnnulla.Click
        If MsgBox("Vuoi annullare la ricerca?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Annulla = True
            UtFlatButtonAnnulla.Enabled = False
        End If
    End Sub

    Private Sub UtFlatButtonEsci_Click(sender As Object, e As EventArgs) Handles UtFlatButtonEsci.Click
        Annulla = True
        Me.Close()
    End Sub
End Class