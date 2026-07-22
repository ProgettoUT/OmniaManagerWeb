Public Class ProfiloUtente

    Private mProfilo As DataTableReader

    Sub New()
        LeggiProfilo()
    End Sub

    Private Sub LeggiProfilo()
        Try
            mProfilo = Utx.FunzioniDb.CreaDataTableReader("SELECT TOP 1 * FROM ProfiloUtente")
            mProfilo.Read()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public ReadOnly Property Compagnia() As String
        Get
            Return mProfilo("Compagnia")
        End Get
    End Property

    Public ReadOnly Property Agenzia() As String
        Get
            Return mProfilo("Agenzia")
        End Get
    End Property

    Public ReadOnly Property Sede() As String
        Get
            Return mProfilo("CodiceSede").ToString.Trim
        End Get
    End Property
End Class
