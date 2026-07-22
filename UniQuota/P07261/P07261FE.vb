Namespace P07261
    Public Class P07261FE

        Protected Overrides Sub AttachEvents()
            AddHandler cmbRCChiave.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbSalvaBenessereEta.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbTutelaLegaleChiave.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler cmbRegione.SelectedIndexChanged, AddressOf ValuesChanged

            AddHandler chkResponsabilitaCivileBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbResponsabilitaCivileBaseMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            AddHandler chkRCVitaPrivata.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCFabbricati.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCVitaPrivataFabbricati.CheckedChanged, AddressOf ValuesChanged
            AddHandler chkRCEstensioneGaranziaBase.CheckedChanged, AddressOf ValuesChanged

            AddHandler chkSalvaBenessereBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbSalvaBenessereBaseMassimale.SelectedIndexChanged, AddressOf ValuesChanged

            AddHandler chkTutelaLegaleBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler cmbTutelaLegaleBaseMassimale.SelectedIndexChanged, AddressOf ValuesChanged

            AddHandler chkAssistenzaBase.CheckedChanged, AddressOf ValuesChanged
            AddHandler QuotatorePremio.ClickedHelp, AddressOf MouseClickedHelp
            AddHandler QuotatorePremio.QuotatorePremioChanged, AddressOf ValuesChanged
            AddHandler TabControl1.SelectedIndexChanged, AddressOf TabControl1_SelectedIndexChanged

            For Each scheda As TabPage In TabControl1.Controls
                If scheda.Controls.Count > 0 AndAlso TypeOf (scheda.Controls(0)) Is AbitazioneFE Then
                    For Each AbitazioneFE As AbitazioneFE In scheda.Controls
                        AddHandler AbitazioneFE.ChiaveChanged, AddressOf ChiaveChanged
                        AddHandler AbitazioneFE.Change, AddressOf ValuesChanged
                        AddHandler AbitazioneFE.Remove, AddressOf RimuoviScheda
                        AddHandler AbitazioneFE.Help, AddressOf MouseClickedHelp
                    Next
                End If
            Next
        End Sub

        Protected Overrides Sub DetachEvents()
            RemoveHandler cmbRCChiave.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbSalvaBenessereEta.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbTutelaLegaleChiave.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler cmbRegione.SelectedIndexChanged, AddressOf ValuesChanged

            RemoveHandler chkResponsabilitaCivileBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler cmbResponsabilitaCivileBaseMassimale.SelectedIndexChanged, AddressOf ValuesChanged
            RemoveHandler chkRCVitaPrivata.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCFabbricati.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCVitaPrivataFabbricati.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler chkRCEstensioneGaranziaBase.CheckedChanged, AddressOf ValuesChanged

            RemoveHandler chkSalvaBenessereBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler cmbSalvaBenessereBaseMassimale.SelectedIndexChanged, AddressOf ValuesChanged

            RemoveHandler chkTutelaLegaleBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler cmbTutelaLegaleBaseMassimale.SelectedIndexChanged, AddressOf ValuesChanged

            RemoveHandler chkAssistenzaBase.CheckedChanged, AddressOf ValuesChanged
            RemoveHandler QuotatorePremio.ClickedHelp, AddressOf MouseClickedHelp
            RemoveHandler QuotatorePremio.QuotatorePremioChanged, AddressOf ValuesChanged
            RemoveHandler TabControl1.SelectedIndexChanged, AddressOf TabControl1_SelectedIndexChanged

            For Each scheda As TabPage In TabControl1.Controls
                If scheda.Controls.Count > 0 AndAlso TypeOf (scheda.Controls(0)) Is AbitazioneFE Then
                    For Each AbitazioneFE As AbitazioneFE In scheda.Controls
                        RemoveHandler AbitazioneFE.ChiaveChanged, AddressOf ChiaveChanged
                        RemoveHandler AbitazioneFE.Change, AddressOf ValuesChanged
                        RemoveHandler AbitazioneFE.Remove, AddressOf RimuoviScheda
                        RemoveHandler AbitazioneFE.Help, AddressOf MouseClickedHelp
                    Next
                End If
            Next
        End Sub

        Public Sub New()
            InitializeComponent2()
            Me.TabControl1.Controls.Add(Me.docTab)
            Me.QuotatorePremio.Image = Global.UniQuota.My.Resources.Resources.P07261
            Me.docBrowser.Tag = "http://www.utools.it/Unitools/Doc/Prodotti/P07261/IndexDoc.htm"
            Me.docBrowser.Url = New System.Uri(CStr(Me.docBrowser.Tag), System.UriKind.Absolute)

            'preventivo = New youCasa
            'modello = New P07261ST

            Dim decode As New P07261DE
            'preventivo.Decode = decode
            Me.decode = decode

            helpChm.CodiceProdotto = "P07261"

            If helpChm.FileExists Then
                AgganciaHelp(Me, AddressOf MouseClickedHelp)
            End If

            AttachCombo(QuotatorePremio.cmbFrazionamento, decode.DecodeFrazionamenti)
            AttachCombo(cmbRCChiave, decode.DecodeRCChiave)
            AttachCombo(cmbSalvaBenessereEta, decode.DecodeSalvaBenessereEta)
            AttachCombo(cmbTutelaLegaleChiave, decode.DecodeTutelaLegaleChiave)
            AttachCombo(cmbResponsabilitaCivileBaseMassimale, decode.DecodeResponsabilitaCivileBaseMassimale)
            AttachCombo(cmbSalvaBenessereBaseMassimale, decode.DecodeSalvaBenessereBaseMassimale)
            AttachCombo(cmbTutelaLegaleBaseMassimale, decode.DecodeTutelaLegaleBaseMassimale)
            AttachCombo(cmbRegione, Luogo.Regioni)

            'preventivo.Inizializza()
            'preventivo.ValidaECalcola()
            'PreventivoToControls()
            Panels = {TableLayoutPanel1}
        End Sub

        Protected Overrides Sub ControlsToPreventivo(ByVal diretto As Boolean)
            With TryCast(preventivo, youCasa)

                If diretto Then
                    .Regione = cmbRegione.SelectedValue

                    'ResponsabilitaCivile
                    .CoperturaResponsabilitaCivileBase.Stato = EnabledAndChecked(chkResponsabilitaCivileBase)
                    .CoperturaResponsabilitaCivileBase.Garanzia.Massimale = CDec(cmbResponsabilitaCivileBaseMassimale.SelectedValue)
                    .RCChiave = cmbRCChiave.SelectedValue
                    .CoperturaRCVitaPrivata.Stato = EnabledAndChecked(chkRCVitaPrivata)
                    .CoperturaRCFabbricati.Stato = EnabledAndChecked(chkRCFabbricati)
                    .CoperturaRCVitaPrivataFabbricati.Stato = EnabledAndChecked(chkRCVitaPrivataFabbricati)
                    .CoperturaRCEstensioneGaranziaBase.Stato = EnabledAndChecked(chkRCEstensioneGaranziaBase)

                    'SalvaBenessere
                    .CoperturaSalvaBenessereBase.Stato = EnabledAndChecked(chkSalvaBenessereBase)
                    .CoperturaSalvaBenessereBase.Garanzia.Massimale = CDec(cmbSalvaBenessereBaseMassimale.SelectedValue)
                    .SalvaBenessereEta = cmbSalvaBenessereEta.SelectedValue

                    'TutelaLegale
                    .CoperturaTutelaLegaleBase.Stato = EnabledAndChecked(chkTutelaLegaleBase)
                    .CoperturaTutelaLegaleBase.Garanzia.Massimale = CDec(cmbTutelaLegaleBaseMassimale.SelectedValue)
                    .TutelaLegaleChiave = cmbTutelaLegaleChiave.SelectedValue

                    'Assistenza
                    .CoperturaAssistenzaBase.Stato = EnabledAndChecked(chkAssistenzaBase)
                Else
                    'ResponsabilitaCivile
                    EnabledAndChecked(chkResponsabilitaCivileBase) = .CoperturaResponsabilitaCivileBase.Stato
                    cmbResponsabilitaCivileBaseMassimale.Enabled = EnableIfAttivo(.CoperturaResponsabilitaCivileBase.Stato)
                    cmbResponsabilitaCivileBaseMassimale.SelectedValue = .CoperturaResponsabilitaCivileBase.Garanzia.Massimale
                    cmbRCChiave.Enabled = EnableIfAttivo(.CoperturaResponsabilitaCivileBase.Stato)
                    cmbRCChiave.SelectedValue = CInt(.RCChiave)
                    EnabledAndChecked(chkRCVitaPrivata) = .CoperturaRCVitaPrivata.Stato
                    FormatEuro(lblRCVitaPrivata, .CoperturaRCVitaPrivata)
                    EnabledAndChecked(chkRCFabbricati) = .CoperturaRCFabbricati.Stato
                    FormatEuro(lblRCFabbricati, .CoperturaRCFabbricati)
                    EnabledAndChecked(chkRCVitaPrivataFabbricati) = .CoperturaRCVitaPrivataFabbricati.Stato
                    FormatEuro(lblRCVitaPrivataFabbricati, .CoperturaRCVitaPrivataFabbricati)
                    FormatEuro(lblResponsabilitaCivilePremio, .SezioneResponsabilitaCivile)
                    EnabledAndChecked(chkRCEstensioneGaranziaBase) = .CoperturaRCEstensioneGaranziaBase.Stato
                    FormatEuro(lblRCEstensioneGaranziaBase, .CoperturaRCEstensioneGaranziaBase)

                    'SalvaBenessere
                    EnabledAndChecked(chkSalvaBenessereBase) = .CoperturaSalvaBenessereBase.Stato
                    FormatEuro(lblSalvaBenesserePremio, .CoperturaSalvaBenessereBase)
                    cmbSalvaBenessereBaseMassimale.Enabled = Enable(.CoperturaSalvaBenessereBase.Stato)
                    cmbSalvaBenessereBaseMassimale.SelectedValue = .CoperturaSalvaBenessereBase.Garanzia.Massimale
                    cmbSalvaBenessereEta.Enabled = Enable(.CoperturaSalvaBenessereBase.Stato)
                    cmbSalvaBenessereEta.SelectedValue = CInt(.SalvaBenessereEta)
                    cmbRegione.SelectedValue = .Regione
                    cmbRegione.Enabled = Enable(.CoperturaSalvaBenessereBase.Stato)
                    'FormatEuro(lblSalvaBenesserePremio, .SezioneSalvaBenessere)

                    'TutelaLegale
                    EnabledAndChecked(chkTutelaLegaleBase) = .CoperturaTutelaLegaleBase.Stato
                    FormatEuro(lblTutelaLegalePremio, .CoperturaTutelaLegaleBase)
                    cmbTutelaLegaleBaseMassimale.Enabled = Enable(.CoperturaTutelaLegaleBase.Stato)
                    cmbTutelaLegaleBaseMassimale.SelectedValue = .CoperturaTutelaLegaleBase.Garanzia.Massimale
                    cmbTutelaLegaleChiave.Enabled = Enable(.CoperturaTutelaLegaleBase.Stato)
                    cmbTutelaLegaleChiave.SelectedValue = CInt(.TutelaLegaleChiave)
                    'FormatEuro(lblTutelaLegalePremio, .SezioneTutelaLegale)

                    'Assistenza
                    EnabledAndChecked(chkAssistenzaBase) = .CoperturaAssistenzaBase.Stato
                    FormatEuro(lblAssistenzaPremio, .CoperturaAssistenzaBase)
                    'FormatEuro(lblAssistenzaPremio, .SezioneAssistenza)
                End If


                'RIEPILOGO GARANZIE
                If diretto = False Then

                    lblSezioneIncendioPremio.Text = FormatEuro(.SezioneIncendio.PremioLabel)
                    chkSezioneIncendio.Checked = .SezioneIncendio.IsAttivo
                    chkSezioneIncendio.Enabled = False

                    lblSezioneTerremotoPremio.Text = FormatEuro(.SezioneTerremoto.PremioLabel)
                    chkSezioneTerremoto.Checked = .SezioneTerremoto.IsAttivo
                    chkSezioneTerremoto.Enabled = False

                    lblSezioneFurtoPremio.Text = FormatEuro(.SezioneFurto.PremioLabel)
                    chkSezioneFurto.Checked = .SezioneFurto.IsAttivo
                    chkSezioneFurto.Enabled = False

                    lblSezioneResponsabilitaCivilePremio.Text = FormatEuro(.SezioneResponsabilitaCivile.PremioLabel)
                    chkSezioneResponsabilitaCivile.Checked = .SezioneResponsabilitaCivile.IsAttivo
                    chkSezioneResponsabilitaCivile.Enabled = False

                    lblSezioneSalvaBenesserePremio.Text = FormatEuro(.SezioneSalvaBenessere.PremioLabel)
                    chkSezioneSalvaBenessere.Checked = .SezioneSalvaBenessere.IsAttivo
                    chkSezioneSalvaBenessere.Enabled = False

                    lblSezioneTutelaLegalePremio.Text = FormatEuro(.SezioneTutelaLegale.PremioLabel)
                    chkSezioneTutelaLegale.Checked = .SezioneTutelaLegale.IsAttivo
                    chkSezioneTutelaLegale.Enabled = False

                    lblSezioneAssistenzaPremio.Text = FormatEuro(.SezioneAssistenza.PremioLabel)
                    chkSezioneAssistenza.Checked = .SezioneAssistenza.IsAttivo
                    chkSezioneAssistenza.Enabled = False

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
                My.Application.DoEvents()

                Dim Abitazione As New Abitazione(CType(preventivo, youCasa))

                preventivo.DescrizioniCoperture(Abitazione.CoperturaIncendio.CopertureSingole)
                preventivo.DescrizioniCoperture(Abitazione.CoperturaTerremoto.CopertureSingole)
                preventivo.DescrizioniCoperture(Abitazione.CoperturaFurto.CopertureSingole)

                AggiungiScheda(Abitazione)
                TryCast(preventivo, youCasa).AggiungiAbitazione(Abitazione)
                preventivo.ValidaECalcola()
                PreventivoToControls()
            End If
        End Sub

        Private Sub AggiungiScheda(ByRef Abitazione As Abitazione)
            With TabControl1
                .SuspendLayout()
                Dim isNew As Boolean = .SelectedTab.Equals(TabAgg)

                Dim TabPage = New System.Windows.Forms.TabPage

                TabPage.Text = "Abitazione " & .TabCount - 2
                TabPage.Margin = New System.Windows.Forms.Padding(0)
                TabPage.UseVisualStyleBackColor = True

                .TabPages.Insert(.TabCount - 2, TabPage)

                If isNew Then
                    TabPage.Controls.Add(lblCaricamento)
                    .SelectedTab = TabPage
                    Application.DoEvents()
                End If


                With TabPage
                    Dim AbitazioneFE As New AbitazioneFE(CType(decode, P07261DE))

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
            Dim AbitazioneFE As AbitazioneFE = CType(sender, AbitazioneFE)
            TryCast(preventivo, youCasa).RimuoviAbitazione(AbitazioneFE.Abitazione)
            preventivo.ValidaECalcola()
            PreventivoToControls()
            AbitazioneFE.Parent.Dispose()

            'rinomina schede
            For i As Integer = 2 To TabControl1.Controls.Count - 2
                TabControl1.Controls(i - 1).Text = "Abitazione " & i - 1
            Next
        End Sub

        Private Sub ChiaveChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim combo As ComboBox = CType(sender, ComboBox)

            If "cmbIncendioChiave".Equals(sender.Name) Then
                TryCast(preventivo, youCasa).IncendioChiave = combo.SelectedValue
            ElseIf "cmbFurtoChiave".Equals(sender.Name) Then
                TryCast(preventivo, youCasa).FurtoChiave = combo.SelectedValue
            End If
        End Sub

        Public Overrides Sub Apri(ByVal p As Prodotto)
            If p IsNot Nothing Then

                preventivo = p
                preventivo.Decode = decode
                preventivo.Inizializza()
                preventivo.ValidaECalcola()

                TabControl1.SuspendLayout()
                While TabControl1.Controls.Count > 3
                    TabControl1.Controls(1).Dispose()
                End While

                For Each Abitazione As Abitazione In TryCast(preventivo, youCasa).AbitazioneX
                    AggiungiScheda(Abitazione)
                Next

                PreventivoToControls()
                TabControl1.ResumeLayout()
            End If
        End Sub
    End Class
End Namespace
