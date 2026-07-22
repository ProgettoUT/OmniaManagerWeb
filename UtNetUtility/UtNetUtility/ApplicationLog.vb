Imports System.IO
Imports System.Text

Public Class ApplicationLog

    Private mLogFile As String
    Private mCartellaLog As String = "C:\ApplicazioniDirezione\Unitools\Logs"
    Private mRientro As Integer = 0
    Private mPassoRientro As Integer = 4

    ''' <summary>
    ''' Istanzia classe per la creazione di un log dell'applicazione
    ''' </summary>
    ''' <param name="NomeLogFile">Nome del file di log senza path (cartella logs predefinita)</param>
    ''' <remarks></remarks>
    Sub New(ByVal NomeLogFile As String)

        'creo la cartella dei log
        Directory.CreateDirectory(mCartellaLog)

        Try
            'recupero solo il nome file nel caso ci sia il path
            NomeLogFile = Path.GetFileName(NomeLogFile)

            mLogFile = Path.Combine(mCartellaLog, NomeLogFile)

            If File.Exists(mLogFile) Then

                If New FileInfo(mLogFile).Length > 500000 Then
                    Dim NuovoNome As String = String.Format("{0}.{1}", Format(Now, "ddMMyyyy_HHmmss"), NomeLogFile)
                    File.Move(mLogFile, Path.Combine(mCartellaLog, NuovoNome))
                End If
            End If

        Catch ex As Exception
            'non fare niente
        End Try

    End Sub

    ''' <summary>
    ''' Istanzia classe per la creazione di un log dell'applicazione
    ''' </summary>
    ''' <param name="CartellaLog">Cartella dove salvare il file di log</param>
    ''' <param name="NomeLogFile">Nome del file di log senza path</param>
    ''' <remarks></remarks>
    Sub New(ByVal CartellaLog As String, ByVal NomeLogFile As String)
        mCartellaLog = CartellaLog

        'creo la cartella dei log
        Directory.CreateDirectory(mCartellaLog)

        'recupero solo il nome file nel caso ci sia il path
        NomeLogFile = Path.GetFileName(NomeLogFile)

        mLogFile = Path.Combine(mCartellaLog, NomeLogFile)

        If File.Exists(mLogFile) Then

            If New FileInfo(mLogFile).Length > 500000 Then
                Dim NuovoNome As String = String.Format("{0}.{1}", Format(Now, "ddMMyyyy"), NomeLogFile)
                File.Move(mLogFile, Path.Combine(mCartellaLog, NuovoNome))
            End If
        End If
    End Sub

    Private Function LogMsg(ByVal Messaggio As String)

        LogMsg = String.Format("[{0} {1}]{2}",
                               Now.ToShortDateString,
                               Now.ToLongTimeString,
                               Space(mRientro) + Messaggio) + vbNewLine

    End Function

    Private Function LogMsg()
        'riga di separazione
        LogMsg = StrDup(80, "-") + vbNewLine
    End Function

    Private Function EvidenziaErrore(Optional ByVal Carattere As String = "*")
        'riga di separazione
        Return StrDup(80, Carattere) + vbNewLine
    End Function

    Public Sub AddLog()
        File.AppendAllText(mLogFile, LogMsg())
    End Sub

    Public Sub AddLog(ByVal Messaggio As String)
        File.AppendAllText(mLogFile, LogMsg(Messaggio))
    End Sub

    Public Sub AddLog(ByVal Ex As Exception)
        'il log degli errori viene evidenziato
        EvidenziaErrore()
        'stampo il messaggio
        File.AppendAllText(mLogFile, LogMsg(Ex.Message))
        'e poi lo stack delle chiamate
        File.AppendAllText(mLogFile, LogMsg(Ex.StackTrace))
        EvidenziaErrore()
    End Sub

    Public Sub AddLog(ByVal Nota As String, ByVal Ex As Exception)
        File.AppendAllText(mLogFile, LogMsg(String.Format("{0}" + vbNewLine +
                                                          "MESSAGGIO: {1}" + vbNewLine +
                                                          "STACK TRACE: {2}" + vbNewLine,
                                                          Nota, Ex.Message, Ex.StackTrace.Trim)))
    End Sub

    Public Sub BoxErrore(ByVal ex As Exception,
                         Optional ByVal VisualizzaMessaggio As Boolean = True)
        AddLog(ex)

        If VisualizzaMessaggio Then
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Unitools: Errore")
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
        Set(ByVal Rientro As Integer)
            mRientro = Rientro
        End Set
    End Property

    Public Property PassoRientro() As Integer
        Get
            Return mPassoRientro
        End Get
        Set(ByVal PassoRientro As Integer)
            mPassoRientro = PassoRientro
        End Set
    End Property

    Public Sub AumentaRientro()
        mRientro += mPassoRientro
    End Sub

    Public Sub DiminuisciRientro()
        mRientro -= mPassoRientro
    End Sub

    Public Sub ApriLog()
        Process.Start(mLogFile)
    End Sub
End Class
