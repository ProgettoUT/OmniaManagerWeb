
Public MustInherit Class TBase
    Public Const DELIMITER As String = "/"
    Private gLastErrorDescription As String

    Private Enum StateObjectEnum
        StateEmpty
        StateNew
        StateUpdated
        StateModified
    End Enum

    Private mStateObject As StateObjectEnum
    Private mLastError As String

    Protected Friend MustOverride ReadOnly Property Tabella() As String
    Public MustOverride Property Key() As String
    Public MustOverride Function GetFields(rs As DataTableReader) As Boolean

    Protected MustOverride Sub SetUnchangedMember()
    Protected MustOverride Function GetSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory
    Protected MustOverride Function PutSqlKey(Optional sql As SqlFactory = Nothing) As SqlFactory
    Protected MustOverride Function PutSqlFields(sql As SqlFactory) As SqlFactory

    Public Function Load(sKey As String) As TBase
        Key = sKey
        GetFields()
        Return Me
    End Function

    Public Function GetFields() As Boolean
        Dim rs As DataTableReader = GetSqlKey.GetRecord
        If rs.Read() Then
            Return GetFields(rs)
        Else
            Return True
        End If
    End Function

    Public Overridable Function Save() As Boolean
        If mStateObject = StateObjectEnum.StateNew Then
            Return Insert()
        ElseIf mStateObject = StateObjectEnum.StateModified Then
            Return Update()
        Else
            Return True
        End If
    End Function

    Public Function Insert() As Boolean
        If mStateObject <> StateObjectEnum.StateNew Then
            Return True
        ElseIf PutSqlFields(PutSqlKey).Insert() Then
            SetUpdatedMember()
            Return True
        Else
            mLastError = gLastErrorDescription
            Return False
        End If
    End Function

    Public Function Update() As Boolean
        If mStateObject <> StateObjectEnum.StateModified Then
            Return True
        ElseIf PutSqlFields(GetSqlKey).Update() Then
            SetUpdatedMember()
            Return True
        Else
            mLastError = gLastErrorDescription
            Return False
        End If
    End Function

    Public Function Delete() As Boolean
        If mStateObject = StateObjectEnum.StateEmpty _
        Or mStateObject = StateObjectEnum.StateNew Then
            Return True
        ElseIf GetSqlKey.Delete Then
            SetNewMember()
            Return True
        Else
            mLastError = gLastErrorDescription
            Return False
        End If
    End Function

    Private Function GetAsDataReader(Optional sKey As String = Nothing) As DataTableReader
        If sKey <> Nothing Then Key = sKey
        Return GetSqlKey.GetRecord
    End Function

    Private Function GetLastError() As String
        Return mLastError
    End Function

    Public Sub New()
        mStateObject = StateObjectEnum.StateEmpty
    End Sub

    Protected Sub SetNewMember()
        mStateObject = StateObjectEnum.StateNew
        SetUnchangedMember()
    End Sub

    Protected Sub SetUpdatedMember()
        mStateObject = StateObjectEnum.StateUpdated
        SetUnchangedMember()
    End Sub

    Protected Sub SetModifiedState()
        If mStateObject = StateObjectEnum.StateUpdated Then
            mStateObject = StateObjectEnum.StateModified
        ElseIf mStateObject = StateObjectEnum.StateEmpty Then
            mStateObject = StateObjectEnum.StateNew
        End If
    End Sub

    Protected Sub SetStateEmpty()
        mStateObject = StateObjectEnum.StateEmpty
    End Sub

    Public Function IsNew() As Boolean
        Return (mStateObject = StateObjectEnum.StateEmpty) Or (mStateObject = StateObjectEnum.StateNew)
    End Function

    Public Function IsModifiedState() As Boolean
        Return (mStateObject = StateObjectEnum.StateModified) Or (mStateObject = StateObjectEnum.StateNew)
    End Function

    Public Function IsUpdated() As Boolean
        Return (mStateObject = StateObjectEnum.StateUpdated)
    End Function

    Public Overridable Function IsValid() As Boolean
        Return True
    End Function
End Class
