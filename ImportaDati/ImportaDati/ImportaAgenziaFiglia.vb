Imports System.IO
Imports System.Data.OleDb
Imports System.Text

Public Class ImportaAgenziaFiglia

    Private mAgenziaFiglia As Utx.AgenziaFigliaOmnia

    Sub New(AgenziaFiglia As Utx.AgenziaFigliaOmnia)
        Try
            mAgenziaFiglia = AgenziaFiglia

            'se il db arrivi esiste lo cancello
            File.Delete(mAgenziaFiglia.Cartelle.DatabaseArrivi)
            'poi lo copio vuoto dal modello in locale
            File.Copy(Path.Combine(Utx.Globale.Paths.CartellaModelli, "DbUt.mdb"), mAgenziaFiglia.Cartelle.DatabaseArrivi)

            'init log
            Globale.Log = New Utx.ApplicationLog("DLDati.log",
                                                CartellaLog:=mAgenziaFiglia.Cartelle.CartellaArriviLocaleAgenziaDL,
                                                Sovrascrivi:=True)
            Globale.LogErrori = New Utx.ApplicationLog("DLErrori.log",
                                                      CartellaLog:=mAgenziaFiglia.Cartelle.CartellaArriviLocaleAgenziaDL,
                                                      Sovrascrivi:=True)
            InitLog()

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        End Try
    End Sub

    Public Sub Importa()
        Try
            Globale.Log.Info(String.Format("Importazione dati per codice agenzia {0}", mAgenziaFiglia.CodiceAgenziaFiglia))

            Using cnArrivi As New OleDbConnection(mAgenziaFiglia.ConnectionStringArrivi)
                cnArrivi.Open()
                'assegno la connessione all'agenzia figlia così da utilizzarla facilmente nel codice
                mAgenziaFiglia.Connessione = cnArrivi

                'per ogni record di configurazione della figlia
                For Each Rec As Utx.RecordConfigOmnia In mAgenziaFiglia.Config
                    'importa i dati dell'agenzia collegata
                    If Rec.Unisalute = False Then
                        ImportaDatiAgenziaCollegata(Rec)
                    End If
                Next

                'tab di notifica
                If SonoArrivatiDati() Then
                    'scrivo il profilo
                    ScriviProfilo()
                    'crea il tab di notifica
                    Globale.Notifica.TabPages.Add(New TabNotifica(mAgenziaFiglia.CodiceAgenziaFiglia, mAgenziaFiglia.Connessione).NotificaDati)
                    'tab log
                    Globale.Notifica.Controls.Add(New TabLog(mAgenziaFiglia.CodiceAgenziaFiglia).NotificaLog)

                    LogRiepilogo()

                    'invio il file al server
                    Utx.OmWeb.InviaFile(mAgenziaFiglia.CodiceAgenziaFiglia,
                                        mAgenziaFiglia.Cartelle.DatabaseArrivi,
                                        Utx.EventiOMW.TipoEvento.CONSOLIDA_DOWNLOAD_AGENZIE.ToString, False)
                End If
            End Using

            'invio eventuale notifica
            If File.Exists(Globale.LogErrori.FullPathLogFile) Then InviaEmailNotifica()

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        Finally
            Globale.Log.Info(String.Format("Importazione dati per codice agenzia {0} completata", mAgenziaFiglia))
        End Try
    End Sub

    Private Sub ImportaDatiAgenziaCollegata(ByRef RecordConfig As Utx.RecordConfigOmnia)
        Try
            'svuota per prudenza la cartella temp
            Funzioni.SvuotaCartella(mAgenziaFiglia.Cartelle.CartellaArriviLocaleTempDL)

            'controllo data inizio
            If RecordConfig.DataInizio <= Today Then

                Globale.Log.Info(String.Format("Importazione dati collegata alla {0}: {1}", mAgenziaFiglia.CodiceAgenziaFiglia, RecordConfig.AgenziaCollegata))
                Globale.Log.Info()

                'inizia il download dei dati e l'importazione
                If RecordConfig.Sinistri = True Then
                    Dim Aia As New SinistriAIA(mAgenziaFiglia, RecordConfig)
                    Aia.ImportaSinistriAIA()
                    Aia = Nothing
                End If
                'monitor QT
                If RecordConfig.Avvisi = True Then
                    Dim MonQT As New MonitorQT(mAgenziaFiglia, RecordConfig)
                    MonQT.ImportaMonitorQT()
                    MonQT = Nothing
                    Dim MonQT_KMS As New MonitorQT_KMS(mAgenziaFiglia, RecordConfig)
                    MonQT_KMS.ImportaMonitorQT_KMS()
                    MonQT_KMS = Nothing
                End If
                'buste
                Dim Buste As New BusteDecadi(mAgenziaFiglia, RecordConfig)
                Buste.ImportaBuste()
                Buste = Nothing
                'management fee
                Dim MFee As New ManagementFee(mAgenziaFiglia, RecordConfig)
                MFee.ImportaMFee()
                MFee = Nothing
                'compensi unibox
                Dim UBox As New CompensiUnibox(mAgenziaFiglia, RecordConfig)
                UBox.ImportaUBox()
                UBox = Nothing
                'PTFCanc
                'Dim PCanc As New PTFCanc(mAgenziaFiglia, RecordConfig)
                'PCanc.CreaPTFCanc()
                'PCanc = Nothing

                'FORZATURE
                'svuota per prudenza la cartella temp
                Funzioni.SvuotaCartella(mAgenziaFiglia.Cartelle.CartellaArriviLocaleTempDL)
                'importo file in forzatura
                Dim Forza As New Forzature(mAgenziaFiglia, RecordConfig)
                Forza.ImportaForzature()
                Forza = Nothing

                'scarico liste e documenti in vari formati
                Dim Liste As New ListeQT(mAgenziaFiglia, RecordConfig)
                Liste.ImportaListeQT()
                'Liste.ImportaListeFlex() 'non esistono più in questa forma
                Liste = Nothing

                'Prima nota bloccata dal 01/03/2023
                'blocca il download prima nota per le sedi secondarie
                'If RecordConfig.CodiceSede = "00" Then
                '    Dim PN As New PrimaNota(mAgenziaFiglia, RecordConfig)
                '    'blocca per le agenzie ex-aurora (che al momento (10/2013) non chiudono la PN)
                '    If Utx.NetFunc.ExGruppo(RecordConfig.AgenziaCollegata) = Utx.Enumerazioni.ExGruppo.EX_AURORA Then
                '        'scarico la PN solo se hanno Unicont
                '        If mAgenziaFiglia.ConfigUnicont.AbilitazioneUniarea = True Then
                '            PN.ImportaPrimaNota()
                '        End If
                '    Else
                '        PN.ImportaPrimaNota()
                '    End If
                '    PN = Nothing
                'End If
            End If

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        Finally
            Globale.Log.Info()
            Globale.Log.Info(String.Format("Fine importazione: {0}", Now.ToString))
            Globale.Log.Info()
        End Try
    End Sub

    Private Sub InitLog()
        Try
            Dim IDati As String = Path.Combine(Utx.Globale.Paths.CartellaApp, "IDati.dll")

            With Globale.Log
                .Info()
                .Info(String.Format("Inizio importazione: {0}", Now.ToString))
                .Info()
                .Info(String.Format("Versione IDati: {0} ({1})", FileVersionInfo.GetVersionInfo(IDati).ProductVersion, Utx.NetFunc.FileToMD5(IDati)))
                .Info(String.Format("Host name: {0}", Utx.FunzioniAmbiente.HostName))
                .Info(String.Format("Sede: {0}", Utx.FunzioniAmbiente.PcToSede))
                .Info(String.Format("Utente pc: {0}", Environment.UserName))
                .Info(String.Format("Utente applicazione/uniage: {0}", Utx.Globale.UtenteCorrente.UniageUser))
                .Info()
            End With

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        End Try
    End Sub

    Friend Sub ScriviProfilo()
        'scrive codice agenzia e sede nel profilo agenzia nella forma 01949-00
        Try
            Using cmd As New OleDbCommand
                cmd.Connection = mAgenziaFiglia.Connessione
                cmd.CommandType = CommandType.Text
                cmd.CommandText = String.Format("INSERT INTO ProfiloAgenzia (Intestatario) VALUES('{0}-{1}')",
                                                mAgenziaFiglia.CodiceAgenziaFiglia,
                                                mAgenziaFiglia.SedeAgenziaFiglia)
                cmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        End Try
    End Sub

    Friend Function SonoArrivatiDati() As Boolean
        Try
            Dim Query As String = "SELECT Count(*) FROM {0}"

            With Globale.DatiArrivati

                Using cmd As New OleDb.OleDbCommand

                    cmd.Connection = mAgenziaFiglia.Connessione
                    cmd.CommandType = CommandType.Text

                    'cmd.CommandText = String.Format(Query, "ControlloIncassi")
                    '.Incassi = (cmd.ExecuteScalar > 0)

                    cmd.CommandText = String.Format(Query, "MonitorQT")
                    .MonitorQt = (cmd.ExecuteScalar > 0)

                    cmd.CommandText = String.Format(Query, "SinistriAia")
                    .SinistriBase = (cmd.ExecuteScalar > 0)

                    cmd.CommandText = String.Format(Query, "AttivitaQT")
                    .ListeQT = (cmd.ExecuteScalar > 0)

                    cmd.CommandText = String.Format(Query, "ElencoFlex")
                    .ListeFlex = (cmd.ExecuteScalar > 0)

                    cmd.CommandText = String.Format(Query, "Buste")
                    .Buste = (cmd.ExecuteScalar > 0)
                End Using

                Return .MonitorQt OrElse
                       .SinistriBase OrElse
                       .ListeQT OrElse
                       .ListeFlex OrElse
                       .Buste
            End With

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
            Return False
        End Try
    End Function

    'Private Sub InviaDbUT()
    '    Try
    '        'il db in arrivi non dovrebbe esistere. nel caso viene sovrascritto
    '        File.Delete(mAgenziaFiglia.Cartelle.DatabaseArriviRete)
    '        'sposta il db arrivi su M:
    '        If CopiaFile(mAgenziaFiglia.Cartelle.DatabaseArrivi, mAgenziaFiglia.Cartelle.CartellaArriviAgenziaRete) = True Then
    '            'se ci sono dati importati crea il flag ready direttamente su M:
    '            Utx.GestioneFlag.CreaFlag(Utx.GestioneFlag.TipoFlag.DATI_DOWNLOAD_DISPONIBILI)
    '        Else
    '            'rimuovo l'ultimo tab di notifica dell'agenzia e il log
    '            For Each tp As TabPage In Globale.Notifica.TabPages
    '                If tp.Name = mAgenziaFiglia.CodiceAgenziaFiglia Then Globale.Notifica.TabPages.Remove(tp)
    '                If tp.Name = String.Format("Log {0}", mAgenziaFiglia.CodiceAgenziaFiglia) Then Globale.Notifica.TabPages.Remove(tp)
    '            Next
    '        End If

    '    Catch ex As Exception
    '        Globale.LogErrori.Info(ex)
    '    End Try

    '    'sposto i log da C: a M:
    '    Try
    '        CopiaFile(Globale.Log.FullPathLogFile, mAgenziaFiglia.Cartelle.CartellaArriviAgenziaRete)
    '        CopiaFile(Globale.LogErrori.FullPathLogFile, mAgenziaFiglia.Cartelle.CartellaArriviAgenziaRete)
    '        'non cancello la cartella in locale perchè in caso di anomalie può essere recuperata a mano
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Private Sub InviaEmailNotifica()
        Try
            Dim sb As New StringBuilder
            With sb
                .AppendLine(String.Format("Agenzia madre: {0} - {1}", Utx.Globale.ProfiloEnteGestore.AgenziaMadre, Utx.Globale.ProfiloEnteGestore.Localita))
                .AppendLine(String.Format("Agenzia: {0}", mAgenziaFiglia.CodiceAgenziaFiglia))
                .AppendLine(String.Format("Versione: {0}", Application.ProductVersion))
                .AppendLine(String.Format("Pc: {0}", Environment.MachineName))
                .AppendLine(String.Format("Utente pc: {0}", Environment.UserName))
                .AppendLine(String.Format("Utente uniage: {0}", Utx.Globale.UtenteCorrente.UniageUser))
            End With

            Dim p As New UniCom.Postino
            With p
                .EmailAutomatica = True
                .Mittente = UniCom.Postino.MittenteAgenzia
                .InviaA.Add("guidolampo@tiscali.it")
                .Oggetto = String.Format("Errore in importazione dati. Agenzia {0}", mAgenziaFiglia.CodiceAgenziaFiglia)
                .Testo = sb.ToString
                .AddAllegato(Globale.Log.FullPathLogFile)
                .AddAllegato(Globale.LogErrori.FullPathLogFile)
                .InviaMail()
            End With

        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        End Try
    End Sub

    Private Sub LogRiepilogo()
        Try
            Using cnArrivi As New OleDbConnection(mAgenziaFiglia.ConnectionStringArrivi)
                cnArrivi.Open()

                Globale.Log.Info("Riepilogo file scaricati:")

                Using da As New OleDbDataAdapter("SELECT NomeFile FROM CalendarioUT", cnArrivi)
                    Dim dt As New DataTable
                    da.Fill(dt)

                    For Each row As DataRow In dt.Rows
                        Globale.Log.Info(row("NomeFile"))
                    Next
                End Using
                Using da As New OleDbDataAdapter("SELECT NomeFile FROM CalendarioDOC", cnArrivi)
                    Dim dt As New DataTable
                    da.Fill(dt)

                    For Each row As DataRow In dt.Rows
                        Globale.Log.Info(row("NomeFile"))
                    Next
                End Using
            End Using
        Catch ex As Exception
            Globale.LogErrori.Info(ex)
        End Try
    End Sub
End Class
