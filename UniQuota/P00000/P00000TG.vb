Imports System.IO
Imports System.IO.Compression

Public Class P00000TG
    Public Shared Function getTable(ByVal tabella As String) As List(Of String())
        Dim rows As New List(Of String())
        Dim sourceFile = New MemoryStream(CType(My.Resources.ResourceManager.GetObject(tabella), Byte()))

        Using input As New GZipStream(sourceFile, CompressionMode.Decompress, False)
            Using reader As New StreamReader(input)
                Dim line As String = reader.ReadLine()
                While Not line Is Nothing
                    Dim cols As String() = Split(line, ";")
                    rows.Add(cols)
                    line = reader.ReadLine()
                End While
            End Using
        End Using

        sourceFile.Close()
        Return rows
    End Function
End Class
