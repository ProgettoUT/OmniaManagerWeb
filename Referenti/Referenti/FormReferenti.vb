Public Class FormReferenti

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        If Utx.Globale.IdAppOk = False Then
            Application.Exit()
        End If

        Me.Size = New Size(800, 550)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.Text = "Referenti d'agenzia"
        Me.Icon = Risorse.Immagini.Icon("referenti")
        Me.Font = New Font("Tahoma", 9)
        Me.Padding = New Padding(3)
        Me.AcceptButton = ButtonCerca

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()

        On Error Resume Next

        With TextBoxAgenzia
            .TextAlign = HorizontalAlignment.Center
            .BackColor = Color.LightYellow
        End With
        With ButtonCerca
            .Margin = New Padding(0)
            .Padding = New Padding(10, 0, 10, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Image = Risorse.Immagini.Bitmap("cerca32")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Cerca referenti"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        With ButtonEsci
            .Margin = New Padding(0)
            .Padding = New Padding(10, 0, 10, 0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Image = Risorse.Immagini.Bitmap("esci")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Esci"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        Utx.NetFunc.DoppioBuffer(dgvLiquidatori)
        TabMain.ColorStyle = Utx.UtTabControl.TabColorStyle.ROSSO
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBoxAgenzia.Text = Utx.Globale.AgenziaRichiesta.CodiceAgenzia
    End Sub

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        TabMain.SelectedTab = TabPageReferenti
        TabMain.Visible = True
        CercaReferenti()
    End Sub

    Private Sub ButtonCerca_Click(sender As Object, e As EventArgs) Handles ButtonCerca.Click
        CercaReferenti()
    End Sub

    Private Sub CercaReferenti()
        Try
            If String.IsNullOrEmpty(TextBoxAgenzia.Text) Then
                TextBoxAgenzia.Focus()
                Exit Sub
            End If
            If (Not IsNumeric(TextBoxAgenzia.Text)) OrElse (TextBoxAgenzia.Text < 1) OrElse (TextBoxAgenzia.Text > 99999) Then
                TextBoxAgenzia.Text = ""
                TextBoxAgenzia.Focus()
                Exit Sub
            End If

            Utx.Globale.Log.Info(String.Format("recupero referenti dell'agenzia {0}", TextBoxAgenzia.Text))

            Cursor = Cursors.WaitCursor

            Dim ds As New DataSet
            Using s As New Utx.SettingAgenzia.ConfiguraSede
                s.Proxy = Utx.Globale.UniProxy.Proxy
                ds = s.Referenti(TextBoxAgenzia.Text)
            End Using

            Utx.Globale.Log.Info(String.Format("referenti trovati: {0}", ds.Tables(0).Rows.Count))

            Dim Immagini As New ImageList
            Immagini.Images.Add("agenzia", Risorse.Immagini.Bitmap("agenzia"))
            Immagini.Images.Add("lob", Risorse.Immagini.Image("pie_chart_blue"))
            Immagini.Images.Add("liq", Risorse.Immagini.Bitmap("cliente"))
            Immagini.Images.Add("tra", Risorse.Immagini.Bitmap("trasparente"))

            tvReferenti.BeginUpdate()
            tvReferenti.ImageList = Immagini
            tvReferenti.Indent = 25

            Dim Base As New TreeNode
            With Base
                .NodeFont = New Font(tvReferenti.Font.Name, tvReferenti.Font.Size, FontStyle.Bold)
                .Text = String.Format("Agenzia {0} - Referenti sinistri {1}",
                                      TextBoxAgenzia.Text.PadLeft(5, "0"), ds.Tables(0).Rows.Count)
                .ImageKey = "agenzia"
                .SelectedImageKey = "agenzia"
            End With

            If ds.Tables(0).Rows.Count > 0 Then
                With Base
                    .Nodes.Add(AggiungiLOB(ds, "AUTO"))
                    .Nodes.Add(AggiungiLOB(ds, "RCG/INF"))
                    .Nodes.Add(AggiungiLOB(ds, "ADB"))
                    .Nodes.Add(AggiungiLOB(ds, "ADB - CORPORATE"))
                End With
            End If

            With tvReferenti
                .Nodes.Clear()
                .Nodes.Add(Base)
            End With

            tvReferenti.ExpandAll()
            tvReferenti.SelectedNode = Base
            tvReferenti.EndUpdate()

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Function AggiungiLOB(ds As DataSet, LOB As String) As TreeNode

        Dim n As New TreeNode

        Try
            'nodo lob
            n.Text = String.Format("LOB: {0}", LOB)
            n.ForeColor = Color.Red
            n.ImageKey = "lob"
            n.SelectedImageKey = "lob"
            n.NodeFont = New Font(tvReferenti.Font.Name, tvReferenti.Font.Size, FontStyle.Bold)

            For Each r As DataRow In ds.Tables(0).Rows

                'se il record fa parte del lob
                If r("LOB") = LOB Then

                    Dim n1 As New TreeNode With {
                        .Text = String.Format("Liquidatore: {0}", r("Liquidatore")),
                        .ForeColor = Color.Blue,
                        .ImageKey = "liq",
                        .SelectedImageKey = "liq"}

                    Dim n2 As New TreeNode With {
                        .Text = String.Format("Ispettorato: {0} - {1}", r("CodiceEnte"), r("Ente")),
                        .ImageKey = "tra",
                        .SelectedImageKey = "tra"}

                    Dim n3 As New TreeNode With {
                        .Text = String.Format("Indirizzo: {0}", r("Indirizzo")),
                        .ImageKey = "tra",
                        .SelectedImageKey = "tra"}

                    Dim n4 As New TreeNode With {
                        .Text = String.Format("Responsabile: {0}", r("Responsabile")),
                        .ImageKey = "tra",
                        .SelectedImageKey = "tra"}

                    Dim n5 As New TreeNode With {
                        .Text = "",
                        .ImageKey = "tra",
                        .SelectedImageKey = "tra"}

                    With n1
                        .Nodes.Add(n2)
                        .Nodes.Add(n3)
                        .Nodes.Add(n4)
                        .Nodes.Add(n5)
                    End With

                    'aggiungo il nodo al lob
                    n.Nodes.Add(n1)
                End If
            Next

            Return n

        Catch ex As Exception
            n.Text = ex.Message
            Return n
        End Try
    End Function

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        Me.Close()
    End Sub

    Private Sub TabPageLiquidatori_Enter(sender As Object, e As EventArgs) Handles TabPageLiquidatori.Enter
        Try
            If dgvLiquidatori.DataSource Is Nothing Then
                Cursor = Cursors.WaitCursor
                dgvLiquidatori.DataSource = Utx.WsCommand.ExecuteNonQuery("SELECT * FROM Liquidatori ORDER BY Nome").DataTable
                dgvLiquidatori.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                TabPageLiquidatori.Text = String.Format("Liquidatori ({0})", dgvLiquidatori.Rows.Count)
            End If
        Catch ex As Exception
            dgvLiquidatori.DataSource = Nothing
            Utx.Globale.Log.Errore(ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
End Class
