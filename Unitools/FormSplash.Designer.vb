<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSplash
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
        Me.components = New System.ComponentModel.Container()
        Me.PictureBoxLogoUniarea = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelInfo = New System.Windows.Forms.Label()
        Me.LabelVersione = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.LabelStato = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LabelCapsLock = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.PictureBoxLogoUniarea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBoxLogoUniarea
        '
        Me.PictureBoxLogoUniarea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBoxLogoUniarea.Location = New System.Drawing.Point(0, 0)
        Me.PictureBoxLogoUniarea.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBoxLogoUniarea.Name = "PictureBoxLogoUniarea"
        Me.PictureBoxLogoUniarea.Size = New System.Drawing.Size(497, 85)
        Me.PictureBoxLogoUniarea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxLogoUniarea.TabIndex = 1
        Me.PictureBoxLogoUniarea.TabStop = False
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 1
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Controls.Add(Me.PictureBoxLogoUniarea, 0, 0)
        Me.tlpMain.Controls.Add(Me.LabelInfo, 0, 1)
        Me.tlpMain.Controls.Add(Me.LabelVersione, 0, 2)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 3
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpMain.Size = New System.Drawing.Size(497, 356)
        Me.tlpMain.TabIndex = 2
        '
        'LabelInfo
        '
        Me.LabelInfo.AutoSize = True
        Me.LabelInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelInfo.Location = New System.Drawing.Point(3, 85)
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(491, 251)
        Me.LabelInfo.TabIndex = 2
        Me.LabelInfo.Text = "Label1"
        Me.LabelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelVersione
        '
        Me.LabelVersione.AutoSize = True
        Me.LabelVersione.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelVersione.Location = New System.Drawing.Point(3, 336)
        Me.LabelVersione.Name = "LabelVersione"
        Me.LabelVersione.Size = New System.Drawing.Size(491, 20)
        Me.LabelVersione.TabIndex = 3
        Me.LabelVersione.Text = "Label1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.StatusStrip1)
        Me.Panel1.Controls.Add(Me.tlpMain)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(497, 356)
        Me.Panel1.TabIndex = 3
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LabelStato, Me.LabelCapsLock})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 334)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(497, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 17
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'LabelStato
        '
        Me.LabelStato.Name = "LabelStato"
        Me.LabelStato.Size = New System.Drawing.Size(25, 17)
        Me.LabelStato.Text = "xxx"
        '
        'LabelCapsLock
        '
        Me.LabelCapsLock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.LabelCapsLock.Name = "LabelCapsLock"
        Me.LabelCapsLock.Size = New System.Drawing.Size(56, 17)
        Me.LabelCapsLock.Text = "caps lock"
        '
        'FormSplash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(497, 356)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FormSplash"
        Me.Text = "FormSplash"
        CType(Me.PictureBoxLogoUniarea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBoxLogoUniarea As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelInfo As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents LabelStato As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LabelCapsLock As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LabelVersione As System.Windows.Forms.Label
End Class
