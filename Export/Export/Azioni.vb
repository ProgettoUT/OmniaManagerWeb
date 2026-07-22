Imports System.Data
Imports System.Windows.Forms

Public Class Azioni

    Private WithEvents Importa As New ExportLib.Export
    Public WithEvents Notifica As Utx.FormNotifica

    Sub New()
        Notifica = New Utx.FormNotifica()
    End Sub

    Private mOpzioniScarico As New ExportLib.ConfigScaricoIncassi
    Public Property OpzioniScarico() As ExportLib.ConfigScaricoIncassi
        Get
            Return mOpzioniScarico
        End Get
        Set(value As ExportLib.ConfigScaricoIncassi)
            mOpzioniScarico = value
        End Set
    End Property

    Public Shared Sub LoginRefresh()
        Dim t As New Threading.Thread(Sub()
                                          Try
                                              'faccio una chiamata al menù per simulare attività dell'utente
                                              'unipol
                                              Dim Essig As New RichiesteEssig(RichiesteEssig.TipoRichiesta.ESITATI, RichiesteEssig.TipoCompagnia.UNIPOL)
                                              Essig.ChiamaMenu()
                                              'unisalute
                                              Essig.Compagnia = RichiesteEssig.TipoCompagnia.UNISALUTE
                                              Essig.ChiamaMenu()

                                              Utx.Globale.LoginUniage.UltimoLogin = Now
                                              Utx.Globale.Log.Info("Eseguito un refresh della sessione ueba")
                                          Catch ex As Exception
                                              Utx.Globale.Log.Info(ex)
                                          End Try
                                      End Sub)
        t.Start()
    End Sub

