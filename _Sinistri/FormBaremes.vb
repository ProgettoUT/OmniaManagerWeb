Imports System.Windows.Forms
Imports System.Drawing

Public Class FormBaremes

    Private Tabella(16) As Array
    Private VeicoloA As Integer = 0
    Private VeicoloB As Integer = 0

    Sub New()
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.WindowState = Windows.Forms.FormWindowState.Maximized
        Me.Text = "Barèmes - Convenzione indennizzo diretto"
        Me.Font = Utx.AppFont.Normal
        Me.Icon = Risorse.Immagini.Icon("sinistro")

        ImpostaControlli()
        ImpostaTabella()
    End Sub

    Private Sub ImpostaControlli()
        TabMain.TabPages(0).Text = "Responsabilità"
        TabMain.TabPages(1).Text = "Guida"

        With LabelA
            .Padding = New Padding(10, 0, 10, 0)
            .Font = Utx.AppFont.Bold
            .BackColor = Drawing.Color.PaleGreen
        End With
        With LabelB
            .Padding = New Padding(10, 0, 10, 0)
            .Font = Utx.AppFont.Bold
            .BackColor = Drawing.Color.Orange
        End With
        With LabelRisultato
            .Padding = New Padding(10, 0, 10, 0)
            .Font = Utx.AppFont.Bold(14)
            .BackColor = Drawing.Color.Gainsboro
            .Text = "Selezionare le circostanze dell'incidente"
        End With

        With CheckedListBoxA
            .Font = Utx.AppFont.Normal(11)
            .Sorted = False
            .CheckOnClick = True
            With .Items
                .Add("01. Veicolo in sosta o in fermata")
                .Add("02. Ripartiva dopo una sosta/apriva una portiera")
                .Add("03. Stava parcheggiando")
                .Add("04. Usciva da un parcheggio, da un luogo privato, in una strada vicinale")
                .Add("05. Entrava in un parcheggio, in un luogo privato, in una strada vicinale")
                .Add("06. Si immetteva su una piazza a senso rotatorio")
                .Add("07. Circolava su una piazza a senso rotatorio")
                .Add("08. Tamponava procedendo nello stesso senso o nella stessa fila")
                .Add("09. Procedeva nello stesso senso, ma in fila diversa")
                .Add("10. Cambiava fila")
                .Add("11. Sorpassava")
                .Add("12. Girava a destra")
                .Add("13. Girava a sinistra")
                .Add("14. Retrocedeva")
                .Add("15. Invadeva la sede stradale riservata alla circolazione in senso inverso")
                .Add("16. Proveniva da destra")
                .Add("17. Non aveva osservato il segnale di precedenza o di semaforo rosso ")
            End With
        End With
        With CheckedListBoxB
            .Font = Utx.AppFont.Normal(11)
            .Sorted = False
            .CheckOnClick = True
            For k As Integer = 0 To CheckedListBoxA.Items.Count - 1
                .Items.Add(CheckedListBoxA.Items(k))
            Next
        End With
    End Sub

    Private Sub ImpostaTabella()
        'veicolo A tabella(A)(B)
        Tabella(0) = "NC,R,R,R,R,R,R,R,R,R,R,R,R,R,R,R,R".Split(",")
        Tabella(1) = "T,C,C,C,C,R,R,C,T,T,T,T,T,R,R,T,C".Split(",")
        Tabella(2) = "T,C,C,C,C,T,T,R,NC,NC,NC,T,T,R,R,NC,R".Split(",")
        Tabella(3) = "T,C,C,C,C,T,T,C,T,T,T,T,T,C,R,T,C".Split(",")
        Tabella(4) = "T,C,C,C,C,T,T,R,T,NC,NC,T,NC,R,R,T,R".Split(",")
        Tabella(5) = "T,T,R,R,R,C,T,R,NC,R,NC,R,NC,R,R,T,R".Split(",")
        Tabella(6) = "T,T,R,R,R,R,C,R,C,R,R,R,R,R,R,T,R".Split(",")
        Tabella(7) = "T,C,T,C,T,T,T,NC,NC,C,T,T,T,R,NC,T,C".Split(",")
        Tabella(8) = "T,R,NC,R,R,NC,C,NC,C,R,R,R,R,R,R,NC,R".Split(",")
        Tabella(9) = "T,R,NC,R,NC,T,T,C,T,C,T,T,T,C,R,T,R".Split(",")
        Tabella(10) = "T,R,NC,R,NC,NC,T,R,T,R,C,T,C,R,R,T,C".Split(",")
        Tabella(11) = "T,R,R,R,R,T,T,R,T,R,R,C,NC,R,R,T,R".Split(",")
        Tabella(12) = "T,R,R,R,NC,NC,T,R,T,R,C,NC,C,R,R,T,R".Split(",")
        Tabella(13) = "T,T,T,C,T,T,T,T,T,C,T,T,T,C,C,T,C".Split(",")
        Tabella(14) = "T,T,T,T,T,T,T,NC,T,T,T,T,T,C,C,T,C".Split(",")
        Tabella(15) = "T,R,NC,R,R,R,R,R,NC,R,R,R,R,R,R,C,R".Split(",")
        Tabella(16) = "T,C,T,C,T,T,T,C,T,T,C,T,T,C,C,T,C".Split(",")
    End Sub

    Private Sub FormBaremes_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        TabMain.ColorStyle = Utx.UtTabControl.TabColorStyle.VERDE
    End Sub

    Private Sub CheckedListBoxA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBoxA.SelectedIndexChanged
        For i = 0 To CheckedListBoxA.Items.Count - 1
            CheckedListBoxA.SetItemCheckState(i, CheckState.Unchecked)
        Next
        CheckedListBoxA.SetItemCheckState(CheckedListBoxA.SelectedIndex, CheckState.Checked)
        VeicoloA = CheckedListBoxA.SelectedIndex
        LabelA.Text = String.Format("Veicolo A: {0}", VeicoloA + 1)
        LabelRisultato.Text = CalcoloBaremes()
    End Sub

    Private Sub CheckedListBoxB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckedListBoxB.SelectedIndexChanged
        For i = 0 To CheckedListBoxB.Items.Count - 1
            CheckedListBoxB.SetItemCheckState(i, CheckState.Unchecked)
        Next
        CheckedListBoxB.SetItemCheckState(CheckedListBoxB.SelectedIndex, CheckState.Checked)
        VeicoloB = CheckedListBoxB.SelectedIndex
        LabelB.Text = String.Format("Veicolo B: {0}", VeicoloB + 1)
        LabelRisultato.Text = CalcoloBaremes()
    End Sub

    Private Function CalcoloBaremes() As String
        If (CheckedListBoxA.SelectedIndices.Count > 0) AndAlso (CheckedListBoxB.SelectedIndices.Count > 0) Then
            Dim Esito As String = Tabella(VeicoloA)(VeicoloB)
            Select Case Esito
                Case "T"
                    Return "Responsabilità totale a carico del veicolo A"
                Case "R"
                    Return "Responsabilità totale a carico del veicolo B"
                Case "C"
                    Return "Concorso di colpa: corresponsabilità paritetica di A e B"
                Case "NC"
                    Return "Sinistro non verificabile"
                Case Else
                    Return "?"
            End Select
        Else
            'non cambio la descrizione
            Return LabelRisultato.Text
        End If
    End Function

    Private Sub TabControl1_Selected(sender As Object, e As TabControlEventArgs) Handles TabMain.Selected
        If e.TabPageIndex = 1 Then
            WebBrowser1.Navigate("http://www.utools.it/Unitools/Download/Baremes.pdf")
        End If
    End Sub
End Class