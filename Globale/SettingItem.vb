Public Class SettingItem

    Public Enum Sezioni
        AUTOMATISMI
        INTEROP
        ESCLUSIONI
        INFO
        COMUNICATORE
        VERSIONE
        SETTING
    End Enum
    Public Enum Chiavi
        IMPORTAZIONE_INCASSI
        IMPORTAZIONE_MA
        IMPORTAZIONE_DL
        LISTE_UTENTI
        IMPORTAZIONE_ARRETRATI
        UNIFEED
        NOTIFICHE_SMS
        COMUNICATORE_NOTIFICHE
        COMUNICATORE_UTENTI
        COMUNICATORE_RID
        COMUNICATORE_DOMICILIO
        COMUNICATORE_CODICI_ABILITATI
    End Enum
    Public Enum Valori
        BLOCCO
    End Enum

    Public ItemRequest As New SettingOMW.SettingItem With {.Utente = Globale.UtenteCorrente.UniageUser}
    Public ItemResult As SettingOMW.SettingItem

    Public Property CodiceAgenzia As String

    Sub New(Optional Agenzia As String = "")
        If Agenzia.Length = 5 Then CodiceAgenzia = Agenzia
    End Sub

    Sub New(Sezione As Sezioni, Chiave As Chiavi)
        CodiceAgenzia = Globale.AgenziaRichiesta.CodiceAgenzia
        ItemRequest.Sezione = Sezione.ToString
        ItemRequest.Chiave = Chiave.ToString
    End Sub

    Sub New(Sezione As Sezioni, Chiave As Chiavi, Operazione As SettingOMW.TipoOperazione)
        CodiceAgenzia = Globale.AgenziaRichiesta.CodiceAgenzia
        ItemRequest.Sezione = Sezione.ToString
        ItemRequest.Chiave = Chiave.ToString
        Me.Operazione = Operazione
    End Sub

    Sub New(Sezione As Sezioni, Chiave As Chiavi, Valore As String, Operazione As SettingOMW.TipoOperazione)
        CodiceAgenzia = Globale.AgenziaRichiesta.CodiceAgenzia
        ItemRequest.Sezione = Sezione.ToString
        ItemRequest.Chiave = Chiave.ToString
        ItemRequest.Valore = Valore.ToString
        Me.Operazione = Operazione
    End Sub

    Sub New(Sezione As Sezioni, Chiave As String, Valore As String, Operazione As SettingOMW.TipoOperazione)
        CodiceAgenzia = Globale.AgenziaRichiesta.CodiceAgenzia
        ItemRequest.Sezione = Sezione.ToString
        ItemRequest.Chiave = Chiave
        ItemRequest.Valore = Valore
        Me.Operazione = Operazione
    End Sub

    Public Sub SetItem(Sezione As Sezioni, Chiave As Chiavi, Valore As String, Operazione As SettingOMW.TipoOperazione)
        'il codice agenzia risulta già impostato nel new
        ItemRequest.Sezione = Sezione.ToString
        ItemRequest.Chiave = Chiave.ToString
        ItemRequest.Valore = Valore.ToString
        Me.Operazione = Operazione
    End Sub

    Public Sub SetItem(Sezione As Sezioni, Chiave As String, Valore As String, Operazione As SettingOMW.TipoOperazione)
        'il codice agenzia risulta già impostato nel new
        ItemRequest.Sezione = Sezione.ToString
        ItemRequest.Chiave = Chiave
        ItemRequest.Valore = Valore
        Me.Operazione = Operazione
    End Sub

    Private _Operazione As SettingOMW.TipoOperazione
    Public Property Operazione() As SettingOMW.TipoOperazione
        Get
            Return _Operazione
        End Get
        Set(value As SettingOMW.TipoOperazione)
            _Operazione = value

            If _Operazione <> SettingOMW.TipoOperazione.NESSUNA Then
                ItemRequest.Operazione = _Operazione
#If DEBUG Then
                ItemRequest.Utente = Utx.Globale.UtenteCorrente.UniageUser.Substring(0, 6) & "GL"
#End If

                Using s As New SettingOMW.GestioneSetting
                    s.Proxy = Utx.Globale.UniProxy.Proxy
                    'qui leggo, scrivo o cancello la chiave ottenendo il risultato
                    ItemResult = s.ElaboraChiave(CodiceAgenzia, ItemRequest, Globale.Token)
                    AnalisiResult()
                End Using
            End If
        End Set
    End Property

    Private Sub AnalisiResult()
        Try
            Select Case ItemResult.Chiave
                Case Chiavi.IMPORTAZIONE_INCASSI.ToString, Chiavi.IMPORTAZIONE_MA.ToString, Chiavi.LISTE_UTENTI.ToString
                    If ItemResult.Operazione = SettingOMW.TipoOperazione.LETTURA Then
                        If (ItemResult.Esiste = False) OrElse (IsDate(ItemResult.Valore) = False) Then
                            ItemResult.Valore = #1/1/1900#
                        End If
                    End If
            End Select

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Shared Function VersioneMinima(Modulo As Utx.SettingItem.Chiavi) As Date
        Try
            Dim VersioneServer As New Utx.SettingItem("00000")
            VersioneServer.SetItem(Utx.SettingItem.Sezioni.VERSIONE, Modulo, "", Utx.SettingOMW.TipoOperazione.LETTURA)
            Return VersioneServer.ItemResult.Valore
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return #1/1/1900#
        End Try
    End Function
End Class
