<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVersamentoSub
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
        Me.cboDest = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboOrigine = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTotale = New System.Windows.Forms.TextBox()
        Me.txtAssegni = New System.Windows.Forms.TextBox()
        Me.txtContanti = New System.Windows.Forms.TextBox()
        Me.cboTipoVersamento = New System.Windows.Forms.ComboBox()
        Me.btnSalva = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.34783!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.65217!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.cboDest, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboOrigine, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTotale, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.txtAssegni, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtContanti, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.cboTipoVersamento, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSalva, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 1)
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 7
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(475, 197)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'cboDest
        '
        Me.cboDest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboDest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDest.FormattingEnabled = True
        Me.cboDest.Location = New System.Drawing.Point(174, 59)
        Me.cboDest.Name = "cboDest"
        Me.cboDest.Size = New System.Drawing.Size(138, 22)
        Me.cboDest.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(165, 28)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Tipo versamento"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gold
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 3)
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(469, 28)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(165, 28)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "A favore di"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboOrigine
        '
        Me.cboOrigine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboOrigine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrigine.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOrigine.FormattingEnabled = True
        Me.cboOrigine.Location = New System.Drawing.Point(174, 31)
        Me.cboOrigine.Name = "cboOrigine"
        Me.cboOrigine.Size = New System.Drawing.Size(138, 22)
        Me.cboOrigine.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(165, 29)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Totale versamento"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(165, 28)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Assegni"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(165, 28)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Contanti"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotale
        '
        Me.txtTotale.BackColor = System.Drawing.Color.Yellow
        Me.txtTotale.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTotale.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotale.Location = New System.Drawing.Point(174, 171)
        Me.txtTotale.Name = "txtTotale"
        Me.txtTotale.Size = New System.Drawing.Size(138, 22)
        Me.txtTotale.TabIndex = 4
        Me.txtTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAssegni
        '
        Me.txtAssegni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtAssegni.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAssegni.Location = New System.Drawing.Point(174, 143)
        Me.txtAssegni.Name = "txtAssegni"
        Me.txtAssegni.Size = New System.Drawing.Size(138, 22)
        Me.txtAssegni.TabIndex = 3
        Me.txtAssegni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtContanti
        '
        Me.txtContanti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtContanti.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContanti.Location = New System.Drawing.Point(174, 115)
        Me.txtContanti.Name = "txtContanti"
        Me.txtContanti.Size = New System.Drawing.Size(138, 22)
        Me.txtContanti.TabIndex = 2
        Me.txtContanti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboTipoVersamento
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.cboTipoVersamento, 2)
        Me.cboTipoVersamento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboTipoVersamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoVersamento.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoVersamento.FormattingEnabled = True
        Me.cboTipoVersamento.Location = New System.Drawing.Point(174, 87)
        Me.cboTipoVersamento.Name = "cboTipoVersamento"
        Me.cboTipoVersamento.Size = New System.Drawing.Size(298, 22)
        Me.cboTipoVersamento.TabIndex = 1
        '
        'btnSalva
        '
        Me.btnSalva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSalva.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalva.Location = New System.Drawing.Point(318, 143)
        Me.btnSalva.Name = "btnSalva"
        Me.TableLayoutPanel1.SetRowSpan(Me.btnSalva, 2)
        Me.btnSalva.Size = New System.Drawing.Size(154, 51)
        Me.btnSalva.TabIndex = 5
        Me.btnSalva.Text = "Salva"
        Me.btnSalva.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(3, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(165, 28)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Versamento eseguito da"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmVersamentoSub
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 221)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmVersamentoSub"
        Me.Text = "VersamentoSub"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtContanti As System.Windows.Forms.TextBox
    Friend WithEvents txtAssegni As System.Windows.Forms.TextBox
    Friend WithEvents txtTotale As System.Windows.Forms.TextBox
    Friend WithEvents btnSalva As System.Windows.Forms.Button
    Friend WithEvents cboOrigine As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboTipoVersamento As System.Windows.Forms.ComboBox
    Friend WithEvents cboDest As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
