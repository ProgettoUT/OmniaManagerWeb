Public Class TabLog

    Dim Pagina As New TabPage
    Dim TextBoxLog As New TextBox

    Sub New(Agenzia As String)

        Pagina.Name = String.Format("Log {0}", Agenzia)
        Pagina.Text = Pagina.Name
        Pagina.Controls.Add(TextBoxLog)

        With TextBoxLog
            .Dock = DockStyle.Fill
            .BackColor = Color.White
            .Multiline = True
            .ReadOnly = True
            .WordWrap = False
            .ScrollBars = ScrollBars.Both
            'leggo il contenuto del log nel textbox
            .Text = System.IO.File.ReadAllText(Globale.Log.LogFile)
        End With
    End Sub

    Public ReadOnly Property NotificaLog() As TabPage
        Get
            Return Pagina
        End Get
    End Property
End Class
