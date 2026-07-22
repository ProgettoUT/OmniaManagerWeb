<Serializable()> Public Class CoperturaSingola
    Inherits Copertura

    Public Partita As Partita
    Public Garanzia As Garanzia
    Public Tariffa As New Tariffa
    Public EscludiFlex As Boolean

    Public Function PremioCrudo() As Decimal
        If Partita Is Nothing Then
            Return Tariffa.PremioCrudo(Garanzia.Massimale)
        Else
            Return Tariffa.PremioCrudo(Partita.SommaAssicurata)
        End If
    End Function

    ReadOnly Property MassimoAssicuratoAttivo() As Decimal
        Get
            If IsAttivo() Then
                If Partita Is Nothing Then
                    Return Garanzia.Massimale
                ElseIf Partita.SommaAssicurata > 0 Then
                    Return Partita.SommaAssicurata
                Else
                    Return Garanzia.Massimale
                End If
            Else
                Return 0D
            End If
        End Get
    End Property

    ReadOnly Property SommaAssicurataAttiva() As Decimal
        Get
            If IsAttivo() Then
                Return Partita.SommaAssicurata
            Else
                Return 0D
            End If
        End Get
    End Property

    ReadOnly Property MassimaleAttivo() As Decimal
        Get
            If IsAttivo() Then
                Return Garanzia.Massimale
            Else
                Return 0D
            End If
        End Get
    End Property

    ReadOnly Property PremioAttivoCrudo() As Decimal
        Get
            If IsAttivo() Then
                Return PremioCrudo()
            Else
                Return 0D
            End If
        End Get
    End Property

    ReadOnly Property PremioAttivoLordo() As Decimal
        Get
            If IsAttivo() Then
                Return PremioLordo
            Else
                Return 0D
            End If
        End Get
    End Property

    ReadOnly Property PremioAttivoNetto() As Decimal
        Get
            If IsAttivo() Then
                Return PremioNetto
            Else
                Return 0D
            End If
        End Get
    End Property

    ReadOnly Property TassoAttivo() As Decimal
        Get
            If IsAttivo() Then
                Return Tariffa.Tasso
            Else
                Return 0D
            End If
        End Get
    End Property

    Public Overrides Sub CalcolaListino()
        If IsApplicabile() Then
            If Sezione.Preventivo.BaseTasse = UniQuota.BaseTasse.BaseNetta Then
                ListinoNetto = Arrotonda(PremioCrudo())
                ListinoLordo = Arrotonda(ListinoNetto * (1 + Sezione.AliquotaImposta))
            Else
                ListinoLordo = Arrotonda(PremioCrudo())
                ListinoNetto = Arrotonda(ListinoLordo / (1 + Sezione.AliquotaImposta))
            End If
        End If
    End Sub

    Public Overrides Sub CalcolaCoperture()

        If IsApplicabile() Then

            ScontoTecnico = Arrotonda(ListinoLordo * (Sezione.PercentualeScontoTecnico + PercentualeScontoTecnico - Sezione.PercentualeScontoTecnico * PercentualeScontoTecnico))
            ScontoConvenzione = Arrotonda((ListinoLordo - ScontoTecnico) * Sezione.Preventivo.Convenzione.Percentuale)
            PremioFlexi = ListinoLordo - ScontoTecnico - ScontoConvenzione
            ScontoFlexi = PremioFlexi * Flexi

            PremioLordo = ListinoLordo - ScontoTecnico - ScontoConvenzione - ScontoFlexi
            PremioNetto = Arrotonda(PremioLordo / (1 + Sezione.AliquotaImposta))
            PremioTasse = PremioLordo - PremioNetto

            If ModalitaVisualizzazione = ModalitaVisualizzazionePremi.ListinoLordo Then
                PremioLabel = ListinoLordo
            ElseIf ModalitaVisualizzazione = ModalitaVisualizzazionePremi.PremioLordo Then
                PremioLabel = PremioLordo
            ElseIf ModalitaVisualizzazione = ModalitaVisualizzazionePremi.ListinoNetto Then
                PremioLabel = ListinoNetto
            Else
                PremioLabel = PremioNetto
            End If
        End If
    End Sub

    Public Overrides Sub CalcolaTotali()
    End Sub

    Public Overrides Sub CalcolaLog()

        If IsAttivo() And ListinoLordo <> 0D Then
            Dim IsBaseNetta As Boolean = Sezione.Preventivo.BaseTasse = UniQuota.BaseTasse.BaseNetta

            If Partita IsNot Nothing Then
                If Garanzia IsNot Nothing Then
                    logCalcolo &= LSet("  Copertura", 30) & "= " & Garanzia.Descrizione & " x " & Partita.Descrizione & vbNewLine
                Else
                    logCalcolo &= LSet("  Copertura", 30) & "= " & Partita.Descrizione & vbNewLine
                End If
                If Partita.SommaAssicurata > 0 Then
                    logCalcolo &= LSet("  Somma assicurata", 30) & "= " & FormatNumber(Partita.SommaAssicurata) & vbNewLine
                End If

                If IsBaseNetta Then
                    logCalcolo &= LSet("  Premio Netto", 30)
                    If Tariffa.Base <> 0 And Partita.SommaAssicurata <> 0 And Tariffa.Tasso <> 0 Then
                        logCalcolo &= "= " & LSet(FormatNumber(Partita.SommaAssicurata) & " x " & FormatPercent(Tariffa.Tasso, 4) & " + " & FormatNumber(Tariffa.Base) & " = ", 30) & RSet(FormatNumber(ListinoNetto), 15) & vbNewLine
                    ElseIf Tariffa.Base <> 0 Then
                        logCalcolo &= "= " & RSet(FormatNumber(ListinoNetto), 45) & vbNewLine
                    ElseIf Partita.SommaAssicurata <> 0 And Tariffa.Tasso <> 0 Then
                        logCalcolo &= "= " & LSet(FormatNumber(Partita.SommaAssicurata) & " x " & FormatPercent(Tariffa.Tasso, 4) & " = ", 30) & RSet(FormatNumber(ListinoNetto), 15) & vbNewLine
                    End If
                Else
                    logCalcolo &= LSet("  Premio Lordo", 30)
                    If Tariffa.Base <> 0 And Partita.SommaAssicurata <> 0 And Tariffa.Tasso <> 0 Then
                        logCalcolo &= "= " & LSet(FormatNumber(Partita.SommaAssicurata) & " x " & FormatPercent(Tariffa.Tasso, 4) & " + " & FormatNumber(Tariffa.Base) & " = ", 30) & RSet(FormatNumber(ListinoLordo), 15) & vbNewLine
                    ElseIf Tariffa.Base <> 0 Then
                        logCalcolo &= "= " & RSet(FormatNumber(ListinoLordo), 45) & vbNewLine
                    ElseIf Partita.SommaAssicurata <> 0 And Tariffa.Tasso <> 0 Then
                        logCalcolo &= "= " & LSet(FormatNumber(Partita.SommaAssicurata) & " x " & FormatPercent(Tariffa.Tasso, 4) & " = ", 30) & RSet(FormatNumber(ListinoLordo), 15) & vbNewLine
                    End If
                End If
            ElseIf Garanzia IsNot Nothing Then
                logCalcolo &= LSet("  Copertura", 30) & "= " & Garanzia.Descrizione & vbNewLine

                If Garanzia.Massimale > 0 Then
                    logCalcolo &= LSet("  Massimale", 30) & "= " & FormatNumber(Garanzia.Massimale) & vbNewLine
                End If

                If IsBaseNetta Then
                    logCalcolo &= LSet("  Premio Netto", 30)
                    If Tariffa.Base <> 0 And Garanzia.Massimale <> 0 And Tariffa.Tasso <> 0 Then
                        logCalcolo &= "= " & LSet(FormatNumber(Garanzia.Massimale) & " x " & FormatPercent(Tariffa.Tasso, 4) & " + " & FormatNumber(Tariffa.Base) & " = ", 30) & RSet(FormatNumber(ListinoNetto), 15) & vbNewLine
                    ElseIf Tariffa.Base <> 0 Then
                        logCalcolo &= "= " & RSet(FormatNumber(ListinoNetto), 45) & vbNewLine
                    ElseIf Garanzia.Massimale <> 0 And Tariffa.Tasso <> 0 Then
                        logCalcolo &= "= " & LSet(FormatNumber(Garanzia.Massimale) & " x " & FormatPercent(Tariffa.Tasso, 4) & " = ", 30) & RSet(FormatNumber(ListinoNetto), 15) & vbNewLine
                    End If
                Else
                    logCalcolo &= LSet("  Premio Lordo", 30)
                    If Tariffa.Base <> 0 And Garanzia.Massimale <> 0 And Tariffa.Tasso <> 0 Then
                        logCalcolo &= "= " & LSet(FormatNumber(Garanzia.Massimale) & " x " & FormatPercent(Tariffa.Tasso, 4) & " + " & FormatNumber(Tariffa.Base) & " = ", 30) & RSet(FormatNumber(ListinoLordo), 15) & vbNewLine
                    ElseIf Tariffa.Base <> 0 Then
                        logCalcolo &= "= " & RSet(FormatNumber(ListinoLordo), 45) & vbNewLine
                    ElseIf Garanzia.Massimale <> 0 And Tariffa.Tasso <> 0 Then
                        logCalcolo &= "= " & LSet(FormatNumber(Garanzia.Massimale) & " x " & FormatPercent(Tariffa.Tasso, 4) & " = ", 30) & RSet(FormatNumber(ListinoLordo), 15) & vbNewLine
                    End If
                End If
            End If

            'logCalcolo &= vbNewLine
            'logCalcolo &= "Premi senza sconti" & vbNewLine
            'logCalcolo &= LSet("  Listino Netto", 30) & "= " & RSet(FormatNumber(ListinoNetto), 45) & vbNewLine
            'logCalcolo &= LSet("  Tasse  ", 30) & "= " & RSet(FormatNumber(ListinoLordo - ListinoNetto), 45) & vbNewLine
            'logCalcolo &= LSet("  Listino Lordo", 30) & "= " & RSet(FormatNumber(ListinoLordo), 45) & vbNewLine
            If ListinoLordo - PremioLordo > 0.01D Then
                logCalcolo &= "  SCONTI APPLICATI:" & vbNewLine
                If Sezione.PercentualeScontoTecnico > 0D Then
                    logCalcolo &= LSet("  % Sconto sezione", 30) & "= " & RSet(FormatPercent(Sezione.PercentualeScontoTecnico), 7) & vbNewLine
                End If
                If PercentualeScontoTecnico > 0D Then
                    logCalcolo &= LSet("  % Sconto copertura", 30) & "= " & RSet(FormatPercent(PercentualeScontoTecnico), 7) & vbNewLine
                End If
                If Sezione.Preventivo.Convenzione.Percentuale > 0D Then
                    logCalcolo &= LSet("  % Sconto convenzione", 30) & "= " & RSet(FormatPercent(Sezione.Preventivo.Convenzione.Percentuale), 7) & vbNewLine
                End If
                If Flexi > 0D Then
                    logCalcolo &= LSet("  % Sconto flex", 30) & "= " & RSet(FormatPercent(Flexi), 7) & vbNewLine
                End If
            End If

            logCalcolo &= vbNewLine
            logCalcolo &= LSet("  RIEPILOGO PREMI:", 30) & RSet("  Con sconto", 47) & RSet("  Senza sconto", 20) & vbNewLine
            logCalcolo &= LSet("  Premio Netto", 30) & "= " & RSet(FormatNumber(PremioNetto), 45) & RSet(FormatNumber(ListinoNetto), 20) & vbNewLine
            logCalcolo &= LSet("  Tasse  ", 30) & "= " & LSet(FormatNumber(PremioNetto) & " x " & FormatPercent(Sezione.AliquotaImposta) & " = ", 30) & RSet(FormatNumber(PremioTasse), 15) & RSet(FormatNumber(ListinoLordo - ListinoNetto), 20) & vbNewLine
            logCalcolo &= LSet("  Premio Lordo", 30) & "= " & RSet(FormatNumber(PremioLordo), 45) & RSet(FormatNumber(ListinoLordo), 20) & vbNewLine
            logCalcolo &= vbNewLine
        End If
    End Sub

    Public Sub New(ByVal Garanzia As Garanzia)
        Me.Partita = Nothing
        Me.Garanzia = Garanzia
    End Sub

    Public Sub New(ByVal Partita As Partita, ByVal Garanzia As Garanzia)
        Me.Partita = Partita
        Me.Garanzia = Garanzia
    End Sub

    Public Sub New(ByVal Partita As Partita, ByVal Garanzia As Garanzia, ByVal IsBase As Boolean)
        Me.Partita = Partita
        Me.Garanzia = Garanzia
        Me.IsBase = IsBase
    End Sub

    Public Overrides ReadOnly Property GetCopertura(ByVal partita As Partita) As CoperturaSingola
        Get
            If partita.Equals(partita) Then
                Return Me
            End If

            Return Nothing
        End Get
    End Property

    Public Overrides ReadOnly Property CopertureSingole() As List(Of CoperturaSingola)
        Get
            Dim lista As New List(Of CoperturaSingola)
            lista.Add(Me)
            Return lista
        End Get
    End Property

    Public Overrides Sub AzzeraTariffa()
        Tariffa.AzzeraTariffa()
    End Sub

    Public ReadOnly Property Flexi() As Decimal
        Get
            If EscludiFlex Then
                Return 0D
            Else
                Return Sezione.Flexi
            End If
        End Get
    End Property

End Class
