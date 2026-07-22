Imports System.Xml
Imports System.IO
Imports System.Data.SqlClient

Public Class GestioneDatabase

    Public Shared Event Messaggio(messaggio As String)

    'Private sqlServerConnectionString As String = "Persist Security Info=false;Integrated Security=false;Data Source={0}\UNITOOLS;User ID=dbunitools;Password=unitoolsadm;"
    Private sqlServerConnectionString As String = "Data Source=SQL6007.site4now.net;Initial Catalog=DB_A4A4CA_pecoraro;User Id=DB_A4A4CA_pecoraro_admin;Password=NOfaste01;"
    Private Shared Log As New Utx.ApplicationLog("GestioneDatabase", LogCondiviso:=True)

    Public Enum TipoDatabase
        COMUNE
        AGENZIA
    End Enum
    Public Enum RecoveryModel
        SIMPLE
        BULK_LOGGED
        FULL
    End Enum

    Sub New(CodiceAgenzia As String)
        Me.CodiceAgenzia = CodiceAgenzia
        sqlServerConnectionString = String.Format(sqlServerConnectionString, GestioneDatabase.ServerSQL)

        If CodiceAgenzia = "00000" Then
            mTipoDB = TipoDatabase.COMUNE
        Else
            mTipoDB = TipoDatabase.AGENZIA
        End If
    End Sub

    Private Shared mServerSQL As String
    Public Shared Property ServerSQL() As String
        Get
#If DEBUG Then
            Select Case Environment.MachineName
                Case "X390-GUIDO"
                    Return Environment.MachineName
                Case Else
                    Return "(localdb)"
            End Select
#Else
            Return Environment.MachineName
