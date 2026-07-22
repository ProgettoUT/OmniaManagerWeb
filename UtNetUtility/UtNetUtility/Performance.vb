Imports System.IO

Public Class Performance

    Private mChiamataPrecedente As DateTime = Now
    Private Log As UtNetUtility.ApplicationLog

    Sub New(ByVal NomeLogFile As String)
        Log = New ApplicationLog(NomeLogFile)
        AddLog(StrDup(80, "-"))
    End Sub

    Public Sub AddLog(ByVal Desk As String)

        Dim Msg As String = String.Format("[{0}][{1}]{2}",
                                          Format(Now, "ss.fff"),
                                          DurataProcesso(),
                                          Desk)

        Log.AddLog(Msg)
        mChiamataPrecedente = Now
    End Sub

    Private Function DurataProcesso() As String
        Return Format(Now.Subtract(mChiamataPrecedente).Milliseconds, "00000")
    End Function

End Class
