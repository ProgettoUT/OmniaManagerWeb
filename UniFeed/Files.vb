Class Files
    Inherits Dictionary(Of String, File)

    Public Function GetFile(sKey As String) As File
        If Not Me.ContainsKey(sKey) Then
            Me.Add(sKey, New File)
        End If
        Return Me(sKey)
    End Function

    Public Function GetFileByPattern(sInFile As String) As File
        Dim i As Integer
        Dim j As Integer
        Dim f As File
        Dim file As File = Nothing
        Dim FilePattern() As String

        sInFile = IO.Path.GetFileName(sInFile)

        For Each f In Me.Values
            FilePattern = Split(f.FilePatterns, ",")
            For i = 0 To UBound(FilePattern)
                If sInFile Like FilePattern(i) Then
                    file = f
                    j = j + 1
                End If
            Next
        Next
        If j <> 1 Then
            file = Nothing
        End If

        Return file
    End Function


End Class
