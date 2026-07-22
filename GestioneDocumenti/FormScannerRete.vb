Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms

Public Class FormScannerRete

    Friend PraticaCorrente As Pratiche
    Friend DocumentoImportato As Documenti

    Private Log As New Utx.ApplicationLog("GestioneDocumenti.log")

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        With Me
            .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            .Size = New Size(710, 565)
            .MaximizeBox = True
            .MinimizeBox = False
            .StartPosition = FormStartPosition.CenterScreen
            .Text = String.Format("Scanner di rete: {0}", CartellaScannerRete)
            .Icon = Risorse.Immagini.Icon("scanrete")
        End With
    End Sub

    Public Shared Property CartellaScannerRete() As String
        Get
            Return Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.CARTELLA_SCANNER_RETE, "")
        End Get
        Set(value As String)
            If Directory.Exists(value) Then
                Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.CARTELLA_SCANNER_RETE, value, True)
            End If
        End Set
    End Property

    Private Sub FormScannerRete_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ImpostaControlli()
    End Sub

    Private Sub FormScannerRete_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Me.Refresh()
        ListaFile()
    End Sub

    Private Sub ImpostaControlli()

        With btnImporta
            .Padding = New Padding(3, 0, 3, 0)
            .BackColor = Colori.Pratiche.BcbtnPratica
            .Text = String.Format("Importa in{0}{1}", Environment.NewLine, PraticaCorrente.Descrizione)
            .TextAlign = ContentAlignment.MiddleLeft
            .Image = Risorse.Immagini.Bitmap("importa")
            .ImageAlign = ContentAlignment.MiddleRight
        End With
        With ButtonSposta
            .Text = "Sposta in..."
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With btnAggiorna
            .Padding = New Padding(10, 0, 10, 0)
            .Text = "Aggiorna lista"
            .TextAlign = ContentAlignment.MiddleLeft
            .Image = Risorse.Immagini.Bitmap("aggiorna")
            .ImageAlign = ContentAlignment.MiddleRight
        End With
        With btnEsci
            .Padding = New Padding(10, 0, 10, 0)
            .Text = "Esci"
            .TextAlign = ContentAlignment.MiddleLeft
            .Image = Risorse.Immagini.Bitmap("esci")
            .ImageAlign = ContentAlignment.MiddleRight
        End With
    End Sub

    Private Sub ListaFile()
        Try
            Dim DocRete() As String = Directory.GetFiles(CartellaScannerRete, "*.pdf")
            Array.Sort(DocRete)
            Array.Reverse(DocRete)

            ListBoxDocRete.Items.Clear()
            ListBoxDocRete.Sorted = False

            For Each d As String In DocRete
                ListBoxDocRete.Items.Add(Path.GetFileName(d))
            Next

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

    End Sub

    Private Sub btnEsci_Click(sender As System.Object, e As System.EventArgs) Handles btnEsci.Click
        Me.Close()
    End Sub

    Private Sub btnImporta_Click(sender As System.Object, e As System.EventArgs) Handles btnImporta.Click

        Try
            If String.IsNullOrEmpty(ListBoxDocRete.Text) Then Exit Sub

            Dim Tmp() As String = Path.GetFileNameWithoutExtension(ListBoxDocRete.Text).Split("_")

            Dim DataDoc As String

            Try
                'gestisco 2 tipi di formato:
                'Acquisizione_2013_07_14_15_58_31_650()
                '20140807_100830
                If Tmp.GetUpperBound(0) = 1 Then
                    'secondo tipo
                    DataDoc = String.Format("{0}-{1}-{2} {3}:{4}:{5}",
                                            Tmp(0).Substring(6, 2), Tmp(0).Substring(4, 2), Tmp(0).Substring(0, 4),
                                            Tmp(1).Substring(0, 2), Tmp(1).Substring(2, 2), Tmp(1).Substring(4, 2))
                Else
                    'primo tipo
                    DataDoc = String.Format("{0}-{1}-{2} {3}:{4}:{5}",
                                            Tmp(3), Tmp(2), Tmp(1),
                                            Tmp(4), Tmp(5), Tmp(6))
                End If

            Catch ex As Exception
                DataDoc = ""
            End Try

            Dim NuovoNome As String = String.Format("Doc{0}", Path.GetExtension(ListBoxDocRete.Text))

            'creo il doc con il nuovo nome
            DocumentoImportato = New Documenti(PraticaCorrente, NuovoNome)

            'aggiungo il protocollo
            If IsDate(DataDoc) Then
                DocumentoImportato.AggiungiProtocollo(CDate(DataDoc))
            Else
                DocumentoImportato.AggiungiProtocollo() 'utilizzo now
            End If

            'sposto il doc
            DocumentoImportato.SpostaDocumento(Path.Combine(CartellaScannerRete, ListBoxDocRete.Text))

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

        Me.Close()

    End Sub

    Private Sub ListBoxDocRete_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ListBoxDocRete.SelectedIndexChanged

        If ListBoxDocRete.SelectedIndex >= 0 Then
            'se è un pdf mostro l'anteprima
            If ListBoxDocRete.Text.EndsWith("PDF", StringComparison.InvariantCultureIgnoreCase) Then
                AxAcroPDF1.LoadFile(Path.Combine(CartellaScannerRete, ListBoxDocRete.Text))
            End If
        End If
    End Sub

    Private Sub btnAggiorna_Click(sender As System.Object, e As System.EventArgs) Handles btnAggiorna.Click
        ListaFile()
    End Sub

    Private Sub ButtonSposta_Click(sender As Object, e As EventArgs) Handles ButtonSposta.Click

        Try
            If ListBoxDocRete.SelectedItem = Nothing Then
                MsgBox("Selezionare prima un documento", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
            Else
                Using cd As New SaveFileDialog

                    cd.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
                    cd.FileName = ListBoxDocRete.Text
                    cd.OverwritePrompt = True

                    If cd.ShowDialog() = Windows.Forms.DialogResult.OK Then

                        My.Computer.FileSystem.MoveFile(Path.Combine(CartellaScannerRete, ListBoxDocRete.Text), cd.FileName)
                        Me.Close()
                    End If
                End Using
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub
End Class