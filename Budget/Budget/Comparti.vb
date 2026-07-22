Public Class InsiemeComparti

    Private Comparti As List(Of Comparto)

    Sub New()
        Comparti = New List(Of Comparto)
    End Sub

    Public Sub Add(comparto As Integer, ByRef Controllo As TextBoxComparto)
        Comparti.Add(New Comparto(comparto, Controllo))
    End Sub

    Public Function Controllo(Comparto As Integer) As TextBoxComparto
        For Each com As Comparto In Comparti
            If com.Controllo.Comparto = Comparto Then
                Return com.Controllo
            End If
        Next
        Return Nothing
    End Function
End Class

Public Class Comparto

    Sub New(Comparto As Integer, ByRef Controllo As TextBoxComparto)
        mControllo = Controllo
        mControllo.Comparto = Comparto
    End Sub

    Private mControllo As TextBoxComparto
    Public ReadOnly Property Controllo() As TextBoxComparto
        Get
            Return mControllo
        End Get
    End Property

    Public Function Comparto() As Integer
        Return Comparto(mControllo.Comparto)
    End Function

    Public Shared Function Comparto(RamoGestione As Integer) As Integer
        For Each row As DataRow In Globale.RgToComparto.Rows
            If row("RamoGestione") = RamoGestione Then
                Return row("Comparto")
            End If
        Next
        Return 0
    End Function

    Public Shared Function RamiGestione(Comparto As Integer) As List(Of Integer)
        RamiGestione = New List(Of Integer)
        For Each row As DataRow In Globale.RgToComparto.Rows
            If row("Comparto") = Comparto Then
                If row("RamoGestione") <> 15 Then
                    RamiGestione.Add(row("RamoGestione"))
                End If
            End If
        Next
    End Function
End Class
