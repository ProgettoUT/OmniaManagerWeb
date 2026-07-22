Namespace P01262
    Public Class P01262TR
        Inherits P00000TR

        Sub New()
            MyBase.New("P01262TR", 100)
        End Sub

        Public Function getPremio(ByVal eta As Integer, ByVal combinazione As Decimal, ByVal ZonaTerritoriale As ZonaTerritorialeEnum, ByVal garanzia As TipoGaranzia) As Decimal
            'eta: 0-99
            'zona: 0-Resto di Italia, 1-Roma e relative province, 2-Milano - Torino - Genova e relative province
            'Combinazione: 1-4
            'garanzia: MalattiaRicovero, MalattiaGicGem, MalattiaSupplementari

            Dim key As String = "" & eta
            Dim ind As Integer = 0

            Select Case garanzia
                Case TipoGaranzia.MalattiaRicovero : ind = 3 * (CInt(combinazione) - 1)
                Case TipoGaranzia.MalattiaGicGem : ind = 12
                Case TipoGaranzia.MalattiaSupplementari : ind = 15
            End Select

            ind += ZonaTerritoriale

            Return CType(getTasso(key, ind), Decimal)
        End Function
    End Class
End Namespace