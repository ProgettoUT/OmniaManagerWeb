Public Class Formati

    Private mFormato As String

    Sub New(Formato As String)
        'il formato è archiviato in maiuscolo
        mFormato = Formato.ToUpper
    End Sub

    Public ReadOnly Property Formato() As String
        Get
            Return mFormato.ToLower
        End Get
    End Property

    Public ReadOnly Property Descrizione() As String
        Get
            Return String.Format("Formato file {0}", mFormato)
        End Get
    End Property

    Public ReadOnly Property IsPdf() As Boolean
        Get
            Return (mFormato = "PDF")
        End Get
    End Property

    Public ReadOnly Property IsTiff() As Boolean
        Get
            Return ((mFormato = "TIF") OrElse (mFormato = "TIFF"))
        End Get
    End Property

End Class
