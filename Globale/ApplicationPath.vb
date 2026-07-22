Imports System.IO
Imports System.IO.Directory

<Serializable>
Public Class ApplicationPath

    Public Event CambioDiscoDati()
    Public Event CartellaAppChange()

#Region "Cartelle"
    'locali
    Public CartellaModelli As String
    Public CartellaTempComune As String
    Public CartellaTempUtente As String
    Public CartellaComUtente As String
    Public CartellaDocUtente As String
    Public CartellaSetting As String
    Public CartellaLogs As String
    Public CartellaUpdate As String
    Public CartellaBackup As String
    Public CartellaModelliDatiAgenzia As String
    Public CartellaModelliDatiComuni As String
    Public CartellaUpdateLocale As String
    'di rete
    Public CartellaUnitoolsRete As String
    Public CartellaDati As String
    Public CartellaDatiComuni As String
    Public CartellaArchivioDati As String
    Public CartellaDocumenti As String
    Public CartellaDocumentiStorico As String
    Public CartellaSms As String
    Public CartellaModelliRete As String
    Public CartellaSettingRete As String
    Public CartellaBackupRete As String
    Public CartellaUpdateRete As String
    Public CartellaFlag As String
    Public CartellaFlagLocale As String
    Public CartellaCentralinoRete As String
    Public CartellaEstrazioni As String
#End Region

    Public DbLink As String

    Sub New()
    End Sub

    Public Sub Inizializza(CartellaApp As String,
                           DiscoDatiLocale As String,
                           DiscoDatiRete As String)

        Try
            If (CartellaApp.Length < 2) OrElse CartellaApp.Substring(1, 2) <> ":\" Then
                Utx.ConfigError.Errore = True
                Utx.ConfigError.MessaggioErrore = "Definizione unità App/Dati errata."
                Exit Sub
            End If

            If (DiscoDatiLocale.Length > 1) OrElse (DiscoDatiRete.Length > 1) Then
                Utx.ConfigError.Errore = True
                Utx.ConfigError.MessaggioErrore = "Definizione unità App/Dati errata."
                Exit Sub
            End If

            mDiscoApp = CartellaApp.Substring(0, 3)
            mCartellaApp = CartellaApp
            mUnitaDatiLocale = DiscoDatiLocale
            mUnitaDatiRete = DiscoDatiRete

            RaiseEvent CartellaAppChange()

            ImpostaPercorsiLocali()

            If Utx.FunzioniRete.PcInDominio = True Then
                Me.UnitaDati = New DriveInfo(DiscoDatiRete)
            Else
                CreaUnitaLocale(DiscoDatiLocale)
                Me.UnitaDati = New DriveInfo(DiscoDatiLocale)
            End If

            'deve stare qui
            ImpostaAmbiente()

            'dblink
            'DbLink = Path.Combine(CartellaTempUtente, "DbLink.Interop.mdb") 'db di interscambio con (ad esempio) Bridgecom
            'Utx.Globale.CnDbLink = Utx.Globale.MDBDriver + DbLink

        Catch ex As Exception
            Utx.ConfigError.Errore = True
            Utx.ConfigError.MessaggioErrore = ex.Message
        End Try
    End Sub

    Private mDiscoApp As String
    Public ReadOnly Property DiscoApp() As String
        Get
            Return mDiscoApp
        End Get
    End Property

    Public Shared ReadOnly Property FlagEmme() As String
        Get
#If DEBUG Then
            Return "C:\ApplicazioniDirezione\UTW\EMME.FLAG"
#Else
            Return "C:\ApplicazioniDirezione\Unitools\EMME.FLAG"
