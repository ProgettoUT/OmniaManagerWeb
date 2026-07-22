Imports System.Windows.Forms
Imports System.Drawing

Friend Class FormCredenziali

    Friend Credenziali As New CredenzialiSalvate

    Private tt As New ToolTip
    Private ColoreSfondo As Color = Color.White
    Private wrapper As New Utx.Crypto("19011957")
    Private WithEvents KeyHook As Kennedy.ManagedHooks.KeyboardHook

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Size = New Size(350, 230)
        Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = Windows.Forms.FormWindowState.Normal
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Icon = Risorse.Immagini.Icon("uniarea")
        Me.Font = Utx.AppFont.Normal

        Select Case Utx.Globale.ProfiloEnteGestore.ProfiloApp
            Case Enumerazioni.ProfiloApp.COMPLETO
                Me.Text = "Omnia Manager - Login Uniage"
            Case Enumerazioni.ProfiloApp.SINISTRI
                Me.Text = "UniSinistri - Login Uniage"
        End Select

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
        With LabelStato
            .Text = ""
            .BackColor = Color.Transparent
        End With
        LabelCapsLock.BackColor = Color.Transparent
        StatoCapsLock()
        KeyHook.InstallHook()
    End Sub

    Private Sub StatoCapsLock()
        If My.Computer.Keyboard.CapsLock Then
            LabelCapsLock.ForeColor = Color.Red
            LabelCapsLock.Text = "Caps lock ON"
        Else
            LabelCapsLock.ForeColor = Color.Gray
            LabelCapsLock.Text = "Caps lock OFF"
        End If
    End Sub

    Private Sub FormCredenziali_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        KeyHook.UninstallHook()
        KeyHook.Dispose()
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.AcceptButton = ButtonOk

        tt.IsBalloon = True
        tt.SetToolTip(ButtonVediPw, "Visualizza password")

        CaricaCredenziali()
    End Sub

    Private Sub FormLogin_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.TopMost = True
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

        Me.TopMost = False
    End Sub

    Private Sub ButtonOk_Click(sender As System.Object, e As System.EventArgs) Handles ButtonOk.Click
        If String.IsNullOrEmpty(TextBoxUser.Text.Trim) Then
            MsgBox("Il campo Utente è obbligatorio", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
            TextBoxUser.Focus()
            Exit Sub
        End If
        If String.IsNullOrEmpty(TextBoxPw.Text.Trim) Then
            MsgBox("Il campo Password è obbligatorio", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
            TextBoxPw.Focus()
            Exit Sub
        End If
#If Not Debug Then
        If Utx.FormUtenti.UtenteAbilitato(TextBoxUser.Text.Trim) = False Then
            LabelStato.Text = "Non autorizzato"
            MsgBox("Utente non autorizzato all'utilizzo di Unitools", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
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

        LabelStato.Text = "Login in corso: attendere..."

        Dim LoginUniage = New Utx.AutenticazioneUeba
        LoginUniage.LogIn(Credenziali.User, Credenziali.Password, Utx.Globale.UtenteCorrente.Dominio)

        'analisi dello stato
        If LoginUniage.IsLogged Then
            'loggato!
            'salvo password nel setting globale se richiesto
            Credenziali.Salva()
            DialogResult = Windows.Forms.DialogResult.OK
        Else
            Select Case LoginUniage.Stato
                Case Autenticazione.StatoLogin.FALLITO, Autenticazione.StatoLogin.LOGOUT
                    'login fallito
                    LabelStato.Text = "Login fallito"
                    MsgBox("Login fallito: impossibile avviare Unitools.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                    'annullo la pw e riprovo
                    TextBoxPw.Text = ""
                    TextBoxPw.Focus()
                Case Autenticazione.StatoLogin.RETE_NON_DISPONIBILE
                    If Credenziali.LoginLocale = True Then
                        Credenziali.Salva() 'salvo altrimenti continua a chiederle
                        DialogResult = Windows.Forms.DialogResult.OK
                    Else
                        'login fallito
                        LabelStato.Text = "Rete non disponibile"
                        MsgBox("Login fallito: inserire le credenziali dell'ultimo accesso valido ad Unitools.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                        'annullo la pw e riprovo
                        TextBoxPw.Text = ""
                        TextBoxPw.Focus()
                    End If
            End Select
        End If
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
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub ButtonVediPw_MouseDown(sender As Object, e As MouseEventArgs) Handles ButtonVediPw.MouseDown
        ButtonVediPw.Text = "*"
        TextBoxPw.PasswordChar = ""
    End Sub

    Private Sub ButtonVediPw_MouseUp(sender As Object, e As MouseEventArgs) Handles ButtonVediPw.MouseUp
        ButtonVediPw.Text = "A"
        TextBoxPw.PasswordChar = "*"
        tt.SetToolTip(ButtonVediPw, "Visualizza password")
    End Sub

    Private Sub LabelStato_TextChanged(sender As Object, e As EventArgs) Handles LabelStato.TextChanged
        StatusStrip1.Refresh()
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
#End Region

    Private Sub KeyHook_KeyboardEvent(kEvent As Kennedy.ManagedHooks.KeyboardEvents, key As Keys) Handles KeyHook.KeyboardEvent
        If key = Keys.CapsLock Then
            StatoCapsLock()
        End If
    End Sub
End Class

Friend Class CredenzialiSalvate

    Private wrapper As New Utx.Crypto()

    Sub New()
        LeggiCredenziali()
    End Sub

    Private mUser, mUserSalvato As String
    Public Property User() As String
        Get
            Return mUser
        End Get
        Set(ByVal value As String)
            mUser = value.Trim.ToLower
        End Set
    End Property

    Private mPassword, mPasswordSalvata As String
    Public Property Password() As String
        Get
            Return mPassword
        End Get
        Set(ByVal value As String)
            mPassword = value.Trim
        End Set
    End Property

    Private mScadenza As Date
    Public Property ScadenzaPw() As Date
        Get
            Return mScadenza
        End Get
        Set(ByVal value As Date)
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

    Private Sub LeggiCredenziali()
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
        'registro l'utente nella forma utentepc:utenteuniage:passworduniage:scadenza:nascosto
        Dim UtenteRegistrato As String = String.Format("{0}:{1}:{2:d}:{3}",
                                                       mUser,
                                                       mPassword,
                                                       mScadenza,
                                                       mNascoste)

        'salvo l'utente criptato nel setting globale legato allo username loggato sul pc
        Utx.Globale.SettingGlobale.AggiungiModifica(wrapper.EncryptData(Environment.UserName), wrapper.EncryptData(UtenteRegistrato))
        'prossima richiesta login dalle 7 del giorno dopo
        Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.LOGIN_RICHIESTO, Format(Today.AddDays(1), "dd/MM/yyyy 07:00:00"), True)
    End Sub
End Class
