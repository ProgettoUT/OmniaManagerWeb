Imports System.Windows.Forms
Imports System.Drawing

Public Class FormAttesa

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Size = New Drawing.Size(400, 140)
        Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        Me.ShowInTaskbar = False
        Me.Font = Utx.AppFont.Normal

        'imposta controlli
        With LabelMessaggio
            .Margin = New Padding(0)
            .Padding = New Padding(5)
            .BorderStyle = BorderStyle.Fixed3D
            .Text = ""
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With ButtonContinua
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .BackColor = Color.PaleGreen
            .Text = "Aspetta ancora..."
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With ButtonAnnulla
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .BackColor = Color.Moccasin
            .Text = "Annulla"
            .TextAlign = ContentAlignment.MiddleCenter
        End With
    End Sub

    Public Property Messaggio() As String
        Get
            Return LabelMessaggio.Text
        End Get
        Set(value As String)
            LabelMessaggio.Text = value
        End Set
    End Property

    Private Sub FormAttesa_Load(sender As Object, e As EventArgs) Handles Me.Load
        Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub FormAttesa_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.TopMost = True
        Me.Refresh()
    End Sub

    Private Sub LabelMessaggio_TextChanged(sender As Object, e As EventArgs) Handles LabelMessaggio.TextChanged
        LabelMessaggio.Refresh()
    End Sub

    Private Sub ButtonContinua_Click(sender As Object, e As EventArgs) Handles ButtonContinua.Click
        Me.DialogResult = Windows.Forms.DialogResult.Retry
    End Sub

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonAnnulla.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class