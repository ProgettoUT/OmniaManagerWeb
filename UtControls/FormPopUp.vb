Imports mshtml
Imports System.Windows.Forms

Public Class FormPopUp

    Private Enum Azione
        NESSUNA
        PRINT
        SELEZIONE
    End Enum

    Private UrlMail As String = ""

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.Font = Utx.AppFont.Normal
        Me.Size = New Drawing.Size(700, 400)
        Me.Icon = Risorse.Immagini.Icon("unitools")
        Me.Text = Utx.Globale.TitoloApp

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        With ButtonCreaNota
            .Margin = New Padding(0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Drawing.Color.Silver
            .Text = "Crea nota dall'e-mail"
            .Tag = Azione.NESSUNA
        End With
        With wbPopUp
            .Margin = New Padding(0)
            .RegisterAsBrowser = True
        End With
    End Sub

    Private Sub FormPopUp_Load(sender As Object, e As EventArgs) Handles Me.Load
        With tlpMain.RowStyles.Item(1)
            .SizeType = SizeType.Absolute
            .Height = 0
        End With

        wbPopUp.Silent = True
    End Sub

    Private Sub ButtonCreaNota_Click(sender As Object, e As EventArgs) Handles ButtonCreaNota.Click
        Try
            Select Case ButtonCreaNota.Tag
                Case Azione.NESSUNA
                    ButtonCreaNota.Tag = Azione.PRINT
                    wbPopUp.Navigate2(Replace(UrlMail, "a=Open", "a=Print", , , CompareMethod.Text))
                Case Azione.SELEZIONE
                    Using f As New UtControls.FormCercaCliente
                        f.NomeCompleto = ""
                        f.VisualizzaSinistri = True
                        f.ShowDialog()

                        If f.DialogResult = Windows.Forms.DialogResult.OK Then

                            Dim doc As IHTMLDocument3 = wbPopUp.Document

                            Dim Nota As New Utx.Nota
                            With Nota
                                .NuovaNota = True
                                .Tipo = Utx.Nota.TipoNota.NOTA
                                .CodiceFiscale = f.CodiceFiscale

                                If f.Selezione = FormCercaCliente.TipoSelezione.CLIENTE Then
                                    .IdNota = f.CodiceFiscale
                                Else
                                    .IdNota = f.IdSinistro
                                End If

                                .Utente = Utx.Globale.UtenteCorrente.UniageUser
                                .Testo = doc.body.innertext
                                .SalvaNota()
                            End With

                            MsgBox("Nota inserita correttamente", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                            Me.Close()
                        End If
                    End Using
            End Select

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub wbPopUp_DocumentComplete(sender As Object, e As AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEvent) Handles wbPopUp.DocumentComplete
        UrlMail = e.uRL

        If e.uRL.ToString.ToLower.StartsWith("https://posta.unipol.it/owa") AndAlso e.uRL.ToString.ToLower.Contains("&a=print") Then
            If ButtonCreaNota.Tag = Azione.PRINT Then
                With ButtonCreaNota
                    .Padding = Utx.AppFont.ButtonPadding
                    .BackColor = Drawing.Color.Moccasin
                    .Image = Risorse.Immagini.Bitmap("check")
                    .ImageAlign = Drawing.ContentAlignment.MiddleLeft
                    .Text = "Seleziona il cliente o il sinistro per la nota"
                    .TextAlign = Drawing.ContentAlignment.MiddleRight
                    .Tag = Azione.SELEZIONE
                End With
                With tlpMain.RowStyles.Item(1)
                    .SizeType = SizeType.Absolute
                    .Height = 40
                End With
                ButtonCreaNota.PerformClick()
            End If
        ElseIf e.uRL.ToString.ToLower.StartsWith("https://posta.unipol.it/owa") Then
            With ButtonCreaNota
                .Padding = Utx.AppFont.ButtonPadding
                .BackColor = Drawing.Color.PaleGreen
                .Image = Risorse.Immagini.Bitmap("notifica")
                .ImageAlign = Drawing.ContentAlignment.MiddleLeft
                .Text = "Crea una nota dall'e-mail"
                .TextAlign = Drawing.ContentAlignment.MiddleRight
            End With
            With tlpMain.RowStyles.Item(1)
                .SizeType = SizeType.Absolute
                .Height = 40
            End With
        End If
    End Sub

    Private Sub wbPopUp_NewWindow2(sender As Object, e As AxSHDocVw.DWebBrowserEvents2_NewWindow2Event) Handles wbPopUp.NewWindow2
        Dim f As New UtControls.FormPopUp
        e.ppDisp = f.wbPopUp.Application
        f.Visible = True
    End Sub
End Class