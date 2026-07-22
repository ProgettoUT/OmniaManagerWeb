<Serializable()> Public Class Tariffa
    Public Tasso As Decimal = 0
    Public Base As Decimal = 0

    Public Sub AzzeraTariffa()
        Tasso = 0D
        Base = 0D
    End Sub

    Public Function PremioCrudo(SommaAssicurata As Decimal) As Decimal
        'Return Partita.TassoDiPartita * Partita.SommaAssicurata * Tariffa.Tasso + Tariffa.Base
        Return Arrotonda((SommaAssicurata * Tasso + Base))
    End Function

    Public Property TassoX1000() As Decimal
        Get
            Return Tasso * 1000D
        End Get
        Set(value As Decimal)
            Tasso = value / 1000D
        End Set
    End Property
End Class
