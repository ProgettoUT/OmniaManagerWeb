<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormReferenti
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
        Me.TextBoxAgenzia = New System.Windows.Forms.TextBox()
        Me.ButtonCerca = New System.Windows.Forms.Button()
        Me.tvReferenti = New System.Windows.Forms.TreeView()
        Me.ButtonEsci = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabMain = New Utx.UtTabControl()
        Me.TabPageReferenti = New System.Windows.Forms.TabPage()
        Me.TabPageLiquidatori = New System.Windows.Forms.TabPage()
        Me.dgvLiquidatori = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabMain.SuspendLayout()
        Me.TabPageReferenti.SuspendLayout()
        Me.TabPageLiquidatori.SuspendLayout()
        CType(Me.dgvLiquidatori, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxAgenzia, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonCerca, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tvReferenti, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonEsci, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(516, 380)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TextBoxAgenzia
        '
        Me.TextBoxAgenzia.Dock = System.Windows.Forms.DockStyle.Top
        Me.TextBoxAgenzia.Location = New System.Drawing.Point(3, 28)
        Me.TextBoxAgenzia.Name = "TextBoxAgenzia"
        Me.TextBoxAgenzia.Size = New System.Drawing.Size(114, 20)
        Me.TextBoxAgenzia.TabIndex = 0
        '
        'ButtonCerca
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonCerca, 2)
        Me.ButtonCerca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCerca.Location = New System.Drawing.Point(123, 3)
        Me.ButtonCerca.Name = "ButtonCerca"
        Me.TableLayoutPanel1.SetRowSpan(Me.ButtonCerca, 2)
        Me.ButtonCerca.Size = New System.Drawing.Size(290, 44)
        Me.ButtonCerca.TabIndex = 1
        Me.ButtonCerca.Text = "Button1"
        Me.ButtonCerca.UseVisualStyleBackColor = True
        '
        'tvReferenti
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.tvReferenti, 4)
        Me.tvReferenti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvReferenti.Location = New System.Drawing.Point(3, 53)
        Me.tvReferenti.Name = "tvReferenti"
        Me.tvReferenti.Size = New System.Drawing.Size(510, 324)
        Me.tvReferenti.TabIndex = 2
        '
        'ButtonEsci
        '
        Me.ButtonEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEsci.Location = New System.Drawing.Point(419, 3)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.TableLayoutPanel1.SetRowSpan(Me.ButtonEsci, 2)
        Me.ButtonEsci.Size = New System.Drawing.Size(94, 44)
        Me.ButtonEsci.TabIndex = 3
        Me.ButtonEsci.Text = "Button1"
        Me.ButtonEsci.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 25)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Codice agenzia"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabMain
        '
        Me.TabMain.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabMain.ColorStyle = Utx.UtTabControl.TabColorStyle.TRASPARENT
        Me.TabMain.Controls.Add(Me.TabPageReferenti)
        Me.TabMain.Controls.Add(Me.TabPageLiquidatori)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.ItemSize = New System.Drawing.Size(150, 25)
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(530, 419)
        Me.TabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabMain.TabIndex = 1
        Me.TabMain.Visible = False
        '
        'TabPageReferenti
        '
        Me.TabPageReferenti.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPageReferenti.Location = New System.Drawing.Point(4, 29)
        Me.TabPageReferenti.Name = "TabPageReferenti"
        Me.TabPageReferenti.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageReferenti.Size = New System.Drawing.Size(522, 386)
        Me.TabPageReferenti.TabIndex = 0
        Me.TabPageReferenti.Text = "Referenti"
        Me.TabPageReferenti.UseVisualStyleBackColor = True
        '
        'TabPageLiquidatori
        '
        Me.TabPageLiquidatori.Controls.Add(Me.dgvLiquidatori)
        Me.TabPageLiquidatori.Location = New System.Drawing.Point(4, 29)
        Me.TabPageLiquidatori.Name = "TabPageLiquidatori"
        Me.TabPageLiquidatori.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageLiquidatori.Size = New System.Drawing.Size(522, 386)
        Me.TabPageLiquidatori.TabIndex = 1
        Me.TabPageLiquidatori.Text = "Liquidatori"
        Me.TabPageLiquidatori.UseVisualStyleBackColor = True
        '
        'dgvLiquidatori
        '
        Me.dgvLiquidatori.AllowUserToAddRows = False
        Me.dgvLiquidatori.AllowUserToDeleteRows = False
        Me.dgvLiquidatori.AllowUserToResizeRows = False
        Me.dgvLiquidatori.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvLiquidatori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLiquidatori.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLiquidatori.Location = New System.Drawing.Point(3, 3)
        Me.dgvLiquidatori.Name = "dgvLiquidatori"
        Me.dgvLiquidatori.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLiquidatori.Size = New System.Drawing.Size(516, 380)
        Me.dgvLiquidatori.TabIndex = 0
        '
        'FormReferenti
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 419)
        Me.Controls.Add(Me.TabMain)
        Me.Name = "FormReferenti"
        Me.Text = "Form1"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TabMain.ResumeLayout(False)
        Me.TabPageReferenti.ResumeLayout(False)
        Me.TabPageLiquidatori.ResumeLayout(False)
        CType(Me.dgvLiquidatori, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TextBoxAgenzia As System.Windows.Forms.TextBox
    Friend WithEvents ButtonCerca As System.Windows.Forms.Button
    Friend WithEvents tvReferenti As System.Windows.Forms.TreeView
    Friend WithEvents ButtonEsci As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabMain As Utx.UtTabControl
    Friend WithEvents TabPageReferenti As TabPage
    Friend WithEvents TabPageLiquidatori As TabPage
    Friend WithEvents dgvLiquidatori As DataGridView
End Class
