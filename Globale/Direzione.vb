Imports System.Xml
Imports System.Globalization

Public Class Direzione
    Public Shared Function GetFilesMAdalServerDiDirezione() As DataTable

        Dim url As String = $"https://casellario.unipolsai.it/WSMA/ListAllFiles.aspx?GUID={System.Guid.NewGuid}"

        'legge i file presente nella cartella di download
        Globale.Log.Trace("GetFilesMAdalServerDiDirezione: inizio")
        Dim table As New DataTable()

        Try
            Globale.Log.Trace($"UniageUser = {Utx.Globale.UtenteCorrente.UniageUser}")
            Globale.Log.Trace("Crea la WebRequest")
            Dim request As Net.WebRequest = Net.WebRequest.Create(url)

            Globale.Log.Trace("imposto il metodo Http.Get")
            request.Method = Net.WebRequestMethods.Http.Get

            Globale.Log.Trace("imposto le credenziali")
            request.Credentials = Utx.Globale.UtenteCorrente.Credenziali

            Globale.Log.Trace("invio la richiesta al server")
            Dim response = request.GetResponse()

            Globale.Log.Trace("elabora la risposta")
            Dim xDoc As New XmlDocument
            xDoc.Load(response.GetResponseStream)

            table.Columns.Add(New DataColumn("Agenzia", GetType(String)))
            table.Columns.Add(New DataColumn("Data", GetType(Date)))
            table.Columns.Add(New DataColumn("Nome", GetType(String)))

            Globale.Log.Trace("leggo i files")
            Dim files As XmlNodeList = xDoc.SelectNodes("//NAME")

            For Each file As XmlNode In files
                Dim filename As String = file.InnerText

                Dim row As DataRow = table.NewRow()
                row("Nome") = filename

                If IO.Path.GetFileNameWithoutExtension(filename) Like "M[AE]###############" Then
                    'MA1 02379 161215 001
                    row("Agenzia") = filename.Substring(3, 5)
                    row("Data") = Date.ParseExact(filename.Substring(8, 6), "yyMMdd", CultureInfo.InvariantCulture)
                End If
                table.Rows.Add(row)
            Next
            response.Close()
        Catch ex As Exception
            Globale.Log.Info($"eccezione: {ex.Message}")
        End Try
        Globale.Log.Trace("CaricaListaDisponibiliHttp: fine")

        Return table
    End Function
End Class
