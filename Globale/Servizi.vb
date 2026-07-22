Imports System.IO
Imports System.Net

Public Class Servizi

    Public Shared Sub AvviaLiveUpdate(Optional Forzatura As Boolean = False,
                                      Optional Nascosta As Boolean = False,
                                      Optional AgenziaMadre As String = "")
        Dim FileExe As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "LiveUpdate.exe")
        Try
            Globale.Log.Info("Avvio live update: forzatura {0}", {Forzatura.ToString})

            File.Copy(FileExe, LiveUpdateTemporaneo, True)
            If File.Exists(LiveUpdateTemporaneo) Then
                If String.IsNullOrEmpty(AgenziaMadre) Then
                    AgenziaMadre = Utx.Globale.ProfiloEnteGestore.AgenziaMadre
                End If

                Using p As New Process
                    p.StartInfo.FileName = LiveUpdateTemporaneo()
                    'in avvio, dalla riga di comando, passare:
                    'utente o agenzia;idapp;modalità >> 102379xx/02379;UT;NORMALE/HIDE/FORZATURA
                    If Nascosta = True Then
                        p.StartInfo.Arguments = AgenziaMadre + ";UTW;HIDE"
                    ElseIf Forzatura = True Then
                        p.StartInfo.Arguments = AgenziaMadre + ";UTW;FORZATURA"
                    Else
                        p.StartInfo.Arguments = AgenziaMadre + ";UTW;NORMALE"
                    End If
                    Globale.Log.Info(p.StartInfo.Arguments)
                    p.Start()
                End Using
            End If
            'se il file non c'è non faccio niente: verrà scaricato da aggiorna liveupdate alla prima occasione
        Catch ex As Exception
            Globale.Log.Info(ex.Message)
            'cancello il file (danneggiato) così lo riscarica
            If File.Exists(FileExe) Then
                File.Delete(FileExe)
            End If
        End Try
    End Sub

    Public Shared Function LiveUpdateTemporaneo() As String
        Return Path.Combine(Utx.Globale.Paths.CartellaApp, String.Format("LUP.{0}.{1:HHmmss}.exe", Environment.UserName, Now))
    End Function

    Public Shared Sub AggiornaLiveUpdate()
        Exit Sub
        Dim LiveUpdate As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "LiveUpdate.exe")
        Dim NuovoNome As String = String.Format("UTOLD.{0}.{1}.LiveUpdate.exe", Environment.UserName, Format(Now, "HHmmss"))

        Try
            Using s As New Utx.SettingAgenzia.ConfiguraSede
                '+se il liveupdate non c'è o la versione non coincide con quella on-line
                Dim VersioneOnLine As String = s.VersioneLiveUpdate_0422

                Globale.Log.Info("LiveUpdate: versione on line {0} - data {1}", {VersioneOnLine, Utx.NetFunc.DataModulo(VersioneOnLine)})
                Globale.Log.Info("LiveUpdate: versione locale {0} - data {1}", {Utx.NetFunc.VersioneModulo(LiveUpdate),
                                 Utx.NetFunc.DataModulo(Utx.NetFunc.VersioneModulo(LiveUpdate))})

                If (File.Exists(LiveUpdate) = False) OrElse
                   (Utx.NetFunc.DataModulo(s.VersioneLiveUpdate) > Utx.NetFunc.DataModulo(Utx.NetFunc.VersioneModulo(LiveUpdate))) Then
                    Globale.Log.Info("Ripristino LiveUpdate: la versione non corrisponde a quella on-line...")
                    'se il file esiste lo rinomino
                    If File.Exists(LiveUpdate) Then
                        Try
                            My.Computer.FileSystem.RenameFile(LiveUpdate, NuovoNome)
                        Catch ex As Exception
                            'se non riesco a rinominare fermo tutto e esco
                            Globale.Log.Info(ex.Message)
                            Exit Sub
                        End Try
                    End If
                    '+scarico liveupdate
                    Using wc As New WebClient
                        Globale.Log.Info("scarico liveupdate")
                        wc.Proxy = Utx.Globale.UniProxy.Proxy
                        wc.DownloadFile("http://www.utools.it/Unitools/Update/Versioni/OM/PROD/EXE/LiveUpdate.exe", LiveUpdate)
                        Globale.Log.Info("LiveUpdate ripristinato alla versione {0}", {Utx.NetFunc.VersioneModulo(LiveUpdate)})
                    End Using
                    'prossimo controllo domani mattina
                    Utx.Globale.SettingInterop.AggiungiModifica(Utx.GestioneFlag.TipoFlag.AUTO_LIVE_UPDATE, Format(Today.AddDays(1), "dd/MM/yyyy 07:00:00"))
                    'reset md5 chiave
                    Call New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.EXTRA, "LiveUpdate", Utx.Globale.Paths.CartellaSetting).AggiungiModifica("DB_MD5", "RESET_MD5")
                End If
            End Using

        Catch ex As Exception
            'rollback in caso di errore
            Dim FileRinominato As String = Path.Combine(Utx.Globale.Paths.CartellaApp, NuovoNome)
            If File.Exists(FileRinominato) Then
                File.Delete(LiveUpdate)
                My.Computer.FileSystem.RenameFile(FileRinominato, "LiveUpdate.exe")
            End If
            'segno l'errore
            Globale.Log.Info(ex.Message)
            'riprovo fra 30 minuti
            Utx.Globale.SettingInterop.AggiungiModifica(Utx.GestioneFlag.TipoFlag.AUTO_LIVE_UPDATE, Format(Now.AddMinutes(30), "dd/MM/yyyy HH:mm:ss"))
        End Try
    End Sub

    Public Shared Sub ScaricaMdbPlus()
        Try
            Using wc As New WebClient
                If File.Exists(MdbPlus) Then
                    If MsgBox("Il file esiste già: lo volete aggiornare?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then
                        File.Delete(MdbPlus)
                    End If
                End If
                If File.Exists(MdbPlus) = False Then
                    Globale.Log.Info("scarico MdbPlus")
                    wc.Proxy = Utx.Globale.UniProxy.Proxy
                    wc.DownloadFile("http://www.utools.it/Unitools/Download/MDBPlus.exe", MdbPlus)
                End If
                Process.Start(MdbPlus)
            End Using
        Catch ex As Exception
            Globale.Log.Info(ex.Message)
        End Try
    End Sub

    Public Shared Function MdbPlus()
        Return Path.Combine(Utx.Globale.Paths.CartellaModelli, "MDBPlus.exe")
    End Function

    Public Shared Sub AvviaAssistenza()
        Dim FileExe As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "Assistenza.exe")
        If File.Exists(FileExe) Then
            Process.Start(FileExe)
        Else
            MsgBox("Il file assistenza non è stato trovato.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Shared Sub AvviaComunicazioni(Optional VisualizzaTutti As Boolean = False)
        Exit Sub 'blocco al 20/12/2020
        Dim FileExe As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "Comunicazioni.exe")
        If File.Exists(FileExe) Then
            Dim p As New Process
            p.StartInfo.FileName = FileExe
            If VisualizzaTutti = True Then
                p.StartInfo.Arguments = String.Format("{0};{1}", 0, Utx.Globale.Paths.CartellaTempUtente)
            Else
                p.StartInfo.Arguments = String.Format("{0};{1}", 1, Utx.Globale.Paths.CartellaTempUtente)
            End If
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            p.Start()
        End If
    End Sub

    Public Shared Sub AvviaEstrattore()
        If Utx.NetFunc.ResumeWindow("Unitools - estrattore") = False Then
            Environment.SetEnvironmentVariable("UNITOOLS_WEBSERVICES", "http://www.utools.it/asp/Estrattore/")
            Environment.SetEnvironmentVariable("UNITOOLS_CARTELLA_EXE", Utx.Globale.Paths.CartellaApp)
            Environment.SetEnvironmentVariable("UNITOOLS_CARTELLA_DATI", Utx.Globale.Paths.CartellaUnitoolsRete)
            Environment.SetEnvironmentVariable("UNITOOLS_NOME_UTENTE", Utx.Globale.UtenteCorrente.UniageUser)
            Environment.SetEnvironmentVariable("UNITOOLS_PROFILI_UTENTE", "AGENTE")
            Environment.SetEnvironmentVariable("UNITOOLS_APPDIR", IIf(Utx.FunzioniRete.PcInDominio, "S", "N"))
            Environment.SetEnvironmentVariable("UNITOOLS_RETEATTIVA", Utx.FunzioniRete.ReteAttivaSiNo)

            'imposto proxy
            Environment.SetEnvironmentVariable("UNITOOLS_NOMEPROXY", "proxy.uniage.it")
            Environment.SetEnvironmentVariable("UNITOOLS_PORTAPROXY", "80")

            If Utx.Setting.Ambiente = Utx.Enumerazioni.TipoAmbiente.PP Then
                'qui metto lo user per non avere una stringa vuota ma non serve
                Environment.SetEnvironmentVariable("UNITOOLS_CREDENZIALI", "U;P;D")
            Else
                Environment.SetEnvironmentVariable("UNITOOLS_CREDENZIALI", String.Format("{0};{1};{2}",
                                                                                         Utx.Globale.UtenteCorrente.UniageUser,
                                                                                         Utx.Globale.UtenteCorrente.UniagePw,
                                                                                         Utx.Globale.UtenteCorrente.Dominio))
            End If

            Dim p As New Process
            With p
                .StartInfo.FileName = Path.Combine(Utx.Globale.Paths.CartellaApp, "UniEsplo.exe")
                .StartInfo.Arguments = "2A71E66E775A4e4a9BED88E5810CFB76"
                .StartInfo.WindowStyle = ProcessWindowStyle.Normal
                .Start()
            End With
        End If
    End Sub

    Public Shared Sub AvviaGestioneAssegni()
        Try
            Utx.Globale.Log.Info("Avvio gestione assegni")

            Dim FileExe As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "Assegni.exe")

            If File.Exists(FileExe) = True Then

                'se la finestra è già aperta la ripristino
                If Utx.NetFunc.ResumeWindow("Gestione assegni") = False Then
                    'altrimenti la apro
                    Utx.Globale.Log.Info("imposto le variabili di ambiente")
                    Utx.Globale.ImpostaVariabiliAmbiente()
                    Dim cr As New Utx.Crypto
                    'imposto le variabili di ambiente specifiche per gli assegni e chiamo exe
                    Environment.SetEnvironmentVariable("UNITOOLS_UNIAGE_USER", cr.EncryptData(Utx.Globale.UtenteCorrente.UniageUser))
                    Environment.SetEnvironmentVariable("UNITOOLS_UNIAGE_PW", cr.EncryptData(Utx.Globale.UtenteCorrente.UniagePw))

                    Dim p As New Process
                    With p
                        .StartInfo.FileName = FileExe
                        .StartInfo.WindowStyle = ProcessWindowStyle.Normal
                        .Start()
                    End With
                End If
            Else
                MsgBox("I file per la gestione assegni non sono stati trovati", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Shared Sub AvviaSistema()
        Try
            Dim FileExe As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "ProDoc.exe")
            If File.Exists(FileExe) Then
                Using p As New Process
                    p.StartInfo.FileName = FileExe
                    p.StartInfo.Arguments = String.Format("1=x=x=Unitools=Lmp04771561216={0}={1}", Utx.Globale.UtenteCorrente.UniageUser, Utx.Globale.UtenteCorrente.UniagePw)
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                    p.Start()
                End Using
            End If
        Catch ex As Exception
            MsgBox("Impossibile avviare Sistema", MsgBoxStyle.Exclamation, "Attenzione")
        End Try
    End Sub

    Public Shared Sub AvviaVademecum()
        Try
            Dim FileExe As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "ProDoc.exe")
            If File.Exists(FileExe) Then
                Using p As New Process
                    p.StartInfo.FileName = FileExe
                    p.StartInfo.Arguments = "6=Vademecum Patto Unipol=https://www.assinews.it/Vademecum_UnipolSai/story.html="
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                    p.Start()
                End Using
            End If
        Catch ex As Exception
            MsgBox("Impossibile aprire il vademecum.", MsgBoxStyle.Exclamation, "Attenzione")
        End Try
    End Sub

    Public Shared Sub AvviaBuste()
        Try
            Dim FileExe As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "ProDoc.exe")
            If File.Exists(FileExe) Then
                Using p As New Process
                    p.StartInfo.FileName = FileExe
                    p.StartInfo.Arguments = String.Format("6=File decadali documentazione=file:///{0}=",
                                                          Utx.Globale.Paths.DocFolder(Utx.Enumerazioni.DocFolderType.BUSTE))
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                    p.Start()
                End Using
            End If
        Catch ex As Exception
            MsgBox("Impossibile aprire la cartella buste decadali.", MsgBoxStyle.Exclamation, "Attenzione")
        End Try
    End Sub

    Public Shared Sub AvviaListeQT()
        Try
            Dim FileExe As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "ProDoc.exe")
            If File.Exists(FileExe) Then
                Using p As New Process
                    p.StartInfo.FileName = FileExe
                    p.StartInfo.Arguments = String.Format("6={0}=file:///{1}",
                                                          "Liste quietanzamento",
                                                          Utx.Globale.Paths.DocFolder(Utx.Enumerazioni.DocFolderType.LISTE_QT))
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                    p.Start()
                End Using
            End If
        Catch ex As Exception
            MsgBox("Impossibile aprire la cartella delle liste di quietanzamento.", MsgBoxStyle.Exclamation, "Attenzione")
        End Try
    End Sub

    Public Shared Sub AvviaQuotatore(Optional Cf As String = "")
        Try
            Dim FileExe As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "UniQuota.exe")
            If File.Exists(FileExe) Then
                Environment.SetEnvironmentVariable("UNITOOLS_CARTELLA_EXE", Utx.Globale.Paths.CartellaApp)
                Environment.SetEnvironmentVariable("UNITOOLS_CARTELLA_DATI", Utx.Globale.Paths.CartellaUnitoolsRete)
                Environment.SetEnvironmentVariable("UNITOOLS_APPDIR", IIf(Utx.FunzioniRete.PcInDominio, "S", "N"))
                Environment.SetEnvironmentVariable("UNITOOLS_RETEATTIVA", Utx.FunzioniRete.ReteAttivaSiNo)
                Environment.SetEnvironmentVariable("UNITOOLS_EMAIL_MITTENTE", Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.EMAIL_PREDEFINITE, ""))
                Environment.SetEnvironmentVariable("UNITOOLS_EMAIL_SMTP", LeggiSmtp)
                Environment.SetEnvironmentVariable("UNITOOLS_POSTINO_GUID", Utx.Funzioni_OLD_UT.Guid)
                'eventuale cf del cliente
                Environment.SetEnvironmentVariable("UNITOOLS_CLIENTE_CODICEFISCALE", Cf)

                If Utx.Setting.Ambiente = Utx.Enumerazioni.TipoAmbiente.PP Then
                    'qui metto lo user per non avere una stringa vuota ma non serve
                    Environment.SetEnvironmentVariable("UNITOOLS_CREDENZIALI", "U;P;D")
                Else
                    Environment.SetEnvironmentVariable("UNITOOLS_CREDENZIALI", String.Format("{0};{1};{2}",
                                                                                             Utx.Globale.UtenteCorrente.UniageUser,
                                                                                             Utx.Globale.UtenteCorrente.UniagePw,
                                                                                             Utx.Globale.UtenteCorrente.Dominio))
                End If

                Using p As New Process
                    p.StartInfo.FileName = FileExe
                    p.StartInfo.Arguments = "62429b55-f1b2-427d-a195-2df7a2303436"
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                    p.Start()
                End Using
            End If
        Catch ex As Exception
            MsgBox("Impossibile avviare il quotatore.", MsgBoxStyle.Exclamation, "Attenzione")
        End Try
    End Sub

    Public Shared Sub LinkUtili()
        Try
            Dim FileExe As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "ProDoc.exe")
            If File.Exists(FileExe) Then
                Using p As New Process
                    p.StartInfo.FileName = FileExe
                    p.StartInfo.Arguments = "3=x=x="
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                    p.Start()
                End Using
            End If
        Catch ex As Exception
            'non fare niente
        End Try
    End Sub

    Public Shared Function AvviaEvidenze(Optional TipoDoc As String = "",
                                    Optional NumeroDoc As String = "",
                                    Optional Cf As String = "") As String
        Try
            Dim FileExe As String
            FileExe = Path.Combine(Utx.Globale.Paths.CartellaApp, "Unidocs.exe")

            If File.Exists(FileExe) Then
                If Utx.NetFunc.ResumeWindow("Unitools - evidenze") = False Then
                    Utx.Globale.ImpostaVariabiliAmbiente()
                    Environment.SetEnvironmentVariable("UNITOOLS_CARTELLA_EXE", Utx.Globale.Paths.CartellaApp)
                    Environment.SetEnvironmentVariable("UNITOOLS_CARTELLA_DATI", Utx.Globale.Paths.CartellaDati)
                    Environment.SetEnvironmentVariable("UNITOOLS_CARTELLA_MODELLI", Utx.Globale.Paths.CartellaModelli)
                    Environment.SetEnvironmentVariable("UNITOOLS_CARTELLA_SETTING", Utx.Globale.Paths.CartellaSetting)
                    Environment.SetEnvironmentVariable("UNITOOLS_RETEATTIVA", Utx.FunzioniRete.ReteAttivaSiNo)
                    Environment.SetEnvironmentVariable("UNITOOLS_EMAIL_MITTENTE", Utx.Globale.UtenteCorrente.MittentePredefinito)
                    Environment.SetEnvironmentVariable("UNITOOLS_EMAIL_SMTP", LeggiSmtp)
                    Environment.SetEnvironmentVariable("UNITOOLS_POSTINO_GUID", Utx.Funzioni_OLD_UT.Guid)
                    'eventuale cf del cliente
                    Environment.SetEnvironmentVariable("UNITOOLS_CLIENTE_CODICEFISCALE", Cf)
                    Environment.SetEnvironmentVariable("UNITOOLS_UTENTE_UNIAGE", Utx.Globale.UtenteCorrente.UniageUser)

                    If Utx.Setting.Ambiente = Enumerazioni.TipoAmbiente.PP Then
                        Environment.SetEnvironmentVariable("UNITOOLS_CREDENZIALI", ";")
                    Else
                        Environment.SetEnvironmentVariable("UNITOOLS_CREDENZIALI", String.Format("{0};{1}",
                                                                                                 Utx.Globale.UtenteCorrente.UniageUser,
                                                                                                 Utx.Globale.UtenteCorrente.UniagePw))
                    End If

                    Dim cartellaDocs As String = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "docs").ToString()
                    Directory.CreateDirectory(cartellaDocs)
                    Dim sessionid As String = Now.Ticks
                    Dim filetocheck As String = Path.Combine(cartellaDocs, "EVIDENZE_REQUEST_" & sessionid & ".xml")

                    Environment.SetEnvironmentVariable("UNITOOLS_CARTELLA_DOCS", cartellaDocs)
                    Environment.SetEnvironmentVariable("UNITOOLS_SESSIONID", sessionid)

                    Dim p As New Process
                    With p
                        .StartInfo.FileName = FileExe
                        .StartInfo.Arguments = String.Format("2A71E66E775A4e4a9BED88E5810CFB76;{0};{1}", TipoDoc, NumeroDoc)
                        .StartInfo.WindowStyle = ProcessWindowStyle.Normal
                        .Start()
                    End With
                    Return filetocheck
                End If
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
        Return Nothing
    End Function

    Public Shared Function LeggiSmtp() As String
        Try
            Dim wrapper As New Utx.Crypto("19011957")
            Dim SmtpSetting As String = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.SMTP, "")

            If String.IsNullOrEmpty(SmtpSetting) = False Then
                SmtpSetting = wrapper.DecryptData(SmtpSetting) 'decripto i dati
                If SmtpSetting.ToLower.Contains("errore") Then 'in caso di errore resetto
                    Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.SMTP, wrapper.EncryptData(";;;;"))
                    Return ""
                End If
            End If
            Return SmtpSetting
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return ""
        End Try
    End Function

    Public Shared Sub AvviaChiusuraCassa()
        Try
