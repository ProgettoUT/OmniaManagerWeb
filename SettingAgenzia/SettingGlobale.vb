Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class SettingGlobale

    'Friend MdbDriver As String = "Provider = Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source="

    'Friend ConfigDb As String = x.MapPath("\mdb-database\190139f2-4749-488a-859c-51c824f6bbdc\ConfigDownload\ConfigDLDati.mdb")
    'Friend StatisticheDb As String = x.MapPath("\mdb-database\Statistiche\Statistiche.mdb")
    'Friend ControlloVersioneDb As String = x.MapPath("\Unitools\Update\Versioni\ControlloVersione.mdb")

    'Friend CnConfigDb As String = MdbDriver + CnConfigDb
    'Friend CnStatisticheDb As String = MdbDriver + StatisticheDb
    'Friend CnControlloVersioneDb As String = MdbDriver + ControlloVersioneDb

    'Friend CartellaLog As String = x.MapPath("\mdb-database\190139f2-4749-488a-859c-51c824f6bbdc\ConfigDownload\Logs")
    'Friend FileLog As String = Path.Combine(CartellaLog, "SettingAgenzie.log")

    Public Shared Function FileToMD5(ByVal FilePath As String) As String

        Try
            If Not File.Exists(FilePath) Then Return "-ERR"

            Dim md5 As New MD5CryptoServiceProvider

            Using f As New FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
                md5.ComputeHash(f)
                f.Close()
            End Using

            Dim hash As Byte() = md5.Hash
            Dim buffer As StringBuilder = New StringBuilder

            For Each hashByte As Byte In hash
                buffer.Append(String.Format("{0:X2}", hashByte))
            Next

            Return buffer.ToString()

        Catch ex As Exception
            Return "-ERR"
        End Try

    End Function

End Class
