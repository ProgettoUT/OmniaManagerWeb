Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO

Public Class DbManager
    Public Event Messaggio(ByVal messaggio As String)

    Private Log As New Utx.ApplicationLog("Migra2SqlServer", CartellaLog:=Utx.Globale.Paths.CartellaLogs, Sovrascrivi:=True)
    'importante
    'in locale utilizzo il comando da cmd "SqlLocalDb start unitools" per avviare l'istanza
#If DEBUGSTEFANO Then
    'Private sqlServerConnectionString As String = "Integrated Security=SSPI;Persist Security Info=False;Data Source=(localdb)\unitools"
    Private sqlServerConnectionString As String = "Provider=SQLOLEDB;Data Source=SQL6007.site4now.net;Initial Catalog=DB_A4A4CA_pecoraro;User Id=DB_A4A4CA_pecoraro_admin;Password=NOfaste01;"
#Else
    Private sqlServerConnectionString As String = "Persist Security Info=false;Integrated Security=false;Data Source={0}\UNITOOLS;User ID=dbunitools;Password=unitoolsadm;"
#End If
    Dim codiciDaMigrare As New List(Of String)

    Sub New()

#If DEBUG Then
        Select Case Environment.MachineName
            Case "LENOVOGUIDO"
                sqlServerConnectionString = String.Format(sqlServerConnectionString, Environment.MachineName)
            Case Else
                sqlServerConnectionString = String.Format(sqlServerConnectionString, "(localdb)")
        End Select
#Else
        sqlServerConnectionString = String.Format(sqlServerConnectionString, Environment.MachineName)
