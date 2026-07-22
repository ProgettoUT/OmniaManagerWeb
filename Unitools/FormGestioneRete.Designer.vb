<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormGestioneRete
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.rbCip = New System.Windows.Forms.RadioButton()
        Me.rbUtenze = New System.Windows.Forms.RadioButton()
        Me.rbSoggetti = New System.Windows.Forms.RadioButton()
        Me.rbPuntiVendita = New System.Windows.Forms.RadioButton()
        Me.dgvDati = New System.Windows.Forms.DataGridView()
        Me.ButtonAggiornaListe = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonEsci = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgvDati, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.rbCip, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.rbUtenze, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.rbSoggetti, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.rbPuntiVendita, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvDati, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAggiornaListe, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonEsci, 5, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(842, 497)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'rbCip
        '
        Me.rbCip.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbCip.AutoSize = True
        Me.rbCip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbCip.Location = New System.Drawing.Point(480, 0)
        Me.rbCip.Margin = New System.Windows.Forms.Padding(0)
        Me.rbCip.Name = "rbCip"
        Me.rbCip.Size = New System.Drawing.Size(160, 40)
        Me.rbCip.TabIndex = 3
        Me.rbCip.TabStop = True
        Me.rbCip.Text = "Cip"
        Me.rbCip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbCip.UseVisualStyleBackColor = True
        '
        'rbUtenze
        '
        Me.rbUtenze.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbUtenze.AutoSize = True
        Me.rbUtenze.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbUtenze.Location = New System.Drawing.Point(320, 0)
        Me.rbUtenze.Margin = New System.Windows.Forms.Padding(0)
        Me.rbUtenze.Name = "rbUtenze"
        Me.rbUtenze.Size = New System.Drawing.Size(160, 40)
        Me.rbUtenze.TabIndex = 2
        Me.rbUtenze.TabStop = True
        Me.rbUtenze.Text = "Utenze"
        Me.rbUtenze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbUtenze.UseVisualStyleBackColor = True
        '
        'rbSoggetti
        '
        Me.rbSoggetti.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbSoggetti.AutoSize = True
        Me.rbSoggetti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbSoggetti.Location = New System.Drawing.Point(160, 0)
        Me.rbSoggetti.Margin = New System.Windows.Forms.Padding(0)
        Me.rbSoggetti.Name = "rbSoggetti"
        Me.rbSoggetti.Size = New System.Drawing.Size(160, 40)
        Me.rbSoggetti.TabIndex = 1
        Me.rbSoggetti.TabStop = True
        Me.rbSoggetti.Text = "Soggetti"
        Me.rbSoggetti.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbSoggetti.UseVisualStyleBackColor = True
        '
        'rbPuntiVendita
        '
        Me.rbPuntiVendita.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbPuntiVendita.AutoSize = True
        Me.rbPuntiVendita.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbPuntiVendita.Location = New System.Drawing.Point(0, 0)
        Me.rbPuntiVendita.Margin = New System.Windows.Forms.Padding(0)
        Me.rbPuntiVendita.Name = "rbPuntiVendita"
        Me.rbPuntiVendita.Size = New System.Drawing.Size(160, 40)
        Me.rbPuntiVendita.TabIndex = 0
        Me.rbPuntiVendita.TabStop = True
        Me.rbPuntiVendita.Text = "Punti vendita"
        Me.rbPuntiVendita.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbPuntiVendita.UseVisualStyleBackColor = True
        '
        'dgvDati
        '
        Me.dgvDati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.dgvDati, 6)
        Me.dgvDati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDati.Location = New System.Drawing.Point(3, 73)
        Me.dgvDati.Name = "dgvDati"
        Me.dgvDati.Size = New System.Drawing.Size(836, 421)
        Me.dgvDati.TabIndex = 4
        '
        'ButtonAggiornaListe
        '
        Me.ButtonAggiornaListe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAggiornaListe.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonAggiornaListe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAggiornaListe.Location = New System.Drawing.Point(640, 0)
        Me.ButtonAggiornaListe.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonAggiornaListe.Name = "ButtonAggiornaListe"
        Me.ButtonAggiornaListe.Size = New System.Drawing.Size(160, 40)
        Me.ButtonAggiornaListe.TabIndex = 6
        Me.ButtonAggiornaListe.Text = "Aggiorna liste da Essig reti"
        Me.ButtonAggiornaListe.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Khaki
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 6)
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(836, 30)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Eventuali modifiche ai dati vanno effettuate in Essig Reti"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonEsci
        '
        Me.ButtonEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEsci.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonEsci.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEsci.Location = New System.Drawing.Point(800, 0)
        Me.ButtonEsci.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.ButtonEsci.Size = New System.Drawing.Size(42, 40)
        Me.ButtonEsci.TabIndex = 9
        Me.ButtonEsci.Text = "esci"
        Me.ButtonEsci.UseVisualStyleBackColor = True
        '
        'FormGestioneRete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(842, 497)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormGestioneRete"
        Me.Text = "FormGestioneRete"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.dgvDati, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rbCip As System.Windows.Forms.RadioButton
    Friend WithEvents rbUtenze As System.Windows.Forms.RadioButton
    Friend WithEvents rbSoggetti As System.Windows.Forms.RadioButton
    Friend WithEvents rbPuntiVendita As System.Windows.Forms.RadioButton
    Friend WithEvents dgvDati As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonAggiornaListe As System.Windows.Forms.Button
    Friend WithEvents ButtonEsci As System.Windows.Forms.Button
End Class
