Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data.OleDb

Public Class FormAzioni

    Private Event ModificaStato()

    Private mSinistro As DataRow
    Private mCompagnia As Integer
    Private mAgenziaSinistro As Integer
    Private mEsercizioSinistro As Integer
    Private mNumeroSinistro As Integer
    Private mNascosto As Boolean

    Sub New(Sinistro As DataRow, IdSinistro As String)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Size = New Size(500, 600)
        Me.Padding = New Padding(10)
        Me.Font = Utx.AppFont.Normal
        Me.Text = "Gestione azioni " & IdSinistro

        ImpostaControlli()

        mSinistro = Sinistro

        mCompagnia = Sinistro("Compagnia")
        mAgenziaSinistro = Sinistro("AgenziaSinistro")
        mEsercizioSinistro = Sinistro("EsercizioSinistro")
        mNumeroSinistro = Sinistro("NumeroSinistro")
        mNascosto = (Utx.FunzioniDb.NullToString(Sinistro("Nascondi")) = "S")
    End Sub

    Private Sub ImpostaControlli()
        Dim tt As New ToolTip
        With dgvAzioni
            .AllowUserToAddRows = False
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
        With LabelAzione
            .Margin = New Padding(2)
            .BackColor = Color.Gainsboro
            .BorderStyle = BorderStyle.FixedSingle
            .Text = ""
        End With
        With ButtonSalva
            .Margin = New Padding(2)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Registra"
        End With
        With ButtonReset
            .Margin = New Padding(2)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "x"
            .TextAlign = ContentAlignment.MiddleCenter
            .ForeColor = Utx.AppColor.RossoScuro
            .Font = Utx.AppFont.Bold
        End With
        tt.SetToolTip(ButtonReset, "annulla azione")
        With ButtonEsci
            .Margin = New Padding(2)
            .Padding = Utx.AppFont.ButtonPadding
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Esci"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = Risorse.Immagini.Bitmap("esci")
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        CheckBoxNascondi.Font = Utx.AppFont.Bold
    End Sub

    Private Sub FormAzioni_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LeggiAzioni()
    End Sub

    Private Sub LeggiAzioni()
        Try
            Using cmd As New OleDbCommand
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT A.*, R.DataAzione FROM AzioniSinistri AS A " +
                                  "LEFT JOIN (SELECT Codice,DataAzione FROM RegistroAzioni WHERE Compagnia=? AND AgenziaSinistro=? AND EsercizioSinistro=? AND NumeroSinistro=?) AS R " +
                                  "ON A.Codice = R.Codice"
                cmd.Parameters.AddWithValue("compagnia", mCompagnia)
                cmd.Parameters.AddWithValue("agenzia", mAgenziaSinistro)
                cmd.Parameters.AddWithValue("esercizio", mEsercizioSinistro)
                cmd.Parameters.AddWithValue("numero", mNumeroSinistro)

                dgvAzioni.DataSource = Utx.FunzioniDb.CreaDataTable(cmd)
                dgvAzioni.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

                CheckBoxNascondi.Checked = mNascosto
            End Using
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        Try
            'aggiorno il datarow sottostante la riga del sinistro in griglia per visualizzare le modifiche
            mSinistro("Nascondi") = IIf(CheckBoxNascondi.Checked, "S", "")
            'nascondo/visualizzo il sinistro il sinistro
            Using c As New OleDbConnection(Utx.Globale.CnDbLink)
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "UPDATE SinistriControparte " +
                                      "SET Nascondi = ? " +
                                      "WHERE Compagnia = ? AND AgenziaSinistro = ? AND EsercizioSinistro = ? AND NumeroSinistro = ?"
                    cmd.Parameters.AddWithValue("nascondi", IIf(CheckBoxNascondi.Checked, "S", ""))
                    cmd.Parameters.AddWithValue("compagnia", 1)
                    cmd.Parameters.AddWithValue("agenzia", mAgenziaSinistro)
                    cmd.Parameters.AddWithValue("esercizio", mEsercizioSinistro)
                    cmd.Parameters.AddWithValue("numero", mNumeroSinistro)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Me.Close()
        End Try
    End Sub

    Private Sub ButtonSalva_Click(sender As Object, e As EventArgs) Handles ButtonSalva.Click
        Try
            If dgvAzioni.CurrentRow Is Nothing Then Exit Sub

            Dim ValorePrecedente As String = Utx.FunzioniDb.NullToString(dgvAzioni.CurrentRow.Cells("DataAzione").Value)

            Using c As New OleDbConnection(Utx.Globale.CnDbLink)
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text

                    dgvAzioni.CurrentRow.Cells("DataAzione").Value = dtpAzione.Value.ToShortDateString
                    'aggiorno il datarow sottostante la riga del sinistro in griglia per visualizzare le modifiche
                    mSinistro(dgvAzioni.CurrentRow.Cells("Codice").Value) = dtpAzione.Value.ToShortDateString

                    If IsDate(ValorePrecedente) Then
                        cmd.CommandText = "UPDATE RegistroAzioni " +
                                          "SET DataAzione = ? " +
                                          "WHERE Compagnia = ? AND AgenziaSinistro = ? AND EsercizioSinistro = ? AND NumeroSinistro = ?"
                        cmd.Parameters.AddWithValue("data", dtpAzione.Value.ToShortDateString)
                        cmd.Parameters.AddWithValue("compagnia", 1)
                        cmd.Parameters.AddWithValue("agenzia", mAgenziaSinistro)
                        cmd.Parameters.AddWithValue("esercizio", mEsercizioSinistro)
                        cmd.Parameters.AddWithValue("numero", mNumeroSinistro)
                    Else
                        cmd.CommandText = "INSERT INTO RegistroAzioni (Compagnia,AgenziaSinistro,EsercizioSinistro,NumeroSinistro,Codice,DataAzione) VALUES(?,?,?,?,?,?) "
                        cmd.Parameters.AddWithValue("compagnia", 1)
                        cmd.Parameters.AddWithValue("agenzia", mAgenziaSinistro)
                        cmd.Parameters.AddWithValue("esercizio", mEsercizioSinistro)
                        cmd.Parameters.AddWithValue("numero", mNumeroSinistro)
                        cmd.Parameters.AddWithValue("codice", dgvAzioni.CurrentRow.Cells("Codice").Value)
                        cmd.Parameters.AddWithValue("data", dtpAzione.Value.ToShortDateString)
                    End If
                    cmd.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub dgvAzioni_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgvAzioni.CurrentCellChanged
        If dgvAzioni.CurrentRow IsNot Nothing Then
            LabelAzione.Text = String.Format("{0} - {1}", dgvAzioni.CurrentRow.Cells("Codice").Value, dgvAzioni.CurrentRow.Cells("Descrizione").Value)
        End If
    End Sub

    Private Sub CheckBoxNascondi_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxNascondi.CheckedChanged
        If CheckBoxNascondi.Checked Then
            CheckBoxNascondi.ForeColor = Utx.AppColor.RossoScuro
        Else
            CheckBoxNascondi.ForeColor = Drawing.SystemColors.ControlText
        End If
    End Sub

    Private Sub ButtonReset_Click(sender As Object, e As EventArgs) Handles ButtonReset.Click
        Try
            If (dgvAzioni.CurrentRow IsNot Nothing) AndAlso IsDate(dgvAzioni.CurrentRow.Cells("DataAzione").Value) Then

                Using c As New OleDbConnection(Utx.Globale.CnDbLink)
                    c.Open()

                    Using cmd As New OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text

                        dgvAzioni.CurrentRow.Cells("DataAzione").Value = DBNull.Value
                        'aggiorno il datarow sottostante la riga del sinistro in griglia per visualizzare le modifiche
                        mSinistro(dgvAzioni.CurrentRow.Cells("Codice").Value) = DBNull.Value

                        cmd.CommandText = "DELETE FROM RegistroAzioni " +
                                          "WHERE Compagnia = ? AND AgenziaSinistro = ? AND EsercizioSinistro = ? AND NumeroSinistro = ? AND Codice=?"
                        cmd.Parameters.AddWithValue("compagnia", 1)
                        cmd.Parameters.AddWithValue("agenzia", mAgenziaSinistro)
                        cmd.Parameters.AddWithValue("esercizio", mEsercizioSinistro)
                        cmd.Parameters.AddWithValue("numero", mNumeroSinistro)
                        cmd.Parameters.AddWithValue("codice", dgvAzioni.CurrentRow.Cells("Codice").Value)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub
End Class