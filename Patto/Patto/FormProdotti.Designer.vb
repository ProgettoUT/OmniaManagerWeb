<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProdotti
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
        Me.dgvProdotti = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonExcel = New System.Windows.Forms.Button()
        Me.ButtonEsci = New System.Windows.Forms.Button()
        Me.ButtonCliente = New System.Windows.Forms.Button()
        Me.ButtonDettaglio = New System.Windows.Forms.Button()
        Me.TabMain = New Utx.UtTabControl()
        Me.TabPageDati = New System.Windows.Forms.TabPage()
        Me.TabPageDoc = New System.Windows.Forms.TabPage()
        Me.ButtonIncassi = New System.Windows.Forms.Button()
        CType(Me.dgvProdotti, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.TabPageDati.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvProdotti
        '
        Me.dgvProdotti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel1.SetColumnSpan(Me.dgvProdotti, 5)
        Me.dgvProdotti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProdotti.Location = New System.Drawing.Point(3, 3)
        Me.dgvProdotti.Name = "dgvProdotti"
        Me.dgvProdotti.Size = New System.Drawing.Size(766, 380)
        Me.dgvProdotti.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonIncassi, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.dgvProdotti, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonExcel, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonEsci, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonCliente, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonDettaglio, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(772, 446)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'ButtonExcel
        '
        Me.ButtonExcel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonExcel.Location = New System.Drawing.Point(311, 389)
        Me.ButtonExcel.Name = "ButtonExcel"
        Me.ButtonExcel.Size = New System.Drawing.Size(148, 54)
        Me.ButtonExcel.TabIndex = 1
        Me.ButtonExcel.Text = "Button1"
        Me.ButtonExcel.UseVisualStyleBackColor = True
        '
        'ButtonEsci
        '
        Me.ButtonEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEsci.Location = New System.Drawing.Point(619, 389)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.ButtonEsci.Size = New System.Drawing.Size(150, 54)
        Me.ButtonEsci.TabIndex = 2
        Me.ButtonEsci.Text = "Button2"
        Me.ButtonEsci.UseVisualStyleBackColor = True
        '
        'ButtonCliente
        '
        Me.ButtonCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCliente.Location = New System.Drawing.Point(157, 389)
        Me.ButtonCliente.Name = "ButtonCliente"
        Me.ButtonCliente.Size = New System.Drawing.Size(148, 54)
        Me.ButtonCliente.TabIndex = 3
        Me.ButtonCliente.Text = "Button3"
        Me.ButtonCliente.UseVisualStyleBackColor = True
        '
        'ButtonDettaglio
        '
        Me.ButtonDettaglio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonDettaglio.Location = New System.Drawing.Point(3, 389)
        Me.ButtonDettaglio.Name = "ButtonDettaglio"
        Me.ButtonDettaglio.Size = New System.Drawing.Size(148, 54)
        Me.ButtonDettaglio.TabIndex = 4
        Me.ButtonDettaglio.Text = "Button4"
        Me.ButtonDettaglio.UseVisualStyleBackColor = True
        '
        'TabMain
        '
        Me.TabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabMain.ColorStyle = Utx.UtTabControl.TabColorStyle.TRASPARENT
        Me.TabMain.Controls.Add(Me.TabPageDati)
        Me.TabMain.Controls.Add(Me.TabPageDoc)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.ItemSize = New System.Drawing.Size(150, 25)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(786, 485)
        Me.TabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabMain.TabIndex = 2
        Me.TabMain.Visible = False
        '
        'TabPageDati
        '
        Me.TabPageDati.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPageDati.Location = New System.Drawing.Point(4, 29)
        Me.TabPageDati.Name = "TabPageDati"
        Me.TabPageDati.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDati.Size = New System.Drawing.Size(778, 452)
        Me.TabPageDati.TabIndex = 0
        Me.TabPageDati.Text = "TabPage1"
        Me.TabPageDati.UseVisualStyleBackColor = True
        '
        'TabPageDoc
        '
        Me.TabPageDoc.Location = New System.Drawing.Point(4, 29)
        Me.TabPageDoc.Name = "TabPageDoc"
        Me.TabPageDoc.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDoc.Size = New System.Drawing.Size(778, 452)
        Me.TabPageDoc.TabIndex = 1
        Me.TabPageDoc.Text = "Documentazione"
        Me.TabPageDoc.UseVisualStyleBackColor = True
        '
        'ButtonIncassi
        '
        Me.ButtonIncassi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonIncassi.Location = New System.Drawing.Point(465, 389)
        Me.ButtonIncassi.Name = "ButtonIncassi"
        Me.ButtonIncassi.Size = New System.Drawing.Size(148, 54)
        Me.ButtonIncassi.TabIndex = 5
        Me.ButtonIncassi.Text = "Button1"
        Me.ButtonIncassi.UseVisualStyleBackColor = True
        '
        'FormProdotti
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(786, 485)
        Me.Controls.Add(Me.TabMain)
        Me.Name = "FormProdotti"
        Me.Text = "FormProdotti"
        CType(Me.dgvProdotti, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TabMain.ResumeLayout(False)
        Me.TabPageDati.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvProdotti As System.Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonExcel As System.Windows.Forms.Button
    Friend WithEvents ButtonEsci As System.Windows.Forms.Button
    Friend WithEvents ButtonCliente As System.Windows.Forms.Button
    Friend WithEvents ButtonDettaglio As System.Windows.Forms.Button
    Friend WithEvents TabMain As Utx.UtTabControl
    Friend WithEvents TabPageDati As System.Windows.Forms.TabPage
    Friend WithEvents TabPageDoc As System.Windows.Forms.TabPage
    Friend WithEvents ButtonIncassi As Button
End Class
