Imports System.IO
Imports System.Data.OleDb
Imports System.ComponentModel

Public Class FormAvvioCentralino

    Private Delegate Sub DelegaChiamataInArrivo(Parametri As Dictionary(Of String, String))
    Public Event RichiestaAnagrafica(CodiceFiscale As String)
    Public Event RichiestaSinistri(CodiceFiscale As String)

    Public Shared Note As String = Path.Combine(My.Computer.FileSystem.SpecialDirectories.Desktop, "Centralino.txt")

    Private WithEvents TimerAvvio As New Timer
    Private CartellaControllata As String
    Private CartellaComandi As String
    Private Pattern As String
    Private RitardoSecondi As Integer
    Private ListaAgenzie As New List(Of String)
    Private WithEvents ElencoChiamate As New Chiamate
    Private WithEvents Notifica As FormNotifica
    Private WithEvents Telefono As Regista.Telefono = Regista.Telefono.GetInstance()
    Private RegiaListener As Regista.ListenerFile
    Friend Shared ElencoNotifiche As New List(Of FormNotifica)
    Private timerRegistrami As System.Threading.Timer

    Private Enum Flag
        PATH
        PATTERN
        SECONDI
    End Enum

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Size = New Size(600, 350)
        Me.Font = Utx.AppFont.Normal
        Me.Icon = Risorse.Immagini.Icon("telefono")
        Me.Text = "Monitor centralino"
        Me.AcceptButton = ButtonOk
        Me.WindowState = FormWindowState.Minimized

#If DEBUG Then
        Utx.ApplicationLog.LivelloLog = Utx.ApplicationLog.Livello.DEBUG
