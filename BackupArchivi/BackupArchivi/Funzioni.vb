Option Compare Text

Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports System.Data.OleDb
Imports System.Environment

Module Funzioni

    Friend Function IdFileBak(ByVal Agenzia As String, ByVal Giorno As Date) As String
        'restituisce il nome del file zip per il backup
        Try
            Return Path.Combine(IdDirBak(Agenzia), String.Format("Giorno{0}.zip", Format(Giorno, "dd")))
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return "ERR"
        End Try
    End Function

    Friend Function IdFileBakLog() As String
        'restituisce il nome del db per il log in locale
        Try
            Dim DbLog As String = Path.Combine(Utx.Globale.Paths.CartellaBackup, "BackupLog.mdb")
            If File.Exists(DbLog) = False Then
                File.Copy(Path.Combine(Utx.Globale.Paths.CartellaModelli, "BackupLog.mdb"), DbLog)
            End If
            Return DbLog
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return "ERR"
        End Try
    End Function

    Friend Function IdFileBakLogEmme() As String
        'restituisce il nome del db per il log in rete
        Try
            Dim DbLog As String = Path.Combine(Utx.Globale.Paths.CartellaBackupRete, "BackupLog.mdb")
            If File.Exists(DbLog) = False Then
                File.Copy(Path.Combine(Utx.Globale.Paths.CartellaModelli, "BackupLog.mdb"), DbLog)
            End If
            Return DbLog
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return "ERR"
        End Try
    End Function

    Friend Function IdFileBakMensile(ByVal Agenzia As String) As String
        'restituisce il nome del file zip per il backup mensile
        Try
            Return Path.Combine(IdDirBak(Agenzia), Format(DateTime.Now, "MM-yyyy") + ".zip")
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return "ERR"
        End Try
    End Function

    Friend Function IdFileBakComuni(ByVal Giorno As Date) As String
        'restituisce il nome del file zip per il backup
        Try
            Return Path.Combine(IdDirBak("00000"), "Giorno" + Format(Giorno, "dd") + ".zip")
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return "ERR"
        End Try
    End Function

    Friend Function IdDirBak(ByVal Agenzia As String) As String
        'restituisce il nome della directory per il backup
        Try
            Dim DirBackupAgenzia As String = Path.Combine(Utx.Globale.Paths.CartellaBackup, Agenzia.Trim.PadLeft(5, "0"))
            If Not Directory.Exists(DirBackupAgenzia) Then Directory.CreateDirectory(DirBackupAgenzia)

            Return DirBackupAgenzia

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return "ERR"
        End Try
    End Function

    Friend Function AperturaMdb(ByVal FileMdb As String) As Boolean
        'controlla se è possibile aprire l'mdb
        Try
            Using c As New OleDbConnection(Utx.Globale.MDBDriver + FileMdb)
                c.Open()
            End Using

            Return True

        Catch ex As Exception
            Return False 'errore: è bloccato
        End Try
    End Function

    Friend Function Tabella2Db(ByVal NomeTabella As String) As String
        Try
            For Each Tbl As Tabella In Globale.StrutturaTabelle
                If Tbl.Nome = NomeTabella Then
                    Return Tbl.Database + ".mdb"
                End If
            Next
            Return ""
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Friend Function NomeDb2Path(ByVal NomeDb As String, ByVal Agenzia As String) As String

        NomeDb = Path.GetFileNameWithoutExtension(NomeDb)

        Select Case NomeDb
            Case "Supporto", "Sms", "Comunicazioni"
                Return String.Format("{0}\00000\{1}.mdb", Utx.Globale.Paths.CartellaDati, NomeDb)
            Case Else
                Return String.Format("{0}\{1}\{2}.mdb", Utx.Globale.Paths.CartellaDati, Agenzia.PadLeft(5, "0"), NomeDb)
        End Select
    End Function

    Friend Function CartellaRipristino() As String
        Return Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "Ripristino")
    End Function

    Friend Function NomeDb2Modello(ByVal NomeDb As String) As String

        NomeDb = Path.GetFileNameWithoutExtension(NomeDb)

        Select Case NomeDb
            Case "Supporto", "Sms", "Comunicazioni"
                Return Path.Combine(Utx.Globale.Paths.CartellaModelliDatiComuni, NomeDb + ".mdb")

            Case Else
                Return Path.Combine(Utx.Globale.Paths.CartellaModelliDatiAgenzia, NomeDb + ".mdb")
        End Select
    End Function

    Friend Function EspandiBackup(ByVal FileBackup As String) As Boolean
        Try
            If File.Exists(FileBackup) = True Then

                Dim Agenzia As String = New FileInfo(FileBackup).Directory.Name

                'estrai dati agenzia
                Utx.LibreriaZip.SevenZip.UnzipFile(FileBackup, CartellaRipristino)
                'estrai dati comuni
                Utx.LibreriaZip.SevenZip.UnzipFile(FileBackup.Replace("\" + Agenzia + "\", "\00000\"), CartellaRipristino)

                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' ripristina la tabella
    ''' </summary>
    ''' <param name="CodiceAgenzia">codice dell'agenzia</param>
    ''' <param name="NomeTabella">nome della tabella</param>
    ''' <returns>numero di record dopo il ripristino</returns>
    ''' <remarks></remarks>
    Friend Function RipristinaTabella(ByVal CodiceAgenzia As String,
                                      ByVal NomeTabella As String,
                                      ByRef CreazioneChiavi As Boolean) As Integer
        Try
            Dim Db As String = Tabella2Db(NomeTabella)
            Dim DbOrigine As String = Path.Combine(CartellaRipristino, Db)

            Dim DbDest As String
            Select Case Db.ToLower
                Case "supporto.mdb", "sms.mdb", "comunicazioni.mdb"
                    DbDest = Path.Combine(Utx.Globale.Paths.CartellaDati, "00000\" + Db)
                Case Else
                    DbDest = Path.Combine(Utx.Globale.Paths.CartellaDati, CodiceAgenzia + "\" + Db)
            End Select

            Using cn As New OleDbConnection(Utx.Globale.MDBDriver + DbDest)
                cn.Open()

                Using cmd As New OleDbCommand
                    'cancella la tabella da ripristinare
                    Try
                        cmd.Connection = cn
                        cmd.CommandText = "DROP TABLE " + NomeTabella
                        cmd.ExecuteNonQuery()
                    Catch ex As Exception
                        Globale.Log.Info(ex.Message) 'solo log NO errore
                    End Try

                    'ripristina da backup
                    cmd.CommandText = String.Format("SELECT * INTO {0} FROM {0} IN '{1}'", NomeTabella, DbOrigine)

                    RipristinaTabella = cmd.ExecuteNonQuery()
                End Using
            End Using

            Try
                'ricreo eventuali chiavi
                Select Case NomeTabella.ToLower
                    Case "clienti"
                        CreaChiaviClienti(CodiceAgenzia)
                    Case "polizze"
                        CreaChiaviPolizze(CodiceAgenzia)
                    Case "sinistri"
                        CreaChiaviSinistri(CodiceAgenzia)
                    Case "sinistridp", "sinistrida", "sinistriac"
                        CreaChiaviSinistri(CodiceAgenzia)
                End Select

                CreazioneChiavi = True

            Catch ex As Exception
                Globale.Log.Errore(ex)
                CreazioneChiavi = False
            End Try

        Catch ex As Exception
            Globale.Log.Errore(ex)
            MsgBox(ex.Message + Environment.NewLine + Environment.NewLine +
                   "Provare ad eseguire di nuovo la procedura scegliendo un altro backup.",
                   MsgBoxStyle.Exclamation, "Ripristino")
            RipristinaTabella = 0
        End Try
    End Function

    Friend Function SostituisciDb(ByVal Db As String,
                                  Optional ByVal DbVuoto As Boolean = False) As Boolean

        Dim finfo As FileInfo = New FileInfo(Db)
        Dim FileModello As String

        Try
            If DbVuoto Then
                FileModello = Path.Combine(Utx.Globale.Paths.CartellaModelli, "Vuoto.mdb")
            Else
                Select Case finfo.Name
                    Case "Supporto.mdb", "Sms.mdb", "Comunicazioni.mdb"
                        FileModello = Path.Combine(Utx.Globale.Paths.CartellaModelliDatiComuni, finfo.Name)
                    Case Else
                        FileModello = Path.Combine(Utx.Globale.Paths.CartellaModelliDatiAgenzia, finfo.Name)
                End Select
            End If

            'cancello il file da sostituire
            File.Delete(Db)
            'sostituisco con il modello
            File.Copy(FileModello, Db)

            Return True

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Friend Sub RiempiComboBackupLocale(ByRef cbo As ComboBox, ByVal Agenzia As Integer)
        'la lista dei backup disponibili non la prendo dal db  che potrebbe non essere
        'disponibile. faccio una scansione di tutti i file nella cartella del backup dell'agenzia
        Try
            'lista dei file di backup, la ordino
            Dim ListaFile() As Object = New DirectoryInfo(IdDirBak(Agenzia)).GetFiles("*.zip")
            Array.Sort(ListaFile, New FileDateSorter)

            'aggiungo i fileinfo al combo
            cbo.Items.Clear()

            For Each f As FileInfo In ListaFile
                cbo.Items.Add(New OrigineBackup(f.FullName, My.Computer.Name))
            Next

            cbo.DisplayMember = "InfoBackup"

            If cbo.Items.Count > 0 Then
                cbo.SelectedIndex = 0
                cbo.Enabled = True
            Else
                cbo.Enabled = False
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Friend Sub RiempiComboBackupRete(ByRef cbo As ComboBox, ByVal Agenzia As Integer)
        'la lista dei backup disponibili la prendo dal db log su emme
        Try
            Using c As New OleDbConnection(Utx.Globale.MDBDriver + IdFileBakLogEmme())
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT DISTINCT A.Pc,A.Agenzia,A.Filebackup,A.Aggiornamento " +
                                      "FROM Log AS A " +
                                      "INNER JOIN " +
                                            "(SELECT Count(*), Max(aggiornamento) AS UltimoAggiornamento,Filebackup " +
                                             "FROM Log " +
                                             "WHERE Agenzia = ? " +
                                             "GROUP BY Filebackup " +
                                             "HAVING Count(*) > 1) AS B " +
                                      "ON (A.Filebackup = B.Filebackup) " +
                                      "WHERE(A.Aggiornamento = B.UltimoAggiornamento) " +
                                      "ORDER BY A.Aggiornamento DESC"

                    cmd.Parameters.AddWithValue("Agenzia", Agenzia.ToString.PadLeft(5, "0"))

                    Dim dr As OleDbDataReader = cmd.ExecuteReader

                    'aggiungo i fileinfo al combo
                    cbo.Items.Clear()

                    Do While dr.Read

                        Dim PathFile As String = String.Format("{0}\{1}\{2}", dr("Pc"), dr(1), dr(2))
                        PathFile = Path.Combine(Utx.Globale.Paths.CartellaBackupRete, PathFile)

                        If File.Exists(PathFile) Then
                            cbo.Items.Add(New OrigineBackup(PathFile, dr("Pc")))
                        End If
                    Loop

                    dr.Close()
                End Using
            End Using

            cbo.DisplayMember = "InfoBackup"

            If cbo.Items.Count > 0 Then
                cbo.SelectedIndex = 0
                cbo.Enabled = True
            Else
                cbo.Enabled = False
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Class FileDateSorter
        Implements IComparer

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
            Return Date.Compare(y.LastWriteTime, x.LastWriteTime)
        End Function
    End Class

    ''' <summary>
    ''' cancello eventuali file difettosi annotati nell'esecuzione precedente
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub CancellaFileCorrotto()
        On Error Resume Next
        'se c'è un file corrotto lo cancello
        If My.Settings.FileCorrotto.Length > 0 Then File.Delete(My.Settings.FileCorrotto)

        My.Settings.FileCorrotto = ""
        My.Settings.Save()
    End Sub

    Friend Sub SvuotaDir(ByVal PathCartella As String)
        Try
            If Directory.Exists(PathCartella) Then
                For Each f As String In Directory.GetFiles(PathCartella)
                    File.Delete(f)
                Next
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Friend Function NomeDominio() As String
        Return System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName.ToLower
    End Function

    Friend Sub ChiudiUnitools()
        For Each p As Process In System.Diagnostics.Process.GetProcessesByName("Unitools")
            p.Kill()
        Next
    End Sub

    Function DbComuni(ByVal NomeDb As String) As Boolean
        For Each db As Database In Globale.DbComuni
            If db.Nome = NomeDb Then Return True
        Next
    End Function

    Friend Sub AggiornaDataModifica(ByVal PathFile As String,
                                    ByVal DataOraModifica As Date)

        Dim fi As New FileInfo(PathFile)
        fi.LastWriteTime = DataOraModifica
    End Sub

    Friend Sub ControlloMdbLog()

        Try
            'log locale
            If Not File.Exists(IdFileBakLog()) Then
                File.Copy(Path.Combine(Utx.Globale.Paths.CartellaModelli, "BackupLog.mdb"), IdFileBakLog())
            End If

            'log di rete
            If Utx.FunzioniRete.ReteAttiva = True Then
                If Not File.Exists(IdFileBakLogEmme()) Then
                    File.Copy(Path.Combine(Utx.Globale.Paths.CartellaModelli, "BackupLog.mdb"), IdFileBakLogEmme())
                End If
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

    End Sub

    Public Function SessioneRDP() As Boolean
        On Error Resume Next
        SessioneRDP = (GetEnvironmentVar("SESSIONNAME").Substring(0, 7).ToUpper) = "RDP-TCP"
    End Function

    Friend Function GetEnvironmentVar(ByVal VarName As String) As String
        If GetEnvironmentVariable(VarName) = Nothing Then
            GetEnvironmentVar = ""
        Else
            GetEnvironmentVar = GetEnvironmentVariable(VarName)
        End If
    End Function

    Public Function CreaChiaviClienti(ByVal Agenzia As String) As Boolean

        Globale.Log.Info("Ricreo le chiavi clienti")

        Dim c As New OleDb.OleDbConnection
        Dim cmd As New OleDb.OleDbCommand

        Try
            c.ConnectionString = Utx.Globale.MDBDriver + NomeDb2Path("Clienti", Agenzia)
            c.Open()

            cmd.Connection = c
            cmd.CommandType = CommandType.Text

            Try
                'cancello le chiavi se ci sono
                cmd.CommandText = "ALTER TABLE Clienti DROP CONSTRAINT pk_clienti"
                cmd.ExecuteNonQuery()

            Catch ex As Exception
            End Try

            'elimino eventuali null
            cmd.CommandText = "DELETE * " +
                              "FROM Clienti " +
                              "WHERE AgenziaPrevalente Is Null Or CodiceFiscale Is Null"
            cmd.ExecuteNonQuery()

            'creo le chiavi
            cmd.CommandText = "ALTER TABLE Clienti " +
                              "ADD CONSTRAINT pk_clienti " +
                              "PRIMARY KEY (AgenziaPrevalente,CodiceFiscale)"
            cmd.ExecuteNonQuery()

            CreaChiaviClienti = True

        Catch ex As Exception
            Globale.Log.Errore(ex)
            CreaChiaviClienti = False
        Finally
            cmd.Dispose()
            c.Close()
            c.Dispose()
        End Try

    End Function

    Public Function CreaChiaviPolizze(ByVal Agenzia As String) As Boolean

        Globale.Log.Info("Ricreo le chiavi polizze")

        Dim c As New OleDb.OleDbConnection
        Dim cmd As New OleDb.OleDbCommand

        Try
            c.ConnectionString = Utx.Globale.MDBDriver + NomeDb2Path("Polizze", Agenzia)
            c.Open()

            cmd.Connection = c
            cmd.CommandType = CommandType.Text

            Try
                'cancello le chiavi se ci sono
                cmd.CommandText = "ALTER TABLE Clienti DROP CONSTRAINT pk_clienti"
                cmd.ExecuteNonQuery()

            Catch ex As Exception
            End Try

            'elimino eventuali null
            cmd.CommandText = "DELETE * " +
                              "FROM Polizze " +
                              "WHERE Agenzia Is Null Or Ramo Is Null Or Polizza Is Null"
            cmd.ExecuteNonQuery()

            'creo le chiavi
            cmd.CommandText = "ALTER TABLE Polizze " +
                              "ADD CONSTRAINT pk_polizze " +
                              "PRIMARY KEY (Agenzia,Ramo,Polizza)"
            cmd.ExecuteNonQuery()

            CreaChiaviPolizze = True

        Catch ex As Exception
            Globale.Log.Errore(ex)
            CreaChiaviPolizze = False
        Finally
            cmd.Dispose()
            c.Close()
            c.Dispose()
        End Try

    End Function

    Public Function CreaChiaviSinistri(ByVal Agenzia As String) As Boolean

        Globale.Log.Info("Ricreo le chiavi sinistri")

        Dim c As New OleDb.OleDbConnection
        Dim cmd As New OleDb.OleDbCommand

        Try
            c.ConnectionString = Utx.Globale.MDBDriver + NomeDb2Path("Sinistri", Agenzia)
            c.Open()

            cmd.Connection = c
            cmd.CommandType = CommandType.Text

            Try
                'cancello le chiavi se ci sono
                cmd.CommandText = "ALTER TABLE Sinistri DROP CONSTRAINT pk_sinistri"
                cmd.ExecuteNonQuery()

            Catch ex As Exception
            End Try

            'elimino eventuali null
            cmd.CommandText = "DELETE * " +
                              "FROM Sinistri " +
                              "WHERE AgenziaSinistro IS Null OR EsercizioSinistro IS Null OR NumeroSinistro IS Null"
            cmd.ExecuteNonQuery()

            'creo le chiavi
            cmd.CommandText = "ALTER TABLE Sinistri " +
                              "ADD CONSTRAINT pk_sinistri " +
                              "PRIMARY KEY (AgenziaSinistro,EsercizioSinistro,NumeroSinistro)"
            cmd.ExecuteNonQuery()

            CreaChiaviSinistri = True

        Catch ex As Exception
            Globale.Log.Errore(ex)
            CreaChiaviSinistri = False
        Finally
            cmd.Dispose()
            c.Close()
            c.Dispose()
        End Try
    End Function
End Module
