Public Class Cumulatore
    Private Shared ReadOnly agenziaMadre As New Utx.AgenziaOmnia()
    Private ReadOnly dataEstrazione As String = Today.ToString("yyMMdd")
    Public Event FileInElaborazione(Agenzia As String, NomeFile As String, Progressivo As Integer, TotaleFile As Integer, ByRef Cancel As Boolean)

    Private Cancel As Boolean = False
    Private Shared Notifica As Utx.FormNotifica
    Private Shared WithEvents Cumulo As Cumulatore

    Shared Sub New()
        Globale.Log = New Utx.ApplicationLog("OmniaCumulatore", Nothing, Nothing, False, True)
    End Sub

    Public Shared Function getInstance() As Cumulatore
        Return New Cumulatore
    End Function

    Public Sub CreaFiles(Optional Agenzia As String = Nothing, Optional Tipo As FileCumulo.TipoCumulo = FileCumulo.TipoCumulo.TUTTI)
        Exit Sub '21/01/2023
        Globale.Log.Info("Creazione files cumulativi (MC.00X) - start")
        Try
            If Agenzia Is Nothing Then 'tutti i codici
                For Each CodiceAgenziaCollegata In agenziaMadre.AgenzieCollegate
                    CreaFilesTipo(CodiceAgenziaCollegata, Tipo)
                Next
            Else
                CreaFilesTipo(Agenzia, Tipo)
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
        Globale.Log.Info("Creazione files cumulativi (MC.00X) - end")
    End Sub

    Public Sub CreaFilesTipo(Agenzia As String, Optional Tipo As FileCumulo.TipoCumulo = FileCumulo.TipoCumulo.TUTTI)

        Const NumeroFiles As Integer = 4

        Try
            Dim Progressivo As Integer = 0
            Dim Cartelle = New Utx.CartelleAgenziaOmnia(Agenzia)
            Dim MancanoFiles As Boolean = False
            Dim MancaFile(NumeroFiles) As Boolean
            For i As Integer = 1 To NumeroFiles
                If Tipo = FileCumulo.TipoCumulo.TUTTI Then
                    MancaFile(i) = IO.Directory.GetFiles(Cartelle.ArchivioFileOmnia, String.Format("MC*00{0}.ZIP", i)).Length = 0
                Else
                    MancaFile(i) = (i = Tipo)
                End If

                MancanoFiles = MancanoFiles Or MancaFile(i)
            Next

            If MancanoFiles Then
                Dim agenziaCollegata = GetAgenziaCollegata(Agenzia)

                Dim nomeBaseMC As String = IO.Path.Combine(Cartelle.CartellaArriviLocaleTempOmnia, String.Format("MC{0}{1}", 100000 + CInt(Agenzia), dataEstrazione))

                Dim writer(NumeroFiles) As System.IO.StreamWriter
                For i As Integer = 1 To NumeroFiles
                    If MancaFile(i) Then writer(i) = My.Computer.FileSystem.OpenTextFileWriter(nomeBaseMC & String.Format(".00{0}", i), False)
                Next

                For Each Codice In agenziaCollegata.Config
                    Dim isCodiceAttuale As Boolean = Agenzia.Equals(Codice.AgenziaCollegata)

                    Dim listaPolizze As New List(Of String)
                    Dim listaClienti As New List(Of String)

                    Dim ListaFile As New List(Of String)
                    ListaFile.AddRange(IO.Directory.GetFiles(Codice.Cartelle.ArchivioFileOmnia))
                    ListaFile.Sort()
                    ListaFile.Reverse()

                    For Each file In ListaFile
                        Dim nomefile = IO.Path.GetFileName(file)
                        Dim nome As String = Archivio.NomeSenzaEstenzioneZip(nomefile)

                        Progressivo += 1

                        If FileDaElaborare(Codice.AgenziaCollegata, nome) Then

                            RaiseEvent FileInElaborazione(Codice.AgenziaCollegata, nome, Progressivo, ListaFile.Count, Cancel)
                            If Cancel Then Exit For

                            Dim listafiles As List(Of String) = (Utx.LibreriaZip.SevenZip.UnzipFile(file, Cartelle.CartellaArriviLocaleTempOmnia))

                            For Each fileMA In listafiles
                                Globale.Log.Info("LEGGO " & fileMA)
                                Dim PathfileMA As String = IO.Path.Combine(Cartelle.CartellaArriviLocaleTempOmnia, fileMA)

                                Using reader = New IO.StreamReader(PathfileMA)

                                    Dim rownumber As Integer = 0

                                    While (reader.Peek() <> -1)
                                        Dim sRow = reader.ReadLine()
                                        rownumber += 1

                                        If sRow.Length = 6000 Then

                                            Dim tipoRecord As String = sRow.Substring(15, 2)

                                            If isCodiceAttuale AndAlso MancaFile(1) AndAlso "01,02,04,05,06,07,08,12,13,14,15".Contains(tipoRecord) Then
                                                Dim keyPolizza As String = sRow.Substring(8, 5) & sRow.Substring(17, 12)

                                                If listaPolizze.Contains(keyPolizza) = False Then
                                                    listaPolizze.Add(keyPolizza)
                                                    writer(1).WriteLine(sRow)
                                                End If
                                            ElseIf MancaFile(2) AndAlso "91,92".Contains(tipoRecord) Then
                                                If (tipoRecord = "92") OrElse (CInt(sRow.Substring(0, 4)) >= 2019) Then
                                                    If sRow.Substring(332, 1) <> "2" Then 'escludiamo i delega altrui
                                                        writer(2).WriteLine(sRow)
                                                    End If
                                                End If
                                            ElseIf isCodiceAttuale AndAlso MancaFile(3) AndAlso "00,16,17".Contains(tipoRecord) Then
                                                Dim keyCliente As String = sRow.Substring(17, 16)

                                                If listaClienti.Contains(keyCliente) = False Then
                                                    listaClienti.Add(keyCliente)
                                                    writer(3).WriteLine(sRow)
                                                End If
                                            ElseIf isCodiceAttuale AndAlso MancaFile(3) AndAlso "10,18,19".Contains(tipoRecord) Then
                                                Dim keyCliente As String = sRow.Substring(33, 16)

                                                If listaClienti.Contains(keyCliente) = False Then
                                                    listaClienti.Add(keyCliente)
                                                    writer(3).WriteLine(sRow)
                                                End If
                                            ElseIf isCodiceAttuale AndAlso MancaFile(4) AndAlso "21,22,23,25,28,29,30,24,26,27".Contains(tipoRecord) Then
                                                writer(4).WriteLine(sRow)
                                            End If 'tipo record
                                        End If ' salta righe vuote
                                    End While

                                    reader.Close()
                                End Using

                                IO.File.Delete(PathfileMA)
                            Next
                        End If
                    Next
                    If Cancel Then Exit For

                Next 'Codice

                For i As Integer = 1 To NumeroFiles
                    If MancaFile(i) Then writer(i).Close()
                Next
                For i As Integer = 1 To NumeroFiles
                    If MancaFile(i) Then
                        Dim NomeFileMC As String = nomeBaseMC & String.Format(".00{0}", i)
                        Dim NomeFileZip As String = nomeBaseMC & String.Format("00{0}.ZIP", i)
                        RaiseEvent FileInElaborazione(Agenzia, "compressione files", i, NumeroFiles, Cancel)
                        If IO.File.Exists(NomeFileZip) Then
                            IO.File.Delete(NomeFileZip)
                        End If
                        Utx.LibreriaZip.SevenZip.ZipFile(NomeFileMC, NomeFileZip)
                        IO.File.Delete(NomeFileMC)
                        IO.File.Move(NomeFileZip, IO.Path.Combine(Cartelle.ArchivioFileOmnia, IO.Path.GetFileName(NomeFileZip)))
                        Globale.Log.Info("File cumulativo creato: " & NomeFileZip)
                    End If
                Next
            End If 'MancanoFiles
        Catch ex As Exception
            Globale.Log.Errore(ex.Message)
        End Try
    End Sub

    Private Function FileDaElaborare(CodiceAgenzia As String, ByRef filename As String) As Boolean
        If (filename.ToUpper Like "MA############.###") = False Then
            Return False
        End If

        If filename.Substring(3, 5) <> CodiceAgenzia Then
            Return False
        End If

        Return True
    End Function

    Public Function GetAgenziaCollegata(CodiceAgenziaCollegata As String) As Utx.AgenziaFigliaOmnia
        Dim agenziaCollegata As Utx.AgenziaFigliaOmnia

