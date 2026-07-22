Imports System.IO
Imports System.Text

Public Class FormBudget

    Public Event RichiestaAnagrafica(CodiceFiscale As String)

    Private ds As New DataSet
    Private AnnoAnalisi As Integer
    Private AnnoInizio As Integer
    Private StopFormatting As Boolean
    'Private ReadOnly TT As New ToolTip
    Private OkStornate, OkPU, OkDelta As Boolean
    Private Figura As String
    Private FiguraBudget As String
    Private Const SogliaBudget As Single = 0.95
    Private CodiceSelezionato As String
    Private FiguraSelezionata As FiguraProduttiva
    Private InitDati As Utx.BudgetOMW.DatiAnalisiIncassi
    Private CompagniaIncorporata As Integer
    Private AgenziaIncorporata As Integer

    'toolstrip pezzi
    Private WithEvents ComboBoxTipoCarico As New ComboBox
    Private WithEvents ButtonAggiornaPezzi As New Button
    Private ReadOnly LabelDataPezzi As New Label
    Private WithEvents FormFiltro As New Utx.FormGestioneFiltro(1000)

    Public Shared TitoloFinestra As String = "Analisi incassi e budget"

    Sub New()
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.WindowState = FormWindowState.Maximized
        Me.Font = Utx.AppFont.Normal
        Me.MinimumSize = New Size(980, 480)
        Me.Text = TitoloFinestra
        Me.Icon = Risorse.Immagini.Icon("budget")
        Me.HelpButton = True
        Me.AcceptButton = btnEstraiDati

        Me.SuspendLayout()
        ImpostaControlli()
        ImpostaGriglie()
        Me.ResumeLayout()

        Globale.RamoGestioneToComparto()
    End Sub

    Private Sub ImpostaControlli()
        ToolStrip1.Font = Utx.AppFont.Normal
        LabelAggiornamentoArretrati.Font = Utx.AppFont.Bold
        tlpMain.Visible = False
        btnEsci.Image = Risorse.Immagini.Bitmap("esci")
        With CheckBoxVitaOk
            .Padding = New Padding(0, 5, 0, 5)
            .Appearance = Appearance.Normal
            .CheckAlign = ContentAlignment.BottomCenter
            .BackColor = Color.Gainsboro
            .Text = String.Format("Obiettivo VITA PREMI ANNUI raggiunto{0}{0}Ricalcola Budget", Environment.NewLine)
            .TextAlign = ContentAlignment.TopCenter
            .Checked = False
        End With
        With CheckBoxArretrati
            .Padding = New Padding(0, 5, 0, 5)
            .Appearance = Appearance.Normal
            .CheckAlign = ContentAlignment.BottomCenter
            .BackColor = Color.Gainsboro
            .Text = "Utilizza arretrati al 31/12 invece dei premi da incassare desunti dall'anno precedente"
            .TextAlign = ContentAlignment.TopCenter
        End With
        With CheckBoxIndividuali
            .Padding = New Padding(0, 0, 0, 2)
            .Appearance = Appearance.Normal
            .CheckAlign = ContentAlignment.BottomCenter
            .TextAlign = ContentAlignment.TopCenter
            .BackColor = Color.Gainsboro
            .Text = "Auto individuali"
            .Checked = False
        End With
        LabelTotalePolizza.Font = Utx.AppFont.Bold
#If Not DEBUG Then
        ButtonDettaglioProvvigioni.Enabled = Utx.Globale.UtenteCorrente.IsAgente
