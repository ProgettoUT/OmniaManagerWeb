Imports System.Data.OleDb

Public Class FormTelefonate

    Private ds As DataSet
#If DEBUG Then
    Private WithEvents Wb3CX As New EO.WinForm.WebControl
    Private WithEvents Wv3CX As New EO.WebBrowser.WebView
#End If

    Const ScriptDanni As String = "http://www.utools.it/Unitools/Doc/ScriptDanni.html"
    Const ScriptVita As String = "http://www.utools.it/Unitools/Doc/ScriptVita.html"

    Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width * 0.5, Screen.PrimaryScreen.WorkingArea.Height * 0.7)
        Me.Font = Utx.AppFont.Normal
        Me.Icon = Risorse.Immagini.Icon("telefono")
        Me.Text = "Telefonate registrate"

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
#If DEBUG Then
        Wb3CX.Dock = DockStyle.Fill
        TabPageTelefono.Controls.Add(Wb3CX)
        Wb3CX.WebView = Wv3CX
#End If
        TabMain.TabPages.Remove(TabPageTelefono)
        Me.ButtonCerca.Image = Risorse.Immagini.Bitmap("cerca32")
        Me.ButtonSalva.Image = Risorse.Immagini.Bitmap("salva")
        Me.ButtonAnnulla.Image = Risorse.Immagini.Bitmap("cancel")
    End Sub

    Private Sub FormTelefonate_Load(sender As Object, e As EventArgs) Handles Me.Load
        With LabelInfo
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = Color.Moccasin
            .Font = Utx.AppFont.Extra(12, FontStyle.Regular)
            .TextAlign = ContentAlignment.MiddleCenter
            .Text = "Inserire ramo e polizza, dove mancanti, collegati alla telefonata registrata."
        End With
        dgvTelefonate.AlternatingRowsDefaultCellStyle = Nothing
        Utx.NetFunc.DoppioBuffer(dgvTelefonate)
    End Sub

    Private Sub FormTelefonate_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            TabMain.ColorStyle = Utx.UtTabControl.TabColorStyle.DODGER_BLUE
            TabMain.Visible = True
#If DEBUG Then
            Wv3CX.Url = "https://aua.pbx.firstpoint.it:23001"
#End If
            wbDanni.Navigate(ScriptDanni)
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub Formatta(dgv As DataGridView)
        On Error Resume Next
        With dgv
            .Columns("Source").Visible = False
            .Columns("Destination").Visible = False
            .Columns("CallID").Visible = False
            .Columns("Path").Visible = False
            .Columns("DataImportazione").Visible = False
            .Columns("FileName").Visible = False
            .Columns("Type").Visible = False
            .Columns("CodiceFiscale").HeaderText = "Codice fiscale"
            .Columns("Polizza").HeaderText = "Polizza/Trattativa"
        End With
    End Sub

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonAnnulla.Click
        Me.Close()
    End Sub

    Private Sub ButtonSalva_Click(sender As Object, e As EventArgs) Handles ButtonSalva.Click
#If DEBUG Then
        Exit Sub
#End If
        Try
            Cursor = Cursors.WaitCursor

            Using s As New Utx.ServiziOMW.ServizioDatiOMW
                s.Proxy = Utx.Globale.UniProxy.Proxy
                s.AggiornaTelefonateSospese(ds)
            End Using

            SalvaCF()

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub SalvaCF()
        Try
            ds.Tables.Clear()

            Using s As New Utx.ServiziOMW.ServizioDatiOMW
                s.Proxy = Utx.Globale.UniProxy.Proxy

                ds = s.CfSospesi(Utx.EnteGestore.StringaCodiciGestiti)
            End Using

            'provo a inserire i cf
            Using c As New OleDbConnection(Utx.Globale.CnDbLink)
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT CodiceFiscale FROM Polizze WHERE Ramo = @ramo AND Polizza = @polizza"

                    For Each row As DataRow In ds.Tables(0).Rows
                        If IsNumeric(row("Ramo")) AndAlso IsNumeric(row("Polizza")) Then
                            With cmd.Parameters
                                .Clear()
                                .AddWithValue("ramo", row("Ramo"))
                                .AddWithValue("polizza", row("Polizza"))
                            End With
                            row("CodiceFiscale") = cmd.ExecuteScalar
                        End If
                    Next
                End Using
            End Using

#If DEBUG Then
            'Dim f As New Utx.FormDebug(ds.Tables(0))
            'f.ShowDialog()
