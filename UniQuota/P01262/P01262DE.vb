Namespace P01262
    Public Class P01262DE
        Inherits P00000DE

        Public DecodeZonaTerritoriale As New Dizionario(Of Integer, String)
        Public DecodeMalattiaRicoverocombinazione As New Dizionario(Of Decimal, String)
        Public DecodeMalattiaRicoveroIstitutoCuramassimale As New Dizionario(Of Decimal, String)
        Public DecodeMalattiaRicoveroAltaSpecializzazionemassimale As New Dizionario(Of Decimal, String)
        Public DecodeMalattiaRicoveroCureOncologichemassimale As New Dizionario(Of Decimal, String)
        Public DecodeMalattiaSupplementariVisitemassimale As New Dizionario(Of Decimal, String)
        Public DecodeMalattiaSupplementariFisioterapiamassimale As New Dizionario(Of Decimal, String)
        Public DecodeMalattiaSupplementariPrevenzionecombinazione As New Dizionario(Of Decimal, String)
        Public DecodeMalattiaSupplementariVisitaOdontoiatricacombinazione As New Dizionario(Of Decimal, String)
        Public DecodeMalattiaSupplementariSedutaIgeneOralecombinazione As New Dizionario(Of Decimal, String)
        Public DecodeMalattiaSupplementariInterventiOdontoiatricimassimale As New Dizionario(Of Decimal, String)
        Public DecodeMalattiaFranchigiafranchigia As New Dizionario(Of Decimal, String)
        Public DecodeMalattiaGicGemmassimale As New Dizionario(Of Decimal, String)

        Sub New()
            With DecodeSezione
                .Add(TipoSezione.Malattia, "Malattia")
                .Add(TipoSezione.Assistenza, "Assistenza")
            End With

            With DecodePartita
                .Add(TipoPartita.Malattia, "Malattia")
                .Add(TipoPartita.Assistenza, "Assistenza")
            End With

            With DecodeGaranzia
                .Add(TipoGaranzia.MalattiaBase, "Assicurato")
                .Add(TipoGaranzia.MalattiaRicovero, "Formula Ricovero")
                .Add(TipoGaranzia.MalattiaRicoveroIstitutoCura, "Ricovero istituto di cura")
                .Add(TipoGaranzia.MalattiaRicoveroAltaSpecializzazione, "Alta specializzazione")
                .Add(TipoGaranzia.MalattiaRicoveroCureOncologiche, "Cure oncologiche")
                .Add(TipoGaranzia.MalattiaSupplementari, "Garanzie Supplementari")
                .Add(TipoGaranzia.MalattiaSupplementariVisite, "Visite specialistiche e accertamenti")
                .Add(TipoGaranzia.MalattiaSupplementariFisioterapia, "Trattamenti fisioterapici riabilitativi a seguito di infortunio")
                .Add(TipoGaranzia.MalattiaSupplementariPrevenzione, "Prevenzione")
                .Add(TipoGaranzia.MalattiaSupplementariVisitaOdontoiatrica, "Una visita odontoiatrica")
                .Add(TipoGaranzia.MalattiaSupplementariSedutaIgeneOrale, "Una seduta di igiene orale")
                .Add(TipoGaranzia.MalattiaSupplementariInterventiOdontoiatrici, "Interventi chirurgici odontoiatrici extraricovero")
                .Add(TipoGaranzia.MalattiaFranchigia, "Franchigia ricovero")
                .Add(TipoGaranzia.MalattiaFormaNucleoFamiliare, "Forma di Assicurazione Nucleo Familiare")
                .Add(TipoGaranzia.MalattiaGicGem, "Formula Grandi Interventi Chirurgici e Gravi Eventi Morbosi")
                .Add(TipoGaranzia.MalattiaSempreOperanti, "Garanzie sempre operanti")
                .Add(TipoGaranzia.MalattiaSempreOperantiSecondOpinion, "Second Opinion")
                .Add(TipoGaranzia.MalattiaSempreOperantiSindromeMetabolica, "Sindrome metabolica")
                .Add(TipoGaranzia.MalattiaSempreOperantiOspedalizzazioneDomiciliare, "Ospedalizzazione domiciliare")
                .Add(TipoGaranzia.AssistenzaBase, "Assistenza")
            End With

            With DecodeFrazionamenti
                .Add(FrazionamentiEnum.annuale, "annuale")
                .Add(FrazionamentiEnum.semestrale, "semestrale")
                .Add(FrazionamentiEnum.quadrimestrale, "quadrimestrale")
                .Add(FrazionamentiEnum.trimestrale, "trimestrale")
                .Add(FrazionamentiEnum.Personalizzato, "Mensile Finitalia")
            End With

            With DecodeZonaTerritoriale
                .Add(ZonaTerritorialeEnum.Zona0, "Resto di Italia")
                .Add(ZonaTerritorialeEnum.Zona1, "Roma e relative province")
                .Add(ZonaTerritorialeEnum.Zona2, "Milano - Torino - Genova e relative province")
            End With
            With DecodeMalattiaRicoverocombinazione
                .Add(1, "50.000-5.000-5.000")
                .Add(2, "100.000-10.000-10.000")
                .Add(3, "150.000-15.000-15.000")
                .Add(4, "250.000-25.000-25.000")
            End With
            With DecodeMalattiaRicoveroIstitutoCuramassimale
                .Add(50000, "50.000")
                .Add(100000, "100.000")
                .Add(150000, "150.000")
                .Add(250000, "250.000")
            End With
            With DecodeMalattiaRicoveroAltaSpecializzazionemassimale
                .Add(5000, "5.000")
                .Add(10000, "10.000")
                .Add(15000, "15.000")
                .Add(25000, "25.000")
            End With
            With DecodeMalattiaRicoveroCureOncologichemassimale
                .Add(5000, "5.000")
                .Add(10000, "10.000")
                .Add(15000, "15.000")
                .Add(25000, "25.000")
            End With
            With DecodeMalattiaSupplementariVisitemassimale
                .Add(1500, "1.500,00 Euro")
            End With
            With DecodeMalattiaSupplementariFisioterapiamassimale
                .Add(350, "350,00 Euro")
            End With
            With DecodeMalattiaSupplementariPrevenzionecombinazione
                .Add(1, "una volta l'anno presso strutture convenzionate UniSalute")
            End With
            With DecodeMalattiaSupplementariVisitaOdontoiatricacombinazione
                .Add(1, "massimo 1 visita")
            End With
            With DecodeMalattiaSupplementariSedutaIgeneOralecombinazione
                .Add(1, "massimo 60,00 Euro")
            End With
            With DecodeMalattiaSupplementariInterventiOdontoiatricimassimale
                .Add(1500, "1.500,00 Euro")
            End With
            With DecodeMalattiaFranchigiafranchigia
                .Add(1500, "1.500,00 Euro")
            End With
            With DecodeMalattiaGicGemmassimale
                .Add(250000, "250.000,00 Euro")
            End With
        End Sub
    End Class
End Namespace
