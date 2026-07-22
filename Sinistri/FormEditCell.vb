Imports System.Windows.Forms
Imports System.Drawing

Public Class FormEditCell

    Public Dgv As DataGridView
    Public ea As DataGridViewCellMouseEventArgs
    Private Campo As String

    Sub New()
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Size = New Size(400, 90)
        Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        Me.Font = Utx.AppFont.Normal
        Me.Text = "Modifica dati"

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        With TextBoxValore
            .BorderStyle = BorderStyle.FixedSingle
            .TextAlign = HorizontalAlignment.Center
        End With
        With ButtonOk
            .Margin = New Padding(0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Drawing.Color.Gainsboro
            .FlatAppearance.MouseOverBackColor = Color.PaleGreen
            .Dock = DockStyle.Fill
            .Text = "Ok"
            .TextAlign = Drawing.ContentAlignment.MiddleCenter
        End With
        With ButtonAnnulla
            .Margin = New Padding(0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Drawing.Color.Gainsboro
            .FlatAppearance.MouseOverBackColor = Color.LightSalmon
            .Dock = DockStyle.Fill
            .Text = "Annulla"
            .TextAlign = Drawing.ContentAlignment.MiddleCenter
        End With
        Me.AcceptButton = ButtonOk
    End Sub

    Private Sub FormEditCell_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Campo = Dgv.Columns(ea.ColumnIndex).Name
        TextBoxValore.Text = Utx.FunzioniDb.NullToString(Dgv.Rows(ea.RowIndex).Cells(ea.ColumnIndex).Value)
        'blocco per campi (composti) che non possono essere modificati
        If "assicurato".Contains(Campo.ToLower) Then
            ButtonOk.Enabled = False
            LabelCampo.Text = String.Format("{0} (non modificabile):", Dgv.Columns(ea.ColumnIndex).HeaderText)
        Else
            LabelCampo.Text = String.Format("{0}:", Dgv.Columns(ea.ColumnIndex).HeaderText)
        End If
    End Sub

    Private Sub FormEditCell_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        TextBoxValore.Focus()
    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        Select Case Campo.ToLower
            Case "compagnia"
                If TextBoxValore.Text < 0 Then
                    TextBoxValore.Text = 1
                End If
            Case "agenziasinistro"
                If TextBoxValore.Text < 0 OrElse TextBoxValore.Text > 9999 Then
                    MsgBox("Agenzia/Ente sinistro non valido", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                    Exit Sub
                End If
            Case "eserciziosinistro"
                If TextBoxValore.Text < 1900 OrElse TextBoxValore.Text > Today.Year Then
                    MsgBox("Esercizio sinistro non valido", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                    Exit Sub
                End If
            Case "numerosinistro"
                If TextBoxValore.Text > 9999999 Then
                    MsgBox("Numero sinistro non valido (max 7 cifre)", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                    Exit Sub
                End If
        End Select
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonAnnulla.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class