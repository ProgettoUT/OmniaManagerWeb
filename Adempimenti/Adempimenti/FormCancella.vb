Public Class FormCancella

    Public Contraente As String
    Public DataFoglioCassa As String

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Font = Globale.MainFont
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Size = New Size(450, 200)
        Me.Text = "Cancellazione titoli"
        Me.BackColor = Color.DarkOrange
        Me.Padding = New Padding(5)

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()

        TabControl1.HotTrack = True

        With TabPage1
            .Text = "Cancella titolo selezionato"
        End With
        With TabPage2
            .Text = "Cancellazione di più titoli"
        End With
        With LabelTitolo
            .Padding = New Padding(20, 0, 0, 0)
            .Dock = DockStyle.Fill
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        With LabelPiuTitoli
            .Padding = New Padding(20, 0, 0, 0)
            .Dock = DockStyle.Fill
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        With dtpInizio
            .Format = DateTimePickerFormat.Short
        End With
        With dtpFine
            .Format = DateTimePickerFormat.Short
        End With
        With ButtonCancella
            .Margin = New Padding(0)
            .Dock = DockStyle.Fill
            .BackColor = SystemColors.Control
            .FlatStyle = FlatStyle.Flat
            .Text = "Cancella"
        End With
        With ButtonEsci
            .Margin = New Padding(0)
            .Dock = DockStyle.Fill
            .BackColor = SystemColors.Control
            .FlatStyle = FlatStyle.Flat
            .Text = "Annulla"
        End With
    End Sub

    Private Sub FormCancella_Load(sender As Object, e As EventArgs) Handles Me.Load

        With LabelTitolo
            .Text = String.Format("{1}{0}esitato il {2:d}",
                                  Environment.NewLine,
                                  Contraente,
                                  DataFoglioCassa)
        End With
        With LabelPiuTitoli
            .Text = "Cancella tutti i titoli compresi nell'intervallo e non selezionati per l'invio"
        End With

        TabControl1.SelectedTab = TabPage1
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        Me.Close()
    End Sub
End Class