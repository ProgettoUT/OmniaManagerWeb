Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports Microsoft.Web.Services3.Security.Tokens

Public Class Globale

    'Friend Const TitoloApp As String = "Gestione documenti"
    Friend Shared Log As New Utx.ApplicationLog("GestioneDocumenti.log")

    'scanner
    Public Shared WithEvents UtScanners As New Scanners

    Public Enum TipoOperazioneLiquido
        UPLOAD = 1
        VISUALIZZA = 2
        SALVA = 3
        LISTALIQUIDO = 4
        LISTASERTEL = 5
    End Enum

    Public Enum TipoUserToken
        TECNICO
        UTENTE
    End Enum

    Friend Shared Function UserToken(Tipo As TipoUserToken) As UsernameToken
        If Tipo = TipoUserToken.TECNICO Then
            Return New UsernameToken("batchuser", "batchuser", PasswordOption.SendPlainText)
        Else
            Return New UsernameToken(Utx.Globale.UtenteCorrente.UniageUser, Utx.Globale.UtenteCorrente.UniagePw, PasswordOption.SendPlainText)
        End If
    End Function

    Friend Shared Function UserToken(User As String, Password As String) As UsernameToken
        Return New UsernameToken(User, Password, PasswordOption.SendPlainText)
    End Function

    Public Shared Sub InstallaCertificati()
        If Utx.FunzioniRete.PcInDominio = False Then
            'Exit Sub
            Try
                'certificato root installato 
                Dim store = New X509Store(StoreName.Root, StoreLocation.CurrentUser)
                store.Open(OpenFlags.ReadWrite)
                store.Add(New X509Certificate2(Path.Combine(Utx.Globale.Paths.CartellaModelli, "prod_internet_root.cer"),
                                               X509KeyStorageFlags.UserKeySet Or X509KeyStorageFlags.PersistKeySet))
                store.Close()

                'certificato intermediate
                store = New X509Store(StoreName.CertificateAuthority, StoreLocation.CurrentUser)
                store.Open(OpenFlags.ReadWrite)
                store.Add(New X509Certificate2(Path.Combine(Utx.Globale.Paths.CartellaModelli, "prod_internet_intermediate.cer"),
                                               X509KeyStorageFlags.UserKeySet Or X509KeyStorageFlags.PersistKeySet))
                store.Close()

            Catch ex As Exception
                Globale.Log.Errore(ex)
            End Try
        End If
    End Sub
End Class
