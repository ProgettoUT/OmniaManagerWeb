Public Class frmVersamento

    Friend Giorno As Date

    Private cQuantita As New Collection
    Private cTotali As New Collection
    Private FValuta As String = "###,##0.00"
    Private ToolTip1 As New ToolTip

    Private Sub frmVersamento_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.Icon = My.Resources.euro

        Label8.Text = "Versamento in banca"

        txtTotaleCassetto.ReadOnly = True

        With btnAggiornaAssegni
            .Font = New Font("Tahoma", 12, FontStyle.Bold)
            .Text = "+"
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With btnStampa
            .Padding = New Padding(70, 0, 0, 0)
            .Image = My.Resources.stampa.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With btnSalva
            .Padding = New Padding(10, 0, 10, 0)
            .Image = My.Resources.save.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With btnEsci
            .Padding = New Padding(10, 0, 10, 0)
            .Image = My.Resources.Esci.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With btnCancellaAssegni
            .Text = "Cancella"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = My.Resources.Annulla.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ToolTip1
            .SetToolTip(btnAggiornaAssegni, "Aggiungi al totale assegni")
            .SetToolTip(btnCancellaAssegni, "Cancella uno/tutti")
            .SetToolTip(txtAssegno, "Importo singolo assegno")
        End With

        ImpostaBanca()
        ImpostaPuntoVendita(cboPuntoVendita)
        ImpostaCollezioni()
    End Sub

    Private Sub btnEsci_Click(sender As System.Object, e As System.EventArgs) Handles btnEsci.Click
        Me.Close()
    End Sub

    Private Sub ImpostaCollezioni()
        With cQuantita
            .Add(txt500)
            .Add(txt200)
            .Add(txt100)
            .Add(txt50)
            .Add(txt20)
            .Add(txt10)
            .Add(txt5)
        End With
        With cTotali
            .Add(txt500Tot, "500")
            .Add(txt200Tot, "200")
            .Add(txt100Tot, "100")
            .Add(txt50Tot, "50")
            .Add(txt20Tot, "20")
            .Add(txt10Tot, "10")
            .Add(txt5Tot, "5")
            .Add(txtNumeroAssegni)
        End With

        For Each c As TextBox In cTotali
            c.ReadOnly = True
            c.BackColor = Color.Beige
        Next

        With cboAssegnoTot
            .BackColor = Color.Beige
            .Items.Clear()
            .Items.Add("0")
            .SelectedIndex = 0
        End With

        For Each c As TextBox In cQuantita
            AddHandler c.KeyPress, AddressOf txt500_KeyPress
            AddHandler c.TextChanged, AddressOf txt500_TextChanged
        Next

        txtTotaleCassetto.BackColor = Color.Yellow
        AddHandler txtTotaleCassetto.KeyPress, AddressOf txtMonetaTot_KeyPress
    End Sub

    Private Sub txt500_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txt500.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8
                'ok
            Case Else
                e.KeyChar = ""
        End Select
    End Sub

    Private Sub txt500_TextChanged(sender As System.Object, e As System.EventArgs) Handles txt500.TextChanged
        CalcolaSubTotali()
    End Sub

    Private Sub txtMonetaTot_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMonetaTot.TextChanged
        CalcolaTotali()
    End Sub

    Private Sub txtNumeroAssegni_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumeroAssegni.TextChanged
        CalcolaTotali()
    End Sub

    Private Sub txtAssegno_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAssegno.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8, 44 'numerici, backspace e virgola
                'ok
            Case 46 'punto trasformato in virgola
                e.KeyChar = ","
            Case 13
                AggiungiAssegno()
            Case Else
                e.KeyChar = ""
        End Select
    End Sub

    Private Sub txtMonetaTot_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonetaTot.KeyPress
        Select Case Asc(e.KeyChar)
            Case 48 To 57, 8, 44 'numerici, backspace e virgola
                'ok
            Case 46 'punto trasformato in virgola
                e.KeyChar = ","
            Case Else
                e.KeyChar = ""
        End Select
    End Sub

    Private Sub btnCancellaAssegni_Click(sender As System.Object, e As System.EventArgs) Handles btnCancellaAssegni.Click
        If cboAssegnoTot.SelectedIndex < 0 Then Exit Sub

        If cboAssegnoTot.SelectedIndex = 0 Then
            cboAssegnoTot.Items.Clear()
            cboAssegnoTot.Items.Add("0")
            txtNumeroAssegni.Text = 0
        Else
            cboAssegnoTot.Items(0) = Format(CDbl(cboAssegnoTot.Items(0)) -
                                            CDbl(cboAssegnoTot.Text), FValuta)

            cboAssegnoTot.Items.RemoveAt(cboAssegnoTot.SelectedIndex)
            txtNumeroAssegni.Text -= 1
        End If

        cboAssegnoTot.SelectedIndex = 0
    End Sub

    Private Sub CalcolaSubTotali()
        Try
            Dim SubTotale As Double = 0
            For k As Int16 = 1 To 7
                If IsNumeric(cQuantita(k).Text) Then
                    cTotali(k).Text = Format(cQuantita(k).Text * cQuantita(k).Name.Substring(3), FValuta)
                Else
                    cTotali(k).Text = Format(0, FValuta)
                End If
            Next

            CalcolaTotali()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub CalcolaTotali()
        Try
            txtTotaleCassetto.Text = 0

            Dim Totale As Double = 0
            For k As Int16 = 1 To 7
                If IsNumeric(cTotali(k).Text) Then Totale = Totale + cTotali(k).Text
            Next
            If IsNumeric(txtMonetaTot.Text) Then Totale = Totale + txtMonetaTot.Text
            If IsNumeric(cboAssegnoTot.Items(0)) Then _
                Totale = Totale + CDbl(cboAssegnoTot.Items(0))

            txtTotaleCassetto.Text = Format(Totale, FValuta)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub AggiungiAssegno()
        If txtNumeroAssegni.Text = String.Empty Then txtNumeroAssegni.Text = 0

        If IsNumeric(txtAssegno.Text) Then
            If txtAssegno.Text = 0 Then
                txtAssegno.Text = ""

            ElseIf txtAssegno.Text > 0 Then
                cboAssegnoTot.Items.Add(Format(CDbl(txtAssegno.Text), FValuta))
                cboAssegnoTot.SelectedIndex = 0 'seleziona 0 che contiene il totale

                cboAssegnoTot.Items(0) = Format(CDbl(cboAssegnoTot.Items(0)) +
                                                CDbl(txtAssegno.Text), FValuta)

                txtNumeroAssegni.Text += 1
                txtAssegno.Text = ""
            End If
        Else
            txtAssegno.Text = ""
        End If
    End Sub

    Private Sub btnStampa_Click(sender As System.Object, e As System.EventArgs) Handles btnStampa.Click
        If cboConto.Text = "C/C..." Then
            MsgBox("Selezionare il c/c per il versamento.", MsgBoxStyle.Information)
            Exit Sub
        End If

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            With PrintDocument1
                .PrinterSettings = PrintDialog1.PrinterSettings
                .DocumentName = "Versamento"
                .Print()
            End With
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim f As Font = New Font("Verdana", 12)
        Dim fg As Font = New Font("Verdana", 12, FontStyle.Bold) 'grassetto
        Dim fGrande As Font = New Font("Verdana", 18, FontStyle.Bold) 'grande

        Dim p1 As Pen = New Pen(Color.Black, 1)
        Dim p2 As Pen = New Pen(Color.Black, 2)

        Dim y As Single = e.MarginBounds.Top
        Dim Tab() As Int16 = {0, 200, 350}

        Dim Sx, Dx As New StringFormat
        Sx.Alignment = StringAlignment.Near
        Dx.Alignment = StringAlignment.Far

        'intestazione
        StampaStringa(cboDeskBanca.Text, 0, y, fGrande, e, Sx)
        y += 5
        e.Graphics.DrawLine(p2, e.MarginBounds.Left, y, e.MarginBounds.Right, y)
        ACapo(y, f, e, 2)

        e.Graphics.DrawRectangle(p1,
                                 e.MarginBounds.Left,
                                 y,
                                 e.MarginBounds.Right - e.MarginBounds.Left,
                                 f.GetHeight(e.Graphics) + 2)
        StampaStringa("Conto corrente " + cboConto.Text, 0, y, fg, e, Sx)
        ACapo(y, f, e, 2)

        'banconote e moneta
        StampaStringa("Pezzi", Tab(0), y, fg, e, Sx, False)
        StampaStringa("Taglio", Tab(1), y, fg, e, Dx, False)
        StampaStringa("Totale", Tab(2), y, fg, e, Dx)

        y += 5
        e.Graphics.DrawLine(p2, e.MarginBounds.Left, y, e.MarginBounds.Left + 400, y)

        'per mettere lo zero anche nelle caselle vuote (se ad esempio non hai contanti ma solo assegni)
        CalcolaSubTotali()

        Dim TotaleContanti As Double = 0
        For Each c As TextBox In cQuantita

            StampaStringa(IIf(c.Text.Trim.Length = 0, "-", c.Text), Tab(0), y, f, e, Sx, False)
            StampaStringa("da " + c.Name.Substring(3) + " euro", Tab(1), y, f, e, Dx, False)
            StampaStringa(cTotali(c.Name.Substring(3)).text, Tab(2), y, f, e, Dx)

            TotaleContanti += CDbl(cTotali(c.Name.Substring(3)).text)
        Next

        If txtMonetaTot.Text.Trim = "" Then txtMonetaTot.Text = 0
        StampaStringa("-", Tab(0), y, f, e, Sx, False)
        StampaStringa("Moneta", Tab(1), y, f, e, Dx, False)
        StampaStringa(Format(CDbl(txtMonetaTot.Text), "###,##0.00"), Tab(2), y, f, e, Dx)

        TotaleContanti += CDbl(txtMonetaTot.Text)

        y += 5
        e.Graphics.DrawLine(p1, e.MarginBounds.Left, y, e.MarginBounds.Left + 400, y)

        'totali
        StampaStringa("Totale contanti", Tab(1), y, f, e, Dx, False)
        Dim CurrentX As Single = StampaStringa(Format(TotaleContanti, FValuta), Tab(2), y, f, e, Dx)
        StampaStringa(txtNumeroAssegni.Text, Tab(0), y, f, e, Sx, False)
        StampaStringa("Assegni", Tab(1), y, f, e, Dx, False)
        StampaStringa(cboAssegnoTot.Items.Item(0), Tab(2), y, f, e, Dx)

        y += 5
        e.Graphics.DrawLine(p2, e.MarginBounds.Left, y, e.MarginBounds.Left + 400, y)

        StampaStringa("Totale versamento", Tab(1), y, fg, e, Dx, False)
        CurrentX = StampaStringa(txtTotaleCassetto.Text, Tab(2), y, fg, e, Dx, False)
        StampaStringa("=", CurrentX, y, fg, e, Sx)

        'dettaglio assegni
        ACapo(y, f, e, 3)
        StampaStringa("Dettaglio importi degli assegni versati:", Tab(0), y, f, e, Sx)
        y += 5
        e.Graphics.DrawLine(p1, e.MarginBounds.Left, y, e.MarginBounds.Right, y)

        Tab(0) = 150

        For k As Int16 = 1 To cboAssegnoTot.Items.Count - 1
            StampaStringa(cboAssegnoTot.Items.Item(k), Tab(0), y, f, e, Dx, False)

            Tab(0) += 150

            If Tab(0) > 600 Then
                ACapo(y, f, e, 1)
                Tab(0) = 150
            End If
        Next
        If Tab(0) > 150 Then ACapo(y, f, e, 1)
        y += 5
        e.Graphics.DrawLine(p1, e.MarginBounds.Left, y, e.MarginBounds.Right, y)

        'descrizione
        ACapo(y, f, e, 1)
        StampaStringa(txtDeskMovimento.Text, 0, y, f, e, Sx)

        'data
        ACapo(y, f, e, 3)
        StampaStringa("Versamento del " + Now.ToShortDateString, 0, y, fg, e, Sx)

        'firma
        ACapo(y, f, e, 5)
        e.Graphics.DrawLine(p1, e.MarginBounds.Left, y, e.MarginBounds.Left + 400, y)
        StampaStringa("Firma", 0, y, f, e, Sx)

    End Sub

    Private Function StampaStringa(Testo As String,
                                   x As Single,
                                   ByRef y As Single,
                                   f As Font,
                                   e As System.Drawing.Printing.PrintPageEventArgs,
                                   sf As StringFormat,
                                   Optional ACapo As Boolean = True) As Single

        e.Graphics.DrawString(Testo,
                              f,
                              Brushes.Black,
                              e.MarginBounds.Left + x,
                              y,
                              sf)

        'la funzione restituisce la posizione corrente della x dopo la stampa della stringa
        If ACapo Then
            StampaStringa = 0
            y = y + f.GetHeight(e.Graphics)
        Else
            Select Case sf.Alignment
                Case StringAlignment.Near 'left
                    StampaStringa = x + e.Graphics.MeasureString(Testo, f).Width
                Case StringAlignment.Center
                    StampaStringa = x + e.Graphics.MeasureString(Testo, f).Width / 2
                Case StringAlignment.Far 'right
                    StampaStringa = x
            End Select
        End If

    End Function

    Private Sub ACapo(ByRef y As Single,
                      f As Font,
                      e As System.Drawing.Printing.PrintPageEventArgs,
                      ACapo As Int16)

        y = y + ACapo * f.GetHeight(e.Graphics)
    End Sub

    Private Sub frmVersamento_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        cboPuntoVendita.Focus()
    End Sub

    Private Sub btnSalva_Click(sender As System.Object, e As System.EventArgs) Handles btnSalva.Click
        Try
            btnSalva.Enabled = False

            If cboConto.Text = "C/C..." Then
                MsgBox("Selezionare il c/c per il versamento.", MsgBoxStyle.Information)
                cboConto.Focus()
                Exit Try
            End If

            If txtTotaleCassetto.Text.Trim = String.Empty Then txtTotaleCassetto.Text = 0
            If txtTotaleCassetto.Text = 0 Then Exit Try

            Dim Assegni As Double = cboAssegnoTot.Items(0)
            Dim Contanti As Double = txtTotaleCassetto.Text - Assegni

            If Assegni < 0 OrElse Contanti < 0 Then
                MsgBox("E' necessario inserire importi non negativi.", MsgBoxStyle.Information)
                Exit Try
            End If

            Dim Query As New Utx.NetFunc.StringFormatter("INSERT INTO ChiusuraCassa 
                (TipoRecord,Id,Sezione,Segno,Ramo,Polizza,Esito,TipoPagamento,DataEsito,CodiceCassa,
                Contraente,PuntoVendita,TotaleTitolo,TipoMovimento,Spunta) 
                VALUES (@tipo,@id,@sezione,@segno,0,0,@esito,@pagamento,@dataesito,'00',
                @contraente,@pv,@importo,@movimento,'N')")

            Dim IdTrans As String = IDTransazione()
            Dim Esito As Boolean

            With Query
                .Parametro("@tipo", Globale.TipoRecord.Prelievi)
                .Parametro("@id", IdTrans, True)
                .Parametro("@sezione", "CA", True)
                .Parametro("@segno", "U", True)
                .Parametro("@esito", "PR", True)
                .Parametro("@dataesito", Format(Giorno, "dd/MM/yyyy"), True)
                .Parametro("@contraente", Microsoft.VisualBasic.Left(txtDeskMovimento.Text, 40), True)
                .Parametro("@pv", CodicePvSelezionato(cboPuntoVendita))

                If Contanti > 0 Then
                    'prelievo contanti dal cassetto che vanno in banca
                    .Parametro("@pagamento", "C", True)
                    .Parametro("@importo", -Contanti)
                    .Parametro("@movimento", ">> IN BANCA", True)
                    Esito = Utx.WsCommand.ExecuteNonQueryRecord(Query.StringaFormattata) = 1
                End If

                If Assegni > 0 Then
                    'prelievo assegni dal cassetto che vanno in banca
                    .Parametro("@pagamento", "A", True)
                    .Parametro("@importo", -Assegni)
                    .Parametro("@movimento", ">> IN BANCA", True)
                    Esito = Utx.WsCommand.ExecuteNonQueryRecord(Query.StringaFormattata) = 1
                End If

                'versamento in banca
                .Parametro("@tipo", Globale.TipoRecord.Versamenti)
                .Parametro("@sezione", "BA", True)
                .Parametro("@segno", "E", True)
                .Parametro("@esito", "VE", True)
                .Parametro("@pagamento", "B", True)
                .Parametro("@importo", txtTotaleCassetto.Text)
                .Parametro("@movimento", "VERSAMENTO", True)
                Esito = Utx.WsCommand.ExecuteNonQueryRecord(Query.StringaFormattata) = 1
            End With

            'aggiorno lista conti correnti
            Dim QueryCC As String = String.Format("DECLARE @Conti AS int = (SELECT Count(*) FROM ContiCorrenti WHERE Conto = '{0}')
                IF @Conti = 0 
                BEGIN
                    INSERT INTO ContiCorrenti (Conto,Banca) VALUES('{0}','{1}')
                END
                ELSE 
                BEGIN
                    UPDATE ContiCorrenti SET Banca = '{1}'
                END", cboConto.Text, cboDeskBanca.Text)
            Utx.WsCommand.ExecuteNonQueryRecord(QueryCC)

            If Esito = True Then
                MsgBox("Versamento salvato correttamente", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            Else
                MsgBox("Nel salvataggio del versamento si sono verificati degli errori", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            btnSalva.Enabled = True
        End Try
    End Sub

    Private Sub btnAggiornaAssegni_Click(sender As System.Object, e As System.EventArgs) Handles btnAggiornaAssegni.Click
        AggiungiAssegno()
    End Sub

    Private Sub ImpostaBanca()
        Try
            Dim Query As String = "SELECT * FROM ContiCorrenti"

            Dim dr As DataTableReader = Utx.FunzioniDb.CreaDataTableReader(Query)

            cboConto.Items.Clear()
            cboConto.Items.Add("C/C...")

            cboDeskBanca.Items.Clear()
            cboDeskBanca.Items.Add("Banca...")

            Do While dr.Read
                cboConto.Items.Add(dr("Conto"))
                cboDeskBanca.Items.Add(dr("Banca"))
            Loop

            cboConto.SelectedIndex = 0
            cboDeskBanca.SelectedIndex = 0

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub cboConto_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboConto.SelectedIndexChanged
        cboDeskBanca.SelectedIndex = cboConto.SelectedIndex
    End Sub

    Private Sub cboDeskBanca_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDeskBanca.SelectedIndexChanged
        cboConto.SelectedIndex = cboDeskBanca.SelectedIndex
    End Sub
End Class