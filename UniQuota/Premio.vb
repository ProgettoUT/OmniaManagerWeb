Public Enum StatoPremio
    ClasseOK = 0
    ClasseRD = 1
    ClasseND = 2
End Enum

<Serializable()> Public MustInherit Class Premio
    <NonSerialized()> Public PremioLabel As Decimal = 0D
    <NonSerialized()> Public PremioFlexi As Decimal = 0D
    <NonSerialized()> Public PremioNetto As Decimal = 0D
    <NonSerialized()> Public PremioLordo As Decimal = 0D
    <NonSerialized()> Public PremioTasse As Decimal = 0D
    <NonSerialized()> Public ScontoTecnico As Decimal = 0D
    <NonSerialized()> Public ScontoConvenzione As Decimal = 0D
    <NonSerialized()> Public ScontoFlexi As Decimal = 0D

    <NonSerialized()> Public ListinoLordo As Decimal = 0D
    <NonSerialized()> Public ListinoNetto As Decimal = 0D
    <NonSerialized()> Public RischioDirezione As StatoPremio
    <NonSerialized()> Public DescrizioneRD As String = vbNullString
    <NonSerialized()> Public Parametro0 As String = vbNullString
    <NonSerialized()> Public Parametro1 As String = vbNullString
    <NonSerialized()> Public Parametro2 As String = vbNullString
    <NonSerialized()> Public Parametro3 As String = vbNullString
    <NonSerialized()> Public PercentualeScontoTecnico As Decimal = 0

    Public Overridable Function CleanRD() As Boolean
        RischioDirezione = StatoPremio.ClasseOK
        DescrizioneRD = vbNullString
    End Function

    Public MustOverride Sub CalcolaListino()
    Public MustOverride Sub CalcolaCoperture()
    Public MustOverride Sub CalcolaTotali()
    Public MustOverride Sub CalcolaLog()

    Public Sub SommaListino(ByVal premio As Premio)

        If premio.RischioDirezione > Me.RischioDirezione Then
            RischioDirezione = premio.RischioDirezione
            DescrizioneRD = premio.DescrizioneRD
        End If

        ListinoNetto += premio.ListinoNetto
        ListinoLordo += premio.ListinoLordo
    End Sub

    Public Sub SommaPremi(ByVal premio As Premio)
        PremioLabel += premio.PremioLabel
        PremioFlexi += premio.PremioFlexi
        PremioNetto += premio.PremioNetto
        PremioTasse += premio.PremioTasse
        PremioLordo += premio.PremioLordo

        ScontoTecnico += premio.ScontoTecnico
        ScontoConvenzione += premio.ScontoConvenzione
        ScontoFlexi += premio.ScontoFlexi
    End Sub

    Public Overridable Sub AzzerraPremi()
        PremioLabel = 0D
        PremioFlexi = 0D
        PremioNetto = 0D
        PremioTasse = 0D
        PremioLordo = 0D

        ScontoTecnico = 0D
        ScontoConvenzione = 0D
        ScontoFlexi = 0D

        ListinoNetto = 0D
        ListinoLordo = 0D
    End Sub

    Public Sub SetRischioDirezione()
        SetRischioDirezione("RD")
    End Sub
    Public Sub SetRischioDirezione(ByVal descrizione As String)
        RischioDirezione = StatoPremio.ClasseRD
        DescrizioneRD = descrizione
    End Sub
    Public Sub SetNonDisponibile(ByVal descrizione As String)
        RischioDirezione = StatoPremio.ClasseND
        DescrizioneRD = descrizione
    End Sub

    Public Function IsZero() As Boolean
        Return ListinoLordo = 0D
    End Function

    Public Function IsNotZero() As Boolean
        Return ListinoLordo <> 0D
    End Function
End Class
