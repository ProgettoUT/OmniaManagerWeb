<Serializable()> Public Class Partita
    Public TassoDiPartita As Decimal = 1
    Public SommaAssicurata As Decimal
    'Public FormaDiAssicurazione As FormaDiAssicurazione
    Public TipoPartita As Integer
    <NonSerialized()> Public Descrizione As String

    Public Sub New(ByVal TipoPartita As Integer)
        Me.TipoPartita = TipoPartita
    End Sub

    Public Shared Operator +(ByVal partita1 As Partita, ByVal partita2 As Partita) As List(Of Partita)
        Dim ReturnValue As New List(Of Partita)
        ReturnValue.Add(partita1)
        ReturnValue.Add(partita2)
        Return ReturnValue
    End Operator

    Public Shared Operator +(ByVal partite As List(Of Partita), ByVal partita As Partita) As List(Of Partita)
        partite.Add(partita)
        Return partite
    End Operator

    Public Sub LimitiAssuntivi(ByVal SommaMinima As Decimal, ByVal SommaMassima As Decimal)
        If SommaAssicurata < 0 Then
            SommaAssicurata = 0
        ElseIf SommaAssicurata < SommaMinima Then
            SommaAssicurata = SommaMinima
        ElseIf SommaAssicurata > SommaMassima Then
            SommaAssicurata = SommaMassima
        End If
    End Sub
    Public Sub LimiteAssuntivoMinimo(ByVal SommaMinima As Decimal)
        If SommaAssicurata < 0 Then
            SommaAssicurata = 0
        ElseIf SommaAssicurata < SommaMinima Then
            SommaAssicurata = SommaMinima
        End If
    End Sub
    Public Sub LimiteAssuntivoMassimo(ByVal SommaMassima As Decimal)
        If SommaAssicurata > SommaMassima Then
            SommaAssicurata = SommaMassima
        End If
    End Sub
    Public Sub LimiteAssuntivoMassimo(ByVal SommaMassima1 As Decimal, ByVal SommaMassima2 As Decimal)
        If SommaAssicurata > SommaMassima1 Then
            SommaAssicurata = SommaMassima1
        End If
        If SommaAssicurata > SommaMassima2 Then
            SommaAssicurata = SommaMassima2
        End If
    End Sub
End Class
