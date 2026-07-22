Public Class TipoDocumentiLiquido

    Sub New(Descrizione As String,
            CodiceDocumento As Integer,
            Lira As String,
            Abbinamento As String)

        mDescrizione = Descrizione
        mCodiceDocumento = CodiceDocumento
        mLira = Lira
        mAbbinamento = Abbinamento
    End Sub

    Private mDescrizione As String
    Public ReadOnly Property Descrizione() As String
        Get
            Return mDescrizione
        End Get
    End Property

    Private mCodiceDocumento As Integer
    Public ReadOnly Property CodiceDocumento() As Integer
        Get
            Return mCodiceDocumento
        End Get
    End Property

    Private mLira As String
    Public ReadOnly Property Lira() As Boolean
        Get
            Return (mLira = "S")
        End Get
    End Property

    Private mAbbinamento As String
    Public ReadOnly Property Abbinamento() As String
        Get
            Return mAbbinamento
        End Get
    End Property
End Class
