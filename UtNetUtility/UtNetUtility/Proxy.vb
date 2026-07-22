Imports System.Net

Public Class Proxy
    Private mProxy As System.Net.WebProxy

    Public Sub New()
        Init()
    End Sub

    Private Sub Init()
        If NetFunc.PcInDominio Then
            Globale.Log.AddLog(String.Format("Pc in dominio '{0}'", Environment.UserDomainName))
            Try
                'se il pc è in dominio imposto il proxy e incorporo le credenziali
                mProxy = New System.Net.WebProxy(Me.UrlProxy, Me.PortaProxy)
                Globale.Log.AddLog(String.Format("Proxy: {0}:{1}", Me.UrlProxy, Me.PortaProxy))
            Catch ex As Exception
                mProxy = Nothing
            End Try
        Else
            Globale.Log.AddLog("Pc non in dominio: nessun proxy")
            mProxy = Nothing
        End If
    End Sub

    Public Sub AssegnaCredenziali(User As String, Pw As String)
        Try
            If mProxy IsNot Nothing Then
                'se ho il proxy e non ho le credenziali
                mProxy.Credentials = New Net.NetworkCredential(User, Pw, "uniage")
            End If
        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
        End Try
    End Sub

    Public ReadOnly Property Proxy() As System.Net.IWebProxy
        Get
            Return mProxy
        End Get
    End Property

    Public Function GetProxy(ByVal url As String) As System.Net.IWebProxy
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
