Imports System.IO
Imports Microsoft.Web.Services3.Security.Tokens

Public Class ServiziSinistri

    'Public Enum TipoAmbiente
    '    PROD = 0
    '    COLLAUDO = 1
    'End Enum

    'Private Shared Function UrlListaDocumentiLiquido(Ambiente As TipoAmbiente) As String
    '    '1.metodo: docINList
    '    If Ambiente = TipoAmbiente.PROD Then
    '        Return "https://wsproxy.unipol.it/essigSXCC/ws/it/unipol/sx/service/unitools/UploaderUnitools/soap11"
    '    Else
    '        Return "https://wsproxy-coll.unipol.it/essigSXCC/ws/it/unipol/sx/service/unitools/UploaderUnitools/soap11"
    '    End If
    'End Function

    'Private Shared Function UrlListaSinistri(Ambiente As TipoAmbiente) As String
    '    '(senza numero).metodo: getListaSinistriDelGiornoPerUtente
    '    If Ambiente = TipoAmbiente.PROD Then
    '        Return "https://mpgw.unipol.it/essigSXCC/services/SinistriServiceForAgenzie" 'in prod prima di jboss - RIMANE UGUALE??
    '    Else
    '        Return "https://wsappscoll.unipolassicurazioni.it/essigSXCC/services/SinistriServiceForAgenzie"
    '    End If
    'End Function

    'Private Shared Function UrlListaDocumentiSinistro(Ambiente As TipoAmbiente) As String
    '    '2.metodo: getDocumentoInfoList
    '    If Ambiente = TipoAmbiente.PROD Then
    '        Return "https://wsproxy.unipol.it/essigSXCC/ws/it/unipol/sx/webservice/unitools/DocumentiAgenziaAPI/soap11"
    '    Else
    '        Return "https://wsappscoll.unipolassicurazioni.it/essigSXCC/ws/it/unipol/sx/webservice/unitools/DocumentiAgenziaAPI/soap11"
    '    End If
    'End Function

    'Private Shared Function UrlScaricaDocumentoSinistro(Ambiente As TipoAmbiente) As String
    '    '3.metodo: uniDownloadFromLiquido
    '    If Ambiente = TipoAmbiente.PROD Then
    '        Return "https://wsproxy.unipol.it/essigSXCC/ws/it/unipol/sx/service/unitools/UploaderUnitools/soap11" 'Errore nel documento XML.
    '    Else
    '        Return " https://wsproxy-coll.unipol.it/essigSXCC/ws/it/unipol/sx/service/unitools/UploaderUnitools/soap11 "
    '    End If
    'End Function

    'Private Shared Function UrlLeggiPosizioniSinistro(Ambiente As TipoAmbiente) As String
    '    '4.metodo: getSinistroDettaglio
    '    If Ambiente = TipoAmbiente.PROD Then
    '        Return "https://wsproxy.unipol.it/essigSXCC/ws/it/unipol/sx/webservice/unitools/SinistriAgenziaAPI/soap11"
    '    Else
    '        Return "  https://wsappscoll.unipolassicurazioni.it/essigSXCC/ws/it/unipol/sx/webservice/unitools/SinistriAgenziaAPI/soap11 "
    '    End If
    'End Function

    'Private Shared Function UrlInviaDocumento(Ambiente As TipoAmbiente) As String
    '    '5.metodo: uniUploadToLiquido
    '    If Ambiente = TipoAmbiente.PROD Then
    '        Return "https://wsproxy.unipol.it/essigSXCC/ws/it/unipol/sx/service/unitools/UploaderUnitools/soap11"
    '    Else
    '        Return " https://wsproxy-coll.unipol.it/essigSXCC/ws/it/unipol/sx/service/unitools/UploaderUnitools/soap11"
    '    End If
    'End Function

    'Public Shared Function ListaSinistri(Inizio As Date,
    '                                     Fine As Date,
    '                                     Optional Ambiente As TipoAmbiente = TipoAmbiente.PROD) As Utx.ServiziSinistri.EsitoChiamata

    '    Dim Esito As New Utx.ServiziSinistri.EsitoChiamata

    '    Try
    '        Utx.Globale.Log.Info("Richiesta lista sinistri dal {0:dd/MM/yyyy} al {1:dd/MM/yyyy}", {Inizio, Fine})
    '        Utx.Globale.Log.AumentaRientro()

    '        Esito.ListaInfoSinistri = New List(Of JBImportaSinistri.DettaglioSinistro)

    '        Using s As New JBImportaSinistri.SinistriServiceForAgenzieService
    '            s.SoapVersion = Web.Services.Protocols.SoapProtocolVersion.Soap12
    '            s.Url = UrlListaSinistri(Ambiente)
    '            s.RequestSoapContext.Security.Tokens.Add(UserToken)
    '            s.Timeout = 60000 '1 minuto

    '            Dim Sinistri As JBImportaSinistri.Result
    '            Dim Dettaglio As JBImportaSinistri.DettaglioSinistro

    '            Dim Giorno As Date = Inizio
    '            Do While Giorno <= Fine
    '                Utx.Globale.Log.Info("Richiesta per il giorno {0}", {Giorno.ToString})

    '                Sinistri = s.getListaSinistriDelGiornoPerUtente(Utx.Globale.UtenteCorrente.UniageUser.ToUpper, Format(Giorno, "yyyyMMdd")) 'metodo in wsdl SinistriServiceForAgenzie
    '                Utx.Globale.Log.Info("Risposta per il giorno {0}: {1} sinistri", {Giorno.ToString, Sinistri.SinistroInfo.Length})

    '                For Each sinistro In Sinistri.SinistroInfo
    '                    Utx.Globale.Log.Info("Richiesta dettaglio sinistro {0}", {sinistro.Numero})
    '                    Dettaglio = s.getSinistroDettaglio(Utx.Globale.UtenteCorrente.UniageUser.ToUpper, sinistro.Numero).DettaglioSinistro

    '                    Utx.Globale.Log.Info("dettaglio aggiunto alla lista")
    '                    Esito.ListaInfoSinistri.Add(Dettaglio)
    '                Next

    '                Giorno = Giorno.AddDays(1)
    '            Loop
    '        End Using
    '        Esito.Esito = True
    '        Utx.Globale.Log.DiminuisciRientro()
    '        Utx.Globale.Log.Info("Letti {0} sinistri", {Esito.ListaInfoSinistri.Count})

    '    Catch ex As Exception
    '        Utx.Globale.Log.DiminuisciRientro()
    '        Utx.Globale.Log.Errore(ex)
    '        Esito.Esito = False
    '        Esito.Errore = ex.Message
    '    End Try

    '    Return Esito
    'End Function

    'Public Shared Function ListaDocumentiLiquido(Optional Ambiente As TipoAmbiente = TipoAmbiente.PROD) As EsitoChiamata
    '    'RESTITUISCE LA LISTA DEI DOCUMENTI CHE SI POSSONO INVIARE A LIQUIDO

    '    Dim Esito As New EsitoChiamata

    '    Try
    '        Dim Aggiorna As Boolean = False
    '        Dim DocXml As String = Path.Combine(Utx.Globale.Paths.CartellaModelli, "DocUp.dat")

    '        If File.Exists(DocXml) Then
    '            'aggiorno il file dal servizio una volta a settimana
    '            Aggiorna = DateDiff(DateInterval.Day, New FileInfo(DocXml).LastWriteTime.Date, Today) >= 7
    '        Else
    '            Aggiorna = True
    '        End If

    '        If Aggiorna = True Then
    '            Utx.Globale.Log.Info("aggiorno la lista dei documenti di Liquido dai servizi di direzione")

    '            Net.ServicePointManager.SecurityProtocol = 3072 'TLS 1.2

    '            Using s As New JBUploaderUnitools.UploaderUnitools
    '                s.Url = UrlListaDocumentiLiquido(Ambiente)
    '                s.Timeout = 20000
    '                s.RequestSoapContext.Security.Tokens.Add(UserToken)

    '                'leggo e serializzo la lista
    '                Dim Lista As String() = s.docINList 'metodo in wsdl UploaderUnitools

    '                Dim serialiser = New System.Xml.Serialization.XmlSerializer(Lista.GetType())

    '                Using writer As New IO.StringWriter()
    '                    serialiser.Serialize(writer, Lista)
    '                    File.WriteAllText(DocXml, writer.ToString())
    '                End Using
    '            End Using
    '        End If

    '        Esito.Documento = File.ReadAllBytes(DocXml)
    '        Esito.Esito = True

    '    Catch ex As Exception
    '        Esito.Esito = False
    '        Esito.Errore = ex.Message
    '    End Try

    '    Return Esito
    'End Function

    'Public Shared Function ListaDocumentiSinistro(IdSinistro As String,
    '                                              Optional Ambiente As TipoAmbiente = TipoAmbiente.PROD) As EsitoChiamata

    '    Dim Esito As New EsitoChiamata

    '    Try
    '        Using s As New JBDocumentiAgenzia.DocumentiAgenziaAPI
    '            'internet
    '            s.Url = UrlListaDocumentiSinistro(Ambiente)
    '            s.Timeout = 20000
    '            s.RequestSoapContext.Security.Tokens.Add(UserToken)

    '            Esito.ListaDocumenti = s.getDocumentoInfoList(IdSinistro, Utx.Globale.AgenziaRichiesta.CodiceAgenzia) 'metodo in wsdl DocumentiAgenzia
    '        End Using

    '        Esito.Esito = True

    '    Catch ex As Exception
    '        Esito.Esito = False
    '        Esito.Errore = ex.Message
    '    End Try

    '    Return Esito
    'End Function

    'Public Shared Function ScaricaDocumentoSinistro(IdDocumento As String,
    '                                                Optional Ambiente As TipoAmbiente = TipoAmbiente.PROD) As EsitoChiamata

    '    Dim Esito As New EsitoChiamata

    '    Try
    '        Using s As New JBUploaderUnitools.UploaderUnitools
    '            s.Url = UrlScaricaDocumentoSinistro(Ambiente)
    '            s.Timeout = 20000
    '            s.RequestSoapContext.Security.Tokens.Add(UserToken)

    '            Esito.Documento = s.uniDownloadFromLiquido(IdDocumento) 'il metodo si trova nel wsdl UploaderUnitools
    '        End Using

    '        Esito.Esito = True

    '    Catch ex As Exception
    '        Esito.Esito = False
    '        Esito.Errore = ex.Message
    '    End Try

    '    Return Esito
    'End Function

    'Public Shared Function LeggiPosizioniSinistro(IdSinistro As String,
    '                                              Optional Ambiente As TipoAmbiente = TipoAmbiente.PROD) As EsitoChiamata

    '    Dim Esito As New EsitoChiamata

    '    Try
    '        'creo lo usertoken per la chiamata
    '        Using s As New JBSinistriAgenzia.SinistriAgenziaAPI
    '            s.Url = UrlLeggiPosizioniSinistro(Ambiente)
    '            s.Timeout = 20000
    '            s.RequestSoapContext.Security.Tokens.Add(UserToken)

    '            'leggo le posizioni
    '            Esito.Posizioni = s.getSinistroDettaglio(IdSinistro) 'il metodo si trova nel wsdl SinistriAgenziaAPI
    '            '(un metodo con lo stesso nome ma con funzionamento diverso si trova anche in sinistriserviceforagenzie)
    '        End Using

    '        Esito.Esito = True

    '    Catch ex As Exception
    '        Esito.Esito = False
    '        Esito.Errore = ex.Message
    '    End Try

    '    Return Esito
    'End Function

    'Public Shared Function InviaDocumento(Documento As Utx.ServiziSinistri.DocumentoLiquido,
    '                                      Optional Ambiente As TipoAmbiente = TipoAmbiente.PROD) As EsitoChiamata

    '    Dim Esito As New EsitoChiamata

    '    Try
    '        Using s As New JBUploaderUnitools.UploaderUnitools
    '            s.Url = UrlInviaDocumento(Ambiente)
    '            s.Timeout = 20000
    '            s.RequestSoapContext.Security.Tokens.Add(UserToken)

    '            Dim Risposta As JBUploaderUnitools.UploaderUnitoolsBean
    '            Risposta = s.uniUploadToLiquido(Documento.IdSinistro,
    '                                            Documento.CodiceDocumento,
    '                                            Documento.EstensioneFile,
    '                                            Documento.NomeDocumento,
    '                                            Documento.Mittente,
    '                                            Documento.DataArrivoDocumento,
    '                                            Documento.DateDocSpecified,
    '                                            Documento.Documento,
    '                                            Documento.Posizione,
    '                                            Documento.Note)

    '            Esito.Esito = (Risposta.esito = "OK")
    '            Esito.Errore = Risposta.errorDescription
    '        End Using

    '    Catch ex As Exception
    '        Esito.Esito = False
    '        Esito.Errore = ex.Message
    '    End Try

    '    Return Esito
    'End Function

    'Private Shared Function UserToken() As UsernameToken
    '    Return New UsernameToken(Utx.Globale.UtenteCorrente.UniageUser, Utx.Globale.UtenteCorrente.UniagePw, PasswordOption.SendPlainText)
    'End Function

    'Public Class EsitoChiamata
    '    Public Esito As Boolean
    '    Public Errore As String = ""
    '    Public ListaDocumenti As JBDocumentiAgenzia.DocumentiAgenziaResult
    '    Public Posizioni As JBSinistriAgenzia.SinistriAgenziaResult
    '    Public ListaInfoSinistri As List(Of JBImportaSinistri.DettaglioSinistro)
    '    Public Documento As Byte()
    'End Class

    'Public Class DocumentoLiquido
    '    Public IdSinistro As String
    '    Public CodiceDocumento As String
    '    Public EstensioneFile As String
    '    Public NomeDocumento As String
    '    Public Mittente As String
    '    Public DataArrivoDocumento As String
    '    Public DateDocSpecified As Boolean
    '    Public Documento As Byte()
    '    Public Posizione As String()
    '    Public Note As String
    'End Class
End Class
