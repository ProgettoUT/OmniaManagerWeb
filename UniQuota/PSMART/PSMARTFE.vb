Namespace PSMART
    Public Class PSMARTFE

        Protected Overrides Sub AttachEvents()
            AddHandler cmbCasaIncendioScelta.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbCasaDurataPoliennale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbInfortuniScelta.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbInfortuniDurataPoliennale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbAttivitaTipo.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbAttivitaScelta.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbAttivitaDurataPoliennale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbProvincia.SelectedIndexChanged, AddressOf ValuesChanged

            AddHandler chkCasaIncendio.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkCasaIncendioBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkCasaFurtoBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkCasaRCBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkCasaAssistenzaBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkCasaPoliennale.CheckedChanged, AddressOf ValuesChanged

            AddHandler chkInfortuniBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkInfortuniMorte.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniMorte.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniMorte.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkInfortuniIP.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniIP.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniIP.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkInfortuniSpeseMediche.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniSpeseMediche.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniSpeseMediche.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkInfortuniDiarieDegenza.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniDiarieDegenza.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniDiarieDegenza.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkInfortuniDiarieDayHospital.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniDiarieDayHospital.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniDiarieDayHospital.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkInfortuniDiarieImmobilizzazione.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniDiarieImmobilizzazione.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniDiarieImmobilizzazione.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkInfortuniFamiglia.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkInfortuniFranchigia.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkInfortuniPoliennale.CheckedChanged, AddressOf ValuesChanged

            AddHandler chkAttivitaRCBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkAttivitaRCT.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaAttivitaRCT.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaAttivitaRCT.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkAttivitaRCL.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaAttivitaRCL.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaAttivitaRCL.KeyPress, AddressOf TextBoxKeyPress

            AddHandler chkAttivitaIncendioFC.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkAttivitaAttiVandalici.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkAttivitaPoliennale.CheckedChanged, AddressOf ValuesChanged

            AddHandler QuotatorePremio.ClickedHelp, AddressOf MouseClickedHelp
            AddHandler QuotatorePremio.QuotatorePremioChanged, AddressOf ValuesChanged
        End Sub

        Protected Overrides Sub DetachEvents()
            RemoveHandler cmbCasaIncendioScelta.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbCasaDurataPoliennale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbInfortuniScelta.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbInfortuniDurataPoliennale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbAttivitaTipo.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbAttivitaScelta.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbAttivitaDurataPoliennale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbProvincia.SelectedIndexChanged, AddressOf ValuesChanged

            RemoveHandler chkCasaIncendio.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkCasaIncendioBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkCasaFurtoBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkCasaRCBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkCasaAssistenzaBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkCasaPoliennale.CheckedChanged, AddressOf ValuesChanged

            RemoveHandler chkInfortuniBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkInfortuniMorte.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaInfortuniMorte.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaInfortuniMorte.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkInfortuniIP.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaInfortuniIP.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaInfortuniIP.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkInfortuniSpeseMediche.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaInfortuniSpeseMediche.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaInfortuniSpeseMediche.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkInfortuniDiarieDegenza.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaInfortuniDiarieDegenza.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaInfortuniDiarieDegenza.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkInfortuniDiarieDayHospital.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaInfortuniDiarieDayHospital.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaInfortuniDiarieDayHospital.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkInfortuniDiarieImmobilizzazione.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaInfortuniDiarieImmobilizzazione.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaInfortuniDiarieImmobilizzazione.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkInfortuniFamiglia.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkInfortuniFranchigia.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkInfortuniPoliennale.CheckedChanged, AddressOf ValuesChanged

            RemoveHandler chkAttivitaRCBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkAttivitaRCT.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaAttivitaRCT.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaAttivitaRCT.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkAttivitaRCL.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaAttivitaRCL.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaAttivitaRCL.KeyPress, AddressOf TextBoxKeyPress

            RemoveHandler chkAttivitaIncendioFC.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkAttivitaAttiVandalici.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkAttivitaPoliennale.CheckedChanged, AddressOf ValuesChanged

            RemoveHandler QuotatorePremio.ClickedHelp, AddressOf MouseClickedHelp
            RemoveHandler QuotatorePremio.QuotatorePremioChanged, AddressOf ValuesChanged
        End Sub

        Public Sub New()
            InitializeComponent2()
            Me.TabControl1.Controls.Add(Me.docTab)
            Me.QuotatorePremio.Image = Global.UniQuota.My.Resources.Resources.PSMART
            Me.docBrowser.Tag = "http://www.utools.it/Unitools/Doc/Prodotti/PSMART/IndexDoc.htm"
            Me.docBrowser.Url = New System.Uri(Me.docBrowser.Tag, System.UriKind.Absolute)

            'preventivo = New smart
            'modello = New PSMARTST

            Dim decode As New PSMARTDE
            'preventivo.Decode = decode
            Me.decode = decode

            helpChm.CodiceProdotto = "PSMART"
            If helpChm.FileExists Then
                AgganciaHelp(Me, AddressOf MouseClickedHelp)
            End If

            AttachCombo(QuotatorePremio.cmbFrazionamento, decode.DecodeFrazionamenti)
            AttachCombo(cmbCasaIncendioScelta, decode.DecodeCasaIncendioScelta)
            AttachCombo(cmbCasaDurataPoliennale, decode.DecodeCasaDurataPoliennale)
            AttachCombo(cmbInfortuniScelta, decode.DecodeInfortuniScelta)
            AttachCombo(cmbInfortuniDurataPoliennale, decode.DecodeInfortuniDurataPoliennale)
            AttachCombo(cmbAttivitaTipo, decode.DecodeAttivitaTipo)
            AttachCombo(cmbAttivitaScelta, decode.DecodeAttivitaScelta)
            AttachCombo(cmbAttivitaDurataPoliennale, decode.DecodeAttivitaDurataPoliennale)
            AttachCombo(cmbProvincia, Luogo.Province)

            AttachCombo(cmbAssicuratoProfessione, Essig.Lista.From("PSMARTTP"))
            cmbAssicuratoTipoOccupazione.DataSource = Essig.Lista.From({{"D", "Dipendente"}, {"L", "Libero Professonista"}})

            'preventivo.Inizializza()
            'preventivo.ValidaECalcola()
            'PreventivoToControls()
            Panels = {TableLayoutPanel2, TableLayoutPanel3, TableLayoutPanel4}
        End Sub

        Protected Overrides Sub ControlsToPreventivo(ByVal diretto As Boolean)
            With TryCast(preventivo, smart)

                If diretto Then
                    .Provincia = cmbProvincia.SelectedValue

                    'Casa
                    .CasaScelta = cmbCasaIncendioScelta.SelectedValue
                    .CoperturaCasaIncendio.Stato = EnabledAndChecked(chkCasaIncendio)
                    .CoperturaCasaIncendioBase.Stato = EnabledAndChecked(chkCasaIncendioBase)
                    .CoperturaCasaPoliennale.Stato = EnabledAndChecked(chkCasaPoliennale)
                    .CasaDurataPoliennale = cmbCasaDurataPoliennale.SelectedValue

                    .CoperturaCasaFurtoBase.Stato = EnabledAndChecked(chkCasaFurtoBase)
                    .CoperturaCasaRCBase.Stato = EnabledAndChecked(chkCasaRCBase)
                    .CoperturaCasaAssistenzaBase.Stato = EnabledAndChecked(chkCasaAssistenzaBase)

                    'Infortuni
                    .CoperturaInfortuniBase.Stato = EnabledAndChecked(chkInfortuniBase)
                    .InfortuniScelta = cmbInfortuniScelta.SelectedValue
                    .CoperturaInfortuniMorte.Stato = EnabledAndChecked(chkInfortuniMorte)
                    .PartitaInfortuniMorte.SommaAssicurata = CurrencyBox(txtPartitaInfortuniMorte)
                    .CoperturaInfortuniIP.Stato = EnabledAndChecked(chkInfortuniIP)
                    .PartitaInfortuniIP.SommaAssicurata = CurrencyBox(txtPartitaInfortuniIP)
                    .CoperturaInfortuniSpeseMediche.Stato = EnabledAndChecked(chkInfortuniSpeseMediche)
                    .PartitaInfortuniSpeseMediche.SommaAssicurata = CurrencyBox(txtPartitaInfortuniSpeseMediche)
                    .CoperturaInfortuniDiarieDegenza.Stato = EnabledAndChecked(chkInfortuniDiarieDegenza)
                    .PartitaInfortuniDiarieDegenza.SommaAssicurata = CurrencyBox(txtPartitaInfortuniDiarieDegenza)
                    .CoperturaInfortuniDiarieDayHospital.Stato = EnabledAndChecked(chkInfortuniDiarieDayHospital)
                    .PartitaInfortuniDiarieDayHospital.SommaAssicurata = CurrencyBox(txtPartitaInfortuniDiarieDayHospital)
                    .CoperturaInfortuniDiarieImmobilizzazione.Stato = EnabledAndChecked(chkInfortuniDiarieImmobilizzazione)
                    .PartitaInfortuniDiarieImmobilizzazione.SommaAssicurata = CurrencyBox(txtPartitaInfortuniDiarieImmobilizzazione)
                    .CoperturaInfortuniFamiglia.Stato = EnabledAndChecked(chkInfortuniFamiglia)
                    .CoperturaInfortuniFranchigia.Stato = EnabledAndChecked(chkInfortuniFranchigia)
                    .CoperturaInfortuniPoliennale.Stato = EnabledAndChecked(chkInfortuniPoliennale)
                    .InfortuniDurataPoliennale = cmbInfortuniDurataPoliennale.SelectedValue

                    'AttivitaRC
                    .CoperturaAttivitaRCBase.Stato = EnabledAndChecked(chkAttivitaRCBase)
                    .AttivitaTipo = cmbAttivitaTipo.SelectedValue
                    .AttivitaScelta = cmbAttivitaScelta.SelectedValue
                    .CoperturaAttivitaRCT.Stato = EnabledAndChecked(chkAttivitaRCT)
                    .PartitaAttivitaRCT.SommaAssicurata = CurrencyBox(txtPartitaAttivitaRCT)
                    .CoperturaAttivitaRCL.Stato = EnabledAndChecked(chkAttivitaRCL)
                    .PartitaAttivitaRCL.SommaAssicurata = CurrencyBox(txtPartitaAttivitaRCL)

                    'AttivitaIncendio
                    .CoperturaAttivitaIncendioFC.Stato = EnabledAndChecked(chkAttivitaIncendioFC)
                    .CoperturaAttivitaAttiVandalici.Stato = EnabledAndChecked(chkAttivitaAttiVandalici)
                    .CoperturaAttivitaPoliennale.Stato = EnabledAndChecked(chkAttivitaPoliennale)
                    .AttivitaDurataPoliennale = cmbAttivitaDurataPoliennale.SelectedValue

                    .EssigAssicuratoNominativo = txtAssicuratoNominativo.Text
                    .EssigAssicuratoCodiceFiscale = txtAssicuratoCF.Text
                    .EssigAssicuratoProfessione = CType(cmbAssicuratoProfessione.SelectedItem, Essig.Elemento).Codice
                    .EssigAssicuratoClasseProfessionale = CType(cmbAssicuratoProfessione.SelectedItem, Essig.Elemento).Extra1
                    .EssigAssicuratoTipoOccupazione = CType(cmbAssicuratoTipoOccupazione.SelectedItem, Essig.Elemento).Codice
                Else
                    'CasaIncendio
                    cmbProvincia.SelectedValue = .Provincia
                    cmbProvincia.Enabled = .CoperturaCasaIncendio.IsAttivo

                    EnabledAndChecked(chkCasaIncendio) = .CoperturaCasaIncendio.Stato
                    lblCasaIncendio.Text = FormatEuro(.CoperturaCasaIncendio.PremioLabel + .CoperturaCasaFurtoBase.PremioLabel + .CoperturaCasaRCBase.PremioLabel + .CoperturaCasaAssistenzaBase.PremioLabel)
                    EnabledAndChecked(chkCasaIncendioBase) = .CoperturaCasaIncendioBase.Stato
                    FormatEuro(lblCasaIncendioBase, .CoperturaCasaIncendioBase)
                    cmbCasaIncendioScelta.Enabled = EnableIfAttivo(.CoperturaCasaIncendioBase.Stato)
                    cmbCasaIncendioScelta.SelectedValue = CInt(.CasaScelta)
                    EnabledAndChecked(chkCasaPoliennale) = .CoperturaCasaPoliennale.Stato
                    FormatEuro(lblCasaPoliennale, .CoperturaCasaPoliennale)
                    cmbCasaDurataPoliennale.Enabled = Enable(.CoperturaCasaPoliennale.Stato)
                    cmbCasaDurataPoliennale.SelectedValue = CInt(.CasaDurataPoliennale)

                    'CasaFurto
                    EnabledAndChecked(chkCasaFurtoBase) = .CoperturaCasaFurtoBase.Stato
                    FormatEuro(lblCasaFurtoBase, .CoperturaCasaFurtoBase)

                    'CasaRC
                    EnabledAndChecked(chkCasaRCBase) = .CoperturaCasaRCBase.Stato
                    FormatEuro(lblCasaRCBase, .CoperturaCasaRCBase)

                    'CasaAssistenza
                    EnabledAndChecked(chkCasaAssistenzaBase) = .CoperturaCasaAssistenzaBase.Stato
                    FormatEuro(lblCasaAssistenzaBase, .CoperturaCasaAssistenzaBase)

                    'Infortuni
                    EnabledAndChecked(chkInfortuniBase) = .CoperturaInfortuniBase.Stato
                    FormatEuro(lblInfortuniBase, .CoperturaInfortuniBase)
                    cmbInfortuniScelta.Enabled = EnableIfAttivo(.CoperturaInfortuniBase.Stato)
                    cmbInfortuniScelta.SelectedValue = CInt(.InfortuniScelta)
                    EnabledAndChecked(chkInfortuniMorte) = .CoperturaInfortuniMorte.Stato
                    CurrencyBox(txtPartitaInfortuniMorte) = .PartitaInfortuniMorte.SommaAssicurata
                    txtPartitaInfortuniMorte.Enabled = False 'Enable(.CoperturaInfortuniMorte.Stato)
                    FormatEuro(lblInfortuniMorte, .CoperturaInfortuniMorte)
                    EnabledAndChecked(chkInfortuniIP) = .CoperturaInfortuniIP.Stato
                    CurrencyBox(txtPartitaInfortuniIP) = .PartitaInfortuniIP.SommaAssicurata
                    txtPartitaInfortuniIP.Enabled = False 'Enable(.CoperturaInfortuniIP.Stato)
                    FormatEuro(lblInfortuniIP, .CoperturaInfortuniIP)
                    EnabledAndChecked(chkInfortuniSpeseMediche) = .CoperturaInfortuniSpeseMediche.Stato
                    CurrencyBox(txtPartitaInfortuniSpeseMediche) = .PartitaInfortuniSpeseMediche.SommaAssicurata
                    txtPartitaInfortuniSpeseMediche.Enabled = False 'Enable(.CoperturaInfortuniSpeseMediche.Stato)
                    FormatEuro(lblInfortuniSpeseMediche, .CoperturaInfortuniSpeseMediche)
                    EnabledAndChecked(chkInfortuniDiarieDegenza) = .CoperturaInfortuniDiarieDegenza.Stato
                    CurrencyBox(txtPartitaInfortuniDiarieDegenza) = .PartitaInfortuniDiarieDegenza.SommaAssicurata
                    txtPartitaInfortuniDiarieDegenza.Enabled = False 'Enable(.CoperturaInfortuniDiarieDegenza.Stato)
                    FormatEuro(lblInfortuniDiarieDegenza, .CoperturaInfortuniDiarieDegenza)
                    EnabledAndChecked(chkInfortuniDiarieDayHospital) = .CoperturaInfortuniDiarieDayHospital.Stato
                    CurrencyBox(txtPartitaInfortuniDiarieDayHospital) = .PartitaInfortuniDiarieDayHospital.SommaAssicurata
                    txtPartitaInfortuniDiarieDayHospital.Enabled = False 'Enable(.CoperturaInfortuniDiarieDayHospital.Stato)
                    FormatEuro(lblInfortuniDiarieDayHospital, .CoperturaInfortuniDiarieDayHospital)
                    EnabledAndChecked(chkInfortuniDiarieImmobilizzazione) = .CoperturaInfortuniDiarieImmobilizzazione.Stato
                    CurrencyBox(txtPartitaInfortuniDiarieImmobilizzazione) = .PartitaInfortuniDiarieImmobilizzazione.SommaAssicurata
                    txtPartitaInfortuniDiarieImmobilizzazione.Enabled = False 'Enable(.CoperturaInfortuniDiarieImmobilizzazione.Stato)
                    FormatEuro(lblInfortuniDiarieImmobilizzazione, .CoperturaInfortuniDiarieImmobilizzazione)
                    EnabledAndChecked(chkInfortuniFamiglia) = .CoperturaInfortuniFamiglia.Stato
                    FormatEuro(lblInfortuniFamiglia, .CoperturaInfortuniFamiglia)
                    EnabledAndChecked(chkInfortuniFranchigia) = .CoperturaInfortuniFranchigia.Stato
                    FormatEuro(lblInfortuniFranchigia, .CoperturaInfortuniFranchigia)
                    EnabledAndChecked(chkInfortuniPoliennale) = .CoperturaInfortuniPoliennale.Stato
                    FormatEuro(lblInfortuniPoliennale, .CoperturaInfortuniPoliennale)
                    cmbInfortuniDurataPoliennale.Enabled = Enable(.CoperturaInfortuniPoliennale.Stato)
                    cmbInfortuniDurataPoliennale.SelectedValue = CInt(.InfortuniDurataPoliennale)

                    txtAssicuratoNominativo.Enabled = chkInfortuniBase.Checked
                    txtAssicuratoCF.Enabled = chkInfortuniBase.Checked
                    cmbAssicuratoProfessione.Enabled = chkInfortuniBase.Checked
                    cmbAssicuratoTipoOccupazione.Enabled = chkInfortuniBase.Checked


                    'AttivitaRC
                    EnabledAndChecked(chkAttivitaRCBase) = .CoperturaAttivitaRCBase.Stato
                    If .CoperturaAttivitaPoliennale.IsAttivo Then
                        lblAttivitaRCBase.Text = FormatEuro(.CoperturaAttivitaRCBase.PremioLabel + .CoperturaAttivitaIncendioBase.PremioLabel + .CoperturaAttivitaPoliennale.PremioLabel)
                    Else
                        lblAttivitaRCBase.Text = FormatEuro(.CoperturaAttivitaRCBase.PremioLabel + .CoperturaAttivitaIncendioBase.PremioLabel)
                    End If
                    cmbAttivitaTipo.Enabled = EnableIfAttivo(.CoperturaAttivitaRCBase.Stato)
                    cmbAttivitaTipo.SelectedValue = CInt(.AttivitaTipo)
                    cmbAttivitaScelta.Enabled = EnableIfAttivo(.CoperturaAttivitaRCBase.Stato)
                    cmbAttivitaScelta.SelectedValue = CInt(.AttivitaScelta)
                    EnabledAndChecked(chkAttivitaRCT) = .CoperturaAttivitaRCT.Stato
                    CurrencyBox(txtPartitaAttivitaRCT) = .PartitaAttivitaRCT.SommaAssicurata
                    'txtPartitaAttivitaRCT.Enabled = Enable(.CoperturaAttivitaRCT.Stato)
                    FormatEuro(lblAttivitaRCT, .CoperturaAttivitaRCT)
                    EnabledAndChecked(chkAttivitaRCL) = .CoperturaAttivitaRCL.Stato
                    CurrencyBox(txtPartitaAttivitaRCL) = .PartitaAttivitaRCL.SommaAssicurata
                    'txtPartitaAttivitaRCL.Enabled = Enable(.CoperturaAttivitaRCL.Stato)
                    FormatEuro(lblAttivitaRCL, .CoperturaAttivitaRCL)

                    'AttivitaIncendio
                    EnabledAndChecked(chkAttivitaIncendioFC) = .CoperturaAttivitaIncendioFC.Stato
                    FormatEuro(lblAttivitaIncendioFC, .CoperturaAttivitaIncendioFC)
                    EnabledAndChecked(chkAttivitaAttiVandalici) = .CoperturaAttivitaAttiVandalici.Stato
                    FormatEuro(lblAttivitaAttiVandalici, .CoperturaAttivitaAttiVandalici)
                    EnabledAndChecked(chkAttivitaPoliennale) = .CoperturaAttivitaPoliennale.Stato
                    FormatEuro(lblAttivitaPoliennale, .CoperturaAttivitaPoliennale)
                    cmbAttivitaDurataPoliennale.Enabled = Enable(.CoperturaAttivitaPoliennale.Stato)
                    cmbAttivitaDurataPoliennale.SelectedValue = CInt(.AttivitaDurataPoliennale)

                    txtAssicuratoNominativo.Text = preventivo.Cliente.Nominativo
                    txtAssicuratoCF.Text = preventivo.Cliente.CodiceFiscale

                End If


                'RIEPILOGO GARANZIE
                If diretto = False Then

                    lblSezioneCasaIncendioPremio.Text = FormatEuro(.SezioneCasaIncendio.PremioLabel)
                    chkSezioneCasaIncendio.Checked = .SezioneCasaIncendio.IsAttivo
                    chkSezioneCasaIncendio.Enabled = False

                    lblSezioneCasaFurtoPremio.Text = FormatEuro(.SezioneCasaFurto.PremioLabel)
                    chkSezioneCasaFurto.Checked = .SezioneCasaFurto.IsAttivo
                    chkSezioneCasaFurto.Enabled = False

                    lblSezioneCasaRCPremio.Text = FormatEuro(.SezioneCasaRC.PremioLabel)
                    chkSezioneCasaRC.Checked = .SezioneCasaRC.IsAttivo
                    chkSezioneCasaRC.Enabled = False

                    lblSezioneCasaAssistenzaPremio.Text = FormatEuro(.SezioneCasaAssistenza.PremioLabel)
                    chkSezioneCasaAssistenza.Checked = .SezioneCasaAssistenza.IsAttivo
                    chkSezioneCasaAssistenza.Enabled = False

                    lblSezioneInfortuniPremio.Text = FormatEuro(.SezioneInfortuni.PremioLabel)
                    chkSezioneInfortuni.Checked = .SezioneInfortuni.IsAttivo
                    chkSezioneInfortuni.Enabled = False

                    lblSezioneAttivitaRCPremio.Text = FormatEuro(.SezioneAttivitaRC.PremioLabel)
                    chkSezioneAttivitaRC.Checked = .SezioneAttivitaRC.IsAttivo
                    chkSezioneAttivitaRC.Enabled = False

                    lblSezioneAttivitaIncendioPremio.Text = FormatEuro(.SezioneAttivitaIncendio.PremioLabel)
                    chkSezioneAttivitaIncendio.Checked = .SezioneAttivitaIncendio.IsAttivo
                    chkSezioneAttivitaIncendio.Enabled = False

                    lblSezioneTotalePremio.Text = FormatEuro(.PremioLabel)
                End If
            End With
        End Sub
    End Class
End Namespace
