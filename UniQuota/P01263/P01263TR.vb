Namespace P01263
    Public Class P01263TR
        Inherits P00000TR

        Public Enum Colonna
            TassoLight = 0
            TassoBase = 1
            TassoGI = 2
            ImportoGI = 3
            TassoEnergy = 4
        End Enum

        Sub New()
            MyBase.New("P01263TR", 100)
        End Sub

        Public Function getPremio(ByVal eta As Integer, ByVal colonna As Colonna) As Decimal
            'eta: 0-75
            'colonna: vedi sopra

            Dim key As String = "" & eta
            Return CType(getTasso(key, colonna), Decimal)
        End Function
    End Class
End Namespace