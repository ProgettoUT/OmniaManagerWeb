Namespace P07260
    Public Class P07260TR
        Inherits P00000TR

        Sub New()
            MyBase.New("P07260TR", 1000000) '12
        End Sub

        Public Overloads Function getTassoTerremoto(ByVal codiceIstat As Integer, ByVal combinazione As Integer, ByVal limite As Decimal, ByVal CaratteristicaCostruttiva As Integer) As Single
            Dim indice As Integer = 0

            'combinazione
            '0=Antisismico: Sc. 5% SA min. 15.000 max 30.000, NonAntisism: Sc. 10% SA min. 25.000 max 50.000
            '1=Antisismico: Sc. 3% SA, NonAntisism: Sc. 5% SA
            '2=Antisismico: Franchigia 150.000, NonAntisism: Franchigia 250.000
            indice = combinazione * 4

            If limite = 50 Then indice += 2

            ' 1 = antisismica, 2 = non antisismica
            indice += (CaratteristicaCostruttiva - 1)

            Return getTasso(codiceIstat, indice)
        End Function
    End Class
End Namespace
