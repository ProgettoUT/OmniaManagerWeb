Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing

Public Class FormRinomina

    Friend NuovoNome As String = ""
    Friend VecchioNome As String
    Friend DataDoc As String

    Private Rinomina As New GestioneRinomina()

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.MaximizeBox = False
        Me.BackColor = Colori.BcFormRinomina
        Me.Text = "Rinomina documento"
    End Sub

    Private Sub FormRinomina_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        With btnRinomina
            .Padding = New Padding(10)
            .Image = Risorse.Immagini.Bitmap("edit")
            .ImageAlign = Drawing.ContentAlignment.MiddleRight
            .Text = "Rinomina di documento"
            .TextAlign = Drawing.ContentAlignment.MiddleLeft
            .BackColor = SystemColors.Control
        End With
        With btnAggiungi
            .Text = "Aggiungi ai predefiniti"
            .BackColor = SystemColors.Control
        End With
        With btnElimina
            .Text = "Elimina dai predefiniti"
            .BackColor = SystemColors.Control
        End With

        LeggiNomiPredefiniti()

        With ComboBoxNomi
            .Sorted = True
            .AutoCompleteMode = Windows.Forms.AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = Windows.Forms.AutoCompleteSource.ListItems
        End With

        ComboBoxNomi.Text = VecchioNome

        'imposta data documento
        dtpDataDoc.ShowCheckBox = True

        If IsDate(DataDoc) Then
            dtpDataDoc.Value = DataDoc
        Else
            dtpDataDoc.Value = Today
            dtpDataDoc.Checked = False
        End If
    End Sub

    Public Sub LeggiNomiPredefiniti()

        Try
            ComboBoxNomi.Items.Clear()
            ComboBoxNomi.Text = ""

            For Each d As String In Rinomina.ListaDocumenti
                ComboBoxNomi.Items.Add(d)
            Next

            ComboBoxNomi.DropDownHeight = Me.Height * 2
            ComboBoxNomi.DropDownWidth = ComboBoxNomi.Width * 1.3

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

    End Sub

    Private Sub btnRinomina_Click(sender As System.Object, e As System.EventArgs) Handles btnRinomina.Click

        NuovoNome = Rinomina.NormalizzaNomeDocumento(ComboBoxNomi.Text.Trim)

        If dtpDataDoc.Checked = True Then
            NuovoNome += String.Format(" [{0}]", Format(dtpDataDoc.Value, "dd-MM-yyyy"))
        End If

        Me.Close()
    End Sub

    Private Sub btnAggiungi_Click(sender As System.Object, e As System.EventArgs) Handles btnAggiungi.Click
        If Rinomina.AggiungiDocumento(ComboBoxNomi.Text.Trim) = True Then
            LeggiNomiPredefiniti()
        End If
    End Sub

    Private Sub btnElimina_Click(sender As System.Object, e As System.EventArgs) Handles btnElimina.Click
        If Rinomina.EliminaDocumento(ComboBoxNomi.Text.Trim) = True Then
            LeggiNomiPredefiniti()
        End If
    End Sub

End Class