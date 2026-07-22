Imports System.Net

<Serializable> _
Public Class Proxy
    Private mProxy As System.Net.WebProxy

    Public Sub New()
        Init()
    End Sub

    Private Sub Init()
        If Utx.FunzioniRete.PcInDominio Then
            Globale.Log.Trace(String.Format("Pc in dominio '{0}'", Environment.UserDomainName))
            Try
                'se il pc è in dominio imposto il proxy e incorporo le credenziali
                mProxy = New System.Net.WebProxy(Me.UrlProxy, Me.PortaProxy) With {.Credentials = Credenziali()}
                Globale.Log.Info(String.Format("Proxy: {0}:{1}", Me.UrlProxy, Me.PortaProxy))
            Catch ex As Exception
                mProxy = Nothing
            End Try
        Else
            Globale.Log.Info("Pc non in dominio: nessun proxy")
            mProxy = Nothing
        End If
    End Sub

    Public ReadOnly Property Credenziali() As System.Net.NetworkCredential
        Get
            If Utx.Globale.UtenteCorrente IsNot Nothing Then
                Return New Net.NetworkCredential(Utx.Globale.UtenteCorrente.UniageUser, Utx.Globale.UtenteCorrente.UniagePw, Utx.Globale.UtenteCorrente.Dominio)
            Else
                Return CredentialCache.DefaultCredentials
            End If
        End Get
    End Property

    Public Sub AssegnaCredenziali()
        Try
            'se ho il proxy e non ho le credenziali le imposto
            If mProxy IsNot Nothing Then
                mProxy.Credentials = Credenziali()
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Public ReadOnly Property Proxy() As System.Net.IWebProxy
        Get
            'per debug
            Return mProxy
        End Get
    End Property

    Public Function GetProxy(url As String) As System.Net.IWebProxy
        If url.StartsWith("http://www.utools.it/") Then
            Return mProxy
        Else
            Return Nothing
        End If
    End Function

    Public ReadOnly Property UrlProxy() As String
        Get
            Return "proxyu.ha.servizi.gr-u.it"
        End Get
    End Property

    Public ReadOnly Property PortaProxy() As Integer
        Get
            Return 80
        End Get
    End Property
End Class
