Public Class PageButton

    Inherits Button

    Public Enum Style
        STANDARD = 0
        FLAT = 1
    End Enum

    Private mDefaultColor As Color

    Sub New(Index As Integer,
            Key As String,
            ButtonStyle As Style)

        mIndex = Index
        mKey = Key
        mTrackColor = Me.ForeColor
        mDefaultColor = Me.ForeColor

        Select Case ButtonStyle

            Case Style.STANDARD

            Case Style.FLAT
                FlatButton(Me)
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

    Private mTrackColor As Color
    Public Property TrackColor() As Color
        Get
            Return mTrackColor
        End Get
        Set(value As Color)
            mTrackColor = value
        End Set
    End Property

    Private Sub PageButton_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter
        Me.ForeColor = mTrackColor
    End Sub

    Private Sub PageButton_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
        Me.ForeColor = mDefaultColor
    End Sub

    Private Sub FlatButton(ByRef Bottone As PageButton)
        With Bottone
            .AutoSize = False
            .TextAlign = ContentAlignment.MiddleCenter
            .Dock = DockStyle.Fill
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.LightGray
            .FlatAppearance.MouseOverBackColor = Color.LightYellow
            .Padding = New Padding(0)
            .Margin = New Padding(0)
            .BackColor = Drawing.SystemColors.Control
        End With
    End Sub
End Class
