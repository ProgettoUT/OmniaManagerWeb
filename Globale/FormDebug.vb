Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.Office.Interop.Excel
Imports System.Data

Public Class FormDebug

    Friend WithEvents FormFiltro As New Utx.FormGestioneFiltro(1000)

    Sub New(Optional ByRef Dati As Object = Nothing)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()
        Me.WindowState = FormWindowState.Maximized
        Me.Font = Utx.AppFont.Normal

        With dgvDebug
            .AllowUserToAddRows = False
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
        Utx.NetFunc.DoppioBuffer(dgvDebug)

        If Dati IsNot Nothing Then
            Me.OrigineDati = Dati
        End If
    End Sub

    Private mOrigine As Object
    Public Property OrigineDati() As Object
        Get
            Return mOrigine
        End Get
        Set(value As Object)
            mOrigine = value
            Me.Text = String.Format("Debug tabella: {0}", value.ToString)
        End Set
    End Property

    Public Property Messaggio() As String
        Get
            Return LabelMessaggio.Text
        End Get
        Set(value As String)
            LabelMessaggio.Text = value.Trim
        End Set
    End Property

    Private Sub FormDebug_Load(sender As Object, e As EventArgs) Handles Me.Load
        On Error Resume Next
        Using s As New Utx.SettingOMW.GestioneSetting
            s.Proxy = Utx.Globale.UniProxy.Proxy
            ButtonLiveUp.Text = String.Format("Aggiornamento data LiveUp{0}(attuale: {1})", Environment.NewLine, s.DataLiveUp(Utx.Globale.Token))
        End Using
    End Sub

    Private Sub FormDebug_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Cursor = Cursors.WaitCursor
        With dgvDebug
            .DataSource = mOrigine
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            .AllowUserToOrderColumns = False
        End With
        Utx.NetFunc.BloccaOrdinamento(dgvDebug)

        LabelRecord.Text = dgvDebug.Rows.Count
        Cursor = DefaultCursor
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        Me.Close()
    End Sub

    Private Sub ButtonCsv_Click(sender As Object, e As EventArgs) Handles ButtonCsv.Click
        Utx.NetFunc.Esporta2Csv(dgvDebug, "Esportazione", Color.Khaki)
    End Sub

    Public Sub VisualizzaFiltro(IndiceColonna As Integer, Optional Centra As Boolean = False)
        Try
            If (dgvDebug.DataSource IsNot Nothing) Then
                'cartella per salvataggio filtro
                With FormFiltro
                    .AppName = "Debug"
                    .FilterFolder = Utx.Globale.Paths.CartellaSettingRete
                    .TabVisibili(True, False)

                    'visualizzo la finestra del filtro
                    .Visualizza(dgvDebug.Columns(IndiceColonna), Centra)
                End With
            End If
            LabelRecord.Text = dgvDebug.Rows.Count
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
        End Try
    End Sub

    Private Sub DataGridView1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvDebug.ColumnHeaderMouseClick
        VisualizzaFiltro(e.ColumnIndex)
    End Sub

    Private Sub ButtonSIA_Click(sender As Object, e As EventArgs) Handles ButtonSIA.Click
        Try
            Do While True
                Dim Codice As String = InputBox("Codice agenzia", DefaultResponse:="00000")
                If String.IsNullOrEmpty(Codice) OrElse (Codice = "00000") Then
                    Exit Sub
                End If

                If Codice.Length = 5 Then
                    'file inviati a sia
                    Dim Dal As String = InputBox("A partire dal", DefaultResponse:=Utx.FunzioniData.InizioMese(Today).AddMonths(-1))

                    If IsDate(Dal) Then
                        Dim Lista() As String = Utx.SIA.ListaFileInviati(Codice, Dal, Today, Utx.SIA.TipoFiltro.INIZIA, "MA")
                        Dim ER() As String = Utx.SIA.ListaFileInviati(Codice, Dal, Today, Utx.SIA.TipoFiltro.CONTIENE, "Essig_Reti")
                        Dim dt As New System.Data.DataTable
                        dt.Columns.Add("File", System.Type.GetType("System.String"))
                        dt.Columns.Add("Data", System.Type.GetType("System.DateTime"))
                        For Each s As String In Lista
                            dt.Rows.Add({s, New DateTime(s.Substring(8, 2) + 2000, s.Substring(10, 2), s.Substring(12, 2))})
                        Next
                        For Each s As String In ER
                            dt.Rows.Add({s, New DateTime(s.Substring(17, 2) + 2000, s.Substring(19, 2), s.Substring(21, 2))})
                        Next
                        LabelRecord.Text = dt.Rows.Count
                        dgvDebug.DataSource = dt

                        For Each row As DataGridViewRow In dgvDebug.Rows
                            If row.Cells(0).Value.ToString.Contains("Essig_Reti") Then
                                row.DefaultCellStyle.BackColor = Color.Moccasin
                            ElseIf row.Cells(0).Value.ToString.Contains("UAP") OrElse
                                   row.Cells(0).Value.ToString.Contains("UB") OrElse
                                   row.Cells(0).Value.ToString.Contains("UT") Then
                                row.DefaultCellStyle.BackColor = Color.PaleGreen
                            End If
                        Next
                    End If
                End If
            Loop
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
        End Try
    End Sub

    Private Sub ButtonMA2SIA_Click(sender As Object, e As EventArgs) Handles ButtonMA2SIA.Click
        Dim Codice As String = InputBox("Codice agenzia", DefaultResponse:="00000")
        If String.IsNullOrEmpty(Codice) OrElse (Val(Codice) = 0) OrElse (Codice.Length <> 5) Then
            MsgBox("Codice agenzia non valido", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
            Exit Sub
        End If
        Dim Sede As String = InputBox("Località agenzia", DefaultResponse:="")
        If String.IsNullOrEmpty(Sede) Then
            MsgBox("Inserire la località", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
            Exit Sub
        End If
        Dim Inizio As Date = InputBox("Data di inzio invio", DefaultResponse:=Today)
        If IsDate(Inizio) = False Then
            MsgBox("Data non valida", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
            Exit Sub
        End If

        Using s As New Utx.SettingAgenzia.ConfiguraSede
            MsgBox(s.AbilitaSwitchMA(Codice, Inizio, #12/31/2100#, Sede.ToUpper))
        End Using
    End Sub

    Private Sub ButtonAttivaExtra_Click(sender As Object, e As EventArgs) Handles ButtonAttivaExtra.Click
        'menuextra attiva / disattiva
        Do While True
            Dim Codice As String = InputBox("agenzia", DefaultResponse:="00000")
            If String.IsNullOrEmpty(Codice) OrElse (Codice = "00000") Then
                Exit Do
            End If

            If Codice.Length = 5 Then
                Using s As New Utx.SettingAgenzia.ConfiguraSede
                    MsgBox(s.AbilitaMenuExtra(Codice, "00", "TUTTI"))
                End Using
            Else
                MsgBox("codice non valido")
            End If
        Loop
    End Sub

    Private Sub ButtonCancellaExtra_Click(sender As Object, e As EventArgs) Handles ButtonCancellaExtra.Click
        'menuextra attiva / disattiva
        Do While True
            Dim Codice As String = InputBox("Cancella extra agenzia", DefaultResponse:="00000")
            If String.IsNullOrEmpty(Codice) OrElse (Codice = "00000") Then
                Exit Do
            End If

            If Codice.Length = 5 Then
                Using s As New Utx.SettingAgenzia.ConfiguraSede
                    MsgBox(s.CancellaMenuExtra(Codice, "00", "TUTTI"))
                End Using
            Else
                MsgBox("codice non valido")
            End If
        Loop
    End Sub

    Private Sub ButtonSetting_Click(sender As Object, e As EventArgs) Handles ButtonSetting.Click
        Dim cd As New OpenFileDialog

        With cd
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            .Filter = "File xml (*.xml)|*.xml"
        End With

        Dim Scelta As DialogResult = cd.ShowDialog

        If Scelta = DialogResult.OK Then
            'lettura setting di agenzia
            dgvDebug.DataSource = Utx.Utente.ListaUtenzePassword(cd.FileName)
            dgvDebug.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        End If
    End Sub

    Private Sub ButtonConsolidaMA_Click(sender As Object, e As EventArgs) Handles ButtonConsolidaMA.Click
        Try
            Cursor = Cursors.WaitCursor

            'RECUPERA L'ULTIMO DB IN FORMATO MDB TRASMESSO DALL'AGENZIA E LO CONSOLIDA NUOVAMENTE
            Dim Agenzia As String = InputBox("Codice agenzia", "Consolida ultimo MA", "").PadLeft(5, "0")
            If String.IsNullOrEmpty(Agenzia) OrElse Agenzia = "00000" Then
                Exit Sub
            End If

            Dim Backup As String = InputBox("Backup", "formato dd-MM")
            Dim Query As String = ""

            ' Query As String =
            '    $"--arretro MA
            '    DELETE
            '    FROM MA{Agenzia}.dbo.Sinistri
            '    WHERE dataelaborazione > '30/01/2026'
            '    --arretro sinistriDP
            '    DELETE FROM DB{Agenzia}.dbo.SinistriDP
            '    WHERE AnnoMeseCompetenza > '30/01/2026'
            '    --aggiorno calendario
            '    UPDATE C
            '    SET UltimoAggiornamento='30/01/2026',Consolida='31/12/2025'
            '    FROM DB{Agenzia}.dbo.CalendarioOmnia C
            '    WHERE TipoFile='05'"
            ' Query As String =
            '    $"--aggiorno calendario
            '    UPDATE C
            '    SET UltimoAggiornamento='30/01/2026'
            '    FROM DB{Agenzia}.dbo.CalendarioOmnia C
            '    WHERE TipoFile='05'"

            Using s As New Utx.ServiziOMW.ServizioDatiOMW
                'importa tutti i file in coda nella cartella ArriviMA sul server indipendentemente dal codice agenzia
                MsgBox(s.ConsolidaDbUnoAgenzia(Agenzia, Backup, Query, Utx.Globale.Token), MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            End Using

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ButtonMaxOnLine_Click(sender As Object, e As EventArgs) Handles ButtonMaxOnLine.Click
        Try
            Dim Operazione As Integer = InputBox("Tipo operazione on-line", "Tipo", 1)
            Dim MaxUtenti As Integer = InputBox("Utenti on-line", "Max utenti", 10)
            Using s As New Utx.SettingAgenzia.ConfiguraSede
                MsgBox(s.UpdateMaxUtenti(Operazione, MaxUtenti))
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonCreaDbNote_Click(sender As Object, e As EventArgs) Handles ButtonCreaDbNote.Click
        Do While True
            Dim Codice As String = InputBox("Crea Db note", DefaultResponse:="00000")
            If String.IsNullOrEmpty(Codice) OrElse (Codice = "00000") Then
                Exit Do
            End If

            If Codice.Length = 5 Then
                Using s As New Utx.ServiziOMW.ServizioDatiOMW
                    s.Proxy = Utx.Globale.UniProxy.Proxy
                    MsgBox(s.CreaDatabaseVuoto(Codice, Utx.Globale.Token))
                End Using
            Else
                MsgBox("codice non valido")
            End If
        Loop
    End Sub

    Private Sub ButtonConsolidaDB_Click(sender As Object, e As EventArgs) Handles ButtonConsolidaDB.Click
        'FORZA CONSOLIDAMENTO DATI SUL SERVER
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim Codice As String = InputBox("Codice agenzia da consolidare (5 caratteri)")
            If String.IsNullOrEmpty(Codice) Then
                Exit Sub
            End If

            If IsNumeric(Codice) And Codice.Length = 5 Then
                Using s As New Utx.EventiOMW.GeneraEventi
                    s.GeneraEvento(Codice, "FORZATURA_CONSOLIDA_DB", "", Utx.Globale.Token)
                End Using
                MsgBox("Fatto.", MsgBoxStyle.Information)
            Else
                MsgBox("Codice non valido", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ButtonAggiornamentoSinistri_Click(sender As Object, e As EventArgs) Handles ButtonAggiornamentoSinistri.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim dt As System.Data.DataTable = Utx.WsCommand.ExecuteNonQuery("SELECT name,state 
            FROM SYS.databases 
            WHERE name LIKE 'MA[0-9][0-9][0-9][0-9][0-9]'
            EXCEPT 
            SELECT 'MA00000',0
            ORDER BY name", "00000").DataTable

            dt.Columns.Add("rec91", System.Type.GetType("System.DateTime"))
            dt.Columns.Add("rec92", System.Type.GetType("System.DateTime"))
            For Each row As DataRow In dt.Rows
                If row("state") = 0 AndAlso row("name") <> "MA00000" Then 'state=0 > db online
                    Dim agenzia As String = row("name").ToString.Substring(2, 5)
                    Dim query As String = String.Format("declare @settimanale as date,@mensile as date
                         SET @settimanale = (SELECT MAX(dataestrazione) FROM [{0}].dbo.arp002_file WHERE codtiporecord = '91')
                         SET @mensile = (SELECT MAX(dataestrazione) FROM [{0}].dbo.arp002_file WHERE codtiporecord = '92')
                         SELECT format(@settimanale,'dd/MM/yyyy' ) + '-' + format(@mensile,'dd/MM/yyyy' )", row("name"))
                    Dim Risultato As Object = Utx.WsCommand.ExecuteScalar(query, agenzia).Valore

                    If Risultato IsNot DBNull.Value Then
                        row("rec91") = Risultato.Split("-")(0)
                        row("rec92") = Risultato.Split("-")(1)
                    End If
                End If
            Next
            dgvDebug.DataSource = dt

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ButtonLiveUp_Click(sender As Object, e As EventArgs) Handles ButtonLiveUp.Click
        Using s As New Utx.SettingOMW.GestioneSetting
            s.Proxy = Utx.Globale.UniProxy.Proxy
            s.AggiornaDataLiveUp(Utx.Globale.Token)
            ButtonLiveUp.Text = String.Format("Aggiornamento data LiveUp{0}(attuale: {1})", Environment.NewLine, s.DataLiveUp(Utx.Globale.Token))
        End Using
    End Sub

    Private Sub ButtonCreaDb_Click(sender As Object, e As EventArgs) Handles ButtonCreaDb.Click
        Try
            Dim Codice As String = InputBox("Codice agenzia", DefaultResponse:="00000")
            Codice = Microsoft.VisualBasic.Right("00000" + Codice, 5)
            If String.IsNullOrEmpty(Codice) OrElse (Codice = "00000") Then
                Exit Sub
            End If

            If MsgBox(String.Format("Confermate la creazione dei database (DB e MA) per il codice {0}?", Codice), MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then
                Using s As New Utx.ServiziOMW.ServizioDatiOMW
                    MsgBox(s.CreaDatabaseAgenzia(Codice, Utx.Globale.Token), MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                End Using
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonPostalizzazione_Click(sender As Object, e As EventArgs) Handles ButtonPostalizzazione.Click
        Try
            Dim Codice As String = InputBox("Codice agenzia", DefaultResponse:="00000")
            Codice = Microsoft.VisualBasic.Right("00000" + Codice, 5)
            If String.IsNullOrEmpty(Codice) OrElse (Codice = "00000") Then
                Exit Sub
            End If

            Using s As New Utx.SettingAgenzia.ConfiguraSede
                If s.EliminaBloccoPostalizzazione(Codice) = True Then
                    MsgBox("Blocco eliminato", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Else
                    MsgBox("Eliminazione non riuscita", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                End If
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub
End Class