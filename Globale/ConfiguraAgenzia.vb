Public Class ConfiguraAgenzia
    Inherits Utx.SettingAgenzia.ConfiguraSede

    Sub New()
        MyBase.New
        Me.Proxy = Utx.Globale.UniProxy.Proxy
        Me.CookieContainer = New Net.CookieContainer
        For Each c As Net.Cookie In Utx.Autenticazione.GetCookies(Utx.Globale.LoginUniage.CookieContainer)
            Me.CookieContainer.Add(c)
        Next
    End Sub

    Sub New(Cookie As Net.CookieContainer)
        MyBase.New
        Me.Proxy = Utx.Globale.UniProxy.Proxy
        Me.CookieContainer = New Net.CookieContainer
        For Each c As Net.Cookie In Utx.Autenticazione.GetCookies(Cookie)
            Me.CookieContainer.Add(c)
        Next
    End Sub
End Class

Public Class ConfigAgenzia

    Public ReadOnly Property Compagnia As Integer
    Public ReadOnly Property CodiceAgenzia As String
    Public ReadOnly Property CodiceSede As String
    Public ReadOnly Property CodiceUnisalute As String = ""
    Public ReadOnly Property Figlie As New List(Of ConfigCollegata)
    Public ReadOnly Property Config As DataTable

    Sub New(Compagnia As Integer, CodiceAgenzia As String, Optional CodiceSede As String = "00")
        Try
            _Compagnia = Compagnia
            _CodiceAgenzia = CodiceAgenzia
            _CodiceSede = CodiceSede

            Using s As New SettingAgenzia.ConfiguraSede
                'ricevo la configurazione dal server
                Dim ds As DataSet = s.ConfigAgenzia(_Compagnia, _CodiceAgenzia, _CodiceSede)

                If ds IsNot Nothing Then
                    Config = ds.Tables("Config")

                    For Each row As DataRow In Config.Rows
                        Dim Collegata = New ConfigCollegata(row)

                        If Collegata.Unisalute = "S" Then
                            CodiceUnisalute = Collegata.Codice
                        End If

                        Figlie.Add(Collegata)
                    Next
                End If
            End Using

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub
End Class

Public Class ConfigCollegata

    Public ReadOnly Property Codice As String
    Public ReadOnly Property Inizio As Date
    Public ReadOnly Property Fine As Date
    Public ReadOnly Property Provvigioni As String
    Public ReadOnly Property Avvisi As String
    Public ReadOnly Property ClientiPolizze As String
    Public ReadOnly Property Incassi As String
    Public ReadOnly Property Sinistri As String
    Public ReadOnly Property Unisalute As String
    Public ReadOnly Property AttivaMA As Boolean
    Public ReadOnly Property AttivaIncassi As Boolean

    Sub New(Dati As DataRow)
        Codice = Dati("Collegata")
        Inizio = Dati("DataInizio")
        Fine = Dati("DataFine")
        Provvigioni = Dati("Provvigioni").Trim
        Avvisi = Dati("Avvisi").Trim
        ClientiPolizze = Dati("ClientiPolizze").Trim
        Incassi = Dati("Incassi").Trim
        Sinistri = Dati("Sinistri").Trim
        Unisalute = Dati("Unisalute").Trim

        AttivaMA = (Fine >= Today)
        AttivaIncassi = Today <= Fine.AddMonths(4)
    End Sub
End Class
