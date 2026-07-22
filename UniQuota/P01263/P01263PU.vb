Namespace P01263
    <Serializable()> Public Class assicurato

        Public Ricovero As Ricovero

        Public FormulaSezione As FormulaSezioneEnum
        Public Nominativo As String
        Public Eta As Integer = 99

        'Malattia
        Public CoperturaMalattia As New CoperturaComposta()
        'Public PartitaMalattiaRicoveroIstitutoCura As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaRicoveroIstitutoCura As New CoperturaSingola(New Garanzia(TipoGaranzia.MalattiaRicoveroIstitutoCura))
        'Public PartitaMalattiaRicoveroFranchigia As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaRicoveroFranchigia As New CoperturaSingola(New Garanzia(TipoGaranzia.MalattiaRicoveroFranchigia))
        'Public PartitaMalattiaConvalescenza As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaConvalescenza As New CoperturaSingola(New Garanzia(TipoGaranzia.MalattiaConvalescenza))
        Public PartitaMalattiaPostRicovero As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaPostRicovero As New CoperturaSingola(PartitaMalattiaPostRicovero, New Garanzia(TipoGaranzia.MalattiaPostRicovero))
        'Public PartitaMalattiaImmobilizzazione As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaImmobilizzazione As New CoperturaSingola(New Garanzia(TipoGaranzia.MalattiaImmobilizzazione))
        Public PartitaMalattiaGrandeIntervento As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaGrandeIntervento As New CoperturaSingola(PartitaMalattiaGrandeIntervento, New Garanzia(TipoGaranzia.MalattiaGrandeIntervento))
        'Public PartitaMalattiaEnergy As New Partita(TipoPartita.Malattia)

        Public CoperturaMalattiaEnergy As New CoperturaComposta() ' Singola(PartitaMalattiaEnergy, New Garanzia(TipoGaranzia.MalattiaEnergy))
        'Public PartitaMalattiaEnergySpesePrePostRicovero As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaEnergySpesePrePostRicovero As New CoperturaSingola(New Garanzia(TipoGaranzia.MalattiaEnergySpesePrePostRicovero))
        'Public PartitaMalattiaEnergyAssistenzaInfermieristica As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaEnergyAssistenzaInfermieristica As New CoperturaSingola(New Garanzia(TipoGaranzia.MalattiaEnergyAssistenzaInfermieristica))
        'Public PartitaMalattiaEnergyRettaAccompagnatore As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaEnergyRettaAccompagnatore As New CoperturaSingola(New Garanzia(TipoGaranzia.MalattiaEnergyRettaAccompagnatore))
        'Public PartitaMalattiaEnergyRaddoppioIndennita As New Partita(TipoPartita.Malattia)
        Public CoperturaMalattiaEnergyRaddoppioIndennita As New CoperturaSingola(New Garanzia(TipoGaranzia.MalattiaEnergyRaddoppioIndennita))

        'Assistenza
        Public CoperturaAssistenza As New CoperturaSingola(New Partita(TipoPartita.Assistenza), New Garanzia(TipoGaranzia.AssistenzaBase))

        Public Sub New(ByVal Ricovero As Ricovero)
            Me.Ricovero = Ricovero

            With CoperturaMalattia
                .Sezione = Ricovero.SezioneMalattia
                .AddCopertura(CoperturaMalattiaRicoveroIstitutoCura)
                .AddCopertura(CoperturaMalattiaRicoveroFranchigia)
                .AddCopertura(CoperturaMalattiaConvalescenza)
                .AddCopertura(CoperturaMalattiaPostRicovero)
                .AddCopertura(CoperturaMalattiaImmobilizzazione)
                .AddCopertura(CoperturaMalattiaGrandeIntervento)
                .AddCopertura(CoperturaMalattiaEnergy)
                CoperturaMalattiaEnergy.AddCopertura(CoperturaMalattiaEnergySpesePrePostRicovero)
                CoperturaMalattiaEnergy.AddCopertura(CoperturaMalattiaEnergyAssistenzaInfermieristica)
                CoperturaMalattiaEnergy.AddCopertura(CoperturaMalattiaEnergyRettaAccompagnatore)
                CoperturaMalattiaEnergy.AddCopertura(CoperturaMalattiaEnergyRaddoppioIndennita)
            End With

            With CoperturaAssistenza
                .Sezione = Ricovero.SezioneAssistenza
            End With
        End Sub

        Public Sub ValidaSezioneMalattiaAssistenza()
            Dim AssicuratoValidato As Boolean
            If Eta < 0 Or Eta > 75 Then
                Ricovero.SetNonDisponibile("Indicare l'età dell'assicurato (da 0 a 75 anni)")
            Else
                AssicuratoValidato = True
            End If


            CoperturaMalattia.DipendeDa(True)

            CoperturaMalattiaRicoveroIstitutoCura.ObbligatoriaDa(CoperturaMalattia.IsAttivo)
            CoperturaMalattiaConvalescenza.ObbligatoriaDa(CoperturaMalattiaRicoveroIstitutoCura.IsAttivo And FormulaSezione = FormulaSezioneEnum.Base)
            CoperturaMalattiaPostRicovero.ObbligatoriaDa(CoperturaMalattiaRicoveroIstitutoCura.IsAttivo And FormulaSezione = FormulaSezioneEnum.Base)
            CoperturaMalattiaImmobilizzazione.ObbligatoriaDa(CoperturaMalattiaRicoveroIstitutoCura.IsAttivo)

            CoperturaMalattiaRicoveroFranchigia.DipendeDa(CoperturaMalattiaRicoveroIstitutoCura.IsAttivo)
            CoperturaMalattiaGrandeIntervento.DipendeDa(CoperturaMalattiaRicoveroIstitutoCura.IsAttivo)

            CoperturaMalattiaEnergy.DipendeDa(CoperturaMalattiaRicoveroIstitutoCura.IsAttivo And FormulaSezione = FormulaSezioneEnum.Base)
            CoperturaMalattiaEnergySpesePrePostRicovero.ObbligatoriaDa(CoperturaMalattiaEnergy.IsAttivo)
            CoperturaMalattiaEnergyAssistenzaInfermieristica.ObbligatoriaDa(CoperturaMalattiaEnergy.IsAttivo)
            CoperturaMalattiaEnergyRettaAccompagnatore.ObbligatoriaDa(CoperturaMalattiaEnergy.IsAttivo)
            CoperturaMalattiaEnergyRaddoppioIndennita.ObbligatoriaDa(CoperturaMalattiaEnergy.IsAttivo)

            CoperturaAssistenza.ObbligatoriaDa(CoperturaMalattiaRicoveroIstitutoCura.IsAttivo)


            Dim tassobase As Decimal
            With CoperturaMalattiaRicoveroIstitutoCura
                If .Garanzia.Massimale = 0 Then .Garanzia.Massimale = 50
            End With

            CoperturaMalattiaConvalescenza.Garanzia.Massimale = CoperturaMalattiaRicoveroIstitutoCura.Garanzia.Massimale
            CoperturaMalattiaPostRicovero.Garanzia.Massimale = 2000D
            CoperturaMalattiaImmobilizzazione.Garanzia.Massimale = CoperturaMalattiaRicoveroIstitutoCura.Garanzia.Massimale

            CoperturaAssistenza.Partita.SommaAssicurata = CoperturaMalattiaRicoveroIstitutoCura.MassimaleAttivo
            CoperturaMalattiaPostRicovero.Partita.SommaAssicurata = CoperturaMalattiaRicoveroIstitutoCura.MassimaleAttivo

            If FormulaSezione = FormulaSezioneEnum.Base Then
                tassobase = Ricovero.Tabella.getPremio(Eta, P01263TR.Colonna.TassoBase)
                CoperturaMalattiaRicoveroIstitutoCura.Tariffa.Tasso = 0.506 * tassobase
                CoperturaMalattiaConvalescenza.Tariffa.Tasso = 0.456 * tassobase
                CoperturaMalattiaPostRicovero.Tariffa.Tasso = 0.01 * tassobase
                CoperturaMalattiaImmobilizzazione.Tariffa.Tasso = 0.023 * tassobase
                CoperturaAssistenza.Tariffa.Tasso = 0.005 * tassobase
            Else
                tassobase = Ricovero.Tabella.getPremio(Eta, P01263TR.Colonna.TassoLight)
                CoperturaMalattiaRicoveroIstitutoCura.Tariffa.Tasso = 0.946 * tassobase
                CoperturaMalattiaConvalescenza.Tariffa.Tasso = 0
                CoperturaMalattiaPostRicovero.Tariffa.Tasso = 0
                CoperturaMalattiaImmobilizzazione.Tariffa.Tasso = 0.044 * tassobase
                CoperturaAssistenza.Tariffa.Tasso = 0.01 * tassobase
            End If


            With CoperturaMalattiaRicoveroFranchigia
                .Tariffa.Base = -0.3D * CoperturaMalattiaRicoveroIstitutoCura.PremioAttivoCrudo
            End With

            With CoperturaMalattiaGrandeIntervento
                .Garanzia.Massimale = 300 * CoperturaMalattiaRicoveroIstitutoCura.MassimaleAttivo
                If .Garanzia.Massimale > 35000D Then .Garanzia.Massimale = 35000D

                If CoperturaMalattiaRicoveroIstitutoCura.Garanzia.Massimale < 110 Then
                    .Tariffa.Base = CoperturaMalattiaRicoveroIstitutoCura.MassimaleAttivo * Ricovero.Tabella.getPremio(Eta, P01263TR.Colonna.TassoGI)
                Else
                    .Tariffa.Base = Ricovero.Tabella.getPremio(Eta, P01263TR.Colonna.ImportoGI)
                End If
            End With

            Dim baseEnergy = CoperturaMalattiaRicoveroIstitutoCura.MassimaleAttivo * Ricovero.Tabella.getPremio(Eta, P01263TR.Colonna.TassoEnergy)

            With CoperturaMalattiaEnergySpesePrePostRicovero
                .Garanzia.Massimale = 1000D
                .Tariffa.Base = 0.26D * baseEnergy
            End With

            With CoperturaMalattiaEnergyAssistenzaInfermieristica
                .Garanzia.Massimale = 0.5 * CoperturaMalattiaRicoveroIstitutoCura.MassimaleAttivo
                .Tariffa.Base = 0.315D * baseEnergy
            End With

            With CoperturaMalattiaEnergyRettaAccompagnatore
                .Garanzia.Massimale = 0.5 * CoperturaMalattiaRicoveroIstitutoCura.MassimaleAttivo
                .Tariffa.Base = 0.42D * baseEnergy
            End With

            With CoperturaMalattiaEnergyRaddoppioIndennita
                .Tariffa.Base = 0.005D * baseEnergy
            End With
        End Sub

    End Class
End Namespace
