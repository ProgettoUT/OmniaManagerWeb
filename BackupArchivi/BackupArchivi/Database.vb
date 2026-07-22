Public Class Database

    Implements IComparable(Of Database)

    Sub New()
    End Sub

    Sub New(ByVal Nome As String, Check As Boolean)
        mNome = Nome
        mCheck = Check
    End Sub

    Private mNome As String
    Public Property Nome() As String
        Get
            Return mNome
        End Get
        Set(ByVal value As String)
            mNome = value
        End Set
    End Property

    Private mCheck As Boolean
    Public Property Check() As Boolean
        Get
            Return mCheck
        End Get
        Set(ByVal value As Boolean)
            mCheck = value
        End Set
    End Property

    Public Function CompareTo(other As Database) As Integer Implements IComparable(Of Database).CompareTo
        Return Me.Nome.CompareTo(other.Nome)
    End Function
End Class
