Public Class Globale

    'costanti
    Public Const TitoloApp As String = "Unitools - Richieste Consap"

    'variabili condivise globali
    Public Shared Log As New Utx.ApplicationLog("Consap.log")

    Public Shared Delegato As DatiDelega

    Public Shared Function NullToString(Testo As Object) As String
        If IsDBNull(Testo) OrElse (Testo Is Nothing) Then
            Return ""
        Else
            Return Testo
        End If
    End Function

    Public Shared Function NullToDate(Data As Object) As Date
        If IsDate(Data) Then
            Return Data
        Else
            Return ""
        End If
    End Function
End Class
