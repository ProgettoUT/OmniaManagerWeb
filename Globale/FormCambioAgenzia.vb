Imports System.Drawing
Imports System.Windows.Forms

Public Class FormCambioAgenzia

    Public Event CambioCodice(Codice As String)
    Public Property CodiceSelezionato As String

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Font = Utx.AppFont.Normal
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Size = New Size(180, 250)
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(Math.Max(0, Cursor.Position.X - Me.Width), Math.Max(0, Cursor.Position.Y - Me.Height))
        Me.Icon = Risorse.Immagini.Icon("cambiaagenzia")
        Me.Text = "Codici gestiti"

        With ListBoxAgenzie
            .Font = New Font("Tahoma", 12, FontStyle.Bold)
            .Sorted = True
            .IntegralHeight = False
        End With

        With ButtonCambia
            .Padding = New Padding(5, 0, 5, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
            .Text = "Seleziona"
            .TextAlign = ContentAlignment.MiddleCenter
        End With
    End Sub

    Private Sub FormCambioAgenzia_Load(sender As Object, e As EventArgs) Handles Me.Load
        For Each a As String In Utx.EnteGestore.CodiciGestiti
            ListBoxAgenzie.Items.Add(a)

            If a = Utx.Globale.AgenziaRichiesta.CodiceAgenzia Then
                ListBoxAgenzie.SelectedIndex = ListBoxAgenzie.Items.Count - 1
            End If
        Next
    End Sub

    Private Sub ListBoxAgenzie_DoubleClick(sender As Object, e As EventArgs) Handles ListBoxAgenzie.DoubleClick
        ButtonCambia_Click(ListBoxAgenzie, New EventArgs)
    End Sub

    Private Sub ListBoxAgenzie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxAgenzie.SelectedIndexChanged
        ButtonCambia.Text = String.Format("Seleziona {0}", ListBoxAgenzie.Text)
    End Sub

    Private Sub ButtonCambia_Click(sender As Object, e As EventArgs) Handles ButtonCambia.Click
        Me.Visible = False
        If (ListBoxAgenzie.Text.Length > 0) AndAlso (Utx.Globale.AgenziaRichiesta.CodiceAgenzia <> ListBoxAgenzie.Text) Then
            CodiceSelezionato = ListBoxAgenzie.Text
            RaiseEvent CambioCodice(ListBoxAgenzie.Text)
        Else
            CodiceSelezionato = Nothing
            RaiseEvent CambioCodice(Nothing)
        End If
        Me.Close()
    End Sub

    Private Sub FormCambioAgenzia_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.TopMost = True
    End Sub
End Class