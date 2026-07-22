Class Log
    Private logFile As String
    Private ScaFile As String

    Public Sub Append(sRow As String)
        IO.File.AppendAllText(logFile, sRow & vbNewLine)
    End Sub
    Public Sub Scarto(sRow As String)
        IO.File.AppendAllText(ScaFile, sRow & vbNewLine)
    End Sub

    Sub New()
        logFile = IO.Path.Combine(CartellaLogs, String.Format("import_{0}.log", Format(Now, "ddMMyyyy_HHmmss")))
        ScaFile = IO.Path.Combine(CartellaLogs, String.Format("scarto_{0}.log", Format(Now, "ddMMyyyy_HHmmss")))
    End Sub
End Class
