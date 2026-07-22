Imports System.Windows.Forms

Public Class Ueba
    Inherits TabPage

    Public WithEvents wbUeba As New AxSHDocVw.AxWebBrowser

    Sub New()
        Me.Name = "Ueba"
        Me.Text = "Ueba"

        wbUeba.Dock = DockStyle.Fill
        Me.Controls.Add(wbUeba)
    End Sub

    Public Sub Naviga(Url As String)
        wbUeba.Silent = True
        wbUeba.Navigate(Url)
    End Sub

    Public Function EsistePaginaWeb() As Boolean
        Return (wbUeba.Document IsNot Nothing)
    End Function

    Public Shared Function PaginaUeba(ByRef Tab As TabControl) As Ueba
        For Each p As TabPage In Tab.TabPages
            If p.Name.ToUpper = "UEBA" Then
                Return p
            End If
        Next
        Return Nothing
    End Function

    Private Sub wbUeba_NewWindow2(sender As Object, e As AxSHDocVw.DWebBrowserEvents2_NewWindow2Event) Handles wbUeba.NewWindow2
        Dim f As New UtControls.FormPopUp
        e.ppDisp = f.wbPopUp.Application
        f.Visible = True
    End Sub
End Class
