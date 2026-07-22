Public Class P00000FE
    Public preventivo As Prodotto
    Protected decode As P00000DE
    Public helpChm As New HelpClass

    Public Event ClickedHelp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    Public Event ControlsToPreventivoEvent(ByVal preventivo As Prodotto, ByVal diretto As Boolean)

    Protected Overridable Sub AttachEvents()
    End Sub
    Protected Overridable Sub DetachEvents()
    End Sub
    Protected Overridable Sub ControlsToPreventivo(ByVal diretto As Boolean)
    End Sub

    Protected Sub TextBoxKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = vbCr Then
            ValuesChanged(sender, e)
        End If
    End Sub

    Public Overridable Sub ValuesChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ControlsToPreventivo()
        preventivo.ValidaECalcola()
        PreventivoToControls()
        HighlightCheckAndLabel(Panels)
    End Sub

    Protected Sub ControlsToPreventivo()
        RaiseEvent ControlsToPreventivoEvent(preventivo, True)
        QuotatorePremio.ControlsToPreventivo(preventivo, True)
        ControlsToPreventivo(True)
    End Sub

    Protected Sub PreventivoToControls()
        DetachEvents()
        RaiseEvent ControlsToPreventivoEvent(preventivo, False)
        QuotatorePremio.ControlsToPreventivo(preventivo, False)
        ControlsToPreventivo(False)
        AttachEvents()

        If preventivo.RischioDirezione = StatoPremio.ClasseOK Then
            lblMessaggi.Text = ""
            lblMessaggi.BackColor = Nothing
        Else
            lblMessaggi.Text = preventivo.DescrizioneRD
            lblMessaggi.BackColor = Color.Coral
        End If
    End Sub

    Public Sub MouseClickedHelp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        helpChm.ShowHelp(sender)
        RaiseEvent ClickedHelp(sender, e)
    End Sub

    Public Overridable Sub Salva()
        ControlsToPreventivo()
        DataManager.SalvaPreventivo(preventivo)
    End Sub

    Public Overridable Sub Apri(ByVal p As Prodotto)
        If p IsNot Nothing Then
            preventivo = p
            preventivo.Decode = decode
            preventivo.Inizializza()
            preventivo.ValidaECalcola()
            PreventivoToControls()
        End If
    End Sub

    'Public Overridable Sub Stampa(ByVal options As StampaOptions)
    '    ControlsToPreventivo()
    '    preventivo.Stampa(options)
    'End Sub

    Private Sub docIndiceClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles docIndice.Click
        docBrowser.Navigate(docBrowser.Tag)
    End Sub


    Private mPanels As TableLayoutPanel()
    Public Property Panels() As TableLayoutPanel()
        Get
            Return mPanels
        End Get
        Set(ByVal value As TableLayoutPanel())
            mPanels = value
            AgganciaCheckAndLabel(value)
        End Set
    End Property

End Class
