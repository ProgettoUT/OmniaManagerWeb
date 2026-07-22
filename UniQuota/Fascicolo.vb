<Serializable()> Public Class Fascicolo
    Inherits Prodotto

    Public Prodotti As New List(Of Prodotto)


    Public Sub Add(prodotto As Prodotto)
        Prodotti.Add(prodotto)
        If Prodotti.Count = 1 Then
            Me.Cliente = prodotto.Cliente
            Me.Agenzia = prodotto.Agenzia
            Me.Subagenzia = prodotto.Subagenzia
            Me.Intermediario = prodotto.Intermediario
            Me.Frazionamento = prodotto.Frazionamento
            Me.Decode = prodotto.Decode
        End If
    End Sub

    Public Overrides Sub CalcolaListino()
        For Each prodotto As Prodotto In Prodotti
            Me.SommaListino(prodotto)
        Next
    End Sub

    Public Overrides Sub CalcolaTotali()
        For Each prodotto As Prodotto In Prodotti
            Me.SommaPremi(prodotto)
        Next
        If RischioDirezione > StatoPremio.ClasseOK Then
            MyBase.AzzerraPremi()
        End If
    End Sub

    Public Overrides Sub CalcolaLog()
    End Sub

    Public Overrides Function CleanRD() As Boolean
        Return MyBase.CleanRD()
    End Function


    Public Overrides Sub Calcola()
        AzzerraPremi()
        CalcolaListino()
        CalcolaTotali()
    End Sub

    Public Sub New()
        CodiceRamoPolizza = 0
        CodiceProdotto = TipoProdotto.Fascicolo
        DescrizioneProdotto = "Riepilogo"
    End Sub

    Public Overrides Sub Stampa(ByVal options As StampaOptions)
        options += StampaOptions.StampaFascicolo

        Dim s As New P00000ST()
        s.StampaInizio(Me, options)

        For Each prodotto As Prodotto In Prodotti
            prodotto.Stampa(options)
        Next

        s.StampaIntestazionePagina(Me, options)
        s.StampaRiepilogoPremi(Me, options)
        s.StampaFine(Me, options)
        s.StampaFineFascicolo()
        s.MostraEtInvia(Me, options)
    End Sub


    Public Overridable Sub CalcolaFrazionamento()
        For Each prodotto As Prodotto In Prodotti
            Me.Interessi += prodotto.Interessi
            Me.PremioPrimaRata += prodotto.PremioPrimaRata
            Me.PremioRataSuccessiva += prodotto.PremioRataSuccessiva
            Me.PremioAnnuo += prodotto.PremioAnnuo
        Next
    End Sub

End Class