#End If

        'posizione comandi
        CartellaComandi = Path.Combine(Utx.Globale.Paths.CartellaTempComune, "Centralino\Comandi")
        Directory.CreateDirectory(CartellaComandi)

        ImpostaControlli()
        'EseguiComando()
    End Sub

    Private Sub ImpostaControlli()
        With LabelMessaggio
            .Padding = New Padding(15)
            .Font = Utx.AppFont.Bold
            .ForeColor = Color.DodgerBlue
        End With
        With ButtonOk
            .Margin = New Padding(1)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Silver
            .Image = Risorse.Immagini.Bitmap("ok32")
            .ImageAlign = ContentAlignment.MiddleRight
            .Text = "Ok"
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonEsci
            .Margin = New Padding(1)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Silver
            .Image = Risorse.Immagini.Bitmap("esci")
            .ImageAlign = ContentAlignment.MiddleRight
            .Text = "Chiudi"
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        'tab configura
        With CheckBoxStart
            .FlatStyle = FlatStyle.Flat
            .CheckAlign = ContentAlignment.MiddleRight
            .Text = String.Format("· Avvia automaticamente all'avvio di {0}", Utx.Globale.TitoloApp)
        End With
        With LabelSecondi
            .Dock = DockStyle.Fill
            .Text = "· Visualizza notifica per secondi"
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        With TextBoxSecondi
            .Dock = DockStyle.Fill
            .BorderStyle = BorderStyle.FixedSingle
            .TextAlign = HorizontalAlignment.Center
        End With
        With LabelCartella
            .Dock = DockStyle.Fill
            .TextAlign = ContentAlignment.BottomLeft
            .Text = "· Cartella centralino da monitorare:"
        End With
        With TextBoxCartella
            .Margin = New Padding(12, 0, 0, 0)
            .Dock = DockStyle.Fill
            .BorderStyle = BorderStyle.FixedSingle
            .ReadOnly = True
        End With
        With ButtonCartella
            .Margin = New Padding(3, 0, 3, 3)
            .Height = 23
            .Dock = DockStyle.Top
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Sfoglia"
        End With
        With LabelEstensione
            .Dock = DockStyle.Fill
            .Text = "· Estensione file da controllare:"
            .TextAlign = ContentAlignment.BottomLeft
        End With
        With TextBoxEstensione
            .Dock = DockStyle.Bottom
            .BorderStyle = BorderStyle.FixedSingle
            .TextAlign = HorizontalAlignment.Center
        End With
        With LabelComando
            .Dock = DockStyle.Fill
            .TextAlign = ContentAlignment.BottomLeft
            .Text = "· Comando da eseguire prima dell'avvio del centralino:"
        End With
        With ButtonCartellaComandi
            .Margin = New Padding(3, 0, 3, 3)
            .Height = 23
            .Dock = DockStyle.Top
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Sfoglia"
        End With
        With ComboBoxComandi
            .Margin = New Padding(12, 0, 0, 0)
            .FlatStyle = FlatStyle.Flat
            .DropDownStyle = ComboBoxStyle.DropDownList
        End With
        With ButtonElimina
            .Margin = New Padding(1)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Elimina utente"
        End With
        With ButtonAggiungi
            .Margin = New Padding(1)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Aggiungi utente"
        End With
        With ButtonModifica
            .Margin = New Padding(1)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Modifica utente"
        End With
        With ButtonCaricaCsv
            .Margin = New Padding(1)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Carica da csv"
        End With
        With ButtonChiama
            .Margin = New Padding(3)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Chiama"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = Risorse.Immagini.Bitmap("cornetta")
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With dgvInterni
            .AllowUserToAddRows = False
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With
        ComboBoxInterni.Font = Utx.AppFont.Bold
        LabelUtente.Font = Utx.AppFont.Bold
        TextBoxTelefono.Font = Utx.AppFont.Extra(18, FontStyle.Bold)
        TimerAvvio.Interval = 3000
        TimerAvvio.Enabled = True
    End Sub

    Private Sub LeggiComandi()
        Try
            With ComboBoxComandi
                .Items.Clear()
                .Items.Add("Seleziona un comando (exe,bat,...)")

                For Each f As String In Directory.GetFiles(CartellaComandi, "*.bat")
                    .Items.Add(Path.GetFileName(f))
                Next
                'seleziono il comando impostato dall'utente (se esiste)
                Dim Comando As String = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.CENTRALINO_COMANDO, "")
                If String.IsNullOrEmpty(Comando) = True Then
                    .SelectedIndex = 0
                Else
                    For Each c As String In ComboBoxComandi.Items
                        If c = Comando Then
                            .SelectedItem = c
                            Exit For
                        End If
                    Next
                End If
            End With
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub EseguiComando()
        Try
            Dim Comando As String = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.CENTRALINO_COMANDO, "")
            Globale.Log.Debug("Eseguo il comando: {0}", {Comando})

            If String.IsNullOrEmpty(Comando) = False Then
                If New DriveInfo(Path.GetPathRoot(CartellaComandi)).IsReady Then
                    Comando = Path.Combine(CartellaComandi, Comando)
                    If File.Exists(Comando) Then
                        Shell(Comando, AppWinStyle.NormalFocus, True, 15)
                    End If
                End If
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub FormAvvioCentralino_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        TextBoxTelefono.Focus()
    End Sub

    Private Sub FormAvvioCentralino_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        On Error Resume Next
        RegiaListener.StopListener = True

        Dim url As String = Regista.ListenerTcp.GetUrlBase("Cancellami")
        url &= "?" & Regista.ClientUnitools.KEY_UTENTE & "=" & Utx.Globale.UtenteCorrente.UniageUser
        Regista.ListenerFile.Invia(url)

#If DEBUG Then
        For Each p As Process In System.Diagnostics.Process.GetProcessesByName("Regia")
            p.Kill()
        Next
