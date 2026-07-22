Namespace P07261
    <Serializable()> Public Class Abitazione

        Public youCasa As youCasa

        Public TipoAbitazione As TipoAbitazioneEnum
        Public ClasseTerritorialeFurto As ClasseTerritorialeFurtoEnum
        Public ZonaTerritorialeEventiAtmosferici As ZonaTerritorialeEventiAtmosfericiEnum
        Public IncendioAbitazioneFormAss As IncendioAbitazioneFormAssEnum
        Public IncendioContenutoFormAss As IncendioContenutoFormAssEnum
        Public IncendioLocazioneFormAss As IncendioLocazioneFormAssEnum
        Public CaratteristicaCostruttiva As CaratteristicaCostruttivaEnum
        Public FurtoEsternoScelta As FurtoEsternoSceltaEnum
        Public FurtoEsternoPlatinoScelta As FurtoEsternoPlatinoSceltaEnum
        Public FurtoInCassaforteScelta As FurtoInCassaforteSceltaEnum
        Public FurtoPreziosiValoriScelta As FurtoPreziosiValoriSceltaEnum
        Public FurtoValoriDimoraAbitualeDenaro As FurtoValoriDimoraAbitualeDenaroEnum
        Public FurtoValoriDimoraAbitualeValori As FurtoValoriDimoraAbitualeValoriEnum
        Public Provincia As ProvinciaEnum
        Public Comune As Integer
        Public Indirizzo As String
        Public NumeroCivico As String
        Public Descrizione As String
        Public FurtoContenutoFormaAssicurazione As FormaAssicurazioneEnum
        Public TipoDimora As TipoDimoraEnum
        Public PianoAbitazione As PianoAbitazioneEnum

        'Incendio
        Public CoperturaIncendio As New CoperturaComposta()
        Public PartitaIncendioBase As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioBase As New CoperturaSingola(PartitaIncendioBase, New Garanzia(TipoGaranzia.IncendioBase))
        Public PartitaIncendioAbitazione As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioAbitazione As New CoperturaSingola(PartitaIncendioAbitazione, New Garanzia(TipoGaranzia.IncendioAbitazione), True)
        Public PartitaIncendioContenuto As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioContenuto As New CoperturaSingola(PartitaIncendioContenuto, New Garanzia(TipoGaranzia.IncendioContenuto), True)
        Public PartitaIncendioLocazione As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioLocazione As New CoperturaSingola(PartitaIncendioLocazione, New Garanzia(TipoGaranzia.IncendioLocazione), True)
        Public PartitaIncendioCondutture As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioCondutture As New CoperturaSingola(PartitaIncendioCondutture, New Garanzia(TipoGaranzia.IncendioAcquaCondotta))
        Public PartitaIncendioFenomeniElettrici As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioFenomeniElettrici As New CoperturaSingola(PartitaIncendioFenomeniElettrici, New Garanzia(TipoGaranzia.IncendioFenomeniElettrici), True)
        'Public PartitaIncendioFenomeniAtmosferici As New Partita(TipoPartita.Incendio)
        'correzione del 25/05/2016
        Public PartitaIncendioAbitazioneContenuto As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioFenomeniAtmosferici As New CoperturaSingola(PartitaIncendioAbitazioneContenuto, New Garanzia(TipoGaranzia.IncendioFenomeniAtmosferici))
        Public PartitaIncendioFenomeniAtmosfericiLarge As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioFenomeniAtmosfericiLarge As New CoperturaSingola(PartitaIncendioFenomeniAtmosfericiLarge, New Garanzia(TipoGaranzia.IncendioFenomeniAtmosfericiLarge))
        Public PartitaIncendioRicorsoTerzi As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioRicorsoTerzi As New CoperturaSingola(PartitaIncendioRicorsoTerzi, New Garanzia(TipoGaranzia.IncendioRicorsoTerzi), True)
        'Public PartitaIncendioDemolizione As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioDemolizione As New CoperturaSingola(PartitaIncendioBase, New Garanzia(TipoGaranzia.IncendioDemolizione))
        'Public PartitaIncendioGelo As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioGelo As New CoperturaSingola(PartitaIncendioBase, New Garanzia(TipoGaranzia.IncendioGelo))
        'Public PartitaIncendioRicercaGuasto As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioRicercaGuasto As New CoperturaSingola(PartitaIncendioAbitazione, New Garanzia(TipoGaranzia.IncendioRicercaGuasto))
        'Public PartitaIncendioAcquaOcclusione As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioAcquaOcclusione As New CoperturaSingola(PartitaIncendioAbitazioneContenuto, New Garanzia(TipoGaranzia.IncendioAcquaOcclusione))
        'Public PartitaIncendioPannelliSolari As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioPannelliSolari As New CoperturaSingola(PartitaIncendioBase, New Garanzia(TipoGaranzia.IncendioPannelliSolari))
        Public PartitaIncendioRiduzioneFranchigiaFenomeniElettrici As New Partita(TipoPartita.Incendio)
        Public CoperturaIncendioRiduzioneFranchigiaFenomeniElettrici As New CoperturaSingola(PartitaIncendioRiduzioneFranchigiaFenomeniElettrici, New Garanzia(TipoGaranzia.IncendioRiduzioneFranchigiaFenomeniElettrici))

        'Terremoto
        Public CoperturaTerremoto As New CoperturaComposta()
        Public PartitaTerremotoBase As New Partita(TipoPartita.Terremoto)
        Public CoperturaTerremotoBase As New CoperturaSingola(PartitaTerremotoBase, New Garanzia(TipoGaranzia.TerremotoBase))
        'Public PartitaTerremotoFabbricato As New Partita(TipoPartita.Terremoto)
        Public CoperturaTerremotoFabbricato As New CoperturaSingola(PartitaIncendioAbitazione, New Garanzia(TipoGaranzia.TerremotoFabbricato))
        'Public PartitaTerremotoContenuto As New Partita(TipoPartita.Terremoto)
        Public CoperturaTerremotoContenuto As New CoperturaSingola(PartitaIncendioContenuto, New Garanzia(TipoGaranzia.TerremotoContenuto))
        Public TerremotoContenutoFormAss As IncendioContenutoFormAssEnum

        'Furto
        Public CoperturaFurto As New CoperturaComposta()
        Public PartitaFurtoBase As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoBase As New CoperturaSingola(PartitaFurtoBase, New Garanzia(TipoGaranzia.FurtoBase))
        Public PartitaFurtoContenuto As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoContenuto As New CoperturaSingola(PartitaFurtoContenuto, New Garanzia(TipoGaranzia.FurtoContenuto), True)
        Public PartitaFurtoEsterno As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoEsternoOro As New CoperturaSingola(PartitaFurtoEsterno, New Garanzia(TipoGaranzia.FurtoEsterno), True)
        Public PartitaFurtoEsternoPlatino As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoEsternoPlatino As New CoperturaSingola(PartitaFurtoEsternoPlatino, New Garanzia(TipoGaranzia.FurtoEsternoPlatino), True)
        Public PartitaFurtoInCassaforte As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoInCassaforte As New CoperturaSingola(PartitaFurtoInCassaforte, New Garanzia(TipoGaranzia.FurtoInCassaforte), True)
        Public PartitaFurtoPreziosiValori As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoPreziosiValori As New CoperturaSingola(PartitaFurtoPreziosiValori, New Garanzia(TipoGaranzia.FurtoPreziosiValori), True)
        Public PartitaFurtoValoriDimoraAbituale As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoValoriDimoraAbituale As New CoperturaSingola(PartitaFurtoValoriDimoraAbituale, New Garanzia(TipoGaranzia.FurtoValoriDimoraAbituale))
        Public PartitaFurtoValoriDimoraSaltuaria As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoValoriDimoraSaltuaria As New CoperturaSingola(PartitaFurtoValoriDimoraSaltuaria, New Garanzia(TipoGaranzia.FurtoValoriDimoraSaltuaria))
        Public PartitaFurtoPannelliSolari As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoPannelliSolari As New CoperturaSingola(PartitaFurtoPannelliSolari, New Garanzia(TipoGaranzia.FurtoPannelliSolari))
        Public PartitaFurtoMezziChiusura As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoMezziChiusura As New CoperturaSingola(PartitaFurtoMezziChiusura, New Garanzia(TipoGaranzia.FurtoMezziChiusura))
        Public PartitaFurtoImpiantoAllarme As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoImpiantoAllarme As New CoperturaSingola(PartitaFurtoImpiantoAllarme, New Garanzia(TipoGaranzia.FurtoImpiantoAllarme))
        Public PartitaFurtoFranchigia As New Partita(TipoPartita.Furto)
        Public CoperturaFurtoFranchigia As New CoperturaSingola(PartitaFurtoFranchigia, New Garanzia(TipoGaranzia.FurtoFranchigia))

        'Integrazione del 11/02/2015
        Public CoperturaIncendioEstensioneGaranziaBase As New CoperturaSingola(PartitaIncendioBase, New Garanzia(TipoGaranzia.IncendioEstensioneGaranziaBase))
        Public CoperturaIncendioPannelliSolariEstensioneFenomenoElettrico As New CoperturaSingola(PartitaIncendioFenomeniElettrici, New Garanzia(TipoGaranzia.IncendioPannelliSolariEstensioneFenomenoElettrico))
        Public CoperturaIncendioPannelliSolariEstensioneFenomenoAtmosferici As New CoperturaSingola(PartitaIncendioBase, New Garanzia(TipoGaranzia.IncendioPannelliSolariEstensioneFenomenoAtmosferici))
        Public CoperturaIncendioPerditeOcculteAcqua As New CoperturaSingola(PartitaIncendioBase, New Garanzia(TipoGaranzia.IncendioPerditeOcculteAcqua))
        Public CoperturaFurtoEstensioneGaranziaBase As New CoperturaSingola(PartitaFurtoContenuto, New Garanzia(TipoGaranzia.FurtoEstensioneGaranziaBase))

        Public ReadOnly Property FurtoChiave As FurtoChiaveEnum
            Get
                Return youCasa.FurtoChiave
            End Get
        End Property

        Public ReadOnly Property IncendioChiave As IncendioChiaveEnum
            Get
                Return youCasa.IncendioChiave
            End Get
        End Property

        Public Sub New(ByVal youCasa As youCasa)
            Me.youCasa = youCasa

            With CoperturaIncendio
                .Sezione = youCasa.SezioneIncendio
                .AddCopertura(CoperturaIncendioBase)
                .AddCopertura(CoperturaIncendioAbitazione)
                .AddCopertura(CoperturaIncendioContenuto)
                .AddCopertura(CoperturaIncendioLocazione)
                .AddCopertura(CoperturaIncendioCondutture)
                .AddCopertura(CoperturaIncendioFenomeniElettrici)
                .AddCopertura(CoperturaIncendioFenomeniAtmosferici)
                .AddCopertura(CoperturaIncendioFenomeniAtmosfericiLarge)
                .AddCopertura(CoperturaIncendioRicorsoTerzi)
                .AddCopertura(CoperturaIncendioDemolizione)
                .AddCopertura(CoperturaIncendioGelo)
                .AddCopertura(CoperturaIncendioRicercaGuasto)
                .AddCopertura(CoperturaIncendioAcquaOcclusione)
                .AddCopertura(CoperturaIncendioPannelliSolari)
                .AddCopertura(CoperturaIncendioRiduzioneFranchigiaFenomeniElettrici)
                .AddCopertura(CoperturaIncendioEstensioneGaranziaBase)
                .AddCopertura(CoperturaIncendioPannelliSolariEstensioneFenomenoElettrico)
                .AddCopertura(CoperturaIncendioPannelliSolariEstensioneFenomenoAtmosferici)
                .AddCopertura(CoperturaIncendioPerditeOcculteAcqua)
            End With

            With CoperturaTerremoto
                .Sezione = youCasa.SezioneTerremoto
                .AddCopertura(CoperturaTerremotoBase)
                .AddCopertura(CoperturaTerremotoFabbricato)
                .AddCopertura(CoperturaTerremotoContenuto)
            End With

            With CoperturaFurto
                .Sezione = youCasa.SezioneFurto
                .AddCopertura(CoperturaFurtoBase)
                .AddCopertura(CoperturaFurtoContenuto)
                .AddCopertura(CoperturaFurtoEsternoOro)
                .AddCopertura(CoperturaFurtoEsternoPlatino)
                .AddCopertura(CoperturaFurtoInCassaforte)
                .AddCopertura(CoperturaFurtoPreziosiValori)
                .AddCopertura(CoperturaFurtoValoriDimoraAbituale)
                .AddCopertura(CoperturaFurtoValoriDimoraSaltuaria)
                .AddCopertura(CoperturaFurtoPannelliSolari)
                .AddCopertura(CoperturaFurtoMezziChiusura)
                .AddCopertura(CoperturaFurtoImpiantoAllarme)
                .AddCopertura(CoperturaFurtoFranchigia)
                .AddCopertura(CoperturaFurtoEstensioneGaranziaBase)
            End With

            'per la stampa
            CoperturaIncendioBase.NonStampare = True
            CoperturaTerremotoBase.NonStampare = True
            CoperturaFurtoBase.NonStampare = True

            '23/06/15: su indicazione di Giorgio, le opzioni vanno selezionate
            'Provincia = Luogo.GetProvinciaBySigla(youCasa.Cliente.Provincia)
            'If Provincia = ProvinciaEnum.SiglaXX Then Provincia = ProvinciaEnum.SiglaAG
            'TipoAbitazione = TipoAbitazioneEnum.Appartamento
            'CaratteristicaCostruttiva = CaratteristicaCostruttivaEnum.Tradizionale

            Provincia = ProvinciaEnum.SiglaXX
            Comune = 0
            TipoAbitazione = TipoAbitazioneEnum.NonSelected
            TipoDimora = TipoDimoraEnum.NonSelected
            PianoAbitazione = PianoAbitazioneEnum.NonSelected
            CaratteristicaCostruttiva = CaratteristicaCostruttivaEnum.NonSelected
        End Sub

        Public Sub LoadForOldVersions()
            If PartitaIncendioFenomeniAtmosfericiLarge Is Nothing Then
                PartitaIncendioFenomeniAtmosfericiLarge = New Partita(TipoPartita.Incendio)
                CoperturaIncendioFenomeniAtmosfericiLarge = New CoperturaSingola(PartitaIncendioFenomeniAtmosfericiLarge, New Garanzia(TipoGaranzia.IncendioFenomeniAtmosfericiLarge))
            End If
            If CoperturaIncendioEstensioneGaranziaBase Is Nothing Then
                CoperturaIncendioEstensioneGaranziaBase = New CoperturaSingola(PartitaIncendioBase, New Garanzia(TipoGaranzia.IncendioEstensioneGaranziaBase))
                CoperturaIncendioPannelliSolariEstensioneFenomenoElettrico = New CoperturaSingola(PartitaIncendioFenomeniElettrici, New Garanzia(TipoGaranzia.IncendioPannelliSolariEstensioneFenomenoElettrico))
                CoperturaIncendioPannelliSolariEstensioneFenomenoAtmosferici = New CoperturaSingola(PartitaIncendioBase, New Garanzia(TipoGaranzia.IncendioPannelliSolariEstensioneFenomenoAtmosferici))
                CoperturaIncendioPerditeOcculteAcqua = New CoperturaSingola(PartitaIncendioBase, New Garanzia(TipoGaranzia.IncendioPerditeOcculteAcqua))
                CoperturaFurtoEstensioneGaranziaBase = New CoperturaSingola(PartitaFurtoBase, New Garanzia(TipoGaranzia.FurtoEstensioneGaranziaBase))

                CoperturaIncendio.AddCopertura(CoperturaIncendioEstensioneGaranziaBase)
                CoperturaIncendio.AddCopertura(CoperturaIncendioPannelliSolariEstensioneFenomenoElettrico)
                CoperturaIncendio.AddCopertura(CoperturaIncendioPannelliSolariEstensioneFenomenoAtmosferici)
                CoperturaIncendio.AddCopertura(CoperturaIncendioPerditeOcculteAcqua)
                CoperturaFurto.AddCopertura(CoperturaFurtoEstensioneGaranziaBase)
            End If
            If PartitaIncendioAbitazioneContenuto Is Nothing Then
                PartitaIncendioAbitazioneContenuto = New Partita(TipoPartita.Incendio)
                CoperturaIncendioFenomeniAtmosferici = New CoperturaSingola(PartitaIncendioAbitazioneContenuto, New Garanzia(TipoGaranzia.IncendioFenomeniAtmosferici))
                CoperturaIncendioAcquaOcclusione = New CoperturaSingola(PartitaIncendioAbitazioneContenuto, New Garanzia(TipoGaranzia.IncendioAcquaOcclusione))
                CoperturaIncendio.AddCopertura(CoperturaIncendioFenomeniAtmosferici)
                CoperturaIncendio.AddCopertura(CoperturaIncendioAcquaOcclusione)
            End If

            If TipoAbitazione = TipoAbitazioneEnum.DimoraSaltuaria Then
                TipoAbitazione = TipoAbitazioneEnum.Appartamento
                TipoDimora = TipoDimoraEnum.DimoraSaltuaria
            ElseIf TipoDimora = TipoDimoraEnum.NonSelected Then
                TipoDimora = TipoDimoraEnum.DimoraAbituale
            End If

            If Provincia = ProvinciaEnum.SiglaXX Then
                Provincia = ProvinciaEnum.SiglaAG
            End If
            If Comune = 0 Then
                Comune = Luogo.Comuni.Find(Function(c As Comune) c.Provincia.IdProvincia = Provincia).CodiceIstat
            End If
            If PianoAbitazione = PianoAbitazioneEnum.NonSelected Then
                PianoAbitazione = PianoAbitazioneEnum.PianoTerra
            End If
        End Sub

        Public Sub ValidaGenerale()
            If Provincia = ProvinciaEnum.SiglaXX Then
                Comune = 0
            End If
            If Comune = 0 Then
                TipoAbitazione = TipoAbitazioneEnum.NonSelected
            End If
            If TipoAbitazione = TipoAbitazioneEnum.NonSelected Then
                TipoDimora = TipoDimoraEnum.NonSelected
            End If
            If TipoDimora = TipoDimoraEnum.NonSelected Then
                PianoAbitazione = PianoAbitazioneEnum.NonSelected
            End If
            If PianoAbitazione = PianoAbitazioneEnum.NonSelected Then
                CaratteristicaCostruttiva = CaratteristicaCostruttivaEnum.NonSelected
            End If

            If Provincia = ProvinciaEnum.SiglaXX Then
                CoperturaIncendio.SetRischioDirezione("Selezionare la provincia dell'abitazione")
            ElseIf Comune = 0 Then
                CoperturaIncendio.SetRischioDirezione("Selezionare il comune dell'abitazione")
            ElseIf TipoAbitazione = TipoAbitazioneEnum.NonSelected Then
                CoperturaIncendio.SetRischioDirezione("Selezionare il tipo di abitazione")
            ElseIf TipoDimora = TipoDimoraEnum.NonSelected Then
                CoperturaIncendio.SetRischioDirezione("Selezionare il tipo di dimora")
            ElseIf PianoAbitazione = PianoAbitazioneEnum.NonSelected Then
                CoperturaIncendio.SetRischioDirezione("Selezionare il piano dell'abitazione")
            ElseIf CaratteristicaCostruttiva = CaratteristicaCostruttivaEnum.NonSelected Then
                CoperturaIncendio.SetRischioDirezione("Selezionare la caratteristica costruttiva")
            End If
        End Sub

        Public Sub ValidaSezioneIncendio()
            CoperturaIncendio.Stato = StatoCopertura.attiva
            CoperturaIncendioBase.DipendeDa(IsParamsCompleted())

            'Per ciascuna abitazione assicurata è obbligatoria almeno una delle due partite Abitazione o Contenuto.
            CoperturaIncendioAbitazione.DipendeDa(CoperturaIncendioBase.IsAttivo) 'AOP
            CoperturaIncendioContenuto.DipendeDa(CoperturaIncendioBase.IsAttivo) 'AOP

            Dim AbitazioneOrContenutoOK = CoperturaIncendioAbitazione.IsAttivo Or CoperturaIncendioContenuto.IsAttivo
            CoperturaIncendioCondutture.DipendeDa(AbitazioneOrContenutoOK And IncendioChiave <> IncendioChiaveEnum.ChiavePLATINO) 'AO
            CoperturaIncendioFenomeniElettrici.DipendeDa(AbitazioneOrContenutoOK And IncendioChiave <> IncendioChiaveEnum.ChiavePLATINO) 'AO
            CoperturaIncendioFenomeniAtmosferici.DipendeDa(AbitazioneOrContenutoOK And IncendioChiave <> IncendioChiaveEnum.ChiavePLATINO) 'AO
            CoperturaIncendioFenomeniAtmosfericiLarge.DipendeDa(CoperturaIncendioFenomeniAtmosferici.IsAttivo And IncendioChiave = IncendioChiaveEnum.ChiaveORO And (CoperturaIncendioAbitazione.IsAttivo Or CoperturaIncendioLocazione.IsAttivo)) 'O
            CoperturaIncendioDemolizione.ObbligatoriaDa(AbitazioneOrContenutoOK And IncendioChiave = IncendioChiaveEnum.ChiaveORO) 'O
            CoperturaIncendioGelo.DipendeDa(AbitazioneOrContenutoOK And IncendioChiave = IncendioChiaveEnum.ChiaveORO) 'O
            CoperturaIncendioPannelliSolari.DipendeDa(AbitazioneOrContenutoOK And IncendioChiave = IncendioChiaveEnum.ChiavePLATINO) 'P
            CoperturaIncendioRiduzioneFranchigiaFenomeniElettrici.DipendeDa(AbitazioneOrContenutoOK And IncendioChiave = IncendioChiaveEnum.ChiavePLATINO) 'P

            'La partita Rischio Locativo può essere assicurata in alternativa alla partita Abitazione 
            'e può essere rilasciata solo se assicurato anche il Contenuto per almeno € 8.000,00.
            CoperturaIncendioLocazione.DipendeDa(Not CoperturaIncendioAbitazione.IsAttivo And _
                                                 CoperturaIncendioContenuto.IsAttivo And PartitaIncendioContenuto.SommaAssicurata >= 8000 And IncendioChiave <> IncendioChiaveEnum.ChiavePLATINO) 'AO

            'La partita Ricorso terzi può essere rilasciata solo se sono assicurati la partita Abitazione 
            '(Proprietà o conto terzi) per almeno € 52.000,00 e/o il Contenuto per almeno € 8.000,00.
            CoperturaIncendioRicorsoTerzi.DipendeDa((CoperturaIncendioContenuto.IsAttivo And PartitaIncendioContenuto.SommaAssicurata >= 8000) _
                                                    Or (Not CoperturaIncendioContenuto.IsAttivo And CoperturaIncendioAbitazione.IsAttivo And PartitaIncendioAbitazione.SommaAssicurata >= 52000)) 'AOP

            'La garanzia supplementare Acqua piovana - Occlusione condutt ure/rigurgito scarichi - Fuoriuscita acqua da 
            'elettrodomestici (Chiave Oro) può essere rilasciata solo se richiamata la garanzia supplementare “Ricerca del guasto”;
            '14 maggiore 2014: errore essig? no dipendenza ricerca guasto
            'CoperturaIncendioAcquaOcclusione.DipendeDa(CoperturaIncendioRicercaGuasto.IsAttivo And IncendioChiave = IncendioChiaveEnum.ChiaveORO) 'O
            CoperturaIncendioAcquaOcclusione.DipendeDa(AbitazioneOrContenutoOK And IncendioChiave = IncendioChiaveEnum.ChiaveORO) 'O

            'La garanzia supplementare ricerca del guasto (Chiave Oro) può solo se richiamata la garanzia supplementare Acqua Condotta
            '5-maggio-2014: da rilevazioni di Umberto Troiani
            CoperturaIncendioRicercaGuasto.DipendeDa(CoperturaIncendioCondutture.IsAttivo And CoperturaIncendioAbitazione.IsAttivo And IncendioChiave = IncendioChiaveEnum.ChiaveORO) 'O

            'integrazione 11-02-2015
            CoperturaIncendioEstensioneGaranziaBase.DipendeDa(AbitazioneOrContenutoOK And IncendioChiave <> IncendioChiaveEnum.ChiaveARGENTO)
            CoperturaIncendioPannelliSolariEstensioneFenomenoElettrico.DipendeDa(CoperturaIncendioEstensioneGaranziaBase.IsAttivo And CoperturaIncendioFenomeniElettrici.IsAttivo And IncendioChiave = IncendioChiaveEnum.ChiaveORO)
            CoperturaIncendioPannelliSolariEstensioneFenomenoAtmosferici.DipendeDa(CoperturaIncendioEstensioneGaranziaBase.IsAttivo And CoperturaIncendioFenomeniAtmosfericiLarge.IsAttivo And IncendioChiave = IncendioChiaveEnum.ChiaveORO)
            CoperturaIncendioPerditeOcculteAcqua.DipendeDa(CoperturaIncendioCondutture.IsAttivo And IncendioChiave = IncendioChiaveEnum.ChiaveORO Or IncendioChiave = IncendioChiaveEnum.ChiavePLATINO)

            If IncendioChiave = IncendioChiaveEnum.ChiaveARGENTO Then
                If IncendioContenutoFormAss = IncendioContenutoFormAssEnum.ValorePrimoRischioNuovo Then
                    IncendioContenutoFormAss = IncendioContenutoFormAssEnum.ValoreInteroNuovo
                ElseIf IncendioContenutoFormAss = IncendioContenutoFormAssEnum.ValorePrimoRischioCommerciale Then
                    IncendioContenutoFormAss = IncendioContenutoFormAssEnum.ValoreInteroCommerciale
                End If
            End If

            If IncendioChiave <> IncendioChiaveEnum.ChiavePLATINO Then
                If IncendioLocazioneFormAss = IncendioLocazioneFormAssEnum.ValorePrimoRischioNuovo Then
                    IncendioLocazioneFormAss = IncendioLocazioneFormAssEnum.ValoreInteroNuovo
                ElseIf IncendioLocazioneFormAss = IncendioLocazioneFormAssEnum.valorePrimoRischioCommerciale Then
                    IncendioLocazioneFormAss = IncendioLocazioneFormAssEnum.ValoreInteroCommerciale
                End If
            End If

            If IncendioChiave = IncendioChiaveEnum.ChiavePLATINO Then
                If IncendioAbitazioneFormAss = IncendioAbitazioneFormAssEnum.ValoreInteroCommerciale Then
                    IncendioAbitazioneFormAss = IncendioAbitazioneFormAssEnum.ValoreInteroNuovo
                End If
                If IncendioContenutoFormAss = IncendioContenutoFormAssEnum.ValoreInteroCommerciale Then
                    IncendioContenutoFormAss = IncendioContenutoFormAssEnum.ValoreInteroNuovo
                ElseIf IncendioContenutoFormAss = IncendioContenutoFormAssEnum.ValorePrimoRischioCommerciale Then
                    IncendioContenutoFormAss = IncendioContenutoFormAssEnum.ValorePrimoRischioNuovo
                End If
            End If


            'Limiti Assuntivi
            'La partita Contenuto può essere assicurata solo per una somma non inferiore ad € 3.000,00.
            PartitaIncendioContenuto.LimiteAssuntivoMinimo(3000)
            PartitaIncendioContenuto.LimiteAssuntivoMassimo(Choose(IncendioContenutoFormAss, 500000, 500000, 100000, 100000))

            'Le partite Abitazione o Rischio Locativo possono essere assicurate solo per somme non inferiori ad € 10.000,00.
            PartitaIncendioAbitazione.LimitiAssuntivi(10000, 2000000)
            PartitaIncendioLocazione.LimitiAssuntivi(10000, 2000000)

            PartitaIncendioRicorsoTerzi.LimitiAssuntivi(1000, 1000000)
            PartitaIncendioFenomeniElettrici.LimitiAssuntivi(1500, 20000)

            'Complessivo per
            'singola ubicazione assicurata sulle partite Abitazione o Rischio Locativo + Contenuto + Ricorso Terzi 3.500.000 
            '(OK - verificate che non possono superare tale limite)


            'I tassi delle tre partite abitazione/rischio
            'locativo/contenuto valgono sia per il tipo di garanzia “valore a nuovo” (valore di costruzione o rimpiazzo) 
            'sia per quello “valore commerciale  (valore allo stato d’uso)  salvo ove diversamente indicato.

            'Per le garanzie facoltative vengono esposti i corrispondenti tassi aggiuntivi (da sommare al tasso base).
            PartitaIncendioBase.SommaAssicurata = CoperturaIncendioAbitazione.SommaAssicurataAttiva _
                                                + CoperturaIncendioLocazione.SommaAssicurataAttiva _
                                                + CoperturaIncendioContenuto.SommaAssicurataAttiva

            PartitaIncendioAbitazioneContenuto.SommaAssicurata = CoperturaIncendioAbitazione.SommaAssicurataAttiva + CoperturaIncendioContenuto.SommaAssicurataAttiva
            PartitaIncendioFenomeniAtmosfericiLarge.SommaAssicurata = CoperturaIncendioAbitazione.SommaAssicurataAttiva + CoperturaIncendioLocazione.SommaAssicurataAttiva

            ' varie
            ZonaTerritorialeEventiAtmosferici = CType(youCasa.Decode, P07261DE).DecodeProvinciaToEventiAtmosferici(Provincia)

            Dim TipoAbitazioneDimora As Integer = GetTipoAbitazioneDimora()

            With CoperturaIncendioBase
                .Tariffa.Tasso = 0D
            End With

            With CoperturaIncendioAbitazione
                If IncendioAbitazioneFormAss = 0 Then IncendioAbitazioneFormAss = IncendioAbitazioneFormAssEnum.ValoreInteroNuovo
                .Tariffa.Tasso = Choose(IncendioChiave, 0.1D, 0.12D, Choose(ZonaTerritorialeEventiAtmosferici, 1.216D, 1.198D, 1.059D)) / 1000D
            End With

            With CoperturaIncendioContenuto
                If IncendioContenutoFormAss = 0 Then IncendioContenutoFormAss = IncendioContenutoFormAssEnum.ValoreInteroNuovo
                .Tariffa.Tasso = Choose(IncendioChiave, 0.245D, 0.672D, Choose(ZonaTerritorialeEventiAtmosferici, 2.245D, 2.232D, 2.137D)) * Choose(IncendioContenutoFormAss, 1D, 1D, 1.8D, 1.4D) / 1000D
            End With

            With CoperturaIncendioLocazione
                If IncendioLocazioneFormAss = 0 Then IncendioLocazioneFormAss = IncendioLocazioneFormAssEnum.ValoreInteroNuovo
                .Tariffa.Tasso = Choose(IncendioChiave, 0.086D, 0.1D, 0D) / 1000D
            End With

            With CoperturaIncendioEstensioneGaranziaBase
                .Tariffa.Base = 0D
                If IncendioChiave = IncendioChiaveEnum.ChiaveORO Then
                    .Tariffa.Base += CoperturaIncendioAbitazione.SommaAssicurataAttiva * ((0.1344D * 0.9955D - 0.12D) / 1000D) ' 0.135 -> 0.1344 DA ESSIG
                    .Tariffa.Base += CoperturaIncendioContenuto.SommaAssicurataAttiva * ((0.6853D - 0.672D) * Choose(IncendioContenutoFormAss, 1D, 1D, 1.8D, 1.4D) / 1000D) ' 0.686 -> 0.6853D DA ESSIG
                    .Tariffa.Base += CoperturaIncendioLocazione.SommaAssicurataAttiva * ((0.112D - 0.1D) / 1000D)
                ElseIf IncendioChiave = IncendioChiaveEnum.ChiavePLATINO Then
                    .Tariffa.Base += CoperturaIncendioAbitazione.SommaAssicurataAttiva * Choose(ZonaTerritorialeEventiAtmosferici, 1.362D - 1.216D, 1.342D - 1.198D, 1.187D - 1.059D) / 1000D
                    .Tariffa.Base += CoperturaIncendioContenuto.SommaAssicurataAttiva * Choose(ZonaTerritorialeEventiAtmosferici, 2.29D - 2.245D, 2.277D - 2.232D, 2.18D - 2.137D) * Choose(IncendioContenutoFormAss, 1D, 1D, 1.8D, 1.4D) / 1000D
                End If
            End With

            With CoperturaIncendioCondutture
                If .Garanzia.Franchigia = 0D Then .Garanzia.Franchigia = 150D
                If IncendioChiave = IncendioChiaveEnum.ChiaveARGENTO Then
                    .Tariffa.Tasso = 0.208D / 1000D
                    .Garanzia.Franchigia = 150D
                ElseIf .Garanzia.Franchigia = 150 Then
                    .Tariffa.Tasso = 0.22D / 1000D
                ElseIf .Garanzia.Franchigia = 200 Then
                    .Tariffa.Tasso = 0.212D / 1000D
                ElseIf .Garanzia.Franchigia = 300 Then
                    .Tariffa.Tasso = 0.196D / 1000D
                End If
                .Partita.SommaAssicurata = CoperturaIncendioAbitazione.SommaAssicurataAttiva + CoperturaIncendioContenuto.SommaAssicurataAttiva
            End With

            With CoperturaIncendioFenomeniElettrici
                If .Garanzia.Franchigia = 0D Then .Garanzia.Franchigia = 150D

                If IncendioChiave = IncendioChiaveEnum.ChiaveARGENTO Then
                    .Tariffa.Base = 21.5D
                    '.Garanzia.Franchigia = 0D
                    .Tariffa.Tasso = 0D
                ElseIf .Partita.SommaAssicurata <= 2500D Then
                    If .Garanzia.Franchigia = 150 Then
                        .Tariffa.Base = 0D
                        .Tariffa.Tasso = 15.59D / 1000D
                    ElseIf .Garanzia.Franchigia = 200 Then
                        .Tariffa.Base = 0D
                        .Tariffa.Tasso = 14.67D / 1000D
                    ElseIf .Garanzia.Franchigia = 300 Then
                        .Tariffa.Base = 0D
                        .Tariffa.Tasso = 13D / 1000D
                    End If
                Else 't2 + (t1 - t2) * 2500 / SA 
                    If .Garanzia.Franchigia = 150 Then
                        .Tariffa.Base = 2500 * (15.59D - 10.719D) / 1000D
                        .Tariffa.Tasso = 10.719D / 1000D
                    ElseIf .Garanzia.Franchigia = 200 Then
                        .Tariffa.Base = 2500 * (14.67D - 10.087D) / 1000D
                        .Tariffa.Tasso = 10.087D / 1000D
                    ElseIf .Garanzia.Franchigia = 300 Then
                        .Tariffa.Base = 2500 * (13D - 8.938D) / 1000D
                        .Tariffa.Tasso = 8.938D / 1000D
                    End If
                End If
            End With

            With CoperturaIncendioPannelliSolariEstensioneFenomenoElettrico
                If IncendioChiave = IncendioChiaveEnum.ChiaveORO Then
                    If CoperturaIncendioFenomeniElettrici.Partita.SommaAssicurata <= 2500D Then
                        If CoperturaIncendioFenomeniElettrici.Garanzia.Franchigia = 150 Then
                            .Tariffa.Base = 0D
                            .Tariffa.Tasso = 18.708D / 1000D
                        ElseIf CoperturaIncendioFenomeniElettrici.Garanzia.Franchigia = 200 Then
                            .Tariffa.Base = 0D
                            .Tariffa.Tasso = 17.604D / 1000D
                        ElseIf CoperturaIncendioFenomeniElettrici.Garanzia.Franchigia = 300 Then
                            .Tariffa.Base = 0D
                            .Tariffa.Tasso = 15.6D / 1000D
                        End If
                    Else 't2 + (t1 - t2) * 2500 / SA 
                        If CoperturaIncendioFenomeniElettrici.Garanzia.Franchigia = 150 Then
                            .Tariffa.Base = 2500 * (18.708D - 12.862D) / 1000D
                            .Tariffa.Tasso = 12.862D / 1000D
                        ElseIf CoperturaIncendioFenomeniElettrici.Garanzia.Franchigia = 200 Then
                            .Tariffa.Base = 2500 * (17.604D - 12.104D) / 1000D
                            .Tariffa.Tasso = 12.104D / 1000D
                        ElseIf CoperturaIncendioFenomeniElettrici.Garanzia.Franchigia = 300 Then
                            .Tariffa.Base = 2500 * (15.6D - 10.725D) / 1000D
                            .Tariffa.Tasso = 10.725D / 1000D
                        End If
                    End If
                    .Tariffa.Base -= CoperturaIncendioFenomeniElettrici.Tariffa.Base
                    .Tariffa.Tasso -= CoperturaIncendioFenomeniElettrici.Tariffa.Tasso
                End If
            End With

            With CoperturaIncendioFenomeniAtmosferici
                If .Garanzia.Limite = 0 Then .Garanzia.Limite = 50
                If .Garanzia.Combinazione = 0 Then .Garanzia.Combinazione = 25000
                If IncendioChiave = IncendioChiaveEnum.ChiaveARGENTO And .Garanzia.Combinazione = 50000 Then
                    .Garanzia.Combinazione = 25010
                End If

                If .Garanzia.Combinazione = 25000 Then
                    .Garanzia.Franchigia = 250
                    .Garanzia.Scoperto = 0
                ElseIf .Garanzia.Combinazione = 50000 Then
                    .Garanzia.Franchigia = 500
                    .Garanzia.Scoperto = 0
                ElseIf .Garanzia.Combinazione = 25010 Then
                    .Garanzia.Franchigia = 250
                    .Garanzia.Scoperto = 10
                End If

                .Tariffa.Tasso = 0D
                If ZonaTerritorialeEventiAtmosferici = ZonaTerritorialeEventiAtmosfericiEnum.ZonaA Then
                    If .Garanzia.Limite = 50 Then
                        If .Garanzia.Combinazione = 25000 Then
                            .Tariffa.Tasso = Choose(IncendioChiave, 0.067D, Choose(TipoAbitazioneDimora, 0.173D, 0.193D, 0.218D, 0.218D), 0D) / 1000D
                        ElseIf .Garanzia.Combinazione = 50000 Then
                            .Tariffa.Tasso = Choose(IncendioChiave, 0D, Choose(TipoAbitazioneDimora, 0.154D, 0.171D, 0.194D, 0.194D), 0D) / 1000D
                        ElseIf .Garanzia.Combinazione = 25010 Then
                            .Tariffa.Tasso = Choose(IncendioChiave, 0.065D, Choose(TipoAbitazioneDimora, 0.167D, 0.187D, 0.211D, 0.211D), 0D) / 1000D
                        End If
                    ElseIf .Garanzia.Limite = 75 Then
                        If .Garanzia.Combinazione = 25000 Then
                            .Tariffa.Tasso = Choose(IncendioChiave, 0.072D, Choose(TipoAbitazioneDimora, 0.183D, 0.203D, 0.23D, 0.23D), 0D) / 1000D
                        ElseIf .Garanzia.Combinazione = 50000 Then
                            .Tariffa.Tasso = Choose(IncendioChiave, 0D, Choose(TipoAbitazioneDimora, 0.163D, 0.181D, 0.205D, 0.205D), 0D) / 1000D
                        ElseIf .Garanzia.Combinazione = 25010 Then
                            .Tariffa.Tasso = Choose(IncendioChiave, 0.068D, Choose(TipoAbitazioneDimora, 0.177D, 0.197D, 0.224D, 0.224D), 0D) / 1000D
                        End If
                    End If
                ElseIf ZonaTerritorialeEventiAtmosferici = ZonaTerritorialeEventiAtmosfericiEnum.ZonaB Then
                    If .Garanzia.Limite = 50 Then
                        If .Garanzia.Combinazione = 25000 Then
                            .Tariffa.Tasso = Choose(IncendioChiave, 0.061D, Choose(TipoAbitazioneDimora, 0.165D, 0.183D, 0.208D, 0.208D), 0D) / 1000D
                        ElseIf .Garanzia.Combinazione = 50000 Then
                            .Tariffa.Tasso = Choose(IncendioChiave, 0D, Choose(TipoAbitazioneDimora, 0.147D, 0.164D, 0.185D, 0.23D), 0D) / 1000D
                        ElseIf .Garanzia.Combinazione = 25010 Then
                            .Tariffa.Tasso = Choose(IncendioChiave, 0.059D, Choose(TipoAbitazioneDimora, 0.16D, 0.178D, 0.202D, 0.202D), 0D) / 1000D
                        End If
                    ElseIf .Garanzia.Limite = 75 Then
                        If .Garanzia.Combinazione = 25000 Then
                            .Tariffa.Tasso = Choose(IncendioChiave, 0.065D, Choose(TipoAbitazioneDimora, 0.174D, 0.193D, 0.219D, 0.219D), 0D) / 1000D
                        ElseIf .Garanzia.Combinazione = 50000 Then
                            .Tariffa.Tasso = Choose(IncendioChiave, 0D, Choose(TipoAbitazioneDimora, 0.155D, 0.172D, 0.194D, 0.194D), 0D) / 1000D
                        ElseIf .Garanzia.Combinazione = 25010 Then
                            .Tariffa.Tasso = Choose(IncendioChiave, 0.062D, Choose(TipoAbitazioneDimora, 0.104D, 0.116D, 0.132D, 0.132D), 0D) / 1000D
                        End If
                    End If
                ElseIf ZonaTerritorialeEventiAtmosferici = ZonaTerritorialeEventiAtmosfericiEnum.ZonaC Then
                    If .Garanzia.Limite = 50 Then
                        If .Garanzia.Combinazione = 25000 Then
                            .Tariffa.Tasso = Choose(IncendioChiave, 0.051D, Choose(TipoAbitazioneDimora, 0.102D, 0.113D, 0.128D, 0.128D), 0D) / 1000D
                        ElseIf .Garanzia.Combinazione = 50000 Then
                            .Tariffa.Tasso = Choose(IncendioChiave, 0D, Choose(TipoAbitazioneDimora, 0.09D, 0.101D, 0.115D, 0.115D), 0D) / 1000D
                        ElseIf .Garanzia.Combinazione = 25010 Then
                            .Tariffa.Tasso = Choose(IncendioChiave, 0.05D, Choose(TipoAbitazioneDimora, 0.099D, 0.11D, 0.125D, 0.125D), 0D) / 1000D
                        End If
                    ElseIf .Garanzia.Limite = 75 Then
                        If .Garanzia.Combinazione = 25000 Then
                            .Tariffa.Tasso = Choose(IncendioChiave, 0.055D, Choose(TipoAbitazioneDimora, 0.108D, 0.12D, 0.136D, 0.136D), 0D) / 1000D
                        ElseIf .Garanzia.Combinazione = 50000 Then
                            .Tariffa.Tasso = Choose(IncendioChiave, 0D, Choose(TipoAbitazioneDimora, 0.095D, 0.108D, 0.121D, 0.121D), 0D) / 1000D
                        ElseIf .Garanzia.Combinazione = 25010 Then
                            .Tariffa.Tasso = Choose(IncendioChiave, 0.052D, Choose(TipoAbitazioneDimora, 0.104D, 0.116D, 0.132D, 0.132D), 0D) / 1000D
                        End If
                    End If
                End If
            End With

            With CoperturaIncendioFenomeniAtmosfericiLarge
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 20000D
                If .Garanzia.Combinazione = 0 Then .Garanzia.Combinazione = 25000
                .Tariffa.Tasso = 0D
                If ZonaTerritorialeEventiAtmosferici = ZonaTerritorialeEventiAtmosfericiEnum.ZonaA Then
                    If .Garanzia.Combinazione = 25000 Then
                        If .Garanzia.Massimale = 20000D Then
                            .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 0.081D, 0.09D, 0.101D, 0.101D) / 1000D
                        ElseIf .Garanzia.Massimale = 30000D Then
                            .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 0.083D, 0.094D, 0.105D, 0.105D) / 1000D
                        End If
                    ElseIf .Garanzia.Combinazione = 50000 Then
                        If .Garanzia.Massimale = 20000D Then
                            .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 0.072D, 0.081D, 0.09D, 0.09D) / 1000D
                        ElseIf .Garanzia.Massimale = 30000D Then
                            .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 0.075D, 0.083D, 0.094D, 0.094D) / 1000D
                        End If
                    ElseIf .Garanzia.Combinazione = 25010 Then
                        If .Garanzia.Massimale = 20000D Then
                            .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 0.078D, 0.088D, 0.099D, 0.099D) / 1000D
                        ElseIf .Garanzia.Massimale = 30000D Then
                            .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 0.081D, 0.092D, 0.103D, 0.103D) / 1000D
                        End If
                    End If
                ElseIf ZonaTerritorialeEventiAtmosferici = ZonaTerritorialeEventiAtmosfericiEnum.ZonaB Then
                    If .Garanzia.Combinazione = 25000 Then
                        If .Garanzia.Massimale = 20000D Then
                            .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 0.077D, 0.086D, 0.097D, 0.097D) / 1000D
                        ElseIf .Garanzia.Massimale = 30000D Then
                            .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 0.079D, 0.088D, 0.1D, 0.1D) / 1000D
                        End If
                    ElseIf .Garanzia.Combinazione = 50000 Then
                        If .Garanzia.Massimale = 20000D Then
                            .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 0.068D, 0.076, 0.086D, 0.086D) / 1000D
                        ElseIf .Garanzia.Massimale = 30000D Then
                            .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 0.071D, 0.078D, 0.088D, 0.088D) / 1000D
                        End If
                    ElseIf .Garanzia.Combinazione = 25010 Then
                        If .Garanzia.Massimale = 20000D Then
                            .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 0.075D, 0.083D, 0.094D, 0.094D) / 1000D
                        ElseIf .Garanzia.Massimale = 30000D Then
                            .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 0.077D, 0.086D, 0.098D, 0.098D) / 1000D
                        End If
                    End If
                ElseIf ZonaTerritorialeEventiAtmosferici = ZonaTerritorialeEventiAtmosfericiEnum.ZonaC Then
                    If .Garanzia.Combinazione = 25000 Then
                        If .Garanzia.Massimale = 20000D Then
                            .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 0.048D, 0.053D, 0.06D, 0.06D) / 1000D
                        ElseIf .Garanzia.Massimale = 30000D Then
                            .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 0.049D, 0.055D, 0.062D, 0.062D) / 1000D
                        End If
                    ElseIf .Garanzia.Combinazione = 50000 Then
                        If .Garanzia.Massimale = 20000D Then
                            .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 0.043D, 0.046D, 0.054D, 0.054D) / 1000D
                        ElseIf .Garanzia.Massimale = 30000D Then
                            .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 0.044D, 0.048D, 0.056D, 0.056D) / 1000D
                        End If
                    ElseIf .Garanzia.Combinazione = 25010 Then
                        If .Garanzia.Massimale = 20000D Then
                            .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 0.046D, 0.051D, 0.059D, 0.059D) / 1000D
                        ElseIf .Garanzia.Massimale = 30000D Then
                            .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 0.048D, 0.053D, 0.061D, 0.061D) / 1000D
                        End If
                    End If
                End If
            End With

            'CoperturaIncendioPannelliSolariEstensioneFenomenoAtmosferici
            With CoperturaIncendioFenomeniAtmosfericiLarge
                .Tariffa.Base = 0D
                If .Garanzia.Combinazione = 25000 Then
                    .Garanzia.Franchigia = 250D
                    .Garanzia.Scoperto = 0D
                    If .Garanzia.Massimale = 20000D Then
                        CoperturaIncendioPannelliSolariEstensioneFenomenoAtmosferici.Tariffa.Base = Choose(ZonaTerritorialeEventiAtmosferici, 43D, 42D, 37D)
                    ElseIf .Garanzia.Massimale = 30000D Then
                        CoperturaIncendioPannelliSolariEstensioneFenomenoAtmosferici.Tariffa.Base = Choose(ZonaTerritorialeEventiAtmosferici, 45.5D, 44.5D, 39.5D)
                    End If
                ElseIf .Garanzia.Combinazione = 50000 Then
                    .Garanzia.Franchigia = 500D
                    .Garanzia.Scoperto = 0D
                    If .Garanzia.Massimale = 20000D Then
                        CoperturaIncendioPannelliSolariEstensioneFenomenoAtmosferici.Tariffa.Base = Choose(ZonaTerritorialeEventiAtmosferici, 39D, 38D, 33.5D)
                    ElseIf .Garanzia.Massimale = 30000D Then
                        CoperturaIncendioPannelliSolariEstensioneFenomenoAtmosferici.Tariffa.Base = Choose(ZonaTerritorialeEventiAtmosferici, 41D, 40D, 35.5D)
                    End If
                ElseIf .Garanzia.Combinazione = 25010 Then
                    .Garanzia.Franchigia = 250D
                    .Garanzia.Scoperto = 10D
                    If .Garanzia.Massimale = 20000D Then
                        CoperturaIncendioPannelliSolariEstensioneFenomenoAtmosferici.Tariffa.Base = Choose(ZonaTerritorialeEventiAtmosferici, 43D, 42D, 37D)
                    ElseIf .Garanzia.Massimale = 30000D Then
                        CoperturaIncendioPannelliSolariEstensioneFenomenoAtmosferici.Tariffa.Base = Choose(ZonaTerritorialeEventiAtmosferici, 45.5D, 44.5D, 39.5D)
                    End If
                End If
            End With

            With CoperturaIncendioRicorsoTerzi
                .Tariffa.Tasso = Choose(IncendioChiave, 0.073D, 0.22D, 0.33D) / 1000D
            End With

            With CoperturaIncendioDemolizione
                If CoperturaIncendioEstensioneGaranziaBase.IsAttivo Then
                    .Garanzia.Massimale = 999999D
                ElseIf .Garanzia.Massimale <= 0 Then
                    .Garanzia.Massimale = 30000D
                End If
                If .Garanzia.Massimale = 30000D Then
                    .Tariffa.Base = 2.8D
                ElseIf .Garanzia.Massimale = 60000D Then
                    .Tariffa.Base = 4.9D
                ElseIf .Garanzia.Massimale = 999999D Then
                    .Tariffa.Base = 7D
                Else
                    .Tariffa.Base = 0D
                End If
            End With

            With CoperturaIncendioGelo
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 5000D
                If .Garanzia.Franchigia = 0 Then .Garanzia.Franchigia = 250
                .Tariffa.Tasso = 0D
                If .Garanzia.Massimale = 5000D Then
                    If .Garanzia.Franchigia = 250 Then
                        .Tariffa.Tasso = 0.061D / 1000D
                    ElseIf .Garanzia.Franchigia = 400 Then
                        .Tariffa.Tasso = 0.052D / 1000D
                    End If
                ElseIf .Garanzia.Massimale = 7500D Then
                    If .Garanzia.Franchigia = 250 Then
                        .Tariffa.Tasso = 0.064D / 1000D
                    ElseIf .Garanzia.Franchigia = 400 Then
                        .Tariffa.Tasso = 0.054D / 1000D
                    End If
                End If
            End With

            With CoperturaIncendioRicercaGuasto
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 2500D
                If .Garanzia.Franchigia = 0 Then .Garanzia.Franchigia = 150
                .Tariffa.Tasso = 0D
                If .Garanzia.Massimale = 2500D Then
                    If .Garanzia.Franchigia = 150 Then
                        .Tariffa.Tasso = 0.061D / 1000D
                    ElseIf .Garanzia.Franchigia = 300 Then
                        .Tariffa.Tasso = 0.052D / 1000D
                    End If
                ElseIf .Garanzia.Massimale = 5000D Then
                    If .Garanzia.Franchigia = 150 Then
                        .Tariffa.Tasso = 0.064D / 1000D
                    ElseIf .Garanzia.Franchigia = 300 Then
                        .Tariffa.Tasso = 0.054D / 1000D
                    End If
                End If
            End With

            With CoperturaIncendioAcquaOcclusione
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 10000D
                If .Garanzia.Franchigia = 0 Then .Garanzia.Franchigia = 150
                .Tariffa.Tasso = 0D
                If .Garanzia.Massimale = 10000D Then
                    If .Garanzia.Franchigia = 150 Then
                        .Tariffa.Tasso = 0.089D / 1000D
                    ElseIf .Garanzia.Franchigia = 250 Then
                        .Tariffa.Tasso = 0.084D / 1000D
                    End If
                ElseIf .Garanzia.Massimale = 15000D Then
                    If .Garanzia.Franchigia = 150 Then
                        .Tariffa.Tasso = 0.098D / 1000D
                    ElseIf .Garanzia.Franchigia = 250 Then
                        .Tariffa.Tasso = 0.093D / 1000D
                    End If
                End If
            End With

            With CoperturaIncendioPerditeOcculteAcqua
                .Tariffa.Base = 30D
            End With

            With CoperturaIncendioPannelliSolari
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 20000D
                If .Garanzia.Franchigia = 0 Then .Garanzia.Franchigia = 250D
                .Tariffa.Base = 0D
                If .Garanzia.Massimale = 20000D Then
                    If .Garanzia.Franchigia = 250D Then
                        .Tariffa.Base = Choose(ZonaTerritorialeEventiAtmosferici, 43D, 42D, 37D)
                    ElseIf .Garanzia.Franchigia = 500D Then
                        .Tariffa.Base = Choose(ZonaTerritorialeEventiAtmosferici, 39D, 38D, 33.5D)
                    End If
                ElseIf .Garanzia.Massimale = 30000D Then
                    If .Garanzia.Franchigia = 250D Then
                        .Tariffa.Base = Choose(ZonaTerritorialeEventiAtmosferici, 45.5D, 44.5D, 39.5D)
                    ElseIf .Garanzia.Franchigia = 500D Then
                        .Tariffa.Base = Choose(ZonaTerritorialeEventiAtmosferici, 41D, 40D, 35.5D)
                    End If
                End If
            End With

            With CoperturaIncendioRiduzioneFranchigiaFenomeniElettrici
                .Partita.SommaAssicurata = CoperturaIncendioAbitazione.PremioAttivoCrudo + CoperturaIncendioContenuto.PremioAttivoCrudo + CoperturaIncendioEstensioneGaranziaBase.PremioAttivoCrudo
                .Tariffa.Tasso = 0.08D
            End With

        End Sub

        Public Sub ValidaSezioneTerremoto()
            CoperturaTerremoto.Stato = StatoCopertura.attiva
            CoperturaTerremotoBase.DipendeDa((CoperturaIncendioAbitazione.IsAttivo And PartitaIncendioAbitazione.SommaAssicurata >= 30000D) And IsParamsCompleted())

            CoperturaTerremotoFabbricato.DipendeDa(CoperturaTerremotoBase.IsAttivo)
            CoperturaTerremotoContenuto.DipendeDa(CoperturaTerremotoBase.IsAttivo And CoperturaIncendioContenuto.IsAttivo)

            With CoperturaTerremotoFabbricato
                If .Garanzia.Limite = 0 Then .Garanzia.Limite = 50
                .Tariffa.Tasso = youCasa.Tabelle.getTassoTerremoto(Comune, .Garanzia.Limite, CaratteristicaCostruttiva)
            End With

            With CoperturaTerremotoContenuto
                '22-12-14: da verifica preventivo
                '.Tariffa.Tasso = CoperturaTerremotoFabbricato.Tariffa.Tasso
                .Tariffa.Tasso = youCasa.Tabelle.getTassoTerremoto(Comune, 0, CaratteristicaCostruttiva)

                TerremotoContenutoFormAss = IncendioContenutoFormAss
                If TerremotoContenutoFormAss = IncendioContenutoFormAssEnum.ValorePrimoRischioCommerciale Then
                    .Tariffa.Tasso *= 1.4D
                ElseIf TerremotoContenutoFormAss = IncendioContenutoFormAssEnum.ValorePrimoRischioNuovo Then
                    .Tariffa.Tasso *= 1.8D
                End If
            End With

        End Sub

        Public Function IsDimoraAbituale() As Boolean
            Return TipoDimora = TipoDimoraEnum.DimoraAbituale
        End Function

        Private Function GetTipoAbitazioneDimora() As Decimal
            Dim TipoAbitazioneDimora As Integer = 4
            If IsDimoraAbituale() Then
                If TipoAbitazione = TipoAbitazioneEnum.VillaSchiera Then
                    TipoAbitazioneDimora = 2
                ElseIf TipoAbitazione = TipoAbitazioneEnum.VillaSingola Then
                    TipoAbitazioneDimora = 3
                ElseIf TipoAbitazione = TipoAbitazioneEnum.Appartamento Then
                    TipoAbitazioneDimora = 1
                End If
            End If
            Return TipoAbitazioneDimora
        End Function

        Public Function IsParamsCompleted() As Boolean
            Return CaratteristicaCostruttiva <> CaratteristicaCostruttivaEnum.NonSelected
        End Function

        Public Sub ValidaSezioneFurto()
            CoperturaFurto.Stato = StatoCopertura.attiva
            CoperturaFurtoBase.DipendeDa((IsDimoraAbituale() Or youCasa.HaCoperturaFurtoContenutoDimoraAbituale()) And IsParamsCompleted())

            CoperturaFurtoContenuto.DipendeDa(CoperturaFurtoBase.IsAttivo)
            If FurtoChiave = FurtoChiaveEnum.ChiaveORO Then
                CoperturaFurtoEsternoOro.DipendeDa(CoperturaFurtoContenuto.IsAttivo And IsDimoraAbituale())
                CoperturaFurtoEsternoPlatino.Stato = StatoCopertura.Inapplicabile
                CoperturaFurtoInCassaforte.DipendeDa(CoperturaFurtoContenuto.IsAttivo And IsDimoraAbituale())
                CoperturaFurtoPreziosiValori.DipendeDa(CoperturaFurtoContenuto.IsAttivo And IsDimoraAbituale())
            Else
                CoperturaFurtoEsternoOro.Stato = StatoCopertura.Inapplicabile
                CoperturaFurtoEsternoPlatino.ObbligatoriaDa(CoperturaFurtoContenuto.IsAttivo And IsDimoraAbituale())
                CoperturaFurtoInCassaforte.ObbligatoriaDa(CoperturaFurtoContenuto.IsAttivo And IsDimoraAbituale())
                CoperturaFurtoPreziosiValori.ObbligatoriaDa(CoperturaFurtoContenuto.IsAttivo And IsDimoraAbituale())
            End If

            CoperturaFurtoValoriDimoraAbituale.DipendeDa(CoperturaFurtoContenuto.IsAttivo And IsDimoraAbituale() And Not CoperturaFurtoInCassaforte.IsAttivo And Not CoperturaFurtoPreziosiValori.IsAttivo)
            CoperturaFurtoValoriDimoraSaltuaria.DipendeDa(CoperturaFurtoContenuto.IsAttivo And Not IsDimoraAbituale())
            CoperturaFurtoPannelliSolari.DipendeDa(CoperturaFurtoContenuto.IsAttivo)
            CoperturaFurtoMezziChiusura.DipendeDa(CoperturaFurtoContenuto.IsAttivo And FurtoChiave = FurtoChiaveEnum.ChiaveORO)
            CoperturaFurtoImpiantoAllarme.DipendeDa(CoperturaFurtoContenuto.IsAttivo And FurtoChiave = FurtoChiaveEnum.ChiaveORO)
            CoperturaFurtoFranchigia.DipendeDa(CoperturaFurtoContenuto.IsAttivo And FurtoChiave = FurtoChiaveEnum.ChiavePLATINO)

            'La somma minima assicurabile per il contenuto non può essere inferiore ad € 3.000,00.
            PartitaFurtoContenuto.LimiteAssuntivoMinimo(3000D)
            PartitaFurtoContenuto.LimiteAssuntivoMassimo(IIf(IsDimoraAbituale, 100000D, 20000D))

            'Il valore della partita “Rischi esterni all’abitazione” non può essere superiore a quello assicurato per il “Contenuto”.
            '11/02/2015: rimosso su segnalazione agenzia di rimini
            PartitaFurtoEsterno.LimiteAssuntivoMassimo(10500D)
            'PartitaFurtoEsterno.LimiteAssuntivoMassimo(PartitaFurtoContenuto.SommaAssicurata)

            PartitaFurtoEsternoPlatino.LimiteAssuntivoMassimo(18000D)
            'PartitaFurtoEsternoPlatino.LimiteAssuntivoMassimo(PartitaFurtoContenuto.SommaAssicurata)

            PartitaFurtoPreziosiValori.LimiteAssuntivoMassimo(IIf(FurtoChiave = FurtoChiaveEnum.ChiaveORO, 10500D, 60500D))
            '11/02/2015: su preventivo di agenzia di rimini e superiore a contenuto
            'PartitaFurtoPreziosiValori.LimiteAssuntivoMassimo(PartitaFurtoContenuto.SommaAssicurata)
            PartitaFurtoInCassaforte.LimiteAssuntivoMassimo(IIf(FurtoChiave = FurtoChiaveEnum.ChiaveORO, 26000D, 76000D))

            'Le partite “Preziosi e valori ovunque riposti” e “Preziosi e valori in cassaforte” non possono
            'avere importi complessivi superiori a quello assicurato per il “Contenuto”
            '13 maggio 14: non presente in Essig
            'PartitaFurtoInCassaforte.LimiteAssuntivoMassimo(PartitaFurtoContenuto.SommaAssicurata - PartitaFurtoPreziosiValori.SommaAssicurata)

            CoperturaFurtoEstensioneGaranziaBase.DipendeDa(CoperturaFurtoBase.IsAttivo)

            ClasseTerritorialeFurto = CType(youCasa.Decode, P07261DE).DecodeProvinciaToClasseTerritorialeFurto(Provincia)

            Dim TipoAbitazioneDimora As Integer = GetTipoAbitazioneDimora()

            With CoperturaFurtoContenuto
                If FurtoContenutoFormaAssicurazione = 0 Then FurtoContenutoFormaAssicurazione = FormaAssicurazioneEnum.valorePrimoRischioNuovo
                .Tariffa.Tasso = 0D
                If FurtoChiave = FurtoChiaveEnum.ChiaveORO Then
                    If ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe1 Then
                        .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 16.4D, 20.5D, 34.2D, 80D) / 1000D
                    ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe2 Then
                        .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 11.6D, 15.5D, 24.4D, 75D) / 1000D
                    ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe3 Then
                        .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 7.7D, 10.4D, 19.6D, 65D) / 1000D
                    ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe4 Then
                        .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 6.1D, 8.9D, 15.4D, 60D) / 1000D
                    End If
                ElseIf FurtoChiave = FurtoChiaveEnum.ChiavePLATINO Then
                    If ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe1 Then
                        .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 32.9D, 36.3D, 52.1D, 90D) / 1000D
                    ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe2 Then
                        .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 26.4D, 29.8D, 39.7D, 85D) / 1000D
                    ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe3 Then
                        .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 22.6D, 25.1D, 30.4D, 70D) / 1000D
                    ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe4 Then
                        .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 19.9D, 22D, 26.9D, 65D) / 1000D
                    End If
                End If
                If FurtoContenutoFormaAssicurazione = FormaAssicurazioneEnum.valorePrimoRischioCommerciale Then
                    .Tariffa.Tasso *= 0.85D
                End If
            End With

            With CoperturaFurtoEstensioneGaranziaBase
                .Tariffa.Tasso = 0D
                If FurtoChiave = FurtoChiaveEnum.ChiaveORO Then
                    If ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe1 Then
                        .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 18.6D, 23.3D, 38.9D, 91.2D) / 1000D
                    ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe2 Then
                        .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 13.2D, 17.6D, 27.8D, 85.5D) / 1000D
                    ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe3 Then
                        .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 8.7D, 11.8D, 22.3D, 74.1D) / 1000D
                    ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe4 Then
                        .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 6.9D, 10.1D, 17.5D, 68.4D) / 1000D
                    End If
                ElseIf FurtoChiave = FurtoChiaveEnum.ChiavePLATINO Then
                    If ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe1 Then
                        .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 35.1D, 39.1D, 56.8D, 101.2D) / 1000D
                    ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe2 Then
                        .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 28D, 31.9D, 43.1D, 95.5D) / 1000D
                    ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe3 Then
                        .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 23.6D, 26.5D, 33.1D, 79.1D) / 1000D
                    ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe4 Then
                        .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 20.7D, 23.2D, 29D, 73.4D) / 1000D
                    End If
                End If
                If FurtoContenutoFormaAssicurazione = FormaAssicurazioneEnum.valorePrimoRischioCommerciale Then
                    .Tariffa.Tasso *= 0.85D
                End If
                .Tariffa.Tasso -= CoperturaFurtoContenuto.Tariffa.Tasso
            End With

            With CoperturaFurtoEsternoOro
                If .Garanzia.Limite = 0 Then .Garanzia.Limite = 15
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 300D
                If FurtoEsternoScelta = 0 Then FurtoEsternoScelta = FurtoEsternoSceltaEnum.SceltaMEDIUM

                .Tariffa.Tasso = 12.8D / 1000D

                If FurtoEsternoScelta = FurtoEsternoSceltaEnum.SceltaLARGE Then
                    If .Garanzia.Limite = 15 Then
                        If .Garanzia.Massimale = 300D Then
                            .Tariffa.Tasso += 7.6D / 1000D
                        ElseIf .Garanzia.Massimale = 500D Then
                            .Tariffa.Tasso += 8.6D / 1000D
                        End If
                    ElseIf .Garanzia.Limite = 20 Then
                        If .Garanzia.Massimale = 300D Then
                            .Tariffa.Tasso += 8.2D / 1000D
                        ElseIf .Garanzia.Massimale = 500D Then
                            .Tariffa.Tasso += 9.2D / 1000D
                        End If
                    End If
                End If
            End With

            With CoperturaFurtoEsternoPlatino
                If FurtoChiave = FurtoChiaveEnum.ChiaveORO Then
                    FurtoEsternoPlatinoScelta = 0
                ElseIf .Partita.SommaAssicurata > 0.6D * PartitaFurtoContenuto.SommaAssicurata _
                    Or .Partita.SommaAssicurata > 7500D Then
                    FurtoEsternoPlatinoScelta = FurtoEsternoPlatinoSceltaEnum.SceltaB
                Else
                    FurtoEsternoPlatinoScelta = FurtoEsternoPlatinoSceltaEnum.SceltaA
                    .Partita.SommaAssicurata = 0.6D * PartitaFurtoContenuto.SommaAssicurata
                    If .Partita.SommaAssicurata > 7500D Then
                        .Partita.SommaAssicurata = 7500D
                    End If
                End If
                If FurtoEsternoPlatinoScelta = FurtoEsternoPlatinoSceltaEnum.SceltaA Then
                    .Tariffa.Tasso = 4.9D / 1000D
                    .Tariffa.Base = 0
                ElseIf FurtoEsternoPlatinoScelta = FurtoEsternoPlatinoSceltaEnum.SceltaB Then
                    '.Tariffa.Tasso = 22D / 1000D
                    .Tariffa.Tasso = 0D
                    .Tariffa.Base = 4.9D * (7500D / 1000D) + (22D / 1000D) * (.Partita.SommaAssicurata - 7500D)
                End If
            End With

            With CoperturaFurtoInCassaforte

                .Tariffa.Tasso = 0D
                If FurtoChiave = FurtoChiaveEnum.ChiaveORO Then

                    FurtoInCassaforteScelta = 0

                    If ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe1 Then
                        .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 18.3D, 21.9D, 24.5D, 0D) / 1000D
                    ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe2 Then
                        .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 14.7D, 17.5D, 22D, 0D) / 1000D
                    ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe3 Then
                        .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 12.2D, 14.1D, 18.3D, 0D) / 1000D
                    ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe4 Then
                        .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 9.8D, 12.1D, 13.4D, 0D) / 1000D
                    End If
                Else 'chiave platino
                    Dim tassoA As Decimal
                    Dim tassoB As Decimal

                    If ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe1 Then
                        tassoA = Choose(TipoAbitazioneDimora, 4.4D, 4.8D, 6.8D, 0D) / 1000D
                        tassoB = Choose(TipoAbitazioneDimora, 41.6D, 45.1D, 61.1D, 0D) / 1000D
                    ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe2 Then
                        tassoA = Choose(TipoAbitazioneDimora, 3.6D, 4D, 5.3D, 0D) / 1000D
                        tassoB = Choose(TipoAbitazioneDimora, 35.5D, 38.5D, 48.9D, 0D) / 1000D
                    ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe3 Then
                        tassoA = Choose(TipoAbitazioneDimora, 3.2D, 3.5D, 4.1D, 0D) / 1000D
                        tassoB = Choose(TipoAbitazioneDimora, 29.3D, 30.9D, 37.9D, 0D) / 1000D
                    ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe4 Then
                        tassoA = Choose(TipoAbitazioneDimora, 2.8D, 3.1D, 3.7D, 0D) / 1000D
                        tassoB = Choose(TipoAbitazioneDimora, 26.9D, 30.3D, 34.2D, 0D) / 1000D
                    End If

                    If .Partita.SommaAssicurata > 0.5D * PartitaFurtoContenuto.SommaAssicurata Then
                        FurtoInCassaforteScelta = FurtoInCassaforteSceltaEnum.SceltaB
                    Else
                        FurtoInCassaforteScelta = FurtoInCassaforteSceltaEnum.SceltaA
                    End If

                    If FurtoInCassaforteScelta = FurtoInCassaforteSceltaEnum.SceltaA Then
                        .Tariffa.Tasso = tassoA
                        .Tariffa.Base = 0D
                    ElseIf FurtoInCassaforteScelta = FurtoInCassaforteSceltaEnum.SceltaB Then
                        .Tariffa.Tasso = 0D
                        .Tariffa.Base = tassoA * PartitaFurtoContenuto.SommaAssicurata / 2D + tassoB * (.Partita.SommaAssicurata - PartitaFurtoContenuto.SommaAssicurata / 2D)
                    End If
                End If

                If .IsAttivo And .SommaAssicurataAttiva <= 0D Then
                    .SetNonDisponibile(.Garanzia.Descrizione & " non può avere somma assicurata a zero")
                End If
            End With

            With CoperturaFurtoPreziosiValori
                .Tariffa.Tasso = 0D
                If FurtoChiave = FurtoChiaveEnum.ChiaveORO Then
                    FurtoPreziosiValoriScelta = 0
                    If ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe1 Then
                        .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 46.6D, 51.2D, 82.2D, 0D) / 1000D
                    ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe2 Then
                        .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 30.2D, 35.7D, 60.3D, 0D) / 1000D
                    ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe3 Then
                        .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 24.4D, 27.5D, 45.8D, 0D) / 1000D
                    ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe4 Then
                        .Tariffa.Tasso = Choose(TipoAbitazioneDimora, 20.8D, 24.2D, 38.5D, 0D) / 1000D
                    End If
                Else
                    Dim tassoA As Decimal
                    Dim tassoB As Decimal

                    If ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe1 Then
                        tassoA = Choose(TipoAbitazioneDimora, 8.2D, 9D, 12.6D, 0D) / 1000D
                        tassoB = Choose(TipoAbitazioneDimora, 58.3D, 62.5D, 101.1D, 0D) / 1000D
                    ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe2 Then
                        tassoA = Choose(TipoAbitazioneDimora, 6.7D, 7.5D, 9.8D, 0D) / 1000D
                        tassoB = Choose(TipoAbitazioneDimora, 41.7D, 46.3D, 76.4D, 0D) / 1000D
                    ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe3 Then
                        tassoA = Choose(TipoAbitazioneDimora, 5.9D, 6.4D, 7.6D, 0D) / 1000D
                        tassoB = Choose(TipoAbitazioneDimora, 35.1D, 37.3D, 56.9D, 0D) / 1000D
                    ElseIf ClasseTerritorialeFurto = ClasseTerritorialeFurtoEnum.Classe4 Then
                        tassoA = Choose(TipoAbitazioneDimora, 5.2D, 5.7D, 6.8D, 0D) / 1000D
                        tassoB = Choose(TipoAbitazioneDimora, 29.3D, 31.6D, 48.9D, 0D) / 1000D
                    End If

                    If .Partita.SommaAssicurata > 0.5D * PartitaFurtoContenuto.SommaAssicurata Then
                        FurtoPreziosiValoriScelta = FurtoPreziosiValoriSceltaEnum.SceltaB
                    Else
                        FurtoPreziosiValoriScelta = FurtoPreziosiValoriSceltaEnum.SceltaA
                    End If

                    If FurtoPreziosiValoriScelta = FurtoPreziosiValoriSceltaEnum.SceltaA Then
                        .Tariffa.Tasso = tassoA
                        .Tariffa.Base = 0D
                    ElseIf FurtoPreziosiValoriScelta = FurtoPreziosiValoriSceltaEnum.SceltaB Then
                        .Tariffa.Tasso = 0D
                        .Tariffa.Base = tassoA * PartitaFurtoContenuto.SommaAssicurata / 2D + tassoB * (.Partita.SommaAssicurata - PartitaFurtoContenuto.SommaAssicurata / 2D)
                    End If

                End If
                If .IsAttivo And .SommaAssicurataAttiva <= 0D Then
                    .SetNonDisponibile(.Garanzia.Descrizione & " non può avere somma assicurata a zero")
                End If
            End With

            With CoperturaFurtoValoriDimoraAbituale
                If FurtoValoriDimoraAbitualeDenaro = 0 Then FurtoValoriDimoraAbitualeDenaro = FurtoValoriDimoraAbitualeDenaroEnum.Scelta05
                If FurtoValoriDimoraAbitualeValori = 0 Then FurtoValoriDimoraAbitualeValori = FurtoValoriDimoraAbitualeValoriEnum.Scelta40
                .Tariffa.Tasso = 0D
                .Partita.SommaAssicurata = CoperturaFurtoContenuto.PremioAttivoCrudo
                If FurtoValoriDimoraAbitualeDenaro = FurtoValoriDimoraAbitualeDenaroEnum.Scelta05 Then
                    If FurtoValoriDimoraAbitualeValori = FurtoValoriDimoraAbitualeValoriEnum.Scelta40 Then
                        .Tariffa.Tasso = 0.4D
                    ElseIf FurtoValoriDimoraAbitualeValori = FurtoValoriDimoraAbitualeValoriEnum.Scelta50 Then
                        .Tariffa.Tasso = 0.5D
                    End If
                ElseIf FurtoValoriDimoraAbitualeDenaro = FurtoValoriDimoraAbitualeDenaroEnum.Scelta10 Then
                    If FurtoValoriDimoraAbitualeValori = FurtoValoriDimoraAbitualeValoriEnum.Scelta40 Then
                        .Tariffa.Tasso = 0.5D
                    ElseIf FurtoValoriDimoraAbitualeValori = FurtoValoriDimoraAbitualeValoriEnum.Scelta50 Then
                        .Tariffa.Tasso = 0.55D
                    End If
                End If
            End With

            With CoperturaFurtoValoriDimoraSaltuaria
                .Partita.SommaAssicurata = CoperturaFurtoContenuto.PremioAttivoCrudo
                .Tariffa.Tasso = 0.45D
            End With

            With CoperturaFurtoPannelliSolari
                If .Garanzia.Massimale = 0 And FurtoChiave = FurtoChiaveEnum.ChiaveORO Then
                    .Garanzia.Massimale = 5000D
                ElseIf .Garanzia.Massimale < 10000D And FurtoChiave = FurtoChiaveEnum.ChiavePLATINO Then
                    .Garanzia.Massimale = 10000D
                ElseIf .Garanzia.Massimale = 15000D And FurtoChiave = FurtoChiaveEnum.ChiaveORO Then
                    .Garanzia.Massimale = 10000D
                End If

                .Tariffa.Base = 0D
                If .Garanzia.Massimale = 5000D Then
                    .Tariffa.Base = 24D
                ElseIf .Garanzia.Massimale = 10000D And FurtoChiave = FurtoChiaveEnum.ChiaveORO Then
                    .Tariffa.Base = 46D
                ElseIf .Garanzia.Massimale = 10000D And FurtoChiave = FurtoChiaveEnum.ChiavePLATINO Then
                    .Tariffa.Base = 49D
                ElseIf .Garanzia.Massimale = 15000D And FurtoChiave = FurtoChiaveEnum.ChiavePLATINO Then
                    .Tariffa.Base = 70D
                End If
            End With

            With CoperturaFurtoMezziChiusura
                .Partita.SommaAssicurata = CoperturaFurtoContenuto.PremioAttivoCrudo _
                                         + CoperturaFurtoPreziosiValori.PremioAttivoCrudo _
                                         + CoperturaFurtoInCassaforte.PremioAttivoCrudo _
                                         + CoperturaFurtoValoriDimoraAbituale.PremioAttivoCrudo
                .Tariffa.Tasso = -0.1D
            End With

            With CoperturaFurtoImpiantoAllarme
                .Partita.SommaAssicurata = CoperturaFurtoContenuto.PremioAttivoCrudo _
                                         + CoperturaFurtoPreziosiValori.PremioAttivoCrudo _
                                         + CoperturaFurtoInCassaforte.PremioAttivoCrudo _
                                         + CoperturaFurtoValoriDimoraAbituale.PremioAttivoCrudo
                .Tariffa.Tasso = -0.1D
            End With

            With CoperturaFurtoFranchigia
                .Partita.SommaAssicurata = CoperturaFurtoContenuto.PremioAttivoCrudo _
                                         + CoperturaFurtoEstensioneGaranziaBase.PremioAttivoCrudo _
                                         + CoperturaFurtoEsternoPlatino.PremioAttivoCrudo _
                                         + CoperturaFurtoPreziosiValori.PremioAttivoCrudo _
                                         + CoperturaFurtoInCassaforte.PremioAttivoCrudo _
                                         + CoperturaFurtoValoriDimoraAbituale.PremioAttivoCrudo _
                                         + CoperturaFurtoValoriDimoraSaltuaria.PremioAttivoCrudo _
                                         + CoperturaFurtoPannelliSolari.PremioAttivoCrudo
                If .Garanzia.Franchigia = 0 Then .Garanzia.Franchigia = 500D
                If .Garanzia.Franchigia = 500D Then
                    .Tariffa.Tasso = -0.1D
                ElseIf .Garanzia.Franchigia = 750D Then
                    .Tariffa.Tasso = -0.2D
                End If
            End With
        End Sub


        'essig

        Public Function GetComune() As Comune
            Return Luogo.Comuni.Find(Function(c As Comune) c.CodiceIstat = Comune)
        End Function

        Public Function CoperturaIncendioFenomeniAtmosfericiFranchigia() As Integer
            Return -CInt(CoperturaIncendioFenomeniAtmosferici.IsAttivo And (CoperturaIncendioFenomeniAtmosferici.Garanzia.Scoperto = 0D))
        End Function

        Public Function CoperturaIncendioFenomeniAtmosfericiScoperto() As Integer
            Return -CInt(CoperturaIncendioFenomeniAtmosferici.IsAttivo And (CoperturaIncendioFenomeniAtmosferici.Garanzia.Scoperto > 0D))
        End Function

        Public Function CoperturaIncendioFenomeniAtmosfericiLargeFranchigia() As Integer
            Return -CInt(CoperturaIncendioFenomeniAtmosfericiLarge.IsAttivo And (CoperturaIncendioFenomeniAtmosfericiLarge.Garanzia.Combinazione <> 25010D))
        End Function

        Public Function CoperturaIncendioFenomeniAtmosfericiLargeScoperto() As Integer
            Return -CInt(CoperturaIncendioFenomeniAtmosferici.IsAttivo And (CoperturaIncendioFenomeniAtmosfericiLarge.Garanzia.Combinazione = 25010D))
        End Function

        Public Function CoperturaFurtoEsternoOroBagagliLimite() As Decimal
            Return IIf(CoperturaFurtoEsternoOro.Garanzia.Massimale = 500D, 20D, 15D)
        End Function
        Public Function CoperturaFurtoEsternoOroBagagliMassimale() As Decimal
            Return CoperturaFurtoEsternoOro.Garanzia.Massimale
        End Function
        Public Function CoperturaFurtoEsternoOroEffettiPersonaliLimite() As Decimal
            Return CoperturaFurtoEsternoOro.Garanzia.Limite
        End Function
        Public Function NumeroBene() As Integer
            Return 1 + youCasa.AbitazioneX.IndexOf(Me)
        End Function

        Public Function HiddenNumeroOggetto() As Integer
            Return 2 + youCasa.AbitazioneX.IndexOf(Me)
        End Function
        '
    End Class
End Namespace
