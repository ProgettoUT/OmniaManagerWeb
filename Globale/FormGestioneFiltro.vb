Imports System.Windows.Forms
Imports System.Drawing
Imports System.Xml
Imports System.IO

<Serializable>
Public Class FormGestioneFiltro

    Public Event SalvatoLayout(NomeLayout As String)
    Public Event EliminatoLayout(NomeLayout As String)
    Public Event ModificatoFiltro()

    Friend FiltriColonna As List(Of FiltroColonna)
    Public LayoutColonne As List(Of LayoutColonna)
    Public GestoreLayout As New Layout
    Public FontGriglia As Font

    Private Const MaxNumeroOperatori As Integer = 200

    Private mColoreCombo As Color = Color.Khaki
    Private mEsistonoVuoti As Boolean
    Private mColonna As DataGridViewColumn
    Private ElementiColonna As ItemsColonna
    Private WithEvents Dettaglio As FormDettagioFiltro
    Private WithEvents TimerCerca As New Timer
    Private tt As New ToolTip
    'solo per il debug
    'ReadOnly Trace As New Performance("trace.log")

#Region "Proprietà"
    Private mCampo As String
    Public Property Campo() As String
        Get
            Return mCampo
        End Get
        Set(value As String)
            mCampo = value
        End Set
    End Property

    Public Property ColoreSfondo() As Color
        Get
            Return Me.Panel1.BackColor
        End Get
        Set(value As Color)
            Me.Panel1.BackColor = value
        End Set
    End Property

    Private mColoreColonnaFiltrata As Color
    Public Property ColoreColonnaFiltrata() As Color
        Get
            Return mColoreColonnaFiltrata
        End Get
        Set(value As Color)
            mColoreColonnaFiltrata = value
        End Set
    End Property

    Private mTipoCampo As Type
    Public Property TipoCampo() As Type
        Get
            Return mTipoCampo
        End Get
        Set(value As Type)
            mTipoCampo = value
        End Set
    End Property

    Private mQuery As String
    Public Property Query() As String
        Get
            Return mQuery
        End Get
        Set(value As String)
            mQuery = value
        End Set
    End Property

    Public Property Titolo() As String
        Get
            Return LabelCampo.Text
        End Get
        Set(value As String)
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
        Set(value As String)
            mAppName = value
        End Set
    End Property

    Private mFilterFolder As String
    Public Property FilterFolder() As String
        Get
            Return mFilterFolder
        End Get
        Set(value As String)
            mFilterFolder = value
        End Set
    End Property

    Private mValoreSelezionato As Object
    Public Property ValoreSelezionato() As Object
        Get
            Return mValoreSelezionato
        End Get
        Set(value As Object)
            If IsDBNull(value) Then
                mValoreSelezionato = ""
                ButtonSelezione.Text = "..."
                ButtonSelezione.Enabled = False
                ButtonDiverso.Enabled = False
            Else
                Select Case value.GetType.Name
                    Case "DateTime" : mValoreSelezionato = Format(value, "dd/MM/yyyy")
                    Case Else : mValoreSelezionato = value.ToString
                End Select
                ButtonSelezione.Text = Microsoft.VisualBasic.Left("Valore = " & mValoreSelezionato, 24)
                ButtonSelezione.Enabled = True
                ButtonDiverso.Enabled = True
            End If
        End Set
    End Property

    Public ReadOnly Property Contesto() As String
        Get
            Try
                If mColonna.DataGridView IsNot Nothing Then
                    Return mColonna.DataGridView.Name
                Else
                    Return ""
                End If
            Catch ex As Exception
                Return ""
            End Try
        End Get
    End Property

    Private mFilterVisible As Boolean
    Private mLayoutVisible As Boolean
    Public Sub TabVisibili(TabFiltro As Boolean, TabLayout As Boolean)
        mFilterVisible = TabFiltro
        mLayoutVisible = TabLayout

        TabControlMain.TabPages.Clear()

        If mFilterVisible = True Then
            TabControlMain.TabPages.Add(TabPageFiltri)
        End If
        If mLayoutVisible = True Then
            TabControlMain.TabPages.Add(TabPageLayout)
        End If
    End Sub
#End Region

