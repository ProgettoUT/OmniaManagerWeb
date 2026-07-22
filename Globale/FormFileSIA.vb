Imports System.Drawing
Imports System.Windows.Forms

Public Class FormFileSIA

    Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "File disponibili in contabilità (ultimi due mesi)"
        Me.Font = Utx.AppFont.Normal
        Me.FormBorderStyle = FormBorderStyle.FixedToolWindow
        Me.Size = New Size(600, 700)

        With dgvElencoFile
            .AllowUserToAddRows = False
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End With
        Utx.NetFunc.DoppioBuffer(dgvElencoFile)
    End Sub

    Private Sub FormFileSIA_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            dgvElencoFile.Refresh()

            Cursor.Current = Cursors.WaitCursor

            Dim dt As New System.Data.DataTable
            dt.Columns.Add("File", System.Type.GetType("System.String"))
            dt.Columns.Add("Data", System.Type.GetType("System.DateTime"))
            dt.Columns.Add("Unisalute", System.Type.GetType("System.String"))

            Dim Lista(), ER() As String
            For Each row As DataRow In Utx.Globale.ProfiloEnteGestore.ConfigurazioneServer.Rows
                If row("DataFine") >= Today Then
                    'questo controllo è necessario altrimenti i codici unisalute uguali a quelli unipol darebbero righe doppie
                    If row("Unisalute") = "N" OrElse (row("Unisalute") = "S" AndAlso row("Agenzia") <> row("Collegata")) Then
                        'scarico le liste da MA e Rete da SIA
                        Lista = Utx.SIA.ListaFileInviati(row("Collegata"), Today.AddMonths(-2), Today, Utx.SIA.TipoFiltro.INIZIA, "MA")
                        ER = Utx.SIA.ListaFileInviati(row("Collegata"), Today.AddMonths(-2), Today, Utx.SIA.TipoFiltro.CONTIENE, "Essig_Reti")

                        For Each s As String In Lista
                            dt.Rows.Add({s, New DateTime(s.Substring(8, 2) + 2000, s.Substring(10, 2), s.Substring(12, 2)), IIf(s.StartsWith("MA4"), "S", "N")})
                        Next
                        For Each s As String In ER
                            dt.Rows.Add({s, New DateTime(s.Substring(17, 2) + 2000, s.Substring(19, 2), s.Substring(21, 2))})
                        Next
                    End If
                End If
            Next

            dgvElencoFile.DataSource = dt

            For Each row As DataGridViewRow In dgvElencoFile.Rows
                If row.Cells(0).Value.ToString.Contains("Essig_Reti") Then

                    row.DefaultCellStyle.BackColor = Color.Moccasin

                ElseIf row.Cells(0).Value.ToString.Contains("UAP") OrElse
                    row.Cells(0).Value.ToString.Contains("UB") OrElse
                    row.Cells(0).Value.ToString.Contains("UT") Then

                    row.DefaultCellStyle.BackColor = Color.PaleGreen
                End If
            Next

            dgvElencoFile.Columns("Unisalute").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvElencoFile.AutoResizeColumns()

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        Me.Close()
    End Sub
End Class