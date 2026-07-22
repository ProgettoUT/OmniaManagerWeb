Imports System.Windows.Forms
Imports System.Drawing
Imports System.Xml
Imports System.IO

Public Class FormGestioneFiltro

    'Private Rec As New Performance("Filtro.log")

    Private Const MaxNumeroOperatori As Integer = 200

    Private mColoreCombo As Color = Color.Khaki
    Private mEsistonoVuoti As Boolean
    Private mColonna As DataGridViewColumn
    Private ElementiColonna As ItemsColonna
    Private WithEvents TimerCerca As New Timer
    Private tt As New ToolTip

    Friend FiltriColonna As List(Of FiltroColonna)
    Private LayoutColonne As List(Of LayoutColonna)

#Region "Proprietà"

    Private mCampo As String
    Public Property Campo() As String
        Get
            Return mCampo
        End Get
        Set(ByVal value As String)
            mCampo = value
        End Set
    End Property

    Public Property ColoreSfondo() As Color
        Get
            Return Me.Panel1.BackColor
        End Get
        Set(ByVal value As Color)
            Me.Panel1.BackColor = value
        End Set
    End Property

    Private mTipoCampo As Type
    Public Property TipoCampo() As Type
        Get
            Return mTipoCampo
        End Get
        Set(ByVal value As Type)
            mTipoCampo = value
        End Set
    End Property

    Private mQuery As String
    Public Property Query() As String
        Get
            Return mQuery
        End Get
        Set(ByVal value As String)
            mQuery = value
        End Set
    End Property

    Public Property Titolo() As String
        Get
            Return LabelCampo.Text
        End Get
        Set(ByVal value As String)
            LabelCampo.Text = Microsoft.VisualBasic.Left(value, 35)
        End Set
    End Property

    Public ReadOnly Property EsisteFiltro() As Boolean
        Get
            If mQuery Is Nothing Then
                Return False
            Else
                Return (mQuery.Length > 0)
            End If
        End Get
    End Property

    Private mAppName As String
    Public Property AppName() As String
        Get
            Return mAppName
        End Get
        Set(ByVal value As String)
            mAppName = value
        End Set
    End Property

    Private mFilterFolder As String
    Public Property FilterFolder() As String
        Get
            Return mFilterFolder
        End Get
        Set(ByVal value As String)
            mFilterFolder = value
        End Set
    End Property
#End Region

#Region "gestione form"
    Sub New(Optional ByVal MaxNumeroItemLista As Integer = 1000)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.AcceptButton = ButtonOk

        ElementiColonna = New ItemsColonna(MaxNumeroItemLista)

        ImpostaControlli()

        FiltriColonna = New List(Of FiltroColonna)
        LayoutColonne = New List(Of LayoutColonna)

        CheckedListBoxValori.CheckOnClick = True
    End Sub

    Private Sub FormFiltro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Cursor = Cursors.WaitCursor

        'disabilito il timer
        TimerCerca.Enabled = False
        TimerCerca.Interval = 1000

        'resetto i result
        ButtonOrdinaCrescente.DialogResult = DialogResult.None
        ButtonOrdinaDescrescente.DialogResult = DialogResult.None
        ButtonOk.DialogResult = DialogResult.None
        ButtonAnnulla.DialogResult = DialogResult.None

        CaricaOperatori()
        TextBoxValore.Text = ""

        TextBoxCerca.Text = ""
        AddHandler TextBoxCerca.TextChanged, AddressOf TextBoxCerca_TextChanged

        'carico la lista da visualizzare nel checkedlistbox
        CaricaListaFiltro()
    End Sub

    Private Sub FormGestioneFiltro_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Cursor = Cursors.Default
        Me.Refresh()
        TextBoxCerca.Focus()
        'Rec.AddLog("exit show: " + Campo)
    End Sub

    Private Sub FormGestioneFiltro_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        RemoveHandler CheckedListBoxValori.ItemCheck, AddressOf CheckedListBoxValori_ItemCheck
        RemoveHandler CheckedListBoxColonne.ItemCheck, AddressOf CheckedListBoxColonne_ItemCheck
        RemoveHandler TextBoxCerca.TextChanged, AddressOf TextBoxCerca_TextChanged

        CheckedListBoxValori.Items.Clear()
        TabControlMain.SelectedTab = TabPageFiltri
        TimerCerca.Enabled = False
    End Sub

    Private Sub ImpostaControlli()

        tt.IsBalloon = False

        Panel1.BackColor = Color.Red

        'scheda filtri
        With ButtonOrdinaCrescente
            .Text = "Ordina dalla A alla Z"
            .TextAlign = ContentAlignment.MiddleCenter
            .Image = My.Resources.az.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonOrdinaDescrescente
            .Text = "Ordina dalla Z alla A"
            .TextAlign = ContentAlignment.MiddleCenter
            .Image = My.Resources.za.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonCancellaFiltri
            .Text = "Cancella filtri per il campo"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = My.Resources.cancel16.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonCancellaTuttiFiltri
            .Text = "Cancella tutti"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = My.Resources.cancel16.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonMostraTutto
            .Text = ""
            .Image = My.Resources.list
            .ImageAlign = ContentAlignment.MiddleCenter
        End With
        With ButtonDettaglio
            .Text = ""
            .Image = My.Resources.salva16.ToBitmap
            .ImageAlign = ContentAlignment.MiddleCenter
        End With
        tt.SetToolTip(ButtonMostraTutto, "Visualizza elenco completo")
        tt.SetToolTip(ButtonCancellaTuttiFiltri, "Cancella tutti i filtri")
        tt.SetToolTip(ButtonDettaglio, "Dettaglio, salva o carica")

        TextBoxCerca.TextAlign = HorizontalAlignment.Center

        'scheda layout
        With ButtonColori
            .Text = "Modifica colore colonna"
            .TextAlign = ContentAlignment.MiddleCenter
            .Image = My.Resources.color.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonResetLayout
            .Text = "Elimina personalizzazioni"
            .TextAlign = ContentAlignment.MiddleCenter
            .Image = My.Resources.cancel16.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With

    End Sub

    Private Sub CaricaOperatori()

        'operatori
        With ComboBoxOperatori
            .BackColor = mColoreCombo

            .Items.Clear()

            Dim op As New Operatori(TipoCampo)

            For Each o As Operatore In op.ListaOperatori

                If o.Codice <> Operatori.CodiceOperatore.NESSUNO Then
                    .Items.Add(o)
                End If
            Next

            .DisplayMember = "Descrizione"
            .SelectedIndex = 0
        End With
    End Sub

    Private Sub CheckedListBoxValori_ItemCheck(sender As Object, e As ItemCheckEventArgs)

        RemoveHandler CheckedListBoxValori.ItemCheck, AddressOf CheckedListBoxValori_ItemCheck

        Dim ItemCorrente As ItemColonna = CheckedListBoxValori.Items(e.Index)

        If ItemCorrente.Testo = ItemsColonna.Tag.TuttiDesk Then
            'modificato (seleziona tutti)
            ModificaTuttiCheck(CheckedListBoxValori, e.NewValue)
        Else
            ItemCorrente.Selezionato = e.NewValue

            'se l'elemento è stato selezionato
            If e.NewValue = CheckState.Checked Then

                'se esiste seleziona tutti
                If EsisteSelezionaTutti() Then

                    'se gli elementi deselezionati prima della modifica erano solo 2
                    If CheckedListBoxValori.CheckedItems.Count = CheckedListBoxValori.Items.Count - 2 Then
                        'allora selezionare (seleziona tutti)
                        CheckedListBoxValori.SetItemChecked(0, True)
                    End If
                End If
            Else
                'deselezionato un elemento bisogna deselezionare (Seleziona tutti)
                If EsisteSelezionaTutti() Then
                    CheckedListBoxValori.SetItemChecked(0, False)
                End If
            End If
        End If

        AddHandler CheckedListBoxValori.ItemCheck, AddressOf CheckedListBoxValori_ItemCheck
    End Sub

