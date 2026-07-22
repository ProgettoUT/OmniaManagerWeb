Imports System.IO

Public Class GestioneFlag

    Sub New(ByVal CartellaFlag As String)

        Try
            mCartellaFlag = CartellaFlag
            Directory.CreateDirectory(mCartellaFlag)

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
        End Try
    End Sub

    Private mCartellaFlag As String
    Public Property CartellaFlag() As String
        Get
            Return mCartellaFlag
        End Get
        Set(ByVal value As String)
            mCartellaFlag = value
        End Set
    End Property

    Public Function CreaFlag(ByVal ID As String,
                             Optional ByVal TestoFlag As String = "Flag") As Boolean

        Try
            Using sw As New StreamWriter(FullNameFlag(ID), False)
                sw.WriteLine(String.Format("{0}|{1}", TestoFlag, Format(Now, "dd/MM/yyyy HH:mm:ss")))
                sw.Close()
            End Using

            Return True

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
            Return False
        End Try

    End Function

    ''' <summary>
    ''' cancella il flag 
    ''' </summary>
    ''' <param name="ID">tipo di flag da cancellare</param>
    ''' <remarks></remarks>
    Public Sub CancellaFlag(ByVal ID As String)

        Try
            File.Delete(FullNameFlag(ID))

        Catch ex As Exception
            Globale.Log.BoxErrore(ex)
        End Try
    End Sub

    ''' <summary>
    ''' controllo esistenza flag work in progress (wip) e se esiste se è scaduto
    ''' se è scaduto (dopo MaxDurataMinuti espresso in minuti) viene cancellato
    ''' </summary>
    ''' <param name="MaxDurataMinuti">massima durata del flag dopo la quale viene cancellato</param>
    ''' <returns>True se il flag esiste</returns>
    ''' <remarks></remarks>
    Public Function EsisteFlag(ByVal ID As String,
                               ByVal MaxDurataMinuti As Integer) As Boolean

        Dim Flag As String = FullNameFlag(ID)

        Try
            If File.Exists(Flag) Then

                'tipo di contenuto
                Dim Contenuto() As String = File.ReadAllText(Flag).Split("|")


                'se il file esiste controlla la data di creazione scritta nel testo
                Dim Data As Date = CDate(File.ReadAllText(Flag).Split("|")(1))

                'se è stato creato da più di 30 minuti è probabile ci sia stato un blocco
                'e quindi il flag viene rimosso
                If DateDiff(DateInterval.Minute, Data, Date.Now) > MaxDurataMinuti Then
                    CancellaFlag(ID)
                End If
            End If

        Catch ex As Exception
            CancellaFlag(ID)
            Globale.Log.BoxErrore(ex)
        End Try

        Return File.Exists(Flag)

    End Function

    Public Function FullNameFlag(ByVal ID As String) As String
        Return Path.Combine(mCartellaFlag, String.Format("Flag.{0}", ID))
    End Function

    Public Function DataOraFlag(ByVal ID As String) As Date

        Try
            If File.Exists(FullNameFlag(ID)) Then

                Using sr As New StreamReader(FullNameFlag(ID))
                    DataOraFlag = sr.ReadLine.Split("|")(1)
                    sr.Close()
                End Using
            Else
                Return #1/1/2000#
            End If

        Catch ex As Exception
            Return #1/1/2000#
        End Try

    End Function

End Class
