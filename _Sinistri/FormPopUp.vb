Imports System.Drawing
Imports System.Windows.Forms

Public Class FormPopUp

    Public WithEvents WbLiquido As New EO.WinForm.WebControl

    Sub New(Titolo As String)

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height)
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width / 2, 0)
        Me.Text = Titolo
        Me.Icon = Risorse.Immagini.Icon("unitools")
        Me.TopMost = True

        WbLiquido.Dock = Windows.Forms.DockStyle.Fill
        Me.Controls.Add(WbLiquido)
    End Sub
End Class