<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPopUp))
        Me.wbPopUp = New AxSHDocVw.AxWebBrowser()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonCreaNota = New System.Windows.Forms.Button()
        CType(Me.wbPopUp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'wbPopUp
        '
        Me.wbPopUp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbPopUp.Enabled = True
        Me.wbPopUp.Location = New System.Drawing.Point(3, 3)
        Me.wbPopUp.OcxState = CType(resources.GetObject("wbPopUp.OcxState"), System.Windows.Forms.AxHost.State)
        Me.wbPopUp.Size = New System.Drawing.Size(694, 329)
        Me.wbPopUp.TabIndex = 0
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 1
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Controls.Add(Me.wbPopUp, 0, 0)
        Me.tlpMain.Controls.Add(Me.ButtonCreaNota, 0, 1)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 2
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tlpMain.Size = New System.Drawing.Size(700, 375)
        Me.tlpMain.TabIndex = 1
        '
        'ButtonCreaNota
        '
        Me.ButtonCreaNota.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCreaNota.Location = New System.Drawing.Point(3, 338)
        Me.ButtonCreaNota.Name = "ButtonCreaNota"
        Me.ButtonCreaNota.Size = New System.Drawing.Size(694, 34)
        Me.ButtonCreaNota.TabIndex = 1
        Me.ButtonCreaNota.Text = "Button1"
        Me.ButtonCreaNota.UseVisualStyleBackColor = True
        '
        'FormPopUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 375)
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "FormPopUp"
        Me.Text = "FormPopUp"
        CType(Me.wbPopUp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents wbPopUp As AxSHDocVw.AxWebBrowser
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonCreaNota As System.Windows.Forms.Button
End Class
