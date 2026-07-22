Imports System.IO

Module Flag

    Friend Enum TipoFlag
        [Wip] = 1
        [Time] = 2
        [Ready] = 3
        [Archivio] = 4
        [ReadyLocale] = 5
    End Enum

    Friend Function CreaFlag(ByVal ID As TipoFlag) As Boolean

        Try
            Using sw As New StreamWriter(FullNameFlag(ID), True)

                Select Case ID
                    Case TipoFlag.Wip, TipoFlag.Time, TipoFlag.Archivio
                        sw.WriteLine(Date.Now.ToString)

                    Case TipoFlag.Ready, TipoFlag.ReadyLocale
                        sw.WriteLine(Date.Now.ToString)
                        sw.WriteLine(Glo.TestoNotifica.ToString)
                End Select
            End Using

            AddLog(AppLogFile, String.Format("Creato flag tipo {0} - Data {1}",
                                             ID.ToString, Date.Now.ToString))

        Catch ex As Exception
            AddLog(AppLogFile, ex.StackTrace)
        End Try

        Return True

    End Function

    ''' <summary>
    ''' cancella il flag 
    ''' </summary>
    ''' <param name="ID">tipo di flag da cancellare</param>
    ''' <remarks></remarks>
    Friend Sub CancellaFlag(ByVal ID As TipoFlag)

        Try
            File.Delete(FullNameFlag(ID))

            AddLog(AppLogFile, "Cancello flag " + ID.ToString)

        Catch ex As Exception
            AddLog(AppLogFile, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' cancella tutti i flag
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub CancellaFlag()

        Try
            File.Delete(FullNameFlag(TipoFlag.Wip))
            File.Delete(FullNameFlag(TipoFlag.Time))
            File.Delete(FullNameFlag(TipoFlag.Ready))

            AddLog(AppLogFile, "Cancello tutti i flag")

        Catch ex As Exception
            AddLog(AppLogFile, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' controllo esistenza flag work in progress (wip) e se esiste se è scaduto
    ''' se è scaduto (dopo 30 minuti) viene cancellato
    ''' </summary>
    ''' <returns>True se il flag esiste</returns>
    ''' <remarks></remarks>
    Friend Function EsisteFlagWip() As Boolean

        Dim FlagWip As String = FullNameFlag(TipoFlag.Wip)

        Try
            If File.Exists(FlagWip) Then

                'se il file esiste controlla la data di creazione scritta nel testo
                Dim Data As Date = CDate(File.ReadAllText(FlagWip))

                AddLog(AppLogFile, "Flag wip " + Data.ToString)

                'se è stato creato da più di 30 minuti è probabile ci sia stato un blocco
                'e quindi il flag viene rimosso
                If DateDiff(DateInterval.Minute, Data, Date.Now) > 30 Then
                    AddLog(AppLogFile, "Flag wip scaduto")
                    CancellaFlag(TipoFlag.Wip)
                End If
            End If

        Catch ex As Exception
            AddLog(AppLogFile, ex.Message)
            CancellaFlag(TipoFlag.Wip)
        End Try

        Return File.Exists(FlagWip)

    End Function

    Friend Function EsisteFlagReady() As Boolean
        'controllo esistenza flag ready (dati pronti)
        If File.Exists(FullNameFlag(TipoFlag.Ready)) Then
            AddLog(AppLogFile, "Esiste flag ready")
            Return True
        Else
            AddLog(AppLogFile, "Non esiste flag ready")
            Return False
        End If
    End Function

    Friend Function EsisteFlagTime(ByVal Delta As Integer) As Boolean

        Dim FlagTime As String = FullNameFlag(TipoFlag.Time)

        Try
            If File.Exists(FlagTime) Then 'esiste

                'leggo quando è stato fatto l'ultimo controllo
                Dim UltimoControllo As Date = CDate(File.ReadAllText(FlagTime))

                AddLog(AppLogFile, "File time " + UltimoControllo.ToString)

                'se il flag è scaduto lo cancello
                If DateDiff(DateInterval.Minute, UltimoControllo, Date.Now) > Delta Then 'è scaduto
                    AddLog(AppLogFile, "Flag time scaduto")
                    CancellaFlag(TipoFlag.Time)
                End If
            End If

        Catch ex As Exception
            'non è possibile inserire log errori perchè non ancora definito il path del file di log
            CancellaFlag(TipoFlag.Time)
        End Try

        Return File.Exists(FlagTime)

    End Function

    Friend Function EsisteFlagArchivio() As Boolean
        'controllo esistenza flag archivio
        Return File.Exists(FullNameFlag(TipoFlag.Archivio))
    End Function

    Friend Function FullNameFlag(ByVal ID As TipoFlag) As String
        'i flag wip e time sono globali a tutte le agenzie
        'il flag ready è locale alla singola agenzia
        Select Case ID
            Case TipoFlag.Wip
                Return Path.Combine(Glo.UTArriviEmme, "ImportaDati.wip")

            Case TipoFlag.Time
                Return Path.Combine(Glo.UTArriviEmme, "ImportaDati.time")

            Case TipoFlag.Ready
                Return Path.Combine(Glo.UTArriviEmmeAgenzia, "ImportaDati.ready")

            Case TipoFlag.ReadyLocale
                Return Path.Combine(Glo.PathDbArrivi, "ImportaDati.ready")

            Case TipoFlag.Archivio
                Return Path.Combine(Glo.PathArchivioDatiAgenzia, "Archivio.Ok")

            Case Else
                Return ""
        End Select

    End Function

End Module