#End If
        End Get
        Set(value As String)
            mServerSQL = value
        End Set
    End Property

    Private mCodiceAgenzia As String
    Public Property CodiceAgenzia() As String
        Get
            Return mCodiceAgenzia
        End Get
        Set(value As String)
            mCodiceAgenzia = value.Trim.PadLeft(5, "0")
        End Set
    End Property

    Public ReadOnly Property PathFileDB() As String
        Get
            Dim PosizioneDB As String = Utx.Globale.Paths.CartellaDati
            'If Utx.FunzioniRete.PcInDominio Then
            '    PosizioneDB = "C:\Direzione\Unitools\Dati"
            'Else
            '    PosizioneDB = "C:\ApplicazioniDirezione\Unitools\Dati"
            'End If
            Directory.CreateDirectory(PosizioneDB)
            Return PosizioneDB
        End Get
    End Property

    Public ReadOnly Property EsisteDB(c As SqlConnection) As Boolean
        Get
            Using cmd As New SqlCommand()
                cmd.Connection = c
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT COUNT(*) FROM sys.databases WHERE name = N'DB{agenzia}'".Replace("{agenzia}", CodiceAgenzia)
                Return cmd.ExecuteScalar > 0
            End Using
        End Get
    End Property

    Public ReadOnly Property EsisteTabella(c As SqlConnection, Tabella As String) As Boolean
        Get
            Using cmd As New SqlCommand()
                cmd.Connection = c
                cmd.CommandType = CommandType.Text
                cmd.CommandText = String.Format("USE {0} SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'{1}'", NomeDB, Tabella)
                Return cmd.ExecuteScalar > 0
            End Using
        End Get
    End Property

    Public ReadOnly Property EsisteSinonimo(c As SqlConnection, Sinonimo As String) As Boolean
        Get
            Using cmd As New SqlCommand()
                cmd.Connection = c
                cmd.CommandType = CommandType.Text
                cmd.CommandText = String.Format("USE {0} SELECT COUNT(*) FROM SYS.SYNONYMS WHERE NAME = N'{1}'", NomeDB, Sinonimo)
                Return cmd.ExecuteScalar > 0
            End Using
        End Get
    End Property

    Private mTipoDB As TipoDatabase
    Public ReadOnly Property TipoDB() As String
        Get
            Return mTipoDB.ToString.ToLower
        End Get
    End Property

    Public ReadOnly Property NomeDB() As String
        Get
            'Return "DB" & CodiceAgenzia
            Return "DB_A4A4CA_pecoraro"
        End Get
    End Property

    Private mDbPrimaryKey As DataTable
    Public ReadOnly Property DbprimaryKey() As DataTable
        Get
            If mDbPrimaryKey Is Nothing Then
                getPrimaryKey()
            End If
            Return mDbPrimaryKey
        End Get
    End Property

    Private mDbIndex As DataTable
    Public ReadOnly Property DbIndex() As DataTable
        Get
            If mDbIndex Is Nothing Then
                getDbIndex()
            End If
            Return mDbIndex
        End Get
    End Property

    Private mErrori As Integer
    Public ReadOnly Property Errori() As Integer
        Get
            Return mErrori
        End Get
    End Property

    Public Shared Sub Migrazione()
        Log.Info("Migrazione dati a SQL Server")
        Log.Info()

        Dim ListaCodici As List(Of String) = Utx.EnteGestore.CodiciGestiti
        ListaCodici.Insert(0, "00000")

        For Each agenzia In ListaCodici
            Dim Db As New Utx.GestioneDatabase(agenzia)
            'If Db.CreaDatabase = True Then
            If Db.CreaTabelle() = True Then
                Db.ImportaDatabase()
                Db.CreaIndici()
                'Db.CreaSinonimi()
            End If
            'End If
            Log.Info("Importazione database {0} terminata (Errori {1})", {Db.NomeDB, Db.Errori})
            Log.Info()
            RaiseEvent Messaggio(String.Format("Importazione database {0} terminata (Err.{1})", Db.NomeDB, Db.Errori))
        Next
    End Sub

    Public Function RecordsTabella(Tabella As String) As Integer
        Try
            Using c As New SqlConnection(sqlServerConnectionString)
                c.Open()

                Using cmd As New SqlCommand
                    cmd.Connection = c
                    cmd.CommandText = "USE {0} " +
                                      "SELECT P.[ROWS] FROM SYS.TABLES T " +
                                      "INNER JOIN SYS.PARTITIONS P ON T.OBJECT_ID = P.OBJECT_ID " +
                                      "WHERE T.NAME = '{1}'"
                    cmd.CommandText = String.Format(cmd.CommandText, NomeDB, Tabella)

                    Return cmd.ExecuteScalar
                End Using
            End Using

        Catch ex As Exception
            Log.Errore(ex)
            Return -1
        End Try
    End Function

    Private Sub getPrimaryKey()
        Try
            Using c As New SqlConnection(sqlServerConnectionString)
                c.Open()

                Using cmd As New SqlCommand
                    cmd.Connection = c
                    cmd.CommandText = "USE {0} " +
                                      "SELECT kcu.TABLE_SCHEMA, kcu.TABLE_NAME, kcu.CONSTRAINT_NAME, kcu.COLUMN_NAME, kcu.ORDINAL_POSITION " +
                                      "FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS as tc " +
                                      "JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE as kcu " +
                                      "ON kcu.CONSTRAINT_SCHEMA = tc.CONSTRAINT_SCHEMA AND " +
                                         "kcu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME AND " +
                                         "kcu.TABLE_SCHEMA = tc.TABLE_SCHEMA " +
                                      "WHERE tc.CONSTRAINT_TYPE = 'PRIMARY KEY'"
                    cmd.CommandText = String.Format(cmd.CommandText, NomeDB)

                    Using da As New SqlDataAdapter(cmd)
                        mDbPrimaryKey = New DataTable
                        da.Fill(mDbPrimaryKey)
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub getDbIndex()
        Try
            Using c As New SqlConnection(sqlServerConnectionString)
                c.Open()

                Using cmd As New SqlCommand
                    cmd.Connection = c
                    cmd.CommandText = "USE {0} " +
                                      "SELECT so.name AS Tabella, si.name AS Indice, si.type_desc AS Tipo " +
                                      "FROM sys.indexes si " +
                                      "JOIN sys.objects AS so ON si.[object_id] = so.[object_id] " +
                                      "WHERE (so.type = 'U') AND (si.name IS NOT NULL) AND si.is_primary_key = 0 " +
                                      "ORDER BY so.name, si.type"
                    cmd.CommandText = String.Format(cmd.CommandText, NomeDB)

                    Using da As New SqlDataAdapter(cmd)
                        mDbIndex = New DataTable
                        da.Fill(mDbIndex)
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Function IsPrimaryKeyColumn(Tabella As String, Campo As String) As Boolean
        For Each row As DataRow In Me.DbprimaryKey.Rows
            If row("TABLE_NAME") = Tabella AndAlso row("COLUMN_NAME") = Campo Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function EsistePrimaryKey(Tabella As String) As Boolean
        For Each row As DataRow In Me.DbprimaryKey.Rows
            If row("TABLE_NAME") = Tabella Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function EsisteIndice(Tabella As String, Indice As String) As Boolean
        For Each row As DataRow In Me.DbIndex.Rows
            If row("Tabella") = Tabella AndAlso row("Indice") = Indice Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Shared Function getScript() As String
        Return CType(My.Resources.ResourceManager.GetObject("ScriptDataBase"), String).Replace("YESNO", "BIT")
    End Function

    Public Function CreaDatabase(Optional Sovrascrivere As Boolean = False) As Boolean
        Try
            Dim Doc As New XmlDocument
            Doc.LoadXml(getScript)
            Dim node As XmlNode = Doc.SelectSingleNode(String.Format("//script/database[@tipo='{0}']/sql[@operazione='create']", Me.TipoDB))

            If node IsNot Nothing Then
                Using c As New SqlConnection(sqlServerConnectionString)
                    c.Open()

                    Using cmd As New SqlCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = node.InnerText.Replace("{path}", PathFileDB).Replace("{agenzia}", CodiceAgenzia)

                        If Me.EsisteDB(c) = False Then
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = String.Format("ALTER DATABASE [{0}] SET AUTO_CLOSE OFF", NomeDB)
                            cmd.ExecuteNonQuery()
                        End If
                    End Using
                End Using

                SetRecoveryModel(RecoveryModel.SIMPLE)
            End If
            Return True

        Catch ex As Exception
            Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Function SetRecoveryModel(Modello As RecoveryModel) As Boolean
        Try
            Using c As New SqlConnection(sqlServerConnectionString)
                c.Open()

                Using cmd As New SqlCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = String.Format("ALTER DATABASE [{0}] SET RECOVERY {1}", NomeDB, Modello.ToString)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return True

        Catch ex As Exception
            Log.Errore(ex)
            Return False
        End Try
    End Function

    'Public Shared Function QueryTabella(Tabella As String, TipoDB As TipoDatabase) As String
    '    Try
    '        Dim Doc As New XmlDocument
    '        Doc.LoadXml(getScript)
    '        Dim node As XmlNode = Doc.SelectSingleNode(String.Format("//script/database[@tipo='{0}']/tabelle/sql[@tabella='[{1}]'][@operazione='create']",
    '                                                                 TipoDB.ToString.ToLower, Tabella.ToLower))

    '        If node IsNot Nothing Then
    '            Return node.InnerText
    '        Else
    '            Return "-ERR"
    '        End If

    '    Catch ex As Exception
    '        Log.Errore(ex)
    '        Return "-ERR"
    '    End Try
    'End Function

    Public Function CreaTabella(c As SqlConnection, Tabella As String, Optional Sovrascrivere As Boolean = False) As Boolean
        Try
            Dim Doc As New XmlDocument
            Doc.LoadXml(getScript)
            Dim node As XmlNode = Doc.SelectSingleNode(String.Format("//script/database[@tipo='{0}']/tabelle/sql[@tabella='[{1}]'][@operazione='create']", Me.TipoDB, Tabella.ToLower))

            If node IsNot Nothing Then
                Using cmd As New SqlCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text

                    If Sovrascrivere = True AndAlso EsisteTabella(c, Tabella) Then
                        cmd.CommandText = String.Format("USE {0} DROP TABLE {1}", NomeDB, Tabella)
                        cmd.ExecuteNonQuery()
                    End If

                    cmd.CommandText = String.Format("USE {0} IF OBJECT_ID(N'dbo.{1}', N'U') IS NULL BEGIN {2} END", NomeDB, Tabella, node.InnerText)
                    cmd.ExecuteNonQuery()
                End Using
            End If
            Return True

        Catch ex As Exception
            Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Shared Function CreaTabellaMdb(c As OleDb.OleDbConnection, TipoDB As TipoDatabase, Tabella As String, Optional Sovrascrivere As Boolean = False) As Boolean
        Try
            Log.Info("Creazione tabella {0} del tipo {1}", {Tabella, TipoDB.ToString})

            Dim Doc As New XmlDocument
            Doc.LoadXml(getScript)
            Dim node As XmlNode = Doc.SelectSingleNode(String.Format("//script/database[@tipo='{0}']/tabelle/sql[@tabella='[{1}]'][@operazione='create']",
                                                                     TipoDB.ToString.ToLower, Tabella.ToLower))

            If node IsNot Nothing Then
                Using cmd As New OleDb.OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text

                    If Sovrascrivere = True Then
                        Utx.FunzioniDb.CancellaTabella(c, Tabella)
                    End If

                    'se non esiste la creo
                    If Utx.FunzioniDb.EsisteTabella(c, Tabella) = False Then
                        cmd.CommandText = Replace(node.InnerText, "dbo.", "", Compare:=CompareMethod.Text)
                        cmd.CommandText = Replace(cmd.CommandText, "NVARCHAR(max)", "MEMO", Compare:=CompareMethod.Text)
                        cmd.CommandText = Replace(cmd.CommandText, " BIT,", " YESNO,", Compare:=CompareMethod.Text)
                        cmd.CommandText = Replace(cmd.CommandText, " SMALLDATETIME,", " DATE,", Compare:=CompareMethod.Text)
                        cmd.CommandText = Replace(cmd.CommandText, " DATETIME,", " DATE,", Compare:=CompareMethod.Text)
                        cmd.CommandText = Replace(cmd.CommandText, " DATETIME2,", " DATE,", Compare:=CompareMethod.Text)
                        cmd.ExecuteNonQuery()
                    End If
                End Using
            End If
            Return True

        Catch ex As Exception
            Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Function CreaTabelle() As Boolean
        Try
            Dim Doc As New XmlDocument
            Doc.LoadXml(getScript)
            Dim ListaTabelle As XmlNodeList = Doc.SelectNodes(String.Format("//script/database[@tipo='{0}']/tabelle/sql[@operazione='create']", Me.TipoDB))

            Using c As New SqlConnection(sqlServerConnectionString)
                c.Open()

                Using cmd As New SqlCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text

                    For Each tabella As XmlNode In ListaTabelle
                        cmd.CommandText = String.Format("USE {0} IF OBJECT_ID(N'dbo.{1}', N'U') IS NULL BEGIN {2} END", NomeDB, tabella.Attributes("tabella").Value, tabella.InnerText)
                        cmd.ExecuteNonQuery()
                    Next
                End Using
            End Using
            Return True

        Catch ex As Exception
            Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Function CreaSinonimi() As Boolean
        Try
            If CodiceAgenzia <> "00000" Then

                RaiseEvent Messaggio(String.Format("Creazione sinonimi per {0}", NomeDB))
                Log.Info("{0}: creazione sinonimi", {CodiceAgenzia})

                Using c As New SqlConnection(sqlServerConnectionString)
                    c.Open()

                    Using cmd As New SqlCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "USE DB00000"
                        cmd.ExecuteNonQuery()

                        Dim Tabelle As DataRowCollection = c.GetSchema("Tables").Rows

                        For Each row As DataRow In Tabelle
                            cmd.CommandText = String.Format("USE {0} IF OBJECT_ID('dbo.[{1}]') IS NULL " +
                                                            "CREATE SYNONYM dbo.[{1}] FOR [DB00000].[dbo].[{1}]", NomeDB, row(2))
                            cmd.ExecuteNonQuery()
                        Next
                    End Using
                End Using
            End If
            Return True

        Catch ex As Exception
            Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Function CreaIndici() As Boolean
        Try
            Dim Doc As New XmlDocument
            Doc.LoadXml(getScript)
            Dim ListaIndici As XmlNodeList = Doc.SelectNodes(String.Format("//script/database[@tipo='{0}']/tabelle/sql[@operazione='createindex']", Me.TipoDB))

            RaiseEvent Messaggio(String.Format("Creazione indici per {0}", NomeDB))
            Log.Info("{0}: creazione indici", {CodiceAgenzia})

            Using c As New SqlConnection(sqlServerConnectionString)
                c.Open()

                Using cmd As New SqlCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text

                    'cancello gli indici esistenti
                    For Each indice As DataRow In Me.DbIndex.Rows
                        cmd.CommandText = String.Format("USE {0} DROP INDEX {1} ON {2}", NomeDB, indice("Indice"), indice("Tabella"))
                        cmd.ExecuteNonQuery()
                    Next
                    'ricreo gli indici
                    For Each indice As XmlNode In ListaIndici
                        cmd.CommandText = String.Format("USE {0} {1}", NomeDB, indice.InnerText)
                        cmd.ExecuteNonQuery()
                    Next
                End Using
            End Using
            Return True

        Catch ex As Exception
            Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Sub ImportaDatabase()
        Try
            mErrori = 0

            Using sqlServer As New SqlConnection(sqlServerConnectionString)
                sqlServer.Open()

                Using cmd As New SqlCommand
                    cmd.Connection = sqlServer
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "USE " & NomeDB
                    cmd.ExecuteNonQuery()
                End Using

                For Each database As String In getAccessDbs()
                    Log.Info("{0}: importazione database {1}", {CodiceAgenzia, database})
                    RaiseEvent Messaggio(CodiceAgenzia & ": importazione database " & database)

                    Using access As New OleDb.OleDbConnection(Utx.ConnessioniDb.ConnectionString(CodiceAgenzia, database))
                        access.Open()

                        For Each row As DataRow In access.GetSchema("Tables").Rows
                            If row(3).ToString = "TABLE" Then
                                Dim tabelleDaImportare As String = row(2).ToString

                                If Me.RecordsTabella(tabelleDaImportare) = 0 Then

                                    If sqlServer.GetSchema("Tables", {Nothing, Nothing, tabelleDaImportare}).Rows.Count > 0 Then
                                        Using bulkCopy As New SqlBulkCopy(sqlServer)
                                            bulkCopy.DestinationTableName = "dbo." & tabelleDaImportare
                                            bulkCopy.BulkCopyTimeout = 60

                                            ' legge la tabella di access
                                            Using cmd As New OleDb.OleDbCommand(getSelectCommand(sqlServer, tabelleDaImportare), access)
                                                Try
                                                    ' scrive la tabella in sql server
                                                    bulkCopy.WriteToServer(cmd.ExecuteReader)
                                                Catch ex As Exception
                                                    mErrori += 1
                                                    Log.Info("{0}.{1}.{2}: {3}", {CodiceAgenzia, database, tabelleDaImportare, ex.Message})
                                                End Try
                                            End Using
                                        End Using
                                    End If
                                End If
                            End If
                        Next 'tabella da importare

                        access.Close()
                    End Using 'close db access

                    RaiseEvent Messaggio("importazione database " & database & " terminata")
                Next database 'access

                sqlServer.Close()
            End Using 'close db sql server

            SetRecoveryModel(RecoveryModel.FULL)

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Public Function getAccessDbs() As String()
        Dim db As String()
        Select Case mTipoDB
            Case TipoDatabase.COMUNE
                db = Directory.GetFiles(Utx.Globale.Paths.CartellaModelliDatiComuni)
            Case Else
                db = Directory.GetFiles(Utx.Globale.Paths.CartellaModelliDatiAgenzia)
        End Select
        For k As Integer = 0 To db.GetUpperBound(0)
            db(k) = Path.GetFileNameWithoutExtension(db(k))
        Next
        Return db
    End Function

    Private Function getSelectCommand(c As SqlConnection, Tabella As String) As String
        Try
            Dim colonne As DataTable = c.GetSchema("Columns", {Nothing, Nothing, Tabella, Nothing})
            Dim sql As String = ""
            Dim GroupBy As String = ""
            Dim Where As String = ""

            If EsistePrimaryKey(Tabella) Then
                'c'è una chiave
                For Each row As DataRow In colonne.Select("", "ORDINAL_POSITION")
                    If IsPrimaryKeyColumn(Tabella, row("COLUMN_NAME")) Then
                        sql += String.Format("[{0}],", row("COLUMN_NAME"))
                        GroupBy += String.Format("[{0}],", row("COLUMN_NAME"))
                        Where += String.Format("(NOT [{0}] IS NULL) AND ", row("COLUMN_NAME"))
                    Else
                        sql += String.Format("LAST([{0}]),", row("COLUMN_NAME"))
                    End If
                Next

                Return String.Format("SELECT {0} FROM {1} WHERE {2} GROUP BY {3}",
                                     sql.Substring(0, sql.Length - 1),
                                     Tabella,
                                     Where.Substring(0, Where.Length - 4),
                                     GroupBy.Substring(0, GroupBy.Length - 1))
            Else
                'senza chiave
                For Each row As DataRow In colonne.Select("", "ORDINAL_POSITION")
                    sql += String.Format("[{0}],", row("COLUMN_NAME"))
                Next

                Return String.Format("SELECT {0} FROM {1}", sql.Substring(0, sql.Length - 1), Tabella)
            End If

        Catch ex As Exception
            Log.Errore(ex)
            Return ""
        End Try
    End Function

    Public Function CreaBackup() As Boolean
        Try
            'Dim Db As String = Path.Combine(Utx.Globale.Paths.CartellaDati, NomeDB + ".mdf")
            Dim Db As String = "U:\unitools\dati\" + NomeDB + ".mdf"

            If File.Exists(Db) Then
                'backup
                Dim BackupDB As String = Path.Combine(Utx.Globale.Paths.CartellaBackup, NomeDB + ".bak")
                Dim BackupLOG As String = Path.Combine(Utx.Globale.Paths.CartellaBackup, NomeDB + "_LOG.bak")

                Using c As New SqlConnection(sqlServerConnectionString)
                    c.Open()

                    Using cmd As New SqlCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        'db
                        cmd.CommandText = String.Format("USE {0} BACKUP DATABASE {0} TO DISK = '{1}'", NomeDB, BackupDB)
                        cmd.ExecuteNonQuery()
                        'log
                        cmd.CommandText = String.Format("USE {0} BACKUP LOG {0} TO DISK = '{1}'", NomeDB, BackupLOG)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
                'Utx.LibreriaZip.ZipFile(BackupDB, Path.ChangeExtension(BackupDB, "zip"))
                'File.Delete(BackupDB)
                'Utx.LibreriaZip.ZipFile(BackupLOG, Path.ChangeExtension(BackupLOG, "zip"))
                'File.Delete(BackupLOG)
                Return True
            Else
                Log.Info("Database '{0}' non trovato", {Db})
                Return False
            End If

        Catch ex As Exception
            Log.Info(ex)
            Return False
        End Try
    End Function
End Class
