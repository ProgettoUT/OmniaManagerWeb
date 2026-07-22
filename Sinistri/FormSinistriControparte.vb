Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data.OleDb

Public Class FormSinistriControparte

    Private Event ModificaStato()

    Sub New(IdSinistro As String)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Size = New Size(700, 400)
        Me.Padding = New Padding(10)
        Me.Font = Utx.AppFont.Normal
        Me.Text = "Gestione sinistro " & IdSinistro

        ImpostaControlli()

        mAgenziaSinistro = IdSinistro.Split("-")(1)
        mEsercizioSinistro = IdSinistro.Split("-")(2)
        mNumeroSinistro = IdSinistro.Split("-")(3)
    End Sub

    Private mSinistro As DataRow
    Public Property Sinistro() As DataRow
        Get
            Return mSinistro
        End Get
        Set(value As DataRow)
            mSinistro = value
        End Set
    End Property

    Private mAgenziaSinistro As Integer
    Public Property AgenziaSinistro() As Integer
        Get
            Return mAgenziaSinistro
        End Get
        Set(value As Integer)
            mAgenziaSinistro = value
        End Set
    End Property

    Private mEsercizioSinistro As Integer
    Public Property EsercizioSinistro() As Integer
        Get
            Return mEsercizioSinistro
        End Get
        Set(value As Integer)
            mEsercizioSinistro = value
        End Set
    End Property

    Private mNumeroSinistro As Integer
    Public Property NumeroSinistro() As Integer
        Get
            Return mNumeroSinistro
        End Get
        Set(value As Integer)
            mNumeroSinistro = value
        End Set
    End Property

    Private Sub ImpostaControlli()
        CheckBox1.Text = "Richiesta denuncia all'assicurato"
        LabelAzione1.Text = "Richiedere all'assicurato la denuncia del sinistro conforme/diversa/negata. Attività interna all'agenzia"
        CheckBox2.Text = "Invio denuncia alla compagnia"
        LabelAzione2.Text = "Inviare alla compagnia la denuncia raccolta dal nostro cliente"
        CheckBox3.Text = "Invio testimonianza/e"
        LabelAzione3.Text = "Inviare alla compagnia le eventuali testimonianze raccolte"
        CheckBoxNascondi.BackColor = Color.Gold
        With ButtonSalva
            .Padding = Utx.AppFont.ButtonPadding
            .Text = "Salva modifiche"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = Risorse.Immagini.Bitmap("salva")
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        RaiseEvent ModificaStato()
    End Sub

    Private Sub FormSinistriControparte_Load(sender As Object, e As EventArgs) Handles Me.Load
        dtpAzione1.Value = Today
        dtpAzione2.Value = Today
        dtpAzione3.Value = Today
        dtpAzione4.Value = Today
    End Sub

    Private Sub FormSinistriControparte_ModificaStato() Handles Me.ModificaStato
        If CheckBox1.Checked Then
            LabelOk1.Text = "OK"
            LabelOk1.BackColor = Color.PaleGreen
        Else
            LabelOk1.Text = "-"
            LabelOk1.BackColor = Color.Salmon
        End If
        If CheckBox2.Checked Then
            LabelOk2.Text = "OK"
            LabelOk2.BackColor = Color.PaleGreen
        Else
            LabelOk2.Text = "-"
            LabelOk2.BackColor = Color.Salmon
        End If
        If CheckBox3.Checked Then
            LabelOk3.Text = "OK"
            LabelOk3.BackColor = Color.PaleGreen
        Else
            LabelOk3.Text = "-"
            LabelOk3.BackColor = Color.Salmon
        End If
        If CheckBox4.Checked Then
            labelOk4.Text = "OK"
            labelOk4.BackColor = Color.PaleGreen
        Else
            labelOk4.Text = "-"
            labelOk4.BackColor = Color.Salmon
        End If
    End Sub

    Private Sub FormSinistriControparte_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LeggiSinistro()
    End Sub

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonAnnulla.Click
        Me.Close()
    End Sub

    Private Sub LeggiSinistro()
        Try
            Using c As New OleDbConnection(Utx.Globale.CnDbLink)
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT * FROM SinistriControparte WHERE AgenziaSinistro = ? AND EsercizioSinistro = ? AND NumeroSinistro = ?"
                    cmd.Parameters.AddWithValue("agenzia", mAgenziaSinistro)
                    cmd.Parameters.AddWithValue("esercizio", mEsercizioSinistro)
                    cmd.Parameters.AddWithValue("numero", mNumeroSinistro)

                    Dim dr As OleDbDataReader = cmd.ExecuteReader
                    dr.Read()
                    If dr("Azione1") IsNot DBNull.Value Then
                        CheckBox1.Checked = True
                        dtpAzione1.Value = dr("Azione1")
                    End If
                    If dr("Azione2") IsNot DBNull.Value Then
                        CheckBox2.Checked = True
                        dtpAzione2.Value = dr("Azione2")
                    End If
                    If dr("Azione3") IsNot DBNull.Value Then
                        CheckBox3.Checked = True
                        dtpAzione3.Value = dr("Azione3")
                    End If
                    If dr("Azione4") IsNot DBNull.Value Then
                        CheckBox4.Checked = True
                        dtpAzione4.Value = dr("Azione4")
                    End If
                    CheckBoxNascondi.Checked = (Utx.FunzioniDb.NullToString(dr("Nascondi")) = "S")
                End Using
            End Using
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged,
                                                                                   CheckBox2.CheckedChanged, CheckBox3.CheckedChanged, CheckBox4.CheckedChanged
        If sender.checked = True Then
            sender.backcolor = Color.PaleGreen
        Else
            sender.backcolor = Color.Salmon
        End If
        RaiseEvent ModificaStato()
    End Sub

    Private Sub ButtonSalva_Click(sender As Object, e As EventArgs) Handles ButtonSalva.Click
        Try
            'aggiorno il datarow sottostante la riga per visualizzare le modifiche
            mSinistro("Azione1") = IIf(CheckBox1.Checked, dtpAzione1.Value.ToShortDateString, DBNull.Value)
            mSinistro("Azione2") = IIf(CheckBox2.Checked, dtpAzione2.Value.ToShortDateString, DBNull.Value)
            mSinistro("Azione3") = IIf(CheckBox3.Checked, dtpAzione3.Value.ToShortDateString, DBNull.Value)
            mSinistro("Azione4") = IIf(CheckBox4.Checked, dtpAzione4.Value.ToShortDateString, DBNull.Value)
            mSinistro("Nascondi") = IIf(CheckBoxNascondi.Checked, "S", "")
            mSinistro("Az1") = IIf(mSinistro("Azione1") Is DBNull.Value, "", "S")
            mSinistro("Az2") = IIf(mSinistro("Azione2") Is DBNull.Value, "", "S")
            mSinistro("Az3") = IIf(mSinistro("Azione3") Is DBNull.Value, "", "S")
            mSinistro("Az4") = IIf(mSinistro("Azione4") Is DBNull.Value, "", "S")

            Using c As New OleDbConnection(Utx.Globale.CnDbLink)
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "UPDATE SinistriControparte " +
                                      "SET Azione1 = ?, Azione2 = ?, Azione3 = ?, Azione4 = ?, Nascondi = ? " +
                                      "WHERE AgenziaSinistro = ? AND EsercizioSinistro = ? AND NumeroSinistro = ?"
                    cmd.Parameters.AddWithValue("1", mSinistro("Azione1"))
                    cmd.Parameters.AddWithValue("2", mSinistro("Azione2"))
                    cmd.Parameters.AddWithValue("3", mSinistro("Azione3"))
                    cmd.Parameters.AddWithValue("4", mSinistro("Azione4"))
                    cmd.Parameters.AddWithValue("nascondi", mSinistro("Nascondi"))
                    cmd.Parameters.AddWithValue("agenzia", mAgenziaSinistro)
                    cmd.Parameters.AddWithValue("esercizio", mEsercizioSinistro)
                    cmd.Parameters.AddWithValue("numero", mNumeroSinistro)

                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Me.Close()
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub CheckBoxNascondi_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxNascondi.CheckedChanged
        If CheckBoxNascondi.Checked = True Then
            CheckBoxNascondi.BackColor = Color.Turquoise
        Else
            CheckBoxNascondi.BackColor = Color.Gold
        End If
    End Sub
End Class