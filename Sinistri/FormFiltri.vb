Imports System.Windows.Forms
Imports System.Drawing

Public Class FormFiltri

    Private mGriglia As DataGridView

    Sub New(ByRef GrigliaDati As DataGridView)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        Me.Size = New Size(420, 240)
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Font = Utx.AppFont.Normal
        Me.Padding = New Padding(3)
        Me.Text = "Filtra i dati"

        mGriglia = GrigliaDati

        ImpostaControlli()
    End Sub

    Private mIndiceColonna As Integer
    Public Property IndiceColonna() As Integer
        Get
            Return mIndiceColonna
        End Get
        Set(value As Integer)
            mIndiceColonna = value
        End Set
    End Property

    Private Sub ImpostaControlli()
        With LabelInfo
            .ForeColor = Color.DarkRed
            .Font = Utx.AppFont.Bold
            .Text = "E' possibile selezionare un filtro cliccando direttamente sull'intestazione della colonna oppure selezionando la colonna qui sotto."
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With ButtonFiltra
            .Margin = New Padding(0, 2, 0, 2)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Silver
            .BackColor = Color.Lavender
            .Dock = DockStyle.Fill
            .Text = "Filtra la colonna selezionata >>"
        End With
        With ButtonCancellaFiltri
            .Padding = Utx.AppFont.ButtonPadding
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Silver
            .Dock = DockStyle.Fill
            .Image = Risorse.Immagini.Bitmap("cancel")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Cancella il filtro corrente"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With ButtonDettaglio
            .Padding = Utx.AppFont.ButtonPadding
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Silver
            .Dock = DockStyle.Fill
            .Image = Risorse.Immagini.Bitmap("salva")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Carica un filtro o salva il filtro corrente"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With ComboBoxColonne
            For Each col As DataGridViewColumn In mGriglia.Columns
                .Items.Add(col)
            Next
            .Dock = DockStyle.Fill
            .DropDownStyle = ComboBoxStyle.DropDownList
            .Sorted = True
            .DisplayMember = "HeaderText"

            If .Items.Count > 0 Then
                .SelectedIndex = 0
            End If
        End With
        Me.AcceptButton = ButtonFiltra
    End Sub

    Private Sub ButtonFiltra_Click(sender As Object, e As EventArgs) Handles ButtonFiltra.Click
        mIndiceColonna = ComboBoxColonne.SelectedItem.Index
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub ButtonDettaglio_Click(sender As Object, e As EventArgs) Handles ButtonDettaglio.Click
        DialogResult = Windows.Forms.DialogResult.Yes
    End Sub

    Private Sub ButtonCancellaFiltri_Click(sender As Object, e As EventArgs) Handles ButtonCancellaFiltri.Click
        DialogResult = Windows.Forms.DialogResult.Retry
    End Sub
End Class