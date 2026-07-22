Imports System.IO

Module Main

    Private Log As Utx.ApplicationLog
    Private TipoChiamata As String
    Private Agenzia As Integer

    Sub Main()
        Try
            Utx.Globale.IdApp(System.Text.Encoding.UTF8.GetString(New Byte() {57, 60, 88, 93, 65, 58, 71}))
            Utx.Globale.Init()

            Log = New Utx.ApplicationLog("ASLoader")

            Dim di As New DriveInfo("M")
            If di.IsReady = False Then
                MsgBox("Disco M non disponibile", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Exit Sub
            End If

            Log.Info("Avvio ASLoader")
            Dim Parametri As String = Command()
            If String.IsNullOrEmpty(Parametri) Then
                If Environment.UserName.ToUpper Like "######[A-Z,0-9][A-Z,0-9]" Then
                    Parametri = String.Format("DIR,{0}", Mid(Environment.UserName, 2, 5))
                End If
            End If

            Log.Info("Parametri: {0}", {Parametri})

            'analisi dei parametri. bisogna passare o niente oppure PP,codice agenzia
            Select Case Parametri.Split(",").GetUpperBound(0)
                Case < 1 'ho passato solo un parametro
                    MsgBox("Numero di parametri errato.", MsgBoxStyle.Critical, Utx.Globale.TitoloApp)
                    Exit Sub

                Case 1
                    TipoChiamata = Parametri.Split(",")(0)
                    Agenzia = Parametri.Split(",")(1)

                    If TipoChiamata = "PP" And Agenzia <= 0 Then
                        MsgBox("Numero di parametri errato.", MsgBoxStyle.Critical, Utx.Globale.TitoloApp)
                        Exit Sub
                    End If
            End Select

            If Utx.NetFunc.AltraIstanzaUtente("Assegni", ProcessoAvviato:=True) = True Then
                MsgBox("Scansione assegni è già aperta per l'utente corrente.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
                End
            End If

            Log.Info("Tipo ambiente: {0} - Agenzia: {1}", {TipoChiamata, Agenzia})
            Log.Info()

            AvviaAssegni()
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub AvviaAssegni()
        Try
            Log.Info("Analisi licenza")

            'se la chiamata è DIR l'impostazione del codice agenzia non serve (la prendo dal pc)
            If TipoChiamata = "PP" Then
                Dim FileLicenza As String = Path.Combine(Utx.Globale.Paths.CartellaSettingRete, Format(Agenzia, "00000") + ".LIC")
                Log.Info("File licenza utilizzato: {0}", {FileLicenza})

                If File.Exists(FileLicenza) = False Then
                    MsgBox("Licenza inesistente o parametri non compatibili", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                    Exit Sub
                End If
            End If

            Log.Info("Imposto variabili di ambiente")
            Environment.SetEnvironmentVariable("UNITOOLS_AGENZIA_MADRE", Format(Agenzia, "00000"))
            Environment.SetEnvironmentVariable("UNITOOLS_AGENZIA_RICHIESTA", Format(Agenzia, "00000"))
            Environment.SetEnvironmentVariable("UNITOOLS_AMBIENTE", TipoChiamata)
            Environment.SetEnvironmentVariable("UNITOOLS_ASSEGNI_ID", "Uniarea." + Format(Now, "yyyy-MM.dddd"))
            Environment.SetEnvironmentVariable("UNITOOLS_STRINGA_CONNESSIONE_DB_CASSA",
                                           String.Format("Provider = Microsoft.Jet.OLEDB.4.0; User Id=; Password=;" +
                                                         "Data Source={0}\{1:00000}\Cassa.mdb", Utx.Globale.Paths.CartellaDati, Agenzia))

            Log.Info("Connessione: {0}", {Environment.GetEnvironmentVariable("UNITOOLS_STRINGA_CONNESSIONE_DB_CASSA")})

            'analisi ini
            Dim FileIni As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "ASLoader.ini")
            Dim FileExe As String = ""
            If File.Exists(FileIni) Then
                Try
                    FileExe = File.ReadAllText(FileIni)
                Catch ex As Exception
                    Log.Info(ex)
                End Try
            End If
            If String.IsNullOrEmpty(FileExe) Then
                FileExe = "Assegni.exe"
            End If
            'avvio il file exe
            Using p As New Process
                p.StartInfo.FileName = Path.Combine(Utx.Globale.Paths.CartellaApp, FileExe)
                Log.Info("Avvio {0}", {p.StartInfo.FileName})
                p.Start()
            End Using

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub
End Module
