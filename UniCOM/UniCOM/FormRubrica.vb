
Public Class FormRubrica

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Size = New Size(500, 350)
        Me.Font = Utx.AppFont.Normal '.Extra(11, FontStyle.Regular)
        Me.BackColor = Color.Lavender
        Me.Text = "Rubrica e-mail"
        Me.Icon = Risorse.Immagini.Icon("rubrica")

        ImpostaControlli()
    End Sub

    Private mEmail As String
    Public ReadOnly Property Email() As String
        Get
            Return mEmail
        End Get
    End Property

    Private Sub ImpostaControlli()
        With ButtonAggiungi
            .Dock = DockStyle.Fill
            .Margin = New Padding(0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Aggiungi"
        End With
        With ButtonSeleziona
            .Dock = DockStyle.Fill
            .Margin = New Padding(0)
            .Padding = Utx.AppFont.ButtonPadding
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Image = Risorse.Immagini.Bitmap("check")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Seleziona e-mail"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With ButtonElimina
            .Dock = DockStyle.Fill
            .Margin = New Padding(0)
            .Padding = Utx.AppFont.ButtonPadding
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Image = Risorse.Immagini.Bitmap("cancel")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Elimina e-mail"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With ButtonEsci
            .Dock = DockStyle.Fill
            .Margin = New Padding(0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Esci"
        End With
        With TextBoxEmail
            .Margin = New Padding(0)
            .BorderStyle = BorderStyle.FixedSingle
            .Multiline = True
            .Dock = DockStyle.Fill
        End With
        With ListBoxEmail
            .Margin = New Padding(0, 5, 0, 5)
            .BorderStyle = BorderStyle.FixedSingle
            .IntegralHeight = False
        End With
    End Sub

    Private Sub FormRubrica_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        TextBoxEmail.Focus()
    End Sub

    Private Sub Cerca()
        Dim Query As String = String.Format("SELECT * FROM Rubrica WHERE Email LIKE '%{0}%'", TextBoxEmail.Text.Trim)
        ListBoxEmail.DataSource = Utx.WsCommand.ExecuteNonQuery(Query).DataTable
        ListBoxEmail.DisplayMember = "Email"
    End Sub

    Private Sub TextBoxEmail_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxEmail.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBoxEmail_TextChanged(sender As Object, e As EventArgs) Handles TextBoxEmail.TextChanged
        Select Case TextBoxEmail.Text.Trim.Length
            Case 0
                ListBoxEmail.DataSource = Nothing
            Case Is < 3
                Exit Sub
            Case Else
                Cerca()
        End Select
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub ButtonSeleziona_Click(sender As Object, e As EventArgs) Handles ButtonSeleziona.Click
        Try
            If ListBoxEmail.SelectedItem IsNot Nothing Then
                Dim drv As DataRowView = ListBoxEmail.SelectedItem
                mEmail = drv.Item("Email")
                DialogResult = Windows.Forms.DialogResult.Yes
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonAggiungi_Click(sender As Object, e As EventArgs) Handles ButtonAggiungi.Click
        Try
            If String.IsNullOrEmpty(TextBoxEmail.Text) Then
                Exit Sub
            End If
            If Not Utx.NetFunc.ValidEmail(TextBoxEmail.Text, False, True) Then
                Exit Sub
            End If

            'se l'indirizzo non è in rubrica lo aggiungo
            Dim Query As String = String.Format("If (SELECT COUNT(*) AS Nr FROM Rubrica WHERE Email='{0}') = 0
                    INSERT INTO Rubrica (Email) VALUES('{0}')", TextBoxEmail.Text.Trim)
            Utx.WsCommand.ExecuteNonQuery(Query)

            Cerca()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonElimina_Click(sender As Object, e As EventArgs) Handles ButtonElimina.Click
        Try
            If ListBoxEmail.SelectedIndex < 0 Then
                Exit Sub
            End If

            Dim drv As DataRowView = ListBoxEmail.SelectedItem

            If MsgBox(String.Format("Confermate la cancellazione dell'indirizzo e-mail{0}{1}?",
                                    Environment.NewLine, drv.Item("Email")),
                      MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2,
                      Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then

                Dim Query As String = String.Format("DELETE FROM Rubrica WHERE Email = '{0}'", drv.Item("Email"))
                Utx.WsCommand.ExecuteNonQuery(Query)
            End If

            Cerca()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ListBoxEmail_DoubleClick(sender As Object, e As EventArgs) Handles ListBoxEmail.DoubleClick
        ButtonSeleziona.PerformClick()
    End Sub
End Class