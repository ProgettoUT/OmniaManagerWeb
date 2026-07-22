Imports System.Drawing
Imports System.ComponentModel

Public Class NotificaRapida

    Private WithEvents bw As New BackgroundWorker
    Private mMessaggio As String
    Private mPermanenza As Integer
    Private mColoreSfondo As Color
    Private mAltezza As Utx.FormNotifica.AltezzaNotifica

    Sub New(Optional Altezza As Utx.FormNotifica.AltezzaNotifica = FormNotifica.AltezzaNotifica.MEZZA)
        mAltezza = Altezza
    End Sub

    ''' <summary>
    ''' visualizza una notifica rapida
    ''' </summary>
    ''' <param name="Messaggio">messaggio da visualizzare</param>
    ''' <param name="Permanenza">ritardo per la chiusura della notifica in secondi</param>
    ''' <remarks></remarks>
    Public Sub Visualizza(Messaggio As String, Optional Permanenza As Integer = 2)
        mMessaggio = Messaggio
        mPermanenza = Permanenza
        mColoreSfondo = Color.WhiteSmoke
        bw.RunWorkerAsync()
    End Sub

    Public Sub VisualizzaErrore(Messaggio As String, Optional Permanenza As Integer = 4)
        mMessaggio = Messaggio
        mPermanenza = Permanenza
        mColoreSfondo = Color.LightSalmon
        bw.RunWorkerAsync()
    End Sub

    Private Sub VisualizzaNotifica()
        On Error Resume Next

        Dim f As New FormNotifica
        With f
            .ColoreSfondo = mColoreSfondo
            .SpessoreBordo = 2
            .Opacity = 1
            .Altezza = mAltezza
            .Show()
            .Messaggio = mMessaggio
            .Chiudi(mPermanenza)
        End With
    End Sub

    Private Sub bw_DoWork(sender As Object, e As DoWorkEventArgs) Handles bw.DoWork
        VisualizzaNotifica()
    End Sub
End Class
