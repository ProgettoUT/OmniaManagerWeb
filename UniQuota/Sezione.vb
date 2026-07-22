

<Serializable()> Public Class Sezione
    Inherits Premio
    Public Stato As StatoCopertura = StatoCopertura.esclusa
    Public Preventivo As Prodotto
    Public TipoSezione As Integer
    Public Coperture As New List(Of Copertura)
    Public AliquotaImposta As Decimal = 0
    Public Note As String
    Public EscludiFlex As Boolean

    Public Function IsAttivo() As Boolean
        Return Stato = StatoCopertura.attiva
    End Function

    Public Function IsEscluso() As Boolean
        Return Stato = StatoCopertura.esclusa
    End Function

    Public Function IsInapplicabile() As Boolean
        Return Stato = StatoCopertura.Inapplicabile
    End Function

    Public ReadOnly Property Flexi() As Decimal
        Get
            If EscludiFlex Then
                Return 0D
            ElseIf Preventivo.EscludiFlex Then
                Return 0D
            Else
                Return Preventivo.Flexi
            End If
        End Get
    End Property

    Public ReadOnly Property Descrizione() As String
        Get
            Try
                Return Preventivo.Decode.DecodeSezione(TipoSezione).ToUpper()
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public Function Inizializza() As Boolean
        For Each Copertura As Copertura In Coperture
            Copertura.Sezione = Me
        Next
    End Function

    Public Overrides Sub AzzerraPremi()
        MyBase.AzzerraPremi()
        For Each Copertura As Copertura In Coperture
            Copertura.AzzerraPremi()
        Next
    End Sub

    Public Overrides Sub CalcolaListino()
        For Each Copertura As Copertura In Coperture
            Copertura.CalcolaListino()
            If Copertura.IsAttivo() Then
                Me.SommaListino(Copertura)
            End If
        Next
    End Sub

    Public Overrides Sub CalcolaCoperture()
        For Each Copertura As Copertura In Coperture
            Copertura.CalcolaCoperture()
        Next
    End Sub

    Public Overrides Sub CalcolaTotali()
        For Each Copertura As Copertura In Coperture
            Copertura.CalcolaTotali()
            If Copertura.IsAttivo Then
                Me.SommaPremi(Copertura)
            End If
        Next
        If RischioDirezione > StatoPremio.ClasseOK Then
            MyBase.AzzerraPremi()
        End If
    End Sub

    Public Overrides Sub CalcolaLog()
        logCalcolo &= "SEZIONE " & Descrizione & vbNewLine

        For Each Copertura As Copertura In Coperture
            Copertura.CalcolaLog()
        Next

        If IsAttivo() Then
            logCalcolo &= " RIEPILOGO SEZIONE " & Preventivo.Decode.DecodeSezione(TipoSezione).ToUpper() & vbNewLine '" (" & Preventivo.Decode.DecodeCombinazioneCopertura(CombinazioneCopertura) & ")" & vbNewLine
            logCalcolo &= RSet("  Con sconto", 47) & RSet("  Senza sconto", 20) & vbNewLine
            logCalcolo &= LSet("  Premio Netto ", 30) & "= " & RSet(FormatNumber(PremioNetto), 15) & RSet(FormatNumber(ListinoNetto), 20) & vbNewLine
            logCalcolo &= LSet("  Tasse  " & FormatPercent(AliquotaImposta) & " x " & FormatNumber(PremioNetto), 30) & "= " & RSet(FormatNumber(PremioTasse), 15) & RSet(FormatNumber(ListinoLordo - ListinoNetto), 20) & vbNewLine
            logCalcolo &= LSet("  Premio Lordo ", 30) & "= " & RSet(FormatNumber(PremioLordo), 15) & RSet(FormatNumber(ListinoLordo), 20) & vbNewLine
            'If ScontoTecnico > 0 Then
            'logCalcolo &= LSet("  Sconto " & FormatPercent(PercentualeScontoTecnico) & " x " & FormatNumber(PremioLordo), 30) & "= " & RSet(FormatNumber(ScontoTecnico), 15) & vbNewLine
            'logCalcolo &= LSet("  Premio Annuo", 30) & "= " & RSet(FormatNumber(PremioAnnuo), 15) & vbNewLine
            'End If
        Else
            logCalcolo &= "  Nessuna copertura" & vbNewLine
        End If

        logCalcolo &= vbNewLine & vbNewLine
    End Sub

    Public Overrides Function CleanRD() As Boolean
        MyBase.CleanRD()
        For Each Copertura As Copertura In Coperture
            Copertura.CleanRD()
        Next
    End Function

    Public Sub AzzeraTariffa()
        For Each Copertura As Copertura In Coperture
            Copertura.AzzeraTariffa()
        Next
    End Sub

    Public Sub New(ByVal Preventivo As Prodotto, ByVal TipoSezione As Integer)
        Me.Preventivo = Preventivo
        Me.TipoSezione = TipoSezione
    End Sub

    Public Sub AddCopertura(ByVal copertura As Copertura)
        copertura.Sezione = Me
        Coperture.Add(copertura)
    End Sub

    Public ReadOnly Property CopertureSingole() As List(Of CoperturaSingola)
        Get
            Dim lista As New List(Of CoperturaSingola)
            For Each Copertura As Copertura In Coperture
                lista.AddRange(Copertura.CopertureSingole)
            Next
            Return lista
        End Get
    End Property
End Class
