Imports System.Data.OleDb

Public Class FileIntoDatabase
    'Public Event Info(valore As String)
    Public Const TIPORECORD_TITOLI = "21,22,23,24,25,26,27,28,29,30,41"
    Public Const TIPORECORD_CLIENTI = "00,16,17,10,18,19"
    Public Const TIPORECORD_POLIZZE = "01,02,05,06,07,08,14,15,70"
    Public Const TIPORECORD_SINISTRI = "89,90,91,92,99"
    Public Const TIPORECORD_INCARICHI = "93"
    Public Const TIPORECORD_PAGAMENTI = "95"
    Public Const TIPORECORD_PRIMANOTA = "42"
    Public Const TIPORECORD_DECODIFICA = "97,98,40,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,78,79,80,81,82"

    Private mLunghezzaTotaleDaImportare As Long
    Private mByteLetti As Long

    Public Shared Function GruppiTipiRecord() As Dictionary(Of String, String)
        Dim list As New Dictionary(Of String, String)
        list.Add(TIPORECORD_TITOLI, "Titoli")
        list.Add(TIPORECORD_CLIENTI, "Clienti")
        list.Add(TIPORECORD_POLIZZE, "Polizze")
        list.Add(TIPORECORD_SINISTRI, "Sinistri")
        list.Add(TIPORECORD_INCARICHI, "Incarichi")
        list.Add(TIPORECORD_PAGAMENTI, "Pagamenti")
        list.Add(TIPORECORD_PRIMANOTA, "Prima nota")
        list.Add(TIPORECORD_DECODIFICA, "Tabelle di sistema")
        Return list
    End Function

    Public Sub New()
        If Utx.Globale.Paths Is Nothing Then
            'solo per i test
            Utx.Globale.IdApp(System.Text.Encoding.UTF8.GetString(New Byte() {57, 60, 88, 93, 65, 58, 71}))
            Utx.Globale.Paths = New Utx.ApplicationPath
            Utx.Globale.Paths.Inizializza("C:\ApplicazioniDirezione\UTW", "X", "M")

            Utx.Globale.UtenteCorrente = New Utx.Utente
            Utx.Globale.SettingGlobale = New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.GLOBALE)
            Utx.Globale.SettingInterop = New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.INTEROP)
            'Utx.Globale.UniProxy = New Utx.Proxy()
            Utx.Globale.ProfiloEnteGestore = New Utx.EnteGestore
            Utx.Globale.AgenziaRichiesta = New Utx.Agenzia(CInt(Utx.Globale.ProfiloEnteGestore.AgenziaMadre))
        End If
    End Sub

    Public Sub ImportaTutto(Optional DataInizioImportazione As Date = Nothing,
                            Optional DataFineImportazione As Date = Nothing,
                            Optional TipiRecordsDaImportare As String = Nothing,
                            Optional CodiceAgenziaDaImportare As String = Nothing)
        Dim CurrentThreadPriority = Threading.Thread.CurrentThread.Priority
        Threading.Thread.CurrentThread.Priority = Threading.ThreadPriority.Lowest
        Dim logs As New List(Of String)
        Dim OmniaLog = New Utx.ApplicationLog("OmniaImport", Nothing, Nothing, False, True)
        Globale.OmniaLog = New Utx.ApplicationLog("OmniaImportProcess", Nothing, Nothing, False, True)
        logs.Add(OmniaLog.FullPathLogFile)
        Globale.ArrestaImportazione = False
        Try
            Globale.NotificaOpen()
            Globale.NotificaShow("Creo file riepilogativi ...")
            Cumulatore.getInstance().CreaFiles()

            Globale.NotificaShow("Importazione dati ...")
            Globale.OmniaLog.Info("Importazione dati inizio")

            Globale.Report = New Report
            Globale.InviaEmailAssistenza = False

            Dim agenziaMadre As New Utx.AgenziaOmnia()

            OmniaLog.Info("#######################################")
            OmniaLog.Info("#######################################")
            OmniaLog.Info("Inizio processo Importazione dati omnia")
            OmniaLog.Info("Computer: " & Environment.MachineName)
            OmniaLog.Info("User PC : " & Environment.UserName)
            With GetType(FileIntoDatabase).Assembly.GetName
                OmniaLog.Info("Modulo  : " & .Name)
                OmniaLog.Info("Versione: " & .Version.ToString)
            End With
            OmniaLog.Info("Ente gestore")

            OmniaLog.Info("    Compagnia     : " & agenziaMadre.Compagnia)
            OmniaLog.Info("    Agenzie Madre : " & agenziaMadre.AgenziaMadre)
            OmniaLog.Info("    Sede          : " & agenziaMadre.CodiceSede)

            CartellaServerFtp = String.Format("ftp://1{0}-00-00/omnia/casella/download/", agenziaMadre.AgenziaMadre)

            Dim agenzieCollegate = agenziaMadre.AgenzieCollegate

            OmniaLog.Info("Agenzie collegate : " & agenzieCollegate.Count)

            If Not String.IsNullOrEmpty(CodiceAgenziaDaImportare) Then
                If agenzieCollegate.Contains(CodiceAgenziaDaImportare) Then
                    agenzieCollegate.Clear()
                    agenzieCollegate.Add(CodiceAgenziaDaImportare)
                End If
            End If

            For Each CodiceAgenziaFiglia In agenzieCollegate
                Try
                    If Globale.ArrestaImportazione = True Then Exit For
                    Globale.Log = New Utx.ApplicationLog(CodiceAgenziaFiglia & "_OmniaImport", Nothing, Nothing, True, True)
                    logs.Add(Globale.Log.FullPathLogFile)
                    Globale.Log.Info("==========================================================================")
                    Globale.Log.Info("Leggo configurazione agenzia " & CodiceAgenziaFiglia)
                    Globale.NotificaShow("Leggo informazioni archivi agenzia " & CodiceAgenziaFiglia)

