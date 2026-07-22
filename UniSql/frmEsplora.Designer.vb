Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEsplora
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEsplora))
        Me.imgImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.TabControlSql = New Utx.UtTabControl()
        Me.TabPageCatalogo = New System.Windows.Forms.TabPage()
        Me.splitContainerSql = New System.Windows.Forms.SplitContainer()
        Me.TreeViewSql = New System.Windows.Forms.TreeView()
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TreeViewStar = New System.Windows.Forms.TreeView()
        Me.webBrowserDoc = New System.Windows.Forms.WebBrowser()
        Me.tsMainMenu = New System.Windows.Forms.ToolStrip()
        Me.ButtonEsci = New System.Windows.Forms.ToolStripButton()
        Me.LabelCerca = New System.Windows.Forms.ToolStripLabel()
        Me.TextBoxCerca = New System.Windows.Forms.ToolStripTextBox()
        Me.ButtonCercaReset = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonEstrai = New System.Windows.Forms.ToolStripButton()
        Me.ButtonProprieta = New System.Windows.Forms.ToolStripButton()
        Me.ButtonPreferito = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonAggiornaCatalogo = New System.Windows.Forms.ToolStripButton()
        Me.contextMenuStripFavorite = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EliminaDaPreferitiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminaDaCronologiaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControlSql.SuspendLayout()
        Me.TabPageCatalogo.SuspendLayout()
        Me.splitContainerSql.Panel1.SuspendLayout()
        Me.splitContainerSql.Panel2.SuspendLayout()
        Me.splitContainerSql.SuspendLayout()
        Me.tableLayoutPanel1.SuspendLayout()
        Me.tsMainMenu.SuspendLayout()
        Me.contextMenuStripFavorite.SuspendLayout()
        Me.SuspendLayout()
        '
        'imgImageList
        '
        Me.imgImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgImageList.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgImageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'TabControlSql
        '
        Me.TabControlSql.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabControlSql.ColorStyle = Utx.UtTabControl.TabColorStyle.AZZURRO
        Me.TabControlSql.Controls.Add(Me.TabPageCatalogo)
        Me.TabControlSql.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlSql.ItemSize = New System.Drawing.Size(100, 25)
        Me.TabControlSql.Location = New System.Drawing.Point(0, 0)
        Me.TabControlSql.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControlSql.Name = "TabControlSql"
        Me.TabControlSql.SelectedIndex = 0
        Me.TabControlSql.Size = New System.Drawing.Size(863, 480)
        Me.TabControlSql.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControlSql.TabIndex = 2
        '
        'TabPageCatalogo
        '
        Me.TabPageCatalogo.Controls.Add(Me.splitContainerSql)
        Me.TabPageCatalogo.Controls.Add(Me.tsMainMenu)
        Me.TabPageCatalogo.Location = New System.Drawing.Point(4, 29)
        Me.TabPageCatalogo.Margin = New System.Windows.Forms.Padding(0)
        Me.TabPageCatalogo.Name = "TabPageCatalogo"
        Me.TabPageCatalogo.Padding = New System.Windows.Forms.Padding(1)
        Me.TabPageCatalogo.Size = New System.Drawing.Size(855, 447)
        Me.TabPageCatalogo.TabIndex = 0
        Me.TabPageCatalogo.Text = "Catalogo"
        '
        'splitContainerSql
        '
        Me.splitContainerSql.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainerSql.Location = New System.Drawing.Point(1, 53)
        Me.splitContainerSql.Margin = New System.Windows.Forms.Padding(0)
        Me.splitContainerSql.Name = "splitContainerSql"
        '
        'splitContainerSql.Panel1
        '
        Me.splitContainerSql.Panel1.Controls.Add(Me.TreeViewSql)
        '
        'splitContainerSql.Panel2
        '
        Me.splitContainerSql.Panel2.Controls.Add(Me.tableLayoutPanel1)
        Me.splitContainerSql.Size = New System.Drawing.Size(853, 393)
        Me.splitContainerSql.SplitterDistance = 282
        Me.splitContainerSql.TabIndex = 0
        '
        'TreeViewSql
        '
        Me.TreeViewSql.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeViewSql.ImageIndex = 0
        Me.TreeViewSql.ImageList = Me.imgImageList
        Me.TreeViewSql.ItemHeight = 20
        Me.TreeViewSql.Location = New System.Drawing.Point(0, 0)
        Me.TreeViewSql.Name = "TreeViewSql"
        Me.TreeViewSql.SelectedImageIndex = 0
        Me.TreeViewSql.Size = New System.Drawing.Size(282, 393)
        Me.TreeViewSql.TabIndex = 0
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.ColumnCount = 1
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel1.Controls.Add(Me.TreeViewStar, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.webBrowserDoc, 0, 1)
        Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.tableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 2
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(567, 393)
        Me.tableLayoutPanel1.TabIndex = 2
        '
        'TreeViewStar
        '
        Me.TreeViewStar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeViewStar.ImageIndex = 0
        Me.TreeViewStar.ImageList = Me.imgImageList
        Me.TreeViewStar.ItemHeight = 20
        Me.TreeViewStar.Location = New System.Drawing.Point(3, 0)
        Me.TreeViewStar.Margin = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.TreeViewStar.Name = "TreeViewStar"
        Me.TreeViewStar.SelectedImageIndex = 0
        Me.TreeViewStar.Size = New System.Drawing.Size(561, 293)
        Me.TreeViewStar.TabIndex = 1
        '
        'webBrowserDoc
        '
        Me.webBrowserDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.webBrowserDoc.Location = New System.Drawing.Point(3, 296)
        Me.webBrowserDoc.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webBrowserDoc.Name = "webBrowserDoc"
        Me.webBrowserDoc.ScrollBarsEnabled = False
        Me.webBrowserDoc.Size = New System.Drawing.Size(561, 94)
        Me.webBrowserDoc.TabIndex = 2
        Me.webBrowserDoc.Visible = False
        Me.webBrowserDoc.WebBrowserShortcutsEnabled = False
        '
        'tsMainMenu
        '
        Me.tsMainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsMainMenu.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.tsMainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonEsci, Me.LabelCerca, Me.TextBoxCerca, Me.ButtonCercaReset, Me.ToolStripSeparator1, Me.ButtonEstrai, Me.ButtonProprieta, Me.ButtonPreferito, Me.ToolStripSeparator2, Me.ButtonAggiornaCatalogo})
        Me.tsMainMenu.Location = New System.Drawing.Point(1, 1)
        Me.tsMainMenu.Name = "tsMainMenu"
        Me.tsMainMenu.Padding = New System.Windows.Forms.Padding(0)
        Me.tsMainMenu.Size = New System.Drawing.Size(853, 52)
        Me.tsMainMenu.TabIndex = 1
        '
        'ButtonEsci
        '
        Me.ButtonEsci.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ButtonEsci.AutoSize = False
        Me.ButtonEsci.Image = CType(resources.GetObject("ButtonEsci.Image"), System.Drawing.Image)
        Me.ButtonEsci.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.ButtonEsci.Size = New System.Drawing.Size(60, 49)
        Me.ButtonEsci.Text = "esci"
        Me.ButtonEsci.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonEsci.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ButtonEsci.ToolTipText = "Esci dal catalogo estrazioni"
        '
        'LabelCerca
        '
        Me.LabelCerca.Name = "LabelCerca"
        Me.LabelCerca.Size = New System.Drawing.Size(118, 49)
        Me.LabelCerca.Text = "Cerca nelle estrazioni"
        '
        'TextBoxCerca
        '
        Me.TextBoxCerca.BackColor = System.Drawing.Color.Black
        Me.TextBoxCerca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxCerca.ForeColor = System.Drawing.Color.White
        Me.TextBoxCerca.Name = "TextBoxCerca"
        Me.TextBoxCerca.Size = New System.Drawing.Size(250, 52)
        '
        'ButtonCercaReset
        '
        Me.ButtonCercaReset.AutoSize = False
        Me.ButtonCercaReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButtonCercaReset.Image = CType(resources.GetObject("ButtonCercaReset.Image"), System.Drawing.Image)
        Me.ButtonCercaReset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ButtonCercaReset.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonCercaReset.Name = "ButtonCercaReset"
        Me.ButtonCercaReset.Size = New System.Drawing.Size(16, 24)
        Me.ButtonCercaReset.Text = "Cerca estrazione"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 52)
        '
        'ButtonEstrai
        '
        Me.ButtonEstrai.AutoSize = False
        Me.ButtonEstrai.ImageTransparentColor = System.Drawing.Color.White
        Me.ButtonEstrai.Name = "ButtonEstrai"
        Me.ButtonEstrai.Size = New System.Drawing.Size(60, 49)
        Me.ButtonEstrai.Text = "estrai"
        Me.ButtonEstrai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ButtonProprieta
        '
        Me.ButtonProprieta.AutoSize = False
        Me.ButtonProprieta.ImageTransparentColor = System.Drawing.Color.White
        Me.ButtonProprieta.Name = "ButtonProprieta"
        Me.ButtonProprieta.Size = New System.Drawing.Size(60, 49)
        Me.ButtonProprieta.Text = "proprietà"
        Me.ButtonProprieta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ButtonPreferito
        '
        Me.ButtonPreferito.AutoSize = False
        Me.ButtonPreferito.ImageTransparentColor = System.Drawing.Color.White
        Me.ButtonPreferito.Name = "ButtonPreferito"
        Me.ButtonPreferito.Size = New System.Drawing.Size(60, 49)
        Me.ButtonPreferito.Text = "preferiti"
        Me.ButtonPreferito.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 52)
        '
        'ButtonAggiornaCatalogo
        '
        Me.ButtonAggiornaCatalogo.AutoSize = False
        Me.ButtonAggiornaCatalogo.ImageTransparentColor = System.Drawing.Color.White
        Me.ButtonAggiornaCatalogo.Name = "ButtonAggiornaCatalogo"
        Me.ButtonAggiornaCatalogo.Size = New System.Drawing.Size(60, 49)
        Me.ButtonAggiornaCatalogo.Text = "aggiorna"
        Me.ButtonAggiornaCatalogo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'contextMenuStripFavorite
        '
        Me.contextMenuStripFavorite.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EliminaDaPreferitiToolStripMenuItem, Me.EliminaDaCronologiaToolStripMenuItem})
        Me.contextMenuStripFavorite.Name = "contextMenuStripFavorite"
        Me.contextMenuStripFavorite.Size = New System.Drawing.Size(190, 48)
        '
        'EliminaDaPreferitiToolStripMenuItem
        '
        Me.EliminaDaPreferitiToolStripMenuItem.Name = "EliminaDaPreferitiToolStripMenuItem"
        Me.EliminaDaPreferitiToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.EliminaDaPreferitiToolStripMenuItem.Text = "elimina da preferiti"
        '
        'EliminaDaCronologiaToolStripMenuItem
        '
        Me.EliminaDaCronologiaToolStripMenuItem.Name = "EliminaDaCronologiaToolStripMenuItem"
        Me.EliminaDaCronologiaToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.EliminaDaCronologiaToolStripMenuItem.Text = "elimina da cronologia"
        '
        'frmEsplora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(863, 480)
        Me.Controls.Add(Me.TabControlSql)
        Me.Name = "frmEsplora"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catalogo estrazioni"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControlSql.ResumeLayout(False)
        Me.TabPageCatalogo.ResumeLayout(False)
        Me.TabPageCatalogo.PerformLayout()
        Me.splitContainerSql.Panel1.ResumeLayout(False)
        Me.splitContainerSql.Panel2.ResumeLayout(False)
        Me.splitContainerSql.ResumeLayout(False)
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.tsMainMenu.ResumeLayout(False)
        Me.tsMainMenu.PerformLayout()
        Me.contextMenuStripFavorite.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents splitContainerSql As System.Windows.Forms.SplitContainer
    Friend WithEvents TreeViewSql As System.Windows.Forms.TreeView
    Friend WithEvents imgImageList As System.Windows.Forms.ImageList
    Friend WithEvents tsMainMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents ButtonEsci As System.Windows.Forms.ToolStripButton
    Friend WithEvents TextBoxCerca As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ButtonCercaReset As System.Windows.Forms.ToolStripButton
    Friend WithEvents LabelCerca As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TreeViewStar As System.Windows.Forms.TreeView
    Friend WithEvents TabControlSql As Utx.UtTabControl
    Friend WithEvents TabPageCatalogo As System.Windows.Forms.TabPage
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ButtonProprieta As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonEstrai As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonPreferito As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ButtonAggiornaCatalogo As System.Windows.Forms.ToolStripButton
    Friend WithEvents contextMenuStripFavorite As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EliminaDaPreferitiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminaDaCronologiaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents webBrowserDoc As System.Windows.Forms.WebBrowser
End Class
