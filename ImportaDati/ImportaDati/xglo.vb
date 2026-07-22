Imports System.IO
Imports System.Text

Module xglo

    'Friend Structure GlobalSet
    '    'generale
    '    Friend Compagnia As Integer
    '    Friend CodiceAgenzia As String
    '    Friend Sede As String
    '    Friend ImportaForzature As Boolean
    '    Friend ContatoreFileSinistri As Integer
    '    Friend LetturaArchivio As Boolean
    '    'path
    '    Friend PathExe As String
    '    Friend PathDati As String
    '    Friend PathDbArrivi As String
    '    Friend PathArchivioDati As String 'root
    '    Friend PathArchivioDatiAgenzia As String 'archivio dell'agenzia richiesta
    '    Friend PathArchivioMagia As String 'storico di magia
    '    Friend UTModelliLoc As String
    '    Friend UTCartellaTemp As String
    '    Friend UTCartellaUnzip As String
    '    Friend UTArriviLoc As String
    '    Friend UTArriviEmme As String
    '    Friend UTArriviEmmeAgenzia As String
    '    'database
    '    Friend FullNameDbArrivi As String
    '    Friend FullNameDbInfo As String
    '    'stringhe di connessione
    '    Friend MDBConnectionString As String
    '    Friend MDBConnectionStringEx As String
    '    Friend MDBConnectionStringArrivi As String
    '    Friend MDBConnectionStringDbLink As String
    '    Friend MDBConnectionStringDbInfo As String
    '    Friend MDBConnectionStringDbModello As String
    '    Friend CSVDriver As String
    '    Friend XLSDriver As String
    '    'varie
    '    Friend HelpFile As String
    '    Friend Impo As Config
    '    Friend Errore As Boolean
    '    Friend DatiArrivati As NuoviDati
    '    Friend AnnullaImportazioneDati As Boolean
    '    Friend TitoloNotifiche As String
    '    Friend TestoNotifica As StringBuilder
    'End Structure

    Friend Structure NuoviDati
        Friend Avvisi As Boolean
        Friend Clienti As Boolean
        Friend Polizze As Boolean
        Friend Incassi As Boolean
        Friend Sinistri As Boolean
        Friend MonitorQt As Boolean
        Friend Riserve As Boolean
        Friend MovimentiPTF As Boolean
        Friend SinistriBase As Boolean
        Friend ListeQT As Boolean
        Friend ListeFlex As Boolean
        Friend Buste As Boolean
    End Structure

    Friend Structure Config
        Friend CodAgenzia As String
        Friend AgenziaPrevalente As Boolean
        Friend CodAgenziaPrevalente As String
        Friend CodiciSub As String
        Friend CodiciProd As String
        Friend DataInizioDL As Date
        Friend DataFineDL As Date
        Friend Provvigioni As String
        Friend PattoUnipol As Boolean
        Friend ListeQT As Boolean
        Friend ArchivioDati As Boolean
        Friend Buste As Boolean
    End Structure

    'Friend Glo As GlobalSet

    Friend Enum TipoFileMagia
        [NonCatalogato] = 0
        [Avvisi] = 1
        [AvvisiVita] = 4
        [Sinistri] = 5
        [Incassi] = 6
        [Anag] = 7
        [Arretrati] = 8
        [MonitorQT] = 9
        [Riserve] = 10
        [MovimentiPTF] = 11
        [SinistriBase] = 12
        [PrimaNota] = 13
        [MFee] = 14
    End Enum

    'tipologie di doc da scaricare
    Friend Enum TipoFileDoc
        [Quietanzamento] = 0
        [SinistriBase] = 1
        [Flex] = 2
        [Buste] = 3
    End Enum

    ''tipologie di doc quietanzamento da scaricare (TipoFileDoc = 0)
    Friend Enum TipoDocQT
        [RcaSospese] = 0
        [RcaCfErrato] = 1
        [ReNonQT] = 2
        [ReDaRegolare] = 3
        [RecuperiFranchigie] = 4
        [PeriodiRegolazione] = 5
        [RcaBloccate] = 6
        [ReCoass] = 7
        [RcaVincolate] = 8
        [ReRichioEstero] = 9
        [EtaInfortuni] = 10
    End Enum

    'tipologie di doc flex da scaricare (TipoFileDoc = 2)
    Friend Enum TipoDocFlex
        [ElencoFlex] = 0
        [ElencoFlexCampagne] = 1
        [StatFlex] = 2
        [StatFlex11] = 3
    End Enum

    Friend cm As New ContextMenuStrip
    Public Event ItemClicked As ToolStripItemClickedEventHandler

    'dataset di configurazione
    Friend dsConfig As New DataSet
    Friend cnArrivi As New OleDb.OleDbConnection
    Friend DizionarioPath As New Dictionary(Of TipoFileMagia, String)

    Friend Function ImpostaVariabiliGlobali() As Boolean
        Try
            If New DriveInfo("M").IsReady Then
                'dizionario path
                With DizionarioPath
                    .Add(TipoFileMagia.Avvisi, "DATI/ARCHIVIO/AVVISIDANNI/")
                    .Add(TipoFileMagia.AvvisiVita, "DATI/ARCHIVIO/AVVISIVITA/")
                    .Add(TipoFileMagia.Sinistri, "DATI/ARCHIVIO/DATISIN/")
                    .Add(TipoFileMagia.Incassi, "DATI/ARCHIVIO/DATIINC/")
                    .Add(TipoFileMagia.Anag, "DATI/ARCHIVIO/DATICLI/")
                    .Add(TipoFileMagia.MonitorQT, "DATI/ARCHIVIO/LISTEQUIETANZAMENTO/")
                    .Add(TipoFileMagia.Riserve, "DATI/ARCHIVIO/COSTISIN/")
                    .Add(TipoFileMagia.MovimentiPTF, "DATI/ARCHIVIO/DATICLI/")
                    .Add(TipoFileMagia.SinistriBase, "DATI/ARCHIVIO/PROVVIGIONALERCA/")
                    .Add(TipoFileMagia.PrimaNota, "DATI/ARCHIVIO/PRIMANOTA/")
                    .Add(TipoFileMagia.MFee, "DATI/ARCHIVIO/MANAGEMENTFEE/")
                End With

                'With Glo
                '    'viene usato per parcheggiare il testo di notifica nel tab e nel flag ready
                '    .TestoNotifica = New StringBuilder

                '    .Compagnia = PcToCompagnia()
                '    .CodiceAgenzia = PcToAgenzia()
                '    .Sede = PcToSede()

                '    If .CodiceAgenzia = "-ERR" Then
                '        Return False
                '    End If

                '    'i path
                '    .PathExe = "C:\ApplicazioniDirezione\Unitools"
                '    .PathDati = "M:\Unitools\Dati"
                '    .PathArchivioDati = "M:\Unitools\ArchivioDati"
                '    .PathArchivioMagia = "M:\Magia\Storico"
                '    .UTArriviEmme = "M:\Unitools\Arrivi"
                '    .UTModelliLoc = Path.Combine(Glo.PathExe, "Modelli")
                '    .UTArriviLoc = Path.Combine(Glo.PathExe, "Arrivi") 'cartella locale arrivi
                '    .UTCartellaTemp = Path.Combine(Glo.UTArriviLoc, "Temp") 'cartella temp in arrivi per scaricare i file
                '    .UTCartellaUnzip = Path.Combine(Glo.UTCartellaTemp, "Unzip")
                '    'le stringhe di connessione
                '    .MDBConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source="
                '    .MDBConnectionStringEx = "Provider = Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Mode=12; Data Source="
                '    .MDBConnectionStringDbModello = Glo.MDBConnectionString + Path.Combine(Glo.UTModelliLoc, "DbUt.mdb")
                '    .MDBConnectionStringDbLink = GetEnvironmentVar("UNITOOLS_STRINGA_CONNESSIONE_DB")
                '    .CSVDriver = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=""text;HDR=Yes;FMT=Delimited(;)"";Data Source="
                '    .XLSDriver = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"";Data Source="


                '    'help
                '    .HelpFile = Path.Combine(Glo.PathExe, "Unitools.chm")

                '    'se le cartelle già esistono non si genera errore
                '    'crea cartella arrivi su M:
                '    Directory.CreateDirectory(Glo.UTArriviEmme)
                '    'crea cartella arrivi in locale su C:
                '    Directory.CreateDirectory(Glo.UTArriviLoc)
                '    'crea cartella arrivi\temp in locale
                '    Directory.CreateDirectory(Glo.UTCartellaTemp)
                '    'crea cartella arrivi\temp\unzip in locale
                '    Directory.CreateDirectory(Glo.UTCartellaUnzip)
                'End With

                Return True
            Else
                MsgBox("Disco M: non pronto o non disponibile", MsgBoxStyle.Exclamation)
                Return False
            End If

        Catch ex As Exception
            AddLog(AppLogFile, ex.StackTrace)
            Return False
        End Try
    End Function

    Friend Sub cm_ItemClicked(ByVal sender As Object,
                              ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)

        Glo.AnnullaImportazioneDati = True
        IconaNotifica.Text = "Annullo importazione..."
        AddLog(">>> Importazione annullata dall'utente", True)
        '---------------------------------------------------------------------------------
        'la chiusura della connessione provoca un errore che produce come conseguenza la
        'chiusura dell'applicazione. non viene inviato log all'assistenza
        cnArrivi.Close()
        '---------------------------------------------------------------------------------
    End Sub
End Module
