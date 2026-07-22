Module Funzioni

    Public Function GetEnvironmentVar(VarName As String) As String
        If Environment.GetEnvironmentVariable(VarName) Is Nothing Then
            GetEnvironmentVar = ""
        Else
            GetEnvironmentVar = Environment.GetEnvironmentVariable(VarName)
        End If
    End Function

    Public Function ExistEnvironmentVar(VarName As String) As Boolean
        Return (Environment.GetEnvironmentVariable(VarName) IsNot Nothing)
    End Function

    Public Function ColoreChiaroScuro(Valore As Integer) As Color

        Try
            Dim x As Integer = Math.Max(180 - ((Valore / 100) * 255), 0)

            Return Color.FromArgb(x, x, x)

        Catch ex As Exception
            Return Color.Black
        End Try

    End Function

End Module
