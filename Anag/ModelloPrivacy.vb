Imports System.Windows.Forms
Imports System.IO

Public Class ModelloPrivacy
    Private sFileName As String

    Public Sub New()
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.MinimizeBox = False
        Me.Text = "Modello privacy d'agenzia"
        Me.Icon = Risorse.Immagini.Icon("cliente")

        InizializzaControllo({lblModelloPrivacySelezionato})
    End Sub

    Private Sub ButtonApriPdf_Click(sender As Object, e As EventArgs) Handles ButtonApriPdf.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Seleziona modello privacy"
        fd.InitialDirectory = Utx.Globale.UtenteCorrente.Desktop
        fd.Filter = "Pdf files (*.pdf)|*.pdf"
        fd.FilterIndex = 1
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            If Not String.IsNullOrEmpty(fd.FileName) Then
                If File.Exists(fd.FileName) Then
                    sFileName = fd.FileName
                    lblModelloPrivacySelezionato.Text = IO.Path.GetFileName(sFileName)
                    lblModelloPrivacySelezionato.ForeColor = Utx.AppColor.VerdeOpaco

                    'cancello il vecchi modello
                    File.Delete(ModelloPrivacyPath)
                    'copio il nuovo e chiudo se tutto ok
                    File.Copy(sFileName, ModelloPrivacyPath)
                    If File.Exists(ModelloPrivacyPath) Then
                        Me.Close()
                        Exit Sub
                    End If
                End If
            End If
            MsgBox("Nessun modello selezionato", MsgBoxStyle.Exclamation, "Modello privacy")
        End If
    End Sub

    Private Sub ModelloPrivacy_Load(sender As Object, e As EventArgs) Handles Me.Load
        If File.Exists(ModelloPrivacyPath) Then
            lblModelloPrivacySelezionato.Text = "Modello privacy già selezionato"
            lblModelloPrivacySelezionato.ForeColor = Utx.AppColor.VerdeOpaco
        Else
            lblModelloPrivacySelezionato.ForeColor = Utx.AppColor.RossoScuro
        End If
    End Sub

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonAnnulla.Click
        Me.Close()
    End Sub
End Class