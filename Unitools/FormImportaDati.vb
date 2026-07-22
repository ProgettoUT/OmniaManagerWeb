Imports System.ComponentModel
Imports System.Collections

Public Class FormImportaDati

    Private ReadOnly Log As New Utx.ApplicationLog("MergeDati.log", Descrizione:="Consolidamento dati")
    Private ReadOnly FigliaOmnia As Utx.AgenziaFigliaOmnia
    Private WithEvents bw As New BackgroundWorker

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(550, 450)
        Me.Font = Utx.AppFont.Normal
        Me.SizeGripStyle = Windows.Forms.SizeGripStyle.Hide
        Me.Icon = Risorse.Immagini.Icon("importa")
        Me.Text = "Importazioni e forzature " + Utx.Globale.AgenziaRichiesta.CodiceAgenzia

        ImpostaControlli()

        FigliaOmnia = New Utx.AgenziaFigliaOmnia(Utx.Globale.AgenziaRichiesta.CodiceAgenzia,
                                                Utx.Globale.ProfiloEnteGestore.CodiceSede,
                                                False)
    End Sub

    Private Sub ImpostaControlli()
        TabPageImporta.Text = "Importa dati"
        With LabelInfoOmnia
            .Dock = DockStyle.Fill
            .Margin = New Padding(0)
            .Padding = New Padding(0)
            .Font = Utx.AppFont.Normal()
            .Text = ""
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        With LabelInfoDL
            .Dock = DockStyle.Fill
            .Margin = New Padding(0)
            .Padding = New Padding(0)
            .Font = Utx.AppFont.Normal()
            .Text = ""
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        With LabelMessaggio
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = Color.Lavender
            .Text = ""
        End With
        With ButtonAggiornaCalendario
            .FlatAppearance.MouseOverBackColor = Color.PaleGreen
            .Text = "Aggiorna calendario"
        End With
        With ButtonEsci
            .FlatAppearance.MouseOverBackColor = Color.LightSalmon
            .Text = "Esci"
        End With
        With ListViewCalendario
            .BorderStyle = BorderStyle.FixedSingle
            .Font = New Font("Courier New", 9)
            .View = View.Details
            .FullRowSelect = True
            .GridLines = True
            .LabelEdit = False
            'crea le colonne ripilogo filtro e i riferimento per il ridimensionamento
            .Columns.Add("Archivio/Dati", 150, HorizontalAlignment.Left)
            .Columns.Add("Record", 80, HorizontalAlignment.Right)
            .Columns.Add("Aggiornamento", .Width - .Columns(0).Width - .Columns(1).Width - 80)
        End With
        'forzature omnia
        LabelForzaturaOmnia.Text = "Forza lettura dati da flusso di direzione"
        dtpForzaturaOmniaDal.Format = DateTimePickerFormat.Short
        dtpForzaturaOmniaDal.Value = Today
        With dtpDataDaDbuno
            .MaxDate = Today
            .Value = Today
        End With
        With ComboBoxTipoRecord
            .Dock = DockStyle.Fill
            .DropDownStyle = ComboBoxStyle.DropDownList
            .FlatStyle = FlatStyle.Standard
            .Items.Add(New TipoRecordOmnia("TUTTI", "TUTTI i tipi"))
            For Each kvp As KeyValuePair(Of String, String) In UniFeed.FileIntoDatabase.GruppiTipiRecord()
                .Items.Add(New TipoRecordOmnia(kvp.Key, kvp.Value))
            Next
            .DisplayMember = "Descrizione"
            .SelectedIndex = 0
        End With
        With ComboBoxAgenzia
            .Dock = DockStyle.Fill
            .DropDownStyle = ComboBoxStyle.DropDownList
            .FlatStyle = FlatStyle.Standard
            .Items.Add("TUTTI i codici")
            For Each a As String In Utx.EnteGestore.CodiciGestiti
                .Items.Add(a)
            Next
            .SelectedIndex = 0
        End With
        With ComboBoxAgenziaCumulo
            .Dock = DockStyle.Fill
            .DropDownStyle = ComboBoxStyle.DropDownList
            .FlatStyle = FlatStyle.Standard
            .Items.Add("TUTTI i codici")
            For Each a As String In Utx.EnteGestore.CodiciGestiti
                .Items.Add(a)
            Next
            .SelectedIndex = 0
        End With
        ButtonForzaturaOmnia.Text = "Avvia"
        With ComboBoxArchivioOmnia
            .Dock = DockStyle.Fill
            .DropDownStyle = ComboBoxStyle.DropDownList
            .FlatStyle = FlatStyle.Standard
            .Items.Add(New Utx.ArchivioUt(Utx.Enumerazioni.TipoFileMagia.NonCatalogato, "Tutto"))
            .Items.Add(New Utx.ArchivioUt(Utx.Enumerazioni.TipoFileMagia.Anag, "Clienti"))
            .Items.Add(New Utx.ArchivioUt(Utx.Enumerazioni.TipoFileMagia.AnagNew, "Clienti new"))
            .Items.Add(New Utx.ArchivioUt(Utx.Enumerazioni.TipoFileMagia.Polizze, "Polizze"))
            .Items.Add(New Utx.ArchivioUt(Utx.Enumerazioni.TipoFileMagia.Sinistri, "Sinistri"))
            .Items.Add(New Utx.ArchivioUt(Utx.Enumerazioni.TipoFileMagia.Titoli, "Titoli"))
            .Items.Add(New Utx.ArchivioUt(Utx.Enumerazioni.TipoFileMagia.PrimaNota, "Prima nota"))
            .DisplayMember = "Descrizione"
            .SelectedIndex = 0
        End With
        LabelForzaturaDbUno.Text = "Forza rilettura dati da Db di primo livello"
        ButtonForzaturaDbuno.Text = "Avvia"
        'forzature da download agenzie
        LabelForzaturaDL.Text = "Archivio di cui effettuare la rilettura"
        LabelDataForzaturaDL.Text = "Selezionare la data da cui avviare la rilettura"
        dtpForzaturaDL.Format = DateTimePickerFormat.Short
        dtpForzaturaDL.Value = Today
        ButtonForzaturaDL.Text = "Avvia"
        With ComboBoxArchivioDL
            .Dock = DockStyle.Fill
            .DropDownStyle = ComboBoxStyle.DropDownList
            .FlatStyle = FlatStyle.Standard
            .Items.Add(New Utx.ArchivioUt(Utx.Enumerazioni.TipoFileMagia.MonitorQT, "Monitor QT"))
            .Items.Add(New Utx.ArchivioUt(Utx.Enumerazioni.TipoFileMagia.PrimaNota, "Prima nota"))
            .Items.Add(New Utx.ArchivioUt(Utx.Enumerazioni.TipoFileDoc.QUIETANZAMENTO, "Liste QT"))
            .Items.Add(New Utx.ArchivioUt(Utx.Enumerazioni.TipoFileDoc.BUSTE, "BUSTE per adempimenti"))
            .DisplayMember = "Descrizione"
            .SelectedIndex = 0
        End With
        With LabelCumulo
            .Dock = DockStyle.Fill
            .Margin = New Padding(0)
            .Padding = New Padding(0)
            .Font = Utx.AppFont.Normal()
            .Text = "Rigenera file di riepilogo per i dati (MC)"
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        With ComboBoxTipoCumulo
            .Dock = DockStyle.Fill
            .DropDownStyle = ComboBoxStyle.DropDownList
            .FlatStyle = FlatStyle.Standard
            For k As Integer = 0 To [Enum].GetNames(GetType(UniFeed.Cumulatore.FileCumulo.TipoCumulo)).Length - 1
                .Items.Add(New UniFeed.Cumulatore.FileCumulo(k))
            Next
            .DisplayMember = "Descrizione"
            .SelectedIndex = 0
        End With
        With LabelImportaCumulo
            .Dock = DockStyle.Fill
            .Margin = New Padding(0)
            .Padding = New Padding(0)
            .Font = Utx.AppFont.Normal()
            .Text = "Importa da file di riepilogo per i dati (MC)"
            .TextAlign = ContentAlignment.MiddleLeft
        End With
    End Sub

    Private Sub FormImportaDati_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If ButtonEsci.Enabled = False Then
            e.Cancel = True
        End If
        If bw IsNot Nothing Then Do While bw.IsBusy : Application.DoEvents() : Loop
    End Sub

    Private Sub FormImportaDati_Load(sender As Object, e As EventArgs) Handles Me.Load
        ControlloNuoviDati()
    End Sub

    Private Sub FormImportaDati_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        On Error Resume Next
        With ListViewCalendario
            .Columns(2).Width = .Width - .Columns(0).Width - .Columns(1).Width - 10
        End With
    End Sub

    Private Sub FormImportaDati_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        TabMain.ItemSize = New Size(200, 25)
        TabMain.ColorStyle = Utx.UtTabControl.TabColorStyle.GOLD
        Me.Refresh()
    End Sub

    Private Sub StatoAggiornamenti()
        On Error Resume Next

        Cursor = Cursors.WaitCursor
        'ButtonImporta.Enabled = False
        ButtonEsci.Enabled = False
        LabelMessaggio.Text = "Aggiornamento calendario..."

        'visualizza lo stato di aggiornamento degli archivi
        ListViewCalendario.Items.Clear()
        ListViewCalendario.Refresh()

        Dim NumeroRecord As Long, Desk As String

        'clienti
        Desk = AggiornamentoArchivi(Utx.Enumerazioni.TipoFileMagia.AnagNew, NumeroRecord)
        With ListViewCalendario.Items.Add("Clienti")
            .SubItems.Add(Format(NumeroRecord, "#,###,##0"))
            .SubItems.Add(Desk)
        End With
        ListViewCalendario.Refresh()
        'polizze
        Desk = AggiornamentoArchivi(Utx.Enumerazioni.TipoFileMagia.Polizze, NumeroRecord)
        With ListViewCalendario.Items.Add("Polizze")
            .SubItems.Add(Format(NumeroRecord, "#,###,##0"))
            .SubItems.Add(Desk)
        End With
        ListViewCalendario.Refresh()
        'Incassi
        Desk = AggiornamentoArchivi(Utx.Enumerazioni.TipoFileMagia.Incassi, NumeroRecord)
        With ListViewCalendario.Items.Add("Incassi")
            .SubItems.Add(Format(NumeroRecord, "#,###,##0"))
            .SubItems.Add(Desk)
        End With
        ListViewCalendario.Refresh()
        'sinistri
        Desk = AggiornamentoArchivi(Utx.Enumerazioni.TipoFileMagia.Sinistri, NumeroRecord)
        With ListViewCalendario.Items.Add("Sinistri")
            .SubItems.Add(Format(NumeroRecord, "#,###,##0"))
            .SubItems.Add(Desk)
        End With
        ListViewCalendario.Refresh()
        'titoli
        Desk = AggiornamentoArchivi(Utx.Enumerazioni.TipoFileMagia.Titoli, NumeroRecord)
        With ListViewCalendario.Items.Add("Titoli")
            .SubItems.Add(Format(NumeroRecord, "#,###,##0"))
            .SubItems.Add(Desk)
        End With
        ListViewCalendario.Refresh()
        'monitor qt
        Desk = AggiornamentoArchivi(Utx.Enumerazioni.TipoFileMagia.MonitorQT, NumeroRecord)
        With ListViewCalendario.Items.Add("Monitor QT")
            .SubItems.Add(Format(NumeroRecord, "#,###,##0"))
            .SubItems.Add(Desk)
        End With
        ListViewCalendario.Refresh()
        'Movimenti PTF
        Desk = AggiornamentoArchivi(Utx.Enumerazioni.TipoFileMagia.MovimentiPTF, NumeroRecord)
        With ListViewCalendario.Items.Add("Movimenti PTF")
            .SubItems.Add(Format(NumeroRecord, "#,###,##0"))
            .SubItems.Add(Desk)
        End With
        ListViewCalendario.Refresh()
        'arretrati
        With ListViewCalendario.Items.Add("Arretrati")
            .SubItems.Add(Format(Utx.FunzioniDb.ExecuteScalar("SELECT Count(*) FROM Arretrati"), "#,###,##0"))
            .SubItems.Add(String.Format("Al {0} (fino al {1:d})",
                                        Utx.Globale.SettingInterop.LeggiValore(Utx.GestioneFlag.TipoFlag.AGGIORNAMENTO_ARRETRATI, "01/01/2000"),
                                        Utx.FunzioniDb.ExecuteScalar("SELECT Max(EffettoTitolo) FROM Arretrati"), #1/1/2000#))
        End With
        ListViewCalendario.Refresh()
        'liste qt
        Desk = AggiornamentoListe(Utx.Enumerazioni.TipoFileDoc.QUIETANZAMENTO, NumeroRecord)
        With ListViewCalendario.Items.Add("Liste QT")
            .SubItems.Add(Format(NumeroRecord, "#,###,##0"))
            .SubItems.Add(Desk)
        End With
        ListViewCalendario.Refresh()
        'flex
        Desk = AggiornamentoListe(Utx.Enumerazioni.TipoFileDoc.FLEX, NumeroRecord)
        With ListViewCalendario.Items.Add("Elenco flex")
            .SubItems.Add(Format(NumeroRecord, "#,###,##0"))
            .SubItems.Add(Desk)
        End With
        ListViewCalendario.Refresh()
        'invio doc
        Desk = AggiornamentoListe(Utx.Enumerazioni.TipoFileDoc.BUSTE, NumeroRecord)
        With ListViewCalendario.Items.Add("Invio documenti")
            .SubItems.Add(Format(NumeroRecord, "#,###,##0"))
            .SubItems.Add(Desk)
        End With
        ListViewCalendario.ListViewItemSorter = New ListViewItemComparer(0)

        LabelMessaggio.Text = "Calendario aggiornamento dati:"
        'ButtonImporta.Enabled = StatoButtonImporta()
        ButtonEsci.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Public Function AggiornamentoArchivi(TipoFile As Utx.Enumerazioni.TipoFileMagia,
                                         Optional ByRef NumeroRecord As Long = 0) As String

        Dim dr As DataTableReader

        Try
            'rileva le date
            Select Case TipoFile
                Case Utx.Enumerazioni.TipoFileMagia.Incassi
                    dr = Utx.FunzioniDb.CreaDataTableReader("SELECT MIN(DataFoglioCassa) AS Inizio,MAX(DataFoglioCassa) AS Fine,COUNT(*) AS Nr 
                        FROM Incassi")

                Case Utx.Enumerazioni.TipoFileMagia.Titoli
                    dr = Utx.FunzioniDb.CreaDataTableReader("SELECT MAX(DataEffetto) AS Fine,COUNT(*) AS Nr FROM Titoli")

                Case Utx.Enumerazioni.TipoFileMagia.Sinistri
                    dr = Utx.FunzioniDb.CreaDataTableReader("SELECT MAX(AnnoMeseCompetenza) AS Fine,COUNT(*) AS Nr FROM SinistriDP")

                Case Utx.Enumerazioni.TipoFileMagia.MonitorQT
                    dr = Utx.FunzioniDb.CreaDataTableReader("SELECT MAX(Effetto) AS Fine,COUNT(*) AS Nr FROM MonitorQT")

                Case Utx.Enumerazioni.TipoFileMagia.AnagNew
                    dr = Utx.FunzioniDb.CreaDataTableReader("SELECT MAX(co.UltimoAggiornamento) AS Fine,COUNT(c.CodiceFiscale) AS Nr 
                        FROM CalendarioOmnia AS CO,Clienti AS c 
                        WHERE CAST(TipoFile AS int) = " & TipoFile)

                Case Utx.Enumerazioni.TipoFileMagia.Polizze
                    dr = Utx.FunzioniDb.CreaDataTableReader("SELECT MAX(CO.UltimoAggiornamento) AS Fine,COUNT(P.CodiceFiscale) AS Nr 
                        FROM CalendarioOmnia AS CO, Polizze AS P 
                        WHERE CAST(TipoFile AS int) = " & TipoFile)

                Case Utx.Enumerazioni.TipoFileMagia.MovimentiPTF
                    dr = Utx.FunzioniDb.CreaDataTableReader("SELECT MAX(CO.UltimoAggiornamento) AS Fine,COUNT(M.CodiceFiscale) AS Nr 
                        FROM CalendarioOmnia AS CO,MovPolizze AS M 
                        WHERE CAST(TipoFile AS int) = " & TipoFile)
                Case Else
                    Return "ND"
            End Select

            dr.Read()
            NumeroRecord = dr("Nr")

            'crea il messaggio
            Select Case TipoFile
                Case Utx.Enumerazioni.TipoFileMagia.Sinistri
                    AggiornamentoArchivi = String.Format("Al {0:d} (cons.{1:d})", dr("Fine"), DataConsolidamentoSinistri())
                Case Utx.Enumerazioni.TipoFileMagia.Incassi
                    AggiornamentoArchivi = String.Format("Dal {0:d} Al {1:d}", dr("Inizio"), dr("Fine"))
                Case Else
                    AggiornamentoArchivi = String.Format("Al {0:d}", dr("Fine"))
            End Select

            dr.Close()

        Catch ex As Exception
            Log.Errore(ex, False)
            NumeroRecord = 0
            Return "ND"
        End Try
    End Function

    Private Function DataConsolidamentoSinistri() As Date
        Return Utx.FunzioniDb.ExecuteScalar("SELECT Consolida FROM CalendarioOmnia WHERE TipoFile = '05'", #1/1/1900#)
    End Function

    Public Function AggiornamentoListe(TipoFile As Utx.Enumerazioni.TipoFileDoc,
                                       Optional ByRef NumeroRecord As Long = 0) As String

        Dim dr As DataTableReader = Nothing
        Try
            'rileva le date
            Select Case TipoFile
                Case Utx.Enumerazioni.TipoFileDoc.QUIETANZAMENTO
                    NumeroRecord = Utx.WsCommand.ExecuteScalar("SELECT COUNT(*) FROM AttivitaQT").Valore
                    dr = Utx.FunzioniDb.CreaDataTableReader(String.Format("SELECT MIN(DataInizio) AS Inizio,MAX(DataFine) AS Fine 
                        FROM CalendarioDoc WHERE TipoFile = {0}", Val(TipoFile)))

                Case Utx.Enumerazioni.TipoFileDoc.FLEX
                    NumeroRecord = Utx.WsCommand.ExecuteScalar("SELECT COUNT(*) FROM ElencoFlex").Valore
                    dr = Utx.FunzioniDb.CreaDataTableReader(String.Format("SELECT MIN(DataInizio) AS Inizio,MAX(DataFine) AS Fine 
                        FROM CalendarioDoc WHERE TipoFile = {0} AND Codice In (0,1)", Val(TipoFile)))

                Case Utx.Enumerazioni.TipoFileDoc.BUSTE
                    NumeroRecord = Utx.WsCommand.ExecuteScalar("SELECT COUNT(*) FROM Buste").Valore
                    dr = Utx.FunzioniDb.CreaDataTableReader(String.Format("SELECT MIN(DataInizio) AS Inizio,MAX(DataFine) AS Fine 
                        FROM CalendarioDoc WHERE TipoFile = {0}", Val(TipoFile)))
            End Select

            'crea il messaggio
            dr.Read()
            AggiornamentoListe = String.Format("Dal {0:d} Al {1:d}", dr("Inizio"), dr("Fine"))

            dr.Close()

        Catch ex As Exception
            Log.Errore(ex, False)
            Return "ND"
        End Try
    End Function

    Private Sub ControlloNuoviDati()
        LabelInfoDL.Text = ""
        'omnia
        If Utx.GestioneFlag.EsisteFlag(Utx.GestioneFlag.TipoFlag.DATI_OMNIA_DISPONIBILI) Then
            LabelInfoOmnia.Text = "Sono disponibili nuovi dati dal flusso gionaliero"
            LabelInfoOmnia.ForeColor = Color.Blue
        Else
            LabelInfoOmnia.Text = "Non sono disponibili nuovi dati dal flusso gionaliero"
            LabelInfoOmnia.ForeColor = SystemColors.WindowText
        End If
        'download agenzie
        If Utx.GestioneFlag.EsisteFlag(Utx.GestioneFlag.TipoFlag.DATI_DOWNLOAD_DISPONIBILI) Then
            LabelInfoDL.Text = "Sono disponibili nuovi dati dal download agenzie"
            LabelInfoDL.ForeColor = Color.Blue
        Else
            LabelInfoDL.Text = "Non sono disponibili nuovi dati dal download agenzie"
            LabelInfoDL.ForeColor = SystemColors.WindowText
        End If
    End Sub

    Private Sub Importazione_StatoImportazione(Messaggio As String)
        LabelMessaggio.Text = Messaggio
    End Sub

    Private Sub LabelMessaggio_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LabelMessaggio.MouseDoubleClick
        Process.Start(Log.FullPathLogFile)
    End Sub

    Private Sub LabelMessaggio_TextChanged(sender As Object, e As EventArgs) Handles LabelMessaggio.TextChanged
        LabelMessaggio.Refresh()
    End Sub

    ' Implements the manual sorting of items by columns.
    Class ListViewItemComparer
        Implements IComparer

        Private col As Integer

        Public Sub New()
            col = 0
        End Sub

        Public Sub New(column As Integer)
            col = column
        End Sub

        Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
            Return [String].Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)
        End Function
    End Class

    Private Sub ButtonForzaturaOmnia_Click(sender As Object, e As EventArgs) Handles ButtonForzaturaOmnia.Click
        Try
            ButtonForzaturaOmnia.Enabled = False

            Dim Operazione As New Forzatura
            With Operazione
                .TipoForzatura = Forzatura.Tipo.OMNIA
                .OmniaDal = dtpForzaturaOmniaDal.Value
                .OmniaAl = dtpForzaturaOmniaAl.Value
                If ComboBoxTipoRecord.SelectedIndex > 0 Then .TipoRecord = ComboBoxTipoRecord.SelectedItem.Key
                If ComboBoxAgenzia.SelectedIndex > 0 Then .Agenzia = ComboBoxAgenzia.Text
            End With

            Dim newThread As New Threading.Thread(AddressOf EseguiForzatura.ForzaturaOmnia)
            newThread.Start(Operazione)
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
        Me.Close()
    End Sub

    Private Sub ButtonForzaturaDL_Click(sender As Object, e As EventArgs) Handles ButtonForzaturaDL.Click
        Dim Operazione As New Forzatura With {.TipoForzatura = Forzatura.Tipo.DL}
        bw.RunWorkerAsync(Operazione)
    End Sub

    Private Sub bw_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw.DoWork
        Try
            Dim Operazione As Forzatura = e.Argument

            If Operazione.TipoForzatura = Forzatura.Tipo.OMNIA Then
                'spostato tutto nell'evento click del bottone

                'If Utx.GestioneFlag.EsisteFlag(Utx.GestioneFlag.TipoFlag.DATI_OMNIA_DISPONIBILI) = True Then
                '    MsgBox("Importare prima i dati già disponibili e poi procedere con la forzatura", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                'Else
                '    If Utx.AgenziaOmnia.ImportazioneInCorso(Utx.GestioneFlag.TipoFlag.IMPORTA_DATI_OMNIA, 30) = True Then
                '        MsgBox("E' già in corso una lettura dati dal flusso giornaliero. Riprovare fra qualche minuto.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                '    Else
                '        Dim newThread As New Threading.Thread(AddressOf EseguiForzatura.ForzaturaOmnia)
                '        newThread.Start(Operazione)
                '    End If
                'End If

            ElseIf Operazione.TipoForzatura = Forzatura.Tipo.DL Then
                System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False

                'avvia processo
                'se non è in corso un'altra importazione
                Dim item As Utx.ArchivioUt = ComboBoxArchivioDL.SelectedItem
                If item.TipoArchivio > 0 Then
                    Utx.Manutenzione.ResetCalendarioUt(Utx.Globale.AgenziaRichiesta.CodiceAgenzia, item.TipoArchivio, dtpForzaturaDL.Value)
                Else
                    Utx.Manutenzione.ResetCalendarioDoc(Utx.Globale.AgenziaRichiesta.CodiceAgenzia, item.TipoArchivioDoc, dtpForzaturaDL.Value)
                End If
                'avvia processo
                Utx.GestioneFlag.CancellaFlag(Utx.GestioneFlag.TipoFlag.AUTO_IMPORT_DOWNLOAD_AGENZIE)
                UtTimer.ForzaTimer()
                Me.Close()
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ButtonForzaturaDbuno_Click(sender As Object, e As EventArgs) Handles ButtonForzaturaDbuno.Click
        Dim Agenzia As String = Utx.Globale.AgenziaRichiesta.CodiceAgenzia

#If DEBUG Then
        Agenzia = InputBox("Codice agenzia", DefaultResponse:=Agenzia)
        If IsNumeric(Agenzia) = False OrElse Agenzia.Length <> 5 Then
            MsgBox("Codice agenzia non valido", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
#End If

        If MsgBox($"Confermate la rilettura dei dati per l'agenzia {Agenzia}?",
                  MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2, Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then

            Dim ArchivioSelezionato As Utx.ArchivioUt = ComboBoxArchivioOmnia.SelectedItem
            Dim Consolida As Date = Utx.FunzioniData.FineMese(dtpDataDaDbuno.Value.AddMonths(-1))
            Dim CommandText As String

            Select Case ArchivioSelezionato.TipoArchivio
                Case Utx.Enumerazioni.TipoFileMagia.NonCatalogato 'vale per tutti gli archivi
                    CommandText = $"UPDATE CalendarioOmnia SET UltimoAggiornamento = '{dtpDataDaDbuno.Value:dd/MM/yyyy}'
                        WHERE UltimoAggiornamento > '{dtpDataDaDbuno.Value:dd/MM/yyyy}'"
                    Utx.WsCommand.ExecuteNonQuery(CommandText, Agenzia)
                    'reimpostare il consolidamento
                    CommandText = $"UPDATE CalendarioOmnia SET Consolida = '{Consolida:dd/MM/yyyy}'
                        WHERE TipoFile = '{Utx.ArchivioUt.TipoFile2Stringa(Utx.Enumerazioni.TipoFileMagia.Sinistri)}' AND Consolida > '{Consolida:dd/MM/yyyy}'"
                    Utx.WsCommand.ExecuteNonQuery(CommandText, Agenzia)
                Case Else
                    'imposto la data sull'archivio selezionato
                    CommandText = $"UPDATE CalendarioOmnia SET UltimoAggiornamento = '{dtpDataDaDbuno.Value:dd/MM/yyyy}'
                        WHERE TipoFile = '{ArchivioSelezionato.StringaTipoArchivio}' AND UltimoAggiornamento > '{dtpDataDaDbuno.Value:dd/MM/yyyy}'"
                    Utx.WsCommand.ExecuteNonQuery(CommandText, Agenzia)
                    'e poi sugli eventuali archivi collegati
                    Select Case ArchivioSelezionato.TipoArchivio
                        Case Utx.Enumerazioni.TipoFileMagia.Polizze
                            'se si tratta di polizze bisogna reimportare anche ptfcanc
                            CommandText = $"UPDATE CalendarioOmnia SET UltimoAggiornamento = '{dtpDataDaDbuno.Value:dd/MM/yyyy}'
                                WHERE TipoFile = '{Utx.ArchivioUt.TipoFile2Stringa(Utx.Enumerazioni.TipoFileMagia.MovimentiPTF)}'
                                    AND UltimoAggiornamento > '{dtpDataDaDbuno.Value:dd/MM/yyyy}'"
                            Utx.WsCommand.ExecuteNonQuery(CommandText, Agenzia)
                        Case Utx.Enumerazioni.TipoFileMagia.Sinistri
                            'se si tratta di sinistri bisogna reimportare anche andamento sinistri
                            CommandText = $"UPDATE CalendarioOmnia SET UltimoAggiornamento = '{dtpDataDaDbuno.Value:dd/MM/yyyy}'
                                WHERE TipoFile = '{Utx.ArchivioUt.TipoFile2Stringa(Utx.Enumerazioni.TipoFileMagia.AndamentoSinistri)}'
                                    AND UltimoAggiornamento > '{dtpDataDaDbuno.Value:dd/MM/yyyy}'"
                            Utx.WsCommand.ExecuteNonQuery(CommandText, Agenzia)
                            'reimpostare il consolidamento
                            CommandText = $"UPDATE CalendarioOmnia SET Consolida = '{Consolida:dd/MM/yyyy}'
                                WHERE TipoFile = '{Utx.ArchivioUt.TipoFile2Stringa(Utx.Enumerazioni.TipoFileMagia.Sinistri)}'
                                    AND Consolida > '{Consolida:dd/MM/yyyy}'"
                            Utx.WsCommand.ExecuteNonQuery(CommandText, Agenzia)
                    End Select
            End Select

            Using s As New Utx.EventiOMW.GeneraEventi
                s.GeneraEvento(Agenzia, "FORZATURA_CONSOLIDA_DB", "", Utx.Globale.Token)
            End Using
            MsgBox("L'importazione richiesta è stata completata.", MsgBoxStyle.Information)

            Me.Close()
        End If
    End Sub

    Private Sub ButtonAggiornaCalendario_Click(sender As Object, e As EventArgs) Handles ButtonAggiornaCalendario.Click
        'leggo il calendario aggiornamenti
        StatoAggiornamenti()
    End Sub

    Private Sub ButtonCumulo_Click(sender As Object, e As EventArgs) Handles ButtonCumulo.Click
        Try
            Dim tt As New Threading.Thread(AddressOf UniFeed.Cumulatore.RigeneraFile)
            Dim Dati As New UniFeed.Cumulatore.DatiStart
            If ComboBoxAgenziaCumulo.SelectedIndex = 0 Then
                Dati.Agenzia = Nothing
            Else
                Dati.Agenzia = ComboBoxAgenziaCumulo.SelectedItem
            End If
            Dati.Tipo = ComboBoxTipoCumulo.SelectedItem.Tipo

            tt.Start(Dati)
            Me.Close()
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonImportaCumulo_Click(sender As Object, e As EventArgs) Handles ButtonImportaCumulo.Click
        Try
            Dim Dati As New UniFeed.Cumulatore.DatiStart
            If ComboBoxAgenziaCumulo.SelectedIndex = 0 Then
                Dati.Agenzia = Nothing
            Else
                Dati.Agenzia = ComboBoxAgenziaCumulo.SelectedItem
            End If
            Dati.Tipo = ComboBoxTipoCumulo.SelectedItem.Tipo

            UniFeed.Cumulatore.CancellaImportazioneCumulo(Dati)

            ButtonForzaturaOmnia.PerformClick()
            Me.Close()
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub
End Class

Public Class TipoRecordOmnia

    Sub New(key As String, Descrizione As String)
        mKey = key
        mDescrizione = Descrizione
    End Sub

    Private mKey As String
    Public Property Key() As String
        Get
            Return mKey
        End Get
        Set(value As String)
            mKey = value
        End Set
    End Property

    Private mDescrizione As String
    Public Property Descrizione() As String
        Get
            Return mDescrizione
        End Get
        Set(value As String)
            mDescrizione = value
        End Set
    End Property
End Class

Public Class Forzatura

    Public Enum Tipo
        OMNIA
        DL
    End Enum

    Private mTipoForzatura As Tipo
    Public Property TipoForzatura() As Tipo
        Get
            Return mTipoForzatura
        End Get
        Set(value As Tipo)
            mTipoForzatura = value
        End Set
    End Property

    Private mOmniaDal As Date
    Public Property OmniaDal() As Date
        Get
            Return mOmniaDal
        End Get
        Set(value As Date)
            mOmniaDal = value
        End Set
    End Property

    Private mOmniaAl As Date
    Public Property OmniaAl() As Date
        Get
            Return mOmniaAl
        End Get
        Set(value As Date)
            mOmniaAl = value
        End Set
    End Property

    Private mAgenzia As String
    Public Property Agenzia() As String
        Get
            Return mAgenzia
        End Get
        Set(value As String)
            mAgenzia = value
        End Set
    End Property

    Private mTipoRecord As String
    Public Property TipoRecord() As String
        Get
            Return mTipoRecord
        End Get
        Set(value As String)
            mTipoRecord = value
        End Set
    End Property
End Class

Public Class EseguiForzatura

    Public Shared Sub ForzaturaOmnia(Operazione As Forzatura)
        'reset del calendario per forzare la successiva importazione
        If Operazione.Agenzia Is Nothing Then
            'tutti i codici agenzia gestiti
            If Operazione.TipoRecord Is Nothing Then
                'tutti i tipi di record per tutti i codici gestiti
                Utx.Manutenzione.ResetCalendarioOmnia(Operazione.OmniaDal.AddDays(-1))
            Else
                'un solo tipo di record
                For Each agenzia As String In Utx.EnteGestore.CodiciGestiti
                    Utx.Manutenzione.ResetCalendarioOmnia(agenzia, Operazione.TipoRecord, Operazione.OmniaDal.AddDays(-1))
                Next
            End If
        Else
            'un solo codice agenzia
            If Operazione.TipoRecord Is Nothing Then
                'tutti i tipi di record
                Utx.Manutenzione.ResetCalendarioOmnia(Operazione.Agenzia, Operazione.OmniaDal.AddDays(-1))
            Else
                'un solo tipo di record
                Utx.Manutenzione.ResetCalendarioOmnia(Operazione.Agenzia, Operazione.TipoRecord, Operazione.OmniaDal.AddDays(-1))
            End If
        End If
        'avvia processo
        TimerUnitools.ImportazioneOmnia(Operazione.OmniaDal.Date, Operazione.OmniaAl.Date, Operazione.TipoRecord, Operazione.Agenzia)
    End Sub
End Class