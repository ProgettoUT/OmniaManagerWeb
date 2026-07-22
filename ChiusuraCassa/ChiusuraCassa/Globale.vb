Public Class Globale

    Friend Const TitoloApp As String = "Chiusura cassa"
    Friend Const FValuta = "###,##0.00"
    Friend Shared Log As New Utx.ApplicationLog("ChiusuraCassa.log")

    Public Enum TipoAmbiente
        DIR = 1
        PP = 2
        PP2DIR = 3
    End Enum

    Friend Enum TipoRecord
        Essig = 0
        Riporto = 1
        Prelievi = 2
        Versamenti = 3
        Chiusura = 4
        Abbuono = 5
        Ammanco = 6
        MovimentoGenerico = 9
    End Enum
End Class
