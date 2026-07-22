<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormChiaviSetting
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
        Me.ListViewChiavi = New System.Windows.Forms.ListView()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonElimina = New UtControls.UtFlatButton()
        Me.LabelInfo = New System.Windows.Forms.Label()
        Me.rbUtente = New System.Windows.Forms.RadioButton()
        Me.rbInterop = New System.Windows.Forms.RadioButton()
        Me.rbGlobale = New System.Windows.Forms.RadioButton()
        Me.ButtonModifica = New UtControls.UtFlatButton()
        Me.rbPostalizzazione = New System.Windows.Forms.RadioButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListViewChiavi
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ListViewChiavi, 4)
        Me.ListViewChiavi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewChiavi.Location = New System.Drawing.Point(3, 28)
        Me.ListViewChiavi.Name = "ListViewChiavi"
        Me.ListViewChiavi.Size = New System.Drawing.Size(412, 222)
        Me.ListViewChiavi.TabIndex = 0
        Me.ListViewChiavi.UseCompatibleStateImageBehavior = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ListViewChiavi, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonElimina, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelInfo, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.rbUtente, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.rbInterop, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.rbGlobale, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonModifica, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.rbPostalizzazione, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(418, 343)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'ButtonElimina
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonElimina, 2)
        Me.ButtonElimina.DefaultBorderSize = 0
        Me.ButtonElimina.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonElimina.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonElimina.FlatAppearance.BorderSize = 0
        Me.ButtonElimina.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonElimina.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonElimina.Location = New System.Drawing.Point(0, 253)
        Me.ButtonElimina.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonElimina.Name = "ButtonElimina"
        Me.ButtonElimina.Size = New System.Drawing.Size(208, 25)
        Me.ButtonElimina.TabIndex = 4
        Me.ButtonElimina.Text = "UtFlatButton1"
        Me.ButtonElimina.UseVisualStyleBackColor = True
        '
        'LabelInfo
        '
        Me.LabelInfo.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelInfo, 4)
        Me.LabelInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelInfo.Location = New System.Drawing.Point(3, 278)
        Me.LabelInfo.Name = "LabelInfo"
        Me.TableLayoutPanel1.SetRowSpan(Me.LabelInfo, 2)
        Me.LabelInfo.Size = New System.Drawing.Size(412, 65)
        Me.LabelInfo.TabIndex = 7
        Me.LabelInfo.Text = "Label1"
        Me.LabelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rbUtente
        '
        Me.rbUtente.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbUtente.AutoSize = True
        Me.rbUtente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbUtente.Location = New System.Drawing.Point(3, 3)
        Me.rbUtente.Name = "rbUtente"
        Me.rbUtente.Size = New System.Drawing.Size(98, 19)
        Me.rbUtente.TabIndex = 8
        Me.rbUtente.TabStop = True
        Me.rbUtente.Text = "RadioButton1"
        Me.rbUtente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbUtente.UseVisualStyleBackColor = True
        '
        'rbInterop
        '
        Me.rbInterop.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbInterop.AutoSize = True
        Me.rbInterop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbInterop.Location = New System.Drawing.Point(107, 3)
        Me.rbInterop.Name = "rbInterop"
        Me.rbInterop.Size = New System.Drawing.Size(98, 19)
        Me.rbInterop.TabIndex = 9
        Me.rbInterop.TabStop = True
        Me.rbInterop.Text = "RadioButton2"
        Me.rbInterop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbInterop.UseVisualStyleBackColor = True
        '
        'rbGlobale
        '
        Me.rbGlobale.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbGlobale.AutoSize = True
        Me.rbGlobale.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbGlobale.Location = New System.Drawing.Point(211, 3)
        Me.rbGlobale.Name = "rbGlobale"
        Me.rbGlobale.Size = New System.Drawing.Size(98, 19)
        Me.rbGlobale.TabIndex = 10
        Me.rbGlobale.TabStop = True
        Me.rbGlobale.Text = "RadioButton3"
        Me.rbGlobale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbGlobale.UseVisualStyleBackColor = True
        '
        'ButtonModifica
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonModifica, 2)
        Me.ButtonModifica.DefaultBorderSize = 0
        Me.ButtonModifica.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonModifica.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonModifica.FlatAppearance.BorderSize = 0
        Me.ButtonModifica.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonModifica.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonModifica.Location = New System.Drawing.Point(208, 253)
        Me.ButtonModifica.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonModifica.Name = "ButtonModifica"
        Me.ButtonModifica.Size = New System.Drawing.Size(210, 25)
        Me.ButtonModifica.TabIndex = 11
        Me.ButtonModifica.Text = "UtFlatButton1"
        Me.ButtonModifica.UseVisualStyleBackColor = True
        '
        'rbPostalizzazione
        '
        Me.rbPostalizzazione.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbPostalizzazione.AutoSize = True
        Me.rbPostalizzazione.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbPostalizzazione.Location = New System.Drawing.Point(315, 3)
        Me.rbPostalizzazione.Name = "rbPostalizzazione"
        Me.rbPostalizzazione.Size = New System.Drawing.Size(100, 19)
        Me.rbPostalizzazione.TabIndex = 12
        Me.rbPostalizzazione.TabStop = True
        Me.rbPostalizzazione.Text = "RadioButton1"
        Me.rbPostalizzazione.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbPostalizzazione.UseVisualStyleBackColor = True
        '
        'FormChiaviSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 343)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormChiaviSetting"
        Me.Text = "FormChiaviSetting"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListViewChiavi As System.Windows.Forms.ListView
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonElimina As UtControls.UtFlatButton
    Friend WithEvents LabelInfo As System.Windows.Forms.Label
    Friend WithEvents rbUtente As System.Windows.Forms.RadioButton
    Friend WithEvents rbInterop As System.Windows.Forms.RadioButton
    Friend WithEvents rbGlobale As System.Windows.Forms.RadioButton
    Friend WithEvents ButtonModifica As UtControls.UtFlatButton
    Friend WithEvents rbPostalizzazione As System.Windows.Forms.RadioButton
End Class
