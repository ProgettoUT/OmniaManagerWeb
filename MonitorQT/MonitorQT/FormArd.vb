Public Class FormArd

    Private FontBold As Font = New Font("Tahoma", 10, FontStyle.Bold)
    Private siSaturazioneSI As New ListViewItem.ListViewSubItem
    Private siSaturazioneNO As New ListViewItem.ListViewSubItem
    Private r As DataGridViewRow
    Private NumeroPagina As Integer
    Private WithEvents PrintDocument1 As New System.Drawing.Printing.PrintDocument

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
    End Sub

    Private mMain As FormMain
    Public Property Main() As FormMain
        Get
            Return mMain
        End Get
        Set(value As FormMain)
            mMain = value
        End Set
    End Property

    Private mTabDefault As String
    Public Property TabDefault() As String
        Get
            Return TabControl1.SelectedTab.Name
        End Get
        Set(value As String)
            mTabDefault = value
        End Set
    End Property

    Private mStampaAutomatica As Boolean
    Public Property StampaAutomatica() As Boolean
        Get
            Return mStampaAutomatica
        End Get
        Set(value As Boolean)
            mStampaAutomatica = value
        End Set
    End Property

    Private mSettingStampante As Printing.PrinterSettings
    Public Property SettingStampante() As Printing.PrinterSettings
        Get
            Return mSettingStampante
        End Get
        Set(value As Printing.PrinterSettings)
            mSettingStampante = value
        End Set
    End Property


    Private Sub frmArd_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'riga corrente
        r = Main.dgv1.CurrentRow

        Me.Text = r.Cells("Contraente").Value

        With siSaturazioneSI
            .BackColor = Color.Black
            .ForeColor = Color.White
            .Font = FontBold
            .Text = "S"
        End With
        siSaturazioneNO.Text = "N"

        Label1.Text = "I premi indicati sono netti annui."
        Label1.BackColor = Color.Gainsboro

        TabRca.Padding = New Padding(1)
        TabRca.Text = String.Format("Rca - Targa {0}", r.Cells("Targa").Value)
        TabIF.Padding = New Padding(1)
        TabArd.Padding = New Padding(1)
        TabUnibox.Padding = New Padding(1)
    End Sub

    Private Sub frmArd_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        TabControl1.SelectTab(mTabDefault)

        'se è selezionata la prima scheda l'evento non si genera
        If TabControl1.SelectedIndex = 0 Then
            Rca()
        End If

        Me.Refresh()

        If mStampaAutomatica = True Then
            Stampa()
            Me.Close()
        End If
    End Sub

    Private Sub btnChiudi_Click(sender As System.Object, e As System.EventArgs) Handles btnChiudi.Click
        Me.Close()
    End Sub

    Private Sub Stampa()

        With PrintDocument1
            .PrinterSettings = mSettingStampante
            .DefaultPageSettings.Margins.Top = 80
            .DocumentName = "Dettaglio " + Main.dgv1.CurrentRow.Cells("Contraente").Value

            NumeroPagina = 1

            .Print()
        End With
    End Sub

    Private Sub btnStampa_Click(sender As System.Object, e As System.EventArgs) Handles btnStampa.Click
        If PrintDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            With PrintDocument1
                .PrinterSettings = PrintDialog1.PrinterSettings
                .DefaultPageSettings.Margins.Top = 80
                .DocumentName = "Dettaglio " + Main.dgv1.CurrentRow.Cells("Contraente").Value

                NumeroPagina = 1

                .Print()
            End With
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        If NumeroPagina = 1 Then
            PaginaUno(e)
        ElseIf NumeroPagina = 2 Then
            PaginaDue(e)
        End If

    End Sub

    Private Sub PaginaUno(e As System.Drawing.Printing.PrintPageEventArgs)
        Dim f As Font = New Font("Verdana", 8)
        Dim fg As Font = New Font("Verdana", 8, FontStyle.Bold) 'grassetto
        Dim fGrande As Font = New Font("Verdana", 12, FontStyle.Bold) 'grande

        Dim p1 As Pen = New Pen(Color.Black, 1)
        Dim p2 As Pen = New Pen(Color.Black, 2)

        Dim y As Single = e.MarginBounds.Top
        Dim Tab() As Int16 = {0, 250, 390, 460, 530, 550, 600, e.MarginBounds.Size.Width}

        Dim Sx, Cx, Dx As New StringFormat
        Sx.Alignment = StringAlignment.Near
        Cx.Alignment = StringAlignment.Center
        Dx.Alignment = StringAlignment.Far

        'compilo le pagine
        Rca()
        IncendioFurto()
        Ard()
        Unibox()

        IntestazionePagina(y, fg, fGrande, e)
        y += 10

        StampaStringa("Riepilogo premi", Tab(0), y, fg, e, Sx)
        StampaStringa("Premi lordi di rata", Tab(7), y, f, e, Dx, True)
        e.Graphics.DrawLine(p1, e.MarginBounds.Left, y, e.MarginBounds.Right, y)
        StampaStringa("Descrizione", Tab(0), y, f, e, Sx)
        StampaStringa("Precedente", Tab(1), y, f, e, Dx)
        StampaStringa("Attuale", Tab(2), y, f, e, Dx)
        StampaStringa("Diff.", Tab(3), y, f, e, Dx, True)
        e.Graphics.DrawLine(p1, e.MarginBounds.Left, y, e.MarginBounds.Right, y)
        With Main
            StampaStringa("Rca", Tab(0), y, f, e, Sx)
            StampaStringa(.txtRcaOld.Text, Tab(1), y, f, e, Dx)
            StampaStringa(.txtRca.Text, Tab(2), y, f, e, Dx)
            StampaStringa(FormIt(.txtRca.Text - .txtRcaOld.Text), Tab(3), y, f, e, Dx, True)
            StampaStringa("Incendio e furto", Tab(0), y, f, e, Sx)
            StampaStringa(.txtIFOld.Text, Tab(1), y, f, e, Dx)
            StampaStringa(.txtIF.Text, Tab(2), y, f, e, Dx)
            StampaStringa(FormIt(.txtIF.Text - .txtIFOld.Text), Tab(3), y, f, e, Dx, True)
            StampaStringa("Kasko", Tab(0), y, f, e, Sx)
            StampaStringa(.txtKaskoOld.Text, Tab(1), y, f, e, Dx)
            StampaStringa(.txtKasko.Text, Tab(2), y, f, e, Dx)
            StampaStringa(FormIt(.txtKasko.Text - .txtKaskoOld.Text), Tab(3), y, f, e, Dx, True)
            StampaStringa("Altra ard", Tab(0), y, f, e, Sx)
            StampaStringa(.txtArdOld.Text, Tab(1), y, f, e, Dx)
            StampaStringa(.txtArd.Text, Tab(2), y, f, e, Dx)
            StampaStringa(FormIt(.txtArd.Text - .txtArdOld.Text), Tab(3), y, f, e, Dx, True)
            StampaStringa("Totale rata", Tab(0), y, fg, e, Sx)
            StampaStringa(.txtSubTotaleRataOld.Text, Tab(1), y, fg, e, Dx)
            StampaStringa(.txtSubTotaleRata.Text, Tab(2), y, fg, e, Dx)
            StampaStringa(FormIt(.txtSubTotaleRata.Text - .txtSubTotaleRataOld.Text), Tab(3), y, fg, e, Dx, True)
            StampaStringa("Unibox", Tab(0), y, f, e, Sx)
            StampaStringa(.txtUniboxOld.Text, Tab(1), y, f, e, Dx)
            StampaStringa(.txtUnibox.Text, Tab(2), y, f, e, Dx)
            StampaStringa(FormIt(.txtUnibox.Text - .txtUniboxOld.Text), Tab(3), y, f, e, Dx, True)
            StampaStringa("Totale con unibox", Tab(0), y, fg, e, Sx)
            StampaStringa(.txtTotaleRataOld.Text, Tab(1), y, fg, e, Dx)
            StampaStringa(.txtTotaleRata.Text, Tab(2), y, fg, e, Dx)
            StampaStringa(FormIt(.txtTotaleRata.Text - .txtTotaleRataOld.Text), Tab(3), y, fg, e, Dx, True)
        End With
        e.Graphics.DrawLine(p1, e.MarginBounds.Left, y, e.MarginBounds.Right, y)
        y += 5

        'rca
        StampaStringa("Rca", Tab(0), y, fg, e, Sx, True)
        IntestazioneRca(Tab, y, f, e)
        For Each i As ListViewItem In lvRca.Items
            Try
                StampaStringa(i.SubItems(0).Text, Tab(0), y, f, e, Sx)
                StampaStringa(i.SubItems(1).Text, Tab(1), y, f, e, Dx)
                StampaStringa(i.SubItems(2).Text, Tab(2), y, f, e, Dx)
                StampaStringa(i.SubItems(3).Text, Tab(3), y, f, e, Dx)
                StampaStringa(i.SubItems(4).Text, Tab(5), y, f, e, Cx, True)
            Catch ex As Exception
                ACapo(y, f, e, 1)
            End Try
        Next
        e.Graphics.DrawLine(p1, e.MarginBounds.Left, y, e.MarginBounds.Right, y)
        ACapo(y, f, e, 1)
        y += 5

        'if
        StampaStringa("Incendio, Furto & Co", Tab(0), y, fg, e, Sx)
        StampaStringa("Premi netti annui", Tab(7), y, f, e, Dx, True)
        Intestazione(Tab, y, f, e)
        For Each i As ListViewItem In lvIF.Items
            Try
                StampaStringa(i.SubItems(0).Text, Tab(0), y, f, e, Sx)
                StampaStringa(i.SubItems(1).Text, Tab(1), y, f, e, Dx)
                StampaStringa(i.SubItems(2).Text, Tab(2), y, f, e, Dx)
                StampaStringa(i.SubItems(3).Text, Tab(3), y, f, e, Dx)
                StampaStringa(i.SubItems(4).Text, Tab(4), y, f, e, Dx)
                StampaStringa(i.SubItems(5).Text, Tab(5), y, f, e, Cx)
                StampaStringa(i.SubItems(6).Text, Tab(6), y, f, e, Cx, True)
            Catch ex As Exception
                ACapo(y, f, e, 1)
            End Try
        Next
        e.Graphics.DrawLine(p1, e.MarginBounds.Left, y, e.MarginBounds.Right, y)
        ACapo(y, f, e, 1)
        y += 5

        'ard
        StampaStringa("Altro CVT", Tab(0), y, fg, e, Sx)
        StampaStringa("Premi netti annui", Tab(7), y, f, e, Dx, True)
        Intestazione(Tab, y, f, e)
        For Each i As ListViewItem In lvArd.Items
            Try
                StampaStringa(i.SubItems(0).Text, Tab(0), y, f, e, Sx)
                StampaStringa(i.SubItems(1).Text, Tab(1), y, f, e, Dx)
                StampaStringa(i.SubItems(2).Text, Tab(2), y, f, e, Dx)
                StampaStringa(i.SubItems(3).Text, Tab(3), y, f, e, Dx)
                StampaStringa(i.SubItems(4).Text, Tab(4), y, f, e, Dx)
                StampaStringa(i.SubItems(5).Text, Tab(5), y, f, e, Cx)
                StampaStringa(i.SubItems(6).Text, Tab(6), y, f, e, Cx, True)
            Catch ex As Exception
                ACapo(y, f, e, 1)
            End Try
        Next
        e.Graphics.DrawLine(p1, e.MarginBounds.Left, y, e.MarginBounds.Right, y)
        ACapo(y, f, e, 1)
        y += 5

        'unibox
        StampaStringa("Unibox", Tab(0), y, fg, e, Sx)
        StampaStringa("Premi netti annui", Tab(7), y, f, e, Dx, True)
        Intestazione(Tab, y, f, e)
        For Each i As ListViewItem In lvUnibox.Items
            Try
                StampaStringa(i.SubItems(0).Text, Tab(0), y, f, e, Sx)
                StampaStringa(i.SubItems(1).Text, Tab(1), y, f, e, Dx)
                StampaStringa(i.SubItems(2).Text, Tab(2), y, f, e, Dx)
                StampaStringa(i.SubItems(3).Text, Tab(3), y, f, e, Dx)
                StampaStringa(i.SubItems(4).Text, Tab(4), y, f, e, Dx, True)
            Catch ex As Exception
                ACapo(y, f, e, 1)
            End Try
        Next
        e.Graphics.DrawLine(p1, e.MarginBounds.Left, y, e.MarginBounds.Right, y)
        ACapo(y, f, e, 1)

        StampaStringa("Stampato il " + Now.ToString, Tab(0), y, fg, e, Sx)

        If chkStampaNote.Checked = True Then
            e.HasMorePages = True
            NumeroPagina += 1
        Else
            e.HasMorePages = False
        End If

    End Sub

    Private Sub PaginaDue(e As System.Drawing.Printing.PrintPageEventArgs)

        Dim p As New Pen(Color.Black, 1)
        Dim f As Font = New Font("Verdana", 8)
        Dim fg As Font = New Font("Verdana", 8, FontStyle.Bold) 'grassetto
        Dim fGrande As Font = New Font("Verdana", 12, FontStyle.Bold) 'grande

        Dim y As Single = e.MarginBounds.Top
        Dim Tab() As Int16 = {0, 200, 300, 400, 620, e.MarginBounds.Size.Width}

        Dim Sx, Cx, Dx As New StringFormat
        Sx.Alignment = StringAlignment.Near
        Cx.Alignment = StringAlignment.Center
        Dx.Alignment = StringAlignment.Far

        IntestazionePagina(y, fg, fGrande, e)
        y += 10

        'dettaglio e note
        StampaStringa("Dettaglio e note", Tab(0), y, fg, e, Sx, True)
        e.Graphics.DrawLine(p, e.MarginBounds.Left, y, e.MarginBounds.Right, y)
        StampaStringa("Descrizione", Tab(0), y, f, e, Sx)
        StampaStringa("Precedente", Tab(1), y, f, e, Dx)
        StampaStringa("Attuale", Tab(2), y, f, e, Dx)
        StampaStringa("Desiderato", Tab(3), y, f, e, Dx)
        StampaStringa("Flex", Tab(4), y, f, e, Dx, True)
        e.Graphics.DrawLine(p, e.MarginBounds.Left, y, e.MarginBounds.Right, y)

        ACapo(y, f, e, 0)

        StampaStringa("Rca", Tab(0), y, f, e, Sx)
        StampaStringa(Main.txtRcaOld.Text, Tab(1), y, f, e, Dx)
        StampaStringa(Main.txtRca.Text, Tab(2), y, f, e, Dx)
        StampaStringa(Main.txtRca2.Text, Tab(3), y, f, e, Dx)
        StampaStringa(String.Format("{0} ({1}%)",
                                    Main.txtFlexRcaImporto.Text,
                                    Main.txtFlexRcaPerc.Text), Tab(4), y, f, e, Dx, True)
        StampaStringa("Inc.e furto", Tab(0), y, f, e, Sx)
        StampaStringa(Main.txtIFOld.Text, Tab(1), y, f, e, Dx)
        StampaStringa(Main.txtIF.Text, Tab(2), y, f, e, Dx)
        StampaStringa(Main.txtIF2.Text, Tab(3), y, f, e, Dx)
        StampaStringa(String.Format("{0} ({1}%)",
                                    Main.txtFlexIFImporto.Text,
                                    Main.txtFlexIFPerc.Text), Tab(4), y, f, e, Dx, True)
        StampaStringa("Kasko", Tab(0), y, f, e, Sx)
        StampaStringa(Main.txtKaskoOld.Text, Tab(1), y, f, e, Dx)
        StampaStringa(Main.txtKasko.Text, Tab(2), y, f, e, Dx)
        StampaStringa(Main.txtKasko2.Text, Tab(3), y, f, e, Dx)
        StampaStringa(String.Format("{0} ({1}%)",
                                    Main.txtFlexKaskoImporto.Text,
                                    Main.txtFlexKaskoPerc.Text), Tab(4), y, f, e, Dx, True)
        StampaStringa("Altra ARD", Tab(0), y, f, e, Sx)
        StampaStringa(Main.txtArdOld.Text, Tab(1), y, f, e, Dx)
        StampaStringa(Main.txtArd.Text, Tab(2), y, f, e, Dx)
        StampaStringa(Main.txtArd2.Text, Tab(3), y, f, e, Dx, True)

        StampaStringa("Totale rata", Tab(0), y, f, e, Sx)
        StampaStringa(Main.txtSubTotaleRataOld.Text, Tab(1), y, f, e, Dx)
        StampaStringa(Main.txtSubTotaleRata.Text, Tab(2), y, f, e, Dx)
        StampaStringa(Main.txtSubTotaleRata2.Text, Tab(3), y, f, e, Dx, True)

        StampaStringa("Canone Unibox", Tab(0), y, f, e, Sx)
        StampaStringa(Main.txtUniboxOld.Text, Tab(1), y, f, e, Dx)
        StampaStringa(Main.txtUnibox.Text, Tab(2), y, f, e, Dx)
        StampaStringa(Main.txtUnibox2.Text, Tab(3), y, f, e, Dx, True)

        StampaStringa("Totale con Unibox", Tab(0), y, f, e, Sx)
        StampaStringa(Main.txtTotaleRataOld.Text, Tab(1), y, f, e, Dx)
        StampaStringa(Main.txtTotaleRata.Text, Tab(2), y, f, e, Dx)
        StampaStringa(Main.txtTotaleRata2.Text, Tab(3), y, f, e, Dx, True)

        StampaStringa("Flex %", Tab(0), y, f, e, Sx)
        StampaStringa(Main.txtFlexOld.Text, Tab(1), y, f, e, Dx, True)

        ACapo(y, f, e, 1)

        e.Graphics.DrawLine(p, e.MarginBounds.Left, y, e.MarginBounds.Right, y)
        StampaStringa("Note", Tab(0), y, f, e, Sx, True)
        e.Graphics.DrawLine(p, e.MarginBounds.Left, y, e.MarginBounds.Right, y)

        ACapo(y, f, e, 0)

        StampaStringa(Main.txtNote.Text, Tab(0), y, f, e, Sx, True)

        e.HasMorePages = False
        NumeroPagina = 1
    End Sub

    Private Sub Intestazione(ByRef Tab() As Int16, _
                             ByRef y As Single, _
                             f As Font, _
                             e As System.Drawing.Printing.PrintPageEventArgs)

        Dim p As New Pen(Color.Black, 1)

        Dim Sx, Cx, Dx As New StringFormat
        Sx.Alignment = StringAlignment.Near
        Cx.Alignment = StringAlignment.Center
        Dx.Alignment = StringAlignment.Far

        e.Graphics.DrawLine(p, e.MarginBounds.Left, y, e.MarginBounds.Right, y)
        StampaStringa("Descrizione", Tab(0), y, f, e, Sx)
        StampaStringa("Precedente", Tab(1), y, f, e, Dx)
        StampaStringa("Attuale", Tab(2), y, f, e, Dx)
        StampaStringa("Diff.", Tab(3), y, f, e, Dx)
        StampaStringa("Flex", Tab(4), y, f, e, Dx)
        StampaStringa("Sat.", Tab(5), y, f, e, Cx)
        StampaStringa("Forma", Tab(6), y, f, e, Cx, True)
        e.Graphics.DrawLine(p, e.MarginBounds.Left, y, e.MarginBounds.Right, y)

    End Sub

    Private Sub IntestazionePagina(ByRef y As Single,
                                   fGrassetto As Font,
                                   fGrande As Font,
                                   e As System.Drawing.Printing.PrintPageEventArgs)

        Dim p As New Pen(Color.Black, 1)
        Dim Sx, Cx, Dx As New StringFormat
        Sx.Alignment = StringAlignment.Near
        Cx.Alignment = StringAlignment.Center
        Dx.Alignment = StringAlignment.Far

        Dim Tab() As Int16 = {0, 250, 390, 460, 530, 550, 600, e.MarginBounds.Size.Width}

        With Main.dgv1.CurrentRow
            e.Graphics.DrawLine(p, e.MarginBounds.Left, y, e.MarginBounds.Right, y)
            StampaStringa(String.Format("{0} - Targa {1}",
                                        .Cells("Contraente").Value,
                                        .Cells("Targa").Value), Tab(0), y, fGrande, e, Sx, True)
            StampaStringa(String.Format("Polizza 30/{0} - Scadenza del {1}",
                                        .Cells("Polizza").Value.ToString,
                                        .Cells("Effetto").Value.ToShortDateString),
                          Tab(0), y, fGrande, e, Sx, True)
            e.Graphics.DrawLine(p, e.MarginBounds.Left, y, e.MarginBounds.Right, y)
            y += 10
            StampaStringa("Tipo quietanza: " + TipoQuietanza(Main.dgv1.CurrentRow), Tab(0), y, fGrassetto, e, Sx)
            StampaStringa("Frazionamento: " + .Cells("FrazNew").Value.ToString, Tab(1), y, fGrassetto, e, Sx, True)
            StampaStringa("Convenzione: " + .Cells("Convenzione").Value.ToString, Tab(0), y, fGrassetto, e, Sx)
            StampaStringa("Sub: " + .Cells("Sub").Value.ToString, Tab(1), y, fGrassetto, e, Sx, True)
        End With

    End Sub

    Private Sub IntestazioneRca(ByRef Tab() As Int16, _
                                ByRef y As Single, _
                                f As Font, _
                                e As System.Drawing.Printing.PrintPageEventArgs)

        Dim p As New Pen(Color.Black, 1)

        Dim Sx, Cx, Dx As New StringFormat
        Sx.Alignment = StringAlignment.Near
        Cx.Alignment = StringAlignment.Center
        Dx.Alignment = StringAlignment.Far

        e.Graphics.DrawLine(p, e.MarginBounds.Left, y, e.MarginBounds.Right, y)
        StampaStringa("Descrizione", Tab(0), y, f, e, Sx)
        StampaStringa("Precedente", Tab(1), y, f, e, Dx)
        StampaStringa("Attuale", Tab(2), y, f, e, Dx)
        StampaStringa("B/M", Tab(3), y, f, e, Dx)
        StampaStringa("Sat.", Tab(5), y, f, e, Cx, True)
        e.Graphics.DrawLine(p, e.MarginBounds.Left, y, e.MarginBounds.Right, y)

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

    Private Sub TabControl1_Selected(sender As Object, e As TabControlEventArgs) Handles TabControl1.Selected
        VisualizzaPagina(e.TabPage.Name)
    End Sub

