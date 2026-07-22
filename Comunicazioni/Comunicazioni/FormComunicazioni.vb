Imports System.IO
Imports System.Data.OleDb

Public Class FormComunicazioni

    'generale
    Friend WithEvents btnIndice As New Button
    Friend WithEvents dtpInizioPeriodo As New DateTimePicker
    Friend WithEvents dtpFinePeriodo As New DateTimePicker
    Friend WithEvents btnDocAttivi As New Button
    Friend WithEvents btnLeggiArchivio As New Button
    Friend WithEvents btnEsci As New Button

    Friend cn As OleDbConnection
    Friend TabellaDoc As String

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        With lbDataDoc
            .BorderStyle = BorderStyle.FixedSingle
            .FlatStyle = FlatStyle.Flat
            .BackColor = Color.Moccasin
            .Text = ""
        End With

        wbDoc.ScriptErrorsSuppressed = True

        SplitContainer1.SplitterDistance = 0
        SplitContainer1.SplitterWidth = 5

        ImpostaTsMenu()
        ImpostaGrid(dgvIndice)
    End Sub

    Private mComunicazioni As ComunicazioniUt
    Public Property Comunicazioni() As ComunicazioniUt
        Get
            Return mComunicazioni
        End Get
        Set(value As ComunicazioniUt)
            mComunicazioni = value
        End Set
    End Property

    Private Sub Form1_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

        Me.Text = String.Format("Unitools - Comunicazioni ({0})", TabellaDoc)
        Me.Refresh()

        LeggiIndice(Today)

        ResizeIndice()

        AddHandler Me.Resize, AddressOf Form1_Resize
        AddHandler SplitContainer1.SplitterMoved, AddressOf SplitContainer1_SplitterMoved

        Me.ResumeLayout()
    End Sub

    Private Sub ImpostaTsMenu()

        tsMenu.SuspendLayout()
        tsMenu.BringToFront()

        With tsMenu
            .AutoSize = True
            .Font = New Font("Tahoma", 9)
            .Visible = False
            .GripStyle = ToolStripGripStyle.Hidden
            .RenderMode = ToolStripRenderMode.ManagerRenderMode
            .Dock = DockStyle.Bottom
            .Items.Clear()
        End With

        Dim BtnHeight As Integer = 30
        Dim ttch As ToolStripControlHost

        With btnIndice
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
            .BackColor = Color.Gainsboro
            .Width = 130
            .Height = BtnHeight
            .Text = "Nascondi indice"
        End With
        ttch = New ToolStripControlHost(btnIndice)
        ttch.AutoSize = False
        tsMenu.Items.Add(ttch)

        tsMenu.Items.Add(New ToolStripSeparator)
        With btnDocAttivi
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
            .BackColor = Color.Gainsboro
            .Width = 130
            .Height = BtnHeight
            .Text = "Documenti correnti"
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        ttch = New ToolStripControlHost(btnDocAttivi)
        ttch.AutoSize = False
        tsMenu.Items.Add(ttch)

        tsMenu.Items.Add(New ToolStripSeparator)
        tsMenu.Items.Add(New ToolStripLabel("Archivio comunicazioni dal "))
        With dtpInizioPeriodo
            .Width = 100
            .Format = DateTimePickerFormat.Short
            .Value = New DateTime(Now.Year, 1, 1)
        End With
        ttch = New ToolStripControlHost(dtpInizioPeriodo)
        ttch.AutoSize = False
        tsMenu.Items.Add(ttch)

        tsMenu.Items.Add(New ToolStripLabel(" al "))
        With dtpFinePeriodo
            .Width = 100
            .Format = DateTimePickerFormat.Short
            .Value = Now
        End With
        ttch = New ToolStripControlHost(dtpFinePeriodo)
        ttch.AutoSize = False
        tsMenu.Items.Add(ttch)

        tsMenu.Items.Add(New ToolStripLabel(""))
        With btnLeggiArchivio
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
            .BackColor = Color.Gainsboro
            .Width = 130
            .Height = BtnHeight
            .Text = "Leggi archivio"
        End With
        ttch = New ToolStripControlHost(btnLeggiArchivio)
        ttch.AutoSize = False
        tsMenu.Items.Add(ttch)

        With btnEsci
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
            .BackColor = Color.Gold
            .Width = 130
            .Height = BtnHeight
            .Text = "Esci"
        End With
        ttch = New ToolStripControlHost(btnEsci)
        ttch.AutoSize = False
        ttch.Alignment = ToolStripItemAlignment.Right
        tsMenu.Items.Add(ttch)

        tsMenu.Visible = True
        tsMenu.ResumeLayout()
    End Sub

    Private Sub ImpostaGrid(ByRef dgv As DataGridView)
        Try
            With dgv
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .MultiSelect = False
                .Font = New System.Drawing.Font("Tahoma", 9)
                .RowHeadersDefaultCellStyle.SelectionBackColor = Color.Red
                .AllowUserToAddRows = False
                .BackgroundColor = Color.White
            End With

            'prendo per l'indice un quarto della larghezza della finestra
            SplitContainer1.SplitterDistance = SplitContainer1.Width * 0.25

        Catch ex As Exception
            ComunicazioniUt.Log.Errore(ex)
        End Try
    End Sub

    Private Sub LeggiIndice(Optional Scadenza As Date = #1/1/1900#)

        Cursor.Current = Cursors.WaitCursor

        Try
            lbDataDoc.Text = "Lettura indice in corso..."

            Using cmd As New OleDbCommand
                cmd.Connection = cn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = String.Format("SELECT Count(*) FROM {0}", TabellaDoc)

                'controllo esistenza tabella dell'utente
                Try
                    cmd.ExecuteScalar()
                Catch ex As Exception
                    'la tabella non esiste: la creo
                    cmd.CommandText = String.Format("SELECT * INTO {0} FROM Documenti WHERE False", TabellaDoc)
                    cmd.ExecuteNonQuery()
                End Try

                cmd.CommandText = String.Format("SELECT * FROM {0} WHERE Scadenza > ? ORDER BY Data DESC", TabellaDoc)

                cmd.Parameters.AddWithValue("Scadenza", Scadenza.ToShortDateString)

                Dim dt As New DataTable
                Dim da = New OleDbDataAdapter
                da.SelectCommand = cmd
                da.Fill(dt)

                With dgvIndice
                    .DataSource = dt

                    Select Case dt.Rows.Count
                        Case 0
                            .Columns("Titolo").HeaderText = "Documenti"
                            lbDataDoc.Text = "Nessun documento"
                        Case Else
                            .Columns("Titolo").HeaderText = String.Format("Documenti trovati {0}", dt.Rows.Count.ToString)
                    End Select

                    .Columns("Codice").Visible = False
                    .Columns("Link").Visible = False
                    .Columns("Data").Visible = False
                    .Columns("Scadenza").Visible = False
                End With

                With dgvIndice
                    .AutoResizeColumn(5)
                    .Columns(1).Width = SplitContainer1.SplitterDistance -
                                        .Columns(5).Width -
                                        dgvIndice.RowHeadersWidth - 2
                    .Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                End With
            End Using

        Catch ex As Exception
            ComunicazioniUt.Log.Errore(ex)
        End Try

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub dgvIndice_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvIndice.SelectionChanged
        Try
            Cursor.Current = Cursors.WaitCursor

            If dgvIndice.CurrentRow IsNot Nothing Then
                wbDoc.Navigate(dgvIndice.CurrentRow.Cells("Link").Value)
                lbDataDoc.Text = String.Format("Documento del {0:d}", dgvIndice.CurrentRow.Cells("Data").Value)
            End If

        Catch ex As Exception
            ComunicazioniUt.Log.Errore(ex)
            lbDataDoc.Text = ""
        End Try
    End Sub

    Private Sub btnEsci_Click(sender As System.Object, e As System.EventArgs) Handles btnEsci.Click
        dgvIndice.DataSource = Nothing
        wbDoc.Stop()
        Me.Close()
    End Sub

    Private Sub dgvIndice_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvIndice.CellContentClick

        If e.ColumnIndex <> 5 Then
            Exit Sub
        End If

        Try
            dgvIndice.CurrentCell.Value = Not dgvIndice.CurrentCell.Value

            Using cmd As New OleDb.OleDbCommand
                cmd.Connection = cn
                cmd.CommandType = CommandType.Text
                cmd.CommandText = String.Format("UPDATE {0} SET Letto = ? WHERE Codice = ?", TabellaDoc)

                cmd.Parameters.AddWithValue("Letto", dgvIndice.CurrentCell.Value)
                cmd.Parameters.AddWithValue("Codice", dgvIndice.CurrentRow.Cells("Codice").Value)

                cmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            ComunicazioniUt.Log.Errore(ex)
        End Try
    End Sub

    Private Sub Form1_Resize(sender As Object, e As System.EventArgs)
        ResizeIndice()
    End Sub

    Private Sub SplitContainer1_SplitterMoved(sender As Object, e As System.Windows.Forms.SplitterEventArgs)
        'larghezza minima indice 1/5 della larghezza totale
        SplitContainer1.SplitterDistance = Math.Max(SplitContainer1.SplitterDistance, SplitContainer1.Width / 5)
        ResizeIndice()
    End Sub

    Private Sub ResizeIndice()
        On Error Resume Next
        dgvIndice.Columns(1).Width = dgvIndice.Width - _
                                     dgvIndice.RowHeadersWidth - _
                                     dgvIndice.Columns(5).Width - 2
        dgvIndice.AutoResizeRows()
    End Sub

    Private Sub btnIndice_Click(sender As System.Object, e As System.EventArgs) Handles btnIndice.Click
        IndiceOnOff()
    End Sub

    Private Sub IndiceOnOff()
        If SplitContainer1.Panel1Collapsed = True Then
            IndiceOn()
        Else
            IndiceOff()
        End If
    End Sub

    Private Sub IndiceOn()
        SplitContainer1.Panel1Collapsed = False
        btnIndice.Text = "Nascondi indice"
    End Sub

    Private Sub IndiceOff()
        SplitContainer1.Panel1Collapsed = True
        btnIndice.Text = "Visualizza indice"
    End Sub

    Private Sub btnLeggiArchivio_Click(sender As Object, e As System.EventArgs) Handles btnLeggiArchivio.Click

        IndiceOn()

        dgvIndice.DataSource = Nothing
        dgvIndice.Refresh()

        lbDataDoc.Text = "Lettura archivio in corso..."
        lbDataDoc.Refresh()

        dgvIndice.DefaultCellStyle.BackColor = Color.Beige

        mComunicazioni.ScaricaDocArchivio(dtpInizioPeriodo.Value, dtpFinePeriodo.Value, cn, TabellaDoc)
        LeggiIndice()
    End Sub

    Private Sub btnDocAttivi_Click(sender As Object, e As System.EventArgs) Handles btnDocAttivi.Click

        IndiceOn()

        dgvIndice.DataSource = Nothing
        dgvIndice.Refresh()

        lbDataDoc.Text = "Lettura indice in corso..."
        lbDataDoc.Refresh()

        dgvIndice.DefaultCellStyle.BackColor = Color.White

        mComunicazioni.ScaricaIndiceDoc(cn, TabellaDoc)
        LeggiIndice()
    End Sub

    Private Sub dtpInizioPeriodo_ValueChanged(sender As Object, e As System.EventArgs) Handles dtpInizioPeriodo.ValueChanged
        If dtpInizioPeriodo.Value > dtpFinePeriodo.Value Then dtpFinePeriodo.Value = dtpInizioPeriodo.Value
    End Sub

    Private Sub dtpFinePeriodo_ValueChanged(sender As Object, e As System.EventArgs) Handles dtpFinePeriodo.ValueChanged
        If dtpFinePeriodo.Value < dtpInizioPeriodo.Value Then dtpInizioPeriodo.Value = dtpFinePeriodo.Value
    End Sub

    Private Sub lbDataDoc_TextChanged(sender As Object, e As EventArgs) Handles lbDataDoc.TextChanged
        lbDataDoc.Refresh()
    End Sub
End Class
