Imports System.IO

Public Class FormManutenzione

    Public TitoloFinestra As String = "Strumenti per la manutenzione"
    Private WithEvents Timer1 As New Timer

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.Size = New Size(700, 350)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Font = Utx.AppFont.Normal
        Me.Icon = Risorse.Immagini.Icon("strumenti")
        Me.Text = TitoloFinestra

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        If File.Exists(FileControlloUpdate) Then
            ButtonUpdate.Text = DeskBloccoUpdate()
            ButtonUpdate.BackColor = Color.Coral
        Else
            ButtonUpdate.Text = "Blocca aggiornamenti"
            ButtonUpdate.BackColor = Color.PaleGreen
        End If
        If Utx.BloccoAutomatismi.Attivo Then
            ButtonBloccoAutomatismi.BackColor = Color.OrangeRed
            ButtonBloccoAutomatismi.Text = "Sblocca automatismi"
        Else
            ButtonBloccoAutomatismi.BackColor = Color.PaleGreen
            ButtonBloccoAutomatismi.Text = "Blocca automatismi"
        End If
        ButtonBackup.Text = "Esegui backup"
        With ButtonAvviaOmnia
            .Text = String.Format("Flusso giornaliero{0}Cerca nuovi dati{0}({1})",
                                  Environment.NewLine, CDate(Utx.Globale.SettingInterop.LeggiValore(Utx.GestioneFlag.TipoFlag.AUTO_IMPORT_OMNIA, Now.AddDays(-1))).AddHours(-3))
            .BackColor = Color.Lavender
        End With
        With ButtonImportaOmnia
            .Text = String.Format("Flusso giornaliero{0}Consolida dati", Environment.NewLine)
            .BackColor = Color.LightYellow
        End With
        With ButtonAvviaDL
            .Text = String.Format("Download agenzie{0}Cerca nuovi dati", Environment.NewLine)
            .BackColor = Color.Lavender
        End With
        With ButtonImportaDL
            .Text = String.Format("Download agenzie{0}Consolida dati", Environment.NewLine)
            .BackColor = Color.LightYellow
        End With
        With ButtonRipristina
            .Padding = Utx.AppFont.ButtonPadding
            .Image = Risorse.Immagini.Bitmap("ripristina")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Ripristina da backup"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        ButtonChiavi.Text = "Visualizza setting"
        ButtonCompatta.Text = "Compatta i database"
        ButtonChiaviDb.Text = "Rigenera chiavi DB"
        ButtonDistinct.Text = "Distinct DB Supporto"
        With ButtonLiveUpdate
            .Padding = Utx.AppFont.ButtonPadding
            .Image = Risorse.Immagini.Bitmap("update_red")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Controlla aggiornamenti"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        ButtonFileSIA.Text = "File disponibili in contabilità"
        ButtonAnalisiDb.Text = "Analisi struttura database"
        ButtonAnalisiFlusso.Text = "Analisi flusso dati"
        ButtonAnalisiMA.Text = "Analisi file MA"
        ButtonChiaviManutenzione.Text = "Chiavi manutenzione"
        ButtonAbilitazioni.Text = "Aggiorna abilitazioni"
        ButtonEssigReti.Text = "Gestione rete"
        With ButtonAR
            .BackColor = Color.DodgerBlue
            .ForeColor = Color.White
            .Text = "Assistenza remota"
        End With
        With LabelStato
            .Margin = New Padding(0)
            .BorderStyle = BorderStyle.None
            .BackColor = Color.Moccasin
            .Text = "..."
            .TextAlign = ContentAlignment.MiddleLeft
        End With
    End Sub

    Private Function FileControlloUpdate()
        Return String.Format("{0}\Versioni\Controllo.OFF", Utx.Globale.Paths.CartellaUpdateLocale)
    End Function

    Private Sub ButtonUpdate_Click(sender As Object, e As EventArgs) Handles ButtonUpdate.Click
        If File.Exists(FileControlloUpdate) Then
            File.Delete(FileControlloUpdate)
            ButtonUpdate.BackColor = Color.PaleGreen
            ButtonUpdate.Text = "Blocca aggiornamenti"
        Else
            Dim Fine As String = InputBox("Blocco fino al (compreso):", "Blocco aggiornamenti", Format(Today, "dd/MM/yyyy"))
            If IsDate(Fine) Then
                File.WriteAllText(FileControlloUpdate, String.Format("Blocco aggiornamenti del {0} e fino al {1}", Now, Format(CDate(Fine), "dd/MM/yyyy")))
                ButtonUpdate.BackColor = Color.Coral
                ButtonUpdate.Text = DeskBloccoUpdate()
            End If
        End If
    End Sub

    Private Function DeskBloccoUpdate() As String
        If File.Exists(FileControlloUpdate) Then
            Dim Fine As String = Microsoft.VisualBasic.Right(File.ReadAllText(FileControlloUpdate), 10)
            If IsDate(Fine) Then
                Return String.Format("Blocco aggiornamenti fino al {1}.{0}Sblocca...", Environment.NewLine, Format(CDate(Fine), "dd/MM/yyyy"))
            Else
                Return "Blocco aggiornamenti"
            End If
        Else
            Return "???"
        End If
    End Function

    Private Sub ButtonImportaOmnia_Click(sender As Object, e As EventArgs) Handles ButtonImportaOmnia.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            'resetto il calendario
            Using s As New Utx.DatabaseOMW.Database
                s.Proxy = Utx.Globale.UniProxy.Proxy
                s.ResetCalendarioOmnia(Utx.Globale.AgenziaRichiesta.CodiceAgenzia, #01/01/2000#, Utx.Globale.Token)
            End Using
            'forzo il consolidamento
            Using s As New Utx.EventiOMW.GeneraEventi
                s.Proxy = Utx.Globale.UniProxy.Proxy
                s.GeneraEvento(Utx.Globale.AgenziaRichiesta.CodiceAgenzia, "FORZATURA_CONSOLIDA_DB", "", Utx.Globale.Token)
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
            Me.Close()
        End Try
    End Sub

    Private Sub ButtonImportaDL_Click(sender As Object, e As EventArgs) Handles ButtonImportaDL.Click
        MsgBox("Funzione al momento non implementata perché inutile", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
        Me.Close()
    End Sub

    Private Sub ButtonAvviaOmnia_Click(sender As Object, e As EventArgs) Handles ButtonAvviaOmnia.Click
        Dim Chiave As Utx.SettingItem
        Try
            'controllo se è già in corso un aggiornamento
            Chiave = New Utx.SettingItem(Utx.SettingItem.Sezioni.INTEROP, Utx.SettingItem.Chiavi.IMPORTAZIONE_MA,
                                         Utx.SettingOMW.TipoOperazione.LETTURA)

            If Chiave.ItemResult.Esiste = False Then
                'resetto la data per la prossima importazione
                Chiave.SetItem(Utx.SettingItem.Sezioni.AUTOMATISMI, Utx.SettingItem.Chiavi.IMPORTAZIONE_MA, "01/01/1900",
                               Utx.SettingOMW.TipoOperazione.SCRITTURA)

                ButtonAvviaOmnia.Enabled = False
                ButtonAvviaOmnia.Text = "Controllo avviato..."
                UtTimer.ForzaTimer()
                Me.Close()
            Else
                MsgBox("E' già in corso una importazione. Provare fra qualche minuto.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonAvviaDL_Click(sender As Object, e As EventArgs) Handles ButtonAvviaDL.Click
        Dim Chiave As Utx.SettingItem
        Try
            'controllo se è già in corso un aggiornamento
            Chiave = New Utx.SettingItem(Utx.SettingItem.Sezioni.INTEROP, Utx.SettingItem.Chiavi.IMPORTAZIONE_DL,
                                         Utx.SettingOMW.TipoOperazione.LETTURA)

            If Chiave.ItemResult.Esiste = False Then
                'resetto la data per la prossima importazione
                Chiave.SetItem(Utx.SettingItem.Sezioni.AUTOMATISMI, Utx.SettingItem.Chiavi.IMPORTAZIONE_DL, "01/01/1900",
                               Utx.SettingOMW.TipoOperazione.SCRITTURA)

                ButtonAvviaOmnia.Enabled = False
                ButtonAvviaOmnia.Text = "Controllo avviato..."
                UtTimer.ForzaTimer()
                Me.Close()
            Else
                MsgBox("E' già in corso una importazione. Provare fra qualche minuto.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonRipristina_Click(sender As Object, e As EventArgs) Handles ButtonRipristina.Click
        ButtonRipristina.Enabled = False
        'passare il codice dell'agenzia da ripristinare, 00000 per tutti
        Utx.Servizi.AvviaBackupArchivi(Utx.Globale.AgenziaRichiesta.CodiceAgenzia, Modo:="R")
        ButtonRipristina.Enabled = True
    End Sub

    Private Sub ButtonChiavi_Click(sender As Object, e As EventArgs) Handles ButtonChiavi.Click
        Using f As New FormChiaviSetting
            f.ShowDialog()
        End Using
    End Sub

    Private Sub ButtonCompatta_Click(sender As Object, e As EventArgs) Handles ButtonCompatta.Click
        Try
            Using Notifica As New Utx.FormNotifica
                With Notifica
                    .Opacity = 0.9
                    .Stile = Utx.FormNotifica.Style.ANTRACITE
                    .Altezza = Utx.FormNotifica.AltezzaNotifica.MEZZA
                    .Show()

                    'compatta
                    Utx.FunzioniDb.CompattaCartelleDati(Notifica.LabelMessaggio)

                    .Messaggio = "Compattazione completata"
                    .Chiudi()
                End With
            End Using

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonChiaviDb_Click(sender As Object, e As EventArgs) Handles ButtonChiaviDb.Click
        Try
            Using Notifica As New Utx.FormNotifica
                With Notifica
                    .ColoreSfondo = Drawing.Color.Gainsboro
                    .Text = ""
                    .Show()
                    .Messaggio = "Creazione chiavi db..."
                    Utx.FunzioniDb.CreaChiaviDb(Notifica.LabelMessaggio)
                    .Messaggio = "Creazione chiavi dbuno..."
                    For Each Agenzia As String In Utx.EnteGestore.CodiciGestiti
                        Utx.FunzioniDb.CreaVincoliDbUno(Agenzia)
                    Next
                    .Chiudi()
                End With
            End Using

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonDistinct_Click(sender As Object, e As EventArgs) Handles ButtonDistinct.Click
        Try
            Using Notifica As New Utx.FormNotifica
                With Notifica
                    .ColoreSfondo = Drawing.Color.Gainsboro
                    .Text = ""
                    .Show()
                    .Messaggio = "Distinct in corso..."

                    Utx.Manutenzione.DistinctSupporto()

                    .Messaggio = "Operazione completata"
                    .Chiudi()
                End With
            End Using

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonLiveUpdate_Click(sender As Object, e As EventArgs) Handles ButtonLiveUpdate.Click
        Try
            Dim th As New Threading.Thread(Sub()
                                               Utx.Globale.Log.Info("richiamo live update - idapp UTW user {0}", {Utx.Globale.UtenteCorrente.UniageUser})
                                               LiveUpdate.Main.ControlloAggiornamenti("UTW", Utx.Globale.UtenteCorrente.UniageUser, Forzatura:=True)
                                           End Sub)
            th.Start()
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonAnalisiDb_Click(sender As Object, e As EventArgs) Handles ButtonAnalisiDb.Click
        Dim f As New FormAnalisiDb
        f.Show()
    End Sub

    Private Sub ButtonAnalisiFlusso_Click(sender As Object, e As EventArgs) Handles ButtonAnalisiFlusso.Click
        Try
            Dim f As New FormAnalisiFlussoDati
            f.Show()
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub FormManutenzione_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Timer1.Dispose()
    End Sub

    Private Sub FormManutenzione_Load(sender As Object, e As EventArgs) Handles Me.Load
        Timer1.Interval = 1000
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Now > Utx.Globale.SessioneCorrente.ProssimoControlloTimerUnitools Then
            LabelStato.Text = "Controlli automatici in corso..."
        Else
            LabelStato.Text = String.Format("Controlli automatici fra {0} sec - Cicli {1}",
                                            DateDiff(DateInterval.Second, Now, Utx.Globale.SessioneCorrente.ProssimoControlloTimerUnitools),
                                            Utx.Globale.SessioneCorrente.CicliTimer)
        End If
    End Sub

    Private Sub ButtonForzaTimer_Click(sender As Object, e As EventArgs) Handles ButtonForzaTimer.Click
        UtTimer.ForzaTimer()
    End Sub

    Private Sub LabelStato_Paint(sender As Object, e As PaintEventArgs) Handles LabelStato.Paint
        ControlPaint.DrawBorder(e.Graphics, LabelStato.DisplayRectangle, Color.Gainsboro, ButtonBorderStyle.Solid)
    End Sub

    Private Sub ButtonAnalisiMA_Click(sender As Object, e As EventArgs) Handles ButtonAnalisiMA.Click
        Dim f As New UniFeed.CercaInFiles
        f.Show()
    End Sub

    Private Sub ButtonBackup_Click(sender As Object, e As EventArgs) Handles ButtonBackup.Click
        Utx.Servizi.AvviaBackupArchivi(Utx.EnteGestore.StringaCodiciGestiti, VisualizzaNotifica:=True, Modo:="B")
    End Sub

    Private Sub ButtonChiaviManutenzione_Click(sender As Object, e As EventArgs) Handles ButtonChiaviManutenzione.Click
        Dim f As New Utx.FormChiaviManetunzione
        f.Show()
    End Sub

    Private Sub ButtonAbilitazioni_Click(sender As Object, e As EventArgs) Handles ButtonAbilitazioni.Click
        Utx.Globale.ProfiloEnteGestore.Abilitazioni.LeggiAbilitazioni()
        MsgBox("Abilitazioni agenzia aggiornate", MsgBoxStyle.Information)
    End Sub

    Private Sub ButtonEssigReti_Click(sender As Object, e As EventArgs) Handles ButtonEssigReti.Click
        Dim f As New FormGestioneRete
        f.Show()
    End Sub

    Private Sub ButtonBloccoAutomatismi_Click(sender As Object, e As EventArgs) Handles ButtonBloccoAutomatismi.Click
        Try
            If Utx.BloccoAutomatismi.Attivo Then
                Utx.BloccoAutomatismi.Rimuovi()
                ButtonBloccoAutomatismi.BackColor = Color.PaleGreen
                ButtonBloccoAutomatismi.Text = "Blocca automatismi"
            Else
                Dim FinoAl As String = InputBox("Bloccare fino al", "Blocco automatismi", Today.ToShortDateString)
                If IsDate(FinoAl) Then
                    Utx.BloccoAutomatismi.Salva(FinoAl)
                    ButtonBloccoAutomatismi.BackColor = Color.OrangeRed
                    ButtonBloccoAutomatismi.Text = "Sblocca automatismi"
                Else
                    MsgBox("Data non valida", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                End If
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonAR_Click(sender As Object, e As EventArgs) Handles ButtonAR.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim ARemota As String = Path.Combine(Utx.Globale.Paths.CartellaModelli, "auasupport-qs.exe")
            If File.Exists(ARemota) Then
                Process.Start(ARemota)
            Else
                Process.Start("http://www.guidolampo.it")
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ButtonFileSIA_Click(sender As Object, e As EventArgs) Handles ButtonFileSIA.Click
        Using f As New Utx.FormFileSIA
            f.ShowDialog()
        End Using
    End Sub
End Class