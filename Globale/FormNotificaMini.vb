Imports System.Drawing
Imports System.Windows.Forms

Public Class FormNotificaMini

    Public Enum TipoNotifica
        OK
        ERRORE
        ATTENZIONE
    End Enum

    Private WithEvents MyTimer As Timer
    Private ReadOnly _SecondiChiusura As Integer
    Private ReadOnly _Tipo As TipoNotifica
    Private ReadOnly _TopMost As Boolean

    Sub New(Tipo As TipoNotifica, Optional SecondiChiusura As Integer = 2, Optional PrimoPiano As Boolean = False)

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        With Me
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            .StartPosition = FormStartPosition.Manual
            .WindowState = FormWindowState.Normal
            'varie
            .Text = ""
            .Opacity = 1
            .ShowInTaskbar = False
            .Padding = New Padding(0)
            .BackColor = Color.White
            '.Size = New Size(20, 30)
        End With
        CheckForIllegalCrossThreadCalls = False

        _Tipo = Tipo
        _SecondiChiusura = SecondiChiusura
        _TopMost = PrimoPiano
    End Sub

    Private mColoreBordo As Color
    Public Property ColoreBordo() As Color
        Get
            Return mColoreBordo
        End Get
        Set(value As Color)
            mColoreBordo = value
            Me.BackColor = mColoreBordo
        End Set
    End Property

    Public Property ColoreSfondo() As Color
        Get
            Return Me.BackColor
        End Get
        Set(value As Color)
            Me.BackColor = value
        End Set
    End Property

    Private Sub FormNotificaMini_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim y As Integer = Screen.PrimaryScreen.WorkingArea.Bottom - 30 - Me.Height
        Dim x As Integer = Screen.PrimaryScreen.WorkingArea.Right - Me.Width - 155
        Me.Location = New Point(x, y)

        PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
        Select Case _Tipo
            Case TipoNotifica.OK
                PictureBox1.Image = Risorse.Immagini.Bitmap("ok32")
            Case TipoNotifica.ERRORE
                PictureBox1.Image = Risorse.Immagini.Bitmap("_error")
            Case TipoNotifica.ATTENZIONE
                PictureBox1.Image = Risorse.Immagini.Bitmap("attenzione")
        End Select
    End Sub

    Private Sub FormNotificaMini_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        MyTimer = New Timer
        MyTimer.Interval = _SecondiChiusura * 1000
        MyTimer.Enabled = True

        Me.TopMost = True
        Me.Refresh()
        Me.TopMost = _TopMost
    End Sub

    Public Sub Chiudi(Optional Secondi As Integer = 2)
        If Me.Visible = True Then
            'prima della chiusura porto la finestra in primo piano per la notifica finale
            PrimoPiano()

            Dim Timeout As Date = Now.AddSeconds(Secondi)
            Do While Now < Timeout
                Application.DoEvents()
            Loop
            Me.Close()
        End If
    End Sub

    Public Sub PrimoPiano()
        Me.WindowState = FormWindowState.Normal
        Me.TopMost = True
        Me.Refresh()
    End Sub

    Private Sub MyTimer_Tick(sender As Object, e As EventArgs) Handles MyTimer.Tick
        MyTimer.Dispose()
        Me.Close()
    End Sub

    Public Shared Sub Visualizza(Tipo As TipoNotifica, Optional SecondiChiusura As Integer = 2, Optional PrimoPiano As Boolean = False)
        Dim th As New Threading.Thread(Sub()
                                           Call New Utx.FormNotificaMini(Tipo, SecondiChiusura, PrimoPiano).ShowDialog()
                                       End Sub)
        th.Start()
    End Sub
End Class