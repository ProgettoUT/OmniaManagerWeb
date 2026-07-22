<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucAndamento
    Inherits System.Windows.Forms.UserControl

    'UserControl esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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
        Dim CartesianArea1 As Telerik.WinControls.UI.CartesianArea = New Telerik.WinControls.UI.CartesianArea()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dgvAndamento = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.RadChartView1 = New Telerik.WinControls.UI.RadChartView()
        Me.CheckBoxCosto = New System.Windows.Forms.CheckBox()
        Me.CheckBoxSpese = New System.Windows.Forms.CheckBox()
        Me.CheckBoxBilancio = New System.Windows.Forms.CheckBox()
        Me.CheckBoxRiserva = New System.Windows.Forms.CheckBox()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvAndamento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.RadChartView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvAndamento)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(728, 437)
        Me.SplitContainer1.SplitterDistance = 205
        Me.SplitContainer1.TabIndex = 0
        '
        'dgvAndamento
        '
        Me.dgvAndamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAndamento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAndamento.Location = New System.Drawing.Point(0, 0)
        Me.dgvAndamento.Name = "dgvAndamento"
        Me.dgvAndamento.Size = New System.Drawing.Size(728, 205)
        Me.dgvAndamento.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.RadChartView1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxCosto, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxSpese, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxBilancio, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBoxRiserva, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(728, 228)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'RadChartView1
        '
        CartesianArea1.GridDesign.AlternatingHorizontalColor = False
        CartesianArea1.GridDesign.AlternatingVerticalColor = False
        CartesianArea1.GridDesign.DrawHorizontalFills = False
        CartesianArea1.GridDesign.DrawVerticalFills = False
        CartesianArea1.GridDesign.DrawVerticalStripes = False
        Me.RadChartView1.AreaDesign = CartesianArea1
        Me.TableLayoutPanel1.SetColumnSpan(Me.RadChartView1, 4)
        Me.RadChartView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RadChartView1.Location = New System.Drawing.Point(3, 23)
        Me.RadChartView1.Name = "RadChartView1"
        Me.RadChartView1.ShowGrid = False
        Me.RadChartView1.Size = New System.Drawing.Size(722, 202)
        Me.RadChartView1.TabIndex = 0
        Me.RadChartView1.Text = "RadChartView1"
        '
        'CheckBoxCosto
        '
        Me.CheckBoxCosto.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBoxCosto.AutoSize = True
        Me.CheckBoxCosto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxCosto.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.CheckBoxCosto.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CheckBoxCosto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxCosto.Location = New System.Drawing.Point(364, 0)
        Me.CheckBoxCosto.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckBoxCosto.Name = "CheckBoxCosto"
        Me.CheckBoxCosto.Size = New System.Drawing.Size(182, 20)
        Me.CheckBoxCosto.TabIndex = 1
        Me.CheckBoxCosto.Text = "Costo totale"
        Me.CheckBoxCosto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBoxCosto.UseVisualStyleBackColor = True
        '
        'CheckBoxSpese
        '
        Me.CheckBoxSpese.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBoxSpese.AutoSize = True
        Me.CheckBoxSpese.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxSpese.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.CheckBoxSpese.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CheckBoxSpese.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxSpese.Location = New System.Drawing.Point(546, 0)
        Me.CheckBoxSpese.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckBoxSpese.Name = "CheckBoxSpese"
        Me.CheckBoxSpese.Size = New System.Drawing.Size(182, 20)
        Me.CheckBoxSpese.TabIndex = 2
        Me.CheckBoxSpese.Text = "Spese"
        Me.CheckBoxSpese.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBoxSpese.UseVisualStyleBackColor = True
        '
        'CheckBoxBilancio
        '
        Me.CheckBoxBilancio.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBoxBilancio.AutoSize = True
        Me.CheckBoxBilancio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxBilancio.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.CheckBoxBilancio.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CheckBoxBilancio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxBilancio.Location = New System.Drawing.Point(182, 0)
        Me.CheckBoxBilancio.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckBoxBilancio.Name = "CheckBoxBilancio"
        Me.CheckBoxBilancio.Size = New System.Drawing.Size(182, 20)
        Me.CheckBoxBilancio.TabIndex = 3
        Me.CheckBoxBilancio.Text = "Riserva di bilancio"
        Me.CheckBoxBilancio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBoxBilancio.UseVisualStyleBackColor = True
        '
        'CheckBoxRiserva
        '
        Me.CheckBoxRiserva.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBoxRiserva.AutoSize = True
        Me.CheckBoxRiserva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBoxRiserva.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.CheckBoxRiserva.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CheckBoxRiserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxRiserva.Location = New System.Drawing.Point(0, 0)
        Me.CheckBoxRiserva.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckBoxRiserva.Name = "CheckBoxRiserva"
        Me.CheckBoxRiserva.Size = New System.Drawing.Size(182, 20)
        Me.CheckBoxRiserva.TabIndex = 4
        Me.CheckBoxRiserva.Text = "Riserva tecnica"
        Me.CheckBoxRiserva.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBoxRiserva.UseVisualStyleBackColor = True
        '
        'ucAndamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "ucAndamento"
        Me.Size = New System.Drawing.Size(728, 437)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvAndamento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.RadChartView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents RadChartView1 As Telerik.WinControls.UI.RadChartView
    Friend WithEvents dgvAndamento As System.Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CheckBoxCosto As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxSpese As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxBilancio As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxRiserva As System.Windows.Forms.CheckBox

End Class