#Region "Pagine"
    Private Sub VisualizzaPagina(Pagina As String)

        Select Case Pagina
            Case "TabRca"
                Rca()
            Case "TabIF"
                IncendioFurto()
            Case "TabArd"
                Ard()
            Case "TabUnibox"
                Unibox()
        End Select
    End Sub

    Private Sub Rca()
        With lvRca
            If .Items.Count > 0 Then Exit Sub

            .View = View.Details
            .Font = New System.Drawing.Font("Tahoma", 10)
            .FullRowSelect = True

            .Columns.Add("desk", "Descrizione", 190).TextAlign = HorizontalAlignment.Left
            .Columns.Add("old", "Precedente", 180).TextAlign = HorizontalAlignment.Right
            .Columns.Add("new", "Attuale", 180).TextAlign = HorizontalAlignment.Right
            .Columns.Add("delta", "Diff.", 70).TextAlign = HorizontalAlignment.Right
            .Columns.Add("sat", "Sat.", 50).TextAlign = HorizontalAlignment.Center

            With .Items.Add("Classe di merito interna")
                .Font = FontBold
                .BackColor = Color.Khaki
                .SubItems.Add(r.Cells("MeritoOld").Value)
                .SubItems.Add(r.Cells("MeritoNew").Value)

                If r.Cells("Effetto").Value < CDate("01/03/2011") Then
                    .SubItems.Add(FormIt(r.Cells("MeritoNew").Value) - r.Cells("MeritoOld").Value)
                Else
                    If r.Cells("InMalus").Value = "S" Then .SubItems.Add("Malus")
                End If
            End With
            With .Items.Add("Classe CU")
                .Font = FontBold
                .BackColor = Color.Khaki
                .SubItems.Add(r.Cells("CuOld").Value)
                .SubItems.Add(r.Cells("CuNew").Value)
                .SubItems.Add(FormIt(r.Cells("CuNew").Value) - r.Cells("CuOld").Value)
            End With
            With .Items.Add("FSP")
                .Font = FontBold
                .BackColor = Color.Khaki
                .SubItems.Add(r.Cells("FspOld").Value)
                .SubItems.Add(r.Cells("FspNew").Value)
            End With
            With .Items.Add("Massimali")
                .UseItemStyleForSubItems = False 'disabilita per colorare le singole celle
                .Font = FontBold
                .BackColor = Color.Khaki
                With .SubItems.Add(r.Cells("MaxOld").Value)
                    .BackColor = Color.Khaki
                    .Font = FontBold
                End With
                With .SubItems.Add(r.Cells("MaxNew").Value)
                    .BackColor = Color.Khaki
                    .Font = FontBold
                End With
                With .SubItems.Add("")
                    .BackColor = Color.Khaki
                    .Font = FontBold
                End With

                If r.Cells("SaturazioneMax").Value = "S" Then
                    .SubItems.Add(siSaturazioneSI)
                Else
                    siSaturazioneNO.BackColor = Color.Khaki
                    .SubItems.Add(siSaturazioneNO)
                End If
            End With
            With .Items.Add("Scivolo")
                .Font = FontBold
                .BackColor = Color.Khaki
                .SubItems.Add("")
                .SubItems.Add(r.Cells("Scivolo").Value)
            End With
            With .Items.Add("Tagliacarta")
                .Font = FontBold
                .BackColor = Color.Khaki
                .SubItems.Add("")
                .SubItems.Add(r.Cells("Tagliacarta").Value)
            End With
            With .Items.Add("Proprietario")
                .Font = FontBold
                .BackColor = Color.Khaki
                .SubItems.Add("")
                .SubItems.Add(r.Cells("Proprietario").Value)
            End With
            With .Items.Add("Forma tariffa")
                .Font = FontBold
                .BackColor = Color.Khaki
                .SubItems.Add(r.Cells("FormaTariffaOld").Value)
                .SubItems.Add(r.Cells("FormaTariffaNew").Value)

                If r.Cells("FormaTariffaOld").Value <> r.Cells("FormaTariffaNew").Value Then
                    .BackColor = Color.LightSalmon
                End If
            End With
            With .Items.Add("Formula tariffa")
                .Font = FontBold
                .BackColor = Color.Khaki
                .SubItems.Add(r.Cells("FormulaTariffaOld").Value)
                .SubItems.Add(r.Cells("FormulaTariffaNew").Value)
            End With
            With .Items.Add("Opzione tariffa")
                .Font = FontBold
                .BackColor = Color.Khaki
                .SubItems.Add(r.Cells("OpzioneTariffaOld").Value)
                .SubItems.Add(r.Cells("OpzioneTariffaNew").Value)
            End With
            With .Items.Add("Percorso")
                .Font = FontBold
                .BackColor = Color.Khaki
                .SubItems.Add(r.Cells("PercorsoOld").Value)

                If r.Cells("PercorsoNew").Value = "G" Then
                    .SubItems.Add("STANDARD")
                Else
                    .SubItems.Add("SPECIAL")
                End If
            End With
            With .Items.Add("Sconto convenzione")
                .Font = FontBold
                .BackColor = Color.Khaki
                .SubItems.Add("")
                .SubItems.Add(r.Cells("PercScontoConvenzione").Value.ToString + "%")
            End With
            With .Items.Add("Sconto plafonamento")
                .Font = FontBold
                .BackColor = Color.Khaki
                .SubItems.Add("")
                .SubItems.Add(r.Cells("PercScontoPlaf").Value.ToString + "%")
            End With
            With .Items.Add("Frazionamento attuale")
                .Font = FontBold
                .BackColor = Color.Khaki
                .SubItems.Add("")
                .SubItems.Add(r.Cells("FrazNew").Value.ToString)
            End With
            With .Items.Add("Aliquota tasse")
                .Font = FontBold
                .BackColor = Color.Khaki
                .SubItems.Add("")
                .SubItems.Add(r.Cells("AliquotaRca").Value.ToString + "%")
            End With
        End With
    End Sub

    Private Sub IncendioFurto()
        With lvIF
            If .Items.Count > 0 Then Exit Sub

            .View = View.Details
            .Font = New System.Drawing.Font("Tahoma", 10)
            .FullRowSelect = True

            .Columns.Add("desk", "Descrizione", 200).TextAlign = HorizontalAlignment.Left
            .Columns.Add("old", "Precedente", 90).TextAlign = HorizontalAlignment.Right
            .Columns.Add("new", "Attuale", 90).TextAlign = HorizontalAlignment.Right
            .Columns.Add("delta", "Differenza", 90).TextAlign = HorizontalAlignment.Right
            .Columns.Add("flex", "Flex%", 70).TextAlign = HorizontalAlignment.Right
            .Columns.Add("sat", "Sat.", 50).TextAlign = HorizontalAlignment.Center
            .Columns.Add("forma", "Forma", 80).TextAlign = HorizontalAlignment.Center

            Dim siFormula As New ListViewItem.ListViewSubItem
            With siFormula
                .Font = FontBold

                If r.Cells("valoreIF").Value > 0 Then
                    Select Case r.Cells("RiparazioneFS").Value
                        Case ""
                            .Text = "-"
                            .BackColor = Color.White
                        Case "N"
                            .Text = "CLASSIC"
                            .BackColor = Color.Gold
                        Case "S"
                            .Text = "CONFORT"
                            .BackColor = Color.Gainsboro
                    End Select
                Else
                    .Text = "-"
                    .BackColor = Color.White
                End If
            End With

            Dim Campi(5, 1) As String
            Campi(0, 0) = "Incendio" : Campi(0, 1) = "INC"
            Campi(1, 0) = "Furto" : Campi(1, 1) = "FUR"
            Campi(2, 0) = "Eventi socio-politici" : Campi(2, 1) = "ESP"
            Campi(3, 0) = "Eventi atmosferici" : Campi(3, 1) = "ATM"
            Campi(4, 0) = "Kasko" : Campi(4, 1) = "KAS"
            Campi(5, 0) = "Collisione" : Campi(5, 1) = "COL"

            Dim TotOld As Double = 0
            Dim TotNew As Double = 0

            For k As Int16 = 0 To 1
                If Campi(k, 0) <> String.Empty Then
                    Dim CampoOld As String = Campi(k, 1) + "NettoOld"
                    Dim CampoNew As String = Campi(k, 1) + "NettoNew"
                    Dim CampoPerc As String = Campi(k, 1) + "PercFlex"
                    Dim CampoSat As String = Campi(k, 1) + "Saturazione"

                    Dim Colore As Color
                    Select Case r.Cells(CampoNew).Value - r.Cells(CampoOld).Value
                        Case 0
                            Colore = Color.White
                        Case Is > 0
                            Colore = Color.LightSalmon
                        Case Is < 0
                            Colore = Color.LightGreen
                    End Select

                    With .Items.Add(Campi(k, 0))
                        .UseItemStyleForSubItems = False 'disabilita per colorare le singole celle
                        .BackColor = Colore 'per colorare la descrizione

                        .SubItems.Add(FormIt(r.Cells(CampoOld).Value)).BackColor = Colore
                        .SubItems.Add(FormIt(r.Cells(CampoNew).Value)).BackColor = Colore
                        .SubItems.Add(FormIt(r.Cells(CampoNew).Value - r.Cells(CampoOld).Value)).BackColor = Colore
                        .SubItems.Add(Coeff2Perc(r.Cells(CampoPerc).Value)).BackColor = Colore

                        Try
                            If r.Cells(CampoSat).Value = "S" Then
                                siSaturazioneSI.Text = r.Cells(CampoSat).Value
                                .SubItems.Add(siSaturazioneSI)
                            Else
                                siSaturazioneNO.BackColor = Colore
                                .SubItems.Add(siSaturazioneNO)
                            End If
                        Catch ex As Exception
                            .SubItems.Add("-").BackColor = Colore
                        End Try

                        .SubItems.Add(siFormula)

                        'calcola totali
                        TotOld = TotOld + CDbl(.SubItems(1).Text)
                        TotNew = TotNew + CDbl(.SubItems(2).Text)
                    End With
                End If
            Next

            'aggiunge riga bianca e totali
            .Items.Add("")
            With .Items.Add("Totali IF")
                .Font = FontBold
                .SubItems.Add(FormIt(TotOld))
                .SubItems.Add(FormIt(TotNew))
                .SubItems.Add(FormIt(TotNew - TotOld))
                .BackColor = IIf(TotNew - TotOld > 0, Color.Coral, Color.GreenYellow)
            End With
            .Items.Add("")

            TotOld = 0
            TotNew = 0

            For k As Int16 = 2 To 5
                If Campi(k, 0) <> String.Empty Then
                    Dim CampoOld As String = Campi(k, 1) + "NettoOld"
                    Dim CampoNew As String = Campi(k, 1) + "NettoNew"
                    Dim CampoPerc As String = Campi(k, 1) + "PercFlex"
                    Dim CampoSat As String = Campi(k, 1) + "Saturazione"

                    Dim Colore As Color
                    Select Case r.Cells(CampoNew).Value - r.Cells(CampoOld).Value
                        Case 0
                            Colore = Color.White
                        Case Is > 0
                            Colore = Color.LightSalmon
                        Case Is < 0
                            Colore = Color.LightGreen
                    End Select

                    With .Items.Add(Campi(k, 0))
                        .UseItemStyleForSubItems = False 'disabilita per colorare le singole celle
                        .BackColor = Colore 'per colorare la descrizione

                        .SubItems.Add(FormIt(r.Cells(CampoOld).Value)).BackColor = Colore
                        .SubItems.Add(FormIt(r.Cells(CampoNew).Value)).BackColor = Colore
                        .SubItems.Add(FormIt(r.Cells(CampoNew).Value - r.Cells(CampoOld).Value)).BackColor = Colore
                        .SubItems.Add(Coeff2Perc(r.Cells(CampoPerc).Value)).BackColor = Colore

                        Try
                            If r.Cells(CampoSat).Value = "S" Then
                                siSaturazioneSI.Text = r.Cells(CampoSat).Value
                                .SubItems.Add(siSaturazioneSI)
                            Else
                                siSaturazioneNO.BackColor = Colore
                                .SubItems.Add(siSaturazioneNO)
                            End If
                        Catch ex As Exception
                            .SubItems.Add("-").BackColor = Colore
                        End Try

                        .SubItems.Add(siFormula)

                        'calcola totali
                        TotOld = TotOld + CDbl(.SubItems(1).Text)
                        TotNew = TotNew + CDbl(.SubItems(2).Text)
                    End With
                End If
            Next

            'aggiunge riga bianca e totali
            .Items.Add("")

            With .Items.Add("Totali ESP/ATM/Kasko")
                .Font = FontBold
                .SubItems.Add(FormIt(TotOld))
                .SubItems.Add(FormIt(TotNew))
                .SubItems.Add(FormIt(TotNew - TotOld))
                .BackColor = IIf(TotNew - TotOld > 0, Color.Coral, Color.GreenYellow)
            End With

            'aggiunge riga bianca
            .Items.Add("")

            'valore IF solo attuale
            With .Items.Add("Valore assicurato IF")
                .Font = FontBold
                .BackColor = Color.Khaki
                .SubItems.Add(FormIt(r.Cells("ValoreIF").Value))
                .SubItems.Add("?")
                '.SubItems.Add("CL 201")
            End With
            'riparazione in forma specifica
            With .Items.Add("Riparazione forma specifica")
                .Font = FontBold
                .BackColor = Color.Khaki
                .SubItems.Add("")
                .SubItems.Add(r.Cells("RiparazioneFS").Value)
            End With
            With .Items.Add("Tariffa ARD")
                .Font = FontBold
                .BackColor = Color.Khaki
                .SubItems.Add("")
                .SubItems.Add(r.Cells("TariffaARD").Value)
            End With
        End With
    End Sub

    Private Sub Ard()
        With lvArd
            If .Items.Count > 0 Then Exit Sub

            .View = View.Details
            .Font = New System.Drawing.Font("Tahoma", 10)
            .FullRowSelect = True

            .Columns.Add("desk", "Descrizione", 200).TextAlign = HorizontalAlignment.Left
            .Columns.Add("old", "Precedente", 90).TextAlign = HorizontalAlignment.Right
            .Columns.Add("new", "Attuale", 90).TextAlign = HorizontalAlignment.Right
            .Columns.Add("delta", "Differenza", 90).TextAlign = HorizontalAlignment.Right
            .Columns.Add("flex", "Flex%", 70).TextAlign = HorizontalAlignment.Right
            .Columns.Add("sat", "Sat.", 50).TextAlign = HorizontalAlignment.Center
            .Columns.Add("forma", "Forma", 80).TextAlign = HorizontalAlignment.Center

            Dim Campi(8, 1) As String
            Campi(0, 0) = "Garanzie accessorie" : Campi(0, 1) = "GA"
            Campi(1, 0) = "Cristalli" : Campi(1, 1) = "CRI"
            Campi(2, 0) = "Rimborso Unibox/Aurobox" : Campi(2, 1) = "RIMBOX"
            Campi(3, 0) = "Tutela legale" : Campi(3, 1) = "TUT"
            Campi(4, 0) = "Assistenza" : Campi(4, 1) = "ASS"
            Campi(5, 0) = "Unisalute" : Campi(5, 1) = "UNISAL"
            Campi(6, 0) = "Ritiro patente" : Campi(6, 1) = "RP"
            Campi(7, 0) = "Infortuni" : Campi(7, 1) = "INF"

            If PcToCompagnia() = 6 Then Campi(8, 0) = "A.D.I. (Aurora)" : Campi(8, 1) = "ADI"

            Dim siOro, siArgento As New ListViewItem.ListViewSubItem
            With siOro
                .Font = FontBold
                .Text = "Oro"
                .BackColor = Color.Gold
            End With
            With siArgento
                .Font = FontBold
                .Text = "Argento"
                .BackColor = Color.Gainsboro
            End With

            Dim TotOld As Double = 0
            Dim TotNew As Double = 0

            For k As Int16 = 0 To 8
                If Campi(k, 0) <> String.Empty Then
                    Dim CampoOld As String = Campi(k, 1) + "NettoOld"
                    Dim CampoNew As String = Campi(k, 1) + "NettoNew"
                    Dim CampoPerc As String = Campi(k, 1) + "PercFlex"
                    Dim CampoSat As String = Campi(k, 1) + "Saturazione"

                    Dim Colore As Color
                    Select Case r.Cells(CampoNew).Value - r.Cells(CampoOld).Value
                        Case 0
                            Colore = Color.White
                        Case Is > 0
                            Colore = Color.LightSalmon
                        Case Is < 0
                            Colore = Color.LightGreen
                    End Select

                    With .Items.Add(Campi(k, 0))
                        .UseItemStyleForSubItems = False 'disabilita per colorare le singole celle

                        .SubItems.Add(FormIt(r.Cells(CampoOld).Value)).BackColor = Colore
                        .SubItems.Add(FormIt(r.Cells(CampoNew).Value)).BackColor = Colore
                        .SubItems.Add(FormIt(r.Cells(CampoNew).Value - r.Cells(CampoOld).Value)).BackColor = Colore

                        Try
                            .SubItems.Add(Coeff2Perc(r.Cells(CampoPerc).Value)).BackColor = Colore
                        Catch ex As Exception
                        End Try

                        Try
                            If r.Cells(CampoSat).Value = "S" Then
                                With .SubItems.Add(r.Cells(CampoSat).Value)
                                    .BackColor = Color.Black
                                    .ForeColor = Color.White
                                    .Font = FontBold
                                End With
                            Else
                                .SubItems.Add(r.Cells(CampoSat).Value).BackColor = Colore
                            End If
                        Catch ex As Exception
                            .SubItems.Add("-").BackColor = Colore
                        End Try

                        If Campi(k, 1).StartsWith("TUT") Then
                            If r.Cells("Effetto").Value >= CDate("01/03/2011") Then
                                Select Case r.Cells(CampoNew).Value
                                    Case 1 To 15
                                        .SubItems.Add(siArgento)
                                    Case Is > 25
                                        .SubItems.Add(siOro)
                                End Select
                            End If
                        End If

                        'colora le righe con differenza positiva o negativa
                        If .SubItems(3).Text > 0 Then .BackColor = Color.LightSalmon
                        If .SubItems(3).Text < 0 Then .BackColor = Color.LightGreen

                        'calcola totali
                        TotOld += CDbl(.SubItems(1).Text)
                        TotNew += CDbl(.SubItems(2).Text)
                    End With
                End If
            Next

            'aggiunge riga bianca e totali
            .Items.Add("")

            With .Items.Add("Totali")
                .Font = FontBold
                .SubItems.Add(FormIt(TotOld))
                .SubItems.Add(FormIt(TotNew))
                .SubItems.Add(FormIt(TotNew - TotOld))
                .BackColor = IIf(TotNew - TotOld > 0, Color.Coral, Color.GreenYellow)
            End With
        End With
    End Sub

    Private Sub Unibox()
        With lvUnibox
            If .Items.Count > 0 Then Exit Sub

            .View = View.Details
            .Font = New System.Drawing.Font("Tahoma", 10)
            .FullRowSelect = True

            .Columns.Add("desk", "Descrizione", 200)
            .Columns.Add("old", "Precedente", 100)
            .Columns.Add("new", "Attuale", 100)
            .Columns.Add("delta", "Differenza", 100)
            .Columns.Add("flex", "Flex%", 70)

            .Columns("old").TextAlign = HorizontalAlignment.Right
            .Columns("new").TextAlign = HorizontalAlignment.Right
            .Columns("delta").TextAlign = HorizontalAlignment.Right
            .Columns("flex").TextAlign = HorizontalAlignment.Right

            With .Items.Add("Canone")
                .SubItems.Add(FormIt(r.Cells("UniboxOld").Value))
                .SubItems.Add(FormIt(r.Cells("UniboxNew").Value))
                .SubItems.Add(FormIt(r.Cells("UniboxNew").Value - r.Cells("UniboxOld").Value))

                'colora le righe con differenza positiva o negativa
                If .SubItems(3).Text > 0 Then .BackColor = Color.LightSalmon
                If .SubItems(3).Text < 0 Then .BackColor = Color.LightGreen
            End With

            .Items.Add("")
            With .Items.Add("Tipo dispositivo OCTO")
                .Font = FontBold
                .BackColor = Color.Khaki
                .SubItems.Add("")
                .SubItems.Add(r.Cells("TipoOcto").Value)
            End With
            With .Items.Add("Tariffa a Kilometro")
                .Font = FontBold
                .BackColor = Color.Khaki
                .SubItems.Add("")
                .SubItems.Add(r.Cells("TariffaKm").Value)
            End With
            With .Items.Add("Km percorsi")
                .Font = FontBold
                .BackColor = Color.Khaki
                .SubItems.Add("")
                .SubItems.Add(r.Cells("KmPercorsi").Value)
            End With
            With .Items.Add("Sconto OCTO RC")
                .Font = FontBold
                .BackColor = Color.Khaki
                .SubItems.Add(Coeff2Perc(r.Cells("ScontoOctoRcOld").Value))
                .SubItems.Add(Coeff2Perc(r.Cells("ScontoOctoRcNew").Value))
            End With
        End With
    End Sub
#End Region

End Class