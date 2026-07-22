<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormConteggioDoc
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
        Me.ButtonConta = New System.Windows.Forms.Button()
        Me.RadioButtonInizia = New System.Windows.Forms.RadioButton()
        Me.RadioButtonContiene = New System.Windows.Forms.RadioButton()
        Me.LabelRisultato = New System.Windows.Forms.Label()
        Me.ButtonSalva = New System.Windows.Forms.Button()
        Me.ComboBoxChiave = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RadioButtonTuttiDocumenti = New System.Windows.Forms.RadioButton()
        Me.RadioButtonCliente = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonConta
        '
        Me.ButtonConta.Location = New System.Drawing.Point(12, 206)
        Me.ButtonConta.Name = "ButtonConta"
        Me.ButtonConta.Size = New System.Drawing.Size(191, 67)
        Me.ButtonConta.TabIndex = 1
        Me.ButtonConta.Text = "Button1"
        Me.ButtonConta.UseVisualStyleBackColor = True
        '
        'RadioButtonInizia
        '
        Me.RadioButtonInizia.AutoSize = True
        Me.RadioButtonInizia.Location = New System.Drawing.Point(3, 3)
        Me.RadioButtonInizia.Name = "RadioButtonInizia"
        Me.RadioButtonInizia.Size = New System.Drawing.Size(276, 18)
        Me.RadioButtonInizia.TabIndex = 2
        Me.RadioButtonInizia.TabStop = True
        Me.RadioButtonInizia.Text = "Trova i documenti con il nome che INIZIA per"
        Me.RadioButtonInizia.UseVisualStyleBackColor = True
        '
        'RadioButtonContiene
        '
        Me.RadioButtonContiene.AutoSize = True
        Me.RadioButtonContiene.Location = New System.Drawing.Point(3, 27)
        Me.RadioButtonContiene.Name = "RadioButtonContiene"
        Me.RadioButtonContiene.Size = New System.Drawing.Size(248, 18)
        Me.RadioButtonContiene.TabIndex = 3
        Me.RadioButtonContiene.TabStop = True
        Me.RadioButtonContiene.Text = "Trova i documenti il cui nome CONTIENE"
        Me.RadioButtonContiene.UseVisualStyleBackColor = True
        '
        'LabelRisultato
        '
        Me.LabelRisultato.BackColor = System.Drawing.SystemColors.Control
        Me.LabelRisultato.Location = New System.Drawing.Point(15, 156)
        Me.LabelRisultato.Name = "LabelRisultato"
        Me.LabelRisultato.Size = New System.Drawing.Size(386, 47)
        Me.LabelRisultato.TabIndex = 4
        Me.LabelRisultato.Text = "Label1"
        Me.LabelRisultato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonSalva
        '
        Me.ButtonSalva.Location = New System.Drawing.Point(210, 206)
        Me.ButtonSalva.Name = "ButtonSalva"
        Me.ButtonSalva.Size = New System.Drawing.Size(191, 67)
        Me.ButtonSalva.TabIndex = 5
        Me.ButtonSalva.Text = "Button1"
        Me.ButtonSalva.UseVisualStyleBackColor = True
        '
        'ComboBoxChiave
        '
        Me.ComboBoxChiave.FormattingEnabled = True
        Me.ComboBoxChiave.Location = New System.Drawing.Point(3, 61)
        Me.ComboBoxChiave.Name = "ComboBoxChiave"
        Me.ComboBoxChiave.Size = New System.Drawing.Size(380, 22)
        Me.ComboBoxChiave.TabIndex = 6
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.RadioButtonInizia)
        Me.Panel1.Controls.Add(Me.RadioButtonContiene)
        Me.Panel1.Controls.Add(Me.ComboBoxChiave)
        Me.Panel1.Location = New System.Drawing.Point(15, 10)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(386, 86)
        Me.Panel1.TabIndex = 7
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.RadioButtonTuttiDocumenti)
        Me.Panel2.Controls.Add(Me.RadioButtonCliente)
        Me.Panel2.Location = New System.Drawing.Point(15, 102)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(386, 51)
        Me.Panel2.TabIndex = 8
        '
        'RadioButtonTuttiDocumenti
        '
        Me.RadioButtonTuttiDocumenti.AutoSize = True
        Me.RadioButtonTuttiDocumenti.Location = New System.Drawing.Point(3, 27)
        Me.RadioButtonTuttiDocumenti.Name = "RadioButtonTuttiDocumenti"
        Me.RadioButtonTuttiDocumenti.Size = New System.Drawing.Size(246, 18)
        Me.RadioButtonTuttiDocumenti.TabIndex = 1
        Me.RadioButtonTuttiDocumenti.TabStop = True
        Me.RadioButtonTuttiDocumenti.Text = "Cerca in tutti i documenti di tutti i clienti"
        Me.RadioButtonTuttiDocumenti.UseVisualStyleBackColor = True
        '
        'RadioButtonCliente
        '
        Me.RadioButtonCliente.AutoSize = True
        Me.RadioButtonCliente.Location = New System.Drawing.Point(3, 3)
        Me.RadioButtonCliente.Name = "RadioButtonCliente"
        Me.RadioButtonCliente.Size = New System.Drawing.Size(115, 18)
        Me.RadioButtonCliente.TabIndex = 0
        Me.RadioButtonCliente.TabStop = True
        Me.RadioButtonCliente.Text = "Cerca nel cliente"
        Me.RadioButtonCliente.UseVisualStyleBackColor = True
        '
        'FormConteggioDoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 285)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ButtonSalva)
        Me.Controls.Add(Me.LabelRisultato)
        Me.Controls.Add(Me.ButtonConta)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FormConteggioDoc"
        Me.Text = "FormConteggioDoc"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonConta As System.Windows.Forms.Button
    Friend WithEvents RadioButtonInizia As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonContiene As System.Windows.Forms.RadioButton
    Friend WithEvents LabelRisultato As System.Windows.Forms.Label
    Friend WithEvents ButtonSalva As System.Windows.Forms.Button
    Friend WithEvents ComboBoxChiave As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonTuttiDocumenti As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonCliente As System.Windows.Forms.RadioButton
End Class
