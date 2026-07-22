Imports System.IO

Public Class DocCasellario

    Public Event Errore(Messaggio As String)
    Public Event VerificatoErroreCritico(Messaggio As String)

    Private Const UrlBase As String = "https://ueba.unipol.it/dati/download1.asp?file=#file&percorso=#path"
    Private ReadOnly PathCasellario As New Dictionary(Of Utx.Enumerazioni.TipoFileDoc, String)
    Private ReadOnly PathArchiviazione As New Dictionary(Of Utx.Enumerazioni.TipoFileDoc, String)

    Public Enum ProvenienzaFile
        EMME
        DOWNLOAD
    End Enum
    Friend Enum TipoDocQT
        RcaSospese = 0
        RcaCfErrato = 1
        ReNonQT = 2
        ReDaRegolare = 3
        RecuperiFranchigie = 4
        PeriodiRegolazione = 5
        RcaBloccate = 6
        ReCoass = 7
        RcaVincolate = 8
        ReRichioEstero = 9
        EtaInfortuni = 10
    End Enum
    Friend Enum TipoDocFlex
        ElencoFlex = 0
        ElencoFlexCampagne = 1
        StatFlex = 2
        StatFlex11 = 3
    End Enum

    Sub New()
        InitDizionarioPath()
    End Sub

    Public Sub Init()
        'cartella archiviazione
        Me.CartellaArchiviazione = Path.Combine(Utx.Globale.Paths.CartellaUnitoolsRete, PathArchiviazione(TipoFile))

        Select Case mTipoFile
            Case Utx.Enumerazioni.TipoFileDoc.QUIETANZAMENTO
                Me.CartellaArchiviazione = Path.Combine(mCartellaArchiviazione, Format(mDataRiferimento, "yyyy-MM"))
                mEstensioneFile = "csv"
            Case Utx.Enumerazioni.TipoFileDoc.FLEX
                Me.CartellaArchiviazione = Path.Combine(mCartellaArchiviazione, Format(mDataRiferimento, "yyyy-MM"))
                Me.CartellaArchiviazione = Path.Combine(mCartellaArchiviazione, "Flex") 'sotto-cartella flex
                mEstensioneFile = "csv"
            Case Utx.Enumerazioni.TipoFileDoc.BUSTE
                Me.CartellaArchiviazione = Path.Combine(mCartellaArchiviazione, Format(mDataRiferimento, "yyyy-MM"))
                mEstensioneFile = "csv"
        End Select
    End Sub

    Private mAgenziaFiglia As Utx.AgenziaFigliaOmnia
    Public Property AgenziaFiglia() As Utx.AgenziaFigliaOmnia
        Get
            Return mAgenziaFiglia
        End Get
        Set(value As Utx.AgenziaFigliaOmnia)
            mAgenziaFiglia = value
        End Set
    End Property

    Private mRecordConfig As Utx.RecordConfigOmnia
    Public Property RecordConfig() As Utx.RecordConfigOmnia
        Get
            Return mRecordConfig
        End Get
        Set(value As Utx.RecordConfigOmnia)
            mRecordConfig = value
        End Set
    End Property

    Private mTipoFile As Utx.Enumerazioni.TipoFileDoc
    Public Property TipoFile() As Utx.Enumerazioni.TipoFileDoc
        Get
            Return mTipoFile
        End Get
        Set(value As Utx.Enumerazioni.TipoFileDoc)
            mTipoFile = value
        End Set
    End Property

    Private mCodiceDoc As Integer
    Public Property CodiceDoc() As Integer
        Get
            Return mCodiceDoc
        End Get
        Set(value As Integer)
            mCodiceDoc = value
        End Set
    End Property

    Private mEstensioneFile As String
    Public ReadOnly Property Estensione() As String
        Get
            Return mEstensioneFile
        End Get
    End Property

    Private mFormatoData As String
    Public Property FormatoData() As String
        Get
            Return mFormatoData
        End Get
        Set(value As String)
            mFormatoData = value
        End Set
    End Property

    Private mNomeFile As String
    Public Property NomeFile() As String
        Get
            Return mNomeFile
        End Get
        Set(value As String)
            mNomeFile = value
        End Set
    End Property

    Private mDataRiferimento As Date
    Public ReadOnly Property DataRiferimento() As Date
        Get
            Return mDataRiferimento
        End Get
    End Property

    Private mFileDisponibile As Boolean
    Public ReadOnly Property FileDisponibile() As Boolean
        Get
            Return mFileDisponibile
        End Get
    End Property

    Private mFileScaricato As String 'è il file scaricato e decompresso
    Public ReadOnly Property FileScaricato() As String
        Get
            Return mFileScaricato
        End Get
    End Property

    Private mOrigineFile As ProvenienzaFile
    Public ReadOnly Property OrigineFile() As ProvenienzaFile
        Get
            Return mOrigineFile
        End Get
    End Property

    Private mCartellaArchiviazione As String
    Public Property CartellaArchiviazione() As String
        Get
            Return mCartellaArchiviazione
        End Get
        Set(value As String)
            mCartellaArchiviazione = value
            Directory.CreateDirectory(mCartellaArchiviazione)
        End Set
    End Property

    Private mImportazioneDB As Boolean
    Public Property ImportazioneDB() As Boolean
        Get
            Return mImportazioneDB
        End Get
        Set(value As Boolean)
            mImportazioneDB = value
        End Set
    End Property

    Private mErroreCritico As Boolean
    Public ReadOnly Property ErroreCritico() As Boolean
        Get
            Return mErroreCritico
        End Get
    End Property

    Private Sub InitDizionarioPath()
        With PathCasellario
            .Add(Utx.Enumerazioni.TipoFileDoc.QUIETANZAMENTO, "DATI/ARCHIVIO/LISTEQUIETANZAMENTO/")
            .Add(Utx.Enumerazioni.TipoFileDoc.FLEX, "DATI/ARCHIVIO/COMMERCIALE/")
            .Add(Utx.Enumerazioni.TipoFileDoc.BUSTE, "DATI/ARCHIVIO/SOLLECITI/")
        End With
        With PathArchiviazione
            .Add(Utx.Enumerazioni.TipoFileDoc.QUIETANZAMENTO, "Documenti_Unipol\Liste_Quietanzamento")
            .Add(Utx.Enumerazioni.TipoFileDoc.FLEX, "Documenti_Unipol\Liste_Quietanzamento")
            .Add(Utx.Enumerazioni.TipoFileDoc.BUSTE, "Documenti_Unipol\Buste")
        End With
    End Sub

    Private Function UrlDownload() As String
        'path
        UrlDownload = Replace$(UrlBase, "#path", PathCasellario.Item(mTipoFile), , , vbTextCompare)
        'nomefile
        UrlDownload = Replace$(UrlDownload, "#file", mNomeFile, , , vbTextCompare)
    End Function

    Private Function PreUrlDownload() As String
        'url da utilizzare prima della chiamata all'url del file
        Return String.Format("https://ueba.unipol.it/ueba/wcmextensions/crmDWAG/rest/update?id={0}1&dojo.preventCache={1}", NomeFile, Utx.FunzioniData.Timestamp.ToString)
    End Function

    Private Function FullNameArchivio() As String
        Return Path.Combine(mCartellaArchiviazione, Path.GetFileNameWithoutExtension(Me.NomeFile) + "." + mEstensioneFile)
    End Function

    Private Sub CancellaFileArchiviato()
        File.Delete(FullNameArchivio)
    End Sub

    Private Function FileRecuperato() As String
        Return Path.Combine(mAgenziaFiglia.Cartelle.CartellaArriviLocaleAgenziaDL, "Archivio.zip")
        'estensione del file
        'Dim Ext As String = Path.GetExtension(Me.FullNameArchivio).ToLower
        'Select Case Ext
        '    Case ".zip"
        '        Return Path.Combine(mAgenziaFiglia.Cartelle.CartellaArriviLocaleAgenziaDL, "Archivio.zip")
        '    Case Else
        '        Return Path.Combine(mAgenziaFiglia.Cartelle.CartellaArriviLocaleAgenziaDL, "Archivio" + Ext)
        'End Select
    End Function

    Private Function IsZippato(NomeFile As String) As Boolean
        Select Case Path.GetExtension(NomeFile).ToLower
            Case ".zip", ".exe"
                Return True
            Case Else
                Return False
        End Select
    End Function

    Public Sub ScaricaFile()
        Try
            Globale.IconaNotifica.Text = NomeFile

            'per sicurezza svuoto la cartella temp (non dovrebbe essere necessario)
            SvuotaTemp()
            mFileDisponibile = False

            'scarico o recupero file
            'se il file esiste in archivio lo riprendo
            If File.Exists(Me.FullNameArchivio) = True Then
                'se è prevista l'importazione nel database
                If mImportazioneDB = True Then
                    'se NON siamo il modalità lettura archivio
                    If mAgenziaFiglia.SoloScaricoFile = False Then
                        Globale.Log.Info("Recupero file da cartella locale: " + NomeFile) 'non voglio scrivere tutta la url
                        mOrigineFile = ProvenienzaFile.EMME 'indica provenienza da archivio locale
                        'copio il file nella posizione di lavorazione temporanea e lo rendo disponibile
                        mFileScaricato = FileDecompresso(Me.FullNameArchivio)
                        'File.Copy(Me.FullNameArchivio, mFileScaricato)
                        mFileDisponibile = File.Exists(mFileScaricato)
                    End If
                End If
            Else
                'altrimenti lo scarico dal download agenzie
                Globale.Log.Info("Download file: " + NomeFile) 'non voglio scrivere tutta la url
                mOrigineFile = ProvenienzaFile.DOWNLOAD

                File.Delete(Me.FileRecuperato)

                'chiamata preparatoria al download
                Dim response As Net.HttpWebResponse
                response = CallWeb(PreUrlDownload, Utx.Globale.LoginUniage)

                If response IsNot Nothing Then
                    response.Close()

                    'faccio il download
                    response = CallWeb(UrlDownload, Utx.Globale.LoginUniage)

                    If response IsNot Nothing Then
                        Globale.SalvaFileStream(Me.FileRecuperato, response)
                        mFileScaricato = FileDecompresso(Me.FileRecuperato)
                        response.Close()
                        mFileDisponibile = File.Exists(mFileScaricato)

                        If mFileDisponibile Then
                            'archivio
                            If mEstensioneFile = "zip" Then
                                ArchiviaFile(Me.FileRecuperato)
                            Else
                                ArchiviaFile(mFileScaricato)
                            End If
                        End If
                    Else
                        mFileDisponibile = False
                    End If
                Else
                    mFileDisponibile = False
                End If
            End If

        Catch ex As System.Net.WebException
            Select Case ex.Status
                Case Net.WebExceptionStatus.ConnectFailure, Net.WebExceptionStatus.NameResolutionFailure
                    RaiseEvent VerificatoErroreCritico(String.Format("Connessione non disponibile{0}{1}", Environment.NewLine, ex.Message))
                Case Net.WebExceptionStatus.ProtocolError
                    RaiseEvent Errore(String.Format("File non disponibile ({0})", CodiceErroreServer(ex.Message)))
                Case Else
                    RaiseEvent Errore(ex.Message)
            End Select
        Catch ex As Exception
            RaiseEvent Errore(ex.Message)
        End Try
        Application.DoEvents()
    End Sub

    Private Function FileDecompresso(FileOrigine As String) As String
        Try
            'se il file esiste
            If File.Exists(FileOrigine) = True Then
                'se è zippato
                If IsZippato(FileOrigine) Then
                    'unzippo il file: il file scaricato è sempre zippato
                    Dim ListaUnzip As List(Of String) = Utx.LibreriaZip.UnZipFile(FileOrigine, mAgenziaFiglia.Cartelle.CartellaArriviLocaleTempDL)

                    If ListaUnzip.Count > 0 Then
                        'decompressione riuscita - fullpath del file decompresso
                        Return Path.Combine(mAgenziaFiglia.Cartelle.CartellaArriviLocaleTempDL, ListaUnzip.Item(0))
                    Else
                        'non si decomprime (forse è danneggiato) ed esiste in archivio lo rinomino così lo riscarica
                        Globale.Log.Info(String.Format("Decompressione file non riuscita: {0}", FileOrigine))
                        Return ""
                    End If
                Else
                    Dim FileTemp As String = Path.Combine(mAgenziaFiglia.Cartelle.CartellaArriviLocaleTempDL, Path.GetFileName(FileOrigine))
                    File.Copy(FileOrigine, FileTemp)
                    Return FileTemp
                End If
            Else
                Return ""
            End If

        Catch ex As Exception
            RaiseEvent Errore(ex.Message)
            Return ""
        End Try
    End Function

    Private Sub ArchiviaFile(FullPathFile As String)
        Try
            'archivia solo nella sede principale dell'agenzia o nella secondaria abilitata da config
            If mAgenziaFiglia.ConfigSedeSecondaria.Archivio = True Then
                'se proviene dal download
                If mOrigineFile = ProvenienzaFile.DOWNLOAD Then
                    'se già esiste cancella il file zip
                    File.Delete(Me.FullNameArchivio)
                    File.Copy(FullPathFile, Me.FullNameArchivio)
                End If
            End If

        Catch ex As Exception
            Globale.LogErrori.Errore(ex)
            Globale.LogErrori.Info(String.Format("File da archiviare: {0} - Nome archivio: {1}", FullPathFile, Me.FullNameArchivio))
        End Try
    End Sub

    Public Sub PrimoAggiornamento()
        Globale.Log.Info(String.Format("{0}: codice doc {1}", mTipoFile, mCodiceDoc))
        UltimoAggiornamentoDoc()
        Globale.Log.Info(String.Format("Ultimo aggiornamento: {0:d}", mDataRiferimento))
        ProssimoAggiornamento()
        Globale.Log.Info(String.Format("Prossimo aggiornamento: {0:d}", mDataRiferimento))
    End Sub

    Public Sub ProssimoAggiornamento()
        Select Case mTipoFile
            Case Utx.Enumerazioni.TipoFileDoc.QUIETANZAMENTO
                mDataRiferimento = Utx.FunzioniData.InizioMese(mDataRiferimento.AddMonths(1))
            Case Utx.Enumerazioni.TipoFileDoc.FLEX
                If mCodiceDoc = 0 Then
                    'scanzione giornaliera
                    mDataRiferimento = mDataRiferimento.AddDays(1)
                Else
                    'scansione quindicinale
                    If mDataRiferimento.Day = 15 Then
                        'mi porto sull'ultimo giorno del mese
                        mDataRiferimento = Utx.FunzioniData.FineMese(mDataRiferimento)
                    Else
                        'avanzo di un mese e mi porto a giorno 15
                        mDataRiferimento = Utx.FunzioniData.QuindiciDelMese(mDataRiferimento.AddMonths(1))
                    End If
                End If
            Case Utx.Enumerazioni.TipoFileDoc.BUSTE
                'scansione decadale
                mDataRiferimento = Utx.FunzioniData.FineProssimaDecade(mDataRiferimento)
        End Select
    End Sub

    Public Function MaxDataDownload() As Date
        Select Case mTipoFile
            Case Utx.Enumerazioni.TipoFileDoc.QUIETANZAMENTO
                'calcolo la data massima per il download (mese corrente + 1)
                Dim MaxDataDL As Date = Utx.FunzioniData.FineMese(Today.AddMonths(1))
                'impongo la condizione di fine data DL presa dalla configurazione
                Return Utx.FunzioniData.MinDate(MaxDataDL, Utx.FunzioniData.FineMese(mRecordConfig.DataFine))
            Case Else
                Return Utx.FunzioniData.MinDate(Today, Utx.FunzioniData.FineMese(mRecordConfig.DataFine))
        End Select
    End Function

    Public Sub UltimoAggiornamentoDoc()
        Try
            Using cn As New OleDb.OleDbConnection(mAgenziaFiglia.ConnectionStringDbInfo)
                cn.Open()

                Using cmd As New OleDb.OleDbCommand
                    With cmd
                        .Connection = cn
                        .CommandType = CommandType.Text
                        .CommandText = "SELECT Max(DataFine) FROM CalendarioDoc " +
                                       "WHERE TipoFile = ? AND Codice = ? AND Agenzia = ?"

                        .Parameters.Clear()
                        .Parameters.AddWithValue("Tipo", mTipoFile)
                        .Parameters.AddWithValue("Codice", mCodiceDoc)
                        .Parameters.AddWithValue("Agenzia", mRecordConfig.AgenziaCollegata)
                    End With

                    mDataRiferimento = cmd.ExecuteScalar
                End Using
            End Using

            'limito la lettura dei periodi precedenti
            Select Case TipoFile
                Case Utx.Enumerazioni.TipoFileDoc.QUIETANZAMENTO
                    'arretro al massimo all'inizio alla fine dell'anno precedente e andando avanti
                    'comincerà a leggere gli archivi dall'inizio dell'anno corrente
                    mDataRiferimento = Utx.FunzioniData.MaxDate(mDataRiferimento, Utx.FunzioniData.InizioAnno(Today).AddMonths(-1))
                Case Utx.Enumerazioni.TipoFileDoc.FLEX
                    'comincerà a leggere gli archivi dall'inizio dell'anno precedente
                    mDataRiferimento = Utx.FunzioniData.MaxDate(mDataRiferimento, Utx.FunzioniData.InizioAnno(Today).AddMonths(-13))
            End Select

        Catch ex As Exception
            Select Case Val(TipoFile)
                Case Utx.Enumerazioni.TipoFileDoc.QUIETANZAMENTO
                    mDataRiferimento = Utx.FunzioniData.InizioAnno(Today).AddMonths(-1)
                Case Utx.Enumerazioni.TipoFileDoc.FLEX
                    mDataRiferimento = Utx.FunzioniData.InizioAnno(Today).AddMonths(-13)
                Case Utx.Enumerazioni.TipoFileDoc.BUSTE
                    'così parte a scaricare dall'inizio del mese corrente
                    mDataRiferimento = Utx.FunzioniData.InizioMese(Today).AddDays(-1)
                Case Else
                    'mi sposto al giorno prima dell'inizio del periodo per fare in modo che
                    'non venga saltato il primo giorno o il primo mese
                    'Glo.Impo.DataInizioDL contiene l'impostazione generale
                    mDataRiferimento = mRecordConfig.DataInizio.AddDays(-1)
            End Select
        End Try
        mDataRiferimento = Utx.FunzioniData.MaxDate(mDataRiferimento, mRecordConfig.DataInizio)
    End Sub

    Public Sub AggiornaCalendarioDocArrivi(InizioPeriodo As Date,
                                           FinePeriodo As Date)
        Try
            'aggiorna CalendarioDoc nel file arrivi da consolidare con l'importazione
            Using cmd As New OleDb.OleDbCommand

                'aggiorno CalendarioDoc
                With cmd
                    .Connection = mAgenziaFiglia.Connessione
                    .CommandType = CommandType.Text
                    .CommandText = "INSERT INTO CalendarioDoc(Agenzia,TipoFile,Codice,DataInizio,DataFine," +
                                                             "NomeFile,DataRicezione) " +
                                   "VALUES(?,?,?,?,?,?,?)"

                    .Parameters.AddWithValue("Agenzia", mRecordConfig.AgenziaCollegata)
                    .Parameters.AddWithValue("TipoFile", mTipoFile)
                    .Parameters.AddWithValue("Codice", mCodiceDoc)
                    .Parameters.AddWithValue("Inizio", InizioPeriodo)
                    .Parameters.AddWithValue("Fine", FinePeriodo)
                    .Parameters.AddWithValue("File", Path.GetFileNameWithoutExtension(mNomeFile).ToUpper)
                    .Parameters.AddWithValue("Ricezione", Today)

                    .ExecuteScalar()
                End With
            End Using

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        End Try
    End Sub

    Public Sub AggiornaCalendarioDocInfo(Optional FinePeriodo As Date = #1/1/1900#)
        Try
            If FinePeriodo = #1/1/1900# Then
                FinePeriodo = Utx.FunzioniData.FineMese(mDataRiferimento)
            End If

            'aggiorna CalendarioDoc direttamente nel db info
            Using c As New OleDb.OleDbConnection(mAgenziaFiglia.ConnectionStringDbInfo)
                c.Open()

                Using cmd As New OleDb.OleDbCommand
                    With cmd
                        .Connection = c
                        .CommandType = CommandType.Text
                        .CommandText = "INSERT INTO CalendarioDoc(Agenzia,TipoFile,Codice,DataInizio,DataFine," +
                                                                 "NomeFile,DataRicezione) " +
                                       "VALUES(?,?,?,?,?,?,?)"

                        .Parameters.AddWithValue("Agenzia", mRecordConfig.AgenziaCollegata)
                        .Parameters.AddWithValue("TipoFile", mTipoFile)
                        .Parameters.AddWithValue("Codice", mCodiceDoc)
                        .Parameters.AddWithValue("Inizio", Utx.FunzioniData.InizioMese(mDataRiferimento))
                        .Parameters.AddWithValue("Fine", FinePeriodo)
                        .Parameters.AddWithValue("File", NomeFile)
                        .Parameters.AddWithValue("Ricezione", Today)

                        .ExecuteScalar()
                    End With
                End Using
            End Using

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        End Try
    End Sub

    Private Sub SvuotaTemp()
        'svuota la cartella temp
        SvuotaCartella(mAgenziaFiglia.Cartelle.CartellaArriviLocaleTempDL)
    End Sub

    Private Sub DocCasellario_Errore(Messaggio As String) Handles Me.Errore
        Globale.Log.Info(Messaggio)
    End Sub

    Private Sub DocCasellario_VerificatoErroreCritico(Messaggio As String) Handles Me.VerificatoErroreCritico
        Globale.Log.Info(String.Format("Errore critico: {0}", Messaggio))
        mErroreCritico = True
    End Sub

    Private Function CallWeb(Url As String, login As Utx.AutenticazioneUeba) As Net.HttpWebResponse
        Try
            Dim request As Net.HttpWebRequest = Net.HttpWebRequest.Create(Url)
            request.Method = Net.WebRequestMethods.Http.Get
            request.AllowAutoRedirect = False
            request.CookieContainer = login.CookieContainer
            request.Timeout = 100000

            ' Get the response.
            Dim response As Net.HttpWebResponse = request.GetResponse()
            login.CookieContainer.Add(response.Cookies)

            If response.StatusCode = Net.HttpStatusCode.Found Then

                Dim newUrl = response.Headers("Location")
                If newUrl.StartsWith("/") Then
                    Dim a = New Uri(Url)
                    newUrl = a.AbsoluteUri.Substring(0, a.AbsoluteUri.LastIndexOf(a.AbsolutePath)) & newUrl
                End If
                response.Close()

                Return CallWeb(newUrl, login)
            End If

            Return response

        Catch ex As System.Net.WebException
            Select Case ex.Status
                Case Net.WebExceptionStatus.ConnectFailure, Net.WebExceptionStatus.NameResolutionFailure
                    RaiseEvent VerificatoErroreCritico(String.Format("Connessione non disponibile{0}{1}", Environment.NewLine, ex.Message))
                Case Net.WebExceptionStatus.ProtocolError
                    RaiseEvent Errore(String.Format("File non disponibile ({0})", CodiceErroreServer(ex.Message)))
                Case Else
                    RaiseEvent Errore(ex.Message)
            End Select

            Return Nothing
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return Nothing
        End Try
    End Function
End Class