#End Region

    Private Function EsisteFiltroCampo(ByVal Campo As String) As FiltroColonna.TipologiaFiltri

        For Each f As FiltroColonna In FiltriColonna

            If f.Campo = Campo Then
                Return f.TipoFiltro
            End If
        Next

        Return FiltroColonna.TipologiaFiltri.NESSUNO

    End Function

    Private Function FiltroPrecedente(ByVal Campo As String) As FiltroColonna

        For Each f As FiltroColonna In FiltriColonna

            If (f.TipoFiltro = FiltroColonna.TipologiaFiltri.CHECK) AndAlso (f.Campo = Campo) Then
                Return f
            End If
        Next

        Return New FiltroColonna
    End Function

    Private Sub EliminaFiltro(ByVal Tipo As FiltroColonna.TipologiaFiltri,
                              ByVal Campo As String)

        For Each f As FiltroColonna In FiltriColonna

            If (f.TipoFiltro = Tipo) AndAlso (f.Campo = Campo) Then
                FiltriColonna.Remove(f)
                Exit For
            End If
        Next
    End Sub

    ''' <summary>
    '''elimina filtro/i sul campo corrente
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EliminaFiltro()

        Do While True

            Dim Trovato As Boolean = False

            For Each f As FiltroColonna In FiltriColonna

                If f.Campo = mCampo Then
                    FiltriColonna.Remove(f)
                    Trovato = True
                    Exit For 'esco altrimenti errore per modifica collection
                End If
            Next

            If Trovato = False Then Exit Do
        Loop

        'modifico il font dell'intestazione
        mColonna.HeaderCell.Style.Font = FontNormale(mColonna)

        mQuery = CreazioneQuery.CreaQueryCompleta(FiltriColonna)
    End Sub

    Public Sub CancellaFiltri()

        'resetto i font
        For Each f As FiltroColonna In FiltriColonna

            Dim c As DataGridViewColumn = mColonna.DataGridView.Columns(f.Campo)

            c.HeaderCell.Style.Font = FontNormale(c)
        Next

        FiltriColonna.Clear()
        mQuery = ""
        ApplicaFiltro()
    End Sub

    Private Sub CaricaListaFiltro(Optional ByVal ForzaCaricamento As Boolean = False)
        'Rec.AddLog("carico lista: " + Campo)

        RemoveHandler CheckedListBoxValori.ItemCheck, AddressOf CheckedListBoxValori_ItemCheck

        tt.SetToolTip(ButtonMostraTutto, String.Format("Visualizza tutti i {0} elementi", ElementiColonna.Count))
        CheckedListBoxValori.Items.Clear()

        If (ForzaCaricamento = True) OrElse (ElementiColonna.Count <= ElementiColonna.MaxNumeroItem) Then

            Cursor = Cursors.WaitCursor

            For Each i As ItemColonna In ElementiColonna.Elementi
                CheckedListBoxValori.Items.Add(i, i.Selezionato)
            Next

            Cursor = Cursors.Default
        End If
        'Rec.AddLog("fine carico lista: " + Campo)

        CheckedListBoxValori.DisplayMember = "Testo"

        AddHandler CheckedListBoxValori.ItemCheck, AddressOf CheckedListBoxValori_ItemCheck
    End Sub

    Private Sub CaricaListaFiltro(ByVal ChiaveRicerca As String)

        RemoveHandler CheckedListBoxValori.ItemCheck, AddressOf CheckedListBoxValori_ItemCheck

        CheckedListBoxValori.Items.Clear()

        ChiaveRicerca = ChiaveRicerca.ToUpper

        'in modalità cerca con filtro se è selezionato "seleziona tutti" de-seleziono tutti
        If ElementiColonna.Elemento(0).Selezionato = True Then
            ElementiColonna.DeSelezionaTutti()
        End If

        For Each i As ItemColonna In ElementiColonna.Elementi

            If i.Testo.ToUpper.Contains(ChiaveRicerca) Then
                CheckedListBoxValori.Items.Add(i, i.Selezionato)
            End If
        Next

        CheckedListBoxValori.DisplayMember = "Testo"

        AddHandler CheckedListBoxValori.ItemCheck, AddressOf CheckedListBoxValori_ItemCheck
    End Sub

    Private Function FontNormale(ByRef c As DataGridViewColumn) As Font

        If c.HeaderCell.Style.Font Is Nothing Then
            Return New Font(c.DataGridView.DefaultCellStyle.Font.Name, c.DataGridView.DefaultCellStyle.Font.Size)
        Else
            Return New Font(c.HeaderCell.Style.Font.Name, c.HeaderCell.Style.Font.Size)
        End If
    End Function

    Private Function FontBold(ByRef c As DataGridViewColumn) As Font

        If c.HeaderCell.Style.Font Is Nothing Then
            Return New Font(c.DataGridView.DefaultCellStyle.Font.Name,
                            c.DataGridView.DefaultCellStyle.Font.Size, FontStyle.Bold)
        Else
            Return New Font(c.HeaderCell.Style.Font.Name,
                            c.HeaderCell.Style.Font.Size, FontStyle.Bold)
        End If
    End Function

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click

        If TabControlMain.SelectedTab Is TabPageFiltri Then
            'sono sulla scheda filtro

            If TextBoxValore.Text.Trim.Length = 0 Then
                'filtro CHECK poiché il campo valore dell'operatore è vuoto
                'creo il nuovo filtro per il campo specificato
                AddFiltroCheck()
            Else 'filtro OPERATORE
                AddFiltroOperatore()
            End If

            'creo il filtro totale
            mQuery = CreazioneQuery.CreaQueryCompleta(FiltriColonna)
            'applico il filtro al datasource
            ApplicaFiltro()
        Else
            'sono su scheda layout
            ImpostaLayout()
        End If

        ButtonOk.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ImpostaLayout()

        If CheckedListBoxColonne.CheckedItems.Count = 0 Then
            MsgBox("E' necessario selezionare almeno una colonna", MsgBoxStyle.Exclamation, "Layout")
        Else
            For Each c As DataGridViewColumn In mColonna.DataGridView.Columns

                For Each l As LayoutColonna In LayoutColonne

                    If l.Campo = c.Name Then
                        c.Visible = l.Visibile
                    End If
                Next
            Next

            ButtonOk.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If

    End Sub

    Private Sub MarcaturaColonneFiltrate()

        For Each f As FiltroColonna In FiltriColonna

            'recupero la colonna
            Dim col As DataGridViewColumn = mColonna.DataGridView.Columns(f.Campo)

            'marco la colonna con il grassetto se c'è filtro
            If Me.EsisteFiltroCampo(f.Campo) <> FiltroColonna.TipologiaFiltri.NESSUNO Then
                col.HeaderCell.Style.Font = FontBold(col)
            Else
                col.HeaderCell.Style.Font = FontNormale(col)
            End If
        Next
    End Sub

    Private Sub ResetMarcaturaColonneFiltrate()

        For Each f As FiltroColonna In FiltriColonna
            'recupero la colonna
            Dim col As DataGridViewColumn = mColonna.DataGridView.Columns(f.Campo)
            col.HeaderCell.Style.Font = FontNormale(col)
        Next
    End Sub

    Private Sub ApplicaFiltro()

        If mColonna.DataGridView.DataSource.GetType.Name = "DataView" Then
            mColonna.DataGridView.DataSource.RowFilter = mQuery
        ElseIf mColonna.DataGridView.DataSource.GetType.Name = "DataTable" Then
            mColonna.DataGridView.DataSource.DefaultView.RowFilter = mQuery
        ElseIf mColonna.DataGridView.DataSource.GetType.Name = "BindingSource" Then
            mColonna.DataGridView.DataSource.DataSource.DefaultView.RowFilter = mQuery
        End If

        MarcaturaColonneFiltrate()
    End Sub

    Private Sub ButtonOrdinaCrescente_Click(sender As Object, e As EventArgs) Handles ButtonOrdinaCrescente.Click
        mColonna.DataGridView.Sort(mColonna, System.ComponentModel.ListSortDirection.Ascending)
        ButtonOrdinaCrescente.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ButtonOrdinaDescrescente_Click(sender As Object, e As EventArgs) Handles ButtonOrdinaDescrescente.Click
        mColonna.DataGridView.Sort(mColonna, System.ComponentModel.ListSortDirection.Descending)
        ButtonOrdinaDescrescente.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub AddFiltroCheck()

        'aggiungo un filtro di tipo CHECK all'insieme dei filtri per il campo corrente

        'elimino il filtro precedente per il campo se non è attivata la ricerca. in questo caso
        'esiste l'elemento (seleziona tutti)
        EliminaFiltro(FiltroColonna.TipologiaFiltri.CHECK, Campo)

        Dim Selezionati, Deselezionati As Integer
        Dim SelezionatoTutti As Boolean

        ElementiColonna.ContaElementi(Selezionati, Deselezionati, SelezionatoTutti)

        'creo il nuovo filtro se NON è selezionato tutti
        If SelezionatoTutti = False Then

            Dim Filtro As New FiltroColonna

            Filtro.Campo = Campo
            Filtro.DeskCampo = mColonna.HeaderText
            Filtro.TipoCampo = TipoCampo
            Filtro.TipoFiltro = FiltroColonna.TipologiaFiltri.CHECK
            Filtro.Operatore = New Operatore
            Filtro.Chiave = ""

            If Selezionati <= Deselezionati Then
                Filtro.AddRange(ElementiColonna.ItemSelezionati)
                Filtro.Elementi = FiltroColonna.ElementiLista.SELEZIONATI
            Else
                Filtro.AddRange(ElementiColonna.ItemDeselezionati)
                Filtro.Elementi = FiltroColonna.ElementiLista.NON_SELEZIONATI
            End If

            'se non ci sono troppi operatori
            If NumeroOperatoriOk(Filtro) = True Then

                Filtro.Query = New CreazioneQuery(Filtro).Query

                'aggiungo il filtro alla lista dei filtri colonna
                If Filtro.Query.Length > 0 Then
                    FiltriColonna.Add(Filtro)
                End If
            End If
        End If
    End Sub

    Private Sub AddFiltroOperatore()

        'aggiungo un filtro di tipo OPERATORE all'insieme dei filtri
        Dim Filtro As New FiltroColonna
        Filtro.Campo = Campo
        Filtro.DeskCampo = mColonna.HeaderText
        Filtro.TipoCampo = TipoCampo
        Filtro.TipoFiltro = FiltroColonna.TipologiaFiltri.OPERATORE
        Filtro.Operatore = ComboBoxOperatori.SelectedItem
        Filtro.Chiave = TextBoxValore.Text.Replace("'", "''").ToUpper

        Filtro.Query = New CreazioneQuery(Filtro).Query

        'aggiungo il filtro alla lista dei filtri colonna
        If Filtro.Query.Length > 0 Then
            FiltriColonna.Add(Filtro)
        End If
    End Sub

    Private Function NumeroOperatoriOk(ByRef Filtro As FiltroColonna) As Boolean

        'numero operatori totali del filtro attuale
        Dim NumeroValori As Integer = Filtro.Items.Count

        'conto i valori precedenti
        For Each f As FiltroColonna In FiltriColonna

            If f.TipoFiltro = FiltroColonna.TipologiaFiltri.CHECK Then
                NumeroValori += f.Items.Count
            Else
                NumeroValori += 1
            End If
        Next

        If NumeroValori <= MaxNumeroOperatori Then
            Return True
        Else
            MsgBox("Selezionati troppi elementi. Scegliere un altro tipo di filtro.", MsgBoxStyle.Exclamation, "Filtro")
            Return False
        End If

    End Function

    Private Function EsisteSelezionaTutti() As Boolean
        'seleziona tutti è sempre il primo elemento
        If CheckedListBoxValori.Items.Count > 0 Then
            Return (CheckedListBoxValori.Items(0).Testo = ItemsColonna.Tag.TuttiDesk)
        Else
            Return False
        End If
    End Function

    Private Sub ModificaTuttiCheck(ByRef Lista As CheckedListBox,
                                   ByVal Selezionato As CheckState)

        For k As Integer = 0 To Lista.Items.Count - 1
            Lista.SetItemChecked(k, Selezionato)
            Lista.Items(k).Selezionato = Selezionato
        Next
    End Sub

    Private Sub TextBoxValore_TextChanged(sender As Object, e As EventArgs) Handles TextBoxValore.TextChanged
        CheckedListBoxValori.Enabled = (TextBoxValore.Text.Trim.Length = 0)
    End Sub

    Private Sub ComboBoxOperatori_DropDown(sender As Object, e As EventArgs) Handles ComboBoxOperatori.DropDown
        ComboBoxOperatori.BackColor = Drawing.SystemColors.Window
    End Sub

    Private Sub ComboBoxOperatori_DropDownClosed(sender As Object, e As EventArgs) Handles ComboBoxOperatori.DropDownClosed
        ComboBoxOperatori.BackColor = mColoreCombo
        TextBoxValore.Focus()
    End Sub

    Private Sub ButtonCancellaFiltri_Click(sender As Object, e As EventArgs) Handles ButtonCancellaFiltri.Click
        EliminaFiltro()
        ApplicaFiltro()
        ButtonOk.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Public Sub Visualizza(ByRef Colonna As DataGridViewColumn)

        Try
            mColonna = Colonna

            'se fallisce il caricamento dei dati esce
            If CaricaElencoDati() = False Then
                Exit Sub
            End If

            'visualizzo il form del filtro
            With Me
                .StartPosition = FormStartPosition.Manual
                .FormBorderStyle = Windows.Forms.FormBorderStyle.None
                .Size = New Size(280, 380)

                'calcolo la posizione della finestra.
                'Offset mi serve per spostare (di poco) il form rispetto al cursore
                Dim Offset As Integer = 5
                Dim Posizione As Point = New Point(Cursor.Position.X - Offset, Cursor.Position.Y - Offset)

                'controllo che margine destro non esca dallo schermo
                If Posizione.X + .Width > Screen.PrimaryScreen.WorkingArea.Width Then
                    Posizione.X -= .Width - 10
                End If
                'controllo che margine inferiore non esca dallo schermo
                If Posizione.Y + .Height > Screen.PrimaryScreen.WorkingArea.Height Then
                    Posizione.Y = (Screen.PrimaryScreen.WorkingArea.Height - .Height) - 10
                End If

                'assegno posizione iniziale del form
                .Location = Posizione

                .ShowDialog()
            End With

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
        End Try
    End Sub

    Private Function CaricaElencoDati() As Boolean

        'recupero datatable origine del campo
        Dim dt As DataTable

        If mColonna.DataGridView.DataSource.GetType.Name = "DataView" Then
            dt = mColonna.DataGridView.DataSource.Table
        ElseIf mColonna.DataGridView.DataSource.GetType.Name = "DataTable" Then
            dt = mColonna.DataGridView.DataSource
        ElseIf mColonna.DataGridView.DataSource.GetType.Name = "BindingSource" Then
            dt = mColonna.DataGridView.DataSource.DataSource
        Else
            Return False
        End If

        'assegno il campo e i dati del filtro
        Me.Titolo = mColonna.HeaderText
        Me.Campo = mColonna.Name
        Me.TipoCampo = dt.Columns(Campo).DataType

        'Rec.AddLog("carico elementi: " + Campo)

        'riempio la classe che contiene gli item filtro della colonna
        ElementiColonna.Clear()

        For Each dr As DataRow In dt.Rows
            ElementiColonna.Add(New ItemColonna(dr(Campo), TipoCampo, True))
        Next
        'Rec.AddLog("fine carico elementi: " + Campo)

        'ordino
        ElementiColonna.Sort()
        'Rec.AddLog("fine sort: " + Campo)

        If ElementiColonna.EsistonoVuoti = True Then
            ElementiColonna.Insert(0, ItemColonna.ItemVuoti(True))
        End If

        Dim Precedente As FiltroColonna = FiltroPrecedente(Campo)

        If (Precedente.Items IsNot Nothing) AndAlso Precedente.Items.Count > 0 Then

            'aggiungo seleziona tutti de-selezionato
            ElementiColonna.Insert(0, ItemColonna.ItemTutti(False))

            If Precedente.Elementi = FiltroColonna.ElementiLista.SELEZIONATI Then
                'se il filtro precedente è fatto con i valori selezionati
                ElementiColonna.SelezionaElementi(Precedente.Items)
            Else
                'se il filtro precedente è fatto con i valori de-selezionati
                ElementiColonna.DeSelezionaElementi(Precedente.Items)
            End If
        Else
            'aggiungo seleziona tutti selezionato
            ElementiColonna.Insert(0, ItemColonna.ItemTutti(True))
        End If

        'controllo se esistono vuoti
        mEsistonoVuoti = ElementiColonna.EsistonoVuoti

        Return True
    End Function

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonAnnulla.Click
        Me.Close()
    End Sub

    Private Sub ButtonCancellaTuttiFiltri_Click(sender As Object, e As EventArgs) Handles ButtonCancellaTuttiFiltri.Click
        CancellaFiltri()
        Me.Close()
    End Sub

    Private Sub TextBoxCerca_TextChanged(sender As Object, e As EventArgs)
        'riavvio il timer
        TimerCerca.Enabled = False
        TimerCerca.Enabled = True
    End Sub

    Private Sub TimerCerca_Tick(sender As Object, e As EventArgs) Handles TimerCerca.Tick

        'fermo il timer per la ricerca
        TimerCerca.Enabled = False

        If TextBoxCerca.Text.Trim.Length = 0 Then
            CaricaListaFiltro()
        Else
            CaricaListaFiltro(TextBoxCerca.Text)
        End If
    End Sub

    Private Sub ButtonMostraTutto_Click(sender As Object, e As EventArgs) Handles ButtonMostraTutto.Click

        If CheckedListBoxValori.Items.Count < ElementiColonna.Count Then
            CaricaListaFiltro(True)
        End If
    End Sub

    Private Sub ButtonDettaglio_Click(sender As Object, e As EventArgs) Handles ButtonDettaglio.Click
        DettaglioFiltro()
    End Sub

    Private Sub DettaglioFiltro()

        Try
            Using f As New FormDettagioFiltro

                With f
                    .FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
                    .Size = New Size(Screen.PrimaryScreen.WorkingArea.Width / 2,
                                     Screen.PrimaryScreen.WorkingArea.Height - 50)
                    .StartPosition = FormStartPosition.CenterScreen
                    .BackColor = Color.OrangeRed

                    .AppName = mAppName
                    .FilterFolder = mFilterFolder
                    .FiltroCorrente = FiltriColonna

                    .ShowDialog()

                    'se è stato caricato un filtro
                    If .FiltroCaricato IsNot Nothing Then

                        'cancello il filtro precedente e resetto il grassetto dalle colonne
                        ResetMarcaturaColonneFiltrate()
                        FiltriColonna.Clear()

                        For Each Filtro As FiltroColonna In .FiltroCaricato
                            Filtro.Query = New CreazioneQuery(Filtro).Query
                            FiltriColonna.Add(Filtro)
                        Next

                        mQuery = CreazioneQuery.CreaQueryCompleta(FiltriColonna)
                        ApplicaFiltro()

                        ButtonOk.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If
                End With
            End Using

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
        End Try

    End Sub

