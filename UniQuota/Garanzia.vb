<Serializable()> Public Class Garanzia
    <NonSerialized()> Public Descrizione As String
    Public CodiceGaranzia As Integer
    Public Limite As Decimal        'massimale percentuale 
    Public Massimale As Decimal     'massimale assoluto
    Public Scoperto As Decimal      'scoperto %
    Public Franchigia As Decimal    'scoperto assoluto
    Public Combinazione As Decimal  'codice combinazione
    Public Garanzie As List(Of Garanzia)
    Public MassimalePerAnno As Decimal     'massimale assoluto aggregato per anno
    <NonSerialized()> Public CombinazioneStampa As String   'descrizione combinazione (ad uso stampa)

    Public Sub New(ByVal Codice As Integer, ByVal Garanzie As List(Of Garanzia))
        CodiceGaranzia = Codice
        Me.Garanzie = Garanzie
    End Sub

    Public Sub New(ByVal Codice As Integer)
        Me.CodiceGaranzia = Codice
    End Sub

    Public Sub New(ByVal Descrizione As String, ByVal Garanzie As List(Of Garanzia))
        Me.Descrizione = Descrizione
        Me.Garanzie = Garanzie
    End Sub
    Public Sub New(ByVal Descrizione As String)
        Me.Descrizione = Descrizione
    End Sub

    Public Shared Operator +(ByVal Garanzia1 As Garanzia, ByVal Garanzia2 As Garanzia) As List(Of Garanzia)
        Dim ReturnValue As New List(Of Garanzia)
        ReturnValue.Add(Garanzia1)
        ReturnValue.Add(Garanzia2)
        Return ReturnValue
    End Operator

    Public Shared Operator +(ByVal Garanzie As List(Of Garanzia), ByVal Garanzia As Garanzia) As List(Of Garanzia)
        Garanzie.Add(Garanzia)
        Return Garanzie
    End Operator
End Class
