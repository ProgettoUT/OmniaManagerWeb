Namespace P04226
    <Serializable()> Public Class Fabbricato
        Public PrimoFabbricato As Boolean
        Public YouCommercio As YouCommercio
        Public SoloProprieta As Boolean
        Public ClasseFabbricato As ClasseFabbricatoEnum
        Public FabbricatoDestinazione As FabbricatoDestinazioneEnum
        Public ZonaTerritorialeFurto As ZonaTerritorialeFurtoEnum
        Public ZonaTerritorialeEventiAtmosferici As ZonaTerritorialeEventiAtmosfericiEnum
        Public IncendioEventiAtmosfericiScelta As IncendioEventiAtmosfericiSceltaEnum
        Public IncendioDanniElettriciScelta As IncendioDanniElettriciSceltaEnum
        Public IncendioDanniIndirettiScelta As IncendioDanniIndirettiSceltaEnum
        Public FurtoFissiScelta As FurtoFissiSceltaEnum
        Public FurtoValoriScelta As FurtoValoriSceltaEnum
        Public FurtoRapinaScelta As FurtoRapinaSceltaEnum
        Public Provincia As ProvinciaEnum
        Public Comune As Integer
        Public IncendioAumentoMerciMesi As Integer
        Public FurtoAumentoMerciMesi As Integer
        Public Descrizione As String
        Public Note As String

        Public Estenzione1 As Boolean
        Public Estenzione2 As Boolean
        Public Estenzione3 As Boolean
        Public Estenzione4 As Boolean

        Public TipologiaFabbricato As TipologiaFabbricatoEnum
        Public CaratteristicaCostruttiva As CaratteristicaCostruttivaEnum
        Public comuneMinorRischioSismico As Boolean
        Public TerremotoAumentoMerciMesi As Integer

        'Incendio
        Public PartitaIncendioBase As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioBase As New CoperturaSingola(PartitaIncendioBase, New Garanzia(TipoGaranzia.IncendioBase))
        Public PartitaIncendioFabbricato As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioFabbricato As New CoperturaSingola(PartitaIncendioFabbricato, New Garanzia(TipoGaranzia.IncendioFabbricato), True)
        Public PartitaIncendioContenuto As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioContenuto As New CoperturaSingola(PartitaIncendioContenuto, New Garanzia(TipoGaranzia.IncendioContenuto), True)
        Public PartitaIncendioLocazione As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioLocazione As New CoperturaSingola(PartitaIncendioLocazione, New Garanzia(TipoGaranzia.IncendioLocazione), True)
        Public PartitaIncendioCondutture As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioCondutture As New CoperturaSingola(PartitaIncendioCondutture, New Garanzia(TipoGaranzia.IncendioCondutture))
        Public PartitaIncendioDemolizione As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioDemolizione As New CoperturaSingola(PartitaIncendioDemolizione, New Garanzia(TipoGaranzia.IncendioDemolizione))
        Public PartitaIncendioEventiAtmosferici As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioEventiAtmosferici As New CoperturaSingola(PartitaIncendioEventiAtmosferici, New Garanzia(TipoGaranzia.IncendioEventiAtmosferici))
        Public PartitaIncendioDanniElettrici As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioDanniElettrici As New CoperturaSingola(PartitaIncendioDanniElettrici, New Garanzia(TipoGaranzia.IncendioDanniElettrici), True)
        Public PartitaIncendioDanniIndirettiA As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioDanniIndirettiA As New CoperturaSingola(PartitaIncendioDanniIndirettiA, New Garanzia(TipoGaranzia.IncendioDanniIndirettiA), True)
        Public PartitaIncendioDanniIndirettiB As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioDanniIndirettiB As New CoperturaSingola(PartitaIncendioDanniIndirettiB, New Garanzia(TipoGaranzia.IncendioDanniIndirettiB), True)
        Public PartitaIncendioRicorsoTerzi As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioRicorsoTerzi As New CoperturaSingola(PartitaIncendioRicorsoTerzi, New Garanzia(TipoGaranzia.IncendioRicorsoTerzi), True)
        Public PartitaIncendioAumentoMerci As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioAumentoMerci As New CoperturaSingola(PartitaIncendioAumentoMerci, New Garanzia(TipoGaranzia.IncendioAumentoMerci), True)
        Public PartitaIncendioCoseTrasportate As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioCoseTrasportate As New CoperturaSingola(PartitaIncendioCoseTrasportate, New Garanzia(TipoGaranzia.IncendioCoseTrasportate), True)
        Public PartitaIncendioRefrigerati1 As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioRefrigerati1 As New CoperturaSingola(PartitaIncendioRefrigerati1, New Garanzia(TipoGaranzia.IncendioRefrigerati1), True)
        Public PartitaIncendioRefrigerati2 As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioRefrigerati2 As New CoperturaSingola(PartitaIncendioRefrigerati2, New Garanzia(TipoGaranzia.IncendioRefrigerati2), True)
        Public PartitaIncendioLastre As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioLastre As New CoperturaSingola(PartitaIncendioLastre, New Garanzia(TipoGaranzia.IncendioLastre), True)
        Public PartitaIncendioPannelliSolari As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioPannelliSolari As New CoperturaSingola(PartitaIncendioPannelliSolari, New Garanzia(TipoGaranzia.IncendioPannelliSolari), True)
        Public PartitaIncendioRicetteMediche As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioRicetteMediche As New CoperturaSingola(PartitaIncendioRicetteMediche, New Garanzia(TipoGaranzia.IncendioRicetteMediche), True)
        Public PartitaIncendioSpeseAccessorie As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioSpeseAccessorie As New CoperturaSingola(PartitaIncendioSpeseAccessorie, New Garanzia(TipoGaranzia.IncendioSpeseAccessorie))
        Public PartitaIncendioGrandineFragili As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioGrandineFragili As New CoperturaSingola(PartitaIncendioGrandineFragili, New Garanzia(TipoGaranzia.IncendioGrandineFragili))
        Public PartitaIncendioAttiVandaliciDolosi As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioAttiVandaliciDolosi As New CoperturaSingola(PartitaIncendioAttiVandaliciDolosi, New Garanzia(TipoGaranzia.IncendioAttiVandaliciDolosi))
        Public PartitaIncendioFabbricatiAperti1 As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioFabbricatiAperti1 As New CoperturaSingola(PartitaIncendioFabbricatiAperti1, New Garanzia(TipoGaranzia.IncendioFabbricatiAperti1))
        Public PartitaIncendioFabbricatiAperti2 As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioFabbricatiAperti2 As New CoperturaSingola(PartitaIncendioFabbricatiAperti2, New Garanzia(TipoGaranzia.IncendioFabbricatiAperti2))
        Public PartitaIncendioPreziosi As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioPreziosi As New CoperturaSingola(PartitaIncendioPreziosi, New Garanzia(TipoGaranzia.IncendioPreziosi))
        Public PartitaIncendioSistemiProtezione As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioSistemiProtezione As New CoperturaSingola(PartitaIncendioSistemiProtezione, New Garanzia(TipoGaranzia.IncendioSistemiProtezione))
        Public PartitaIncendioCommercioAmbulante As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioCommercioAmbulante As New CoperturaSingola(PartitaIncendioCommercioAmbulante, New Garanzia(TipoGaranzia.IncendioCommercioAmbulante))
        Public PartitaIncendioFranchigia As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioFranchigia As New CoperturaSingola(PartitaIncendioFranchigia, New Garanzia(TipoGaranzia.IncendioFranchigia))

        'Furto
        Public PartitaFurtoBase As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoBase As New CoperturaSingola(PartitaFurtoBase, New Garanzia(TipoGaranzia.FurtoBase))
        Public PartitaFurtoContenuto As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoContenuto As New CoperturaSingola(PartitaFurtoContenuto, New Garanzia(TipoGaranzia.FurtoContenuto), True)
        Public PartitaFurtoFissi As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoFissi As New CoperturaSingola(PartitaFurtoFissi, New Garanzia(TipoGaranzia.FurtoFissi), True)
        Public PartitaFurtoValori As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoValori As New CoperturaSingola(PartitaFurtoValori, New Garanzia(TipoGaranzia.FurtoValori), True)
        Public PartitaFurtoRapina As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoRapina As New CoperturaSingola(PartitaFurtoRapina, New Garanzia(TipoGaranzia.FurtoRapina), True)
        Public PartitaFurtoVetrinette As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoVetrinette As New CoperturaSingola(PartitaFurtoVetrinette, New Garanzia(TipoGaranzia.FurtoVetrinette), True)
        Public PartitaFurtoPortavalori As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoPortavalori As New CoperturaSingola(PartitaFurtoPortavalori, New Garanzia(TipoGaranzia.FurtoPortavalori), True)
        Public PartitaFurtoAumentoMerci As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoAumentoMerci As New CoperturaSingola(PartitaFurtoAumentoMerci, New Garanzia(TipoGaranzia.FurtoAumentoMerci), True)
        Public PartitaFurtoMerciTrasportate As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoMerciTrasportate As New CoperturaSingola(PartitaFurtoMerciTrasportate, New Garanzia(TipoGaranzia.FurtoMerciTrasportate), True)
        Public PartitaFurtoMerciAperto As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoMerciAperto As New CoperturaSingola(PartitaFurtoMerciAperto, New Garanzia(TipoGaranzia.FurtoMerciAperto), True)
        Public PartitaFurtoDistributoriEsterni As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoDistributoriEsterni As New CoperturaSingola(PartitaFurtoDistributoriEsterni, New Garanzia(TipoGaranzia.FurtoDistributoriEsterni), True)
        Public PartitaFurtoDistributoriCarburante As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoDistributoriCarburante As New CoperturaSingola(PartitaFurtoDistributoriCarburante, New Garanzia(TipoGaranzia.FurtoDistributoriCarburante), True)
        Public PartitaFurtoRicetteMediche As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoRicetteMediche As New CoperturaSingola(PartitaFurtoRicetteMediche, New Garanzia(TipoGaranzia.FurtoRicetteMediche), True)
        Public PartitaFurtoDipendenti As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoDipendenti As New CoperturaSingola(PartitaFurtoDipendenti, New Garanzia(TipoGaranzia.FurtoDipendenti), True)
        'Public PartitaFurtoSpeseAccessorie As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoSpeseAccessorie As New CoperturaSingola(PartitaFurtoContenuto, New Garanzia(TipoGaranzia.FurtoSpeseAccessorie))
        'Public PartitaFurtoSpeseMiglioramento As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoSpeseMiglioramento As New CoperturaSingola(PartitaFurtoContenuto, New Garanzia(TipoGaranzia.FurtoSpeseMiglioramento))
        Public PartitaFurtoSlotMachine As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoSlotMachine As New CoperturaSingola(PartitaFurtoSlotMachine, New Garanzia(TipoGaranzia.FurtoSlotMachine), True)
        Public PartitaFurtoReintegroAutomatico As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoReintegroAutomatico As New CoperturaSingola(PartitaFurtoReintegroAutomatico, New Garanzia(TipoGaranzia.FurtoReintegroAutomatico))
        Public PartitaFurtoCommercioAmbulante As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoCommercioAmbulante As New CoperturaSingola(PartitaFurtoCommercioAmbulante, New Garanzia(TipoGaranzia.FurtoCommercioAmbulante))
        Public PartitaFurtoDepositoRiserva As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoDepositoRiserva As New CoperturaSingola(PartitaFurtoDepositoRiserva, New Garanzia(TipoGaranzia.FurtoDepositoRiserva))
        Public PartitaFurtoDerogaCostruttive As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoDerogaCostruttive As New CoperturaSingola(PartitaFurtoDerogaCostruttive, New Garanzia(TipoGaranzia.FurtoDerogaCostruttive))
        Public PartitaFurtoMezziChiusura As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoMezziChiusura As New CoperturaSingola(PartitaFurtoMezziChiusura, New Garanzia(TipoGaranzia.FurtoMezziChiusura))
        'Public PartitaFurtoImpiantoAllarme As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoImpiantoAllarme As New CoperturaSingola(PartitaFurtoMezziChiusura, New Garanzia(TipoGaranzia.FurtoImpiantoAllarme))
        'Public PartitaFurtoAllarmeDistanza As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoAllarmeDistanza As New CoperturaSingola(PartitaFurtoMezziChiusura, New Garanzia(TipoGaranzia.FurtoAllarmeDistanza))
        'Public PartitaFurtoAllarmeDoppio As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoAllarmeDoppio As New CoperturaSingola(PartitaFurtoMezziChiusura, New Garanzia(TipoGaranzia.FurtoAllarmeDoppio))
        'Public PartitaFurtoVideoSorveglianza As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoVideoSorveglianza As New CoperturaSingola(PartitaFurtoMezziChiusura, New Garanzia(TipoGaranzia.FurtoVideoSorveglianza))
        Public PartitaFurtoScopertoMerciA As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoScopertoMerciA As New CoperturaSingola(PartitaFurtoScopertoMerciA, New Garanzia(TipoGaranzia.FurtoScopertoMerciA))
        Public PartitaFurtoScopertoMerciB As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoScopertoMerciB As New CoperturaSingola(PartitaFurtoScopertoMerciB, New Garanzia(TipoGaranzia.FurtoScopertoMerciB))
        Public PartitaFurtoPiuEsercizi As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoPiuEsercizi As New CoperturaSingola(PartitaFurtoPiuEsercizi, New Garanzia(TipoGaranzia.FurtoPiuEsercizi))

        'Terremoto
        Public PartitaTerremotoBase As New Partita(TipoPartita.Terremoto)
        Public CoperturaTerremotoBase As New CoperturaSingola(PartitaTerremotoBase, New Garanzia(TipoGaranzia.TerremotoBase))
        Public PartitaTerremotoFabbricato As New Partita(TipoPartita.Terremoto)
        Public CoperturaTerremotoFabbricato As New CoperturaSingola(PartitaTerremotoFabbricato, New Garanzia(TipoGaranzia.TerremotoFabbricato), True)
        Public PartitaTerremotoContenuto As New Partita(TipoPartita.Terremoto)
        Public CoperturaTerremotoContenuto As New CoperturaSingola(PartitaTerremotoContenuto, New Garanzia(TipoGaranzia.TerremotoContenuto), True)
        Public PartitaTerremotoDemolizione As New Partita(TipoPartita.Terremoto)
        Public CoperturaTerremotoDemolizione As New CoperturaSingola(PartitaTerremotoDemolizione, New Garanzia(TipoGaranzia.TerremotoDemolizione))
        Public PartitaTerremotoAumentoMerci As New Partita(TipoPartita.Terremoto)
        Public CoperturaTerremotoAumentoMerci As New CoperturaSingola(PartitaTerremotoAumentoMerci, New Garanzia(TipoGaranzia.TerremotoAumentoMerci), True)
        Public PartitaTerremotoRicetteMediche As New Partita(TipoPartita.Terremoto)
        Public CoperturaTerremotoRicetteMediche As New CoperturaSingola(PartitaTerremotoRicetteMediche, New Garanzia(TipoGaranzia.TerremotoRicetteMediche), True)

        Public CoperturaIncendio As New CoperturaComposta()
        Public CoperturaFurto As New CoperturaComposta()
        Public CoperturaTerremoto As New CoperturaComposta()

        Public IncendioFabbricatoFormaDiAssicurazione As FormaDiAssicurazione
        Public IncendioContenutoFormaDiAssicurazione As FormaDiAssicurazione
        Public IncendioLocazioneFormaDiAssicurazione As FormaDiAssicurazione

        Public Property IncendioScelta() As IncendioSceltaEnum
            Get
                Return YouCommercio.IncendioScelta
            End Get
            Set(ByVal value As IncendioSceltaEnum)
                YouCommercio.IncendioScelta = value
            End Set
        End Property


        Public Sub New(ByVal YouCommercio As YouCommercio)
            Me.YouCommercio = YouCommercio

            With CoperturaIncendio
                .Sezione = YouCommercio.SezioneIncendio

                .AddCopertura(CoperturaIncendioBase)
                .AddCopertura(CoperturaIncendioFabbricato)
                .AddCopertura(CoperturaIncendioContenuto)
                .AddCopertura(CoperturaIncendioLocazione)
                .AddCopertura(CoperturaIncendioCondutture)
                .AddCopertura(CoperturaIncendioDemolizione)
                .AddCopertura(CoperturaIncendioEventiAtmosferici)
                .AddCopertura(CoperturaIncendioDanniElettrici)
                .AddCopertura(CoperturaIncendioDanniIndirettiA)
                .AddCopertura(CoperturaIncendioDanniIndirettiB)
                .AddCopertura(CoperturaIncendioRicorsoTerzi)
                .AddCopertura(CoperturaIncendioAumentoMerci)
                .AddCopertura(CoperturaIncendioCoseTrasportate)
                .AddCopertura(CoperturaIncendioRefrigerati1)
                .AddCopertura(CoperturaIncendioRefrigerati2)
                .AddCopertura(CoperturaIncendioLastre)
                .AddCopertura(CoperturaIncendioPannelliSolari)
                .AddCopertura(CoperturaIncendioRicetteMediche)
                .AddCopertura(CoperturaIncendioSpeseAccessorie)
                .AddCopertura(CoperturaIncendioGrandineFragili)
                .AddCopertura(CoperturaIncendioAttiVandaliciDolosi)
                .AddCopertura(CoperturaIncendioFabbricatiAperti1)
                .AddCopertura(CoperturaIncendioFabbricatiAperti2)
                .AddCopertura(CoperturaIncendioPreziosi)
                .AddCopertura(CoperturaIncendioSistemiProtezione)
                .AddCopertura(CoperturaIncendioCommercioAmbulante)
                .AddCopertura(CoperturaIncendioFranchigia)

            End With

            With CoperturaFurto
                .Sezione = YouCommercio.SezioneFurto
                .AddCopertura(CoperturaFurtoBase)
                .AddCopertura(CoperturaFurtoContenuto)
                .AddCopertura(CoperturaFurtoFissi)
                .AddCopertura(CoperturaFurtoValori)
                .AddCopertura(CoperturaFurtoRapina)
                .AddCopertura(CoperturaFurtoVetrinette)
                .AddCopertura(CoperturaFurtoPortavalori)
                .AddCopertura(CoperturaFurtoAumentoMerci)
                .AddCopertura(CoperturaFurtoMerciTrasportate)
                .AddCopertura(CoperturaFurtoMerciAperto)
                .AddCopertura(CoperturaFurtoDistributoriEsterni)
                .AddCopertura(CoperturaFurtoDistributoriCarburante)
                .AddCopertura(CoperturaFurtoRicetteMediche)
                .AddCopertura(CoperturaFurtoDipendenti)
                .AddCopertura(CoperturaFurtoSpeseAccessorie)
                .AddCopertura(CoperturaFurtoSpeseMiglioramento)
                .AddCopertura(CoperturaFurtoSlotMachine)
                .AddCopertura(CoperturaFurtoReintegroAutomatico)
                .AddCopertura(CoperturaFurtoCommercioAmbulante)
                .AddCopertura(CoperturaFurtoDepositoRiserva)
                .AddCopertura(CoperturaFurtoDerogaCostruttive)
                .AddCopertura(CoperturaFurtoMezziChiusura)
                .AddCopertura(CoperturaFurtoImpiantoAllarme)
                .AddCopertura(CoperturaFurtoAllarmeDistanza)
                .AddCopertura(CoperturaFurtoAllarmeDoppio)
                .AddCopertura(CoperturaFurtoVideoSorveglianza)
                .AddCopertura(CoperturaFurtoScopertoMerciA)
                .AddCopertura(CoperturaFurtoScopertoMerciB)
                .AddCopertura(CoperturaFurtoPiuEsercizi)
            End With

            With CoperturaTerremoto
                .Sezione = YouCommercio.SezioneTerremoto
                .AddCopertura(CoperturaTerremotoBase)
                .AddCopertura(CoperturaTerremotoFabbricato)
                .AddCopertura(CoperturaTerremotoContenuto)
                .AddCopertura(CoperturaTerremotoDemolizione)
                .AddCopertura(CoperturaTerremotoAumentoMerci)
                .AddCopertura(CoperturaTerremotoRicetteMediche)
            End With
        End Sub

        Public Function ValidaSezioneIncendio() As Boolean
            'NB: In Essig la quotaparte è aggiunta in atti vandalici
            'INCENDIO - DANNI INDIRETTI A DIARIA - PREMIO AGGIUNTIVO PER GA NEVE
            'default
            If IncendioScelta = 0 Then IncendioScelta = IncendioSceltaEnum.RischiNominati

            If YouCommercio.SoloProprieta Then
                IncendioFabbricatoFormaDiAssicurazione = FormaDiAssicurazione.ValoreInteroNuovo
                IncendioContenutoFormaDiAssicurazione = FormaDiAssicurazione.ValoreInteroNuovo
                IncendioLocazioneFormaDiAssicurazione = FormaDiAssicurazione.ValoreInteroNuovo
                IncendioDanniElettriciScelta = IncendioDanniElettriciSceltaEnum.SceltaBasic
                IncendioDanniIndirettiScelta = IncendioDanniIndirettiSceltaEnum.SceltaBasicPercentuale
            Else
                If IncendioFabbricatoFormaDiAssicurazione = 0 Then IncendioFabbricatoFormaDiAssicurazione = FormaDiAssicurazione.ValoreInteroNuovo
                If IncendioContenutoFormaDiAssicurazione = 0 Then IncendioContenutoFormaDiAssicurazione = FormaDiAssicurazione.ValoreInteroNuovo
                If IncendioLocazioneFormaDiAssicurazione = 0 Then IncendioLocazioneFormaDiAssicurazione = FormaDiAssicurazione.ValoreInteroNuovo
                If IncendioDanniElettriciScelta = 0 Then IncendioDanniElettriciScelta = IncendioDanniElettriciSceltaEnum.SceltaBasic
                If IncendioDanniIndirettiScelta = 0 Then IncendioDanniIndirettiScelta = IncendioDanniIndirettiSceltaEnum.SceltaBasicDiaria
            End If

            'dipendenze
            CoperturaIncendioBase.DipendeDa(True)
            CoperturaIncendio.Stato = CoperturaIncendioBase.Stato

            CoperturaIncendioFabbricato.DipendeDa(CoperturaIncendioBase.IsAttivo And Not CoperturaIncendioLocazione.IsAttivo)

            CoperturaIncendioContenuto.DipendeDa(CoperturaIncendioBase.IsAttivo And Not YouCommercio.SoloProprieta)
            CoperturaIncendioLocazione.DipendeDa(CoperturaIncendioBase.IsAttivo And Not CoperturaIncendioFabbricato.IsAttivo And Not YouCommercio.SoloProprieta)

            Dim BaseIsAttivo As Boolean = CoperturaIncendioFabbricato.IsAttivo Or CoperturaIncendioContenuto.IsAttivo Or CoperturaIncendioLocazione.IsAttivo
            CoperturaIncendioCondutture.ObbligatoriaDa(CoperturaIncendioFabbricato.IsAttivo)
            CoperturaIncendioDemolizione.ObbligatoriaDa(BaseIsAttivo)

            If IncendioScelta = IncendioSceltaEnum.RischiNominati Then
                CoperturaIncendioLastre.DipendeDa(CoperturaIncendioFabbricato.IsAttivo Or CoperturaIncendioContenuto.IsAttivo)
                CoperturaIncendioDanniElettrici.DipendeDa(CoperturaIncendioFabbricato.IsAttivo Or CoperturaIncendioContenuto.IsAttivo)
            Else
                CoperturaIncendioLastre.ObbligatoriaDa(CoperturaIncendioFabbricato.IsAttivo Or CoperturaIncendioContenuto.IsAttivo)
                CoperturaIncendioDanniElettrici.ObbligatoriaDa(CoperturaIncendioFabbricato.IsAttivo Or CoperturaIncendioContenuto.IsAttivo)
            End If

            CoperturaIncendioEventiAtmosferici.DipendeDa((CoperturaIncendioFabbricato.IsAttivo Or CoperturaIncendioContenuto.IsAttivo) And IncendioScelta = IncendioSceltaEnum.RischiNominati)
            CoperturaIncendioDanniIndirettiA.DipendeDa(CoperturaIncendioFabbricato.IsAttivo Or CoperturaIncendioContenuto.IsAttivo)
            CoperturaIncendioDanniIndirettiB.DipendeDa(CoperturaIncendioDanniIndirettiA.IsAttivo And Not YouCommercio.SoloProprieta)
            CoperturaIncendioRicorsoTerzi.DipendeDa(BaseIsAttivo)
            CoperturaIncendioAumentoMerci.DipendeDa(CoperturaIncendioContenuto.IsAttivo And FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici)
            CoperturaIncendioCoseTrasportate.DipendeDa(CoperturaIncendioContenuto.IsAttivo And FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici)
            CoperturaIncendioRefrigerati1.DipendeDa(CoperturaIncendioContenuto.IsAttivo And Not CoperturaIncendioRefrigerati2.IsAttivo And FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici)
            CoperturaIncendioRefrigerati2.DipendeDa(CoperturaIncendioContenuto.IsAttivo And Not CoperturaIncendioRefrigerati1.IsAttivo And FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici)
            CoperturaIncendioPannelliSolari.DipendeDa(CoperturaIncendioFabbricato.IsAttivo)
            CoperturaIncendioRicetteMediche.DipendeDa(CoperturaIncendioContenuto.IsAttivo And Not YouCommercio.SoloProprieta And YouCommercio.CodiceAttivita1 = 754 And FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici)
            CoperturaIncendioSpeseAccessorie.DipendeDa(BaseIsAttivo And Not YouCommercio.SoloProprieta)
            CoperturaIncendioGrandineFragili.DipendeDa((CoperturaIncendioFabbricato.IsAttivo Or CoperturaIncendioContenuto.IsAttivo) And IncendioScelta = IncendioSceltaEnum.AllRisks)
            CoperturaIncendioAttiVandaliciDolosi.DipendeDa((CoperturaIncendioFabbricato.IsAttivo Or CoperturaIncendioContenuto.IsAttivo) And IncendioScelta = IncendioSceltaEnum.RischiNominati)
            CoperturaIncendioFabbricatiAperti1.DipendeDa((CoperturaIncendioFabbricato.IsAttivo Or CoperturaIncendioContenuto.IsAttivo) And Not CoperturaIncendioFabbricatiAperti2.IsAttivo)
            CoperturaIncendioFabbricatiAperti2.DipendeDa(CoperturaIncendioContenuto.IsAttivo And Not CoperturaIncendioFabbricatiAperti1.IsAttivo And IncendioScelta = IncendioSceltaEnum.RischiNominati And IsOneOf(YouCommercio.CodiceAttivita1, 251, 254, 256, 257, 258))
            CoperturaIncendioPreziosi.DipendeDa(CoperturaIncendioContenuto.IsAttivo And IncendioScelta = IncendioSceltaEnum.RischiNominati)
            CoperturaIncendioSistemiProtezione.DipendeDa(CoperturaIncendioDanniElettrici.IsAttivo And Not (FabbricatoDestinazione = FabbricatoDestinazioneEnum.Uffici And IncendioScelta = IncendioSceltaEnum.AllRisks))
            CoperturaIncendioCommercioAmbulante.DipendeDa(CoperturaIncendioContenuto.IsAttivo And FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici)
            CoperturaIncendioFranchigia.DipendeDa(BaseIsAttivo)

            PartitaIncendioFabbricato.LimitiAssuntivi(0D, 2200000D)
            PartitaIncendioContenuto.LimitiAssuntivi(0D, 2200000D)
            PartitaIncendioLocazione.LimitiAssuntivi(0D, 2200000D)
            PartitaIncendioAumentoMerci.LimitiAssuntivi(0D, 2200000D)
            PartitaIncendioDemolizione.LimitiAssuntivi(0D, 2200000D)
            PartitaIncendioDanniIndirettiA.LimitiAssuntivi(0D, 2200000D)
            PartitaIncendioDanniIndirettiB.LimitiAssuntivi(0D, 2200000D)
            PartitaIncendioCoseTrasportate.LimitiAssuntivi(0D, 10000D)

            PartitaIncendioRicorsoTerzi.LimitiAssuntivi(0D, 2000000D)
            If IncendioScelta = IncendioSceltaEnum.AllRisks And IncendioDanniElettriciScelta = IncendioDanniElettriciSceltaEnum.SceltaMedium Then
                PartitaIncendioDanniElettrici.LimitiAssuntivi(0D, 25000D)
            Else
                PartitaIncendioDanniElettrici.LimitiAssuntivi(0D, 13000D)
            End If
            PartitaIncendioRefrigerati1.LimitiAssuntivi(0D, 10000D)
            PartitaIncendioRefrigerati2.LimitiAssuntivi(0D, 30000D)
            PartitaIncendioLastre.LimitiAssuntivi(0D, 15000D)
            PartitaIncendioPannelliSolari.LimitiAssuntivi(0D, 80000D)
            PartitaIncendioRicetteMediche.LimitiAssuntivi(0D, 10000D)

            'sottolimite
            PartitaIncendioContenuto.LimitiAssuntivi(0D, 1200000D)
            PartitaIncendioAumentoMerci.LimitiAssuntivi(0D, 1200000D - PartitaIncendioContenuto.SommaAssicurata)
            PartitaIncendioAumentoMerci.LimitiAssuntivi(0D, 2D * PartitaIncendioContenuto.SommaAssicurata)

            If IncendioDanniIndirettiScelta = IncendioDanniIndirettiSceltaEnum.SceltaBasicDiaria Then
                PartitaIncendioDanniIndirettiA.LimitiAssuntivi(0D, 1000D)
            End If
            PartitaIncendioDanniIndirettiB.LimitiAssuntivi(0D, 20000D)

            With CoperturaIncendioBase
                .Tariffa.Tasso = 0D
                .Tariffa.Base = 0D
            End With

            Dim CoefficienteClasseFabbricato = 1D
            If ClasseFabbricato = ClasseFabbricatoEnum.Classe2 Then
                CoefficienteClasseFabbricato = 1.2D
            End If

            '1)
            With CoperturaIncendioFabbricato
                If IncendioScelta = IncendioSceltaEnum.RischiNominati Then
                    If FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrosso _
                    Or FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrossoDettaglio Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaIncendio, 1.55D, 1.25D, 0.9D, 0.65D) / 1000D
                    ElseIf FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaDettaglio Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaIncendio, 1.3D, 1.05D, 0.75D, 0.55D) / 1000D
                    ElseIf FabbricatoDestinazione = FabbricatoDestinazioneEnum.Uffici = True Then
                        .Tariffa.Tasso = 0.31D / 1000D
                    Else
                        .Tariffa.Tasso = 0D
                    End If
                Else
                    If FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrosso _
                    Or FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrossoDettaglio Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaIncendio, 3.25D, 2.9D, 2.5D, 2.2D) / 1000D
                    ElseIf FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaDettaglio Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaIncendio, 2.7D, 2.45D, 2.1D, 1.85D) / 1000D
                    ElseIf FabbricatoDestinazione = FabbricatoDestinazioneEnum.Uffici Then
                        .Tariffa.Tasso = 0.92D / 1000D
                    Else
                        .Tariffa.Tasso = 0D
                    End If
                End If

                .Tariffa.Tasso *= CoefficienteClasseFabbricato
            End With

            '2)
            With CoperturaIncendioContenuto
                If IncendioScelta = IncendioSceltaEnum.RischiNominati Then
                    If FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrosso _
                    Or FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrossoDettaglio Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaIncendio, 2.35D, 1.85D, 1.4D, 0.95D) / 1000D
                    ElseIf FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaDettaglio Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaIncendio, 1.95D, 1.55D, 1.15D, 0.8D) / 1000D
                    ElseIf FabbricatoDestinazione = FabbricatoDestinazioneEnum.Uffici Then
                        .Tariffa.Tasso = 0.4D / 1000D
                    Else
                        .Tariffa.Tasso = 0D
                    End If
                Else
                    If FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrosso _
                    Or FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrossoDettaglio Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaIncendio, 4.05D, 3.5D, 2.95D, 2.5D) / 1000D
                    ElseIf FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaDettaglio Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaIncendio, 3.4D, 2.9D, 2.5D, 2.05D) / 1000D
                    ElseIf FabbricatoDestinazione = FabbricatoDestinazioneEnum.Uffici Then
                        .Tariffa.Tasso = 0.98D / 1000D
                    Else
                        .Tariffa.Tasso = 0D
                    End If
                End If

                .Tariffa.Tasso *= CoefficienteClasseFabbricato
            End With

            '3)
            With CoperturaIncendioLocazione
                If IncendioScelta = IncendioSceltaEnum.RischiNominati Then
                    If FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrosso _
                    Or FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrossoDettaglio Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaIncendio, 1.15D, 0.95D, 0.65D, 0.45D) / 1000D
                    ElseIf FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaDettaglio Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaIncendio, 1D, 0.8D, 0.55D, 0.4D) / 1000D
                    ElseIf FabbricatoDestinazione = FabbricatoDestinazioneEnum.Uffici Then
                        .Tariffa.Tasso = 0.2D / 1000D
                    Else
                        .Tariffa.Tasso = 0D
                    End If
                Else
                    If FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrosso _
                    Or FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrossoDettaglio Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaIncendio, 2.44D, 2.17D, 1.88D, 1.65D) / 1000D
                    ElseIf FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaDettaglio Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaIncendio, 2.08D, 1.89D, 1.62D, 1.42D) / 1000D
                    ElseIf FabbricatoDestinazione = FabbricatoDestinazioneEnum.Uffici Then
                        .Tariffa.Tasso = 0.67D / 1000D
                    Else
                        .Tariffa.Tasso = 0D
                    End If
                End If

                .Tariffa.Tasso *= CoefficienteClasseFabbricato
            End With

            '4)
            With CoperturaIncendioDemolizione
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 10000D
                .Partita.SommaAssicurata = .Garanzia.Massimale

                If .Garanzia.Massimale = 10000D Then
                    .Tariffa.Base = 24D
                ElseIf .Garanzia.Massimale = 30000D Then
                    .Tariffa.Base = 70D
                ElseIf .Garanzia.Massimale = 50000D Then
                    .Tariffa.Base = 110D
                ElseIf .Garanzia.Massimale = 100000D Then
                    .Tariffa.Base = 200D
                ElseIf .Garanzia.Massimale = 200000D Then
                    .Tariffa.Base = 350D
                Else
                    .Tariffa.Base = 0D
                End If

                .Tariffa.Base *= CoefficienteClasseFabbricato

                .RischioDirezione = (.Tariffa.Base = 0D)
                .DescrizioneRD = "Spese di demolizione e sgombero oltre 200.000€"
            End With

            '5)
            With CoperturaIncendioCondutture
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 2000D
                .Partita.SommaAssicurata = .Garanzia.Massimale

                If .Garanzia.Massimale = 2000D Then
                    .Tariffa.Base = 18D
                ElseIf .Garanzia.Massimale = 5000D Then
                    .Tariffa.Base = 40D
                ElseIf .Garanzia.Massimale = 10000D Then
                    .Tariffa.Base = 75D
                Else
                    .Tariffa.Base = 0D
                End If

                .Tariffa.Base *= CoefficienteClasseFabbricato

                .RischioDirezione = (.Tariffa.Base = 0D)
                .DescrizioneRD = "Spese di Ricerca del guasto oltre 10.000€"
            End With

            '6)
            With CoperturaIncendioDanniElettrici
                .Tariffa.Tasso = 0D
                .Tariffa.Base = 0D

                If FabbricatoDestinazione = FabbricatoDestinazioneEnum.Uffici Then
                    IncendioDanniElettriciScelta = IncendioDanniElettriciSceltaEnum.SceltaBasic
                End If

                If IncendioScelta = IncendioSceltaEnum.RischiNominati Then
                    '.Partita.SommaAssicurata = CoperturaIncendioFabbricato.PremioAttivoCrudo + CoperturaIncendioContenuto.PremioAttivoCrudo
                    If .Partita.SommaAssicurata <= 0D Then .Partita.SommaAssicurata = 0D
                    If IncendioDanniElettriciScelta = IncendioDanniElettriciSceltaEnum.SceltaBasic Then
                        .Tariffa.Tasso = 26.9D / 1000D
                    ElseIf IncendioDanniElettriciScelta = IncendioDanniElettriciSceltaEnum.SceltaMedium Then
                        .Tariffa.Tasso = 34.25D / 1000D
                    End If
                ElseIf IncendioScelta = IncendioSceltaEnum.AllRisks Then
                    If .Partita.SommaAssicurata <= 2500D Then .Partita.SommaAssicurata = 2500D
                    If IncendioDanniElettriciScelta = IncendioDanniElettriciSceltaEnum.SceltaBasic Then
                        If .Partita.SommaAssicurata = 2500D Then
                            .Tariffa.Base = 21.24D
                            .Tariffa.Tasso = 0D
                        Else
                            .Tariffa.Base = 21.24D - 2500D * 26.9D / 1000D
                            .Tariffa.Tasso = 26.9D / 1000D
                        End If
                    ElseIf IncendioDanniElettriciScelta = IncendioDanniElettriciSceltaEnum.SceltaMedium Then
                        If .Partita.SommaAssicurata = 2500D Then
                            .Tariffa.Tasso = 39.62D
                            .Tariffa.Tasso = 0D
                        Else
                            .Tariffa.Base = 39.62D - 2500D * 34.25D / 1000D
                            .Tariffa.Tasso = 34.25D / 1000D
                        End If
                    End If
                End If
            End With

            '7)
            With CoperturaIncendioRicorsoTerzi
                .Tariffa.Tasso = 0D
                If IncendioScelta = IncendioSceltaEnum.RischiNominati Then
                    If FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrosso _
                    Or FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrossoDettaglio Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaIncendio, 1.45D, 1.15D, 0.9D, 0.65D) / 1000D
                    ElseIf FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaDettaglio Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaIncendio, 1.2D, 1D, 0.75D, 0.55D) / 1000D
                    ElseIf FabbricatoDestinazione = FabbricatoDestinazioneEnum.Uffici Then
                        .Tariffa.Tasso = 0.2D / 1000D
                    End If
                ElseIf IncendioScelta = IncendioSceltaEnum.AllRisks Then
                    If FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrosso _
                    Or FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrossoDettaglio Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaIncendio, 1.9D, 1.55D, 1.15D, 0.8D) / 1000D
                    ElseIf FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaDettaglio Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaIncendio, 1.6D, 1.3D, 0.95D, 0.7D) / 1000D
                    ElseIf FabbricatoDestinazione = FabbricatoDestinazioneEnum.Uffici Then
                        .Tariffa.Tasso = 0.34D / 1000D
                    End If
                End If
            End With

            '8)
            With CoperturaIncendioAumentoMerci
                If FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici Then
                    .RischioDirezione = (IncendioAumentoMerciMesi > 6)
                    .DescrizioneRD = "Oltre 6 mesi la garanzia è Riservata Direzione"
                    'Tasso = Numero Mesi X Tasso Mensile 1/10 del tasso Contenuto
                    .Tariffa.Tasso = IncendioAumentoMerciMesi * CoperturaIncendioContenuto.Tariffa.Tasso / 10D

                    .Tariffa.Tasso /= CoefficienteClasseFabbricato
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            '9)
            With CoperturaIncendioCoseTrasportate
                If FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici Then
                    If IncendioScelta = IncendioSceltaEnum.RischiNominati Then
                        .Tariffa.Tasso = 15.9D / 1000D
                    Else
                        .Tariffa.Tasso = 15.89D / 1000D
                    End If
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            '10)
            With CoperturaIncendioRefrigerati1
                If FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici Then
                    .Tariffa.Tasso = 24.4D / 1000D
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            '11)
            With CoperturaIncendioRefrigerati2
                If FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici Then
                    .Tariffa.Tasso = 17.1D / 1000D
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            '12)
            With CoperturaIncendioLastre
                .Tariffa.Base = 0D
                .Tariffa.Tasso = 0D
                If IncendioScelta = IncendioSceltaEnum.RischiNominati Then
                    .Tariffa.Tasso = 42.8D / 1000D
                ElseIf IncendioScelta = IncendioSceltaEnum.AllRisks Then
                    If .Partita.SommaAssicurata < 2500D Then .Partita.SommaAssicurata = 2500D
                    If .Partita.SommaAssicurata < 2500 Then
                        .Tariffa.Base = 36.61D
                        .Tariffa.Tasso = 0D
                    Else
                        .Tariffa.Base = 36.61D - 2500D * 42.8D / 1000D
                        .Tariffa.Tasso = 42.8D / 1000D
                    End If
                End If
            End With

            '13)
            With CoperturaIncendioPannelliSolari
                If IncendioScelta = IncendioSceltaEnum.RischiNominati Then
                    .Tariffa.Tasso = 1.85D / 1000D
                ElseIf IncendioScelta = IncendioSceltaEnum.AllRisks Then
                    .Tariffa.Tasso = 0.8D / 1000D
                End If
            End With

            '14)
            With CoperturaIncendioRicetteMediche
                .Tariffa.Tasso = 0D
                If FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici Then
                    If IncendioScelta = IncendioSceltaEnum.RischiNominati Then
                        .Tariffa.Tasso = 2.8D / 1000D
                    ElseIf IncendioScelta = IncendioSceltaEnum.AllRisks Then
                        .Tariffa.Tasso = 3.65D / 1000D
                    End If
                End If
            End With

            '15)
            With CoperturaIncendioSpeseAccessorie
                .Tariffa.Base = 20D
            End With

            '16)
            Dim IncendioDanniIndirettiSommaAssicurataAttiva As Decimal = 0D
            Dim IncendioDanniIndirettiDiariaPremioAttivo As Decimal = 0D
            Dim IncendioDanniIndirettiPercenPremioAttivo As Decimal = 0D

            With CoperturaIncendioDanniIndirettiA
                .Tariffa.Tasso = 0D
                .Tariffa.Base = 0D

                If FabbricatoDestinazione = FabbricatoDestinazioneEnum.Uffici Then
                    IncendioDanniIndirettiScelta = IncendioDanniIndirettiSceltaEnum.SceltaBasicPercentuale
                End If

                If IncendioDanniIndirettiScelta = IncendioDanniIndirettiSceltaEnum.SceltaBasicDiaria Then
                    If IncendioScelta = IncendioSceltaEnum.RischiNominati Then
                        If FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrosso _
                        Or FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrossoDettaglio Then
                            .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaIncendio, 1.45D, 1.2D, 1D, 0.75D) / 1000D
                        ElseIf FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaDettaglio Then
                            .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaIncendio, 1.1D, 0.9D, 0.6D, 0.45D) / 1000D
                        End If
                    ElseIf IncendioScelta = IncendioSceltaEnum.AllRisks Then
                        If FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrosso _
                        Or FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrossoDettaglio Then
                            .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaIncendio, 3.15D, 2.85D, 2.5D, 2.25D) / 1000D
                        ElseIf FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaDettaglio Then
                            .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaIncendio, 2.65D, 2.4D, 2.1D, 1.9D) / 1000D
                        End If
                    End If
                    .Tariffa.Tasso *= 90D
                    IncendioDanniIndirettiSommaAssicurataAttiva = CoperturaIncendioDanniIndirettiA.SommaAssicurataAttiva * 90
                    IncendioDanniIndirettiDiariaPremioAttivo = .PremioAttivoCrudo
                ElseIf IncendioDanniIndirettiScelta = IncendioDanniIndirettiSceltaEnum.SceltaBasicPercentuale Then
                    '20% della sommatoria premi imponibili delle partite: Fabbricato/Rischio Locativo - Contenuto - Aumento periodico Merci - Merci Trasportate - Spese Demolizione e sgombero - Lastre  

                    .Tariffa.Base = 0.2D * (CoperturaIncendioFabbricato.PremioAttivoCrudo _
                                          + CoperturaIncendioLocazione.PremioAttivoCrudo _
                                          + CoperturaIncendioContenuto.PremioAttivoCrudo _
                                          + CoperturaIncendioDemolizione.PremioAttivoCrudo _
                                          + CoperturaIncendioAumentoMerci.PremioAttivoCrudo _
                                          + CoperturaIncendioCoseTrasportate.PremioAttivoCrudo _
                                          + CoperturaIncendioLastre.PremioAttivoCrudo)
                    .Partita.SommaAssicurata = 0.2D * (CoperturaIncendioFabbricato.SommaAssicurataAttiva _
                                          + CoperturaIncendioLocazione.SommaAssicurataAttiva _
                                          + CoperturaIncendioContenuto.SommaAssicurataAttiva _
                                          + CoperturaIncendioDemolizione.SommaAssicurataAttiva _
                                          + CoperturaIncendioAumentoMerci.SommaAssicurataAttiva _
                                          + CoperturaIncendioCoseTrasportate.SommaAssicurataAttiva _
                                          + CoperturaIncendioLastre.SommaAssicurataAttiva)
                    IncendioDanniIndirettiSommaAssicurataAttiva = CoperturaIncendioDanniIndirettiA.SommaAssicurataAttiva
                    IncendioDanniIndirettiPercenPremioAttivo = .PremioAttivoCrudo
                End If
            End With

            '17)
            With CoperturaIncendioDanniIndirettiB
                .Tariffa.Tasso = 5D / 1000D
            End With

            '18)
            With CoperturaIncendioEventiAtmosferici
                .Tariffa.Tasso = 0D
                .Partita.SommaAssicurata = CoperturaIncendioFabbricato.SommaAssicurataAttiva _
                                         + CoperturaIncendioContenuto.SommaAssicurataAttiva _
                                         + CoperturaIncendioDemolizione.SommaAssicurataAttiva _
                                         + CoperturaIncendioAumentoMerci.SommaAssicurataAttiva _
                                         + IncendioDanniIndirettiSommaAssicurataAttiva

                If IncendioEventiAtmosfericiScelta = 0 Then IncendioEventiAtmosfericiScelta = IncendioEventiAtmosfericiSceltaEnum.SceltaBasic
                If ZonaTerritorialeEventiAtmosferici = 0 Then ZonaTerritorialeEventiAtmosferici = ZonaTerritorialeEventiAtmosfericiEnum.ZonaA

                If IncendioScelta = IncendioSceltaEnum.RischiNominati Then
                    If FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrosso _
                    Or FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrossoDettaglio Then
                        If IncendioEventiAtmosfericiScelta = IncendioEventiAtmosfericiSceltaEnum.SceltaBasic Then
                            .Tariffa.Tasso = Choose(ZonaTerritorialeEventiAtmosferici, 0.18D, 0.13D, 0.1D) / 1000D
                        ElseIf IncendioEventiAtmosfericiScelta = IncendioEventiAtmosfericiSceltaEnum.SceltaMedium Then
                            .Tariffa.Tasso = Choose(ZonaTerritorialeEventiAtmosferici, 0.24D, 0.17D, 0.14D) / 1000D
                        ElseIf IncendioEventiAtmosfericiScelta = IncendioEventiAtmosfericiSceltaEnum.SceltaLarge Then
                            .Tariffa.Tasso = Choose(ZonaTerritorialeEventiAtmosferici, 0.42D, 0.3D, 0.24D) / 1000D
                        End If
                    Else
                        If IncendioEventiAtmosfericiScelta = IncendioEventiAtmosfericiSceltaEnum.SceltaBasic Then
                            .Tariffa.Tasso = Choose(ZonaTerritorialeEventiAtmosferici, 0.15D, 0.11D, 0.08D) / 1000D
                        ElseIf IncendioEventiAtmosfericiScelta = IncendioEventiAtmosfericiSceltaEnum.SceltaMedium Then
                            .Tariffa.Tasso = Choose(ZonaTerritorialeEventiAtmosferici, 0.2D, 0.14D, 0.11D) / 1000D
                        ElseIf IncendioEventiAtmosfericiScelta = IncendioEventiAtmosfericiSceltaEnum.SceltaLarge Then
                            .Tariffa.Tasso = Choose(ZonaTerritorialeEventiAtmosferici, 0.35D, 0.25D, 0.19D) / 1000D
                        End If
                    End If

                    If CoperturaIncendioPannelliSolari.IsAttivo() Then
                        If FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrosso _
                        Or FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrossoDettaglio Then
                            If IncendioEventiAtmosfericiScelta = IncendioEventiAtmosfericiSceltaEnum.SceltaMedium Then
                                .Tariffa.Base = CoperturaIncendioPannelliSolari.SommaAssicurataAttiva * Choose(ZonaTerritorialeEventiAtmosferici, 0.24D - 0.18D, 0.17D - 0.13D, 0.14D - 0.1D) / 1000D
                            ElseIf IncendioEventiAtmosfericiScelta = IncendioEventiAtmosfericiSceltaEnum.SceltaLarge Then
                                .Tariffa.Base = CoperturaIncendioPannelliSolari.SommaAssicurataAttiva * Choose(ZonaTerritorialeEventiAtmosferici, 0.42D - 0.18D, 0.3D - 0.13D, 0.24D - 0.1D) / 1000D
                            End If
                        Else
                            If IncendioEventiAtmosfericiScelta = IncendioEventiAtmosfericiSceltaEnum.SceltaMedium Then
                                .Tariffa.Base = CoperturaIncendioPannelliSolari.SommaAssicurataAttiva * Choose(ZonaTerritorialeEventiAtmosferici, 0.2D - 0.15D, 0.14D - 0.11D, 0.11D - 0.08D) / 1000D
                            ElseIf IncendioEventiAtmosfericiScelta = IncendioEventiAtmosfericiSceltaEnum.SceltaLarge Then
                                .Tariffa.Base = CoperturaIncendioPannelliSolari.SommaAssicurataAttiva * Choose(ZonaTerritorialeEventiAtmosferici, 0.35D - 0.15D, 0.25D - 0.11D, 0.19D - 0.08D) / 1000D
                            End If
                        End If
                    End If
                End If
            End With


            '19)
            With CoperturaIncendioGrandineFragili
                .Partita.SommaAssicurata = CoperturaIncendioFabbricato.SommaAssicurataAttiva _
                                         + CoperturaIncendioContenuto.SommaAssicurataAttiva _
                                         + CoperturaIncendioDemolizione.SommaAssicurataAttiva _
                                         + CoperturaIncendioAumentoMerci.SommaAssicurataAttiva _
                                         + CoperturaIncendioPannelliSolari.SommaAssicurataAttiva _
                                         + IncendioDanniIndirettiSommaAssicurataAttiva
                If IncendioScelta = IncendioSceltaEnum.RischiNominati Then
                    .Tariffa.Tasso = 0D / 1000D 'todo
                ElseIf IncendioScelta = IncendioSceltaEnum.AllRisks Then
                    If FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrosso _
                    Or FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrossoDettaglio Then
                        .Tariffa.Tasso = Choose(ZonaTerritorialeEventiAtmosferici, 0.18D, 0.13D, 0.1D) / 1000D
                    Else
                        .Tariffa.Tasso = Choose(ZonaTerritorialeEventiAtmosferici, 0.15D, 0.11D, 0.08D) / 1000D
                    End If
                End If
            End With

            '20)
            With CoperturaIncendioAttiVandaliciDolosi
                .Partita.SommaAssicurata = CoperturaIncendioFabbricato.SommaAssicurataAttiva _
                                         + CoperturaIncendioContenuto.SommaAssicurataAttiva _
                                         + CoperturaIncendioDemolizione.SommaAssicurataAttiva _
                                         + CoperturaIncendioAumentoMerci.SommaAssicurataAttiva _
                                         + IncendioDanniIndirettiSommaAssicurataAttiva

                If FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrosso _
                Or FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrossoDettaglio Then
                    .Tariffa.Tasso = 0.23D / 1000D
                Else
                    .Tariffa.Tasso = 0.2D / 1000D
                End If
            End With

            '21)
            With CoperturaIncendioFabbricatiAperti1
                .Partita.SommaAssicurata = CoperturaIncendioFabbricato.SommaAssicurataAttiva _
                                         + CoperturaIncendioContenuto.SommaAssicurataAttiva _
                                         + CoperturaIncendioDemolizione.SommaAssicurataAttiva _
                                         + CoperturaIncendioAumentoMerci.SommaAssicurataAttiva _
                                         + IncendioDanniIndirettiSommaAssicurataAttiva

                If FabbricatoDestinazione = FabbricatoDestinazioneEnum.Uffici Then
                    If IncendioScelta = IncendioSceltaEnum.RischiNominati Then
                        .Tariffa.Tasso = 0.2D / 1000D '0.25D / 1000D ?errore essig?
                    Else
                        .Tariffa.Tasso = 0.3423D / 1000D '0.30D / 1000D ?errore essig?
                    End If
                ElseIf IncendioScelta = IncendioSceltaEnum.RischiNominati Then
                    .Tariffa.Tasso = 0.25D / 1000D
                Else
                    .Tariffa.Tasso = 0.25D / 1000D '0.3D / 1000D ?errore essig?
                End If
            End With

            '22)
            With CoperturaIncendioFabbricatiAperti2
                .Partita.SommaAssicurata = CoperturaIncendioFabbricato.SommaAssicurataAttiva _
                                         + CoperturaIncendioContenuto.SommaAssicurataAttiva _
                                         + CoperturaIncendioDemolizione.SommaAssicurataAttiva _
                                         + CoperturaIncendioAumentoMerci.SommaAssicurataAttiva _
                                         + IncendioDanniIndirettiSommaAssicurataAttiva

                If FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici Then
                    If IncendioScelta = IncendioSceltaEnum.RischiNominati Then
                        .Tariffa.Tasso = 0.5D / 1000D
                    Else
                        .Tariffa.Tasso = 0.6D / 1000D
                    End If
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            '23)
            With CoperturaIncendioPreziosi
                .Partita.SommaAssicurata = CoperturaIncendioContenuto.Partita.SommaAssicurata
                .Tariffa.Tasso = 0.18D / 1000D
            End With

            '24)
            With CoperturaIncendioSistemiProtezione
                .Tariffa.Base = -0.3D * CoperturaIncendioDanniElettrici.PremioAttivoCrudo
            End With

            '25)
            Dim IncendioCommercioAmbulanteContenutoAumentoMerciPremioAttivo As Decimal = 0D
            Dim IncendioCommercioAmbulanteDanniIndirettiPercenPremioAttivo As Decimal = 0D
            With CoperturaIncendioCommercioAmbulante
                '.Partita.SommaAssicurata = CoperturaIncendioContenuto.SommaAssicurataAttiva _
                '                         + CoperturaIncendioAumentoMerci.SommaAssicurataAttiva '_
                '+ CoperturaIncendioDanniIndirettiA.SommaAssicurataAttiva _
                '+ CoperturaIncendioDanniIndirettiB.SommaAssicurataAttiva


                If FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici Then
                    IncendioCommercioAmbulanteContenutoAumentoMerciPremioAttivo = 0.0006D * CoperturaIncendioContenuto.SommaAssicurataAttiva

                    If IncendioDanniIndirettiScelta = IncendioDanniIndirettiSceltaEnum.SceltaBasicPercentuale Then
                        IncendioCommercioAmbulanteDanniIndirettiPercenPremioAttivo = 0.2D * 0.0006D * CoperturaIncendioContenuto.SommaAssicurataAttiva
                    End If

                    IncendioCommercioAmbulanteContenutoAumentoMerciPremioAttivo *= CoefficienteClasseFabbricato
                    IncendioCommercioAmbulanteDanniIndirettiPercenPremioAttivo *= CoefficienteClasseFabbricato

                    If CoperturaIncendioAumentoMerci.IsAttivo Then
                        IncendioCommercioAmbulanteContenutoAumentoMerciPremioAttivo += 0.0006D * CoperturaIncendioContenuto.SommaAssicurataAttiva * IncendioAumentoMerciMesi / 10D

                        If IncendioDanniIndirettiScelta = IncendioDanniIndirettiSceltaEnum.SceltaBasicPercentuale Then
                            IncendioCommercioAmbulanteDanniIndirettiPercenPremioAttivo += 0.2D * 0.0006D * CoperturaIncendioContenuto.SommaAssicurataAttiva * IncendioAumentoMerciMesi / 10D
                        End If
                    End If
                    .Tariffa.Base = IncendioCommercioAmbulanteContenutoAumentoMerciPremioAttivo + IncendioCommercioAmbulanteDanniIndirettiPercenPremioAttivo
                Else
                    .Tariffa.Base = 0D
                End If
            End With

            '26)
            With CoperturaIncendioFranchigia
                If .Garanzia.Franchigia = 0 Then .Garanzia.Franchigia = 1500D

                If .Garanzia.Franchigia = 1500D Then
                    .Tariffa.Tasso = -0.2D
                ElseIf .Garanzia.Franchigia = 2500D Then
                    .Tariffa.Tasso = -0.3D
                ElseIf .Garanzia.Franchigia = 20000D Then
                    .Tariffa.Tasso = -0.5D
                Else
                    .Tariffa.Tasso = 0D
                End If


                'REMEBER: IL TASSO E' NEGATIVO
                .Partita.SommaAssicurata _
                = CoperturaIncendioFabbricato.PremioAttivoCrudo / CoefficienteClasseFabbricato _
                + CoperturaIncendioContenuto.PremioAttivoCrudo / CoefficienteClasseFabbricato _
                + CoperturaIncendioLocazione.PremioAttivoCrudo / CoefficienteClasseFabbricato _
                + CoperturaIncendioCondutture.PremioAttivoCrudo / CoefficienteClasseFabbricato _
                + CoperturaIncendioDemolizione.PremioAttivoCrudo / CoefficienteClasseFabbricato _
                + CoperturaIncendioEventiAtmosferici.PremioAttivoCrudo _
                + IncendioDanniIndirettiPercenPremioAttivo * (2D + .Tariffa.Tasso) _
                + IncendioDanniIndirettiDiariaPremioAttivo _
                + CoperturaIncendioDanniIndirettiB.PremioAttivoCrudo _
                + CoperturaIncendioRicorsoTerzi.PremioAttivoCrudo _
                + CoperturaIncendioAumentoMerci.PremioAttivoCrudo _
                + CoperturaIncendioCoseTrasportate.PremioAttivoCrudo _
                + CoperturaIncendioRefrigerati1.PremioAttivoCrudo _
                + CoperturaIncendioRefrigerati2.PremioAttivoCrudo _
                + CoperturaIncendioLastre.PremioAttivoCrudo _
                + CoperturaIncendioPannelliSolari.PremioAttivoCrudo _
                + CoperturaIncendioRicetteMediche.PremioAttivoCrudo _
                + CoperturaIncendioSpeseAccessorie.PremioAttivoCrudo _
                + CoperturaIncendioGrandineFragili.PremioAttivoCrudo _
                + CoperturaIncendioAttiVandaliciDolosi.PremioAttivoCrudo _
                + CoperturaIncendioFabbricatiAperti1.PremioAttivoCrudo _
                + CoperturaIncendioFabbricatiAperti2.PremioAttivoCrudo _
                + CoperturaIncendioPreziosi.PremioAttivoCrudo _
                + CoperturaIncendioSistemiProtezione.PremioAttivoCrudo * 0 _
                + CoperturaIncendioDanniElettrici.PremioAttivoCrudo

                If CoperturaIncendioCommercioAmbulante.IsAttivo Then
                    .Partita.SommaAssicurata += IncendioCommercioAmbulanteContenutoAumentoMerciPremioAttivo
                    .Partita.SommaAssicurata += IncendioCommercioAmbulanteDanniIndirettiPercenPremioAttivo * (2D + .Tariffa.Tasso)
                End If
                'If IncendioDanniElettriciScelta = IncendioDanniElettriciSceltaEnum.SceltaBasic Then
                '    '.Partita.SommaAssicurata -= CoperturaIncendioDanniElettrici.PremioAttivoCrudo
                'Else
                '    .Partita.SommaAssicurata += CoperturaIncendioDanniElettrici.PremioAttivoCrudo
                'End If

                '- CoperturaIncendioDanniElettrici.PremioAttivoCrudo _
                '+ CoperturaIncendioDanniIndirettiA.PremioAttivoCrudo  * (2D - .Tariffa.Tasso) 

                If .IsAttivo Then
                    If CoperturaIncendioFabbricato.IsAttivo And PartitaIncendioFabbricato.SommaAssicurata < .Garanzia.Franchigia Then
                        .SetNonDisponibile("Partita fabbricato minore della franchigia")
                    ElseIf CoperturaIncendioContenuto.IsAttivo And PartitaIncendioContenuto.SommaAssicurata < .Garanzia.Franchigia Then
                        .SetNonDisponibile("Partita contenuto minore della franchigia")
                    ElseIf CoperturaIncendioLocazione.IsAttivo And PartitaIncendioLocazione.SommaAssicurata < .Garanzia.Franchigia Then
                        .SetNonDisponibile("Partita rischio locativo minore della franchigia")
                    ElseIf CoperturaIncendioCondutture.IsAttivo And PartitaIncendioCondutture.SommaAssicurata < .Garanzia.Franchigia Then
                        .SetNonDisponibile("Spese ricerca e riparazione condutture minore della franchigia")
                    ElseIf CoperturaIncendioDemolizione.IsAttivo And PartitaIncendioDemolizione.SommaAssicurata < .Garanzia.Franchigia Then
                        .SetNonDisponibile("Spese di demolizione, sgombero, ecc minore della franchigia")
                    ElseIf CoperturaIncendioLastre.IsAttivo And PartitaIncendioLastre.SommaAssicurata < .Garanzia.Franchigia Then
                        .SetNonDisponibile("Partita lastre minore della franchigia")
                    ElseIf CoperturaIncendioDanniElettrici.IsAttivo And PartitaIncendioDanniElettrici.SommaAssicurata < .Garanzia.Franchigia Then
                        .SetNonDisponibile("Partita danni elettrici minore della franchigia")
                    ElseIf CoperturaIncendioRicorsoTerzi.IsAttivo And PartitaIncendioRicorsoTerzi.SommaAssicurata < .Garanzia.Franchigia Then
                        .SetNonDisponibile("Partita ricorso terzi minore della franchigia")
                    ElseIf CoperturaIncendioAumentoMerci.IsAttivo And PartitaIncendioAumentoMerci.SommaAssicurata < .Garanzia.Franchigia Then
                        .SetNonDisponibile("Aumento periodico merci minore della franchigia")
                    ElseIf CoperturaIncendioCoseTrasportate.IsAttivo And PartitaIncendioCoseTrasportate.SommaAssicurata < .Garanzia.Franchigia Then
                        .SetNonDisponibile("Merci e attrezzature trasportate minore della franchigia")
                    ElseIf CoperturaIncendioRefrigerati1.IsAttivo And PartitaIncendioRefrigerati1.SommaAssicurata < .Garanzia.Franchigia Then
                        .SetNonDisponibile("Partita merci in refrigerazione minore della franchigia")
                    ElseIf CoperturaIncendioPannelliSolari.IsAttivo And PartitaIncendioPannelliSolari.SommaAssicurata < .Garanzia.Franchigia Then
                        .SetNonDisponibile("Partita pannelli solari minore della franchigia")
                        'ElseIf CoperturaIncendioSpeseAccessorie.IsAttivo And PartitaIncendioSpeseAccessorie.SommaAssicurata < .Garanzia.Franchigia Then
                        '    .SetNonDisponibile("Partita spese accessorie minore della franchigia")
                    ElseIf CoperturaIncendioDanniIndirettiB.IsAttivo And PartitaIncendioDanniIndirettiB.SommaAssicurata < .Garanzia.Franchigia Then
                        .SetNonDisponibile("Partita maggiori costi minore della franchigia")
                    End If
                End If
            End With

            Return True
        End Function

        Public Function ValidaSezioneFurto() As Boolean
            CoperturaFurtoBase.DipendeDa(Not YouCommercio.SoloProprieta)
            CoperturaFurto.Stato = CoperturaFurtoBase.Stato

            CoperturaFurtoContenuto.DipendeDa(CoperturaFurtoBase.IsAttivo)
            CoperturaFurtoFissi.ObbligatoriaDa(CoperturaFurtoContenuto.IsAttivo)
            CoperturaFurtoValori.ObbligatoriaDa(CoperturaFurtoContenuto.IsAttivo)
            CoperturaFurtoRapina.ObbligatoriaDa(CoperturaFurtoContenuto.IsAttivo)

            CoperturaFurtoVetrinette.DipendeDa(CoperturaFurtoContenuto.IsAttivo And FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaDettaglio)
            CoperturaFurtoPortavalori.DipendeDa(CoperturaFurtoContenuto.IsAttivo)
            CoperturaFurtoAumentoMerci.DipendeDa(CoperturaFurtoContenuto.IsAttivo And FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici)
            CoperturaFurtoMerciTrasportate.DipendeDa(CoperturaFurtoContenuto.IsAttivo And FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici)
            CoperturaFurtoMerciAperto.DipendeDa(CoperturaFurtoContenuto.IsAttivo And FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici And YouCommercio.ClasseRischioAttivitaFurto <> ClasseRischioAttivitaFurtoEnum.A2)
            CoperturaFurtoDistributoriEsterni.DipendeDa(CoperturaFurtoContenuto.IsAttivo And FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaDettaglio)
            CoperturaFurtoDistributoriCarburante.DipendeDa(CoperturaFurtoContenuto.IsAttivo And IsOneOf(YouCommercio.CodiceAttivita1, 951, 952))
            CoperturaFurtoRicetteMediche.DipendeDa(CoperturaFurtoContenuto.IsAttivo And YouCommercio.CodiceAttivita1 = 754)
            CoperturaFurtoDipendenti.DipendeDa(CoperturaFurtoContenuto.IsAttivo)
            CoperturaFurtoSpeseAccessorie.DipendeDa(CoperturaFurtoContenuto.IsAttivo)
            CoperturaFurtoSpeseMiglioramento.DipendeDa(CoperturaFurtoContenuto.IsAttivo)
            CoperturaFurtoSlotMachine.DipendeDa(CoperturaFurtoContenuto.IsAttivo And FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici)
            CoperturaFurtoReintegroAutomatico.DipendeDa(CoperturaFurtoContenuto.IsAttivo And YouCommercio.ClasseRischioAttivitaFurto <> ClasseRischioAttivitaFurtoEnum.A2)
            CoperturaFurtoCommercioAmbulante.DipendeDa(CoperturaFurtoContenuto.IsAttivo And FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici)
            CoperturaFurtoDepositoRiserva.DipendeDa(CoperturaFurtoContenuto.IsAttivo And FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici)
            CoperturaFurtoDerogaCostruttive.DipendeDa(CoperturaFurtoContenuto.IsAttivo And YouCommercio.ClasseRischioAttivitaFurto <> ClasseRischioAttivitaFurtoEnum.A2)
            CoperturaFurtoMezziChiusura.DipendeDa(CoperturaFurtoContenuto.IsAttivo)
            CoperturaFurtoImpiantoAllarme.DipendeDa(CoperturaFurtoContenuto.IsAttivo)
            CoperturaFurtoAllarmeDistanza.DipendeDa(CoperturaFurtoContenuto.IsAttivo)
            CoperturaFurtoAllarmeDoppio.DipendeDa(CoperturaFurtoContenuto.IsAttivo)
            CoperturaFurtoVideoSorveglianza.DipendeDa(CoperturaFurtoContenuto.IsAttivo And (CoperturaFurtoAllarmeDistanza.IsAttivo Or CoperturaFurtoAllarmeDoppio.IsAttivo))
            CoperturaFurtoScopertoMerciA.DipendeDa(CoperturaFurtoContenuto.IsAttivo And FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici And YouCommercio.ClasseRischioAttivitaFurto = ClasseRischioAttivitaFurtoEnum.A2)
            CoperturaFurtoScopertoMerciB.DipendeDa(CoperturaFurtoContenuto.IsAttivo And FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici And YouCommercio.ClasseRischioAttivitaFurto <> ClasseRischioAttivitaFurtoEnum.A2)
            CoperturaFurtoPiuEsercizi.Stato = YouCommercio.CoperturaFurtoPiuEsercizi.Stato

            'Limiti assuntivi
            Dim LimitiAssuntiviMax As Decimal

            If CoperturaFurtoVideoSorveglianza.IsAttivo Or CoperturaFurtoAllarmeDoppio.IsAttivo Or CoperturaFurtoAllarmeDistanza.IsAttivo Then
                If YouCommercio.ClasseRischioAttivitaFurto = ClasseRischioAttivitaFurtoEnum.A2 Then
                    LimitiAssuntiviMax = 90000D
                Else
                    LimitiAssuntiviMax = 120000D
                End If
            ElseIf CoperturaFurtoImpiantoAllarme.IsAttivo Or CoperturaFurtoMezziChiusura.IsAttivo Then
                If YouCommercio.ClasseRischioAttivitaFurto = ClasseRischioAttivitaFurtoEnum.A2 Then
                    LimitiAssuntiviMax = 75000D
                Else
                    LimitiAssuntiviMax = 90000D
                End If
            Else
                If YouCommercio.ClasseRischioAttivitaFurto = ClasseRischioAttivitaFurtoEnum.A2 Then
                    LimitiAssuntiviMax = 45000D
                Else
                    LimitiAssuntiviMax = 75000D
                End If
            End If

            PartitaFurtoContenuto.LimitiAssuntivi(0D, LimitiAssuntiviMax)
            PartitaFurtoAumentoMerci.LimitiAssuntivi(0D, LimitiAssuntiviMax - PartitaFurtoContenuto.SommaAssicurata)
            PartitaFurtoMerciAperto.LimitiAssuntivi(0D, LimitiAssuntiviMax - PartitaFurtoContenuto.SommaAssicurata - PartitaFurtoAumentoMerci.SommaAssicurata)
            If FurtoFissiScelta = FurtoFissiSceltaEnum.SceltaA Then
                PartitaFurtoFissi.SommaAssicurata = 2000D
            Else
                PartitaFurtoFissi.LimitiAssuntivi(2000D, 4000D)
            End If
            If FurtoValoriScelta = FurtoValoriSceltaEnum.SceltaA Then
                PartitaFurtoValori.SommaAssicurata = 0.1D * PartitaFurtoContenuto.SommaAssicurata
                PartitaFurtoValori.LimitiAssuntivi(0.1D * PartitaFurtoContenuto.SommaAssicurata, 2000D)
            Else
                PartitaFurtoValori.LimitiAssuntivi(2000D, 12000D)
            End If
            If FurtoRapinaScelta = FurtoRapinaSceltaEnum.SceltaA Then
                PartitaFurtoRapina.SommaAssicurata = 0.1D * PartitaFurtoContenuto.SommaAssicurata
                PartitaFurtoRapina.LimitiAssuntivi(0.1D * PartitaFurtoContenuto.SommaAssicurata, 2000D)
            Else
                PartitaFurtoRapina.LimitiAssuntivi(2000D, 10000D)
            End If
            PartitaFurtoDipendenti.LimitiAssuntivi(0D, 10000D)
            PartitaFurtoAumentoMerci.LimitiAssuntivi(0D, 2D * PartitaFurtoContenuto.SommaAssicurata)
            PartitaFurtoPortavalori.LimitiAssuntivi(0D, 10000D)
            PartitaFurtoDistributoriCarburante.LimitiAssuntivi(0D, 2000D)
            PartitaFurtoMerciTrasportate.LimitiAssuntivi(0D, 10000D)
            PartitaFurtoRicetteMediche.LimitiAssuntivi(0D, 10000D)
            PartitaFurtoMerciAperto.LimitiAssuntivi(0D, 0.5D * PartitaFurtoContenuto.SommaAssicurata)
            PartitaFurtoMerciAperto.LimitiAssuntivi(0D, 30000D)
            PartitaFurtoDistributoriEsterni.LimitiAssuntivi(500D, 20000D)
            PartitaFurtoVetrinette.LimitiAssuntivi(0D, 2000D)
            PartitaFurtoSlotMachine.LimitiAssuntivi(0D, 5000D)

            With CoperturaFurtoContenuto
                .Tariffa.Tasso = 0D

                If FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrosso _
                Or FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrossoDettaglio Then
                    If ZonaTerritorialeFurto = ZonaTerritorialeFurtoEnum.Zona12 Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaFurto, 117D, 87D, 69D, 50D, 35D, 28D) / 1000D
                    ElseIf ZonaTerritorialeFurto = ZonaTerritorialeFurtoEnum.Zona21 Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaFurto, 104D, 77D, 60D, 44D, 29D, 24D) / 1000D
                    ElseIf ZonaTerritorialeFurto = ZonaTerritorialeFurtoEnum.Zona22 Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaFurto, 90D, 66D, 51D, 39D, 25D, 20D) / 1000D
                    ElseIf ZonaTerritorialeFurto = ZonaTerritorialeFurtoEnum.Zona31 Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaFurto, 73D, 53D, 40D, 31D, 23D, 18D) / 1000D
                    ElseIf ZonaTerritorialeFurto = ZonaTerritorialeFurtoEnum.Zona32 Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaFurto, 56D, 40D, 30D, 22D, 18D, 15D) / 1000D
                    ElseIf ZonaTerritorialeFurto = ZonaTerritorialeFurtoEnum.Zona41 Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaFurto, 48D, 32D, 26D, 18D, 14D, 12D) / 1000D
                    End If
                ElseIf FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaDettaglio Then
                    If ZonaTerritorialeFurto = ZonaTerritorialeFurtoEnum.Zona12 Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaFurto, 111D, 83D, 66D, 48D, 33D, 27D) / 1000D
                    ElseIf ZonaTerritorialeFurto = ZonaTerritorialeFurtoEnum.Zona21 Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaFurto, 99D, 73D, 57D, 42D, 28D, 23D) / 1000D
                    ElseIf ZonaTerritorialeFurto = ZonaTerritorialeFurtoEnum.Zona22 Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaFurto, 86D, 62D, 49D, 37D, 24D, 19D) / 1000D
                    ElseIf ZonaTerritorialeFurto = ZonaTerritorialeFurtoEnum.Zona31 Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaFurto, 70D, 50D, 38D, 29D, 22D, 17D) / 1000D
                    ElseIf ZonaTerritorialeFurto = ZonaTerritorialeFurtoEnum.Zona32 Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaFurto, 54D, 38D, 28D, 21D, 17D, 14D) / 1000D
                    ElseIf ZonaTerritorialeFurto = ZonaTerritorialeFurtoEnum.Zona41 Then
                        .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaFurto, 45D, 31D, 24D, 17D, 13D, 11D) / 1000D
                    End If
                ElseIf FabbricatoDestinazione = FabbricatoDestinazioneEnum.Uffici Then
                    If ZonaTerritorialeFurto = ZonaTerritorialeFurtoEnum.Zona12 Then
                        .Tariffa.Tasso = 40.5D / 1000D
                    ElseIf ZonaTerritorialeFurto = ZonaTerritorialeFurtoEnum.Zona21 Then
                        .Tariffa.Tasso = 37.8D / 1000D
                    ElseIf ZonaTerritorialeFurto = ZonaTerritorialeFurtoEnum.Zona22 Then
                        .Tariffa.Tasso = 33.3D / 1000D
                    ElseIf ZonaTerritorialeFurto = ZonaTerritorialeFurtoEnum.Zona31 Then
                        .Tariffa.Tasso = 26.1D / 1000D
                    ElseIf ZonaTerritorialeFurto = ZonaTerritorialeFurtoEnum.Zona32 Then
                        .Tariffa.Tasso = 18.9D / 1000D
                    ElseIf ZonaTerritorialeFurto = ZonaTerritorialeFurtoEnum.Zona41 Then
                        .Tariffa.Tasso = 13D / 1000D
                    End If
                End If

                If FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrosso _
                Or FabbricatoDestinazione = FabbricatoDestinazioneEnum.VenditaIngrossoDettaglio Then
                    If .Partita.SommaAssicurata < 21000D Then
                        .Tariffa.Tasso *= 1D
                    ElseIf .Partita.SommaAssicurata < 31000D Then
                        .Tariffa.Tasso *= 0.95D
                    ElseIf .Partita.SommaAssicurata < 41000D Then
                        .Tariffa.Tasso *= 0.92D
                    Else
                        .Tariffa.Tasso *= 0.9D
                    End If
                Else
                    If .Partita.SommaAssicurata < 11000D Then
                        .Tariffa.Tasso *= 1D
                    ElseIf .Partita.SommaAssicurata < 21000D Then
                        .Tariffa.Tasso *= 0.95D
                    ElseIf .Partita.SommaAssicurata < 31000D Then
                        .Tariffa.Tasso *= 0.92D
                    Else
                        .Tariffa.Tasso *= 0.9D
                    End If
                End If
            End With

            With CoperturaFurtoFissi
                If .Partita.SommaAssicurata <= 2000 Then
                    .Tariffa.Base = 12.2D
                Else
                    .Tariffa.Base = 12.2D - 2000D * 36.5D / 1000D
                    .Tariffa.Tasso = 36.5D / 1000D
                End If
            End With

            With CoperturaFurtoValori
                'If FurtoValoriScelta = FurtoValoriSceltaEnum.SceltaA Then
                '    .Tariffa.Tasso = 18.3D / 1000D
                'ElseIf FurtoValoriScelta = FurtoValoriSceltaEnum.SceltaB Then
                .Tariffa.Tasso = 22D / 1000D
                'Else
                '    .Tariffa.Tasso = 0D
                'End If
            End With

            With CoperturaFurtoRapina
                .Tariffa.Tasso = 18.3D / 1000D
            End With

            With CoperturaFurtoVetrinette
                If FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici Then
                    .Tariffa.Tasso = 1.2D * CoperturaFurtoContenuto.Tariffa.Tasso
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            With CoperturaFurtoPortavalori
                .Tariffa.Tasso = 29.3D / 1000D
            End With

            With CoperturaFurtoAumentoMerci
                If FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici Then
                    .RischioDirezione = (IncendioAumentoMerciMesi > 6)
                    .DescrizioneRD = "Oltre 6 mesi la garanzia è Riservata Direzione"
                    'Tasso = Numero Mesi X Tasso Mensile 1/10 del tasso Contenuto
                    .Tariffa.Tasso = FurtoAumentoMerciMesi * CoperturaFurtoContenuto.Tariffa.Tasso / 10D
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            With CoperturaFurtoMerciTrasportate
                If FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici Then
                    .Tariffa.Tasso = CoperturaFurtoContenuto.Tariffa.Tasso
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            With CoperturaFurtoMerciAperto
                If FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici Then
                    .Tariffa.Tasso = 1.25D * CoperturaFurtoContenuto.Tariffa.Tasso
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            With CoperturaFurtoDistributoriEsterni
                If FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici Then
                    .Tariffa.Tasso = 36.5D / 1000D
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            With CoperturaFurtoDistributoriCarburante
                If FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici Then
                    .Tariffa.Tasso = 73.5D / 1000D
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            With CoperturaFurtoRicetteMediche
                If FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici Then
                    .Tariffa.Tasso = 36.5D / 1000D
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            With CoperturaFurtoDipendenti
                .Tariffa.Tasso = 24.5D / 1000D
            End With

            With CoperturaFurtoSpeseAccessorie
                .Tariffa.Base = 0.15D * CoperturaFurtoContenuto.PremioAttivoCrudo
            End With

            With CoperturaFurtoCommercioAmbulante
                .Partita.SommaAssicurata = CoperturaFurtoContenuto.PremioAttivoCrudo _
                                         + CoperturaFurtoAumentoMerci.PremioAttivoCrudo _
                                         + CoperturaFurtoSpeseAccessorie.PremioAttivoCrudo
                If FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici Then
                    .Tariffa.Tasso = 0.5D
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            With CoperturaFurtoDerogaCostruttive
                .Tariffa.Base = 0.2D * (CoperturaFurtoContenuto.PremioAttivoCrudo + CoperturaFurtoSpeseAccessorie.PremioAttivoCrudo)
            End With

            With CoperturaFurtoReintegroAutomatico
                .Tariffa.Base = 0.1D * (CoperturaFurtoContenuto.PremioAttivoCrudo _
                                        + CoperturaFurtoSpeseAccessorie.PremioAttivoCrudo)
            End With

            With CoperturaFurtoSpeseMiglioramento
                .Tariffa.Base = 34D
            End With

            With CoperturaFurtoSlotMachine
                If FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici Then
                    .Tariffa.Tasso = 110D / 1000D
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            With CoperturaFurtoDepositoRiserva
                .Partita.SommaAssicurata = CoperturaFurtoCommercioAmbulante.Partita.SommaAssicurata
                If FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici Then
                    .Tariffa.Tasso = 0.2D
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            With CoperturaFurtoScopertoMerciA
                .Partita.SommaAssicurata = CoperturaFurtoContenuto.PremioAttivoCrudo _
                                         + CoperturaFurtoAumentoMerci.PremioAttivoCrudo _
                                         + CoperturaFurtoSpeseAccessorie.PremioAttivoCrudo
                If FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici Then
                    .Tariffa.Tasso = 0.3D
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            With CoperturaFurtoScopertoMerciB
                .Partita.SommaAssicurata = CoperturaFurtoContenuto.PremioAttivoCrudo _
                                         + CoperturaFurtoAumentoMerci.PremioAttivoCrudo _
                                         + CoperturaFurtoSpeseAccessorie.PremioAttivoCrudo
                If FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici Then
                    .Tariffa.Tasso = -0.2D
                Else
                    .Tariffa.Tasso = 0D
                End If
            End With

            With CoperturaFurtoMezziChiusura
                .Tariffa.Tasso = -0.2D
                If FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici Then
                    .Partita.SommaAssicurata = CoperturaFurtoContenuto.PremioAttivoCrudo _
                                             + CoperturaFurtoValori.PremioAttivoCrudo _
                                             + CoperturaFurtoRicetteMediche.PremioAttivoCrudo _
                                             + CoperturaFurtoAumentoMerci.PremioAttivoCrudo _
                                             + CoperturaFurtoSlotMachine.PremioAttivoCrudo
                Else
                    .Partita.SommaAssicurata = CoperturaFurtoContenuto.PremioAttivoCrudo + CoperturaFurtoValori.PremioAttivoCrudo
                End If
            End With

            With CoperturaFurtoImpiantoAllarme
                .Tariffa.Tasso = -0.1D
            End With

            With CoperturaFurtoAllarmeDistanza
                .Tariffa.Tasso = -0.2D
            End With

            With CoperturaFurtoAllarmeDoppio
                .Tariffa.Tasso = -0.25D
            End With

            With CoperturaFurtoVideoSorveglianza
                .Tariffa.Tasso = -0.3D
            End With

            With CoperturaFurtoPiuEsercizi
                .Tariffa.Tasso = YouCommercio.CoperturaFurtoPiuEsercizi.Tariffa.Tasso
                .Partita.SommaAssicurata _
                        = CoperturaFurtoContenuto.PremioAttivoCrudo _
                        + CoperturaFurtoFissi.PremioAttivoCrudo _
                        + CoperturaFurtoValori.PremioAttivoCrudo _
                        + CoperturaFurtoRapina.PremioAttivoCrudo _
                        + CoperturaFurtoVetrinette.PremioAttivoCrudo _
                        + CoperturaFurtoPortavalori.PremioAttivoCrudo _
                        + CoperturaFurtoAumentoMerci.PremioAttivoCrudo _
                        + CoperturaFurtoMerciTrasportate.PremioAttivoCrudo _
                        + CoperturaFurtoMerciAperto.PremioAttivoCrudo _
                        + CoperturaFurtoDistributoriEsterni.PremioAttivoCrudo _
                        + CoperturaFurtoDistributoriCarburante.PremioAttivoCrudo _
                        + CoperturaFurtoRicetteMediche.PremioAttivoCrudo _
                        + CoperturaFurtoDipendenti.PremioAttivoCrudo _
                        + CoperturaFurtoSpeseAccessorie.PremioAttivoCrudo _
                        + CoperturaFurtoSpeseMiglioramento.PremioAttivoCrudo _
                        + CoperturaFurtoSlotMachine.PremioAttivoCrudo _
                        + CoperturaFurtoReintegroAutomatico.PremioAttivoCrudo _
                        + CoperturaFurtoCommercioAmbulante.PremioAttivoCrudo _
                        + CoperturaFurtoDepositoRiserva.PremioAttivoCrudo _
                        + CoperturaFurtoDerogaCostruttive.PremioAttivoCrudo _
                        + CoperturaFurtoMezziChiusura.PremioAttivoCrudo _
                        + CoperturaFurtoImpiantoAllarme.PremioAttivoCrudo _
                        + CoperturaFurtoAllarmeDistanza.PremioAttivoCrudo _
                        + CoperturaFurtoAllarmeDoppio.PremioAttivoCrudo _
                        + CoperturaFurtoVideoSorveglianza.PremioAttivoCrudo _
                        + CoperturaFurtoScopertoMerciA.PremioAttivoCrudo _
                        + CoperturaFurtoScopertoMerciB.PremioAttivoCrudo
            End With

            Return True
        End Function

        Public Sub ValidaSezioneTerremoto()
            CoperturaTerremotoBase.DipendeDa(CoperturaIncendioBase.IsAttivo And YouCommercio.Frazionamento <> FrazionamentiEnum.UnicoAnticipato)
            CoperturaTerremoto.Stato = CoperturaTerremotoBase.Stato

            CoperturaTerremotoFabbricato.DipendeDa(CoperturaTerremotoBase.IsAttivo)
            CoperturaTerremotoContenuto.DipendeDa(CoperturaTerremotoBase.IsAttivo)
            CoperturaTerremotoDemolizione.DipendeDa(CoperturaTerremotoFabbricato.IsAttivo Or CoperturaTerremotoContenuto.IsAttivo)
            CoperturaTerremotoAumentoMerci.DipendeDa(CoperturaTerremotoContenuto.IsAttivo And Not YouCommercio.SoloProprieta And FabbricatoDestinazione <> FabbricatoDestinazioneEnum.Uffici)
            CoperturaTerremotoRicetteMediche.DipendeDa(CoperturaTerremotoContenuto.IsAttivo And Not YouCommercio.SoloProprieta And YouCommercio.CodiceAttivita1 = 754)

            If CaratteristicaCostruttiva = 0 Then CaratteristicaCostruttiva = CaratteristicaCostruttivaEnum.Antisismica
            If TipologiaFabbricato = 0 Then TipologiaFabbricato = TipologiaFabbricatoEnum.TipologiaB

            If TipologiaFabbricato = TipologiaFabbricatoEnum.TipologiaB Then
                If CaratteristicaCostruttiva <> CaratteristicaCostruttivaEnum.Antisismica _
                And comuneMinorRischioSismico = False Then
                    CoperturaTerremotoBase.SetRischioDirezione("RD: Fabbricati produttivo non antisismico in comune a rischio terremoto")
                End If
            End If

            ' trovo massimale
            Select Case CoperturaIncendioFabbricato.SommaAssicurataAttiva _
                      + CoperturaIncendioContenuto.SommaAssicurataAttiva _
                      + CoperturaIncendioDemolizione.MassimaleAttivo _
                      + CoperturaIncendioAumentoMerci.SommaAssicurataAttiva _
                      + CoperturaIncendioRicetteMediche.SommaAssicurataAttiva
                Case Is <= 1000000
                    CoperturaTerremotoFabbricato.Garanzia.Franchigia = 10000
                Case Is <= 3000000
                    CoperturaTerremotoFabbricato.Garanzia.Franchigia = 30000
                Case Else
                    CoperturaTerremotoFabbricato.Garanzia.Franchigia = 50000
            End Select

            With CoperturaTerremotoFabbricato
                If .Garanzia.Limite = 0 Then .Garanzia.Limite = 30
                .Partita.SommaAssicurata = CoperturaIncendioFabbricato.SommaAssicurataAttiva
                .Tariffa.Tasso = YouCommercio.Tabelle.getTassoTerremoto(Comune, .Garanzia.Franchigia, .Garanzia.Limite, CaratteristicaCostruttiva)
            End With

            With CoperturaTerremotoContenuto
                .Partita.SommaAssicurata = CoperturaIncendioContenuto.SommaAssicurataAttiva
                .Tariffa.Tasso = Choose(YouCommercio.ClasseRischioAttivitaTerremoto, 1.1D, 1.05D, 1D) * CoperturaTerremotoFabbricato.Tariffa.Tasso
            End With

            With CoperturaTerremotoDemolizione
                .Garanzia.Massimale = CoperturaIncendioDemolizione.Garanzia.Massimale
                .Partita.SommaAssicurata = .Garanzia.Massimale

                If .Garanzia.Massimale = 10000D Then
                    .Tariffa.Base = 24D
                ElseIf .Garanzia.Massimale = 30000D Then
                    .Tariffa.Base = 70D
                ElseIf .Garanzia.Massimale = 50000D Then
                    .Tariffa.Base = 110D
                ElseIf .Garanzia.Massimale = 100000D Then
                    .Tariffa.Base = 200D
                ElseIf .Garanzia.Massimale = 200000D Then
                    .Tariffa.Base = 350D
                Else
                    .Tariffa.Base = 0D
                End If

                .RischioDirezione = (.Tariffa.Base = 0D)
                .DescrizioneRD = "Spese di demolizione e sgombero oltre 200.000€"
            End With

            With CoperturaTerremotoAumentoMerci
                .Partita.SommaAssicurata = CoperturaIncendioAumentoMerci.SommaAssicurataAttiva
                TerremotoAumentoMerciMesi = IncendioAumentoMerciMesi
                .Tariffa.Tasso = TerremotoAumentoMerciMesi * CoperturaTerremotoContenuto.Tariffa.Tasso / 10D
            End With

            With CoperturaTerremotoRicetteMediche
                .Partita.SommaAssicurata = CoperturaIncendioRicetteMediche.SommaAssicurataAttiva
                .Tariffa.Tasso = CoperturaTerremotoContenuto.Tariffa.Tasso
            End With
        End Sub

    End Class
End Namespace
