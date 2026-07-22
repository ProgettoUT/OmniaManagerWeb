<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDettaglioRg
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Me.dgvDettaglio = New System.Windows.Forms.DataGridView()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonEsporta = New System.Windows.Forms.Button()
        Me.ButtonEsci = New System.Windows.Forms.Button()
        Me.LabelTotaleTassabile = New System.Windows.Forms.Label()
        Me.LabelTotaleLordo = New System.Windows.Forms.Label()
        Me.LabelRecord = New System.Windows.Forms.Label()
        Me.LabelPeriodo = New System.Windows.Forms.Label()
        Me.LabelMedia = New System.Windows.Forms.Label()
        CType(Me.dgvDettaglio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvDettaglio
        '
        Me.dgvDettaglio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpMain.SetColumnSpan(Me.dgvDettaglio, 7)
        Me.dgvDettaglio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDettaglio.Location = New System.Drawing.Point(3, 3)
        Me.dgvDettaglio.Name = "dgvDettaglio"
        Me.dgvDettaglio.Size = New System.Drawing.Size(576, 325)
        Me.dgvDettaglio.TabIndex = 0
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 7
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.tlpMain.Controls.Add(Me.dgvDettaglio, 0, 0)
        Me.tlpMain.Controls.Add(Me.ButtonEsporta, 0, 1)
        Me.tlpMain.Controls.Add(Me.ButtonEsci, 6, 1)
        Me.tlpMain.Controls.Add(Me.LabelTotaleTassabile, 3, 1)
        Me.tlpMain.Controls.Add(Me.LabelTotaleLordo, 4, 1)
        Me.tlpMain.Controls.Add(Me.LabelRecord, 1, 1)
        Me.tlpMain.Controls.Add(Me.LabelPeriodo, 2, 1)
        Me.tlpMain.Controls.Add(Me.LabelMedia, 5, 1)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 2
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tlpMain.Size = New System.Drawing.Size(582, 361)
        Me.tlpMain.TabIndex = 1
        '
        'ButtonEsporta
        '
        Me.ButtonEsporta.Location = New System.Drawing.Point(3, 334)
        Me.ButtonEsporta.Name = "ButtonEsporta"
        Me.ButtonEsporta.Size = New System.Drawing.Size(75, 23)
        Me.ButtonEsporta.TabIndex = 2
        Me.ButtonEsporta.Text = "Button1"
        Me.ButtonEsporta.UseVisualStyleBackColor = True
        '
        'ButtonEsci
        '
        Me.ButtonEsci.Location = New System.Drawing.Point(526, 334)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.ButtonEsci.Size = New System.Drawing.Size(53, 23)
        Me.ButtonEsci.TabIndex = 7
        Me.ButtonEsci.Text = "Button1"
        Me.ButtonEsci.UseVisualStyleBackColor = True
        '
        'LabelTotaleTassabile
        '
        Me.LabelTotaleTassabile.AutoSize = True
        Me.LabelTotaleTassabile.Location = New System.Drawing.Point(247, 331)
        Me.LabelTotaleTassabile.Name = "LabelTotaleTassabile"
        Me.LabelTotaleTassabile.Size = New System.Drawing.Size(42, 14)
        Me.LabelTotaleTassabile.TabIndex = 8
        Me.LabelTotaleTassabile.Text = "Label1"
        '
        'LabelTotaleLordo
        '
        Me.LabelTotaleLordo.AutoSize = True
        Me.LabelTotaleLordo.Location = New System.Drawing.Point(340, 331)
        Me.LabelTotaleLordo.Name = "LabelTotaleLordo"
        Me.LabelTotaleLordo.Size = New System.Drawing.Size(42, 14)
        Me.LabelTotaleLordo.TabIndex = 9
        Me.LabelTotaleLordo.Text = "Label2"
        '
        'LabelRecord
        '
        Me.LabelRecord.AutoSize = True
        Me.LabelRecord.Location = New System.Drawing.Point(96, 331)
        Me.LabelRecord.Name = "LabelRecord"
        Me.LabelRecord.Size = New System.Drawing.Size(42, 14)
        Me.LabelRecord.TabIndex = 10
        Me.LabelRecord.Text = "Label1"
        '
        'LabelPeriodo
        '
        Me.LabelPeriodo.AutoSize = True
        Me.LabelPeriodo.Location = New System.Drawing.Point(154, 331)
        Me.LabelPeriodo.Name = "LabelPeriodo"
        Me.LabelPeriodo.Size = New System.Drawing.Size(42, 14)
        Me.LabelPeriodo.TabIndex = 11
        Me.LabelPeriodo.Text = "Label2"
        '
        'LabelMedia
        '
        Me.LabelMedia.AutoSize = True
        Me.LabelMedia.Location = New System.Drawing.Point(433, 331)
        Me.LabelMedia.Name = "LabelMedia"
        Me.LabelMedia.Size = New System.Drawing.Size(42, 14)
        Me.LabelMedia.TabIndex = 12
        Me.LabelMedia.Text = "Label1"
        '
        'FormDettaglioRg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 361)
        Me.Controls.Add(Me.tlpMain)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FormDettaglioRg"
        Me.Text = "FormDettaglioRg"
        CType(Me.dgvDettaglio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvDettaglio As System.Windows.Forms.DataGridView
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonEsporta As System.Windows.Forms.Button
    Friend WithEvents ButtonEsci As System.Windows.Forms.Button
    Friend WithEvents LabelTotaleTassabile As System.Windows.Forms.Label
    Friend WithEvents LabelTotaleLordo As System.Windows.Forms.Label
    Friend WithEvents LabelRecord As System.Windows.Forms.Label
    Friend WithEvents LabelPeriodo As System.Windows.Forms.Label
    Friend WithEvents LabelMedia As System.Windows.Forms.Label
End Class
