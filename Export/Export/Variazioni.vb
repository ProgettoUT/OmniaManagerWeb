Imports System.IO
Imports System.Data.OleDb
Imports System.Net
Imports System.Data

Public Class Variazioni

    Public Event StatoImportazione(e As ExportEventArgs)

    Public OpzioniScarico As ExportLib.ConfigScaricoIncassi

    Private WithEvents e As New ExportEventArgs
    Private WithEvents Essig As RichiesteEssig

    Public Sub AggiornaVariazioni()

        Globale.Log.Info(String.Format("Variate/Sostituite: utente {0}", Environment.UserName))
        Globale.Log.Info(String.Format("Agenzia capofila: {0}-{1}", OpzioniScarico.AgenziaPrincipale, OpzioniScarico.Sede))
        Globale.Log.Info(String.Format("Agenzie da scaricare: {0}", OpzioniScarico.CodiciDaScaricare))
        Globale.Log.AumentaRientro()

        Try
            Essig = New RichiesteEssig(RichiesteEssig.TipoRichiesta.VARIAZIONI)

            For Each AgenziaMadre As String In OpzioniScarico.CodiciDaScaricare.Split("/")

                e.AgenziaMadre = AgenziaMadre

                'trovo tutte le righe che configurano la collegata nella tabella config
                Dim dt As DataTable = OpzioniScarico.Config.ConfigAgenzia(OpzioniScarico.Compagnia,
                                                                          AgenziaMadre,
                                                                          OpzioniScarico.Sede)


                For Each Figlia As DataRow In dt.Rows
                    Dim Variazioni As DataTable = Utx.WsCommand.ExecuteNonQuery("SELECT * FROM PolizzeSostituite WHERE 1=0", e.AgenziaMadre).DataTable

                    'se madre e figlia coincidono
                    If Figlia("Agenzia") = Figlia("Collegata") Then

                        For Each SubAgenzia As String In Figlia("CodiciSub").ToString.Split("/")

                            Globale.Log.Info(String.Format("Agenzia {0} - Collegata {1} - Sub {2}", Figlia("Agenzia"), Figlia("Collegata"), SubAgenzia))
                            Globale.Log.AumentaRientro()

                            e.SubAgenzia = SubAgenzia

                            If e.Errore Then Exit Try

                            Dim Inizio As Date = InizioPeriodo()
                            Dim Fine As Date

                            Do While Inizio <= Today

                                'scarico file di 30 giorni per volta
                                Fine = Inizio.AddDays(30)
                                If Fine > Today Then Fine = Today

                                Globale.Log.Info(String.Format("Importazione variate/sostituite dal {0} al {1}", Inizio.ToShortDateString, Fine.ToShortDateString))
                                Globale.Log.AumentaRientro()

                                e.InizioPeriodo = Inizio
                                e.FinePeriodo = Fine
                                RaiseEvent StatoImportazione(e)

                                'catturo il file degli esitati in formato csv
                                Dim FileDati As String = ScaricaFileVariazioni(e.AgenziaMadre, e.SubAgenzia,
                                                                               Inizio, Fine)

                                Esitati.ControlloFileEsitati(FileDati, e)
                                If e.Errore = True Then
                                    Exit Try
                                End If

                                'importo i dati nel db
                                ImportaVariazioni(FileDati, Variazioni)

                                If e.Errore Then Exit Do

                                Globale.Log.DiminuisciRientro()

                                'avanzo di un giorno rispetto alla fine del periodo precedente
                                Inizio = Fine.AddDays(1)
                            Loop

                            Globale.Log.DiminuisciRientro()
                        Next
                        'invio al server
                        Variazioni.TableName = Utx.ServiziOMW.TipoEvento.AGGIORNA_VARIAZIONI.ToString
                        Dim ds As New DataSet
                        ds.Tables.Add(Variazioni)
                        'invio i dati al server
                        Utx.OmWeb.InviaDataSet(e.AgenziaMadre, ds, AttendiFine:=True)
                    End If
                Next
            Next

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

        If e.Errore Then
            Globale.Log.Info("Importazione con errori")
        Else
            Globale.Log.Info("Importazione variazioni/sostituzioni completata correttamente")
        End If

        Globale.Log.DiminuisciRientro()
        Globale.Log.Info()
    End Sub

    Private Function ScaricaFileVariazioni(Agenzia As String,
                                           CodiceSub As String,
                                           Inizio As Date,
                                           Fine As Date) As String

        Try
            'chiamo il menù: necessario per settaggio parametri
            Essig.ChiamaMenu()
            If Essig.EventArgs.Errore = True Then
                Return ""
            End If

            'richiedo i dati
            Essig.RichiestaDati(Agenzia, CodiceSub, Inizio, Fine)
            If Essig.EventArgs.Errore = True Then
                Return ""
            End If

            'esporto il file dati in formato csv
            Dim FileDati As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "Variazioni.csv")

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

    Private Sub ImportaVariazioni(FileDati As String, dt As DataTable)
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

                    'normalizza campi
                    NormalizzaCampiEsitati(Campi)

                    Dim dr As DataRow = dt.NewRow

                    dr("Ramo") = Campi(Tracciati.ESITATI.Ramo)
                    dr("Polizza") = Campi(Tracciati.ESITATI.Polizza)
                    dr("TipoVar") = Campi(Tracciati.ESITATI.TipoEsito)
                    dr("DataVar") = Campi(Tracciati.ESITATI.DataEsito)
                    dr("ScadenzaPolizza") = Campi(Tracciati.ESITATI.ScadenzaPolizza)

                    dt.Rows.Add(dr)
                Loop
            End Using

            File.Delete(FileDati)

        Catch ex As Exception
            MsgBox(ex.Message)
            e.Errore = True
        End Try
    End Sub

    Private Function InizioPeriodo() As Date
        Try
            Dim Query As String = "DECLARE @maxdata AS DATETIME = (SELECT MAX(DataVar) FROM PolizzeSostituite)
                If ISDATE(@maxdata) = CAST(1 as bit)
                    --inizio dalla maxdate
                    SELECT CAST(@maxdata AS DATE)
                ELSE
                    --inizio dal 1 gennaio dell'anno corrente
                    SELECT '01/01/' + TRIM(STR(YEAR(GETDATE())))"
            Return Utx.WsCommand.ExecuteScalar(Query).Valore
        Catch ex As Exception
            Globale.Log.Errore(ex)
            e.Errore = True
            Return New DateTime(Today.Year - 1, 1, 1)
        End Try
    End Function

    Private Sub e_CambiaStato() Handles e.CambiaStato
        RaiseEvent StatoImportazione(e)
    End Sub

    Private Sub Essig_Stato(e As ExportEventArgs) Handles Essig.Stato
        RaiseEvent StatoImportazione(e)
    End Sub
End Class
