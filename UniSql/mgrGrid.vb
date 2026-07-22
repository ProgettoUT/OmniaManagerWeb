Imports System.Xml

Module mgrGrid
    Public Function gridGetAsRecordset(oGrid As Windows.Forms.DataGridView) As IDataReader
        Try

            Dim rsOld As DataTable = oGrid.DataSource
            If rsOld Is Nothing Then Return Nothing

            Dim rsNew As DataTable = rsOld.Clone

            For i As Integer = 0 To oGrid.RowCount - 1
                If oGrid.Rows(i).Cells(0).Value = True Then
                    rsNew.ImportRow(CType(oGrid.Rows(i).DataBoundItem, DataRowView).Row)
                End If
            Next

            Return rsNew.CreateDataReader

        Catch ex As Exception
            maErrorFound("mgrGrid", "gridGetAsRecordset", Err.Number, Err.Description, Err.Source)
        End Try

        Return Nothing
    End Function

    Public Function gridSetting(oGrid As Windows.Forms.DataGridView, isLoading As Boolean, sFilePath As String) As Boolean

        Dim sFileUtenteName As String
        Dim x As New CXml
        Dim key As String
        Dim i, k As Integer

        If oGrid Is Nothing Then Return False
        If sFilePath = vbNullString Then Return False

        Dim sUtente As String = System.Environment.UserName

        Try
            sFileUtenteName = LCase(sFilePath & "." & sUtente & ".viewgrid.xml")

            With oGrid
                If isLoading Then

                    If Dir(sFileUtenteName) = vbNullString Then
                        sFileUtenteName = LCase(sFilePath & ".viewgrid.xml")
                    End If
                    If Dir(sFileUtenteName) <> vbNullString Then
                        If x.LoadXML(sFileUtenteName) Then
                            Dim n As XmlNode
                            For Each n In x.GetNodes("/Grid/Columns/Column")
                                key = x.GetNodeText("ColumnKey", n)
                                If IsNumeric(key) Then
                                    k = CInt(key)
                                    If k > 1 And k <= .Columns.Count Then
                                        .Columns(k - 1).Width = CLng(x.GetNodeText("ColumnWidth", n))
                                    End If
                                End If
                            Next
                        End If
                    End If
                    x = Nothing
                ElseIf oGrid.Rows.Count > 0 Then
                    Dim r As XmlNode
                    r = x.CreateNode("Grid")

                    With r.AppendChild(x.CreateNode("Columns"))
                        For i = 0 To oGrid.Columns.Count - 1
                            With .AppendChild(x.CreateNode("Column"))
                                .AppendChild(x.CreateNodeText("ColumnKey", "" & 1 + i))
                                .AppendChild(x.CreateNodeText("ColumnWidth", "" & oGrid.Columns(i).Width))
                            End With
                        Next
                    End With
                    x.Document.AppendChild(r)
                    x.SaveXML(sFileUtenteName)
                    x = Nothing
                End If
            End With

        Catch ex As Exception
        End Try

        Return True
    End Function
End Module
