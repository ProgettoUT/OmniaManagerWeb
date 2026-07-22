Imports System.Text
Imports System.IO
Imports System.Windows.Forms

Public Class FormInfo

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(580, 620)
        Me.Font = Utx.AppFont.Normal
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        'Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Text = String.Format("OmniaManager {0}", InfoApp.VersioneApp) + ".T"
        Me.Icon = Risorse.Immagini.Icon("aua")
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'se non si tratta del profilo completo rimuovo il tab dell'AAU
        'If Utx.Globale.ProfiloEnteGestore.ProfiloApp <> Utx.Enumerazioni.ProfiloApp.COMPLETO Then
        '    TabControl1.TabPages.Remove(TabAAU)
        'End If
        TabControl1.TabPages.Remove(TabAAU)

        With btnEsci
            .Padding = New Padding(10)
            .Image = Risorse.Immagini.Bitmap("esci")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Esci"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With pbUnitools
            .BorderStyle = BorderStyle.None
            .BackColor = Color.White
            .SizeMode = PictureBoxSizeMode.CenterImage
            Select Case Utx.Globale.ProfiloEnteGestore.ProfiloApp
                Case Utx.Enumerazioni.ProfiloApp.COMPLETO
                    .Image = Risorse.Immagini.Image("logo_splash")
                Case Utx.Enumerazioni.ProfiloApp.SINISTRI
                    .Image = Risorse.Immagini.Image("logo_unisinistri")
            End Select
        End With
        With pbUniarea
            .BorderStyle = BorderStyle.None
            .BackColor = Color.White
            .SizeMode = PictureBoxSizeMode.CenterImage
            .Image = Risorse.Immagini.Image("logo_aua_info")
        End With
        With pbAAU
            .BorderStyle = BorderStyle.None
            .BackColor = Color.White
            .SizeMode = PictureBoxSizeMode.CenterImage
            .Image = Risorse.Immagini.Image("logo_aau")
        End With
        With dgvConfig
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
        End With
        Utx.NetFunc.DoppioBuffer(dgvConfig)
        Dim Testo As New StringBuilder
        'uniarea
        With Testo
            .AppendLine("via Stalingrado 57 - 40128 Bologna")
            .AppendLine()
            .AppendLine("Tel.051.6313108 - 335.5308389")
            .AppendLine("Fax 051.4159737")
            .AppendLine()
            .AppendLine("Sito web: www.auaonline.it")
            .AppendLine("E-mail: info@auaonline.it")
        End With
        LabelUniarea.TextAlign = ContentAlignment.MiddleCenter
        LabelUniarea.Text = Testo.ToString

        'auto spegnimento
#If DEBUG Then
        btnAutoSpegnimento.Enabled = True
#Else
        btnAutoSpegnimento.Enabled = SessioneRDP()
