Imports System.Data.OleDb
Imports System.IO

Module AndamentoSinistri

    Friend Function ImportaAndamento(ByVal FileDati As String, ByVal DataFile As Date) As Boolean

        AddLog(">>> Importa andamento")

        Try
            Using cmd As New OleDbCommand

                cmd.Connection = cnArrivi

                Using da As New OleDbDataAdapter("SELECT * FROM AndamentoSinistri WHERE False", cnArrivi)

                    Dim dt As New DataTable
                    da.Fill(dt)

                    Dim FileCorrente As FileSinistri = New FileSinistri(FileDati)

                    'dichiaro la tipologia di record nel file da analizzare
                    Dim Record As New RecordSinistri(FileCorrente.DataFile, True)

                    'leggo il file da importare riga per riga
                    Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)

                        'scarto la testata che non mi serve
                        sr.ReadLine()

                        'importa sinistri
                        Do While Not sr.EndOfStream

                            Record.Testo = sr.ReadLine

                            'controlla se siamo arrivati alla fine della sezione sinistri
                            If Record.FineSezione = True Then Exit Do

                            'importa la riga in un datarow
                            If Record.EstraiDatiSinistro(dt) = False Then Throw New System.Exception

                            Application.DoEvents()
                        Loop
                    End Using

                    'imposto il cmd per l'esecuzione della stored di inserimento
                    da.InsertCommand = FunzioniSinistri.AssegnaParametriCommand("InsAndamento", dt)

                    da.Update(dt)
                End Using
            End Using

            AddLog(">>> Importa andamento: Ok")

            ImportaAndamento = True 'EliminaDoppioniAndamentoSinistri()

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
            AddLog(">>> Importa andamento: Errore")
            ImportaAndamento = False
        End Try

    End Function

    Friend Sub ModificaCampiAndamento()

        Try
            Using cmd As New OleDbCommand

                cmd.Connection = cnArrivi
                cmd.CommandType = CommandType.Text

                'aggiorno riserva di bilancio a zero
                cmd.CommandText = "UPDATE AndamentoSinistri SET RiservaBilancio = 0"
                cmd.ExecuteNonQuery()

                'modifica i codici chiusura in andamento
                cmd.CommandText = "UPDATE AndamentoSinistri SET TipoChiusura = '..' " +
                                  "WHERE Len(Trim(TipoChiusura)) = 0 Or IsNull(TipoChiusura)"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "UPDATE AndamentoSinistri SET TipoChiusura = 'LT' " +
                                  "WHERE Val(TipoChiusura) = 2 Or Val(TipoChiusura) > 3"
                cmd.ExecuteNonQuery()

                cmd.CommandText = "UPDATE AndamentoSinistri SET TipoChiusura = 'SS' " +
                                  "WHERE Val(TipoChiusura) = 3"
                cmd.ExecuteNonQuery()

                'modifica SS in LT se il costo è diverso da zero (ci sono dei casi con più posizioni)
                cmd.CommandText = "UPDATE AndamentoSinistri SET TipoChiusura = 'LT' " +
                                  "WHERE TipoChiusura = 'SS' AND PagatoAl <> 0"
                cmd.ExecuteNonQuery()

            End Using

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
        End Try
    End Sub

    Friend Function EliminaDoppioniAndamentoSinistri() As Boolean

        AddLog(">>> Controllo doppioni andamento")

        Try
            'utilizzo la stored creata precedentemente per eliminare i doppioni
            Using cmd As New OleDbCommand

                cmd.Connection = cnArrivi

                'modifico le date a null altrimenti la stored di aliminazione doppioni non funziona
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "UPDATE AndamentoSinistri SET DataUltPagam = #1/1/1900# " +
                                  "WHERE DataUltPagam IS NULL"
                cmd.ExecuteNonQuery()


                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "EliminaDoppioniAndamento"

                AddLog(String.Format(">>> Eliminati {0} doppioni", cmd.ExecuteNonQuery()))

                'riporto a null le date
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "UPDATE AndamentoSinistri SET DataUltPagam = NULL " +
                                  "WHERE DataUltPagam = #1/1/1900#"
                cmd.ExecuteNonQuery()
            End Using

            AddLog(">>> Controllo doppioni andamento: Ok")

            EliminaDoppioniAndamentoSinistri = True

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
            AddLog(">>> Elimina doppioni andamento: Errore")
            EliminaDoppioniAndamentoSinistri = False
        End Try

    End Function

    Friend Sub SalvaStoricoAndamentoSinistri()
        'viene richiamato quando è finita l'importazione di tutti i file
        'chiudo la connessione ad arrivi.mdb
        cnArrivi.Close()

        Try
            Using c As New OleDbConnection(Glo.MDBConnectionString + Path.Combine(Glo.PathDati, "Andamenti.mdb"))

                c.Open()

                Using cmd As New OleDbCommand

                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text

                    'cancello la vecchia tabella andamenti
                    CancellaTabella(cmd, "AndamentoSinistri")

                    cmd.CommandText = String.Format("SELECT * INTO AndamentoSinistri FROM AndamentoSinistri IN '{0}'",
                                                    Glo.FullNameDbArrivi)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            AddLog(String.Format("{0}: {1}", mAgenzia.CodiceCollegato, "Salva storico andamento sinistri: Ok"))

        Catch ex As Exception
            AddLog(String.Format("{0}: {1}", mAgenzia.CodiceCollegato, "Errore in Salva storico andamento sinistri"))
            Globale.Log.BoxErrore(ex)
        End Try

        AddLog()

        'riapro la connessione al db arrivi
        cnArrivi.Open()

    End Sub

    Friend Sub CreaStoredInserimento()

        Try
            Using da As New OleDbDataAdapter("SELECT * FROM AndamentoSinistri WHERE False", cnArrivi)

                Using cmdBuilder As New OleDbCommandBuilder(da)

                    'creo la stored per l'inserimento
                    Using cmd As New OleDbCommand
                        Try
                            cmd.Connection = cnArrivi
                            cmd.CommandType = CommandType.Text
                            cmd.CommandText = "Create Procedure InsAndamento AS " + cmdBuilder.GetInsertCommand.CommandText
                            cmd.ExecuteNonQuery()

                        Catch ex As Exception
                            'la stored c'è già
                        End Try
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
        End Try

    End Sub

    Friend Sub CreaStoredDoppioniAndamento()

        AddLog(">>> Creo stored eliminazione doppioni in andamento")

        Try
            Using cmd As New OleDbCommand
                With cmd
                    .Connection = cnArrivi
                    .CommandType = CommandType.Text
                    .CommandText = "Create Procedure EliminaDoppioniAndamento AS " +
                                   "DELETE DISTINCTROW A.* " +
                                   "FROM AndamentoSinistri AS A " +
                                   "INNER JOIN " +
                                       "(SELECT Min(AnnoMeseCompetenza) AS MinDiAnnoMeseCompetenza," +
                                               "EsercizioSinistro,NumeroSinistro," +
                                               "AgenziaSinistro,TipoCid,TipoChiusura,PrimoPreventivo,PagatoDel," +
                                               "PagatoAl,RecuperoDel,RecuperoAl,DataUltPagam,NrPosizioni," +
                                               "CardGest,CardDebito,CardNo,FranchigieAl,FranchigieDel,RivalseAl," +
                                               "RivalseDel,AltroAl,AltroDel,SpeseAl,SpeseDel,Riserva,RiservaBilancio " +
                                       "FROM AndamentoSinistri " +
                                       "GROUP BY EsercizioSinistro,NumeroSinistro," +
                                                "AgenziaSinistro,TipoCid,TipoChiusura,PrimoPreventivo,PagatoDel," +
                                                "PagatoAl,RecuperoDel,RecuperoAl,DataUltPagam,NrPosizioni," +
                                                "CardGest,CardDebito,CardNo,FranchigieAl,FranchigieDel,RivalseAl," +
                                                "RivalseDel,AltroAl,AltroDel,SpeseAl,SpeseDel,Riserva,RiservaBilancio " +
                                       "HAVING Count(AnnoMeseCompetenza) > 1) AS B " +
                                   "ON A.EsercizioSinistro = B.EsercizioSinistro AND " +
                                      "A.NumeroSinistro = B.NumeroSinistro AND " +
                                      "A.AgenziaSinistro = B.AgenziaSinistro AND " +
                                      "A.TipoCid = B.TipoCid AND " +
                                      "A.TipoChiusura = B.TipoChiusura AND " +
                                      "A.PrimoPreventivo = B.PrimoPreventivo AND " +
                                      "A.PagatoDel = B.PagatoDel AND " +
                                      "A.PagatoAl = B.PagatoAl AND " +
                                      "A.RecuperoDel = B.RecuperoDel AND " +
                                      "A.RecuperoAl = B.RecuperoAl AND " +
                                      "A.DataUltPagam = B.DataUltPagam AND " +
                                      "A.NrPosizioni = B.NrPosizioni AND " +
                                      "A.CardGest = B.CardGest AND " +
                                      "A.CardDebito = B.CardDebito AND " +
                                      "A.CardNo = B.CardNo AND " +
                                      "A.FranchigieAl = B.FranchigieAl AND " +
                                      "A.FranchigieDel = B.FranchigieDel AND " +
                                      "A.RivalseAl = B.RivalseAl AND " +
                                      "A.RivalseDel = B.RivalseDel AND " +
                                      "A.AltroAl = B.AltroAl AND " +
                                      "A.AltroDel = B.AltroDel AND " +
                                      "A.SpeseAl = B.SpeseAl AND " +
                                      "A.SpeseDel = B.SpeseDel AND " +
                                      "A.Riserva = B.Riserva AND " +
                                      "A.RiservaBilancio = B.RiservaBilancio " +
                                   "WHERE(A.AnnoMeseCompetenza > B.MinDiAnnoMeseCompetenza)"

                    .ExecuteNonQuery()
                End With
            End Using

            AddLog(">>> Stored doppioni creata")

        Catch ex As Exception
            'la stored c'è già
        End Try

    End Sub

End Module
