Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO

Public Class FormConfigura

    Private wrapper As New Utx.Crypto("19011957")

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Size = New Size(600, 400)
        Me.Padding = New Padding(5)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Font = Utx.AppFont.Normal
        Me.Icon = Risorse.Immagini.Icon("config")
        Me.Text = "Configura"
        ImpostaControlli()
        CaricaImpostazioni()

        AddHandler RadioButtonM.CheckedChanged, AddressOf RadioButtonM_CheckedChanged
    End Sub

    Private Sub ImpostaControlli()
        With TabMain
            .ItemSize = New Size(130, 25)
            .ColorStyle = UtTabControl.TabColorStyle.ROSA
        End With
        With ButtonSalva
            .Padding = New Padding(10, 0, 10, 0)
            .BackColor = SystemColors.Control
            .Image = Risorse.Immagini.Bitmap("salva")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Salva"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With ButtonAnnulla
            .Padding = New Padding(10, 0, 10, 0)
            .BackColor = SystemColors.Control
            .Image = Risorse.Immagini.Bitmap("cancel")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Annulla"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        'scheda archivi
        LabelIP.Text = "Nome o IP del server che ospita i dati"
        LabelSincro.Text = "Ricordami di sincronizzare i dati quando mi disconnetto dalla rete"
        With TextBoxIP
            '.BackColor = Color.Gold
            .TextAlign = HorizontalAlignment.Center
        End With
        If Utx.FunzioniRete.PcInDominio = True Then
            CheckBoxSincro.Checked = False
            CheckBoxSincro.Enabled = False
        End If
        With LabelInfoEmme
            .Font = Utx.AppFont.Bold
            .Text = "Per pc NON in dominio 'uniage' avviare l'applicazione"
        End With
        RadioButtonU.Text = "utilizzando un disco locale U:"
        RadioButtonM.Text = "utilizzando il disco di rete M:"
        'scheda interfaccia
        With ComboBoxRitardo
            .DropDownStyle = ComboBoxStyle.DropDownList
            .DisplayMember = "Descrizione"

            .Items.Add(New RitardoRicerca(0))

            For k As Integer = 700 To 3000 Step 100
                .Items.Add(New RitardoRicerca(k))
                If k = Utx.Globale.RitardoTimer Then
                    .SelectedIndex = .Items.Count - 1
                End If
            Next

            If .SelectedIndex < 0 Then
                .SelectedIndex = 0
            End If
        End With
        'in dominio nascondo la scheda archivi
        If Utx.FunzioniRete.PcInDominio = True Then
            TabMain.TabPages.Remove(TabPageArchivi)
        End If
    End Sub

    Private Sub FormConfigura_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        TextBoxMail.Focus()
    End Sub

    Private Sub ButtonAggiungi_Click(sender As Object, e As EventArgs) Handles ButtonAggiungi.Click
        'se la mail è valida
        If Utx.NetFunc.ValidEmail(TextBoxMail.Text, False, True) = True Then
            'controllo se già è nella lista
            For Each email As String In ListBoxMail.Items
                If email = TextBoxMail.Text Then Exit Sub
            Next
            'la aggiungo alla lista
            ListBoxMail.Items.Add(TextBoxMail.Text.Trim)
            TextBoxMail.Text = ""
            TextBoxMail.Focus()
        Else
            TextBoxMail.Focus()
        End If
    End Sub

    Private Sub ButtonPredefinita_Click(sender As Object, e As EventArgs) Handles ButtonPredefinita.Click
        If ListBoxMail.SelectedIndex > 0 Then
            Dim Mail As String = ListBoxMail.Text
            ListBoxMail.Items.Remove(ListBoxMail.SelectedItem)
            ListBoxMail.Items.Insert(0, Mail)
        End If
    End Sub

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonAnnulla.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub SalvaImpostazioni()
        Try
            'metto le mail in una stringa separata da ;
            Dim Mails As String = ""
            For Each email In ListBoxMail.Items
                Mails += ";" + email
            Next
            'tolgo il primo ;
            If Mails.Length >= 1 Then Mails = Mails.Substring(1)
            'salvo
            Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.EMAIL_PREDEFINITE, Mails)
            Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.SMTP, wrapper.EncryptData(String.Format("{0};{1};{2};{3};{4}",
                                                       TextBoxSmtp.Text, TextBoxSmtpPorta.Text, TextBoxSmtpUtente.Text, TextBoxSmtpPw.Text, CheckBoxSSL.Checked.ToString)))
            Utx.Globale.SettingGlobale.AggiungiModifica(Utx.GestioneFlag.TipoFlag.IP_SERVER, TextBoxIP.Text)
            Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.SINCRO_DATI, CStr(CheckBoxSincro.Checked))
            Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.RITARDO_TIMER_RICERCA, ComboBoxRitardo.SelectedItem.Ritardo.ToString, True)
            Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.FORZA_SMTP_AUA, CheckBoxSmtpAUA.Checked.ToString, True)
            'imposto il ritardo
            Utx.Globale.RitardoTimer = ComboBoxRitardo.SelectedItem.Ritardo
            'disco dati per PP
            If RadioButtonM.Checked Then
                File.WriteAllText(Utx.ApplicationPath.FlagEmme, Now)
            Else
                File.Delete(Utx.ApplicationPath.FlagEmme)
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub CaricaImpostazioni()
        Try
            ListBoxMail.Items.Clear()
            Dim Mails As String = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.EMAIL_PREDEFINITE, "")
            For Each email In Mails.Split(";")
                If String.IsNullOrEmpty(email) = False Then
                    ListBoxMail.Items.Add(email)
                End If
            Next
            TextBoxSmtp.Text = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.SMTP, "")
            TextBoxIP.Text = Utx.Globale.SettingGlobale.LeggiValore(Utx.GestioneFlag.TipoFlag.IP_SERVER, "")
            CheckBoxSincro.Checked = CBool(Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.SINCRO_DATI, "False"))
            CheckBoxSmtpAUA.Checked = CBool(Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.FORZA_SMTP_AUA, "False"))

            If File.Exists(Utx.ApplicationPath.FlagEmme) Then
                RadioButtonM.Checked = True
            Else
                RadioButtonU.Checked = True
            End If

            Try
                Dim Smtp As String = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.SMTP, "")
                Smtp = wrapper.DecryptData(Smtp)
                TextBoxSmtp.Text = Smtp.Split(";")(0)
                TextBoxSmtpPorta.Text = Smtp.Split(";")(1)
                TextBoxSmtpUtente.Text = Smtp.Split(";")(2)
                TextBoxSmtpPw.Text = Smtp.Split(";")(3)
                'SSL
                If Smtp.Split(";").Length = 5 Then
                    CheckBoxSSL.Checked = Smtp.Split(";")(4)
                Else
                    CheckBoxSSL.Checked = True
                End If
            Catch ex As Exception
                'passando dal vecchio al nuovo sistema va in errore
            End Try

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonSalva_Click(sender As Object, e As EventArgs) Handles ButtonSalva.Click
        SalvaImpostazioni()
        DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ListBoxMail.SelectedIndex >= 0 Then
            ListBoxMail.Items.RemoveAt(ListBoxMail.SelectedIndex)
        End If
    End Sub

    Private Class RitardoRicerca
        Public Property Ritardo As Single

        Sub New(Valore As Single)
            _Ritardo = Valore

            If Valore = 0 Then
                _Descrizione = "Ricerca manuale con il tasto INVIO"
            Else
                _Descrizione = Format(Valore / 1000, "0.00 sec")
            End If
        End Sub

        Private _Descrizione As String
        Public ReadOnly Property Descrizione() As String
            Get
                Return _Descrizione
            End Get
        End Property
    End Class

    Private Sub TabPageUtenti_Enter(sender As Object, e As EventArgs) Handles TabPageUtenti.Enter
#If Not Debug Then
        If Utx.Globale.UtenteCorrente.IsAgente = False Then
            MsgBox("Utente non autorizzato all'utilizzo di questa funzione", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
            Exit Sub
        End If
#End If
        TabMain.SelectedTab = TabPageContatti
        Using f As New Utx.FormUtenti
            f.ShowDialog()
        End Using
    End Sub

    Private Sub RadioButtonM_CheckedChanged(sender As Object, e As EventArgs)
        MsgBox("Per rendere effettiva questa impostazione è necessario riavviare il programma.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
    End Sub
End Class