#Region "Layout"
    Public Function EsisteLayoutGriglia() As Boolean
        Return (LayoutColonne.Count > 0)
    End Function

    Public Sub ApplicaLayoutGriglia(ByRef dgv As DataGridView)

        'inizializza la struttura layout delle colonne
        If LayoutColonne.Count > 0 Then

            For Each l As LayoutColonna In LayoutColonne

                With dgv.Columns(l.Campo)

                    .HeaderText = l.Titolo
                    .Visible = l.Visibile
                    .Width = l.Larghezza
                    If l.ColoreTesto < 0 Then
                        .DefaultCellStyle.ForeColor = Color.FromArgb(l.ColoreTesto)
                    End If
                    If l.ColoreSfondo < 0 Then
                        .DefaultCellStyle.BackColor = Color.FromArgb(l.ColoreSfondo)
                    End If
                End With
            Next
        End If
    End Sub

    Private Sub TabPageLayout_Enter(sender As Object, e As EventArgs) Handles TabPageLayout.Enter

        RemoveHandler CheckedListBoxColonne.ItemCheck, AddressOf CheckedListBoxColonne_ItemCheck

        'inizializza la struttura layout delle colonne
        LeggiLayoutDaGriglia(mColonna.DataGridView)

        Dim ColonneSelezionateTutte As Boolean = True

        For Each l As LayoutColonna In LayoutColonne
            If l.Visibile = False Then
                ColonneSelezionateTutte = False
                Exit For
            End If
        Next

        CheckedListBoxColonne.Items.Clear()
        CheckedListBoxColonne.Items.Add(New LayoutColonna(LayoutColonna.TagTutti,
                                                          "(Seleziona tutto)",
                                                          False, ColonneSelezionateTutte, Nothing, Nothing, 0),
                                                ColonneSelezionateTutte)

        For Each l As LayoutColonna In LayoutColonne

            If l.Nascosta = False Then
                CheckedListBoxColonne.Items.Add(l, l.Visibile)
            End If
        Next

        CheckedListBoxColonne.DisplayMember = "Titolo"

        AddHandler CheckedListBoxColonne.ItemCheck, AddressOf CheckedListBoxColonne_ItemCheck

    End Sub

    Private Sub CheckedListBoxColonne_ItemCheck(sender As Object, e As ItemCheckEventArgs)

        RemoveHandler CheckedListBoxColonne.ItemCheck, AddressOf CheckedListBoxColonne_ItemCheck

        CheckedListBoxColonne.Items(e.Index).Visibile = (e.NewValue = CheckState.Checked)

        If CheckedListBoxColonne.Items(e.Index).Campo = LayoutColonna.TagTutti Then
            'modificato seleziona/deseleziona tutti
            For k As Integer = 0 To CheckedListBoxColonne.Items.Count - 1
                CheckedListBoxColonne.SetItemChecked(k, e.NewValue)
                CheckedListBoxColonne.Items(k).Visibile = e.NewValue
            Next

            For Each l As LayoutColonna In LayoutColonne
                l.Visibile = e.NewValue
            Next
        Else
            If e.NewValue = CheckState.Checked AndAlso
               (CheckedListBoxColonne.CheckedItems.Count = CheckedListBoxColonne.Items.Count - 2) Then

                CheckedListBoxColonne.SetItemChecked(0, True)
            Else
                'modificato un check >> deselezionare TUTTI
                CheckedListBoxColonne.SetItemChecked(0, False)
            End If
        End If

        AddHandler CheckedListBoxColonne.ItemCheck, AddressOf CheckedListBoxColonne_ItemCheck

    End Sub

    Private Sub ButtonColori_Click(sender As Object, e As EventArgs) Handles ButtonColori.Click

        Dim cd As New ColorDialog

        If cd.ShowDialog(Me) = DialogResult.OK Then
            mColonna.DefaultCellStyle.BackColor = cd.Color
        Else
            mColonna.DefaultCellStyle.BackColor = Nothing
        End If

        'cerco il layout della colonna corrente e memorizzo il colore
        For Each l As LayoutColonna In LayoutColonne
            If l.Campo = mColonna.Name Then
                l.ColoreSfondo = mColonna.DefaultCellStyle.BackColor.ToArgb
            End If
        Next

        ButtonOk.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Public Sub SalvaLayoutGriglia(ByVal NomeFile As String)

        Try
            Dim xmlDoc As New XmlDocument

            Dim xmlGridNode As XmlElement = xmlDoc.CreateElement("grid")
            xmlDoc.AppendChild(xmlGridNode)

            For Each l As LayoutColonna In LayoutColonne
                xmlGridNode.AppendChild(CreaElemento(xmlGridNode, l))
            Next

            xmlDoc.Save(NomeFile)

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
        End Try

    End Sub

    Private Function CreaElemento(ByVal ParentNode As XmlNode,
                                  ByRef Colonna As LayoutColonna) As XmlElement

        Dim xmlEl As XmlElement = ParentNode.OwnerDocument.CreateElement("column")

        With xmlEl
            .SetAttribute("name", Colonna.Campo)
            .SetAttribute("text", Colonna.Titolo)
            .SetAttribute("hide", Colonna.Nascosta)
            .SetAttribute("visible", Colonna.Visibile)
            .SetAttribute("width", Colonna.Larghezza)
            .SetAttribute("argbforecolor", Colonna.ColoreTesto)
            .SetAttribute("argbbackcolor", Colonna.ColoreSfondo)
        End With

        Return xmlEl
    End Function

    Public Sub LeggiLayoutDaGriglia(ByRef dgv As DataGridView)

        'inizializza la struttura layout delle colonne
        If LayoutColonne.Count = 0 Then

            For Each c As DataGridViewColumn In dgv.Columns

                LayoutColonne.Add(New LayoutColonna(c.Name,
                                                    c.HeaderText,
                                                    Not c.Visible,
                                                    c.Visible,
                                                    c.DefaultCellStyle.BackColor.ToArgb,
                                                    c.DefaultCellStyle.ForeColor.ToArgb,
                                                    c.Width))
            Next
        End If

    End Sub

    Public Sub LeggiLayoutDaXml(ByVal XmlFile As String)

        Try
            If File.Exists(XmlFile) = False Then
                Exit Sub
            End If

            Dim xDoc As New XmlDocument
            xDoc.Load(XmlFile)

            LayoutColonne.Clear()

            Dim xnl As XmlNodeList = xDoc.SelectNodes("//column")

            For Each xn As XmlNode In xnl

                Dim l As New LayoutColonna

                l.Campo = xn.Attributes("name").InnerText
                l.Titolo = xn.Attributes("text").InnerText
                l.Nascosta = xn.Attributes("hide").InnerText
                l.Visibile = xn.Attributes("visible").InnerText
                l.Larghezza = xn.Attributes("width").InnerText

                If xn.Attributes("argbforecolor").InnerText <> "0" Then
                    l.ColoreTesto = xn.Attributes("argbforecolor").InnerText
                End If
                If xn.Attributes("argbbackcolor").InnerText <> "0" Then
                    l.ColoreSfondo = xn.Attributes("argbbackcolor").InnerText
                End If

                LayoutColonne.Add(l)
            Next

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
        End Try

    End Sub

    Public Sub ModificaLarghezzaColonna(ByRef Colonna As DataGridViewColumn)

        For Each l As LayoutColonna In LayoutColonne

            If l.Campo = Colonna.Name Then
                l.Larghezza = Colonna.Width
            End If
        Next
    End Sub

    Private Sub ButtonResetLayout_Click(sender As Object, e As EventArgs) Handles ButtonResetLayout.Click

        'resetto il layout
        For Each l As LayoutColonna In LayoutColonne
            l.ColoreSfondo = 0
        Next
        'resetto la griglia
        For Each c As DataGridViewColumn In mColonna.DataGridView.Columns
            c.DefaultCellStyle.BackColor = Nothing
        Next

        mColonna.DataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

        Me.Close()
    End Sub
