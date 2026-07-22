Imports System.IO

Public Class FormBDAOpzioni

    Public Opzioni As ExportLib.BancaDatiAnia.Opzioni
    Public Annulla As Boolean

    Private Sub FormBDA_Load(sender As Object, e As EventArgs) Handles Me.Load

        rbStornate.Checked = True
        rbAutovetture.Checked = True

        Opzioni.PeriodoAggiornamento = 90

        With LabelFileOrigine
            .BackColor = Color.White
            .BorderStyle = Windows.Forms.BorderStyle.Fixed3D
            .Text = ""
        End With
        With ButtonSfoglia
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Sfoglia"
        End With
        With ButtonModello
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .BackColor = Color.Moccasin
            .Text = "Modello"
        End With
        With ButtonAvvia
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Padding = New Padding(20, 0, 20, 0)
            .Text = "Avvia processo"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = My.Resources.importa32.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonAnnulla
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Padding = New Padding(10, 0, 10, 0)
            .Text = "Annulla"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = My.Resources.cancel.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
    End Sub

    Private Sub rbStornate_CheckedChanged(sender As Object, e As EventArgs) Handles rbStornate.CheckedChanged
        DeskFile()
    End Sub

    Private Sub rbArretrati_CheckedChanged(sender As Object, e As EventArgs) Handles rbArretrati.CheckedChanged
        DeskFile()
    End Sub

    Private Sub rbUtente_CheckedChanged(sender As Object, e As EventArgs) Handles rbUtente.CheckedChanged
        DeskFile()
    End Sub

    Private Sub rbArchivioBDA_CheckedChanged(sender As Object, e As EventArgs)
        DeskFile()
    End Sub

    Private Sub DeskFile()

        Veicoli.Enabled = True
        LabelFileOrigine.Text = ""
        'scelta del file origine
        LabelFileOrigine.Enabled = False
        ButtonSfoglia.Enabled = False

        If rbStornate.Checked = True Then
            LabelDesk.Text = "Targhe provenienti dall'estrazione 'Polizze stornate auto' per le quali chiedere l'interrogazione della banca dati Ania."

        ElseIf rbArretrati.Checked = True Then
            LabelDesk.Text = "Targhe provenienti dall'estrazione 'Titoli arretrati auto' scaduti da almeno 10 giorni e per le quali chiedere l'interrogazione della banca dati Ania."

        ElseIf rbUtente.Checked = True Then
            LabelDesk.Text = "File csv redatto dall'utente con intestazione e contenente almeno i campi 'Targa' e 'Classe Rca'."
            LabelFileOrigine.Enabled = True
            ButtonSfoglia.Enabled = True
            Veicoli.Enabled = False
            rbTuttiVeicoli.Checked = True
        End If
    End Sub

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonAnnulla.Click
        Annulla = True
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub ButtonAvvia_Click(sender As Object, e As EventArgs) Handles ButtonAvvia.Click

        If ButtonSfoglia.Enabled = True Then
            If String.IsNullOrEmpty(LabelFileOrigine.Text) Then
                MsgBox("Selezionare prima il file origine dei dati.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Exit Sub
            End If
        End If

        Annulla = False

        'tipo file
        If rbStornate.Checked = True Then
            Opzioni.TipoFile = ExportLib.BancaDatiAnia.TipoFile.STORNATE
        ElseIf rbArretrati.Checked = True Then
            Opzioni.TipoFile = ExportLib.BancaDatiAnia.TipoFile.ARRETRATI
        ElseIf rbUtente.Checked = True Then
            Opzioni.TipoFile = ExportLib.BancaDatiAnia.TipoFile.UTENTE
        End If

        'flag autovetture
        Opzioni.SoloAutovetture = rbAutovetture.Checked

        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub ButtonSfoglia_Click(sender As Object, e As EventArgs) Handles ButtonSfoglia.Click

        Dim cd As New OpenFileDialog

        With cd
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            .Filter = "File csv (*.csv)|*.csv"
        End With

        Dim Scelta As DialogResult = cd.ShowDialog

        If Scelta = Windows.Forms.DialogResult.OK Then
            Opzioni.FileOrigine = cd.FileName
            LabelFileOrigine.Text = Path.GetFileName(Opzioni.FileOrigine)
        End If
    End Sub

    Private Sub LabelFileOrigine_TextChanged(sender As Object, e As EventArgs) Handles LabelFileOrigine.TextChanged
        If LabelFileOrigine.Text.Trim.Length > 0 Then
            LabelFileOrigine.BackColor = Color.LightYellow
        End If
    End Sub

    Private Sub rbAutovetture_CheckedChanged(sender As Object, e As EventArgs) Handles rbAutovetture.CheckedChanged
        DeskFile()
    End Sub

    Private Sub rbTuttiVeicoli_CheckedChanged(sender As Object, e As EventArgs) Handles rbTuttiVeicoli.CheckedChanged
        DeskFile()
    End Sub

    'Private Function TargheDaAggiornare() As String
    '    Try
    '        Dim BDA As New ExportLib.BancaDatiAnia

    '        Using c As New OleDbConnection(Utx.Globale.CnDbLink)
    '            c.Open()

    '            Using cmd As New OleDbCommand
    '                cmd.Connection = c
    '                cmd.CommandType = CommandType.Text

    '                If rbAutovetture.Checked = True Then
    '                    cmd.CommandText = "SELECT Count(*) FROM Bda " +
    '                                      "WHERE (ScadenzaContratto BETWEEN ? AND ?) AND (ClasseRca = '01')"
    '                Else
    '                    cmd.CommandText = "SELECT Count(*) FROM Bda " +
    '                                      "WHERE (ScadenzaContratto BETWEEN ? AND ?)"
    '                End If

    '                cmd.Parameters.Add("Inizio", OleDbType.Date).Value = Today.AddDays(-Opzioni.PeriodoAggiornamento)
    '                cmd.Parameters.Add("Fine", OleDbType.Date).Value = Today

    '                Return cmd.ExecuteScalar.ToString
    '            End Using
    '        End Using

    '    Catch ex As Exception
    '        Globale.Log.Errore(ex)
    '        Return "N.D."
    '    End Try
    'End Function

    Private Sub ButtonSfoglia_EnabledChanged(sender As Object, e As EventArgs) Handles ButtonSfoglia.EnabledChanged
        ButtonModello.Enabled = ButtonSfoglia.Enabled
    End Sub

    Private Sub ButtonModello_Click(sender As Object, e As EventArgs) Handles ButtonModello.Click
        File.WriteAllText(Path.Combine(Utx.Globale.UtenteCorrente.Desktop, "File utente BDA.csv"), "Targa;Classe Rca")
        MsgBox("File modello per l'utente salvato sul desktop", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
    End Sub
End Class