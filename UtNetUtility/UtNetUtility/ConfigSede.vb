Imports System.Data.OleDb

Public Class ConfigSede

    Dim Log As New ApplicationLog("UtNetUtility.ConfigSede.log")
    Dim Utente As UtNetUtility.ProfiloUtente
    Dim mErrore As Boolean
    Dim mIdAmbiente As Globale.TipoAmbiente
    Dim mUserUniage As String
    Dim mPwUniage As String

    Sub New(ByVal IdAmbiente As Globale.TipoAmbiente,
            ByVal UserUniage As String,
            ByVal PwUniage As String,
            ByVal ConnessioneDbLink As String)

        Try
            Using c As New OleDbConnection(ConnessioneDbLink)
                c.Open()
                Utente = New UtNetUtility.ProfiloUtente(c)
            End Using

            mIdAmbiente = IdAmbiente
            mUserUniage = UserUniage
            mPwUniage = PwUniage

        Catch ex As Exception
            Log.BoxErrore(ex)
        End Try

    End Sub

    Private Function Key() As String
        Return String.Format("UT-{0}", Format(Now, "ddMMHH"))
    End Function

    Public ReadOnly Property ConfigAgenzia(ByVal Compagnia As Integer,
                                           ByVal Agenzia As String,
                                           ByVal Sede As String) As DataTable
        Get
            Dim ds As DataSet

            Try
                Using WsSetting As New SettingAgenzia.ConfiguraSede

                    With WsSetting
                        'assegno il timeout, il proxy e le credenziali
                        .Timeout = 30000

                        If mIdAmbiente <> Globale.TipoAmbiente.PP Then
                            .Proxy = NetFunc.ImpostaProxy()
                            .Proxy.Credentials = NetFunc.ImpostaCredenziali(mUserUniage, mPwUniage, mIdAmbiente)
                        End If
                    End With

                    ds = WsSetting.ConfigAgenzia(Compagnia, Agenzia, Sede)
                End Using

                'nel caso in cui la configurazione non viene trovata sul server
                If ds Is Nothing Then
                    Return New DataTable("Config")
                Else
                    Return ds.Tables("Config")
                End If

            Catch ex As Exception
                Log.BoxErrore(ex)
                Return New DataTable("Config")
            End Try
        End Get
    End Property

    Public ReadOnly Property AgenzieCollegate() As DataTable
        Get
            Try
                Using WsSetting As New SettingAgenzia.ConfiguraSede

                    With WsSetting
                        'assegno il timeout, il proxy e le credenziali
                        .Timeout = 60000

                        If mIdAmbiente <> Globale.TipoAmbiente.PP Then
                            .Proxy = NetFunc.ImpostaProxy()
                            .Proxy.Credentials = NetFunc.ImpostaCredenziali(mUserUniage, mPwUniage, mIdAmbiente)
                        End If

                        'i parametri li prendo dal profilo
                        Return .TabellaAgenzieCollegate(Utente.Compagnia,
                                                        Utente.Agenzia,
                                                        Utente.Sede).Tables("AgenzieCollegate")
                    End With
                End Using

            Catch ex As Exception
                Log.BoxErrore(ex)
                Return New DataTable("AgenzieCollegate")
            End Try
        End Get
    End Property

End Class
