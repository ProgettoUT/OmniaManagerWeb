Imports UniQuota.Essig

Namespace P07261
    Public Class P07261ES
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
            navigatore.Inizializza("P07261ES")

            With CType(preventivo, youCasa)
                navigatore.AddStadio(preventivo, 0)
                For Each Abitazione In .AbitazioneX
                    navigatore.AddStadio(Abitazione, 1)
                Next
                navigatore.AddStadio(preventivo, 2)
            End With

            navigatore.Process()
            Return navigatore.Esito
        End Function
    End Class
End Namespace
