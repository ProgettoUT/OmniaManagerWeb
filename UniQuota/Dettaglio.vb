Public Class Dettaglio
    Dim row As Integer = 0
    Dim rows() As String
    Dim myFont As New Font("Courier New", 8.5)

    Private Sub cmdStampa_Click(sender As Object, e As EventArgs) Handles cmdStampa.Click
        rows = txtDettaglio.Text.Split(vbNewLine)
        row = 0
        Dim prn As New Printing.PrintDocument
        Using (prn)
            'prn.PrinterSettings.PrinterName = printer
            AddHandler prn.PrintPage, AddressOf Me.PrintPageHandler
            prn.Print()
            RemoveHandler prn.PrintPage, AddressOf Me.PrintPageHandler
        End Using
    End Sub

    Private Sub PrintPageHandler(ByVal sender As Object, ByVal args As Printing.PrintPageEventArgs)
        Dim testo As New System.Text.StringBuilder

        While (row < rows.Length)
            testo.Append(rows(row))
            row += 1
            If row Mod 80 = 79 Then
                args.HasMorePages = True
                Exit While
            End If
        End While
        args.Graphics.DrawString(testo.ToString, New Font(myFont, FontStyle.Regular), Brushes.Black, 50, 50)
    End Sub

End Class