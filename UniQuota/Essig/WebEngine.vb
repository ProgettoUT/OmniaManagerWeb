Imports System.Net
Imports System.Text
Imports System.IO

Namespace Essig

    Public Class WebEngine

        Private Shared mInstance As WebEngine

        Public Shared ReadOnly Property Instance As WebEngine
            Get
                If mInstance Is Nothing Then
                    mInstance = New WebEngine
                End If
                Return mInstance
            End Get
        End Property

        Public Shared ReadOnly Property IsLogged As Boolean
            Get
                If Instance Is Nothing Then
                    Return False
                Else
                    Return LoginEssig.IsLogged
                End If
            End Get
        End Property


        Public Sub New()
            Login()
        End Sub

        Private Sub Login()
            Dim statoLogin = LoginEssig.LogIn()

            If statoLogin = Utx.Autenticazione.StatoLogin.FALLITO Then
                MsgBox("Accesso in Essig non eseguito. Login annullato o utente/password errati. ")
            ElseIf statoLogin = Utx.Autenticazione.StatoLogin.RETE_NON_DISPONIBILE Then
                MsgBox("Accesso in Essig non eseguito. Rete non accessibile. ")
            End If
        End Sub

        Public Function CallWeb(ByVal url As String, Optional ByVal postData As String = Nothing) As String
            'Debug.Print(url)
            'Debug.Print(postData)
            Return LoginEssig.CallWeb(LoginEssig.UrlBase & url, postData)
        End Function

    End Class
End Namespace
