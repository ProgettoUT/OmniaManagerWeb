Imports System.Drawing
Imports System.Windows.Forms

Public Class FormRichiestaDate

    Public FinePeriodo As Date
    Public InizioPeriodo As Date
    Public ListaCodici As List(Of String)

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = FormBorderStyle.None
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Drawing.Size(350, 150)
        Me.Padding = New Padding(2)
        Me.Font = Utx.AppFont.Normal
    End Sub

    Private Sub ImpostaControlli()
        'default
        Me.BackColor = mColoreBordo
        Panel1.BackColor = mColoreSfondo
        Me.Text = mFormText
        ButtonOk.Text = mButtonOkText
        ButtonAnnulla.Text = mButtonAnnullaText
        LabelMessaggio.Text = mLabelMessaggioText

        tlpMain.Padding = New Padding(5)
        With LabelMessaggio
            .FlatStyle = FlatStyle.Flat
            .Margin = New Padding(0)
            .Padding = New Padding(3)
            .TextAlign = Drawing.ContentAlignment.MiddleLeft
        End With
        With ButtonOk
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Silver
            .Margin = New Padding(1)
            .Padding = New Padding(3)
            .TextAlign = Drawing.ContentAlignment.MiddleCenter
        End With
        With ButtonAnnulla
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Silver
            .Margin = New Padding(1)
            .Padding = New Padding(3)
            .TextAlign = Drawing.ContentAlignment.MiddleCenter
        End With
        'codici
        With ComboBoxAgenzia
            .DropDownStyle = ComboBoxStyle.DropDownList

            .Items.Add("Tutti i codici")
            For Each a As String In Utx.EnteGestore.CodiciGestiti
                .Items.Add(a)
            Next
            .SelectedIndex = 0
        End With
    End Sub

    Private mColoreBordo As Color = Color.Gainsboro
    Public WriteOnly Property ColoreBordo() As Color
        Set(value As Color)
            mColoreBordo = value
            Me.BackColor = mColoreBordo
        End Set
    End Property

    Private mColoreSfondo As Color = SystemColors.Control
    Public WriteOnly Property ColoreSfondo() As Color
        Set(value As Color)
            mColoreSfondo = value
            Panel1.BackColor = mColoreSfondo
        End Set
    End Property

    Private mFormText As String = Utx.Globale.TitoloApp
    Public WriteOnly Property FormText() As String
        Set(value As String)
            mFormText = value
            Me.Text = mFormText
        End Set
    End Property

    Private mButtonOkText As String = "Ok"
    Public WriteOnly Property ButtonOkText() As String
        Set(value As String)
            mButtonOkText = value
            ButtonOk.Text = mButtonOkText
        End Set
    End Property

    Private mButtonAnnullaText As String = "Annulla"
    Public WriteOnly Property ButtonAnnullaText() As String
        Set(value As String)
            mButtonAnnullaText = value
            ButtonAnnulla.Text = mButtonAnnullaText
        End Set
    End Property

    Private mLabelMessaggioText As String = ""
    Public WriteOnly Property LabelMessaggioText() As String
        Set(value As String)
            mLabelMessaggioText = value
            LabelMessaggio.Text = mLabelMessaggioText
        End Set
    End Property

    Private Sub FormRichiestaDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ImpostaControlli()
        ImpostaDate()
    End Sub

    Private Sub FormArretrati_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.TopMost = True
        Me.Refresh()
        dtpInizioPeriodo.Focus()
    End Sub

    Private Sub ImpostaDate()
        'inizio periodo
        With dtpInizioPeriodo
            .Format = DateTimePickerFormat.Short
            .Value = #1/1/2014#
            .MaxDate = Today
        End With
        'fine periodo
        With dtpFinePeriodo
            .Format = DateTimePickerFormat.Short
            .Value = Today
            .MaxDate = Today
        End With
    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        If FinePeriodo < InizioPeriodo Then
            MsgBox("Data fine periodo non corretta", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
            Exit Sub
        End If

        InizioPeriodo = dtpInizioPeriodo.Value
        FinePeriodo = dtpFinePeriodo.Value

        ListaCodici = New List(Of String)
        If ComboBoxAgenzia.SelectedIndex = 0 Then
            For Each a As String In Utx.EnteGestore.CodiciGestiti
                ListaCodici.Add(a)
            Next
        Else
            ListaCodici.Add(ComboBoxAgenzia.Text)
        End If
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonAnnulla.Click
        DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class