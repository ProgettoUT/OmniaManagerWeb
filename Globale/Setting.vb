Imports System.IO

Public Class Setting

    Private Shared mAmbiente As Enumerazioni.TipoAmbiente
    Public Shared Property Ambiente() As Enumerazioni.TipoAmbiente
        Get
            Return mAmbiente
        End Get
        Set(value As Enumerazioni.TipoAmbiente)
            mAmbiente = value
        End Set
    End Property
End Class
