Public Class CParametri
    Inherits Dictionary(Of String, CParametro)

    Public Function Exists(sKey As String) As Boolean
        Return Me.ContainsKey(sKey)
    End Function

    Public Function ReplaceParam(sql As String) As String

        For Each p As CParametro In Me.Values
            sql = Replace(sql, p.Nome, p.ReplaceParam())
        Next

        Return sql
    End Function
End Class
