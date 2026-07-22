Imports System.IO
Imports System.Xml
Imports System.Text
Imports System.Net

Public Class TTYCreo

    Public Enum TipoFile
        OMNIA
        PRIMA_NOTA
        PRIMA_NOTA_ESSIG
        PRIMA_NOTA_ESSIG_NC
    End Enum

    'annuncio: https://gs.ttycreo.it/webservice/import/announce_3p/[codice_cliente]/[identificativo_procedura]/[codice_azienda]/[codice_agenzia]/[key]
    Const UrlAnnuncio As String = "https://gs.ttycreo.it/webservice/import/announce_3p/{0}/unitools/{0}01/1/{1}"
    'esclusioni: https://gs.ttycreo.it/webservice/import/exclusion/[codice_cliente]/[auth_key]/[funzionalita_id]/[codice_azienda]
    Const UrlEsclusioni As String = "https://gs.ttycreo.it/webservice/import/exclusion/{0}/{1}/{2}/{0}01"
    'upload: https://gs.ttycreo.it/webservice/import/send/[codice_cliente]/[auth_key]/[funzionalita_id]/[codice_azienda]/[codice_agenzia]
    Const UrlUpload As String = "https://gs.ttycreo.it/webservice/import/send/{0}/{1}/{2}/{0}01/{3}"

    Private Log As New Utx.ApplicationLog("UploadTTY.log")

    Sub New(Tipo As TipoFile)
        mTipo = Tipo
        mListaUpload = New List(Of String)
    End Sub

    Private mTipo As TipoFile
    Public Property Tipo() As TipoFile
        Get
            Return mTipo
        End Get
        Set(value As TipoFile)
            mTipo = value
        End Set
    End Property

    Private mCliente As String
    Public Property Cliente() As String
        Get
            Return mCliente
        End Get
        Set(value As String)
            mCliente = value
        End Set
    End Property

    Private mAgenzia As String
    Public Property Agenzia() As String
        Get
            Return mAgenzia
        End Get
        Set(value As String)
            mAgenzia = value
        End Set
    End Property

    Private mUtente As String
    Public Property Utente() As String
        Get
            Return mUtente
        End Get
        Set(value As String)
            mUtente = value
        End Set
    End Property

    Private mPassword As String
    Public Property Password() As String
        Get
            Return mPassword
        End Get
        Set(value As String)
            mPassword = value
        End Set
    End Property

    Private mAuthKey As String
    Public Property AuthKey() As String
        Get
            Return mAuthKey
        End Get
        Set(value As String)
            mAuthKey = value
        End Set
    End Property

    Private mFunzionalita As String
    Public Property Funzionalita() As String
        Get
            Return mFunzionalita
        End Get
        Set(value As String)
            mFunzionalita = value
        End Set
    End Property

    Private mStepId As String
    Public Property StepId() As String
        Get
            Return mStepId
        End Get
        Set(value As String)
            mStepId = value
        End Set
    End Property

    Private mListaUpload As List(Of String)
    Public Property ListaUpload() As List(Of String)
        Get
            Return mListaUpload
        End Get
        Set(value As List(Of String))
            mListaUpload = value
        End Set
    End Property

    Public ReadOnly Property InizioInvioPNota() As Date
        Get
            Dim ValoreDefault As Date = #1/1/2017#
            Dim Chiave As String = Utx.Globale.SettingInterop.LeggiValore(Utx.GestioneFlag.TipoFlag.TTY_DATA_UPLOAD_PNOTA, ValoreDefault)

            If IsDate(Chiave) Then
                Return CDate(Chiave).AddDays(-7)
            Else
                Return ValoreDefault
            End If
        End Get
    End Property

    Public ReadOnly Property InizioInvioOmnia() As Date
        Get
            Dim ValoreDefault As Date = #1/1/2017#
            Dim Chiave As String = Utx.Globale.SettingInterop.LeggiValore(Utx.GestioneFlag.TipoFlag.TTY_DATA_UPLOAD_OMNIA, ValoreDefault)

            If IsDate(Chiave) Then
                Return CDate(Chiave).AddDays(-7)
            Else
                Return ValoreDefault
            End If
        End Get
    End Property

    Public ReadOnly Property InizioInvioPNotaEssig() As Date
        Get
            Dim ValoreDefault As Date = #1/1/2017#
            Dim Chiave As String = Utx.Globale.SettingInterop.LeggiValore(Utx.GestioneFlag.TipoFlag.TTY_DATA_UPLOAD_PNOTA_ESSIG, ValoreDefault)

            If IsDate(Chiave) Then
                Return CDate(Chiave).AddDays(1)
            Else
                Return ValoreDefault
            End If
        End Get
    End Property

    Public ReadOnly Property InizioInvioPNotaEssigNC() As Date
        Get
            Dim ValoreDefault As Date = #1/1/2017#
            Dim Chiave As String = Utx.Globale.SettingInterop.LeggiValore(Utx.GestioneFlag.TipoFlag.TTY_DATA_UPLOAD_PNOTA_ESSIG_NC, ValoreDefault)

            If IsDate(Chiave) Then
                Return CDate(Chiave).AddDays(1)
            Else
                Return ValoreDefault
            End If
        End Get
    End Property

    Private Function Key() As String
        Return Utx.NetFunc.StringToSHA256(String.Concat("!a!", mCliente, "$wr@72fht", mUtente, "9€9akj29€r", Utx.NetFunc.StringToSHA256(mPassword),
                                                        "8j$2&245aa", Format(Now(), "yyyyMMddHH"), "!z!"))
    End Function

    Private Function Annuncio() As Boolean
        Try

