Namespace P04226
    Public Class P04226FE

        Protected Overrides Sub AttachEvents()
            AddHandler txtNumeroAddetti.Leave, AddressOf ValuesChanged
            AddHandler txtNumeroAddetti.KeyPress, AddressOf TextBoxKeyPress
            AddHandler cmbAttivita1.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbAttivita2.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbAttivita3.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkSoloProprieta.CheckedChanged, AddressOf ValuesChanged

            AddHandler chkResponsabilitaCivileBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkResponsabilitaCivileRct.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbResponsabilitaCivileRctMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkResponsabilitaCivileRco.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbResponsabilitaCivileRcoMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkRCLavoratoriProgetto.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCRicorsoTerzi.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCDanniCoseClienti.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCDanniVeicoliTerzi.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCDanniFurto.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCDanniCoseLavorate.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCDanniCoseMovimentate.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCMalattieProfessionali.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCInquinamento.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCFornitura.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCDistributori1.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCDistributori2.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCCatering.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCInstallazioni.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCLavanderie.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCParrucchieri.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCCarrelli.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCSoloProprieta.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbRCSoloProprietaMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkRCAmbulante.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCFranchigia.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbRCFranchigiaFranchigia.SelectedIndexChanged, AddressOf ValuesChanged

            AddHandler chkTutelaLegaleBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbTutelaLegaleBaseMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkTutelaLegaleDlgs07193.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkTutelaLegaleDlgs01231.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkTutelaLegaleDlgs97472.CheckedChanged, AddressOf ValuesChanged

            AddHandler chkAssistenzaBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler QuotatorePremio.ClickedHelp, AddressOf MouseClickedHelp
            AddHandler QuotatorePremio.QuotatorePremioChanged, AddressOf ValuesChanged

            AddHandler TabFabbricati.SelectedIndexChanged, AddressOf TabControl1_SelectedIndexChanged

            For Each scheda As TabPage In TabFabbricati.Controls
                If scheda.Controls.Count > 0 AndAlso TypeOf (scheda.Controls(0)) Is FabbricatoFE Then
                    For Each FabbricatoFE As FabbricatoFE In scheda.Controls
                        AddHandler FabbricatoFE.Change, AddressOf ValuesChanged
                        AddHandler FabbricatoFE.Remove, AddressOf RimuoviScheda
                        AddHandler FabbricatoFE.Help, AddressOf MouseClickedHelp
                    Next
                End If
            Next

        End Sub

        Protected Overrides Sub DetachEvents()
            RemoveHandler txtNumeroAddetti.Leave, AddressOf ValuesChanged
            RemoveHandler txtNumeroAddetti.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler cmbAttivita1.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbAttivita2.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbAttivita3.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler chkSoloProprieta.CheckedChanged, AddressOf ValuesChanged

            RemoveHandler chkResponsabilitaCivileBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkResponsabilitaCivileRct.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler cmbResponsabilitaCivileRctMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler chkResponsabilitaCivileRco.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler cmbResponsabilitaCivileRcoMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler chkRCLavoratoriProgetto.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCRicorsoTerzi.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCDanniCoseClienti.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCDanniVeicoliTerzi.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCDanniFurto.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCDanniCoseLavorate.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCDanniCoseMovimentate.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCMalattieProfessionali.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCInquinamento.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCFornitura.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCDistributori1.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCDistributori2.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCCatering.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCInstallazioni.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCLavanderie.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCParrucchieri.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCCarrelli.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCSoloProprieta.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler cmbRCSoloProprietaMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler chkRCAmbulante.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCFranchigia.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler cmbRCFranchigiaFranchigia.SelectedIndexChanged, AddressOf ValuesChanged

            RemoveHandler chkTutelaLegaleBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler cmbTutelaLegaleBaseMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler chkTutelaLegaleDlgs07193.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkTutelaLegaleDlgs01231.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkTutelaLegaleDlgs97472.CheckedChanged, AddressOf ValuesChanged

            RemoveHandler chkAssistenzaBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler QuotatorePremio.ClickedHelp, AddressOf MouseClickedHelp
            RemoveHandler QuotatorePremio.QuotatorePremioChanged, AddressOf ValuesChanged

            RemoveHandler TabFabbricati.SelectedIndexChanged, AddressOf TabControl1_SelectedIndexChanged

            For Each scheda As TabPage In TabFabbricati.Controls
                If scheda.Controls.Count > 0 AndAlso TypeOf (scheda.Controls(0)) Is FabbricatoFE Then
                    For Each FabbricatoFE As FabbricatoFE In scheda.Controls
                        RemoveHandler FabbricatoFE.Change, AddressOf ValuesChanged
                        RemoveHandler FabbricatoFE.Remove, AddressOf RimuoviScheda
                        RemoveHandler FabbricatoFE.Help, AddressOf MouseClickedHelp
                    Next
                End If
            Next

        End Sub

        Public Sub New()
            InitializeComponent2()
            Me.TabFabbricati.Controls.Add(Me.docTab)
            Me.QuotatorePremio.Image = Global.UniQuota.My.Resources.Resources.P04226
            Me.docBrowser.Tag = "http://www.utools.it/Unitools/Doc/Prodotti/P04226/IndexDoc.htm"
            Me.docBrowser.Url = New System.Uri(CType(Me.docBrowser.Tag, String), System.UriKind.Absolute)

            'preventivo = New YouCommercio
            'modello = New P04226ST

            Dim decode As New P04226DE
            'preventivo.Decode = decode
            Me.decode = decode

            helpChm.CodiceProdotto = "P04226"
            If helpChm.FileExists Then
                AgganciaHelp(Me, AddressOf MouseClickedHelp)
            End If

            With QuotatorePremio.cmbFrazionamento
                .DataSource = New BindingSource(decode.DecodeFrazionamenti, Nothing)
                .ValueMember = "Key"
                .DisplayMember = "Value"
                .SelectedIndex = 0
            End With

            AttachCombo(cmbAttivita1, decode.DecodeAttivita)
            AttachCombo(cmbAttivita2, decode.DecodeAttivita)
            AttachCombo(cmbAttivita3, decode.DecodeAttivita)
            AttachCombo(cmbResponsabilitaCivileRctMassimale, decode.DecodeResponsabilitaCivileRctMassimale)
            AttachCombo(cmbResponsabilitaCivileRcoMassimale, decode.DecodeResponsabilitaCivileRcoMassimale)
            AttachCombo(cmbRCSoloProprietaMassimale, decode.DecodeRCSoloProprietaMassimale)
            AttachCombo(cmbRCFranchigiaFranchigia, decode.DecodeRCFranchigiaFranchigia)
            AttachCombo(cmbTutelaLegaleBaseMassimale, decode.DecodeTutelaLegaleBaseMassimale)

            'preventivo.Inizializza()
            'preventivo.ValidaECalcola()
            'PreventivoToControls()
            Panels = {TableLayoutPanel6, TableLayoutPanel7, TableLayoutPanel8}
        End Sub

        Protected Overrides Sub ControlsToPreventivo(ByVal diretto As Boolean)
            With TryCast(preventivo, YouCommercio)

                If diretto Then
                    .NumeroAddetti = IntegerBox(txtNumeroAddetti)
                    .CodiceAttivita1 = CInt(cmbAttivita1.SelectedValue)
                    .CodiceAttivita2 = CInt(cmbAttivita2.SelectedValue)
                    .CodiceAttivita3 = CInt(cmbAttivita3.SelectedValue)
                    .TestoAttivita1 = txtAttivita1.Text
                    .TestoAttivita2 = txtAttivita2.Text
                    .TestoAttivita3 = txtAttivita3.Text
                    .SoloProprieta = chkSoloProprieta.Checked

                    'ResponsabilitaCivile
                    .CoperturaResponsabilitaCivileBase.Stato = EnabledAndChecked(chkResponsabilitaCivileBase)
                    .CoperturaResponsabilitaCivileRct.Stato = EnabledAndChecked(chkResponsabilitaCivileRct)
                    .CoperturaResponsabilitaCivileRct.Garanzia.Massimale = CDec(cmbResponsabilitaCivileRctMassimale.SelectedValue)
                    .CoperturaResponsabilitaCivileRco.Stato = EnabledAndChecked(chkResponsabilitaCivileRco)
                    .CoperturaResponsabilitaCivileRco.Garanzia.Massimale = CDec(cmbResponsabilitaCivileRcoMassimale.SelectedValue)
                    .CoperturaRCLavoratoriProgetto.Stato = EnabledAndChecked(chkRCLavoratoriProgetto)
                    .CoperturaRCRicorsoTerzi.Stato = EnabledAndChecked(chkRCRicorsoTerzi)
                    .CoperturaRCDanniCoseClienti.Stato = EnabledAndChecked(chkRCDanniCoseClienti)
                    .CoperturaRCDanniVeicoliTerzi.Stato = EnabledAndChecked(chkRCDanniVeicoliTerzi)
                    .CoperturaRCDanniFurto.Stato = EnabledAndChecked(chkRCDanniFurto)
                    .CoperturaRCDanniCoseLavorate.Stato = EnabledAndChecked(chkRCDanniCoseLavorate)
                    .CoperturaRCDanniCoseMovimentate.Stato = EnabledAndChecked(chkRCDanniCoseMovimentate)
                    .CoperturaRCMalattieProfessionali.Stato = EnabledAndChecked(chkRCMalattieProfessionali)
                    .CoperturaRCInquinamento.Stato = EnabledAndChecked(chkRCInquinamento)
                    .CoperturaRCFornitura.Stato = EnabledAndChecked(chkRCFornitura)
                    .CoperturaRCDistributori1.Stato = EnabledAndChecked(chkRCDistributori1)
                    .CoperturaRCDistributori2.Stato = EnabledAndChecked(chkRCDistributori2)
                    .CoperturaRCCatering.Stato = EnabledAndChecked(chkRCCatering)
                    .CoperturaRCInstallazioni.Stato = EnabledAndChecked(chkRCInstallazioni)
                    .CoperturaRCLavanderie.Stato = EnabledAndChecked(chkRCLavanderie)
                    .CoperturaRCParrucchieri.Stato = EnabledAndChecked(chkRCParrucchieri)
                    .CoperturaRCCarrelli.Stato = EnabledAndChecked(chkRCCarrelli)
                    .CoperturaRCSoloProprieta.Stato = EnabledAndChecked(chkRCSoloProprieta)
                    .CoperturaRCSoloProprieta.Garanzia.Massimale = CDec(cmbRCSoloProprietaMassimale.SelectedValue)
                    .CoperturaRCAmbulante.Stato = EnabledAndChecked(chkRCAmbulante)
                    .CoperturaRCFranchigia.Stato = EnabledAndChecked(chkRCFranchigia)
                    .CoperturaRCFranchigia.Garanzia.Franchigia = CDec(cmbRCFranchigiaFranchigia.SelectedValue)

                    'TutelaLegale
                    .CoperturaTutelaLegaleBase.Stato = EnabledAndChecked(chkTutelaLegaleBase)
                    .CoperturaTutelaLegaleBase.Garanzia.Massimale = CDec(cmbTutelaLegaleBaseMassimale.SelectedValue)
                    .CoperturaTutelaLegaleDlgs07193.Stato = EnabledAndChecked(chkTutelaLegaleDlgs07193)
                    .CoperturaTutelaLegaleDlgs01231.Stato = EnabledAndChecked(chkTutelaLegaleDlgs01231)
                    .CoperturaTutelaLegaleDlgs97472.Stato = EnabledAndChecked(chkTutelaLegaleDlgs97472)

                    'Assistenza
                    .CoperturaAssistenzaBase.Stato = EnabledAndChecked(chkAssistenzaBase)
                Else
                    IntegerBox(txtNumeroAddetti) = .NumeroAddetti
                    txtNumeroAddetti.Enabled = True
                    cmbAttivita1.SelectedValue = .CodiceAttivita1
                    cmbAttivita1.Enabled = True
                    cmbAttivita2.SelectedValue = .CodiceAttivita2
                    cmbAttivita2.Enabled = True
                    cmbAttivita3.SelectedValue = .CodiceAttivita3
                    cmbAttivita3.Enabled = True

                    txtAttivita1.Text = .TestoAttivita1
                    txtAttivita1.Enabled = (.CodiceAttivita1 Mod 100 = 0)
                    txtAttivita2.Text = .TestoAttivita2
                    txtAttivita2.Enabled = (.CodiceAttivita2 Mod 100 = 0)
                    txtAttivita3.Text = .TestoAttivita3
                    txtAttivita3.Enabled = (.CodiceAttivita3 Mod 100 = 0)

                    chkSoloProprieta.Checked = .SoloProprieta
                    chkSoloProprieta.Enabled = (.Fabbricati.Count <= 1)

                    'ResponsabilitaCivile
                    EnabledAndChecked(chkResponsabilitaCivileBase) = .CoperturaResponsabilitaCivileBase.Stato
                    EnabledAndChecked(chkResponsabilitaCivileRct) = .CoperturaResponsabilitaCivileRct.Stato
                    FormatEuro(lblResponsabilitaCivileRct, .CoperturaResponsabilitaCivileRct)
                    cmbResponsabilitaCivileRctMassimale.Enabled = Enable(.CoperturaResponsabilitaCivileRct.Stato)
                    cmbResponsabilitaCivileRctMassimale.SelectedValue = .CoperturaResponsabilitaCivileRct.Garanzia.Massimale
                    EnabledAndChecked(chkResponsabilitaCivileRco) = .CoperturaResponsabilitaCivileRco.Stato
                    FormatEuro(lblResponsabilitaCivileRco, .CoperturaResponsabilitaCivileRco)
                    cmbResponsabilitaCivileRcoMassimale.Enabled = Enable(.CoperturaResponsabilitaCivileRco.Stato)
                    cmbResponsabilitaCivileRcoMassimale.SelectedValue = .CoperturaResponsabilitaCivileRco.Garanzia.Massimale
                    EnabledAndChecked(chkRCLavoratoriProgetto) = .CoperturaRCLavoratoriProgetto.Stato
                    FormatEuro(lblRCLavoratoriProgetto, .CoperturaRCLavoratoriProgetto)
                    EnabledAndChecked(chkRCRicorsoTerzi) = .CoperturaRCRicorsoTerzi.Stato
                    FormatEuro(lblRCRicorsoTerzi, .CoperturaRCRicorsoTerzi)
                    EnabledAndChecked(chkRCDanniCoseClienti) = .CoperturaRCDanniCoseClienti.Stato
                    FormatEuro(lblRCDanniCoseClienti, .CoperturaRCDanniCoseClienti)
                    EnabledAndChecked(chkRCDanniVeicoliTerzi) = .CoperturaRCDanniVeicoliTerzi.Stato
                    FormatEuro(lblRCDanniVeicoliTerzi, .CoperturaRCDanniVeicoliTerzi)
                    EnabledAndChecked(chkRCDanniFurto) = .CoperturaRCDanniFurto.Stato
                    FormatEuro(lblRCDanniFurto, .CoperturaRCDanniFurto)
                    EnabledAndChecked(chkRCDanniCoseLavorate) = .CoperturaRCDanniCoseLavorate.Stato
                    FormatEuro(lblRCDanniCoseLavorate, .CoperturaRCDanniCoseLavorate)
                    EnabledAndChecked(chkRCDanniCoseMovimentate) = .CoperturaRCDanniCoseMovimentate.Stato
                    FormatEuro(lblRCDanniCoseMovimentate, .CoperturaRCDanniCoseMovimentate)
                    EnabledAndChecked(chkRCMalattieProfessionali) = .CoperturaRCMalattieProfessionali.Stato
                    FormatEuro(lblRCMalattieProfessionali, .CoperturaRCMalattieProfessionali)
                    EnabledAndChecked(chkRCInquinamento) = .CoperturaRCInquinamento.Stato
                    FormatEuro(lblRCInquinamento, .CoperturaRCInquinamento)
                    EnabledAndChecked(chkRCFornitura) = .CoperturaRCFornitura.Stato
                    FormatEuro(lblRCFornitura, .CoperturaRCFornitura)
                    EnabledAndChecked(chkRCDistributori1) = .CoperturaRCDistributori1.Stato
                    FormatEuro(lblRCDistributori1, .CoperturaRCDistributori1)
                    EnabledAndChecked(chkRCDistributori2) = .CoperturaRCDistributori2.Stato
                    FormatEuro(lblRCDistributori2, .CoperturaRCDistributori2)
                    EnabledAndChecked(chkRCCatering) = .CoperturaRCCatering.Stato
                    FormatEuro(lblRCCatering, .CoperturaRCCatering)
                    EnabledAndChecked(chkRCInstallazioni) = .CoperturaRCInstallazioni.Stato
                    FormatEuro(lblRCInstallazioni, .CoperturaRCInstallazioni)
                    EnabledAndChecked(chkRCLavanderie) = .CoperturaRCLavanderie.Stato
                    FormatEuro(lblRCLavanderie, .CoperturaRCLavanderie)
                    EnabledAndChecked(chkRCParrucchieri) = .CoperturaRCParrucchieri.Stato
                    FormatEuro(lblRCParrucchieri, .CoperturaRCParrucchieri)
                    EnabledAndChecked(chkRCCarrelli) = .CoperturaRCCarrelli.Stato
                    FormatEuro(lblRCCarrelli, .CoperturaRCCarrelli)
                    EnabledAndChecked(chkRCSoloProprieta) = .CoperturaRCSoloProprieta.Stato
                    FormatEuro(lblRCSoloProprieta, .CoperturaRCSoloProprieta)
                    cmbRCSoloProprietaMassimale.Enabled = Enable(.CoperturaRCSoloProprieta.Stato)
                    cmbRCSoloProprietaMassimale.SelectedValue = .CoperturaRCSoloProprieta.Garanzia.Massimale
                    EnabledAndChecked(chkRCAmbulante) = .CoperturaRCAmbulante.Stato
                    FormatEuro(lblRCAmbulante, .CoperturaRCAmbulante)
                    EnabledAndChecked(chkRCFranchigia) = .CoperturaRCFranchigia.Stato
                    FormatEuro(lblRCFranchigia, .CoperturaRCFranchigia)
                    cmbRCFranchigiaFranchigia.Enabled = Enable(.CoperturaRCFranchigia.Stato)
                    cmbRCFranchigiaFranchigia.SelectedValue = .CoperturaRCFranchigia.Garanzia.Franchigia
                    FormatEuro(lblResponsabilitaCivilePremio, .SezioneResponsabilitaCivile)

                    'TutelaLegale
                    EnabledAndChecked(chkTutelaLegaleBase) = .CoperturaTutelaLegaleBase.Stato
                    FormatEuro(lblTutelaLegaleBase, .CoperturaTutelaLegaleBase)
                    cmbTutelaLegaleBaseMassimale.Enabled = Enable(.CoperturaTutelaLegaleBase.Stato)
                    cmbTutelaLegaleBaseMassimale.SelectedValue = .CoperturaTutelaLegaleBase.Garanzia.Massimale
                    EnabledAndChecked(chkTutelaLegaleDlgs07193) = .CoperturaTutelaLegaleDlgs07193.Stato
                    FormatEuro(lblTutelaLegaleDlgs07193, .CoperturaTutelaLegaleDlgs07193)
                    EnabledAndChecked(chkTutelaLegaleDlgs01231) = .CoperturaTutelaLegaleDlgs01231.Stato
                    FormatEuro(lblTutelaLegaleDlgs01231, .CoperturaTutelaLegaleDlgs01231)
                    EnabledAndChecked(chkTutelaLegaleDlgs97472) = .CoperturaTutelaLegaleDlgs97472.Stato
                    FormatEuro(lblTutelaLegaleDlgs97472, .CoperturaTutelaLegaleDlgs97472)
                    FormatEuro(lblTutelaLegalePremio, .SezioneTutelaLegale)

                    'Assistenza
                    EnabledAndChecked(chkAssistenzaBase) = .CoperturaAssistenzaBase.Stato
                    FormatEuro(lblAssistenzaBase, .CoperturaAssistenzaBase)
                    FormatEuro(lblAssistenzaPremio, .SezioneAssistenza)
                End If


                'RIEPILOGO GARANZIE
                If diretto = False Then
                    FormatEuro(lblSezioneIncendioPremio, .SezioneIncendio)
                    chkSezioneIncendio.Checked = .SezioneIncendio.IsAttivo
                    chkSezioneIncendio.Enabled = False

                    FormatEuro(lblSezioneFurtoPremio, .SezioneFurto)
                    chkSezioneFurto.Checked = .SezioneFurto.IsAttivo
                    chkSezioneFurto.Enabled = False

                    FormatEuro(lblSezioneTerremotoPremio, .SezioneTerremoto)
                    chkSezioneTerremoto.Checked = .SezioneTerremoto.IsAttivo
                    chkSezioneTerremoto.Enabled = False

                    FormatEuro(lblSezioneResponsabilitaCivilePremio, .SezioneResponsabilitaCivile)
                    chkSezioneResponsabilitaCivile.Checked = .SezioneResponsabilitaCivile.IsAttivo
                    chkSezioneResponsabilitaCivile.Enabled = False

                    FormatEuro(lblSezioneTutelaLegalePremio, .SezioneTutelaLegale)
                    chkSezioneTutelaLegale.Checked = .SezioneTutelaLegale.IsAttivo
                    chkSezioneTutelaLegale.Enabled = False

                    FormatEuro(lblSezioneAssistenzaPremio, .SezioneAssistenza)
                    chkSezioneAssistenza.Checked = .SezioneAssistenza.IsAttivo
                    chkSezioneAssistenza.Enabled = False

                    FormatEuro(lblSezioneTotalePremio, preventivo)
                End If
            End With

            For Each scheda As TabPage In TabFabbricati.Controls
                If scheda.Controls.Count > 0 AndAlso TypeOf (scheda.Controls(0)) Is FabbricatoFE Then
                    For Each FabbricatoFE As FabbricatoFE In scheda.Controls
                        FabbricatoFE.ControlsToPreventivo(diretto)
                    Next
                End If
            Next
        End Sub

        Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If TabFabbricati.SelectedTab.Equals(TabAgg) Then
                Dim fabbricato As New Fabbricato(TryCast(preventivo, YouCommercio))

                preventivo.DescrizioniCoperture(fabbricato.CoperturaIncendio.CopertureSingole)
                preventivo.DescrizioniCoperture(fabbricato.CoperturaFurto.CopertureSingole)
                preventivo.DescrizioniCoperture(fabbricato.CoperturaTerremoto.CopertureSingole)

                AggiungiScheda(fabbricato)
                TryCast(preventivo, YouCommercio).AggiungiFabbricato(fabbricato)
                preventivo.ValidaECalcola()
                PreventivoToControls()
            End If
        End Sub

        Private Sub AggiungiScheda(ByRef fabbricato As Fabbricato)
            With TabFabbricati
                .SuspendLayout()

                Dim isNew As Boolean = .SelectedTab.Equals(TabAgg)

                .Controls.Remove(docTab)
                .Controls.Remove(TabAgg)

                Dim TabPage = New System.Windows.Forms.TabPage
                .Controls.Add(TabPage)

                With TabPage
                    .Margin = New System.Windows.Forms.Padding(0)
                    .UseVisualStyleBackColor = True

                    Dim fabbricatoFE As New FabbricatoFE(CType(decode, P04226DE))

                    fabbricatoFE.Fabbricato = fabbricato
                    fabbricatoFE.Dock = DockStyle.Fill
                    .Controls.Add(fabbricatoFE)
                    .Text = "Fabbricato " & TabFabbricati.Controls.Count - 4
                End With

                .Controls.Add(TabAgg)
                .Controls.Add(docTab)

                If isNew Then
                    .SelectedTab = TabPage
                End If

                .ResumeLayout()
            End With
        End Sub

        Private Sub RimuoviScheda(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim fabbricatoFE As FabbricatoFE = CType(sender, FabbricatoFE)
            TryCast(preventivo, YouCommercio).RimuoviFabbricato(fabbricatoFE.Fabbricato)
            preventivo.ValidaECalcola()
            PreventivoToControls()
            fabbricatoFE.Parent.Dispose()

            'rinomina schede
            For i As Integer = 5 To TabFabbricati.Controls.Count - 2
                TabFabbricati.Controls(i - 1).Text = "Fabbricato " & i - 4
            Next
        End Sub

        Public Overrides Sub Apri(ByVal p As Prodotto)
            If p IsNot Nothing Then
                preventivo = p
                preventivo.Decode = decode
                preventivo.Inizializza()
                preventivo.ValidaECalcola()

                TabFabbricati.SuspendLayout()
                While TabFabbricati.Controls.Count > 6
                    TabFabbricati.Controls(4).Dispose()
                End While

                For Each fabbricato As Fabbricato In TryCast(preventivo, YouCommercio).Fabbricati
                    AggiungiScheda(fabbricato)
                Next

                PreventivoToControls()
                TabFabbricati.ResumeLayout()
            End If
        End Sub

    End Class
End Namespace
