Public Class Globale
    'in bridgecom

    'variabili globali
    Public Shared Log As Utx.ApplicationLog
    Public Shared FunzioneRichiesta As Integer

    Public Enum FunzioniDisponibili
        InviaSmsLista = 0
        InviaSmsSingolo = 4
        InviaEmailSenzaInterfaccia = 6
        InviaSmsSenzaInterfaccia = 7
    End Enum

    Public Shared Function LeggiImpostazioniGlobali() As Boolean
        Try
            FunzioneRichiesta = Utx.NetFunc.GetEnvironmentVar("UNITOOLS_COM2_FUNZIONE")
            Return True
        Catch ex As Exception
            Log.Errore(ex)
            Return False
        End Try
    End Function
End Class
