Public Class Indirizzo
    Public Indirizzo As String
    Public Cap As String
    Public Localita As String
    Public Provincia As String

    Public Sub New(indirizzo As String, cap As String, localita As String, provincia As String)
        Me.Indirizzo = Trim(indirizzo)
        Me.Cap = Trim(cap)
        Me.Localita = Trim(localita)
        Me.Provincia = Trim(provincia)
    End Sub

    Public Overrides Function ToString() As String
        If String.IsNullOrEmpty(Indirizzo) Then
            Return Cap & " - " & Localita & " - " & Provincia
        Else
            Return Indirizzo & " - " & Cap & " - " & Localita & " - " & Provincia
        End If
    End Function

End Class