#Region "incassi"
    Public Sub AggiornaIncassiConOpzioni()
        Try
            If OpzioniScarico.e.Errore = False Then
                OpzioniScarico.EsecuzioneAutomatica = False

                Using f As New ExportLib.FormImportaIncassi
                    f.OpzioniScarico = OpzioniScarico
                    f.ShowDialog()

                    If f.DialogResult = Windows.Forms.DialogResult.OK Then

                        If f.OpzioniScarico.ScaricaFile = True Then
                            If OpzioniScarico.Forzatura = True OrElse JobEsitati.ConsensoFasceOrarie(f.OpzioniScarico.InizioPeriodo) = True Then
                                RiletturaFileIncassi()
                            Else
                                Dim Job As New JobEsitati
                                Job.Salva(f.OpzioniScarico)
                                JobEsitati.Messaggio() 'visualizzo messaggio
                            End If
                        Else
                            AggiornaIncassi()
                        End If
                    End If
                End Using
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub AggiornaIncassi()
        'richiamato direttamente anche da adempimenti, budget ecc. per aggiornamento incassi
        Try
            'leggo chiave INTEROP per vedere se è già in corso una importazione
            Dim Chiave As New Utx.SettingItem(Utx.SettingItem.Sezioni.INTEROP, Utx.SettingItem.Chiavi.IMPORTAZIONE_INCASSI, "",
                                              Utx.SettingOMW.TipoOperazione.LETTURA)

            If Chiave.ItemResult.Esiste Then
                MsgBox("E' già in corso importazione degli incassi.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            Else
                'creo blocco per gli altri utenti
                Chiave.SetItem(Utx.SettingItem.Sezioni.INTEROP, Utx.SettingItem.Chiavi.IMPORTAZIONE_INCASSI,
                               Utx.SettingItem.Valori.BLOCCO.ToString, Utx.SettingOMW.TipoOperazione.SCRITTURA)

                Utx.ApplicationLog.LogUso("Aggiorna incassi")
                With Notifica
                    .ColoreSfondo = Drawing.Color.PaleGreen
                    .Opacity = 0.8
                    .Text = ""
                    .Show()
                    .Messaggio = "Aggiorna incassi. Attendere..."
                End With

                'incassi
                AddHandler Importa.StatoImportazione, AddressOf CambiaStatoImportazioneIncassi
                Importa.AggiornaIncassi(OpzioniScarico)

                Notifica.Messaggio = "Aggiornamento incassi completato."
                AggiornaVariazioni()

                'prossimo controllo domani mattina dopo le 8
                Chiave.SetItem(Utx.SettingItem.Sezioni.AUTOMATISMI, Utx.SettingItem.Chiavi.IMPORTAZIONE_INCASSI,
                               Format(Now.AddDays(1), "dd/MM/yyyy 08:00:00"), Utx.SettingOMW.TipoOperazione.SCRITTURA)
                'info
                Chiave.SetItem(Utx.SettingItem.Sezioni.INFO, Utx.SettingItem.Chiavi.IMPORTAZIONE_INCASSI,
                               Now.ToString, Utx.SettingOMW.TipoOperazione.SCRITTURA)
                'rimuovo blocco
                Chiave.SetItem(Utx.SettingItem.Sezioni.INTEROP, Utx.SettingItem.Chiavi.IMPORTAZIONE_INCASSI, "",
                               Utx.SettingOMW.TipoOperazione.CANCELLAZIONE)
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub RiletturaFileIncassi(ScaricareDal As Date,
                                    ScaricatiPrimaDel As Date)
        'automatismo da programma
        Try
            'avvia processo
            'aggiorna file
            AddHandler Importa.StatoImportazione, AddressOf CambiaStatoImportazioneIncassi
            Importa.AggiornaFile(ScaricareDal, ScaricatiPrimaDel, OpzioniScarico)
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub RiletturaFileIncassi()
        'richiesta manuale
        Try
            Dim Chiave As New Utx.SettingItem(Utx.SettingItem.Sezioni.INTEROP, Utx.SettingItem.Chiavi.IMPORTAZIONE_INCASSI,
                                              Utx.SettingOMW.TipoOperazione.LETTURA)
            'se non è già in corso una rilettura dei file da essig
            If Chiave.ItemResult.Esiste Then
                MsgBox("E' già in corso importazione degli incassi.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            Else
                'creo blocco per gli altri utenti
                Chiave.SetItem(Utx.SettingItem.Sezioni.INTEROP, Utx.SettingItem.Chiavi.IMPORTAZIONE_INCASSI,
                                   Utx.SettingItem.Valori.BLOCCO.ToString, Utx.SettingOMW.TipoOperazione.SCRITTURA)

                'avvia processo
                With Notifica
                    .ColoreSfondo = Drawing.Color.PaleGreen
                    .Opacity = 0.8
                    .Text = ""
                    .Show()

                    .Messaggio = "Aggiorna incassi. Attendere..."
                End With

                'incassi
                AddHandler Importa.StatoImportazione, AddressOf CambiaStatoImportazioneIncassi
                Importa.AggiornaFile(OpzioniScarico.InizioPeriodo, OpzioniScarico)

                Chiave.SetItem(Utx.SettingItem.Sezioni.INFO, Utx.SettingItem.Chiavi.IMPORTAZIONE_INCASSI, Now.ToString,
                                   Utx.SettingOMW.TipoOperazione.SCRITTURA)
                'rimuovo blocco utenti
                Chiave.SetItem(Utx.SettingItem.Sezioni.INTEROP, Utx.SettingItem.Chiavi.IMPORTAZIONE_INCASSI, "",
                                   Utx.SettingOMW.TipoOperazione.CANCELLAZIONE)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Friend Sub CambiaStatoImportazioneIncassi(e As ExportLib.ExportEventArgs)
        Try
            If e.Errore = True Then
                Notifica.ColoreSfondo = Drawing.Color.Orange
                Notifica.Refresh()

                If e.Messaggio.Trim.Length = 0 Then
                    e.Messaggio = "Errore non previsto"
                End If

                Notifica.Messaggio = String.Format("Agenzia: {1} ({2}) - Sub: {3}{0}{4}",
                                                   Environment.NewLine,
                                                   e.AgenziaMadre,
                                                   e.AgenziaFiglia,
                                                   IIf(e.SubAgenzia.Trim.Length = 0, "Tutte", e.SubAgenzia),
                                                   e.Messaggio)

            ElseIf e.Messaggio.Trim.Length > 0 Then
                Notifica.ColoreSfondo = Drawing.Color.PaleGreen
                Notifica.Refresh()
                Notifica.Messaggio = String.Format("Agenzia: {1} ({2}{3}) - Sub: {4}{0}{5}",
                                                   Environment.NewLine,
                                                   e.AgenziaMadre,
                                                   e.AgenziaFiglia,
                                                   IIf(e.Unisalute, " UniSalute", ""),
                                                   IIf(e.SubAgenzia.Trim.Length = 0, "Tutte", e.SubAgenzia),
                                                   e.Messaggio)
            Else
                Notifica.ColoreSfondo = Drawing.Color.PaleGreen
                Notifica.Refresh()
                Notifica.Messaggio = String.Format("Agenzia: {1} ({2}{3}) - Sub: {4}{0}Importazione incassi del {5}",
                                                   Environment.NewLine,
                                                   e.AgenziaMadre,
                                                   e.AgenziaFiglia,
                                                   IIf(e.Unisalute, " UniSalute", ""),
                                                   IIf(e.SubAgenzia.Trim.Length = 0, "Tutte", e.SubAgenzia),
                                                   IIf(e.InizioPeriodo < #1/1/2000#, "...", e.InizioPeriodo.ToShortDateString))
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Notifica.TopMost = True
        End Try
    End Sub
#End Region

#Region "variazioni"
    Public Sub AggiornaVariazioni()
        Try
            'il controllo flag non serve perché l'aggiornamento delle variazioni è sempre in coda all'aggiornamento degli incassi
            With Notifica
                .ColoreSfondo = Drawing.Color.LightYellow
                .Opacity = 0.8
                .Text = ""
                .Show()

                .Messaggio = "Aggiorna variazioni/sostituzioni. Attendere..."
            End With

            AddHandler Importa.StatoImportazione, AddressOf CambiaStatoImportazioneVariazioni
            Importa.AggiornaVariazioni(OpzioniScarico)

            'registra data ultimo aggiornamento
            Utx.GestioneFlag.CreaFlag(Utx.GestioneFlag.TipoFlag.AGGIORNAMENTO_VARIAZIONI)

            Notifica.Messaggio = "Aggiornamento variazioni completato"

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Friend Sub CambiaStatoImportazioneVariazioni(e As ExportLib.ExportEventArgs)

        Try
            If e.Errore = True Then

                Notifica.ColoreSfondo = Drawing.Color.Orange
                Notifica.Refresh()

                If e.Messaggio.Trim.Length = 0 Then
                    e.Messaggio = "Errore non previsto"
                End If

                Notifica.Messaggio = String.Format("Agenzia: {1} ({2}) - Sub: {3}{0}{4}",
                                                   Environment.NewLine,
                                                   e.AgenziaMadre,
                                                   e.AgenziaFiglia,
                                                   IIf(e.SubAgenzia.Trim.Length = 0, "Tutte", e.SubAgenzia),
                                                   e.Messaggio)

            ElseIf e.Messaggio.Trim.Length > 0 Then

                If e.Errore = True Then
                    Notifica.ColoreSfondo = Drawing.Color.Orange
                End If

                Notifica.Messaggio = String.Format("Agenzia: {1} ({2}) - Sub: {3}{0}{4}",
                                                   Environment.NewLine,
                                                   e.AgenziaMadre,
                                                   e.AgenziaFiglia,
                                                   IIf(e.SubAgenzia.Trim.Length = 0, "Tutte", e.SubAgenzia),
                                                   e.Messaggio)
            Else
                Notifica.Messaggio = String.Format("Agenzia: {1} ({2}) - Sub: {3}{0}Importazione variazioni al {4}",
                                                   Environment.NewLine,
                                                   e.AgenziaMadre,
                                                   e.AgenziaFiglia,
                                                   IIf(e.SubAgenzia.Trim.Length = 0, "Tutte", e.SubAgenzia),
                                                   e.FinePeriodo.ToShortDateString)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Notifica.TopMost = True
        End Try
    End Sub
#End Region

#Region "arretrati"
    Public Sub AggiornaArretrati()
#If DEBUG Then
        Utx.GestioneFlag.CancellaFlag(Utx.GestioneFlag.TipoFlag.ARRETRATI)
#End If
        Try
            If Utx.Globale.UtenteCorrente.Profilo.ProfiloUnipol <> "A" Then
                MsgBox("L'aggiornamento degli arretrati è possibile solo agli utenti con profilo Essig A", MsgBoxStyle.Information + vbSystemModal, Utx.Globale.TitoloApp)
                Exit Sub
            End If

            Dim Chiave As New Utx.SettingItem(Utx.SettingItem.Sezioni.INTEROP, Utx.SettingItem.Chiavi.IMPORTAZIONE_INCASSI,
                                              Utx.SettingOMW.TipoOperazione.LETTURA)

#If DEBUG Then
            If Chiave.ItemResult.Esiste Then
                Chiave.Operazione = Utx.SettingOMW.TipoOperazione.CANCELLAZIONE
            End If
#End If
            If Chiave.ItemResult.Esiste Then
                MsgBox("E' già in corso una importazione. Attendere e riprovare.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            Else
                Using f As New ExportLib.FormArretrati
                    f.ShowDialog()

                    If f.DialogResult = Windows.Forms.DialogResult.OK Then
                        'crea blocco
                        Chiave.SetItem(Utx.SettingItem.Sezioni.INTEROP, Utx.SettingItem.Chiavi.IMPORTAZIONE_INCASSI,
                               Utx.SettingItem.Valori.BLOCCO.ToString, Utx.SettingOMW.TipoOperazione.SCRITTURA)

                        With Notifica
                            .Stile = Utx.FormNotifica.Style.BIANCO_ROSSO
                            .Opacity = 1
                            .Text = ""
                            .Show()
                            .Messaggio = "Aggiorna arretrati. Attendere..."
                        End With

                        Importa = New Export()

                        AddHandler Importa.StatoImportazione, AddressOf CambiaStatoImportazioneArretrati
                        Importa.AggiornaArretrati(f.InizioPeriodo, f.FinePeriodo, f.SoloCodiceSelezionato)

                        'registra data ultimo aggiornamento
                        Chiave.SetItem(Utx.SettingItem.Sezioni.INFO, Utx.SettingItem.Chiavi.IMPORTAZIONE_ARRETRATI, Now.ToString,
                                           Utx.SettingOMW.TipoOperazione.SCRITTURA)

                        Notifica.Messaggio = "Aggiornamento arretrati completato"

                        Chiave.SetItem(Utx.SettingItem.Sezioni.INTEROP, Utx.SettingItem.Chiavi.IMPORTAZIONE_INCASSI, "",
                                       Utx.SettingOMW.TipoOperazione.CANCELLAZIONE)

                        Utx.Globale.SessioneCorrente.LetturaArretrati = Now
                    End If
                End Using
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Utx.GestioneFlag.CancellaFlag(Utx.GestioneFlag.TipoFlag.ARRETRATI)
        End Try
    End Sub

    Public Sub AggiornaPostalizzazione(Agenzia As UniCom.AgenziaConfigPostalizzazione,
                                       Inizio As Date,
                                       Fine As Date)
#If DEBUG Then
        Utx.GestioneFlag.CancellaFlag(Utx.GestioneFlag.TipoFlag.ARRETRATI)
#End If
        Try
            'controllo flag
            If Utx.GestioneFlag.EsisteFlag(Utx.GestioneFlag.TipoFlag.ARRETRATI, 15) Then
                MsgBox("Importazione arretrati già in esecuzione. Riprovare più tardi.",
                       MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Exit Sub
            End If
            'crea flag
            Utx.GestioneFlag.CreaFlag(Utx.GestioneFlag.TipoFlag.ARRETRATI)

            With Notifica
                .Stile = Utx.FormNotifica.Style.BIANCO_ROSSO
                .LabelMessaggio.Font = Utx.AppFont.Bold
                .Text = ""
                .Show()

                .Messaggio = String.Format("Postalizzazione {1}{0}aggiorno titoli periodo {2:MM-yyyy}{0}{0}Attendere...", Environment.NewLine, Agenzia.Agenzia, Inizio)
            End With

            Dim Postalizzazione As New ExportLib.Postalizzazione With {.Agenzia = Agenzia.Agenzia, .Cookie = Utx.Globale.LoginUniage.CookieContainer}
            AddHandler Postalizzazione.StatoImportazione, AddressOf CambiaStatoImportazioneArretrati

            Dim Esito As Boolean = Postalizzazione.CatturaArretrati(Inizio, Fine)
            If Esito = True Then
                Agenzia.LetturaArretrati = True
                Notifica.SecondiChiusura = 1
            Else
                Agenzia.LetturaArretrati = False
                Notifica.Messaggio = String.Format("Postalizzazione {1}{0}impossibile scaricare i dati del periodo {2:MM-yyyy}{0}{0}POSTALIZZAZIONE NON COMPLETATA", Environment.NewLine, Agenzia.Agenzia, Inizio)
                Notifica.SecondiChiusura = 10
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Agenzia.LetturaArretrati = False
        Finally
            Utx.GestioneFlag.CancellaFlag(Utx.GestioneFlag.TipoFlag.ARRETRATI)
        End Try
    End Sub

    Private Sub CambiaStatoImportazioneArretrati(e As ExportLib.ExportEventArgs)

        If e.Errore = True Then

            Notifica.ColoreSfondo = Drawing.Color.Orange
            Notifica.Refresh()

            If e.Messaggio.Trim.Length = 0 Then
                e.Messaggio = "Errore non previsto"
            End If

            Notifica.Messaggio = String.Format("Agenzia: {1} - Sub: {2}{0}{3}",
                                               Environment.NewLine,
                                               e.AgenziaMadre,
                                               IIf(e.SubAgenzia.Trim.Length = 0, "Tutte", e.SubAgenzia),
                                               e.Messaggio)

        ElseIf e.Messaggio.Trim.Length > 0 Then

            If e.Errore = True Then
                Notifica.ColoreSfondo = Drawing.Color.Orange
            End If

            Notifica.Messaggio = String.Format("Agenzia: {1} {4} - Sub: {2}{0}{3}",
                                               Environment.NewLine,
                                               e.AgenziaMadre,
                                               IIf(e.SubAgenzia.Trim.Length = 0, "Tutte", e.SubAgenzia),
                                               e.Messaggio,
                                               IIf(e.Unisalute, " UniSalute", ""))
        Else
            Notifica.Messaggio = String.Format("Agenzia: {1} {4} - Sub: {2}{0}Aggiornamento arretrati al {3}",
                                               Environment.NewLine,
                                               e.AgenziaMadre,
                                               IIf(e.SubAgenzia.Trim.Length = 0, "Tutte", e.SubAgenzia),
                                               IIf(e.FinePeriodo < #1/1/2000#, "...", e.FinePeriodo.ToShortDateString),
                                               IIf(e.Unisalute, " UniSalute", ""))
        End If

        Notifica.TopMost = True
    End Sub

    Public Sub AnalisiOrariIncassi(Agenzia As String, Giorno As Date)
        Try
            'controllo flag
            If Utx.GestioneFlag.EsisteFlag(Utx.GestioneFlag.TipoFlag.ARRETRATI, 15) Then
                MsgBox("Importazione arretrati già in esecuzione. Riprovare più tardi.",
                       MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Exit Sub
            End If
            'crea flag
            Utx.GestioneFlag.CreaFlag(Utx.GestioneFlag.TipoFlag.ARRETRATI)

            With Notifica
                .Stile = Utx.FormNotifica.Style.BIANCO_ROSSO
                .LabelMessaggio.Font = Utx.AppFont.Bold
                .Text = ""
                .Show()

                .Messaggio = "Analisi orari incassi"
            End With

            Dim Giornale As New ExportLib.GiornaleCassa
            Giornale.Cookie = Utx.Globale.LoginUniage.CookieContainer

            Giornale.AnalisiFasceOrarie(Agenzia, Giorno)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Utx.GestioneFlag.CancellaFlag(Utx.GestioneFlag.TipoFlag.ARRETRATI)
        End Try
    End Sub
#End Region

#Region "Cassa"
    Public Sub AggiornaCassa()
        Try
            'flag
            Utx.GestioneFlag.CreaFlag(Utx.GestioneFlag.TipoFlag.INCASSI)

            With Notifica
                .ColoreSfondo = Drawing.Color.PaleGreen
                .Opacity = 0.8
                .Text = ""
                .Show()

                .Messaggio = "Aggiorna cassa. Attendere..."
            End With

            'incassi
            AddHandler Importa.StatoImportazione, AddressOf CambiaStatoImportazioneIncassi
            Importa.AggiornaCassa(Today, Today)

            Notifica.Messaggio = "Aggiornamento cassa completato."

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Utx.GestioneFlag.CancellaFlag(Utx.GestioneFlag.TipoFlag.INCASSI)
        End Try
    End Sub
#End Region

#Region "Liste"
    Public Sub AggiornaListeEssig(Optional Forzatura As Boolean = False)
        Try
            Dim Chiave As Utx.SettingItem

            If Forzatura = True Then
                'cancello una eventuale esclusione dell'utente così da resettare la chiave
                Chiave = New Utx.SettingItem(Utx.SettingItem.Sezioni.ESCLUSIONI,
                                             Utx.SettingItem.Chiavi.LISTE_UTENTI,
                                             Utx.Globale.UtenteCorrente.UniageUser.ToUpper,
                                             Utx.SettingOMW.TipoOperazione.CANCELLAZIONE_CON_VALORE)
            Else
                Chiave = New Utx.SettingItem(Utx.SettingItem.Sezioni.ESCLUSIONI,
                                             Utx.SettingItem.Chiavi.LISTE_UTENTI,
                                             Utx.Globale.UtenteCorrente.UniageUser.ToUpper,
                                             Utx.SettingOMW.TipoOperazione.LETTURA_CON_VALORE)
                'se c'è l'esclusione esco
                If Chiave.ItemResult.Esiste Then Exit Sub
            End If

            'leggo da data dell'ultimo aggiornamento
            Chiave.SetItem(Utx.SettingItem.Sezioni.AUTOMATISMI,
                           Utx.SettingItem.Chiavi.LISTE_UTENTI,
                           "",
                           Utx.SettingOMW.TipoOperazione.LETTURA)

            If Chiave.ItemResult.Valore < Now OrElse (Forzatura = True) Then
                'creo blocco per gli altri utenti
                Chiave.SetItem(Utx.SettingItem.Sezioni.INTEROP,
                                   Utx.SettingItem.Chiavi.LISTE_UTENTI,
                                   "BLOCCO",
                                   Utx.SettingOMW.TipoOperazione.SCRITTURA)

                Try
                    With Notifica
                        .ColoreSfondo = Drawing.Color.WhiteSmoke
                        .Opacity = 0.8
                        .Show()
                        .Messaggio = "Aggiornamento CIP/utenze..."
                    End With

                    If Importa.AggiornaListeEssigReti(OpzioniScarico) = True Then
                        'registra data prossimo controllo: prossimo lunedì dalle ore 7
                        Chiave.SetItem(Utx.SettingItem.Sezioni.AUTOMATISMI,
                                           Utx.SettingItem.Chiavi.LISTE_UTENTI,
                                           Format(Utx.FunzioniData.ProssimoGiornoDeterminato(DayOfWeek.Monday), "dd/MM/yyyy 07:00:00"),
                                           Utx.SettingOMW.TipoOperazione.SCRITTURA)

                        With Notifica
                            .LabelMessaggio.Font = Utx.AppFont.Bold
                            .Messaggio = "Aggiornate liste CIP/utenze"
                        End With
                        Notifica.LabelMessaggio.BackColor = Drawing.Color.Khaki
                    Else
                        Chiave.SetItem(Utx.SettingItem.Sezioni.ESCLUSIONI,
                                       Utx.SettingItem.Chiavi.LISTE_UTENTI,
                                       Utx.Globale.UtenteCorrente.UniageUser,
                                       Utx.SettingOMW.TipoOperazione.SCRITTURA_CON_VALORE)
                        Notifica.Messaggio = "Per aggiornare CIP/utenze è necessaria un'utenza con accesso a Essig 'Gestione rete'"
                        Notifica.SecondiChiusura = 3
                    End If
                Catch ex As Exception
                    Chiave.SetItem(Utx.SettingItem.Sezioni.AUTOMATISMI,
                                       Utx.SettingItem.Chiavi.LISTE_UTENTI,
                                       Now.AddHours(1).ToString,
                                       Utx.SettingOMW.TipoOperazione.SCRITTURA)
                    Globale.Log.Errore(ex)
                    Notifica.SecondiChiusura = 5
                Finally
                    ChiudiNotifica()
                    End Try
                    'rimuovo blocco
                    Chiave.SetItem(Utx.SettingItem.Sezioni.INTEROP,
                                   Utx.SettingItem.Chiavi.LISTE_UTENTI,
                                   "",
                                   Utx.SettingOMW.TipoOperazione.CANCELLAZIONE)
                End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub
#End Region

#Region "BDA"
    Public Sub InterrogaBDA(ByRef OpzioniDBA As ExportLib.BancaDatiAnia.Opzioni)
        Try
            'flag
            Utx.GestioneFlag.CreaFlag(Utx.GestioneFlag.TipoFlag.AGGIORNAMENTO_BDA)

            With Notifica
                .ColoreSfondo = Drawing.Color.PaleGreen
                .Opacity = 0.8
                .Text = ""
                .AnnullaOperazione = True
                .Show()

                .Messaggio = "Lettura BDA. Attendere..."
            End With

            'incassi
            AddHandler Importa.StatoImportazione, AddressOf CambiaStatoBDA
            Importa.InterrogaBDA(OpzioniDBA)

            Notifica.Messaggio = "Interrogazione BDA completata"
            'Notifica.Chiudi()
            ChiudiNotifica()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Utx.GestioneFlag.CancellaFlag(Utx.GestioneFlag.TipoFlag.AGGIORNAMENTO_BDA)
        End Try
    End Sub

    Public Function InterrogaBDATargaSingola(Targa As String, ClasseRca As String, Optional ConNotifica As Boolean = True) As BancaDatiAnia.BDATarga
        Try
            Dim OpzioniDBA As New ExportLib.BancaDatiAnia.Opzioni With {.TargaSingola = Targa, .ClasseRca = ClasseRca}

            If ConNotifica Then
                With Notifica
                    .ColoreSfondo = Drawing.Color.PaleGreen
                    .Opacity = 0.8
                    .Text = ""
                    .Show()
                    .Messaggio = "Lettura BDA. Attendere..."
                End With
            End If

            AddHandler Importa.StatoImportazione, AddressOf CambiaStatoBDA

            Return Importa.InterrogaBDATargaSingola(OpzioniDBA)

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return Nothing
        Finally
            If ConNotifica Then Notifica.ChiusuraImmediata()
        End Try
    End Function

    Public Shared Function VisualizzaBDATarga(Targa As String,
                                              EffettoTitolo As Date,
                                              RataIntermedia As String,
                                              ClasseRca As String) As ExportLib.BancaDatiAnia.BDATarga
        Try
            If RataIntermedia = "S" Then
                MsgBox("Non si tratta di una scadenza annuale", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Return Nothing
            ElseIf EffettoTitolo > Today Then
                MsgBox("La polizza non è ancora scaduta", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Return Nothing
            End If

            Dim Messaggio As String = "Targa: {1}{0}Compagnia: {2} - {3}{0}Scadenza contratto: {4:dd-MM-yyyy}"

            Dim BDATarga As ExportLib.BancaDatiAnia.BDATarga

            Dim Query As String = String.Format("SELECT * FROM Bda WHERE Targa = '{0}'", Targa)
            Dim dr As DataTableReader = Utx.FunzioniDb.CreaDataTableReader(Query)

            If dr.HasRows Then
                dr.Read()

                If IsDBNull(dr("ScadenzaContratto")) = False AndAlso dr("ScadenzaContratto") > Today Then
                    'visualizzo i dati già in archivio
                    BDATarga = New BancaDatiAnia.BDATarga With {
                        .Aggiornato = dr("Aggiornato"),
                        .Compagnia = BancaDatiAnia.BDATarga.CompagniaAnia(dr("CodiceCompagnia")),
                        .ScadenzaContratto = dr("ScadenzaContratto")}
                Else
                    dr.Close()
                    'interrogo DBA
                    Dim az As New ExportLib.Azioni
                    BDATarga = az.InterrogaBDATargaSingola(Targa, ClasseRca, False)
                    If BDATarga.EsitoBDA = True Then
                        AggiornaTargaBda(BDATarga)
                    End If
                End If
            Else
                dr.Close()
                'interrogo DBA
                Dim az As New ExportLib.Azioni
                BDATarga = az.InterrogaBDATargaSingola(Targa, ClasseRca, False)
                If BDATarga.EsitoBDA = False Then
                    'non fare niente
                ElseIf BDATarga Is Nothing Then
                    MsgBox(String.Format("I dati della targa {0} non sono stati trovati", Targa),
                               MsgBoxStyle.Information, "Interrogazione BDA")
                Else
                    'salvo i dati
                    AggiungiTargaBda(BDATarga)
                End If
            End If
            Return BDATarga

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Public Shared Function InterrogaBDATarga(dt As DataTable,
                                             TargaIndex As Integer,
                                             AggiornamentoIndex As Integer,
                                             CompagniaIndex As Integer,
                                             ScadenzaIndex As Integer) As Integer
        Try
            Dim az As New ExportLib.Azioni

            Dim BDATarga As ExportLib.BancaDatiAnia.BDATarga

            For Each row As DataRow In dt.Rows
                If IsDBNull(row("Lettura BDA")) OrElse (row("Lettura BDA").Date < Today) Then
                    Dim targa As String = IIf(TargaIndex <> -1, row(TargaIndex), "")

                    BDATarga = az.InterrogaBDATargaSingola(targa, "", False)

                    If BDATarga.EsitoBDA = False Then
                        'interrompo per probabile errore di essig (500)
                        Exit For

                    ElseIf BDATarga.DatiTrovati = False Then
                        'non fare niente: i dati non sono stati trovati in BDA

                    ElseIf BDATarga IsNot Nothing Then
                        InterrogaBDATarga += 1

                        row(CompagniaIndex) = ""
                        row(ScadenzaIndex) = DBNull.Value
                        row(AggiornamentoIndex) = DBNull.Value
                        row(CompagniaIndex) = BDATarga.Compagnia
                        row(ScadenzaIndex) = Format(BDATarga.ScadenzaContratto, "dd-MM-yyyy")
                        row(AggiornamentoIndex) = Format(Now, "dd-MM-yyyy HH:mm")
                        Windows.Forms.Application.DoEvents()

                        If Utx.WsCommand.ExecuteScalar(String.Format("SELECT COUNT(*) FROM Bda WHERE Targa = '{0}'", targa)).Valore > 0 Then
                            Globale.Log.Info("Aggiorno posizione targa {0}", {targa})
                            AggiornaTargaBda(BDATarga)
                        Else
                            Globale.Log.Info("Inserisco posizione targa {0}", {targa})
                            AggiungiTargaBda(BDATarga)
                        End If
                        Windows.Forms.Application.DoEvents()
                    End If
                End If
            Next

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Function

    Private Shared Function AggiornaTargaBda(BDATarga As BancaDatiAnia.BDATarga) As Integer
        Try
            If BDATarga Is Nothing Then Return 0

            Dim Query As New Utx.NetFunc.StringFormatter("UPDATE BDA 
                SET Aggiornato = @aggiornato,ClasseRca = @classerca,CartaCircolazione = @carta,MotivoEmissioneCarta = @motivo,
                Immatricolazione = @imma,CodiceCompagnia = @compagnia,CodiceFiscale = @cf,Effetto = @effetto,
                ScadenzaCopertura = @copertura,ScadenzaContratto = @contratto,Tariffa = @tariffa,
                ClasseTariffa = @classetariffa,DataSinistro = @sinistro 
                WHERE Targa = @targa")

            With Query
                .Parametro("@aggiornato", Format(Now, "dd/MM/yyyy HH:mm"), True)
                .Parametro("@classerca", BDATarga.ClasseVeicolo, True)
                .Parametro("@carta", Format(BDATarga.CartaCircolazione, "dd/MM/yyyy"), True)
                .Parametro("@motivo", BDATarga.MotivoEmissioneCarta, True)
                .Parametro("@imma", Format(BDATarga.Immatricolazione, "dd/MM/yyyy"), True)
                .Parametro("@compagnia", BDATarga.CodiceCompagnia)
                .Parametro("@cf", BDATarga.CodiceFiscale, True)
                .Parametro("@effetto", Format(BDATarga.Effetto, "dd/MM/yyyy"), True)
                .Parametro("@copertura", Format(BDATarga.ScadenzaCopertura, "dd/MM/yyyy"), True)
                .Parametro("@contratto", Format(BDATarga.ScadenzaContratto, "dd/MM/yyyy"), True)
                .Parametro("@tariffa", BDATarga.Tariffa, True)
                .Parametro("@classetariffa", BDATarga.ClasseTariffa, True)
                .Parametro("@sinistro", Format(BDATarga.DataSinistro, "dd/MM/yyyy"), True)
                .Parametro("@targa", BDATarga.TargaInterrogata, True)
            End With
            Return Utx.WsCommand.ExecuteNonQueryRecord(Query.StringaFormattata)

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return -1
        End Try
    End Function

    Private Shared Function AggiungiTargaBda(BDATarga As BancaDatiAnia.BDATarga) As Integer
        Try
            If BDATarga Is Nothing Then Return 0

            Dim Query As New Utx.NetFunc.StringFormatter("INSERT INTO BDA 
                (BloccoTarga,Aggiornato,Targa,ClasseRca,CartaCircolazione,MotivoEmissioneCarta,Immatricolazione,CodiceCompagnia,
                CodiceFiscale,Effetto,ScadenzaCopertura,ScadenzaContratto,Tariffa,ClasseTariffa,DataSinistro) 
                VALUES(cast(0 as bit),@aggiornato,@targa,@classerca,@carta,@motivo,@imma,@compagnia,
                @cf,@effetto,@copertura,@contratto,@tariffa,@classetariffa,@sinistro)")

            With Query
                .Parametro("@aggiornato", Format(Now, "dd/MM/yyyy HH:mm"), True)
                .Parametro("@targa", BDATarga.TargaInterrogata, True)
                .Parametro("@classerca", BDATarga.ClasseVeicolo, True)
                .Parametro("@carta", Format(BDATarga.CartaCircolazione, "dd/MM/yyyy"), True)
                .Parametro("@motivo", BDATarga.MotivoEmissioneCarta, True)
                .Parametro("@imma", Format(BDATarga.Immatricolazione, "dd/MM/yyyy"), True)
                .Parametro("@compagnia", BDATarga.CodiceCompagnia)
                .Parametro("@cf", BDATarga.CodiceFiscale, True)
                .Parametro("@effetto", Format(BDATarga.Effetto, "dd/MM/yyyy"), True)
                .Parametro("@copertura", Format(BDATarga.ScadenzaCopertura, "dd/MM/yyyy"), True)
                .Parametro("@contratto", Format(BDATarga.ScadenzaContratto, "dd/MM/yyyy"), True)
                .Parametro("@tariffa", BDATarga.Tariffa, True)
                .Parametro("@classetariffa", BDATarga.ClasseTariffa, True)
                .Parametro("@sinistro", Format(BDATarga.DataSinistro, "dd/MM/yyyy"), True)
            End With
            Return Utx.WsCommand.ExecuteNonQueryRecord(Query.StringaFormattata)

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return -1
        End Try
    End Function

    Public Shared Sub AnalisiBDATarga(Agenzia As String,
                                      Targa As String,
                                      EffettoTitolo As Date,
                                      RataIntermedia As String,
                                      ClasseRca As String)
        Try
            Dim BDATarga As ExportLib.BancaDatiAnia.BDATarga

            Dim Query As String = $"SELECT * FROM Bda WHERE Targa = '{Targa}'"
            Dim dr As DataTableReader = Utx.FunzioniDb.CreaDataTableReader(Query)

            If dr.HasRows Then
                dr.Read()

                If dr("Aggiornato") >= Today Then
                    'dati aggiornati oggi
                    Globale.Log.Info($"BDA targa {Targa} già aggiornato oggi")
                    dr.Close()
                ElseIf IsDBNull(dr("ScadenzaContratto")) = False AndAlso dr("ScadenzaContratto") > Today Then
                    'dati già in archivio
                    Globale.Log.Info($"BDA targa {Targa} già in archivio")
                    dr.Close()
                Else
                    dr.Close()
                    'interrogo DBA
                    Dim az As New ExportLib.Azioni
                    BDATarga = az.InterrogaBDATargaSingola(Targa, ClasseRca, ConNotifica:=False)
                    AggiornaTargaBda(BDATarga)
                End If
            Else
                dr.Close()
                'interrogo DBA
                Dim az As New ExportLib.Azioni
                BDATarga = az.InterrogaBDATargaSingola(Targa, ClasseRca, ConNotifica:=False)
                AggiungiTargaBda(BDATarga)
            End If

        Catch ex As Exception
            Globale.Log.Info(ex)
        End Try
    End Sub

    Public Sub AggiornaBDA(ByRef OpzioniDBA As ExportLib.BancaDatiAnia.Opzioni)
        Try
            'flag
            Utx.GestioneFlag.CreaFlag(Utx.GestioneFlag.TipoFlag.AGGIORNAMENTO_BDA)

            With Notifica
                .ColoreSfondo = Drawing.Color.PaleGreen
                .Opacity = 0.8
                .Text = ""
                .AnnullaOperazione = True
                .Show()

                .Messaggio = "Lettura BDA. Attendere..."
            End With

            'incassi
            AddHandler Importa.StatoImportazione, AddressOf CambiaStatoBDA
            Importa.AggiornaBDA(OpzioniDBA)

            Notifica.Messaggio = "Interrogazione BDA completata"
            'Notifica.Chiudi()
            ChiudiNotifica()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Utx.GestioneFlag.CancellaFlag(Utx.GestioneFlag.TipoFlag.AGGIORNAMENTO_BDA)
        End Try
    End Sub

    Private Sub CambiaStatoBDA(e As ExportLib.ExportEventArgs)

        If e.Errore = True Then

            Notifica.ColoreSfondo = Drawing.Color.Orange
            Notifica.Refresh()

            If e.Messaggio.Trim.Length = 0 Then
                e.Messaggio = "Errore non previsto"
            End If

            Notifica.Messaggio = e.Messaggio

            Notifica.TopMost = True

        ElseIf e.Messaggio.Trim.Length > 0 Then

            'se non c'è errore il messaggio contiene la targa

            If e.Errore = False Then
                Notifica.ColoreSfondo = Drawing.Color.PaleGreen
            Else
                Notifica.ColoreSfondo = Drawing.Color.Orange
            End If

            Notifica.Messaggio = e.Messaggio
        End If
    End Sub
#End Region

#Region "Prima nota"
    Public Sub AggiornaPNotaEssig(Inizio As Date)
        Try
            Importa.AggiornaPrimaNota(Inizio, Today.AddDays(-1))

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub
#End Region

    Public Sub ChiudiNotifica()
        If Notifica IsNot Nothing Then
            Notifica.Chiudi()
        End If
    End Sub

    Private Sub Notifica_Annulla() Handles Notifica.Annulla
        Importa.Annulla = True
    End Sub

    Private Sub Importa_AnnullamentoInCorso(Messaggio As String) Handles Importa.AnnullamentoInCorso
        Notifica.Messaggio = Messaggio
    End Sub
End Class
