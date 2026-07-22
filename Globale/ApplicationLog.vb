Imports System.IO
Imports System.Text

Public Class ApplicationLog

    Public Shared LogAttivi As New List(Of ApplicationLog)

    Public Enum Livello
        TRACE = 0
        DEBUG = 1
        INFO = 2
        ERRORE = 3
        FATALE = 4
    End Enum

    Public Enum DataOra
        NESSUNA
        SOLO_DATA
        DATA_ORA
        DATA_ORA_MILLISECONDI
    End Enum

    Private ReadOnly mCartellaLog As String
    Private mRientro As Integer = 0
    Private mPassoRientro As Integer = 4
    Private Shared Uso As New List(Of String)

    ''' <summary>
    ''' Istanzia classe per la creazione di un log dell'applicazione
    ''' </summary>
    ''' <param name="NomeLogFile">Nome del file di log senza path (cartella logs predefinita)</param>
    ''' <remarks></remarks>
    Sub New(NomeLogFile As String,
            Optional CartellaLog As String = "",
            Optional Descrizione As String = "",
            Optional Sovrascrivi As Boolean = False,
            Optional LogCondiviso As Boolean = False)

        Try
            mLogCondiviso = LogCondiviso

            If String.IsNullOrEmpty(CartellaLog) Then
                'la cartella log alla prima chiamata non è ancora definita perciò bisogna usare questa forma con cartellaapp
                If LogCondiviso = True Then
                    mCartellaLog = $"{Utx.Globale.Paths.CartellaApp}\Logs"
                Else
                    mCartellaLog = $"{Utx.Globale.Paths.CartellaApp}\Logs\{Utx.Globale.PcUserName}"
                End If
            Else
                mCartellaLog = CartellaLog
            End If

            'creo la cartella dei log
            Directory.CreateDirectory(mCartellaLog)

            'recupero solo il nome file nel caso ci sia il path e controllo l'estensione
            NomeLogFile = Path.ChangeExtension(Path.GetFileName(NomeLogFile), "log")
            'nome file e descrizione
            mLogFile = Path.Combine(mCartellaLog, NomeLogFile)
            mTipoData = DataOra.DATA_ORA
            mDescrizione = NomeLogFile
            If String.IsNullOrEmpty(Descrizione) = False Then
                mDescrizione += $" ({Descrizione})"
            End If

            If File.Exists(mLogFile) Then
                'se è richiesta la sovrascrittura o supera i 500 KB
                If (Sovrascrivi = True) OrElse (New FileInfo(mLogFile).Length > 500000) Then
                    File.Delete(mLogFile)
                End If
            End If
            'aggiungo il log alla collection dei log attivi
            AddLogAttivo()

        Catch ex As Exception
            'non fare niente
        End Try
    End Sub

    Private mLogCondiviso As Boolean
    Public Property LogCondiviso() As Boolean
        Get
            Return mLogCondiviso
        End Get
        Set(value As Boolean)
            mLogCondiviso = value
        End Set
    End Property

    Private Shared mLivelloLog As Livello = Livello.INFO
    Public Shared Property LivelloLog() As Livello
        Get
            Return mLivelloLog
        End Get
        Set(value As Livello)
            mLivelloLog = value
        End Set
    End Property

    Private mLogFile As String
    Public ReadOnly Property LogFile() As String
        Get
            Return mLogFile
        End Get
    End Property

    Private mDescrizione As String
    Public Property Descrizione() As String
        Get
            Return mDescrizione
        End Get
        Set(value As String)
            mDescrizione = value
        End Set
    End Property

    Private mTipoData As DataOra
    Public Property TipoData() As DataOra
        Get
            Return mTipoData
        End Get
        Set(value As DataOra)
            mTipoData = value
        End Set
    End Property

    Private Function LogMsg(Messaggio As String, Optional RientroExtra As Integer = 0)
        Select Case mTipoData
            Case DataOra.SOLO_DATA
                LogMsg = $"[{Today:d}]{Space(RientroExtra)}{Space(mRientro) + Messaggio}"
            Case DataOra.DATA_ORA
                LogMsg = $"[{Today:d} {Now:T}]{Space(RientroExtra)}{Space(mRientro) + Messaggio}"
            Case DataOra.DATA_ORA_MILLISECONDI
                LogMsg = $"[{Today:d} {Now:HH:mm:ss.fff}]{Space(RientroExtra)}{Space(mRientro) + Messaggio}"
            Case Else
                LogMsg = $"{Space(RientroExtra)}{Space(mRientro) + Messaggio}"
        End Select
        'se il log è condiviso aggiungo l'utente
        Dim Utente As String = "XX"
        If (Utx.Globale.UtenteCorrente IsNot Nothing) AndAlso (Utx.Globale.UtenteCorrente.UniageUser IsNot Nothing) Then
            Utente = Utx.Globale.UtenteCorrente.UniageUser.Substring(6).ToUpper
        End If
        If Globale.SessioneCorrente IsNot Nothing Then
            If mLogCondiviso Then
                If Globale.SessioneCorrente.Nascosta Then
                    LogMsg = $"[AUTO][{Utente}]" & LogMsg
                Else
                    LogMsg = $"[{Utente}]" & LogMsg
                End If
            Else
                'sessione nascosta aggiungo AUTO
                If Globale.SessioneCorrente.Nascosta Then
                    LogMsg = "[AUTO]" & LogMsg
                End If
            End If
        End If
        LogMsg &= Environment.NewLine
    End Function

    Private Function LogMsg()
        'riga di separazione
        Return StrDup(80, "-") + Environment.NewLine
    End Function

    Private Sub Evidenza(Aggiungi As Boolean)
        If Aggiungi Then
            File.AppendAllText(mLogFile, StrDup(80, "=") + Environment.NewLine)
        End If
    End Sub

    Private Sub EvidenziaErrore(Optional Carattere As String = "*")
        On Error Resume Next
        File.AppendAllText(mLogFile, StrDup(80, Carattere) + Environment.NewLine)
    End Sub

    Private Sub AddLog()
        On Error Resume Next
        Dim Testo As String = LogMsg()
        File.AppendAllText(mLogFile, Testo)
        VisualizzaInFinestra(Testo)
    End Sub

    Private Sub AddLog(Messaggio As String, Rientro As Integer)
        On Error Resume Next
        Dim Testo As String = LogMsg(Messaggio, Rientro)
        File.AppendAllText(mLogFile, Testo)
        VisualizzaInFinestra(Testo)
    End Sub

    Private Sub AddLog(Messaggio As String)
        On Error Resume Next
        '#If DEBUG Then
        '        If Messaggio.StartsWith("http") Then
        '            MsgBox("x")
        '        End If
        '#End If
        Dim Testo As String = LogMsg(Messaggio)
        File.AppendAllText(mLogFile, Testo)
        VisualizzaInFinestra(Testo)
    End Sub

    Private Sub AddLog(Ex As Exception)
        On Error Resume Next
        'il log degli errori viene evidenziato
        EvidenziaErrore()
        'stampo il messaggio
        File.AppendAllText(mLogFile, LogMsg(Ex.Message))
        'e poi lo stack delle chiamate
        File.AppendAllText(mLogFile, Ex.StackTrace & Environment.NewLine)
        EvidenziaErrore()
    End Sub

    'Private Function StackChiamate(Ex As Exception) As String
    '    Dim sb As New StringBuilder
    '    With sb
    '        Dim st As New StackTrace(Ex, True)
    '        sb.AppendLine(String.Format("{1}{0}", Environment.NewLine, Ex.StackTrace))
    '        sb.AppendLine("Dettaglio delle chiamate:" + Environment.NewLine)
    '        sb.AppendLine(String.Format("Errore in {1} alla linea {2}{0}",
    '                                    Environment.NewLine,
    '                                    st.GetFrame(0).GetMethod,
    '                                    st.GetFrame(0).GetFileLineNumber()))

    '        For k As Integer = 1 To st.FrameCount - 1
    '            sb.AppendLine(String.Format("- Chiamato da {1} alla linea {2}{0}",
    '                                        Environment.NewLine,
    '                                        st.GetFrame(k).GetMethod.Name,
    '                                        st.GetFrame(k).GetFileLineNumber()))
    '        Next
    '    End With
    '    Return sb.ToString()
    'End Function

    Private Sub AddLog(Nota As String, Ex As Exception)
        On Error Resume Next
        File.AppendAllText(mLogFile, LogMsg($"{Nota}{vbNewLine}MESSAGGIO: {Ex.Message}{vbNewLine}STACK TRACE: {Ex.StackTrace.Trim}{vbNewLine}"))
    End Sub

    Private Sub BoxErrore(ex As Exception, Optional VisualizzaMessaggio As Boolean = True)
        On Error Resume Next
        'incaso di errore disattivo il primo piano
        If mFormVisualizzazione IsNot Nothing Then mFormVisualizzazione.CheckBoxPrimoPiano.Checked = False

        AddLog(ex) 'in locale
        LogClient(ex.Message & Environment.NewLine & ex.StackTrace)

        'se richiesto visualizza il messaggio di errore
        If VisualizzaMessaggio Then
            Dim Messaggio As String = $"{ex.Message}{Environment.NewLine}{Environment.NewLine}Log: {Replace(mLogFile, Utx.Globale.Paths.CartellaApp, "...")}"

            'controllo se è richiesto un riavvio
            If Utx.Globale.SessioneCorrente.RiavvioRichiesto = True Then
                MsgBox($"Si è verificato un errore.
Poiché è stato scaricato un aggiornamento un RIAVVIO (chiudi e riapri il programma) potrebbe risolvere il problema.

Errore:
{Messaggio}", MsgBoxStyle.Exclamation, $"{Utx.Globale.TitoloApp}: Errore")
            Else
                MsgBox(Messaggio, MsgBoxStyle.Exclamation, $"{Utx.Globale.TitoloApp}: Errore")
            End If
        End If
    End Sub

    Private Sub BoxErrore(Messaggio As String, Optional VisualizzaMessaggio As Boolean = True)
        On Error Resume Next
        'incaso di errore disattivo il primo piano
        If mFormVisualizzazione IsNot Nothing Then mFormVisualizzazione.CheckBoxPrimoPiano.Checked = False

        AddLog(Messaggio)
        LogClient(Messaggio)

        'se richiesto visualizza il messaggio di errore
        If VisualizzaMessaggio Then
            MsgBox($"{Messaggio}

log: {Replace(mLogFile, Utx.Globale.Paths.CartellaApp, "...")}",
                   MsgBoxStyle.Exclamation, $"{Utx.Globale.TitoloApp}: Errore")
        End If
    End Sub

    Public Sub LogDataTable(ByRef dt As DataTable, ByRef Campi() As String)
        On Error Resume Next
        For k As Integer = 0 To dt.Columns.Count - 1
            File.AppendAllText(mLogFile, $"{k:00}: {dt.Columns(k).ColumnName.Trim} = |{Campi(k)}|")
        Next
        File.AppendAllText(mLogFile, StrDup(40, "-"))
    End Sub

    Public Sub LogDataTable(ByRef dt As DataTable, ByRef Campi As ArrayList)
        On Error Resume Next
        For k As Integer = 0 To dt.Columns.Count - 1
            File.AppendAllText(mLogFile, $"{k:00}: {dt.Columns(k).ColumnName.Trim} = |{Campi(k)}|{Environment.NewLine}")
        Next
        File.AppendAllText(mLogFile, StrDup(40, "-"))
    End Sub

    Public Sub LogDataTable(ByRef dt As DataTable, Optional Righe As Integer = 100)
        On Error Resume Next
        Righe = Math.Min(Righe, dt.Rows.Count - 1)
        For r As Integer = 0 To Righe
            For c As Integer = 0 To dt.Columns.Count - 1
                File.AppendAllText(mLogFile, $"Riga {r:000} colonna {c:000}[{dt.Columns(c).ColumnName.Trim}] = |{dt.Rows(r).Item(c)}|{Environment.NewLine}")
            Next
            File.AppendAllText(mLogFile, StrDup(40, "-") + Environment.NewLine)
        Next
    End Sub

    Public ReadOnly Property FullPathLogFile() As String
        Get
            Return mLogFile
        End Get
    End Property

    Public Property Rientro() As Integer
        Get
            Return mRientro
        End Get
        Set(Rientro As Integer)
            mRientro = Rientro
        End Set
    End Property

    Public Property PassoRientro() As Integer
        Get
            Return mPassoRientro
        End Get
        Set(PassoRientro As Integer)
            mPassoRientro = PassoRientro
        End Set
    End Property

    Private Shared mFormVisualizzazione As FormLog
    Public Shared Property FormVisualizzazione() As FormLog
        Get
            Return mFormVisualizzazione
        End Get
        Set(value As FormLog)
            mFormVisualizzazione = value
        End Set
    End Property

    Public Shared Function DataLog(Riga As String) As Date
        Try
            If IsDate(Riga.Substring(1, 10)) Then
                Return CDate(Riga.Substring(1, 10))
            Else
                Return #1/1/2000#
            End If
        Catch ex As Exception
            Return #1/1/2000#
        End Try
    End Function

    Public Sub AumentaRientro()
        mRientro += mPassoRientro
    End Sub

    Public Sub DiminuisciRientro()
        mRientro -= mPassoRientro
        If mRientro < 0 Then mRientro = 0
    End Sub

    Public Sub ApriLog()
        On Error Resume Next
        Process.Start(mLogFile)
    End Sub

    Private Sub AddLogAttivo()
        For Each l As Utx.ApplicationLog In LogAttivi
            If Me.Equals(l) Then
                Exit Sub
            End If
        Next
        LogAttivi.Add(Me)

        If mFormVisualizzazione IsNot Nothing Then
            mFormVisualizzazione.AggiornaListaLogAttivi()
        End If
    End Sub

    Private Sub VisualizzaInFinestra(Messaggio As String)
        If mFormVisualizzazione IsNot Nothing Then
            mFormVisualizzazione.AddLog($"{Path.GetFileName(Me.mLogFile)} >> {Messaggio}")
        End If
    End Sub

    Public Sub LogClient(Messaggio As String)
        On Error Resume Next
        Using s As New Utx.Log.Log
            s.LogClientEx(Utx.Globale.ProfiloEnteGestore.AgenziaMadre,
                          Utx.Globale.AgenziaRichiesta.CodiceAgenzia,
                          Environment.MachineName,
                          Messaggio,
                          Utx.Globale.Token)
        End Using
    End Sub

#Region "trace"
    Public Sub Trace(Messaggio As String)
        If mLivelloLog <= Livello.TRACE Then
            AddLog(Messaggio)
        End If
    End Sub

    Public Sub Trace(Messaggio As String, Parametri() As String)
        If mLivelloLog <= Livello.TRACE Then
            AddLog(String.Format(Messaggio, Parametri))
        End If
    End Sub

    Public Sub Trace()
        If mLivelloLog <= Livello.TRACE Then
            AddLog()
        End If
    End Sub
#End Region

#Region "debug"
    Public Sub Debug(Messaggio As String)
        If mLivelloLog <= Livello.DEBUG Then
            AddLog(Messaggio)
        End If
    End Sub

    Public Sub Debug(Messaggio As String, Parametri() As String)
        If mLivelloLog <= Livello.DEBUG Then
            AddLog(String.Format(Messaggio, Parametri))
        End If
    End Sub
#End Region

#Region "info"
    Public Sub InfoNoLivello(Messaggio As String, Optional Evidenzia As Boolean = False)
        Evidenza(Evidenzia)
        AddLog(Messaggio)
        Evidenza(Evidenzia)
    End Sub
    Public Sub InfoNoLivello(Messaggio As String)
        AddLog(Messaggio)
    End Sub

    Public Sub Info(Messaggio As String, Parametri() As String, Optional Evidenzia As Boolean = False)
        If mLivelloLog <= Livello.INFO Then
            Evidenza(Evidenzia)
            AddLog(String.Format(Messaggio, Parametri))
            Evidenza(Evidenzia)
        End If
    End Sub
    Public Sub Info(Messaggio As String, Parametri() As String)
        If mLivelloLog <= Livello.INFO Then
            AddLog(String.Format(Messaggio, Parametri))
        End If
    End Sub

    Public Sub Info(Messaggio As String, Optional Evidenzia As Boolean = False)
        If mLivelloLog <= Livello.INFO Then
            Evidenza(Evidenzia)
            AddLog(Messaggio)
            Evidenza(Evidenzia)
        End If
    End Sub
    Public Sub Info(Messaggio As String)
        If mLivelloLog <= Livello.INFO Then
            AddLog(Messaggio)
        End If
    End Sub

    Public Sub Info(Nota As String, Ex As Exception)
        If mLivelloLog <= Livello.INFO Then
            AddLog(Nota, Ex)
        End If
    End Sub

    Public Sub Info()
        If mLivelloLog <= Livello.INFO Then
            AddLog()
        End If
    End Sub

    Public Sub Info(Ex As Exception)
        If mLivelloLog <= Livello.INFO Then
            AddLog(Ex)
        End If
    End Sub

    Public Sub Info(Messaggio As String, Rientro As Integer)
        If mLivelloLog <= Livello.INFO Then
            AddLog(Messaggio, Rientro)
        End If
    End Sub
#End Region

#Region "errore"
    Public Sub Errore(ex As Exception, Optional VisualizzaMessaggio As Boolean = True)
        On Error Resume Next
        If mLivelloLog <= Livello.ERRORE Then
            If Utx.Globale.SessioneCorrente IsNot Nothing AndAlso Utx.Globale.SessioneCorrente.Nascosta Then
                VisualizzaMessaggio = False
            End If

            BoxErrore(ex, VisualizzaMessaggio)
        End If
    End Sub

    Public Sub Errore(Messaggio As String, Optional VisualizzaMessaggio As Boolean = True)
        On Error Resume Next
        If mLivelloLog <= Livello.ERRORE Then
            If Utx.Globale.SessioneCorrente IsNot Nothing AndAlso Utx.Globale.SessioneCorrente.Nascosta Then
                VisualizzaMessaggio = False
            End If

            BoxErrore(Messaggio, VisualizzaMessaggio)
        End If
    End Sub

    Public Sub Fatale(ex As Exception, Optional VisualizzaMessaggio As Boolean = True)
        On Error Resume Next
        If mLivelloLog <= Livello.FATALE Then
            If Utx.Globale.SessioneCorrente IsNot Nothing AndAlso Utx.Globale.SessioneCorrente.Nascosta Then
                VisualizzaMessaggio = False
            End If

            BoxErrore(ex, VisualizzaMessaggio)
        End If
    End Sub
#End Region

#Region "Log uso UT"
    Public Shared Sub LogUso(Sezione As String)
#If DEBUG Then
        'Exit Sub
#End If
        On Error Resume Next
        'aggiungo la riga alla lista
        Uso.Add($"{Utx.Globale.UtenteCorrente.UniageUser};{Left(Sezione.Trim, 255)};{Now}")

        'quando supera la lunghezza massima invio dati e svuoto la lista
        If (Uso.Count >= 50) Then
            InviaLogUso()
        End If
    End Sub

    Public Shared Sub InviaLogUso()
#If DEBUG Then
        Uso.Clear()
        Exit Sub
#End If
        Try
            Utx.Globale.Log.Info("InviaLogUso")
            'definisco dataset e datatable
            Dim ds As New DataSet
            With ds.Tables.Add("Uso").Columns
                .Add("Utente", Type.GetType("System.String"))
                .Add("Funzione", Type.GetType("System.String"))
                .Add("Data", Type.GetType("System.DateTime"))
            End With
            'aggiuungo record dalla lista
            For Each riga As String In Uso
                ds.Tables("Uso").Rows.Add(riga.Trim.Split(";"))
            Next

            'definisco modalità
            Dim Modalita As String = "UTENTE"
            If Utx.Globale.SessioneCorrente.Nascosta Then
                Modalita = "AUTO"
            End If
            If Utx.FunzioniRete.PcInDominio Then
                Modalita &= "-DIR"
            Else
                Modalita &= "-PP"
            End If
            Modalita &= "-" & Utx.Globale.Paths.UnitaDati.Name.Substring(0, 1)

            'invio i dati
            Using ws As New Utx.SettingAgenzia.ConfiguraSede
                ws.Proxy = Utx.Globale.UniProxy.Proxy

                Dim Esito As String = ws.RegistraLogUsoEx(Utx.Globale.ProfiloEnteGestore.Compagnia,
                                                          Utx.Globale.AgenziaRichiesta.CodiceAgenzia,
                                                          Utx.Globale.ProfiloEnteGestore.CodiceSede,
                                                          Utx.Globale.SessioneCorrente.IdSessione,
                                                          Utx.Globale.SessioneCorrente.Versione,
                                                          Modalita,
                                                          ds)
                Utx.Globale.Log.Info($"Inviate {ds.Tables("Uso").Rows.Count} righe log uso con esito: {Esito}")
            End Using
            'svuoto la lista
            Uso.Clear()

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub
#End Region
End Class
