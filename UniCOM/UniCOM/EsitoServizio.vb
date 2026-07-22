Public Class EsitoServizio

    Public EsitoChiamata As Boolean
    Public Messaggio As String
    Public CodiceErrore As String
    Public MessaggioErrore As String
    Public ValoreRestituiro As Object
    Public IdSending As String
End Class

Public Class EsitoServizioRest
    Public async As Boolean
    Public [error] As Integer
    Public credit As Integer
    Public sending_contacts_count As Integer
    Public sending_batch_id As String
End Class
