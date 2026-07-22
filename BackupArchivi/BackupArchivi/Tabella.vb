Public Class Tabella

    Sub New()
    End Sub

    Sub New(ByVal Database As String,
            ByVal Nome As String,
            ByVal Descrizione As String,
            ByVal Records As Integer,
            ByVal Check As Boolean)

        mDatabase = Database
        mNome = Nome
        mDescrizione = Descrizione
        mRecords = Records
        mCheck = Check
    End Sub

    Private mDatabase As String
    Public Property Database() As String
        Get
            Return mDatabase
        End Get
        Set(ByVal value As String)
            mDatabase = value
        End Set
    End Property

    Private mNome As String
    Public Property Nome() As String
        Get
            Return mNome
        End Get
        Set(ByVal value As String)
            mNome = value
        End Set
    End Property

    Private mDescrizione As String
    Public Property Descrizione() As String
        Get
            Return mDescrizione
        End Get
        Set(ByVal value As String)
            mDescrizione = value
        End Set
    End Property

    Private mRecords As Integer
    Public Property Records() As Integer
        Get
            Return mRecords
        End Get
        Set(ByVal value As Integer)
            mRecords = value
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

End Class
