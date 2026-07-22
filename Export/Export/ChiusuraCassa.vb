Imports System.IO
Imports System.Net
Imports System.Data

Public Class ChiusuraCassa

    Public Event StatoImportazione(e As ExportEventArgs)

    Private ReadOnly e As New ExportEventArgs
    Private ReadOnly Log As New Utx.ApplicationLog("Export.Cassa.log")
    Private WithEvents Essig As RichiesteEssig
    Private DatiChiusura As DataTable

    Public Sub New()
    End Sub

    Friend Sub CatturaCassa(InizioPeriodo As Date,
                            FinePeriodo As Date,
                            CodiciSub As String)
        Try
            Log.Info(String.Format("Chiusura cassa: utente {0}", Environment.UserName))

            DatiChiusura = Utx.WsCommand.ExecuteNonQuery("SELECT * FROM ChiusuraCassa WHERE 1=0").DataTable

            Essig = New RichiesteEssig(RichiesteEssig.TipoRichiesta.CHIUSURA_CASSA, RichiesteEssig.TipoCompagnia.UNIPOL)

            e.AgenziaMadre = Utx.Globale.AgenziaRichiesta.CodiceAgenzia

            If e.Errore = True Then Exit Try

            'controllo se c'è un codice unisalute e faccio login US
            If Utx.Utente.ControlloUniSalute(Utx.Globale.ProfiloEnteGestore.ConfigurazioneServer) = False Then
                Exit Sub
            End If

            For Each row As DataRow In Utx.Globale.ProfiloEnteGestore.ConfigurazioneServer.Rows
                If row("DataFine") > InizioPeriodo Then
                    'per ogni codice sub
                    For Each SubAgenzia As String In CodiciSub.Split("/")

                        Log.Info($"Importazione codice {row("Collegata")} sub {SubAgenzia}")

                        e.SubAgenzia = SubAgenzia

                        Dim Giorno As Date = InizioPeriodo

                        Do While Giorno <= FinePeriodo

                            Log.Info($"Importazione del giorno {Giorno:dd/MM/yyyy}")

                            e.InizioPeriodo = Giorno
                            e.FinePeriodo = Giorno
                            RaiseEvent StatoImportazione(e)

                            'catturo il file degli esitati in formato csv
                            Dim FileDati As String = ScaricaFileCassa(row("Collegata"), Giorno, SubAgenzia, row("Unisalute") = "S")
                            If e.Errore = True Then Exit For

                            'importo i dati nel db
                            ImportaChiusuraCassa(Giorno, FileDati)
                            If e.Errore = True Then Exit For

                            'avanzo di un giorno
                            Giorno = Giorno.AddDays(1)
                        Loop
                    Next
                End If
            Next

            DatiChiusura.TableName = Utx.ServiziOMW.TipoEvento.AGGIORNA_CHIUSURA_CASSA.ToString
            Dim ds As New DataSet
            ds.Tables.Add(DatiChiusura)
            'invio i dati al server
            Utx.OmWeb.InviaDataSet(e.AgenziaMadre, ds)

        Catch ex As Exception
            Log.Errore(ex)
            e.Messaggio = ex.Message
            e.Errore = True
        End Try

        'ConcludiImportazione()
    End Sub

    Private Function ScaricaFileCassa(CodiceAgenzia As String, Giorno As Date, CodiceSub As String, Unisalute As Boolean) As String
        Try
            If Unisalute Then
                Essig.Compagnia = RichiesteEssig.TipoCompagnia.UNISALUTE
                Essig.CreaLink()
            Else
                Essig.Compagnia = RichiesteEssig.TipoCompagnia.UNIPOL
                Essig.CreaLink()
            End If

            'chiamo il menù: necessario per settaggio parametri
            Essig.ChiamaMenu()
            If Essig.EventArgs.Errore = True Then
                Return ""
            End If

            'richiedo i dati
            Essig.RichiestaDati(CodiceAgenzia, CodiceSub, Giorno, Giorno)
            If Essig.EventArgs.Errore = True Then
                Return ""
            End If

            'esporto il file dati in formato csv
            Dim FileDati As String = $"{Utx.Globale.Paths.CartellaTempUtente}\{Giorno:yyyyMMdd}.csv"
            If Essig.EventArgs.Errore = True Then
                Return ""
            End If

            'salvo il file
            Using sw As New StreamWriter(FileDati)
                sw.Write(Essig.EsportaDati)
            End Using

            Return FileDati

        Catch ex As Exception
            Log.Errore(ex)
            e.Messaggio = ex.Message
            e.Errore = True
            Return ""
        End Try
    End Function

    Private Sub ImportaChiusuraCassa(Giorno As Date, FileDati As String)
        Try
            'pulisco il file da eventuali null
            ClearFileFromNull(FileDati)

            'apro lo stream
            Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)
                'leggo la prima riga con il nome dei campi
                sr.ReadLine()

                Dim Campi() As String

                Do While Not sr.EndOfStream

                    Campi = sr.ReadLine.Split(";")

                    'trimma tutto
                    TrimArray(Campi)

                    'in caso di canoni unibox ecc. prende i valori cercando la polizza per rg <> 0
                    'sempre nel file csv. Nota che la polizza potrebbe essere successiva e quindi
                    'non ancora inserita nel recordset
                    If Campi(Tracciati.ESITATI.RamoGestione) = 0 Then ParametriPolizzaEsitata(FileDati, Campi)

                    'normalizza campi
                    NormalizzaCampiEsitati(Campi)

                    Dim dr As DataRow = DatiChiusura.NewRow

                    dr("Tipo") = Campi(Tracciati.ESITATI.Tipo)
                    dr("TipoRecord") = 0
                    dr("Ramo") = Campi(Tracciati.ESITATI.Ramo)
                    dr("Polizza") = Campi(Tracciati.ESITATI.Polizza)
                    dr("EffettoPolizza") = Campi(Tracciati.ESITATI.EffettoPolizza)
                    dr("EffettoTitolo") = Campi(Tracciati.ESITATI.EffettoTitolo)
                    dr("TipoCarico") = Campi(Tracciati.ESITATI.TipoCarico)
                    dr("Esito") = Campi(Tracciati.ESITATI.TipoEsito)
                    dr("DataEsito") = Campi(Tracciati.ESITATI.DataEsito)
                    dr("CodiceCassa") = Campi(Tracciati.ESITATI.CodiceCassa)

                    If dr("CodiceCassa") = "ERID" Then
                        'se il codice cassa negli esitati è vuoto
                        If (dr("TipoPagamento") Is DBNull.Value) OrElse String.IsNullOrEmpty(dr("TipoPagamento")) Then
                            dr("TipoPagamento") = "D"
                        End If
                    Else
                        dr("TipoPagamento") = Campi(Tracciati.ESITATI.TipoPagamento)
                    End If

                    dr("Contraente") = Campi(Tracciati.ESITATI.Contraente)
                    dr("TotaleTitolo") = CDbl(Campi(Tracciati.ESITATI.TotaleLordo))
                    dr("SubAgenzia") = Campi(Tracciati.ESITATI.SubAgenzia)
                    dr("TipoMovimento") = Campi(Tracciati.ESITATI.TipoMovimento)
                    dr("Rientro") = "N"
                    dr("Sezione") = ""
                    dr("Segno") = ""
                    dr("Spunta") = "N"
                    dr("ImportoIncassato") = Campi(Tracciati.ESITATI.ImportoIncassato)

                    'annotazione rientri da co/sc
                    'se il rientro IC/IS avviene nello stesso giorno il dato non è ancora nel db ma nella dt
                    If dr("Esito").ToString.Trim = "IC" Then

                        If dr("DataEsito") = Giorno Then
                            AnnotazioneRientroNelGiorno(DatiChiusura, dr, "CO")
                        Else
                            AnnotazioneRientro(DatiChiusura, dr, "CO")
                        End If

                    ElseIf dr("Esito").ToString.Trim = "IS" Then

                        If dr("DataEsito") = Giorno Then
                            AnnotazioneRientroNelGiorno(DatiChiusura, dr, "SC")
                        Else
                            AnnotazioneRientro(DatiChiusura, dr, "SC")
                        End If
                    End If

                    'aggiungo il record alla tabella
                    DatiChiusura.Rows.Add(dr)
                Loop
            End Using
            File.Delete(FileDati)

        Catch ex As Exception
            Log.Errore(ex)
            e.Messaggio = ex.Message
            e.Errore = True
        End Try
    End Sub

    Private Sub ParametriPolizzaEsitata(FileDati As String,
                                        ByRef Campi() As String)
        Try
            'leggo il csv come un File di testo
            'apro lo stream e leggo la prima riga con il nome dei campi
            Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)
                sr.ReadLine()

                Dim Riga() As String

                Do While Not sr.EndOfStream
                    'estrae dal file solo i caratteri stampabili poichè spesso ci sono porcherie tipo chr(0)
                    Riga = sr.ReadLine.Split(";")

                    'trimma tutto
                    TrimArray(Riga)

                    'cerca la polizza passata con ramo gestione diverso da 0 per recuperare i dati
                    'che sulle righe con rg=0 (canone unibox ecc.) possono non essere corretti
                    If Riga(Tracciati.ESITATI.Ramo) = Campi(Tracciati.ESITATI.Ramo) AndAlso
                       Riga(Tracciati.ESITATI.Polizza) = Campi(Tracciati.ESITATI.Polizza) AndAlso
                       Riga(Tracciati.ESITATI.EffettoTitolo) = Campi(Tracciati.ESITATI.EffettoTitolo) AndAlso
                       Riga(Tracciati.ESITATI.RamoGestione) > 0 Then

                        'aggiusto i valori in campi passato per riferimento
                        Campi(Tracciati.ESITATI.TipoCarico) = Riga(Tracciati.ESITATI.TipoCarico)
                        If Campi(Tracciati.ESITATI.EffettoPolizza) < #1/1/1900# Then
                            Campi(Tracciati.ESITATI.EffettoPolizza) = Riga(Tracciati.ESITATI.EffettoPolizza)
                        End If
                        If Campi(Tracciati.ESITATI.EffettoTitolo) < #1/1/1900# Then
                            Campi(Tracciati.ESITATI.EffettoTitolo) = Riga(Tracciati.ESITATI.EffettoTitolo)
                        End If
                        Campi(Tracciati.ESITATI.CodiceCassa) = Riga(Tracciati.ESITATI.CodiceCassa)
                        If String.IsNullOrEmpty(Campi(Tracciati.ESITATI.Contraente)) Then
                            Campi(Tracciati.ESITATI.Contraente) = Riga(Tracciati.ESITATI.Contraente)
                        End If
                        If String.IsNullOrEmpty(Campi(Tracciati.ESITATI.SubAgenzia)) OrElse Campi(Tracciati.ESITATI.SubAgenzia) = 0 Then
                            Campi(Tracciati.ESITATI.SubAgenzia) = Riga(Tracciati.ESITATI.SubAgenzia)
                        End If

                        Exit Do
                    End If
                Loop
            End Using

        Catch ex As Exception
            Log.Errore(ex)
            e.Messaggio = ex.Message
            e.Errore = True
        End Try
    End Sub

    Private Sub AnnotazioneRientro(ByRef dt As DataTable,
                                   dr As DataRow,
                                   TipoScoperto As String)

        Try
            'annoto il rientro del CO/SC
            Dim Query As String = String.Format("UPDATE ChiusuraCassa 
                SET Rientro = 'S' 
                WHERE Ramo = {0} AND Polizza = {1} AND EffettoTitolo = '{2:dd/MM/yyyy}' AND Esito = '{3}' AND TotaleTitolo = {4}",
                    dr("Ramo"), dr("Polizza"), dr("EffettoTitolo"), TipoScoperto, dr("TotaleTitolo"))
            Utx.WsCommand.ExecuteNonQueryRecord(Query)

            'metto l'incasso in uscita dal CO/SC marcandolo come tipo record 99. Li metto a 99
            'perchè sugli altri tipi vanno poi fatte delle operazioni da cui i 99 sono esclusi
            Dim drIC As DataRow = dt.NewRow

            'copio il datarow precedente
            For Each col As DataColumn In dt.Columns
                drIC(col.ColumnName) = dr(col.ColumnName)
            Next

            'e modifico i campi
            drIC("TipoRecord") = 99
            drIC("Sezione") = TipoScoperto
            drIC("TotaleTitolo") = -drIC("TotaleTitolo")
            drIC("ImportoIncassato") = -drIC("ImportoIncassato")
            drIC("Segno") = "U"
            dt.Rows.Add(drIC)

        Catch ex As Exception
            Log.Errore(ex)
            e.Messaggio = ex.Message
            e.Errore = True
        End Try
    End Sub

    Private Sub AnnotazioneRientroNelGiorno(ByRef dt As DataTable,
                                            dr As DataRow,
                                            TipoScoperto As String)
        Try
            For Each r As DataRow In dt.Rows

                If r("Ramo") = dr("Ramo") AndAlso r("Polizza") = dr("Polizza") Then

                    If r("EffettoTitolo") = dr("EffettoTitolo") AndAlso
                       r("Esito") = TipoScoperto AndAlso
                       r("TotaleTitolo") = dr("TotaleTitolo") Then

                        r("Rientro") = "S"

                    End If
                End If
            Next

            'metto l'incasso in uscita dal CO/SC marcandolo come tipo record 99. Li metto a 99
            'perchè sugli altri tipi vanno poi fatte delle operazioni da cui i 99 sono esclusi
            Dim drIC As DataRow = dt.NewRow

            'copio il datarow precedente
            For Each col As DataColumn In dt.Columns
                drIC(col.ColumnName) = dr(col.ColumnName)
            Next

            'e modifico i campi
            drIC("TipoRecord") = 99
            drIC("Sezione") = TipoScoperto
            drIC("TotaleTitolo") = -drIC("TotaleTitolo")
            drIC("ImportoIncassato") = -drIC("ImportoIncassato")
            drIC("Segno") = "U"

            dt.Rows.Add(drIC)

        Catch ex As Exception
            Log.Errore(ex)
            e.Messaggio = ex.Message
            e.Errore = True
        End Try

    End Sub
End Class
