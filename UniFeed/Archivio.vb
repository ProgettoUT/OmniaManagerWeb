Imports System.Data.OleDb
Imports System.IO.Compression
Imports UniFeed.Report

Class Archivio
    Public Archivi As Archivi
    Public Agenzia As Utx.AgenziaFigliaOmnia
    Public CodiceCollegato As String
    Public NomeOriginale As String
    Public Nome As String
    Public DataImportazione As Date
    Public DataEstrazione As Date
    Public Tipo As String

    Public FromUtools As Boolean = False
    Public Disponibile As Boolean 'il file è disponibile per il download dal server (di compagnia/agenzia)
    Public DisponibileDiscoK As Boolean 'il file è disponibile nel disco K, scaricato dalla direzione
    Public DisponibileDiscoKBackup As Boolean 'il file è disponibile nel disco K, scaricato dalla direzione
    Public Scaricato As Boolean   'il file è stato scaricato/decompresso e pronto per l'importazione
    Public Compresso As Boolean   'Se compresso, occorre scompattarlo
    Public Importato As Boolean   'il file è stato importato nel database
    Public Archiviato As Boolean  'il file è in archivio
    Public Decompresso As Boolean  'il file è in archivio

    Public OriginatoDaFileCompresso As Boolean  'il file è stato ottenuto da decompressione file e quindi non va archiviato, ma eliminato

    Public Database As Database
    Public Cartelle As Utx.CartelleAgenziaOmnia
    Public Configurazione As Utx.RecordConfigOmnia

    Private Enum StatoRiga As Integer
        OK
        KO
    End Enum


    Public Sub New(Archivi As Archivi, Agenzia As Utx.AgenziaFigliaOmnia, Nome As String)
        Me.Archivi = Archivi
        Me.Agenzia = Agenzia
        Me.Nome = Nome
        Me.CodiceCollegato = Nome.Substring(3, 5)
        If Me.CodiceCollegato = "00000" Then
            Me.CodiceCollegato = Agenzia.CodiceAgenziaFiglia
        End If
        Me.Cartelle = New Utx.CartelleAgenziaOmnia(CodiceCollegato)
        Me.Configurazione = Agenzia.Config.Find(Function(x) x.AgenziaCollegata.Equals(CodiceCollegato))
        Me.Compresso = FileDaScompattare(Nome)

        LeggiFileInfo()
    End Sub

    Public ReadOnly Property NomeFileInviato() As String
        Get
            Return IO.Path.Combine(Agenzia.Cartelle.ArchivioFileInviati, Nome)
        End Get
    End Property

    Public ReadOnly Property NomeFileCompleto() As String
        Get
            If Decompresso Then
                Return IO.Path.Combine(Cartelle.CartellaArriviLocaleTempOmnia, Nome)
            ElseIf Scaricato Then
                Return IO.Path.Combine(Cartelle.CartellaArriviLocaleAgenziaOmnia, Nome)
            ElseIf Archiviato Then
                Return IO.Path.Combine(Cartelle.ArchivioFileOmnia, Nome)
            ElseIf OriginatoDaFileCompresso Then
                Return IO.Path.Combine(Cartelle.CartellaArriviLocaleTempOmnia, Nome)
            ElseIf DisponibileDiscoK Then
                Return IO.Path.Combine(Cartelle.CartellaArriviDiscoK, Nome)
            ElseIf DisponibileDiscoKBackup Then
                Return IO.Path.Combine(Cartelle.CartellaArriviDiscoKBackup, NomeOriginale)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Private Sub LeggiFileInfo()

        'Dim tipofile As String() = Nothing

        'If Archivi IsNot Nothing Then
        '    tipofile = Archivi.GetMatchExps().Find(Function(x) Nome Like x(0))
        'End If

        'If tipofile IsNot Nothing Then
        '    Tipo = tipofile(1)
        'Else
        '    Tipo = "X01"
        'End If

        Tipo = "F01"
        Dim sData As String = Mid(Nome, 9, 6)

        If IsNumeric(sData) Then
            DataEstrazione = DateSerial(Left(sData, 2), Mid(sData, 3, 2), Right(sData, 2))
        Else
            DataEstrazione = Today
        End If
    End Sub

    Public Function Download() As Boolean
        Globale.OmniaLog.Info("Download file " & Nome)
        Globale.NotificaShow("Download file " & Nome)
        If DisponibileDiscoK = True Then
            Return DownloadDiscoK()
        ElseIf DisponibileDiscoKBackup = True Then
            Return DownloadDiscoKBackup()
        Else
            Return DownloadHttp()
        End If
    End Function

    Public Function DownloadDiscoK() As Boolean
        Dim nomeArrivo As String = IO.Path.Combine(Cartelle.CartellaArriviLocaleAgenziaOmnia, Nome)
        Try
            If Scaricato = False Then
                If IO.File.Exists(nomeArrivo) Then
                    IO.File.Delete(nomeArrivo)
                End If

                IO.File.Copy(NomeFileCompleto, nomeArrivo)

                LeggiFileInfo()
                Scaricato = True
                DisponibileDiscoK = False
            End If
        Catch e As Exception
            If IO.File.Exists(nomeArrivo) Then
                IO.File.Delete(nomeArrivo)
            End If
        End Try
        Return Scaricato
    End Function

    Public Function DownloadDiscoKBackup() As Boolean
        Dim nomeArrivo As String = IO.Path.Combine(Cartelle.CartellaArriviLocaleAgenziaOmnia, Nome)
        Try
            If Scaricato = False Then
                If IO.File.Exists(nomeArrivo) Then
                    IO.File.Delete(nomeArrivo)
                End If

                IO.File.Copy(NomeFileCompleto, nomeArrivo)

                LeggiFileInfo()
                Scaricato = True
                DisponibileDiscoKBackup = False
            End If
        Catch e As Exception
            If IO.File.Exists(nomeArrivo) Then
                IO.File.Delete(nomeArrivo)
            End If

        Finally
        End Try
        Return Scaricato
    End Function

    Public Function DownloadHttp() As Boolean
        Dim nomeArrivo As String = IO.Path.Combine(Cartelle.CartellaArriviLocaleAgenziaOmnia, Nome)
        Try
            If Scaricato = False Then
                If IO.File.Exists(nomeArrivo) Then
                    IO.File.Delete(nomeArrivo)
                End If

                Dim url As String = Nothing
                If FromUtools = True Then
                    url = String.Format("http://www.utools.it/Unitools/Download/OMNIA/{0}?GUID={1}", Nome, Archivi.Guid)
                ElseIf Utx.FunzioniRete.PcInDominio Then
                    url = UrlHttpInDominio & String.Format("GetFile.aspx?GUID={0}&FNAME={1}", Archivi.Guid, Nome)
                Else
                    url = UrlHttpInternet & String.Format("GetSingleFile.aspx?GUID={0}&FILENAME={1}", Archivi.Guid, Nome)
                End If

                'Globale.Log.Info("inizio Download:" & Nome)
                Dim inizioProcesso As Long = Now.Ticks

                Dim request = Net.WebRequest.Create(url)
                request.Method = Net.WebRequestMethods.Http.Get
                request.Proxy = Utx.Globale.UniProxy.GetProxy(url)
                request.Credentials = Utx.Globale.UtenteCorrente.Credenziali
                Dim response = request.GetResponse()

                Using writer As New IO.FileStream(nomeArrivo, IO.FileMode.Create)
                    Dim reader = response.GetResponseStream()

                    Dim buffer(1024) As Byte

                    Dim b = reader.Read(buffer, 0, 1024)
                    While b > 0
                        writer.Write(buffer, 0, b)
                        b = reader.Read(buffer, 0, 1024)
                    End While
                End Using

                response.Close()

                LeggiFileInfo()

                Scaricato = True
                Globale.Log.Info(String.Format("Download del file {0} eseguito in {1} ms.", Nome, (Now.Ticks - inizioProcesso) \ TimeSpan.TicksPerMillisecond))
            End If
        Catch e As Exception
            Globale.Log.Info(String.Format("errore Download {0}: {1}", Nome, e.Message))
            'Globale.InviaEmailAssistenza = True
            If IO.File.Exists(nomeArrivo) Then
                IO.File.Delete(nomeArrivo)
            End If

        Finally
        End Try
        Return Scaricato
    End Function


    'Public Function DownloadFtp() As Boolean
    '    Dim nomeArrivo As String = IO.Path.Combine(Agenzia.Cartelle.CartellaArriviLocaleAgenziaOmnia, Nome)
    '    Try
    '        If Scaricato = False Then
    '            Globale.Log.Info("inizio Download:" & Nome)
    '            Dim inizioProcesso As Long = Now.Ticks


    '            If IO.File.Exists(nomeArrivo) Then
    '                IO.File.Delete(nomeArrivo)
    '            End If

    '            Dim url As String = CartellaServerFtp & Nome

    '            Dim request = DirectCast(Net.WebRequest.Create(url), Net.FtpWebRequest)
    '            request.Credentials = New Net.NetworkCredential(Utx.Globale.UtenteCorrente.UniageUser, Utx.Globale.UtenteCorrente.UniagePw)
    '            'request.Proxy = Utx.Globale.UniProxy.Proxy
    '            request.Method = Net.WebRequestMethods.Ftp.DownloadFile
    '            request.UseBinary = True

    '            Dim response = DirectCast(request.GetResponse(), Net.FtpWebResponse)

    '            Using writer As New IO.StreamWriter(nomeArrivo)
    '                writer.Write(New IO.StreamReader(request.GetResponse().GetResponseStream).ReadToEnd)
    '            End Using

    '            response.Close()

    '            LeggiFileInfo()

    '            Scaricato = True
    '            Globale.Log.Info(String.Format("Download del file {0} terminato in {1} ms.", Nome, (Now.Ticks - inizioProcesso) \ TimeSpan.TicksPerMillisecond))
    '        End If
    '    Catch e As Exception
    '        Globale.Log.Info(String.Format("errore Download {0}: {1}", Nome, e.Message))
    '        'Globale.InviaEmailAssistenza = True
    '        If IO.File.Exists(nomeArrivo) Then
    '            IO.File.Delete(nomeArrivo)
    '        End If
    '    Finally
    '    End Try

    '    Return Scaricato
    'End Function

    Public Function Importa(Report As Report) As Boolean
        Dim oFile As File
        Dim oTracciato As Tracciato
        Dim oTabella As Tabella
        Dim RowTracciatoIsOk As StatoRiga

        Globale.Log.Info(String.Format("Inizio importazione del file {0}", Nome))
        Globale.OmniaLog.Info(String.Format("Inizio importazione del file {0}", Nome))
        Dim inizioProcesso As Long = Now.Ticks
        oFile = Archivi.Specifica.Files.GetFileByPattern(Nome)

        If oFile IsNot Nothing Then

            If oFile.TipoFile = File.TipoFileEnum.TipoFileTesto Then
                'controllo venerdì per bloccare il tipo record 91 sul fine mese
                Dim FineMese As Date = Utx.FunzioniData.FineMese(Today.AddMonths(-1))
                Dim Venerdi As Boolean = FineMese.DayOfWeek = DayOfWeek.Friday
                Dim Trova As String = $"{FineMese:yyyyMMdd}{Utx.Globale.AgenziaRichiesta.CodiceAgenzia}0191"
                '===================

                Dim sRow As String
                Dim ProgressivoFile As String = Nome.Substring(8).Replace(".", "")

                'RaiseEvent Info("File " & archivio.Nome & ": inizio importazione.")
                Dim righeLette As Long = 0
                Dim righeTotali As Long = FileLen(NomeFileCompleto)
                If Nome.StartsWith("ME") Then
                    righeTotali \= 102
                Else
                    righeTotali \= 6002
                End If

                Using reader = New IO.StreamReader(NomeFileCompleto)

                    While reader.Peek() <> -1
                        sRow = reader.ReadLine()

                        If Venerdi AndAlso sRow.StartsWith(Trova) Then
                            Continue While
                        End If

                        If sRow.Length > 0 Then
                            righeLette += 1

                            If righeLette Mod 500 = 0 Then
                                Globale.Log.Info(String.Format("File {0}: righe elaborate {1}/{2}", Nome, righeLette, righeTotali))
                                System.Windows.Forms.Application.DoEvents()
                            End If

                            Globale.Report.NumeroRecordDaImportare += 1
                            RowTracciatoIsOk = StatoRiga.OK

                            Dim tipoRecord As String = oFile.GetTipoRecord(sRow)

                            Dim ReportPerTipoRecord As Dettaglio

                            If Report.DettaglioPerTipoRecord.ContainsKey(tipoRecord) Then
                                ReportPerTipoRecord = Report.DettaglioPerTipoRecord(tipoRecord)
                            Else
                                ReportPerTipoRecord = New Dettaglio
                                Report.DettaglioPerTipoRecord.Add(tipoRecord, ReportPerTipoRecord)
                            End If

                            ReportPerTipoRecord.NumeroRecordDaImportare += 1
                            oTracciato = oFile.GetTracciatoByInput(sRow)

                            If (Archivi.TipiRecordsDaImportare IsNot Nothing) AndAlso (Not Archivi.TipiRecordsDaImportare.Contains(tipoRecord)) Then
                                Report.NumeroRecordEsclusi += 1
                                ReportPerTipoRecord.NumeroRecordEsclusi += 1

                            ElseIf oTracciato Is Nothing Then
                                Report.NumeroRecordScartati += 1
                                ReportPerTipoRecord.NumeroRecordScartati += 1
                                If Not Archivi.TipiRecordsScartati.Contains(tipoRecord) Then
                                    Archivi.TipiRecordsScartati.Add(tipoRecord)
                                    Globale.Log.Info(String.Format("il file {0} ha un tipo record /{1}/L{2} non definito in specifica. Controllare.", Nome, tipoRecord, Len(sRow)))
                                    Globale.OmniaLog.Info(String.Format("il file {0} ha un tipo record /{1}/L{2} non definito in specifica. Controllare.", Nome, tipoRecord, Len(sRow)))
                                    Globale.Log.Info(sRow)
                                    Globale.OmniaLog.Info(sRow)
                                End If

                            ElseIf oTracciato.Obsoleto = True Then
                                Report.NumeroRecordObsolete += 1
                                ReportPerTipoRecord.NumeroRecordObsolete += 1
                            Else
                                ' controlla se eliminare i dati nella tabella
                                If oTracciato.DeleteFirst Then
                                    If ReportPerTipoRecord.NumeroRecordDaImportare = 1 Then
                                        For Each oTabella In oTracciato.Tabelle
                                            Archivi.Database.Aggiorna("Delete from " & oTabella.Nome)
                                        Next
                                    End If
                                End If

                                ValorizzaCampi(oTracciato.Campi, 1, sRow)

                                '+step per verificare se riga è di competenza o meno
                                If ConsensoImportazione(oTracciato) = False Then
                                    'record non di competenza (nè sub, nè prod): salto
                                    Report.NumeroRecordSenzaConsenso += 1
                                    ReportPerTipoRecord.NumeroRecordSenzaConsenso += 1
                                Else
                                    If oTracciato.HaChiaviInterne Then
                                        oTracciato.ImpostaParametriChiaviInterne()
                                        Archivi.Database.TrovaChiaviInterne(oTracciato)
                                    End If

                                    For Each oTabella In oTracciato.Tabelle
                                        If oTabella.Operazione <> "N" Then
                                            If oTabella.PerOccorrenzaDi = vbNullString Then
                                                oTracciato.ApplyValue(oTabella)

                                                If oTabella.ImportaIsOk() Then
                                                    If oTabella.Campi.ContainsKey("ProgressivoFile") Then
                                                        oTabella.Campi("ProgressivoFile").Valore = ProgressivoFile
                                                    End If
                                                    If Not Archivi.Database.Aggiorna(oTabella) Then
                                                        Globale.Log.Info(sRow)
                                                        If Archivi.Database.HasErrors Then
                                                            'If Archivi.Database.ErrorNumber <> -2147467259 Then
                                                            Globale.Log.Info(Archivi.Database.GetSql(oTabella))
                                                            Globale.Log.Info(Archivi.Database.ErrorDescription)
                                                            RowTracciatoIsOk = StatoRiga.KO
                                                            'End If
                                                        End If
                                                    End If
                                                End If
                                            Else
                                                Dim i As Integer
                                                For i = 1 To oTracciato.Campi(oTabella.PerOccorrenzaDi).Occorrenze
                                                    oTracciato.ApplyValue(oTabella, i)
                                                    If oTabella.ImportaIsOk() Then
                                                        If Not Archivi.Database.Aggiorna(oTabella) Then
                                                            Globale.Log.Info(sRow)
                                                            If Archivi.Database.HasErrors Then
                                                                'If Archivi.Database.ErrorNumber <> -2147467259 Then
                                                                Globale.Log.Info(Archivi.Database.GetSql(oTabella))
                                                                Globale.Log.Info(Archivi.Database.ErrorDescription)
                                                                RowTracciatoIsOk = StatoRiga.KO
                                                                'End If
                                                            End If
                                                        End If
                                                    End If
                                                Next
                                            End If
                                        End If
                                    Next 'tabella
                                    If RowTracciatoIsOk = StatoRiga.OK Then
                                        Report.NumeroRecordImportati += 1
                                        ReportPerTipoRecord.NumeroRecordImportati += 1
                                    ElseIf RowTracciatoIsOk = StatoRiga.KO Then
                                        Report.NumeroRecordNonImportati += 1
                                        ReportPerTipoRecord.NumeroRecordNonImportati += 1
                                        Globale.Log.Info("ERRORE:" & sRow)
                                        Globale.OmniaLog.Info("ERRORE:" & sRow)
                                        '26-09-17: le convenzioni contengono un sacco di errori
                                        'ho deciso di scartarle (per adesso)
                                        '04-12-17: se errore nei file, interrompo l'importazione
                                        '03-10-18: Troppi errori su record 18.
                                        'Globale.Log.Info(String.Format("!!!IMPORTAZIONE FILE {0} INTERROTTA!!!", Me.Nome))
                                        'Globale.OmniaLog.Info(String.Format("!!!IMPORTAZIONE FILE {0} INTERROTTA!!!", Me.Nome))
                                        'Globale.InviaEmailAssistenza = True
                                        'Return False

                                        Globale.InviaEmailAssistenza = True
                                        StampaCampi(oTracciato.Campi, 1, sRow)
                                    End If
                                End If
                            End If
                        End If ' salta righe vuote
                    End While
                    Globale.Log.Info(String.Format("File {0}: righe elaborate {1}/{2}", Nome, righeTotali, righeTotali))
                    reader.Close()
                End Using

                '+RaiseEvent Info("File " & archivio.Nome & ": importazione terminata.")
            End If
        End If

        Globale.Log.Info(String.Format("Importazione del file {0} terminata in {1} ms. Importati {2} records.", Nome, (Now.Ticks - inizioProcesso) \ TimeSpan.TicksPerMillisecond, Report.NumeroRecordImportati))
        Return True
    End Function

    Private Sub ValorizzaCampi(ByRef oCampi As Campi, ByRef nPos As Integer, ByRef sRow As String)

        For Each oCampo In oCampi.Values
            If Not oCampo.CampoCalcolato Then
                If oCampo.Occorrenze = 1 Then
                    If oCampo.HasChild Then
                        ValorizzaCampi(oCampo.Campi, nPos, sRow)
                    Else
                        oCampo.Valore = Mid(sRow, nPos, oCampo.Lunghezza)
                        'Debug.Print(Format(nPos, "0000") & ": " & oCampo.DettaglioCampo4Debug())
                        nPos += oCampo.Lunghezza
                    End If
                Else
                    For i = 1 To oCampo.Occorrenze
                        With oCampo.Campi(oCampo.Nome & i)
                            If .HasChild Then
                                ValorizzaCampi(.Campi, nPos, sRow)
                            Else
                                .Valore = Mid(sRow, nPos, .Lunghezza)
                                'Debug.Print(Format(nPos, "0000") & ": " & oCampo.DettaglioCampo4Debug())
                                nPos += .Lunghezza
                            End If
                        End With
                    Next
                End If
            End If
        Next
    End Sub

    Public Function ConsensoImportazione(tracciato As Tracciato) As Boolean
        If Configurazione Is Nothing Then
            Return False
        End If

        If Configurazione.ListaSub.Count = 0 AndAlso Configurazione.ListaProd.Count = 0 Then
            Return True
        End If


        Dim CodiceSubagente As String = "0"
        Dim CodiceProduttore As String = "0"

        With tracciato.Campi
            If .ContainsKey("CodiceSubagente") Then
                CodiceSubagente = .Item("CodiceSubagente").Valore
            ElseIf .ContainsKey("CodiceSubagenzia") Then
                CodiceSubagente = .Item("CodiceSubagenzia").Valore
            ElseIf .ContainsKey("Subagenzia") Then
                CodiceSubagente = .Item("Subagenzia").Valore
            End If
            If .ContainsKey("CodiceProduttore") Then
                CodiceProduttore = .Item("CodiceProduttore").Valore
            End If
        End With

        If CodiceSubagente = "0" AndAlso CodiceProduttore = "0" Then
            Return True
        Else
            Return Configurazione.ConsensoImportazione(CodiceSubagente, CodiceProduttore)
        End If
    End Function

    Public Function SalvaNelDB(Report As Report) As Boolean
        'Aggiungere i seguenti campi in dbuno
        'ALTER TABLE arp002_file ADD COLUMN RecordsImportati INTEGER;
        'ALTER TABLE arp002_file ADD COLUMN RecordsScartati INTEGER;
        Try
            Using adapter As New OleDbDataAdapter("SELECT * FROM ARP002_File WHERE NOME = " & Utx.FunzioniDb.TO_STRING(Nome), Agenzia.Connessione)
                Using builder As New OleDbCommandBuilder(adapter)
                    Dim dt As New DataTable
                    adapter.Fill(dt)

                    If Report.DettaglioPerTipoRecord.Count = 0 Then
                        'elimina le righe
                        For Each row As DataRow In dt.Select("CodTipoRecord = '00'")
                            row.Delete()
                        Next

                        Dim newrow = dt.NewRow()
                        newrow("Nome") = Nome
                        newrow("DataEstrazione") = DataEstrazione
                        newrow("CodTipoFile") = Tipo
                        newrow("DataImportazione") = Today
                        newrow("CodTipoRecord") = "00"
                        newrow("NumeroRecords") = "0"
                        newrow("RecordsImportati") = "0"
                        newrow("RecordsScartati") = "0"
                        dt.Rows.Add(newrow)
                    Else
                        For Each tiporecord In Report.DettaglioPerTipoRecord
                            For Each row As DataRow In dt.Select("CodTipoRecord = '" + tiporecord.Key + "'")
                                row.Delete()
                            Next
                        Next
                        For Each tiporecord In Report.DettaglioPerTipoRecord
                            Dim newrow = dt.NewRow()
                            newrow("Nome") = Nome
                            newrow("DataEstrazione") = DataEstrazione
                            newrow("CodTipoFile") = Tipo
                            newrow("DataImportazione") = Today
                            newrow("CodTipoRecord") = tiporecord.Key
                            newrow("NumeroRecords") = tiporecord.Value.NumeroRecordDaImportare
                            newrow("RecordsImportati") = tiporecord.Value.NumeroRecordImportati
                            newrow("RecordsScartati") = tiporecord.Value.NumeroRecordScartati +
                            tiporecord.Value.NumeroRecordEsclusi +
                            tiporecord.Value.NumeroRecordNonImportati +
                            tiporecord.Value.NumeroRecordObsolete
                            dt.Rows.Add(newrow)
                        Next
                    End If

                    adapter.Update(dt)
                    Importato = True
                End Using
            End Using

        Catch ex As Exception
            Globale.Log.Info(ex.Message)
        End Try

        Return True
    End Function

    Public Function Archivia() As Boolean
        Try
            'If Scaricato = True Then
            If Esiste() Then
                Dim nomeStorico As String

                Dim inizioProcesso As Long = Now.Ticks

                If OriginatoDaFileCompresso = True Then
                    IO.File.Delete(NomeFileCompleto)
                    Globale.Log.Trace(String.Format("Il file {0} è stato eliminato in {1} ms.", Nome, (Now.Ticks - inizioProcesso) \ TimeSpan.TicksPerMillisecond))
                ElseIf Compresso = False Then
                    nomeStorico = IO.Path.Combine(Cartelle.ArchivioFileOmnia, Nome.Replace(".", "") & ".ZIP")
                    If IO.File.Exists(nomeStorico) Then
                        IO.File.Delete(NomeFileCompleto)
                    Else
                        If Utx.LibreriaZip.SevenZip.ZipFile(NomeFileCompleto, nomeStorico) Then
                            IO.File.Delete(NomeFileCompleto)
                        End If
                    End If
                    Globale.Log.Trace(String.Format("Il file {0} è stato compresso e archiviato in {1} ms.", Nome, (Now.Ticks - inizioProcesso) \ TimeSpan.TicksPerMillisecond))
                    Globale.OmniaLog.Info(String.Format("Il file {0} è stato compresso e archiviato.", Nome))
                Else
                    nomeStorico = IO.Path.Combine(Cartelle.ArchivioFileOmnia, Nome)
                    If NomeFileCompleto <> nomeStorico Then
                        If IO.File.Exists(nomeStorico) Then
                            IO.File.Delete(nomeStorico)
                        End If

                        If DisponibileDiscoK Or DisponibileDiscoKBackup Then
                            IO.File.Copy(NomeFileCompleto, nomeStorico)
                        Else
                            IO.File.Move(NomeFileCompleto, nomeStorico)
                        End If
                        Globale.Log.Trace(String.Format("Il file {0} è stato archiviato in {1} ms.", Nome, (Now.Ticks - inizioProcesso) \ TimeSpan.TicksPerMillisecond))
                    Else
                        Globale.Log.Trace(String.Format("Il file {0} è già in archivio.", Nome))
                    End If
                End If

                Archiviato = True
                Scaricato = False
            End If
            'End If
        Finally
        End Try
        Return Archiviato
    End Function

    Public Function Esiste() As Boolean
        Return IO.File.Exists(NomeFileCompleto)
    End Function

    Public Function FileDaScompattare(Nome As String) As Boolean
        Nome = Nome.ToUpper
        If Nome Like "M[AEC]###############.ZIP" Then
            Return True
        ElseIf Nome Like "M[AEC]###############.7Z" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function NomeSenzaEstenzioneZip(Nome As String) As String
        Nome = Nome.ToUpper
        If Nome Like "M[AEC]###############.ZIP" Then
            Return Nome.Substring(0, 14) & "." & Nome.Substring(14, 3)
        ElseIf Nome Like "M[AEC]###############.7Z" Then
            Return Nome.Substring(0, 14) & "." & Nome.Substring(14, 3)
        Else
            Return Nome
        End If
    End Function

    Public Function NomeSenzaEstenzioneZip() As String
        Return NomeSenzaEstenzioneZip(Nome)
    End Function

    Private Sub StampaCampi(ByRef oCampi As Campi, ByRef nPos As Integer, ByRef sRow As String)

        For Each oCampo In oCampi.Values
            If Not oCampo.CampoCalcolato Then
                If oCampo.Occorrenze = 1 Then
                    If oCampo.HasChild Then
                        StampaCampi(oCampo.Campi, nPos, sRow)
                    Else
                        oCampo.Valore = Mid(sRow, nPos, oCampo.Lunghezza)
                        Globale.Log.Info(Format(nPos, "00000") & ": " & oCampo.DettaglioCampo4Debug())
                        nPos = nPos + oCampo.Lunghezza
                    End If
                Else
                    For i = 1 To oCampo.Occorrenze
                        With oCampo.Campi(oCampo.Nome & i)
                            If .HasChild Then
                                StampaCampi(.Campi, nPos, sRow)
                            Else
                                .Valore = Mid(sRow, nPos, .Lunghezza)
                                Globale.Log.Info(Format(nPos, "00000") & ": " & oCampo.DettaglioCampo4Debug())
                                nPos = nPos + .Lunghezza
                            End If
                        End With
                    Next
                End If
            End If
        Next
    End Sub

    Public Shared Function DownloadHttp(nomefile As String, cartellaDownload As String) As Boolean
        Dim nomeArrivo As String = IO.Path.Combine(cartellaDownload, nomefile)
        Dim guid As String = System.Guid.NewGuid.ToString

        Try
            If IO.File.Exists(nomeArrivo) Then
                IO.File.Delete(nomeArrivo)
            End If

            Dim url As String = Nothing
            If Utx.FunzioniRete.PcInDominio Then
                url = UrlHttpInDominio & String.Format("GetFile.aspx?GUID={0}&FNAME={1}", guid, nomefile)
            Else
                url = UrlHttpInternet & String.Format("GetSingleFile.aspx?GUID={0}&FILENAME={1}", guid, nomefile)
            End If

            'Utx.Globale.Log.Info("inizio Download:" & nomefile)
            Dim inizioProcesso As Long = Now.Ticks

            Dim request = Net.WebRequest.Create(url)
            request.Method = Net.WebRequestMethods.Http.Get
            request.Proxy = Utx.Globale.UniProxy.GetProxy(url)
            request.Credentials = Utx.Globale.UtenteCorrente.Credenziali
            Dim response = request.GetResponse()

            Using writer As New IO.FileStream(nomeArrivo, IO.FileMode.Create)
                Dim reader = response.GetResponseStream()

                Dim buffer(1024) As Byte

                Dim b = reader.Read(buffer, 0, 1024)
                While b > 0
                    writer.Write(buffer, 0, b)
                    b = reader.Read(buffer, 0, 1024)
                End While
            End Using

            response.Close()

            Utx.Globale.Log.Info(String.Format("Download del file {0} eseguito in {1} ms.", nomefile, (Now.Ticks - inizioProcesso) \ TimeSpan.TicksPerMillisecond))
            Return True

        Catch e As Exception
            Utx.Globale.Log.Errore(String.Format("errore Download {0}: {1}", nomefile, e.Message))
            If IO.File.Exists(nomeArrivo) Then
                IO.File.Delete(nomeArrivo)
            End If
        End Try
        Return False
    End Function
End Class
