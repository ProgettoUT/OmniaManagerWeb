Imports System.IO
Imports System.Xml.Serialization
Imports System.Reflection
Imports MSHTML
Imports System.IO.Compression

Namespace Essig
    Public Class Navigatore
        Public Event NavigatoreEvent(ByVal testo As String, ByVal contatore As Integer)
        Private mProcesso As Processo
        Private mStadi As List(Of Stadio)

        Private mStadioCorrente As Stadio
        Private mPaginaCorrente As Pagina

        Private lastResponse As String
        Private lastError As ErrorCodeEnum
        Private mParams As Dictionary(Of String, String)

        Private essig As WebEngine = WebEngine.Instance

        Private mContatoreAttuale As Integer
        Private mContatoreTotale As Integer

        Public Esito As Esito

        Public DebugParams As List(Of KeyValuePair(Of String, String))

        Public ReadOnly Property isCompleted() As Boolean
            Get
                Return (mStadioCorrente Is Nothing And mPaginaCorrente Is Nothing)
            End Get
        End Property

        Public Sub Process()
            If mStadioCorrente Is Nothing And mPaginaCorrente Is Nothing Then
                Start()
            End If

            Do Until (mStadioCorrente Is Nothing)
                Do Until (mPaginaCorrente Is Nothing)
                    RaiseEvent NavigatoreEvent(mPaginaCorrente.Testo, mContatoreAttuale * 100 \ mContatoreTotale)

                    If mPaginaCorrente.isAttivo(mStadioCorrente.Oggetto) Then
                        If PostEssing() Then
                            parseHtml()
                        Else
                            Return
                        End If
                    End If

                    PaginaSuccessiva()
                Loop
                StadioSuccessivo()
            Loop

            RaiseEvent NavigatoreEvent("", 100)
            Completed()
        End Sub

        Private Sub StadioSuccessivo()
            Dim i As Integer = 1 + mStadi.IndexOf(mStadioCorrente)
            If i < mStadi.Count Then
                mStadioCorrente = mStadi(i)
                mPaginaCorrente = mStadioCorrente.Fase.Pagine(0)
            Else
                mStadioCorrente = Nothing
                mPaginaCorrente = Nothing
            End If
        End Sub

        Private Sub PaginaSuccessiva()
            With mStadioCorrente.Fase.Pagine
                Dim i As Integer = 1 + .IndexOf(mPaginaCorrente)
                If i < .Count Then
                    mPaginaCorrente = .Item(i)
                Else
                    mPaginaCorrente = Nothing
                End If

#If DEBUG Then
                ' se ultima pagina dell'ultimo stadio (paginaFinaleRegistra.do) 
                ' non registra il preventivo
                If i = .Count - 1 Then
                    If mStadi.IndexOf(mStadioCorrente) = mStadi.Count - 1 Then
                        mPaginaCorrente = Nothing
                    End If
                End If
#End If

                mContatoreAttuale += 1
            End With

        End Sub

        Private Function PostEssing() As Boolean
            CallWeb(getUrl(), GetUrlParameters())

            If lastError = ErrorCodeEnum.NoError Then
                Return True
            Else
                ShowErrors()
                Return False
            End If
        End Function

        Private Function getUrl() As String
            Return mPaginaCorrente.Url
        End Function

        Private Function GetUrlParameters() As String
            Dim params As String = ""

            For Each Parametro As Parametro In mPaginaCorrente.Parametri
                params &= Parametro.URLEncode(mParams, mStadioCorrente.Oggetto)
            Next

            If params = "" Then
                Return Nothing
            Else
                'Return params.Substring(1) ' toglie la "&" iniziale 
                Return "flagDatiCambiati&forzatura.value=NO" & params

            End If

        End Function

        Private Sub CallWeb(url As String, parameters As String)
            lastResponse = essig.CallWeb(url, parameters)
            lastError = ErrorCode(lastResponse)
#If DEBUG Then
            If lastError <> ErrorCodeEnum.NoError Then
                Debug.Print(lastResponse)
            End If
#End If

        End Sub

        Private Sub ShowErrors()
#If DEBUG Then
            'MsgBox("url=" & mPaginaCorrente.Url)
