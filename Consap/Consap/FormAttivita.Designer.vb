<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAttivita
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
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelDeskPolizza = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LabelScadenzaAttivita = New System.Windows.Forms.Label()
        Me.LabelPolizza = New System.Windows.Forms.Label()
        Me.LabelScadenza = New System.Windows.Forms.Label()
        Me.ButtonCreaAttivita = New System.Windows.Forms.Button()
        Me.dtpScadenzaAttivita = New System.Windows.Forms.DateTimePicker()
        Me.LabelHelp = New System.Windows.Forms.Label()
        Me.tlpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 2
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.tlpMain.Controls.Add(Me.LabelDeskPolizza, 0, 0)
        Me.tlpMain.Controls.Add(Me.Label2, 0, 1)
        Me.tlpMain.Controls.Add(Me.LabelScadenzaAttivita, 0, 2)
        Me.tlpMain.Controls.Add(Me.LabelPolizza, 1, 0)
        Me.tlpMain.Controls.Add(Me.LabelScadenza, 1, 1)
        Me.tlpMain.Controls.Add(Me.ButtonCreaAttivita, 0, 4)
        Me.tlpMain.Controls.Add(Me.dtpScadenzaAttivita, 1, 2)
        Me.tlpMain.Controls.Add(Me.LabelHelp, 0, 3)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 5
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlpMain.Size = New System.Drawing.Size(376, 194)
        Me.tlpMain.TabIndex = 0
        '
        'LabelDeskPolizza
        '
        Me.LabelDeskPolizza.AutoSize = True
        Me.LabelDeskPolizza.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelDeskPolizza.Location = New System.Drawing.Point(3, 0)
        Me.LabelDeskPolizza.Name = "LabelDeskPolizza"
        Me.LabelDeskPolizza.Size = New System.Drawing.Size(219, 27)
        Me.LabelDeskPolizza.TabIndex = 0
        Me.LabelDeskPolizza.Text = "Polizza"
        Me.LabelDeskPolizza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(219, 27)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Scadenza polizza"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelScadenzaAttivita
        '
        Me.LabelScadenzaAttivita.AutoSize = True
        Me.LabelScadenzaAttivita.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelScadenzaAttivita.Location = New System.Drawing.Point(3, 54)
        Me.LabelScadenzaAttivita.Name = "LabelScadenzaAttivita"
        Me.LabelScadenzaAttivita.Size = New System.Drawing.Size(219, 27)
        Me.LabelScadenzaAttivita.TabIndex = 2
        Me.LabelScadenzaAttivita.Text = "Scadenza attività"
        Me.LabelScadenzaAttivita.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelPolizza
        '
        Me.LabelPolizza.AutoSize = True
        Me.LabelPolizza.BackColor = System.Drawing.Color.Transparent
        Me.LabelPolizza.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelPolizza.Location = New System.Drawing.Point(228, 0)
        Me.LabelPolizza.Name = "LabelPolizza"
        Me.LabelPolizza.Size = New System.Drawing.Size(145, 27)
        Me.LabelPolizza.TabIndex = 3
        Me.LabelPolizza.Text = "Label4"
        Me.LabelPolizza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelScadenza
        '
        Me.LabelScadenza.AutoSize = True
        Me.LabelScadenza.BackColor = System.Drawing.Color.Transparent
        Me.LabelScadenza.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelScadenza.Location = New System.Drawing.Point(228, 27)
        Me.LabelScadenza.Name = "LabelScadenza"
        Me.LabelScadenza.Size = New System.Drawing.Size(145, 27)
        Me.LabelScadenza.TabIndex = 4
        Me.LabelScadenza.Text = "Label5"
        Me.LabelScadenza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonCreaAttivita
        '
        Me.tlpMain.SetColumnSpan(Me.ButtonCreaAttivita, 2)
        Me.ButtonCreaAttivita.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCreaAttivita.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonCreaAttivita.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCreaAttivita.Location = New System.Drawing.Point(0, 144)
        Me.ButtonCreaAttivita.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonCreaAttivita.Name = "ButtonCreaAttivita"
        Me.ButtonCreaAttivita.Size = New System.Drawing.Size(376, 50)
        Me.ButtonCreaAttivita.TabIndex = 5
        Me.ButtonCreaAttivita.Text = "Crea attività Consap"
        Me.ButtonCreaAttivita.UseVisualStyleBackColor = True
        '
        'dtpScadenzaAttivita
        '
        Me.dtpScadenzaAttivita.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpScadenzaAttivita.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpScadenzaAttivita.Location = New System.Drawing.Point(228, 57)
        Me.dtpScadenzaAttivita.Name = "dtpScadenzaAttivita"
        Me.dtpScadenzaAttivita.Size = New System.Drawing.Size(145, 20)
        Me.dtpScadenzaAttivita.TabIndex = 6
        '
        'LabelHelp
        '
        Me.LabelHelp.AutoSize = True
        Me.tlpMain.SetColumnSpan(Me.LabelHelp, 2)
        Me.LabelHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelHelp.Location = New System.Drawing.Point(3, 81)
        Me.LabelHelp.Name = "LabelHelp"
        Me.LabelHelp.Padding = New System.Windows.Forms.Padding(5)
        Me.LabelHelp.Size = New System.Drawing.Size(370, 63)
        Me.LabelHelp.TabIndex = 7
        Me.LabelHelp.Text = "Label6"
        '
        'FormAttivita
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(376, 194)
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "FormAttivita"
        Me.Text = "FormAttivita"
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelDeskPolizza As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LabelScadenzaAttivita As System.Windows.Forms.Label
    Friend WithEvents LabelPolizza As System.Windows.Forms.Label
    Friend WithEvents LabelScadenza As System.Windows.Forms.Label
    Friend WithEvents ButtonCreaAttivita As System.Windows.Forms.Button
    Friend WithEvents dtpScadenzaAttivita As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelHelp As System.Windows.Forms.Label
End Class