#End If

        Terminale.ResetInterni()
        timerRegistrami.Dispose()
        TimerAvvio.Dispose()
    End Sub

    Private Sub FormAvvio_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Globale.Log.Info("load")

            ListaAgenzie = Utx.EnteGestore.CodiciGestiti

            TextBoxCartella.Text = Utx.Globale.SettingGlobale.LeggiValore(Utx.GestioneFlag.TipoFlag.CENTRALINO_CARTELLA,
                                                                         Path.Combine(Utx.Globale.Paths.CartellaUnitoolsRete, "Temp\Centralino"))
            TextBoxEstensione.Text = Utx.Globale.SettingGlobale.LeggiValore(Utx.GestioneFlag.TipoFlag.CENTRALINO_PATTERN, "3cx")
            TextBoxSecondi.Text = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.CENTRALINO_SECONDI, "20")
            CheckBoxStart.Checked = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.CENTRALINO_AUTOSTART, "False")

            CartellaControllata = TextBoxCartella.Text.Trim
            Pattern = String.Format("*.{0}", TextBoxEstensione.Text)
            RitardoSecondi = TextBoxSecondi.Text

        Catch ex As Exception
            Globale.Log.Info(ex)
            MsgBox(String.Format("Le impostazioni del centralino, per l'utente {0} sono state reimpostate ai valori di default.",
                                 Utx.Globale.UtenteCorrente.UniageUser),
                             MsgBoxStyle.Information, Utx.Globale.TitoloApp)

            Utx.Globale.SettingGlobale.AggiungiModifica(Utx.GestioneFlag.TipoFlag.CENTRALINO_CARTELLA,
                                                                          Path.Combine(Utx.Globale.Paths.CartellaUnitoolsRete, "Temp\Centralino"))
            Utx.Globale.SettingGlobale.AggiungiModifica(Utx.GestioneFlag.TipoFlag.CENTRALINO_PATTERN, "3cx")
            Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.CENTRALINO_SECONDI, "20")
            Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.CENTRALINO_AUTOSTART, "False")

            TextBoxCartella.Text = Path.Combine(Utx.Globale.Paths.CartellaUnitoolsRete, "Temp\Centralino")
            TextBoxEstensione.Text = "3cx"
            TextBoxSecondi.Text = "20"
            CheckBoxStart.Checked = False

            CartellaControllata = TextBoxCartella.Text.Trim
            Pattern = String.Format("*.{0}", TextBoxEstensione.Text)
            RitardoSecondi = TextBoxSecondi.Text
        End Try
        Try
            'controllo percorso
            If String.IsNullOrEmpty(TextBoxCartella.Text) Then
                Utx.Globale.SettingGlobale.AggiungiModifica(Utx.GestioneFlag.TipoFlag.CENTRALINO_CARTELLA,
                                                             Path.Combine(Utx.Globale.Paths.CartellaUnitoolsRete, "Temp\Centralino"))
                TextBoxCartella.Text = Path.Combine(Utx.Globale.Paths.CartellaUnitoolsRete, "Temp\Centralino")
            End If

            If New DriveInfo(Path.GetPathRoot(CartellaControllata)).IsReady Then
                Directory.CreateDirectory(CartellaControllata)
            End If
            LeggiComandi()
#If DEBUG Then
            If Utx.NetFunc.AltraIstanza("Regia", ProcessoAvviato:=False) = False Then
                Process.Start(Path.Combine(Utx.Globale.Paths.CartellaApp, "Regia.exe"))
            End If
