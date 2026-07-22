Namespace P01262
    <Serializable()> Public Class assicurato

        Public SpeseMediche As SpeseMediche
        Public Nominativo As String
        Public Eta As Integer = 99


        'Malattia
        Public CoperturaMalattia As New CoperturaComposta()
        Public PartitaMalattiaRicovero As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaRicovero As New CoperturaSingola(PartitaMalattiaRicovero, New Garanzia(TipoGaranzia.MalattiaRicovero,
                                                                                               New Garanzia(TipoGaranzia.MalattiaRicoveroIstitutoCura) +
                                                                                               New Garanzia(TipoGaranzia.MalattiaRicoveroAltaSpecializzazione) +
                                                                                               New Garanzia(TipoGaranzia.MalattiaRicoveroCureOncologiche)))
        Public PartitaMalattiaSupplementari As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaSupplementari As New CoperturaSingola(PartitaMalattiaSupplementari, New Garanzia(TipoGaranzia.MalattiaSupplementari,
                                                                                                            New Garanzia(TipoGaranzia.MalattiaSupplementariVisite) +
                                                                                                            New Garanzia(TipoGaranzia.MalattiaSupplementariFisioterapia) +
                                                                                                            New Garanzia(TipoGaranzia.MalattiaSupplementariPrevenzione) +
                                                                                                            New Garanzia(TipoGaranzia.MalattiaSupplementariVisitaOdontoiatrica) +
                                                                                                            New Garanzia(TipoGaranzia.MalattiaSupplementariSedutaIgeneOrale) +
                                                                                                            New Garanzia(TipoGaranzia.MalattiaSupplementariInterventiOdontoiatrici)))
        Public PartitaMalattiaFranchigia As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaFranchigia As New CoperturaSingola(PartitaMalattiaFranchigia, New Garanzia(TipoGaranzia.MalattiaFranchigia))
        Public PartitaMalattiaFormaNucleoFamiliare As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaFormaNucleoFamiliare As New CoperturaSingola(PartitaMalattiaFormaNucleoFamiliare, New Garanzia(TipoGaranzia.MalattiaFormaNucleoFamiliare))
        Public PartitaMalattiaGicGem As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaGicGem As New CoperturaSingola(PartitaMalattiaGicGem, New Garanzia(TipoGaranzia.MalattiaGicGem))
        Public PartitaMalattiaSempreOperanti As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaSempreOperanti As New CoperturaSingola(PartitaMalattiaSempreOperanti, New Garanzia(TipoGaranzia.MalattiaSempreOperanti,
                                                                                                                   New Garanzia(TipoGaranzia.MalattiaSempreOperantiSecondOpinion) +
                                                                                                                   New Garanzia(TipoGaranzia.MalattiaSempreOperantiSindromeMetabolica) +
                                                                                                                   New Garanzia(TipoGaranzia.MalattiaSempreOperantiOspedalizzazioneDomiciliare)))
        'Assistenza
        Public PartitaAssistenza As New Partita(TipoPartita.Assistenza)
        Public CoperturaAssistenza As New CoperturaSingola(PartitaAssistenza, New Garanzia(TipoGaranzia.AssistenzaBase))

        <NonSerialized()> Private AssicuratoValidato As Boolean
        <NonSerialized()> Public PrimoAssicurato As Boolean
        <NonSerialized()> Public decode As P01262DE

        Public Sub New(ByVal SpeseMediche As SpeseMediche)
            Me.SpeseMediche = SpeseMediche

            With CoperturaMalattia
                .Sezione = SpeseMediche.SezioneMalattia
                .AddCopertura(CoperturaMalattiaRicovero)
                .AddCopertura(CoperturaMalattiaSupplementari)
                .AddCopertura(CoperturaMalattiaFranchigia)
                .AddCopertura(CoperturaMalattiaFormaNucleoFamiliare)
                .AddCopertura(CoperturaMalattiaGicGem)
                .AddCopertura(CoperturaMalattiaSempreOperanti)
            End With
            CoperturaAssistenza.Sezione = SpeseMediche.SezioneAssistenza
        End Sub

        Public Sub ValidaAssicurato()
            AssicuratoValidato = False

            If Eta < 0 Or Eta > 75 Then
                SpeseMediche.SetNonDisponibile("Indicare l'età dell'assicurato (da 0 a 75 anni)")
            Else
                AssicuratoValidato = True
            End If

        End Sub

        Public Sub ValidaSezioneMalattiaAssistenza()
            Dim BaseRicovero As Decimal
            Dim BaseInterventi As Decimal
            decode = CType(SpeseMediche.Decode, P01262DE)

            If PrimoAssicurato Then
                CoperturaMalattia.DipendeDa(True)
                CoperturaMalattiaRicovero.DipendeDa(CoperturaMalattia.IsAttivo And Not CoperturaMalattiaGicGem.IsAttivo)
                CoperturaMalattiaSupplementari.DipendeDa(CoperturaMalattiaRicovero.IsAttivo)
                CoperturaMalattiaFormaNucleoFamiliare.DipendeDa(CoperturaMalattiaRicovero.IsAttivo And (SpeseMediche.assicurati.Count > 1))
                CoperturaMalattiaGicGem.DipendeDa(CoperturaMalattia.IsAttivo And Not CoperturaMalattiaRicovero.IsAttivo)
            Else
                With SpeseMediche.assicurati(0)
                    CoperturaMalattia.Stato = .CoperturaMalattia.Stato
                    CoperturaMalattiaRicovero.Stato = .CoperturaMalattiaRicovero.Stato
                    CoperturaMalattiaSupplementari.Stato = .CoperturaMalattiaSupplementari.Stato
                    CoperturaMalattiaFormaNucleoFamiliare.Stato = .CoperturaMalattiaFormaNucleoFamiliare.Stato
                    CoperturaMalattiaGicGem.Stato = .CoperturaMalattiaGicGem.Stato
                End With
            End If
            CoperturaMalattiaFranchigia.DipendeDa(CoperturaMalattiaRicovero.IsAttivo)
            CoperturaMalattiaSempreOperanti.ObbligatoriaDa(CoperturaMalattiaRicovero.IsAttivo Or CoperturaMalattiaGicGem.IsAttivo)
            CoperturaAssistenza.ObbligatoriaDa(CoperturaMalattiaRicovero.IsAttivo Or CoperturaMalattiaGicGem.IsAttivo)

            'Dim coefficienteAssistenza As Decimal
            Dim coefficienteRicovero As Decimal

            With CoperturaMalattiaRicovero
                If PrimoAssicurato = False Then
                    .Garanzia.Combinazione = SpeseMediche.assicurati(0).CoperturaMalattiaRicovero.Garanzia.Combinazione
                ElseIf .Garanzia.Combinazione = 0 Then
                    .Garanzia.Combinazione = 1
                End If
                .Garanzia.CombinazioneStampa = decode.DecodeMalattiaRicoverocombinazione(.Garanzia.Combinazione)

                BaseRicovero = SpeseMediche.Tabella.getPremio(Eta, CoperturaMalattiaRicovero.Garanzia.Combinazione, SpeseMediche.ZonaTerritoriale, TipoGaranzia.MalattiaRicovero)


                If .Garanzia.Combinazione = 1 Then
                    .Garanzia.Garanzie(0).Massimale = 50000
                    .Garanzia.Garanzie(1).Massimale = 5000
                    .Garanzia.Garanzie(2).Massimale = 5000
                    'coefficienteAssistenza = 0.00471D
                ElseIf .Garanzia.Combinazione = 2 Then
                    .Garanzia.Garanzie(0).Massimale = 100000
                    .Garanzia.Garanzie(1).Massimale = 10000
                    .Garanzia.Garanzie(2).Massimale = 10000
                    'coefficienteAssistenza = 0.004D
                ElseIf .Garanzia.Combinazione = 3 Then
                    .Garanzia.Garanzie(0).Massimale = 150000
                    .Garanzia.Garanzie(1).Massimale = 15000
                    .Garanzia.Garanzie(2).Massimale = 15000
                    'coefficienteAssistenza = 0.00364D
                ElseIf .Garanzia.Combinazione = 4 Then
                    .Garanzia.Garanzie(0).Massimale = 250000
                    .Garanzia.Garanzie(1).Massimale = 25000
                    .Garanzia.Garanzie(2).Massimale = 25000
                    'coefficienteAssistenza = 0.00303D
                End If


                coefficienteRicovero = 0.98D
                .Tariffa.Base = coefficienteRicovero * BaseRicovero

                If BaseRicovero = 0D Then
                    .SetNonDisponibile("Combinazione non permessa per la zona territoriale selezionata")
                Else
                    'coefficienteAssistenza = 4D / BaseRicovero
                End If
            End With

            With CoperturaMalattiaSupplementari
                .Garanzia.Garanzie(0).Massimale = 1500 'CoperturaMalattiaSupplementariVisite
                .Garanzia.Garanzie(1).Massimale = 350 'CoperturaMalattiaSupplementariFisioterapia
                .Garanzia.Garanzie(2).Combinazione = 1 'CoperturaMalattiaSupplementariPrevenzione
                .Garanzia.Garanzie(2).CombinazioneStampa = decode.DecodeMalattiaSupplementariPrevenzionecombinazione(.Garanzia.Garanzie(2).Combinazione)
                .Garanzia.Garanzie(3).Combinazione = 1 'CoperturaMalattiaSupplementariVisitaOdontoiatrica
                .Garanzia.Garanzie(3).CombinazioneStampa = decode.DecodeMalattiaSupplementariVisitaOdontoiatricacombinazione(.Garanzia.Garanzie(3).Combinazione)
                .Garanzia.Garanzie(4).Combinazione = 1 'CoperturaMalattiaSupplementariSedutaIgeneOrale
                .Garanzia.Garanzie(4).CombinazioneStampa = decode.DecodeMalattiaSupplementariSedutaIgeneOralecombinazione(.Garanzia.Garanzie(4).Combinazione)
                .Garanzia.Garanzie(5).Massimale = 1500 'CoperturaMalattiaSupplementariInterventiOdontoiatrici

                .Tariffa.Base = SpeseMediche.Tabella.getPremio(Eta, .Garanzia.Combinazione, SpeseMediche.ZonaTerritoriale, TipoGaranzia.MalattiaSupplementari)
            End With

            With CoperturaMalattiaFranchigia
                .Garanzia.Franchigia = 1500
                .Tariffa.Base = -0.23D * 0.69D * BaseRicovero
            End With

            With CoperturaMalattiaGicGem
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 250000
                BaseInterventi = SpeseMediche.Tabella.getPremio(Eta, .Garanzia.Combinazione, SpeseMediche.ZonaTerritoriale, TipoGaranzia.MalattiaGicGem)
                .Tariffa.Base = 0.964D * BaseInterventi
            End With

            With CoperturaMalattiaSempreOperanti
                If CoperturaMalattiaRicovero.IsAttivo Then
                    .Tariffa.Base = 0.016D * BaseRicovero
                ElseIf CoperturaMalattiaGicGem.IsAttivo Then
                    .Tariffa.Base = 0.026D * BaseInterventi
                Else
                    .Tariffa.Base = 0D
                End If
            End With

            With CoperturaMalattiaFormaNucleoFamiliare
                .Partita.SommaAssicurata =
                    CoperturaMalattiaRicovero.PremioAttivoCrudo +
                    CoperturaMalattiaSupplementari.PremioAttivoCrudo +
                    CoperturaMalattiaFranchigia.PremioAttivoCrudo +
                    CoperturaMalattiaSempreOperanti.PremioAttivoCrudo

                Select Case SpeseMediche.assicurati.Count
                    Case Is <= 1 : .Tariffa.Tasso = 0D
                    Case 2 : .Tariffa.Tasso = -0.15D
                    Case 3 : .Tariffa.Tasso = -0.2D
                    Case 4 : .Tariffa.Tasso = -0.25D
                    Case Else : .Tariffa.Tasso = -0.35D
                End Select
                'Select Case SpeseMediche.assicurati.Count
                '    Case Is < 2 : .Tariffa.Tasso = 0D
                '    Case Is = 2 : .Tariffa.Tasso = -0.105263D
                '    Case Is = 3 : .Tariffa.Tasso = -0.111111D
                '    Case Is = 4 : .Tariffa.Tasso = -0.166667D
                '    Case Else : .Tariffa.Tasso = -0.235294D
                'End Select
            End With


            If CoperturaMalattiaRicovero.IsAttivo Then
                'da quick quotation 2.0
                'CoperturaAssistenza.Tariffa.Base = 0.004D * Tabella.getPremio(Eta, 2D, SpeseMediche.ZonaTerritoriale, TipoGaranzia.MalattiaRicovero)

                'da tariffino 
                CoperturaAssistenza.Tariffa.Base = 0.004D * BaseRicovero
                CoperturaAssistenza.RischioDirezione = CoperturaMalattiaRicovero.RischioDirezione
            ElseIf CoperturaMalattiaGicGem.IsAttivo Then
                CoperturaAssistenza.Tariffa.Base = 0.01D * BaseInterventi
                CoperturaAssistenza.RischioDirezione = CoperturaMalattiaGicGem.RischioDirezione
            Else
                CoperturaAssistenza.Tariffa.Base = 0D
            End If
        End Sub

    End Class
End Namespace
