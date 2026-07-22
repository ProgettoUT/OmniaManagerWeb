Imports System.IO

Public Class Globale

    'variabili condivise globali
    Public Shared Log As New UtNetUtility.ApplicationLog("NetUtility.log")

#Region "Enumerazioni"

    Public Enum TipoAmbiente
        [DIR] = 0
        [PP] = 1
        [PP2DIR] = 2
    End Enum

#End Region

    Public Shared Function ImpostaAmbiente() As TipoAmbiente

        Select Case UtNetUtility.NetFunc.GetEnvironmentVar("UNITOOLS_AMBIENTE")

            Case "PP"
                Return TipoAmbiente.PP
            Case "PP2DIR"
                Return TipoAmbiente.PP2DIR
            Case Else
                Return TipoAmbiente.DIR
        End Select
    End Function

    Public Shared Function ImpostaDominio() As String
        Return "uniage"
    End Function

    Public Shared Function ImpostaProxy() As System.Net.WebProxy

        Dim Proxy As System.Net.WebProxy

        Try
            If Setting.Ambiente.Tipo = Globale.TipoAmbiente.PP Then
                Return Nothing
            Else
                Proxy = New System.Net.WebProxy("proxyu.ha.servizi.gr-u.it", 80)

                If Setting.Ambiente.Tipo = Globale.TipoAmbiente.DIR Then
                    'e le credenziali di default
                    Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
                Else
                    'e le credenziali utente uniage
                    Proxy.Credentials = New System.Net.NetworkCredential(Setting.Utente.IdUser,
                                                                         Setting.Utente.UniagePw,
                                                                         ImpostaDominio())
                End If

                Return Proxy
            End If

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
            Return Nothing
        End Try

    End Function

End Class
