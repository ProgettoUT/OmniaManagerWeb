Namespace P04226

    Public Class P04226ST
        Inherits P00000ST

        Public Overrides Sub Stampa(ByVal preventivo As Prodotto, ByVal options As StampaOptions)
            VerticaleUno = 125
            tab(1) = VerticaleUno

            With CType(preventivo, YouCommercio)
                Dim decode As P04226DE = CType(preventivo.Decode, P04226DE)

                StampaInizio(preventivo, options)

                For Each Fabbricato As Fabbricato In .Fabbricati
                    Fabbricato.CoperturaIncendioBase.NonStampare = True
                    Fabbricato.CoperturaFurtoBase.NonStampare = True
                    Fabbricato.CoperturaTerremotoBase.NonStampare = True

                    Fabbricato.CoperturaIncendioFabbricato.Parametro0 = decode.DecodeFormaDiAssicurazione(Fabbricato.IncendioFabbricatoFormaDiAssicurazione)
                    Fabbricato.CoperturaIncendioContenuto.Parametro0 = decode.DecodeFormaDiAssicurazione(Fabbricato.IncendioContenutoFormaDiAssicurazione)
                    Fabbricato.CoperturaIncendioLocazione.Parametro0 = decode.DecodeFormaDiAssicurazione(Fabbricato.IncendioLocazioneFormaDiAssicurazione)
                    Fabbricato.CoperturaIncendioDanniElettrici.Parametro0 = decode.DecodeIncendioDanniElettriciScelta(Fabbricato.IncendioDanniElettriciScelta)
                    Fabbricato.CoperturaIncendioDanniIndirettiA.Parametro0 = decode.DecodeIncendioDanniIndirettiScelta(Fabbricato.IncendioDanniIndirettiScelta)
                    Fabbricato.CoperturaIncendioEventiAtmosferici.Parametro0 = decode.DecodeIncendioEventiAtmosfericiScelta(Fabbricato.IncendioEventiAtmosfericiScelta)
                    If Fabbricato.IncendioAumentoMerciMesi > 0 Then
                        Fabbricato.CoperturaIncendioAumentoMerci.Parametro1 = "Mesi " & Fabbricato.IncendioAumentoMerciMesi
                    End If
                    StampaIntestazionePagina(preventivo, options)
                    StampaParametri("Descrizione", Fabbricato.Descrizione, _
                                    "Provincia", Luogo.Province(Fabbricato.Provincia).Nome, _
                                    "Destinazione", decode.DecodeFabbricatoDestinazione(Fabbricato.FabbricatoDestinazione), _
                                    "Classe fabbricato", decode.DecodeClasseFabbricato(Fabbricato.ClasseFabbricato), _
                                    "Tipologia fabbricato", decode.DecodeTipologiaFabbricato(Fabbricato.TipologiaFabbricato), _
                                    "Caratteristica costruttiva", decode.DecodeCaratteristicaCostruttiva(Fabbricato.CaratteristicaCostruttiva), _
                                    "Comune a minor rischio sismico", FormatSiNo(Fabbricato.comuneMinorRischioSismico), _
                                    "Note", Fabbricato.Note)
                    StampaDettaglioInizio(preventivo, options)
                    StampaCoperture(Fabbricato.CoperturaIncendio, "INCENDIO", decode.DecodeIncendioScelta(Fabbricato.IncendioScelta), options)


                    If Fabbricato.TerremotoAumentoMerciMesi > 0 Then
                        Fabbricato.CoperturaTerremotoAumentoMerci.Parametro1 = "Mesi " & Fabbricato.TerremotoAumentoMerciMesi
                    End If
                    Fabbricato.CoperturaTerremotoFabbricato.Parametro1 = decode.DecodeTerremotoBaseLimite(Fabbricato.CoperturaTerremotoFabbricato.Garanzia.Limite)

                    StampaCoperture(Fabbricato.CoperturaTerremoto, "TERREMOTO", options)
                    StampaDettaglioFine(preventivo, options)


                    If Fabbricato.FurtoAumentoMerciMesi > 0 Then
                        Fabbricato.CoperturaFurtoAumentoMerci.Parametro1 = "Mesi " & Fabbricato.FurtoAumentoMerciMesi
                    End If
                    Fabbricato.CoperturaFurtoFissi.Parametro0 = decode.DecodeFurtoFissiScelta(Fabbricato.FurtoFissiScelta)
                    Fabbricato.CoperturaFurtoValori.Parametro0 = decode.DecodeFurtoValoriScelta(Fabbricato.FurtoValoriScelta)
                    Fabbricato.CoperturaFurtoRapina.Parametro0 = decode.DecodeFurtoRapinaScelta(Fabbricato.FurtoRapinaScelta)

                    StampaIntestazionePagina(preventivo, options)
                    StampaParametri("Descrizione", Fabbricato.Descrizione, _
                                    "Provincia", Luogo.Province(Fabbricato.Provincia).Nome, _
                                    "Destinazione", decode.DecodeFabbricatoDestinazione(Fabbricato.FabbricatoDestinazione), _
                                    "Classe fabbricato", decode.DecodeClasseFabbricato(Fabbricato.ClasseFabbricato))
                    StampaDettaglioInizio(preventivo, options)
                    StampaCoperture(Fabbricato.CoperturaFurto, "FURTO", options)
                    StampaDettaglioFine(preventivo, options)
                Next

                .CoperturaResponsabilitaCivileBase.NonStampare = True
                StampaIntestazionePagina(preventivo, options)
                StampaSezioneCliente(preventivo, options)
                StampaParametri("Attività", decode.DecodeAttivita(.CodiceAttivita1), _
                                "Numero Addetti", CStr(.NumeroAddetti), _
                                "Solo proprieta", FormatSiNo(.SoloProprieta), _
                                "Classi di Rischio", _
                                "Incendio (" & .ClasseRischioAttivitaIncendio & ")" & _
                                " - Furto (" & decode.DecodeClasseRischioAttivitaFurto(.ClasseRischioAttivitaFurto) + ")" & _
                                " - Terremoto (" & .ClasseRischioAttivitaTerremoto & ")" & _
                                " - RC (" & .ClasseRischioAttivitaRc & ")")

                StampaDettaglioInizio(preventivo, options)
                StampaSezione(.SezioneResponsabilitaCivile, options)
                StampaSezione(.SezioneAssistenza, options)
                StampaSezione(.SezioneTutelaLegale, options)
                StampaDettaglioFine(preventivo, options)

                StampaRiepilogoPremi(preventivo, options)

                StampaFine(preventivo, options)
            End With
        End Sub
    End Class
End Namespace
