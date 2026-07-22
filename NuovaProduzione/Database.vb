Imports System.Data.OleDb
Module Database
    Public oConn As New OleDbConnection

    Public Sub DatabaseClose()
        If oConn.State <> ConnectionState.Closed Then
            oConn.Close()
        End If
    End Sub

    Public Function CreaRecordset(ByRef sSql As String) As OleDbDataReader
        Try
            If oConn.State = ConnectionState.Closed Then
                oConn.ConnectionString = Utx.Globale.CnDbLink
                oConn.Open()
            End If

            Dim objCmd As New OleDbCommand(sSql, oConn)
            Return objCmd.ExecuteReader()
        Catch e As Exception
            MsgBox("Errore nell'estrazione: " & e.Message)
            Return Nothing
        End Try
    End Function

    'Public Function TO_DATE(sData As String) As String
    '    Dim Data As Date


    '    If IsDate(sData) Then
    '        Data = CDate(sData)
    '        If Data > System.DateTime.FromOADate(0) Then
    '            TO_DATE = "#" & Format(Data, "MM/dd/yyyy") & "#"
    '        Else
    '            TO_DATE = "NULL"
    '        End If
    '    Else
    '        TO_DATE = "NULL"
    '    End If

    'End Function

    'Public Function TO_STRING(sStringa As String) As String
    '    If sStringa <> vbNullString Then
    '        TO_STRING = "'" & Replace(sStringa, "'", "''") & "'"
    '    Else
    '        TO_STRING = "''" '= "NULL"
    '    End If
    'End Function
End Module
