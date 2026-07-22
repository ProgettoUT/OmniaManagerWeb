Imports System.IO
Imports System.Data.OleDb
Imports System.Net
Imports System.Data

Public Class PrimaNota

    Public Event StatoImportazione(e As ExportEventArgs)

    Private WithEvents e As New ExportEventArgs
    Private WithEvents Essig As RichiesteEssig
    Private Archivio As Utx.CartelleArchivioDati

    Private Enum PN
        Tipo = 0
        Movimento = 1
        Descrizione = 2
        Categoria = 3
        Ramo = 4
        Polizza = 5
        Effetto = 6
        Contraente = 7
        Segno = 8
        Cassa = 9
        Banca = 10
        CBanc = 11
        PrBon = 12
        Altro = 13
        Pagamento = 14
        SubAgenzia = 15
        Convenzione = 16
        Registrazione = 17
        Inserimento = 18
        Conferma = 19
    End Enum

    Private mCookie As CookieContainer
    Public Property Cookie() As CookieContainer
        Get
            Return mCookie
        End Get
        Set(value As CookieContainer)
            mCookie = value
        End Set
    End Property

    Public Shared Function MdbPrimaNota(Agenzia As String) As String
        Return String.Format("{0}\{1}\PrimaNota.mdb", Utx.Globale.Paths.CartellaDati, Agenzia)
    End Function

    Friend Sub CatturaPrimaNota(InizioPeriodo As Date,
                                FinePeriodo As Date,
                                ByRef Annulla As Boolean)

        Globale.Log.Info(String.Format("Prima nota: utente {0}", Environment.UserName))

        Try
            Dim Config As New Utx.ConfigSede
            Dim dt As DataTable = Config.ConfigAgenzia(Utx.Globale.ProfiloEnteGestore.Compagnia,
                                                       Utx.Globale.AgenziaRichiesta.CodiceAgenzia,
                                                       Utx.Globale.ProfiloEnteGestore.CodiceSede)

            Essig = New RichiesteEssig(RichiesteEssig.TipoRichiesta.PRIMA_NOTA, RichiesteEssig.TipoCompagnia.UNIPOL)

            e.AgenziaMadre = Utx.Globale.AgenziaRichiesta.CodiceAgenzia
            e.AgenziaFiglia = e.AgenziaMadre

            'PreparaImportazione()

            For Each Figlia As DataRow In dt.Rows

                'se madre e figlia coincidono
                If Figlia("Agenzia") = Figlia("Collegata") Then

                    'inizializzo l'archivio dell'agenzia o delle accorpate
                    Archivio = New Utx.CartelleArchivioDati(Figlia("Collegata"))

                    If Archivio.Disponibile = False Then
                        Globale.Log.Info("Archivio dati non disponibile")
                    End If

                    For Each SubAgenzia As String In Figlia("CodiciSub").ToString.Split("/")

                        Globale.Log.Info(String.Format("Agenzia {0} - Collegata {1} - Sub {2}",
                                                       Figlia("Agenzia"),
                                                       Figlia("Collegata"),
                                                       SubAgenzia))
                        Globale.Log.AumentaRientro()

                        e.SubAgenzia = SubAgenzia

                        If e.Errore Then Exit Try

                        Dim Inizio As Date = InizioPeriodo

                        Do While Inizio <= FinePeriodo

                            'scarico file di 1 giorno per volta
                            Globale.Log.Info(String.Format("Importazione Prima Nota dal {0} al {1}",
                                                           Inizio.ToShortDateString,
                                                           Inizio.ToShortDateString))
                            Globale.Log.AumentaRientro()

                            e.InizioPeriodo = Inizio
                            e.FinePeriodo = Inizio
                            RaiseEvent StatoImportazione(e)

                            'catturo il file degli esitati in formato csv
                            Dim FileDati As String = ScaricaFilePrimaNota(e.AgenziaMadre,
                                                                          Inizio,
                                                                          Inizio)

                            ControlloFilePrimaNota(FileDati, e)
                            If e.Errore = True Then
                                Exit Try
                            End If

                            If String.IsNullOrEmpty(File.ReadAllText(FileDati)) = False Then
                                'archivio il file
                                If Archivio.ArchiviazioneAbilitata Then
                                    ArchiviaFilePrimaNota(FileDati, Inizio)
                                End If
                            End If

                            'cancello il file csv
                            File.Delete(FileDati)

                            Globale.Log.DiminuisciRientro()

                            'avanzo di un giorno
                            Inizio = Inizio.AddDays(1)
                        Loop

                        Globale.Log.DiminuisciRientro()
                    Next
                End If
            Next

            'ConcludiImportazione(InizioPeriodo, FinePeriodo)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

        If e.Errore Then
            Globale.Log.Info("Importazione con errori")
        Else
            Globale.Log.Info("Importazione completata correttamente")
        End If

        Globale.Log.Info()

    End Sub

    Private Function ScaricaFilePrimaNota(Agenzia As String,
                                          Inizio As Date,
                                          Fine As Date) As String

        Try
            'chiamo il menù 1 e 2: necessario per settaggio parametri
            Essig.ChiamaMenu()
            If Essig.EventArgs.Errore = True Then
                Return ""
            End If
            Essig.ChiamaMenu2()
            If Essig.EventArgs.Errore = True Then
                Return ""
            End If

            'richiedo i dati
            Essig.RichiestaDati(Inizio, Fine)
            If Essig.EventArgs.Errore = True Then
                Return ""
            End If

            Dim NomeFile As String = String.Format("{0}_PNOTA_ESSIG_{1}.csv", Agenzia, Format(Inizio, "yyyyMMdd"))

            'esporto il file dati in formato csv
            Dim FileDati As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, NomeFile)
            If Essig.EventArgs.Errore = True Then
                Return ""
            End If

            'salvo il file
            Using sw As New StreamWriter(FileDati)
                sw.Write(Essig.EsportaDati)
            End Using

            Return FileDati

        Catch ex As Exception
            Globale.Log.Errore(ex)
            e.Messaggio = ex.Message
            e.Errore = True
            Return ""
        End Try

    End Function

    Private Sub ControlloFilePrimaNota(FileDati As String,
                                       ByRef e As ExportEventArgs)
        Try
            Dim Riga As String

            Using sr As New StreamReader(FileDati)
                Riga = sr.ReadLine
            End Using

            If Riga Is Nothing Then
                e.Errore = False 'non c'è errore il file è vuoto
            Else
                If Riga.ToUpper.StartsWith("COD TIP;MOVIMENTO;") = False Then

                    Globale.Log.Info(String.Format("File dati non valido: {0}", Path.GetFileName(FileDati)))

                    e.Messaggio = String.Format("File dati non valido:{0}{1}",
                                                Environment.NewLine,
                                                Path.GetFileName(FileDati))
                    e.Errore = True
                End If
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

    End Sub

    Friend Sub ArchiviaFilePrimaNota(FileOrigine As String,
                                     Giorno As Date)
        Try
            'file di destinazione zippato
            Dim FileDest As String = Path.Combine(Archivio.PrimaNota(Giorno.Year), Path.GetFileName(FileOrigine))
            FileDest = Path.ChangeExtension(FileDest, "zip")

            'cancello il file se esiste
            File.Delete(FileDest)

            'zippo e archivio
            Utx.LibreriaZip.ZipFile(FileOrigine, FileDest)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ImportaPrimaNota(FileDati As String)
        Try
            Using c As New OleDbConnection(Utx.Globale.MDBDriver + MdbPrimaNota(e.AgenziaMadre))

                c.Open()

                Using da As New OleDbDataAdapter("SELECT * FROM PrimaNota WHERE False", c)

                    Using cmdBuilder As New OleDbCommandBuilder(da)
                        da.InsertCommand = cmdBuilder.GetInsertCommand

                        Dim dt As New DataTable
                        da.Fill(dt)

                        'pulisco il file da eventuali null
                        ClearFileFromNull(FileDati)

                        Dim Record As Integer = File.ReadAllLines(FileDati).Length
                        'in caso di file non vuoti tolgo l'intestazione
                        If Record > 0 Then
                            Record -= 1
                        End If

                        'apro lo stream e leggo la prima riga con il nome dei campi
                        Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)

                            sr.ReadLine() 'intestazione

                            Dim Campi() As String

                            Do While Not sr.EndOfStream

                                Campi = sr.ReadLine.Split(";")

                                'trimma tutto
                                TrimArray(Campi)

                                Dim dr As DataRow = dt.NewRow

                                dr("Tipo") = Campi(PN.Tipo)
                                dr("Movimento") = Campi(PN.Movimento)
                                dr("Descrizione") = Left(Campi(PN.Descrizione), 40)
                                dr("Categoria") = Campi(PN.Categoria)
                                dr("Ramo") = NormalizzaNumero(Campi(PN.Ramo))
                                dr("Polizza") = NormalizzaNumero(Campi(PN.Polizza))
                                dr("Effetto") = NormalizzaData(Campi(PN.Effetto))
                                dr("Contraente") = Left(Campi(PN.Contraente), 40)
                                dr("Segno") = Campi(PN.Segno)
                                dr("Cassa") = CDbl(Campi(PN.Cassa))
                                dr("Banca") = CDbl(Campi(PN.Banca))
                                dr("CBanc") = NormalizzaNumero(Campi(PN.CBanc))
                                dr("PrBon") = NormalizzaNumero(Campi(PN.PrBon))
                                dr("Altro") = CDbl(Campi(PN.Altro))
                                dr("Pagamento") = Campi(PN.Pagamento)
                                dr("SubAgenzia") = NormalizzaNumero(Campi(PN.SubAgenzia))
                                dr("Convenzione") = NormalizzaNumero(Campi(PN.Convenzione))
                                dr("Registrazione") = NormalizzaData(Campi(PN.Registrazione))
                                dr("Inserimento") = Campi(PN.Inserimento)
                                dr("Conferma") = Campi(PN.Conferma)

                                dt.Rows.Add(dr)
                            Loop
                        End Using

                        If dt.Rows.Count = Record Then

                            If dt.Rows.Count > 0 Then

                                CancellaPrimaNota(dt.Rows(0).Item("Registrazione"), c)
                                If e.Errore = True Then
                                    e.Messaggio = "Errore nel consolidamento dati"
                                End If

                                da.Update(dt)

                                Globale.Log.Info(String.Format("record importati: {0}", dt.Rows.Count))
                                dt.Dispose()
                            End If
                        Else
                            e.Errore = True
                            e.Messaggio = "Numero di record errato"
                        End If
                    End Using

                    File.Delete(FileDati)
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
            e.Errore = True
        End Try
    End Sub

    Private Function NormalizzaNumero(Numero As String) As Object

        If IsNumeric(Numero) Then
            Return Numero
        Else
            Return 0
        End If
    End Function

    Private Function NormalizzaData(Data As String) As Object

        If Data = "01/01/0001" Then
            Return DBNull.Value
        Else
            If IsDate(Data) Then
                Return CDate(Data)
            Else
                Return DBNull.Value
            End If
        End If
    End Function

    Private Sub CancellaPrimaNota(Giorno As Date,
                                  ByRef c As OleDbConnection)

        Try
            Using cmd As New OleDbCommand

                cmd.Connection = c
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "DELETE FROM PrimaNota WHERE Registrazione = ?"

                cmd.Parameters.AddWithValue("Giorno", Giorno)
                cmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            Globale.Log.Info(ex.Message)
            e.Errore = True
        End Try
    End Sub

    'Private Sub PreparaImportazione()

    '    Try
    '        Using c As New OleDbConnection(UtNetUtility.Setting.MDBDriver + MdbIncassi(e.AgenziaMadre))

    '            c.Open()

    '            Using cmd As New OleDbCommand

    '                'sposto la giornata in un'altra tabella (old) per poi effettuare il recupero
    '                'di alcuni dati inseriti dall'utente
    '                CancellaTabella(c, "TempArretrati")

    '                cmd.Connection = c
    '                cmd.CommandType = CommandType.Text
    '                cmd.CommandText = "SELECT * INTO TempArretrati FROM Arretrati"
    '                cmd.ExecuteNonQuery()

    '                'quindi la cancello dalla tabella. cancello anche i tipo 99 perché se sono
    '                'rimasti in tabella si tratta di un errore
    '                cmd.CommandText = "DELETE * FROM Arretrati"
    '                cmd.ExecuteNonQuery()
    '            End Using
    '        End Using

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        e.Errore = True
    '    End Try

    'End Sub

    'Private Sub ConcludiImportazione(InizioPeriodo As Date,
    '                                 FinePeriodo As Date)

    '    Try
    '        Using c As New OleDbConnection(UtNetUtility.Setting.MDBDriver + MdbIncassi(e.AgenziaMadre))

    '            c.Open()

    '            Using cmd As New OleDbCommand

    '                cmd.Connection = c
    '                cmd.CommandType = CommandType.Text

    '                'attribuisco il comparto
    '                cmd.CommandText = "UPDATE Arretrati SET Comparto = 1 WHERE RamoGestione In (1,2)"
    '                cmd.ExecuteNonQuery()
    '                cmd.CommandText = "UPDATE Arretrati SET Comparto = 2 WHERE RamoGestione In (3,4,5)"
    '                cmd.ExecuteNonQuery()
    '                cmd.CommandText = "UPDATE Arretrati SET Comparto = 3 WHERE RamoGestione In (6,7,8,9,10,21,22,23)"
    '                cmd.ExecuteNonQuery()
    '                cmd.CommandText = "UPDATE Arretrati SET Comparto = 4 WHERE RamoGestione In (11,12,13,14,15,16,17)"
    '                cmd.ExecuteNonQuery()
    '                cmd.CommandText = "UPDATE Arretrati SET Comparto = 5 WHERE RamoGestione In (18,19,20)"
    '                cmd.ExecuteNonQuery()

    '                'metto a posto i null che altrimenti danno poi fastidio nell'estrazione
    '                cmd.CommandText = "UPDATE Arretrati SET Nome = '' WHERE Nome Is Null"
    '                cmd.ExecuteNonQuery()

    '                'copio dalla tabella di backup il flag
    '                cmd.CommandText = "UPDATE Arretrati a " +
    '                                  "INNER JOIN TempArretrati o ON a.Ramo = o.Ramo AND " +
    '                                                      "a.Polizza = o.Polizza AND " +
    '                                                      "a.EffettoTitolo = o.EffettoTitolo " +
    '                                  "SET a.Incassabile = o.Incassabile"
    '                cmd.ExecuteNonQuery()

    '                CancellaTabella(c, "TempArretrati")

    '                c.Close()

    '                c.ConnectionString = UtNetUtility.Setting.CnDbLink
    '                c.Open()

    '                'join con clienti per nome e cognome
    '                cmd.CommandText = "UPDATE Arretrati a " +
    '                                  "INNER JOIN Clienti c ON a.CodiceFiscale = c.CodiceFiscale " +
    '                                  "SET a.Cognome = c.Cognome," +
    '                                      "a.Nome = c.Nome," +
    '                                      "a.Sesso = c.Sesso"
    '                cmd.ExecuteNonQuery()

    '                'join con avvisi per prodotto targa e modello
    '                cmd.CommandText = "UPDATE Arretrati a " +
    '                                  "LEFT JOIN Avvisi q ON a.Ramo = q.Ramo AND a.Polizza = Val(q.Polizza) " +
    '                                  "SET a.Prodotto = Right('00000' + q.Prodotto,5)," +
    '                                      "a.Targa = q.Targa," +
    '                                      "a.Modello = q.Modello"
    '                cmd.ExecuteNonQuery()

    '                'aggiorna calendariout
    '                'cancello record precedente (è uno solo)
    '                cmd.CommandText = "DELETE FROM CalendarioUt " +
    '                                  "WHERE TipoFile = '08' AND Agenzia = ?"
    '                cmd.Parameters.Clear()
    '                cmd.Parameters.AddWithValue("Agenzia", UtNetUtility.Setting.AgenziaRichiesta)
    '                cmd.ExecuteNonQuery()

    '                'riscrivo record con dati aggiornamento
    '                cmd.CommandText = "INSERT INTO CalendarioUt " +
    '                                              "(Agenzia,TipoFile,DataInizio,DataFine," +
    '                                               "NomeFile,DataRicezione,Consolida) " +
    '                                  "VALUES(?,?,?,?,?,?,?)"
    '                cmd.Parameters.Clear()
    '                cmd.Parameters.AddWithValue("Agenzia", UtNetUtility.Setting.AgenziaRichiesta)
    '                cmd.Parameters.AddWithValue("Tipo", "08")
    '                cmd.Parameters.AddWithValue("Inizio", InizioPeriodo)
    '                cmd.Parameters.AddWithValue("Fine", FinePeriodo)
    '                cmd.Parameters.AddWithValue("File", "Arretrati.csv")
    '                cmd.Parameters.AddWithValue("Data", Now.ToString)
    '                cmd.Parameters.AddWithValue("Consolida", #1/1/2000#)

    '                cmd.ExecuteNonQuery()
    '            End Using
    '        End Using

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        e.Errore = True
    '    End Try

    'End Sub

    Private Sub e_CambiaStato() Handles e.CambiaStato
        RaiseEvent StatoImportazione(e)
    End Sub

    Private Sub Essig_Stato(e As ExportEventArgs) Handles Essig.Stato
        RaiseEvent StatoImportazione(e)
    End Sub

End Class
