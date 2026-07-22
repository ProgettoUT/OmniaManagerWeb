Imports System.IO
Imports System.Net
Imports ExportLib.Export
Imports System.Data.OleDb
Imports System.Data

Module Funzioni

    Public Sub TrimArray(ByRef Matrice() As String)
        'trimma tutti gli elementi dell'array unidimensionale
        Try
            For k As Integer = 0 To Matrice.GetUpperBound(0)
                Matrice(k) = Matrice(k).Trim
            Next

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Function ClearFileFromNull(NomeFile As String) As Boolean
        Try
            Dim Temp() As Byte = File.ReadAllBytes(NomeFile)
            Dim Modifica As Boolean = False

            For k = 0 To Temp.GetUpperBound(0)
                'sostituisco eventuali null (00) con uno spazio (32)
                If Temp(k) = 0 Then
                    Temp(k) = 32
                    Modifica = True
                End If
            Next

            If Modifica = True Then
                File.WriteAllBytes(NomeFile, Temp)
            End If

            Return True

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Sub RollbackTabella(TabellaErrata As String,
                               TabellaBackup As String,
                               ByRef c As OleDbConnection,
                               Optional Messaggio As Boolean = True)
        Try
            Using cmd As New OleDbCommand
                cmd.Connection = c
                cmd.CommandType = CommandType.Text
                'cancello tutti i record
                cmd.CommandText = String.Format("DELETE * FROM {0}", TabellaErrata)
                cmd.ExecuteNonQuery()
                're-incollo tutto dalla tabella di backup
                cmd.CommandText = String.Format("INSERT INTO {0} SELECT * FROM {1}", TabellaErrata, TabellaBackup)
                cmd.ExecuteNonQuery()
                'cancello la tabella di backup
                Utx.FunzioniDb.CancellaTabella(c, TabellaBackup)

                If Messaggio Then
                    MsgBox("Si è vericato un errore nell'importazione dati." + Environment.NewLine +
                           "E' stato ripristinato l'archivio precedente l'importazione.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                End If
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Friend Sub NormalizzaCampiEsitati(ByRef Campi() As String)
        'controllo campi
        'controllo codici sub e produttore (può contenere codici errati)
        If Campi(Tracciati.ESITATI.SubAgenzia) > 999 Then Campi(Tracciati.ESITATI.SubAgenzia) = 0
        If Campi(Tracciati.ESITATI.Produttore) > 9999 Then Campi(Tracciati.ESITATI.Produttore) = 0

        'taglia e sostituisce nel contraente le " con spazio per evitare errori SQL
        Campi(Tracciati.ESITATI.Contraente) = Left(Campi(Tracciati.ESITATI.Contraente).Trim, 25)
        Campi(Tracciati.ESITATI.Contraente) = Campi(Tracciati.ESITATI.Contraente).Replace(Chr(34), Chr(32))

        'correzione PIVA che è nella forma ="012345678901"
        If Campi(Tracciati.ESITATI.CodiceFiscale).StartsWith("=") Then
            Campi(Tracciati.ESITATI.CodiceFiscale) = Campi(Tracciati.ESITATI.CodiceFiscale).Substring(2, 11)
        End If

        'quando fraz è vuoto (può succedere)
        If String.IsNullOrEmpty(Campi(Tracciati.ESITATI.Fraz)) Then Campi(Tracciati.ESITATI.Fraz) = 0

        'quando codice cassa è vuoto
        If String.IsNullOrEmpty(Campi(Tracciati.ESITATI.CodiceCassa)) Then Campi(Tracciati.ESITATI.CodiceCassa) = "00"
    End Sub

    Public Function MdbVuoto() As String
        MdbVuoto = Path.Combine(Utx.Globale.Paths.CartellaModelli, "Vuoto.mdb")
    End Function

    Public Function PathArchivioDatiAgenzia(Agenzia As String) As String
        PathArchivioDatiAgenzia = Path.Combine(Utx.Globale.Paths.DiscoApp & "Unitools\ArchivioDati", Agenzia)
    End Function

    Public Function TipoFileMagiaToString(TipoFile As Utx.Enumerazioni.TipoFileMagia) As String
        Select Case TipoFile
            Case Utx.Enumerazioni.TipoFileMagia.Avvisi
                Return "Avvisi"
            Case Utx.Enumerazioni.TipoFileMagia.AvvisiVita
                Return "Avvisi"
            Case Utx.Enumerazioni.TipoFileMagia.Sinistri
                Return "Sinistri"
            Case Utx.Enumerazioni.TipoFileMagia.Incassi
                Return "Incassi"
            Case Utx.Enumerazioni.TipoFileMagia.Anag
                Return "Anag"
            Case Utx.Enumerazioni.TipoFileMagia.Arretrati
                Return "Arretrati"
            Case Utx.Enumerazioni.TipoFileMagia.MonitorQT
                Return "MonitorQT"
            Case Utx.Enumerazioni.TipoFileMagia.Riserve
                Return "Riserve"
            Case Utx.Enumerazioni.TipoFileMagia.MovimentiPTF
                Return "MovimentiPTF"
            Case Utx.Enumerazioni.TipoFileMagia.SinistriBase
                Return "SinistriBase"
            Case Else
                Return "Altro"
        End Select
    End Function

    Public Function RinominaFile(FileOrigine As String,
                                 NuovoNome As String) As String
        Try
            'se il file non esiste già
            If Path.GetFileName(FileOrigine) <> NuovoNome Then
                'rinomina il file
                My.Computer.FileSystem.RenameFile(FileOrigine, NuovoNome)
            End If

            'restituisce il nuovo fullpath del file
            Return Path.Combine(Path.GetDirectoryName(FileOrigine), NuovoNome)

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Public Function Text2Html(Pagina As String) As Windows.Forms.HtmlDocument
        Try
            Dim wb As New Windows.Forms.WebBrowser
            wb.ScriptErrorsSuppressed = True
            wb.DocumentText = ""
            wb.Document.Write(Pagina)

            Return wb.Document

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Public Function Html2Dom(ByRef PaginaHtml As String) As MSHTML.IHTMLDocument
        Try
            Dim Doc As Object = New mshtml.HTMLDocument
            Doc.Open()
            Doc.Write(PaginaHtml)
            Doc.Close()

            Return Doc

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function

    Public Function StringToDate(Data As String) As Object
        Try
            If IsDate(Data) Then
                Return CDate(Data).Date
            Else
                Return DBNull.Value
            End If

        Catch ex As Exception
            Globale.Log.Info(ex.Message)
            Return DBNull.Value
        End Try
    End Function

    Public Function StringToNumber(Numero As String) As Single
        Try
            Numero = Numero.Replace(",", ".") 'notazione americana

            If IsNumeric(Numero) Then
                Return Val(Numero)
            Else
                Return 0
            End If

        Catch ex As Exception
            Globale.Log.Info(ex.Message)
            Return 0
        End Try
    End Function
End Module
