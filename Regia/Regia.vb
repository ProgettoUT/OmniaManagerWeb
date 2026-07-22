Imports Regista
Imports System.ComponentModel
Imports System.IO

Module Regia
    Private UnitoolsListener As ListenerFile
    Private CentralinoListener As ListenerTcp
    Private Notifica As Utx.FormNotifica
    Friend WithEvents IconaNotifica As NotifyIcon

    Public Sub Main()
        Utx.ApplicationLog.LivelloLog = Utx.ApplicationLog.Livello.TRACE
        Utx.Globale.IdApp(System.Text.Encoding.UTF8.GetString(New Byte() {57, 60, 88, 93, 65, 58, 71}))
        Utx.Globale.Paths = New Utx.ApplicationPath
#If DEBUG Then
        Utx.Globale.Paths.Inizializza("C:\ApplicazioniDirezione\UT", "U", "M")
#Else
        Utx.Globale.Paths.Inizializza("C:\ApplicazioniDirezione\Unitools", "U", "M")
#End If
        Notifica = New Utx.FormNotifica
        With Notifica
            .ColoreSfondo = Drawing.Color.WhiteSmoke
            .ColoreBordo = Utx.AppColor.RossoScuro
            .LabelMessaggio.Font = Utx.AppFont.Bold
            .Opacity = 1
            .Text = ""
        End With

        ControlloSetting() 

        IconaNotifica = New NotifyIcon()
        With IconaNotifica
            .Icon = Risorse.Immagini.Icon("unitools")
            .Text = "Regia centralino unitools"
            .Visible = True
        End With

        ListenerFile.SvuotaCartellaMessagi()

        'Da verificare se i client siano raggiungibili o meno
        Dim timer As System.Threading.Timer = New System.Threading.Timer(AddressOf CheckClients, Nothing, 120 * 1000, 120 * 1000)

        UnitoolsListener = New ListenerFile(ListenerTcp.PORTA_BASE)
        UnitoolsListener.StartListenAsync()

        CentralinoListener = New ListenerTcp(ListenerTcp.PORTA_BASE)
        CentralinoListener.StartListen()
        IconaNotifica.Dispose()
        End
    End Sub

    Private Sub CheckClients(state As Object)
        ControlloSetting()

        Dim elencoClient(Centralino.ClientUnitoolsList.Count - 1) As ClientUnitools

        Centralino.ClientUnitoolsList.CopyTo(elencoClient)

        For Each client In elencoClient
            If (Now.Ticks - client.UltimaConnessione) > 200 * 10000000 Then
                Cancellami.GetInstance.performRequest(New Richiesta(String.Format("GET Cancellami?{0}={1} HTTP/1.1", ClientUnitools.KEY_UTENTE, client.Utente)), New Risposta())
                ListenerTcp.Log.Debug("Utente non connesso: " & client.Utente)
                ListenerTcp.Log.Debug("Numero unitools connessi = " & Centralino.ClientUnitoolsList.Count)
            End If
        Next
    End Sub

    Private Function ControlloSetting() As Boolean
        Try
            Utx.Globale.Log.Info("Controllo setting")
            If Directory.Exists(Utx.Globale.Paths.CartellaCentralinoRete) Then
                'mi copio il setting
                CopiaSetting()
                Return True
            Else
                If ConnettiEmme() = True Then
                    Notifica.Show()
                    Notifica.Messaggio = String.Format("Regia centralino attiva su{0}{1}", Environment.NewLine, Utx.Globale.Paths.CartellaCentralinoRete)
                    Return True
                Else
                    Notifica.Show()
                    Notifica.Messaggio = "Cartella di interscambio non disponibile"
                    Return False
                End If
            End If
            Notifica.Chiudi()
        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
            Return False
        End Try
    End Function

    Private Function ConnettiEmme() As Boolean
        Try
            Utx.Globale.Log.Info("Connetti emme")

            'connetti al server
            With Notifica
                .Show()
                .Messaggio = String.Format("Connessione ad {0}...", Utx.Globale.Paths.UnitaDatiRete)
            End With

            Utx.Globale.Log.Info(String.Format("Unità di rete: {0}", Utx.Globale.Paths.UnitaDatiRete))

            If New DriveInfo(Utx.Globale.Paths.UnitaDatiRete).IsReady = False Then
                'tento di connettere
                If NetUse() = True Then
                    Utx.Globale.Log.Info("Unità di rete pronta")
                    Notifica.Messaggio = "Connessione riuscita correttamente"
                    Notifica.Chiudi(5)
                    Return True
                Else
                    Utx.Globale.Log.Info("Unità di rete NON pronta")
                    Notifica.Messaggio = "Connessione non riuscita"
                    Notifica.Chiudi(5)
                    Return False
                End If
            Else
                Return True
            End If

        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
            Return False
        End Try
    End Function

    Private Function NetUse() As Boolean
        Try
            Utx.Globale.Log.Info("Net use")
            'inizializzo il setting globale
            Try
                Utx.Globale.SettingGlobale = New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.GLOBALE)
                If Utx.Globale.SettingGlobale.EsisteSetting = False Then
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try

            Dim IP As String = Utx.Globale.SettingGlobale.LeggiValore(Utx.GestioneFlag.TipoFlag.IP_SERVER, "")

            'se IP non impostato in configura
            If String.IsNullOrEmpty(IP) Then
                Utx.Globale.Log.Info("Impostare il Nome/Ip dell'unità di rete")
                Return False
            End If

            'leggo le utenze
            For Each c As Utx.Credenziali In Utx.Utente.ListaUtenzePassword(FileSettingLocale)
                Utx.Globale.Log.Info(String.Format("NET USE M: \\{0}\Direzione /user:uniage\{1} *** /persistent:yes", IP, c.User))
                'tento la connessione di M: - disconnetto eventuali connessioni precedenti e riconnetto
                Shell("NET USE M: /delete /yes", AppWinStyle.Hide, True, 10000)
#If DEBUG Then
                Dim ComandoNetUse As String = String.Format("NET USE M: \\X390-GUIDO\Direzione /user:guidolampo@tiscali.it Elpampa1991 /persistent:yes", IP, InputBox("password"))
#Else
                Dim ComandoNetUse As String = String.Format("NET USE M: \\{0}\Direzione /user:uniage\{1} {2} /persistent:yes", IP, c.User, c.Password)
#End If

                Shell(ComandoNetUse, AppWinStyle.Hide, True, 10000)

                If New DriveInfo("M").IsReady Then
                    Return True
                End If
            Next
            'non sono riuscito a connettermi
            Return False

        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
            Return False
        End Try
    End Function

    Private Sub CopiaSetting()
#If Not Debug Then
        Try
            Utx.Globale.Log.Info("Copia setting")
            File.Copy(FileSettingRete, FileSettingLocale, True)
        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
        End Try
#End If
    End Sub

    Private Function FileSettingLocale() As String
        Return Path.Combine(Utx.Globale.Paths.CartellaSetting, "Unitools.Setting.xml")
    End Function

    Private Function FileSettingRete() As String
#If DEBUG Then
        Return "U:\UT\Modelli\Setting\Unitools.Setting.xml"
#Else
        Return "M:\Unitools\Modelli\Setting\Unitools.Setting.xml"
#End If
    End Function
End Module
