Imports System.IO
Imports System.Data.OleDb

Public Class Manutenzione
    'manutenzione livechange
    Public Shared Notifica As Utx.FormNotifica
    Private Shared FlagErroreGlobale As Boolean
    Private Shared FlagErroreMetodo As Boolean
    Private Shared Log As New Utx.ApplicationLog("Manutenzione.log", LogCondiviso:=True)

    Public Shared Sub LiveChange()
        'manutenzione
        Try
            Log.Info("Controllo manutenzioni")

            Utx.GestioneFlag.CreaFlag(Utx.GestioneFlag.TipoFlag.LIVE_CHANGE)
            Utx.GestioneFileFlag.InitFlag()

            FlagErroreGlobale = False

            For Each ChiaveManutenzione As FileFlag In Utx.GestioneFileFlag.Flag

                FlagErroreMetodo = False

                'controllo esistenza flag
                If (ChiaveManutenzione.CategoriaFlag = FileFlag.Categoria.NORMALE) AndAlso (ChiaveManutenzione.Esiste = False) Then

                    Dim Notifica As New Utx.FormNotifica
                    With Notifica
                        .ColoreSfondo = Drawing.Color.PaleGreen
                        .Opacity = 0.8
                        .Text = ""
                        .Show()

                        .Messaggio = "Manutenzione dati..."
                    End With

                    With Log
                        .Info(String.Format("* Eseguo manutenzione {0}", ChiaveManutenzione.Key))
                        .AumentaRientro()
                        .Info("chiave   : " + ChiaveManutenzione.Key)
                        .Info("percorso : " + ChiaveManutenzione.FullPath)
                        .Info("categoria: " + ChiaveManutenzione.CategoriaFlag.ToString)
                        .Info("scadenza : " + ChiaveManutenzione.Scadenza.ToString)
                        .Info("eseguito : " + ChiaveManutenzione.Eseguito.ToString)
                        .Info("esiste   : " + ChiaveManutenzione.Esiste.ToString)
                    End With

                    'dati comuni
                    Select Case ChiaveManutenzione.Key
                        Case "28-03-2017"
                            ManutenzioneArchivioListe()
                        Case "03-04-2017"
                            ModificaLayoutSinistri()
                        Case "TabelleComuni"
                            EsistenzaTabelleComuni()
                            AggiornamentoTabelleComuni()
                        Case "ChiaviSupporto"
                            Utx.FunzioniDb.CreaChiaviSupporto()
                        Case "NormalizzaFlag"
                            NormalizzaFlag()
                        Case "TabellaUtenti"
                            UpdateUtenti()
                        Case "EsistenzaTabelleComuni"
                            EsistenzaTabelleComuni()
                        Case "Convenzioni"
                            Convenzioni()
                        Case "LayoutClienti"
                            Utx.Layout.AggiungiColonna(Path.Combine(Utx.Globale.Paths.CartellaSetting, "Clienti.layout.xml"),
                                                           "AutorizzazioneFEA", "FEA", "False", "True", "60", "0", "-404040", "32", "", Dopo:="ConsensoPrivacy")
                            Utx.Layout.AggiungiColonna(Path.Combine(Utx.Globale.Paths.CartellaSettingRete, "Clienti.layout.xml"),
                                                           "AutorizzazioneFEA", "FEA", "False", "True", "60", "0", "-404040", "32", "", Dopo:="ConsensoPrivacy")
                        Case "LayoutSinistri"
                            Dim xml As String = Path.Combine(Utx.Globale.Paths.CartellaSetting, "Sinistri.layout.xml") + ";" +
                                Path.Combine(Utx.Globale.Paths.CartellaSettingRete, "Sinistri.layout.xml")

                            For Each LayoutFile As String In xml.Split(";")
                                'cancello le colonne
                                Utx.Layout.CancellaColonna(LayoutFile, "Sinistri.Ispettorato")
                                Utx.Layout.CancellaColonna(LayoutFile, "TblComparto.Descrizione")
                                Utx.Layout.CancellaColonna(LayoutFile, "Sinistri.TipoCid")
                                Utx.Layout.CancellaColonna(LayoutFile, "ConvDesk")
                                Utx.Layout.CancellaColonna(LayoutFile, "TblApp.Descrizione")
                                'le inserisco modificate
                                Utx.Layout.AggiungiColonna(LayoutFile, "Ispettorato", "Ispettorato", "False", "True", "76", "0", "-32768", "32", "", Dopo:="DesRamoSinistro")
                                Utx.Layout.AggiungiColonna(LayoutFile, "DeskComparto", "Codice perito", "False", "True", "60", "0", "0", "32", "", Dopo:="Comparto")
                                Utx.Layout.AggiungiColonna(LayoutFile, "TipoCid", "Tipo Cid", "False", "True", "40", "0", "0", "32", "", Dopo:="DataProtocollo")
                                Utx.Layout.AggiungiColonna(LayoutFile, "DeskConv", "Desc.Conv.", "False", "True", "106", "0", "0", "32", "", Dopo:="Convenzione")
                                Utx.Layout.AggiungiColonna(LayoutFile, "DeskApp", "Desc.applicativo", "False", "True", "80", "0", "0", "32", "", Dopo:="CompControparte")
                            Next
                        Case "ResetDbLink"
                            'ResetDbLink()
                    End Select

                    'per ogni agenzia/codice gestito
                    For Each Agenzia As String In Utx.EnteGestore.CodiciGestiti
                        Notifica.Messaggio = String.Format("Manutenzione dati{0}{1} {2}",
                                                           Environment.NewLine, ChiaveManutenzione.Descrizione, Agenzia)

                        Log.Info(String.Format("agenzia  : {0}", Agenzia))
                        Log.AumentaRientro()

                        Select Case ChiaveManutenzione.Key
                            Case "ModificaDbUt"
                                ModificaDbUt(Agenzia)
                            Case "05-12-2016"
                                NuoveTabelleAgenzia(Agenzia)
                                ControlloEsistenzaDatabase(Agenzia)
                                NormalizzaArchivioClienti(Agenzia)
                                NormalizzaArchivioPolizze(Agenzia)
                                NormalizzaArchivioSinistri(Agenzia)
                                NormalizzaArchivioDbUno(Agenzia)
                                UpdateArchivi(Agenzia)
                                UpdateDataUltimaNota(Agenzia)
                                UpdateArchivioSinistri(Agenzia)
                                AggiornaAndamentoSinistri(Agenzia)
                                ModificaMovPolizze(Agenzia)
                                AggiornaArretrati(Agenzia)
                                ResetControlloIncassi(Agenzia)
                            Case "20-01-2017"
                                AggiornaAnag(Agenzia)
                            Case "01-02-2017"
                                AggiornaPolizze(Agenzia)
                            Case "06-02-2017"
                                ResetPTFCanc(Agenzia)
                            Case "10-02-2017"
                                AggiornaPolizze(Agenzia)
                                UpdateDataMemoSinistri(Agenzia)
                                ResetCalendarioOmnia(Agenzia, Utx.Enumerazioni.TipoFileMagia.Polizze)
                            Case "13-02-2017"
                                AggiornaPolizzeMarcaVeicolo(Agenzia)
                            Case "ManutenzioneNote"
                                ManutenzioneNote(Agenzia)
                            Case "24-02-2017"
                                ManutenzionePeriti(Agenzia)
                            Case "28-02-2017"
                                NormalizzaArchivioClienti(Agenzia)
                                UpdateArchivi(Agenzia)
                                ResetCalendarioOmnia(Agenzia, Utx.Enumerazioni.TipoFileMagia.Anag)
                            Case "07-03-2017"
                                NormalizzaArchivioClienti(Agenzia)
                                ModificaEvidenze(Agenzia)
                            Case "10-03-2017", "23-03-2017"
                                UpdateArchivioSinistri(Agenzia)
                                Utx.FunzioniDb.CreaChiaviSinistri(Agenzia)
                                Utx.FunzioniDb.CreaChiaviPolizze(Agenzia)
                            Case "16-03-2017"
                                VecchiLog()
                            Case "22-03-2017"
                                AllineamentoModelli(Agenzia)
                            Case "28-03-2017"
                                AggiornaAndamentoSinistri(Agenzia)
                                ModificaFileCalendari(Agenzia)
                            Case "TabelleDbUno"
                                NuoveTabelleDbUno(Agenzia)
                            Case "11-04-2017"
                                ResetCalendarioDoc(Agenzia, Utx.Enumerazioni.TipoFileDoc.BUSTE, "1/1/2017")
                            Case "13-04-2017"
                                NormalizzaArchivioSinistri(Agenzia)
                            Case "21-04-2017"
                                AllineamentoModelli(Agenzia)
                                UpdateTargheIncassi(Agenzia)
                                File.Delete(Utx.ConnessioniDb.PathMdbAgenzia(Agenzia, Utx.ConnessioniDb.Db.SINISTRIEXTRA))
                            Case "01-05-2017", "CreaIndici"
                                MD5ArchivioNote(Agenzia)
                                CreaIndici(Agenzia)
                            Case "CompagniaNota"
                                UpdateCompagniaNote(Agenzia)
                            Case "TracciatoPolizze"
                                NormalizzaArchivioPolizze(Agenzia)
                            Case "ModelliAgenzia"
                                NuoveTabelleAgenzia(Agenzia)
                            Case "ClientiSub"
                                'utilizzato in timerunitools. da rimuovere a regime
                            Case "TracciatiRete"
                                TracciatiGestioneRete(Agenzia)
                            Case "NormalizzaDbUno"
                                NormalizzaArchivioDbUno(Agenzia)
                            Case "TabelleBudget"
                                TabelleBudget(Agenzia)
                            Case "ResetCalendarioOmnia0307"
                                ResetCalendarioOmnia(Agenzia, Enumerazioni.TipoFileMagia.Polizze)
                            Case "ModificaComparti_25072017"
                                ModificaComparti(Agenzia)
                            Case "RinominaSinistriDP"
                                ChiaveManutenzione.Esito = RinominaSinistriDP(Agenzia)
                            Case "AllineamentoModelli"
                                AllineamentoModelli(Agenzia)
                            Case "ArchiviaIncassi"
                                ArchiviaIncassi(Agenzia)
                            Case "IndiciDbUno"
                                Utx.FunzioniDb.CreaVincoliDbUno(Agenzia)
                            Case "PuliziaDati"
                                PuliziaDati(Agenzia)
                            Case "ContattiCIP"
                                CreaContattiCIP(Agenzia)
                            Case "RipartizioneTitoli"
                                RipartizioneTitoli(Agenzia)
                            Case "ManutenzioneEvidenze"
                                ModificaEvidenze(Agenzia)
                            Case "ArchiviaTitoli"
                                ArchiviaTitoli(Agenzia)
                            Case "Arretrati"
                                AggiornaArretrati(Agenzia)
                            Case "EliminaTabelle"
                                EliminaTabelle(Agenzia)
                            Case "NormalizzaDbSinistri"
                                NormalizzaArchivioSinistri(Agenzia)
                            Case "ResetCalendarioOmnia"
                                ResetCalendarioOmnia(Agenzia, Utx.Enumerazioni.TipoFileMagia.AndamentoSinistri)
                            Case "RecuperoSinistri022018"
                                RecuperoSinistri022018(Agenzia)
                            Case "RiletturaSinistri"
                                RiletturaSinistri(Agenzia)
                                'Case "ManutenzioneSinistriAC"
                                '    ManutenzioneSinistriAC(Agenzia)
                            Case "ResetSinistriAia"
                                ResetCalendarioUt(Agenzia, Enumerazioni.TipoFileMagia.SinistriBase, CDate("31/12/2017"))
                            Case "UpdateDataMemoSinistri"
                                UpdateDataMemoSinistri(Agenzia)
                            Case "MonitorQTKMS"
                                AggiornaMonitorQT_KMS(Agenzia)
                            Case "ResetCalendarioAnag"
                                ResetCalendarioOmnia(Agenzia, Enumerazioni.TipoFileMagia.Anag)
                            Case "ResetCalendarioMonQTKMS"
                                ResetCalendarioUt(Agenzia, Enumerazioni.TipoFileMagia.MonitorQT_KMS, CDate("01/08/2020"))
                            'Case "ManutenzioneIdNote"
                            '    ManutenzioneIdNote(Agenzia)
                            Case "ResetCalendarioAnagNew"
                                ResetCalendarioOmnia(Agenzia, Enumerazioni.TipoFileMagia.AnagNew)
                            Case "PuliziaEvidenze"
                                PuliziaEvidenze(Agenzia)
                            Case "TabellaClienti"
                                AggiornaTabellaClienti(Agenzia)
                        End Select

                        Log.Info("esito   : " + ChiaveManutenzione.Esito.ToString)
                        Log.Info()
                        Log.DiminuisciRientro()
                    Next

                    'se non ci sono stati errori nell'esecuzione della manutenzione
                    If FlagErroreMetodo = False Then
                        'crea flag
                        ChiaveManutenzione.CreaFlag()

                        If (ChiaveManutenzione.Key = "RinominaSinistriDP") AndAlso (ChiaveManutenzione.Esito = True) Then
                            'creo la stored sinistri in DbLink
                            'Using c As New OleDbConnection(Utx.Globale.CnDbLink)
                            '    c.Open()
                            '    Utx.Agenzia.CreaStored(c, "Sinistri", "SinistriDP", Utx.ConnessioniDb.PathMdb(Utx.ConnessioniDb.Db.SINISTRI))
                            'End Using
                            'messaggio per l'utente
                            MsgBox(String.Format("ATTENZIONE: è stata effettuata una manutenzione straordinaria del database sinistri.{0}{0}" +
                                                 "Si consiglia di far RIAVVIARE subito Unitools a tutti gli utenti.", Environment.NewLine),
                                             MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                        End If
                    End If
                    Notifica.Messaggio = "Manutenzione dati conclusa"
                    Notifica.Chiudi(1)
                End If

                Log.DiminuisciRientro()
            Next

            PuliziaFlag()

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            Utx.Globale.SettingInterop.Rimuovi(Utx.GestioneFlag.TipoFlag.LIVE_CHANGE)
        End Try
    End Sub

    Public Shared Sub LiveChangeTardivo()
        'manutenzione
        Try
            Log.Info("Controllo manutenzioni tardive")

            Utx.GestioneFileFlag.InitFlag()
            FlagErroreGlobale = False

            For Each ChiaveManutenzione As FileFlag In Utx.GestioneFileFlag.Flag
                'controllo esistenza flag
                If (ChiaveManutenzione.CategoriaFlag = FileFlag.Categoria.TARDIVO) AndAlso (ChiaveManutenzione.Esiste = False) Then

                    FlagErroreMetodo = False

                    Utx.GestioneFlag.CreaFlag(Utx.GestioneFlag.TipoFlag.LIVE_CHANGE)

                    Dim Notifica As New Utx.FormNotifica
                    With Notifica
                        .ColoreSfondo = Drawing.Color.PaleGreen
                        .Opacity = 0.8
                        .Text = ""
                        .Show()

                        .Messaggio = "Manutenzione dati..."
                    End With

                    Log.Info(String.Format("* Manutenzione {0:d}", ChiaveManutenzione.Key))
                    Log.AumentaRientro()

                    'dati comuni
                    Select Case ChiaveManutenzione.Key
                        Case "ResetCip"
                            Utx.GestioneFlag.CancellaFlag(GestioneFlag.TipoFlag.AUTO_LISTE_UTENTI)
                    End Select

                    'per ogni agenzia/codice gestito
                    For Each Agenzia As String In Utx.EnteGestore.CodiciGestiti
                        Notifica.Messaggio = String.Format("Manutenzione dati del {1:d}{0}codice agenzia {2}",
                                                           Environment.NewLine, ChiaveManutenzione.Descrizione, Agenzia)

                        Log.Info(String.Format("Agenzia {0}", Agenzia))
                        Log.AumentaRientro()

                        Select Case ChiaveManutenzione.Key
                            Case "25-01-2017"
                                Utx.RegistroAttivita.CreaTabellaTipoAttivita(Agenzia)
                            Case "ResetCalendarioSinistri3001"
                                ResetCalendarioOmnia(Agenzia, Utx.Enumerazioni.TipoFileMagia.Sinistri, Today, CDate("30/11/2018"))
                                ResetCalendarioOmnia(Agenzia, Utx.Enumerazioni.TipoFileMagia.AndamentoSinistri, CDate("30/12/2018"))
                                Utx.GestioneFlag.CreaFlag(Utx.GestioneFlag.TipoFlag.IMPORTA_DATI_OMNIA) 'blocco per 30 minuti per consentire il riavvio
                                Utx.GestioneFlag.CreaFlag(Utx.GestioneFlag.TipoFlag.DATI_OMNIA_DISPONIBILI)
                            Case "CorreggiSinistriDbUno"
                                CorreggiSinistriDbuno(Agenzia)
                            Case "ModificaDbSupporto2"
                                ModificaCampiSupporto()
                            Case "22-04-2017"
                                Utx.Globale.SettingInterop.Rimuovi(Utx.GestioneFlag.TipoFlag.AUTO_INCASSI)
                            Case "26-04-2017"
                                'per rifare il recupero canoni unibox
                                Utx.Globale.SettingGlobale.Rimuovi(String.Format("{0}_{1}", Utx.GestioneFlag.TipoFlag.RECUPERO_INCASSI_UNIBOX, Agenzia))
                            Case "ResetCip"
                                Utx.GestioneFlag.CancellaFlag(GestioneFlag.TipoFlag.AUTO_LISTE_UTENTI)
                            Case "AggiornaPostalizzazione"
                                AggiornaDbPostalizzazione(Agenzia)
                            Case "Postalizzazione"
                                Postalizzazione(Agenzia)
                            Case "AnomaliaSinistri10032019"
                                AnomaliaSinistri10032019(Agenzia)
                            Case "ForzaturaSinistri"
                                ForzaturaSinistri(Agenzia)
                            Case "Psico"
                                Psico(Agenzia)
                        End Select

                        Log.DiminuisciRientro()
                    Next

                    If FlagErroreMetodo = False Then
                        'crea flag
                        ChiaveManutenzione.CreaFlag()
                    End If
                    Notifica.Messaggio = "Manutenzione dati conclusa"
                    Notifica.Chiudi()
                End If
            Next

            PuliziaFlag()

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            Utx.Globale.SettingInterop.Rimuovi(Utx.GestioneFlag.TipoFlag.LIVE_CHANGE)
        End Try
    End Sub

    Public Shared ReadOnly Property ErroreGlobale() As Boolean
        Get
            Return FlagErroreGlobale
        End Get
    End Property

    Public Shared Sub MessaggioErroreManutenzione()
        'Utx.Sessione.InvitoAllaChiusura.Crea()
        'messaggio provvisorio fino all'andata a regime dell'invito alla chiusura
        MsgBox($"ATTENZIONE.

Si è verificato un errore in una operazione di manutenzione.
I database sono probabilmente bloccati da un altro utente.

Si consiglia di chiudere Unitools su tutti i pc e di riavviare l'applicazione su un solo pc per consentire la corretta esecuzione dell'operazione di manutenzione.",
                         MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
    End Sub

    Private Shared Sub PuliziaFlag()
        Try
            'elimino i flag non più definiti nell'enumerazione dei flag da eseguire
            For Each f As String In Directory.GetFiles(Utx.Globale.Paths.CartellaFlag, "LiveChange.*")
                If New FileFlag(f).Definito = False Then
                    File.Delete(f)
                End If
            Next
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Public Shared Function EsistenzaTabelleComuni() As Boolean
        Try
            Log.Info("NuoveTabelleComuni1")
            'copia il modello solo se non esiste la tabella
            Utx.GestioneModelli.CopiaModelloTabella("00000", Utx.ConnessioniDb.Db.SUPPORTO, "ApplicativoSinistri", CopiaDati:=True)
            Utx.GestioneModelli.CopiaModelloTabella("00000", Utx.ConnessioniDb.Db.SUPPORTO, "Comparto", CopiaDati:=True)
            Utx.GestioneModelli.CopiaModelloTabella("00000", Utx.ConnessioniDb.Db.SUPPORTO, "Tariffati", CopiaDati:=True)
            Utx.GestioneModelli.CopiaModelloTabella("00000", Utx.ConnessioniDb.Db.SUPPORTO, "AzioniSinistri", CopiaDati:=True)
            Utx.GestioneModelli.CopiaModelloTabella("00000", Utx.ConnessioniDb.Db.SMS, "UtentiCentralino", CopiaDati:=False)
            Return True
        Catch ex As Exception
            Errore(Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function AggiornamentoTabelleComuni() As Boolean
        Try
            Log.Info("NuoveTabelleComuni2")
            'sovrascrivi la vecchia tabella
            Utx.GestioneModelli.CopiaModelloTabella("00000", Utx.ConnessioniDb.Db.SUPPORTO, "Carrozzeria", CopiaDati:=True, Sovrascrivi:=True)
            Utx.GestioneModelli.CopiaModelloTabella("00000", Utx.ConnessioniDb.Db.SUPPORTO, "CompagniaANIA", CopiaDati:=True, Sovrascrivi:=True)
            Utx.GestioneModelli.CopiaModelloTabella("00000", Utx.ConnessioniDb.Db.SUPPORTO, "Comuni", CopiaDati:=True, Sovrascrivi:=True)
            Utx.GestioneModelli.CopiaModelloTabella("00000", Utx.ConnessioniDb.Db.SUPPORTO, "Convenzioni", CopiaDati:=True, Sovrascrivi:=True)
            Utx.GestioneModelli.CopiaModelloTabella("00000", Utx.ConnessioniDb.Db.SUPPORTO, "Ispettorato", CopiaDati:=True, Sovrascrivi:=True)
            Utx.GestioneModelli.CopiaModelloTabella("00000", Utx.ConnessioniDb.Db.SUPPORTO, "MercatoPreferenziale", CopiaDati:=True, Sovrascrivi:=True)
            Utx.GestioneModelli.CopiaModelloTabella("00000", Utx.ConnessioniDb.Db.SUPPORTO, "Prodotti", CopiaDati:=True, Sovrascrivi:=True)
            Utx.GestioneModelli.CopiaModelloTabella("00000", Utx.ConnessioniDb.Db.SUPPORTO, "Professioni", CopiaDati:=True, Sovrascrivi:=True)
            Utx.GestioneModelli.CopiaModelloTabella("00000", Utx.ConnessioniDb.Db.SUPPORTO, "RamoGest", CopiaDati:=True, Sovrascrivi:=True)
            Utx.GestioneModelli.CopiaModelloTabella("00000", Utx.ConnessioniDb.Db.SUPPORTO, "TipoRami", CopiaDati:=True, Sovrascrivi:=True)
            Utx.GestioneModelli.CopiaModelloTabella("00000", Utx.ConnessioniDb.Db.SUPPORTO, "TipoRamiSinistro", CopiaDati:=True, Sovrascrivi:=True)
            Utx.GestioneModelli.CopiaModelloTabella("00000", Utx.ConnessioniDb.Db.SUPPORTO, "TipoSinistro", CopiaDati:=True, Sovrascrivi:=True)
            Utx.GestioneModelli.CopiaModelloTabella("00000", Utx.ConnessioniDb.Db.SUPPORTO, "TipoStorni", CopiaDati:=True, Sovrascrivi:=True)
            Utx.GestioneModelli.CopiaModelloTabella("00000", Utx.ConnessioniDb.Db.SUPPORTO, "TipoStatiCliente", CopiaDati:=True, Sovrascrivi:=True)
            Utx.GestioneModelli.CopiaModelloTabella("00000", Utx.ConnessioniDb.Db.SUPPORTO, "DocUpload", CopiaDati:=True, Sovrascrivi:=True)
            Return True
        Catch ex As Exception
            Errore(Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function NuoveTabelleAgenzia(CodiceAgenzia As String) As Boolean
        Try
            Log.Info("NuoveTabelleAgenzia")
            'copia il modello solo se non esiste la tabella
            '+INFO
            If Utx.ConnessioniDb.EsisteDb(CodiceAgenzia, ConnessioniDb.Db.INFO) Then
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.INFO, "CalendarioOmnia")
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.INFO, "RegistroAttivita")
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.INFO, "TipoAttivita")
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.INFO, "Cip")
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.INFO, "Soggetti")
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.INFO, "Utenze")
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.INFO, "Punti_Vendita")
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.INFO, "GruppiCip")
            End If
            '+SINISTRI
            If Utx.ConnessioniDb.EsisteDb(CodiceAgenzia, ConnessioniDb.Db.SINISTRI) Then
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.SINISTRI, "SinistriControparte")
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.SINISTRI, "RegistroAzioni")
            End If
            '+INCASSI
            If Utx.ConnessioniDb.EsisteDb(CodiceAgenzia, ConnessioniDb.Db.INCASSI) Then
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.INCASSI, "MonitorQT_KMS")
            End If
            Return True
        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function NormalizzaArchivioSinistri(CodiceAgenzia As String) As Boolean
        Try
            'nel caso non sia ancora avvenuta la rinomina da sinistri a sinistriDP
            RinominaSinistriDP(CodiceAgenzia)

            'per passaggio alla struttura del nuovo UT
            Log.Info("NormalizzaArchivioSinistri")

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.SINISTRI))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text

                    'modifico il campo a intero lungo
                    cmd.CommandText = "ALTER TABLE SinistriDP ALTER COLUMN AgenziaPolizza INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE SinistriDP ALTER COLUMN FlagUtente TEXT(8)"
                    cmd.ExecuteNonQuery()

                    'creo tabella Delega Altrui DA 
                    If Utx.FunzioniDb.EsisteTabella(c, "SinistriDA") = True Then
                        'la tabella esiste e la modifico
                        cmd.CommandText = "ALTER TABLE SinistriDA ALTER COLUMN AgenziaPolizza INTEGER"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE SinistriDA ALTER COLUMN FlagUtente TEXT(8)"
                        cmd.ExecuteNonQuery()
                    Else
                        'non esiste la creo
                        cmd.CommandText = "SELECT * INTO SinistriDA FROM Sinistri WHERE TipoDelega = '2'"
                        cmd.ExecuteNonQuery()
                    End If
                    'cancello dalla tabella sinistri dove devono restare solo i DP
                    cmd.CommandText = "DELETE * FROM SinistriDP WHERE TipoDelega = '2'"
                    cmd.ExecuteNonQuery()

                    'creo la tabella Altra Compagnia
                    If Utx.FunzioniDb.EsisteTabella(c, "SinistriAC") = True Then
                        cmd.CommandText = "ALTER TABLE SinistriAC ALTER COLUMN AgenziaPolizza INTEGER"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE SinistriAC ALTER COLUMN FlagUtente TEXT(8)"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "INSERT INTO SinistriAC SELECT * FROM Sinistri WHERE AgenziaSinistro < 10"
                        cmd.ExecuteNonQuery()
                    Else
                        cmd.CommandText = "SELECT * INTO SinistriAC FROM Sinistri WHERE AgenziaSinistro < 10"
                        cmd.ExecuteNonQuery()
                    End If
                    cmd.CommandText = "DELETE * FROM SinistriDP WHERE AgenziaSinistro < 10"
                    cmd.ExecuteNonQuery()

                    'sistemo stato tecnico e bilancistico per vecchi sinistri
                    cmd.CommandText = "UPDATE SinistriDP " +
                                      "SET StatoTecnico = TipoChiusura, StatoBilancistico = '00' " +
                                      "WHERE (Trim(StatoTecnico) = '') OR (StatoTecnico IS NULL)"
                    cmd.ExecuteNonQuery()

                    'modifico campo per sub/prod
                    cmd.CommandText = "ALTER TABLE SinistriDP ALTER COLUMN CodiceSubAgenteSima INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE SinistriDP ALTER COLUMN CodiceProduttoreSima INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE SinistriDA ALTER COLUMN CodiceSubAgenteSima INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE SinistriDA ALTER COLUMN CodiceProduttoreSima INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE SinistriAC ALTER COLUMN CodiceSubAgenteSima INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE SinistriAC ALTER COLUMN CodiceProduttoreSima INTEGER"
                    cmd.ExecuteNonQuery()
                    'liquidatore
                    cmd.CommandText = "ALTER TABLE SinistriDP ALTER COLUMN CodiceLiquidatore INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE SinistriDA ALTER COLUMN CodiceLiquidatore INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE SinistriAC ALTER COLUMN CodiceLiquidatore INTEGER"
                    cmd.ExecuteNonQuery()
                    'modifico campo IdCartella da numerico a stringa di 9 caratteri
                    cmd.CommandText = "ALTER TABLE SinistriDP ALTER COLUMN IdCartella TEXT(9)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE SinistriDA ALTER COLUMN IdCartella TEXT(9)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE SinistriAC ALTER COLUMN IdCartella TEXT(9)"
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            'elimino sinistri extra che non serve più
            File.Delete(Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.SINISTRIEXTRA))

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            'provo con l'apertura esclusiva del DB
            Return NormalizzaArchivioSinistriEx(CodiceAgenzia)
        End Try
    End Function

    Public Shared Function ModificaDbUt(CodiceAgenzia As String) As Boolean
        Try
            'per passaggio alla struttura del nuovo UT
            Log.Info("ModificaDbUt")

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Path.Combine(Utx.Globale.Paths.CartellaModelli, "DbUt.mdb"))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c

                    For Each campo As String In "flag_coass_33;1/classificazione;20/id_evento_atmos;20".Split("/")
                        Dim NomeCampo As String = campo.Split(";")(0)
                        Dim DimCampo As String = campo.Split(";")(1)

                        If Utx.FunzioniDb.EsisteCampo(c, "SinistriAia", NomeCampo) = False Then
                            cmd.CommandText = String.Format("ALTER TABLE SinistriAIA ADD COLUMN [{0}] TEXT({1})", NomeCampo, DimCampo)
                            cmd.ExecuteNonQuery()
                        End If
                    Next

                    If Utx.FunzioniDb.EsisteCampo(c, "SinistriAia", "ramo_gest") = False Then
                        cmd.CommandText = "ALTER TABLE SinistriAIA ADD COLUMN [ramo_gest] INT"
                        cmd.ExecuteNonQuery()
                    End If
                End Using
            End Using
            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function NormalizzaArchivioSinistriEx(CodiceAgenzia As String) As Boolean
        Try
            'nel caso non sia ancora avvenuta la rinomina da sinistri a sinistriDP
            RinominaSinistriDP(CodiceAgenzia)

            'per passaggio alla struttura del nuovo UT
            Log.Info("NormalizzaArchivioSinistri")

            Using c As New OleDbConnection(Utx.Globale.MDBDriverExclusive + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.SINISTRI))
                Try
                    c.Open()
                Catch ex As Exception
                    MsgBox("Per effettuare  quasta manutenzione è necessario l'uso esclusivo del database. Far chiudere l'applicazione agli altri utenti e riprovare.",
                           MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                    Return False
                End Try

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text

                    'modifico il campo a intero lungo
                    cmd.CommandText = "ALTER TABLE SinistriDP ALTER COLUMN AgenziaPolizza INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE SinistriDP ALTER COLUMN FlagUtente TEXT(8)"
                    cmd.ExecuteNonQuery()

                    'creo tabella Delega Altrui DA 
                    If Utx.FunzioniDb.EsisteTabella(c, "SinistriDA") = True Then
                        'la tabella esiste e la modifico
                        cmd.CommandText = "ALTER TABLE SinistriDA ALTER COLUMN AgenziaPolizza INTEGER"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE SinistriDA ALTER COLUMN FlagUtente TEXT(8)"
                        cmd.ExecuteNonQuery()
                    Else
                        'non esiste la creo
                        cmd.CommandText = "SELECT * INTO SinistriDA FROM Sinistri WHERE TipoDelega = '2'"
                        cmd.ExecuteNonQuery()
                    End If
                    'cancello dalla tabella sinistri dove devono restare solo i DP
                    cmd.CommandText = "DELETE * FROM SinistriDP WHERE TipoDelega = '2'"
                    cmd.ExecuteNonQuery()

                    'creo la tabella Altra Compagnia
                    If Utx.FunzioniDb.EsisteTabella(c, "SinistriAC") = True Then
                        cmd.CommandText = "ALTER TABLE SinistriAC ALTER COLUMN AgenziaPolizza INTEGER"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE SinistriAC ALTER COLUMN FlagUtente TEXT(8)"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "INSERT INTO SinistriAC SELECT * FROM Sinistri WHERE AgenziaSinistro < 10"
                        cmd.ExecuteNonQuery()
                    Else
                        cmd.CommandText = "SELECT * INTO SinistriAC FROM Sinistri WHERE AgenziaSinistro < 10"
                        cmd.ExecuteNonQuery()
                    End If
                    cmd.CommandText = "DELETE * FROM SinistriDP WHERE AgenziaSinistro < 10"
                    cmd.ExecuteNonQuery()

                    'sistemo stato tecnico e bilancistico per vecchi sinistri
                    cmd.CommandText = "UPDATE SinistriDP " +
                                      "SET StatoTecnico = TipoChiusura, StatoBilancistico = '00' " +
                                      "WHERE (Trim(StatoTecnico) = '') OR (StatoTecnico IS NULL)"
                    cmd.ExecuteNonQuery()

                    'modifico campo per sub/prod
                    cmd.CommandText = "ALTER TABLE SinistriDP ALTER COLUMN CodiceSubAgenteSima INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE SinistriDP ALTER COLUMN CodiceProduttoreSima INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE SinistriDA ALTER COLUMN CodiceSubAgenteSima INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE SinistriDA ALTER COLUMN CodiceProduttoreSima INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE SinistriAC ALTER COLUMN CodiceSubAgenteSima INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE SinistriAC ALTER COLUMN CodiceProduttoreSima INTEGER"
                    cmd.ExecuteNonQuery()
                    'liquidatore
                    cmd.CommandText = "ALTER TABLE SinistriDP ALTER COLUMN CodiceLiquidatore INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE SinistriDA ALTER COLUMN CodiceLiquidatore INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE SinistriAC ALTER COLUMN CodiceLiquidatore INTEGER"
                    cmd.ExecuteNonQuery()
                    'modifico campo IdCartella da numerico a stringa di 9 caratteri
                    cmd.CommandText = "ALTER TABLE SinistriDP ALTER COLUMN IdCartella TEXT(9)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE SinistriDA ALTER COLUMN IdCartella TEXT(9)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE SinistriAC ALTER COLUMN IdCartella TEXT(9)"
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            'elimino sinistri extra che non serve più
            File.Delete(Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.SINISTRIEXTRA))

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function UpdateArchivioSinistri(CodiceAgenzia As String) As Boolean
        Try
            Log.Info("UpdateArchivioSinistri")

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.SINISTRI))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    'normalizzo il campo referente
                    cmd.CommandText = "UPDATE SinistriDP SET IdGestione = '' WHERE IdGestione IS NULL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE SinistriDA SET IdGestione = '' WHERE IdGestione IS NULL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE SinistriAC SET IdGestione = '' WHERE IdGestione IS NULL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE SinistriDP SET Compagnia = 1 WHERE (Compagnia IS NULL) OR (Len(Trim(Compagnia)) = 0)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE SinistriDA SET Compagnia = 1 WHERE (Compagnia IS NULL) OR (Len(Trim(Compagnia)) = 0)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE SinistriAC SET Compagnia = 1 WHERE (Compagnia IS NULL) OR (Len(Trim(Compagnia)) = 0)"
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function AggiornaAndamentoSinistri(CodiceAgenzia As String) As Boolean
        Try
            Log.Info("AggiornaAndamentoSinistri")

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.ANDAMENTI))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    'aggiungo i nuovi campi
                    If Utx.FunzioniDb.EsisteCampo(c, "AndamentoSinistri", "StatoTecnico") = False Then
                        cmd.CommandText = "ALTER TABLE AndamentoSinistri ADD COLUMN StatoTecnico TEXT(2)"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "AndamentoSinistri", "StatoBilancistico") = False Then
                        cmd.CommandText = "ALTER TABLE AndamentoSinistri ADD COLUMN StatoBilancistico TEXT(2)"
                        cmd.ExecuteNonQuery()
                    End If
                    cmd.CommandText = "UPDATE AndamentoSinistri SET StatoTecnico = '' WHERE StatoTecnico IS NULL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE AndamentoSinistri SET StatoBilancistico = '' WHERE StatoBilancistico IS NULL"
                    cmd.ExecuteNonQuery()
                    'correggo il marcatore delle riserve
                    cmd.CommandText = "UPDATE AndamentoSinistri SET TipoChiusura = 'RB' " +
                                      "WHERE (Format(AnnoMeseCompetenza, 'dd/MM') = '31/12') AND (RiservaBilancio <> NULL)"
                    cmd.ExecuteNonQuery()
                End Using

                Utx.FunzioniDb.DistinctTabella("AndamentoSinistri", c)
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function NormalizzaArchivioDbUno(CodiceAgenzia As String) As Boolean
        'per modificare DbUno se già esiste
        Try
            Log.Info("NormalizzaArchivioDbUno")

            Dim ao As New Utx.AgenziaFigliaOmnia(CodiceAgenzia, Utx.Globale.ProfiloEnteGestore.CodiceSede, False)

            If File.Exists(ao.Cartelle.DatabaseDbUno) Then
                Using c As New OleDbConnection(Utx.Globale.MDBDriverExclusive + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO))
                    Try
                        c.Open()
                    Catch ex As Exception
                        MsgBox("Per effettuare  quasta manutenzione è necessario l'uso esclusivo del database. Far chiudere l'applicazione agli altri utenti e riprovare.",
                               MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                        Return False
                    End Try

                    Using cmd As New OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text

                        Log.Info("modifico campi")
                        cmd.CommandText = "ALTER TABLE Polizze1 ALTER COLUMN CodiceSubAgenzia INTEGER"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE Polizze1 ALTER COLUMN CodiceProduttore INTEGER"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE PolizzeRipartizionePremio ALTER COLUMN CodiceCategoriaRischio INTEGER"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE PolizzeClausole ALTER COLUMN Clausola INTEGER"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE Sinistri ALTER COLUMN AgenziaPolizza INTEGER"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE Sinistri ALTER COLUMN CodiceSubAgenzia INTEGER"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE Sinistri ALTER COLUMN CodiceProduttore INTEGER"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE Clienti ALTER COLUMN SubAgenzia INTEGER"
                        cmd.ExecuteNonQuery()
                        If Utx.FunzioniDb.EsisteCampo(c, "arp002_file", "RecordsImportati") = False Then
                            cmd.CommandText = "ALTER TABLE arp002_file ADD COLUMN RecordsImportati INTEGER"
                            cmd.ExecuteNonQuery()
                        End If
                        If Utx.FunzioniDb.EsisteCampo(c, "arp002_file", "RecordsScartati") = False Then
                            cmd.CommandText = "ALTER TABLE arp002_file ADD COLUMN RecordsScartati INTEGER"
                            cmd.ExecuteNonQuery()
                        End If
                        If Utx.FunzioniDb.EsisteCampo(c, "Incarichi", "ProgressivoFile") = False Then
                            'correzione del 18/01/2018
                            cmd.CommandText = "ALTER TABLE Incarichi ADD COLUMN ProgressivoFile INTEGER"
                            cmd.ExecuteNonQuery()
                            cmd.CommandText = "UPDATE Incarichi SET ProgressivoFile = 180101001 WHERE ProgressivoFile IS NULL OR ProgressivoFile = 0"
                            cmd.ExecuteNonQuery()
                        End If
                        'correzione per il file del 2/11/2018 letto male in alcune agenzie
                        If Today < CDate("01/12/2018") Then
                            cmd.CommandText = "DELETE FROM arp002_file WHERE dataestrazione = #11/2/2018#"
                            cmd.ExecuteNonQuery()
                            ResetCalendarioOmnia(CodiceAgenzia, Enumerazioni.TipoFileMagia.Sinistri, CDate("30/10/2018"))
                        End If

                        Log.Info("creo vincoli")
                        Utx.FunzioniDb.CreaVincoliDbUno(CodiceAgenzia)

                        Log.Info("distinct su tabelle incarichi e titoli")
                        Utx.FunzioniDb.DistinctTabella("Incarichi", c)
                        Utx.FunzioniDb.DistinctTabella("Titoli", c)
                    End Using
                End Using
            End If

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function DistinctDbUno(CodiceAgenzia As String) As Boolean
        'per modificare DbUno se già esiste
        Try
            Dim ao As New Utx.AgenziaFigliaOmnia(CodiceAgenzia, Utx.Globale.ProfiloEnteGestore.CodiceSede, False)

            If File.Exists(ao.Cartelle.DatabaseDbUno) Then
                Using c As New OleDbConnection(ao.ConnectionStringDbUno)
                    c.Open()
                    'distinct su tabelle incarichi e titoli
                    Utx.FunzioniDb.DistinctTabella("Incarichi", c)
                    Utx.FunzioniDb.DistinctTabella("Titoli", c)
                End Using
            End If

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function ManutenzionePeriti(CodiceAgenzia As String) As Boolean
        Try
            Dim ao As New Utx.AgenziaFigliaOmnia(CodiceAgenzia, Utx.Globale.ProfiloEnteGestore.CodiceSede, False)

            If File.Exists(ao.Cartelle.DatabaseDbUno) Then
                Using c As New OleDbConnection(ao.ConnectionStringDbUno)
                    c.Open()

                    'sistemo la tabella periti
                    Utx.FunzioniDb.CancellaTabella(c, "TempPeriti")

                    Using cmd As New OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "SELECT DISTINCT datacompetenzaelaborazione,codicepuntovendita,progressivo,tipoelaborazione,codiceperito," +
                                                          "tipoperito,cognome,nome,codicefiscale,telefono,cellulare,email,A.codiceperitosap " +
                                          "INTO TempPeriti FROM Periti AS A " +
                                          "INNER JOIN (SELECT Max(DataCompetenzaElaborazione) AS Aggiornamento,CodicePeritoSAP FROM Periti GROUP BY CodicePeritoSAP) AS B " +
                                          "ON A.DataCompetenzaElaborazione = B.Aggiornamento AND A.CodicePeritoSAP = B.CodicePeritoSAP"
                        cmd.ExecuteNonQuery()

                        cmd.CommandText = "DELETE * FROM Periti"
                        cmd.ExecuteNonQuery()

                        cmd.CommandText = "INSERT INTO Periti SELECT * FROM TempPeriti"
                        cmd.ExecuteNonQuery()

                        'aggiungo la chiave. prima la cancello nel caso esista
                        Try
                            cmd.CommandText = "ALTER TABLE Periti DROP CONSTRAINT pk_periti"
                            cmd.ExecuteNonQuery()
                        Catch ex As Exception
                        End Try
                        cmd.CommandText = "ALTER TABLE Periti ADD CONSTRAINT pk_periti PRIMARY KEY (CodicePeritoSAP)"
                        cmd.ExecuteNonQuery()
                    End Using

                    Utx.FunzioniDb.CancellaTabella(c, "TempPeriti")
                End Using
            End If

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function NormalizzaArchivioNote(CodiceAgenzia As String) As Boolean
        'modifica la tabella note in tutti i codici gestiti
        Try
            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.NOTE))
                c.Open()

                If Utx.FunzioniDb.EsisteCampo(c, "SinistriMemo", "IdNota") = True Then
                    Return True
                End If

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    'modifico la tabella
                    cmd.CommandText = "ALTER TABLE SinistriMemo ADD COLUMN IdNota TEXT(20)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE SinistriMemo ADD COLUMN CodiceFiscale TEXT(16)"
                    cmd.ExecuteNonQuery()
                    'update campo id
                    cmd.CommandText = "UPDATE SinistriMemo " +
                                      "SET IdNota = '1-' + Format(AgenziaSinistro,'0000') + '-' + " +
                                                          "Format(EsercizioSinistro,'0000') + '-' + " +
                                                          "Format(NumeroSinistro,'0000000')"
                    cmd.ExecuteNonQuery()

                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "UPDATE SinistriMemo AS m " +
                                      "INNER JOIN (SELECT EsercizioSinistro,AgenziaSinistro,NumeroSinistro,CODICEFISCCONTRPOL " +
                                                  "FROM Sinistri IN '{0}') AS s " +
                                      "ON Val(Mid(m.IdNota,3,4)) = s.AgenziaSinistro AND " +
                                         "Val(Mid(m.IdNota,8,4)) = s.EsercizioSinistro AND " +
                                         "Val(Mid(m.IdNota,13,7)) = s.NumeroSinistro " +
                                      "SET m.CodiceFiscale = s.CODICEFISCCONTRPOL"
                    cmd.CommandText = String.Format(cmd.CommandText, Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.SINISTRI))
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "UPDATE SinistriMemo " +
                                      "SET CodiceFiscale = 'ND' " +
                                      "WHERE (CodiceFiscale IS NULL) OR (CodiceFiscale = '')"
                    cmd.ExecuteNonQuery()

                    'cancello i campi che non servono più
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "ALTER TABLE SinistriMemo DROP COLUMN AgenziaSinistro,EsercizioSinistro,NumeroSinistro"
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function NormalizzaArchivioPolizze(CodiceAgenzia As String) As Boolean
        'modifica campi nella tabella polizze, movpolizze (ptfcanc) e BDA
        Try
            Log.Info("NormalizzaArchivioPolizze")

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.POLIZZE))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    'modifico la tabella
                    cmd.CommandText = "ALTER TABLE Polizze ALTER COLUMN Targa TEXT(20)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE Polizze ALTER COLUMN ClasseRca TEXT(3)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE MovPolizze ALTER COLUMN Targa TEXT(20)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE MovPolizze ALTER COLUMN ClasseRca TEXT(3)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE BDA ALTER COLUMN Targa TEXT(20)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE BDA ALTER COLUMN ClasseRca TEXT(3)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE Polizze ALTER COLUMN CodiceSubAgente INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE Polizze ALTER COLUMN CodiceSubAgenteSIMA INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE Polizze ALTER COLUMN CodiceProduttore INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE Polizze ALTER COLUMN CodiceProduttoreSIMA INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE Polizze ALTER COLUMN Frazionamento INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE Polizze ALTER COLUMN CavalliFiscali INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE MovPolizze ALTER COLUMN CodiceSubAgente INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE MovPolizze ALTER COLUMN CodiceSubAgenteSIMA INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE MovPolizze ALTER COLUMN CodiceProduttore INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE MovPolizze ALTER COLUMN CodiceProduttoreSIMA INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE MovPolizze ALTER COLUMN Frazionamento INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE MovPolizze ALTER COLUMN CavalliFiscali INTEGER"
                    cmd.ExecuteNonQuery()
                    'update
                    cmd.CommandText = "UPDATE Bda SET ClasseRca = Right('000' + ClasseRca,3)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE Polizze SET TotalePremioAnnuo = 0 WHERE TotalePremioAnnuo IS NULL"
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function ModificaMovPolizze(CodiceAgenzia As String) As Boolean
        Try
            Log.Info("ModificaMovPolizze")

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.POLIZZE))
                c.Open()
                'rimuovo il campo dataemissionestorno
                If Utx.FunzioniDb.EsisteCampo(c, "MovPolizze", "DataEmissioneStorno") = True Then

                    Using cmd As New OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        'modifico la tabella
                        cmd.CommandText = "ALTER TABLE MovPolizze DROP COLUMN DataEmissioneStorno"
                        cmd.ExecuteNonQuery()
                    End Using
                End If
                'aggiungo il campo dataelaborazione
                If Utx.FunzioniDb.EsisteCampo(c, "MovPolizze", "DataElaborazione") = False Then

                    Using cmd As New OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        'modifico la tabella
                        cmd.CommandText = "ALTER TABLE MovPolizze ADD COLUMN DataElaborazione DATE"
                        cmd.ExecuteNonQuery()
                        'aggiorno il campo
                        cmd.CommandText = "UPDATE MovPolizze " +
                                          "SET DataElaborazione = CDate('01/' + Right(AnnoMeseCompetenza,2) + '/' + Left(AnnoMeseCompetenza,4)) " +
                                          "WHERE DataElaborazione IS NULL"
                        cmd.ExecuteNonQuery()
                    End Using
                End If
            End Using
            'azzero calendario omnia per ptfcanc
            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.INFO))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = String.Format("DELETE FROM CalendarioOmnia WHERE TipoFile = '{0}'",
                                                    Utx.Enumerazioni.Funzioni.CodiceFileMagia(Utx.Enumerazioni.TipoFileMagia.MovimentiPTF))
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function NormalizzaArchivioClienti(CodiceAgenzia As String) As Boolean
        'per passaggio alla struttura del nuovo UT
        Try
            Log.Info("NormalizzaArchivioClienti")

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.CLIENTI))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "ALTER TABLE Clienti ALTER COLUMN Cap TEXT(5)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE Clienti ALTER COLUMN SubAgenzia INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE Clienti ALTER COLUMN SubAgenziaSIMA INTEGER"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE Clienti ALTER COLUMN Indirizzo TEXT(60)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "ALTER TABLE Clienti ALTER COLUMN Localita TEXT(40)"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE Clienti SET Cap = Right('00000' + Trim(Cap),5)"
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function UpdateTabellaSinistri(CodiceAgenzia As String) As Boolean
        Try
            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO))
                c.Open()

                Log.Info("Manutenzione record doppi sinistri-dbuno")
                Utx.FunzioniDb.CancellaTabella(c, "TempSin")

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    'manutenzione record doppi
                    cmd.CommandText = "SELECT A.* INTO TempSin FROM Sinistri AS A INNER JOIN " +
                                      "(SELECT DataElaborazione,Compagnia,AgenziaSinistro,EsercizioSinistro,NumeroSinistro,COUNT(*) " +
                                      "FROM Sinistri GROUP BY DataElaborazione,Compagnia,AgenziaSinistro,EsercizioSinistro,NumeroSinistro " +
                                      "HAVING COUNT(*) > 1) AS B " +
                                      "ON A.Compagnia = B.Compagnia AND A.AgenziaSinistro = B.AgenziaSinistro AND A.EsercizioSinistro = B.EsercizioSinistro AND " +
                                         "A.NumeroSinistro = B.NumeroSinistro AND A.DataElaborazione = B.DataElaborazione"
                    If cmd.ExecuteNonQuery() > 0 Then
                        cmd.CommandText = "DELETE DISTINCTROW A.* FROM Sinistri AS A INNER JOIN TempSin AS B " +
                                      "ON A.Compagnia = B.Compagnia And A.AgenziaSinistro = B.AgenziaSinistro And A.EsercizioSinistro = B.EsercizioSinistro And " +
                                         "A.NumeroSinistro = B.NumeroSinistro And A.DataElaborazione = B.DataElaborazione"
                        cmd.ExecuteNonQuery()

                        Dim dt, dtUni As New DataTable

                        cmd.CommandText = "SELECT * FROM TempSin"
                        Using da As New OleDbDataAdapter(cmd)
                            da.Fill(dt)
                            dtUni = dt.Clone
                            dtUni.PrimaryKey = {dtUni.Columns("Compagnia"), dtUni.Columns("AgenziaSinistro"), dtUni.Columns("EsercizioSinistro"), dtUni.Columns("NumeroSinistro")}

                            For Each dr As DataRow In dt.Rows
                                If dtUni.Rows.Find({dr("Compagnia"), dr("AgenziaSinistro"), dr("EsercizioSinistro"), dr("NumeroSinistro")}) Is Nothing Then
                                    dtUni.Rows.Add(dr.ItemArray)
                                End If
                            Next
                        End Using

                        cmd.CommandText = "SELECT * FROM Sinistri"
                        Using da As New OleDbDataAdapter(cmd)
                            Using cb As New OleDbCommandBuilder(da)
                                da.InsertCommand = cb.GetInsertCommand
                                da.Update(dtUni)
                            End Using
                        End Using
                    End If
                    Utx.FunzioniDb.CancellaTabella(c, "TempSin")

                    'sinistri cognome/nome NULL
                    Log.Info("Manutenzione DbUno cognome/nome cliente")
                    cmd.CommandText = "UPDATE Sinistri SET CognomeAssicurato = '' WHERE CognomeAssicurato IS NULL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE Sinistri SET NomeAssicurato = '' WHERE NomeAssicurato IS NULL"
                    cmd.ExecuteNonQuery()

                    'non serve più. portato in specifica
                    'manutenzione dbuno tipo delega NULL
                    'Log.Info("Manutenzione DbUno tipo delega")
                    'cmd.CommandText = "UPDATE Sinistri SET tipodelega = '0' WHERE tipodelega=''"
                    'cmd.ExecuteNonQuery()

                    'non serve più. portato in specifica
                    'stati da lunghi in codice ../LT/LP/SS
                    Log.Info("Manutenzione stati dbuno")
                    For Each campo As String In "StatoBilancistico;StatoTecnico;StatoAmministrativo;StatoRecupero;StatoForfait".Split(";")
                        Log.Info(String.Format("Manutenzione DbUno stato sinistro: campo={0}", campo))
                        cmd.CommandText = String.Format("UPDATE Sinistri SET {0} = '..' WHERE {0} = 'APERTO'", campo)
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = String.Format("UPDATE Sinistri SET {0} = 'LT' WHERE {0} = 'LIQUIDATO_TOTALE'", campo)
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = String.Format("UPDATE Sinistri SET {0} = 'LP' WHERE {0} = 'LIQUIDATO_PARZIALE'", campo)
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = String.Format("UPDATE Sinistri SET {0} = 'SS' WHERE {0} = 'SENZA_SEGUITO'", campo)
                        cmd.ExecuteNonQuery()
                    Next
                End Using
            End Using
            Return True

        Catch ex As Exception
            Errore(Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Sub UpdateArchivi(CodiceAgenzia As String)
        'in cognome e nome stringa vuota al posto di NULL
        'clienti
        Try
            Log.Info("UpdateArchivi")

            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(CodiceAgenzia, Utx.ConnessioniDb.Db.CLIENTI))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    'modifico la tabella
                    cmd.CommandText = "UPDATE Clienti SET Cognome = '' WHERE Cognome IS NULL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE Clienti SET Nome = '' WHERE Nome IS NULL"
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Log.Info(ex.Message)
        End Try

        'polizze
        Try
            'il comando replace sql non funziona da codice
            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(CodiceAgenzia, Utx.ConnessioniDb.Db.POLIZZE))
                c.Open()

                'tolgo gli spazi bianchi dalle terghe
                Dim da As New OleDbDataAdapter("SELECT Agenzia,Ramo,Polizza,Targa FROM Polizze WHERE NOT Targa IS NULL", c)
                Dim dt As New DataTable
                da.Fill(dt)

                For Each dr As DataRow In dt.Rows
                    dr("Targa") = Replace(dr("Targa"), " ", "")
                Next

                'creo l'update command
                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "UPDATE Polizze " +
                                      "SET Targa = ? " +
                                      "WHERE Agenzia = ? AND Ramo = ? AND Polizza = ?"

                    With cmd.Parameters
                        .AddWithValue("Targa", dt).SourceColumn = "Targa"
                        .AddWithValue("Agenzia", dt).SourceColumn = "Agenzia"
                        .AddWithValue("Ramo", dt).SourceColumn = "Ramo"
                        .AddWithValue("Polizza", dt).SourceColumn = "Polizza"
                    End With
                    'aggiorno il db
                    da.UpdateCommand = cmd
                    da.Update(dt)

                    'normalizzo convenzioni
                    cmd.CommandText = "UPDATE Polizze SET Convenzione = 0 WHERE Convenzione IS NULL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE MovPolizze SET Convenzione = 0 WHERE Convenzione IS NULL"
                    cmd.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            Log.Info(ex.Message)
        End Try

        'sinistri
        Try
            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(CodiceAgenzia, Utx.ConnessioniDb.Db.SINISTRI))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    'modifico la tabella
                    cmd.CommandText = "UPDATE Sinistri SET CognomeAssicurato = '' WHERE CognomeAssicurato IS NULL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE Sinistri SET NomeAssicurato = '' WHERE NomeAssicurato IS NULL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE SinistriDA SET CognomeAssicurato = '' WHERE CognomeAssicurato IS NULL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE SinistriDA SET NomeAssicurato = '' WHERE NomeAssicurato IS NULL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE SinistriAC SET CognomeAssicurato = '' WHERE CognomeAssicurato IS NULL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE SinistriAC SET NomeAssicurato = '' WHERE NomeAssicurato IS NULL"
                    cmd.ExecuteNonQuery()
                    'elimino doppioni incarichi
                    cmd.CommandText = "DELETE DISTINCTROW A.* FROM SIncarichi AS A " +
                                      "INNER JOIN (SELECT AgenziaSinistro,EsercizioSinistro,NumeroSinistro,Posizione,DataIncarico," +
                                                         "CodicePeritoSAP,TipoIncaricoCC,Max(DataCompetenza) AS UltimoAggiornamento " +
                                                  "FROM SIncarichi " +
                                                  "GROUP BY AgenziaSinistro,EsercizioSinistro,NumeroSinistro,Posizione,DataIncarico,CodicePeritoSAP," +
                                                           "TipoIncaricoCC " +
                                                  "HAVING Count(*) > 1) AS B " +
                                      "ON A.AgenziaSinistro = B.AgenziaSinistro AND A.EsercizioSinistro = B.EsercizioSinistro AND " +
                                         "A.NumeroSinistro = B.NumeroSinistro AND A.Posizione = B.Posizione AND A.DataIncarico = B.DataIncarico AND " +
                                         "A.CodicePeritoSAP = B.CodicePeritoSAP AND A.TipoIncaricoCC = B.TipoIncaricoCC " +
                                      "WHERE A.DataCompetenza < B.UltimoAggiornamento"
                    cmd.ExecuteNonQuery()
                    'sistemo incarichi con esercizio/agenzia invertiti
                    cmd.CommandText = "UPDATE SIncarichi " +
                                      "SET AgenziaSinistro = EsercizioSinistro,EsercizioSinistro = AgenziaSinistro " +
                                      "WHERE EsercizioSinistro > 3000"
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Log.Info(ex.Message)
        End Try

        'dbuno
        Try
            'manutenzione tabella sinistri dbuno
            UpdateTabellaSinistri(CodiceAgenzia)

            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    'clienti
                    cmd.CommandText = "UPDATE Clienti SET Cognome = '' WHERE Cognome IS NULL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE Clienti SET Nome = '' WHERE Nome IS NULL"
                    cmd.ExecuteNonQuery()
                    'sinistri
                    cmd.CommandText = "UPDATE Sinistri SET CognomeAssicurato = '' WHERE CognomeAssicurato IS NULL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE Sinistri SET NomeAssicurato = '' WHERE NomeAssicurato IS NULL"
                    cmd.ExecuteNonQuery()

                    'clienti
                    cmd.CommandText = "UPDATE Clienti SET Nucleo = '000' WHERE (Nucleo IS NULL) OR (Trim(Nucleo) = '')"
                    cmd.ExecuteNonQuery()
                    'elimino doppioni incarichi
                    cmd.CommandText = "DELETE DISTINCTROW A.* FROM Incarichi AS A " +
                                      "INNER JOIN (SELECT AgenziaSinistro,EsercizioSinistro,NumeroSinistro,NumeroPosizione,DataIncarico," +
                                                         "CodicePeritoSAP,TipoIncaricoCC,Max(DataCompetenzaElaborazione) AS UltimoAggiornamento " +
                                                  "FROM Incarichi " +
                                                  "GROUP BY AgenziaSinistro,EsercizioSinistro,NumeroSinistro,NumeroPosizione,DataIncarico,CodicePeritoSAP," +
                                                           "TipoIncaricoCC " +
                                                  "HAVING Count(*) > 1) AS B " +
                                      "ON A.AgenziaSinistro = B.AgenziaSinistro AND A.EsercizioSinistro = B.EsercizioSinistro AND " +
                                         "A.NumeroSinistro = B.NumeroSinistro AND A.NumeroPosizione = B.NumeroPosizione AND A.DataIncarico = B.DataIncarico AND " +
                                         "A.CodicePeritoSAP = B.CodicePeritoSAP AND A.TipoIncaricoCC = B.TipoIncaricoCC " +
                                      "WHERE A.DataCompetenzaElaborazione < B.UltimoAggiornamento"
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
        End Try
    End Sub

    Public Shared Sub SpostaCartellaSms()
        Dim VecchiaCartellaSms As String = Path.Combine(Utx.Globale.Paths.UnitaDati.Name, "Unitools\Sms")
        If Directory.Exists(VecchiaCartellaSms) Then
            My.Computer.FileSystem.MoveDirectory(VecchiaCartellaSms, Utx.Globale.Paths.CartellaSms, True)
        End If
    End Sub

    Public Shared Sub NormalizzaCartelleDocumenti()
        Try
            Dim Contatore As Integer = 0

            'per tutte le cartelle in documenti
            For Each cartella As String In Directory.GetDirectories(Utx.Globale.Paths.CartellaDocumenti)
                'per tutti i clienti
                For Each cliente In Directory.GetDirectories(cartella)
                    'per tutte le pratiche del cliente
                    For Each pratica In Directory.GetDirectories(cliente)

                        Dim NomeCartellaPratica As String = Path.GetFileName(pratica)

                        If NomeCartellaPratica.ToLower.StartsWith("sinistro") Then
                            'se la pratica è un sinistro scritto con la vecchia notazione
                            If NomeCartellaPratica.Contains(".") AndAlso (NomeCartellaPratica.Length = 26) Then
                                'modifico il nome
                                Dim NuovoNome As String = Replace(NomeCartellaPratica, "Sinistro ", "Sinistro 1-")
                                NuovoNome = Replace(NuovoNome, ".", "-")

                                Dim NuovoPathPratica As String = Path.Combine(Directory.GetParent(pratica).FullName, NuovoNome)

                                If Directory.Exists(NuovoPathPratica) Then
                                    'se la pratica (col nuovo nome) già esiste sposto i file dalla vecchia alla nuova cartella
                                    For Each f As String In Directory.GetFiles(pratica)
                                        'nuovo path del file
                                        Dim NuovoPathFile As String = Path.Combine(NuovoPathPratica, Path.GetFileName(f))
                                        'se il file non esiste nella nuova cartella
                                        If File.Exists(NuovoPathFile) = False Then
                                            My.Computer.FileSystem.MoveFile(f, NuovoPathFile)
                                            'Ut.Globale.Log.Info(String.Format("*** file {0} spostato in {1}", f, NuovoPathFile))
                                        Else
                                            'lo cancello dalla vecchia cartella
                                            File.Delete(f)
                                        End If
                                    Next
                                    'cancello la vecchia cartella
                                    Directory.Delete(pratica)
                                Else
                                    'la pratica non esiste con il nuovo nome e rinomino la vecchia
                                    My.Computer.FileSystem.RenameDirectory(pratica, NuovoNome)
                                    'Ut.Globale.Log.Info(String.Format("pratica {0} rinominata in {1}", pratica, NuovoNome))
                                End If
                            End If
                        End If
                    Next

                    Contatore += 1

                    'notifica ogni 50 clienti analizzati
                    If (Contatore Mod 50) = 0 Then
                        Notifica.Messaggio = String.Format("Normalizzazione documenti{0}{0} Clienti normalizzati {1}",
                                                           Environment.NewLine, Contatore)
                    End If
                Next
            Next

            Log.Info(String.Format("Clienti normalizzati {0}", Contatore))

        Catch ex As Exception
            Errore(Reflection.MethodBase.GetCurrentMethod.ToString, ex)
        End Try
    End Sub

    Public Shared Sub UpdateDataUltimaNota(CodiceAgenzia As String)
        Try
            Log.Info("UpdateDataUltimaNota")

            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(CodiceAgenzia, Utx.ConnessioniDb.Db.SINISTRI))
                c.Open()

                Dim FileNote As String = Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.NOTE)

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    'creo una tabella temp
                    Utx.FunzioniDb.CancellaTabella(c, "Temp")
                    cmd.CommandText = "SELECT Max(DataModifica) AS UltimaNota,Val(Mid(m.IdNota,3,4)) AS Ente," +
                                             "Val(Mid(m.IdNota,8,4)) AS Esercizio,Val(Mid(m.IdNota,13,7)) AS Numero " +
                                      "INTO Temp " +
                                      "FROM SinistriMemo AS m IN '{0}' " +
                                      "WHERE IsNumeric(Left(IdNota, 1)) " +
                                      "GROUP BY IdNota"
                    cmd.CommandText = String.Format(cmd.CommandText, FileNote)
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE Sinistri AS s " +
                                      "INNER JOIN Temp AS m ON s.AgenziaSinistro = m.Ente AND " +
                                                              "s.EsercizioSinistro = m.Esercizio AND " +
                                                              "s.NumeroSinistro = m.Numero " +
                                      "SET s.DataMemo = m.UltimaNota"
                    cmd.ExecuteNonQuery()
                    Utx.FunzioniDb.CancellaTabella(c, "Temp")
                End Using
            End Using
        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
        End Try
    End Sub

    Private Shared Sub ControlloEsistenzaDatabase(CodiceAgenzia As String)
        Try
            Log.Info("ControlloEsistenzaDatabase")

            Dim ListaDb As New List(Of String)
            ListaDb.Add("Titoli.mdb")

            'cartella mdb agenzia
            Dim CartellaDbAgenzia As String = Path.Combine(Utx.Globale.Paths.CartellaDati, CodiceAgenzia)

            For Each db In ListaDb
                Dim MdbDest As String = Path.Combine(CartellaDbAgenzia, db)

                If File.Exists(MdbDest) = False Then
                    Dim Modello As String = Path.Combine(Utx.Globale.Paths.CartellaModelliDatiAgenzia, db)

                    If File.Exists(Modello) = True Then
                        File.Copy(Modello, MdbDest)
                    Else
                        Log.Info(String.Format("File modello '{0}' non trovato", Modello))
                    End If
                End If
            Next

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
        End Try
    End Sub

    Public Shared Sub DistinctSupporto()
        Try
            Dim dt As DataTable = Utx.FunzioniDb.CreaDataTable("SELECT * FROM Struttura WHERE Database = 'Supporto'")

            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString("00000", Utx.ConnessioniDb.Db.SUPPORTO))
                c.Open()

                For Each r As DataRow In dt.Rows
                    Utx.FunzioniDb.DistinctTabella(r("Tabella"), c)
                Next
            End Using

        Catch ex As Exception
            Errore(Reflection.MethodBase.GetCurrentMethod.ToString, ex)
        End Try
    End Sub

    Private Shared Sub ResetControlloIncassi(CodiceAgenzia As String)
        Try
            Log.Info("ResetControlloIncassi")

            Dim Inizio As Date

            Try
                Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO))
                    c.Open()

                    Using cmd As New OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "SELECT Min(DataFoglioCassa) FROM Titoli WHERE TipoElaborazione = '23'"
                        Inizio = cmd.ExecuteScalar
                    End Using
                End Using
            Catch ex As Exception
                'dbuno probabilmente vuoto non fare niente
                Exit Sub
            End Try

            'reset calendario di Unitools
            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(CodiceAgenzia, Utx.ConnessioniDb.Db.INCASSI))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = String.Format("DELETE FROM ControlloIncassi WHERE Agenzia = {0} AND DataFoglioCassa >= {1}",
                                                    CodiceAgenzia, Utx.FunzioniData.DataUsa(Inizio))
                    cmd.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
        End Try
    End Sub

    Public Shared Function AggiornaArretrati(CodiceAgenzia As String) As Boolean
        Try
            Log.Info("AggiornaArretrati")

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.INCASSI))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    'aggiungo i nuovi campi
                    If Utx.FunzioniDb.EsisteCampo(c, "Arretrati", "PrvAcq") = False Then
                        cmd.CommandText = "ALTER TABLE Arretrati ADD COLUMN PrvAcq DOUBLE"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Arretrati", "PrvInc") = False Then
                        cmd.CommandText = "ALTER TABLE Arretrati ADD COLUMN PrvInc DOUBLE"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Arretrati", "PremioRc") = False Then
                        cmd.CommandText = "ALTER TABLE Arretrati ADD COLUMN PremioRc DOUBLE"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE Arretrati SET PremioRc = 0"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Arretrati", "PrIF") = False Then
                        cmd.CommandText = "ALTER TABLE Arretrati ADD COLUMN PrIF DOUBLE"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE Arretrati SET PrIF = 0"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Arretrati", "PrINF") = False Then
                        cmd.CommandText = "ALTER TABLE Arretrati ADD COLUMN PrINF DOUBLE"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE Arretrati SET PrINF = 0"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Arretrati", "PrKasko") = False Then
                        cmd.CommandText = "ALTER TABLE Arretrati ADD COLUMN PrKasko DOUBLE"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE Arretrati SET PrKasko = 0"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Arretrati", "PrAssistenza") = False Then
                        cmd.CommandText = "ALTER TABLE Arretrati ADD COLUMN PrAssistenza DOUBLE"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE Arretrati SET PrAssistenza = 0"
                        cmd.ExecuteNonQuery()
                    End If
                    'dal 28/08/2019
                    If Utx.FunzioniDb.EsisteCampo(c, "Arretrati", "ScadenzaVincolo") = False Then
                        cmd.CommandText = "ALTER TABLE Arretrati ADD COLUMN ScadenzaVincolo DATE, EffettoPolizza DATE, ScadenzaPolizza DATE, RataIntermedia TEXT(1), CodiceProduttore INT"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE Arretrati SET CodiceProduttore = 0"
                        cmd.ExecuteNonQuery()
                    End If
                    'dal 18/12/2019
                    If Utx.FunzioniDb.EsisteCampo(c, "Arretrati", "TotalePolizza") = False Then
                        cmd.CommandText = "ALTER TABLE Arretrati ADD COLUMN TotalePolizza DOUBLE"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Arretrati", "Unibox") = False Then
                        cmd.CommandText = "ALTER TABLE Arretrati ADD COLUMN Unibox DOUBLE"
                        cmd.ExecuteNonQuery()
                    End If
                    'dal 05/11/2020
                    If Utx.FunzioniDb.EsisteCampo(c, "Arretrati", "TipoMat") = False Then
                        cmd.CommandText = "ALTER TABLE Arretrati ADD COLUMN TipoMat TEXT(1)"
                        cmd.ExecuteNonQuery()
                    End If
                    'dal 27/12/2020
                    If Utx.FunzioniDb.EsisteCampo(c, "Arretrati", "Nota") = False Then
                        cmd.CommandText = "ALTER TABLE Arretrati ADD COLUMN Nota TEXT(255)"
                        cmd.ExecuteNonQuery()
                    End If
                    'dal 28/03/2021
                    If Utx.FunzioniDb.EsisteCampo(c, "Arretrati", "Frazionamento") = False Then
                        cmd.CommandText = "ALTER TABLE Arretrati ADD COLUMN Frazionamento TEXT(1)"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Arretrati", "RID") = False Then
                        cmd.CommandText = "ALTER TABLE Arretrati ADD COLUMN RID TEXT(1)"
                        cmd.ExecuteNonQuery()
                    End If
                End Using
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function AggiornaAnag(CodiceAgenzia As String) As Boolean
        Try
            Log.Info("AggiornaAnag")

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.ANAG))
                c.Open()

                If Utx.FunzioniDb.EsisteCampo(c, "ana_soggetto", "DestinatarioQualifica") = False Then

                    Using cmd As New OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        'aggiungo i nuovi campi
                        cmd.CommandText = "ALTER TABLE ana_soggetto ADD DestinatarioQualifica varchar(50)"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE ana_soggetto ADD DestinatarioNominativo varchar(50)"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE ana_soggetto ADD DestinatarioPresso varchar(50)"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE ana_soggetto ADD DestinatarioIndirizzo varchar(50)"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE ana_soggetto ADD DestinatarioCap char(5)"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE ana_soggetto ADD DestinatarioLocalita varchar(50)"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE ana_soggetto ADD DestinatarioProvincia char(3)"
                        cmd.ExecuteNonQuery()
                    End Using
                End If
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function AggiornaPolizze(CodiceAgenzia As String) As Boolean
        Try
            Log.Info("AggiornaPolizze")

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.POLIZZE))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    'tabella polizze
                    If Utx.FunzioniDb.EsisteCampo(c, "Polizze", "FlagSospesa") = False Then
                        'aggiungo i nuovi campi
                        cmd.CommandText = "ALTER TABLE Polizze ADD FlagSospesa char(2)"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE Polizze ADD DataEffettoSospesa date"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE Polizze ADD FlagFlessibilita char(1)"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE Polizze ADD PercentualeFlessibilita double"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE Polizze ADD FlagRegolazionePremio char(1)"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE Polizze ADD EsercizioCompetenza integer"
                        cmd.ExecuteNonQuery()
                    End If

                    If File.Exists(Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO)) Then
                        'faccio l'update recuperando i valori da dbuno
                        cmd.CommandText = "UPDATE Polizze AS p " +
                                          "INNER JOIN (SELECT P1.CodicePuntoVendita,P1.ramo,P1.polizza,P1.FlagSospesa,P1.DataEffettoSospesa," +
                                                             "P1.FlagFlessibilita,P1.PercentualeFlessibilita,P2.FlagRegolazionePremio,P2.EsercizioCompetenza " +
                                                      "FROM (Polizze1 AS P1 INNER JOIN Polizze2 AS P2 " +
                                                      "ON P1.CodicePuntoVendita = P2.CodicePuntoVendita AND P1.ramo = P2.ramo AND P1.polizza = P2.polizza) IN '{0}') AS v " +
                                          "ON p.Agenzia = v.CodicePuntoVendita AND p.Ramo = v.Ramo AND p.Polizza = v.Polizza " +
                                          "SET p.FlagSospesa = v.FlagSospesa," +
                                              "p.DataEffettoSospesa = v.DataEffettoSospesa," +
                                              "p.FlagFlessibilita = v.FlagFlessibilita," +
                                              "p.PercentualeFlessibilita = v.PercentualeFlessibilita," +
                                              "p.FlagRegolazionePremio = v.FlagRegolazionePremio," +
                                              "p.EsercizioCompetenza = v.EsercizioCompetenza"
                        cmd.CommandText = String.Format(cmd.CommandText, Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO))
                        cmd.ExecuteNonQuery()
                    End If

                    'tabella PTFCanc
                    If Utx.FunzioniDb.EsisteCampo(c, "MovPolizze", "FlagSospesa") = False Then
                        'aggiungo i nuovi campi
                        cmd.CommandText = "ALTER TABLE MovPolizze ADD FlagSospesa char(2)"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE MovPolizze ADD DataEffettoSospesa date"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE MovPolizze ADD FlagFlessibilita char(1)"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE MovPolizze ADD PercentualeFlessibilita double"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE MovPolizze ADD FlagRegolazionePremio char(1)"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE MovPolizze ADD EsercizioCompetenza integer"
                        cmd.ExecuteNonQuery()
                    End If

                    If File.Exists(Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO)) Then
                        'faccio l'update recuperando i valori da dbuno
                        cmd.CommandText = "UPDATE MovPolizze AS p " +
                                          "INNER JOIN (SELECT P1.CodicePuntoVendita,P1.ramo,P1.polizza,P1.FlagSospesa,P1.DataEffettoSospesa," +
                                                             "P1.FlagFlessibilita,P1.PercentualeFlessibilita,P2.FlagRegolazionePremio,P2.EsercizioCompetenza " +
                                                      "FROM (Polizze1 AS P1 INNER JOIN Polizze2 AS P2 " +
                                                      "ON P1.CodicePuntoVendita = P2.CodicePuntoVendita AND P1.ramo = P2.ramo AND P1.polizza = P2.polizza) IN '{0}') AS v " +
                                          "ON p.Agenzia = v.CodicePuntoVendita AND p.Ramo = v.Ramo AND p.Polizza = v.Polizza " +
                                          "SET p.FlagSospesa = v.FlagSospesa," +
                                              "p.DataEffettoSospesa = v.DataEffettoSospesa," +
                                              "p.FlagFlessibilita = v.FlagFlessibilita," +
                                              "p.PercentualeFlessibilita = v.PercentualeFlessibilita," +
                                              "p.FlagRegolazionePremio = v.FlagRegolazionePremio," +
                                              "p.EsercizioCompetenza = v.EsercizioCompetenza"
                        cmd.CommandText = String.Format(cmd.CommandText, Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO))
                        cmd.ExecuteNonQuery()
                    End If
                End Using
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function AggiornaPolizzeMarcaVeicolo(CodiceAgenzia As String) As Boolean
        Try
            Log.Info("AggiornaPolizzeMarcaVeicolo")

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.POLIZZE))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    'tabella polizze
                    If Utx.FunzioniDb.EsisteCampo(c, "Polizze", "MarcaVeicolo") = False Then
                        'aggiungo i nuovi campi
                        cmd.CommandText = "ALTER TABLE Polizze ADD MarcaVeicolo varchar(14)"
                        cmd.ExecuteNonQuery()
                    End If

                    If File.Exists(Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO)) Then
                        'faccio l'update recuperando i valori da dbuno
                        cmd.CommandText = "UPDATE Polizze AS p " +
                                          "INNER JOIN (SELECT P2.CodicePuntoVendita,P2.ramo,P2.polizza,P2.MarcaVeicolo FROM Polizze2 AS P2 IN '{0}') AS v " +
                                          "ON p.Agenzia = v.CodicePuntoVendita AND p.Ramo = v.Ramo AND p.Polizza = v.Polizza " +
                                          "SET p.MarcaVeicolo = v.MarcaVeicolo"
                        cmd.CommandText = String.Format(cmd.CommandText, Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO))
                        cmd.ExecuteNonQuery()
                    End If

                    'tabella PTFCanc
                    If Utx.FunzioniDb.EsisteCampo(c, "MovPolizze", "MarcaVeicolo") = False Then
                        'aggiungo i nuovi campi
                        cmd.CommandText = "ALTER TABLE MovPolizze ADD MarcaVeicolo varchar(14)"
                        cmd.ExecuteNonQuery()
                    End If

                    If File.Exists(Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO)) Then
                        'faccio l'update recuperando i valori da dbuno
                        cmd.CommandText = "UPDATE MovPolizze AS p " +
                                          "INNER JOIN (SELECT P2.CodicePuntoVendita,P2.ramo,P2.polizza,P2.MarcaVeicolo FROM Polizze2 AS P2 IN '{0}') AS v " +
                                          "ON p.Agenzia = v.CodicePuntoVendita AND p.Ramo = v.Ramo AND p.Polizza = v.Polizza " +
                                          "SET p.MarcaVeicolo = v.MarcaVeicolo"
                        cmd.CommandText = String.Format(cmd.CommandText, Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO))
                        cmd.ExecuteNonQuery()
                    End If
                End Using
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Private Shared Function ResetPTFCanc(CodiceAgenzia As String) As Boolean
        Try
            Dim ao As New Utx.AgenziaFigliaOmnia(CodiceAgenzia, Utx.Globale.ProfiloEnteGestore.CodiceSede, False)
            Dim PTFCanc2017 As String = Path.Combine(ao.Cartelle.ArchivioDati, "MovimentiPTF\2017")
            'svuota la cartella
            Utx.NetFunc.SvuotaCartella(PTFCanc2017)
            'reset calendario
            ResetCalendarioOmnia(CodiceAgenzia, Utx.Enumerazioni.TipoFileMagia.MovimentiPTF)

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function ResetCalendarioOmnia(CodiceAgenzia As String,
                                                TipoDati As Utx.Enumerazioni.TipoFileMagia) As Boolean
        Try
            '+reset per un solo codice agenzia e un solo tipo di dati
            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.INFO))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "DELETE FROM CalendarioOmnia WHERE TipoFile = ?"
                    cmd.Parameters.AddWithValue("tipofile", Utx.Enumerazioni.CodiceFileMagia(TipoDati))
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function ResetCalendarioOmnia(CodiceAgenzia As String,
                                                TipoDati As Utx.Enumerazioni.TipoFileMagia,
                                                UltimoAggiornamento As Date,
                                                Optional Consolida As Date = #1/1/2000#) As Boolean
        Try
            '+reset per un solo codice agenzia e un solo tipo di dati
            Dim Query As String = String.Format("UPDATE C
                SET UltimoAggiornamento = '{0:dd/MM/yyyy}',Consolida = '{1:dd/MM/yyyy}' 
                FROM CalendarioOmnia AS C
                WHERE (UltimoAggiornamento > '{0:dd/MM/yyyy}') AND (TipoFile = '{2}')",
                                                UltimoAggiornamento, Consolida, Utx.Enumerazioni.CodiceFileMagia(TipoDati))
            Utx.WsCommand.ExecuteNonQuery(Query, CodiceAgenzia)
            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function ResetCalendarioOmnia(UltimoAggiornamento As Date) As Boolean
        Try
            '+reset di tutti i tipi di dati e per tutti i codici gestiti
            For Each Agenzia In Utx.EnteGestore.CodiciGestiti
                Try
                    'reset per un solo codice agenzia e tutti i tipi di dati
                    Dim Query As String = String.Format("UPDATE DB{0}.dbo.CalendarioOmnia 
                        SET UltimoAggiornamento = '{1:dd/MM/yyyy}',Consolida = '01/01/2000' 
                        WHERE UltimoAggiornamento > '{1:dd/MM/yyyy}'", Agenzia, UltimoAggiornamento.AddDays(-1))

                    Return Utx.WsCommand.ExecuteNonQueryRecord(Query) > 0

                Catch ex As Exception
                    Errore(Agenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
                    Return False
                End Try
            Next
            Return True

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Shared Function ResetCalendarioOmnia(CodiceAgenzia As String,
                                                UltimoAggiornamento As Date) As Boolean
        Try
            '+reset per un solo codice agenzia e tutti i tipi di dati
            Dim Query As String = String.Format("UPDATE DB{0}.dbo.CalendarioOmnia 
                SET UltimoAggiornamento = '{1:dd/MM/yyyy}',Consolida = '01/01/2000' 
                WHERE UltimoAggiornamento > '{1:dd/MM/yyyy}'", CodiceAgenzia, UltimoAggiornamento)

            Return Utx.WsCommand.ExecuteNonQueryRecord(Query) > 0

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function ResetCalendarioUt(CodiceAgenzia As String,
                                             TipoDati As Utx.Enumerazioni.TipoFileMagia,
                                             Dal As Date) As Boolean
        Try
            'reset per un solo codice e un solo tipo di dati
            Dim Query As String = String.Format("DELETE FROM DB{0}.dbo.CalendarioUt 
                WHERE (DataFine >= '{1:dd/MM/yyyy}') AND (TipoFile = '{2}')", CodiceAgenzia, Dal, Utx.Enumerazioni.CodiceFileMagia(TipoDati))

            Return Utx.WsCommand.ExecuteNonQueryRecord(Query) > 0

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function ResetCalendarioDoc(CodiceAgenzia As String,
                                              TipoDati As Utx.Enumerazioni.TipoFileDoc,
                                              Dal As Date) As Boolean
        Try
            Dim Query As String = String.Format("DELETE FROM CalendarioDoc
                WHERE (DataFine >= '{0:dd/MM/yyyy}') AND (TipoFile = '{1}')", Dal, Utx.Enumerazioni.CodiceFileMagia(TipoDati))

            Return Utx.WsCommand.ExecuteNonQueryRecord(Query, CodiceAgenzia) > 0

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function UpdateDataMemoSinistri(CodiceAgenzia As String) As Boolean
        Try
            Log.Info("UpdateDataMemoSinistri")

            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(CodiceAgenzia, Utx.ConnessioniDb.Db.SINISTRI))
                c.Open()

                'leggo da ws la data dell'ultima nota x sinistro e la salvo nella tabella manutenzione
                Dim dt As DataTable
                Using s As New Utx.ServiziOMW.ServizioDatiOMW
                    s.Proxy = Utx.Globale.UniProxy.Proxy
                    dt = s.UltimaNota(CodiceAgenzia, Today.AddDays(-365), Utx.Globale.Token).Tables(0)
                    For Each row As DataRow In dt.Rows
                        row.SetAdded()
                    Next
                End Using

                If dt.Rows.Count > 0 Then
                    Utx.FunzioniDb.CancellaTabella(c, "Manutenzione")

                    Using cmd As New OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "CREATE TABLE Manutenzione (UltimaNota DATE, Compagnia INT, AgenziaSinistro INT, EsercizioSinistro INT, NumeroSinistro INT)"
                        cmd.ExecuteNonQuery()

                        cmd.CommandText = "INSERT INTO Manutenzione VALUES (?,?,?,?,?)"
                        cmd.Parameters.AddWithValue("0", dt).SourceColumn = "UltimaNota"
                        cmd.Parameters.AddWithValue("1", dt).SourceColumn = "Compagnia"
                        cmd.Parameters.AddWithValue("2", dt).SourceColumn = "AgenziaSinistro"
                        cmd.Parameters.AddWithValue("3", dt).SourceColumn = "EsercizioSinistro"
                        cmd.Parameters.AddWithValue("4", dt).SourceColumn = "NumeroSinistro"

                        Using da As New OleDbDataAdapter()
                            da.InsertCommand = cmd
                            da.Update(dt)
                        End Using
                        'aggiorno le tabelle sinistri
                        cmd.CommandText = "UPDATE SinistriDP AS S " +
                                      "INNER JOIN Manutenzione AS M ON S.Compagnia = M.Compagnia AND S.AgenziaSinistro = M.AgenziaSinistro AND " +
                                                            "S.EsercizioSinistro = M.EsercizioSinistro AND S.NumeroSinistro = M.NumeroSinistro " +
                                      "SET S.DataMemo = M.UltimaNota"
                        Log.Info("{0}: aggiornata DataMemo per {1} sinistri su SinistriDP", {CodiceAgenzia, cmd.ExecuteNonQuery()})
                        cmd.CommandText = "UPDATE SinistriDA AS S " +
                                      "INNER JOIN Manutenzione AS M ON S.Compagnia = M.Compagnia AND S.AgenziaSinistro = M.AgenziaSinistro AND " +
                                                            "S.EsercizioSinistro = M.EsercizioSinistro AND S.NumeroSinistro = M.NumeroSinistro " +
                                      "SET S.DataMemo = M.UltimaNota"
                        Log.Info("{0}: aggiornata DataMemo per {1} sinistri su SinistriDA", {CodiceAgenzia, cmd.ExecuteNonQuery()})
                        cmd.CommandText = "UPDATE SinistriAC AS S " +
                                      "INNER JOIN Manutenzione AS M ON S.Compagnia = M.Compagnia AND S.AgenziaSinistro = M.AgenziaSinistro AND " +
                                                            "S.EsercizioSinistro = M.EsercizioSinistro AND S.NumeroSinistro = M.NumeroSinistro " +
                                      "SET S.DataMemo = M.UltimaNota"
                        Log.Info("{0}: aggiornata DataMemo per {1} sinistri su SinistriAC", {CodiceAgenzia, cmd.ExecuteNonQuery()})
                        Utx.FunzioniDb.CancellaTabella(c, "Manutenzione")
                    End Using
                End If
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function ManutenzioneNote(CodiceAgenzia As String) As Boolean
        Try
            Log.Info("ManutenzioneNote")

            Using cn As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.NOTE))
                cn.Open()

                Utx.FunzioniDb.CreaIndice(cn, "SinistriMemo", "idx_cf", {"CodiceFiscale", "IdNota"})

                'se il campo esiste la migrazione non è riuscita
                If Utx.FunzioniDb.EsisteCampo(cn, "SinistriMemo", "EsercizioSinistro") Then

                    Using cs As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.SINISTRI))
                        cs.Open()

                        Dim dt As DataTable = Utx.FunzioniDb.CreaDataTable("SELECT Id,EsercizioSinistro,AgenziaSinistro,NumeroSinistro " +
                                                                           "FROM SinistriMemo WHERE AgenziaSinistro = 0 AND NumeroSinistro > 9999999", cn)

                        Using cmd As New OleDbCommand
                            cmd.CommandType = CommandType.Text

                            For Each dr As DataRow In dt.Rows
                                'modifico il numero nella tabella sinistri
                                cmd.Connection = cs
                                cmd.CommandText = "UPDATE SinistriAC SET NumeroSinistro = ? " +
                                                  "WHERE AgenziaSinistro = 0 AND EsercizioSinistro = ? AND NumeroSinistro = ?"
                                cmd.Parameters.Clear()
                                cmd.Parameters.AddWithValue("id", dr("Id"))
                                cmd.Parameters.AddWithValue("esercizio", dr("EsercizioSinistro"))
                                cmd.Parameters.AddWithValue("numero", dr("NumeroSinistro"))
                                cmd.ExecuteNonQuery()
                                'modifico il numero nella tabella note
                                cmd.Connection = cn
                                cmd.CommandText = "UPDATE SinistriMemo SET NumeroSinistro = ? " +
                                                  "WHERE AgenziaSinistro = 0 AND EsercizioSinistro = ? AND NumeroSinistro = ?"
                                cmd.ExecuteNonQuery()
                                'aggiungo una nota con il numero sinistro
                                cmd.CommandText = "INSERT INTO SinistriMemo (Utente,DataModifica,EsercizioSinistro,AgenziaSinistro,NumeroSinistro,[Memo],Tipo) " +
                                                  "VALUES ('Numero',?,?,0,?,?,'N')"
                                cmd.Parameters.Clear()
                                cmd.Parameters.AddWithValue("data", Now.ToString)
                                cmd.Parameters.AddWithValue("esercizio", dr("EsercizioSinistro"))
                                cmd.Parameters.AddWithValue("numero", dr("Id"))
                                cmd.Parameters.AddWithValue("memo", String.Format("Numero sinistro: {0}", dr("NumeroSinistro")))
                                cmd.ExecuteNonQuery()
                            Next
                            'creo l'id nota
                            cmd.Connection = cn
                            cmd.CommandText = "UPDATE SinistriMemo " +
                                              "SET IdNota = '1-' + Format(AgenziaSinistro,'0000') + '-' + " +
                                                                  "Format(EsercizioSinistro,'0000') + '-' + " +
                                                                  "Format(NumeroSinistro,'0000000') " +
                                              "WHERE Len(Trim(IdNota)) = 0 OR IdNota IS NULL"
                            cmd.ExecuteNonQuery()
                            'cancello le colonne che non servono più
                            cmd.CommandText = "ALTER TABLE SinistriMemo DROP COLUMN AgenziaSinistro,EsercizioSinistro,NumeroSinistro"
                            cmd.ExecuteNonQuery()
                        End Using
                    End Using
                End If
            End Using

            Dim DataOra As Date = Now
            Using cn As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.NOTE))
                cn.Open()

                If Utx.FunzioniDb.EsisteCampo(cn, "SinistriMemo", "DataCommit") = False Then
                    Using cmd As New OleDbCommand
                        cmd.Connection = cn
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "ALTER TABLE SinistriMemo ADD COLUMN DataCommit Date"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE SinistriMemo SET DataCommit = ?"
                        cmd.Parameters.AddWithValue("now", Format(DataOra, "dd/MM/yyyy HH:mm:ss"))
                        cmd.ExecuteNonQuery()
                    End Using
                End If
            End Using

            Using cn As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.REPLICA))
                cn.Open()

                If Utx.FunzioniDb.EsisteCampo(cn, "ReplicaNote", "DataCommit") = False Then
                    Using cmd As New OleDbCommand
                        cmd.Connection = cn
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "ALTER TABLE ReplicaNote ADD COLUMN DataCommit Date"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE ReplicaNote SET DataCommit = ?"
                        cmd.Parameters.AddWithValue("now", Format(DataOra, "dd/MM/yyyy HH:mm:ss"))
                        cmd.ExecuteNonQuery()
                    End Using
                End If
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    'Public Shared Function ManutenzioneIdNote(CodiceAgenzia As String) As Boolean
    '    Try
    '        Log.Info("ManutenzioneIdNote")

    '        Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.NOTE))
    '            c.Open()

    '            Using cmd As New OleDbCommand
    '                cmd.Connection = c
    '                cmd.CommandType = CommandType.Text
    '                cmd.CommandText = "UPDATE SinistriMemo SET IdNota = LEFT(IdNota, 1) + '-' + " +
    '                                                                   "MID(IdNota,3,4) + '-' + " +
    '                                                                   "MID(IdNota,8,4) + '-' + " +
    '                                                                   "MID(IdNota,13,7) " +
    '                                                "WHERE (LEN(IdNota) = 19) AND (MID(IdNota, 2, 1) = '.')"
    '                cmd.ExecuteNonQuery()
    '            End Using
    '        End Using

    '        Return True

    '    Catch ex As Exception
    '        Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
    '        Return False
    '    End Try
    'End Function

    Public Shared Function CorreggiSinistriDbuno(CodiceAgenzia As String) As Boolean
        Try
            Log.Info("CorreggiSinistriDbuno")

            Dim ao As New Utx.AgenziaFigliaOmnia(CodiceAgenzia, Utx.Globale.ProfiloEnteGestore.CodiceSede, False)

            If File.Exists(ao.Cartelle.DatabaseDbUno) Then
                Using c As New OleDbConnection(ao.ConnectionStringDbUno)
                    c.Open()

                    Using cmd As New OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        'anomalia del 10/03/2019
                        cmd.CommandText = "DELETE FROM Sinistri WHERE DataElaborazione = #3/10/2019# AND TipoElaborazione = '91'"
                        cmd.ExecuteNonQuery()
                        'anomalia del 01/11/2020
                        cmd.CommandText = "DELETE FROM Sinistri WHERE DataElaborazione = #11/1/2020# AND TipoElaborazione = '91'"
                        cmd.ExecuteNonQuery()
                        'copio il dato consolidato dell'ultimo flusso mensile sul successivo settimanale
                        cmd.CommandText = "UPDATE Sinistri AS A " +
                                      "INNER JOIN ( " +
                                      "SELECT Compagnia,AgenziaSinistro,EsercizioSinistro,NumeroSinistro,TipoSinistro,TipoCid,FlagCosePersone,CognomeControparte," +
                                             "NomeControparte,CodiceFiscaleControparte,AgenziaPolizzaArrivo,TipologiaDenuncia,PresentatoreDenuncia,NumeroCartellaSertel," +
                                             "ContatoreSinistri,IndicatoreNoCard,ImportoRiserva,RamoGestione " +
                                      "FROM Sinistri " +
                                      "WHERE TipoElaborazione = '92' AND DataElaborazione = (SELECT MAX(DataElaborazione) FROM Sinistri WHERE TipoElaborazione = '92')) AS B " +
                                      "ON A.Compagnia=B.Compagnia AND A.AgenziaSinistro=B.AgenziaSinistro AND A.EsercizioSinistro=B.EsercizioSinistro AND A.NumeroSinistro=B.NumeroSinistro " +
                                      "SET A.TipoSinistro = B.TipoSinistro,A.TipoCid = B.TipoCid,A.FlagCosePersone = B.FlagCosePersone," +
                                          "A.CognomeControparte = B.CognomeControparte,A.NomeControparte = B.NomeControparte," +
                                          "A.CodiceFiscaleControparte = B.CodiceFiscaleControparte,A.AgenziaPolizzaArrivo = B.AgenziaPolizzaArrivo," +
                                          "A.TipologiaDenuncia = B.TipologiaDenuncia,A.PresentatoreDenuncia = B.PresentatoreDenuncia," +
                                          "A.NumeroCartellaSertel = B.NumeroCartellaSertel,A.ContatoreSinistri = B.ContatoreSinistri," +
                                          "A.IndicatoreNoCard = B.IndicatoreNoCard,A.ImportoRiserva = B.ImportoRiserva,A.RamoGestione = B.RamoGestione " +
                                      "WHERE A.DataElaborazione > (SELECT MAX(DataElaborazione) FROM Sinistri WHERE TipoElaborazione = '92')"
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            End If

            ResetCalendarioOmnia(CodiceAgenzia, Utx.Enumerazioni.TipoFileMagia.Sinistri, #10/30/2020#, #9/30/2020#)
            Utx.GestioneFlag.CreaFlag(Utx.GestioneFlag.TipoFlag.DATI_OMNIA_DISPONIBILI)

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function ForzaturaSinistri(CodiceAgenzia As String) As Boolean
        Try
            'correzione sinistri vecchi non chiusi e rimasti appesi
            Log.Info("ForzaturaSinistri")

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.SINISTRI))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    'chiudi sinistri appesi
                    cmd.CommandText = "UPDATE SinistriDP " +
                                      "SET AnnoMeseCompetenza = FORMAT(AnnoMeseCompetenza,'31/12/yyyy'),StatoTecnico = 'LT',StatoBilancistico = 'LT',FlagUtente = 'FORZ.' " +
                                      "WHERE YEAR(AnnoMeseCompetenza) < 2020 AND " +
                                         "((MONTH(AnnoMeseCompetenza)) < 12 OR (MONTH(AnnoMeseCompetenza) = 12 AND DAY(AnnoMeseCompetenza) < 31))"
                    Utx.Globale.Log.Info("Chiusi {0} sinistri con forzatura", {cmd.ExecuteNonQuery()})
                End Using
            End Using
            Return True
        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function AnomaliaSinistri10032019(CodiceAgenzia As String) As Boolean
        'per modificare DbUno se già esiste
        Try
            Log.Info("CorreggiSinistriDbuno")

            Dim ao As New Utx.AgenziaFigliaOmnia(CodiceAgenzia, Utx.Globale.ProfiloEnteGestore.CodiceSede, False)

            If File.Exists(ao.Cartelle.DatabaseDbUno) Then
                Using c As New OleDbConnection(ao.ConnectionStringDbUno)
                    c.Open()

                    Using cmd As New OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        'anomalia del 10/03/2019
                        cmd.CommandText = "DELETE FROM Sinistri WHERE DataElaborazione = #3/10/2019# AND TipoElaborazione = '91'"
                        Utx.Globale.Log.Info("Eliminati {0} sinistri con data elaborazione 10/03/2019", {cmd.ExecuteNonQuery()})
                    End Using
                End Using
            End If

            ResetCalendarioOmnia(CodiceAgenzia, Utx.Enumerazioni.TipoFileMagia.Sinistri, #3/1/2019#, #1/31/2019#)
            Utx.GestioneFlag.CreaFlag(Utx.GestioneFlag.TipoFlag.DATI_OMNIA_DISPONIBILI)

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function ModificaEvidenze(CodiceAgenzia As String) As Boolean
        Try
            Log.Info("ModificaEvidenze")

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.EVIDENZE))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text

                    'se il campo non esiste
                    If Utx.FunzioniDb.EsisteCampo(c, "Unidocs_Promemoria", "FlagInvioPosta") = False Then
                        cmd.CommandText = "ALTER TABLE Unidocs_Promemoria ADD COLUMN FlagInvioPosta YESNO"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Unidocs_Promemoria", "Flags") = False Then
                        cmd.CommandText = "ALTER TABLE Unidocs_Promemoria ADD COLUMN Flags INTEGER NULL"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Unidocs_Promemoria", "ConsegnatoA") = False Then
                        cmd.CommandText = "ALTER TABLE Unidocs_Promemoria ADD COLUMN ConsegnatoA BYTE NULL"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Unidocs_Evidenza", "DataRiferimento") = False Then
                        cmd.CommandText = "ALTER TABLE Unidocs_Evidenza ADD COLUMN DataRiferimento DATE"
                        cmd.ExecuteNonQuery()
                    End If
                    'nuova tabella Unidocs_TipoDocumento
                    Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.EVIDENZE, "Unidocs_TipoDocumento", CopiaDati:=True, Sovrascrivi:=True)
                End Using
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function PuliziaEvidenze(CodiceAgenzia As String) As Boolean
        Try
            Log.Info("PuliziaEvidenze")

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.EVIDENZE))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "DELETE FROM Unidocs_evidenza " +
                                      "WHERE (CodCompagnia IS NULL) OR (IdOggetto IS NULL) OR (CodiceFiscale IS NULL)"
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Sub VecchiLog()
        Try
            'cancella copie di vecchi log (> 500 KB) con formato non più gestito
            For Each f As String In Directory.GetFiles(Utx.Globale.Paths.CartellaLogs, "????????_??????.*.log")
                File.Delete(f)
            Next
            For Each f As String In Directory.GetFiles(Path.Combine(Utx.Globale.Paths.CartellaLogs, Environment.UserName), "????????_??????.*.log")
                File.Delete(f)
            Next
        Catch ex As Exception
            Errore(Reflection.MethodBase.GetCurrentMethod.ToString, ex)
        End Try
    End Sub

    Public Shared Function AllineamentoModelli(CodiceAgenzia As String) As Boolean
        Try
            Log.Info("AllineamentoModelli")

            Log.Info("Allinemento ANAG")
            Using c As New OleDbConnection(Utx.Globale.MDBDriverExclusive + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.ANAG))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text

                    If Utx.FunzioniDb.EsisteCampo(c, "Ana_Polizza", "Polizza") = False Then
                        cmd.CommandText = "ALTER TABLE Ana_Polizza ADD COLUMN Polizza TEXT(50)"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Ana_Soggetto", "Note") = False Then
                        cmd.CommandText = "ALTER TABLE Ana_Soggetto ADD COLUMN [Note] MEMO"
                        cmd.ExecuteNonQuery()
                    End If
                End Using
            End Using
            Log.Info("Allinemento ANDAMENTI")
            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.ANDAMENTI))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text

                    If Utx.FunzioniDb.EsisteCampo(c, "AndamentoSinistri", "TipoChiusura") = True Then
                        cmd.CommandText = "ALTER TABLE AndamentoSinistri ALTER COLUMN TipoChiusura TEXT(2)"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "AndamentoSinistri", "TipoCid") = True Then
                        cmd.CommandText = "ALTER TABLE AndamentoSinistri ALTER COLUMN TipoCid TEXT(1)"
                        cmd.ExecuteNonQuery()
                    End If
                End Using
            End Using
            Log.Info("Allinemento INCASSI")
            Using c As New OleDbConnection(Utx.Globale.MDBDriverExclusive + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.INCASSI))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text

                    If Utx.FunzioniDb.EsisteCampo(c, "Arretrati", "Agenzia") = True Then
                        cmd.CommandText = "ALTER TABLE Arretrati ALTER COLUMN Agenzia INTEGER"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Avvisi", "Agenzia") = True Then
                        cmd.CommandText = "ALTER TABLE Avvisi ALTER COLUMN Agenzia INTEGER"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Incassi", "CanoneBox") = False Then
                        cmd.CommandText = "ALTER TABLE Incassi ADD COLUMN CanoneBox DOUBLE"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Incassi", "Quota") = False Then
                        cmd.CommandText = "ALTER TABLE Incassi ADD COLUMN Quota DOUBLE"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Incassi", "DataRegolazione") = False Then
                        cmd.CommandText = "ALTER TABLE Incassi ADD COLUMN DataRegolazione TEXT(10)"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Incassi", "Cin") = False Then
                        cmd.CommandText = "ALTER TABLE Incassi ADD COLUMN Cin TEXT(1)"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Incassi", "Abi") = False Then
                        cmd.CommandText = "ALTER TABLE Incassi ADD COLUMN Abi INTEGER"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Incassi", "Cab") = False Then
                        cmd.CommandText = "ALTER TABLE Incassi ADD COLUMN Cab INTEGER"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Incassi", "ContoCorrente") = False Then
                        cmd.CommandText = "ALTER TABLE Incassi ADD COLUMN ContoCorrente TEXT(12)"
                        cmd.ExecuteNonQuery()
                    Else
                        cmd.CommandText = "ALTER TABLE Incassi ALTER COLUMN ContoCorrente TEXT(12)"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Incassi", "RataIntermedia") = False Then
                        cmd.CommandText = "ALTER TABLE Incassi ADD COLUMN RataIntermedia TEXT(1)"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Incassi", "PuntoVendita") = False Then
                        cmd.CommandText = "ALTER TABLE Incassi ADD COLUMN PuntoVendita INTEGER"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Incassi", "Tipo") = True Then
                        cmd.CommandText = "ALTER TABLE Incassi ALTER COLUMN Tipo TEXT(1)"
                        cmd.ExecuteNonQuery()
                    End If

                    cmd.CommandText = "UPDATE Incassi SET CanoneBox = 0 WHERE CanoneBox IS NULL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE Incassi SET Quota = 0 WHERE Quota IS NULL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE Incassi SET DataRegolazione = '' WHERE DataRegolazione IS NULL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE Incassi SET Cin = '' WHERE Cin IS NULL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE Incassi SET RataIntermedia = '' WHERE RataIntermedia IS NULL"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE Incassi SET PuntoVendita = 0 WHERE PuntoVendita IS NULL"
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Log.Info("Allinemento SINISTRI")
            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.SINISTRI))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text

                    If Utx.FunzioniDb.EsisteCampo(c, "SPagamenti", "Assegno") = True Then
                        cmd.CommandText = "ALTER TABLE SPagamenti ALTER COLUMN Assegno TEXT(15)"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "SPagamenti", "CFDanneggiato") = True Then
                        cmd.CommandText = "ALTER TABLE SPagamenti ALTER COLUMN CFDanneggiato TEXT(16)"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "SPagamenti", "Cognome") = True Then
                        cmd.CommandText = "ALTER TABLE SPagamenti ALTER COLUMN Cognome TEXT(40)"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "SPagamenti", "Nome") = True Then
                        cmd.CommandText = "ALTER TABLE SPagamenti ALTER COLUMN Nome TEXT(40)"
                        cmd.ExecuteNonQuery()
                    End If
                End Using
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function ModificaCampiSupporto() As Boolean
        Try
            Log.Info("ModificaCampiSupporto")

            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString("00000", Utx.ConnessioniDb.Db.SUPPORTO))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text

                    'If Utx.FunzioniDb.EsisteCampo(c, "ProfiloUtente", "CodiceSede") = True Then
                    '    cmd.CommandText = "ALTER TABLE ProfiloUtente ALTER COLUMN CodiceSede TEXT(5)"
                    '    cmd.ExecuteNonQuery()
                    'End If
                    'liquidatori
                    If Utx.FunzioniDb.EsisteCampo(c, "Liquidatori", "Codice") = True Then
                        cmd.CommandText = "ALTER TABLE Liquidatori ALTER COLUMN Codice INTEGER"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Liquidatori", "Nome") = True Then
                        cmd.CommandText = "ALTER TABLE Liquidatori ALTER COLUMN Nome TEXT(50)"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Liquidatori", "Telefono") = True Then
                        cmd.CommandText = "ALTER TABLE Liquidatori ALTER COLUMN Telefono TEXT(20)"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Liquidatori", "TelefonoClg") = True Then
                        cmd.CommandText = "ALTER TABLE Liquidatori ALTER COLUMN TelefonoClg TEXT(20)"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Liquidatori", "Clg") = True Then
                        cmd.CommandText = "ALTER TABLE Liquidatori ALTER COLUMN Clg INTEGER"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Liquidatori", "Localita") = True Then
                        cmd.CommandText = "ALTER TABLE Liquidatori ALTER COLUMN Localita TEXT(50)"
                        cmd.ExecuteNonQuery()
                    End If
                    If Utx.FunzioniDb.EsisteCampo(c, "Liquidatori", "Provincia") = True Then
                        cmd.CommandText = "ALTER TABLE Liquidatori ALTER COLUMN Provincia TEXT(3)"
                        cmd.ExecuteNonQuery()
                    End If
                End Using
            End Using

            Return True

        Catch ex As Exception
            Errore(Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function ManutenzioneArchivioListe() As Boolean
        Try
            If Directory.Exists(Utx.Globale.Paths.DocFolder(Utx.Enumerazioni.DocFolderType.BUSTE)) Then
                For Each d As String In Directory.GetDirectories(Utx.Globale.Paths.DocFolder(Utx.Enumerazioni.DocFolderType.BUSTE))
                    Dim fi As New FileInfo(d)
                    'nuovo nome cartella invertendo mm-yyyy in yyyy-mm
                    Dim Anno As String = fi.Name.Split("-")(1)
                    Dim Mese As String = fi.Name.Split("-")(0)
                    If IsNumeric(Mese) AndAlso IsNumeric(Anno) AndAlso Val(Mese) <= 12 Then
                        Dim NuovoNome As String = String.Format("{0}-{1}", Anno, Mese)
                        Dim NuovoPath As String = Path.Combine(Directory.GetParent(d).FullName, NuovoNome)
                        If Directory.Exists(NuovoPath) = False Then
                            My.Computer.FileSystem.RenameDirectory(d, NuovoNome)
                        End If
                    End If
                Next
            End If
            If Directory.Exists(Utx.Globale.Paths.DocFolder(Utx.Enumerazioni.DocFolderType.LISTE_QT)) Then
                For Each d As String In Directory.GetDirectories(Utx.Globale.Paths.DocFolder(Utx.Enumerazioni.DocFolderType.LISTE_QT))
                    Dim fi As New FileInfo(d)
                    'nuovo nome cartella invertendo mm-yyyy in yyyy-mm
                    Dim Anno As String = fi.Name.Split("-")(1)
                    Dim Mese As String = fi.Name.Split("-")(0)
                    If IsNumeric(Mese) AndAlso IsNumeric(Anno) AndAlso Val(Mese) <= 12 Then
                        Dim NuovoNome As String = String.Format("{0}-{1}", Anno, Mese)
                        Dim NuovoPath As String = Path.Combine(Directory.GetParent(d).FullName, NuovoNome)
                        If Directory.Exists(NuovoPath) = False Then
                            My.Computer.FileSystem.RenameDirectory(d, NuovoNome)
                        End If
                    End If
                Next
            End If
            Return True

        Catch ex As Exception
            Errore(Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function ModificaFileCalendari(CodiceAgenzia As String) As Boolean
        Try
            Log.Info("ModificaFileCalendari")

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.INFO))
                c.Open()

                'scrivo i nomi dei file in maiuscolo e tolgo eventuali estensioni
                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    'calendariout
                    cmd.CommandText = "UPDATE CalendarioUt SET NomeFile = ? WHERE NomeFile = ?"

                    Dim dt As DataTable = Utx.FunzioniDb.CreaDataTable("SELECT NomeFile FROM CalendarioUt", c)
                    For Each dr In dt.Rows
                        If dr("NomeFile") <> Path.GetFileNameWithoutExtension(dr("NomeFile")) Then
                            cmd.Parameters.Clear()
                            cmd.Parameters.AddWithValue("nuovo", Path.GetFileNameWithoutExtension(dr("NomeFile")).ToUpper)
                            cmd.Parameters.AddWithValue("vecchio", dr("NomeFile"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                    'calendariodoc
                    cmd.CommandText = "UPDATE CalendarioDoc SET NomeFile = ? WHERE NomeFile = ?"

                    dt = Utx.FunzioniDb.CreaDataTable("SELECT NomeFile FROM CalendarioDoc", c)
                    For Each dr In dt.Rows
                        If dr("NomeFile") <> Path.GetFileNameWithoutExtension(dr("NomeFile")) Then
                            cmd.Parameters.Clear()
                            cmd.Parameters.AddWithValue("nuovo", Path.GetFileNameWithoutExtension(dr("NomeFile")).ToUpper)
                            cmd.Parameters.AddWithValue("vecchio", dr("NomeFile"))
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End Using
            End Using
            'resetto date per l'importazione
            ResetCalendarioDoc(CodiceAgenzia, Utx.Enumerazioni.TipoFileDoc.QUIETANZAMENTO, #1/1/2017#)
            ResetCalendarioDoc(CodiceAgenzia, Utx.Enumerazioni.TipoFileDoc.BUSTE, #1/1/2017#)

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Private Shared Function ModificaLayoutSinistri() As Boolean
        Try
            Dim Layout As String = Path.Combine(Utx.Globale.Paths.CartellaSettingRete, "Sinistri.layout.xml")

            If File.Exists(Layout) Then
                Dim Testo As String = File.ReadAllText(Layout)

                Testo = Replace(Testo, "name=""Sinistri.Ispettorato""", "name=""Ispettorato""")
                Testo = Replace(Testo, "name=""Sinistri.TipoCid""", "name=""TipoCid""")

                File.WriteAllText(Layout, Testo)
            End If

            Return True

        Catch ex As Exception
            Errore(Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function NuoveTabelleDbUno(CodiceAgenzia As String) As Boolean
        'per modificare DbUno se già esiste
        Try
            Log.Info("NuoveTabelleDbUno")

            Dim ao As New Utx.AgenziaFigliaOmnia(CodiceAgenzia, Utx.Globale.ProfiloEnteGestore.CodiceSede, False)

            If File.Exists(ao.Cartelle.DatabaseDbUno) Then
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "TipoRecord", CopiaDati:=True, Sovrascrivi:=True)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "Liquidatori", CopiaDati:=False, Sovrascrivi:=True)

                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "CategoriaRischio", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "MassimaliNoNatanti", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "MassimaliNatanti", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "RamoProdottoAliquota", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "ClausolaRCA", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "Franchigia", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "TipoTarga", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "ProfessioneRCA", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "ProvinciaRischio", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "TipoStorno", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "Prodotto", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "RamoMinisteriale", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "RamoPolizzaVita", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "RamoSinistro", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "IspettoratoSinistro", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "CompagniaControparte", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "Frazionamento", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "ClasseVeicolo", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "MercatoPreferenziale", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "Professione", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "TipoDocumento", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "StatoSinistro", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "TipoStornoRamoVita", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "SettoreTariffale", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "RamoPolizza", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "GaranziaAccessoria", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "TipoAvviso", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "Convenzione", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "TipoPagamento", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "ClasseUsoVeicolo", CopiaDati:=False, Sovrascrivi:=False)
                Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO, "RamoComparto", CopiaDati:=False, Sovrascrivi:=False)
            End If

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function UpdateTargheIncassi(CodiceAgenzia As String) As Boolean
        Try
            Log.Info("UpdateTargheIncassi")

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.INCASSI))
                c.Open()

                Dim sql As String = "UPDATE Incassi AS I " +
                                    "INNER JOIN (SELECT Ramo,Polizza,Targa FROM {0} IN '{1}') AS P ON I.Ramo = P.Ramo AND I.Polizza = P.Polizza " +
                                    "SET I.Targa = LEFT(TRIM(P.Targa),9) " +
                                    "WHERE (LEN(TRIM(I.Targa)) = 0) AND (LEN(TRIM(P.Targa)) > 0)"

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    'da polizze
                    cmd.CommandText = String.Format(sql, "Polizze", Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.POLIZZE))
                    cmd.ExecuteNonQuery()
                    'da stornate
                    cmd.CommandText = String.Format(sql, "MovPolizze", Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.POLIZZE))
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function MD5ArchivioNote(CodiceAgenzia As String) As Boolean
        Try
            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.NOTE))
                c.Open()

                If Utx.FunzioniDb.EsisteCampo(c, "SinistriMemo", "MD5") = True Then
                    Using cmd As New OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        'modifico la tabella
                        cmd.CommandText = "ALTER TABLE SinistriMemo DROP COLUMN MD5"
                        cmd.ExecuteNonQuery()
                    End Using
                End If
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Private Shared Sub CreaIndici(CodiceAgenzia As String)
        Try
            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.CLIENTI))
                c.Open()
                Utx.FunzioniDb.CreaIndice(c, "Clienti", "IndiceClienti", {"Cognome", "Nome"})
            End Using
            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.SINISTRI))
                c.Open()
                Utx.FunzioniDb.CreaIndice(c, "SinistriDP", "IndiceSinistri", {"CognomeAssicurato", "NomeAssicurato"})
                Utx.FunzioniDb.CreaIndice(c, "SinistriDA", "IndiceSinistri", {"CognomeAssicurato", "NomeAssicurato"})
                Utx.FunzioniDb.CreaIndice(c, "SinistriAC", "IndiceSinistri", {"CognomeAssicurato", "NomeAssicurato"})
            End Using
            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.INCASSI))
                c.Open()
                Utx.FunzioniDb.CreaIndice(c, "Incassi", "IndiceIncassi", {"Ramo", "Polizza", "DataFoglioCassa"})
                Utx.FunzioniDb.CreaIndice(c, "MonitorQT", "IndicePolizza", {"Polizza"})
            End Using

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
        End Try
    End Sub

    Private Shared Function UpdateCompagniaNote(CodiceAgenzia As String) As Boolean
        Try
            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.NOTE))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    'per sicurezza ma non serve
                    cmd.CommandText = "UPDATE SinistriMemo SET IdNota = TRIM(IdNota)"
                    cmd.ExecuteNonQuery()
                    'modifico la tabella
                    cmd.CommandText = "UPDATE SinistriMemo AS A " +
                                      "INNER JOIN (SELECT Compagnia,AgenziaSinistro,EsercizioSinistro,NumeroSinistro,CodiceFiscContrPol FROM SinistriDP IN '{0}') AS B " +
                                      "ON B.AgenziaSinistro = VAL(MID(A.IdNota, 3, 4)) AND " +
                                         "B.EsercizioSinistro = VAL(MID(A.IdNota, 8, 4)) AND " +
                                         "B.NumeroSinistro = VAL(MID(A.IdNota, 13, 7)) AND " +
                                         "B.CodiceFiscContrPol = A.CodiceFiscale " +
                                         "SET A.IdNota = TRIM(STR(B.Compagnia)) + Mid(A.IdNota, 2, 18)"
                    cmd.CommandText = String.Format(cmd.CommandText, Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.SINISTRI))
                    'eseguo e scrivo log
                    Log.Info(String.Format("Aggiornato IdNota di {0} note", cmd.ExecuteNonQuery()))
                End Using
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function TracciatiGestioneRete(CodiceAgenzia As String) As Boolean
        'modifica campi nella tabella polizze, movpolizze (ptfcanc) e BDA
        Try
            Log.Info("TracciatiGestioneRete")

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.INFO))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    'modifico la tabella
                    cmd.CommandText = "ALTER TABLE Utenze ALTER COLUMN StatoUtenza TEXT(15)"
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function TabelleBudget(CodiceAgenzia As String) As Boolean
        Try
            Log.Info("TabelleBudget")

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.BUDGET))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text

                    cmd.CommandText = "ALTER TABLE BudgetAnnuo ALTER COLUMN CodiceFigura INTEGER"
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function ModificaComparti(CodiceAgenzia As String) As Boolean
        Try
            'sovrascrivi la vecchia tabella
            Utx.GestioneModelli.CopiaModelloTabella("00000", Utx.ConnessioniDb.Db.SUPPORTO, "Comparto", CopiaDati:=True, Sovrascrivi:=True)
            Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.BUDGET, "Codici", CopiaDati:=True, Sovrascrivi:=True)
            Utx.GestioneModelli.CopiaModelloTabella(CodiceAgenzia, Utx.ConnessioniDb.Db.BUDGET, "RgToComparto", CopiaDati:=True, Sovrascrivi:=True)
            Return True
        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function ManutenzioneSinistriAC(CodiceAgenzia As String) As Boolean
        Try
            Log.Info("ManutenzioneSinistriAC")

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.SINISTRI))
                c.Open()

                Dim dr As OleDbDataReader = Utx.FunzioniDb.CreaDataReader(c, "SELECT DISTINCT EsercizioSinistro FROM SinistriAC")

                Do While dr.Read
                    Using da As New OleDbDataAdapter(String.Format("SELECT NumeroSinistro FROM SinistriAC WHERE EsercizioSinistro = {0} ORDER BY NumeroSinistro",
                                                                   dr("EsercizioSinistro")), c)
                        Dim dt As New DataTable
                        da.Fill(dt)

                        Dim Progressivo As Integer = 1

                        For Each row As DataRow In dt.Rows
                            row("NumeroSinistro") = Progressivo
                            Progressivo += 1
                        Next

                        'aggiorno il db
                        Using cmd As New OleDbCommand
                            cmd.Connection = c
                            cmd.CommandType = CommandType.Text
                            cmd.CommandText = "UPDATE SinistriAC SET NumeroSinistro = ?"
                            cmd.Parameters.AddWithValue("Numero", dt).SourceColumn = "NumeroSinistro"

                            'aggiorno il db
                            da.UpdateCommand = cmd
                            da.Update(dt)
                        End Using
                    End Using
                Loop
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function RinominaSinistriDP(CodiceAgenzia As String) As Boolean
        Try
            Log.Info("RinominaSinistriDP")

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.SINISTRI))
                c.Open()

                Dim schemaTable As DataTable = c.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables_Info, New Object() {Nothing, Nothing, "Sinistri", "TABLE"})

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text

                    'se esiste ancora la tabella sinistri
                    If schemaTable.Rows.Count = 1 Then
                        Dim Record As Integer = schemaTable.Rows(0).Item("cardinality")
                        Dim RecordDP As Integer = Utx.FunzioniDb.ExecuteScalar(c, "SELECT COUNT(*) FROM SinistriDP", 0)
                        If Record > RecordDP Then
                            'la tabella sinistri esiste ed è ancora piena, quella DP o non esiste o è vuota
                            Utx.FunzioniDb.CancellaTabella(c, "SinistriDP")
                        Else
                            Return False
                        End If
                    Else
                        Return False
                    End If
                End Using
            End Using

            Using c As New OleDbConnection(Utx.Globale.MDBDriverExclusive + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.SINISTRI))
                c.Open()

                Dim schemaTable As DataTable = c.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables_Info, New Object() {Nothing, Nothing, "Sinistri", "TABLE"})

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text

                    'se esiste ancora la tabella sinistri
                    If schemaTable.Rows.Count = 1 Then
                        Dim Record As Integer = schemaTable.Rows(0).Item("cardinality")
                        Dim RecordDP As Integer = Utx.FunzioniDb.ExecuteScalar(c, "SELECT COUNT(*) FROM SinistriDP", 0)
                        If Record > RecordDP Then
                            'la tabella sinistri esiste ed è ancora piena, quella DP o non esiste o è vuota
                            Utx.FunzioniDb.CancellaTabella(c, "SinistriDP")
                        End If
                    End If

                    If Utx.FunzioniDb.EsisteTabella(c, "SinistriDP") = False Then
                        'metto i sinistri DP in una tabella temp
                        Utx.FunzioniDb.CancellaTabella(c, "TempDP")
                        cmd.CommandText = "SELECT * INTO TempDP FROM Sinistri"
                        cmd.ExecuteNonQuery()
                        'cancello la tabella sinistri
                        cmd.CommandText = "DROP TABLE Sinistri"
                        cmd.ExecuteNonQuery()
                        'se sono riuscito a cancellare la vecchia tabella sinistri creo la nuova tabella da temp
                        cmd.CommandText = "SELECT * INTO SinistriDP FROM TempDP"
                        cmd.ExecuteNonQuery()
                        'creo la stored Sinistri che punta a SinistriDP
                        cmd.CommandText = "Create Procedure Sinistri AS SELECT * FROM SinistriDP"
                        cmd.ExecuteNonQuery()
                        'creo la chiave
                        Utx.FunzioniDb.CreaChiaviSinistri(CodiceAgenzia)
                        'cancello la tabella temp
                        Utx.FunzioniDb.CancellaTabella(c, "TempDP")
                    End If
                End Using
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function NormalizzaFlag() As Boolean
        Try
            Log.Info("NormalizzaFlag")

            For Each f As String In Directory.GetFiles(Utx.Globale.Paths.CartellaFlag, "*.*", SearchOption.TopDirectoryOnly)
                Dim Testo As String = File.ReadAllText(f)
                Dim DataEsecuzione As String = Right(Testo, 19)

                If IsDate(DataEsecuzione) = False Then
                    File.WriteAllText(f, Format(Now, "dd/MM/yyyy HH:mm:ss"))
                ElseIf Testo <> DataEsecuzione Then
                    File.WriteAllText(f, DataEsecuzione)
                End If
            Next

            Return True

        Catch ex As Exception
            Errore(Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Private Shared Sub Errore(Agenzia As String, Metodo As String, ByRef ex As Exception)
        Log.Info(String.Format("Errore in manutenzione agenzia: {0}", Agenzia))
        Log.Info(String.Format("Metodo: {0}", Metodo))
        Log.Info(ex)

        FlagErroreMetodo = True
        FlagErroreGlobale = FlagErroreGlobale Or FlagErroreMetodo
    End Sub

    Private Shared Sub Errore(Metodo As String, ByRef ex As Exception)
        Log.Info("Errore in manutenzione dati comuni")
        Log.Info(String.Format("Metodo: {0}", Metodo))
        Log.Info(ex)

        FlagErroreMetodo = True
        FlagErroreGlobale = FlagErroreGlobale Or FlagErroreMetodo
    End Sub

    Private Shared Sub UpdateUtenti()
        'la tabella in supporti viene (ora) utilizzata solo dalle estrazioni come tabella d'appoggio
        'deve prevedere una sola riga per consentire una query del tipo >> select 1+1 from utenti
        Try
            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(Utx.ConnessioniDb.Db.SUPPORTO))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "DELETE FROM Utenti"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "INSERT INTO Utenti(ID) VALUES('RISERVATO')"
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Errore(Reflection.MethodBase.GetCurrentMethod.ToString, ex)
        End Try
    End Sub

    Public Shared Sub ArchiviaIncassi(CodiceAgenzia As String)
        Try
            Log.Info("ArchiviaIncassi")

            Log.Info("Spostamento incassi nello storico fino al 31/12/2013")
            Using c As New OleDbConnection(Utx.Globale.MDBDriverExclusive + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.UTSTORICO))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    If Utx.FunzioniDb.EsisteTabella(c, "Incassi") = False Then
                        'creo la tabella vuota
                        cmd.CommandText = String.Format("SELECT * INTO Incassi FROM Incassi IN '{0}' WHERE False",
                                                        Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.INCASSI))
                        cmd.ExecuteNonQuery()
                    End If
                    'corregge il campo contocorrente
                    cmd.CommandText = "ALTER TABLE Incassi ALTER COLUMN ContoCorrente TEXT(12)"
                    cmd.ExecuteNonQuery()

                    Dim Inizio As Date
                    Try
                        cmd.CommandText = String.Format("SELECT Min(DataFoglioCassa) FROM Incassi IN '{0}'",
                                                        Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.INCASSI))
                        Inizio = cmd.ExecuteScalar
                    Catch ex As Exception
                        Inizio = Today
                    End Try

                    If Inizio >= #1/1/2014# Then
                        Log.Info("Non ci sono dati incassi fino al 31/12/2013 da archiviare nello storico")
                    Else
                        cmd.CommandText = "DELETE * FROM Incassi WHERE DataFoglioCassa BETWEEN ? AND #12/31/2013#"
                        cmd.Parameters.AddWithValue("inizio", Inizio)
                        Log.Info(String.Format("Cancellati dallo storico {0} incassi", cmd.ExecuteNonQuery))

                        cmd.CommandText = String.Format("INSERT INTO Incassi SELECT * FROM Incassi IN '{0}' WHERE Year(DataFoglioCassa) < 2014",
                                                        Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.INCASSI))
                        Log.Info(String.Format("Aggiunti nello storico {0} incassi", cmd.ExecuteNonQuery))
                        cmd.CommandText = String.Format("DELETE * FROM Incassi IN '{0}' WHERE Year(DataFoglioCassa) < 2014",
                                                        Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.INCASSI))
                        Log.Info(String.Format("Cancellati da incassi {0} record spostati nello storico", cmd.ExecuteNonQuery))
                    End If
                End Using
            End Using

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
        End Try
    End Sub

    Public Shared Function PuliziaDati(CodiceAgenzia As String) As Boolean
        On Error Resume Next
        File.Delete(Path.Combine(Utx.ConnessioniDb.CartellaDatiAgenzia(CodiceAgenzia), "Sms.mdb"))
        File.Delete(Path.Combine(Utx.ConnessioniDb.CartellaDatiAgenzia(CodiceAgenzia), "Supporto.mdb"))
        File.Delete(Path.Combine(Utx.ConnessioniDb.CartellaDatiAgenzia(CodiceAgenzia), "SinistriExtra.mdb"))
    End Function

    Public Shared Function CreaContattiCIP(CodiceAgenzia As String) As Boolean
        Try
            Log.Info("CreaContattiCIP")

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.INFO))
                c.Open()

                If Utx.FunzioniDb.EsisteTabella(c, "ContattiCIP") = False Then

                    Using cmd As New OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        'creo la tabella
                        cmd.CommandText = "CREATE TABLE ContattiCip (Cip Integer, Email varchar(50), Cellulare varchar(15), primary key (Cip))"
                        cmd.ExecuteNonQuery()
                        'popolamento nuova tabella
                        cmd.CommandText = "INSERT INTO ContattiCip (Cip, Email, Cellulare) " +
                                          "SELECT IDFiguraProduttiva, Last(Email), Last(Cellulare) " +
                                          "FROM FigureProduttive WHERE TipoFigura = 'P' AND NOT (Email = '' AND Cellulare = '') " +
                                          "GROUP BY IDFiguraProduttiva"
                        cmd.ExecuteNonQuery()
                        'cancello la vecchia tabella
                        cmd.CommandText = "DROP TABLE FigureProduttive"
                        cmd.ExecuteNonQuery()
                        'creo la nuova vista delle figure produttive
                        cmd.CommandText = "Create Procedure FigureProduttive AS " +
                                          "SELECT 'P'     AS TipoFigura " +
                                          ", A.Cip        AS IDFiguraProduttiva " +
                                          ", A.DeskCip    AS FiguraProduttiva " +
                                          ", ''           AS Canale " +
                                          ", A.DataInizio AS DataAttivazione " +
                                          ", A.DataFine   AS DataDisattivazione " +
                                          ", B.Email " +
                                          ", B.Cellulare " +
                                          "FROM Cip AS A " +
                                          "LEFT JOIN ContattiCip AS B " +
                                          "ON A.Cip = B.Cip"
                        cmd.ExecuteNonQuery()
                    End Using
                End If
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function RipartizioneTitoli(CodiceAgenzia As String) As Boolean
        'per eliminare le righe doppie
        Try
            Log.Info("RipartizioneTitoli")

            Dim ao As New Utx.AgenziaFigliaOmnia(CodiceAgenzia, Utx.Globale.ProfiloEnteGestore.CodiceSede, False)

            If File.Exists(ao.Cartelle.DatabaseDbUno) Then
                Using c As New OleDbConnection(ao.ConnectionStringDbUno)
                    c.Open()

                    Using cmd As New OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "DELETE FROM titoliripartizione"
                        cmd.ExecuteNonQuery()

                        ''cancello per sicurezza la tabella temp
                        'Utx.FunzioniDb.CancellaTabella(c, "titoliripartizione2")
                        ''creo tabella temp
                        'cmd.CommandText = "SELECT Last(dataelaborazione)   AS dataelaborazione2 " +
                        '                       ", Last(codicepuntovendita) AS codicepuntovendita2 " +
                        '                       ", Last(progressivo)        AS progressivo2 " +
                        '                       ", Last(tipoelaborazione)   AS tipoelaborazione2 " +
                        '                       ", ramo                     AS ramo2 " +
                        '                       ", polizza                  AS polizza2 " +
                        '                       ", effettoappendice         AS effettoappendice2 " +
                        '                       ", numeroappendice          AS numeroappendice2 " +
                        '                       ", dataeffetto              AS dataeffetto2 " +
                        '                       ", codicecategoriarischio   AS codicecategoriarischio2 " +
                        '                       ", Last(codicetassazione)   AS codicetassazione2 " +
                        '                       ", Last(premionetto)        AS premionetto2 " +
                        '                       ", Last(interessi)          AS interessi2 " +
                        '                       ", Last(accessori)          AS accessori2 " +
                        '                       ", Last(tasse)              AS tasse2 " +
                        '                       ", Last(aliquotatasse)      AS aliquotatasse2 " +
                        '                       ", Last(tassabile)          AS tassabile2 " +
                        '                       ", Last(provvigioni)        AS provvigioni2 " +
                        '                  "INTO titoliripartizione2 " +
                        '                  "FROM titoliripartizione " +
                        '                  "GROUP BY ramo, polizza, effettoappendice, numeroappendice, dataeffetto, codicecategoriarischio"
                        'cmd.ExecuteNonQuery()
                        ''svuoto la tabella
                        'cmd.CommandText = "DELETE From titoliripartizione"
                        'cmd.ExecuteNonQuery()
                        ''aggiungo la chiave
                        'Utx.FunzioniDb.CancellaChiaveDb(c, "TitoliRipartizione", "pk_titoliripartizione") 'per correggere errore di nome in test (da eliminare)
                        'Utx.FunzioniDb.CancellaChiaveDb(c, "TitoliRipartizione", "IndiceTitoliRipartizione")
                        'Utx.FunzioniDb.CreaChiaveDb(c, "TitoliRipartizione", "IndiceTitoliRipartizione", {"Ramo", "Polizza", "EffettoAppendice", "NumeroAppendice", "DataEffetto", "CodiceCategoriaRischio"})
                        ''copio i record da temp
                        'cmd.CommandText = "INSERT INTO titoliripartizione " +
                        '                  "SELECT dataelaborazione2       AS dataelaborazione " +
                        '                       ", codicepuntovendita2     AS codicepuntovendita " +
                        '                       ", progressivo2            AS progressivo " +
                        '                       ", tipoelaborazione2       AS tipoelaborazione " +
                        '                       ", ramo2                   AS ramo " +
                        '                       ", polizza2                AS polizza " +
                        '                       ", effettoappendice2       AS effettoappendice " +
                        '                       ", numeroappendice2        AS numeroappendice " +
                        '                       ", dataeffetto2            AS dataeffetto " +
                        '                       ", codicecategoriarischio2 AS codicecategoriarischio " +
                        '                       ", codicetassazione2       AS codicetassazione " +
                        '                       ", premionetto2            AS premionetto " +
                        '                       ", interessi2              AS interessi " +
                        '                       ", accessori2              AS accessori " +
                        '                       ", tasse2                  AS tasse " +
                        '                       ", aliquotatasse2          AS aliquotatasse " +
                        '                       ", tassabile2              AS tassabile " +
                        '                       ", provvigioni2            AS provvigioni " +
                        '                  "FROM titoliripartizione2"
                        'cmd.ExecuteNonQuery()
                        ''cancello temp
                        'Utx.FunzioniDb.CancellaTabella(c, "titoliripartizione2")
                    End Using
                End Using
            End If

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function ArchiviaTitoli(CodiceAgenzia As String) As Boolean
        Try
            Log.Info("ArchiviaTitoli")

            If File.Exists(Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO)) Then
                Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO))
                    c.Open()

                    Using cmd As New OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "DELETE FROM Titoli WHERE DataEffetto <= ? AND TipoElaborazione IN ('21','22','26','28','29','30')"

                        Dim DataLimite As Date = Utx.FunzioniData.FineMese(Today.AddMonths(-6))

                        cmd.Parameters.AddWithValue("data", DataLimite.ToString)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            End If
            Return True
        Catch ex As Exception
            Errore(Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function Convenzioni() As Boolean
        Try
            Log.Info("Convenzioni")

            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString("00000", Utx.ConnessioniDb.Db.SUPPORTO))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    'cancella le convenzioni con codice compagnia diverso da 1
                    cmd.CommandText = "DELETE FROM Convenzioni WHERE Compagnia <> 1"
                    cmd.ExecuteNonQuery()
                End Using

                Utx.FunzioniDb.CancellaChiaveDb(c, "Convenzioni", "pk_Convenzione")
                Utx.FunzioniDb.CreaChiaveDb(c, "Convenzioni", "pk_Convenzione", {"Compagnia", "Codice"})
            End Using
            Return True

        Catch ex As Exception
            Errore(Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function EliminaTabelle(CodiceAgenzia As String) As Boolean
        Try
            Log.Info("EliminaTabelle")

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.POLIZZE))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    'se la tabella esiste
                    If Utx.FunzioniDb.EsisteTabella(c, "Buste") Then
                        cmd.CommandText = "DROP TABLE Buste"
                        cmd.ExecuteNonQuery()
                    End If
                End Using
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function RiletturaSinistri(CodiceAgenzia As String) As Boolean
        Try
            Log.Info("RiletturaSinistri")

            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = "SELECT COUNT(*) FROM Sinistri WHERE DataElaborazione >= #3/1/2018# AND TipoElaborazione = '92'"
                    'se non c'è una elaborazione successiva al 28/02/2018 con flusso mensile (92)
                    If cmd.ExecuteScalar = 0 Then
                        'cancello il file da arp002 per forzare la rilettura
                        cmd.CommandText = "DELETE FROM arp002_file WHERE Right(Nome,10) = '180313.001'"
                        cmd.ExecuteNonQuery()
                    End If
                End Using
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function RecuperoSinistri022018(CodiceAgenzia As String) As Boolean
        Try
            Log.Info("RecuperoSinistri022018")

            Dim CartellaBackup As String = Path.Combine(Utx.Globale.Paths.CartellaBackup, CodiceAgenzia)

            For giorno As Integer = 13 To 5 Step -1

                Dim Backup As String = String.Format("{0}\Giorno{1:00}.zip", CartellaBackup, giorno)
                'se il backup esiste
                If File.Exists(Backup) Then

                    Dim InfoBackup As FileInfo = New FileInfo(Backup)
                    Log.Info("Backup {0} modificato il {1}", {Backup, InfoBackup.LastWriteTime})

                    'se il file è compreso fra il 5/3/2018  e il 31/03/2018
                    If InfoBackup.LastWriteTime >= CDate("05/03/2018") And InfoBackup.LastWriteTime <= CDate("31/03/2018") Then
                        'estraggo il file
                        Dim BackupSinistri As String = Utx.LibreriaZip.EstraiFile(InfoBackup.FullName, Utx.Globale.Paths.CartellaTempUtente, "sinistri.mdb")
                        'se riesco ad estrarre il file sinistri
                        If BackupSinistri <> "" Then
                            Using c As New OleDbConnection(Utx.ConnessioniDb.ConnectionString(CodiceAgenzia, Utx.ConnessioniDb.Db.SINISTRI))
                                c.Open()

                                Using cmd As New OleDbCommand
                                    cmd.Connection = c
                                    cmd.CommandType = CommandType.Text
                                    'sinistri attualmente in archivio
                                    cmd.CommandText = "SELECT COUNT(*) FROM SinistriDP"
                                    Dim SinistriAttuali As Integer = cmd.ExecuteScalar
                                    Log.Info("Record in database {0}", {SinistriAttuali})
                                    'sinistri nel backup
                                    cmd.CommandText = String.Format("SELECT COUNT(*) FROM SinistriDP IN '{0}'", BackupSinistri)
                                    Dim SinistriBackup As Integer = cmd.ExecuteScalar
                                    Log.Info("Record in backup {0}", {SinistriBackup})

                                    If SinistriBackup > SinistriAttuali Then
                                        Log.Info("Recupero sinistri")
                                        'cancello i sinistri attuali
                                        cmd.CommandText = "DELETE FROM SinistriDP"
                                        cmd.ExecuteNonQuery()
                                        'li sostituisco con quelli nel backup
                                        cmd.CommandText = String.Format("INSERT INTO SinistriDP SELECT * FROM SinistriDP IN '{0}'", BackupSinistri)
                                        cmd.ExecuteNonQuery()
                                        Log.Info("Effettuato il recupero di {0} sinistri (precedenti {1})", {SinistriBackup, SinistriAttuali})
                                        'arretro il calendario
                                        ResetCalendarioOmnia(CodiceAgenzia, Enumerazioni.TipoFileMagia.Sinistri)
                                        'forzo la rilettura dei dati
                                        Utx.GestioneFlag.CreaFlag(Utx.GestioneFlag.TipoFlag.DATI_OMNIA_DISPONIBILI)
                                    Else
                                        Log.Info("Recupero solo i flag utente")
                                        'solo recupero i dati utente in seguito al problema del 28/02/2018
                                        Utx.FunzioniDb.CancellaTabella(c, "Recupero")
                                        cmd.CommandText = String.Format("SELECT * INTO Recupero FROM SinistriDP IN '{0}'", BackupSinistri)
                                        cmd.ExecuteNonQuery()
                                        cmd.CommandText = "UPDATE SinistriDP AS S INNER JOIN Recupero AS R " +
                                                          "ON S.Compagnia = R.Compagnia AND S.AgenziaSinistro = R.AgenziaSinistro AND S.EsercizioSinistro = R.EsercizioSinistro AND " +
                                                             "S.NumeroSinistro = R.NumeroSinistro " +
                                                          "SET S.IdStatoCliente = R.IdStatoCliente, S.IdGestione = R.IdGestione, S.FlagUtente = R.FlagUtente, S.Modifica = R.Modifica," +
                                                              "S.RiservaBilancio = R.RiservaBilancio, S.Comparto = R.Comparto"
                                        Log.Info("Aggiornati flag utente per {0} sinistri", {cmd.ExecuteNonQuery()})
                                        Utx.FunzioniDb.CancellaTabella(c, "Recupero")
                                    End If
                                End Using
                            End Using
                            Exit For
                        End If
                    End If
                End If
            Next
            Return True
        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function AggiornaMonitorQT_KMS(CodiceAgenzia As String) As Boolean
        Try
            'lo eseguo solo fino al 31/05/2018
            If Today > CDate("31/05/2018") Then Return True

            Log.Info("AggiornaMonitorQT_KMS")

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.INCASSI))
                c.Open()

                If Utx.FunzioniDb.EsisteTabella(c, "MonitorQT_KMS") Then
                    Using cmd As New OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "UPDATE MonitorQT_KMS SET Fatto = NULL,Flex = NULL,Disdetta = NULL,Sostituita = NULL,Variata = NULL"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE MonitorQT_KMS ALTER COLUMN Fatto YESNO"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE MonitorQT_KMS ALTER COLUMN Flex YESNO"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE MonitorQT_KMS ALTER COLUMN Disdetta YESNO"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE MonitorQT_KMS ALTER COLUMN Sostituita YESNO"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE MonitorQT_KMS ALTER COLUMN Variata YESNO"
                        cmd.ExecuteNonQuery()
                    End Using
                End If
            End Using
            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function AggiornaDbPostalizzazione(CodiceAgenzia As String) As Boolean
        Try
            Log.Info("UpdateDbPostalizzazione")

            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.INFO))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    'aggiungo campo senza premio
                    If Utx.FunzioniDb.EsisteTabella(c, "Postalizzazione") = True Then
                        If Utx.FunzioniDb.EsisteCampo(c, "Postalizzazione", "SenzaPremio") = False Then
                            cmd.CommandText = "ALTER TABLE Postalizzazione ADD COLUMN SenzaPremio YESNO"
                            cmd.ExecuteNonQuery()
                        End If
                    End If
                    If Utx.FunzioniDb.EsisteTabella(c, "OldPostalizzazione") = True Then
                        If Utx.FunzioniDb.EsisteCampo(c, "OldPostalizzazione", "SenzaPremio") = False Then
                            cmd.CommandText = "ALTER TABLE OldPostalizzazione ADD COLUMN SenzaPremio YESNO"
                            cmd.ExecuteNonQuery()
                        End If
                    End If
                End Using
            End Using

            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function Postalizzazione(CodiceAgenzia As String) As Boolean
        Try
            If Today < #2/28/2019# Then 'modifica del 15/02/2019
                Log.Info("Postalizzazione")

                Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.INFO))
                    c.Open()

                    If Utx.FunzioniDb.EsisteTabella(c, "Postalizzazione") Then
                        Using cmd As New OleDbCommand
                            cmd.Connection = c
                            cmd.CommandType = CommandType.Text
                            cmd.CommandText = "UPDATE Postalizzazione SET Selezionato = False WHERE Ramo IN (110,118,126,315)"
                            cmd.ExecuteNonQuery()
                        End Using
                    End If
                End Using
            End If
            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    Public Shared Function AggiornaTabellaClienti(CodiceAgenzia As String) As Boolean
        Try
            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.CLIENTI))
                c.Open()

                If Utx.FunzioniDb.EsisteCampo(c, "Clienti", "AutorizzazioneFea") = False Then
                    Using cmd As New OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "ALTER TABLE Clienti ADD COLUMN AutorizzazioneFEA TEXT(1)"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "ALTER TABLE Clienti ADD COLUMN DataAutorizzazioneFEA DATE"
                        cmd.ExecuteNonQuery()
                    End Using
                End If
            End Using
            Return True

        Catch ex As Exception
            Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
            Return False
        End Try
    End Function

    'Public Shared Function ResetDbLink() As Boolean
    '    Try
    '        Log.Info("ResetDbLink")
    '        Dim CodiceCorrente As String = Utx.Globale.AgenziaRichiesta.CodiceAgenzia

    '        'imposta agenzia e posizione dati dei codici gestiti
    '        For Each codice As String In Utx.EnteGestore.CodiciGestiti
    '            If codice <> CodiceCorrente Then
    '                Utx.Globale.AgenziaRichiesta = New Utx.Agenzia(codice, True)
    '            End If
    '        Next
    '        'imposto agenzia madre
    '        Utx.Globale.AgenziaRichiesta = New Utx.Agenzia(CodiceCorrente, True)
    '        Return True
    '    Catch ex As Exception
    '        Errore("xxxxx", Reflection.MethodBase.GetCurrentMethod.ToString, ex)
    '        Return False
    '    End Try
    'End Function

    Private Shared Function Psico(Agenzia As String)
        Try
            Using c As New OleDb.OleDbConnection(Utx.ConnessioniDb.ConnectionString(Agenzia, Utx.ConnessioniDb.Db.INCASSI))
                c.Open()

                If Utx.FunzioniDb.EsisteCampo(c, "Incassi", "Psico") = False Then
                    Using cmd As New OleDbCommand
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "ALTER TABLE Incassi ADD COLUMN Psico SINGLE"
                        cmd.ExecuteNonQuery()
                        cmd.CommandText = "UPDATE Incassi SET Psico = 0 WHERE Psico IS NULL"
                        cmd.ExecuteNonQuery()
                    End Using
                End If
            End Using
            Log.Info("Allinemento modello INCASSI")
            Using c As New OleDbConnection(Utx.Globale.MDBDriver + Path.Combine(Utx.Globale.Paths.CartellaModelliDatiAgenzia, "Incassi.mdb"))
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text

                    If Utx.FunzioniDb.EsisteCampo(c, "Incassi", "Psico") = False Then
                        cmd.CommandText = "ALTER TABLE Incassi ADD COLUMN Psico SINGLE"
                        cmd.ExecuteNonQuery()
                    End If
                End Using
            End Using
            Return True
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function
    'Public Shared Function MovimentiPrimaNota(CodiceAgenzia As String) As Boolean
    '    Try
    '        Log.Info("MovimentiPrimaNota")

    '        Dim ao As New Utx.AgenziaFigliaOmnia(CodiceAgenzia, Utx.Globale.ProfiloEnteGestore.CodiceSede, False)

    '        If File.Exists(ao.Cartelle.DatabaseDbUno) Then
    '            Log.Info("svuoto mivemti prima nota")

    '            Using c As New OleDbConnection(Utx.Globale.MDBDriverExclusive + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.DBUNO))
    '                c.Open()

    '                Using cmd As New OleDbCommand
    '                    cmd.Connection = c
    '                    cmd.CommandType = CommandType.Text
    '                    cmd.CommandText = "DELETE FROM MovimentiPrimaNota"
    '                    cmd.ExecuteNonQuery()
    '                End Using
    '            End Using
    '        End If

    '        Return True

    '    Catch ex As Exception
    '        Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
    '        Return False
    '    End Try
    'End Function

    'Public Shared Function ManutenzioneSinistriControparte(CodiceAgenzia As String) As Boolean
    '    Try
    '        Log.Info("ManutenzioneSinistriAC")

    '        Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdbAgenzia(CodiceAgenzia, Utx.ConnessioniDb.Db.SINISTRI))
    '            c.Open()

    '            Dim dr As OleDbDataReader = Utx.FunzioniDb.CreaDataReader(c, "SELECT DISTINCT EsercizioSinistro FROM SinistriAC")

    '            Do While dr.Read
    '                Using da As New OleDbDataAdapter(String.Format("SELECT NumeroSinistro FROM SinistriAC WHERE EsercizioSinistro = {0} ORDER BY NumeroSinistro",
    '                                                               dr("EsercizioSinistro")), c)
    '                    Dim dt As New DataTable
    '                    da.Fill(dt)

    '                    Dim Progressivo As Integer = 1

    '                    For Each row As DataRow In dt.Rows
    '                        row("NumeroSinistro") = Progressivo
    '                        Progressivo += 1
    '                    Next

    '                    'aggiorno il db
    '                    Using cmd As New OleDbCommand
    '                        cmd.Connection = c
    '                        cmd.CommandType = CommandType.Text
    '                        cmd.CommandText = "UPDATE SinistriAC SET NumeroSinistro = ?"
    '                        cmd.Parameters.AddWithValue("Numero", dt).SourceColumn = "NumeroSinistro"

    '                        'aggiorno il db
    '                        da.UpdateCommand = cmd
    '                        da.Update(dt)
    '                    End Using
    '                End Using
    '            Loop
    '        End Using

    '        Return True

    '    Catch ex As Exception
    '        Errore(CodiceAgenzia, Reflection.MethodBase.GetCurrentMethod.ToString, ex)
    '        Return False
    '    End Try
    'End Function
End Class
