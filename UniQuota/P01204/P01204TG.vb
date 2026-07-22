Namespace P01204
    Public Class P01204TG
        Shared Attivita As Dictionary(Of Integer, Attivita)

        Public Shared Function GetAttivita() As Dictionary(Of Integer, Attivita)
            If attivita Is Nothing Then
                attivita = New Dictionary(Of Integer, Attivita)
                For Each row As String() In P00000TG.getTable("P01204TG")
                    Dim a = New Attivita(row)
                    attivita.Add(a.Codice, a)
                Next
            End If

            Return attivita
        End Function
    End Class

    Public Class Attivita
        Public Codice As Integer
        Public Descrizione As String
        Public ClasseRischio As RischioProfessionaleEnum
        Public PerDipendenti As Boolean
        Public PerProfessionisti As Boolean
        Public PerNonLavoratori As Boolean
        Public RiservatoDirezione As Boolean

        Public Sub New(cols As String())
            Codice = Integer.Parse(cols(0))
            ClasseRischio = Integer.Parse(cols(2))
            Descrizione = cols(1) & " (classe " & "ABCD".Substring(ClasseRischio - 1, 1) & ")"
            PerDipendenti = (cols(3) = "1")
            PerProfessionisti = (cols(4) = "1")
            PerNonLavoratori = (cols(5) = "1")
            RiservatoDirezione = (cols(6) = "1")
        End Sub

        Public Overrides Function ToString() As String
            Return Codice & " " & Descrizione
        End Function
    End Class
End Namespace