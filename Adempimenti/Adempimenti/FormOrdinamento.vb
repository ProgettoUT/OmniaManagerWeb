Public Class FormOrdinamento

    Public Griglia As DataGridView
    Public ListaOrdinamento As List(Of ColonnaOrdinamento)

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Size = New Size(400, 300)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Font = Globale.MainFont
        Me.Padding = New Padding(2)
        Me.Text = "Ordinamento multiplo personalizzato"

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()

        With LabelColonne
            .AutoSize = True
            .Dock = DockStyle.Fill
            .FlatStyle = FlatStyle.Flat
            .BorderStyle = BorderStyle.Fixed3D
            .BackColor = Color.YellowGreen
            .Text = "Colonne disponibili"
        End With
        With LabelOrdinamento
            .AutoSize = True
            .Dock = DockStyle.Fill
            .FlatStyle = FlatStyle.Flat
            .BorderStyle = BorderStyle.Fixed3D
            .BackColor = Color.Gold
            .Text = "Ordinamento (tipo)"
        End With
        With ListBoxColonne
            .IntegralHeight = False
            .Dock = DockStyle.Fill
        End With
        With ListBoxOrdinamento
            .IntegralHeight = False
            .Dock = DockStyle.Fill
        End With
        With ButtonAggiungiCrescente
            .Margin = New Padding(0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Gainsboro
            .FlatAppearance.BorderSize = 1
            .Dock = DockStyle.Fill
            .Text = "Aggiungi con ordine CRESCENTE"
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonAggiungiDecrescente
            .Margin = New Padding(0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Gainsboro
            .FlatAppearance.BorderSize = 1
            .Dock = DockStyle.Fill
            .Text = "Aggiungi con ordine DECRESCENTE"
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonCancella
            .Margin = New Padding(0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Gainsboro
            .FlatAppearance.BorderSize = 1
            .Dock = DockStyle.Fill
            .Text = "Rimuovi colonna"
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With ButtonCancellaTutto
            .Margin = New Padding(0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Dock = DockStyle.Fill
            .FlatAppearance.BorderSize = 1
            .Text = "Rimuovi tutto"
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With ButtonOk
            .Margin = New Padding(0)
            .Padding = New Padding(5, 0, 5, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Gainsboro
            .FlatAppearance.BorderSize = 1
            .Dock = DockStyle.Fill
            .Image = My.Resources.ok32.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Applica"
            .TextAlign = ContentAlignment.MiddleRight
        End With
    End Sub

    Private Sub FormOrdinamento_Load(sender As Object, e As EventArgs) Handles Me.Load
        CaricaColonne()
    End Sub

    Private Sub FormOrdinamento_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ListBoxColonne.Focus()
    End Sub

    Private Sub CaricaColonne()

        'carica colonne disponibili
        If Griglia IsNot Nothing Then

            ListBoxColonne.Items.Clear()

            For Each c As DataGridViewColumn In Griglia.Columns

                If c.Visible = True Then
                    ListBoxColonne.Items.Add(c)
                End If
            Next

            ListBoxColonne.DisplayMember = "HeaderText"
            ListBoxOrdinamento.DisplayMember = "Descrizione"
        End If

        'carica filtro precedente
        ListBoxOrdinamento.Items.Clear()

        For Each co As ColonnaOrdinamento In ListaOrdinamento
            ListBoxOrdinamento.Items.Add(co)
        Next
    End Sub

    Private Sub ButtonAggiungiCrescente_Click(sender As Object, e As EventArgs) Handles ButtonAggiungiCrescente.Click

        If ListBoxColonne.SelectedItem IsNot Nothing Then

            For Each c As ColonnaOrdinamento In ListBoxOrdinamento.Items

                If c.Nome = ListBoxColonne.SelectedItem.Name Then
                    Exit Sub
                End If
            Next

            ListBoxOrdinamento.Items.Add(New ColonnaOrdinamento(ListBoxColonne.SelectedItem,
                                                                ColonnaOrdinamento.TipoOrdinamento.CRESCENTE))
        End If
    End Sub

    Private Sub ButtonAggiungiDecrescente_Click(sender As Object, e As EventArgs) Handles ButtonAggiungiDecrescente.Click

        If ListBoxColonne.SelectedItem IsNot Nothing Then

            For Each c As ColonnaOrdinamento In ListBoxOrdinamento.Items

                If c.Nome = ListBoxColonne.SelectedItem.Name Then
                    Exit Sub
                End If
            Next

            ListBoxOrdinamento.Items.Add(New ColonnaOrdinamento(ListBoxColonne.SelectedItem,
                                                                ColonnaOrdinamento.TipoOrdinamento.DECRESCENTE))
        End If
    End Sub

    Private Sub ButtonCancella_Click(sender As Object, e As EventArgs) Handles ButtonCancella.Click

        ListBoxOrdinamento.Items.Remove(ListBoxOrdinamento.SelectedItem)

        If ListBoxOrdinamento.Items.Count > 0 Then
            ListBoxOrdinamento.SelectedIndex = 0
        End If
    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click

        ListaOrdinamento.Clear()

        If ListBoxOrdinamento.Items.Count > 0 Then
            For Each co As ColonnaOrdinamento In ListBoxOrdinamento.Items
                ListaOrdinamento.Add(co)
            Next
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ButtonCancellaTutto_Click(sender As Object, e As EventArgs) Handles ButtonCancellaTutto.Click
        ListBoxOrdinamento.Items.Clear()
    End Sub
End Class