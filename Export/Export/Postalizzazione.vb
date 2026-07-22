Imports System.IO
Imports System.Net
Imports System.Data

Public Class Postalizzazione

    Public Event StatoImportazione(e As ExportEventArgs)

    Private WithEvents e As New ExportEventArgs
    Private WithEvents Essig As RichiesteEssig

    Public Property FigliaUnisalute() As Boolean

    Private mCookie As CookieContainer
    Public Property Cookie() As CookieContainer
        Get
            Return mCookie
        End Get
        Set(value As CookieContainer)
            mCookie = value
        End Set
    End Property

    Private mAgenzia As String
    Public Property Agenzia() As String
        Get
            Return mAgenzia
        End Get
        Set(value As String)
            mAgenzia = value
        End Set
    End Property

    Public Function CatturaArretrati(Inizio As Date, Fine As Date) As Boolean
        Try
            UniCom.FormPostalizzazione.MigrazioneSetting()

            Essig = New RichiesteEssig(RichiesteEssig.TipoRichiesta.ARRETRATI, RichiesteEssig.TipoCompagnia.UNIPOL)

            Globale.Log.Info("Postalizzazione agenzia {0}", {Agenzia})
            Globale.Log.AumentaRientro()

            Dim dt As DataTable = Utx.Globale.ProfiloEnteGestore.ConfigurazioneCodiciAttivi(Agenzia)

            'controllo se c'è un codice unisalute e faccio login US
            If Utx.Utente.ControlloUniSalute(dt) = False Then
                If MsgBox(String.Format("Errore login UniSalute.{0}Gli avvisi UniSalute non verranno inviati.{0}Continuare con l'invio dei SOLI AVVISI UNIPOLSAI?", Environment.NewLine),
                          MsgBoxStyle.Question + MsgBoxStyle.YesNo, Utx.Globale.TitoloApp) = MsgBoxResult.No Then

                    e.Errore = True
                    e.Messaggio = "Errore login UniSalute. Avvisi non inviati."
                    Exit Try
                End If
            End If

            'scarico file di un mese
            Globale.Log.Info(String.Format("Importazione arretrati dal {0:d} al {1:d}", Inizio, Fine))
            Globale.Log.AumentaRientro()

            Dim Arretrati As DataTable = Utx.WsCommand.ExecuteNonQuery("SELECT * FROM Postalizzazione WHERE 1=0", mAgenzia).DataTable

            Dim InvioRid As Boolean = False

            Dim Chiave As New Utx.SettingItem(Utx.SettingItem.Sezioni.COMUNICATORE, Utx.SettingItem.Chiavi.COMUNICATORE_RID,
                                              Utx.SettingOMW.TipoOperazione.LETTURA)

            InvioRid = Chiave.ItemResult.Valore = "S"

            For Each Figlia As DataRow In dt.Rows
                Me.Agenzia = Figlia("Collegata")
                Me.FigliaUnisalute = (Figlia("Unisalute") = "S")
                e.Unisalute = Me.FigliaUnisalute

                e.AgenziaMadre = Figlia("Agenzia")
                e.InizioPeriodo = Inizio
                e.FinePeriodo = Fine
                e.Messaggio = "Aggiorno avvisi di scadenza..."
                RaiseEvent StatoImportazione(e)

                'spezzetto in periodi
                Dim GiorniPeriodo As Integer = 6 'giorni
                Dim InizioPeriodo As Date = Inizio
                Dim FinePeriodo As Date = Utx.FunzioniData.MinDate(InizioPeriodo.AddDays(GiorniPeriodo), Fine)

                Do While InizioPeriodo <= Fine
                    '+catturo il file degli esitati in formato csv (compresi i rid)
                    e.Messaggio = String.Format("scarico i dati al {0:dd-MM-yyy}", FinePeriodo)

#If DEBUG Then
                    'per forzature
                    'Dim FileDati As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "1938.csv")
                    '---------------------------------------------------------------------------------------
                    Dim FileDati As String = ScaricaFileArretrati(Me.Agenzia, InizioPeriodo, FinePeriodo, "+")
#Else
                Dim FileDati As String = ScaricaFileArretrati(Me.Agenzia, InizioPeriodo, FinePeriodo, "+")
