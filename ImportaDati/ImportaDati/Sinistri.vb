Imports System.Data.OleDb
Imports System.IO

Module Sinistri

    Private FileCorrente As FileSinistri

    Friend Sub ImportaFileSinistri(ByVal FileDati As String, ByVal DataFile As Date)

        IconaNotifica.Text = Glo.TitoloNotifiche + "importa sinistri..."

        Try
            FileCorrente = New FileSinistri(FileDati)

            If ImportaSinistri(FileDati) = False Then Throw New System.Exception
            If ImportaIncarichi(FileDati) = False Then Throw New System.Exception
            If ImportaPagamenti(FileDati) = False Then Throw New System.Exception
            If ImportaProfessionisti(FileDati) = False Then Throw New System.Exception

            AggiornaCalendarioUt(Glo.Impo.CodAgenzia,
                                 TipoFileMagia.Sinistri,
                                 FileCorrente.InizioPeriodo,
                                 FileCorrente.FinePeriodo,
                                 FileDati,
                                 FileCorrente.DataConsolidamento)

        Catch ex As Exception
            BoxErrore(ex)
            SvuotaTabella(TipoFileMagia.Sinistri)
        End Try

    End Sub

#Region "sinistri"
    Private Function ImportaSinistri(ByVal FileDati As String) As Boolean

        AddLog(String.Format(">>> Importa sinistri: record dichiarati {0}", FileCorrente.NumeroRecord))
        Glo.ContatoreFileSinistri += 1

        CreaStoredDoppioni()

        Using da As New OleDbDataAdapter("SELECT * FROM Sinistri WHERE False", cnArrivi)

            Using cmdBuilder As New OleDbCommandBuilder(da)

                Try
                    'creo la stored per l'inserimento
                    Using cmd As New OleDbCommand
                        cmd.Connection = cnArrivi
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "Create Procedure InsSinistro AS " + cmdBuilder.GetInsertCommand.CommandText
                        cmd.ExecuteNonQuery()
                    End Using

                Catch ex As Exception
                    'la stored c'è già
                End Try

                Try
                    'creo un datatable vuoto con la struttura della tabella
                    Dim dt As New DataTable
                    da.Fill(dt)

                    'dichiaro la tipologia di record nel file da analizzare
                    Dim Record As New RecordSinistri(FileCorrente.DataFile)

                    'leggo il file da importare riga per riga
                    Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)

                        'scarto la testata che non mi serve
                        sr.ReadLine()

                        'importa sinistri
                        Do While Not sr.EndOfStream

                            Record.Testo = sr.ReadLine

                            'controlla se siamo arrivati alla fine della sezione sinistri
                            If Record.FineSezione = True Then Exit Do

                            'importa la riga aggiungendola al dt. controllo sub/prod incorporato nel metodo
                            If Record.EstraiDatiSinistro(dt) = False Then
                                Throw New System.Exception
                            End If

                            Application.DoEvents()
                        Loop
                    End Using

                    'imposto il cmd per l'esecuzione della stored di inserimento
                    da.InsertCommand = FunzioniSinistri.AssegnaParametriCommand("InsSinistro", dt)

                    'aggiorno il database
                    da.Update(dt)

                    'elimino i doppioni
                    EliminaDoppioniSinistro()

                    AddLog(String.Format(">>> Importa sinistri: ok (record importati {0})", dt.Rows.Count))

                    'nel caso di doppioni con la stessa data di aggiornamento
                    If EsistonoSinistriDuplicati() Then
                        AddLog(">>> Eliminati sinistri duplicati")
                    End If

                    Return True

                Catch ex As Exception
                    BoxErrore(ex)
                    AddLog(">>> Importa sinistri: Errore")
                    Return False
                End Try
            End Using
        End Using

    End Function

    Private Sub CreaStoredDoppioni()

        'creo la stored per ELIMINARE i doppioni in caso di più record con date
        'di aggiornamento diverse
        Using cmd As New OleDbCommand

            cmd.Connection = cnArrivi

            Try
                With cmd
                    .CommandType = CommandType.Text
                    .CommandText = "Create Procedure EliminaDoppioniSinistro As " +
                                   "DELETE DISTINCTROW A.* " +
                                   "FROM Sinistri AS A " +
                                   "INNER JOIN " +
                                        "(SELECT Count(*), Max(AnnoMeseCompetenza) AS UltimoAggiornamento," +
                                         "AgenziaSinistro, EsercizioSinistro, NumeroSinistro " +
                                         "FROM Sinistri " +
                                         "GROUP BY AgenziaSinistro, EsercizioSinistro, NumeroSinistro " +
                                         "HAVING Count(*) > 1) AS B " +
                                   "ON (A.AgenziaSinistro = B.AgenziaSinistro) AND " +
                                      "(A.EsercizioSinistro = B.EsercizioSinistro) AND " +
                                      "(A.NumeroSinistro = B.NumeroSinistro) " +
                                   "WHERE A.AnnoMeseCompetenza < B.UltimoAggiornamento"

                    .ExecuteNonQuery()
                End With

            Catch ex As Exception
                'la stored c'è già
            End Try

            'creo la stored per CERCARE i doppioni
            Try
                With cmd
                    .CommandType = CommandType.Text
                    .CommandText = "Create Procedure CercaDoppioniSinistro As " +
                                   "SELECT DISTINCTROW A.* " +
                                   "FROM Sinistri AS A " +
                                   "INNER JOIN " +
                                        "(SELECT AgenziaSinistro, EsercizioSinistro, NumeroSinistro " +
                                         "FROM Sinistri " +
                                         "GROUP BY AgenziaSinistro, EsercizioSinistro, NumeroSinistro " +
                                         "HAVING Count(*) > 1) AS B " +
                                   "ON (A.AgenziaSinistro = B.AgenziaSinistro) AND " +
                                      "(A.EsercizioSinistro = B.EsercizioSinistro) AND " +
                                      "(A.NumeroSinistro = B.NumeroSinistro)"
                    .ExecuteNonQuery() 'creo la stored
                End With

            Catch ex As Exception
                'la stored c'è già
            End Try
        End Using
    End Sub

    Private Sub EliminaDoppioniSinistro()

        Try
            Using cmd As New OleDbCommand
                cmd.Connection = cnArrivi
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "EliminaDoppioniSinistro"
                cmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            BoxErrore(ex)
        End Try

    End Sub

    Private Function EsistonoSinistriDuplicati() As Boolean

        'i duplicati li segno nel log ma li elimino per non bloccare tutta l'importazione

        Try
            Using cmd As New OleDbCommand

                cmd.Connection = cnArrivi
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "CercaDoppioniSinistro"

                Dim dr As OleDbDataReader = cmd.ExecuteReader

                If dr.HasRows Then
                    EsistonoSinistriDuplicati = True

                    LogErrori("Attenzione: File con sinistri duplicati.")

                    Using cmdDelete As New OleDbCommand

                        cmdDelete.Connection = cnArrivi
                        cmdDelete.CommandType = CommandType.Text
                        cmdDelete.CommandText = "DELETE FROM Sinistri " + _
                                                "WHERE AgenziaSinistro = ? AND EsercizioSinistro = ? AND NumeroSinistro = ?"

                        Do While dr.Read

                            With cmdDelete
                                .Parameters.Clear()
                                .Parameters.AddWithValue("Agenzia", dr("AgenziaSinistro"))
                                .Parameters.AddWithValue("Esercizio", dr("EsercizioSinistro"))
                                .Parameters.AddWithValue("Numero", dr("NumeroSinistro"))

                                LogErrori(String.Format("Eliminati {0} sinistri con numero {1}-{2}-{3}",
                                                        .ExecuteNonQuery,
                                                        dr("AgenziaSinistro"),
                                                        dr("EsercizioSinistro"),
                                                        dr("NumeroSinistro")))
                            End With
                        Loop
                    End Using
                Else
                    EsistonoSinistriDuplicati = False
                End If

                dr.Close()
            End Using

        Catch ex As Exception
            BoxErrore(ex)
        End Try

    End Function
