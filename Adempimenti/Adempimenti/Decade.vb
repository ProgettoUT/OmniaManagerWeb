Public Class Decade

    Sub New()
    End Sub

    Sub New(DataRiferimento As Date)
        mInizio = DataInizioDecade(DataRiferimento)
        mFine = DataFineDecade(DataRiferimento)
    End Sub

    Private mInizio As Date
    Public Property Inizio() As Date
        Get
            Return mInizio
        End Get
        Set(value As Date)
            mInizio = DataInizioDecade(value)
        End Set
    End Property

    Private mFine As Date
    Public Property Fine() As Date
        Get
            Return mFine
        End Get
        Set(value As Date)
            mFine = DataFineDecade(value)
        End Set
    End Property

    Public ReadOnly Property Numero() As Integer
        Get
            If mInizio.Day = 1 Then
                Return 1
            ElseIf mInizio.Day = 11 Then
                Return 2
            Else
                Return 3
            End If
        End Get
    End Property

    Public ReadOnly Property Descrizione() As String
        Get
            Return String.Format("{0}° Decade {1} (dal {2} al {3})",
                                 Me.Numero,
                                 Format(mInizio, "MM-yyyy"),
                                 Format(mInizio, "dd/MM"),
                                 Format(mFine, "dd/MM"))
        End Get
    End Property

    Public Shared Function DataInizioDecade(DataRiferimento As Date) As Date
        Select Case DataRiferimento.Day
            Case Is < 11
                Return New DateTime(DataRiferimento.Year, DataRiferimento.Month, 1)
            Case Is < 21
                Return New DateTime(DataRiferimento.Year, DataRiferimento.Month, 11)
            Case Else
                Return New DateTime(DataRiferimento.Year, DataRiferimento.Month, 21)
        End Select
    End Function

    Public Shared Function DataFineDecade(DataRiferimento As Date) As Date

        Select Case DataRiferimento.Day

            Case Is < 11
                Return New DateTime(DataRiferimento.Year, DataRiferimento.Month, 10)
            Case Is < 21
                Return New DateTime(DataRiferimento.Year, DataRiferimento.Month, 20)
            Case Else
                Return New DateTime(DataRiferimento.Year, DataRiferimento.Month, Globale.GiorniNelMese(DataRiferimento))
        End Select

    End Function

    Public Shared Function DataFineDecadePrecedente(DataRiferimento As Date) As Date
        Return DataInizioDecade(DataRiferimento).AddDays(-1)
    End Function
End Class
