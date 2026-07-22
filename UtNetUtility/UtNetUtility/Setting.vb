Imports System.IO

Public Class Setting

    'costanti
    Public Const MDBDriver As String = "Provider = Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source="
    Public Const Compagnia As Integer = 1

    'variabili condivise globali
    Public Shared AgenziaRichiesta As String = UtNetUtility.NetFunc.GetEnvironmentVar("UNITOOLS_AGENZIA_RICHIESTA")
    Public Shared CnDbLink As String = UtNetUtility.NetFunc.GetEnvironmentVar("UNITOOLS_STRINGA_CONNESSIONE_DB")

    Public Structure Utente
        ''' <summary>
        ''' Obsoleto: utilizzare UniageUser
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared IdUser As String = UtNetUtility.NetFunc.GetEnvironmentVar("UNITOOLS_UNIAGE_USER")
        Public Shared UniageUser As String = UtNetUtility.NetFunc.GetEnvironmentVar("UNITOOLS_UNIAGE_USER")
        Public Shared UniagePw As String = UtNetUtility.NetFunc.GetEnvironmentVar("UNITOOLS_UNIAGE_PW")
        Public Shared EssigUser As String = UtNetUtility.NetFunc.GetEnvironmentVar("UNITOOLS_UNIAGE_USER")
        Public Shared EssigPw As String = UtNetUtility.NetFunc.GetEnvironmentVar("UNITOOLS_UNIAGE_PW")
    End Structure

    Public Structure Ambiente
        Public Shared Tipo As TipoAmbiente = ImpostaAmbiente()
        Public Shared CartellaApplicazione As String = "C:\ApplicazioniDirezione\Unitools"
        Public Shared CartellaTemp As String = UtNetUtility.NetFunc.GetEnvironmentVar("UNITOOLS_CARTELLA_TEMP")
        Public Shared CartellaCom As String = UtNetUtility.NetFunc.GetEnvironmentVar("UNITOOLS_CARTELLA_COM")
        Public Shared CartellaSms As String = UtNetUtility.NetFunc.GetEnvironmentVar("UNITOOLS_CARTELLA_SMS")
        Public Shared CartellaDocumenti As String = UtNetUtility.NetFunc.GetEnvironmentVar("UNITOOLS_CARTELLA_DOCUMENTI")
        Public Shared CartellaDati As String = UtNetUtility.NetFunc.GetEnvironmentVar("UNITOOLS_CARTELLA_DATI")
        Public Shared CartellaModelliLocale As String = Path.Combine(CartellaApplicazione, "Modelli")
        Public Shared CartellaSettingLocale As String = Path.Combine(CartellaModelliLocale, "Setting")
        Public Shared CartellaModelliEmme As String = Path.Combine(CartellaDati, "Modelli")
        Public Shared CartellaSettingEmme As String = Path.Combine(CartellaModelliEmme, "Setting")
        Public Shared Smtp As String = UtNetUtility.NetFunc.GetEnvironmentVar("UNITOOLS_SMTP")
    End Structure

    'costanti abilitazioni
    Public Const ABILITAZIONE_UNITOOLS As Integer = 1
    Public Const ABILITAZIONE_SMS As Integer = 2
    Public Const ABILITAZIONE_VISURE As Integer = 4
    Public Const ABILITAZIONE_SISTEMA As Integer = 8
    Public Const ABILITAZIONE_QUOTATORE As Integer = 16
    Public Const ABILITAZIONE_UNIGEST As Integer = 32
    Public Const ABILITAZIONE_PATTO_UNIPOL As Integer = 64
    Public Const ABILITAZIONE_LISTEQT As Integer = 128
    Public Const ABILITAZIONE_ARCHIVIO_DATI As Integer = 256
    Public Const ABILITAZIONE_CHECK As Integer = 511

#Region "Enumerazioni"

    Public Enum TipoAmbiente
        [DIR] = 0
        [PP] = 1
        [PP2DIR] = 2
    End Enum

