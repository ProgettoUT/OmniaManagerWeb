Imports System.Windows.Forms

Public Class Arretrati
    Public Shared Function GetArretratiAsList(essig As Utx.AutenticazioneEssig,
                                              compagnia As String,
                                              agenzia As String,
                                              codicefiscale As String) As DataTable
        Try
            If essig.IsLogged Then
                Dim table As mshtml.HTMLTable = Nothing
                Dim menu As String = essig.CallWeb(essig.UrlBase & "essigSC/start.do?itemId=0101000000&parametri=SC++SC")
                Dim cliente As String = essig.CallWeb(essig.UrlBase & "essigSC/danni/situazionecliente/pagina00.do",
                                                      "nomePaginaAlbero=&flagDatiCambiati=&agenzia.value=" & agenzia &
                                                      "&descrizioneAgenzia.value=&codiceFiscale.value=" & codicefiscale &
                                                      "&cognomeRagSociale.value=&ACTIONBUTTON018=Conferma")
                If cliente IsNot Nothing AndAlso cliente.IndexOf("Cliente - Dettaglio") > 0 Then
                    Dim parametri As String = String.Format("ACTIONBUTTON050=Albero&nomePaginaAlbero=AJMAP016&compagnia.value={0}&agenzia.value={1}&codiceFiscale.value={2}",
                                                        compagnia, agenzia, codicefiscale)
                    Dim pagina As String = essig.CallWeb(essig.UrlBase & "essigSC/danni/situazionecliente/pagina03.do?" + parametri)

                    Dim dom As mshtml.HTMLDocument = Utx.FunzioniHtml.Html2Dom(pagina, "arretrati")

                    table = dom.getElementById("risultato")
                End If

                Dim dt As New DataTable()

                If (table Is Nothing OrElse table.rows.length < 2) Then
                    dt.Columns.Add(New DataColumn("Arretrati"))
                    dt.Rows.Add({"Cliente non disponibile in Essig"})
                ElseIf String.IsNullOrEmpty(Utx.FunzioniHtml.GetValueCell(table.rows.item(1), 1)) Then
                    dt.Columns.Add(New DataColumn("Arretrati"))
                    dt.Rows.Add({"Non ci sono arretrati in Essig"})
                Else
                    dt.Columns.Add(New DataColumn("Ramo"))
                    dt.Columns.Add(New DataColumn("Polizza"))
                    dt.Columns.Add(New DataColumn("Effetto"))
                    dt.Columns.Add(New DataColumn("Scadenza"))
                    dt.Columns.Add(New DataColumn("Premio"))

                    Dim Totale As Double = 0

                    For i = 1 To table.rows.length - 1
                        'Azioni 	Polizza 	App. 	Eff.titolo 	Scad.titolo 	Tipo 	Esito 	Tipo pagamento 	Scad.titolo 	Tassabile 	Premio Totale 	Data avv. pagam
                        Dim row As mshtml.HTMLTableRow = table.rows.item(i)
                        Dim polizza As String() = Utx.FunzioniHtml.GetValueCell(row, 1).Split("/")
                        Dim effetto As String = Utx.FunzioniHtml.GetValueCell(row, 3)
                        Dim scadenza As String = Utx.FunzioniHtml.GetValueCell(row, 4)
                        Dim premioLordo As Double = Val(Utx.FunzioniHtml.GetValueCell(row, 10))

                        dt.Rows.Add({polizza(1), polizza(2), effetto, scadenza, Format(premioLordo, "#,###,##0.00")})
                        Totale += Val(premioLordo)
                    Next
                    dt.Rows.Add({"", "", "", "TOTALE", Format(Totale, "#,###,##0.00")})
                End If

                Return dt
            Else
                Dim dt As New DataTable()
                dt.Columns.Add(New DataColumn("Arretrati"))
                dt.Rows.Add({"Essig non disponibile"})
                Return dt
            End If

        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
            Dim dt As New DataTable()
            dt.Columns.Add(New DataColumn("Arretrati"))
            dt.Rows.Add({ex.Message})
            Return dt
        End Try
    End Function
End Class
