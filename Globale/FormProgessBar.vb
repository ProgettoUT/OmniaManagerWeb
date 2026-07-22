Imports System.Drawing

Public Class FormProgessBar

    Public Annulla As Boolean = False

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Avanzamento processo"
        ProgressBar1.BackColor = SystemColors.Control
        ButtonAnnulla.BackColor = SystemColors.Control
    End Sub

    Private mColoreSfondo As Color
    Public Property Coloresforndo() As Color
        Get
            Return mColoreSfondo
        End Get
        Set(value As Color)
            mColoreSfondo = value
            Me.BackColor = Coloresforndo
        End Set
    End Property

    Public Property ProgressValue() As Integer
        Get
            Return ProgressBar1.Value
        End Get
        Set(value As Integer)
            'aggiorno la pb
            ProgressBar1.Value = value
            ProgressBar1.Refresh()
            'aggiorno l'etichetta
            LabelPerc.Text = Format(ProgressBar1.Value / ProgressBar1.Maximum, "###%")
            LabelPerc.Refresh()
        End Set
    End Property

    Private Sub FormProgessBar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Coloresforndo
        LabelMessaggio.Text = "Esportazione in corso..."
        LabelPerc.Text = ""
    End Sub

    Private Sub FormProgessBar_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Refresh()
    End Sub

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonAnnulla.Click

        If MsgBox("Annullare l'esportazione?",
                  MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question,
                  "Esportazione dati") = MsgBoxResult.Yes Then
            Annulla = True
        End If
    End Sub
End Class