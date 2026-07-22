Imports System.IO

Public Class WsFlag
#Region "Flag"
    Public Shared Function EliminaFlag(CodiceAgenzia As String, TipoFlag As String) As Boolean
        Try
            Using s As New Utx.SettingFlag.SettingFlag
                s.Proxy = Utx.Globale.UniProxy.Proxy
                s.EliminaFlag(CodiceAgenzia, TipoFlag, Utx.Globale.Token)
            End Using
            Return True
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Shared Function EsisteFlag(CodiceAgenzia As String, Tipo As String) As Boolean
        Try
            Using s As New Utx.SettingFlag.SettingFlag
                s.Proxy = Utx.Globale.UniProxy.Proxy
                Dim Risposta As Utx.SettingFlag.Dati = s.EsisteFlag(CodiceAgenzia, Tipo, Utx.Globale.Token)
                Return Risposta.Esiste
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Shared Function CreaFlag(CodiceAgenzia As String, Utente As String, Tipo As String, Descrizione As String) As Boolean
        Try
            Using s As New Utx.SettingFlag.SettingFlag
                s.Proxy = Utx.Globale.UniProxy.Proxy
                s.CreaFlag(CodiceAgenzia, Utente, Tipo, Descrizione, Utx.Globale.Token)
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Function
#End Region

#Region "Chiavi"
    Public Shared Function LeggiChiaveInterop(Chiave As String, Optional Agenzia As String = "") As String
        Try
            If String.IsNullOrEmpty(Agenzia) Then Agenzia = Utx.Globale.AgenziaRichiesta.CodiceAgenzia

            Using s As New Utx.SettingFlag.SettingFlag
                s.Proxy = Utx.Globale.UniProxy.Proxy
                Return s.ValoreChiaveInterop(Agenzia, Chiave, Utx.Globale.Token)
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Public Shared Function SalvaChiaveInterop(Chiave As String, Valore As String, Optional Agenzia As String = "") As Boolean
        Try
            If String.IsNullOrEmpty(Agenzia) Then Agenzia = Utx.Globale.AgenziaRichiesta.CodiceAgenzia

            Using s As New Utx.SettingFlag.SettingFlag
                s.Proxy = Utx.Globale.UniProxy.Proxy
                Return s.SalvaChiaveInterop(Agenzia, Chiave, Valore, Utx.Globale.Token)
            End Using
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return False
        End Try
    End Function
#End Region

    Public Shared Function WsBudget() As Utx.BudgetOMW.ServizioBudget
        Return New Utx.BudgetOMW.ServizioBudget With {.Proxy = Utx.Globale.UniProxy.Proxy}
    End Function
End Class
