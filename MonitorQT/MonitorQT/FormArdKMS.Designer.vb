<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormArdKMS
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
        Me.lvArd = New System.Windows.Forms.ListView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnChiudi = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabRca = New System.Windows.Forms.TabPage()
        Me.lvRca = New System.Windows.Forms.ListView()
        Me.TabIF = New System.Windows.Forms.TabPage()
        Me.lvIF = New System.Windows.Forms.ListView()
        Me.TabArd = New System.Windows.Forms.TabPage()
        Me.TabUnibox = New System.Windows.Forms.TabPage()
        Me.lvUnibox = New System.Windows.Forms.ListView()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.btnStampa = New System.Windows.Forms.Button()
        Me.chkStampaNote = New System.Windows.Forms.CheckBox()
        Me.TabControl1.SuspendLayout()
        Me.TabRca.SuspendLayout()
        Me.TabIF.SuspendLayout()
        Me.TabArd.SuspendLayout()
        Me.TabUnibox.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvArd
        '
        Me.lvArd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvArd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvArd.Location = New System.Drawing.Point(0, 0)
        Me.lvArd.Name = "lvArd"
        Me.lvArd.Size = New System.Drawing.Size(682, 332)
        Me.lvArd.TabIndex = 0
        Me.lvArd.UseCompatibleStateImageBehavior = False
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 370)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(338, 36)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnChiudi
        '
        Me.btnChiudi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChiudi.Location = New System.Drawing.Point(562, 373)
        Me.btnChiudi.Name = "btnChiudi"
        Me.btnChiudi.Size = New System.Drawing.Size(130, 29)
        Me.btnChiudi.TabIndex = 2
        Me.btnChiudi.Text = "Chiudi"
        Me.btnChiudi.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabRca)
        Me.TabControl1.Controls.Add(Me.TabIF)
        Me.TabControl1.Controls.Add(Me.TabArd)
        Me.TabControl1.Controls.Add(Me.TabUnibox)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl1.Location = New System.Drawing.Point(6, 6)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(690, 361)
        Me.TabControl1.TabIndex = 3
        '
        'TabRca
        '
        Me.TabRca.Controls.Add(Me.lvRca)
        Me.TabRca.Location = New System.Drawing.Point(4, 25)
        Me.TabRca.Name = "TabRca"
        Me.TabRca.Size = New System.Drawing.Size(682, 332)
        Me.TabRca.TabIndex = 0
        Me.TabRca.Text = "Rca"
        Me.TabRca.UseVisualStyleBackColor = True
        '
        'lvRca
        '
        Me.lvRca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvRca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvRca.Location = New System.Drawing.Point(0, 0)
        Me.lvRca.Name = "lvRca"
        Me.lvRca.Size = New System.Drawing.Size(682, 332)
        Me.lvRca.TabIndex = 1
        Me.lvRca.UseCompatibleStateImageBehavior = False
        '
        'TabIF
        '
        Me.TabIF.Controls.Add(Me.lvIF)
        Me.TabIF.Location = New System.Drawing.Point(4, 25)
        Me.TabIF.Name = "TabIF"
        Me.TabIF.Size = New System.Drawing.Size(682, 332)
        Me.TabIF.TabIndex = 1
        Me.TabIF.Text = "Incendio, furto & Co"
        Me.TabIF.UseVisualStyleBackColor = True
        '
        'lvIF
        '
        Me.lvIF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvIF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvIF.Location = New System.Drawing.Point(0, 0)
        Me.lvIF.Name = "lvIF"
        Me.lvIF.Size = New System.Drawing.Size(682, 332)
        Me.lvIF.TabIndex = 1
        Me.lvIF.UseCompatibleStateImageBehavior = False
        '
        'TabArd
        '
        Me.TabArd.Controls.Add(Me.lvArd)
        Me.TabArd.Location = New System.Drawing.Point(4, 25)
        Me.TabArd.Name = "TabArd"
        Me.TabArd.Size = New System.Drawing.Size(682, 332)
        Me.TabArd.TabIndex = 2
        Me.TabArd.Text = "Altro CVT"
        Me.TabArd.UseVisualStyleBackColor = True
        '
        'TabUnibox
        '
        Me.TabUnibox.Controls.Add(Me.lvUnibox)
        Me.TabUnibox.Location = New System.Drawing.Point(4, 25)
        Me.TabUnibox.Name = "TabUnibox"
        Me.TabUnibox.Size = New System.Drawing.Size(682, 332)
        Me.TabUnibox.TabIndex = 3
        Me.TabUnibox.Text = "Unibox"
        Me.TabUnibox.UseVisualStyleBackColor = True
        '
        'lvUnibox
        '
        Me.lvUnibox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvUnibox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvUnibox.Location = New System.Drawing.Point(0, 0)
        Me.lvUnibox.Name = "lvUnibox"
        Me.lvUnibox.Size = New System.Drawing.Size(682, 332)
        Me.lvUnibox.TabIndex = 1
        Me.lvUnibox.UseCompatibleStateImageBehavior = False
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'btnStampa
        '
        Me.btnStampa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStampa.Location = New System.Drawing.Point(456, 373)
        Me.btnStampa.Name = "btnStampa"
        Me.btnStampa.Size = New System.Drawing.Size(100, 29)
        Me.btnStampa.TabIndex = 4
        Me.btnStampa.Text = "Stampa"
        Me.btnStampa.UseVisualStyleBackColor = True
        '
        'chkStampaNote
        '
        Me.chkStampaNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkStampaNote.AutoSize = True
        Me.chkStampaNote.Location = New System.Drawing.Point(350, 378)
        Me.chkStampaNote.Name = "chkStampaNote"
        Me.chkStampaNote.Size = New System.Drawing.Size(100, 20)
        Me.chkStampaNote.TabIndex = 5
        Me.chkStampaNote.Text = "Stampa note"
        Me.chkStampaNote.UseVisualStyleBackColor = True
        '
        'frmArd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 412)
        Me.Controls.Add(Me.chkStampaNote)
        Me.Controls.Add(Me.btnStampa)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnChiudi)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MinimizeBox = False
        Me.Name = "frmArd"
        Me.Padding = New System.Windows.Forms.Padding(6)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Dettaglio"
        Me.TabControl1.ResumeLayout(False)
        Me.TabRca.ResumeLayout(False)
        Me.TabIF.ResumeLayout(False)
        Me.TabArd.ResumeLayout(False)
        Me.TabUnibox.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvArd As System.Windows.Forms.ListView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnChiudi As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabRca As System.Windows.Forms.TabPage
    Friend WithEvents TabIF As System.Windows.Forms.TabPage
    Friend WithEvents TabArd As System.Windows.Forms.TabPage
    Friend WithEvents TabUnibox As System.Windows.Forms.TabPage
    Friend WithEvents lvIF As System.Windows.Forms.ListView
    Friend WithEvents lvRca As System.Windows.Forms.ListView
    Friend WithEvents lvUnibox As System.Windows.Forms.ListView
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents btnStampa As System.Windows.Forms.Button
    Friend WithEvents chkStampaNote As System.Windows.Forms.CheckBox
End Class
