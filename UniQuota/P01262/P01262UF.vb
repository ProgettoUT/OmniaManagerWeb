Namespace P01262
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
            AddHandler txtNominativo.Leave, AddressOf ValuesChanged
            AddHandler txtNominativo.KeyPress, AddressOf TextBoxKeyPress
            AddHandler txtEta.Leave, AddressOf ValuesChanged
            AddHandler txtEta.KeyPress, AddressOf TextBoxKeyPress

            AddHandler chkMalattiaBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkMalattiaRicovero.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbMalattiaRicoverocombinazione.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkMalattiaSupplementari.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkMalattiaFranchigia.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbMalattiaFranchigiafranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkMalattiaFormaNucleoFamiliare.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkMalattiaGicGem.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbMalattiaGicGemmassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkMalattiaSempreOperanti.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkAssistenzaBase.CheckedChanged, AddressOf ValuesChanged
        End Sub


        Public Sub New(ByVal decode As P01262DE, helpChm As HelpClass)
            ' Chiamata richiesta da Progettazione Windows Form.
            InitializeComponent()
            AttachCombo(cmbMalattiaRicoverocombinazione, decode.DecodeMalattiaRicoverocombinazione)
            AttachCombo(cmbMalattiaRicoveroIstitutoCuramassimale, decode.DecodeMalattiaRicoveroIstitutoCuramassimale)
            AttachCombo(cmbMalattiaRicoveroAltaSpecializzazionemassimale, decode.DecodeMalattiaRicoveroAltaSpecializzazionemassimale)
            AttachCombo(cmbMalattiaRicoveroCureOncologichemassimale, decode.DecodeMalattiaRicoveroCureOncologichemassimale)
            AttachCombo(cmbMalattiaSupplementariVisitemassimale, decode.DecodeMalattiaSupplementariVisitemassimale)
            AttachCombo(cmbMalattiaSupplementariFisioterapiamassimale, decode.DecodeMalattiaSupplementariFisioterapiamassimale)
            AttachCombo(cmbMalattiaSupplementariPrevenzionecombinazione, decode.DecodeMalattiaSupplementariPrevenzionecombinazione)
            AttachCombo(cmbMalattiaSupplementariVisitaOdontoiatricacombinazione, decode.DecodeMalattiaSupplementariVisitaOdontoiatricacombinazione)
            AttachCombo(cmbMalattiaSupplementariSedutaIgeneOralecombinazione, decode.DecodeMalattiaSupplementariSedutaIgeneOralecombinazione)
            AttachCombo(cmbMalattiaSupplementariInterventiOdontoiatricimassimale, decode.DecodeMalattiaSupplementariInterventiOdontoiatricimassimale)
            AttachCombo(cmbMalattiaFranchigiafranchigia, decode.DecodeMalattiaFranchigiafranchigia)
            AttachCombo(cmbMalattiaGicGemmassimale, decode.DecodeMalattiaGicGemmassimale)
            AttachEvents()

            AgganciaCheckAndLabel({TableLayoutPanel1})

            If helpChm.FileExists Then
                AgganciaHelp(Me, AddressOf MouseClickedHelp)
            End If

        End Sub

        Public Sub ControlsToPreventivo(ByVal diretto As Boolean)

            With assicurato

                If diretto Then
                    .Nominativo = txtNominativo.Text
                    .Eta = IntegerBox(txtEta)

                    'Malattia
                    .CoperturaMalattia.Stato = EnabledAndChecked(chkMalattiaBase)
                    .CoperturaMalattiaRicovero.Stato = EnabledAndChecked(chkMalattiaRicovero)
                    .CoperturaMalattiaRicovero.Garanzia.combinazione = cmbMalattiaRicoverocombinazione.SelectedValue
                    .CoperturaMalattiaSupplementari.Stato = EnabledAndChecked(chkMalattiaSupplementari)
                    .CoperturaMalattiaFranchigia.Stato = EnabledAndChecked(chkMalattiaFranchigia)
                    .CoperturaMalattiaFranchigia.Garanzia.Franchigia = cmbMalattiaFranchigiafranchigia.SelectedValue
                    .CoperturaMalattiaFormaNucleoFamiliare.Stato = EnabledAndChecked(chkMalattiaFormaNucleoFamiliare)
                    .CoperturaMalattiaGicGem.Stato = EnabledAndChecked(chkMalattiaGicGem)
                    .CoperturaMalattiaGicGem.Garanzia.Massimale = cmbMalattiaGicGemmassimale.SelectedValue
                    .CoperturaMalattiaSempreOperanti.Stato = EnabledAndChecked(chkMalattiaSempreOperanti)
                Else
                    'Malattia
                    EnabledAndChecked(chkMalattiaBase) = .CoperturaMalattia.Stato
                    FormatEuro(lblMalattiaBase, .CoperturaMalattia)
                    'Assistenza
                    EnabledAndChecked(chkAssistenzaBase) = .CoperturaAssistenza.Stato
                    FormatEuro(lblAssistenzaBase, .CoperturaAssistenza)

                    txtNominativo.Text = .Nominativo
                    'txtNominativo.Enabled = EnableIfAttivo(.CoperturaMalattia.Stato)
                    IntegerBox(txtEta) = .Eta
                    'txtEta.Enabled = EnableIfAttivo(.CoperturaMalattia.Stato)
                    EnabledAndChecked(chkMalattiaRicovero) = .CoperturaMalattiaRicovero.Stato
                    FormatEuro(lblMalattiaRicovero, .CoperturaMalattiaRicovero)
                    cmbMalattiaRicoverocombinazione.Enabled = Enable(.CoperturaMalattiaRicovero.Stato) And .PrimoAssicurato
                    cmbMalattiaRicoverocombinazione.SelectedValue = .CoperturaMalattiaRicovero.Garanzia.Combinazione
                    cmbMalattiaRicoveroIstitutoCuramassimale.Enabled = False 'Enable(.CoperturaMalattiaRicovero.Stato)
                    cmbMalattiaRicoveroIstitutoCuramassimale.SelectedValue = .CoperturaMalattiaRicovero.Garanzia.Garanzie(0).Massimale
                    cmbMalattiaRicoveroAltaSpecializzazionemassimale.Enabled = False 'Enable(.CoperturaMalattiaRicovero.Stato)
                    cmbMalattiaRicoveroAltaSpecializzazionemassimale.SelectedValue = .CoperturaMalattiaRicovero.Garanzia.Garanzie(1).Massimale
                    cmbMalattiaRicoveroCureOncologichemassimale.Enabled = False 'Enable(.CoperturaMalattiaRicovero.Stato)
                    cmbMalattiaRicoveroCureOncologichemassimale.SelectedValue = .CoperturaMalattiaRicovero.Garanzia.Garanzie(2).Massimale

                    EnabledAndChecked(chkMalattiaSupplementari) = .CoperturaMalattiaSupplementari.Stato
                    FormatEuro(lblMalattiaSupplementari, .CoperturaMalattiaSupplementari)
                    cmbMalattiaSupplementariVisitemassimale.Enabled = False 'Enable(.CoperturaMalattiaSupplementari.Stato)
                    cmbMalattiaSupplementariVisitemassimale.SelectedValue = .CoperturaMalattiaSupplementari.Garanzia.Garanzie(0).Massimale
                    cmbMalattiaSupplementariFisioterapiamassimale.Enabled = False 'Enable(.CoperturaMalattiaSupplementari.Stato)
                    cmbMalattiaSupplementariFisioterapiamassimale.SelectedValue = .CoperturaMalattiaSupplementari.Garanzia.Garanzie(1).Massimale
                    cmbMalattiaSupplementariPrevenzionecombinazione.Enabled = False 'Enable(.CoperturaMalattiaSupplementari.Stato)
                    cmbMalattiaSupplementariPrevenzionecombinazione.SelectedValue = .CoperturaMalattiaSupplementari.Garanzia.Garanzie(2).Combinazione
                    cmbMalattiaSupplementariVisitaOdontoiatricacombinazione.Enabled = False 'Enable(.CoperturaMalattiaSupplementari.Stato)
                    cmbMalattiaSupplementariVisitaOdontoiatricacombinazione.SelectedValue = .CoperturaMalattiaSupplementari.Garanzia.Garanzie(3).Combinazione
                    cmbMalattiaSupplementariSedutaIgeneOralecombinazione.Enabled = False 'Enable(.CoperturaMalattiaSupplementari.Stato)
                    cmbMalattiaSupplementariSedutaIgeneOralecombinazione.SelectedValue = .CoperturaMalattiaSupplementari.Garanzia.Garanzie(4).Combinazione
                    cmbMalattiaSupplementariInterventiOdontoiatricimassimale.Enabled = False 'Enable(.CoperturaMalattiaSupplementari.Stato)
                    cmbMalattiaSupplementariInterventiOdontoiatricimassimale.SelectedValue = .CoperturaMalattiaSupplementari.Garanzia.Garanzie(5).Massimale

                    EnabledAndChecked(chkMalattiaFranchigia) = .CoperturaMalattiaFranchigia.Stato
                    FormatEuro(lblMalattiaFranchigia, .CoperturaMalattiaFranchigia)
                    cmbMalattiaFranchigiafranchigia.Enabled = False 'Enable(.CoperturaMalattiaFranchigia.Stato)
                    cmbMalattiaFranchigiafranchigia.SelectedValue = .CoperturaMalattiaFranchigia.Garanzia.Franchigia
                    EnabledAndChecked(chkMalattiaFormaNucleoFamiliare) = .CoperturaMalattiaFormaNucleoFamiliare.Stato
                    FormatEuro(lblMalattiaFormaNucleoFamiliare, .CoperturaMalattiaFormaNucleoFamiliare)
                    EnabledAndChecked(chkMalattiaGicGem) = .CoperturaMalattiaGicGem.Stato
                    FormatEuro(lblMalattiaGicGem, .CoperturaMalattiaGicGem)
                    cmbMalattiaGicGemmassimale.Enabled = Enable(.CoperturaMalattiaGicGem.Stato)
                    cmbMalattiaGicGemmassimale.SelectedValue = .CoperturaMalattiaGicGem.Garanzia.Massimale

                    EnabledAndChecked(chkMalattiaSempreOperanti) = .CoperturaMalattiaSempreOperanti.Stato
                    FormatEuro(lblMalattiaSempreOperanti, .CoperturaMalattiaSempreOperanti)
                    HighlightCheckAndLabel({TableLayoutPanel1})
                End If
            End With
        End Sub
    End Class
End Namespace
