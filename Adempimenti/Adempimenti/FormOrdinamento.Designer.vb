<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormOrdinamento
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
        Me.ListBoxColonne = New System.Windows.Forms.ListBox()
        Me.ListBoxOrdinamento = New System.Windows.Forms.ListBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonAggiungiDecrescente = New System.Windows.Forms.Button()
        Me.ButtonAggiungiCrescente = New System.Windows.Forms.Button()
        Me.ButtonCancella = New System.Windows.Forms.Button()
        Me.LabelColonne = New System.Windows.Forms.Label()
        Me.LabelOrdinamento = New System.Windows.Forms.Label()
        Me.ButtonOk = New System.Windows.Forms.Button()
        Me.ButtonCancellaTutto = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListBoxColonne
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ListBoxColonne, 2)
        Me.ListBoxColonne.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBoxColonne.FormattingEnabled = True
        Me.ListBoxColonne.Location = New System.Drawing.Point(0, 20)
        Me.ListBoxColonne.Margin = New System.Windows.Forms.Padding(0)
        Me.ListBoxColonne.Name = "ListBoxColonne"
        Me.ListBoxColonne.Size = New System.Drawing.Size(262, 302)
        Me.ListBoxColonne.TabIndex = 0
        '
        'ListBoxOrdinamento
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ListBoxOrdinamento, 2)
        Me.ListBoxOrdinamento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBoxOrdinamento.FormattingEnabled = True
        Me.ListBoxOrdinamento.Location = New System.Drawing.Point(262, 20)
        Me.ListBoxOrdinamento.Margin = New System.Windows.Forms.Padding(0)
        Me.ListBoxOrdinamento.Name = "ListBoxOrdinamento"
        Me.ListBoxOrdinamento.Size = New System.Drawing.Size(262, 302)
        Me.ListBoxOrdinamento.TabIndex = 1
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAggiungiDecrescente, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ListBoxColonne, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ListBoxOrdinamento, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAggiungiCrescente, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonCancella, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelColonne, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelOrdinamento, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonOk, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonCancellaTutto, 2, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(524, 372)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'ButtonAggiungiDecrescente
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonAggiungiDecrescente, 2)
        Me.ButtonAggiungiDecrescente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAggiungiDecrescente.FlatAppearance.BorderSize = 0
        Me.ButtonAggiungiDecrescente.Location = New System.Drawing.Point(0, 347)
        Me.ButtonAggiungiDecrescente.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonAggiungiDecrescente.Name = "ButtonAggiungiDecrescente"
        Me.ButtonAggiungiDecrescente.Size = New System.Drawing.Size(262, 25)
        Me.ButtonAggiungiDecrescente.TabIndex = 7
        Me.ButtonAggiungiDecrescente.Text = "Button1"
        Me.ButtonAggiungiDecrescente.UseVisualStyleBackColor = True
        '
        'ButtonAggiungiCrescente
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonAggiungiCrescente, 2)
        Me.ButtonAggiungiCrescente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAggiungiCrescente.FlatAppearance.BorderSize = 0
        Me.ButtonAggiungiCrescente.Location = New System.Drawing.Point(0, 322)
        Me.ButtonAggiungiCrescente.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonAggiungiCrescente.Name = "ButtonAggiungiCrescente"
        Me.ButtonAggiungiCrescente.Size = New System.Drawing.Size(262, 25)
        Me.ButtonAggiungiCrescente.TabIndex = 2
        Me.ButtonAggiungiCrescente.Text = "Button1"
        Me.ButtonAggiungiCrescente.UseVisualStyleBackColor = True
        '
        'ButtonCancella
        '
        Me.ButtonCancella.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCancella.FlatAppearance.BorderSize = 0
        Me.ButtonCancella.Location = New System.Drawing.Point(262, 322)
        Me.ButtonCancella.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonCancella.Name = "ButtonCancella"
        Me.ButtonCancella.Size = New System.Drawing.Size(131, 25)
        Me.ButtonCancella.TabIndex = 3
        Me.ButtonCancella.Text = "Button2"
        Me.ButtonCancella.UseVisualStyleBackColor = True
        '
        'LabelColonne
        '
        Me.LabelColonne.AutoSize = True
        Me.LabelColonne.BackColor = System.Drawing.Color.Gainsboro
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelColonne, 2)
        Me.LabelColonne.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelColonne.Location = New System.Drawing.Point(0, 0)
        Me.LabelColonne.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelColonne.Name = "LabelColonne"
        Me.LabelColonne.Size = New System.Drawing.Size(262, 20)
        Me.LabelColonne.TabIndex = 4
        Me.LabelColonne.Text = "Colonne disponibili"
        Me.LabelColonne.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelOrdinamento
        '
        Me.LabelOrdinamento.AutoSize = True
        Me.LabelOrdinamento.BackColor = System.Drawing.Color.Gold
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelOrdinamento, 2)
        Me.LabelOrdinamento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelOrdinamento.Location = New System.Drawing.Point(262, 0)
        Me.LabelOrdinamento.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelOrdinamento.Name = "LabelOrdinamento"
        Me.LabelOrdinamento.Size = New System.Drawing.Size(262, 20)
        Me.LabelOrdinamento.TabIndex = 5
        Me.LabelOrdinamento.Text = "Ordinamento"
        Me.LabelOrdinamento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonOk
        '
        Me.ButtonOk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonOk.FlatAppearance.BorderSize = 0
        Me.ButtonOk.Location = New System.Drawing.Point(393, 322)
        Me.ButtonOk.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonOk.Name = "ButtonOk"
        Me.TableLayoutPanel1.SetRowSpan(Me.ButtonOk, 2)
        Me.ButtonOk.Size = New System.Drawing.Size(131, 50)
        Me.ButtonOk.TabIndex = 6
        Me.ButtonOk.Text = "Ok"
        Me.ButtonOk.UseVisualStyleBackColor = True
        '
        'ButtonCancellaTutto
        '
        Me.ButtonCancellaTutto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCancellaTutto.Location = New System.Drawing.Point(265, 350)
        Me.ButtonCancellaTutto.Name = "ButtonCancellaTutto"
        Me.ButtonCancellaTutto.Size = New System.Drawing.Size(125, 19)
        Me.ButtonCancellaTutto.TabIndex = 8
        Me.ButtonCancellaTutto.Text = "Button1"
        Me.ButtonCancellaTutto.UseVisualStyleBackColor = True
        '
        'FormOrdinamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(524, 372)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormOrdinamento"
        Me.Text = "FormOrdinamento"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBoxColonne As System.Windows.Forms.ListBox
    Friend WithEvents ListBoxOrdinamento As System.Windows.Forms.ListBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonAggiungiCrescente As System.Windows.Forms.Button
    Friend WithEvents ButtonCancella As System.Windows.Forms.Button
    Friend WithEvents LabelColonne As System.Windows.Forms.Label
    Friend WithEvents LabelOrdinamento As System.Windows.Forms.Label
    Friend WithEvents ButtonOk As System.Windows.Forms.Button
    Friend WithEvents ButtonAggiungiDecrescente As System.Windows.Forms.Button
    Friend WithEvents ButtonCancellaTutto As System.Windows.Forms.Button
End Class
