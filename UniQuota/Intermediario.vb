<Serializable()> Public Class Intermediario
    Public CodiceFiscale As String
    Public Nominativo As String
    Public NumeroIscrizioneIsvap As String
    Public Ruolo As String

    Public SoggettoCodiceFiscale As String
    Public SoggettoNominativo As String

    Public Overrides Function ToString() As String
        Return Nominativo
    End Function
End Class
