Public Class Page

    Inherits TableLayoutPanel

    Public Event PageClick(key As String, Index As Integer)
    Public Event MenuButtonClick(key As String, Index As Integer)

    Private WithEvents btnMenu As MenuButton
    Private WithEvents TlpMenu As New TableLayoutPanel

    Sub New(Index As Integer,
            Text As String,
            Key As String)

        'imposto il bottone
        mBottonePagina = New PageButton(Index, Key, mButtonPageStyle)
        mBottonePagina.Text = Text
        mBottonePagina.Height = mButtonPageHeight
        mBottonePagina.TrackColor = mTrackColor

        'inizializzo la lista dei bottoni di questa pagina
        mBottoniMenu = New List(Of MenuButton)

        With Me
            .Dock = DockStyle.Fill
            .CellBorderStyle = TableLayoutPanelCellBorderStyle.None
            .Padding = New Padding(0)
            .Margin = New Padding(0)

            'una sola colonna. imposto lo stile
            .ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100%))
            .ColumnCount = 1

            'bottone della pagina
            'imposto lo stile della riga del bottone di pagina
            .RowStyles.Add(New RowStyle(SizeType.Absolute, mButtonPageHeight))
            'aggiungo il bottone pagina
            .RowCount += 1
            .Controls.Add(mBottonePagina)
            .SetCellPosition(mBottonePagina, New TableLayoutPanelCellPosition(0, 0))

            'tlp per accogliere i bottoni del menù con l'ultima cella in autosize come riempitivo
            TlpMenu.Dock = DockStyle.Fill
            TlpMenu.AutoScroll = True
            TlpMenu.RowStyles.Add(New RowStyle(SizeType.AutoSize))
            TlpMenu.RowCount += 1
            TlpMenu.SetAutoScrollMargin(30, 30)

            'cella vuota per accogliere il tlp con i bottoni del menù
            .RowStyles.Add(New RowStyle(SizeType.Percent, 100%))
            .RowCount += 1
            .Controls.Add(TlpMenu)
            .SetCellPosition(TlpMenu, New TableLayoutPanelCellPosition(0, 1))

            'cella vuota per riempimento dello spazio libero
            .RowStyles.Add(New RowStyle(SizeType.AutoSize))
            .RowCount += 1
        End With
    End Sub

    Private mBottoniMenu As List(Of MenuButton)
    Public Property BottoniMenu() As List(Of MenuButton)
        Get
            Return mBottoniMenu
        End Get
        Set(value As List(Of MenuButton))
            mBottoniMenu = value
        End Set
    End Property

    Private WithEvents mBottonePagina As PageButton
    Public Property BottonePagina() As PageButton
        Get
            Return mBottonePagina
        End Get
        Set(value As PageButton)
            mBottonePagina = value
        End Set
    End Property

    Private mKey As String
    Public ReadOnly Property Key() As String
        Get
            Return mBottonePagina.Key
        End Get
    End Property

    Private mIndex As Integer
    Public ReadOnly Property Index() As Integer
        Get
            Return mBottonePagina.Index
        End Get
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

    Private Shared mButtonMenuBackColor As Color = Color.White
    Public Shared Property ButtonMenuBackColor() As Color
        Get
            Return mButtonMenuBackColor
        End Get
        Set(value As Color)
            mButtonMenuBackColor = value
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

    Private Shared mButtonMenuHeight As Integer
    Public Shared Property ButtonMenuHeight() As Integer
        Get
            Return mButtonMenuHeight
        End Get
        Set(value As Integer)
            mButtonMenuHeight = value
        End Set
    End Property

    Private Shared mButtonMenuStyle As MenuButton.Style = MenuButton.Style.FLAT
    Public Shared Property ButtonMenuStyle() As MenuButton.Style
        Get
            Return mButtonMenuStyle
        End Get
        Set(value As MenuButton.Style)
            mButtonMenuStyle = value
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

    Private Sub mBottonePagina_Click(sender As Object, e As EventArgs) Handles mBottonePagina.Click
        RaiseEvent PageClick(mKey, mIndex)
    End Sub

    Public Function AddButtonMenu(Text As String,
                                  Key As String,
                                  Optional ButtonImage As Image = Nothing) As MenuButton

        'controllo che la key non esista già
        For Each btn As MenuButton In mBottoniMenu

            If btn.Key = Key Then
                MsgBox(String.Format("Impossibile aggiungere il menù. La key '{0}' esiste già.", Key),
                       MsgBoxStyle.Exclamation)
                Return Nothing
            End If
        Next

        'dichiaro e imposto il bottone
        btnMenu = New MenuButton(mBottoniMenu.Count, Key, mButtonMenuStyle)
        With btnMenu
            .Text = String.Format(Text, Environment.NewLine)
            .BackColor = mButtonMenuBackColor
            .Image = ButtonImage
        End With
        'lo aggiungo alla lista
        mBottoniMenu.Add(btnMenu)

        'lo aggiungo all'ultima riga della tlpmenu cambiando sizetype
        With TlpMenu
            With .RowStyles.Item(.RowCount - 1)
                .SizeType = SizeType.Absolute
                .Height = mButtonMenuHeight
            End With

            .SetCellPosition(btnMenu, New TableLayoutPanelCellPosition(0, .RowCount - 1))
            .Controls.Add(btnMenu)

            'aggiungo la riga con autosize come riempitivo
            .RowStyles.Add(New RowStyle(SizeType.AutoSize))
            .RowCount += 1
        End With

        'evento per la pressione del tasto
        AddHandler btnMenu.MenuButtonClick, AddressOf Page_MenuButtonClick

        Return btnMenu

    End Function

    Private Sub Page_MenuButtonClick(key As String, Index As Integer)
        RaiseEvent MenuButtonClick(key, Index)
    End Sub

    Public Function BottoneMenu(key As String) As MenuButton
        For Each b As MenuButton In mBottoniMenu
            If b.Key = key Then
                Return b
            End If
        Next
        Return Nothing
    End Function
End Class
