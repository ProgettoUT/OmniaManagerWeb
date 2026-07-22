Imports System.Windows.Forms
Imports System.Drawing

Public Class FormNotifica

    Public Event Annulla()

    Public Shared ListaNotifiche As New List(Of FormNotifica)
    Private WithEvents LinkLabelAnnulla As New LinkLabel
    Private WithEvents TimeoutChiusura As MyTimeout
    Private WithEvents TimeoutHide As MyTimeout
    Private Delegate Sub ChiudiNotifica()
    Private Delegate Sub NascondiNotifica()

    Public Enum AltezzaNotifica
        NORMALE
        MEZZA
        DOPPIA
    End Enum
    Public Enum Style
        BIANCO_ROSSO
        ANTRACITE
        ROSA_CHIARO
        VERDE
        ROSSO_BIANCO
        OMNIA_MANAGER_1
        OMNIA_MANAGER_2
        BIANCO_GRIGIO
    End Enum

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        mIdNotifica = Guid.NewGuid.ToString
        With Me
            .FormBorderStyle = Windows.Forms.FormBorderStyle.None
            .StartPosition = FormStartPosition.Manual
            .Altezza = AltezzaNotifica.NORMALE
            .WindowState = FormWindowState.Normal
            .Font = Utx.AppFont.Normal
            'varie
            .Text = "Unitools"
            .Opacity = 1
            .ShowInTaskbar = True
            .Icon = Risorse.Immagini.Icon("notifica")
            .Padding = New Padding(1)
            .BackColor = Color.Gray
        End With
        CheckForIllegalCrossThreadCalls = False

        ImpostaControlli()
    End Sub

    Private Sub FormNotifica_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ListaNotifiche.Add(Me)
        If Utx.Globale.SessioneCorrente IsNot Nothing Then
            If Utx.Globale.SessioneCorrente.Nascosta = False Then
                Me.TopMost = True
                Me.Refresh()
                Me.TopMost = False
            End If
        Else
            Me.TopMost = True
            Me.Refresh()
            Me.TopMost = False
        End If
    End Sub

    Private Sub ImpostaControlli()
        tlpMain.Padding = New Padding(0)
        With tlpMain.RowStyles.Item(0)
            .SizeType = SizeType.Percent
            .Height = 100
        End With

        Utx.NetFunc.DoppioBuffer(tlpMain)

        'label messaggio
        With LabelMessaggio
            .Margin = New Padding(0)
            .AutoSize = True
            .Dock = DockStyle.Fill
            .BorderStyle = BorderStyle.None
            .BackColor = Color.Transparent
            .ForeColor = Color.Black
            .Font = Utx.AppFont.Normal
            .Text = "..."
            .TextAlign = ContentAlignment.MiddleCenter
        End With

        'label annulla
        With LinkLabelAnnulla
            .Margin = New Padding(0)
            .Padding = New Padding(10, 0, 10, 0)
            .AutoSize = True
            .Dock = DockStyle.Fill
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = Color.Gainsboro
            .ForeColor = Color.Black
            .Font = Utx.AppFont.Normal
            .Text = "Annulla l'operazione"
            .TextAlign = ContentAlignment.MiddleRight
        End With
        'nascondo annulla
        With tlpMain.RowStyles.Item(1)
            .SizeType = SizeType.Absolute
            .Height = 0
        End With

        tlpMain.SetRowSpan(LabelMessaggio, 1)
    End Sub

    Private mIdNotifica As String
    Public ReadOnly Property IdNotifica() As String
        Get
            Return mIdNotifica
        End Get
    End Property

    Private mAnnullaOperazione As Boolean
    Public Property AnnullaOperazione() As Boolean
        Get
            Return mAnnullaOperazione
        End Get
        Set(value As Boolean)
            mAnnullaOperazione = value

            If mAnnullaOperazione = True Then
                'ridimensiono la seconda riga
                With tlpMain.RowStyles.Item(1)
                    .SizeType = SizeType.Absolute
                    .Height = 20
                End With
                'inserisco label annulla
                tlpMain.Controls.Add(LinkLabelAnnulla)
                tlpMain.SetCellPosition(LinkLabelAnnulla, New TableLayoutPanelCellPosition(0, 1))
            Else
                'nascondo la seconda riga
                tlpMain.Controls.Remove(LinkLabelAnnulla)
                With tlpMain.RowStyles.Item(1)
                    .SizeType = SizeType.Absolute
                    .Height = 0
                End With
            End If
        End Set
    End Property

    Private mAltezza As AltezzaNotifica
    Public Property Altezza() As AltezzaNotifica
        Get
            Return mAltezza
        End Get
        Set(value As AltezzaNotifica)
            mAltezza = value
            Select Case mAltezza
                Case AltezzaNotifica.NORMALE
                    Me.Size = New Size(360, 90)
                Case AltezzaNotifica.MEZZA
                    Me.Size = New Size(360, 50)
                Case AltezzaNotifica.DOPPIA
                    Me.Size = New Size(500, 180)
            End Select
            'posizione di default - iterazione su tutte le istanze attive per trovare la notifica più in alto
            Dim MaxY As Integer = Screen.PrimaryScreen.WorkingArea.Bottom - 30
            For Each n As FormNotifica In ListaNotifiche
                If n.Location.Y < MaxY Then
                    MaxY = n.Location.Y
                End If
            Next
            y = MaxY - Me.Height - 1
            x = Screen.PrimaryScreen.WorkingArea.Right - Me.Width - 155

            If Utx.Globale.SessioneCorrente IsNot Nothing Then
                If Utx.Globale.SessioneCorrente.Nascosta Then
                    Me.Location = New Point(-10000, y)
                    Me.ShowInTaskbar = False
                Else
                    Me.Location = New Point(x, y)
                End If
            Else
                Me.Location = New Point(x, y)
            End If
        End Set
    End Property

    Private _x As Integer
    Public Property x() As Integer
        Get
            Return _x
        End Get
        Set(value As Integer)
            _x = value
        End Set
    End Property

    Private _y As Integer
    Public Property y() As Integer
        Get
            Return _y
        End Get
        Set(value As Integer)
            _y = value
        End Set
    End Property

    Private mLog As ApplicationLog = Nothing
    Public Property Log() As ApplicationLog
        Get
            Return mLog
        End Get
        Set(value As ApplicationLog)
            mLog = value
        End Set
    End Property

    Private mSpessoreBordo As Integer
    Public Property SpessoreBordo() As Integer
        Get
            Return mSpessoreBordo
        End Get
        Set(value As Integer)
            value = Math.Max(0, value)
            mSpessoreBordo = value
            Me.Padding = New Padding(mSpessoreBordo)
        End Set
    End Property

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

    Public Property Messaggio() As String
        Get
            Return LabelMessaggio.Text
        End Get
        Set(value As String)
            LabelMessaggio.Text = value
            'se ho legato un oggetto log scrive il messaggio nel log
            If Log IsNot Nothing Then
                Log.Info(value)
            End If
        End Set
    End Property

    Private mStile As Style
    Public Property Stile() As Style
        Get
            Return mStile
        End Get
        Set(value As Style)
            mStile = value
            Select Case mStile
                Case Style.ANTRACITE
                    Me.BackColor = Color.Gainsboro
                    Me.LabelMessaggio.BackColor = Utx.AppColor.Antracite
                    Me.LabelMessaggio.ForeColor = Color.White
                Case Style.BIANCO_ROSSO
                    Me.LabelMessaggio.BackColor = Drawing.Color.WhiteSmoke
                    Me.BackColor = Utx.AppColor.RossoScuro
                    Me.LabelMessaggio.ForeColor = Color.Black
                Case Style.ROSA_CHIARO
                    Me.LabelMessaggio.BackColor = Utx.AppColor.RosaChiaro
                    Me.BackColor = Utx.AppColor.Antracite
                    Me.LabelMessaggio.ForeColor = Color.Black
                Case Style.VERDE
                    Me.LabelMessaggio.BackColor = Color.LightGreen
                    Me.BackColor = Utx.AppColor.Antracite
                    Me.LabelMessaggio.ForeColor = Color.Black
                Case Style.ROSSO_BIANCO
                    Me.LabelMessaggio.BackColor = Color.Red
                    Me.BackColor = Color.WhiteSmoke
                    Me.LabelMessaggio.ForeColor = Color.WhiteSmoke
                Case Style.BIANCO_GRIGIO
                    Me.BackColor = Color.Gray
                    Me.LabelMessaggio.BackColor = Color.WhiteSmoke
                    Me.LabelMessaggio.ForeColor = Color.Black
                Case Style.OMNIA_MANAGER_1
                    Me.BackColor = Color.FromArgb(140, 180, 255)
                    Me.LabelMessaggio.BackColor = Color.FromArgb(140, 180, 215)
                    Me.LabelMessaggio.ForeColor = Color.White
                Case Style.OMNIA_MANAGER_2
                    Me.BackColor = Color.WhiteSmoke
                    Me.LabelMessaggio.BackColor = Color.FromArgb(91, 146, 194)
                    Me.LabelMessaggio.ForeColor = Color.White
            End Select
        End Set
    End Property

    Public Property ColoreSfondo() As Color
        Get
            Return LabelMessaggio.BackColor
        End Get
        Set(value As Color)
            LabelMessaggio.BackColor = value
        End Set
    End Property

    Public WriteOnly Property ColoreTesto() As Color
        Set(value As Color)
            LabelMessaggio.ForeColor = value
        End Set
    End Property

    Private mSecondiChiusura As Integer = 0
    Public Property SecondiChiusura() As Integer
        Get
            Return mSecondiChiusura
        End Get
        Set(value As Integer)
            mSecondiChiusura = value
        End Set
    End Property

    Private mOnClickClose As Boolean
    Public Property OnClickClose() As Boolean
        Get
            Return mOnClickClose
        End Get
        Set(value As Boolean)
            mOnClickClose = value
        End Set
    End Property

    Private mErrore As Boolean
    Public Property Errore() As Boolean
        'per memorizzare un errore
        Get
            Return mErrore
        End Get
        Set(value As Boolean)
            mErrore = value
        End Set
    End Property

    Private mRichiestaAnnullamento As Boolean
    Public ReadOnly Property RichiestaAnnullamento() As Boolean
        Get
            Return mRichiestaAnnullamento
        End Get
    End Property

    Public Sub Nascondi()
        Me.Visible = False
    End Sub

    ''' <summary>
    ''' chiusura asincrona
    ''' </summary>
    ''' <param name="Secondi"></param>
    ''' <remarks></remarks>
    Public Sub ChiudiAsync(Optional Secondi As Integer = 2)
        If Me.Visible = True Then
            'prima della chiusura porto la finestra in primo piano per la notifica finale
            PrimoPiano()
            Dim tt As New Threading.Thread(Sub()
                                               If mSecondiChiusura > 0 Then
                                                   TimeoutChiusura = New MyTimeout(mSecondiChiusura * 1000)
                                               Else
                                                   TimeoutChiusura = New MyTimeout(Secondi * 1000)
                                               End If
                                           End Sub)
            tt.Start()
        End If
    End Sub

    Public Sub NascondiAsync(Optional Secondi As Integer = 2)
        If Me.Visible = True Then
            PrimoPiano()
            Dim tt As New Threading.Thread(Sub()
                                               TimeoutHide = New MyTimeout(Secondi * 1000)
                                           End Sub)
            tt.Start()
        End If
    End Sub

    ''' <summary>
    ''' chiusura sincrona
    ''' </summary>
    ''' <param name="Secondi"></param>
    ''' <remarks></remarks>
    Public Sub Chiudi(Optional Secondi As Integer = 2)
        If Me.Visible = True Then
            'prima della chiusura porto la finestra in primo piano per la notifica finale
            PrimoPiano()

            Dim Timeout As Date
            If mSecondiChiusura > 0 Then
                Timeout = Now.AddSeconds(mSecondiChiusura)
            Else
                Timeout = Now.AddSeconds(Secondi)
            End If

            Do While Now < Timeout
                Application.DoEvents()
            Loop
            ListaNotifiche.Remove(Me)
            Me.Close()
        End If
    End Sub

    Public Sub ChiusuraImmediata()
        If TimeoutChiusura IsNot Nothing Then TimeoutChiusura = Nothing
        If TimeoutHide IsNot Nothing Then TimeoutHide = Nothing
        ListaNotifiche.Remove(Me)
        Me.Close()
    End Sub

    Public Sub PrimoPiano()
        Me.WindowState = FormWindowState.Normal
        Me.Refresh()
    End Sub

    'Private Sub btnAnnulla_Click(sender As System.Object, e As System.EventArgs)
    '    RaiseEvent Annulla()
    'End Sub

    Private Sub LabelMessaggio_Click(sender As Object, e As System.EventArgs) Handles LabelMessaggio.Click
        If mOnClickClose = True Then
            Me.WindowState = FormWindowState.Minimized
            ListaNotifiche.Remove(Me)
            Me.Close()
        Else
            Me.WindowState = FormWindowState.Minimized
        End If
    End Sub

    Private Sub LabelMessaggio_TextChanged(sender As Object, e As System.EventArgs) Handles LabelMessaggio.TextChanged
        LabelMessaggio.Refresh()
        Application.DoEvents()
    End Sub

    Private Sub LabelMessaggio_BackColorChanged(sender As Object, e As EventArgs) Handles LabelMessaggio.BackColorChanged
        LabelMessaggio.Refresh()
        Application.DoEvents()
    End Sub

    Private Sub LinkLabelAnnulla_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelAnnulla.LinkClicked
        If MsgBox("Confermate l'annullamento dell'operazione", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then
            mRichiestaAnnullamento = True
            RaiseEvent Annulla()
        End If
    End Sub

    Private Sub TimeoutChiusura_Timeout() Handles TimeoutChiusura.Timeout
        Try
            ListaNotifiche.Remove(Me)
            Me.Invoke(New ChiudiNotifica(AddressOf Me.Close))
        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
            ListaNotifiche.Remove(Me)
            Me.Close()
#If DEBUG Then
            Console.Beep(1000, 1000)
            Utx.Globale.Log.Errore(ex)
#End If
        End Try
    End Sub

    Private Sub TimeoutHide_Timeout() Handles TimeoutHide.Timeout
        Try
            Me.Invoke(New ChiudiNotifica(AddressOf Me.Hide))
        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
            Me.Hide()
#If DEBUG Then
            Console.Beep(1000, 1000)
            Utx.Globale.Log.Errore(ex)
#End If
        End Try
    End Sub

#Region "Spostamento finestra"
    'Declare the variables
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub LabelMessaggio_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LabelMessaggio.MouseDoubleClick
        Me.Top = 0
        Me.Height = Screen.PrimaryScreen.WorkingArea.Height
    End Sub

    Private Sub LabelMessaggio_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles LabelMessaggio.MouseDown
        drag = True 'Sets the variable drag to true.
        mousex = Windows.Forms.Cursor.Position.X - Me.Left 'Sets variable mousex
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top 'Sets variable mousey
    End Sub

    Private Sub LabelMessaggio_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles LabelMessaggio.MouseMove
        'If drag is set to true then move the form accordingly.
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub LabelMessaggio_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles LabelMessaggio.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub

    Private Sub FormNotifica_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        ListaNotifiche.Remove(Me)
    End Sub
#End Region
End Class