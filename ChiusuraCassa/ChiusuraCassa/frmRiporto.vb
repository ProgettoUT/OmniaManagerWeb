Public Class frmRiporto

    Friend Giorno As Date

    Private Sub frmRiporto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.Icon = My.Resources.euro

        Label1.Text = "Riporto del " + Giorno.ToShortDateString

        With btnSalva
            .Padding = New Padding(10, 0, 10, 0)
            .Image = My.Resources.save.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
            .TextAlign = ContentAlignment.MiddleRight
        End With

        ImpostaSezione(cboSezione, "Incasso conto terzi")
        ImpostaPuntoVendita(cboPv)
        ImpostaCassa(cboCassa, "Tutte")

        txtTotale.ReadOnly = True

        AddHandler txtAssegni.KeyPress, AddressOf txtContanti_KeyPress
        AddHandler txtAssegni.TextChanged, AddressOf txtContanti_TextChanged
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
        txtContanti.Text = Format(CDbl(txtContanti.Text), Globale.FValuta)
    End Sub

    Private Sub txtContanti_TextChanged(sender As Object, e As System.EventArgs) Handles txtContanti.TextChanged
        If txtContanti.Text.Trim = String.Empty Then txtContanti.Text = 0
        If txtAssegni.Text.Trim = String.Empty Then txtAssegni.Text = 0

        txtTotale.Text = Format(CDbl(txtContanti.Text) + CDbl(txtAssegni.Text), Globale.FValuta)
    End Sub

    Private Sub txtAssegni_Leave(sender As Object, e As System.EventArgs) Handles txtAssegni.Leave
        On Error Resume Next
        txtAssegni.Text = Format(CDbl(txtAssegni.Text), Globale.FValuta)
    End Sub

    Private Sub btnSalva_Click(sender As System.Object, e As System.EventArgs) Handles btnSalva.Click

        If txtTotale.Text = String.Empty Then Exit Sub
        If txtTotale.Text = 0 Then Exit Sub

        btnSalva.Enabled = False

        If String.IsNullOrEmpty(txtContanti.Text.Trim) Then txtContanti.Text = 0
        If String.IsNullOrEmpty(txtAssegni.Text.Trim) Then txtAssegni.Text = 0

        Try
            Dim Query As New Utx.NetFunc.StringFormatter("INSERT INTO ChiusuraCassa 
                (TipoRecord,Id,Sezione,Segno,Ramo,Polizza,Esito,TipoPagamento,DataEsito,CodiceCassa,
                Contraente,PuntoVendita,TotaleTitolo,TipoMovimento,Spunta) 
                VALUES (@tipo,@id,@sezione,@segno,0,0,@esito,@pagamento,@dataesito,@cassa,
                @contraente,@pv,@importo,@movimento,'N')")

            Dim IdTrans As String = IDTransazione()
            Dim Pv As Integer = CodicePvSelezionato(cboPv)
            Dim Cassa As String = IIf(cboCassa.SelectedIndex = 0, "00", cboCassa.Text)

            Select Case cboSezione.SelectedIndex
                Case 0 'incassi conto terzi
                    If txtContanti.Text > 0 Then 'contanti
                        With Query
                            .Parametro("@tipo", Globale.TipoRecord.Versamenti) 'versamento
                            .Parametro("@id", IdTrans, True)
                            .Parametro("@sezione", "CA", True)
                            .Parametro("@segno", IIf(txtContanti.Text > 0, "E", "U"), True)
                            .Parametro("@esito", "VE", True)
                            .Parametro("@pagamento", "C", True)
                            .Parametro("@dataesito", Format(Giorno, "dd/MM/yyyy"), True)
                            .Parametro("@cassa", Cassa, True)
                            .Parametro("@contraente", Microsoft.VisualBasic.Left(txtDesk.Text, 40), True)
                            .Parametro("@pv", Pv)
                            .Parametro("@importo", txtContanti.Text)
                            .Parametro("@movimento", "Incasso c/t", True)
                        End With
                        Utx.WsCommand.ExecuteNonQueryRecord(Query.StringaFormattata)
                    End If
                    If txtAssegni.Text > 0 Then 'assegni
                        With Query
                            .Parametro("@tipo", Globale.TipoRecord.Versamenti) 'versamento
                            .Parametro("@id", IdTrans, True)
                            .Parametro("@sezione", "CA", True)
                            .Parametro("@segno", IIf(txtContanti.Text > 0, "E", "U"), True)
                            .Parametro("@esito", "VE", True)
                            .Parametro("@pagamento", "A", True)
                            .Parametro("@dataesito", Format(Giorno, "dd/MM/yyyy"), True)
                            .Parametro("@cassa", Cassa, True)
                            .Parametro("@contraente", txtDesk.Text, True)
                            .Parametro("@pv", Pv)
                            .Parametro("@importo", txtAssegni.Text)
                            .Parametro("@movimento", "Incasso c/t", True)
                        End With
                        Utx.WsCommand.ExecuteNonQueryRecord(Query.StringaFormattata)
                    End If

                Case 1 'riporto in cassa
                    If txtContanti.Text > 0 Then
                        With Query
                            .Parametro("@tipo", Globale.TipoRecord.Riporto) 'riporto
                            .Parametro("@id", IdTrans, True)
                            .Parametro("@sezione", "CA", True)
                            .Parametro("@segno", IIf(txtContanti.Text > 0, "E", "U"), True)
                            .Parametro("@esito", "RP", True)
                            .Parametro("@pagamento", "C", True)
                            .Parametro("@dataesito", Format(Giorno, "dd/MM/yyyy"), True)
                            .Parametro("@cassa", Cassa, True)
                            .Parametro("@contraente", cboSezione.SelectedIndex.ToString + "." + cboSezione.Text, True)
                            .Parametro("@pv", Pv)
                            .Parametro("@importo", txtContanti.Text)
                            .Parametro("@movimento", ">> RIPORTO", True)
                        End With
                        Utx.WsCommand.ExecuteNonQueryRecord(Query.StringaFormattata)
                    End If
                    If txtAssegni.Text > 0 Then 'assegni
                        With Query
                            .Parametro("@tipo", Globale.TipoRecord.Riporto) 'riporto
                            .Parametro("@id", IdTrans, True)
                            .Parametro("@sezione", "CA", True)
                            .Parametro("@segno", IIf(txtContanti.Text > 0, "E", "U"), True)
                            .Parametro("@esito", "RP", True)
                            .Parametro("@pagamento", "A", True)
                            .Parametro("@dataesito", Format(Giorno, "dd/MM/yyyy"), True)
                            .Parametro("@cassa", Cassa, True)
                            .Parametro("@contraente", cboSezione.SelectedIndex.ToString + "." + cboSezione.Text, True)
                            .Parametro("@pv", Pv)
                            .Parametro("@importo", txtAssegni.Text)
                            .Parametro("@movimento", ">> RIPORTO", True)
                        End With
                        Utx.WsCommand.ExecuteNonQueryRecord(Query.StringaFormattata)
                    End If

                Case 2 'banca
                    With Query
                        .Parametro("@tipo", Globale.TipoRecord.Riporto) 'riporto
                        .Parametro("@id", IdTrans, True)
                        .Parametro("@sezione", "BA", True)
                        .Parametro("@segno", IIf(txtContanti.Text > 0, "E", "U"), True)
                        .Parametro("@esito", "RP", True)
                        .Parametro("@pagamento", "B", True)
                        .Parametro("@dataesito", Format(Giorno, "dd/MM/yyyy"), True)
                        .Parametro("@cassa", Cassa, True)
                        .Parametro("@contraente", cboSezione.SelectedIndex.ToString + "." + cboSezione.Text, True)
                        .Parametro("@pv", Pv)
                        .Parametro("@importo", txtContanti.Text)
                        .Parametro("@movimento", ">> RIPORTO", True)
                    End With
                    Utx.WsCommand.ExecuteNonQueryRecord(Query.StringaFormattata)

                Case 3 'co
                    With Query
                        .Parametro("@tipo", Globale.TipoRecord.Riporto) 'riporto
                        .Parametro("@id", IdTrans, True)
                        .Parametro("@sezione", "CO", True)
                        .Parametro("@segno", IIf(txtContanti.Text > 0, "E", "U"), True)
                        .Parametro("@esito", "RP", True)
                        .Parametro("@pagamento", "CO", True)
                        .Parametro("@dataesito", Format(Giorno, "dd/MM/yyyy"), True)
                        .Parametro("@cassa", Cassa, True)
                        .Parametro("@contraente", cboSezione.SelectedIndex.ToString + "." + cboSezione.Text, True)
                        .Parametro("@pv", Pv)
                        .Parametro("@importo", txtContanti.Text)
                        .Parametro("@movimento", ">> RIPORTO", True)
                    End With
                    Utx.WsCommand.ExecuteNonQueryRecord(Query.StringaFormattata)

                Case 4 'scoperti
                    With Query
                        .Parametro("@tipo", Globale.TipoRecord.Riporto) 'riporto
                        .Parametro("@id", IdTrans, True)
                        .Parametro("@sezione", "SC", True)
                        .Parametro("@segno", IIf(txtContanti.Text > 0, "E", "U"), True)
                        .Parametro("@esito", "RP", True)
                        .Parametro("@pagamento", "SC", True)
                        .Parametro("@dataesito", Format(Giorno, "dd/MM/yyyy"), True)
                        .Parametro("@cassa", Cassa, True)
                        .Parametro("@contraente", cboSezione.SelectedIndex.ToString + "." + cboSezione.Text, True)
                        .Parametro("@pv", Pv)
                        .Parametro("@importo", txtContanti.Text)
                        .Parametro("@movimento", ">> RIPORTO", True)
                    End With
                    Utx.WsCommand.ExecuteNonQueryRecord(Query.StringaFormattata)
            End Select

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

        Me.Close()
    End Sub

    Private Sub cboSezione_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSezione.SelectedIndexChanged
        txtContanti.Text = ""
        txtAssegni.Text = ""
        txtDesk.Enabled = (cboSezione.SelectedIndex = 0)
        txtAssegni.Enabled = (cboSezione.SelectedIndex < 2)
    End Sub
End Class