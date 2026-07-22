<Serializable()> Public Class CoperturaStampa
    Inherits CoperturaComposta

    Public Overrides Sub AzzerraPremi()
        'do nothing
    End Sub

    Public Overrides Sub CalcolaListino()
        For Each Copertura As Copertura In Coperture
            If Copertura.IsAttivo() Then
                Me.SommaListino(Copertura)
            End If
        Next
    End Sub

    Public Overrides Sub CalcolaCoperture()
        'do nothing
    End Sub

    Public Overrides Sub CalcolaTotali()
        For Each Copertura As Copertura In Coperture
            If Copertura.IsAttivo() Then
                Me.SommaPremi(Copertura)
            End If
        Next
    End Sub

    Public Overrides Sub CalcolaLog()
    End Sub

    Public Overrides Function CleanRD() As Boolean
        Return MyBase.CleanRD()
    End Function

    Public Overrides Sub AzzeraTariffa()
    End Sub


    Public Sub New(ByVal ParamArray coperture() As List(Of Copertura))
        For Each c As List(Of Copertura) In coperture
            Me.Coperture.AddRange(c)
        Next
        CalcolaListino()
        CalcolaTotali()
    End Sub
End Class
