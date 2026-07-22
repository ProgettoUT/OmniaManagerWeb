Imports Budget

Public Class FormRappel

    Public Shared Log As New Utx.ApplicationLog("SimulatoreRappel.log")

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(900, 530)
        Me.Icon = Risorse.Immagini.Icon("rubik")
        Me.Font = Utx.AppFont.Normal

        InizializzaControllo({lblRappelPrincipaleRP, lblRappelPrincipaleRA, lblRappelPrincipaleRCG})
        InizializzaControllo({lblRappelRedditivitaRP, lblPercentualeCorrenteRP, lblRappelRedditivitaRA, lblPercentualeCorrenteRA})
        InizializzaControllo({lblRappelRP, lblRappelRA, lblRappelRCG})
        InizializzaControllo({TextBoxRapportoSPRP, TextBoxRapportoSPRA, TextBoxRapportoSPRCG, TextBoxRapportoSPNazionaleRP, TextBoxRapportoSPNazionaleRA, ComboBoxAnno, ComboBoxVita})
        InizializzaControllo({txtIncassiPrecedenteRP, txtIncassiPrecedenteRA, txtBudgetRP, txtBudgetRA, txtIncassiCorrenteRP, txtIncassiCorrenteRA, txtIncassiCorrenteRCG})
        InizializzaControllo({TextBoxIncassiNazionaliRP, TextBoxIncassiNazionaliRA, TextBoxPesoAgenziaRP, TextBoxPesoAgenziaRA, lblRappelIncentivoNazionaleRP, lblRappelIncentivoNazionaleRA})
        lblRappel.Font = Utx.AppFont.Bold(14)
        lblTitoloRP.Font = Utx.AppFont.Bold(12)
        lblTitoloRA.Font = Utx.AppFont.Bold(12)
        lblTitoloRCG.Font = Utx.AppFont.Bold(12)

        With buttonGuida
            .Image = Risorse.Immagini.Bitmap("help")
            .ImageAlign = ContentAlignment.MiddleRight
            .Text = "Guida"
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        With buttonChiudi
            .Image = Risorse.Immagini.Bitmap("esci")
            .ImageAlign = ContentAlignment.MiddleRight
            .Text = "Esci"
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        With CheckedListBoCodici
            .IntegralHeight = False
            .CheckOnClick = True
            For Each codice As String In Utx.EnteGestore.CodiciGestiti
                If codice = Utx.Globale.AgenziaRichiesta.CodiceAgenzia Then
                    .Items.Add(codice, True)
                Else
                    .Items.Add(codice, False)
                End If
            Next
        End With
        lblTotale.Font = Utx.AppFont.Bold(13)
        lblRappel.Text = "..."
    End Sub

    Private Sub FormRappel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Cursor = Cursors.WaitCursor

            For anno As Integer = Today.Year + 2 To 2017 Step -1
                ComboBoxAnno.Items.Add(anno)
            Next
            ComboBoxAnno.SelectedIndex = 3

            With ComboBoxVita.Items
                .Add("No")
                .Add("Si")
            End With
            ComboBoxVita.SelectedIndex = 0

            TextBoxRapportoSPRP.Text = 0
            TextBoxRapportoSPNazionaleRP.Text = 0
            TextBoxRapportoSPRA.Text = 0
            TextBoxRapportoSPNazionaleRA.Text = 0
            TextBoxRapportoSPRCG.Text = 0
            TextBoxPesoAgenziaRP.Text = 0
            TextBoxPesoAgenziaRA.Text = 0
        Catch ex As Exception
            FormRappel.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormRappel_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Application.DoEvents()
        CalcolaTotali()
        LeggiValoriSP()
        ButtonCalcola.PerformClick()
        AddHandler ComboBoxVita.SelectedIndexChanged, AddressOf ComboBoxVita_SelectedIndexChanged
        AddHandler ComboBoxAnno.SelectedIndexChanged, AddressOf ComboBoxAnno_SelectedIndexChanged
        AddHandler CheckedListBoCodici.SelectedValueChanged, AddressOf CheckedListBoCodici_SelectedValueChanged
    End Sub

    Private Sub LeggiValoriSP()
        Try
            Me.Cursor = Cursors.WaitCursor
            'leggo valori nazionali rappel nella forma
            '% naz.persone;% naz.aziende;incassi naz.persone;incassi naz aziende
            'i dati sono nel DB Servizi.mdb su utools.it
            Using s As New Utx.SettingAgenzia.ConfiguraSede
                'SP nazionali validi per tutte le agenzie
                Dim Nazionali As String = s.RappelNazionale(ComboBoxAnno.Text)
                If IsNothing(Nazionali) Then
                    CurrencyBox(TextBoxRapportoSPNazionaleRP) = 0
                    CurrencyBox(TextBoxRapportoSPNazionaleRA) = 0
                    CurrencyBox(TextBoxIncassiNazionaliRP) = 0
                    CurrencyBox(TextBoxIncassiNazionaliRA) = 0
                Else
                    CurrencyBox(TextBoxRapportoSPNazionaleRP) = Nazionali.Split(";")(0)
                    CurrencyBox(TextBoxRapportoSPNazionaleRA) = Nazionali.Split(";")(1)
                    CurrencyBox(TextBoxIncassiNazionaliRP) = Nazionali.Split(";")(2)
                    CurrencyBox(TextBoxIncassiNazionaliRA) = Nazionali.Split(";")(3)
                End If
                'sp agenzia
                CurrencyBox(TextBoxRapportoSPRP) = 0
                CurrencyBox(TextBoxRapportoSPRA) = 0
                CurrencyBox(TextBoxRapportoSPRCG) = 0
                For Each codice As String In CheckedListBoCodici.CheckedItems
                    Dim SpAgenzia As String = s.SpAgenzia(codice, ComboBoxAnno.Text)
                    If SpAgenzia <> "0;0;0" Then
                        'i dati SP sono del primo codice trovato sul server
                        CurrencyBox(TextBoxRapportoSPRP) = SpAgenzia.Split(";")(0)
                        CurrencyBox(TextBoxRapportoSPRA) = SpAgenzia.Split(";")(1)
                        CurrencyBox(TextBoxRapportoSPRCG) = SpAgenzia.Split(";")(2)
                        Exit For
                    End If
                Next
            End Using
        Catch ex As Exception
            FormRappel.Log.Errore(ex)
            CurrencyBox(TextBoxRapportoSPNazionaleRP) = 0
            CurrencyBox(TextBoxRapportoSPNazionaleRA) = 0
            CurrencyBox(TextBoxIncassiNazionaliRP) = 0
            CurrencyBox(TextBoxIncassiNazionaliRA) = 0
            CurrencyBox(TextBoxRapportoSPRP) = 0
            CurrencyBox(TextBoxRapportoSPRA) = 0
            CurrencyBox(TextBoxRapportoSPRCG) = 0
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Calcola()
        Try
            Dim incassoSuBadget As Decimal
            DetachEvents()
            'principale
            CurrencyBox(lblRappelPrincipaleRP) = RappelPrincipale(Value(TextBoxRapportoSPRP), CurrencyBox(txtIncassiPrecedenteRP), CurrencyBox(txtBudgetRP), CurrencyBox(txtIncassiCorrenteRP), (ComboBoxVita.SelectedItem = "Si"), incassoSuBadget)
            PercentualeBox(lblPercentualeCorrenteRP) = incassoSuBadget
            CurrencyBox(lblRappelPrincipaleRA) = RappelPrincipale(Value(TextBoxRapportoSPRA), CurrencyBox(txtIncassiPrecedenteRA), CurrencyBox(txtBudgetRA), CurrencyBox(txtIncassiCorrenteRA), (ComboBoxVita.SelectedItem = "Si"), incassoSuBadget)
            PercentualeBox(lblPercentualeCorrenteRA) = incassoSuBadget
            CurrencyBox(lblRappelPrincipaleRCG) = RappelRCG(Value(TextBoxRapportoSPRCG), CurrencyBox(txtIncassiCorrenteRCG))
            'reddività
            CurrencyBox(lblRappelRedditivitaRP) = RappelRedditivita(TextBoxRapportoSPRP.Text, CurrencyBox(txtIncassiPrecedenteRP), CurrencyBox(txtBudgetRP), CurrencyBox(txtIncassiCorrenteRP), (ComboBoxVita.SelectedItem = "Si"))
            CurrencyBox(lblRappelRedditivitaRA) = RappelRedditivita(Value(TextBoxRapportoSPRA), CurrencyBox(txtIncassiPrecedenteRA), CurrencyBox(txtBudgetRA), CurrencyBox(txtIncassiCorrenteRA), (ComboBoxVita.SelectedItem = "Si"))
            'nazionale + peso incassi
            CurrencyBox(lblRappelIncentivoNazionaleRP) = RappelPesoIncassiRamiPersona(Value(TextBoxRapportoSPNazionaleRP), Value(TextBoxIncassiNazionaliRP), Value(TextBoxPesoAgenziaRP), ComboBoxAnno.SelectedItem)
            CurrencyBox(lblRappelIncentivoNazionaleRA) = RappelPesoIncassiRamiAziende(Value(TextBoxRapportoSPNazionaleRA), Value(TextBoxIncassiNazionaliRA), Value(TextBoxPesoAgenziaRA), ComboBoxAnno.SelectedItem)
            'sub-totali
            CurrencyBox(lblRappelRP) = CurrencyBox(lblRappelPrincipaleRP) + CurrencyBox(lblRappelRedditivitaRP) + CurrencyBox(lblRappelIncentivoNazionaleRP)
            CurrencyBox(lblRappelRA) = CurrencyBox(lblRappelPrincipaleRA) + CurrencyBox(lblRappelRedditivitaRA) + CurrencyBox(lblRappelIncentivoNazionaleRA)
            CurrencyBox(lblRappelRCG) = CurrencyBox(lblRappelPrincipaleRCG)
            'totale generale
            CurrencyBox(lblRappel) = CurrencyBox(lblRappelRP) + CurrencyBox(lblRappelRA) + CurrencyBox(lblRappelRCG)
            AttachEvents()
        Catch ex As Exception
            FormRappel.Log.Errore(ex)
        End Try
    End Sub

    Sub AttachEvents()
        AddHandler txtIncassiPrecedenteRP.Leave, AddressOf ValuesChanged
        AddHandler txtIncassiPrecedenteRP.KeyPress, AddressOf TextBoxKeyPress
        AddHandler txtBudgetRP.Leave, AddressOf ValuesChanged
        AddHandler txtBudgetRP.KeyPress, AddressOf TextBoxKeyPress
        AddHandler txtIncassiCorrenteRP.Leave, AddressOf ValuesChanged
        AddHandler txtIncassiCorrenteRP.KeyPress, AddressOf TextBoxKeyPress

        AddHandler txtIncassiPrecedenteRA.Leave, AddressOf ValuesChanged
        AddHandler txtIncassiPrecedenteRA.KeyPress, AddressOf TextBoxKeyPress
        AddHandler txtBudgetRA.Leave, AddressOf ValuesChanged
        AddHandler txtBudgetRA.KeyPress, AddressOf TextBoxKeyPress
        AddHandler txtIncassiCorrenteRA.Leave, AddressOf ValuesChanged
        AddHandler txtIncassiCorrenteRA.KeyPress, AddressOf TextBoxKeyPress
        AddHandler txtIncassiCorrenteRCG.Leave, AddressOf ValuesChanged
        AddHandler txtIncassiCorrenteRCG.KeyPress, AddressOf TextBoxKeyPress

        AddHandler ComboBoxVita.SelectedValueChanged, AddressOf ValuesChanged
        AddHandler ComboBoxAnno.SelectedValueChanged, AddressOf ValuesChanged
        AddHandler TextBoxRapportoSPRP.LostFocus, AddressOf ValuesChanged
        AddHandler TextBoxRapportoSPRA.LostFocus, AddressOf ValuesChanged
        AddHandler TextBoxRapportoSPRCG.LostFocus, AddressOf ValuesChanged
        AddHandler TextBoxRapportoSPNazionaleRP.LostFocus, AddressOf ValuesChanged
        AddHandler TextBoxRapportoSPNazionaleRA.LostFocus, AddressOf ValuesChanged
        AddHandler TextBoxIncassiNazionaliRP.LostFocus, AddressOf ValuesChanged
        AddHandler TextBoxIncassiNazionaliRA.LostFocus, AddressOf ValuesChanged
        AddHandler TextBoxPesoAgenziaRP.LostFocus, AddressOf ValuesChanged
        AddHandler TextBoxPesoAgenziaRA.LostFocus, AddressOf ValuesChanged
    End Sub

    Sub DetachEvents()
        RemoveHandler txtIncassiPrecedenteRP.Leave, AddressOf ValuesChanged
        RemoveHandler txtIncassiPrecedenteRP.KeyPress, AddressOf TextBoxKeyPress
        RemoveHandler txtBudgetRP.Leave, AddressOf ValuesChanged
        RemoveHandler txtBudgetRP.KeyPress, AddressOf TextBoxKeyPress
        RemoveHandler txtIncassiCorrenteRP.Leave, AddressOf ValuesChanged
        RemoveHandler txtIncassiCorrenteRP.KeyPress, AddressOf TextBoxKeyPress

        RemoveHandler txtIncassiPrecedenteRA.Leave, AddressOf ValuesChanged
        RemoveHandler txtIncassiPrecedenteRA.KeyPress, AddressOf TextBoxKeyPress
        RemoveHandler txtBudgetRA.Leave, AddressOf ValuesChanged
        RemoveHandler txtBudgetRA.KeyPress, AddressOf TextBoxKeyPress
        RemoveHandler txtIncassiCorrenteRA.Leave, AddressOf ValuesChanged
        RemoveHandler txtIncassiCorrenteRA.KeyPress, AddressOf TextBoxKeyPress
        RemoveHandler txtIncassiCorrenteRCG.Leave, AddressOf ValuesChanged
        RemoveHandler txtIncassiCorrenteRCG.KeyPress, AddressOf TextBoxKeyPress

        RemoveHandler ComboBoxVita.SelectedValueChanged, AddressOf ValuesChanged
        RemoveHandler ComboBoxAnno.SelectedValueChanged, AddressOf ValuesChanged
        RemoveHandler TextBoxRapportoSPRP.LostFocus, AddressOf ValuesChanged
        RemoveHandler TextBoxRapportoSPRA.LostFocus, AddressOf ValuesChanged
        RemoveHandler TextBoxRapportoSPRCG.LostFocus, AddressOf ValuesChanged
        RemoveHandler TextBoxRapportoSPNazionaleRP.LostFocus, AddressOf ValuesChanged
        RemoveHandler TextBoxRapportoSPNazionaleRA.LostFocus, AddressOf ValuesChanged
        RemoveHandler TextBoxIncassiNazionaliRP.LostFocus, AddressOf ValuesChanged
        RemoveHandler TextBoxIncassiNazionaliRA.LostFocus, AddressOf ValuesChanged
        RemoveHandler TextBoxPesoAgenziaRP.LostFocus, AddressOf ValuesChanged
        RemoveHandler TextBoxPesoAgenziaRA.LostFocus, AddressOf ValuesChanged
    End Sub

    Sub ValuesChanged(sender As System.Object, e As System.EventArgs)
        If TypeOf sender Is TextBox Then
            If IsNumeric(sender.text) Then
                CurrencyBox(sender) = sender.text
            Else
                CurrencyBox(sender) = 0D
            End If
        End If
    End Sub

    Sub TextBoxKeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = vbCr Then
            ValuesChanged(sender, e)
        End If
    End Sub

    Public Property CurrencyBox(textbox As TextBox) As String
        Get
            Dim output As Decimal = 0D
            If Decimal.TryParse(textbox.Text, output) Then
                Return output
            Else
                Return 0D
            End If
        End Get
        Set(value As String)
            If textbox.Name.ToLower.Contains("peso") Then
                textbox.Text = FormatNumber(value, 4)
            Else
                textbox.Text = FormatNumber(value, 2)
            End If
        End Set
    End Property

    Public Property CurrencyBox(label As Label) As Decimal
        Get
            Dim output As Decimal = 0D
            If Decimal.TryParse(label.Text, output) Then
                Return output
            Else
                Return 0D
            End If
        End Get
        Set(value As Decimal)
            label.Text = FormatNumber(value, 2)
        End Set
    End Property

    Public Property PercentualeBox(textbox As Label) As Decimal
        Get
            Dim outtag As Decimal = 0D
            Decimal.TryParse(textbox.Tag, outtag)
            Return outtag
        End Get
        Set(value As Decimal)
            textbox.Tag = value
            textbox.Text = FormatNumber(value * 100D, 2) & "%"
        End Set
    End Property

    Public Function Value(Text As TextBox) As Decimal
        Dim s As String = Text.Text
        If s Is Nothing Then s = ""
        Dim output As Decimal = 0D
        Dim variazione As Decimal = 0D
        s = s.Replace("%", "").Replace("=", "")

        If s.Contains(">") Then
            s = s.Replace(">", "")
            variazione = 1
        End If

        If s.Contains("<") Then
            s = s.Replace("<", "")
            variazione = -1
        End If

        If Decimal.TryParse(s.Replace("%", ""), output) Then
            Return (output + variazione) / 100
        Else
            Return 0D
        End If
    End Function

    Public Function Value(combo As ComboBox) As Decimal
        Dim s As String = combo.SelectedItem
        If s Is Nothing Then s = ""
        Dim output As Decimal = 0D
        Dim variazione As Decimal = 0D
        s = s.Replace("%", "").Replace("=", "")

        If s.Contains(">") Then
            s = s.Replace(">", "")
            variazione = 1
        End If

        If s.Contains("<") Then
            s = s.Replace("<", "")
            variazione = -1
        End If

        If Decimal.TryParse(s.Replace("%", ""), output) Then
            Return (output + variazione) / 100
        Else
            Return 0D
        End If
    End Function

    Public Sub InizializzaControllo(controlli() As Control)
        For Each c As Control In controlli
            c.Font = Utx.AppFont.Bold
        Next
    End Sub

    Private Sub buttonChiudi_Click(sender As Object, e As EventArgs) Handles buttonChiudi.Click
        Me.Close()
    End Sub

    Private Sub buttonGuida_Click(sender As Object, e As EventArgs) Handles buttonGuida.Click
        Process.Start("http://www.utools.it/Unitools/Download/HelpSimulatore.pdf")
    End Sub

    Private Sub lblRappel_TextChanged(sender As Object, e As EventArgs) Handles lblRappel.TextChanged
        lblRappel.Refresh()
    End Sub

    Private Sub ButtonCalcola_Click(sender As Object, e As EventArgs) Handles ButtonCalcola.Click
        Try
            If CheckedListBoCodici.CheckedItems.Count = 0 Then
                MsgBox("Selezionare almeno un codice gestito", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor

            Calcola()
        Catch ex As Exception
            FormRappel.Log.Errore(ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CalcolaTotali()
        Try
            Cursor.Current = Cursors.WaitCursor
            lblRappel.Text = "..."

            lblIncassiAnnoPrecedente.Text = "Incassi anno " & (ComboBoxAnno.SelectedItem - 1)
            lblBudgetAnnoCorrente.Text = "Budget anno " & ComboBoxAnno.SelectedItem
            lblIncassiAnnoCorrente.Text = "Incassi anno " & ComboBoxAnno.SelectedItem

            CurrencyBox(txtIncassiPrecedenteRP) = 0
            CurrencyBox(txtIncassiPrecedenteRA) = 0
            CurrencyBox(txtBudgetRP) = 0
            CurrencyBox(txtBudgetRA) = 0
            CurrencyBox(txtIncassiCorrenteRP) = 0
            CurrencyBox(txtIncassiCorrenteRA) = 0
            CurrencyBox(txtIncassiCorrenteRCG) = 0
            Me.Refresh()

            Dim Sim As New Budget.SimulatoreRappel(ComboBoxAnno.Text)
            Sim.Codici.Clear()
            For Each codice As String In CheckedListBoCodici.CheckedItems
                Sim.Codici.Add(codice)
            Next

            Sim.CalcolaImporti()

            CurrencyBox(txtIncassiPrecedenteRP) = Sim.IncassiPersonaPrecedenti
            CurrencyBox(txtIncassiPrecedenteRA) = Sim.IncassiAziendePrecedenti

            CurrencyBox(txtBudgetRP) = Sim.BudgetPersone
            CurrencyBox(txtBudgetRA) = Sim.BudgetAziende

            CurrencyBox(txtIncassiCorrenteRP) = Sim.IncassiPersona
            CurrencyBox(txtIncassiCorrenteRA) = Sim.IncassiAziende
            CurrencyBox(txtIncassiCorrenteRCG) = Sim.IncassiRcg

            LeggiValoriSP()
        Catch ex As Exception
            FormRappel.Log.Errore(ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub CheckedListBoCodici_SelectedValueChanged(sender As Object, e As EventArgs)
        CalcolaTotali()
    End Sub

    Private Sub ComboBoxAnno_SelectedIndexChanged(sender As Object, e As EventArgs)
        CalcolaTotali()
    End Sub

    Private Sub ButtonSelezionaTutti_Click(sender As Object, e As EventArgs) Handles ButtonSelezionaTutti.Click
        If CheckedListBoCodici.Items.Count > CheckedListBoCodici.CheckedItems.Count Then
            RemoveHandler CheckedListBoCodici.SelectedValueChanged, AddressOf CheckedListBoCodici_SelectedValueChanged
            For k As Integer = 0 To CheckedListBoCodici.Items.Count - 1
                CheckedListBoCodici.SetItemChecked(k, True)
            Next
            CheckedListBoCodici.Refresh()
            CalcolaTotali()
            AddHandler CheckedListBoCodici.SelectedValueChanged, AddressOf CheckedListBoCodici_SelectedValueChanged
        End If
    End Sub

    Private Sub ComboBoxVita_SelectedIndexChanged(sender As Object, e As EventArgs)
        If ComboBoxVita.SelectedIndex = 0 Then
            'vita NO
            CalcolaTotali()
        Else
            'vita SI
            lblRappel.Text = "..."
            CurrencyBox(txtBudgetRP) = Rappel.BudgetRimodulato(txtIncassiPrecedenteRP.Text, txtBudgetRP.Text, (ComboBoxVita.SelectedIndex = 1))
            CurrencyBox(txtBudgetRA) = Rappel.BudgetRimodulato(txtIncassiPrecedenteRA.Text, txtBudgetRA.Text, (ComboBoxVita.SelectedIndex = 1))
        End If
    End Sub

    Private Sub AzzeraAvanzamentoRP(sender As Object, e As EventArgs) Handles txtBudgetRP.TextChanged, txtIncassiCorrenteRP.TextChanged
        PercentualeBox(lblPercentualeCorrenteRP) = 0
    End Sub

    Private Sub AzzeraAvanzamentoRA(sender As Object, e As EventArgs) Handles txtBudgetRA.TextChanged, txtIncassiCorrenteRA.TextChanged
        PercentualeBox(lblPercentualeCorrenteRA) = 0
    End Sub
End Class