#End If
                    Esitati.ControlloFileEsitati(FileDati, e)
                    If e.Errore = True Then
                        Exit Try
                    End If

                    '+importo i dati nel datatable
                    ImportaArretrati(FileDati, Arretrati)
                    If e.Errore Then
                        Exit Try
                    End If

                    e.Messaggio = String.Format("controllo RID al {0:dd-MM-yyy}", FinePeriodo)

                    '+scarico solo i RID e li marco
                    FileDati = ScaricaFileArretrati(Me.Agenzia, InizioPeriodo, FinePeriodo, "S")
                    MarcaRid(FileDati, Arretrati, InvioRid)
                    'avanzo dei giorni del periodo
                    InizioPeriodo = FinePeriodo.AddDays(1)
                    FinePeriodo = Utx.FunzioniData.MinDate(InizioPeriodo.AddDays(GiorniPeriodo), Fine)
                Loop
            Next
            e.Unisalute = False
            e.Messaggio = "Salvo i dati..."
            RaiseEvent StatoImportazione(e)

#If DEBUG Then
            'Dim f As New Utx.FormDebug(Arretrati)
            'f.ShowDialog()
#End If
            'invio al server - il calcolo quota e un eventuale ripristino da backup sono gestiti sul SERVER
            Arretrati.TableName = Utx.ServiziOMW.TipoEvento.AGGIORNA_POSTALIZZAZIONE.ToString
            Dim ds As New DataSet
            ds.Tables.Add(Arretrati)
            'invio i dati al server
            Utx.OmWeb.InviaDataSet(e.AgenziaMadre, ds, AttendiFine:=True)

            Globale.Log.DiminuisciRientro()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Globale.Log.Rientro = 0
        End Try

        If e.Errore = True Then
            Globale.Log.Info("Importazione titoli postalizzazione completata con errori. Ripristinati i dati precedenti lo scarico.")
            Return False
        Else
            Globale.Log.Info("Importazione titoli postalizzazione completata correttamente")
            Return True
        End If
    End Function

    Private Function ScaricaFileArretrati(Agenzia As String,
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
            Essig.RichiestaDati(Agenzia, "", Inizio, Fine, RID)
            If Essig.EventArgs.Errore = True Then
                Return ""
            End If

            'esporto il file dati in formato csv
            Dim FileDati As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "Postalizzazione.csv")

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

    Private Sub ImportaArretrati(FileDati As String, ByRef dt As DataTable)
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

                        Dim dr As DataRow = dt.NewRow

                        dr("Selezionato") = True
                        dr("Tipo") = Campi(Tracciati.ESITATI.Tipo)
                        dr("Agenzia") = e.AgenziaMadre 'codici di agenzia diversi (tipo unisalute) creano problemi a KOINÈ nell'invio
                        dr("Ramo") = Campi(Tracciati.ESITATI.Ramo)
                        dr("Polizza") = Campi(Tracciati.ESITATI.Polizza)
                        dr("EffettoTitolo") = Campi(Tracciati.ESITATI.EffettoTitolo)
                        dr("ScadenzaPolizza") = Campi(Tracciati.ESITATI.ScadenzaPolizza)
                        dr("TipoCarico") = Campi(Tracciati.ESITATI.TipoCarico)
                        dr("CodiceFiscale") = Campi(Tracciati.ESITATI.CodiceFiscale)
                        dr("Contraente") = Campi(Tracciati.ESITATI.Contraente)
                        dr("SubAgenzia") = Campi(Tracciati.ESITATI.SubAgenzia)
                        dr("Convenzione") = Campi(Tracciati.ESITATI.Convenzione)
                        dr("RamoGestione") = Campi(Tracciati.ESITATI.RamoGestione)
                        dr("Prodotto") = Campi(Tracciati.ESITATI.Prodotto).Trim.PadLeft(5, "0")
                        dr("Targa") = Campi(Tracciati.ESITATI.Targa)
                        dr("Frazionamento") = Campi(Tracciati.ESITATI.Fraz)
                        dr("RataIntermedia") = Campi(Tracciati.ESITATI.RataIntermedia)
                        dr("RID") = "N"
                        dr("Delegataria") = Campi(Tracciati.ESITATI.Delegataria)
                        dr("Quota") = 0
                        'polizza in quota con delega nostra
                        If dr("Delegataria") > 0 Then
                            dr("Selezionato") = False 'deve essere esplicitamente l'utente a decidere di mandare l'avviso
                            dr("TotaleTitolo") = 0
                            dr("ImportoQuota") = CDbl(Campi(Tracciati.ESITATI.TotaleLordo))
                        Else
                            dr("TotaleTitolo") = CDbl(Campi(Tracciati.ESITATI.TotaleLordo))
                        End If
                        'rami defleggati
                        If dr("Ramo") = 110 OrElse dr("Ramo") = 118 OrElse dr("Ramo") = 126 OrElse dr("Ramo") = 315 Then
                            dr("Selezionato") = False 'deve essere esplicitamente l'utente a decidere di mandare l'avviso
                        End If
                        'p.iva
                        If IsNumeric(Campi(Tracciati.ESITATI.CodiceFiscale)) Then
                            dr("Sesso") = "N"
                        ElseIf Campi(Tracciati.ESITATI.CodiceFiscale).Length < 16 Then
                            'serve per le società estere (vedi san marino)
                            dr("Sesso") = "N"
                        Else
                            If Mid(Campi(Tracciati.ESITATI.CodiceFiscale), 10, 2) < 40 Then
                                dr("Sesso") = "M"
                            Else
                                dr("Sesso") = "F"
                            End If
                        End If

                        For Each campo As String In "EffettoTitolo;ScadenzaPolizza".Split(";")
                            If IsDBNull(dr(campo)) = False AndAlso dr(campo) < #1/1/1900# Then
                                dr(campo) = #1/1/1900#
                            End If
                        Next
                        dr("SenzaPremio") = (dr("Ramo") = 30 AndAlso dr("RataIntermedia") = "N" AndAlso dr("Frazionamento") = 9)

                        dt.Rows.Add(dr)
                    End If

                    e.Messaggio = String.Format("aggiorno avvisi di scadenza...{0}", dt.Rows.Count)
                Loop
            End Using
            SommaCanoniUnibox(FileDati, dt)

        Catch ex As Exception
            Globale.Log.Errore(ex)
            e.Errore = True
        End Try
    End Sub

    Private Sub MarcaRid(FileDati As String, ByRef dt As DataTable, InvioRid As Boolean)
        Try
            'pulisco il file da eventuali null
            ClearFileFromNull(FileDati)

            'apro lo stream e leggo la prima riga con il nome dei campi
            Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)

                Dim Intestazione As String = sr.ReadLine()

                Dim Campi() As String
                Dim QueryUp As String = ""

                Do While Not sr.EndOfStream
                    'leggo una polizza con RID
                    Campi = sr.ReadLine.Split(";")

                    'trimma tutto
                    TrimArray(Campi)

                    'se NON si tratta di un canone
                    If Campi(Tracciati.ESITATI.TipoMovimento).ToUpper.Contains("CANONE") = False Then
                        'normalizza campi
                        NormalizzaCampiEsitati(Campi)

                        For Each dr As DataRow In dt.Rows
                            'trovo la polizza nella data table
                            If dr("Ramo") = Campi(Tracciati.ESITATI.Ramo) AndAlso
                                dr("Polizza") = Campi(Tracciati.ESITATI.Polizza) AndAlso
                                dr("EffettoTitolo") = Campi(Tracciati.ESITATI.EffettoTitolo) Then

                                'imposto i campi
                                dr("RID") = "S"
                                dr("Selezionato") = InvioRid OrElse (dr("Ramo") = 30 AndAlso dr("RataIntermedia") = "N" AndAlso dr("Frazionamento") = 9)
                                Exit For
                            End If
                        Next
                    End If
                Loop
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
            e.Errore = True
        End Try
    End Sub

    Private Sub SommaCanoniUnibox(FileDati As String, ByRef dt As DataTable)
        Try
            Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)
                sr.ReadLine() 'intestazione

                Dim Riga() As String

                Do While Not sr.EndOfStream
                    'estrae dal file solo i caratteri stampabili poichè spesso ci sono porcherie tipo chr(0)
                    Riga = sr.ReadLine.Split(";")
                    'trimma tutto
                    TrimArray(Riga)

                    'se si tratta di un canone
                    If Riga(Tracciati.ESITATI.TipoMovimento).ToUpper.Contains("CANONE") Then
                        For Each dr As DataRow In dt.Rows
                            If dr("Ramo") = Riga(Tracciati.ESITATI.Ramo) AndAlso
                                dr("Polizza") = Riga(Tracciati.ESITATI.Polizza) AndAlso
                                dr("EffettoTitolo") = Riga(Tracciati.ESITATI.EffettoTitolo) Then

                                dr("TotaleTitolo") += CDbl(Riga(Tracciati.ESITATI.TotaleLordo))
                                Exit For
                            End If
                        Next
                    End If
                Loop
            End Using

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
End Class