#If DEBUG Then
                    'Dim Test As New Utx.AgenziaFigliaOmnia("39464", "00")
#End If
                    Dim agenziaFiglia As New Utx.AgenziaFigliaOmnia(CodiceAgenziaFiglia, agenziaMadre.CodiceSede)
                    '#If DEBUG Then
                    '                        If PCSTEFANO Or PCGUIDO Then
                    '                            agenziaFiglia = New Utx.AgenziaFigliaOmnia(CodiceAgenziaFiglia, "00")
                    '                        Else
                    '                            agenziaFiglia = New Utx.AgenziaFigliaOmnia(CodiceAgenziaFiglia, agenziaMadre.CodiceSede)
                    '                        End If
                    '#Else
                    '                    agenziaFiglia = New Utx.AgenziaFigliaOmnia(CodiceAgenziaFiglia, agenziaMadre.CodiceSede)
                    '#End If

                    Globale.Log.Info("consenso importazione: " & agenziaFiglia.ConsensoImportazione)

                    'CONVERSIONE FILE DISATTIVATA IL 14/02/2024
                    'Dim convertiFile As ConvertiFileSinistri

                    If agenziaFiglia.ConsensoImportazione = True Then
                        'Try
                        '    convertiFile = New ConvertiFileSinistri(agenziaFiglia)
                        '    convertiFile.ConvertiSinistri()
                        'Catch ex As Exception
                        'End Try

                        Dim archivi As New Archivi(agenziaMadre, agenziaFiglia, True)
                        Storico.SvecchiaDbUno(agenziaFiglia)

                        If DataInizioImportazione <> Nothing Then
                            archivi.NomeSimbolicoInizioImportazione = String.Format("MA{0}{1}{2}.000", agenziaMadre.Compagnia, CodiceAgenziaFiglia, DataInizioImportazione.ToString("yyMMdd"))
                            If DataFineImportazione <> Nothing Then
                                archivi.NomeSimbolicoFineImportazione = String.Format("MA{0}{1}{2}.999", agenziaMadre.Compagnia, CodiceAgenziaFiglia, DataFineImportazione.ToString("yyMMdd"))
                            Else
                                archivi.NomeSimbolicoFineImportazione = String.Format("MA{0}{1}991231.999", agenziaMadre.Compagnia, CodiceAgenziaFiglia)
                            End If
                        End If
                        If TipiRecordsDaImportare <> Nothing Then
                            archivi.TipiRecordsDaImportare = TipiRecordsDaImportare
                            Globale.Log.Info("tipi records da importare: " & TipiRecordsDaImportare)
                        End If
                        archivi.Elabora() 'elabora: download, importa e archivia i files
                    End If
                Catch ex As Exception
                    OmniaLog.Info(ex.Message)
                    Globale.OmniaLog.Info("Errore: " & ex.Message)
                End Try
            Next

            OmniaLog.Info(Globale.Report.ToString)
        Catch ex As Exception
            OmniaLog.Info(ex.Message)
            OmniaLog.Info(ex.ToString)
            Globale.NotificaShow("Errore: " & ex.Message)
            Globale.OmniaLog.Info("Errore: " & ex.Message)
        End Try
        Globale.OmniaLog.Info("Importazione dati fine")

        If Globale.InviaEmailAssistenza = True Then
            Try
                Dim sb As New Text.StringBuilder
                With sb
                    .AppendLine(String.Format("Agenzia madre: {0} - {1}", Utx.Globale.ProfiloEnteGestore.AgenziaMadre, Utx.Globale.ProfiloEnteGestore.Localita))
                    .AppendLine(String.Format("Versione: {0}", Windows.Forms.Application.ProductVersion))
                    .AppendLine(String.Format("Pc: {0}", Environment.MachineName))
                    .AppendLine(String.Format("Utente pc: {0}", Environment.UserName))
                    '.AppendLine(String.Format("Utente uniage: {0}", Ut.Globale.UtenteCorrente.UniageUser))
                End With

                Dim p As New UniCom.Postino
                With p
                    .Oggetto = String.Format("Errore in importazione dati. Agenzia {0} - {1}", Utx.Globale.ProfiloEnteGestore.AgenziaMadre, Utx.Globale.ProfiloEnteGestore.Localita)
                    .Testo = sb.ToString

                    Dim logzipfile = IO.Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "logs.zip")

                    If IO.File.Exists(logzipfile) Then
                        IO.File.Delete(logzipfile)
                    End If

                    If Utx.LibreriaZip.SevenZip.ZipFile(logs.ToArray(), logzipfile) Then
                        .AddAllegato(logzipfile)
                    Else
                        For Each l In logs
                            .AddAllegato(l)
                        Next
                    End If

                    .EmailAutomatica = True
                    .Mittente = UniCom.Postino.MittenteAgenzia
                    .InviaA.Add("guidolampo@tiscali.it")
                    .InviaMail()

                    If IO.File.Exists(logzipfile) Then
                        IO.File.Delete(logzipfile)
                    End If
                End With

            Catch ex As Exception
                OmniaLog.Info(ex)
            End Try
        End If

        Globale.NotificaClose(False) '(Globale.Report.NumeroFileImportati > 0)

        'PubblicaTTYCreo()
        Threading.Thread.CurrentThread.Priority = CurrentThreadPriority
    End Sub

    'Public Sub PubblicaTTYCreo()
    '    Dim TTY As New Utx.TTYCreo(Utx.TTYCreo.TipoFile.OMNIA)
    '    Dim dataInizio As Date = TTY.InizioInvioOmnia

    '    For Each file In IO.Directory.GetDirectories(Utx.Globale.Paths.CartellaArchivioDati)
    '        Dim codiceagenzia As String = IO.Path.GetFileName(file)
    '        If codiceagenzia Like "#####" AndAlso codiceagenzia = "00000" Then 'bloccato il 7/3/2018
    '            Dim agenziaFiglia As New Utx.AgenziaFigliaOmnia(codiceagenzia)

    '            For Each f As String In IO.Directory.GetFiles(agenziaFiglia.Cartelle.ArchivioFileOmnia)

    '                Dim nomefile As String = IO.Path.GetFileName(f)

    '                If dataInizio < Date.ParseExact(Mid(nomefile, 9, 6), "yyMMdd", Nothing) Then
    '                    TTY.ListaUpload.Add(f)
    '                End If
    '            Next
    '        End If
    '    Next

    '    TTY.Upload()
    'End Sub
End Class
