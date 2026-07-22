<Serializable()> Public Class Convenzione
    Private mCodice As String = "00000"
    Private mDescrizione As String = ""
    Private mPercentuale As Decimal = 0D

    Public Property Percentuale() As Decimal
        Get
            Return mPercentuale
        End Get

        Set(ByVal value As Decimal)
            If value < 0D Then
                mPercentuale = 0D
            ElseIf value > 0.9999D Then
                mPercentuale = 0.9999D
            Else
                mPercentuale = value
            End If
        End Set
    End Property

    Public Property Codice() As String
        Get
            Return mCodice
        End Get
        Set(ByVal value As String)
            Dim i As Integer = 0
            Integer.TryParse(value, i)
            If mCodice <> Format(i, "00000") Then
                mCodice = Format(i, "00000")
                'If i <> 0 Then
                '    mDescrizione = "CISL"
                '    If mPercentuale = 0D Then
                '        mPercentuale = 0.15D
                '    End If
                'End If
            End If
        End Set
    End Property

    Public Property Descrizione() As String
        Get
            Return mDescrizione
            'If mCodice = "00000" Then
            '    Return "non convenzionato"
            'ElseIf mDescrizione = vbNullString Then
            '    Return "non disponibile"
            'Else
            '    Return mDescrizione
            'End If
        End Get
        Set(ByVal value As String)
            mDescrizione = value
        End Set
    End Property

End Class
