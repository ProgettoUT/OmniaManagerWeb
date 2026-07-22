Imports mshtml
Imports System.Windows.Forms

Public Class RicercaSinistro

#Region "Tag pagina ricerca"
    'id che identificano i campi in liquido (sezione ricerca semplice)
    Public Const IdRicercaSemplice As String = "TabBar:SearchTab"
    Public Const IdBottoneCerca As String = "SimpleClaimSearch:SimpleClaimSearchScreen:SimpleClaimSearchDV:ClaimSearchAndResetInputSet:Search_link"
    Public Const IdBottoneCercaAvanzata As String = "ClaimSearch:ClaimSearchScreen:ClaimSearchDV:ClaimSearchAndResetInputSet:Search_link"
    Public Const IdBottoneResetta As String = "SimpleClaimSearch:SimpleClaimSearchScreen:SimpleClaimSearchDV:ClaimSearchAndResetInputSet:Reset_link"
    Public Const IdComboCompagnia As String = "SimpleClaimSearch:SimpleClaimSearchScreen:SimpleClaimSearchDV:ClaimSearchCriteriaInputSet:claimDivisione"
    Public Const IdComboCompagniaPolizza As String = "SimpleClaimSearch:SimpleClaimSearchScreen:SimpleClaimSearchDV:ClaimSearchCriteriaInputSet:polDivisione"
    Public Const IdAgenzia As String = "SimpleClaimSearch:SimpleClaimSearchScreen:SimpleClaimSearchDV:ClaimSearchCriteriaInputSet:agenziaNum"
    Public Const IdRamo As String = "SimpleClaimSearch:SimpleClaimSearchScreen:SimpleClaimSearchDV:ClaimSearchCriteriaInputSet:ramoPolizza"
    Public Const IdPolizza As String = "SimpleClaimSearch:SimpleClaimSearchScreen:SimpleClaimSearchDV:ClaimSearchCriteriaInputSet:numeroPolizza"
    Public Const IdTarga As String = "SimpleClaimSearch:SimpleClaimSearchScreen:SimpleClaimSearchDV:LicensePlate"
    Public Const IdEvento As String = "SimpleClaimSearch:SimpleClaimSearchScreen:SimpleClaimSearchDV:ClaimSearchCriteriaInputSet:EventNumber"
    Public Const IdSinistro As String = "SimpleClaimSearch:SimpleClaimSearchScreen:SimpleClaimSearchDV:ClaimSearchCriteriaInputSet:complSinistroNum"
    Public Const IdCF As String = "ClaimSearch:ClaimSearchScreen:ClaimSearchDV:ClaimSearchRequiredInputSet:CodiceFiscale"
    Public Const IdPiva As String = "ClaimSearch:ClaimSearchScreen:ClaimSearchDV:ClaimSearchRequiredInputSet:PartitaIVA"
    Public Const IdCognome As String = "SimpleClaimSearch:SimpleClaimSearchScreen:SimpleClaimSearchDV:Ext_NameSearchInputSet:LastName"
    Public Const IdNome As String = "SimpleClaimSearch:SimpleClaimSearchScreen:SimpleClaimSearchDV:Ext_NameSearchInputSet:FirstName"
    Public Const IdRagioneSociale As String = "SimpleClaimSearch:SimpleClaimSearchScreen:SimpleClaimSearchDV:Ext_NameSearchInputSet:CompanyName"
    'costanti che identificano gli Id dei campi della pagina di ricerca
    Public Const UrlRicercaSertel As String = "https://essig.unipolsai.it/websinistri/Ricerche.aspx"
    Const TipoArchivio As String = "ctl00_Main_slTipoArchivio"
    Const CheckNumero As String = "ctl00_Main_rdNumeroSinistro"
    Const CheckCartella As String = "ctl00_Main_rdNumeroCartella"
    Const CheckAnag As String = "ctl00_Main_rdDatiAnagrafici"
    Const CheckPolizza As String = "ctl00_Main_rdNumeroPolizza"
    Const CheckTarga As String = "ctl00_Main_rdTarga"
    Const TipoTarga As String = "ctl00_Main_slTipoTarga"
    Const CheckCf As String = "ctl00_Main_rdcodfis"
    Const TipoAnag As String = "ctl00_Main_slTipoAna"
    Const CheckPiva As String = "ctl00_Main_rdpiva"
    Const Compagnia As String = "ctl00$Main$slCompagnia1"
    Const Ente As String = "ctl00_Main_txEnte"
    Const Esercizio As String = "ctl00_Main_txAnnoSx"
    Const NumeroSinistro As String = "ctl00_Main_txNumSinistro"
    Const Targa As String = "ctl00_Main_txTarga"
    Const Cartella As String = "ctl00_Main_txNumCartella"
    Const Anag As String = "ctl00_Main_txCognome"
    Const Cf As String = "ctl00_Main_txcodfispiva"
    Const Agenzia As String = "ctl00_Main_txAgenzia"
    Const Ramo As String = "ctl00_Main_txRamoPolizza"
    Const Polizza As String = "ctl00_Main_txNumPolizza"
    Const BtnRicerca As String = "ctl00_btnRicerca"
