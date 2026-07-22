Imports System.Data.OleDb

Public Class Profilo

    Public Enum CategoriaFunzione As Integer
        Amministrativa = &H1
        Operativa = &H2
        Gestionale = &H4
    End Enum

    Private mUtente As String = Ut.Globale.UtenteCorrente.UniageUser
    Private mAutorizzazioni As Integer = 0
    Private mColonia As String
    Private Shared mProfilo As Profilo
    Private Const ROOT = &H80000000

    Private Sub New()

        Using connection As OleDbConnection = New OleDbConnection(Ut.Globale.CnDbLink)

            connection.Open()

            Using cmd As New OleDbCommand(String.Format("Select Autorizzazioni from Utente Where Utente ='{0}'", mUtente), connection)
                Using reader As OleDbDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        mAutorizzazioni = reader.GetInt32(0)
                    End If
                End Using
            End Using

            If mAutorizzazioni = 0 Then
                Using cmd As New OleDbCommand("Select 1 from Utente Where (Autorizzazioni mod 2) = 1", connection)
                    Using reader = cmd.ExecuteReader()
                        If Not reader.Read() Then
                            mAutorizzazioni = ROOT
                        End If
                    End Using
                End Using
            End If
        End Using
    End Sub

    Public Shared Function IsAuthorizzed(ByVal categoriaFunzione As CategoriaFunzione) As Boolean
        If mProfilo Is Nothing Then
            mProfilo = New Profilo()
        End If
        If mProfilo.mAutorizzazioni = ROOT Then
            Return True
        Else
            Return ((mProfilo.mAutorizzazioni And categoriaFunzione) > 0)
        End If
    End Function

    Public Shared Sub openForm()
        Dim f As New FormProfilazione
        f.ShowDialog()
    End Sub
End Class
