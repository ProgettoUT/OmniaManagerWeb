Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO

Public Class FormAnteprima

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.WindowState = Windows.Forms.FormWindowState.Normal
        Me.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width * 0.8, Screen.PrimaryScreen.WorkingArea.Height * 0.8)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Icon = Risorse.Immagini.Icon("cerca32")
        Me.Text = "Anteprima"

        ImpostaControlli()
    End Sub

    Private mNomeFile As String
    Public Property NomeFile() As String
        Get
            Return mNomeFile
        End Get
        Set(value As String)
            mNomeFile = value
        End Set
    End Property

    Private mCodiceFiscale As String
    Public Property CodiceFiscale() As String
        Get
            Return mCodiceFiscale
        End Get
        Set(value As String)
            mCodiceFiscale = value
        End Set
    End Property

    Public Sub ControlloBottoni(Optional ByRef Stampa As Boolean = True,
                                Optional Apri As Boolean = True,
                                Optional Converti As Boolean = True,
                                Optional Word As Boolean = True,
                                Optional Email As Boolean = True)
        ButtonStampa.Enabled = Stampa
        ButtonApri.Enabled = Apri
        ButtonCreaPDF.Enabled = Converti
        ButtonConvertiWord.Enabled = Word
        ButtonInvia.Enabled = Email
    End Sub

    Private Sub ImpostaControlli()
        With ButtonStampa
            .Margin = New Padding(1)
            .Padding = New Padding(10, 0, 10, 0)
            .Image = Risorse.Immagini.Bitmap("print")
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = "Stampa"
            .TextAlign = Drawing.ContentAlignment.MiddleRight
        End With
        With ButtonApri
            .Margin = New Padding(1)
            .Padding = New Padding(10, 0, 10, 0)
            .Image = Risorse.Immagini.Bitmap("open")
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = "Apri"
            .TextAlign = Drawing.ContentAlignment.MiddleRight
        End With
        With ButtonCreaPDF
            .Margin = New Padding(1)
            .Padding = New Padding(10, 0, 10, 0)
            .Image = Risorse.Immagini.Image("pdf")
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = "Converti in PDF"
            .TextAlign = Drawing.ContentAlignment.MiddleRight
        End With
        With ButtonConvertiWord
            .Margin = New Padding(1)
            .Padding = New Padding(10, 0, 10, 0)
            .Image = Risorse.Immagini.Bitmap("word")
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = "Apri in Word"
            .TextAlign = Drawing.ContentAlignment.MiddleRight
        End With
        With ButtonInvia
            .Margin = New Padding(1)
            .Padding = New Padding(10, 0, 10, 0)
            .Image = Risorse.Immagini.Bitmap("mail")
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = "Invia"
            .TextAlign = Drawing.ContentAlignment.MiddleRight
        End With
        With ButtonEsci
            .Margin = New Padding(1)
            .Padding = New Padding(10, 0, 10, 0)
            .Image = Risorse.Immagini.Bitmap("cancel")
            .ImageAlign = Drawing.ContentAlignment.MiddleLeft
            .Text = "Esci"
            .TextAlign = Drawing.ContentAlignment.MiddleRight
        End With
    End Sub

    Private Sub FormAnteprima_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If File.Exists(mNomeFile) Then
            wbAnteprima.Navigate(mNomeFile)
        Else
            MsgBox("Impossibile visualizzare l'anteprima richiesta", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
            DialogResult = Windows.Forms.DialogResult.Abort
        End If
    End Sub

    Private Sub ButtonStampa_Click(sender As Object, e As EventArgs) Handles ButtonStampa.Click
        Shell(String.Format("rundll32.exe MSHTML.DLL PrintHTML ""{0}""", mNomeFile), AppWinStyle.NormalFocus, True)
    End Sub

    Private Sub ButtonApri_Click(sender As Object, e As EventArgs) Handles ButtonApri.Click
        Process.Start(mNomeFile)
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub ButtonInvia_Click(sender As Object, e As EventArgs) Handles ButtonInvia.Click
        Try
            Using f As New UniCom.FormMail
                Cursor = Cursors.WaitCursor

                f.Messaggio = UniCom.FormMail.TipoMessaggio.Email

                'converto in pdf e allego
                f.AddAllegato(Utx.PaginaHtml.CreaFilePdf(Me.NomeFile, Path.ChangeExtension(Me.NomeFile, ".pdf")))

                Dim contatti As New Utx.Recapiti
                contatti = Utx.Recapiti.GetRecapitiCliente(mCodiceFiscale).Filtra(Utx.TipoRecapitoEnum.Email)
                If contatti.Count > 0 Then
                    f.AddDestinatarioEmail(UniCom.FormMail.TipoDestinatarioMail.A, contatti(0).Contatto)
                End If

                Cursor = Cursors.Default

                f.ShowDialog()
            End Using

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonCreaPDF_Click(sender As Object, e As EventArgs) Handles ButtonCreaPDF.Click

        Dim ErroreCreazionePdf As Boolean
        Dim pdfName As String = ""

        Try
            Using cd As New SaveFileDialog
                cd.InitialDirectory = Utx.Globale.UtenteCorrente.Desktop
                cd.Filter = "File pdf (*.pdf)|*.pdf"
                cd.AddExtension = True
                cd.FileName = Path.GetFileNameWithoutExtension(mNomeFile) 'nome di default

                If cd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    pdfName = cd.FileName

                    ErroreCreazionePdf = (Utx.PaginaHtml.CreaFilePdf(mNomeFile, pdfName) = "")

                    If ErroreCreazionePdf = False Then
                        'visualizza file
                        Process.Start(cd.FileName)
                    End If
                End If
            End Using

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            If ErroreCreazionePdf = True Then File.Delete(pdfName)
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ButtonConvertiWord_Click(sender As Object, e As EventArgs) Handles ButtonConvertiWord.Click
        Try
            Using p As New Process
                p.StartInfo.FileName = "winword.exe"
                p.StartInfo.Arguments = mNomeFile
                p.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                p.Start()
            End Using
        Catch ex As Exception
            MsgBox("Word non installato o non funzionante.", MsgBoxStyle.Information)
            Utx.Globale.Log.Info(ex.Message)
        End Try
    End Sub
End Class