#End If
            'utenti
            ImpostaUtenti()
        Catch ex As Exception
            Me.Close()
        End Try
    End Sub

    Private Sub ImpostaUtenti()
        Try
            Globale.UtenteCorrente = New Utente()

            LabelUtente.Text = String.Format("Utente {0} - Telefono OFF", Utx.Globale.UtenteCorrente.UniageUser.ToUpper)

            For Each i As DataRow In Terminale.Interni.Rows
                ComboBoxInterni.Items.Add(i("Interno"))
                If i("Utente").ToString.ToUpper = Utx.Globale.UtenteCorrente.UniageUser.ToUpper Then
                    ComboBoxInterni.SelectedIndex = ComboBoxInterni.Items.Count - 1 'qui si accoppia il terminale
                End If
            Next
        Catch ex As Exception
            Me.Close()
        End Try
    End Sub

    Private Sub FormAvvioCentralino_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'per validare tutti gli elementi del setting
        TabMain.Focus()
        TabMain.SelectedTab = TabPageMonitor
        TextBoxTelefono.Focus()
    End Sub

    Private Sub FormAvvio_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        TabMain.ColorStyle = Utx.UtTabControl.TabColorStyle.AZZURRO
        SetLabelMessaggio()
        Me.Refresh()
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        Me.Close()
    End Sub

    Private Sub Notifica_EliminaNotifica(ByRef ChiamataDaEliminare As Chiamata) Handles Notifica.EliminaNotifica
        ElencoChiamate.Elimina(ChiamataDaEliminare)
    End Sub

    Private Sub ElencoChiamate_Notifica(ByRef NuovaChiamata As Chiamata) Handles ElencoChiamate.Notifica
        Try
            Notifica = New FormNotifica(ElencoChiamate.ChiamataPrecedente)
            Notifica.ListaAgenzie = ListaAgenzie
            Notifica.Chiamata = NuovaChiamata
            Notifica.Secondi = RitardoSecondi
            'visualizzo la notifica
            Notifica.Show()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub Notifica_RichiestaAnagrafica(CodiceFiscale As String) Handles Notifica.RichiestaAnagrafica
        RaiseEvent RichiestaAnagrafica(CodiceFiscale)
    End Sub

    Private Sub Notifica_RichiestaSinistri(CodiceFiscale As String) Handles Notifica.RichiestaSinistri
        RaiseEvent RichiestaSinistri(CodiceFiscale)
    End Sub

    Private Sub TimerAvvio_Tick(sender As Object, e As EventArgs) Handles TimerAvvio.Tick
        TimerAvvio.Enabled = False
#If Not Debug Then
                Me.WindowState = FormWindowState.Minimized
