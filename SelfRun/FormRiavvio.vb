Imports System.IO
Imports Utx.ServiziUniarea

Public Class FormRiavvio

    Private WithEvents Timer1 As Timer
    Private Avvio As Date = Now

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Size = New Size(360, 50)
        Me.ShowInTaskbar = False
    End Sub

    Private Sub FormRiavvio_Load(sender As Object, e As EventArgs) Handles Me.Load
        With Label1
            .Font = Utx.AppFont.Normal
            .FlatStyle = FlatStyle.Flat
            .BorderStyle = BorderStyle.FixedSingle
            .BackColor = Color.Gainsboro
            .ForeColor = Utx.AppColor.RossoScuro
            .Text = "R i a v v i o  d i  O m n i a  m a n a g e r"
        End With

        Timer1 = New Timer With {.Interval = 1000, .Enabled = True}
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
#If DEBUG Then
        If DateDiff(DateInterval.Second, Avvio, Now) > 5 Then
            End
        End If
#Else
        If DateDiff(DateInterval.Second, Avvio, Now) > 60 Then
            End
        Else
            If Utx.NetFunc.AltraIstanzaUtente("Unitools", ProcessoAvviato:=False) = False Then
                Process.Start("C:\ApplicazioniDirezione\Unitools\Unitools.exe")
                End
            End If
        End If
#End If
    End Sub
End Class
