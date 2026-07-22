Public Class QuotatorePremio
    Public Event QuotatorePremioChanged(ByVal sender As Object, ByVal e As EventArgs)
    Public Event ClickedHelp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    Private PremioFlex As Decimal = 0D

    Public Sub New()
        InitializeComponent()
        txtDurata.Text = "1"
        AttachCombo(cmbPeriodo, P00000DE.DecodePeriodo)
        AttachEvents()
    End Sub

    Private Sub AttachEvents()
        AddHandler NoteProdotto.NoteChanged, AddressOf EnableControls
        AddHandler CheckBox1.CheckedChanged, AddressOf EnableControls
        AddHandler cmbFrazionamento.SelectedIndexChanged, AddressOf EnableControls
        AddHandler txtDurata.Leave, AddressOf EnableControls
        AddHandler txtDurata.KeyPress, AddressOf TextBoxKeyPress
        AddHandler cmbPeriodo.SelectedIndexChanged, AddressOf EnableControls
    End Sub


    Public Sub ControlsToPreventivo(ByVal preventivo As Prodotto, ByVal diretto As Boolean)
        If diretto Then
            preventivo.Note = NoteProdotto.TextNote
            preventivo.Frazionamento = cmbFrazionamento.SelectedValue
            preventivo.Periodo = cmbPeriodo.SelectedValue
            Integer.TryParse(txtDurata.Text, preventivo.Durata)
            preventivo.Indicizzazione = EnabledAndChecked(CheckBox1)
            preventivo.Flexi = PercentualeBox(txtFlex)
            '.Convivente = IIf(txtClienteConvivente.Text = txtClienteConvivente.Tag, "", txtClienteConvivente.Text)
            preventivo.Convenzione.Percentuale = PercentualeBox(txtCovenzione)

            preventivo.Convenzione.Descrizione = If(txtCovenzioneList.Text.Equals(txtCovenzioneList.Tag), "", txtCovenzioneList.Text)

            'If txtCovenzioneList.TextLength > 5 Then
            '    preventivo.Convenzione.Codice = If(txtCovenzioneList.Text.Equals(txtCovenzioneList.Tag), "", txtCovenzioneList.Text.Substring(0, 5))
            'ElseIf txtCovenzioneList.TextLength > 0 Then
            '    preventivo.Convenzione.Codice = txtCovenzioneList.Text
            'End If
            'If txtCovenzioneList.TextLength > 6 Then
            '    preventivo.Convenzione.Descrizione = If(txtCovenzioneList.Text.Equals(txtCovenzioneList.Tag), "", txtCovenzioneList.Text.Substring(6))
            'End If

            If preventivo.Frazionamento <> FrazionamentiEnum.Temporaneo Then
                preventivo.Periodo = PeriodoEnum.Anni
            ElseIf preventivo.Periodo = PeriodoEnum.Anni Or preventivo.Periodo = PeriodoEnum.Nessuno Then
                preventivo.Periodo = PeriodoEnum.Mesi
            End If
        Else
            If preventivo.Frazionamento <> FrazionamentiEnum.Temporaneo Then
                preventivo.Periodo = PeriodoEnum.Anni
            ElseIf preventivo.Periodo = PeriodoEnum.Anni Or preventivo.Periodo = PeriodoEnum.Nessuno Then
                preventivo.Periodo = PeriodoEnum.Mesi
            End If
            NoteProdotto.TextNote = preventivo.Note
            cmbFrazionamento.SelectedValue = CInt(preventivo.Frazionamento)
            lblRata.Text = "Rata " & preventivo.Decode.DecodeFrazionamenti(preventivo.Frazionamento)
            cmbPeriodo.SelectedValue = CInt(preventivo.Periodo)
            txtDurata.Text = CStr(preventivo.Durata)
            EnabledAndChecked(CheckBox1) = preventivo.Indicizzazione
            PercentualeBox(txtFlex) = preventivo.Flexi
            txtCovenzioneList.Text = If(preventivo.Convenzione.Descrizione <> "", preventivo.Convenzione.Descrizione, CStr(txtCovenzioneList.Tag))
            'txtCovenzioneList.Text = If(preventivo.Convenzione.Codice <> "00000", preventivo.Convenzione.Codice & "-" & preventivo.Convenzione.Descrizione, txtCovenzioneList.Tag)
            PercentualeBox(txtCovenzione) = preventivo.Convenzione.Percentuale

            txtFlex.ReadOnly = preventivo.EscludiFlex
            txtScontoFlex.ReadOnly = preventivo.EscludiFlex

            '23 febbraio 2016: Gilberto dice che convenzione e flex si escludono a vicenda
            txtCovenzione.Enabled = (preventivo.Flexi = 0)
            txtCovenzioneList.Enabled = (preventivo.Flexi = 0)
            txtFlex.Enabled = (preventivo.Convenzione.Percentuale = 0)
            txtScontoFlex.Enabled = (preventivo.Convenzione.Percentuale = 0)
        End If

        'risultati
        If diretto = False Then
            If preventivo.RischioDirezione > 0 Then
                PremioFlex = 0D
                txtListinoLordo.Text = FormatEuro(0D)
                txtImponibile.Text = FormatEuro(0D)
                txtTasse.Text = FormatEuro(0D)
                txtTotale.Text = FormatEuro(0D)
                txtScontoFlex.Text = FormatEuro(0D)
                txtInteressi.Text = FormatEuro(0D)
                txtPremioAnnuo.Text = FormatEuro(0D)
                txtPremioTotale.Text = FormatEuro(0D)
            Else
                PremioFlex = preventivo.PremioFlexi
                txtListinoLordo.Text = FormatEuro(preventivo.ListinoLordo)
                txtImponibile.Text = FormatEuro(preventivo.PremioNetto)
                txtTasse.Text = FormatEuro(preventivo.PremioTasse)
                txtTotale.Text = FormatEuro(preventivo.PremioLordo)
                txtScontoFlex.Text = FormatEuro(preventivo.ScontoFlexi)
                txtInteressi.Text = FormatEuro(preventivo.Interessi)
                txtPremioAnnuo.Text = FormatEuro(preventivo.PremioAnnuo)
                txtPremioTotale.Text = FormatEuro(preventivo.PremioPrimaRata)
            End If
        End If
    End Sub

    Private Sub EnableControls(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent QuotatorePremioChanged(Me, New EventArgs())
    End Sub

    Private Sub TextBoxKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = vbCr Then
            EnableControls(sender, e)
        End If
    End Sub

    Public Property Image() As Image
        Get
            Return PictureBox1.Image
        End Get
        Set(ByVal value As Image)
            PictureBox1.Image = value
        End Set
    End Property

    Private Sub txtScontoFlex_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtScontoFlex.MouseDoubleClick
        If ModalitaVisualizzazione = ModalitaVisualizzazionePremi.ListinoLordo Then
            ModalitaVisualizzazione = ModalitaVisualizzazionePremi.ListinoNetto
            'txtScontoFlex.BackColor = Color.Salmon
            lblModalitaVisualizzazione.Text = "L Netto"
        ElseIf ModalitaVisualizzazione = ModalitaVisualizzazionePremi.ListinoNetto Then
            ModalitaVisualizzazione = ModalitaVisualizzazionePremi.PremioLordo
            'txtScontoFlex.BackColor = Color.LightGreen
            lblModalitaVisualizzazione.Text = "P Lordo"
        ElseIf ModalitaVisualizzazione = ModalitaVisualizzazionePremi.PremioLordo Then
            ModalitaVisualizzazione = ModalitaVisualizzazionePremi.PremioNetto
            'txtScontoFlex.BackColor = Color.Azure
            lblModalitaVisualizzazione.Text = "P Netto"
        ElseIf ModalitaVisualizzazione = ModalitaVisualizzazionePremi.PremioNetto Then
            ModalitaVisualizzazione = ModalitaVisualizzazionePremi.ListinoLordo
            'txtScontoFlex.BackColor = Color.LightCoral
            lblModalitaVisualizzazione.Text = "L Lordo"
        End If
        EnableControls(sender, e)
    End Sub

    Private Sub txtPercentuale_Leave(ByVal sender As TextBox, ByVal e As System.EventArgs) Handles txtFlex.Leave, txtCovenzione.Leave
        Dim percentuale As Decimal = 0D
        Decimal.TryParse(CStr(sender.Text), percentuale)
        percentuale = percentuale / 100
        If percentuale >= 1D Then
            percentuale = 0.99D
        ElseIf percentuale < 0D Then
            percentuale = 0D
        End If
        PercentualeBox(sender) = percentuale
        EnableControls(sender, e)
    End Sub

    Private Sub txtPercentuale_KeyPress(ByVal sender As TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFlex.KeyPress, txtCovenzione.KeyPress
        If e.KeyChar = vbCr Then
            txtPercentuale_Leave(sender, e)
        End If
    End Sub

    Private Sub txtScontoFlex_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScontoFlex.Leave
        If PremioFlex <> 0 Then
            Dim percentuale As Decimal = CurrencyBox(txtScontoFlex) / PremioFlex
            If percentuale >= 1 Then
                percentuale = 0.99D
            ElseIf percentuale < 0 Then
                percentuale = 0
            End If
            PercentualeBox(txtFlex) = percentuale
            EnableControls(sender, e)
        End If
    End Sub

    Private Sub txtScontoFlex_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtScontoFlex.KeyPress
        If e.KeyChar = vbCr Then
            txtScontoFlex_Leave(sender, e)
        End If
    End Sub

    Private Sub txtCovenzioneList_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCovenzioneList.Enter
        If txtCovenzioneList.Text = CStr(txtCovenzioneList.Tag) Then
            txtCovenzioneList.Text = ""
        End If
    End Sub

    Private Sub txtCovenzioneList_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCovenzioneList.Leave
        If txtCovenzioneList.Text = "" Then
            txtCovenzioneList.Text = CStr(txtCovenzioneList.Tag)
        End If
        EnableControls(sender, e)
    End Sub

    Private Sub txtCovenzioneList_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCovenzioneList.KeyPress
        If e.KeyChar = vbCr Then
            txtCovenzioneList_Leave(sender, e)
        End If
    End Sub

    Private Sub cmdHelp_Click(sender As Object, e As EventArgs) Handles cmdHelp.Click
        Dim p As P00000FE = CType(Me.Parent.Parent.Parent.Parent, P00000FE)
        p.helpChm.RunHelp()
    End Sub
End Class