#End If
            If lastError = ErrorCodeEnum.NoSession Then
                'MsgBox("Sessione utente non valida. Impossibile procedere.", MsgBoxStyle.Exclamation)
                Esito = New Esito("Sessione utente non valida. Impossibile procedere")
            ElseIf lastError = ErrorCodeEnum.AbendError Then
                'MsgBox("Errore non previsto.", MsgBoxStyle.Exclamation)
                Esito = New Esito("Errore non previsto")
            ElseIf lastError = ErrorCodeEnum.ApplicarionError Then

                Dim pagina As String = essig.CallWeb("Danni/essigRE/danni/error/emissioneErrorDetailView.do", Nothing)

                Dim errore As String = ""

                Do
                    Dim i As Integer = pagina.IndexOf("<strong>")
                    If i = -1 Then Exit Do
                    pagina = pagina.Substring(8 + i)
                    errore &= "-" & pagina.Substring(0, pagina.IndexOf("</strong>"))
                Loop

                If errore.Length > 3 Then
                    errore = errore.Substring(3) & vbNewLine & vbNewLine
                End If
                Do
                    Dim i As Integer = pagina.IndexOf("<td colspan=""6"">")
                    If i = -1 Then Exit Do
                    pagina = pagina.Substring(16 + i)
                    errore &= "-" & pagina.Substring(0, pagina.IndexOf("</td>"))
                Loop
                errore = errore.Replace("&nbsp;", " ").Trim()
                errore = errore.ToUpper.Replace("<BR>", "-")
                While errore.IndexOf("  ") >= 0
                    errore = errore.Replace("  ", " ")
                End While
                'MsgBox(errore, MsgBoxStyle.Exclamation)
                Esito = New Esito(errore)
                End If
        End Sub

        Public Sub Inizializza(filename As String)
            If File.Exists(filename) Then
                Dim objStreamReader As New StreamReader(filename)
                Dim x As New System.Xml.Serialization.XmlSerializer(New Processo().GetType)
                mProcesso = CType(x.Deserialize(objStreamReader), Processo)
                objStreamReader.Close()
            Else
                Dim sourceFile = New MemoryStream(CType(My.Resources.ResourceManager.GetObject(filename), Byte()))
                Using input As New GZipStream(sourceFile, CompressionMode.Decompress, False)
                    Using reader As New StreamReader(input)
                        Dim x As New System.Xml.Serialization.XmlSerializer(New Processo().GetType)
                        mProcesso = CType(x.Deserialize(reader), Processo)
                    End Using
                End Using

                sourceFile.Close()
            End If
            mStadi = New List(Of Stadio)
            mParams = New Dictionary(Of String, String)
            DebugParams = New List(Of KeyValuePair(Of String, String))

        End Sub

        Public Sub AddStadio(ByVal oggetto As Object, ByVal fase As Integer)
            mStadi.Add(New Stadio(oggetto, mProcesso.Fasi(fase)))
        End Sub

        Private Sub Start()
            mStadioCorrente = mStadi(0)
            mPaginaCorrente = mStadioCorrente.Fase.Pagine(0)
            mContatoreTotale = 0
            mContatoreAttuale = 0

            For Each s As Stadio In mStadi
                For Each p As Pagina In s.Fase.Pagine
                    mContatoreTotale += 1
                Next
            Next
        End Sub

        Public Sub Completed()
            Esito = New Esito

            Dim messaggio As String = "Preventivo"

            If mParams.ContainsKey("numeroArchivio.value") Then
                messaggio &= " numero " & mParams("numeroArchivio.value")
            End If
            messaggio &= " salvato correttamente in Essig."

            If mParams.ContainsKey("totalePremioLordo.value") Then
                'messaggio &= String.Format("{0}In Essig il totale premio lordo risulta essere di {1} Euro.", vbNewLine, mParams("totalePremioLordo.value"))
                Decimal.TryParse(mParams("totalePremioLordo.value"), Esito.PremioAnnuoLordo)
            End If

            Esito.Messaggio = messaggio
            Esito.Params = DebugParams
        End Sub

        Public Sub Reset()
            ' equivalente a premere il pulsante Esci (elimina il preventivo corrente)
            Dim p As String = essig.CallWeb("Danni/essigRE/esci.do", Nothing)
            'reinizia tutta la navigazione
            mStadioCorrente = Nothing
            mPaginaCorrente = Nothing
            mStadi = Nothing
            mParams = Nothing
        End Sub

        Private Sub parseHtml()
            Dim htmlDocument As IHTMLDocument2 = New HTMLDocumentClass()
            htmlDocument.write(lastResponse.Replace("<script", "<!--").Replace("</script>", "-->"))
            htmlDocument.close()

            Dim allElements As IHTMLElementCollection = htmlDocument.body.all

            For Each element As IHTMLInputElement In allElements.tags("input")
                If element.type <> "radio" And element.type <> "checkbox" Then
                    AddToParams(element.name, element.value)
                ElseIf element.checked = True Then
                    AddToParams(element.name, element.value)
                End If
            Next

            For Each element As HTMLSelectElement In allElements.tags("select")
                AddToParams(element.name, element.value)
            Next

            For Each element As HTMLTextAreaElement In allElements.tags("textarea")
                AddToParams(element.name, element.value)
            Next
        End Sub

        Private Sub AddToParams(elementName As String, elementValue As String)
            If (elementName IsNot Nothing) And (elementValue IsNot Nothing) Then
                If (mParams.ContainsKey(elementName)) Then
                    mParams(elementName) = elementValue
                Else
                    mParams.Add(elementName, elementValue)
                End If

                Try
                    DebugParams.Add(New KeyValuePair(Of String, String)(String.Format("stadio{0}.pagina{1}.{2}", mStadi.IndexOf(mStadioCorrente), mStadioCorrente.Fase.Pagine.IndexOf(mPaginaCorrente), elementName), elementValue))
                Catch ex As Exception
                End Try
            End If
        End Sub

        Protected Overrides Sub Finalize()
            If mPaginaCorrente IsNot Nothing Then
                Reset()
            End If
            MyBase.Finalize()
        End Sub
    End Class


    Public Class Stadio
        Public Oggetto As Object
        Public Fase As Fase
        Public Sub New(Oggetto As Object, Fase As Fase)
            Me.Oggetto = Oggetto
            Me.Fase = Fase
        End Sub
    End Class

    <Serializable()> Public Class Processo
        Public Fasi As New List(Of Fase)
    End Class

    <Serializable()> Public Class Fase
        Public Pagine As New List(Of Pagina)
    End Class

    <Serializable()> Public Class Pagina
        Public Url As String
        Public AttivoSe As String
        <XmlAttribute>
        Public Testo As String
        Public Debug As String
        Public Parametri As New List(Of Parametro)

        Public Function isAttivo(oggetto As Object) As Boolean
            If String.IsNullOrEmpty(AttivoSe) Then
                Return True
            Else
                Return GetValore(oggetto, AttivoSe)
            End If
        End Function
    End Class

    <Serializable()> Public Class Parametro
        <XmlAttribute>
        Public Nome As String
        <XmlAttribute>
        Public Valore As String
        <XmlAttribute>
        Public Funzione As String
        <XmlAttribute>
        Public SendIfNotNull As String

        Private Shared Funzioni As New Funzioni

        Public Sub New()
        End Sub

        Public Sub New(nome As String, valore As String, funzione As String, SendIfNotNull As String)
            Me.Nome = nome
            Me.Valore = valore
            Me.Funzione = funzione
            Me.SendIfNotNull = SendIfNotNull
        End Sub

        Public Function URLEncode(params As Dictionary(Of String, String), oggetto As Object) As String
            Dim v As Object = Nothing

            If Valore Is Nothing Then
                If params.ContainsKey(Nome) Then
                    v = params(Nome)
                Else
                    v = ""
                End If
            ElseIf Valore = "" Then
                v = ""
            ElseIf Valore.StartsWith("@") Then 'prende il valore di un'altro campo
                v = Valore.Substring(1)
                If params.ContainsKey(v) Then
                    v = params(v)
                Else
                    v = ""
                End If
            ElseIf Valore.StartsWith("=") Then
                v = Valore.Substring(1)
            ElseIf SendIfNotNull IsNot Nothing Then
                v = GetValore(oggetto, Valore)
                If String.IsNullOrEmpty(v) Then
                    Return ""
                End If
            Else
                v = GetValore(oggetto, Valore)
            End If

            Dim risultato As String = Nothing
            If Funzione Is Nothing OrElse Funzione.Length = 0 Then
                risultato = Funzioni.Standard(v)
            Else
                risultato = CStr(Funzioni.GetType().InvokeMember(Funzione, BindingFlags.InvokeMethod, Nothing, Funzioni, New Object() {v}))
            End If

            Return "&" & Nome & "=" & URLEncode(risultato)

        End Function

        Private Function URLEncode(EncodeStr As String) As String
            Dim i As Integer
            Dim erg As String

            erg = EncodeStr

            ' *** First replace '%' chr
            erg = Replace(erg, "%", Chr(1))

            ' *** then '+' chr
            erg = Replace(erg, "+", Chr(2))

            For i = 0 To 255
                Select Case i
                    ' *** Allowed 'regular' characters
                    Case 37, 43, 46, 48 To 57, 64, 65 To 90, 97 To 122

                    Case 1  ' *** Replace original %
                        erg = Replace(erg, Chr(i), "%25")

                    Case 2  ' *** Replace original +
                        erg = Replace(erg, Chr(i), "%2B")

                    Case 32
                        erg = Replace(erg, Chr(i), "+")

                    Case 3 To 15
                        erg = Replace(erg, Chr(i), "%0" & Hex(i))

                    Case Else
                        erg = Replace(erg, Chr(i), "%" & Hex(i))

                End Select
            Next

            URLEncode = erg

        End Function

    End Class

    Module libreria
        Public Function GetValore(ByVal oggetto As Object, ByVal campo As String) As Object

            Dim i As Integer = campo.IndexOf(".")

            If i >= 0 Then
                Dim camposx As String = campo.Substring(0, i)
                Dim campodx As String = campo.Substring(1 + i)

                Dim v As Object = oggetto.GetType().InvokeMember(camposx, BindingFlags.InvokeMethod Or BindingFlags.GetProperty Or BindingFlags.GetField, Nothing, oggetto, Nothing)
                If v Is Nothing Then
                    Return Nothing
                Else
                    Return GetValore(v, campodx)
                End If
            Else
                Return oggetto.GetType().InvokeMember(campo, BindingFlags.InvokeMethod Or BindingFlags.GetProperty Or BindingFlags.GetField, Nothing, oggetto, Nothing)
            End If

        End Function

    End Module

End Namespace
