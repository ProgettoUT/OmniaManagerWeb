#If DEBUG Then
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml.Serialization
Imports System.Data.OleDb

Module perDebug
    Public Sub Main()
#If DEBUGSTEFANO Then
        Utx.Globale.IdApp(System.Text.Encoding.UTF8.GetString(New Byte() {57, 60, 88, 93, 65, 58, 71}))
        Utx.Globale.Paths = New Utx.ApplicationPath
        Utx.Globale.Paths.Inizializza("C:\ApplicazioniDirezione\UT", "X", "M")
        Utx.Globale.UtenteCorrente = New Utx.Utente
        Utx.Globale.SettingGlobale = New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.GLOBALE)
        Utx.Globale.SettingInterop = New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.INTEROP)
        Utx.Globale.UniProxy = New Utx.Proxy()
        Utx.Globale.ProfiloEnteGestore = New Utx.EnteGestore
        Utx.Globale.Log = New Utx.ApplicationLog("Migrazione2018", Nothing, Nothing, True)
        'Utx.Globale.ProfiloEnteGestore.LeggiAbilitazioni()

        Dim f As FormMigrazione
        f = New FormMigrazione
        f.ShowDialog()
#End If
    End Sub
End Module

<TestClass>
Public Class DBDDL
    Public TestContext As TestContext
    Private Log As New Utx.ApplicationLog("DBDDL")
    'tipi di dato
    'https://msdn.microsoft.com/it-it/library/cc716729(v=vs.110).aspx


    Shared Sub New()
        Dim a As New Utx.TestEssig
        a.Inizializza()
    End Sub

    <TestMethod>
    Public Sub DBDDLGeneraDDL()
        Try
            Dim agenzie As String() = {"comuni", "agenzia"} '{"00000"}

            Dim data_type As String
            For Each agenzia As String In agenzie

                Dim Report As New Utx.ApplicationLog(String.Format("DB_{0}", agenzia), Sovrascrivi:=True)
                Report.TipoData = Utx.ApplicationLog.DataOra.NESSUNA

                For Each database As String In DbManager.getAccessDbs(agenzia)
                    Using access As New OleDb.OleDbConnection(String.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}\Dati\{1}\{2}.mdb",
                                                                            Utx.Globale.Paths.CartellaModelli, agenzia, database))
                        access.Open()

                        Dim tabelle As DataTable = access.GetSchema("Tables")
                        For Each tabella As DataRow In tabelle.Rows
                            If tabella(3) = "TABLE" Then

                                Dim colonne As DataTable = access.GetSchema("Columns", {Nothing, Nothing, tabella(2), Nothing}) ',Columns, Views, Procedures

                                Report.Info("**Creazione tabella [" & tabella(2) & "];" & vbNewLine)
                                Report.Info("IF OBJECT_ID('dbo.[" & tabella(2) & "]', 'U') IS NOT NULL DROP TABLE dbo.[" & tabella(2) & "];" & vbNewLine)

                                Dim sql As String = "CREATE TABLE dbo.[" & tabella(2) & "]" & vbNewLine & "    ("

                                For Each row As DataRow In colonne.Select("", "ORDINAL_POSITION")

                                    Select Case row("DATA_TYPE")
                                        Case OleDbType.Char, OleDbType.WChar,
                                            OleDbType.VarChar, OleDbType.VarWChar,
                                            OleDbType.LongVarChar, OleDbType.LongVarWChar
                                            If row("character_maximum_length") = 0 Then
                                                data_type = "TEXT"
                                            ElseIf row("character_maximum_length") <= 5 Then
                                                data_type = String.Format("CHAR({0})", row("CHARACTER_MAXIMUM_LENGTH"))
                                            Else
                                                data_type = String.Format("VARCHAR({0})", row("CHARACTER_MAXIMUM_LENGTH"))
                                            End If

                                        Case OleDbType.Boolean
                                            data_type = "BIT"
                                        Case OleDbType.UnsignedTinyInt
                                            data_type = "TINYINT"
                                        Case OleDbType.SmallInt
                                            data_type = "SMALLINT"
                                        Case OleDbType.Integer
                                            data_type = "INT"
                                        Case OleDbType.Double
                                            data_type = "FLOAT"
                                        Case OleDbType.Single
                                            data_type = "REAL"
                                        Case OleDbType.Currency
                                            data_type = "MONEY"
                                        Case OleDbType.Date
                                            data_type = "DATE"
                                        Case OleDbType.Guid
                                            data_type = "UNIQUEIDENTIFIER"
                                        Case OleDbType.Binary
                                            data_type = String.Format("VARBINARY({0})", row("CHARACTER_MAXIMUM_LENGTH"))
                                        Case Else
                                            data_type = "TIPO NON TROVATO " & row("DATA_TYPE") & " " & [Enum].GetName(GetType(OleDbType), (row("DATA_TYPE")))
                                            Log.Errore("***>> " & row("COLUMN_NAME") & " = " & data_type)
                                    End Select

                                    Dim is_nullable As String = IIf(row("IS_NULLABLE") = True, "", " NOT NULL")

                                    sql &= vbNewLine & "    [" & row("COLUMN_NAME") & "] " & data_type & is_nullable & ","
                                Next

                                Report.Info(sql.Substring(0, sql.Length - 1) & vbNewLine & "    );" & vbNewLine & vbNewLine)
                            End If
                        Next

                        access.Close()
                    End Using
                Next database

                Report.Info(String.Format("**CREAZIONE SCRIPT {0} TERMINATO CORRETTAMENTE;", agenzia))
            Next agenzia

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub


    <TestMethod>
    Public Sub DBDDLCreaChiaviInDatabase()
        Utx.FunzioniDb.CreaChiaviClienti("00001")
        Utx.FunzioniDb.CreaChiaviPolizze("00001")
        Utx.FunzioniDb.CreaChiaviSinistri("00001")
        Utx.FunzioniDb.CreaChiaviNote("00001")
        Utx.FunzioniDb.CreaChiaviSupporto()
        '        Utx.Manutenzione.CreaIndici("00001")
        Debug.Assert(True)
    End Sub

    <TestMethod>
    Public Sub DBDDCreaIndici()
        Dim a As New Utx.TestEssig
        a.Inizializza()

        Try
            Dim agenzie As String() = {"00000", "00001"}
            For Each agenzia As String In agenzie

                Dim Report As New Utx.ApplicationLog(String.Format("DB_{0}", agenzia), Sovrascrivi:=True)
                Report.TipoData = Utx.ApplicationLog.DataOra.NESSUNA

                For Each database As String In DbManager.getAccessDbs(agenzia)
                    Using access As New OleDb.OleDbConnection(String.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}\{1}\{2}.mdb",
                                                        Utx.Globale.Paths.CartellaDati, agenzia, database))

                        access.Open()

                        'PRIMARY_KEY, UNIQUE, CLUSTERED, COLUMN_NAME, NULLS
                        For Each campo As DataRow In access.GetSchema("Indexes").Rows
                            If (campo("TABLE_NAME").ToString.StartsWith("MSys") = False) AndAlso campo("PRIMARY_KEY") Then

                                Dim data_type As String = ""
                                Dim colonna = access.GetSchema("Columns", {Nothing, Nothing, campo("TABLE_NAME"), Nothing}).Select("COLUMN_NAME = '" & campo("COLUMN_NAME") & "'") ',Columns, Views, Procedures

                                Select Case colonna(0)("DATA_TYPE")
                                    Case OleDbType.Char, OleDbType.WChar,
                                        OleDbType.VarChar, OleDbType.VarWChar,
                                        OleDbType.LongVarChar, OleDbType.LongVarWChar
                                        data_type = String.Format("CHAR({0})", colonna(0)("CHARACTER_MAXIMUM_LENGTH"))
                                    Case OleDbType.Boolean
                                        data_type = "BIT"
                                    Case OleDbType.UnsignedTinyInt
                                        data_type = "TINYINT"
                                    Case OleDbType.SmallInt
                                        data_type = "SMALLINT"
                                    Case OleDbType.Integer
                                        data_type = "INT"
                                    Case OleDbType.Double
                                        data_type = "FLOAT"
                                    Case OleDbType.Single
                                        data_type = "REAL"
                                    Case OleDbType.Currency
                                        data_type = "MONEY"
                                    Case OleDbType.Date
                                        data_type = "DATE"
                                    Case OleDbType.Guid
                                        data_type = "UNIQUEIDENTIFIER"
                                    Case Else
                                        Log.Errore("***>> " & campo("COLUMN_NAME"))
                                End Select


                                Report.Info("**set NOTNULL [" & campo("TABLE_NAME") & "].[" & campo("COLUMN_NAME") & "];")
                                Report.Info(String.Format("ALTER TABLE dbo.[{0}] ALTER COLUMN [{1}] {2} NOT NULL;",
                                                          campo("TABLE_NAME"), campo("COLUMN_NAME"), data_type))
                            End If
                        Next
                        access.Close()
                    End Using
                Next

                Report.Info()

                For Each database As String In DbManager.getAccessDbs(agenzia)
                    Using access As New OleDb.OleDbConnection(String.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}\{1}\{2}.mdb",
                                                                            Utx.Globale.Paths.CartellaDati, agenzia, database))
                        access.Open()

                        Dim tabelle As DataTable = access.GetSchema("Tables")
                        For Each tabella As DataRow In tabelle.Rows
                            If tabella(3) = "TABLE" Then
                                Dim colonne As DataTable = access.GetSchema("Indexes", {Nothing, Nothing, Nothing, Nothing, tabella(2)})

                                'Dim f As New Utx.FormDebug(colonne)
                                'f.ShowDialog()

                                If colonne.Rows.Count > 0 Then
                                    Dim campi As String = ""
                                    Dim prgIndice As Integer = 1
                                    colonne.Select("", "INDEX_NAME, ORDINAL_POSITION")
                                    Dim unique As String = ""
                                    Dim clustered As String = ""
                                    Dim primarykey As Boolean = False

                                    For Each campo As DataRow In colonne.Rows
                                        If campo("ORDINAL_POSITION") = 1 And campi <> "" Then
                                            Report.Info(" ")
                                            If (primarykey) Then
                                                Report.Info("**Creazione chiave [" & tabella(2) & "];")
                                                Report.Info(String.Format("ALTER TABLE dbo.{0} ADD CONSTRAINT PK_{0} PRIMARY KEY CLUSTERED ({1});",
                                                                          UCase(tabella(2)), campi.Substring(2)))
                                            Else
                                                Report.Info("**Creazione indice [" & tabella(2) & "];")
                                                ' WITH DROP_EXISTING = ON
                                                Report.Info(String.Format("CREATE {3}{4} INDEX IX{1}_{0} ON dbo.{0} ({2});",
                                                                          UCase(tabella(2)), prgIndice, campi.Substring(2), unique, clustered))
                                                prgIndice += 1
                                            End If
                                            campi = ""
                                        End If
                                        campi &= ", " & campo("COLUMN_NAME")
                                        unique = IIf(campo("UNIQUE"), "UNIQUE ", "")
                                        clustered = IIf(campo("CLUSTERED"), "CLUSTERED", "NONCLUSTERED")
                                        primarykey = campo("PRIMARY_KEY")
                                    Next

                                    Report.Info(" ")
                                    If (primarykey) Then
                                        Report.Info("**Creazione chiave [" & tabella(2) & "];")
                                        Report.Info(String.Format("ALTER TABLE dbo.{0} ADD CONSTRAINT PK_{0} PRIMARY KEY CLUSTERED ({1});",
                                                                  UCase(tabella(2)), campi.Substring(2)))
                                    Else
                                        Report.Info("**Creazione indice [" & tabella(2) & "];")
                                        Report.Info(String.Format("CREATE {3}{4} INDEX IX{1}_{0} ON dbo.{0} ({2}) WITH DROP_EXISTING = ON;",
                                                                  UCase(tabella(2)), prgIndice, campi.Substring(2), unique, clustered))
                                    End If
                                End If
                            End If
                        Next

                        access.Close()
                    End Using
                Next database

                Report.Info(String.Format("**CREAZIONE SCRIPT {0} TERMINATO CORRETTAMENTE;", agenzia))
            Next agenzia

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub
End Class
#End If
#If COMMENT Then
colonne schema columns
TABLE_CATALOG
TABLE_SCHEMA
TABLE_NAME
COLUMN_NAME
COLUMN_GUID
COLUMN_PROPID
ORDINAL_POSITION
COLUMN_HASDEFAULT
COLUMN_DEFAULT
COLUMN_FLAGS
IS_NULLABLE
DATA_TYPE
TYPE_GUID
CHARACTER_MAXIMUM_LENGTH
CHARACTER_OCTET_LENGTH
NUMERIC_PRECISION
NUMERIC_SCALE
DATETIME_PRECISION
CHARACTER_SET_CATALOG
CHARACTER_SET_SCHEMA
CHARACTER_SET_NAME
COLLATION_CATALOG
COLLATION_SCHEMA
COLLATION_NAME
DOMAIN_CATALOG
DOMAIN_SCHEMA
DOMAIN_NAME
DESCRIPTION
#End If