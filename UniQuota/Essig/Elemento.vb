Namespace Essig

    Public Class Elemento
        Public Codice As String
        Public Descrizione As String
        Public Extra1 As String
        Public Extra2 As String

        Public Overrides Function ToString() As String
            Return codice & " " & descrizione
        End Function

        Public Sub New()

        End Sub

        Public Sub New(codice As String, descrizione As String)
            Me.Codice = codice
            Me.Descrizione = descrizione
        End Sub

        Public Sub New(riga() As String)
            Codice = riga(0)
            If riga.Length > 0 Then Descrizione = riga(1)
            If riga.Length > 1 Then Extra1 = riga(2)
            If riga.Length > 2 Then Extra2 = riga(3)
        End Sub
    End Class
End Namespace