#End Region

End Class

Friend Class ItemsColonna

    Public MaxNumeroItem As Integer

    Public Structure Tag
        Const Tutti As String = "TAG_TUTTI"
        Const TuttiDesk As String = "(Seleziona tutto)"
        Const Vuoti As String = "TAG_VUOTI"
        Const VuotiDesk As String = "(Vuoti)"
        Const Aggiungi As String = "TAG_AGGIUNGI"
        Const AggiungiDesk As String = "(Aggiungi selezionati al filtro)"
    End Structure

    Private mElementi As New List(Of ItemColonna)

    Sub New(ByVal MaxNumeroItemLista As Integer)
        MaxNumeroItem = MaxNumeroItemLista
    End Sub

    Private mTipoCampo As Type
    Public Property TipoCampo() As Type
        Get
            Return mTipoCampo
        End Get
        Set(ByVal value As Type)
            mTipoCampo = value
        End Set
    End Property

    Private mEsistonoVuoti As Boolean
    Public ReadOnly Property EsistonoVuoti() As Boolean
        Get
            Return mEsistonoVuoti
        End Get
    End Property

    Public ReadOnly Property Count() As Integer
        Get
            Return mElementi.Count
        End Get
    End Property

    Public Sub Clear()
        mElementi.Clear()
        mEsistonoVuoti = False
    End Sub

    Public Sub Add(ByVal Elemento As ItemColonna)

        If Elemento.Testo = "" Then
            mEsistonoVuoti = True
        Else
            If EsisteElemento(Elemento.Testo) = False Then

                If Elemento.Valore.ToString = "" Then
                    ItemColonna.ItemVuoti(True)
                Else
                    mElementi.Add(Elemento)
                End If
            End If
        End If
    End Sub

    Public Sub Insert(ByVal Index As Integer,
                      ByVal Elemento As ItemColonna)

        mElementi.Insert(Index, Elemento)
    End Sub

    Public Sub Sort()
        mElementi.Sort(AddressOf ItemColonnaComparer)
    End Sub

    Public Function Elementi() As List(Of ItemColonna)
        Return mElementi
    End Function

    Public Function EsisteElemento(ByVal Testo As String) As Boolean

        For Each i As ItemColonna In mElementi

            If i.Testo = Testo Then
                Return True
            End If
        Next

        Return False
    End Function

    Public Function TrovaElemento(ByVal Cerca As ItemColonna) As ItemColonna
        Return mElementi.Find(Function(i As ItemColonna) i.Testo = Cerca.Testo)
    End Function

    Public Function Elemento(ByVal Index As Integer) As ItemColonna
        Return mElementi.Item(Index)
    End Function

    Public Sub SelezionaTutti()
        mElementi.ForEach(AddressOf SelezionaItem)
    End Sub

    Public Sub DeSelezionaTutti()
        mElementi.ForEach(AddressOf DeSelezionaItem)
    End Sub

    Public Sub SelezionaElementi(ByVal Items As List(Of ItemColonna))

        'poiché gli elementi sono di default tutti selezionati se bisogna selezionarne solo alcuni
        'deselezionare prima tutti e poi selezionare gli item interessati
        Me.DeSelezionaTutti()

        For Each i As ItemColonna In Items
            TrovaElemento(i).Selezionato = True
        Next
    End Sub

    Public Sub DeSelezionaElementi(ByVal Items As List(Of ItemColonna))

        For Each i As ItemColonna In Items
            TrovaElemento(i).Selezionato = False
        Next
    End Sub

    Public Sub CambiaSelezioneElemento(ByVal Index As Integer,
                                       ByVal Selezionato As Boolean)

        mElementi.Item(Index).Selezionato = Selezionato
    End Sub

    Public Sub ContaElementi(ByRef Selezionati As Integer,
                             ByRef Deselezionati As Integer,
                             ByVal SelezionatoTutti As Boolean)

        Selezionati = Me.ItemSelezionati.Count
        Deselezionati = mElementi.Count - Selezionati
        SelezionatoTutti = (Selezionati = mElementi.Count)
    End Sub

    Public Function ItemSelezionati() As List(Of ItemColonna)
        Return mElementi.FindAll(AddressOf TrovaSelezionati)
    End Function

    Public Function ItemDeselezionati() As List(Of ItemColonna)
        Return mElementi.FindAll(AddressOf TrovaDeselezionati)
    End Function

