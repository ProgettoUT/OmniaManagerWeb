Imports Microsoft.Web.WebView2.WinForms
Imports Microsoft.Web.WebView2.Core

Imports EO.WebBrowser
Imports mshtml
Imports System.Windows.Forms

Public Class RicercaSinistroLiquido

    Public Shared Attiva As Boolean
    Public Shared Wv As WebView2
    Public Shared RicercaCompletata As Boolean

#Region "Tag pagina ricerca"
    'id che identificano i campi in liquido (sezione ricerca semplice)
    Const IdPaginaRicerca As String = "TabBar-SearchTab"
    Const IdSinistro As String = "SimpleClaimSearch-SimpleClaimSearchScreen-SimpleClaimSearchDV-ClaimSearchCriteriaInputSet-complSinistroNum"
    Const IdAgenzia As String = "SimpleClaimSearch-SimpleClaimSearchScreen-SimpleClaimSearchDV-ClaimSearchCriteriaInputSet-agenziaNum"
    Const IdCerca As String = "SimpleClaimSearch-SimpleClaimSearchScreen-SimpleClaimSearchDV-ClaimSearchAndResetInputSet-Search"
    'Const IdReset As String = "SimpleClaimSearch-SimpleClaimSearchScreen-SimpleClaimSearchDV-ClaimSearchAndResetInputSet-Reset"
    Const IdBottoneSinistro As String = "SimpleClaimSearch-SimpleClaimSearchScreen-Ext_ClaimSearchResultsLV-0-ClaimNumber_button"
    Const IdInfocell As String = "SimpleClaimSearch-SimpleClaimSearchScreen-Ext_ClaimSearchResultsLV div.gw-ListView--empty-info-cell"
#End Region

    Public Shared Sub Cerca(ByRef Wv As EO.WebBrowser.WebView, SinistroCorrente As Sinistro)
        Try
            RicercaSinistroLiquido.Attiva = False

            Wv.SetFocus() 'fondamentale: senza questo non funziona!
            Wv.EvalScript(String.Format("parent.gwUtil.fireEvent(document.getElementById('{0}').id+'_act');", IdPaginaRicerca))
            Threading.Thread.Sleep(300)

            'numero sinistro
            Wv.EvalScript(String.Format("document.getElementsByName('{0}')[0].value='{1}'", IdSinistro, SinistroCorrente.IdSinistro))
            'codice agenzia
            Wv.EvalScript(String.Format("document.getElementsByName('{0}')[0].value='{1}'", IdAgenzia, Val(SinistroCorrente.AgenziaPolizza)))

            Wv.EvalScript(String.Format("parent.gwUtil.fireEvent(document.getElementById('{0}').id+'_act');", IdCerca))
            Threading.Thread.Sleep(1000)

            Dim obj As Object = Wv.EvalScript(String.Format("$('#{0}').text();", IdInfocell))
            If obj IsNot Nothing Then
                If obj.ToString.ToLower.Contains("non sono presenti dati") = False Then
                    Wv.EvalScript(String.Format("document.getElementById('{0}').focus();", IdBottoneSinistro))
                    SendKeys.Send("{ENTER}")
                End If
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

    End Sub

    Public Shared Async Sub CercaWV2(SinistroCorrente As Sinistro)
        Try
            If RicercaSinistroLiquido.Attiva = False Then
                Exit Sub
            End If

            RicercaSinistroLiquido.Attiva = False

            Await Wv.CoreWebView2.ExecuteScriptAsync(String.Format("parent.gwUtil.fireEvent(document.getElementById('{0}').id+'_act');", IdPaginaRicerca))
            Threading.Thread.Sleep(300)

            'numero sinistro
            Await Wv.CoreWebView2.ExecuteScriptAsync(String.Format("document.getElementsByName('{0}')[0].value='{1}'", IdSinistro, SinistroCorrente.IdSinistro))
            'codice agenzia
            Await Wv.CoreWebView2.ExecuteScriptAsync(String.Format("document.getElementsByName('{0}')[0].value='{1}'", IdAgenzia, Val(SinistroCorrente.AgenziaPolizza)))

            Await Wv.CoreWebView2.ExecuteScriptAsync(String.Format("parent.gwUtil.fireEvent(document.getElementById('{0}').id+'_act');", IdCerca))
            Threading.Thread.Sleep(1000)

            Dim obj As Object = Wv.CoreWebView2.ExecuteScriptAsync(String.Format("$('#{0}').text();", IdInfocell))
            If obj IsNot Nothing Then
                If obj.ToString.ToLower.Contains("non sono presenti dati") = False Then
                    Await Wv.CoreWebView2.ExecuteScriptAsync(String.Format("document.getElementById('{0}').focus();", IdBottoneSinistro))
                    SendKeys.Send("{ENTER}")
                End If
            End If
        Catch ex As Exception
            Globale.Log.Errore(ex)
        Finally
            RicercaCompletata = True
        End Try
    End Sub
End Class