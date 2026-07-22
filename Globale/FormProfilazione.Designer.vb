<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProfilazione
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim UtenteLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProfilazione))
        Me.UProfiloDataSet = New UProfiloDataSet()
        Me.UtenteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UtenteTableAdapter = New UProfiloDataSetTableAdapters.UtenteTableAdapter()
        Me.TableAdapterManager = New UProfiloDataSetTableAdapters.TableAdapterManager()
        Me.ColoniaTableAdapter = New UProfiloDataSetTableAdapters.ColoniaTableAdapter()
        Me.UtenteBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.UtenteBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.UtenteTextBox = New System.Windows.Forms.TextBox()
        Me.ColoniaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ColoniaDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkAmministratore = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkOperativo = New System.Windows.Forms.CheckBox()
        Me.chkGestionale = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdChiudi = New System.Windows.Forms.Button()
        UtenteLabel = New System.Windows.Forms.Label()
        CType(Me.UProfiloDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UtenteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UtenteBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UtenteBindingNavigator.SuspendLayout()
        CType(Me.ColoniaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColoniaDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'UtenteLabel
        '
        UtenteLabel.AutoSize = True
        UtenteLabel.Location = New System.Drawing.Point(21, 49)
        UtenteLabel.Name = "UtenteLabel"
        UtenteLabel.Size = New System.Drawing.Size(42, 13)
        UtenteLabel.TabIndex = 1
        UtenteLabel.Text = "Utente:"
        '
        'UProfiloDataSet
        '
        Me.UProfiloDataSet.DataSetName = "UProfiloDataSet"
        Me.UProfiloDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UtenteBindingSource
        '
        Me.UtenteBindingSource.DataMember = "Utente"
        Me.UtenteBindingSource.DataSource = Me.UProfiloDataSet
        '
        'UtenteTableAdapter
        '
        Me.UtenteTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.ColoniaTableAdapter = Me.ColoniaTableAdapter
        Me.TableAdapterManager.UpdateOrder = UProfiloDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.UtenteTableAdapter = Me.UtenteTableAdapter
        '
        'ColoniaTableAdapter
        '
        Me.ColoniaTableAdapter.ClearBeforeFill = True
        '
        'UtenteBindingNavigator
        '
        Me.UtenteBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.UtenteBindingNavigator.BindingSource = Me.UtenteBindingSource
        Me.UtenteBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.UtenteBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.UtenteBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.UtenteBindingNavigatorSaveItem})
        Me.UtenteBindingNavigator.Location = New System.Drawing.Point(5, 5)
        Me.UtenteBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.UtenteBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.UtenteBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.UtenteBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.UtenteBindingNavigator.Name = "UtenteBindingNavigator"
        Me.UtenteBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.UtenteBindingNavigator.Size = New System.Drawing.Size(480, 25)
        Me.UtenteBindingNavigator.TabIndex = 0
        Me.UtenteBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'UtenteBindingNavigatorSaveItem
        '
        Me.UtenteBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.UtenteBindingNavigatorSaveItem.Image = CType(resources.GetObject("UtenteBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.UtenteBindingNavigatorSaveItem.Name = "UtenteBindingNavigatorSaveItem"
        Me.UtenteBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.UtenteBindingNavigatorSaveItem.Text = "Save Data"
        '
        'UtenteTextBox
        '
        Me.UtenteTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UtenteBindingSource, "Utente", True))
        Me.UtenteTextBox.Location = New System.Drawing.Point(83, 46)
        Me.UtenteTextBox.Name = "UtenteTextBox"
        Me.UtenteTextBox.Size = New System.Drawing.Size(100, 20)
        Me.UtenteTextBox.TabIndex = 2
        '
        'ColoniaBindingSource
        '
        Me.ColoniaBindingSource.DataMember = "UtenteColonia"
        Me.ColoniaBindingSource.DataSource = Me.UtenteBindingSource
        '
        'ColoniaDataGridView
        '
        Me.ColoniaDataGridView.AutoGenerateColumns = False
        Me.ColoniaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ColoniaDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6})
        Me.ColoniaDataGridView.DataSource = Me.ColoniaBindingSource
        Me.ColoniaDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ColoniaDataGridView.Location = New System.Drawing.Point(5, 18)
        Me.ColoniaDataGridView.Name = "ColoniaDataGridView"
        Me.ColoniaDataGridView.Size = New System.Drawing.Size(470, 181)
        Me.ColoniaDataGridView.TabIndex = 7
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Compagnia"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Compagnia"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Agenzia"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Agenzia"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Subagenzia"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Subagenzia"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Produttore"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Produttore"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'chkAmministratore
        '
        Me.chkAmministratore.AutoSize = True
        Me.chkAmministratore.Location = New System.Drawing.Point(8, 27)
        Me.chkAmministratore.Name = "chkAmministratore"
        Me.chkAmministratore.Size = New System.Drawing.Size(94, 17)
        Me.chkAmministratore.TabIndex = 8
        Me.chkAmministratore.Tag = "1"
        Me.chkAmministratore.Text = "Amministratore"
        Me.chkAmministratore.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ColoniaDataGridView)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(5, 158)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(5)
        Me.GroupBox1.Size = New System.Drawing.Size(480, 204)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Colonia dati"
        '
        'chkOperativo
        '
        Me.chkOperativo.AutoSize = True
        Me.chkOperativo.Location = New System.Drawing.Point(204, 27)
        Me.chkOperativo.Name = "chkOperativo"
        Me.chkOperativo.Size = New System.Drawing.Size(72, 17)
        Me.chkOperativo.TabIndex = 8
        Me.chkOperativo.Tag = "2"
        Me.chkOperativo.Text = "Operativo"
        Me.chkOperativo.UseVisualStyleBackColor = True
        '
        'chkGestionale
        '
        Me.chkGestionale.AutoSize = True
        Me.chkGestionale.Location = New System.Drawing.Point(396, 27)
        Me.chkGestionale.Name = "chkGestionale"
        Me.chkGestionale.Size = New System.Drawing.Size(76, 17)
        Me.chkGestionale.TabIndex = 8
        Me.chkGestionale.Tag = "4"
        Me.chkGestionale.Text = "Gestionale"
        Me.chkGestionale.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkGestionale)
        Me.GroupBox2.Controls.Add(Me.chkOperativo)
        Me.GroupBox2.Controls.Add(Me.chkAmministratore)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(5, 88)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(5)
        Me.GroupBox2.Size = New System.Drawing.Size(480, 70)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Autorizzazioni"
        '
        'cmdChiudi
        '
        Me.cmdChiudi.Location = New System.Drawing.Point(385, 33)
        Me.cmdChiudi.Name = "cmdChiudi"
        Me.cmdChiudi.Size = New System.Drawing.Size(100, 44)
        Me.cmdChiudi.TabIndex = 11
        Me.cmdChiudi.Text = "Chiudi"
        Me.cmdChiudi.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(490, 367)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdChiudi)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(UtenteLabel)
        Me.Controls.Add(Me.UtenteTextBox)
        Me.Controls.Add(Me.UtenteBindingNavigator)
        Me.Name = "Form1"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.Text = "Profilazione"
        CType(Me.UProfiloDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UtenteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UtenteBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UtenteBindingNavigator.ResumeLayout(False)
        Me.UtenteBindingNavigator.PerformLayout()
        CType(Me.ColoniaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColoniaDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UProfiloDataSet As UProfiloDataSet
    Friend WithEvents UtenteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UtenteTableAdapter As UProfiloDataSetTableAdapters.UtenteTableAdapter
    Friend WithEvents TableAdapterManager As UProfiloDataSetTableAdapters.TableAdapterManager
    Friend WithEvents UtenteBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents UtenteBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ColoniaTableAdapter As UProfiloDataSetTableAdapters.ColoniaTableAdapter
    Friend WithEvents UtenteTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ColoniaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ColoniaDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents chkAmministratore As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkOperativo As System.Windows.Forms.CheckBox
    Friend WithEvents chkGestionale As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdChiudi As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
