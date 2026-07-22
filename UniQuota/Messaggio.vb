Public Enum TipoMessaggio
    Debug = 0
    Info = 1
    Warning = 2
    Errore = 4
End Enum

Public Class Messaggio
    Public Testo As String
    Public Tipo As TipoMessaggio
    Sub New(ByVal tipo As TipoMessaggio, ByVal testo As String)
        Me.Tipo = tipo
        Me.Testo = testo
    End Sub
    Sub New(ByVal testo As String)
        Me.Tipo = TipoMessaggio.Info
        Me.Testo = testo
    End Sub
End Class

Public Class Messaggi
    Inherits List(Of Messaggio)
    Public TipoLivelloMassimo As TipoMessaggio = TipoMessaggio.Debug

    Public Sub Debug(ByVal testo As String)
        Me.Add(New Messaggio(TipoMessaggio.Debug, testo))
    End Sub
    Public Sub Info(ByVal testo As String)
        Me.Add(New Messaggio(TipoMessaggio.Info, testo))
        If TipoLivelloMassimo < TipoMessaggio.Info Then TipoLivelloMassimo = TipoMessaggio.Info
    End Sub
    Public Sub Warning(ByVal testo As String)
        Me.Add(New Messaggio(TipoMessaggio.Warning, testo))
        If TipoLivelloMassimo < TipoMessaggio.Warning Then TipoLivelloMassimo = TipoMessaggio.Warning
    End Sub
    Public Sub Errore(ByVal testo As String)
        Me.Add(New Messaggio(TipoMessaggio.Errore, testo))
        If TipoLivelloMassimo < TipoMessaggio.Errore Then TipoLivelloMassimo = TipoMessaggio.Errore
    End Sub
End Class
