Imports System.Data.OleDb
Imports System.Drawing
Imports System.IO

Public Class BackupEx

    Private Notifica As New Utx.FormNotifica

    Public Sub Backup()
        Try
            Threading.Thread.CurrentThread.Priority = Threading.ThreadPriority.BelowNormal

            With Notifica
                .Text = ""
                .ColoreSfondo = Color.LightSlateGray
                .ColoreTesto = Color.White
                .Opacity = 0.8
            End With

            If Globale.VisualizzaNotifica = True Then
                Notifica.Show()
                Notifica.Messaggio = "Backup archivi..."
            End If

            Dim Codici As List(Of String) = Utx.EnteGestore.CodiciGestiti
            Codici.Add("00000")

            For Each Codice As String In Utx.EnteGestore.CodiciGestiti
                Notifica.Messaggio = "Backup database " & Codice
                Globale.Log.Info("Backup database " & Codice)
                Globale.Log.AumentaRientro()

                Dim CartellaBak As String = Path.Combine(IdDirBak(Codice), String.Format("Bak_{0:dd-MM-yyyy}", Today))
                Directory.CreateDirectory(CartellaBak)

                Dim PathDatiAgenzia As String = Path.Combine(Utx.Globale.Paths.CartellaDati, Codice)
                For Each db As String In Directory.GetFiles(PathDatiAgenzia, "*.mdb")
                    Dim DbBak As String = Path.Combine(CartellaBak, Path.GetFileName(db))

                    If Utx.NetFunc.FileToMD5(db) <> Utx.NetFunc.FileToMD5(DbBak) Then
                        If NewCheckDb(db) = True Then
                            Globale.Log.Info("DB {0} ok - Aggiorno backup", {Path.GetFileName(db)})
                            File.Copy(db, DbBak, True)
                        Else
                            Globale.Log.Info("*** DB {0}: corrotto", {Path.GetFileName(db)})
                        End If
                    Else
                        Globale.Log.Info("DB {0} invariato", {Path.GetFileName(db)})
                    End If
                Next

                'zippo
                For Each Cartella As String In Directory.GetDirectories(IdDirBak(Codice), "Bak_*")
                    If IsDate(Path.GetFileName(Cartella).Substring(4)) Then
                        Dim Giorno As Date = Path.GetFileName(Cartella).Substring(4)

                        If Giorno < Today Then
                            Globale.Log.Info("Compressione backup {0} del {1:dd-MM-yyyy}", {Codice, Giorno})
                            Notifica.Messaggio = String.Format("Compressione backup {0} del {1:dd-MM-yyyy}", Codice, Giorno)
                            'file zippato
                            Dim Backup As String = String.Format("{0}\Giorno{1:00}.zip", IdDirBak(Codice), Giorno.Day)

                            AggiornaDbLog(Cartella, Backup, Codice)

                            Utx.LibreriaZip.ZipFolder(Cartella, Backup)

                            'salva, se non esiste, backup mensile
                            Dim ZipFileMensile As String = IdFileBakMensile(Codice)
                            If Not File.Exists(ZipFileMensile) Then
                                Notifica.Messaggio = "Salvataggio backup mensile..."
                                File.Copy(Backup, ZipFileMensile)
                                AggiornaDbLog(Cartella, Path.GetFileName(ZipFileMensile), Codice)
                            End If

                            'sincronizzo backup su M
                            If New DriveInfo("M").IsReady Then
                                Notifica.Messaggio = "Sincronizzo backup di rete (M:)..."
                                If Not File.Exists(IdFileBakLogEmme()) Then
                                    File.Copy(Path.Combine(Utx.Globale.Paths.CartellaModelli, "BackupLog.mdb"), IdFileBakLogEmme())
                                End If

                                SincronizzaBackup(Backup, Codice)
                                AggiornaDbLogEmme(Backup, Codice)
                            End If
                            'cancello cartella zippata
                            Utx.NetFunc.CancellaCartella(Cartella)
                        End If
                    End If
                Next
                Globale.Log.DiminuisciRientro()
                Globale.Log.Info()
            Next

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Globale.Log.Info()
        End Try
    End Sub

    Private Shared Sub AggiornaDbLog(ByVal CartellaBackup As String, FileBackup As String, ByVal Agenzia As String)
        Try
            'se non esiste il db modello lo copio
            If Not File.Exists(IdFileBakLog()) Then
                File.Copy(Path.Combine(Utx.Globale.Paths.CartellaModelli, "BackupLog.mdb"), IdFileBakLog())
            End If

            Dim Tabelle As New List(Of Tabella)
            For Each db As String In Directory.GetFiles(CartellaBackup, "*.mdb")
                Dim SchemaTabella As DataTable
                Using c As New OleDbConnection(Utx.Globale.MDBDriver + db)
                    c.Open()

                    SchemaTabella = c.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables_Info, New Object() {Nothing, Nothing, Nothing, Nothing})

                    For Each row As DataRow In SchemaTabella.Rows
                        If row("TABLE_TYPE") = "TABLE" Then
                            Tabelle.Add(New Tabella(db, row("TABLE_NAME"), row("CARDINALITY")))
                        End If
                    Next
                End Using
            Next

            'prendo solo il nome del file senza path
            FileBackup = Path.GetFileName(FileBackup)

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + IdFileBakLog())
                c.Open()

                Using cmd As New OleDbCommand
                    With cmd
                        .Connection = c
                        .CommandType = CommandType.Text
                        'cancello dati vecchi lascio anno corrente + precedente
                        .CommandText = String.Format("DELETE FROM Log WHERE Aggiornamento < #{0:MM/dd/yyyy}#", New DateTime(Today.Year - 1, 1, 1))
                        .ExecuteNonQuery()

                        'cancello i dati precedenti
                        .CommandText = "DELETE FROM Log WHERE Pc = ? AND FileBackup = ? AND Agenzia = ?"

                        .Parameters.AddWithValue("Pc", Environment.MachineName)
                        .Parameters.AddWithValue("FileBackup", FileBackup)
                        .Parameters.AddWithValue("Agenzia", Agenzia)

                        .ExecuteNonQuery()

                        'e poi aggiungo
                        .CommandText = "INSERT INTO Log(Pc,FileBackup,Agenzia,NomeDb,Tabella,Aggiornamento,Record) VALUES(?,?,?,?,?,?,?)"

                        Dim DataBackup As String = Now.ToString

                        'faccio la scansione delle cartelle e aggiorno la tabella con la cronologia backup
                        For Each tbl As Tabella In Tabelle

                            If ((Agenzia <> "00000") And (Not DbComuni(tbl.Database))) OrElse
                               ((Agenzia = "00000") And (DbComuni(tbl.Database))) Then

                                With .Parameters
                                    .Clear()
                                    .AddWithValue("Pc", Environment.MachineName)
                                    .AddWithValue("FileBackup", FileBackup)
                                    .AddWithValue("Agenzia", Agenzia)
                                    .AddWithValue("Database", tbl.Database)
                                    .AddWithValue("Tabella", tbl.Nome)
                                    .AddWithValue("Aggiornamento", DataBackup)
                                    .AddWithValue("Records", tbl.Records)
                                End With

                                .ExecuteNonQuery()
                            End If
                        Next
                    End With
                End Using
            End Using

            Globale.Log.Info("Aggiornato Db log per l'agenzia " + Agenzia)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub AggiornaDbLogEmme(ByVal FileBackup As String,
                                  ByVal Agenzia As String)
        Try
            'prendo solo il nome del file senza path
            FileBackup = Path.GetFileName(FileBackup)

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + IdFileBakLogEmme())
                c.Open()

                Using cmd As New OleDbCommand
                    With cmd
                        .Connection = c
                        .CommandType = CommandType.Text
                        'cancello dati vecchi lascio anno corrente + precedente
                        .CommandText = String.Format("DELETE FROM Log WHERE Aggiornamento < #{0:MM/dd/yyyy}#", New DateTime(Today.Year - 1, 1, 1))
                        .ExecuteNonQuery()

                        'cancello i dati precedenti
                        .CommandText = "DELETE " +
                                       "FROM Log " +
                                       "WHERE Pc = ? And FileBackup = ? And Agenzia = ?"

                        .Parameters.AddWithValue("Pc", Environment.MachineName)
                        .Parameters.AddWithValue("FileBackup", FileBackup)
                        .Parameters.AddWithValue("Agenzia", Agenzia)

                        .ExecuteNonQuery()

                        'copio i dati dal lo backup locale al log in emme
                        .CommandText = "INSERT INTO Log " +
                                       "SELECT * FROM Log IN '" + IdFileBakLog() + "' " +
                                       "WHERE Pc = ? And FileBackup = ? And Agenzia = ?"

                        .ExecuteNonQuery()
                    End With
                End Using
            End Using

            Globale.Log.Info("Aggiornato Db log su M: per l'agenzia " + Agenzia)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub SincronizzaBackup(ByVal FileBackup As String,
                                  ByVal Agenzia As String)
        Try
            Dim DestinazioneEmme As String = Path.Combine(Utx.Globale.Paths.CartellaBackupRete, Environment.MachineName)
            Dim DestEmmeAgenzia As String = Path.Combine(DestinazioneEmme, Agenzia)

            Directory.CreateDirectory(DestEmmeAgenzia)

            Dim fi As New FileInfo(FileBackup)
            Dim PathDestinazione As String = Path.Combine(DestEmmeAgenzia, fi.Name)

            If Utx.NetFunc.FileToMD5(PathDestinazione) <> Utx.NetFunc.FileToMD5(fi.FullName) Then
                File.Copy(fi.FullName, PathDestinazione, True)
            End If

            'sincronizzo le date dei due file
            AggiornaDataModifica(PathDestinazione, fi.LastWriteTime)

            Globale.Log.Info("Sincronizzato backup su M: per l'agenzia " + Agenzia)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Class Tabella

        Sub New(Database As String, Nome As String, Records As Integer)
            _Database = Path.GetFileNameWithoutExtension(Database)
            _Nome = Nome
            _Records = Records
        End Sub

        Private _Database As String
        Public Property Database() As String
            Get
                Return _Database
            End Get
            Set(ByVal value As String)
                _Database = value
            End Set
        End Property

        Private _Nome As String
        Public Property Nome() As String
            Get
                Return _Nome
            End Get
            Set(ByVal value As String)
                _Nome = value
            End Set
        End Property

        Private _Records As Integer
        Public Property Records() As Integer
            Get
                Return _Records
            End Get
            Set(ByVal value As Integer)
                _Records = value
            End Set
        End Property
    End Class
End Class
