Namespace P01261
    Public Class P01261TR
        Inherits P00000TR

        Sub New()
            MyBase.New("P01261TR", 10000000)
        End Sub

        Public Function getPremio(ByVal eta As Integer, CriterioLiquidazioneIPM As CriterioLiquidazioneIPMEnum, ByVal SommaAssicurato As Decimal) As Decimal
            'eta: 0-64

            Dim key As String = "" & eta
            Dim ind As Integer = 0

            If CriterioLiquidazioneIPM = CriterioLiquidazioneIPMEnum.Tabella2 Then
                ind += 2
            End If
            If SommaAssicurato > 250000D Then
                ind += 1
            End If

            Return CType(getTasso(key, ind), Decimal)
        End Function
    End Class
End Namespace