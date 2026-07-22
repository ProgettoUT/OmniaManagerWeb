<Serializable()> Public Class Subagenzia
    Public Codice As String
    Public Denominazione As String

    Public Overrides Function ToString() As String
        Return Codice & " " & Denominazione
    End Function
End Class
