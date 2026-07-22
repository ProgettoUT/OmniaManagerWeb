Public Class Scansione

    Private specifica As Specifica
    Public Agenzie As New List(Of String)
    Public TipiRecord As New List(Of String)
    Public ChiaveValore As New Dictionary(Of String, String)
    Public DataInizio As Date = #1/1/2001#
    Public DataFine As Date = #12/31/2099#
    Public Contiene As String = ""
    Private numeroRigheTrovate As Integer

    Private resultLog As Utx.ApplicationLog
    Public Event FileInElaborazione(nomefile As String, ByRef Cancel As Boolean)
    Public Event RigheElaborate(numeroRigheTrovate As Integer, RigheElaborate As Integer)
    Public TipoRecordDaCercare As String

    Private Cancel As Boolean = False

    Public Sub New()
        Globale.Log = New Utx.ApplicationLog("ScansioneFileMA")
        specifica = New Specifica()
    End Sub

    Public Function FileLog() As String
        Return resultLog.FullPathLogFile
    End Function

    Public Sub Cerca()
        Cancel = False
        numeroRigheTrovate = 0

        If TipiRecord.Count = 0 AndAlso ChiaveValore.Count = 0 AndAlso String.IsNullOrEmpty(Contiene) Then
            Return
        End If

        resultLog = New Utx.ApplicationLog("RisultatoRicerca", , , True)

        resultLog.Info("***********************************************************")

        For Each AgenziaCode As String In Agenzie
            resultLog.Info("* Cod Agenzia: " & AgenziaCode)
        Next
        If Not String.IsNullOrEmpty(Contiene) Then
            resultLog.Info("* Contiene   : " & Contiene)
        End If
        If DataInizio <> #1/1/2001# Then
            resultLog.Info("* Data Inizio: " & DataInizio.ToString("dd/MM/yyyy"))
        End If
        If DataFine <> #12/31/2099# Then
            resultLog.Info("* Data Fine  : " & DataFine.ToString("dd/MM/yyyy"))
        End If

        For Each TipoRecord As String In TipiRecord
            resultLog.Info("* Tipo Record: " & TipoRecord)
        Next

        For Each cv In ChiaveValore
            resultLog.Info("* " & cv.Key & " = " & cv.Value)
        Next

        If TipiRecord.Count = 1 Then
            Try
                resultLog.Info("*")
                Dim keyRecord As String = TipiRecord(0)
                Dim keyFile = keyRecord.Substring(0, keyRecord.IndexOf("/"))
                Dim keyTracciato = keyRecord.Substring(keyRecord.IndexOf("/"))
                Dim tracciato As Tracciato = specifica.Files.GetFile(keyFile).Tracciati(keyTracciato)
                TipoRecordDaCercare = keyTracciato.Substring(1, 2)

                For Each cv In ChiaveValore
                    With tracciato.Campi(cv.Key)
                        resultLog.Info(String.Format("* {0}: (Posizione = {1}, lunghezza = {2}, formato = {3})", .Nome, .Posizione, .Lunghezza, .Formato))
                    End With
                Next
            Catch ex As Exception

            End Try
        Else
            TipoRecordDaCercare = ""
        End If

        For Each CodiceAgenziaFiglia In Agenzie
            Dim agenziaFiglia As New Utx.AgenziaFigliaOmnia(CodiceAgenziaFiglia)
            CercaPerAgenzia(agenziaFiglia)
            If Cancel Then Exit For
        Next

        If Cancel Then
            resultLog.Info(">>> ricerca annullata <<<")
        End If

    End Sub


    Private Sub CercaPerAgenzia(Agenzia As Utx.AgenziaFigliaOmnia)
        'Globale.Log.Trace("CaricaListaArchiviati: inizio")
        resultLog.Info("*")
        resultLog.Info("* Cartella: " & Agenzia.CodiceAgenziaFiglia & " (" & Agenzia.Cartelle.ArchivioFileOmnia & ")")
        resultLog.Info("*")

        Try
            For Each file In IO.Directory.GetFiles(Agenzia.Cartelle.ArchivioFileOmnia)
                Dim nomefile = IO.Path.GetFileName(file)
                Dim nome As String = Archivio.NomeSenzaEstenzioneZip(nomefile)

                If FileDaElaborare(Agenzia, nome) Then

                    RaiseEvent FileInElaborazione(nome, Cancel)
                    If Cancel Then Exit For

                    Dim archivi As List(Of Archivio) = Decomprimi(Agenzia, New Archivio(Nothing, Agenzia, nomefile))

                    If archivi IsNot Nothing Then
                        For Each archivio In archivi
                            CercaNelFile(archivio)
                            IO.File.Delete(archivio.NomeFileCompleto)
                        Next
                    End If
                End If
            Next
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub


    Private Function FileDaElaborare(Agenzia As Utx.AgenziaFigliaOmnia, ByRef filename As String) As Boolean
        If (filename.ToUpper Like "M[ACE]############.###") = False Then
            Return False
        End If

        Dim codiceAgenzia = filename.Substring(3, 5)
        If codiceAgenzia <> "00000" And Not Agenzia.Config.Exists(Function(x) x.AgenziaCollegata.Equals(codiceAgenzia)) Then
            Return False
        End If


        If DataInizio = #1/1/2001# And DataFine = #12/31/2099# Then
            Return specifica.FileCanUpload(filename)
        End If

        Dim DataEstrazione As Date = Date.ParseExact(Mid(filename, 9, 6), "yyMMdd", Nothing)

        If DataEstrazione < DataInizio Then Return False
        If DataEstrazione > DataFine Then Return False

        Return specifica.FileCanUpload(filename)
    End Function

    Private Function Decomprimi(Agenzia As Utx.AgenziaFigliaOmnia, archivio As Archivio) As List(Of Archivio)
        Try
            Dim listafiles As New List(Of String)
            Dim archivi As New List(Of Archivio)

            If archivio.Compresso = True Then
                archivio.Archiviato = True
                listafiles.AddRange(Utx.LibreriaZip.SevenZip.UnZipFile(archivio.NomeFileCompleto, Agenzia.Cartelle.CartellaArriviLocaleTempOmnia))
            Else
                listafiles.Add(archivio.NomeFileCompleto)
            End If

            ' i file non possono essere aggiunti all'interno di un ciclo for/next della stessa lista
            For Each nomeFile In listafiles
                If FileDaElaborare(Agenzia, nomeFile) Then
                    Dim a As New Archivio(Nothing, Agenzia, nomeFile) With {.Decompresso = True}
                    archivi.Add(a)
                End If
            Next

            Return archivi

        Catch ex As Exception
            Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Private Function CercaNelFile(Archivio As Archivio) As Boolean
        Try
            Dim oFile As File
            Dim oTracciato As Tracciato
            Dim oTabella As Tabella

            oFile = specifica.Files.GetFileByPattern(Archivio.Nome)

            If oFile IsNot Nothing Then

                If oFile.TipoFile = File.TipoFileEnum.TipoFileTesto Then
                    Dim sRow As String
                    Dim ProgressivoFile As String = Archivio.Nome.Substring(8).Replace(".", "")

                    '+RaiseEvent Info("File " & archivio.Nome & ": inizio importazione.")
                    Using reader = New IO.StreamReader(Archivio.NomeFileCompleto)

                        Dim rownumber As Integer = 0

                        While (reader.Peek() <> -1)
                            sRow = reader.ReadLine()
                            rownumber += 1

                            If sRow.Length > 0 Then

                                Dim tipoRecord As String = oFile.GetTipoRecord(sRow)

                                If TipiRecord.Count = 0 OrElse TipoRecordDaCercare.Equals(tipoRecord) Then

                                    oTracciato = oFile.GetTracciatoByInput(sRow)
                                    If oTracciato IsNot Nothing Then

                                        Call ValorizzaCampi(oTracciato.Campi, sRow)

                                        For Each oTabella In oTracciato.Tabelle
                                            If oTabella.PerOccorrenzaDi = vbNullString Then
                                                oTracciato.ApplyValue(oTabella)
                                            Else
                                                For i As Integer = 1 To oTracciato.Campi(oTabella.PerOccorrenzaDi).Occorrenze
                                                    oTracciato.ApplyValue(oTabella, i)
                                                Next
                                            End If
                                        Next

                                        Dim found As Boolean = True

                                        If Not String.IsNullOrEmpty(Contiene) Then
                                            found = sRow.Contains(Contiene)
                                        End If

                                        If found = True And ChiaveValore.Count > 0 Then
                                            For Each cv In ChiaveValore
                                                If cv.Value.Length > 0 Then
                                                    If Not oTracciato.Campi.ContainsKey(cv.Key) OrElse Not (oTracciato.Campi(cv.Key).Valore.TrimEnd Like cv.Value) Then
                                                        found = False
                                                        Exit For
                                                    End If
                                                End If
                                            Next
                                        End If

                                        If found Then
                                            numeroRigheTrovate += 1
                                            RaiseEvent RigheElaborate(numeroRigheTrovate, rownumber)

                                            For Each cv In ChiaveValore
                                                If oTracciato.Campi.ContainsKey(cv.Key) Then
                                                    resultLog.Info(cv.Key & " = " & oTracciato.Campi(cv.Key).Valore.TrimEnd)
                                                End If
                                            Next
                                            resultLog.Info(Archivio.Nome & " - " & rownumber.ToString("00000") & ": " & sRow)
                                            resultLog.Info()
                                        End If

                                        'Else
                                        'Globale.Log.Info(String.Format("il file {0} ha un tipo record /{1}/L{2} non definito in specifica. Controllare.", Nome, tipoRecord, Len(sRow)))
                                    End If
                                End If 'tipo record
                            End If ' salta righe vuote
                        End While

                        reader.Close()
                        RaiseEvent RigheElaborate(numeroRigheTrovate, rownumber)
                    End Using
                End If
            End If
        Catch ex As Exception
            Log.Errore(ex)
        End Try

        Return True
    End Function

    Private Sub ValorizzaCampi(ByRef oCampi As Campi, ByRef sRow As String)

        For Each oCampo In oCampi.Values
            If Not oCampo.CampoCalcolato Then
                If oCampo.Occorrenze = 1 Then
                    If oCampo.HasChild Then
                        ValorizzaCampi(oCampo.Campi, sRow)
                    Else
                        oCampo.Valore = Mid(sRow, oCampo.Posizione, oCampo.Lunghezza)
                    End If
                Else
                    For i = 1 To oCampo.Occorrenze
                        With oCampo.Campi(oCampo.Nome & i)
                            If .HasChild Then
                                ValorizzaCampi(.Campi, sRow)
                            Else
                                .Valore = Mid(sRow, .Posizione, .Lunghezza)
                            End If
                        End With
                    Next
                End If
            End If
        Next
    End Sub

End Class
