Imports System.IO

Module Flag

    Friend Function CreaFlag() As Boolean

        Try
            'se la dir non c'è la crea
            Directory.CreateDirectory(New FileInfo(FullNameFlag()).DirectoryName)

            Using sw As New StreamWriter(FullNameFlag(), True)
                sw.WriteLine(Date.Now.ToString)
            End Using

            Return True

        Catch ex As Exception
            Globale.Log.Info(ex.StackTrace)
        End Try

    End Function

    ''' <summary>
    ''' cancella il flag 
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub CancellaFlag()

        Try
            File.Delete(FullNameFlag())

        Catch ex As Exception
            Globale.Log.Info(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' controllo esistenza flag work in progress (wip) e se esiste se è scaduto
    ''' se è scaduto (dopo DurataInMinuti minuti) viene cancellato
    ''' </summary>
    ''' <returns>True se il flag esiste</returns>
    ''' <remarks></remarks>
    Friend Function EsisteFlagWip(ByVal DurataInMinuti As Integer) As Boolean

        Dim FlagWip As String = FullNameFlag()

        Try
            If File.Exists(FlagWip) Then

                'se il file esiste controlla la data di creazione scritta nel testo
                Dim Data As Date = CDate(File.ReadAllText(FlagWip))

                'se è stato creato da più di DurataInMinuti minuti è probabile ci sia stato un blocco
                'e quindi il flag viene rimosso
                If DateDiff(DateInterval.Minute, Data, Date.Now) >= DurataInMinuti Then
                    Globale.Log.Info("Flag wip scaduto")
                    CancellaFlag()
                End If
            End If

        Catch ex As Exception
            Globale.Log.Info(ex.Message)
            CancellaFlag()
        End Try

        Return File.Exists(FlagWip)

    End Function

    Friend Function FullNameFlag() As String
        'serve solo in TS-RDP
        Return "M:\Unitools\Archivi.bak\Backup.wip"
    End Function

End Module
