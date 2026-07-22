Module ExtensionTabControl

    Private TabPageList As New List(Of TabPage)

    Public Sub HideTabPage(ByVal TControl As TabControl, ByVal TPageName As String)
        Dim TPage As TabPage = TControl.TabPages(TPageName)
        If TPage Is Nothing Then
            Throw New ApplicationException("Non esiste nessun TabPage con il nome indicato")
        Else
            TControl.TabPages.RemoveByKey(TPageName)
            TabPageList.Add(TPage)
        End If
    End Sub

    Public Sub ShowTabPage(ByVal TControl As TabControl, ByVal TPageName As String, Optional ByVal Index As Integer = -1)
        Dim TPage As TabPage = TabPageList.Find(Function(tmpPage) tmpPage.Name = TPageName)
        If TPage Is Nothing Then
            Throw New ApplicationException("Non esiste nessun TabPage con il nome indicato")
        Else
            If (Index >= 0) AndAlso Index < TControl.TabPages.Count Then
                TControl.TabPages.Insert(Index, TPage)
            Else
                TControl.TabPages.Add(TPage)
            End If
            TabPageList.Remove(TPage)
        End If
    End Sub
End Module
