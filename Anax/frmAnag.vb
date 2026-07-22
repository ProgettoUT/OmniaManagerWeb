Imports System.Windows.Forms
Imports System.Drawing

Public Class frmAnag
    Dim DataGridViewCellStyleValuta As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStylePercento As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()


    Private mTextBoxErrors As New Dictionary(Of TextBox, String)
    Private mCellBoxErrors As New Dictionary(Of DataGridViewCell, String)

    Private mAnagrafica As New Anagrafica

    Private cmbCodAbitazione As ComboBox()
    Private txtmq As TextBox()
    Private txtValoreCommerciale As TextBox()
    Private chkProprietario As CheckBox()
    Private chkMutuo As CheckBox()
    Private txtImportoAnnuale As TextBox()

    Private cmbTipoAttivita As ComboBox()
    Private chkImpresaPubblica As CheckBox()
    Private txtImpresaSettore As TextBox()
    Private cmbImpresaDimensione As ComboBox()
    Private txtImpresaDenominazione As TextBox()
    Private txtImpresaInizio As TextBox()
    Private cmbAttivitaFase As ComboBox()
    Private txtAtivitaImporto As TextBox()

    Private cmbCodSoddisfazione As ComboBox()
    Private lblCodServizio As Label()

    Private cmbCodStrumento As ComboBox()
    Private txtImporto As TextBox()
    Private txtBanca As TextBox()
    Private txtSim As TextBox()
    Private txtTipologia As TextBox()
    Private cmbCodEsperienza As ComboBox()
    Private chkCoperturaPolizza As CheckBox()

    Private cmbCodRelazione As ComboBox()
    Private txtNome As TextBox()
    Private txtEta As TextBox()
    Private txtCodiceFiscaleFamiliare As TextBox()
    Private chkConvivente As CheckBox()
    Private txtAttivitaSvolta As TextBox()
    Private txtAttivitaLuogo As TextBox()
    Private txtAttivitaInizio As TextBox()
    Private txtRedditoAnnuo As TextBox()

    Private cmbCodRamo As ComboBox()
    Private txtPremio As TextBox()

    Private txtSpesaImporto As TextBox()
    Private lblSpesaDescrizione As Label()
    Private lblSpesaDettaglio As Label()

    Private txtDesHobby As TextBox()
    Private txtFrequenza As TextBox()
    Private chkPericoloInfortuni As CheckBox()
    Private chkPericoloMorte As CheckBox()
    Private chkCoperturaHobby As CheckBox()

    Private cmbSezione As ComboBox()
    Private txtPolizza As TextBox()
    Private txtCompagnia As TextBox()
    Private txtTarga As TextBox()
    Private txtMarca As TextBox()
    Private txtModello As TextBox()
    Private txtDoc As TextBox()
    Private txtDataScadenza As TextBox()
    Private txtDataDisdetta As TextBox()
    Private txtDataPreventivo As TextBox()


    Private Sub SetDoubleBuffered(oggetto As Object)
        oggetto.GetType.InvokeMember("DoubleBuffered",
                                     Reflection.BindingFlags.NonPublic Or
                                     Reflection.BindingFlags.Instance Or
                                     Reflection.BindingFlags.SetProperty,
                                     Nothing, oggetto, New Object() {True})
    End Sub

    Sub New()
        InitializeComponent()
        'TabControl1.TabPages.Remove(TabPage7)
        AddChangeEvents()
        imgError.Image = ErrorProvider1.Icon.ToBitmap

        SetDoubleBuffered(grdAnaliRca)
        SetDoubleBuffered(grdArretrati)
        'SetDoubleBuffered(grdDiario) '!?!Problema con il paint!!!
        SetDoubleBuffered(grdFasiVendita)
        SetDoubleBuffered(grdOpzioni)
        SetDoubleBuffered(grdPolizzeAltrui)
        SetDoubleBuffered(grdPolizzeNostre)
        SetDoubleBuffered(grdScadenze)
        SetDoubleBuffered(TabControl1)

        cmbCodAbitazione = {cmbCodAbitazione0, cmbCodAbitazione1, cmbCodAbitazione2, cmbCodAbitazione3}
        txtmq = {txtmq0, txtmq1, txtmq2, txtmq3}
        txtValoreCommerciale = {txtValoreCommerciale0, txtValoreCommerciale1, txtValoreCommerciale2, txtValoreCommerciale3}
        chkProprietario = {chkProprietario0, chkProprietario1, chkProprietario2, chkProprietario3}
        chkMutuo = {chkMutuo0, chkMutuo1, chkMutuo2, chkMutuo3}
        txtImportoAnnuale = {txtImportoAnnuale0, txtImportoAnnuale1, txtImportoAnnuale2, txtImportoAnnuale3}

        cmbTipoAttivita = {cmbTipoAttivita0, cmbTipoAttivita1}
        chkImpresaPubblica = {chkImpresaPubblica0, chkImpresaPubblica1}
        txtImpresaSettore = {txtImpresaSettore0, txtImpresaSettore1}
        cmbImpresaDimensione = {cmbImpresaDimensione0, cmbImpresaDimensione1}
        txtImpresaDenominazione = {txtImpresaDenominazione0, txtImpresaDenominazione1}
        txtImpresaInizio = {txtImpresaInizio0, txtImpresaInizio1}
        cmbAttivitaFase = {cmbAttivitaFase0, cmbAttivitaFase1}
        txtAtivitaImporto = {txtAtivitaImporto0, txtAtivitaImporto1}

        cmbCodSoddisfazione = {cmbCodSoddisfazione0, cmbCodSoddisfazione1, cmbCodSoddisfazione2, cmbCodSoddisfazione3, cmbCodSoddisfazione4, cmbCodSoddisfazione5}
        lblCodServizio = {lblCodServizio0, lblCodServizio1, lblCodServizio2, lblCodServizio3, lblCodServizio4, lblCodServizio5}

        cmbCodStrumento = {cmbCodStrumento0, cmbCodStrumento1, cmbCodStrumento2, cmbCodStrumento3, cmbCodStrumento4, cmbCodStrumento5, cmbCodStrumento6, cmbCodStrumento7}
        txtImporto = {txtImporto0, txtImporto1, txtImporto2, txtImporto3, txtImporto4, txtImporto5, txtImporto6, txtImporto7}
        txtBanca = {txtBanca0, txtBanca1, txtBanca2, txtBanca3, txtBanca4, txtBanca5, txtBanca6, txtBanca7}
        txtSim = {txtSim0, txtSim1, txtSim2, txtSim3, txtSim4, txtSim5, txtSim6, txtSim7}
        txtTipologia = {txtTipologia0, txtTipologia1, txtTipologia2, txtTipologia3, txtTipologia4, txtTipologia5, txtTipologia6, txtTipologia7}
        cmbCodEsperienza = {cmbCodEsperienza0, cmbCodEsperienza1, cmbCodEsperienza2, cmbCodEsperienza3, cmbCodEsperienza4, cmbCodEsperienza5, cmbCodEsperienza6, cmbCodEsperienza7}
        chkCoperturaPolizza = {chkCoperturaPolizza0, chkCoperturaPolizza1, chkCoperturaPolizza2, chkCoperturaPolizza3, chkCoperturaPolizza4, chkCoperturaPolizza5, chkCoperturaPolizza6, chkCoperturaPolizza7}

        cmbCodRelazione = {cmbCodRelazione0, cmbCodRelazione1, cmbCodRelazione2, cmbCodRelazione3, cmbCodRelazione4, cmbCodRelazione5, cmbCodRelazione6}
        txtNome = {txtNome0, txtNome1, txtNome2, txtNome3, txtNome4, txtNome5, txtNome6}
        txtEta = {txtEta0, txtEta1, txtEta2, txtEta3, txtEta4, txtEta5, txtEta6}
        txtCodiceFiscaleFamiliare = {txtCodiceFiscaleFamiliare0, txtCodiceFiscaleFamiliare1, txtCodiceFiscaleFamiliare2, txtCodiceFiscaleFamiliare3, txtCodiceFiscaleFamiliare4, txtCodiceFiscaleFamiliare5, txtCodiceFiscaleFamiliare6}
        chkConvivente = {chkConvivente0, chkConvivente1, chkConvivente2, chkConvivente3, chkConvivente4, chkConvivente5, chkConvivente6}
        txtAttivitaSvolta = {txtAttivitaSvolta0, txtAttivitaSvolta1, txtAttivitaSvolta2, txtAttivitaSvolta3, txtAttivitaSvolta4, txtAttivitaSvolta5, txtAttivitaSvolta6}
        txtAttivitaLuogo = {txtAttivitaLuogo0, txtAttivitaLuogo1, txtAttivitaLuogo2, txtAttivitaLuogo3, txtAttivitaLuogo4, txtAttivitaLuogo5, txtAttivitaLuogo6}
        txtAttivitaInizio = {txtAttivitaInizio0, txtAttivitaInizio1, txtAttivitaInizio2, txtAttivitaInizio3, txtAttivitaInizio4, txtAttivitaInizio5, txtAttivitaInizio6}
        txtRedditoAnnuo = {txtRedditoAnnuo0, txtRedditoAnnuo1, txtRedditoAnnuo2, txtRedditoAnnuo3, txtRedditoAnnuo4, txtRedditoAnnuo5, txtRedditoAnnuo6}

        'cmbCodRamo = {cmbCodRamo0, cmbCodRamo1, cmbCodRamo2, cmbCodRamo3, cmbCodRamo4, cmbCodRamo5, cmbCodRamo6}
        'txtPremio = {txtPremio0, txtPremio1, txtPremio2, txtPremio3, txtPremio4, txtPremio5, txtPremio6}

        txtSpesaImporto = {txtSpesaImporto0, txtSpesaImporto1, txtSpesaImporto2, txtSpesaImporto3, txtSpesaImporto4, txtSpesaImporto5}
        lblSpesaDescrizione = {lblSpesaDescrizione0, lblSpesaDescrizione1, lblSpesaDescrizione2, lblSpesaDescrizione3, lblSpesaDescrizione4, lblSpesaDescrizione5}
        lblSpesaDettaglio = {lblSpesaDettaglio0, lblSpesaDettaglio1, lblSpesaDettaglio2, lblSpesaDettaglio3, lblSpesaDettaglio4, lblSpesaDettaglio5}

        txtDesHobby = {txtDesHobby0, txtDesHobby1, txtDesHobby2, txtDesHobby3}
        txtFrequenza = {txtFrequenza0, txtFrequenza1, txtFrequenza2, txtFrequenza3}
        chkPericoloInfortuni = {chkPericoloInfortuni0, chkPericoloInfortuni1, chkPericoloInfortuni2, chkPericoloInfortuni3}
        chkPericoloMorte = {chkPericoloMorte0, chkPericoloMorte1, chkPericoloMorte2, chkPericoloMorte3}
        chkCoperturaHobby = {chkCoperturaHobby0, chkCoperturaHobby1, chkCoperturaHobby2, chkCoperturaHobby3}

        'cmbSezione = {cmbSezione0, cmbSezione1, cmbSezione2, cmbSezione3, cmbSezione4, cmbSezione5, cmbSezione6, cmbSezione7, cmbSezione8}
        'txtPolizza = {txtPolizza0, txtPolizza1, txtPolizza2, txtPolizza3, txtPolizza4, txtPolizza5, txtPolizza6, txtPolizza7, txtPolizza8}
        'txtCompagnia = {txtCompagnia0, txtCompagnia1, txtCompagnia2, txtCompagnia3, txtCompagnia4, txtCompagnia5, txtCompagnia6, txtCompagnia7, txtCompagnia8}
        'txtTarga = {txtTarga0, txtTarga1, txtTarga2, txtTarga3, txtTarga4, txtTarga5, txtTarga6, txtTarga7, txtTarga8}
        'txtMarca = {txtMarca0, txtMarca1, txtMarca2, txtMarca3, txtMarca4, txtMarca5, txtMarca6, txtMarca7, txtMarca8}
        'txtModello = {txtModello0, txtModello1, txtModello2, txtModello3, txtModello4, txtModello5, txtModello6, txtModello7, txtModello8}
        'txtDoc = {txtDoc0, txtDoc1, txtDoc2, txtDoc3, txtDoc4, txtDoc5, txtDoc6, txtDoc7, txtDoc8}
        'txtDataScadenza = {txtDataScadenza0, txtDataScadenza1, txtDataScadenza2, txtDataScadenza3, txtDataScadenza4, txtDataScadenza5, txtDataScadenza6, txtDataScadenza7, txtDataScadenza8}
        'txtDataDisdetta = {txtDataDisdetta0, txtDataDisdetta1, txtDataDisdetta2, txtDataDisdetta3, txtDataDisdetta4, txtDataDisdetta5, txtDataDisdetta6, txtDataDisdetta7, txtDataDisdetta8}
        'txtDataPreventivo = {txtDataPreventivo0, txtDataPreventivo1, txtDataPreventivo2, txtDataPreventivo3, txtDataPreventivo4, txtDataPreventivo5, txtDataPreventivo6, txtDataPreventivo7, txtDataPreventivo8}

        DataGridViewCellStyleValuta.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyleValuta.Format = "#,##0.00;#,##0.00; "
        DataGridViewCellStyleValuta.NullValue = Nothing

        DataGridViewCellStylePercento.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStylePercento.Format = "#,##0.00%;#,##0.00%; "
        DataGridViewCellStylePercento.NullValue = Nothing

        InizializzaControllo(buttonRisCellulare0, "send16", "invia sms")
        InizializzaControllo(buttonRisCellulare1, "send16", "invia sms")
        InizializzaControllo(buttonRisCellulare2, "send16", "invia sms")
        InizializzaControllo(buttonRisCellulare3, "send16", "invia sms")
        InizializzaControllo(buttonRisMail0, "send16", "invia e-mail")
        InizializzaControllo(buttonRisMail1, "send16", "invia e-mail")
        InizializzaControllo(buttonRisMail2, "send16", "invia e-mail")
        InizializzaControllo(buttonRisMail3, "send16", "invia e-mail")

        InizializzaControllo(cmdSalva, "disk", "salva")
        InizializzaControllo(cmdStampa, Nothing, "stampa")
        InizializzaControllo(cmdChiudi, "esci", "esci")
        cmdStampa.Image = Risorse.Immagini.Image("pdf")
    End Sub

    Public Sub InizializzaControllo(pulsante As Button,
                                Optional imagekey As String = Nothing,
                                Optional Tip As String = "")
        Dim p As New Utx.MyFlatButton
        With pulsante
            .Margin = p.Margin
            .FlatStyle = p.FlatStyle
            .FlatAppearance.BorderSize = p.FlatAppearance.BorderSize
            .FlatAppearance.BorderColor = p.FlatAppearance.BorderColor
            If imagekey IsNot Nothing Then
                .Image = Risorse.Immagini.Bitmap(imagekey)
            End If
        End With

        If Tip <> "" Then
            Dim tt As New ToolTip
            tt.SetToolTip(pulsante, Tip)
        End If
    End Sub

    Private Sub ObjectsToControls()
        Dim Index As Integer

        With mAnagrafica.Cliente
            txtClienteCodiceFiscale.Text = .CodiceFiscale
            txtClienteCognome.Text = .Cognome
            txtClienteNome.Text = .Nome
            cmbClienteSesso.SelectedValue = .Sesso

            txtClienteIndirizzo.Text = .Indirizzo
            txtClienteCap.Text = .Cap
            txtClienteLocalita.Text = .Localita
            txtClienteProvincia.Text = .Provincia

            RisCellulare3.Text = .Cellulare
            txtClienteTelefono.Text = .Telefono1
            RisMail3.Text = .Email

            'tclDataNascita = .DataNascita
            'tclComuneCAB = .ComuneCAB
            'tclStatoCAB = .StatoCAB

            'StringToTextBox txtCasaTel1, .Telefono1
            'StringToTextBox txtCasaTel2, .Telefono2

            'tclCapofamiglia = .Capofamiglia
            'tclCodiceFiscaleCF = .CodiceFiscaleCF
            'tclCodiceFiscaleEA = .CodiceFiscaleEA
            tclClienteTop.Text = .ClienteTop
            DateToLabel(tclDataTop, .DataTop)
            tclStatoCivile.Text = .StatoCivile
            'tclNucleoFamiliare = .NucleoFamiliare
            'tclPrimaCasa = .PrimaCasa
            'tclAltriImmobili = .AltriImmobili
            'tclTitoliStato = .TitoliStato
            'tclFasciaReddito = .FasciaReddito
            'tclSindacati = .Sindacati
            'tclPolizzeAltreComp = .PolizzeAltreComp
            'tclCartaCredito = .CartaCredito
            'tclEsclusioneAttivita = .EsclusioneAttivita
            'tclEnte = .Ente
            tclTipoCliente1.Text = .TipoCliente \ 100 'professione
            tclTipoCliente2.Text = .TipoCliente Mod 100 'mercato

            'tclIDSegmentoCorrente = .IDSegmentoCorrente
            'tclIDSegmentoPrecedente = .IDSegmentoPrecedente
            'tclIDStatoCliente = .IDStatoCliente
            'tclIDZona = .IDZona
            DateToLabel(tclDataInserimento, .DataInserimento)
            DateToLabel(tclDataCessazione, .DataCessazione)
            StringToLabel(tclAgenzia, .AgenziaPrevalente)
            StringToLabel(tclSubAgenzia, .SubAgenzia)
            StringToLabel(tclProduttore, .Produttore)
            'tclSubAgenziaSIMA = .SubAgenziaSIMA
            'tclDataUltimaVisita = .DataUltimaVisita
            'tclDataProssimaVisita = .DataProssimaVisita
            tclPolizzeVigore.Text = .PolizzeVigore
            tclPolizzeStoriche.Text = .PolizzeStoriche
            CurrencyToLabel(tclPremiCorrente, .PremiCorrente)
            CurrencyToLabel(tclLiquidatoCorrente, .LiquidatoCorrente)
            CurrencyToLabel(tclPremiPrecedente, .PremiPrecedente)
            CurrencyToLabel(tclLiquidatoPrecedente, .LiquidatoPrecedente)
            CurrencyToLabel(tclPremiTotale, .PremiTotale)
            CurrencyToLabel(tclLiquidatoTotale, .LiquidatoTotale)

            tclSinistriPrecedente.Text = .SinistriPrecedente
            tclSinistriCorrente.Text = .SinistriCorrente
            tclSinistriTotale.Text = .SinistriTotale

            tclConsensoPrivacy.Text = .ConsensoPrivacy
            'tclRilascioPatente = .RilascioPatente
            'StringToTextBox txtPersonaleEmail, .Email
            'StringToTextBox txtCasaFax, .Fax
            'StringToTextBox txtPersonaleCel, .Cellulare
            txtTelReferente.Text = .TelReferente
            'txtReferente.Text = .NomeReferente
            'StringToTextBox txtLavoroTel1, .TelAziendale
            'tclCodAvvisoScadenza = .CodAvvisoScadenza
            'tclAnnoMeseInizioEsclTemp = .AnnoMeseInizioEsclTemp
            'tclAnnoMeseFineEsclTemp = .AnnoMeseFineEsclTemp
            'tclCodModalitaIncasso = .CodModalitaIncasso
            'tclFlag1 = .Flag1
            'tclFlag2 = .Flag2
            'tclFlag3 = .Flag3
            'tclRisTelefono = .RisTelefono
            'tclRisCellulare = .RisCellulare
            'tclRisMail, .RisMail
            RisTelefono0.Text = .RisTelefono
            RisTelefonoNota0.Text = .RisTelefonoNota
            RisCellulare0.Text = .RisCellulare
            RisCellulareNota0.Text = .RisCellulareNota
            RisMail0.Text = .RisMail
            RisMailNota0.Text = .RisMailNota
        End With

        With mAnagrafica.Soggetto
            'StringToTextBox txtAgenzia, .Agenzia
            'StringToTextBox txtSubagenzia, .SubAgenzia
            'StringToTextBox txtProduttore, .Produttore
            'StringToTextBox txtCasaTel1, .CasaTel1
            'StringToTextBox txtCasaTel2, .CasaTel2
            'StringToTextBox txtCasaFax, .CasaFax
            'StringToTextBox txtPersonaleCel, .PersonaleCel
            'StringToTextBox txtPersonaleEmail, .PersonaleEmail

            StringToTextBox(RisMail1, .EmailIndirizzo1)
            StringToTextBox(EmailNota1, .EmailNota1)
            StringToTextBox(RisMail2, .EmailIndirizzo2)
            StringToTextBox(EmailNota2, .EmailNota2)

            StringToTextBox(TelNumero1, .TelNumero1)
            StringToTextBox(TelNota1, .TelNota1)
            StringToTextBox(RisCellulare1, .TelNumero2)
            StringToTextBox(TelNota2, .TelNota2)
            StringToTextBox(TelNumero3, .TelNumero3)
            StringToTextBox(TelNota3, .TelNota3)
            StringToTextBox(RisCellulare2, .TelNumero4)
            StringToTextBox(TelNota4, .TelNota4)

            StringToTextBox(txtVoip, .Voip)
            StringToTextBox(txtSocialNet, .SocialNet)
            StringToTextBox(txtSitoWeb, .SitoWeb)
            StringToTextBox(txtBancaIban, .BancaIban)
            StringToTextBox(txtBancaNome, .BancaNome)
            StringToTextBox(txtConvenzione, .Convenzione)
            StringToTextBox(txtCasaIndirizzo, .CasaIndirizzo)
            StringToTextBox(txtCasaLocalita, .CasaLocalita)
            StringToTextBox(txtCasaCap, .CasaCap)
            StringToTextBox(txtCasaProvincia, .CasaProvincia)
            StringToTextBox(txtLavoroIndirizzo, .LavoroIndirizzo)
            StringToTextBox(txtLavoroLocalita, .LavoroLocalita)
            StringToTextBox(txtLavoroCap, .LavoroCap)
            StringToTextBox(txtLavoroProvincia, .LavoroProvincia)
            StringToTextBox(txtAltroIndirizzo, .AltroIndirizzo)
            StringToTextBox(txtAltroLocalita, .AltroLocalita)
            StringToTextBox(txtAltroCap, .AltroCap)
            StringToTextBox(txtAltroProvincia, .AltroProvincia)
            StringToTextBox(txtAgenziaPrivacy, .AgenziaPrivacy)
            StringToTextBox(txtReferente, .Referente)
            StringToTextBox(txtNote, .Note)

            StringToComboBox(cmbCodStatoCivile, .CodStatoCivile)
            StringToComboBox(cmbCodPagamento, .CodPagamento)
            StringToComboBox(cmbCodProfiloRischio, .CodProfiloRischio)

            tclDocumentoTipo.Text = .DocumentoTipo
            tclDocumentoNumero.Text = .DocumentoNumero
            tclDocumentoAutorita.Text = .DocumentoAutorita
            tclDocumentoLuogo.Text = .DocumentoLuogo
            DateToLabel(tclDocumentoRilascio, .DocumentoRilascio)
            DateToLabel(tclDocumentoScadenza, .DocumentoScadenza)

            StringToTextBox(txtDestinatarioQualifica, .DestinatarioQualifica)
            StringToTextBox(txtDestinatarioNominativo, .DestinatarioNominativo)
            StringToTextBox(txtDestinatarioPresso, .DestinatarioPresso)
            StringToTextBox(txtDestinatarioIndirizzo, .DestinatarioIndirizzo)
            StringToTextBox(txtDestinatarioCap, .DestinatarioCap)
            StringToTextBox(txtDestinatarioLocalita, .DestinatarioLocalita)
            StringToTextBox(txtDestinatarioProvincia, .DestinatarioProvincia)
        End With

        For Index = 0 To mAnagrafica.Abitazioni.Count - 1
            With mAnagrafica.Abitazioni(Index)
                StringToComboBox(cmbCodAbitazione(Index), .CodAbitazione)
                LongToTextBox(txtmq(Index), .mq)
                CurrencyToTextBox(txtValoreCommerciale(Index), .ValoreCommerciale)
                BooleanToCheckbox(chkProprietario(Index), .Proprietario)
                BooleanToCheckbox(chkMutuo(Index), .Mutuo)
                CurrencyToTextBox(txtImportoAnnuale(Index), .ImportoAnnuale)
            End With
        Next

        For Index = 0 To mAnagrafica.Attivitas.Count - 1
            With mAnagrafica.Attivitas(Index)
                StringToComboBox(cmbTipoAttivita(Index), .TipoAttivita)
                BooleanToCheckbox(chkImpresaPubblica(Index), .ImpresaPubblica)
                StringToTextBox(txtImpresaSettore(Index), .ImpresaSettore)
                StringToComboBox(cmbImpresaDimensione(Index), .ImpresaDimensione)
                StringToTextBox(txtImpresaDenominazione(Index), .ImpresaDenominazione)
                DateToTextBox(txtImpresaInizio(Index), .ImpresaInizio)
                StringToComboBox(cmbAttivitaFase(Index), .AttivitaFase)
                CurrencyToTextBox(txtAtivitaImporto(Index), .AtivitaImporto)
            End With
        Next

        For Index = 0 To mAnagrafica.Finanzacose.Count - 1
            With mAnagrafica.Finanzacose(Index)
                lblCodServizio(Index).Text = .DesServizio
                StringToComboBox(cmbCodSoddisfazione(Index), .CodSoddisfazione)
            End With
        Next

        For Index = 0 To mAnagrafica.Finanzastrumenti.Count - 1
            With mAnagrafica.Finanzastrumenti(Index)
                StringToComboBox(cmbCodStrumento(Index), .CodStrumento)
                CurrencyToTextBox(txtImporto(Index), .Importo)
                StringToTextBox(txtBanca(Index), .Banca)
                StringToTextBox(txtSim(Index), .Sim)
                StringToTextBox(txtTipologia(Index), .Tipologia)
                StringToComboBox(cmbCodEsperienza(Index), .CodEsperienza)
                BooleanToCheckbox(chkCoperturaPolizza(Index), .CoperturaPolizza)
            End With
        Next

        For Index = 0 To mAnagrafica.Nucleofamiliari.Count - 1
            With mAnagrafica.Nucleofamiliari(Index)
                StringToComboBox(cmbCodRelazione(Index), .CodRelazione)
                StringToTextBox(txtCodiceFiscaleFamiliare(Index), .CodiceFiscaleFamiliare)
                StringToTextBox(txtNome(Index), .Nome)
                LongToTextBox(txtEta(Index), .Eta)
                BooleanToCheckbox(chkConvivente(Index), .Convivente)
                StringToTextBox(txtAttivitaSvolta(Index), .AttivitaSvolta)
                StringToTextBox(txtAttivitaLuogo(Index), .AttivitaLuogo)
                DateToTextBox(txtAttivitaInizio(Index), .AttivitaInizio)
                CurrencyToTextBox(txtRedditoAnnuo(Index), .RedditoAnnuo)
            End With
        Next

        For Index = 0 To mAnagrafica.Spesapiani.Count - 1
            With mAnagrafica.Spesapiani(Index)
                CurrencyToTextBox(txtSpesaImporto(Index), .SpesaImporto)
                lblSpesaDescrizione(Index).Text = .Descrizione
                lblSpesaDettaglio(Index).Text = .Dettaglio
            End With
        Next

        For Index = 0 To mAnagrafica.Hobbies.Count - 1
            With mAnagrafica.Hobbies(Index)
                StringToTextBox(txtDesHobby(Index), .DesHobby)
                StringToTextBox(txtFrequenza(Index), .Frequenza)
                BooleanToCheckbox(chkPericoloInfortuni(Index), .PericoloInfortuni)
                BooleanToCheckbox(chkPericoloMorte(Index), .PericoloMorte)
                BooleanToCheckbox(chkCoperturaHobby(Index), .CoperturaHobby)
            End With
        Next

        'ANALISI RCA
        Me.PremioOld.DefaultCellStyle = DataGridViewCellStyleValuta
        Me.PremioNew.DefaultCellStyle = DataGridViewCellStyleValuta
        Me.PremioDif.DefaultCellStyle = DataGridViewCellStyleValuta
        Me.FlexIncendioFurto.DefaultCellStyle = DataGridViewCellStylePercento

        With grdAnaliRca
            .RowTemplate.Height = 22
            .AutoGenerateColumns = False
            .DataSource = mAnagrafica.AnalisiRca
        End With

        'POLIZZE NOSTRE
        With grdPolizzeNostre
            .RowTemplate.Height = 21
            .AutoGenerateColumns = False
            .DataSource = mAnagrafica.PolizzeNostre
        End With

        'POLIZZE ALTRUI
        With grdPolizzeAltrui
            .RowTemplate.Height = 21
            .AutoGenerateColumns = False
            .DataSource = mAnagrafica.PolizzeAltrui
        End With

        'FASI DI VENDITA
        With grdFasiVendita
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersHeight = 42
            .RowTemplate.Height = 39
            .AutoGenerateColumns = False
            .DataSource = mAnagrafica.FasiVendita
        End With

        'OPZIONI
        With grdOpzioni
            .AutoGenerateColumns = False
            .DataSource = mAnagrafica.Opzioni
        End With

        'Solo Lettura
        With mAnagrafica.Cliente
            If .IsNew Then
                lblBarCliente.Text = "Cliente non trovato in anagrafica (" & .CodiceFiscale & ")"
                lblBarClienteIndirizzo.Text = ""
            Else
                lblBarCliente.Text = Trim(.Cognome & " " & .Nome) & " (" & .CodiceFiscale & ")"
                lblBarClienteIndirizzo.Text = Trim(Trim(.Indirizzo) & " - " & Trim(.Cap) & " - " & Trim(.Localita) & " - " & .Provincia)
            End If
            txtClienteCodiceFiscale.Enabled = .IsNew
            txtClienteCognome.Enabled = .IsNew
            txtClienteNome.Enabled = .IsNew
            cmbClienteSesso.Enabled = .IsNew

            txtClienteIndirizzo.Enabled = .IsNew
            txtClienteCap.Enabled = .IsNew
            txtClienteLocalita.Enabled = .IsNew
            txtClienteProvincia.Enabled = .IsNew

            RisCellulare3.Enabled = .IsNew
            txtClienteTelefono.Enabled = .IsNew
            RisMail3.Enabled = .IsNew
        End With

        ' ARRETRATI
        With New TString
            .Add(String.Format("SELECT Cognome + ' ' + Nome As Nominativo, Prodotto, Ramo, Polizza, Targa, Modello, EffettoTitolo, TotaleTitolo
                FROM ARRETRATI WHERE CodiceFiscale IN ({0})
                ORDER BY CodiceFiscale, EffettoTitolo", mAnagrafica.ElencoCodiciFiscaliFamiglia))
            grdArretrati.DataSource = Utx.WsCommand.ExecuteNonQuery(.ToString).DataTable
        End With

        ' SCADENZE (EVIDENZE)
        With New TString
            .Add(String.Format("SELECT C.Cognome + ' ' + C.Nome As Nominativo, E.DesEvidenza as Evidenza, P.Messaggio, 
                IIF(E.DataRiferimento IS NOT NULL, E.DataRiferimento, E.DataApertura) as Data
                FROM Unidocs_Evidenza E
                INNER JOIN Clienti AS C ON C.CodiceFiscale = E.CodiceFiscale
                LEFT JOIN Unidocs_Promemoria AS P ON E.IdEvidenza = P.IdEvidenza
                WHERE E.CodiceFiscale IN ({0})
                ORDER BY E.CodiceFiscale, E.DataApertura", mAnagrafica.ElencoCodiciFiscaliFamiglia))
            grdScadenze.DataSource = Utx.WsCommand.ExecuteNonQuery(.ToString).DataTable
        End With

        'DIARIO
        With New TString
            .Add(String.Format("SELECT Descrizione, Utente, DataInserimento
                FROM Ana_diario WHERE CodiceFiscale IN ({0})
                ORDER BY CodiceFiscale, Progressivo", mAnagrafica.ElencoCodiciFiscaliFamiglia))
            grdDiario.DataSource = Utx.WsCommand.ExecuteNonQuery(.ToString).DataTable
        End With
    End Sub

    Private Function ControlsToObjects() As Boolean
        Dim Index As Integer

        If mTextBoxErrors.Count > 0 Or mCellBoxErrors.Count > 0 Then
            'MsgBox("Correggere tutti gli errori presenti nella scheda", MsgBoxStyle.Exclamation)
            Return False
        End If

        With mAnagrafica.Cliente
            If .IsNew() Then
                .CodiceFiscale = txtClienteCodiceFiscale.Text
                .Cognome = txtClienteCognome.Text
                .Nome = txtClienteNome.Text
                .Sesso = cmbClienteSesso.SelectedValue

                .Indirizzo = txtClienteIndirizzo.Text
                If IsNumeric(txtClienteCap.Text) Then
                    .Cap = txtClienteCap.Text
                End If
                .Localita = txtClienteLocalita.Text
                .Provincia = txtClienteProvincia.Text

                .Cellulare = RisCellulare3.Text
                .Telefono1 = txtClienteTelefono.Text
                .Email = RisMail3.Text

                .TelReferente = TextBoxToString(txtTelReferente)
            End If

            .RisTelefono = TextBoxToString(RisTelefono0)
            .RisTelefonoNota = TextBoxToString(RisTelefonoNota0)
            .RisCellulare = TextBoxToString(RisCellulare0)
            .RisCellulareNota = TextBoxToString(RisCellulareNota0)
            .RisMail = TextBoxToString(RisMail0)
            .RisMailNota = TextBoxToString(RisMailNota0)
        End With

        With mAnagrafica.Soggetto
            '.Agenzia = TextBoxToString(txtAgenzia)
            '.SubAgenzia = TextBoxToString(txtSubagenzia)
            '.Produttore = TextBoxToString(txtProduttore)
            '.CasaTel1 = TextBoxToString(txtCasaTel1)
            '.CasaTel2 = TextBoxToString(txtCasaTel2)
            '.CasaFax = TextBoxToString(txtCasaFax)
            '.PersonaleCel = TextBoxToString(txtPersonaleCel)
            '.PersonaleEmail = TextBoxToString(txtPersonaleEmail)
            '.LavoroTel1 = TextBoxToString(txtLavoroTel1)
            '.LavoroTel2 = TextBoxToString(txtLavoroTel2)
            '.LavoroCel = TextBoxToString(txtLavoroCel)
            '.LavoroFax = TextBoxToString(txtLavoroFax)
            '.LavoroEmail = TextBoxToString(txtLavoroEmail)
            '.Pec = TextBoxToString(txtPec)
            '.Email = TextBoxToString(txtEmail)
            .Voip = TextBoxToString(txtVoip)
            .SocialNet = TextBoxToString(txtSocialNet)
            .SitoWeb = TextBoxToString(txtSitoWeb)
            .BancaIban = TextBoxToString(txtBancaIban)
            .BancaNome = TextBoxToString(txtBancaNome)
            .Convenzione = TextBoxToString(txtConvenzione)
            .CasaIndirizzo = TextBoxToString(txtCasaIndirizzo)
            .CasaLocalita = TextBoxToString(txtCasaLocalita)
            .CasaCap = TextBoxToString(txtCasaCap)
            .CasaProvincia = TextBoxToString(txtCasaProvincia)
            .LavoroIndirizzo = TextBoxToString(txtLavoroIndirizzo)
            .LavoroLocalita = TextBoxToString(txtLavoroLocalita)
            .LavoroCap = TextBoxToString(txtLavoroCap)
            .LavoroProvincia = TextBoxToString(txtLavoroProvincia)
            .AgenziaPrivacy = TextBoxToString(txtAgenziaPrivacy)
            .Referente = TextBoxToString(txtReferente)

            .EmailIndirizzo1 = TextBoxToString(RisMail1)
            .EmailNota1 = TextBoxToString(EmailNota1)
            .EmailIndirizzo2 = TextBoxToString(RisMail2)
            .EmailNota2 = TextBoxToString(EmailNota2)
            .TelNumero1 = TextBoxToString(TelNumero1)
            .TelNota1 = TextBoxToString(TelNota1)
            .TelNumero2 = TextBoxToString(RisCellulare1)
            .TelNota2 = TextBoxToString(TelNota2)
            .TelNumero3 = TextBoxToString(TelNumero3)
            .TelNota3 = TextBoxToString(TelNota3)
            .TelNumero4 = TextBoxToString(RisCellulare2)
            .TelNota4 = TextBoxToString(TelNota4)

            .Note = TextBoxToString(txtNote)
            .CodStatoCivile = ComboBoxToString(cmbCodStatoCivile)
            .CodPagamento = ComboBoxToString(cmbCodPagamento)
            .CodProfiloRischio = ComboBoxToString(cmbCodProfiloRischio)

            .DestinatarioQualifica = TextBoxToString(txtDestinatarioQualifica)
            .DestinatarioNominativo = TextBoxToString(txtDestinatarioNominativo)
            .DestinatarioPresso = TextBoxToString(txtDestinatarioPresso)
            .DestinatarioIndirizzo = TextBoxToString(txtDestinatarioIndirizzo)
            .DestinatarioCap = TextBoxToString(txtDestinatarioCap)
            .DestinatarioLocalita = TextBoxToString(txtDestinatarioLocalita)
            .DestinatarioProvincia = TextBoxToString(txtDestinatarioProvincia)
        End With

        For Index = 0 To mAnagrafica.Abitazioni.Count - 1
            With mAnagrafica.Abitazioni(Index)
                .CodAbitazione = ComboBoxToString(cmbCodAbitazione(Index))
                .mq = TextBoxToLong(txtmq(Index))
                .ValoreCommerciale = TextBoxToCurrency(txtValoreCommerciale(Index))
                .Proprietario = CheckboxToBoolean(chkProprietario(Index))
                .Mutuo = CheckboxToBoolean(chkMutuo(Index))
                .ImportoAnnuale = TextBoxToCurrency(txtImportoAnnuale(Index))
            End With
        Next

        For Index = 0 To mAnagrafica.Attivitas.Count - 1
            With mAnagrafica.Attivitas(Index)
                .TipoAttivita = ComboBoxToString(cmbTipoAttivita(Index))
                .ImpresaPubblica = CheckboxToBoolean(chkImpresaPubblica(Index))
                .ImpresaSettore = TextBoxToString(txtImpresaSettore(Index))
                .ImpresaDimensione = ComboBoxToString(cmbImpresaDimensione(Index))
                .ImpresaDenominazione = TextBoxToString(txtImpresaDenominazione(Index))
                .ImpresaInizio = TextBoxToDate(txtImpresaInizio(Index))
                .AttivitaFase = ComboBoxToString(cmbAttivitaFase(Index))
                .AtivitaImporto = TextBoxToCurrency(txtAtivitaImporto(Index))
            End With
        Next

        For Index = 0 To mAnagrafica.Finanzacose.Count - 1
            With mAnagrafica.Finanzacose(Index)
                .CodSoddisfazione = ComboBoxToString(cmbCodSoddisfazione(Index))
            End With
        Next

        For Index = 0 To mAnagrafica.Finanzastrumenti.Count - 1
            With mAnagrafica.Finanzastrumenti(Index)
                .CodStrumento = ComboBoxToString(cmbCodStrumento(Index))
                .Importo = TextBoxToCurrency(txtImporto(Index))
                .Banca = TextBoxToString(txtBanca(Index))
                .Sim = TextBoxToString(txtSim(Index))
                .Tipologia = TextBoxToString(txtTipologia(Index))
                .CodEsperienza = ComboBoxToString(cmbCodEsperienza(Index))
                .CoperturaPolizza = CheckboxToBoolean(chkCoperturaPolizza(Index))
            End With
        Next

        For Index = 0 To mAnagrafica.Nucleofamiliari.Count - 1
            With mAnagrafica.Nucleofamiliari(Index)
                .CodRelazione = ComboBoxToString(cmbCodRelazione(Index))
                .CodiceFiscaleFamiliare = TextBoxToString(txtCodiceFiscaleFamiliare(Index))
                .Nome = TextBoxToString(txtNome(Index))
                .Eta = TextBoxToLong(txtEta(Index))
                .Convivente = CheckboxToBoolean(chkConvivente(Index))
                .AttivitaSvolta = TextBoxToString(txtAttivitaSvolta(Index))
                .AttivitaLuogo = TextBoxToString(txtAttivitaLuogo(Index))
                .AttivitaInizio = TextBoxToDate(txtAttivitaInizio(Index))
                .RedditoAnnuo = TextBoxToCurrency(txtRedditoAnnuo(Index))
            End With
        Next

        'For Index = 0 To mAnagrafica.PolizzeAltreCompagnie.Count - 1
        '    With mAnagrafica.PolizzeAltreCompagnie(Index)
        '        .Sezione = ComboBoxToString(cmbSezione(Index))
        '        .Polizza = TextBoxToString(txtPolizza(Index))
        '        .Targa = TextBoxToString(txtTarga(Index))
        '        .Marca = TextBoxToString(txtMarca(Index))
        '        .Modello = TextBoxToString(txtModello(Index))
        '        .Doc = TextBoxToString(txtDoc(Index))
        '        .DataScadenza = TextBoxToString(txtDataScadenza(Index))
        '        .DataDisdetta = TextBoxToString(txtDataDisdetta(Index))
        '        .DataPreventivo = TextBoxToString(txtDataPreventivo(Index))
        '        '.CodRamo = ComboBoxToString(cmbCodRamo(Index))
        '        '.PremioNew = TextBoxToCurrency(txtPremio(Index))
        '    End With
        'Next

        For Index = 0 To mAnagrafica.Spesapiani.Count - 1
            With mAnagrafica.Spesapiani(Index)
                .SpesaImporto = TextBoxToCurrency(txtSpesaImporto(Index))
            End With
        Next

        For Index = 0 To mAnagrafica.Hobbies.Count - 1
            With mAnagrafica.Hobbies(Index)
                .DesHobby = TextBoxToString(txtDesHobby(Index))
                .Frequenza = TextBoxToString(txtFrequenza(Index))
                .PericoloInfortuni = CheckboxToBoolean(chkPericoloInfortuni(Index))
                .PericoloMorte = CheckboxToBoolean(chkPericoloMorte(Index))
                .CoperturaHobby = CheckboxToBoolean(chkCoperturaHobby(Index))
            End With
        Next

        Return True
    End Function

    Private Sub frmAnag_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            lblError.Text = ""

            ComboBoxLoad(cmbCodAbitazione, "SELECT * FROM Ana_AbitazioneTipo")
            ComboBoxLoad(cmbTipoAttivita, "SELECT TipoAttivita, DesAttivita FROM Ana_AttivitaTipo")
            ComboBoxLoad(cmbImpresaDimensione, "SELECT * FROM Ana_AttivitaDimensione")
            ComboBoxLoad(cmbAttivitaFase, "SELECT * FROM Ana_AttivitaFase")
            ComboBoxLoad(cmbCodSoddisfazione, "SELECT * FROM Ana_FinanzaCoseSoddisfazione")
            ComboBoxLoad(cmbCodStrumento, "SELECT * FROM Ana_FinanzaStrumentoTipo")
            ComboBoxLoad(cmbCodEsperienza, "SELECT * FROM Ana_FinanzaStrumentoEsperienza")
            ComboBoxLoad(cmbCodRelazione, "SELECT * FROM Ana_NucleoFamiliareRelazione")
            'ComboBoxLoad(cmbCodRamo, "SELECT * FROM Ana_PolizzaRamo")
            ComboBoxLoad(cmbCodStatoCivile, "SELECT * FROM Ana_SoggettoStatoCivile")
            ComboBoxLoad(cmbCodPagamento, "SELECT * FROM Ana_SoggettoPagamento")
            ComboBoxLoad(cmbCodProfiloRischio, "SELECT * FROM Ana_SoggettoProfiloRischio")
            ComboBoxLoad(cmbClienteSesso, "SELECT codice, idioma FROM Ana_PianoCodici WHERE Tipologia = 'U' Order By Ordine")
            'ComboBoxLoad(cmbSezione, "SELECT codice, idioma FROM Ana_PianoCodici WHERE Tipologia = 'A' Order By Ordine")

            ComboBoxLoad(Unibox, "SELECT codice, idioma FROM Ana_PianoCodici WHERE Tipologia = 'C' Order By Ordine")
            ComboBoxLoad(GuidaEsperta, "SELECT codice, idioma FROM Ana_PianoCodici WHERE Tipologia = 'C' Order By Ordine")
            ComboBoxLoad(Finanziamento, "SELECT codice, idioma FROM Ana_PianoCodici WHERE Tipologia = 'C' Order By Ordine")
            ComboBoxLoad(Riparazione, "SELECT codice, idioma FROM Ana_PianoCodici WHERE Tipologia = 'C' Order By Ordine")

            ComboBoxLoad(SituazioneSezione, "SELECT codice, idioma FROM Ana_PianoCodici WHERE Tipologia = 'A' Order By Ordine")
            ObjectsToControls()
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub SelezionaCliente(CodiceFiscale As String)
        mAnagrafica.Load(CodiceFiscale)
    End Sub

    Private Sub cmdSalva_Click(sender As System.Object, e As System.EventArgs) Handles cmdSalva.Click
        If ControlsToObjects() Then
            If mAnagrafica.Save Then
                Close()
            End If
        Else
            MsgBox("Correggere tutti gli errori presenti nella scheda", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub cmdChiudi_Click(sender As System.Object, e As System.EventArgs) Handles cmdChiudi.Click
        If ControlsToObjects() Then
            If mAnagrafica.IsModifiedState Then
                Select Case MsgBox("Salvare le modifiche?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNoCancel)
                    Case MsgBoxResult.Yes
                        If mAnagrafica.Save Then
                            Close()
                        End If
                    Case MsgBoxResult.No
                        Close()
                End Select
            Else
                Close()
            End If
        ElseIf MsgBox("Sono presenti degli errori. Vuoi uscire lo stesso?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub


    Private Sub grdDiario_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles grdDiario.Paint
        Dim sndr As DataGridView = sender

        If sndr.Rows.Count = 0 Then
            Using grfx As Graphics = e.Graphics
                'create a white rectangle so text will be easily readable
                'grfx.FillRectangle(Brushes.White, New Rectangle(New Point(), New Size(sndr.Width, sndr.Height)))
                'write text on top of the white rectangle just created
                'grfx.DrawString("No data returned", New Font("Arial", 12), Brushes.LightGray, New PointF((sndr.Width) / 2, sndr.Height / 2))

                ' Set up string.
                Dim messaggio As String = "Nessun dato"
                Dim stringFont As New Font("Arial", 20, FontStyle.Bold)

                ' Measure string.
                Dim stringSize As SizeF = grfx.MeasureString(messaggio, stringFont)

                ' Draw string to screen.
                grfx.DrawString(messaggio, stringFont, Brushes.LightGray, New PointF((sndr.Width - stringSize.Width) / 2, (sndr.Height - stringSize.Height) / 2))

            End Using
        End If

    End Sub

    Private Sub cmdStampa_Click(sender As System.Object, e As System.EventArgs) Handles cmdStampa.Click
        If ControlsToObjects() Then
            Dim Options As StampaOptions = StampaOptions.MostraAnteprima _
                                           + chkCopertina.Checked * chkCopertinaA3.Checked * StampaOptions.StampaA3 _
                                           + chkCopertina.Checked * chkCopertinaCliente.Checked * StampaOptions.StampaCliente _
                                           + chkCopertina.Checked * chkCopertinaSituazione.Checked * StampaOptions.StampaSituazione _
                                           + chkCopertina.Checked * chkCopertinaNote.Checked * StampaOptions.StampaNote _
                                           + chkCopertina.Checked * chkCopertinaFasiVendita.Checked * StampaOptions.StampaFasiVendita _
                                           + chkCopertina.Checked * chkCopertinaAnalisiRca.Checked * StampaOptions.StampaAnalisiRca
            Dim stampa As New Copertina
            stampa.StampaMostraEtInvia(mAnagrafica, Options)
        Else
            MsgBox("Correggere tutti gli errori presenti nella scheda", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub chkCopertina_CheckedChanged(sender As System.Object, e As System.EventArgs)
        chkCopertinaCliente.Enabled = chkCopertina.Checked
        chkCopertinaSituazione.Enabled = chkCopertina.Checked
        chkCopertinaNote.Enabled = chkCopertina.Checked
        chkCopertinaFasiVendita.Enabled = chkCopertina.Checked
        chkCopertinaAnalisiRca.Enabled = chkCopertina.Checked
        chkCopertinaA3.Enabled = chkCopertina.Checked
    End Sub


    Private Sub grdPolizzeAltrui_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdPolizzeAltrui.CellContentClick

        If e.ColumnIndex = 13 Then
            With mAnagrafica.PolizzeAltrui(e.RowIndex)
                If .DataScadenza > Date.MinValue Or .DataDisdetta > Date.MinValue Then
                    If .DataPromemoria = Date.MinValue Then
                        Dim evidenza As New TEvidenza
                        evidenza.CodCompagnia = 0
                        evidenza.CodPuntoVendita = mAnagrafica.Cliente.AgenziaPrevalente
                        evidenza.DesEvidenza = mAnagrafica.Opzioni(1).Valore
                        evidenza.IdOggetto = "~" & .CodiceFiscale
                        'evidenza.DesNote = ""
                        evidenza.CodGravita = GravitaEvidenza.Normale
                        evidenza.CodTipoEvidenza = TipoEvidenza.Generica
                        evidenza.CodTipoOggetto = TipoOggetto.Cliente
                        evidenza.DataApertura = Today
                        evidenza.DataChiusura = #12/31/9999#
                        evidenza.CodiceFiscale = .CodiceFiscale
                        evidenza.CodiceSubAgente = mAnagrafica.Cliente.SubAgenzia

                        If .DataDisdetta > Date.MinValue Then
                            evidenza.DataRiferimento = .DataDisdetta.AddDays(-mAnagrafica.Opzioni(0).DoubleValore)
                        Else
                            evidenza.DataRiferimento = .DataScadenza.AddDays(-mAnagrafica.Opzioni(0).DoubleValore)
                        End If

                        If evidenza.DataRiferimento < Today Then
                            evidenza.DataRiferimento = Today
                        End If

                        mAnagrafica.Evidenze.Add(evidenza)
                        .DataPromemoria = evidenza.DataRiferimento
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub txtCurrencyTextChanged(sender As System.Object, e As System.EventArgs)
        ValidaCurrency(sender)
    End Sub
    Private Sub txtNumeroTextChanged(sender As System.Object, e As System.EventArgs)
        ValidaNumero(sender)
    End Sub
    Private Sub txtDateTextChanged(sender As System.Object, e As System.EventArgs)
        ValidaDate(sender)
    End Sub
    Private Sub txtEmailTextChanged(sender As System.Object, e As System.EventArgs)
        ValidaEmail(sender)
    End Sub
    Private Sub txtCellulareTextChanged(sender As System.Object, e As System.EventArgs)
        ValidaCellulare(sender)
    End Sub
    Private Sub txtCodiceFiscaleTextChanged(sender As System.Object, e As System.EventArgs)
        ValidaCodiceFiscale(sender)
    End Sub

    Public Function ValidaString(txt As TextBox) As Boolean
        Return ValidaNotifica(txt, True, "ok")
    End Function

    Public Function ValidaCurrency(txt As TextBox) As Boolean
        Dim valore As String = Trim(txt.Text)
        Dim IsValido As Boolean = IsNumeric(valore) Or (valore = vbNullString)
        Return ValidaNotifica(txt, IsValido, "Importo non valido")
    End Function

    Public Function ValidaNumero(txt As TextBox) As Boolean
        Dim valore As String = Trim(txt.Text)
        Return ValidaNotifica(txt, IsNumeric(valore) Or (valore = vbNullString), "Numero non valido")
    End Function

    Public Function ValidaDate(txt As TextBox) As Boolean
        Dim Data As String = Trim(txt.Text)

        If (IsNumeric(Data) And (Len(Data) = 8)) Then
            Data = Data.Substring(0, 2) & "/" & Data.Substring(2, 2) & "/" & Data.Substring(4)
            txt.Text = Data
        End If

        Dim IsValido As Boolean = (IsDate(Data) And (Len(Data) = 10)) Or (Data = vbNullString)
        Return ValidaNotifica(txt, IsValido, "Data non valida (gg/mm/aaaa)")
    End Function

    Public Function ValidaEmail(txt As TextBox) As Boolean
        Dim IsValido As Boolean
        Dim Email As String
        Dim i As Integer
        Dim j As Integer

        IsValido = True

        Email = Trim(txt.Text)
        If Email <> vbNullString Then
            i = InStr(1, Email, "@")
            If i = 0 Or i = 1 Or i = Len(Email) Then
                IsValido = False
            Else
                j = InStrRev(Email, ".")
                If j = 0 Or j = Len(Email) Or j <= 1 + i Then
                    IsValido = False
                End If
            End If
        End If

        Return ValidaNotifica(txt, IsValido, "Indirizzo Email non valido")
    End Function

    Public Function ValidaCellulare(txt As TextBox) As Boolean
        Dim Cellulare As String = txt.Text.Trim
        Return ValidaNotifica(txt, True, "Numero Cellulare non valido")
    End Function

    Public Function ValidaCodiceFiscale(txt As TextBox) As Boolean
        Return ValidaNotifica(txt, True, "Codice fiscale non valido non valido")
    End Function

    Public Function ValidaNotifica(txt As TextBox, IsValido As Boolean, Caption As String) As Boolean
        If IsValido Then
            txt.ForeColor = SystemColors.WindowText

            If mTextBoxErrors.ContainsKey(txt) Then
                mTextBoxErrors.Remove(txt)
            End If
            ErrorProvider1.SetError(txt, vbNullString)
        Else
            txt.ForeColor = Color.Red

            If Not mTextBoxErrors.ContainsKey(txt) Then
                mTextBoxErrors.Add(txt, Caption)
            End If
        End If

        If mTextBoxErrors.Count = 0 Then
            imgError.Visible = False
            lblError.Visible = False
        Else
            If IsValido Then
                For Each s As String In mTextBoxErrors.Values
                    lblError.Text = s
                Next
            Else
                lblError.Text = Caption
                ErrorProvider1.SetError(txt, Caption)
            End If

            imgError.Visible = True
            lblError.Visible = True
        End If

        Return IsValido
    End Function

    Private Sub AddChangeEvents()
        'AddHandler txtAgenziaPrivacy.TextChanged, AddressOf Me.txtStringTextChanged
        AddHandler txtAtivitaImporto0.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtAtivitaImporto1.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtAttivitaInizio0.TextChanged, AddressOf Me.txtDateTextChanged
        AddHandler txtAttivitaInizio1.TextChanged, AddressOf Me.txtDateTextChanged
        AddHandler txtAttivitaInizio2.TextChanged, AddressOf Me.txtDateTextChanged
        AddHandler txtAttivitaInizio3.TextChanged, AddressOf Me.txtDateTextChanged
        AddHandler txtAttivitaInizio4.TextChanged, AddressOf Me.txtDateTextChanged
        AddHandler txtAttivitaInizio5.TextChanged, AddressOf Me.txtDateTextChanged
        AddHandler txtAttivitaInizio6.TextChanged, AddressOf Me.txtDateTextChanged
        'AddHandler txtAttivitaLuogo0.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtAttivitaLuogo1.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtAttivitaLuogo2.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtAttivitaLuogo3.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtAttivitaLuogo4.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtAttivitaLuogo5.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtAttivitaLuogo6.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtAttivitaSvolta0.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtAttivitaSvolta1.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtAttivitaSvolta2.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtAttivitaSvolta3.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtAttivitaSvolta4.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtAttivitaSvolta5.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtAttivitaSvolta6.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtBanca0.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtBanca1.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtBanca2.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtBanca3.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtBanca4.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtBanca5.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtBanca6.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtBanca7.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtBancaIban.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtBancaNome.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtCasaCap.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtCasaIndirizzo.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtCasaLocalita.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtCasaProvincia.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtClienteCap.TextChanged, AddressOf Me.txtStringTextChanged
        AddHandler txtClienteCodiceFiscale.TextChanged, AddressOf Me.txtCodiceFiscaleTextChanged
        'AddHandler txtClienteCognome.TextChanged, AddressOf Me.txtStringTextChanged

        AddHandler txtClienteTelefono.TextChanged, AddressOf Me.txtCellulareTextChanged
        AddHandler RisCellulare3.TextChanged, AddressOf Me.txtCellulareTextChanged
        AddHandler RisTelefono0.TextChanged, AddressOf Me.txtCellulareTextChanged
        AddHandler RisCellulare0.TextChanged, AddressOf Me.txtCellulareTextChanged
        AddHandler TelNumero1.TextChanged, AddressOf Me.txtCellulareTextChanged
        AddHandler RisCellulare1.TextChanged, AddressOf Me.txtCellulareTextChanged
        AddHandler TelNumero3.TextChanged, AddressOf Me.txtCellulareTextChanged
        AddHandler RisCellulare2.TextChanged, AddressOf Me.txtCellulareTextChanged

        AddHandler RisMail3.TextChanged, AddressOf Me.txtEmailTextChanged
        AddHandler RisMail0.TextChanged, AddressOf Me.txtEmailTextChanged
        AddHandler RisMail1.TextChanged, AddressOf Me.txtEmailTextChanged
        AddHandler RisMail2.TextChanged, AddressOf Me.txtEmailTextChanged

        'AddHandler txtClienteIndirizzo.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtClienteLocalita.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtClienteNome.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtClienteProvincia.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtClienteTelefono.TextChanged, AddressOf Me.txtStringTextChanged
        AddHandler txtCodiceFiscaleFamiliare0.TextChanged, AddressOf Me.txtCodiceFiscaleTextChanged
        AddHandler txtCodiceFiscaleFamiliare1.TextChanged, AddressOf Me.txtCodiceFiscaleTextChanged
        AddHandler txtCodiceFiscaleFamiliare2.TextChanged, AddressOf Me.txtCodiceFiscaleTextChanged
        AddHandler txtCodiceFiscaleFamiliare3.TextChanged, AddressOf Me.txtCodiceFiscaleTextChanged
        AddHandler txtCodiceFiscaleFamiliare4.TextChanged, AddressOf Me.txtCodiceFiscaleTextChanged
        AddHandler txtCodiceFiscaleFamiliare5.TextChanged, AddressOf Me.txtCodiceFiscaleTextChanged
        AddHandler txtCodiceFiscaleFamiliare6.TextChanged, AddressOf Me.txtCodiceFiscaleTextChanged
        'AddHandler txtConvenzione.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtDesHobby0.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtDesHobby1.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtDesHobby2.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtDesHobby3.TextChanged, AddressOf Me.txtStringTextChanged
        AddHandler txtEta0.TextChanged, AddressOf Me.txtNumeroTextChanged
        AddHandler txtEta1.TextChanged, AddressOf Me.txtNumeroTextChanged
        AddHandler txtEta2.TextChanged, AddressOf Me.txtNumeroTextChanged
        AddHandler txtEta3.TextChanged, AddressOf Me.txtNumeroTextChanged
        AddHandler txtEta4.TextChanged, AddressOf Me.txtNumeroTextChanged
        AddHandler txtEta5.TextChanged, AddressOf Me.txtNumeroTextChanged
        AddHandler txtEta6.TextChanged, AddressOf Me.txtNumeroTextChanged
        'AddHandler txtFrequenza0.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtFrequenza1.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtFrequenza2.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtFrequenza3.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtImporto0.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtImporto1.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtImporto2.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtImporto3.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtImporto4.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtImporto5.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtImporto6.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtImporto7.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtImportoAnnuale0.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtImportoAnnuale1.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtImportoAnnuale2.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtImportoAnnuale3.TextChanged, AddressOf Me.txtCurrencyTextChanged
        'AddHandler txtImpresaDenominazione0.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtImpresaDenominazione1.TextChanged, AddressOf Me.txtStringTextChanged
        AddHandler txtImpresaInizio0.TextChanged, AddressOf Me.txtDateTextChanged
        AddHandler txtImpresaInizio1.TextChanged, AddressOf Me.txtDateTextChanged
        'AddHandler txtImpresaSettore0.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtImpresaSettore1.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtLavoroCap.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtLavoroIndirizzo.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtLavoroLocalita.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtLavoroProvincia.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtNome0.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtNome1.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtNome2.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtNome3.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtNome4.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtNome5.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtNome6.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtNote.TextChanged, AddressOf Me.txtStringTextChanged
        AddHandler txtRedditoAnnuo0.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtRedditoAnnuo1.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtRedditoAnnuo2.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtRedditoAnnuo3.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtRedditoAnnuo4.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtRedditoAnnuo5.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtRedditoAnnuo6.TextChanged, AddressOf Me.txtCurrencyTextChanged
        'AddHandler txtReferente.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtSim0.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtSim1.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtSim2.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtSim3.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtSim4.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtSim5.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtSim6.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtSim7.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtSitoWeb.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtSocialNet.TextChanged, AddressOf Me.txtStringTextChanged
        AddHandler txtSpesaImporto0.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtSpesaImporto1.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtSpesaImporto2.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtSpesaImporto3.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtSpesaImporto4.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtSpesaImporto5.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtTelReferente.TextChanged, AddressOf Me.txtCellulareTextChanged
        'AddHandler txtTipologia0.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtTipologia1.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtTipologia2.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtTipologia3.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtTipologia4.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtTipologia5.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtTipologia6.TextChanged, AddressOf Me.txtStringTextChanged
        'AddHandler txtTipologia7.TextChanged, AddressOf Me.txtStringTextChanged
        AddHandler txtValoreCommerciale0.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtValoreCommerciale1.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtValoreCommerciale2.TextChanged, AddressOf Me.txtCurrencyTextChanged
        AddHandler txtValoreCommerciale3.TextChanged, AddressOf Me.txtCurrencyTextChanged
        'AddHandler txtVoip.TextChanged, AddressOf Me.txtStringTextChanged
        AddHandler txtmq0.TextChanged, AddressOf Me.txtNumeroTextChanged
        AddHandler txtmq1.TextChanged, AddressOf Me.txtNumeroTextChanged
        AddHandler txtmq2.TextChanged, AddressOf Me.txtNumeroTextChanged
        AddHandler txtmq3.TextChanged, AddressOf Me.txtNumeroTextChanged

        AddHandler grdAnaliRca.DataError, AddressOf Me.DataGridViewCellValueDataError
        AddHandler grdFasiVendita.DataError, AddressOf Me.DataGridViewCellValueDataError
        AddHandler grdOpzioni.DataError, AddressOf Me.DataGridViewCellValueDataError
        AddHandler grdPolizzeAltrui.DataError, AddressOf Me.DataGridViewCellValueDataError
    End Sub

    Private Sub DataGridViewCellValueDataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        e.Cancel = False
    End Sub

    'Private Sub DataGridViewCellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    If sender.Equals(grdPolizzeAltrui) Then
    '        If grdPolizzeAltrui.Columns(e.ColumnIndex).Name = "" Then
    '            ValidaCurrency(grdPolizzeAltrui.Rows(e.RowIndex).Cells(e.ColumnIndex))
    '        End If
    '    End If
    'End Sub

    'Private Sub grdPolizzeAltrui_CellErrorTextNeeded(sender As Object, e As System.Windows.Forms.DataGridViewCellErrorTextNeededEventArgs) Handles grdPolizzeAltrui.CellErrorTextNeeded
    '    Dim cell As DataGridViewCell = CType(sender, DataGridView).Rows(e.RowIndex).Cells(e.ColumnIndex)
    '    If mCellBoxErrors.ContainsKey(cell) Then
    '        e.ErrorText = mCellBoxErrors(cell)
    '    End If
    'End Sub


    'Public Function ValidaCurrency(cell As DataGridViewCell) As Boolean
    '    Dim valore As String = Trim(cell.Value)
    '    Dim IsValido As Boolean = IsNumeric(valore) Or (valore = vbNullString)
    '    Return ValidaNotifica(cell, IsValido, "Importo non valido")
    'End Function

    'Public Function ValidaNumero(cell As DataGridViewCell) As Boolean
    '    Dim valore As String = Trim(cell.Value)
    '    Return ValidaNotifica(cell, IsNumeric(valore) Or (valore = vbNullString), "Numero non valido")
    'End Function

    'Public Function ValidaDate(cell As DataGridViewCell) As Boolean
    '    Dim Data As String = Trim(cell.Value)

    '    If (IsNumeric(Data) And (Len(Data) = 8)) Then
    '        Data = Data.Substring(0, 2) & "/" & Data.Substring(2, 2) & "/" & Data.Substring(4)
    '        cell.Value = Data
    '    End If

    '    Dim IsValido As Boolean = (IsDate(Data) And (Len(Data) = 10)) Or (Data = vbNullString)
    '    Return ValidaNotifica(cell, IsValido, "Data non valida (gg/mm/aaaa)")
    'End Function

    'Public Function ValidaNotifica(cell As DataGridViewCell, IsValido As Boolean, Caption As String) As Boolean
    '    If IsValido Then
    '        'cell.ForeColor = SystemColors.WindowText

    '        If mCellBoxErrors.ContainsKey(cell) Then
    '            mCellBoxErrors.Remove(cell)
    '        End If
    '        'ErrorProvider1.SetError(cell, vbNullString)
    '    Else
    '        'cell.ForeColor = Color.Red

    '        If Not mCellBoxErrors.ContainsKey(cell) Then
    '            mCellBoxErrors.Add(cell, Caption)
    '        End If
    '    End If

    '    If mCellBoxErrors.Count = 0 Then
    '        imgError.Visible = False
    '        lblError.Visible = False
    '    Else
    '        If IsValido Then
    '            For Each s As String In mCellBoxErrors.Values
    '                lblError.Text = s
    '            Next
    '        Else
    '            lblError.Text = Caption
    '            'ErrorProvider1.SetError(cell, Caption)
    '        End If

    '        imgError.Visible = True
    '        lblError.Visible = True
    '    End If

    '    Return IsValido
    'End Function

    Private Sub cmdMemo_Click(sender As System.Object, e As System.EventArgs) Handles cmdMemo.Click
        MsgBox("Da implementare chiamata a evidenze")
        'Process.Start(CARTELLA_APPPATH & "unidocs.exe 2A71E66E775A4e4a9BED88E5810CFB76;CLIENTE;" & mAnagrafica.CodiceFiscale)
    End Sub

    Private Sub buttonRisCellulare0_Click(sender As Object, e As EventArgs) Handles buttonRisCellulare0.Click
        InviaMessaggio(RisCellulare0.Text, UniCom.FormMail.TipoMessaggio.Sms)
    End Sub
    Private Sub buttonRisCellulare1_Click(sender As Object, e As EventArgs) Handles buttonRisCellulare1.Click
        InviaMessaggio(RisCellulare1.Text, UniCom.FormMail.TipoMessaggio.Sms)
    End Sub
    Private Sub buttonRisCellulare2_Click(sender As Object, e As EventArgs) Handles buttonRisCellulare2.Click
        InviaMessaggio(RisCellulare2.Text, UniCom.FormMail.TipoMessaggio.Sms)
    End Sub
    Private Sub buttonRisCellulare3_Click(sender As Object, e As EventArgs) Handles buttonRisCellulare3.Click
        InviaMessaggio(RisCellulare3.Text, UniCom.FormMail.TipoMessaggio.Sms)
    End Sub

    Private Sub buttonRisMail0_Click(sender As Object, e As EventArgs) Handles buttonRisMail0.Click
        InviaMessaggio(RisMail0.Text, UniCom.FormMail.TipoMessaggio.Email)
    End Sub
    Private Sub buttonRisMail1_Click(sender As Object, e As EventArgs) Handles buttonRisMail1.Click
        InviaMessaggio(RisMail1.Text, UniCom.FormMail.TipoMessaggio.Email)
    End Sub
    Private Sub buttonRisMail2_Click(sender As Object, e As EventArgs) Handles buttonRisMail2.Click
        InviaMessaggio(RisMail2.Text, UniCom.FormMail.TipoMessaggio.Email)
    End Sub
    Private Sub buttonRisMail3_Click(sender As Object, e As EventArgs) Handles buttonRisMail3.Click
        InviaMessaggio(RisMail3.Text, UniCom.FormMail.TipoMessaggio.Email)
    End Sub

    Friend Sub InviaMessaggio(Destinatario As String,
                          TipoMessaggio As UniCom.FormMail.TipoMessaggio)
        Try
            Using f As New UniCom.FormMail
                'tipo messaggio
                f.Messaggio = TipoMessaggio
                'pratica
                f.IdPratica = mAnagrafica.Cliente.CodiceFiscale
                f.CodiceFiscale = mAnagrafica.Cliente.CodiceFiscale
                'aggiungo destinatario
                Select Case TipoMessaggio
                    Case UniCom.FormMail.TipoMessaggio.Email
                        f.AddDestinatarioEmail(UniCom.FormMail.TipoDestinatarioMail.A, Destinatario)
                    Case UniCom.FormMail.TipoMessaggio.Sms
                        f.AddDestinatarioSms(Destinatario)
                End Select

                f.ShowDialog()
            End Using

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

End Class