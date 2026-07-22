Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports System.Data.OleDb

Module Funzioni

    Friend Function UserDesktop() As String
        UserDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    End Function

    Friend Function DataUSA(DataIT As String) As String
        Try
            If IsDate(DataIT) Then
                Return "#" + Format(CDate(DataIT), "MM/dd/yyyy") + "#"
            Else
                Return "Null"
            End If

        Catch ex As Exception
            Return "Null"
        End Try
    End Function

    Friend Function DataITA(DataIT As String) As Object
        Try
            If IsDate(DataIT) Then
                Return CDate(DataIT)
            Else
                Return DBNull.Value
            End If

        Catch ex As Exception
            Return DBNull.Value
        End Try
    End Function

    Friend Function NumeroUSA(Numero As String) As String
        NumeroUSA = Str(CDbl(Numero)).Trim.Replace(",", ".")
    End Function

    Friend Sub SvuotaCartella(Cartella As String)
        Try
            Dim fo As New DirectoryInfo(Cartella)
            For Each fi As FileInfo In fo.GetFiles
                CancellaFile(fi.FullName)
            Next

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        End Try
    End Sub

    Friend Function CfToSesso(CodiceFiscale As String) As String
        Try
            If IsNumeric(CodiceFiscale) Then
                Return "S"
            Else
                If CInt(CodiceFiscale.Substring(9, 2)) > 40 Then
                    Return "F"
                Else
                    Return "M"
                End If
            End If
        Catch ex As Exception
            Return "?"
        End Try

    End Function

    'Friend Sub CompattaMdb(DbFile As String)

    '    Try
    '        Globale.Log.Info("Compatto mdb arrivi")

    '        Dim NomeCopia As String = Path.Combine(Path.GetDirectoryName(DbFile), "CompactDb.mdb")

    '        If File.Exists(NomeCopia) Then File.Delete(NomeCopia)

    '        Dim j As New JRO.JetEngine

    '        'compatta il file DB
    '        Call j.CompactDatabase(String.Format("Data Source={0};", DbFile),
    '                               String.Format("Data Source={0};", NomeCopia))

    '        'rinomina il file
    '        File.Delete(DbFile)
    '        My.Computer.FileSystem.RenameFile(NomeCopia, "Arrivi.mdb")

    '    Catch ex As Exception
    '        Globale.Log.Info(ex.Message)
    '    End Try
    'End Sub

    Friend Function LeggiCalendarioUt(ByRef cnArrivi As OleDbConnection,
                                      TipoFile As Utx.Enumerazioni.TipoFileMagia) As String
        'restituisce stringa con date aggiornamento archivi

        Dim cmd As New OleDb.OleDbCommand

        Try
            cmd.Connection = cnArrivi
            cmd.CommandType = CommandType.Text

            'imposta la query
            Select Case TipoFile
                Case Utx.Enumerazioni.TipoFileMagia.Incassi
                    cmd.CommandText = "SELECT Min(DataFoglioCassa),Max(DataFoglioCassa) FROM ControlloIncassi"
                Case Utx.Enumerazioni.TipoFileMagia.MonitorQT
                    cmd.CommandText = "SELECT Min(Effetto),Max(Effetto) FROM MonitorQT"
                Case Utx.Enumerazioni.TipoFileMagia.MovimentiPTF
                    cmd.CommandText = "SELECT Min(DataInizio),Max(DataFine) FROM CalendarioUt WHERE Val(TipoFile) = ?"
                Case Utx.Enumerazioni.TipoFileMagia.SinistriBase
                    cmd.CommandText = "SELECT Min(DataInizio),Max(DataFine) FROM CalendarioUt WHERE Val(TipoFile) = ?"
            End Select

            'imposta il parametro
            cmd.Parameters.AddWithValue("TipoFile", Val(TipoFile))

            'legge le date
            Dim dr As OleDbDataReader = cmd.ExecuteReader

            'attenzione: nell'executereader il dr contiene comunque una riga
            'anche se i campi sono a null perchè non ha trovato niente nel db
            dr.Read()

            Dim Msg As String = "({0}{1})"

            'crea il messaggio
            If dr(0) Is System.DBNull.Value Then
                Return String.Format(Msg, "ND", "")
            Else
                Select Case TipoFile
                    Case Utx.Enumerazioni.TipoFileMagia.Anag
                        Return String.Format(Msg, Format(dr(0), "MM-yyyy"), "")
                    Case Utx.Enumerazioni.TipoFileMagia.Sinistri
                        Return String.Format(Msg, Format(dr(1), "dd-MM-yyyy"), "")
                    Case Else
                        Return String.Format(Msg, Format(dr(0), "dd-MM-yyyy"),
                                             " - " + Format(dr(1), "dd-MM-yyyy"))
                End Select
            End If

            dr.Close()

        Catch ex As Exception
            Globale.Log.Info(ex.Message)
            Return "(ND)"
        Finally
            cmd.Dispose()
        End Try
    End Function

    Public Function LeggiCalendarioDoc(ByRef cnArrivi As OleDbConnection,
                                       TipoFile As Utx.Enumerazioni.TipoFileDoc) As String
        Try
            Using cmd As New OleDbCommand
                cmd.Connection = cnArrivi
                cmd.CommandType = CommandType.Text
                cmd.CommandText = "SELECT Min(DataInizio),Max(DataFine) FROM CalendarioDoc WHERE TipoFile = ?"

                'imposta il parametro
                cmd.Parameters.AddWithValue("TipoFile", TipoFile)

                'legge le date
                Dim dr As OleDbDataReader = cmd.ExecuteReader

                If dr.HasRows Then
                    dr.Read()
                    'crea il messaggio
                    Return String.Format("({0} - {1})", Format(dr(0), "dd-MM-yyyy"), Format(dr(1), "dd-MM-yyyy"))
                Else
                    Return ""
                End If

                dr.Close()
            End Using

        Catch ex As Exception
            Globale.Log.Info(ex)
            Return "(ND)"
        End Try
    End Function

    Friend Sub SplitTesto(Testo As String,
                          PosizioneIniziale As Integer,
                          ByRef LunCampi() As Integer,
                          ByRef Campi() As String)

        Try
            Dim Pos As Integer = PosizioneIniziale
            For n As Integer = 0 To UBound(LunCampi)
                Campi(n) = Testo.Substring(Pos, LunCampi(n)).Trim
                Pos += LunCampi(n)
            Next

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        End Try
    End Sub

    Friend Function VersioneCorrenteIDati() As String
        Try
            Dim Info As New FileInfo(Application.ExecutablePath)
            Dim VerInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Info.FullName)
            Return VerInfo.FileVersion

        Catch ex As Exception
            Globale.Log.Info(ex.Message)
            Return "???"
        End Try
    End Function

    Friend Sub TrimArray(ByRef Matrice() As String)
        'trimma tutta la matrice unidimensionale di stringhe
        Try
            For k As Integer = 0 To UBound(Matrice)
                Matrice(k) = Matrice(k).Trim
            Next
        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        End Try
    End Sub

    Friend Sub TrimArray(ByRef Lista As ArrayList)
        'trimma tutti gli elementi dell'arraylist
        Try
            For k As Integer = 0 To Lista.Count - 1
                Lista(k) = Lista(k).Trim
            Next
        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        End Try
    End Sub

    Friend Function CopiaFile(FullPathFileOrigine As String,
                              CartellaDestinazione As String,
                              Optional Timeout As Integer = 180) As Boolean

        If File.Exists(FullPathFileOrigine) = False Then
            Return False
        End If

        'destinazione
        Dim FullPathFileDest As String = Path.Combine(CartellaDestinazione, Path.GetFileName(FullPathFileOrigine))

        'sposta il file aspettando se il file è bloccato fino al timeout
        'il timeout è espresso in secondi
        Dim Inizio As Date = Now

        Do
            Try
                File.Copy(FullPathFileOrigine, FullPathFileDest, True)
                Globale.Log.Info(String.Format("File '{0}' copiato in '{1}'", FullPathFileOrigine, FullPathFileDest))
                CopiaFile = True
                Exit Do

            Catch ex As IOException
                'se è stato superato il tempo assegnato
                If DateDiff(DateInterval.Second, Inizio, Now) > Timeout Then
                    CopiaFile = False
                    Globale.Log.Info(String.Format("*Timeout: il file '{0}' non è stato copiato", FullPathFileOrigine))
                    Exit Do
                End If

                Application.DoEvents()

                'aspetto 5 secondi e riprovo
                System.Threading.Thread.Sleep(3000)

            Catch ex As Exception
                Globale.Log.Info(ex.Message)
                CopiaFile = False
                Exit Do
            End Try
        Loop
    End Function

    Friend Sub CancellaFile(FullPathFile As String)
        Try
            If File.Exists(FullPathFile) Then
                'AddLog(String.Format("Cancellazione del file {0}", FullPathFile))
                File.Delete(FullPathFile)
            End If

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Conta i record (righe) in un file di testo (txt,csv)
    ''' </summary>
    ''' <param name="NomeFile">Path completo del file</param>
    ''' <param name="RigaTitoli">Nome dei campi nella proma riga</param>
    ''' <returns>Numero record/righe</returns>
    ''' <remarks></remarks>
    Friend Function ContaRecordTxt(NomeFile As String, RigaTitoli As Boolean) As Integer
        Try
            Using sr As New StreamReader(NomeFile, System.Text.Encoding.Default)
                'se prima riga contiene il nome dei campi la salto
                If RigaTitoli Then sr.ReadLine()

                ContaRecordTxt = 0

                Do While Not sr.EndOfStream
                    sr.ReadLine()
                    ContaRecordTxt += 1
                Loop
            End Using

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
            Return 0
        End Try
    End Function

    Friend Function NomeMese2NumeroMese(NomeMese As String) As Integer
        Try
            NomeMese = NomeMese.ToUpper

            For k As Integer = 1 To 12
                If MonthName(k).ToUpper = NomeMese Then
                    Return k
                End If
            Next

            Return 0

        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Sub InsertArrayElement(Of T)(ByRef sourceArray() As T,
                                        insertIndex As Integer,
                                        newValue() As T)

        Array.Resize(sourceArray, sourceArray.Length + newValue.Length)

        Dim IndiceSup As Integer = sourceArray.Length - 1
        Dim Offset As Integer = newValue.Length

        For k As Integer = IndiceSup To (IndiceSup - newValue.Length + 1) Step -1
            sourceArray(k) = sourceArray(k - Offset)
        Next

        For k As Integer = insertIndex To insertIndex + newValue.Length - 1
            sourceArray(k) = newValue(k - insertIndex)
        Next
    End Sub

    Friend Function CodiceErroreServer(MsgErrore As String) As Integer
        Try
            Dim Pos As Integer = MsgErrore.IndexOf(": (")
            Return MsgErrore.Substring(Pos + 3, 3)

        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Sub CancellaCartelleVuote(Path As String)

        Dim SubDirectories() As String = Directory.GetDirectories(Path)

        For Each sd As String In SubDirectories
            CancellaCartelleVuote(sd)
        Next

        'se nella cartella non ci sono file e non ci sono sottocartelle viene cancellata
        If Directory.GetFiles(Path).Length = 0 AndAlso
           Directory.GetDirectories(Path).Length = 0 Then

            Directory.Delete(Path)
            Globale.Log.Info(Path)
        End If
    End Sub

    Public Sub LogAggiornamento(Sezione As String,
                                UltimoAggiornamento As Date,
                                ProssimoAggiornamento As Date)
        Globale.Log.Info(Sezione)
        Globale.Log.Info(String.Format("Ultimo aggiornamento: {0:d}", UltimoAggiornamento))
        Globale.Log.Info(String.Format("Prossimo aggiornamento: {0:d}", ProssimoAggiornamento))
    End Sub
End Module