#Region "gestione form"
    Sub New(Optional MaxNumeroItemLista As Integer = 1000)
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Utx.NetFunc.DoppioBuffer(Me)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.Text = ""
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.ControlBox = False
        Me.MinimumSize = New Size(300, 380)
        Me.Size = Me.MinimumSize
        Me.AcceptButton = ButtonOk

        mFilterVisible = True
        mLayoutVisible = True
        mColoreColonnaFiltrata = Color.Red

        ElementiColonna = New ItemsColonna(MaxNumeroItemLista)

        ImpostaControlli()

        FiltriColonna = New List(Of FiltroColonna)
        LayoutColonne = New List(Of LayoutColonna)

        CheckedListBoxValori.CheckOnClick = True
    End Sub

    Private Sub FormFiltro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If mFilterVisible = True Then
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
            TextBoxValore2.Text = ""

            TextBoxCerca.Text = ""
            AddHandler TextBoxCerca.TextChanged, AddressOf TextBoxCerca_TextChanged

            'carico la lista da visualizzare nel checkedlistbox
            CaricaListaFiltro()
        End If
    End Sub

    Private Sub FormGestioneFiltro_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Cursor = Cursors.Default
        Cursor.Position = New Point(Me.Left + 10, Me.Top + 10)
        Me.Refresh()

        If mFilterVisible = True Then TextBoxCerca.Focus()
        'Trace.Info("exit show: " + Campo)
    End Sub

    Private Sub FormGestioneFiltro_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        RemoveHandler CheckedListBoxValori.ItemCheck, AddressOf CheckedListBoxValori_ItemCheck
        RemoveHandler CheckedListBoxColonne.ItemCheck, AddressOf CheckedListBoxColonne_ItemCheck
        RemoveHandler TextBoxCerca.TextChanged, AddressOf TextBoxCerca_TextChanged

        TimerCerca.Enabled = False
        TimerCerca.Dispose()
        CheckedListBoxValori.Items.Clear()

        If mFilterVisible = True Then TabControlMain.SelectedTab = TabPageFiltri
    End Sub

    Private Sub ImpostaControlli()
        tt.IsBalloon = False

        Panel1.BackColor = Color.Red

        'scheda filtri
        With ButtonOrdinaCrescente
            .Text = "Ordina dalla A alla Z"
            .TextAlign = ContentAlignment.MiddleCenter
            .Image = Risorse.Immagini.Bitmap("az")
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonOrdinaDescrescente
            .Text = "Ordina dalla Z alla A"
            .TextAlign = ContentAlignment.MiddleCenter
            .Image = Risorse.Immagini.Bitmap("za")
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonCancellaFiltri
            .Text = "Cancella filtri per il campo"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = Risorse.Immagini.Bitmap("cancel16")
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonCancellaTuttiFiltri
            .Text = "Cancella tutti"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = Risorse.Immagini.Bitmap("cancel16")
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonMostraTutto
            .Text = ""
            .Image = Risorse.Immagini.Image("list")
            .ImageAlign = ContentAlignment.MiddleCenter
        End With
        With ButtonSelezione
            .TextAlign = ContentAlignment.MiddleCenter
            .Image = Risorse.Immagini.Bitmap("ok16")
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonDettaglio
            .Text = ""
            .Image = Risorse.Immagini.Bitmap("salva16")
            .ImageAlign = ContentAlignment.MiddleCenter
        End With
        tt.SetToolTip(ButtonMostraTutto, "Visualizza elenco completo")
        tt.SetToolTip(ButtonCancellaTuttiFiltri, "Cancella tutti i filtri")
        tt.SetToolTip(ButtonDettaglio, "Dettaglio, salva o carica")

        TextBoxCerca.TextAlign = HorizontalAlignment.Center

        'scheda layout
        With ButtonColoreSfondo
            .Text = "Colore sfondo"
            .TextAlign = ContentAlignment.MiddleCenter
            .Image = Risorse.Immagini.Bitmap("color")
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonColoreTesto
            .Text = "Colore testo"
            .TextAlign = ContentAlignment.MiddleCenter
            .Image = Risorse.Immagini.Bitmap("color")
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonResetLayout
            .Text = "Elimina personalizzazioni"
            .TextAlign = ContentAlignment.MiddleCenter
            .Image = Risorse.Immagini.Bitmap("cancel16")
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonSu
            .Margin = New Padding(0)
            .Font = New Font("Wingdings 3", 8)
            .Text = "p"
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
        End With
        tt.SetToolTip(ButtonSu, "Sposta su")
        With ButtonGiu
            .Margin = New Padding(0)
            .Font = New Font("Wingdings 3", 8)
            .Text = "q"
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
        End With
        tt.SetToolTip(ButtonGiu, "Sposta giù")
        With ButtonSpostaColonnaIn
            .Margin = New Padding(0)
            .Font = New Font("Wingdings 3", 8)
            .ForeColor = Color.Red
            .Text = "u"
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
        End With
        tt.SetToolTip(ButtonSpostaColonnaIn, "Sposta alla colonna...")
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

    Private Function EsisteFiltroCampo(Campo As String) As FiltroColonna.TipologiaFiltri
        For Each f As FiltroColonna In FiltriColonna

            If f.Campo = Campo Then
                Return f.TipoFiltro
            End If
        Next

        Return FiltroColonna.TipologiaFiltri.NESSUNO
    End Function

    Private Function FiltroPrecedente(Campo As String) As FiltroColonna
        For Each f As FiltroColonna In FiltriColonna

            If (f.TipoFiltro = FiltroColonna.TipologiaFiltri.CHECK) AndAlso (f.Campo = Campo) Then
                Return f
            End If
        Next

        Return New FiltroColonna
    End Function

    Private Sub EliminaFiltro(Tipo As FiltroColonna.TipologiaFiltri,
                              Campo As String)
        For Each f As FiltroColonna In FiltriColonna

            If (f.TipoFiltro = Tipo) AndAlso (f.Campo = Campo) Then
                FiltriColonna.Remove(f)
                ResetMarcaturaColonna(f.Colonna)
                Exit For
            End If
        Next
    End Sub

    ''' <summary>
    '''elimina filtro/i sul campo corrente
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EliminaFiltro()
        For Each f As FiltroColonna In FiltriColonna

            If f.Campo = mCampo Then
                'elimino il filtro
                FiltriColonna.Remove(f)
                'reset grassetto/colore
                ResetMarcaturaColonna(f.Colonna)
                'ricreo la query
                mQuery = CreazioneQuery.CreaQueryCompleta(FiltriColonna)
                Exit For
            End If
        Next
    End Sub

    ''' <summary>
    ''' elimina tutti i filtri
    ''' </summary>
    Public Sub CancellaFiltri()
        If FiltriColonna.Count > 0 Then
            'resetto i font
            For Each f As FiltroColonna In FiltriColonna
                ResetMarcaturaColonna(f.Colonna)
            Next
            'cancello filtri e query
            FiltriColonna.Clear()
            mQuery = ""
            ApplicaFiltro()
        End If
    End Sub

    Private Sub CaricaListaFiltro(Optional ForzaCaricamento As Boolean = False)
        'Trace.Info("carico lista: " + Campo)

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
        'Trace.Info("fine carico lista: " + Campo)

        CheckedListBoxValori.DisplayMember = "Testo"

        AddHandler CheckedListBoxValori.ItemCheck, AddressOf CheckedListBoxValori_ItemCheck
    End Sub

    Private Sub CaricaListaFiltro(ChiaveRicerca As String)
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

        'se l'elemento nella lista è uno solo lo seleziono
        If CheckedListBoxValori.Items.Count = 1 Then
            CheckedListBoxValori.SetItemChecked(0, True)
        End If
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
                'analisi necessaria per l'operatore compreso tra
                If ComboBoxOperatori.SelectedItem.Codice = Operatori.CodiceOperatore.COMPRESO_TRA Then
                    If TextBoxValore2.Text.Trim.Length = 0 Then
                        MsgBox("Valori per l'intervallo non corretti.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                        TextBoxValore2.Focus()
                        Exit Sub
                    Else
                        'i due valori devono essere dello stesso tipo
                        Select Case TipoCampo.Name
                            Case "String"
                                'ok
                            Case "DateTime"
                                If IsDate(TextBoxValore.Text) And IsDate(TextBoxValore2.Text) Then
                                    'ok
                                Else
                                    MsgBox("I valori devono essere due date.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                                    TextBoxValore.Focus()
                                    Exit Sub
                                End If
                            Case Else
                                If IsNumeric(TextBoxValore.Text) And IsNumeric(TextBoxValore2.Text) Then
                                    'ok
                                Else
                                    MsgBox("I valori devono essere due numeri.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                                    TextBoxValore.Focus()
                                    Exit Sub
                                End If
                        End Select

                    End If
                End If

                AddFiltroOperatore()
            End If

            'creo il filtro totale
            mQuery = CreazioneQuery.CreaQueryCompleta(FiltriColonna)
            'applico il filtro al datasource
            ApplicaFiltro()
        Else
            'sono su scheda layout non faccio niente
        End If

        ButtonOk.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub ImpostaLayout()
        'cambia la visibilità delle colonne
        If CheckedListBoxColonne.CheckedItems.Count = 0 Then
            MsgBox("E' necessario selezionare almeno una colonna", MsgBoxStyle.Exclamation, "Layout")
        Else
            Dim dgv As DataGridView = mColonna.DataGridView

            For Each l As LayoutColonna In LayoutColonne
                dgv.Columns(l.Campo).Visible = l.Visibile
                dgv.Columns(l.Campo).DisplayIndex = l.DisplayIndex
            Next
        End If
    End Sub

    Private Sub MarcaturaColonna(ByRef col As DataGridViewColumn)
        col.HeaderCell.Style.ForeColor = ColoreColonnaFiltrata
        col.HeaderCell.Style.Font = FontBold(col)
    End Sub

    Public Sub MarcaturaColonne()
        For Each f As FiltroColonna In FiltriColonna
            f.Colonna.HeaderCell.Style.ForeColor = ColoreColonnaFiltrata
            f.Colonna.HeaderCell.Style.Font = FontBold(f.Colonna)
        Next
    End Sub

    Private Sub ResetMarcaturaColonneFiltrate()
        For Each f As FiltroColonna In FiltriColonna
            f.Colonna.HeaderCell.Style.ForeColor = Color.Black
            f.Colonna.HeaderCell.Style.Font = FontNormale(f.Colonna)
        Next
    End Sub

    Private Sub ResetMarcaturaColonna(ByRef col As DataGridViewColumn)
        col.HeaderCell.Style.ForeColor = Color.Black
        col.HeaderCell.Style.Font = FontNormale(col)
    End Sub

    Private Sub ResetMarcaturaColonna(Campo As String)
        For Each f As FiltroColonna In FiltriColonna
            If f.Campo = Campo Then
                f.Colonna.HeaderCell.Style.ForeColor = Color.Black
                f.Colonna.HeaderCell.Style.Font = FontNormale(f.Colonna)
                Exit For
            End If
        Next
    End Sub

    Private Sub ApplicaFiltro()
        Try
            'se è stata passata la colonna la dgv c'è sempre
            'potrebbe non esserci il datasource (griglia creata non a partire dalla sorgente dati)
            If (mColonna IsNot Nothing) AndAlso
               (mColonna.DataGridView IsNot Nothing) AndAlso
               (mColonna.DataGridView.DataSource IsNot Nothing) Then

                If mColonna.DataGridView.DataSource.GetType.Name = "DataView" Then
                    mColonna.DataGridView.DataSource.RowFilter = mQuery
                ElseIf mColonna.DataGridView.DataSource.GetType.Name = "DataTable" Then
                    mColonna.DataGridView.DataSource.DefaultView.RowFilter = mQuery
                ElseIf mColonna.DataGridView.DataSource.GetType.Name = "BindingSource" Then
                    mColonna.DataGridView.DataSource.DataSource.DefaultView.RowFilter = mQuery
                End If
            End If

            RaiseEvent ModificatoFiltro()

        Catch ex As Exception
            Globale.Log.Info(mQuery)
            Globale.Log.Errore(ex)
        End Try
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
            Filtro.Colonna = mColonna
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
                    MarcaturaColonna(Filtro.Colonna)
                End If
            End If
        End If
    End Sub

    Private Sub AddFiltroOperatore()
        'aggiungo un filtro di tipo OPERATORE all'insieme dei filtri
        Dim Filtro As New FiltroColonna
        Filtro.Colonna = mColonna
        Filtro.Campo = Campo
        Filtro.DeskCampo = mColonna.HeaderText
        Filtro.TipoCampo = TipoCampo
        Filtro.TipoFiltro = FiltroColonna.TipologiaFiltri.OPERATORE
        Filtro.Operatore = ComboBoxOperatori.SelectedItem
        Filtro.Chiave = TextBoxValore.Text.Replace("'", "''").ToUpper
        Filtro.ChiaveAl = TextBoxValore2.Text.Replace("'", "''").ToUpper

        Filtro.Query = New CreazioneQuery(Filtro).Query

        'aggiungo il filtro alla lista dei filtri colonna
        If Filtro.Query.Length > 0 Then
            FiltriColonna.Add(Filtro)
            MarcaturaColonna(Filtro.Colonna)
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
                                   Selezionato As CheckState)
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

    Public Sub Visualizza(ByRef Colonna As DataGridViewColumn, Optional Centra As Boolean = False)
        Try
            mColonna = Colonna

            'se fallisce il caricamento dei dati esce
            If (mFilterVisible = True) AndAlso (CaricaElencoDati() = False) Then
                Exit Sub
            End If

            'visualizzo il form del filtro/layout
            With Me
                .StartPosition = FormStartPosition.Manual

                'calcolo la posizione della finestra.
                'Offset mi serve per spostare (di poco) il form rispetto al cursore
                Dim Offset As Integer = 5
                Dim Posizione As Point
                If Centra = False Then
                    Posizione = New Point(Cursor.Position.X - Offset, Cursor.Position.Y - Offset)
                Else
                    Posizione = New Point((Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2)
                End If

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
            End With

            'leggo layout
            If mFilterVisible = False Then
                'sono in modalità layout
                ButtonAnnulla.Visible = False
                tlpLayout.SetColumnSpan(ButtonOk, 2)
                LeggiDatiLayout()
            End If

            Me.ShowDialog()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub VisualizzaDettaglio(ByRef Colonna As DataGridViewColumn)
        Try
            mColonna = Colonna

            'se fallisce il caricamento dei dati esce
            If (mFilterVisible = True) AndAlso (CaricaElencoDati() = False) Then
                Exit Sub
            End If
            ButtonDettaglio_Click(Me, New EventArgs)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Function CaricaElencoDati() As Boolean
        Try
            If (mColonna.DataGridView.DataSource Is Nothing) Then
                Return False
            End If

            'recupero datatable origine del campo
            Dim dt As DataTable

            Select Case mColonna.DataGridView.DataSource.GetType.Name
                Case "DataView"
                    dt = mColonna.DataGridView.DataSource.Table
                Case "DataTable"
                    dt = mColonna.DataGridView.DataSource
                Case "BindingSource"
                    dt = mColonna.DataGridView.DataSource.DataSource
                Case Else
                    Return False
            End Select

            If dt.Columns(mColonna.Name) Is Nothing Then
                MsgBox(String.Format("Il campo '{0}' non risulta disponibile nella visualizzazione corrente", mColonna.Name.ToUpper), MsgBoxStyle.Information)
                Return False
            End If

            'assegno il campo e i dati del filtro
            Me.Titolo = mColonna.HeaderText
            Me.Campo = mColonna.Name
            Me.TipoCampo = dt.Columns(Campo).DataType
            'Trace.Info("carico elementi: " + Campo)

            'riempio la classe che contiene gli item filtro della colonna
            ElementiColonna.Clear()
            'valore selezionato
            If mColonna.DataGridView.CurrentRow IsNot Nothing Then
                Me.ValoreSelezionato = mColonna.DataGridView.CurrentRow.Cells(mColonna.Index).Value
            End If

            'creo un clone altrimenti, l'applicazione della query senza un campo, mi sballa la vista corrente
            Dim dtClone As DataTable = dt.Copy
            'applico la query, escluso il campo corrente, per avere solo valori compatibili
            dtClone.DefaultView.RowFilter = CreazioneQuery.CreaQueryCompleta(FiltriColonna, mCampo)
            'carico i dati da un datatable di valori unici
            For Each dr As DataRow In FunzioniDb.CreaDataTableDistinct(dtClone, {mCampo}).Rows
                ElementiColonna.Add(New ItemColonna(dr(Campo), TipoCampo, True))
            Next
            'Trace.Info("fine carico elementi: " + Campo)

            'ordino ascendente tranne le date che ordino in senso inverso
            ElementiColonna.Sort(Me.TipoCampo.Name <> "DateTime")
            'Trace.Info("fine sort: " + Campo)

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

        Catch ex As System.Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
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

    Public Sub ApriDettaglioFiltri()
        DettaglioFiltro()
    End Sub

    Private Sub ButtonDettaglio_Click(sender As Object, e As EventArgs) Handles ButtonDettaglio.Click
        Select Case TabControlMain.SelectedTab.Name
            Case "TabPageFiltri"
                DettaglioFiltro()
            Case "TabPageLayout"
                DettaglioLayout()
        End Select
    End Sub

    Private Sub DettaglioFiltro()
        Try
            Dettaglio = New FormDettagioFiltro
            With Dettaglio
                .Modo = FormDettagioFiltro.Modalita.FILTRO
                .AppName = mAppName
                .FilterFolder = mFilterFolder
                .FiltroCorrente = FiltriColonna
                .GestoreLayout = GestoreLayout

                .ShowDialog()

                If .DialogResult = Windows.Forms.DialogResult.OK Then
                    DialogResult = Windows.Forms.DialogResult.OK
                End If
            End With

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub DettaglioLayout()
        Try
            Dettaglio = New FormDettagioFiltro
            With Dettaglio
                .Modo = FormDettagioFiltro.Modalita.LAYOUT
                .ButtonCarica.Enabled = False
                .AppName = mAppName
                .FilterFolder = mFilterFolder
                .GestoreLayout = GestoreLayout

                .ShowDialog()

                If .DialogResult = Windows.Forms.DialogResult.OK Then
                    DialogResult = Windows.Forms.DialogResult.OK
                End If
            End With

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

#Region "Layout"
    Public Function EsisteLayoutGriglia() As Boolean
        Return (LayoutColonne.Count > 0)
    End Function

    Public Sub ApplicaLayoutGriglia(ByRef dgv As DataGridView)
        'inizializza la struttura layout delle colonne
        If LayoutColonne.Count > 0 Then
            'per tutte le colonne
            For Each l As LayoutColonna In LayoutColonne
                Try
                    With dgv.Columns(l.Campo)
                        .HeaderText = l.Titolo
                        .Visible = l.Visibile
                        .Width = l.Larghezza
                        'colore testo
                        Select Case l.ColoreTesto
                            Case Is < 0
                                .DefaultCellStyle.ForeColor = Color.FromArgb(l.ColoreTesto)
                            Case 0
                                .DefaultCellStyle.ForeColor = Nothing
                        End Select
                        'colore sfondo
                        Select Case l.ColoreSfondo
                            Case Is < 0
                                .DefaultCellStyle.BackColor = Color.FromArgb(l.ColoreSfondo)
                            Case 0
                                .DefaultCellStyle.BackColor = Nothing
                        End Select
                    End With
                Catch ex As Exception
                    Utx.Globale.Log.Info(l.Campo)
                    Utx.Globale.Log.Errore(ex)
                End Try
            Next
        End If
    End Sub

    Private Sub TabPageLayout_Selected(sender As Object, e As TabControlEventArgs) Handles TabControlMain.Selected
        If e.TabPage IsNot Nothing Then
            e.TabPage.Refresh()

            Select Case e.TabPage.Name
                Case "TabPageLayout"
                    LeggiDatiLayout()
            End Select
        End If
    End Sub

    Private Sub LeggiDatiLayout()
        RemoveHandler CheckedListBoxColonne.ItemCheck, AddressOf CheckedListBoxColonne_ItemCheck

        'inizializza la struttura layout delle colonne
        LeggiLayoutDaGriglia(mColonna.DataGridView, True)

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
                                                          False, ColonneSelezionateTutte,
                                                          Nothing, Nothing,
                                                          0, -1, 0, ""),
                                                ColonneSelezionateTutte)

        For Each l As LayoutColonna In LayoutColonne
            If l.Nascosta = False Then
                CheckedListBoxColonne.Items.Add(l, l.Visibile)
            End If
        Next

        CheckedListBoxColonne.DisplayMember = "Descrizione" ' "Titolo"
        CheckedListBoxColonne.CheckOnClick = False
        CheckedListBoxColonne.Sorted = True

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
        'applico la modifica
        ApplicaLayoutGriglia(mColonna.DataGridView)

        AddHandler CheckedListBoxColonne.ItemCheck, AddressOf CheckedListBoxColonne_ItemCheck
    End Sub

    Private Sub ButtonColoreSfondo_Click(sender As Object, e As EventArgs) Handles ButtonColoreSfondo.Click
        If CheckedListBoxColonne.SelectedItem Is Nothing Then
            MsgBox("Selezionare prima una colonna dalla lista.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
        Else
            Dim ColonnaSelezionata As LayoutColonna = CheckedListBoxColonne.SelectedItem

            Dim cd As New ColorDialog
            If cd.ShowDialog(Me) = DialogResult.OK Then
                ColonnaSelezionata.ColoreSfondo = cd.Color.ToArgb
            Else
                ColonnaSelezionata.ColoreSfondo = 0
            End If
            ApplicaLayoutGriglia(mColonna.DataGridView)
        End If
    End Sub

    Private Sub ButtonColoreTesto_Click(sender As Object, e As EventArgs) Handles ButtonColoreTesto.Click
        If CheckedListBoxColonne.SelectedItem Is Nothing Then
            MsgBox("Selezionare prima una colonna dalla lista.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
        Else
            Dim ColonnaSelezionata As LayoutColonna = CheckedListBoxColonne.SelectedItem

            Dim cd As New ColorDialog
            If cd.ShowDialog(Me) = DialogResult.OK Then
                ColonnaSelezionata.ColoreTesto = cd.Color.ToArgb
            Else
                ColonnaSelezionata.ColoreTesto = 0
            End If
            ApplicaLayoutGriglia(mColonna.DataGridView)
        End If
    End Sub

    Public Sub SalvaLayoutGriglia(NomeFile As String,
                                  Optional NomeGriglia As String = "default")
        Try
            Dim xmlDoc As New XmlDocument

            Dim xmlGridNode As XmlElement = xmlDoc.CreateElement("grid")
            xmlGridNode.SetAttribute("name", NomeGriglia)
            xmlDoc.AppendChild(xmlGridNode)

            'salvo il font
            xmlGridNode.AppendChild(CreaElementoFont(xmlGridNode))

            'salvo il layout delle colonne
            For Each l As LayoutColonna In LayoutColonne
                xmlGridNode.AppendChild(CreaElementoColonna(xmlGridNode, l))
            Next

            xmlDoc.Save(NomeFile)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

    End Sub

    Public Function XmlLayoutGriglia(NomeFile As String,
                                     Optional NomeGriglia As String = "default") As XmlElement
        Try
            Dim xmlDoc As New XmlDocument

            Dim xmlGridNode As XmlElement = xmlDoc.CreateElement("grid")
            xmlGridNode.SetAttribute("name", NomeGriglia)
            xmlDoc.AppendChild(xmlGridNode)

            'elemento font
            xmlGridNode.AppendChild(CreaElementoFont(xmlGridNode))

            'layout delle colonne
            For Each l As LayoutColonna In LayoutColonne
                xmlGridNode.AppendChild(CreaElementoColonna(xmlGridNode, l))
            Next

            Return xmlGridNode

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Public Function CreaElementoColonna(ParentNode As XmlNode,
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
            .SetAttribute("displayindex", Colonna.DisplayIndex)
            .SetAttribute("alignment", Colonna.Allineamento)
            .SetAttribute("format", Colonna.Formato)
        End With
        Return xmlEl
    End Function

    Public Function CreaElementoFont(ParentNode As XmlNode) As XmlElement
        Dim xmlEl As XmlElement = ParentNode.OwnerDocument.CreateElement("font")
        With xmlEl
            .SetAttribute("name", FontGriglia.Name)
            .SetAttribute("size", FontGriglia.Size)
        End With
        Return xmlEl
    End Function

    Public Function CreaElementoProperty(ParentNode As XmlNode,
                                         Edit As Boolean) As XmlElement
        Dim xmlEl As XmlElement = ParentNode.OwnerDocument.CreateElement("property")
        xmlEl.SetAttribute("edit", Edit)
        Return xmlEl
    End Function

    Public Sub LeggiLayoutDaGriglia(ByRef dgv As DataGridView,
                                    Optional ForzaLettura As Boolean = False)
        'font
        FontGriglia = New Font(dgv.Font.Name, dgv.Font.Size)

        'se la struttura layout non è ancora inizializzata la legge dalla griglia
        If (ForzaLettura = True) OrElse (LayoutColonne.Count) = 0 Then

            LayoutColonne.Clear()

            For Each c As DataGridViewColumn In dgv.Columns

                LayoutColonne.Add(New LayoutColonna(c.Name,
                                                    c.HeaderText,
                                                    c.Tag,
                                                    c.Visible,
                                                    c.DefaultCellStyle.BackColor.ToArgb,
                                                    c.DefaultCellStyle.ForeColor.ToArgb,
                                                    c.Width,
                                                    c.DisplayIndex,
                                                    c.DefaultCellStyle.Alignment,
                                                    c.DefaultCellStyle.Format))
            Next
        End If
    End Sub

    Public Sub LeggiFontDaGriglia(ByRef dgv As DataGridView)
        FontGriglia = New Font(dgv.Font.Name, dgv.Font.Size)
    End Sub

    Public Shared Function LeggiFontDaXml(XmlFile As String,
                                          NomeLayout As String) As Font
        Try
            If File.Exists(XmlFile) = False Then
                Return Nothing
            End If

            Dim xDoc As New XmlDocument
            xDoc.Load(XmlFile)

            Dim xnl As XmlNodeList = xDoc.SelectNodes(String.Format("//grid[@name='{0}']/font", NomeLayout))

            If xnl.Count = 0 Then
                Return New Font("Tahoma", 9)
            Else
                Return New Font(xnl.Item(0).Attributes("name").InnerText,
                                CInt(xnl.Item(0).Attributes("size").InnerText))
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return Nothing
        End Try

    End Function

    Public Sub LeggiLayoutDaXml(XmlFile As String,
                                NomeLayout As String)
        Try
            If File.Exists(XmlFile) = False Then
                Exit Sub
            End If

            Dim xDoc As New XmlDocument
            xDoc.Load(XmlFile)

            'il font
            FontGriglia = LeggiFontDaXml(XmlFile, NomeLayout)

            'le colonne
            LayoutColonne.Clear()

            Dim xnl As XmlNodeList = xDoc.SelectNodes(String.Format("//grid[@name='{0}']/column", NomeLayout))

            If xnl.Count = 0 Then
                Exit Sub
            End If

            For Each xn As XmlNode In xnl

                Dim l As New LayoutColonna

                l.Campo = xn.Attributes("name").InnerText
                l.Titolo = xn.Attributes("text").InnerText
                l.Nascosta = xn.Attributes("hide").InnerText
                l.Visibile = xn.Attributes("visible").InnerText
                l.Larghezza = xn.Attributes("width").InnerText
                'colori
                If xn.Attributes("argbforecolor").InnerText <> "0" Then
                    l.ColoreTesto = xn.Attributes("argbforecolor").InnerText
                End If
                If xn.Attributes("argbbackcolor").InnerText <> "0" Then
                    l.ColoreSfondo = xn.Attributes("argbbackcolor").InnerText
                End If
                'posizione colonna
                If xn.Attributes("displayindex") Is Nothing Then
                    l.DisplayIndex = LayoutColonne.Count
                Else
                    l.DisplayIndex = xn.Attributes("displayindex").InnerText
                End If
                'allineamento
                If (xn.Attributes("alignment") Is Nothing) Then
                    l.Allineamento = DataGridViewContentAlignment.TopLeft
                Else
                    l.Allineamento = xn.Attributes("alignment").InnerText
                End If
                'formattazione
                If (xn.Attributes("format") Is Nothing) Then
                    l.Formato = ""
                Else
                    l.Formato = xn.Attributes("format").InnerText
                End If

                LayoutColonne.Add(l)
            Next

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Restituisce True se il layout è modificabile
    ''' </summary>
    ''' <param name="XmlFile"></param>
    ''' <param name="NomeLayout"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EditLayout(XmlFile As String, NomeLayout As String) As Boolean
        Try
            If File.Exists(XmlFile) = True Then
                Dim xDoc As New XmlDocument
                xDoc.Load(XmlFile)

                Dim xnl As XmlNodeList = xDoc.SelectNodes(String.Format("//grid[@name='{0}']/property", NomeLayout))

                If xnl.Count > 0 Then
                    Return xnl.Item(0).Attributes("edit").InnerText
                Else
                    Return True
                End If
            Else
                Return True
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return True
        End Try
    End Function

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

    Private Sub ButtonSpostaColonnaIn_Click(sender As Object, e As EventArgs) Handles ButtonSpostaColonnaIn.Click
        Try
            If CheckedListBoxColonne.SelectedItem Is Nothing Then
                MsgBox("Selezionare prima una colonna dalla lista.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            Else
                Dim Temp As Object = InputBox("Sposta alla colonna", "Modifica layout", "")
                If String.IsNullOrEmpty(Temp) Then
                    Exit Sub
                ElseIf (IsNumeric(Temp) = False) OrElse (Temp <= 0) OrElse (Temp > LayoutColonne.Count) Then
                    MsgBox(String.Format("Inserire un valore compreso fra 1 e {0}", LayoutColonne.Count), MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                    Exit Sub
                End If

                ButtonSu.Enabled = False

                Dim ItemCorrente As LayoutColonna = CheckedListBoxColonne.SelectedItem

                CheckedListBoxColonne.Enabled = False
                CheckedListBoxColonne.Sorted = False
                CheckedListBoxColonne.SuspendLayout()

                Dim NuovaPosizione As Integer = Temp
                Dim IndiceCorrente As Integer = ItemCorrente.DisplayIndex
                Dim NuovoIndice As Integer = NuovaPosizione - 1 'displayIndex è a base zero

                Select Case IndiceCorrente
                    Case Is < NuovoIndice
                        'si deve spostare in giù
                        For Each l As LayoutColonna In LayoutColonne
                            If (l.DisplayIndex > IndiceCorrente) And (l.DisplayIndex <= NuovoIndice) Then
                                l.DisplayIndex -= 1
                            End If
                        Next

                    Case Is = NuovoIndice
                        'non si deve spostare

                    Case Is > NuovoIndice
                        'si sposta in su
                        For Each l As LayoutColonna In LayoutColonne
                            If (l.DisplayIndex >= NuovoIndice) And (l.DisplayIndex < IndiceCorrente) Then
                                l.DisplayIndex += 1
                            End If
                        Next
                End Select

                ItemCorrente.DisplayIndex = NuovoIndice

                CheckedListBoxColonne.Sorted = True
                CheckedListBoxColonne.Enabled = True
                CheckedListBoxColonne.ResumeLayout()

                ButtonSu.Enabled = True
            End If
            ImpostaLayout()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonSu_Click(sender As Object, e As EventArgs) Handles ButtonSu.Click
        Try
            ButtonSu.Enabled = False

            Dim ItemCorrente As LayoutColonna = CheckedListBoxColonne.SelectedItem

            If ItemCorrente.DisplayIndex = 0 Then
                Exit Try
            End If

            CheckedListBoxColonne.Enabled = False
            CheckedListBoxColonne.Sorted = False
            CheckedListBoxColonne.SuspendLayout()

            Dim IndiceCorrente As Integer = ItemCorrente.DisplayIndex
            Dim NuovoIndice As Integer = IndiceCorrente - 1

            'si sposta in su
            For Each l As LayoutColonna In LayoutColonne
                If (l.DisplayIndex >= NuovoIndice) And (l.DisplayIndex < IndiceCorrente) Then
                    l.DisplayIndex += 1
                End If
            Next

            ItemCorrente.DisplayIndex = NuovoIndice

            CheckedListBoxColonne.Sorted = True
            CheckedListBoxColonne.Enabled = True
            CheckedListBoxColonne.ResumeLayout()

            ImpostaLayout()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            ButtonSu.Enabled = True
        End Try
    End Sub

    Private Sub ButtonGiu_Click(sender As Object, e As EventArgs) Handles ButtonGiu.Click
        Try
            ButtonSu.Enabled = False

            Dim ItemCorrente As LayoutColonna = CheckedListBoxColonne.SelectedItem

            If ItemCorrente.DisplayIndex = CheckedListBoxColonne.Items.Count Then
                Exit Try
            End If

            CheckedListBoxColonne.Enabled = False
            CheckedListBoxColonne.Sorted = False
            CheckedListBoxColonne.SuspendLayout()

            Dim IndiceCorrente As Integer = ItemCorrente.DisplayIndex
            Dim NuovoIndice As Integer = IndiceCorrente + 1

            'si deve spostare in giù
            For Each l As LayoutColonna In LayoutColonne
                If (l.DisplayIndex > IndiceCorrente) And (l.DisplayIndex <= NuovoIndice) Then
                    l.DisplayIndex -= 1
                End If
            Next

            ItemCorrente.DisplayIndex = NuovoIndice

            CheckedListBoxColonne.Sorted = True
            CheckedListBoxColonne.Enabled = True
            CheckedListBoxColonne.ResumeLayout()

            ImpostaLayout()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            ButtonSu.Enabled = True
        End Try
    End Sub

    Public Sub SortLayout()
        'ordino per display index per semplicità di lettura degli xml
        LayoutColonne.Sort(AddressOf LayoutColonnaComparer)
    End Sub

    Private Function LayoutColonnaComparer(x As LayoutColonna, y As LayoutColonna) As Integer
        ' 1. Gestione oggetti nulli (per stabilità dell'algoritmo)
        If x Is y Then Return 0
        If x Is Nothing Then Return -1 ' Il nullo viene prima
        If y Is Nothing Then Return 1

        ' 2. Ordinamento CRESCENTE per DisplayIndex
        ' Passiamo x come primo argomento e y come secondo
        Return Comparer(Of Object).Default.Compare(x.DisplayIndex, y.DisplayIndex)
    End Function
#End Region

    Private Sub FormGestioneFiltro_ResizeBegin(sender As Object, e As EventArgs) Handles Me.ResizeBegin
        Me.Opacity = 0.8
        Me.SuspendLayout()
    End Sub

    Private Sub FormGestioneFiltro_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        Me.Opacity = 1
        Me.ResumeLayout()
        ComboBoxOperatori.Refresh() 'atrimenti non si aggiorna correttamente
    End Sub

    Private Sub ComboBoxOperatori_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxOperatori.SelectedIndexChanged
        If ComboBoxOperatori.SelectedItem.Codice = Operatori.CodiceOperatore.COMPRESO_TRA Then
            tlpFiltri.SetColumnSpan(TextBoxValore, 1)
            TextBoxValore2.Visible = True
            Label2.Visible = True
        Else
            TextBoxValore2.Visible = False
            Label2.Visible = False
            tlpFiltri.SetColumnSpan(TextBoxValore, 4)
        End If
    End Sub

    Private Sub Dettaglio_CaricatoFiltro(FiltroCaricato As List(Of FiltroColonna)) Handles Dettaglio.CaricatoFiltro
        Try
            'cancello il filtro precedente e resetto il grassetto dalle colonne
            ResetMarcaturaColonneFiltrate()
            FiltriColonna.Clear()

            For Each Filtro As FiltroColonna In FiltroCaricato
                Filtro.Query = New CreazioneQuery(Filtro).Query

                'aggancio l'oggetto colonna, che non è salvato nel filtro, tramite il campo
                For Each col As DataGridViewColumn In mColonna.DataGridView.Columns
                    If col.Name = Filtro.Campo Then
                        Filtro.Colonna = col
                        MarcaturaColonna(col)
                        Exit For
                    End If
                Next

                FiltriColonna.Add(Filtro)
            Next

            mQuery = CreazioneQuery.CreaQueryCompleta(FiltriColonna)
            ApplicaFiltro()

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub Dettaglio_SalvatoLayout(NomeLayout As String) Handles Dettaglio.SalvatoLayout
        RaiseEvent SalvatoLayout(NomeLayout)
    End Sub

    Private Sub Dettaglio_EliminatoLayout(NomeLayout As String) Handles Dettaglio.EliminatoLayout
        RaiseEvent EliminatoLayout(NomeLayout)
    End Sub

    Private Sub ButtonSelezione_Click(sender As Object, e As EventArgs) Handles ButtonSelezione.Click
        ComboBoxOperatori.SelectedIndex = Operatori.CodiceOperatore.UGUALE
        TextBoxValore.Text = mValoreSelezionato
        ButtonOk.PerformClick()
    End Sub

    Private Sub ButtonDiverso_Click(sender As Object, e As EventArgs) Handles ButtonDiverso.Click
        ComboBoxOperatori.SelectedIndex = Operatori.CodiceOperatore.DIVERSO
        TextBoxValore.Text = mValoreSelezionato
        ButtonOk.PerformClick()
    End Sub

    Private Sub FormGestioneFiltro_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Me.Close()
    End Sub
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

    Sub New(MaxNumeroItemLista As Integer)
        MaxNumeroItem = MaxNumeroItemLista
    End Sub

    Private mTipoCampo As Type
    Public Property TipoCampo() As Type
        Get
            Return mTipoCampo
        End Get
        Set(value As Type)
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

    Public Sub Add(Elemento As ItemColonna)
        If Elemento.Testo = "" Then
            mEsistonoVuoti = True
        Else
            If Elemento.Valore.ToString = "" Then
                ItemColonna.ItemVuoti(True)
            Else
                mElementi.Add(Elemento)
            End If
        End If
    End Sub

    Public Sub Insert(Index As Integer, Elemento As ItemColonna)
        mElementi.Insert(Index, Elemento)
    End Sub

    Public Sub Sort(Optional OrdinamentoAscendente As Boolean = True)
        If OrdinamentoAscendente = True Then
            mElementi.Sort(AddressOf ItemColonnaComparerASC)
        Else
            mElementi.Sort(AddressOf ItemColonnaComparerDESC)
        End If
    End Sub

    Public Function Elementi() As List(Of ItemColonna)
        Return mElementi
    End Function

    Public Function EsisteElemento(Testo As String) As Boolean
        For Each i As ItemColonna In mElementi
            If i.Testo = Testo Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function TrovaElemento(Cerca As ItemColonna) As ItemColonna
        Return mElementi.Find(Function(i As ItemColonna) i.Testo = Cerca.Testo)
    End Function

    Public Function Elemento(Index As Integer) As ItemColonna
        Return mElementi.Item(Index)
    End Function

    Public Sub SelezionaTutti()
        mElementi.ForEach(AddressOf SelezionaItem)
    End Sub

    Public Sub DeSelezionaTutti()
        mElementi.ForEach(AddressOf DeSelezionaItem)
    End Sub

    Public Sub SelezionaElementi(Items As List(Of ItemColonna))
        'poiché gli elementi sono di default tutti selezionati se bisogna selezionarne solo alcuni
        'deselezionare prima tutti e poi selezionare gli item interessati
        Me.DeSelezionaTutti()

        For Each i As ItemColonna In Items
            Dim e As ItemColonna = TrovaElemento(i)
            If e IsNot Nothing Then
                e.Selezionato = True
            End If
        Next
    End Sub

    Public Sub DeSelezionaElementi(Items As List(Of ItemColonna))
        For Each i As ItemColonna In Items
            Dim e As ItemColonna = TrovaElemento(i)
            If e IsNot Nothing Then
                e.Selezionato = False
            End If
        Next
    End Sub

    Public Sub CambiaSelezioneElemento(Index As Integer,
                                       Selezionato As Boolean)
        mElementi.Item(Index).Selezionato = Selezionato
    End Sub

    Public Sub ContaElementi(ByRef Selezionati As Integer,
                             ByRef Deselezionati As Integer,
                             SelezionatoTutti As Boolean)
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
    Private Sub SelezionaItem(Item As ItemColonna)
        Item.Selezionato = True
    End Sub

    Private Sub DeSelezionaItem(Item As ItemColonna)
        Item.Selezionato = False
    End Sub

    Private Function TrovaSelezionati(Item As ItemColonna) As Boolean
        Return Item.Selezionato = True
    End Function

    Private Function TrovaDeselezionati(Item As ItemColonna) As Boolean
        If Item.Testo = ItemsColonna.Tag.TuttiDesk Then
            'per i deselezionati bisogna escludere tag_tutti
            Return False
        Else
            Return Item.Selezionato = False
        End If
    End Function

    Private Function ItemColonnaComparerASC(x As ItemColonna, y As ItemColonna) As Integer
        ' 1. Gestione oggetti nulli (per stabilità dell'algoritmo)
        If x Is y Then Return 0
        If x Is Nothing Then Return -1 ' Il nullo viene prima
        If y Is Nothing Then Return 1

        ' 2. Ordinamento CRESCENTE (ASC)
        ' Passiamo x come primo argomento e y come secondo
        Return Comparer(Of Object).Default.Compare(x.Valore, y.Valore)
    End Function

    Private Function ItemColonnaComparerDESC(x As ItemColonna, y As ItemColonna) As Integer
        ' 1. Gestione oggetti nulli
        If x Is y Then Return 0
        If x Is Nothing Then Return 1
        If y Is Nothing Then Return -1

        ' 2. Per il DESC (Decrescente), passiamo prima y e poi x
        Return Comparer(Of Object).Default.Compare(y.Valore, x.Valore)
    End Function
