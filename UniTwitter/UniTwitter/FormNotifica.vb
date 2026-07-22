Public Class FormNotifica

    Friend News As PaginaNews

    Private Const LinkUtwitt As String = "http://lnx.utools.it/utwitt/"
    Private tt As New ToolTip
    Private HelpTag As String = "Inserisci i tag da cercare"

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        With Me
            .Padding = New Padding(0)
            .FormBorderStyle = FormBorderStyle.None
            .ShowInTaskbar = True
            .Size = New Size(400, Screen.PrimaryScreen.WorkingArea.Height * 0.5)
            .MinimumSize = New Size(.Width, .Height)
            .StartPosition = FormStartPosition.Manual
            .Location = New Point(Screen.PrimaryScreen.WorkingArea.Right - .Width - 180,
                                  Screen.PrimaryScreen.WorkingArea.Height - .Height)
            .TopMost = True
            .Text = ""
            .Icon = My.Resources.utw
        End With

        If ImpostaControlli() = False Then
            Me.Close()
        End If
    End Sub

    Private Sub FormNotifica_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Timer1.Dispose()
    End Sub

    Private Sub FormNotifica_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Me.Refresh()

        WebBrowser1.DocumentText = News.Pagina.ToString
        Me.TopMost = False
    End Sub

    Private Function ImpostaControlli() As Boolean

        Try
            WebBrowser1.Margin = New Padding(0)
            WebBrowser1.ScriptErrorsSuppressed = True

            With Panel1
                .BorderStyle = BorderStyle.FixedSingle
                .BackColor = Color.DarkGray
                .Padding = New Padding(3)
                .Margin = New Padding(0)
            End With
            With LabelTestata
                .BorderStyle = BorderStyle.None
                .BackColor = Color.Gainsboro
                .Image = My.Resources.logo_uniarea
            End With
            With LabelTitolo
                .FlatStyle = FlatStyle.Flat
                .BorderStyle = BorderStyle.None
                .BackColor = Color.SteelBlue
                .ForeColor = Color.White
            End With
            With ButtonVediTutti
                .BackColor = Color.DarkRed
                .ForeColor = Color.White
                .Text = "Vedi tutti i twitt"
            End With
            With ButtonEsci
                .BackColor = Color.SteelBlue
                .ForeColor = Color.White
                .Text = "Chiudi"
            End With
            With ButtonCerca
                .BackColor = Color.Gainsboro
                .Text = "Cerca i tag"
            End With
            With TextBoxTag
                .BorderStyle = BorderStyle.FixedSingle
                .BackColor = Color.Moccasin
                .ForeColor = Color.Gray
                .Text = HelpTag
            End With
            With CheckBoxTopMost
                .BackColor = Color.Gainsboro
                .Image = My.Resources.spillo16.ToBitmap
                .ImageAlign = ContentAlignment.MiddleCenter
                .Text = ""
                .Checked = False
            End With

            Timer1.Interval = 200
            Timer1.Enabled = True

            Return True

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim Titolo As String = "uTwitt - Notizie Uniarea"
        Dim Taglio As Integer

        If LabelTitolo.Text.Length < Titolo.Length Then
            Taglio = LabelTitolo.Text.Length + 1
        Else
            Taglio = 0
        End If

        LabelTitolo.Text = Titolo.Substring(0, Taglio)
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        Me.Close()
    End Sub

    Private Sub CheckBoxTopMost_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBoxTopMost.CheckedChanged
        If CheckBoxTopMost.Checked Then
            CheckBoxTopMost.BackColor = Color.Orange
            tt.SetToolTip(CheckBoxTopMost, "sblocca primo piano")
        Else
            CheckBoxTopMost.BackColor = Color.Gainsboro
            tt.SetToolTip(CheckBoxTopMost, "blocca in primo piano")
        End If
        Me.TopMost = CheckBoxTopMost.Checked
    End Sub

    Private Sub ButtonVediTutti_Click(sender As Object, e As EventArgs) Handles ButtonVediTutti.Click
        Process.Start(LinkUtwitt)
    End Sub

    Private Sub TextBoxTag_MouseDown(sender As Object, e As MouseEventArgs) Handles TextBoxTag.MouseDown
        TextBoxTag.SelectAll()
    End Sub

    Private Sub ButtonCerca_Click(sender As Object, e As EventArgs) Handles ButtonCerca.Click
        If TextBoxTag.Text <> HelpTag Then
            Process.Start(String.Format("{0}?s={1}", LinkUtwitt, TextBoxTag.Text.Replace(" ", "+")))
        End If
    End Sub

#Region "Spostamento finestra"
    'Declare the variables
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub LabelTestata_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LabelTestata.MouseDoubleClick
        Me.Top = 0
        Me.Height = Screen.PrimaryScreen.WorkingArea.Height
    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles LabelTestata.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles LabelTestata.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles LabelTestata.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub
#End Region

End Class