#End If

            Using s As New Utx.ServiziOMW.ServizioDatiOMW
                s.Proxy = Utx.Globale.UniProxy.Proxy
                s.AggiornaTelefonateSospese(ds)
            End Using

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub dgvTelefonate_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvTelefonate.CellBeginEdit
        If e.ColumnIndex <> dgvTelefonate.Columns("Ramo").Index And e.ColumnIndex <> dgvTelefonate.Columns("Polizza").Index Then
            e.Cancel = True
        End If
    End Sub

    Private Sub TabPageElenco_Enter(sender As Object, e As EventArgs) Handles TabPageElenco.Enter
        Try
            Cursor = Cursors.WaitCursor

            Using s As New Utx.ServiziOMW.ServizioDatiOMW
                s.Proxy = Utx.Globale.UniProxy.Proxy

                ds = s.ElencoTelefonate(Utx.EnteGestore.StringaCodiciGestiti)

                If ds IsNot Nothing Then
                    Dim dt As DataTable = ds.Tables(0)
                    dt.Columns.Add(New DataColumn With {.ColumnName = "Chiamante", .DataType = Type.GetType("System.String")})
                    dt.Columns.Add(New DataColumn With {.ColumnName = "Chiamato", .DataType = Type.GetType("System.String")})
                    dt.Columns.Add(New DataColumn With {.ColumnName = "Cliente", .DataType = Type.GetType("System.String")})
                    dt.Columns("Chiamante").SetOrdinal(0)
                    dt.Columns("Chiamato").SetOrdinal(1)

                    If dt.Rows.Count > 0 Then
                        'abbino i nomi dei clienti
                        Dim dtClienti As DataTable = Utx.FunzioniDb.CreaDataTable("SELECT CodiceFiscale,Cognome + ' ' + Nome AS Cliente FROM Clienti")
                        dtClienti.PrimaryKey = {dtClienti.Columns("CodiceFiscale")}

                        For Each row In dt.Rows
                            row("Chiamante") = Normalizza(row("FileName").ToString.Split("_")(0))
                            row("Chiamato") = Normalizza(row("FileName").ToString.Split("_")(1))

                            If String.IsNullOrEmpty(row("CodiceFiscale").ToString) = False Then
                                Dim Cliente As DataRow = dtClienti.Rows.Find(row("CodiceFiscale"))
                                If IsNothing(Cliente) = False Then
                                    row("Cliente") = Cliente("Cliente")
                                End If
                            End If
                        Next
                    End If

                    dgvElenco.DataSource = dt
                    Formatta(dgvElenco)
                    dgvElenco.Columns("CodiceFiscale").Visible = False
                End If
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub TabPageSospese_Enter(sender As Object, e As EventArgs) Handles TabPageSospese.Enter
        Try
            Cursor = Cursors.WaitCursor

            'controllo se le api del centralino sono attivate
            Dim th As New Threading.Thread(AddressOf ApiAttive)
            th.Start()

            Using s As New Utx.ServiziOMW.ServizioDatiOMW
                s.Proxy = Utx.Globale.UniProxy.Proxy

                ds = s.TelefonateSospese(Utx.EnteGestore.StringaCodiciGestiti)

                If ds IsNot Nothing Then
                    Dim dt As DataTable = ds.Tables(0)
                    dt.Columns.Add(New DataColumn With {.ColumnName = "Chiamante", .DataType = Type.GetType("System.String")})
                    dt.Columns.Add(New DataColumn With {.ColumnName = "Chiamato", .DataType = Type.GetType("System.String")})
                    dt.Columns("Chiamante").SetOrdinal(0)
                    dt.Columns("Chiamato").SetOrdinal(1)

                    For Each row In dt.Rows
                        row("Chiamante") = Normalizza(row("FileName").ToString.Split("_")(0))
                        row("Chiamato") = Normalizza(row("FileName").ToString.Split("_")(1))
                    Next
                    dgvTelefonate.DataSource = dt
                    Formatta(dgvTelefonate)
                End If
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ApiAttive()
        Try
            Using s As New Utx.ServiziOMW.ServizioDatiOMW
                s.Proxy = Utx.Globale.UniProxy.Proxy

                If s.ApiAttive(Utx.EnteGestore.StringaCodiciGestiti) = False Then
                    LabelInfo.Text = String.Format("Inserire ramo e polizza, dove mancanti, collegati alla telefonata registrata.{0}" +
                                    "Le telefonate saranno disponibili alla consultazione al mattino del giorno successivo.{0}" +
                                    "E' possibile chiedere al gestore del centralino, gratuitamente, l'attivazione delle API per la visualizzazione delle registrazioni in tempo reale.",
                                Environment.NewLine)
                End If
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub
    Private Function Normalizza(Testo As String) As String
        Dim Caratteri As String = "[|;]|;%20| ;%C3%A0|à;%C3%A8|è;%C3%A9|é;%C3%AC|ì;%C3%B2|ò;%C3%B9|ù;%3A|:"

        For Each c As String In Caratteri.Split(";")
            Testo = Replace(Testo, c.Split("|")(0), c.Split("|")(1), Compare:=CompareMethod.Text)
        Next
        Return Testo
    End Function

    Private Sub TabPageVita_Enter(sender As Object, e As EventArgs) Handles TabPageVita.Enter
        wbVita.Navigate(ScriptVita)
    End Sub

    Private Sub dgvTelefonate_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvTelefonate.CellValidating
        dgvTelefonate.EndEdit()
    End Sub

    Private Sub dgvTelefonate_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTelefonate.CellDoubleClick
        CercaCliente()
    End Sub

    Private Sub CercaCliente()
        Try
            Using f As New UtControls.FormCercaCliente
                f.NomeCompleto = ""
                f.ShowDialog()

                If f.DialogResult = Windows.Forms.DialogResult.OK Then
                    With dgvTelefonate.CurrentRow
                        .Cells("CodiceFiscale").Value = f.CodiceFiscale

                        If String.IsNullOrEmpty(.Cells("Ramo").Value.ToString) OrElse String.IsNullOrEmpty(.Cells("Polizza").Value.ToString) Then

                            Using fp As New UtControls.FormCercaPolizze
                                fp.CodiceFiscale = f.CodiceFiscale
                                fp.ShowDialog()

                                If fp.DialogResult = Windows.Forms.DialogResult.OK Then
                                    .Cells("Ramo").Value = fp.Ramo
                                    .Cells("Polizza").Value = fp.Polizza
                                End If
                            End Using
                        End If
                    End With
                End If
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonCerca_Click(sender As Object, e As EventArgs) Handles ButtonCerca.Click
        Try
            If dgvTelefonate.CurrentRow IsNot Nothing Then
                CercaCliente()
            Else
                MsgBox("Selezionare prima una telefonata.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub
End Class