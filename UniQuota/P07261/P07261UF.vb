Namespace P07261
     Public Class AbitazioneFE
        Public Abitazione As Abitazione
        Public Event Change(ByVal sender As Object, ByVal e As EventArgs)
        Public Event Remove(ByVal sender As Object, ByVal e As EventArgs)
        Public Event Help(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Public Event ChiaveChanged(ByVal sender As Object, ByVal e As EventArgs)

        Private Sub cmbChiaveChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFurtoChiave.SelectedIndexChanged, cmbIncendioChiave.SelectedIndexChanged, cmbFurtoContenutoFormAss.SelectedIndexChanged
            RaiseEvent ChiaveChanged(sender, e)
        End Sub

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
            AgganciaHelp(Me, AddressOf MouseClickedHelp)
        End Sub

        Protected Sub AttachEvents()
            AddHandler cmdRemove.Click, AddressOf RemoveUnita
            AddHandler cmbTipoAbitazione.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioChiave.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioAbitazioneFormAss.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioContenutoFormAss.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioLocazioneFormAss.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbCaratteristicaCostruttiva.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbFurtoChiave.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbFurtoEsternoScelta.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbFurtoEsternoPlatinoScelta.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbFurtoInCassaforteScelta.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbFurtoPreziosiValoriScelta.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbFurtoValoriDimoraAbitualeDenaro.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbFurtoValoriDimoraAbitualeValori.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbComune.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler txtDescrizione.Leave, AddressOf ValuesChanged
            AddHandler txtDescrizione.KeyPress, AddressOf TextBoxKeyPress
            AddHandler cmbTipoDimora.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbPianoAbitazione.SelectedIndexChanged, AddressOf ValuesChanged

            AddHandler txtIndirizzo.Leave, AddressOf ValuesChanged
            AddHandler txtIndirizzo.KeyPress, AddressOf TextBoxKeyPress
            AddHandler txtNumeroCivico.Leave, AddressOf ValuesChanged
            AddHandler txtNumeroCivico.KeyPress, AddressOf TextBoxKeyPress

            AddHandler chkIncendioBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkIncendioAbitazione.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioAbitazione.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioAbitazione.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkIncendioContenuto.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioContenuto.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioContenuto.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkIncendioLocazione.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioLocazione.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioLocazione.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkIncendioCondutture.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioFenomeniElettrici.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioFenomeniElettrici.KeyPress, AddressOf TextBoxKeyPress
            AddHandler cmbIncendioConduttureFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkIncendioFenomeniElettrici.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioFenomeniElettriciFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkIncendioFenomeniAtmosferici.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioFenomeniAtmosfericiLimite.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioFenomeniAtmosfericiCombinazione.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkIncendioFenomeniAtmosfericiLarge.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioFenomeniAtmosfericiLargeCombinazione.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioFenomeniAtmosfericiLargeMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkIncendioRicorsoTerzi.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioRicorsoTerzi.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioRicorsoTerzi.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkIncendioDemolizione.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioDemolizioneMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkIncendioGelo.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioGeloMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioGeloFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkIncendioRicercaGuasto.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioRicercaGuastoMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioRicercaGuastoFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkIncendioAcquaOcclusione.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioAcquaOcclusioneMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioAcquaOcclusioneFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkIncendioPannelliSolari.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioPannelliSolariMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioPannelliSolariFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkIncendioRiduzioneFranchigiaFenomeniElettrici.CheckedChanged, AddressOf ValuesChanged

            AddHandler chkTerremotoBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkTerremotoFabbricato.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbTerremotoFabbricatoLimite.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkTerremotoContenuto.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbTerremotoContenutoFormAss.SelectedIndexChanged, AddressOf ValuesChanged

            AddHandler chkFurtoBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkFurtoContenuto.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbFurtoContenutoFormAss.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoContenuto.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoContenuto.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkFurtoEsterno.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoEsterno.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoEsterno.KeyPress, AddressOf TextBoxKeyPress
            AddHandler cmbFurtoEsternoLimite.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbFurtoEsternoMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkFurtoEsternoPlatino.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoEsternoPlatino.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoEsternoPlatino.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkFurtoInCassaforte.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoInCassaforte.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoInCassaforte.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkFurtoPreziosiValori.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoPreziosiValori.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoPreziosiValori.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkFurtoValoriDimoraAbituale.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkFurtoValoriDimoraSaltuaria.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkFurtoPannelliSolari.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbFurtoPannelliSolariMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkFurtoMezziChiusura.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkFurtoImpiantoAllarme.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkFurtoFranchigia.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbFurtoFranchigiaFranchigia.SelectedIndexChanged, AddressOf ValuesChanged

            AddHandler chkIncendioEstensioneGaranziaBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkIncendioPannelliSolariEstensioneFenomenoElettrico.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkIncendioPannelliSolariEstensioneFenomenoAtmosferici.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkIncendioPerditeOcculteAcqua.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkFurtoEstensioneGaranziaBase.CheckedChanged, AddressOf ValuesChanged
        End Sub


        Public Sub New(ByVal decode As P07261DE)
            ' Chiamata richiesta da Progettazione Windows Form.
            InitializeComponent()
            AttachCombo(cmbTipoAbitazione, decode.DecodeTipoAbitazione)
            AttachCombo(cmbIncendioChiave, decode.DecodeIncendioChiave)
            AttachCombo(cmbIncendioAbitazioneFormAss, decode.DecodeIncendioAbitazioneFormAss)
            AttachCombo(cmbIncendioContenutoFormAss, decode.DecodeIncendioContenutoFormAss)
            AttachCombo(cmbIncendioLocazioneFormAss, decode.DecodeIncendioLocazioneFormAss)
            AttachCombo(cmbCaratteristicaCostruttiva, decode.DecodeCaratteristicaCostruttiva)
            AttachCombo(cmbFurtoChiave, decode.DecodeFurtoChiave)
            AttachCombo(cmbFurtoContenutoFormAss, decode.DecodeFurtoContenutoFormAss)
            AttachCombo(cmbFurtoEsternoScelta, decode.DecodeFurtoEsternoScelta)
            AttachCombo(cmbFurtoEsternoPlatinoScelta, decode.DecodeFurtoEsternoPlatinoScelta)
            AttachCombo(cmbFurtoInCassaforteScelta, decode.DecodeFurtoInCassaforteScelta)
            AttachCombo(cmbFurtoPreziosiValoriScelta, decode.DecodeFurtoPreziosiValoriScelta)
            AttachCombo(cmbFurtoValoriDimoraAbitualeDenaro, decode.DecodeFurtoValoriDimoraAbitualeDenaro)
            AttachCombo(cmbFurtoValoriDimoraAbitualeValori, decode.DecodeFurtoValoriDimoraAbitualeValori)
            AttachCombo(cmbIncendioConduttureFranchigia, decode.DecodeIncendioConduttureFranchigia)
            AttachCombo(cmbIncendioFenomeniElettriciFranchigia, decode.DecodeIncendioFenomeniElettriciFranchigia)
            AttachCombo(cmbIncendioFenomeniAtmosfericiLimite, decode.DecodeIncendioFenomeniAtmosfericiLimite)
            AttachCombo(cmbIncendioFenomeniAtmosfericiCombinazione, decode.DecodeIncendioFenomeniAtmosfericiCombinazione)
            AttachCombo(cmbIncendioFenomeniAtmosfericiLargeCombinazione, decode.DecodeIncendioFenomeniAtmosfericiLargeCombinazione)
            AttachCombo(cmbIncendioFenomeniAtmosfericiLargeMassimale, decode.DecodeIncendioFenomeniAtmosfericiLargeMassimale)
            AttachCombo(cmbIncendioDemolizioneMassimale, decode.DecodeIncendioDemolizioneMassimale)
            AttachCombo(cmbIncendioGeloMassimale, decode.DecodeIncendioGeloMassimale)
            AttachCombo(cmbIncendioGeloFranchigia, decode.DecodeIncendioGeloFranchigia)
            AttachCombo(cmbIncendioRicercaGuastoMassimale, decode.DecodeIncendioRicercaGuastoMassimale)
            AttachCombo(cmbIncendioRicercaGuastoFranchigia, decode.DecodeIncendioRicercaGuastoFranchigia)
            AttachCombo(cmbIncendioAcquaOcclusioneMassimale, decode.DecodeIncendioAcquaOcclusioneMassimale)
            AttachCombo(cmbIncendioAcquaOcclusioneFranchigia, decode.DecodeIncendioAcquaOcclusioneFranchigia)
            AttachCombo(cmbIncendioPannelliSolariMassimale, decode.DecodeIncendioPannelliSolariMassimale)
            AttachCombo(cmbIncendioPannelliSolariFranchigia, decode.DecodeIncendioPannelliSolariFranchigia)
            AttachCombo(cmbTerremotoFabbricatoLimite, decode.DecodeTerremotoFabbricatoLimite)
            AttachCombo(cmbTerremotoContenutoFormAss, decode.DecodeIncendioContenutoFormAss)
            AttachCombo(cmbFurtoEsternoLimite, decode.DecodeFurtoEsternoLimite)
            AttachCombo(cmbFurtoEsternoMassimale, decode.DecodeFurtoEsternoMassimale)
            AttachCombo(cmbFurtoPannelliSolariMassimale, decode.DecodeFurtoPannelliSolariMassimale)
            AttachCombo(cmbFurtoFranchigiaFranchigia, decode.DecodeFurtoFranchigiaFranchigia)
            AttachCombo(cmbProvincia, Luogo.Province)
            'AttachCombo(cmbComune, Luogo.Comuni)
            AttachCombo(cmbTipoDimora, decode.DecodeTipoDimora)
            AttachCombo(cmbPianoAbitazione, decode.DecodePianoAbitazione)
            AttachEvents()
            AgganciaCheckAndLabel({TableLayoutPanel0, TableLayoutPanel7, TableLayoutPanel8, TableLayoutPanel9})
            TableLayoutPanel7.AutoScroll = True
        End Sub

        Public Sub ControlsToPreventivo(ByVal diretto As Boolean)

            With Abitazione

                If diretto Then
                    .TipoAbitazione = cmbTipoAbitazione.SelectedValue
                    .IncendioAbitazioneFormAss = cmbIncendioAbitazioneFormAss.SelectedValue
                    .IncendioContenutoFormAss = cmbIncendioContenutoFormAss.SelectedValue
                    .IncendioLocazioneFormAss = cmbIncendioLocazioneFormAss.SelectedValue
                    .CaratteristicaCostruttiva = cmbCaratteristicaCostruttiva.SelectedValue
                    .FurtoEsternoScelta = cmbFurtoEsternoScelta.SelectedValue
                    .FurtoEsternoPlatinoScelta = cmbFurtoEsternoPlatinoScelta.SelectedValue
                    .FurtoInCassaforteScelta = cmbFurtoInCassaforteScelta.SelectedValue
                    .FurtoPreziosiValoriScelta = cmbFurtoPreziosiValoriScelta.SelectedValue
                    .FurtoValoriDimoraAbitualeDenaro = cmbFurtoValoriDimoraAbitualeDenaro.SelectedValue
                    .FurtoValoriDimoraAbitualeValori = cmbFurtoValoriDimoraAbitualeValori.SelectedValue
                    .Provincia = cmbProvincia.SelectedValue
                    .Comune = cmbComune.SelectedValue
                    .Descrizione = IIf(txtDescrizione.Text = txtDescrizione.Tag, "", txtDescrizione.Text)
                    .TipoDimora = cmbTipoDimora.SelectedValue
                    .PianoAbitazione = cmbPianoAbitazione.SelectedValue
                    .Indirizzo = txtIndirizzo.Text
                    .NumeroCivico = txtNumeroCivico.Text

                    'Incendio
                    .CoperturaIncendioBase.Stato = EnabledAndChecked(chkIncendioBase)
                    .CoperturaIncendioAbitazione.Stato = EnabledAndChecked(chkIncendioAbitazione)
                    .PartitaIncendioAbitazione.SommaAssicurata = CurrencyBox(txtPartitaIncendioAbitazione)
                    .IncendioAbitazioneFormAss = cmbIncendioAbitazioneFormAss.SelectedValue
                    .CoperturaIncendioContenuto.Stato = EnabledAndChecked(chkIncendioContenuto)
                    .PartitaIncendioContenuto.SommaAssicurata = CurrencyBox(txtPartitaIncendioContenuto)
                    .IncendioContenutoFormAss = cmbIncendioContenutoFormAss.SelectedValue
                    .CoperturaIncendioLocazione.Stato = EnabledAndChecked(chkIncendioLocazione)
                    .PartitaIncendioLocazione.SommaAssicurata = CurrencyBox(txtPartitaIncendioLocazione)
                    .IncendioLocazioneFormAss = cmbIncendioLocazioneFormAss.SelectedValue
                    .CoperturaIncendioCondutture.Stato = EnabledAndChecked(chkIncendioCondutture)
                    .CoperturaIncendioCondutture.Garanzia.Franchigia = cmbIncendioConduttureFranchigia.SelectedValue
                    .PartitaIncendioFenomeniElettrici.SommaAssicurata = CurrencyBox(txtPartitaIncendioFenomeniElettrici)
                    .CoperturaIncendioFenomeniElettrici.Stato = EnabledAndChecked(chkIncendioFenomeniElettrici)
                    .CoperturaIncendioFenomeniElettrici.Garanzia.Franchigia = cmbIncendioFenomeniElettriciFranchigia.SelectedValue
                    .CoperturaIncendioFenomeniAtmosferici.Stato = EnabledAndChecked(chkIncendioFenomeniAtmosferici)
                    .CoperturaIncendioFenomeniAtmosferici.Garanzia.Limite = cmbIncendioFenomeniAtmosfericiLimite.SelectedValue
                    .CoperturaIncendioFenomeniAtmosferici.Garanzia.Combinazione = cmbIncendioFenomeniAtmosfericiCombinazione.SelectedValue
                    .CoperturaIncendioFenomeniAtmosfericiLarge.Stato = EnabledAndChecked(chkIncendioFenomeniAtmosfericiLarge)
                    .CoperturaIncendioFenomeniAtmosfericiLarge.Garanzia.Combinazione = cmbIncendioFenomeniAtmosfericiLargeCombinazione.SelectedValue
                    .CoperturaIncendioFenomeniAtmosfericiLarge.Garanzia.Massimale = cmbIncendioFenomeniAtmosfericiLargeMassimale.SelectedValue
                    .CoperturaIncendioRicorsoTerzi.Stato = EnabledAndChecked(chkIncendioRicorsoTerzi)
                    .PartitaIncendioRicorsoTerzi.SommaAssicurata = CurrencyBox(txtPartitaIncendioRicorsoTerzi)
                    .CoperturaIncendioDemolizione.Stato = EnabledAndChecked(chkIncendioDemolizione)
                    .CoperturaIncendioDemolizione.Garanzia.Massimale = cmbIncendioDemolizioneMassimale.SelectedValue
                    .CoperturaIncendioGelo.Stato = EnabledAndChecked(chkIncendioGelo)
                    .CoperturaIncendioGelo.Garanzia.Massimale = cmbIncendioGeloMassimale.SelectedValue
                    .CoperturaIncendioGelo.Garanzia.Franchigia = cmbIncendioGeloFranchigia.SelectedValue
                    .CoperturaIncendioRicercaGuasto.Stato = EnabledAndChecked(chkIncendioRicercaGuasto)
                    .CoperturaIncendioRicercaGuasto.Garanzia.Massimale = cmbIncendioRicercaGuastoMassimale.SelectedValue
                    .CoperturaIncendioRicercaGuasto.Garanzia.Franchigia = cmbIncendioRicercaGuastoFranchigia.SelectedValue
                    .CoperturaIncendioAcquaOcclusione.Stato = EnabledAndChecked(chkIncendioAcquaOcclusione)
                    .CoperturaIncendioAcquaOcclusione.Garanzia.Massimale = cmbIncendioAcquaOcclusioneMassimale.SelectedValue
                    .CoperturaIncendioAcquaOcclusione.Garanzia.Franchigia = cmbIncendioAcquaOcclusioneFranchigia.SelectedValue
                    .CoperturaIncendioPannelliSolari.Stato = EnabledAndChecked(chkIncendioPannelliSolari)
                    '.PartitaIncendioPannelliSolari.SommaAssicurata = CurrencyBox(txtPartitaIncendioPannelliSolari)
                    .CoperturaIncendioPannelliSolari.Garanzia.Massimale = cmbIncendioPannelliSolariMassimale.SelectedValue
                    .CoperturaIncendioPannelliSolari.Garanzia.Franchigia = cmbIncendioPannelliSolariFranchigia.SelectedValue
                    .CoperturaIncendioRiduzioneFranchigiaFenomeniElettrici.Stato = EnabledAndChecked(chkIncendioRiduzioneFranchigiaFenomeniElettrici)
                    .CoperturaIncendioEstensioneGaranziaBase.Stato = EnabledAndChecked(chkIncendioEstensioneGaranziaBase)
                    .CoperturaIncendioPannelliSolariEstensioneFenomenoElettrico.Stato = EnabledAndChecked(chkIncendioPannelliSolariEstensioneFenomenoElettrico)
                    .CoperturaIncendioPannelliSolariEstensioneFenomenoAtmosferici.Stato = EnabledAndChecked(chkIncendioPannelliSolariEstensioneFenomenoAtmosferici)
                    .CoperturaIncendioPerditeOcculteAcqua.Stato = EnabledAndChecked(chkIncendioPerditeOcculteAcqua)

                    'Terremoto
                    .CoperturaTerremotoBase.Stato = EnabledAndChecked(chkTerremotoBase)
                    .CoperturaTerremotoFabbricato.Stato = EnabledAndChecked(chkTerremotoFabbricato)
                    .CoperturaTerremotoFabbricato.Garanzia.Limite = cmbTerremotoFabbricatoLimite.SelectedValue
                    .CaratteristicaCostruttiva = cmbCaratteristicaCostruttiva.SelectedValue
                    .CoperturaTerremotoContenuto.Stato = EnabledAndChecked(chkTerremotoContenuto)
                    .TerremotoContenutoFormAss = cmbTerremotoContenutoFormAss.SelectedValue

                    'Furto
                    .CoperturaFurtoBase.Stato = EnabledAndChecked(chkFurtoBase)
                    .CoperturaFurtoContenuto.Stato = EnabledAndChecked(chkFurtoContenuto)
                    .FurtoContenutoFormaAssicurazione = cmbFurtoContenutoFormAss.SelectedValue
                    .PartitaFurtoContenuto.SommaAssicurata = CurrencyBox(txtPartitaFurtoContenuto)
                    .CoperturaFurtoEsternoOro.Stato = EnabledAndChecked(chkFurtoEsterno)
                    .PartitaFurtoEsterno.SommaAssicurata = CurrencyBox(txtPartitaFurtoEsterno)
                    .CoperturaFurtoEsternoOro.Garanzia.Limite = cmbFurtoEsternoLimite.SelectedValue
                    .CoperturaFurtoEsternoOro.Garanzia.Massimale = cmbFurtoEsternoMassimale.SelectedValue
                    .FurtoEsternoScelta = cmbFurtoEsternoScelta.SelectedValue
                    .CoperturaFurtoEsternoPlatino.Stato = EnabledAndChecked(chkFurtoEsternoPlatino)
                    .PartitaFurtoEsternoPlatino.SommaAssicurata = CurrencyBox(txtPartitaFurtoEsternoPlatino)
                    .FurtoEsternoPlatinoScelta = cmbFurtoEsternoPlatinoScelta.SelectedValue
                    .CoperturaFurtoInCassaforte.Stato = EnabledAndChecked(chkFurtoInCassaforte)
                    .PartitaFurtoInCassaforte.SommaAssicurata = CurrencyBox(txtPartitaFurtoInCassaforte)
                    .FurtoInCassaforteScelta = cmbFurtoInCassaforteScelta.SelectedValue
                    .CoperturaFurtoPreziosiValori.Stato = EnabledAndChecked(chkFurtoPreziosiValori)
                    .PartitaFurtoPreziosiValori.SommaAssicurata = CurrencyBox(txtPartitaFurtoPreziosiValori)
                    .FurtoPreziosiValoriScelta = cmbFurtoPreziosiValoriScelta.SelectedValue
                    .CoperturaFurtoValoriDimoraAbituale.Stato = EnabledAndChecked(chkFurtoValoriDimoraAbituale)
                    .FurtoValoriDimoraAbitualeDenaro = cmbFurtoValoriDimoraAbitualeDenaro.SelectedValue
                    .FurtoValoriDimoraAbitualeValori = cmbFurtoValoriDimoraAbitualeValori.SelectedValue
                    .CoperturaFurtoValoriDimoraSaltuaria.Stato = EnabledAndChecked(chkFurtoValoriDimoraSaltuaria)
                    .CoperturaFurtoPannelliSolari.Stato = EnabledAndChecked(chkFurtoPannelliSolari)
                    .CoperturaFurtoPannelliSolari.Garanzia.Massimale = cmbFurtoPannelliSolariMassimale.SelectedValue
                    .CoperturaFurtoMezziChiusura.Stato = EnabledAndChecked(chkFurtoMezziChiusura)
                    .CoperturaFurtoImpiantoAllarme.Stato = EnabledAndChecked(chkFurtoImpiantoAllarme)
                    .CoperturaFurtoFranchigia.Stato = EnabledAndChecked(chkFurtoFranchigia)
                    .CoperturaFurtoFranchigia.Garanzia.Franchigia = cmbFurtoFranchigiaFranchigia.SelectedValue
                    .CoperturaFurtoEstensioneGaranziaBase.Stato = EnabledAndChecked(chkFurtoEstensioneGaranziaBase)
                Else
                    cmbTipoAbitazione.SelectedValue = CInt(.TipoAbitazione)
                    cmbTipoAbitazione.Enabled = (.Comune <> 0)
                    cmbIncendioChiave.SelectedValue = CInt(.IncendioChiave)
                    cmbIncendioChiave.Enabled = True
                    cmbIncendioAbitazioneFormAss.SelectedValue = CInt(.IncendioAbitazioneFormAss)
                    cmbIncendioAbitazioneFormAss.Enabled = True
                    cmbIncendioContenutoFormAss.SelectedValue = CInt(.IncendioContenutoFormAss)
                    cmbIncendioContenutoFormAss.Enabled = True
                    cmbIncendioLocazioneFormAss.SelectedValue = CInt(.IncendioLocazioneFormAss)
                    cmbIncendioLocazioneFormAss.Enabled = True
                    cmbCaratteristicaCostruttiva.SelectedValue = CInt(.CaratteristicaCostruttiva)
                    cmbCaratteristicaCostruttiva.Enabled = True
                    cmbFurtoChiave.SelectedValue = CInt(.FurtoChiave)
                    cmbFurtoChiave.Enabled = True
                    cmbFurtoContenutoFormAss.SelectedValue = CInt(.FurtoContenutoFormaAssicurazione)
                    cmbFurtoContenutoFormAss.Enabled = True
                    cmbFurtoEsternoScelta.SelectedValue = CInt(.FurtoEsternoScelta)
                    cmbFurtoEsternoScelta.Enabled = True
                    cmbFurtoEsternoPlatinoScelta.SelectedValue = CInt(.FurtoEsternoPlatinoScelta)
                    cmbFurtoEsternoPlatinoScelta.Enabled = True
                    cmbFurtoInCassaforteScelta.SelectedValue = CInt(.FurtoInCassaforteScelta)
                    cmbFurtoInCassaforteScelta.Enabled = True
                    cmbFurtoPreziosiValoriScelta.SelectedValue = CInt(.FurtoPreziosiValoriScelta)
                    cmbFurtoPreziosiValoriScelta.Enabled = True
                    cmbFurtoValoriDimoraAbitualeDenaro.SelectedValue = CInt(.FurtoValoriDimoraAbitualeDenaro)
                    cmbFurtoValoriDimoraAbitualeDenaro.Enabled = True
                    cmbFurtoValoriDimoraAbitualeValori.SelectedValue = CInt(.FurtoValoriDimoraAbitualeValori)
                    cmbFurtoValoriDimoraAbitualeValori.Enabled = True
                    cmbProvincia.SelectedValue = .Provincia
                    cmbProvincia.Enabled = True
                    cmbComune.SelectedValue = .Comune
                    cmbComune.Enabled = (.Provincia <> ProvinciaEnum.SiglaXX)
                    txtDescrizione.Text = IIf(.Descrizione <> "", .Descrizione, txtDescrizione.Tag)
                    txtDescrizione.Enabled = (.Provincia <> ProvinciaEnum.SiglaXX)
                    cmbTipoDimora.SelectedValue = CInt(.TipoDimora)
                    cmbTipoDimora.Enabled = (.TipoAbitazione <> TipoAbitazioneEnum.NonSelected)
                    cmbPianoAbitazione.SelectedValue = CInt(.PianoAbitazione)
                    cmbPianoAbitazione.Enabled = (.TipoDimora <> TipoDimoraEnum.NonSelected)

                    txtIndirizzo.Text = .Indirizzo
                    txtIndirizzo.Enabled = (.Comune > 0)
                    txtNumeroCivico.Text = .NumeroCivico
                    txtNumeroCivico.Enabled = (.Comune > 0)

                    'Incendio
                    EnabledAndChecked(chkIncendioBase) = .CoperturaIncendioBase.Stato
                    cmbIncendioChiave.Enabled = .CoperturaIncendioBase.IsAttivo
                    cmbIncendioChiave.SelectedValue = CInt(.IncendioChiave)
                    EnabledAndChecked(chkIncendioAbitazione) = .CoperturaIncendioAbitazione.Stato
                    CurrencyBox(txtPartitaIncendioAbitazione) = .PartitaIncendioAbitazione.SommaAssicurata
                    txtPartitaIncendioAbitazione.Enabled = Enable(.CoperturaIncendioAbitazione.Stato)
                    FormatEuro(lblIncendioAbitazione, .CoperturaIncendioAbitazione)
                    cmbIncendioAbitazioneFormAss.Enabled = Enable(.CoperturaIncendioAbitazione.Stato)
                    cmbIncendioAbitazioneFormAss.SelectedValue = CInt(.IncendioAbitazioneFormAss)
                    EnabledAndChecked(chkIncendioContenuto) = .CoperturaIncendioContenuto.Stato
                    CurrencyBox(txtPartitaIncendioContenuto) = .PartitaIncendioContenuto.SommaAssicurata
                    txtPartitaIncendioContenuto.Enabled = Enable(.CoperturaIncendioContenuto.Stato)
                    FormatEuro(lblIncendioContenuto, .CoperturaIncendioContenuto)
                    cmbIncendioContenutoFormAss.Enabled = Enable(.CoperturaIncendioContenuto.Stato)
                    cmbIncendioContenutoFormAss.SelectedValue = CInt(.IncendioContenutoFormAss)
                    EnabledAndChecked(chkIncendioLocazione) = .CoperturaIncendioLocazione.Stato
                    CurrencyBox(txtPartitaIncendioLocazione) = .PartitaIncendioLocazione.SommaAssicurata
                    txtPartitaIncendioLocazione.Enabled = Enable(.CoperturaIncendioLocazione.Stato)
                    FormatEuro(lblIncendioLocazione, .CoperturaIncendioLocazione)
                    cmbIncendioLocazioneFormAss.Enabled = Enable(.CoperturaIncendioLocazione.Stato)
                    cmbIncendioLocazioneFormAss.SelectedValue = CInt(.IncendioLocazioneFormAss)
                    EnabledAndChecked(chkIncendioCondutture) = .CoperturaIncendioCondutture.Stato
                    FormatEuro(lblIncendioCondutture, .CoperturaIncendioCondutture)
                    cmbIncendioConduttureFranchigia.Enabled = Enable(.CoperturaIncendioCondutture.Stato) And .IncendioChiave <> IncendioChiaveEnum.ChiaveARGENTO
                    cmbIncendioConduttureFranchigia.SelectedValue = .CoperturaIncendioCondutture.Garanzia.Franchigia
                    EnabledAndChecked(chkIncendioFenomeniElettrici) = .CoperturaIncendioFenomeniElettrici.Stato
                    FormatEuro(lblIncendioFenomeniElettrici, .CoperturaIncendioFenomeniElettrici)
                    CurrencyBox(txtPartitaIncendioFenomeniElettrici) = .PartitaIncendioFenomeniElettrici.SommaAssicurata
                    txtPartitaIncendioFenomeniElettrici.Enabled = Enable(.CoperturaIncendioCondutture.Stato) And .IncendioChiave = IncendioChiaveEnum.ChiaveORO
                    cmbIncendioFenomeniElettriciFranchigia.Enabled = Enable(.CoperturaIncendioFenomeniElettrici.Stato) And .IncendioChiave = IncendioChiaveEnum.ChiaveORO
                    cmbIncendioFenomeniElettriciFranchigia.SelectedValue = .CoperturaIncendioFenomeniElettrici.Garanzia.Franchigia
                    EnabledAndChecked(chkIncendioFenomeniAtmosferici) = .CoperturaIncendioFenomeniAtmosferici.Stato
                    FormatEuro(lblIncendioFenomeniAtmosferici, .CoperturaIncendioFenomeniAtmosferici)
                    cmbIncendioFenomeniAtmosfericiLimite.Enabled = Enable(.CoperturaIncendioFenomeniAtmosferici.Stato)
                    cmbIncendioFenomeniAtmosfericiLimite.SelectedValue = .CoperturaIncendioFenomeniAtmosferici.Garanzia.Limite
                    cmbIncendioFenomeniAtmosfericiCombinazione.Enabled = Enable(.CoperturaIncendioFenomeniAtmosferici.Stato)
                    cmbIncendioFenomeniAtmosfericiCombinazione.SelectedValue = .CoperturaIncendioFenomeniAtmosferici.Garanzia.Combinazione
                    EnabledAndChecked(chkIncendioFenomeniAtmosfericiLarge) = .CoperturaIncendioFenomeniAtmosfericiLarge.Stato
                    FormatEuro(lblIncendioFenomeniAtmosfericiLarge, .CoperturaIncendioFenomeniAtmosfericiLarge)
                    cmbIncendioFenomeniAtmosfericiLargeCombinazione.Enabled = Enable(.CoperturaIncendioFenomeniAtmosfericiLarge.Stato)
                    cmbIncendioFenomeniAtmosfericiLargeCombinazione.SelectedValue = .CoperturaIncendioFenomeniAtmosfericiLarge.Garanzia.Combinazione
                    cmbIncendioFenomeniAtmosfericiLargeMassimale.Enabled = Enable(.CoperturaIncendioFenomeniAtmosfericiLarge.Stato)
                    cmbIncendioFenomeniAtmosfericiLargeMassimale.SelectedValue = .CoperturaIncendioFenomeniAtmosfericiLarge.Garanzia.Massimale
                    EnabledAndChecked(chkIncendioRicorsoTerzi) = .CoperturaIncendioRicorsoTerzi.Stato
                    CurrencyBox(txtPartitaIncendioRicorsoTerzi) = .PartitaIncendioRicorsoTerzi.SommaAssicurata
                    txtPartitaIncendioRicorsoTerzi.Enabled = Enable(.CoperturaIncendioRicorsoTerzi.Stato)
                    FormatEuro(lblIncendioRicorsoTerzi, .CoperturaIncendioRicorsoTerzi)
                    EnabledAndChecked(chkIncendioDemolizione) = .CoperturaIncendioDemolizione.Stato
                    FormatEuro(lblIncendioDemolizione, .CoperturaIncendioDemolizione)
                    cmbIncendioDemolizioneMassimale.Enabled = Enable(.CoperturaIncendioDemolizione.Stato)
                    cmbIncendioDemolizioneMassimale.SelectedValue = .CoperturaIncendioDemolizione.Garanzia.Massimale
                    EnabledAndChecked(chkIncendioGelo) = .CoperturaIncendioGelo.Stato
                    FormatEuro(lblIncendioGelo, .CoperturaIncendioGelo)
                    cmbIncendioGeloMassimale.Enabled = Enable(.CoperturaIncendioGelo.Stato)
                    cmbIncendioGeloMassimale.SelectedValue = .CoperturaIncendioGelo.Garanzia.Massimale
                    cmbIncendioGeloFranchigia.Enabled = Enable(.CoperturaIncendioGelo.Stato)
                    cmbIncendioGeloFranchigia.SelectedValue = .CoperturaIncendioGelo.Garanzia.Franchigia
                    EnabledAndChecked(chkIncendioRicercaGuasto) = .CoperturaIncendioRicercaGuasto.Stato
                    FormatEuro(lblIncendioRicercaGuasto, .CoperturaIncendioRicercaGuasto)
                    cmbIncendioRicercaGuastoMassimale.Enabled = Enable(.CoperturaIncendioRicercaGuasto.Stato)
                    cmbIncendioRicercaGuastoMassimale.SelectedValue = .CoperturaIncendioRicercaGuasto.Garanzia.Massimale
                    cmbIncendioRicercaGuastoFranchigia.Enabled = Enable(.CoperturaIncendioRicercaGuasto.Stato)
                    cmbIncendioRicercaGuastoFranchigia.SelectedValue = .CoperturaIncendioRicercaGuasto.Garanzia.Franchigia
                    EnabledAndChecked(chkIncendioAcquaOcclusione) = .CoperturaIncendioAcquaOcclusione.Stato
                    FormatEuro(lblIncendioAcquaOcclusione, .CoperturaIncendioAcquaOcclusione)
                    cmbIncendioAcquaOcclusioneMassimale.Enabled = Enable(.CoperturaIncendioAcquaOcclusione.Stato)
                    cmbIncendioAcquaOcclusioneMassimale.SelectedValue = .CoperturaIncendioAcquaOcclusione.Garanzia.Massimale
                    cmbIncendioAcquaOcclusioneFranchigia.Enabled = Enable(.CoperturaIncendioAcquaOcclusione.Stato)
                    cmbIncendioAcquaOcclusioneFranchigia.SelectedValue = .CoperturaIncendioAcquaOcclusione.Garanzia.Franchigia
                    EnabledAndChecked(chkIncendioPannelliSolari) = .CoperturaIncendioPannelliSolari.Stato
                    FormatEuro(lblIncendioPannelliSolari, .CoperturaIncendioPannelliSolari)
                    cmbIncendioPannelliSolariMassimale.Enabled = Enable(.CoperturaIncendioPannelliSolari.Stato)
                    cmbIncendioPannelliSolariMassimale.SelectedValue = .CoperturaIncendioPannelliSolari.Garanzia.Massimale
                    cmbIncendioPannelliSolariFranchigia.Enabled = Enable(.CoperturaIncendioPannelliSolari.Stato)
                    cmbIncendioPannelliSolariFranchigia.SelectedValue = .CoperturaIncendioPannelliSolari.Garanzia.Franchigia
                    EnabledAndChecked(chkIncendioRiduzioneFranchigiaFenomeniElettrici) = .CoperturaIncendioRiduzioneFranchigiaFenomeniElettrici.Stato
                    FormatEuro(lblIncendioRiduzioneFranchigiaFenomeniElettrici, .CoperturaIncendioRiduzioneFranchigiaFenomeniElettrici)
                    FormatEuro(lblIncendioPremio, .CoperturaIncendio)
                    EnabledAndChecked(chkIncendioEstensioneGaranziaBase) = .CoperturaIncendioEstensioneGaranziaBase.Stato
                    FormatEuro(lblIncendioEstensioneGaranziaBase, .CoperturaIncendioEstensioneGaranziaBase)
                    EnabledAndChecked(chkIncendioPannelliSolariEstensioneFenomenoElettrico) = .CoperturaIncendioPannelliSolariEstensioneFenomenoElettrico.Stato
                    FormatEuro(lblIncendioPannelliSolariEstensioneFenomenoElettrico, .CoperturaIncendioPannelliSolariEstensioneFenomenoElettrico)
                    EnabledAndChecked(chkIncendioPannelliSolariEstensioneFenomenoAtmosferici) = .CoperturaIncendioPannelliSolariEstensioneFenomenoAtmosferici.Stato
                    FormatEuro(lblIncendioPannelliSolariEstensioneFenomenoAtmosferici, .CoperturaIncendioPannelliSolariEstensioneFenomenoAtmosferici)
                    EnabledAndChecked(chkIncendioPerditeOcculteAcqua) = .CoperturaIncendioPerditeOcculteAcqua.Stato
                    FormatEuro(lblIncendioPerditeOcculteAcqua, .CoperturaIncendioPerditeOcculteAcqua)

                    'Terremoto
                    EnabledAndChecked(chkTerremotoBase) = .CoperturaTerremotoBase.Stato
                    EnabledAndChecked(chkTerremotoFabbricato) = .CoperturaTerremotoFabbricato.Stato
                    FormatEuro(lblTerremotoFabbricato, .CoperturaTerremotoFabbricato)
                    cmbTerremotoFabbricatoLimite.Enabled = Enable(.CoperturaTerremotoFabbricato.Stato)
                    cmbTerremotoFabbricatoLimite.SelectedValue = .CoperturaTerremotoFabbricato.Garanzia.Limite
                    'cmbCaratteristicaCostruttiva.Enabled = Enable(.CoperturaTerremotoFabbricato.Stato)
                    cmbCaratteristicaCostruttiva.Enabled = (.PianoAbitazione <> PianoAbitazioneEnum.NonSelected)
                    cmbCaratteristicaCostruttiva.SelectedValue = CInt(.CaratteristicaCostruttiva)
                    EnabledAndChecked(chkTerremotoContenuto) = .CoperturaTerremotoContenuto.Stato
                    FormatEuro(lblTerremotoContenuto, .CoperturaTerremotoContenuto)
                    FormatEuro(lblTerremotoPremio, .CoperturaTerremoto)
                    cmbTerremotoContenutoFormAss.Enabled = False 'Enable(.CoperturaTerremotoContenuto.Stato)
                    cmbTerremotoContenutoFormAss.SelectedValue = CInt(.TerremotoContenutoFormAss)

                    'Furto
                    EnabledAndChecked(chkFurtoBase) = .CoperturaFurtoBase.Stato
                    cmbFurtoChiave.Enabled = .CoperturaFurtoBase.IsAttivo
                    cmbFurtoChiave.SelectedValue = CInt(.FurtoChiave)
                    cmbFurtoContenutoFormAss.Enabled = Enable(.CoperturaFurtoContenuto.Stato)
                    cmbFurtoContenutoFormAss.SelectedValue = CInt(.FurtoContenutoFormaAssicurazione)
                    EnabledAndChecked(chkFurtoContenuto) = .CoperturaFurtoContenuto.Stato
                    CurrencyBox(txtPartitaFurtoContenuto) = .PartitaFurtoContenuto.SommaAssicurata
                    txtPartitaFurtoContenuto.Enabled = Enable(.CoperturaFurtoContenuto.Stato)
                    FormatEuro(lblFurtoContenuto, .CoperturaFurtoContenuto)
                    EnabledAndChecked(chkFurtoEsterno) = .CoperturaFurtoEsternoOro.Stato
                    CurrencyBox(txtPartitaFurtoEsterno) = .PartitaFurtoEsterno.SommaAssicurata
                    txtPartitaFurtoEsterno.Enabled = Enable(.CoperturaFurtoEsternoOro.Stato)
                    FormatEuro(lblFurtoEsterno, .CoperturaFurtoEsternoOro)
                    cmbFurtoEsternoLimite.Enabled = Enable(.CoperturaFurtoEsternoOro.Stato) And .FurtoEsternoScelta = FurtoEsternoSceltaEnum.SceltaLARGE
                    cmbFurtoEsternoLimite.SelectedValue = .CoperturaFurtoEsternoOro.Garanzia.Limite
                    cmbFurtoEsternoMassimale.Enabled = Enable(.CoperturaFurtoEsternoOro.Stato) And .FurtoEsternoScelta = FurtoEsternoSceltaEnum.SceltaLARGE
                    cmbFurtoEsternoMassimale.SelectedValue = .CoperturaFurtoEsternoOro.Garanzia.Massimale
                    cmbFurtoEsternoScelta.Enabled = Enable(.CoperturaFurtoEsternoOro.Stato)
                    cmbFurtoEsternoScelta.SelectedValue = CInt(.FurtoEsternoScelta)
                    EnabledAndChecked(chkFurtoEsternoPlatino) = .CoperturaFurtoEsternoPlatino.Stato
                    CurrencyBox(txtPartitaFurtoEsternoPlatino) = .PartitaFurtoEsternoPlatino.SommaAssicurata
                    txtPartitaFurtoEsternoPlatino.Enabled = Enable(.CoperturaFurtoEsternoPlatino.Stato)
                    FormatEuro(lblFurtoEsternoPlatino, .CoperturaFurtoEsternoPlatino)
                    cmbFurtoEsternoPlatinoScelta.Enabled = Enable(.CoperturaFurtoEsternoPlatino.Stato)
                    cmbFurtoEsternoPlatinoScelta.SelectedValue = CInt(.FurtoEsternoPlatinoScelta)
                    EnabledAndChecked(chkFurtoInCassaforte) = .CoperturaFurtoInCassaforte.Stato
                    CurrencyBox(txtPartitaFurtoInCassaforte) = .PartitaFurtoInCassaforte.SommaAssicurata
                    txtPartitaFurtoInCassaforte.Enabled = Enable(.CoperturaFurtoInCassaforte.Stato)
                    FormatEuro(lblFurtoInCassaforte, .CoperturaFurtoInCassaforte)
                    cmbFurtoInCassaforteScelta.Enabled = Enable(.CoperturaFurtoInCassaforte.Stato) And .FurtoChiave = FurtoChiaveEnum.ChiavePLATINO
                    cmbFurtoInCassaforteScelta.SelectedValue = CInt(.FurtoInCassaforteScelta)
                    EnabledAndChecked(chkFurtoPreziosiValori) = .CoperturaFurtoPreziosiValori.Stato
                    CurrencyBox(txtPartitaFurtoPreziosiValori) = .PartitaFurtoPreziosiValori.SommaAssicurata
                    txtPartitaFurtoPreziosiValori.Enabled = Enable(.CoperturaFurtoPreziosiValori.Stato)
                    FormatEuro(lblFurtoPreziosiValori, .CoperturaFurtoPreziosiValori)
                    cmbFurtoPreziosiValoriScelta.Enabled = Enable(.CoperturaFurtoPreziosiValori.Stato) And .FurtoChiave = FurtoChiaveEnum.ChiavePLATINO
                    cmbFurtoPreziosiValoriScelta.SelectedValue = CInt(.FurtoPreziosiValoriScelta)
                    EnabledAndChecked(chkFurtoValoriDimoraAbituale) = .CoperturaFurtoValoriDimoraAbituale.Stato
                    FormatEuro(lblFurtoValoriDimoraAbituale, .CoperturaFurtoValoriDimoraAbituale)
                    cmbFurtoValoriDimoraAbitualeDenaro.Enabled = Enable(.CoperturaFurtoValoriDimoraAbituale.Stato)
                    cmbFurtoValoriDimoraAbitualeDenaro.SelectedValue = CInt(.FurtoValoriDimoraAbitualeDenaro)
                    cmbFurtoValoriDimoraAbitualeValori.Enabled = Enable(.CoperturaFurtoValoriDimoraAbituale.Stato)
                    cmbFurtoValoriDimoraAbitualeValori.SelectedValue = CInt(.FurtoValoriDimoraAbitualeValori)
                    EnabledAndChecked(chkFurtoValoriDimoraSaltuaria) = .CoperturaFurtoValoriDimoraSaltuaria.Stato
                    FormatEuro(lblFurtoValoriDimoraSaltuaria, .CoperturaFurtoValoriDimoraSaltuaria)
                    EnabledAndChecked(chkFurtoPannelliSolari) = .CoperturaFurtoPannelliSolari.Stato
                    FormatEuro(lblFurtoPannelliSolari, .CoperturaFurtoPannelliSolari)
                    cmbFurtoPannelliSolariMassimale.Enabled = Enable(.CoperturaFurtoPannelliSolari.Stato)
                    cmbFurtoPannelliSolariMassimale.SelectedValue = .CoperturaFurtoPannelliSolari.Garanzia.Massimale
                    EnabledAndChecked(chkFurtoMezziChiusura) = .CoperturaFurtoMezziChiusura.Stato
                    FormatEuro(lblFurtoMezziChiusura, .CoperturaFurtoMezziChiusura)
                    EnabledAndChecked(chkFurtoImpiantoAllarme) = .CoperturaFurtoImpiantoAllarme.Stato
                    FormatEuro(lblFurtoImpiantoAllarme, .CoperturaFurtoImpiantoAllarme)
                    EnabledAndChecked(chkFurtoFranchigia) = .CoperturaFurtoFranchigia.Stato
                    FormatEuro(lblFurtoFranchigia, .CoperturaFurtoFranchigia)
                    cmbFurtoFranchigiaFranchigia.Enabled = Enable(.CoperturaFurtoFranchigia.Stato)
                    cmbFurtoFranchigiaFranchigia.SelectedValue = .CoperturaFurtoFranchigia.Garanzia.Franchigia
                    FormatEuro(lblFurtoPremio, .CoperturaFurto)
                    EnabledAndChecked(chkFurtoEstensioneGaranziaBase) = .CoperturaFurtoEstensioneGaranziaBase.Stato
                    FormatEuro(lblFurtoEstensioneGaranziaBase, .CoperturaFurtoEstensioneGaranziaBase)

                    HighlightCheckAndLabel({TableLayoutPanel0, TableLayoutPanel7, TableLayoutPanel8, TableLayoutPanel9})
                End If
            End With
        End Sub

        Private Sub cmbProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProvincia.SelectedIndexChanged
            cmbProvinciaSelectedIndexChanged(cmbProvincia, cmbComune)
        End Sub
    End Class
End Namespace