#Region "Delegati"
    Private Sub SelezionaItem(ByVal Item As ItemColonna)
        Item.Selezionato = True
    End Sub

    Private Sub DeSelezionaItem(ByVal Item As ItemColonna)
        Item.Selezionato = False
    End Sub

    Private Function TrovaSelezionati(ByVal Item As ItemColonna) As Boolean
        Return Item.Selezionato = True
    End Function

    Private Function TrovaDeselezionati(ByVal Item As ItemColonna) As Boolean
        Return Item.Selezionato = False
    End Function

    Private Function ItemColonnaComparer(ByVal x As ItemColonna, ByVal y As ItemColonna) As Boolean
        Return (x.Valore < y.Valore)
    End Function
#End Region
End Class

Friend Class ItemColonna

    Sub New(ByVal Valore As String,
            ByVal Testo As String,
            ByVal Selezionato As Boolean)

        mValore = Valore
        mTesto = Testo
        mSelezionato = Selezionato
    End Sub

    Sub New(ByVal Valore As Object,
            ByVal TipoCampo As Type,
            ByVal Selezionato As Boolean)

        If TipoCampo.Name = "DateTime" Then

            If Valore Is DBNull.Value Then
                mValore = ItemsColonna.Tag.Vuoti
                mTesto = ""
            Else
                mValore = DateValue(Valore)
                mTesto = mValore.ToShortDateString
            End If
        Else
            If Valore Is DBNull.Value Then
                mValore = ItemsColonna.Tag.Vuoti
                mTesto = ""
            Else
                mValore = Valore
                mTesto = mValore.ToString
            End If
        End If

        mSelezionato = Selezionato
    End Sub

    Private mValore As Object
    Public Property Valore() As Object
        Get
            Return mValore
        End Get
        Set(ByVal value As Object)
            mValore = value
        End Set
    End Property

    Private mTesto As String
    Public Property Testo() As String
        Get
            Return mTesto
        End Get
        Set(ByVal value As String)
            mTesto = value
        End Set
    End Property

    Private mSelezionato As Boolean
    Public Property Selezionato() As Boolean
        Get
            Return mSelezionato
        End Get
        Set(ByVal value As Boolean)
            mSelezionato = value
        End Set
    End Property

    Public Shared Function ItemTutti(ByVal Selezionato As Boolean) As ItemColonna
        Return New ItemColonna(ItemsColonna.Tag.Tutti, ItemsColonna.Tag.TuttiDesk, Selezionato)
    End Function

    Public Shared Function ItemVuoti(ByVal Selezionato As Boolean) As ItemColonna
        Return New ItemColonna(ItemsColonna.Tag.Vuoti, ItemsColonna.Tag.VuotiDesk, Selezionato)
    End Function

    Public Shared Function ItemAggiungi(ByVal Selezionato As Boolean) As ItemColonna
        Return New ItemColonna(ItemsColonna.Tag.Aggiungi, ItemsColonna.Tag.AggiungiDesk, Selezionato)
    End Function

    Public Shared Function IsItemTutti(ByRef Item As ItemColonna) As Boolean
        If Item.Valore.GetType.Name = "String" Then
            Return Item.Valore = ItemsColonna.Tag.Tutti
        Else
            Return False
        End If
    End Function

    Public Shared Function IsItemVuoti(ByRef Item As ItemColonna) As Boolean
        If Item.Valore.GetType.Name = "String" Then
            Return Item.Valore = ItemsColonna.Tag.Vuoti
        Else
            Return False
        End If
    End Function
