Imports System.IO
Imports System.Data.OleDb

Public Class FileCasellario

    Public Event Errore(Messaggio As String)
    Public Event VerificatoErroreCritico(Messaggio As String)

    Private Const UrlBase As String = "https://ueba.unipol.it/dati/download1.asp?file=#file&percorso=#path"
    Private PathCasellario As New Dictionary(Of Utx.Enumerazioni.TipoFileDoc, String)
    Private PathArchiviazione As New Dictionary(Of Utx.Enumerazioni.TipoFileDoc, String)

    Public Enum ProvenienzaFile
        EMME
        DOWNLOAD
    End Enum

    Sub New()
        InitDizionarioPath()
    End Sub

    Public Sub Init()
        'init cartella archiviazione. eventualmente la crea
        Me.CartellaArchiviazione = Path.Combine(mAgenziaFiglia.Cartelle.ArchivioDati, PathArchiviazione(mTipoFile))

        Select Case mTipoFile
            Case Utx.Enumerazioni.TipoFileMagia.SinistriBase
                Me.CartellaArchiviazione = Path.Combine(mCartellaArchiviazione, mDataRiferimento.Year.ToString)
            Case Else
                Me.CartellaArchiviazione = Path.Combine(mCartellaArchiviazione, mDataRiferimento.Year.ToString)
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

    Private mTipoFile As Utx.Enumerazioni.TipoFileMagia
    Public Property TipoFile() As Utx.Enumerazioni.TipoFileMagia
        Get
            Return mTipoFile
        End Get
        Set(value As Utx.Enumerazioni.TipoFileMagia)
            mTipoFile = value
        End Set
    End Property

    Private Function TipoFileToString() As String
        'ToString non funziona in quanto restituisce l'identificatore dell'enumerazione
        Return Str(mTipoFile).Trim.PadLeft(2, "0")
    End Function

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
    Public Property DataRiferimento() As Date
        Get
            Return mDataRiferimento
        End Get
        Set(value As Date)
            mDataRiferimento = value
        End Set
    End Property

    Private mForzatura As Boolean
    Public Property Forzatura() As Boolean
        Get
            Return mForzatura
        End Get
        Set(value As Boolean)
            mForzatura = value
        End Set
    End Property

    Private mDataInizioForzatura As Date
    Public Property DataInizioForzatura() As Date
        Get
            Return mDataInizioForzatura
        End Get
        Set(value As Date)
            mDataInizioForzatura = value
        End Set
    End Property

    Private mFileDisponibile As Boolean
    Public ReadOnly Property FileDisponibile() As Boolean
        Get
            Return mFileDisponibile
        End Get
    End Property

    Private mFileScaricato As String
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
            .Add(Utx.Enumerazioni.TipoFileMagia.MonitorQT, "DATI/ARCHIVIO/LISTEQUIETANZAMENTO/")
            .Add(Utx.Enumerazioni.TipoFileMagia.MonitorQT_KMS, "DATI/ARCHIVIO/LISTEQUIETANZAMENTO/")
            .Add(Utx.Enumerazioni.TipoFileMagia.SinistriBase, "DATI/ARCHIVIO/PROVVIGIONALERCA/")
            .Add(Utx.Enumerazioni.TipoFileMagia.PrimaNota, "DATI/ARCHIVIO/PRIMANOTA/")
            .Add(Utx.Enumerazioni.TipoFileMagia.MFee, "DATI/ARCHIVIO/MANAGEMENTFEE/")
            .Add(Utx.Enumerazioni.TipoFileMagia.UBox, "DATI/ARCHIVIO/PROVVIGIONALERCA/")
            .Add(Utx.Enumerazioni.TipoFileMagia.MovimentiPTF, "") 'no download
        End With
        With PathArchiviazione
            .Add(Utx.Enumerazioni.TipoFileMagia.MonitorQT, Utx.Enumerazioni.TipoFileMagia.MonitorQT.ToString)
            .Add(Utx.Enumerazioni.TipoFileMagia.MonitorQT_KMS, Utx.Enumerazioni.TipoFileMagia.MonitorQT.ToString)
            .Add(Utx.Enumerazioni.TipoFileMagia.SinistriBase, Utx.Enumerazioni.TipoFileMagia.SinistriBase.ToString)
            .Add(Utx.Enumerazioni.TipoFileMagia.PrimaNota, Utx.Enumerazioni.TipoFileMagia.PrimaNota.ToString)
            .Add(Utx.Enumerazioni.TipoFileMagia.MFee, Utx.Enumerazioni.TipoFileMagia.MFee.ToString)
            .Add(Utx.Enumerazioni.TipoFileMagia.UBox, Utx.Enumerazioni.TipoFileMagia.UBox.ToString)
            .Add(Utx.Enumerazioni.TipoFileMagia.MovimentiPTF, Utx.Enumerazioni.TipoFileMagia.MovimentiPTF.ToString)
        End With
    End Sub

    Private Function UrlDownload() As String
        'path
        UrlDownload = Replace$(UrlBase, "#path", PathCasellario.Item(TipoFile), , , vbTextCompare)
        'nomefile
        UrlDownload = Replace$(UrlDownload, "#file", mNomeFile, , , vbTextCompare)
    End Function

    Private Function PreUrlDownload() As String
        'url da utilizzare prima della chiamata all'url del file
        Return String.Format("https://ueba.unipol.it/ueba/wcmextensions/crmDWAG/rest/update?id={0}1&dojo.preventCache={1}", NomeFile, Utx.FunzioniData.Timestamp.ToString)
    End Function

    Private Function FullNameArchivio() As String
        Return Path.Combine(mCartellaArchiviazione, Path.ChangeExtension(mNomeFile, "zip"))
    End Function

    Private Sub CancellaFileArchiviato()
        'se il file è stato scaricato prima dell'inizio della forzatura lo cancello
        If New FileInfo(FullNameArchivio).CreationTime < mDataInizioForzatura.Date Then
            File.Delete(FullNameArchivio)
        End If
    End Sub

    Private Function FileRecuperato() As String
        'estensione del file
        Dim Ext As String = Path.GetExtension(Me.FullNameArchivio).ToLower
        Select Case Ext
            Case ".zip"
                Return Path.Combine(mAgenziaFiglia.Cartelle.CartellaArriviLocaleAgenziaDL, "Archivio.zip")
            Case Else
                Return Path.Combine(mAgenziaFiglia.Cartelle.CartellaArriviLocaleAgenziaDL, "Archivio" + Ext)
        End Select
    End Function

    Private Function IsZippato(NomeFile As String) As Boolean
        Return (Path.GetExtension(Me.FullNameArchivio).ToLower = ".zip")
    End Function

    Public Sub ScaricaFile()
        Try
            Globale.IconaNotifica.Text = NomeFile

            'per sicurezza svuoto la cartella temp e unzip (non dovrebbe essere necessario)
            SvuotaTemp()
            mFileDisponibile = False
            File.Delete(Me.FileRecuperato)

            'se siamo in forzatura cancello il file per riscaricarlo
            If mForzatura = True Then
                File.Delete(Me.FullNameArchivio)
            End If

            'scarico o recupero file
            'se il file esiste in archivio lo recupero
            If File.Exists(Me.FullNameArchivio) = True Then
                'se è prevista l'importazione nel database
                If mImportazioneDB = True Then
                    'se NON siamo il modalità lettura archivio
                    If mAgenziaFiglia.SoloScaricoFile = False Then
                        Globale.Log.Info("Recupero file da cartella locale: " + NomeFile) 'non voglio scrivere tutta la url
                        mOrigineFile = ProvenienzaFile.EMME
                        File.Copy(Me.FullNameArchivio, Me.FileRecuperato)
                    End If
                End If
            Else
                'altrimenti lo scarico dal download agenzie
                Globale.Log.Info("Download file: " + NomeFile) 'non voglio scrivere tutta la url
                mOrigineFile = ProvenienzaFile.DOWNLOAD

                'chiamata preparatoria al download
                Dim response As Net.HttpWebResponse
                response = CallWeb(PreUrlDownload, Utx.Globale.LoginUniage)

                If response IsNot Nothing Then
                    response.Close()

                    'faccio il download
                    response = CallWeb(UrlDownload, Utx.Globale.LoginUniage)

                    If response IsNot Nothing Then
                        Globale.SalvaFileStream(Me.FileRecuperato, response)
                        response.Close()
                    End If
                End If
            End If

            'se il file esiste scaricato o recuperato da M:
            If File.Exists(Me.FileRecuperato) = True Then
                'se sto solo scaricando per completare l'archivio
                If mAgenziaFiglia.SoloScaricoFile = True Then
                    ArchiviaFile()
                    mFileDisponibile = True
                Else
                    If IsZippato(Me.FileRecuperato) Then
                        'unzippo il file
                        'altrimenti unzip per controllare il file scaricato e renderlo disponibile per l'eventuale importazione nel db
                        Dim ListaUnzip As List(Of String) = Utx.LibreriaZip.UnZipFile(Me.FileRecuperato, mAgenziaFiglia.Cartelle.CartellaArriviLocaleTempDL)
                        If ListaUnzip.Count > 0 Then
                            'decompressione riuscita - fullpath del file decompresso
                            mFileScaricato = Path.Combine(mAgenziaFiglia.Cartelle.CartellaArriviLocaleTempDL, ListaUnzip.Item(0))
                            mFileDisponibile = True
                            ArchiviaFile()
                        Else
                            'non si decomprime (forse è danneggiato) ed esiste in archivio lo rinomino così lo riscarica
                            File.Delete(Me.FileRecuperato)
                            File.Delete(Me.FullNameArchivio)
                            mFileScaricato = ""
                            mFileDisponibile = False
                            RaiseEvent Errore("Decompressione file non riuscita")
                        End If
                    Else
                        mFileScaricato = Me.FileRecuperato
                        mFileDisponibile = True
                    End If
                End If
            Else
                mFileScaricato = ""
                mFileDisponibile = False
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

    Public Sub ScaricaFile(FullPathFile As String)
        Try
            Globale.IconaNotifica.Text = NomeFile

            'per sicurezza svuoto la cartella temp e unzip (non dovrebbe essere necessario)
            SvuotaTemp()
            mFileDisponibile = False

            'copio il file nell'archivio
            Globale.Log.Info("Archivia file: " + NomeFile)
            ArchiviaFile(FullPathFile)

        Catch ex As Exception
            RaiseEvent Errore(ex.Message)
        End Try
    End Sub

    Private Sub ArchiviaFile()
        Try
            'archivia solo nella sede principale dell'agenzia o nella secondaria abilitata da config
            If mAgenziaFiglia.ConfigSedeSecondaria.Archivio = True Then
                'se proviene dal download
                If mOrigineFile = ProvenienzaFile.DOWNLOAD Then
                    'se già esiste cancella il file in archivio
                    File.Delete(Me.FullNameArchivio)
                    'se il file è in una categoria prevista lo sposta in archivio
                    If TipoFile() <> Utx.Enumerazioni.TipoFileMagia.NonCatalogato Then
                        File.Move(Me.FileRecuperato, Me.FullNameArchivio)
                    End If
                End If
            End If

        Catch ex As Exception
            Globale.LogErrori.Errore(ex)
            Globale.LogErrori.Info(String.Format("File scaricato: {0} - Nome archivio: {1}", Me.FileRecuperato, Me.FullNameArchivio))
        End Try
    End Sub

    Private Sub ArchiviaFile(FullPathFile As String)
        Try
            'archivia solo nella sede principale dell'agenzia o nella secondaria abilitata da config
            If mAgenziaFiglia.ConfigSedeSecondaria.Archivio = True Then
                'se già esiste cancella il file in archivio
                File.Delete(FullNameArchivio)
                'se il file è in una categoria prevista lo sposta in archivio
                If TipoFile() <> Utx.Enumerazioni.TipoFileMagia.NonCatalogato Then
                    File.Move(FullPathFile, Me.FullNameArchivio)
                End If
            End If

        Catch ex As Exception
            Globale.LogErrori.Errore(ex)
            Globale.LogErrori.Info(String.Format("File scaricato: {0} - Nome archivio: {1}", FullPathFile, Me.FullNameArchivio))
        End Try
    End Sub

    Public Sub PrimoAggiornamento()
        Globale.Log.Info(mTipoFile.ToString.ToUpper)
        UltimoAggiornamento()
        Globale.Log.Info(String.Format("Ultimo aggiornamento: {0:d}", mDataRiferimento))
        ProssimoAggiornamento()

        'limito la data del download prima nota
        If mTipoFile = Utx.Enumerazioni.TipoFileMagia.PrimaNota Then
            If mAgenziaFiglia.ConfigUnicont.AbilitazioneSIA = True Then
                'se fa la contabilità inizio al massimo da 6 mesi prima
                mDataRiferimento = Utx.FunzioniData.MaxDate(mDataRiferimento, Today.AddMonths(-6))
            Else
                'se NON fa la contabilità leggo da inizio mese corrente
                mDataRiferimento = Utx.FunzioniData.MaxDate(mDataRiferimento, Utx.FunzioniData.InizioMeseCorrente())
            End If
        End If

        Globale.Log.Info(String.Format("Prossimo aggiornamento: {0:d}", mDataRiferimento))
    End Sub

    Public Sub ProssimoAggiornamento()
        'calcolo data del prossimo aggiornamento 
        Select Case mTipoFile
            Case Utx.Enumerazioni.TipoFileMagia.PrimaNota
                mDataRiferimento = mDataRiferimento.AddDays(1)
            Case Utx.Enumerazioni.TipoFileMagia.SinistriBase
                'mi sposto al 1 aprile dell'anno dopo
                mDataRiferimento = Utx.FunzioniData.InizioMese(New DateTime(mDataRiferimento.Year + 2, 4, 1))
            Case Utx.Enumerazioni.TipoFileMagia.MovimentiPTF
                mDataRiferimento = Utx.FunzioniData.InizioProssimaDecade(mDataRiferimento)
            Case Utx.Enumerazioni.TipoFileMagia.MonitorQT_KMS
                mDataRiferimento = Utx.FunzioniData.InizioMese(mDataRiferimento.AddMonths(1))
            Case Else
                'tutto il resto con avanzamento mensile
                mDataRiferimento = Utx.FunzioniData.InizioMese(mDataRiferimento.AddMonths(1))
        End Select
    End Sub

    Private Sub UltimoAggiornamento()
        Try
            'se sto solo leggendo l'archivio
            If mAgenziaFiglia.SoloScaricoFile = True Then
                DataInizioArchiviazione(TipoFile)
                Exit Sub
            End If

            'Dim DbInfo As String = Path.Combine(Me.AgenziaFiglia.Cartelle.CartellaDati, "Info.mdb")
            'Globale.Log.Trace("Tipo " & TipoFileToString())
            'Globale.Log.Trace("Agenzia " & mRecordConfig.AgenziaCollegata)
            'Globale.Log.Trace(DbInfo)

            'leggo i dati del calendario direttamente dal db info
            Dim Query As String = String.Format("SELECT Max(DataFine) 
                FROM CalendarioUt 
                WHERE TipoFile = '{0}' AND Agenzia = '{1}' AND NOT (NomeFile LIKE '%LEGENDA%')", TipoFileToString, mRecordConfig.AgenziaCollegata)

            mDataRiferimento = Utx.WsCommand.ExecuteScalar(Query, Me.AgenziaFiglia.CodiceAgenziaFiglia).Valore

        Catch ex As Exception
            Globale.Log.Trace(ex.Message)
            Select Case mTipoFile
                Case Utx.Enumerazioni.TipoFileMagia.Avvisi, Utx.Enumerazioni.TipoFileMagia.AvvisiVita 'avvisi leggo l'ultimo trimestre
                    mDataRiferimento = Utx.FunzioniData.InizioMese(Today.AddMonths(-3))

                Case Utx.Enumerazioni.TipoFileMagia.Incassi 'incassi leggo l'anno precedente
                    mDataRiferimento = New DateTime(Now.Year - 2, 12, 31)

                Case Utx.Enumerazioni.TipoFileMagia.MonitorQT, Utx.Enumerazioni.TipoFileMagia.MonitorQT_KMS 'monitorQT leggo da inizio d'anno
                    mDataRiferimento = Utx.FunzioniData.FineAnnoPrecedente(Today)

                Case Utx.Enumerazioni.TipoFileMagia.MovimentiPTF 'movimenti nuovo PTF dal 01/09/2016
                    mDataRiferimento = #8/31/2016#

                Case Utx.Enumerazioni.TipoFileMagia.SinistriBase 'file base sinistri patto unipol
                    mDataRiferimento = #1/1/2011#

                Case Utx.Enumerazioni.TipoFileMagia.PrimaNota 'prima nota 6 mesi prima
                    mDataRiferimento = Today.AddMonths(-6)

                Case Utx.Enumerazioni.TipoFileMagia.MFee
                    mDataRiferimento = #8/1/2014#

                Case Utx.Enumerazioni.TipoFileMagia.UBox
                    mDataRiferimento = #7/1/2015# 'il file esiste da 08/2015

                Case Else
                    'mi sposto al giorno prima dell'inizio del periodo per fare in modo che
                    'non venga saltato il primo giorno o il primo mese
                    mDataRiferimento = mRecordConfig.DataInizio.AddDays(-1)
            End Select

            'se non si tratta del patto unipol
            If TipoFile() <> Utx.Enumerazioni.TipoFileMagia.SinistriBase Then
                'parto comunque a partire dalla data inizio DL
                mDataRiferimento = Utx.FunzioniData.MaxDate(mDataRiferimento, mRecordConfig.DataInizio.AddDays(-1))
            End If
        End Try
    End Sub

    Private Sub DataInizioArchiviazione(TipoFile As Utx.Enumerazioni.TipoFileMagia)
        Select Case TipoFile
            Case Utx.Enumerazioni.TipoFileMagia.MonitorQT 'monitorQT leggo da inizio d'anno
                mDataRiferimento = Utx.FunzioniData.FineAnnoPrecedente(Today)

            Case Else
                'mi sposto al giorno prima dell'inizio del periodo per fare in modo che
                'non venga saltato il primo giorno o il primo mese
                'Glo.Impo.DataInizioDL contiene l'impostazione generale
                mDataRiferimento = mRecordConfig.DataInizio.AddDays(-1)
        End Select
    End Sub

    Public Function MaxDataDownload() As Date
        Return Utx.FunzioniData.MinDate(Today, Utx.FunzioniData.FineMese(mRecordConfig.DataFine))
    End Function

    Public Shared Function FileGiaScaricato(NomeFile As String,
                                            ByRef cnArrivi As OleDbConnection) As Boolean
        'controlla se il file è già nel db arrivi e quindi è stato già scaricato in questa sessione
        Try
            Using cmd As New OleDbCommand
                cmd.Connection = cnArrivi
                cmd.CommandType = CommandType.Text
                cmd.CommandText = String.Format("SELECT Count(*) FROM CalendarioUt WHERE Trim(NomeFile) = '{0}'",
                                                Path.GetFileNameWithoutExtension(NomeFile))

                Return (cmd.ExecuteScalar > 0)
            End Using

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function DataRicezioneFile(cnStringInfo As String,
                                             NomeFile As String) As Date
        'controllo data ricezione file
        Try
            Using c As New OleDbConnection(cnStringInfo)
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = String.Format("SELECT Max(DataRicezione) FROM CalendarioUt WHERE Trim(NomeFile) = '{0}",
                                                    Path.GetFileNameWithoutExtension(NomeFile))
                    Return cmd.ExecuteScalar
                End Using
            End Using

        Catch ex As Exception
            Return #1/1/2000#
        End Try
    End Function

    Friend Sub AggiornaCalendarioUt(DataInizio As Date,
                                    DataFine As Date,
                                    Optional Consolida As Date = #1/1/2000#,
                                    Optional SoloUltimoAggiornamento As Boolean = False)
        Try
            'aggiorno calendarioUT
            Using cmd As New OleDbCommand
                With cmd
                    .Connection = mAgenziaFiglia.Connessione
                    .CommandType = CommandType.Text

                    'nel caso viene richiesto di conservare solo il record dell'ultimo scarico
                    'cancello gli altri con lo stesso tipo file (dovrebbe essere uno solo)
                    If SoloUltimoAggiornamento = True Then
                        .CommandText = "DELETE * FROM CalendarioUt WHERE TipoFile = ?"
                        .Parameters.Clear()
                        .Parameters.AddWithValue("TipoFile", TipoFileToString)
                        .ExecuteNonQuery()
                    End If

                    'ora aggiorno il calendario inserendo il nuovo record
                    .CommandText = "INSERT INTO CalendarioUt(Agenzia,TipoFile,DataInizio,DataFine,NomeFile,DataRicezione,Consolida) VALUES(?,?,?,?,?,?,?)"

                    .Parameters.Clear()
                    .Parameters.AddWithValue("Agenzia", mRecordConfig.AgenziaCollegata)
                    .Parameters.AddWithValue("TipoFile", TipoFileToString)
                    .Parameters.AddWithValue("Inizio", DataInizio)
                    .Parameters.AddWithValue("Fine", DataFine)
                    .Parameters.AddWithValue("File", Path.GetFileNameWithoutExtension(mNomeFile).ToUpper)
                    .Parameters.AddWithValue("Ricezione", Now.ToString)
                    .Parameters.AddWithValue("Consolida", Consolida)

                    .ExecuteNonQuery()
                End With
            End Using

        Catch ex As Exception
            'se non riesce ad aggiornare il calendario svuota la tabella
            Globale.Log.Info(ex)
            SvuotaTabella()
        End Try
    End Sub

    Public Sub AggiornaCalendarioUtInfo(DataInizio As Date,
                                        DataFine As Date,
                                        Optional Consolida As Date = #1/1/2000#,
                                        Optional SoloUltimoAggiornamento As Boolean = False)

        'aggiorna direttamente il calendario in info
        Try
            Using c As New OleDbConnection(mAgenziaFiglia.ConnectionStringDbInfo)
                c.Open()

                Using cmd As New OleDbCommand
                    cmd.Connection = c
                    cmd.CommandType = CommandType.Text

                    'nel caso viene richiesto di conservare solo il record dell'ultimo scarico
                    'cancello gli altri con lo stesso tipo file (dovrebbe essere uno solo)
                    If SoloUltimoAggiornamento = True Then
                        cmd.CommandText = "DELETE FROM CalendarioUt WHERE Agenzia = ? AND TipoFile = ?"
                        cmd.Parameters.Clear()
                        cmd.Parameters.AddWithValue("Agenzia", mRecordConfig.AgenziaCollegata)
                        cmd.Parameters.AddWithValue("TipoFile", TipoFileToString)
                        cmd.ExecuteNonQuery()
                    End If

                    'ora aggiorno il calendario inserendo il nuovo record
                    cmd.CommandText = "INSERT INTO CalendarioUt(Agenzia,TipoFile,DataInizio,DataFine,NomeFile,DataRicezione,Consolida) " +
                                      "VALUES(?,?,?,?,?,?,?)"

                    With cmd.Parameters
                        .Clear()
                        .AddWithValue("Agenzia", mRecordConfig.AgenziaCollegata)
                        .AddWithValue("TipoFile", TipoFileToString)
                        .AddWithValue("Inizio", DataInizio)
                        .AddWithValue("Fine", DataFine)
                        .AddWithValue("File", Path.GetFileNameWithoutExtension(mNomeFile).ToUpper)
                        .AddWithValue("Ricezione", Now.ToString)
                        .AddWithValue("Consolida", Consolida)
                    End With

                    cmd.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            Globale.Log.Info(ex)
            'se non riesce ad aggiornare il calendario svuota la tabella
            SvuotaTabella()
        End Try
    End Sub

    Public Sub SvuotaTabella()
        Select Case mTipoFile
            Case Utx.Enumerazioni.TipoFileMagia.MonitorQT
                Utx.FunzioniDb.SvuotaTabella(mAgenziaFiglia.Connessione, "MonitorQT")
        End Select
    End Sub

    Private Sub SvuotaTemp()
        'svuota la cartella temp
        SvuotaCartella(mAgenziaFiglia.Cartelle.CartellaArriviLocaleTempDL)
    End Sub

    Private Sub FileCasellario_Errore(Messaggio As String) Handles Me.Errore
        Globale.Log.Info(Messaggio)
    End Sub

    Private Sub FileCasellario_VerificatoErroreCritico(Messaggio As String) Handles Me.VerificatoErroreCritico
        Globale.Log.Info(String.Format("Errore critico: {0}", Messaggio))
        mErroreCritico = True
    End Sub

    Public Shared Function TipoFileGestito(TipoFile As Utx.Enumerazioni.TipoFileDoc) As Boolean
        Select Case TipoFile
            Case Utx.Enumerazioni.TipoFileDoc.BUSTE, Utx.Enumerazioni.TipoFileDoc.FLEX, Utx.Enumerazioni.TipoFileDoc.QUIETANZAMENTO
                Return True
            Case Else
                Return False
        End Select
    End Function

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
