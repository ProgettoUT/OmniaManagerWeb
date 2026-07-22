Imports System.IO

Public Class FormFirma

    Sub New(TipoMessaggio As FormMail.TipoMessaggio)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(400, 250)
        Me.Padding = New Padding(3)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Font = Utx.AppFont.Normal

        If TipoMessaggio = FormMail.TipoMessaggio.Email Then
            Me.BackColor = Color.Coral
            Me.Text = "Crea la firma e-mail"
        Else
            Me.BackColor = Color.YellowGreen
            Me.Text = "Crea la firma sms"
        End If

        ImpostaControlli()
    End Sub

    Private mFileFirma
    Public Property FileFirma() As String
        Get
            Return mFileFirma
        End Get
        Set(value As String)
            mFileFirma = value
        End Set
    End Property

    Private Sub ImpostaControlli()
        With ButtonSalva
            .Padding = New Padding(10, 0, 10, 0)
            .BackColor = SystemColors.Control
            .Image = Risorse.Immagini.Bitmap("salva")
            .ImageAlign = ContentAlignment.MiddleRight
            .Text = "Salva"
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonAnnulla
            .Padding = New Padding(10, 0, 10, 0)
            .BackColor = SystemColors.Control
            .Image = Risorse.Immagini.Bitmap("cancel")
            .ImageAlign = ContentAlignment.MiddleRight
            .Text = "Annulla"
            .TextAlign = ContentAlignment.MiddleLeft
        End With
    End Sub

    Private Sub ButtonSalva_Click(sender As Object, e As EventArgs) Handles ButtonSalva.Click
        Try
            If String.IsNullOrEmpty(TextBoxFirma.Text) Then
                File.Delete(mFileFirma)
            Else
                File.WriteAllText(mFileFirma, TextBoxFirma.Text)
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End Try
    End Sub

    Private Sub ButtonAnnulla_Click(sender As Object, e As EventArgs) Handles ButtonAnnulla.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub FormFirma_Load(sender As Object, e As EventArgs) Handles Me.Load
        If File.Exists(mFileFirma) Then
            TextBoxFirma.Text = File.ReadAllText(mFileFirma)
            TextBoxFirma.SelectionStart = TextBoxFirma.Text.Length
            TextBoxFirma.Focus()
        End If
    End Sub
End Class