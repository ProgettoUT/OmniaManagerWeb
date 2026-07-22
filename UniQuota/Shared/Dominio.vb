
Public Class Dominio
    Public Shared Divisioni As New Dictionary(Of String, Divisione)

    Shared Sub New()
        Try
            With Divisioni
                .Add("034", New Divisione("034", "Sai"))
                .Add("082", New Divisione("082", "Unipol"))
                .Add("010", New Divisione("010", "Aurora"))
                .Add("049", New Divisione("049", "Navale"))
                '.Add("018", New Divisione("018", "La Fondiaria"))
                '.Add("007", New Divisione("007", "Milano"))
                '.Add("009", New Divisione("009", "Nuova Maa"))
            End With
        Catch ex As Exception
        End Try
    End Sub
End Class


Public Class Divisione
    Public Codice As String
    Public Denominazione As String

    Public Sub New(ByVal Codice As String, ByVal Denominazione As String)
        Me.Codice = Codice
        Me.Denominazione = Denominazione
    End Sub

    Public Overrides Function ToString() As String
        Return Denominazione
    End Function
End Class
