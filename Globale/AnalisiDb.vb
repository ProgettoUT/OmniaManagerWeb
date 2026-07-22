Imports System.Data.OleDb
Imports System.IO

Public Class AnalisiDb

    Private Enum Errore
        TIPO_ERRATO
        LUNGHEZZA_DIVERSA
        CAMPO_NON_TROVATO
    End Enum

    Public Event Messaggio(TestoMessaggio As String)

    Sub New(Optional Log As Utx.ApplicationLog = Nothing)
        If Log Is Nothing Then
            mLog = New ApplicationLog("AnalisiDb", Utx.Globale.Paths.CartellaLogs, Sovrascrivi:=True)
        Else
            mLog = Log
        End If
    End Sub

    Private mAgenzia As String
    Public Property Agenzia() As String
        Get
            If String.IsNullOrEmpty(mAgenzia) Then
                Return Utx.Globale.AgenziaRichiesta.CodiceAgenzia
            Else
                Return mAgenzia
            End If
        End Get
        Set(value As String)
            mAgenzia = value
        End Set
    End Property

    Private mLog As Utx.ApplicationLog
    Public Property Log() As Utx.ApplicationLog
        Get
            Return mLog
        End Get
        Set(value As Utx.ApplicationLog)
            mLog = value
        End Set
    End Property

    Private mErrori As Integer
    Public Property Errori() As Integer
        Get
            Return mErrori
        End Get
        Set(value As Integer)
            mErrori = value
        End Set
    End Property

    Private mTabellaErrori As DataTable
    Public Property TabellaErrori() As DataTable
        Get
            Return mTabellaErrori
        End Get
        Set(value As DataTable)
            mTabellaErrori = value
        End Set
    End Property

    Private mErroreAnalisi As Boolean
    Public Property ErroreAnalisi() As Boolean
        Get
            Return mErroreAnalisi
        End Get
        Set(value As Boolean)
            mErroreAnalisi = value
        End Set
    End Property

    Private mErroriNonCorretti As List(Of String)
    Public Property ErroriNonCorretti() As List(Of String)
        Get
            Return mErroriNonCorretti
        End Get
        Set(value As List(Of String))
            mErroriNonCorretti = value
        End Set
    End Property

    Public Function AnalisiDb() As DataTable
        mTabellaErrori = New DataTable
        mErroriNonCorretti = New List(Of String)

        With mTabellaErrori.Columns
            .Add("Database", Type.GetType("System.String"))
            .Add("Tabella", Type.GetType("System.String"))
            .Add("Campo", Type.GetType("System.String"))
            .Add("Tipo modello", Type.GetType("System.String"))
            .Add("Note", Type.GetType("System.String"))
            .Add("Tipo tabella", Type.GetType("System.String"))
            .Add("Car.modello", Type.GetType("System.String"))
            .Add("Car.tabella", Type.GetType("System.String"))
            .Add("Record", Type.GetType("System.String"))
        End With

        Try
            Log.Info("Controllo struttura tabelle agenzia {0}", {mAgenzia})
            Log.AumentaRientro()

            Using c As New OleDbConnection(Utx.Globale.CnDbLink)
                c.Open()

                Dim Struttura As OleDbDataReader = Utx.FunzioniDb.CreaDataReader("SELECT * FROM Struttura ORDER BY Database,Tabella")

                Do While Struttura.Read
                    ControlloTabella(Struttura("Database"), Struttura("Tabella"), mTabellaErrori)
                Loop
            End Using

            mErrori = mTabellaErrori.Rows.Count

            RaiseEvent Messaggio(String.Format("Errori trovati: {0}", mErrori))

        Catch ex As Exception
            mErroreAnalisi = True
            Log.Info(ex.Message)
        Finally
            Log.DiminuisciRientro()
        End Try

        Return mTabellaErrori
    End Function

    Public Function AnalisiDbUno(CodiceAgenzia As String) As DataTable
        Dim Statistiche As New DataTable
        With Statistiche.Columns
            .Add("Agenzia", Type.GetType("System.String"))
            .Add("Db", Type.GetType("System.String"))
            .Add("Tabella", Type.GetType("System.String"))
            .Add("Tipo", Type.GetType("System.String"))
            .Add("Record", Type.GetType("System.Int32"))
            .Add("Aggiornato", Type.GetType("System.String"))
        End With

        Try
            Log.Info("Controllo struttura DbUno agenzia {0}", {mAgenzia})
            Log.AumentaRientro()

            Dim SchemaTabella As DataTable
            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(CodiceAgenzia, Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO)))
                c.Open()

                SchemaTabella = c.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables_Info, New Object() {Nothing, Nothing, Nothing, Nothing})

                For Each row In SchemaTabella.Rows
                    If row("TABLE_TYPE") = "TABLE" Then
                        Dim dr As DataRow = Statistiche.NewRow
                        dr("Agenzia") = CodiceAgenzia
                        dr("Db") = "DbUno"
                        dr("Tabella") = row("TABLE_NAME")
                        dr("Tipo") = "TABLE"
                        dr("Record") = row("CARDINALITY")
                        dr("Aggiornato") = Now.ToString
                        Statistiche.Rows.Add(dr)
                    End If
                Next
            End Using

        Catch ex As Exception
            Log.Info(ex)
        Finally
            Log.DiminuisciRientro()
        End Try
        Return Statistiche
    End Function

    Private Sub ControlloTabella(DataBase As String,
                                 Tabella As String,
                                 Riepilogo As DataTable)
        Try
            RaiseEvent Messaggio(String.Format("Database: {0}", DataBase))
            Log.Info("Verifica tabella [{0}].[{1}]", {DataBase, Tabella})

            'rilevo struttura modello
            Dim Modello As DataTable, SchemaTabella As DataTable
            Using c As New OleDb.OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbModello(DataBase))
                c.Open()

                SchemaTabella = c.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Tabella, Nothing})

                If SchemaTabella.Rows(0).Item("TABLE_TYPE") <> "TABLE" Then
                    'se non si tratta di una tabella esco
                    Exit Try
                End If

                Modello = c.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Columns, New Object() {Nothing, Nothing, Tabella, Nothing})
            End Using

            Using c As New OleDb.OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(Me.Agenzia, DataBase))
                c.Open()
                'numero di record in tabella
                Dim Record As Integer = Utx.FunzioniDb.NumeroRecord(c, Tabella)

                'struttura tabella
                Dim schemaTable As DataTable = c.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Columns, New Object() {Nothing, Nothing, Tabella, Nothing})

                '+stampa struttura per DEBUG
                'Utx.Globale.Log.Info("Database {0} - Tabella {1}", {DataBase, Tabella})
                'Utx.Globale.Log.AumentaRientro()

                'For Each r As DataRow In schemaTable.Rows
                '    If TipoCampo(r("DATA_TYPE")) = "Text" Then
                '        Utx.Globale.Log.Info("Campo {0}: {1} (codice tipo {2}) lunghezza {3}", {r("COLUMN_NAME"), TipoCampo(r("DATA_TYPE")), r("DATA_TYPE"), r("CHARACTER_MAXIMUM_LENGTH")})
                '    Else
                '        Utx.Globale.Log.Info("Campo {0}: {1} (codice tipo {2})", {r("COLUMN_NAME"), TipoCampo(r("DATA_TYPE")), r("DATA_TYPE")})
                '    End If
                'Next

                'Utx.Globale.Log.DiminuisciRientro()
                'Utx.Globale.Log.Info()
                '''''''''''''''''''''''''''''''''''''''''''''

                For i = 0 To Modello.Rows.Count - 1
                    'per ciascuna riga del modello
                    Dim EsisteColonna As Boolean = False
                    Dim CampoModello As String = Modello.Rows(i).Item("COLUMN_NAME").ToString.ToLower
                    Dim TipoModello As String = TipoCampo(Modello.Rows(i).Item("DATA_TYPE"))
                    Dim TipoDato As String = ""
                    Dim LunghezzaModello As Integer = 0
                    Dim LunghezzaDato As Integer = 0

                    'cerco il campo nella tabella
                    For Each r As DataRow In schemaTable.Rows
                        If (r("COLUMN_NAME").ToString.ToLower = CampoModello) Then
                            EsisteColonna = True
                            TipoDato = TipoCampo(r("DATA_TYPE"))
                            If TipoDato = "Text" Then
                                LunghezzaDato = r("CHARACTER_MAXIMUM_LENGTH")
                            End If
                            Exit For
                        End If
                    Next

                    If EsisteColonna = True Then
                        If TipoDato <> TipoModello Then
                            Riepilogo.Rows.Add({DataBase, Tabella, Modello.Rows(i).Item("COLUMN_NAME"), TipoModello, Errore.TIPO_ERRATO, TipoDato, "", "", Record})
                            Log.Info(String.Format("Database {0}: Tabella {1} Campo: {2} [{3}] (TIPO ERRATO: {4})",
                                                            DataBase,
                                                            Tabella,
                                                            CampoModello,
                                                            TipoModello,
                                                            TipoDato))
                        Else
                            If TipoModello = "Text" Then
                                LunghezzaModello = Modello.Rows(i).Item("CHARACTER_MAXIMUM_LENGTH")
                                'se le lunghezze sono diverse
                                If LunghezzaDato <> LunghezzaModello Then
                                    Riepilogo.Rows.Add({DataBase, Tabella, Modello.Rows(i).Item("COLUMN_NAME"), TipoModello, Errore.LUNGHEZZA_DIVERSA,
                                                        TipoDato, LunghezzaModello, LunghezzaDato, Record})
                                    Log.Info(String.Format("Database {0}: Tabella {1} Campo: {2} [{3}] (LUNGHEZZA DIVERSA: {4}/{5})",
                                                                    DataBase,
                                                                    Tabella,
                                                                    CampoModello,
                                                                    TipoModello,
                                                                    LunghezzaModello,
                                                                    LunghezzaDato))
                                End If
                            End If
                        End If
                    Else
                        If TipoModello = "Text" Then
                            LunghezzaModello = Modello.Rows(i).Item("CHARACTER_MAXIMUM_LENGTH")
                        End If
                        Riepilogo.Rows.Add({DataBase, Tabella, Modello.Rows(i).Item("COLUMN_NAME"), TipoModello, Errore.CAMPO_NON_TROVATO, "", LunghezzaModello, "", Record})
                        Log.Info(String.Format("*** Database {0}: Tabella {1} Campo: {2} [{3}] (CAMPO NON TROVATO)",
                                                        DataBase,
                                                        Tabella,
                                                        CampoModello,
                                                        TipoModello))
                    End If
                Next i
            End Using
#If DEBUG Then
            ControlloTabellaInverso(DataBase, Tabella, Riepilogo)
#End If

        Catch ex As Exception
            mErroreAnalisi = True
            Log.Info(ex.Message)
        End Try
    End Sub

    Private Sub ControlloTabellaInverso(DataBase As String,
                                        Tabella As String,
                                        Riepilogo As DataTable)
        Try
            RaiseEvent Messaggio(String.Format("Database: {0} (inverso)", DataBase))

            Dim Record As Integer

            '+rilevo struttura modello. NEL CONTROLLO INVERSO IL MODELLO E' LA TABELLA!!!
            Dim Modello As DataTable
            Using c As New OleDb.OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(Me.Agenzia, DataBase))
                c.Open()
                Modello = c.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Columns, New Object() {Nothing, Nothing, Tabella, Nothing})
                'numero di record in tabella
                Record = Utx.FunzioniDb.NumeroRecord(c, Tabella)
            End Using

            Using c As New OleDb.OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbModello(DataBase))
                c.Open()

                'struttura tabella
                Dim schemaTable As DataTable = c.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Columns, New Object() {Nothing, Nothing, Tabella, Nothing})

                For i = 0 To Modello.Rows.Count - 1
                    'per ciascuna riga del modello
                    Dim EsisteColonna As Boolean = False
                    Dim CampoModello As String = Modello.Rows(i).Item("COLUMN_NAME").ToString.ToLower
                    Dim TipoModello As String = TipoCampo(Modello.Rows(i).Item("DATA_TYPE"))
                    Dim TipoDato As String = ""
                    Dim LunghezzaModello As Integer = 0
                    Dim LunghezzaDato As Integer = 0

                    'cerco il campo nella tabella
                    For Each r As DataRow In schemaTable.Rows
                        If (r("COLUMN_NAME").ToString.ToLower = CampoModello) Then
                            EsisteColonna = True
                            TipoDato = TipoCampo(r("DATA_TYPE"))
                            If TipoDato = "Text" Then
                                LunghezzaDato = r("CHARACTER_MAXIMUM_LENGTH")
                            End If
                            Exit For
                        End If
                    Next

                    If EsisteColonna = True Then
                        If TipoDato <> TipoModello Then
                            Riepilogo.Rows.Add({DataBase + " (Inverso)", Tabella, Modello.Rows(i).Item("COLUMN_NAME"), TipoDato, Errore.TIPO_ERRATO, TipoModello, "", "", Record})
                        Else
                            If TipoModello = "Text" Then
                                LunghezzaModello = Modello.Rows(i).Item("CHARACTER_MAXIMUM_LENGTH")
                                'se le lunghezze sono diverse
                                If LunghezzaDato <> LunghezzaModello Then
                                    Riepilogo.Rows.Add({DataBase + " (Inverso)", Tabella, Modello.Rows(i).Item("COLUMN_NAME"), TipoDato, Errore.LUNGHEZZA_DIVERSA,
                                                        TipoModello, LunghezzaDato, LunghezzaModello, Record})
                                End If
                            End If
                        End If
                    Else
                        If TipoModello = "Text" Then
                            LunghezzaModello = Modello.Rows(i).Item("CHARACTER_MAXIMUM_LENGTH")
                        End If
                        Riepilogo.Rows.Add({DataBase + " (Inverso)", Tabella, Modello.Rows(i).Item("COLUMN_NAME"), TipoDato, Errore.CAMPO_NON_TROVATO, "", LunghezzaModello, "", Record})
                    End If
                Next i
            End Using

        Catch ex As Exception
            mErroreAnalisi = True
            Log.Info(ex.Message)
        End Try
    End Sub

    Public Shared Function TipoCampo(Tipo As OleDb.OleDbType) As String
        Select Case Tipo
            Case OleDbType.BigInt, OleDbType.Integer
                Return "Integer"
            Case OleDbType.Single, OleDbType.SmallInt
                Return "SmallInt"
            Case OleDbType.BSTR, OleDbType.Char, OleDbType.LongVarChar, OleDbType.LongVarWChar, OleDbType.VarChar, OleDbType.VarWChar, OleDbType.WChar
                Return "Text"
            Case OleDbType.Date, OleDbType.DBDate, OleDbType.DBTime, OleDbType.DBTimeStamp
                Return "Date"
            Case OleDbType.Currency, OleDbType.Double
                Return "Double"
            Case OleDbType.Numeric
                Return "Decimal"
            Case OleDbType.Boolean
                Return "Boolean"
            Case OleDbType.Binary, OleDbType.TinyInt
                Return "Byte"
            Case System.Data.OleDb.OleDbType.Integer
                Return "Long"
            Case System.Data.OleDb.OleDbType.Currency
                Return "Currency"
            Case System.Data.OleDb.OleDbType.Single
                Return "Single"
            Case System.Data.OleDb.OleDbType.Binary
                Return "Object"
            Case Else
                Return String.Format("{0} ???", Tipo)
        End Select
    End Function

    Public Sub CorreggiTutto()
        Try
            For k As Integer = 0 To mTabellaErrori.Rows.Count - 1
                If mTabellaErrori.Rows(k).Item("Database").ToString.ToLower.Contains("(inverso)") = False Then
                    Select Case mTabellaErrori.Rows(k).Item("Note")
                        Case Errore.CAMPO_NON_TROVATO.ToString
                            AggiungiCampo(k)
                        Case Errore.LUNGHEZZA_DIVERSA.ToString
                            CorreggiLunghezzaCampo(k)
                        Case Errore.TIPO_ERRATO.ToString
                            CorreggiTipo(k)
                    End Select
                End If
            Next
        Catch ex As Exception
            mErroreAnalisi = True
            Log.Errore(ex)
        End Try
    End Sub

    Public Sub CorreggiCampo(Riga As Integer)
        Try
            'correzione non disponibile per l'analisi inversa disponibile solo in debug
            If mTabellaErrori.Rows(Riga).Item("Database").ToString.ToLower.Contains("(inverso)") = False Then
                Select Case mTabellaErrori.Rows(Riga).Item("Note")
                    Case Errore.CAMPO_NON_TROVATO.ToString
                        AggiungiCampo(Riga)
                    Case Errore.LUNGHEZZA_DIVERSA.ToString
                        CorreggiLunghezzaCampo(Riga)
                    Case Errore.TIPO_ERRATO.ToString
                        CorreggiTipo(Riga)
                End Select
            End If
        Catch ex As Exception
            mErroreAnalisi = True
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub CorreggiLunghezzaCampo(Riga As Integer)
        Try
            Dim Database As String = mTabellaErrori.Rows(Riga).Item("Database")
            Dim Tabella As String = mTabellaErrori.Rows(Riga).Item("Tabella")
            Dim Campo As String = mTabellaErrori.Rows(Riga).Item("Campo")
            Dim LunghezzaModello As String = mTabellaErrori.Rows(Riga).Item("Car.modello")

            Log.Info("Correzione lunghezza campo: {0} - {1} ({0})", {Tabella, Campo, LunghezzaModello})

            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(Me.Agenzia, Database))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = String.Format("ALTER TABLE {0} ALTER COLUMN {1} TEXT({2})", Tabella, Campo, LunghezzaModello)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            RaiseEvent Messaggio(String.Format("Tabella {0} - Campo {1}: Modifica apportata correttamente", Tabella, Campo))

        Catch ex As Exception
            mErroreAnalisi = True
            mErroriNonCorretti.Add(String.Format("Database: {0} - Tabella: {1} - Campo: {2}",
                                                 mTabellaErrori.Rows(Riga).Item("Database"),
                                                 mTabellaErrori.Rows(Riga).Item("Tabella"),
                                                 mTabellaErrori.Rows(Riga).Item("Campo")))
            Log.Info(ex)
        End Try
    End Sub

    Private Sub CorreggiTipo(Riga As Integer)
        Try
            Dim Database As String = mTabellaErrori.Rows(Riga).Item("Database")
            Dim Tabella As String = mTabellaErrori.Rows(Riga).Item("Tabella")
            Dim Campo As String = mTabellaErrori.Rows(Riga).Item("Campo")
            Dim TipoModello As String = mTabellaErrori.Rows(Riga).Item("Tipo modello")

            Log.Info("Correzione tipo campo: {0} - {1} ({2})", {Tabella, Campo, TipoModello})

            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(Me.Agenzia, Database))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = String.Format("ALTER TABLE {0} ALTER COLUMN {1} {2}", Tabella, Campo, TipoModello.ToUpper)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            RaiseEvent Messaggio(String.Format("Tabella {0} - Campo {1}: Modifica apportata correttamente", Tabella, Campo))

        Catch ex As Exception
            mErroreAnalisi = True
            mErroriNonCorretti.Add(String.Format("Database: {0} - Tabella: {1} - Campo: {2}",
                                                 mTabellaErrori.Rows(Riga).Item("Database"),
                                                 mTabellaErrori.Rows(Riga).Item("Tabella"),
                                                 mTabellaErrori.Rows(Riga).Item("Campo")))
            Log.Info(ex)
        End Try
    End Sub

    Private Sub AggiungiCampo(Riga As Integer)
        Try
            Dim Database As String = mTabellaErrori.Rows(Riga).Item("Database")
            Dim Tabella As String = mTabellaErrori.Rows(Riga).Item("Tabella")
            Dim Campo As String = mTabellaErrori.Rows(Riga).Item("Campo")
            Dim TipoModello As String = mTabellaErrori.Rows(Riga).Item("Tipo modello")
            Dim LunghezzaModello As String = mTabellaErrori.Rows(Riga).Item("Car.modello")

            Log.Info("Aggiunta campo mancante: {0} - {1} ({2} - {3})", {Tabella, Campo, TipoModello, LunghezzaModello})

            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(Me.Agenzia, Database))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    'valuto il tipo del campo da aggiungere
                    Select Case TipoModello
                        Case "Text"
                            If LunghezzaModello = 0 Then
                                cmd.CommandText = String.Format("ALTER TABLE {0} ADD COLUMN [{1}] MEMO", Tabella, Campo)
                            Else
                                cmd.CommandText = String.Format("ALTER TABLE {0} ADD COLUMN [{1}] TEXT({2})", Tabella, Campo, LunghezzaModello)
                            End If
                        Case "Date"
                            cmd.CommandText = String.Format("ALTER TABLE {0} ADD COLUMN [{1}] DATE", Tabella, Campo)
                        Case "Integer"
                            cmd.CommandText = String.Format("ALTER TABLE {0} ADD COLUMN [{1}] INTEGER", Tabella, Campo)
                        Case "Double"
                            cmd.CommandText = String.Format("ALTER TABLE {0} ADD COLUMN [{1}] DOUBLE", Tabella, Campo)
                        Case "SmallInt"
                            cmd.CommandText = String.Format("ALTER TABLE {0} ADD COLUMN [{1}] SMALLINT", Tabella, Campo)
                    End Select
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            RaiseEvent Messaggio(String.Format("Tabella {0} - Campo {1}: Modifica apportata correttamente", Tabella, Campo))

        Catch ex As Exception
            mErroreAnalisi = True
            mErroriNonCorretti.Add(String.Format("Database: {0} - Tabella: {1} - Campo: {2}",
                                                 mTabellaErrori.Rows(Riga).Item("Database"),
                                                 mTabellaErrori.Rows(Riga).Item("Tabella"),
                                                 mTabellaErrori.Rows(Riga).Item("Campo")))
            Log.Info(ex)
        End Try
    End Sub

    Public Function AnalisiDbAnag() As Boolean
        Try
            For Each Agenzia As String In Utx.EnteGestore.CodiciGestiti

                Using s As New SettingAgenzia.ConfiguraSede
                    s.Proxy = Utx.Globale.UniProxy.Proxy

                    If s.EsistonoDatiAnag(Agenzia) = False Then
                        Dim dt As New DataTable With {.TableName = "Anag"}
                        With dt.Columns
                            .Add("Agenzia", Type.GetType("System.String"))
                            .Add("Tabella", Type.GetType("System.String"))
                            .Add("Record", Type.GetType("System.Int32"))
                        End With

                        Dim SchemaTabella As DataTable
                        Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(Agenzia, Utx.ConnessioniDb.PathMdbAgenzia(Agenzia, Utx.ConnessioniDb.Db.ANAG)))
                            c.Open()

                            SchemaTabella = c.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables_Info, New Object() {Nothing, Nothing, Nothing, Nothing})

                            For Each row In SchemaTabella.Rows
                                If row("TABLE_TYPE") = "TABLE" Then
                                    Dim dr As DataRow = dt.NewRow
                                    dr("Agenzia") = Agenzia
                                    dr("Tabella") = row("TABLE_NAME")
                                    dr("Record") = row("CARDINALITY")
                                    dt.Rows.Add(dr)
                                End If
                            Next
                        End Using

                        Dim ds As New DataSet
                        ds.Tables.Add(dt)

                        s.RegistraLogAnag(ds)
                    End If
                End Using
            Next
            Return True

        Catch ex As Exception
            Log.Info(ex)
            Return False
        Finally
            Log.DiminuisciRientro()
        End Try
    End Function

    Public Shared Function AnalisiDbLink(FullPathDb As String) As Boolean
        Try
            Utx.Globale.Log.Info("Verifico integrità DbLink {0}", {FullPathDb})

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + FullPathDb)
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "DELETE FROM InfoMe WHERE Proprieta = 'Errore'"

                    Return (cmd.ExecuteNonQuery = 0)
                End Using
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Shared Sub CancellaDocumentiDuplicati()
        Dim Notifica As New FormNotifica
        Dim CartellaDoppioni As String = Path.Combine(Globale.Paths.CartellaDocumenti, "Cartella documenti duplicati")
        Try
            With Notifica
                .Stile = FormNotifica.Style.ANTRACITE
                .AnnullaOperazione = True
                .Show()
                .Messaggio = "Controllo documenti duplicati..."
                .TopMost = True
            End With
            Utx.Globale.Log.Info("Controllo documenti duplicati: inizio")

            Directory.CreateDirectory(CartellaDoppioni)

            Dim TotaleCartelle As Integer = Directory.GetDirectories(Globale.Paths.CartellaDocumenti, "?").Length
            Dim Progressivo As Integer = 0

            For Each Lettera As String In Directory.GetDirectories(Globale.Paths.CartellaDocumenti, "?")
                'per ogni cliente
                For Each Cliente As String In Directory.GetDirectories(Lettera)
                    'per tutti i file nella cartella cliente
                    For Each FileAnag As String In Directory.GetFiles(Cliente)
                        Dim MD5 As String = Utx.NetFunc.FileToMD5(FileAnag).ToUpper
                        Dim Copia As Boolean = False

                        'per tutte le sottocartelle del cliente
                        For Each c As String In Directory.GetDirectories(Cliente)
                            'per tutti i file nelle sottocartelle
                            For Each FileSub As String In Directory.GetFiles(c)
                                Dim MD5Sub As String = Utx.NetFunc.FileToMD5(FileSub).ToUpper

                                If MD5 = MD5Sub Then
                                    Globale.Log.Info("{0} - {1}", {FileAnag, MD5})
                                    Globale.Log.Info("* Copia: {0} - {1}", {FileSub, MD5Sub})

                                    Copia = True

                                    'sposta il file
                                    Dim Destinazione As String = Path.Combine(CartellaDoppioni, Path.GetFileName(Cliente))
                                    Directory.CreateDirectory(Destinazione)
                                    Destinazione = Path.Combine(Destinazione, Path.GetFileName(FileSub))

                                    My.Computer.FileSystem.MoveFile(FileAnag, Destinazione, True)
                                    Exit For
                                End If
                            Next

                            If Copia = True Then
                                Exit For
                            End If
                        Next
                        System.Windows.Forms.Application.DoEvents()
                    Next
                    System.Windows.Forms.Application.DoEvents()

                    If Notifica.RichiestaAnnullamento = True Then
                        Notifica.Messaggio = "Annullamento Integer corso..."
                        Exit Try
                    End If
                Next
                System.Windows.Forms.Application.DoEvents()

                Progressivo += 1
                Notifica.Messaggio = String.Format("Controllo documenti duplicati {0:##0%}", Progressivo / TotaleCartelle)
            Next
            Utx.Globale.Log.Info("Controllo documenti duplicati: inizio")

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Notifica.Messaggio = "Controllo documenti duplicati concluso"
            MsgBox("I documenti duplicati sono stati spostati nella cartella " & CartellaDoppioni, MsgBoxStyle.Information, Globale.TitoloApp)
            Notifica.Chiudi(1)
        End Try
    End Sub

    'Public Shared Function AnalisiDbLink(FullPathDb As String) As Boolean
    '    Try
    '        Utx.Globale.Log.Info("Verifico integrità DbLink {0}", {FullPathDb})

    '        Using c As New OleDbConnection(Utx.Globale.MDBDriver + FullPathDb)
    '            c.Open()

    '            Utx.Globale.Log.Info("leggo schema dblink")
    '            Dim Stored As DataTable = c.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables_Info, New Object() {Nothing, Nothing, Nothing, "VIEW"})
    '            Utx.Globale.Log.Info("leggo tabella struttura")
    '            Dim Struttura As New DataTable

    '            Using cmd As New OleDbCommand
    '                cmd.Connection = c
    '                cmd.CommandType = CommandType.Text
    '                cmd.CommandText = "SELECT Iif(Link IS NULL OR TRIM(Link) = '',Tabella,Link) AS Tabella FROM Struttura ORDER BY Tabella ASC"

    '                Using da As New OleDbDataAdapter(cmd)
    '                    da.Fill(Struttura)
    '                End Using
    '            End Using

    '            Utx.Globale.Log.Info("verifico corrispondenza schema/struttura")

    '            For Each dr As DataRow In Struttura.Rows
    '                Dim Esiste As Boolean = False
    '                For Each row As DataRow In Stored.Rows
    '                    If dr("Tabella") = row("TABLE_NAME") Then
    '                        Esiste = True
    '                        Exit For
    '                    End If
    '                Next
    '                If Esiste = False Then
    '                    Utx.Globale.Log.Info("La tabella '{0}' non esiste in '{1}'", {dr("Tabella"), FullPathDb})
    '                    Return False
    '                End If
    '            Next
    '        End Using
    '        Utx.Globale.Log.Info("Integrità DbLink OK")
    '        Return True

    '    Catch ex As Exception
    '        Utx.Globale.Log.Errore(ex)
    '        Return False
    '    End Try
    'End Function
End Class
