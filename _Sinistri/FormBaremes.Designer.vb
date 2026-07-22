<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBaremes
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
        Me.TabMain = New Utx.UtTabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.CheckedListBoxA = New System.Windows.Forms.CheckedListBox()
        Me.CheckedListBoxB = New System.Windows.Forms.CheckedListBox()
        Me.LabelA = New System.Windows.Forms.Label()
        Me.LabelB = New System.Windows.Forms.Label()
        Me.LabelRisultato = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.TabMain.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabMain
        '
        Me.TabMain.Controls.Add(Me.TabPage1)
        Me.TabMain.Controls.Add(Me.TabPage2)
        Me.TabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabMain.Location = New System.Drawing.Point(0, 0)
        Me.TabMain.Name = "TabMain"
        Me.TabMain.SelectedIndex = 0
        Me.TabMain.Size = New System.Drawing.Size(494, 345)
        Me.TabMain.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(486, 319)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.CheckedListBoxA, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckedListBoxB, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelA, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelB, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelRisultato, 0, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(480, 313)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'CheckedListBoxA
        '
        Me.CheckedListBoxA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBoxA.FormattingEnabled = True
        Me.CheckedListBoxA.Location = New System.Drawing.Point(3, 28)
        Me.CheckedListBoxA.Name = "CheckedListBoxA"
        Me.CheckedListBoxA.Size = New System.Drawing.Size(474, 100)
        Me.CheckedListBoxA.TabIndex = 0
        '
        'CheckedListBoxB
        '
        Me.CheckedListBoxB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBoxB.FormattingEnabled = True
        Me.CheckedListBoxB.Location = New System.Drawing.Point(3, 159)
        Me.CheckedListBoxB.Name = "CheckedListBoxB"
        Me.CheckedListBoxB.Size = New System.Drawing.Size(474, 100)
        Me.CheckedListBoxB.TabIndex = 1
        '
        'LabelA
        '
        Me.LabelA.AutoSize = True
        Me.LabelA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelA.Location = New System.Drawing.Point(3, 0)
        Me.LabelA.Name = "LabelA"
        Me.LabelA.Size = New System.Drawing.Size(474, 25)
        Me.LabelA.TabIndex = 2
        Me.LabelA.Text = "Veicolo A"
        Me.LabelA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelB
        '
        Me.LabelB.AutoSize = True
        Me.LabelB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelB.Location = New System.Drawing.Point(3, 131)
        Me.LabelB.Name = "LabelB"
        Me.LabelB.Size = New System.Drawing.Size(474, 25)
        Me.LabelB.TabIndex = 3
        Me.LabelB.Text = "Veicolo B"
        Me.LabelB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelRisultato
        '
        Me.LabelRisultato.AutoSize = True
        Me.LabelRisultato.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelRisultato.Location = New System.Drawing.Point(3, 262)
        Me.LabelRisultato.Name = "LabelRisultato"
        Me.LabelRisultato.Size = New System.Drawing.Size(474, 51)
        Me.LabelRisultato.TabIndex = 4
        Me.LabelRisultato.Text = "Label3"
        Me.LabelRisultato.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.WebBrowser1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(486, 319)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(3, 3)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(480, 313)
        Me.WebBrowser1.TabIndex = 0
        '
        'FormBaremes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 345)
        Me.Controls.Add(Me.TabMain)
        Me.Name = "FormBaremes"
        Me.Text = "FormBaremes"
        Me.TabMain.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabMain As Utx.UtTabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CheckedListBoxA As System.Windows.Forms.CheckedListBox
    Friend WithEvents CheckedListBoxB As System.Windows.Forms.CheckedListBox
    Friend WithEvents LabelA As System.Windows.Forms.Label
    Friend WithEvents LabelB As System.Windows.Forms.Label
    Friend WithEvents LabelRisultato As System.Windows.Forms.Label
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
End Class