#If Not Debug Then
            If Utx.Setting.Ambiente = Enumerazioni.TipoAmbiente.PP Then
                MsgBox("Per utilizzare la chiusura cassa è necessario essere connessi al disco di rete.", MsgBoxStyle.Information)
                Exit Sub
            End If
#End If
            Dim FileExe As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "ChiusuraCassa.exe")

            If File.Exists(FileExe) Then
                If Utx.NetFunc.ResumeWindow("Chiusura cassa") = False Then
                    'funzione assegni non più gestita, variabile CASSA_CARTELLA_ASSEGNI non necessaria
                    Environment.SetEnvironmentVariable("UNITOOLS_AMBIENTE", Utx.Setting.Ambiente.ToString)

                    Dim p As New Process
                    With p
                        .StartInfo.FileName = FileExe
                        .StartInfo.Arguments = String.Format("{0};{1}", Utx.Funzioni_OLD_UT.Guid, Utx.Globale.Paths.CartellaTempUtente)
                        .StartInfo.WindowStyle = ProcessWindowStyle.Normal
                        .Start()
                    End With
                End If
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Shared Sub AvviaMappa(Indirizzo As String,
                                 Citta As String,
                                 Stato As String,
                                 Cap As String)
        Try
            Dim FileExe As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "Mappe.exe")

            If File.Exists(FileExe) Then
                Dim p As New Process
                With p
                    .StartInfo.FileName = FileExe
                    .StartInfo.Arguments = String.Format("{0};{1};{2};{3};{4}",
                                                         "d12ee614-6eec-4e1e-97a0-86f0c72b0faa",
                                                         Indirizzo, Citta, Stato, Cap)
                    .StartInfo.WindowStyle = ProcessWindowStyle.Normal
                    .Start()
                End With
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Shared Function AvviaBackupArchivi(Agenzie As String,
                                              Optional VisualizzaNotifica As Boolean = False,
                                              Optional Modo As String = "B") As Boolean
        'B modo backup
        'R modo ripristino manuale
        'le agenzie vanno passate con separatore /
        Try
            If Utx.NetFunc.AltraIstanza("BackupArchivi", ProcessoAvviato:=False) = False Then

                Utx.Globale.Log.Info(String.Format("Avvio backup in modalità {0}", Modo))

                Dim FileExe As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "BackupArchivi.exe")

                If File.Exists(FileExe) Then

                    Using p As New Process
                        p.StartInfo.FileName = FileExe
                        p.StartInfo.Arguments = String.Format("{0};{1};{2}",
                                                              Modo,
                                                              VisualizzaNotifica,
                                                              Agenzie.Replace(";", "/"))
                        p.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                        p.Start()
                    End Using
                End If
                Return True
            Else
                Utx.Globale.Log.Info("Altra instanza backup in esecuzione")
                Return False
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return False
        End Try
    End Function

    Public Shared Sub AvviaUnicoop(Cliente As String,
                                   Ramo As Integer,
                                   Polizza As Integer,
                                   PremioAnnuo As Double,
                                   DataScadenza As Date)
        Try
            Environment.SetEnvironmentVariable("UNICOOP_ID", "2A71E66E775A4e4a9BED88E5810CFB76")
            Environment.SetEnvironmentVariable("UNICOOP_PATHDB", Utx.ConnessioniDb.PathMdb(ConnessioniDb.Db.UNICOOP))
            Environment.SetEnvironmentVariable("UNICOOP_AGENZIA", Utx.Globale.AgenziaRichiesta.CodiceAgenzia)
            Environment.SetEnvironmentVariable("UNICOOP_CLIENTE", Cliente)
            Environment.SetEnvironmentVariable("UNICOOP_RAMO", Ramo)
            Environment.SetEnvironmentVariable("UNICOOP_POLIZZA", Polizza)
            Environment.SetEnvironmentVariable("UNICOOP_TOTALEPREMIOANNUO", PremioAnnuo)
            Environment.SetEnvironmentVariable("UNICOOP_DATASCADENZA", DataScadenza)

            Using p As New Process
                p.StartInfo.FileName = Path.Combine(Utx.Globale.Paths.CartellaApp, "Unicoop.exe")
                p.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                p.StartInfo.Arguments = ""
                p.Start()
            End Using

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub
End Class
