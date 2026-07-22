Imports System.Data.OleDb

Public Class Utente

    Sub New()
    End Sub

    Private mTelefono As Terminale
    Public Property Telefono() As Terminale
        Get
            Return mTelefono
        End Get
        Set(value As Terminale)
            mTelefono = value
        End Set
    End Property

    Private mInterno As Integer
    Public Property Interno() As Integer
        Get
            Return mInterno
        End Get
        Set(value As Integer)
            mInterno = value
            Me.Telefono = New Terminale(mInterno)
        End Set
    End Property

    Public ReadOnly Property StatoTelefono() As String
        Get
            If mTelefono IsNot Nothing AndAlso mTelefono.Ping Then
                Return "ON"
            Else
                Return "OFF"
            End If
        End Get
    End Property

End Class
