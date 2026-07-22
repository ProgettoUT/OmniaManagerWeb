Imports System.IO

Public Class InfoApp

    Public Shared Function VersioneApp() As String
        Return FileVersionInfo.GetVersionInfo(Path.Combine(Utx.Globale.Paths.CartellaApp, "InfoUt.dll")).ProductVersion
    End Function
End Class
