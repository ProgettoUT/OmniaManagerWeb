Imports System.IO
Imports System.Text
Imports System.Net
Imports System.Data

Public Class Export

    Structure LinkEssig
        Dim Login As String
        Dim Menu As String
        Dim Richiesta As String
        Dim Esporta As String
    End Structure

    Public Event StatoImportazione(e As ExportEventArgs)
    Public Event AnnullamentoInCorso(Messaggio As String)

#Region "new"
    Sub New()
        mAgenzia = Utx.Globale.AgenziaRichiesta.CodiceAgenzia
    End Sub

    Sub New(Agenzia As String)
        mAgenzia = Agenzia.PadLeft(5, "0")
    End Sub

    Sub New(Agenzia As String, CookieAutenticazione As CookieContainer)
        mAgenzia = Agenzia.PadLeft(5, "0")
    End Sub
#End Region

#Region "proprietà"
    Private mAgenzia As String
    Public Property Agenzia() As String
        Get
            Return mAgenzia
        End Get
        Set(value As String)
            mAgenzia = value
        End Set
    End Property
#End Region

    Public Sub AggiornaFile(ScaricareDal As Date,
                            ScaricatiPrimaDel As Date,
                            ByRef OpzioniScarico As ExportLib.ConfigScaricoIncassi)
        'per automatismo da programma
        Dim i As New Incassi With {.OpzioniScarico = OpzioniScarico}
        AddHandler i.StatoImportazione, AddressOf CambiaStatoImportazione
        'avvia lo scarico file
        i.AggiornaFile(ScaricareDal, ScaricatiPrimaDel)
    End Sub

    Public Sub AggiornaFile(InizioPeriodo As Date,
                            ByRef OpzioniScarico As ExportLib.ConfigScaricoIncassi)
        'per richiesta manuale rilettura incassi
        Dim i As New Incassi With {.OpzioniScarico = OpzioniScarico}
        AddHandler i.StatoImportazione, AddressOf CambiaStatoImportazione
        'avvia lo scarico file
        i.AggiornaFile(InizioPeriodo)
    End Sub

    Public Sub AggiornaIncassi(ByRef OpzioniScarico As ExportLib.ConfigScaricoIncassi)
        Dim i As New Incassi With {.OpzioniScarico = OpzioniScarico}
        AddHandler i.StatoImportazione, AddressOf CambiaStatoImportazione
        'avvia lo scarico dati
        i.AggiornaIncassi(mAnnulla)
    End Sub

    Public Sub AggiornaVariazioni(ByRef OpzioniScarico As ExportLib.ConfigScaricoIncassi)
        Dim v As New Variazioni With {.OpzioniScarico = OpzioniScarico}
        AddHandler v.StatoImportazione, AddressOf CambiaStatoImportazione
        'avvia lo scarico dati
        v.AggiornaVariazioni()
    End Sub

    Public Function IncassiGiornalieri(Compagnia As Integer, Giorno As Date, Optional CodiceSub As String = "") As DataTable
        Dim i As New Incassi
        AddHandler i.StatoImportazione, AddressOf CambiaStatoImportazione
        'avvia lo scarico dati
        Return i.IncassiDelGiorno(Compagnia, mAgenzia, Giorno, CodiceSub, mAnnulla)
    End Function

    Public Sub AggiornaCassa(InizioPeriodo As Date,
                             FinePeriodo As Date,
                             Optional CodiciSub As String = "")
        Dim Cassa As New ChiusuraCassa
        AddHandler Cassa.StatoImportazione, AddressOf CambiaStatoImportazione
        'avvia lo scarico dati
        Cassa.CatturaCassa(InizioPeriodo, FinePeriodo, CodiciSub)
    End Sub

    Public Sub AggiornaArretrati(InizioPeriodo As Date, FinePeriodo As Date, CodiceCorrente As Boolean)
        'avvia lo scarico dati
        Dim a As New Arretrati
        AddHandler a.StatoImportazione, AddressOf CambiaStatoImportazione
        a.CatturaArretrati(InizioPeriodo, FinePeriodo, CodiceCorrente)
    End Sub

    Public Sub AggiornaPrimaNota(InizioPeriodo As Date, FinePeriodo As Date)
        'avvia lo scarico dati
        Dim pn As New PrimaNota
        AddHandler pn.StatoImportazione, AddressOf CambiaStatoImportazione
        pn.CatturaPrimaNota(InizioPeriodo, FinePeriodo, mAnnulla)
    End Sub

    Public Function AggiornaListeEssigReti(ByRef OpzioniScarico As ExportLib.ConfigScaricoIncassi) As Boolean

        Dim Liste As New ExportLib.GestioneRete() With {.OpzioniScarico = OpzioniScarico}

        'scarico le liste per ogni codice gestito
        If Liste.AggiornaListe() = False Then
            Return False
        End If

#If Not DEBUG Then
        'invio pacchetto zip a SIA
        For Each Agenzia As String In OpzioniScarico.CodiciDaScaricare.Split("/")
            Globale.Log.Info("invio gestione rete codice {0}", {Agenzia})

            If File.Exists(ExportLib.GestioneRete.PacchettoZip(Agenzia)) Then
                If Utx.Globale.SettingInterop.EsisteChiave(Utx.GestioneFlag.TipoFlag.MIGRAZIONE_INVIO_IN_CORSO) Then
                    'in fase di migrazione invio sempre
                    Utx.SIA.InviaPacchettoEssigReti(ExportLib.GestioneRete.PacchettoZip(Agenzia))
                Else
                    'se è abilitata nel config leggiamo la data di inizio. in caso di NON abilitazione il servizio ritorna 31/12/2100
                    If Utx.SIA.InizioInvioEssigReti(Agenzia) <= Today Then
                        If Utx.SIA.InviaPacchettoEssigReti(ExportLib.GestioneRete.PacchettoZip(Agenzia)) Then
                            Globale.Log.Info("pacchetto essig reti inviato")
                        Else
                            Globale.Log.Info("ERRORE: pacchetto essig reti NON inviato")
                        End If
                    End If
                End If
            End If
        Next
