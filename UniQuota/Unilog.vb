Imports System.Environment
Imports System.IO

Public Class Unilog
    'Public utlog As New Utx.ApplicationLog("Uniquota.log")

    'Private m_fileLog As String = "C:\ApplicazioniDirezione\Unitools\Logs\Uniquota.log"

    'Public Sub New()
    '    If CARTELLA_DATI IsNot Nothing Then
    '        m_fileLog = Path.Combine(CARTELLA_DATI, "C:\ApplicazioniDirezione\Unitools\Logs\Uniquota.log")
    '    End If

    '    Dim directoryName As String = Path.GetDirectoryName(m_fileLog)
    '    If Not Directory.Exists(directoryName) Then
    '        Directory.CreateDirectory(directoryName)
    '    End If
    'End Sub

    'Public Sub Debug(ByRef sText As String)
    '    Try
    '        File.AppendAllText(m_fileLog, Today.ToString + ": " + sText + vbNewLine)
    '    Catch ex As Exception
    '        MsgBox(ex.StackTrace)
    '    End Try
    'End Sub

    Public Sub Debug(ByRef sText As String)
        'Utx.Globale.Log.AddLog(sText)
    End Sub
End Class
