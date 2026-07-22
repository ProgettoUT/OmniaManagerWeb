Namespace P01204
     Public Class assicuratoFE
        Public assicurato As assicurato
        Public Event Change(ByVal sender As Object, ByVal e As EventArgs)
        Public Event Remove(ByVal sender As Object, ByVal e As EventArgs)
        Public Event Help(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Private mPanels As TableLayoutPanel() = {TableLayoutPanel2, TableLayoutPanel3, TableLayoutPanel4}

        Private Sub RemoveUnita(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If MsgBox("Eliminare l'elemento selezionato?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                RaiseEvent Remove(Me, New EventArgs())
                Dispose()
            End If
        End Sub

        Private Sub ValuesChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            RaiseEvent Change(Me, New EventArgs())
        End Sub
        Private Sub TextBoxKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            If e.KeyChar = vbCr Then
                RaiseEvent Change(Me, New EventArgs())
            End If
        End Sub
        Private Sub MouseClickedHelp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            RaiseEvent Help(sender, e)
        End Sub

        Private Sub ControlloLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            'AgganciaHelp(Me, AddressOf MouseClickedHelp)
        End Sub

        Protected Sub AttachEvents()
            AddHandler cmdRemove.Click, AddressOf RemoveUnita
            AddHandler cmbTipoContraente.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbFormaCopertura.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbTipoRapporto.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbAttivita.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbInfortuniIPScelta.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbRicoveroConvalescenzaScelta.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbMalattiaRicoveroConvalescenzaScelta.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbInfortuniITSceta.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbSportClasseRischio.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbSportAgonisticoRicoveroConvalescenzaScelta.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbSportAltoRischioRicoveroConvalescenzaScelta.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbSportMotoRicoveroConvalescenzaScelta.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbSportAereiRicoveroConvalescenzaScelta.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler txtEta.Leave, AddressOf ValuesChanged
            AddHandler txtEta.KeyPress, AddressOf TextBoxKeyPress
            AddHandler txtNominativo.Leave, AddressOf ValuesChanged
            AddHandler txtNominativo.KeyPress, AddressOf TextBoxKeyPress
            AddHandler txtDescrizione.Leave, AddressOf ValuesChanged
            AddHandler txtDescrizione.KeyPress, AddressOf TextBoxKeyPress

            AddHandler chkInfortuni.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkInfortuniMorte.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniMorte.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniMorte.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkInfortuniIP.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniIP.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniIP.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkInfortuniIPRenditaVitalizia.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbInfortuniIPRenditaVitaliziamassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkInfortuniSpeseMediche.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbInfortuniSpeseMedichemassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkInfortuniRicoveroConvalescenza.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniRicoveroConvalescenza.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniRicoveroConvalescenza.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkInfortuniImmobilizzazione.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniImmobilizzazione.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniImmobilizzazione.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkInfortuniIT.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniIT.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniIT.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkInfortuniTabellaINAIL.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkInfortuniFranchigia3.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkInfortuniFranchigia0.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkInfortuniFranchigiaPlus.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkInfortuniFranchigiaDiff.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkInfortuniSVPartiAnatomiche.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkInfortuniSVIP.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkInfortuniForfaitFrattura.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkInfortuniForfaitRicoveroInfortunio.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkInfortuniGlobaleImmobilizzazione.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkInfortuniDannoEstetico.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkInfortuniMorteCircolazione.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkInfortuniNucleoFamiliare.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkSportAgonistico.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkSportAgonisticoMorte.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaSportAgonisticoMorte.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaSportAgonisticoMorte.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkSportAgonisticoIP.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaSportAgonisticoIP.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaSportAgonisticoIP.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkSportAgonisticoSpeseMediche.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbSportAgonisticoSpeseMedichemassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkSportAgonisticoRicoveroConvalescenza.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaSportAgonisticoRicoveroConvalescenza.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaSportAgonisticoRicoveroConvalescenza.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkSportAltoRischio.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkSportAltoRischioMorte.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaSportAltoRischioMorte.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaSportAltoRischioMorte.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkSportAltoRischioIP.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaSportAltoRischioIP.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaSportAltoRischioIP.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkSportAltoRischioSpeseMediche.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbSportAltoRischioSpeseMedichemassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkSportAltoRischioRicoveroConvalescenza.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaSportAltoRischioRicoveroConvalescenza.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaSportAltoRischioRicoveroConvalescenza.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkSportMoto.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkSportMotoMorte.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaSportMotoMorte.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaSportMotoMorte.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkSportMotoIP.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaSportMotoIP.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaSportMotoIP.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkSportMotoSpeseMediche.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbSportMotoSpeseMedichemassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkSportMotoRicoveroConvalescenza.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaSportMotoRicoveroConvalescenza.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaSportMotoRicoveroConvalescenza.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkSportAerei.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkSportAereiMorte.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaSportAereiMorte.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaSportAereiMorte.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkSportAereiIP.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaSportAereiIP.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaSportAereiIP.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkSportAereiSpeseMediche.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbSportAereiSpeseMedichemassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkSportAereiRicoveroConvalescenza.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaSportAereiRicoveroConvalescenza.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaSportAereiRicoveroConvalescenza.KeyPress, AddressOf TextBoxKeyPress

            AddHandler chkMalattia.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkMalattiaRicoveroConvalescenza.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkMalattiaForfaitRicovero.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaMalattiaRicoveroConvalescenza.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaMalattiaRicoveroConvalescenza.KeyPress, AddressOf TextBoxKeyPress

            AddHandler chkSalvaPremioBase.CheckedChanged, AddressOf ValuesChanged

            AddHandler chkAssistenzaBase.CheckedChanged, AddressOf ValuesChanged
        End Sub


        Public Sub New(ByVal decode As P01204DE, helpChm As HelpClass)
            ' Chiamata richiesta da Progettazione Windows Form.
            InitializeComponent()
            AttachCombo(cmbTipoContraente, decode.DecodeTipoContraente)
            AttachCombo(cmbFormaCopertura, decode.DecodeFormaCopertura)
            AttachCombo(cmbTipoRapporto, decode.DecodeTipoRapporto)
            AttachCombo(cmbAttivita, P01204TG.GetAttivita())
            AttachCombo(cmbInfortuniIPScelta, decode.DecodeInfortuniIPScelta)
            AttachCombo(cmbRicoveroConvalescenzaScelta, decode.DecodeRicoveroConvalescenzaScelta)
            AttachCombo(cmbMalattiaRicoveroConvalescenzaScelta, decode.DecodeRicoveroConvalescenzaScelta)
            AttachCombo(cmbInfortuniITSceta, decode.DecodeInfortuniITScelta)
            AttachCombo(cmbSportClasseRischio, decode.DecodeSportClasseRischio)
            AttachCombo(cmbSportAgonisticoRicoveroConvalescenzaScelta, decode.DecodeRicoveroConvalescenzaScelta)
            AttachCombo(cmbSportAltoRischioRicoveroConvalescenzaScelta, decode.DecodeRicoveroConvalescenzaScelta)
            AttachCombo(cmbSportMotoRicoveroConvalescenzaScelta, decode.DecodeRicoveroConvalescenzaScelta)
            AttachCombo(cmbSportAereiRicoveroConvalescenzaScelta, decode.DecodeRicoveroConvalescenzaScelta)
            AttachCombo(cmbInfortuniIPRenditaVitaliziamassimale, decode.DecodeInfortuniIPRenditaVitaliziaMassimale)
            AttachCombo(cmbInfortuniSpeseMedichemassimale, decode.DecodeInfortuniSpeseMedicheMassimale)
            AttachCombo(cmbSportAgonisticoSpeseMedichemassimale, decode.DecodeSportSpeseMedicheMassimale)
            AttachCombo(cmbSportAltoRischioSpeseMedichemassimale, decode.DecodeSportSpeseMedicheMassimale)
            AttachCombo(cmbSportMotoSpeseMedichemassimale, decode.DecodeSportSpeseMedicheMassimale)
            AttachCombo(cmbSportAereiSpeseMedichemassimale, decode.DecodeSportSpeseMedicheMassimale)
            AttachEvents()

            mPanels = {TableLayoutPanel2, TableLayoutPanel3, TableLayoutPanel4}
            AgganciaCheckAndLabel(mPanels)

            If helpChm.FileExists Then
                AgganciaHelp(Me, AddressOf MouseClickedHelp)
            End If
        End Sub

        Public Sub ControlsToPreventivo(ByVal diretto As Boolean)

            With assicurato

                If diretto Then
                    .TipoContraente = cmbTipoContraente.SelectedValue
                    .FormaCopertura = cmbFormaCopertura.SelectedValue
                    .TipoRapporto = cmbTipoRapporto.SelectedValue
                    .CodiceAttivita = cmbAttivita.SelectedValue
                    .InfortuniIPScelta = cmbInfortuniIPScelta.SelectedValue

                    .InfortuniITScelta = cmbInfortuniITSceta.SelectedValue
                    .SportClasseRischio = cmbSportClasseRischio.SelectedValue
                    .Eta = IntegerBox(txtEta)
                    .Nominativo = txtNominativo.Text
                    .Descrizione = txtDescrizione.Text

                    'Infortuni
                    .CoperturaInfortuni.Stato = EnabledAndChecked(chkInfortuni)
                    .CoperturaInfortuniMorte.Stato = EnabledAndChecked(chkInfortuniMorte)
                    .PartitaInfortuniMorte.SommaAssicurata = CurrencyBox(txtPartitaInfortuniMorte)
                    .CoperturaInfortuniIP.Stato = EnabledAndChecked(chkInfortuniIP)
                    .PartitaInfortuniIP.SommaAssicurata = CurrencyBox(txtPartitaInfortuniIP)
                    .InfortuniIPScelta = cmbInfortuniIPScelta.SelectedValue
                    .CoperturaInfortuniIPRenditaVitalizia.Stato = EnabledAndChecked(chkInfortuniIPRenditaVitalizia)
                    .CoperturaInfortuniIPRenditaVitalizia.Garanzia.massimale = cmbInfortuniIPRenditaVitaliziamassimale.SelectedValue
                    .CoperturaInfortuniSpeseMediche.Stato = EnabledAndChecked(chkInfortuniSpeseMediche)
                    .CoperturaInfortuniSpeseMediche.Garanzia.massimale = cmbInfortuniSpeseMedichemassimale.SelectedValue
                    .CoperturaInfortuniRicoveroConvalescenza.Stato = EnabledAndChecked(chkInfortuniRicoveroConvalescenza)
                    .PartitaInfortuniRicoveroConvalescenza.SommaAssicurata = CurrencyBox(txtPartitaInfortuniRicoveroConvalescenza)
                    .InfortuniRicoveroConvalescenzaScelta = cmbRicoveroConvalescenzaScelta.SelectedValue
                    .CoperturaInfortuniImmobilizzazione.Stato = EnabledAndChecked(chkInfortuniImmobilizzazione)
                    .PartitaInfortuniImmobilizzazione.SommaAssicurata = CurrencyBox(txtPartitaInfortuniImmobilizzazione)
                    .CoperturaInfortuniIT.Stato = EnabledAndChecked(chkInfortuniIT)
                    .PartitaInfortuniIT.SommaAssicurata = CurrencyBox(txtPartitaInfortuniIT)
                    .InfortuniITScelta = cmbInfortuniITSceta.SelectedValue
                    .CoperturaInfortuniTabellaINAIL.Stato = EnabledAndChecked(chkInfortuniTabellaINAIL)
                    .CoperturaInfortuniFranchigia3.Stato = EnabledAndChecked(chkInfortuniFranchigia3)
                    .CoperturaInfortuniFranchigia0.Stato = EnabledAndChecked(chkInfortuniFranchigia0)
                    .CoperturaInfortuniFranchigiaPlus.Stato = EnabledAndChecked(chkInfortuniFranchigiaPlus)
                    .CoperturaInfortuniFranchigiaDiff.Stato = EnabledAndChecked(chkInfortuniFranchigiaDiff)
                    .CoperturaInfortuniSVPartiAnatomiche.Stato = EnabledAndChecked(chkInfortuniSVPartiAnatomiche)
                    .CoperturaInfortuniSVIP.Stato = EnabledAndChecked(chkInfortuniSVIP)
                    .CoperturaInfortuniForfaitFrattura.Stato = EnabledAndChecked(chkInfortuniForfaitFrattura)
                    .CoperturaInfortuniForfaitRicovero.Stato = EnabledAndChecked(chkInfortuniForfaitRicoveroInfortunio)
                    .CoperturaInfortuniGlobaleImmobilizzazione.Stato = EnabledAndChecked(chkInfortuniGlobaleImmobilizzazione)
                    .CoperturaInfortuniDannoEstetico.Stato = EnabledAndChecked(chkInfortuniDannoEstetico)
                    .CoperturaInfortuniMorteCircolazione.Stato = EnabledAndChecked(chkInfortuniMorteCircolazione)
                    .CoperturaInfortuniNucleoFamiliare.Stato = EnabledAndChecked(chkInfortuniNucleoFamiliare)
                    .CoperturaSportAgonistico.Stato = EnabledAndChecked(chkSportAgonistico)
                    .SportClasseRischio = cmbSportClasseRischio.SelectedValue
                    .CoperturaSportAgonisticoMorte.Stato = EnabledAndChecked(chkSportAgonisticoMorte)
                    .PartitaSportAgonisticoMorte.SommaAssicurata = CurrencyBox(txtPartitaSportAgonisticoMorte)
                    .CoperturaSportAgonisticoIP.Stato = EnabledAndChecked(chkSportAgonisticoIP)
                    .PartitaSportAgonisticoIP.SommaAssicurata = CurrencyBox(txtPartitaSportAgonisticoIP)
                    .CoperturaSportAgonisticoSpeseMediche.Stato = EnabledAndChecked(chkSportAgonisticoSpeseMediche)
                    .CoperturaSportAgonisticoSpeseMediche.Garanzia.massimale = cmbSportAgonisticoSpeseMedichemassimale.SelectedValue
                    .CoperturaSportAgonisticoRicoveroConvalescenza.Stato = EnabledAndChecked(chkSportAgonisticoRicoveroConvalescenza)
                    .PartitaSportAgonisticoRicoveroConvalescenza.SommaAssicurata = CurrencyBox(txtPartitaSportAgonisticoRicoveroConvalescenza)
                    .SportAgonisticoRicoveroConvalescenzaScelta = cmbSportAgonisticoRicoveroConvalescenzaScelta.SelectedValue
                    .CoperturaSportAltoRischio.Stato = EnabledAndChecked(chkSportAltoRischio)
                    .CoperturaSportAltoRischioMorte.Stato = EnabledAndChecked(chkSportAltoRischioMorte)
                    .PartitaSportAltoRischioMorte.SommaAssicurata = CurrencyBox(txtPartitaSportAltoRischioMorte)
                    .CoperturaSportAltoRischioIP.Stato = EnabledAndChecked(chkSportAltoRischioIP)
                    .PartitaSportAltoRischioIP.SommaAssicurata = CurrencyBox(txtPartitaSportAltoRischioIP)
                    .CoperturaSportAltoRischioSpeseMediche.Stato = EnabledAndChecked(chkSportAltoRischioSpeseMediche)
                    .CoperturaSportAltoRischioSpeseMediche.Garanzia.massimale = cmbSportAltoRischioSpeseMedichemassimale.SelectedValue
                    .CoperturaSportAltoRischioRicoveroConvalescenza.Stato = EnabledAndChecked(chkSportAltoRischioRicoveroConvalescenza)
                    .PartitaSportAltoRischioRicoveroConvalescenza.SommaAssicurata = CurrencyBox(txtPartitaSportAltoRischioRicoveroConvalescenza)
                    .SportAltoRischioRicoveroConvalescenzaScelta = cmbSportAltoRischioRicoveroConvalescenzaScelta.SelectedValue
                    .CoperturaSportMoto.Stato = EnabledAndChecked(chkSportMoto)
                    .CoperturaSportMotoMorte.Stato = EnabledAndChecked(chkSportMotoMorte)
                    .PartitaSportMotoMorte.SommaAssicurata = CurrencyBox(txtPartitaSportMotoMorte)
                    .CoperturaSportMotoIP.Stato = EnabledAndChecked(chkSportMotoIP)
                    .PartitaSportMotoIP.SommaAssicurata = CurrencyBox(txtPartitaSportMotoIP)
                    .CoperturaSportMotoSpeseMediche.Stato = EnabledAndChecked(chkSportMotoSpeseMediche)
                    .CoperturaSportMotoSpeseMediche.Garanzia.massimale = cmbSportMotoSpeseMedichemassimale.SelectedValue
                    .CoperturaSportMotoRicoveroConvalescenza.Stato = EnabledAndChecked(chkSportMotoRicoveroConvalescenza)
                    .PartitaSportMotoRicoveroConvalescenza.SommaAssicurata = CurrencyBox(txtPartitaSportMotoRicoveroConvalescenza)
                    .SportMotoRicoveroConvalescenzaScelta = cmbSportMotoRicoveroConvalescenzaScelta.SelectedValue
                    .CoperturaSportAerei.Stato = EnabledAndChecked(chkSportAerei)
                    .CoperturaSportAereiMorte.Stato = EnabledAndChecked(chkSportAereiMorte)
                    .PartitaSportAereiMorte.SommaAssicurata = CurrencyBox(txtPartitaSportAereiMorte)
                    .CoperturaSportAereiIP.Stato = EnabledAndChecked(chkSportAereiIP)
                    .PartitaSportAereiIP.SommaAssicurata = CurrencyBox(txtPartitaSportAereiIP)
                    .CoperturaSportAereiSpeseMediche.Stato = EnabledAndChecked(chkSportAereiSpeseMediche)
                    .CoperturaSportAereiSpeseMediche.Garanzia.massimale = cmbSportAereiSpeseMedichemassimale.SelectedValue
                    .CoperturaSportAereiRicoveroConvalescenza.Stato = EnabledAndChecked(chkSportAereiRicoveroConvalescenza)
                    .PartitaSportAereiRicoveroConvalescenza.SommaAssicurata = CurrencyBox(txtPartitaSportAereiRicoveroConvalescenza)
                    .SportAereiRicoveroConvalescenzaScelta = cmbSportAereiRicoveroConvalescenzaScelta.SelectedValue

                    'Malattia
                    .CoperturaMalattia.Stato = EnabledAndChecked(chkMalattia)
                    .CoperturaMalattiaRicoveroConvalescenza.Stato = EnabledAndChecked(chkMalattiaRicoveroConvalescenza)
                    .PartitaMalattiaRicoveroConvalescenza.SommaAssicurata = CurrencyBox(txtPartitaMalattiaRicoveroConvalescenza)
                    .MalattiaRicoveroConvalescenzaScelta = cmbMalattiaRicoveroConvalescenzaScelta.SelectedValue
                    .CoperturaMalattiaForfaitRicovero.Stato = EnabledAndChecked(chkMalattiaForfaitRicovero)

                    'SalvaPremio
                    .CoperturaSalvaPremioBase.Stato = EnabledAndChecked(chkSalvaPremioBase)

                    'Assistenza
                    .CoperturaAssistenzaBase.Stato = EnabledAndChecked(chkAssistenzaBase)
                Else
                    cmbTipoContraente.SelectedValue = CInt(.TipoContraente)
                    cmbTipoContraente.Enabled = True
                    cmbFormaCopertura.SelectedValue = CInt(.FormaCopertura)
                    cmbFormaCopertura.Enabled = True
                    cmbTipoRapporto.SelectedValue = CInt(.TipoRapporto)
                    cmbTipoRapporto.Enabled = True
                    cmbAttivita.SelectedValue = .CodiceAttivita
                    cmbAttivita.Enabled = True
                    cmbInfortuniIPScelta.SelectedValue = CInt(.InfortuniIPScelta)
                    cmbInfortuniIPScelta.Enabled = True
                    cmbInfortuniITSceta.SelectedValue = CInt(.InfortuniITScelta)
                    cmbInfortuniITSceta.Enabled = True
                    cmbSportClasseRischio.SelectedValue = CInt(.SportClasseRischio)
                    cmbSportClasseRischio.Enabled = True
                    IntegerBox(txtEta) = .Eta
                    txtEta.Enabled = True
                    txtNominativo.Text = .Nominativo
                    txtNominativo.Enabled = True
                    txtDescrizione.Text = .Descrizione
                    txtDescrizione.Enabled = True

                    'Infortuni
                    EnabledAndChecked(chkInfortuni) = .CoperturaInfortuni.Stato
                    FormatEuro(lblInfortuni, .CoperturaInfortuni)
                    EnabledAndChecked(chkInfortuniMorte) = .CoperturaInfortuniMorte.Stato
                    CurrencyBox(txtPartitaInfortuniMorte) = .PartitaInfortuniMorte.SommaAssicurata
                    txtPartitaInfortuniMorte.Enabled = Enable(.CoperturaInfortuniMorte.Stato)
                    FormatEuro(lblInfortuniMorte, .CoperturaInfortuniMorte)
                    EnabledAndChecked(chkInfortuniIP) = .CoperturaInfortuniIP.Stato
                    CurrencyBox(txtPartitaInfortuniIP) = .PartitaInfortuniIP.SommaAssicurata
                    txtPartitaInfortuniIP.Enabled = Enable(.CoperturaInfortuniIP.Stato)
                    FormatEuro(lblInfortuniIP, .CoperturaInfortuniIP)
                    cmbInfortuniIPScelta.Enabled = Enable(.CoperturaInfortuniIP.Stato)
                    cmbInfortuniIPScelta.SelectedValue = CInt(.InfortuniIPScelta)
                    EnabledAndChecked(chkInfortuniIPRenditaVitalizia) = .CoperturaInfortuniIPRenditaVitalizia.Stato
                    FormatEuro(lblInfortuniIPRenditaVitalizia, .CoperturaInfortuniIPRenditaVitalizia)
                    cmbInfortuniIPRenditaVitaliziamassimale.Enabled = Enable(.CoperturaInfortuniIPRenditaVitalizia.Stato)
                    cmbInfortuniIPRenditaVitaliziamassimale.SelectedValue = .CoperturaInfortuniIPRenditaVitalizia.Garanzia.massimale
                    EnabledAndChecked(chkInfortuniSpeseMediche) = .CoperturaInfortuniSpeseMediche.Stato
                    FormatEuro(lblInfortuniSpeseMediche, .CoperturaInfortuniSpeseMediche)
                    cmbInfortuniSpeseMedichemassimale.Enabled = Enable(.CoperturaInfortuniSpeseMediche.Stato)
                    cmbInfortuniSpeseMedichemassimale.SelectedValue = .CoperturaInfortuniSpeseMediche.Garanzia.massimale
                    EnabledAndChecked(chkInfortuniRicoveroConvalescenza) = .CoperturaInfortuniRicoveroConvalescenza.Stato
                    CurrencyBox(txtPartitaInfortuniRicoveroConvalescenza) = .PartitaInfortuniRicoveroConvalescenza.SommaAssicurata
                    txtPartitaInfortuniRicoveroConvalescenza.Enabled = Enable(.CoperturaInfortuniRicoveroConvalescenza.Stato)
                    FormatEuro(lblInfortuniRicoveroConvalescenza, .CoperturaInfortuniRicoveroConvalescenza)
                    cmbRicoveroConvalescenzaScelta.Enabled = Enable(.CoperturaInfortuniRicoveroConvalescenza.Stato)
                    cmbRicoveroConvalescenzaScelta.SelectedValue = CInt(.InfortuniRicoveroConvalescenzaScelta)
                    EnabledAndChecked(chkInfortuniImmobilizzazione) = .CoperturaInfortuniImmobilizzazione.Stato
                    CurrencyBox(txtPartitaInfortuniImmobilizzazione) = .PartitaInfortuniImmobilizzazione.SommaAssicurata
                    txtPartitaInfortuniImmobilizzazione.Enabled = Enable(.CoperturaInfortuniImmobilizzazione.Stato)
                    FormatEuro(lblInfortuniImmobilizzazione, .CoperturaInfortuniImmobilizzazione)
                    EnabledAndChecked(chkInfortuniIT) = .CoperturaInfortuniIT.Stato
                    CurrencyBox(txtPartitaInfortuniIT) = .PartitaInfortuniIT.SommaAssicurata
                    txtPartitaInfortuniIT.Enabled = Enable(.CoperturaInfortuniIT.Stato)
                    FormatEuro(lblInfortuniIT, .CoperturaInfortuniIT)
                    cmbInfortuniITSceta.Enabled = Enable(.CoperturaInfortuniIT.Stato)
                    cmbInfortuniITSceta.SelectedValue = CInt(.InfortuniITScelta)
                    EnabledAndChecked(chkInfortuniTabellaINAIL) = .CoperturaInfortuniTabellaINAIL.Stato
                    FormatEuro(lblInfortuniTabellaINAIL, .CoperturaInfortuniTabellaINAIL)
                    EnabledAndChecked(chkInfortuniFranchigia3) = .CoperturaInfortuniFranchigia3.Stato
                    FormatEuro(lblInfortuniFranchigia3, .CoperturaInfortuniFranchigia3)
                    EnabledAndChecked(chkInfortuniFranchigia0) = .CoperturaInfortuniFranchigia0.Stato
                    FormatEuro(lblInfortuniFranchigia0, .CoperturaInfortuniFranchigia0)
                    EnabledAndChecked(chkInfortuniFranchigiaPlus) = .CoperturaInfortuniFranchigiaPlus.Stato
                    FormatEuro(lblInfortuniFranchigiaPlus, .CoperturaInfortuniFranchigiaPlus)
                    EnabledAndChecked(chkInfortuniFranchigiaDiff) = .CoperturaInfortuniFranchigiaDiff.Stato
                    FormatEuro(lblInfortuniFranchigiaDiff, .CoperturaInfortuniFranchigiaDiff)
                    EnabledAndChecked(chkInfortuniSVPartiAnatomiche) = .CoperturaInfortuniSVPartiAnatomiche.Stato
                    FormatEuro(lblInfortuniSVPartiAnatomiche, .CoperturaInfortuniSVPartiAnatomiche)
                    EnabledAndChecked(chkInfortuniSVIP) = .CoperturaInfortuniSVIP.Stato
                    FormatEuro(lblInfortuniSVIP, .CoperturaInfortuniSVIP)
                    EnabledAndChecked(chkInfortuniForfaitFrattura) = .CoperturaInfortuniForfaitFrattura.Stato
                    FormatEuro(lblInfortuniForfaitFrattura, .CoperturaInfortuniForfaitFrattura)
                    EnabledAndChecked(chkInfortuniForfaitRicoveroInfortunio) = .CoperturaInfortuniForfaitRicovero.Stato
                    FormatEuro(lblInfortuniForfaitRicoveroInfortunio, .CoperturaInfortuniForfaitRicovero)
                    EnabledAndChecked(chkInfortuniGlobaleImmobilizzazione) = .CoperturaInfortuniGlobaleImmobilizzazione.Stato
                    FormatEuro(lblInfortuniGlobaleImmobilizzazione, .CoperturaInfortuniGlobaleImmobilizzazione)
                    EnabledAndChecked(chkInfortuniDannoEstetico) = .CoperturaInfortuniDannoEstetico.Stato
                    FormatEuro(lblInfortuniDannoEstetico, .CoperturaInfortuniDannoEstetico)
                    EnabledAndChecked(chkInfortuniMorteCircolazione) = .CoperturaInfortuniMorteCircolazione.Stato
                    FormatEuro(lblInfortuniMorteCircolazione, .CoperturaInfortuniMorteCircolazione)
                    EnabledAndChecked(chkInfortuniNucleoFamiliare) = .CoperturaInfortuniNucleoFamiliare.Stato
                    FormatEuro(lblInfortuniNucleoFamiliare, .CoperturaInfortuniNucleoFamiliare)
                    EnabledAndChecked(chkSportAgonistico) = .CoperturaSportAgonistico.Stato
                    FormatEuro(lblSportAgonistico, .CoperturaSportAgonistico)
                    cmbSportClasseRischio.Enabled = .CoperturaSportAgonistico.IsAttivo
                    cmbSportClasseRischio.SelectedValue = CInt(.SportClasseRischio)
                    EnabledAndChecked(chkSportAgonisticoMorte) = .CoperturaSportAgonisticoMorte.Stato
                    CurrencyBox(txtPartitaSportAgonisticoMorte) = .PartitaSportAgonisticoMorte.SommaAssicurata
                    txtPartitaSportAgonisticoMorte.Enabled = Enable(.CoperturaSportAgonisticoMorte.Stato)
                    FormatEuro(lblSportAgonisticoMorte, .CoperturaSportAgonisticoMorte)
                    EnabledAndChecked(chkSportAgonisticoIP) = .CoperturaSportAgonisticoIP.Stato
                    CurrencyBox(txtPartitaSportAgonisticoIP) = .PartitaSportAgonisticoIP.SommaAssicurata
                    txtPartitaSportAgonisticoIP.Enabled = Enable(.CoperturaSportAgonisticoIP.Stato)
                    FormatEuro(lblSportAgonisticoIP, .CoperturaSportAgonisticoIP)
                    EnabledAndChecked(chkSportAgonisticoSpeseMediche) = .CoperturaSportAgonisticoSpeseMediche.Stato
                    FormatEuro(lblSportAgonisticoSpeseMediche, .CoperturaSportAgonisticoSpeseMediche)
                    cmbSportAgonisticoSpeseMedichemassimale.Enabled = Enable(.CoperturaSportAgonisticoSpeseMediche.Stato)
                    cmbSportAgonisticoSpeseMedichemassimale.SelectedValue = .CoperturaSportAgonisticoSpeseMediche.Garanzia.massimale
                    EnabledAndChecked(chkSportAgonisticoRicoveroConvalescenza) = .CoperturaSportAgonisticoRicoveroConvalescenza.Stato
                    CurrencyBox(txtPartitaSportAgonisticoRicoveroConvalescenza) = .PartitaSportAgonisticoRicoveroConvalescenza.SommaAssicurata
                    txtPartitaSportAgonisticoRicoveroConvalescenza.Enabled = Enable(.CoperturaSportAgonisticoRicoveroConvalescenza.Stato)
                    FormatEuro(lblSportAgonisticoRicoveroConvalescenza, .CoperturaSportAgonisticoRicoveroConvalescenza)
                    cmbSportAgonisticoRicoveroConvalescenzaScelta.Enabled = Enable(.CoperturaSportAgonisticoRicoveroConvalescenza.Stato)
                    cmbSportAgonisticoRicoveroConvalescenzaScelta.SelectedValue = CInt(.SportAgonisticoRicoveroConvalescenzaScelta)
                    EnabledAndChecked(chkSportAltoRischio) = .CoperturaSportAltoRischio.Stato
                    FormatEuro(lblSportAltoRischio, .CoperturaSportAltoRischio)
                    EnabledAndChecked(chkSportAltoRischioMorte) = .CoperturaSportAltoRischioMorte.Stato
                    CurrencyBox(txtPartitaSportAltoRischioMorte) = .PartitaSportAltoRischioMorte.SommaAssicurata
                    txtPartitaSportAltoRischioMorte.Enabled = Enable(.CoperturaSportAltoRischioMorte.Stato)
                    FormatEuro(lblSportAltoRischioMorte, .CoperturaSportAltoRischioMorte)
                    EnabledAndChecked(chkSportAltoRischioIP) = .CoperturaSportAltoRischioIP.Stato
                    CurrencyBox(txtPartitaSportAltoRischioIP) = .PartitaSportAltoRischioIP.SommaAssicurata
                    txtPartitaSportAltoRischioIP.Enabled = Enable(.CoperturaSportAltoRischioIP.Stato)
                    FormatEuro(lblSportAltoRischioIP, .CoperturaSportAltoRischioIP)
                    EnabledAndChecked(chkSportAltoRischioSpeseMediche) = .CoperturaSportAltoRischioSpeseMediche.Stato
                    FormatEuro(lblSportAltoRischioSpeseMediche, .CoperturaSportAltoRischioSpeseMediche)
                    cmbSportAltoRischioSpeseMedichemassimale.Enabled = Enable(.CoperturaSportAltoRischioSpeseMediche.Stato)
                    cmbSportAltoRischioSpeseMedichemassimale.SelectedValue = .CoperturaSportAltoRischioSpeseMediche.Garanzia.massimale
                    EnabledAndChecked(chkSportAltoRischioRicoveroConvalescenza) = .CoperturaSportAltoRischioRicoveroConvalescenza.Stato
                    CurrencyBox(txtPartitaSportAltoRischioRicoveroConvalescenza) = .PartitaSportAltoRischioRicoveroConvalescenza.SommaAssicurata
                    txtPartitaSportAltoRischioRicoveroConvalescenza.Enabled = Enable(.CoperturaSportAltoRischioRicoveroConvalescenza.Stato)
                    FormatEuro(lblSportAltoRischioRicoveroConvalescenza, .CoperturaSportAltoRischioRicoveroConvalescenza)
                    cmbSportAltoRischioRicoveroConvalescenzaScelta.Enabled = Enable(.CoperturaSportAltoRischioRicoveroConvalescenza.Stato)
                    cmbSportAltoRischioRicoveroConvalescenzaScelta.SelectedValue = CInt(.SportAltoRischioRicoveroConvalescenzaScelta)
                    EnabledAndChecked(chkSportMoto) = .CoperturaSportMoto.Stato
                    FormatEuro(lblSportMoto, .CoperturaSportMoto)
                    EnabledAndChecked(chkSportMotoMorte) = .CoperturaSportMotoMorte.Stato
                    CurrencyBox(txtPartitaSportMotoMorte) = .PartitaSportMotoMorte.SommaAssicurata
                    txtPartitaSportMotoMorte.Enabled = Enable(.CoperturaSportMotoMorte.Stato)
                    FormatEuro(lblSportMotoMorte, .CoperturaSportMotoMorte)
                    EnabledAndChecked(chkSportMotoIP) = .CoperturaSportMotoIP.Stato
                    CurrencyBox(txtPartitaSportMotoIP) = .PartitaSportMotoIP.SommaAssicurata
                    txtPartitaSportMotoIP.Enabled = Enable(.CoperturaSportMotoIP.Stato)
                    FormatEuro(lblSportMotoIP, .CoperturaSportMotoIP)
                    EnabledAndChecked(chkSportMotoSpeseMediche) = .CoperturaSportMotoSpeseMediche.Stato
                    FormatEuro(lblSportMotoSpeseMediche, .CoperturaSportMotoSpeseMediche)
                    cmbSportMotoSpeseMedichemassimale.Enabled = Enable(.CoperturaSportMotoSpeseMediche.Stato)
                    cmbSportMotoSpeseMedichemassimale.SelectedValue = .CoperturaSportMotoSpeseMediche.Garanzia.massimale
                    EnabledAndChecked(chkSportMotoRicoveroConvalescenza) = .CoperturaSportMotoRicoveroConvalescenza.Stato
                    CurrencyBox(txtPartitaSportMotoRicoveroConvalescenza) = .PartitaSportMotoRicoveroConvalescenza.SommaAssicurata
                    txtPartitaSportMotoRicoveroConvalescenza.Enabled = Enable(.CoperturaSportMotoRicoveroConvalescenza.Stato)
                    FormatEuro(lblSportMotoRicoveroConvalescenza, .CoperturaSportMotoRicoveroConvalescenza)
                    cmbSportMotoRicoveroConvalescenzaScelta.Enabled = Enable(.CoperturaSportMotoRicoveroConvalescenza.Stato)
                    cmbSportMotoRicoveroConvalescenzaScelta.SelectedValue = CInt(.SportMotoRicoveroConvalescenzaScelta)
                    EnabledAndChecked(chkSportAerei) = .CoperturaSportAerei.Stato
                    FormatEuro(lblSportAerei, .CoperturaSportAerei)
                    EnabledAndChecked(chkSportAereiMorte) = .CoperturaSportAereiMorte.Stato
                    CurrencyBox(txtPartitaSportAereiMorte) = .PartitaSportAereiMorte.SommaAssicurata
                    txtPartitaSportAereiMorte.Enabled = Enable(.CoperturaSportAereiMorte.Stato)
                    FormatEuro(lblSportAereiMorte, .CoperturaSportAereiMorte)
                    EnabledAndChecked(chkSportAereiIP) = .CoperturaSportAereiIP.Stato
                    CurrencyBox(txtPartitaSportAereiIP) = .PartitaSportAereiIP.SommaAssicurata
                    txtPartitaSportAereiIP.Enabled = Enable(.CoperturaSportAereiIP.Stato)
                    FormatEuro(lblSportAereiIP, .CoperturaSportAereiIP)
                    EnabledAndChecked(chkSportAereiSpeseMediche) = .CoperturaSportAereiSpeseMediche.Stato
                    FormatEuro(lblSportAereiSpeseMediche, .CoperturaSportAereiSpeseMediche)
                    cmbSportAereiSpeseMedichemassimale.Enabled = Enable(.CoperturaSportAereiSpeseMediche.Stato)
                    cmbSportAereiSpeseMedichemassimale.SelectedValue = .CoperturaSportAereiSpeseMediche.Garanzia.massimale
                    EnabledAndChecked(chkSportAereiRicoveroConvalescenza) = .CoperturaSportAereiRicoveroConvalescenza.Stato
                    CurrencyBox(txtPartitaSportAereiRicoveroConvalescenza) = .PartitaSportAereiRicoveroConvalescenza.SommaAssicurata
                    txtPartitaSportAereiRicoveroConvalescenza.Enabled = Enable(.CoperturaSportAereiRicoveroConvalescenza.Stato)
                    FormatEuro(lblSportAereiRicoveroConvalescenza, .CoperturaSportAereiRicoveroConvalescenza)
                    cmbSportAereiRicoveroConvalescenzaScelta.Enabled = Enable(.CoperturaSportAereiRicoveroConvalescenza.Stato)
                    cmbSportAereiRicoveroConvalescenzaScelta.SelectedValue = CInt(.SportAereiRicoveroConvalescenzaScelta)

                    'Malattia
                    EnabledAndChecked(chkMalattia) = .CoperturaMalattia.Stato
                    FormatEuro(lblMalattia, .CoperturaMalattia)
                    EnabledAndChecked(chkMalattiaRicoveroConvalescenza) = .CoperturaMalattiaRicoveroConvalescenza.Stato
                    FormatEuro(lblMalattiaRicoveroConvalescenza, .CoperturaMalattiaRicoveroConvalescenza)
                    CurrencyBox(txtPartitaMalattiaRicoveroConvalescenza) = .PartitaMalattiaRicoveroConvalescenza.SommaAssicurata
                    txtPartitaMalattiaRicoveroConvalescenza.Enabled = Enable(.CoperturaMalattiaRicoveroConvalescenza.Stato)
                    cmbMalattiaRicoveroConvalescenzaScelta.Enabled = Enable(.CoperturaMalattiaRicoveroConvalescenza.Stato)
                    cmbMalattiaRicoveroConvalescenzaScelta.SelectedValue = CInt(.MalattiaRicoveroConvalescenzaScelta)
                    EnabledAndChecked(chkMalattiaForfaitRicovero) = .CoperturaMalattiaForfaitRicovero.Stato
                    FormatEuro(lblMalattiaForfaitRicovero, .CoperturaMalattiaForfaitRicovero)

                    'SalvaPremio
                    EnabledAndChecked(chkSalvaPremioBase) = .CoperturaSalvaPremioBase.Stato
                    FormatEuro(lblSalvaPremioBase, .CoperturaSalvaPremioBase)

                    'Assistenza
                    EnabledAndChecked(chkAssistenzaBase) = .CoperturaAssistenzaBase.Stato
                    FormatEuro(lblAssistenzaBase, .CoperturaAssistenzaBase)

                    txtSommaAssicurata.Text = assicurato.PartitaInfortuniIP.SommaAssicurata
                    HighlightCheckAndLabel(mPanels)
                End If
            End With
        End Sub

        Private Sub cmdCalcola_Click(sender As Object, e As EventArgs) Handles cmdCalcola.Click
            If Not IsNumeric(txtSommaAssicurata.Text) OrElse txtSommaAssicurata.Text = 0 Then
                MsgBox("Controllare la somma assicurata")
                Return
            End If
            If Not IsNumeric(txtGradoInvalidita.Text) Or txtGradoInvalidita.Text = 0 Then
                MsgBox("Controllare il grado di invalidità")
                Return
            End If
            If assicurato.CoperturaInfortuniIP.PremioAttivoCrudo = 0 Then
                MsgBox("Verificare la copertura invalidità permamente")
                Return
            End If

            grdView.DataSource = New P01204SM().GetTable(assicurato, txtSommaAssicurata.Text, txtGradoInvalidita.Text)
        End Sub
    End Class
End Namespace
