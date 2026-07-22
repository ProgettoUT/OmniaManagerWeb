<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormDebugWeb
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.WebViewDebug = New Microsoft.Web.WebView2.WinForms.WebView2()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.WebViewDebug, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'WebViewDebug
        '
        Me.WebViewDebug.AllowExternalDrop = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.WebViewDebug, 2)
        Me.WebViewDebug.CreationProperties = Nothing
        Me.WebViewDebug.DefaultBackgroundColor = System.Drawing.Color.White
        Me.WebViewDebug.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebViewDebug.Location = New System.Drawing.Point(3, 3)
        Me.WebViewDebug.Name = "WebViewDebug"
        Me.WebViewDebug.Size = New System.Drawing.Size(794, 219)
        Me.WebViewDebug.TabIndex = 0
        Me.WebViewDebug.ZoomFactor = 1.0R
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.WebViewDebug, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button1, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(800, 490)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button1.Location = New System.Drawing.Point(3, 453)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(394, 34)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FormDebugWeb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 490)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormDebugWeb"
        Me.Text = "FormDebugWeb"
        CType(Me.WebViewDebug, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents WebViewDebug As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents TableLayoutPanel1 As Windows.Forms.TableLayoutPanel
    Friend WithEvents Button1 As Windows.Forms.Button
End Class
