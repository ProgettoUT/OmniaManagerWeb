Namespace P07261
    Public Class P07261TR
        Inherits P00000TR

        Sub New()
            MyBase.New("P07261TR", 1000000) '9
        End Sub

        Public Overloads Function getTassoTerremoto(ByVal codiceIstat As Integer, ByVal limite As Decimal, ByVal CaratteristicaCostruttiva As Integer) As Single
            If CaratteristicaCostruttiva = CaratteristicaCostruttivaEnum.NonSelected Then Return 0D

            Dim indice As Integer = 0
            If limite = 50 Then
                indice = 0
            ElseIf limite = 70 Then
                indice = 3
            Else
                indice = 6
            End If

            ' 1 = antisismica, 2 = Armato/Tradizionale, 3 = Muratura
            indice += (CaratteristicaCostruttiva - 1)

            Return getTasso(codiceIstat, indice)
        End Function
    End Class
End Namespace
