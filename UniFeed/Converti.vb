Imports System.Data.OleDb

Public Class ConvertiFileSinistri
    Private Agenzia As Utx.AgenziaFigliaOmnia

    Public Sub New(Agenzia As Utx.AgenziaFigliaOmnia)
        Me.Agenzia = Agenzia
    End Sub

    Public Sub ConvertiSinistri()
        Try
            Using connessione As New OleDbConnection(Agenzia.ConnectionStringDbUno)
                connessione.Open()
                Using command As OleDbCommand = New OleDbCommand()
                    command.Connection = connessione

                    For anno As Integer = 2016 To 2012 Step -1
                        Try
                            command.CommandText = "SELECT COUNT(*) FROM Sinistri WHERE TipoElaborazione = '92' AND DataElaborazione = #12/31/" & anno & "#"
                            If CInt(command.ExecuteScalar()) = 0 Then
                                ConvertiSinistriAnno(anno)
                            Else
                                Exit For
                            End If
                        Catch ex As Exception
                            Globale.Log.Info(ex)
                        End Try
                    Next
                End Using
            End Using

        Catch ex As Exception
            Globale.Log.Info(ex)
        End Try
    End Sub

    Public Sub ConvertiSinistriAnno(anno As Integer)
        Try
            Globale.Log.Info("Conversione file sinistri 31/12 dell'anno " & anno)

            'download file vecchio archivio
            Dim ArchivioSinistriDl As String = String.Format("{0}\Sinistri\{1:0000}", Agenzia.Cartelle.ArchivioDati, anno)
            Dim NomeFileDl As String = String.Format("{0}_sinistri_31_Dicembre_{1}.exe", Agenzia.CodiceAgenziaFiglia, anno)
            Dim NomeFileOmnia As String = String.Format("MA1{0}{1}1231.777", Agenzia.CodiceAgenziaFiglia, anno - 2000)
            Dim NomeFileOmniaZip As String = String.Format("MA1{0}{1}1231777.ZIP", Agenzia.CodiceAgenziaFiglia, anno - 2000)

            Dim PathFileDl As String = IO.Path.Combine(Agenzia.Cartelle.CartellaArriviLocaleTempOmnia, NomeFileDl)
            Dim PathFileOmnia As String = IO.Path.Combine(Agenzia.Cartelle.CartellaArriviLocaleTempOmnia, NomeFileDl)
            Dim PathFileOmniaZip As String = IO.Path.Combine(Agenzia.Cartelle.CartellaArriviLocaleTempOmnia, NomeFileDl)

            If IO.File.Exists(IO.Path.Combine(ArchivioSinistriDl, NomeFileDl)) Then
                IO.File.Copy(IO.Path.Combine(ArchivioSinistriDl, NomeFileDl), PathFileDl, True)
            ElseIf Not IO.File.Exists(IO.Path.Combine(Agenzia.Cartelle.ArchivioDatiOmnia, NomeFileOmniaZip)) Then
                Dim url As String = String.Format("http://team.agenzie.unipolsai.it/dati/download1.asp?file={0}&percorso=DATI/ARCHIVIO/DATISIN/", NomeFileDl)

#If Not Debug Then
                Try
                    Using wc As New System.Net.WebClient
                        wc.Credentials = System.Net.CredentialCache.DefaultCredentials
                        wc.CachePolicy = New Net.Cache.RequestCachePolicy(Net.Cache.RequestCacheLevel.NoCacheNoStore)
                        wc.DownloadFile(url, PathFileDl)
                    End Using
                Catch ex As Exception
                    Globale.Log.Info(ex)
                End Try
#End If
            End If

            Dim FileIn As String = PathFileDl.Replace(".exe", ".txt")
            Dim FileOut As String = IO.Path.Combine(Agenzia.Cartelle.CartellaArriviLocaleAgenziaOmnia, NomeFileOmnia)

            'scompattazione
            If IO.File.Exists(PathFileDl) Then
                Utx.LibreriaZip.SevenZip.UnzipFile(PathFileDl, Agenzia.Cartelle.CartellaArriviLocaleTempOmnia)
            End If

            'conversione
            If IO.File.Exists(FileIn) Then
                SinistriToMA92(FileIn, FileOut)
            End If

        Catch ex As Exception
            Globale.Log.Info(ex)
        End Try
    End Sub

    Public Function SinistriToMA92(fileIn As String, fileOut As String) As Boolean
        Dim codiceAgenzia As String = IO.Path.GetFileName(fileIn).Substring(0, 5)

        Globale.Log.Info("Inizio conversione file: " & fileIn)

        Using writer As New IO.StreamWriter(fileOut)
            Using reader = New IO.StreamReader(fileIn)
                While (reader.Peek() <> -1)
                    Dim riga As String = reader.ReadLine()
                    If riga.StartsWith("INIZIO INCARICHI") Then
                        Exit While
                    End If

                    If riga.Length = 1021 Then
                        writer.Write(riga.Substring(6, 4))
                        writer.Write(riga.Substring(3, 2))
                        writer.Write(riga.Substring(0, 2))
                        writer.Write(codiceAgenzia)
                        writer.Write("0192")
                        writer.Write(riga.Substring(10, 4))
                        writer.Write(riga.Substring(14, 4))
                        writer.Write(riga.Substring(19, 32))
                        writer.Write("000000")
                        writer.Write(riga.Substring(51, 3))
                        writer.Write("0000")
                        writer.Write(riga.Substring(55, 34))
                        writer.Write("ITA")
                        writer.Write("   ") ' PROVINCIA
                        writer.Write("000")
                        writer.Write(riga.Substring(89, 14))
                        writer.Write(riga.Substring(104, 16))
                        writer.Write(riga.Substring(121, 138))
                        writer.Write(Space(26))
                        writer.Write("00000") '00035 PRIMA DELLA TARGA
                        writer.Write(riga.Substring(259, 582))
                        writer.Write("1")
                        writer.Write(riga.Substring(841, 180))
                        writer.Write("0000001")
                        writer.Write(Space(4917))
                        writer.Write("*")
                        writer.WriteLine()
                    End If
                End While
            End Using
        End Using

        Globale.Log.Info("Fine conversione file: " & fileIn)
        Return True
    End Function
End Class