#If DEBUG Then
        If PCSTEFANO Or PCGUIDO Then
            agenziaCollegata = New Utx.AgenziaFigliaOmnia(CodiceAgenziaCollegata)
        Else
            agenziaCollegata = New Utx.AgenziaFigliaOmnia(CodiceAgenziaCollegata, agenziaMadre.CodiceSede)
        End If
#Else
        agenziaCollegata = New Utx.AgenziaFigliaOmnia(CodiceAgenziaCollegata, agenziaMadre.CodiceSede)
#End If
        Return agenziaCollegata
    End Function

    Public Shared Sub RigeneraFile(Dati As DatiStart)
        Try
#If DEBUG Then
            Utx.GestioneFlag.CancellaFlag(Utx.GestioneFlag.TipoFlag.DATI_OMNIA_DISPONIBILI)
            Utx.GestioneFlag.CancellaFlag(Utx.GestioneFlag.TipoFlag.IMPORTA_DATI_OMNIA)
#End If
            'se non ci sono dati già in coda per l'importazione
            'se non è in corso un'altra importazione
            Notifica = New Utx.FormNotifica
            With Notifica
                .Stile = Utx.FormNotifica.Style.ANTRACITE
                .AnnullaOperazione = True
                .Show()

                .Messaggio = "Creo file riepilogativi"
            End With

            'cancello i file MC precedenti
            If Dati.Agenzia = Nothing Then 'tutti i codici
                Select Case Dati.Tipo
                    Case FileCumulo.TipoCumulo.TUTTI
                        For Each CodiceAgenziaCollegata In agenziaMadre.AgenzieCollegate
                            Dim Cartelle = New Utx.CartelleAgenziaOmnia(CodiceAgenziaCollegata)
                            For Each f As String In IO.Directory.GetFiles(Cartelle.ArchivioFileOmnia, "MC*.ZIP")
                                IO.File.Delete(f)
                            Next
                        Next
                    Case Else
                        For Each CodiceAgenziaCollegata In agenziaMadre.AgenzieCollegate
                            Dim Cartelle = New Utx.CartelleAgenziaOmnia(CodiceAgenziaCollegata)
                            For Each f As String In IO.Directory.GetFiles(Cartelle.ArchivioFileOmnia, String.Format("MC*{0:000}.ZIP", Val(Dati.Tipo)))
                                IO.File.Delete(f)
                            Next
                        Next
                End Select
            Else
                Select Case Dati.Tipo
                    Case FileCumulo.TipoCumulo.TUTTI
                        Dim Cartelle = New Utx.CartelleAgenziaOmnia(Dati.Agenzia)
                        For Each f As String In IO.Directory.GetFiles(Cartelle.ArchivioFileOmnia, String.Format("MC1{0}*.ZIP", Dati.Agenzia))
                            IO.File.Delete(f)
                        Next
                    Case Else
                        Dim Cartelle = New Utx.CartelleAgenziaOmnia(Dati.Agenzia)
                        For Each f As String In IO.Directory.GetFiles(Cartelle.ArchivioFileOmnia, String.Format("MC1{0}*{1:000}.ZIP", Dati.Agenzia, Val(Dati.Tipo)))
                            IO.File.Delete(f)
                        Next
                End Select
            End If

            'creo i nuovi file
            Cumulo = New UniFeed.Cumulatore
            Cumulo.CreaFiles(Dati.Agenzia, Dati.Tipo)
            CancellaImportazioneCumulo(Dati)
            Notifica.Messaggio = "Operazione conclusa"
            Notifica.Chiudi()

        Catch ex As Exception
            Globale.Log.Errore(ex.Message)
        End Try
    End Sub

    Public Shared Sub CancellaImportazioneCumulo(Dati As DatiStart)
        Try
            'cancello la precedente importazione dei file cumulativi
            For Each CodiceAgenziaCollegata In agenziaMadre.AgenzieCollegate

                If (Dati.Agenzia Is Nothing) OrElse (CodiceAgenziaCollegata = Dati.Agenzia) Then
                    Dim Cartelle = New Utx.CartelleAgenziaOmnia(CodiceAgenziaCollegata)

                    Using c As New OleDb.OleDbConnection(Utx.ConnessioniDb.ConnectionString(CodiceAgenziaCollegata, Utx.ConnessioniDb.Db.DBUNO))
                        c.Open()

                        Using cmd As New OleDb.OleDbCommand
                            cmd.Connection = c
                            cmd.CommandType = CommandType.Text

                            Select Case Dati.Tipo
                                Case FileCumulo.TipoCumulo.TUTTI
                                    cmd.CommandText = String.Format("DELETE FROM arp002_file WHERE Left(Nome,8) = 'MC1{0}'", CodiceAgenziaCollegata)
                                Case Else
                                    cmd.CommandText = String.Format("DELETE FROM arp002_file WHERE Left(Nome,8) = 'MC1{0}' AND Right(Nome,4) = '.{1:000}'", CodiceAgenziaCollegata, Val(Dati.Tipo))
                            End Select
                            cmd.ExecuteNonQuery()
                        End Using
                    End Using
                End If
            Next
        Catch ex As Exception
            Globale.Log.Errore(ex.Message)
        End Try
    End Sub

    Private Shared Sub Cumulo_FileInElaborazione(Agenzia As String, NomeFile As String, Progressivo As Integer, TotaleFile As Integer, ByRef Cancel As Boolean) Handles Cumulo.FileInElaborazione
        Notifica.Messaggio = String.Format("Codice {0}: {1} ({2}/{3})", Agenzia, NomeFile, Progressivo, TotaleFile)
        If Notifica.RichiestaAnnullamento = True Then
            Notifica.Messaggio = "Operazione annullata dall'utente"
            Cancel = True
        End If
    End Sub

    Public Class FileCumulo
        Public Enum TipoCumulo
            TUTTI = 0
            POLIZZE = 1
            SINISTRI = 2
            CLIENTI = 3
            TITOLI = 4
        End Enum

        Sub New(Tipo As TipoCumulo)
            _Tipo = Tipo
            _Descrizione = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Tipo.ToString.ToLower)
        End Sub

        Private _Tipo As TipoCumulo
        Public ReadOnly Property Tipo() As TipoCumulo
            Get
                Return _Tipo
            End Get
        End Property

        Private _Descrizione As String
        Public Property Descrizione() As String
            Get
                Return _Descrizione
            End Get
            Set(value As String)
                _Descrizione = value
            End Set
        End Property
    End Class

    Public Class DatiStart
        Public Agenzia As String
        Public Tipo As Cumulatore.FileCumulo.TipoCumulo
    End Class
End Class
