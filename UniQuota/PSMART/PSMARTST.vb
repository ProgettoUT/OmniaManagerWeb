Namespace PSMART
    Public Class PSMARTST
        Inherits P00000ST

        Public Sub New()
            MyBase.New(True)
        End Sub

        Public Overrides Sub Stampa(ByVal preventivo As Prodotto, ByVal options As StampaOptions)
            VerticaleUno = 100D
            tab(1) = VerticaleUno

            With CType(preventivo, smart)
                Dim decode As PSMARTDE = CType(preventivo.Decode, PSMARTDE)

                StampaInizio(preventivo, options)

                StampaIntestazionePagina(preventivo, options)
                StampaSezioneCliente(preventivo, options)

                If .Note <> vbNullString Then
                    StampaParametri("Note", .Note)
                End If

                StampaDettaglioInizio(preventivo, options)

                If .SezioneCasaIncendio.IsAttivo Then

                    Dim GaranzieIncendio As New List(Of Garanzia)
                    If .CasaScelta = CasaSceltaEnum.SceltaC Or .CasaScelta = CasaSceltaEnum.SceltaD Then
                        GaranzieIncendio.Add(Garanzia("Fabbricato (a primo rischio assoluto)", Choose(.CasaScelta, 0D, 0D, 75000D, 100000D)))
                    End If
                    GaranzieIncendio.Add(Garanzia("Contenuto (a primo rischio assoluto)", Choose(.CasaScelta, 5000D, 25000D, 15000D, 25000D)))
                    GaranzieIncendio.Add(Garanzia("Atti vandalici e dolosi, sabotaggio", 0D, 0.5D))
                    GaranzieIncendio.Add(Garanzia("Atti di terrorismo", 0D, 0.5D))
                    GaranzieIncendio.Add(Garanzia("Acqua condotta", 10000D, 0.5D))
                    GaranzieIncendio.Add(Garanzia("Fenomeni elettrici", 2500D))
                    GaranzieIncendio.Add(Garanzia("Fenomeni atmosferici", 0D, 0.5D))
                    GaranzieIncendio.Add(Garanzia("Sovraccarico neve", 20000D))
                    GaranzieIncendio.Add(Garanzia("Gelo", 2500D))
                    If .CasaScelta = CasaSceltaEnum.SceltaC Or .CasaScelta = CasaSceltaEnum.SceltaD Then
                        GaranzieIncendio.Add(Garanzia("Ricerca del guasto", 2500D))
                    End If
                    GaranzieIncendio.Add(Garanzia("Lastre", 0D, 0D, 5000D))
                    GaranzieIncendio.Add(Garanzia("Spese rimozione e collocamento del contenuto", 2500D, 0.1D))
                    GaranzieIncendio.Add(Garanzia("Spese per trasloco e deposito", 2500D))
                    GaranzieIncendio.Add(Garanzia("Spese per demolizione e sgombero", 15000D, 0.2D))
                    GaranzieIncendio.Add(Garanzia("Onorari del perito", 2500D, 0.1D))
                    GaranzieIncendio.Add(Garanzia("Alloggio sostitutivo", 0D, 0.1D))
                    If .CasaScelta = CasaSceltaEnum.SceltaC Or .CasaScelta = CasaSceltaEnum.SceltaD Then
                        GaranzieIncendio.Add(Garanzia("Riprogettazione del fabbricato", 2500D, 0.05D))
                        GaranzieIncendio.Add(Garanzia("Oneri dovuti per la ricostruzione", 2500D))
                    End If
                    GaranzieIncendio.Add(Garanzia("Franchigia", 0D, 0D, 0D, 0D, 250D))

                    Dim CoperturaIncendio As New CoperturaSingola(.PartitaCasaAssistenzaBase, New Garanzia(.CoperturaCasaIncendioBase.Garanzia.Descrizione, GaranzieIncendio))
                    CoperturaIncendio.ListinoLordo = .CoperturaCasaIncendioBase.ListinoLordo
                    CoperturaIncendio.Stato = .CoperturaCasaIncendioBase.Stato

                    Dim CoperturaFurto As CoperturaSingola = .CoperturaCasaFurtoBase

                    Dim GaranzieFurto As New List(Of Garanzia)
                    GaranzieFurto.Add(Garanzia("Contenuto (a primo rischio assoluto)", 5000D))
                    GaranzieFurto.Add(Garanzia("Atti vandalici/Furto fissi e infissi", 2500D))
                    GaranzieFurto.Add(Garanzia("Onorari del perito", 0D, 0.1D))
                    GaranzieFurto.Add(Garanzia("Sostituzione serrature", 500D))
                    GaranzieFurto.Add(Garanzia("Duplicazione o rifacimento documenti personali", 500D))
                    GaranzieFurto.Add(Garanzia("Franchigia", 0D, 0D, 0D, 0D, 250D))

                    CoperturaFurto = New CoperturaSingola(.PartitaCasaAssistenzaBase, New Garanzia(.CoperturaCasaFurtoBase.Garanzia.Descrizione, GaranzieFurto))
                    CoperturaFurto.ListinoLordo = .CoperturaCasaFurtoBase.ListinoLordo
                    CoperturaFurto.Stato = .CoperturaCasaFurtoBase.Stato

                    Dim GaranzieRC As New List(Of Garanzia)
                    GaranzieRC.Add(Garanzia("Vita privata e abitazione", Choose(.CasaScelta, 500000D, 1000000D, 500000D, 1000000D)))
                    GaranzieRC.Add(Garanzia("Manutenzione ordinaria"))
                    GaranzieRC.Add(Garanzia("Spargimento liquidi", 25000D))
                    GaranzieRC.Add(Garanzia("Neve e ghiaccio"))
                    GaranzieRC.Add(Garanzia("Interruzione e sospensione di attività", 0D, 0.15D))
                    GaranzieRC.Add(Garanzia("Ricorso terzi da incendio", 0D, 0.2D))
                    Dim CoperturaRC As New CoperturaSingola(.PartitaCasaAssistenzaBase, New Garanzia(.CoperturaCasaRCBase.Garanzia.Descrizione, GaranzieRC))
                    CoperturaRC.ListinoLordo = .CoperturaCasaRCBase.ListinoLordo
                    CoperturaRC.Stato = .CoperturaCasaRCBase.Stato

                    Dim GaranzieAssistenza As New List(Of Garanzia)
                    GaranzieAssistenza.Add(Garanzia("Reperimento telefonico artigiani"))
                    GaranzieAssistenza.Add(Garanzia("Invio idraulico in caso emergenza", 150D))
                    GaranzieAssistenza.Add(Garanzia("Invio elettricista in caso emergenza", 150D))
                    GaranzieAssistenza.Add(Garanzia("Invio fabbro in caso emergenza", 150D))
                    GaranzieAssistenza.Add(Garanzia("Intervento guardia giurata (max 8 ore)"))
                    GaranzieAssistenza.Add(Garanzia("Spese di albergo", 300D))
                    GaranzieAssistenza.Add(Garanzia("Somme di denaro per emergenza", 300D))
                    GaranzieAssistenza.Add(Garanzia("Rientro anticipato dell’Assicurato"))

                    Dim CoperturaAssistenza As New CoperturaSingola(.PartitaCasaAssistenzaBase, New Garanzia(.CoperturaCasaAssistenzaBase.Garanzia.Descrizione, GaranzieAssistenza))
                    CoperturaAssistenza.ListinoLordo = .CoperturaCasaAssistenzaBase.ListinoLordo
                    CoperturaAssistenza.Stato = .CoperturaCasaAssistenzaBase.Stato

                    Dim CoperturaCasa As New CoperturaStampa(CoperturaIncendio _
                                                             + CoperturaFurto _
                                                             + CoperturaRC _
                                                             + CoperturaAssistenza _
                                                             + .CoperturaCasaPoliennale)

                    .CoperturaCasaPoliennale.Parametro1 = decode.DecodeCasaDurataPoliennale(.CasaDurataPoliennale)
                    StampaCoperture(CoperturaCasa, "Casa Smart" & " (" & Luogo.Province(.Provincia).Nome & ")", decode.DecodeCasaIncendioScelta(.CasaScelta), options)

                    If .SezioneInfortuni.IsAttivo Then
                        StampaDettaglioFine(preventivo, options)
                        StampaIntestazionePagina(preventivo, options)
                        StampaDettaglioInizio(preventivo, options)
                    End If

                End If

                If .SezioneInfortuni.IsAttivo Or .SezioneAttivitaRC.IsAttivo Then
                    Dim CoperturaInfortuni As New CoperturaStampa(.CoperturaInfortuniMorte _
                                                                    + .CoperturaInfortuniIP _
                                                                    + .CoperturaInfortuniSpeseMediche _
                                                                    + .CoperturaInfortuniDiarieDegenza _
                                                                    + .CoperturaInfortuniDiarieDayHospital _
                                                                    + .CoperturaInfortuniDiarieImmobilizzazione _
                                                                    + .CoperturaInfortuniFamiglia _
                                                                    + .CoperturaInfortuniFranchigia _
                                                                    + .CoperturaInfortuniPoliennale)

                    .CoperturaInfortuniMorte.Garanzia.Massimale = .PartitaInfortuniMorte.SommaAssicurata
                    .CoperturaInfortuniIP.Garanzia.Massimale = .PartitaInfortuniIP.SommaAssicurata
                    .CoperturaInfortuniSpeseMediche.Garanzia.Massimale = .PartitaInfortuniSpeseMediche.SommaAssicurata
                    .CoperturaInfortuniDiarieDegenza.Garanzia.Massimale = .PartitaInfortuniDiarieDegenza.SommaAssicurata
                    .CoperturaInfortuniDiarieDayHospital.Garanzia.Massimale = .PartitaInfortuniDiarieDayHospital.SommaAssicurata
                    .CoperturaInfortuniDiarieImmobilizzazione.Garanzia.Massimale = .PartitaInfortuniDiarieImmobilizzazione.SommaAssicurata

                    .CoperturaInfortuniPoliennale.Parametro1 = decode.DecodeInfortuniDurataPoliennale(.InfortuniDurataPoliennale)
                    StampaCoperture(CoperturaInfortuni, "Infortuni Smart", decode.DecodeInfortuniScelta(.InfortuniScelta), options)
                End If

                If .SezioneAttivitaRC.IsAttivo Then
                    Dim CoperturaAttivita As New CoperturaStampa(.CoperturaAttivitaRCT _
                                                                   + .CoperturaAttivitaRCL _
                                                                   + .CoperturaAttivitaIncendioFC _
                                                                   + .CoperturaAttivitaAttiVandalici _
                                                                   + .CoperturaAttivitaPoliennale)

                    .CoperturaAttivitaRCT.Garanzia.Massimale = .PartitaAttivitaRCT.SommaAssicurata
                    .CoperturaAttivitaRCL.Garanzia.Massimale = .PartitaAttivitaRCL.SommaAssicurata
                    .CoperturaAttivitaIncendioFC.Garanzia.Massimale = 50000
                    .CoperturaAttivitaPoliennale.Parametro1 = decode.DecodeAttivitaDurataPoliennale(.AttivitaDurataPoliennale)
                    StampaCoperture(CoperturaAttivita, "Attivita Smart" & " (" & decode.DecodeAttivitaTipo(.AttivitaTipo) & ")", "Scelta " & decode.DecodeAttivitaScelta(.AttivitaScelta), options)
                End If


                StampaDettaglioFine(preventivo, options)
                StampaRiepilogoPremi(preventivo, options)
                StampaFine(preventivo, options)
            End With
        End Sub

        Private Function Garanzia(ByVal descrizione As String, Optional ByVal massimalePerSinistro As Decimal = 0, Optional ByVal limite As Decimal = 0, Optional ByVal MassimalePerAnno As Decimal = 0, Optional ByVal Scoperto As Decimal = 0, Optional ByVal Franchigia As Decimal = 0)
            Dim g As New Garanzia(descrizione)
            g.Limite = limite
            g.Massimale = massimalePerSinistro
            g.Scoperto = Scoperto
            g.Franchigia = Franchigia
            g.MassimalePerAnno = MassimalePerAnno

            Return g
        End Function
    End Class
End Namespace
