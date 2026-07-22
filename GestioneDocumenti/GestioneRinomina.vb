Imports System.Xml
Imports System.IO

Public Class GestioneRinomina

    Dim mFileRinomina As String
    Friend TagStandard As String = "*"

    Friend Enum TipoDoc
        standard = 0
        utente = 1
    End Enum

    Sub New()
        mFileRinomina = Path.Combine(Utx.Globale.Paths.CartellaUnitoolsRete, "RinominaDoc.xml")
        InitFileRinomina()

        If EsisteElemento("Richiesta CONSAP") = False Then
            AggiungiDocumento("Richiesta CONSAP", TipoDoc.standard)
        End If
        'aggiunta documenti privacy
        If EsisteElemento("Privacy Agenzia EU base") = False Then
            EliminaDocumentoStandard("Privacy")

            AggiungiDocumento("Privacy Agenzia", TipoDoc.standard)
            AggiungiDocumento("Privacy Agenzia EU base", TipoDoc.standard)
            AggiungiDocumento("Privacy Agenzia EU 1", TipoDoc.standard)
            AggiungiDocumento("Privacy Agenzia EU 2", TipoDoc.standard)
            AggiungiDocumento("Privacy Agenzia EU 3", TipoDoc.standard)
            AggiungiDocumento("Privacy Agenzia EU 4", TipoDoc.standard)
            AggiungiDocumento("Privacy Compagnia", TipoDoc.standard)
            AggiungiDocumento("Privacy Compagnia EU 1-2", TipoDoc.standard)
            AggiungiDocumento("Privacy Compagnia Omnibus", TipoDoc.standard)
        End If
    End Sub

    Sub New(FileRinomina As String)
        mFileRinomina = String.Format("{0}\{1}.xml", Utx.Globale.Paths.CartellaUnitoolsRete, Path.GetFileNameWithoutExtension(FileRinomina))
        InitFileRinomina()
    End Sub

    Private Sub InitFileRinomina()
        Try
            If File.Exists(mFileRinomina) Then Exit Try

            Dim xmlDoc As New XmlDocument

            Dim xmlNode As XmlElement = xmlDoc.CreateElement("documenti")
            xmlDoc.AppendChild(xmlNode)

            For Each d As String In DocumentiStandard()
                xmlNode.AppendChild(CreaElemento(xmlNode, d))
            Next

            'importo i vecchi elementi
            Dim FileIni As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "RinominaDoc.ini")

            If File.Exists(FileIni) Then

                Using sr As New StreamReader(FileIni)

                    Do While Not sr.EndOfStream

                        Dim Riga As String = sr.ReadLine.Trim

                        If Not Riga.StartsWith("Selezionare il nome...", StringComparison.InvariantCultureIgnoreCase) Then

                            If Not EsisteElemento(xmlDoc, Riga) Then
                                xmlNode.AppendChild(CreaElemento(xmlNode, Riga.Trim, TipoDoc.utente))
                            End If
                        End If
                    Loop
                End Using
            End If

            SalvaXml(xmlDoc)

            'cancello il vecchio file ini
            File.Delete(FileIni)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub SalvaXml(ByRef xmlDoc As XmlDocument)
        Try
            'se il file già esiste faccio backup
            If File.Exists(mFileRinomina) Then
                Dim FileBackup As String = mFileRinomina + ".bak"
                File.Delete(FileBackup)
                My.Computer.FileSystem.RenameFile(mFileRinomina, Path.GetFileName(FileBackup))
            End If

            'salvo
            xmlDoc.Save(mFileRinomina)

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Friend Function EsisteElemento(ByRef xmlDoc As XmlDocument,
                                   NomeDocumento As String) As Boolean
        Try
            For Each el As XmlElement In xmlDoc.DocumentElement
                If String.Compare(el.GetAttribute("nome").Trim, NomeDocumento.Trim, True) = 0 Then
                    Return True
                End If
            Next

            Return False

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return True 'così non aggiunge
        End Try
    End Function

    Friend Function EsisteElemento(NomeDocumento As String) As Boolean
        Try
            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(mFileRinomina)

            For Each el As XmlElement In xmlDoc.DocumentElement
                If String.Compare(el.GetAttribute("nome").Trim, NomeDocumento.Trim, True) = 0 Then
                    Return True
                End If
            Next

            Return False

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return True 'così non aggiunge
        End Try
    End Function

    Private Function CreaElemento(ParentNode As XmlNode,
                                  NomeDocumento As String,
                                  Optional Tipo As TipoDoc = TipoDoc.Standard) As XmlElement

        Dim xmlEl As XmlElement = ParentNode.OwnerDocument.CreateElement("documento")
        xmlEl.SetAttribute("nome", NomeDocumento)
        xmlEl.SetAttribute("tipo", Tipo.ToString)

        Return xmlEl
    End Function

    Friend Function AggiungiDocumento(NomeDocumento As String,
                                      Optional Tipo As TipoDoc = TipoDoc.utente) As Boolean
        Try
            Select Case NomeDocumento.Trim.Length

                Case Is < 3
                    MsgBox("Il nome del documento deve essere di almeno 3 caratteri", MsgBoxStyle.Exclamation, "Predefiniti")
                    Return False

                Case Else
                    Dim xmlDoc As New XmlDocument
                    xmlDoc.Load(mFileRinomina)

                    If EsisteElemento(xmlDoc, NomeDocumento) = False Then
                        Dim xmlNode As XmlElement = xmlDoc.SelectSingleNode("documenti")
                        xmlNode.AppendChild(CreaElemento(xmlNode, NomeDocumento, Tipo))
                        SalvaXml(xmlDoc)

                        Return True
                    Else
                        MsgBox("Nome già presente nella lista", MsgBoxStyle.Information, "Predefiniti")
                        Return False
                    End If
            End Select

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Friend Function EliminaDocumento(NomeDocumento As String) As Boolean
        Try
            NomeDocumento = NomeDocumento.Replace(TagStandard, "").Trim

            Dim xmlDoc As New XmlDocument, el As XmlElement
            xmlDoc.Load(mFileRinomina)

            For Each xn As XmlElement In xmlDoc.SelectNodes("//documento")

                el = xn

                If String.Compare(el.GetAttribute("nome").Trim, NomeDocumento, True) = 0 Then

                    If String.Compare(el.GetAttribute("tipo"), TipoDoc.utente.ToString, True) = 0 Then

                        If MsgBox("Confermate l'eliminazione dell'elemento dalla lista?",
                                  MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Question,
                                  "Predefiniti") = Windows.Forms.DialogResult.Yes Then

                            xn.ParentNode.RemoveChild(xn)
                            SalvaXml(xmlDoc)
                            Return True
                        Else
                            Return False
                        End If
                    Else
                        MsgBox("Gli elementi standard (*) non possono essere eliminati.", MsgBoxStyle.Exclamation, "Predefiniti")
                        Return False
                    End If
                End If
            Next
            Return False

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Private Sub EliminaDocumentoStandard(NomeDocumento As String)
        Try
            'cancellazione da codice per manutenzione lista
            NomeDocumento = NomeDocumento.Replace(TagStandard, "").Trim

            Dim xmlDoc As New XmlDocument
            xmlDoc.Load(mFileRinomina)

            For Each xn As XmlElement In xmlDoc.SelectNodes("//documento")
                If String.Compare(xn.GetAttribute("tipo"), TipoDoc.standard.ToString, True) = 0 Then
                    If xn.GetAttribute("nome").StartsWith(NomeDocumento, StringComparison.InvariantCultureIgnoreCase) = True Then
                        xn.ParentNode.RemoveChild(xn)
                    End If
                End If
            Next
            SalvaXml(xmlDoc)
        Catch ex As Exception
            Globale.Log.Info(ex.Message)
        End Try
    End Sub

    Friend Function ListaDocumenti() As ArrayList
        Try
            Dim xDoc As New XmlDocument
            xDoc.Load(mFileRinomina)

            Dim Lista As New ArrayList

            Dim xnl As XmlNodeList = xDoc.SelectNodes("//documento")

            For Each xn As XmlNode In xnl

                If xn.Attributes.Count > 0 Then

                    If String.Compare(xn.Attributes("tipo").InnerText, TipoDoc.standard.ToString, True) = 0 Then
                        Lista.Add(String.Format("{0} {1}", xn.Attributes("nome").InnerText, TagStandard))
                    Else
                        Lista.Add(xn.Attributes("nome").InnerText)
                    End If
                End If
            Next

            Return Lista

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return New ArrayList
        End Try
    End Function

    Friend Function NormalizzaNomeDocumento(NomeDocumento As String) As String
        Return NomeDocumento.Replace(TagStandard, "").Trim
    End Function

    Private Function DocumentiStandard() As List(Of String)

        Dim Lista As New List(Of String)

        With Lista
            .Add("7A")
            .Add("Attestato di Rischio")
            .Add("Atto di accertamento")
            .Add("Atto di Citazione")
            .Add("CAI")
            .Add("Carta d'Identità")
            .Add("Codice Fiscale")
            .Add("Copia verbale autorita")
            .Add("Denuncia")
            .Add("Denuncia Firmata")
            .Add("Documentazione Medica")
            .Add("Esito offerta Commerciale")
            .Add("Fattura")
            .Add("Fax Sertel - Liquido")
            .Add("Libretto")
            .Add("Negazione eventi")
            .Add("Patente")
            .Add("Perizia")
            .Add("Polizza")
            .Add("Preventivo")
            .Add("Privacy Agenzia")
            .Add("Privacy Agenzia Europea")
            .Add("Privacy Compagnia")
            .Add("Privacy Compagnia EU 1-2 ")
            .Add("Privacy Compagnia Omnibus")
            .Add("Ricevuta fiscale")
            .Add("Richiesta CONSAP")
            .Add("Richiesta danni")
            .Add("Tessera convenzione")
            .Add("Testimonianza")
        End With

        Return Lista
    End Function
End Class
