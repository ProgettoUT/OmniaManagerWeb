Public Class FormNote

    Private mChiamata As Chiamata

    Sub New(ByRef Chiamata As Chiamata)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(450, 250)
        Me.Icon = Risorse.Immagini.Icon("edit")
        Me.Text = "Appunti"
        Me.AcceptButton = ButtonOk
        Me.TopMost = True

        mChiamata = Chiamata
    End Sub

    Private Sub FormNote_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.TopMost = False
    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        Try
            Dim Nota As String = String.Format("{1}{0}Telefono: {2}{0}Cliente: {3}{0}Note: {4}{0}{5}{0}",
                                               Environment.NewLine,
                                               Now,
                                               mChiamata.Telefono,
                                               mChiamata.Nome,
                                               TextBoxNota.Text.Trim,
                                               StrDup(60, "-"))

            IO.File.AppendAllText(FormAvvioCentralino.Note, Nota)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
        Me.Close()
    End Sub

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonAnnulla.Click
        Me.Close()
    End Sub
End Class