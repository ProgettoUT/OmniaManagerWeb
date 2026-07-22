Namespace P07263
    Public Class P07263ST
        Inherits P00000ST

        Public Sub New()
            MyBase.New(True)
        End Sub

        Public Overrides Sub Stampa(ByVal preventivo As Prodotto, ByVal options As StampaOptions)
            VerticaleUno = 110
            tab(1) = VerticaleUno

            With CType(preventivo, UnipolSaiCasaServizi)
                Dim decode As P07263DE = CType(preventivo.Decode, P07263DE)

                StampaInizio(preventivo, options)

                For Each Abitazione As Abitazione In .Abitazioni
                    Abitazione.CoperturaDanniBeniAbitazione.Parametro1 = decode.DecodeDanniBeniAbitazioneFormaGaranzia(Abitazione.DanniBeniAbitazioneFormaGaranzia)
                    Abitazione.CoperturaDanniBeniContenuto.Parametro1 = decode.DecodeDanniBeniContenutoFormaGaranzia(Abitazione.DanniBeniContenutoFormaGaranzia)
                    Abitazione.CoperturaAssistenzaPlusBase.Parametro3 = decode.DecodeAssistenzaPlus(Abitazione.AssistenzaPlus)
                    Abitazione.CoperturaCatastrofaliAlluvioneAbitazione.Parametro1 = "(classe rischio da verificare)"
                    Abitazione.CoperturaCatastrofaliAlluvioneAbitazione.Parametro3 =
                        decode.DecodeAlluvioneGruppoRischio(Abitazione.CoperturaCatastrofaliAlluvioneAbitazione.Garanzia.Combinazione)
                    StampaIntestazionePagina(preventivo, options)
                    StampaParametri( _
                                    "Comune", Abitazione.GetComune.Nome & " (" & Abitazione.GetComune.Provincia.Sigla & ")", _
                                    "Indirizzo", Abitazione.Indirizzo & " " & Abitazione.NumeroCivico, _
                                    "Tipo dimora", decode.DecodeTipoDimora(Abitazione.TipoDimora), _
                                    "Tipo abitazione", decode.DecodeTipoAbitazione(Abitazione.TipoAbitazione), _
                                    "Tipo utilizzo", decode.DecodeTipoUtilizzo(Abitazione.TipoUtilizzo), _
                                    "Tipologia costruzione", decode.DecodeTipologiaCostruzione(Abitazione.TipologiaCostruzione), _
                                    "Antisismico", decode.DecodeAntisismico(Abitazione.Antisismico), _
                                    "Alluvionato", decode.DecodeAlluvionato(Abitazione.Alluvionato), _
                                    "Piano assicurato", decode.DecodePianoAssicurato(Abitazione.PianoAssicurato), _
                                    "Classe territoriale furto", decode.DecodeClasseTerritorialeFurto(Abitazione.ClasseTerritorialeFurto), _
                                    "Classe territoriale eventi atmosferici", decode.DecodeClasseTerritorialeEventiAtmosferici(Abitazione.ClasseTerritorialeEventiAtmosferici), _
                                    "Classe territoriale danni acqua", decode.DecodeClasseTerritorialeDanniAcqua(Abitazione.ClasseTerritorialeDanniAcqua), _
                                    "Riparazione diretta", decode.DecodeRiparazionediretta(Abitazione.Riparazionediretta), _
                                    "", "")

                    '"Classe territoriale RCT", decode.DecodeClasseTerritorialeRCT(Abitazione.ClasseTerritorialeRCT), _

                    StampaDettaglioInizio(preventivo, options)
                    StampaCoperture(Abitazione.CoperturaDanniBeni, "DANNI BENI", options)
                    StampaCoperture(Abitazione.CoperturaCatastrofali, "CATASTROFALI", options)
                    StampaCoperture(Abitazione.CoperturaAssistenzaPlus, "ASSISTENZA PLUS", options)
                    StampaCoperture(Abitazione.CoperturaProtezioneEmergenza, "PACK PROTEZIONE EMERGENZA", options)
                    StampaCoperture(Abitazione.CoperturaFurto, "FURTO", options)
                    StampaDettaglioFine(preventivo, options)
                Next

                StampaIntestazionePagina(preventivo, options)
                StampaSezioneCliente(preventivo, options)
                StampaParametri("Persona giuridica", Formatta(.TipoContraenza = TipoContraenzaEnum.PersonaGiudirica), "Vincolo Bancario", Formatta(.VincoloBancario))

                .CoperturaDanniTerziIncendio.Parametro1 = Luogo.Province(.ProvinciaRCT).Nome
                .CoperturaDanniTerziProprieta.Parametro1 = .DanniTerziNumeroUbicazioni & " unità"

                StampaDettaglioInizio(preventivo, options)
                StampaSezione(.SezioneDanniTerzi, options)
                StampaSezione(.SezioneTutelaLegale, options)
                StampaSezione(.SezioneAssistenza, options)
                StampaSezione(.SezioneProtezioneDigitale, options)
                StampaSezione(.SezioneProtezioneBenessere, options)
                StampaSezione(.SezioneProtezioneFamiglia, options)
                StampaDettaglioFine(preventivo, options)

                StampaRiepilogoPremi(preventivo, options)

                StampaFine(preventivo, options)
            End With
        End Sub
    End Class
End Namespace
