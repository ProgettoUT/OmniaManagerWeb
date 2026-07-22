Imports System.IO
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports iTextSharp.tool.xml
Imports iTextSharp.text.html.simpleparser
Imports SelectPdf

Public Class Pdf

    'esempio per tabella in itextsharp
    'Public Shared Sub StringToPdf(fileHtml As String, pdfName As String)
    '    'Dummy DataTable
    '    Dim dt As New DataTable()
    '    dt.Columns.AddRange(New DataColumn(2) {New DataColumn("Id", GetType(Integer)), New DataColumn("Name", GetType(String)), New DataColumn("Country", GetType(String))})
    '    dt.Rows.Add(1, "John Hammond", "United States")
    '    dt.Rows.Add(2, "Mudassar Khan", "India")
    '    dt.Rows.Add(3, "Suzanne Mathews", "France")
    '    dt.Rows.Add(4, "Robert Schidner", "Russia")

    '    Dim html As String = String.Empty
    '    html += "<p style='font-family:verdana; font-size:23px; color:#FF0000'>ASPForums.Net Sample</p>"
    '    html += "<br />"

    '    'Creating iTextSharp Table from the DataTable data
    '    Dim pdfTable As New PdfPTable(dt.Columns.Count)
    '    pdfTable.DefaultCell.Padding = 3
    '    pdfTable.WidthPercentage = 30
    '    pdfTable.HorizontalAlignment = Element.ALIGN_LEFT
    '    pdfTable.DefaultCell.BorderWidth = 1

    '    'Adding Header Row
    '    For Each column As DataColumn In dt.Columns
    '        Dim cell As New PdfPCell(New Phrase(column.ColumnName))
    '        pdfTable.AddCell(cell)
    '    Next

    '    'Adding Data Rows
    '    For Each row As DataRow In dt.Rows
    '        For Each column As DataColumn In dt.Columns
    '            pdfTable.AddCell(row(column.ColumnName).ToString())
    '        Next
    '    Next

    '    Using document As New Document(PageSize.A4, 10, 10, 10, 10)
    '        Dim writer As PdfWriter = PdfWriter.GetInstance(document, New FileStream(pdfName, System.IO.FileMode.Create))

    '        document.Open()
    '        document.Add(pdfTable)
    '        document.Close()

    '    End Using
    'End Sub

    'Public Shared Function CreaPdfDaHtml(fileHtml As String, pdfName As String) As Boolean
    '    'con l'uso di itextsharp
    '    Try
    '        Using document As New Document(PageSize.A4, 10, 10, 10, 10)
    '            Dim writer As PdfWriter = PdfWriter.GetInstance(document, New FileStream(pdfName, System.IO.FileMode.Create))

    '            document.Open()
    '            XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, New StreamReader(fileHtml, System.IO.FileMode.Open))
    '            document.Close()

    '            Return True
    '        End Using

    '    Catch ex As Exception
    '        Globale.Log.Errore(ex)
    '        Return False
    '    End Try
    'End Function

    Public Shared Function CreaPdfDaHtml(fileHtml As String, pdfName As String) As Boolean
        Try
            Dim converter As New HtmlToPdf()
            'The margin is specified in points. 1 point is 1/72 inch. 1 inch = 2.54 cm. 30 = circa 1 cm
            With converter.Options
                .PdfPageSize = PdfPageSize.A4
                .MarginTop = 30
                .MarginBottom = 30
                .MarginLeft = 30
                .MarginRight = 30
            End With
            Dim doc As PdfDocument = converter.ConvertHtmlString(File.ReadAllText(fileHtml))

            doc.Save(pdfName)
            doc.Close()

            Return True

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function
End Class