#End If
    End Sub

    Private Sub CheckBoxStart_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxStart.CheckedChanged
        Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.CENTRALINO_AUTOSTART, CheckBoxStart.Checked.ToString, True)
    End Sub

    Private Sub TextBoxSecondi_Validated(sender As Object, e As EventArgs) Handles TextBoxSecondi.Validated
        If IsNumeric(TextBoxSecondi.Text) = True Then
            RitardoSecondi = TextBoxSecondi.Text
            Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.CENTRALINO_SECONDI, TextBoxSecondi.Text)
        Else
            RitardoSecondi = 20
            Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.CENTRALINO_SECONDI, "20")
        End If
    End Sub

    Private Sub TextBoxEstensione_Validated(sender As Object, e As EventArgs) Handles TextBoxEstensione.Validated
        Pattern = String.Format("*.{0}", TextBoxEstensione.Text)
        Utx.Globale.SettingGlobale.AggiungiModifica(Utx.GestioneFlag.TipoFlag.CENTRALINO_PATTERN, TextBoxEstensione.Text)
    End Sub

    Private Sub TextBoxCartella_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCartella.TextChanged
        CartellaControllata = TextBoxCartella.Text
        Utx.Globale.SettingGlobale.AggiungiModifica(Utx.GestioneFlag.TipoFlag.CENTRALINO_CARTELLA, TextBoxCartella.Text)
    End Sub

    Private Sub ButtonCartella_Click(sender As Object, e As EventArgs) Handles ButtonCartella.Click
        Using fb As New FolderBrowserDialog
            fb.SelectedPath = CartellaControllata
            fb.ShowDialog()

            If fb.SelectedPath.Length > 0 Then
                TextBoxCartella.Text = fb.SelectedPath
            End If
        End Using
        SetLabelMessaggio()
    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub SetLabelMessaggio()
        If Directory.Exists(CartellaControllata) Then
            With LabelMessaggio
                .Image = Risorse.Immagini.Bitmap("conn_on")
                .ImageAlign = ContentAlignment.TopCenter
                .ForeColor = Color.Blue
                .Text = "Monitoraggio del centralino attivo"
                .TextAlign = ContentAlignment.BottomCenter
            End With
        Else
            With LabelMessaggio
                .Image = Risorse.Immagini.Bitmap("conn_off")
                .ImageAlign = ContentAlignment.TopCenter
                .ForeColor = Utx.AppColor.RossoScuro
                .Text = String.Format("Attenzione: la cartella selezionata non esiste.{0}Monitoraggio del centralino NON attivo", Environment.NewLine)
                .TextAlign = ContentAlignment.BottomCenter
            End With
        End If
    End Sub

    Private Sub ButtonCartellaComandi_Click(sender As Object, e As EventArgs) Handles ButtonCartellaComandi.Click
        Try
            Using cd As New OpenFileDialog
                cd.InitialDirectory = CartellaComandi
                cd.CheckFileExists = True
                If cd.ShowDialog = Windows.Forms.DialogResult.OK Then
                    File.Copy(cd.FileName, Path.Combine(CartellaComandi, Path.GetFileName(cd.FileName)), True)
                    LeggiComandi()
                End If
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ComboBoxComandi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxComandi.SelectedIndexChanged
        If ComboBoxComandi.SelectedIndex = 0 Then
            Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.CENTRALINO_COMANDO, "")
        Else
            Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.CENTRALINO_COMANDO, ComboBoxComandi.Text)
        End If
    End Sub

    Private Sub ComboBoxInterni_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxInterni.SelectedIndexChanged
        If Globale.UtenteCorrente Is Nothing Then
            LabelUtente.Text = "Utente ND - Telefono OFF"
        ElseIf IsNumeric(ComboBoxInterni.Text) Then
            Globale.UtenteCorrente.Interno = ComboBoxInterni.Text
            LabelUtente.Text = String.Format("Utente {0} - Telefono {1}", Utx.Globale.UtenteCorrente.UniageUser.ToUpper, Globale.UtenteCorrente.StatoTelefono)
            AvviaAscolto()
        End If
    End Sub

    Private Sub TabMain_Selected(sender As Object, e As TabControlEventArgs) Handles TabMain.Selected
        Select Case e.TabPage.Name
            Case TabPageInterni.Name
                AggiornaInterni()
                For k As Integer = 0 To dgvInterni.Rows.Count - 1
                    If dgvInterni.Rows(k).Cells("Utente").Value.ToString.ToUpper = Utx.Globale.UtenteCorrente.UniageUser.ToUpper Then
                        dgvInterni.CurrentCell = dgvInterni.Rows(k).Cells(0)
                        Exit For
                    End If
                Next
        End Select
    End Sub

    Private Sub ButtonAggiungi_Click(sender As Object, e As EventArgs) Handles ButtonAggiungi.Click
        Using f As New FormUtente
            f.ShowDialog()

            If f.DialogResult = Windows.Forms.DialogResult.OK Then
                AggiornaInterni()
            End If
        End Using
    End Sub

    Private Sub ButtonModifica_Click(sender As Object, e As EventArgs) Handles ButtonModifica.Click
        Using f As New FormUtente(dgvInterni.CurrentRow)
            f.ShowDialog()

            If f.DialogResult = Windows.Forms.DialogResult.OK Then
                AggiornaInterni()
            End If
        End Using
    End Sub

    Private Sub AggiornaInterni()
        dgvInterni.DataSource = Terminale.Interni
        dgvInterni.Columns("Nome").DefaultCellStyle.BackColor = Color.Yellow
        ImpostaUtenti()
    End Sub

    Private Sub ButtonElimina_Click(sender As Object, e As EventArgs) Handles ButtonElimina.Click
        Try
            If MsgBox("Confermate la cancellazione dell'interno?",
                      MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then
                Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdb(Utx.ConnessioniDb.Db.SMS))
                    c.Open()

                    Using cmd As New OleDbCommand()
                        cmd.Connection = c
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = "DELETE FROM UtentiCentralino WHERE Interno = ?"
                        cmd.Parameters.AddWithValue("interno", dgvInterni.CurrentRow.Cells("Interno").Value)

                        cmd.ExecuteNonQuery()
                    End Using
                End Using
                AggiornaInterni()
            End If
        Catch ex As Exception
            Globale.Log.Info(ex)
        End Try
    End Sub

    Private Sub ButtonCaricaCsv_Click(sender As Object, e As EventArgs) Handles ButtonCaricaCsv.Click
        Try
            Using cd As New OpenFileDialog
                cd.InitialDirectory = Utx.Globale.UtenteCorrente.Desktop
                cd.Filter = "File csv (*.csv)|*.csv"
                cd.CheckFileExists = True

                If cd.ShowDialog() = DialogResult.OK Then

                    Using c As New OleDbConnection(Utx.Globale.MDBDriver + Utx.ConnessioniDb.PathMdb(Utx.ConnessioniDb.Db.SMS))
                        c.Open()

                        Using cmd As New OleDbCommand()
                            cmd.Connection = c
                            cmd.CommandType = CommandType.Text

                            If MsgBox("Eliminare la lista utenti attuale?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then
                                cmd.CommandText = "DELETE FROM UtentiCentralino"
                                cmd.ExecuteNonQuery()
                            End If

                            Using sr As New StreamReader(cd.FileName)

                                Do While sr.EndOfStream = False
                                    Dim Campi() As String = sr.ReadLine.Split(";")

                                    If IsNumeric(Campi(0)) Then
                                        cmd.CommandText = "SELECT COUNT(*) FROM UtentiCentralino WHERE Interno = ?"
                                        cmd.Parameters.Clear()
                                        cmd.Parameters.AddWithValue("interno", Campi(0))

                                        If cmd.ExecuteScalar = 0 Then
                                            cmd.CommandText = "INSERT INTO UtentiCentralino (Interno,Utente,Nome,PasswordTelefono,IPTelefono,MacAddressTelefono) VALUES(?,'',?,?,?,?)"
                                            cmd.Parameters.AddWithValue("nome", Microsoft.VisualBasic.Left(Campi(1), 40))
                                            cmd.Parameters.AddWithValue("pw", Campi(2))
                                            cmd.Parameters.AddWithValue("ip", Campi(3))
                                            cmd.Parameters.AddWithValue("mac", Campi(4))
                                            cmd.ExecuteNonQuery()
                                        End If
                                    End If
                                Loop
                            End Using
                        End Using
                    End Using
                    Terminale.ResetInterni()
                    AggiornaInterni()
                End If
            End Using
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonChiama_Click(sender As Object, e As EventArgs) Handles ButtonChiama.Click
        Servizi.Chiama(TextBoxTelefono.Text)
    End Sub

    Private Sub AvviaAscolto()
        If RegiaListener IsNot Nothing Then
            ' il listener completa il giro è finisce il thread
            RegiaListener.StopListener = True
        End If
        RegiaListener = New Regista.ListenerFile(Regista.ListenerTcp.PORTA_BASE + Globale.UtenteCorrente.Interno)
        Dim StartListenThread As New Threading.Thread(AddressOf RegiaListener.StartListen)
        StartListenThread.Start()

        If timerRegistrami IsNot Nothing Then
            timerRegistrami.Dispose()
            timerRegistrami = Nothing
        End If

        Dim url As String = Regista.ListenerTcp.GetUrlBase("Registrami")
        url &= "?" & Regista.ClientUnitools.KEY_UTENTE & "=" & Utx.Globale.UtenteCorrente.UniageUser
        url &= "&" & Regista.ClientUnitools.KEY_INTERNO & "=" & Globale.UtenteCorrente.Interno
        url &= "&" & Regista.ClientUnitools.KEY_INDIRIZZOCALLBACK & "=" & RegiaListener.Address
        url &= "&" & Regista.ClientUnitools.KEY_PORTACALLBACK & "=" & RegiaListener.Port

        timerRegistrami = New System.Threading.Timer(AddressOf Registrami, url, 0, 100 * 1000)
    End Sub


    Private Sub Registrami(state As Object)
        'notifica al centralino che l'istanza unitool è in ascolto nell'indirizzo indicato
        'questo evento è richiamato da timerRegistrami di cui sopra
        Regista.ListenerFile.Invia(state.ToString)
    End Sub

    Private Sub Telefono_ChiamataInArrivo(Parametri As Dictionary(Of String, String)) Handles Telefono.ChiamataInArrivo
        Try
            If Me.InvokeRequired Then
                Me.Invoke(New DelegaChiamataInArrivo(AddressOf ChiamataInArrivo), Parametri)
            Else
                ChiamataInArrivo(Parametri)
            End If
        Catch ex As Exception
            'se chiudo form centralino con telefonata in arrivo in contemporanea si genera un errore per oggetto non più disponibile
            Globale.Log.Info(ex.Message)
        End Try
    End Sub

    Private Sub ChiamataInArrivo(Parametri As Dictionary(Of String, String))
        '+variable URL supported and description
        '$mac MAC address
        '$ip IP address
        '$model model of the phone
        '$firmware firmware of the phone
        '$active_url SIP URI of current active account (when Incoming call, Outgoing call, Call established)
        '$active_user User account part of SIP URI from current active account (when Incoming call, Outgoing call, Call established)
        '$active_host Server part of SIP URI from current active account(when Incoming call, Outgoing call, Call established)
        '$local SIP URI of Callee(when Incoming call, Outgoing call)
        '$remote SIP URI of Caller(when Incoming call)
        '$display_local Display name of Callee(when Incoming call, Outgoing call)
        '$display_remote Display name of Caller(when Incoming call)
        '$call_id call_id(when Imcoming call, Outgoing call, Call established)
        '$duration the talk duration, the unit is second
        '$callDirection record the incoming and outing call, the value is in, out or unknown
        '$callerID the display name of the other party on the LCD.
        '$calledNumber the call number when calling out or transfer the call
        '$csta_id CSTA ID
        '$expansion_module the model and version of the expansion which is currently using
        '$active_key the function key (e.g. P1, P5, P32,..) associated with a call
        '+ut=in/out/answer/end/transfer

        '+esempio di stringhe di configurazione del telefono 27.05.2018
        'in arrivo: http://IP:10000/Centralino?ut=in&remote=$remote&mac=$mac&active_user=$active_user&call_id=$call_id
        'in uscita: http://IP:10000/Centralino?ut=out&calledNumber=$calledNumber&call_id=$call_id
        'risposta: http://IP:10000/Centralino?ut=answer&active_user=$active_user&call_id=$call_id
        'terminata: http://IP:10000/Centralino?ut=end&duration=$duration&call_id=$call_id
        'trasferisci chiamata: http://IP:10000/Centralino?ut=transfer&call_id=$call_id
        'trasfer failed: http://IP:10000/Centralino?ut=transferfail&call_id=$call_id
        'trasfer finished: http://IP:10000/Centralino?ut=transferok&call_id=$call_id

        Try
#If DEBUG Then
            Globale.Log.Info()
            For Each kvp As KeyValuePair(Of String, String) In Parametri
                Globale.Log.Info("{0}: {1}", {kvp.Key, kvp.Value})
            Next
            Globale.Log.Info()
#End If
            Select Case Parametri("ut")
                Case "in"
                    If Terminale.IsInterno(Chiamata.EstraiTelefonoIN(Parametri)) = False Then
                        ElencoChiamate.Add(Parametri)
                    End If
                Case "out"
                    If Terminale.IsInterno(Chiamata.EstraiTelefonoOUT(Parametri)) = False Then
                        ElencoChiamate.Add(Parametri)
                    End If
                Case "answer"
                    'se ha risposto un altro interno cerco la notifica e la chiudo
                    If Regista.Richiesta.Valore(Parametri, "active_user") <> Globale.UtenteCorrente.Interno Then
                        Dim Id As Integer = Regista.Richiesta.Valore(Parametri, "call_id")
                        For Each n As FormNotifica In ElencoNotifiche
                            If n.Chiamata.Id = Id Then
                                n.Close()
                                ElencoNotifiche.Remove(n)
                                Exit For
                            End If
                        Next
                    End If
                Case "end"
                    ElencoChiamate.Termina(Parametri)
                Case "transfer", "transferfail"
                    'non fare niente (per ora)
                Case "transferok"
                    ElencoChiamate.Elimina(Parametri)
            End Select

        Catch ex As Exception
            Globale.Log.Info(ex.Message)
        End Try
    End Sub

    Private Sub dgvInterni_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgvInterni.MouseDoubleClick
        ButtonModifica.PerformClick()
    End Sub
End Class