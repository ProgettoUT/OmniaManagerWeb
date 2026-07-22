Imports System.IO

Public Class Globale

    'variabili condivise globali
    Public Shared Log As New Utx.ApplicationLog("UniCom.log")

    Public Enum TipoPratica
        CLIENTE = 0
        POLIZZA = 1
        SINISTRO = 2
        ND = 3
    End Enum

    Public Shared Function ImpostaDominio() As String
        Return "uniage"
    End Function

    Public Shared Function TipologiaPratica(IdPratica As String) As TipoPratica
        Try
            If IdPratica.StartsWith("Sinistro", StringComparison.InvariantCultureIgnoreCase) Then
                Return TipoPratica.SINISTRO
            ElseIf IdPratica.StartsWith("Polizza", StringComparison.InvariantCultureIgnoreCase) Then
                Return TipoPratica.POLIZZA
            Else
                Return TipoPratica.ND
            End If

        Catch ex As Exception
            Return TipoPratica.ND
        End Try

    End Function

    Public Shared Function AgenziaSinistro(IdPratica As String) As Integer
        Try
            'tolgo la parola sinistro
            IdPratica = IdPratica.Substring(8)

            Return IdPratica.Split(".")(0)

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return 0
        End Try

    End Function

    Public Shared Function EsercizioSinistro(IdPratica As String) As Integer
        Try
            'tolgo la parola sinistro
            IdPratica = IdPratica.Substring(8)

            Return IdPratica.Split(".")(1)

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return 0
        End Try

    End Function

    Public Shared Function NumeroSinistro(IdPratica As String) As Integer
        Try
            'tolgo la parola sinistro
            IdPratica = IdPratica.Substring(8)

            Return IdPratica.Split(".")(2)

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return 0
        End Try

    End Function
End Class
