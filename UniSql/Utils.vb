Public Class Utils

    Public Shared Sub ErrorFound(
                     sCallingModName As String,
                     sCallingProcName As String,
                     lErrNumber As Long,
                     sErrDescription As String,
                     sErrSource As String,
                     Optional sParam As String = vbNullString
                         )
        mgrLogs.maErrorFound(sCallingModName, sCallingProcName, lErrNumber, sErrDescription, sErrSource, sParam)
    End Sub

    Public Shared Function Utente() As CUtente
        Return mgrPrf.Utente
    End Function

    Public Shared Function CreaListaInvio(ByRef recin As IDataReader) As IDataReader
        Return mgrExport.CreaListaInvio(recin)
    End Function

    Public Shared Function gridGetAsDataReader(oGrid As Windows.Forms.DataGridView) As IDataReader
        Return mgrGrid.gridGetAsRecordset(oGrid)
    End Function

    Public Shared Function gridGetAsDataTable(oGrid As Windows.Forms.DataGridView) As DataTable
        Dim dr As IDataReader = mgrGrid.gridGetAsRecordset(oGrid)
        If dr Is Nothing Then Return Nothing

        Dim data As New DataTable
        data.Load(dr)
        Return data
    End Function

    Public Shared Function gridSetting(oGrid As Windows.Forms.DataGridView, isLoading As Boolean, sFilePath As String)
        Return mgrGrid.gridSetting(oGrid, isLoading, sFilePath)
    End Function

    Public Shared Function CreaListaComunica(ByRef recin As IDataReader) As DataTable
        Return mgrExport.CreaListaComunica(recin)
    End Function
End Class