#End If
        End Get
    End Property

    Public ReadOnly Property NomeCartellaApp() As String
        Get
            Return Path.GetFileName(mCartellaApp)
        End Get
    End Property

    Private mCartellaApp As String
    Public ReadOnly Property CartellaApp() As String
        Get
            Return mCartellaApp
        End Get
    End Property

    Public ReadOnly Property CartellaApp83() As String
        Get
            Return Utx.FunzioniAmbiente.Path83(CartellaApp)
        End Get
    End Property

    Private mUnitaDatiLocale As String
    Public Property UnitaDatiLocale() As String
        Get
            Return mUnitaDatiLocale
        End Get
        Set(value As String)
            mUnitaDatiLocale = value
        End Set
    End Property

    Private mUnitaDatiRete As String
    Public Property UnitaDatiRete() As String
        Get
            Return mUnitaDatiRete
        End Get
        Set(value As String)
            mUnitaDatiRete = value
        End Set
    End Property

    Private mUnitaDati As DriveInfo
    Public Property UnitaDati() As DriveInfo
        Get
            Return mUnitaDati
        End Get
        Set(value As DriveInfo)
            'se l'unità non è ancora definita o è diversa da quella da impostare
            If (mUnitaDati Is Nothing) OrElse (mUnitaDati.Name <> value.Name) Then

                Try
                    mUnitaDati = value

                    If mUnitaDati.IsReady Then
                        ImpostaPercorsiRete()
                        RaiseEvent CambioDiscoDati()
                    Else
                        Utx.ConfigError.Errore = True
                        Utx.ConfigError.MessaggioErrore = "Disco dati non pronto."
                    End If

                Catch ex As Exception
                    Utx.ConfigError.Errore = True
                    Utx.ConfigError.MessaggioErrore = ex.Message
                End Try
            End If
        End Set
    End Property

    Public ReadOnly Property NomeUnitaDati() As String
        Get
            Return mUnitaDati.Name
        End Get
    End Property

    Public ReadOnly Property StringaAmbiente() As String
        Get
            Return Utx.Setting.Ambiente.ToString
        End Get
    End Property

    Private mNomeDbLink As String = "DbLink"
    Public Property NomeDbLink() As String
        Get
            Return mNomeDbLink
        End Get
        Set(value As String)
            If value = "DbLink" Then
                MsgBox("Il nome 'DbLink' non può essere utilizzato.", MsgBoxStyle.Exclamation, "Attenzione")
            Else
                mNomeDbLink = value
            End If
        End Set
    End Property

    Private Sub CreaUnitaLocale(DiscoDatiLocale As String)
        Try
            CreateDirectory(mCartellaApp)

            If New DriveInfo(DiscoDatiLocale).IsReady = False Then
                'elimino percorsi precedenti
                Shell(String.Format("cmd /c subst {0}: /d", DiscoDatiLocale), AppWinStyle.Hide, True)
                'creo l'unità virtuale sulla cartella dell'app
                Shell(String.Format("cmd /c subst {0}: {1}",
                                    DiscoDatiLocale,
                                    Utx.FunzioniAmbiente.Path83(Directory.GetParent(mCartellaApp).FullName)),
                                    AppWinStyle.Hide, True)
            End If
        Catch ex As Exception
            Utx.ConfigError.Errore = True
            Utx.ConfigError.MessaggioErrore = ex.Message
        End Try
    End Sub

    Private Sub ImpostaPercorsiLocali()
        Try
            CartellaModelli = Path.Combine(mCartellaApp, "Modelli")
            CartellaTempComune = Path.Combine(mCartellaApp, "Temp")
            CartellaTempUtente = Path.Combine(CartellaTempComune, Utx.Globale.PcUserName)
            CartellaLogs = Path.Combine(mCartellaApp, "Logs")
            CartellaComUtente = Path.Combine(CartellaTempUtente, "COM")
            CartellaDocUtente = Path.Combine(CartellaTempUtente, "DOC")
            CartellaSetting = Path.Combine(CartellaModelli, "Setting")
            CartellaBackup = Path.Combine(mCartellaApp, "Archivi.bak")
            CartellaModelliDatiAgenzia = Path.Combine(CartellaModelli, "Dati\Agenzia")
            CartellaModelliDatiComuni = Path.Combine(CartellaModelli, "Dati\Comuni")
            CartellaUpdateLocale = Path.Combine(mCartellaApp, "Update")
            CartellaFlagLocale = Path.Combine(CartellaModelli, "Flag")

            'se è un pc di proprietà
            If Utx.FunzioniRete.PcInDominio = False Then
                Directory.CreateDirectory(Path.Combine(mCartellaApp, "Update"))
            End If

            'creo le cartelle
            CreateDirectory(CartellaModelli)
            CreateDirectory(CartellaModelliDatiAgenzia)
            CreateDirectory(CartellaModelliDatiComuni)
            CreateDirectory(CartellaTempComune)
            CreateDirectory(CartellaTempUtente)
            CreateDirectory(CartellaComUtente)
            CreateDirectory(CartellaDocUtente)
            CreateDirectory(CartellaLogs)
            CreateDirectory(CartellaBackup)
            CreateDirectory(CartellaSetting)
            CreateDirectory(CartellaUpdateLocale)
            CreateDirectory(CartellaFlagLocale)

            'variabili di ambiente
            Environment.SetEnvironmentVariable("UNITOOLS_CARTELLA_TEMP_COMUNE", CartellaTempComune)
            Environment.SetEnvironmentVariable("UNITOOLS_CARTELLA_TEMP", CartellaTempUtente)
            Environment.SetEnvironmentVariable("UNITOOLS_CARTELLA_COM", CartellaComUtente)

        Catch ex As Exception
            Utx.ConfigError.Errore = True
            Utx.ConfigError.MessaggioErrore = ex.Message
        End Try
    End Sub

    Private Sub ImpostaPercorsiRete()
        Try
            CartellaUnitoolsRete = Path.Combine(mUnitaDati.Name, Me.NomeCartellaApp)
            CartellaDati = Path.Combine(CartellaUnitoolsRete, "Dati")
            CartellaDatiComuni = Path.Combine(CartellaDati, "00000")
            CartellaArchivioDati = Path.Combine(CartellaUnitoolsRete, "ArchivioDati")
            CartellaDocumenti = Path.Combine(CartellaUnitoolsRete, "Documenti")
            CartellaDocumentiStorico = Path.Combine(CartellaUnitoolsRete, "DocumentiStorico")
            CartellaModelliRete = Path.Combine(CartellaUnitoolsRete, "Modelli")
            CartellaSettingRete = Path.Combine(CartellaModelliRete, "Setting")
            CartellaSms = Path.Combine(CartellaModelliRete, "Sms")
            CartellaBackupRete = Path.Combine(CartellaUnitoolsRete, "Archivi.bak")
            CartellaUpdateRete = Path.Combine(CartellaUnitoolsRete, "Update")
            CartellaFlag = Path.Combine(CartellaModelliRete, "Flag")
            CartellaCentralinoRete = Path.Combine(CartellaUnitoolsRete, "Temp\Centralino\messaggi")
            CartellaEstrazioni = Path.Combine(CartellaUnitoolsRete, "Oggetti")

            CreateDirectory(CartellaUnitoolsRete)
            CreateDirectory(CartellaDati)
            CreateDirectory(CartellaDatiComuni)
            CreateDirectory(CartellaArchivioDati)
            CreateDirectory(CartellaDocumenti)
            CreateDirectory(CartellaDocumentiStorico)
            CreateDirectory(CartellaSms)
            CreateDirectory(CartellaModelliRete)
            CreateDirectory(CartellaSettingRete)
            CreateDirectory(CartellaBackupRete)
            CreateDirectory(CartellaUpdateRete)
            CreateDirectory(CartellaFlag)
            CreateDirectory(CartellaEstrazioni)

            If New DriveInfo("M").IsReady Then
                CreateDirectory(CartellaCentralinoRete)
            End If

            ControlloDatabaseComuni()

            'variabile d'ambiente
            Environment.SetEnvironmentVariable("UNITOOLS_CARTELLA_DATI", CartellaDati)
            Environment.SetEnvironmentVariable("UNITOOLS_CARTELLA_SMS", CartellaSms)
            Environment.SetEnvironmentVariable("UNITOOLS_CARTELLA_DOCUMENTI", CartellaDocumenti)

        Catch ex As Exception
            Utx.ConfigError.Errore = True
            Utx.ConfigError.MessaggioErrore = ex.Message
        End Try
    End Sub

    Private Sub ControlloDatabaseComuni()
        Try
            'controlla l'esistenza di tutti i db comuni
            For Each f As String In Directory.GetFiles(CartellaModelliDatiComuni)
                'escludo gli UTOLD
                If Path.GetFileName(f).ToUpper.StartsWith("UTOLD.") = False Then
                    'se non esiste lo copia dalla cartella dei modelli
                    If File.Exists(Path.Combine(CartellaDatiComuni, Path.GetFileName(f))) = False Then
                        File.Copy(f, Path.Combine(CartellaDatiComuni, Path.GetFileName(f)))
                    End If
                End If
            Next

        Catch ex As Exception
            Utx.ConfigError.Errore = True
            Utx.ConfigError.MessaggioErrore = ex.Message
        End Try
    End Sub

    Private Sub ImpostaAmbiente()
