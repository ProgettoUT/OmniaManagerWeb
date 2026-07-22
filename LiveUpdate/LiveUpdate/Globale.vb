Imports System.IO

Public Class Globale

    'costanti
    Public Const TitoloDll As String = "Live update"

    Public Structure Ambiente
        Public Shared Tipo As TipoAmbiente = ImpostaAmbiente()
    End Structure

    Public Enum TipoAmbiente
        [DIR] = 0
        [PP] = 1
        [PP2DIR] = 2
    End Enum

    Public Shared Function ImpostaAmbiente() As TipoAmbiente
        Select Case GetEnvironmentVar("UNITOOLS_AMBIENTE")
            Case "DIR" : Return TipoAmbiente.DIR
            Case "PP" : Return TipoAmbiente.PP
            Case "PP2DIR" : Return TipoAmbiente.PP2DIR 'non più attuale
        End Select
    End Function

    Public Shared Function GetEnvironmentVar(VarName As String) As String
        If Environment.GetEnvironmentVariable(VarName) = Nothing Then
            GetEnvironmentVar = ""
        Else
            GetEnvironmentVar = Environment.GetEnvironmentVariable(VarName)
        End If
    End Function
End Class
