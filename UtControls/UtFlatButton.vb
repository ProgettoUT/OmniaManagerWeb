Imports System.Windows.Forms
Imports System.Drawing

Public Class UtFlatButton

    Inherits Button

    Sub New()

        mDefaultBorderSize = 0

        With Me
            .Margin = New Padding(0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = mDefaultBorderSize
            .FlatAppearance.BorderColor = Color.Gainsboro
            .FlatAppearance.MouseDownBackColor = Color.Moccasin
            .Text = ""
            .TextAlign = ContentAlignment.MiddleCenter
            .ImageAlign = ContentAlignment.MiddleCenter
        End With
    End Sub

    Private mDefaultBorderSize As Integer
    Public Property DefaultBorderSize() As Integer
        Get
            Return mDefaultBorderSize
        End Get
        Set(value As Integer)
            mDefaultBorderSize = value
            Me.FlatAppearance.BorderSize = mDefaultBorderSize
        End Set
    End Property

    Public Sub SetToolTip(Optional Tip As String = "")
        Dim tt As New ToolTip
        tt.SetToolTip(Me, Tip)
    End Sub

    Private Sub UtFlatButton_MouseHover(sender As Object, e As EventArgs) Handles Me.MouseHover
        Me.FlatAppearance.BorderSize = 1
    End Sub

    Private Sub UtFlatButton_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
        Me.FlatAppearance.BorderSize = mDefaultBorderSize
    End Sub
End Class
