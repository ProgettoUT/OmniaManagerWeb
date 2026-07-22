Imports System.IO
Imports System.Drawing
Imports System.Runtime.InteropServices

Public Class Globale
    'per forzare i cookie nel browser
    <DllImport("wininet.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Public Shared Function InternetSetCookie(lpszUrl As String,
      lpszCookieName As String, lpszCookieDataAs As String) As Boolean
    End Function

    Public Shared LoginUniage As New AutenticazioneUeba
    Public Shared LoginUS As New AutenticazioneEssig(Autenticazione.TipoLogin.ESSIG_UNISALUTE)

    'variabili condivise globali
    Public Shared PingUniarea As Boolean
    Public Shared IdAppOk As Boolean = False
    Public Shared Log As Utx.ApplicationLog
    Public Shared UniProxy As Proxy
    Public Shared PcUserName As String = Environment.UserName.Replace(" ", "_")
    Public Shared WithEvents SessioneCorrente As Sessione

    'ritardo timer ricerca clienti/sinistri
    Public Shared RitardoTimer As Integer 'in millisecondi per la ricerca automatica
    'setting dictionary
    Public Shared SettingGlobale As Utx.ApplicationUserSetting
    Public Shared SettingUtente As Utx.ApplicationUserSetting
    Public Shared SettingInterop As Utx.ApplicationUserSetting
    'driver DB
    Public Const MDBDriver As String = "Provider=Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source="
    Public Const MDBDriverExclusive As String = "Provider=Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Mode=Share Exclusive; Data Source="
    Public Const CSVDriver As String = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=""text;HDR=Yes;FMT=Delimited(;)"";Data Source="
    Public Const XLSDriver As String = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"";Data Source="
    'esempio non scontato con password per il database
    'MDBDriver = "Provider = Microsoft.Jet.OLEDB.4s.0; User Id=; Jet OLEDB:Database Password=pwd; Data Source="
    'app e utente
    Public Shared WithEvents Paths As ApplicationPath
    Public Shared WithEvents UtenteCorrente As Utente
    Public Shared WithEvents AgenziaRichiesta As Agenzia
    Public Shared WithEvents ProfiloEnteGestore As EnteGestore
    'connessione a dblink
    Public Shared CnDbLink As String = ""
    Public Shared FullPathBag As String
    'token
    Public Shared Token As String

#If DEBUG Then
    Public Shared Ambiente As String = "PROD" 'PROD/TEST
#End If

    'Public Shared ListaThread As New List(Of Threading.Thread)

    Public Shared Function Init() As Boolean
        'definisco i dischi e i percorsi dell'applicazione
        Utx.Globale.Paths = New Utx.ApplicationPath

#If DEBUG Then
        'cartella UT
        If New DriveInfo("M").IsReady = True Then
            Select Case Ambiente
                Case "TEST"
                    Utx.Globale.Paths.Inizializza("C:\ApplicazioniDirezione\UTW", "M", "M")
                Case "PROD"
                    Utx.Globale.Paths.Inizializza("C:\ApplicazioniDirezione\Unitools", "M", "M")
            End Select
        Else
            'il disco M: non è pronto
            If File.Exists(Utx.ApplicationPath.FlagEmme) Then
                'il disco M: è richiesto dalla presenza del flag e quindi avvio impossibile
                MsgBox($"Disco di rete M: non presente o non pronto. Impossibile avviare l'applicazione.{StrDup(2, Environment.NewLine)}Controllare che GOOGLE DRIVE sia avviato.",
                       MsgBoxStyle.Exclamation, "Unitools")
                Return False
            Else
                'il disco M: non è richiesto e vado su U:
                Utx.Globale.Paths.Inizializza("C:\ApplicazioniDirezione\UTW", "U", "M")
            End If
        End If
        ControlloCartelleDoppie()
#Else
        'cartella UT
        If New DriveInfo("M").IsReady = True Then
            Utx.Globale.Paths.Inizializza("C:\ApplicazioniDirezione\Unitools", "M", "M")
        Else
            'il disco M: non è pronto
            If File.Exists(Utx.ApplicationPath.FlagEmme) Then
                'il disco M: è richiesto dalla presenza del flag e quindi avvio impossibile
                MsgBox(String.Format("Disco di rete M: non presente o non pronto. Impossibile avviare l'applicazione.{0}{0}Controllare che GOOGLE DRIVE sia avviato.",
                                     Environment.NewLine), MsgBoxStyle.Exclamation, "Unitools")
                Return False
            Else
                'il disco M: non è richiesto e vado su U:
                Utx.Globale.Paths.Inizializza("C:\ApplicazioniDirezione\Unitools", "U", "M")
            End If
        End If
