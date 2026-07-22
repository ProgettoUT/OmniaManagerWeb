<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCambioAgenzia
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
        Me.ListBoxAgenzie = New System.Windows.Forms.ListBox()
        Me.ButtonCambia = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListBoxAgenzie
        '
        Me.ListBoxAgenzie.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBoxAgenzie.FormattingEnabled = True
        Me.ListBoxAgenzie.Location = New System.Drawing.Point(0, 0)
        Me.ListBoxAgenzie.Margin = New System.Windows.Forms.Padding(0)
        Me.ListBoxAgenzie.Name = "ListBoxAgenzie"
        Me.ListBoxAgenzie.Size = New System.Drawing.Size(184, 221)
        Me.ListBoxAgenzie.TabIndex = 0
        '
        'ButtonCambia
        '
        Me.ButtonCambia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCambia.Location = New System.Drawing.Point(0, 221)
        Me.ButtonCambia.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonCambia.Name = "ButtonCambia"
        Me.ButtonCambia.Size = New System.Drawing.Size(184, 40)
        Me.ButtonCambia.TabIndex = 1
        Me.ButtonCambia.Text = "Button1"
        Me.ButtonCambia.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ListBoxAgenzie, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonCambia, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(184, 261)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'FormCambioAgenzia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(184, 261)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormCambioAgenzia"
        Me.Text = "FormCambioAgenzia"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBoxAgenzie As System.Windows.Forms.ListBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonCambia As System.Windows.Forms.Button
End Class
