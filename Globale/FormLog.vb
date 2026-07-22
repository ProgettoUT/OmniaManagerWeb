Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms

Public Class FormLog

    Private LogGlobale As String = Path.Combine(Utx.Globale.Paths.CartellaLogs, "Globale.log")
    Private WithEvents Sessione As Utx.Sessione = Utx.Globale.SessioneCorrente
    Private WithEvents TimerSessioni As New Timers.Timer
    Private Utenze As DataTable

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.WindowState = Windows.Forms.FormWindowState.Normal
        Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        Me.Size = New Size(Utx.InfoSistema.Desktop.Larghezza * 0.4, Utx.InfoSistema.Desktop.Altezza * 0.8)
        Me.Font = AppFont.Normal
        Me.Icon = Risorse.Immagini.Icon("unitools")
        Me.Text = "Visualizzazione log"

        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False

        ImpostaControlli()

        'se il log globale supera i 500 KB lo cancella
        If File.Exists(LogGlobale) Then
            If New FileInfo(LogGlobale).Length > 500000 Then
                File.Delete(LogGlobale)
            End If
        End If

        UtTabMain.SelectedTab = TabPageLog
    End Sub

    Private Sub ImpostaControlli()
        ComboBoxLogAttivi.DataSource = Utx.ApplicationLog.LogAttivi
        ComboBoxLogAttivi.DisplayMember = "Descrizione"
        ComboBoxLogAttivi.ForeColor = Drawing.Color.Red

        With ComboBoxLivelloLog
            For k As Integer = 0 To [Enum].GetNames(GetType(Utx.ApplicationLog.Livello)).Length - 1
                .Items.Add(String.Format("{0} - Livello log {1}", k, [Enum].GetNames(GetType(Utx.ApplicationLog.Livello))(k)))
            Next
            .SelectedIndex = Utx.ApplicationLog.LivelloLog
        End With
        'aggiungo i tipi di log prendendoli dai file presenti nella cartella
        For Each f As String In Directory.GetFiles(Utx.Globale.Paths.CartellaLogs, "*.*", SearchOption.AllDirectories)
            'se già non è nell'elenco
            If ComboBoxTipiLog.Items.Contains(Path.GetFileName(f)) = False Then
                ComboBoxTipiLog.Items.Add(Path.GetFileName(f))
            End If
        Next
        ComboBoxTipiLog.Sorted = True
        ComboBoxTipiLog.SelectedIndex = 0

        ButtonApri.Text = "Apri il file"
        ButtonMergeLog.Text = "Unisci i log"
        ButtonStrumenti.Text = "Apri strumenti"
        ButtonCartellaLog.Text = "Cartella log utente"
        ButtonApriLogGlobale.Text = "Apri log globale"
        ButtonClear.Text = "Pulisci tutto"
        ButtonInvitoChiusura.Text = "Invia richiesta chiusura agli altri Pc"
        CheckBoxSincronizza.Checked = False

        With ListViewSessioni
            .BorderStyle = BorderStyle.FixedSingle
            .View = View.Details
            .FullRowSelect = True
            .GridLines = True
            .LabelEdit = False
            .MultiSelect = False
            .Sorting = SortOrder.None
            'crea le colonne ripilogo filtro e i riferimento per il ridimensionamento
            .Columns.Add("Sessione", 150, HorizontalAlignment.Left)
            .Columns.Add("Nome", 150, HorizontalAlignment.Left)
            .Columns.Add("Inizio", 150, HorizontalAlignment.Left)
            .Columns.Add("Ping", 150, HorizontalAlignment.Left)
        End With
    End Sub

    Private Sub FormLog_FormClosed(sender As Object, e As Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        TimerSessioni.Dispose()
    End Sub

    Private Sub FormLog_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        UtTabMain.ColorStyle = UtTabControl.TabColorStyle.ORANGE
        Me.Refresh()
        CheckBoxSincronizza.Checked = True
        TimerSessioni.Interval = 5000
    End Sub

    Private mSeguiFlusso As Boolean
    Public Property SeguiFlusso() As Boolean
        Get
            Return mSeguiFlusso
        End Get
        Set(value As Boolean)
            mSeguiFlusso = value
        End Set
    End Property

    Private mFiltro As Boolean
    Public Property Filtro() As Boolean
        Get
            Return mFiltro
        End Get
        Set(value As Boolean)
            mFiltro = value
        End Set
    End Property

    Public Sub AddLog(Testo As String)
        On Error Resume Next
        If Filtro = True Then
            If Testo.ToUpper.Contains(TextBoxFiltro.Text.Trim.ToUpper) Then
                ListBoxLog.Items.Add(Testo)
                File.AppendAllText(LogGlobale, Testo)
                If mSeguiFlusso = True Then SelezionaUltimaRiga()
            End If
        Else
            ListBoxLog.Items.Add(Testo)
            File.AppendAllText(LogGlobale, Testo)
            If mSeguiFlusso = True Then SelezionaUltimaRiga()
        End If
    End Sub

    Public Sub SelezionaUltimaRiga()
        ListBoxLog.SelectedIndex = ListBoxLog.Items.Count - 1
    End Sub

    Public Sub AggiornaListaLogAttivi()
        ComboBoxLogAttivi.DataSource = Nothing
        ComboBoxLogAttivi.DataSource = Utx.ApplicationLog.LogAttivi
        ComboBoxLogAttivi.DisplayMember = "Descrizione"
    End Sub

    Private Sub CheckBoxSincronizza_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSincronizza.CheckedChanged
        mSeguiFlusso = CheckBoxSincronizza.Checked
        If mSeguiFlusso = True Then SelezionaUltimaRiga()
    End Sub

    Private Sub ButtonApri_Click(sender As Object, e As EventArgs) Handles ButtonApri.Click
        On Error Resume Next
        Process.Start(ComboBoxLogAttivi.SelectedItem.LogFile)
    End Sub

    Private Sub ButtonApriLogGlobale_Click(sender As Object, e As EventArgs) Handles ButtonApriLogGlobale.Click
        On Error Resume Next
        Process.Start(LogGlobale)
    End Sub

    Private Sub ButtonCartellaLog_Click(sender As Object, e As EventArgs) Handles ButtonCartellaLog.Click
        On Error Resume Next
        Process.Start(Path.Combine(Utx.Globale.Paths.CartellaLogs, Environment.UserName))
    End Sub

    Private Sub ButtonMergeLog_Click(sender As Object, e As EventArgs) Handles ButtonMergeLog.Click
        Try
            Dim Log As String = Path.Combine(Utx.Globale.Paths.CartellaLogs, "Merge.log")
            File.Delete(Log)

            Dim Inizio As Date
            Dim temp As String = InputBox("Unisci log a partire dal", "Unisci log", Today)

            If String.IsNullOrEmpty(temp) Then
                Exit Sub
            ElseIf IsDate(temp) Then
                Inizio = temp
            Else
                Inizio = Today
            End If

            Using sw As New StreamWriter(Log)
                sw.WriteLine(String.Format("Data inizio: {0:d}", Inizio))
                sw.WriteLine()

                For Each f As String In Directory.GetFiles(Utx.Globale.Paths.CartellaLogs, ComboBoxTipiLog.Text, SearchOption.AllDirectories)
                    sw.WriteLine(f)
                    sw.WriteLine()

                    Dim Utente As String = Directory.GetParent(f).Name

                    Using sr As New StreamReader(f)
                        Do While sr.EndOfStream = False

                            Dim Riga As String = sr.ReadLine
                            Dim DataLog As String = Mid(Riga, 2, 10)

                            If IsDate(DataLog) AndAlso DataLog >= Inizio Then
                                sw.WriteLine(Utente + " > " + sr.ReadLine)
                            End If
                        Loop
                    End Using

                    sw.WriteLine(StrDup(80, "=" + Environment.NewLine))
                    sw.WriteLine()
                Next
            End Using

            Process.Start(Log)

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub UtTabMain_Selected(sender As Object, e As Windows.Forms.TabControlEventArgs) Handles UtTabMain.Selected
        Select Case e.TabPage.Name
            Case "TabPageBlocchi"
                LeggiUtenze()
                LeggiBlocchi()
                LeggiSessioni()
                TimerSessioni.Enabled = True
            Case Else
                TimerSessioni.Enabled = False
        End Select
    End Sub

    Private Sub LeggiBlocchi()
        Try
            ListBoxBlocchi.Items.Clear()

            If Utx.Globale.SessioneCorrente.Blocchi.Count = 0 Then
                ListBoxBlocchi.Items.Add("Non ci sono blocchi attivi")
            Else
                For Each b As Utx.Sessione.Blocco In Utx.Globale.SessioneCorrente.Blocchi
                    ListBoxBlocchi.Items.Add(b)
                Next
                ListBoxBlocchi.DisplayMember = "DescrizioneEstesa"
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub LeggiSessioni()
        Try
            TimerSessioni.Enabled = False

            ListViewSessioni.Items.Clear()

            For Each kvp As KeyValuePair(Of String, String) In Utx.Globale.SessioneCorrente.SettingSessioni.Impostazioni
                'se il ping della sessione è attivo
                If DateDiff(DateInterval.Minute, CDate(kvp.Value.Split("|")(1)), Now) < 3 Then
                    'cerco il nome dell'utente
                    Dim NomeUtente As String = ""

                    For Each row As DataRow In Utenze.Rows
                        If row("Utenza") = kvp.Key Then
                            NomeUtente = row("Nome")
                            Exit For
                        End If
                    Next

                    With ListViewSessioni.Items.Add(kvp.Key)
                        .SubItems.Add(NomeUtente)
                        .SubItems.Add(CDate(kvp.Value.Split("|")(0)))
                        .SubItems.Add(CDate(kvp.Value.Split("|")(1)))
                    End With
                End If
            Next
            ListViewSessioni.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)

            TimerSessioni.Enabled = True

        Catch ex As Exception
            ListViewSessioni.Items.Add(ex.Message)
        End Try
    End Sub

    Private Sub Sessione_ModificaBlocchi() Handles Sessione.ModificaBlocchi
        LeggiBlocchi()
    End Sub

    Private Sub TimerSessioni_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles TimerSessioni.Elapsed
        LeggiSessioni()
    End Sub

    Private Sub LeggiUtenze()
        If Utenze Is Nothing Then
            Utenze = Utx.Utente.LeggiUtenze
        End If
    End Sub

    Private Sub ButtonInvitoChiusura_Click(sender As Object, e As EventArgs) Handles ButtonInvitoChiusura.Click
        ''crea una richiesta aglia altri pc di chiudere il programma
        'If MsgBox("Confermate la richiesta di chiusura del programma per gli altri utenti?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then
        '    Dim Invito As New Utx.Sessione.InvitoAllaChiusura()
        '    If Invito.Esiste = False Then
        '        Utx.Sessione.InvitoAllaChiusura.Crea()
        '        MsgBox("Richiesta di chiusura creata correttamente.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
        '    Else
        '        MsgBox("E' già presente un'altra richiesta di chiusura.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
        '    End If
        'End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxFiltro.TextChanged
        Filtro = TextBoxFiltro.Text.Trim.Length > 0
    End Sub

    Private Sub ComboBoxLivelloLog_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxLivelloLog.SelectedIndexChanged
        Utx.ApplicationLog.LivelloLog = ComboBoxLivelloLog.SelectedIndex
    End Sub

    Private Sub ButtonStrumenti_Click(sender As Object, e As EventArgs) Handles ButtonStrumenti.Click
        Utx.Eventi.Strumenti()
    End Sub

    Private Sub ButtonClear_Click(sender As Object, e As EventArgs) Handles ButtonClear.Click
        ListBoxLog.Items.Clear()
    End Sub

    Private Sub CheckBoxPrimoPiano_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxPrimoPiano.CheckedChanged
        Me.TopMost = CheckBoxPrimoPiano.Checked
    End Sub

    Private Sub ListBoxLog_DoubleClick(sender As Object, e As EventArgs) Handles ListBoxLog.DoubleClick
        Dim NomeLog As String = ListBoxLog.SelectedItem.ToString.Split(">>")(0).Trim
        Dim FullPathLog As String = ""
        If File.Exists(Path.Combine(Utx.Globale.Paths.CartellaLogs, NomeLog)) Then
            FullPathLog = Path.Combine(Utx.Globale.Paths.CartellaLogs, NomeLog)
        Else
            FullPathLog = Path.Combine(Utx.Globale.Paths.CartellaLogs, Environment.UserName, NomeLog)
        End If
        Process.Start(FullPathLog)
    End Sub
End Class