Imports System.IO

Public Class OrigineBackup

    Dim mInfo As FileInfo
    Dim mPc As String

    Sub New(ByVal PathFile As String, Optional ByVal Pc As String = "ND")
        mInfo = New FileInfo(PathFile)
        mPc = Pc
    End Sub

    Public ReadOnly Property InfoBackup() As String
        Get
            Return String.Format("{0} - {1} - {2}", mInfo.LastWriteTime, mPc, mInfo.Name)
        End Get
    End Property

    Public ReadOnly Property FullName() As String
        Get
            Return mInfo.FullName
        End Get
    End Property

    Public ReadOnly Property Name() As String
        Get
            Return mInfo.Name
        End Get
    End Property

    Public ReadOnly Property LastWriteTime() As Date
        Get
            Return mInfo.LastWriteTime
        End Get
    End Property

End Class
