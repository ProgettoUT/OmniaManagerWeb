Imports UniQuota.Essig

Public Class P00000ES
    Public WithEvents navigatore As New Navigatore

    Protected preventivo As Prodotto

    Public Overridable Function Esporta() As Esito
        If WebEngine.IsLogged() = False Then
            Return New Esito("Impossibile salvare in Essig.")
        End If

        If preventivo.Subagenzia Is Nothing Then
            preventivo.Subagenzia = Essig.Elenco.Subagenzie(preventivo.Agenzia.Compagnia, preventivo.Agenzia.Codice).Item(0)
        End If
        If preventivo.Intermediario Is Nothing Then
            preventivo.Intermediario = Essig.Elenco.Intermediari(preventivo.Agenzia.Compagnia, preventivo.Agenzia.Codice).Item(0)
        End If
        If preventivo.Cliente.CodiceFiscale = "" Then
            Return New Esito(1, "Inserire il codice fiscale del cliente/contraente")
        End If

        Return Nothing
    End Function

End Class
