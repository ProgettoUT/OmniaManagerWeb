Imports System.IO

Public Class FormRichiesta

    Friend Cliente As UtControls.Cliente
    Friend Sinistro As DatiSinistro

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(730, 560)
        Me.Font = Utx.AppFont.Normal
        Me.Text = "Stampa richiesta CONSAP"
        Me.Icon = Risorse.Immagini.Icon("consap")

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        With ButtonSalvaDelegato
            .Padding = Utx.AppFont.ButtonPadding
            .Image = Risorse.Immagini.Bitmap("salva")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Salva dati delega"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With ButtonStampa
            .Padding = Utx.AppFont.ButtonPadding
            .Image = Risorse.Immagini.Bitmap("print")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Stampa richiesta/delega"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With ButtonRichiestaSito
            .Padding = Utx.AppFont.ButtonPadding
            .Image = Risorse.Immagini.Bitmap("web")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Crea richiesta sul sito CONSAP"
            .TextAlign = ContentAlignment.MiddleRight
        End With
    End Sub

    Private Sub rbDelega_CheckedChanged(sender As Object, e As EventArgs) Handles rbDelega.CheckedChanged
        GroupBoxDelega.Enabled = rbDelega.Checked = True
    End Sub

    Private Sub rbNormale_CheckedChanged(sender As Object, e As EventArgs) Handles rbNormale.CheckedChanged
        GroupBoxDelega.Enabled = rbDelega.Checked = True
    End Sub

    Private Sub FormRichiesta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SalvaDelegato()
    End Sub

    Private Sub FormRichiesta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbNormale.Checked = True
    End Sub

    Private Sub FormRichiesta_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        CompilaDatiCliente()
        CompilaDatiSinistro()
        CompilaDelega()
    End Sub

    Private Sub CompilaDatiCliente()
        Try
            txtNome.Text = Cliente.NomeCompleto
            txtIndirizzo.Text = Cliente.Indirizzo
            txtCAP.Text = Cliente.Cap
            txtCitta.Text = Cliente.Citta
            txtProvincia.Text = Cliente.Provincia
            txtCF.Text = Cliente.CF

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub CompilaDatiSinistro()
        Try
            txtDataSinistro.Text = Sinistro.DataSinistro
            txtTargaResponsabile.Text = Sinistro.TargaResponsabile
            txtTargaControparte.Text = Sinistro.TargaControparte
            txtCompagnia.Text = Sinistro.Compagnia
            txtCompControparte.Text = Sinistro.CompagniaControparte

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub CompilaDelega()
        Try
            txtDRagioneSociale.Text = Globale.Delegato.RagioneSociale
            txtDIndirizzo.Text = Globale.Delegato.Indirizzo
            txtDCap.Text = Globale.Delegato.Cap
            txtDCitta.Text = Globale.Delegato.Citta
            txtDProvincia.Text = Globale.Delegato.Provincia
            txtDCF.Text = Globale.Delegato.CF
            txtDTelefono.Text = Globale.Delegato.Telefono
            txtDEmail.Text = Globale.Delegato.Email

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Function RichiestaConsapDelega() As String
        Return Path.Combine(Utx.Globale.Paths.CartellaSettingRete, "RichiestaConsapDelega.html")
    End Function

    Private Function RichiestaConsap() As String
        Return Path.Combine(Utx.Globale.Paths.CartellaSettingRete, "RichiestaConsap.html")
    End Function

    Private Sub ButtonStampa_Click(sender As Object, e As EventArgs) Handles ButtonStampa.Click
        Try
            Using Anteprima As New UtControls.FormAnteprima
                Anteprima.NomeFile = CompilaModulo()
                Anteprima.ShowDialog()
                'cancello il file di anteprima
                IO.File.Delete(Anteprima.NomeFile)
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub TrimmaTutto()

        On Error Resume Next

        For Each txt As TextBox In tlpCliente.Controls
            txt.Text = txt.Text.Trim()
        Next
        For Each txt As TextBox In tlpDelega.Controls
            txt.Text = txt.Text.Trim()
        Next
        For Each txt As TextBox In tlpSinistro.Controls
            txt.Text = txt.Text.Trim()
        Next
    End Sub

    Private Function CompilaModulo() As String
        Try
            Dim Testo As String

            If rbDelega.Checked = True Then
                Testo = File.ReadAllText(RichiestaConsapDelega)
            Else
                Testo = File.ReadAllText(RichiestaConsap)
            End If

            TrimmaTutto()

            'normalizza documento cliente
            If txtTipoDoc.Text.Trim.Length = 0 Then
                txtTipoDoc.Text = "---"
            End If
            If txtNumeroDoc.Text.Trim.Length = 0 Then
                txtNumeroDoc.Text = "---"
            End If
            If txtRilascioDoc.Text.Trim.Length = 0 Then
                txtRilascioDoc.Text = "---"
            End If
            If txtScadenzaDoc.Text.Trim.Length = 0 Then
                txtScadenzaDoc.Text = "---"
            End If

            'cliente
            Testo = Testo.Replace("#assicurato#", txtNome.Text)
            Testo = Testo.Replace("#residenzaassicurato#", txtIndirizzo.Text)
            Testo = Testo.Replace("#cap#", txtCAP.Text)
            Testo = Testo.Replace("#citta#", txtCitta.Text)
            Testo = Testo.Replace("#provincia#", txtProvincia.Text)
            Testo = Testo.Replace("#tipodoc#", txtTipoDoc.Text)
            Testo = Testo.Replace("#numerodoc#", txtNumeroDoc.Text)
            Testo = Testo.Replace("#rilasciodoc#", txtRilascioDoc.Text)
            Testo = Testo.Replace("#scadenzadoc#", txtScadenzaDoc.Text)
            Testo = Testo.Replace("#codicefiscale#", txtCF.Text)

            'delega
            If rbDelega.Checked = True Then
                Testo = Testo.Replace("#dragionesociale#", txtDRagioneSociale.Text)
                Testo = Testo.Replace("#dindirizzo#", txtDIndirizzo.Text)
                Testo = Testo.Replace("#dcap#", txtDCap.Text)
                Testo = Testo.Replace("#dcitta#", txtDCitta.Text)
                Testo = Testo.Replace("#dprovincia#", txtDProvincia.Text)
                Testo = Testo.Replace("#dcodicefiscale#", txtDCF.Text)
            End If

            'sinistro
            Testo = Testo.Replace("#datasinistro#", txtDataSinistro.Text)
            Testo = Testo.Replace("#targaassicurato#", txtTargaResponsabile.Text)
            Testo = Testo.Replace("#targadanneggiato#", txtTargaControparte.Text)
            Testo = Testo.Replace("#impresaassicurato#", txtCompagnia.Text)
            Testo = Testo.Replace("#impresadanneggiato#", txtCompControparte.Text)

            'recapito
            Testo = Testo.Replace("#recapito#", String.Format("{0} - {1} - {2} {3} {4}",
                                                              txtNome.Text,
                                                              txtIndirizzo.Text,
                                                              txtCAP.Text,
                                                              txtCitta.Text,
                                                              txtProvincia.Text))

            'salvo il modulo compilato in un file temporaneo
            Dim FileTemp As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "Richiesta.html")

            File.Delete(FileTemp)

            Using sw As New StreamWriter(FileTemp)
                sw.Write(Testo)
            End Using

            Return FileTemp

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Private Sub ButtonRichiestaSito_Click(sender As Object, e As EventArgs) Handles ButtonRichiestaSito.Click
        Using f As New FormRichiestaSito
            f.Cliente = New UtControls.Cliente(Cliente.CF)
            f.Sinistro = New DatiSinistro(Sinistro.AgenziaSinistro, Sinistro.EsercizioSinistro, Sinistro.NumeroSinistro)
            f.Delega = rbDelega.Checked
            f.ShowDialog()
        End Using
    End Sub

    Private Sub ButtonSalvaDelegato_Click(sender As Object, e As EventArgs) Handles ButtonSalvaDelegato.Click
        SalvaDelegato()
    End Sub

    Private Sub SalvaDelegato()
        Try
            'salvo dati delegato
            With Globale.Delegato
                .RagioneSociale = txtDRagioneSociale.Text
                .Indirizzo = txtDIndirizzo.Text
                .Cap = txtDCap.Text
                .Citta = txtDCitta.Text
                .Provincia = txtDProvincia.Text
                .CF = txtDCF.Text
                .Telefono = txtDTelefono.Text
                .Email = txtDEmail.Text

                .SalvaDati()
            End With

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub
End Class