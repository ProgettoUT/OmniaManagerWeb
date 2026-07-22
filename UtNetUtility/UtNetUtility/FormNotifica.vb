Imports System.Windows.Forms
Imports System.Drawing

Friend Class FormNotifica

    Public Event Annulla()

    Sub New(Optional ByVal BottoneAnnulla As Boolean = True,
            Optional ByVal Bordo As Boolean = True)

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        TableLayoutPanel1.GetType.InvokeMember("DoubleBuffered",
            Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty,
            Nothing,
            TableLayoutPanel1,
            New Object() {True})

        'label messaggio
        With LabelMessaggio
            .AutoSize = False
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = Color.Transparent
            .ForeColor = Color.Black
            .Font = New Font("Tahoma", 9)
            .Text = "..."
            .TextAlign = ContentAlignment.MiddleCenter
        End With

        'bottone annulla
        With btnAnnulla
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Margin = New Padding(0)
            .Padding = New Padding(10, 0, 10, 0)
            .Text = "Annulla"
            .TextAlign = ContentAlignment.MiddleLeft
            .Image = My.Resources.logo
            .ImageAlign = ContentAlignment.MiddleRight
            .Dock = DockStyle.Fill
        End With

        ConsentiAnnullamento = BottoneAnnulla

        Dim Video As Screen = Screen.PrimaryScreen

        With Me
            .Size = New Size(365, 125)
            .StartPosition = FormStartPosition.Manual
            .WindowState = FormWindowState.Normal
            .Font = New Font("Tahoma", 9)
            'posizione di default
            .Top = Video.WorkingArea.Bottom - Me.Height - 20
            .Left = Video.WorkingArea.Right - Me.Width - 20
            'varie
            .Text = "Unitools"
            .Opacity = 1
            .ShowInTaskbar = True
            .Icon = My.Resources.notifica

            If Bordo = True Then
                .FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
            Else
                .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            End If
        End With

        ImpostaControlli()
    End Sub

    Private mAnnulla As Boolean
    Public Property ConsentiAnnullamento() As Boolean
        Get
            Return mAnnulla
        End Get
        Set(ByVal value As Boolean)
            mAnnulla = value
            ImpostaControlli()
        End Set
    End Property

    Public WriteOnly Property ColoreSfondo() As Color
        Set(ByVal value As Color)
            LabelMessaggio.BackColor = value
        End Set
    End Property

    Private Sub frmNotifica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        Timer1.Enabled = False
    End Sub

    Private Sub ImpostaControlli()

        If mAnnulla = True Then
            'visualizzo il bottone annulla
            btnAnnulla.Visible = True
            TableLayoutPanel1.SetRowSpan(LabelMessaggio, 1)
        Else
            'nascondo il bottone annulla
            btnAnnulla.Visible = False
            TableLayoutPanel1.Controls.Remove(btnAnnulla)
            TableLayoutPanel1.SetRowSpan(LabelMessaggio, 2)
        End If

        TableLayoutPanel1.Refresh()
    End Sub

    Private Sub frmNotifica_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Timer1.Enabled = False Then
            RaiseEvent Annulla()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As System.EventArgs) Handles Timer1.Tick
        Me.Close()
    End Sub

    Private Sub btnAnnulla_Click(sender As System.Object, e As System.EventArgs) Handles btnAnnulla.Click
        RaiseEvent Annulla()
    End Sub

    Private Sub LabelMessaggio_Click(sender As Object, e As System.EventArgs) Handles LabelMessaggio.Click
        'minimizzo solo se non è già in fase di chiusura e quindi il timer è già partito
        If Timer1.Enabled = False Then
            Me.WindowState = FormWindowState.Minimized
        End If
    End Sub

    Private Sub LabelMessaggio_TextChanged(sender As Object, e As System.EventArgs) Handles LabelMessaggio.TextChanged
        LabelMessaggio.Refresh()
        Application.DoEvents()
    End Sub

End Class