#End If
    End Sub

    Public Sub CreaDatabase()
        'legge la cartella dati:
        For Each Cartella As String In IO.Directory.GetDirectories(Utx.Globale.Paths.CartellaDati)
            Dim Agenzia = Path.GetFileName(Cartella)
            If IsNumeric(Agenzia) AndAlso Agenzia.Length = 5 Then
                CreaDatabase(Agenzia)
            End If
        Next
        RaiseEvent Messaggio("PROCEDURA CREAZIONE DATABASE TERMINATA")
    End Sub

    Public Sub CreaDatabase(ByVal agenzia As String)
        Try
            Log.Debug("Apro connessione con sql server")
            Using sqlServer As New SqlConnection(sqlServerConnectionString)
                sqlServer.Open()

                Using cmd As New SqlCommand
                    cmd.Connection = sqlServer
                    cmd.CommandType = CommandType.Text

                    For Each Sql As String In getSqls(agenzia)
                        If Sql.StartsWith("**") Then
                            RaiseEvent Messaggio(Sql.Substring(2))
                        ElseIf Not Sql.StartsWith("--") Then
                            Try
                                cmd.CommandText = String.Format(Sql, "C:\ApplicazioniDirezione\UT\Dati")
                                cmd.ExecuteNonQuery()
                            Catch ex As Exception
                                Log.Errore(Sql, False)
                                Log.Errore(ex, False)
                            End Try
                        End If
                    Next
                    codiciDaMigrare.Add(agenzia)
                    Log.Info("Database creato: " & agenzia)
                End Using
            End Using

        Catch ex As Exception
            Log.Info("errore creazione database: " & agenzia)
            RaiseEvent Messaggio(ex.Message)
            Log.Errore(ex)
        End Try
    End Sub

    Public Sub ImportaDatabase()
        Try
            Dim Errori As Integer = 0

            Using sqlServer As New SqlConnection(sqlServerConnectionString)
                sqlServer.Open()

                For Each agenzia As String In codiciDaMigrare
                    'seleziona il database
                    With sqlServer.CreateCommand()
                        .CommandType = CommandType.Text
                        .CommandText = "USE DB" & agenzia
                        .ExecuteNonQuery()
                    End With

                    For Each database As String In getAccessDbs(agenzia)
                        Log.Info("{0}: importazione database {1}", {agenzia, database})
                        RaiseEvent Messaggio(agenzia & ": importazione database " & database)

                        Using access As New OleDb.OleDbConnection(Utx.ConnessioniDb.ConnectionString(agenzia, database))
                            access.Open()

                            For Each row As DataRow In access.GetSchema("Tables").Rows
                                If row(3).ToString = "TABLE" Then
                                    Dim tabelleDaImportare As String = row(2).ToString

                                    If sqlServer.GetSchema("Tables", {Nothing, Nothing, tabelleDaImportare}).Rows.Count > 0 Then
                                        Using bulkCopy As New SqlBulkCopy(sqlServer)
                                            bulkCopy.DestinationTableName = "dbo." & tabelleDaImportare

                                            ' legge la tabella di access
                                            Using cmd As New OleDb.OleDbCommand(getSelectCommand(sqlServer, tabelleDaImportare), access)
                                                Try
                                                    ' scrive la tabella in sql server
                                                    bulkCopy.WriteToServer(cmd.ExecuteReader)
                                                Catch ex As Exception
                                                    Errori += 1
                                                    Log.Info("{0}.{1}.{2}: {3}", {agenzia, database, tabelleDaImportare, ex.Message})
                                                End Try
                                            End Using
                                        End Using
                                    End If
                                End If
                            Next 'tabella da importare

                            access.Close()
                        End Using 'close db access

                        RaiseEvent Messaggio("importazione database " & database & " terminata")
                    Next database 'access

                    CreaSinonimi(agenzia)
                    Log.Info("Migrazione agenzia {0} terminata", {agenzia})
                    Log.Info()
                Next agenzia

                sqlServer.Close()
            End Using 'close db sql server
            Log.Info("PROCEDURA IMPORTAZIONE DATABASE TERMINATA (Errori {0})", {Errori})
            RaiseEvent Messaggio(String.Format("PROCEDURA IMPORTAZIONE DATABASE TERMINATA (Err.{0})", Errori))

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Public Sub ImportaDatabase2(ByVal agenzia As String)
        Dim databases As String() = {"Clienti"}


        Using sqlServer As New OleDb.OleDbConnection(sqlServerConnectionString)
            sqlServer.Open()

            With sqlServer.CreateCommand()
                .CommandType = CommandType.Text
                .CommandText = "USE DB" & agenzia
                .ExecuteNonQuery()
            End With

            For Each database As String In databases
                RaiseEvent Messaggio("importazione database " & database)

                Using access As New OleDb.OleDbConnection(Utx.ConnessioniDb.ConnectionString(agenzia, database))
                    access.Open()

                    For Each row As DataRow In access.GetSchema("Tables").Rows
                        If row(3).ToString = "TABLE" Then
                            Dim tabelleDaImportare As String = row(2).ToString

                            ' legge la tabella di access
                            Dim tabella As New DataTable
                            Using cmd As New OleDb.OleDbCommand()
                                cmd.Connection = access
                                cmd.CommandType = CommandType.TableDirect
                                cmd.CommandText = tabelleDaImportare

                                Using da As New OleDb.OleDbDataAdapter(cmd)
                                    da.Fill(tabella)
                                End Using
                            End Using


                            ' scrive la tabella su sql server

                            Using cmd As New OleDb.OleDbCommand()
                                cmd.Connection = sqlServer
                                cmd.CommandType = CommandType.Text
                                cmd.CommandText = "select * from " & tabelleDaImportare

                                Using da As New OleDb.OleDbDataAdapter(cmd)
                                    Dim o As New OleDb.OleDbCommandBuilder(da)

                                    For Each riga As DataRow In tabella.Rows
                                        riga.SetAdded()
                                    Next
                                    da.Update(tabella)
                                End Using
                            End Using
                        End If
                    Next 'tabella da importare

                    access.Close()
                End Using 'close db access

                RaiseEvent Messaggio("importazione database " & database & " terminata")
            Next database 'access

            sqlServer.Close()
        End Using 'close db sql server
    End Sub

    Private Function getSelectCommand(c As SqlConnection, Tabella As String) As String
        Try
            Dim colonne As DataTable = c.GetSchema("Columns", {Nothing, Nothing, Tabella, Nothing})
            Dim sql As String = ""

            For Each row As DataRow In colonne.Select("", "ORDINAL_POSITION")
                sql += String.Format("[{0}],", row("COLUMN_NAME"))
            Next

            Return String.Format("SELECT {0} FROM {1}", sql.Substring(0, sql.Length - 1), Tabella)

        Catch ex As Exception
            Log.Errore(ex)
            Return ""
        End Try
    End Function

    Private Function CreaSinonimi(Agenzia As String) As Boolean
        Try
            If Agenzia <> "00000" Then

                RaiseEvent Messaggio(String.Format("Creazione sinonimi per DB{0}", Agenzia))

                Using c As New SqlConnection(sqlServerConnectionString)
                    c.Open()

                    Using cmd As New SqlCommand
                        cmd.Connection = c
                        cmd.CommandText = "USE DB00000"
                        cmd.ExecuteNonQuery()

                        Dim Tabelle As DataRowCollection = c.GetSchema("Tables").Rows

                        cmd.CommandText = "USE DB" & Agenzia
                        cmd.ExecuteNonQuery()

                        For Each row As DataRow In Tabelle
                            cmd.CommandText = String.Format("CREATE SYNONYM [dbo].[{0}] FOR [DB00000].[dbo].[{0}]", row(2))
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

    Private Function getSqls(ByVal agenzia As String) As List(Of String)
        Dim sqls As New List(Of String)
        Dim scriptName As String = "Database" & IIf(agenzia = "00000", "Supporto", "Agenzia")

        Dim script As String = CType(My.Resources.ResourceManager.GetObject(scriptName), String)
        script = script.Replace("{agenzia}", agenzia)

        For Each Sql As String In script.Split(";")
            Sql = Sql.Trim
            If Sql.Length > 0 Then
                sqls.Add(Sql)
            End If
        Next

        Return sqls
    End Function

    Public Shared Function getAccessDbs(ByVal agenzia As String) As String()
        Dim db As String()
        Select Case agenzia
            Case "comuni", "00000"
                db = Directory.GetFiles(Utx.Globale.Paths.CartellaModelliDatiComuni)
            Case Else
                db = Directory.GetFiles(Utx.Globale.Paths.CartellaModelliDatiAgenzia)
        End Select
        For k As Integer = 0 To db.GetUpperBound(0)
            db(k) = Path.GetFileNameWithoutExtension(db(k))
        Next
        Return db
    End Function

    Public Function VerificaDatabase() As Boolean
        Dim databaseIsOk As Boolean = True
        Try
            Dim colonneSqlServer As New List(Of String)
            Dim colonneAccess As New List(Of String)

            RaiseEvent Messaggio("Inizio verifica database ")
            Log.Info(">>> Inizio verifica database")

            Using sqlServer As New SqlConnection(sqlServerConnectionString)
                sqlServer.Open()

                For Each agenzia As String In codiciDaMigrare
                    'seleziona il database
                    With sqlServer.CreateCommand()
                        .CommandType = CommandType.Text
                        .CommandText = "USE DB" & agenzia
                        .ExecuteNonQuery()
                    End With


                    For Each row As DataRow In sqlServer.GetSchema("Tables").Rows
                        If row(3).ToString = "BASE TABLE" Then
                            Dim tabella As String = row("TABLE_NAME").ToString
                            For Each rowcols As DataRow In sqlServer.GetSchema("Columns", {Nothing, Nothing, tabella, Nothing}).Rows
                                colonneSqlServer.Add(agenzia & "." & tabella & "." & rowcols("COLUMN_NAME"))
                            Next
                        End If
                    Next 'tabella


                    For Each database As String In getAccessDbs(agenzia)

                        Using access As New OleDb.OleDbConnection(Utx.ConnessioniDb.ConnectionString(agenzia, database))
                            access.Open()

                            For Each row As DataRow In access.GetSchema("Tables").Rows
                                If row(3).ToString = "TABLE" Then
                                    Dim tabella As String = row("TABLE_NAME").ToString
                                    If sqlServer.GetSchema("Tables", {Nothing, Nothing, tabella}).Rows.Count > 0 Then
                                        For Each rowcols As DataRow In access.GetSchema("Columns", {Nothing, Nothing, tabella, Nothing}).Rows
                                            colonneAccess.Add(agenzia & "." & tabella & "." & rowcols("COLUMN_NAME"))
                                        Next
                                    End If
                                End If
                            Next 'tabella

                            access.Close()
                        End Using 'close db access

                    Next database 'access
                Next agenzia

                sqlServer.Close()
            End Using 'close db sql server

            For Each campo In colonneAccess
                If colonneSqlServer.Contains(campo) = False Then
                    Log.Errore(">>> " & campo & ": manca in SqlServer", False)
                    databaseIsOk = False
                Else
                    'Log.Errore(">>> " & campo & ": ok", False)
                End If
            Next

            For Each campo In colonneSqlServer
                If colonneAccess.Contains(campo) = False Then
                    Log.Errore(">>> " & campo & ": manca in access", False)
                    databaseIsOk = False
                Else
                    'Log.Errore(">>> " & campo & ": ok", False)
                End If
            Next

            Log.Info(">>> Fine verifica database")
            RaiseEvent Messaggio("PROCEDURA VERIFICA DATABASE TERMINATA")

        Catch ex As Exception
            Log.Errore(ex)
        End Try
        Return databaseIsOk
    End Function

    Public Sub VisualizzaLog()
        Log.ApriLog()
    End Sub
End Class