#End If

        'inizializzo il token web
        Token = Utx.NetFunc.TokenUniWeb
        'inizializzo proxy
        Utx.Globale.UniProxy = New Utx.Proxy
        Return True
    End Function

    Public Shared Sub VerificaGoogleDrive()
        Try
            If New DriveInfo("M").IsReady = False Then
#If DEBUG Then
                Select Case Ambiente
                    Case "TEST" 'mio account GDrive
                        Dim CartellaGoogle As String = "G:\Il mio drive\Direzione"
                        'Directory.CreateDirectory(CartellaGoogle)
                        If Directory.Exists(CartellaGoogle) Then
                            Shell($"Subst M: ""{CartellaGoogle}""", AppWinStyle.Hide, Wait:=True, 10000)

                            Dim EmmePath As String = Path.Combine(CartellaGoogle, "Unitools", "Emme.path")
                            File.WriteAllText(EmmePath, EmmePath)
                        End If
                    Case "PROD" 'account di agenzia
                        CreaMW()
                End Select
#Else
                CreaMW()
#End If
            End If
        Catch ex As Exception
            'non fare niente - log non ancora disponibili
        End Try
    End Sub

    Public Shared Sub CreaMW()
        Try
            Dim CartellaRoot As String = "Drive condivisi"
            Const LettereDrive As String = "D/E/F/G/H/I/J/K/L/N/O/P/Q/R/S/T/U/V/W/X/Y/Z"

            '-----------------------------------------------------------
            'VERIFICO SE ESISTE UN FILE CHE CONTIENE IL PERCORSO DI M:
            '-----------------------------------------------------------
            Dim FlagEmme As String = "C:\ApplicazioniDirezione\Unitools\Modelli\Setting\Emme.path"
            If File.Exists(FlagEmme) Then
                Dim PathEmme As String = File.ReadAllText(FlagEmme)
                'se il percorso scritto nella stringa non è vuoto
                If String.IsNullOrEmpty(PathEmme) = False Then
                    Dim DiscoM As String = $"{PathEmme}\Direzione"
                    Dim DiscoW As String = $"{PathEmme}\DocumentiCondivisi"

                    Shell($"Subst M: ""{DiscoM}""", AppWinStyle.Hide, Wait:=True, 10000)
                    Shell($"Subst W: ""{DiscoW}""", AppWinStyle.Hide, Wait:=False, 10000)
                    Exit Try
                End If
            End If

            '-----------------------------------------------------------------------
            'PERCORSO PERSONALIZZATO SU GOOGLE DRIVE (del tipo 101197-AGE-DISCOEMME)
            '-----------------------------------------------------------------------
            For Each unita As String In LettereDrive.Split("/")
                Dim Cartella As String = $"{unita}:\{CartellaRoot}"

                If Directory.Exists(Cartella) Then
                    For Each d As String In Directory.GetDirectories(Cartella)
                        If Path.GetFileName(d) Like "1[0-9][0-9][0-9][0-9][0-9]-AGE-DISCOEMME" Then
                            Dim Agenzia As String = Path.GetFileName(d).Substring(1, 5)
                            Dim DiscoM As String = $"{unita}:\{CartellaRoot}\1{Agenzia}-AGE-DISCOEMME"

                            Shell($"Subst M: ""{DiscoM}""", AppWinStyle.Hide, Wait:=True, 10000)
                            Exit Try
                        End If
                    Next
                End If
            Next

            '---------------------------------
            'PERCORSI STANDARD SU GOOGLE DRIVE
            '---------------------------------
            For Each unita As String In LettereDrive.Split("/")
                Dim Cartella As String = $"{unita}:\{CartellaRoot}"

                If Directory.Exists(Cartella) Then
                    For Each d As String In Directory.GetDirectories(Cartella)
                        If Path.GetFileName(d) Like "1[0-9][0-9][0-9][0-9][0-9]-NGA" Then
                            Dim Agenzia As String = Path.GetFileName(d).Substring(1, 5)
                            Dim DiscoM As String = $"{unita}:\{CartellaRoot}\1{Agenzia}-NGA\1{Agenzia}-00-00_C\Direzione"
                            Dim DiscoW As String = $"{unita}:\{CartellaRoot}\1{Agenzia}-NGA\1{Agenzia}-00-00_C\DocumentiCondivisi"

                            Shell($"Subst M: ""{DiscoM}""", AppWinStyle.Hide, Wait:=True, 10000)
                            Shell($"Subst W: ""{DiscoW}""", AppWinStyle.Hide, Wait:=False, 10000)
                            Exit Try
                        End If
                    Next

                    'se ancora non esiste provo percorso AGE-EX tipo 139893-AGE-EX-102451-NGA (Bolzano)
                    If New DriveInfo("M").IsReady = False Then
                        For Each d As String In Directory.GetDirectories(Cartella)
                            If Path.GetFileName(d) Like "1[0-9][0-9][0-9][0-9][0-9]-AGE-EX-1[0-9][0-9][0-9][0-9][0-9]-NGA" Then
                                Dim Agenzia As String = Path.GetFileName(d).Substring(1, 5)
                                Dim ExAgenzia As String = Path.GetFileName(d).Substring(15, 5)
                                Dim DiscoM As String = $"{unita}:\{CartellaRoot}\1{Agenzia}-AGE-EX-1{ExAgenzia}-NGA\1{ExAgenzia}-00-00_C\Direzione"
                                Dim DiscoW As String = $"{unita}:\{CartellaRoot}\1{Agenzia}-AGE-EX-1{ExAgenzia}-NGA\1{ExAgenzia}-00-00_C\DocumentiCondivisi"

                                Shell($"Subst M: ""{DiscoM}""", AppWinStyle.Hide, Wait:=True, 10000)
                                Shell($"Subst W: ""{DiscoW}""", AppWinStyle.Hide, Wait:=False, 10000)
                                Exit Try
                            End If
                        Next
                    End If

                    'se emme ancora non esiste controllo percorso alternativo
                    If New DriveInfo("M").IsReady = False Then
                        Dim d As String = Directory.GetDirectories(Cartella)(0) 'prendo la prima cartella
                        Dim Agenzia As String = Path.GetFileName(d).Substring(1, 5) 'estraggo il codice agenzia

                        'Percorso tipo: G:\Drive condivisi\139834-AGE-NGASERVER\139834-00-00_C\Direzione
                        Dim DiscoM As String = $"{unita}:\{CartellaRoot}\1{Agenzia}-AGE-NGASERVER\1{Agenzia}-00-00_C\Direzione"
                        Dim DiscoW As String = $"{unita}:\{CartellaRoot}\1{Agenzia}-AGE-NGASERVER\1{Agenzia}-00-00_C\DocumentiCondivisi"

                        Shell($"Subst M: ""{DiscoM}""", AppWinStyle.Hide, Wait:=True, 10000)
                        Shell($"Subst W: ""{DiscoW}""", AppWinStyle.Hide, Wait:=False, 10000)
                        Exit Try
                    End If
                End If
            Next
        Catch ex As Exception
            'LOG NON ANCORA DISPONIBILI
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, TitoloApp)
        End Try
    End Sub

    Private Shared Function ControlloCartelleDoppie()
