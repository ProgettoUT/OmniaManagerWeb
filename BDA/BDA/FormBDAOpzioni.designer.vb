<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBDAOpzioni
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
        Me.TipoFile = New System.Windows.Forms.GroupBox()
        Me.LabelFileOrigine = New System.Windows.Forms.Label()
        Me.ButtonSfoglia = New System.Windows.Forms.Button()
        Me.LabelDesk = New System.Windows.Forms.Label()
        Me.rbUtente = New System.Windows.Forms.RadioButton()
        Me.rbArretrati = New System.Windows.Forms.RadioButton()
        Me.rbStornate = New System.Windows.Forms.RadioButton()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonAvvia = New System.Windows.Forms.Button()
        Me.ButtonAnnulla = New System.Windows.Forms.Button()
        Me.Veicoli = New System.Windows.Forms.GroupBox()
        Me.rbTuttiVeicoli = New System.Windows.Forms.RadioButton()
        Me.rbAutovetture = New System.Windows.Forms.RadioButton()
        Me.ButtonModello = New System.Windows.Forms.Button()
        Me.TipoFile.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Veicoli.SuspendLayout()
        Me.SuspendLayout()
        '
        'TipoFile
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TipoFile, 2)
        Me.TipoFile.Controls.Add(Me.ButtonModello)
        Me.TipoFile.Controls.Add(Me.LabelFileOrigine)
        Me.TipoFile.Controls.Add(Me.ButtonSfoglia)
        Me.TipoFile.Controls.Add(Me.LabelDesk)
        Me.TipoFile.Controls.Add(Me.rbUtente)
        Me.TipoFile.Controls.Add(Me.rbArretrati)
        Me.TipoFile.Controls.Add(Me.rbStornate)
        Me.TipoFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TipoFile.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TipoFile.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TipoFile.Location = New System.Drawing.Point(3, 3)
        Me.TipoFile.Name = "TipoFile"
        Me.TipoFile.Size = New System.Drawing.Size(480, 143)
        Me.TipoFile.TabIndex = 0
        Me.TipoFile.TabStop = False
        Me.TipoFile.Text = "Provenienza targhe"
        '
        'LabelFileOrigine
        '
        Me.LabelFileOrigine.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelFileOrigine.ForeColor = System.Drawing.SystemColors.WindowText
        Me.LabelFileOrigine.Location = New System.Drawing.Point(6, 113)
        Me.LabelFileOrigine.Name = "LabelFileOrigine"
        Me.LabelFileOrigine.Size = New System.Drawing.Size(324, 22)
        Me.LabelFileOrigine.TabIndex = 5
        Me.LabelFileOrigine.Text = "Label1"
        Me.LabelFileOrigine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonSfoglia
        '
        Me.ButtonSfoglia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonSfoglia.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ButtonSfoglia.Location = New System.Drawing.Point(336, 113)
        Me.ButtonSfoglia.Name = "ButtonSfoglia"
        Me.ButtonSfoglia.Size = New System.Drawing.Size(67, 22)
        Me.ButtonSfoglia.TabIndex = 4
        Me.ButtonSfoglia.Text = "Button1"
        Me.ButtonSfoglia.UseVisualStyleBackColor = True
        '
        'LabelDesk
        '
        Me.LabelDesk.BackColor = System.Drawing.SystemColors.Control
        Me.LabelDesk.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelDesk.Location = New System.Drawing.Point(220, 30)
        Me.LabelDesk.Name = "LabelDesk"
        Me.LabelDesk.Size = New System.Drawing.Size(254, 66)
        Me.LabelDesk.TabIndex = 3
        Me.LabelDesk.Text = "descrizione tipo file"
        '
        'rbUtente
        '
        Me.rbUtente.AutoSize = True
        Me.rbUtente.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbUtente.Location = New System.Drawing.Point(6, 78)
        Me.rbUtente.Name = "rbUtente"
        Me.rbUtente.Size = New System.Drawing.Size(84, 18)
        Me.rbUtente.TabIndex = 2
        Me.rbUtente.TabStop = True
        Me.rbUtente.Text = "File utente"
        Me.rbUtente.UseVisualStyleBackColor = True
        '
        'rbArretrati
        '
        Me.rbArretrati.AutoSize = True
        Me.rbArretrati.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbArretrati.Location = New System.Drawing.Point(6, 54)
        Me.rbArretrati.Name = "rbArretrati"
        Me.rbArretrati.Size = New System.Drawing.Size(98, 18)
        Me.rbArretrati.TabIndex = 1
        Me.rbArretrati.TabStop = True
        Me.rbArretrati.Text = "Titoli arretrati"
        Me.rbArretrati.UseVisualStyleBackColor = True
        '
        'rbStornate
        '
        Me.rbStornate.AutoSize = True
        Me.rbStornate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbStornate.Location = New System.Drawing.Point(6, 30)
        Me.rbStornate.Name = "rbStornate"
        Me.rbStornate.Size = New System.Drawing.Size(196, 18)
        Me.rbStornate.TabIndex = 0
        Me.rbStornate.TabStop = True
        Me.rbStornate.Text = "Archivio storico polizze stornate"
        Me.rbStornate.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.34156!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.65844!))
        Me.TableLayoutPanel1.Controls.Add(Me.TipoFile, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAvvia, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAnnulla, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Veicoli, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(486, 280)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'ButtonAvvia
        '
        Me.ButtonAvvia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAvvia.Location = New System.Drawing.Point(3, 232)
        Me.ButtonAvvia.Name = "ButtonAvvia"
        Me.ButtonAvvia.Size = New System.Drawing.Size(330, 45)
        Me.ButtonAvvia.TabIndex = 1
        Me.ButtonAvvia.Text = "Ok"
        Me.ButtonAvvia.UseVisualStyleBackColor = True
        '
        'ButtonAnnulla
        '
        Me.ButtonAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnnulla.Location = New System.Drawing.Point(339, 232)
        Me.ButtonAnnulla.Name = "ButtonAnnulla"
        Me.ButtonAnnulla.Size = New System.Drawing.Size(144, 45)
        Me.ButtonAnnulla.TabIndex = 2
        Me.ButtonAnnulla.Text = "Annulla"
        Me.ButtonAnnulla.UseVisualStyleBackColor = True
        '
        'Veicoli
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.Veicoli, 2)
        Me.Veicoli.Controls.Add(Me.rbTuttiVeicoli)
        Me.Veicoli.Controls.Add(Me.rbAutovetture)
        Me.Veicoli.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Veicoli.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Veicoli.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Veicoli.Location = New System.Drawing.Point(3, 152)
        Me.Veicoli.Name = "Veicoli"
        Me.Veicoli.Size = New System.Drawing.Size(480, 74)
        Me.Veicoli.TabIndex = 3
        Me.Veicoli.TabStop = False
        Me.Veicoli.Text = "Tipo veicoli"
        '
        'rbTuttiVeicoli
        '
        Me.rbTuttiVeicoli.AutoSize = True
        Me.rbTuttiVeicoli.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbTuttiVeicoli.Location = New System.Drawing.Point(9, 44)
        Me.rbTuttiVeicoli.Name = "rbTuttiVeicoli"
        Me.rbTuttiVeicoli.Size = New System.Drawing.Size(94, 18)
        Me.rbTuttiVeicoli.TabIndex = 1
        Me.rbTuttiVeicoli.TabStop = True
        Me.rbTuttiVeicoli.Text = "Tutti i veicoli"
        Me.rbTuttiVeicoli.UseVisualStyleBackColor = True
        '
        'rbAutovetture
        '
        Me.rbAutovetture.AutoSize = True
        Me.rbAutovetture.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rbAutovetture.Location = New System.Drawing.Point(9, 21)
        Me.rbAutovetture.Name = "rbAutovetture"
        Me.rbAutovetture.Size = New System.Drawing.Size(118, 18)
        Me.rbAutovetture.TabIndex = 0
        Me.rbAutovetture.TabStop = True
        Me.rbAutovetture.Text = "Solo autovetture"
        Me.rbAutovetture.UseVisualStyleBackColor = True
        '
        'ButtonModello
        '
        Me.ButtonModello.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonModello.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ButtonModello.Location = New System.Drawing.Point(407, 113)
        Me.ButtonModello.Name = "ButtonModello"
        Me.ButtonModello.Size = New System.Drawing.Size(67, 22)
        Me.ButtonModello.TabIndex = 6
        Me.ButtonModello.Text = "Button1"
        Me.ButtonModello.UseVisualStyleBackColor = True
        '
        'FormBDAOpzioni
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 286)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormBDAOpzioni"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.Text = "FormBDA"
        Me.TipoFile.ResumeLayout(False)
        Me.TipoFile.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Veicoli.ResumeLayout(False)
        Me.Veicoli.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TipoFile As System.Windows.Forms.GroupBox
    Friend WithEvents LabelDesk As System.Windows.Forms.Label
    Friend WithEvents rbUtente As System.Windows.Forms.RadioButton
    Friend WithEvents rbArretrati As System.Windows.Forms.RadioButton
    Friend WithEvents rbStornate As System.Windows.Forms.RadioButton
    Friend WithEvents ButtonSfoglia As System.Windows.Forms.Button
    Friend WithEvents LabelFileOrigine As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonAvvia As System.Windows.Forms.Button
    Friend WithEvents ButtonAnnulla As System.Windows.Forms.Button
    Friend WithEvents Veicoli As System.Windows.Forms.GroupBox
    Friend WithEvents rbTuttiVeicoli As System.Windows.Forms.RadioButton
    Friend WithEvents rbAutovetture As System.Windows.Forms.RadioButton
    Friend WithEvents ButtonModello As System.Windows.Forms.Button
End Class
