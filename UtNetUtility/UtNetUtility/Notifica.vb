Imports System.Drawing
Imports System.Windows.Forms

Public Class Notifica

    Public Event Annulla()

    Dim f As FormNotifica

    Sub New()
        f = New FormNotifica
    End Sub

    Sub New(ByVal BottoneAnnulla As Boolean, ByVal Bordo As Boolean)
        f = New FormNotifica(BottoneAnnulla, Bordo)
    End Sub

    Public Sub Visualizza()

        AddHandler f.Annulla, AddressOf Annulla_click

        f.Show()
    End Sub

    Private Sub Annulla_click()
        If MsgBox("Annullare l'operazione in corso?",
                  MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.YesNo,
                  f.Text) = MsgBoxResult.Yes Then

            f.btnAnnulla.Enabled = False
            RaiseEvent Annulla()
        End If
    End Sub

    Public Sub Chiudi(Optional ByVal Secondi As Integer = 5)

        'prima della chiusura porto la finestra in primo piano per la notifica finale
        f.WindowState = FormWindowState.Normal
        NetFunc.FinestraOnTop(f.Handle, True)
        f.Refresh()

        If Secondi = 0 Then
            f.Timer1.Interval = 1
        Else
            f.Timer1.Interval = Secondi * 1000
        End If

        f.Timer1.Enabled = True
    End Sub

    Public Sub Refresh()
        f.Refresh()
        f.LabelMessaggio.Refresh()
    End Sub

    Public Property Messaggio() As String
        Get
            Return f.LabelMessaggio.Text
        End Get
        Set(ByVal value As String)
            f.LabelMessaggio.Text = value
        End Set
    End Property

    Public WriteOnly Property TopMost() As Boolean
        Set(ByVal value As Boolean)
            f.WindowState = FormWindowState.Normal
            NetFunc.FinestraOnTop(f.Handle, value)
        End Set
    End Property

    Public WriteOnly Property ColoreTesto() As Color
        Set(ByVal value As Color)
            f.LabelMessaggio.ForeColor = value
        End Set
    End Property

    Public WriteOnly Property ColoreSfondo() As Color
        Set(ByVal value As Color)
            f.ColoreSfondo = value
        End Set
    End Property

    Public Property Titolo() As String
        Get
            Return f.Text
        End Get
        Set(ByVal value As String)
            f.Text = value
        End Set
    End Property

    Public Property Trasparenza() As Double
        Get
            Return f.Opacity
        End Get
        Set(ByVal value As Double)
            f.Opacity = value
        End Set
    End Property

    Public WriteOnly Property FontMessaggio() As Font
        Set(ByVal value As Font)
            f.LabelMessaggio.Font = value
        End Set
    End Property

    Public Property ConsentiAnnullamento() As Boolean
        Get
            Return f.ConsentiAnnullamento
        End Get
        Set(ByVal value As Boolean)
            f.ConsentiAnnullamento = value
        End Set
    End Property

End Class
