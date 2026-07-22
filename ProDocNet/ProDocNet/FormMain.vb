Imports System.Data
Imports System.Data.OleDb

Public Class FormMain

    Private Const UrlDoc As String = "http://lnx.utools.it/ametsisottegorp9933/"
    Private Const UrlCap As String = "http://www.utools.it/asp/Cap/Default.aspx"
    Private Const UrlLinkUtili As String = "http://www.utools.it/Unitools/LinkUtili/LinkUtili.htm"
    Private Const UrlPosta As String = "https://posta.unipol.it"
    Private Const UrlIama As String = "http://aiba.prezzirca.it/"
    Private Const UrlUnicont As String = "http://85.34.90.73:5000/WS_UGF"

    Private Vista As ModeView

    Private UrlChiamata As String
    Private Chiamata As Integer
    Private LoginOk As Boolean
    Private DbLink As String = "C:\ApplicazioniDirezione\Unitools\DbLink.mdb"
    Private MDBProvider As String = "Provider = Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source="
    Private UserIama As String = ""
    Private PwIama As String = ""
    Private CF As String
    Private Ramo As Integer
    Private Polizza As Integer
    Private WbZoom As Integer = 100

    Enum TipoChiamata
        Sistema = 1
        Cap = 2
        LinkUtili = 3
        Posta = 4
        Iama = 5
        ConUrl = 6
    End Enum

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        With ToolStripButtonIndietro
            .AutoSize = True
            .Text = ""
            '.TextAlign = ContentAlignment.MiddleRight
            .Image = Risorse.Immagini.Bitmap("precedente32")
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ToolStripButtonAvanti
            .AutoSize = True
            .Text = ""
            '.TextAlign = ContentAlignment.MiddleLeft
            .Image = Risorse.Immagini.Bitmap("prossimo32")
            .ImageAlign = ContentAlignment.MiddleRight
        End With
        With ToolStripButtonAggiorna
            .AutoSize = True
            .Text = "Aggiorna"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = Risorse.Immagini.Bitmap("aggiorna")
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ToolStripButtonStop
            .AutoSize = True
            .Text = "Stop"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = Risorse.Immagini.Bitmap("cancel")
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ToolStripButtonStampa
            .AutoSize = True
            .Text = "Stampa"
            .TextAlign = ContentAlignment.MiddleRight
            .Image = Risorse.Immagini.Bitmap("print")
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
        With ToolStripButtonEsci
            .AutoSize = True
            .Text = ""
            .TextAlign = ContentAlignment.MiddleRight
            .Image = Risorse.Immagini.Bitmap("esci")
            .ImageAlign = ContentAlignment.MiddleLeft
        End With
    End Sub

    Private Sub EseguiLogin()
        On Error GoTo Esci

        Cursor.Current = Cursors.WaitCursor

        LoginOk = False

        AxWebBrowser1.Navigate(UrlDoc) 'navigo URL

        Do While AxWebBrowser1.ReadyState <> WebBrowserReadyState.Complete
            Application.DoEvents()
        Loop

        Dim hdoc As mshtml.HTMLDocument = AxWebBrowser1.Document

        Dim btnLogin As mshtml.IHTMLInputElement = hdoc.getElementsByName("Submit").item("Submit")
        Dim user As mshtml.IHTMLInputElement = hdoc.getElementsByName("username").item("username")
        Dim psw As mshtml.IHTMLInputElement = hdoc.getElementsByName("passwd").item("passwd")

        user.value = "Unitools"
        psw.value = "Lmp04771561216"

        btnLogin.form.submit() 'clicca il bottone login

        Cursor.Current = Cursors.Default

        LoginOk = True

Esci:
    End Sub

    Private Sub EseguiLogout()

        On Error GoTo Esci

        Cursor.Current = Cursors.WaitCursor

        AxWebBrowser1.Navigate(UrlDoc)

        Do While AxWebBrowser1.ReadyState <> WebBrowserReadyState.Complete
            Application.DoEvents()
        Loop

        Dim hdoc As mshtml.HTMLDocument = AxWebBrowser1.Document

        Dim btnLogin As mshtml.IHTMLInputElement = hdoc.getElementsByName("Submit").item("Submit")
        btnLogin.form.submit() 'clicca il bottone esci

        Cursor.Current = Cursors.Default

