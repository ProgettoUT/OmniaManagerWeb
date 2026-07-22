Namespace P01263
     Public Class assicuratoFE
        Public assicurato As assicurato
        Public Event Change(ByVal sender As Object, ByVal e As EventArgs)
        Public Event Remove(ByVal sender As Object, ByVal e As EventArgs)
        Public Event Help(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

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

        Protected Sub AttachEvents()
            AddHandler cmdRemove.Click, AddressOf RemoveUnita
            AddHandler cmbFormulaSezione.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler txtNominativo.Leave, AddressOf ValuesChanged
            AddHandler txtNominativo.KeyPress, AddressOf TextBoxKeyPress
            AddHandler txtEta.Leave, AddressOf ValuesChanged
            AddHandler txtEta.KeyPress, AddressOf TextBoxKeyPress

            AddHandler chkMalattiaBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkMalattiaRicoveroIstitutoCura.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbMalattiaRicoveroIstitutoCuramassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkMalattiaRicoveroFranchigia.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkMalattiaConvalescenza.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkMalattiaPostRicovero.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkMalattiaImmobilizzazione.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkMalattiaGrandeIntervento.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkMalattiaEnergy.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkMalattiaEnergySpesePrePostRicovero.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkMalattiaEnergyAssistenzaInfermieristica.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkMalattiaEnergyRettaAccompagnatore.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkMalattiaEnergyRaddoppioIndennita.CheckedChanged, AddressOf ValuesChanged

            AddHandler chkAssistenzaBase.CheckedChanged, AddressOf ValuesChanged
        End Sub


        Public Sub New(ByVal decode As P01263DE, helpChm As HelpClass)
            ' Chiamata richiesta da Progettazione Windows Form.
            InitializeComponent()
            AttachCombo(cmbFormulaSezione, decode.DecodeFormulaSezione)
            AttachCombo(cmbMalattiaRicoveroIstitutoCuramassimale, decode.DecodeMalattiaRicoveroIstitutoCuramassimale)
            AttachEvents()

            AgganciaCheckAndLabel({TableLayoutPanel1})

            If helpChm.FileExists Then
                AgganciaHelp(Me, AddressOf MouseClickedHelp)
            End If

        End Sub

        Public Sub ControlsToPreventivo(ByVal diretto As Boolean)

            With assicurato

                If diretto Then
                    .FormulaSezione = cmbFormulaSezione.SelectedValue
                    .Nominativo = txtNominativo.Text
                    .Eta = IntegerBox(txtEta)

                    'Malattia
                    .CoperturaMalattia.Stato = EnabledAndChecked(chkMalattiaBase)
                    .CoperturaMalattiaRicoveroIstitutoCura.Stato = EnabledAndChecked(chkMalattiaRicoveroIstitutoCura)
                    .CoperturaMalattiaRicoveroIstitutoCura.Garanzia.massimale = cmbMalattiaRicoveroIstitutoCuramassimale.SelectedValue
                    .CoperturaMalattiaRicoveroFranchigia.Stato = EnabledAndChecked(chkMalattiaRicoveroFranchigia)
                    .CoperturaMalattiaConvalescenza.Stato = EnabledAndChecked(chkMalattiaConvalescenza)
                    .CoperturaMalattiaPostRicovero.Stato = EnabledAndChecked(chkMalattiaPostRicovero)
                    .CoperturaMalattiaImmobilizzazione.Stato = EnabledAndChecked(chkMalattiaImmobilizzazione)
                    .CoperturaMalattiaGrandeIntervento.Stato = EnabledAndChecked(chkMalattiaGrandeIntervento)
                    .CoperturaMalattiaEnergy.Stato = EnabledAndChecked(chkMalattiaEnergy)
                    .CoperturaMalattiaEnergySpesePrePostRicovero.Stato = EnabledAndChecked(chkMalattiaEnergySpesePrePostRicovero)
                    .CoperturaMalattiaEnergyAssistenzaInfermieristica.Stato = EnabledAndChecked(chkMalattiaEnergyAssistenzaInfermieristica)
                    .CoperturaMalattiaEnergyRettaAccompagnatore.Stato = EnabledAndChecked(chkMalattiaEnergyRettaAccompagnatore)
                    .CoperturaMalattiaEnergyRaddoppioIndennita.Stato = EnabledAndChecked(chkMalattiaEnergyRaddoppioIndennita)

                    'Assistenza
                    .CoperturaAssistenza.Stato = EnabledAndChecked(chkAssistenzaBase)
                Else
                    txtNominativo.Text = .Nominativo
                    txtNominativo.Enabled = True
                    IntegerBox(txtEta) = .Eta
                    txtEta.Enabled = True
                    cmbFormulaSezione.SelectedValue = CInt(.FormulaSezione)
                    cmbFormulaSezione.Enabled = Enable(.CoperturaMalattiaRicoveroIstitutoCura.Stato)

                    'Malattia
                    EnabledAndChecked(chkMalattiaBase) = .CoperturaMalattia.Stato
                    FormatEuro(lblMalattiaBase, .CoperturaMalattia)
                    EnabledAndChecked(chkMalattiaRicoveroIstitutoCura) = .CoperturaMalattiaRicoveroIstitutoCura.Stato
                    FormatEuro(lblMalattiaRicoveroIstitutoCura, .CoperturaMalattiaRicoveroIstitutoCura)
                    cmbMalattiaRicoveroIstitutoCuramassimale.Enabled = Enable(.CoperturaMalattiaRicoveroIstitutoCura.Stato)
                    cmbMalattiaRicoveroIstitutoCuramassimale.SelectedValue = .CoperturaMalattiaRicoveroIstitutoCura.Garanzia.massimale
                    EnabledAndChecked(chkMalattiaRicoveroFranchigia) = .CoperturaMalattiaRicoveroFranchigia.Stato
                    FormatEuro(lblMalattiaRicoveroFranchigia, .CoperturaMalattiaRicoveroFranchigia)
                    EnabledAndChecked(chkMalattiaConvalescenza) = .CoperturaMalattiaConvalescenza.Stato
                    FormatEuro(lblMalattiaConvalescenza, .CoperturaMalattiaConvalescenza)
                    txtMalattiaConvalescenzaMassimale.Text = .CoperturaMalattiaConvalescenza.Garanzia.Massimale
                    EnabledAndChecked(chkMalattiaPostRicovero) = .CoperturaMalattiaPostRicovero.Stato
                    FormatEuro(lblMalattiaPostRicovero, .CoperturaMalattiaPostRicovero)
                    txtMalattiaPostRicoveroMassimale.Text = .CoperturaMalattiaPostRicovero.Garanzia.Massimale
                    EnabledAndChecked(chkMalattiaImmobilizzazione) = .CoperturaMalattiaImmobilizzazione.Stato
                    FormatEuro(lblMalattiaImmobilizzazione, .CoperturaMalattiaImmobilizzazione)
                    txtMalattiaImmobilizzazioneMassimale.Text = .CoperturaMalattiaImmobilizzazione.Garanzia.Massimale
                    EnabledAndChecked(chkMalattiaGrandeIntervento) = .CoperturaMalattiaGrandeIntervento.Stato
                    FormatEuro(lblMalattiaGrandeIntervento, .CoperturaMalattiaGrandeIntervento)
                    txtMalattiaGrandeInterventoMassimale.Text = .CoperturaMalattiaGrandeIntervento.Garanzia.Massimale
                    EnabledAndChecked(chkMalattiaEnergy) = .CoperturaMalattiaEnergy.Stato
                    FormatEuro(lblMalattiaEnergy, .CoperturaMalattiaEnergy)
                    EnabledAndChecked(chkMalattiaEnergySpesePrePostRicovero) = .CoperturaMalattiaEnergySpesePrePostRicovero.Stato
                    FormatEuro(lblMalattiaEnergySpesePrePostRicovero, .CoperturaMalattiaEnergySpesePrePostRicovero)
                    txtMalattiaEnergySpesePrePostRicoveroMassimale.Text = .CoperturaMalattiaEnergySpesePrePostRicovero.Garanzia.Massimale
                    EnabledAndChecked(chkMalattiaEnergyAssistenzaInfermieristica) = .CoperturaMalattiaEnergyAssistenzaInfermieristica.Stato
                    FormatEuro(lblMalattiaEnergyAssistenzaInfermieristica, .CoperturaMalattiaEnergyAssistenzaInfermieristica)
                    txtMalattiaEnergyAssistenzaInfermieristicaMassimale.Text = .CoperturaMalattiaEnergyAssistenzaInfermieristica.Garanzia.Massimale
                    EnabledAndChecked(chkMalattiaEnergyRettaAccompagnatore) = .CoperturaMalattiaEnergyRettaAccompagnatore.Stato
                    FormatEuro(lblMalattiaEnergyRettaAccompagnatore, .CoperturaMalattiaEnergyRettaAccompagnatore)
                    txtMalattiaEnergyRettaAccompagnatoreMassimale.Text = .CoperturaMalattiaEnergyRettaAccompagnatore.Garanzia.Massimale
                    EnabledAndChecked(chkMalattiaEnergyRaddoppioIndennita) = .CoperturaMalattiaEnergyRaddoppioIndennita.Stato
                    FormatEuro(lblMalattiaEnergyRaddoppioIndennita, .CoperturaMalattiaEnergyRaddoppioIndennita)
                    HighlightCheckAndLabel({TableLayoutPanel1})

                    'Assistenza
                    EnabledAndChecked(chkAssistenzaBase) = .CoperturaAssistenza.Stato
                    FormatEuro(lblAssistenzaBase, .CoperturaAssistenza)
                    HighlightCheckAndLabel({TableLayoutPanel1})
                End If
            End With
        End Sub
    End Class
End Namespace
