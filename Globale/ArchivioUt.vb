Public Class ArchivioUt

    Sub New(TipoArchivio As Enumerazioni.TipoFileMagia,
            Descrizione As String)

        mTipoArchivio = TipoArchivio
        mDescrizione = Descrizione
    End Sub

    Sub New(TipoArchivioDoc As Enumerazioni.TipoFileDoc,
            Descrizione As String)

        mTipoArchivioDoc = TipoArchivioDoc
        mDescrizione = Descrizione
    End Sub

    Private mTipoArchivio As Enumerazioni.TipoFileMagia
    Public Property TipoArchivio() As Enumerazioni.TipoFileMagia
        Get
            Return mTipoArchivio
        End Get
        Set(value As Enumerazioni.TipoFileMagia)
            mTipoArchivio = value
        End Set
    End Property

    Private mTipoArchivioDoc As Enumerazioni.TipoFileDoc
    Public Property TipoArchivioDoc() As Enumerazioni.TipoFileDoc
        Get
            Return mTipoArchivioDoc
        End Get
        Set(value As Enumerazioni.TipoFileDoc)
            mTipoArchivioDoc = value
        End Set
    End Property

    Private mDescrizione As String
    Public Property Descrizione() As String
        Get
            Return mDescrizione
        End Get
        Set(value As String)
            mDescrizione = value
        End Set
    End Property

    Public ReadOnly Property StringaTipoArchivio() As String
        Get
            Return Val(mTipoArchivio).ToString.PadLeft(2, "0")
        End Get
    End Property

    Public Shared Function TipoFile2Stringa(Tipo As Enumerazioni.TipoFileMagia) As String
        Return Val(Tipo).ToString.PadLeft(2, "0")
    End Function
End Class
