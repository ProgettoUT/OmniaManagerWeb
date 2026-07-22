Imports UniQuota.Essig

Namespace PSMART
    Public Class PSMARTES
        Inherits P00000ES

        Public Sub New(preventivo As Prodotto)
            Me.preventivo = preventivo
        End Sub

        Public Overrides Function Esporta() As Essig.Esito
            Dim e As Esito = MyBase.Esporta()

            If e IsNot Nothing Then
                Return e
            End If

            navigatore.Reset()
            navigatore.Inizializza("P01202ES")
            navigatore.AddStadio(preventivo, 0)

            navigatore.Process()

            Return navigatore.Esito
        End Function

    End Class
End Namespace
