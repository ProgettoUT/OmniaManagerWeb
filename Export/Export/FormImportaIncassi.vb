Imports System.Windows.Forms

Public Class FormImportaIncassi

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = Risorse.Immagini.Icon("opzioni")
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Importazione incassi"

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        Dim Chiave As New Utx.SettingItem(Utx.SettingItem.Sezioni.INFO, Utx.SettingItem.Chiavi.IMPORTAZIONE_INCASSI,
                                          Utx.SettingOMW.TipoOperazione.LETTURA)
        If Chiave.ItemResult.Esiste Then
            LabelUltimoAggiornamento.Text = String.Format("Ultimo aggiornamento incassi: {0}", Chiave.ItemResult.Valore)
        Else
            LabelUltimoAggiornamento.Text = "Ultimo aggiornamento incassi: N.D."
        End If

        With ButtonImporta
            .Margin = New Padding(0)
            .Padding = New Padding(10, 0, 20, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Drawing.Color.Gainsboro
            .Image = Risorse.Immagini.Bitmap("aggiorna")
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = "Avvia aggiornamento degli incassi"
            .TextAlign = Drawing.ContentAlignment.MiddleRight
        End With
        With ButtonAnnulla
            .Margin = New Padding(0)
            .Padding = New Padding(5, 0, 5, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Drawing.Color.Gainsboro
            .Image = Risorse.Immagini.Bitmap("cancel")
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = "Annulla"
            .TextAlign = Drawing.ContentAlignment.MiddleRight
        End With

        ComboBoxAgenzie.DropDownStyle = ComboBoxStyle.DropDownList

        RadioButtonAuto.Checked = True
        RadioButtonAutoData.Checked = True
        RadioButtonLeggi.Checked = True
        dtpInizioPeriodo.MaxDate = Today
    End Sub

    Private mOpzioniScarico As ExportLib.ConfigScaricoIncassi
    Public Property OpzioniScarico() As ExportLib.ConfigScaricoIncassi
        Get
            Return mOpzioniScarico
        End Get
        Set(value As ExportLib.ConfigScaricoIncassi)
            mOpzioniScarico = value

            ComboBoxAgenzie.Items.Clear()

            'il primo item è per tutti i codici
            ComboBoxAgenzie.Items.Add(mOpzioniScarico.CodiciGestiti)

            'poi aggiungo tutti i codici singolarmente
            For Each AgenziaMadre As String In mOpzioniScarico.CodiciGestiti.Split("/")
                ComboBoxAgenzie.Items.Add(AgenziaMadre)
            Next

            If ComboBoxAgenzie.Items.Count > 0 Then
                ComboBoxAgenzie.SelectedIndex = 0 'tutti i codici
            End If
        End Set
    End Property

    Private Sub RadioButtonAutoData_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonAutoData.CheckedChanged
        dtpInizioPeriodo.Enabled = Not RadioButtonAutoData.Checked
    End Sub

    Private Sub ButtonImporta_Click(sender As Object, e As EventArgs) Handles ButtonImporta.Click

        'data inizio periodo
        If RadioButtonAutoData.Checked = True Then
            mOpzioniScarico.InizioPeriodo = Today
        Else
            mOpzioniScarico.InizioPeriodo = dtpInizioPeriodo.Value
        End If

        'lettura o scarico file
        mOpzioniScarico.ScaricaFile = RadioButtonScaricaFile.Checked
        'codici da scaricare
        mOpzioniScarico.CodiciDaScaricare = ComboBoxAgenzie.Text

        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonAnnulla.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub RadioButtonAuto_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonAuto.CheckedChanged
        If RadioButtonAuto.Checked = True Then
            Panel1.BackColor = Drawing.Color.YellowGreen
            GroupBoxDate.Enabled = False
            GroupBoxTipoLettura.Enabled = False
            GroupBoxAgenzie.Enabled = False
        Else
            Panel1.BackColor = Drawing.Color.Coral
            GroupBoxDate.Enabled = True
            GroupBoxTipoLettura.Enabled = True
            GroupBoxAgenzie.Enabled = True
        End If
    End Sub

    Private Sub FormImportaIncassi_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.TopMost = True
    End Sub

    Private Sub LabelUltimoAggiornamento_DoubleClick(sender As Object, e As EventArgs) Handles LabelUltimoAggiornamento.DoubleClick
        OpzioniScarico.Forzatura = Not OpzioniScarico.Forzatura
        If OpzioniScarico.Forzatura = False Then
            ButtonImporta.Image = Risorse.Immagini.Bitmap("aggiorna")
        Else
            ButtonImporta.Image = Risorse.Immagini.Bitmap("aggiorna2")
        End If
    End Sub
End Class