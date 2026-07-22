Public Class ServizioSms

    Public Structure Pacchetto
        Dim NumeroSms As Integer
        Dim Costo As Double
    End Structure

    Public ReadOnly Property Abilitazione As Boolean

    Private ReadOnly _Costi As New ArrayList

    Sub New(Agenzia As Integer)
        Try
            Dim CostiSms As String
            Using s As New Utx.ServiziUniarea.accessoCasa
                s.Proxy = Utx.Globale.UniProxy.Proxy
                CostiSms = s.checkSmsW(Agenzia.ToString.PadLeft(5, "0"), Utx.Globale.ProfiloEnteGestore.Compagnia, Utx.NetFunc.TokenAccessoCasa)
            End Using

            _Abilitazione = (CostiSms <> "0")

            If _Abilitazione = True Then

                For Each s As String In CostiSms.Split(";")
                    If s.Trim.Length > 0 Then
                        Dim p As New Pacchetto With {.NumeroSms = s.Split("=")(0), .Costo = s.Split("=")(1)}
                        _Costi.Add(p)
                    End If
                Next
            End If

        Catch ex As Exception
            _Abilitazione = Utx.Globale.ProfiloEnteGestore.Abilitazioni.SMS
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Function PacchettoSms(NumeroSms As Integer) As Pacchetto
        Try
            For Each p As Pacchetto In _Costi
                If p.NumeroSms = NumeroSms Then
                    Return p
                End If
            Next
            Return PacchettoVuoto()

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return PacchettoVuoto()
        End Try
    End Function

    Private Function PacchettoVuoto() As Pacchetto
        Return New Pacchetto With {.NumeroSms = 0, .Costo = 0}
    End Function
End Class
