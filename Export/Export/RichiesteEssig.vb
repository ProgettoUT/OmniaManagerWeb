Imports System.Net
Imports System.IO

Public Class RichiesteEssig

    Public Enum TipoCompagnia
        UNIPOL = 1
        UNISALUTE = 4
    End Enum

    Public Enum TipoRichiesta
        ESITATI = 0
        ARRETRATI = 1
        LISTE = 2
        BDA = 3
        PRIMA_NOTA = 4
        VARIAZIONI = 5
        GIORNALECASSA = 6
        CHIUSURA_CASSA = 7
        MENU = 8
    End Enum

    Structure LinkEssig
        'Dim Login As String
        Dim Menu As String
        Dim Menu2 As String
        Dim Richiesta As String
        Dim Esporta As String
    End Structure

    Public Enum TipoRichiestaEsitati
        NORMALE
        RIDOTTA
    End Enum

    Public Event Stato(e As ExportEventArgs)
    Private WithEvents e As New ExportEventArgs

    Friend Shared TipoEsitati As TipoRichiestaEsitati

    Private mRichiesta As TipoRichiesta
    Private mLink As LinkEssig
    Private Shared mCookie As CookieContainer
    Private Shared UrlBase As String

    Sub New(TipoRichiesta As TipoRichiesta, Optional CodiceCompagnia As TipoCompagnia = TipoCompagnia.UNIPOL)
        mRichiesta = TipoRichiesta
        Compagnia = CodiceCompagnia
    End Sub

    Private _Compagnia As TipoCompagnia
    Public Property Compagnia() As TipoCompagnia
        Get
            Return _Compagnia
        End Get
        Set(ByVal value As TipoCompagnia)
            _Compagnia = value
            _CompagniaCorrente = _Compagnia
            'imposto i cookies
            If _Compagnia = TipoCompagnia.UNIPOL Then
                UrlBase = "https://essig.unipolsai.it"
                mCookie = Utx.Globale.LoginUniage.CookieContainer
            Else
                UrlBase = "https://essig.unisalute.it"
                mCookie = Utx.Globale.LoginUS.CookieContainer
            End If
            CreaLink()
        End Set
    End Property

    Private Shared _CompagniaCorrente As TipoCompagnia
    Public Shared ReadOnly Property CompagniaCorrente() As TipoCompagnia
        Get
            Return _CompagniaCorrente
        End Get
    End Property

    Public Sub CreaLink()
        Select Case mRichiesta
            Case RichiesteEssig.TipoRichiesta.MENU
                mLink = RichiestaMenu()
            Case RichiesteEssig.TipoRichiesta.ESITATI
                If RichiesteEssig.TipoEsitati = TipoRichiestaEsitati.NORMALE Then
                    mLink = RichiestaEsitati()
                Else 'ridotta
                    mLink = RichiestaEsitatiRidotta()
                End If
            Case RichiesteEssig.TipoRichiesta.VARIAZIONI
                mLink = RichiestaVariazioni()
            Case RichiesteEssig.TipoRichiesta.ARRETRATI
                mLink = RichiestaArretrati()
            Case RichiesteEssig.TipoRichiesta.LISTE
                mLink = RichiestaLista()
            Case RichiesteEssig.TipoRichiesta.BDA
                mLink = RichiestaBDA()
            Case RichiesteEssig.TipoRichiesta.PRIMA_NOTA
                mLink = RichiestaPrimaNota()
            Case RichiesteEssig.TipoRichiesta.GIORNALECASSA
                mLink = RichiestaGiornaleCassa()
            Case RichiesteEssig.TipoRichiesta.CHIUSURA_CASSA
                mLink = RichiestaChiusuraCassa()
        End Select
    End Sub

    Public Sub SwitchRichiestaEsitati(Tipo As TipoRichiestaEsitati)
        If Tipo = TipoRichiestaEsitati.NORMALE Then
            mLink = RichiestaEsitati()
            TipoEsitati = TipoRichiestaEsitati.NORMALE
            Globale.Log.Info("Switch richiesta normale IT-CO-SC-IC-IS")
        Else
            mLink = RichiestaEsitatiRidotta()
            TipoEsitati = TipoRichiestaEsitati.RIDOTTA
            Globale.Log.Info("Switch richiesta ridotta IT-CO-SC")
        End If
    End Sub

    Public Property EventArgs() As ExportEventArgs
        Get
            Return e
        End Get
        Set(value As ExportEventArgs)
            e = value
        End Set
    End Property

    Friend Sub ChiamaMenu()
        If mCookie IsNot Nothing Then
            CallWeb(mLink.Menu)
        End If
    End Sub

    Friend Sub ChiamaMenu2()
        CallWeb(mLink.Menu2)
    End Sub

    Friend Sub RichiestaDati(Agenzia As String,
                             CodiceSub As String,
                             Inizio As Date,
                             Fine As Date,
                             Optional RID As String = "+")

        CallWeb(String.Format(mLink.Richiesta,
                              Agenzia,
                              CodiceSub,
                              Format(Inizio, "dd/MM/yyyy"),
                              Format(Fine, "dd/MM/yyyy"),
                              RID))
    End Sub

    Friend Sub RichiestaDati(Agenzia As String,
                             Giorno As Date)

        CallWeb(String.Format(mLink.Richiesta,
                              Agenzia,
                              Format(Giorno, "dd/MM/yyyy")))
    End Sub

    Friend Sub RichiestaDati(Inizio As Date,
                             Fine As Date)

        CallWeb(String.Format(mLink.Richiesta, Format(Inizio, "dd/MM/yyyy"), Format(Fine, "dd/MM/yyyy")))
    End Sub

    Friend Sub RichiestaDati(TipoLista As String,
                             Agenzia As String)

        CallWeb(String.Format(mLink.Richiesta, TipoLista, Agenzia))
    End Sub

    Friend Function RichiestaDati(TipoTarga As String,
                                  Targa As String,
                                  TipoVeicolo As String) As String

        Return CallWeb(String.Format(mLink.Richiesta, TipoTarga, Targa, TipoVeicolo))
    End Function

    Friend Function EsportaDati() As String
        Return CallWeb(mLink.Esporta)
    End Function

    Private Function CallWeb(Url As String) As String
        Try
            ServicePointManager.SecurityProtocol = 3072 'fondamentale nei casi in cui i protocolli TSL non vanno in automatico

            Dim request As HttpWebRequest = HttpWebRequest.Create(Url)
            request.AllowAutoRedirect = False
            request.CookieContainer = mCookie
            request.Timeout = 100000 'per risolvere l'errore 504 gateway timeout

            ' Get the response.
            Dim response As HttpWebResponse = request.GetResponse()
            mCookie.Add(response.Cookies)

            If response.StatusCode = HttpStatusCode.Found Then

                Dim newUrl = response.Headers("Location")
                If newUrl.StartsWith("/") Then
                    Dim a = New Uri(Url)
                    newUrl = a.AbsoluteUri.Substring(0, a.AbsoluteUri.LastIndexOf(a.AbsolutePath)) & newUrl
                End If
                response.Close()

                Return CallWeb(newUrl)
            End If


            ' Get the stream containing content returned by the server.
            Dim resStream As Stream = response.GetResponseStream()

            ' Open the stream using a StreamReader for easy access.
            Dim reader As New StreamReader(resStream)

            ' Read the content.
            CallWeb = reader.ReadToEnd()

