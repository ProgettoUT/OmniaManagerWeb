<Serializable()> Public Class CoperturaComposta
    Inherits Copertura
    Public Coperture As New List(Of Copertura)

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
            If Copertura.IsAttivo() Then
                Me.SommaPremi(Copertura)
            End If
        Next
    End Sub

    Public Overrides Sub CalcolaLog()
        For Each Copertura As Copertura In Coperture
            Copertura.CalcolaLog()
        Next
    End Sub

    Public Overrides Function CleanRD() As Boolean
        MyBase.CleanRD()
        For Each Copertura As Copertura In Coperture
            Copertura.CleanRD()
        Next
    End Function

    Public Overrides Sub AzzeraTariffa()
        For Each Copertura As Copertura In Coperture
            Copertura.AzzeraTariffa()
        Next
    End Sub

    Public Sub New()
    End Sub

    Public Sub New(ByVal copertura As Copertura)
        Me.Coperture.Add(copertura)
    End Sub

    Public Sub New(ByVal coperture As List(Of Copertura))
        Me.Coperture.AddRange(coperture)
    End Sub

    Public Sub New(ByVal Partite As List(Of Partita), ByVal Garanzia As Garanzia)
        For Each Partita As Partita In Partite
            Coperture.Add(New CoperturaSingola(Partita, Garanzia))
        Next
    End Sub

    Public Overrides ReadOnly Property GetCopertura(ByVal partita As Partita) As CoperturaSingola
        Get
            For Each copertura As CoperturaSingola In Coperture
                If TypeOf copertura Is CoperturaSingola Then
                    If copertura.Partita.Equals(partita) Then
                        Return copertura
                    End If
                End If
            Next

            Return Nothing
        End Get
    End Property

    Public Overrides Property Sezione() As Sezione
        Get
            Return MyBase.Sezione
        End Get
        Set(ByVal value As Sezione)
            MyBase.Sezione = value
            For Each copertura As Copertura In Coperture
                copertura.Sezione = value
            Next
        End Set
    End Property

    Public Overrides ReadOnly Property CopertureSingole() As List(Of CoperturaSingola)
        Get
            Dim lista As New List(Of CoperturaSingola)
            For Each Copertura As Copertura In Coperture
                lista.AddRange(Copertura.CopertureSingole)
            Next
            Return lista
        End Get
    End Property

    Public Sub AddCopertura(ByVal copertura As Copertura)
        copertura.Sezione = Me.Sezione
        Coperture.Add(copertura)
    End Sub
End Class
