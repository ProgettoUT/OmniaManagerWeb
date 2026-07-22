Namespace P07263
    Public Class P07263FE

        Protected Overrides Sub AttachEvents()
            AddHandler txtDanniTerziNumeroUbicazioni.Leave, AddressOf ValuesChanged
            AddHandler txtDanniTerziNumeroUbicazioni.KeyPress, AddressOf TextBoxKeyPress

            AddHandler chkDanniTerziBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkDanniTerziIncendio.CheckedChanged, AddressOf ValuesChanged
            AddHandler txtPartitaDanniTerziIncendio.Leave, AddressOf ValuesChanged
            AddHandler txtPartitaDanniTerziIncendio.KeyPress, AddressOf TextBoxKeyPress
            AddHandler chkDanniTerziVitaPrivata.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbDanniTerziVitaPrivatamassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkDanniTerziProprieta.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbDanniTerziProprietamassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkDanniTerziPlus.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkDanniTerziLavoro.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkDanniTerziBeB.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkDanniTerziLocazione.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkDanniTerziStage.CheckedChanged, AddressOf ValuesChanged

            AddHandler chkTutelaLegaleBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbTutelaLegaleBasemassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkTutelaLegaleDivorzio.CheckedChanged, AddressOf ValuesChanged

            AddHandler chkAssistenzaBase.CheckedChanged, AddressOf ValuesChanged

            AddHandler chkProtezioneDigitaleBase.CheckedChanged, AddressOf ValuesChanged

            AddHandler chkProtezioneBenessereBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbProtezioneBenessereBasecombinazione.SelectedIndexChanged, AddressOf ValuesChanged

            AddHandler chkProtezioneFamigliaBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkPersonaGiuridica.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkVincoloBancario.CheckedChanged, AddressOf ValuesChanged

            AddHandler QuotatorePremio.ClickedHelp, AddressOf MouseClickedHelp
            AddHandler QuotatorePremio.QuotatorePremioChanged, AddressOf ValuesChanged
            AddHandler TabControl1.SelectedIndexChanged, AddressOf TabControl1_SelectedIndexChanged

            For Each scheda As TabPage In TabControl1.Controls
                If scheda.Controls.Count > 0 AndAlso TypeOf (scheda.Controls(0)) Is AbitazioneFE Then
                    For Each AbitazioneFE As AbitazioneFE In scheda.Controls
                        AddHandler AbitazioneFE.Change, AddressOf ValuesChanged
                        AddHandler AbitazioneFE.Remove, AddressOf RimuoviScheda
                        AddHandler AbitazioneFE.Help, AddressOf MouseClickedHelp
                    Next
                End If
            Next
            AddHandler cmbDanniTerziProvincia.SelectedIndexChanged, AddressOf ValuesChanged

        End Sub

        Protected Overrides Sub DetachEvents()
            RemoveHandler txtDanniTerziNumeroUbicazioni.Leave, AddressOf ValuesChanged
            RemoveHandler txtDanniTerziNumeroUbicazioni.KeyPress, AddressOf TextBoxKeyPress

            RemoveHandler chkDanniTerziBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkDanniTerziIncendio.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler txtPartitaDanniTerziIncendio.Leave, AddressOf ValuesChanged
            RemoveHandler txtPartitaDanniTerziIncendio.KeyPress, AddressOf TextBoxKeyPress
            RemoveHandler chkDanniTerziVitaPrivata.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler cmbDanniTerziVitaPrivatamassimale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler chkDanniTerziProprieta.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler cmbDanniTerziProprietamassimale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler chkDanniTerziPlus.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkDanniTerziLavoro.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkDanniTerziBeB.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkDanniTerziLocazione.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkDanniTerziStage.CheckedChanged, AddressOf ValuesChanged

            RemoveHandler chkTutelaLegaleBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler cmbTutelaLegaleBasemassimale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler chkTutelaLegaleDivorzio.CheckedChanged, AddressOf ValuesChanged

            RemoveHandler chkAssistenzaBase.CheckedChanged, AddressOf ValuesChanged

            RemoveHandler chkProtezioneDigitaleBase.CheckedChanged, AddressOf ValuesChanged

            RemoveHandler chkProtezioneBenessereBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler cmbProtezioneBenessereBasecombinazione.SelectedIndexChanged, AddressOf ValuesChanged

            RemoveHandler chkProtezioneFamigliaBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkPersonaGiuridica.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkVincoloBancario.CheckedChanged, AddressOf ValuesChanged

            RemoveHandler QuotatorePremio.ClickedHelp, AddressOf MouseClickedHelp
            RemoveHandler QuotatorePremio.QuotatorePremioChanged, AddressOf ValuesChanged
            RemoveHandler TabControl1.SelectedIndexChanged, AddressOf TabControl1_SelectedIndexChanged

            For Each scheda As TabPage In TabControl1.Controls
                If scheda.Controls.Count > 0 AndAlso TypeOf (scheda.Controls(0)) Is AbitazioneFE Then
                    For Each AbitazioneFE As AbitazioneFE In scheda.Controls
                        RemoveHandler AbitazioneFE.Change, AddressOf ValuesChanged
                        RemoveHandler AbitazioneFE.Remove, AddressOf RimuoviScheda
                        RemoveHandler AbitazioneFE.Help, AddressOf MouseClickedHelp
                    Next
                End If
            Next
            RemoveHandler cmbDanniTerziProvincia.SelectedIndexChanged, AddressOf ValuesChanged

        End Sub

        Public Sub New()
            InitializeComponent2()
            Me.TabControl1.Controls.Add(Me.docTab)
            'ToDo: Me.QuotatorePremio.Image = Global.UniQuota.My.Resources.Resources.P07263
            Me.docBrowser.Tag = "http://www.utools.it/Unitools/Doc/Prodotti/P07263/IndexDoc.htm"
            Me.docBrowser.Url = New System.Uri(Me.docBrowser.Tag, System.UriKind.Absolute)

            'preventivo = New UnipolSaiCasaServizi
            'modello = New P07263ST

            Dim decode As New P07263DE
            'preventivo.Decode = decode
            Me.decode = decode

            helpChm.CodiceProdotto = "P07263"
            If helpChm.FileExists Then
                AgganciaHelp(Me, AddressOf MouseClickedHelp)
                helpChm.ShowPowerPoints(helpBrowser)
            End If

            AttachCombo(QuotatorePremio.cmbFrazionamento, decode.DecodeFrazionamenti)
            AttachCombo(cmbDanniTerziVitaPrivatamassimale, decode.DecodeDanniTerziVitaPrivatamassimale)
            AttachCombo(cmbDanniTerziProprietamassimale, decode.DecodeDanniTerziProprietamassimale)
            AttachCombo(cmbTutelaLegaleBasemassimale, decode.DecodeTutelaLegaleBasemassimale)
            AttachCombo(cmbProtezioneBenessereBasecombinazione, decode.DecodeProtezioneBenessereBasecombinazione)
            AttachCombo(cmbDanniTerziProvincia, Luogo.Province)

            QuotatorePremio.TableLayoutPanel1.Controls.Add(Me.lblPersonaGiuridica, 0, 10)
            QuotatorePremio.TableLayoutPanel1.Controls.Add(Me.chkPersonaGiuridica, 1, 10)
            QuotatorePremio.TableLayoutPanel1.Controls.Add(Me.lblVincoloBancario, 0, 11)
            QuotatorePremio.TableLayoutPanel1.Controls.Add(Me.chkVincoloBancario, 1, 11)
            QuotatorePremio.TableLayoutPanel4.RowStyles(0).Height = 260 + 24 + 24

            Panels = {TableLayoutPanel0, TableLayoutPanel1}
        End Sub

        Protected Overrides Sub ControlsToPreventivo(ByVal diretto As Boolean)
            With TryCast(preventivo, UnipolSaiCasaServizi)

                If diretto Then
                    If chkPersonaGiuridica.Checked Then
                        .TipoContraenza = TipoContraenzaEnum.PersonaGiudirica
                    Else
                        .TipoContraenza = TipoContraenzaEnum.PersonaFisica
                    End If
                    .VincoloBancario = chkVincoloBancario.Checked

                    .DanniTerziNumeroUbicazioni = IntegerBox(txtDanniTerziNumeroUbicazioni)
                    .ProvinciaRCT = cmbDanniTerziProvincia.SelectedValue
                    'DanniTerzi
                    .CoperturaDanniTerziBase.Stato = EnabledAndChecked(chkDanniTerziBase)
                    .CoperturaDanniTerziIncendio.Stato = EnabledAndChecked(chkDanniTerziIncendio)
                    .PartitaDanniTerziIncendio.SommaAssicurata = CurrencyBox(txtPartitaDanniTerziIncendio)
                    .CoperturaDanniTerziVitaPrivata.Stato = EnabledAndChecked(chkDanniTerziVitaPrivata)
                    .CoperturaDanniTerziVitaPrivata.Garanzia.Massimale = cmbDanniTerziVitaPrivatamassimale.SelectedValue
                    .CoperturaDanniTerziProprieta.Stato = EnabledAndChecked(chkDanniTerziProprieta)
                    .CoperturaDanniTerziProprieta.Garanzia.Massimale = cmbDanniTerziProprietamassimale.SelectedValue
                    .CoperturaDanniTerziPlus.Stato = EnabledAndChecked(chkDanniTerziPlus)
                    .CoperturaDanniTerziLavoro.Stato = EnabledAndChecked(chkDanniTerziLavoro)
                    .CoperturaDanniTerziBeB.Stato = EnabledAndChecked(chkDanniTerziBeB)
                    .CoperturaDanniTerziLocazione.Stato = EnabledAndChecked(chkDanniTerziLocazione)
                    .CoperturaDanniTerziStage.Stato = EnabledAndChecked(chkDanniTerziStage)

                    'TutelaLegale
                    .CoperturaTutelaLegaleBase.Stato = EnabledAndChecked(chkTutelaLegaleBase)
                    .CoperturaTutelaLegaleBase.Garanzia.Massimale = cmbTutelaLegaleBasemassimale.SelectedValue
                    .CoperturaTutelaLegaleDivorzio.Stato = EnabledAndChecked(chkTutelaLegaleDivorzio)

                    'Assistenza
                    .CoperturaAssistenzaBase.Stato = EnabledAndChecked(chkAssistenzaBase)

                    'ProtezioneDigitale
                    .CoperturaProtezioneDigitaleBase.Stato = EnabledAndChecked(chkProtezioneDigitaleBase)

                    'ProtezioneBenessere
                    .CoperturaProtezioneBenessereBase.Stato = EnabledAndChecked(chkProtezioneBenessereBase)
                    .CoperturaProtezioneBenessereBase.Garanzia.Combinazione = cmbProtezioneBenessereBasecombinazione.SelectedValue

                    'ProtezioneFamiglia
                    .CoperturaProtezioneFamigliaBase.Stato = EnabledAndChecked(chkProtezioneFamigliaBase)
                Else
                    IntegerBox(txtDanniTerziNumeroUbicazioni) = .DanniTerziNumeroUbicazioni
                    txtDanniTerziNumeroUbicazioni.Enabled = True

                    cmbDanniTerziProvincia.SelectedValue = .ProvinciaRCT
                    cmbDanniTerziProvincia.Enabled = .CoperturaDanniTerziBase.IsAttivo
                    'DanniTerzi
                    EnabledAndChecked(chkDanniTerziBase) = .CoperturaDanniTerziBase.Stato
                    FormatEuro(lblDanniTerziBase, .SezioneDanniTerzi)
                    EnabledAndChecked(chkDanniTerziIncendio) = .CoperturaDanniTerziIncendio.Stato
                    CurrencyBox(txtPartitaDanniTerziIncendio) = .PartitaDanniTerziIncendio.SommaAssicurata
                    txtPartitaDanniTerziIncendio.Enabled = Enable(.CoperturaDanniTerziIncendio.Stato)
                    FormatEuro(lblDanniTerziIncendio, .CoperturaDanniTerziIncendio)
                    EnabledAndChecked(chkDanniTerziVitaPrivata) = .CoperturaDanniTerziVitaPrivata.Stato
                    FormatEuro(lblDanniTerziVitaPrivata, .CoperturaDanniTerziVitaPrivata)
                    cmbDanniTerziVitaPrivatamassimale.Enabled = Enable(.CoperturaDanniTerziVitaPrivata.Stato)
                    cmbDanniTerziVitaPrivatamassimale.SelectedValue = .CoperturaDanniTerziVitaPrivata.Garanzia.Massimale
                    EnabledAndChecked(chkDanniTerziProprieta) = .CoperturaDanniTerziProprieta.Stato
                    FormatEuro(lblDanniTerziProprieta, .CoperturaDanniTerziProprieta)
                    cmbDanniTerziProprietamassimale.Enabled = Enable(.CoperturaDanniTerziProprieta.Stato)
                    cmbDanniTerziProprietamassimale.SelectedValue = .CoperturaDanniTerziProprieta.Garanzia.Massimale
                    IntegerBox(txtDanniTerziNumeroUbicazioni) = .DanniTerziNumeroUbicazioni
                    txtDanniTerziNumeroUbicazioni.Enabled = Enable(.CoperturaDanniTerziProprieta.Stato)
                    EnabledAndChecked(chkDanniTerziPlus) = .CoperturaDanniTerziPlus.Stato
                    FormatEuro(lblDanniTerziPlus, .CoperturaDanniTerziPlus)
                    EnabledAndChecked(chkDanniTerziLavoro) = .CoperturaDanniTerziLavoro.Stato
                    FormatEuro(lblDanniTerziLavoro, .CoperturaDanniTerziLavoro)
                    EnabledAndChecked(chkDanniTerziBeB) = .CoperturaDanniTerziBeB.Stato
                    FormatEuro(lblDanniTerziBeB, .CoperturaDanniTerziBeB)
                    EnabledAndChecked(chkDanniTerziLocazione) = .CoperturaDanniTerziLocazione.Stato
                    FormatEuro(lblDanniTerziLocazione, .CoperturaDanniTerziLocazione)
                    EnabledAndChecked(chkDanniTerziStage) = .CoperturaDanniTerziStage.Stato
                    FormatEuro(lblDanniTerziStage, .CoperturaDanniTerziStage)

                    'TutelaLegale
                    EnabledAndChecked(chkTutelaLegaleBase) = .CoperturaTutelaLegaleBase.Stato
                    FormatEuro(lblTutelaLegaleBase, .CoperturaTutelaLegaleBase)
                    cmbTutelaLegaleBasemassimale.Enabled = EnableIfAttivo(.CoperturaTutelaLegaleBase.Stato)
                    cmbTutelaLegaleBasemassimale.SelectedValue = .CoperturaTutelaLegaleBase.Garanzia.Massimale
                    EnabledAndChecked(chkTutelaLegaleDivorzio) = .CoperturaTutelaLegaleDivorzio.Stato
                    FormatEuro(lblTutelaLegaleDivorzio, .CoperturaTutelaLegaleDivorzio)

                    'Assistenza
                    EnabledAndChecked(chkAssistenzaBase) = .CoperturaAssistenzaBase.Stato
                    FormatEuro(lblAssistenzaBase, .CoperturaAssistenzaBase)

                    'ProtezioneDigitale
                    EnabledAndChecked(chkProtezioneDigitaleBase) = .CoperturaProtezioneDigitaleBase.Stato
                    FormatEuro(lblProtezioneDigitaleBase, .CoperturaProtezioneDigitaleBase)

                    'ProtezioneBenessere
                    EnabledAndChecked(chkProtezioneBenessereBase) = .CoperturaProtezioneBenessereBase.Stato
                    FormatEuro(lblProtezioneBenessereBase, .CoperturaProtezioneBenessereBase)
                    cmbProtezioneBenessereBasecombinazione.Enabled = Enable(.CoperturaProtezioneBenessereBase.Stato)
                    cmbProtezioneBenessereBasecombinazione.SelectedValue = .CoperturaProtezioneBenessereBase.Garanzia.Combinazione

                    'ProtezioneFamiglia
                    EnabledAndChecked(chkProtezioneFamigliaBase) = .CoperturaProtezioneFamigliaBase.Stato
                    FormatEuro(lblProtezioneFamigliaBase, .CoperturaProtezioneFamigliaBase)
                End If


                'RIEPILOGO GARANZIE
                If diretto = False Then
                    chkPersonaGiuridica.Checked = (.TipoContraenza = TipoContraenzaEnum.PersonaGiudirica)
                    chkVincoloBancario.Checked = .VincoloBancario

                    lblSezioneDanniBeniPremio.Text = FormatEuro(.SezioneDanniBeni.PremioLabel)
                    chkSezioneDanniBeni.Checked = .SezioneDanniBeni.IsAttivo
                    chkSezioneDanniBeni.Enabled = False

                    lblSezioneCatastrofaliPremio.Text = FormatEuro(.SezioneCatastrofali.PremioLabel)
                    chkSezioneCatastrofali.Checked = .SezioneCatastrofali.IsAttivo
                    chkSezioneCatastrofali.Enabled = False

                    lblSezioneAssistenzaPlusPremio.Text = FormatEuro(.SezioneAssistenzaPlus.PremioLabel)
                    chkSezioneAssistenzaPlus.Checked = .SezioneAssistenzaPlus.IsAttivo
                    chkSezioneAssistenzaPlus.Enabled = False

                    lblSezioneProtezioneEmergenzaPremio.Text = FormatEuro(.SezioneProtezioneEmergenza.PremioLabel)
                    chkSezioneProtezioneEmergenza.Checked = .SezioneProtezioneEmergenza.IsAttivo
                    chkSezioneProtezioneEmergenza.Enabled = False

                    lblSezioneFurtoPremio.Text = FormatEuro(.SezioneFurto.PremioLabel)
                    chkSezioneFurto.Checked = .SezioneFurto.IsAttivo
                    chkSezioneFurto.Enabled = False

                    lblSezioneDanniTerziPremio.Text = FormatEuro(.SezioneDanniTerzi.PremioLabel)
                    chkSezioneDanniTerzi.Checked = .SezioneDanniTerzi.IsAttivo
                    chkSezioneDanniTerzi.Enabled = False

                    lblSezioneTutelaLegalePremio.Text = FormatEuro(.SezioneTutelaLegale.PremioLabel)
                    chkSezioneTutelaLegale.Checked = .SezioneTutelaLegale.IsAttivo
                    chkSezioneTutelaLegale.Enabled = False

                    lblSezioneAssistenzaPremio.Text = FormatEuro(.SezioneAssistenza.PremioLabel)
                    chkSezioneAssistenza.Checked = .SezioneAssistenza.IsAttivo
                    chkSezioneAssistenza.Enabled = False

                    lblSezioneProtezioneDigitalePremio.Text = FormatEuro(.SezioneProtezioneDigitale.PremioLabel)
                    chkSezioneProtezioneDigitale.Checked = .SezioneProtezioneDigitale.IsAttivo
                    chkSezioneProtezioneDigitale.Enabled = False

                    lblSezioneProtezioneBenesserePremio.Text = FormatEuro(.SezioneProtezioneBenessere.PremioLabel)
                    chkSezioneProtezioneBenessere.Checked = .SezioneProtezioneBenessere.IsAttivo
                    chkSezioneProtezioneBenessere.Enabled = False

                    lblSezioneProtezioneFamigliaPremio.Text = FormatEuro(.SezioneProtezioneFamiglia.PremioLabel)
                    chkSezioneProtezioneFamiglia.Checked = .SezioneProtezioneFamiglia.IsAttivo
                    chkSezioneProtezioneFamiglia.Enabled = False

                    lblSezioneTotalePremio.Text = FormatEuro(.PremioLabel)
                End If
            End With
            For Each scheda As TabPage In TabControl1.Controls
                If scheda.Controls.Count > 0 AndAlso TypeOf (scheda.Controls(0)) Is AbitazioneFE Then
                    For Each AbitazioneFE As AbitazioneFE In scheda.Controls
                        AbitazioneFE.ControlsToPreventivo(diretto)
                    Next
                End If
            Next
        End Sub

        Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If TabControl1.SelectedTab.Equals(TabAgg) Then
                Dim Abitazione As New Abitazione(preventivo)

                preventivo.DescrizioniCoperture(Abitazione.CoperturaDanniBeni.CopertureSingole)
                preventivo.DescrizioniCoperture(Abitazione.CoperturaCatastrofali.CopertureSingole)
                preventivo.DescrizioniCoperture(Abitazione.CoperturaFurto.CopertureSingole)

                AggiungiScheda(Abitazione)
                TryCast(preventivo, UnipolSaiCasaServizi).AggiungiAbitazione(Abitazione)
                preventivo.ValidaECalcola()
                PreventivoToControls()
            End If
        End Sub

        Private Sub AggiungiScheda(ByRef Abitazione As Abitazione)
            With TabControl1
                .SuspendLayout()

                Dim isNew As Boolean = .SelectedTab.Equals(TabAgg)

                Dim TabPage = New System.Windows.Forms.TabPage
                TabPage.Text = "Abitazione " & TabControl1.Controls.Count - 5
                TabPage.Margin = New System.Windows.Forms.Padding(0)
                TabPage.UseVisualStyleBackColor = True

                .TabPages.Insert(.TabCount - 4, TabPage)

                If isNew Then
                    TabPage.Controls.Add(lblCaricamento)
                    .SelectedTab = TabPage
                    Application.DoEvents()
                End If

                With TabPage
                    Dim AbitazioneFE As New AbitazioneFE(decode, helpChm)

                    AbitazioneFE.Abitazione = Abitazione
                    AbitazioneFE.Dock = DockStyle.Fill
                    .Controls.Add(AbitazioneFE)
                End With

                If isNew Then
                    TabPage.Controls.Remove(lblCaricamento)
                    Application.DoEvents()
                End If

                .ResumeLayout()
            End With
        End Sub

        Private Sub RimuoviScheda(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim AbitazioneFE As AbitazioneFE = sender
            TryCast(preventivo, UnipolSaiCasaServizi).RimuoviAbitazione(AbitazioneFE.Abitazione)
            preventivo.ValidaECalcola()
            PreventivoToControls()
            AbitazioneFE.Parent.Dispose()

            'rinomina schede
            For i As Integer = 1 To TabControl1.Controls.Count - 6
                TabControl1.Controls(i + 1).Text = "Abitazione " & i
            Next
        End Sub

        Public Overrides Sub Apri(ByVal p As Prodotto)
            If p IsNot Nothing Then
                preventivo = p
                preventivo.Decode = decode
                preventivo.Inizializza()
                preventivo.ValidaECalcola()

                TabControl1.SuspendLayout()
                While TabControl1.Controls.Count > 6
                    TabControl1.Controls(2).Dispose()
                End While

                For Each Abitazione As Abitazione In TryCast(preventivo, UnipolSaiCasaServizi).Abitazioni
                    AggiungiScheda(Abitazione)
                Next

                PreventivoToControls()
                TabControl1.ResumeLayout()
            End If
        End Sub

    End Class
End Namespace
