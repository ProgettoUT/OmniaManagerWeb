Public Class FormRecuperoIncasso

    Public Incasso As DataGridViewRow

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width * 0.7, Screen.PrimaryScreen.WorkingArea.Height / 2)
        Me.Font = Globale.MainFont
        Me.Text = "Importa incasso"
        Me.AcceptButton = ButtonCerca

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()

        With tlpMain
            'sistemo le righe del tlp elenco
            .RowStyles.Item(0) = New RowStyle(SizeType.Absolute, 28)
            .RowStyles.Item(2) = New RowStyle(SizeType.Absolute, 50)
            'colonne
            .ColumnStyles.Item(0) = New ColumnStyle(SizeType.Percent, 100)
            .ColumnStyles.Item(1) = New ColumnStyle(SizeType.Absolute, 50)
            .ColumnStyles.Item(2) = New ColumnStyle(SizeType.Absolute, 150)
            .ColumnStyles.Item(3) = New ColumnStyle(SizeType.Absolute, 150)
        End With

        With ButtonCerca
            .Margin = New Padding(2)
            .AutoSize = True
            .Dock = DockStyle.Fill
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Text = "Cerca"
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        With ButtonRecupera
            .AutoSize = True
            .Dock = DockStyle.Fill
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Image = My.Resources.ok32.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Importa incasso"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With ButtonEsci
            .AutoSize = True
            .Dock = DockStyle.Fill
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Image = My.Resources.Elimina.ToBitmap
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Annulla"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With TextBoxRamo
            .BorderStyle = BorderStyle.FixedSingle
            .Dock = DockStyle.Fill
            .BackColor = Color.LightYellow
            .TextAlign = HorizontalAlignment.Center
        End With
        With TextBoxPolizza
            .BorderStyle = BorderStyle.FixedSingle
            .Dock = DockStyle.Fill
            .BackColor = Color.LightYellow
            .TextAlign = HorizontalAlignment.Center
        End With
        With LabelPolizza
            .Margin = New Padding(0, 3, 0, 3)
            .AutoSize = True
            .Dock = DockStyle.Fill
            .FlatStyle = FlatStyle.Flat
            .BorderStyle = BorderStyle.None
            .Text = "Ramo/Polizza"
            .TextAlign = ContentAlignment.MiddleRight
        End With

        With dgvIncassi
            .Dock = DockStyle.Fill
            .Font = Globale.MainFont
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .EditMode = DataGridViewEditMode.EditProgrammatically
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .CellBorderStyle = DataGridViewCellBorderStyle.Raised
            .RowHeadersDefaultCellStyle.SelectionBackColor = Color.Red
        End With
        Utx.NetFunc.DoppioBuffer(dgvIncassi)
    End Sub

    Private Sub FormRecuperoIncasso_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        TextBoxRamo.Focus()
    End Sub

    Private Sub ButtonCerca_Click(sender As Object, e As EventArgs) Handles ButtonCerca.Click
        Try
            If IsNumeric(TextBoxRamo.Text) AndAlso IsNumeric(TextBoxPolizza.Text) Then
                Dim Query As String = String.Format("SELECT I.Agenzia,I.Ramo,I.Polizza,I.Contraente,I.CodiceSubAgente AS SubAgenzia,I.TipoCarico,
                    I.NumeroAppendice AS Appendice,I.DataEffettoAppendice AS EffettoAppendice,I.DataEffettoTitolo AS EffettoTitolo,
                    I.Esito,I.DataFoglioCassa,I.TotaleTitolo,I.Targa,I.CodiceProdotto AS Prodotto,I.RamoGestione,
                    CASE
                    WHEN B.Ramo IS NULL THEN ''
                    ELSE 'già in elenco'
                    END
                    AS Stato
                    FROM Incassi AS I
                    LEFT JOIN Buste AS B ON I.Agenzia = B.Agenzia AND I.Ramo = B.Ramo AND I.Polizza = B.Polizza AND I.NumeroAppendice = B.Appendice AND 
                        I.DataEffettoAppendice = B.EffettoAppendice AND I.DataEffettoTitolo = B.EffettoTitolo 
                        AND I.DataFoglioCassa = B.DataFoglioCassa AND I.TipoCarico = B.TipoCarico
                    WHERE I.Ramo = {0} AND I.Polizza = {1} 
                    ORDER BY I.DataFoglioCassa DESC", TextBoxRamo.Text, TextBoxPolizza.Text)
                dgvIncassi.DataSource = Utx.WsCommand.ExecuteNonQuery(Query).DataTable
                FormattaColonne()
            Else
                MsgBox("Inserire un ramo/polizza valido", MsgBoxStyle.Exclamation)
                TextBoxRamo.Focus()
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub FormattaColonne()
        On Error Resume Next

        With dgvIncassi
            .SuspendLayout()

            'intestazioni delle colonne
            With .Columns("SubAgenzia")
                .HeaderText = "Sub"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("TipoCarico")
                .HeaderText = String.Format("Tipo{0}carico", Environment.NewLine)
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = Color.PaleGreen
            End With
            With .Columns("EffettoTitolo")
                .HeaderText = "Effetto"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("DataFoglioCassa")
                .HeaderText = "Foglio cassa"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .DefaultCellStyle.BackColor = Color.Khaki
            End With
            With .Columns("TotaleTitolo")
                .HeaderText = "Tot.titolo"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .DefaultCellStyle.Format = "###,##0.00"
            End With
            With .Columns("NumeroAppendice")
                .HeaderText = "App."
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("EffettoAppendice")
                .HeaderText = "Effetto app."
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            With .Columns("RamoGestione")
                .HeaderText = String.Format("Ramo{0}gestione", Environment.NewLine)
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            .Columns("Agenzia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Ramo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Esito").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Prodotto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Targa").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

            .ResumeLayout()
        End With
    End Sub

    Private Sub ButtonRecupera_Click(sender As Object, e As EventArgs) Handles ButtonRecupera.Click
        If dgvIncassi.CurrentRow IsNot Nothing Then
            Incasso = dgvIncassi.CurrentRow
        End If
        Me.Close()
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        Me.Close()
    End Sub
End Class