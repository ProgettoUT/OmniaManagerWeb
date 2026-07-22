<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAttivazione
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
        Me.clbFigure = New System.Windows.Forms.CheckedListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnEsci = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabAttivazione = New System.Windows.Forms.TabPage()
        Me.TabGruppi = New System.Windows.Forms.TabPage()
        Me.txtDesk = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.clbFigureGruppi = New System.Windows.Forms.CheckedListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboGruppi = New System.Windows.Forms.ComboBox()
        Me.btnSalvaGruppo = New System.Windows.Forms.Button()
        Me.txtCodiceGruppo = New System.Windows.Forms.TextBox()
        Me.btnEliminaGruppo = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabAttivazione.SuspendLayout()
        Me.TabGruppi.SuspendLayout()
        Me.SuspendLayout()
        '
        'clbFigure
        '
        Me.clbFigure.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clbFigure.FormattingEnabled = True
        Me.clbFigure.IntegralHeight = False
        Me.clbFigure.Location = New System.Drawing.Point(6, 40)
        Me.clbFigure.Name = "clbFigure"
        Me.clbFigure.Size = New System.Drawing.Size(345, 361)
        Me.clbFigure.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(345, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Label2"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnEsci
        '
        Me.btnEsci.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEsci.Location = New System.Drawing.Point(6, 451)
        Me.btnEsci.Name = "btnEsci"
        Me.btnEsci.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.btnEsci.Size = New System.Drawing.Size(365, 29)
        Me.btnEsci.TabIndex = 1
        Me.btnEsci.Text = "Esci"
        Me.btnEsci.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEsci.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabAttivazione)
        Me.TabControl1.Controls.Add(Me.TabGruppi)
        Me.TabControl1.Location = New System.Drawing.Point(6, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(365, 433)
        Me.TabControl1.TabIndex = 1
        '
        'TabAttivazione
        '
        Me.TabAttivazione.Controls.Add(Me.clbFigure)
        Me.TabAttivazione.Controls.Add(Me.Label1)
        Me.TabAttivazione.Location = New System.Drawing.Point(4, 22)
        Me.TabAttivazione.Name = "TabAttivazione"
        Me.TabAttivazione.Padding = New System.Windows.Forms.Padding(3)
        Me.TabAttivazione.Size = New System.Drawing.Size(357, 407)
        Me.TabAttivazione.TabIndex = 0
        Me.TabAttivazione.Text = "Attivazione figure"
        Me.TabAttivazione.UseVisualStyleBackColor = True
        '
        'TabGruppi
        '
        Me.TabGruppi.Controls.Add(Me.txtDesk)
        Me.TabGruppi.Controls.Add(Me.Label3)
        Me.TabGruppi.Controls.Add(Me.clbFigureGruppi)
        Me.TabGruppi.Controls.Add(Me.Label2)
        Me.TabGruppi.Controls.Add(Me.cboGruppi)
        Me.TabGruppi.Controls.Add(Me.btnSalvaGruppo)
        Me.TabGruppi.Controls.Add(Me.txtCodiceGruppo)
        Me.TabGruppi.Controls.Add(Me.btnEliminaGruppo)
        Me.TabGruppi.Location = New System.Drawing.Point(4, 22)
        Me.TabGruppi.Name = "TabGruppi"
        Me.TabGruppi.Padding = New System.Windows.Forms.Padding(3)
        Me.TabGruppi.Size = New System.Drawing.Size(357, 407)
        Me.TabGruppi.TabIndex = 1
        Me.TabGruppi.Text = "Gestione gruppi"
        Me.TabGruppi.UseVisualStyleBackColor = True
        '
        'txtDesk
        '
        Me.txtDesk.Location = New System.Drawing.Point(117, 381)
        Me.txtDesk.MaxLength = 20
        Me.txtDesk.Name = "txtDesk"
        Me.txtDesk.Size = New System.Drawing.Size(139, 20)
        Me.txtDesk.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 384)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Descrizione gruppo"
        '
        'clbFigureGruppi
        '
        Me.clbFigureGruppi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clbFigureGruppi.FormattingEnabled = True
        Me.clbFigureGruppi.IntegralHeight = False
        Me.clbFigureGruppi.Location = New System.Drawing.Point(6, 33)
        Me.clbFigureGruppi.Name = "clbFigureGruppi"
        Me.clbFigureGruppi.Size = New System.Drawing.Size(341, 315)
        Me.clbFigureGruppi.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 358)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Codice da attribuire al gruppo"
        '
        'cboGruppi
        '
        Me.cboGruppi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGruppi.FormattingEnabled = True
        Me.cboGruppi.Location = New System.Drawing.Point(6, 6)
        Me.cboGruppi.Name = "cboGruppi"
        Me.cboGruppi.Size = New System.Drawing.Size(250, 21)
        Me.cboGruppi.TabIndex = 1
        '
        'btnSalvaGruppo
        '
        Me.btnSalvaGruppo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalvaGruppo.Location = New System.Drawing.Point(262, 354)
        Me.btnSalvaGruppo.Name = "btnSalvaGruppo"
        Me.btnSalvaGruppo.Size = New System.Drawing.Size(85, 50)
        Me.btnSalvaGruppo.TabIndex = 6
        Me.btnSalvaGruppo.Text = "Salva gruppo"
        Me.btnSalvaGruppo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalvaGruppo.UseVisualStyleBackColor = True
        '
        'txtCodiceGruppo
        '
        Me.txtCodiceGruppo.Location = New System.Drawing.Point(168, 355)
        Me.txtCodiceGruppo.Name = "txtCodiceGruppo"
        Me.txtCodiceGruppo.Size = New System.Drawing.Size(88, 20)
        Me.txtCodiceGruppo.TabIndex = 4
        Me.txtCodiceGruppo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnEliminaGruppo
        '
        Me.btnEliminaGruppo.Location = New System.Drawing.Point(262, 6)
        Me.btnEliminaGruppo.Name = "btnEliminaGruppo"
        Me.btnEliminaGruppo.Size = New System.Drawing.Size(85, 21)
        Me.btnEliminaGruppo.TabIndex = 2
        Me.btnEliminaGruppo.Text = "Elimina"
        Me.btnEliminaGruppo.UseVisualStyleBackColor = True
        '
        'frmAttivazione
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 487)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnEsci)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAttivazione"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Gruppi"
        Me.TabControl1.ResumeLayout(False)
        Me.TabAttivazione.ResumeLayout(False)
        Me.TabGruppi.ResumeLayout(False)
        Me.TabGruppi.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents clbFigure As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnEsci As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabAttivazione As System.Windows.Forms.TabPage
    Friend WithEvents TabGruppi As System.Windows.Forms.TabPage
    Friend WithEvents clbFigureGruppi As System.Windows.Forms.CheckedListBox
    Friend WithEvents cboGruppi As System.Windows.Forms.ComboBox
    Friend WithEvents btnEliminaGruppo As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSalvaGruppo As System.Windows.Forms.Button
    Friend WithEvents txtCodiceGruppo As System.Windows.Forms.TextBox
    Friend WithEvents txtDesk As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
