<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCodiciSub
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
        Me.lstCodiciPrincipali = New System.Windows.Forms.ListBox()
        Me.lstCodiciLegati = New System.Windows.Forms.CheckedListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnEliminaPuntoVendita = New System.Windows.Forms.Button()
        Me.btnAggiungiPuntoVendita = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCodicePV = New System.Windows.Forms.TextBox()
        Me.txtDescrizionePV = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCodiceEssig = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstCodiciPrincipali
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.lstCodiciPrincipali, 4)
        Me.lstCodiciPrincipali.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstCodiciPrincipali.FormattingEnabled = True
        Me.lstCodiciPrincipali.IntegralHeight = False
        Me.lstCodiciPrincipali.ItemHeight = 14
        Me.lstCodiciPrincipali.Location = New System.Drawing.Point(3, 23)
        Me.lstCodiciPrincipali.Name = "lstCodiciPrincipali"
        Me.lstCodiciPrincipali.Size = New System.Drawing.Size(250, 244)
        Me.lstCodiciPrincipali.TabIndex = 0
        '
        'lstCodiciLegati
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.lstCodiciLegati, 4)
        Me.lstCodiciLegati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstCodiciLegati.FormattingEnabled = True
        Me.lstCodiciLegati.IntegralHeight = False
        Me.lstCodiciLegati.Location = New System.Drawing.Point(259, 23)
        Me.lstCodiciLegati.Name = "lstCodiciLegati"
        Me.lstCodiciLegati.Size = New System.Drawing.Size(255, 244)
        Me.lstCodiciLegati.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Gold
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 4)
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(250, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Punti vendita"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Gold
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label2, 4)
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(259, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(255, 20)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Codici cassa collegati"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 8
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lstCodiciLegati, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lstCodiciPrincipali, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnEliminaPuntoVendita, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAggiungiPuntoVendita, 6, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCodicePV, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDescrizionePV, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.txtCodiceEssig, 5, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(517, 386)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'btnEliminaPuntoVendita
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.btnEliminaPuntoVendita, 8)
        Me.btnEliminaPuntoVendita.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnEliminaPuntoVendita.Location = New System.Drawing.Point(3, 273)
        Me.btnEliminaPuntoVendita.Name = "btnEliminaPuntoVendita"
        Me.btnEliminaPuntoVendita.Size = New System.Drawing.Size(511, 30)
        Me.btnEliminaPuntoVendita.TabIndex = 5
        Me.btnEliminaPuntoVendita.TabStop = False
        Me.btnEliminaPuntoVendita.Text = "Elimina il punto vendita selezionato"
        Me.btnEliminaPuntoVendita.UseVisualStyleBackColor = True
        '
        'btnAggiungiPuntoVendita
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.btnAggiungiPuntoVendita, 2)
        Me.btnAggiungiPuntoVendita.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAggiungiPuntoVendita.Location = New System.Drawing.Point(387, 329)
        Me.btnAggiungiPuntoVendita.Name = "btnAggiungiPuntoVendita"
        Me.TableLayoutPanel1.SetRowSpan(Me.btnAggiungiPuntoVendita, 2)
        Me.btnAggiungiPuntoVendita.Size = New System.Drawing.Size(127, 54)
        Me.btnAggiungiPuntoVendita.TabIndex = 5
        Me.btnAggiungiPuntoVendita.Text = "Aggiungi punto vendita"
        Me.btnAggiungiPuntoVendita.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label3, 2)
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 326)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 30)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Codice"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label4, 2)
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(3, 356)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 30)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Descrizione"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCodicePV
        '
        Me.txtCodicePV.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtCodicePV.Location = New System.Drawing.Point(131, 329)
        Me.txtCodicePV.Name = "txtCodicePV"
        Me.txtCodicePV.Size = New System.Drawing.Size(58, 22)
        Me.txtCodicePV.TabIndex = 2
        Me.txtCodicePV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDescrizionePV
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.txtDescrizionePV, 4)
        Me.txtDescrizionePV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescrizionePV.Location = New System.Drawing.Point(131, 359)
        Me.txtDescrizionePV.MaxLength = 50
        Me.txtDescrizionePV.Name = "txtDescrizionePV"
        Me.txtDescrizionePV.Size = New System.Drawing.Size(250, 22)
        Me.txtDescrizionePV.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Gold
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label5, 8)
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 306)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(511, 20)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Definisci nuovi punti vendita"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label6, 2)
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Location = New System.Drawing.Point(195, 326)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 30)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Codice Essig reti"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCodiceEssig
        '
        Me.txtCodiceEssig.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCodiceEssig.Location = New System.Drawing.Point(323, 329)
        Me.txtCodiceEssig.Name = "txtCodiceEssig"
        Me.txtCodiceEssig.Size = New System.Drawing.Size(58, 22)
        Me.txtCodiceEssig.TabIndex = 3
        Me.txtCodiceEssig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmCodiciSub
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(523, 392)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmCodiciSub"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.Text = "frmCodiciSub"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstCodiciPrincipali As System.Windows.Forms.ListBox
    Friend WithEvents lstCodiciLegati As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnEliminaPuntoVendita As System.Windows.Forms.Button
    Friend WithEvents btnAggiungiPuntoVendita As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCodicePV As System.Windows.Forms.TextBox
    Friend WithEvents txtDescrizionePV As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCodiceEssig As System.Windows.Forms.TextBox
End Class
