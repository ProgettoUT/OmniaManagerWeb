Imports System.IO

Public Class ApplicationLog

    Private mFileLog As String
    Private mCartellaLog As String

    Sub New(ByVal CartellaLog As String,
            ByVal NomeFileLog As String)

        mCartellaLog = CartellaLog
        mFileLog = Path.Combine(CartellaLog, NomeFileLog)

        ControlloLog()
    End Sub

    Private Sub ControlloLog()

        Try
            'controlla dimensioni del log se > 1000 kb lo sposta nell'archivio
            If File.Exists(mFileLog) AndAlso (New FileInfo(mFileLog).Length > 1000000) Then
                Dim ArchivioLog As String = Path.Combine(mCartellaLog, "Logs")
                Directory.CreateDirectory(ArchivioLog)

                File.Move(mFileLog, Path.Combine(ArchivioLog, Format(Now, "dd-MM-yyyy HH-mm-ss") + ".log"))
            End If

        Catch ex As Exception
        End Try

    End Sub

    Friend Sub AddLog()

        On Error Resume Next

        'aggiungo il separatore al file di log
        File.AppendAllText(mFileLog, StrDup(60, "-") + Environment.NewLine)
    End Sub

    Friend Sub AddLog(ByVal Messaggio As String)

        On Error Resume Next

        'aggiungo il messaggio al file di log
        File.AppendAllText(mFileLog, String.Format("[{0:G}]{1}{2}", Now, Messaggio, Environment.NewLine))
    End Sub

    Friend Sub BoxErrore(ByVal ex As Exception)
        AddLog()
        AddLog(ex.Message)
        LogStackTrace()
        AddLog()
    End Sub

    Friend Sub LogStackTrace()

        Dim st As New StackTrace(True)

        For i As Integer = 0 To st.FrameCount - 1

            Dim sf As StackFrame = st.GetFrame(i)

            Try
                AddLog(Space(4) + "Metodo: " + sf.GetMethod().ToString)

                'se è presente il file pdb
                If sf.GetFileName() <> Nothing Then
                    AddLog(Space(8) + "- File: " + Path.GetFileName(sf.GetFileName()))
                    AddLog(Space(8) + "- Linea: " + sf.GetFileLineNumber().ToString)
                End If

            Catch ex As Exception
                AddLog(ex.Message)
            End Try
        Next i

    End Sub

End Class
