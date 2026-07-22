Public Class FormGestioneAccount

    Private ServizioSmsAgenzia As ServizioSms
    Private Sms As UniCom.Sms
    Private PacchettoSelezionato As ServizioSms.Pacchetto

    Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(800, 480)
        Me.MinimumSize = New Size(Me.Width, Me.Height)
        Me.Text = "Gestione account SMS"
        Me.Icon = Risorse.Immagini.Icon("account")

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        LabelCredito.BackColor = Color.Gainsboro
        LabelCredito.ForeColor = Color.Black

        LabelMessaggio.ForeColor = Color.Gray
        LabelMessaggio.Text = "Selezionare la ricarica desiderata e premere 'Effettua ricarica'. La ricarica è immediata."

        With btnRicarica
            .Padding = New Padding(10, 0, 10, 0)
            .Image = Risorse.Immagini.Bitmap("aggiorna")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Effettua ricarica"
            .TextAlign = ContentAlignment.MiddleRight
        End With

        With btnAperturaAccount
            .Padding = New Padding(10, 0, 10, 0)
            .Image = Risorse.Immagini.Bitmap("account")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Richiedi apertura account"
            .TextAlign = ContentAlignment.MiddleRight
        End With

        With btnEsci
            .Padding = New Padding(10, 0, 10, 0)
            .Image = Risorse.Immagini.Bitmap("Esci")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Esci"
            .TextAlign = ContentAlignment.MiddleRight
        End With
    End Sub

    Private Sub FormGestioneAccount_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

        btnAperturaAccount.Enabled = False
        Me.Refresh()
        Me.TopMost = True

        wbCondizioni.Navigate("http://www.utools.it/unitools/sms/CondizioniSms_uniarea.htm")

        Try
            LabelCredito.Text = "Ricezione dei dati in corso..."
            Globale.Log.Info(Utx.Globale.AgenziaRichiesta.CodiceAgenzia)

            ServizioSmsAgenzia = New ServizioSms(Utx.Globale.AgenziaRichiesta.CodiceAgenzia)

            If ServizioSmsAgenzia.Abilitazione = False Then 'agenzia non abilitata

                LabelCredito.Text = "Agenzia non abilitata al servizio sms"
                LabelCredito.BackColor = Color.Orange
                GroupBoxRicarica.Enabled = False
                btnAperturaAccount.Enabled = False

                MsgBox(String.Format("Agenzia non ancora abilitata al servizio SMS.{0}{0}" +
                                     "Per abilitare il servizio è necessario registrarsi, gratuitamente,{0}" +
                                     "sul sito Uniarea.it inviando, come richiesto dalla procedura,{0}" +
                                     "l'autorizzazione all'addebito in estratto conto.{0}{0}" +
                                     "Verrete ora reindirizzati sulla pagina di registrazione.", Environment.NewLine),
                                 MsgBoxStyle.Information, Utx.Globale.TitoloApp)

                If MsgBox("Procedere con la registrazione al servizio SMS?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then
                    Process.Start("http://servizi.uniarea.it/registrazioneutenteclassica.aspx")
                End If
            Else
                With ServizioSmsAgenzia
                    RadioButton1000.Tag = .PacchettoSms(1000)
                    RadioButton2000.Tag = .PacchettoSms(2000)
                    RadioButton3000.Tag = .PacchettoSms(3000)
                    RadioButton4000.Tag = .PacchettoSms(4000)
                    RadioButton5000.Tag = .PacchettoSms(5000)
                    RadioButton10000.Tag = .PacchettoSms(10000)
                End With

                AddHandler RadioButton2000.CheckedChanged, AddressOf RadioButton1000_CheckedChanged
                AddHandler RadioButton3000.CheckedChanged, AddressOf RadioButton1000_CheckedChanged
                AddHandler RadioButton4000.CheckedChanged, AddressOf RadioButton1000_CheckedChanged
                AddHandler RadioButton5000.CheckedChanged, AddressOf RadioButton1000_CheckedChanged
                AddHandler RadioButton10000.CheckedChanged, AddressOf RadioButton1000_CheckedChanged

                RadioButton1000.Checked = True

                Sms = New UniCom.Sms With {.Agenzia = Utx.Globale.AgenziaRichiesta.CodiceAgenzia,
                                           .UtenteUniage = Utx.Globale.UtenteCorrente.UniageUser,
                                           .PwUniage = Utx.Globale.UtenteCorrente.UniagePw}

                If Sms.UtenteSubaccount.Length = 0 Then  'account non ancora registrato
                    btnAperturaAccount.Enabled = True
                    LabelCredito.Text = "Account non ancora registrato"
                    btnRicarica.Enabled = False
                Else 'l'account già esiste
                    btnAperturaAccount.Enabled = False
                    btnRicarica.Enabled = True

                    Dim Credito As Integer = Sms.CreditoSubaccount()

                    If Sms.Esito.EsitoChiamata = True Then
                        LabelCredito.BackColor = Color.LightSeaGreen
                        LabelCredito.ForeColor = Color.Gainsboro
                        AggiornaLabelCredito(Credito)
                    Else
                        LabelCredito.BackColor = Color.Orange
                        LabelCredito.ForeColor = Color.Black
                        If String.IsNullOrEmpty(Sms.Esito.MessaggioErrore) Then
                            AggiornaLabelCredito(Credito)
                        Else
                            LabelCredito.Text = Sms.Esito.MessaggioErrore
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub AggiornaLabelCredito(Credito As Integer)
        LabelCredito.Text = String.Format("Account: {0} - Credito residuo: {1:N0} SMS", Sms.UtenteSubaccount.ToUpper, Credito)
    End Sub

    Private Sub btnEsci_Click(sender As System.Object, e As System.EventArgs) Handles btnEsci.Click
        Me.Close()
    End Sub

    Private Sub RadioButton1000_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1000.CheckedChanged

        If sender.checked Then
            PacchettoSelezionato = sender.tag

            sender.Backcolor = Color.PaleGreen

            txtCostoUnitario.Text = String.Format("{0:N1} centesimi",
                                                  PacchettoSelezionato.Costo / PacchettoSelezionato.NumeroSms * 100)
            txtCostoRicarica.Text = String.Format("Euro {0:N2} + IVA 22%", PacchettoSelezionato.Costo)
        Else
            sender.Backcolor = Drawing.SystemColors.Control
        End If
    End Sub

    Private Sub LabelCredito_TextChanged(sender As Object, e As System.EventArgs) Handles LabelCredito.TextChanged
        LabelCredito.Refresh()
    End Sub

    Private Sub btnRicarica_Click(sender As System.Object, e As System.EventArgs) Handles btnRicarica.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Me.Enabled = False

            If MsgBox(String.Format("Procedere con la ricarica di {0} SMS?", PacchettoSelezionato.NumeroSms),
                      MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question,
                      Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then

                Dim Credito As Integer = Sms.RicaricaSubaccount(PacchettoSelezionato.NumeroSms,
                                                                PacchettoSelezionato.Costo)

                If Sms.Esito.EsitoChiamata = True Then
                    AggiornaLabelCredito(Credito)
                    MsgBox("Ricarica effettuala correttamente.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Else
                    Globale.Log.Info(Sms.Esito.MessaggioErrore)
                    MsgBox(Sms.Esito.MessaggioErrore, MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                End If
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Cursor.Current = Cursors.Default
            Me.Enabled = True
        End Try
    End Sub

    Private Sub btnAperturaAccount_Click(sender As System.Object, e As System.EventArgs) Handles btnAperturaAccount.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Me.Enabled = False

            If MsgBox(String.Format("Confermate la richiesta di apertura di un account SMS?{0}(L'apertura dell'account è gratuita.)",
                                     Environment.NewLine),
                                 MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2,
                                 Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then

                Sms.Compagnia = Utx.Globale.ProfiloEnteGestore.Compagnia
                Sms.Agenzia = Utx.Globale.ProfiloEnteGestore.AgenziaMadre
                Sms.Sede = Utx.Globale.ProfiloEnteGestore.CodiceSede
                Sms.CodiceUtente = Utx.NetFunc.StringToMD5(Utx.Globale.ProfiloEnteGestore.AgenziaMadre).Substring(0, 10)

                Sms.CreaSubAccount()

                If Sms.Esito.EsitoChiamata = True Then
                    Sms.CreditoSubaccount()
                    AggiornaLabelCredito(Sms.CreditoSubaccount())
                    MsgBox("Apertura account effettuala correttamente.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Else
                    Globale.Log.Info(Sms.Esito.MessaggioErrore)
                    MsgBox(Sms.Esito.MessaggioErrore, MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                End If
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub
End Class