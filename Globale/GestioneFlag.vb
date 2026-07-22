Imports System.IO

Public Class GestioneFlag
    'gestione dei flag interop
    Public Enum TipoFlag
        INCASSI = 1
        ARRETRATI = 2
        IMPORTA_DATI_OMNIA = 3
        IMPORTA_DATI_DOWNLOAD = 4
        DATI_DOWNLOAD_DISPONIBILI = 5
        DATI_OMNIA_DISPONIBILI = 6
        ID_APP = 7
        AGGIORNAMENTO_INCASSI = 8
        AGGIORNAMENTO_VARIAZIONI = 9
        AGGIORNAMENTO_ARRETRATI = 10
        ESECUZIONE_MERGE_DATI = 11
        CONSOLIDAMENTO_SINISTRI = 12
        AGGIORNAMENTO_BDA = 13
        MANUTENZIONE_NOTE = 14
        PULIZIA_NOTE = 15
        LIVE_CHANGE = 16
        SINISTRI_CONTROPARTE = 17
        AVANZAMENTO_PSICO = 18
        CONTROLLO_COMPAGNIA_UNIPOL = 19
        CONTROLLO_COMPAGNIA_UNISALUTE = 20
        'auto processi
        AUTO_UTWITT = 50
        AUTO_INCASSI = 51
        AUTO_IMPORT_OMNIA = 52
        AUTO_IMPORT_DOWNLOAD_AGENZIE = 53
        AUTO_BACKUP = 54
        AUTO_LISTE_UTENTI = 55
        AUTO_LIVE_UPDATE = 56
        AUTO_ANALISI_DB = 57
        AUTO_INTEGRITA_DB = 58
        'config
        EMAIL_PREDEFINITE = 100
        SMTP = 101
        IP_SERVER = 102
        SINCRO_DATI = 103
        SCANNER_PREDEFINITO = 104
        CARTELLA_SCANNER_RETE = 105
        RITARDO_TIMER_RICERCA = 106
        LIVELLO_LOG = 107
        LOGIN_RICHIESTO = 108
        ABILITAZIONI_AGENZIA = 109
        FORZA_SMTP_AUA = 110
        CARTELLA_STORICO_DOC = 111
        'centralino
        CENTRALINO_AUTOSTART = 150
        CENTRALINO_SECONDI = 151
        CENTRALINO_CARTELLA = 152
        CENTRALINO_PATTERN = 153
        CENTRALINO_COMANDO = 154
        'link posta e varie
        CASELLA_EMAIL_LINK0 = 200
        CASELLA_EMAIL_LINK1 = 201
        CASELLA_EMAIL_LINK2 = 202
        CASELLA_EMAIL_LINK3 = 203
        'utenti/operazioni
        UTENTE_MERGE_DATI_OMNIA = 300
        UTENTE_MERGE_DATI_DL = 301
        UTENTE_IMPORTA_DATI_OMNIA = 302
        UTENTE_IMPORTA_DATI_DL = 303
        'blocchi
        BLOCCO_LISTE_RETE = 400
        'sessione
        INVITO_CHIUSURA_SESSIONE = 451
        PROSSIMO_AUTOSTART = 452
        'copertina
        CopertinaA3 = 500
        CopertinaCliente = 501
        CopertinaSituazione = 502
        CopertinaNote = 503
        CopertinaFasiVendita = 504
        CopertinaAnalisiRca = 505
        CopertinaSelezionaTutto = 506
        'sintesi cliente
        RiepilogoArretrati = 510
        RiepilogoAvvisi = 511
        RiepilogoDatiAnagrafici = 512
        RiepilogoIncassi = 513
        RiepilogoPolizzeAuto = 514
        RiepilogoPolizzeRE = 515
        RiepilogoPolizzeVita = 516
        RiepilogoRapportoSP = 517
        RiepilogoSinistri = 518
        RiepilogoSelezionaTutto = 519
        'postalizzazione
        POSTALIZZAZIONE_CODICI_ABILITATI = 600
        POSTALIZZAZIONE_PROSSIMA_ESECUZIONE = 601
        POSTALIZZAZIONE_ESECUZIONE = 602
        POSTALIZZAZIONE_NOTIFICHE = 603
        POSTALIZZAZIONE_UTENTI = 604
        POSTALIZZAZIONE_RID = 605
        POSTALIZZAZIONE_AUTO_BLOCCO = 606
        POSTALIZZAZIONE_DOMICILIO = 607
        'varie
        INVIO_LOG_USO = 900
        AGGIORNA_DATA_NOTE = 901
        RECUPERO_INCASSI_UNIBOX = 902
        MD5_NOTE_OK = 903
        TTY_DATA_UPLOAD_OMNIA = 904
        TTY_DATA_UPLOAD_PNOTA = 905
        TTY_AUTHKEY = 906
        TTY_FUNZIONALITA = 907
        TTY_STEP_ID = 908
        TTY_DATA_UPLOAD_PNOTA_ESSIG = 909
        TTY_DATA_UPLOAD_PNOTA_ESSIG_NC = 910
        RILETTURA_INCASSI = 911 'in corso
        DATA_RILETTURA_FILE_INCASSI = 912 'ultima data rilettura file incassi
        DATA_RILETTURA_INCASSI = 913 'ultima rilettura massiva degli incassi
        VERIFICA_RILETTURA_FILE = 914
        ZOOM = 915
        CHIUSURA_FORZATA = 916
        PROFILAZIONE = 917
        COMPATTAZIONE_ARCHIVI = 918
        PROSSIMA_COMPATTAZIONE_ARCHIVI = 919
        INVIO_LOG_ANAG = 920
        INVIO_LOG_DOCUMENTI = 921
        MENU_EXTRA = 922
        'esportazione dati
        MIGRAZIONE_DATI = 940
        MIGRAZIONE_ERRORE = 941
        MIGRAZIONE_INVIO_DATI = 942
        MIGRAZIONE_INVIO_IN_CORSO = 943
        'login ow
        OW1 = 953
        OW2 = 954
        'migrazione sql server web
        MIGRAZIONE_NOTE_WEB = 960
        MIGRAZIONE_STORICO_NOTE_WEB = 961
    End Enum

    Public Shared Sub CreaFlag(Tipo As TipoFlag)
        Utx.Globale.SettingInterop.AggiungiModifica(Tipo, Format(Now, "dd/MM/yyyy HH:mm:ss"))
    End Sub

    Public Shared Sub CreaFlag(Tipo As TipoFlag, DataOra As DateTime)
        Utx.Globale.SettingInterop.AggiungiModifica(Tipo, Format(DataOra, "dd/MM/yyyy HH:mm:ss"))
    End Sub

    Public Shared Sub CancellaFlag(Tipo As TipoFlag)
        Utx.Globale.SettingInterop.Rimuovi(Tipo)
    End Sub

    Public Shared Function EsisteFlag(Tipo As TipoFlag,
                                      Optional MaxDurataMinuti As Integer = 0,
                                      Optional Setting As Utx.ApplicationUserSetting = Nothing) As Boolean
        Try
            If Setting Is Nothing Then
                Setting = Utx.Globale.SettingInterop
            End If

            If Setting.EsisteChiave(Tipo) = True Then

                'con MaxDurataMinuti = 0 il flag non scade
                If MaxDurataMinuti = 0 Then
                    Return True
                Else
                    'se il file esiste controlla la data di creazione scritta nel testo
                    Dim Valore As String = Setting.LeggiValore(Tipo)

                    If IsDate(Valore) Then
                        Dim ScadenzaFlag As Date = CDate(Valore).AddMinutes(MaxDurataMinuti)

                        If ScadenzaFlag < Now Then
                            'ora (now) il flag è scaduto ed è probabile ci sia stato un blocco e quindi lo cancello
                            CancellaFlag(Tipo)
                            Return False
                        Else
                            Return True
                        End If
                    Else
                        CancellaFlag(Tipo)
                        Return False
                    End If
                End If
            Else
                Return False
            End If

        Catch ex As Exception
            CancellaFlag(Tipo)
            Globale.Log.Errore(ex, False)
            Return False
        End Try
    End Function
End Class
