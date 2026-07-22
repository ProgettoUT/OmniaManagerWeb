Imports System.Web.Services
Imports System.Data.OleDb
Imports System.IO
Imports System.Collections.Generic
Imports System.Web.Services.Protocols


<System.Web.Services.WebService(Namespace:="http://www.utools.it/asp/SettingAgenzia")>
Public Class ConfiguraSede

    Inherits System.Web.Services.WebService

#Region " Codice generato da Progettazione servizi Web "

    Public Sub New()
        MyBase.New()

        'Chiamata richiesta da Progettazione servizi Web
        InitializeComponent()

        'Aggiungere il codice di inizializzazione dopo la chiamata a InitializeComponent()
    End Sub

    'Richiesto da Progettazione servizi Web
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione servizi Web.
    'Può essere modificata in Progettazione servizi Web.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: questa procedura è richiesta da Progettazione servizi Web.
        'Non modificarla nell'editor del codice.
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region

    'Private Globale As New SettingGlobale
    Friend MdbDriver As String = "Provider = Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source="

    Friend ConfigDb As String = Server.MapPath("\mdb-database\190139f2-4749-488a-859c-51c824f6bbdc\ConfigDownload\ConfigDLDati.mdb")
    Friend StatisticheDb As String = Server.MapPath("\mdb-database\Statistiche\Statistiche.mdb")
    Friend ControlloVersioneDb As String = Server.MapPath("\Unitools\Update\Versioni\ControlloVersione.mdb")
    Friend RaccoltaDati As String = Server.MapPath("\mdb-database\Statistiche\RaccoltaDati.mdb")
    Friend DatiComuniAgenzie As String = Server.MapPath("\mdb-database\190139f2-4749-488a-859c-51c824f6bbdc\ConfigDownload\DatiComuniAgenzie.mdb")
    Friend StatisticheUso As String = Server.MapPath("\mdb-database\Statistiche\StatisticheUso.mdb")
    Friend Postalizzazione As String = Server.MapPath("\mdb-database\190139f2-4749-488a-859c-51c824f6bbdc\Postalizzazione\Postalizzazione.mdb")
    Friend SiaDb As String = Server.MapPath("\mdb-database\190139f2-4749-488a-859c-51c824f6bbdc\ConfigDownload\SIA.mdb")
    Friend ServiziDb As String = Server.MapPath("\mdb-database\190139f2-4749-488a-859c-51c824f6bbdc\ConfigDownload\Servizi.mdb")

    Friend CnConfigDb As String = MdbDriver + ConfigDb
    Friend CnStatisticheDb As String = MdbDriver + StatisticheDb
    Friend CnControlloVersioneDb As String = MdbDriver + ControlloVersioneDb
    Friend CnRaccoltaDati As String = MdbDriver + RaccoltaDati
    Friend CnPostalizzazione As String = MdbDriver + Postalizzazione
    Friend CnSia As String = MdbDriver + SiaDb
    Friend CnServizi As String = MdbDriver + ServiziDb

    Friend CartellaLog As String = Server.MapPath("\mdb-database\190139f2-4749-488a-859c-51c824f6bbdc\ConfigDownload\Logs")

    Private ReadOnly Log As New ApplicationLog(CartellaLog, "SettingAgenzie.log")

    Private dsConfig As New DataSet

    Private Enum Variabili
        BloccoImportazione
        Postalizzazione
        VersioneLiveUpdate
        OggiPostalizzazione
    End Enum

    <WebMethod()>
    Public Function CodiciDownloadEx(ByVal Compagnia As Integer,
                                     ByVal CodiceAgenzia As String,
                                     ByVal CodiceSede As String,
                                     ByVal CodiceControllo As Integer,
                                     ByRef ConsensoImportazione As Boolean,
                                     ByRef Errore As String,
                                     ByRef ErroreForzature As String,
                                     ByRef ErroreListe As String) As DataSet

        Log.AddLog(String.Format("Importa dati: Agenzia {0}-{1}-{2} Codice controllo {3}",
                                 Compagnia, CodiceAgenzia, CodiceSede, CodiceControllo))

        Dim BloccaImportazione As Boolean = False 'flag che imposta il blocco

        'blocco lettura dati per versioni vecchie di IDati
        If VersioneMinima(Compagnia, CodiceAgenzia, CodiceControllo) = False Then
            ConsensoImportazione = False
            Errore = "-ERR: Versione IDati non aggiornata"
            ErroreForzature = "+OK"
            ErroreListe = "+OK"
            'aggiungo tabella config vuota
            dsConfig.Tables.Add("Config")
            Return dsConfig
        ElseIf BloccaImportazione = True Then
            '+blocca tutte le importazioni
            ConsensoImportazione = False
            Errore = "-ERR: Importazione bloccata dal server"
            ErroreForzature = "+OK"
            ErroreListe = "+OK"
            'aggiungo tabella config vuota
            dsConfig.Tables.Add("Config")
            Return dsConfig
        End If

        Dim cn As New OleDb.OleDbConnection
        Dim cmd As New OleDb.OleDbCommand

        Try
            cn.ConnectionString = CnConfigDb
            cn.Open()

            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT DISTINCT * " +
                              "FROM Config " +
                              "WHERE Compagnia = ? AND Agenzia = ? AND Sede = ? AND DataFine > #{0:MM/dd/yyyy}# " +
                              "ORDER BY DataFine ASC"

            'se il codice è stato chiuso da più di 4 mesi lo escludo dalla configurazione restituita
            cmd.CommandText = String.Format(cmd.CommandText, Today.AddMonths(-4))

            cmd.Parameters.AddWithValue("Compagnia", Compagnia)
            cmd.Parameters.AddWithValue("Agenzia", CodiceAgenzia)
            cmd.Parameters.AddWithValue("Sede", IIf(CodiceSede = "DR", "00", CodiceSede))

            Dim da As New OleDbDataAdapter
            da.SelectCommand = cmd

            Dim RecordConfig As Integer = da.Fill(dsConfig, "Config")

            'dopo 6 mesi il record di configurazione non viene più trasmesso
            Dim DataMinima As Date = CDate("01/01/" + (Year(Now) - 2).ToString)

            For Each dr As DataRow In dsConfig.Tables("Config").Rows
                If dr("DataInizio") < DataMinima Then dr("DataInizio") = DataMinima
                If dr("CodiciSub") Is DBNull.Value Then dr("CodiciSub") = ""
                If dr("CodiciProd") Is DBNull.Value Then dr("CodiciProd") = ""
            Next

            'se non c'è configurazione per l'agenzia e si tratta della sede centrale
            If RecordConfig = 0 And (CodiceSede = "00" OrElse CodiceSede = "DR") Then

                Dim rowArray() As Object = {Compagnia, CodiceAgenzia, False, CodiceSede, "", CodiceAgenzia, "", "",
                                            DataMinima, #12/31/2100#, "S", "N", "S", "S", "S", "S"}

                dsConfig.Tables("Config").Rows.Add(rowArray)
            End If

            'da il consenso se è presente almeno una riga di configurazione
            ConsensoImportazione = (dsConfig.Tables("Config").Rows.Count > 0)
            Errore = "+OK"

            'leggo le forzature e le metto nel dataset
            ForzatureEx(cn, ErroreForzature)

            'leggo le liste da scaricare
            Liste(cn, ErroreListe)

            'contabilità
            ContabilitaEx(cn, CodiceAgenzia)

            'abilitazioni della sede secondaria
            AbilitazioniSede(cn, Compagnia, CodiceAgenzia, CodiceSede)

        Catch ex As Exception
            Errore = "-ERR|" + ex.Message
            Log.BoxErrore(ex)
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
            cmd.Dispose()
            cn.Dispose()
        End Try

        'restituisco il dataset di configurazione
        Return dsConfig
    End Function

    <WebMethod()>
    Public Function CodiciIncorporati(ByVal Compagnia As Integer,
                                      ByVal CodiceAgenzia As String,
                                      ByVal CodiceSede As String) As String

        Try
            Using cn As New OleDbConnection(CnConfigDb)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT Collegata " +
                                      "FROM Config " +
                                      "WHERE Compagnia = ? AND Agenzia = ? AND Sede = ? AND DataFine > #{0:MM/dd/yyyy}# " +
                                      "ORDER BY DataFine ASC"

                    'se il codice è stato chiuso da più di 6 mesi lo escludo dalla configurazione restituita
                    cmd.CommandText = String.Format(cmd.CommandText, Today.AddMonths(-6))

                    cmd.Parameters.AddWithValue("Compagnia", Compagnia)
                    cmd.Parameters.AddWithValue("Agenzia", CodiceAgenzia)
                    cmd.Parameters.AddWithValue("Sede", CodiceSede)

                    Dim dr As OleDbDataReader = cmd.ExecuteReader

                    Dim Codici As String = ""
                    If dr.HasRows = True Then
                        Do While dr.Read
                            Codici &= dr("Collegata") & "/"
                        Loop
                        Codici = Codici.Substring(0, Codici.Length - 1)
                    Else
                        Codici = CodiceAgenzia
                    End If
                    Return Codici
                End Using
            End Using

        Catch ex As Exception
            Log.BoxErrore(ex)
            Return ex.Message
        End Try
    End Function

    Private Sub ForzatureEx(ByRef cn As OleDbConnection,
                            ByRef ErroreForzature As String)

        Dim cmd As New OleDb.OleDbCommand

        Try
            'inizializzo la tabella forzature con la struttura vuota
            With cmd
                .Connection = cn
                .CommandType = CommandType.Text
                .CommandText = "SELECT DISTINCT * FROM Forzature"
            End With

            Dim da As New OleDbDataAdapter
            da.SelectCommand = cmd
            da.Fill(dsConfig, "Forzature")

            ErroreForzature = "+OK"

        Catch ex As Exception
            ErroreForzature = "-ERR|" + ex.Message
            Log.BoxErrore(ex)
        Finally
            cmd.Dispose()
        End Try
    End Sub

    Private Sub AbilitazioniSede(ByRef cn As OleDbConnection,
                                 ByVal Compagnia As Integer,
                                 ByVal CodiceAgenzia As String,
                                 ByVal CodiceSede As String)

        Dim cmd As New OleDb.OleDbCommand

        Try
            'inizializzo la tabella forzature con la struttura vuota
            With cmd
                .Connection = cn
                .CommandType = CommandType.Text
                .CommandText = "SELECT TOP 1 * FROM AbilitazioniSede WHERE Compagnia = ? AND Agenzia = ? AND Sede = ?"

                .Parameters.Clear()
                .Parameters.AddWithValue("Compagnia", Compagnia)
                .Parameters.AddWithValue("Agenzia", CodiceAgenzia)
                .Parameters.AddWithValue("Sede", CodiceSede)
            End With

            Dim da As New OleDbDataAdapter
            da.SelectCommand = cmd
            da.Fill(dsConfig, "AbilitazioniSede")

            'in caso non ci siano configurazioni impostate aggiungo la riga di default a seconda del tipo di sede
            If dsConfig.Tables("AbilitazioniSede").Rows.Count = 0 Then

                Dim dr As DataRow = dsConfig.Tables("AbilitazioniSede").NewRow

                dr("Compagnia") = Compagnia.ToString '0
                dr("Agenzia") = CodiceAgenzia '1
                dr("Sede") = CodiceSede '2

                If CodiceSede = "00" Then
                    'sede principale: tutto "S"
                    For k As Integer = 3 To dsConfig.Tables("AbilitazioniSede").Columns.Count - 1
                        dr(k) = "S"
                    Next
                Else
                    'sede secondaria: tutto "N"
                    For k As Integer = 3 To dsConfig.Tables("AbilitazioniSede").Columns.Count - 1
                        dr(k) = "N"
                    Next
                End If

                dsConfig.Tables("AbilitazioniSede").Rows.Add(dr)
            End If

        Catch ex As Exception
            Log.BoxErrore(ex)
        Finally
            cmd.Dispose()
        End Try

    End Sub

    <WebMethod()>
    Public Function AbilitazioniSedeStringa(ByVal Compagnia As Integer,
                                            ByVal CodiceAgenzia As String,
                                            ByVal CodiceSede As String) As String

        Try
            Using c As New OleDb.OleDbConnection(CnConfigDb)

                c.Open()

                Using cmd As New OleDb.OleDbCommand

                    'inizializzo la tabella forzature con la struttura vuota
                    With cmd
                        .Connection = c
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT TOP 1 * FROM AbilitazioniSede WHERE Compagnia = ? AND Agenzia = ? AND Sede = ?"

                        .Parameters.Clear()
                        .Parameters.AddWithValue("Compagnia", Compagnia)
                        .Parameters.AddWithValue("Agenzia", CodiceAgenzia)
                        .Parameters.AddWithValue("Sede", CodiceSede)
                    End With

                    Dim dr As OleDbDataReader = cmd.ExecuteReader

                    If dr.HasRows Then

                        dr.Read()

                        AbilitazioniSedeStringa = String.Format("{0};{1};{2};{3}",
                                                                dr("PattoUnipol"),
                                                                dr("ListeQT"),
                                                                dr("Archivio"),
                                                                dr("Buste"))
                    Else
                        If CodiceSede = "00" Then
                            AbilitazioniSedeStringa = "S;S;S;S"
                        Else
                            AbilitazioniSedeStringa = "N;N;N;N"
                        End If
                    End If

                    dr.Close()
                End Using
            End Using

        Catch ex As Exception

            If CodiceSede = "00" Then
                AbilitazioniSedeStringa = "S;S;S;S"
            Else
                AbilitazioniSedeStringa = "N;N;N;N"
            End If
        End Try

    End Function

    Private Sub Liste(ByRef cn As OleDbConnection,
                      ByRef ErroreListe As String)

        Dim cmd As New OleDb.OleDbCommand

        Try
            'inizializzo la tabella forzature con la struttura vuota
            With cmd
                .Connection = cn
                .CommandType = CommandType.Text
                .CommandText = "SELECT DISTINCT * FROM Liste"
            End With

            Dim da As New OleDbDataAdapter With {.SelectCommand = cmd}
            da.Fill(dsConfig, "Liste")

            ErroreListe = "+OK"

        Catch ex As Exception
            ErroreListe = "-ERR|" + ex.Message
            Log.BoxErrore(ex)
        Finally
            cmd.Dispose()
        End Try
    End Sub

    <WebMethod()>
    Public Function ForzatureDL(ByVal CodiceAgenzia As String,
                                ByVal CodiceSede As String) As String

        Dim cn As New OleDb.OleDbConnection
        Dim cmd As New OleDb.OleDbCommand
        Dim cmdFile As New OleDb.OleDbCommand
        Dim drCodici As OleDb.OleDbDataReader
        Dim drFile As OleDb.OleDbDataReader

        Try
            cn.ConnectionString = CnConfigDb
            cn.Open()

            With cmdFile
                .CommandType = CommandType.Text
                .Connection = cn
                .CommandText = "SELECT DISTINCT * FROM Forzature"
            End With

            With cmd
                .CommandType = CommandType.Text
                .Connection = cn
                .CommandText = "SELECT DISTINCT * " +
                               "FROM Config " +
                               "WHERE Agenzia = ? AND Sede = ?"

                .Parameters.AddWithValue("agenzia", CodiceAgenzia)
                .Parameters.AddWithValue("sede", CodiceSede)

                drCodici = .ExecuteReader
            End With

            Dim NomeFile As String = ""

            ForzatureDL = "+OK"
            Do While drCodici.Read
                drFile = cmdFile.ExecuteReader

                Do While drFile.Read
                    NomeFile = Replace(drFile("NomeFile"), "#agenzia#", drCodici("Collegata"), , , CompareMethod.Text)
                    ForzatureDL = ForzatureDL +
                                  "|" +
                                  drFile("TipoFile") + ";" +
                                  NomeFile + ";" +
                                  Format(drFile("DataInizio"), "dd/MM/yyyy HH:mm:ss")
                Loop

                drFile.Close()
            Loop

            drCodici.Close()

            'Non ci sono stringhe di configurazione per l'agenzia
            If ForzatureDL = "+OK" Then
                'Se la sede è 00 passa i file per il codice agenzia
                'altrimenti restituisce solo +OK che non da luogo a ulteriori download
                If CodiceSede = "00" Then 'sede centrale
                    drFile = cmdFile.ExecuteReader

                    Do While drFile.Read
                        NomeFile = Replace(drFile("NomeFile"), "#agenzia#", CodiceAgenzia, , , CompareMethod.Text)
                        ForzatureDL = ForzatureDL +
                                      "|" +
                                      drFile("TipoFile") + ";" +
                                      NomeFile + ";" +
                                      Format(drFile("DataInizio"), "dd/MM/yyyy HH:mm:ss")
                    Loop

                    drFile.Close()
                End If
            End If

        Catch ex As Exception
            ForzatureDL = "-ERR|" + ex.Message
            Log.BoxErrore(ex)
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
            cmd.Dispose()
            cmdFile.Dispose()
            cn.Dispose()
        End Try
    End Function

    <WebMethod()>
    Public Function AgenzieCollegate(ByVal Compagnia As Integer,
                                     ByVal CodiceAgenzia As String,
                                     ByVal CodiceSede As String) As String

        'per vecchia versione senza codice compagnia
        If Compagnia = 0 Then Return CodiceAgenzia

        Try
            Using cn As New OleDb.OleDbConnection(CnConfigDb)
                cn.Open()

                Using cmd As New OleDb.OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = String.Format("SELECT Collegate FROM AgenzieCollegate WHERE Compagnia = {0} AND Agenzia = '{1}' AND Sede = '{2}'",
                                                    Compagnia, CodiceAgenzia, CodiceSede)

                    AgenzieCollegate = cmd.ExecuteScalar

                    'se non trova niente restituisce il codice passato
                    If AgenzieCollegate Is Nothing Then
                        AgenzieCollegate = CodiceAgenzia
                    End If
                End Using
            End Using

        Catch ex As Exception
            AgenzieCollegate = CodiceAgenzia
            Log.BoxErrore(ex)
        End Try
    End Function

    <WebMethod()>
    Public Function AgenzieCollegateEx(ByVal Compagnia As Integer,
                                       ByVal CodiceAgenzia As String,
                                       ByVal CodiceSede As String) As String
        Try
            Using cn As New OleDb.OleDbConnection(CnConfigDb)
                cn.Open()

                Using cmd As New OleDb.OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    'le collegate
                    cmd.CommandText = String.Format("SELECT Collegate FROM AgenzieCollegate WHERE Compagnia = {0} AND Agenzia = '{1}' AND Sede = '{2}'",
                                                    Compagnia, CodiceAgenzia, CodiceSede)
                    Dim Collegate As String = cmd.ExecuteScalar
                    'se non trovo niente restituisco il codice agenzia
                    If Collegate Is Nothing Then Collegate = CodiceAgenzia
                    'ora la postalizzazione
                    cmd.CommandText = String.Format("SELECT Collegate FROM GestionePostalizzazione WHERE Compagnia = {0} AND Agenzia = '{1}' AND Sede = '{2}'",
                                                    Compagnia, CodiceAgenzia, CodiceSede)
                    Dim Postalizzate As String = cmd.ExecuteScalar
                    'se non trovo impostazioni di postalizzazione restituisco le collegate
                    If Postalizzate Is Nothing Then
                        If ("DR-00".Contains(CodiceSede)) Then
                            'per la sede principale restituisco le collegate
                            Postalizzate = Collegate
                        Else
                            'per le sedi secondarie, se non configurate in GestionePostalizzazione, non restituisco niente
                            Postalizzate = ""
                        End If
                    End If

                    Return String.Format("{0}|{1}", Collegate, Postalizzate)
                End Using
            End Using

        Catch ex As Exception
            Log.BoxErrore(ex)
            'restituisce il codice passato
            Return String.Format("{0}|{1}", CodiceAgenzia, CodiceAgenzia)
        End Try
    End Function

    <WebMethod()>
    Public Function MenuExtra(AgenziaMadre As String,
                              CodiceSede As String,
                              Utente As String) As DataSet
        Try
            Using cn As New OleDb.OleDbConnection(CnServizi)
                cn.Open()

                Using cmd As New OleDb.OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    'voci di menù
                    cmd.CommandText = "SELECT * FROM MenuExtra " &
                                      "WHERE (Agenzia = @agenzia OR Agenzia = 'TUTTE') AND (Sede = @sede OR Sede = 'TUTTE') AND (Utente = @utente OR Utente = 'TUTTI')"
                    cmd.Parameters.AddWithValue("agenzia", AgenziaMadre)
                    cmd.Parameters.AddWithValue("sede", CodiceSede)
                    cmd.Parameters.AddWithValue("utente", Utente)

                    Using da As New OleDbDataAdapter(cmd)
                        Using dt As New DataTable
                            dt.TableName = "MenuExtra"
                            da.Fill(dt)
                            'creo dataset da restituire
                            Using ds As New DataSet
                                ds.Tables.Add(dt)
                                Return ds
                            End Using
                        End Using
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Log.BoxErrore(ex)
            Return Nothing
        End Try
    End Function

    <WebMethod()>
    Public Function AbilitaMenuExtra(Agenzia As String, Sede As String, Utente As String) As String
        Try
            Using cn As New OleDb.OleDbConnection(CnServizi)
                cn.Open()

                Using cmd As New OleDb.OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    'cancello settaggio precedente
                    cmd.CommandText = String.Format("DELETE FROM MenuExtra WHERE (Agenzia = '{0}') AND (Sede = '{1}') AND (Utente = '{2}')", Agenzia, Sede, Utente)
                    cmd.ExecuteNonQuery()
                    'voci di menù
                    cmd.CommandText = "INSERT INTO MenuExtra " &
                                      "SELECT '{0}' AS Agenzia,'{1}' AS Sede,'{2}' AS Utente,Chiave,Descrizione,targetComando,targetNuovaPagina,id_menu FROM MenuExtra WHERE Agenzia = 'ABASE'"
                    cmd.CommandText = String.Format(cmd.CommandText, Agenzia, Sede, Utente)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return "+OK"
        Catch ex As Exception
            Log.BoxErrore(ex)
            Return ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function CancellaMenuExtra(Agenzia As String, Sede As String, Utente As String) As String
        Try
            Using cn As New OleDb.OleDbConnection(CnServizi)
                cn.Open()

                Using cmd As New OleDb.OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    'cancello settaggio precedente
                    cmd.CommandText = String.Format("DELETE FROM MenuExtra WHERE (Agenzia = '{0}') AND (Sede = '{1}') AND (Utente = '{2}')", Agenzia, Sede, Utente)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return "+OK"
        Catch ex As Exception
            Log.BoxErrore(ex)
            Return ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function TabellaAgenzieCollegate(ByVal Compagnia As Integer,
                                            ByVal CodiceAgenzia As String,
                                            ByVal CodiceSede As String) As DataSet

        Dim cn As New OleDb.OleDbConnection
        Dim cmd As New OleDb.OleDbCommand
        Dim ds As New DataSet

        Try
            cn.ConnectionString = CnConfigDb
            cn.Open()

            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT * " +
                              "FROM AgenzieCollegate " +
                              "WHERE Compagnia = ? AND Agenzia = ? AND Sede = ?"

            cmd.Parameters.AddWithValue("compagnia", Compagnia)
            cmd.Parameters.AddWithValue("agenzia", CodiceAgenzia)
            cmd.Parameters.AddWithValue("sede", CodiceSede)

            Dim da As New OleDbDataAdapter
            da.SelectCommand = cmd

            da.Fill(ds, "AgenzieCollegate")

        Catch ex As Exception
            Log.BoxErrore(ex)
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
            cmd.Dispose()
            cn.Dispose()
        End Try

        Try
            'se non c'è configurazione per l'agenzia aggiunge una riga per se stessa
            If ds.Tables("AgenzieCollegate").Rows.Count = 0 Then

                Dim rowArray() As Object = {Compagnia, CodiceAgenzia, CodiceSede, CodiceAgenzia}

                ds.Tables("AgenzieCollegate").Rows.Add(rowArray)
            End If

        Catch ex As Exception
            Log.BoxErrore(ex)
        End Try

        Return ds

    End Function

    Public Function ContabilitaEx(ByRef cn As OleDbConnection,
                                  ByVal CodiceAgenzia As String) As String

        Dim cmd As New OleDb.OleDbCommand

        Try
            With cmd
                .Connection = cn
                .CommandType = CommandType.Text
                .CommandText = "SELECT * " +
                               "FROM Contabilita " +
                               "WHERE Agenzia = ?"

                .Parameters.AddWithValue("Agenzia", CodiceAgenzia)
            End With

            Dim da As New OleDbDataAdapter
            da.SelectCommand = cmd
            da.Fill(dsConfig, "Contabilita")

            'azzero il campo forzatura: la forzatura avviene una sola volta.
            With cmd
                .CommandText = "UPDATE Contabilita " +
                               "SET Forzatura = ? " +
                               "WHERE Agenzia = ?"

                .Parameters.Clear()
                .Parameters.AddWithValue("Forzatura", System.DBNull.Value)
                .Parameters.AddWithValue("Agenzia", CodiceAgenzia)

                .ExecuteNonQuery()
            End With

            ContabilitaEx = "+OK"

        Catch ex As Exception
            ContabilitaEx = "-ERR|" + ex.Message
            Log.BoxErrore(ex)
        Finally
            cmd.Dispose()
        End Try

    End Function

    <WebMethod()>
    Public Function AgenziaBloccata(ByVal Compagnia As Integer,
                                    ByVal CodiceAgenzia As Integer,
                                    ByVal Pc As String,
                                    ByVal VersioneUt As String,
                                    ByRef Prod As String,
                                    ByRef Test As String,
                                    ByRef Lab As String,
                                    ByRef Gruppo As String,
                                    ByRef Errore As String) As Boolean

        Dim cn As New OleDb.OleDbConnection
        Dim cmd As New OleDb.OleDbCommand

        Try
            AggiornaStatistiche(Compagnia, CodiceAgenzia, Pc, VersioneUt)

            cn.ConnectionString = CnConfigDb
            cn.Open()

            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT Count(*) " +
                              "FROM AgenzieAbilitate " +
                              "WHERE Compagnia = ? AND Agenzia = ?"

            cmd.Parameters.AddWithValue("Compagnia", Compagnia)
            cmd.Parameters.AddWithValue("Agenzia", CodiceAgenzia)

            AgenziaBloccata = (cmd.ExecuteScalar = 0) 'non la trovo è bloccata

            'imposta tipologia dell'agenzia
            If AgenziaBloccata = True Then
                Prod = "N"
                Test = "N"
                Lab = "N"
                Gruppo = "Bloccate"
            Else
                Dim Tipologia As String = TipoAgenzia(Compagnia, CodiceAgenzia, cn)

                Prod = "S"
                Test = Tipologia.Split(";")(0)
                Lab = Tipologia.Split(";")(1)
                Gruppo = Tipologia.Split(";")(2)
            End If

            'processo concluso senza errori
            Errore = "+OK"

        Catch ex As Exception
            Errore = "-ERR|" + ex.Message
            Log.BoxErrore(ex)

            AgenziaBloccata = True
            Prod = "N"
            Test = "N"
            Lab = "N"
            Gruppo = ""
        Finally
            cmd.Dispose()
            cn.Close()
            cn.Dispose()
        End Try

        If AgenziaBloccata Then
            Log.AddLog(String.Format("Abilitazione: Agenzia bloccata {0}-{1}-Gruppo <{2}>-{3}",
                                     Compagnia, CodiceAgenzia.ToString.PadLeft(5, "0"), Gruppo, Pc))
        Else
            Log.AddLog(String.Format("Abilitazione: Agenzia {0}-{1}-Gruppo <{2}>-{3}",
                                     Compagnia, CodiceAgenzia.ToString.PadLeft(5, "0"), Gruppo, Pc))
        End If

    End Function

    <WebMethod()>
    Public Function TipologiaAgenzia(ByVal Compagnia As Integer,
                                     ByVal Agenzia As Integer,
                                     ByRef Prod As String,
                                     ByRef Test As String,
                                     ByRef Lab As String,
                                     ByRef Gruppo As String) As String

        Dim cn As New OleDb.OleDbConnection
        Dim cmd As New OleDb.OleDbCommand

        Try
            cn.ConnectionString = CnConfigDb
            cn.Open()

            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT Test + ';' + Lab + ';' + Trim(Gruppo) " +
                              "FROM AgenzieTest " +
                              "WHERE Compagnia = ? AND Agenzia = ?"

            cmd.Parameters.AddWithValue("Compagnia", Compagnia)
            cmd.Parameters.AddWithValue("Agenzia", Agenzia)

            Dim Tipologia As String = cmd.ExecuteScalar

            If Tipologia Is Nothing Then
                Prod = "S"
                Test = "N"
                Lab = "N"
                Gruppo = ""

            ElseIf Tipologia.Trim = String.Empty Then
                Prod = "S"
                Test = "N"
                Lab = "N"
                Gruppo = ""

            Else
                Prod = "S"
                Test = Tipologia.Split(";")(0)
                Lab = Tipologia.Split(";")(1)
                Gruppo = Tipologia.Split(";")(2)
            End If

            'processo concluso senza errori
            TipologiaAgenzia = "+OK"

        Catch ex As Exception
            TipologiaAgenzia = "-ERR|" + ex.Message
            Log.BoxErrore(ex)

            Prod = "S"
            Test = "N"
            Lab = "N"
            Gruppo = ""
        Finally
            cmd.Dispose()
            cn.Close()
            cn.Dispose()
        End Try

        Log.AddLog(String.Format("Tipologia: Agenzia {0}-{1}-Gruppo: {2}-Prod: {3}-Test: {4}-Lab: {5}",
                                 Compagnia, Agenzia.ToString.PadLeft(5, "0"), Gruppo, Prod, Test, Lab))

    End Function

    <WebMethod()>
    Public Function AgenziaBloccataAsp(ByVal Compagnia As Integer,
                                       ByVal CodiceAgenzia As Integer) As Boolean

        'funzione richiamata da una pagina asp

        Dim cn As New OleDb.OleDbConnection
        Dim cmd As New OleDb.OleDbCommand

        Try
            cn.ConnectionString = CnConfigDb
            cn.Open()

            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT Count(*) " +
                              "FROM AgenzieAbilitate " +
                              "WHERE Compagnia = ? AND Agenzia = ?"

            cmd.Parameters.AddWithValue("Compagnia", Compagnia)
            cmd.Parameters.AddWithValue("Agenzia", CodiceAgenzia)

            AgenziaBloccataAsp = (cmd.ExecuteScalar = 0) 'non la trovo è bloccata

        Catch ex As Exception
            Log.BoxErrore(ex)
            Return True
        Finally
            cmd.Dispose()
            cn.Close()
            cn.Dispose()
        End Try

    End Function

    <WebMethod()>
    Public Function CercaAggiornamento(ByVal Compagnia As Integer,
                                       ByVal Agenzia As Integer,
                                       ByVal VersioneCorrente As Integer,
                                       ByVal SubVersioneCorrente As Integer,
                                       ByRef NuovaVersione As Integer,
                                       ByRef NuovaSubVersione As Integer,
                                       ByRef NuovoTipo As String) As String

        Dim cn As New OleDb.OleDbConnection
        Dim cmd As New OleDb.OleDbCommand

        Try
            cn.ConnectionString = CnConfigDb
            cn.Open()

            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT TOP 1 * " +
                              "FROM Aggiornamenti " +
                              "WHERE (TipoFile = ?) AND " +
                                    "(Versione > ? Or (Versione = ? AND SubVersione > ?))"

            'file Prod
            Dim Tipo As Integer = 0

            cmd.Parameters.AddWithValue("TipoFile", Tipo)
            cmd.Parameters.AddWithValue("Versione", VersioneCorrente)
            cmd.Parameters.AddWithValue("Versione2", VersioneCorrente)
            cmd.Parameters.AddWithValue("SubVersione", SubVersioneCorrente)

            Dim dr As OleDbDataReader = cmd.ExecuteReader

            If dr.HasRows Then
                dr.Read()
                NuovaVersione = dr("Versione")
                NuovaSubVersione = dr("SubVersione")
                NuovoTipo = "Prod"
            Else
                NuovaVersione = 0
                NuovaSubVersione = 0
                NuovoTipo = ""
            End If

            dr.Close()

            'controllo il tipo di agenzia
            Dim AgenziaTestLab As String = TipoAgenzia(Compagnia, Agenzia, cn)
            'assegno il valore ai flag
            Dim IsAgenziaTest As Boolean = (AgenziaTestLab.Split(";")(0) = "S")
            Dim IsAgenziaLab As Boolean = (AgenziaTestLab.Split(";")(1) = "S")

            'file test
            If NuovaVersione = 0 AndAlso IsAgenziaTest Then
                Tipo = 1

                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("TipoFile", Tipo)
                cmd.Parameters.AddWithValue("Versione", VersioneCorrente)
                cmd.Parameters.AddWithValue("Versione2", VersioneCorrente)
                cmd.Parameters.AddWithValue("SubVersione", SubVersioneCorrente)

                dr = cmd.ExecuteReader

                If dr.HasRows Then
                    dr.Read()
                    NuovaVersione = dr("Versione")
                    NuovaSubVersione = dr("SubVersione")
                    NuovoTipo = "Test"
                Else
                    NuovaVersione = 0
                    NuovaSubVersione = 0
                    NuovoTipo = ""
                End If

                dr.Close()
            End If

            'file lab
            If NuovaVersione = 0 AndAlso IsAgenziaLab Then
                Tipo = 2

                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("TipoFile", Tipo)
                cmd.Parameters.AddWithValue("Versione", VersioneCorrente)
                cmd.Parameters.AddWithValue("Versione2", VersioneCorrente)
                cmd.Parameters.AddWithValue("SubVersione", SubVersioneCorrente)

                dr = cmd.ExecuteReader

                If dr.HasRows Then
                    dr.Read()
                    NuovaVersione = dr("Versione")
                    NuovaSubVersione = dr("SubVersione")
                    NuovoTipo = "Lab"
                Else
                    NuovaVersione = 0
                    NuovaSubVersione = 0
                    NuovoTipo = ""
                End If

                dr.Close()
            End If

            Return "+OK"

        Catch ex As Exception
            Log.BoxErrore(ex)

            NuovaVersione = 0
            NuovaSubVersione = 0
            Return "-ERR|" + ex.Message
        Finally
            cmd.Dispose()
            cn.Close()
            cn.Dispose()
        End Try

    End Function

    <WebMethod()>
    Public Function ListinoSms(ByVal Compagnia As Integer,
                               ByVal CodiceAgenzia As Integer) As String

        'restituisce il listino sms applicato all'agenzia sotto forma di stringa
        'con l'accoppiata quantità-prezzo. La quantità 0 indica l'eventuale canone di abbonamento

        Dim cn As New OleDb.OleDbConnection
        Dim cmd As New OleDb.OleDbCommand

        Try
            cn.ConnectionString = CnConfigDb
            cn.Open()

            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT Quantita,Prezzo " +
                              "FROM ListinoSms L " +
                              "INNER JOIN AgenzieAbilitate A ON L.Listino = A.ListinoSms " +
                              "WHERE Compagnia = ? AND Agenzia = ? " +
                              "ORDER BY Quantita"

            cmd.Parameters.AddWithValue("Compagnia", Compagnia)
            cmd.Parameters.AddWithValue("Agenzia", CodiceAgenzia)

            Dim dr As OleDbDataReader = cmd.ExecuteReader

            If dr.HasRows Then

                ListinoSms = ""

                Do While dr.Read
                    ListinoSms += dr("Quantita").ToString + "-" + dr("Prezzo").ToString + ";"
                Loop

                ListinoSms = ListinoSms.Substring(0, ListinoSms.Length - 1)
                ListinoSms = "+OK|" + ListinoSms
            Else
                ListinoSms = "-ERR: Listino non trovato"
            End If

            dr.Close()

        Catch ex As Exception
            Log.BoxErrore(ex)
            Return "-ERR|" + ex.Message
        Finally
            cmd.Dispose()
            cn.Close()
            cn.Dispose()
        End Try

    End Function

    Private Function TipoAgenzia(ByVal Compagnia As Integer,
                                 ByVal Agenzia As Integer,
                                 ByRef cn As OleDbConnection) As String

        Dim cmd As New OleDb.OleDbCommand

        Try
            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT Test + ';' + Lab + ';' + Trim(Gruppo) " +
                              "FROM AgenzieTest " +
                              "WHERE Compagnia = ? AND Agenzia = ?"

            cmd.Parameters.AddWithValue("Compagnia", Compagnia)
            cmd.Parameters.AddWithValue("Agenzia", Agenzia)

            TipoAgenzia = cmd.ExecuteScalar

            If TipoAgenzia Is Nothing Then
                TipoAgenzia = "N;N;N"
            ElseIf TipoAgenzia.Trim = String.Empty Then
                TipoAgenzia = "N;N;N"
            End If

        Catch ex As Exception
            Log.BoxErrore(ex)
            Return "N;N;N"
        Finally
            cmd.Dispose()
        End Try

    End Function

    Private Sub AggiornaStatistiche(ByVal Compagnia As Integer,
                                    ByVal CodiceAgenzia As Integer,
                                    ByRef Pc As String,
                                    ByVal VersioneUt As String)

        Dim cn As New OleDb.OleDbConnection
        Dim cmd As New OleDb.OleDbCommand

        Try
            cn.ConnectionString = MdbDriver + StatisticheDb
            cn.Open()

            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT Count(*) " +
                              "FROM AccessiLiveUp " +
                              "WHERE Compagnia = ? AND Agenzia = ? AND Pc = ? AND " +
                                    "DataOra = Date()"

            cmd.Parameters.AddWithValue("Compagnia", Compagnia)
            cmd.Parameters.AddWithValue("Agenzia", CodiceAgenzia)
            cmd.Parameters.AddWithValue("Pc", Pc)
            cmd.Parameters.AddWithValue("DataOra", Now.Date)
            cmd.Parameters.AddWithValue("Ora", Format(Now, "HH:mm"))
            cmd.Parameters.AddWithValue("Versione", VersioneUt)

            If cmd.ExecuteScalar = 0 Then
                cmd.CommandText = "INSERT INTO AccessiLiveUp(Compagnia,Agenzia,Pc,DataOra,Ora,VersioneUt) " +
                                  "VALUES(?,?,?,?,?,?)"
                cmd.ExecuteNonQuery()
            End If

        Catch ex As Exception
            Log.BoxErrore(ex)
        Finally
            cmd.Dispose()
            cn.Close()
            cn.Dispose()
        End Try

    End Sub

    <WebMethod()>
    Public Function Province(ByRef Errore As String) As DataSet

        Dim cn As New OleDb.OleDbConnection
        Dim cmd As New OleDb.OleDbCommand
        Dim ds As New DataSet

        Try
            cn.ConnectionString = CnConfigDb
            cn.Open()

            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT * FROM Province"

            Dim da As New OleDbDataAdapter
            da.SelectCommand = cmd

            da.Fill(ds, "Province")

            Errore = "+OK"

        Catch ex As Exception
            Errore = "-ERR|" + ex.Message
            Log.BoxErrore(ex)
        Finally
            cmd.Dispose()
            cn.Close()
            cn.Dispose()
        End Try

        'restituisco il dataset con le province
        Return ds

    End Function

    <WebMethod()>
    Public Function DatiVersione(ByVal Compagnia As Integer,
                                 ByVal CodiceAgenzia As String,
                                 ByVal VersioneCorrente As String,
                                 ByVal Ambiente As String,
                                 ByRef LogON As Boolean,
                                 ByRef Errore As String) As DataSet

        'con questo flag posso accendere/spegnere il log di liveupdate
        LogON = True

        'l'ambiente PP2DIR che viene trasmesso è equivalente a PP
        If Ambiente = "PP2DIR" Then Ambiente = "PP"

        Dim cn As New OleDb.OleDbConnection
        Dim cmd As New OleDb.OleDbCommand
        Dim ds As New DataSet

        Try
            cn.ConnectionString = MdbDriver + ControlloVersioneDb
            cn.Open()

            'imposto le query
            Dim Query As String = "SELECT cv.*, c.Path AS PathDestinazione " +
                                  "FROM ControlloVersione cv " +
                                  "INNER JOIN Cartelle c ON c.Cartella = cv.Destinazione " +
                                  "WHERE cv.{0} = True AND " +
                                        "VersioneUT = '{1}' AND " +
                                        "(Ambiente = '{2}' OR Ambiente = 'DIR/PP') " +
                                  "ORDER BY Modulo"

            Dim QueryGruppo As String = "SELECT cv.*, c.Path AS PathDestinazione " +
                                        "FROM {0} cv " +
                                        "INNER JOIN Cartelle c ON c.Cartella = cv.Destinazione " +
                                        "WHERE VersioneUT = '{1}' AND " +
                                              "(Ambiente = '{2}' OR Ambiente = 'DIR/PP')"

            Dim QueryDelete As String = "SELECT e.*,c.Path AS PathDestinazione " +
                                        "FROM ElementiDaEliminare e " +
                                        "INNER JOIN Cartelle c ON c.Cartella = e.Destinazione " +
                                        "WHERE e.{0} = True AND " +
                                              "VersioneUT = '{1}' AND " +
                                              "(Ambiente = '{2}' OR Ambiente = 'DIR/PP') AND " +
                                              "Tipo = '{3}'"

            cmd.Connection = cn
            cmd.CommandType = CommandType.Text

            Dim TipoAgenzia As String = TipologiaAgenzia(Compagnia, CodiceAgenzia, Errore)

            If Errore.StartsWith("-ERR") Then Exit Try

            Select Case TipoAgenzia

                Case "Prod", "Test", "Lab"

                    cmd.CommandText = String.Format(Query, TipoAgenzia, VersioneCorrente, Ambiente)

                Case Else 'gruppo

                    cmd.CommandText = String.Format(QueryGruppo, TipoAgenzia, VersioneCorrente, Ambiente)

            End Select

            'leggo i dati della versione
            Dim da As New OleDbDataAdapter
            da.SelectCommand = cmd

            da.Fill(ds, "Versione")

            'leggo i file e le cartelle da cancellare
            Select Case TipoAgenzia

                Case "Prod", "Test", "Lab"

                    'i file
                    cmd.CommandText = String.Format(QueryDelete, TipoAgenzia, VersioneCorrente, Ambiente, "F")
                    da.Fill(ds, "FileDaEliminare")

                    'le cartelle
                    cmd.CommandText = String.Format(QueryDelete, TipoAgenzia, VersioneCorrente, Ambiente, "C")
                    da.Fill(ds, "CartelleDaEliminare")

                Case Else 'gruppo

                    'per i gruppi vengono restituite 2 tabelle vuote perché altrimenti bisognerebbe compilare
                    'delle tabelle ad hoc per ogni gruppo
                    cmd.CommandText = "SELECT * FROM ElementiDaEliminare WHERE False"

                    da.Fill(ds, "FileDaEliminare")
                    da.Fill(ds, "CartelleDaEliminare")

            End Select

        Catch ex As Exception
            Errore = "-ERR|" + ex.Message
            Log.BoxErrore(ex)
        Finally
            cn.Close()
            cmd.Dispose()
            cn.Dispose()
        End Try

        'restituisco il dataset di versione
        Return ds

    End Function

    <WebMethod()>
    Public Function DatiVersioneLivello(ByVal Compagnia As Integer,
                                        ByVal CodiceAgenzia As String,
                                        ByVal VersioneCorrente As String,
                                        ByVal Ambiente As String,
                                        ByRef Agenzia As DatiAgenzia,
                                        ByRef Esito As EsitoServizio) As DataSet

        Dim ds As New DataSet
        Dim cv As ControlloVersione

        Try
            cv = New ControlloVersione(Compagnia, CodiceAgenzia, VersioneCorrente, Ambiente, CartellaLog)
            cv.CnConfigDb = CnConfigDb
            cv.CnControlloVersioneDb = CnControlloVersioneDb

            'tabella dei componenti per il livello dell'agenzia
            Dim dtVersione As DataTable = cv.Componenti(Agenzia)
            dtVersione.TableName = "Versione"
            ds.Tables.Add(dtVersione)

            'tabella dei file da eliminare
            Dim dtFile As DataTable = cv.ElementiDaEliminare(Agenzia, "F")
            dtFile.TableName = "FileDaEliminare"
            ds.Tables.Add(dtFile)

            'tabella delle cartelle da eliminare
            Dim dtCartelle As DataTable = cv.ElementiDaEliminare(Agenzia, "C")
            dtCartelle.TableName = "CartelleDaEliminare"
            ds.Tables.Add(dtCartelle)

            Esito.EsitoChiamata = True

        Catch ex As Exception
            ds.Tables.Add(New DataTable("Versione"))
            ds.Tables.Add(New DataTable("FileDaEliminare"))
            ds.Tables.Add(New DataTable("CartelleDaEliminare"))

            Esito.EsitoChiamata = False
            Esito.MessaggioErrore = ex.Message
        End Try

        'restituisco il dataset di versione
        Return ds

    End Function

    <WebMethod()>
    Public Function VersioneLivello(ByVal Compagnia As Integer,
                                    ByVal CodiceAgenzia As String,
                                    ByVal VersioneCorrente As String,
                                    ByVal Ambiente As String,
                                    ByRef Agenzia As DatiAgenzia,
                                    ByRef Esito As EsitoServizio) As DataSet

        Dim ds As New DataSet
        Dim cv As ControlloVersione

        Try
            cv = New ControlloVersione(Compagnia, CodiceAgenzia, VersioneCorrente, Ambiente, CartellaLog)
            cv.CnConfigDb = CnConfigDb
            cv.CnControlloVersioneDb = CnControlloVersioneDb

            'tabella dei componenti per il livello dell'agenzia
            Dim dtVersione As DataTable
            'se viene passato un livello specifico ritorna i componenti di quel livello altrimenti
            'restituisce i componenti di tutti i livelli dell'agenzia (PROD,ecc...)
            If Agenzia.Livello.Trim.Length = 0 Then
                dtVersione = cv.Componenti(Agenzia)
            Else
                dtVersione = cv.Componenti(Agenzia.Livello)
            End If

            dtVersione.TableName = "Versione"
            ds.Tables.Add(dtVersione)

            'tabella dei file da eliminare
            Dim dtFile As DataTable = cv.ElementiDaEliminare(Agenzia, "F")
            dtFile.TableName = "FileDaEliminare"
            ds.Tables.Add(dtFile)

            'tabella delle cartelle da eliminare
            Dim dtCartelle As DataTable = cv.ElementiDaEliminare(Agenzia, "C")
            dtCartelle.TableName = "CartelleDaEliminare"
            ds.Tables.Add(dtCartelle)

            Esito.EsitoChiamata = True

        Catch ex As Exception
            ds.Tables.Add(New DataTable("Versione"))
            ds.Tables.Add(New DataTable("FileDaEliminare"))
            ds.Tables.Add(New DataTable("CartelleDaEliminare"))

            Esito.EsitoChiamata = False
            Esito.MessaggioErrore = ex.Message
        End Try

        'restituisco il dataset di versione
        Return ds

    End Function

    <WebMethod()>
    Public Function VersioneLivelloEx(ByVal Compagnia As Integer,
                                      ByVal CodiceAgenzia As String,
                                      ByVal VersioneCorrente As String,
                                      ByVal Ambiente As String,
                                      ByRef Agenzia As DatiAgenzia,
                                      ByRef Esito As EsitoServizio,
                                      ByVal MD5 As String) As DataSet

        Dim ds As New DataSet
        ds.DataSetName = MD5Database()

        If MD5 = ds.DataSetName Then
            Esito.EsitoChiamata = True
            Return Nothing
        Else
            Try
                Dim cv As ControlloVersione
                cv = New ControlloVersione(Compagnia, CodiceAgenzia, VersioneCorrente, Ambiente, CartellaLog)
                cv.CnConfigDb = CnConfigDb
                cv.CnControlloVersioneDb = CnControlloVersioneDb

                'tabella dei componenti per il livello dell'agenzia
                Dim dtVersione As DataTable
                'se viene passato un livello specifico ritorna i componenti di quel livello altrimenti
                'restituisce i componenti di tutti i livelli dell'agenzia (PROD,ecc...)
                If Agenzia.Livello.Trim.Length = 0 Then
                    dtVersione = cv.Componenti(Agenzia)
                Else
                    dtVersione = cv.Componenti(Agenzia.Livello)
                End If

                dtVersione.TableName = "Versione"
                ds.Tables.Add(dtVersione)

                'tabella dei file da eliminare
                Dim dtFile As DataTable = cv.ElementiDaEliminare(Agenzia, "F")
                dtFile.TableName = "FileDaEliminare"
                ds.Tables.Add(dtFile)

                'tabella delle cartelle da eliminare
                Dim dtCartelle As DataTable = cv.ElementiDaEliminare(Agenzia, "C")
                dtCartelle.TableName = "CartelleDaEliminare"
                ds.Tables.Add(dtCartelle)

                Esito.EsitoChiamata = True

            Catch ex As Exception
                ds.Tables.Add(New DataTable("Versione"))
                ds.Tables.Add(New DataTable("FileDaEliminare"))
                ds.Tables.Add(New DataTable("CartelleDaEliminare"))

                Esito.EsitoChiamata = False
                Esito.MessaggioErrore = ex.Message
            End Try

            'restituisco il dataset di versione
            Return ds
        End If
    End Function

    Private Function TipologiaAgenzia(ByVal Compagnia As Integer,
                                      ByVal Agenzia As Integer,
                                      ByRef Errore As String) As String

        Dim cn As New OleDb.OleDbConnection
        Dim cmd As New OleDb.OleDbCommand

        Try
            Errore = "+OK"

            cn.ConnectionString = CnConfigDb
            cn.Open()

            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT Test + ';' + Lab + ';' + Trim(Gruppo) " +
                              "FROM AgenzieTest " +
                              "WHERE Compagnia = ? AND Agenzia = ?"

            cmd.Parameters.AddWithValue("Compagnia", Compagnia)
            cmd.Parameters.AddWithValue("Agenzia", Agenzia)

            Dim Tipologia As String = cmd.ExecuteScalar

            If Tipologia Is Nothing Then
                Return "Prod"

            ElseIf Tipologia.Trim = String.Empty Then
                Return "Prod"

            ElseIf Tipologia.Split(";")(2).Trim <> "N" Then
                'gruppo
                Return Tipologia.Split(";")(2).Trim

            ElseIf Tipologia.Split(";")(1).Trim = "S" Then
                'agenzia lab
                Return "Lab"

            ElseIf Tipologia.Split(";")(0).Trim = "S" Then
                'agenzia test
                Return "Test"
            Else
                Return "Prod"
            End If

        Catch ex As Exception
            Errore = "-ERR|" + ex.Message
            Return "Prod"
        Finally
            cmd.Dispose()
            cn.Close()
            cn.Dispose()
        End Try

    End Function

    Public Function VersioneMinima(ByVal Compagnia As Integer,
                                   ByVal CodiceAgenzia As String,
                                   ByVal CodiceControllo As Integer) As Boolean
        'blocco lettura dati per versioni vecchie di IDati
        'compagnia/agenzia non sono usati ma potrebbero tornare utili
        Try
            If CodiceControllo = 99999999 Then
                Return False 'blocco x vecchie versioni prima del 07/01/2019
            Else
                Using cn As New OleDbConnection(CnConfigDb)
                    cn.Open()

                    Using cmd As New OleDbCommand
                        cmd.Connection = cn
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "SELECT VersioneMinima FROM VersioneMinima"

                        'ritorna falso se la versione minima (codice controllo) non è raggiunta
                        Return (CodiceControllo >= Format(cmd.ExecuteScalar, "yyyyMMdd"))
                    End Using
                End Using
            End If

        Catch ex As Exception
            Log.BoxErrore(ex)
            Return True 'nessun blocco
        End Try
    End Function

    <WebMethod()>
    Public Function Assicoop2Codice(ByVal Sigla As String) As String

        Dim cmd As New OleDb.OleDbCommand
        Dim c As New OleDb.OleDbConnection

        Try
            c.ConnectionString = CnConfigDb
            c.Open()

            'inizializzo la tabella forzature con la struttura vuota
            With cmd
                .Connection = c
                .CommandType = CommandType.Text
                .CommandText = "SELECT TOP 1 Codice FROM Assicoop WHERE Sigla = ?"

                .Parameters.Clear()
                .Parameters.AddWithValue("Sigla", Sigla)
            End With

            Return cmd.ExecuteScalar

        Catch ex As Exception

            Return ""

        Finally
            cmd.Dispose()
            c.Close()
            c.Dispose()
        End Try

    End Function

    <WebMethod()>
    Public Function CodiciSub(ByVal Compagnia As Integer,
                              ByVal CodiceAgenzia As String,
                              ByVal CodiceSede As String) As String

        Dim cn As New OleDb.OleDbConnection
        Dim cmd As New OleDb.OleDbCommand

        Try
            cn.ConnectionString = CnConfigDb
            cn.Open()

            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT DISTINCT CodiciSub " +
                              "FROM Config " +
                              "WHERE Compagnia = ? AND Agenzia = ? AND Sede = ?"

            cmd.Parameters.AddWithValue("Compagnia", Compagnia)
            cmd.Parameters.AddWithValue("Agenzia", CodiceAgenzia)
            cmd.Parameters.AddWithValue("Sede", CodiceSede)

            Return cmd.ExecuteScalar

        Catch ex As Exception
            Log.BoxErrore(ex)
            Return "-ERR|" + ex.Message
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
            cmd.Dispose()
            cn.Dispose()
        End Try

    End Function

    <WebMethod()>
    Public Function ConfigAgenzia(ByVal Compagnia As Integer,
                                  ByVal CodiceAgenzia As String,
                                  ByVal CodiceSede As String) As DataSet

        Log.AddLog(String.Format("Importa incassi/arretrati: Agenzia {0}-{1}-{2}",
                                 Compagnia, CodiceAgenzia, CodiceSede))

        Dim cn As New OleDb.OleDbConnection
        Dim cmd As New OleDb.OleDbCommand
        Dim ds As New DataSet

        Try
            cn.ConnectionString = CnConfigDb
            cn.Open()

            cmd.Connection = cn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "SELECT DISTINCT * " +
                              "FROM Config " +
                              "WHERE Compagnia = ? AND Agenzia = ? AND Sede = ? " +
                              "ORDER BY DataFine ASC"

            cmd.Parameters.AddWithValue("Compagnia", Compagnia)
            cmd.Parameters.AddWithValue("Agenzia", CodiceAgenzia)
            cmd.Parameters.AddWithValue("Sede", IIf(CodiceSede = "DR", "00", CodiceSede))

            Dim da As New OleDbDataAdapter
            da.SelectCommand = cmd

            Dim RecordConfig As Integer = da.Fill(ds, "Config")

            'se non c'è configurazione per l'agenzia e si tratta della sede centrale
            If RecordConfig = 0 And (CodiceSede = "00" OrElse CodiceSede = "DR") Then

                Dim rowArray() As Object = {Compagnia, CodiceAgenzia, False, CodiceSede, "", CodiceAgenzia, "", "",
                                            New DateTime(Today.Year - 3, 1, 1), #12/31/2100#, "S", "N", "S", "S", "S", "S"}

                ds.Tables("Config").Rows.Add(rowArray)
            End If

        Catch ex As Exception
            Log.BoxErrore(ex)
        Finally
            If cn.State = ConnectionState.Open Then cn.Close()
            cmd.Dispose()
            cn.Dispose()
        End Try

        'restituisco il dataset di configurazione
        Return ds

    End Function

    <WebMethod()>
    Public Function Abilitazioni(ByVal Compagnia As Integer,
                                 ByVal Agenzia As String) As String

        Try
            RegistraAccesso(Agenzia)

            Using wsUniarea As New ServiziUniarea.accessoCasa
                'in caso di errore il servizio restituisce tutti zero
                Return wsUniarea.checkMultiplo(Agenzia, Compagnia)
            End Using

        Catch ex As Exception
            Log.BoxErrore(ex)
            Return "0;0;0;0;0;0"
        End Try

    End Function

#Region "postalizzazione"
    <WebMethod()>
    Public Function ReportComunicazioniInviate(Agenzia As String, DataRiferimento As Date) As DataSet
        Dim ds As New DataSet
        Try
            Dim dt As New DataTable
            dt.TableName = "Report"
            ds.Tables.Add(dt)

            Using c As New OleDbConnection(CnPostalizzazione)
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT Lotto, Codice, Cip, SUM([Pagine Lettera]) AS Pagine, SUM([Sms Landing]) AS Landing, SUM(Email) AS Mail, SUM(Sms) AS Sms," +
                                             "SUM([Pagine Lettera] + [Sms Landing] + Email + Sms) AS Totale " +
                                      "FROM Com_Inviate " +
                                      "WHERE Codice = [@agenzia] AND VAL(MID([Data Invio],5,2)) = [@mese] AND VAL(MID([Data Invio],1,4)) = [@anno] " +
                                      "GROUP BY Lotto, Codice, Cip"
                    cmd.Parameters.AddWithValue("agenzia", Val(Agenzia))
                    cmd.Parameters.AddWithValue("mese", DataRiferimento.AddMonths(-1).Month)
                    cmd.Parameters.AddWithValue("anno", DataRiferimento.AddMonths(-1).Year)

                    Using da As New OleDbDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                    dt.Columns.Add("Periodo", System.Type.GetType("System.String"))
                    dt.Columns("Periodo").SetOrdinal(0)

                    Dim TotalePagine, TotaleLanding, TotaleMail, TotaleSms, Totale As Integer
                    For Each row As DataRow In dt.Rows
                        row("Periodo") = Format(DataRiferimento, "MM-yyyy")
                        TotalePagine += row("Pagine")
                        TotaleLanding += row("Landing")
                        TotaleMail += row("Mail")
                        TotaleSms += row("Sms")
                        Totale += row("Pagine") + row("Landing") + row("Mail") + row("Sms")
                    Next
                    dt.Rows.Add({Format(DataRiferimento, "MM-yyyy"), DBNull.Value, DBNull.Value, DBNull.Value, TotalePagine, TotaleLanding, TotaleMail, TotaleSms, Totale})
                    Return ds
                End Using
            End Using
        Catch ex As Exception
            Log.BoxErrore(ex)
            Return ds
        End Try
    End Function

    <WebMethod()>
    Public Function DateAutoPostalizzazioneEx() As String
        Try
            Using c As New OleDbConnection(CnPostalizzazione)
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT Trim(Valore) FROM Variabili WHERE Variabile = ?"
                    cmd.Parameters.AddWithValue("variabile", Variabili.Postalizzazione.ToString)
                    Return cmd.ExecuteScalar & ";" & Format(OggiPostalizzazione, "dd/MM/yyyy")
                End Using
            End Using
        Catch ex As Exception
            Log.BoxErrore(ex)
            Return "25;26;26"
        End Try
    End Function

    <WebMethod()>
    Public Function OggiPostalizzazione() As Date
        Try
            Using c As New OleDbConnection(CnPostalizzazione)
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT Trim(Valore) FROM Variabili WHERE Variabile = ?"
                    cmd.Parameters.AddWithValue("variabile", Variabili.OggiPostalizzazione.ToString)

                    Try
                        Dim Oggi As String = cmd.ExecuteScalar()

                        If IsDBNull(Oggi) Then
                            Return Today
                        ElseIf IsDate(Oggi) Then
                            Return Oggi
                        Else
                            Return Today
                        End If
                    Catch ex As Exception
                        Return Today
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Log.BoxErrore(ex)
            Return Today
        End Try
    End Function

    <WebMethod()>
    Public Function CambiaOggiPostalizzazione(OggiPostalizzazione As String) As Boolean
        Try
            Using c As New OleDbConnection(CnPostalizzazione)
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "UPDATE Variabili SET Valore = @stringa WHERE Variabile = 'OggiPostalizzazione'"
                    cmd.Parameters.AddWithValue("@stringa", OggiPostalizzazione)
                    Return cmd.ExecuteScalar
                End Using
            End Using
            Return True
        Catch ex As Exception
            Log.BoxErrore(ex)
            Return False
        End Try
    End Function

    <WebMethod()>
    Public Function CambiaDatePostalizzazione(InizioManuale As Integer, InizioAuto As Integer, FineAuto As Integer) As Boolean
        Try
            Dim StringaDate As String = String.Format("{0};{1};{2}", InizioManuale, InizioAuto, FineAuto)

            Using c As New OleDbConnection(CnPostalizzazione)
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "UPDATE Variabili SET Valore = @stringa WHERE Variabile = 'Postalizzazione'"
                    cmd.Parameters.AddWithValue("@stringa", StringaDate)
                    Return cmd.ExecuteScalar
                End Using
            End Using
            Return True
        Catch ex As Exception
            Log.BoxErrore(ex)
            Return False
        End Try
    End Function

    <WebMethod()>
    Public Function DatiPostalizzazione(Ambiente As String,
                                        Modo As String,
                                        Agenzia As String,
                                        Sede As String,
                                        Localita As String,
                                        Pc As String,
                                        Utente As String,
                                        Mese As Integer,
                                        Anno As Integer,
                                        DataInvio As Date,
                                        FileDati As String,
                                        IdCampagna As Integer,
                                        Clienti As Integer,
                                        Titoli As Integer,
                                        Comunicazioni As Integer,
                                        CodiciAbilitati As String) As String

        Try
            Using cn As New OleDbConnection(CnPostalizzazione)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "INSERT INTO Postalizzazione (Ambiente,Modo,Agenzia,Sede,Localita,Pc,Utente,Mese,Anno,DataInvio,FileDati,IdCampagna,Clienti,Titoli,Comunicazioni,CodiciAbilitati) " +
                                      "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
                    With cmd.Parameters
                        .AddWithValue("ambiente", Ambiente)
                        .AddWithValue("modo", Modo)
                        .AddWithValue("agenzia", Agenzia)
                        .AddWithValue("sede", Sede)
                        .AddWithValue("localita", Localita)
                        .AddWithValue("pc", Pc)
                        .AddWithValue("utente", Utente)
                        .AddWithValue("mese", Mese)
                        .AddWithValue("anno", Anno)
                        .AddWithValue("data", DataInvio.ToString)
                        .AddWithValue("file", FileDati)
                        .AddWithValue("id", IdCampagna)
                        .AddWithValue("clienti", Clienti)
                        .AddWithValue("titoli", Titoli)
                        .AddWithValue("com", Comunicazioni)
                        .AddWithValue("codici", CodiciAbilitati)
                    End With

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Return "+OK"

        Catch ex As Exception
            RegistraErrorePostalizzazione(Agenzia, ex.Message)
            Log.BoxErrore(ex)
            Return "-ERR|" + ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function CodiciAttiviPostalizzazione(Codici As String, Localita As String) As String
        Try
            Using cn As New OleDbConnection(CnPostalizzazione)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text

                    'stringa passata: 01234;0|01949;1|... 0=non attivo e 1=attivo
                    For Each a As String In Codici.Split("|")
                        'cancello il codice
                        cmd.CommandText = "DELETE FROM CodiciAttivi WHERE Codice = ?"
                        cmd.Parameters.Clear()
                        cmd.Parameters.AddWithValue("codice", a.Split(";")(0))
                        cmd.ExecuteNonQuery()

                        If a.Split(";")(1) = 1 Then
                            cmd.CommandText = "INSERT INTO CodiciAttivi (Codice,Localita,Attivazione) VALUES(?,?,?)"
                            cmd.Parameters.AddWithValue("localita", Localita)
                            cmd.Parameters.AddWithValue("data", Now.ToString)
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End Using
            End Using

            Return "+OK"

        Catch ex As Exception
            RegistraErrorePostalizzazione("00000", ex.Message)
            Log.BoxErrore(ex)
            Return "-ERR|" + ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function CodiciNonAttiviPostalizzazione() As DataSet
        Dim ds As New DataSet
        Dim dt As New DataTable
        Try
            Using cn As New OleDbConnection(CnPostalizzazione)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT A.Agenzia,A.Descrizione FROM Abilitazioni AS A " +
                                      "LEFT JOIN CodiciAttivi AS C ON A.Agenzia = C.Codice " +
                                      "WHERE C.Codice IS NULL " +
                                      "ORDER BY A.Agenzia"
                    Dim da As New OleDbDataAdapter(cmd)
                    da.Fill(dt)
                    ds.Tables.Add(dt)
                End Using
            End Using
        Catch ex As Exception
            Log.BoxErrore(ex)
        End Try
        Return ds
    End Function

    <WebMethod()>
    Public Function CodiciAbilitatiPostalizzazione() As DataSet
        Try
            Using cn As New OleDbConnection(CnPostalizzazione)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT * FROM Abilitazioni ORDER BY Agenzia"

                    Using da As New OleDbDataAdapter(cmd)
                        Dim dt As New DataTable
                        da.Fill(dt)

                        Dim ds As New DataSet
                        ds.Tables.Add(dt)
                        Return ds
                    End Using
                End Using
            End Using

        Catch ex As Exception
            RegistraErrorePostalizzazione("00000", ex.Message)
            Log.BoxErrore(ex)
            Return New DataSet
        End Try
    End Function

    <WebMethod()>
    Public Function AbilitazionePostalizzazione(Agenzia As String, Localita As String, DataInizio As Date) As Boolean
        Try
            Using cn As New OleDbConnection(CnPostalizzazione)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "DELETE FROM Abilitazioni WHERE Agenzia = ?"
                    cmd.Parameters.AddWithValue("agenzia", Agenzia)
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "INSERT INTO Abilitazioni (Agenzia,Descrizione,InizioPostalizzazione) VALUES(?,?,?)"
                    cmd.Parameters.AddWithValue("localita", Left(Localita, 50))
                    cmd.Parameters.AddWithValue("inizio", Format(DataInizio, "dd/MM/yyyy"))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            RegistraErrorePostalizzazione("00000", ex.Message)
            Log.BoxErrore(ex)
            Return False
        End Try
    End Function

    <WebMethod()>
    Public Function EliminaAbilitazionePostalizzazione(Agenzia As String) As Boolean
        Try
            Using cn As New OleDbConnection(CnPostalizzazione)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "DELETE FROM Abilitazioni WHERE Agenzia = ?"
                    cmd.Parameters.AddWithValue("agenzia", Agenzia)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            RegistraErrorePostalizzazione("00000", ex.Message)
            Log.BoxErrore(ex)
            Return False
        End Try
    End Function

    <WebMethod()>
    Public Function CodiciMancantiPostalizzazione(Mese As Integer, Anno As Integer) As DataSet
        Dim ds As New DataSet
        Try
            'data di riferimento da confrontare con la data di inizio postalizzazione inserita in koinè
            Dim DataRiferimento As Date = New DateTime(Anno, Mese, DateTime.DaysInMonth(Anno, Mese))

            Using cn As New OleDbConnection(CnPostalizzazione)
                cn.Open()

                Using cmd As New OleDbCommand
                    'la tabella CodiciAttivi contiene i codici attivati via flag da unitools
                    'la tabella Postalizzazione contiene i lotti postalizzati
                    'la tabella Abilitazioni contiene i codici abilitati sul portale koinè
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT A.Codice,A.Localita,A.Attivazione,C.InizioPostalizzazione " +
                                      "FROM (CodiciAttivi AS A " +
                                      "LEFT JOIN (SELECT Agenzia FROM Postalizzazione WHERE Mese = @mese And Anno = @anno) AS B ON A.Codice = B.Agenzia) " +
                                      "INNER JOIN Abilitazioni AS C ON A.Codice = C.Agenzia " +
                                      "WHERE (B.Agenzia Is NULL) And C.InizioPostalizzazione <= @inizio " +
                                      "ORDER BY A.Localita,A.Codice"
                    cmd.Parameters.AddWithValue("mese", Mese)
                    cmd.Parameters.AddWithValue("anno", Anno)
                    cmd.Parameters.AddWithValue("inizio", Format(DataRiferimento, "dd/MM/yyyy"))

                    Dim dt As New DataTable
                    dt.TableName = "Mancanti"
                    Using da As New OleDbDataAdapter
                        da.SelectCommand = cmd
                        da.Fill(dt)

                        ds.Tables.Add(dt)
                    End Using
                End Using
            End Using

        Catch ex As Exception
            RegistraErrorePostalizzazione("00000", ex.Message)
            Log.BoxErrore(ex)
        End Try

        Return ds
    End Function

    <WebMethod()>
    Public Function RegistraErrorePostalizzazione(Agenzia As String, Errore As String) As String
        Try
            'registro errore
            Using cn As New OleDbConnection(CnPostalizzazione)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "INSERT INTO Errori (Agenzia,Data,Errore) VALUES(?,?,?)"
                    With cmd.Parameters
                        .AddWithValue("agenzia", Agenzia)
                        .AddWithValue("data", Now.ToString)
                        .AddWithValue("errore", Left(Errore, 256))
                    End With
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Return "+OK"

        Catch ex As Exception
            Return "-ERR|" + ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function ConsensoPostalizzazione(Agenzia As String) As Boolean
        Try
            Using cn As New OleDbConnection(CnPostalizzazione)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT COUNT(*) FROM Abilitazioni WHERE Agenzia = ?"
                    cmd.Parameters.AddWithValue("agenzia", Agenzia)
                    Return cmd.ExecuteScalar > 0
                End Using
            End Using

        Catch ex As Exception
            Return False
        End Try
    End Function

    <WebMethod()>
    Public Function MonitorPostalizzazione() As DataSet
        Dim ds As New DataSet
        Try
            Using cn As New OleDbConnection(CnPostalizzazione)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT * FROM Postalizzazione WHERE Ambiente <> 'avvtest' ORDER BY Anno DESC, Mese DESC, DataInvio DESC"

                    Using da As New OleDbDataAdapter(cmd)
                        da.Fill(ds, "Postalizzazione")
                    End Using
                End Using
            End Using

            Return ds

        Catch ex As Exception
            RegistraErrorePostalizzazione("00000", ex.Message)
            Log.BoxErrore(ex)
            Return ds
        End Try
    End Function

    <WebMethod()>
    Public Function MonitorPostalizzazioneMensile(Mese As Integer, Anno As Integer) As DataSet
        Dim ds As New DataSet
        Try
            Using cn As New OleDbConnection(CnPostalizzazione)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT * FROM Postalizzazione WHERE Mese = ? AND Anno = ? ORDER BY DataInvio DESC"
                    cmd.Parameters.AddWithValue("mese", Mese)
                    cmd.Parameters.AddWithValue("anno", Anno)

                    Using da As New OleDbDataAdapter(cmd)
                        da.Fill(ds, "Postalizzazione")
                    End Using
                End Using
            End Using

            Return ds

        Catch ex As Exception
            RegistraErrorePostalizzazione("00000", ex.Message)
            Log.BoxErrore(ex)
            Return ds
        End Try
    End Function

    <WebMethod()>
    Public Function PostalizzazioneMediaMensile() As DataSet
        Dim ds As New DataSet
        Try
            Using cn As New OleDbConnection(CnPostalizzazione)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT Agenzia,AVG(Comunicazioni) AS Media 
                                       FROM Postalizzazione 
                                       WHERE DataInvio >= #{0}#
                                       GROUP BY Agenzia"
                    cmd.CommandText = String.Format(cmd.CommandText, Format(Now.AddYears(-1), "MM/dd/yyyy"))
                    Using da As New OleDbDataAdapter(cmd)
                        da.Fill(ds, "Medie")
                    End Using
                End Using
            End Using

            Return ds

        Catch ex As Exception
            RegistraErrorePostalizzazione("00000", ex.Message)
            Log.BoxErrore(ex)
            Return ds
        End Try
    End Function

    <WebMethod()>
    Public Function EsistePostalizzazioneAgenzia(FileDati As String) As Boolean
        Dim ds As New DataSet
        Try
            Using cn As New OleDbConnection(CnPostalizzazione)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT COUNT(*) FROM Postalizzazione WHERE Ambiente = @ambiente AND FileDati = @file"

                    cmd.Parameters.AddWithValue("ambiente", AmbientePostalizzazione(FileDati.Split("_")(0)))
                    cmd.Parameters.AddWithValue("file", FileDati)

                    Return cmd.ExecuteScalar > 0
                End Using
            End Using

        Catch ex As Exception
            RegistraErrorePostalizzazione("00000", ex.Message)
            Log.BoxErrore(ex)
            Return False
        End Try
    End Function

    <WebMethod()>
    Public Function ConsensoProssimaPostalizzazione(Agenzia As String) As Boolean
        Dim ds As New DataSet
        Try
            Using cn As New OleDbConnection(CnPostalizzazione)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT COUNT(*) FROM Abilitazioni WHERE Agenzia = ?"
                    cmd.Parameters.AddWithValue("agenzia", Agenzia)

                    If cmd.ExecuteScalar > 0 Then
                        cmd.CommandText = "SELECT InizioPostalizzazione FROM Abilitazioni WHERE Agenzia = ?"
                        Return cmd.ExecuteScalar <= Today
                    Else
                        Return False
                    End If
                End Using
            End Using

        Catch ex As Exception
            RegistraErrorePostalizzazione("00000", ex.Message)
            Log.BoxErrore(ex)
            Return False
        End Try
    End Function

    <WebMethod()>
    Public Function EliminaLottoPostalizzazione(IdCampagna As Integer) As Boolean
        Dim ds As New DataSet
        Try
            Using cn As New OleDbConnection(CnPostalizzazione)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    'eseguo backup
                    cmd.CommandText = String.Format("SELECT * INTO Bak_{0:ddMMyyyy}_{0:HHmmss} FROM Postalizzazione", Now)
                    cmd.ExecuteNonQuery()
                    'elimino record
                    cmd.CommandText = "DELETE FROM Postalizzazione WHERE IdCampagna = ?"
                    cmd.Parameters.AddWithValue("id", IdCampagna)

                    Return cmd.ExecuteNonQuery > 0
                End Using
            End Using

        Catch ex As Exception
            RegistraErrorePostalizzazione("00000", ex.Message)
            Log.BoxErrore(ex)
            Return False
        End Try
    End Function

    <WebMethod()>
    Public Function AmbientePostalizzazione(Agenzia As String) As String
        Try
            If "01949/02379/36459/02364/02710".Contains(Agenzia) Then
                Return "avvtest"
            Else
                Return "avvcom"
            End If
        Catch ex As Exception
            RegistraErrorePostalizzazione("00000", ex.Message)
            Log.BoxErrore(ex)
            Return "avverror"
        End Try
    End Function
#End Region

#Region "raccolta dati"
    Private Sub RegistraAccesso(ByVal Agenzia As String)

        Try
            Using c As New OleDbConnection(CnRaccoltaDati)

                c.Open()

                Using cmd As New OleDbCommand

                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT Count(*) FROM Accessi WHERE Agenzia = ? AND DataAccesso = ?"

                    cmd.Parameters.AddWithValue("Agenzia", Agenzia)
                    cmd.Parameters.AddWithValue("Data", Today)

                    'se l'agenzia c'è già per quel giorno
                    If cmd.ExecuteScalar > 0 Then
                        cmd.CommandText = "UPDATE Accessi " +
                                          "SET NumeroAccessi = NumeroAccessi + 1 " +
                                          "WHERE Agenzia = ? AND DataAccesso = ?"
                        cmd.ExecuteNonQuery()
                    Else
                        cmd.CommandText = "INSERT INTO Accessi (Agenzia,DataAccesso,NumeroAccessi) " +
                                          "VALUES (?,?,1)"
                        cmd.ExecuteNonQuery()
                    End If
                End Using
            End Using

        Catch ex As Exception
            Log.BoxErrore(ex)
        End Try
    End Sub

    <WebMethod()>
    Public Function InviaProdotti(ByVal Compagnia As Integer,
                                  ByVal Agenzia As String,
                                  ByVal dsStatistiche As DataSet) As String

        Try
            Using cn As New OleDbConnection(CnRaccoltaDati)

                cn.Open()

                Using cmd As New OleDbCommand

                    cmd.CommandType = CommandType.Text
                    cmd.Connection = cn

                    For Each r As DataRow In dsStatistiche.Tables("Prodotti").Rows

                        cmd.CommandText = "SELECT Count(*) " +
                                          "FROM ProdottiVenduti " +
                                          "WHERE Prodotto = ? And Ramo = ? And RamoGestione = ?"

                        cmd.Parameters.Clear()
                        cmd.Parameters.AddWithValue("Prodotto", r("Prodotto"))
                        cmd.Parameters.AddWithValue("Ramo", r("Ramo"))
                        cmd.Parameters.AddWithValue("RamoGestione", r("RamoGestione"))

                        If cmd.ExecuteScalar = 0 Then

                            cmd.CommandText = "INSERT INTO ProdottiVenduti(Prodotto,Ramo,RamoGestione,DataInvio) " +
                                              "VALUES(?,?,?,?)"

                            cmd.Parameters.AddWithValue("Data", Now.ToShortDateString)
                            cmd.ExecuteNonQuery()
                        End If
                    Next

                    'registro l'invio
                    cmd.CommandText = "INSERT INTO AgenzieMittenti(Compagnia,Agenzia,DataTrasmissione) " +
                                      "VALUES(?,?,?)"

                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("Compagnia", Compagnia)
                    cmd.Parameters.AddWithValue("Agenzia", Agenzia)
                    cmd.Parameters.AddWithValue("Data", Now.ToString)

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Return "+OK"

        Catch ex As Exception
            Log.BoxErrore(ex)
            Return "-ERR|" + ex.Message
        End Try

    End Function

    <WebMethod()>
    Public Function InviaDatiSinistri(ByVal Agenzia As String,
                                      ByVal dsStatistiche As DataSet) As String

        Try
            Using cn As New OleDbConnection(CnRaccoltaDati)

                cn.Open()

                Using cmd As New OleDbCommand

                    cmd.CommandType = CommandType.Text
                    cmd.Connection = cn

                    'riaperture
                    cmd.CommandText = "INSERT INTO Riaperture(Agenzia,RamoSinistro,RamoPolizza,TipoCid," +
                                                             "AgenziaSinistro,EsercizioSinistro,NumeroSinistro," +
                                                             "DataFlusso,DataTrasmissione) " +
                                      "VALUES(?,?,?,?,?,?,?,?,?)"

                    For Each r As DataRow In dsStatistiche.Tables("Riaperture").Rows

                        cmd.Parameters.Clear()
                        cmd.Parameters.AddWithValue("Agenzia", r("Agenzia"))
                        cmd.Parameters.AddWithValue("Rs", r("RamoSinistro"))
                        cmd.Parameters.AddWithValue("Rp", r("RamoPolizza"))
                        cmd.Parameters.AddWithValue("Tc", r("TipoCid"))
                        cmd.Parameters.AddWithValue("As", r("AgenziaSinistro"))
                        cmd.Parameters.AddWithValue("Es", r("EsercizioSinistro"))
                        cmd.Parameters.AddWithValue("Ns", r("NumeroSinistro"))
                        cmd.Parameters.AddWithValue("Df", r("DataFlusso"))
                        cmd.Parameters.AddWithValue("Dt", Format(Now, "dd/MM/yyy HH:mm:ss"))

                        cmd.ExecuteNonQuery()
                    Next

                    'aperture per mese
                    cmd.CommandText = "INSERT INTO ApertureSinistri(Agenzia,RamoSinistro,Mese,Aperture) " +
                                      "VALUES(?,?,?,?)"

                    For Each r As DataRow In dsStatistiche.Tables("ApertureSinistri").Rows

                        cmd.Parameters.Clear()
                        cmd.Parameters.AddWithValue("Agenzia", r("Agenzia"))
                        cmd.Parameters.AddWithValue("Ramo", r("RamoSinistro"))
                        cmd.Parameters.AddWithValue("Mese", r("Mese"))
                        cmd.Parameters.AddWithValue("Aperture", r("Aperture"))

                        cmd.ExecuteNonQuery()
                    Next
                End Using
            End Using

            Return String.Format("+OK|{0}|{1}",
                                 dsStatistiche.Tables("Riaperture").Rows.Count,
                                 dsStatistiche.Tables("ApertureSinistri").Rows.Count)

        Catch ex As Exception
            Log.BoxErrore(ex)
            Return "-ERR|" + ex.Message
        End Try

    End Function

    <WebMethod()>
    Public Function InvioProdottiEffettuato(ByVal Compagnia As Integer,
                                            ByVal Agenzia As Integer) As Boolean

        Try
            Using cn As New OleDbConnection(CnRaccoltaDati)

                cn.Open()

                Using cmd As New OleDbCommand

                    cmd.CommandType = CommandType.Text
                    cmd.Connection = cn
                    cmd.CommandText = "SELECT Count(*) " +
                                      "FROM AgenzieMittenti " +
                                      "WHERE Compagnia = ? And Agenzia = ?"

                    cmd.Parameters.AddWithValue("Compagnia", Compagnia)
                    cmd.Parameters.AddWithValue("Agenzia", Agenzia)

                    Return cmd.ExecuteScalar > 0
                End Using
            End Using


        Catch ex As Exception
            InvioProdottiEffettuato = True
            Log.BoxErrore(ex)
        End Try

    End Function

    <WebMethod()>
    Public Function InvioDatiSinistri(ByVal Agenzia As Integer) As Boolean

        Try
            Using cn As New OleDbConnection(CnRaccoltaDati)

                cn.Open()

                Using cmd As New OleDbCommand

                    cmd.CommandType = CommandType.Text
                    cmd.Connection = cn
                    cmd.CommandText = "SELECT Count(*) FROM Riaperture WHERE Agenzia = ?"

                    cmd.Parameters.AddWithValue("Agenzia", Agenzia)

                    Return (cmd.ExecuteScalar > 0)
                End Using
            End Using


        Catch ex As Exception
            InvioDatiSinistri = True
            Log.BoxErrore(ex)
        End Try

    End Function

    <WebMethod()>
    Public Function RegistraLogUso(ByVal DatiLog As DataSet) As String
        Try
            Log.AddLog("Registrazione log uso...")
            Dim Agenzia As String = ""

            Using cn As New OleDbConnection(MdbDriver + StatisticheUso)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "INSERT INTO UsoFunzioni(Compagnia,Agenzia,Utente,Funzione,Data,Modalita,IdSessione) " +
                                      "VALUES(?,?,?,?,?,?,?)"

                    For Each r As DataRow In DatiLog.Tables("Uso").Rows
                        If r("Funzione") <> "Postalizzazione: controlli" Then
                            Agenzia = r("Agenzia")

                            cmd.Parameters.Clear()
                            cmd.Parameters.AddWithValue("Compagnia", r("Compagnia"))
                            cmd.Parameters.AddWithValue("Agenzia", r("Agenzia"))
                            cmd.Parameters.AddWithValue("Utente", Left(r("Utente"), 20))
                            cmd.Parameters.AddWithValue("Funzione", Left(r("Funzione"), 50))
                            cmd.Parameters.AddWithValue("Data", r("Data"))
                            cmd.Parameters.AddWithValue("Modalita", r("Modalita").ToString)
                            cmd.Parameters.AddWithValue("IdSessione", Left(r("IdSessione"), 15))

                            Dim Tentativo As Integer = 1
AggiornaDb:
                            Try
                                cmd.ExecuteNonQuery()
                            Catch ex As Exception
                                Tentativo += 1
                                If Tentativo > 5 Then
                                    Log.BoxErrore(ex)
                                Else
                                    Threading.Thread.Sleep(200)
                                    GoTo AggiornaDb
                                End If
                            End Try
                        End If
                    Next
                End Using
            End Using
            Log.AddLog(String.Format("{0}: Registrazione log uso conclusa correttamente", Agenzia))

            Return String.Format("+OK")

        Catch ex As Exception
            Log.BoxErrore(ex)
            Return "-ERR|" + ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function RegistraLogUsoEx(Compagnia As Integer,
                                     Agenzia As Integer,
                                     Sede As Integer,
                                     Sessione As String,
                                     Versione As String,
                                     Modalita As String,
                                     DatiLog As DataSet) As String 'dal 18/06/2021
        Try
            Log.AddLog(String.Format("Registrazione log uso {0}", Agenzia))

            Using cn As New OleDbConnection(MdbDriver + StatisticheUso)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = String.Format("INSERT INTO UsoFunzioni(Compagnia,Agenzia,Sede,Utente,Funzione,Data,Modalita,IdSessione,Versione) " +
                                                    "VALUES({0},{1},{2},?,?,?,'{3}','{4}','{5}')",
                                                    Compagnia, Agenzia, Sede, Modalita, Sessione, Versione)

                    For Each r As DataRow In DatiLog.Tables("Uso").Rows
                        cmd.Parameters.Clear()
                        cmd.Parameters.AddWithValue("Utente", Left(r("Utente"), 20))
                        cmd.Parameters.AddWithValue("Funzione", Left(r("Funzione"), 50))
                        cmd.Parameters.AddWithValue("Data", r("Data"))

                        Dim Tentativo As Integer = 1
AggiornaDb:
                        Try
                            cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            Tentativo += 1
                            If Tentativo > 5 Then
                                Log.BoxErrore(ex)
                            Else
                                Threading.Thread.Sleep(200)
                                GoTo AggiornaDb
                            End If
                        End Try
                    Next
                End Using
            End Using
            Return String.Format("+OK")

        Catch ex As Exception
            Log.BoxErrore(ex)
            Return "-ERR|Registrazione log uso: " + ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function EsistonoDatiAnag(Agenzia As String) As Boolean
        Try
            Using cn As New OleDbConnection(CnRaccoltaDati)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT COUNT(*) FROM AnagUT WHERE Agenzia = ?"
                    cmd.Parameters.AddWithValue("agenzia", Agenzia)
                    Return (cmd.ExecuteScalar > 0).ToString
                End Using
            End Using
        Catch ex As Exception
            Log.BoxErrore(ex)
            Return False
        End Try
    End Function

    <WebMethod()>
    Public Function RegistraLogAnag(ByVal DatiAnag As DataSet) As String
        Try
            Using cn As New OleDbConnection(CnRaccoltaDati)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "INSERT INTO AnagUT(Agenzia,Tabella,Record) VALUES(?,?,?)"

                    For Each r As DataRow In DatiAnag.Tables("Anag").Rows
                        cmd.Parameters.Clear()
                        cmd.Parameters.AddWithValue("Agenzia", r("Agenzia"))
                        cmd.Parameters.AddWithValue("Tabella", r("Tabella"))
                        cmd.Parameters.AddWithValue("Record", r("Record"))
                        cmd.ExecuteNonQuery()
                    Next
                End Using
            End Using
            Return String.Format("+OK")

        Catch ex As Exception
            Log.BoxErrore(ex)
            Return "-ERR|" + ex.Message
        End Try
    End Function
#End Region

#Region "Referenti sinistri"

    <WebMethod()>
    Public Function Referenti(ByVal Agenzia As Integer) As DataSet

        Try
            Using c As New OleDbConnection(MdbDriver + DatiComuniAgenzie)

                c.Open()

                Using cmd As New OleDbCommand

                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT * FROM Referenti WHERE Agenzia = ?"

                    cmd.Parameters.AddWithValue("Agenzia", Agenzia)

                    Dim da As New OleDbDataAdapter(cmd)
                    Dim ds As New DataSet
                    da.Fill(ds, "Referenti")

                    Return ds
                End Using
            End Using

        Catch ex As Exception
            Log.BoxErrore(ex)

            'restituisce il dataset con la tabella vuota
            Dim ds As New DataSet
            ds.Tables.Add("Referenti")
            Return ds
        End Try

    End Function

#End Region

    <WebMethod()>
    Public Function Ping() As Boolean
        Return True
    End Function

    <WebMethod()>
    Public Sub ImpostaAgenzieCollegate(ByVal AgenziaMadre As String, ByVal AgenzieCollegate As List(Of String))
        Try
            If AgenzieCollegate.Count > 1 Then

                Dim Collegate As String = ""

                For Each a As String In AgenzieCollegate
                    Collegate += String.Format("{0}/", a)
                Next
                'tolgo l'ultimo /
                Collegate = Left(Collegate, Collegate.Length - 1)

                Using c As New OleDbConnection(CnConfigDb)
                    c.Open()

                    Using cmd As New OleDbCommand

                    End Using
                End Using
            End If

        Catch ex As Exception
            Log.BoxErrore(ex)
        End Try
    End Sub

    <WebMethod()>
    Public Function BloccoImportazione() As Boolean
        Try
            Dim Valore As String = LeggiVariabile(Variabili.BloccoImportazione.ToString)

            If Valore Is Nothing Then
                Return False 'nessun blocco
            Else
                Return Valore
            End If
        Catch ex As Exception
            Log.BoxErrore(ex)
            Return False
        End Try
    End Function

    Private Function LeggiVariabile(ByVal NomeVariabile As String) As Object
        Try
            Using c As New OleDbConnection(CnConfigDb)
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT Trim(Valore) FROM Variabili WHERE Variabile = ?"
                    cmd.Parameters.AddWithValue("variabile", NomeVariabile)
                    Return cmd.ExecuteScalar
                End Using
            End Using
        Catch ex As Exception
            Log.BoxErrore(ex)
            Return Nothing
        End Try
    End Function

#Region "controllo utenti on-line"
    <WebMethod()>
    Public Function ConsensoOnLine(ByVal TipoOperazione As Integer,
                                   ByVal Agenzia As String,
                                   ByVal IdOperazione As String) As Boolean
        Try
            Log.AddLog(String.Format("Consenso on-line: richiesta operazione {0} da agenzia {1} con Id {2}", TipoOperazione, Agenzia, IdOperazione))

            Using c As New OleDbConnection(MdbDriver + Server.MapPath("\mdb-database\190139f2-4749-488a-859c-51c824f6bbdc\ConfigDownload\ControlliOnLine.mdb"))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    'pulizia per accessi vecchi eventualmente bloccati. durata max 60 minuti
                    cmd.CommandText = "DELETE FROM ControlloAccessi WHERE DateDiff('n',Inizio,Now) > 60"
                    cmd.ExecuteNonQuery()

                    Dim MaxUtenti As Integer
                    Try
                        cmd.CommandText = "SELECT TOP 1 MaxUtenti FROM Limitazioni WHERE TipoOperazione = ?"
                        cmd.Parameters.AddWithValue("tipo", TipoOperazione)
                        MaxUtenti = cmd.ExecuteScalar
                    Catch ex As Exception
                        MaxUtenti = 10
                    End Try

                    cmd.CommandText = "SELECT COUNT(*) FROM ControlloAccessi WHERE TipoOperazione = ?"
                    Dim UtentiOnLine As Integer = cmd.ExecuteScalar

                    If UtentiOnLine >= MaxUtenti Then
                        Log.AddLog(String.Format("Consenso: raggiunto il numero massimo di utenti ({0})", UtentiOnLine))
                        Return False
                    Else
                        Log.AddLog(String.Format("Consenso: numero utenti connessi {0}", UtentiOnLine))

                        cmd.CommandText = "INSERT INTO ControlloAccessi (TipoOperazione, Agenzia, IdOperazione, Inizio) VALUES(?,?,?,Now)"
                        cmd.Parameters.AddWithValue("agenzia", Agenzia)
                        cmd.Parameters.AddWithValue("id", IdOperazione)
                        cmd.ExecuteNonQuery()
                        Log.AddLog(String.Format("Consenso: agenzia {0} tipo operazione {1} id {2} connesso", Agenzia, TipoOperazione, IdOperazione))
                        Return True
                    End If
                End Using
            End Using
        Catch ex As Exception
            Log.BoxErrore(ex)
            Return False
        End Try
    End Function

    <WebMethod()>
    Public Function RimuoviConsensoOnLine(ByVal TipoOperazione As Integer,
                                          ByVal Agenzia As String,
                                          ByVal IdOperazione As String) As Boolean
        Try
            Using c As New OleDbConnection(MdbDriver + Server.MapPath("\mdb-database\190139f2-4749-488a-859c-51c824f6bbdc\ConfigDownload\ControlliOnLine.mdb"))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "DELETE FROM ControlloAccessi WHERE TipoOperazione = ? AND Agenzia = ? AND IdOperazione = ?"
                    cmd.Parameters.AddWithValue("operazione", TipoOperazione)
                    cmd.Parameters.AddWithValue("agenzia", Agenzia)
                    cmd.Parameters.AddWithValue("guid", IdOperazione)
                    cmd.ExecuteNonQuery()
                    Log.AddLog(String.Format("Consenso: agenzia {0} tipo operazione {1} id {2} disconnesso", Agenzia, TipoOperazione, IdOperazione))
                End Using
            End Using
            Return True
        Catch ex As Exception
            Log.BoxErrore(ex)
            Return False
        End Try
    End Function

    <WebMethod()>
    Public Function UpdateMaxUtenti(ByVal TipoOperazione As Integer,
                                    ByVal MaxUtenti As Integer) As Boolean
        Try
            Using c As New OleDbConnection(MdbDriver + Server.MapPath("\mdb-database\190139f2-4749-488a-859c-51c824f6bbdc\ConfigDownload\ControlliOnLine.mdb"))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "UPDATE Limitazioni SET MaxUtenti = ? WHERE TipoOperazione = ?"
                    cmd.Parameters.AddWithValue("utenti", MaxUtenti)
                    cmd.Parameters.AddWithValue("operazione", TipoOperazione)
                    If cmd.ExecuteNonQuery() = 0 Then
                        'il tipo operazione non è stato trovato
                        cmd.CommandText = "INSERT INTO Limitazioni (MaxUtenti,TipoOperazione) VALUES(?,?)"
                        cmd.ExecuteNonQuery()
                    End If
                    Log.AddLog(String.Format("Consenso: numero massimo di utenti aggiornato a {0}", MaxUtenti))
                End Using
            End Using
            Return True
        Catch ex As Exception
            Log.BoxErrore(ex)
            Return False
        End Try
    End Function

    <WebMethod()>
    Public Function UtentiOnLine(ByVal TipoOperazione As Integer) As Integer
        Try
            Using c As New OleDbConnection(MdbDriver + Server.MapPath("\mdb-database\190139f2-4749-488a-859c-51c824f6bbdc\ConfigDownload\ControlliOnLine.mdb"))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT COUNT(*) FROM ControlloAccessi WHERE TipoOperazione = ?"
                    cmd.Parameters.AddWithValue("operazione", TipoOperazione)
                    Return cmd.ExecuteScalar()
                End Using
            End Using
        Catch ex As Exception
            Log.BoxErrore(ex)
            Return -1
        End Try
    End Function
#End Region

    '<WebMethod()> _
    'Public Function UniRelease() As DataSet
    '    Try
    '        Dim ds As New DataSet
    '        Dim dt As New DataTable
    '        dt.TableName = "Release"
    '        With dt.Columns
    '            .Add("Modulo", Type.GetType("System.String"))
    '            .Add("Tipo", Type.GetType("System.String"))
    '            .Add("Versione", Type.GetType("System.String"))
    '            .Add("MD5", Type.GetType("System.String"))
    '        End With

    '        ds.Tables.Add(dt)

    '        Dim Pattern As New List(Of String)
    '        With Pattern
    '            .Clear()
    '            .Add("*.exe")
    '            .Add("*.dll")
    '            .Add("*.xml")
    '        End With

    '        Dim CartellaVersione As String = Server.MapPath("\Unitools\Update\Versioni\600")
    '        'per ciascun pattern
    '        For Each p As String In Pattern
    '            'per ciascuna cartella
    '            For Each d As String In Directory.GetDirectories(CartellaVersione)
    '                'per ciascun file
    '                For Each f As String In Directory.GetFiles(CartellaVersione, p)

    '                    If (f.Contains(".vshost.") = False) AndAlso (f.Contains(".XmlSerializers.") = False) Then

    '                        dt.Rows.Add(Path.GetFileName(f),
    '                                    Path.GetExtension(f).Replace(".", "").ToUpper,
    '                                    FileVersionInfo.GetVersionInfo(f).ProductVersion.Replace(",", ".").Replace(" ", ""),
    '                                    SettingGlobale.FileToMD5(f))
    '                    End If
    '                Next
    '            Next
    '        Next

    '        Return ds

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return New DataSet
    '    End Try
    'End Function

    <WebMethod()>
    Public Function SalvaStatisticheDb(Agenzia As String, DatiDb As DataSet) As String
        Try
            'inserisco i nuovi dati
            Dim dt As DataTable = DatiDb.Tables(0)

            If dt.Rows.Count > 0 Then
                Using cn As New OleDbConnection(CnStatisticheDb)
                    cn.Open()

                    Using cmd As New OleDbCommand
                        cmd.Connection = cn
                        cmd.CommandType = CommandType.Text
                        'cancello la rilevazione precedente
                        cmd.CommandText = "DELETE FROM StatisticheDb WHERE Agenzia = @agenzia"
                        cmd.Parameters.AddWithValue("agenzia", Agenzia)
                        cmd.ExecuteNonQuery()
                        'aggiorno i dati
                        cmd.CommandText = "INSERT INTO StatisticheDb (Agenzia,Db,Tabella,Tipo,Record,Aggiornato) VALUES(?,?,?,?,?,?)"
                        With cmd.Parameters
                            .Clear()
                            .AddWithValue("agenzia", dt).SourceColumn = "Agenzia"
                            .AddWithValue("db", dt).SourceColumn = "Db"
                            .AddWithValue("tabella", dt).SourceColumn = "Tabella"
                            .AddWithValue("tipo", dt).SourceColumn = "Tipo"
                            .AddWithValue("record", dt).SourceColumn = "Record"
                            .AddWithValue("aggiornato", dt).SourceColumn = "Aggiornato"
                        End With

                        Using da As New OleDbDataAdapter(cmd)
                            da.InsertCommand = cmd
                            da.Update(dt)
                        End Using
                    End Using
                End Using
            End If

            Return "+OK"

        Catch ex As Exception
            Log.BoxErrore(ex)
            Return "-ERR|" & ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function RegistraLogDocumenti(Agenzia As String, Sede As String, Dimensione As Long) As String
        Try
            Using cn As New OleDbConnection(CnRaccoltaDati)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    'cancello la rilevazione precedente
                    cmd.CommandText = "DELETE FROM CartellaDocumenti WHERE Agenzia = @agenzia AND Sede = @sede"
                    cmd.Parameters.AddWithValue("agenzia", Agenzia)
                    cmd.Parameters.AddWithValue("sede", Sede)
                    cmd.ExecuteNonQuery()
                    'aggiorno i dati
                    cmd.CommandText = "INSERT INTO CartellaDocumenti (Agenzia,Sede,Dimensione) VALUES(?,?,?)"
                    cmd.Parameters.AddWithValue("dimensione", Dimensione)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return "+OK"

        Catch ex As Exception
            Log.BoxErrore(ex)
            Return "-ERR|" & ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function VersioneLiveUpdate() As String
        Try
            Using cn As New OleDbConnection(CnControlloVersioneDb)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT Versione FROM ControlloVersione20 WHERE Livello = 'PROD' AND Modulo = 'LiveUpdate.exe'"

                    Return cmd.ExecuteScalar
                End Using
            End Using

        Catch ex As Exception
            RegistraErrorePostalizzazione("00000", ex.Message)
            Log.BoxErrore(ex)
            Return "-ERR"
        End Try
    End Function

    <WebMethod()>
    Public Function MD5Database() As String
        Try
            Return SettingGlobale.FileToMD5(ControlloVersioneDb).ToUpper
        Catch ex As Exception
            RegistraErrorePostalizzazione("00000", ex.Message)
            Return "ERRORE"
        End Try
    End Function

    <WebMethod()>
    Public Function InviaMA2OmniaManager(Agenzia As String) As Object
        Try
            Using cn As New OleDbConnection(CnConfigDb)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT Inizio FROM InvioMA WHERE Agenzia = @agenzia"
                    cmd.Parameters.AddWithValue("agenzia", Agenzia)

                    Dim dr As OleDbDataReader = cmd.ExecuteReader

                    If dr.HasRows Then
                        dr.Read()
                        Return dr("Inizio")
                    Else
                        Return CDate("31/12/2100")
                    End If
                End Using
            End Using

        Catch ex As Exception
            Log.BoxErrore(ex)
            Return "-ERR|" & ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function InviaEssigReti2OmniaManager(Agenzia As String) As Object
        Try
            Using cn As New OleDbConnection(CnConfigDb)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT Inizio FROM InvioEssigReti WHERE Agenzia = @agenzia"
                    cmd.Parameters.AddWithValue("agenzia", Agenzia)

                    Dim dr As OleDbDataReader = cmd.ExecuteReader

                    If dr.HasRows Then
                        dr.Read()
                        Return dr("Inizio")
                    Else
                        Return CDate("31/12/2100")
                    End If
                End Using
            End Using

        Catch ex As Exception
            Log.BoxErrore(ex)
            Return "-ERR|" & ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function InviaMA2SIA(Agenzia As String) As Object
        'obsoleto sostituito da InviaMA2OmniaManager
        Try
            Using cn As New OleDbConnection(CnSia)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT Inizio FROM InvioMA WHERE Agenzia = @agenzia"
                    cmd.Parameters.AddWithValue("agenzia", Agenzia)

                    Dim dr As OleDbDataReader = cmd.ExecuteReader

                    If dr.HasRows Then
                        dr.Read()
                        Return dr("Inizio")
                    Else
                        Return CDate("31/12/2100")
                    End If
                End Using
            End Using

        Catch ex As Exception
            Log.BoxErrore(ex)
            Return "-ERR|" & ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function RegistraDataSwitchMA(Agenzia As String, Inizio As Date) As Boolean
        Try
            Using cn As New OleDbConnection(CnSia)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = String.Format("UPDATE InvioMA SET Inizio = #{0:MM/dd/yyyy}# WHERE Agenzia = '{1}'", Inizio, Agenzia)
                    Return (cmd.ExecuteNonQuery() = 1)
                End Using
            End Using
        Catch ex As Exception
            Log.BoxErrore(ex)
            Return False
        End Try
    End Function

    <WebMethod()>
    Public Function DataSwitchMA(Agenzia As String) As String
        Try
            Using cn As New OleDbConnection(CnConfigDb)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = String.Format("SELECT Inizio FROM InvioMA WHERE Agenzia = '{0}'", Agenzia)
                    Dim Inizio As Date = cmd.ExecuteScalar
                    Return Inizio.ToString
                End Using
            End Using
        Catch ex As Exception
            Log.BoxErrore(ex)
            Return "-ERR|" & ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function EsisteSwitchMA(Agenzia As String) As Boolean
        Return DataSwitchMA(Agenzia) > #1/1/1900#
    End Function

    <WebMethod()>
    Public Function CancellaSwitchMA(Agenzia As String) As String
        Try
            Using cn As New OleDbConnection(CnConfigDb)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = String.Format("DELETE FROM InvioMA WHERE Agenzia = '{0}'", Agenzia)
                    Return String.Format("+OK - rimosso {0} record dell'agenzia {1}", cmd.ExecuteNonQuery, Agenzia)
                End Using
            End Using
        Catch ex As Exception
            Log.BoxErrore(ex)
            Return "-ERR|" & ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function AbilitaSwitchMA(Agenzia As String, Inizio As Date, Fine As Date, Note As String) As String
        Try
            Using cn As New OleDbConnection(CnConfigDb)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    'cancello record precedenti
                    cmd.CommandText = String.Format("DELETE FROM InvioMA WHERE Agenzia = '{0}'", Agenzia)
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = String.Format("DELETE FROM InvioEssigReti WHERE Agenzia = '{0}'", Agenzia)
                    cmd.ExecuteNonQuery()
                    'MA
                    cmd.CommandText = "INSERT INTO InvioMA (Agenzia, Inizio, Fine, [Note], DataInserimento) VALUES(@agenzia,@inizio,@fine,@note,@inserimento)"
                    cmd.Parameters.AddWithValue("agenzia", Agenzia)
                    cmd.Parameters.AddWithValue("inizio", Format(Inizio, "dd/MM/yyyy"))
                    cmd.Parameters.AddWithValue("fine", Format(Fine, "dd/MM/yyyy"))
                    cmd.Parameters.AddWithValue("note", Note)
                    cmd.Parameters.AddWithValue("inserimento", Format(Now, "dd/MM/yyyy HH:mm"))
                    cmd.ExecuteNonQuery()
                    'essig reti - stessi parametri
                    cmd.CommandText = "INSERT INTO InvioEssigReti (Agenzia, Inizio, Fine, [Note], DataInserimento) VALUES(@agenzia,@inizio,@fine,@note,@inserimento)"
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return String.Format("+OK|Abilitata per MA e Essig reti dal {0:dd-MM-yyyy}", Inizio)
        Catch ex As Exception
            Log.BoxErrore(ex)
            Return "-ERR|" & ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function EseguiSwitchMA(Query As String, Token As String) As String
        Try
            If Token = Format(Today, "yyyy_MM_dd_") & "19011957" Then
                Using cn As New OleDbConnection(CnSia)
                    cn.Open()

                    Using cmd As New OleDbCommand
                        cmd.Connection = cn
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = Query
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
                Return "+OK"
            Else
                Return "-KO"
            End If
        Catch ex As Exception
            Log.BoxErrore(ex)
            Return "-ERR|" & ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function AggiornaAbilitazioniPostalizzazioneDaKoine(ByRef DatiKoine As DataSet) As String
        Try
            Using cn As New OleDbConnection(CnPostalizzazione)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "DELETE * FROM Abilitazioni"
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "INSERT INTO Abilitazioni (Agenzia,Descrizione,InizioPostalizzazione) VALUES(?,?,?)"

                    For Each dr As DataRow In DatiKoine.Tables(0).Rows
                        With cmd.Parameters
                            .Clear()
                            .AddWithValue("agenzia", dr("Agenzia"))
                            .AddWithValue("localita", dr("Localita"))
                            .AddWithValue("inizio", dr("Inizio"))
                        End With
                        cmd.ExecuteNonQuery()
                    Next
                End Using
            End Using
            Return "+OK"
        Catch ex As Exception
            Log.BoxErrore(ex)
            Return "-ERR|" & ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function GestioneAssegniAttiva(Agenzia As String) As String
        Try
            Using cn As New OleDbConnection(CnConfigDb)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT COUNT(*) FROM Assegni WHERE Agenzia = ?"
                    cmd.Parameters.AddWithValue("agenzia", Agenzia)

                    If cmd.ExecuteScalar > 0 Then
                        Return "+OK"
                    Else
                        Return "-KO"
                    End If
                End Using
            End Using
        Catch ex As Exception
            Log.BoxErrore(ex)
            Return "-ERR|" & ex.Message
        End Try
    End Function

#Region "Servizi"
    <WebMethod()>
    Public Function AggiornaUtenze(Agenzia As String, ByRef Utenze As DataSet) As String
        Try
            Using cn As New OleDbConnection(CnServizi)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = String.Format("DELETE FROM Utenze WHERE Agenzia = '{0}' OR Agenzia IS NULL", Agenzia)
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "INSERT INTO Utenze (Agenzia,Utenza,CodiceFiscale) VALUES(?,?,?)"

                    For Each dr As DataRow In Utenze.Tables(0).Rows
                        With cmd.Parameters
                            .Clear()
                            .AddWithValue("agenzia", Agenzia)
                            .AddWithValue("utenza", dr("Utenza"))
                            .AddWithValue("cf", dr("CodiceFiscale"))
                        End With
                        cmd.ExecuteNonQuery()
                    Next
                End Using
            End Using
            Return "+OK"
        Catch ex As Exception
            Log.BoxErrore(ex)
            Return "-ERR|" & ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function RappelNazionale(Anno As Integer) As String
        Try
            Using cn As New OleDbConnection(CnServizi)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = String.Format("SELECT Valore FROM Variabili WHERE Variabile = 'Rappel_{0:0000}'", Anno)
                    Return cmd.ExecuteScalar
                End Using
            End Using
        Catch ex As Exception
            Log.BoxErrore(ex)
            Return "-ERR|" & ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function SpAgenzia(Agenzia As String, Anno As Integer) As String
        Try
            Using cn As New OleDbConnection(CnServizi)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = String.Format("SELECT * FROM SP WHERE Agenzia = {0} AND Anno = {1}", Agenzia, Anno)

                    Using da As New OleDbDataAdapter(cmd)
                        Using dt As New DataTable
                            da.Fill(dt)

                            Dim Persone, Rcg, Aziende As Double

                            For Each row As DataRow In dt.Rows
                                If row("Comparto") = "Persone" Then
                                    Persone = Int(row("SP") * 1000 + 1) / 10
                                ElseIf row("Comparto") = "RCG" Then
                                    Rcg = Int(row("SP") * 1000 + 1) / 10
                                ElseIf row("Comparto") = "Aziende_no_RCG" Then
                                    Aziende = Int(row("SP") * 1000 + 1) / 10
                                End If
                            Next

                            Return String.Format("{0};{1};{2}", Persone, Aziende, Rcg)
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Log.BoxErrore(ex)
            Return "-ERR|" & ex.Message
        End Try
    End Function

    <WebMethod()>
    Public Function MittenteSms(Agenzia As Integer) As String
        Try
            Using cn As New OleDbConnection(CnServizi)
                cn.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = cn
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = String.Format("SELECT Mittente FROM Mittenti_SMS WHERE Agenzia = {0}", Agenzia)
                    Return cmd.ExecuteScalar()
                End Using
            End Using
        Catch ex As Exception
            Log.BoxErrore(ex)
            Return "-ERR|" & ex.Message
        End Try
    End Function
#End Region
End Class

' Define a SOAP Extension that traces the SOAP request and SOAP response
' for the XML Web service method the SOAP extension is applied to.
Public Class TraceExtension
    Inherits SoapExtension

    Dim Servizio As New ConfiguraSede

    Private oldStream As Stream
    Private newStream As Stream
    Private m_filename As String

    ' Save the Stream representing the SOAP request or SOAP response into
    ' a local memory buffer.
    Public Overrides Function ChainStream(ByVal stream As Stream) As Stream
        oldStream = stream
        newStream = New MemoryStream()
        Return newStream
    End Function

    ' When the SOAP extension is accessed for the first time, the XML Web
    ' service method it is applied to is accessed to store the file
    ' name passed in, using the corresponding SoapExtensionAttribute.    
    Public Overloads Overrides Function GetInitializer(ByVal methodInfo As LogicalMethodInfo,
                                                       ByVal attribute As SoapExtensionAttribute) As Object
        Return CType(attribute, TraceExtensionAttribute).Filename
    End Function

    ' The SOAP extension was configured to run using a configuration file
    ' instead of an attribute applied to a specific XML Web service
    ' method.  Return a file name based on the class implementing the Web
    ' Service's type.
    Public Overloads Overrides Function GetInitializer(ByVal WebServiceType As Type) As Object
        ' Return a file name to log the trace information to, based on the
        ' type.
        Return Path.Combine(Servizio.CartellaLog, WebServiceType.FullName + ".log")
    End Function

    ' Receive the file name stored by GetInitializer and store it in a
    ' member variable for this specific instance.
    Public Overrides Sub Initialize(ByVal initializer As Object)
        m_filename = CStr(initializer)
    End Sub

    ' If the SoapMessageStage is such that the SoapRequest or SoapResponse
    ' is still in the SOAP format to be sent or received over the network,
    ' save it out to file.
    Public Overrides Sub ProcessMessage(ByVal message As SoapMessage)
        Select Case message.Stage
            Case SoapMessageStage.BeforeSerialize
            Case SoapMessageStage.AfterSerialize
                WriteOutput(message)
            Case SoapMessageStage.BeforeDeserialize
                WriteInput(message)
            Case SoapMessageStage.AfterDeserialize
        End Select
    End Sub

    ' Write the SOAP message out to a file.
    Public Sub WriteOutput(ByVal message As SoapMessage)
        newStream.Position = 0
        Dim fs As New FileStream(m_filename, FileMode.Append, FileAccess.Write)
        Dim w As New StreamWriter(fs)
        w.WriteLine("-----Response at " + DateTime.Now.ToString())
        w.Flush()
        Copy(newStream, fs)
        w.Close()
        newStream.Position = 0
        Copy(newStream, oldStream)
    End Sub

    ' Write the SOAP message out to a file.
    Public Sub WriteInput(ByVal message As SoapMessage)
        Copy(oldStream, newStream)
        Dim fs As New FileStream(m_filename, FileMode.Append, FileAccess.Write)
        Dim w As New StreamWriter(fs)

        w.WriteLine("----- Request at " + DateTime.Now.ToString())
        w.Flush()
        newStream.Position = 0
        Copy(newStream, fs)
        w.Close()
        newStream.Position = 0
    End Sub

    Sub Copy(ByVal fromStream As Stream, ByVal toStream As Stream)
        Dim reader As New StreamReader(fromStream)
        Dim writer As New StreamWriter(toStream)
        writer.WriteLine(reader.ReadToEnd())
        writer.Flush()
    End Sub
End Class

' Create a SoapExtensionAttribute for our SOAP Extension that can be
' applied to an XML Web service method.
<AttributeUsage(AttributeTargets.Method)>
Public Class TraceExtensionAttribute
    Inherits SoapExtensionAttribute

    Dim Servizio As New ConfiguraSede

    Private m_filename As String = Path.Combine(Servizio.CartellaLog, "SOAP.xml")
    Private m_priority As Integer

    Public Overrides ReadOnly Property ExtensionType() As Type
        Get
            Return GetType(TraceExtension)
        End Get
    End Property

    Public Overrides Property Priority() As Integer
        Get
            Return m_priority
        End Get
        Set(ByVal Value As Integer)
            m_priority = Value
        End Set
    End Property

    Public Property Filename() As String
        Get
            Return m_filename
        End Get
        Set(ByVal Value As String)
            m_filename = Value
        End Set
    End Property
End Class