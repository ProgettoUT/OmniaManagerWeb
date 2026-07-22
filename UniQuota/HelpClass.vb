Public Class HelpClass
    Private mFileName As String
    Private mCodiceProdotto As String
    Private webBrowser As WebBrowser = Quotatore.helpBrowser

    Sub New()
    End Sub

    Public WriteOnly Property CodiceProdotto() As String
        Set(ByVal value As String)
            mCodiceProdotto = value
            mFileName = System.IO.Path.Combine(CARTELLA_EXE, mCodiceProdotto & ".chm")
        End Set
    End Property

    Public Sub GoHelp(ByVal control As System.Windows.Forms.Control)
        If control.Tag IsNot Nothing Then
            'Dim form As New Form()
            'form.CreateControl()
            'Help.ShowHelp(form, "HelpProtetto.chm", HelpNavigator.TopicId, control.Tag)
        End If
    End Sub

    Public Sub GoHelp(ByVal control As System.Windows.Forms.ToolStripButton)
        If control.Tag IsNot Nothing Then
            Dim form As New Form()
            form.CreateControl()
            Help.ShowHelp(form, mFileName, HelpNavigator.TableOfContents)
        End If
    End Sub

    Public Sub ShowHelp(ByRef control As System.Windows.Forms.Control)
        If TypeOf control Is System.Windows.Forms.Control Then
            If control.Tag IsNot Nothing Then
                If control.Tag <> "" Then
                    webBrowser.Navigate("mk:@MSITStore:" & mFileName & "::/html/" & mCodiceProdotto & "." & control.Tag & ".htm")
                End If
            End If
        End If
    End Sub

    Public Function FileExists() As Boolean
        Return FileIO.FileSystem.FileExists(mFileName)
    End Function

    Public Sub RunHelp()
        If FileExists() Then

            Dim info As New ProcessStartInfo
            info.FileName = mFileName
            info.WindowStyle = ProcessWindowStyle.Maximized
            Process.Start(info)
        Else
            MsgBox("Il file guida del prodotto non è stato trovato nel sistema", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Sub ShowPowerPoints(ByRef webBrowser As WebBrowser)
        webBrowser.Navigate("mk:@MSITStore:" & mFileName & "::/html/" & mCodiceProdotto & ".000.htm")
    End Sub

End Class
