Imports System.Text

Public Class TString
    Dim ClasseDrv As New StringBuilder

    Public Function Add(riga As String) As TString
        ClasseDrv.AppendLine(riga)
        Return Me
    End Function

    Public Function Add(riga As String, arg0 As Object) As TString
        ClasseDrv.AppendFormat(riga, arg0).AppendLine()
        Return Me
    End Function

    Public Function Add(riga As String, arg0 As Object, arg1 As Object) As TString
        ClasseDrv.AppendFormat(riga, arg0, arg1).AppendLine()
        Return Me
    End Function

    Public Function Add(riga As String, arg0 As Object, arg1 As Object, arg2 As Object) As TString
        ClasseDrv.AppendFormat(riga, arg0, arg1, arg2).AppendLine()
        Return Me
    End Function

    Public Overrides Function ToString() As String
        Return ClasseDrv.ToString()
    End Function
End Class
