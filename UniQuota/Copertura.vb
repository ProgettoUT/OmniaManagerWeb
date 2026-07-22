Public Enum StatoCopertura
    Inapplicabile = 0
    attiva = 1
    esclusa = 2
End Enum

<Serializable()> Public MustInherit Class Copertura
    Inherits Premio
    Private mStatoCopertura As StatoCopertura = StatoCopertura.Inapplicabile
    Private mSezione As Sezione

    Public IsBase As Boolean = False ' = true visualizza la partita in stampa
    Public NonStampare As Boolean = False ' se true non stampa la copertura stampa

    Public Overridable Property Sezione() As Sezione
        Get
            Return mSezione
        End Get
        Set(ByVal value As Sezione)
            mSezione = value
        End Set
    End Property

    Public Overridable Property Stato() As StatoCopertura
        Get
            Return mStatoCopertura
        End Get
        Set(ByVal value As StatoCopertura)
            mStatoCopertura = value
        End Set
    End Property

    Public Function IsNotAttivo() As Boolean
        Return Stato <> StatoCopertura.attiva
    End Function

    Public Function IsAttivo() As Boolean
        Return Stato = StatoCopertura.attiva
    End Function

    Public Function IsEscluso() As Boolean
        Return Stato = StatoCopertura.esclusa
    End Function

    Public Function IsInapplicabile() As Boolean
        Return Stato = StatoCopertura.Inapplicabile
    End Function

    Public Sub EscludiIfInapplicabile()
        If IsInapplicabile() Then Stato = StatoCopertura.esclusa
    End Sub

    Public Function IsApplicabile() As Boolean
        If Stato = StatoCopertura.attiva And ModalitaQuotatore = ModalitaPreventivo.Guidato _
        Or Stato <> StatoCopertura.Inapplicabile And ModalitaQuotatore = ModalitaPreventivo.ConScelta Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub DipendeDa(ByVal attivo As Boolean)
        If attivo Then
            If IsInapplicabile() Then
                Stato = StatoCopertura.esclusa
            End If
        Else
            Stato = StatoCopertura.Inapplicabile
        End If
    End Sub

    Public Sub ObbligatoriaDa(ByVal attivo As Boolean)
        If attivo Then
            Stato = StatoCopertura.attiva
        Else
            Stato = StatoCopertura.Inapplicabile
        End If
    End Sub

    Public MustOverride Sub AzzeraTariffa()

    'Public Shared Function Nuova(ByRef Partite As List(Of Partita), ByRef Garanzie As List(Of Garanzia)) As Copertura
    '    Return New CoperturaComposta(Partite, Garanzie)
    'End Function

    'Public Shared Function Nuova(ByRef Partita As Partita, ByRef Garanzie As List(Of Garanzia)) As Copertura
    '    Return New CoperturaComposta(Partita, Garanzie)
    'End Function

    Public Shared Function Nuova(ByRef Partite As List(Of Partita), ByRef Garanzia As Garanzia) As Copertura
        Return New CoperturaComposta(Partite, Garanzia)
    End Function

    Public Shared Function Nuova(ByRef Partita As Partita, ByRef Garanzia As Garanzia) As Copertura
        Return New CoperturaSingola(Partita, Garanzia)
    End Function

    Default Public MustOverride ReadOnly Property GetCopertura(ByVal partita As Partita) As CoperturaSingola

    Public MustOverride ReadOnly Property CopertureSingole() As List(Of CoperturaSingola)

    Public Shared Operator +(ByVal copertura1 As Copertura, ByVal copertura2 As Copertura) As List(Of Copertura)
        Dim ReturnValue As New List(Of Copertura)
        ReturnValue.Add(copertura1)
        ReturnValue.Add(copertura2)
        Return ReturnValue
    End Operator

    Public Shared Operator +(ByVal coperture As List(Of Copertura), ByVal copertura As Copertura) As List(Of Copertura)
        Dim ReturnValue As New List(Of Copertura)
        ReturnValue.AddRange(coperture)
        ReturnValue.Add(copertura)
        Return ReturnValue
    End Operator
End Class
