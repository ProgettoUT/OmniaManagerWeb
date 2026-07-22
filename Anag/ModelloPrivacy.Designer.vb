<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModelloPrivacy
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.picPictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTitolo = New System.Windows.Forms.Label()
        Me.tableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblModelloPrivacySelezionato = New System.Windows.Forms.Label()
        Me.ButtonApriPdf = New System.Windows.Forms.Button()
        Me.ButtonAnnulla = New System.Windows.Forms.Button()
        Me.tableLayoutPanel1.SuspendLayout()
        CType(Me.picPictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.ColumnCount = 1
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel1.Controls.Add(Me.picPictureBox1, 0, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.lblTitolo, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.tableLayoutPanel2, 0, 2)
        Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 3
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(804, 594)
        Me.tableLayoutPanel1.TabIndex = 0
        '
        'picPictureBox1
        '
        Me.picPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picPictureBox1.Image = Global.Anag.My.Resources.Resources.ModelloPrivacy
        Me.picPictureBox1.Location = New System.Drawing.Point(3, 53)
        Me.picPictureBox1.Name = "picPictureBox1"
        Me.picPictureBox1.Size = New System.Drawing.Size(798, 488)
        Me.picPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPictureBox1.TabIndex = 0
        Me.picPictureBox1.TabStop = False
        '
        'lblTitolo
        '
        Me.lblTitolo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitolo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitolo.Location = New System.Drawing.Point(3, 0)
        Me.lblTitolo.Name = "lblTitolo"
        Me.lblTitolo.Size = New System.Drawing.Size(798, 50)
        Me.lblTitolo.TabIndex = 1
        Me.lblTitolo.Text = "Seleziona il documento della privacy in PDF, avendo cura di rispettare le misure " & _
    "indicate"
        Me.lblTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tableLayoutPanel2
        '
        Me.tableLayoutPanel2.ColumnCount = 4
        Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tableLayoutPanel2.Controls.Add(Me.lblModelloPrivacySelezionato, 0, 0)
        Me.tableLayoutPanel2.Controls.Add(Me.ButtonApriPdf, 1, 0)
        Me.tableLayoutPanel2.Controls.Add(Me.ButtonAnnulla, 3, 0)
        Me.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel2.Location = New System.Drawing.Point(3, 547)
        Me.tableLayoutPanel2.Name = "tableLayoutPanel2"
        Me.tableLayoutPanel2.RowCount = 1
        Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel2.Size = New System.Drawing.Size(798, 44)
        Me.tableLayoutPanel2.TabIndex = 3
        '
        'lblModelloPrivacySelezionato
        '
        Me.lblModelloPrivacySelezionato.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblModelloPrivacySelezionato.Location = New System.Drawing.Point(5, 5)
        Me.lblModelloPrivacySelezionato.Margin = New System.Windows.Forms.Padding(5)
        Me.lblModelloPrivacySelezionato.Name = "lblModelloPrivacySelezionato"
        Me.lblModelloPrivacySelezionato.Size = New System.Drawing.Size(309, 34)
        Me.lblModelloPrivacySelezionato.TabIndex = 0
        Me.lblModelloPrivacySelezionato.Text = "Nessun modello privacy selezionato"
        Me.lblModelloPrivacySelezionato.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonApriPdf
        '
        Me.tableLayoutPanel2.SetColumnSpan(Me.ButtonApriPdf, 2)
        Me.ButtonApriPdf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonApriPdf.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonApriPdf.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonApriPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonApriPdf.Location = New System.Drawing.Point(322, 3)
        Me.ButtonApriPdf.Name = "ButtonApriPdf"
        Me.ButtonApriPdf.Size = New System.Drawing.Size(312, 38)
        Me.ButtonApriPdf.TabIndex = 1
        Me.ButtonApriPdf.Text = "Seleziona modello"
        Me.ButtonApriPdf.UseVisualStyleBackColor = True
        '
        'ButtonAnnulla
        '
        Me.ButtonAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnnulla.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonAnnulla.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAnnulla.Location = New System.Drawing.Point(640, 3)
        Me.ButtonAnnulla.Name = "ButtonAnnulla"
        Me.ButtonAnnulla.Size = New System.Drawing.Size(155, 38)
        Me.ButtonAnnulla.TabIndex = 1
        Me.ButtonAnnulla.Text = "Annulla"
        Me.ButtonAnnulla.UseVisualStyleBackColor = True
        '
        'ModelloPrivacy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 594)
        Me.Controls.Add(Me.tableLayoutPanel1)
        Me.Name = "ModelloPrivacy"
        Me.Text = "ModelloPrivacy"
        Me.tableLayoutPanel1.ResumeLayout(False)
        CType(Me.picPictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents picPictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitolo As System.Windows.Forms.Label
    Friend WithEvents lblModelloPrivacySelezionato As System.Windows.Forms.Label
    Friend WithEvents tableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonApriPdf As System.Windows.Forms.Button
    Friend WithEvents ButtonAnnulla As System.Windows.Forms.Button
End Class
