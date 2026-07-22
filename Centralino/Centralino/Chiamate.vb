Imports System.IO

Public Class Chiamate

    Public Event Notifica(ByRef NuovaChiamata As Chiamata)

    Sub New()
        mElenco = New List(Of Chiamata)
    End Sub

    Private mElenco As List(Of Chiamata)
    Public Property Elenco() As List(Of Chiamata)
        Get
            Return mElenco
        End Get
        Set(value As List(Of Chiamata))
            mElenco = value
        End Set
    End Property

    Public ReadOnly Property InAttesa() As Integer
        Get
            Return mElenco.Count
        End Get
    End Property

    Public ReadOnly Property ChiamataPrecedente() As Chiamata
        Get
            If mElenco.Count < 2 Then
                Return Nothing
            Else
                Return mElenco.Item(mElenco.Count - 2)
            End If
        End Get
    End Property

    Public Sub Add(Parametri As Dictionary(Of String, String))
        'aggiungo all'elenco  chiamate
        Dim NuovaChiamata As Chiamata = New Chiamata(Parametri)
        mElenco.Add(NuovaChiamata)
        'notifico
        RaiseEvent Notifica(NuovaChiamata)
    End Sub

    Public Sub Termina(Parametri As Dictionary(Of String, String))
        Dim c As Chiamata = EsisteChiamata(Parametri)
        If c IsNot Nothing Then
            c.Durata = Regista.Richiesta.Valore(Parametri, "duration")
            'todo: salvataggio
        End If
    End Sub

    Public Sub Aggiorna(Parametri As Dictionary(Of String, String))
        Dim c As Chiamata = EsisteChiamata(Parametri)
        If c IsNot Nothing Then
            c.Durata = Regista.Richiesta.Valore(Parametri, "duration")
            'todo: salvataggio
        End If
    End Sub

    Public Sub Elimina(Parametri As Dictionary(Of String, String))
        Dim Id As Integer = Regista.Richiesta.Valore(Parametri, "call_id")
        For k As Integer = 0 To mElenco.Count - 1
            If mElenco(k).Id = Id Then
                mElenco.RemoveAt(k)
                Exit For
            End If
        Next
    End Sub

    Public Function EsisteChiamata(Parametri As Dictionary(Of String, String)) As Chiamata
        Dim Id As Integer = Regista.Richiesta.Valore(Parametri, "call_id")
        For Each c As Chiamata In Elenco
            If c.Id = Id Then
                Return c
            End If
        Next
        Return Nothing
    End Function

    Public Sub Elimina(ByRef ChiamataDaEliminare As Chiamata)
        For Each c As Chiamata In mElenco
            If c.Telefono = ChiamataDaEliminare.Telefono Then
                mElenco.Remove(c)
                Exit For
            End If
        Next
    End Sub

    Public Sub Reset()
        mElenco.Clear()
    End Sub

    Private Function File2Telefono(FileChiamata As String) As String
        Dim Telefono As String = Path.GetFileNameWithoutExtension(FileChiamata).Split(".")(0)
        Return Chiamata.NormalizzaNumero(Telefono)
    End Function
End Class
