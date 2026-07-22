Imports System.IO

Public Class Globale

    Public Shared Log As New Utx.ApplicationLog("UploadUnigest.log")
    Public Shared s As New UnicontUpload.IcoUniDataExchangeservice

    Public Shared Function UploadFile(Sessione As String,
                                      NomeFile As String,
                                      TipoFile As String,
                                      DataInizio As Date,
                                      DataFine As Date) As Boolean

        Try
            'invio il file al servizio ottenendo il codice di risposta
            Dim Codice As Integer = s.UploadFileAndTime(Sessione,
                                                        TipoFile,
                                                        Path.GetFileName(NomeFile),
                                                        CDate(Format(DataInizio, "dd/MM/yyyy 08:00:00")),
                                                        CDate(Format(DataFine, "dd/MM/yyyy 08:00:00")),
                                                        File.ReadAllBytes(NomeFile))
            Return (Codice = 0)

        Catch ex As Exception
            Globale.Log.Info(ex)
            Return False
        End Try
    End Function

    Friend Shared Function ErroreOpenSession(Sessione As String) As Boolean
        Select Case Sessione
            Case -1
                Log.Info("eccezione interna. contattare gli amministratori del servizio")
                Return True
            Case 1
                Log.Info("utente o passord errati")
                Return True
            Case 2
                Log.Info("utente(bloccato)")
                Return True
            Case Else
                Return False
        End Select
    End Function
End Class
