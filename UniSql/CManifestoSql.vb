Public Class CManifestoSql
    Inherits CManifesto
    Implements ICriterio, IProfilatore

    Private mCriterio As New CCriterio
    Private mProfilatore As New CProfilatore

    Public Overrides Function Save() As Boolean
        Return True
    End Function
    Public Overrides Function Clone() As CManifesto
        Return Nothing
    End Function
    Public Overrides Function Rename(NewName As String) As Boolean
        Return True
    End Function

    Public Property Sql() As String

    Public Function GetSql(Optional askParamIfrunTime As Boolean = True) As String

        If askParamIfrunTime Then
            If AskNewParametri() = False Then
                Return vbNullString
            End If
        End If

        Dim sSql As String = _Sql

        If Not Parametri Is Nothing Then
            For Each parametro As CParametro In Parametri.Values
                sSql = Replace(sSql, parametro.Nome, parametro.ReplaceParam())
            Next
        End If

        Return sSql
    End Function

    Public Sub New()
        MyBase.New("E|", "query")

        'autorizzazioni di default
        AddAutorizzazioni(PRF_TUTTI, "r", "")
    End Sub

    Public Function AskNewParametri() As Boolean Implements ICriterio.AskNewParametri
        Return mCriterio.AskNewParametri()
    End Function

    Public Property Parametri As CParametri Implements ICriterio.Parametri
        Get
            Return mCriterio.Parametri
        End Get
        Set(value As CParametri)
            mCriterio.Parametri = value
        End Set
    End Property

    Public Function RunTime() As Boolean Implements ICriterio.RunTime
        Return mCriterio.RunTime
    End Function

    Public Sub AddAutorizzazioni(sNome As String, sConsenti As String, sNega As String) Implements IProfilatore.AddAutorizzazioni
        mProfilatore.AddAutorizzazioni(sNome, sConsenti, sNega)
    End Sub

    Public Function GetAutorizzazioni(utente As CUtente) As EAutType Implements IProfilatore.GetAutorizzazioni
        Return mProfilatore.GetAutorizzazioni(utente)
    End Function

    Public ReadOnly Property Profili As CProfili Implements IProfilatore.Profili
        Get
            Return mProfilatore.Profili
        End Get
    End Property

    Public ReadOnly Property ProfiloPrincipale As String
        Get
            For Each profilo In Profili
                If profilo.Key.ToUpper <> PRF_TUTTI Then
                    Return profilo.Key.ToUpper
                End If
            Next

            Return PRF_TUTTI
        End Get
    End Property
End Class
