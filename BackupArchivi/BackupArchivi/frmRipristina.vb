Imports System.Data.OleDb
Imports System.IO

Public Class frmRipristina

    Dim TT As New ToolTip

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Icon = My.Resources.ripristina
        Me.Text = "Ripristino archivi - Ver." + Application.ProductVersion
    End Sub

    Private Sub frmRipristina_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = Not btnAnalisi.Enabled
    End Sub

    Private Sub frmRipristina_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With btnRipristina
            .Padding = New Padding(10, 0, 10, 0)
            .Image = My.Resources.ripristina.ToBitmap
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = "Ripristina le tabelle selezionate (0)"
            .TextAlign = Drawing.ContentAlignment.MiddleRight
        End With
        With btnRecuperoAutomatico
            .Padding = New Padding(10, 0, 10, 0)
            .Image = My.Resources.wizard.ToBitmap
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = "Recupero automatico"
            .TextAlign = Drawing.ContentAlignment.MiddleRight
        End With
        With btnSelezionaTutti
            .Padding = New Padding(30, 0, 30, 0)
            .Image = My.Resources.check16.ToBitmap
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = "Seleziona tutti"
            .TextAlign = Drawing.ContentAlignment.MiddleRight
        End With
        With btnDeselezionaTutti
            .Padding = New Padding(30, 0, 30, 0)
            .Image = My.Resources.uncheck16.ToBitmap
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = "Deseleziona tutti"
            .TextAlign = Drawing.ContentAlignment.MiddleRight
        End With
        With btnEsci
            .Padding = New Padding(10, 0, 10, 0)
            .Image = My.Resources.Esci.ToBitmap
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = "Esci"
            .TextAlign = Drawing.ContentAlignment.MiddleRight
        End With
        With btnAnalisi
            .Padding = New Padding(30, 0, 30, 0)
            .Image = My.Resources.analisi.ToBitmap
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = "Analizza database e tabelle"
            .TextAlign = Drawing.ContentAlignment.MiddleRight
        End With
        With ListView1
            .View = View.Details
            .Columns.Add("Tabella")
            .Columns.Add("Numero record")
            .Columns.Add("Nome Db")
        End With

        StatusStrip1.GripStyle = ToolStripGripStyle.Hidden
        StatusStrip1.SizingGrip = False

        TabPageTabelle.Text = "Tabelle"
        TabPageAnalisi.Text = "Analisi"
        TabPageStorico.Text = "Storico tabelle"
        TabPageLog.Text = "Log"

        MessaggioStato()
        MessaggioDettaglio()

        'dopo aver impostato i combo e agganciati
        If Utx.FunzioniRete.ReteAttiva = True Then
            RadioButtonRete.Checked = True
        Else
            RadioButtonRete.Enabled = False
            RadioButtonLocale.Checked = True
        End If

        ImpostaElencoTabelle()
        ImpostaAgenzie()

        If ImpostaDatabase() = False Then
            MsgBox("Si è verificato un errore imprevisto in un tentativo di ripristino dei dati. Contattare l'assistenza",
                   MsgBoxStyle.Exclamation, "Ripristino dati Unitools")
            Me.Close()
        End If

        AgganciaEventi()
    End Sub

    Private Sub frmRipristina_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        cboDatabase.SelectedIndex = 0
    End Sub

    Private Sub AgganciaEventi()
        AddHandler cboDatabase.SelectedIndexChanged, AddressOf cboDatabase_SelectedIndexChanged
        AddHandler cboOrigine.SelectedIndexChanged, AddressOf cboDatabase_SelectedIndexChanged
        AddHandler RadioButtonLocale.CheckedChanged, AddressOf RadioButtonLocale_CheckedChanged
        AddHandler cboTabella.SelectionChangeCommitted, AddressOf cboTabella_SelectionChangeCommitted
    End Sub

    Private Function ImpostaDatabase() As Boolean
        Try
            cboDatabase.Items.Clear()
            cboDatabase.Items.Add("Tutte")

            Dim StrutturaCompleta As New List(Of BackupArchivi.Database)
            With StrutturaCompleta
                .AddRange(Globale.DbAgenzia)
                .AddRange(Globale.DbComuni)
                .Sort()
            End With

            For Each db As BackupArchivi.Database In StrutturaCompleta
                cboDatabase.Items.Add(db.Nome)
            Next

            Return True

        Catch ex As Exception
            lbLog.Text = ex.Message
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Private Sub ImpostaTabelle()

        If cboDatabase.SelectedIndex < 0 Then Exit Sub
        If cboOrigine.SelectedIndex < 0 Then Exit Sub

        If Not File.Exists(IdFileBakLog()) Then
            ImpostaTabelleDaFile()
            Exit Sub
        End If

        Dim cn As New OleDbConnection
        Dim cmd As New OleDbCommand

        Try
            cn.ConnectionString = Utx.Globale.MDBDriver + IdFileBakLog()
            cn.Open()

            cmd.Connection = cn
            cmd.CommandType = CommandType.Text

            If cboDatabase.SelectedIndex = 0 Then
                cmd.CommandText = "SELECT DISTINCT Tabella,Record,NomeDb " +
                                  "FROM Log " +
                                  "WHERE Agenzia = ? AND FileBackup = ? " +
                                  "ORDER BY Tabella"

                cmd.Parameters.AddWithValue("Agenzia", cboAgenzia.Text)
                cmd.Parameters.AddWithValue("File", cboOrigine.SelectedItem.Name)
            Else
                cmd.CommandText = "SELECT DISTINCT Tabella,Record,NomeDb " +
                                  "FROM Log " +
                                  "WHERE Agenzia = ? AND NomeDb = ? AND FileBackup = ? " +
                                  "ORDER BY Tabella"

                cmd.Parameters.AddWithValue("Agenzia", cboAgenzia.Text)
                cmd.Parameters.AddWithValue("Db", cboDatabase.Text)
                cmd.Parameters.AddWithValue("File", cboOrigine.SelectedItem.Name)
            End If

            Dim dr As OleDbDataReader = cmd.ExecuteReader

            If dr.HasRows Then
                ListView1.Items.Clear()

                Do While dr.Read
                    ListView1.Items.Add(New ListViewItem({dr(0), dr(1), dr(2)}))
                Loop

                ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
            Else
                ImpostaTabelleDaFile()
            End If

        Catch ex As Exception
            lbLog.Text = ex.Message
            Globale.Log.Errore(ex)
        Finally
            cmd.Dispose()
            cn.Close()
            cn.Dispose()
        End Try

    End Sub

    Private Sub ImpostaTabelleDaFile()
        Try
            ListView1.Items.Clear()

            For Each Tbl As Tabella In Globale.StrutturaTabelle
                If (Tbl.Database = cboDatabase.Text) OrElse (cboDatabase.Text = "Tutte") Then
                    ListView1.Items.Add(New ListViewItem({Tbl.Nome, "N.D.", Tbl.Database}))
                End If
            Next

            ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

        Catch ex As Exception
            lbLog.Text = ex.Message
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ImpostaAgenzie()
        If Globale.Agenzia = "00000" Then
            For Each d As String In Directory.GetDirectories(Utx.Globale.Paths.CartellaDati)
                Dim dinfo As DirectoryInfo = New DirectoryInfo(d)

                If dinfo.Name.Length = 5 AndAlso IsNumeric(dinfo.Name) AndAlso dinfo.Name <> "00000" Then
                    cboAgenzia.Items.Add(dinfo.Name)
                End If
            Next
        Else
            cboAgenzia.Items.Add(Globale.Agenzia)
        End If

        cboAgenzia.SelectedIndex = 0
    End Sub

    Private Sub cboAgenzia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAgenzia.SelectedIndexChanged
        RiempiComboBackup()
        If cboOrigine.Enabled = False Then ListView1.Items.Clear()
    End Sub

    Private Sub btnSelezionaTutti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelezionaTutti.Click
        For i As Int16 = 0 To ListView1.Items.Count - 1
            ListView1.Items(i).Checked = True
        Next
    End Sub

    Private Sub btnDeselezionaTutti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeselezionaTutti.Click
        For i As Int16 = 0 To ListView1.Items.Count - 1
            ListView1.Items(i).Checked = False
        Next
    End Sub

    Private Sub btnRipristina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRipristina.Click

        If cboOrigine.Enabled = False Then
            MessaggioStato("Non ci sono backup disponibili")
            Exit Sub
        End If

        If ListView1.CheckedIndices.Count = 0 Then
            MessaggioStato("Selezionare prima le tabelle da ripristinare...")
            Exit Sub
        End If

        btnEsci.Enabled = False
        btnSelezionaTutti.Enabled = False
        btnDeselezionaTutti.Enabled = False
        btnRipristina.Enabled = False

        Me.Refresh()

        Try
            Cursor = Cursors.WaitCursor

            MessaggioStato("Estrazione dati agenzia...")

            Globale.Log.Info(String.Format("Decomprimo backup origine: {0} ({1})",
                                           cboOrigine.SelectedItem.FullName,
                                           cboOrigine.Text))

            If EspandiBackup(cboOrigine.SelectedItem.FullName) = False Then
                MsgBox("Impossibile decomprimere in tutto o in parte il backup selezionato.",
                       MsgBoxStyle.Exclamation, "Ripristino")
                Exit Try
            End If

            RipristinaTabelle()

        Catch ex As Exception
            lbLog.Text = ex.Message
            Globale.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
            btnEsci.Enabled = True
            btnSelezionaTutti.Enabled = True
            btnDeselezionaTutti.Enabled = True
            btnRipristina.Enabled = True
        End Try
    End Sub

    Private Sub btnEsci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEsci.Click
        Globale.Log.Info("Chiusura interfaccia ripristino manuale")
        Globale.Log.Info()
        Me.Close()
    End Sub

    Private Function BackupSelezionatoDatiComuni() As String
        Return Path.Combine(Utx.Globale.Paths.CartellaBackup, "00000\Giorno" + CDate(cboOrigine.Text).Day.ToString + ".zip")
    End Function

    Private Sub MessaggioStato(Optional ByVal Testo As String = "")
        lbStato.Text = Testo
        StatusStrip1.Refresh()
        lbLog.Text = Testo
        Globale.Log.Info(Testo)
    End Sub

    Private Sub MessaggioDettaglio(Optional ByVal Testo As String = "")
        lbDettaglio.Text = Testo
        StatusStrip1.Refresh()
        lbLog.Text = Testo
        Globale.Log.Info(Testo)
    End Sub

    Private Sub RipristinaTabelle()

        Dim RecordRipristinati As Integer

        Try
            For Each i As Int16 In ListView1.CheckedIndices
                MessaggioStato(String.Format("Ripristino in corso: tabella {0}...",
                                             ListView1.Items(i).SubItems(0).Text))

                With ListView1
                    .Items(i).Selected = True

                    'ripristino
                    Dim CreazioneChiavi As Boolean
                    RecordRipristinati = RipristinaTabella(cboAgenzia.Text,
                                                           ListView1.Items(i).Text,
                                                           CreazioneChiavi)

                    'aggiorno visualizzazione
                    .Items(i).SubItems(2).Text += String.Format(" (Record ripristinati: {0} - Chiavi: {1})",
                                                                RecordRipristinati,
                                                                IIf(CreazioneChiavi, "Ok", "Errore"))

                    'deseleziona la tabella
                    .Items(i).Checked = False
                End With

                Application.DoEvents()
            Next

        Catch ex As Exception
            lbLog.Text = ex.Message
            Globale.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
            MessaggioStato("Ripristino completato (record " + RecordRipristinati.ToString + ")")
        End Try

    End Sub

    'Private Sub frmRipristina_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
    '    Me.Visible = True
    'End Sub

    Private Sub AggiornaBtnRipristina()
        btnRipristina.Text = "Ripristina le tabelle selezionate (" + ListView1.CheckedItems.Count.ToString + ")"
    End Sub

    Private Sub cboDatabase_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        ImpostaTabelle()

        If cboOrigine.SelectedIndex >= 0 Then
            TT.SetToolTip(cboOrigine, cboOrigine.SelectedItem.FullName)
        End If
    End Sub

    Private Sub AnalisiDatabase()
        Try
            Cursor = Cursors.WaitCursor
            MessaggioStato("Analisi database in corso...")

            lbAnalisi.Items.Clear()
            lbAnalisi.Items.Add("Analisi database:")

            For Each db As Database In Globale.DbAgenzia
                MessaggioDettaglio(db.Nome)
                StatusStrip1.Refresh()

                Dim DbPath As String = NomeDb2Path(db.Nome, cboAgenzia.Text)

                'se il file non esiste
                If File.Exists(DbPath) Then
                    If AperturaMdb(DbPath) Then
                        lbAnalisi.Items.Add(DbPath + " connessione ok.")
                    Else
                        lbAnalisi.Items.Add("*** " + DbPath + " è bloccato" + IIf(SostituisciDb(DbPath), " (Sostituito).", "."))
                        lbAnalisi.BackColor = Drawing.Color.LightYellow
                    End If
                Else
                    lbAnalisi.Items.Add("*** " + DbPath + " non esiste" + IIf(SostituisciDb(DbPath), " (Sostituito).", "."))
                    lbAnalisi.BackColor = Drawing.Color.LightYellow
                End If

                Application.DoEvents()
            Next

            For Each db As Database In Globale.DbComuni
                MessaggioDettaglio(db.Nome)
                StatusStrip1.Refresh()

                Dim DbPath As String = NomeDb2Path(db.Nome, cboAgenzia.Text)

                'se il file non esiste
                If File.Exists(DbPath) Then
                    If AperturaMdb(DbPath) Then
                        lbAnalisi.Items.Add(DbPath + " connessione ok.")
                    Else
                        lbAnalisi.Items.Add("*** " + DbPath + " è bloccato" + IIf(SostituisciDb(DbPath), " (Sostituito).", "."))
                        lbAnalisi.BackColor = Drawing.Color.LightYellow
                    End If
                Else
                    lbAnalisi.Items.Add("*** " + DbPath + " non esiste" + IIf(SostituisciDb(DbPath), " (Sostituito).", "."))
                    lbAnalisi.BackColor = Drawing.Color.LightYellow
                End If

                Application.DoEvents()
            Next

        Catch ex As Exception
            lbLog.Text = ex.Message
            Globale.Log.Errore(ex)
        Finally
            MessaggioStato()
            MessaggioDettaglio()
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub AnalisiTabelle()
        Try
            Cursor = Cursors.WaitCursor

            MessaggioStato("Analisi tabelle in corso...")

            lbAnalisi.Items.Add("")
            lbAnalisi.Items.Add("Analisi tabelle:")

            For Each db As Database In Globale.DbAgenzia
                lbAnalisi.Items.Add(">>> Database: " + db.Nome)

                Dim DbPath As String = NomeDb2Path(db.Nome, cboAgenzia.Text)

                'se il file mdb esiste
                If File.Exists(DbPath) Then

                    Using cn As New OleDbConnection(Utx.Globale.MDBDriver + DbPath)
                        cn.Open()

                        Using cmdCount As New OleDbCommand
                            cmdCount.Connection = cn
                            cmdCount.CommandType = CommandType.Text

                            For Each Tbl As Tabella In Globale.StrutturaTabelle

                                If Tbl.Database = db.Nome Then
                                    MessaggioDettaglio(Tbl.Nome)
                                    StatusStrip1.Refresh()

                                    cmdCount.CommandText = "SELECT Count(*) FROM " + Tbl.Nome

                                    Try
                                        Dim Nr As Integer = cmdCount.ExecuteScalar

                                        'se non ha record la spunto
                                        If Nr = 0 Then
                                            CheckTabella(Tbl.Nome)
                                            lbAnalisi.Items.Add(String.Format("*** {0}: records {1} (Selezionata)", Tbl.Nome, Nr))
                                            lbAnalisi.BackColor = Drawing.Color.LightYellow
                                        Else
                                            lbAnalisi.Items.Add(String.Format("{0}: records {1}", Tbl.Nome, Nr))
                                        End If

                                    Catch ex As Exception
                                        lbAnalisi.Items.Add(String.Format("*** {0}: non trovata (Selezionata)", Tbl.Nome))
                                        lbAnalisi.BackColor = Drawing.Color.LightYellow

                                        'la spunto nella lista delle tabelle da recuperare
                                        CheckTabella(Tbl.Nome)
                                    End Try
                                End If
                            Next
                            lbAnalisi.Items.Add("")
                        End Using
                    End Using
                End If
                Application.DoEvents()
            Next

            'ora i db comuni
            For Each db As Database In Globale.DbComuni
                lbAnalisi.Items.Add(">>> Database: " + db.Nome)

                Dim DbPath As String = NomeDb2Path(db.Nome, cboAgenzia.Text)

                'se il file mdb esiste
                If File.Exists(DbPath) Then

                    Using cn As New OleDbConnection(Utx.Globale.MDBDriver + DbPath)
                        cn.Open()

                        Using cmdCount As New OleDbCommand
                            cmdCount.Connection = cn
                            cmdCount.CommandType = CommandType.Text

                            For Each Tbl As Tabella In Globale.StrutturaTabelle
                                If Tbl.Database = db.Nome Then
                                    MessaggioDettaglio(Tbl.Nome)
                                    StatusStrip1.Refresh()

                                    cmdCount.CommandText = "SELECT Count(*) FROM " + Tbl.Nome

                                    Try
                                        Dim Nr As Integer = cmdCount.ExecuteScalar

                                        'se non ha record la spunto
                                        If Nr = 0 Then
                                            CheckTabella(Tbl.Nome)
                                            lbAnalisi.Items.Add(String.Format("*** {0}: records {1} (Selezionata)", Tbl.Nome, Nr))
                                            lbAnalisi.BackColor = Drawing.Color.LightYellow
                                        Else
                                            lbAnalisi.Items.Add(String.Format("{0}: records {1}", Tbl.Nome, Nr))
                                        End If

                                    Catch ex As Exception
                                        lbAnalisi.Items.Add(String.Format("*** {0}: non trovata (Selezionata)", Tbl.Nome))
                                        lbAnalisi.BackColor = Drawing.Color.LightYellow

                                        'la spunto nella lista delle tabelle da recuperare
                                        CheckTabella(Tbl.Nome)
                                    End Try
                                End If
                            Next
                            lbAnalisi.Items.Add("")
                        End Using
                    End Using
                End If

                Application.DoEvents()
            Next

            cboDatabase.SelectedIndex = 0 'tutte le tabelle

        Catch ex As Exception
            lbLog.Text = ex.Message
            Globale.Log.Errore(ex)
        Finally
            MessaggioStato()
            MessaggioDettaglio()
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnAnalisi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnalisi.Click
        Analisi()
    End Sub

    Private Sub Analisi()
        btnAnalisi.Enabled = False
        btnEsci.Enabled = False

        lbAnalisi.ResetBackColor()
        AnalisiDatabase()
        AnalisiTabelle()

        'aggiungo analisi al log
        For Each i As String In lbAnalisi.Items
            lbLog.Text = i
            Globale.Log.Info(i)
        Next

        btnAnalisi.Enabled = True
        btnEsci.Enabled = True
    End Sub

    Private Sub CheckTabella(ByVal NomeTabella As String)
        On Error Resume Next
        For k As Integer = 0 To ListView1.Items.Count - 1
            If ListView1.Items(k).Text = NomeTabella Then ListView1.Items(k).Checked = True
        Next
    End Sub

    Private Sub ListView1_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs) Handles ListView1.ItemChecked
        AggiornaBtnRipristina()
    End Sub

    Private Sub btnRecuperoAutomatico_Click(sender As System.Object, e As System.EventArgs) Handles btnRecuperoAutomatico.Click

        Try
            Dim f As New frmRecuperoAutomatico
            With f
                .Text = "Recupero automatico dati"
                .Icon = My.Resources.ripristina
                .StartPosition = FormStartPosition.CenterScreen
                .FormBorderStyle = FormBorderStyle.FixedDialog
                .MinimizeBox = False
                .Button1.Text = "attendere..."
                .Button1.Enabled = False

                .AgenziaRichiesta = cboAgenzia.Text

                .ShowDialog()
            End With

        Catch ex As Exception
            lbLog.Text = ex.Message
            Globale.Log.Errore(ex)
        End Try

    End Sub

    Private Sub lbLog_DoubleClick(sender As Object, e As System.EventArgs) Handles lbLog.DoubleClick
        Process.Start(Globale.Log.LogFile)
    End Sub

    Private Sub RadioButtonLocale_CheckedChanged(sender As Object, e As System.EventArgs)
        RiempiComboBackup()
        cboTabella_SelectionChangeCommitted(Me, New EventArgs)
    End Sub

    Friend Sub RiempiComboBackup()
        If RadioButtonRete.Checked = True Then
            RiempiComboBackupRete(cboOrigine, cboAgenzia.Text)
        ElseIf RadioButtonLocale.Checked = True Then
            RiempiComboBackupLocale(cboOrigine, cboAgenzia.Text)
        End If
    End Sub

    Private Sub ImpostaElencoTabelle()
        Try
            Using cn As New OleDbConnection(Utx.Globale.CnDbLink)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT DISTINCT Tabella, Descrizione FROM Struttura"

                    Dim dr As OleDbDataReader
                    dr = cmd.ExecuteReader

                    cboTabella.Items.Clear()
                    cboTabella.Items.Add("Selezionare una tabella...")

                    If dr.HasRows Then
                        Do While dr.Read
                            cboTabella.Items.Add(String.Format("{0} ({1})", dr("Tabella"), dr("Descrizione")))
                        Loop
                    End If

                    cboTabella.SelectedIndex = 0
                End Using
            End Using

        Catch ex As Exception
            lbLog.Text = ex.Message
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub cboTabella_SelectionChangeCommitted(sender As Object, e As System.EventArgs)

        If cboTabella.SelectedIndex = 0 Then
            dgvStoricoTabella.DataSource = Nothing
            Exit Sub
        End If

        Cursor.Current = Cursors.WaitCursor

        Dim cn As New OleDbConnection
        Dim cmd As New OleDbCommand

        Try
            If RadioButtonLocale.Checked = True Then
                cn.ConnectionString = Utx.Globale.MDBDriver + IdFileBakLog() 'su c:
            Else
                cn.ConnectionString = Utx.Globale.MDBDriver + IdFileBakLogEmme() 'su m:
            End If

            cn.Open()

            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT Pc,FileBackup,NomeDb AS Db,Tabella,Aggiornamento,Record " +
                              "FROM Log " +
                              "WHERE (Agenzia = ? OR Agenzia = '00000') AND Tabella = ? " +
                              "ORDER BY Aggiornamento DESC"

            cmd.Parameters.AddWithValue("Agenzia", cboAgenzia.Text)
            cmd.Parameters.AddWithValue("Tabella", Split(cboTabella.Text, "(")(0).Trim)

            Dim da As New OleDbDataAdapter(cmd)
            Dim dt As New DataTable
            da.Fill(dt)

            dgvStoricoTabella.DataSource = dt
            dgvStoricoTabella.AutoResizeColumns()

            dgvStoricoTabella.Columns("Aggiornamento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvStoricoTabella.Columns("Aggiornamento").DefaultCellStyle.Format = "dd-MM-yyyy HH:mm:ss"
            dgvStoricoTabella.Columns("Record").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvStoricoTabella.Columns("Record").DefaultCellStyle.Format = "###,###"

            dgvStoricoTabella.Focus()

        Catch ex As Exception
            lbLog.Text = ex.Message
            Globale.Log.Errore(ex)
        Finally
            cmd.Dispose()
            cn.Close()
            cn.Dispose()
        End Try

        Cursor.Current = Cursors.Default

    End Sub

End Class