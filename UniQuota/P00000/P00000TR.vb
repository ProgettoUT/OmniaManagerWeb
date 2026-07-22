Imports System.IO
Imports System.IO.Compression

Public Class P00000TR
    Private KeyToTasso As New Dizionario(Of String, Single())

    Public Function getTasso(ByVal key As String, ByVal indice As Integer) As Single
        If KeyToTasso.ContainsKey(key) Then
            Return KeyToTasso(key)(indice)
        ElseIf KeyToTasso.ContainsKey("99999") Then
            Return KeyToTasso("99999")(indice)
        Else
            Return 0
        End If
    End Function

    Sub New(ByVal tabella As String, ByVal scala As Decimal)
        Dim sourceFile = New MemoryStream(CType(My.Resources.ResourceManager.GetObject(tabella), Byte()))

        Using input As New GZipStream(sourceFile, CompressionMode.Decompress, False)
            Using reader As New StreamReader(input)
                Dim line As String = reader.ReadLine()
                While Not line Is Nothing
                    Dim cols As String() = Split(line, ";")
                    Dim key As String = cols(0)
                    Dim tasso As Single() = New Single(cols.Length - 2) {}

                    For i As Integer = 1 To tasso.Length
                        tasso(i - 1) = Single.Parse(cols(i)) / scala
                    Next

                    Try
                        KeyToTasso.Add(key, tasso)
                    Catch ex As Exception
                        Debug.Print("doppione: " & key)
                    End Try


                    line = reader.ReadLine()
                End While
            End Using
        End Using

        sourceFile.Close()
    End Sub

    'File.WriteAllBytes("C:\Documents and Settings\Pecoraro\Desktop\P04226TR.gz", Compress(File.ReadAllBytes("C:\Documents and Settings\Pecoraro\Desktop\P04226TR.csv")))
    'Function Compress(ByVal raw() As Byte) As Byte()
    '    ' Clean up memory with Using-statements.
    '    Using memory As MemoryStream = New MemoryStream()
    '        ' Create compression stream.
    '        Using gzip As GZipStream = New GZipStream(memory, CompressionMode.Compress, True)
    '            ' Write.
    '            gzip.Write(raw, 0, raw.Length)
    '        End Using
    '        ' Return array.
    '        Return memory.ToArray()
    '    End Using
    'End Function

End Class