#If DEBUG Then
        Utx.Setting.Ambiente = Utx.Enumerazioni.TipoAmbiente.PP
        Environment.SetEnvironmentVariable("UNITOOLS_AMBIENTE", Utx.Enumerazioni.TipoAmbiente.PP.ToString)
#Else
        'all'avvio o sei DIR o PP. se poi ci si connette alla rete allorara si passa da PP a PP2DIR
        If Utx.FunzioniRete.PcInDominio = True Then
            'pc direzione
            Utx.Setting.Ambiente = Utx.Enumerazioni.TipoAmbiente.DIR
            Environment.SetEnvironmentVariable("UNITOOLS_AMBIENTE", Utx.Enumerazioni.TipoAmbiente.DIR.ToString)
        Else
            'pc proprio 
            Utx.Setting.Ambiente = Utx.Enumerazioni.TipoAmbiente.PP
            Environment.SetEnvironmentVariable("UNITOOLS_AMBIENTE", Utx.Enumerazioni.TipoAmbiente.PP.ToString)
        End If
#End If
    End Sub

    Public Function DocFolder(TipoCartella As Enumerazioni.DocFolderType) As String
        'restituisce il nome completo della cartella o la url identificata dal tipo
        On Error Resume Next

        Select Case TipoCartella
            Case Enumerazioni.DocFolderType.LISTE_QT
                DocFolder = Path.Combine(CartellaUnitoolsRete, "Documenti_Unipol\Liste_Quietanzamento")
                Directory.CreateDirectory(DocFolder)
            Case Enumerazioni.DocFolderType.BUSTE
                DocFolder = Path.Combine(CartellaUnitoolsRete, "Documenti_Unipol\Buste")
                Directory.CreateDirectory(DocFolder)
            Case Enumerazioni.DocFolderType.SP_RCA
                DocFolder = Path.Combine(CartellaUnitoolsRete, "Documenti_Unipol\Patto_Unipol\Documentazione_SP_Rca")
                Directory.CreateDirectory(DocFolder)
            Case Enumerazioni.DocFolderType.PRECONTO
                DocFolder = "http://www.utools.it/Unitools/Doc/DocumentiUnipol/DocumentazioneAccordi/AccordoPreconto/IndexDoc.htm"
        End Select
    End Function

    Public Function CartellaAssegni(Data As Date) As String
        Return String.Format("{0}\i\Documenti personali\Assegni\{1}\{2:00}", CartellaDocumenti, Data.Year, Data.Month)
    End Function
End Class
