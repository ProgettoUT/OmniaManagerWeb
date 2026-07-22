<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormScannerRete
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormScannerRete))
        Me.ListBoxDocRete = New System.Windows.Forms.ListBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.AxAcroPDF1 = New AxAcroPDFLib.AxAcroPDF()
        Me.btnEsci = New System.Windows.Forms.Button()
        Me.btnImporta = New System.Windows.Forms.Button()
        Me.btnAggiorna = New System.Windows.Forms.Button()
        Me.ButtonSposta = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListBoxDocRete
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ListBoxDocRete, 2)
        Me.ListBoxDocRete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBoxDocRete.FormattingEnabled = True
        Me.ListBoxDocRete.IntegralHeight = False
        Me.ListBoxDocRete.ItemHeight = 14
        Me.ListBoxDocRete.Location = New System.Drawing.Point(3, 3)
        Me.ListBoxDocRete.Name = "ListBoxDocRete"
        Me.ListBoxDocRete.Size = New System.Drawing.Size(304, 377)
        Me.ListBoxDocRete.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.AxAcroPDF1, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ListBoxDocRete, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnEsci, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnImporta, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAggiorna, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonSposta, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.79443!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.20557!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(620, 437)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'AxAcroPDF1
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.AxAcroPDF1, 2)
        Me.AxAcroPDF1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AxAcroPDF1.Enabled = True
        Me.AxAcroPDF1.Location = New System.Drawing.Point(313, 3)
        Me.AxAcroPDF1.Name = "AxAcroPDF1"
        Me.AxAcroPDF1.OcxState = CType(resources.GetObject("AxAcroPDF1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF1.Size = New System.Drawing.Size(304, 377)
        Me.AxAcroPDF1.TabIndex = 3
        '
        'btnEsci
        '
        Me.btnEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnEsci.Location = New System.Drawing.Point(465, 383)
        Me.btnEsci.Margin = New System.Windows.Forms.Padding(0)
        Me.btnEsci.Name = "btnEsci"
        Me.btnEsci.Size = New System.Drawing.Size(155, 54)
        Me.btnEsci.TabIndex = 1
        Me.btnEsci.Text = "Button1"
        Me.btnEsci.UseVisualStyleBackColor = True
        '
        'btnImporta
        '
        Me.btnImporta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnImporta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImporta.Location = New System.Drawing.Point(0, 383)
        Me.btnImporta.Margin = New System.Windows.Forms.Padding(0)
        Me.btnImporta.Name = "btnImporta"
        Me.btnImporta.Size = New System.Drawing.Size(217, 54)
        Me.btnImporta.TabIndex = 2
        Me.btnImporta.Text = "Button2"
        Me.btnImporta.UseVisualStyleBackColor = True
        '
        'btnAggiorna
        '
        Me.btnAggiorna.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAggiorna.Location = New System.Drawing.Point(310, 383)
        Me.btnAggiorna.Margin = New System.Windows.Forms.Padding(0)
        Me.btnAggiorna.Name = "btnAggiorna"
        Me.btnAggiorna.Size = New System.Drawing.Size(155, 54)
        Me.btnAggiorna.TabIndex = 4
        Me.btnAggiorna.Text = "Button1"
        Me.btnAggiorna.UseVisualStyleBackColor = True
        '
        'ButtonSposta
        '
        Me.ButtonSposta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSposta.Location = New System.Drawing.Point(217, 383)
        Me.ButtonSposta.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonSposta.Name = "ButtonSposta"
        Me.ButtonSposta.Size = New System.Drawing.Size(93, 54)
        Me.ButtonSposta.TabIndex = 5
        Me.ButtonSposta.Text = "Button1"
        Me.ButtonSposta.UseVisualStyleBackColor = True
        '
        'FormScannerRete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 437)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FormScannerRete"
        Me.Text = "FormScannerRete"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBoxDocRete As System.Windows.Forms.ListBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnEsci As System.Windows.Forms.Button
    Friend WithEvents btnImporta As System.Windows.Forms.Button
    Friend WithEvents AxAcroPDF1 As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents btnAggiorna As System.Windows.Forms.Button
    Friend WithEvents ButtonSposta As System.Windows.Forms.Button
End Class
