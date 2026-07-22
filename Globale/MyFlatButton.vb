Imports System.Windows.Forms

Public Class MyFlatButton

    Inherits Button

    Sub New()

        With Me
            .Margin = New Padding(0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Drawing.Color.Gainsboro
            .Dock = DockStyle.Fill
        End With
    End Sub
End Class
