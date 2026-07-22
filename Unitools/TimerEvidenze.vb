Imports System.Timers
Imports System.ComponentModel
Imports System.IO
Imports System.Xml

Public Class TimerEvidenze

    Private Log As New Utx.ApplicationLog("InteropEvidenze.log")
    Private WithEvents Timer1 As New Timer
    Private RequestFilename As String
    Private ProcessFilename As String
    Private ResponseOkFilename As String
    Private ResponseKoFilename As String
    Private ExitFilename As String

    Sub New(filename As String)
        Me.RequestFilename = filename
        ResponseOkFilename = RequestFilename.Replace("REQUEST", "RESPONSE_OK")
        ResponseKoFilename = RequestFilename.Replace("REQUEST", "RESPONSE_KO")
        ExitFilename = RequestFilename.Replace("REQUEST", "EXIT")
        ProcessFilename = RequestFilename.Replace("REQUEST", "PROCESS")
        Timer1.Interval = 1000
        Timer1.Enabled = True
    End Sub

    Public Property TimerAbilitato() As Boolean
        Get
            Return Timer1.Enabled
        End Get
        Set(value As Boolean)
            Timer1.Enabled = value
        End Set
    End Property

    Private Sub Timer1_Elapsed(sender As Object, e As ElapsedEventArgs) Handles Timer1.Elapsed
        On Error Resume Next

        If IO.File.Exists(ExitFilename) Then
            Timer1.Enabled = False
            Timer1.Interval = 0
            IO.File.Delete(ExitFilename)
        ElseIf IO.File.Exists(RequestFilename) Then
            My.Computer.FileSystem.RenameFile(RequestFilename, Path.GetFileName(ProcessFilename))
            Dim nt As New Threading.Thread(AddressOf AvviaComunica)
            nt.SetApartmentState(Threading.ApartmentState.STA)
            nt.Start()
        End If
    End Sub

    Public Sub AvviaComunica()
        Try
            Application.DoEvents()
            Dim comunica As New UniCom.FormComunicazioni
            comunica.Chiamata = UniCom.FormComunicazioni.TipoChiamata.EVIDENZE
            comunica.Destinatari = CreaDatatable()
            Application.DoEvents()
            comunica.ShowDialog()
            If File.Exists(ProcessFilename) Then
                If comunica.MessaggiInviati Then
                    My.Computer.FileSystem.RenameFile(ProcessFilename, Path.GetFileName(ResponseOkFilename))
                Else
                    My.Computer.FileSystem.RenameFile(ProcessFilename, Path.GetFileName(ResponseKoFilename))
                End If
            End If
        Catch ex As Exception
            Log.Info(ex.Message)
        End Try
    End Sub

    Private Function CreaDatatable() As DataTable
        Dim table As DataTable = Nothing

        Try
            Dim xml As New XmlDocument
            xml.Load(ProcessFilename)
            For Each promemoria As XmlNode In xml.SelectNodes("promemorie/promemoria")
                If table Is Nothing Then
                    table = New DataTable()
                    With table.Columns
                        For Each campo As XmlNode In promemoria.ChildNodes
                            .Add(campo.Name, GetType(String))
                        Next
                    End With
                End If

                Dim row As DataRow = table.NewRow()
                For Each campo As XmlNode In promemoria.ChildNodes
                    row(campo.Name) = campo.InnerText
                Next
                table.Rows.Add(row)
            Next
        Catch ex As Exception
            Log.Info(ex.Message)
        End Try
        Return table
    End Function
End Class
