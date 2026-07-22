<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucStatistiche
    Inherits System.Windows.Forms.UserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgvStatistiche = New System.Windows.Forms.DataGridView()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpMenu = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonMixCP = New System.Windows.Forms.Button()
        Me.ButtonFrequenzaCip = New System.Windows.Forms.Button()
        Me.ButtonFrequenzaRamoProdotto = New System.Windows.Forms.Button()
        Me.ButtonFrequenzaConvenzioni = New System.Windows.Forms.Button()
        Me.ButtonStatisticheLiquidato = New System.Windows.Forms.Button()
        Me.ButtonEsci = New System.Windows.Forms.Button()
        Me.ButtonEsporta = New System.Windows.Forms.Button()
        Me.LabelDesk = New System.Windows.Forms.Label()
        Me.LabelMenu = New System.Windows.Forms.Label()
        Me.ButtonStatisticheComparto = New System.Windows.Forms.Button()
        CType(Me.dgvStatistiche, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpMain.SuspendLayout()
        Me.tlpMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvStatistiche
        '
        Me.dgvStatistiche.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStatistiche.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvStatistiche.Location = New System.Drawing.Point(3, 28)
        Me.dgvStatistiche.Name = "dgvStatistiche"
        Me.dgvStatistiche.Size = New System.Drawing.Size(557, 394)
        Me.dgvStatistiche.TabIndex = 0
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 2
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.tlpMain.Controls.Add(Me.dgvStatistiche, 0, 1)
        Me.tlpMain.Controls.Add(Me.tlpMenu, 1, 1)
        Me.tlpMain.Controls.Add(Me.LabelDesk, 0, 0)
        Me.tlpMain.Controls.Add(Me.LabelMenu, 1, 0)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 1
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMain.Size = New System.Drawing.Size(713, 425)
        Me.tlpMain.TabIndex = 1
        '
        'tlpMenu
        '
        Me.tlpMenu.ColumnCount = 1
        Me.tlpMenu.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMenu.Controls.Add(Me.ButtonStatisticheComparto, 0, 5)
        Me.tlpMenu.Controls.Add(Me.ButtonMixCP, 0, 0)
        Me.tlpMenu.Controls.Add(Me.ButtonFrequenzaCip, 0, 1)
        Me.tlpMenu.Controls.Add(Me.ButtonFrequenzaRamoProdotto, 0, 2)
        Me.tlpMenu.Controls.Add(Me.ButtonFrequenzaConvenzioni, 0, 3)
        Me.tlpMenu.Controls.Add(Me.ButtonStatisticheLiquidato, 0, 4)
        Me.tlpMenu.Controls.Add(Me.ButtonEsci, 0, 8)
        Me.tlpMenu.Controls.Add(Me.ButtonEsporta, 0, 6)
        Me.tlpMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMenu.Location = New System.Drawing.Point(563, 25)
        Me.tlpMenu.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpMenu.Name = "tlpMenu"
        Me.tlpMenu.RowCount = 9
        Me.tlpMenu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlpMenu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlpMenu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlpMenu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlpMenu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlpMenu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlpMenu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlpMenu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMenu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlpMenu.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMenu.Size = New System.Drawing.Size(150, 400)
        Me.tlpMenu.TabIndex = 1
        '
        'ButtonMixCP
        '
        Me.ButtonMixCP.Location = New System.Drawing.Point(3, 3)
        Me.ButtonMixCP.Name = "ButtonMixCP"
        Me.ButtonMixCP.Size = New System.Drawing.Size(75, 23)
        Me.ButtonMixCP.TabIndex = 0
        Me.ButtonMixCP.Text = "Button1"
        Me.ButtonMixCP.UseVisualStyleBackColor = True
        '
        'ButtonFrequenzaCip
        '
        Me.ButtonFrequenzaCip.Location = New System.Drawing.Point(3, 43)
        Me.ButtonFrequenzaCip.Name = "ButtonFrequenzaCip"
        Me.ButtonFrequenzaCip.Size = New System.Drawing.Size(75, 23)
        Me.ButtonFrequenzaCip.TabIndex = 2
        Me.ButtonFrequenzaCip.Text = "Button1"
        Me.ButtonFrequenzaCip.UseVisualStyleBackColor = True
        '
        'ButtonFrequenzaRamoProdotto
        '
        Me.ButtonFrequenzaRamoProdotto.Location = New System.Drawing.Point(3, 83)
        Me.ButtonFrequenzaRamoProdotto.Name = "ButtonFrequenzaRamoProdotto"
        Me.ButtonFrequenzaRamoProdotto.Size = New System.Drawing.Size(75, 23)
        Me.ButtonFrequenzaRamoProdotto.TabIndex = 3
        Me.ButtonFrequenzaRamoProdotto.Text = "Button1"
        Me.ButtonFrequenzaRamoProdotto.UseVisualStyleBackColor = True
        '
        'ButtonFrequenzaConvenzioni
        '
        Me.ButtonFrequenzaConvenzioni.Location = New System.Drawing.Point(3, 123)
        Me.ButtonFrequenzaConvenzioni.Name = "ButtonFrequenzaConvenzioni"
        Me.ButtonFrequenzaConvenzioni.Size = New System.Drawing.Size(75, 23)
        Me.ButtonFrequenzaConvenzioni.TabIndex = 4
        Me.ButtonFrequenzaConvenzioni.Text = "Button1"
        Me.ButtonFrequenzaConvenzioni.UseVisualStyleBackColor = True
        '
        'ButtonStatisticheLiquidato
        '
        Me.ButtonStatisticheLiquidato.Location = New System.Drawing.Point(3, 163)
        Me.ButtonStatisticheLiquidato.Name = "ButtonStatisticheLiquidato"
        Me.ButtonStatisticheLiquidato.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStatisticheLiquidato.TabIndex = 5
        Me.ButtonStatisticheLiquidato.Text = "Button1"
        Me.ButtonStatisticheLiquidato.UseVisualStyleBackColor = True
        '
        'ButtonEsci
        '
        Me.ButtonEsci.Location = New System.Drawing.Point(3, 363)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.ButtonEsci.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEsci.TabIndex = 6
        Me.ButtonEsci.Text = "Button1"
        Me.ButtonEsci.UseVisualStyleBackColor = True
        '
        'ButtonEsporta
        '
        Me.ButtonEsporta.Location = New System.Drawing.Point(3, 243)
        Me.ButtonEsporta.Name = "ButtonEsporta"
        Me.ButtonEsporta.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEsporta.TabIndex = 1
        Me.ButtonEsporta.Text = "Button1"
        Me.ButtonEsporta.UseVisualStyleBackColor = True
        '
        'LabelDesk
        '
        Me.LabelDesk.AutoSize = True
        Me.LabelDesk.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LabelDesk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelDesk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelDesk.Location = New System.Drawing.Point(3, 0)
        Me.LabelDesk.Name = "LabelDesk"
        Me.LabelDesk.Size = New System.Drawing.Size(557, 25)
        Me.LabelDesk.TabIndex = 2
        Me.LabelDesk.Text = "descrizione"
        Me.LabelDesk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelMenu
        '
        Me.LabelMenu.AutoSize = True
        Me.LabelMenu.Location = New System.Drawing.Point(566, 0)
        Me.LabelMenu.Name = "LabelMenu"
        Me.LabelMenu.Size = New System.Drawing.Size(39, 13)
        Me.LabelMenu.TabIndex = 3
        Me.LabelMenu.Text = "Label1"
        '
        'ButtonStatisticheComparto
        '
        Me.ButtonStatisticheComparto.Location = New System.Drawing.Point(3, 203)
        Me.ButtonStatisticheComparto.Name = "ButtonStatisticheComparto"
        Me.ButtonStatisticheComparto.Size = New System.Drawing.Size(75, 23)
        Me.ButtonStatisticheComparto.TabIndex = 7
        Me.ButtonStatisticheComparto.Text = "Button1"
        Me.ButtonStatisticheComparto.UseVisualStyleBackColor = True
        '
        'ucStatistiche
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "ucStatistiche"
        Me.Size = New System.Drawing.Size(713, 425)
        CType(Me.dgvStatistiche, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.tlpMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvStatistiche As System.Windows.Forms.DataGridView
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpMenu As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelDesk As System.Windows.Forms.Label
    Friend WithEvents ButtonMixCP As System.Windows.Forms.Button
    Friend WithEvents LabelMenu As System.Windows.Forms.Label
    Friend WithEvents ButtonEsporta As System.Windows.Forms.Button
    Friend WithEvents ButtonFrequenzaCip As System.Windows.Forms.Button
    Friend WithEvents ButtonFrequenzaRamoProdotto As System.Windows.Forms.Button
    Friend WithEvents ButtonFrequenzaConvenzioni As System.Windows.Forms.Button
    Friend WithEvents ButtonStatisticheLiquidato As System.Windows.Forms.Button
    Friend WithEvents ButtonEsci As System.Windows.Forms.Button
    Friend WithEvents ButtonStatisticheComparto As Windows.Forms.Button
End Class
