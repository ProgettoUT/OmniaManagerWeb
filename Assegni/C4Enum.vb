Public Class C4Enum

#Region "Enumerazioni"
    Public Enum ParametriScanner
        CARTELLA_DESTINAZIONE = 1
        RISOLUZIONE = 3
        TIPO_SCANSIONE = 4
        FORMATO_IMMAGINE = 8
    End Enum

    Public Enum TipoScansione
        '0=grigi, 1=colore, 2=bn
        BN = 2
        Grigi = 0
        Colore = 1
    End Enum

    Public Enum FormatoImmagine
        JPG = 5
    End Enum

    'dal manuale emmedi:
    '   1 = software 4Cheque attivato e scanner collegato;
    '  -4 = nessun scanner rilevato
    ' 100 = software 4Cheque in valutazione e scanner collegato
    '-100 = software 4Cheque in valutazione conclusa e scanner collegato
    ' -99 = software 4Cheque non attivato e concluso o non iniziato il periodo di prova e scanner collegato;
    ' -90 = è collegato uno scanner che non è supportato dal software 4Cheque (es.Fi N1800)

    Public Enum EmmediMsg
        FI_ATTIVATO = 1 'licenza ok e scanner attivo
        FI_DEMO = 100 'demo 30 gg
        FI_GENERIC_ERROR = -2
        FI_ERROR_LOADING_DLL = -3
        FI_SOURCE_NOT_FOUND = -4
        FI_UNABLE_TO_OPEN_SOURCE = -5
        FI_NOT_INITIALIZED = -6
        FI_FEEDER_EMPTY = -7
        FI_RUNNING = -8
        FI_UNKNOWN_PARAMETER = -9
        FI_FEEDERTRACK_ERROR = -10
        FI_SCANNER_NOT_SUPPORTED = -90
        FI_NO_LICENSE = -99
        FI_DEMO_END = -100
    End Enum
#End Region

    Public Shared Function DeskMsg(ByVal CodiceErrore As C4Enum.EmmediMsg) As String
        Select Case CodiceErrore

            Case C4Enum.EmmediMsg.FI_ATTIVATO
                Return "Scanner pronto"
            Case C4Enum.EmmediMsg.FI_DEMO
                Return "Scanner pronto - DEMO"
            Case C4Enum.EmmediMsg.FI_GENERIC_ERROR
                Return "Errore generico"
            Case C4Enum.EmmediMsg.FI_ERROR_LOADING_DLL
                Return "Impossibile caricare l'interfaccia TWAIN"
            Case C4Enum.EmmediMsg.FI_SOURCE_NOT_FOUND
                Return "Scanner non trovato"
            Case C4Enum.EmmediMsg.FI_UNABLE_TO_OPEN_SOURCE
                Return "Impossibile aprire lo scanner"
            Case C4Enum.EmmediMsg.FI_NOT_INITIALIZED
                Return "Scanner non inizializzato"
            Case C4Enum.EmmediMsg.FI_FEEDER_EMPTY
                Return "Cassetto vuoto"
            Case C4Enum.EmmediMsg.FI_RUNNING
                Return "Scanner occupato"
            Case C4Enum.EmmediMsg.FI_UNKNOWN_PARAMETER
                Return "Parametro sconosciuto"
            Case C4Enum.EmmediMsg.FI_FEEDERTRACK_ERROR
                Return "Cassetto inceppato"
            Case C4Enum.EmmediMsg.FI_NO_LICENSE
                Return "Non ci sono licenze installate"
            Case C4Enum.EmmediMsg.FI_SCANNER_NOT_SUPPORTED
                Return "Scanner non supportato"
            Case Else
                Return "Errore imprevisto"
        End Select

    End Function

    Public Shared Function DeskMsgEsteso(ByVal CodiceErrore As C4Enum.EmmediMsg) As String
        Return String.Format("{0} ({1})", Val(CodiceErrore), DeskMsg(CodiceErrore))
    End Function

End Class
