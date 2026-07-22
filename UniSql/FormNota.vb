Imports System.Windows.Forms
Imports System.Data.OleDb

Public Class FormNota

    Friend Agenzia As String
    Friend UsoStampa As Boolean
    Friend TestoNota As String = ""

    Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        Me.Size = New Drawing.Size(500, 200)
        Me.Font = Utx.AppFont.Extra(9, Drawing.FontStyle.Regular)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        TextBoxNota.Font = Utx.AppFont.Extra(12, Drawing.FontStyle.Regular)
    End Sub

    Private Sub FormNota_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            With TextBoxNota
                .MaxLength = 255
                .Text = Utx.FunzioniDb.NullToString(_Arretrato.Cells("Nota").Value)
            End With

            If UsoStampa = True Then
                Me.Text = String.Format("{0} {1} del {2:dd-MM-yyyy}", _Arretrato.Cells("DESTINATARIO_NOME").Value,
                                    _Arretrato.Cells("POLIZZA_NUMERO").Value, _Arretrato.Cells("POLIZZA_SCADENZA").Value)
            Else
                Me.Text = String.Format("{0} {1}.{2} del {3:dd-MM-yyyy}", _Arretrato.Cells("Contraente").Value,
                                    _Arretrato.Cells("Ramo").Value, _Arretrato.Cells("Polizza").Value, _Arretrato.Cells("Effetto titolo").Value)
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private _Arretrato As DataGridViewRow
    Public WriteOnly Property Arretrato() As DataGridViewRow
        Set(value As DataGridViewRow)
            _Arretrato = value
        End Set
    End Property

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub ButtonSalva_Click(sender As Object, e As EventArgs) Handles ButtonSalva.Click
        Try
            If TextBoxNota.Text.Trim.Length > 0 Then
                TestoNota = TextBoxNota.Text.Trim
            Else
                TestoNota = ""
            End If

            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(Agenzia, Utx.ConnessioniDb.Db.INCASSI))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "UPDATE Arretrati SET Nota = ? WHERE Ramo = ? AND Polizza = ? AND EffettoTitolo = ?"

                    cmd.Parameters.AddWithValue("nota", TestoNota)

                    If UsoStampa = True Then
                        cmd.Parameters.AddWithValue("ramo", _Arretrato.Cells("POLIZZA_NUMERO").Value.ToString.Split("/")(0))
                        cmd.Parameters.AddWithValue("polizza", _Arretrato.Cells("POLIZZA_NUMERO").Value.ToString.Split("/")(1))
                        cmd.Parameters.AddWithValue("effetto", _Arretrato.Cells("POLIZZA_SCADENZA").Value)
                    Else
                        cmd.Parameters.AddWithValue("ramo", _Arretrato.Cells("Ramo").Value)
                        cmd.Parameters.AddWithValue("polizza", _Arretrato.Cells("Polizza").Value)
                        cmd.Parameters.AddWithValue("effetto", _Arretrato.Cells("Effetto titolo").Value)
                    End If
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub
End Class