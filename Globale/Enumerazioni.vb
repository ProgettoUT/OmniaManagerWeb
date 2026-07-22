Namespace Enumerazioni
    Public Enum TipoAmbiente
        [DIR] = 0
        [PP] = 1
        [PP2DIR] = 2
    End Enum
    'profilo app
    Public Enum ProfiloApp
        NESSUNO = 0
        COMPLETO = 1
        SINISTRI = 2
        POSTALIZZAZIONE = 3
        SINISTRI_POSTALIZZAZIONE = 4
    End Enum
    'tipo file magia e non solo
    Public Enum TipoFileMagia
        NonCatalogato = 0
        Avvisi = 1
        AvvisiVita = 4
        Sinistri = 5
        Incassi = 6
        Anag = 7
        Arretrati = 8
        MonitorQT = 9
        Riserve = 10
        MovimentiPTF = 11
        SinistriBase = 12
        PrimaNota = 13
        MFee = 14
        UBox = 15
        Titoli = 20 'da flusso omnia
        Polizze = 21 'necessario con flusso omnia. prima erano aggregati ad anag (7)
        SinistriControparte = 22
        AndamentoSinistri = 23
        MonitorQT_KMS = 24
        AnagNew = 25 'nuova anagrafica clienti
    End Enum
    Public Enum TipoFileDoc
        QUIETANZAMENTO = 0 'liste qt
        FLEX = 2
        BUSTE = 3
    End Enum
    'cartelle documenti unipol
    Public Enum DocFolderType
        SP_RCA
        PRECONTO
        LISTE_QT
        BUSTE
    End Enum
    'sezione budget
    Public Enum Comparti
        AUTO = 1
        RP = 2
        SALUTE = 3
        AZIENDE = 4
        RCG = 5
        ALTRIRAMI = 6
        VITA = 7
    End Enum

    Public Enum Settori
        AUTO = 1
        RE = 2
        VITA = 3
    End Enum

    Public Enum Aggregati
        DANNI = 1
        VITA = 2
    End Enum
    'ex gruppo
    Public Enum ExGruppo
        EX_UNIPOL
        EX_AURORA
        EX_FONSAI
        EX_NAVALE
    End Enum

    Public Enum TipoOperazioneOnLine
        ESSIG_ON_DEMAND = 1
    End Enum

    Public Module Funzioni
        Public Function CodiceFileMagia(TipoFile As TipoFileMagia) As String
            Return Val(TipoFile).ToString.PadLeft(2, "0")
        End Function
    End Module
End Namespace
