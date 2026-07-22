Namespace P07263
     Public Class AbitazioneFE
        Public Abitazione As Abitazione
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
            AddHandler cmbTipoDimora.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbTipoAbitazione.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbTipoUtilizzo.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbTipologiaCostruzione.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbAntisismico.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbAlluvionato.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbPianoAssicurato.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbRiparazionediretta.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbDanniBeniAbitazioneFormaGaranzia.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbDanniBeniContenutoFormaGaranzia.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbAssistenzaPlus.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbProvincia.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbComune.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler txtIndirizzo.Leave, AddressOf ValuesChanged
            AddHandler txtIndirizzo.KeyPress, AddressOf TextBoxKeyPress
            AddHandler txtNumeroCivico.Leave, AddressOf ValuesChanged
            AddHandler txtNumeroCivico.KeyPress, AddressOf TextBoxKeyPress

            AddHandler chkDanniBeniBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkDanniBeniAbitazione.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaDanniBeniAbitazione.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaDanniBeniAbitazione.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkDanniBeniContenuto.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaDanniBeniContenuto.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaDanniBeniContenuto.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkDanniBeniGaranziaPlus.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkDanniBeniFenomeniElettrici.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbDanniBeniFenomeniElettricifranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbDanniBeniFenomeniElettricimassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkDanniBeniFenomeniElettriciPannelliSolari.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbDanniBeniFenomeniElettriciPannelliSolarifranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbDanniBeniFenomeniElettriciPannelliSolarimassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkDanniBeniFenomeniAtmosferici.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkDanniBeniDanniDaAcqua.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkDanniBeniRicercaGuasto.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkDanniBeniPerditeOcculte.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkDanniBeniVetriCristalli.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbDanniBeniVetriCristallimassimale.SelectedIndexChanged, AddressOf ValuesChanged

            AddHandler chkCatastrofaliBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkCatastrofaliTerremotoAbitazione.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbCatastrofaliTerremotoAbitazionecombinazione.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkCatastrofaliTerremotoContenuto.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkCatastrofaliAlluvioneAbitazione.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkCatastrofaliAlluvioneContenuto.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbCatastrofaliAlluvioneAbitazionecombinazione.SelectedIndexChanged, AddressOf ValuesChanged

            AddHandler chkAssistenzaPlus.CheckedChanged, AddressOf ValuesChanged

            AddHandler chkProtezioneEmergenza.CheckedChanged, AddressOf ValuesChanged

            AddHandler chkFurtoBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkDanniFurtoContenuto.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaDanniFurtoContenuto.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaDanniFurtoContenuto.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkDanniFurtoGaranziaPlus.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkDanniFurtoValoriNonCustoditi.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaDanniFurtoValoriNonCustoditi.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaDanniFurtoValoriNonCustoditi.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkDanniFurtoValoriCustoditi.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaDanniFurtoValoriCustoditi.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaDanniFurtoValoriCustoditi.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkDanniFurtoSocioPolitico.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkDanniFurtoPannelli.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaDanniFurtoPannelli.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaDanniFurtoPannelli.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkDanniFurtoEsterno.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaDanniFurtoEsterno.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaDanniFurtoEsterno.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkDanniFurtoImpiantoAllarme.CheckedChanged, AddressOf ValuesChanged
        End Sub


        Public Sub New(ByVal decode As P07263DE, helpChm As HelpClass)
            ' Chiamata richiesta da Progettazione Windows Form.
            InitializeComponent()
            AttachCombo(cmbTipoDimora, decode.DecodeTipoDimora)
            AttachCombo(cmbTipoAbitazione, decode.DecodeTipoAbitazione)
            AttachCombo(cmbTipoUtilizzo, decode.DecodeTipoUtilizzo)
            AttachCombo(cmbTipologiaCostruzione, decode.DecodeTipologiaCostruzione)
            AttachCombo(cmbAntisismico, decode.DecodeAntisismico)
            AttachCombo(cmbAlluvionato, decode.DecodeAlluvionato)
            AttachCombo(cmbPianoAssicurato, decode.DecodePianoAssicurato)
            AttachCombo(cmbRiparazionediretta, decode.DecodeRiparazionediretta)
            AttachCombo(cmbDanniBeniAbitazioneFormaGaranzia, decode.DecodeDanniBeniAbitazioneFormaGaranzia)
            AttachCombo(cmbDanniBeniContenutoFormaGaranzia, decode.DecodeDanniBeniContenutoFormaGaranzia)
            AttachCombo(cmbAssistenzaPlus, decode.DecodeAssistenzaPlus)
            AttachCombo(cmbDanniBeniFenomeniElettricifranchigia, decode.DecodeDanniBeniFenomeniElettricifranchigia)
            AttachCombo(cmbDanniBeniFenomeniElettricimassimale, decode.DecodeDanniBeniFenomeniElettricimassimale)
            AttachCombo(cmbDanniBeniFenomeniElettriciPannelliSolarifranchigia, decode.DecodeDanniBeniFenomeniElettriciPannelliSolarifranchigia)
            AttachCombo(cmbDanniBeniFenomeniElettriciPannelliSolarimassimale, decode.DecodeDanniBeniFenomeniElettriciPannelliSolarimassimale)
            AttachCombo(cmbDanniBeniVetriCristallimassimale, decode.DecodeDanniBeniVetriCristallimassimale)
            AttachCombo(cmbCatastrofaliTerremotoAbitazionecombinazione, decode.DecodeCatastrofaliTerremotoAbitazionecombinazione)
            AttachCombo(cmbCatastrofaliAlluvioneAbitazionecombinazione, decode.DecodeAlluvioneGruppoRischio)
            AttachCombo(cmbProvincia, Luogo.Province)
            AttachEvents()

            AgganciaCheckAndLabel({TableLayoutPanel1, TableLayoutPanel2})

            If helpChm.FileExists Then
                AgganciaHelp(Me, AddressOf MouseClickedHelp)
            End If

        End Sub

        Public Sub ControlsToPreventivo(ByVal diretto As Boolean)

            With Abitazione

                If diretto Then
                    .TipoDimora = cmbTipoDimora.SelectedValue
                    .TipoAbitazione = cmbTipoAbitazione.SelectedValue
                    .TipoUtilizzo = cmbTipoUtilizzo.SelectedValue
                    .TipologiaCostruzione = cmbTipologiaCostruzione.SelectedValue
                    .Antisismico = cmbAntisismico.SelectedValue
                    .Alluvionato = cmbAlluvionato.SelectedValue
                    .PianoAssicurato = cmbPianoAssicurato.SelectedValue
                    .Riparazionediretta = cmbRiparazionediretta.SelectedValue
                    .DanniBeniAbitazioneFormaGaranzia = cmbDanniBeniAbitazioneFormaGaranzia.SelectedValue
                    .DanniBeniContenutoFormaGaranzia = cmbDanniBeniContenutoFormaGaranzia.SelectedValue
                    .AssistenzaPlus = cmbAssistenzaPlus.SelectedValue
                    .Provincia = cmbProvincia.SelectedValue
                    .Comune = cmbComune.SelectedValue
                    .Indirizzo = txtIndirizzo.Text
                    .NumeroCivico = txtNumeroCivico.Text

                    'DanniBeni
                    .CoperturaDanniBeni.Stato = EnabledAndChecked(chkDanniBeniBase)
                    .Riparazionediretta = cmbRiparazionediretta.SelectedValue
                    .CoperturaDanniBeniAbitazione.Stato = EnabledAndChecked(chkDanniBeniAbitazione)
                    .PartitaDanniBeniAbitazione.SommaAssicurata = CurrencyBox(txtPartitaDanniBeniAbitazione)
                    .DanniBeniAbitazioneFormaGaranzia = cmbDanniBeniAbitazioneFormaGaranzia.SelectedValue
                    .CoperturaDanniBeniContenuto.Stato = EnabledAndChecked(chkDanniBeniContenuto)
                    .PartitaDanniBeniContenuto.SommaAssicurata = CurrencyBox(txtPartitaDanniBeniContenuto)
                    .DanniBeniContenutoFormaGaranzia = cmbDanniBeniContenutoFormaGaranzia.SelectedValue
                    .CoperturaDanniBeniGaranziaPlus.Stato = EnabledAndChecked(chkDanniBeniGaranziaPlus)
                    .CoperturaDanniBeniFenomeniElettrici.Stato = EnabledAndChecked(chkDanniBeniFenomeniElettrici)
                    .CoperturaDanniBeniFenomeniElettrici.Garanzia.franchigia = cmbDanniBeniFenomeniElettricifranchigia.SelectedValue
                    .CoperturaDanniBeniFenomeniElettrici.Garanzia.massimale = cmbDanniBeniFenomeniElettricimassimale.SelectedValue
                    .CoperturaDanniBeniFenomeniElettriciPannelliSolari.Stato = EnabledAndChecked(chkDanniBeniFenomeniElettriciPannelliSolari)
                    .CoperturaDanniBeniFenomeniElettriciPannelliSolari.Garanzia.franchigia = cmbDanniBeniFenomeniElettriciPannelliSolarifranchigia.SelectedValue
                    .CoperturaDanniBeniFenomeniElettriciPannelliSolari.Garanzia.massimale = cmbDanniBeniFenomeniElettriciPannelliSolarimassimale.SelectedValue
                    .CoperturaDanniBeniFenomeniAtmosferici.Stato = EnabledAndChecked(chkDanniBeniFenomeniAtmosferici)
                    .CoperturaDanniBeniDanniDaAcqua.Stato = EnabledAndChecked(chkDanniBeniDanniDaAcqua)
                    .CoperturaDanniBeniRicercaGuasto.Stato = EnabledAndChecked(chkDanniBeniRicercaGuasto)
                    .CoperturaDanniBeniPerditeOcculte.Stato = EnabledAndChecked(chkDanniBeniPerditeOcculte)
                    .CoperturaDanniBeniVetriCristalli.Stato = EnabledAndChecked(chkDanniBeniVetriCristalli)
                    .CoperturaDanniBeniVetriCristalli.Garanzia.massimale = cmbDanniBeniVetriCristallimassimale.SelectedValue

                    'Catastrofali
                    .CoperturaCatastrofali.Stato = EnabledAndChecked(chkCatastrofaliBase)
                    .CoperturaCatastrofaliTerremotoAbitazione.Stato = EnabledAndChecked(chkCatastrofaliTerremotoAbitazione)
                    .CoperturaCatastrofaliTerremotoAbitazione.Garanzia.combinazione = cmbCatastrofaliTerremotoAbitazionecombinazione.SelectedValue
                    .CoperturaCatastrofaliTerremotoContenuto.Stato = EnabledAndChecked(chkCatastrofaliTerremotoContenuto)
                    .CoperturaCatastrofaliAlluvioneAbitazione.Stato = EnabledAndChecked(chkCatastrofaliAlluvioneAbitazione)
                    .CoperturaCatastrofaliAlluvioneAbitazione.Garanzia.Combinazione = cmbCatastrofaliAlluvioneAbitazionecombinazione.SelectedValue
                    .CoperturaCatastrofaliAlluvioneContenuto.Stato = EnabledAndChecked(chkCatastrofaliAlluvioneContenuto)

                    'AssistenzaPlus
                    .CoperturaAssistenzaPlus.Stato = EnabledAndChecked(chkAssistenzaPlus)
                    .AssistenzaPlus = cmbAssistenzaPlus.SelectedValue

                    'ProtezioneEmergenza
                    .CoperturaProtezioneEmergenza.Stato = EnabledAndChecked(chkProtezioneEmergenza)

                    'Furto
                    .CoperturaFurto.Stato = EnabledAndChecked(chkFurtoBase)
                    .CoperturaDanniFurtoContenuto.Stato = EnabledAndChecked(chkDanniFurtoContenuto)
                    .PartitaDanniFurtoContenuto.SommaAssicurata = CurrencyBox(txtPartitaDanniFurtoContenuto)
                    .CoperturaDanniFurtoGaranziaPlus.Stato = EnabledAndChecked(chkDanniFurtoGaranziaPlus)
                    .CoperturaDanniFurtoValoriNonCustoditi.Stato = EnabledAndChecked(chkDanniFurtoValoriNonCustoditi)
                    .PartitaDanniFurtoValoriNonCustoditi.SommaAssicurata = CurrencyBox(txtPartitaDanniFurtoValoriNonCustoditi)
                    .CoperturaDanniFurtoValoriCustoditi.Stato = EnabledAndChecked(chkDanniFurtoValoriCustoditi)
                    .PartitaDanniFurtoValoriCustoditi.SommaAssicurata = CurrencyBox(txtPartitaDanniFurtoValoriCustoditi)
                    .CoperturaDanniFurtoSocioPolitico.Stato = EnabledAndChecked(chkDanniFurtoSocioPolitico)
                    .CoperturaDanniFurtoPannelli.Stato = EnabledAndChecked(chkDanniFurtoPannelli)
                    .PartitaDanniFurtoPannelli.SommaAssicurata = CurrencyBox(txtPartitaDanniFurtoPannelli)
                    .CoperturaDanniFurtoEsterno.Stato = EnabledAndChecked(chkDanniFurtoEsterno)
                    .PartitaDanniFurtoEsterno.SommaAssicurata = CurrencyBox(txtPartitaDanniFurtoEsterno)
                    .CoperturaDanniFurtoImpiantoAllarme.Stato = EnabledAndChecked(chkDanniFurtoImpiantoAllarme)
                Else
                    cmbTipoDimora.SelectedValue = CInt(.TipoDimora)
                    cmbTipoDimora.Enabled = True
                    cmbTipoAbitazione.SelectedValue = CInt(.TipoAbitazione)
                    cmbTipoAbitazione.Enabled = True
                    cmbTipoUtilizzo.SelectedValue = CInt(.TipoUtilizzo)
                    cmbTipoUtilizzo.Enabled = True
                    cmbTipologiaCostruzione.SelectedValue = CInt(.TipologiaCostruzione)
                    cmbTipologiaCostruzione.Enabled = True
                    cmbAntisismico.SelectedValue = CInt(.Antisismico)
                    cmbAntisismico.Enabled = True
                    cmbAlluvionato.SelectedValue = CInt(.Alluvionato)
                    cmbAlluvionato.Enabled = True
                    cmbPianoAssicurato.SelectedValue = CInt(.PianoAssicurato)
                    cmbPianoAssicurato.Enabled = True
                    cmbRiparazionediretta.SelectedValue = CInt(.Riparazionediretta)
                    cmbRiparazionediretta.Enabled = True
                    cmbDanniBeniAbitazioneFormaGaranzia.SelectedValue = CInt(.DanniBeniAbitazioneFormaGaranzia)
                    cmbDanniBeniAbitazioneFormaGaranzia.Enabled = True
                    cmbDanniBeniContenutoFormaGaranzia.SelectedValue = CInt(.DanniBeniContenutoFormaGaranzia)
                    cmbDanniBeniContenutoFormaGaranzia.Enabled = True
                    cmbAssistenzaPlus.SelectedValue = CInt(.AssistenzaPlus)
                    cmbAssistenzaPlus.Enabled = True
                    cmbProvincia.SelectedValue = .Provincia
                    cmbProvincia.Enabled = True
                    cmbComune.SelectedValue = .Comune
                    cmbComune.Enabled = (.Provincia <> ProvinciaEnum.SiglaXX)
                    txtIndirizzo.Text = .Indirizzo
                    txtIndirizzo.Enabled = True
                    txtNumeroCivico.Text = .NumeroCivico
                    txtNumeroCivico.Enabled = True

                    'DanniBeni
                    EnabledAndChecked(chkDanniBeniBase) = .CoperturaDanniBeni.Stato
                    FormatEuro(lblDanniBeniBase, .CoperturaDanniBeni)
                    cmbRiparazionediretta.Enabled = EnableIfAttivo(.CoperturaDanniBeni.Stato)
                    cmbRiparazionediretta.SelectedValue = CInt(.Riparazionediretta)
                    EnabledAndChecked(chkDanniBeniAbitazione) = .CoperturaDanniBeniAbitazione.Stato
                    CurrencyBox(txtPartitaDanniBeniAbitazione) = .PartitaDanniBeniAbitazione.SommaAssicurata
                    txtPartitaDanniBeniAbitazione.Enabled = Enable(.CoperturaDanniBeniAbitazione.Stato)
                    FormatEuro(lblDanniBeniAbitazione, .CoperturaDanniBeniAbitazione)
                    cmbDanniBeniAbitazioneFormaGaranzia.Enabled = Enable(.CoperturaDanniBeniAbitazione.Stato)
                    cmbDanniBeniAbitazioneFormaGaranzia.SelectedValue = CInt(.DanniBeniAbitazioneFormaGaranzia)
                    EnabledAndChecked(chkDanniBeniContenuto) = .CoperturaDanniBeniContenuto.Stato
                    CurrencyBox(txtPartitaDanniBeniContenuto) = .PartitaDanniBeniContenuto.SommaAssicurata
                    txtPartitaDanniBeniContenuto.Enabled = Enable(.CoperturaDanniBeniContenuto.Stato)
                    FormatEuro(lblDanniBeniContenuto, .CoperturaDanniBeniContenuto)
                    cmbDanniBeniContenutoFormaGaranzia.Enabled = Enable(.CoperturaDanniBeniContenuto.Stato)
                    cmbDanniBeniContenutoFormaGaranzia.SelectedValue = CInt(.DanniBeniContenutoFormaGaranzia)
                    EnabledAndChecked(chkDanniBeniGaranziaPlus) = .CoperturaDanniBeniGaranziaPlus.Stato
                    FormatEuro(lblDanniBeniGaranziaPlus, .CoperturaDanniBeniGaranziaPlus)
                    EnabledAndChecked(chkDanniBeniFenomeniElettrici) = .CoperturaDanniBeniFenomeniElettrici.Stato
                    FormatEuro(lblDanniBeniFenomeniElettrici, .CoperturaDanniBeniFenomeniElettrici)
                    cmbDanniBeniFenomeniElettricifranchigia.Enabled = Enable(.CoperturaDanniBeniFenomeniElettrici.Stato)
                    cmbDanniBeniFenomeniElettricifranchigia.SelectedValue = .CoperturaDanniBeniFenomeniElettrici.Garanzia.franchigia
                    cmbDanniBeniFenomeniElettricimassimale.Enabled = Enable(.CoperturaDanniBeniFenomeniElettrici.Stato)
                    cmbDanniBeniFenomeniElettricimassimale.SelectedValue = .CoperturaDanniBeniFenomeniElettrici.Garanzia.massimale
                    EnabledAndChecked(chkDanniBeniFenomeniElettriciPannelliSolari) = .CoperturaDanniBeniFenomeniElettriciPannelliSolari.Stato
                    FormatEuro(lblDanniBeniFenomeniElettriciPannelliSolari, .CoperturaDanniBeniFenomeniElettriciPannelliSolari)
                    cmbDanniBeniFenomeniElettriciPannelliSolarifranchigia.Enabled = Enable(.CoperturaDanniBeniFenomeniElettriciPannelliSolari.Stato)
                    cmbDanniBeniFenomeniElettriciPannelliSolarifranchigia.SelectedValue = .CoperturaDanniBeniFenomeniElettriciPannelliSolari.Garanzia.franchigia
                    cmbDanniBeniFenomeniElettriciPannelliSolarimassimale.Enabled = Enable(.CoperturaDanniBeniFenomeniElettriciPannelliSolari.Stato)
                    cmbDanniBeniFenomeniElettriciPannelliSolarimassimale.SelectedValue = .CoperturaDanniBeniFenomeniElettriciPannelliSolari.Garanzia.massimale
                    EnabledAndChecked(chkDanniBeniFenomeniAtmosferici) = .CoperturaDanniBeniFenomeniAtmosferici.Stato
                    FormatEuro(lblDanniBeniFenomeniAtmosferici, .CoperturaDanniBeniFenomeniAtmosferici)
                    EnabledAndChecked(chkDanniBeniDanniDaAcqua) = .CoperturaDanniBeniDanniDaAcqua.Stato
                    FormatEuro(lblDanniBeniDanniDaAcqua, .CoperturaDanniBeniDanniDaAcqua)
                    EnabledAndChecked(chkDanniBeniRicercaGuasto) = .CoperturaDanniBeniRicercaGuasto.Stato
                    FormatEuro(lblDanniBeniRicercaGuasto, .CoperturaDanniBeniRicercaGuasto)
                    EnabledAndChecked(chkDanniBeniPerditeOcculte) = .CoperturaDanniBeniPerditeOcculte.Stato
                    FormatEuro(lblDanniBeniPerditeOcculte, .CoperturaDanniBeniPerditeOcculte)
                    EnabledAndChecked(chkDanniBeniVetriCristalli) = .CoperturaDanniBeniVetriCristalli.Stato
                    FormatEuro(lblDanniBeniVetriCristalli, .CoperturaDanniBeniVetriCristalli)
                    cmbDanniBeniVetriCristallimassimale.Enabled = Enable(.CoperturaDanniBeniVetriCristalli.Stato)
                    cmbDanniBeniVetriCristallimassimale.SelectedValue = .CoperturaDanniBeniVetriCristalli.Garanzia.massimale
                    HighlightCheckAndLabel({TableLayoutPanel1, TableLayoutPanel2})

                    'Catastrofali
                    EnabledAndChecked(chkCatastrofaliBase) = .CoperturaCatastrofali.Stato
                    FormatEuro(lblCatastrofaliBase, .CoperturaCatastrofali)
                    EnabledAndChecked(chkCatastrofaliTerremotoAbitazione) = .CoperturaCatastrofaliTerremotoAbitazione.Stato
                    FormatEuro(lblCatastrofaliTerremotoAbitazione, .CoperturaCatastrofaliTerremotoAbitazione)
                    cmbCatastrofaliTerremotoAbitazionecombinazione.Enabled = Enable(.CoperturaCatastrofaliTerremotoAbitazione.Stato)
                    cmbCatastrofaliTerremotoAbitazionecombinazione.SelectedValue = .CoperturaCatastrofaliTerremotoAbitazione.Garanzia.combinazione
                    EnabledAndChecked(chkCatastrofaliTerremotoContenuto) = .CoperturaCatastrofaliTerremotoContenuto.Stato
                    FormatEuro(lblCatastrofaliTerremotoContenuto, .CoperturaCatastrofaliTerremotoContenuto)
                    EnabledAndChecked(chkCatastrofaliAlluvioneAbitazione) = .CoperturaCatastrofaliAlluvioneAbitazione.Stato
                    cmbCatastrofaliAlluvioneAbitazionecombinazione.Enabled = Enable(.CoperturaCatastrofaliAlluvioneAbitazione.Stato)
                    cmbCatastrofaliAlluvioneAbitazionecombinazione.SelectedValue = .CoperturaCatastrofaliAlluvioneAbitazione.Garanzia.Combinazione
                    FormatEuro(lblCatastrofaliAlluvioneAbitazione, .CoperturaCatastrofaliAlluvioneAbitazione)
                    EnabledAndChecked(chkCatastrofaliAlluvioneContenuto) = .CoperturaCatastrofaliAlluvioneContenuto.Stato
                    FormatEuro(lblCatastrofaliAlluvioneContenuto, .CoperturaCatastrofaliAlluvioneContenuto)
                    HighlightCheckAndLabel({TableLayoutPanel1, TableLayoutPanel2})

                    'AssistenzaPlus
                    EnabledAndChecked(chkAssistenzaPlus) = .CoperturaAssistenzaPlus.Stato
                    FormatEuro(lblAssistenzaPlus, .CoperturaAssistenzaPlusBase)
                    cmbAssistenzaPlus.Enabled = EnableIfAttivo(.CoperturaAssistenzaPlus.Stato)
                    cmbAssistenzaPlus.SelectedValue = CInt(.AssistenzaPlus)
                    HighlightCheckAndLabel({TableLayoutPanel1, TableLayoutPanel2})

                    'ProtezioneEmergenza
                    EnabledAndChecked(chkProtezioneEmergenza) = .CoperturaProtezioneEmergenza.Stato
                    FormatEuro(lblProtezioneEmergenza, .CoperturaProtezioneEmergenzaBase)
                    HighlightCheckAndLabel({TableLayoutPanel1, TableLayoutPanel2})

                    'Furto
                    EnabledAndChecked(chkFurtoBase) = .CoperturaFurto.Stato
                    FormatEuro(lblFurtoBase, .CoperturaFurto)
                    EnabledAndChecked(chkDanniFurtoContenuto) = .CoperturaDanniFurtoContenuto.Stato
                    CurrencyBox(txtPartitaDanniFurtoContenuto) = .PartitaDanniFurtoContenuto.SommaAssicurata
                    txtPartitaDanniFurtoContenuto.Enabled = Enable(.CoperturaDanniFurtoContenuto.Stato)
                    FormatEuro(lblDanniFurtoContenuto, .CoperturaDanniFurtoContenuto)
                    EnabledAndChecked(chkDanniFurtoGaranziaPlus) = .CoperturaDanniFurtoGaranziaPlus.Stato
                    FormatEuro(lblDanniFurtoGaranziaPlus, .CoperturaDanniFurtoGaranziaPlus)
                    EnabledAndChecked(chkDanniFurtoValoriNonCustoditi) = .CoperturaDanniFurtoValoriNonCustoditi.Stato
                    CurrencyBox(txtPartitaDanniFurtoValoriNonCustoditi) = .PartitaDanniFurtoValoriNonCustoditi.SommaAssicurata
                    txtPartitaDanniFurtoValoriNonCustoditi.Enabled = Enable(.CoperturaDanniFurtoValoriNonCustoditi.Stato)
                    FormatEuro(lblDanniFurtoValoriNonCustoditi, .CoperturaDanniFurtoValoriNonCustoditi)
                    EnabledAndChecked(chkDanniFurtoValoriCustoditi) = .CoperturaDanniFurtoValoriCustoditi.Stato
                    CurrencyBox(txtPartitaDanniFurtoValoriCustoditi) = .PartitaDanniFurtoValoriCustoditi.SommaAssicurata
                    txtPartitaDanniFurtoValoriCustoditi.Enabled = Enable(.CoperturaDanniFurtoValoriCustoditi.Stato)
                    FormatEuro(lblDanniFurtoValoriCustoditi, .CoperturaDanniFurtoValoriCustoditi)
                    EnabledAndChecked(chkDanniFurtoSocioPolitico) = .CoperturaDanniFurtoSocioPolitico.Stato
                    FormatEuro(lblDanniFurtoSocioPolitico, .CoperturaDanniFurtoSocioPolitico)
                    EnabledAndChecked(chkDanniFurtoPannelli) = .CoperturaDanniFurtoPannelli.Stato
                    CurrencyBox(txtPartitaDanniFurtoPannelli) = .PartitaDanniFurtoPannelli.SommaAssicurata
                    txtPartitaDanniFurtoPannelli.Enabled = Enable(.CoperturaDanniFurtoPannelli.Stato)
                    FormatEuro(lblDanniFurtoPannelli, .CoperturaDanniFurtoPannelli)
                    EnabledAndChecked(chkDanniFurtoEsterno) = .CoperturaDanniFurtoEsterno.Stato
                    CurrencyBox(txtPartitaDanniFurtoEsterno) = .PartitaDanniFurtoEsterno.SommaAssicurata
                    txtPartitaDanniFurtoEsterno.Enabled = Enable(.CoperturaDanniFurtoEsterno.Stato)
                    FormatEuro(lblDanniFurtoEsterno, .CoperturaDanniFurtoEsterno)
                    EnabledAndChecked(chkDanniFurtoImpiantoAllarme) = .CoperturaDanniFurtoImpiantoAllarme.Stato
                    FormatEuro(lblDanniFurtoImpiantoAllarme, .CoperturaDanniFurtoImpiantoAllarme)
                    HighlightCheckAndLabel({TableLayoutPanel1, TableLayoutPanel2})
                End If
            End With
        End Sub
        Private Sub cmbProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProvincia.SelectedIndexChanged
            cmbProvinciaSelectedIndexChanged(cmbProvincia, cmbComune)
        End Sub
    End Class
End Namespace