Esci:
    End Sub

    Private Sub EseguiLoginIama()

        On Error GoTo Esci

        Cursor.Current = Cursors.WaitCursor

        LoginOk = False

        AxWebBrowser1.Navigate(UrlIama) 'navigo URL

        Do While AxWebBrowser1.ReadyState <> WebBrowserReadyState.Complete
            Application.DoEvents()
        Loop

        'Dim hdoc As mshtml.HTMLDocument = AxWebBrowser1.Document.DomDocument
        Dim hdoc As mshtml.HTMLDocument = AxWebBrowser1.Document

        Dim user As mshtml.IHTMLInputElement = hdoc.getElementsByName("username").item("username")
        Dim psw As mshtml.IHTMLInputElement = hdoc.getElementsByName("password").item("password")

        LeggiUtenteIama()

        user.value = UserIama
        psw.value = PwIama

        Cursor.Current = Cursors.Default

        LoginOk = True

Esci:
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If (Chiamata = TipoChiamata.Sistema) AndAlso LoginOk Then EseguiLogout()
    End Sub

    Private Sub Form1_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        ToolStrip1.Refresh()

        'per settare il tipo di visualizzazione
        Vista = New ModeView(Me, AxWebBrowser1)

        Select Case Chiamata
            Case TipoChiamata.Sistema
                EseguiLogin()
            Case TipoChiamata.Cap
                AxWebBrowser1.Navigate(UrlCap)
            Case TipoChiamata.LinkUtili
                AxWebBrowser1.Navigate(UrlLinkUtili)
            Case TipoChiamata.Posta
                AxWebBrowser1.Navigate(UrlPosta)
            Case TipoChiamata.Iama
                EseguiLoginIama()
            Case TipoChiamata.ConUrl
                ToolStripLabel1.Visible = False
                ToolStripComboBox1.Visible = False

                AxWebBrowser1.Navigate(UrlChiamata)

                Vista.SetView(ToolStripComboBox1.SelectedIndex)
        End Select

        Try
            ToolStripStatusLabel1.Text = "Completato"
            ToolStripProgressBar1.Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButtonIndietro.Click
        On Error Resume Next
        AxWebBrowser1.GoBack()
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButtonAvanti.Click
        On Error Resume Next
        AxWebBrowser1.GoForward()
    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButtonAggiorna.Click
        On Error Resume Next
        AxWebBrowser1.Refresh()
    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButtonStop.Click
        On Error Resume Next
        AxWebBrowser1.Stop()
    End Sub

    Private Sub AxWebBrowser1_DocumentComplete(sender As Object, e As AxSHDocVw.DWebBrowserEvents2_DocumentCompleteEvent) Handles AxWebBrowser1.DocumentComplete

        RegolaCaratteriBrowser(0)

        If Chiamata = TipoChiamata.Sistema Then
            If LoginOk Then
                ToolStripStatusLabel1.Text = "Completato"
                ToolStripProgressBar1.Visible = False
            Else
                ToolStripStatusLabel1.Text = "Richiesta autorizzazione..."
            End If

        ElseIf Chiamata = TipoChiamata.Iama Then

            'login fallito
            If e.uRL.ToString.StartsWith("http://aiba.prezzirca.it/login.asp?ErrorMessage") Then
                UserIama = ""
                PwIama = ""

                'login riuscito
            ElseIf e.uRL.ToString.ToUpper.Contains("USERLOGGED=TRUE") Then

                SalvaUtenteIama()

                ToolStripStatusLabel1.Text = "Completato"
                ToolStripProgressBar1.Visible = False
                AxWebBrowser1.Silent = False
            End If
        Else
            If Chiamata = TipoChiamata.ConUrl Then
                Vista.SetView(ToolStripComboBox1.SelectedIndex)
            End If
            ToolStripStatusLabel1.Text = "Completato"
            ToolStripProgressBar1.Visible = False
        End If

    End Sub

    Private Sub AxWebBrowser1_BeforeNavigate2(sender As Object, e As AxSHDocVw.DWebBrowserEvents2_BeforeNavigate2Event) Handles AxWebBrowser1.BeforeNavigate2
        If e.uRL.ToString.Substring(e.uRL.ToString.Length - 4) <> ".doc" Then
            ToolStripStatusLabel1.Text = "Caricamento in corso..."
            ToolStripProgressBar1.Visible = True
            ToolStripProgressBar1.Style = ProgressBarStyle.Marquee
        End If
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Padding = New Padding(1)
        Me.Icon = My.Resources.unitools

        With ToolStripComboBox1
            .DropDownStyle = ComboBoxStyle.DropDownList
            .ForeColor = Color.IndianRed

            .Items.Add("Icone")
            .Items.Add("Dettagli")
            .Items.Add("Icone piccole")
            .Items.Add("Elenco")
            .Items.Add("Titoli")

            .SelectedIndex = 4
        End With

        SplitContainer1.Panel1Collapsed = True

        SplitContainer1.Panel2.Controls.Add(AxWebBrowser1)
        AxWebBrowser1.Dock = DockStyle.Fill

        Try
            Dim LineaComando As String = Microsoft.VisualBasic.Command()
            Dim Var() As String = LineaComando.Split("=")

            Try
                Chiamata = Var(0)
            Catch ex As Exception
                Me.Close()
                Exit Sub
            End Try

            With ToolStripStatusLabel1
                .AutoSize = True
                .Text = "In attesa..."
            End With
            ToolStripProgressBar1.Visible = False

            Select Case Chiamata
                Case TipoChiamata.Sistema
                    If UBound(Var) < 5 Then End

                    Me.WindowState = FormWindowState.Maximized
                    Me.Text = "Sistema"

                    Me.Location = New Point(0, 0)
                    Dim x As Integer = Screen.PrimaryScreen.WorkingArea.Width - 150
                    Dim y As Integer = Screen.PrimaryScreen.WorkingArea.Height
                    Me.Size = New Size(x, y)

                Case TipoChiamata.Cap
                    Me.WindowState = FormWindowState.Maximized
                    Me.Text = "Cerca Cap"

                Case TipoChiamata.LinkUtili
                    Me.WindowState = FormWindowState.Maximized
                    Me.Text = "Link utili"

                Case TipoChiamata.Posta
                    Me.WindowState = FormWindowState.Maximized
                    Me.Text = "Posta OWA"

                Case TipoChiamata.Iama
                    Me.WindowState = FormWindowState.Maximized
                    Me.Text = "Preventivatore Rca"

                    With SplitContainer1
                        SplitContainer1.BorderStyle = BorderStyle.Fixed3D
                        SplitContainer1.Panel1Collapsed = False
                        SplitContainer1.SplitterDistance = SplitContainer1.Width * 0.2
                    End With

                    AxWebBrowser1.Silent = True

                    Label1.Text = "Selezionare una riga per copiare il dato negli appunti"
                    Label1.Refresh()

                    If UBound(Var) >= 2 Then
                        CF = Var(1)

                        If Var(2).Trim.Length > 0 Then
                            Ramo = Var(2).Split("/")(0)
                            Polizza = Var(2).Split("/")(1)
                        End If

                        LeggiCliente()
                        LeggiPolizza()
                        ListBoxDati.Refresh()
                    End If

                Case TipoChiamata.ConUrl
                    Me.WindowState = FormWindowState.Maximized
                    Me.Text = Var(1)
                    UrlChiamata = Var(2)
            End Select

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Unitools")
        End Try
    End Sub

    Private Sub ToolStripButtonEsci_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButtonEsci.Click
        AxWebBrowser1.Dispose()
        Me.Close()
    End Sub

    Private Sub LeggiUtenteIama()

        Dim cn As New OleDbConnection
        Dim cmd As New OleDbCommand
        Try
            cn.ConnectionString = MDBProvider + DbLink
            cn.Open()

            cmd.Connection = cn
            cmd.CommandType = Data.CommandType.Text
            cmd.CommandText = "SELECT Valore FROM InfoDatabase WHERE Proprieta = 'Iama'"

            Dim Utente As String = cmd.ExecuteScalar

            If String.IsNullOrEmpty(Utente) Then
                FormLogin()
            Else
                UserIama = Utente.Split(";")(0)
                PwIama = Utente.Split(";")(1)
            End If

        Catch ex As Exception
            FormLogin()
        Finally
            cn.Close()
            cn.Dispose()
            cmd.Dispose()
        End Try

    End Sub

    Private Sub FormLogin()

        Dim f As New Login
        Try
            f.StartPosition = FormStartPosition.CenterScreen
            f.Text = "Login preventivatore"
            f.ShowDialog()

            UserIama = f.txtUser.Text
            PwIama = f.txtPw.Text

            f.Dispose()

        Catch ex As Exception
            UserIama = ""
            PwIama = ""
            MsgBox(ex.Message)
        Finally
            f.Dispose()
        End Try
    End Sub

    Private Sub SalvaUtenteIama()

        If String.IsNullOrEmpty(UserIama) Then Exit Sub
        If String.IsNullOrEmpty(PwIama) Then Exit Sub

        Dim cn As New OleDbConnection
        Dim cmd As New OleDbCommand
        Try
            cn.ConnectionString = MDBProvider + DbLink
            cn.Open()

            cmd.Connection = cn
            cmd.CommandType = Data.CommandType.Text
            cmd.CommandText = "SELECT Count(*) FROM InfoDatabase WHERE Proprieta = 'Iama'"

            If cmd.ExecuteScalar = 0 Then
                cmd.CommandText = "INSERT INTO InfoDatabase(Proprieta,Valore) VALUES('Iama',?)"
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("Utente", UserIama + ";" + PwIama)

                cmd.ExecuteNonQuery()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        Finally
            cn.Close()
            cn.Dispose()
            cmd.Dispose()
        End Try

    End Sub

    Private Sub LeggiCliente()

        If String.IsNullOrEmpty(CF) Then Exit Sub

        Dim cn As New OleDbConnection
        Dim cmd As New OleDbCommand
        Try
            cn.ConnectionString = MDBProvider + DbLink
            cn.Open()

            With cmd
                .Connection = cn
                .CommandType = Data.CommandType.Text
                .CommandText = "SELECT * FROM Clienti WHERE CodiceFiscale = ?"
                .Parameters.AddWithValue("CF", CF)
            End With

            Dim dr As OleDbDataReader = cmd.ExecuteReader

            VisualizzaDatiClienti(dr)

            dr.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
            cn.Dispose()
            cmd.Dispose()
        End Try

    End Sub

    Private Sub LeggiPolizza()

        If Ramo = 0 Then Exit Sub

        Dim cn As New OleDbConnection
        Dim cmd As New OleDbCommand
        Try
            cn.ConnectionString = MDBProvider + DbLink
            cn.Open()

            With cmd
                .Connection = cn
                .CommandType = Data.CommandType.Text
                .CommandText = "SELECT p.*,a.modello " + _
                               "FROM Polizze p " + _
                               "INNER JOIN Avvisi a ON p.Ramo = a.Ramo And p.Polizza = a.Polizza " + _
                               "WHERE p.Ramo = ? And p.Polizza = ?"
                .Parameters.AddWithValue("Ramo", Ramo)
                .Parameters.AddWithValue("Polizza", Polizza)
            End With

            Dim dr As OleDbDataReader = cmd.ExecuteReader

            VisualizzaDatiPolizza(dr)

            dr.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cn.Close()
            cn.Dispose()
            cmd.Dispose()
        End Try

    End Sub

    Private Sub VisualizzaDatiPolizza(dr As OleDbDataReader)

        On Error Resume Next

        dr.Read()

        With ListBoxDati
            .Items.Add("")
            .Items.Add("Polizza: " + Ramo.ToString + "/" + Polizza.ToString)
            .Items.Add(StrDup(80, "-"))
            .Items.Add("Effetto: " + Format(dr("DataEffetto"), "dd-MM-yyyy"))
            .Items.Add("Frazionamento: " + dr("Frazionamento").ToString)
            .Items.Add("Targa: " + dr("Targa").ToString)
            .Items.Add("Cavalli fiscali: " + dr("CavalliFiscali").ToString)
            .Items.Add("Clausole: " + dr("Clausole").ToString)
            .Items.Add("Classe BM: " + dr("ClasseBonusMalus").ToString)
            .Items.Add("Combinazione massimali: " + dr("CombinazioneMassimali").ToString)
            .Items.Add("Alimentazione: " + dr("AlimentazioneVeicolo").ToString)
            .Items.Add("Immatricolazione: " + dr("ImmatricVeicolo").ToString.Substring(4, 2) + " " + _
                                              dr("ImmatricVeicolo").ToString.Substring(0, 4))
            .Items.Add("Modello: " + dr("Modello").ToString)
        End With

    End Sub

    Private Sub VisualizzaDatiClienti(dr As OleDbDataReader)

        On Error Resume Next

        dr.Read()

        With ListBoxDati
            .Items.Add("Cliente: " + dr("Cognome").ToString + " " + dr("Nome").ToString)
            .Items.Add(StrDup(80, "-"))
            .Items.Add("Sesso: " + dr("Sesso").ToString)
            .Items.Add("Provincia: " + dr("Provincia").ToString)
            .Items.Add("Localita: " + dr("Localita").ToString)
            If IsDate(dr("DataNascita")) Then
                .Items.Add("DataNascita: " + Format(dr("DataNascita"), "dd-MM-yyyy"))
            Else
                .Items.Add("DataNascita: ")
            End If
            .Items.Add("StatoCivile: " + dr("StatoCivile").ToString)
            .Items.Add("TipoCliente: " + dr("TipoCliente").ToString)
            .Items.Add("RilascioPatente: " + dr("RilascioPatente").ToString)
        End With

    End Sub

    Private Sub ListBoxDati_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ListBoxDati.SelectedIndexChanged
        Try
            If ListBoxDati.SelectedIndex >= 0 Then
                Clipboard.Clear()

                System.Threading.Thread.Sleep(50)

                Clipboard.SetData("Text", ListBoxDati.Text.Split(":")(1).Trim)
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub AxWebBrowser1_NewWindow2(sender As System.Object, e As AxSHDocVw.DWebBrowserEvents2_NewWindow2Event) Handles AxWebBrowser1.NewWindow2
        Dim F As New frmPopup
        F.Text = ""
        F.StartPosition = FormStartPosition.CenterScreen
        F.Show() 'important to call show method before the following lines to ensure
        e.ppDisp = F.AxWebBrowser1.Application
        F.AxWebBrowser1.RegisterAsBrowser = True
    End Sub

    Private Sub ToolStripButton6_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButtonStampa.Click
        SendKeys.Send("^p")
    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
        On Error Resume Next
        Vista.SetView(ToolStripComboBox1.SelectedIndex)
    End Sub

    Public Sub RegolaCaratteriBrowser(Incremento As Integer)
        On Error Resume Next

        WbZoom = WbZoom + Incremento

        PiuToolStripMenuItem.Text = String.Format("Aumenta zoom (attuale {0}%)", WbZoom)

        'imposto il valore di default per i caratteri
        AxWebBrowser1.ExecWB(SHDocVw.OLECMDID.OLECMDID_ZOOM,
                             SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER,
                             2, vbNull)

        'imposto il nuovo valore dello zoom
        AxWebBrowser1.ExecWB(SHDocVw.OLECMDID.OLECMDID_OPTICAL_ZOOM,
                             SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DONTPROMPTUSER,
                             WbZoom, vbNull)

    End Sub

    Private Sub PiuToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PiuToolStripMenuItem.Click
        RegolaCaratteriBrowser(+10)
    End Sub

    Private Sub MenoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MenoToolStripMenuItem.Click
        RegolaCaratteriBrowser(-10)
    End Sub
End Class
