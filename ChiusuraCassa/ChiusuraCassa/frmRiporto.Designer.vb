<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRiporto
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
        Me.txtDesk = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTotale = New System.Windows.Forms.TextBox()
        Me.txtAssegni = New System.Windows.Forms.TextBox()
        Me.txtContanti = New System.Windows.Forms.TextBox()
        Me.btnSalva = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboSezione = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboPv = New System.Windows.Forms.ComboBox()
        Me.cboCassa = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.63107!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.36893!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 178.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.txtDesk, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtTotale, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.txtAssegni, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.txtContanti, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSalva, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cboSezione, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboPv, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.cboCassa, 1, 3)
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(8, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(469, 216)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'txtDesk
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtDesk, 2)
        Me.txtDesk.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtDesk.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesk.Location = New System.Drawing.Point(135, 111)
        Me.txtDesk.MaxLength = 40
        Me.txtDesk.Name = "txtDesk"
        Me.txtDesk.Size = New System.Drawing.Size(331, 22)
        Me.txtDesk.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(126, 27)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Descrizione"
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
        Me.Label1.Size = New System.Drawing.Size(463, 27)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 189)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(126, 27)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Totale versamento"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(126, 27)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Assegni"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 27)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Contanti"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotale
        '
        Me.txtTotale.BackColor = System.Drawing.Color.Yellow
        Me.txtTotale.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtTotale.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotale.Location = New System.Drawing.Point(135, 192)
        Me.txtTotale.Name = "txtTotale"
        Me.txtTotale.Size = New System.Drawing.Size(152, 22)
        Me.txtTotale.TabIndex = 4
        Me.txtTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAssegni
        '
        Me.txtAssegni.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtAssegni.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAssegni.Location = New System.Drawing.Point(135, 165)
        Me.txtAssegni.Name = "txtAssegni"
        Me.txtAssegni.Size = New System.Drawing.Size(152, 22)
        Me.txtAssegni.TabIndex = 3
        Me.txtAssegni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtContanti
        '
        Me.txtContanti.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtContanti.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContanti.Location = New System.Drawing.Point(135, 138)
        Me.txtContanti.Name = "txtContanti"
        Me.txtContanti.Size = New System.Drawing.Size(152, 22)
        Me.txtContanti.TabIndex = 2
        Me.txtContanti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSalva
        '
        Me.btnSalva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSalva.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalva.Location = New System.Drawing.Point(293, 165)
        Me.btnSalva.Name = "btnSalva"
        Me.TableLayoutPanel1.SetRowSpan(Me.btnSalva, 2)
        Me.btnSalva.Size = New System.Drawing.Size(173, 48)
        Me.btnSalva.TabIndex = 5
        Me.btnSalva.Text = "Salva"
        Me.btnSalva.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 27)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Sezione"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboSezione
        '
        Me.cboSezione.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboSezione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSezione.DropDownWidth = 162
        Me.cboSezione.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSezione.FormattingEnabled = True
        Me.cboSezione.Location = New System.Drawing.Point(135, 30)
        Me.cboSezione.Name = "cboSezione"
        Me.cboSezione.Size = New System.Drawing.Size(152, 22)
        Me.cboSezione.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Location = New System.Drawing.Point(3, 81)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(126, 27)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Cassa"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(3, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(126, 27)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Punto vendita"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboPv
        '
        Me.cboPv.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboPv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPv.FormattingEnabled = True
        Me.cboPv.Location = New System.Drawing.Point(135, 57)
        Me.cboPv.Name = "cboPv"
        Me.cboPv.Size = New System.Drawing.Size(152, 22)
        Me.cboPv.TabIndex = 9
        '
        'cboCassa
        '
        Me.cboCassa.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboCassa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCassa.FormattingEnabled = True
        Me.cboCassa.Location = New System.Drawing.Point(135, 84)
        Me.cboCassa.Name = "cboCassa"
        Me.cboCassa.Size = New System.Drawing.Size(152, 22)
        Me.cboCassa.TabIndex = 8
        '
        'frmRiporto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 239)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmRiporto"
        Me.Text = "frmRiporto"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboSezione As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTotale As System.Windows.Forms.TextBox
    Friend WithEvents txtAssegni As System.Windows.Forms.TextBox
    Friend WithEvents txtContanti As System.Windows.Forms.TextBox
    Friend WithEvents btnSalva As System.Windows.Forms.Button
    Friend WithEvents txtDesk As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboPv As System.Windows.Forms.ComboBox
    Friend WithEvents cboCassa As System.Windows.Forms.ComboBox
End Class
