<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormRichiestaSito
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.wbConsap = New System.Windows.Forms.WebBrowser()
        Me.ListBoxDati = New System.Windows.Forms.ListBox()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelMessaggio = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.tlpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.wbConsap)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.tlpMain)
        Me.SplitContainer1.Size = New System.Drawing.Size(436, 354)
        Me.SplitContainer1.SplitterDistance = 307
        Me.SplitContainer1.TabIndex = 0
        '
        'wbConsap
        '
        Me.wbConsap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbConsap.Location = New System.Drawing.Point(0, 0)
        Me.wbConsap.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbConsap.Name = "wbConsap"
        Me.wbConsap.Size = New System.Drawing.Size(307, 354)
        Me.wbConsap.TabIndex = 0
        '
        'ListBoxDati
        '
        Me.ListBoxDati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBoxDati.FormattingEnabled = True
        Me.ListBoxDati.Location = New System.Drawing.Point(0, 0)
        Me.ListBoxDati.Margin = New System.Windows.Forms.Padding(0)
        Me.ListBoxDati.Name = "ListBoxDati"
        Me.ListBoxDati.Size = New System.Drawing.Size(125, 284)
        Me.ListBoxDati.TabIndex = 0
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 1
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Controls.Add(Me.ListBoxDati, 0, 0)
        Me.tlpMain.Controls.Add(Me.LabelMessaggio, 0, 2)
        Me.tlpMain.Controls.Add(Me.Label1, 0, 1)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Margin = New System.Windows.Forms.Padding(0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 3
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlpMain.Size = New System.Drawing.Size(125, 354)
        Me.tlpMain.TabIndex = 1
        '
        'LabelMessaggio
        '
        Me.LabelMessaggio.AutoSize = True
        Me.LabelMessaggio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelMessaggio.Location = New System.Drawing.Point(3, 304)
        Me.LabelMessaggio.Name = "LabelMessaggio"
        Me.LabelMessaggio.Size = New System.Drawing.Size(119, 50)
        Me.LabelMessaggio.TabIndex = 1
        Me.LabelMessaggio.Text = "Label1"
        Me.LabelMessaggio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Lavender
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(0, 284)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "copiato negli appunti:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FormRichiestaSito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(436, 354)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FormRichiestaSito"
        Me.Text = "FormRichiestaSito"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents wbConsap As WebBrowser
    Friend WithEvents ListBoxDati As ListBox
    Friend WithEvents tlpMain As TableLayoutPanel
    Friend WithEvents LabelMessaggio As Label
    Friend WithEvents Label1 As Label
End Class
