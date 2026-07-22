Public Class user
    Public Property id As String
    Public Property username As String
    Public Property password As String
End Class

Public Class wallet
    Public Property amount As Decimal
    Public Property user As user
    Public Property [me] As Boolean
End Class

Public Class credito
    Public Property count As Integer
    Public Property wallets As List(Of wallet)
End Class

Public Class TransazioneCredito
    Public Enum TipoTransazione
        ADD
        SUBTRACT
    End Enum

    Public Property data As New Ricarica

    Sub New()
    End Sub

    Sub New(importo As Decimal)
        data.value = importo
    End Sub

    Sub New(importo As Decimal, tipo As String)
        data.value = importo
        data.type = tipo.ToLower
    End Sub
End Class

Public Class TransazioneSubAccount
    Public Property data As New DatiSubAccount
End Class

Public Class Ricarica
    Public Property value As Decimal
    Public Property type As String = "add" 'add oppure subtract
    Public Property sms_cost As Decimal = 0.1
End Class

Public Class EsitoRicarica
    Public Property updated
    Public Property wallet
End Class

Public Class DatiSubAccount
    Public Property username As String
    Public Property password As String
    Public Property email As String
    Public Property lastname As String = ""
End Class
Public Class EsitoCreazioneSubAccount
    Public Property created As Boolean
    Public Property id As String
End Class

Public Class subaccount

    Public Property id As String
    Public Property user As String
    Public Property password As String
    Public Property email As String
    Public Property gender As String
    Public Property lastname As String = ""
    Public Property firstname As String = ""
    Public Property date_born As Date
    Public Property wallet As Decimal
    Public Property created As Date
    Public Property modified As Date
End Class

Public Class ListaNotifiche
    Public Property count As Integer
    Public Property limit As Integer
    Public Property offset As Integer
    Public Property deliveries As New List(Of delivery)

    Public Shared Sub Merge(Origine As ListaNotifiche, Destinazione As ListaNotifiche)
        Try
            For Each d As delivery In Origine.deliveries
                Select Case d.delivery_status
                    Case delivery.Status.DELIVERED.ToString
                        Destinazione.deliveries.Add(d)
                    Case delivery.Status.NOT_DELIVERED.ToString
                        Destinazione.deliveries.Add(d)
                    Case Else
                        'non fare niente
                End Select
            Next
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub
End Class

Public Class delivery
    Public Enum Status
        DELIVERED
        NOT_DELIVERED
        LOST_NOTIFICATION
        BUFFERED
        [ERROR]
        UNKNOWN
        SUBSCRIBER_UNKNOWN
    End Enum

    Public Property user_id As String
    Public Property queue_id As String
    Public Property sender As String
    Public Property receiver As String
    Public Property delivery_date As String
    Public Property delivery_status As String
    Public Property reason_code As String
End Class
