Namespace P02229
    Public Class P02229FE

        Protected Overrides Sub AttachEvents()
            AddHandler cmbAttivitaProfessionale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbFasceIntroiti.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioContenuto.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioRicorsoTerzi.SelectedIndexChanged, AddressOf ValuesChanged

            AddHandler chkResponsabilitaCivileBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbResponsabilitaCivileBaseMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkResponsabilitaCivileMancataRispondenza.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkResponsabilitaCivileFaldaFreatica.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkResponsabilitaCivileDLgs81_2008.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkResponsabilitaCivileFranchigia.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbResponsabilitaCivileFranchigiaFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkResponsabilitaCivileSostituzione.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkResponsabilitaCivileScontoDiff.CheckedChanged, AddressOf ValuesChanged

            AddHandler chkIncendioBase.CheckedChanged, AddressOf ValuesChanged

            AddHandler chkTutelaLegaleBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbTutelaLegaleBaseMassimale.SelectedIndexChanged, AddressOf ValuesChanged

            AddHandler chkInterruzioneProfessioneBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler QuotatorePremio.ClickedHelp, AddressOf MouseClickedHelp
            AddHandler QuotatorePremio.QuotatorePremioChanged, AddressOf ValuesChanged
        End Sub

        Protected Overrides Sub DetachEvents()
            RemoveHandler cmbAttivitaProfessionale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbFasceIntroiti.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbIncendioContenuto.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbIncendioRicorsoTerzi.SelectedIndexChanged, AddressOf ValuesChanged

            RemoveHandler chkResponsabilitaCivileBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler cmbResponsabilitaCivileBaseMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler chkResponsabilitaCivileMancataRispondenza.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkResponsabilitaCivileFaldaFreatica.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkResponsabilitaCivileDLgs81_2008.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkResponsabilitaCivileFranchigia.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler cmbResponsabilitaCivileFranchigiaFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler chkResponsabilitaCivileSostituzione.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkResponsabilitaCivileScontoDiff.CheckedChanged, AddressOf ValuesChanged

            RemoveHandler chkIncendioBase.CheckedChanged, AddressOf ValuesChanged

            RemoveHandler chkTutelaLegaleBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler cmbTutelaLegaleBaseMassimale.SelectedIndexChanged, AddressOf ValuesChanged

            RemoveHandler chkInterruzioneProfessioneBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler QuotatorePremio.ClickedHelp, AddressOf MouseClickedHelp
            RemoveHandler QuotatorePremio.QuotatorePremioChanged, AddressOf ValuesChanged
        End Sub

        Public Sub New()
            InitializeComponent2()
            Me.TabControl1.Controls.Add(Me.docTab)
            Me.QuotatorePremio.Image = Global.UniQuota.My.Resources.Resources.P02229
            Me.docBrowser.Tag = "http://www.utools.it/Unitools/Doc/Prodotti/P02229/IndexDoc.htm"
            Me.docBrowser.Url = New System.Uri(Me.docBrowser.Tag, System.UriKind.Absolute)

            'preventivo = New YouIngegnereArchitetto
            'modello = New P02229ST

            Dim decode As New P02229DE
            'preventivo.Decode = decode
            Me.decode = decode

            helpChm.CodiceProdotto = "P02229"
            If helpChm.FileExists Then
                AgganciaHelp(Me, AddressOf MouseClickedHelp)
            End If

            AttachCombo(QuotatorePremio.cmbFrazionamento, decode.DecodeFrazionamenti)
            AttachCombo(cmbAttivitaProfessionale, decode.DecodeAttivitaProfessionale)
            AttachCombo(cmbFasceIntroiti, decode.DecodeFasceIntroiti)
            AttachCombo(cmbIncendioContenuto, decode.DecodeIncendioContenuto)
            AttachCombo(cmbIncendioRicorsoTerzi, decode.DecodeIncendioRicorsoTerzi)
            AttachCombo(cmbResponsabilitaCivileBaseMassimale, decode.DecodeResponsabilitaCivileBaseMassimale)
            AttachCombo(cmbResponsabilitaCivileFranchigiaFranchigia, decode.DecodeResponsabilitaCivileFranchigiaFranchigia)
            AttachCombo(cmbTutelaLegaleBaseMassimale, decode.DecodeTutelaLegaleBaseMassimale)

            'preventivo.Inizializza()
            'preventivo.ValidaECalcola()
            'PreventivoToControls()
            Panels = {TableLayoutPanel1}
        End Sub

        Protected Overrides Sub ControlsToPreventivo(ByVal diretto As Boolean)
            With TryCast(preventivo, YouIngegnereArchitetto)

                If diretto Then
                    .AttivitaProfessionale = cmbAttivitaProfessionale.SelectedValue
                    .FasceIntroiti = cmbFasceIntroiti.SelectedValue

                    'ResponsabilitaCivile
                    .CoperturaResponsabilitaCivileBase.Stato = EnabledAndChecked(chkResponsabilitaCivileBase)
                    .CoperturaResponsabilitaCivileBase.Garanzia.Massimale = cmbResponsabilitaCivileBaseMassimale.SelectedValue
                    .CoperturaResponsabilitaCivileMancataRispondenza.Stato = EnabledAndChecked(chkResponsabilitaCivileMancataRispondenza)
                    .CoperturaResponsabilitaCivileFaldaFreatica.Stato = EnabledAndChecked(chkResponsabilitaCivileFaldaFreatica)
                    .CoperturaResponsabilitaCivileDLgs81_2008.Stato = EnabledAndChecked(chkResponsabilitaCivileDLgs81_2008)
                    .CoperturaResponsabilitaCivileFranchigia.Stato = EnabledAndChecked(chkResponsabilitaCivileFranchigia)
                    .CoperturaResponsabilitaCivileFranchigia.Garanzia.Franchigia = cmbResponsabilitaCivileFranchigiaFranchigia.SelectedValue
                    .CoperturaResponsabilitaCivileScontoDiff.Stato = EnabledAndChecked(chkResponsabilitaCivileScontoDiff)

                    'Incendio
                    .CoperturaIncendioBase.Stato = EnabledAndChecked(chkIncendioBase)
                    .IncendioContenuto = cmbIncendioContenuto.SelectedValue
                    .IncendioRicorsoTerzi = cmbIncendioRicorsoTerzi.SelectedValue

                    'TutelaLegale
                    .CoperturaTutelaLegaleBase.Stato = EnabledAndChecked(chkTutelaLegaleBase)
                    .CoperturaTutelaLegaleBase.Garanzia.Massimale = cmbTutelaLegaleBaseMassimale.SelectedValue

                    'InterruzioneProfessione
                    .CoperturaInterruzioneProfessioneBase.Stato = EnabledAndChecked(chkInterruzioneProfessioneBase)

                    .ScontoSostituzionePolizza.Stato = EnabledAndChecked(chkResponsabilitaCivileSostituzione)
                Else
                    cmbAttivitaProfessionale.SelectedValue = CInt(.AttivitaProfessionale)
                    cmbAttivitaProfessionale.Enabled = True
                    cmbFasceIntroiti.SelectedValue = CInt(.FasceIntroiti)
                    cmbFasceIntroiti.Enabled = True

                    'ResponsabilitaCivile
                    EnabledAndChecked(chkResponsabilitaCivileBase) = .CoperturaResponsabilitaCivileBase.Stato
                    FormatEuro(lblResponsabilitaCivileBase, .CoperturaResponsabilitaCivileBase)
                    cmbResponsabilitaCivileBaseMassimale.Enabled = Enable(.CoperturaResponsabilitaCivileBase.Stato)
                    cmbResponsabilitaCivileBaseMassimale.SelectedValue = .CoperturaResponsabilitaCivileBase.Garanzia.Massimale
                    EnabledAndChecked(chkResponsabilitaCivileMancataRispondenza) = .CoperturaResponsabilitaCivileMancataRispondenza.Stato
                    FormatEuro(lblResponsabilitaCivileMancataRispondenza, .CoperturaResponsabilitaCivileMancataRispondenza)
                    EnabledAndChecked(chkResponsabilitaCivileFaldaFreatica) = .CoperturaResponsabilitaCivileFaldaFreatica.Stato
                    FormatEuro(lblResponsabilitaCivileFaldaFreatica, .CoperturaResponsabilitaCivileFaldaFreatica)
                    EnabledAndChecked(chkResponsabilitaCivileDLgs81_2008) = .CoperturaResponsabilitaCivileDLgs81_2008.Stato
                    FormatEuro(lblResponsabilitaCivileDLgs81_2008, .CoperturaResponsabilitaCivileDLgs81_2008)
                    EnabledAndChecked(chkResponsabilitaCivileFranchigia) = .CoperturaResponsabilitaCivileFranchigia.Stato
                    FormatEuro(lblResponsabilitaCivileFranchigia, .CoperturaResponsabilitaCivileFranchigia)
                    cmbResponsabilitaCivileFranchigiaFranchigia.Enabled = Enable(.CoperturaResponsabilitaCivileFranchigia.Stato)
                    cmbResponsabilitaCivileFranchigiaFranchigia.SelectedValue = .CoperturaResponsabilitaCivileFranchigia.Garanzia.Franchigia
                    EnabledAndChecked(chkResponsabilitaCivileScontoDiff) = .CoperturaResponsabilitaCivileScontoDiff.Stato
                    FormatEuro(lblResponsabilitaCivileScontoDiff, .CoperturaResponsabilitaCivileScontoDiff)
                    FormatEuro(lblResponsabilitaCivilePremio, .SezioneResponsabilitaCivile)
                    lblResponsabilitaCivileScontoMax.Text = "(Cumulo massimo degli Sconti ammesso " & FormatEuro(.ResponsabilitaCivileScontoMax) & ")"

                    'Incendio
                    EnabledAndChecked(chkIncendioBase) = .CoperturaIncendioBase.Stato
                    FormatEuro(lblIncendioBase, .CoperturaIncendioBase)
                    cmbIncendioContenuto.Enabled = Enable(.CoperturaIncendioBase.Stato)
                    cmbIncendioContenuto.SelectedValue = CInt(.IncendioContenuto)
                    cmbIncendioRicorsoTerzi.Enabled = Enable(.CoperturaIncendioBase.Stato)
                    cmbIncendioRicorsoTerzi.SelectedValue = CInt(.IncendioRicorsoTerzi)

                    'TutelaLegale
                    EnabledAndChecked(chkTutelaLegaleBase) = .CoperturaTutelaLegaleBase.Stato
                    FormatEuro(lblTutelaLegaleBase, .CoperturaTutelaLegaleBase)
                    cmbTutelaLegaleBaseMassimale.Enabled = Enable(.CoperturaTutelaLegaleBase.Stato)
                    cmbTutelaLegaleBaseMassimale.SelectedValue = .CoperturaTutelaLegaleBase.Garanzia.Massimale

                    'InterruzioneProfessione
                    EnabledAndChecked(chkInterruzioneProfessioneBase) = .CoperturaInterruzioneProfessioneBase.Stato
                    FormatEuro(lblInterruzioneProfessioneBase, .CoperturaInterruzioneProfessioneBase)

                    '
                    EnabledAndChecked(chkResponsabilitaCivileSostituzione) = .ScontoSostituzionePolizza.Stato
                    FormatEuro(lblResponsabilitaCivileSostituzione, .ScontoSostituzionePolizza)
                End If


                'RIEPILOGO GARANZIE
                If diretto = False Then
                    lblSezioneTotalePremio.Text = FormatEuro(.PremioLabel)
                End If
            End With
        End Sub


    End Class
End Namespace
