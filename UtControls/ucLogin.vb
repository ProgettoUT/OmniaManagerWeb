Imports System.Windows.Forms
Imports System.Drawing

Public Class ucLogin

    Public Event StatoLogin(Messaggio As String, Stato As Utx.Autenticazione.StatoLogin)
    Public Event AnnulloLogin()
    Public Event PressioneTasto(Tasto As Keys)

    Friend Credenziali As CredenzialiSalvate

    Private ReadOnly tt As New ToolTip
    Private ReadOnly ColoreSfondo As Color = Color.White
    Private wrapper As New Utx.Crypto("19011957")

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Size = New Size(350, 230)
        Me.Dock = DockStyle.Fill
        Me.Font = Utx.AppFont.Normal

        TextBoxUser.BackColor = ColoreSfondo
        TextBoxPw.BackColor = ColoreSfondo

        With LabelIcona
            .Text = ""
            .Image = Risorse.Immagini.Bitmap("user")
            .ImageAlign = ContentAlignment.MiddleCenter
        End With
        With LabelInfo
            .ForeColor = Color.DarkSlateGray
            .Text = "Inserire il nome utente e la password di Windows per il dominio 'uniage'"
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        CheckBoxPW.Image = Risorse.Immagini.Image("occhio")
        CheckBoxMFA.Enabled = False
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        tt.IsBalloon = True
        tt.SetToolTip(CheckBoxPW, "Visualizza password")

        Credenziali = New CredenzialiSalvate
        CaricaCredenziali()

        Me.Refresh()

        If TextBoxUser.Text.Trim.Length = 0 Then
            TextBoxUser.Focus()
        Else
            If TextBoxPw.Text.Length = 0 Then
                TextBoxPw.Focus()
            Else
                ButtonOk.Focus()
            End If
        End If
    End Sub

    Private Sub ButtonOk_Click(sender As System.Object, e As System.EventArgs) Handles ButtonOk.Click
        Try
            TextBoxUser.Text = TextBoxUser.Text.Trim
            TextBoxPw.Text = TextBoxPw.Text.Trim
            If Utx.Utente.IsUniageUser(TextBoxUser.Text) = False Then
                MsgBox("Formato nome utente errato. Utilizzare un account UnipolSai.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                TextBoxUser.Focus()
                Exit Sub
            End If
            If String.IsNullOrEmpty(TextBoxPw.Text) Then
                MsgBox("Il campo Password è obbligatorio.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                TextBoxPw.Focus()
                Exit Sub
            End If

            Utx.Globale.UtenteCorrente.UniageUser = TextBoxUser.Text
            Utx.Globale.UtenteCorrente.UniagePw = TextBoxPw.Text

#If Not DEBUG Then
            If Utx.FormUtenti.UtenteAbilitato(TextBoxUser.Text.Trim) = False Then
                RaiseEvent StatoLogin("Utente non autorizzato", Utx.Autenticazione.StatoLogin.FALLITO)
                'annullo la user e pw e riprovo
                TextBoxUser.Text = ""
                TextBoxPw.Text = ""
                TextBoxUser.Focus()
                Exit Sub
            End If
#End If

            Credenziali.User = TextBoxUser.Text
            Credenziali.Password = TextBoxPw.Text
            Credenziali.ScadenzaPw = dtpScadenzaPw.Value
            Credenziali.Nascoste = Not CheckBoxSalvaPw.Checked

            RaiseEvent StatoLogin("Login in corso: attendere...", Utx.Autenticazione.StatoLogin.ATTESA)

            Utx.Globale.LoginUniage.LogIn(Credenziali.User, Credenziali.Password, Utx.Globale.UtenteCorrente.Dominio)

            'analisi dello stato
            If Utx.Globale.LoginUniage.IsLogged Then
                'loggato!
                'salvo password nel setting globale se richiesto
                Utx.Globale.UtenteCorrente.UniageUser = TextBoxUser.Text
                Utx.Globale.UtenteCorrente.UniagePw = TextBoxPw.Text
                Utx.Globale.UtenteCorrente.Autenticato = True
                Credenziali.Salva()
                RaiseEvent StatoLogin("Login riuscito", Utx.Autenticazione.StatoLogin.LOGIN)
            Else
                Select Case Utx.Globale.LoginUniage.Stato
                    Case Utx.Autenticazione.StatoLogin.FALLITO, Utx.Autenticazione.StatoLogin.LOGOUT
                        'login fallito
                        RaiseEvent StatoLogin("Login fallito", Utx.Autenticazione.StatoLogin.FALLITO)
                    Case Utx.Autenticazione.StatoLogin.RETE_NON_DISPONIBILE
                        If Credenziali.LoginLocale = True Then
                            Credenziali.Salva() 'salvo altrimenti continua a chiederle
                            RaiseEvent StatoLogin("Rete non disponibile", Utx.Autenticazione.StatoLogin.RETE_NON_DISPONIBILE)
                        Else
                            'login fallito
                            RaiseEvent StatoLogin("Login impossibile", Utx.Autenticazione.StatoLogin.RETE_NON_DISPONIBILE)
                        End If
                End Select
                'annullo la pw e riprovo
                TextBoxPw.Text = ""
                TextBoxPw.Focus()
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub txtUser_GotFocus(sender As Object, e As System.EventArgs) Handles TextBoxUser.GotFocus
        TextBoxUser.BackColor = Color.Yellow
    End Sub

    Private Sub txtUser_LostFocus(sender As Object, e As System.EventArgs) Handles TextBoxUser.LostFocus
        TextBoxUser.BackColor = ColoreSfondo
    End Sub

    Private Sub txtPw_GotFocus(sender As Object, e As System.EventArgs) Handles TextBoxPw.GotFocus
        TextBoxPw.BackColor = Color.Yellow
    End Sub

    Private Sub txtPw_LostFocus(sender As Object, e As System.EventArgs) Handles TextBoxPw.LostFocus
        TextBoxPw.BackColor = ColoreSfondo
    End Sub

    Private Sub ButtonAnnulla_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAnnulla.Click
        RaiseEvent AnnulloLogin()
    End Sub

    Private Sub CheckBoxPW_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxPW.CheckedChanged
        If CheckBoxPW.Checked = True Then
            TextBoxPw.PasswordChar = ""
            tt.SetToolTip(CheckBoxPW, "Nascondi password")
        Else
            TextBoxPw.PasswordChar = "*"
            tt.SetToolTip(CheckBoxPW, "Visualizza password")
        End If
    End Sub

#Region "gestione credenziali"
    Private Sub CaricaCredenziali()
        Try
            With dtpScadenzaPw
                .MinDate = Today
                .MaxDate = Today.AddDays(90)
            End With

            TextBoxUser.Text = Credenziali.User

            If Credenziali.Nascoste = False Then
                CheckBoxSalvaPw.Checked = True
                TextBoxPw.Text = Credenziali.Password
            Else
                CheckBoxSalvaPw.Checked = False
            End If

            dtpScadenzaPw.Value = Credenziali.ScadenzaPw

        Catch ex As Exception
            'rimuovo la chiave difettosa e ricarico
            Utx.Globale.SettingGlobale.Rimuovi(Environment.UserName)
            ResetUtente()
        End Try
    End Sub

    Private Sub ResetUtente()
        TextBoxUser.Text = ""
        TextBoxPw.Text = ""
        dtpScadenzaPw.Value = Today
        TextBoxUser.Focus()
    End Sub

    Private Sub TextBoxUser_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxUser.KeyDown, TextBoxPw.KeyDown, dtpScadenzaPw.KeyDown
        RaiseEvent PressioneTasto(e.KeyCode)
    End Sub

    Private Sub ButtonCambiaPassword_Click(sender As Object, e As EventArgs) Handles ButtonCambiaPassword.Click
        MsgBox(String.Format("» Verrete ora indirizzati al sito Unipol per cambiare la password.{0}{0}" +
                             "» Potete cambiare la password UnipolSai o Unisalute utilizzando la relativa utenza.{0}{0}" +
                             "» Selezionate il flag 'cambia password' e il dominio 'uniage'.{0}{0}" +
                             "» Per il corretto funzionamento di questa App impostate la password Unisalute uguale a quella UnipolSai.", Environment.NewLine),
               MsgBoxStyle.Information, "Cambia password")
        Process.Start("https://changepwd.unipol.it/")
    End Sub
#End Region
End Class

Public Class CredenzialiSalvate

    Private wrapper As New Utx.Crypto()

    Sub New()
        LeggiCredenziali()
    End Sub

    Private mUser, mUserSalvato As String
    Public Property User() As String
        Get
            Return mUser
        End Get
        Set(value As String)
            mUser = value.Trim.ToLower
        End Set
    End Property

    Private mPassword, mPasswordSalvata As String
    Public Property Password() As String
        Get
            Return mPassword
        End Get
        Set(value As String)
            mPassword = value.Trim
        End Set
    End Property

    Private mScadenza As Date
    Public Property ScadenzaPw() As Date
        Get
            Return mScadenza
        End Get
        Set(value As Date)
            mScadenza = value
        End Set
    End Property

    Private mNascoste As Boolean 'dipende dal checkbox salva pw
    Public Property Nascoste() As Boolean
        Get
            Return mNascoste
        End Get
        Set(value As Boolean)
            mNascoste = value
        End Set
    End Property

    Public Function LoginLocale() As Boolean
        Return (mUser = mUserSalvato) And (mPassword = mPasswordSalvata)
    End Function

    Public Sub LeggiCredenziali()
        Try
            'cerco la chiave dell'utente loggato sul pc
            Dim UtentePc As String = Environment.UserName
            Dim Chiave As String = Utx.Globale.SettingGlobale.LeggiValore(wrapper.EncryptData(UtentePc))

            If String.IsNullOrEmpty(Chiave) Then
                mUser = ""
                mPassword = ""
                mUserSalvato = ""
                mPasswordSalvata = ""
                mScadenza = Today
                mNascoste = True
            Else
                'se la chiave esiste la decripto
                Dim UtenteRegistrato As String = wrapper.DecryptData(Chiave)
                'l'utente registrato è nella forma utenteuniage:passworduniage:scadenza:nascoste

                mUser = UtenteRegistrato.Split(":")(0)
                mPassword = UtenteRegistrato.Split(":")(1)
                mScadenza = UtenteRegistrato.Split(":")(2)
                mNascoste = CBool(UtenteRegistrato.Split(":")(3))
                mUserSalvato = mUser
                mPasswordSalvata = mPassword

                Utx.Globale.UtenteCorrente.UniageUser = mUser
                Utx.Globale.UtenteCorrente.UniagePw = mPassword

                'se credenziali scadute
                If mScadenza < Today Then
                    mPassword = ""
                    mScadenza = Today
                End If
            End If

        Catch ex As Exception
            mUser = ""
            mPassword = ""
            mUserSalvato = ""
            mPasswordSalvata = ""
            mScadenza = Today
            mNascoste = True
            'rimuovo la chiave difettosa e ricarico
            Utx.Globale.SettingGlobale.Rimuovi(Environment.UserName)
        End Try
    End Sub

    Public Sub Salva()
        Try
            'registro l'utente nella forma utentepc:utenteuniage:passworduniage:scadenza:nascosto:mfa
            Dim UtenteRegistrato As String = $"{mUser}:{mPassword}:{mScadenza:d}:{mNascoste}:True"

            'salvo l'utente criptato nel setting globale legato allo username loggato sul pc
            Utx.Globale.SettingGlobale.AggiungiModifica(wrapper.EncryptData(Environment.UserName), wrapper.EncryptData(UtenteRegistrato))
            'prossima richiesta login dalle 7 del giorno dopo
            Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.LOGIN_RICHIESTO, Format(Today.AddDays(1), "dd/MM/yyyy 07:00:00"), True)
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub Cancella()
        Try
            Utx.Globale.SettingGlobale.Rimuovi(wrapper.EncryptData(Environment.UserName))
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub
End Class
