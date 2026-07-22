Imports System.Data.OleDb
Imports System.Xml

Class Archivi
    Inherits Dictionary(Of String, Archivio)
    Public AgenziaMadre As Utx.AgenziaOmnia
    Public Agenzia As Utx.AgenziaFigliaOmnia
    Public Database As Database
    Public Specifica As Specifica
    Public DataUltimaEstrazione As Date
    Public Guid As String
    Public NomeSimbolicoInizioImportazione As String = Nothing
    Public NomeSimbolicoFineImportazione As String = Nothing
    Public TipiRecordsDaImportare As String = Nothing
    Public TipiRecordsScartati As New List(Of String)
    Private Shared tipoFileToFind As New List(Of String())

    Shared Sub New()
        tipoFileToFind.Add(New String() {"M?############.???", "F01"})
    End Sub

    Public Sub New(AgenziaMadre As Utx.AgenziaOmnia, Agenzia As Utx.AgenziaFigliaOmnia, withDatabase As Boolean)
        Me.AgenziaMadre = AgenziaMadre
        Me.Agenzia = Agenzia
        If withDatabase Then
            Database = New Database(Agenzia)

            Using c As New OleDbConnection(Utx.Globale.MDBDriver & Database.ModelloDbUno)
                c.Open()
                Specifica = New Specifica(c)
            End Using

            Globale.Log.Trace("Specifica : " & (Specifica IsNot Nothing))
        End If

        Guid = System.Guid.NewGuid.ToString
        Globale.Log.Trace("Guid : " & Guid)
    End Sub

    Public Sub Elabora()
        '1) leggo l'elenco di tutti i file presenti in agenzia e nel server
        Globale.NotificaShow("Lettura elenco files")
        Globale.Log.Trace(vbNewLine)
        Globale.Log.Trace("1/7: inizio lettura dell'elenco di tutti i file presenti in agenzia e nel server")
        CaricaLista()
        Globale.Log.Trace("1/7: lettura dell'elenco di tutti i file presenti in agenzia e nel server terminata")

        '2) scarico i file disponibili nel server che mancano in agenzia
        Globale.Log.Trace(vbNewLine)
        Globale.Log.Trace("2/7: inizio download dei file disponibili nel server che mancano in agenzia")
        Download()
        Globale.Log.Trace("2/7: download dei file disponibili terminata")

        '3) invio i file a SIA
        Globale.Log.Trace(vbNewLine)
        Globale.Log.Trace("3/7: inizio controllo file da reimportazione")
        InviaFileMaToSia()
        Globale.Log.Trace("3/7: fine controllo file da reimportazione")

        '4) forza eventualmente la reimportazione
        Globale.Log.Trace(vbNewLine)
        Globale.Log.Trace("4/7: inizio controllo file da reimportazione")
        Reimporta()
        Globale.Log.Trace("4/7: fine controllo file da reimportazione")

        '5) unzip i file
        Globale.Log.Trace(vbNewLine)
        Globale.Log.Trace("5/7: inizio la decompressione dei file zippati")
        Decomprimi()
        Globale.Log.Trace("5/7: decompressione dei file zippati terminata")

        '6) importo i file
        Globale.Log.Trace(vbNewLine)
        Globale.Log.Trace("6/7: inizio importazione dei file")
        Importa()
        Globale.Log.Trace("6/7: importazione dei file terminata")

        '7) Sposto archivi in storico
        Globale.Log.Trace(vbNewLine)
        Globale.Log.Trace("7/7: inizio archiviazione")
        Archivia()
        Globale.Log.Trace("7/7: archiviazione terminata")
    End Sub

    Public Sub CaricaLista()
        CaricaListaMancanti()
        CaricaListaDisponibili()
        CaricaListaScaricati()
        CaricaListaArchiviati()
        CaricaListaImportati()
        Globale.Report.ArchiviTotaliCount = Me.Count
        Globale.Log.Info("Archivi totali: {0}", {Me.Count.ToString})

        'rendo non disponibile i file di codici chiusi (datafine < today)
        For Each r In Agenzia.Config
            'se il codice è chiuso
            If r.DataFine < Today Then
                Dim FileDisabilitati As Integer = 0
                For Each archivio In Me.Values
                    If (archivio.CodiceCollegato = r.AgenziaCollegata) Then
                        archivio.Disponibile = False
                        archivio.Archiviato = True
                        archivio.Importato = True
                        FileDisabilitati += 1
                    End If
                Next
                Globale.Log.Info("Controllo codici: {0} codice chiuso il {1} - file disabilitati {2}", {r.AgenziaCollegata, r.DataFine.ToShortDateString, FileDisabilitati.ToString})
            End If
        Next
    End Sub

    Public Sub CaricaListaMancanti()
        Try
            Globale.Log.Info("CaricaListaMancanti: inizio")
            Dim Query As String = String.Format("SELECT DISTINCT Nome, DataEstrazione, CodTipoFile 
                FROM MA{0}.dbo.ARP002_File 
                WHERE DataImportazione IS NULL", Agenzia.CodiceAgenziaFiglia)
            Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteNonQueryMA({Query}, {"MA"}, Agenzia.CodiceAgenziaFiglia)
            Dim files As DataTable = Risposta.DataSet.Tables("MA")

            For Each file As DataRow In files.Rows
                With GetArchivio(file("Nome").ToString)
                    If file("DataEstrazione") IsNot Nothing Then .DataEstrazione = CDate(file("DataEstrazione"))
                    If file("CodTipoFile") IsNot Nothing Then .Tipo = file("CodTipoFile").ToString
                    Globale.Report.ArchiviMancantiCount += 1
                End With
            Next
        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Globale.Log.Info("CaricaListaMancanti: fine")
        End Try
    End Sub

    Public Sub CaricaListaDisponibili()
        Globale.Log.Info("CaricaListaDisponibili: inizio")
        Globale.Log.Info("Utx.Globale.ProfiloEnteGestore.ProfiloApp = " & Utx.Globale.ProfiloEnteGestore.ProfiloApp)

        'If Utx.Globale.ProfiloEnteGestore.ProfiloApp = Utx.Enumerazioni.ProfiloApp.COMPLETO Then
        CaricaListaDisponibiliHttp()
        CaricaListaDisponibiliUtools()
        CaricaListaDisponibiliDiscoK()
        CaricaListaDisponibiliDiscoKBackup()
        'ElseIf Utx.Globale.ProfiloEnteGestore.ProfiloApp = Utx.Enumerazioni.ProfiloApp.SINISTRI Then
        '    CaricaListaDisponibiliFtp()
        'End If
        Globale.Log.Info("CaricaListaDisponibili: fine")
    End Sub

    Public Sub CaricaListaDisponibiliDiscoK()
        Exit Sub
        Globale.Log.Info("CaricaListaDisponibiliDiscoK: inizio")

        If IO.Directory.Exists(Agenzia.Cartelle.CartellaArriviDiscoK) Then
            'todo: definire la cartella di origine del disco k
            For Each file In IO.Directory.GetFiles(Agenzia.Cartelle.CartellaArriviDiscoK)
                Dim nomefile = IO.Path.GetFileName(file)
                Dim nome As String = Archivio.NomeSenzaEstenzioneZip(nomefile)

                If FileDaElaborare(nome) = False Then
                    Globale.Log.Trace(String.Format("Il file {0} non puo essere elaborato e quindi verrà scartato.", nomefile))
                ElseIf Specifica.FileCanUpload(nome) = False Then
                    Globale.Log.Trace(String.Format("Manca la specifica di importazione del file {0} e quindi verrà scartato.", nomefile))
                Else
                    Globale.Log.Trace(String.Format("Il file {0} è stato inserito nella lista dei file disponibili nel disco k.", nomefile))
                    GetArchivio(nomefile).DisponibileDiscoK = True
                    GetArchivio(nomefile).Disponibile = True
                    'Globale.Report.ArchiviDisponibiliCount += 1
                End If
            Next
        End If
        Globale.Log.Info("CaricaListaDisponibiliDiscoK: fine")
    End Sub

    Public Shared Sub CopiaFileDiscoK()
        Globale.Log.Info("CopiaFileDiscoK: inizio")
        Dim Agenzia As String = "02379"
        Try
            Dim CartellaK As String = IO.Path.Combine("K:\Casella\download", Agenzia)

            If IO.Directory.Exists(CartellaK) Then
                Dim CartellaM As String = IO.Path.Combine(Utx.Globale.Paths.CartellaArchivioDati, Agenzia, "OMNIA", "FileRicevuti")
                IO.Directory.CreateDirectory(CartellaM)
                Dim ModelloK As String = String.Format("MA1{0}??????.???", Agenzia)

                For Each f As String In IO.Directory.GetFiles(CartellaK, ModelloK)
                    Dim NomeFile As String = IO.Path.GetFileName(f)
                    Dim NomeZip As String = NomeFile.Replace(".", "") & "zip"
                    Dim FileZip As String = IO.Path.Combine(Utx.Globale.Paths.CartellaArchivioDati, Agenzia, "OMNIA", "FileRicevuti", NomeZip)

                    If IO.File.Exists(FileZip) = False Then
                        'zippo e copio il file
                        Utx.LibreriaZip.SevenZip.ZipFile(f, FileZip)
                    End If
                Next
            End If
        Catch ex As Exception
            Globale.Log.Info(ex.Message)
        End Try
        Globale.Log.Info("CopiaFileDiscoK: fine")
    End Sub

    Public Sub CaricaListaDisponibiliDiscoKBackup()
        Exit Sub
        Globale.Log.Info("CaricaListaDisponibiliDiscoKBackup: inizio")

        If IO.Directory.Exists(Agenzia.Cartelle.CartellaArriviDiscoKBackup) Then
            'todo: definire la cartella di origine del disco k
            For Each file In IO.Directory.GetFiles(Agenzia.Cartelle.CartellaArriviDiscoKBackup)
                Dim nomeBackup = IO.Path.GetFileName(file)
                Dim nomefile = IIf(nomeBackup.IndexOf("_") >= 0, nomeBackup.Substring(1 + nomeBackup.IndexOf("_")), nomeBackup)
                Dim nome As String = Archivio.NomeSenzaEstenzioneZip(nomefile)

                If FileDaElaborare(nome) = False Then
                    Globale.Log.Trace(String.Format("Il file {0} non puo essere elaborato e quindi verrà scartato.", nomeBackup))
                ElseIf Specifica.FileCanUpload(nome) = False Then
                    Globale.Log.Trace(String.Format("Manca la specifica di importazione del file {0} e quindi verrà scartato.", nomeBackup))
                Else
                    Globale.Log.Trace(String.Format("Il file {0} è stato inserito nella lista dei file disponibili nel disco k.", nomeBackup))
                    With GetArchivio(nomefile)
                        .DisponibileDiscoKBackup = True
                        .Disponibile = True
                        .NomeOriginale = nomeBackup
                    End With
                    'Globale.Report.ArchiviDisponibiliCount += 1
                End If
            Next
        End If
        Globale.Log.Info("CaricaListaDisponibiliDiscoKBackup: fine")
    End Sub

    Public Sub CaricaListaDisponibiliHttp()
        'legge i file presente nella cartella di download
        Globale.Log.Info("CaricaListaDisponibiliHttp: inizio")
        Try
            'Globale.Log.Trace("CartellaServer = " & CartellaServerHttp)
            Globale.Log.Trace("UniageUser = " & Utx.Globale.UtenteCorrente.UniageUser)
            'Globale.Log.Trace("UniagePw = " & Ut.Globale.UtenteCorrente.UniagePw)


            Globale.Log.Trace("Crea la WebRequest")

            Dim url As String = Nothing
            If Utx.FunzioniRete.PcInDominio Then
                url = UrlHttpInDominio & "ListAll.aspx?GUID=" & Guid
            Else
                url = UrlHttpInternet & "ListAllFiles.aspx?GUID=" & Guid
            End If

            Globale.Log.Trace("imposto il metodo, proxy e credenziali")
            Dim request = Net.WebRequest.Create(url)
            request.Method = Net.WebRequestMethods.Http.Get
            request.Proxy = Utx.Globale.UniProxy.GetProxy(url)
            request.Credentials = Utx.Globale.UtenteCorrente.Credenziali

            Globale.Log.Trace("invio la richiesta al server")
            Dim response = request.GetResponse()

            Globale.Log.Trace("elabora la risposta")
            Dim xDoc As New XmlDocument
            xDoc.Load(response.GetResponseStream)

            Globale.Log.Trace("leggo i files")
            Dim files As XmlNodeList = xDoc.SelectNodes("//NAME")

            For Each file As XmlNode In files
                Dim nomefile = file.InnerText
                Dim nome As String = Archivio.NomeSenzaEstenzioneZip(nomefile)

                If FileDaElaborare(nome) = False Then
                    Globale.Log.Trace(String.Format("Il file {0} non puo essere elaborato e quindi non verrà scaricato.", nomefile))
                ElseIf Specifica.FileCanUpload(nome) = False Then
                    Globale.Log.Trace(String.Format("Manca la specifica di importazione del file {0} e quindi non verrà scaricato.", nomefile))
                Else
                    Globale.Log.Trace(String.Format("Il file {0} è stato inserito nella lista dei file disponibili per il download.", nomefile))
                    GetArchivio(nomefile).Disponibile = True
                    Globale.Report.ArchiviDisponibiliCount += 1
                End If
            Next
            response.Close()
        Catch ex As Exception
            Globale.Log.Info("eccezione: " & ex.Message)
        End Try
        Globale.Log.Info("CaricaListaDisponibiliHttp: fine")
    End Sub

    Public Sub CaricaListaDisponibiliFtp()
        'legge i file presente nella cartella di download: CartellaServerFtp
        Globale.Log.Info("CaricaListaDisponibiliFtp: inizio")
        'Globale.Log.Trace("CartellaServer = " & CartellaServerFtp)
        Globale.Log.Trace("UniageUser = " & Utx.Globale.UtenteCorrente.UniageUser)
        'Globale.Log.Trace("UniagePw = " & Ut.Globale.UtenteCorrente.UniagePw)

        Try
            Globale.Log.Trace("Crea la Request")
            Dim request As Net.FtpWebRequest = DirectCast(Net.WebRequest.Create(CartellaServerFtp), Net.FtpWebRequest)

            Globale.Log.Trace("imposto il metodo ftp.ListDirectory")
            request.Method = Net.WebRequestMethods.Ftp.ListDirectory

            Globale.Log.Trace("imposto le credenziali")
            request.Credentials = Utx.Globale.UtenteCorrente.Credenziali

            Globale.Log.Trace("invio la richiesta al server")
            Dim response = DirectCast(request.GetResponse(), Net.FtpWebResponse)

            Globale.Log.Trace("elabora la risposta")
            Using reader As New IO.StreamReader(response.GetResponseStream)
                Do While reader.Peek <> -1
                    Dim nomefile = reader.ReadLine
                    Globale.Log.Trace("file: " & nomefile)

                    Dim nome As String = Archivio.NomeSenzaEstenzioneZip(nomefile)

                    If FileDaElaborare(nome) = False Then
                        Globale.Log.Trace(String.Format("Il file {0} non puo essere elaborato e quindi verrà scartato.", nomefile))
                    ElseIf Specifica.FileCanUpload(nome) = False Then
                        Globale.Log.Trace(String.Format("Manca la specifica di importazione del file {0} e quindi verrà scartato.", nomefile))
                    Else
                        Globale.Log.Trace(String.Format("Il file {0} è stato inserito nella lista dei file disponibili per il download.", nomefile))
                        GetArchivio(nomefile).Disponibile = True
                        Globale.Report.ArchiviDisponibiliCount += 1
                    End If
                Loop
            End Using
            response.Close()
        Catch ex As Exception
            Globale.Log.Trace("ERRORE CaricaListaDisponibiliFtp")
            Globale.Log.Trace(ex.Message)
        End Try
        Globale.Log.Info("CaricaListaDisponibiliFtp: fine")
    End Sub


    Public Sub CaricaListaDisponibiliUtools()
        'legge i file presente nella cartella di download
        Globale.Log.Info("CaricaListaDisponibiliUtools: inizio")
        Try
            'Globale.Log.Trace("CartellaServer = " & CartellaServerHttp)
            'Globale.Log.Trace("UniageUser = " & Utx.Globale.UtenteCorrente.UniageUser)
            'Globale.Log.Trace("UniagePw = " & Ut.Globale.UtenteCorrente.UniagePw)

            Globale.Log.Trace("Crea la WebRequest")
            Dim request As Net.WebRequest = Net.WebRequest.Create("http://www.utools.it/Unitools/Download/OMNIA/ListaFiles.xml?GUID=" & Guid)

            Globale.Log.Trace("Imposto proxy")
            request.Proxy = Utx.Globale.UniProxy.Proxy

            Globale.Log.Trace("imposto il metodo Http.Get")
            request.Method = Net.WebRequestMethods.Http.Get

            'Globale.Log.Trace("imposto le credenziali")
            'request.Credentials = New Net.NetworkCredential(Utx.Globale.UtenteCorrente.UniageUser, Utx.Globale.UtenteCorrente.UniagePw)

            Globale.Log.Trace("invio la richiesta al server")
            Dim response = request.GetResponse()

            Globale.Log.Trace("elabora la risposta")
            Dim xDoc As New XmlDocument
            xDoc.Load(response.GetResponseStream)

            Globale.Log.Trace("leggo i files")
            Dim files As XmlNodeList = xDoc.SelectNodes("//file")

            For Each file As XmlNode In files
                Dim nomefile = file.InnerText
                Dim nome As String = Archivio.NomeSenzaEstenzioneZip(nomefile)

                If FileDaElaborare(nome) = False Then
                    Globale.Log.Trace(String.Format("Il file {0} non puo essere elaborato e quindi non verrà scaricato.", nomefile))
                ElseIf Specifica.FileCanUpload(nome) = False Then
                    Globale.Log.Trace(String.Format("Manca la specifica di importazione del file {0} e quindi non verrà scaricato.", nomefile))
                Else
                    Globale.Log.Trace(String.Format("Il file {0} è stato inserito nella lista dei file disponibili per il download.", nomefile))
                    GetArchivio(nomefile).Disponibile = True
                    GetArchivio(nomefile).FromUtools = True
                    Globale.Report.ArchiviDisponibiliCount += 1
                End If
            Next
            response.Close()
        Catch ex As Exception
            Globale.Log.Info("eccezione: " & ex.Message)
        End Try
        Globale.Log.Info("CaricaListaDisponibiliUtools: fine")
    End Sub

    Public Function GetMatchExps() As List(Of String())

        'If tipoFileToFind Is Nothing Then
        '    tipoFileToFind = New List(Of String())()

        '    Using adapter As New OleDbDataAdapter("Select MatchExp, CodTipoFile From ARP001_TipoFile", Agenzia.Connessione)
        '        Dim dt As New DataTable
        '        adapter.Fill(dt)

        '        For Each row As DataRow In dt.Rows
        '            tipoFileToFind.Add(New String() {row.Item(0).ToString, row.Item(1).ToString})
        '        Next
        '    End Using

        'End If
        Return tipoFileToFind
    End Function

    Public Sub CaricaListaScaricati()
        Globale.Log.Info("CaricaListaScaricati: inizio")

        For Each Codice In Agenzia.Config
            For Each file In IO.Directory.GetFiles(Codice.Cartelle.CartellaArriviLocaleAgenziaOmnia)
                Dim nomeFile As String = IO.Path.GetFileName(file)

                Dim nome As String = Archivio.NomeSenzaEstenzioneZip(nomeFile)

                If FileDaElaborare(nome) = False Then
                    Globale.Log.Trace(String.Format("Il file {0} non puo essere elaborato e quindi verrà scartato.", nomeFile))
                ElseIf Specifica.FileCanUpload(nome) = False Then
                    Globale.Log.Trace(String.Format("Manca la specifica di importazione del file {0} e quindi verrà scartato.", nomeFile))
                Else
                    Globale.Log.Trace(String.Format("Il file {0} è stato inserito nella lista dei file in arrivo da importare.", nomeFile))
                    Globale.Report.ArchiviInArrivoCount += 1
                    With GetArchivio(nomeFile)
                        .Scaricato = True
                    End With
                End If
            Next
        Next
        Globale.Log.Info("CaricaListaScaricati: fine")
    End Sub

    Public Sub CaricaListaArchiviati()
        Globale.Log.Info("CaricaListaArchiviati: inizio")
        'pulizia
        For Each Codice In Agenzia.Config
            For Each file In IO.Directory.GetFiles(Codice.Cartelle.ArchivioFileOmnia, "ME*.ZIP")
                IO.File.Delete(file)
            Next
        Next
        'carica lista
        For Each Codice In Agenzia.Config
            For Each file In IO.Directory.GetFiles(Codice.Cartelle.ArchivioFileOmnia)
                Dim nomefile = IO.Path.GetFileName(file)
                Dim nome As String = Archivio.NomeSenzaEstenzioneZip(nomefile)

                If FileDaElaborare(nome) = False Then
                    Globale.Log.Trace(String.Format("Il file {0} non puo essere elaborato e quindi verrà scartato.", nomefile))
                ElseIf Specifica.FileCanUpload(nome) = False Then
                    Globale.Log.Trace(String.Format("Manca la specifica di importazione del file {0} e quindi verrà scartato.", nomefile))
                Else
                    Globale.Log.Trace(String.Format("Il file {0} è stato inserito nella lista dei file nella lista degli archiviati.", nomefile))
                    Globale.Report.ArchiviInStoricoCount += 1
                    With GetArchivio(nomefile)
                        .Archiviato = True
                    End With
                End If
            Next
        Next
        Globale.Log.Info("CaricaListaArchiviati: fine")
    End Sub

    Public Sub CaricaListaImportati()
        Globale.Log.Info("CaricaListaImportati: inizio")

        DataUltimaEstrazione = Date.MinValue

#If DEBUG Then
        'per test
        'Utx.WsCommand.ExecuteNonQueryMA({"delete from arp002_file where dataestrazione >='31/08/2022'"}, Agenzia:=Agenzia.CodiceAgenziaFiglia)
#End If

        Dim Query As String = String.Format("SELECT DISTINCT Nome, CodTipoFile, DataCreazione, DataEstrazione, DataImportazione 
                FROM MA{0}.dbo.ARP002_File 
                WHERE LEFT(Nome,2) <> 'ME' AND numerorecords > 0
                UNION
                SELECT DISTINCT Nome, CodTipoFile, DataCreazione, DataEstrazione, DataImportazione 
                FROM MA00000.dbo.ARP002_File 
                WHERE LEFT(Nome,2) = 'ME' AND numerorecords > 0", Agenzia.CodiceAgenziaFiglia)
        Dim Risposta As Utx.ServiziOMW.Risposta = Utx.WsCommand.ExecuteNonQueryMA({Query}, {"MA"}, Agenzia.CodiceAgenziaFiglia)
        Dim files As DataTable = Risposta.DataSet.Tables("MA")

#If DEBUG Then
        'Dim f As New Utx.FormDebug(files)
        'f.ShowDialog()
#End If

        For Each file As DataRow In files.Rows
            Dim nomefile As String = file("Nome").ToString
            Globale.Log.Trace(String.Format("Il file {0} è stato inserito nella lista degli importati.", nomefile))

            With GetArchivio(nomefile)
                .Importato = True
                Globale.Report.ArchiviImportatiCount += 1
                If file("DataEstrazione") IsNot Nothing Then .DataEstrazione = CDate(file("DataEstrazione"))
                If file("CodTipoFile") IsNot Nothing Then .Tipo = file("CodTipoFile").ToString
                If file("DataImportazione") IsNot Nothing Then .DataImportazione = CDate(file("DataImportazione"))
                If .DataEstrazione > DataUltimaEstrazione Then
                    DataUltimaEstrazione = .DataEstrazione
                End If
            End With
            If nomefile.ToUpper.EndsWith(".ZIP") = False Then
                nomefile = nomefile.ToUpper.Replace(".", "") & ".ZIP"
                With GetArchivio(nomefile)
                    .Importato = True
                    If file("DataEstrazione") IsNot Nothing Then .DataEstrazione = CDate(file("DataEstrazione"))
                    If file("CodTipoFile") IsNot Nothing Then .Tipo = file("CodTipoFile").ToString
                    If file("DataImportazione") IsNot Nothing Then .DataImportazione = CDate(file("DataImportazione"))
                    If .DataEstrazione > DataUltimaEstrazione Then
                        DataUltimaEstrazione = .DataEstrazione
                    End If
                End With
            End If
        Next
        Globale.Log.Info("CaricaListaImportati: fine")
    End Sub

    Public Function GetArchivio(Nome As String) As Archivio
        Nome = Nome.ToUpper
        If Not Me.ContainsKey(Nome) Then
            Globale.Log.Trace(String.Format("Il file {0} è stato inserito nella lista dei file.", Nome))
            Me.Add(Nome, New Archivio(Me, Agenzia, Nome))
        Else
            Globale.Log.Trace(String.Format("Il file {0} è già presente nella lista dei file.", Nome))
        End If

        Return Me.Item(Nome)
    End Function

    Public Sub Reimporta()
        On Error Resume Next
        If NomeSimbolicoInizioImportazione <> Nothing Then
            Globale.Log.Info(String.Format("VENGONO IMPORTATI I FILE A PARTIRE DA {0} a {1}", NomeSimbolicoInizioImportazione, NomeSimbolicoFineImportazione))
            For Each archivio In Me.Values
                If Globale.ArrestaImportazione = True Then Exit For

                If archivio.NomeSenzaEstenzioneZip.CompareTo(NomeSimbolicoInizioImportazione) >= 0 _
                    And archivio.NomeSenzaEstenzioneZip.CompareTo(NomeSimbolicoFineImportazione) <= 0 Then
                    Globale.Log.Trace("File da reimportare: " & archivio.Nome)
                    If archivio.Esiste = False Then
                        'se il file non è già stato scaricato lo scarica
                        UniFeed.DownloadHttp(archivio.Nome, archivio.Cartelle.ArchivioFileOmnia)
                    End If
                    archivio.Importato = False
                End If
            Next
        Else
            Globale.Log.Trace("Nessuna forzatura per la reimportare dei file")
        End If
    End Sub

    Public Sub InviaFileMaToSia()
        Try
            Globale.Log.Info()

            For Each config In Agenzia.Config
                'se è abilitata nel config leggiamo la data di inizio. in caso di NON abilitazione il servizio ritorna 31/12/2100
                Dim Inizio As Date = Utx.SIA.InizioInvioMA(config.AgenziaCollegata)

                If Inizio <= Today Then
                    Globale.Log.Info("Invio file MA a SIA codice {0} dal {1} al {2}", {config.AgenziaCollegata, Format(Inizio, "dd/MM/yyyy"), Format(Today, "dd/MM/yyyy")})
                    'leggo file già inviati
                    Dim ListaFileInviati As String() = Utx.SIA.ListaFileInviati(config.AgenziaCollegata, Inizio, Today, Utx.SIA.TipoFiltro.INIZIA, "MA")
                    Globale.Log.Info("File MA già inviati: {0}", {ListaFileInviati.Length.ToString})

                    Globale.Log.Info("Carica lista archivi inviati")
                    Dim fileInviati As New List(Of String)

                    For Each file In ListaFileInviati
                        file = file.ToUpper.Replace("MA_", "MA1")
                        fileInviati.Add(Archivio.NomeSenzaEstenzioneZip(IO.Path.GetFileName(file)))
                    Next

                    Dim InizioImportazione As String = Format(Inizio, "yyMMdd")
                    Dim FineImportazione As String = Format(Today, "yyMMdd")

                    For Each archivio In Me.Values
                        If archivio.Nome.StartsWith("MA") AndAlso archivio.Nome.ToUpper.EndsWith(".ZIP") Then
                            If archivio.Nome.Substring(3, 5).Equals(config.AgenziaCollegata) Then
                                If archivio.Nome.Substring(8, 6).CompareTo(InizioImportazione) >= 0 _
                                        And archivio.Nome.Substring(8, 6).CompareTo(FineImportazione) <= 0 Then

                                    If Globale.ArrestaImportazione = True Then Exit For

                                    If Not fileInviati.Contains(archivio.NomeSenzaEstenzioneZip) Then
                                        InviaFile(archivio)
                                    Else
                                        Globale.Log.Trace("File {0} già inviato", {archivio.Nome})
                                    End If
                                End If
                            End If
                        End If
                    Next
                Else
                    Globale.Log.Info("Invio file MA a SIA codice {0} BLOCCATO. Previsto dal {1}", {config.AgenziaCollegata, Format(Inizio, "dd/MM/yyyy")})
                End If
            Next
        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            Globale.Log.Info()
        End Try
    End Sub

    Private Sub InviaFile(archivio As Archivio)
        Dim Esito As String = Utx.SIA.InviaFileMA(Agenzia.CodiceAgenziaFiglia, archivio.NomeFileCompleto, False)
        Globale.Log.Info("Invio file {0} - Esito: {1}", {archivio.Nome, Esito})
    End Sub

    Public Sub Decomprimi()
        Dim listafiles As New List(Of String)

        For Each Codice In Agenzia.Config
            Utx.NetFunc.SvuotaCartella(Codice.Cartelle.CartellaArriviLocaleTempOmnia)
        Next

        For Each archivio In Me.Values
            If Globale.ArrestaImportazione = True Then Exit For
            If archivio.Compresso = True Then
                If archivio.Importato = False Then
                    Globale.NotificaShow("Decompressione file " & archivio.Nome)
                    Globale.Log.Info("Decompressione file " & archivio.Nome)

                    Dim inizioProcesso As Long = Now.Ticks
                    listafiles.AddRange(Utx.LibreriaZip.SevenZip.UnZipFile(archivio.NomeFileCompleto, archivio.Cartelle.CartellaArriviLocaleTempOmnia))
                    Globale.Log.Trace(String.Format("Decompressione del file {0} effettuata in {1} ms.", archivio.Nome, (Now.Ticks - inizioProcesso) \ TimeSpan.TicksPerMillisecond))
                    archivio.SalvaNelDB(New Report)
                End If
                archivio.Archivia()
            End If
        Next

        ' i file non possono essere aggiunti all'interno di un ciclo for/next della stessa lista
        If listafiles.Count = 0 Then
            Globale.Log.Trace("Nessun file da decomprimere")
        Else
            Globale.Log.Info("Creazione lista file da importare")
            For Each nomeFile In listafiles
                If FileDaElaborare(nomeFile) = False Then
                    Globale.Log.Trace(String.Format("Il file {0} non puo essere elaborato e quindi verrà scartato.", nomeFile))
                ElseIf Specifica.FileCanUpload(nomeFile) = False Then
                    Globale.Log.Trace(String.Format("Manca la specifica di importazione del file {0} e quindi verrà scartato.", nomeFile))
                Else
                    Globale.Log.Trace(String.Format("Il file {0} sarà inserito nella lista dei file in arrivo da importare.", nomeFile))
                    With GetArchivio(nomeFile)
                        .Decompresso = True
                        .OriginatoDaFileCompresso = True
                        .Importato = False
                    End With
                End If
            Next
        End If
    End Sub

    Public Function ArchiviDaScaricare() As List(Of Archivio)
        Dim archivi As New List(Of Archivio)

        For Each archivio In Me.Values
            If archivio.Disponibile = True AndAlso
                archivio.Importato = False Then
                archivi.Add(archivio)
            End If
        Next

        Return archivi
    End Function

    Public Sub Download()
        Globale.Report.InizioDownload = Now
        Dim DaScaricare = ArchiviDaScaricare()
        With DaScaricare
            Globale.Report.NumeroFileDaScaricare = .Count

            If Globale.Report.NumeroFileDaScaricare > 0 Then
                For Each archivio In DaScaricare
                    If Globale.ArrestaImportazione = True Then Exit For
                    If archivio.Download() = True Then
                        Globale.Report.NumeroFileScaricati += 1
                    End If
                Next
            Else
                Globale.Log.Trace("Nessun file da scaricare")
            End If
        End With
        Globale.Report.FineDownload = Now
    End Sub

    Public Function ArchiviDaImportare() As List(Of Archivio)
        Dim archivi As New List(Of Archivio)

        For Each archivio In Me.Values
            If archivio.Importato = False Then
                If IO.File.Exists(archivio.NomeFileCompleto) Then
                    archivi.Add(archivio)
                End If
            End If
        Next

        ' funzione completa
        'archivi.Sort(Function(x As Archivio, y As Archivio)
        '                 If x.Nome Is Nothing AndAlso y.Nome Is Nothing Then
        '                     Return 0
        '                 ElseIf x.Nome Is Nothing Then
        '                     Return -1
        '                 ElseIf y.Nome Is Nothing Then
        '                     Return 1
        '                 Else
        '                     Return x.Nome.CompareTo(y.Nome)
        '                 End If
        '             End Function)


        archivi.Sort(Function(x As Archivio, y As Archivio)
                         Return x.Nome.CompareTo(y.Nome)
                     End Function)
        Log.Trace("ArchiviDaImportare().Count = " & archivi.Count)
        Return archivi
    End Function

    Public Sub Importa()

        Globale.Report.InizioImportazione = Now
        Dim DaImportare = ArchiviDaImportare()
        With DaImportare
            Globale.Report.NumeroFileDaImportare = .Count
            Globale.Report.NumeroRecordDaImportare = 0

            If DaImportare.Count > 0 Then
                'pre-elaborazione database
                If Specifica.PreImportazione.Count > 0 Then
                    Globale.Log.Trace("ELABORAZIONI PRE-IMPORTAZIONI:")
                    For Each sql As String In Specifica.PreImportazione
                        Globale.Log.Trace(sql & IIf(Database.Aggiorna(sql), ": OK", ": KO").ToString)
                    Next
                Else
                    Globale.Log.Trace("NESSUNA ELABORAZIONE CONFIGURATA PER LA PRE-IMPORTAZIONE")
                End If

                Globale.Report.NumeroRecordDaImportare = 0
                Dim FileDaImportare As Integer = .Count

                For Each archivio In DaImportare
                    If Utx.Globale.SessioneCorrente.RichiestaChiusura = True Then
                        Globale.OmniaLog.Info("*** Importazione interrotta su richiesta dell'utente")
                        Exit For
                    End If

                    Globale.NotificaShow("Importazione file " & archivio.Nome)
                    Globale.Log.Info("file MA ancora da importare: {0}", {FileDaImportare.ToString})
                    Globale.OmniaLog.Info("Importazione file " & archivio.Nome)

                    Dim report = New Report
                    If archivio.Importa(report) Then
                        archivio.Archivia()
                        archivio.SalvaNelDB(report)
                        Globale.Report.NumeroFileImportati += 1
                    Else
                        Globale.Report.NumeroFileNonImportati += 1
                    End If

                    For Each dettaglio In report.DettaglioPerTipoRecord
                        If Globale.Report.DettaglioPerTipoRecord.ContainsKey(dettaglio.Key) Then
                            Globale.Report.DettaglioPerTipoRecord(dettaglio.Key) += dettaglio.Value
                        Else
                            Globale.Report.DettaglioPerTipoRecord.Add(dettaglio.Key, dettaglio.Value)
                        End If
                    Next
                    FileDaImportare -= 1

                    Globale.Report.NumeroRecordScartati += report.NumeroRecordScartati
                    Globale.Report.NumeroRecordImportati += report.NumeroRecordImportati
                    Globale.Report.NumeroRecordNonImportati += report.NumeroRecordNonImportati
                    Globale.Report.NumeroRecordEsclusi += report.NumeroRecordEsclusi
                    Globale.Report.NumeroRecordObsolete += report.NumeroRecordObsolete
                Next

                'post-elaborazione database
                If Specifica.PostImportazione.Count > 0 Then
                    Globale.Log.Trace("ELABORAZIONI POST-IMPORTAZIONI:")
                    For Each sql As String In Specifica.PostImportazione
                        Globale.Log.Trace(sql & IIf(Database.Aggiorna(sql), ": OK", ": KO"))
                    Next
                Else
                    Globale.Log.Trace("NESSUNA ELABORAZIONE CONFIGURATA PER LA POST-IMPORTAZIONE")
                End If
                'copio il dato consolidato dell'ultimo flusso mensile sul successivo settimanale
                Dim norma As String = "UPDATE Sinistri AS A " +
                                      "INNER JOIN ( " +
                                      "SELECT Compagnia,AgenziaSinistro,EsercizioSinistro,NumeroSinistro,TipoSinistro,TipoCid,FlagCosePersone,CognomeControparte," +
                                             "NomeControparte,CodiceFiscaleControparte,AgenziaPolizzaArrivo,TipologiaDenuncia,PresentatoreDenuncia,NumeroCartellaSertel," +
                                             "ContatoreSinistri,IndicatoreNoCard,ImportoRiserva,RamoGestione " +
                                      "FROM Sinistri " +
                                      "WHERE TipoElaborazione = '92' AND DataElaborazione = (SELECT MAX(DataElaborazione) FROM Sinistri WHERE TipoElaborazione = '92')) AS B " +
                                      "ON A.Compagnia=B.Compagnia AND A.AgenziaSinistro=B.AgenziaSinistro AND A.EsercizioSinistro=B.EsercizioSinistro AND A.NumeroSinistro=B.NumeroSinistro " +
                                      "SET A.TipoSinistro = B.TipoSinistro,A.TipoCid = B.TipoCid,A.FlagCosePersone = B.FlagCosePersone," +
                                          "A.CognomeControparte = B.CognomeControparte,A.NomeControparte = B.NomeControparte," +
                                          "A.CodiceFiscaleControparte = B.CodiceFiscaleControparte,A.AgenziaPolizzaArrivo = B.AgenziaPolizzaArrivo," +
                                          "A.TipologiaDenuncia = B.TipologiaDenuncia,A.PresentatoreDenuncia = B.PresentatoreDenuncia," +
                                          "A.NumeroCartellaSertel = B.NumeroCartellaSertel,A.ContatoreSinistri = B.ContatoreSinistri," +
                                          "A.IndicatoreNoCard = B.IndicatoreNoCard,A.ImportoRiserva = B.ImportoRiserva,A.RamoGestione = B.RamoGestione " +
                                      "WHERE A.DataElaborazione > (SELECT MAX(DataElaborazione) FROM Sinistri WHERE TipoElaborazione = '92')"
                Globale.Log.Info("normalizza campi settimanali: " & Database.Aggiorna(norma))

                Database.InviaDbUno()
            Else
                Globale.Log.Trace("Nessun file da importare")
            End If
        End With
        Globale.Report.FineImportazione = Now
    End Sub

    Public Sub Archivia()
        For Each archivio In Me.Values
            archivio.Archivia()
        Next
    End Sub

    Public Function FileDaElaborare(ByRef filename As String) As Boolean
        If filename.ToUpper Like "M[AE]############.###" Then
            'MA1 02379 161215 .001
            If filename.Substring(8, 6) < "170101" Then
                Return False
            End If
            Dim codiceAgenzia = filename.Substring(3, 5)
            If codiceAgenzia = "00000" Then
                Return AgenziaMadre.AgenziaMadre = Agenzia.CodiceAgenziaFiglia
            Else
                Dim datafile As Date = Date.ParseExact(filename.Substring(8, 6), "yyMMdd", System.Globalization.CultureInfo.InvariantCulture)
                Return Agenzia.Config.Exists(Function(x) x.AgenziaCollegata.Equals(codiceAgenzia) And x.DataInizio <= datafile And x.DataFine >= datafile)
            End If
        Else
            Return False
        End If
    End Function

    Public Function FileRicevuti() As List(Of Archivio)

        Dim archivi As New List(Of Archivio)

        For Each archivio In Me.Values
            If archivio.Importato = False Then
                archivi.Add(archivio)
            End If
        Next
        Return archivi
    End Function

End Class