#End Region

    'Public Shared Sub RefreshAmbiente()

    '    Ambiente.Tipo = ImpostaAmbiente()
    '    Ambiente.CartellaApplicazione = "C:\ApplicazioniDirezione\Unitools"
    '    Ambiente.CartellaTemp = UtNetUtility.NetFunc.GetEnvironmentVar("UNITOOLS_CARTELLA_TEMP")
    '    Ambiente.CartellaCom = UtNetUtility.NetFunc.GetEnvironmentVar("UNITOOLS_CARTELLA_COM")
    '    Ambiente.CartellaSms = UtNetUtility.NetFunc.GetEnvironmentVar("UNITOOLS_CARTELLA_SMS")
    '    Ambiente.CartellaDocumenti = UtNetUtility.NetFunc.GetEnvironmentVar("UNITOOLS_CARTELLA_DOCUMENTI")
    '    Ambiente.CartellaDati = UtNetUtility.NetFunc.GetEnvironmentVar("UNITOOLS_CARTELLA_DATI")
    '    Ambiente.CartellaModelliLocale = Path.Combine(Ambiente.CartellaApplicazione, "Modelli")
    '    Ambiente.CartellaSettingLocale = Path.Combine(Ambiente.CartellaModelliLocale, "Setting")
    '    Ambiente.CartellaModelliEmme = Path.Combine(Ambiente.CartellaDati, "Modelli")
    '    Ambiente.CartellaSettingEmme = Path.Combine(Ambiente.CartellaModelliEmme, "Setting")
    '    Ambiente.Smtp = UtNetUtility.NetFunc.GetEnvironmentVar("UNITOOLS_SMTP")
    'End Sub

    Public Shared Function ImpostaAmbiente() As TipoAmbiente

        Select Case UtNetUtility.NetFunc.GetEnvironmentVar("UNITOOLS_AMBIENTE")

            Case "PP"
                Return TipoAmbiente.PP
            Case "PP2DIR"
                Return TipoAmbiente.PP2DIR
            Case Else
                Return TipoAmbiente.DIR
        End Select
    End Function

    Public Shared Function ImpostaDominio() As String
        Return "uniage"
    End Function

    Public Shared Function ImpostaProxy() As System.Net.WebProxy
        Try
            If (Environment.UserDomainName.ToUpper = "UNIAGE" OrElse Environment.UserDomainName.ToUpper = "AURAGE") Then
                'pc in dominio
                Globale.Log.AddLog("pc in dominio")
                Dim Proxy As New System.Net.WebProxy("proxyu.ha.servizi.gr-u.it", 80)
                Proxy.Credentials = New Net.NetworkCredential(Utente.UniageUser, Utente.UniagePw, "uniage")
                Return Proxy
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function CartellaDatiAgenzia(ByVal Agenzia As Integer) As String

        Try
            Return String.Format("{0}\Dati\{1}", Ambiente.CartellaDati, Agenzia.ToString.PadLeft(5, "0"))

        Catch ex As Exception
            Return ""
        End Try

    End Function

    Public Shared Function HostName() As String

        Try
            If EsisteUnivar() = True Then
                Return NetFunc.GetEnvironmentVar("UNIVAR")
            Else
                Return System.Environment.MachineName
            End If

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
            Return "U99999-99-99"
        End Try

    End Function

    Public Shared Function EsisteUnivar() As Boolean
        Return (NetFunc.GetEnvironmentVar("UNIVAR").Trim.Length > 0)
    End Function

    Public Shared Function PcToAgenzia() As String

        Try
            'nome pc ex-unipol U01949-00-01 oppure 102416-00-00 (TS)
            'nome pc ex-navale 703235-00-01
            'nome pc ex-aurora 10200-00-01
            'nome del pc preso dalla variabile UNIVAR
            Dim HnAgenzia As String = HostName().Split("-")(0)

            If HnAgenzia.StartsWith("ASSI") Then 'per le assicoop

                Dim WsSetting As New SettingAgenzia.ConfiguraSede
                Return WsSetting.Assicoop2Codice(HnAgenzia.Substring(0, 6))

            ElseIf HnAgenzia.Length = 6 Then 'lungo 6 = unipol/navale

                If HnAgenzia.StartsWith("7") Then
                    'ex-navale
                    Return Format(Val(HnAgenzia.Substring(1, 5)) + 70000, "00000")
                Else
                    'unipol (U/1 per TS)
                    Return HnAgenzia.Substring(1, 5)
                End If

            Else 'lungo 5 = ex-aurora
                Return HnAgenzia
            End If

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
            Return "-ERR"
        End Try

    End Function

    Public Shared Function PcDirezione() As Boolean

        Dim Hn As String = HostName()

        'la seconda parte si dovrebbe, dopo controlli rimuovere lasciando solo il controllo del dominio
        If Environment.UserDomainName.ToUpper = "UNIAGE" OrElse
           Environment.UserDomainName.ToUpper = "AURAGE" Then

            Return True

        ElseIf EsisteUnivar() Then
            Return True

        ElseIf (Hn Like "[UX]#####-##-##") OrElse
               (Hn Like "#####-##-##") OrElse
               (Hn Like "######-##-##") Then

            'se esiste M e non esiste U
            If (New DriveInfo("M").IsReady) And (Not New DriveInfo("U").IsReady) Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If

    End Function

End Class
