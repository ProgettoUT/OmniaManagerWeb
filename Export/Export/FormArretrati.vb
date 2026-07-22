Imports System.Windows.Forms

Public Class FormArretrati

    Public FinePeriodo As Date
    Public InizioPeriodo As Date

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = FormBorderStyle.FixedToolWindow
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Drawing.Size(375, 165)
        Me.Padding = New Padding(5)
        Me.Text = "Aggiornamento arretrati"
        'dtpInizioPeriodo
        With ButtonAggiorna
            .Image = Risorse.Immagini.Bitmap("aggiorna2")
            .ImageAlign = Drawing.ContentAlignment.TopCenter
            .Text = "Aggiorna"
            .TextAlign = Drawing.ContentAlignment.BottomCenter
        End With
    End Sub

    Public ReadOnly Property SoloCodiceSelezionato() As Boolean
        Get
            Return CheckBoxCodiceCorrente.Checked
        End Get
    End Property

    Private Sub FormArretrati_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Chiave As New Utx.SettingItem(Utx.SettingItem.Sezioni.INFO, Utx.SettingItem.Chiavi.IMPORTAZIONE_ARRETRATI,
                                   Utx.SettingOMW.TipoOperazione.LETTURA)
        If Chiave.ItemResult.Esiste Then
            LabelUltimoAggiornamento.Text = String.Format("Ultimo aggiornamento: {0}", Chiave.ItemResult.Valore)
        Else
            LabelUltimoAggiornamento.Text = "Ultimo aggiornamento: N.D."
        End If
        ImpostaDate()
        With CheckBoxCodiceCorrente
            .Checked = False
            .Text = String.Format("Aggiorna solo il codice agenzia {0}", Utx.Globale.AgenziaRichiesta.CodiceAgenzia)
            .Enabled = Utx.EnteGestore.CodiciGestiti.Count > 1
        End With
        Me.AcceptButton = ButtonAggiorna
    End Sub

    Private Sub FormArretrati_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.TopMost = True
        ButtonAggiorna.Focus()
    End Sub

    Private Sub ImpostaDate()
        'inizio periodo
        With dtpInizioPeriodo
            .Format = DateTimePickerFormat.Short
            .Value = Utx.FunzioniData.InizioMese(Today.AddYears(-1))
            'vado indietro di n mesi e inizio da giorno 1 (2 mesi + mese corrente)
            .MinDate = Utx.FunzioniData.InizioMese(Today.AddMonths(-35))
            .MaxDate = Today
        End With
        'fine periodo
        With dtpFinePeriodo
            .Format = DateTimePickerFormat.Short
            .Value = Utx.FunzioniData.FineMese(Today)
            'data minima oggi
            .MinDate = Today
            'massima data fine mese seguente
            .MaxDate = Utx.FunzioniData.FineMese(Today.AddMonths(1))
        End With
#If DEBUG Then
        dtpInizioPeriodo.Value = Utx.FunzioniData.InizioMese(Today.AddMonths(-1))
#End If
    End Sub

    Private Sub ButtonAggiorna_Click(sender As Object, e As EventArgs) Handles ButtonAggiorna.Click
        InizioPeriodo = dtpInizioPeriodo.Value
        FinePeriodo = dtpFinePeriodo.Value

        DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class