#End If
        'cancello i pacchetti zip temporanei
        For Each f As String In Directory.GetFiles(Utx.Globale.Paths.CartellaTempUtente, "?????_Essig_Reti_??????.zip")
            File.Delete(f)
        Next
        Return True
    End Function

    Public Sub InterrogaBDA(OpzioniBDA As BancaDatiAnia.Opzioni)
        Dim BDA As New ExportLib.BancaDatiAnia With {.OpzioniBDA = OpzioniBDA}
        AddHandler BDA.StatoImportazione, AddressOf CambiaStatoImportazione
        'avvia la lettura del BDA
        BDA.InterrogaBDA(mAnnulla)
    End Sub

    Public Function InterrogaBDATargaSingola(OpzioniBDA As BancaDatiAnia.Opzioni) As BancaDatiAnia.BDATarga
        Dim BDA As New ExportLib.BancaDatiAnia With {.OpzioniBDA = OpzioniBDA}
        AddHandler BDA.StatoImportazione, AddressOf CambiaStatoImportazione
        'avvia la lettura del BDA
        Return BDA.InterrogaTargaSingola(OpzioniBDA.TargaSingola, OpzioniBDA.ClasseRca)
    End Function

    Public Sub AggiornaBDA(OpzioniBDA As BancaDatiAnia.Opzioni)
        Dim BDA As New ExportLib.BancaDatiAnia With {.OpzioniBDA = OpzioniBDA}
        AddHandler BDA.StatoImportazione, AddressOf CambiaStatoImportazione
        'avvia la lettura del BDA
        BDA.AggiornaBDA(mAnnulla)
    End Sub

    Private Sub CambiaStatoImportazione(e As ExportEventArgs)
        RaiseEvent StatoImportazione(e)
    End Sub

    Private mAnnulla As Boolean
    Public Property Annulla() As Boolean
        Get
            Return mAnnulla
        End Get
        Set(value As Boolean)
            mAnnulla = value
            If mAnnulla = True Then RaiseEvent AnnullamentoInCorso("Annullamento in corso...")
        End Set
    End Property
End Class

Public Class ExportEventArgs
    Inherits EventArgs

    Public Event CambiaStato()

    Sub New()
        mAgenziaMadre = ""
        mAgenziaFiglia = ""
        mSubAgenzia = ""
        mNumeroRecord = 0
        mMessaggio = ""
        mUnisalute = False
    End Sub

    Private mAgenziaMadre As String
    Public Property AgenziaMadre() As String
        Get
            Return mAgenziaMadre
        End Get
        Set(value As String)
            mAgenziaMadre = value
            RaiseEvent CambiaStato()
        End Set
    End Property

    Private mAgenziaFiglia As String
    Public Property AgenziaFiglia() As String
        Get
            Return mAgenziaFiglia
        End Get
        Set(value As String)
            mAgenziaFiglia = value
            RaiseEvent CambiaStato()
        End Set
    End Property

    Private mUnisalute As Boolean
    Public Property Unisalute() As Boolean
        Get
            Return mUnisalute
        End Get
        Set(ByVal value As Boolean)
            mUnisalute = value
        End Set
    End Property

    Private mSubAgenzia As String
    Public Property SubAgenzia() As String
        Get
            Return mSubAgenzia
        End Get
        Set(value As String)
            mSubAgenzia = value
            RaiseEvent CambiaStato()
        End Set
    End Property

    Private mNumeroRecord As Integer
    Public Property NumeroRecord() As Integer
        Get
            Return mNumeroRecord
        End Get
        Set(value As Integer)
            mNumeroRecord = value
            RaiseEvent CambiaStato()
        End Set
    End Property

    Private mFileScaricati As Integer
    Public Property FileScaricati() As Integer
        Get
            Return mFileScaricati
        End Get
        Set(value As Integer)
            mFileScaricati = value
        End Set
    End Property

    Private mMessaggio As String
    Public Property Messaggio() As String
        Get
            Return mMessaggio
        End Get
        Set(value As String)
            mMessaggio = value
            RaiseEvent CambiaStato()
        End Set
    End Property

    Private mInizioPeriodo As Date
    Public Property InizioPeriodo() As Date
        Get
            Return mInizioPeriodo
        End Get
        Set(value As Date)
            mInizioPeriodo = value
            RaiseEvent CambiaStato()
        End Set
    End Property

    Private mFinePeriodo As Date
    Public Property FinePeriodo() As Date
        Get
            Return mFinePeriodo
        End Get
        Set(value As Date)
            mFinePeriodo = value
            RaiseEvent CambiaStato()
        End Set
    End Property

    Private mErrore As Boolean
    Public Property Errore() As Boolean
        Get
            Return mErrore
        End Get
        Set(value As Boolean)
            mErrore = value

            If mErrore = True Then
                RaiseEvent CambiaStato()
            End If
        End Set
    End Property

    Private mCodiceErrore As Integer
    Public Property CodiceErrore() As Integer
        Get
            Return mCodiceErrore
        End Get
        Set(value As Integer)
            mCodiceErrore = value
        End Set
    End Property
End Class