#End Region
End Class

Friend Class ItemColonna

    Sub New(Valore As String,
            Testo As String,
            Selezionato As Boolean)
        mValore = Valore
        mTesto = Testo
        mSelezionato = Selezionato
    End Sub

    Sub New(Valore As Object,
            TipoCampo As Type,
            Selezionato As Boolean)

        If TipoCampo.Name = "DateTime" Then
            If (Valore Is DBNull.Value) Then
                mValore = ItemsColonna.Tag.Vuoti
                mTesto = ""
            ElseIf (Valore.GetType Is GetType(String)) AndAlso (Valore = ItemsColonna.Tag.Vuoti) Then
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
        Set(value As Object)
            mValore = value
        End Set
    End Property

    Private mTesto As String
    Public Property Testo() As String
        Get
            Return mTesto
        End Get
        Set(value As String)
            mTesto = value
        End Set
    End Property

    Private mSelezionato As Boolean
    Public Property Selezionato() As Boolean
        Get
            Return mSelezionato
        End Get
        Set(value As Boolean)
            mSelezionato = value
        End Set
    End Property

    Public Shared Function ItemTutti(Selezionato As Boolean) As ItemColonna
        Return New ItemColonna(ItemsColonna.Tag.Tutti, ItemsColonna.Tag.TuttiDesk, Selezionato)
    End Function

    Public Shared Function ItemVuoti(Selezionato As Boolean) As ItemColonna
        Return New ItemColonna(ItemsColonna.Tag.Vuoti, ItemsColonna.Tag.VuotiDesk, Selezionato)
    End Function

    Public Shared Function ItemAggiungi(Selezionato As Boolean) As ItemColonna
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

    Private mColonna As DataGridViewColumn
    Public Property Colonna() As DataGridViewColumn
        Get
            Return mColonna
        End Get
        Set(value As DataGridViewColumn)
            mColonna = value
        End Set
    End Property

    Private mCampo As String
    Public Property Campo() As String
        Get
            Return mCampo
        End Get
        Set(value As String)
            mCampo = value
        End Set
    End Property

    Private mDeskCampo As String
    Public Property DeskCampo() As String
        Get
            Return mDeskCampo
        End Get
        Set(value As String)
            mDeskCampo = value
        End Set
    End Property

    Private mTipoCampo As Type
    Public Property TipoCampo() As Type
        Get
            Return mTipoCampo
        End Get
        Set(value As Type)
            mTipoCampo = value
        End Set
    End Property

    Private mOperatore As Operatore
    Public Property Operatore() As Operatore
        Get
            Return mOperatore
        End Get
        Set(value As Operatore)
            mOperatore = value
        End Set
    End Property

    Private mTipoFiltro As TipologiaFiltri
    Public Property TipoFiltro() As TipologiaFiltri
        Get
            Return mTipoFiltro
        End Get
        Set(value As TipologiaFiltri)
            mTipoFiltro = value
        End Set
    End Property

    Private mItems As List(Of ItemColonna)
    Public Property Items() As List(Of ItemColonna)
        Get
            Return mItems
        End Get
        Set(value As List(Of ItemColonna))
            mItems = value
        End Set
    End Property

    Private mChiave As String
    Public Property Chiave() As String
        Get
            Return mChiave
        End Get
        Set(value As String)
            mChiave = value
        End Set
    End Property

    Private mChiaveAl As String
    Public Property ChiaveAl() As String
        Get
            Return mChiaveAl
        End Get
        Set(value As String)
            mChiaveAl = value
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
        Set(value As String)
            mQuery = value
        End Set
    End Property

    Private mElementi As ElementiLista
    Public Property Elementi() As ElementiLista
        Get
            Return mElementi
        End Get
        Set(value As ElementiLista)
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

    Sub New(Contesto As String,
            Codice As Operatori.CodiceOperatore,
            Descrizione As String,
            Simbolo As String)
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
        Set(value As String)
            mContesto = value
        End Set
    End Property

    Private mCodice As Operatori.CodiceOperatore
    Public Property Codice() As Operatori.CodiceOperatore
        Get
            Return mCodice
        End Get
        Set(value As Operatori.CodiceOperatore)
            mCodice = value
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

    Private mSimbolo As String
    Public Property Simbolo() As String
        Get
            Return mSimbolo
        End Get
        Set(value As String)
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
        COMPRESO_TRA = 7
        NESSUNO = 99
    End Enum

    Public Operatori As List(Of Operatore)

    Sub New(TipoCampo As Type)
        Operatori = New List(Of Operatore)

        With Operatori
            .Add(New Operatore("", CodiceOperatore.UGUALE, "Uguale", "="))
            .Add(New Operatore("", CodiceOperatore.DIVERSO, "Diverso", "<>"))
            .Add(New Operatore("", CodiceOperatore.MAGGIORE, "Maggiore", ">"))
            .Add(New Operatore("", CodiceOperatore.MINORE, "Minore", "<"))
            .Add(New Operatore("", CodiceOperatore.COMPRESO_TRA, "Compreso tra", ".."))

            If TipoCampo.Name = "String" Then
                .Add(New Operatore("String", CodiceOperatore.INIZIA, "Inizia", "LIKE"))
                .Add(New Operatore("String", CodiceOperatore.CONTIENE, "Contiene", "LIKE"))
                .Add(New Operatore("String", CodiceOperatore.NON_CONTIENE, "Non contiene", "LIKE"))
            End If

            'nessun operatore
            .Add(New Operatore("", CodiceOperatore.NESSUNO, "NN", "NN"))
        End With
    End Sub

    Public ReadOnly Property Operatore(Codice As Integer) As Operatore
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

    Private Function CreaQueryCheck(Filtro As FiltroColonna) As String
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
    ''' ricalcola la query completa del filtro da applicare alla dataview/datatable
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

    Public Shared Function CreaQueryCompleta(ByRef Filtri As List(Of FiltroColonna),
                                             CampoEscluso As String) As String
        Dim Query As String = ""

        'unisco i filtri di tutti i campi/colonne
        For Each f As FiltroColonna In Filtri

            If f.Campo <> CampoEscluso Then
                Query += String.Format("({0}) AND ", f.Query)
            End If
        Next

        Return EliminaOperatoreFinale(Query)
    End Function

    Public Function TipoValoreOk(TipoCampo As Type, Valore As String) As Boolean
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
        'per la conversione della virgola in punto nei campi numerici
        Select Case Filtro.TipoCampo.Name
            Case Is <> "String", "DateTime"
                Filtro.Chiave = Filtro.Chiave.Replace(",", ".")
        End Select

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
            Case Operatori.CodiceOperatore.COMPRESO_TRA
                Select Case Filtro.TipoCampo.Name
                    Case "String"
                        Return String.Format("[{0}] >= '{1}' AND [{0}] <= '{2}'", Filtro.Campo, Filtro.Chiave, Filtro.ChiaveAl)
                    Case "DateTime"
                        Return String.Format("[{0}] >= #{1}# AND [{0}] <= #{2}#",
                                             Filtro.Campo,
                                             Format(CDate(Filtro.Chiave), "MM/dd/yyyy"),
                                             Format(CDate(Filtro.ChiaveAl), "MM/dd/yyyy"))

                    Case Else
                        Return String.Format("[{0}] >= {1} AND [{0}] <= {2}", Filtro.Campo, Filtro.Chiave, Filtro.ChiaveAl)
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
                    Query += String.Format("([{0}] = {1}) OR ", f.Campo, i.Valore.ToString.Replace(",", "."))
                End If
            Else
                If ItemColonna.IsItemVuoti(i) Then
                    Query += String.Format("(NOT ([{0}] IS NULL)) AND ", f.Campo)
                Else
                    Query += String.Format("([{0}] <> {1}) AND ", f.Campo, i.Valore.ToString.Replace(",", "."))
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
                    Query += String.Format("(([{0}] <> '{1}') OR ([{0}] IS NULL)) AND ", f.Campo, i.Valore.Replace("'", "''"))
                End If
            End If
        Next

        Return EliminaOperatoreFinale(Query)
    End Function

    Private Shared Function EliminaOperatoreFinale(Query As String) As String
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

Public Class LayoutColonna

    Public Const TagTutti As String = "TAG_TUTTI"

    Sub New()
    End Sub

    Sub New(Campo As String,
            Titolo As String,
            Nascosta As Boolean,
            Visibile As Boolean,
            ColoreSfondo As Integer,
            ColoreTesto As Integer,
            Larghezza As Integer,
            DisplayIndex As Integer,
            Allineamento As Integer,
            Formato As String)
        mCampo = Campo
        mTitolo = Titolo
        mNascosta = Nascosta
        mVisibile = Visibile
        mColoreSfondo = ColoreSfondo
        mColoreTesto = ColoreTesto
        mLarghezza = Larghezza
        mDisplayIndex = DisplayIndex
        mAllineamento = Allineamento
        mFormato = Formato
    End Sub

    Private mCampo As String
    Public Property Campo() As String
        Get
            Return mCampo
        End Get
        Set(value As String)
            mCampo = value
        End Set
    End Property

    Private mTitolo As String
    Public Property Titolo() As String
        Get
            Return mTitolo
        End Get
        Set(value As String)
            mTitolo = value
        End Set
    End Property

    Private mNascosta As Boolean
    Public Property Nascosta() As Boolean
        Get
            Return mNascosta
        End Get
        Set(value As Boolean)
            mNascosta = value
        End Set
    End Property

    Private mVisibile As Boolean
    Public Property Visibile() As Boolean
        Get
            Return mVisibile
        End Get
        Set(value As Boolean)
            mVisibile = value
        End Set
    End Property

    Private mColoreSfondo As Integer
    Public Property ColoreSfondo() As Integer
        Get
            Return mColoreSfondo
        End Get
        Set(value As Integer)
            mColoreSfondo = value
        End Set
    End Property

    Private mColoreTesto As Integer
    Public Property ColoreTesto() As Integer
        Get
            Return mColoreTesto
        End Get
        Set(value As Integer)
            mColoreTesto = value
        End Set
    End Property

    Private mLarghezza As Integer
    Public Property Larghezza() As Integer
        Get
            Return mLarghezza
        End Get
        Set(value As Integer)
            mLarghezza = value
        End Set
    End Property

    Private mDisplayIndex As Integer
    Public Property DisplayIndex() As Integer
        Get
            Return mDisplayIndex
        End Get
        Set(value As Integer)
            mDisplayIndex = value
        End Set
    End Property

    Private mAllineamento As Integer
    Public Property Allineamento() As Integer
        Get
            Return mAllineamento
        End Get
        Set(value As Integer)
            mAllineamento = value
        End Set
    End Property

    Private mFormato As String
    Public Property Formato() As String
        Get
            Return mFormato
        End Get
        Set(value As String)
            mFormato = value
        End Set
    End Property

    Public ReadOnly Property Descrizione() As String
        Get
            Return String.Format("{0:000} {1}", mDisplayIndex + 1, mTitolo)
        End Get
    End Property
End Class