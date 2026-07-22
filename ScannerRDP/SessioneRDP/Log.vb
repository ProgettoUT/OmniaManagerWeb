Imports System.IO
Imports System.Text

Module Log

    Friend Const LogFile As String = "C:\ApplicazioniDirezione\Unitools\Logs\ScannerRDP.log"

    Private Function LogMsg(ByVal Messaggio As String)

        LogMsg = String.Format("[{0} {1}]{2}",
                               Now.ToShortDateString,
                               Now.ToLongTimeString,
                               Messaggio) + vbNewLine

    End Function

    Private Function LogMsg()
        'riga di separazione
        LogMsg = StrDup(80, "-") + vbNewLine
    End Function

    Friend Sub AddLog()
        'aggiungo msg al file di log
        File.AppendAllText(LogFile, LogMsg() + vbNewLine)
    End Sub

    Friend Sub AddLog(ByVal Messaggio As String)
        'aggiungo msg al file di log
        File.AppendAllText(LogFile, LogMsg(Messaggio) + vbNewLine)
    End Sub

    Friend Sub AddLog(ByVal Messaggio As String, ByVal Evidenziato As Boolean)

        'attenzione: non far riferimento qui a funzioni che utilizzano addlog (come ad esempio LogStackTrace)
        'altrimenti si va in un loop infinito

        If Evidenziato Then AddLog()

        'aggiungo msg al file di log
        AddLog(Messaggio)

        If Evidenziato Then AddLog()
    End Sub

    Friend Sub BoxErrore(ByVal ex As Exception)

        AddLog()
        AddLog(ex.Message)
        AddLog()
        AddLog()

    End Sub

    Friend Sub BoxErrore(ByVal Messaggio As String)

        AddLog()
        AddLog(Messaggio)
        AddLog()
        AddLog()

    End Sub

End Module
