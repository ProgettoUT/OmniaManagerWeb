Imports System.IO

Public Class DepositoServer

    Private Const UrlBase As String = "http://www.utools.it/Unitools/Update/Versioni/{0}/"

    Friend Shared Function OrigineVersione() As String
        Return String.Format(UrlBase, Versione.IdVersioneCorrente)
    End Function

End Class
