Namespace P01204
    Public Class P01204FE

        Protected Overrides Sub AttachEvents()
            AddHandler QuotatorePremio.ClickedHelp, AddressOf MouseClickedHelp
            AddHandler QuotatorePremio.QuotatorePremioChanged, AddressOf ValuesChanged
            AddHandler TabControl1.SelectedIndexChanged, AddressOf TabControl1_SelectedIndexChanged

            For Each scheda As TabPage In TabControl1.Controls
                If scheda.Controls.Count > 0 AndAlso TypeOf (scheda.Controls(0)) Is assicuratoFE Then
                    For Each assicuratoFE As assicuratoFE In scheda.Controls
                        AddHandler assicuratoFE.Change, AddressOf ValuesChanged
                        AddHandler assicuratoFE.Remove, AddressOf RimuoviScheda
                        AddHandler assicuratoFE.Help, AddressOf MouseClickedHelp
                    Next
                End If
            Next
        End Sub

        Protected Overrides Sub DetachEvents()
            RemoveHandler QuotatorePremio.ClickedHelp, AddressOf MouseClickedHelp
            RemoveHandler QuotatorePremio.QuotatorePremioChanged, AddressOf ValuesChanged
            RemoveHandler TabControl1.SelectedIndexChanged, AddressOf TabControl1_SelectedIndexChanged

            For Each scheda As TabPage In TabControl1.Controls
                If scheda.Controls.Count > 0 AndAlso TypeOf (scheda.Controls(0)) Is assicuratoFE Then
                    For Each assicuratoFE As assicuratoFE In scheda.Controls
                        RemoveHandler assicuratoFE.Change, AddressOf ValuesChanged
                        RemoveHandler assicuratoFE.Remove, AddressOf RimuoviScheda
                        RemoveHandler assicuratoFE.Help, AddressOf MouseClickedHelp
                    Next
                End If
            Next
        End Sub

        Public Sub New()
            InitializeComponent2()
            Me.TabControl1.Controls.Add(Me.docTab)
            Me.QuotatorePremio.Image = Global.UniQuota.My.Resources.Resources.P01204
            Me.docBrowser.Tag = "http://www.utools.it/Unitools/Doc/Prodotti/P01204/IndexDoc.htm"
            Me.docBrowser.Url = New System.Uri(Me.docBrowser.Tag, System.UriKind.Absolute)

            'preventivo = New InfortuniPremium
            'modello = New P01204ST

            Dim decode As New P01204DE
            'preventivo.Decode = decode
            Me.decode = decode

            helpChm.CodiceProdotto = "P01204"
            If helpChm.FileExists Then
                AgganciaHelp(Me, AddressOf MouseClickedHelp)
            End If

            AttachCombo(QuotatorePremio.cmbFrazionamento, decode.DecodeFrazionamenti)
            Panels = {TableLayoutPanel1}
        End Sub

        Protected Overrides Sub ControlsToPreventivo(ByVal diretto As Boolean)
            With TryCast(preventivo, InfortuniPremium)

                'RIEPILOGO GARANZIE
                If diretto = False Then

                    lblSezioneInfortuniPremio.Text = FormatEuro(.SezioneInfortuni.PremioLabel)
                    chkSezioneInfortuni.Checked = .SezioneInfortuni.IsAttivo
                    chkSezioneInfortuni.Enabled = False

                    lblSezioneMalattiaPremio.Text = FormatEuro(.SezioneMalattia.PremioLabel)
                    chkSezioneMalattia.Checked = .SezioneMalattia.IsAttivo
                    chkSezioneMalattia.Enabled = False

                    lblSezioneSalvaPremioPremio.Text = FormatEuro(.SezioneSalvaPremio.PremioLabel)
                    chkSezioneSalvaPremio.Checked = .SezioneSalvaPremio.IsAttivo
                    chkSezioneSalvaPremio.Enabled = False

                    lblSezioneAssistenzaPremio.Text = FormatEuro(.SezioneAssistenza.PremioLabel)
                    chkSezioneAssistenza.Checked = .SezioneAssistenza.IsAttivo
                    chkSezioneAssistenza.Enabled = False

                    lblSezioneTotalePremio.Text = FormatEuro(.PremioLabel)
                End If
            End With
            For Each scheda As TabPage In TabControl1.Controls
                If scheda.Controls.Count > 0 AndAlso TypeOf (scheda.Controls(0)) Is assicuratoFE Then
                    For Each assicuratoFE As assicuratoFE In scheda.Controls
                        assicuratoFE.ControlsToPreventivo(diretto)
                    Next
                End If
            Next
        End Sub

        Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If TabControl1.SelectedTab.Equals(TabAgg) Then
                Dim assicurato As New assicurato(preventivo)

                preventivo.DescrizioniCoperture(assicurato.CoperturaInfortuni.CopertureSingole)
                preventivo.DescrizioniCoperture(assicurato.CoperturaMalattia.CopertureSingole)
                preventivo.DescrizioniCoperture(assicurato.CoperturaSalvaPremio.CopertureSingole)
                preventivo.DescrizioniCoperture(assicurato.CoperturaAssistenza.CopertureSingole)

                AggiungiScheda(assicurato)
                TryCast(preventivo, InfortuniPremium).Aggiungiassicurato(assicurato)
                preventivo.ValidaECalcola()
                PreventivoToControls()
            End If
        End Sub

        Private Sub AggiungiScheda(ByRef assicurato As assicurato)
            With TabControl1
                .SuspendLayout()

                Dim isNew As Boolean = .SelectedTab.Equals(TabAgg)

                Dim TabPage = New System.Windows.Forms.TabPage
                TabPage.Text = "assicurato " & TabControl1.Controls.Count - 2
                TabPage.Margin = New System.Windows.Forms.Padding(0)
                TabPage.UseVisualStyleBackColor = True

                .TabPages.Insert(.TabCount - 2, TabPage)

                If isNew Then
                    TabPage.Controls.Add(lblCaricamento)
                    .SelectedTab = TabPage
                    Application.DoEvents()
                End If

                With TabPage
                    Dim assicuratoFE As New assicuratoFE(decode, helpChm)

                    assicuratoFE.assicurato = assicurato
                    assicuratoFE.Dock = DockStyle.Fill
                    .Controls.Add(assicuratoFE)
                End With

                If isNew Then
                    TabPage.Controls.Remove(lblCaricamento)
                    Application.DoEvents()
                End If

                .ResumeLayout()
            End With
        End Sub

        Private Sub RimuoviScheda(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim assicuratoFE As assicuratoFE = sender
            TryCast(preventivo, InfortuniPremium).Rimuoviassicurato(assicuratoFE.assicurato)
            preventivo.ValidaECalcola()
            PreventivoToControls()
            assicuratoFE.Parent.Dispose()

            'rinomina schede
            For i As Integer = 1 To TabControl1.Controls.Count - 3
                TabControl1.Controls(i).Text = "assicurato " & i
            Next
        End Sub

        Public Overrides Sub Apri(ByVal p As Prodotto)
            If p IsNot Nothing Then
                preventivo = p
                preventivo.Decode = decode
                preventivo.Inizializza()
                preventivo.ValidaECalcola()

                TabControl1.SuspendLayout()
                While TabControl1.Controls.Count > 3
                    TabControl1.Controls(2).Dispose()
                End While

                For Each assicurato As assicurato In TryCast(preventivo, InfortuniPremium).assicurati
                    AggiungiScheda(assicurato)
                Next

                PreventivoToControls()
                TabControl1.ResumeLayout()
            End If
        End Sub

    End Class
End Namespace
