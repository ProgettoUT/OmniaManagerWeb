Namespace P01261
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
            AddHandler cmbCriterioLiquidazioneIPM .SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler txtNominativo.Leave, AddressOf ValuesChanged
            AddHandler txtNominativo.KeyPress, AddressOf TextBoxKeyPress
            AddHandler txtEta.Leave, AddressOf ValuesChanged
            AddHandler txtEta.KeyPress, AddressOf TextBoxKeyPress

            AddHandler chkMalattiaBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkMalattiaIPM.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbMalattiaIPMmassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkMalattiaVisiteTrattamenti.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkMalattiaConvalescenza.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkMalattiaPrevenzioneSindromeMetabolica.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkMalattiaSecondOpinion.CheckedChanged, AddressOf ValuesChanged

            AddHandler chkAssistenzaBase.CheckedChanged, AddressOf ValuesChanged
        End Sub


        Public Sub New(ByVal decode As P01261DE, helpChm As HelpClass)
            ' Chiamata richiesta da Progettazione Windows Form.
            InitializeComponent()
            AttachCombo(cmbCriterioLiquidazioneIPM, decode.DecodeCriterioLiquidazioneIPM)
            AttachCombo(cmbMalattiaIPMmassimale, decode.DecodeMalattiaIPMmassimale)
            AttachEvents()

            AgganciaCheckAndLabel({TableLayoutPanel1})

            If helpChm.FileExists Then
                AgganciaHelp(Me, AddressOf MouseClickedHelp)
            End If

        End Sub

        Public Sub ControlsToPreventivo(ByVal diretto As Boolean)

            With assicurato

                If diretto Then
                    .CriterioLiquidazioneIPM = cmbCriterioLiquidazioneIPM.SelectedValue
                    .Nominativo = txtNominativo.Text
                    .Eta = IntegerBox(txtEta)

                    'Malattia
                    .CoperturaMalattia.Stato = EnabledAndChecked(chkMalattiaBase)
                    .CriterioLiquidazioneIPM = cmbCriterioLiquidazioneIPM.SelectedValue
                    .CoperturaMalattiaIPM.Stato = EnabledAndChecked(chkMalattiaIPM)
                    .CoperturaMalattiaIPM.Garanzia.massimale = cmbMalattiaIPMmassimale.SelectedValue
                    .CoperturaMalattiaVisiteTrattamenti.Stato = EnabledAndChecked(chkMalattiaVisiteTrattamenti)
                    .CoperturaMalattiaConvalescenza.Stato = EnabledAndChecked(chkMalattiaConvalescenza)
                    .CoperturaMalattiaPrevenzioneSindromeMetabolica.Stato = EnabledAndChecked(chkMalattiaPrevenzioneSindromeMetabolica)
                    .CoperturaMalattiaSecondOpinion.Stato = EnabledAndChecked(chkMalattiaSecondOpinion)

                    'Assistenza
                    .CoperturaAssistenza.Stato = EnabledAndChecked(chkAssistenzaBase)
                Else
                    cmbCriterioLiquidazioneIPM.SelectedValue = CInt(.CriterioLiquidazioneIPM)
                    txtNominativo.Text = .Nominativo
                    IntegerBox(txtEta) = .Eta

                    'Malattia
                    EnabledAndChecked(chkMalattiaBase) = .CoperturaMalattia.Stato
                    FormatEuro(lblMalattiaBase, .CoperturaMalattia)
                    EnabledAndChecked(chkMalattiaIPM) = .CoperturaMalattiaIPM.Stato
                    FormatEuro(lblMalattiaIPM, .CoperturaMalattiaIPM)
                    cmbMalattiaIPMmassimale.Enabled = Enable(.CoperturaMalattiaIPM.Stato)
                    cmbMalattiaIPMmassimale.SelectedValue = .CoperturaMalattiaIPM.Garanzia.massimale
                    EnabledAndChecked(chkMalattiaVisiteTrattamenti) = .CoperturaMalattiaVisiteTrattamenti.Stato
                    FormatEuro(lblMalattiaVisiteTrattamenti, .CoperturaMalattiaVisiteTrattamenti)
                    txtMalattiaVisiteTrattamentimassimale.Text = .CoperturaMalattiaVisiteTrattamenti.Garanzia.Massimale
                    EnabledAndChecked(chkMalattiaConvalescenza) = .CoperturaMalattiaConvalescenza.Stato
                    FormatEuro(lblMalattiaConvalescenza, .CoperturaMalattiaConvalescenza)
                    txtMalattiaConvalescenzamassimale.Text = .CoperturaMalattiaConvalescenza.Garanzia.Massimale
                    EnabledAndChecked(chkMalattiaPrevenzioneSindromeMetabolica) = .CoperturaMalattiaPrevenzioneSindromeMetabolica.Stato
                    FormatEuro(lblMalattiaPrevenzioneSindromeMetabolica, .CoperturaMalattiaPrevenzioneSindromeMetabolica)
                    EnabledAndChecked(chkMalattiaSecondOpinion) = .CoperturaMalattiaSecondOpinion.Stato
                    FormatEuro(lblMalattiaSecondOpinion, .CoperturaMalattiaSecondOpinion)
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
