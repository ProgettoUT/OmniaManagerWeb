Imports System.ComponentModel
Imports System.IO
Imports System.Net

Public Class FormAssistenza

    Private Const TitoloApp As String = "Assistenza OmniaManager"
    Private Const DimX As Integer = 880
    Private Const DimY As Integer = 500
    Private ReadOnly IdApp As String
    Private ReadOnly Tip As New ToolTip
    Private ReadOnly SessioneNascosta As Boolean = False
    Private ReadOnly Log As Utx.ApplicationLog

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        If Utx.NetFunc.AltraIstanzaUtente("Assistenza", ProcessoAvviato:=True) Then
            MsgBox("L'assistenza Unitools è già aperta,", MsgBoxStyle.Information)
            Me.Close()
        End If
        SessioneNascosta = (Command() = "HIDE")

        Utx.Globale.VerificaGoogleDrive()

        Application.EnableVisualStyles()

        If New DriveInfo("M").IsReady = True Then
            Utx.Globale.Init() 'inizializzo percorsi e proxy
            'leggo id dell'app installata
            Utx.Globale.SettingGlobale = New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.GLOBALE)
            'come valore di default per ID_APP imposto ASSEGNI poiché la sola app assegni non imposta di suo un ID
            'Unitools imposta UT oppure UTW e quindi se non c'è niente è installata la sola scansione assegni
            IdApp = Utx.Globale.SettingGlobale.LeggiValore(Utx.GestioneFlag.TipoFlag.ID_APP, "ASSEGNI")

            Log = New Utx.ApplicationLog("Assistenza.log", LogCondiviso:=True)

            Me.Text = TitoloApp
            Me.Icon = My.Resources.Kermit
            Me.Size = New Size(DimX, DimY)
            Me.MinimumSize = New Size(DimX, DimY)

            ImpostaControlli()
        Else
            If SessioneNascosta Then
                'se M: non è disponibile è probabile che google drive non sia ancora partito allora aspetta 3 minuti
                Threading.Thread.Sleep(180000)
                'riprovo a connettere M:
                Utx.Globale.VerificaGoogleDrive()
                'se ancora non è disponibile esco
                If New DriveInfo("M").IsReady = False Then
                    End
                End If
            Else
                AssistenzaRemota("auasupport-qs.exe")
            End If
            End
        End If
    End Sub

    Private Sub ImpostaControlli()
        'forma del tooltip
        Tip.IsBalloon = True

        With ButtonRipristino
            .Margin = New Padding(0)
            .BackColor = Color.LightGreen
            .Font = Utx.AppFont.Bold
            .Text = "Per ripristinare/aggiornare manualmente OmniaManager clicca qui"
        End With
        Tip.SetToolTip(ButtonRipristino, "Ripristina manualmente l'applicazione")

        With btnChat
            .Margin = New Padding(0)
            .BackColor = Color.DarkOrange
            .Font = Utx.AppFont.Bold
            .Text = "Apri un ticket per richiedere assistenza"
            .Tag = False 'indica che la chat NON è in corso
        End With
        Tip.SetToolTip(btnChat, "Contatta l'assistenza")

        With ButtonARemota
            .Margin = New Padding(0)
            .BackColor = Color.LightSteelBlue
            .ForeColor = Color.Black
            .Font = Utx.AppFont.Bold
            .Text = "Avvia l'assistenza remota"
        End With
        Tip.SetToolTip(ButtonARemota, "Collegati con l'assistenza")

        With btnEsci
            .Margin = New Padding(0)
            .Padding = New Padding(5)
            .Font = Utx.AppFont.Bold
            .Image = My.Resources.Esci.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Esci"
            .TextAlign = ContentAlignment.MiddleRight
        End With
    End Sub

    Private Sub FormAvvio_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Utx.PowerManager.PowerSaveOff()

        WebBrowser1.ScriptErrorsSuppressed = True
        WebBrowser1.Navigate("http://lnx.utools.it/assistenza-omnia-manager/")
    End Sub

    Private Sub btnChat_Click(sender As Object, e As System.EventArgs) Handles btnChat.Click
        Me.WindowState = FormWindowState.Maximized
        WebBrowser1.Navigate("http://lnx.utools.it/modulo-di-contatto/")
    End Sub

    Private Sub btnEsci_Click(sender As Object, e As System.EventArgs) Handles btnEsci.Click
        Me.Close()
    End Sub

    Public Sub AssistenzaRemota(NomeClient As String)
        Dim ClientQS As String = ""
        Try
            Dim Cartella As String = Path.Combine(Directory.GetParent(Application.ExecutablePath).FullName, "Modelli")

            'crea la cartella se non esiste
            Directory.CreateDirectory(Cartella)

            'aggiungo il nome dell'exe dell'assistenza remota
            ClientQS = Path.Combine(Cartella, NomeClient)

            'rinomina vecchio client. eliminare a regime dal 01/2026-----------------------
            Try
                Dim OldClient As String = Path.Combine(Cartella, "auasupport.exe")
                My.Computer.FileSystem.RenameFile(OldClient, "auasupport-qs.exe")
            Catch ex As Exception
            End Try
            '------------------------------------------------------------------------------

            'se non esiste scarico il file
            If Not File.Exists(ClientQS) Then
                ButtonARemota.Text = "Download in corso..."
                Dim LinkClientQS As String = $"http://www.utools.it/Unitools/Assistenza/{NomeClient}"
                ScaricaFile(LinkClientQS, ClientQS)
            End If

            'lo avvio
            If File.Exists(ClientQS) Then
                Shell(ClientQS, AppWinStyle.NormalFocus, True)
                Me.Close()
            Else
                Err.Raise(vbObjectError + 1000)
            End If

        Catch ex As Exception
            'si verifica in genere se il file di assistenza remota è danneggiato
            If ex.GetType.ToString = "System.IO.FileNotFoundException" Then
                File.Delete(ClientQS)
            End If

            Log.Info(ex.Message)

            MsgBox($"Errore imprevisto.{Environment.NewLine}Verrà ora aperta la pagina web dell'assistenza.", vbExclamation, Utx.Globale.TitoloApp)
            WebBrowser1.Navigate("http://lnx.utools.it/modulo-di-contatto/")
        End Try
    End Sub

    Private Function ScaricaFile(Url As String, Destinazione As String) As Boolean
        Try
            Using wc As New System.Net.WebClient
                wc.Proxy = Utx.Globale.UniProxy.Proxy
                wc.DownloadFile(Url, Destinazione)
            End Using
            Return True
        Catch ex As Exception
            Log.Info(ex.Message)
            Return False
        End Try
    End Function

    Private Sub Ripristino()
        Try
