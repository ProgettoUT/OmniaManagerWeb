Namespace P01263
    Public Class P01263DE
        Inherits P00000DE

        Public DecodeFormulaSezione As New Dizionario(Of Integer, String)
        Public DecodeMalattiaRicoveroIstitutoCuramassimale As New Dizionario(Of Decimal, String)

        Sub New()
            With DecodeSezione
                .Add(TipoSezione.Malattia, "Malattia e infortuni")
                .Add(TipoSezione.Assistenza, "Assistenza")
            End With

            With DecodePartita
                .Add(TipoPartita.Malattia, "Malattia e infortuni")
                .Add(TipoPartita.Assistenza, "Assistenza")
            End With

            With DecodeGaranzia
                .Add(TipoGaranzia.MalattiaBase, "Assicurato")
                .Add(TipoGaranzia.MalattiaRicoveroIstitutoCura, "Indennita' giornaliera per ricoveri in istituto di cura")
                .Add(TipoGaranzia.MalattiaRicoveroFranchigia, "Franchigia assoluta di 5 giorni")
                .Add(TipoGaranzia.MalattiaConvalescenza, "Indennita' giornaliera per convalescenza")
                .Add(TipoGaranzia.MalattiaPostRicovero, "Ospedalizzazione domiciliare post ricovero")
                .Add(TipoGaranzia.MalattiaImmobilizzazione, "Indennita' giornaliera da immobilizzazione")
                .Add(TipoGaranzia.MalattiaGrandeIntervento, "Grande intervento chirurgico")
                .Add(TipoGaranzia.MalattiaEnergy, "Energy")
                .Add(TipoGaranzia.MalattiaEnergySpesePrePostRicovero, "Spese Pre e Post Ricovero")
                .Add(TipoGaranzia.MalattiaEnergyAssistenzaInfermieristica, "Spese per l'assistenza infermieristica ospedaliera")
                .Add(TipoGaranzia.MalattiaEnergyRettaAccompagnatore, "Spese per la retta dell'accompagnatore")
                .Add(TipoGaranzia.MalattiaEnergyRaddoppioIndennita, "Raddoppio indennita' ricovero")
                .Add(TipoGaranzia.AssistenzaBase, "Assistenza")
            End With

            With DecodeFrazionamenti
                .Add(FrazionamentiEnum.annuale, "annuale")
                .Add(FrazionamentiEnum.semestrale, "semestrale")
                .Add(FrazionamentiEnum.quadrimestrale, "quadrimestrale")
                .Add(FrazionamentiEnum.trimestrale, "trimestrale")
                .Add(FrazionamentiEnum.Personalizzato, "Mensile Finitalia")
            End With

            With DecodeFormulaSezione
                .Add(FormulaSezioneEnum.Light, "Base light")
                .Add(FormulaSezioneEnum.Base, "Base")
            End With

            With DecodeMalattiaRicoveroIstitutoCuramassimale
                .Add(50, "50")
                .Add(60, "60")
                .Add(70, "70")
                .Add(80, "80")
                .Add(90, "90")
                .Add(100, "100")
                .Add(110, "110")
                .Add(120, "120")
                .Add(130, "130")
                .Add(140, "140")
                .Add(150, "150")
                .Add(160, "160")
                .Add(170, "170")
                .Add(180, "180")
                .Add(190, "190")
                .Add(200, "200")
                .Add(250, "250")
            End With
        End Sub
    End Class
End Namespace
