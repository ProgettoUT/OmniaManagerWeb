<Serializable()> Public MustInherit Class Prodotto
    Inherits Premio

    <NonSerialized()> Public NomeFile As String
    <NonSerialized()> Public Messaggi As New Messaggi
    <NonSerialized()> Public NuovoPreventivo As Boolean
    <NonSerialized()> Public Decode As P00000DE
    <NonSerialized()> Public Stampato As Boolean
    Public Agenzia As New Agenzia
    Public Subagenzia As New Subagenzia
    Public Intermediario As New Intermediario
    Public Cliente As New Cliente

    Public CodiceRamoPolizza As String
    Public CodiceProdotto As String
    Public Edizione As String
    Public DataEntrataVigore As String
    Public DescrizioneProdotto As String

    Public DurataContrattualeMinimaInAnni As Integer
    Public DurataContrattualeMassimaInAnni As Integer
    Public PeriodoMoraInGiorni As Integer
    Public GiorniValiditaPreventivo As Integer = 60

    Public EmissioneAppendici As Boolean
    Public TacitoRinnovo As Boolean

    Public ContraenzaPersonaGiuridica As Boolean
    Public ContraenzaPersonaFisica As Boolean

    Public AliquotaImpostaIncendio As Decimal = 0.2225D
    Public AliquotaImpostaFurto As Decimal = 0.2225D
    Public AliquotaImpostaResponsabilitaCivile As Decimal = 0.2225D
    Public AliquotaImpostaTutelaLegale As Decimal = 0.2125D
    Public AliquotaImpostaAssistenza As Decimal = 0.1D
    Public AliquotaImpostaDanniAcqua As Decimal = 0.2225D
    Public AliquotaImpostaInfortuni As Decimal = 0.025D
    Public AliquotaImpostaRca As Decimal = 0.125D

    Public PremioMinimoPrimaRata As Decimal = 0D
    Public PremioMinimoRataSuccessiva As Decimal = 0D
    Public PremioMinimoAnnuoNetto As Decimal = 0D
    Public PremioMinimoAnnuoLordo As Decimal = 0D

    <NonSerialized()> Public PremioAnnuo As Decimal = 0D
    <NonSerialized()> Public PremioRata As Decimal = 0D
    <NonSerialized()> Public PremioPrimaRata As Decimal = 0D
    <NonSerialized()> Public PremioRataSuccessiva As Decimal = 0D

    Public FrazionamentoInteressiSemestrale As Decimal = 0.03D
    Public FrazionamentoInteressiQuadrimestrale As Decimal = 0.03D
    Public FrazionamentoInteressiTrimestrale As Decimal = 0.03D
    Public FrazionamentoInteressiBimestrale As Decimal = 0.03D
    Public FrazionamentoInteressiMensile As Decimal = 0.03D
    Public FrazionamentoMinimoMesi As Decimal = 2D
    Public FrazionamentoInteressiPersonalizzato As Decimal = 0D
    Public FrazionamentoFrazionePersonalizzato As Decimal = 11D

    Public EscludiFlex As Boolean
    Public Flexi As Decimal = 0

    Public Interessi As Decimal = 0
    Public Durata As Integer = 1
    Public Periodo As PeriodoEnum = PeriodoEnum.Anni
    Public Frazionamento As FrazionamentiEnum = FrazionamentiEnum.Annuale
    Public Indicizzazione As StatoCopertura = StatoCopertura.attiva
    Public Arrotondamento As Arrotondamento = Arrotondamento.EuroAllaFirma
    Public Note As String
    Public BaseTasse As BaseTasse = BaseTasse.BaseNetta
    Public Convenzione As New Convenzione
    Public Sezioni As New List(Of Sezione)
    Public EmailTo As String
    Public EmailDate As Date
    Public Sconti As Sconti
    Public EssigEsito As Essig.Esito

    Public Function NamespaceProdotto() As String
        Return Me.GetType.Namespace.Substring(1 + Me.GetType.Namespace.LastIndexOf("."))
    End Function

    Public Sub ValidaECalcola()
        CleanRD()
        AzzeraTariffa()
        Valida()
        Calcola()
    End Sub

    Public Overridable Sub Valida()
    End Sub

    Public Overridable Sub Calcola()
        AzzerraPremi()
        VerificaDurata()
        CalcolaListino()
        ImpostaSconto()
        CalcolaCoperture()
        CalcolaSconti()
        CalcolaTotaliPre()
        CalcolaTotali()
        CalcolaFrazionamento()
        CalcolaPostFrazionamento()
        ControlloPremioMinimo()
    End Sub

    Public Overrides Sub AzzerraPremi()
        MyBase.AzzerraPremi()
        For Each Sezione As Sezione In Sezioni
            Sezione.AzzerraPremi()
        Next
    End Sub

    Public Overridable Sub VerificaDurata()
        If Frazionamento <> FrazionamentiEnum.Temporaneo Then
            If DurataContrattualeMinimaInAnni > 0 And Durata < DurataContrattualeMinimaInAnni Then
                Durata = DurataContrattualeMinimaInAnni
            ElseIf DurataContrattualeMassimaInAnni > 0 And Durata > DurataContrattualeMassimaInAnni Then
                Durata = DurataContrattualeMassimaInAnni
            End If
        ElseIf Periodo = PeriodoEnum.Mesi Then
            If Durata < 1 Then
                Durata = 1
            ElseIf Durata > 12 Then
                Durata = 12
            End If
        ElseIf Periodo = PeriodoEnum.Giorni Then
            If Durata < 1 Then
                Durata = 1
            ElseIf Durata > 360 Then
                Durata = 360
            End If
        End If
    End Sub

    Public Overrides Sub CalcolaListino()
        For Each Sezione As Sezione In Sezioni
            Sezione.CalcolaListino()
            Me.SommaListino(Sezione)
        Next
    End Sub

    Public Overridable Sub ImpostaSconto()
    End Sub

    Public Overrides Sub CalcolaCoperture()
        For Each Sezione As Sezione In Sezioni
            Sezione.CalcolaCoperture()
            Sezione.CalcolaTotali()
        Next
    End Sub

    Public Overridable Sub CalcolaSconti()
    End Sub

    Public Overridable Sub CalcolaTotaliPre()
    End Sub

    Public Overrides Sub CalcolaTotali()
        For Each Sezione As Sezione In Sezioni
            Me.SommaPremi(Sezione)
        Next
        If RischioDirezione > StatoPremio.ClasseOK Then
            MyBase.AzzerraPremi()
        End If

        If Sconti IsNot Nothing Then
            For Each Sconto As Sconto In Sconti
                PremioNetto -= Sconto.NettoSconto
                PremioTasse -= Sconto.TasseSconto
                PremioLordo -= Sconto.LordoSconto
            Next

            If ModalitaVisualizzazione = ModalitaVisualizzazionePremi.PremioLordo Then
                PremioLabel = PremioLordo
            ElseIf ModalitaVisualizzazione = ModalitaVisualizzazionePremi.PremioNetto Then
                PremioLabel = PremioNetto
            End If
        End If
    End Sub


    Public Overridable Sub CalcolaFrazionamento()
        If Frazionamento = FrazionamentiEnum.Semestrale Then
            Interessi = Math.Round(PremioLordo * FrazionamentoInteressiSemestrale, 2, MidpointRounding.AwayFromZero)
            PremioPrimaRata = Math.Round((PremioLordo + Interessi) / 2, 2, MidpointRounding.AwayFromZero)
        ElseIf Frazionamento = FrazionamentiEnum.Quadrimestrale Then
            Interessi = Math.Round(PremioLordo * FrazionamentoInteressiQuadrimestrale, 2, MidpointRounding.AwayFromZero)
            PremioPrimaRata = Math.Round((PremioLordo + Interessi) / 3, 2, MidpointRounding.AwayFromZero)
        ElseIf Frazionamento = FrazionamentiEnum.Trimestrale Then
            Interessi = Math.Round(PremioLordo * FrazionamentoInteressiTrimestrale, 2, MidpointRounding.AwayFromZero)
            PremioPrimaRata = Math.Round((PremioLordo + Interessi) / 4, 2, MidpointRounding.AwayFromZero)
        ElseIf Frazionamento = FrazionamentiEnum.Bimestrale Then
            Interessi = Math.Round(PremioLordo * FrazionamentoInteressiBimestrale, 2, MidpointRounding.AwayFromZero)
            PremioPrimaRata = Math.Round((PremioLordo + Interessi) / 6, 2, MidpointRounding.AwayFromZero)
        ElseIf Frazionamento = FrazionamentiEnum.Mensile Then
            Interessi = Math.Round(PremioLordo * FrazionamentoInteressiMensile, 2, MidpointRounding.AwayFromZero)
            PremioPrimaRata = Math.Round((PremioLordo + Interessi) / 12, 2, MidpointRounding.AwayFromZero)
        ElseIf Frazionamento = FrazionamentiEnum.Personalizzato Then
            Interessi = Math.Round(PremioLordo * FrazionamentoInteressiPersonalizzato, 2, MidpointRounding.AwayFromZero)
            PremioPrimaRata = Math.Round((PremioLordo + Interessi) / FrazionamentoFrazionePersonalizzato, 2, MidpointRounding.AwayFromZero)
        ElseIf Frazionamento = FrazionamentiEnum.Temporaneo Then
            Interessi = 0D
            If Periodo = PeriodoEnum.Mesi Then
                PremioPrimaRata = Math.Round((PremioLordo) * (FrazionamentoMinimoMesi + Durata) / 12, 2, MidpointRounding.AwayFromZero)
            ElseIf Periodo = PeriodoEnum.Giorni Then
                PremioPrimaRata = Math.Round((PremioLordo) * (30 * FrazionamentoMinimoMesi + Durata) / 360, 2, MidpointRounding.AwayFromZero)
            End If
        ElseIf Frazionamento = FrazionamentiEnum.UnicoAnticipato Then
            Interessi = 0D
            PremioPrimaRata = Math.Round((PremioLordo) * Durata, 2, MidpointRounding.AwayFromZero)
        Else
            Interessi = 0D
            PremioPrimaRata = PremioLordo
        End If

        If Frazionamento = FrazionamentiEnum.UnicoAnticipato Then
            PremioRataSuccessiva = 0D
        ElseIf Frazionamento = FrazionamentiEnum.Temporaneo Then
            PremioRataSuccessiva = 0D
        Else
            PremioRataSuccessiva = PremioPrimaRata
        End If

        PremioAnnuo = PremioLordo + Interessi

        If Frazionamento = FrazionamentiEnum.UnicoAnticipato Then
            Indicizzazione = StatoCopertura.Inapplicabile
        ElseIf Indicizzazione = StatoCopertura.Inapplicabile Then
            Indicizzazione = StatoCopertura.attiva
        End If

    End Sub

    Public Overridable Sub CalcolaPostFrazionamento()

    End Sub

    Public Overridable Sub ControlloPremioMinimo()
        If PremioMinimoPrimaRata > 0 And PremioPrimaRata > 0 And PremioPrimaRata < PremioMinimoPrimaRata Then
            SetNonDisponibile(String.Format("Premio minimo prima rata {0} minore di {1}", FormatEuro(PremioPrimaRata), FormatEuro(PremioMinimoPrimaRata)))
        ElseIf PremioMinimoRataSuccessiva > 0 And PremioRataSuccessiva > 0 And PremioRataSuccessiva < PremioMinimoRataSuccessiva Then
            SetNonDisponibile(String.Format("Premio minimo rate successive {0} minore di {1}", FormatEuro(PremioRataSuccessiva), FormatEuro(PremioMinimoRataSuccessiva)))
        ElseIf PremioMinimoAnnuoNetto > 0 And PremioNetto > 0 And PremioNetto < PremioMinimoAnnuoNetto Then
            SetNonDisponibile(String.Format("Premio minimo annuo imponibile {0} minore di {1}", FormatEuro(PremioNetto), FormatEuro(PremioMinimoAnnuoNetto)))
        ElseIf PremioMinimoAnnuoLordo > 0 And PremioLordo > 0 And PremioLordo < PremioMinimoAnnuoLordo Then
            SetNonDisponibile(String.Format("Premio minimo annuo {0} minore di {1}", FormatEuro(PremioLordo), FormatEuro(PremioMinimoAnnuoLordo)))
        End If
    End Sub

    Public Overrides Sub CalcolaLog()
        logCalcolo = vbNullString
        For Each Sezione As Sezione In Sezioni
            Sezione.CalcolaLog()
        Next
        logCalcolo &= vbNewLine
        logCalcolo &= "TOTALE PREVENTIVO:" & vbNewLine
        logCalcolo &= LSet("  Imponibile", 30) & "= " & RSet(FormatNumber(PremioNetto), 15) & vbNewLine
        logCalcolo &= LSet("  Tasse", 30) & "= " & RSet(FormatNumber(PremioTasse), 15) & vbNewLine
        logCalcolo &= LSet("  Lordo", 30) & "= " & RSet(FormatNumber(PremioLordo), 15) & vbNewLine
        logCalcolo &= LSet("  Sconto", 30) & "= " & RSet(FormatNumber(ScontoTecnico), 15) & vbNewLine
        logCalcolo &= LSet("  Flex", 30) & "= " & RSet(FormatNumber(ScontoFlexi), 15) & vbNewLine
        logCalcolo &= LSet("  Interessi", 30) & "= " & RSet(FormatNumber(Interessi), 15) & vbNewLine
        logCalcolo &= LSet("  Premio annuo", 30) & "= " & RSet(FormatNumber(PremioAnnuo), 15) & vbNewLine
        'If PremioMinimoRata > 0 And PremioRata > 0 And PremioRata < PremioMinimoRata Then
        '    logCalcolo &= LSet("  Premio di Rata ", 30) & "= " & RSet(FormatNumber(PremioMinimoRata), 15) & _
        '        " (in quando " & FormatNumber(PremioRata) & " è minore della premio minimo di rata " & FormatNumber(PremioMinimoRata) & ")" & vbNewLine
        '    PremioRata = PremioMinimoRata

        'Else
        '    logCalcolo &= LSet("  Premio di Rata", 30) & "= " & RSet(FormatNumber(PremioRata), 15) & vbNewLine
        'End If
        logCalcolo &= LSet("  Premio di Rata", 30) & "= " & RSet(FormatNumber(PremioPrimaRata), 15) & vbNewLine
        logCalcolo &= LSet("  Indicizzazione", 30) & "= " & IIf(Indicizzazione, "SI", "NO") & vbNewLine

        logCalcolo &= vbNewLine
        logCalcolo &= "SCONTI APPLICATI:" & vbNewLine
        logCalcolo &= LSet("  Tecnico", 30) & "= " & RSet(FormatNumber(ScontoTecnico), 15) & vbNewLine
        logCalcolo &= LSet("  Convenzione", 30) & "= " & RSet(FormatNumber(ScontoConvenzione), 15) & vbNewLine
        logCalcolo &= LSet("  Flex", 30) & "= " & RSet(FormatNumber(ScontoFlexi), 15) & vbNewLine
        logCalcolo &= LSet("  TOTALE", 30) & "= " & RSet(FormatNumber(ScontoTecnico + ScontoConvenzione + ScontoFlexi), 15) & vbNewLine
        logCalcolo &= vbNewLine
        logCalcolo &= vbNewLine

        logCalcolo &= LSet("Garanzia", 100) & vbTab & RSet("Listino Netto", 15) & vbTab & RSet("Listino Lordo", 15) & vbNewLine
        For Each Copertura As CoperturaSingola In CopertureSingole()
            If Copertura.IsAttivo Then
                logCalcolo &= LSet(Copertura.Sezione.Descrizione & " - " & Copertura.Garanzia.Descrizione, 100) & vbTab & RSet(FormatNumber(Copertura.ListinoNetto), 15) & vbTab & RSet(FormatNumber(Copertura.ListinoLordo), 15) & vbNewLine
            End If
        Next

        If EssigEsito IsNot Nothing AndAlso EssigEsito.Params IsNot Nothing Then
            Dim params As New Dictionary(Of String, Decimal)
            Dim d As Decimal = 0D


            logCalcolo &= String.Format("{0}PARAMETRI ESSIG{0}", vbNewLine)
            For Each p In EssigEsito.Params
                logCalcolo &= String.Format("{0} = {1}{2}", p.Key, p.Value, vbNewLine)

                If Not Decimal.TryParse(p.Value, d) Then
                    d = 0D
                End If

                If params.ContainsKey(p.Key) Then
                    params(p.Key) = d
                Else
                    params.Add(p.Key, d)
                End If
            Next


            Dim UniquotaParams As New List(Of KeyValuePair(Of String, String))
            For Each Copertura As CoperturaSingola In CopertureSingole()
                If Copertura.IsAttivo Then
                    UniquotaParams.Add(New KeyValuePair(Of String, String)(Copertura.Sezione.Descrizione & " - " & Copertura.Garanzia.Descrizione, FormatNumber(Copertura.ListinoNetto)))
                    Dim key As String = Copertura.Sezione.Descrizione & " - " & Copertura.Garanzia.Descrizione
                    params.Add(key, Arrotonda(Copertura.ListinoNetto * (1D - Copertura.PercentualeScontoTecnico)))
                End If
            Next

            logCalcolo &= PrintEssigLog(params, True)
            logCalcolo &= PrintEssigLog(params, False)
        End If
    End Sub

    Public ReadOnly Property CopertureSingole() As List(Of CoperturaSingola)
        Get
            Dim lista As New List(Of CoperturaSingola)
            For Each Sezione As Sezione In Sezioni
                lista.AddRange(Sezione.CopertureSingole)
            Next
            Return lista
        End Get
    End Property

    Public Overrides Function CleanRD() As Boolean
        MyBase.CleanRD()

        For Each Sezione As Sezione In Sezioni
            Sezione.CleanRD()
        Next

        logCalcolo = vbNullString
    End Function

    Public Sub AzzeraTariffa()
        For Each Sezione As Sezione In Sezioni
            Sezione.AzzeraTariffa()
        Next
    End Sub

    ' richiamato anche in apertura di un file
    Public Overridable Sub New2()
    End Sub

    Public Overridable Sub Inizializza()
        If Frazionamento = 0 Then
            Frazionamento = FrazionamentiEnum.Annuale
        End If

        DescrizioniCoperture()

        If Convenzione Is Nothing Then
            Convenzione = New Convenzione
        End If
        For Each Sezione As Sezione In Sezioni
            Sezione.Inizializza()
        Next
    End Sub

    Public Sub DescrizioniCoperture(ByVal coperture As List(Of CoperturaSingola))
        For Each Copertura As Copertura In coperture
            Try
                With TryCast(Copertura, CoperturaSingola)
                    .Garanzia.Descrizione = Decode.DecodeGaranzia(.Garanzia.CodiceGaranzia)
                    If .Garanzia.Garanzie IsNot Nothing Then
                        For Each Garanzia As Garanzia In .Garanzia.Garanzie
                            Garanzia.Descrizione = Decode.DecodeGaranzia(Garanzia.CodiceGaranzia)
                        Next
                    End If
                    If .Partita IsNot Nothing Then
                        .Partita.Descrizione = Decode.DecodePartita(.Partita.TipoPartita)
                    End If
                End With
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
    End Sub

    Public Sub DescrizioniCoperture()
        DescrizioniCoperture(CopertureSingole)
    End Sub

    Public Overridable Function IdProdottoPerLog() As String
        Return CodiceProdotto
    End Function

    Protected Overrides Sub Finalize()
        If Stampato = False And NuovoPreventivo = True And PremioAnnuo > 0 Then
            Globale.LogNet.Add(IdProdottoPerLog, "V")
        End If
        MyBase.Finalize()
    End Sub

    Public Sub New()
        NuovoPreventivo = True
    End Sub

    Public MustOverride Sub Stampa(ByVal options As StampaOptions)

    'proprietà comuni uso essig

    Public Overridable Function HasEssig() As Boolean
        Return False
    End Function
    Public Overridable Function GetNewPES() As P00000ES
        Return Nothing
    End Function

    Public Overridable ReadOnly Property EssigScadenzaPolizza() As String
        Get
            Return Today.AddYears(1).ToString("dd/MM/yyyy")
        End Get
    End Property

    Public Overridable ReadOnly Property EssigTacitoRinnovo() As String
        Get
            Return "N"
        End Get
    End Property

    Public Overridable ReadOnly Property EssigRescindibilitaAnnuale() As String
        Get
            Return "N"
        End Get
    End Property

    Public Overridable ReadOnly Property EssigDeroga() As String
        Get
            Return "N"
        End Get
    End Property
    Public Overridable ReadOnly Property EssigTipoAdeguamento() As String
        Get
            If Indicizzazione = StatoCopertura.attiva Then
                Return "2"
            Else
                Return "0"
            End If
        End Get
    End Property

    Public ReadOnly Property EssigFlexi() As String
        Get
            Return Flexi * 100D
        End Get
    End Property

    Public ReadOnly Property EssigApplicaFlexi() As Boolean
        Get
            Return Flexi <> 0D
        End Get
    End Property

    Public Overridable Function PrintEssigLog(ByRef params As Dictionary(Of String, Decimal), ByVal ShowAll As Boolean) As String
    End Function

    Public Function PrintRowLog(ByRef params As Dictionary(Of String, Decimal), ByVal KeyEssig As String, ByVal KeyQuotatore As String, ByVal ShowAll As Boolean) As String
        Dim PremioEssig As Decimal = 0D
        Dim PremioQuotatore As Decimal = 0D

        For Each k In KeyEssig.Split("+")
            If params.ContainsKey(k) Then PremioEssig += params(k)
        Next

        For Each k In KeyQuotatore.Split("+")
            If params.ContainsKey(k) Then PremioQuotatore += params(k)
        Next

        If ShowAll = False And Math.Abs(PremioEssig - PremioQuotatore) < 0.05 Then Return ""

        Return LSet(KeyQuotatore, 50) & RSet(PremioEssig, 15) & RSet(PremioQuotatore, 15) & RSet(PremioEssig - PremioQuotatore, 15) & vbNewLine
    End Function

End Class
