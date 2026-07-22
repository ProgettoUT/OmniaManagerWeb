Imports System.IO
Imports System.Net
Imports System.Data.OleDb
Imports System.Data
Imports Utx
'Imports System.Data.SqlClient

Public Class Incassi

    Public Event StatoImportazione(e As ExportEventArgs)

    Public OpzioniScarico As ExportLib.ConfigScaricoIncassi

    Private WithEvents e As New ExportEventArgs
    Private WithEvents Essig As RichiesteEssig

    Private ReadOnly ErrorePreImportazione As Boolean = False
    Private ReadOnly ErrorePostImportazione As Boolean = False

    Private Archivio As ArchivioDati
    Private ReadOnly NoIncassi As New ArrayList

    Private Enum TipoImportazione
        Prima = 0
        Dopo = 1
    End Enum

    Public Sub New()
    End Sub

    Private mFiglia As String
    Public Property Figlia() As String
        Get
            Return mFiglia
        End Get
        Set(value As String)
            mFiglia = value
        End Set
    End Property

    Public Property FigliaUnisalute() As Boolean

    Public Shared Function ModelloMdbIncassi() As String
        Return Path.Combine(Utx.Globale.Paths.CartellaModelliDatiAgenzia, "Incassi.mdb")
    End Function

    Public Function MdbTemp() As String
        Return String.Format("{0}\{1}.mdb", Utx.Globale.Paths.CartellaTempUtente, Figlia) 'mdb temporaneo in locale dove memorizzare i dati
    End Function

    Public Function StringaConnessione() As String
        Return Utx.Globale.MDBDriver + MdbTemp()
    End Function

    Private Function DeskSub(Subagenzia As Object) As String
        Try
            If (Subagenzia Is DBNull.Value) OrElse (Subagenzia.Trim.Length = 0) Then
                Return "Tutte"
            Else
                Return Subagenzia
            End If

        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Friend Sub AggiornaIncassi(ByRef Annulla As Boolean)
        Try
            Globale.Log.Info(String.Format("Incassi: utente {0}", Environment.UserName))
            Globale.Log.Info(String.Format("Agenzia capofila: {0}-{1}", OpzioniScarico.AgenziaPrincipale, OpzioniScarico.Sede))
            Globale.Log.Info(String.Format("Agenzie da scaricare: {0}", OpzioniScarico.CodiciDaScaricare))
            Globale.Log.AumentaRientro()

            Essig = New RichiesteEssig(RichiesteEssig.TipoRichiesta.ESITATI, RichiesteEssig.TipoCompagnia.UNIPOL)
            AddHandler Essig.Stato, AddressOf e_CambiaStato

            Dim Giorni As New List(Of Date)

            For Each AgenziaMadre As String In OpzioniScarico.CodiciDaScaricare.Split("/")

                e.AgenziaMadre = AgenziaMadre

                'controllo incassi con data errata nel db della madre
                ControlloIncassi(AgenziaMadre)

                'trovo tutte le righe che configurano la collegata nella tabella config
                Dim dt As DataTable = OpzioniScarico.Config.ConfigAgenzia(OpzioniScarico.Compagnia,
                                                                          AgenziaMadre,
                                                                          OpzioniScarico.Sede)
                'controllo se c'è un codice unisalute e faccio login US
                Utx.Utente.ControlloUniSalute(dt)

#If DEBUG Then
                Utx.NetFunc.DataTable2Log(dt, Globale.Log, True)
