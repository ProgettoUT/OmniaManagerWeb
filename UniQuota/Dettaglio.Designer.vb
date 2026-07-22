<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dettaglio
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Me.txtDettaglio = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.cmdStampa = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtDettaglio
        '
        Me.txtDettaglio.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtDettaglio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDettaglio.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDettaglio.Location = New System.Drawing.Point(3, 3)
        Me.txtDettaglio.Multiline = True
        Me.txtDettaglio.Name = "txtDettaglio"
        Me.txtDettaglio.ReadOnly = True
        Me.txtDettaglio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDettaglio.Size = New System.Drawing.Size(1102, 585)
        Me.txtDettaglio.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtDettaglio, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmdStampa, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1108, 641)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'cmdStampa
        '
        Me.cmdStampa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdStampa.Location = New System.Drawing.Point(3, 594)
        Me.cmdStampa.Name = "cmdStampa"
        Me.cmdStampa.Size = New System.Drawing.Size(1102, 44)
        Me.cmdStampa.TabIndex = 1
        Me.cmdStampa.Text = "Stampa"
        Me.cmdStampa.UseVisualStyleBackColor = True
        '
        'Dettaglio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1108, 641)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Dettaglio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dettaglio"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtDettaglio As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmdStampa As System.Windows.Forms.Button
End Class
