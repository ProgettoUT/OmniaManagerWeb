Imports System.IO
Imports System.Data.OleDb
Imports System.Net
Imports System.Data
Imports Utx

Public Class Arretrati

    Public Event StatoImportazione(e As ExportEventArgs)
    Private Arretrati As DataTable

    Private WithEvents e As New ExportEventArgs
    Private WithEvents Essig As RichiesteEssig

    Private mCookie As CookieContainer
    Public Property Cookie() As CookieContainer
        Get
            Return mCookie
        End Get
        Set(value As CookieContainer)
            mCookie = value
        End Set
    End Property

    Public Property FigliaUnisalute() As Boolean

    Public Shared Function MdbIncassi(Agenzia As String) As String
        Return $"{Utx.Globale.Paths.CartellaModelliDatiAgenzia}\Incassi.mdb"
    End Function

    Friend Sub CatturaArretrati(InizioPeriodo As Date,
                                FinePeriodo As Date,
                                CodiceCorrente As Boolean)

        Globale.Log.Info($"Arretrati: utente {Environment.UserName}")

        Try
            Dim Config As New Utx.ConfigSede

            For Each Agenzia As String In Config.StringaAgenzieCollegate.Split("/")

                If (CodiceCorrente = False) OrElse (CodiceCorrente = True And Agenzia = Utx.Globale.AgenziaRichiesta.CodiceAgenzia) Then

                    Dim dt As DataTable = Utx.Globale.ProfiloEnteGestore.ConfigurazioneCodiciAttivi(Agenzia)
                    Arretrati = WsCommand.ExecuteNonQuery("SELECT * FROM Arretrati WHERE 1=0", Agenzia).DataTable
#If DEBUG Then
                    'Dim f As New Utx.FormDebug(dt)
                    'f.ShowDialog()
