Namespace P01203
    Public Class P01203DE
        Inherits P00000DE

        Public DecodeTipologiaVeicolo As New Dizionario(Of Integer, String)
        Public DecodeInfortuniScelta As New Dizionario(Of Integer, String)
        Public DecodeInfortuniForma As New Dizionario(Of Integer, String)
        Public DecodeScontoPoliennale As New Dizionario(Of Integer, String)
        Public DecodeSalvaCircolazioneBasemassimale As New Dizionario(Of Decimal, String)
        Public DecodeTipoSoggetto As New Dizionario(Of Integer, String)

        Sub New()
            With DecodeSezione
                .Add(TipoSezione.Infortuni, "Infortuni")
                .Add(TipoSezione.SalvaCircolazione, "Salva Circolazione")
                .Add(TipoSezione.Assistenza, "Assistenza")
                .Add(TipoSezione.Sconti, "Sconto per poliennalità")
            End With

            With DecodePartita
                .Add(TipoPartita.Infortuni, "Infortuni")
                .Add(TipoPartita.SalvaCircolazione, "Salva Circolazione")
                .Add(TipoPartita.Assistenza, "Assistenza")
                .Add(TipoPartita.Sconti, "Sconto per poliennalità")
            End With

            With DecodeGaranzia
                .Add(TipoGaranzia.InfortuniBase, "Garanzia base")
                .Add(TipoGaranzia.InfortuniMorte, "Morte")
                .Add(TipoGaranzia.InfortuniComa, "Stato comatoso")
                .Add(TipoGaranzia.InfortuniIP, "Invalidita Permanente")
                .Add(TipoGaranzia.InfortuniSpeseMediche, "Rimborso Spese Mediche")
                .Add(TipoGaranzia.InfortuniRicovero, "Indennita per ricovero")
                .Add(TipoGaranzia.InfortuniConvalescenza, "Indennita per convalescenza")
                .Add(TipoGaranzia.InfortuniImmobilizzazione, "Indennita per immobilizzazione")
                .Add(TipoGaranzia.InfortuniTabellaINAIL, "Invalidita Permanente Tabella INAIL")
                .Add(TipoGaranzia.InfortuniFranchigia3, "Invalidità Permanente con franchigia 3%")
                .Add(TipoGaranzia.InfortuniSuperValutazione, "Invalidità Permanente super valutazione")
                .Add(TipoGaranzia.SalvaCircolazioneBase, "Salva Circolazione")
                .Add(TipoGaranzia.AssistenzaBase, "Assistenza")
                .Add(TipoGaranzia.ScontiBase, "Sconto polizza poliennale")
            End With

            With DecodeFrazionamenti
                .Add(FrazionamentiEnum.annuale, "annuale")
                .Add(FrazionamentiEnum.semestrale, "semestrale")
                .Add(FrazionamentiEnum.mensile, "mensile")
            End With

            With DecodeTipoSoggetto
                .Add(TipoSoggettoEnum.PersonaFisica, "Persona fisica")
                .Add(TipoSoggettoEnum.PersonaGiuridica, "Persona giuridica")
            End With

            With DecodeTipologiaVeicolo
                .Add(TipologiaVeicoloEnum.Autovettura, "Autovettura")
                .Add(TipologiaVeicoloEnum.Autoveicolo, "Autoveicolo per trasporto promiscuo")
                .Add(TipologiaVeicoloEnum.Autocarro0, "Autocarro fino a 35 qli")
                .Add(TipologiaVeicoloEnum.Camper, "Camper (autocaravan)")
                .Add(TipologiaVeicoloEnum.Motocicli, "Motocicli")
                .Add(TipologiaVeicoloEnum.Ciclomotori, "Ciclomotori")
                .Add(TipologiaVeicoloEnum.Natante, "Natante da diporto")
                .Add(TipologiaVeicoloEnum.MacchinaAgricola, "Macchina Agricola")
                .Add(TipologiaVeicoloEnum.TrattoreStradale, "Trattore stradale")
                .Add(TipologiaVeicoloEnum.MacchinaOperatrice, "Macchina operatrice")
                .Add(TipologiaVeicoloEnum.Autocarro1, "Autocarro >35 qli")
                .Add(TipologiaVeicoloEnum.Autotreno, "Autotreno")
                .Add(TipologiaVeicoloEnum.AutoArticolati, "Auto Articolati")
                .Add(TipologiaVeicoloEnum.AutoSnodati, "Auto Snodati")
            End With

            With DecodeInfortuniScelta
                .Add(InfortuniSceltaEnum.SceltaPersona, "Scelta Persona")
                .Add(InfortuniSceltaEnum.SceltaFamiglia, "Scelta Famiglia")
                .Add(InfortuniSceltaEnum.SceltaVeicolo, "Scelta Veicolo")
            End With

            With DecodeInfortuniForma
                .Add(InfortuniFormaEnum.CapitaliLiberi, "Capitali liberi")
                .Add(InfortuniFormaEnum.Combinazione1, "Combinazione 1")
                .Add(InfortuniFormaEnum.Combinazione2, "Combinazione 2")
                .Add(InfortuniFormaEnum.Combinazione3, "Combinazione 3")
                .Add(InfortuniFormaEnum.Combinazione4, "Combinazione 4")
                .Add(InfortuniFormaEnum.Combinazione5, "Combinazione 5")
                .Add(InfortuniFormaEnum.Combinazione6, "Combinazione 6")
                .Add(InfortuniFormaEnum.Combinazione7, "Combinazione 7")
                .Add(InfortuniFormaEnum.Combinazione8, "Combinazione 8")
            End With

            With DecodeScontoPoliennale
                .Add(ScontoPoliennaleEnum.Anni2, "2 anni")
                .Add(ScontoPoliennaleEnum.Anni3, "3 anni")
                .Add(ScontoPoliennaleEnum.Anni4, "4 anni")
                .Add(ScontoPoliennaleEnum.Anni5, "5 anni")
            End With
            With DecodeSalvaCircolazioneBasemassimale
                .Add(0500, "500,00")
                .Add(1000, "1.000,00")
                .Add(2000, "2.000,00")
            End With
        End Sub
    End Class
End Namespace
