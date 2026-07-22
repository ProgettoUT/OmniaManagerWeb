Imports System.Drawing
Imports System.Windows.Forms

Public Class FormAttivita

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        Me.Size = New Drawing.Size(460, 200)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Font = Utx.AppFont.Normal
        Me.AcceptButton = ButtonAnnulla
        Me.Text = "Report attività"

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        With ButtonStampa
            .Padding = New Padding(5, 0, 5, 0)
            .Image = Risorse.Immagini.Bitmap("print")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Stampa"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With ButtonElenco
            .Padding = New Padding(5, 0, 5, 0)
            .Image = Risorse.Immagini.Bitmap("list16")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Elenco"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With ButtonAnnulla
            .Padding = New Padding(5, 0, 5, 0)
            .Image = Risorse.Immagini.Bitmap("cancel")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Annulla"
            .TextAlign = ContentAlignment.MiddleRight
        End With

        dtpInizio.Format = Windows.Forms.DateTimePickerFormat.Short
        dtpFine.Format = Windows.Forms.DateTimePickerFormat.Short

        With ComboBoxPeriodo
            .DropDownStyle = Windows.Forms.ComboBoxStyle.DropDownList
            .BackColor = Color.Yellow

            With .Items
                .Clear()
                .Add("Mese corrente")
                .Add("Mese successivo")
                .Add("Settimana corrente")
                .Add("Settimana successiva")
                .Add("Tutto fino ad oggi")
                .Add("Tutto fino alla fine del mese")
                .Add("Tutto")
            End With
        End With
    End Sub

    Public ReadOnly Property Utente() As String
        Get
            Return TextBoxUtente.Text.ToUpper
        End Get
    End Property

    Public ReadOnly Property InizioPeriodo() As Date
        Get
            Return dtpInizio.Value.Date
        End Get
    End Property

    Public ReadOnly Property FinePeriodo() As Date
        Get
            Return dtpFine.Value.Date
        End Get
    End Property

    Private Sub FormAttivita_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ComboBoxPeriodo.SelectedIndex = 0
    End Sub

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonAnnulla.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub ButtonStampa_Click(sender As Object, e As EventArgs) Handles ButtonStampa.Click
        Me.DialogResult = Windows.Forms.DialogResult.Yes
    End Sub

    Private Sub ButtonElenco_Click(sender As Object, e As EventArgs) Handles ButtonElenco.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub ComboBoxPeriodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxPeriodo.SelectedIndexChanged
        On Error Resume Next

        Select Case ComboBoxPeriodo.SelectedIndex
            Case 0 'mese corrente
                dtpInizio.Value = Utx.FunzioniData.InizioMeseCorrente
                dtpFine.Value = Utx.FunzioniData.FineMeseCorrente
            Case 1 'mese seguente
                dtpInizio.Value = Utx.FunzioniData.InizioMese(Today.AddMonths(1))
                dtpFine.Value = Utx.FunzioniData.FineMese(Today.AddMonths(1))
            Case 2 'settimana corrente
                dtpInizio.Value = Today.AddDays(DayOfWeek.Monday - Today.DayOfWeek)
                dtpFine.Value = dtpInizio.Value.AddDays(6)
            Case 3 'settimana successiva
                dtpInizio.Value = Today.AddDays(7).AddDays(DayOfWeek.Monday - Today.DayOfWeek)
                dtpFine.Value = dtpInizio.Value.AddDays(6)
            Case 4 'Tutto fino ad oggi
                dtpInizio.Value = #1/1/1900#
                dtpFine.Value = Today
            Case 5 'Tutto fino alla fine del mese
                dtpInizio.Value = #1/1/2000#
                dtpFine.Value = Utx.FunzioniData.FineMeseCorrente()
            Case 6 'tutto
                dtpInizio.Value = #1/1/2000#
                dtpFine.Value = #12/31/2100#
        End Select
    End Sub

    Private Sub dtpInizio_Validated(sender As Object, e As EventArgs) Handles dtpInizio.Validated
        If dtpFine.Value < dtpInizio.Value Then
            dtpFine.Value = dtpInizio.Value
        End If
    End Sub

    Private Sub FormAttivita_Load(sender As Object, e As EventArgs) Handles Me.Load
        TextBoxUtente.Text = Utx.Globale.UtenteCorrente.UniageUser.ToUpper
    End Sub
End Class