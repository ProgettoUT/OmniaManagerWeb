Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing

Public Class ucSinistri


    Public Event RowChanged(ByRef Sinistro As DataGridViewRow)
    Public Event NoRow()
    Public Event Errore(ex As Exception, Procedura As String)
    Public Event SumVisibleChanged(Visible As Boolean)
    Public Event EditCell(ByRef dgv As DataGridView, ea As DataGridViewCellMouseEventArgs)
    Public Event BeforeVistaChange(TipoVista As Vista.ElencoViste)
    Public Event AfterVistaChange(TipoVista As Vista.ElencoViste)
    Public Event MenuVistaChange(MenuAttivo As Boolean)
    Public Event VistaClose()
    Public Event SalvatoLayout(NomeLayout As String)
    Public Event EliminatoLayout(NomeLayout As String)
    Public Event CercaCliente(CodiceFiscale As String)
    Public Event CercaSinistro(Agenzia As Integer, Esercizio As Integer, Numero As Long)
    Public Event GestioneSinistroControparte(ByRef Sinistro As DataGridViewRow)

    Friend WithEvents FormFiltro As Utx.FormGestioneFiltro
    Friend WithEvents VistaCorrente As New Vista

    Private Const MODULO As String = "ucSinistri"

    Sub New()
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        If Utx.Globale.IdAppOk = False Then
            Application.Exit()
        End If
        CheckForIllegalCrossThreadCalls = False

        Me.Dock = Windows.Forms.DockStyle.Fill
        'per evitare sfarfallamenti durante il caricamento del layout
        'viene reso visibile dopo il caricamento del layout
        dgvSinistri.Visible = False

        ImpostaControlli()
    End Sub

    Private Sub ucSinistri_Load(sender As Object, e As EventArgs) Handles Me.Load
        VistaCorrente.TipoVista = Vista.ElencoViste.NORMALE
    End Sub

    Private Sub ImpostaControlli()
        Dim th As New Threading.Thread(Sub()
                                           FormFiltro = New Utx.FormGestioneFiltro(1000)
                                           With FormFiltro.GestoreLayout
                                               .Griglia = dgvSinistri
                                               .GestoreLayout = FormFiltro
                                           End With
                                       End Sub)
        th.Start()

        With tlpMain
            With .RowStyles.Item(0)
                .SizeType = SizeType.Absolute
                .Height = 50
            End With
            With .RowStyles.Item(1)
                .SizeType = SizeType.Absolute
                .Height = 16
            End With
            With .RowStyles.Item(2)
                .SizeType = SizeType.Percent
                .Height = 100
            End With
            With .RowStyles.Item(3)
                .SizeType = SizeType.Absolute
                .Height = 23
            End With
        End With

        With LabelDesk
            .Padding = New Padding(0)
            .Margin = New Padding(1, 0, 1, 0)
            .FlatStyle = FlatStyle.Flat
            .BorderStyle = Windows.Forms.BorderStyle.FixedSingle
            .BackColor = Color.Khaki
            .Font = Utx.AppFont.Bold
            .Text = ""
        End With
        With ButtonSopravvenienze
            .Dock = DockStyle.Fill
            .Margin = New Padding(1, 0, 1, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.SteelBlue
            .BackColor = Color.Lavender
            .Text = "Variazione costi"
        End With
        With ButtonVariazioniMeseAnno
            .Dock = DockStyle.Fill
            .Margin = New Padding(1, 0, 1, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Orange
            .BackColor = Color.Gold
            .Text = "Variazione costi su mese/anno"
        End With
        With ButtonPerizie
            .Dock = DockStyle.Fill
            .Margin = New Padding(1, 0, 1, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Salmon
            .BackColor = Color.Moccasin
            .Text = "Analisi perizie"
        End With
        With ButtonIndicatoreCliente
            .Dock = DockStyle.Fill
            .Margin = New Padding(1, 0, 1, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Green
            .BackColor = Color.PaleGreen
            .Text = "Indicatori sinistri per cliente"
        End With
        With ButtonControparte
            .Dock = DockStyle.Fill
            .Margin = New Padding(1, 0, 1, 0)
            .Padding = Utx.AppFont.ButtonPadding
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Green
            .BackColor = Color.WhiteSmoke
            .ForeColor = Color.Black
            .Image = Risorse.Immagini.Bitmap("attenzione")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Sinistri aperti da controparte"
            .TextAlign = ContentAlignment.MiddleCenter
            .Visible = Utx.Tester.SinistriControparte(Utx.Globale.ProfiloEnteGestore.AgenziaMadre)
        End With
        With ButtonEsciViste
            .Dock = DockStyle.Fill
            .Margin = New Padding(1, 0, 1, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Red
            .BackColor = Color.LightSalmon
            .Text = "Chiudi"
        End With

        With dgvSinistri
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = True
            .CellBorderStyle = DataGridViewCellBorderStyle.Raised
            .Margin = New Padding(1)
        End With
        Utx.NetFunc.DoppioBuffer(dgvSinistri)

        With dgvTotali
            .Font = Utx.AppFont.Bold
            .ColumnHeadersVisible = False
            .SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = False
            .AllowUserToResizeColumns = False
            .ScrollBars = ScrollBars.None
            .Font = Utx.AppFont.Bold
            .Margin = New Padding(1)
        End With
    End Sub

    Public ReadOnly Property ListaLayout() As List(Of String)
        Get
            Return FormFiltro.GestoreLayout.ListaLayout
        End Get
    End Property

    Private mMenuViste As Boolean
    Public Property MenuViste() As Boolean
        Get
            Return mMenuViste
        End Get
        Set(value As Boolean)
            mMenuViste = value

            With tlpMain.RowStyles.Item(0)

                .SizeType = SizeType.Absolute
                'ridimensiono l'altezza della riga a seconda che ilmenù debba essere o meno visibile
                If mMenuViste = True Then
                    .Height = 50
                    LabelDesk.Text = ""
                Else
                    .Height = 0
                    LabelDesk.Text = String.Format("Sinistri consolidati al {0}", Format(mConsolidato, "dd-MM-yyyy"))
                End If
                tlpMenuViste.Visible = mMenuViste
            End With
            tlpMain.Refresh()

            RaiseEvent MenuVistaChange(mMenuViste)
        End Set
    End Property

    Private mConsolidato As Date
    Public Property Consolidato() As Date
        Get
            Return mConsolidato
        End Get
        Set(value As Date)
            mConsolidato = value
        End Set
    End Property

    Private mRigaTotali As Boolean
    Public Property RigaTotali() As Boolean
        Get
            Return mRigaTotali
        End Get
        Set(value As Boolean)
            mRigaTotali = value

            With tlpMain.RowStyles.Item(3)

                .SizeType = SizeType.Absolute

                If mRigaTotali = True Then
                    .Height = 30
                Else
                    .Height = 0
                End If
            End With

            RaiseEvent SumVisibleChanged(mRigaTotali)
        End Set
    End Property

    Private Sub dgvSinistri_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvSinistri.CellMouseDoubleClick
        If e.RowIndex >= 0 Then
            Select Case VistaCorrente.TipoVista
                Case Vista.ElencoViste.INDICATORE_CLIENTE
                    Vista.Persistenza.Salva(dgvSinistri.DataSource, VistaCorrente.TipoVista, FormFiltro)
                    Dim CF As String = dgvSinistri.CurrentRow.Cells("CodiceFiscContrPol").Value
                    RaiseEvent VistaClose()
                    RaiseEvent CercaCliente(CF)
                Case Vista.ElencoViste.APERTI_CONTROPARTE, Vista.ElencoViste.VARIAZIONE_COSTI_MESE_ANNO, Vista.ElencoViste.PERIZIE
                    Vista.Persistenza.Salva(dgvSinistri.DataSource, VistaCorrente.TipoVista, FormFiltro)
                    Dim Ente As Integer = dgvSinistri.CurrentRow.Cells("AgenziaSinistro").Value
                    Dim Esercizio As Integer = dgvSinistri.CurrentRow.Cells("EsercizioSinistro").Value
                    Dim Numero As Long = dgvSinistri.CurrentRow.Cells("NumeroSinistro").Value
                    RaiseEvent VistaClose()
                    RaiseEvent CercaSinistro(Ente, Esercizio, Numero)
                Case Vista.ElencoViste.NORMALE
                    RaiseEvent EditCell(dgvSinistri, e)
            End Select
        End If
    End Sub

    Private Sub dgvSinistri_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles dgvSinistri.ColumnAdded
        dgvTotali.Columns.Add(e.Column.Clone)
    End Sub

    Private Sub dgvSinistri_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvSinistri.ColumnHeaderMouseClick
        VisualizzaFiltro(e.ColumnIndex)
    End Sub

    Public Sub VisualizzaFiltro(IndiceColonna As Integer, Optional Centra As Boolean = False)
        Try
            If (dgvSinistri.DataSource IsNot Nothing) Then
                'cartella per salvataggio filtro
                With FormFiltro
                    .AppName = VistaCorrente.Layout
                    .FilterFolder = Utx.Globale.Paths.CartellaSettingRete
                    .TabVisibili(True, False)

                    'visualizzo la finestra del filtro
                    .Visualizza(dgvSinistri.Columns(IndiceColonna), Centra)
                End With
                'aggiorno i totali
                Dim tt As New Threading.Thread(AddressOf SommaColonne)
                tt.Start()

                RaiseEvent RowChanged(dgvSinistri.CurrentRow)
            End If

        Catch ex As Exception
            RaiseError(ex, System.Reflection.MethodInfo.GetCurrentMethod.Name)
        End Try
    End Sub

    Public Sub VisualizzaDettaglio()
        Try
            If (dgvSinistri.DataSource IsNot Nothing) Then
                'cartella per salvataggio filtro
                With FormFiltro
                    .AppName = VistaCorrente.Layout
                    .FilterFolder = Utx.Globale.Paths.CartellaSettingRete
                    .TabVisibili(True, False)

                    'visualizzo il dettaglio dei filtri
                    .VisualizzaDettaglio(dgvSinistri.Columns("Compagnia"))
                End With
            End If

        Catch ex As Exception
            RaiseError(ex, System.Reflection.MethodInfo.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub dgvSinistri_ColumnWidthChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles dgvSinistri.ColumnWidthChanged
        dgvTotali.Columns(e.Column.Name).Width = e.Column.Width
        dgvTotali.HorizontalScrollingOffset = dgvSinistri.HorizontalScrollingOffset
        FormFiltro.MarcaturaColonne()
    End Sub

    Private Sub dgvSinistri_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgvSinistri.CurrentCellChanged
        If dgvSinistri.CurrentRow IsNot Nothing Then
            RaiseEvent RowChanged(dgvSinistri.CurrentRow)
        End If
    End Sub

    Private Sub dgvSinistri_DataSourceChanged(sender As Object, e As EventArgs) Handles dgvSinistri.DataSourceChanged
        dgvSinistri.Refresh()
        If dgvSinistri.DataSource IsNot Nothing Then
            Dim tt As New Threading.Thread(AddressOf SommaColonne)
            tt.Start()

            If dgvSinistri.CurrentRow Is Nothing Then
                RaiseEvent NoRow()
            Else
                RaiseEvent RowChanged(dgvSinistri.CurrentRow)
            End If
        Else
            AzzeraTotali()
        End If
    End Sub

    Private Sub dgvSinistri_Scroll(sender As Object, e As ScrollEventArgs) Handles dgvSinistri.Scroll
        If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then
            Exit Sub
        End If

        If dgvSinistri.Rows.Count > 0 And dgvTotali.Rows.Count > 0 Then
            dgvTotali.HorizontalScrollingOffset = e.NewValue
        End If
    End Sub

    Public Sub CaricaLayout(NomeLayout As String)
        dgvSinistri.SuspendLayout()
        'resetto il ds
        Dim source As Object = dgvSinistri.DataSource
        dgvSinistri.DataSource = Nothing

        'imposto il nuovo
        FormFiltro.GestoreLayout.LayoutCorrente = NomeLayout

        'imposto il layout della riga di somma
        CaricaLayoutTotali()

        'imposto nuovamente il ds
        dgvSinistri.DataSource = source
        dgvSinistri.ResumeLayout()
    End Sub

    Private Sub CaricaLayoutTotali()
        Try
            dgvTotali.Rows.Clear()
            dgvTotali.Columns.Clear()

            'imposto le colonne
            Dim ct As DataGridViewTextBoxColumn

            For Each col As DataGridViewColumn In dgvSinistri.Columns

                ct = New DataGridViewTextBoxColumn

                With ct
                    .Name = col.Name
                    .DataPropertyName = col.Name
                    .Width = col.Width
                    .Visible = col.Visible
                    .DisplayIndex = col.DisplayIndex
                    .DefaultCellStyle.Alignment = col.DefaultCellStyle.Alignment
                    .DefaultCellStyle.Format = col.DefaultCellStyle.Format
                End With

                dgvTotali.Columns.Add(ct)
            Next
            'aggiungo una riga vuota
            dgvTotali.Rows.Add()

            'colore sfondo
            dgvTotali.Rows(0).DefaultCellStyle.BackColor = Color.Moccasin
            'colore selezione (invisibile)
            dgvTotali.DefaultCellStyle.SelectionBackColor = dgvTotali.Rows(0).DefaultCellStyle.BackColor
            dgvTotali.DefaultCellStyle.SelectionForeColor = dgvTotali.DefaultCellStyle.ForeColor
            'regolo altezza
            dgvTotali.Rows(0).Height = dgvTotali.Height
            'intestazione riga e tooltip
            dgvTotali.Rows(0).HeaderCell.Value = "∑"
            dgvTotali.Rows(0).HeaderCell.ToolTipText = "Somma della colonna"

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub SommaColonne()
        Try
            'se i totali devono essere visualizzati
            If mRigaTotali = True Then
                'se c'è il ds
                If dgvSinistri.DataSource IsNot Nothing Then

                    AzzeraTotali()

                    If dgvTotali.Rows.Count > 0 Then
                        'calcolo le somme
                        For Each r As DataGridViewRow In dgvSinistri.Rows
                            For Each item As Vista.Totale In VistaCorrente.ListaCampiSomma
                                Try
                                    If IsNumeric(r.Cells(item.Campo).Value) Then
                                        item.Valore += r.Cells(item.Campo).Value
                                    End If
                                Catch ex As Exception
                                    AzzeraTotali()
                                    Globale.Log.Info(ex.Message)
                                    Globale.Log.Info("sommo " & item.Campo & " - " & r.Cells(item.Campo).Value.ToString)
                                    dgvTotali.Visible = True
                                    Exit Sub
                                End Try
                            Next
                        Next
                    End If
                End If
            Else
                AzzeraTotali()
            End If

        Catch ex As Exception
            AzzeraTotali()
            Globale.Log.Info(ex.Message)
        End Try

        'metto i totali in griglia
        Try
            For Each item As Vista.Totale In VistaCorrente.ListaCampiSomma
                dgvTotali.Rows(0).Cells(item.Campo).Value = item.Valore
            Next
            'calcoli extra
            If VistaCorrente.TipoVista = Vista.ElencoViste.INDICATORE_CLIENTE Then
                'scrivo le percentuali
                If dgvTotali.Rows(0).Cells("PremiStoriciAuto").Value <> 0 Then
                    dgvTotali.Rows(0).Cells("PercAuto").Value =
                                    dgvTotali.Rows(0).Cells("SinistriStoriciAuto").Value / dgvTotali.Rows(0).Cells("PremiStoriciAuto").Value * 100
                End If
                If dgvTotali.Rows(0).Cells("PremiStoriciRE").Value <> 0 Then
                    dgvTotali.Rows(0).Cells("PercRE").Value =
                                    dgvTotali.Rows(0).Cells("SinistriStoriciRE").Value / dgvTotali.Rows(0).Cells("PremiStoriciRE").Value * 100
                End If
                If dgvTotali.Rows(0).Cells("PremiStoriciTotali").Value <> 0 Then
                    dgvTotali.Rows(0).Cells("PercTotale").Value =
                                    dgvTotali.Rows(0).Cells("SinistriStoriciTotali").Value / dgvTotali.Rows(0).Cells("PremiStoriciTotali").Value * 100
                End If
            End If

        Catch ex As Exception
            Globale.Log.Info(ex.Message)
        End Try
    End Sub

    Private Sub AzzeraTotali()
        Try
            For Each item As Vista.Totale In VistaCorrente.ListaCampiSomma
                item.Valore = 0
                dgvTotali.Rows(0).Cells(item.Campo).Value = DBNull.Value
            Next
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    'Private Sub SommaColonne()
    '    Try
    '        'se i totali devono essere visualizzati
    '        If mRigaTotali = True Then
    '            'se c'è il ds
    '            If dgvSinistri.DataSource IsNot Nothing Then
    '                dgvTotali.Visible = False

    '                AzzeraTotali()

    '                If dgvTotali.Rows.Count > 0 Then
    '                    'calcolo le somme
    '                    For Each r As DataGridViewRow In dgvSinistri.Rows
    '                        For Each campo As String In VistaCorrente.ListaCampiSomma
    '                            Try
    '                                If IsNumeric(r.Cells(campo).Value) Then
    '                                    dgvTotali.Rows(0).Cells(campo).Value += r.Cells(campo).Value
    '                                End If
    '                            Catch ex As Exception
    '                                AzzeraTotali()
    '                                Globale.Log.Info(ex.Message)
    '                                Globale.Log.Info("sommo " & campo & " - " & r.Cells(campo).Value.ToString)
    '                                dgvTotali.Visible = True
    '                                Exit Sub
    '                            End Try
    '                        Next
    '                    Next
    '                    If VistaCorrente.TipoVista = Vista.ElencoViste.INDICATORE_CLIENTE Then
    '                        'scrivo le percentuali
    '                        If dgvTotali.Rows(0).Cells("PremiStoriciAuto").Value <> 0 Then
    '                            dgvTotali.Rows(0).Cells("PercAuto").Value =
    '                                dgvTotali.Rows(0).Cells("SinistriStoriciAuto").Value / dgvTotali.Rows(0).Cells("PremiStoriciAuto").Value * 100
    '                        End If
    '                        If dgvTotali.Rows(0).Cells("PremiStoriciRE").Value <> 0 Then
    '                            dgvTotali.Rows(0).Cells("PercRE").Value =
    '                                dgvTotali.Rows(0).Cells("SinistriStoriciRE").Value / dgvTotali.Rows(0).Cells("PremiStoriciRE").Value * 100
    '                        End If
    '                        If dgvTotali.Rows(0).Cells("PremiStoriciTotali").Value <> 0 Then
    '                            dgvTotali.Rows(0).Cells("PercTotale").Value =
    '                                dgvTotali.Rows(0).Cells("SinistriStoriciTotali").Value / dgvTotali.Rows(0).Cells("PremiStoriciTotali").Value * 100
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        Else
    '            AzzeraTotali()
    '        End If

    '    Catch ex As Exception
    '        AzzeraTotali()
    '        Globale.Log.Info(ex.Message)
    '    Finally
    '        dgvTotali.Visible = True
    '    End Try
    'End Sub

    'Private Sub AzzeraTotali()
    '    Try
    '        For Each campo As String In VistaCorrente.ListaCampiSomma
    '            dgvTotali.Rows(0).Cells(campo).Value = 0
    '        Next
    '    Catch ex As Exception
    '        Globale.Log.Errore(ex)
    '    Finally
    '        dgvTotali.Refresh()
    '    End Try
    'End Sub

    Public Sub SalvaLayout()
        'salvo il layout da cui sto uscendo
        FormFiltro.GestoreLayout.SalvaLayout()
    End Sub

    Public Sub ImpostaLayoutPredefinito(NomeLayout As String)
        FormFiltro.GestoreLayout.ImpostaLayoutPredefinito(NomeLayout)
    End Sub

    Private Sub RaiseError(ex As Exception, Procedura As String)
        RaiseEvent Errore(ex, String.Format("{0}.{1}", MODULO, Procedura))
    End Sub

    Private Sub ucSinistri_SumVisibleChanged(Visible As Boolean) Handles Me.SumVisibleChanged
        If Visible = True Then
            Dim tt As New Threading.Thread(AddressOf SommaColonne)
            tt.Start()
        End If
        dgvTotali.HorizontalScrollingOffset = dgvSinistri.HorizontalScrollingOffset
    End Sub

    Private Sub VistaCorrente_AfterVistaChanged(TipoVista As Vista.ElencoViste) Handles VistaCorrente.AfterVistaChange
        FormFiltro.GestoreLayout.XmlSetting = VistaCorrente.Layout
        RaiseEvent AfterVistaChange(TipoVista)
    End Sub

    Private Sub VistaCorrente_BeforeVistaChange(TipoVista As Vista.ElencoViste) Handles VistaCorrente.BeforeVistaChange
        SalvaLayout()
        dgvSinistri.DataSource = Nothing
        RaiseEvent BeforeVistaChange(TipoVista)
    End Sub

    Public Sub ImpostaLayout()
        Try
            'cartella per salvataggio filtro
            With FormFiltro
                .AppName = VistaCorrente.Layout
                .FilterFolder = Utx.Globale.Paths.CartellaSettingRete
                .TabVisibili(False, True)
                'visualizzo la finestra del layout. la colonna serve per passare indirettamente il datasource
                .Visualizza(dgvSinistri.Columns(0))
            End With

        Catch ex As Exception
            RaiseError(ex, System.Reflection.MethodInfo.GetCurrentMethod.Name)
        End Try
    End Sub

    Private Sub FormFiltro_SalvatoLayout(NomeLayout As String) Handles FormFiltro.SalvatoLayout
        RaiseEvent SalvatoLayout(NomeLayout)
    End Sub

    Private Sub FormFiltro_EliminatoLayout(NomeLayout As String) Handles FormFiltro.EliminatoLayout
        RaiseEvent EliminatoLayout(NomeLayout)
    End Sub

    Public Function AggiornaListaLayout() As List(Of String)
        FormFiltro.GestoreLayout.LeggiListaLayout() 'per aggiornare la lista
        Return FormFiltro.GestoreLayout.ListaLayout
    End Function

    Private Sub ButtonEsciViste_Click(sender As Object, e As EventArgs) Handles ButtonEsciViste.Click
        Vista.Persistenza.Reset()
        RaiseEvent VistaClose()
    End Sub

    Private Sub ButtonSopravvenienze_Click(sender As Object, e As EventArgs) Handles ButtonSopravvenienze.Click
        LabelDesk.Text = "Variazione costi"
        VistaCorrente.TipoVista = Vista.ElencoViste.SOPRAVVENIENZE
    End Sub

    Private Sub ButtonPerizie_Click(sender As Object, e As EventArgs) Handles ButtonPerizie.Click
        LabelDesk.Text = "Analisi perizie"
        VistaCorrente.TipoVista = Vista.ElencoViste.PERIZIE
    End Sub

    Private Sub ButtonIndicatoreCliente_Click(sender As Object, e As EventArgs) Handles ButtonIndicatoreCliente.Click
        Vista.Persistenza.Reset()
        LabelDesk.Text = "Indicatori sinistri per cliente"
        VistaCorrente.TipoVista = Vista.ElencoViste.INDICATORE_CLIENTE
    End Sub

    Private Sub ButtonControparte_Click(sender As Object, e As EventArgs) Handles ButtonControparte.Click
        LabelDesk.Text = "Sinistri aperti da controparte"
        VistaCorrente.TipoVista = Vista.ElencoViste.APERTI_CONTROPARTE
    End Sub

    Private Sub ButtonVariazioniMeseAnno_Click(sender As Object, e As EventArgs) Handles ButtonVariazioniMeseAnno.Click
        Vista.Persistenza.Reset()
        LabelDesk.Text = "Variazione costi su mese/anno"
        VistaCorrente.TipoVista = Vista.ElencoViste.VARIAZIONE_COSTI_MESE_ANNO
    End Sub

    Private Sub dgvSinistri_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvSinistri.RowHeaderMouseClick
        If VistaCorrente.TipoVista = Vista.ElencoViste.APERTI_CONTROPARTE Then
            If dgvSinistri.CurrentRow IsNot Nothing Then
                RaiseEvent GestioneSinistroControparte(dgvSinistri.CurrentRow)
            End If
        End If
    End Sub

    Private Sub ButtonEsciViste_DragDrop(sender As Object, e As DragEventArgs) Handles ButtonEsciViste.DragDrop
        Vista.Persistenza.Reset()
    End Sub
End Class