#End If
        btnEstraiDati.Enabled = False
        ButtonAggiornaIncassi.Enabled = False
        ButtonDettaglioProvvigioni.BackColor = Utx.AppColor.RosaChiaro
        'carattere predefinito
        udFontSize.Value = Utx.AppFont.FontSize
        'autosize colonne di default
        chkAutoSize.Checked = True
        'blocca colonne a sinistra
        chkBloccaColonne.Checked = True

        SplitContainer1.SplitterDistance = SplitContainer1.Width * 0.5

        'check box codici gestiti
        ImpostaCodiciGestiti()

        dtpDataInizioAnalisi.Format = DateTimePickerFormat.Short
        dtpDataAnalisi.Format = DateTimePickerFormat.Short

        TabPageVarie.Text = String.Format("Analisi varie {0}", Utx.Globale.AgenziaRichiesta.CodiceAgenzia)
        TabVarie.SelectedTab = DeltaPremi

        Utx.NetFunc.DoppioBuffer(TabMain)
        Utx.NetFunc.DoppioBuffer(TabVarie)
    End Sub

    Private Sub ImpostaCodiciGestiti()
        Try
            CodiceSelezionato = Utx.Globale.AgenziaRichiesta.CodiceAgenzia

            CheckedListBoxAgenzie.Items.Clear()
            CheckedListBoxAgenzie.CheckOnClick = True
            For Each Agenzia As String In Utx.EnteGestore.CodiciGestiti
                CheckedListBoxAgenzie.Items.Add(Agenzia, Agenzia = CodiceSelezionato)
            Next
            ButtonConfermaGruppo.Enabled = False
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ImpostaGriglie()
        On Error Resume Next

        For Each dgv As DataGridView In InsiemeGriglieExt()
            With dgv
                .SuspendLayout()
                .ReadOnly = True
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ColumnHeadersDefaultCellStyle.Padding = New Padding(0, 1, 0, 1)
                .DefaultCellStyle.Padding = New Padding(0, 1, 0, 1)
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .ResumeLayout()
            End With
            Utx.NetFunc.DoppioBuffer(dgv)
        Next
        'in arretrati il flag è modificabile dall'utente
        dgvArretrati.ReadOnly = False
        With dgvDelta
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
        End With
        With dgvDettaglioIncassi
            .SuspendLayout()
            .ReadOnly = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Padding = New Padding(0, 1, 0, 1)
            .DefaultCellStyle.Padding = New Padding(0, 1, 0, 1)
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ResumeLayout()
        End With
        With dgvAnomalie
            .SuspendLayout()
            .ReadOnly = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Padding = New Padding(0, 1, 0, 1)
            .DefaultCellStyle.Padding = New Padding(0, 1, 0, 1)
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ResumeLayout()
        End With
        With dgvDeltaArretrati
            .SuspendLayout()
            .ReadOnly = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Padding = New Padding(0, 1, 0, 1)
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.Padding = New Padding(0, 1, 0, 1)
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .ResumeLayout()
        End With
        Utx.NetFunc.DoppioBuffer(dgvDelta)
        Utx.NetFunc.DoppioBuffer(dgvDettaglioIncassi)
        Utx.NetFunc.DoppioBuffer(dgvAnomalie)
        Utx.NetFunc.DoppioBuffer(dgvArretrati)
        Utx.NetFunc.DoppioBuffer(dgvDeltaArretrati)
    End Sub

    Private Sub FormBudget_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        IncassiGiornalieri.Inizializzato = False
    End Sub

    Private Sub FormBudget_Load(sender As Object, e As EventArgs) Handles Me.Load
        FormBudget_Resize(Me, New EventArgs)
    End Sub

    Private Sub FormBudget_Resize(sender As Object, e As EventArgs)
        If Me.WindowState <> FormWindowState.Minimized Then
            TabMain.ItemSize = New Size(TabMain.Width / TabMain.TabPages.Count - 12, 27)
            TabAnalisi.ItemSize = New Size(TabAnalisi.Width / TabAnalisi.TabPages.Count - 12, 27)
            TabVarie.ItemSize = New Size(TabVarie.Width / TabVarie.TabPages.Count - 12, 27)
        End If
    End Sub

    Private Sub frmMain_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Try
            tlpMain.Visible = True
            TabMain.ColorStyle = Utx.UtTabControl.TabColorStyle.TRASPARENT
            TabMain.ColorStyle = Utx.UtTabControl.TabColorStyle.CONTROL
            TabAnalisi.ColorStyle = Utx.UtTabControl.TabColorStyle.TRASPARENT
            TabAnalisi.ColorStyle = Utx.UtTabControl.TabColorStyle.VERDE
            TabVarie.ColorStyle = Utx.UtTabControl.TabColorStyle.ROSA
            Me.Refresh()

            AddHandler Me.Resize, AddressOf FormBudget_Resize
            AddHandler chkAutoSize.CheckedChanged, AddressOf chkAutoSize_CheckedChanged
            AddHandler chkBloccaColonne.CheckedChanged, AddressOf chkBloccaColonne_CheckedChanged
            AddHandler udFontSize.ValueChanged, AddressOf udFontSize_ValueChanged
            AddHandler CheckedListBoxAgenzie.ItemCheck, AddressOf CheckedListBoxAgenzie_ItemCheck

            Me.UseWaitCursor = True
            btnExcel.Enabled = False

            InitTabelle()

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            btnEstraiDati.Enabled = True
            ButtonAggiornaIncassi.Enabled = True
            Me.UseWaitCursor = False
        End Try
    End Sub

    Private Sub InitTabelle()
        Try
            Me.Cursor = Cursors.WaitCursor

            Using s As New Utx.BudgetOMW.ServizioBudget With {.Proxy = Utx.Globale.UniProxy.Proxy}
                tssStato.Text = String.Format("Inizializzazione {0}...", CodiceSelezionato)
                'in settingbudget creo IncassiZero,Viste,Inizializza Budget Annuo
                s.SettingBudgetEx(CodiceSelezionato, {CodiceSelezionato}, Utx.Globale.Token)
                'inizializzo i dati analisi solo per il codice selezionato
                InitDati = s.DatiAnalisi(CodiceSelezionato, Utx.Globale.Token)
            End Using

            'creo i link  alle tabelle
            ImpostaDate()
            ImpostaAgenzie()
            ImpostaComboFigure()

        Catch ex As Exception
            Log.Errore(ex)
            Me.Close() 'esce dall'applicazione
        Finally
            tssStato.Text = ""
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub CreaLinkTabelle(Agenzia As String, ListaCodici As String())
        Try
            'creo linkincassi
            Using s As New Utx.BudgetOMW.ServizioBudget With {.Proxy = Utx.Globale.UniProxy.Proxy}
                s.CreaVistaIncassi(Agenzia, ListaCodici, Utx.Globale.Token)
            End Using
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub CreaLinkGruppo()
        Try
            Me.Cursor = Cursors.WaitCursor
            tssStato.Text = "Analisi incassi gruppo..."

            Using s As New Utx.BudgetOMW.ServizioBudget With {.Proxy = Utx.Globale.UniProxy.Proxy}
                s.CreaVistaIncassi(CodiceSelezionato, Utx.EnteGestore.ArrayCodiciGestiti, Utx.Globale.Token)
            End Using

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
            tssStato.Text = ""
        End Try
    End Sub

    Private Sub btnEstraiDati_Click(sender As System.Object, e As System.EventArgs) Handles btnEstraiDati.Click
        Try
            GroupBoxAnalisi.Enabled = False
            GroupBoxCodici.Enabled = False
            GroupBoxDati.Enabled = False
            GroupBoxAspetto.Enabled = False

            'resetta i flag che indicano l'avvenuto calcolo delle griglie
            OkStornate = False
            OkPU = False
            OkDelta = False

            'imposta la descrizione del tab stornate
            Stornate.Text = "Polizze stornate"

            Me.Cursor = Cursors.WaitCursor

            RimuoviEventiGriglie()
            ResetGriglie()

            'cancello le tabelle per ricrearle
            ds.Tables.Clear()

            AnalisiRamoGestione()

            AggregaDati()

            CalcolaGriglie()
            CalcolaRedditivita()
            DeskCodici()

            'cancella anni da non visualizzare
            CancellaAnniPrecedenti()
            'cancella colonne inutili (comparto/settore...)
            CancellaColonne()
            'visualizza notifica anomalie auto
            If AnalisiGruppo() = False AndAlso ComboBoxAgenzia.SelectedIndex = 0 Then
                Dim Notifica1 As New Utx.FormNotifica
                With Notifica1
                    .Stile = Utx.FormNotifica.Style.BIANCO_ROSSO
                    .Messaggio = String.Format("Totale anomalie auto {1:#,###,##0.00}{0}{0}per il dettaglio vai a 'Anomalie rami auto'", Environment.NewLine, TotaleAnomalieAuto)
                    .Show()
                    .ChiudiAsync(5)
                End With
            End If
            'visualizza notifica psico
            If AnalisiGruppo() = False AndAlso ComboBoxAgenzia.SelectedIndex = 0 Then
                Dim Notifica2 As New Utx.FormNotifica
                With Notifica2
                    .Stile = Utx.FormNotifica.Style.BIANCO_ROSSO
                    .Altezza = Utx.FormNotifica.AltezzaNotifica.MEZZA
                    .Messaggio = String.Format("Dati assistenza psicologica aggiornati{0}dal {1:dd-MM-yyyy} al {2:dd-MM-yyyy}",
                                               Environment.NewLine,
                                               ExportLib.Incassi.InizioAggiornamentoPsico(CheckedListBoxAgenzie.CheckedItems(0),
                                                                                          CheckedListBoxAgenzie.CheckedItems(0)),
                                               ExportLib.Incassi.UltimoAggiornamentoPsico(CheckedListBoxAgenzie.CheckedItems(0),
                                                                                          CheckedListBoxAgenzie.CheckedItems(0)))
                    .Show()
                    .ChiudiAsync(5)
                End With
            End If

            dgvRamoGestione.DataSource = ds.Tables("Rg")
            dgvComparto.DataSource = ds.Tables("Comparto")
            dgvSettore.DataSource = ds.Tables("Settore")
            dgvAggregato.DataSource = ds.Tables("Aggregato")
            dgvGenerale.DataSource = ds.Tables("Generale")
            'formatta celle e colonne
            FormattaColonne()
            For Each dgv As DataGridView In InsiemeGriglie()
                FormattaCelle(dgv)
            Next
            AgganciaEventiGriglie()

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            btnExcel.Enabled = True
            GroupBoxAnalisi.Enabled = True
            GroupBoxCodici.Enabled = True
            GroupBoxDati.Enabled = True
            GroupBoxAspetto.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub InitBudgetFigura(Figura As Integer,
                                 AnnoIniziale As Integer)
        '+imposta budget iniziale uguale a zero per la singola figura
        Try
            Dim Query As String = String.Format("SELECT * 
                FROM BudgetAnnuo 
                WHERE (Anno >= {0}) AND (CodiceFigura = {1}) 
                ORDER BY CodiceFigura,Anno,RamoGestione", AnnoIniziale, Figura)

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query, CodiceSelezionato).DataTable
            If dt IsNot Nothing Then
                'assegno una chiave per la ricerca
                dt.PrimaryKey = {dt.Columns("Anno"), dt.Columns("RamoGestione")}

                'controllo budget agenzia
                tssStato.Text = String.Format("Controllo budget della figura {0}", Figura)

                Query = "INSERT INTO BudgetAnnuo (CodiceFigura,Anno,RamoGestione,Importo)
                    VALUES({0},{1},{2},0)"

                'per ogni anno
                For Anno As Integer = AnnoIniziale To Today.Year
                    Dim QueryAnno As String = ""

                    'per ogni ramo gestione
                    For Rg As Integer = 1 To 23
                        'se la riga per figura/anno/rg non esiste
                        If dt.Rows.Find({Anno, Rg}) Is Nothing Then
                            QueryAnno &= String.Format(Query, Figura, Anno, Rg) & Environment.NewLine
                        End If
                    Next
                    If String.IsNullOrEmpty(QueryAnno) = False Then
                        Utx.WsCommand.ExecuteNonQuery(QueryAnno, CodiceSelezionato)
                    End If
                Next
            End If

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub ImpostaBudgetGruppi()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim dr As DataTableReader = Utx.FunzioniDb.CreaDataTableReader("SELECT DISTINCT Gruppo FROM GruppiCip")

            'per ogni gruppo
            Do While dr.Read
                ImpostaBudgetGruppo(dr("Gruppo"))
            Loop
        Catch ex As Exception
            Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ImpostaBudgetGruppo(CodiceGruppo As String)
        Try
            tssStato.Text = String.Format("Controllo budget: gruppo {0}", CodiceGruppo)

            'creo tabella temporanea con budget del gruppo
            Dim Query As String = String.Format("WITH Temp AS (
                SELECT Anno,RamoGestione,SUM(Importo) AS ImportoTotale 
                FROM BudgetAnnuo 
                WHERE CodiceFigura IN ({0}) 
                GROUP BY Anno,RamoGestione)
                
                UPDATE A 
                SET Importo = Temp.ImportoTotale 
                FROM BudgetAnnuo AS A 
                INNER JOIN Temp
                ON (A.Anno = Temp.Anno) AND (A.RamoGestione = Temp.Ramogestione)
                WHERE CodiceFigura = {1}", FiguraProduttiva.SelezionaFigura(CodiceGruppo).CodiciFigura(), CodiceGruppo)

            Utx.WsCommand.ExecuteNonQuery(Query)

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            tssStato.Text = ""
        End Try
    End Sub

    Private Sub AnalisiRamoGestione()
        Try
            tssStato.Text = "Analisi in corso..."

            AnnoAnalisi = dtpDataAnalisi.Value.Year
            AnnoInizio = Math.Min(CInt(cboAnnoInizio.Text), AnnoAnalisi - 1)
            Dim StringaAnno As String = CreaStringaAnno(AnnoInizio)

            Dim IndividualiAuto As String = " 1=1 "
            If CheckBoxIndividuali.Checked Then
                IndividualiAuto = " LinkIncassi.Ramo NOT IN (130,131,230,231) "
            End If

            FiguraBudget = String.Format(" (B.CodiceFigura = {0}) ", FiguraSelezionata.Codice)
            Figura = FiguraSelezionata.ClausolaIN(CheckBoxSub.Checked, CheckBoxProd.Checked)

            Dim CmdText As String = "SELECT LinkIncassi.RamoGestione,0 AS Comparto,0 AS Settore,0 AS Aggregato,0 AS Generale,
                '..' As Desk,Year(DataFoglioCassa) AS Anno,0.0001 AS IncassoAnnuo,
                B.Importo As BudgetAnnuo,0.0001 As IncrementoAtteso,{0},
                SUM(Tassabile) AS TotaleAlMese,0.0001 AS DiCui,
                SUM(PremioRC) AS TotaleRCA,SUM(PrINF) AS TotaleINF,SUM(PremioARD) AS TotaleARD,
                SUM(PrvFisse) AS Provvigioni,0.0001 AS DiffProvPerc,0.0001 AS Redditivita,
                SUM(CavRCA) AS ProvCAV,SUM(PrvINF) AS ProvINF,SUM(PrvARD) AS ProvARD,
                0 AS QIncassate,0 AS PIncassate,0.0001 AS MediaIncasso,0.0001 AS Differenza,
                0.0001 AS ImportoDiff,0.0001 AS Atteso,0.0001 AS ScostamentoPerc,0.0001 AS Scostamento,
                0.0001 AS Avanzamento,0.0001 AS DaIncassare,0.0001 AS TotaleSenzaPU,0.0001 AS AvanzamentoSenzaPU,
                0.0001 AS DaIncassarePU,0.0001 AS TotaleConPU,0.0001 AS AvanzamentoConPU 
                FROM LinkIncassi WITH (NOLOCK), LinkBudget AS B WITH (NOLOCK)
                WHERE (LinkIncassi.RamoGestione = B.RamoGestione AND 
                YEAR(DataFoglioCassa) = B.Anno) AND {1} AND {2} AND {3} AND {4} AND {5}
                GROUP BY LinkIncassi.RamoGestione,YEAR(DataFoglioCassa),B.Importo 
                ORDER BY LinkIncassi.RamoGestione"
            CmdText = String.Format(CmdText, CreaStringaMesi, StringaAnno, Figura, FiguraBudget, Incorporata, IndividualiAuto)
            '0=CreaStringaMesi,1=stringaanno,2=figura,3=figurabudget,4=incorporata,5=individuali
            Utx.Globale.Log.Info(CmdText)
            '+la tabella incassi rappresenta la UNION fra gli incassi di tutti i codici selezionati
            ds = Utx.WsCommand.ExecuteNonQuery({CmdText,
                                               QueryIncassiMensili(StringaAnno),
                                               QueryIncassiTotaliAnnui(),
                                               QueryMediaIncasso(String.Format(" {0} AND {1} AND {2} ", StringaAnno, Figura, IndividualiAuto)),
                                               QueryPremiSenzaPU(),
                                               QueryPremiUniciDaIncassare(),
                                               QueryPolizzeIncassate(String.Format(" {0} AND {1} AND {2} ", StringaAnno, Figura, IndividualiAuto)),
                                               QueryTitoliIncassati(String.Format(" {0} AND {1} AND {2} ", StringaAnno, Figura, IndividualiAuto))},
                                               {"Rg", "Mensili", "Annuali", "Media", "SenzaPU", "PremiUnici", "Polizze", "Titoli"}, CodiceSelezionato).DataSet

            'azzera campi a 0.0001
            AzzeraCampi(ds.Tables("Rg"))
            'imposta gli aggregati
            ImpostaAggregati()
            'sistema le partite delle polizze Rca
            ElaboraRca()
            'polizze e quietanze incassate
            PolizzeIncassate()
            'media giorni per l'incasso solo sulla tabella Rg
            MediaIncasso()
            'totali annui e incassi per mese
            IncassiTotaliAnnui(AnnoAnalisi)
            IncassiMensili()
            'ricalcolo budget
            RicalcoloBudgetAnnuo()
            'premi da incassare fino a fine anno senza premi unici
            PremiDaIncassareSenzaPU()
            'sistemazione arretrati
            SostituisciArretrati()
            'premi unici da incassare fino a fine anno
            PremiUniciDaIncassare()

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            tssStato.Text = ""
        End Try
    End Sub

    Private Sub CalcolaRedditivita()
        Try
            Dim Tabelle() As String = {"Rg", "Comparto", "Settore", "Aggregato", "Generale"}
            'per tutte le tabelle in elenco
            For Each tbl As String In Tabelle
                'per ogni riga nella tabella
                For Each dr As DataRow In ds.Tables(tbl).Rows
                    If dr("TotaleAlMese") > 0 Then
                        dr("Redditivita") = dr("Provvigioni") / dr("TotaleAlMese")
                    End If
                Next
            Next
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub CalcolaGriglie()
        Try
            Dim Tabelle() As String = {"Rg", "Comparto", "Settore", "Aggregato", "Generale"}

            'calcolo scostamento assoluto e percentuale
            Dim TotaleAnnuoPrecedente, TotaleAlPrecedente, TotaleProvPrecedente As Double

            'per tutte le tabelle in elenco
            For Each tbl As String In Tabelle
                'per ogni riga nella tabella
                For Each dr As DataRow In ds.Tables(tbl).Rows
                    'differenza assoluta e percentuale con l'anno precedente
                    If dr("Anno") > AnnoInizio Then
                        If TotaleAlPrecedente > 0 Then
                            dr("Differenza") = dr("TotaleAlMese") / TotaleAlPrecedente - 1
                            dr("ImportoDiff") = dr("TotaleAlMese") - TotaleAlPrecedente
                        End If
                        If TotaleProvPrecedente > 0 Then
                            'incremento %
                            dr("DiffProvPerc") = dr("Provvigioni") / TotaleProvPrecedente - 1
                        End If
                    End If

                    If dr("Anno") < AnnoAnalisi Then
                        TotaleAnnuoPrecedente = dr("IncassoAnnuo")
                        TotaleAlPrecedente = dr("TotaleAlMese")
                        TotaleProvPrecedente = dr("Provvigioni")
                    End If

                    If dr("Anno") = AnnoAnalisi Then
                        'calcola totali con e senza premi unici (PU)
                        dr("TotaleSenzaPU") = dr("TotaleAlMese") + dr("DaIncassare")
                        dr("TotaleConPU") = dr("TotaleSenzaPU") + dr("DaIncassarePU")

                        If TotaleAnnuoPrecedente * TotaleAlPrecedente <> 0 Then
                            dr("Atteso") = dr("BudgetAnnuo") / TotaleAnnuoPrecedente * TotaleAlPrecedente
                        End If
                        If TotaleAnnuoPrecedente <> 0 Then
                            'incremento atteso
                            dr("IncrementoAtteso") = dr("BudgetAnnuo") / TotaleAnnuoPrecedente - 1
                        End If
                        If TotaleProvPrecedente > 0 Then
                            'incremento %
                            dr("DiffProvPerc") = dr("Provvigioni") / TotaleProvPrecedente - 1
                        End If

                        'scostamento percentuale e assoluto
                        dr("Scostamento") = dr("TotaleAlMese") - dr("Atteso")

                        If dr("Atteso") > 0 Then
                            dr("ScostamentoPerc") = dr("Scostamento") / dr("Atteso")
                        End If

                        If dr("BudgetAnnuo") > 0 Then
                            'avanzamento su budget
                            dr("Avanzamento") = dr("TotaleAlMese") / dr("BudgetAnnuo")

                            'avanzamento senza pu
                            dr("AvanzamentoSenzaPU") = dr("TotaleSenzaPU") / dr("BudgetAnnuo")

                            'avanzamento con pu
                            dr("AvanzamentoConPU") = dr("TotaleConPU") / dr("BudgetAnnuo")
                        End If
                    End If
                Next
            Next

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub DeskCodici()
        Try
            '+inserisce le descrizioni di rg, comparto, ecc.
            For Each Tabella As String In "Rg/Comparto/Settore/Aggregato/Generale".Split("/")

                Dim CampoCodice, CampoDesk As String
                If Tabella = "Rg" Then
                    CampoCodice = "RamoGestione"
                    CampoDesk = "RgDesk"
                Else
                    CampoCodice = Tabella
                    CampoDesk = Tabella + "Desk"
                End If

                For Each dr As DataRow In ds.Tables(Tabella).Rows
                    For Each row As DataRow In Globale.RgToComparto.Rows
                        If row(CampoCodice) = dr(CampoCodice) Then
                            dr("Desk") = row(CampoDesk)
                            Exit For
                        End If
                    Next
                Next
            Next
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Function QueryIncassiTotaliAnnui() As String
        '+incassi totali per anno
        Return String.Format("SELECT RamoGestione,YEAR(DataFoglioCassa) AS Anno,SUM(Tassabile) AS TotaleAnnuo,
            SUM(PremioRC) AS TotaleRCA,SUM(PrINF) AS TotaleINF,SUM(PremioARD) AS TotaleARD 
            FROM LinkIncassi WITH (NOLOCK)
            WHERE {0} AND {1} 
            GROUP BY RamoGestione,YEAR(DataFoglioCassa) 
            ORDER BY Year(DataFoglioCassa),RamoGestione", Figura, Incorporata)
    End Function

    Private Sub IncassiTotaliAnnui(AnnoAnalisi As Integer)
        Try
            Dim dt As DataTable = ds.Tables("Annuali")

            Dim Rca, RcaARD, RcaINF As Double
            For Each dri As DataRow In dt.Rows
                'per l'anno di analisi non esiste un incasso annuo ma un incasso al...
                If dri("Anno") < AnnoAnalisi OrElse Format(dtpDataAnalisi.Value, "dd/MM") = "31/12" Then

                    If dri("RamoGestione") = 1 Then
                        Rca = dri("TotaleRCA")
                        RcaARD = dri("TotaleARD")
                        RcaINF = dri("TotaleINF")
                    End If

                    For Each dr As DataRow In ds.Tables("Rg").Rows

                        'per ogni riga con anno e rg uguale ai valori nella riga del dri
                        If (dr("Anno") = dri("Anno")) And (dr("RamoGestione") = dri("RamoGestione")) Then

                            Select Case dr("RamoGestione")
                                Case 1
                                    dr("IncassoAnnuo") = Rca
                                Case 2
                                    dr("IncassoAnnuo") += dri.Item("TotaleAnnuo") + RcaARD
                                Case 3
                                    dr("IncassoAnnuo") += dri.Item("TotaleAnnuo") + RcaINF
                                Case Else
                                    dr("IncassoAnnuo") = dri.Item("TotaleAnnuo")
                            End Select

                            'trovata la riga non ne esiste un'altra con stesso anno e stesso rg perciò esco
                            Exit For
                        End If
                    Next
                End If
            Next

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Function QueryIncassiMensili(StringaAnno As String) As String
        Try
            Return String.Format("SELECT RamoGestione,YEAR(DataFoglioCassa) AS Anno,MONTH(DataFoglioCassa) AS Mese,SUM(Tassabile) AS TotaleMese,
                SUM(PremioRC) AS TotaleRCA,SUM(PrINF) AS TotaleINF,SUM(PremioARD) AS TotaleARD 
                FROM LinkIncassi WITH (NOLOCK)
                WHERE {0}  AND {1} AND {2}
                GROUP BY RamoGestione,YEAR(DataFoglioCassa),MONTH(DataFoglioCassa)
                ORDER BY Anno,Mese,RamoGestione", StringaAnno, Figura, Incorporata)
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Function

    Private Sub IncassiMensili()
        Try
            Dim dtm As DataTable = ds.Tables("Mensili")

            Dim Righe(), RigheRca() As DataRow

            For Each dr As DataRow In ds.Tables("Rg").Rows
                'seleziono le righe per quel ramo gestione e quell'anno
                Righe = dtm.Select(String.Format("RamoGestione = {0} And Anno = {1}", dr("RamoGestione"), dr("Anno")))

                Select Case dr("RamoGestione")
                    Case 1
                        For Each r As DataRow In Righe
                            dr(r("Mese").ToString) = r("TotaleRca")
                        Next
                    Case > 3
                        For Each r As DataRow In Righe
                            dr(r("Mese").ToString) = r("TotaleMese")
                        Next
                    Case Else
                        'seleziono le righe rca per quell'anno
                        RigheRca = dtm.Select(String.Format("RamoGestione = 1 And Anno = {0}", dr("Anno")))

                        'per tutti i mesi. nei 2 array di datarow alcuni mesi potrebbero non esserci
                        For m As Integer = 1 To dtpDataAnalisi.Value.Month

                            dr(m.ToString) = 0

                            'inserisco nel mese l'importo del ramogestione (2 o 3)
                            For Each r As DataRow In Righe
                                If r("Mese") = m Then
                                    dr(m.ToString) = r("TotaleMese")
                                    Exit For
                                End If
                            Next
                            'e poi aggiungo la parte derivante dall'auto
                            For Each r As DataRow In RigheRca
                                If r("Mese") = m Then
                                    If dr("RamoGestione") = 2 Then
                                        dr(m.ToString) += r("TotaleARD")
                                    Else 'rg 3 INF
                                        dr(m.ToString) += r("TotaleINF")
                                    End If

                                    Exit For
                                End If
                            Next
                        Next
                End Select
            Next

            dtm.Dispose()

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Function QueryPremiSenzaPU() As String
        '+premi da incassare fino a fine anno senza premi unici. FONDAMENTALE ordinamento query per ramo gestione
        Return String.Format("SELECT RamoGestione,YEAR(DataFoglioCassa) AS Anno,SUM(Tassabile) AS DaIncassare,
            SUM(PremioRC) As TotaleRCA,SUM(PrINF) As TotaleINF,SUM(PremioARD) As TotaleARD 
            FROM LinkIncassi WITH (NOLOCK)
            WHERE(DataFoglioCassa BETWEEN '{0:dd/MM/yyyy}' AND '{1:dd/MM/yyyy}') AND Frazionamento NOT IN (0,8) AND {2}
            GROUP BY RamoGestione, Year(DataFoglioCassa) 
            ORDER BY RamoGestione", dtpDataAnalisi.Value.AddYears(-1).AddDays(1),
                                    Utx.FunzioniData.FineAnno(dtpDataAnalisi.Value.Year - 1), Figura)
    End Function

    Private Sub PremiDaIncassareSenzaPU()
        Try
            '+premi da incassare fino a fine anno senza premi unici. FONDAMENTALE ordinamento query per ramo gestione
            Dim dt As DataTable = ds.Tables("SenzaPU")
            'sistemazione dei premi inf del conducende e ard in rcauto
            Dim INF, ARD As Double
            For Each dri As DataRow In dt.Rows
                For Each dr As DataRow In ds.Tables("Rg").Rows
                    If (dr("Anno") = dri("Anno") + 1) And (dr("RamoGestione") = dri("RamoGestione")) Then
                        Select Case dri("RamoGestione")
                            Case 1 : INF = dri("TotaleINF") : ARD = dri("TotaleARD") : dr("DaIncassare") = dri("DaIncassare") - INF - ARD
                            Case 2 : dr("DaIncassare") = dri("DaIncassare") + ARD
                            Case 3 : dr("DaIncassare") = dri("DaIncassare") + INF
                            Case Else : dr("DaIncassare") = dri("DaIncassare")
                        End Select
                    End If
                Next
            Next
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Function QueryPremiUniciDaIncassare() As String
        'premi unici da incassare fino a fine anno
        Return String.Format("SELECT RamoGestione,YEAR(DataFoglioCassa) AS Anno,SUM(Tassabile) AS DaIncassarePU,
            SUM(PremioRC) AS TotaleRCA,SUM(PrINF) AS TotaleINF,SUM(PremioARD) AS TotaleARD 
            FROM LinkIncassi WITH (NOLOCK)
            WHERE (DataFoglioCassa BETWEEN '{0}' AND '{1}') AND Frazionamento IN (0,8) AND {2}
            GROUP BY RamoGestione,YEAR(DataFoglioCassa)",
                             dtpDataAnalisi.Value.AddYears(-1).AddDays(1), Utx.FunzioniData.FineAnno(dtpDataAnalisi.Value.Year - 1), Figura)
    End Function

    Private Sub PremiUniciDaIncassare()
        Try
            'premi unici da incassare fino a fine anno
            Dim dt As DataTable = ds.Tables("PremiUnici")
            Dim INF, ARD As Double

            For Each dri As DataRow In dt.Rows
                For Each dr As DataRow In ds.Tables("Rg").Rows
                    If (dr("Anno") = dri("Anno") + 1) And (dr("RamoGestione") = dri("RamoGestione")) Then

                        Select Case dri("RamoGestione")
                            Case 1
                                INF = dri("TotaleINF") : ARD = dri("TotaleARD")
                                dr("DaIncassarePU") = dri("DaIncassarePU") - INF - ARD
                            Case 2
                                dr("DaIncassarePU") = dri("DaIncassarePU") + ARD
                            Case 3
                                dr("DaIncassarePU") = dri("DaIncassarePU") + INF
                            Case Else
                                dr("DaIncassarePU") = dri("DaIncassarePU")
                        End Select
                        dr("TotaleConPU") = dr("TotaleSenzaPU") + dr("DaIncassarePU")
                    End If
                Next
            Next
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Function QueryPolizzeIncassate(ClausolaWhere As String) As String
        Return String.Format("WITH PolInc AS 
            (SELECT YEAR(DataFoglioCassa) AS Anno,RamoGestione,Ramo,Polizza 
            FROM LinkIncassi WITH (NOLOCK)
            WHERE (TipoCarico <> '9') AND (Polizza <> 0) AND {0}
            GROUP BY YEAR(DataFoglioCassa),RamoGestione,Ramo,Polizza) 

            SELECT Anno,RamoGestione,COUNT(*) AS NrPolizze 
            FROM PolInc
            GROUP BY Anno,RamoGestione 
            ORDER BY Anno,RamoGestione", ClausolaWhere)
    End Function

    Private Function QueryTitoliIncassati(ClausolaWhere As String) As String
        Return String.Format("SELECT YEAR(DataFoglioCassa) AS Anno,RamoGestione,Count(*) AS NrTitoli 
            FROM LinkIncassi WITH (NOLOCK)
            WHERE (TipoCarico <> '9') AND (CodiceSubAgente >= 0) AND {0}
            GROUP BY YEAR(DataFoglioCassa),RamoGestione 
            ORDER BY YEAR(DataFoglioCassa),RamoGestione", ClausolaWhere)
    End Function

    Private Sub PolizzeIncassate()
        Try
            Dim Polizze As DataTable = ds.Tables("Polizze")
            Dim Quietanze As DataTable = ds.Tables("Titoli")

            'polizze
            Polizze.PrimaryKey = {Polizze.Columns("Anno"), Polizze.Columns("RamoGestione")}

            For Each r As DataRow In ds.Tables("Rg").Rows
                'seleziono la riga per quel ramo gestione e quell'anno
                Dim Riga As DataRow = Polizze.Rows.Find({r("Anno"), r("RamoGestione")})

                If Riga Is Nothing Then
                    r("PIncassate") = 0
                Else
                    r("PIncassate") = Riga("NrPolizze")
                End If
            Next
            'quietanze
            Quietanze.PrimaryKey = {Quietanze.Columns("Anno"), Quietanze.Columns("RamoGestione")}

            For Each r As DataRow In ds.Tables("Rg").Rows
                'seleziono la riga per quel ramo gestione e quell'anno
                Dim Riga As DataRow = Quietanze.Rows.Find({r("Anno"), r("RamoGestione")})

                If Riga Is Nothing Then
                    r("QIncassate") = 0
                Else
                    r("QIncassate") = Riga("NrTitoli")
                End If
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Unitools", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function QueryMediaIncasso(ClausolaWhere As String) As String
        'elimino i tipi carico 5/6/9 (premi unici/regolazioni/rimborsi)
        Return String.Format("SELECT AVG(DATEDIFF(day,DataEffettoTitolo,DataFoglioCassa)) AS MediaIncasso,RamoGestione,YEAR(DataFoglioCassa) AS Anno 
            FROM LinkIncassi WITH (NOLOCK)
            WHERE (TipoCarico NOT IN ('5','6','9')) AND {0}
            GROUP BY YEAR(DataFoglioCassa),RamoGestione", ClausolaWhere)
    End Function

    Private Sub MediaIncasso()
        Try
            If AnalisiGruppo() = True Then
                'per l'analisi di gruppo dato non disponibile
                Exit Sub
            End If

            Dim Temp As DataTable = ds.Tables("Media")
            Temp.PrimaryKey = {Temp.Columns("Anno"), Temp.Columns("RamoGestione")}

            Dim Riga As DataRow

            For Each dr As DataRow In ds.Tables("Rg").Rows
                'seleziono la riga per quel ramo gestione e quell'anno
                Riga = Temp.Rows.Find({dr("Anno"), dr("RamoGestione")})

                If Riga IsNot Nothing Then dr("MediaIncasso") = Riga("MediaIncasso")
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Unitools", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ImpostaDate()
        Try
            tssStato.Text = "Controllo date incassi..."

            With dtpDataAnalisi
                .MaxDate = CDate("31/12/2100") 'resetto max date
                .Value = InitDati.DataAnalisi
                .MaxDate = Utx.FunzioniData.FineMese(.Value)
            End With
            dtpDataInizioAnalisi.Value = New Date(dtpDataAnalisi.Value.Year, 1, 1)

            cboAnnoInizio.Items.Clear()
            For k As Integer = InitDati.PrimoAnno To dtpDataAnalisi.Value.Year
                cboAnnoInizio.Items.Add(k)
            Next

            'seleziono l'ultimo anno
            cboAnnoInizio.SelectedIndex = cboAnnoInizio.Items.Count - 1

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            tssStato.Text = ""
        End Try
    End Sub

    Private Sub ImpostaAgenzie()
        Try
            ComboBoxAgenzia.Items.Clear()
            ComboBoxAgenzia.Items.Add("TUTTE")
            For Each row As DataRow In InitDati.Agenzie.Rows
                ComboBoxAgenzia.Items.Add(row("Agenzia"))
            Next
            ComboBoxAgenzia.SelectedIndex = 0

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            tssStato.Text = ""
        End Try
    End Sub

    Private Sub ImpostaComboFigure()
        Try
            RemoveHandler cboFigura.SelectedIndexChanged, AddressOf cboFigura_SelectedIndexChanged

            cboFigura.DataSource = Nothing
            FiguraProduttiva.Figure.Clear()
            FiguraProduttiva.Figure.Add(New FiguraProduttiva(0, "Tutte le figure", FiguraProduttiva.TipoFigura.CIP))

            If AnalisiGruppo() = False Then
                '+se NON stiamo analizzando un gruppo con più codici aggiungo le figure
                For Each dr As DataRow In InitDati.FigureProduttive.Rows
                    FiguraProduttiva.Figure.Add(New FiguraProduttiva(dr("IdFiguraProduttiva"), dr("FiguraProduttiva"), FiguraProduttiva.TipoFigura.CIP))
                Next
                'gruppi
                'intestazione gruppi
                FiguraProduttiva.Figure.Add(New FiguraProduttiva(0, "Gruppi definiti:", FiguraProduttiva.TipoFigura.NON_DEFINITO))
                For Each dr As DataRow In InitDati.Gruppi.Rows
                    FiguraProduttiva.Figure.Add(New FiguraProduttiva(dr("Gruppo"), dr("Descrizione"), FiguraProduttiva.TipoFigura.GRUPPO))
                Next
            End If

            AddHandler cboFigura.SelectedIndexChanged, AddressOf cboFigura_SelectedIndexChanged

            With cboFigura
                .DataSource = FiguraProduttiva.Figure
                .DisplayMember = "DescrizioneEstesa"
                .SelectedIndex = 0
            End With

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Function Incorporata() As String
        If CompagniaIncorporata = 0 Then
            Return " 1=1 "
        Else
            Return String.Format(" (Compagnia IN (0, {0}) AND Agenzia IN (0, {1})) ", CompagniaIncorporata, AgenziaIncorporata)
        End If
    End Function

    Private Function CreaStringaMesi() As String
        Try
            Dim Mesi As String = ""
            For k As Integer = 1 To dtpDataAnalisi.Value.Month
                Mesi += String.Format("0.0001 As '{0}',", k)
            Next

            Return Mesi.Substring(0, Mesi.Length - 1)

        Catch ex As Exception
            Log.Errore(ex)
            Return ""
        End Try
    End Function

    Private Function CreaStringaAnno(AnnoInizio As Integer) As String
        Try
            Dim Anno As String = ""

            For k As Integer = AnnoInizio To dtpDataAnalisi.Value.Year
                Anno += String.Format("(DataFoglioCassa BETWEEN '{0:dd/MM/yyyy}' AND '{1:dd/MM/yyyy}'){2}",
                                      DateSerial(k, dtpDataInizioAnalisi.Value.Month, dtpDataInizioAnalisi.Value.Day),
                                      DateSerial(k, dtpDataAnalisi.Value.Month, dtpDataAnalisi.Value.Day),
                                      IIf(k = dtpDataAnalisi.Value.Year, "", " OR "))
            Next
            For k As Integer = AnnoInizio To dtpDataAnalisi.Value.Year
                Anno += String.Format(" OR (YEAR(DataFoglioCassa) = {0} AND CodiceSubAgente = -1)", k)
            Next
            Return String.Format("({0})", Anno)

        Catch ex As Exception
            Log.Errore(ex)
            Return ""
        End Try
    End Function

    Private Sub FormattaCelle(dgv As DataGridView)
        On Error Resume Next
        'indici colonne da formattare
        'Differenza,ImportoDiff,Scostamento,ScostamentoPerc,Avanzamento,AvanzamentoSenzaPU,AvanzamentoConPu,Atteso,IncassoAnnuo,diffprovperc
        For c As Integer = 0 To dgv.Columns.Count - 1

            Dim colonna As String = dgv.Columns(c).Name.ToLower

            Select Case colonna
                Case "differenza", "importodiff", "scostamento", "scostamentoperc", "diffprovperc"
                    For r As Integer = 0 To dgv.Rows.Count - 1
                        Select Case dgv.Rows(r).Cells(c).Value
                            Case Is < 0
                                dgv.Rows(r).Cells(c).Style.ForeColor = Color.Red
                            Case 0
                                dgv.Rows(r).Cells(c).Style.BackColor = Color.LightGray
                            Case Else
                                dgv.Rows(r).Cells(c).Style.ForeColor = Color.Green
                        End Select
                    Next

                Case "avanzamento", "avanzamentosenzapu", "avanzamentoconpu"
                    For r As Integer = 0 To dgv.Rows.Count - 1
                        Select Case dgv.Rows(r).Cells(c).Value
                            Case 0
                                dgv.Rows(r).Cells(c).Style.BackColor = Color.LightGray
                            Case Is >= SogliaBudget
                                dgv.Rows(r).Cells(c).Style.ForeColor = Color.Green
                            Case Else
                                dgv.Rows(r).Cells(c).Style.ForeColor = Color.Red
                        End Select
                    Next

                Case "atteso"
                    For r As Integer = 0 To dgv.Rows.Count - 1
                        If dgv.Rows(r).Cells(c).Value = 0 Then dgv.Rows(r).Cells(c).Style.BackColor = Color.LightGray
                    Next

                Case "incassoannuo"
                    For r As Integer = 0 To dgv.Rows.Count - 1
                        If dgv.Rows(r).Cells(c).Value > 0 Then dgv.Rows(r).Cells(c).Style.BackColor = Color.LightGray
                    Next
            End Select
        Next
    End Sub

    Private Sub tssStato_TextChanged(sender As Object, e As System.EventArgs) Handles tssStato.TextChanged
        StatusStrip1.Refresh()
    End Sub

    Private Sub FormattaColonne()
        On Error Resume Next
        Dim StrDataAnalisi As String = Format(dtpDataAnalisi.Value, "dd MMMM")

        With dgvRamoGestione
            .SuspendLayout()

            With .Columns("RamoGestione")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Ramo Gestione"
            End With

            .Columns("Anno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            With .Columns("Desk")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Descr."
            End With
            With .Columns("IncassoAnnuo")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
                .HeaderText = "Incasso annuo"
            End With
            With .Columns("IncrementoAtteso")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##0.00%"
                .DefaultCellStyle.BackColor = Color.Beige
                .HeaderText = "Incremento % atteso"
            End With
            With .Columns("TotaleAlMese")
                .HeaderCell.Style.Font = Utx.AppFont.Bold
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
                .DefaultCellStyle.BackColor = Color.Gold
                .HeaderText = "Incassato al " + StrDataAnalisi
            End With
            With .Columns("DiCui")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
                .HeaderText = "Di cui da polizze Rca"
            End With
            With .Columns("Provvigioni")
                .HeaderCell.Style.Font = Utx.AppFont.Bold
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
                .DefaultCellStyle.BackColor = Color.Pink
            End With
            With .Columns("DiffProvPerc")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##0.00%"
                .DefaultCellStyle.BackColor = Color.LavenderBlush
                .HeaderText = "Provvigioni differenza anno prec. %"
            End With
            With .Columns("Redditivita")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##0.00%"
                .DefaultCellStyle.BackColor = Utx.AppColor.RosaChiaro
                .HeaderText = "Provvigioni Redditività %"
            End With
            With .Columns("QIncassate")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,##0"
                .DefaultCellStyle.BackColor = Color.Lavender
                .HeaderText = "Titoli"
            End With
            With .Columns("PIncassate")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,##0"
                .DefaultCellStyle.BackColor = Color.LavenderBlush
                .HeaderText = "Polizze"
            End With
            With .Columns("MediaIncasso")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##0.00"
                .DefaultCellStyle.BackColor = Color.LightBlue
                .HeaderText = "Tempo medio di incasso in giorni"
            End With
            With .Columns("Differenza")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##0.00%"
                .HeaderText = "Differenza con l'anno precedente %"
            End With
            With .Columns("ImportoDiff")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
                .HeaderText = "Differenza con l'anno precedente euro"
            End With
            With .Columns("BudgetAnnuo")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
                .DefaultCellStyle.BackColor = Color.Moccasin
                .HeaderText = "Budget annuo"
            End With

            With .Columns("Atteso")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
                .DefaultCellStyle.BackColor = Color.GreenYellow
                .HeaderText = "Incasso atteso al " + StrDataAnalisi
            End With
            With .Columns("ScostamentoPerc")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##0.00%"
                .HeaderText = "Scostamento dall'atteso %"
            End With
            With .Columns("Scostamento")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
                .HeaderText = "Scostamento dall'atteso euro"
            End With
            With .Columns("Avanzamento")
                .HeaderCell.Style.Font = Utx.AppFont.Bold
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##0.00%"
                .HeaderText = "Avanzamento % sul Budget al " + StrDataAnalisi
            End With
            With .Columns("DaIncassare")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
                If CheckBoxArretrati.Checked = True Then
                    .HeaderText = String.Format("Arretrati {0} da incassare al 31/12", Utx.Globale.AgenziaRichiesta.CodiceAgenzia)
                    .DefaultCellStyle.BackColor = Color.LightSalmon
                Else
                    .HeaderText = "Premi ricorrenti da incassare dopo il " + StrDataAnalisi
                    .DefaultCellStyle.BackColor = Color.Moccasin
                End If
            End With
            With .Columns("TotaleSenzaPU")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
                .DefaultCellStyle.BackColor = Color.Cornsilk
                .HeaderText = "Totale SENZA PU al 31/12"
            End With
            With .Columns("AvanzamentoSenzaPU")
                .HeaderCell.Style.Font = Utx.AppFont.Bold
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##0.00%"
                .DefaultCellStyle.BackColor = Color.Cornsilk
                .HeaderText = "Avanzamento % sul Budget SENZA PU al 31/12"
            End With
            With .Columns("DaIncassarePU")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
                .DefaultCellStyle.BackColor = Color.Linen
                .HeaderText = "Premi unici da incassare dopo il " + StrDataAnalisi
            End With
            With .Columns("TotaleConPU")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
                .DefaultCellStyle.BackColor = Color.Linen
                .HeaderText = "Totale CON PU al 31/12"
            End With
            With .Columns("AvanzamentoConPU")
                .HeaderCell.Style.Font = Utx.AppFont.Bold
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##0.00%"
                .DefaultCellStyle.BackColor = Color.Linen
                .HeaderText = "Avanzamento % sul Budget CON PU al 31/12"
            End With

            'colonne mesi
            For k As Integer = 1 To dtpDataAnalisi.Value.Month
                With .Columns(k.ToString)
                    .HeaderText = FirstToUpper(MonthName(k))
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "##,###,##0.00"
                    .Visible = False
                End With
            Next

            CopiaFormatColonne()
            VisibilitaProvvigioni()

            'autosize
            AutoSizeColonne()

            .RowHeadersDefaultCellStyle.SelectionBackColor = Color.Red
            dgvRamoGestione_CurrentCellChanged(Me, New EventArgs)

            'autosize intestazioni righe
            .AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders)

            'blocca colonne a sinistra
            ' ** chkBloccaColonne_CheckedChanged(Me, New EventArgs)

            .ResumeLayout()
        End With
    End Sub

    Private Function VisibilitaProvvigioni() As Boolean
#If DEBUG Then
        Return True
#End If
        For Each dgv As DataGridView In InsiemeGriglie()
            With dgv
                .Columns("Provvigioni").Visible = Utx.Globale.UtenteCorrente.Ruolo.StartsWith("AGE")
                .Columns("DiffProvPerc").Visible = Utx.Globale.UtenteCorrente.Ruolo.StartsWith("AGE")
                .Columns("Redditivita").Visible = Utx.Globale.UtenteCorrente.Ruolo.StartsWith("AGE")
            End With
        Next
        Return Utx.Globale.UtenteCorrente.Ruolo.StartsWith("AGE")
    End Function

    Private Sub CopiaFormatColonne()
        Try
            For Each dgv As DataGridView In InsiemeGriglie(False)
                dgv.SuspendLayout()

                'copia formati e intestazioni
                For Each c As DataGridViewColumn In dgvRamoGestione.Columns
                    'per tutte le colonne tranne la prima (comparto/settore...) e la seconda (anno)
                    'si utilizzano i suffissi com/set/agg/gen
                    If c.Name = "RamoGestione" Then
                        dgv.Columns(dgv.Name.Substring(3)).DefaultCellStyle = dgvRamoGestione.Columns(c.Name).DefaultCellStyle

                    ElseIf c.Name = "Anno" Then
                        dgv.Columns("Anno").DefaultCellStyle = dgvRamoGestione.Columns("Anno").DefaultCellStyle

                    ElseIf IsNumeric(c.Name) Then
                        'per i mesi
                        dgv.Columns(c.Name).DefaultCellStyle = dgvRamoGestione.Columns(c.Name).DefaultCellStyle
                        dgv.Columns(c.Name).HeaderText = dgvRamoGestione.Columns(c.Name).HeaderText
                        'nasconde colonne mesi
                        dgv.Columns(c.Name).Visible = False

                    ElseIf c.Name = "MediaIncasso" Then
                        'la colonna non esiste negli altri dgv
                    ElseIf c.Name = "DiCui" Then
                        'la colonna non esiste negli altri dgv
                    Else
                        dgv.Columns(c.Name).DefaultCellStyle = dgvRamoGestione.Columns(c.Name).DefaultCellStyle
                        dgv.Columns(c.Name).HeaderText = dgvRamoGestione.Columns(c.Name).HeaderText
                    End If
                Next

                dgv.ResumeLayout()
            Next

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub AutoSizeColonne()
        'auto size di righe e colonne in base al check
        On Error Resume Next

        If chkAutoSize.Checked Then
            For Each dgv As DataGridView In InsiemeGriglieExt()
                dgv.SuspendLayout()
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
                dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                dgv.ResumeLayout()
            Next
        Else
            For Each dgv As DataGridView In InsiemeGriglieExt()
                dgv.SuspendLayout()
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
                dgv.ResumeLayout()
            Next
        End If
    End Sub

    Private Sub chkAutoSize_CheckedChanged(sender As System.Object, e As System.EventArgs)
        AutoSizeColonne()
    End Sub

    Private Sub btnNascondiColonna_Click(sender As System.Object, e As System.EventArgs) Handles btnNascondiColonna.Click
        On Error Resume Next
        For Each c As DataGridViewCell In dgvRamoGestione.SelectedCells
            dgvRamoGestione.Columns(c.ColumnIndex).Visible = False
        Next
    End Sub

    Private Sub btnScopri_Click(sender As System.Object, e As System.EventArgs) Handles btnScopri.Click
        Try
            For Each dgv As DataGridView In InsiemeGriglie()
                dgv.SuspendLayout()
                For Each c As DataGridViewColumn In dgv.Columns
                    c.Visible = True
                Next
                dgv.ResumeLayout()
            Next
            VisibilitaProvvigioni()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnNascondiMesi_Click(sender As System.Object, e As System.EventArgs) Handles btnNascondiMesi.Click
        Try
            For Each dgv As DataGridView In InsiemeGriglie()
                dgv.SuspendLayout()
                For k As Integer = 1 To dtpDataAnalisi.Value.Month
                    dgv.Columns(k.ToString).Visible = False
                Next
                dgv.ResumeLayout()
            Next
            VisibilitaProvvigioni()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chkBloccaColonne_CheckedChanged(sender As System.Object, e As System.EventArgs)
        On Error Resume Next
        'è stata scelta la forma resume next invece di try perchè deve sempre essere
        'eseguito il ResumeLayout altrimenti resta il layout sospeso

        For Each dgv As DataGridView In InsiemeGriglie()
            dgv.SuspendLayout()

            'blocca le colonne a sinistra del cursore
            For k As Integer = 0 To dgv.CurrentCell.ColumnIndex - 1
                dgv.Columns.Item(k).Frozen = chkBloccaColonne.Checked
            Next

            dgv.ResumeLayout()
        Next
    End Sub

    Private Sub udFontSize_ValueChanged(sender As System.Object, e As System.EventArgs)
        StopFormatting = True

        Try
            For Each dgv As DataGridView In InsiemeGriglie()
                dgv.SuspendLayout()
                'cambia dimensione carattere
                dgv.Font = Utx.AppFont.Extra(udFontSize.Value, FontStyle.Regular)
                dgv.ResumeLayout()
            Next
        Catch ex As Exception
        End Try

        AutoSizeColonne()
        StopFormatting = False
    End Sub

    Private Sub btnEsci_Click(sender As System.Object, e As System.EventArgs) Handles btnEsci.Click
        Me.Close()
    End Sub

    Private Sub dgvRamoGestione_SelectionChanged(sender As Object, e As System.EventArgs)
        Somma(dgvRamoGestione)
    End Sub

    Private Sub dgvComparto_SelectionChanged(sender As Object, e As System.EventArgs)
        Somma(dgvComparto)
    End Sub

    Private Sub dgvSettore_SelectionChanged(sender As Object, e As System.EventArgs)
        Somma(dgvSettore)
    End Sub

    Private Sub dgvAggregato_SelectionChanged(sender As Object, e As System.EventArgs)
        Somma(dgvAggregato)
    End Sub

    Private Sub dgvGenerale_SelectionChanged(sender As Object, e As System.EventArgs)
        Somma(dgvGenerale)
    End Sub

    Private Sub Somma(ByRef dgv As DataGridView)
        Dim StrTotale As String, StrMedia As String

        Try
            Dim Totale As Double = 0, k As Integer = 0
            For Each c As DataGridViewCell In dgv.SelectedCells
                Totale = Totale + c.Value
                k += 1
            Next
            StrTotale = Format(Totale, "###,###,##0.00")
            StrMedia = Format(Totale / k, "###,###,##0.00")

        Catch ex As Exception
            StrTotale = "Errore"
            StrMedia = "Errore"
        End Try

        tssSomma.Text = String.Format("Somma: {0} - Media: {1} ({2})", StrTotale, StrMedia, TabAnalisi.SelectedTab.Text)
    End Sub

    Private Function InsiemeGriglie(Optional ConRamoGestione As Boolean = True) As Array
        If ConRamoGestione Then
            Dim o(4) As Object

            o(0) = dgvRamoGestione
            o(1) = dgvComparto
            o(2) = dgvSettore
            o(3) = dgvAggregato
            o(4) = dgvGenerale

            Return o
        Else
            Dim o(3) As Object

            o(0) = dgvComparto
            o(1) = dgvSettore
            o(2) = dgvAggregato
            o(3) = dgvGenerale

            Return o
        End If
    End Function

    Private Function InsiemeGriglieExt(Optional ConRamoGestione As Boolean = True) As Array
        Dim o() As Object

        If ConRamoGestione Then
            ReDim o(11)

            o(0) = dgvRamoGestione
            o(1) = dgvComparto
            o(2) = dgvSettore
            o(3) = dgvAggregato
            o(4) = dgvGenerale
            o(5) = dgvMovimenti
            o(6) = dgvStornate
            o(7) = dgvPremiUnici
            o(8) = dgvDelta
            o(9) = dgvArretrati
            o(10) = dgvGiornate
            o(11) = dgvRegistro
        Else
            ReDim o(9)

            o(0) = dgvComparto
            o(1) = dgvSettore
            o(2) = dgvAggregato
            o(3) = dgvGenerale
            o(4) = dgvStornate
            o(5) = dgvPremiUnici
            o(6) = dgvDelta
            o(7) = dgvArretrati
            o(8) = dgvGiornate
            o(9) = dgvRegistro
        End If

        Return o
    End Function

    Private Function DescrizioneGriglie() As String()
        Dim o(11) As String

        o(0) = "Ramo gestione"
        o(1) = "Comparto"
        o(2) = "Settore"
        o(3) = "Aggregato"
        o(4) = "Generale"
        o(5) = "Movimenti"
        o(6) = "Stornate"
        o(7) = "PremiUnici"
        o(8) = "Delta"
        o(9) = "Arretrati"
        o(10) = "Giornate"
        o(11) = "Registro"

        Return o
    End Function

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Dim NomeFile As String = String.Format("Budget al {0:dd-MM-yyyy}", dtpDataAnalisi.Value)
        Utx.NetFunc.Esporta2Csv({dgvRamoGestione, dgvComparto, dgvSettore, dgvAggregato, dgvGenerale},
                                {"RAMO GESTIONE", "COMPARTO", "SETTORE", "AGGREGATO", "TOTALE"}, NomeFile, Color.Khaki)
    End Sub

    Private Sub btnHelp_Click(sender As System.Object, e As System.EventArgs) Handles btnHelp.Click
        Help.ShowHelp(Me,
                      Path.Combine(Utx.Globale.Paths.CartellaApp, "Unitools.chm"),
                      "analisi_incassi_e_budget.htm")
    End Sub

    Private Sub ListaPremiUnici(Optional FiltroCella As String = " 1=1 ")
        Try
            If OkPU Then
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor
            RemoveHandler dgvPremiUnici.ColumnHeaderMouseClick, AddressOf dgvArretrati_ColumnHeaderMouseClick

            tssStato.Text = "Premi unici..."

            Label4.Text = String.Format("Premi unici incassati nel {0}/{1}." +
                                        " E' possibile utilizzare la funzione di filtro (Attiva filtro PU).",
                                        dtpDataAnalisi.Value.Year - 1,
                                        dtpDataAnalisi.Value.Year)
            Label4.Refresh()

            Dim Query As String = String.Format("SELECT I.DataEffettoTitolo AS Effetto,I.DataFoglioCassa AS [Data incasso],I.Tassabile,
                C.Cognome,C.Nome,C.DataNascita AS [Data di nascita],C.Telefono1 AS Telefono,
                I.CodiceProdotto AS Prodotto,I.Ramo,I.Polizza,I.CodiceSubAgente AS Sub,I.Frazionamento AS Fraz 
                FROM Incassi As I WITH (NOLOCK)
                LEFT JOIN Clienti AS C ON I.CodiceFiscInc = C.CodiceFiscale 
                WHERE I.Frazionamento IN (0,8) AND (Year(I.DataFoglioCassa) >= {0} AND {1})",
                                                (dtpDataAnalisi.Value.Year - 1).ToString, FiltroCella)

            dgvPremiUnici.DataSource = Utx.WsCommand.ExecuteNonQuery(Query).DataTable
            Utx.NetFunc.BloccaOrdinamento(dgvPremiUnici)

            FormattaPU()

            AddHandler dgvPremiUnici.ColumnHeaderMouseClick, AddressOf dgvArretrati_ColumnHeaderMouseClick

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            OkPU = True
            Me.Cursor = Cursors.Default
            tssStato.Text = ""
        End Try
    End Sub

    Private Sub ListaStornate(Optional FiltroCella As String = " True ")
        Try
            If OkStornate Then
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor
            RemoveHandler dgvStornate.ColumnHeaderMouseClick, AddressOf dgvArretrati_ColumnHeaderMouseClick

            tssStato.Text = "Stornate..."

            Dim Anno As Integer = dtpDataAnalisi.Value.Year

            Dim Query As String = String.Format("SELECT C.Cognome,C.Nome,
                M.Ramo,M.Polizza,M.CodiceSubAgente AS Sub,M.CodiceProdotto AS Prodotto,
                M.TotalePremioAnnuo AS [Premio annuo],M.IdStorno,M.DataStorno AS [Data storno] 
                FROM MovPolizze AS M WITH (NOLOCK)
                INNER JOIN Clienti AS C ON C.CodiceFiscale = M.CodiceFiscale 
                WHERE (M.IdStorno <> 'AU') AND Year(DataStorno) = {0}", dtpDataAnalisi.Value.Year)

            Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteNonQuery(Query)
            dgvStornate.DataSource = Risposta.DataTable
            Utx.NetFunc.BloccaOrdinamento(dgvStornate)

            FormattaStornate()

            AddHandler dgvStornate.ColumnHeaderMouseClick, AddressOf dgvArretrati_ColumnHeaderMouseClick

        Catch ex As Exception
            Log.Errore(ex)
        End Try

        'imposta la descrizione del tab
        Try
            Dim Query As String = String.Format("SELECT Max(DataStorno) 
                FROM MovPolizze 
                WHERE YEAR(DataStorno) = {0} AND (IdStorno <> 'AU')", dtpDataAnalisi.Value.Year)

            Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteScalar(Query)

            Stornate.Text = String.Format("Polizze stornate al {0:MM-yyyy} ({1})", Risposta.Valore, dgvStornate.DataSource.Rows.Count)

        Catch ex As Exception
            Stornate.Text = "Polizze stornate"
        Finally
            OkStornate = True
            Me.Cursor = Cursors.Default
            tssStato.Text = ""
        End Try
    End Sub

    Private Sub VariazioneIncassi(Optional FiltroCella As String = " True ")
        Try
            If OkDelta Then
                Exit Sub
            End If
            If CheckedListBoxAgenzie.CheckedItems.Count > 1 Then
                MsgBox("L'analisi variazioni può essere fatta solo per un singolo codice.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            RemoveHandler dgvDelta.ColumnHeaderMouseClick, AddressOf dgvArretrati_ColumnHeaderMouseClick
            RemoveHandler dgvDelta.CurrentCellChanged, AddressOf dgvDelta_CurrentCellChanged
            RemoveHandler ComboBoxRgDelta.SelectedIndexChanged, AddressOf ComboBoxRgDelta_SelectedIndexChanged

            tssStato.Text = "Variazione incassi..."

            dgvDelta.DataSource = Nothing
            dgvDettaglioIncassi.DataSource = Nothing
            dgvDelta.Refresh()
            dgvDettaglioIncassi.Refresh()
            FormFiltro.CancellaFiltri()
            Application.DoEvents()

            Dim AnnoNew As Integer = dtpDataAnalisi.Value.Year
            Dim AnnoOld As Integer = AnnoNew - 1
            Dim DataLimiteNew As Date = dtpDataAnalisi.Value
            Dim DataLimiteOld As Date = DataLimiteNew.AddYears(-1)
            Dim CampoOld As String = String.Format("Premi {0}", AnnoOld)
            Dim CampoNew As String = String.Format("Premi {0}", AnnoNew)
            'dblink del codice selezionato (è sempre uno solo)
            Dim DbLink As String = String.Format("{0}\DbLink.{1}.mdb", Utx.Globale.Paths.CartellaTempUtente, CodiceSelezionato)

            Dim CmdText As New StringBuilder
            With CmdText
                .Append("Premi versati nel {0}/{1} raggruppati per codice fiscale. ")
                .Append("Nelle  colonne a sinistra la differenza (+/-) in valore assoluto e percentuale. ")
                .Append("Trattandosi di variazioni non vengono riportati i nuovi clienti. ")
                .Append("Nel riquadro a destra il dettaglio degli incassi del cliente selezionato")
            End With

            With Label5
                .Font = Utx.AppFont.Normal
                .TextAlign = ContentAlignment.MiddleLeft
                .Text = String.Format(CmdText.ToString, AnnoOld, AnnoNew)
            End With

            Dim ClausolaRg As String = "1=1"
            If ComboBoxRgDelta.SelectedIndex > 0 Then
                ClausolaRg = String.Format("(I.RamoGestione = {0})", ComboBoxRgDelta.SelectedItem.Substring(0, 2))
            End If

            Dim Query As String = String.Format("DECLARE @NumeroClienti AS int = (SELECT COUNT(*) FROM Clienti)

                IF @NumeroClienti > 0

                WITH 
                Precedente AS (
                SELECT C.Cognome,C.Nome,C.Telefono1,C.SubAgenzia AS Sub,
                YEAR(I.DataFoglioCassa) As Anno,I.CodiceFiscInc As CF,SUM(I.TotaleTitolo) As Premi 
                FROM Incassi AS I WITH (NOLOCK), Clienti AS C WITH (NOLOCK)
                WHERE(C.CodiceFiscale = I.CodiceFiscInc) AND 
                (I.DataFoglioCassa BETWEEN '{0:dd/MM/yyyy}' AND '{1:dd/MM/yyyy}') AND {4}
                GROUP BY I.CodiceFiscInc,YEAR(I.DataFoglioCassa),C.Cognome,C.Nome,C.Telefono1,C.SubAgenzia),

                Corrente AS (
                SELECT C.Cognome,C.Nome,C.Telefono1,C.SubAgenzia AS Sub,
                YEAR(I.DataFoglioCassa) As Anno,I.CodiceFiscInc As CF,SUM(I.TotaleTitolo) As Premi 
                FROM Incassi AS I WITH (NOLOCK), Clienti AS C WITH (NOLOCK)
                WHERE(C.CodiceFiscale = I.CodiceFiscInc) AND 
                (I.DataFoglioCassa BETWEEN '{2:dd/MM/yyyy}' AND '{3:dd/MM/yyyy}') AND {4}
                GROUP BY I.CodiceFiscInc,YEAR(I.DataFoglioCassa),C.Cognome,C.Nome,C.Telefono1,C.SubAgenzia)

                SELECT P.CF,P.Cognome,P.Nome,P.Telefono1 AS Telefono,P.Sub,
                ISNULL(P.Premi,0) AS PremiOld,
                ISNULL(C.Premi,0) AS PremiNew,
                0.001 AS Differenza,0.001 AS Perc
                FROM Precedente AS P
                LEFT JOIN Corrente AS C ON P.CF = C.CF", dtpDataInizioAnalisi.Value.AddYears(-1), dtpDataAnalisi.Value.AddYears(-1),
                                                         dtpDataInizioAnalisi.Value, dtpDataAnalisi.Value, ClausolaRg)

            Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteNonQuery(Query)
            If Risposta IsNot Nothing Then
                'calcolo differenze, percentuale e saldo
                Dim Saldo As Double = 0
                    For Each row As DataRow In Risposta.DataTable.Rows
                    row("Differenza") = row("PremiNew") - row("PremiOld")
                    If row("PremiOld") > 0 Then row("Perc") = row("Differenza") / row("PremiOld")
                        Saldo += row("Differenza")
                    Next
                    SaldoDeltaPremi(Saldo)

                    'visualizzo
                    dgvDelta.DataSource = Risposta.DataTable
                    FormattaDelta()
                    Utx.NetFunc.BloccaOrdinamento(dgvDelta)

                    OkDelta = True

                    If dgvDelta.Rows.Count > 0 Then
                        dgvDelta.CurrentCell = dgvDelta.Rows(0).Cells(1)
                        dgvDelta.Rows(0).Selected = True
                    End If
                End If

                dgvDelta_CurrentCellChanged(Me, New EventArgs)

            AddHandler dgvDelta.ColumnHeaderMouseClick, AddressOf dgvArretrati_ColumnHeaderMouseClick
            AddHandler dgvDelta.CurrentCellChanged, AddressOf dgvDelta_CurrentCellChanged
            AddHandler ComboBoxRgDelta.SelectedIndexChanged, AddressOf ComboBoxRgDelta_SelectedIndexChanged

        Catch ex As Exception
            Log.Errore(ex)
            OkDelta = True
        Finally
            tssStato.Text = ""
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub SaldoDeltaPremi(Optional Saldo As Double = 0)
        Try
            If Saldo = 0 Then
                'calcolo totale
                For Each row As DataGridViewRow In dgvDelta.Rows
                    Saldo += row.Cells("Differenza").Value
                Next
            End If
            'visualizzo
            lbDeltaTotale.Text = String.Format("Totale differenze {0} (+/-) dal {1:dd-MM-yyyy} al {2:dd-MM-yyyy} = {3:##,###,##0.00} euro",
                                               CodiceSelezionato, dtpDataInizioAnalisi.Value, dtpDataAnalisi.Value, Saldo)
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub InitComboRgDelta()
        Try
            If ComboBoxRgDelta.Items.Count = 0 Then
                Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery("SELECT * 
                    FROM RamoGest 
                    WHERE NOT RamoGestione IN (18,19,20) 
                    ORDER BY RamoGestione").DataTable

                ComboBoxRgDelta.Items.Clear()
                ComboBoxRgDelta.Items.Add("00. Tutti i rami gestione")

                For Each row As DataRow In dt.Rows
                    ComboBoxRgDelta.Items.Add(String.Format("{0:00}. {2} ({1})",
                                           row("RamoGestione"), row("DescBreve").ToString.Trim, row("DescRamoGest").ToString.Trim))
                Next
                If ComboBoxRgDelta.Items.Count > 0 Then
                    ComboBoxRgDelta.SelectedIndex = 0
                End If
            End If
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub ComboBoxRgDelta_SelectedIndexChanged(sender As Object, e As EventArgs)
        OkDelta = False
        dgvDelta.DataSource = Nothing
        dgvDelta.Refresh()
        dgvDettaglioIncassi.DataSource = Nothing
        dgvDettaglioIncassi.Refresh()
    End Sub

    Private Sub FormattaStornate()
        On Error Resume Next

        With dgvStornate
            .SuspendLayout()

            .Columns("Prodotto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Prodotto").DefaultCellStyle.BackColor = Color.GreenYellow
            .Columns("Ramo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Ramo").DefaultCellStyle.ForeColor = Color.Red
            .Columns("Sub").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("IdStorno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Data storno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Premio Annuo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Premio Annuo").DefaultCellStyle.ForeColor = Color.Blue
            .Columns("Premio Annuo").DefaultCellStyle.Format = "##,###,##0.00"

            If chkAutoSize.Checked Then
                .AutoResizeColumns(DataGridViewAutoSizeColumnMode.AllCells)
            Else
                .AutoResizeColumns(DataGridViewAutoSizeColumnMode.NotSet)
            End If

            .ResumeLayout()
        End With
    End Sub

    Private Sub FormattaPU()
        Try
            With dgvPremiUnici
                .Columns("Data incasso").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Data di nascita").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Telefono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Prodotto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Prodotto").DefaultCellStyle.BackColor = Color.GreenYellow
                .Columns("Ramo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Ramo").DefaultCellStyle.ForeColor = Color.Red
                .Columns("Effetto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Fraz").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Sub").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Tassabile").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Tassabile").DefaultCellStyle.Format = "##,###,##0.00"
                .Columns("Tassabile").DefaultCellStyle.ForeColor = Color.Blue
                .AutoResizeColumns(DataGridViewAutoSizeColumnMode.AllCells)
            End With
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub FormattaDelta()
        On Error Resume Next
        With dgvDelta
            .SuspendLayout()

            .Columns("CF").Visible = False

            .Columns("Telefono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Sub").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Sub").DefaultCellStyle.ForeColor = Color.Red

            With .Columns("PremiOld")
                .HeaderText = String.Format("Premi {0}", dtpDataAnalisi.Value.Year - 1)
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
            End With
            With .Columns("PremiNew")
                .HeaderText = String.Format("Premi {0}", dtpDataAnalisi.Value.Year)
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
            End With
            .Columns("Differenza").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Differenza").DefaultCellStyle.Format = "##,###,##0.00"
            .Columns("Differenza").DefaultCellStyle.BackColor = Color.GreenYellow

            .Columns("Perc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Perc").DefaultCellStyle.Format = "##0.00%"

            If chkAutoSize.Checked Then
                .AutoResizeColumns(DataGridViewAutoSizeColumnMode.AllCells)
            Else
                .AutoResizeColumns(DataGridViewAutoSizeColumnMode.NotSet)
            End If

            .ResumeLayout()
        End With
    End Sub

    Private Sub dgvDelta_CurrentCellChanged(sender As Object, e As System.EventArgs)
        If dgvDelta.CurrentRow IsNot Nothing Then
            If OkDelta Then DettaglioDelta()
        End If
    End Sub

    Private Sub DettaglioDelta()
        Static CFPrecedente As String = ""
        Dim CFSelezionato As String

        Try
            CFSelezionato = dgvDelta.CurrentRow.Cells("CF").Value
            If CFSelezionato = CFPrecedente Then
                Exit Sub
            Else
                'se è cambiato il CF
                CFPrecedente = CFSelezionato
            End If
        Catch ex As Exception
            dgvDettaglioIncassi.DataSource = Nothing
            dgvDettaglioIncassi.Refresh()
            Exit Sub
        End Try

        RemoveHandler dgvDettaglioIncassi.CurrentCellChanged, AddressOf dgvDettaglioIncassi_CurrentCellChanged

        Try
            Me.Cursor = Cursors.WaitCursor

            btnEsportaDettaglio.Enabled = False

            LabelDettaglioVariazioni.Font = Utx.AppFont.Bold
            LabelDettaglioVariazioni.Text = String.Format("{0} {1} - Incassi dal {2} al {3} - {4}",
                                                          dgvDelta.CurrentRow.Cells("Cognome").Value,
                                                          dgvDelta.CurrentRow.Cells("Nome").Value,
                                                          dtpDataAnalisi.Value.Year - 1, Today.Year, ComboBoxRgDelta.Text)

            Dim ClausolaRg As String = "1=1"
            If ComboBoxRgDelta.SelectedIndex > 0 Then
                ClausolaRg = String.Format("(RamoGestione = {0})", ComboBoxRgDelta.SelectedItem.Substring(0, 2))
            End If

            Dim Query As String = String.Format("SELECT Ramo,Polizza,CodiceSubAgente AS Sub,CodiceProdotto AS Prodotto,
                Frazionamento AS Fraz,TipoCarico AS [Tipo carico],RamoGestione,
                DataEffettoTitolo AS [Effetto titolo],DataFoglioCassa AS [Data esito],
                SUM(TotaleTitolo) AS Premio, YEAR(DataFoglioCassa) AS Anno,'' AS Note
                FROM Incassi 
                WHERE (CodiceFiscInc = '{0}') AND (YEAR(DataFoglioCassa) >= {1}) AND {2}
                GROUP BY Ramo,Polizza,CodiceSubAgente,CodiceProdotto,YEAR(DataFoglioCassa),
                    Frazionamento,DataFoglioCassa,DataEffettoTitolo,TipoCarico,RamoGestione",
                                                CFSelezionato.Trim, dtpDataAnalisi.Value.Year - 1, ClausolaRg)
            Dim QueryArretrati As String = String.Format("SELECT RamoGestione AS RGest,Ramo,Polizza,EffettoTitolo,Frazionamento,TotaleTitolo,Prodotto,Convenzione
                FROM Arretrati
                WHERE CodiceFiscale = '{0}' AND {1}", CFSelezionato.Trim, ClausolaRg)

            Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteNonQuery({Query, QueryArretrati}, {"Incassi", "Arretrati"})

            If Risposta IsNot Nothing Then
                dgvDettaglioIncassi.DataSource = Risposta.DataSet.Tables("Incassi")

                'formatto la griglia
                With dgvDettaglioIncassi
                    .Columns("Ramo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Anno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Prodotto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Sub").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Fraz").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Tipo carico").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Effetto titolo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Data esito").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("Premio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("Premio").DefaultCellStyle.Format = "##,###,##0.00"
                    .Columns("RamoGestione").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("RamoGestione").HeaderText = String.Format("Ramo{0}gestione", Environment.NewLine)
                    .Columns("Note").DefaultCellStyle.BackColor = Color.White
                    .AutoResizeColumns()
                End With

                Dim Colore1 As Color = Color.Gainsboro
                Dim Colore2 As Color = Color.LightYellow
                Dim Colore As Color = Colore1
                Dim Polizza As Integer = 0
                For Each row As DataGridViewRow In dgvDettaglioIncassi.Rows
                    If row.Cells("polizza").Value <> Polizza Then
                        If Colore = Colore1 Then
                            Colore = Colore2
                        Else
                            Colore = Colore1
                        End If
                        Polizza = row.Cells("polizza").Value
                    End If
                    For col As Integer = 0 To 9
                        row.Cells(col).Style.BackColor = Colore
                    Next

                    If Year(row.Cells("Data esito").Value) = dtpDataAnalisi.Value.Year Then
                        'anno corrente
                        If row.Cells("Data esito").Value < dtpDataInizioAnalisi.Value Or row.Cells("Data esito").Value > dtpDataAnalisi.Value Then
                            row.Cells("Note").Value = "fuori intervallo"
                        End If
                    Else
                        'anno precedente
                        If row.Cells("Data esito").Value < dtpDataInizioAnalisi.Value.AddYears(-1) Or row.Cells("Data esito").Value > dtpDataAnalisi.Value.AddYears(-1) Then
                            row.Cells("Note").Value = "fuori intervallo"
                        End If
                    End If
                Next

                dgvDettaglioIncassi.Columns("Anno").DefaultCellStyle.BackColor = Color.PeachPuff
            End If

            dgvDettaglioIncassi_CurrentCellChanged(Me, New EventArgs)
            AddHandler dgvDettaglioIncassi.CurrentCellChanged, AddressOf dgvDettaglioIncassi_CurrentCellChanged

            btnEsportaDettaglio.Enabled = True

            'arretrati
            dgvDeltaArretrati.DataSource = Risposta.DataSet.Tables("Arretrati")

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnEsportaDettaglio_Click(sender As System.Object, e As System.EventArgs) Handles btnEsportaDettaglio.Click
        Try
            If dgvDettaglioIncassi.Rows.Count > 0 Then
                Dim NomeFile As String = String.Format("Dettaglio incassi di {0} {1}", dgvDelta.CurrentRow.Cells("Cognome").Value.Trim, dgvDelta.CurrentRow.Cells("Nome").Value.Trim)
                Utx.NetFunc.Esporta2Csv(dgvDettaglioIncassi, NomeFileValido(NomeFile), Color.Khaki)
            End If
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub btnEsportaElenco_Click(sender As System.Object, e As System.EventArgs) Handles btnEsportaElenco.Click
        Try
            If dgvDelta.Rows.Count > 0 Then
                Dim NomeFile As String = String.Format("Elenco variazione incassi {0}", ComboBoxRgDelta.Text)
                Utx.NetFunc.Esporta2Csv(dgvDelta, NomeFileValido(NomeFile), Color.Khaki)
            End If
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub dtpDataAnalisi_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpDataAnalisi.ValueChanged
        Try
            'se l'anno inizio raffronto è maggiore dell'anno analisi lo arretrata fino a renderli uguali
            If Val(cboAnnoInizio.Text) > dtpDataAnalisi.Value.Year Then

                For k As Integer = 0 To cboAnnoInizio.Items.Count - 1
                    If Val(cboAnnoInizio.Items(k)) = dtpDataAnalisi.Value.Year Then
                        cboAnnoInizio.SelectedIndex = k
                        Exit For
                    End If
                Next
            End If
            'se la data analisi è compresa fra il 15/11 e il 31/12 è possibile usare gli arretrati invece degli incassi degli anni precedenti
            'il check viene attivato automaticamente ma l'utente può toglierlo
            If dtpDataAnalisi.Value >= New DateTime(dtpDataAnalisi.Value.Year, 11, 15) AndAlso
               dtpDataAnalisi.Value <= New DateTime(dtpDataAnalisi.Value.Year, 12, 31) Then
                CheckBoxArretrati.Enabled = True
                CheckBoxArretrati.Checked = True
            Else
                CheckBoxArretrati.Enabled = False
                CheckBoxArretrati.Checked = False
            End If
            'se la data selezianata è il 29 febbraio arretra al 28 perchè, 
            'il fatto che l'anno prima il 29 non c'è, genera un errore 
            If dtpDataAnalisi.Value.Month = 2 AndAlso dtpDataAnalisi.Value.Day = 29 Then
                dtpDataAnalisi.Value = dtpDataAnalisi.Value.AddDays(-1)
            End If
            'data inizio analisi
            'se l'anno è diverso
            If (dtpDataInizioAnalisi.Value > dtpDataAnalisi.Value) OrElse (dtpDataAnalisi.Value.Year <> dtpDataInizioAnalisi.Value.Year) Then
                'dtpDataInizioAnalisi.MinDate = #1/1/2000#
                'dtpDataInizioAnalisi.MaxDate = #12/31/2100#
                'dtpDataInizioAnalisi.MinDate = Utx.FunzioniData.InizioAnno(dtpDataAnalisi.Value)
                'dtpDataInizioAnalisi.MaxDate = dtpDataAnalisi.Value
                dtpDataInizioAnalisi.Value = dtpDataAnalisi.Value
            End If

            'per forzare il ricalcolo delle stornate
            OkStornate = False

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub dtpDataInizioAnalisi_ValueChanged(sender As Object, e As EventArgs) Handles dtpDataInizioAnalisi.ValueChanged
        Try
            If (dtpDataInizioAnalisi.Value > dtpDataAnalisi.Value) OrElse (dtpDataAnalisi.Value.Year <> dtpDataInizioAnalisi.Value.Year) Then
                'dtpDataInizioAnalisi.MinDate = #1/1/2000#
                'dtpDataInizioAnalisi.MaxDate = #12/31/2100#
                'dtpDataInizioAnalisi.MinDate = Utx.FunzioniData.InizioAnno(dtpDataAnalisi.Value)
                'dtpDataInizioAnalisi.MaxDate = dtpDataAnalisi.Value
                dtpDataAnalisi.Value = dtpDataInizioAnalisi.Value
            End If
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub cboAnnoInizio_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboAnnoInizio.SelectedIndexChanged
        Try
            If Val(cboAnnoInizio.SelectedItem) > dtpDataAnalisi.Value.Year Then

                For k As Integer = 0 To cboAnnoInizio.Items.Count - 1
                    If Val(cboAnnoInizio.Items(k)) = dtpDataAnalisi.Value.Year Then
                        cboAnnoInizio.SelectedIndex = k
                        Exit For
                    End If
                Next
            End If

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub btnGestione_Click(sender As System.Object, e As System.EventArgs) Handles btnGestione.Click
        Try
            Using f As New frmAttivazione
                f.ShowDialog()

                Me.Refresh()
                Me.Cursor = Cursors.WaitCursor

                Using s As New Utx.BudgetOMW.ServizioBudget With {.Proxy = Utx.Globale.UniProxy.Proxy}
                    s.SettingBudget(CodiceSelezionato, Utx.Globale.Token)
                End Using
                ImpostaBudgetGruppi()
                ImpostaComboFigure()
            End Using

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub LeggiElencoArretrati()
        Try
            Cursor.Current = Cursors.WaitCursor

            dgvArretrati.DataSource = Nothing
            RemoveHandler dgvArretrati.ColumnHeaderMouseClick, AddressOf dgvArretrati_ColumnHeaderMouseClick

            Dim ClausolaWhere As String = " 1=1 "
            If txtCercaArretrati.Text.Length > 0 Then
                ClausolaWhere = String.Format(" Cognome LIKE '%{0}%' ", txtCercaArretrati.Text.Trim.ToUpper)
            End If

            Dim Query As String = String.Format("SELECT Incassabile,C.RgDesk AS RamoGestione,C.CompartoDesk AS Comparto,
                Ramo,Polizza,EffettoTitolo,TipoCarico,TRIM(Cognome) + Space(1) + TRIM(Nome) AS Contraente,TotaleTitolo,Tassabile,
                PremioRC,PrINF,(PrIF+PrKasko+PrAssistenza) AS PremioARD,PrvAcq+PrvInc AS Provvigioni,Prodotto,Subagenzia,Convenzione,
                Delegataria,Targa,Unibox 
                FROM Arretrati 
                INNER JOIN Codici1023 AS C ON C.RamoGestione = Arretrati.RamoGestione
                WHERE {0}
                ORDER BY EffettoTitolo", ClausolaWhere)

            dgvArretrati.DataSource = Utx.WsCommand.ExecuteNonQuery(Query).DataTable
            Utx.NetFunc.BloccaOrdinamento(dgvArretrati)

            FormattaElencoArretrati()
            dgvArretrati.Focus()

            Arretrati.Text = String.Format("Arretrati ({0}/{1})", ContaIncassabili, dgvArretrati.Rows.Count)

            AddHandler dgvArretrati.ColumnHeaderMouseClick, AddressOf dgvArretrati_ColumnHeaderMouseClick

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ControlloArretrati()
        Try
            Cursor.Current = Cursors.WaitCursor
            If Utx.WsCommand.ExecuteScalar("SELECT SUM(PremioRC+PrINF+PrIF+PrKasko+PrAssistenza) FROM Arretrati").Valore = 0 Then
                MsgBox("Attenzione: è probabilmente necessario aggiornare gli arretrati per allinearli alle nuove impostazioni.",
                       MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            End If
        Catch ex As Exception
            Log.Errore(ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function ArretratiRamoGestione(Optional FinoAl As Date = Nothing) As DataTable
        Try
            Cursor.Current = Cursors.WaitCursor

            dgvArretrati.DataSource = Nothing

            ControlloArretrati()

            If FinoAl = Nothing Then
                FinoAl = Utx.FunzioniData.FineAnno(dtpDataAnalisi.Value.Year)
            End If

            Dim Query As String = String.Format("SELECT A.RamoGestione,C.RgDesk AS Descrizione,SUM(A.Tassabile) AS Premi,SUM(PremioRC) AS RC,
                SUM(PrINF) AS INF,SUM(PrIF+PrKasko+PrAssistenza) AS ARD,0.00 AS DiCui,SUM(PrvAcq+PrvInc) AS Provvigioni 
                FROM Arretrati AS A
                INNER JOIN Codici1023 AS C ON A.RamoGestione = C.RamoGestione
                WHERE (CAST(A.Incassabile AS bit) = 1) AND (A.EffettoTitolo <= '{0:dd/MM/yyyy}') AND ({1})
                GROUP BY A.RamoGestione,C.RgDesk
                ORDER BY A.RamoGestione", FinoAl, FiguraSelezionata.ClausolaINArretrati())

            Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteNonQuery(Query)
            If Risposta IsNot Nothing Then
                Dim Infortuni As Double = 0
                Dim Ard As Double = 0

                For Each r As DataRow In Risposta.DataTable.Rows
                    Select Case r("Ramogestione")
                        Case 1
                            Infortuni = r("INF")
                            Ard = r("ARD")
                            r("Premi") = r("RC")
                        Case 2
                            r("Premi") += Ard
                            r("DiCui") = Ard
                        Case 3
                            r("Premi") += Infortuni
                            r("DiCui") = Infortuni
                            Exit For
                    End Select
                Next
            End If
            Return Risposta.DataTable

        Catch ex As Exception
            Log.Errore(ex)
            Return Nothing
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Sub ArretratiPerRg()
        Try
            Cursor.Current = Cursors.WaitCursor
            RemoveHandler dgvArretrati.ColumnHeaderMouseClick, AddressOf dgvArretrati_ColumnHeaderMouseClick

            dgvArretrati.DataSource = Nothing
            dgvArretrati.DataSource = ArretratiRamoGestione()
            Utx.NetFunc.BloccaOrdinamento(dgvArretrati)

            FormattaArretratiRg()
            dgvArretrati.Focus()

            AddHandler dgvArretrati.ColumnHeaderMouseClick, AddressOf dgvArretrati_ColumnHeaderMouseClick

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ArretratiPerComparto()
        Try
            Cursor.Current = Cursors.WaitCursor
            RemoveHandler dgvArretrati.ColumnHeaderMouseClick, AddressOf dgvArretrati_ColumnHeaderMouseClick

            dgvArretrati.DataSource = Nothing

            Dim Query As String = String.Format("SELECT A.Comparto,UPPER(C.CompartoDesk) AS Descrizione,SUM(A.Tassabile) AS Premi,
                SUM(PrvAcq + PrvInc) AS Provvigioni 
                FROM Arretrati AS A
                INNER JOIN Codici1023 AS C ON A.Comparto = C.Comparto
                WHERE (CAST(A.Incassabile AS bit) = 1) AND (A.EffettoTitolo <= '{0:dd/MM/yyyy}') 
                GROUP BY A.Comparto, C.CompartoDesk 
                ORDER BY A.Comparto", Utx.FunzioniData.FineAnno(dtpDataAnalisi.Value.Year))

            Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteNonQuery(Query)
            If Risposta IsNot Nothing Then
                Dim dtRG As DataTable = ArretratiRamoGestione()

                Dim Infortuni As Double = 0
                'rilevo la parte infortuni nell'auto
                For Each r As DataRow In dtRG.Rows
                    If r("RamoGestione") = 1 Then 'rc
                        Infortuni = r("INF")
                        Exit For
                    End If
                Next
                'sposto gli infortuni al comparto 2
                For Each r As DataRow In Risposta.DataTable.Rows
                    If r("Comparto") = 2 Then
                        r("Premi") += Infortuni
                    End If
                Next

                dgvArretrati.DataSource = Risposta.DataTable
                Utx.NetFunc.BloccaOrdinamento(dgvArretrati)

                FormattaArretratiComparto()
                dgvArretrati.Focus()
            End If

            AddHandler dgvArretrati.ColumnHeaderMouseClick, AddressOf dgvArretrati_ColumnHeaderMouseClick

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function ContaIncassabili() As Integer
        Try
            Dim ClausolaWhere As String
            If txtCercaArretrati.Text.Length = 0 Then
                ClausolaWhere = " True "
            Else
                ClausolaWhere = String.Format(" Cognome LIKE '{0}%' ", txtCercaArretrati.Text.Trim.ToUpper)
            End If

            Dim sql As String = String.Format("SELECT Count(*) FROM Arretrati WHERE Incassabile = True AND {0}", ClausolaWhere)
            ContaIncassabili = Utx.FunzioniDb.ExecuteScalar(sql)

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Function

    Private Sub btnElencoArretrati_Click(sender As System.Object, e As System.EventArgs) Handles btnElencoArretrati.Click
        If dgvArretrati.IsCurrentRowDirty Then SalvaFlag()
        LeggiElencoArretrati()
    End Sub

    Private Sub btnArretratiRg_Click(sender As System.Object, e As System.EventArgs) Handles btnArretratiRg.Click
        If dgvArretrati.IsCurrentRowDirty Then SalvaFlag()
        ArretratiPerRg()
    End Sub

    Private Sub btnArretratiComparto_Click(sender As System.Object, e As System.EventArgs) Handles btnArretratiComparto.Click
        If dgvArretrati.IsCurrentRowDirty Then SalvaFlag()
        ArretratiPerComparto()
    End Sub

    Private Sub FormattaElencoArretrati()
        On Error Resume Next

        With dgvArretrati
            .SuspendLayout()

            .Columns("EffettoTitolo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("EffettoTitolo").HeaderText = "Effetto titolo"
            .Columns("TipoCarico").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("TipoCarico").HeaderText = "Tipo carico"
            With .Columns("Comparto")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = Color.Moccasin
            End With
            With .Columns("RamoGestione")
                .HeaderText = "Ramo gestione"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = Color.Lavender
            End With
            .Columns("Ramo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Prodotto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Convenzione").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Delegataria").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            With .Columns("TotaleTitolo")
                .HeaderText = "Totale titolo"
                .DefaultCellStyle.Format = "##,###,##0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.BackColor = Color.LightYellow
            End With
            .Columns("Tassabile").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Tassabile").DefaultCellStyle.Format = "##,###,##0.00"
            .Columns("Provvigioni").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Provvigioni").DefaultCellStyle.Format = "##,###,##0.00"
            .Columns("Subagenzia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Subagenzia").HeaderText = "Sub"
            With .Columns("PremioRC")
                .HeaderText = "Premio RC"
                .DefaultCellStyle.Format = "##,###,##0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.BackColor = Color.Gainsboro
            End With
            With .Columns("PrINF")
                .HeaderText = "Premio infortuni"
                .DefaultCellStyle.Format = "##,###,##0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.BackColor = Color.Gainsboro
            End With
            With .Columns("PremioARD")
                .HeaderText = "Premio ARD"
                .DefaultCellStyle.Format = "##,###,##0.00"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.BackColor = Color.Gainsboro
            End With
            .AutoResizeColumns()

            .ResumeLayout()
        End With
    End Sub

    Private Sub FormattaArretratiComparto()
        'On Error Resume Next

        With dgvArretrati
            .SuspendLayout()

            .Columns("Comparto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Descrizione").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            With .Columns("Premi")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
                .HeaderText = "Tassabile da incassare"
            End With
            With .Columns("Provvigioni")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
            End With
            .AutoResizeColumns()
            .ResumeLayout()
        End With
    End Sub

    Private Sub FormattaArretratiRg()
        On Error Resume Next

        With dgvArretrati
            .SuspendLayout()

            With .Columns("RamoGestione")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Ramo gestione"
            End With
            .Columns("Descrizione").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            With .Columns("Premi")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
                .HeaderText = "Tassabile da incassare"
            End With
            With .Columns("Provvigioni")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
            End With
            With .Columns("DiCui")
                .HeaderText = "Di cui da polizze RCA"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "##,###,##0.00"
                .DefaultCellStyle.BackColor = Color.Gainsboro
            End With
            .Columns("RC").Visible = False
            .Columns("INF").Visible = False
            .Columns("ARD").Visible = False

            .AutoResizeColumns()

            .ResumeLayout()
        End With
    End Sub

    Private Sub SalvaFlag()
        Try
            Dim Query As String = String.Format("UPDATE Arretrati 
                SET Incassabile = CAST({0} as bit) 
                WHERE (Ramo = {1}) AND (Polizza = {2}) AND (EffettoTitolo = '{3}')",
                        IIf(dgvArretrati.CurrentRow.Cells("Incassabile").EditedFormattedValue = True, 1, 0),
                        dgvArretrati.CurrentRow.Cells("Ramo").Value,
                        dgvArretrati.CurrentRow.Cells("Polizza").Value,
                        dgvArretrati.CurrentRow.Cells("EffettoTitolo").Value)
            Utx.WsCommand.ExecuteNonQueryRecord(Query)
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub dgvArretrati_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs)
        If dgvArretrati.Columns(0).DataPropertyName <> "Incassabile" Then e.Cancel = True
        If e.ColumnIndex > 0 Then e.Cancel = True
    End Sub

    Private Sub dgvArretrati_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvArretrati.CellEndEdit
        SalvaFlag()
    End Sub

    Private Sub btnCerca_Click(sender As System.Object, e As System.EventArgs) Handles btnCerca.Click
        If dgvArretrati.IsCurrentRowDirty Then SalvaFlag()
        LeggiElencoArretrati()
        txtCercaArretrati.Focus()
    End Sub

    Private Sub AzzeraCampi(ByRef dt As DataTable)
        On Error Resume Next

        For Each r As DataRow In dt.Rows
            r("IncassoAnnuo") = 0
            r("IncrementoAtteso") = 0
            r("Differenza") = 0
            r("ImportoDiff") = 0
            r("Atteso") = 0
            r("Scostamento") = 0
            r("ScostamentoPerc") = 0
            r("Avanzamento") = 0
            r("DaIncassare") = 0
            r("TotaleSenzaPU") = 0
            r("AvanzamentoSenzaPU") = 0
            r("DaIncassarePU") = 0
            r("TotaleConPU") = 0
            r("AvanzamentoConPU") = 0
            r("PIncassate") = 0
            r("QIncassate") = 0
            r("DiffProvPerc") = 0
            r("Redditivita") = 0
            'la colonna esiste solo in ramogestione
            If dt.TableName = "Rg" Then
                r("MediaIncasso") = 0
                r("DiCui") = 0
            End If
        Next
    End Sub

    Private Sub AggregaDati()
        Try
            Dim Tabelle() As String = {"Comparto", "Settore", "Aggregato", "Generale"}
            'per tutte le tabelle in elenco
            For Each Tabella As String In Tabelle

                'creo una nuova tabella con la stessa struttura di rg e nome "Tabella"
                Dim NewTable As DataTable = ds.Tables("Rg").Clone
                NewTable.TableName = Tabella
                'e la aggiungo al dataset
                ds.Tables.Add(NewTable)
                NewTable.Dispose()

                'creo una chiave per la ricerca
                ds.Tables(Tabella).PrimaryKey = {ds.Tables(Tabella).Columns("Anno"), ds.Tables(Tabella).Columns(Tabella)}

                'campi da aggregare
                Dim Campi() As String = {"IncassoAnnuo", "BudgetAnnuo", "TotaleAlMese", "QIncassate", "PIncassate", "Atteso",
                                         "Scostamento", "DaIncassare", "TotaleSenzaPU", "DaIncassarePU", "TotaleConPU", "Provvigioni"}

                For Each dr As DataRow In ds.Tables("Rg").Rows

                    'cerco la chiave nella nuova tabella
                    Dim drDest As DataRow = ds.Tables(Tabella).Rows.Find({dr("Anno"), dr(Tabella)})

                    'se non esiste aggiungo la riga
                    If drDest Is Nothing Then
                        'è importante caricare i dati usando LoadDataRow e non utilizzando il metodo add
                        'che conserva una qualche relazione con l'oggetto originale creando degli strani effetti
                        'e poi bisogna valorizzare solo i campi presenti in campi()
                        'creo una riga vuota con tutti i campi a zero
                        Dim row As DataRow = ds.Tables("Rg").NewRow
                        For k As Integer = 0 To ds.Tables("Rg").Columns.Count - 1
                            row(k) = 0 'azzero per non avere problemi con la somma di null
                        Next
                        'inserisco la chiave
                        row("Anno") = dr("Anno")
                        row(Tabella) = dr(Tabella)
                        'copio i dati da aggregare
                        For k As Integer = 0 To Campi.GetUpperBound(0)
                            row(Campi(k)) = dr(Campi(k))
                        Next
                        'copio i campi dei mesi
                        For k As Integer = 1 To dtpDataAnalisi.Value.Month
                            row(k.ToString) = dr(k.ToString)
                        Next
                        'inserisco la riga nella tabella
                        ds.Tables(Tabella).LoadDataRow(row.ItemArray, True)
                    Else
                        'altrimenti sommo i campi
                        For k As Integer = 0 To Campi.GetUpperBound(0)
                            drDest(Campi(k)) += dr(Campi(k))
                        Next
                        'sommo i campi dei mesi
                        For k As Integer = 1 To dtpDataAnalisi.Value.Month
                            drDest(k.ToString) += dr(k.ToString)
                        Next
                    End If
                Next
            Next

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub CancellaColonne()
        On Error Resume Next

        'cancello le colonne che non mi servono in Rg
        With ds
            With .Tables("Rg").Columns
                .Remove("Comparto")
                .Remove("Settore")
                .Remove("Aggregato")
                .Remove("Generale")
                .Remove("ProvCAV")
                .Remove("ProvINF")
                .Remove("ProvARD")
            End With
            With .Tables("Comparto").Columns
                .Remove("RamoGestione")
                .Remove("Settore")
                .Remove("Aggregato")
                .Remove("Generale")
                .Remove("MediaIncasso")
                .Remove("DiCui")
                .Remove("ProvCAV")
                .Remove("ProvINF")
                .Remove("ProvARD")
            End With
            With .Tables("Settore").Columns
                .Remove("RamoGestione")
                .Remove("Comparto")
                .Remove("Aggregato")
                .Remove("Generale")
                .Remove("MediaIncasso")
                .Remove("DiCui")
                .Remove("ProvCAV")
                .Remove("ProvINF")
                .Remove("ProvARD")
            End With
            With .Tables("Aggregato").Columns
                .Remove("RamoGestione")
                .Remove("Comparto")
                .Remove("Settore")
                .Remove("Generale")
                .Remove("MediaIncasso")
                .Remove("DiCui")
                .Remove("ProvCAV")
                .Remove("ProvINF")
                .Remove("ProvARD")
            End With
            With .Tables("Generale").Columns
                .Remove("RamoGestione")
                .Remove("Comparto")
                .Remove("Settore")
                .Remove("Aggregato")
                .Remove("MediaIncasso")
                .Remove("DiCui")
                .Remove("ProvCAV")
                .Remove("ProvINF")
                .Remove("ProvARD")
            End With
        End With
    End Sub

    Private Sub ElaboraRca()
        Try
            'ramogestione: 1=rca, 2=ard, 3=inf
            Dim RigaRg1, RigaRg2, RigaRg3 As Integer

            With ds.Tables("Rg")

                If .Rows.Count > 0 Then
                    'per ogni anno
                    For Anno As Integer = AnnoInizio To AnnoAnalisi

                        'recupero l'indice di riga per quell'anno dei rami gestione 1/2/3
                        For k As Integer = 0 To ds.Tables("Rg").Rows.Count - 1

                            If .Rows(k).Item("Anno") = Anno Then

                                If .Rows(k).Item("RamoGestione") = 1 Then RigaRg1 = k
                                If .Rows(k).Item("RamoGestione") = 2 Then RigaRg2 = k
                                If .Rows(k).Item("RamoGestione") = 3 Then RigaRg3 = k

                                'azzero il campo dicui per rami gestione diversi da 2 e 3
                                If .Rows(k).Item("RamoGestione") < 2 OrElse .Rows(k).Item("RamoGestione") > 3 Then
                                    .Rows(RigaRg1).Item("DiCui") = 0
                                End If
                            End If
                        Next

                        'sistemo le partire RCA/ARD/INF
                        If .Rows(RigaRg1).Item("Anno") >= 2013 Then
                            'premi
                            .Rows(RigaRg1).Item("TotaleAlMese") = .Rows(RigaRg1).Item("TotaleRCA")
                            .Rows(RigaRg2).Item("TotaleAlMese") += .Rows(RigaRg1).Item("TotaleARD") 'ARD proveniente dalla riga 1 (rca)
                            .Rows(RigaRg3).Item("TotaleAlMese") += .Rows(RigaRg1).Item("TotaleINF") + .Rows(RigaRg2).Item("TotaleINF") 'INF proveniente dalle righe 1 e 2 (rca e ard)

                            .Rows(RigaRg2).Item("DiCui") = .Rows(RigaRg1).Item("TotaleARD")
                            .Rows(RigaRg3).Item("DiCui") = .Rows(RigaRg1).Item("TotaleINF") + .Rows(RigaRg2).Item("TotaleINF")
                            'provvigioni
                            'per il rg 1 aggiungo il CAV e tolgo INF e ARD già sommati in provvigioni
                            .Rows(RigaRg1).Item("Provvigioni") += (.Rows(RigaRg1).Item("ProvCAV") - .Rows(RigaRg1).Item("ProvINF") - .Rows(RigaRg1).Item("ProvARD"))
                            .Rows(RigaRg2).Item("Provvigioni") += .Rows(RigaRg1).Item("ProvARD") 'aggiungo ARD da rg 1
                            .Rows(RigaRg3).Item("Provvigioni") += .Rows(RigaRg1).Item("ProvINF") + .Rows(RigaRg2).Item("ProvINF") 'aggiungo INF da rg 1 e 2
                        End If
                    Next
                End If

                'cancello le colonne che non mi servono più
                .Columns.Remove("TotaleRCA")
                .Columns.Remove("TotaleARD")
                .Columns.Remove("TotaleINF")
            End With

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub CancellaAnniPrecedenti()
        Try
            Dim Tabelle() As String = {"Rg", "Comparto", "Settore", "Aggregato", "Generale"}

            'per tutte le tabelle in elenco
            For Each tbl As String In Tabelle

                'Dim f As New Utx.FormDebug(ds.Tables(tbl))
                'f.ShowDialog()

                For Each r As DataRow In ds.Tables(tbl).Rows
                    'cancello la riga se l'anno è precedente all'anno di inizio analisi
                    If r("Anno") < cboAnnoInizio.Text Then
                        r.Delete()
                    End If
                Next

                ds.Tables(tbl).AcceptChanges()
            Next

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub dgvDettaglioIncassi_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvDettaglioIncassi.CellFormatting
        On Error Resume Next
        If e.ColumnIndex = dgvDettaglioIncassi.ColumnCount - 2 Then
            If e.Value = dtpDataAnalisi.Value.Year Then e.CellStyle.BackColor = Color.LightSalmon
        End If
    End Sub

    Private Sub ImpostaAggregati()
        Try
            Globale.RgToComparto.PrimaryKey = {Globale.RgToComparto.Columns("RamoGestione")}

            For Each dr As DataRow In ds.Tables("Rg").Rows

                Dim r As DataRow = Globale.RgToComparto.Rows.Find({dr("RamoGestione")})

                If r IsNot Nothing Then
                    dr("Comparto") = r("Comparto")
                    dr("Settore") = r("Settore")
                    dr("Aggregato") = r("Aggregato")
                    dr("Generale") = r("Generale")
                Else
                    MsgBox("Impostazione aggregati non riuscita", MsgBoxStyle.Exclamation, "Budget")
                End If
            Next
            Globale.RgToComparto.PrimaryKey = Nothing

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub AgganciaEventiGriglie()
        AddHandler dgvRamoGestione.CellLeave, AddressOf dgvRamoGestione_CellLeave
        AddHandler dgvRamoGestione.CurrentCellChanged, AddressOf dgvRamoGestione_CurrentCellChanged
        AddHandler dgvRamoGestione.SelectionChanged, AddressOf dgvRamoGestione_SelectionChanged
        AddHandler dgvComparto.SelectionChanged, AddressOf dgvComparto_SelectionChanged
        AddHandler dgvSettore.SelectionChanged, AddressOf dgvSettore_SelectionChanged
        AddHandler dgvAggregato.SelectionChanged, AddressOf dgvAggregato_SelectionChanged
        AddHandler dgvGenerale.SelectionChanged, AddressOf dgvGenerale_SelectionChanged
    End Sub

    Private Sub RimuoviEventiGriglie()
        RemoveHandler dgvRamoGestione.CurrentCellChanged, AddressOf dgvRamoGestione_CurrentCellChanged
        RemoveHandler dgvRamoGestione.CellLeave, AddressOf dgvRamoGestione_CellLeave
        RemoveHandler dgvRamoGestione.SelectionChanged, AddressOf dgvRamoGestione_SelectionChanged
        RemoveHandler dgvComparto.SelectionChanged, AddressOf dgvComparto_SelectionChanged
        RemoveHandler dgvSettore.SelectionChanged, AddressOf dgvSettore_SelectionChanged
        RemoveHandler dgvAggregato.SelectionChanged, AddressOf dgvAggregato_SelectionChanged
        RemoveHandler dgvGenerale.SelectionChanged, AddressOf dgvGenerale_SelectionChanged
    End Sub

    Private Function TotaleAnomalieAuto() As Double
        Try
            Dim Query As String = String.Format("SELECT (SUM(Tassabile) - (SUM(PremioRC) + SUM(PrINF) + SUM(PremioARD))) 
                FROM LinkIncassi AS I 
                INNER JOIN (SELECT DISTINCT Ramo FROM Incassi WHERE RamoGestione IN (1,2)) AS R 
                ON I.Ramo = R.Ramo 
                WHERE ABS(Tassabile - (PremioRC + PrINF + PremioARD)) > 0.5 AND YEAR(DataFoglioCassa) = {0} AND {1}",
                                                dtpDataAnalisi.Value.Year, Incorporata)

            Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteScalar(Query)

            If IsNumeric(Risposta.Valore) Then
                Return Risposta.Valore
            Else
                Return 0
            End If

        Catch ex As Exception
            Log.Errore(ex)
            Return 0
        End Try
    End Function

    Private Sub VisualizzaAnomalieAuto()
        Try
            tssStato.Text = "Analisi in corso..."

            With TextBoxAnomalie
                .ReadOnly = True
                .BackColor = Color.Gainsboro
                .ScrollBars = ScrollBars.Vertical
            End With
            'label di aiuto
            Dim Testo As New StringBuilder
            With Testo
                .Append("Dal 2013, con il nuovo formato incassi scaricato da Essig e con i dati disaggregati per garanzia ")
                .AppendLine("si è evidenziata un'anomalia: nei dati scaricati da Essig, in alcuni casi, il tassabile (A) è diverso dalla somma delle singole garanzie (B/C/D) come è possibile vedere dalla tabella.")
                .AppendLine()
                .AppendLine("Il problema è limitato al ramo auto (rami 30/130/131/132 - rami gestione 1/2), dove è necessario disaggregare il tassabile nelle singole garanzie, e riguarda principalmente le polizze cumulative.")
                .AppendLine()
                .Append("Unitools evidenzia qui sopra le differenze riscontrate raggruppate per polizza. ")
                .AppendLine("Poiché si tratta quasi sempre di polizze multi-garanzia, non è dato sapere quanta parte del tassabile è da attribuire ai singoli rami gestione 1, 2 e 3.")
                .AppendLine()
                .Append("Poiché ognuno di voi conosce la composizione del proprio portafoglio e le modalità con cui, abitualmente, si stipulano questi contratti, affidiamo a voi la valutazione di questo dato. ")
                .Append("Si tratta in sostanza di capire come suddividere le differenze, non contabilizzate nell'analisi, fra le partite RC/ARD/INF e attribuirle ai rispettivi rami gestione (1/2/3).")
            End With

            TextBoxAnomalie.Text = String.Format(Testo.ToString)
            TextBoxAnomalie.Refresh()

            Try
                If ds.Tables("Anomalie") IsNot Nothing Then
                    ds.Tables("Anomalie").Clear()
                End If
            Catch ex As Exception
            End Try

            Dim Query As String = String.Format("SELECT STR(RamoGestione) AS RamoGestione,I.Ramo,Polizza,YEAR(DataFoglioCassa) AS Anno,
                SUM(Tassabile) As Tassabile,SUM(PremioRC) As RC,SUM(PrINF) As INF,SUM(PremioARD) As ARD,
                (SUM(Tassabile) - (SUM(PremioRC) + SUM(PrINF) + SUM(PremioARD))) AS Differenza 
                FROM LinkIncassi AS I
                INNER JOIN (SELECT DISTINCT Ramo FROM Incassi WHERE RamoGestione IN (1,2)) AS R 
                ON I.Ramo = R.Ramo 
                WHERE ABS(Tassabile - (PremioRC + PrINF + PremioARD)) > 0.5 AND YEAR(DataFoglioCassa) = {0} 
                GROUP BY YEAR(DataFoglioCassa),RamoGestione,I.Ramo,Polizza
                ORDER BY I.Ramo", dtpDataAnalisi.Value.Year)

            Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteNonQuery(Query)
            Risposta.DataTable.TableName = "Anomalie"
            ds.Tables.Add(Risposta.DataTable)

            'calcolo il totale
            Dim Totale As Double = 0

            For Each dr As DataRow In ds.Tables("Anomalie").Rows
                Totale += dr("Differenza")
            Next

            ds.Tables("Anomalie").Rows.Add({"Totale",
                                            DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value,
                                            DBNull.Value, DBNull.Value, DBNull.Value, Totale})

            With dgvAnomalie
                .DataSource = Nothing
                .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.None)
                .DataSource = ds.Tables("Anomalie")

                .AllowUserToAddRows = False

                With .Columns("RamoGestione")
                    .HeaderText = String.Format("Ramo{0}gestione", Environment.NewLine)
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .DefaultCellStyle.Font = Utx.AppFont.Bold
                End With
                With .Columns("Ramo")
                    .HeaderText = String.Format("Ramo{0}polizza", Environment.NewLine)
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .DefaultCellStyle.Font = Utx.AppFont.Bold
                End With
                .Columns("Polizza").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Anno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                With .Columns("Tassabile")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "##,###,##0.00"
                    .HeaderText = String.Format("Tassabile{0}totale (A)", Environment.NewLine)
                End With
                With .Columns("RC")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "##,###,##0.00"
                    .DefaultCellStyle.BackColor = Color.LightYellow
                    .HeaderText = String.Format("Tassabile{0}RC (B)", Environment.NewLine)
                End With
                With .Columns("INF")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "##,###,##0.00"
                    .DefaultCellStyle.BackColor = Color.LightYellow
                    .HeaderText = String.Format("Tassabile{0}INF (C)", Environment.NewLine)
                End With
                With .Columns("ARD")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "##,###,##0.00"
                    .DefaultCellStyle.BackColor = Color.LightYellow
                    .HeaderText = String.Format("Tassabile{0}ARD (D)", Environment.NewLine)
                End With
                With .Columns("Differenza")
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .DefaultCellStyle.Format = "##,###,##0.00"
                    .DefaultCellStyle.BackColor = Color.LightSalmon
                    .HeaderText = String.Format("Differenza{0}(A-B-C-D)", Environment.NewLine)
                End With

                .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            End With

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            tssStato.Text = ""
        End Try
    End Sub

    Private Sub VisualizzaRegistro()
        tssStato.Text = "Registro importazioni"
        dgvRegistro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.None

        Try
            dgvRegistro.DataSource = Nothing
            If ds.Tables("Registro") IsNot Nothing Then
                ds.Tables.Remove("Registro")
            End If
        Catch ex As Exception
            'non fare niente: la tabella potrebbe non esistere
        End Try

        Try
            'importazioni degli ultimi 7 giorni
            Dim Query As String = "SELECT * FROM Registro 
                    WHERE (DATEDIFF(day,Importazione,GETDATE())) <= 7 ORDER BY Importazione DESC"

            dgvRegistro.DataSource = Utx.WsCommand.ExecuteNonQuery(Query).DataTable
        Catch ex As Exception
            Log.Errore(ex)
        End Try

        Try
            With dgvRegistro
                .AllowUserToAddRows = False

                With .Columns("Importazione")
                    .HeaderText = "Importazione del"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                End With
                .Columns("Errore").DefaultCellStyle.BackColor = Color.Moccasin
                .Columns("Agenzia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Giorno").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Descrizione").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                With .Columns("TotaleEssig")
                    .HeaderText = "da Essig"
                    .DefaultCellStyle.Format = "###,###,##0.00"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns("TotaleDownload")
                    .HeaderText = "da flusso dati"
                    .DefaultCellStyle.Format = "###,###,##0.00"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                With .Columns("Differenza")
                    .DefaultCellStyle.Format = "###,###,##0.00"
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End With
                .Columns("Tipo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
        Catch ex As Exception
            Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
            tssStato.Text = ""
        End Try
    End Sub

    Private Sub GiornateLavorative()
        Try
            Dim Query As String = String.Format("SELECT Year(DataFoglioCassa) AS Anno,COUNT(*) AS Giornate,
                        SUM(Totale) AS Incassato,SUM(Totale)/COUNT(*) AS Media 
                        FROM (SELECT DataFoglioCassa,SUM(Tassabile) AS Totale 
                        FROM Incassi 
                        WHERE (MONTH(DataFoglioCassa) < {0}) OR 
                        (MONTH(DataFoglioCassa) = {0} AND DAY(DataFoglioCassa) <= {1}) 
                        GROUP BY DataFoglioCassa) AS A
                        GROUP BY year(DataFoglioCassa)", dtpDataAnalisi.Value.Month, dtpDataAnalisi.Value.Day)

            Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteNonQuery(Query)
            If Risposta IsNot Nothing Then
                dgvGiornate.DataSource = Risposta.DataTable

                With dgvGiornate
                    With .Columns("Anno")
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .DefaultCellStyle.BackColor = Color.Moccasin
                    End With
                    With .Columns("Giornate")
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .HeaderText = String.Format("Giornate con incassi al {0}", Format(dtpDataAnalisi.Value, "dd/MM"))
                    End With
                    With .Columns("Incassato")
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .DefaultCellStyle.Format = "##,###,##0.00"
                        .HeaderText = "Totale incassato nel periodo"
                    End With
                    With .Columns("Media")
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .DefaultCellStyle.Format = "##,###,##0.00"
                        .HeaderText = "Media giornaliera"
                        .DefaultCellStyle.BackColor = Color.Lavender
                    End With

                    .AutoResizeColumns()
                End With
            End If

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub dgvRamoGestione_CellLeave(sender As Object, e As EventArgs)
        If dgvRamoGestione.CurrentRow IsNot Nothing Then
            dgvRamoGestione.CurrentRow.HeaderCell.Value = ""
        End If
    End Sub

    Private Sub dgvRamoGestione_CurrentCellChanged(sender As Object, e As EventArgs)
        If dgvRamoGestione.CurrentRow IsNot Nothing Then
            dgvRamoGestione.CurrentRow.HeaderCell.Value = "Dettaglio"
        End If
    End Sub

    Private Sub dgvRamoGestione_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvRamoGestione.RowHeaderMouseClick
        If AnalisiGruppo() = True Then
            MsgBox("Il dettaglio delle polizze è disponibile solo per il singolo codice", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
        Else
            Using f As New FormDettaglioRg
                f.CodiceSelezionato = CodiceSelezionato
                f.RamoGestione = dgvRamoGestione.CurrentRow.Cells(0).Value
                f.Anno = dgvRamoGestione.CurrentRow.Cells("Anno").Value
                f.DataInizioAnalisi = dtpDataInizioAnalisi.Value
                f.DataAnalisi = dtpDataAnalisi.Value
                f.CLausolaSub = Figura
                f.ClausolaIncorporata = Incorporata()
                f.ShowDialog()
            End Using
        End If
    End Sub

#Region "Pezzi"
    Private Sub VisualizzaPezzi()
        If tsPezzi.Tag = False Then

            dgvMovimenti.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            ImpostaToolStripPezzi()
            AggiornaPezzi()

            AddHandler ComboBoxTipoCarico.SelectedIndexChanged, AddressOf ComboBoxTipoCarico_SelectedIndexChanged

            dgvMovimenti.Focus()
        End If
    End Sub

    Private Sub AggiornaPezzi()
        Try
            Cursor = Cursors.WaitCursor

            dgvMovimenti.DataSource = Nothing
            dgvMovimenti.Refresh()

            LabelDataPezzi.Text = String.Format(" al {0:d} ", dtpDataAnalisi.Value)

            Dim Query As String = String.Format("DECLARE
                @cols nvarchar(max),
                @sql nvarchar(max)

                SELECT @cols = ISNULL(@cols + ', ', '') + '[' + TRIM(STR(T.Anno)) + ']' FROM 
                    (SELECT DISTINCT TOP 10 YEAR(DataFoglioCassa) AS Anno FROM Incassi ORDER BY YEAR(DataFoglioCassa) DESC) AS T

                SET @sql = '
                SELECT * FROM 
                (
                SELECT COUNT(*) AS Nr,I.RamoGestione, R.DescRamoGest As Descrizione,Space(0) AS Perc,YEAR(DataFoglioCassa) AS Anno
                FROM Incassi AS I 
                INNER JOIN (SELECT RamoGestione,DescRamoGest FROM DB00000.dbo.RamoGest) AS R 
                ON I.RamoGestione = R.RamoGestione 
                WHERE (TipoCarico = {0}) AND (Format(DataFoglioCassa,''MMdd'')) <= ''{1:MMdd}''
                GROUP BY YEAR(DataFoglioCassa),I.RamoGestione, R.DescRamoGest, TipoCarico 
                ) AS A 
                PIVOT
                (
                SUM(A.Nr)
                FOR A.Anno IN 
                (' + @cols + ')
                ) AS B
                ORDER BY RamoGestione'

                EXECUTE sp_executesql @sql", ComboBoxTipoCarico.Text.Substring(0, 1), dtpDataAnalisi.Value)

            Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteNonQuery(Query)
            If Risposta IsNot Nothing Then
                Dim dt As DataTable = Risposta.DataTable

                For Each row As DataRow In dt.Rows
                    For i As Integer = 3 To dt.Columns.Count - 1
                        If row(i) Is DBNull.Value Then
                            row(i) = 0
                        End If
                    Next

                    If row(4) = 0 Then
                        row(2) = "-"
                    Else
                        row(2) = String.Format("{0: +##0.0%;-##0.0%;-}", (row(3) / row(4) - 1))
                    End If
                Next

                dgvMovimenti.DataSource = dt
                FormattaPezzi()

                dgvMovimenti.Focus()
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ImpostaToolStripPezzi()
        On Error Resume Next

        With tsPezzi
            .GripStyle = ToolStripGripStyle.Hidden
            .BackColor = Color.Gold
            .Items.Clear()
        End With

        Dim ttch As ToolStripControlHost

        tsPezzi.Items.Add("Tipo carico")
        With ComboBoxTipoCarico
            .AutoSize = False
            .Width = 200
            .DropDownStyle = ComboBoxStyle.DropDownList

            ImpostaTipoCarico()
        End With
        ttch = New ToolStripControlHost(ComboBoxTipoCarico)
        tsPezzi.Items.Add(ttch)

        With LabelDataPezzi
            .AutoSize = True
            .BackColor = Color.Transparent
            .Text = "..."
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        ttch = New ToolStripControlHost(LabelDataPezzi)
        tsPezzi.Items.Add(ttch)

        tsPezzi.Items.Add(New ToolStripSeparator)

        With ButtonAggiornaPezzi
            .AutoSize = True
            .BackColor = SystemColors.Control
            .Text = "Aggiorna movimenti"
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        ttch = New ToolStripControlHost(ButtonAggiornaPezzi)
        tsPezzi.Items.Add(ttch)

        tsPezzi.Tag = True
    End Sub

    Private Sub ImpostaTipoCarico()
        Try
            Dim dr As DataTableReader = Utx.FunzioniDb.CreaDataTableReader("SELECT * FROM TipoCarico")

            ComboBoxTipoCarico.Items.Clear()

            Do While dr.Read
                ComboBoxTipoCarico.Items.Add(String.Format("{0} - {1}", dr("Codice"), dr("Descrizione")))

                If dr("Codice") = 1 Then
                    ComboBoxTipoCarico.SelectedIndex = ComboBoxTipoCarico.Items.Count - 1
                End If
            Loop

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub FormattaPezzi()
        On Error Resume Next

        With dgvMovimenti
            .SuspendLayout()

            With .Columns("RamoGestione")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.ForeColor = Color.Red
                .HeaderText = "Ramo Gestione"
            End With
            With .Columns("Descrizione")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .DefaultCellStyle.BackColor = Color.Moccasin
                .HeaderText = "Descrizione ramo gestione"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
            With .Columns("Perc")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = Color.Lavender
                .HeaderText = "Differenza ultimo anno"
            End With

            For Each c As DataGridViewColumn In .Columns

                If c.Index > 2 Then

                    With c
                        .HeaderText = String.Format("Tipo carico {0} del {1}", ComboBoxTipoCarico.Text.Substring(0, 1), c.Name)
                        .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End With
                End If
            Next

            'autosize
            .AutoResizeColumns()

            .ResumeLayout()
        End With
    End Sub

    Private Sub ComboBoxTipoCarico_SelectedIndexChanged(sender As Object, e As EventArgs)
        AggiornaPezzi()
    End Sub

    Private Sub ButtonAggiornaPezzi_Click(sender As Object, e As EventArgs) Handles ButtonAggiornaPezzi.Click
        AggiornaPezzi()
    End Sub
#End Region

    Private Sub ButtonAggiornaIncassi_Click(sender As Object, e As EventArgs) Handles ButtonAggiornaIncassi.Click
        Try
            ResetGriglie()

            ButtonAggiornaIncassi.Enabled = False
            btnEstraiDati.Enabled = False
            TabMain.Enabled = False

            TabMain.SelectedTab = TabPageAnalisi
            TabAnalisi.SelectedTab = Rg

            Dim o As New ExportLib.ConfigScaricoIncassi With {.EsecuzioneAutomatica = False}

            Dim Azioni As New ExportLib.Azioni
            Azioni.AggiornaIncassi()
            'da novembre comincia ad avere senso aggiornare gli arretrati
            If Today.Month >= 11 Then
                If Utx.Globale.UtenteCorrente.Profilo.ProfiloUnipol = "A" Then
                    If MsgBox("Volete aggiornare gli arretrati?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then
                        Azioni.AggiornaArretrati()
                    End If
                End If
            End If
            Azioni.ChiudiNotifica()

                InitTabelle()

            If CheckedListBoxAgenzie.CheckedItems.Count > 1 Then
                ButtonConfermaGruppo_Click(Me, Nothing)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            ButtonAggiornaIncassi.Enabled = True
            btnEstraiDati.Enabled = True
            TabMain.Enabled = True
        End Try
    End Sub

    Private Sub dgvArretrati_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        Try
            Static GrigliaPrecedente As String = ""

            If GrigliaPrecedente <> sender.name Then
                FormFiltro.CancellaFiltri()
                GrigliaPrecedente = sender.name
            End If

            'cartella per salvataggio filtro
            FormFiltro.AppName = "BUDGET"
            FormFiltro.FilterFolder = Utx.Globale.Paths.CartellaSettingRete

            'visualizzo la finestra del filtro
            FormFiltro.Visualizza(sender.Columns(e.ColumnIndex))

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub btnInserimento_Click(sender As System.Object, e As System.EventArgs) Handles btnInserimento.Click
        Try
            If (AnalisiGruppo() = True) OrElse (ButtonConfermaGruppo.Enabled = True) Then
                MsgBox("Per inserire il budget selezionare un solo codice agenzia e confermare.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Exit Sub
            End If
            If CheckedListBoxAgenzie.CheckedItems(0) <> Utx.Globale.AgenziaRichiesta.CodiceAgenzia Then
                MsgBox(String.Format("Per inserire il budget di codici diversi da {0} selezionare l'agenzia con l'opzione  del menù 'Impostazioni >> Cambia agenzia'.",
                                     Utx.Globale.AgenziaRichiesta.CodiceAgenzia),
                       MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Exit Sub
            End If

            Using fi As New frmInserimento
                fi.Agenzia = CheckedListBoxAgenzie.CheckedItems(0)
                fi.FigureProduttive = FiguraProduttiva.Figure
                fi.DataAnalisi = dtpDataAnalisi.Value
                fi.ShowDialog(Me)

                Me.Refresh()

                Cursor.Current = Cursors.WaitCursor

                'nella finestra di inserimento del budget potrebbe essere stato modificato il budget di una figura
                'e quindi è necessario cambiare il budget del gruppo in cui si trova la figura modificata
                Dim Query As String = "SELECT Gruppo FROM GruppiCip WHERE Cip = {0}"

                    Dim GruppiModificati As New ArrayList

                    'controllo budget figure e gruppi
                    For Each i As Object In fi.FigureModificate

                    'budget figura
                    InitBudgetFigura(i(0), i(1))

                    Dim dr As DataTableReader = Utx.FunzioniDb.CreaDataTableReader(String.Format(Query, i(0)))

                    Do While dr.Read
                            'se è stato già controllato lo salto
                            For Each g As Array In GruppiModificati
                                If (g(0) = dr("Gruppo")) AndAlso (g(1) = dr("Anno")) Then Exit Do
                            Next

                            'controllo budget gruppo appartenenza della figura
                            ImpostaBudgetGruppo(dr("Gruppo"))

                            'lo aggiungo all'elenco dei già controllati
                            GruppiModificati.Add({dr("Gruppo"), i(1)})
                        Loop

                        dr.Close()
                    Next
                End Using

        Catch ex As Exception
            Log.Errore(ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub TabVarie_Selected(sender As Object, e As TabControlEventArgs) Handles TabVarie.Selected
        Cursor = Cursors.WaitCursor
        e.TabPage.Refresh()

        Select Case e.TabPage.Name
            Case "Stornate"
                ListaStornate()
            Case "DeltaPremi"
                InitComboRgDelta()
                AggiornaLabelArretrati(LabelDeltaArretrati)
            Case "PremiUnici"
                ListaPremiUnici()
            Case "Arretrati"
                ControlloArretrati()
                AggiornaLabelArretrati(LabelAggiornamentoArretrati)
            Case "Registro"
                VisualizzaRegistro()
        End Select
        Cursor = Cursors.Default
    End Sub

    Private Sub TabAnalisi_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles TabAnalisi.Selecting
        Select Case e.TabPage.Name
            Case "Pezzi"
                If AnalisiGruppo() = True Then
                    MsgBox("L'analisi dei movimenti è disponibile solo per il singolo codice", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                    e.Cancel = True
                End If
            Case "AnomalieAuto"
                If AnalisiGruppo() = True Then
                    MsgBox("Il dettaglio anomalie auto è disponibile solo per il singolo codice", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                    e.Cancel = True
                End If
        End Select
    End Sub

    Private Sub TabAnalisi_Selected(sender As Object, e As TabControlEventArgs) Handles TabAnalisi.Selected
        Cursor = Cursors.WaitCursor
        e.TabPage.Refresh()

        ComboBoxAgenzia.Enabled = True

        Select Case e.TabPage.Name
            Case "AnomalieAuto"
                VisualizzaAnomalieAuto()
            Case "Pezzi"
                VisualizzaPezzi()
            Case "Giornate"
                GiornateLavorative()
            Case "Giornalieri"
                ComboBoxAgenzia.SelectedIndex = 0
                ComboBoxAgenzia.Enabled = False
        End Select
        Cursor = Cursors.Default
    End Sub

    Private Sub TabPageVarie_Enter(sender As Object, e As EventArgs) Handles TabPageVarie.Enter
        If TabVarie.SelectedTab Is Stornate Then
            ListaStornate()
        End If
    End Sub

    Private Sub cboFigura_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cboFigura.SelectedItem.Tipo = FiguraProduttiva.TipoFigura.NON_DEFINITO Then
            cboFigura.SelectedIndex = 0
        End If

        CheckBoxSub.Enabled = cboFigura.SelectedIndex > 0
        CheckBoxProd.Enabled = cboFigura.SelectedIndex > 0

        If cboFigura.SelectedIndex = 0 Then
            CheckBoxSub.Checked = True
            CheckBoxProd.Checked = True
        End If

        FiguraSelezionata = cboFigura.SelectedItem
    End Sub

    Private Sub ButtonConfermaGruppo_Click(sender As Object, e As EventArgs) Handles ButtonConfermaGruppo.Click
        ResetGriglie()
        ComboBoxAgenzia.SelectedIndex = 0
        Dim CodiciSelezionati As Integer = CheckedListBoxAgenzie.CheckedItems.Count
        Select Case CodiciSelezionati
            Case 0
                MsgBox("E' necessario selezionare almeno un codice.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Exit Sub
            Case 1
                CodiceSelezionato = CheckedListBoxAgenzie.CheckedItems.Item(0)
                CreaLinkTabelle(CodiceSelezionato, {CodiceSelezionato})
                btnGestione.Enabled = True
                ComboBoxAgenzia.Enabled = True
            Case Else
                CodiceSelezionato = Utx.Globale.AgenziaRichiesta.CodiceAgenzia
                Dim Codici(CodiciSelezionati - 1) As String
                For k As Integer = 0 To CodiciSelezionati - 1
                    Codici(k) = CheckedListBoxAgenzie.CheckedItems.Item(k)
                Next
                CreaLinkTabelle(CodiceSelezionato, Codici)
                btnGestione.Enabled = False
                ComboBoxAgenzia.Enabled = False
                CheckBoxArretrati.Checked = False
        End Select
        InitTabelle() ' ImpostaComboFigure()
        ButtonConfermaGruppo.Enabled = False
    End Sub

    Private Sub ButtonConfermaGruppo_EnabledChanged(sender As Object, e As EventArgs) Handles ButtonConfermaGruppo.EnabledChanged
        btnEstraiDati.Enabled = Not ButtonConfermaGruppo.Enabled
    End Sub

    Private Sub CheckedListBoxAgenzie_ItemCheck(sender As Object, e As ItemCheckEventArgs)
        ButtonConfermaGruppo.Enabled = True
    End Sub

    Private Sub ResetGriglie()
        On Error Resume Next
        tssSomma.Text = ""
        'slego le griglie
        For Each dgv As DataGridView In InsiemeGriglie()
            dgv.DataSource = Nothing
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            dgv.Refresh()
        Next
        'seleziono tab di default
        TabMain.SelectTab("TabPageAnalisi")
        TabMain.Refresh()
        TabAnalisi.SelectTab("RG")
        TabAnalisi.Refresh()
    End Sub

    Private Function AnalisiGruppo() As Boolean
        Return CheckedListBoxAgenzie.CheckedItems.Count > 1
    End Function

    Private Sub RicalcoloBudgetAnnuo()
        Try
            If CheckBoxVitaOk.Checked = True Then
                For r As Integer = 0 To ds.Tables("Rg").Rows.Count - 1
                    Dim tbl As DataTable = ds.Tables("Rg")

                    'se è una riga dell'anno analisi 
                    If tbl.Rows(r).Item("Anno") = AnnoAnalisi Then
                        'per i comparti 2 RDP e 3 AZIENDE diminuzione dell'incremento del 30%
                        If "03/04/05/06/07/08/09/21/22/23".Contains(tbl.Rows(r).Item("RamoGestione").ToString.PadLeft(2, "0")) Then

                            Log.Trace("Rg {0}: Budget anno corrente {1} - Saldo anno precedente {2} - Differenza {3} - 70% = {4}",
                                      {tbl.Rows(r).Item("RamoGestione"), tbl.Rows(r).Item("BudgetAnnuo"), tbl.Rows(r - 1).Item("IncassoAnnuo"),
                                       tbl.Rows(r).Item("BudgetAnnuo") - tbl.Rows(r - 1).Item("IncassoAnnuo"),
                                       (tbl.Rows(r).Item("BudgetAnnuo") - tbl.Rows(r - 1).Item("IncassoAnnuo")) * 0.7})

                            Dim Incremento As Double = Math.Max(tbl.Rows(r).Item("BudgetAnnuo") - tbl.Rows(r - 1).Item("IncassoAnnuo"), 0) * 0.7
                            If Incremento > 0 Then
                                tbl.Rows(r).Item("BudgetAnnuo") = tbl.Rows(r - 1).Item("IncassoAnnuo") + Incremento
                            End If
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub SostituisciArretrati()
        Try
            'nel caso l'analisi non è per tutti i codici disattivo arretrati
            If ComboBoxAgenzia.SelectedIndex > 0 Then
                CheckBoxArretrati.Checked = False
            End If

            If CheckBoxArretrati.Checked = True Then
                Dim Arretrati As DataTable = ArretratiRamoGestione(New DateTime(dtpDataAnalisi.Value.Year, 12, 31))

                For Each row As DataRow In ds.Tables("Rg").Rows
                    If row("Anno") = AnnoAnalisi Then
                        'pulisco il campo
                        row("DaIncassare") = 0
                        'se esiste un arretrato lo inserisco
                        For Each rowarretrati As DataRow In Arretrati.Rows
                            If row("RamoGestione") = rowarretrati("RamoGestione") Then
                                row("DaIncassare") = rowarretrati("Premi")
                                Exit For
                            End If
                        Next
                    End If
                Next
            End If

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub CheckBoxVitaOk_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxVitaOk.CheckedChanged
        With CheckBoxVitaOk
            If CheckBoxVitaOk.Checked = False Then
                .BackColor = Color.Moccasin
            Else
                .BackColor = Color.PaleGreen
            End If
            .Refresh()
        End With
        ResetGriglie()
    End Sub

    Private Sub CheckBoxArretrati_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxArretrati.CheckedChanged
        With CheckBoxArretrati
            If CheckBoxArretrati.Checked = False Then
                .BackColor = Color.Gainsboro
            Else
                .BackColor = Color.PaleGreen
            End If
            .Refresh()
        End With
        ResetGriglie()
        If CheckBoxArretrati.Checked = True Then
            ImportaArretrati()
        End If
    End Sub

    Private Sub dgvArretrati_DataSourceChanged(sender As Object, e As EventArgs) Handles dgvArretrati.DataSourceChanged
        FormFiltro.CancellaFiltri()
    End Sub

    Private Sub ButtonDettaglioProvvigioni_Click(sender As Object, e As EventArgs) Handles ButtonDettaglioProvvigioni.Click
        Dim sql As New UniSql.UniSql
        If sql.ShowGridAndGetDataTable("Provvigioni per ramo gestione", False, scalaX:=70, scalaY:=90) Is Nothing Then
            MsgBox("Accedere al menù Portafoglio >> Estrattore dati per consentire l'aggiornamento delle estrazioni", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
        End If
    End Sub

    Private Sub ButtonRichiestaCliente_Click(sender As Object, e As EventArgs) Handles ButtonRichiestaCliente.Click
        Try
            If dgvDelta.CurrentRow IsNot Nothing Then
                RaiseEvent RichiestaAnagrafica(dgvDelta.CurrentRow.Cells("CF").Value)
            End If
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub FormFiltro_ModificatoFiltro() Handles FormFiltro.ModificatoFiltro
        If String.Compare(FormFiltro.Contesto, "dgvDelta", True) = 0 Then
            SaldoDeltaPremi()
        End If
    End Sub

    Private Sub ButtonAggiornaDelta_Click(sender As Object, e As EventArgs) Handles ButtonAggiornaDelta.Click
        OkDelta = False
        VariazioneIncassi()
    End Sub

    Private Sub btnEsporta_Click(sender As Object, e As EventArgs) Handles btnEsporta.Click
        If dgvArretrati.Rows.Count > 0 Then
            Utx.NetFunc.Esporta2Csv(dgvArretrati, String.Format("Arretrati al {0:dd-MM-yyyy}", Today), Color.Khaki)
        End If
    End Sub

    Private Sub ImportaArretrati()
        Try
            Dim Chiave As New Utx.SettingItem(Utx.SettingItem.Sezioni.INFO, Utx.SettingItem.Chiavi.IMPORTAZIONE_ARRETRATI,
                                              Utx.SettingOMW.TipoOperazione.LETTURA)
            If Chiave.ItemResult.Esiste = False OrElse Chiave.ItemResult.Valore < Today Then
                If Utx.Globale.UtenteCorrente.Profilo.ProfiloUnipol = "A" Then
                    If MsgBox("Volete aggiornare gli arretrati?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then
                        Dim az As New ExportLib.Azioni
                        az.AggiornaArretrati()
                        az.ChiudiNotifica()
                        AggiornaLabelArretrati(LabelAggiornamentoArretrati)
                    End If
                End If
            End If
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub btnAggiornaArretrati_Click(sender As Object, e As EventArgs) Handles btnAggiornaArretrati.Click
        Try
            dgvArretrati.DataSource = Nothing
            ToolStrip1.Enabled = False
            'aggiorno
            Dim az As New ExportLib.Azioni
            az.AggiornaArretrati()
            az.ChiudiNotifica()
        Catch ex As Exception
            Log.Errore(ex)
        Finally
            AggiornaLabelArretrati(LabelAggiornamentoArretrati)
            ToolStrip1.Enabled = True
        End Try
    End Sub

    Private Sub AggiornaLabelArretrati(Etichetta As Object)
        Dim Chiave As New Utx.SettingItem(Utx.SettingItem.Sezioni.INFO, Utx.SettingItem.Chiavi.IMPORTAZIONE_ARRETRATI,
                                          Utx.SettingOMW.TipoOperazione.LETTURA)
        If Chiave.ItemResult.Esiste Then
            Etichetta.Text = String.Format("Arretrati al {0}", Chiave.ItemResult.Modifica)
        Else
            Etichetta.Text = "Arretrati al N.D."
        End If
    End Sub

    Private Sub CheckBoxIndividuali_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxIndividuali.CheckedChanged
        With CheckBoxIndividuali
            If CheckBoxIndividuali.Checked = False Then
                .BackColor = Color.Gainsboro
            Else
                .BackColor = Color.PaleGreen
            End If
            .Refresh()
        End With
        ResetGriglie()
    End Sub

#Region "giornalieri"
    Private Sub ButtonVisualizzaGiornalieri_Click(sender As Object, e As EventArgs) Handles ButtonVisualizzaGiornalieri.Click
        If ComboBoxMeseGiornalieri.SelectedIndex = 0 Then
            IncassiGiornalieri.LeggiMensili()
        Else
            IncassiGiornalieri.LeggiGiornalieri()
        End If
    End Sub

    Private Sub ButtonAnalisiDifferenze_Click(sender As Object, e As EventArgs) Handles ButtonAnalisiDifferenze.Click
        Try
            Dim Mese As Integer = ComboBoxMeseGiornalieri.Text.Split(".")(0)
            dtpDataInizioAnalisi.Value = New DateTime(ComboBoxAnnoGiornalieri.Text, Mese, 1)
            dtpDataAnalisi.Value = New DateTime(ComboBoxAnnoGiornalieri.Text, Mese, DateTime.DaysInMonth(ComboBoxAnnoGiornalieri.Text, Mese))
            TabMain.SelectedTab = TabPageVarie
            TabVarie.SelectedTab = DeltaPremi
            ComboBoxRgDelta.SelectedIndex = ComboBoxRamoGestioneGiornalieri.SelectedIndex
            TabMain.Refresh()
            ButtonAggiornaDelta.PerformClick()
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub Giornalieri_Enter(sender As Object, e As EventArgs) Handles Giornalieri.Enter
        If IncassiGiornalieri.Inizializzato = False Then
            IncassiGiornalieri.ButtonVisualizza = ButtonVisualizzaGiornalieri
            IncassiGiornalieri.ButtonVariazioni = ButtonAnalisiDifferenze
            IncassiGiornalieri.ComboAnno = ComboBoxAnnoGiornalieri
            IncassiGiornalieri.ComboMese = ComboBoxMeseGiornalieri
            IncassiGiornalieri.ComboRg = ComboBoxRamoGestioneGiornalieri
            IncassiGiornalieri.ComboComparto = ComboBoxCompartoGiornalieri
            IncassiGiornalieri.ComboAggregato = ComboBoxAggregatoGiornalieri
            IncassiGiornalieri.dgv = dgvGiornalieri
            IncassiGiornalieri.Init()
        End If
    End Sub

    Private Sub Label5_TextChanged(sender As Object, e As EventArgs) Handles Label5.TextChanged
        Label5.Refresh()
    End Sub

    Private Sub dgvDettaglioIncassi_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgvDettaglioIncassi.CurrentCellChanged
        Try
            If dgvDettaglioIncassi.DataSource IsNot Nothing AndAlso dgvDettaglioIncassi.CurrentRow IsNot Nothing Then
                Dim AnnoNew As Integer = dtpDataAnalisi.Value.Year
                Dim AnnoOld As Integer = AnnoNew - 1
                Dim TotaleOld As Double = 0
                Dim TotaleNew As Double = 0
                Dim Polizza As Integer = dgvDettaglioIncassi.CurrentRow.Cells("Polizza").Value
                For Each row As DataGridViewRow In dgvDettaglioIncassi.Rows
                    If row.Cells("Polizza").Value = Polizza Then
                        If row.Cells("Anno").Value = AnnoOld Then
                            TotaleOld += row.Cells("Premio").Value
                        Else
                            TotaleNew += row.Cells("Premio").Value
                        End If
                    End If
                Next
                'LabelTotalePolizza.Text = String.Format("Polizza: {0}/{1} - Totale {2}: {3:###,##0.00} Totale {4}: {5:###,##0.00} Differenza: {6:###,##0.00}",
                '                                        dgvDettaglioIncassi.CurrentRow.Cells("Ramo").Value, Polizza, AnnoOld, TotaleOld, AnnoNew, TotaleNew, TotaleNew - TotaleOld)
                LabelTotalePolizza.Text = String.Format("Polizza: {0}/{1} - Differenza ({2} - {3}): {4:+###,##0.00;-###,##0.00;0}",
                                                        dgvDettaglioIncassi.CurrentRow.Cells("Ramo").Value, Polizza, AnnoNew, AnnoOld, TotaleNew - TotaleOld)
                If TotaleNew - TotaleOld >= 0 Then
                    LabelTotalePolizza.ForeColor = Color.Green
                Else
                    LabelTotalePolizza.ForeColor = Color.IndianRed
                End If
            End If
        Catch ex As Exception
            LabelTotalePolizza.Text = "ND"
        End Try
    End Sub

    Private Sub ComboBoxAgenzia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxAgenzia.SelectedIndexChanged
        If ComboBoxAgenzia.SelectedIndex = 0 Then
            CompagniaIncorporata = 0
            AgenziaIncorporata = 0
        Else
            CompagniaIncorporata = ComboBoxAgenzia.Text.Split("-")(0)
            AgenziaIncorporata = ComboBoxAgenzia.Text.Split("-")(1)
        End If
    End Sub

    Private Sub CheckBoxSub_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSub.CheckedChanged
        btnEstraiDati.Enabled = Not (CheckBoxSub.Checked = False And CheckBoxProd.Checked = False)
    End Sub

    Private Sub CheckBoxProd_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxProd.CheckedChanged
        btnEstraiDati.Enabled = Not (CheckBoxSub.Checked = False And CheckBoxProd.Checked = False)
    End Sub
#End Region
End Class
