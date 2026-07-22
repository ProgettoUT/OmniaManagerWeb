Public Class Globale

    Public Const TitoloApp As String = "Gestione buste"

    Public Shared Log As New Utx.ApplicationLog("Adempimenti.log")
    Public Shared MainFont As New Font("Tahoma", 9)

    Public Shared Function GiorniNelMese(DataRiferimento As Date) As Integer
        Return DateTime.DaysInMonth(DataRiferimento.Year, DataRiferimento.Month)
    End Function
End Class