End Class

Friend Class FiltroColonna

    Public Enum TipologiaFiltri
        NESSUNO = 0
        CHECK = 1
        OPERATORE = 2
    End Enum

    Public Enum ElementiLista
        SELEZIONATI = 0
        NON_SELEZIONATI = 1
    End Enum

    Sub New()
        mItems = New List(Of ItemColonna)
        mChiave = ""
    End Sub

    Private mCampo As String
    Public Property Campo() As String
        Get
            Return mCampo
        End Get
        Set(ByVal value As String)
            mCampo = value
        End Set
    End Property

    Private mDeskCampo As String
    Public Property DeskCampo() As String
        Get
            Return mDeskCampo
        End Get
        Set(ByVal value As String)
            mDeskCampo = value
        End Set
    End Property

    Private mTipoCampo As Type
    Public Property TipoCampo() As Type
        Get
            Return mTipoCampo
        End Get
        Set(ByVal value As Type)
            mTipoCampo = value
        End Set
    End Property

    Private mOperatore As Operatore
    Public Property Operatore() As Operatore
        Get
            Return mOperatore
        End Get
        Set(ByVal value As Operatore)
            mOperatore = value
        End Set
    End Property

    Private mTipoFiltro As TipologiaFiltri
    Public Property TipoFiltro() As TipologiaFiltri
        Get
            Return mTipoFiltro
        End Get
        Set(ByVal value As TipologiaFiltri)
            mTipoFiltro = value
        End Set
    End Property

    Private mItems As List(Of ItemColonna)
    Public Property Items() As List(Of ItemColonna)
        Get
            Return mItems
        End Get
        Set(ByVal value As List(Of ItemColonna))
            mItems = value
        End Set
    End Property

    Private mChiave As String
    Public Property Chiave() As String
        Get
            Return mChiave
        End Get
        Set(ByVal value As String)
            mChiave = value
        End Set
    End Property

    Private mQuery As String
    ''' <summary>
    ''' query sotto forma di testo da applicare al dataview
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Query() As String
        Get
            Return mQuery
        End Get
        Set(ByVal value As String)
            mQuery = value
        End Set
    End Property

    Private mElementi As ElementiLista
    Public Property Elementi() As ElementiLista
        Get
            Return mElementi
        End Get
        Set(ByVal value As ElementiLista)
            mElementi = value
        End Set
    End Property

    Public Sub Add(ByRef Item As ItemColonna)
        mItems.Add(Item)
    End Sub

    Public Sub AddRange(ByRef Items As List(Of ItemColonna))

        For Each i As ItemColonna In Items
            mItems.Add(i)
        Next
    End Sub
