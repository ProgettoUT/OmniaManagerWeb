Public Class CProfili
    Inherits Dictionary(Of String, CProfilo)

    Public Function Exists(sKey As String) As Boolean
        Return Me.ContainsKey(sKey)
    End Function

    Public Function GetProfilo(sKey As String) As CProfilo
        sKey = sKey.ToUpper()

        If (Me.ContainsKey(sKey)) Then
            Return Me(sKey)
        Else
            Dim profilo As New CProfilo
            profilo.Nome = sKey
            Add(sKey, profilo)
            Return profilo
        End If

    End Function

End Class
