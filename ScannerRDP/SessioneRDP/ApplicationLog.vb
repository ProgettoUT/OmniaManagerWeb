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

    Private mCartellaLog As String
    Private mRientro As Integer = 0
    Private mPassoRientro As Integer = 4
    Private Shared sbUso As New StringBuilder()
    Private CartellaApp As String = "C:\ApplicazioniDirezione\Unitools"
    Private TitoloApp As String = "Scanner RDP"

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
            If String.IsNullOrEmpty(CartellaLog) Then
                'la cartella log alla prima chiamata non è ancora definita perciò bisogna usare questa forma con cartellaapp
                If LogCondiviso = True Then
                    mCartellaLog = "C:\ApplicazioniDirezione\Unitools\Logs"
                Else
                    mCartellaLog = String.Format("C:\ApplicazioniDirezione\Unitools\Logs\{0}", Environment.UserName)
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
                mDescrizione += String.Format(" ({0})", Descrizione)
            End If

            If File.Exists(mLogFile) Then
                'se è richiesta la sovrascrittura o supera i 500 KB
                If (Sovrascrivi = True) OrElse (New FileInfo(mLogFile).Length > 500000) Then
                    File.Delete(mLogFile)
                End If
            End If

        Catch ex As Exception
            'non fare niente
        End Try
    End Sub

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
            Case DataOra.NESSUNA
                Return String.Format("{0}{1}", Space(RientroExtra), Space(mRientro) + Messaggio) + Environment.NewLine
            Case DataOra.SOLO_DATA
                Return String.Format("[{0:d}]{1}{2}", Today, Space(RientroExtra), Space(mRientro) + Messaggio) + Environment.NewLine
            Case DataOra.DATA_ORA
                Return String.Format("[{0:d} {1:T}]{2}{3}", Today, Now, Space(RientroExtra), Space(mRientro) + Messaggio) + Environment.NewLine
            Case DataOra.DATA_ORA_MILLISECONDI
                Return String.Format("[{0:d} {1}]{2}{3}", Today, Format(Now, "HH:mm:ss.fff"), Space(RientroExtra), Space(mRientro) + Messaggio) + Environment.NewLine
            Case Else
                'data e ora
                Return String.Format("[{0:d} {1:T}]{2}{3}", Today, Now, Space(RientroExtra), Space(mRientro) + Messaggio) + Environment.NewLine
        End Select
    End Function

    Private Function LogMsg()
        'riga di separazione
        LogMsg = StrDup(80, "-") + Environment.NewLine
    End Function

    Private Sub EvidenziaErrore(Optional Carattere As String = "*")
        On Error Resume Next
        File.AppendAllText(mLogFile, StrDup(80, Carattere) + Environment.NewLine)
    End Sub

    Private Sub AddLog()
        On Error Resume Next
        Dim Testo As String = LogMsg()
        File.AppendAllText(mLogFile, Testo)
    End Sub

    Private Sub AddLog(Messaggio As String, Rientro As Integer)
        On Error Resume Next
        Dim Testo As String = LogMsg(Messaggio, Rientro)
        File.AppendAllText(mLogFile, Testo)
    End Sub

    Private Sub AddLog(Messaggio As String)
        On Error Resume Next
        Dim Testo As String = LogMsg(Messaggio)
        File.AppendAllText(mLogFile, Testo)
    End Sub

    Private Sub AddLog(Ex As Exception)
        On Error Resume Next
        'il log degli errori viene evidenziato
        EvidenziaErrore()
        'stampo il messaggio
        File.AppendAllText(mLogFile, LogMsg(Ex.Message))
        'e poi lo stack delle chiamate
        Dim st As New StackTrace(Ex, True)
        File.AppendAllText(mLogFile, String.Format("{1}{0}", Environment.NewLine, Ex.StackTrace))
        File.AppendAllText(mLogFile, "Dettaglio delle chiamate:" + Environment.NewLine)
        File.AppendAllText(mLogFile, String.Format("Errore in {1} alla linea {2}{0}",
                                                   Environment.NewLine,
                                                   st.GetFrame(0).GetMethod,
                                                   st.GetFrame(0).GetFileLineNumber()))

        For k As Integer = 1 To st.FrameCount - 1
            File.AppendAllText(mLogFile, String.Format("- Chiamato da {1} alla linea {2}{0}",
                                                       Environment.NewLine,
                                                       st.GetFrame(k).GetMethod.Name,
                                                       st.GetFrame(k).GetFileLineNumber()))
        Next
        EvidenziaErrore()
    End Sub

    Private Sub AddLog(Nota As String, Ex As Exception)
        On Error Resume Next
        File.AppendAllText(mLogFile, LogMsg(String.Format("{0}" + vbNewLine +
                                                          "MESSAGGIO: {1}" + vbNewLine +
                                                          "STACK TRACE: {2}" + vbNewLine,
                                                          Nota, Ex.Message, Ex.StackTrace.Trim)))
    End Sub

    Private Sub BoxErrore(ex As Exception, Optional VisualizzaMessaggio As Boolean = True)
        On Error Resume Next
        AddLog(ex)
        'se richiesto visualizza il messaggio di errore
        If VisualizzaMessaggio Then
            Dim Messaggio As String = String.Format("{1}{0}{0}Log: {2}",
                                     Environment.NewLine,
                                     ex.Message,
                                     Replace(mLogFile, CartellaApp, ".."))
        End If
    End Sub

    Private Sub BoxErrore(Messaggio As String, Optional VisualizzaMessaggio As Boolean = True)
        On Error Resume Next
        AddLog(Messaggio)
        'se richiesto visualizza il messaggio di errore
        If VisualizzaMessaggio Then
            MsgBox(String.Format("{1}{0}{0}log: {2}", Environment.NewLine, Messaggio, Replace(mLogFile, CartellaApp, "..")),
                   MsgBoxStyle.Exclamation,
                   String.Format("{0}: Errore", TitoloApp))
        End If
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
    Public Sub InfoNoLivello(Messaggio As String)
        AddLog(Messaggio)
    End Sub

    Public Sub Info(Messaggio As String, Parametri() As String)
        If mLivelloLog <= Livello.INFO Then
            AddLog(String.Format(Messaggio, Parametri))
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
        If mLivelloLog <= Livello.ERRORE Then
            BoxErrore(ex, VisualizzaMessaggio)
        End If
    End Sub

    Public Sub Errore(Messaggio As String, Optional VisualizzaMessaggio As Boolean = True)
        If mLivelloLog <= Livello.ERRORE Then
            BoxErrore(Messaggio, VisualizzaMessaggio)
        End If
    End Sub

    Public Sub Fatale(ex As Exception, Optional VisualizzaMessaggio As Boolean = True)
        If mLivelloLog <= Livello.FATALE Then
            BoxErrore(ex, VisualizzaMessaggio)
        End If
    End Sub
#End Region
End Class
