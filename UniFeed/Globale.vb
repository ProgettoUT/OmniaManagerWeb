Imports System.Data.OleDb
Imports Utx
Imports System.Windows.Forms

Public Module Globale
    Public UrlHttpInDominio As String = "http://casellario.servizi.gr-u.it/ScaricoDati/" 'ListAll.aspx?GUID=b01665d5-d3f2-45cd-86bf-3aef9c076a99"
    Public UrlHttpInternet As String = "https://casellario.unipolsai.it/WSMA/" 'ListAllFiles.aspx?GUID=b01665d5-d3f2-45cd-86bf-3aef9c076a99"
    Public CartellaServerFtp As String = "ftp://10.16.14.1/omnia/casella/download/" '"ftp://2182035:getitn0w@www.utools.it/utools.it/Unitools/Download/OMNIA/"
    Public Log As ApplicationLog
    Public OmniaLog As ApplicationLog
    Public Report As Report
    Public InviaEmailAssistenza As Boolean
    Public ArrestaImportazione As Boolean

    Private WithEvents IconaNotifica As NotifyIcon
    Public Notifica As New TabControl
#If DEBUG Then
    Public PCSTEFANO As Boolean = (Environment.MachineName = "PINKFLOYD")
    Public PCGUIDO As Boolean = (Environment.MachineName = "X390-GUIDO")
#End If

    Public Sub NotificaOpen()
        IconaNotifica = New NotifyIcon
        With IconaNotifica
            .Text = String.Format("Unitools:{0}ricerca nuovi dati in corso", Environment.NewLine)
            .Icon = Risorse.Immagini.Icon("update_blu")
            .Visible = True
            '.ShowBalloonTip(30000)
        End With

    End Sub

    Public Sub NotificaClose(showlog As Boolean)
        If IconaNotifica IsNot Nothing Then
            With IconaNotifica
                .BalloonTipText = String.Format("Unitools:{0}controllo dati download agenzie completato", Environment.NewLine)
                .BalloonTipIcon = ToolTipIcon.Info
                .Visible = True
            End With

            'visualizza form notifiche
            If showlog Then
                Globale.Notifica.TabPages.Add(New TabNotifica().NotificaDati)
                Globale.Notifica.TabPages.Add(New TabLog().NotificaLog)

                Using fn As New frmNotifiche
                    fn.ShowDialog()
                End Using
            End If

            Notifica.Dispose()
            IconaNotifica.Dispose()
        End If
    End Sub

    Public Sub NotificaShow(ByRef messaggio As String)
        If IconaNotifica IsNot Nothing Then
            IconaNotifica.Text = Left(String.Format("{0}{1}{2}", Utx.Globale.TitoloApp, vbNewLine, messaggio), 63)
        End If
    End Sub

    Public Function DownloadHttp(nomefile As String, cartellaDownload As String) As Boolean
        Return Archivio.DownloadHttp(nomefile, cartellaDownload)
    End Function
End Module
