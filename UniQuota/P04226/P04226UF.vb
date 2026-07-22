Namespace P04226
    Public Class FabbricatoFE
        Public Fabbricato As Fabbricato
        Public Event Change(ByVal sender As Object, ByVal e As EventArgs)
        Public Event Remove(ByVal sender As Object, ByVal e As EventArgs)
        Public Event Help(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)

        Protected Sub AttachEvents()
            AddHandler Note.NoteChanged, AddressOf ValuesChanged
            AddHandler txtDescrizione.Leave, AddressOf ValuesChanged
            AddHandler txtDescrizione.KeyPress, AddressOf TextBoxKeyPress
            AddHandler cmdRemove.Click, AddressOf RemoveAbitazione

            AddHandler cmbFabbricatoDestinazione.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbFabbricatoClasse.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioScelta.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioEventiAtmosfericiScelta.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioDanniElettriciScelta.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioDanniIndirettiScelta.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbFurtoFissiScelta.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbFurtoValoriScelta.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbFurtoRapinaScelta.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbComune.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler txtIncendioAumentoMerciMesi.Leave, AddressOf ValuesChanged
            AddHandler txtIncendioAumentoMerciMesi.KeyPress, AddressOf TextBoxKeyPress
            AddHandler txtFurtoAumentoMerciMesi.Leave, AddressOf ValuesChanged
            AddHandler txtFurtoAumentoMerciMesi.KeyPress, AddressOf TextBoxKeyPress

            AddHandler chkIncendioBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkIncendioFabbricato.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioFabbricato.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioFabbricato.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkIncendioContenuto.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioContenuto.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioContenuto.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkIncendioLocazione.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioLocazione.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioLocazione.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkIncendioCondutture.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioConduttureMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkIncendioDemolizione.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioDemolizioneMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkIncendioEventiAtmosferici.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkIncendioDanniElettrici.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioDanniElettrici.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioDanniElettrici.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkIncendioDanniIndirettiA.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioDanniIndirettiA.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioDanniIndirettiA.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkIncendioDanniIndirettiB.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioDanniIndirettiB.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioDanniIndirettiB.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkIncendioRicorsoTerzi.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioRicorsoTerzi.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioRicorsoTerzi.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkIncendioAumentoMerci.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioAumentoMerci.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioAumentoMerci.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkIncendioCoseTrasportate.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioCoseTrasportate.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioCoseTrasportate.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkIncendioRefrigerati1.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioRefrigerati1.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioRefrigerati1.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkIncendioRefrigerati2.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioRefrigerati2.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioRefrigerati2.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkIncendioLastre.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioLastre.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioLastre.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkIncendioPannelliSolari.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioPannelliSolari.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioPannelliSolari.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkIncendioRicetteMediche.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioRicetteMediche.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaIncendioRicetteMediche.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkIncendioSpeseAccessorie.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkIncendioGrandineFragili.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkIncendioAttiVandaliciDolosi.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkIncendioFabbricatiAperti1.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkIncendioFabbricatiAperti2.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkIncendioPreziosi.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkIncendioSistemiProtezione.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkIncendioCommercioAmbulante.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkIncendioFranchigia.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioFranchigiaFranchigia.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioFormaFabbricato.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioFormaContenuto.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbIncendioFormaLocazione.SelectedIndexChanged, AddressOf ValuesChanged

            AddHandler chkFurtoBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkFurtoContenuto.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoContenuto.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoContenuto.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkFurtoFissi.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoFissi.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoFissi.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkFurtoValori.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkFurtoRapina.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoValori.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoValori.KeyPress, AddressOf TextBoxKeyPress
            AddHandler txtPartitaFurtoRapina.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoRapina.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkFurtoVetrinette.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoVetrinette.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoVetrinette.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkFurtoPortavalori.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoPortavalori.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoPortavalori.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkFurtoAumentoMerci.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoAumentoMerci.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoAumentoMerci.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkFurtoMerciTrasportate.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoMerciTrasportate.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoMerciTrasportate.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkFurtoMerciAperto.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoMerciAperto.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoMerciAperto.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkFurtoDistributoriEsterni.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoDistributoriEsterni.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoDistributoriEsterni.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkFurtoDistributoriCarburante.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoDistributoriCarburante.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoDistributoriCarburante.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkFurtoRicetteMediche.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoRicetteMediche.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoRicetteMediche.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkFurtoDipendenti.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoDipendenti.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoDipendenti.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkFurtoSpeseAccessorie.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkFurtoSpeseMiglioramento.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkFurtoSlotMachine.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoSlotMachine.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoSlotMachine.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkFurtoReintegroAutomatico.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkFurtoCommercioAmbulante.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkFurtoDepositoRiserva.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkFurtoDerogaCostruttive.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkFurtoMezziChiusura.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkFurtoImpiantoAllarme.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkFurtoAllarmeDistanza.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkFurtoAllarmeDoppio.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkFurtoVideoSorveglianza.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkFurtoScopertoMerciA.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkFurtoScopertoMerciB.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkFurtoPiuEsercizi.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoPiuEsercizi.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaFurtoPiuEsercizi.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkExt1.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkExt2.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkExt3.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkExt4.CheckedChanged, AddressOf ValuesChanged

            AddHandler cmbCaratteristicaCostruttiva.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbTipologiaFabbricato.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkcomuneMinorRischioSismico.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaTerremotoAumentoMerci.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaTerremotoAumentoMerci.KeyPress, AddressOf TextBoxKeyPress
            AddHandler txtTerremotoAumentoMerciMesi.Leave, AddressOf ValuesChanged
            AddHandler txtTerremotoAumentoMerciMesi.KeyPress, AddressOf TextBoxKeyPress

            AddHandler chkTerremotoBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbTerremotoFabbricatoLimite.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkTerremotoFabbricato.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaTerremotoFabbricato.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaTerremotoFabbricato.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkTerremotoContenuto.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaTerremotoContenuto.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaTerremotoContenuto.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkTerremotoDemolizione.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbTerremotoDemolizioneMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkTerremotoAumentoMerci.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkTerremotoRicetteMediche.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaTerremotoRicetteMediche.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaTerremotoRicetteMediche.KeyPress, AddressOf TextBoxKeyPress
        End Sub

        Public Sub ControlsToPreventivo(ByVal diretto As Boolean)

            With Fabbricato

                If diretto Then
                    .FabbricatoDestinazione = cmbFabbricatoDestinazione.SelectedValue
                    .ClasseFabbricato = cmbFabbricatoClasse.SelectedValue
                    .IncendioScelta = cmbIncendioScelta.SelectedValue
                    .IncendioEventiAtmosfericiScelta = cmbIncendioEventiAtmosfericiScelta.SelectedValue
                    .IncendioDanniElettriciScelta = cmbIncendioDanniElettriciScelta.SelectedValue
                    .IncendioDanniIndirettiScelta = cmbIncendioDanniIndirettiScelta.SelectedValue
                    .FurtoFissiScelta = cmbFurtoFissiScelta.SelectedValue
                    .FurtoValoriScelta = cmbFurtoValoriScelta.SelectedValue
                    .FurtoRapinaScelta = cmbFurtoRapinaScelta.SelectedValue
                    .Descrizione = txtDescrizione.Text
                    .Provincia = cmbProvincia.SelectedValue
                    .Comune = cmbComune.SelectedValue
                    .Note = Note.TextNote

                    .IncendioAumentoMerciMesi = IntegerBox(txtIncendioAumentoMerciMesi)
                    .FurtoAumentoMerciMesi = IntegerBox(txtFurtoAumentoMerciMesi)
                    .Estenzione1 = chkExt1.Checked
                    .Estenzione2 = chkExt2.Checked
                    .Estenzione3 = chkExt3.Checked
                    .Estenzione4 = chkExt4.Checked

                    'Incendio
                    .CoperturaIncendioBase.Stato = EnabledAndChecked(chkIncendioBase)
                    .IncendioScelta = cmbIncendioScelta.SelectedValue
                    .CoperturaIncendioFabbricato.Stato = EnabledAndChecked(chkIncendioFabbricato)
                    .PartitaIncendioFabbricato.SommaAssicurata = CurrencyBox(txtPartitaIncendioFabbricato)
                    .IncendioFabbricatoFormaDiAssicurazione = cmbIncendioFormaFabbricato.SelectedValue
                    .CoperturaIncendioContenuto.Stato = EnabledAndChecked(chkIncendioContenuto)
                    .PartitaIncendioContenuto.SommaAssicurata = CurrencyBox(txtPartitaIncendioContenuto)
                    .IncendioContenutoFormaDiAssicurazione = cmbIncendioFormaContenuto.SelectedValue
                    .CoperturaIncendioLocazione.Stato = EnabledAndChecked(chkIncendioLocazione)
                    .PartitaIncendioLocazione.SommaAssicurata = CurrencyBox(txtPartitaIncendioLocazione)
                    .IncendioLocazioneFormaDiAssicurazione = cmbIncendioFormaLocazione.SelectedValue
                    .CoperturaIncendioCondutture.Stato = EnabledAndChecked(chkIncendioCondutture)
                    .CoperturaIncendioCondutture.Garanzia.Massimale = cmbIncendioConduttureMassimale.SelectedValue
                    .CoperturaIncendioDemolizione.Stato = EnabledAndChecked(chkIncendioDemolizione)
                    .CoperturaIncendioDemolizione.Garanzia.Massimale = cmbIncendioDemolizioneMassimale.SelectedValue
                    .CoperturaIncendioEventiAtmosferici.Stato = EnabledAndChecked(chkIncendioEventiAtmosferici)
                    .IncendioEventiAtmosfericiScelta = cmbIncendioEventiAtmosfericiScelta.SelectedValue
                    .CoperturaIncendioDanniElettrici.Stato = EnabledAndChecked(chkIncendioDanniElettrici)
                    .PartitaIncendioDanniElettrici.SommaAssicurata = CurrencyBox(txtPartitaIncendioDanniElettrici)
                    .IncendioDanniElettriciScelta = cmbIncendioDanniElettriciScelta.SelectedValue
                    .CoperturaIncendioDanniIndirettiA.Stato = EnabledAndChecked(chkIncendioDanniIndirettiA)
                    .PartitaIncendioDanniIndirettiA.SommaAssicurata = CurrencyBox(txtPartitaIncendioDanniIndirettiA)
                    .CoperturaIncendioDanniIndirettiB.Stato = EnabledAndChecked(chkIncendioDanniIndirettiB)
                    .PartitaIncendioDanniIndirettiB.SommaAssicurata = CurrencyBox(txtPartitaIncendioDanniIndirettiB)
                    .IncendioDanniIndirettiScelta = cmbIncendioDanniIndirettiScelta.SelectedValue
                    .CoperturaIncendioRicorsoTerzi.Stato = EnabledAndChecked(chkIncendioRicorsoTerzi)
                    .PartitaIncendioRicorsoTerzi.SommaAssicurata = CurrencyBox(txtPartitaIncendioRicorsoTerzi)
                    .CoperturaIncendioAumentoMerci.Stato = EnabledAndChecked(chkIncendioAumentoMerci)
                    .PartitaIncendioAumentoMerci.SommaAssicurata = CurrencyBox(txtPartitaIncendioAumentoMerci)
                    .CoperturaIncendioCoseTrasportate.Stato = EnabledAndChecked(chkIncendioCoseTrasportate)
                    .PartitaIncendioCoseTrasportate.SommaAssicurata = CurrencyBox(txtPartitaIncendioCoseTrasportate)
                    .CoperturaIncendioRefrigerati1.Stato = EnabledAndChecked(chkIncendioRefrigerati1)
                    .PartitaIncendioRefrigerati1.SommaAssicurata = CurrencyBox(txtPartitaIncendioRefrigerati1)
                    .CoperturaIncendioRefrigerati2.Stato = EnabledAndChecked(chkIncendioRefrigerati2)
                    .PartitaIncendioRefrigerati2.SommaAssicurata = CurrencyBox(txtPartitaIncendioRefrigerati2)
                    .CoperturaIncendioLastre.Stato = EnabledAndChecked(chkIncendioLastre)
                    .PartitaIncendioLastre.SommaAssicurata = CurrencyBox(txtPartitaIncendioLastre)
                    .CoperturaIncendioPannelliSolari.Stato = EnabledAndChecked(chkIncendioPannelliSolari)
                    .PartitaIncendioPannelliSolari.SommaAssicurata = CurrencyBox(txtPartitaIncendioPannelliSolari)
                    .CoperturaIncendioRicetteMediche.Stato = EnabledAndChecked(chkIncendioRicetteMediche)
                    .PartitaIncendioRicetteMediche.SommaAssicurata = CurrencyBox(txtPartitaIncendioRicetteMediche)
                    .CoperturaIncendioSpeseAccessorie.Stato = EnabledAndChecked(chkIncendioSpeseAccessorie)
                    .CoperturaIncendioGrandineFragili.Stato = EnabledAndChecked(chkIncendioGrandineFragili)
                    .CoperturaIncendioAttiVandaliciDolosi.Stato = EnabledAndChecked(chkIncendioAttiVandaliciDolosi)
                    .CoperturaIncendioFabbricatiAperti1.Stato = EnabledAndChecked(chkIncendioFabbricatiAperti1)
                    .CoperturaIncendioFabbricatiAperti2.Stato = EnabledAndChecked(chkIncendioFabbricatiAperti2)
                    .CoperturaIncendioPreziosi.Stato = EnabledAndChecked(chkIncendioPreziosi)
                    .CoperturaIncendioSistemiProtezione.Stato = EnabledAndChecked(chkIncendioSistemiProtezione)
                    .CoperturaIncendioCommercioAmbulante.Stato = EnabledAndChecked(chkIncendioCommercioAmbulante)
                    .CoperturaIncendioFranchigia.Stato = EnabledAndChecked(chkIncendioFranchigia)
                    .CoperturaIncendioFranchigia.Garanzia.Franchigia = cmbIncendioFranchigiaFranchigia.SelectedValue

                    'Furto
                    .CoperturaFurtoBase.Stato = EnabledAndChecked(chkFurtoBase)
                    .CoperturaFurtoContenuto.Stato = EnabledAndChecked(chkFurtoContenuto)
                    .PartitaFurtoContenuto.SommaAssicurata = CurrencyBox(txtPartitaFurtoContenuto)
                    .CoperturaFurtoFissi.Stato = EnabledAndChecked(chkFurtoFissi)
                    .PartitaFurtoFissi.SommaAssicurata = CurrencyBox(txtPartitaFurtoFissi)
                    .FurtoFissiScelta = cmbFurtoFissiScelta.SelectedValue
                    .CoperturaFurtoValori.Stato = EnabledAndChecked(chkFurtoValori)
                    .PartitaFurtoValori.SommaAssicurata = CurrencyBox(txtPartitaFurtoValori)
                    .FurtoValoriScelta = cmbFurtoValoriScelta.SelectedValue
                    .CoperturaFurtoRapina.Stato = EnabledAndChecked(chkFurtoRapina)
                    .PartitaFurtoRapina.SommaAssicurata = CurrencyBox(txtPartitaFurtoRapina)
                    .FurtoRapinaScelta = cmbFurtoRapinaScelta.SelectedValue
                    .CoperturaFurtoVetrinette.Stato = EnabledAndChecked(chkFurtoVetrinette)
                    .PartitaFurtoVetrinette.SommaAssicurata = CurrencyBox(txtPartitaFurtoVetrinette)
                    .CoperturaFurtoPortavalori.Stato = EnabledAndChecked(chkFurtoPortavalori)
                    .PartitaFurtoPortavalori.SommaAssicurata = CurrencyBox(txtPartitaFurtoPortavalori)
                    .CoperturaFurtoAumentoMerci.Stato = EnabledAndChecked(chkFurtoAumentoMerci)
                    .PartitaFurtoAumentoMerci.SommaAssicurata = CurrencyBox(txtPartitaFurtoAumentoMerci)
                    .CoperturaFurtoMerciTrasportate.Stato = EnabledAndChecked(chkFurtoMerciTrasportate)
                    .PartitaFurtoMerciTrasportate.SommaAssicurata = CurrencyBox(txtPartitaFurtoMerciTrasportate)
                    .CoperturaFurtoMerciAperto.Stato = EnabledAndChecked(chkFurtoMerciAperto)
                    .PartitaFurtoMerciAperto.SommaAssicurata = CurrencyBox(txtPartitaFurtoMerciAperto)
                    .CoperturaFurtoDistributoriEsterni.Stato = EnabledAndChecked(chkFurtoDistributoriEsterni)
                    .PartitaFurtoDistributoriEsterni.SommaAssicurata = CurrencyBox(txtPartitaFurtoDistributoriEsterni)
                    .CoperturaFurtoDistributoriCarburante.Stato = EnabledAndChecked(chkFurtoDistributoriCarburante)
                    .PartitaFurtoDistributoriCarburante.SommaAssicurata = CurrencyBox(txtPartitaFurtoDistributoriCarburante)
                    .CoperturaFurtoRicetteMediche.Stato = EnabledAndChecked(chkFurtoRicetteMediche)
                    .PartitaFurtoRicetteMediche.SommaAssicurata = CurrencyBox(txtPartitaFurtoRicetteMediche)
                    .CoperturaFurtoDipendenti.Stato = EnabledAndChecked(chkFurtoDipendenti)
                    .PartitaFurtoDipendenti.SommaAssicurata = CurrencyBox(txtPartitaFurtoDipendenti)
                    .CoperturaFurtoSpeseAccessorie.Stato = EnabledAndChecked(chkFurtoSpeseAccessorie)
                    .CoperturaFurtoSpeseMiglioramento.Stato = EnabledAndChecked(chkFurtoSpeseMiglioramento)
                    .CoperturaFurtoSlotMachine.Stato = EnabledAndChecked(chkFurtoSlotMachine)
                    .PartitaFurtoSlotMachine.SommaAssicurata = CurrencyBox(txtPartitaFurtoSlotMachine)
                    .CoperturaFurtoReintegroAutomatico.Stato = EnabledAndChecked(chkFurtoReintegroAutomatico)
                    .CoperturaFurtoCommercioAmbulante.Stato = EnabledAndChecked(chkFurtoCommercioAmbulante)
                    .CoperturaFurtoDepositoRiserva.Stato = EnabledAndChecked(chkFurtoDepositoRiserva)
                    .CoperturaFurtoDerogaCostruttive.Stato = EnabledAndChecked(chkFurtoDerogaCostruttive)
                    .CoperturaFurtoMezziChiusura.Stato = EnabledAndChecked(chkFurtoMezziChiusura)
                    .CoperturaFurtoImpiantoAllarme.Stato = EnabledAndChecked(chkFurtoImpiantoAllarme)
                    .CoperturaFurtoAllarmeDistanza.Stato = EnabledAndChecked(chkFurtoAllarmeDistanza)
                    .CoperturaFurtoAllarmeDoppio.Stato = EnabledAndChecked(chkFurtoAllarmeDoppio)
                    .CoperturaFurtoVideoSorveglianza.Stato = EnabledAndChecked(chkFurtoVideoSorveglianza)
                    .CoperturaFurtoScopertoMerciA.Stato = EnabledAndChecked(chkFurtoScopertoMerciA)
                    .CoperturaFurtoScopertoMerciB.Stato = EnabledAndChecked(chkFurtoScopertoMerciB)
                    If .PrimoFabbricato Then
                        .YouCommercio.CoperturaFurtoPiuEsercizi.Stato = EnabledAndChecked(chkFurtoPiuEsercizi)
                        .YouCommercio.PartitaFurtoPiuEsercizi.SommaAssicurata = CurrencyBox(txtPartitaFurtoPiuEsercizi)
                    End If

                    'Terremoto
                    .comuneMinorRischioSismico = chkcomuneMinorRischioSismico.Checked
                    .CoperturaTerremotoBase.Stato = EnabledAndChecked(chkTerremotoBase)
                    .CaratteristicaCostruttiva = cmbCaratteristicaCostruttiva.SelectedValue
                    .TipologiaFabbricato = cmbTipologiaFabbricato.SelectedValue
                    .CoperturaTerremotoFabbricato.Stato = EnabledAndChecked(chkTerremotoFabbricato)
                    .PartitaTerremotoFabbricato.SommaAssicurata = CurrencyBox(txtPartitaTerremotoFabbricato)
                    .CoperturaTerremotoFabbricato.Garanzia.Limite = cmbTerremotoFabbricatoLimite.SelectedValue
                    .CoperturaTerremotoContenuto.Stato = EnabledAndChecked(chkTerremotoContenuto)
                    .PartitaTerremotoContenuto.SommaAssicurata = CurrencyBox(txtPartitaTerremotoContenuto)
                    .CoperturaTerremotoDemolizione.Stato = EnabledAndChecked(chkTerremotoDemolizione)
                    .CoperturaTerremotoDemolizione.Garanzia.Massimale = cmbTerremotoDemolizioneMassimale.SelectedValue
                    .CoperturaTerremotoAumentoMerci.Stato = EnabledAndChecked(chkTerremotoAumentoMerci)
                    .CoperturaTerremotoRicetteMediche.Stato = EnabledAndChecked(chkTerremotoRicetteMediche)
                    .PartitaTerremotoRicetteMediche.SommaAssicurata = CurrencyBox(txtPartitaTerremotoRicetteMediche)

                    .CoperturaTerremotoAumentoMerci.Stato = EnabledAndChecked(chkTerremotoAumentoMerci)
                    .PartitaTerremotoAumentoMerci.SommaAssicurata = CurrencyBox(txtPartitaTerremotoAumentoMerci)
                    .TerremotoAumentoMerciMesi = IntegerBox(txtTerremotoAumentoMerciMesi)
                Else
                    cmbFabbricatoDestinazione.SelectedValue = CInt(.FabbricatoDestinazione)
                    cmbFabbricatoDestinazione.Enabled = True
                    cmbFabbricatoClasse.SelectedValue = CInt(.ClasseFabbricato)
                    cmbFabbricatoClasse.Enabled = True
                    txtDescrizione.Text = .Descrizione
                    cmbProvincia.SelectedValue = .Provincia
                    cmbProvincia.Enabled = True
                    cmbComune.SelectedValue = .Comune
                    cmbComune.Enabled = True
                    Note.TextNote = .Note
                    IntegerBox(txtIncendioAumentoMerciMesi) = .IncendioAumentoMerciMesi
                    txtIncendioAumentoMerciMesi.Enabled = True
                    IntegerBox(txtFurtoAumentoMerciMesi) = .FurtoAumentoMerciMesi
                    txtFurtoAumentoMerciMesi.Enabled = True
                    chkExt1.Checked = .Estenzione1
                    chkExt2.Checked = .Estenzione2
                    chkExt3.Checked = .Estenzione3
                    chkExt4.Checked = .Estenzione4

                    'Incendio
                    EnabledAndChecked(chkIncendioBase) = .CoperturaIncendioBase.Stato
                    cmbIncendioScelta.Enabled = .CoperturaIncendioBase.IsAttivo
                    cmbIncendioScelta.SelectedValue = CInt(.IncendioScelta)
                    EnabledAndChecked(chkIncendioFabbricato) = .CoperturaIncendioFabbricato.Stato
                    CurrencyBox(txtPartitaIncendioFabbricato) = .PartitaIncendioFabbricato.SommaAssicurata
                    txtPartitaIncendioFabbricato.Enabled = Enable(.CoperturaIncendioFabbricato.Stato)
                    cmbIncendioFormaFabbricato.Enabled = Enable(.CoperturaIncendioFabbricato.Stato)
                    cmbIncendioFormaFabbricato.SelectedValue = CInt(.IncendioFabbricatoFormaDiAssicurazione)
                    FormatEuro(lblIncendioFabbricato, .CoperturaIncendioFabbricato)
                    FormatEuro(lblIncendioFabbricato, .CoperturaIncendioFabbricato)
                    EnabledAndChecked(chkIncendioContenuto) = .CoperturaIncendioContenuto.Stato
                    CurrencyBox(txtPartitaIncendioContenuto) = .PartitaIncendioContenuto.SommaAssicurata
                    txtPartitaIncendioContenuto.Enabled = Enable(.CoperturaIncendioContenuto.Stato)
                    cmbIncendioFormaContenuto.Enabled = Enable(.CoperturaIncendioContenuto.Stato)
                    cmbIncendioFormaContenuto.SelectedValue = CInt(.IncendioContenutoFormaDiAssicurazione)
                    FormatEuro(lblIncendioContenuto, .CoperturaIncendioContenuto)
                    EnabledAndChecked(chkIncendioLocazione) = .CoperturaIncendioLocazione.Stato
                    CurrencyBox(txtPartitaIncendioLocazione) = .PartitaIncendioLocazione.SommaAssicurata
                    txtPartitaIncendioLocazione.Enabled = Enable(.CoperturaIncendioLocazione.Stato)
                    cmbIncendioFormaLocazione.Enabled = Enable(.CoperturaIncendioLocazione.Stato)
                    cmbIncendioFormaLocazione.SelectedValue = CInt(.IncendioLocazioneFormaDiAssicurazione)
                    FormatEuro(lblIncendioLocazione, .CoperturaIncendioLocazione)
                    EnabledAndChecked(chkIncendioCondutture) = .CoperturaIncendioCondutture.Stato
                    FormatEuro(lblIncendioCondutture, .CoperturaIncendioCondutture)
                    cmbIncendioConduttureMassimale.Enabled = Enable(.CoperturaIncendioCondutture.Stato)
                    cmbIncendioConduttureMassimale.SelectedValue = .CoperturaIncendioCondutture.Garanzia.Massimale
                    EnabledAndChecked(chkIncendioDemolizione) = .CoperturaIncendioDemolizione.Stato
                    FormatEuro(lblIncendioDemolizione, .CoperturaIncendioDemolizione)
                    cmbIncendioDemolizioneMassimale.Enabled = Enable(.CoperturaIncendioDemolizione.Stato)
                    cmbIncendioDemolizioneMassimale.SelectedValue = .CoperturaIncendioDemolizione.Garanzia.Massimale
                    EnabledAndChecked(chkIncendioEventiAtmosferici) = .CoperturaIncendioEventiAtmosferici.Stato
                    FormatEuro(lblIncendioEventiAtmosferici, .CoperturaIncendioEventiAtmosferici)
                    cmbIncendioEventiAtmosfericiScelta.Enabled = Enable(.CoperturaIncendioEventiAtmosferici.Stato)
                    cmbIncendioEventiAtmosfericiScelta.SelectedValue = CInt(.IncendioEventiAtmosfericiScelta)
                    EnabledAndChecked(chkIncendioDanniElettrici) = .CoperturaIncendioDanniElettrici.Stato
                    CurrencyBox(txtPartitaIncendioDanniElettrici) = .PartitaIncendioDanniElettrici.SommaAssicurata
                    txtPartitaIncendioDanniElettrici.Enabled = Enable(.CoperturaIncendioDanniElettrici.Stato)
                    FormatEuro(lblIncendioDanniElettrici, .CoperturaIncendioDanniElettrici)
                    cmbIncendioDanniElettriciScelta.Enabled = Enable(.CoperturaIncendioDanniElettrici.Stato)
                    cmbIncendioDanniElettriciScelta.SelectedValue = CInt(.IncendioDanniElettriciScelta)
                    EnabledAndChecked(chkIncendioDanniIndirettiA) = .CoperturaIncendioDanniIndirettiA.Stato
                    CurrencyBox(txtPartitaIncendioDanniIndirettiA) = .PartitaIncendioDanniIndirettiA.SommaAssicurata
                    txtPartitaIncendioDanniIndirettiA.Enabled = Enable(.CoperturaIncendioDanniIndirettiA.Stato)
                    FormatEuro(lblIncendioDanniIndirettiA, .CoperturaIncendioDanniIndirettiA)
                    cmbIncendioDanniIndirettiScelta.Enabled = Enable(.CoperturaIncendioDanniIndirettiA.Stato)
                    cmbIncendioDanniIndirettiScelta.SelectedValue = CInt(.IncendioDanniIndirettiScelta)
                    EnabledAndChecked(chkIncendioDanniIndirettiB) = .CoperturaIncendioDanniIndirettiB.Stato
                    CurrencyBox(txtPartitaIncendioDanniIndirettiB) = .PartitaIncendioDanniIndirettiB.SommaAssicurata
                    txtPartitaIncendioDanniIndirettiB.Enabled = Enable(.CoperturaIncendioDanniIndirettiB.Stato)
                    FormatEuro(lblIncendioDanniIndirettiB, .CoperturaIncendioDanniIndirettiB)
                    EnabledAndChecked(chkIncendioRicorsoTerzi) = .CoperturaIncendioRicorsoTerzi.Stato
                    CurrencyBox(txtPartitaIncendioRicorsoTerzi) = .PartitaIncendioRicorsoTerzi.SommaAssicurata
                    txtPartitaIncendioRicorsoTerzi.Enabled = Enable(.CoperturaIncendioRicorsoTerzi.Stato)
                    FormatEuro(lblIncendioRicorsoTerzi, .CoperturaIncendioRicorsoTerzi)
                    EnabledAndChecked(chkIncendioAumentoMerci) = .CoperturaIncendioAumentoMerci.Stato
                    CurrencyBox(txtPartitaIncendioAumentoMerci) = .PartitaIncendioAumentoMerci.SommaAssicurata
                    txtPartitaIncendioAumentoMerci.Enabled = Enable(.CoperturaIncendioAumentoMerci.Stato)
                    FormatEuro(lblIncendioAumentoMerci, .CoperturaIncendioAumentoMerci)
                    IntegerBox(txtIncendioAumentoMerciMesi) = .IncendioAumentoMerciMesi
                    txtIncendioAumentoMerciMesi.Enabled = Enable(.CoperturaIncendioAumentoMerci.Stato)
                    EnabledAndChecked(chkIncendioCoseTrasportate) = .CoperturaIncendioCoseTrasportate.Stato
                    CurrencyBox(txtPartitaIncendioCoseTrasportate) = .PartitaIncendioCoseTrasportate.SommaAssicurata
                    txtPartitaIncendioCoseTrasportate.Enabled = Enable(.CoperturaIncendioCoseTrasportate.Stato)
                    FormatEuro(lblIncendioCoseTrasportate, .CoperturaIncendioCoseTrasportate)
                    EnabledAndChecked(chkIncendioRefrigerati1) = .CoperturaIncendioRefrigerati1.Stato
                    CurrencyBox(txtPartitaIncendioRefrigerati1) = .PartitaIncendioRefrigerati1.SommaAssicurata
                    txtPartitaIncendioRefrigerati1.Enabled = Enable(.CoperturaIncendioRefrigerati1.Stato)
                    FormatEuro(lblIncendioRefrigerati1, .CoperturaIncendioRefrigerati1)
                    EnabledAndChecked(chkIncendioRefrigerati2) = .CoperturaIncendioRefrigerati2.Stato
                    CurrencyBox(txtPartitaIncendioRefrigerati2) = .PartitaIncendioRefrigerati2.SommaAssicurata
                    txtPartitaIncendioRefrigerati2.Enabled = Enable(.CoperturaIncendioRefrigerati2.Stato)
                    FormatEuro(lblIncendioRefrigerati2, .CoperturaIncendioRefrigerati2)
                    EnabledAndChecked(chkIncendioLastre) = .CoperturaIncendioLastre.Stato
                    CurrencyBox(txtPartitaIncendioLastre) = .PartitaIncendioLastre.SommaAssicurata
                    txtPartitaIncendioLastre.Enabled = Enable(.CoperturaIncendioLastre.Stato)
                    FormatEuro(lblIncendioLastre, .CoperturaIncendioLastre)
                    EnabledAndChecked(chkIncendioPannelliSolari) = .CoperturaIncendioPannelliSolari.Stato
                    CurrencyBox(txtPartitaIncendioPannelliSolari) = .PartitaIncendioPannelliSolari.SommaAssicurata
                    txtPartitaIncendioPannelliSolari.Enabled = Enable(.CoperturaIncendioPannelliSolari.Stato)
                    FormatEuro(lblIncendioPannelliSolari, .CoperturaIncendioPannelliSolari)
                    EnabledAndChecked(chkIncendioRicetteMediche) = .CoperturaIncendioRicetteMediche.Stato
                    CurrencyBox(txtPartitaIncendioRicetteMediche) = .PartitaIncendioRicetteMediche.SommaAssicurata
                    txtPartitaIncendioRicetteMediche.Enabled = Enable(.CoperturaIncendioRicetteMediche.Stato)
                    FormatEuro(lblIncendioRicetteMediche, .CoperturaIncendioRicetteMediche)
                    EnabledAndChecked(chkIncendioSpeseAccessorie) = .CoperturaIncendioSpeseAccessorie.Stato
                    FormatEuro(lblIncendioSpeseAccessorie, .CoperturaIncendioSpeseAccessorie)
                    EnabledAndChecked(chkIncendioGrandineFragili) = .CoperturaIncendioGrandineFragili.Stato
                    FormatEuro(lblIncendioGrandineFragili, .CoperturaIncendioGrandineFragili)
                    EnabledAndChecked(chkIncendioAttiVandaliciDolosi) = .CoperturaIncendioAttiVandaliciDolosi.Stato
                    FormatEuro(lblIncendioAttiVandaliciDolosi, .CoperturaIncendioAttiVandaliciDolosi)
                    EnabledAndChecked(chkIncendioFabbricatiAperti1) = .CoperturaIncendioFabbricatiAperti1.Stato
                    FormatEuro(lblIncendioFabbricatiAperti1, .CoperturaIncendioFabbricatiAperti1)
                    EnabledAndChecked(chkIncendioFabbricatiAperti2) = .CoperturaIncendioFabbricatiAperti2.Stato
                    FormatEuro(lblIncendioFabbricatiAperti2, .CoperturaIncendioFabbricatiAperti2)
                    EnabledAndChecked(chkIncendioPreziosi) = .CoperturaIncendioPreziosi.Stato
                    FormatEuro(lblIncendioPreziosi, .CoperturaIncendioPreziosi)
                    EnabledAndChecked(chkIncendioSistemiProtezione) = .CoperturaIncendioSistemiProtezione.Stato
                    FormatEuro(lblIncendioSistemiProtezione, .CoperturaIncendioSistemiProtezione)
                    EnabledAndChecked(chkIncendioCommercioAmbulante) = .CoperturaIncendioCommercioAmbulante.Stato
                    FormatEuro(lblIncendioCommercioAmbulante, .CoperturaIncendioCommercioAmbulante)
                    EnabledAndChecked(chkIncendioFranchigia) = .CoperturaIncendioFranchigia.Stato
                    chkIncendioFranchigia.Enabled = chkIncendioFranchigia.Enabled And .PrimoFabbricato
                    FormatEuro(lblIncendioFranchigia, .CoperturaIncendioFranchigia)
                    cmbIncendioFranchigiaFranchigia.Enabled = Enable(.CoperturaIncendioFranchigia.Stato)
                    cmbIncendioFranchigiaFranchigia.Enabled = cmbIncendioFranchigiaFranchigia.Enabled And .PrimoFabbricato
                    cmbIncendioFranchigiaFranchigia.SelectedValue = .CoperturaIncendioFranchigia.Garanzia.Franchigia
                    FormatEuro(lblIncendioPremio, .CoperturaIncendio)

                    'Furto
                    EnabledAndChecked(chkFurtoBase) = .CoperturaFurtoBase.Stato
                    EnabledAndChecked(chkFurtoContenuto) = .CoperturaFurtoContenuto.Stato
                    CurrencyBox(txtPartitaFurtoContenuto) = .PartitaFurtoContenuto.SommaAssicurata
                    txtPartitaFurtoContenuto.Enabled = Enable(.CoperturaFurtoContenuto.Stato)
                    FormatEuro(lblFurtoContenuto, .CoperturaFurtoContenuto)
                    EnabledAndChecked(chkFurtoFissi) = .CoperturaFurtoFissi.Stato
                    CurrencyBox(txtPartitaFurtoFissi) = .PartitaFurtoFissi.SommaAssicurata
                    txtPartitaFurtoFissi.Enabled = Enable(.CoperturaFurtoFissi.Stato) And .FurtoFissiScelta = FurtoFissiSceltaEnum.SceltaB
                    FormatEuro(lblFurtoFissi, .CoperturaFurtoFissi)
                    cmbFurtoFissiScelta.Enabled = Enable(.CoperturaFurtoFissi.Stato)
                    cmbFurtoFissiScelta.SelectedValue = CInt(.FurtoFissiScelta)
                    EnabledAndChecked(chkFurtoValori) = .CoperturaFurtoValori.Stato
                    CurrencyBox(txtPartitaFurtoValori) = .PartitaFurtoValori.SommaAssicurata
                    txtPartitaFurtoValori.Enabled = Enable(.CoperturaFurtoValori.Stato) And .FurtoValoriScelta = FurtoValoriSceltaEnum.SceltaB
                    FormatEuro(lblFurtoValori, .CoperturaFurtoValori)
                    cmbFurtoValoriScelta.Enabled = Enable(.CoperturaFurtoValori.Stato)
                    cmbFurtoValoriScelta.SelectedValue = CInt(.FurtoValoriScelta)
                    EnabledAndChecked(chkFurtoRapina) = .CoperturaFurtoRapina.Stato
                    CurrencyBox(txtPartitaFurtoRapina) = .PartitaFurtoRapina.SommaAssicurata
                    txtPartitaFurtoRapina.Enabled = Enable(.CoperturaFurtoRapina.Stato) And .FurtoRapinaScelta = FurtoRapinaSceltaEnum.SceltaB
                    FormatEuro(lblFurtoRapina, .CoperturaFurtoRapina)
                    cmbFurtoRapinaScelta.Enabled = Enable(.CoperturaFurtoRapina.Stato)
                    cmbFurtoRapinaScelta.SelectedValue = CInt(.FurtoRapinaScelta)
                    EnabledAndChecked(chkFurtoVetrinette) = .CoperturaFurtoVetrinette.Stato
                    CurrencyBox(txtPartitaFurtoVetrinette) = .PartitaFurtoVetrinette.SommaAssicurata
                    txtPartitaFurtoVetrinette.Enabled = Enable(.CoperturaFurtoVetrinette.Stato)
                    FormatEuro(lblFurtoVetrinette, .CoperturaFurtoVetrinette)
                    EnabledAndChecked(chkFurtoPortavalori) = .CoperturaFurtoPortavalori.Stato
                    CurrencyBox(txtPartitaFurtoPortavalori) = .PartitaFurtoPortavalori.SommaAssicurata
                    txtPartitaFurtoPortavalori.Enabled = Enable(.CoperturaFurtoPortavalori.Stato)
                    FormatEuro(lblFurtoPortavalori, .CoperturaFurtoPortavalori)
                    EnabledAndChecked(chkFurtoAumentoMerci) = .CoperturaFurtoAumentoMerci.Stato
                    CurrencyBox(txtPartitaFurtoAumentoMerci) = .PartitaFurtoAumentoMerci.SommaAssicurata
                    txtPartitaFurtoAumentoMerci.Enabled = Enable(.CoperturaFurtoAumentoMerci.Stato)
                    FormatEuro(lblFurtoAumentoMerci, .CoperturaFurtoAumentoMerci)
                    IntegerBox(txtFurtoAumentoMerciMesi) = .FurtoAumentoMerciMesi
                    txtFurtoAumentoMerciMesi.Enabled = Enable(.CoperturaFurtoAumentoMerci.Stato)
                    EnabledAndChecked(chkFurtoMerciTrasportate) = .CoperturaFurtoMerciTrasportate.Stato
                    CurrencyBox(txtPartitaFurtoMerciTrasportate) = .PartitaFurtoMerciTrasportate.SommaAssicurata
                    txtPartitaFurtoMerciTrasportate.Enabled = Enable(.CoperturaFurtoMerciTrasportate.Stato)
                    FormatEuro(lblFurtoMerciTrasportate, .CoperturaFurtoMerciTrasportate)
                    EnabledAndChecked(chkFurtoMerciAperto) = .CoperturaFurtoMerciAperto.Stato
                    CurrencyBox(txtPartitaFurtoMerciAperto) = .PartitaFurtoMerciAperto.SommaAssicurata
                    txtPartitaFurtoMerciAperto.Enabled = Enable(.CoperturaFurtoMerciAperto.Stato)
                    FormatEuro(lblFurtoMerciAperto, .CoperturaFurtoMerciAperto)
                    EnabledAndChecked(chkFurtoDistributoriEsterni) = .CoperturaFurtoDistributoriEsterni.Stato
                    CurrencyBox(txtPartitaFurtoDistributoriEsterni) = .PartitaFurtoDistributoriEsterni.SommaAssicurata
                    txtPartitaFurtoDistributoriEsterni.Enabled = Enable(.CoperturaFurtoDistributoriEsterni.Stato)
                    FormatEuro(lblFurtoDistributoriEsterni, .CoperturaFurtoDistributoriEsterni)
                    EnabledAndChecked(chkFurtoDistributoriCarburante) = .CoperturaFurtoDistributoriCarburante.Stato
                    CurrencyBox(txtPartitaFurtoDistributoriCarburante) = .PartitaFurtoDistributoriCarburante.SommaAssicurata
                    txtPartitaFurtoDistributoriCarburante.Enabled = Enable(.CoperturaFurtoDistributoriCarburante.Stato)
                    FormatEuro(lblFurtoDistributoriCarburante, .CoperturaFurtoDistributoriCarburante)
                    EnabledAndChecked(chkFurtoRicetteMediche) = .CoperturaFurtoRicetteMediche.Stato
                    CurrencyBox(txtPartitaFurtoRicetteMediche) = .PartitaFurtoRicetteMediche.SommaAssicurata
                    txtPartitaFurtoRicetteMediche.Enabled = Enable(.CoperturaFurtoRicetteMediche.Stato)
                    FormatEuro(lblFurtoRicetteMediche, .CoperturaFurtoRicetteMediche)
                    EnabledAndChecked(chkFurtoDipendenti) = .CoperturaFurtoDipendenti.Stato
                    CurrencyBox(txtPartitaFurtoDipendenti) = .PartitaFurtoDipendenti.SommaAssicurata
                    txtPartitaFurtoDipendenti.Enabled = Enable(.CoperturaFurtoDipendenti.Stato)
                    FormatEuro(lblFurtoDipendenti, .CoperturaFurtoDipendenti)
                    EnabledAndChecked(chkFurtoSpeseAccessorie) = .CoperturaFurtoSpeseAccessorie.Stato
                    FormatEuro(lblFurtoSpeseAccessorie, .CoperturaFurtoSpeseAccessorie)
                    EnabledAndChecked(chkFurtoSpeseMiglioramento) = .CoperturaFurtoSpeseMiglioramento.Stato
                    FormatEuro(lblFurtoSpeseMiglioramento, .CoperturaFurtoSpeseMiglioramento)
                    EnabledAndChecked(chkFurtoSlotMachine) = .CoperturaFurtoSlotMachine.Stato
                    CurrencyBox(txtPartitaFurtoSlotMachine) = .PartitaFurtoSlotMachine.SommaAssicurata
                    txtPartitaFurtoSlotMachine.Enabled = Enable(.CoperturaFurtoSlotMachine.Stato)
                    FormatEuro(lblFurtoSlotMachine, .CoperturaFurtoSlotMachine)
                    EnabledAndChecked(chkFurtoReintegroAutomatico) = .CoperturaFurtoReintegroAutomatico.Stato
                    FormatEuro(lblFurtoReintegroAutomatico, .CoperturaFurtoReintegroAutomatico)
                    EnabledAndChecked(chkFurtoCommercioAmbulante) = .CoperturaFurtoCommercioAmbulante.Stato
                    FormatEuro(lblFurtoCommercioAmbulante, .CoperturaFurtoCommercioAmbulante)
                    EnabledAndChecked(chkFurtoDepositoRiserva) = .CoperturaFurtoDepositoRiserva.Stato
                    FormatEuro(lblFurtoDepositoRiserva, .CoperturaFurtoDepositoRiserva)
                    EnabledAndChecked(chkFurtoDerogaCostruttive) = .CoperturaFurtoDerogaCostruttive.Stato
                    FormatEuro(lblFurtoDerogaCostruttive, .CoperturaFurtoDerogaCostruttive)
                    EnabledAndChecked(chkFurtoMezziChiusura) = .CoperturaFurtoMezziChiusura.Stato
                    FormatEuro(lblFurtoMezziChiusura, .CoperturaFurtoMezziChiusura)
                    EnabledAndChecked(chkFurtoImpiantoAllarme) = .CoperturaFurtoImpiantoAllarme.Stato
                    FormatEuro(lblFurtoImpiantoAllarme, .CoperturaFurtoImpiantoAllarme)
                    EnabledAndChecked(chkFurtoAllarmeDistanza) = .CoperturaFurtoAllarmeDistanza.Stato
                    FormatEuro(lblFurtoAllarmeDistanza, .CoperturaFurtoAllarmeDistanza)
                    EnabledAndChecked(chkFurtoAllarmeDoppio) = .CoperturaFurtoAllarmeDoppio.Stato
                    FormatEuro(lblFurtoAllarmeDoppio, .CoperturaFurtoAllarmeDoppio)
                    EnabledAndChecked(chkFurtoVideoSorveglianza) = .CoperturaFurtoVideoSorveglianza.Stato
                    FormatEuro(lblFurtoVideoSorveglianza, .CoperturaFurtoVideoSorveglianza)
                    EnabledAndChecked(chkFurtoScopertoMerciA) = .CoperturaFurtoScopertoMerciA.Stato
                    FormatEuro(lblFurtoScopertoMerciA, .CoperturaFurtoScopertoMerciA)
                    EnabledAndChecked(chkFurtoScopertoMerciB) = .CoperturaFurtoScopertoMerciB.Stato
                    FormatEuro(lblFurtoScopertoMerciB, .CoperturaFurtoScopertoMerciB)

                    EnabledAndChecked(chkFurtoPiuEsercizi) = .YouCommercio.CoperturaFurtoPiuEsercizi.Stato
                    CurrencyBox(txtPartitaFurtoPiuEsercizi) = .YouCommercio.PartitaFurtoPiuEsercizi.SommaAssicurata
                    chkFurtoPiuEsercizi.Enabled = chkFurtoPiuEsercizi.Enabled And .PrimoFabbricato
                    txtPartitaFurtoPiuEsercizi.Enabled = .YouCommercio.CoperturaFurtoPiuEsercizi.IsAttivo And .PrimoFabbricato
                    FormatEuro(lblFurtoPiuEsercizi, .CoperturaFurtoPiuEsercizi)

                    FormatEuro(lblFurtoPremio, .CoperturaFurto)

                    chkcomuneMinorRischioSismico.Checked = .comuneMinorRischioSismico
                    chkcomuneMinorRischioSismico.Enabled = True
                    IntegerBox(txtTerremotoAumentoMerciMesi) = .TerremotoAumentoMerciMesi
                    txtTerremotoAumentoMerciMesi.Enabled = True

                    'Terremoto
                    EnabledAndChecked(chkTerremotoBase) = .CoperturaTerremotoBase.Stato

                    cmbTerremotoFabbricatoLimite.Enabled = Enable(.CoperturaTerremotoFabbricato.Stato)
                    cmbTerremotoFabbricatoLimite.SelectedValue = .CoperturaTerremotoFabbricato.Garanzia.Limite
                    cmbCaratteristicaCostruttiva.Enabled = Enable(.CoperturaTerremotoFabbricato.Stato)
                    cmbCaratteristicaCostruttiva.SelectedValue = CInt(.CaratteristicaCostruttiva)

                    cmbTipologiaFabbricato.Enabled = Enable(.CoperturaTerremotoFabbricato.Stato)
                    cmbTipologiaFabbricato.SelectedValue = CInt(.TipologiaFabbricato)

                    EnabledAndChecked(chkTerremotoFabbricato) = .CoperturaTerremotoFabbricato.Stato
                    CurrencyBox(txtPartitaTerremotoFabbricato) = .PartitaTerremotoFabbricato.SommaAssicurata
                    txtPartitaTerremotoFabbricato.Enabled = False 'Enable(.CoperturaTerremotoFabbricato.Stato)
                    FormatEuro(lblTerremotoFabbricato, .CoperturaTerremotoFabbricato)
                    EnabledAndChecked(chkTerremotoContenuto) = .CoperturaTerremotoContenuto.Stato
                    CurrencyBox(txtPartitaTerremotoContenuto) = .PartitaTerremotoContenuto.SommaAssicurata
                    txtPartitaTerremotoContenuto.Enabled = False 'Enable(.CoperturaTerremotoContenuto.Stato)
                    FormatEuro(lblTerremotoContenuto, .CoperturaTerremotoContenuto)
                    EnabledAndChecked(chkTerremotoDemolizione) = .CoperturaTerremotoDemolizione.Stato
                    FormatEuro(lblTerremotoDemolizione, .CoperturaTerremotoDemolizione)
                    cmbTerremotoDemolizioneMassimale.Enabled = False 'Enable(.CoperturaTerremotoDemolizione.Stato)
                    cmbTerremotoDemolizioneMassimale.SelectedValue = .CoperturaTerremotoDemolizione.Garanzia.Massimale

                    EnabledAndChecked(chkTerremotoAumentoMerci) = .CoperturaTerremotoAumentoMerci.Stato
                    FormatEuro(lblTerremotoAumentoMerci, .CoperturaTerremotoAumentoMerci)
                    IntegerBox(txtTerremotoAumentoMerciMesi) = .TerremotoAumentoMerciMesi
                    txtTerremotoAumentoMerciMesi.Enabled = False 'Enable(.CoperturaTerremotoAumentoMerci.Stato)
                    txtPartitaTerremotoAumentoMerci.Enabled = Enable(.CoperturaTerremotoAumentoMerci.Stato)
                    CurrencyBox(txtPartitaTerremotoAumentoMerci) = .PartitaTerremotoAumentoMerci.SommaAssicurata

                    EnabledAndChecked(chkTerremotoRicetteMediche) = .CoperturaTerremotoRicetteMediche.Stato
                    CurrencyBox(txtPartitaTerremotoRicetteMediche) = .PartitaTerremotoRicetteMediche.SommaAssicurata
                    txtPartitaTerremotoRicetteMediche.Enabled = False 'Enable(.CoperturaTerremotoRicetteMediche.Stato)
                    FormatEuro(lblTerremotoRicetteMediche, .CoperturaTerremotoRicetteMediche)

                    FormatEuro(lblTerremotoPremio, .CoperturaTerremoto)

                    HighlightCheckAndLabel({TableLayoutPanel2, TableLayoutPanel3, TableLayoutPanel4, TableLayoutPanel5, TableLayoutPanel8})
                End If
            End With
        End Sub

        Public Sub New(ByVal decode As P04226DE)
            ' Chiamata richiesta da Progettazione Windows Form.
            InitializeComponent()
            AttachCombo(cmbProvincia, Luogo.Province)
            'AttachCombo(cmbComune, Luogo.Comuni)
            AttachCombo(cmbFabbricatoDestinazione, decode.DecodeFabbricatoDestinazione)
            AttachCombo(cmbFabbricatoClasse, decode.DecodeClasseFabbricato)
            AttachCombo(cmbIncendioScelta, decode.DecodeIncendioScelta)
            AttachCombo(cmbIncendioFormaFabbricato, decode.DecodeFormaDiAssicurazione)
            AttachCombo(cmbIncendioFormaContenuto, decode.DecodeFormaDiAssicurazione)
            AttachCombo(cmbIncendioFormaLocazione, decode.DecodeFormaDiAssicurazione)
            AttachCombo(cmbIncendioEventiAtmosfericiScelta, decode.DecodeIncendioEventiAtmosfericiScelta)
            AttachCombo(cmbIncendioDanniElettriciScelta, decode.DecodeIncendioDanniElettriciScelta)
            AttachCombo(cmbIncendioDanniIndirettiScelta, decode.DecodeIncendioDanniIndirettiScelta)
            AttachCombo(cmbFurtoFissiScelta, decode.DecodeFurtoFissiScelta)
            AttachCombo(cmbFurtoValoriScelta, decode.DecodeFurtoValoriScelta)
            AttachCombo(cmbFurtoRapinaScelta, decode.DecodeFurtoRapinaScelta)
            AttachCombo(cmbIncendioConduttureMassimale, decode.DecodeIncendioConduttureMassimale)
            AttachCombo(cmbIncendioDemolizioneMassimale, decode.DecodeIncendioDemolizioneMassimale)
            AttachCombo(cmbIncendioFranchigiaFranchigia, decode.DecodeIncendioFranchigiaFranchigia)

            AttachCombo(cmbCaratteristicaCostruttiva, decode.DecodeCaratteristicaCostruttiva)
            AttachCombo(cmbTipologiaFabbricato, decode.DecodeTipologiaFabbricato)
            AttachCombo(cmbTerremotoFabbricatoLimite, decode.DecodeTerremotoBaseLimite)
            AttachCombo(cmbTerremotoDemolizioneMassimale, decode.DecodeTerremotoDemolizioneMassimale)

            AttachEvents()
            AgganciaCheckAndLabel({TableLayoutPanel2, TableLayoutPanel3, TableLayoutPanel4, TableLayoutPanel5, TableLayoutPanel8})
        End Sub

        Private Sub RemoveAbitazione(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If MsgBox("Eliminare il fabbricato selezionato?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
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

        Private Sub cmbProvincia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProvincia.SelectedIndexChanged
            cmbProvinciaSelectedIndexChanged(cmbProvincia, cmbComune)
        End Sub
    End Class
End Namespace
