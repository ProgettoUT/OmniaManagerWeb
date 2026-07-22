Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel

Public Class frmEsplora
    Private Const MIO_NO As String = "Altri utenti"

    Dim mEstrazioni As Dictionary(Of String, CManifestoLight)
    Dim mNodoManifestoList As New List(Of NodoManifesto)

    Dim mNodoCatalogo As Windows.Forms.TreeNode
    Dim mNodoFiltrato As Windows.Forms.TreeNode
    Dim mNodoPreferiti As Windows.Forms.TreeNode
    Dim mNodoRecenti As Windows.Forms.TreeNode

    Private WithEvents TimerCerca As New Timer
    Private WithEvents bw As New BackgroundWorker
    Private WithEvents ButtonCambiaAgenzia As New UtControls.UtFlatButton

    Public Event RichiestaCambioAgenzia()

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.Icon = Risorse.Immagini.Icon("estrai")
    End Sub

    Private Sub frmEsplora_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ParametriBase.ParametriBase.Dispose()
        ParametriBase.ParametriBase = Nothing
        PreferitiSetting(False)
    End Sub

    Private Sub frmEsplora_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If bw IsNot Nothing Then Do While bw.IsBusy : Application.DoEvents() : Loop
    End Sub

    Private Sub frmEsplora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'CheckForIllegalCrossThreadCalls = False
        Me.Font = Utx.AppFont.Normal
        imgImageList.Images.Add("agenzia", Risorse.Immagini.Icon("agenzia"))
        imgImageList.Images.Add("formazione", Risorse.Immagini.Icon("formazione"))
        imgImageList.Images.Add("estrai", Risorse.Immagini.Icon("estrai"))
        imgImageList.Images.Add("list16", Risorse.Immagini.Icon("list16"))
        imgImageList.Images.Add("cartella", Risorse.Immagini.Icon("folder_blu"))
        imgImageList.Images.Add("cartellasel", Risorse.Immagini.Icon("open"))
        imgImageList.Images.Add("favorite", Risorse.Immagini.Icon("favorite"))
        imgImageList.Images.Add("history", Risorse.Immagini.Icon("history"))
        '
        splitContainerSql.SplitterDistance = splitContainerSql.Width / 2

        LabelCerca.Font = Utx.AppFont.Bold
        ButtonEsci.Image = Risorse.Immagini.Bitmap("esci")
        ButtonEstrai.Image = Risorse.Immagini.Bitmap("estrai")
        ButtonProprieta.Image = Risorse.Immagini.Image("proprieta")
        ButtonPreferito.Image = Risorse.Immagini.Bitmap("favoriteplus")
        ButtonAggiornaCatalogo.Image = Risorse.Immagini.Bitmap("sincro")
        ButtonCercaReset.Image = Risorse.Immagini.Bitmap("cancel16")

        With TextBoxCerca
            .BackColor = Color.Black
            .ForeColor = Color.Yellow
            .Font = Utx.AppFont.Bold
        End With
        'cambio agenzia
        tsMainMenu.Items.Add(New ToolStripSeparator)
        If Utx.EnteGestore.CodiciGestiti.Count > 1 Then
            With ButtonCambiaAgenzia
                .Height = tsMainMenu.Height
                .Dock = DockStyle.Fill
                .BackColor = Color.Gold
                .TextAlign = ContentAlignment.MiddleCenter
            End With
            AggiornaBottoneCodice()
            Dim ttch As New ToolStripControlHost(ButtonCambiaAgenzia) With {.Dock = DockStyle.Fill, .Width = 150, .Alignment = ToolStripItemAlignment.Left}
            tsMainMenu.Items.Add(ttch)
        End If

        openDocumentazione(Nothing)

        LeggiCatalogoEstrazioni()

        'imposta timer ricerca
        TimerCerca.Enabled = False
        If Utx.Globale.RitardoTimer > 0 Then
            TimerCerca.Interval = Utx.Globale.RitardoTimer
        End If

        bw.RunWorkerAsync(False)
    End Sub

    Private Sub LeggiCatalogoEstrazioni()
        Application.DoEvents()
        mEstrazioni = CManifestoLight.Load()

        Dim CATALOGO_DATA As String = ""
        Dim fileEntries As String() = IO.Directory.GetFiles(CARTELLA_SETTING, "VersioneFile" & FILETOCHECK & ".*.txt")
        Array.Sort(fileEntries)

        If fileEntries.Length > 0 Then
            Dim sFileVersioneCatalogo As String = IO.Path.GetFileName(fileEntries(fileEntries.Length - 1))

            If Len(sFileVersioneCatalogo) = 25 + Len(FILETOCHECK) Then
                Dim start As Integer = 14 + Len(FILETOCHECK)
                CATALOGO_DATA = Mid(sFileVersioneCatalogo, start + 6, 2) & "/" & Mid(sFileVersioneCatalogo, start + 4, 2) & "/" & Mid(sFileVersioneCatalogo, start, 4)
            End If
        End If

        mNodoManifestoList.Clear()

        With TreeViewSql
            .Nodes.Clear()
            .Font = Utx.AppFont.Bold

            mNodoCatalogo = New TreeNode("Catalogo (versione del " & CATALOGO_DATA & ")", 0, 0)
            With mNodoCatalogo
                .ForeColor = Utx.AppColor.AzzurroScuro
            End With

            Dim nodoQueries = New TreeNode("Estrazioni", 2, 2)
            With nodoQueries
                .Expand()
                .EnsureVisible()
                .ForeColor = Utx.AppColor.RossoScuro
            End With

            For Each mfs As CManifestoLight In mEstrazioni.Values
                If String.Concat(Utente.Profili).Contains(mfs.Profilo) Then
                    AddToTreeView(mfs, nodoQueries)
                End If
            Next
            mNodoCatalogo.Nodes.Add(nodoQueries)

            .Nodes.Add(mNodoCatalogo)
        End With

        With TreeViewStar
            .Nodes.Clear()
            .Font = Utx.AppFont.Bold
            mNodoPreferiti = New TreeNode("Preferiti", 6, 6)
            With mNodoPreferiti
                .ForeColor = Utx.AppColor.RossoScuro
            End With

            mNodoRecenti = New TreeNode("Cronologia", 7, 7)
            With mNodoRecenti
                .ForeColor = Utx.AppColor.VerdeOpaco
            End With

            .Nodes.Add(mNodoPreferiti)
            .Nodes.Add(mNodoRecenti)
            mNodoPreferiti.Nodes.Add(New TreeNode(UserTag(True), 6, 6))
            mNodoPreferiti.Nodes.Add(New TreeNode(MIO_NO, 6, 6))
        End With

        PreferitiSetting(True)

        mNodoCatalogo.EnsureVisible()
        mNodoCatalogo.Expand()
        mNodoPreferiti.EnsureVisible()
        mNodoPreferiti.Expand()
        mNodoPreferiti.FirstNode.EnsureVisible()
        mNodoPreferiti.FirstNode.Expand()
        mNodoPreferiti.LastNode.EnsureVisible()
        mNodoPreferiti.LastNode.Expand()
        mNodoRecenti.EnsureVisible()
        mNodoRecenti.Expand()
    End Sub

    Private Sub AddToTreeView(manifesto As CManifestoLight, nodoPadre As Windows.Forms.TreeNode)

        Dim cartelle As String() = Split(manifesto.Pacchetto, "\")

        For Each cartella As String In cartelle
            If cartella <> vbNullString Then
                If nodoPadre.Nodes().ContainsKey(cartella) Then
                    nodoPadre = nodoPadre.Nodes(cartella)
                Else
                    nodoPadre = nodoPadre.Nodes().Add(cartella, cartella, "cartella", "cartella")
                End If
            End If
        Next

        mNodoManifestoList.Add(New NodoManifesto(AddNode(nodoPadre, manifesto), manifesto))

    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        Me.Close()
    End Sub

    Private Sub ButtonCercaReset_Click(sender As Object, e As EventArgs) Handles ButtonCercaReset.Click
        TextBoxCerca.Text = ""
        CercaEstrazione()
    End Sub

    Private Sub CercaEstrazione()
        TimerCerca.Enabled = False

        Dim filtro As String = TextBoxCerca.Text.Trim.ToUpper

        If TreeViewSql.Nodes.Contains(mNodoFiltrato) Then
            TreeViewSql.Nodes.Remove(mNodoFiltrato)
            mNodoFiltrato = Nothing
        End If

        If filtro = "" Then
            If Not TreeViewSql.Nodes.Contains(mNodoCatalogo) Then
                TreeViewSql.Nodes.Add(mNodoCatalogo)
            End If
        Else
            mNodoFiltrato = New TreeNode("Risultato ricerca per """ & filtro & """")
            For Each elemento In mNodoManifestoList
                With elemento.Manifesto
                    If CheckFiltro(.DisplayNome, filtro) Or
                        CheckFiltro(.Descrizione, filtro) Or
                        CheckFiltro(.Note, filtro) Then
                        'Or CheckFiltro(.Sql, filtro)
                        mNodoFiltrato.Nodes.Add(elemento.Nodo.Clone)
                    End If
                End With
            Next
            If mNodoFiltrato.Nodes.Count = 0 Then
                mNodoFiltrato.Nodes.Add("nessun risultato")
            End If
            mNodoFiltrato.ExpandAll()

            If TreeViewSql.Nodes.Contains(mNodoCatalogo) Then
                TreeViewSql.Nodes.Remove(mNodoCatalogo)
            End If
            If Not TreeViewSql.Nodes.Contains(mNodoFiltrato) Then
                TreeViewSql.Nodes.Add(mNodoFiltrato)
            End If
        End If
    End Sub

    Private Function CheckFiltro(prop As String, filtro As String) As Boolean
        If prop Is Nothing Then
            Return False
        End If
        If prop.ToUpper.Trim.Contains(filtro) Then
            Return True
        End If
        Return False
    End Function

    Private Sub TimerCerca_Tick(sender As Object, e As EventArgs) Handles TimerCerca.Tick
        CercaEstrazione()
    End Sub

    Private Sub TextBoxCerca_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCerca.TextChanged
        TimerCerca.Enabled = False
        TimerCerca.Enabled = (Utx.Globale.RitardoTimer > 0)
    End Sub

    Private Sub TextBoxCerca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxCerca.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            e.Handled = True
            CercaEstrazione()
        Else
            Select Case Asc(e.KeyChar)
                Case 8, 32, 39, 46, 48 To 57, 47, 64 To 90, 97 To 122
                    'backspace,spazio,numeri, lettere e @
                    e.KeyChar = e.KeyChar.ToString.ToUpper
                Case Else
                    e.KeyChar = ""
            End Select
        End If
    End Sub

    Private Sub TextBoxCerca_GotFocus(sender As Object, e As EventArgs) Handles TextBoxCerca.GotFocus
        TextBoxCerca.SelectionStart = TextBoxCerca.Text.Length
        TextBoxCerca.SelectionLength = 0
    End Sub

    Class NodoManifesto
        Public Nodo As Windows.Forms.TreeNode
        Public Manifesto As CManifestoLight

        Public Sub New(Nodo As Windows.Forms.TreeNode, Manifesto As CManifestoLight)
            Me.Nodo = Nodo
            Me.Manifesto = Manifesto
        End Sub
    End Class

    Public Sub PreferitiSetting(isLoading As Boolean)
        Try

            Dim x As New CXml

            Dim sFileUtenteName = IO.Path.Combine(CARTELLA_SETTING, "tutti.preferiti.xml")

            If isLoading Then
                If Dir(sFileUtenteName) <> vbNullString Then
                    If x.LoadXML(sFileUtenteName) Then
                        For Each n In x.GetNodes("/oggetti/oggetto")
                            Dim key = n.innerText.ToString.Substring(2)

                            If mEstrazioni.ContainsKey(key) Then
                                AddNodePreferito(mEstrazioni(key), True)
                            End If
                        Next
                        For Each n In x.GetNodes("/liste/preferiti/preferito")
                            Dim key = n.innerText.ToString
                            If mEstrazioni.ContainsKey(key) Then
                                mEstrazioni(key).PreferitoUtente = x.GetAttributeText(n, "preferitoutente")
                                AddNodePreferito(mEstrazioni(key), True)
                            End If
                        Next
                        Dim recenti As New List(Of CManifestoLight)
                        For Each n In x.GetNodes("/liste/recenti/recente")
                            Dim key = n.innerText.ToString
                            If mEstrazioni.ContainsKey(key) Then
                                mEstrazioni(key).UltimoUtilizzo = x.GetAttributeLong(n, "ultimoutilizzo")
                                mEstrazioni(key).UltimoUtente = x.GetAttributeText(n, "ultimoutente")
                                recenti.Add(mEstrazioni(key))
                            End If
                        Next

                        recenti.Sort(Function(z, y) z.UltimoUtilizzo.CompareTo(y.UltimoUtilizzo))

                        While (recenti.Count > 10)
                            recenti.RemoveAt(0)
                        End While

                        For Each estrazione As CManifestoLight In recenti
                            AddNodeRecente(estrazione, True)
                        Next
                    End If
                End If
            Else
                Dim mainNode As Xml.XmlNode = x.CreateNode("liste")

                Dim r As Xml.XmlNode = x.CreateNode("preferiti")
                For Each m As CManifestoLight In mEstrazioni.Values
                    If String.IsNullOrEmpty(m.PreferitoUtente) = False Then
                        Dim p As Xml.XmlNode = x.CreateNodeText("preferito", m.Nome)
                        p.Attributes.Append(x.CreateAttibute("preferitoutente", m.PreferitoUtente))
                        r.AppendChild(p)
                    End If
                Next

                mainNode.AppendChild(r)

                r = x.CreateNode("recenti")
                For Each nodo As TreeNode In mNodoRecenti.Nodes
                    Dim m As CManifestoLight = CType(nodo.Tag, CManifestoLight)
                    Dim p As Xml.XmlNode = x.CreateNodeText("recente", m.Nome)
                    p.Attributes.Append(x.CreateAttibute("ultimoutilizzo", m.UltimoUtilizzo.ToString()))
                    p.Attributes.Append(x.CreateAttibute("ultimoutente", m.UltimoUtente))
                    r.AppendChild(p)
                Next
                mainNode.AppendChild(r)

                x.Document.AppendChild(mainNode)
                x.SaveXML(sFileUtenteName)
            End If
            x = Nothing
        Catch ex As Exception
        End Try

    End Sub

    Private Function AddNode(nodoPadre As TreeNode, manifesto As CManifestoLight) As TreeNode
        Dim nodo As TreeNode = nodoPadre.Nodes.Add(manifesto.Nome, manifesto.DisplayNome, "list16", "list16")
        nodo.Tag = manifesto
        nodo.NodeFont = Utx.AppFont.Normal
        Return nodo
    End Function

    Private Sub AddNodeRecente(ByRef manifesto As CManifestoLight, Optional loading As Boolean = False)
        If manifesto IsNot Nothing Then
            If loading = False Then
                manifesto.UltimoUtente = UserTag(True)
                manifesto.UltimoUtilizzo = Now.Ticks
            End If

            If manifesto.Recente = False Then
                manifesto.Recente = True

                Dim UltimoUtilizzo As New DateTime(manifesto.UltimoUtilizzo)

                Dim nodo As TreeNode = mNodoRecenti.Nodes.Insert(0,
                             manifesto.Nome,
                             String.Format("{0} ({1} {2})", manifesto.DisplayNome,
                                           manifesto.UltimoUtente,
                                           UltimoUtilizzo.ToString("dd.MM.yy hh:mm:ss")),
                             "list16", "list16")
                nodo.Tag = manifesto
                nodo.NodeFont = Utx.AppFont.Normal
                If mNodoRecenti.IsExpanded = False Then
                    mNodoRecenti.Expand()
                End If
            ElseIf mNodoRecenti.Nodes(manifesto.Nome).Index > 0 Then
                Dim nodo = mNodoRecenti.Nodes(manifesto.Nome)
                nodo.Remove()
                mNodoRecenti.Nodes.Insert(0, nodo)
            End If
        End If
    End Sub

    Private Sub AddNodePreferito(ByRef manifesto As CManifestoLight, Optional loading As Boolean = False)
        If manifesto IsNot Nothing Then
            If loading = True Then
            ElseIf String.IsNullOrEmpty(manifesto.PreferitoUtente) Then
                manifesto.PreferitoUtente = UserTag()
            ElseIf manifesto.PreferitoUtente.Contains(UserTag()) = False Then
                manifesto.PreferitoUtente &= UserTag()
            Else
                Return
            End If
            Dim preferito As TreeNode
            If manifesto.PreferitoUtente.Contains(UserTag()) Then
                preferito = mNodoPreferiti.FirstNode
            Else
                preferito = mNodoPreferiti.LastNode
            End If

            Dim nodo As TreeNode = preferito.Nodes.Add(manifesto.Nome, manifesto.DisplayNome, "list16", "list16")

            'Dim nodo As TreeNode = preferito.Nodes.Add(
            '    manifesto.Key,
            '    String.Format("{0} ({1})", manifesto.DisplayNome, manifesto.PreferitoUtente),
            '    "list16", "list16")
            nodo.Tag = manifesto
            nodo.NodeFont = Utx.AppFont.Normal

            nodo.EnsureVisible()
            'nodo.Expand()
        End If
    End Sub

    Private Sub btnProprieta_Click(sender As Object, e As EventArgs) Handles ButtonProprieta.Click

        Dim mfs As CManifestoLight = getSelectedManifesto()

        If mfs IsNot Nothing Then
            Dim f As New frmProprieta() With {.Manifesto = mgrMfs.ManifestoLoad(CManifestoLight.Gruppo, mfs.Nome, Utente)}
            f.ShowDialog(Me)
        End If
    End Sub

    Private Sub ButtonEstrai_Click(sender As Object, e As EventArgs) Handles ButtonEstrai.Click
        openEstrattore(getSelectedManifesto())
    End Sub

    Private Sub TreeViewStar_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeViewStar.NodeMouseClick
        If e.Button = MouseButtons.Right Then
            EliminaDaPreferitiToolStripMenuItem.Visible = False
            EliminaDaCronologiaToolStripMenuItem.Visible = False
            If TreeViewStar.SelectedNode.Parent IsNot Nothing Then
                If TreeViewStar.SelectedNode.Parent.Text = UserTag(True) Then
                    EliminaDaPreferitiToolStripMenuItem.Visible = True
                    EliminaDaCronologiaToolStripMenuItem.Visible = False
                    contextMenuStripFavorite.Show(Cursor.Position)
                ElseIf TreeViewStar.SelectedNode.Parent.Text = "Cronologia" Then
                    EliminaDaPreferitiToolStripMenuItem.Visible = False
                    EliminaDaCronologiaToolStripMenuItem.Visible = True
                    contextMenuStripFavorite.Show(Cursor.Position)
                End If
            End If
        End If
    End Sub

    Private Sub TreeViewSql_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeViewSql.NodeMouseClick, TreeViewStar.NodeMouseClick
        openDocumentazione(e.Node.Tag)
    End Sub

    Private Sub TreeViewSql_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeViewSql.NodeMouseDoubleClick, TreeViewStar.NodeMouseDoubleClick
        openEstrattore(e.Node.Tag)
    End Sub

    Private Sub openEstrattore(mfs As CManifestoLight)
        Try
            If mfs IsNot Nothing Then
                Dim sql As CManifestoSql = mgrMfs.ManifestoLoad("queries", mfs.Nome, Utente)
                Utx.ApplicationLog.LogUso("SQL." + mfs.Nome)

                If (sql.GetAutorizzazioni(Utente) And EAutType.AUT_ESECUZIONE) = 0 Then
                    Utente.MessaggioNotAutorizzato()
                    Exit Sub
                End If

                AddNodeRecente(mfs)

                Dim titolo As String = mfs.DisplayNome
                If titolo.Length > 17 Then titolo = titolo.Substring(0, 14) + "..."

                Dim f As New frmGrid() With {.TopMost = False, .TopLevel = False, .FormBorderStyle = FormBorderStyle.None, .Dock = DockStyle.Fill}
                Dim page = New TabPage(titolo) With {.Padding = New Padding(0), .Margin = New Padding(0)}

                page.Controls.Add(f)
                TabControlSql.TabPages.Add(page)
                f.ParentPage = page
                f.Show()
                f.ExecuteMfs(sql)
                TabControlSql.SelectTab(page)
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub openDocumentazione(mfs As CManifestoLight)
        If mfs IsNot Nothing AndAlso mfs.HaDocumentazione Then
            webBrowserDoc.DocumentText = mfs.Documentazione
            webBrowserDoc.Visible = True
            tableLayoutPanel1.RowStyles(1).Height = mfs.AltezzaDocumentazione

            'For i As Integer = 0 To mfs.AltezzaDocumentazione Step 5
            '    tableLayoutPanel1.RowStyles(1).Height = i
            '    Threading.Thread.Sleep(5)
            'Next
        Else
            webBrowserDoc.Visible = False
            tableLayoutPanel1.RowStyles(1).Height = 0
        End If
    End Sub

    Private Function getSelectedManifesto() As CManifestoLight
        If TreeViewSql.Focused And TreeViewSql.SelectedNode IsNot Nothing Then
            Dim mfs As CManifestoLight = TreeViewSql.SelectedNode.Tag

            If mfs IsNot Nothing Then
                Return mfs
            End If
        End If
        If TreeViewStar.Focused And TreeViewStar.SelectedNode IsNot Nothing Then
            Dim mfs As CManifestoLight = TreeViewStar.SelectedNode.Tag

            If mfs IsNot Nothing Then
                Return mfs
            End If
        End If

        Return Nothing
    End Function

    Private Sub ButtonAggiornaCatalogo_Click(sender As Object, e As EventArgs) Handles ButtonAggiornaCatalogo.Click
        bw.RunWorkerAsync(True)
    End Sub

    Private Sub bwDoWork(sender As Object, e As DoWorkEventArgs) Handles bw.DoWork
        e.Result = UniAggio.Aggiorna(e.Argument)
    End Sub

    Private Sub bw_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw.RunWorkerCompleted
        If e.Result = True Then
            CManifestoLight.DeleteFile()
            LeggiCatalogoEstrazioni()
        End If
    End Sub

    Private Sub ButtonPreferito_Click(sender As Object, e As EventArgs) Handles ButtonPreferito.Click
        AddNodePreferito(getSelectedManifesto())
    End Sub

    Private Sub EliminaDaPreferitiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminaDaPreferitiToolStripMenuItem.Click
        If TreeViewStar.SelectedNode IsNot Nothing Then
            If MsgBox("Eliminare l'estrazione selezionata dai preferiti?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim selectedNode = TreeViewStar.SelectedNode
                Dim manifesto As CManifestoLight = selectedNode.Tag
                manifesto.PreferitoUtente = manifesto.PreferitoUtente.Replace(UserTag, "")

                selectedNode.Remove()

                'If String.IsNullOrEmpty(manifesto.PreferitoUtente.Replace("*", "")) = False Then
                '    mNodoPreferiti.LastNode.Nodes.Add(selectedNode)
                'End If
            End If
        End If
    End Sub

    Private Sub EliminaDaCronologiaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminaDaCronologiaToolStripMenuItem.Click
        If TreeViewStar.SelectedNode IsNot Nothing Then
            If MsgBox("Eliminare l'estrazione selezionata dalla cronologia?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim manifesto As CManifestoLight = TreeViewStar.SelectedNode.Tag
                manifesto.Recente = False
                TreeViewStar.SelectedNode.Remove()
            End If
        End If
    End Sub

    Private Function UserTag(Optional onlyuser As Boolean = False) As String
        If onlyuser Then
            Return Utx.Globale.UtenteCorrente.UniageUser.ToUpper
        Else
            Return "*" & Utx.Globale.UtenteCorrente.UniageUser.ToUpper & "*"
        End If
    End Function

    Private Sub ButtonCambiaAgenzia_Click(sender As Object, e As EventArgs) Handles ButtonCambiaAgenzia.Click
        RaiseEvent RichiestaCambioAgenzia()
    End Sub

    Public Sub AggiornaBottoneCodice()
        ButtonCambiaAgenzia.Text = Utx.Globale.AgenziaRichiesta.CodiceAgenzia & " - Cambia codice"
    End Sub

    Private Sub TabControlSql_TabIndexChanged(sender As Object, e As EventArgs) Handles TabControlSql.TabIndexChanged
        TabControlSql.Refresh()
    End Sub

    Private Sub frmEsplora_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        TextBoxCerca.Focus()
        ParametriBase.LeggiParametriBase()
    End Sub
End Class