#End If
                    Essig = New RichiesteEssig(RichiesteEssig.TipoRichiesta.ARRETRATI, RichiesteEssig.TipoCompagnia.UNIPOL)

                    e.AgenziaMadre = Agenzia
                    e.AgenziaFiglia = Agenzia

                    Arretrati.Clear()

                    'controllo se c'è un codice unisalute e faccio login US
                    If Utx.Utente.ControlloUniSalute(dt) = False Then
                        MsgBox("Gli arretrati Unisalute NON saranno importati", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                    End If

                    'su ogni set di dati il record con agenzia attiva (non chiusa) è sempre solo uno. se sono due uno e di unisalute
                    For Each Figlia As DataRow In dt.Rows
                        Me.FigliaUnisalute = (Figlia("Unisalute") = "S")
                        e.Unisalute = Me.FigliaUnisalute

                        For Each SubAgenzia As String In Figlia("CodiciSub").ToString.Split("/")

                            Globale.Log.Info($"Agenzia {Figlia("Agenzia")} - Collegata {Figlia("Collegata")} - Sub {SubAgenzia}")
                            Globale.Log.AumentaRientro()

                            e.SubAgenzia = SubAgenzia

                            If e.Errore Then
                                Exit Try
                            End If

                            Dim Inizio As Date = InizioPeriodo
                            Dim Fine As Date

                            Do While Inizio <= FinePeriodo

                                'scarico file di 10 giorni per volta
                                Fine = Inizio.AddDays(10)
                                If Fine > FinePeriodo Then
                                    Fine = FinePeriodo
                                End If

                                Globale.Log.Info($"Importazione arretrati dal {Inizio:d} al {Fine:d}")
                                Globale.Log.AumentaRientro()

                                e.InizioPeriodo = Inizio
                                e.FinePeriodo = Fine
                                RaiseEvent StatoImportazione(e)

                                'catturo il file degli esitati in formato csv
                                Dim FileDati As String = ScaricaFileArretrati(Figlia("Collegata"), SubAgenzia, Inizio, Fine, "+")

                                Esitati.ControlloFileEsitati(FileDati, e)
                                If e.Errore = True Then
                                    Exit Try
                                End If

                                'importo i dati nel db
                                ImportaArretrati(FileDati)
                                If e.Errore Then
                                    Exit Do
                                End If

                                '+scarico solo i RID e li marco
                                FileDati = ScaricaFileArretrati(Figlia("Collegata"), SubAgenzia, Inizio, Fine, "S")
                                MarcaRid(FileDati)

                                Globale.Log.DiminuisciRientro()

                                'avanzo di un giorno rispetto alla fine del periodo precedente
                                Inizio = Fine.AddDays(1)
                            Loop

                            Globale.Log.DiminuisciRientro()
                        Next
                    Next
                    'interrogazione BDA
                    'AnalisiBDA()
                    'invio i dati al server
                    e.Messaggio = $"{Environment.NewLine}aggiorno database ({Arretrati.Rows.Count} record)..."
                    RaiseEvent StatoImportazione(e)

                    Arretrati.TableName = Utx.ServiziOMW.TipoEvento.AGGIORNA_ARRETRATI.ToString
                    Dim ds As New DataSet
                    ds.Tables.Add(Arretrati)
                    Utx.OmWeb.InviaDataSet(Agenzia, ds)
                End If
            Next

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

        If e.Errore Then
            Globale.Log.Info("Importazione con errori: {0}", {e.Messaggio})
        Else
            Globale.Log.Info("Importazione completata correttamente")
        End If

        Globale.Log.Info()
    End Sub

    Private Function ScaricaFileArretrati(Agenzia As String,
                                          CodiceSub As String,
                                          Inizio As Date,
                                          Fine As Date,
                                          RID As String) As String

        Try
            If Me.FigliaUnisalute Then
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
            Essig.RichiestaDati(Agenzia, CodiceSub, Inizio, Fine, RID)
            If Essig.EventArgs.Errore = True Then
                Return ""
            End If

            'esporto il file dati in formato csv
            Dim FileDati As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "Arretrati.csv")

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

    Private Sub ImportaArretrati(FileDati As String)
        Try
            'pulisco il file da eventuali null
            ClearFileFromNull(FileDati)

            'apro lo stream e leggo la prima riga con il nome dei campi
            Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)

                Dim Intestazione As String = sr.ReadLine()

                Dim Campi() As String

                Do While Not sr.EndOfStream

                    Campi = sr.ReadLine.Split(";")

                    'trimma tutto
                    TrimArray(Campi)

                    'se NON si tratta di un canone
                    If Campi(Tracciati.ESITATI.TipoMovimento).ToUpper.Contains("CANONE") = False Then
                        'normalizza campi
                        NormalizzaCampiEsitati(Campi)

                        Dim dr As DataRow = Arretrati.NewRow

                        dr("Agenzia") = Campi(Tracciati.ESITATI.Agenzia)
                        dr("Ramo") = Campi(Tracciati.ESITATI.Ramo)
                        dr("Polizza") = Campi(Tracciati.ESITATI.Polizza)
                        dr("EffettoAppendice") = Campi(Tracciati.ESITATI.EffettoApp)
                        dr("NumeroAppendice") = Campi(Tracciati.ESITATI.NumeroApp)
                        dr("EffettoTitolo") = Campi(Tracciati.ESITATI.EffettoTitolo)
                        dr("Frazionamento") = Campi(Tracciati.ESITATI.Fraz)
                        dr("TipoCarico") = Campi(Tracciati.ESITATI.TipoCarico)
                        dr("TipoMat") = Campi(Tracciati.ESITATI.TipoMat)
                        dr("CodiceFiscale") = Campi(Tracciati.ESITATI.CodiceFiscale)
                        dr("Cognome") = Campi(Tracciati.ESITATI.Contraente)
                        dr("Tassabile") = CDbl(Campi(Tracciati.ESITATI.Tassabile))
                        dr("TotaleTitolo") = CDbl(Campi(Tracciati.ESITATI.TotaleLordo))
                        dr("Prodotto") = Campi(Tracciati.ESITATI.Prodotto)
                        dr("TotalePolizza") = CDbl(Campi(Tracciati.ESITATI.TotaleLordo))
                        dr("Delegataria") = Campi(Tracciati.ESITATI.Delegataria)
                        dr("SubAgenzia") = Campi(Tracciati.ESITATI.SubAgenzia)
                        dr("Convenzione") = Campi(Tracciati.ESITATI.Convenzione)
                        dr("Targa") = Campi(Tracciati.ESITATI.Targa)
                        dr("RamoGestione") = Campi(Tracciati.ESITATI.RamoGestione)
                        dr("PrvAcq") = Campi(Tracciati.ESITATI.PrvAcq)
                        dr("PrvInc") = Campi(Tracciati.ESITATI.PrvInc)
                        dr("Incassabile") = CBool("True")
                        dr("PremioRC") = Campi(Tracciati.ESITATI.PremioRC)
                        dr("PrIF") = Campi(Tracciati.ESITATI.PrIF)
                        dr("PrINF") = Campi(Tracciati.ESITATI.PrINF)
                        dr("PrKasko") = Campi(Tracciati.ESITATI.PrKasko)
                        dr("PrAssistenza") = Campi(Tracciati.ESITATI.PrAssistenza)
                        'dal 29/08/2019
                        dr("EffettoPolizza") = Campi(Tracciati.ESITATI.EffettoPolizza)
                        dr("ScadenzaPolizza") = Campi(Tracciati.ESITATI.ScadenzaPolizza)
                        dr("RataIntermedia") = Campi(Tracciati.ESITATI.RataIntermedia)
                        dr("CodiceProduttore") = Campi(Tracciati.ESITATI.Produttore)
                        If IsDate(Campi(Tracciati.ESITATI.Vincolo)) AndAlso CDate(Campi(Tracciati.ESITATI.Vincolo)) > #1/1/2000# Then
                            dr("ScadenzaVincolo") = Campi(Tracciati.ESITATI.Vincolo)
                        Else
                            dr("ScadenzaVincolo") = DBNull.Value
                        End If

                        For Each campo As String In "EffettoAppendice;EffettoTitolo;EffettoPolizza;ScadenzaPolizza;ScadenzaVincolo".Split(";")
                            If IsDBNull(dr(campo)) = False AndAlso dr(campo) < #1/1/1900# Then
                                dr(campo) = #1/1/1900#
                            End If
                        Next
                        Arretrati.Rows.Add(dr)
                    Else
                        Arretrati.Rows(Arretrati.Rows.Count - 1).Item("Unibox") = CDbl(Campi(Tracciati.ESITATI.TotaleLordo))
                        Arretrati.Rows(Arretrati.Rows.Count - 1).Item("TotaleTitolo") += Arretrati.Rows(Arretrati.Rows.Count - 1).Item("Unibox")
                    End If
                Loop
            End Using

            Globale.Log.Info($"record importati: {Arretrati.Rows.Count}")

            File.Delete(FileDati)

        Catch ex As Exception
            e.Messaggio = ex.Message
            e.Errore = True
        End Try
    End Sub

    Private Sub e_CambiaStato() Handles e.CambiaStato
        RaiseEvent StatoImportazione(e)
    End Sub

    Private Sub Essig_Stato(e As ExportEventArgs) Handles Essig.Stato
        RaiseEvent StatoImportazione(e)
    End Sub

    Private Sub MarcaRid(FileDati As String)
        Try
            'pulisco il file da eventuali null
            ClearFileFromNull(FileDati)

            'apro lo stream e leggo la prima riga con il nome dei campi
            Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)
                'intestazione
                sr.ReadLine()

                Do While Not sr.EndOfStream
                    Dim Campi() As String = sr.ReadLine.Split(";")

                    'trimma tutto
                    TrimArray(Campi)

                    'se NON si tratta di un canone
                    If Campi(Tracciati.ESITATI.TipoMovimento).ToUpper.Contains("CANONE") = False Then
                        'normalizza campi
                        NormalizzaCampiEsitati(Campi)

                        For Each row In Arretrati.Select($"Ramo = {Campi(Tracciati.ESITATI.Ramo)} 
                                                        AND Polizza = {Campi(Tracciati.ESITATI.Polizza)} 
                                                        AND EffettoTitolo = #{CDate(Campi(Tracciati.ESITATI.EffettoTitolo)):MM/dd/yyyy}#")
                            row("RID") = "S"
                        Next
                    End If
                Loop
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
            e.Errore = True
        End Try
    End Sub
End Class
