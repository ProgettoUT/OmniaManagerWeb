Imports System.Drawing
Imports System.Windows.Forms

Public Class ucNavigationBar

    Public Event ButtonClick(ButtonIndex As ButtonType)

    Public Enum ButtonType
        PRIMO
        ULTIMO
        PROSSIMO
        PRECEDENTE
        MENO
        CENTO
        PIU
    End Enum

    Public WithEvents ButtonMeno As New UtFlatButton
    Public WithEvents Button100 As New UtFlatButton
    Public WithEvents ButtonPiu As New UtFlatButton
    Public WithEvents ButtonPrimo As New UtFlatButton
    Public WithEvents ButtonUltimo As New UtFlatButton
    Public WithEvents ButtonProssimo As New UtFlatButton
    Public WithEvents ButtonPrecedente As New UtFlatButton

    Private mColoreBordo As Color = Color.LightGray

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Margin = New Padding(0)

        ImpostaControlli()
    End Sub

    Sub New(ColoreBordo As Color)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Margin = New Padding(0)

        mColoreBordo = ColoreBordo

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()

        On Error Resume Next

        'zoom
        With ButtonMeno
            .DefaultBorderSize = 1
            .Dock = DockStyle.Fill
            .FlatAppearance.BorderColor = mColoreBordo
            .Image = Risorse.Immagini.Bitmap("Meno")
            .SetToolTip("diminuisci zoom")
        End With
        tlpMain.SetCellPosition(ButtonMeno, New TableLayoutPanelCellPosition(0, 0))
        With Button100
            .DefaultBorderSize = 1
            .Dock = DockStyle.Fill
            .FlatAppearance.BorderColor = mColoreBordo
            .Image = Risorse.Immagini.Bitmap("_100")
            .SetToolTip("100 %")
        End With
        tlpMain.SetCellPosition(Button100, New TableLayoutPanelCellPosition(1, 0))
        With ButtonPiu
            .DefaultBorderSize = 1
            .Dock = DockStyle.Fill
            .FlatAppearance.BorderColor = mColoreBordo
            .Image = Risorse.Immagini.Bitmap("Piu")
            .SetToolTip("aumenta zoom")
        End With
        tlpMain.SetCellPosition(ButtonPiu, New TableLayoutPanelCellPosition(2, 0))
        'bottoni navigazione
        With ButtonPrimo
            .DefaultBorderSize = 1
            .Dock = DockStyle.Fill
            .FlatAppearance.BorderColor = mColoreBordo
            .Image = Risorse.Immagini.Bitmap("first")
            .SetToolTip("primo record")
        End With
        tlpMain.SetCellPosition(ButtonPrimo, New TableLayoutPanelCellPosition(3, 0))
        With ButtonPrecedente
            .DefaultBorderSize = 1
            .Dock = DockStyle.Fill
            .FlatAppearance.BorderColor = mColoreBordo
            .Image = Risorse.Immagini.Bitmap("previous")
            .SetToolTip("record precedente")
        End With
        tlpMain.SetCellPosition(ButtonPrecedente, New TableLayoutPanelCellPosition(4, 0))
        With ButtonProssimo
            .DefaultBorderSize = 1
            .Dock = DockStyle.Fill
            .FlatAppearance.BorderColor = mColoreBordo
            .Image = Risorse.Immagini.Bitmap("_next")
            .SetToolTip("record seguente")
        End With
        tlpMain.SetCellPosition(ButtonProssimo, New TableLayoutPanelCellPosition(5, 0))
        With ButtonUltimo
            .DefaultBorderSize = 1
            .Dock = DockStyle.Fill
            .FlatAppearance.BorderColor = mColoreBordo
            .Image = Risorse.Immagini.Bitmap("last")
            .SetToolTip("ultimo record")
        End With
        tlpMain.SetCellPosition(ButtonUltimo, New TableLayoutPanelCellPosition(6, 0))

        With tlpMain
            .Controls.Add(ButtonMeno)
            .Controls.Add(Button100)
            .Controls.Add(ButtonPiu)
            .Controls.Add(ButtonPrimo)
            .Controls.Add(ButtonPrecedente)
            .Controls.Add(ButtonProssimo)
            .Controls.Add(ButtonUltimo)
        End With
    End Sub

    Public Property AbilitaZoom() As Boolean
        Get
            Return Button100.Enabled
        End Get
        Set(value As Boolean)
            ButtonMeno.Enabled = value
            ButtonPiu.Enabled = value
            Button100.Enabled = value
        End Set
    End Property

    Public Sub AbilitaNavigazione(Abilita As Boolean)
        ButtonPrimo.Enabled = Abilita
        ButtonUltimo.Enabled = Abilita
        ButtonPrecedente.Enabled = Abilita
        ButtonProssimo.Enabled = Abilita
    End Sub

    Private Sub ButtonPrimo_Click(sender As Object, e As EventArgs) Handles ButtonPrimo.Click
        RaiseEvent ButtonClick(ButtonType.PRIMO)
    End Sub

    Private Sub ButtonUltimo_Click(sender As Object, e As EventArgs) Handles ButtonUltimo.Click
        RaiseEvent ButtonClick(ButtonType.ULTIMO)
    End Sub

    Private Sub ButtonProssimo_Click(sender As Object, e As EventArgs) Handles ButtonProssimo.Click
        RaiseEvent ButtonClick(ButtonType.PROSSIMO)
    End Sub

    Private Sub ButtonPrecedente_Click(sender As Object, e As EventArgs) Handles ButtonPrecedente.Click
        RaiseEvent ButtonClick(ButtonType.PRECEDENTE)
    End Sub

    Private Sub ButtonPiu_Click(sender As Object, e As EventArgs) Handles ButtonPiu.Click
        RaiseEvent ButtonClick(ButtonType.PIU)
    End Sub

    Private Sub ButtonMeno_Click(sender As Object, e As EventArgs) Handles ButtonMeno.Click
        RaiseEvent ButtonClick(ButtonType.MENO)
    End Sub

    Private Sub Button100_Click(sender As Object, e As EventArgs) Handles Button100.Click
        RaiseEvent ButtonClick(ButtonType.CENTO)
    End Sub
End Class
