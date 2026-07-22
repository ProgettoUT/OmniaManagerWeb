Public Class frmMovimento

    Friend Misto As Boolean = False
    Friend dr As DataGridViewRow
    Friend Giorno As Date

    Private Sub Movimento_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.Icon = My.Resources.euro
        Me.Text = "Movimento"

        lbTestata.Text = "Movimento del " + Format(Giorno, "dd-MM-yyyy")

        lbStato.Text = ""
        With btnSalva
            .Padding = New Padding(10, 0, 10, 0)
            .Text = "Registra il movimento"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = My.Resources.save.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With btnNuovo
            .Padding = New Padding(10, 0, 10, 0)
            .Text = "Nuovo movimento"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = My.Resources.nuovo.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With btnEsci
            .Padding = New Padding(10, 0, 10, 0)
            .Text = "Esci"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = My.Resources.Esci.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With

        If Misto = True Then

            cboTipoMovimento.Items.Add("Assicurativo")
            cboTipoMovimento.SelectedIndex = 0

            cboCodice.Enabled = False

            cboSezioneUscita.Items.Add("Cassetto")
            cboSezioneUscita.SelectedIndex = 0

            cboSezioneEntrata.Items.Add("Banca")
            cboSezioneEntrata.SelectedIndex = 0

            txtDesk.Text = dr.Cells("Contraente").Value

            With cboPvUscita
                .DropDownStyle = ComboBoxStyle.DropDownList
                .Items.Add(dr.Cells("Pv").Value)
                .SelectedIndex = 0
            End With
            With cboPvEntrata
                .DropDownStyle = ComboBoxStyle.DropDownList
                .Items.Add(dr.Cells("Pv").Value)
                .SelectedIndex = 0
            End With

            With cboCassaUscita
                .DropDownStyle = ComboBoxStyle.DropDownList
                .Items.Add(dr.Cells("CodiceCassa").Value)
                .SelectedIndex = 0
            End With
            With cboCassaEntrata
                .DropDownStyle = ComboBoxStyle.DropDownList
                .Items.Add(dr.Cells("CodiceCassa").Value)
                .SelectedIndex = 0
            End With

            ImpostaTipoPagamento(cboTipoPagamento, True)

            btnNuovo.Enabled = False
        Else
            ImpostaTipoMovimento(cboTipoMovimento)

            ImpostaSezione(cboSezioneUscita, "Altro...")
            ImpostaSezione(cboSezioneEntrata, "Altro...")

            ImpostaPuntoVendita(cboPvUscita)
            ImpostaPuntoVendita(cboPvEntrata)

            ImpostaCassa(cboCassaUscita, "Tutte")
            CopiaCombo(cboCassaUscita, cboCassaEntrata)

            ImpostaTipoPagamento(cboTipoPagamento, False)
        End If
    End Sub

    Private Sub CopiaCombo(ComboDa As ComboBox, ComboA As ComboBox)

        ComboA.Items.Clear()

        For Each i As Object In ComboDa.Items
            ComboA.Items.Add(i)
        Next
        ComboA.SelectedIndex = ComboDa.SelectedIndex
    End Sub

    Private Sub txtImporto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtImporto.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8, 44 'numerici, backspace e virgola - ok
            Case 45 : e.KeyChar = "" 'segno meno
            Case 46 : e.KeyChar = "," 'punto trasformato in virgola
            Case Else : e.KeyChar = ""
        End Select
    End Sub

    Private Sub btnSalva_Click(sender As System.Object, e As System.EventArgs) Handles btnSalva.Click
        If (dr IsNot Nothing) AndAlso dr.Cells("TipoPagamento").Value = "M" Then
            SalvaMovimentoMisto()
        Else
            SalvaMovimento()
        End If
    End Sub

    Private Sub SalvaMovimento()
        Dim SezioneUscita As String = cboSezioneUscita.Text.Substring(0, 2).ToUpper
        Dim SezioneEntrata As String = cboSezioneEntrata.Text.Substring(0, 2).ToUpper
        Dim PvUscita As Integer = CodicePvSelezionato(cboPvUscita)
        Dim PvEntrata As Integer = CodicePvSelezionato(cboPvEntrata)

        If (PvUscita = PvEntrata) AndAlso (SezioneUscita = SezioneEntrata) Then
            MsgBox("Le sezioni uscita ed entrata non possono essere uguali", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If txtImporto.Text = String.Empty Then txtImporto.Text = 0

        If txtImporto.Text = 0 Then
            If MsgBox("L'importo è uguale a zero: continuare?",
                      MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2,
                      "Movimento") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        btnSalva.Enabled = False

        Try
            Dim Query As New Utx.NetFunc.StringFormatter("INSERT INTO ChiusuraCassa 
                    (TipoRecord,Id,Sezione,Segno,Ramo,Polizza,Esito,TipoPagamento,DataEsito,CodiceCassa,
                    Contraente,PuntoVendita,TotaleTitolo,TipoMovimento,Spunta) 
                    VALUES (@tipo,@id,@sezione,@segno,0,0,@esito,@pagamento,@dataesito,@cassa,
                    @contraente,@pv,@totale,@movimento,'N')")
            Dim QueryIns As String = ""
            Dim IdTrans As String = IDTransazione()

            With Query
                .Parametro("@tipo", IIf(cboTipoMovimento.SelectedIndex = 0, 9, 100))
                .Parametro("@id", IdTrans, True)
                .Parametro("@esito", "MA", True)
                .Parametro("@pagamento", cboTipoPagamento.Text.Substring(0, 2).Trim, True)
                .Parametro("@dataesito", Format(Giorno, "dd/MM/yyyy"), True)
                .Parametro("@cassa", IIf(cboCassaUscita.SelectedIndex = 0, "00", cboCassaUscita.Text), True)
                .Parametro("@contraente", Microsoft.VisualBasic.Left(txtDesk.Text, 40), True)
                .Parametro("@movimento", cboCodice.Text.ToUpper, True)
                'uscita
                If cboSezioneUscita.SelectedIndex > 0 Then
                    .Parametro("@sezione", SezioneUscita, True)
                    .Parametro("@segno", "U", True)
                    .Parametro("@pv", PvUscita)
                    .Parametro("@totale", -txtImporto.Text)
                    QueryIns = Query.StringaFormattata
                End If
                'entrata
                If cboSezioneEntrata.SelectedIndex > 0 Then
                    .Parametro("@sezione", SezioneEntrata, True)
                    .Parametro("@segno", "E", True)
                    .Parametro("@pv", PvEntrata)
                    .Parametro("@totale", txtImporto.Text)
                    QueryIns &= Environment.NewLine & Query.StringaFormattata
                End If
            End With
            If Utx.WsCommand.ExecuteNonQueryRecord(QueryIns) = 2 Then
                lbStato.Text = "Movimento registrato"
            Else
                lbStato.Text = "Errore nella registrazione del movimento"
            End If

        Catch ex As Exception
            lbStato.Text = "Errore"
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub SalvaMovimentoMisto()

        Dim SezioneUscita As String = cboSezioneUscita.Text.Substring(0, 2).ToUpper
        Dim SezioneEntrata As String = cboSezioneEntrata.Text.Substring(0, 2).ToUpper

        'se il campo importo è vuoto
        If txtImporto.Text = String.Empty Then txtImporto.Text = 0

        'se l'importo è zero
        If txtImporto.Text = 0 Then
            If MsgBox("L'importo è uguale a zero: continuare?",
                      MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2,
                      "Movimento") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        'per movimento misto l'importo non può essere maggiore del totale titolo
        If txtImporto.Text > dr.Cells("TotaleTitolo").Value Then
            MsgBox(String.Format("Importo errato (maggiore di {0}).",
                                 dr.Cells("TotaleTitolo").Value), MsgBoxStyle.Exclamation, Globale.TitoloApp)
            Exit Sub
        End If

        btnSalva.Enabled = False

        Try
            Dim Query As New Utx.NetFunc.StringFormatter("INSERT INTO ChiusuraCassa 
                (TipoRecord,Id,PuntoVendita,Sezione,Segno,Ramo,Polizza,Esito,TipoPagamento,DataEsito,CodiceCassa,
                Contraente,Subagenzia,TotaleTitolo,TipoMovimento,Spunta) 
                VALUES (@tipo,@id,@pv,@sezione,@segno,@ramo,@polizza,@esito,@pagamento,@dataesito,@cassa,
                @contraente,@sub,@totale,@movimento,'N')")
            Dim QueryIns As String = ""
            Dim IdTrans As String = IDTransazione()

            'nel movimento misto che in prima battuta viene sempre messo nei contanti
            'l'uscita è sempre cal cassetto e l'entrata è sempre in banca
            With Query
                .Parametro("@tipo", 9)
                .Parametro("@id", IdTrans, True)
                .Parametro("@ramo", dr.Cells("Ramo").Value)
                .Parametro("@polizza", dr.Cells("Polizza").Value)
                .Parametro("@esito", "MA", True)
                .Parametro("@pagamento", "C", True)
                .Parametro("@dataesito", Format(Giorno, "dd/MM/yyyy"), True)
                .Parametro("@contraente", Microsoft.VisualBasic.Left(txtDesk.Text, 40), True)
                .Parametro("@sub", dr.Cells("Subagenzia").Value)
                .Parametro("@movimento", cboCodice.Text.ToUpper, True)

                'uscita
                .Parametro("@pv", cboPvUscita.Text)
                .Parametro("@sezione", SezioneUscita, True)
                .Parametro("@segno", "U", True)
                .Parametro("@cassa", cboCassaUscita.Text, True)
                .Parametro("@totale", -txtImporto.Text)
                QueryIns = Query.StringaFormattata

                'entrata
                .Parametro("@pv", cboPvEntrata.Text)
                .Parametro("@sezione", SezioneEntrata, True)
                .Parametro("@segno", "E", True)
                .Parametro("@cassa", cboCassaEntrata.Text, True)
                .Parametro("@totale", txtImporto.Text)
                QueryIns &= Environment.NewLine & Query.StringaFormattata
            End With
            If Utx.WsCommand.ExecuteNonQueryRecord(QueryIns) = 2 Then
                lbStato.Text = "Movimento registrato"
            Else
                lbStato.Text = "Errore nella registrazione del movimento"
            End If

        Catch ex As Exception
            lbStato.Text = "Errore"
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        Me.Close()
    End Sub

    Private Sub btnEsci_Click(sender As System.Object, e As System.EventArgs) Handles btnEsci.Click
        Me.Close()
    End Sub

    Private Sub btnNuovo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuovo.Click
        On Error Resume Next

        cboTipoMovimento.SelectedIndex = 0
        cboSezioneUscita.SelectedIndex = 0
        cboPvUscita.SelectedIndex = 0
        cboCassaUscita.SelectedIndex = 0
        cboTipoPagamento.SelectedIndex = 0
        txtDesk.Text = ""
        txtImporto.Text = 0

        lbStato.Text = ""

        btnSalva.Enabled = True
    End Sub

    Private Sub cboTipoMovimento_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoMovimento.SelectedIndexChanged

        If cboTipoMovimento.SelectedIndex = 0 Then
            cboTipoMovimento.BackColor = Color.White
        Else
            cboTipoMovimento.BackColor = Color.Moccasin
        End If

        If Misto = False Then
            ImpostaCodiceMovimento(cboCodice, cboTipoMovimento.SelectedIndex)
        End If

    End Sub

    Private Sub cboSubUscita_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboPvUscita.SelectedIndexChanged
        On Error Resume Next
        cboPvEntrata.SelectedIndex = cboPvUscita.SelectedIndex
    End Sub

    Private Sub cboCassaUscita_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCassaUscita.SelectedIndexChanged
        On Error Resume Next
        cboCassaEntrata.SelectedIndex = cboCassaUscita.SelectedIndex
    End Sub

    Private Sub frmMovimento_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        If Misto = True Then txtImporto.Focus()
    End Sub
End Class