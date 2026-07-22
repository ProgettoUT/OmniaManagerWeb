Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Public Class NetLog
    <Serializable()> Private Class InfoLog
        Public Compagnia As String
        Public Agenzia As String
        Public Uid As String
        Public Prodotto As String
        Public DataOra As DateTime
        Public Modalita As String
    End Class

    Private infologs As Collections.Generic.List(Of InfoLog)
    Private FileName As String
    Private TimerDelegate As New System.Threading.TimerCallback(AddressOf TimerTask)
    Private TimerItem As New System.Threading.Timer(TimerDelegate, Nothing, 60000, 300000)

    Public Sub Add(ByVal Prodotto As String, Modalita As String)
#If RELEASE Or VALUTAZIONE Then
        Dim info As New InfoLog
        With Globale.licenza
            info.Compagnia = .CodiceCompagnia
            info.Agenzia = .CodiceAgenzia
            info.Uid = .UID
            info.Prodotto = Prodotto
            info.DataOra = Now
            info.Modalita = Modalita
        End With

        infologs.Add(info)
        Send()
#End If
    End Sub

    Private Sub Send()
#If RELEASE Or VALUTAZIONE Then
        Try
            If infologs.Count > 0 Then
                Dim attivazione As New Uniarea.Uniquota
                attivazione.Proxy = Utx.Globale.UniProxy.Proxy

                While infologs.Count > 0
                    With infologs(0)
                        Dim esito As Uniarea.Esito = attivazione.RegistraQuotazione(.Compagnia, .Agenzia, .Uid, .Prodotto, .DataOra, .Modalita)
                        If esito.Errore Is Nothing OrElse esito.Errore = "0" Then
                            infologs.RemoveAt(0)
                        End If
                    End With
                End While

            End If
        Catch ex As Exception
        End Try
#End If
    End Sub

    Public Sub New()
        Try
            FileName = Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "UniQuota.use")
            If File.Exists(FileName) Then
                Dim fs As FileStream = File.Open(FileName, FileMode.Open)
                Dim bf As New BinaryFormatter()
                infologs = CType(bf.Deserialize(fs), Collections.Generic.List(Of InfoLog))
                fs.Close()
            End If
        Catch ex As Exception
        End Try

        If infologs Is Nothing Then
            infologs = New Collections.Generic.List(Of InfoLog)
        End If
    End Sub

    Protected Overrides Sub Finalize()
        Try
            If infologs.Count = 0 And File.Exists(FileName) Then
                File.Delete(FileName)
            Else
                Dim fs As FileStream = File.Open(FileName, FileMode.Create)
                Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter()
                bf.Serialize(fs, infologs)
                fs.Close()
            End If
            TimerItem.Dispose()
        Catch ex As Exception
        End Try

        MyBase.Finalize()
    End Sub


    Private Sub TimerTask(ByVal StateObj As Object)
        Send()
    End Sub

End Class
