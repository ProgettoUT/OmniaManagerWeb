Imports System.IO
Imports System.Drawing

Module Funzioni

    Public Function GetEnvironmentVar(VarName As String,
                                      Optional ValoreDefault As String = "") As String
        If Environment.GetEnvironmentVariable(VarName) Is Nothing Then
            GetEnvironmentVar = ValoreDefault
        Else
            GetEnvironmentVar = Environment.GetEnvironmentVariable(VarName)
        End If
    End Function

    Public Function ExistEnvironmentVar(VarName As String) As Boolean
        Return (Environment.GetEnvironmentVariable(VarName) IsNot Nothing)
    End Function

    Public Function SessioneRDP() As Boolean
        On Error Resume Next
        SessioneRDP = GetEnvironmentVar("SESSIONNAME").StartsWith("RDP-TCP", StringComparison.InvariantCultureIgnoreCase)
    End Function

    Public Function NumeroSottoCartelle(PathCartella As String) As Integer
        Return My.Computer.FileSystem.GetDirectories(PathCartella).Count()
    End Function

    Public Function NumeroFileCartella(PathCartella As String) As Integer
        Return My.Computer.FileSystem.GetFiles(PathCartella).Count()
    End Function

    Public Function NumeroOggettiCartella(PathCartella As String) As Integer
        Return NumeroFileCartella(PathCartella) + NumeroSottoCartelle(PathCartella)
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
