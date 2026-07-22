Public Class frmVersamentoSub

    Friend Giorno As Date

    Private Const FValuta = "###,##0.00"

    Private Sub frmVersamentoSub_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.euro

        Label1.Text = "Versamento da subagenzia"

        ImpostaPuntoVendita(cboDest)
        ImpostaPuntoVendita(cboOrigine)

        With btnSalva
            .Padding = New Padding(10, 0, 10, 0)
            .Image = My.Resources.save.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With cboTipoVersamento
            .Items.Clear()
            .Items.Add("...")
            .Items.Add("Versamento nel cassetto")
            .Items.Add("Bonifico bancario")
            .SelectedIndex = 0
        End With

        txtTotale.ReadOnly = True

        AddHandler txtAssegni.KeyPress, AddressOf txtContanti_KeyPress
        AddHandler txtAssegni.TextChanged, AddressOf txtContanti_TextChanged
    End Sub

    Private Sub cboOrigine_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboOrigine.SelectedIndexChanged
        ControlloBottoneSalva()
    End Sub

    Private Sub cboTipoVersamento_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTipoVersamento.SelectedIndexChanged
        txtContanti.Enabled = (cboTipoVersamento.SelectedIndex > 0)
        txtAssegni.Enabled = (cboTipoVersamento.SelectedIndex > 0)
        txtTotale.Enabled = (cboTipoVersamento.SelectedIndex > 0)
        ControlloBottoneSalva()
    End Sub

    Private Sub txtContanti_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtContanti.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8, 44 'numerici, backspace e virgola
                'ok
            Case 46 'punto trasformato in virgola
                e.KeyChar = ","
            Case Else
                e.KeyChar = ""
        End Select
    End Sub

    Private Sub txtContanti_Leave(sender As Object, e As System.EventArgs) Handles txtContanti.Leave
        On Error Resume Next
        txtContanti.Text = Format(CDbl(txtContanti.Text), FValuta)
    End Sub

    Private Sub txtContanti_TextChanged(sender As Object, e As System.EventArgs) Handles txtContanti.TextChanged
        If txtContanti.Text.Trim = String.Empty Then txtContanti.Text = 0
        If txtAssegni.Text.Trim = String.Empty Then txtAssegni.Text = 0

        txtTotale.Text = Format(CDbl(txtContanti.Text) + CDbl(txtAssegni.Text), FValuta)
    End Sub

    Private Sub txtAssegni_Leave(sender As Object, e As System.EventArgs) Handles txtAssegni.Leave
        On Error Resume Next
        txtAssegni.Text = Format(CDbl(txtAssegni.Text), FValuta)
    End Sub

    Private Sub btnSalva_Click(sender As System.Object, e As System.EventArgs) Handles btnSalva.Click

        If txtTotale.Text = String.Empty Then txtTotale.Text = 0
        If txtTotale.Text = 0 Then Exit Sub

        btnSalva.Enabled = False

        If String.IsNullOrEmpty(txtContanti.Text.Trim) Then txtContanti.Text = 0
        If String.IsNullOrEmpty(txtAssegni.Text.Trim) Then txtAssegni.Text = 0

        Dim PvUscita As Integer = CodicePvSelezionato(cboOrigine)
        Dim PvEntrata As Integer = CodicePvSelezionato(cboDest)

        Dim DeskUscita As String = String.Format(">> A Pv {0}", PvEntrata)
        Dim DeskEntrata As String = String.Format(">> DA Pv {0}", PvUscita)

        Try
            If txtContanti.Text < 0 OrElse txtAssegni.Text < 0 Then
                MsgBox("E' necessario inserire importi non negativi.", MsgBoxStyle.Exclamation)
                Exit Try
            End If

            Dim Query As New Utx.NetFunc.StringFormatter("INSERT INTO ChiusuraCassa 
                (TipoRecord,Id,Sezione,Segno,Ramo,Polizza,Esito,TipoPagamento,DataEsito,CodiceCassa,
                Contraente,PuntoVendita,TotaleTitolo,TipoMovimento,Spunta) 
                VALUES (@tipo,@id,@sezione,@segno,0,0,@esito,@pagamento,@dataesito,'00',
                @contraente,@pv,@importo,@movimento,'N')")

            Dim IdTrans As String = IDTransazione()

            If cboTipoVersamento.SelectedIndex = 1 Then 'versamento in cassa

                'contanti
                With Query
                    If txtContanti.Text > 0 Then
                        .Parametro("@id", IdTrans, True)
                        .Parametro("@sezione", "CA", True)
                        .Parametro("@pagamento", "C", True)
                        .Parametro("@dataesito", Format(Giorno, "dd/MM/yyyy"), True)
                        .Parametro("@contraente", Microsoft.VisualBasic.Left(DeskUscita, 40), True)

                        'prelievo contanti
                        .Parametro("@tipo", Globale.TipoRecord.Prelievi)
                        .Parametro("@segno", "U", True)
                        .Parametro("@esito", "PR", True)
                        .Parametro("@contraente", "Prelievo", True)
                        .Parametro("@pv", PvUscita)
                        .Parametro("@importo", -txtContanti.Text)
                        .Parametro("@movimento", DeskUscita)
                        Utx.WsCommand.ExecuteNonQueryRecord(Query.StringaFormattata)

                        'versamento in cassa dei contanti
                        .Parametro("@tipo", Globale.TipoRecord.Versamenti)
                        .Parametro("@segno", "E", True)
                        .Parametro("@esito", "VE", True)
                        .Parametro("@contraente", "Versamento", True)
                        .Parametro("@pv", PvEntrata)
                        .Parametro("@importo", txtContanti.Text)
                        .Parametro("@movimento", DeskEntrata)
                        Utx.WsCommand.ExecuteNonQueryRecord(Query.StringaFormattata)
                    End If
                End With

                'assegni
                With Query
                    If txtAssegni.Text > 0 Then
                        .Parametro("@id", IdTrans, True)
                        .Parametro("@sezione", "CA", True)
                        .Parametro("@dataesito", Format(Giorno, "dd/MM/yyyy"), True)
                        .Parametro("@pagamento", "A", True)

                        'prelievo assegni
                        .Parametro("@tipo", Globale.TipoRecord.Prelievi)
                        .Parametro("@segno", "U", True)
                        .Parametro("@esito", "PR", True)
                        .Parametro("@pagamento", "A", True)
                        .Parametro("@contraente", "Prelievo", True)
                        .Parametro("@pv", PvUscita)
                        .Parametro("@importo", -txtAssegni.Text)
                        .Parametro("@movimento", DeskUscita, True)
                        Utx.WsCommand.ExecuteNonQueryRecord(Query.StringaFormattata)

                        'versamento in cassa degli assegni
                        .Parametro("@tipo", Globale.TipoRecord.Versamenti)
                        .Parametro("@segno", "E", True)
                        .Parametro("@esito", "VE", True)
                        .Parametro("@contraente", "Versamento", True)
                        .Parametro("@pv", PvEntrata)
                        .Parametro("@importo", txtAssegni.Text)
                        .Parametro("@movimento", DeskEntrata, True)
                        Utx.WsCommand.ExecuteNonQueryRecord(Query.StringaFormattata)
                    End If
                End With

            Else 'bonifico
                With Query
                    .Parametro("@tipo", Globale.TipoRecord.Prelievi)
                    .Parametro("@id", IdTrans, True)
                    .Parametro("@sezione", "CA", True)
                    .Parametro("@segno", "U", True)
                    .Parametro("@esito", "PR", True)
                    .Parametro("@dataesito", Format(Giorno, "dd/MM/yyyy"), True)
                    .Parametro("@contraente", "Bonifico", True)

                    If txtContanti.Text > 0 Then
                        'prelievo contanti in cassa
                        .Parametro("@pagamento", "C", True)
                        .Parametro("@pv", PvUscita)
                        .Parametro("@importo", -txtContanti.Text)
                        .Parametro("@movimento", DeskUscita, True)
                        Utx.WsCommand.ExecuteNonQueryRecord(Query.StringaFormattata)
                    End If

                    If txtAssegni.Text > 0 Then
                        'prelievo assegni in cassa
                        .Parametro("@pagamento", "A", True)
                        .Parametro("@pv", PvUscita)
                        .Parametro("@importo", -txtAssegni.Text)
                        .Parametro("@movimento", DeskUscita, True)
                        Utx.WsCommand.ExecuteNonQueryRecord(Query.StringaFormattata)
                    End If

                    'versamento in banca
                    .Parametro("@tipo", Globale.TipoRecord.Versamenti)
                    .Parametro("@sezione", "BA", True)
                    .Parametro("@segno", "E", True)
                    .Parametro("@esito", "VE", True)
                    .Parametro("@pagamento", "B", True)
                    .Parametro("@contraente", "Versamento", True)
                    .Parametro("@pv", PvEntrata)
                    .Parametro("@importo", txtTotale.Text)
                    .Parametro("@movimento", DeskEntrata, True)
                    Utx.WsCommand.ExecuteNonQueryRecord(Query.StringaFormattata)
                End With
            End If

            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cboDest_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDest.SelectedIndexChanged
        ControlloBottoneSalva()
    End Sub

    Private Sub ControlloBottoneSalva()
        btnSalva.Enabled = (cboDest.Text <> cboOrigine.Text) And (cboTipoVersamento.SelectedIndex > 0)
    End Sub
End Class