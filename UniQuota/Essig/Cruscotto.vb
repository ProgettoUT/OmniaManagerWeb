Namespace Essig

    Public Class Cruscotto

        Public Shared Function GetAsList(compagnia As String, agenzia As String, cliente As String) As String(,)

            Dim menu As String = WebEngine.Instance.CallWeb("essigSC/start.do", "itemId=0101000000&parametri=SC  SC")

            Dim parametri As String = String.Format("param=CRUSAGEN&compagnia.value={0}&agenzia.value={1}&codiceFiscale.value={2}", compagnia, agenzia, cliente)

            Dim pagina As String = WebEngine.Instance.CallWeb("essigSC/danni/situazionecliente/paginaFEIRECruscotto.do?" + parametri)

            pagina = pagina.Replace("&nbsp;", " ")

            Dim row As List(Of String) = Nothing
            Dim rows As New List(Of List(Of String))

            Do
                Dim i As Integer = pagina.IndexOf("<tr class=""bordiTab")
                If i = -1 Then Exit Do
                pagina = pagina.Substring(i + 22)

                i = pagina.IndexOf("</tr>")
                Dim item As String = pagina.Substring(0, i)
                pagina = pagina.Substring(i + 5)

                row = New List(Of String)


                i = item.IndexOf("showmenuie5")
                If i = -1 Then Exit Do

                Dim showmenuie5 As String = item.Substring(i + 11)

                Dim j As Integer = showmenuie5.IndexOf(""">")
                If j = -1 Then Exit Do

                showmenuie5 = showmenuie5.Substring(0, j)

                Do
                    j = item.IndexOf("<span")
                    If j = -1 Then Exit Do
                    item = item.Substring(j)
                    j = item.IndexOf(""">")
                    If j = -1 Then Exit Do
                    item = item.Substring(j + 2)
                    j = item.IndexOf("</span>")
                    row.Add(item.Substring(0, j).Trim)
                Loop

                Do
                    j = showmenuie5.IndexOf("'")
                    If j = -1 Then Exit Do
                    showmenuie5 = showmenuie5.Substring(j + 1)
                    j = showmenuie5.IndexOf("'")
                    If j = -1 Then Exit Do
                    row.Add(showmenuie5.Substring(0, j).Trim)
                    showmenuie5 = showmenuie5.Substring(j + 1)
                Loop

                rows.Add(row)

            Loop

            If row Is Nothing Then
                Return Nothing
            Else
                Dim arrai(rows.Count - 1, row.Count - 1) As String

                For i As Integer = 0 To rows.Count - 1
                    For j As Integer = 0 To row.Count - 1
                        arrai(i, j) = rows(i)(j)
                    Next
                Next

                Return arrai
            End If

        End Function

        Public Shared Sub Ripartenza(posizione As Integer, progressivo As Integer)
            'Dim url As String = String.Format("Danni/essigRE/danni/cruscotto/ripartenza.do?idPosizione={0}&progressivo={1}", posizione, progressivo)
            'WebEngine.Instance.OpenBrowser(url)
            MsgBox("Da implementare")
        End Sub

        Public Shared Function Annulla(posizione As Integer, progressivo As Integer) As Boolean
            Dim url As String = String.Format("Danni/essigRE/danni/cruscotto/annulloPreventivo.do?idPosizione={0}&progressivo={1}", posizione, progressivo)
            If NoError(WebEngine.Instance.CallWeb(url, Nothing)) Then
                If NoError(WebEngine.Instance.CallWeb("Danni/essigRE/danni/cruscotto/annulloPreventivoConferma.do", Nothing)) Then
                    Return True
                End If
            End If

            Return False
        End Function
    End Class

End Namespace
