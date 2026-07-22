Public Class InsiemeRamiGestione

    Private RamiGestione As List(Of RamoGestione)

    Sub New()
        RamiGestione = New List(Of RamoGestione)
    End Sub

    Public Sub Add(RamoGestione As Integer, ByRef Controllo As TextBoxRG)
        RamiGestione.Add(New RamoGestione(RamoGestione, Controllo))
    End Sub

    Public Function Controllo(RamoGestione As Integer) As TextBoxRG
        For Each rg As RamoGestione In RamiGestione
            If rg.Controllo.RamoGestione = RamoGestione Then
                Return rg.Controllo
            End If
        Next
        Return Nothing
    End Function
End Class

Public Class RamoGestione

    Sub New(RamoGestione As Integer, ByRef Controllo As TextBoxRG)
        mControllo = Controllo
        mControllo.RamoGestione = RamoGestione
    End Sub

    Private mControllo As TextBoxRG
    Public ReadOnly Property Controllo() As TextBoxRG
        Get
            Return mControllo
        End Get
    End Property

    Public Function Comparto() As Integer
        Return Budget.Comparto.Comparto(mControllo.RamoGestione)
    End Function
End Class