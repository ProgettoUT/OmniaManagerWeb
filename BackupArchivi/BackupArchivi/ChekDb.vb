Imports System.IO
Imports System.Data.OleDb

Module ChekDb

    Private clog As New OleDbConnection

    Public Function CheckDb(ByVal AgenziaRichiesta As String) As Boolean
        Try
            Globale.Log.Info("Avvio check database dell'agenzia " + AgenziaRichiesta)
            Globale.Log.Rientro += 4

            Dim DbAgenzia As List(Of Database)

            If AgenziaRichiesta = "00000" Then
                DbAgenzia = Globale.DbComuni
            Else
                DbAgenzia = Globale.DbAgenzia
            End If

            'struttura oggetto: Database,check
            For Each db As Database In DbAgenzia

                Dim DbPath As String = NomeDb2Path(db.Nome, AgenziaRichiesta)

                Globale.Log.Info(String.Format("File db {0}", DbPath))

                '+se il db esiste
                If File.Exists(DbPath) Then
                    Try
                        Using c As New OleDbConnection(Utx.Globale.MDBDriver + DbPath)
                            c.Open()

                            Globale.Log.Info(String.Format("Database {0}: ok", db.Nome))

                            '+controllo esistenza delle tabelle nel db
                            CheckTabelle(AgenziaRichiesta, db.Nome, c)
                        End Using

                    Catch ex As Exception
                        'da ripristinare perchè non si apre
                        Globale.Log.Info(String.Format("*** Database {0}: corrotto", db.Nome))
                        db.Check = False
                    End Try

                    Application.DoEvents()
                Else
                    'da ripristinare perchè non esiste
                    Globale.Log.Info(String.Format("*** Database {0}: inesistente", db.Nome))
                    db.Check = False
                End If

                Globale.Log.Info("")
            Next

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Globale.Log.Rientro = 0
        End Try

        'controllo dei risultati delle analisi
        'se uno dei due è false restituisce false (qualcosa non va)
        Return (DatabaseCheckOk(AgenziaRichiesta) And TabelleCheckOk())
    End Function

    Public Function NewCheckDb(ByVal Db As String) As Boolean
        Try
            '+se il db esiste
            If File.Exists(Db) Then
                Try
                    Using c As New OleDbConnection(Utx.Globale.MDBDriver + Db)
                        c.Open()
                    End Using
                    NewCheckDb = True
                Catch ex As Exception
                    'da ripristinare perchè non si apre
                    NewCheckDb = False
                End Try

                Application.DoEvents()
            Else
                'da ripristinare perchè non esiste
                Globale.Log.Info("*** Database {0}: inesistente", {Db})
                NewCheckDb = False
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Globale.Log.Rientro = 0
        End Try
    End Function

    Public Sub CheckTabelle(ByVal AgenziaRichiesta As String,
                            ByVal NomeDb As String,
                            ByRef c As OleDbConnection)
        Try
            Globale.Log.Rientro += 4
            Globale.Log.Info("Check tabelle:")
            Globale.Log.Rientro += 4

            Using cmdCount As New OleDbCommand
                cmdCount.Connection = c
                cmdCount.CommandType = CommandType.Text

                For Each Tbl As Tabella In Globale.StrutturaTabelle

                    If Tbl.Database = NomeDb Then
                        cmdCount.CommandText = "SELECT Count(*) FROM " + Tbl.Nome

                        Try
                            Tbl.Records = cmdCount.ExecuteScalar
                            Globale.Log.Info(String.Format("{0}: ok (record {1})", Tbl.Nome, Tbl.Records))
                        Catch ex As Exception
                            Globale.Log.Info(String.Format("***** {0}: corrotta o inesistente", Tbl.Nome))
                            Tbl.Check = False
                        End Try
                    End If
                Next

                Application.DoEvents()
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Globale.Log.Rientro -= 8
        End Try
    End Sub

    Private Function NumeroRecordUltimoBackup(ByVal Agenzia As String,
                                              ByVal Db As String,
                                              ByVal Tabella As String,
                                              ByRef DataBackup As Date) As Integer
        Try
            'connessione al db log
            Using cmdCount As New OleDbCommand
                cmdCount.Connection = clog
                cmdCount.CommandType = CommandType.Text
                cmdCount.CommandText = "SELECT TOP 1 Record,Aggiornamento " +
                                       "FROM Log " +
                                       "WHERE Agenzia = ? AND NomeDb = ? AND Tabella = ? " +
                                       "ORDER BY Aggiornamento DESC"

                cmdCount.Parameters.AddWithValue("Agenzia", Agenzia)
                cmdCount.Parameters.AddWithValue("Db", Db)
                cmdCount.Parameters.AddWithValue("Tabella", Tabella)

                Try
                    Dim dr As OleDbDataReader = cmdCount.ExecuteReader

                    If dr.HasRows Then
                        dr.Read()
                        DataBackup = dr("Aggiornamento")
                        Return dr("Record")
                    Else
                        Return 0
                    End If

                Catch ex As Exception
                    'non fare niente
                    DataBackup = #1/1/2000#
                    Return 0
                End Try
            End Using

        Catch ex As Exception
            'non fare niente
            DataBackup = #1/1/2000#
            Return 0
        End Try
    End Function

    Private Function AnomaliaTabella(ByVal Tabella As String,
                                     ByVal NumeroRecordOld As Integer,
                                     ByVal NumeroRecordNew As Integer) As Boolean

        Dim Coefficiente As Single

        Select Case Tabella
            'Case "Sinistri", "SinistriMemo", "Avvisi", "Unicoop", "MovPolizze", "MonitorQT", "Note"
            Case "Sinistri", "SinistriMemo", "Unicoop", "MonitorQT", "Note"
                Coefficiente = 0.9998
            Case "Clienti", "Polizze", "Unicoop", "ChiusuraCassa"
                Coefficiente = 0.95
            Case "Unidocs_Documento", "Unidocs_Evidenza", "Unidocs_Promemoria", "Rubrica"
                Coefficiente = 0.9
            Case "Avvisi"
                Coefficiente = 0.5
            Case Else
                'il resto non viene controllato
                Return False
        End Select

        Return (NumeroRecordNew < (NumeroRecordOld * Coefficiente))
    End Function

    Private Function DatabaseCheckOk(ByVal AgenziaRichiesta As String) As Boolean
        'se una tabella ha check su false restituisce false
        DatabaseCheckOk = True

        If AgenziaRichiesta = "00000" Then
            For Each db As Database In Globale.DbComuni
                DatabaseCheckOk = DatabaseCheckOk And db.Check
            Next
        Else
            For Each db As Database In Globale.DbAgenzia
                DatabaseCheckOk = DatabaseCheckOk And db.Check
            Next
        End If
    End Function

    Private Function TabelleCheckOk() As Boolean
        'se una tabella ha check su false restituisce false
        TabelleCheckOk = True

        For Each Tbl As Tabella In Globale.StrutturaTabelle
            TabelleCheckOk = TabelleCheckOk And Tbl.Check
        Next
    End Function

    Friend Sub CheckInserimentoBackup()
        'controllo tutte le tabelle
        For Each tbl As Tabella In Globale.StrutturaTabelle
            'e se la tabella ha problemi
            If tbl.Check = False Then
                'escludo il corrispondente db dal backup
                For Each db As Database In Globale.DbAgenzia
                    If db.Nome = tbl.Database Then
                        db.Check = False
                        Exit For
                    End If
                Next
            End If
        Next
    End Sub
End Module

