<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCercaCliente
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
        Me.ButtonCerca = New System.Windows.Forms.Button()
        Me.TextBoxCerca = New System.Windows.Forms.TextBox()
        Me.ButtonOk = New System.Windows.Forms.Button()
        Me.ButtonAnnulla = New System.Windows.Forms.Button()
        Me.dgvClienti = New System.Windows.Forms.DataGridView()
        Me.dgvSinistri = New System.Windows.Forms.DataGridView()
        Me.tlpMain.SuspendLayout()
        CType(Me.dgvClienti, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSinistri, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 2
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tlpMain.Controls.Add(Me.TextBoxCerca, 0, 0)
        Me.tlpMain.Controls.Add(Me.ButtonCerca, 1, 0)
        Me.tlpMain.Controls.Add(Me.dgvClienti, 0, 1)
        Me.tlpMain.Controls.Add(Me.ButtonOk, 0, 3)
        Me.tlpMain.Controls.Add(Me.ButtonAnnulla, 1, 3)
        Me.tlpMain.Controls.Add(Me.dgvSinistri, 0, 2)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 4
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlpMain.Size = New System.Drawing.Size(730, 306)
        Me.tlpMain.TabIndex = 0
        '
        'ButtonCerca
        '
        Me.ButtonCerca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCerca.Location = New System.Drawing.Point(514, 3)
        Me.ButtonCerca.Name = "ButtonCerca"
        Me.ButtonCerca.Size = New System.Drawing.Size(213, 22)
        Me.ButtonCerca.TabIndex = 1
        Me.ButtonCerca.Text = "Button1"
        Me.ButtonCerca.UseVisualStyleBackColor = True
        '
        'TextBoxCerca
        '
        Me.TextBoxCerca.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TextBoxCerca.Location = New System.Drawing.Point(3, 5)
        Me.TextBoxCerca.Name = "TextBoxCerca"
        Me.TextBoxCerca.Size = New System.Drawing.Size(505, 20)
        Me.TextBoxCerca.TabIndex = 0
        '
        'ButtonOk
        '
        Me.ButtonOk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonOk.Location = New System.Drawing.Point(3, 269)
        Me.ButtonOk.Name = "ButtonOk"
        Me.ButtonOk.Size = New System.Drawing.Size(505, 34)
        Me.ButtonOk.TabIndex = 3
        Me.ButtonOk.Text = "Button2"
        Me.ButtonOk.UseVisualStyleBackColor = True
        '
        'ButtonAnnulla
        '
        Me.ButtonAnnulla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnnulla.Location = New System.Drawing.Point(514, 269)
        Me.ButtonAnnulla.Name = "ButtonAnnulla"
        Me.ButtonAnnulla.Size = New System.Drawing.Size(213, 34)
        Me.ButtonAnnulla.TabIndex = 4
        Me.ButtonAnnulla.Text = "Button3"
        Me.ButtonAnnulla.UseVisualStyleBackColor = True
        '
        'dgvClienti
        '
        Me.dgvClienti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpMain.SetColumnSpan(Me.dgvClienti, 2)
        Me.dgvClienti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvClienti.Location = New System.Drawing.Point(3, 31)
        Me.dgvClienti.Name = "dgvClienti"
        Me.dgvClienti.Size = New System.Drawing.Size(724, 113)
        Me.dgvClienti.TabIndex = 2
        '
        'dgvSinistri
        '
        Me.dgvSinistri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpMain.SetColumnSpan(Me.dgvSinistri, 2)
        Me.dgvSinistri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSinistri.Location = New System.Drawing.Point(3, 150)
        Me.dgvSinistri.Name = "dgvSinistri"
        Me.dgvSinistri.Size = New System.Drawing.Size(724, 113)
        Me.dgvSinistri.TabIndex = 5
        '
        'FormCercaCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(730, 306)
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "FormCercaCliente"
        Me.Text = "FormCercaCliente"
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        CType(Me.dgvClienti, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSinistri, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonCerca As System.Windows.Forms.Button
    Friend WithEvents TextBoxCerca As System.Windows.Forms.TextBox
    Friend WithEvents ButtonOk As System.Windows.Forms.Button
    Friend WithEvents ButtonAnnulla As System.Windows.Forms.Button
    Friend WithEvents dgvClienti As System.Windows.Forms.DataGridView
    Friend WithEvents dgvSinistri As System.Windows.Forms.DataGridView
End Class