#If DEBUG Then
            If SessioneNascosta Then
                MsgBox($"Avviata sessione nascosta {IdApp}-199999AA{Environment.NewLine}Il LiveUpdate non sarà eseguito", MsgBoxStyle.Information)
                Exit Sub
            End If
#End If
            If SessioneNascosta Then
                LiveUpdate.Main.ControlloAggiornamenti(IdApp, "199999AA", Forzatura:=True)
                Exit Sub
            End If

            If Utx.Utente.IsUniageUser(TextBoxUtente.Text) = False Then
                MsgBox("Inserite la vostra utenza uniage", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                TextBoxUtente.Focus()
                Exit Sub
            End If
            ButtonRipristino.Enabled = False
            ButtonRipristino.Text = "Aggiornamento/Ripristino in corso. Attendere..."

            Log.Info($"Ripristino applicazione richiesto da assistenza: {IdApp}-{TextBoxUtente.Text} con Forzatura")

            LiveUpdate.Main.ControlloAggiornamenti(IdApp, TextBoxUtente.Text, Forzatura:=True)

        Catch ex As Exception
            Log.Info(ex.Message)
        Finally
            ButtonRipristino.Text = "Per ripristinare/aggiornare manualmente Unitools clicca qui"
            ButtonRipristino.Enabled = True
        End Try
    End Sub

    Private Sub ButtonRipristino_Click(sender As Object, e As EventArgs) Handles ButtonRipristino.Click
        Ripristino()
    End Sub

    Private Sub ButtonRipristino_TextChanged(sender As Object, e As EventArgs) Handles ButtonRipristino.TextChanged
        Refresh()
    End Sub

    Private Sub FormAssistenza_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Utx.PowerManager.PowerSaveOn()
    End Sub

    Private Sub FormAssistenza_Load(sender As Object, e As EventArgs) Handles Me.Load
        If SessioneNascosta Then
            'se la sessione è nascosta (autoexec) avvio liveupdate
            ButtonRipristino.PerformClick()
            Me.Close()
        End If

        TextBoxUtente.ForeColor = Color.Gainsboro
        TextBoxUtente.Text = "utente"
    End Sub

    Private Sub TextBoxUtente_GotFocus(sender As Object, e As EventArgs) Handles TextBoxUtente.GotFocus
        If TextBoxUtente.Text = "utente" Then
            TextBoxUtente.Text = ""
            TextBoxUtente.ForeColor = SystemColors.WindowText
            TextBoxUtente.BackColor = Color.Yellow
        End If
    End Sub

    Private Sub TextBoxUtente_LostFocus(sender As Object, e As EventArgs) Handles TextBoxUtente.LostFocus
        If String.IsNullOrEmpty(TextBoxUtente.Text) Then
            TextBoxUtente.ForeColor = Color.Gainsboro
            TextBoxUtente.Text = "utente"
            TextBoxUtente.BackColor = SystemColors.Window
        End If
    End Sub

    Private Sub btnARemota_Click(sender As Object, e As System.EventArgs) Handles ButtonARemota.Click
        With ButtonARemota
            .Padding = New Padding(7, 0, 7, 0)
            .Image = My.Resources.Kermit.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Avvio in corso..."
            .TextAlign = ContentAlignment.MiddleRight
            .BackColor = Color.Gainsboro
            .ForeColor = Color.Black
            .Refresh()
            .Tag = True 'apertura in corso
        End With

        AssistenzaRemota("auasupport-qs.exe")

        With ButtonARemota
            .Image = Nothing
            .BackColor = Color.LightSteelBlue
            .ForeColor = Color.Black
            .Font = Utx.AppFont.Bold
            '.Width = 250
            '.Height = 50
            .Text = "Avvia l'assistenza remota"
            .TextAlign = ContentAlignment.MiddleCenter
            .Tag = False
        End With
    End Sub

    Private Sub TextBoxUtente_Validating(sender As Object, e As CancelEventArgs) Handles TextBoxUtente.Validating
        If TextBoxUtente.Text <> "utente" Then
            TextBoxUtente.Text = TextBoxUtente.Text.ToUpper
        End If
    End Sub
End Class