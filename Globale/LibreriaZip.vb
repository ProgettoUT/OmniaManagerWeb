Imports System.IO
Imports Telerik.WinControls.Zip
Imports System.Windows.Forms

Public Class LibreriaZip

#Region "zip"
    Public Shared Function ZipFile(FileOrigine() As String,
                                   FileZippato As String) As Boolean
        Try
            FileZippato = ControlloEstenzione(FileZippato)

            Using St As Stream = File.Open(FileZippato, FileMode.Create, FileAccess.Write)
                Using zipArchive As ZipArchive = New ZipArchive(St, ZipArchiveMode.Create, False, Nothing)
                    For Each f As String In FileOrigine
                        Dim entry As String = Path.GetFileName(f)
                        Try
                            'aggiungo il file allo zip
                            Extensions.ZipFile.CreateEntryFromFile(zipArchive, f, entry)
                        Catch ex As Exception
                            'se è bloccato aggiungo una copia temporanea
                            Dim FileTemp As String = CreaFileTemporaneo(f)
                            Extensions.ZipFile.CreateEntryFromFile(zipArchive, FileTemp, entry)
                            File.Delete(FileTemp)
                        End Try
                    Next
                End Using
            End Using

            Return True

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Shared Function ZipFile(FileOrigine As String,
                                   FileZippato As String) As Boolean
        Return ZipFile({FileOrigine}, FileZippato)
    End Function

    Public Shared Function UpdateZipFile(ListaFile As List(Of String),
                                         FileZippato As String,
                                         ByRef Esito As EsitoZip) As Boolean
        Try
            FileZippato = ControlloEstenzione(FileZippato)

            Using St As Stream = File.Open(FileZippato, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                Using zipArchive As ZipArchive = New ZipArchive(St, ZipArchiveMode.Update, False, Nothing)
                    For Each f As String In ListaFile
                        'se entry esiste già lo rimuove per aggiornarlo
                        Dim entry As String = Path.GetFileName(f)
                        Dim entryfound As Boolean = False

                        For Each e As ZipArchiveEntry In zipArchive.Entries
                            If e.FullName = entry Then
                                entryfound = True 'file trovato

                                If e.LastWriteTime.AddSeconds(2) < File.GetLastWriteTime(f) Then
                                    e.Delete() 'lo cancello
                                    entryfound = False 'per inserirlo di nuovo ed aggiornarlo
                                End If

                                Exit For
                            End If
                        Next

                        'se il file non è nell'archivio
                        If entryfound = False Then
                            Try
                                'aggiungo il file allo zip
                                Extensions.ZipFile.CreateEntryFromFile(zipArchive, f, entry)
                            Catch ex As Exception
                                'se è bloccato aggiungo una copia temporanea
                                Dim FileTemp As String = CreaFileTemporaneo(f)
                                Extensions.ZipFile.CreateEntryFromFile(zipArchive, FileTemp, entry)
                                File.Delete(FileTemp)
                            End Try
                            Esito.ListaFileZippati.Add(entry)
                        End If
                    Next
                End Using
            End Using

            Esito.Esito = True
            Esito.MessaggioErrore = ""

            Return True

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Esito.Esito = False
            Esito.MessaggioErrore = ex.Message
            Return False
        End Try
    End Function

    Public Shared Function UpdateZipFile(FileOrigine As String,
                                         FileZippato As String) As EsitoZip
        Dim Esito As New EsitoZip
        Try
            FileZippato = ControlloEstenzione(FileZippato)

            Using St As Stream = File.Open(FileZippato, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                Using zipArchive As ZipArchive = New ZipArchive(St, ZipArchiveMode.Update, False, Nothing)
                    'se entry esiste già lo rimuove per aggiornarlo
                    Dim entry As String = Path.GetFileName(FileOrigine)
                    Dim entryfound As Boolean = False

                    For Each e As ZipArchiveEntry In zipArchive.Entries
                        If e.FullName = entry Then
                            entryfound = True 'file trovato

                            If e.LastWriteTime.AddSeconds(2) < File.GetLastWriteTime(FileOrigine) Then
                                e.Delete() 'lo cancello
                                entryfound = False 'per inserirlo di nuovo ed aggiornarlo
                            End If

                            Exit For
                        End If
                    Next

                    'se il file non è nell'archivio
                    If entryfound = False Then
                        Try
                            'aggiungo il file allo zip
                            Extensions.ZipFile.CreateEntryFromFile(zipArchive, FileOrigine, entry)
                        Catch ex As Exception
                            'se è bloccato aggiungo una copia temporanea
                            Dim FileTemp As String = CreaFileTemporaneo(FileOrigine)
                            Extensions.ZipFile.CreateEntryFromFile(zipArchive, FileTemp, entry)
                            File.Delete(FileTemp)
                        End Try
                        Esito.ListaFileZippati.Add(entry)
                    End If
                End Using
            End Using

            Esito.Esito = True
            Esito.MessaggioErrore = ""
            Return Esito

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Esito.Esito = False
            Esito.MessaggioErrore = ex.Message
        End Try
        Return Esito
    End Function

    Public Shared Function ZipFolder(Folder As String,
                                     FileZippato As String) As Boolean
        Return ZipFile(Directory.GetFiles(Folder), FileZippato)
    End Function
#End Region

#Region "unzip"
    Public Shared Function UnZipFile(FileOrigine As String,
                                     CartellaDestinazione As String) As List(Of String)

        Dim ListaFile As New List(Of String)
        Try
            Directory.CreateDirectory(CartellaDestinazione)

            Using st As Stream = File.OpenRead(FileOrigine)
                Using archive As New ZipArchive(st)
                    For Each e As ZipArchiveEntry In archive.Entries
                        Using sw As Stream = File.Create(Path.Combine(CartellaDestinazione, e.FullName))
                            Dim entryStream As Stream = e.Open()
                            Extensions.ZipFile.CopyStreamTo(entryStream, sw)
                            sw.Flush()
                        End Using
                        'aggiungo alla lista
                        ListaFile.Add(e.FullName)
                    Next
                End Using
            End Using

            Return ListaFile

        Catch ex As Exception
            If ex.Message.ToLower.StartsWith("end of central directory not found") Then
                'file danneggiato: non fare niente
            Else
                Globale.Log.Errore(ex)
            End If
            ListaFile.Clear()
            Return ListaFile
        End Try
    End Function

    Public Shared Function UnZipFileEx(FileOrigine As String,
                                       CartellaDestinazione As String) As List(Of String)

        Dim ListaFile As New List(Of String)
        Try
            Directory.CreateDirectory(CartellaDestinazione)

            Using st As Stream = File.OpenRead(FileOrigine)
                Using archive As New ZipArchive(st)
                    For Each e As ZipArchiveEntry In archive.Entries
                        If Right(e.FullName, 1) = "/" Then
                            Directory.CreateDirectory(Path.Combine(CartellaDestinazione, e.FullName))
                        Else
                            'creo la eventuale sub cartella
                            Dim SubCartella As String = Directory.GetParent(Path.Combine(CartellaDestinazione, e.FullName)).FullName
                            Directory.CreateDirectory(SubCartella)
                            'estraggo
                            Using sw As Stream = File.Create(Path.Combine(CartellaDestinazione, e.FullName))
                                Dim entryStream As Stream = e.Open()
                                Extensions.ZipFile.CopyStreamTo(entryStream, sw)
                                sw.Flush()
                            End Using
                            'aggiungo alla lista
                            ListaFile.Add(e.FullName)
                        End If
                    Next
                End Using
            End Using

            Return ListaFile

        Catch ex As Exception
            If ex.Message.ToLower.StartsWith("end of central directory not found") Then
                'file danneggiato: non fare niente
            Else
                Globale.Log.Errore(ex)
            End If
            ListaFile.Clear()
            Return ListaFile
        End Try
    End Function

    Public Shared Function UnZipFileRename(FileOrigine As String,
                                           CartellaDestinazione As String) As List(Of String)
        'prima di decomprimere un file lo cancella oppure lo rinomina in caso di file bloccato
        'da usare da live update per i pacchetti zip
        Dim ListaFile As New List(Of String)
        Try
            Directory.CreateDirectory(CartellaDestinazione)

            Using st As Stream = File.OpenRead(FileOrigine)
                Using archive As New ZipArchive(st)
                    For Each e As ZipArchiveEntry In archive.Entries
                        If Right(e.FullName, 1) = "/" Then
                            Directory.CreateDirectory(Path.Combine(CartellaDestinazione, e.FullName))
                        Else
                            'creo la eventuale sub cartella
                            Dim SubCartella As String = Directory.GetParent(Path.Combine(CartellaDestinazione, e.FullName)).FullName
                            Directory.CreateDirectory(SubCartella)
                            'cancello la destinazione
                            Dim Destinazione As String = Path.Combine(CartellaDestinazione, e.FullName)
                            Try
                                File.Delete(Destinazione)
                            Catch ex As Exception
                            End Try
                            'se ancora esiste è bloccato e allora lo rinomino
                            If File.Exists(Destinazione) Then
                                Dim NuovoNome As String = String.Format("UTOLD.{0}.{1}.{2}", Environment.UserName, Format(Now, "HHmmss"), Path.GetFileName(Destinazione))
                                'rinomino il file bloccato
                                My.Computer.FileSystem.RenameFile(Destinazione, NuovoNome)
                            End If
                            'estraggo
                            Using sw As Stream = File.Create(Destinazione)
                                Dim entryStream As Stream = e.Open()
                                Extensions.ZipFile.CopyStreamTo(entryStream, sw)
                                sw.Flush()
                            End Using
                            'aggiungo alla lista
                            ListaFile.Add(e.FullName)
                        End If
                    Next
                End Using
            End Using

            Return ListaFile

        Catch ex As Exception
            If ex.Message.ToLower.StartsWith("end of central directory not found") Then
                'file danneggiato: non fare niente
            Else
                Globale.Log.Errore(ex)
            End If
            ListaFile.Clear()
            Return ListaFile
        End Try
    End Function

    Public Shared Function EstraiFile(FileOrigine As String,
                                      CartellaDestinazione As String,
                                      FileDaEstrarre As String) As String
        Try
            Directory.CreateDirectory(CartellaDestinazione)

            Dim Destinazione As String = Path.Combine(CartellaDestinazione, FileDaEstrarre)
            File.Delete(Destinazione)

            Using st As Stream = File.OpenRead(FileOrigine)
                Using archive As New ZipArchive(st)
                    For Each e As ZipArchiveEntry In archive.Entries
                        If e.Name = FileDaEstrarre Then
                            Using sw As Stream = File.Create(Destinazione)
                                Dim entryStream As Stream = e.Open()
                                Extensions.ZipFile.CopyStreamTo(entryStream, sw)
                                sw.Flush()
                            End Using
                            Return Destinazione
                        End If
                    Next
                End Using
            End Using

            Return ""

        Catch ex As Exception
            If ex.Message.ToLower.StartsWith("end of central directory not found") Then
                'file danneggiato: non fare niente
            Else
                Globale.Log.Errore(ex)
            End If
            Return ""
        End Try
    End Function

    Public Shared Function UnZipFileConNome(FileOrigine As String,
                                            FileDestinazione As String) As Boolean
        Try
            Using st As Stream = File.OpenRead(FileOrigine)
                Using archive As New ZipArchive(st)
                    For Each e As ZipArchiveEntry In archive.Entries
                        Using sw As Stream = File.Create(FileDestinazione) 'se esiste viene sovrascritto
                            Dim entryStream As Stream = e.Open()
                            Extensions.ZipFile.CopyStreamTo(entryStream, sw)
                            sw.Flush()
                        End Using
                    Next
                End Using
            End Using

            Return True

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    'Public Shared Sub UnZipToFolder(FileOrigine As String,
    '                                CartellaDestinazione As String)
    '    Try
    '        Directory.CreateDirectory(CartellaDestinazione)

    '        Using stream As Stream = File.OpenRead(FileOrigine)
    '            Using zip As New ZipArchive(stream, ZipArchiveMode.Read, False, Nothing)
    '                Extensions.ZipFile.ExtractToDirectory(zip, CartellaDestinazione)
    '            End Using
    '        End Using

    '    Catch ex As Exception
    '        Globale.Log.Errore(ex)
    '    End Try
    'End Sub
#End Region

    Private Shared Function ControlloEstenzione(NomeFile As String) As String
        If Path.GetExtension(NomeFile).ToLower = ".zip" Then
            Return NomeFile
        Else
            Return NomeFile + ".zip"
        End If
    End Function

    Private Shared Function CreaFileTemporaneo(f As String) As String
        Try
            'copia il file (bloccato) in una cartella temmporanea
            Dim TempZip As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "Zip")
            Directory.CreateDirectory(TempZip)

            Dim FileTemp As String = Path.Combine(TempZip, Path.GetFileName(f))
            File.Copy(f, FileTemp, True)

            Return FileTemp

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return f
        End Try
    End Function

    Public Class EsitoZip

        Public Property Esito As Boolean
        Public Property MessaggioErrore As String
        Public Property ListaFileZippati As List(Of String)

        Sub New()
            ListaFileZippati = New List(Of String)
        End Sub
    End Class

    Public Class SevenZip

        Private Shared Eseguibile As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "7z.exe")

        Public Shared Function ZipFile(FileOrigine As String,
                                       FileZippato As String) As Boolean
            Try
                FileZippato = ControlloEstenzione(FileZippato)

                Dim Comando As String = String.Format("{0} a ""{1}"" ""{2}""", Eseguibile, FileZippato, FileOrigine)

                Dim Esito As Integer = Shell(Comando, AppWinStyle.Hide, True)

                If Esito = 0 Then
                    Return True
                Else
                    Globale.Log.Errore(MessaggioErrore(Esito))
                    Return False
                End If

            Catch ex As Exception
                Globale.Log.Errore(ex)
                Return False
            End Try
        End Function

        Public Shared Function ZipFile(FileOrigine() As String,
                                       FileZippato As String) As Boolean
            Try
                FileZippato = ControlloEstenzione(FileZippato)

                For Each f As String In FileOrigine
                    Dim Comando As String = String.Format("{0} a {1} {2}", Eseguibile, FileZippato, f)
                    Dim Esito As Integer = Shell(Comando, AppWinStyle.Hide, True)

                    If Esito > 0 Then
                        Globale.Log.Errore(MessaggioErrore(Esito))
                        Return False
                    End If
                Next
                Return True

            Catch ex As Exception
                Globale.Log.Errore(ex)
                Return False
            End Try
        End Function

        Public Shared Function ZipFolder(Folder As String,
                                         FileZippato As String) As Boolean
            Return ZipFile(Path.Combine(Folder, "*.*"), FileZippato)
        End Function

        Public Shared Function UnzipFile(FileOrigine As String,
                                         CartellaDestinazione As String,
                                         FileDaEstrarre As String) As Boolean
            Try
                Dim Comando As String = String.Format("{0} e {1} -o{2} {3} -r -y", Eseguibile, FileOrigine, CartellaDestinazione, FileDaEstrarre)
                Globale.Log.Trace(Comando)

                Dim Esito As Integer = Shell(Comando, AppWinStyle.Hide, True)

                If Esito = 0 Then
                    Return True
                Else
                    Globale.Log.Errore(MessaggioErrore(Esito))
                    Return False
                End If

            Catch ex As Exception
                Globale.Log.Errore(ex)
                Return False
            End Try
        End Function

        'Public Shared Function UnZipFile(FileOrigine As String,
        '                                 CartellaDestinazione As String) As List(Of String)

        '    Dim ListaFile As New List(Of String)
        '    Try
        '        Directory.CreateDirectory(CartellaDestinazione)
        '        Dim files = New List(Of String)(IO.Directory.GetFiles(CartellaDestinazione))

        '        Dim Comando As String = String.Format("{0} e {1} -o{2} -r -y", Eseguibile, FileOrigine, CartellaDestinazione)

        '        Dim Esito As Integer = Shell(Comando, AppWinStyle.Hide, True)

        '        If Esito = 0 Then
        '            For Each fileName In IO.Directory.GetFiles(CartellaDestinazione)
        '                If Not files.Contains(fileName) Then
        '                    ListaFile.Add(Path.GetFileName(fileName))
        '                End If
        '            Next
        '        Else
        '            Globale.Log.Errore(MessaggioErrore(Esito))
        '        End If

        '    Catch ex As Exception
        '        Globale.Log.Errore(ex)
        '    End Try

        '    Return ListaFile
        'End Function

        Public Shared Function UnZipFile(FileOrigine As String, CartellaDestinazione As String) As List(Of String)

            Dim Files = New List(Of String)

            Try
                Dim Comando As String
                Dim Esito As Integer

                Directory.CreateDirectory(CartellaDestinazione)

                If Directory.GetFiles(CartellaDestinazione).Length = 0 Then
                    '+se la cartella destinazione è vuota
                    Try
                        Comando = String.Format("{0} e {1} -o{2} -r -y", Eseguibile, FileOrigine, CartellaDestinazione)
                        Globale.Log.Trace(Comando)

                        Esito = Shell(Comando, AppWinStyle.Hide, True)

                        If Esito = 0 Then
                            For Each f As String In Directory.GetFiles(CartellaDestinazione)
                                Files.Add(Path.GetFileName(f))
                            Next
                        Else
                            Globale.Log.Errore(MessaggioErrore(Esito))
                        End If

                    Catch ex As Exception
                        Globale.Log.Errore(ex)
                    End Try
                Else
                    '+se la destinazione non è vuota uso una cartella temporanea
                    Dim Temp As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, Guid.NewGuid.ToString.ToUpper)
                    Directory.CreateDirectory(Temp)

                    Try
                        Comando = String.Format("{0} e {1} -o{2} -r -y", Eseguibile, FileOrigine, Temp)
                        Globale.Log.Trace(Comando)

                        Esito = Shell(Comando, AppWinStyle.Hide, True)

                        If Esito = 0 Then
                            For Each f As String In Directory.GetFiles(Temp)
                                Dim FileDest As String = Path.Combine(CartellaDestinazione, Path.GetFileName(f))
                                File.Delete(FileDest)
                                File.Move(f, FileDest)
                                Files.Add(Path.GetFileName(f))
                            Next
                        Else
                            Globale.Log.Errore(MessaggioErrore(Esito))
                        End If

                    Catch ex As Exception
                        Globale.Log.Errore(ex)
                    Finally
                        Utx.NetFunc.SvuotaCartella(Temp)
                        Directory.Delete(Temp)
                    End Try
                End If

            Catch ex As Exception
                Globale.Log.Errore(ex)
            End Try

            Return Files
        End Function

        Public Shared Function MessaggioErrore(CodiceErrore As Integer) As String
            Select Case CodiceErrore
                Case 0
                    Return "Ok"
                Case 1
                    Return "Attenzione (errore non fatale). Per esempio uno o più file sono bloccati da altre applicazioni e non possono essere compressi."
                Case 2
                    Return "Error fatale"
                Case 7
                    Return "Comando errato"
                Case 8
                    Return "memoria insufficiente"
                Case 255
                    Return "Processo interrotto dall'utente"
                Case Else
                    Return "Errore non previsto"
            End Select
        End Function
    End Class
End Class
