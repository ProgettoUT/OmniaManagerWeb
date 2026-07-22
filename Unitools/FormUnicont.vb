Imports System.IO

Public Class FormUnicont

    Sub New()
        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Size = New Size(380, 280)
        Me.Font = Utx.AppFont.Extra(12, FontStyle.Bold)
        Me.Text = "Risorse Unicont"

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        With PictureBox1
            .SizeMode = PictureBoxSizeMode.CenterImage
            .Image = Risorse.Immagini.Image("contabilita")
        End With
        With Label1
            .Margin = New Padding(6)
            .FlatStyle = FlatStyle.Flat
            .Text = "Tutte le funzioni disponibili in desktop remoto sono ora accessibili attraverso il portale web"
            .TextAlign = ContentAlignment.MiddleCenter
        End With
        'With ButtonUnicont
        '    .Margin = New Padding(0)
        '    .Padding = New Padding(10, 0, 10, 0)
        '    .Image = Risorse.Immagini.Bitmap("euro")
        '    .ImageAlign = ContentAlignment.MiddleLeft
        '    .Text = "Accedi alla contabilità"
        '    .TextAlign = ContentAlignment.MiddleRight
        'End With
        'With ButtonPortale
        '    .Margin = New Padding(0)
        '    .Padding = New Padding(10, 0, 10, 0)
        '    .Image = Risorse.Immagini.Bitmap("link")
        '    .ImageAlign = ContentAlignment.MiddleLeft
        '    .Text = "Portale di stampa - Utilità"
        '    .TextAlign = ContentAlignment.MiddleRight
        'End With
    End Sub

    'Private Sub ButtonUnicont_Click(sender As Object, e As EventArgs)
    '    Try
    '        'IP contabilità
    '        'DIR: 172.30.86.220:4300
    '        'PP: 85.34.90.73:4300
    '        Dim FileRDP As String
    '        If Utx.Setting.Ambiente = Utx.Enumerazioni.TipoAmbiente.PP Then
    '            FileRDP = Path.Combine(Utx.Globale.Paths.CartellaSetting, "Unicont.PP")
    '        Else
    '            FileRDP = Path.Combine(Utx.Globale.Paths.CartellaSetting, "Unicont.DIR")
    '        End If

    '        Dim p As New Process
    '        With p
    '            .StartInfo.FileName = "MSTSC"
    '            .StartInfo.Arguments = FileRDP
    '            .StartInfo.WindowStyle = ProcessWindowStyle.Minimized
    '            .Start()
    '        End With

    '        Me.Close()

    '    Catch ex As Exception
    '        Utx.Globale.Log.Info(ex)
    '    End Try
    'End Sub

    'Private Sub ButtonPortale_Click(sender As Object, e As EventArgs)
    '    On Error Resume Next
    '    Process.Start("https://omaportal.siaspa.com/ws_ugf/")
    '    Me.Close()
    'End Sub
End Class