End Class

Friend Class Operatore

    Sub New()
        mContesto = ""
        mCodice = Operatori.CodiceOperatore.NESSUNO
        mDescrizione = ""
        mSimbolo = ""
    End Sub

    Sub New(ByVal Contesto As String,
            ByVal Codice As Operatori.CodiceOperatore,
            ByVal Descrizione As String,
            ByVal Simbolo As String)

        mContesto = Contesto
        mCodice = Codice
        mDescrizione = Descrizione
        mSimbolo = Simbolo
    End Sub

    Private mContesto As String
    Public Property Contesto() As String
        Get
            Return mContesto
        End Get
        Set(ByVal value As String)
            mContesto = value
        End Set
    End Property

    Private mCodice As Integer
    Public Property Codice() As Integer
        Get
            Return mCodice
        End Get
        Set(ByVal value As Integer)
            mCodice = value
        End Set
    End Property

    Private mDescrizione As String
    Public Property Descrizione() As String
        Get
            Return mDescrizione
        End Get
        Set(ByVal value As String)
            mDescrizione = value
        End Set
    End Property

    Private mSimbolo As String
    Public Property Simbolo() As String
        Get
            Return mSimbolo
        End Get
        Set(ByVal value As String)
            mSimbolo = value
        End Set
    End Property
End Class

Friend Class Operatori

    Public Enum CodiceOperatore
        UGUALE = 0
        DIVERSO = 1
        MAGGIORE = 2
        MINORE = 3
        INIZIA = 4
        CONTIENE = 5
        NON_CONTIENE = 6
        NESSUNO = 99
    End Enum

    Public Operatori As List(Of Operatore)

    Sub New(ByVal TipoCampo As Type)

        Operatori = New List(Of Operatore)

        With Operatori
            .Add(New Operatore("", CodiceOperatore.UGUALE, "Uguale", "="))
            .Add(New Operatore("", CodiceOperatore.DIVERSO, "Diverso", "<>"))
            .Add(New Operatore("", CodiceOperatore.MAGGIORE, "Maggiore", ">"))
            .Add(New Operatore("", CodiceOperatore.MINORE, "Minore", "<"))

            If TipoCampo.Name = "String" Then
                .Add(New Operatore("String", CodiceOperatore.INIZIA, "Inizia", "LIKE"))
                .Add(New Operatore("String", CodiceOperatore.CONTIENE, "Contiene", "LIKE"))
                .Add(New Operatore("String", CodiceOperatore.NON_CONTIENE, "Non contiene", "LIKE"))
            End If

            'nessun operatore
            .Add(New Operatore("", CodiceOperatore.NESSUNO, "NN", "NN"))
        End With
    End Sub

    Public ReadOnly Property Operatore(ByVal Codice As Integer) As Operatore
        Get
            For Each o As Operatore In Operatori
                If o.Codice = Codice Then
                    Return o
                    Exit Property
                End If
            Next

            'se non trova il codice nessun operatore
            Return New Operatore("", CodiceOperatore.NESSUNO, "NN", "NN")
        End Get
    End Property

    Public ReadOnly Property ListaOperatori() As List(Of Operatore)
        Get
            Return Operatori
        End Get
    End Property

    Public ReadOnly Property ListaCodiciOperatori() As List(Of String)
        Get
            Dim Lista As New List(Of String)

            For Each o As Operatore In Operatori
                Lista.Add(o.Codice)
            Next

            Return Lista
        End Get
    End Property

End Class

