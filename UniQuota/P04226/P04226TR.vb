Namespace P04226
    Public Class P04226TR
        Inherits P00000TR

        Sub New()
            MyBase.New("P04226TR", 1000000) '18
        End Sub

        Public Overloads Function getTassoTerremoto(ByVal codiceIstat As Integer, ByVal franchigia As Decimal, ByVal limite As Decimal, ByVal CaratteristicaCostruttiva As Integer) As Single
            Dim indice As Integer = 0
            If franchigia = 30000 Then
                indice = 6
            ElseIf franchigia = 50000 Then
                indice = 12
            End If
            If limite = 50 Then indice += 3

            ' 1 = antisismica, 2 = Tradizionale, 3 = Muratura
            indice += (CaratteristicaCostruttiva - 1)

            Return getTasso(codiceIstat, indice)
        End Function
    End Class
End Namespace