#End If

        'versione
        With TextBoxFiltro
            .Margin = New Padding(0)
            .BorderStyle = BorderStyle.Fixed3D
            .TextAlign = HorizontalAlignment.Center
        End With
        With ButtonFiltro
            .Margin = New Padding(0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .Text = "Filtra"
        End With
        'utente
        LeggiUtente()
    End Sub

    Private Sub FormInfo_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        TabControl1.ItemSize = New Size(90, 25)
        TabControl1.ColorStyle = Utx.UtTabControl.TabColorStyle.ORANGE
        Me.Refresh()
    End Sub

    Private Sub LeggiUtente()
        Try
            Dim dr As DataTableReader = Utx.FunzioniDb.CreaDataTableReader("SELECT TOP 1 * FROM ProfiloUtente")

            If dr.HasRows Then
                dr.Read()

                Dim Testo As New StringBuilder
                With Testo
                    .AppendLine()
                    .AppendLine($"Compagnia: {Utx.Globale.ProfiloEnteGestore.Compagnia}")
                    .AppendLine()
                    .AppendLine($"Agenzia madre: {Utx.Globale.ProfiloEnteGestore.AgenziaMadre} Sede: {Utx.Globale.ProfiloEnteGestore.CodiceSede}")
                    .AppendLine($"Codici collegati: {Utx.EnteGestore.StringaCodiciGestiti.Replace(";", "-")}")
                    .AppendLine()
                    .AppendLine($"Indirizzo: {dr("Indirizzo")}")
                    .AppendLine($"Località: {dr("Cap")} {dr("Localita")} - {dr("Provincia")}")
                    .AppendLine()
                    .AppendLine($"Utente: {Utx.Globale.UtenteCorrente.UniageUser} ({Utx.Globale.UtenteCorrente.UnisaluteUser}) - {Utx.Globale.UtenteCorrente.NomeUtente}")
                    .AppendLine($"Ruolo: {Utx.Globale.UtenteCorrente.DeskRuolo} ({Utx.Globale.UtenteCorrente.Ruolo})")
                    .AppendLine($"Profilo Unipol: {Utx.Globale.UtenteCorrente.Profilo.ProfiloUnipol}")
                    .AppendLine("Profilo AUA: -")
                    .AppendLine()
                    .AppendLine($"Sessione avviata il {Utx.Globale.SessioneCorrente.Inizio}")
                End With

                LabelUtente.Padding = New Padding(10)
                LabelUtente.Text = Testo.ToString
            Else
                LabelUtente.Text = "Dati utente non disponibili"
            End If

            dr.Close()

        Catch ex As Exception
            LabelUtente.Text = $"Dati utente non disponibili{Environment.NewLine}({ex.Message})"
        End Try
    End Sub

    Private Sub btnEsci_Click(sender As System.Object, e As System.EventArgs) Handles btnEsci.Click
        Me.Close()
    End Sub

    Private Sub TabVersioni_Enter(sender As Object, e As System.EventArgs) Handles TabVersioni.Enter
        With ListView1
            .BorderStyle = BorderStyle.FixedSingle
            .View = View.Details
            .FullRowSelect = True
            .GridLines = True
            'le colonne
            .Columns.Clear()
            .Columns.Add("Componente", 10, HorizontalAlignment.Left)
            .Columns.Add("Versione", 10, HorizontalAlignment.Left)
            .Columns.Add("Modificato il", 10, HorizontalAlignment.Left)
            .Columns.Add("Dimensione", 10, HorizontalAlignment.Right)
            .Columns.Add("MD5", 10, HorizontalAlignment.Left)
        End With

        ControlloComponentiInstallati()
    End Sub

    Private Sub ControlloComponentiInstallati(Optional Filtro As String = "")
        Try
            Cursor = Cursors.WaitCursor

            ListView1.Items.Clear()
            ListView1.BorderStyle = BorderStyle.None

            Dim Componenti As Integer
            Dim Dimensione As Double

            Filtro = Filtro.ToLower

            'per le estensioni previste
            For Each pattern As String In "*.exe;*.dll;*.chm;modelli\setting\*.xml".Split(";")

                Componenti = 0
                Dimensione = 0

                'per tutti i file con questo pattern
                For Each f As String In Directory.GetFiles(Utx.Globale.Paths.CartellaApp, pattern)

                    Dim fi As New FileInfo(f)
                    Dim InfoComponente As FileVersionInfo = FileVersionInfo.GetVersionInfo(f)

                    If Filtro = "" OrElse Path.GetFileName(f).ToLower.Contains(Filtro) Then
                        With ListView1.Items
                            With .Add(fi.Name)
                                .UseItemStyleForSubItems = False
                                .SubItems.Add(InfoComponente.ProductVersion).ForeColor = Color.Blue
                                .SubItems.Add(fi.LastWriteTime).ForeColor = Color.Red
                                .SubItems.Add(Format(fi.Length / 1024, "#,###,##0 KB"))
                                .SubItems.Add(Utx.NetFunc.FileToMD5(f))
                            End With
                        End With

                        Componenti += 1
                        Dimensione += fi.Length
                    End If
                Next

                With ListView1.Items
                    With .Add(String.Format("Totale componenti ({0})", Path.GetExtension(pattern)))
                        .Font = New Font(.Font.Name, .Font.Size, FontStyle.Bold)
                        .BackColor = Color.Gold
                        .SubItems.Add(Componenti)
                        .SubItems.Add("")
                        .SubItems.Add(Format(Dimensione / 1024, "#,###,##0 KB"))
                    End With
                End With
            Next

            ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)

        Catch ex As Exception
            MsgBox("Controllo componenti installati concluso con errori: " + ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles ListView1.KeyDown
        'con F5 refresh lista
        If e.KeyCode = Keys.F5 Then ControlloComponentiInstallati()
    End Sub

    Private Sub btnResetUtente_Click(sender As System.Object, e As System.EventArgs) Handles btnResetUtente.Click
        Try
            If MsgBox(String.Format("I dati utente verranno ora cancellati.{0}" +
                      "Riavviare Unitools e inserire i nuovi dati utente.{0}{0}" +
                      "Continuare?", Environment.NewLine),
                      MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question) = MsgBoxResult.Yes Then

                Utx.FunzioniDb.SvuotaTabella("ProfiloUtente")
                Me.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TabLicenza_Enter(sender As Object, e As System.EventArgs) Handles TabLicenza.Enter
        WebBrowser1.ScriptErrorsSuppressed = True
        WebBrowser1.Navigate("http://www.utools.it/unitools/doc/LicenzaAUA.htm")
    End Sub

    Private Sub btnAutoSpegnimento_Click(sender As System.Object, e As System.EventArgs) Handles btnAutoSpegnimento.Click
        Try
            If Utx.GestioneFlag.EsisteFlag(Utx.GestioneFlag.TipoFlag.CHIUSURA_FORZATA) = False Then
                If MsgBox("ATTENZIONE: Unitools sarà chiuso, entro 2 minuti, su tutte le postazioni. Continuare?",
                          MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question, Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then
                    'creo la chiave per la chiusura forzata
                    Utx.GestioneFlag.CreaFlag(Utx.GestioneFlag.TipoFlag.CHIUSURA_FORZATA)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function SessioneRDP() As Boolean
        On Error Resume Next
        Return Utx.NetFunc.GetEnvironmentVar("SESSIONNAME").StartsWith("RDP-TCP", StringComparison.InvariantCultureIgnoreCase)
    End Function

    Private Sub ButtonFiltro_Click(sender As Object, e As EventArgs) Handles ButtonFiltro.Click
        ControlloComponentiInstallati(TextBoxFiltro.Text)
    End Sub

    Private Sub TabConfigura_Enter(sender As Object, e As EventArgs) Handles TabConfigura.Enter
        Try
            Me.Cursor = Cursors.WaitCursor

            dgvConfig.DataSource = Utx.Globale.ProfiloEnteGestore.ConfigurazioneCodice

            With dgvConfig
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Agenzia").DefaultCellStyle.Font = Utx.AppFont.Bold
                .Columns("Collegata").DefaultCellStyle.Font = Utx.AppFont.Bold
                .Columns("DataFine").DefaultCellStyle.Font = Utx.AppFont.Bold
                .AutoResizeColumns()
            End With
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dgvConfig_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvConfig.CellFormatting
        If e.ColumnIndex = 9 Then
            If e.Value < Today Then
                dgvConfig.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Red
            End If
        ElseIf e.ColumnIndex > 9 Then
            If e.Value = "S" Then
                dgvConfig.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Green
                dgvConfig.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.Font = Utx.AppFont.Bold
            Else
                dgvConfig.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Red
            End If
        End If
    End Sub
End Class
