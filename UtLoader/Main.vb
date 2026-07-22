Module Main

    Sub Main()
        Dim FileExe As String = IO.Path.Combine(IO.Path.GetDirectoryName(Application.ExecutablePath), "Unitools.exe")
        Process.Start(FileExe)
    End Sub
End Module
