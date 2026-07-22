Namespace P01203
    Public Enum TipoSezione
        Infortuni
        SalvaCircolazione
        Assistenza
        Sconti
    End Enum

    Public Enum TipoPartita
        Infortuni
        SalvaCircolazione
        Assistenza
        Sconti
    End Enum

    Public Enum TipoGaranzia
        InfortuniBase
        InfortuniMorte
        InfortuniComa
        InfortuniIP
        InfortuniSpeseMediche
        InfortuniRicovero
        InfortuniConvalescenza
        InfortuniImmobilizzazione
        InfortuniTabellaINAIL
        InfortuniFranchigia3
        InfortuniSuperValutazione
        SalvaCircolazioneBase
        AssistenzaBase
        ScontiBase
    End Enum

    Public Enum TipoSoggettoEnum
        PersonaFisica
        PersonaGiuridica
    End Enum

    Public Enum TipologiaVeicoloEnum
        Autovettura = 11
        Autoveicolo = 12
        Autocarro0 = 21
        Camper = 22
        Motocicli = 23
        Ciclomotori = 24
        Natante = 29
        Autocarro1 = 31
        Autotreno = 32
        AutoArticolati = 33
        AutoSnodati = 34
        MacchinaAgricola = 41
        TrattoreStradale = 42
        MacchinaOperatrice = 43
    End Enum

    Public Enum ClasseRischioVeicoloEnum
        ClasseA = 1
        ClasseB = 2
        ClasseC = 3
        ClasseD = 4
    End Enum

    Public Enum InfortuniSceltaEnum
        SceltaPersona = 1
        SceltaFamiglia = 2
        SceltaVeicolo = 3
    End Enum

    Public Enum InfortuniFormaEnum
        CapitaliLiberi = 0
        Combinazione1 = 1
        Combinazione2 = 2
        Combinazione3 = 3
        Combinazione4 = 4
        Combinazione5 = 5
        Combinazione6 = 6
        Combinazione7 = 7
        Combinazione8 = 8
    End Enum

    Public Enum ScontoPoliennaleEnum
        Anni1 = 1
        Anni2 = 2
        Anni3 = 3
        Anni4 = 4
        Anni5 = 5
    End Enum
End Namespace
