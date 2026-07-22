Imports System.Windows.Forms

Public Class Essig
    Inherits TabPage

    Public WithEvents wbEssig As New AxSHDocVw.AxWebBrowser

    Sub New()
        Me.Name = "Essig"
        Me.Text = "Essig"

        wbEssig.Dock = DockStyle.Fill
        Me.Controls.Add(wbEssig)
    End Sub

    Public Sub Naviga(Url As String)
        wbEssig.Silent = True
        wbEssig.Navigate(Url)
    End Sub

    Public Function EsistePaginaWeb() As Boolean
        Return (wbEssig.Document IsNot Nothing)
    End Function

    Public Shared Function NumeroPagineEssig(ByRef Tab As TabControl) As Integer

        Dim Pagine As Integer = 0

        For Each p As TabPage In Tab.TabPages
            If p.Name.ToUpper = "ESSIG" Then
                Pagine += 1
            End If
        Next
        Return Pagine
    End Function

    Private Sub wbEssig_NewWindow2(sender As Object, e As AxSHDocVw.DWebBrowserEvents2_NewWindow2Event) Handles wbEssig.NewWindow2
        Dim f As New UtControls.FormPopUp
        e.ppDisp = f.wbPopUp.Application
        f.Visible = True
    End Sub
End Class
