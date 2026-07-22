Imports System.IO
Imports System.Diagnostics

Public Class Form1

    Private CfCliente As String
    Private NomeCliente As String
    Private img As Drawing.Image
    Private objGuid As Guid
    Private objDimension As System.Drawing.Imaging.FrameDimension
    Private totFrame As Integer

    Private Cliente As Clienti
    Private Deposito As DepositoDocumenti
    Private Pratica As Pratiche

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'SplitContainer1.BackColor = Color.Gold
        'SplitContainer2.BackColor = Color.Aquamarine
        'SplitContainer3.BackColor = Color.Gold

        With PictureBox1
            .Dock = DockStyle.Fill
            .Visible = True
        End With

        AxAcroPDF1.Dock = DockStyle.Fill
        AxAcroPDF1.Visible = False

        With ToolStripComboBox2.Items
            .Add("Normale")
            .Add("Adatta")
            .Add("Auto")
            .Add("Centra")
            .Add("Pagina intera")
        End With
        ToolStripComboBox2.SelectedIndex = 4

        ListBox1.DisplayMember = "Nome"

        CfCliente = "03548130289"
        NomeCliente = "Cliente test"

        Deposito = New DepositoDocumenti(Unita.Locale, DepositoDocumenti.Depositi.Principale)
        Cliente = New Clienti(Deposito, "03548130289")
        Pratica = New Pratiche(Deposito, Cliente, "Sinistro 3998.2007.94393")

    End Sub

    Private Sub Form1_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

        CaricaPraticheCliente(Cliente)

        'CfCliente = "Documenti personali"
        'NomeCliente = "Documenti dell'agenzia"

        MyTreeView.ExpandAll()
        MyTreeView.SelectedNode = MyTreeView.Nodes(0)
        MyTreeView.Focus()
    End Sub

    Public Sub CaricaPraticheCliente(ByVal Cliente As Clienti)

        If Directory.Exists(Cliente.FullPathCliente) Then

            Dim NodoCliente As New TreeNode
            NodoCliente.Text = Cliente.CodiceFiscale
            NodoCliente.Tag = New Pratiche(Deposito, Cliente)

            MyTreeView.Nodes.Add(NodoCliente)

            For Each Dir As String In Directory.GetDirectories(Cliente.FullPathCliente)

                Dim n As New TreeNode
                n.Text = New DirectoryInfo(Dir).Name
                n.Tag = New Pratiche(Deposito, Cliente, n.Text)

                NodoCliente.Nodes.Add(n)
            Next
        Else
            MsgBox("Cartella documenti non trovata.", MsgBoxStyle.Exclamation)
        End If

    End Sub

    'Public Sub LoadFolderTree(ByVal Path As String)
    '    Dim BaseNode As New System.Windows.Forms.TreeNode
    '    If Directory.Exists(Path) Then
    '        'If Path.Length <= 3 Then
    '        '    BaseNode = MyTreeView.Nodes.Add(Path)
    '        'Else
    '        '    BaseNode = MyTreeView.Nodes.Add(My.Computer.FileSystem.GetName(Path))
    '        'End If
    '        BaseNode = MyTreeView.Nodes.Add(NomeCliente)
    '        BaseNode.Tag = Path
    '        LoadDir(Path, BaseNode)
    '        'LoadFile(Path, BaseNode)
    '    Else
    '        MsgBox("Cartella documenti non trovata.", MsgBoxStyle.Exclamation)
    '    End If
    'End Sub

    'Private Sub MyTreeView_AfterExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles MyTreeView.AfterExpand
    '    For Each n As System.Windows.Forms.TreeNode In e.Node.Nodes
    '        LoadDir(n.Tag, n)
    '        'LoadFile(n.Tag, n)
    '    Next
    'End Sub

    Public Sub LoadDir(ByVal DirPath As String, ByVal Node As Windows.Forms.TreeNode)
        On Error Resume Next
        If DirPath Is Nothing Then Exit Sub

        Dim Index As Integer
        If Node.Nodes.Count = 0 Then
            For Each Dir As String In My.Computer.FileSystem.GetDirectories(DirPath)
                Dim x As New DirectoryInfo(Dir)
                Node.Nodes.Add(x.Name)

                'Index = Dir.LastIndexOf("\")
                'Node.Nodes.Add(Dir.Substring(Index + 1, Dir.Length - Index - 1))
                Node.LastNode.Tag = Dir
                'Node.LastNode.ImageIndex = 0
            Next
        End If
    End Sub

    Public Sub CaricaDocumentiPratica(ByVal Pratica As Pratiche)

        If String.IsNullOrEmpty(Pratica.FullPathPratica) Then Exit Sub

        ListBox1.Items.Clear()

        For Each f As String In Directory.GetFiles(Pratica.FullPathPratica)

            ListBox1.Items.Add(New Documento(Pratica, Path.GetFileName(f)))
        Next

    End Sub

    Public Sub LoadFile(ByVal DirPath As String)
        Exit Sub

        On Error Resume Next
        If DirPath Is Nothing Then Exit Sub

        ListBox1.Items.Clear()
        For Each f As String In Directory.GetFiles(DirPath)
            'ListBox1.Items.Add(New Documento(f))

            'Node.LastNode.Tag = x.FullName
        Next

        'Public Sub LoadFile(ByVal DirPath As String, ByVal Node As Windows.Forms.TreeNode)
        '    On Error Resume Next
        '    If DirPath Is Nothing Then Exit Sub

        '    If Node.Nodes.Count = 0 Then
        '        For Each f As String In My.Computer.FileSystem.GetFiles(DirPath)
        '            Dim x As New IO.FileInfo(f)
        '            Node.Nodes.Add(x.Name)
        '            Node.LastNode.Tag = x.FullName
        '        Next
        '    End If
    End Sub

    Private Sub MyTreeView_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles MyTreeView.AfterSelect
        'documenti della pratica. nel caso del nodo cliente la pratica è il cliente stesso
        CaricaDocumentiPratica(e.Node.Tag)

        img = Nothing

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

        If ListBox1.SelectedIndex < 0 Then Exit Sub

        Dim d As New Documento(MyTreeView.SelectedNode.Tag, ListBox1.Text)

        If d.IsImmagine Then
            SplitContainer3.SplitterDistance = ToolStrip1.Height
            SplitContainer3.Panel1Collapsed = False

            img = Image.FromFile(d.FullPathDoc)
            objGuid = (img.FrameDimensionsList(0))
            objDimension = New System.Drawing.Imaging.FrameDimension(objGuid)
            totFrame = img.GetFrameCount(objDimension)

            ToolStripLabel1.Text = "/" + totFrame.ToString

            ToolStripComboBox1.Items.Clear()
            For k As Integer = 1 To totFrame
                ToolStripComboBox1.Items.Add(k)
            Next
            ToolStripComboBox1.SelectedIndex = 0

            'img.SelectActiveFrame(objDimension, ToolStripComboBox1.Text - 1)

            AxAcroPDF1.Visible = False
            PictureBox1.Visible = True

        ElseIf d.Formato = "PDF" Then
            SplitContainer3.Panel1Collapsed = True

            AxAcroPDF1.LoadFile(d.FullPathDoc)
            AxAcroPDF1.Dock = DockStyle.Fill
            AxAcroPDF1.Visible = True

            PictureBox1.Visible = False
            PictureBox1.Image = Nothing

        Else
            AxAcroPDF1.Visible = False
            PictureBox1.Image = Nothing
            PictureBox1.Visible = True

        End If
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        TabControl1.Visible = Not TabControl1.Visible
    End Sub

    Private Sub ToolStripComboBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripComboBox1.TextChanged
        If ToolStripComboBox1.Text = String.Empty Then Exit Sub
        If ToolStripComboBox1.Text = 0 OrElse _
           ToolStripComboBox1.Text > ToolStripComboBox1.Items.Count Then Exit Sub

        PictureBox1.Image = AnteprimaImmagine(img)
    End Sub

    Private Function AnteprimaImmagine(ByRef Immagine As Image)

        img.SelectActiveFrame(objDimension, ToolStripComboBox1.Text - 1)

        'Using g As Graphics = Graphics.FromImage(img)
        '    g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic

        '    ' g is set to draw onto finalImg, which will store the scaled version of img
        '    g.DrawImage(img, 0, 0, img.Width, img.Height)
        'End Using

        Try
            Dim tumH, tumW As Integer
            If img.Height > img.Width Then
                tumH = PictureBox1.Height
                tumW = tumH * (img.Width / img.Height)
            Else
                tumW = PictureBox1.Width
                tumH = tumW * (img.Height / img.Width)
            End If

            Dim cb As System.Drawing.Image.GetThumbnailImageAbort
            Dim cd As System.IntPtr

            Return img.GetThumbnailImage(tumW, tumH, cb, cd)

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

    End Function

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If ToolStripComboBox1.SelectedIndex = ToolStripComboBox1.Items.Count - 1 Then Exit Sub
        ToolStripComboBox1.SelectedIndex = ToolStripComboBox1.SelectedIndex + 1
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If ToolStripComboBox1.SelectedIndex = 0 Then Exit Sub
        ToolStripComboBox1.SelectedIndex = ToolStripComboBox1.SelectedIndex - 1
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Process.Start(ListBox1.SelectedItem.FullPathDoc)

        '        Imports System.Diagnostics
        '        Process.Start(My.Application.Info.DirectoryPath & _
        '"\Prova.docx")

        'Dim p As New Process()
        'With p.StartInfo
        '    .Arguments = d.NomeCompleto
        '    .UseShellExecute = True
        '    .WindowStyle = ProcessWindowStyle.Normal
        '    '.WorkingDirectory = _
        '    '    "C:\Program Files (x86)\Adobe\Reader 9.0\Reader\"
        '    .FileName = "AcroRd32.exe"
        'End With
        'p.Start()
        'p.Close()
        'p.Dispose()

    End Sub

    Private Sub ToolStripComboBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripComboBox2.SelectedIndexChanged
        Select Case ToolStripComboBox2.SelectedIndex
            Case 0
                PictureBox1.SizeMode = PictureBoxSizeMode.Normal
            Case 1
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            Case 2
                PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize
            Case 3
                PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
            Case 4
                PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        End Select
    End Sub

    Public Function IdDocCliente(ByVal CF As String, _
                                 Optional ByVal RootDoc As String = _
                                 "C:\ApplicazioniDirezione\Unitools\Documenti") As String
        'restituisce la posizione dei documenti del cliente indicato con il CF

        CF = CF.Trim

        Dim DocCliente As String
        DocCliente = Path.Combine(RootDoc, Microsoft.VisualBasic.Right(CF, 1)) 'cartella con l'ultima lettera del CF

        'aggiunge la cartella se è assente
        If Not Directory.Exists(DocCliente) Then Directory.CreateDirectory(DocCliente)
        'aggiunge il CF come ultima parte del percorso
        IdDocCliente = Path.Combine(DocCliente, CF)
    End Function

    Private Sub PictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
        'On Error Resume Next

        'Dim font As New Font("Arial", 8)
        'Dim blackBrush As New SolidBrush(Color.Black)
        'Dim X As Integer = 0
        'Dim Y As Integer = 0

        'Dim propItems As System.Drawing.Imaging.PropertyItem() = img.PropertyItems
        ''For each PropertyItem in the array, display the id, type, and length.
        'Dim count As Integer = 0
        'Dim propItem As System.Drawing.Imaging.PropertyItem

        'propItems.SetValue(888, 0)
        'For Each propItem In propItems

        '    e.Graphics.DrawString("Property Item " + count.ToString(), _
        '       Font, blackBrush, X, Y)
        '    Y += Font.Height

        '    e.Graphics.DrawString("   iD: 0x" & propItem.Id.ToString("x"), _
        '       Font, blackBrush, X, Y)
        '    Y += Font.Height

        '    e.Graphics.DrawString("   type: " & propItem.Type.ToString(), _
        '       Font, blackBrush, X, Y)
        '    Y += Font.Height

        '    e.Graphics.DrawString("   length: " & propItem.Len.ToString() & _
        '        " bytes", Font, blackBrush, X, Y)
        '    Y += Font.Height

        '    Dim b As Byte
        '    For Each b In propItem.Value
        '        e.Graphics.DrawString("   value: " & b.ToString, font, blackBrush, X, Y)
        '        Y += font.Height
        '    Next

        '    count += 1
        'Next propItem

    End Sub

End Class
