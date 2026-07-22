Imports System.Windows.Forms

Public Class TabLog

    Dim Pagina As New TabPage
    Dim TextBoxLog As New TextBox

    Sub New()

        Pagina.Name = "Log"
        Pagina.Text = Pagina.Name
        Pagina.Controls.Add(TextBoxLog)

        With TextBoxLog
            .Dock = DockStyle.Fill
            .BackColor = Drawing.Color.White
            .Multiline = True
            .ReadOnly = True
            .WordWrap = False
            .ScrollBars = ScrollBars.Both
            .Font = New System.Drawing.Font("Arial monospaced for SAP", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

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
