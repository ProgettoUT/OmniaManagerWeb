<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class P00000FE
    Inherits System.Windows.Forms.UserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.QuotatorePremio = New UniQuota.QuotatorePremio()
        Me.docTab = New System.Windows.Forms.TabPage()
        Me.helpTab = New System.Windows.Forms.TabPage()
        Me.docBrowser = New System.Windows.Forms.WebBrowser()
        Me.helpBrowser = New System.Windows.Forms.WebBrowser()
        Me.docIndice = New System.Windows.Forms.Button()
        Me.TableLayoutBase = New System.Windows.Forms.TableLayoutPanel()
        Me.lblMessaggi = New System.Windows.Forms.Label()
        Me.lblCaricamento = New System.Windows.Forms.Label()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.docTab.SuspendLayout()
        Me.helpTab.SuspendLayout()
        Me.TableLayoutBase.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCaricamento
        '
        Me.lblCaricamento.Font = New System.Drawing.Font("Tahoma", 32.0!, System.Drawing.FontStyle.Bold)
        Me.lblCaricamento.ForeColor = System.Drawing.Color.LightGray
        Me.lblCaricamento.Name = "lblCaricamento"
        Me.lblCaricamento.Size = New System.Drawing.Size(500, 49)
        Me.lblCaricamento.TextAlign = ContentAlignment.MiddleCenter
        Me.lblCaricamento.Text = "Caricamento in corso ..."
        Me.lblCaricamento.Dock = DockStyle.Fill
        Me.lblCaricamento.Visible = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 19)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.QuotatorePremio)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Size = New System.Drawing.Size(1041, 546)
        Me.SplitContainer1.SplitterDistance = 210
        Me.SplitContainer1.SplitterWidth = 6
        Me.SplitContainer1.TabIndex = 10
        '
        'QuotatorePremio
        '
        Me.QuotatorePremio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.QuotatorePremio.Image = Nothing
        Me.QuotatorePremio.Location = New System.Drawing.Point(0, 0)
        Me.QuotatorePremio.Name = "QuotatorePremio"
        Me.QuotatorePremio.Size = New System.Drawing.Size(210, 546)
        Me.QuotatorePremio.TabIndex = 0
        '
        'helpTab
        '
        Me.helpTab.Controls.Add(Me.helpBrowser)
        Me.helpTab.ImageIndex = 3
        Me.helpTab.Location = New System.Drawing.Point(4, 29)
        Me.helpTab.Margin = New System.Windows.Forms.Padding(0)
        Me.helpTab.Name = "helpTab"
        Me.helpTab.Size = New System.Drawing.Size(1082, 502)
        Me.helpTab.TabIndex = 5
        Me.helpTab.Tag = "HELP"
        Me.helpTab.Text = "Prodotto"
        Me.helpTab.UseVisualStyleBackColor = True
        '
        'helpBrowser
        '
        Me.helpBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.helpBrowser.Location = New System.Drawing.Point(0, 30)
        Me.helpBrowser.Margin = New System.Windows.Forms.Padding(0)
        Me.helpBrowser.MinimumSize = New System.Drawing.Size(23, 22)
        Me.helpBrowser.Name = "helpBrowser"
        Me.helpBrowser.ScriptErrorsSuppressed = True
        Me.helpBrowser.Size = New System.Drawing.Size(1082, 472)
        '
        'docTab
        '
        Me.docTab.Controls.Add(Me.docBrowser)
        Me.docTab.Controls.Add(Me.docIndice)
        Me.docTab.ImageIndex = 3
        Me.docTab.Location = New System.Drawing.Point(4, 29)
        Me.docTab.Margin = New System.Windows.Forms.Padding(0)
        Me.docTab.Name = "docTab"
        Me.docTab.Size = New System.Drawing.Size(1082, 502)
        Me.docTab.Tag = "DOC"
        Me.docTab.Text = "Documentazione"
        Me.docTab.UseVisualStyleBackColor = True
        '
        'docBrowser
        '
        Me.docBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.docBrowser.Location = New System.Drawing.Point(0, 30)
        Me.docBrowser.Margin = New System.Windows.Forms.Padding(0)
        Me.docBrowser.MinimumSize = New System.Drawing.Size(23, 22)
        Me.docBrowser.Name = "docBrowser"
        Me.docBrowser.ScriptErrorsSuppressed = True
        Me.docBrowser.Size = New System.Drawing.Size(1082, 472)
        Me.docBrowser.TabIndex = 16
        '
        'docIndice
        '
        Me.docIndice.Dock = System.Windows.Forms.DockStyle.Top
        Me.docIndice.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.docIndice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.docIndice.Location = New System.Drawing.Point(0, 0)
        Me.docIndice.Name = "docIndice"
        Me.docIndice.Size = New System.Drawing.Size(1082, 30)
        Me.docIndice.TabIndex = 17
        Me.docIndice.Text = "Indice"
        Me.docIndice.UseVisualStyleBackColor = True
        '
        'TableLayoutBase
        '
        Me.TableLayoutBase.ColumnCount = 1
        Me.TableLayoutBase.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutBase.Controls.Add(Me.SplitContainer1, 0, 0)
        Me.TableLayoutBase.Controls.Add(Me.lblMessaggi, 0, 0)
        Me.TableLayoutBase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutBase.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutBase.Name = "TableLayoutBase"
        Me.TableLayoutBase.RowCount = 2
        Me.TableLayoutBase.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16.0!))
        Me.TableLayoutBase.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutBase.Size = New System.Drawing.Size(1047, 568)
        Me.TableLayoutBase.TabIndex = 11
        '
        'lblMessaggi
        '
        Me.lblMessaggi.AutoSize = True
        Me.lblMessaggi.BackColor = System.Drawing.Color.Coral
        Me.lblMessaggi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMessaggi.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessaggi.ForeColor = System.Drawing.Color.White
        Me.lblMessaggi.Location = New System.Drawing.Point(0, 0)
        Me.lblMessaggi.Margin = New System.Windows.Forms.Padding(0)
        Me.lblMessaggi.Name = "lblMessaggi"
        Me.lblMessaggi.Size = New System.Drawing.Size(1047, 16)
        Me.lblMessaggi.TabIndex = 11
        Me.lblMessaggi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'P00000FE
        '
        Me.Controls.Add(Me.TableLayoutBase)
        Me.Name = "P00000FE"
        Me.Size = New System.Drawing.Size(1047, 568)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.helpTab.ResumeLayout(False)
        Me.docTab.ResumeLayout(False)
        Me.TableLayoutBase.ResumeLayout(False)
        Me.TableLayoutBase.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents QuotatorePremio As UniQuota.QuotatorePremio
    Friend WithEvents docTab As System.Windows.Forms.TabPage
    Friend WithEvents docBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents docIndice As System.Windows.Forms.Button
    Friend WithEvents TableLayoutBase As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblMessaggi As System.Windows.Forms.Label
    Friend WithEvents lblCaricamento As System.Windows.Forms.Label
    Friend WithEvents helpTab As System.Windows.Forms.TabPage
    Friend WithEvents helpBrowser As System.Windows.Forms.WebBrowser
End Class
