Imports System.Text
Imports System.IO

Public Class FormAdempimenti

    Public Shared TitoloFinestra As String = "Adempimenti"

    Private Const LinkDoc As String = "http://www.utools.it/Unitools/Doc/Buste/IndexDoc.htm"

    Private WithEvents Notifica As Utx.FormNotifica
    Private WithEvents FormDocumenti As UnitoolsDocumenti.FormDocumenti

    Private WithEvents ButtonAggiornaEssig As New Button
    Private WithEvents ButtonDocumentiCliente As New Button
    Private WithEvents ButtonArchiviaBuste As New Button
    Private WithEvents ButtonCancella As New Button
    Private WithEvents ButtonExcel As New Button
    Private WithEvents ButtonEsci As New Button
    Private FormFiltro As Utx.FormGestioneFiltro
    Private FormFiltroArchivio As Utx.FormGestioneFiltro
    Private ListaOrdimamento As New List(Of ColonnaOrdinamento)
    Private Stato As FormWindowState

    'per menù archivio
    Private WithEvents ButtonCerca As New Button
    Private WithEvents ButtonArchivioTrimestre As New Button
    Private WithEvents TextBoxCerca As New TextBox
    Private LabelCerca As New Label
    Private ArchivioModificato As Boolean

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.MinimumSize = New Size(600, 500)
        Me.WindowState = FormWindowState.Maximized
        Me.Font = Globale.MainFont
        Me.Icon = My.Resources.adempimenti
        Me.Text = TitoloFinestra

        ImpostaToolStripMain()
        ImpostaToolStripArchivio()

        Dim AltezzaMenu As Integer = tsMainMenu.Height

        With tlpMain.RowStyles.Item(0)
            .SizeType = SizeType.Absolute
            .Height = AltezzaMenu
        End With

        AltezzaMenu = tsMenuArchivio.Height

        With tlpArchivio.RowStyles.Item(0)
            .SizeType = SizeType.Absolute
            .Height = AltezzaMenu
        End With

        ImpostaControlli()
    End Sub

    Private Sub ImpostaToolStripMain()

        On Error Resume Next

        Dim tt As New ToolTip

        With tsMainMenu
            .GripStyle = ToolStripGripStyle.Hidden
            .BackColor = Color.Transparent
            .Items.Clear()
        End With

        Dim ttch As ToolStripControlHost

        With ButtonAggiornaEssig
            .AutoSize = False
            .Width = 150
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Text = "Aggiorna da Essig"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = My.Resources.aggiorna.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        ttch = New ToolStripControlHost(ButtonAggiornaEssig)
        tsMainMenu.Items.Add(ttch)
        tt.SetToolTip(ButtonAggiornaEssig, "Aggiorna incassi da Essig")

        With ButtonDocumentiCliente
            .AutoSize = False
            .Width = 150
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Text = "Documenti cliente"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = My.Resources.ScanDoc.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        ttch = New ToolStripControlHost(ButtonDocumentiCliente)
        tsMainMenu.Items.Add(ttch)
        tt.SetToolTip(ButtonDocumentiCliente, "Visualizza documenti del cliente")

        With ButtonArchiviaBuste
            .AutoSize = False
            .Width = 150
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Text = "Stampa e archivia"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = My.Resources.archivio.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        ttch = New ToolStripControlHost(ButtonArchiviaBuste)
        tsMainMenu.Items.Add(ttch)
        tt.SetToolTip(ButtonArchiviaBuste, "Stampa e archivia")

        With ButtonExcel
            .AutoSize = False
            .Width = 150
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Text = "Esporta in csv"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = My.Resources.excel.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        ttch = New ToolStripControlHost(ButtonExcel)
        tsMainMenu.Items.Add(ttch)

        With ButtonCancella
            .AutoSize = False
            .Width = 150
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Text = "Cancella righe"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = My.Resources.Elimina.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        ttch = New ToolStripControlHost(ButtonCancella)
        tsMainMenu.Items.Add(ttch)

        With ButtonEsci
            .AutoSize = False
            .Width = 150
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Text = "Esci"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = My.Resources.esci.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        ttch = New ToolStripControlHost(ButtonEsci) With {.Alignment = ToolStripItemAlignment.Right}
        tsMainMenu.Items.Add(ttch)

        tsMainMenu.Items.Add(New ToolStripSeparator With {.Alignment = ToolStripItemAlignment.Right})

        With ButtonCerca
            .AutoSize = False
            .Width = 150
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Gainsboro
            .BackColor = SystemColors.Control
            .Text = "Cerca"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = Risorse.Immagini.Bitmap("cerca16")
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        ttch = New ToolStripControlHost(ButtonCerca) With {.Alignment = ToolStripItemAlignment.Right, .Margin = New Padding(3)}
        ttch.Alignment = ToolStripItemAlignment.Right
        tsMainMenu.Items.Add(ttch)

        ttch = New ToolStripControlHost(TextBoxCerca) With {.Alignment = ToolStripItemAlignment.Right,
                                                            .AutoSize = False, .Width = 200, .Margin = New Padding(3)}
        tsMainMenu.Items.Add(ttch)

        With LabelCerca
            .AutoSize = False
            .Height = ButtonCerca.Height
            .Width = 150
            .Text = "Polizza/Contraente "
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        ttch = New ToolStripControlHost(LabelCerca) With {.Alignment = ToolStripItemAlignment.Right}
        tsMainMenu.Items.Add(ttch)

        tsMainMenu.Visible = True
    End Sub

    Private Sub ImpostaToolStripArchivio()

        On Error Resume Next

        Dim tt As New ToolTip

        With tsMenuArchivio
            .GripStyle = ToolStripGripStyle.Hidden
            .BackColor = Color.Orange
            .Padding = New Padding(1)
            .Items.Clear()
        End With

        Dim ttch As ToolStripControlHost

        With ButtonArchivioTrimestre
            .AutoSize = False
            .Width = 150
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Gainsboro
            .BackColor = SystemColors.Control
            .Text = "Ultimo trimestre"
        End With
        ttch = New ToolStripControlHost(ButtonArchivioTrimestre) With {.Height = ButtonArchivioTrimestre.Height}
        tsMenuArchivio.Items.Add(ttch)
        tt.SetToolTip(ButtonArchivioTrimestre, "Visualizza l'archivio dell'ultimo trimestre")
    End Sub

    Private Sub ImpostaControlli()

        TabPageArchivio.BackColor = Color.Gray

        With TabControlMain
            .TabPages.Remove(TabPageStornate)
            .ItemSize = New Size(150, 25)
        End With

        'sistemo le righe del tlp elenco
        tlpElenco.RowStyles.Item(0) = New RowStyle(SizeType.Absolute, 30)
        tlpElenco.RowStyles.Item(2) = New RowStyle(SizeType.Absolute, 50)
        'colonne
        tlpElenco.ColumnStyles.Item(0) = New ColumnStyle(SizeType.Percent, 100)
        tlpElenco.ColumnStyles.Item(1) = New ColumnStyle(SizeType.Absolute, 80)
        tlpElenco.ColumnStyles.Item(2) = New ColumnStyle(SizeType.Absolute, 120)
        tlpElenco.ColumnStyles.Item(3) = New ColumnStyle(SizeType.Absolute, 30)
        tlpElenco.ColumnStyles.Item(4) = New ColumnStyle(SizeType.Absolute, 120)
        tlpElenco.ColumnStyles.Item(5) = New ColumnStyle(SizeType.Absolute, 150)
        tlpElenco.ColumnStyles.Item(6) = New ColumnStyle(SizeType.Absolute, 150)
        tlpElenco.ColumnStyles.Item(7) = New ColumnStyle(SizeType.Absolute, 150)

        ttsStato.Text = ""
        With CheckBoxMostraQuietanze
            .Padding = New Padding(5, 0, 5, 0)
            .BackColor = Color.Gold
            .Checked = False
            .Text = "Mostra tipo carico 4 (quietanze)"
        End With
        'date
        dtpInizio.Value = Utx.FunzioniData.InizioPrecedenteDecade(Today)
        dtpInizio.MaxDate = Today
        dtpFine.Value = Today
        dtpFine.MaxDate = Today
        AddHandler dtpInizio.ValueChanged, AddressOf dtpInizio_ValueChanged
        AddHandler dtpFine.ValueChanged, AddressOf dtpInizio_ValueChanged

        With ButtonRicarica
            .Margin = New Padding(3)
            .AutoSize = True
            .Dock = DockStyle.Fill
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.DodgerBlue
            .BackColor = Color.SteelBlue
            .ForeColor = Color.White
            .Text = "Carica titoli"
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With ButtonRecuperaIncasso
            .AutoSize = True
            .Dock = DockStyle.Fill
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.LightSlateGray
            .BackColor = Color.PaleGreen
            .Text = "Importa incasso"
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With ButtonOrdinamento
            .AutoSize = True
            .Dock = DockStyle.Fill
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.LightSlateGray
            .BackColor = Color.LightSteelBlue
            .Text = "Ordinamento personalizzato"
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With TextBoxNota
            .Multiline = True
            .BorderStyle = BorderStyle.FixedSingle
            .Dock = DockStyle.Fill
            .BackColor = Color.LightYellow
            .MaxLength = 255
        End With
        With ButtonSalvaNota
            .Padding = New Padding(5, 0, 5, 0)
            .Dock = DockStyle.Fill
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gray
            .Text = "Salva nota"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = My.Resources.salva16.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With

        With LabelNumeroRighe
            .Margin = New Padding(0, 3, 0, 3)
            .AutoSize = True
            .Dock = DockStyle.Fill
            .FlatStyle = FlatStyle.Flat
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = Color.Gold
            .Text = ""
            .TextAlign = ContentAlignment.MiddleCenter
        End With

        With dgvBuste
            .Dock = DockStyle.Fill
            .Font = Globale.MainFont
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = True
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .CellBorderStyle = DataGridViewCellBorderStyle.Raised
            .DefaultCellStyle.SelectionBackColor = Color.Coral
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .RowHeadersDefaultCellStyle.SelectionBackColor = Color.Red
        End With
        Utx.NetFunc.DoppioBuffer(dgvBuste)

        With dgvArchivio
            .Margin = New Padding(0, 3, 0, 0)
            .Font = Globale.MainFont
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .CellBorderStyle = DataGridViewCellBorderStyle.Raised
            .DefaultCellStyle.SelectionBackColor = Color.Coral
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .RowHeadersDefaultCellStyle.SelectionBackColor = Color.Red
        End With
        Utx.NetFunc.DoppioBuffer(dgvArchivio)
    End Sub

    Private Sub FormAdempimenti_Load(sender As Object, e As EventArgs) Handles Me.Load
        OrdinamentoPredefinito()
    End Sub

    Private Sub FormAdempimenti_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        TabControlMain.ColorStyle = Utx.UtTabControl.TabColorStyle.VERDE
        Me.Refresh()

        ButtonRicarica.BackColor = Color.Gainsboro
        ButtonRicarica.Enabled = False

        ManutenzioneTabella()
        Busta.AggiornaDateDecadi()
        ArchivioModificato = False

        ButtonRicarica.BackColor = Color.SteelBlue
        ButtonRicarica.Enabled = True
        dgvBuste.Focus()

        AddHandler CheckBoxMostraQuietanze.CheckedChanged, AddressOf CheckBoxMostraQuietanze_CheckedChanged
    End Sub

    Private Sub OrdinamentoPredefinito()

        If File.Exists(FileBusteXml) Then
            'se esiste un ordinamento impostato dall'utente lo carico
            CaricaOrdinamentoUtente()
        Else
            'altrimenti carico l'ordinamento predefinito
            With ListaOrdimamento
                .Clear()

                .Add(New ColonnaOrdinamento("DataFoglioCassa", "Data FC", ColonnaOrdinamento.TipoOrdinamento.DECRESCENTE))
                .Add(New ColonnaOrdinamento("TipoCarico", "Tipo carico", ColonnaOrdinamento.TipoOrdinamento.CRESCENTE))
                .Add(New ColonnaOrdinamento("Contraente", "Contraente", ColonnaOrdinamento.TipoOrdinamento.CRESCENTE))
            End With
        End If
    End Sub

    Private Sub LeggiDocDaIncassi()
        Try
            Using s As New Utx.AdempimentiOMW.Adempimenti
                s.Proxy = Utx.Globale.UniProxy.Proxy
                s.LeggiDocDaIncassi(Utx.Globale.AgenziaRichiesta.CodiceAgenzia, Utx.Globale.Token)
            End Using
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonAggiornaEssig_Click(sender As Object, e As EventArgs) Handles ButtonAggiornaEssig.Click
        Try
            ButtonAggiornaEssig.Enabled = False

            dgvBuste.Enabled = False

            Dim Azioni As New ExportLib.Azioni
            Azioni.OpzioniScarico = New ExportLib.ConfigScaricoIncassi With {.EsecuzioneAutomatica = False}
            Azioni.AggiornaIncassi()
            Azioni.ChiudiNotifica()

            LeggiDocDaIncassi()
            LeggiElencoDoc()

            dgvBuste.Enabled = True

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            ButtonAggiornaEssig.Enabled = True
        End Try
    End Sub

    Private Sub LeggiElencoDoc()
        Try
            Cursor.Current = Cursors.WaitCursor

            dgvBuste.DataSource = Nothing
            dgvBuste.Refresh()
            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(QueryElencoDoc()).DataTable
            dgvBuste.DataSource = dt

            FormattaElencoDoc(dgvBuste)
            FormattaColoriCelle(dgvBuste)

            LabelNumeroRighe.Text = String.Format("Righe {0}", dgvBuste.Rows.Count)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub LeggiDocArchiviati(InizioPeriodo As Date)
        Try
            Cursor.Current = Cursors.WaitCursor

            dgvArchivio.DataSource = Nothing
            dgvArchivio.Refresh()

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(QueryArchivioDoc(InizioPeriodo)).DataTable
            dgvArchivio.DataSource = dt

            FormattaElencoDoc(dgvArchivio)
            dgvArchivio.Columns("TipoBusta").DefaultCellStyle.BackColor = Color.Pink

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function QueryBase() As String
        Return "SELECT 
                    CASE
                        WHEN DataBusta IS NULL THEN CAST(0 AS bit)
                        ELSE CAST(1 AS bit)
                    END AS Doc,
                    CASE
                        WHEN (Archivio = 0) OR (Archivio IS NULL) THEN ''
                        ELSE 'DIR'
                    END AS Dir,
                    DataBusta,
                    CASE
                        WHEN Day(DataFoglioCassa) < 11 THEN '1 DEC '
                        WHEN Day(DataFoglioCassa) < 21 THEN '2 DEC '
                        ELSE '3 DEC '
                    END + UPPER(Format(DataFoglioCassa,'MM-yyyy')) AS Busta,
                    TipoBusta,Agenzia,SubAgenzia,Ramo,Polizza,TipoCarico,Appendice,EffettoAppendice,EffettoTitolo,
                    CASE
                        WHEN Tipo = 'F' THEN 'FEA'
                        ELSE ''
                    END AS Fea,
                    Contraente,DataFoglioCassa,Esito,TotaleTitolo,Prodotto,Targa,Stampato,Archivio,RamoGestione,CodiceFiscale,Nota
                FROM Buste "
    End Function

    Private Function QueryElencoDoc() As String
        Try
            Dim Sql As String

            If CheckBoxMostraQuietanze.Checked = False Then
                Sql = QueryBase() +
                        " WHERE (DataFoglioCassa BETWEEN '{0:dd/MM/yyyy}' AND '{1:dd/MM/yyyy}') AND (CAST(Inviato AS Int) = 0) AND 
                            ((Tipocarico <> '4') OR (TipoCarico = '4' AND (Archivio > 0)))
                        ORDER BY {2}"
            Else
                Sql = QueryBase() +
                    " WHERE (DataFoglioCassa BETWEEN '{0:dd/MM/yyyy}' AND '{1:dd/MM/yyyy}') AND (CAST(Inviato AS Int) = 0) 
                    ORDER BY {2}"
            End If
            Return String.Format(Sql, dtpInizio.Value, dtpFine.Value, ColonnaOrdinamento.ClausolaOrder(ListaOrdimamento))

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return "SELECT * FROM Buste WHERE 1=0" 'non visualizza niente ma non va in errore
        End Try
    End Function

    Private Function CercaElencoDoc(Chiave As String) As String
        Try
            Dim Sql As String = QueryBase() +
                " WHERE ({0} LIKE '%{1}%') AND (Inviato = CAST(0 AS bit)) 
                ORDER BY {2}"
            If IsNumeric(Chiave) Then
                Return String.Format(Sql, "Polizza", Chiave, ColonnaOrdinamento.ClausolaOrder(ListaOrdimamento))
            Else
                Return String.Format(Sql, "Contraente", Chiave, ColonnaOrdinamento.ClausolaOrder(ListaOrdimamento))
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Private Function CercaArchivioDoc(Chiave As String) As String
        Try
            Dim Sql As String = QueryBase() +
                " WHERE ({0} LIKE '%{1}%') AND (Inviato = CAST(1 AS bit)) 
                 ORDER BY DataFoglioCassa DESC,TipoCarico,Contraente"
            If IsNumeric(Chiave) Then
                Return String.Format(Sql.ToString, "Polizza", Chiave)
            Else
                Return String.Format(Sql.ToString, "Contraente", Chiave)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Private Function QueryArchivioDoc(InizioPeriodo As Date) As String
        Try
            Dim Sql As String = QueryBase() +
                " WHERE (Inviato = CAST(1 AS bit)) AND (DataBusta >= '{0:dd/MM/yyyy}') 
                ORDER BY DataFoglioCassa DESC,TipoCarico,Contraente"
            Return String.Format(Sql.ToString, InizioPeriodo)
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Private Sub FormattaElencoDoc(ByRef dgv As DataGridView)

        On Error Resume Next

        With dgv
            .SuspendLayout()

            'intestazioni delle colonne
            .Columns("Nota").Visible = False
            With .Columns("Busta")
                .HeaderText = "Riferimento"
                .DefaultCellStyle.BackColor = Color.Gainsboro
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("TipoBusta")
                .HeaderText = "Tipo busta"
                .Width = 200
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("SubAgenzia")
                .HeaderText = "Sub"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("DataBusta")
                .HeaderText = "Invio"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("TipoCarico")
                .HeaderText = String.Format("Tipo{0}carico", Environment.NewLine)
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = Color.PaleGreen
            End With
            With .Columns("EffettoTitolo")
                .HeaderText = "Effetto"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("DataFoglioCassa")
                .HeaderText = "Foglio cassa"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = Color.Khaki
            End With
            With .Columns("TotaleTitolo")
                .HeaderText = "Tot.titolo"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,##0.00"
            End With
            With .Columns("Appendice")
                .HeaderText = "App."
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("EffettoAppendice")
                .HeaderText = "Effetto app."
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("RamoGestione")
                .HeaderText = "Ramo gestione"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            .Columns("Agenzia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Ramo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Esito").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Prodotto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Targa").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

            For Each c As DataGridViewColumn In .Columns
                c.SortMode = DataGridViewColumnSortMode.Programmatic
            Next

            .ResumeLayout()
        End With
    End Sub

    Private Sub FormattaColoriCelle(ByRef dgv As DataGridView)

        On Error Resume Next

        With dgv
            .SuspendLayout()

            For Each r As DataGridViewRow In .Rows

                If r.Cells("DataBusta").Value IsNot DBNull.Value Then
                    r.Cells("Doc").Style.BackColor = Color.YellowGreen
                ElseIf r.Cells("Fea").Value = "FEA" Then
                    r.DefaultCellStyle.BackColor = Color.Gainsboro
                    r.DefaultCellStyle.ForeColor = Color.Blue
                End If

                If r.Cells("TipoBusta").Value.ToString.Trim.Length > 0 Then

                    Select Case r.Cells("TipoBusta").Value.ToString.ToUpper

                        Case Busta.Tipo.RCASING.ToString
                            r.Cells("TipoBusta").Style.BackColor = Color.DodgerBlue
                            r.Cells("TipoBusta").Style.ForeColor = Color.White

                        Case Busta.Tipo.RCACUM.ToString
                            r.Cells("TipoBusta").Style.BackColor = Color.Black
                            r.Cells("TipoBusta").Style.ForeColor = Color.White

                        Case Busta.Tipo.RAMIELE.ToString
                            r.Cells("TipoBusta").Style.BackColor = Color.YellowGreen

                        Case Busta.Tipo.VITA.ToString
                            r.Cells("TipoBusta").Style.BackColor = Color.Khaki

                        Case Busta.Tipo.CAUZIONI.ToString
                            r.Cells("TipoBusta").Style.BackColor = Color.Gray
                            r.Cells("TipoBusta").Style.ForeColor = Color.White
                    End Select
                End If
            Next

            .ResumeLayout()
        End With
    End Sub

    Private Sub dgvBuste_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBuste.CellContentClick
        'se clicco sul check della documentazione
        If (e.ColumnIndex = dgvBuste.Columns("Doc").Index) Then
            ModificaFlagDoc(dgvBuste.CurrentRow)
        End If
    End Sub

    Private Sub dgvArchivio_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvArchivio.CellContentClick
        Try
            If dgvArchivio.Columns("Doc") IsNot Nothing Then
                'se clicco sul check della documentazione (controllo prima che la colonna esista)
                If (e.ColumnIndex = dgvArchivio.Columns("Doc").Index) Then
                    'solo se è fleggato
                    If dgvArchivio.CurrentRow.Cells("Doc").Value = True Then

                        If MsgBox("Attenzione: il documento è stato già inviato e archiviato. Ripristinare il documento?",
                           MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                            RipristinaDaArchivio(dgvArchivio.CurrentRow)
                            ArchivioModificato = True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ModificaFlagDoc(ByRef dr As DataGridViewRow)
        Try
            With dr
                If .Cells("FEA").Value.ToString.Trim.Length = 0 Then
                    .Cells("Doc").Value = Not .Cells("Doc").Value

                    If .Cells("Doc").Value = True Then
                        .Cells("DataBusta").Value = Busta.DecadeCorrente(.Cells("TipoBusta").Value)
                        .Cells("Doc").Style.BackColor = Color.YellowGreen
                    Else
                        .Cells("DataBusta").Value = System.DBNull.Value
                        .Cells("Doc").Style.BackColor = dgvBuste.DefaultCellStyle.BackColor
                    End If
                End If
            End With
            ModificaFlagTabella(dr)
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ModificaFlagTabella(dr As DataGridViewRow)
        Try
            Dim th As New Threading.Thread(Sub()
                                               Dim Query As String
                                               If IsDBNull(dr.Cells("DataBusta").Value) Then
                                                   Query = String.Format("UPDATE Buste SET DataBusta = NULL WHERE {0}", ImpostaParametriChiave(dr))
                                               Else
                                                   Query = String.Format("UPDATE Buste SET DataBusta = '{0:dd/MM/yyyy}' WHERE {1}", dr.Cells("DataBusta").Value, ImpostaParametriChiave(dr))
                                               End If
                                               Utx.WsCommand.ExecuteNonQueryRecord(Query)
                                           End Sub)
            th.Start()
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub RipristinaDaArchivio(dr As DataGridViewRow)
        Try
            'aggiorno griglia
            dr.Cells("Doc").Value = False
            dr.Cells("DataBusta").Value = System.DBNull.Value
            'aggiorno db
            Dim th As New Threading.Thread(Sub()
                                               Dim Query As String = String.Format("UPDATE Buste SET DataBusta = NULL,Inviato = 0 WHERE {0}",
                                                                                   ImpostaParametriChiave(dr))
                                               Utx.WsCommand.ExecuteNonQuery({Query})
                                           End Sub)
            th.Start()
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub dgvBuste_DoubleClick(sender As Object, e As EventArgs) Handles dgvBuste.DoubleClick
        'disattivo il doppio click
        'ModificaFlagDoc(dgvBuste.CurrentRow)
    End Sub

    Private Sub ButtonDocumentiCliente_Click(sender As Object, e As EventArgs) Handles ButtonDocumentiCliente.Click
        Try
            ButtonDocumentiCliente.Enabled = False

            If dgvBuste.CurrentRow Is Nothing Then
                MsgBox("Selezionare prima una riga", MsgBoxStyle.Exclamation)
            Else
                FormDocumenti = Utx.OggettoForm.Esiste(Utx.OggettoForm.TipoForm.DOCUMENTI)

                If FormDocumenti Is Nothing Then
                    FormDocumenti = New UnitoolsDocumenti.FormDocumenti
                End If

                AddHandler FormDocumenti.ActivateDoc, AddressOf FormDocumenti_ActivateDoc
                AddHandler FormDocumenti.CloseDoc, AddressOf FormDocumenti_CloseDoc


                FormDocumenti.Reset()
                FormDocumenti.CartellaAllegati = ""

                If TabControlMain.SelectedTab Is TabPageBuste Then
                    With FormDocumenti
                        .CodiceFiscale = dgvBuste.CurrentRow.Cells("CodiceFiscale").Value
                        .NomeCliente = dgvBuste.CurrentRow.Cells("Contraente").Value
                    End With
                ElseIf TabControlMain.SelectedTab Is TabPageArchivio Then
                    With FormDocumenti
                        .CodiceFiscale = dgvArchivio.CurrentRow.Cells("CodiceFiscale").Value
                        .NomeCliente = dgvArchivio.CurrentRow.Cells("Contraente").Value
                    End With
                End If

                Utx.OggettoForm.Show(Utx.OggettoForm.TipoForm.DOCUMENTI)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            ButtonDocumentiCliente.Enabled = True
        End Try
    End Sub

    Private Sub dgvBuste_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvBuste.ColumnHeaderMouseClick
        Try
            'cartella per salvataggio filtro
            FormFiltro.AppName = "Utx.BUSTE"
            FormFiltro.FilterFolder = Utx.Globale.Paths.CartellaSettingRete

            'visualizzo la finestra del filtro
            FormFiltro.Visualizza(dgvBuste.Columns(e.ColumnIndex))

            FormattaColoriCelle(dgvBuste)
            LabelNumeroRighe.Text = String.Format("Righe {0}", dgvBuste.Rows.Count)

        Catch ex As Exception
            Globale.Log.Errore(ex, String.Format("{0}.{1}",
                                                    "FormMain",
                                                    System.Reflection.MethodInfo.GetCurrentMethod.Name))
        End Try
    End Sub

    Private Sub dgvArchivio_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvArchivio.ColumnHeaderMouseClick
        Try
            'cartella per salvataggio filtro
            FormFiltroArchivio.AppName = "Utx.BUSTE"
            FormFiltroArchivio.FilterFolder = Utx.Globale.Paths.CartellaSettingRete

            'visualizzo la finestra del filtro
            FormFiltroArchivio.Visualizza(dgvArchivio.Columns(e.ColumnIndex))

            FormattaColoriCelle(dgvBuste)
            LabelNumeroRighe.Text = String.Format("Righe {0}", dgvBuste.Rows.Count)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonArchiviaBuste_Click(sender As Object, e As EventArgs) Handles ButtonArchiviaBuste.Click
        Try
            Using f As New FormInvio
                f.ShowDialog()

                If f.Archiviazione = True Then
                    'aggiorna elenco 
                    LeggiElencoDoc()
                End If
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        Me.Close()
    End Sub

    Private Sub ButtonSalvaNota_Click(sender As Object, e As EventArgs) Handles ButtonSalvaNota.Click
        Try
            Dim th As New Threading.Thread(Sub()
                                               Dim Query As String = String.Format("UPDATE Buste SET Nota = '{0}' WHERE {1}",
                                                        TextBoxNota.Text, ImpostaParametriChiave(dgvBuste.CurrentRow))
                                               Utx.WsCommand.ExecuteNonQuery({Query})
                                           End Sub)
            th.Start()
            dgvBuste.CurrentRow.Cells("Nota").Value = TextBoxNota.Text
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub dgvBuste_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgvBuste.CurrentCellChanged

        On Error Resume Next

        If dgvBuste.CurrentRow.Cells("Nota").Value Is DBNull.Value Then
            TextBoxNota.Text = ""
        Else
            TextBoxNota.Text = dgvBuste.CurrentRow.Cells("Nota").Value
        End If
    End Sub

    Private Sub ButtonExcel_Click(sender As Object, e As EventArgs) Handles ButtonExcel.Click
        If TabControlMain.SelectedTab Is TabPageBuste Then
            Utx.NetFunc.Esporta2Csv(dgvBuste, String.Format("Buste {0}", Format(Today, "dd-MM-yyyy")), Color.Khaki)
        ElseIf TabControlMain.SelectedTab Is TabPageArchivio Then
            Utx.NetFunc.Esporta2Csv(dgvArchivio, String.Format("Buste {0}", Format(Today, "dd-MM-yyyy")), Color.Khaki)
        End If
    End Sub

    Private Sub ButtonIndice_Click(sender As System.Object, e As System.EventArgs) Handles ButtonIndice.Click
        wbDocumentazione.Navigate(LinkDoc)
    End Sub

    Private Sub ButtonCancella_Click(sender As Object, e As EventArgs) Handles ButtonCancella.Click
        Try
            If TabControlMain.SelectedTab IsNot TabPageBuste Then
                MsgBox("Impossibile cancellare un documento archiviato.", MsgBoxStyle.Exclamation, Globale.TitoloApp)
                Exit Sub
            End If

            'warning direzione
            For Each r As DataGridViewRow In dgvBuste.SelectedRows
                'se il doc è richiesto dalla direzione
                If r.Cells("Archivio").Value IsNot DBNull.Value AndAlso r.Cells("Archivio").Value > 0 Then
                    MsgBox("Attenzione: uno o più documenti sono richiesti dalla direzione.", MsgBoxStyle.Information, Globale.TitoloApp)
                    Exit For
                End If
            Next

            Select Case dgvBuste.SelectedRows.Count
                Case 0 : Exit Sub
                Case 1
                    If MsgBox(String.Format("Confermate la cancellazione del titolo selezionato?{0}{0}- {1} esitato il {2:d}",
                                            Environment.NewLine,
                                            dgvBuste.CurrentRow.Cells("Contraente").Value,
                                            dgvBuste.CurrentRow.Cells("DataFoglioCassa").Value),
                              MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question,
                              Globale.TitoloApp) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                Case Is > 1
                    If MsgBox("Confermate la cancellazione dei titoli selezionati e da non inviare?",
                              MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question,
                              Globale.TitoloApp) = MsgBoxResult.No Then
                        Exit Sub
                    End If
            End Select

            For Each row As DataGridViewRow In dgvBuste.SelectedRows
                'se il doc non è selezionato per l'invio
                If row.Cells("Doc").Value = False Then
                    Dim Query As String = String.Format("DELETE FROM Buste WHERE {0}", ImpostaParametriChiave(row))
                    Utx.WsCommand.ExecuteNonQueryRecord(Query)
                End If
            Next
            LeggiElencoDoc()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Function ImpostaParametriChiave(ByRef r As DataGridViewRow) As String
        Try
            Dim WhereChiave As New Utx.NetFunc.StringFormatter("Agenzia = @agenzia AND Ramo = @ramo AND Polizza = @polizza AND 
                Appendice = @appendice AND EffettoAppendice = '@effettoappendice' AND EffettoTitolo = '@effettotitolo' AND 
                DataFoglioCassa = '@datafogliocassa' AND TipoCarico = @tipocarico")

            With WhereChiave
                .Parametro("@agenzia", r.Cells("Agenzia").Value.ToString.PadLeft(5, "0"), True)
                .Parametro("@ramo", r.Cells("Ramo").Value)
                .Parametro("@polizza", r.Cells("Polizza").Value)
                .Parametro("@appendice", r.Cells("Appendice").Value)
                .Parametro("@effettoAppendice", r.Cells("EffettoAppendice").Value)
                .Parametro("@effettoTitolo", r.Cells("EffettoTitolo").Value)
                .Parametro("@datafogliocassa", r.Cells("DataFoglioCassa").Value)
                .Parametro("@tipocarico", r.Cells("TipoCarico").Value, True)
            End With
            Return WhereChiave.StringaFormattata
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Private Sub ButtonArchivioTrimestre_Click(sender As Object, e As EventArgs) Handles ButtonArchivioTrimestre.Click
        LeggiDocArchiviati(Today.AddMonths(-3))
    End Sub

    Private Sub CheckBoxMostraQuietanze_CheckedChanged(sender As Object, e As EventArgs)
        If CheckBoxMostraQuietanze.Checked = True Then
            CheckBoxMostraQuietanze.BackColor = Color.YellowGreen
        Else
            CheckBoxMostraQuietanze.BackColor = Color.Gold
        End If
        CheckBoxMostraQuietanze.Refresh()
        dgvBuste.DataSource = Nothing
    End Sub

    Private Sub ButtonOrdinamento_Click(sender As Object, e As EventArgs) Handles ButtonOrdinamento.Click
        Try
            Using f As New FormOrdinamento
                f.Griglia = dgvBuste
                f.ListaOrdinamento = ListaOrdimamento

                f.ShowDialog()

                'se si preme il bottone applica
                If f.DialogResult = Windows.Forms.DialogResult.OK Then

                    ListaOrdimamento = f.ListaOrdinamento

                    'se non c'è una lista per l'ordinamento imposto il predefinito
                    If ListaOrdimamento.Count = 0 Then
                        File.Delete(FileBusteXml)
                        OrdinamentoPredefinito()
                    End If

                    'salva l'ordinamento impostato
                    SalvaOrdinamento()

                    LeggiElencoDoc()
                End If
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Shared Function FileBusteXml() As String
        Return Path.Combine(Utx.Globale.Paths.CartellaSettingRete, "Buste.xml")
    End Function

    Public Sub SalvaOrdinamento()
        Try
            'salvo dati delegato
            Dim ser As New Xml.Serialization.XmlSerializer(GetType(List(Of ColonnaOrdinamento)))

            Using fs As New StreamWriter(FileBusteXml)
                ser.Serialize(fs, ListaOrdimamento)
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
            File.Delete(FileBusteXml)
        End Try
    End Sub

    Public Sub CaricaOrdinamentoUtente()
        Try
            If File.Exists(FileBusteXml) Then

                Dim ser As New Xml.Serialization.XmlSerializer(GetType(List(Of ColonnaOrdinamento)))

                Using fs As New StreamReader(FileBusteXml)
                    ListaOrdimamento = ser.Deserialize(fs)
                End Using
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            File.Delete(FileBusteXml)
        End Try
    End Sub

    Private Sub ButtonRecuperaIncasso_Click(sender As Object, e As EventArgs) Handles ButtonRecuperaIncasso.Click
        Try
            Using f As New FormRecuperoIncasso
                f.ShowDialog()

                If (f.Incasso IsNot Nothing) Then
                    Dim AppendiceOriginale As Integer = f.Incasso.Cells("Appendice").Value 'la memorizzo per eventuali modifiche

                    If EsisteIncasso(f.Incasso) = True Then
                        If MsgBox("Un titolo simile è già presente in elenco. Volete aggiungerlo comunque?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then
                            Do While True
                                f.Incasso.Cells("Appendice").Value += 10
                                If EsisteIncasso(f.Incasso) = False Then
                                    InserisciIncasso(f, AppendiceOriginale)
                                    Exit Do
                                End If
                            Loop
                        End If
                    ElseIf f.Incasso.Cells("DataFoglioCassa").Value >
                           Utx.WsCommand.ExecuteScalar("SELECT MAX(DataFoglioCassa) FROM Buste",
                                                       Utx.Globale.AgenziaRichiesta.CodiceAgenzia, Today).Valore Then
                        MsgBox("Foglio cassa non ancora importato. Utilizzare la funzione 'Aggiorna da essig'",
                               MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                    Else
                        InserisciIncasso(f, AppendiceOriginale)
                        LeggiElencoDoc()
                    End If
                End If
            End Using
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Function InserisciIncasso(f As FormRecuperoIncasso, AppendiceOriginale As Integer) As Boolean
        Try
            'l'appendice può essere modificata dal metodo chiamante per esigenze di chiave tabella
            Dim Sql As New Utx.NetFunc.StringFormatter("INSERT INTO Buste 
                            SELECT TOP 1 0 AS Inviato,NULL AS DataBusta,'@tipobusta' AS TipoBusta,Tipo,Format(Agenzia,'00000') AS Agenzia,
                            Ramo,Polizza,CodiceFiscInc AS CodiceFiscale,Contraente,@appmodificata AS Appendice,
                            DataEffettoAppendice AS EffettoAppendice,DataEffettoTitolo AS EffettoTitolo,TipoCarico,
                            DataFoglioCassa,Esito,TotaleTitolo,CodiceProdotto AS Prodotto,CodiceSubAgente AS SubAgenzia,
                            '' AS Stampato,Targa,0 AS Archivio,RamoGestione,'' AS Nota
                            FROM Incassi 
                            WHERE Agenzia = @agenzia AND Ramo = @ramo AND Polizza = @polizza AND TipoCarico = @tipocarico AND 
                                NumeroAppendice = @appendice AND DataEffettoAppendice = '@effettoappendice' AND 
                                DataEffettoTitolo = '@effettotitolo' AND DataFoglioCassa = '@fogliocassa' AND TotaleTitolo = @importo")
            With Sql.Parametri
                .Add("@tipobusta", Busta.RamoGestione2TipoBusta(f.Incasso.Cells("Ramogestione").Value, f.Incasso.Cells("Ramo").Value))
                .Add("@appmodificata", f.Incasso.Cells("Appendice").Value)
                .Add("@agenzia", f.Incasso.Cells("Agenzia").Value)
                .Add("@ramo", f.Incasso.Cells("Ramo").Value)
                .Add("@polizza", f.Incasso.Cells("Polizza").Value)
                .Add("@tipocarico", f.Incasso.Cells("TipoCarico").Value)
                .Add("@appendice", AppendiceOriginale)
                .Add("@effettoappendice", Format(f.Incasso.Cells("EffettoAppendice").Value, "dd/MM/yyyy"))
                .Add("@effettotitolo", Format(f.Incasso.Cells("EffettoTitolo").Value, "dd/MM/yyyy"))
                .Add("@fogliocassa", Format(f.Incasso.Cells("DataFoglioCassa").Value, "dd/MM/yyyy"))
                .Add("@importo", f.Incasso.Cells("TotaleTitolo").Value)
            End With
            If Utx.WsCommand.ExecuteNonQueryRecord(Sql.StringaFormattata) = 1 Then
                Return True
            Else
                MsgBox("Recupero incasso non riuscito", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Return False
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Private Function EsisteIncasso(ByRef Incasso As DataGridViewRow) As Boolean
        Try
            Dim Sql As String = String.Format("SELECT COUNT(*) FROM Buste WHERE {0}", ImpostaParametriChiave(Incasso))
            Return Utx.WsCommand.ExecuteScalar(Sql, Utx.Globale.AgenziaRichiesta.CodiceAgenzia).Valore > 0
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return True
        End Try
    End Function

    Private Sub dgvBuste_DataSourceChanged(sender As Object, e As EventArgs) Handles dgvBuste.DataSourceChanged
        FormFiltro = New Utx.FormGestioneFiltro(1000)
    End Sub

    Private Sub dgvArchivio_DataSourceChanged(sender As Object, e As EventArgs) Handles dgvArchivio.DataSourceChanged
        FormFiltroArchivio = New Utx.FormGestioneFiltro(1000)
    End Sub

#Region "Manutenzione"
    Private Sub ManutenzioneTabella()
        CancellazioneFEA()
    End Sub

    Private Sub CancellazioneFEA()
        Try
            ttsStato.Text = "Cancella FEA decadi precedenti"
            Dim Sql As String = String.Format("DELETE FROM Buste WHERE Tipo = 'F' AND DataFoglioCassa <= '{0:dd/MM/yyyy}'",
                                              Decade.DataFineDecadePrecedente(Today))
            Globale.Log.Info("FEA cancellate: {0}", {Utx.WsCommand.ExecuteNonQueryRecord(Sql)})
        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            ttsStato.Text = ""
        End Try
    End Sub
#End Region

    Private Sub TabControlMain_Selected(sender As Object, e As TabControlEventArgs) Handles TabControlMain.Selected
        Select Case e.TabPage.Name
            Case "TabPageBuste"
                If ArchivioModificato = True Then
                    ArchivioModificato = False
                    LeggiElencoDoc()
                End If
            Case "TabPageDoc"
                Cursor.Current = Cursors.WaitCursor
                If wbDocumentazione.Url = Nothing Then wbDocumentazione.Navigate(LinkDoc)
        End Select
    End Sub

    Private Sub ButtonRicarica_Click(sender As Object, e As EventArgs) Handles ButtonRicarica.Click
        If DateDiff(DateInterval.Month, dtpInizio.Value, dtpFine.Value) > 3 Then
            MsgBox("E' consentito un intervallo massimo di 3 mesi", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            Exit Sub
        End If
        LeggiElencoDoc()
    End Sub

    Private Sub ButtonCerca_Click(sender As Object, e As EventArgs) Handles ButtonCerca.Click
        Try
            If String.IsNullOrEmpty(TextBoxCerca.Text) Then
                Exit Try
            End If

            Dim dgv As DataGridView = dgvBuste
            If TabControlMain.SelectedTab Is TabPageArchivio Then
                dgv = dgvArchivio
            End If

            dgv.DataSource = Nothing
            dgv.Refresh()

            dgv.DataSource = Cerca()
            FormattaElencoDoc(dgv)
            FormattaColoriCelle(dgv)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Function Cerca() As DataTable
        Dim Inviato As Boolean = TabControlMain.SelectedTab Is TabPageArchivio
        Dim dt = New DataTable

        Try
            TextBoxCerca.Text = TextBoxCerca.Text.Replace("'", "").Replace("""", "")
            If Inviato = True Then
                'archivio
                dt = Utx.WsCommand.ExecuteNonQuery(CercaArchivioDoc(TextBoxCerca.Text.Trim)).DataTable
            Else
                dt = Utx.WsCommand.ExecuteNonQuery(CercaElencoDoc(TextBoxCerca.Text.Trim)).DataTable
            End If

            '    End Using
            'End Using
            Return dt

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return dt
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Sub dtpInizio_ValueChanged(sender As Object, e As EventArgs)
        On Error Resume Next
        If dtpFine.Value < dtpInizio.Value Then
            dtpFine.Value = dtpInizio.Value
        End If
    End Sub

    Private Sub ttsStato_TextChanged(sender As Object, e As EventArgs) Handles ttsStato.TextChanged
        StatusStrip1.Refresh()
    End Sub

    Private Sub FormDocumenti_ActivateDoc()
        Stato = Me.WindowState
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub FormDocumenti_CloseDoc()
        RemoveHandler FormDocumenti.ActivateDoc, AddressOf FormDocumenti_ActivateDoc
        RemoveHandler FormDocumenti.CloseDoc, AddressOf FormDocumenti_CloseDoc

        Me.WindowState = Me.Stato
    End Sub
End Class
