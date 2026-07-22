Imports System.IO
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Drawing

Public Class FormConteggioDoc

    Friend CartellaCliente As String
    Friend CartellaDocumenti As String
    Friend ListaDoc() As String = {}

    Private Enum Ricerca
        Cliente = 0
        Tutti = 1
    End Enum
    Private AmbitoRicerca As Ricerca

    Private Sub FormConteggioDoc_Load(sender As Object, e As EventArgs) Handles Me.Load

        With ButtonConta
            .Padding = New Padding(10, 0, 10, 0)
            .Image = Risorse.Immagini.Bitmap("cerca32")
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = "Trova i documenti"
            .TextAlign = Drawing.ContentAlignment.MiddleRight
        End With
        With ComboBoxChiave
            .BackColor = Color.LightYellow
            .DropDownStyle = ComboBoxStyle.DropDown

            Dim Rinomina As New GestioneRinomina

            For Each d As String In Rinomina.ListaDocumenti
                .Items.Add(d.Replace("*", "").Trim)
            Next
        End With

        RadioButtonInizia.Checked = True
        RadioButtonCliente.Checked = True
        AmbitoRicerca = Ricerca.Tutti 'questo mi consente di passare al cliente in ImpostaBottoneSalva

        ImpostaBottoneSalva()

        Panel1.BackColor = Color.Gainsboro

        LabelRisultato.ForeColor = Color.DodgerBlue
        LabelRisultato.Text = "In attesa..."
    End Sub

    Private Sub FormConteggioDoc_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ComboBoxChiave.Focus()
    End Sub

    Private Sub FormConteggioDoc_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Try
            If RadioButtonTuttiDocumenti.Checked = True Then
                ListaDoc = {}
            End If

            Using c As New OleDbConnection(Utx.Globale.CnDbLink)

                c.Open()

                Using cmd As New OleDbCommand

                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text

                    'ora genero il file csv
                    cmd.CommandText = "DROP TABLE ConteggioDoc"
                    cmd.ExecuteNonQuery()

                End Using
            End Using

        Catch ex As Exception
        End Try

    End Sub

    Private Sub ButtonConta_Click(sender As Object, e As EventArgs) Handles ButtonConta.Click

        If ComboBoxChiave.Text.Trim.Length > 0 Then
            ButtonConta.Enabled = False
            ButtonSalva.Enabled = False

            ContaDocumenti()

            ButtonConta.Enabled = True
            ButtonSalva.Enabled = True
        Else
            MsgBox("Inserire una chiave di ricerca per il nome file", MsgBoxStyle.Exclamation)
            ComboBoxChiave.Focus()
        End If
    End Sub

    Private Sub ContaDocumenti()

        Try
            Dim Modello As String

            If RadioButtonInizia.Checked = True Then
                Modello = String.Format("{0}*.*", ComboBoxChiave.Text)
            Else
                Modello = String.Format("*{0}*.*", ComboBoxChiave.Text)
            End If

            LabelRisultato.Text = "Ricerca in corso..."
            Application.DoEvents()

            If RadioButtonCliente.Checked = True Then
                ListaDoc = Directory.GetFiles(CartellaCliente, Modello, SearchOption.AllDirectories)
                LabelRisultato.Text = String.Format("Trovati {0} documenti per il cliente", ListaDoc.Length)
            Else
                ListaDoc = Directory.GetFiles(CartellaDocumenti, Modello, SearchOption.AllDirectories)
                LabelRisultato.Text = String.Format("Trovati {0} documenti in archivio", ListaDoc.Length)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

    End Sub

    'Private Sub ContaDocumentiClienti(Cartella As String)

    '    Try
    '        Dim Modello As String

    '        If RadioButtonInizia.Checked = True Then
    '            Modello = String.Format("{0}*.*", ComboBoxChiave.Text)
    '        Else
    '            Modello = String.Format("*{0}*.*", ComboBoxChiave.Text)
    '        End If

    '        LabelRisultato.Text = "Ricerca in corso..."
    '        Application.DoEvents()

    '        ListaDoc = Directory.GetFiles(Cartella, Modello, SearchOption.AllDirectories)

    '        LabelRisultato.Text = String.Format("Trovati {0} documenti per il cliente", ListaDoc.Length)

    '    Catch ex As Exception
    '        Log.Errore(ex)
    '    End Try

    'End Sub

    Private Sub LabelRisultato_TextChanged(sender As Object, e As EventArgs) Handles LabelRisultato.TextChanged
        LabelRisultato.Refresh()
    End Sub

    Private Sub ButtonSalva_Click(sender As Object, e As EventArgs) Handles ButtonSalva.Click
        If RadioButtonCliente.Checked = True Then
            Me.Close()
        Else
            SalvaReport()
        End If
    End Sub

    Private Sub SalvaReport()
        Try
            'se la lista è vuota
            If ListaDoc.Length = 0 Then
                Exit Sub
            End If

            Dim cd As New SaveFileDialog
            cd.InitialDirectory = Utx.Globale.UtenteCorrente.Desktop
            cd.FileName = String.Format("Report ({0}) del {1}.csv", ComboBoxChiave.Text, Format(Now, "dd-MM-yyyy HH.mm.ss"))
            If cd.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            Using c As New OleDbConnection(Utx.Globale.CnDbLink)
                c.Open()

                LabelRisultato.Text = "Preparo il report..."

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text

                    'creo la tabella
                    Try
                        cmd.CommandText = "DROP TABLE ConteggioDoc"
                        cmd.ExecuteNonQuery()

                    Catch ex As Exception
                    End Try

                    cmd.CommandText = "SELECT 'NO' AS Doc,'' AS DataDoc,'' AS Mese,'' AS Anno," +
                                              "IdStatoCliente, CodiceFiscale, Sesso, Cognome, Nome, Indirizzo, Cap," +
                                              "Localita,Provincia,SubAgenzia,Produttore,Telefono1,Telefono2,Cellulare,Email,'' AS Percorso " +
                                      "INTO ConteggioDoc " +
                                      "FROM Clienti"

                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "UPDATE ConteggioDoc SET Doc = 'SI',DataDoc = ?,Mese = ?,Anno = ?,Percorso = ? " +
                                      "WHERE CodiceFiscale = ?"

                    For Each f As String In ListaDoc

                        Dim DataDoc As String = Documenti.DataDocumento(Path.GetFileName(f))

                        cmd.Parameters.Clear()

                        If IsDate(DataDoc) Then
                            cmd.Parameters.AddWithValue("Data", DataDoc)
                            cmd.Parameters.AddWithValue("Mese", CDate(DataDoc).Month)
                            cmd.Parameters.AddWithValue("Anno", CDate(DataDoc).Year)
                        Else
                            cmd.Parameters.AddWithValue("Data", "")
                            cmd.Parameters.AddWithValue("Mese", "")
                            cmd.Parameters.AddWithValue("Anno", "")
                        End If

                        cmd.Parameters.AddWithValue("Percorso", f)
                        cmd.Parameters.AddWithValue("CF", f.Split("\")(4))
                        cmd.ExecuteNonQuery()
                    Next

                    'ora genero il file csv
                    LabelRisultato.Text = "Salvataggio report..."

                    cmd.CommandText = "SELECT * FROM ConteggioDoc"
                    cmd.Parameters.Clear()

                    Dim da As New OleDbDataAdapter(cmd)
                    Dim dt As New DataTable
                    da.Fill(dt)

                    If dt.Rows.Count > 0 Then
                        Using sw As New StreamWriter(cd.FileName, False)
                            'riga di intestazione
                            For Each col As DataColumn In dt.Columns
                                sw.Write(String.Format("{0};", col.ColumnName))
                            Next
                            sw.Write(Environment.NewLine)

                            For Each dr As DataRow In dt.Rows

                                For Each col As DataColumn In dt.Columns
                                    sw.Write(String.Format("{0};", dr(col.ColumnName)))
                                Next

                                sw.Write(Environment.NewLine)
                            Next
                        End Using
                    End If

                End Using
            End Using

            LabelRisultato.Text = "Report salvato"

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub RadioButtonInizia_Click(sender As Object, e As EventArgs) Handles RadioButtonInizia.Click
        ComboBoxChiave.Focus()
    End Sub

    Private Sub RadioButtonContiene_Click(sender As Object, e As EventArgs) Handles RadioButtonContiene.Click
        ComboBoxChiave.Focus()
    End Sub

    Private Function LeggiNomiPredefiniti() As String()
        Try
            Dim mFileNomiPredefiniti As String = Path.Combine(Utx.Globale.Paths.CartellaModelliRete, "RinominaDoc.ini")

            If File.Exists(mFileNomiPredefiniti) Then
                Return File.ReadAllLines(mFileNomiPredefiniti)
            Else
                Return {""}
            End If

        Catch ex As Exception
            Return {""}
        End Try
    End Function

    Private Sub RadioButtonCliente_Click(sender As Object, e As EventArgs) Handles RadioButtonCliente.Click
        ImpostaBottoneSalva()
    End Sub

    Private Sub RadioButtonTuttiDocumenti_Click(sender As Object, e As EventArgs) Handles RadioButtonTuttiDocumenti.Click
        ImpostaBottoneSalva()
    End Sub

    Private Sub ImpostaBottoneSalva()

        If RadioButtonTuttiDocumenti.Checked = True And AmbitoRicerca = Ricerca.Cliente Then

            With ButtonSalva
                .Padding = New Padding(10, 0, 10, 0)
                .Image = Risorse.Immagini.Bitmap("csv")
                .ImageAlign = Drawing.ContentAlignment.MiddleLeft
                .Text = "Salva il report in CSV"
                .TextAlign = Drawing.ContentAlignment.MiddleRight
            End With

            AmbitoRicerca = Ricerca.Tutti
            ListaDoc = {}

        ElseIf RadioButtonCliente.Checked = True And AmbitoRicerca = Ricerca.Tutti Then

            With ButtonSalva
                .Padding = New Padding(10, 0, 10, 0)
                .Image = Risorse.Immagini.Bitmap("esci")
                .ImageAlign = Drawing.ContentAlignment.MiddleLeft
                .Text = "Esci - Vedi i documenti"
                .TextAlign = Drawing.ContentAlignment.MiddleRight
            End With

            AmbitoRicerca = Ricerca.Cliente
            ListaDoc = {}
        End If
    End Sub

End Class