#End If

                'per ogni riga di configurazione figlia dell'agenziacollegata
                For Each Figlia As DataRow In dt.Rows
                    Me.Figlia = Figlia("Collegata")
                    Me.FigliaUnisalute = (Figlia("Unisalute") = "S")

                    If Me.FigliaUnisalute Then
                        Essig.Compagnia = RichiesteEssig.TipoCompagnia.UNISALUTE
                    Else
                        Essig.Compagnia = RichiesteEssig.TipoCompagnia.UNIPOL
                    End If

                    e.Unisalute = Me.FigliaUnisalute

                    Globale.Log.Info(String.Format("Agenzia: {0}-{1} Sub: {2} (importa fino al {3:d})",
                                                   Figlia("Collegata"),
                                                   Figlia("Sede"),
                                                   DeskSub(Figlia("CodiciSub")),
                                                   MaxDataImportazione(Figlia("DataFine"))))
                    Globale.Log.AumentaRientro()

                    If OpzioniScarico.InizioPeriodo <= MaxDataImportazione(Figlia("DataFine")) Then
                        'If (OpzioniScarico.Forzatura = True) OrElse (Today <= MaxDataImportazione(Figlia("DataFine"))) Then
                        'creo l'mdb temporaneo e apro la connessione
                        CreaIncassiTemp()
                        If e.Errore Then Exit Try

                        'inizializzo l'archivio dell'agenzia o delle accorpate
                        Archivio = New ArchivioDati(Figlia("Collegata"))

                        If Archivio.Disponibile = False Then
                            Globale.Log.Info("Archivio dati non disponibile")
                        Else
                            'controllo codice compagnia
                            If Me.FigliaUnisalute Then
                                Archivio.ControlloCompagnia(RichiesteEssig.TipoCompagnia.UNISALUTE, Me.Figlia, OpzioniScarico, e)
                            Else
                                Archivio.ControlloCompagnia(RichiesteEssig.TipoCompagnia.UNIPOL, Me.Figlia, OpzioniScarico, e)
                            End If
                        End If

                        e.AgenziaFiglia = Figlia("Collegata")

                        'imposto i giorni su cui effettuare l'importazione
                        Giorni.Clear()

                        'controllo numero record sull'ultimo periodo in cui non è possibile quadrare
                        'ContaIncassi(AgenziaMadre, Figlia("Collegata"), Giorni)
                        Globale.Log.Info("* giornate con numero incassi errato: {0}", {Giorni.Count})

                        Using s As New Utx.ServiziOMW.ServizioDatiOMW
                            s.Proxy = Utx.Globale.UniProxy.Proxy
                            Dim Fx As New ServiziOMW.ConfigFiglia With {.Codice = Figlia("Collegata"),
                                        .Inizio = Figlia("DataInizio"), .Fine = Figlia("DataFine")}

                            Dim Gg As ServiziOMW.DatiIncassi = s.RichiestaDatiIncassi_0523(IIf(Me.FigliaUnisalute, 4, 1),
                                                                                           AgenziaMadre, Fx, OpzioniScarico.InizioPeriodo, Utx.Globale.Token)
                            Giorni.AddRange(Gg.Giorni)
                        End Using

                        'ordino
                        Giorni.Sort()

                        Dim MaxGiorni As Integer = 60
                        If OpzioniScarico.Forzatura = True Then
                            MaxGiorni = 1500
                        End If

                        If FileMancanti(Figlia, Giorni) > MaxGiorni Then
                            'se devo scaricare più di 30 giorni e non sono in fascia consentita creo job
                            If JobEsitati.FasciaOrariaConsentita = False Then
                                Dim Job As New JobEsitati
                                Job.Salva(OpzioniScarico)
                                JobEsitati.Messaggio()
                                Exit Sub
                            End If
                        End If

                        'se è stata richiesta la rilettura cancello i file
                        If OpzioniScarico.ScaricaFile = True Then
                            For Each d As Date In Giorni
                                Archivio.CancellaFileIncassi(d)
                            Next
                            OpzioniScarico.ScaricaFile = False
                        End If

                        'per i vecchi codici la lista dei giorni potrebbe essere vuota
                        If Giorni.Count > 0 Then
                            Dim UltimoGiorno As Date = Giorni.Item(Giorni.Count - 1)
                            Globale.Log.Info(UltimoGiorno)
                            Globale.Log.Info(Archivio.EsisteFileEsitati(Giorni.Item(Giorni.Count - 1)))

                            'l'ultima data esaminata per gli incassi è la data server + 120 giorni
                            'scarico se ultimogiorno è oggi (codice ancora attivo) oppure se
                            'il codice è chiuso e il file non esiste (non è stato ancora archiviato)
                            If (UltimoGiorno = Today) OrElse
                                       (UltimoGiorno < Today And Archivio.EsisteFileEsitati(Giorni.Item(Giorni.Count - 1)) = False) Then

                                Dim CodiciSub As String = Figlia("CodiciSub").ToString

                                Globale.Log.Info(String.Format("Subagenzia: {0}", DeskSub(CodiciSub)))
                                Globale.Log.AumentaRientro()

                                e.SubAgenzia = CodiciSub

                                'se è abilitata l'archiviazione dei file scarico tutti i file che servono
                                Dim IntervalloGiorni As Integer = RegolaIntervalloGiorni()
                                RichiesteEssig.TipoEsitati = RichiesteEssig.TipoRichiestaEsitati.NORMALE

                                Do While True
                                    e.Errore = False
                                    'scarico i file
                                    ScaricaFileAgenzia(Figlia("Collegata"), CodiciSub, Giorni, IntervalloGiorni)
                                    Select Case e.CodiceErrore
                                        Case 1002, 1003
                                            IntervalloGiorni = RegolaIntervalloGiorni(IntervalloGiorni)
                                            If IntervalloGiorni < 0 Then
                                                If RichiesteEssig.TipoEsitati = RichiesteEssig.TipoRichiestaEsitati.RIDOTTA Then
                                                    'fallita anche richiesta ridotta
                                                    e.Errore = True
                                                    Exit Try
                                                Else
                                                    'riprovo con richiesta ridotta senza IC/IS
                                                    IntervalloGiorni = 0
                                                    RichiesteEssig.TipoEsitati = RichiesteEssig.TipoRichiestaEsitati.RIDOTTA
                                                    Globale.Log.Info("Intervallo modificato a 0 giorni")
                                                End If
                                            End If
                                        Case 9000
                                            'sono al rientro da un periodo ridotto e/o richiesta ridotta
                                            IntervalloGiorni = RegolaIntervalloGiorni()
                                            RichiesteEssig.TipoEsitati = RichiesteEssig.TipoRichiestaEsitati.NORMALE
                                        Case Else
                                            If e.Errore = False Then
                                                Exit Do 'tutto ok
                                            Else
                                                Exit Try 'interrompo per errore
                                            End If
                                    End Select
                                Loop
                                'ora importo tutto con eventuale scarico un giorno per volta
                                CatturaIncassiAgenzia(Figlia("Collegata"), CodiciSub, Giorni, Annulla)

                                Globale.Log.DiminuisciRientro()
                            End If

                            Globale.Log.DiminuisciRientro()

                            If ConsensoUtente(Figlia("Collegata"), Me.FigliaUnisalute, Figlia("DataFine")) Then
                                'consolido i dati dell'agenzia nel db dell'agenzia madre
                                ConsolidaIncassi(AgenziaMadre, Figlia("Collegata")) 'invio i dati al server
                                Globale.Log.Info("Dati convalidati dall'utente")

                                'invia i dati a Unigest
                                AvviaUnigestUpload(Figlia("Collegata"), Figlia("DataInizio"))

                                'controllo finale per registro
                                QuadraturaIncassi(AgenziaMadre, Figlia("Collegata"), Giorni, False, TipoImportazione.Dopo)
                            Else
                                'l'utente NON conferma e cancello i file scaricati per poterli rileggere
                                For Each d As Date In Giorni
                                    Archivio.CancellaFileIncassi(d)
                                Next

                                Globale.Log.Info("Dati NON confermati")

                                e.Messaggio = "Importazione annullata"
                                e.Errore = True

                                OpzioniScarico.ErroreImportazione = True

                                'per permettere all'utente di vedere la notifica
                                Threading.Thread.Sleep(2000)
                            End If

                            e.Errore = False
                            e.Messaggio = ""
                            NoIncassi.Clear()
                        End If
                    End If
                    'psico - disabilitata il 27/09/2023
                    'RecuperoAssistenzaPsico(Figlia("Agenzia"), Figlia("Collegata")) 'devo passare l'agenzia madre
                Next
            Next

            NotificaErrori(ErrorePreImportazione, ErrorePostImportazione)

            Globale.Log.DiminuisciRientro()
            Globale.Log.Info("Importazione completata")
            Globale.Log.Info()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Friend Sub AggiornaFile(ScaricareDal As Date, ScaricatiPrimaDel As Date)
        'da utilizzare con automatismo. aggiorna i file senza importazione
        Try
            Globale.Log.Info(String.Format("Aggiornamento file incassi (automatismo): utente {0}", Environment.UserName))
            Globale.Log.Info(String.Format("Agenzia capofila: {0}-{1}", OpzioniScarico.AgenziaPrincipale, OpzioniScarico.Sede))
            Globale.Log.Info(String.Format("Agenzie da scaricare: {0}", OpzioniScarico.CodiciDaScaricare))
            Globale.Log.AumentaRientro()

            Essig = New RichiesteEssig(RichiesteEssig.TipoRichiesta.ESITATI, RichiesteEssig.TipoCompagnia.UNIPOL)
            AddHandler Essig.Stato, AddressOf e_CambiaStato

            For Each AgenziaMadre As String In OpzioniScarico.CodiciDaScaricare.Split("/")

                e.AgenziaMadre = AgenziaMadre

                'controllo incassi con data errata nel db della madre
                ControlloIncassi(AgenziaMadre)

                'trovo tutte le righe che configurano la collegata nella tabella config
                Dim dt As DataTable = OpzioniScarico.Config.ConfigAgenzia(OpzioniScarico.Compagnia,
                                                                          AgenziaMadre,
                                                                          OpzioniScarico.Sede)

                'per ogni riga di configurazione figlia dell'agenziacollegata
                For Each Figlia As DataRow In dt.Rows

                    If Today <= MaxDataImportazione(Figlia("DataFine")) Then
                        'inizializzo l'archivio dell'agenzia o delle accorpate
                        Archivio = New ArchivioDati(Figlia("Collegata"))

                        If Archivio.Disponibile = False Then
                            Globale.Log.Info("Archivio dati non disponibile")
                            Exit For
                        End If

                        'primo giorno con imposizione del minimo
                        Dim Giorno As Date = PrimoFileNonAggiornato(ScaricareDal, ScaricatiPrimaDel)
                        Giorno = Utx.FunzioniData.MinDate(Giorno, OpzioniScarico.InizioPeriodo)
                        'cancello i file da riscaricare
                        Archivio.CancellaFileIncassi(Giorno, Today.AddDays(-1))
                        'lista dei giorni da importare
                        Dim Giorni As List(Of Date) = Utx.FunzioniData.ListaGiorni(Giorno, Today)

                        Dim CodiciSub As String = Figlia("CodiciSub").ToString

                        Globale.Log.Info(String.Format("Agenzia: {0}-{1} Sub: {2}", Figlia("Collegata"), Figlia("Sede"), DeskSub(CodiciSub)))
                        Globale.Log.AumentaRientro()

                        e.AgenziaFiglia = Figlia("Collegata")

                        Dim IntervalloGiorni As Integer = RegolaIntervalloGiorni()
                        Do While True
                            e.Errore = False
                            'scarico i file
                            ScaricaFileAgenzia(Figlia("Collegata"), CodiciSub, Giorni, IntervalloGiorni)
                            Select Case e.CodiceErrore
                                Case 1002
                                    IntervalloGiorni = RegolaIntervalloGiorni(IntervalloGiorni)
                                    If IntervalloGiorni < 0 Then
                                        If RichiesteEssig.TipoEsitati = RichiesteEssig.TipoRichiestaEsitati.RIDOTTA Then
                                            'fallita anche richiesta ridotta
                                            e.Errore = True
                                            Exit Try
                                        Else
                                            'riprovo con richiesta  ridotta
                                            IntervalloGiorni = 0
                                            Globale.Log.Info("Intervallo modificato a 0 giorni")
                                            Essig.SwitchRichiestaEsitati(RichiesteEssig.TipoRichiestaEsitati.RIDOTTA)
                                        End If
                                    End If
                                Case 9000
                                    'sono al rientro da un periodo ridotto e/o richiesta ridotta
                                    IntervalloGiorni = RegolaIntervalloGiorni()
                                    Essig.SwitchRichiestaEsitati(RichiesteEssig.TipoRichiestaEsitati.NORMALE)
                                Case Else
                                    If e.Errore = False Then
                                        Exit Do 'tutto ok
                                    Else
                                        Exit Try 'interrompo per errore
                                    End If
                            End Select
                        Loop

                        'in caso di richiesta di chiusura
                        'If Utx.Globale.SessioneCorrente.RichiestaChiusura = True Then
                        '    Exit Try
                        'End If
                    End If
                Next
                'se sono qui ho finito senza errori e senza richieste di uscita
                If e.FileScaricati = 0 Then
                    'non ci sono più file da scaricare
                    Utx.GestioneFlag.CreaFlag(Utx.GestioneFlag.TipoFlag.VERIFICA_RILETTURA_FILE)
                Else
                    'è stato scaricato almeno un file scrivo la chiave
                    Utx.GestioneFlag.CreaFlag(Utx.GestioneFlag.TipoFlag.DATA_RILETTURA_FILE_INCASSI)
                End If
            Next

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Friend Sub AggiornaFile(Inizio As Date)
        'da utilizzare con richiesta manuale
        Try
            Globale.Log.Info(String.Format("Aggiornamento file incassi (richiesta manuale): utente {0}", Environment.UserName))
            Globale.Log.Info(String.Format("Agenzia capofila: {0}-{1}", OpzioniScarico.AgenziaPrincipale, OpzioniScarico.Sede))
            Globale.Log.Info(String.Format("Agenzie da scaricare: {0}", OpzioniScarico.CodiciDaScaricare))
            Globale.Log.AumentaRientro()

            Essig = New RichiesteEssig(RichiesteEssig.TipoRichiesta.ESITATI, RichiesteEssig.TipoCompagnia.UNIPOL)
            AddHandler Essig.Stato, AddressOf e_CambiaStato

            Dim Esito As Boolean = False

            For Each AgenziaMadre As String In OpzioniScarico.CodiciDaScaricare.Split("/")

                e.AgenziaMadre = AgenziaMadre

                'controllo incassi con data errata nel db della madre
                ControlloIncassi(AgenziaMadre)

                'trovo tutte le righe che configurano la collegata nella tabella config
                Dim dt As DataTable = OpzioniScarico.Config.ConfigAgenzia(OpzioniScarico.Compagnia,
                                                                          AgenziaMadre,
                                                                          OpzioniScarico.Sede)
                'controllo se c'è un codice unisalute e faccio login US
                Utx.Utente.ControlloUniSalute(dt)

                'per ogni riga di configurazione figlia dell'agenziacollegata
                For Each Figlia As DataRow In dt.Rows
                    Me.Figlia = Figlia("Collegata")
                    Me.FigliaUnisalute = (Figlia("Unisalute") = "S")

                    If Today <= MaxDataImportazione(Figlia("DataFine")) Then
                        'inizializzo l'archivio dell'agenzia o delle accorpate
                        Archivio = New ArchivioDati(Figlia("Collegata"))

                        If Archivio.Disponibile = False Then
                            Globale.Log.Info("Archivio dati non disponibile")
                            Exit For
                        End If

                        Dim CodiciSub As String = Figlia("CodiciSub").ToString
                        Globale.Log.Info(String.Format("Agenzia: {0}-{1} Sub: {2}", Figlia("Collegata"), Figlia("Sede"), DeskSub(CodiciSub)))
                        Globale.Log.AumentaRientro()

                        e.AgenziaFiglia = Figlia("Collegata")

                        If OpzioniScarico.ScaricaFile = True Then
                            'chiesta rilettura, cancello i file
                            Archivio.CancellaFileIncassi(OpzioniScarico.InizioPeriodo, Today)
                        End If

                        Dim Giorno As Date = PrimoFileNonAggiornato(Inizio, CDate("01/01/2000"))
                        Giorno = Utx.FunzioniData.MinDate(Giorno, OpzioniScarico.InizioPeriodo)
                        'lista dei giorni da importare
                        Dim Giorni As List(Of Date) = Utx.FunzioniData.ListaGiorni(Giorno, Today)

                        'se devo rileggere uso rilettura a gruppo
                        Dim IntervalloGiorni As Integer = RegolaIntervalloGiorni()
                        Do While True
                            e.Errore = False
                            'scarico i file
                            ScaricaFileAgenzia(Figlia("Collegata"), CodiciSub, Giorni, IntervalloGiorni)
                            Select Case e.CodiceErrore
                                Case 1002
                                    IntervalloGiorni = RegolaIntervalloGiorni(IntervalloGiorni)
                                    If IntervalloGiorni < 0 Then
                                        If RichiesteEssig.TipoEsitati = RichiesteEssig.TipoRichiestaEsitati.RIDOTTA Then
                                            'fallita anche richiesta ridotta
                                            e.Errore = True
                                            Exit Try
                                        Else
                                            'riprovo con richiesta  ridotta
                                            IntervalloGiorni = 0
                                            Globale.Log.Info("Intervallo modificato a 0 giorni")
                                            Essig.SwitchRichiestaEsitati(RichiesteEssig.TipoRichiestaEsitati.RIDOTTA)
                                        End If
                                    End If
                                Case 9000
                                    'sono al rientro da un periodo ridotto e/o richiesta ridotta
                                    IntervalloGiorni = RegolaIntervalloGiorni()
                                    Essig.SwitchRichiestaEsitati(RichiesteEssig.TipoRichiestaEsitati.NORMALE)
                                Case Else
                                    If e.Errore = False Then
                                        Exit Do 'tutto ok
                                    Else
                                        Exit Try 'interrompo per errore
                                    End If
                            End Select
                        Loop
                        'blocco altrimenti riscarica
                        OpzioniScarico.ScaricaFile = False
                        'ora importo tutto con eventuale scarico un giorno per volta
                        AggiornaIncassi(False)
                    End If
                Next
            Next

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Friend Function FileMancanti(Figlia As DataRow, ByRef Giorni As List(Of Date)) As Integer
        If Archivio.ArchiviazioneAbilitata = False Then
            Return 0
        End If

        Globale.Log.Info(String.Format("controllo file mancanti dal {0:dd-MM-yyyy} al {1:dd-MM-yyyy}", Giorni.Item(0), Giorni.Item(Giorni.Count - 1)))
        FileMancanti = 0
        For Each d As Date In Giorni
            If File.Exists(Archivio.FileIncassiArchiviato(d)) = False Then
                FileMancanti += 1
            End If
        Next
        ''controllo se i file degli ultimi 30 giorni (o più se richiesto) ci sono tutti
        If Figlia("DataFine") > Today Then
            Globale.Log.Info("controllo file mancanti ultimi 30 giorni")
            Dim Giorno As Date = Today.AddDays(-30)
            Do While Giorno < Today
                If File.Exists(Archivio.FileIncassiArchiviato(Giorno)) = False Then
                    If Giorni.Contains(Giorno) = False Then
                        Giorni.Add(Giorno)
                    End If
                    FileMancanti += 1
                End If
                'avanzo al giorno successivo
                Giorno = Giorno.AddDays(1)
            Loop
        End If
        Globale.Log.Info(String.Format("*** File mancanti: {0}", FileMancanti))
    End Function

    Private Sub ScaricaFileAgenzia(Agenzia As String,
                                   CodiciSub As String,
                                   ByRef Giorni As List(Of Date),
                                   IntervalloGiorni As Integer)
        Try
            'la procedura funziona solo con l'archiviazione abilitata
            If Archivio.ArchiviazioneAbilitata = False Then Exit Sub
            'se la lista dei giorni è vuota
            If Giorni.Count = 0 Then Exit Sub

            If Me.FigliaUnisalute Then
                Essig.Compagnia = RichiesteEssig.TipoCompagnia.UNISALUTE
                Essig.CreaLink()
            Else
                Essig.Compagnia = RichiesteEssig.TipoCompagnia.UNIPOL
                Essig.CreaLink()
            End If

            e.Errore = False
            e.CodiceErrore = 0
            Essig.EventArgs.Errore = False
            Essig.EventArgs.CodiceErrore = 0

            Dim ChiamataNoStandard As Boolean = (IntervalloGiorni < 14) OrElse (RichiesteEssig.TipoEsitati = RichiesteEssig.TipoRichiestaEsitati.RIDOTTA)

            Dim FileScaricati As New List(Of String) 'lista dei file scaricati per subagenzia
            Dim IndiceInizioBlocco, IndiceFineBlocco As Integer 'indice fine blocco di date in lettura inizializzati automaticamente a zero

            e.Messaggio = "Controllo file..."
            Dim GiorniDaScaricare As New List(Of Date)
            For k = 0 To Giorni.Count - 2 'utilizzo il -2 perché il -1 è oggi che non viene archiviato
                If FileAggiornato(Giorni.Item(k)) = False Then
                    GiorniDaScaricare.Add(Giorni.Item(k))
                End If
            Next
            GiorniDaScaricare.Sort()

            Dim DataLimite As Date
            If GiorniDaScaricare.Count = 0 Then
                Exit Try
            Else
                If ChiamataNoStandard Then
                    Globale.Log.Info("Chiamata NON standard: blocco di giorni {0} - tipo chiamata {1}", {IntervalloGiorni, RichiesteEssig.TipoEsitati.ToString})
                    DataLimite = GiorniDaScaricare.Item(0).AddDays(14)
                Else
                    DataLimite = GiorniDaScaricare.Item(GiorniDaScaricare.Count - 1)
                End If
            End If

            Do While IndiceInizioBlocco <= GiorniDaScaricare.Count - 1
                'primo giorno del blocco da scaricare
                Dim Inizio As Date = GiorniDaScaricare.Item(IndiceInizioBlocco)

                If Inizio > DataLimite Then
                    Exit Do
                End If

                'il file della giornata corrente non viene mai archiviato e perciò esco. non dovrebbe servire
                If Inizio = Today Then Exit Try

                'cerco la fine del blocco di giorni consecutivi con al massimo un numero di giorni=intervallogiorni
                IndiceFineBlocco = Math.Min(IndiceInizioBlocco + IntervalloGiorni, GiorniDaScaricare.Count - 1) 'indice limitato alla lunghezza della lista
                For k As Integer = IndiceFineBlocco To IndiceInizioBlocco Step -1
                    'offset fra inizio e fine blocco
                    Dim offset As Integer = k - IndiceInizioBlocco

                    'se è un blocco continuo di giorni
                    If GiorniDaScaricare.Item(IndiceInizioBlocco + offset) = GiorniDaScaricare.Item(IndiceInizioBlocco).AddDays(offset) Then
                        IndiceFineBlocco = k
                        Exit For
                    End If
                Next
                Dim Fine As Date = GiorniDaScaricare.Item(IndiceFineBlocco)

                FileScaricati.Clear()
                Dim FileDati As String = String.Format("{0}\{1}.csv", Utx.Globale.Paths.CartellaTempUtente, Format(Inizio, "yyyyMMdd"))

                'scarico i file di tutte le sub
                For Each SubAgenzia As String In CodiciSub.Split("/")
                    Globale.Log.Info(String.Format("Scarico file sub {0} dal {1:d} al {2:d}", SubAgenzia, Inizio, Fine))

                    e.SubAgenzia = SubAgenzia
                    If Inizio = Fine Then
                        e.Messaggio = String.Format("Scarico dati del {0:d}", Inizio)
                    Else
                        e.Messaggio = String.Format("Scarico dati dal {0:d} al {1:d}", Inizio, Fine)
                    End If

                    'chiamo il menù: necessario per settaggio parametri
                    Essig.ChiamaMenu()
                    If Essig.EventArgs.Errore = True Then
                        e.Errore = True
                        Exit Try
                    End If

                    'Essig.SwitchRichiestaEsitati(RichiesteEssig.TipoRichiestaEsitati.RIDOTTA)
                    Essig.RichiestaDati(Agenzia, SubAgenzia, Inizio, Fine)
                    If Essig.EventArgs.Errore = True Then
                        'errore
                        Select Case Essig.EventArgs.CodiceErrore
                            Case 1002, 1003
                                'probabilmente troppi record letti
                                e.Errore = False
                                e.CodiceErrore = Essig.EventArgs.CodiceErrore
                                Exit Try
                            Case Else
                                'errore non gestito. lettura non riuscita
                                e.Errore = True
                                Exit Try
                        End Select
                    End If

                    Dim FileSub As String = String.Format("{0}\{1}_{2:0000}.csv", Utx.Globale.Paths.CartellaTempUtente, Format(Inizio, "yyyyMMdd"), SubAgenzia)

                    'salvo il file nella cartella temporanea
                    Using sw As New StreamWriter(FileSub)
                        sw.Write(Essig.EsportaDati)
                    End Using

                    FileScaricati.Add(FileSub)
                Next

                'unisco i dati delle varie sub
                MergeFileEsitati(FileDati, FileScaricati)
                If e.Errore = True Then
                    e.Errore = True
                    Exit Try
                End If

                'divido il file totale in file giornalieri
                SplitFileEsitati(Agenzia, Inizio, Fine, FileDati)
                If e.Errore = True Then
                    e.Errore = True
                    Exit Try
                End If

                'mi sposto sul primo elemento della lista dei giorni dopo fine e che quindi non è stato ancora scaricato
                IndiceInizioBlocco = IndiceFineBlocco + 1
            Loop

            If ChiamataNoStandard Then
                e.Errore = False
                e.CodiceErrore = 9000
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            e.Messaggio = ex.Message
            e.Errore = True
        End Try
    End Sub

    Friend Sub CatturaIncassiAgenzia(Agenzia As String,
                                     CodiciSub As String,
                                     ByRef Giorni As List(Of Date),
                                     ByRef Annulla As Boolean)
        Try
            e.Errore = False
            e.Messaggio = ""

            For Each d As Date In Giorni

                e.InizioPeriodo = d
                e.SubAgenzia = CodiciSub

                'se è stata richiesta la rilettura
                If OpzioniScarico.ScaricaFile = True Then
                    Archivio.CancellaFileIncassi(d)
                End If

                'catturo il file degli esitati in formato csv o lo recupero dall'archivio
                Dim FileDati As String = ScaricaFileEsitati(Agenzia, CodiciSub, d)
                If e.Errore Or Annulla Then Exit For

                'importo i dati nel db
                ImportaIncassi(d, FileDati)
                If e.Errore Or Annulla Then Exit For

                'archivio il file
                If Archivio.ArchiviazioneAbilitata = True Then
                    Archivio.ArchiviaFileEsitati(FileDati, NomeFileEsitati(Agenzia, d, "csv"), d)
                Else
                    File.Delete(FileDati)
                End If
            Next
            'canoni
            UpdateCanoni()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Function ScaricaFileEsitati(Agenzia As String,
                                        CodiciSub As String,
                                        Giorno As Date) As String
        Try
            'scarico per una sola giornata
            'uso l'archivio solo per l'aggiornamento incassi
            Dim FileRecuperato As String = ""

            If Archivio IsNot Nothing Then
                FileRecuperato = Archivio.RecuperaFileEsitati(Giorno)
            End If

            If FileRecuperato.Length > 0 Then
                Return FileRecuperato
            Else
                Dim FileScaricati As New List(Of String)
                Dim FileDati As String = String.Format("{0}\{1}.csv", Utx.Globale.Paths.CartellaTempUtente, Format(Giorno, "yyyyMMdd"))

                For Each SubAgenzia As String In CodiciSub.Split("/")
                    'chiamo il menù: necessario per settaggio parametri
                    Essig.ChiamaMenu()
                    If Essig.EventArgs.Errore = True Then
                        e = Essig.EventArgs
                        Return ""
                    End If

                    'richiedo i dati
                    Essig.RichiestaDati(Agenzia, SubAgenzia, Giorno, Giorno)
                    If Essig.EventArgs.Errore = True Then
                        e = Essig.EventArgs
                        Return ""
                    End If

                    'esporto il file dati in formato csv
                    Dim FileSub As String = String.Format("{0}\{1}_{2}.csv",
                                                          Utx.Globale.Paths.CartellaTempUtente,
                                                          Format(Giorno, "yyyyMMdd"), SubAgenzia.PadLeft(4, "0"))

                    'salvo il file nella cartella temporanea
                    Using sw As New StreamWriter(FileSub)
                        sw.Write(Essig.EsportaDati)
                    End Using

                    FileScaricati.Add(FileSub)
                Next

                MergeFileEsitati(FileDati, FileScaricati)
                If e.Errore = True Then
                    Return ""
                End If

                Return FileDati
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            e.Messaggio = ex.Message
            e.Errore = True
            Return ""
        End Try
    End Function

    Private Sub ImportaIncassi(Giorno As Date, FileDati As String)
        Try
            Globale.Log.Info("incassi del {0:d}", {Giorno.Date})

            Using c As New OleDbConnection(StringaConnessione)
                c.Open()

                'creo un datatable disconnesso e vuoto
                Using da As New OleDbDataAdapter("SELECT * FROM Incassi WHERE False", c)
                    Using cmdBuilder As New OleDbCommandBuilder(da)
                        da.InsertCommand = cmdBuilder.GetInsertCommand

                        Dim dt As New DataTable
                        da.Fill(dt)

                        'apro lo stream
                        Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)
                            'leggo l'intestazione che non mi serve
                            sr.ReadLine()

                            Dim Campi() As String

                            Do While Not sr.EndOfStream
                                Dim Riga As String = sr.ReadLine
                                Globale.Log.Trace(Riga)

                                'controllo perché capita di avere una riga vuota specialmente in coda
                                If Riga.Trim.Length > 0 Then
                                    Campi = Riga.Split(";")

                                    'per risolvere il problema delle righe più corte
                                    'devo avere almeno 74 campi (0-73) con campo di indice 73=punto vendita
                                    IntegrazioneCampi(Campi, 74)

                                    'trimma tutto
                                    TrimArray(Campi)

                                    If (Campi(Tracciati.ESITATI.RamoGestione) > 0) AndAlso
                                       (Campi(Tracciati.ESITATI.TipoEsito) <> "IC") AndAlso
                                       (Campi(Tracciati.ESITATI.TipoEsito) <> "IS") Then

                                        'normalizza campi
                                        NormalizzaCampiEsitati(Campi)

                                        Try
                                            Dim dr As DataRow = dt.NewRow
                                            For k As Integer = 0 To 57
                                                Select Case dt.Columns(k).DataType
                                                    Case System.Type.GetType("System.Double")
                                                        dr(k) = CDbl(Campi(k)) 'per convertire correttamente la notazione italiana
                                                    Case System.Type.GetType("System.DateTime")
                                                        If IsDate(Campi(k)) Then
                                                            If CDate(Campi(k)) < #1/1/1900# Then
                                                                dr(k) = #1/1/1900#
                                                            Else
                                                                dr(k) = CDate(Campi(k))
                                                            End If
                                                        Else
                                                            dr(k) = #1/1/1900#
                                                        End If
                                                    Case Else
                                                        dr(k) = Campi(k)
                                                End Select
                                            Next

                                            dr("Targa") = Left(Campi(Tracciati.ESITATI.Targa), 9)
                                            dr("Quota") = Utx.FunzioniDb.Str2Num(Campi(Tracciati.ESITATI.Quota))
                                            dr("DataRegolazione") = Campi(Tracciati.ESITATI.DataRegolazione)
                                            dr("RataIntermedia") = Campi(Tracciati.ESITATI.RataIntermedia)
                                            dr("Cin") = Campi(Tracciati.ESITATI.Cin)
                                            dr("Abi") = Utx.FunzioniDb.Str2Num(Campi(Tracciati.ESITATI.Abi))
                                            dr("Cab") = Utx.FunzioniDb.Str2Num(Campi(Tracciati.ESITATI.Cab))
                                            dr("ContoCorrente") = Campi(Tracciati.ESITATI.ContoCorrente)
                                            dr("PuntoVendita") = Utx.FunzioniDb.Str2Num(Campi(Tracciati.ESITATI.PuntoVendita))
                                            dr("Psico") = 0
                                            'dal 27/01/2025
                                            Try
                                                dr("AntProvvInc") = Campi(Tracciati.ESITATI.AntProvvInc)
                                                dr("AntProvvAcq") = Campi(Tracciati.ESITATI.AntProvvAcq)
                                                dr("AntProvvCav") = Campi(Tracciati.ESITATI.AntProvvCav)
                                                dr("AntProvvFlag") = Campi(Tracciati.ESITATI.AntProvvFlag)
                                                dr("CavRC") = Campi(Tracciati.ESITATI.CavRC)
                                                dr("CavIF") = Campi(Tracciati.ESITATI.CavIF)
                                                dr("CavINF") = Campi(Tracciati.ESITATI.CavINF)
                                                dr("CavKASKO") = Campi(Tracciati.ESITATI.CavKASKO)
                                                dr("CavASS") = Campi(Tracciati.ESITATI.CavASS)
                                            Catch ex As Exception
                                                'non fare niente, serve per la rilettura dei file incassi vecchi che non hanno questi campi
                                                'per recuperarli bisogna leggere di nuovo i file da essig
                                            End Try

                                            dt.Rows.Add(dr)

                                            'per debug -----------------------------
                                            'Try
                                            '    da.Update(dt)
                                            'Catch ex As Exception
                                            '    Globale.Log.Errore(ex)
                                            '    Globale.Log.Info(dr("contraente"))
                                            'Finally
                                            '    dt.Clear()
                                            'End Try
                                            '---------------------------------------
                                        Catch ex As Exception
                                            Globale.Log.Errore(ex)
                                            Globale.Log.Info("Errore esitato {0}", {Campi(Tracciati.ESITATI.Contraente)})
                                        End Try
                                    End If
                                End If
                            Loop
                        End Using

                        da.Update(dt)

                        Globale.Log.Info(String.Format("Record letti: {0}", dt.Rows.Count))

                        'leggo i canoni unibox
                        ImportaCanoni(Giorno, FileDati)

                        'se è un giorno feriale e non ci sono incassi
                        If (dt.Rows.Count = 0) AndAlso (Giorno <> Today) AndAlso (Giorno.DayOfWeek <> DayOfWeek.Sunday) Then
                            'solo per gli ultimi 7 giorni
                            If (DateDiff(DateInterval.Day, Giorno, Today) <= 7) AndAlso (Giorno <> Today) Then
                                NoIncassi.Add(Giorno)
                            End If
                        End If

                        dt.Dispose()
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
            e.Messaggio = ex.Message
            e.Errore = True
        End Try
    End Sub

    Private Sub ImportaCanoni(Giorno As Date, FileDati As String)
        Try
            Using c As New OleDbConnection(Utx.Globale.MDBDriver + MdbTemp())
                c.Open()

                'creo un datatable disconnesso e vuoto
                Using da As New OleDbDataAdapter("SELECT * FROM Unibox WHERE False", c)

                    Using cmdBuilder As New OleDbCommandBuilder(da)

                        da.InsertCommand = cmdBuilder.GetInsertCommand

                        Dim dt As New DataTable
                        da.Fill(dt)

                        'pulisco il file da eventuali null
                        ClearFileFromNull(FileDati)

                        'apro lo stream
                        Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)
                            'leggo l'intestazione che non mi serve
                            sr.ReadLine()

                            Dim Campi() As String

                            Do While Not sr.EndOfStream

                                Dim Riga As String = sr.ReadLine

                                'controllo perché capita di avere una riga vuota specialmente in coda
                                If Riga.Trim.Length > 0 Then

                                    Campi = Riga.Split(";")

                                    'per risolvere il problema delle righe più corte
                                    'devo avere almeno 62 campi (0-61) con campo 61=targa
                                    IntegrazioneCampi(Campi, 61)

                                    'trimma tutto
                                    TrimArray(Campi)

                                    'se si tratta di un canone
                                    If (Campi(Tracciati.ESITATI.RamoGestione) = 0) AndAlso
                                       (Campi(Tracciati.ESITATI.TipoEsito) <> "IC") AndAlso
                                       (Campi(Tracciati.ESITATI.TipoEsito) <> "IS") AndAlso
                                       (Campi(Tracciati.ESITATI.TipoMovimento) = "CANONE") Then

                                        'normalizza campi
                                        NormalizzaCampiEsitati(Campi)

                                        Dim dr As DataRow = dt.NewRow

                                        dr("Ramo") = Campi(Tracciati.ESITATI.Ramo)
                                        dr("Polizza") = Campi(Tracciati.ESITATI.Polizza)
                                        dr("DataEffettoAppendice") = Campi(Tracciati.ESITATI.EffettoApp)
                                        dr("NumeroAppendice") = Campi(Tracciati.ESITATI.NumeroApp)
                                        dr("DataEffettoTitolo") = Campi(Tracciati.ESITATI.EffettoTitolo)
                                        dr("DataFoglioCassa") = Campi(Tracciati.ESITATI.DataEsito)
                                        dr("Canone") = CDbl(Campi(Tracciati.ESITATI.TotaleLordo))

                                        dt.Rows.Add(dr)
                                    End If
                                End If
                            Loop
                        End Using

                        da.Update(dt)

                        Globale.Log.Info(String.Format("Canoni unibox: {0}", dt.Rows.Count))
                        dt.Dispose()
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Globale.Log.Info(String.Format("canoni unibox del {0:d}", Giorno.Date))
            Globale.Log.Errore(ex)
            e.Messaggio = ex.Message
            e.Errore = True
        End Try
    End Sub

    Private Sub UpdateCanoni()
        Try
            Using c As New OleDbConnection(Utx.Globale.MDBDriver + MdbTemp())
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "UPDATE Incassi AS I " +
                                      "INNER JOIN Unibox AS U ON I.ramo=U.Ramo AND I.Polizza=U.Polizza AND I.DataEffettoAppendice=U.DataEffettoAppendice AND " +
                                                                "I.NumeroAppendice=U.NumeroAppendice AND I.DataEffettoTitolo=U.DataEffettoTitolo AND I.dataFoglioCassa=U.dataFoglioCassa " +
                                      "SET I.CanoneBox = U.Canone"
                    cmd.ExecuteNonQuery()
                    'metto a zero i null
                    cmd.CommandText = "UPDATE Incassi SET CanoneBox = 0 WHERE CanoneBox IS NULL"
                    cmd.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
            e.Messaggio = ex.Message
            e.Errore = True
        End Try
    End Sub

    Private Sub ConsolidaIncassi(AgenziaMadre As String, AgenziaFiglia As String)
        Try
            Using c As New OleDbConnection(Utx.Globale.MDBDriver + MdbTemp())
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    'controllo record infiltrati :-) di altra compagnia
                    cmd.CommandText = String.Format("DELETE * FROM Incassi WHERE Compagnia <> {0}", IIf(Me.FigliaUnisalute, 4, 1))
                    Globale.Log.Info("cancellati {0} record infiltrati", {cmd.ExecuteNonQuery()})
                End Using
            End Using

            Utx.OmWeb.InviaFile(AgenziaMadre, MdbTemp, Utx.ServiziOMW.TipoEvento.AGGIORNA_INCASSI.ToString, False)
            e.Messaggio = ""
        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            'cancello il db temporaneo
            File.Delete(MdbTemp)
        End Try
    End Sub

    Private Sub CreaIncassiTemp()
        Try
            File.Delete(MdbTemp)
            File.Copy(ModelloMdbIncassi, MdbTemp, True)

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + MdbTemp())
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT Ramo,Polizza,DataEffettoAppendice,NumeroAppendice,DataEffettoTitolo,DataFoglioCassa,
                        TotaleTitolo AS Canone INTO Unibox FROM Incassi"
                    cmd.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
            e.Messaggio = ex.Message
            e.Errore = True
        End Try
    End Sub

    Private Function MaxDataImportazione(DataChiusura As Date) As Date
        'impongo il limite della data chiusura + 120 giorni
        Return Utx.FunzioniData.MinDate(Today, DataChiusura.AddDays(120))
    End Function

    Private Function DataFileIncassi(Agenzia As String) As Date
        Try
            Dim DataScansione As Date = MinimaDataIncassi(Agenzia)

            Do While File.Exists(FullPathFileIncassi(Agenzia, DataScansione))
                DataScansione = DataScansione.AddDays(1)
            Loop

            Return DataScansione

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return MinimaDataIncassi(Agenzia)
        End Try
    End Function

    Private Function MinimaDataIncassi(Agenzia As String) As Date
        Try
            'Data minima 01/01/2014
            Return Utx.FunzioniData.MaxDate(#1/1/2014#, Utx.FunzioniData.InizioAnno(Now.AddYears(-2))).Date
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return Utx.FunzioniData.InizioAnno(Now.AddYears(-2)).Date
        End Try
    End Function

    Private Sub QuadraturaIncassi(AgenziaMadre As String,
                                  AgenziaFiglia As String,
                                  ByRef Giorni As List(Of Date),
                                  ByRef ErroreControllo As Boolean,
                                  Tipo As TipoImportazione)
        Try
            'nel contesto la figlia è la collegata (incorporata) nella madre
            Globale.Log.Info("Eseguo quadratura incassi")

            'nel db dell'agenzia madre incrocio i dati della figlia
            'correzione dei NULL
            'estraggo giorni con quadratura errata (> di 50 cent)
            Dim Query As String = String.Format("UPDATE ControlloIncassi SET NumeroCorrezioni = 0 WHERE NumeroCorrezioni IS NULL

                SELECT I.Agenzia,I.DataFoglioCassa,C.TotaleLordo,I.TotaleGiorno 
                FROM (SELECT Agenzia,DataFoglioCassa,SUM(TotaleTitolo) AS TotaleGiorno 
                        FROM Incassi 
                        WHERE Agenzia = '{0}'
                        GROUP BY Agenzia,DataFoglioCassa) AS I 
                INNER JOIN ControlloIncassi AS C 
                ON I.Agenzia = C.Agenzia AND I.DataFoglioCassa = C.DataFoglioCassa 
                WHERE (I.Agenzia = '{0}') AND (ABS(I.TotaleGiorno - C.TotaleLordo) > 0.5) AND (CAST(C.Ignora AS bit) = 0) 
                ORDER BY c.DataFoglioCassa", AgenziaFiglia)

            Dim dr As DataTableReader = Utx.FunzioniDb.CreaDataTableReader(Query, AgenziaMadre)

            If dr.HasRows Then
                'ci sono errori
                ErroreControllo = True

                Dim NumeroGiorni As Integer = 0
                Do While dr.Read
                    'aggiungo il giorno alla lista
                    If Giorni.Contains(dr("DataFoglioCassa")) = False Then
                        Giorni.Add(dr("DataFoglioCassa"))
                        Globale.Log.Trace(dr("DataFoglioCassa"))
                    End If
                    'cancello i file per la rilettura
                    If Tipo = TipoImportazione.Prima Then
                        Archivio.CancellaFileIncassi(dr("DataFoglioCassa"))
                    End If

                    'aggiorno il numero di tentativi di correzione e il flag ignora
                    If Tipo = TipoImportazione.Prima Then
                        AggiornaTentativiCorrezione(AgenziaMadre, AgenziaFiglia, dr("DataFoglioCassa"))
                    End If

                    'aggiorno il registro
                    AggiornaRegistro(AgenziaMadre,
                                     AgenziaFiglia,
                                     dr("DataFoglioCassa"),
                                     dr("TotaleGiorno"),
                                     dr("TotaleLordo"),
                                     True,
                                     Tipo)
                    NumeroGiorni += 1
                Loop
                'metto il flag alle giornate da ignorare nel prossimo controllo quadratura
                AggiornaIgnoraQuadratura(AgenziaMadre, AgenziaFiglia)
                Globale.Log.Info(String.Format("Aggiorno registro. Giornate che non quadrano: {0}", NumeroGiorni))
            Else
                ErroreControllo = False
                'aggiorno il registro 
                Globale.Log.Info("Aggiorno registro. Nessun errore di quadratura.")
                AggiornaRegistro(AgenziaMadre, AgenziaFiglia, Nothing, 0, 0, False, Tipo)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex, False)
        End Try
    End Sub

    Public Shared Function NomeFileEsitati(Agenzia As String,
                                           DataRiferimento As Date,
                                           Estensione As String)

        'restituisce il nome file incassi del tipo 01949_INCASSI_20130127.zip (o csv)
        If RichiesteEssig.CompagniaCorrente = RichiesteEssig.TipoCompagnia.UNIPOL Then
            Return String.Format("{0}_INCASSI_{1}.{2}", Agenzia, Format(DataRiferimento, "yyyyMMdd"), Estensione)
        Else
            Return String.Format("{0}_INCASSI_US_{1}.{2}", Agenzia, Format(DataRiferimento, "yyyyMMdd"), Estensione)
        End If
    End Function

    Public Function FullPathFileIncassi(Agenzia As String,
                                        DataRiferimento As Date)
        'restituisce il path completo del file incassi nell'archivio dati
        Try
            Return Path.Combine(Archivio.PathArchivioAnnoMese(DataRiferimento, Utx.Enumerazioni.TipoFileMagia.Incassi),
                                NomeFileEsitati(Agenzia, DataRiferimento, "zip"))
        Catch ex As Exception
            Return "-ERR"
        End Try
    End Function

    Private Function ConsensoUtente(Agenzia As String,
                                    Unisalute As Boolean,
                                    DataFine As Date) As Boolean
        Return True
        'bloccato dal 08/05/2023 per modifica da effettuare per distinguere unipolsai da unisalute
        'elimino i giorni successivi alla data chiusura del codice che in genere sono vuoti e diventa solo una scocciatura
        For k As Integer = NoIncassi.Count - 1 To 0 Step -1
            If NoIncassi(k) > DataFine Then
                NoIncassi.RemoveAt(k)
            End If
        Next

        If NoIncassi.Count = 0 OrElse Utx.Globale.SessioneCorrente.Nascosta Then
            Return True
        Else
            Dim Avviso As String = String.Format("Agenzia {1} ({2}){0}Nei seguenti giorni non sono presenti incassi:{0}{0}",
                                                 Environment.NewLine, Agenzia, IIf(Unisalute, "Unisalute", "UnipolSai"))

            For Each g As Date In NoIncassi
                Avviso += String.Format("{0} {1} {2} - {3}{4}",
                                        g.Day.ToString.PadLeft(2, "0"),
                                        Format(g, "MMMM"),
                                        g.Year,
                                        Format(g, "dddd"),
                                        Environment.NewLine)
            Next

            Avviso += String.Format("{0}Confermate l'importazione?", Environment.NewLine)

            If MsgBox(Avviso,
                      MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1,
                      "Importazione incassi") = MsgBoxResult.Yes Then

                Return True
            Else
                Return False
            End If
        End If
    End Function

    Public Sub AvviaUnigestUpload(Agenzia As String, DataInizio As Date)
        Try
            If Utx.Globale.ProfiloEnteGestore.Abilitazioni.UNIGEST = True Then
                Globale.Log.Info("Invio i file ad Unigest...")
                e.Messaggio = String.Format("Invio dati Unigest", Environment.NewLine, Agenzia)
#If Not DEBUG Then
                Dim Upload As New UnigestUp.Upload(Agenzia, DataInizio)
                Upload.AvviaUpload()
#End If
                e.Messaggio = "..."
            Else
                Globale.Log.Info("Agenzia {0} non abilitata ad Unigest.", {Agenzia})
            End If
        Catch ex As Exception
            Globale.Log.Info(ex)
        End Try
    End Sub

    Private Sub NotificaErrori(ErrorePre As Boolean,
                               ErrorePost As Boolean)
        'notifica all'utente
        If ErrorePreImportazione = True AndAlso ErrorePostImportazione = False Then
            MsgBox(String.Format("Prima dell'importazione è stato rilevato un errore nei dati.{0}" +
                                 "L'errore è stato corretto.{0}{0}Consultare il registro per i dettagli.",
                                 Environment.NewLine), MsgBoxStyle.Information, Utx.Globale.TitoloApp)

        ElseIf ErrorePreImportazione = False AndAlso ErrorePostImportazione = True Then
            MsgBox(String.Format("Durante l'importazione si è verificato un errore nei dati.{0}{0}" +
                                 "Consultare il registro per i dettagli.",
                                 Environment.NewLine), MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)

        ElseIf ErrorePreImportazione = True AndAlso ErrorePostImportazione = True Then
            MsgBox(String.Format("Prima dell'importazione è stato rilevato un errore nei dati.{0}" +
                                 "L'errore NON è stato corretto.{0}{0}Consultare il registro per i dettagli.",
                                 Environment.NewLine), MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
        End If
    End Sub

    Private Sub ControlloIncassi(AgenziaMadre As String)
        Try
            Dim Query As String = "DELETE FROM Incassi WHERE DataFoglioCassa < '01/01/2000'"

            Dim Record As Integer = Utx.WsCommand.ExecuteNonQueryRecord(Query, AgenziaMadre)

            If Record > 0 Then
                Globale.Log.Info(String.Format("Eliminati {0} con campo data corrotto", Record))
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub AggiornaRegistro(AgenziaMadre As String,
                                 AgenziaFiglia As String,
                                 Giorno As Date,
                                 PremioEssig As Double,
                                 PremioFlusso As Double,
                                 Errore As Boolean,
                                 Tipo As TipoImportazione,
                                 Optional Descrizione As String = "")
        Try
            Dim Query As New Utx.NetFunc.StringFormatter("INSERT INTO Registro (Errore,Importazione,Agenzia,Giorno,Descrizione,
                TotaleEssig,TotaleDownload,Differenza,Tipo) 
                VALUES (CAST(@errore AS bit),'@importazione',@agenzia,@giorno,'@desk',@essig,@flusso,@diff,'@tipo')")

            With Query.Parametri
                .Add("@errore", IIf(Errore, 1, 0))
                .Add("@importazione", Format(Now, "dd/MM/yyyy HH:mm:ss"))
                .Add("@agenzia", AgenziaFiglia)

                If Giorno < #1/1/2000# Then
                    .Add("@giorno", "NULL")
                Else
                    .Add("@giorno", "'" & Format(Giorno, "dd/MM/yyyy") & "'")
                End If

                If Descrizione.Length > 0 Then
                    .Add("@desk", Left(Descrizione, 50))
                    .Add("@essig", 0)
                    .Add("@flusso", 0)
                    .Add("@diff", 0)
                ElseIf Errore = True Then
                    .Add("@desk", "Quadratura: errore")
                    .Add("@essig", Utx.FunzioniDb.TO_NUMBER(PremioEssig))
                    .Add("@flusso", Utx.FunzioniDb.TO_NUMBER(PremioFlusso))
                    .Add("@diff", Utx.FunzioniDb.TO_NUMBER(PremioEssig - PremioFlusso))
                Else
                    .Add("@desk", "Quadratura: nessuna segnalazione")
                    .Add("@essig", 0)
                    .Add("@flusso", 0)
                    .Add("@diff", 0)
                End If

                .Add("@tipo", Tipo.ToString)
            End With
            Globale.Log.Info("aggiornato registro incassi con {0} record",
                             Utx.WsCommand.ExecuteNonQueryRecord(Query.StringaFormattata, AgenziaMadre))

        Catch ex As Exception
            Globale.Log.Errore(ex, False)
        End Try
    End Sub

    Private Sub AggiornaTentativiCorrezione(AgenziaMadre As String, AgenziaFiglia As String, DataFoglioCassa As Date)
        Try
            'aggiorno il numero di tentativi di correzione e il flag ignora
            Dim Query As String = String.Format("UPDATE ControlloIncassi 
                    SET NumeroCorrezioni = NumeroCorrezioni + 1 
                    WHERE Agenzia = '{0}' AND DataFoglioCassa = '{1:dd/MM/yyyy}'", AgenziaFiglia, DataFoglioCassa)
            Utx.WsCommand.ExecuteNonQueryRecord(Query, AgenziaMadre)
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub AggiornaIgnoraQuadratura(AgenziaMadre As String, AgenziaFiglia As String)
        Try
            'aggiorno il flag ignora
            Dim Query As String = String.Format("UPDATE ControlloIncassi 
                    SET Ignora = IIF(NumeroCorrezioni >= 3,CAST(1 AS bit),CAST(0 AS bit)) 
                    WHERE Agenzia = '{0}'", AgenziaFiglia)
            Utx.WsCommand.ExecuteNonQueryRecord(Query, AgenziaMadre)
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub e_CambiaStato() Handles e.CambiaStato
        RaiseEvent StatoImportazione(e)
    End Sub

    Private Sub Essig_Stato(e As ExportEventArgs) Handles Essig.Stato
        RaiseEvent StatoImportazione(e)
    End Sub

    Private Sub IntegrazioneCampi(ByRef Campi() As String,
                                  Lunghezza As Integer)
        'se la riga ha meno campi aggiungo campi vuoti fino a lunghezza
        Try
            Dim NumeroCampi As Integer = Campi.GetUpperBound(0)

            If NumeroCampi < Lunghezza Then

                ReDim Preserve Campi(Lunghezza)

                For k As Integer = NumeroCampi + 1 To Lunghezza
                    Campi(k) = ""
                Next
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub MergeFileEsitati(FileDestinazione As String,
                                 ListaFile As List(Of String))
        Try
            Dim Intestazione As String = "Tipo;Comp;Age;Ramo;Polizza;Eff.App.;Num.App.;Eff.Titolo;Tipoca;Tipo Mat.;Esito;Tipo Pag.;Data Esito;Effettivo Pag;Cod.Cassa;Contraente;Cod.Fisc.;" +
                "Tassabile;Totale;Pr.Acq.;Pr.Inc.;Cod.Del.;Subag;Conven.;Produt.;Conv.Provv.;Scad.Vincolo;Prodotto;Frazionamento;Incr.Produz.;Di cui ARD;Di cui INF;Tariffa vita;Rendita prev.;" +
                "Ramo Gestione;Eff.Poliz.;Scad.Poliz.;Tipo Movim.;Aliq.Pr.Acq.;Aliq.Pr.Inc.;Tutela;Assistenza;Premio RC;Prv.Fisse RC;C.A.V.RCA ;Pr.INC/FUR;Prv.INC/FUR;Pr.INF.;Prv.INF.;Pr.Kasko;" +
                "Prv.Kasko;Pr.Assist.;Prv.Assist.;SSN;DataScad.Titolo;Importo Incassato;Prodotto Vita;Tipo Unibox;Cod.Fisc.Dipendente;Matricola Dipendente;Codice Azienda;Targa Veicolo;NS Quota;" +
                "Importo al100;Data Definizione Reg.Premio;Premio Tassab.old;Flag Rata Int.;Ora esito;Ora Copertura;Cod.Cin;Cod.Abi;Cod.Cab;Cod.Conto;P.Vendita;Nuovo mandato;Tipo incasso;" +
                "Cod.Scontrino;MARK-UP;CODICE ACCORDO;ANT. PROVV.INC;ANT. PROVV. ACQ;ANT. PROVV. CAV;FLAG ANT. PROVV;ADDEB. AUTOMAT.;Folder;Attr.Tipo Carico;Carrello;CAV.RC;CAV.INC/FUR;CAV.INF;" +
                "CAV.Kasko;CAV.Assist.;% Comm.Interm."

            'merge file
            Using sw As New StreamWriter(FileDestinazione, False)
                sw.WriteLine(Intestazione)

                For Each f As String In ListaFile

                    'controllo file scaricato
                    Esitati.ControlloFileEsitati(f, e)
                    If e.Errore = True Then
                        File.Delete(f)
                        Exit Try
                    End If

                    'ripulisco da eventuali NULL (00)
                    If ClearFileFromNull(f) = False Then
                        File.Delete(f)
                        Exit Try
                    End If

                    Using sr As New StreamReader(f)
                        'scarto l'intestazione
                        sr.ReadLine()
                        'aggiungo il resto
                        Do While sr.EndOfStream = False
                            sw.WriteLine(sr.ReadLine)
                        Loop
                    End Using
                    'cancello il file della sub appena aggiunta
                    File.Delete(f)
                Next
            End Using

        Catch ex As Exception
            Globale.Log.Info(ex)
            e.Messaggio = ex.Message
            e.Errore = True
        End Try
    End Sub

    Private Sub SplitFileEsitati(Agenzia As String,
                                 Inizio As Date,
                                 Fine As Date,
                                 FileDati As String)
        Try
            If Archivio.ArchiviazioneAbilitata = False Then Exit Sub

            Dim Giorno As Date = Inizio
            Do While Giorno <= Fine

                Dim FileGiornaliero As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "FileGiornaliero.csv")

                Using sw As New StreamWriter(FileGiornaliero, False)
                    Using sr As New StreamReader(FileDati)
                        sw.WriteLine(sr.ReadLine)

                        Do While Not sr.EndOfStream
                            Dim riga As String = sr.ReadLine
                            If CDate(riga.Split(";")(Tracciati.ESITATI.DataEsito)) = Giorno Then
                                sw.WriteLine(riga)
                            End If
                        Loop
                    End Using
                End Using

                'archivio il file
                Archivio.ArchiviaFileEsitati(FileGiornaliero, NomeFileEsitati(Agenzia, Giorno, "csv"), Giorno, Sovrascrivi:=True)

                e.FileScaricati += 1

                'avanzo di un giorno
                Giorno = Giorno.AddDays(1)
            Loop
            'cancello il file totale splittato
            File.Delete(FileDati)

        Catch ex As Exception
            Globale.Log.Info(ex)
            e.Messaggio = ex.Message
            e.Errore = True
        End Try
    End Sub

    Private Function RegolaIntervalloGiorni(Optional IntervalloPrecedente As Integer = 99) As Integer
        Dim NuovoIntervallo As Integer
        Select Case IntervalloPrecedente
            Case 99
                NuovoIntervallo = 14
            Case 14
                NuovoIntervallo = 6
            Case 6
                NuovoIntervallo = 0
            Case Else 'è uguale a 0
                'Intervallo minimo di un giorno. non lo posso più diminuire ed esco con errore
                NuovoIntervallo = -1
        End Select
        Globale.Log.Info(String.Format("Intervallo modificato a {0} giorni", NuovoIntervallo))
        Return NuovoIntervallo
    End Function

    Friend Function PrimoFileNonAggiornato(Inizio As Date,
                                           Optional Aggiornamento As Date = #1/1/1900#) As Date
        Try
            'cerco da dove devo cominciare con l'aggiornamento. finecontrollo è oggi e non va incluso
            Do While Inizio <= Today
                'archivio fa riferimento alla specifica agenzia
                Dim FileArchiviato As String = Archivio.FileIncassiArchiviato(Inizio)

                If File.Exists(FileArchiviato) = True Then
                    'il file esiste
                    If New FileInfo(Archivio.FileIncassiArchiviato(Inizio)).LastAccessTime < Aggiornamento Then
                        'il file non è aggiornato
                        Exit Do
                    Else
                        'il file è aggiornato
                        Inizio = Inizio.AddDays(1)
                    End If
                Else
                    'il file non esiste
                    Exit Do
                End If
            Loop

            Return Inizio

        Catch ex As Exception
            Return Inizio
        End Try
    End Function

    Friend Function FileAggiornato(Giorno As Date, Optional Aggiornamento As Date = #1/1/1900#) As Boolean
        Try
            'archivio fa riferimento alla specifica agenzia
            Dim FileArchiviato As String = Archivio.FileIncassiArchiviato(Giorno)

            If File.Exists(FileArchiviato) = True Then
                'il file esiste
                'Globale.Log.Trace("Il file incassi del {0:dd-MM-yyyy} esiste", {Giorno})
                Return New FileInfo(Archivio.FileIncassiArchiviato(Giorno)).LastAccessTime >= Aggiornamento
            Else
                'il file non esiste
                Globale.Log.Trace("*** Il file incassi del {0:dd-MM-yyyy} NON esiste", {Giorno})
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    Friend Function IncassiDelGiorno(Compagnia As Integer,
                                     Agenzia As String,
                                     Giorno As Date,
                                     Optional CodiceSub As String = "",
                                     Optional ByRef Annulla As Boolean = False) As DataTable

        Essig = New RichiesteEssig(RichiesteEssig.TipoRichiesta.ESITATI, RichiesteEssig.TipoCompagnia.UNIPOL)
        AddHandler Essig.Stato, AddressOf e_CambiaStato

        If Compagnia = 4 Then
            Essig.Compagnia = RichiesteEssig.TipoCompagnia.UNISALUTE
            Essig.CreaLink()
        Else
            Essig.Compagnia = RichiesteEssig.TipoCompagnia.UNIPOL
            Essig.CreaLink()
        End If

        Globale.Log.Info("Importa incassi utente {0}", {Environment.UserName})

        Agenzia = Agenzia.Trim.PadLeft(5, "0")

        Dim dt As New DataTable

        Try
            e.Errore = False

            e.AgenziaFiglia = Agenzia
            e.SubAgenzia = CodiceSub
            e.InizioPeriodo = Giorno
            e.FinePeriodo = Giorno

            'catturo il file degli esitati in formato csv
            Dim FileDati As String = ScaricaFileEsitati(Agenzia, CodiceSub, Giorno)

            If e.Errore = True Then
                Globale.Log.Info(e.Messaggio)
                MsgBox(e.Messaggio, MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Exit Try
            End If

            Esitati.ControlloFileEsitati(FileDati, e)

            'importo i dati nel db
            dt = ImportaIncassiDelGiorno(Agenzia, FileDati)
            If e.Errore Or Annulla Then Exit Try

        Catch ex As Exception
            Globale.Log.Errore(ex)
            e.Messaggio = ex.Message
            e.Errore = True
        End Try

        If e.Errore Then
            Globale.Log.Info("Importazione con errori")
        Else
            Globale.Log.Info("Importazione completata correttamente")
        End If

        Return dt

    End Function

    Private Function ImportaIncassiDelGiorno(Agenzia As String,
                                             FileDati As String) As DataTable

        Globale.Log.Info("Importo incassi del giorno")
        Dim dt As New DataTable

        Try

            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(Agenzia, Utx.ConnessioniDb.Db.INCASSI))
                c.Open()

                'creo un datatable disconnesso e vuoto
                Using da As New OleDbDataAdapter("SELECT * FROM Incassi WHERE False", c)
                    Using cmdBuilder As New OleDbCommandBuilder(da)
                        da.InsertCommand = cmdBuilder.GetInsertCommand
                    End Using

                    da.Fill(dt)
                End Using

                'pulisco il file da eventuali null
                ClearFileFromNull(FileDati)

                'apro lo stream 
                Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)

                    sr.ReadLine() 'intestazione

                    Dim Campi() As String

                    Do While Not sr.EndOfStream

                        Campi = sr.ReadLine.Split(";")

                        'per risolvere il problema delle righe più corte
                        'devo avere almeno 62 campi (0-61) con campo 61=targa
                        IntegrazioneCampi(Campi, 61)

                        'trimma tutto
                        TrimArray(Campi)

                        'normalizza campi
                        NormalizzaCampiEsitati(Campi)

                        Dim dr As DataRow = dt.NewRow

                        For k As Integer = 0 To dt.Columns.Count - 2 'poi aggiungo targa

                            Try
                                If dt.Columns(k).DataType Is System.Type.GetType("System.Double") Then
                                    dr(k) = CDbl(Campi(k)) 'per convertire correttamente la notazione italiana
                                Else
                                    dr(k) = Campi(k)
                                End If

                            Catch ex As Exception
                                dr(k) = DBNull.Value
                            End Try
                        Next

                        dr("Targa") = Right(Campi(Tracciati.ESITATI.Targa).Trim, 9)

                        dt.Rows.Add(dr)
                    Loop
                End Using
                File.Delete(FileDati)
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
            e.Messaggio = ex.Message
            e.Errore = True
        End Try

        Return dt
    End Function

    Public Shared Function RecuperoAssistenzaPsico(Agenzia As String, Collegata As String) As Boolean
        Return True

        Dim Notifica As New Utx.FormNotifica
        Try
            Globale.Log.Info("Assistenza psicologica: agenzia {0} - collegata {1}", {Agenzia, Collegata})

            Dim CartellaMA As String = Path.Combine(Utx.Globale.Paths.CartellaArchivioDati, Collegata, "OMNIA", "FileRicevuti")

            If Directory.Exists(CartellaMA) = False Then
                Globale.Log.Info("Cartella {0} inesistente", {CartellaMA})
                Return False
            Else
                Globale.Log.Info("Cartella MA: {0}", {CartellaMA})
            End If

            With Notifica
                .Stile = FormNotifica.Style.BIANCO_ROSSO
                .Altezza = FormNotifica.AltezzaNotifica.MEZZA
                .Show()
                .Messaggio = "Incassi assistenza psicologica..."
            End With

            'connessione al db dell'agenzia che contiene la collegata
            Using c As New OleDb.OleDbConnection(Utx.ConnessioniDb.ConnectionString(Agenzia, Utx.ConnessioniDb.Db.INCASSI))
                c.Open()

                CreaCampoPsicologica(c)
                CreaTabellaPsicologica(c)

                Using cmd As New OleDb.OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text

                    Dim Inizio As Date = #1/1/2020#
                    Dim DataInizioMA As Date = #1/1/2100#

                    Dim MaxDataFC As Date = UltimoAggiornamentoPsico(Agenzia, Collegata) 'dati già analizzati e importati
                    Inizio = MaxDataFC.AddDays(1)
                    Globale.Log.Info("Importazione dati assistenza psicologica {0} dal {1:dd-MM-yyyy}", {Agenzia, Inizio})

                    cmd.CommandText = String.Format("DELETE FROM Psicologica WHERE DataFoglioCassa >= {0:#MM/dd/yyyy#}", Inizio)
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "INSERT INTO Psicologica (Agenzia,Ramo,Polizza,NumeroAppendice,DataEffettoTitolo,DataFoglioCassa,TotaleTitolo,Psico) 
                                       VALUES(?,?,?,?,?,?,?,?)"

                    For Each MA As String In Directory.GetFiles(CartellaMA, "MA??????2????????.zip")
                        Dim Totale As Single = 0
                        Dim DataFile As New DateTime(Path.GetFileName(MA).Substring(8, 2) + 2000,
                                                     Path.GetFileName(MA).Substring(10, 2),
                                                     Path.GetFileName(MA).Substring(12, 2))

                        If DataFile < DataInizioMA Then
                            DataInizioMA = DataFile 'per rilevare da che data è iniziata l'importazione psico da MA
                        End If

                        If DataFile >= Inizio Then
                            'decomprimo MA
                            Dim f As String = Utx.LibreriaZip.SevenZip.UnZipFile(MA, Utx.Globale.Paths.CartellaTempUtente)(0)
                            f = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, f)

                            Using sr As New StreamReader(f)
                                Do While sr.EndOfStream = False
                                    Dim riga As String = sr.ReadLine
                                    If riga.Substring(15, 2) = "23" Then
                                        Dim DataFoglioCassa As New DateTime(riga.Substring(65, 4), riga.Substring(69, 2), riga.Substring(71, 2))
                                        If DataFoglioCassa > MaxDataFC Then
                                            MaxDataFC = DataFoglioCassa
                                            Globale.Log.Info("Dati assistenza psicologica FC del {0:dd-MM-yyyy} (file {1})",
                                                             {DataFoglioCassa, Path.GetFileName(f)})
                                        End If
                                        Dim RamoGestione As Integer = riga.Substring(5977, 5)

                                        If (DataFoglioCassa >= Inizio) AndAlso (RamoGestione = 1) Then
                                            Dim Ramo As Integer = riga.Substring(17, 3)
                                            Dim Polizza As Integer = riga.Substring(20, 9)
                                            Dim NumeroAppendice As Integer = riga.Substring(37, 3)
                                            Dim DataEffettoTitolo As New DateTime(riga.Substring(40, 4), riga.Substring(44, 2), riga.Substring(46, 2))
                                            Dim TotaleTitolo As Double = riga.Substring(158, 1) & riga.Substring(142, 16)
                                            Dim Psico As Double = 0

                                            Notifica.Messaggio = String.Format("{1} ({2}): incassi assistenza psicologica{0}{3:dd-MM-yyyy}",
                                                                                       Environment.NewLine, Agenzia, Collegata, DataFoglioCassa)

                                            Dim Garanzie As String = riga.Substring(330, 3320) 'blocco delle garanzie
                                            Dim Pos As Integer = 0

                                            Do While Pos < 3320
                                                '40 blocchi di 83 caratteri, a partire dal 330 (base 0), così fatti:
                                                '<campo nome = "CodiceCategoriaRischioA" lunghezza="05"/>
                                                '<campo nome = "CodiceTassazioneA"       lunghezza="04"/>
                                                '<campo nome = "PremioNettoA"            lunghezza="17" formato="9(12),999S"/>
                                                '<campo nome = "InteressiA"              lunghezza="17" formato="9(12),999S"/>
                                                '<campo nome = "AccessoriA"              lunghezza="17" formato="9(12),999S"/>
                                                '<campo nome = "TasseA"                  lunghezza="17" formato="9(12),999S"/>
                                                '<campo nome = "AliquotaTasseA"          lunghezza="06" formato="9(03),99"/>

                                                Dim Garanzia As String = Garanzie.Substring(Pos, 83) 'singola garanzia

                                                If Garanzia.Substring(0, 5) = "00000" Then
                                                    Exit Do
                                                ElseIf Garanzia.Substring(0, 5) = "00247" Then
                                                    If Garanzia.Substring(25, 1) = "+" Then
                                                        Psico = Garanzia.Substring(9, 16)
                                                    Else
                                                        Psico = -Garanzia.Substring(9, 16)
                                                    End If
                                                    'aggiungo in tabella psicologica
                                                    If Psico <> 0 Then
                                                        cmd.Parameters.Clear()
                                                        cmd.Parameters.AddWithValue("agenzia", Collegata)
                                                        cmd.Parameters.AddWithValue("ramo", Ramo)
                                                        cmd.Parameters.AddWithValue("polizza", Polizza)
                                                        cmd.Parameters.AddWithValue("app", NumeroAppendice)
                                                        cmd.Parameters.AddWithValue("effetto", DataEffettoTitolo)
                                                        cmd.Parameters.AddWithValue("cassa", DataFoglioCassa)
                                                        cmd.Parameters.AddWithValue("lordo", TotaleTitolo)
                                                        cmd.Parameters.AddWithValue("psico", Psico)
                                                        cmd.ExecuteNonQuery()
                                                    End If
                                                    Exit Do
                                                End If
                                                Pos += 83
                                            Loop
                                        End If
                                    End If
                                Loop
                            End Using
                            File.Delete(f)
                        End If
                    Next
                    'aggiorno la tabella incassi
                    Notifica.Messaggio = String.Format("Assistenza psicologica {1}:{0} salvo i dati della {2}", Environment.NewLine, Agenzia, Collegata)
                    cmd.CommandText = "UPDATE Incassi SET Psico = 0"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE Incassi AS I " +
                                      "INNER JOIN Psicologica AS P ON I.Ramo=P.Ramo AND I.Polizza=P.Polizza AND " +
                                      "I.NumeroAppendice=P.NumeroAppendice AND I.DataEffettoTitolo=P.DataEffettoTitolo AND " +
                                      "I.DataFoglioCassa=P.DataFoglioCassa And I.TotaleTitolo=P.TotaleTitolo " +
                                      "SET I.Psico = P.Psico"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE Incassi SET Psico = 0 WHERE Psico IS NULL"
                    cmd.ExecuteNonQuery()

                    AggiornaCalendarioPsico(Agenzia, Collegata, MaxDataFC, DataInizioMA)
                End Using
            End Using
            Notifica.Chiudi()
            Return True
        Catch ex As Exception
            Notifica.Messaggio = ex.Message
            Notifica.Chiudi(5)
            Return False
        End Try
    End Function

    Public Shared Function CreaCampoPsicologica(c As OleDbConnection) As Boolean
        Try
            If Utx.FunzioniDb.EsisteCampo(c, "Incassi", "Psico") = False Then
                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "ALTER TABLE Incassi ADD COLUMN Psico SINGLE"
                    cmd.ExecuteNonQuery()
                End Using
            End If
            Return True
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Private Shared Function CreaTabellaPsicologica(c As OleDbConnection) As Boolean
        Try
            If Utx.FunzioniDb.EsisteTabella(c, "Psicologica") = False Then
                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT Agenzia,Ramo,Polizza,NumeroAppendice,DataEffettoTitolo,DataFoglioCassa,TotaleTitolo,Psico 
                                       INTO Psicologica 
                                       FROM Incassi 
                                       WHERE Psico <> 0"
                    cmd.ExecuteNonQuery()
                End Using
            End If
            Return True
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Shared Function UltimoAggiornamentoPsico(Agenzia As String, Collegata As String) As Date
        Try
            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(Agenzia, Utx.ConnessioniDb.Db.INCASSI))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT Importazione FROM Registro WHERE Tipo = 'PSICO' AND Agenzia = ?"
                    cmd.Parameters.AddWithValue("agenzia", Collegata)
                    Return Utx.FunzioniData.MaxDate(cmd.ExecuteScalar, #12/31/2019#)
                End Using
            End Using
        Catch ex As Exception
            Return #12/31/2019#
        End Try
    End Function

    Public Shared Function InizioAggiornamentoPsico(Agenzia As String, Collegata As String) As Date
        Try
            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(Agenzia, Utx.ConnessioniDb.Db.INCASSI))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT MMIN(Giorno) FROM Registro WHERE Tipo = 'PSICO'"
                    Return Utx.FunzioniData.MaxDate(cmd.ExecuteScalar, #12/21/2019#)
                End Using
            End Using
        Catch ex As Exception
            Return #12/31/2019#
        End Try
    End Function

    Private Shared Sub AggiornaCalendarioPsico(Agenzia As String, Collegata As String,
                                               Aggiornamento As Date, DataInizioMA As Date)
        Try
            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(Agenzia, Utx.ConnessioniDb.Db.INCASSI))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    'cancello la precedente registarzione
                    cmd.CommandText = "DELETE FROM Registro WHERE Tipo = 'PSICO' AND Agenzia = @agenzia"
                    cmd.Parameters.AddWithValue("agenzia", Collegata)
                    cmd.ExecuteNonQuery()
                    'aggiungo la registrazione dell'aggiornamento corrente
                    cmd.CommandText = "INSERT INTO Registro (Agenzia,Tipo,Importazione,Giorno) VALUES(@agenzia,'PSICO',@aggiornamento,@inizioMA)"
                    cmd.Parameters.AddWithValue("aggiornamento", Aggiornamento)
                    cmd.Parameters.AddWithValue("inizioma", DataInizioMA)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

#If DEBUG Then
    Public Shared Sub IncassiDebug(cartella As String, SubAgenzie As String)
        Try
            Dim FileEsito As String = Path.Combine(cartella, "Esito.csv")
            File.Delete(FileEsito)

            Using sw As New StreamWriter(FileEsito)

                For Each f As String In Directory.GetFiles(cartella, "*.csv")

                    If f <> FileEsito Then
                        Using sr As New StreamReader(f)
                            sr.ReadLine() 'intestazione

                            Do While sr.EndOfStream = False
                                Dim Riga As String = sr.ReadLine

                                If SubAgenzie.Contains(Riga.Split(";")(Tracciati.ESITATI.SubAgenzia).Trim.PadLeft(4, "0")) Then
                                    sw.WriteLine(Riga)
                                End If
                            Loop
                        End Using
                    End If
                Next
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub
#End If

#Region "variazioni"
    Public Sub AggiornaVariazioni(Figlia As DataRow)

        Globale.Log.Info(String.Format("Variate/Sostituite: utente {0}", Environment.UserName))
        Globale.Log.Info(String.Format("Agenzia capofila: {0}-{1}", OpzioniScarico.AgenziaPrincipale, OpzioniScarico.Sede))
        Globale.Log.Info(String.Format("Agenzie da scaricare: {0}", OpzioniScarico.CodiciDaScaricare))
        Globale.Log.AumentaRientro()

        Try
            Essig = New RichiesteEssig(RichiesteEssig.TipoRichiesta.VARIAZIONI, RichiesteEssig.TipoCompagnia.UNIPOL)

            'For Each AgenziaMadre As String In OpzioniScarico.CodiciDaScaricare.Split("/")

            '    e.AgenziaMadre = AgenziaMadre

            '    'trovo tutte le righe che configurano la collegata nella tabella config
            '    Dim dt As DataTable = OpzioniScarico.Config.ConfigAgenzia(OpzioniScarico.Compagnia,
            '                                                              AgenziaMadre,
            '                                                              OpzioniScarico.Sede)


            'For Each Figlia As DataRow In dt.Rows

            'se madre e figlia coincidono
            If Figlia("Agenzia") = Figlia("Collegata") Then

                For Each SubAgenzia As String In Figlia("CodiciSub").ToString.Split("/")

                    Globale.Log.Info(String.Format("Agenzia {0} - Collegata {1} - Sub {2}", Figlia("Agenzia"), Figlia("Collegata"), SubAgenzia))
                    Globale.Log.AumentaRientro()

                    e.SubAgenzia = SubAgenzia

                    If e.Errore Then Exit Try

                    Dim Inizio As Date = InizioPeriodoVariazioni(Figlia("Agenzia"))
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
                        ImportaVariazioni(FileDati)
                        If e.Errore Then Exit Do

                        Globale.Log.DiminuisciRientro()

                        'avanzo di un giorno rispetto alla fine del periodo precedente
                        Inizio = Fine.AddDays(1)
                    Loop

                    Globale.Log.DiminuisciRientro()
                Next
            End If
            'Next
            'Next

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

    Private Sub ImportaVariazioni(FileDati As String)
        Try
            Using c As New OleDbConnection(StringaConnessione)

                c.Open()

                Using da As New OleDbDataAdapter("SELECT * FROM PolizzeSostituite WHERE False", c)

                    Using cmdBuilder As New OleDbCommandBuilder(da)
                        da.InsertCommand = cmdBuilder.GetInsertCommand

                        Dim dt As New DataTable
                        da.Fill(dt)

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

                        da.Update(dt)

                        Globale.Log.Info(String.Format("record importati: {0}", dt.Rows.Count))
                        dt.Dispose()
                    End Using

                    File.Delete(FileDati)
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
            e.Errore = True
        End Try
    End Sub

    Private Function InizioPeriodoVariazioni(CodiceAgenzia As String) As Date
        Try
            Dim Query As String = "DECLARE @maxdata AS DATETIME = (SELECT MAX(DataVar) FROM PolizzeSostituite)
                If ISDATE(@maxdata) = CAST(1 as bit)
                    SELECT CAST(@maxdata AS DATE)
                ELSE
                    SELECT '01/01/' + TRIM(STR(YEAR(GETDATE())))"
            Return Utx.WsCommand.ExecuteScalar(Query, CodiceAgenzia).Valore
        Catch ex As Exception
            Globale.Log.Errore(ex)
            e.Errore = True
            Return New DateTime(Today.Year - 1, 1, 1)
        End Try
    End Function
#End Region
End Class
