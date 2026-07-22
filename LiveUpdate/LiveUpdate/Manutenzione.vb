Imports System.IO

Public Class Manutenzione

    ''' <summary>
    ''' cancella file obsoleti
    ''' </summary>
    ''' <param name="dtFile">datatable con i dati sui file da cancellare</param>
    ''' <remarks></remarks>
    Friend Shared Sub CancellaFileOld(ByRef dtFile As DataTable)

        Try
            'controllo file obsoleti da cancellare
            Log.Info(String.Format("Controllo {0} file obsoleti", dtFile.Rows.Count))
            Log.AumentaRientro()

            For Each dr As DataRow In dtFile.Rows
                Try
                    Log.Trace(String.Format("{0} - {1}: {2}", PathDestinazione(dr("Unita"), dr("PathDestinazione")),
                                           dr("Modulo"),
                                           Directory.GetFiles(PathDestinazione(dr("Unita"), dr("PathDestinazione")), dr("Modulo")).GetUpperBound(0)))

                    'il nome del modulo può contenere caratteri jolly
                    For Each FileOld As String In Directory.GetFiles(PathDestinazione(dr("Unita"), dr("PathDestinazione")), dr("Modulo"))
                        'questo controllo è utile per le cartelle che non esistono altrimenti genera
                        'una eccezione (senza conseguenze)
                        If Directory.Exists(Path.GetDirectoryName(FileOld)) Then
                            If File.Exists(FileOld) Then
                                Log.Trace("Cancello " + FileOld)
                                File.Delete(FileOld)
                            End If
                        End If
                    Next
                Catch ex As Exception
                    Log.Info("Errore cancellazione file obsoleti: " + ex.Message)
                End Try
            Next

            CancellaFileUTOLD()

        Catch ex As Exception
            Log.Info("Errore cancellazione file obsoleti", ex)
        End Try

        Log.DiminuisciRientro()
    End Sub

    Friend Shared Sub CancellaFileUTOLD()
        'controllo file obsoleti da cancellare
        Try
            Log.Info("Cancellazione file UTOLD")
            Log.AumentaRientro()

            For Each f As String In Directory.GetFiles(Utx.Globale.Paths.CartellaApp, "*", SearchOption.TopDirectoryOnly)
                'solo cartella app
                If Path.GetFileName(f).ToUpper.StartsWith("UTOLD.") Then
                    Log.Trace("Cancello " + f)
                    File.Delete(f)
                End If
            Next
        Catch ex As Exception
            Log.Info("Errore cancellazione file UTOLD: " + ex.Message)
        Finally
            Log.DiminuisciRientro()
        End Try
    End Sub

    ''' <summary>
    ''' cancella cartelle obsolete anche se piene
    ''' </summary>
    ''' <param name="dtCartelle">datatable con i dati sulle cartelle da cancellare</param>
    ''' <remarks></remarks>
    Friend Shared Sub CancellaCartelleOld(ByRef dtCartelle As DataTable)
        Try
            'controllo cartelle da cancellare
            Log.Info(String.Format("Controllo {0} cartelle obsolete", dtCartelle.Rows.Count))
            Log.AumentaRientro()

            For Each dr As DataRow In dtCartelle.Rows
                Try
                    Log.Info(String.Format("Cancello la cartella {0}", dr("PathDestinazione")))
                    Utx.NetFunc.SvuotaCartella(dr("PathDestinazione"))
                    'se la cartella esiste la cancello
                    If Directory.Exists(dr("PathDestinazione")) Then
                        Directory.Delete(dr("PathDestinazione"), True)
                    End If

                Catch ex As Exception
                    Log.Info("Errore cancellazione cartelle obsolete: " + ex.Message)
                End Try
            Next

        Catch ex As Exception
            Log.Info("Errore cancellazione cartelle obsolete", ex)
        Finally
            Log.DiminuisciRientro()
        End Try
    End Sub

    Private Shared Function PathDestinazione(Unita As String,
                                             PathRelativo As Object) As String
        If PathRelativo Is DBNull.Value Then
            PathRelativo = ""
        End If

        Select Case Unita
            Case "L" 'locale
                Return Path.Combine(Utx.Globale.Paths.CartellaApp, PathRelativo)
            Case "R" 'rete
                Return Path.Combine(Utx.Globale.Paths.CartellaUnitoolsRete, PathRelativo)
            Case Else 'A=percorso assoluto
                Return PathRelativo
        End Select
    End Function
End Class
