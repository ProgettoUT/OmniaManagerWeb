Imports System.IO
Imports System.Text

Public Class Globale

    Public Structure NuoviDati
        Friend MonitorQt As Boolean
        Friend SinistriBase As Boolean
        Friend ListeQT As Boolean
        Friend ListeFlex As Boolean
        Friend Buste As Boolean
    End Structure

    Public Shared Login As New Utx.AutenticazioneUeba
    Public Shared DatiArrivati As NuoviDati

    Public Shared Log As Utx.ApplicationLog
    Public Shared LogErrori As Utx.ApplicationLog

    Friend cm As New ContextMenuStrip
    Public Event ItemClicked As ToolStripItemClickedEventHandler

    Friend Shared WithEvents IconaNotifica As NotifyIcon
    Friend Shared Notifica As New TabControl

    Public Shared Function SalvaFileStream(Destinazione As String, Response As Net.HttpWebResponse) As Boolean
        Try
            Using writer As New IO.FileStream(Destinazione, IO.FileMode.Create)
                Dim reader = Response.GetResponseStream()

                Dim buffer(1024) As Byte

                Dim b = reader.Read(buffer, 0, 1024)
                While b > 0
                    writer.Write(buffer, 0, b)
                    b = reader.Read(buffer, 0, 1024)
                End While
            End Using
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function
End Class
