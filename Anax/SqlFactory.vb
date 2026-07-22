Option Explicit On
Imports Utx.FunzioniDb.Funzioni

Public Class SqlFactory

    Private mTabella As String = Nothing
    Private mWheres As String = Nothing
    Private mFields As New Dictionary(Of String, String)

    Public Property Tabella() As String
        Get
            Return mTabella
        End Get
        Set(value As String)
            If Left(value, 1) <> "[" Then
                mTabella = "[" & value & "]"
            Else
                mTabella = value
            End If
        End Set
    End Property

    Public WriteOnly Property Where(fieldName As String, fieldTipo As TipoEnum) As String
        Set(value As String)

            If mWheres <> Nothing Then
                mWheres &= " AND "
            Else
                mWheres &= ""
            End If

            If value = "" Then value = TO_DEFAULT(fieldTipo)

            mWheres &= "[" & fieldName & "] = " & TO_DB(value, fieldTipo)
        End Set
    End Property

    Public WriteOnly Property Field(fieldName As String, fieldTipo As TipoEnum) As String
        Set(value As String)
            mFields.Add("[" & fieldName & "]", TO_DB(value, fieldTipo))
        End Set
    End Property

    Public Function GetRecord() As DataTableReader
        Return Utx.FunzioniDb.CreaDataTableReader(GetSelectSql)
    End Function

    Public Function Insert() As Boolean
        Return Utx.FunzioniDb.Aggiorna(GetInsertSql)
    End Function

    Public Function Update() As Boolean
        Return Utx.FunzioniDb.Aggiorna(GetUpdateSql)
    End Function

    Public Function Delete() As Boolean
        Return Utx.FunzioniDb.Aggiorna(GetDeleteSql)
    End Function

    Public Sub ApriParentesiInWhere(Optional sOp As String = "OR")
        If mWheres = Nothing Then
            mWheres = "("
        Else
            mWheres &= sOp & "("
        End If
    End Sub
    Public Sub ChiudiParentesiInWhere()
        mWheres &= ")"
    End Sub

    Public Function GetSelectSql() As String
        Dim sSql As String

        sSql = "SELECT * FROM " & mTabella

        If mWheres <> Nothing Then
            sSql &= " WHERE " & mWheres
        End If

        GetSelectSql = sSql
    End Function

    Private Function GetInsertSql() As String
        'INSERT INTO COMUNI(campo1, campo2, ...) VALUES (val1, val2, ...);
        Dim sSql As String
        Dim sFields As String = ""
        Dim sValues As String = ""

        For Each s As String In mFields.Keys
            sFields &= ", " & s
            sValues &= ", " & mFields(s)
        Next

        sSql = "INSERT INTO " & mTabella _
             & "(" & sFields.Substring(2) & ") VALUES (" & sValues.Substring(2) & ")"

        GetInsertSql = sSql

    End Function

    Private Function GetUpdateSql() As String
        Dim sSql As String
        Dim sFields As String = ""

        sSql = "UPDATE " & mTabella & " SET "

        For Each s As String In mFields.Keys
            sFields &= ", " & s & " = " & mFields(s)
        Next

        sSql &= sFields.Substring(2)

        If mWheres <> Nothing Then
            sSql &= " WHERE " & mWheres
        End If

        GetUpdateSql = sSql
    End Function

    Private Function GetDeleteSql() As String
        Dim sSql As String

        sSql = "DELETE FROM " & mTabella

        If mWheres <> Nothing Then
            sSql &= " WHERE " & mWheres
        End If

        GetDeleteSql = sSql
    End Function

    Public Function GetNextPrg(sField As String) As String
        Dim sSql As String

        sSql = "SELECT MAX(" & sField & ") + 1 " & _
               "FROM " & mTabella

        If mWheres <> Nothing Then
            sSql &= " WHERE " & mWheres
        End If

        GetNextPrg = "1"

        With Utx.FunzioniDb.CreaDataTableReader(sSql)
            If .Read Then
                If Not .IsDBNull(0) Then
                    GetNextPrg = .GetValue(0)
                End If
            End If
            .Close()
        End With

        Return GetNextPrg
    End Function
End Class