#If DEBUG Then
        Try
            Dim Flag As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "CartellaOriginale.flag")

            If Directory.GetDirectories(Utx.Globale.Paths.UnitaDati.Name, "Unitools*").Length > 1 Then
                For Each d As String In Directory.GetDirectories(Utx.Globale.Paths.UnitaDati.Name, "Unitools*")

                Next
            End If
            If File.Exists(Flag) Then

            End If
        Catch ex As Exception
            'log non ancora disponibili
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, TitoloApp)
            Return False
        End Try
#End If
    End Function

    Public Shared Sub IdApp(Id As String)
        IdAppOk = (Utx.NetFunc.StringToMD5(Id) = "5E922648C24FC1AEA7A85AE74F9B23C2")
    End Sub

    Public Shared TitoloApp As String = "AUA"
    Public Shared Sub ImpostaTitoloApp()
        Select Case Utx.Globale.ProfiloEnteGestore.ProfiloApp
            Case Utx.Enumerazioni.ProfiloApp.COMPLETO
                Utx.Globale.TitoloApp = "AUAweb"
            Case Utx.Enumerazioni.ProfiloApp.SINISTRI
                Utx.Globale.TitoloApp = "UniSinistri"
            Case Utx.Enumerazioni.ProfiloApp.POSTALIZZAZIONE
                Utx.Globale.TitoloApp = "Comunicatore"
            Case Utx.Enumerazioni.ProfiloApp.SINISTRI_POSTALIZZAZIONE
                Utx.Globale.TitoloApp = "UniSinistri"
            Case Else
                Utx.Globale.TitoloApp = "OmniaManager"
        End Select
    End Sub

    Public Shared Sub ImpostaVariabiliAmbiente()
        Try
            Environment.SetEnvironmentVariable("UNITOOLS_STRINGA_CONNESSIONE_DB", CnDbLink)
            Environment.SetEnvironmentVariable("UNITOOLS_AMBIENTE", Utx.Setting.Ambiente.ToString)
            Environment.SetEnvironmentVariable("UNITOOLS_CARTELLA_DATI", Utx.Globale.Paths.CartellaUnitoolsRete)
            Environment.SetEnvironmentVariable("UNITOOLS_CARTELLA_DOCUMENTI", Utx.Globale.Paths.CartellaDocumenti)
            Environment.SetEnvironmentVariable("UNITOOLS_CARTELLA_TEMP", Utx.Globale.Paths.CartellaTempUtente)
            Environment.SetEnvironmentVariable("UNITOOLS_AGENZIA_RICHIESTA", Utx.Globale.AgenziaRichiesta.CodiceAgenzia)
            Log.Trace("UNITOOLS_STRINGA_CONNESSIONE_DB: {0}", {CnDbLink})
            Log.Trace("UNITOOLS_AMBIENTE: {0}", {Utx.Setting.Ambiente.ToString})
            Log.Trace("UNITOOLS_CARTELLA_DATI: {0}", {Utx.Globale.Paths.CartellaUnitoolsRete})
            Log.Trace("UNITOOLS_CARTELLA_DOCUMENTI: {0}", {Utx.Globale.Paths.CartellaDocumenti})
            Log.Trace("UNITOOLS_CARTELLA_TEMP: {0}", {Utx.Globale.Paths.CartellaTempUtente})
            Log.Trace("UNITOOLS_AGENZIA_RICHIESTA: {0}", {Utx.Globale.AgenziaRichiesta.CodiceAgenzia})
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Shared Sub Paths_CambioDiscoDati() Handles Paths.CambioDiscoDati, AgenziaRichiesta.CambioAgenziaRichiesta
        If Utx.Globale.AgenziaRichiesta IsNot Nothing Then
            Utx.Globale.AgenziaRichiesta.Init()
        End If
    End Sub

    Private Shared Sub Paths_CartellaAppChange() Handles Paths.CartellaAppChange
        'qui dopo la definizione della cartella dell'app
        Utx.Globale.Log = New Utx.ApplicationLog("Unitools.log")
    End Sub

    Public Shared ReadOnly WidthRatio As Single = Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width / 2560
    Public Shared ReadOnly HeightRatio As Single = Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height / 1080
    Public Shared Scala As New SizeF(WidthRatio, HeightRatio)

    'Public Shared Sub ScalaControlli(Controllo As Windows.Forms.Form)
    '    Exit Sub
    '    Utx.Globale.Log.Info("Width: {0}", {Windows.Forms.Screen.PrimaryScreen.Bounds.Width})
    '    Utx.Globale.Log.Info("Height: {0}", {Windows.Forms.Screen.PrimaryScreen.Bounds.Height})
    '    Utx.Globale.Log.Info("Ratio: {0} x {1} = {2}", {HeightRatio, WidthRatio, HeightRatio * WidthRatio})
    '    If (Utx.Sessione.Hide = False) AndAlso (HeightRatio * WidthRatio <> 1) Then
    '        Dim Pos As Windows.Forms.FormStartPosition = Controllo.StartPosition
    '        Controllo.Scale(Scala)

    '        For Each control As Windows.Forms.Control In Controllo.Controls
    '            control.Scale(Scala)
    '            control.Font = Utx.AppFont.Extra(Utx.AppFont.FontSize * HeightRatio * WidthRatio, FontStyle.Regular)
    '        Next
    '        Controllo.StartPosition = Pos
    '    End If
    'End Sub
    'Public Shared Sub ScalaFont(Controllo As Windows.Forms.Control)
    '    Exit Sub
    '    If (Utx.Sessione.Hide = False) AndAlso (HeightRatio * WidthRatio <> 1) Then
    '        Controllo.Font = Utx.AppFont.Extra(Utx.AppFont.FontSize * HeightRatio * WidthRatio, FontStyle.Regular)
    '    End If
    'End Sub
End Class

Public Class ConfigError
    Public Shared Errore As Boolean
    Public Shared MessaggioErrore As String
End Class
