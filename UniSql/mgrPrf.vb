Module mgrPrf
    Public Const PRF_TUTTI As String = "TUTTI"
    Public Const PRF_ADMIN As String = "ADMIN"
    Public Const PRF_AGENTE As String = "AGENTE"
    Public Const PRF_COLLABORATORE As String = "COLLABORATORE"

    Public Const UNITOOLS_NOME_UTENTE As String = "UNITOOLS_NOME_UTENTE"
    Public Const UNITOOLS_PROFILI_UTENTE As String = "UNITOOLS_PROFILI_UTENTE"

    Public Utente As New CUtente

    Public Function CastPrf(obj As CManifesto) As IProfilatore
        CastPrf = obj
    End Function

End Module
