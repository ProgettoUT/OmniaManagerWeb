Namespace P07261
    Public Class P07261ST
        Inherits P00000ST

        Public Sub New()
            MyBase.New(True)
        End Sub

        Public Overrides Sub Stampa(ByVal preventivo As Prodotto, ByVal options As StampaOptions)
            'VerticaleUno = 125
            'tab(1) = VerticaleUno

            With CType(preventivo, youCasa)
                Dim decode As P07261DE = CType(preventivo.Decode, P07261DE)

                .CoperturaTutelaLegaleBase.Parametro1 = decode.DecodeTutelaLegaleChiave(.TutelaLegaleChiave)
                .CoperturaSalvaBenessereBase.Parametro1 = decode.DecodeSalvaBenessereEta(.SalvaBenessereEta)

                StampaInizio(preventivo, options)

                StampaIntestazionePagina(preventivo, options)
                StampaSezioneCliente(preventivo, options)

                If .AbitazioneX.Count <> 1 Then
                    StampaParametri( _
                                    "Indicizzazione", FormatSiNo(.Indicizzazione = StatoCopertura.attiva), _
                                    "Tacito rinnovo", FormatSiNo(.TacitoRinnovo) _
                                    )
                    StampaDettaglioInizio(preventivo, options)
                    StampaCoperture(New CoperturaStampa(.SezioneResponsabilitaCivile.Coperture), "RESPONSABILITA' CIVILE", decode.DecodeRCChiave(.RCChiave), options)
                    StampaCoperture(New CoperturaStampa(.SezioneSalvaBenessere.Coperture, .SezioneTutelaLegale.Coperture, .SezioneAssistenza.Coperture), "SALVA BENESSERE, TUTELA LEGALE E ASSISTENZA", options)
                    'StampaCoperture(New CoperturaStampa(.SezioneTutelaLegale.Coperture), Nothing, options)
                    'StampaCoperture(New CoperturaStampa(.SezioneAssistenza.Coperture), Nothing, options)

                    StampaDettaglioFine(preventivo, options)
                    StampaRiepilogoPremi(preventivo, options)
                End If

                For Each Abitazione As Abitazione In .AbitazioneX
                    Abitazione.CoperturaIncendioAbitazione.Parametro0 = decode.DecodeIncendioAbitazioneFormAss(Abitazione.IncendioAbitazioneFormAss)
                    Abitazione.CoperturaIncendioContenuto.Parametro0 = decode.DecodeIncendioContenutoFormAss(Abitazione.IncendioContenutoFormAss)
                    Abitazione.CoperturaIncendioLocazione.Parametro0 = decode.DecodeIncendioLocazioneFormAss(Abitazione.IncendioLocazioneFormAss)
                    Abitazione.CoperturaFurtoContenuto.Parametro0 = decode.DecodeFurtoContenutoFormAss(Abitazione.FurtoContenutoFormaAssicurazione)
                    Abitazione.CoperturaFurtoEsternoOro.Parametro0 = decode.DecodeFurtoEsternoScelta(Abitazione.FurtoEsternoScelta)
                    Abitazione.CoperturaFurtoEsternoPlatino.Parametro0 = decode.DecodeFurtoEsternoPlatinoScelta(Abitazione.FurtoEsternoPlatinoScelta)
                    Abitazione.CoperturaFurtoInCassaforte.Parametro0 = decode.DecodeFurtoInCassaforteScelta(Abitazione.FurtoInCassaforteScelta)
                    Abitazione.CoperturaFurtoPreziosiValori.Parametro0 = decode.DecodeFurtoPreziosiValoriScelta(Abitazione.FurtoPreziosiValoriScelta)

                    Abitazione.CoperturaFurtoValoriDimoraAbituale.Parametro3 = decode.DecodeFurtoValoriDimoraAbitualeDenaro(Abitazione.FurtoValoriDimoraAbitualeDenaro) & " - " & decode.DecodeFurtoValoriDimoraAbitualeValori(Abitazione.FurtoValoriDimoraAbitualeValori)

                    'Abitazione.CoperturaIncendioFenomeniElettrici.Parametro = "Franchigia " & FormatCurrency(Abitazione.CoperturaIncendioFenomeniElettrici.Garanzia.Franchigia)
                    'Abitazione.CoperturaIncendioFenomeniAtmosferici.Parametro = decode.DecodeIncendioFenomeniAtmosfericiCombinazione(Abitazione.CoperturaIncendioFenomeniAtmosferici.Garanzia.Combinazione)
                    'Abitazione.CoperturaIncendioRicercaGuasto.Parametro = "Franchigia " & FormatCurrency(Abitazione.CoperturaIncendioRicercaGuasto.Garanzia.Franchigia)
                    'Abitazione.CoperturaIncendioAcquaOcclusione.Parametro = "Franchigia " & FormatCurrency(Abitazione.CoperturaIncendioAcquaOcclusione.Garanzia.Franchigia)

                    If .AbitazioneX.Count <> 1 Then
                        StampaIntestazionePagina(preventivo, options)
                    Else
                        StampaParametri( _
                                        "Indicizzazione", FormatSiNo(.Indicizzazione = StatoCopertura.attiva), _
                                        "Tacito rinnovo", FormatSiNo(.TacitoRinnovo) _
                                        )
                    End If
                    StampaParametri( _
                                    "Provincia", Luogo.Province(Abitazione.Provincia).Nome, _
                                    "Tipo abitazione", decode.DecodeTipoAbitazione(Abitazione.TipoAbitazione), _
                                    "Comune", Luogo.GetComuneByCodiceIstat(Abitazione.Comune).Nome, _
                                    "Dimora", decode.DecodeTipoDimora(Abitazione.TipoDimora), _
                                    "Indirizzo", Trim(Abitazione.Indirizzo & " " & Abitazione.NumeroCivico), _
                                    "Caratteristica Costruttiva", decode.DecodeCaratteristicaCostruttiva(Abitazione.CaratteristicaCostruttiva), _
                                    "Piano", decode.DecodePianoAbitazione(Abitazione.PianoAbitazione), _
                                    "Descrizione", Abitazione.Descrizione _
                                    )
                    StampaDettaglioInizio(preventivo, options)
                    StampaCoperture(Abitazione.CoperturaIncendio, "INCENDIO", decode.DecodeIncendioChiave(Abitazione.IncendioChiave), options)
                    'StampaParametri( _
                    '                "TipoAbitazione", decode.DecodeTipoAbitazione(Abitazione.TipoAbitazione), _
                    '                "ClasseTerritorialeFurto", decode.DecodeClasseTerritorialeFurto(Abitazione.ClasseTerritorialeFurto), _
                    '                "ZonaTerritorialeEventiAtmosferici", decode.DecodeZonaTerritorialeEventiAtmosferici(Abitazione.ZonaTerritorialeEventiAtmosferici), _
                    '                "IncendioChiave", decode.DecodeIncendioChiave(Abitazione.IncendioChiave), _
                    '                "IncendioAbitazioneFormAss", decode.DecodeIncendioAbitazioneFormAss(Abitazione.IncendioAbitazioneFormAss), _
                    '                "IncendioContenutoFormAss", decode.DecodeIncendioContenutoFormAss(Abitazione.IncendioContenutoFormAss), _
                    '                "IncendioLocazioneFormAss", decode.DecodeIncendioLocazioneFormAss(Abitazione.IncendioLocazioneFormAss), _
                    '                "CaratteristicaCostruttiva", decode.DecodeCaratteristicaCostruttiva(Abitazione.CaratteristicaCostruttiva), _
                    '                "FurtoChiave", decode.DecodeFurtoChiave(Abitazione.FurtoChiave), _
                    '                "FurtoEsternoScelta", decode.DecodeFurtoEsternoScelta(Abitazione.FurtoEsternoScelta), _
                    '                "FurtoEsternoPlatinoScelta", decode.DecodeFurtoEsternoPlatinoScelta(Abitazione.FurtoEsternoPlatinoScelta), _
                    '                "FurtoInCassaforteScelta", decode.DecodeFurtoInCassaforteScelta(Abitazione.FurtoInCassaforteScelta), _
                    '                "FurtoPreziosiValoriScelta", decode.DecodeFurtoPreziosiValoriScelta(Abitazione.FurtoPreziosiValoriScelta), _
                    '                "FurtoValoriDimoraAbitualeDenaro", decode.DecodeFurtoValoriDimoraAbitualeDenaro(Abitazione.FurtoValoriDimoraAbitualeDenaro), _
                    '                "FurtoValoriDimoraAbitualeValori", decode.DecodeFurtoValoriDimoraAbitualeValori(Abitazione.FurtoValoriDimoraAbitualeValori), _
                    '                "", "")
                    StampaCoperture(Abitazione.CoperturaTerremoto, "TERREMOTO", options)
                    StampaCoperture(Abitazione.CoperturaFurto, "FURTO", decode.DecodeFurtoChiave(Abitazione.FurtoChiave), options)
                    If .AbitazioneX.Count <> 1 Then
                        StampaDettaglioFine(preventivo, options)
                    End If
                Next

                If .AbitazioneX.Count = 1 Then
                    StampaCoperture(New CoperturaStampa(.SezioneResponsabilitaCivile.Coperture), "RESPONSABILITA' CIVILE", decode.DecodeRCChiave(.RCChiave), options)
                    StampaCoperture(New CoperturaStampa(.SezioneSalvaBenessere.Coperture, .SezioneTutelaLegale.Coperture, .SezioneAssistenza.Coperture), "SALVA BENESSERE, TUTELA LEGALE E ASSISTENZA", options)
                    'StampaCoperture(New CoperturaStampa(.SezioneSalvaBenessere.Coperture), "SALVA BENESSERE, TUTELA LEGALE E ASSISTENZA", options)
                    'StampaCoperture(New CoperturaStampa(.SezioneTutelaLegale.Coperture), Nothing, options)
                    'StampaCoperture(New CoperturaStampa(.SezioneAssistenza.Coperture), Nothing, options)

                    StampaDettaglioFine(preventivo, options)
                    StampaRiepilogoPremi(preventivo, options)
                End If

                StampaFine(preventivo, options)
            End With
        End Sub
    End Class
End Namespace
