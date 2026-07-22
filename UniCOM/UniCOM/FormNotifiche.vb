Public Class FormNotifiche

    Friend WithEvents FormFiltro As New Utx.FormGestioneFiltro(1000)

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Size = New Size(Utx.InfoSistema.Desktop.Larghezza * 0.7, Utx.InfoSistema.Desktop.Altezza * 0.7)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "Notifiche SMS"
        Me.Icon = Risorse.Immagini.Icon("notifica")

        ImpostaControlli()
    End Sub

    Private mTelefoni As New List(Of String)
    Public Property Telefoni() As List(Of String)
        Get
            Return mTelefoni
        End Get
        Set(value As List(Of String))
            mTelefoni = value
            'riempio il combo
            ComboBoxTelefoni.Items.Clear()
            If mTelefoni.Count > 0 Then
                For Each t As String In mTelefoni
                    ComboBoxTelefoni.Items.Add(t)
                Next
                ComboBoxTelefoni.SelectedIndex = 0
            End If
        End Set
    End Property

    Private Sub FormNotifiche_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

        'cerco le notifiche
        Dim s As New Servizi
        s.CercaNotificheSms(2)

        AddHandler TabPageNumero.Enter, AddressOf TabPageNumero_Enter
        AddHandler TabPageConsegnati.Enter, AddressOf TabPageConsegnati_Enter
        AddHandler TabPageNonConsegnati.Enter, AddressOf TabPageNonConsegnati_Enter
        AddHandler TabPageNonEsitati.Enter, AddressOf TabPageNonEsitati_Enter
        'filtro dgv
        AddHandler dgvNumero.ColumnHeaderMouseClick, AddressOf dgvNumero_ColumnHeaderMouseClick
        AddHandler dgvConsegnati.ColumnHeaderMouseClick, AddressOf dgvNumero_ColumnHeaderMouseClick
        AddHandler dgvNonEsitati.ColumnHeaderMouseClick, AddressOf dgvNumero_ColumnHeaderMouseClick
        AddHandler dgvNonConsegnati.ColumnHeaderMouseClick, AddressOf dgvNumero_ColumnHeaderMouseClick

        'e ora le visualizzo
        TabPageNumero_Enter(Me, New EventArgs)
    End Sub

    Private Sub ImpostaControlli()
        LabelTesto.Text = ""
        LabelTesto.Image = Risorse.Immagini.Bitmap("notifica")
        LabelTesto.ImageAlign = ContentAlignment.MiddleRight
        LabelInfo.Text = "Attendere..."
        LabelInfo.TextAlign = ContentAlignment.MiddleLeft

        TabControlMain.HotTrack = True

        TabPageNumero.Text = "Inviati al numero"
        TabPageConsegnati.Text = "SMS consegnati (tutti)"
        TabPageNonConsegnati.Text = "SMS non consegnati (tutti)"
        TabPageNonEsitati.Text = "SMS non esitati (tutti)"

        With ComboBoxTelefoni
            .DropDownStyle = ComboBoxStyle.DropDown
            .BackColor = Color.Yellow
        End With

        With btnVisualizzaNotifiche
            .Margin = New Padding(0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
        End With
        With btnCercaNotifiche
            .Margin = New Padding(0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .ForeColor = Color.White
            .BackColor = Color.DodgerBlue
        End With
        With btnStampa
            .Margin = New Padding(0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Silver
            .BackColor = Color.Gainsboro
        End With
        With LabelTesto
            .Margin = New Padding(3)
            .Dock = DockStyle.Fill
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = Color.Moccasin
            .Text = ""
            .TextAlign = ContentAlignment.TopLeft
        End With
        With LabelNumeroSms
            .Margin = New Padding(3)
            .Dock = DockStyle.Fill
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = Color.Gold
            .Text = ""
            .TextAlign = ContentAlignment.MiddleCenter
        End With

        Dim Griglie As New Collection
        With Griglie
            .Add(dgvNumero)
            .Add(dgvConsegnati)
            .Add(dgvNonConsegnati)
            .Add(dgvNonEsitati)
        End With

        For Each dgv As DataGridView In Griglie
            With dgv
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .EditMode = DataGridViewEditMode.EditProgrammatically
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .AllowUserToOrderColumns = False
                .CellBorderStyle = DataGridViewCellBorderStyle.Raised
            End With
            Utx.NetFunc.DoppioBuffer(dgv)
        Next
    End Sub

    Private Sub CercaNotifiche()
        'cerco le notifiche
        Dim s As New Servizi
        s.CercaNotificheSms(2)
        'visualizzo le notifiche
        TabPageNumero_Enter(Me, New EventArgs)
    End Sub

    Private Sub dgvNumero_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvNumero.SelectionChanged
        If dgvNumero.CurrentRow IsNot Nothing Then
            LabelTesto.Text = dgvNumero.CurrentRow.Cells("Testo").Value
        End If
    End Sub

    Private Sub dgvConsegnati_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvConsegnati.MouseDoubleClick
        If dgvConsegnati.CurrentRow IsNot Nothing Then
            Dim Lista As New List(Of String) From {dgvConsegnati.CurrentRow.Cells("Telefono").Value}
            Me.Telefoni = Lista
            TabControlMain.SelectedTab = TabPageNumero
        End If
    End Sub

    Private Sub dgvNonConsegnati_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvNonConsegnati.MouseDoubleClick
        If dgvNonConsegnati.CurrentRow IsNot Nothing Then
            Dim Lista As New List(Of String) From {dgvNonConsegnati.CurrentRow.Cells("Telefono").Value}
            Me.Telefoni = Lista
            TabControlMain.SelectedTab = TabPageNumero
        End If
    End Sub

    Private Sub dgvNonEsitati_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvNonEsitati.MouseDoubleClick
        If dgvNonEsitati.CurrentRow IsNot Nothing Then
            Dim Lista As New List(Of String) From {dgvNonEsitati.CurrentRow.Cells("Telefono").Value}
            Me.Telefoni = Lista
            TabControlMain.SelectedTab = TabPageNumero
        End If
    End Sub

    Private Sub dgvConsegnati_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvConsegnati.SelectionChanged
        If dgvConsegnati.CurrentRow IsNot Nothing Then
            LabelTesto.Text = dgvConsegnati.CurrentRow.Cells("Testo").Value
        End If
    End Sub

    Private Sub dgvNonConsegnati_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvNonConsegnati.SelectionChanged
        If dgvNonConsegnati.CurrentRow IsNot Nothing Then
            LabelTesto.Text = dgvNonConsegnati.CurrentRow.Cells("Testo").Value
        End If
    End Sub

    Private Sub dgvNonEsitati_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvNonEsitati.SelectionChanged
        If dgvNonEsitati.CurrentRow IsNot Nothing Then
            LabelTesto.Text = dgvNonEsitati.CurrentRow.Cells("Testo").Value
        End If
    End Sub

    Private Sub TabPageNumero_Enter(sender As Object, e As System.EventArgs)
        'quando le notifiche sono chiamate dal menù non ci sono telefoni impostati e il numero può essere scritto dall'utente
        If mTelefoni.Count = 0 AndAlso String.IsNullOrEmpty(ComboBoxTelefoni.Text) = False Then
            mTelefoni.Add(ComboBoxTelefoni.Text.Trim)
        End If

        dgvNumero.DataSource = Sms.CercaNotifiche(mTelefoni)
        Utx.NetFunc.DataGridViewColumnsNoSort(dgvNumero)
        dgvNumero.AutoResizeColumns()

        If dgvNumero.DataSource IsNot Nothing Then
            FormattaColonne(dgvNumero)

            LabelInfo.Text = String.Format("Inviati {0} sms",
                                           dgvNumero.DataSource.Rows.Count())
        End If
        LabelNumeroSms.Text = String.Format("{1}{0}{0}sms", Environment.NewLine, dgvNumero.Rows.Count)
    End Sub

    Private Sub TabPageConsegnati_Enter(sender As Object, e As System.EventArgs)
        dgvConsegnati.DataSource = Sms.CercaNotifiche(Sms.SmsStatus.Consegnati)
        Utx.NetFunc.DataGridViewColumnsNoSort(dgvConsegnati)
        FormattaColonne(dgvConsegnati)
        LabelNumeroSms.Text = String.Format("{1}{0}{0}sms", Environment.NewLine, dgvConsegnati.Rows.Count)
    End Sub

    Private Sub TabPageNonConsegnati_Enter(sender As Object, e As System.EventArgs)
        dgvNonConsegnati.DataSource = Sms.CercaNotifiche(Sms.SmsStatus.NonConsegnati)
        Utx.NetFunc.DataGridViewColumnsNoSort(dgvNonConsegnati)
        FormattaColonne(dgvNonConsegnati)
        LabelNumeroSms.Text = String.Format("{1}{0}{0}sms", Environment.NewLine, dgvNonConsegnati.Rows.Count)
    End Sub

    Private Sub TabPageNonEsitati_Enter(sender As Object, e As System.EventArgs)
        dgvNonEsitati.DataSource = Sms.CercaNotifiche(Sms.SmsStatus.InAttesa)
        Utx.NetFunc.DataGridViewColumnsNoSort(dgvNonEsitati)
        FormattaColonne(dgvNonEsitati)
        LabelNumeroSms.Text = String.Format("{1}{0}{0}sms", Environment.NewLine, dgvNonEsitati.Rows.Count)
    End Sub

    Private Sub FormattaColonne(ByRef dgv As DataGridView)

        On Error Resume Next

        With dgv
            .SuspendLayout()

            With .Columns("DataInvio")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Data invio"
            End With
            With .Columns("OraInvio")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Ora invio"
            End With
            With .Columns("DataConsegna")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Data consegna"
            End With
            With .Columns("OraConsegna")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Ora consegna"
            End With
            With .Columns("DataInvio")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .HeaderText = "Data invio"
            End With

            .Columns("Stato").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            With .Columns("Testo")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                .HeaderText = "Testo del messaggio"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End With
            With .Columns("Telefono")
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            End With

            'autosize
            .AutoResizeColumns()
            .ResumeLayout()
        End With
    End Sub

    Private Sub btnVisualizzaNotifiche_Click(sender As System.Object, e As System.EventArgs) Handles btnVisualizzaNotifiche.Click
        'visualizzo le notifiche
        TabPageNumero_Enter(Me, New EventArgs)
    End Sub

    Private Sub btnCercaNotifiche_Click(sender As System.Object, e As System.EventArgs) Handles btnCercaNotifiche.Click
        CercaNotifiche()
    End Sub

    Private Sub btnStampa_Click(sender As System.Object, e As System.EventArgs) Handles btnStampa.Click

        If dgvNumero.CurrentRow Is Nothing Then Exit Sub

        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            With PrintDocument1
                .PrinterSettings = PrintDialog1.PrinterSettings
                .DefaultPageSettings.Margins.Top = 80
                .DocumentName = "Dettaglio invio SMS al numero " + ComboBoxTelefoni.Text

                .Print()
            End With
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        StampaSms(e)
    End Sub

    Private Sub StampaSms(e As System.Drawing.Printing.PrintPageEventArgs)

        Dim f As Font = New Font("Verdana", 8)
        Dim fi As Font = New Font("Verdana", 8, FontStyle.Italic)
        Dim fg As Font = New Font("Verdana", 8, FontStyle.Bold) 'grassetto
        Dim fGrande As Font = New Font("Verdana", 12, FontStyle.Bold) 'grande

        Dim p1 As Pen = New Pen(Color.Black, 1)
        Dim p2 As Pen = New Pen(Color.Black, 2)

        Dim y As Single = e.MarginBounds.Top
        Dim Tab() As Int16 = {0, 150, e.MarginBounds.Size.Width}

        Dim Sx, Cx, Dx As New StringFormat
        Sx.Alignment = StringAlignment.Near
        Cx.Alignment = StringAlignment.Center
        Dx.Alignment = StringAlignment.Far

        y += 10

        Dim dr As DataGridViewRow = dgvNumero.CurrentRow

        StampaStringa("Dettaglio invio SMS", Tab(0), y, fGrande, e, Sx, True)
        e.Graphics.DrawLine(p1, e.MarginBounds.Left, y, e.MarginBounds.Right, y)

        ACapo(y, f, e, 1)

        StampaStringa("Destinatario: ", Tab(0), y, fg, e, Sx)
        StampaStringa(ComboBoxTelefoni.Text.Replace("+39", ""), Tab(1), y, f, e, Sx, True)
        StampaStringa("Inviato: ", Tab(0), y, fg, e, Sx)
        StampaStringa(String.Format("il {0} alle {1}",
                                    Format(dr.Cells("DataInvio").Value, "dd-MM-yyyy"),
                                    dr.Cells("OraInvio").Value), Tab(1), y, f, e, Sx, True)
        StampaStringa("Stato: ", Tab(0), y, fg, e, Sx)

        Select Case dr.Cells("Stato").Value

            Case "S"
                StampaStringa(String.Format("CONSEGNATO il {0} alle {1}",
                                            Format(dr.Cells("DataConsegna").Value, "dd-MM-yyyy"),
                                            dr.Cells("OraConsegna").Value),
                                            Tab(1), y, f, e, Sx, True)

            Case "N"
                StampaStringa("NON CONSEGNATO", Tab(1), y, f, e, Sx, True)

            Case "?"
                StampaStringa("IN ATTESA (non ancora esitato)", Tab(1), y, f, e, Sx, True)

            Case "*"
                StampaStringa("NON DEFINITO", Tab(0), y, f, e, Sx, True)
        End Select

        e.Graphics.DrawLine(p1, e.MarginBounds.Left, y, e.MarginBounds.Right, y)
        ACapo(y, f, e, 2)

        StampaStringa("Testo del messaggio:", Tab(0), y, fg, e, Sx, True)
        ACapo(y, f, e, 1)
        StampaTesto(dr.Cells("Testo").Value, y, f, e)

        ACapo(y, f, e, 3)

        e.Graphics.DrawLine(p1, e.MarginBounds.Left, y, e.MarginBounds.Right, y)
        StampaStringa(String.Format("Unitools - Report stampato il {0}", Now.ToString), Tab(0), y, fi, e, Sx)

        e.HasMorePages = False

    End Sub

    Private Function StampaStringa(Testo As String, _
                                   x As Single, _
                                   ByRef y As Single, _
                                   f As Font, _
                                   e As System.Drawing.Printing.PrintPageEventArgs, _
                                   sf As StringFormat, _
                                   Optional ACapo As Boolean = False) As Single

        e.Graphics.DrawString(Testo, _
                              f, _
                              Brushes.Black, _
                              e.MarginBounds.Left + x, _
                              y, _
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

    Private Sub ACapo(ByRef y As Single, _
                  f As Font, _
                  e As System.Drawing.Printing.PrintPageEventArgs, _
                  ACapo As Int16)

        y = y + ACapo * f.GetHeight(e.Graphics)
    End Sub

    Private Sub StampaTesto(Testo As String,
                            ByRef y As Single,
                            pf As Font,
                            e As System.Drawing.Printing.PrintPageEventArgs)

        Dim yPos As Single = y

        'dichiarazioni static
        Static xPos As Single = 0 'x posizione del prossimo token
        Static Tokens() As String 'parole estratte dalla stringa
        Static TokensIdx As Single = -1 'indice

        xPos = e.MarginBounds.Left 'reset margine sinistro
        Tokens = Testo.Split() 'divido in token
        TokensIdx = 0 'azzero l'indice

        yPos = y 'posizione y iniziale

        'stampa tutte le parole
        While TokensIdx < Tokens.Length

            'prendo il token successivo e calcolo la larghezza
            Dim token As String = Tokens(TokensIdx) & " "
            Dim w As SizeF = e.Graphics.MeasureString(token, pf)

            'se eccede la lunghezza della riga vado a capo
            If w.Width + xPos > e.MarginBounds.Right Then
                xPos = e.MarginBounds.Left
                yPos = yPos + pf.GetHeight(e.Graphics)
            End If

            e.Graphics.DrawString(token, pf, Brushes.Black, New Point(xPos, yPos))
            xPos += w.Width
            TokensIdx += 1

            If yPos >= e.MarginBounds.Bottom Then
                e.HasMorePages = True
            End If
        End While

        'per restituire il valore raggiunto dalla y
        y = yPos
    End Sub

    Private Sub dgvNumero_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs)
        VisualizzaFiltro(sender, e.ColumnIndex)
    End Sub

    Public Sub VisualizzaFiltro(ByRef dgv As DataGridView,
                                IndiceColonna As Integer,
                                Optional Centra As Boolean = False)
        Try
            If (dgvNumero.DataSource IsNot Nothing) Then
                'cartella per salvataggio filtro
                With FormFiltro
                    .AppName = "Unicom"
                    .FilterFolder = Utx.Globale.Paths.CartellaSettingRete
                    .TabVisibili(True, False)

                    'visualizzo la finestra del filtro
                    .Visualizza(dgv.Columns(IndiceColonna), Centra)
                    'record visualizzati
                    LabelNumeroSms.Text = String.Format("{1}{0}{0}sms", Environment.NewLine, dgv.Rows.Count)
                End With
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub
End Class