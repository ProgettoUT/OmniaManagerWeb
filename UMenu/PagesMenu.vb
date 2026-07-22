Public Class PagesMenu

    Inherits TableLayoutPanel

    Public Event BeforePageClick(key As String, Index As Integer)
    Public Event PageClick(key As String, Index As Integer)
    Public Event MenuButtonClick(key As String, Index As Integer)
    Public Event Chiudi()
    Public Event Minimizza()
    Public Event MinimizzaMenu()

    Public WithEvents ButtonChiudi As New Button
    Public WithEvents ButtonMinimizza As New Button
    Public WithEvents InfoLabel As Label
    Public ButtonStyle As PageButton.Style

    Sub New(ViewInfoLabel As Boolean)

        mViewInfoLabel = ViewInfoLabel

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Dock = DockStyle.Fill
        Me.BackColor = Color.White
        Me.Padding = New Padding(0)
        Me.Margin = New Padding(0)

        mPages = New List(Of Page)

        If mViewInfoLabel = True Then

            'info
            InfoLabel = New Label
            InfoLabel.Dock = DockStyle.Fill
            InfoLabel.Text = ""

            With ButtonChiudi
                .AutoSize = False
                .Margin = New Padding(0)
                .Padding = New Padding(0)
                .FlatStyle = FlatStyle.Flat
                .FlatAppearance.BorderSize = 0
                .Dock = DockStyle.Fill
                .BackColor = InfoLabel.BackColor
                .ForeColor = Color.White
                .TextAlign = ContentAlignment.MiddleLeft
                .Text = "X"
                .Font = New Font("Calibri", 12)
            End With

            With ButtonMinimizza
                .AutoSize = False
                .Margin = New Padding(0)
                .FlatStyle = FlatStyle.Flat
                .FlatAppearance.BorderSize = 0
                .Dock = DockStyle.Fill
                .BackColor = InfoLabel.BackColor
                .ForeColor = Color.White
                .TextAlign = ContentAlignment.MiddleLeft
                .Text = "_"
                .Font = New Font("Calibri", 12)
            End With

            Dim InfoTable As New TableLayoutPanel
            With InfoTable
                .Padding = New Padding(0)
                .Margin = New Padding(0)
                .Dock = DockStyle.Fill
                .ColumnCount = 1

                'aggiungo il bottone chiudi
                .RowStyles.Add(New RowStyle(SizeType.Absolute, 30))
                .RowCount += 1
                .Controls.Add(ButtonChiudi)
                .SetCellPosition(ButtonChiudi, New TableLayoutPanelCellPosition(0, 0))
                'aggiungo il bottone minimizza
                .RowStyles.Add(New RowStyle(SizeType.Absolute, 30))
                .RowCount += 1
                .Controls.Add(ButtonMinimizza)
                .SetCellPosition(ButtonMinimizza, New TableLayoutPanelCellPosition(0, 1))
                'aggiungo il la label di info
                .RowStyles.Add(New RowStyle(SizeType.AutoSize))
                .RowCount += 1
                .Controls.Add(InfoLabel)
                .SetCellPosition(InfoLabel, New TableLayoutPanelCellPosition(0, 2))
            End With

            With Me
                'aggiungo la infotable al menu
                .ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20))
                .ColumnCount += 1
                .Controls.Add(InfoTable)
                .SetRowSpan(InfoTable, 50)

                .ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100%))
                .ColumnCount += 1
            End With
        Else
            Me.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100%))
            Me.ColumnCount = 1
        End If

    End Sub

    Private mViewInfoLabel As Boolean
    Public Property ViewInfoLabel() As Boolean
        Get
            Return mViewInfoLabel
        End Get
        Set(value As Boolean)
            mViewInfoLabel = value
        End Set
    End Property

    Private mInfoLabelText As String
    Public Property InfoLabelText() As String
        Get
            Return mInfoLabelText
        End Get
        Set(value As String)
            mInfoLabelText = value
        End Set
    End Property

    Private mPages As List(Of Page)
    Public Property Pages() As List(Of Page)
        Get
            Return mPages
        End Get
        Set(value As List(Of Page))
            mPages = value
        End Set
    End Property

    Private Shared mButtonPageHeight As Integer
    Public Shared Property ButtonPageHeight() As Integer
        Get
            Return mButtonPageHeight
        End Get
        Set(value As Integer)
            mButtonPageHeight = value
        End Set
    End Property

    Private mPageHeight As Integer
    Public Property PageHeight() As Integer
        Get
            Return mPageHeight
        End Get
        Set(value As Integer)
            mPageHeight = value
        End Set
    End Property

    Private Shared mTrackColor As Color
    Public Shared Property TrackColor() As Color
        Get
            Return mTrackColor
        End Get
        Set(value As Color)
            mTrackColor = value
        End Set
    End Property

    Private mButtonBackColor As Color
    Public Property ButtonBackColor() As Color
        Get
            Return mButtonBackColor
        End Get
        Set(value As Color)
            mButtonBackColor = value
        End Set
    End Property

    Private Shared mButtonPageStyle As PageButton.Style = PageButton.Style.FLAT
    Public Shared Property ButtonPageStyle() As PageButton.Style
        Get
            Return mButtonPageStyle
        End Get
        Set(value As PageButton.Style)
            mButtonPageStyle = value
        End Set
    End Property

    Public Function Pagina(key As String) As Page
        For Each p As Page In mPages
            If p.Key = key Then
                Return p
            End If
        Next
        MsgBox("Il menù richiesto non esiste", MsgBoxStyle.Exclamation, "Attenzione")
        Return Nothing
    End Function

    Public Function AddPage(Text As String,
                            Key As String) As Page

        'controllo che la key non esista già
        For Each pag As Page In mPages

            If pag.BottonePagina.Key = Key Then
                MsgBox(String.Format("Impossibile aggiungere la pagina. La key '{0}' esiste già.", Key),
                       MsgBoxStyle.Exclamation)
                Return Nothing
            End If
        Next

        Page.ButtonPageHeight = mButtonPageHeight
        Page.ButtonPageStyle = mButtonPageStyle
        Page.TrackColor = mTrackColor

        Dim p As New Page(mPages.Count, Text, Key)
        p.BottonePagina.BackColor = mButtonBackColor

        mPages.Add(p)

        With Me
            'imposto lo stile della riga da aggiungere
            .RowStyles.Add(New RowStyle(SizeType.Absolute, mButtonPageHeight))
            'aggiungo la pagina
            .RowCount += 1
            .Controls.Add(p)
            .SetCellPosition(p, New TableLayoutPanelCellPosition(1, .RowCount - 1))
        End With

        AddHandler p.BottonePagina.Click, AddressOf PageButton_Click

        Return p
    End Function

    Public Sub ClickPage(Key As String)
        'ciclo sulla lista delle pagine
        For Each p As Page In mPages
            'quando trovo la chiave
            If p.Key = Key Then
                'richiamo il metodo di quando si clicca una pagina
                PageButton_Click(p.BottonePagina, New EventArgs)
                Exit For
            End If
        Next
    End Sub

    Private Sub InfoLabel_BackColorChanged(sender As Object, e As EventArgs) Handles InfoLabel.BackColorChanged
        ButtonChiudi.BackColor = InfoLabel.BackColor
        ButtonMinimizza.BackColor = InfoLabel.BackColor
    End Sub

    Private Sub InfoLabel_DoubleClick(sender As Object, e As EventArgs) Handles InfoLabel.DoubleClick
        RaiseEvent MinimizzaMenu()
    End Sub

    Private Sub InfoLabel_Paint(sender As Object, e As PaintEventArgs) Handles InfoLabel.Paint
        With e.Graphics
            .TranslateTransform(0, InfoLabel.Height - 10)
            .RotateTransform(270)
            .DrawString(mInfoLabelText, InfoLabel.Font, Brushes.White, 0, 1)
        End With
    End Sub

    Private Sub PageButton_Click(sender As PageButton, e As EventArgs)
        RaiseEvent BeforePageClick(sender.Key, sender.Index)

        Dim rs As RowStyle

        For Each rs In Me.RowStyles
            rs.SizeType = SizeType.Absolute
        Next

        'riporto a normale il font di tutti i bottoni di pagina
        For Each p As Page In Me.Pages
            p.BottonePagina.Font = New Font(sender.Font.Name, sender.Font.Size, FontStyle.Regular)
        Next

        'metto a grassetto il font del bottone della pagina selezionata
        sender.Font = New Font(sender.Font.Name, sender.Font.Size, FontStyle.Bold)

        'recupero il rowstyle del bottone di pagina selezionato
        rs = Me.RowStyles.Item(sender.Index)

        'rendo % il sizetype che permette il riempimento dello spazio libero nel menù
        rs.SizeType = SizeType.Percent
        Me.Refresh() 'refresh prima dell'evento

        RaiseEvent PageClick(sender.Key, sender.Index)
    End Sub

    Private Sub PagesMenu_MenuButtonClick(key As String, Index As Integer) Handles Me.MenuButtonClick
        RaiseEvent MenuButtonClick(key, Index)
    End Sub

    Private Sub ButtonChiudi_Click(sender As Object, e As EventArgs) Handles ButtonChiudi.Click
        RaiseEvent Chiudi()
    End Sub

    Private Sub ButtonMinimizza_Click(sender As Object, e As EventArgs) Handles ButtonMinimizza.Click
        RaiseEvent Minimizza()
    End Sub
End Class
