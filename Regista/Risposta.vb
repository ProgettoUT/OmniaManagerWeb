Public Class Risposta
    Private a As New Text.StringBuilder()
    Public RawData As String

    Public Function WriteLine() As Risposta
        a.AppendLine()
        Return Me
    End Function

    Public Function WriteLine(line As String) As Risposta
        a.AppendLine(line)
        Return Me
    End Function

    Public Function EndWrite() As Risposta
        RawData = a.ToString()
        Return Me
    End Function

    Public Function RispondiOK(Optional contenuto As String = Nothing) As Risposta
        WriteLine("HTTP/1.1 200 OK")
        If contenuto Is Nothing Then
            WriteLine()
            WriteLine()
        Else
            WriteLine("Content-Length:" & contenuto.Length)
            WriteLine("Content-Type:text/html")
            WriteLine("Connection:close")
            WriteLine()
            WriteLine(contenuto)
        End If
        EndWrite()

        Return Me
    End Function

End Class
