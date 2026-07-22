Imports System.Data.OleDb

Public Class FormUtente

    Sub New(Optional Utente As DataGridViewRow = Nothing)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Font = Utx.AppFont.Normal
        Me.Text = "Aggiungi o modifica utente"

        mUtente = Utente

        ImpostaControlli()
    End Sub

    Private mUtente As DataGridViewRow
    Public Property Utente() As DataGridViewRow
        Get
            Return mUtente
        End Get
        Set(value As DataGridViewRow)
            mUtente = value
        End Set
    End Property

    Private Sub ImpostaControlli()
        TextBoxNome.MaxLength = 40
        TextBoxPassword.MaxLength = 10
        TextBoxMacAddress.MaxLength = 12
        TextBoxIP.MaxLength = 15
    End Sub

    Private Sub FormUtente_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LeggiUtenti()
        If mUtente IsNot Nothing Then
            'seleziono l'utente nel combo se c'è
            ComboBoxUtente.Text = ""
            Dim UtenteSelezionato As String = Utx.FunzioniDb.NullToString(mUtente.Cells("Utente").Value.ToString.ToUpper)
            For k As Integer = 0 To ComboBoxUtente.Items.Count - 1
                If Microsoft.VisualBasic.Left(ComboBoxUtente.Items(k), 8).ToUpper = UtenteSelezionato Then
                    ComboBoxUtente.SelectedIndex = k
                    Exit For
                End If
            Next
            TextBoxNome.Text = Utx.FunzioniDb.NullToString(mUtente.Cells("Nome").Value)
            TextBoxInterno.Text = Utx.FunzioniDb.NullToString(mUtente.Cells("Interno").Value)
            TextBoxPassword.Text = Utx.FunzioniDb.NullToString(mUtente.Cells("Password").Value)
            TextBoxMacAddress.Text = Utx.FunzioniDb.NullToString(mUtente.Cells("MacAddress").Value)
            TextBoxIP.Text = Utx.FunzioniDb.NullToString(mUtente.Cells("IP").Value)
        End If
        ComboBoxUtente.Focus()
    End Sub

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonAnnulla.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub ButtonSalva_Click(sender As Object, e As EventArgs) Handles ButtonSalva.Click
        Try
            If IsNumeric(TextBoxInterno.Text) = False Then
                MsgBox("Interno non valido", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Exit Sub
            End If
            If Utx.NetFunc.ValidIP4(TextBoxIP.Text) = False Then
                MsgBox("IP telefono non valido", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Exit Sub
            End If
            If String.IsNullOrEmpty(TextBoxMacAddress.Text) Then
                TextBoxMacAddress.Text = "ND"
            End If

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdb(Utx.ConnessioniDb.Db.SMS))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    'cancello l'utente da altri record per evitare la duplicazione
                    cmd.CommandText = "UPDATE UtentiCentralino SET Utente = '' WHERE Utente = ?"
                    cmd.Parameters.AddWithValue("utente", Microsoft.VisualBasic.Left(ComboBoxUtente.Text.ToUpper, 8))
                    cmd.ExecuteNonQuery()
                    'e ora aggiungo o aggiorno
                    cmd.CommandText = "SELECT COUNT(*) FROM UtentiCentralino WHERE Interno = ?"
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("interno", TextBoxInterno.Text)
                    cmd.Parameters.AddWithValue("utente", Microsoft.VisualBasic.Left(ComboBoxUtente.Text.ToUpper, 8))
                    cmd.Parameters.AddWithValue("nome", TextBoxNome.Text)
                    cmd.Parameters.AddWithValue("pw", TextBoxPassword.Text)
                    cmd.Parameters.AddWithValue("macaddress", TextBoxMacAddress.Text)
                    cmd.Parameters.AddWithValue("ip", TextBoxIP.Text)
                    cmd.Parameters.AddWithValue("interno", TextBoxInterno.Text)

                    If cmd.ExecuteScalar = 0 Then
                        cmd.CommandText = "INSERT INTO UtentiCentralino(Interno,Utente,Nome,PasswordTelefono,MacAddressTelefono,IPTelefono) VALUES(?,?,?,?,?,?)"
                        cmd.ExecuteNonQuery()
                    Else
                        cmd.CommandText = "UPDATE UtentiCentralino SET Interno = ?, Utente = ?, Nome = ?, PasswordTelefono = ?, MacAddressTelefono = ?, IPTelefono = ? WHERE Interno = ?"
                        cmd.ExecuteNonQuery()
                    End If
                End Using
            End Using
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub LeggiUtenti()
        Try
            Dim dr As DataTableReader = Utx.FunzioniDb.CreaDataTableReader("SELECT Utenza + ' - ' + TRIM(NomeComponente) AS Utente 
                FROM Utenze WHERE StatoUtenza = 'ATTIVATA'")
            Do While dr.Read
                ComboBoxUtente.Items.Add(dr("Utente"))
            Loop
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub
End Class