Friend Class CreazioneQuery

    Sub New(ByRef Filtro As FiltroColonna)

        If Filtro.Chiave.Trim.Length = 0 Then
            'filtro CHECK
            mQuery = CreaQueryCheck(Filtro)
        Else
            'filtro OPERATORE
            If TipoValoreOk(Filtro.TipoCampo, Filtro.Chiave) = True Then
                mQuery = CreaQueryOperatore(Filtro)
            End If
        End If
    End Sub

    Private mQuery As String
    Public ReadOnly Property Query() As String
        Get
            Return mQuery.Trim
        End Get
    End Property

    Private Function CreaQueryCheck(ByVal Filtro As FiltroColonna) As String

        Select Case Filtro.TipoCampo.Name

            Case "String"
                Return CreaFiltroStringhe(Filtro)

            Case "DateTime"
                Return CreaFiltroDate(Filtro)

            Case Else
                Return CreaFiltroNumeri(Filtro)
        End Select
    End Function

    ''' <summary>
    ''' ricalcola la query completa del filtro da applicare alla dv /dt
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreaQueryCompleta(ByRef Filtri As List(Of FiltroColonna)) As String

        Dim Query As String = ""

        'unisco i filtri di tutti i campi/colonne
        For Each f As FiltroColonna In Filtri
            Query += String.Format("({0}) AND ", f.Query)
        Next

        Return EliminaOperatoreFinale(Query)

    End Function

    Public Function TipoValoreOk(ByVal TipoCampo As Type, ByVal Valore As String) As Boolean

        Select Case TipoCampo.Name

            Case "String"
                Return True

            Case "DateTime"
                Return IsDate(Valore)

            Case Else
                Return IsNumeric(Valore)
        End Select
    End Function

    Private Function CreaQueryOperatore(ByRef Filtro As FiltroColonna) As String

        Select Case Filtro.Operatore.Codice

            Case Operatori.CodiceOperatore.CONTIENE
                Return String.Format("[{0}] LIKE '%{1}%'", Filtro.Campo, Filtro.Chiave)

            Case Operatori.CodiceOperatore.NON_CONTIENE
                Return String.Format("[{0}] NOT LIKE '%{1}%'", Filtro.Campo, Filtro.Chiave)

            Case Operatori.CodiceOperatore.INIZIA
                Return String.Format("[{0}] LIKE '{1}%'", Filtro.Campo, Filtro.Chiave)

            Case Operatori.CodiceOperatore.DIVERSO
                Select Case Filtro.TipoCampo.Name

                    Case "String"
                        Return String.Format("[{0}] <> '{1}'", Filtro.Campo, Filtro.Chiave)

                    Case "DateTime"
                        Return String.Format("[{0}] <> #{1}#", Filtro.Campo, Format(CDate(Filtro.Chiave), "MM/dd/yyyy"))

                    Case Else
                        Return String.Format("[{0}] <> {1}", Filtro.Campo, Filtro.Chiave)
                End Select

            Case Operatori.CodiceOperatore.MAGGIORE
                Select Case Filtro.TipoCampo.Name

                    Case "String"
                        Return String.Format("[{0}] > '{1}'", Filtro.Campo, Filtro.Chiave)

                    Case "DateTime"
                        Return String.Format("[{0}] > #{1}#", Filtro.Campo, Format(CDate(Filtro.Chiave), "MM/dd/yyyy"))

                    Case Else
                        Return String.Format("[{0}] > {1}", Filtro.Campo, Filtro.Chiave)
                End Select

            Case Operatori.CodiceOperatore.MINORE
                Select Case Filtro.TipoCampo.Name

                    Case "String"
                        Return String.Format("[{0}] < '{1}'", Filtro.Campo, Filtro.Chiave)

                    Case "DateTime"
                        Return String.Format("[{0}] < #{1}#", Filtro.Campo, Format(CDate(Filtro.Chiave), "MM/dd/yyyy"))

                    Case Else
                        Return String.Format("[{0}] < {1}", Filtro.Campo, Filtro.Chiave)
                End Select

            Case Operatori.CodiceOperatore.UGUALE
                Select Case Filtro.TipoCampo.Name

                    Case "String"
                        Return String.Format("[{0}] = '{1}'", Filtro.Campo, Filtro.Chiave)

                    Case "DateTime"
                        Return String.Format("[{0}] = #{1}#", Filtro.Campo, Format(CDate(Filtro.Chiave), "MM/dd/yyyy"))

                    Case Else
                        Return String.Format("[{0}] = {1}", Filtro.Campo, Filtro.Chiave)
                End Select

            Case Else
                MsgBox("Operatore ancora da implementare.", MsgBoxStyle.Information)
                Return ""
        End Select
    End Function

    Private Function CreaFiltroDate(ByRef f As FiltroColonna) As String

        Dim Query As String = ""

        For Each i As ItemColonna In f.Items

            If f.Elementi = FiltroColonna.ElementiLista.SELEZIONATI Then
                If IsDate(i.Valore) Then
                    Query += String.Format("([{0}] = #{1}#) OR ", f.Campo, Format(CDate(i.Valore), "MM/dd/yyyy"))
                Else
                    Query += String.Format("([{0}] IS NULL) OR ", f.Campo)
                End If
            Else
                If IsDate(i.Valore) Then
                    Query += String.Format("([{0}] <> #{1}#) AND ", f.Campo, Format(CDate(i.Valore), "MM/dd/yyyy"))
                Else
                    Query += String.Format("(NOT ([{0}] IS NULL)) AND ", f.Campo)
                End If
            End If
        Next

        Return EliminaOperatoreFinale(Query)

    End Function

    Private Function CreaFiltroNumeri(ByRef f As FiltroColonna) As String

        Dim Query As String = ""

        For Each i As ItemColonna In f.Items

            If f.Elementi = FiltroColonna.ElementiLista.SELEZIONATI Then
                If ItemColonna.IsItemVuoti(i) Then
                    Query += String.Format("([{0}] IS NULL) OR ", f.Campo)
                Else
                    Query += String.Format("([{0}] = {1}) OR ", f.Campo, i.Valore)
                End If
            Else
                If ItemColonna.IsItemVuoti(i) Then
                    Query += String.Format("(NOT ([{0}] IS NULL)) AND ", f.Campo)
                Else
                    Query += String.Format("([{0}] <> {1}) AND ", f.Campo, i.Valore)
                End If
            End If
        Next

        Return EliminaOperatoreFinale(Query)

    End Function

    Private Function CreaFiltroStringhe(ByRef f As FiltroColonna) As String

        Dim Query As String = ""

        For Each i As ItemColonna In f.Items

            If f.Elementi = FiltroColonna.ElementiLista.SELEZIONATI Then
                If ItemColonna.IsItemVuoti(i) Then
                    Query += String.Format("(Trim([{0}]) = '' OR ([{0}] IS NULL)) OR ", f.Campo)
                Else
                    Query += String.Format("([{0}] = '{1}') OR ", f.Campo, i.Valore.Replace("'", "''"))
                End If
            Else
                If ItemColonna.IsItemVuoti(i) Then
                    Query += String.Format("(Trim([{0}]) <> '' AND (NOT ([{0}] IS NULL))) AND ", f.Campo)
                Else
                    Query += String.Format("([{0}] <> '{1}') AND ", f.Campo, i.Valore.Replace("'", "''"))
                End If
            End If
        Next

        Return EliminaOperatoreFinale(Query)

    End Function

    Private Shared Function EliminaOperatoreFinale(ByVal Query As String) As String

        'tolgo l'ultimo operatore (OR/AND) alla stringa
        If Query.Length > 0 Then

            If Query.EndsWith("OR ", StringComparison.InvariantCultureIgnoreCase) Then
                Return Query.Substring(0, Query.Length - 3)
            Else
                Return Query.Substring(0, Query.Length - 4)
            End If
        Else
            Return Query
        End If
    End Function

End Class

Friend Class LayoutColonna

    Public Const TagTutti As String = "TAG_TUTTI"

    Sub New()
    End Sub

    Sub New(ByVal Campo As String,
            ByVal Titolo As String,
            ByVal Nascosta As Boolean,
            ByVal Visibile As Boolean,
            ByVal ColoreSfondo As Integer,
            ByVal ColoreTesto As Integer,
            ByVal Larghezza As Integer)

        mCampo = Campo
        mTitolo = Titolo
        mNascosta = Nascosta
        mVisibile = Visibile
        mColoreSfondo = ColoreSfondo
        mColoreTesto = ColoreTesto
        mLarghezza = Larghezza
    End Sub

    Private mCampo As String
    Public Property Campo() As String
        Get
            Return mCampo
        End Get
        Set(ByVal value As String)
            mCampo = value
        End Set
    End Property

    Private mTitolo As String
    Public Property Titolo() As String
        Get
            Return mTitolo
        End Get
        Set(ByVal value As String)
            mTitolo = value
        End Set
    End Property

    Private mNascosta As Boolean
    Public Property Nascosta() As Boolean
        Get
            Return mNascosta
        End Get
        Set(ByVal value As Boolean)
            mNascosta = value
        End Set
    End Property

    Private mVisibile As Boolean
    Public Property Visibile() As Boolean
        Get
            Return mVisibile
        End Get
        Set(ByVal value As Boolean)
            mVisibile = value
        End Set
    End Property

    Private mColoreSfondo As Integer
    Public Property ColoreSfondo() As Integer
        Get
            Return mColoreSfondo
        End Get
        Set(ByVal value As Integer)
            mColoreSfondo = value
        End Set
    End Property

    Private mColoreTesto As Integer
    Public Property ColoreTesto() As Integer
        Get
            Return mColoreTesto
        End Get
        Set(ByVal value As Integer)
            mColoreTesto = value
        End Set
    End Property

    Private mLarghezza As Integer
    Public Property Larghezza() As Integer
        Get
            Return mLarghezza
        End Get
        Set(ByVal value As Integer)
            mLarghezza = value
        End Set
    End Property

End Class