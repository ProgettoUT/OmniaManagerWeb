Public Class FormAperturaBusta

    Private mTipoBusta As String

    Public DecadeSelezionata As Date

    Sub New(TipoBusta As String)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(300, 120)
        Me.Font = Globale.MainFont
        Me.Padding = New Padding(5)
        Me.BackColor = Color.DimGray

        mTipoBusta = TipoBusta

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        'controllo data
        If Today < Utx.FunzioniData.InizioAnno(2018) Then
            MsgBox("La data del computer è errata. Impossibile inizializzare la busta.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
            Me.Close()
        End If

        'sistemo le righe del tlp elenco
        tlpMain.RowStyles.Item(0) = New RowStyle(SizeType.Percent, 100)
        tlpMain.RowStyles.Item(1) = New RowStyle(SizeType.Absolute, 30)
        tlpMain.RowStyles.Item(2) = New RowStyle(SizeType.Absolute, 50)

        With Label1
            .AutoSize = True
            .Dock = DockStyle.Fill
            .ForeColor = Color.White
            .Text = String.Format("Non ci sono ancora buste del tipo '{1}' con documenti.{0}Apri la busta della",
                                  Environment.NewLine, mTipoBusta)
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        With ComboBoxDecadi
            .Dock = DockStyle.Top
            .DropDownStyle = ComboBoxStyle.DropDownList
            .Sorted = False

            Dim Inizio, Fine As Date

            Inizio = Today.AddDays(1) 'aggiungo 1 giorno perché nel DO lo tolgo

            Do While True

                Inizio = Decade.DataInizioDecade(Inizio.AddDays(-1))
                Fine = Decade.DataFineDecade(Inizio)

                If EsisteBustaArchiviata(Fine) = False Then
                    .Items.Add(New Decade(Fine))

                    If .Items.Count = 6 Then 'max 6 decadi 
                        Exit Do
                    End If
                Else
                    Exit Do
                End If
            Loop

            .DisplayMember = "Descrizione"
            'seleziono l'ultima decade (corrente)
            .SelectedIndex = 0
        End With
        With ButtonOk
            .AutoSize = True
            .Dock = DockStyle.Fill
            .FlatStyle = FlatStyle.Flat
            .Padding = New Padding(10, 0, 10, 0)
            .FlatAppearance.BorderColor = Color.Gainsboro
            .BackColor = SystemColors.Control
            .Image = My.Resources.ok32.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Ok"
            .TextAlign = ContentAlignment.MiddleRight
        End With
    End Sub

    Private Sub ButtonOk_Click(sender As Object, e As EventArgs) Handles ButtonOk.Click
        DecadeSelezionata = ComboBoxDecadi.SelectedItem.Fine
        Me.Close()
    End Sub

    Private Function EsisteBustaArchiviata(Decade As Date) As Boolean
        Try
            Dim Query As String = String.Format("SELECT COUNT(*) 
                FROM Buste 
                WHERE (DataBusta = '{0:dd/MM/yyyy}') AND (TipoBusta = '{1}') AND CAST(Inviato as bit) = 1", Decade, mTipoBusta)
            Return Utx.WsCommand.ExecuteScalar(Query, Utx.Globale.AgenziaRichiesta.CodiceAgenzia, 0).Valore > 0
        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return True
        End Try
    End Function
End Class