#End Region

#Region "altri dati sinistri"
    Private Function ImportaIncarichi(ByVal FileDati As String) As Boolean

        AddLog(">>> Importa incarichi")

        Using da As New OleDbDataAdapter("SELECT * FROM SIncarichi WHERE False", cnArrivi)

            Using cmdBuilder As New OleDbCommandBuilder(da)

                Try
                    Using cmd As New OleDbCommand
                        cmd.Connection = cnArrivi

                        'creo la stored per l'inserimento
                        With cmd
                            .CommandType = CommandType.Text
                            .CommandText = "Create Procedure InsIncarico AS " + cmdBuilder.GetInsertCommand.CommandText
                            .ExecuteNonQuery()
                        End With
                    End Using

                Catch ex As Exception
                    'la stored c'è già
                End Try

                Try
                    Dim dt As New DataTable
                    da.Fill(dt)

                    'dichiaro la tipologia di record nel file da analizzare
                    Dim Record As New RecordIncarichi(FileCorrente.DataFile)

                    Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)

                        If FileCorrente.TrovaSezione(sr, "INIZIO INCARICHI") = False Then Return True

                        Do While Not sr.EndOfStream
                            Record.Testo = sr.ReadLine

                            'controlla se siamo arrivati alla fine della sezione sinistri
                            If Record.FineSezione = True Then Exit Do

                            'importa la riga in un datarow
                            If Record.EstraiDatiIncarico(dt) = False Then Throw New System.Exception

                            Application.DoEvents()
                        Loop
                    End Using

                    'imposto il cmd per l'esecuzione della stored di inserimento
                    da.InsertCommand = FunzioniSinistri.AssegnaParametriCommand("InsIncarico", dt)
                    da.Update(dt)

                    AddLog(String.Format(">>> Importa incarichi: ok (record importati {0})", dt.Rows.Count))

                    Return True

                Catch ex As Exception
                    BoxErrore(ex)
                    AddLog(">>> Importa incarichi: Errore")
                    Return False
                End Try
            End Using
        End Using

    End Function

    Private Function ImportaPagamenti(ByVal FileDati As String) As Boolean

        AddLog(">>> Importa pagamenti")

        'imposto dataadapter e commandbuilder
        Using da As New OleDbDataAdapter("SELECT * FROM SPagamenti WHERE False", cnArrivi)

            Using cmdBuilder As New OleDbCommandBuilder(da)

                Try
                    Using cmd As New OleDbCommand
                        cmd.Connection = cnArrivi

                        'creo la stored per l'inserimento
                        With cmd
                            .CommandType = CommandType.Text
                            .CommandText = "Create Procedure InsPagamento AS " + cmdBuilder.GetInsertCommand.CommandText
                            .ExecuteNonQuery()
                        End With
                    End Using

                Catch ex As Exception
                    'la stored c'è già
                End Try

                Try
                    Dim dt As New DataTable
                    da.Fill(dt)

                    'dichiaro la tipologia di record nel file da analizzare
                    Dim Record As New RecordPagamenti(FileCorrente.DataFile)

                    Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)

                        If FileCorrente.TrovaSezione(sr, "INIZIO PAGAMENTI") = False Then Return True

                        Do While Not sr.EndOfStream
                            Record.Testo = sr.ReadLine

                            'controlla se siamo arrivati alla fine della sezione sinistri
                            If Record.FineSezione = True Then Exit Do

                            'importa la riga in un datarow
                            If Record.EstraiDatiPagamento(dt) = False Then Throw New System.Exception

                            Application.DoEvents()
                        Loop
                    End Using

                    'imposto il cmd per l'esecuzione della stored di inserimento
                    da.InsertCommand = FunzioniSinistri.AssegnaParametriCommand("InsPagamento", dt)
                    da.Update(dt)

                    AddLog(String.Format(">>> Importa pagamenti: ok (record importati {0})", dt.Rows.Count))

                    Return True

                Catch ex As Exception
                    BoxErrore(ex)
                    AddLog(">>> Importa pagamenti: Errore")
                    Return False
                End Try
            End Using
        End Using

    End Function

    Private Function ImportaProfessionisti(ByVal FileDati As String) As Boolean

        AddLog(">>> Importa professionisti")

        'imposto dataadapter e commandbuilder
        Using da As New OleDbDataAdapter("SELECT * FROM PeritoIncaricato WHERE False", cnArrivi)

            Using cmdBuilder As New OleDbCommandBuilder(da)

                Try
                    Using cmd As New OleDbCommand
                        cmd.Connection = cnArrivi

                        'cancello eventuali importazioni precedenti
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "DELETE FROM PeritoIncaricato"
                        cmd.ExecuteNonQuery()

                        'creo la stored per l'inserimento
                        With cmd
                            .CommandType = CommandType.Text
                            .CommandText = "Create Procedure InsPerito AS " + cmdBuilder.GetInsertCommand.CommandText
                            .ExecuteNonQuery()
                        End With
                    End Using

                Catch ex As Exception
                    'la stored c'è già
                End Try

                Try
                    Dim dt As New DataTable
                    da.Fill(dt)

                    'dichiaro la tipologia di record nel file da analizzare
                    Dim Record As New RecordPeriti(FileCorrente.DataFile)

                    Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)

                        If FileCorrente.TrovaSezione(sr, "INIZIO PROFESSIONISTI") = False Then Return True

                        Do While Not sr.EndOfStream
                            Record.Testo = sr.ReadLine

                            'controlla se siamo arrivati alla fine della sezione sinistri
                            If Record.FineSezione = True Then Exit Do

                            'importa la riga in un datarow
                            If Record.EstraiDatiPerito(dt) = False Then Throw New System.Exception

                            Application.DoEvents()
                        Loop
                    End Using

                    'imposto il cmd per l'esecuzione della stored di inserimento
                    da.InsertCommand = FunzioniSinistri.AssegnaParametriCommand("InsPerito", dt)
                    da.Update(dt)

                    AddLog(String.Format(">>> Importa professionisti: ok (record importati {0})", dt.Rows.Count))

                    Return True

                Catch ex As Exception
                    BoxErrore(ex)
                    AddLog(">>> Importa professionisti: Errore")
                    Return False
                End Try
            End Using
        End Using

    End Function

    Friend Function ImportaSinistriBase(ByVal FileDati As String,
                                        ByVal Anno As Integer) As Boolean

        AddLog(">>> Importa sinistri base")

        'inizializzo command builder
        Dim da As New OleDbDataAdapter("SELECT * FROM SinistriAia WHERE False", cnArrivi)
        Dim cmdBuilder As New OleDbCommandBuilder(da)
        Dim cmd As New OleDbCommand

        Try
            'creo la stored procedure di insert
            With cmd
                .Connection = cnArrivi
                .CommandType = CommandType.Text
                .CommandText = "Create Procedure InsSinistroAia As " + cmdBuilder.GetInsertCommand.CommandText
                .ExecuteNonQuery()
            End With

        Catch ex As Exception
            'la stored c'è già
            cmdBuilder.Dispose()
            da.Dispose()
        End Try

        'imposto il cmd per l'esecuzione della stored
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "InsSinistroAia"

        Try
            'imposto la connessione a seconda del tipo di file
            Select Case Path.GetExtension(FileDati).ToLower

                Case ".xls" 'file in formato excel

                    Try
                        Using cx As New OleDbConnection(Glo.XLSDriver + FileDati)

                            cx.Open()

                            Using cmdEx As New OleDbCommand

                                Dim dr As OleDbDataReader

                                cmdEx.Connection = cx
                                cmdEx.CommandType = CommandType.Text
                                cmdEx.CommandText = "SELECT * FROM [Dati$]"

                                'leggo i dati dal file excel
                                dr = cmdEx.ExecuteReader

                                'leggo riga per riga il dr e aggiungo alla tabella in arrivi
                                Do While dr.Read
                                    cmd.Parameters.Clear()

                                    'il db contiene una colonna in più con l'anno di competenza
                                    cmd.Parameters.AddWithValue("Anno", Anno)

                                    'imposta i parametri
                                    For k As Integer = 0 To dr.FieldCount - 1
                                        Select Case k
                                            Case 5
                                                'analisi per correggere errori ex fonsai (05/2016) - vedi 7
                                                If dr(7).ToString.Length = 10 Then
                                                    'prendo i primi 5 caratteri che rappresentano l'agenzia
                                                    cmd.Parameters.AddWithValue(k.ToString, dr(k).ToString.Substring(0, 5))
                                                Else
                                                    cmd.Parameters.AddWithValue(k.ToString, dr(k))
                                                End If
                                            Case 7
                                                'analisi per correggere errori ex fonsai (05/2016)
                                                If dr(k).ToString.Length = 10 Then
                                                    'tolgo i primi 5 caratteri che rappresentano l'agenzia
                                                    'il numero polizza è comunque sbagliato perchè sempre uguale
                                                    cmd.Parameters.AddWithValue(k.ToString, dr(k).ToString.Substring(5))
                                                Else
                                                    cmd.Parameters.AddWithValue(k.ToString, dr(k))
                                                End If
                                            Case 8
                                                'tolgo le virgolette nel campo intestatario polizza
                                                Dim Contraente As String
                                                If dr(k) Is DBNull.Value Then
                                                    Contraente = ""
                                                Else
                                                    Contraente = dr(k).Replace(Chr(34), "")
                                                    Contraente = Contraente.Replace("'", "")
                                                End If

                                                cmd.Parameters.AddWithValue(k.ToString, Contraente)
                                            Case Else
                                                cmd.Parameters.AddWithValue(k.ToString, dr(k))
                                        End Select
                                    Next

                                    'il db contiene una colonna in più, alla fine, con il flag coass
                                    cmd.Parameters.AddWithValue("32", "")

                                    cmd.ExecuteNonQuery()
                                Loop

                                dr.Close()
                            End Using
                        End Using

                    Catch ex As Exception
                        BoxErrore(ex)
                        AddLog(">>> Importa sinistri base formato xls: Errore")
                        Throw New System.Exception
                    End Try

                Case ".csv" 'file in formato csv

                    Dim Campi() As String

                    Try
                        Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)
                            'prima riga con il nome dei campi
                            sr.ReadLine()

                            Do While Not sr.EndOfStream
                                Campi = sr.ReadLine.Split(";")
                                'tolgo le virgolette nel campo intestatario polizza
                                If Campi(8) Is DBNull.Value Then
                                    Campi(8) = ""
                                Else
                                    Campi(8) = Campi(8).Replace(Chr(34), "").Replace("'", "")
                                End If
                                'analisi per correggere errori ex fonsai (05/2016) - vedi 7
                                If Campi(7).ToString.Length = 10 Then
                                    'prendo i primi 5 caratteri che rappresentano l'agenzia
                                    Campi(5) = Campi(7).ToString.Substring(0, 5)
                                    'gli ultimi 5 caratteri sono il numero di polizza (sbagliato)
                                    Campi(7) = Campi(7).ToString.Substring(5)
                                End If

                                cmd.Parameters.Clear()

                                'il db contiene una colonna in più con l'anno di competenza
                                cmd.Parameters.AddWithValue("Anno", Anno)

                                'imposta i parametri
                                For k As Integer = 0 To Campi.GetUpperBound(0)
                                    cmd.Parameters.AddWithValue(k.ToString, Campi(k))
                                Next

                                If Campi.GetUpperBound(0) = 31 Then
                                    'il db contiene una colonna in più, alla fine, con il flag coass
                                    cmd.Parameters.AddWithValue("32", "")
                                End If

                                cmd.ExecuteNonQuery()
                            Loop

                            sr.Close()
                        End Using

                    Catch ex As Exception
                        BoxErrore(ex)

                        AddLog(">>> Importa sinistri base formato csv: Errore")
                        For k As Integer = 0 To Campi.GetUpperBound(0)
                            LogErroriRiga(String.Format("{0}: {1}", k, Campi(k)))
                        Next

                        Throw New System.Exception
                    End Try
            End Select

            AggiornaCalendarioUt(Glo.Impo.CodAgenzia, _
                     TipoFileMagia.SinistriBase, _
                     New Date(Anno, 1, 1), _
                     New Date(Anno, 12, 31), _
                     FileDati)

            AddLog(">>> Importa sinistri base: ok")

            ImportaSinistriBase = True

        Catch ex As Exception
            BoxErrore(ex)
            AddLog(">>> Importa sinistri base: Errore")
            ImportaSinistriBase = False
        End Try

    End Function

    Friend Sub ImportaRiserve(ByVal FileDati As String, ByVal Anno As Integer)
        IconaNotifica.Text = "Unitools: " + vbCrLf + _
                             "importa riserve..."
        AddLog(">>> Importa riserve")

        Try
            Using da As New OleDbDataAdapter("SELECT * FROM Riserve", cnArrivi)

                Using cmdBuilder As New OleDbCommandBuilder(da)

                    Using cmd As New OleDbCommand

                        With cmd
                            Try
                                'creo la stored procedure
                                .Connection = cnArrivi
                                .CommandType = CommandType.Text
                                .CommandText = "Create Procedure InsRiserva As " + cmdBuilder.GetInsertCommand.CommandText

                                .ExecuteNonQuery()

                            Catch ex As Exception
                                'esiste già
                            End Try
                        End With
                    End Using
                End Using
            End Using

            Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)

                Using cmd As New OleDbCommand

                    'imposto il cmd per l'esecuzione
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = "InsRiserva"

                    'leggo testata
                    sr.ReadLine()

                    Do While Not sr.EndOfStream

                        Dim Campi() As String = sr.ReadLine.Split(";")

                        TrimArray(Campi)

                        With cmd.Parameters
                            .Clear()

                            .AddWithValue("AgenziaSinistro", CShort(Campi(6)))
                            .AddWithValue("Esercizio", CShort(Campi(5)))
                            .AddWithValue("Numero", CInt(Campi(8)))
                            .AddWithValue("Importo", CDbl(Campi(12)))
                        End With

                        cmd.ExecuteNonQuery()
                    Loop
                End Using
            End Using

            AggiornaCalendarioUt(Glo.Impo.CodAgenzia, _
                                 TipoFileMagia.Riserve, _
                                 DateSerial(Anno, 1, 1), _
                                 DateSerial(Anno, 12, 31), _
                                 FileDati, _
                                 #1/1/2000#)

            AddLog(">>> Importa riserve: Ok")

        Catch ex As Exception
            BoxErrore(ex)
            AddLog(">>> Importa riserve: Errore")
            SvuotaTabella(TipoFileMagia.Sinistri)
        End Try
    End Sub

#End Region

End Module
