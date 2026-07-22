Imports System.Xml

Module mgrMfs
    Public CARTELLA_OGGETTI As String
    Public CARTELLA_SETTING As String

    Public Function ManifestoLoad(sGruppo As String, sOggetto As String, utente As CUtente) As CManifestoSql

        Dim oMfs As CManifestoSql = Nothing
        Dim nodo As XmlNode

        Dim profilo As Object
        Dim uniProfili() As String
        Dim objProfili As String

        Dim sFileName As String
        sFileName = CARTELLA_OGGETTI & sGruppo & "\" & sOggetto & "\" & sOggetto & ".xml"
        If Dir(sFileName) = vbNullString Then
            Return Nothing
        End If

        uniProfili = utente.Profili

        Dim xml As New CXml
        If xml.LoadEncriptedXML(sFileName) Then
            If xml.GetNodeText("/oggetto/manifesto/scadenza") <> "" Then
                If CDate(xml.GetNodeText("/oggetto/manifesto/scadenza")) >= Date.Now Then
                    Select Case xml.GetNodeText("/oggetto/manifesto/tipo")

                        Case "query"
                            oMfs = New CManifestoSql
                    End Select

                    If oMfs IsNot Nothing Then
                        ' Autorizzazioni
                        If TypeOf oMfs Is IProfilatore Then
                            With CastPrf(oMfs)
                                For Each nodo In xml.GetNodes("/oggetto/autorizzazioni/profilo")
                                    .AddAutorizzazioni(xml.GetAttributeText(nodo, "nome"),
                                                       xml.GetAttributeText(nodo, "consenti"),
                                                       xml.GetAttributeText(nodo, "nega"))
                                Next
                            End With
                        End If

                        'Parametri runtime
                        If TypeOf oMfs Is ICriterio Then
                            Dim n As XmlNode
                            Dim params As New CParametri
                            Dim param As CParametro

                            For Each nodo In xml.GetNodes("/oggetto/parametri/parametro")
                                param = New CParametro
                                With param
                                    .Nome = xml.GetAttributeText(nodo, "nome")
                                    .Etichetta = xml.GetAttributeText(nodo, "etichetta")
                                    .ParseParamType(xml.GetAttributeText(nodo, "tipo"))
                                    If System.Environment.GetEnvironmentVariable(.Nome) = vbNullString Then
                                        .Valore = xml.GetAttributeText(nodo, "valore")
                                    Else
                                        .Valore = System.Environment.GetEnvironmentVariable(.Nome)
                                    End If
                                    If .Valore IsNot Nothing AndAlso .Valore.StartsWith("=") Then
                                        .Valore = ValutaEspressione(.Valore)
                                    End If
                                    .Obbligatorio = xml.GetAttributeBool(nodo, "obbligatorio")
                                    .Nascosto = xml.GetAttributeBool(nodo, "nascosto")
                                    .NuovaRiga = xml.GetAttributeBool(nodo, "nuovariga")
                                    .Larghezza = xml.GetAttributeLong(nodo, "larghezza")
                                    .Sinistra = xml.GetAttributeLong(nodo, "sinistra")
                                    .Altezza = xml.GetAttributeLong(nodo, "altezza")
                                    .MultiValore = xml.GetAttributeBool(nodo, "multivalore")
                                    .EditaValore = xml.GetAttributeBool(nodo, "editavalore")
                                    n = nodo.SelectSingleNode("elencovalori")
                                    If n IsNot Nothing Then .Elencovalori = Trim("" & n.InnerText)
                                End With

                                If params.Exists(param.Key) = False Then
                                    params.Add(param.Key, param)
                                End If
                            Next

                            If params.Count > 0 Then
                                oMfs.Parametri = params
                            End If
                        End If

                        If TypeOf oMfs Is ICriterio Then
                            With oMfs
                                For Each nodo In xml.GetNodes("/oggetto/estrazione/sql")
                                    objProfili = xml.GetAttributeText(nodo, "profili")
                                    For Each profilo In uniProfili
                                        If InStr(1, objProfili, profilo, vbTextCompare) Then
                                            .Sql = nodo.InnerText
                                            Exit For
                                        End If
                                    Next
                                Next
                            End With
                        End If

                        ' Dati generali
                        oMfs.RootPath = CARTELLA_OGGETTI
                        oMfs.Gruppo = sGruppo
                        oMfs.Nome = sOggetto
                        oMfs.DisplayNome = xml.GetNodeText("/oggetto/manifesto/nome")
                        oMfs.Pacchetto = xml.GetNodeText("/oggetto/manifesto/pacchetto")
                        oMfs.Descrizione = xml.GetNodeText("/oggetto/manifesto/descrizione")
                        oMfs.Documentazione = xml.GetNodeText("/oggetto/manifesto/documentazione")
                        oMfs.AltezzaDocumentazione = xml.GetAttributeLong(xml.GetNode("/oggetto/manifesto/documentazione"), "altezza")
                        oMfs.Categoria = xml.GetNodeText("/oggetto/manifesto/categoria")
                        oMfs.Dominio = xml.GetNodeText("/oggetto/manifesto/dominio")
                        oMfs.Proprietario = xml.GetNodeText("/oggetto/manifesto/proprietario")
                        oMfs.Note = xml.GetNodeText("/oggetto/manifesto/note")
                        oMfs.Stato = xml.GetNodeText("/oggetto/manifesto/stato")
                        oMfs.UltAgg = xml.GetNodeText("/oggetto/manifesto/ultagg")
                        oMfs.Contenuto = xml.GetNodeText("/oggetto/manifesto/contenuto")
                        oMfs.Applicazioni = xml.GetNodeText("/oggetto/manifesto/applicazioni")
                        Return oMfs
                    End If
                End If
            End If
        End If

        Return Nothing
    End Function

    Public Function ManifestiLoad(utente As CUtente, gruppo As String) As CManifestiSql
        Dim mfsSet As New CManifestiSql

        Dim oggetti As New List(Of String)

        Dim oggetto As String = Dir(CARTELLA_OGGETTI & gruppo & "\", vbDirectory)

        While oggetto <> vbNullString
            If oggetto <> "." And oggetto <> ".." Then
                If (GetAttr(CARTELLA_OGGETTI & gruppo & "\" & oggetto) And vbDirectory) = vbDirectory Then
                    oggetti.Add(oggetto)
                End If
            End If
            oggetto = Dir()
        End While

        For Each oggetto In oggetti
            Dim mfs As CManifesto = ManifestoLoad(gruppo, oggetto, utente)
            If mfs IsNot Nothing Then
                If (mfs.StatoInterno = CManifesto.EStatoInterno.ESI_NORMALE) Then
                    If Utils.Utente.AutorizzatoAdLeggere(mfs) Then
                        mfsSet.Add(oggetto, mfs)
                    End If
                End If
            End If
        Next

        Return mfsSet
    End Function

    Public Function ValutaEspressione(Espressione As String) As String
        Try
            'utilizza sql server per simulare una funzione EVAL()
            Dim sql As String
            If Espressione.ToUpper.StartsWith("=SELECT") Then
                sql = Espressione.Substring(1)
            Else
                sql = "SELECT " + Espressione.Substring(1)
            End If
            Return Utx.WsCommand.Eval(sql)
        Catch ex As Exception
            Return ""
        End Try
    End Function
End Module
