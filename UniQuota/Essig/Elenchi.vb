Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml.Serialization

Namespace Essig

    Public Class Elenco
        Private Shared CARTELLA_ELENCHI As String = Path.Combine(CARTELLA_PREVENTIVI, "ELENCHI")

        Shared Sub New()
            Directory.CreateDirectory(CARTELLA_ELENCHI)
        End Sub


        Public Shared Function Intermediari(ByVal compagnia As Integer, ByVal agenzia As Integer) As List(Of Intermediario)
            Static lista As List(Of Intermediario)

            If lista IsNot Nothing Then Return lista

            Dim filename As String = Path.Combine(CARTELLA_ELENCHI, compagnia & agenzia & "B")

            lista = CType(Load(filename), List(Of Intermediario))
            If lista IsNot Nothing Then Return lista

            If WebEngine.IsLogged Then
                Dim items As List(Of String) = GetAsList("Danni/essigRE/danni/emissione/popupSelezioneIntermediario.do?comp=" & compagnia & "&agen=" & agenzia, "doClick6Param(", ");", {"'"})
                If items.Count = 0 Then Return Nothing

                lista = New List(Of Intermediario)

                Dim intermediario As Intermediario
                For Each item As String In items
                    Dim campi As String() = item.Split(",")
                    intermediario = New Intermediario()
                    With intermediario
                        .CodiceFiscale = campi(3).Trim
                        .Nominativo = campi(1).Trim
                        .NumeroIscrizioneIsvap = campi(5).Trim
                        .Ruolo = campi(7).Trim
                        .SoggettoNominativo = campi(9).Trim
                        .SoggettoCodiceFiscale = campi(11).Trim
                    End With
                    lista.Add(intermediario)
                Next

                Salva(filename, lista)
            End If
            Return lista
        End Function


        Public Shared Function Subagenzie(ByVal compagnia As Integer, ByVal agenzia As Integer) As List(Of Subagenzia)
            Static lista As List(Of Subagenzia)
            If lista IsNot Nothing Then Return lista


            Dim filename As String = Path.Combine(CARTELLA_ELENCHI, compagnia & agenzia & "A")

            lista = CType(Load(filename), List(Of Subagenzia))
            If lista IsNot Nothing Then Return lista

            If WebEngine.IsLogged Then
                Dim items As List(Of String) = GetAsList("Danni/essigRE/danni/emissione/popupSelezioneSubAgenzia.do?comp=" & compagnia & "&agen=" & agenzia, "doClick(", ");", {"'"})
                lista = New List(Of Subagenzia)

                Dim subagenzia As Subagenzia
                For Each item As String In items
                    Dim campi As String() = item.Split(",")
                    subagenzia = New Subagenzia()

                    With subagenzia
                        .Codice = campi(3).Trim
                        .Denominazione = campi(1).Trim
                    End With

                    lista.Add(subagenzia)
                Next

                Salva(filename, lista)
            End If
            Return lista
        End Function

        Public Shared Function Professioni() As Lista
            Static lista As Lista
            If lista IsNot Nothing Then Return lista


            Dim filename As String = Path.Combine(CARTELLA_ELENCHI, "Professioni")

            lista = CType(Load(filename), Lista)
            If lista IsNot Nothing Then Return lista

            If WebEngine.IsLogged Then

                Dim items As List(Of String) = GetAsList("Danni/essigRE/danni/emissione/popupProfessione1202_0001.do", "doClick4Param(", ");", {"'"})
                lista = New Lista

                Dim elemento As Elemento
                For Each item As String In items
                    Dim campi As String() = item.Split(",")
                    elemento = New Elemento()

                    With elemento
                        .Codice = campi(1).Trim
                        .Descrizione = campi(3).Trim
                        .Extra1 = campi(5).Trim
                        .Extra2 = campi(7).Trim
                    End With

                    lista.Add(elemento)
                Next

                Salva(filename, lista)
            End If

            Return lista
        End Function

        Private Shared Function GetAsList(url As String, tagStart As String, tagEnd As String, tagReplace As String()) As List(Of String)

            WebEngine.Instance.CallWeb("Danni/essigRE/start.do?itemId=0201020000&parametri=RE++EMPR", Nothing)
            Dim pagina As String = WebEngine.Instance.CallWeb(url, Nothing)

            Dim lista As New List(Of String)

            If pagina IsNot Nothing Then
                Do
                    Dim i As Integer = pagina.IndexOf(tagStart)
                    If i = -1 Then Exit Do
                    pagina = pagina.Substring(i + tagStart.Length)
                    i = pagina.IndexOf(tagEnd)
                    Dim item As String = pagina.Substring(0, i)

                    For Each tag In tagReplace
                        item = item.Replace(tag, "")
                    Next
                    lista.Add(item)
                    i = pagina.IndexOf("</tr>")
                    pagina = pagina.Substring(i + 5)
                Loop
            End If

            Return lista
        End Function


        Private Shared Function Load(ByVal filename As String) As Object
            Dim oggetto As Object = Nothing

            Try
                If File.Exists(filename) Then
                    Dim fs As FileStream = File.Open(filename, FileMode.Open)
                    Dim bf As New BinaryFormatter()
                    oggetto = bf.Deserialize(fs)
                    fs.Close()

                    If oggetto.GetType().InvokeMember("Count", Reflection.BindingFlags.GetProperty, Nothing, oggetto, Nothing) = 0 Then
                        oggetto = Nothing
                    End If
                    If oggetto Is Nothing Then
                        Try
                            File.Delete(filename)
                        Catch ex As Exception
                        End Try
                    End If
                End If
            Catch ex As Exception
            End Try

            Return oggetto
        End Function

        Private Shared Sub Salva(ByVal filename As String, oggetto As Object)
            Try
                Dim fs As FileStream = File.Open(filename, FileMode.Create)
                Dim bf As New BinaryFormatter()
                bf.Serialize(fs, oggetto)
                fs.Close()
            Catch ex As Exception
            End Try
        End Sub

    End Class
End Namespace
