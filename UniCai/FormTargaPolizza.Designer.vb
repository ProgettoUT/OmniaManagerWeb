<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTargaPolizza
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtTarga = New System.Windows.Forms.TextBox()
        Me.txtRamo = New System.Windows.Forms.TextBox()
        Me.txtPolizza = New System.Windows.Forms.TextBox()
        Me.lblTarga = New System.Windows.Forms.Label()
        Me.lblRamo = New System.Windows.Forms.Label()
        Me.lblPolizza = New System.Windows.Forms.Label()
        Me.ButtonCerca = New UtControls.UtFlatButton()
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelTitolo = New System.Windows.Forms.Label()
        Me.ButtonClose = New UtControls.UtFlatButton()
        Me.tableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTarga
        '
        Me.txtTarga.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tableLayoutPanel1.SetColumnSpan(Me.txtTarga, 3)
        Me.txtTarga.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTarga.Location = New System.Drawing.Point(53, 48)
        Me.txtTarga.Name = "txtTarga"
        Me.txtTarga.Size = New System.Drawing.Size(212, 13)
        Me.txtTarga.TabIndex = 0
        Me.txtTarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRamo
        '
        Me.txtRamo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRamo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRamo.Location = New System.Drawing.Point(53, 74)
        Me.txtRamo.Name = "txtRamo"
        Me.txtRamo.Size = New System.Drawing.Size(44, 13)
        Me.txtRamo.TabIndex = 1
        Me.txtRamo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPolizza
        '
        Me.txtPolizza.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPolizza.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPolizza.Location = New System.Drawing.Point(153, 74)
        Me.txtPolizza.Name = "txtPolizza"
        Me.txtPolizza.Size = New System.Drawing.Size(112, 13)
        Me.txtPolizza.TabIndex = 2
        Me.txtPolizza.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTarga
        '
        Me.lblTarga.AutoSize = True
        Me.lblTarga.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTarga.Location = New System.Drawing.Point(3, 45)
        Me.lblTarga.Name = "lblTarga"
        Me.lblTarga.Size = New System.Drawing.Size(44, 26)
        Me.lblTarga.TabIndex = 3
        Me.lblTarga.Text = "Targa"
        Me.lblTarga.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRamo
        '
        Me.lblRamo.AutoSize = True
        Me.lblRamo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRamo.Location = New System.Drawing.Point(3, 71)
        Me.lblRamo.Name = "lblRamo"
        Me.lblRamo.Size = New System.Drawing.Size(44, 26)
        Me.lblRamo.TabIndex = 4
        Me.lblRamo.Text = "Ramo"
        Me.lblRamo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPolizza
        '
        Me.lblPolizza.AutoSize = True
        Me.lblPolizza.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPolizza.Location = New System.Drawing.Point(103, 71)
        Me.lblPolizza.Name = "lblPolizza"
        Me.lblPolizza.Size = New System.Drawing.Size(44, 26)
        Me.lblPolizza.TabIndex = 5
        Me.lblPolizza.Text = "Polizza"
        Me.lblPolizza.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ButtonCerca
        '
        Me.tableLayoutPanel1.SetColumnSpan(Me.ButtonCerca, 5)
        Me.ButtonCerca.DefaultBorderSize = 0
        Me.ButtonCerca.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCerca.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonCerca.FlatAppearance.BorderSize = 0
        Me.ButtonCerca.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonCerca.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ButtonCerca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCerca.Location = New System.Drawing.Point(0, 108)
        Me.ButtonCerca.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonCerca.Name = "ButtonCerca"
        Me.ButtonCerca.Size = New System.Drawing.Size(288, 40)
        Me.ButtonCerca.TabIndex = 6
        Me.ButtonCerca.Text = "Cerca per targa o per polizza"
        Me.ButtonCerca.UseVisualStyleBackColor = True
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.ColumnCount = 5
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tableLayoutPanel1.Controls.Add(Me.txtPolizza, 3, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.lblTarga, 0, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.lblRamo, 0, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.txtRamo, 1, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.txtTarga, 1, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.lblPolizza, 2, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.ButtonCerca, 0, 5)
        Me.tableLayoutPanel1.Controls.Add(Me.LabelTitolo, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.ButtonClose, 4, 0)
        Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 6
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(288, 148)
        Me.tableLayoutPanel1.TabIndex = 7
        '
        'LabelTitolo
        '
        Me.LabelTitolo.AutoSize = True
        Me.LabelTitolo.BackColor = System.Drawing.Color.LightSkyBlue
        Me.tableLayoutPanel1.SetColumnSpan(Me.LabelTitolo, 4)
        Me.LabelTitolo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelTitolo.Location = New System.Drawing.Point(0, 0)
        Me.LabelTitolo.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelTitolo.Name = "LabelTitolo"
        Me.LabelTitolo.Size = New System.Drawing.Size(268, 25)
        Me.LabelTitolo.TabIndex = 7
        Me.LabelTitolo.Text = "Compilazione CAI"
        Me.LabelTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonClose
        '
        Me.ButtonClose.BackColor = System.Drawing.Color.SkyBlue
        Me.ButtonClose.DefaultBorderSize = 0
        Me.ButtonClose.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonClose.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonClose.FlatAppearance.BorderSize = 0
        Me.ButtonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClose.Location = New System.Drawing.Point(268, 0)
        Me.ButtonClose.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(20, 25)
        Me.ButtonClose.TabIndex = 8
        Me.ButtonClose.Text = "X"
        Me.ButtonClose.UseVisualStyleBackColor = False
        '
        'FormTargaPolizza
        '
        Me.AcceptButton = Me.ButtonCerca
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(288, 148)
        Me.ControlBox = False
        Me.Controls.Add(Me.tableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormTargaPolizza"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.tableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtTarga As System.Windows.Forms.TextBox
    Friend WithEvents txtRamo As System.Windows.Forms.TextBox
    Friend WithEvents txtPolizza As System.Windows.Forms.TextBox
    Friend WithEvents lblTarga As System.Windows.Forms.Label
    Friend WithEvents lblRamo As System.Windows.Forms.Label
    Friend WithEvents lblPolizza As System.Windows.Forms.Label
    Friend WithEvents ButtonCerca As UtControls.UtFlatButton
    Friend WithEvents tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelTitolo As System.Windows.Forms.Label
    Friend WithEvents ButtonClose As UtControls.UtFlatButton
End Class