#End Region

    Private mSinistroCorrente As Sinistro

    Sub New(SinistroCorrente As Sinistro)
        mSinistroCorrente = SinistroCorrente
    End Sub

    'Public Function NormalizzaEvento() As String
    '    If InStr(1, mEvento, "/", vbTextCompare) = 0 Then
    '        mEvento = mEsercizioSinistro + "/" + mEvento
    '    End If
    'End Function

    Public Function NavigaRicercaSemplice(ByRef d As IHTMLDocument3) As Boolean
        On Error Resume Next

        NavigaRicercaSemplice = Not (d.getElementById(IdSinistro) Is Nothing)

        'se la pagina non è ancora visualizzata la naviga
        If NavigaRicercaSemplice = False Then
            Dim Link As IHTMLElement3
            Link = d.getElementById(IdRicercaSemplice)
            Link.FireEvent("onClick")

            'avvio un timeout per sicurezza
            Dim Avvio As Date
            Avvio = Now

            Do While NavigaRicercaSemplice = False
                NavigaRicercaSemplice = Not (d.getElementById(IdSinistro) Is Nothing)
                Application.DoEvents()

                If DateDiff("s", Avvio, Now) > 30 Then
                    Exit Do
                End If
            Loop
        End If
    End Function

    Public Function NavigaRicercaAvanzata(ByRef d As IHTMLDocument3)
        NavigaRicercaAvanzata = Not (d.getElementById(IdCF) Is Nothing)

        'se la pagina non è ancora visualizzata la naviga
        If NavigaRicercaAvanzata = False Then
            Dim Par(1) As String
            Par(0) = "TabBar:SearchTab:Search_ClaimSearchesGroup:ClaimSearchesGroup_ClaimSearch_act"
            Par(1) = "true"

            Utx.FunzioniHtml.InvocaJavaScript(d, Par)

            'avvio un timeout per sicurezza
            Dim Avvio As Date
            Avvio = Now

            Do While NavigaRicercaAvanzata = False
                NavigaRicercaAvanzata = Not (d.getElementById(IdCF) Is Nothing)
                Application.DoEvents()

                If DateDiff("s", Avvio, Now) > 30 Then
                    Exit Do
                End If
            Loop
        End If
    End Function

    Public Sub PerNumeroSinistro(ByRef d As IHTMLDocument3)
        On Error Resume Next

        'se la pagina di ricerca è già visualizzata
        If NavigaRicercaSemplice(d) = True Then

            PulisciCampi(d)

            d.getElementById(IdComboCompagnia).setAttribute("value", mSinistroCorrente.Compagnia)
            d.getElementById(IdSinistro).setAttribute("value", mSinistroCorrente.IdSinistro)
            d.getElementById(IdBottoneCerca).click()
        End If
    End Sub

    Public Sub PerNumeroSinistroSertel(ByRef d As IHTMLDocument3)
        On Error Resume Next

        PulisciCampiSertel(d)

        'ricerca poer numero
        d.getElementById(CheckNumero).click()
        'imposto il tipo di archivio per la ricerca
        d.getElementById(TipoArchivio).item(0).setAttribute("value", "MSP")
        'imposto il numero di sinistro
        'il combo funziona solo con il byname
        d.getElementsByName(Compagnia).item(0).setAttribute("value", mSinistroCorrente.Compagnia)
        d.getElementById(Ente).setAttribute("value", mSinistroCorrente.Agenzia)
        d.getElementById(Esercizio).setAttribute("value", mSinistroCorrente.Esercizio)
        d.getElementById(NumeroSinistro).setAttribute("value", mSinistroCorrente.Numero)
        'e premo il bottone
        d.getElementById(BtnRicerca).click()
    End Sub

    Public Sub PerNumeroPolizza(ByRef d As IHTMLDocument3)
        On Error Resume Next

        'se la pagina di ricerca è già visualizzata
        If NavigaRicercaSemplice(d) = True Then

            PulisciCampi(d)

            d.getElementById(IdAgenzia).setAttribute("value", mSinistroCorrente.Agenzia)
            d.getElementById(IdRamo).setAttribute("value", mSinistroCorrente.RamoSinistro)
            d.getElementById(IdPolizza).setAttribute("value", mSinistroCorrente.Polizza)
            d.getElementById(IdBottoneCerca).click()
        End If
    End Sub

    Public Sub PerTarga(ByRef d As IHTMLDocument3)
        On Error Resume Next

        'se la pagina di ricerca è già visualizzata
        If NavigaRicercaSemplice(d) = True Then

            PulisciCampi(d)

            d.getElementById(IdTarga).setAttribute("value", mSinistroCorrente.TargaAssicurato)
            d.getElementById(IdBottoneCerca).click()
        End If
    End Sub

    Public Sub PerCF(ByRef d As IHTMLDocument3)
        On Error Resume Next

        'se la pagina di ricerca è già visualizzata
        If NavigaRicercaAvanzata(d) = True Then

            PulisciCampi(d)

            If IsNumeric(mSinistroCorrente.CfAssicurato) Then
                d.getElementById(IdCF).setAttribute("value", "")
                d.getElementById(IdPiva).setAttribute("value", mSinistroCorrente.CfAssicurato)
            Else
                d.getElementById(IdCF).setAttribute("value", mSinistroCorrente.CfAssicurato)
                d.getElementById(IdPiva).setAttribute("value", "")
            End If

            d.getElementById(IdBottoneCercaAvanzata).click()
        End If
    End Sub

    'Public Sub PerEvento(ByRef d As IHTMLDocument3)
    '    On Error Resume Next

    '    'se la pagina di ricerca è già visualizzata
    '    If NavigaRicercaSemplice(d) = True Then

    '        PulisciCampi(d)

    '        d.getElementById(IdEvento).setAttribute("value", NormalizzaEvento)
    '        d.getElementById(IdBottoneCerca).click()
    '    End If
    'End Sub

    Public Sub PulisciCampi(ByRef d As IHTMLDocument3)
        'il bottone reset produce uno strano effeto di blocco: non usare
        On Error Resume Next

        d.getElementById(IdSinistro).setAttribute("value", "")
        d.getElementById(IdAgenzia).setAttribute("value", "")
        d.getElementById(IdRamo).setAttribute("value", "")
        d.getElementById(IdPolizza).setAttribute("value", "")
        d.getElementById(IdTarga).setAttribute("value", "")
        d.getElementById(IdEvento).setAttribute("value", "")
        d.getElementById(IdCognome).setAttribute("value", "")
        d.getElementById(IdNome).setAttribute("value", "")
        d.getElementById(IdRagioneSociale).setAttribute("value", "")
    End Sub

    Public Sub PulisciCampiSertel(ByRef d As IHTMLDocument3)
        'il bottone reset produce uno strano effeto di blocco: non usare
        On Error Resume Next
        d.getElementById(TipoArchivio).setAttribute("value", "")
        d.getElementById(CheckNumero).setAttribute("value", "")
        d.getElementById(CheckCartella).setAttribute("value", "")
        d.getElementById(CheckAnag).setAttribute("value", "")
        d.getElementById(CheckPolizza).setAttribute("value", "")
        d.getElementById(CheckTarga).setAttribute("value", "")
        d.getElementById(TipoTarga).setAttribute("value", "")
        d.getElementById(CheckCf).setAttribute("value", "")
        d.getElementById(TipoAnag).setAttribute("value", "")
        d.getElementById(CheckPiva).setAttribute("value", "")
        d.getElementById(Compagnia).setAttribute("value", "")
        d.getElementById(Ente).setAttribute("value", "")
        d.getElementById(Esercizio).setAttribute("value", "")
        d.getElementById(NumeroSinistro).setAttribute("value", "")
        d.getElementById(Targa).setAttribute("value", "")
        d.getElementById(Cartella).setAttribute("value", "")
        d.getElementById(Anag).setAttribute("value", "")
        d.getElementById(Cf).setAttribute("value", "")
        d.getElementById(Agenzia).setAttribute("value", "")
        d.getElementById(Ramo).setAttribute("value", "")
        d.getElementById(Polizza).setAttribute("value", "")
        d.getElementById(BtnRicerca).setAttribute("value", "")
    End Sub
End Class
