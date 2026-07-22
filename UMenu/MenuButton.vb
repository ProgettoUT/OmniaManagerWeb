Public Class MenuButton

    Inherits Button

    Public Event MenuButtonClick(key As String, Index As Integer)

    Public Enum Style
        STANDARD = 0
        FLAT = 1
    End Enum

    Sub New(Index As Integer,
            Key As String,
            Optional Style As Style = Style.STANDARD)

        mIndex = Index
        mKey = Key

        Select Case Style
            Case MenuButton.Style.STANDARD
                Standard(Me)
            Case MenuButton.Style.FLAT
                Flat(Me)
        End Select
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

    Private mIndex As Integer
    Public Property Index() As Integer
        Get
            Return mIndex
        End Get
        Set(value As Integer)
            mIndex = value
        End Set
    End Property

    Public WriteOnly Property ToolTip() As String
        Set(value As String)
            Call New ToolTip().SetToolTip(Me, value)
        End Set
    End Property

    Public WriteOnly Property Testo() As String
        Set(value As String)
            Me.Text = String.Format(value, Environment.NewLine)
        End Set
    End Property

    Private Sub Flat(ByRef Button As MenuButton)
        With Button
            .AutoSize = False
            .TextAlign = ContentAlignment.MiddleRight
            .ImageAlign = ContentAlignment.MiddleLeft
            .Dock = DockStyle.Fill
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
            .FlatAppearance.MouseOverBackColor = Color.Moccasin
            .Padding = New Padding(0)
            .Margin = New Padding(0)
        End With
    End Sub

    Private Sub Standard(ByRef Button As MenuButton)
        With Button
            .AutoSize = False
            .TextAlign = ContentAlignment.MiddleLeft
            .Dock = DockStyle.Fill
        End With
    End Sub

    Private Sub MenuButton_Click(sender As Object, e As EventArgs) Handles Me.Click
        RaiseEvent MenuButtonClick(Me.mKey, Me.mIndex)
    End Sub
End Class