#If DEBUG Then
            'Dim sw As New StreamWriter(String.Format("C:\Users\Guido\Desktop\{0}.htm", Format(Now, "HHmmss")))
            'sw.Write(CallWeb)
            'sw.Close()
#End If
            If InStr(CallWeb, "CICS 104", CompareMethod.Text) > 0 Then
                e.Messaggio = "Terminale non abilitato all'operazione"
                e.CodiceErrore = 1001
                e.Errore = True
            ElseIf (InStr(CallWeb, "Segnalazione CICS 216", CompareMethod.Text) > 0) OrElse
                   (InStr(CallWeb, "Segnalazione CICS 567", CompareMethod.Text) > 0) Then
                e.Messaggio = "Segnalazione CICS"
                e.CodiceErrore = 1002
                e.Errore = True
            ElseIf InStr(CallWeb, "Errore non previsto", CompareMethod.Text) > 0 Then
                e.Messaggio = "Errore non previsto"
                e.CodiceErrore = 1003
                e.Errore = True
            End If

            reader.Close()
            resStream.Close()
            response.Close()
        Catch ex As Exception
            Globale.Log.Errore(ex)
            e.Messaggio = ex.Message
            e.Errore = True
            Return ""
        End Try
    End Function

#Region "Link essig"
    Friend Shared Function RichiestaMenu() As LinkEssig
        Return New LinkEssig With {.Menu = UrlBase + "/essigCP/start.do"}
    End Function

    Friend Shared Function RichiestaEsitati() As LinkEssig
        Dim DatiRichiesta = "method=Conferma" +
                            "&funzione.value=8" +
                            "&agenzia.value={0}" +
                            "&subagente.value={1}" +
                            "&dataRegistrazioneDa.value={2}" +
                            "&dataRegistrazioneA.value={3}" +
                            "&codiceEsito1.value=IT" +
                            "&codiceEsito2.value=CO" +
                            "&codiceEsito3.value=SC" +
                            "&codiceEsito4.value=IC" +
                            "&codiceEsito5.value=IS"

        Return New LinkEssig With {.Menu = UrlBase + "/essigCP/start.do?itemId=0401040000&parametri=CP++STGI",
            .Richiesta = UrlBase + "/essigCP/danni/contabpremi/paginaGC00.do?" + DatiRichiesta,
            .Esporta = UrlBase + "/essigCP/danni/contabpremi/exportCsvGC12.do?method=exportCsv"}
    End Function

    Friend Shared Function RichiestaEsitatiRidotta() As LinkEssig
        Dim DatiRichiesta = "method=Conferma" +
                            "&funzione.value=8" +
                            "&agenzia.value={0}" +
                            "&subagente.value={1}" +
                            "&dataRegistrazioneDa.value={2}" +
                            "&dataRegistrazioneA.value={3}" +
                            "&codiceEsito1.value=IT" +
                            "&codiceEsito2.value=CO" +
                            "&codiceEsito3.value=SC"

        Return New LinkEssig With {.Menu = UrlBase + "/essigCP/start.do?itemId=0401040000&parametri=CP++STGI",
            .Richiesta = UrlBase + "/essigCP/danni/contabpremi/paginaGC00.do?" + DatiRichiesta,
            .Esporta = UrlBase + "/essigCP/danni/contabpremi/exportCsvGC12.do?method=exportCsv"}
    End Function

    Friend Shared Function RichiestaChiusuraCassa() As LinkEssig
        Dim DatiRichiesta = "method=Conferma" +
                            "&funzione.value=8" +
                            "&agenzia.value={0}" +
                            "&subagente.value={1}" +
                            "&dataRegistrazioneDa.value={2}" +
                            "&dataRegistrazioneA.value={3}" +
                            "&codiceEsito1.value=IT" +
                            "&codiceEsito2.value=CO" +
                            "&codiceEsito3.value=SC" +
                            "&codiceEsito4.value=IC" +
                            "&codiceEsito5.value=IS"

        Return New LinkEssig With {.Menu = UrlBase + "/essigCP/start.do?itemId=0401040000&parametri=CP++STGI",
            .Richiesta = UrlBase + "/essigCP/danni/contabpremi/paginaGC00.do?" + DatiRichiesta,
            .Esporta = UrlBase + "/essigCP/danni/contabpremi/exportCsvGC12.do?method=exportCsv"}
    End Function

    Friend Shared Function RichiestaGiornaleCassa() As LinkEssig
        Dim DatiRichiesta = "method=Conferma" +
                            "&funzione.value=2" +
                            "&agenzia.value={0}" +
                            "&dataRegistrazioneDa.value={1}" +
                            "&dataRegistrazioneA.value={1}"

        Return New LinkEssig With {.Menu = UrlBase + "/essigCP/start.do?itemId=0401040000&parametri=CP++STGI",
            .Richiesta = UrlBase + "/essigCP/danni/contabpremi/paginaGC00.do?" + DatiRichiesta,
            .Esporta = UrlBase + "/essigCP/danni/contabpremi/exportCsvGC12.do?method=exportCsv"}
    End Function

    Friend Shared Function RichiestaVariazioni() As LinkEssig
        Dim DatiRichiesta = "method=Conferma" +
                            "&funzione.value=8" +
                            "&agenzia.value={0}" +
                            "&subagente.value={1}" +
                            "&dataRegistrazioneDa.value={2}" +
                            "&dataRegistrazioneA.value={3}" +
                            "&codiceEsito1.value=SS" +
                            "&codiceEsito2.value=VR"

        Return New LinkEssig With {.Menu = UrlBase + "/essigCP/start.do?itemId=0401040000&parametri=CP++STGI",
            .Richiesta = UrlBase + "/essigCP/danni/contabpremi/paginaGC00.do?" + DatiRichiesta,
            .Esporta = UrlBase + "/essigCP/danni/contabpremi/exportCsvGC12.do?method=exportCsv"}
    End Function

    Friend Shared Function RichiestaArretrati() As LinkEssig
        Dim DatiRichiesta = "method=Conferma" +
                            "&funzione.value=6" +
                            "&agenzia.value={0}" +
                            "&subagente.value={1}" +
                            "&dataRegistrazioneDa.value={2}" +
                            "&dataRegistrazioneA.value={3}" +
                            "&rid.value={4}"

        Return New LinkEssig With {.Menu = UrlBase + "/essigCP/start.do?itemId=0401040000&parametri=CP++STGI",
            .Richiesta = UrlBase + "/essigCP/danni/contabpremi/paginaGC00.do?" + DatiRichiesta,
            .Esporta = UrlBase + "/essigCP/danni/contabpremi/exportCsvGC12.do?method=exportCsv"}
    End Function

    Friend Shared Function RichiestaPrimaNota() As LinkEssig

        Dim Link As New LinkEssig

        Dim DatiRichiesta = "funzione=5" +
                            "&compagnia=1" +
                            "&flagIR.value=T" +
                            "&dataRegistrazioneDa.value={0}" +
                            "&dataRegistrazioneA.value={1}" +
                            "&method=Elabora"

        With Link
            .Menu = UrlBase + "/essigCP/start.do?itemId=0401080000&parametri=CP++PNAG"
            .Menu2 = UrlBase + "/essigCP/danni/contabpremi/paginaIC01.do?paginaRitornoStampa=&funzione.value=5&agenzia.value=2379&method=Elabora"
            .Richiesta = UrlBase + "/essigCP/danni/contabpremi/paginaIC07.do?" + DatiRichiesta
            .Esporta = UrlBase + "/essigCP/danni/contabpremi/exportCsvIC04.do?method=exportCsv"
        End With
        Return Link
    End Function

    Friend Shared Function RichiestaBDA() As LinkEssig
        Dim DatiRichiesta = "nomePaginaAlbero=" +
                            "&flagDatiCambiati=+" +
                            "&formTarga.value={0}" +
                            "&posizioneAssicurativa.value={1}" +
                            "&tpVeicolo.value={2}" +
                            "&ACTIONBUTTON001=Avanti"

        Return New LinkEssig With {.Menu = UrlBase + "/Danni/essigRA/start.do?itemId=0614000000&parametri=RA++CBDA",
            .Richiesta = UrlBase + "/Danni/essigRA/danni/rcauto/paginaD0.do?" + DatiRichiesta,
            .Esporta = ""}
    End Function

    Friend Function RichiestaLista() As LinkEssig
        Dim DatiRichiesta = "method=Avanti&listaScelta={0}&agenzia.value={1}"

        Return New LinkEssig With {.Menu = UrlBase + "/essigGRFE/start.do?itemId=0603000000&parametri=GR++LIST",
            .Richiesta = UrlBase + "/essigGRFE/danni/gestionerete/pagina17.do?" + DatiRichiesta,
            .Esporta = UrlBase + "/essigGRFE/danni/gestionerete/exportExcel.do?method=exporta"}
    End Function
#End Region

    Private Sub e_CambiaStato() Handles e.CambiaStato
        RaiseEvent Stato(e)
    End Sub
End Class
