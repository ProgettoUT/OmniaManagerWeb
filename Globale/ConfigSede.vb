
Public Class ConfigSede

    Dim Log As New ApplicationLog("Utx.ConfigSede.log")
    Dim mErrore As Boolean

    Sub New()
    End Sub

    Public ReadOnly Property ConfigAgenzia(Compagnia As Integer,
                                           Agenzia As String,
                                           Sede As String) As DataTable
        Get
            Try
                Using WsSetting As New SettingAgenzia.ConfiguraSede
                    'assegno il timeout, il proxy e le credenziali
                    WsSetting.Timeout = 30000
                    WsSetting.Proxy = Utx.Globale.UniProxy.Proxy
                    'ricevo la configurazione dal server
                    Dim ds As DataSet = WsSetting.ConfigAgenzia(Compagnia, Agenzia, Sede)

                    'nel caso in cui la configurazione non viene trovata sul server
                    If ds Is Nothing Then
                        Throw New Exception("Impossibile contattare il server per la configurazione d'agenzia.")
                    Else
                        Return ds.Tables("Config")
                    End If
                End Using

            Catch ex As Exception
                MsgBox(String.Format("Il server non risponde.{0}Impossibile verificare la configurazione dell'agenzia.{0}{0}Riprovate fra qualche minuto.",
                                     Environment.NewLine), MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Log.Info(ex)
                Return New DataTable("Config")
            End Try
        End Get
    End Property

    Public ReadOnly Property AgenzieCollegate() As DataTable
        Get
            Try
                Using WsSetting As New SettingAgenzia.ConfiguraSede
                    'assegno il timeout, il proxy e le credenziali
                    WsSetting.Timeout = 30000
                    WsSetting.Proxy = Utx.Globale.UniProxy.Proxy
                    'i parametri li prendo dal profilo
                    Return WsSetting.TabellaAgenzieCollegate(Globale.ProfiloEnteGestore.Compagnia,
                                                             Globale.ProfiloEnteGestore.AgenziaMadre,
                                                             Globale.ProfiloEnteGestore.CodiceSede).Tables("AgenzieCollegate")
                End Using

            Catch ex As Exception
                Log.Errore(ex)
                Return New DataTable("AgenzieCollegate")
            End Try
        End Get
    End Property

    Public ReadOnly Property StringaAgenzieCollegate() As String
        Get
            Try
                Using WsSetting As New SettingAgenzia.ConfiguraSede
                    'assegno il timeout, il proxy e le credenziali
                    WsSetting.Timeout = 30000
                    WsSetting.Proxy = Utx.Globale.UniProxy.Proxy
                    'i parametri li prendo dal profilo
                    Return WsSetting.AgenzieCollegate(Globale.ProfiloEnteGestore.Compagnia,
                                                      Globale.ProfiloEnteGestore.AgenziaMadre,
                                                      Globale.ProfiloEnteGestore.CodiceSede)
                End Using

            Catch ex As Exception
                Log.Errore(ex)
                Return Globale.ProfiloEnteGestore.AgenziaMadre
            End Try
        End Get
    End Property
End Class
