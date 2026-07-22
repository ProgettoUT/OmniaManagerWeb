Imports UniSql.CProfilo

Public Interface IProfilatore
    ReadOnly Property Profili() As CProfili
    Sub AddAutorizzazioni(sNome As String, sConsenti As String, sNega As String)
    Function GetAutorizzazioni(utente As CUtente) As EAutType
End Interface

Public Class CProfilatore
    Implements IProfilatore

    Private _Profili As New CProfili
    Public ReadOnly Property Profili() As CProfili Implements IProfilatore.Profili
        Get
            Return _Profili
        End Get
    End Property

    Public Sub AddAutorizzazioni(sNome As String, sConsenti As String, sNega As String) Implements IProfilatore.AddAutorizzazioni
        _Profili.GetProfilo(sNome).SetProfilo(sConsenti, sNega)
    End Sub

    Public Function GetAutorizzazioni(utente As CUtente) As EAutType Implements IProfilatore.GetAutorizzazioni
        Dim autorizzazioni As EAutType


        If utente.IsAdmin Then
            Return EAutType.AUT_CONTROLLO_COMPLETO
        End If

        Dim profiliUtente() As String = utente.Profili()

        ' Per ogni profilo

        ' aggiunge le autorizzazioni consentite
        For Each profiloName As String In profiliUtente
            If _Profili.ContainsKey(profiloName) Then
                autorizzazioni = autorizzazioni Or _Profili(profiloName).Consenti
            End If
        Next

        ' e nega le autorizzazioni non consentite
        For Each profiloName As String In profiliUtente
            If _Profili.ContainsKey(profiloName) Then
                autorizzazioni = autorizzazioni And Not _Profili(profiloName).Nega
            End If
        Next

        Return autorizzazioni
    End Function
End Class
