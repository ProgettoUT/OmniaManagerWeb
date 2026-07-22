Namespace P01203
    Public Class P01203FE

        Protected Overrides Sub AttachEvents()
            AddHandler cmbTipologiaVeicolo.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbInfortuniScelta.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbInfortuniForma.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbScontoPoliennale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbTipoSoggetto.SelectedIndexChanged, AddressOf ValuesChanged

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
            AddHandler chkInfortuniRicovero.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniRicovero.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniRicovero.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkInfortuniConvalescenza.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniConvalescenza.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniConvalescenza.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkInfortuniImmobilizzazione.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniImmobilizzazione.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaInfortuniImmobilizzazione.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkInfortuniTabellaINAIL.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkInfortuniFranchigia3.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkInfortuniSuperValutazione.CheckedChanged, AddressOf ValuesChanged

            AddHandler chkSalvaCircolazioneBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbSalvaCircolazioneBasemassimale.SelectedIndexChanged, AddressOf ValuesChanged

            AddHandler chkAssistenzaBase.CheckedChanged, AddressOf ValuesChanged

            AddHandler chkScontiBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler QuotatorePremio.ClickedHelp, AddressOf MouseClickedHelp
            AddHandler QuotatorePremio.QuotatorePremioChanged, AddressOf ValuesChanged
        End Sub

        Protected Overrides Sub DetachEvents()
            RemoveHandler cmbTipologiaVeicolo.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbInfortuniScelta.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbInfortuniForma.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbScontoPoliennale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbTipoSoggetto.SelectedIndexChanged, AddressOf ValuesChanged

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
            RemoveHandler chkInfortuniRicovero.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaInfortuniRicovero.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaInfortuniRicovero.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkInfortuniConvalescenza.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaInfortuniConvalescenza.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaInfortuniConvalescenza.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkInfortuniImmobilizzazione.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaInfortuniImmobilizzazione.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaInfortuniImmobilizzazione.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkInfortuniTabellaINAIL.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkInfortuniFranchigia3.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkInfortuniSuperValutazione.CheckedChanged, AddressOf ValuesChanged

            RemoveHandler chkSalvaCircolazioneBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler cmbSalvaCircolazioneBasemassimale.SelectedIndexChanged, AddressOf ValuesChanged

            RemoveHandler chkAssistenzaBase.CheckedChanged, AddressOf ValuesChanged

            RemoveHandler chkScontiBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler QuotatorePremio.ClickedHelp, AddressOf MouseClickedHelp
            RemoveHandler QuotatorePremio.QuotatorePremioChanged, AddressOf ValuesChanged
        End Sub

        Public Sub New()
            InitializeComponent2()
            Me.TabControl1.Controls.Add(Me.docTab)
            Me.QuotatorePremio.Image = Global.UniQuota.My.Resources.Resources.P01203
            Me.docBrowser.Tag = "http://www.utools.it/Unitools/Doc/Prodotti/Circolazione/IndexDoc.htm"
            Me.docBrowser.Url = New System.Uri(Me.docBrowser.Tag, System.UriKind.Absolute)

            'preventivo = New Circolazione
            'modello = New P01203ST

            Dim decode As New P01203DE
            'preventivo.Decode = decode
            Me.decode = decode

            helpChm.CodiceProdotto = "P01203"
            If helpChm.FileExists Then
                AgganciaHelp(Me, AddressOf MouseClickedHelp)
            End If

            AttachCombo(QuotatorePremio.cmbFrazionamento, decode.DecodeFrazionamenti)
            AttachCombo(cmbTipologiaVeicolo, decode.DecodeTipologiaVeicolo)
            AttachCombo(cmbInfortuniScelta, decode.DecodeInfortuniScelta)
            AttachCombo(cmbInfortuniForma, decode.DecodeInfortuniForma)
            AttachCombo(cmbScontoPoliennale, decode.DecodeScontoPoliennale)
            AttachCombo(cmbSalvaCircolazioneBasemassimale, decode.DecodeSalvaCircolazioneBasemassimale)
            AttachCombo(cmbTipoSoggetto, decode.DecodeTipoSoggetto)

            Panels = {TableLayoutPanel1}
        End Sub

        Protected Overrides Sub ControlsToPreventivo(ByVal diretto As Boolean)
            With TryCast(preventivo, Circolazione)

                If diretto Then

                    'Infortuni
                    .CoperturaInfortuniBase.Stato = EnabledAndChecked(chkInfortuniBase)
                    .TipologiaVeicolo = cmbTipologiaVeicolo.SelectedValue
                    .InfortuniScelta = cmbInfortuniScelta.SelectedValue
                    .InfortuniForma = cmbInfortuniForma.SelectedValue
                    .TipoSoggetto = cmbTipoSoggetto.SelectedValue
                    .CoperturaInfortuniMorte.Stato = EnabledAndChecked(chkInfortuniMorte)
                    .PartitaInfortuniMorte.SommaAssicurata = CurrencyBox(txtPartitaInfortuniMorte)
                    .CoperturaInfortuniIP.Stato = EnabledAndChecked(chkInfortuniIP)
                    .PartitaInfortuniIP.SommaAssicurata = CurrencyBox(txtPartitaInfortuniIP)
                    .CoperturaInfortuniSpeseMediche.Stato = EnabledAndChecked(chkInfortuniSpeseMediche)
                    .PartitaInfortuniSpeseMediche.SommaAssicurata = CurrencyBox(txtPartitaInfortuniSpeseMediche)
                    .CoperturaInfortuniRicovero.Stato = EnabledAndChecked(chkInfortuniRicovero)
                    .CoperturaInfortuniConvalescenza.Stato = EnabledAndChecked(chkInfortuniConvalescenza)
                    .PartitaInfortuniRicoveroConvalescenza.SommaAssicurata = CurrencyBox(txtPartitaInfortuniRicovero)
                    .CoperturaInfortuniImmobilizzazione.Stato = EnabledAndChecked(chkInfortuniImmobilizzazione)
                    .PartitaInfortuniImmobilizzazione.SommaAssicurata = CurrencyBox(txtPartitaInfortuniImmobilizzazione)
                    .CoperturaInfortuniTabellaINAIL.Stato = EnabledAndChecked(chkInfortuniTabellaINAIL)
                    .CoperturaInfortuniFranchigia3.Stato = EnabledAndChecked(chkInfortuniFranchigia3)
                    .CoperturaInfortuniSuperValutazione.Stato = EnabledAndChecked(chkInfortuniSuperValutazione)

                    'SalvaCircolazione
                    .CoperturaSalvaCircolazioneBase.Stato = EnabledAndChecked(chkSalvaCircolazioneBase)
                    .CoperturaSalvaCircolazioneBase.Garanzia.massimale = cmbSalvaCircolazioneBasemassimale.SelectedValue

                    'Assistenza
                    .CoperturaAssistenzaBase.Stato = EnabledAndChecked(chkAssistenzaBase)

                    'Sconti
                    .CoperturaScontiBase.Stato = EnabledAndChecked(chkScontiBase)
                    .ScontoPoliennale = cmbScontoPoliennale.SelectedValue
                Else

                    'Infortuni
                    EnabledAndChecked(chkInfortuniBase) = .CoperturaInfortuniBase.Stato
                    FormatEuro(lblInfortuniBase, .SezioneInfortuni)
                    cmbTipologiaVeicolo.Enabled = EnableIfAttivo(.CoperturaInfortuniBase.Stato)
                    cmbTipologiaVeicolo.SelectedValue = CInt(.TipologiaVeicolo)
                    cmbInfortuniScelta.Enabled = EnableIfAttivo(.CoperturaInfortuniBase.Stato)
                    cmbInfortuniScelta.SelectedValue = CInt(.InfortuniScelta)
                    cmbInfortuniForma.Enabled = EnableIfAttivo(.CoperturaInfortuniBase.Stato)
                    cmbInfortuniForma.SelectedValue = CInt(.InfortuniForma)
                    cmbTipoSoggetto.Enabled = EnableIfAttivo(.CoperturaInfortuniBase.Stato)
                    cmbTipoSoggetto.SelectedValue = CInt(.TipoSoggetto)
                    EnabledAndChecked(chkInfortuniMorte) = .CoperturaInfortuniMorte.Stato
                    CurrencyBox(txtPartitaInfortuniMorte) = .PartitaInfortuniMorte.SommaAssicurata
                    txtPartitaInfortuniMorte.Enabled = Enable(.CoperturaInfortuniMorte.Stato)
                    FormatEuro(lblInfortuniMorte, .CoperturaInfortuniMorte)
                    EnabledAndChecked(chkInfortuniIP) = .CoperturaInfortuniIP.Stato
                    CurrencyBox(txtPartitaInfortuniIP) = .PartitaInfortuniIP.SommaAssicurata
                    txtPartitaInfortuniIP.Enabled = Enable(.CoperturaInfortuniIP.Stato)
                    FormatEuro(lblInfortuniIP, .CoperturaInfortuniIP)
                    EnabledAndChecked(chkInfortuniSpeseMediche) = .CoperturaInfortuniSpeseMediche.Stato
                    CurrencyBox(txtPartitaInfortuniSpeseMediche) = .PartitaInfortuniSpeseMediche.SommaAssicurata
                    txtPartitaInfortuniSpeseMediche.Enabled = Enable(.CoperturaInfortuniSpeseMediche.Stato)
                    FormatEuro(lblInfortuniSpeseMediche, .CoperturaInfortuniSpeseMediche)
                    EnabledAndChecked(chkInfortuniRicovero) = .CoperturaInfortuniRicovero.Stato
                    CurrencyBox(txtPartitaInfortuniRicovero) = .PartitaInfortuniRicoveroConvalescenza.SommaAssicurata
                    txtPartitaInfortuniRicovero.Enabled = Enable(.CoperturaInfortuniRicovero.Stato)
                    FormatEuro(lblInfortuniRicovero, .CoperturaInfortuniRicovero)

                    EnabledAndChecked(chkInfortuniConvalescenza) = .CoperturaInfortuniConvalescenza.Stato
                    CurrencyBox(txtPartitaInfortuniConvalescenza) = .PartitaInfortuniRicoveroConvalescenza.SommaAssicurata
                    txtPartitaInfortuniConvalescenza.Enabled = Enable(.CoperturaInfortuniConvalescenza.Stato)
                    FormatEuro(lblInfortuniConvalescenza, .CoperturaInfortuniConvalescenza)

                    EnabledAndChecked(chkInfortuniImmobilizzazione) = .CoperturaInfortuniImmobilizzazione.Stato
                    CurrencyBox(txtPartitaInfortuniImmobilizzazione) = .PartitaInfortuniImmobilizzazione.SommaAssicurata
                    txtPartitaInfortuniImmobilizzazione.Enabled = Enable(.CoperturaInfortuniImmobilizzazione.Stato)
                    FormatEuro(lblInfortuniImmobilizzazione, .CoperturaInfortuniImmobilizzazione)
                    EnabledAndChecked(chkInfortuniTabellaINAIL) = .CoperturaInfortuniTabellaINAIL.Stato
                    FormatEuro(lblInfortuniTabellaINAIL, .CoperturaInfortuniTabellaINAIL)
                    EnabledAndChecked(chkInfortuniFranchigia3) = .CoperturaInfortuniFranchigia3.Stato
                    FormatEuro(lblInfortuniFranchigia3, .CoperturaInfortuniFranchigia3)
                    EnabledAndChecked(chkInfortuniSuperValutazione) = .CoperturaInfortuniSuperValutazione.Stato
                    FormatEuro(lblInfortuniSuperValutazione, .CoperturaInfortuniSuperValutazione)

                    'SalvaCircolazione
                    EnabledAndChecked(chkSalvaCircolazioneBase) = .CoperturaSalvaCircolazioneBase.Stato
                    FormatEuro(lblSalvaCircolazioneBase, .CoperturaSalvaCircolazioneBase)
                    cmbSalvaCircolazioneBasemassimale.Enabled = Enable(.CoperturaSalvaCircolazioneBase.Stato)
                    cmbSalvaCircolazioneBasemassimale.SelectedValue = .CoperturaSalvaCircolazioneBase.Garanzia.massimale

                    'Assistenza
                    EnabledAndChecked(chkAssistenzaBase) = .CoperturaAssistenzaBase.Stato
                    FormatEuro(lblAssistenzaBase, .CoperturaAssistenzaBase)

                    'Sconti
                    EnabledAndChecked(chkScontiBase) = .CoperturaScontiBase.Stato
                    FormatEuro(lblScontiBase, .CoperturaScontiBase)
                    cmbScontoPoliennale.Enabled = Enable(.CoperturaScontiBase.Stato)
                    cmbScontoPoliennale.SelectedValue = CInt(.ScontoPoliennale)
                End If


                'RIEPILOGO GARANZIE
                If diretto = False Then
                    lblSezioneTotalePremio.Text = FormatEuro(.PremioLabel)
                End If
            End With
        End Sub


    End Class
End Namespace