#If DEBUG Then
            Exit Function
#End If
            'per il momento utilizzato solo dall'agenzia 2379
            mCliente = "302379"
            mAgenzia = "1"
            mUtente = "agente"
            mPassword = "00000000"

            'leggo la chiave di autenticazione
            Dim Chiave As String = Utx.Globale.SettingGlobale.LeggiValore(Utx.GestioneFlag.TipoFlag.TTY_AUTHKEY, "")

            If String.IsNullOrEmpty(Chiave) Then
                'se le chiavi non sono valide faccio l'annuncio
                Dim url As String = String.Format(UrlAnnuncio, mCliente, Key)
                Dim request As Net.HttpWebRequest = Net.HttpWebRequest.Create(url)
                request.Proxy = Utx.Globale.UniProxy.Proxy
                request.AllowAutoRedirect = False

                ' Get the response.
                Dim response As Net.HttpWebResponse = request.GetResponse()

                Dim xDoc As New XmlDocument
                xDoc.Load(response.GetResponseStream)

                Dim StatusCode As Integer = xDoc.SelectSingleNode("//httpstatus/code").InnerText

                If StatusCode = 201 Then
                    Log.Info("Annuncio OK")

                    mAuthKey = xDoc.SelectSingleNode("//data/authkey").InnerText
                    mFunzionalita = xDoc.SelectSingleNode("//data/procedure/procedura").Attributes("funzionalita").Value
                    mStepId = xDoc.SelectSingleNode("//data/procedure/procedura").Attributes("step").Value

                    'memorizzo le chiavi per le prossime trasmissioni
                    Utx.Globale.SettingGlobale.AggiungiModifica(Utx.GestioneFlag.TipoFlag.TTY_AUTHKEY,
                                                                String.Format("{0};{1};{2}", mAuthKey, mFunzionalita, mStepId))

                    Return True
                Else
                    Return False
                End If
            Else
                'chiavi valide
                mAuthKey = Chiave.Split(";")(0)
                mFunzionalita = Chiave.Split(";")(1)
                mStepId = Chiave.Split(";")(2)

                Return True
            End If

        Catch ex As Exception
            Utx.Globale.SettingGlobale.Rimuovi(Utx.GestioneFlag.TipoFlag.TTY_AUTHKEY)
            Log.Info(ex)
            Return False
        End Try
    End Function

    Private Function Esclusioni() As Boolean
        Try
            Dim url As String = String.Format(UrlEsclusioni, mCliente, mAuthKey, mFunzionalita)

            Dim postData As String = ""
            For k As Integer = 0 To mListaUpload.Count - 1
                postData += "&file[]=" + ZipToContenuto(mListaUpload.Item(k))
            Next
            postData = postData.Substring(1) 'tolgo la & iniziale

            Dim byteArray As Byte() = Text.Encoding.UTF8.GetBytes(postData)

            Dim request As Net.HttpWebRequest = Net.HttpWebRequest.Create(url)
            With request
                .Proxy = Utx.Globale.UniProxy.Proxy
                .Method = "POST"
                .ContentType = "application/x-www-form-urlencoded"
                .ContentLength = byteArray.Length
                'scrivo i dati post nella request
                .GetRequestStream().Write(byteArray, 0, byteArray.Length)
            End With

            Dim response As Net.HttpWebResponse

            Try
                response = request.GetResponse()
            Catch ex As WebException
                If (ex.Response IsNot Nothing) Then
                    response = ex.Response
                Else
                    Throw ex
                End If
            End Try

            Dim xDoc As New XmlDocument
            xDoc.Load(response.GetResponseStream)

            Dim StatusCode As Integer = xDoc.SelectSingleNode("//httpstatus/code").InnerText

            If StatusCode = 200 Then
                Log.Info("Lista esclusioni:")

                Dim ListaEsclusioni As XmlNodeList = xDoc.SelectNodes("//data/file")
                For Each n As XmlNode In ListaEsclusioni

                    Dim NomeFile = ContenutoToZip(n.InnerText).ToUpper
                    Log.Info(n.InnerText)

                    'tolgo il file dalla lista
                    For Each f As String In mListaUpload
                        If Path.GetFileName(f).ToUpper = NomeFile Then
                            mListaUpload.Remove(f)
                            Exit For
                        End If
                    Next
                Next

                Log.Info("Esclusioni OK")
            Else
                Throw New Exception(String.Format("Errore HTTP {1}: {2} ({3}){0}OuterXml: {4}",
                                  Environment.NewLine,
                                  StatusCode,
                                  xDoc.SelectSingleNode("//httpstatus/description").InnerText,
                                  xDoc.SelectSingleNode("//httpstatus/custom-description").InnerText,
                                  xDoc.OuterXml))
            End If

            Return True

        Catch ex As Exception
            Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Function Upload() As Boolean
        Try
            'se non ci sono file da trasmettere
            If mListaUpload.Count = 0 Then
                Log.Info("Nessun nuovo file da trasmettere")
                Return True
            End If
            'annuncio
            If Annuncio() = False Then Return False
            'esclusioni
            If Esclusioni() = False Then Return False
            'controllo se ci sono file da trasmettere dopo le esclusioni
            If mListaUpload.Count = 0 Then
                Log.Info("Nessun nuovo file da trasmettere")
                Return True
            End If

            'invio i file
            Log.Info(String.Format("Invio di {0} file:", mListaUpload.Count))

            Dim url As String = String.Format(UrlUpload, mCliente, mAuthKey, mFunzionalita, mAgenzia)

            Dim sb As New StringBuilder

            For Each f As String In mListaUpload
                Log.Info(String.Format("Invio file {0}", Path.GetFileName(f)))

                Dim Checksum As String = Utx.NetFunc.Crc32.FileChecksum(f).ToLower

                sb.Append("chunk-uid=" + Guid.NewGuid.ToString)
                sb.Append("&step-id=" + mStepId)
                sb.Append("&checksum=" + Checksum)
                sb.Append("&chunk-checksum=" + Checksum)
                sb.Append("&chunk-total=1")
                sb.Append("&chunk-current=1")
                sb.Append("&chunk-merge=true")
                sb.Append("&chunk-data=" + Web.HttpUtility.UrlEncode(Convert.ToBase64String(File.ReadAllBytes(f))))
                sb.Append("&lastst=" + Format(Now, "yyyyMMddHHmmssfff"))
                sb.Append("&queue=false")
                sb.Append("&archive=true")

                Dim byteArray As Byte() = Text.Encoding.UTF8.GetBytes(sb.ToString)

                Dim request As Net.HttpWebRequest = Net.HttpWebRequest.Create(url)
                With request
                    .Proxy = Utx.Globale.UniProxy.Proxy
                    .Method = "POST"
                    .ContentType = "application/x-www-form-urlencoded"
                    .ContentLength = byteArray.Length
                    'scrivo i dati post nella request
                    .GetRequestStream().Write(byteArray, 0, byteArray.Length)
                End With

                Dim response As Net.HttpWebResponse

                Try
                    response = request.GetResponse()
                Catch ex As WebException
                    If (ex.Response IsNot Nothing) Then
                        response = ex.Response
                    Else
                        Throw ex
                    End If
                End Try

                Dim xDoc As New XmlDocument
                xDoc.Load(response.GetResponseStream)

                Dim StatusCode As Integer = xDoc.SelectSingleNode("//httpstatus/code").InnerText

                If StatusCode = 201 Then
                    Log.Info("File inviato correttamente")
                Else
                    Throw New Exception(String.Format("Errore HTTP {1}: {2} ({3}){0}OuterXml: {4}",
                                                      Environment.NewLine,
                                                      StatusCode,
                                                      xDoc.SelectSingleNode("//httpstatus/description").InnerText,
                                                      xDoc.SelectSingleNode("//httpstatus/custom-description").InnerText,
                                                      xDoc.OuterXml))
                End If
                'svuoto lo string builder
                sb.Length = 0
            Next

            'scrivo la chiave calendario
            Select Case mTipo
                Case TipoFile.OMNIA
                    Utx.Globale.SettingInterop.AggiungiModifica(Utx.GestioneFlag.TipoFlag.TTY_DATA_UPLOAD_OMNIA, Format(Today, "dd/MM/yyyy"))
                Case TipoFile.PRIMA_NOTA
                    Utx.Globale.SettingInterop.AggiungiModifica(Utx.GestioneFlag.TipoFlag.TTY_DATA_UPLOAD_PNOTA, Format(Today, "dd/MM/yyyy"))
                Case TipoFile.PRIMA_NOTA_ESSIG
                    Utx.Globale.SettingInterop.AggiungiModifica(Utx.GestioneFlag.TipoFlag.TTY_DATA_UPLOAD_PNOTA_ESSIG, Format(Today, "dd/MM/yyyy"))
                Case TipoFile.PRIMA_NOTA_ESSIG_NC
                    Utx.Globale.SettingInterop.AggiungiModifica(Utx.GestioneFlag.TipoFlag.TTY_DATA_UPLOAD_PNOTA_ESSIG_NC, Format(Today, "dd/MM/yyyy"))
            End Select

            Log.Info("Invio concluso correttamente")

            Return True

        Catch ex As Exception
            Log.Errore(ex)
            Return False
        End Try
    End Function

    Private Function ZipToContenuto(NomeFile As String) As String

        NomeFile = Path.GetFileNameWithoutExtension(NomeFile)

        Select Case mTipo
            Case TipoFile.PRIMA_NOTA, TipoFile.PRIMA_NOTA_ESSIG, TipoFile.PRIMA_NOTA_ESSIG_NC
                Return String.Format("{0}.{1}", NomeFile, "csv")
            Case Else 'omnia
                Return String.Format("{0}.{1}", Left(NomeFile, 14), Right(NomeFile, 3))
        End Select
    End Function

    Private Function ContenutoToZip(NomeFile As String) As String
        Select Case mTipo
            Case TipoFile.PRIMA_NOTA, TipoFile.PRIMA_NOTA_ESSIG, TipoFile.PRIMA_NOTA_ESSIG_NC
                Return String.Format("{0}.zip", Path.GetFileNameWithoutExtension(NomeFile))
            Case Else 'omnia
                Return Path.GetFileName(NomeFile).Replace(".", "") + ".zip"
        End Select
    End Function
End Class
