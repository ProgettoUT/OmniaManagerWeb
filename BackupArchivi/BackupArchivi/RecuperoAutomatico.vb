Imports System.Data.OleDb
Imports System.IO

Public Class frmRecuperoAutomatico

    'la modalità check viene attivata prima del backup e chiude automaticamente la finestra
    'dopo il recupero dati
    Friend ModoSoloRecupero As Boolean
    Friend AgenziaRichiesta As String

    Private UltimoBackupEstratto() As String = {"", ""}

    Private Sub frmRecuperoAutomatico_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ChiudiUnitools() 'chiudo il prg in caso sia rimasto aperto
    End Sub

    Private Sub frmRecuperoAutomatico_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Me.Refresh()
        RecuperoAutomaticoTabelle()
    End Sub

    Private Sub frmRecuperoAutomatico_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = (Button1.Enabled = False) And (ModoSoloRecupero = False)
    End Sub

    Private Sub RecuperoAutomaticoTabelle()

        Dim OraInizio As Date = Now

        If ModoSoloRecupero Then
            MessaggioStato("Modalità solo recupero...")

            RecuperoDb()
            RecuperoTabelle()
        Else
            MessaggioStato("Analisi database in corso...")

            If (CheckDb(AgenziaRichiesta) = False) Or
               (CheckDb("00000") = False) Then
                'non utilizzare OrElse altrimenti potrebbe non fare il check dei dati comuni

                MessaggioStato("Recupero automatico dati agenzia " + AgenziaRichiesta)
                MessaggioStato()

                RecuperoDb()
                RecuperoTabelle()

                Globale.Log.Rientro = 0

                MessaggioStato()
                MessaggioStato("Recupero dati agenzia completato")

                If Directory.Exists(Utx.Globale.Paths.CartellaTempUtente) Then Directory.Delete(Utx.Globale.Paths.CartellaTempUtente, True)

            Else
                MessaggioStato("Non è stata rilevata alcuna anomalia nei dati dell'agenzia " + AgenziaRichiesta)
            End If
        End If
        Utx.NetFunc.SvuotaCartella(CartellaRipristino)

        MessaggioStato(String.Format("Analisi dati completata in {0} secondi",
                                     DateDiff(DateInterval.Second, OraInizio, Now)))
        Globale.Log.Info()

        If ModoSoloRecupero Then
            Globale.Log.Info("Chiudo interfaccia di recupero automatico")
            Me.Close()
        Else
            With Button1
                .Padding = New Padding(20, 0, 20, 0)
                .Image = My.Resources.Esci.ToBitmap
                .ImageAlign = Drawing.ContentAlignment.MiddleLeft
                .TextAlign = Drawing.ContentAlignment.MiddleRight
                .Enabled = True
            End With

            Button1.Text = "Esci e avvia Unitools"
        End If

    End Sub

    Private Sub MessaggioStato(Optional ByVal Testo As String = "", Optional ByVal Errore As Boolean = False)
        lbMessaggi.Text = Testo
        Globale.Log.Info(Testo)
    End Sub

    Private Sub RecuperoDb()
        Try
            Cursor = Cursors.WaitCursor

            Dim StrutturaCompleta As New List(Of Database)
            StrutturaCompleta.AddRange(Globale.DbAgenzia)
            StrutturaCompleta.AddRange(Globale.DbComuni)

            'struttura oggetto: Database,check
            For Each db As Database In StrutturaCompleta

                If db.Check = False Then 'dal check è venuta fuori un anomalia
                    Dim DbPath As String = NomeDb2Path(db.Nome, AgenziaRichiesta)

                    'sostituisco con il db preso dai modelli per poi attivare il recupero delle tabelle dal backup
                    If SostituisciDb(DbPath, False) = True Then
                        MessaggioStato(String.Format("Database sostituito: {0}", DbPath))

                        db.Check = True

                        'per attivare il recupero delle tabelle metto il check a false
                        'struttura oggetto: Database,Tabella,Descrizione,numero record,check
                        For Each Tbl As Tabella In Globale.StrutturaTabelle
                            If Tbl.Database = db.Nome Then Tbl.Check = False
                        Next
                    End If
                    Application.DoEvents()
                End If
            Next

        Catch ex As Exception
            MessaggioStato(ex.Message, True)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub RecuperoTabelle()
        Try
            Cursor = Cursors.WaitCursor

            For Each Tbl As Tabella In Globale.StrutturaTabelle
                'se dal check è venuta fuori un anomalia
                If Tbl.Check = False Then
                    For Each db As Database In Globale.DbComuni
                        If Tbl.Database = db.Nome Then
                            RecuperoAutomaticoTabella("00000", Tbl)
                        End If
                    Next
                    For Each db As Database In Globale.DbAgenzia
                        If Tbl.Database = db.Nome Then
                            RecuperoAutomaticoTabella(AgenziaRichiesta, Tbl)
                        End If
                    Next
                End If
                Application.DoEvents()
            Next

        Catch ex As Exception
            MessaggioStato(ex.Message, True)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Friend Sub RecuperoAutomaticoTabella(ByVal CodiceAgenzia As String,
                                         ByRef DatiTabella As Tabella)

        'trova il backup e lo decomprime nella catella temp
        If TrovaBackupInLog(CodiceAgenzia, DatiTabella.Nome) = False Then
            If TrovaBackupInFile(CodiceAgenzia) = False Then Exit Sub
        End If

        Try
            'nome del db che contiene la tabella
            Dim Db As String = Tabella2Db(DatiTabella.Nome)
            'file backup origine del ripristino
            Dim DbOrigine As String = Path.Combine(CartellaRipristino, Db)
            'destinazione della tabella ripristinata
            Dim DbDest As String = NomeDb2Path(Db, CodiceAgenzia)

            'connessione al db di destinazione (da ripristinare)
            Using cn As New OleDbConnection(Utx.Globale.MDBDriver + DbDest)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn

                    'cancella la tabella da ripristinare
                    Try
                        cmd.CommandText = "DROP TABLE " + DatiTabella.Nome
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        'se va in errore la tabella non c'è
                    End Try

                    Globale.Log.Rientro += 4

                    Try
                        'ripristina da backup
                        cmd.CommandText = String.Format("SELECT * INTO {0} FROM {1} IN '{2}'", _
                                                        DatiTabella.Nome, DatiTabella.Nome, DbOrigine)

                        Dim NrRecord As Integer = cmd.ExecuteNonQuery()

                        MessaggioStato(String.Format("Recupero tabella {0} (record {1})", DatiTabella.Nome, NrRecord))

                        DatiTabella.Records = NrRecord
                        DatiTabella.Check = True

                    Catch ex As Exception
                        MessaggioStato("Errore nel ripristino da backup:")
                        MessaggioStato(ex.Message, True)

                        'se il ripristino è andato in errore ripristino da modello
                        DbOrigine = NomeDb2Modello(Db)

                        Try
                            cmd.CommandText = String.Format("SELECT * INTO {0} FROM {1} IN '{2}'", _
                                                            DatiTabella.Nome, DatiTabella.Nome, DbOrigine)
                            cmd.ExecuteNonQuery()

                            MessaggioStato(String.Format("Recupero tabella {0} dai modelli", DatiTabella.Nome), True)

                            DatiTabella.Records = 0
                            DatiTabella.Check = True

                        Catch exModelli As Exception
                            MessaggioStato(exModelli.Message, True)
                        End Try

                    End Try
                End Using
            End Using

            Try
                'ricreo eventuali chiavi
                Select Case DatiTabella.Nome.ToLower
                    Case "clienti"
                        CreaChiaviClienti(CodiceAgenzia)
                    Case "polizze"
                        CreaChiaviPolizze(CodiceAgenzia)
                    Case "sinistri"
                        CreaChiaviSinistri(CodiceAgenzia)
                    Case "sinistridp", "sinistrida", "sinistriac"
                        CreaChiaviSinistri(CodiceAgenzia)
                End Select

            Catch ex As Exception
                Globale.Log.Errore(ex)
            End Try

            Globale.Log.Rientro -= 4

        Catch ex As Exception
            MessaggioStato(ex.Message, True)
        End Try
    End Sub

    Private Function TrovaBackupInLog(ByVal Agenzia As String,
                                      ByVal Tabella As String,
                                      Optional ByVal MaxAggiornamento As Date = #1/1/2100#) As Boolean

        Dim DbBackupLog As String

        If Utx.FunzioniRete.ReteAttiva = True Then
            DbBackupLog = IdFileBakLogEmme()
        Else
            DbBackupLog = IdFileBakLog()
        End If

        Dim c As New OleDbConnection
        Dim cmd As New OleDbCommand

        Try
            c.ConnectionString = Utx.Globale.MDBDriver + DbBackupLog
            c.Open()

            With cmd
                .Connection = c
                .CommandType = CommandType.Text

                'cerco la tabella da ripristinare per quell'agenzia
                .CommandText = "SELECT TOP 1 Pc,Agenzia,FileBackup,Aggiornamento " +
                               "FROM Log " +
                               "WHERE Agenzia = ? And Tabella = ? And Aggiornamento < ? " +
                               "ORDER BY Aggiornamento DESC"

                With .Parameters
                    .AddWithValue("Agenzia", Agenzia)
                    .AddWithValue("Tabella", Tabella)
                    .AddWithValue("Aggiornamento", MaxAggiornamento)
                End With

                Dim dr As OleDbDataReader = .ExecuteReader

                Try
                    Dim FileBackup As String

                    If dr.HasRows Then

                        dr.Read()

                        If Utx.FunzioniRete.ReteAttiva = True Then
                            FileBackup = Path.Combine(Utx.Globale.Paths.CartellaBackupRete, dr(0) + "\" + dr(1) + "\" + dr(2))
                        Else
                            FileBackup = Path.Combine(Utx.Globale.Paths.CartellaBackup, dr(1) + "\" + dr(2))
                        End If
                    Else
                        Return False
                    End If

                    If FileBackup <> UltimoBackupEstratto(0) Then
                        MessaggioStato("Trovato backup nel log")
                        Globale.Log.Rientro += 4

                        'MessaggioStato(String.Format("Decompressione backup {0} del {1}", FileBackup, dr("Aggiornamento")))
                        MessaggioStato(String.Format("File backup: {0}", FileBackup))
                        MessaggioStato(String.Format("Data backup: {0}", dr("Aggiornamento")))

                        If EspandiBackup(FileBackup) = True Then
                            MessaggioStato("Decompressione backup eseguita correttamente")
                            UltimoBackupEstratto(0) = FileBackup
                            UltimoBackupEstratto(1) = dr("Aggiornamento")
                            Return True
                        Else
                            MessaggioStato("Impossibile decomprimere il backup")
                            Return False
                        End If

                        Globale.Log.Rientro -= 4
                    Else
                        Return True
                    End If

                    dr.Close()

                Catch ex As Exception
                    Return False
                End Try

            End With

        Catch ex As Exception
            MessaggioStato(ex.Message, True)
            Return False
        Finally
            cmd.Dispose()
            c.Close()
            c.Dispose()
        End Try

    End Function

    Private Function TrovaBackupInFile(ByVal Agenzia As String) As Boolean

        MessaggioStato("Cerco backup nei file")
        Globale.Log.Rientro += 4

        Try
            Dim DataBackup As Date = #1/1/1900#
            Dim FileBackupSelezionato As String = ""

            'cerco il file zip più recente
            If Utx.FunzioniRete.ReteAttiva = True Then
                For Each di As DirectoryInfo In New DirectoryInfo(Utx.Globale.Paths.CartellaBackupRete).GetDirectories

                    If Directory.Exists(Path.Combine(di.FullName, Agenzia)) Then
                        For Each fi As FileInfo In di.GetFiles(Agenzia + "\*.zip", SearchOption.TopDirectoryOnly)

                            If fi.LastWriteTime > DataBackup Then
                                DataBackup = fi.LastWriteTime
                                FileBackupSelezionato = fi.FullName
                            End If
                        Next
                    End If
                Next
            End If

            'se il backup non è stato trovato in rete e se la rete non è attiva cerco in locale
            If String.IsNullOrEmpty(FileBackupSelezionato) Then
                For Each fi As FileInfo In New DirectoryInfo(IdDirBak(Agenzia)).GetFiles("*.zip", SearchOption.TopDirectoryOnly)

                    If fi.LastWriteTime > DataBackup Then
                        DataBackup = fi.LastWriteTime
                        FileBackupSelezionato = fi.FullName
                    End If
                Next
            End If

            If String.IsNullOrEmpty(FileBackupSelezionato) Then
                MessaggioStato("Backup non trovato")
                Return False

            ElseIf FileBackupSelezionato = UltimoBackupEstratto(0) Then 'già estratto
                Return True
            Else
                MessaggioStato(String.Format("Decompressione backup {0} ...", FileBackupSelezionato))

                If EspandiBackup(FileBackupSelezionato) = True Then
                    MessaggioStato("Decompressione eseguita correttamente")
                    UltimoBackupEstratto(0) = FileBackupSelezionato
                    UltimoBackupEstratto(1) = File.GetLastWriteTime(FileBackupSelezionato)
                    Return True
                Else
                    MessaggioStato("Impossibile decomprimere il backup")
                    Return False
                End If
            End If

        Catch ex As Exception
            MessaggioStato("Decompressione backup non riuscita")
            MessaggioStato(ex.Message, True)
            Return False
        Finally
            Globale.Log.Rientro -= 4
        End Try

    End Function

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Globale.Log.Info("Chiudo interfaccia di recupero automatico e avvio Unitools")
        Process.Start(Path.Combine(Utx.Globale.Paths.CartellaApp, "Unitools.exe"))
        Me.Close()
    End Sub

    Private Sub lbMessaggi_DoubleClick(sender As Object, e As System.EventArgs) Handles lbMessaggi.DoubleClick
        Process.Start(Globale.Log.LogFile)
    End Sub

End Class