Imports System.IO

Public Class Chiamata

    Public Event EliminaFileChiamata(Chiamata As Chiamata)

    Public Enum Tipo
        IN_ENTRATA
        IN_USCITA
    End Enum

    Sub New(Parametri As Dictionary(Of String, String))
        'http://192.168.1.5:10000/Centralino?callDirection=$callDirection&remote=$remote&mac=$mac&active_user=$active_user&call_id=$call_id

        mId = Regista.Richiesta.Valore(Parametri, "call_id")
        mTipoChiamata = IIf(Regista.Richiesta.Valore(Parametri, "ut") = "in", Tipo.IN_ENTRATA, Tipo.IN_USCITA)
        If mTipoChiamata = Tipo.IN_ENTRATA Then
            mTelefono = EstraiTelefonoIN(Parametri)
        Else
            mTelefono = EstraiTelefonoOUT(Parametri)
        End If
        mCodiceFiscale = ""
    End Sub

    Private mId As Integer
    Public ReadOnly Property Id() As Integer
        Get
            Return mId
        End Get
    End Property

    Private mTipoChiamata As Tipo
    Public ReadOnly Property TipoChiamata() As Tipo
        Get
            Return mTipoChiamata
        End Get
    End Property

    Private mTelefono As String
    Public ReadOnly Property Telefono() As String
        Get
            Return mTelefono
        End Get
    End Property

    Private mDurata As Integer
    Public Property Durata() As Integer
        Get
            Return mDurata
        End Get
        Set(value As Integer)
            mDurata = value
        End Set
    End Property

    Private mCodiceFiscale As String
    Public Property CodiceFiscale() As String
        Get
            Return mCodiceFiscale
        End Get
        Set(value As String)
            mCodiceFiscale = value
        End Set
    End Property

    Private mNome As String
    Public Property Nome() As String
        Get
            Return mNome
        End Get
        Set(value As String)
            mNome = value.Trim
        End Set
    End Property

    Private mAgenzia As String
    Public Property Agenzia() As String
        Get
            Return mAgenzia
        End Get
        Set(value As String)
            mAgenzia = value
        End Set
    End Property

    Public Shared Function EstraiTelefonoIN(Parametri As Dictionary(Of String, String)) As String
        Return NormalizzaNumero(Replace(Regista.Richiesta.Valore(Parametri, "remote").Split("@")(0), "sip:", "", Compare:=CompareMethod.Text))
    End Function

    Public Shared Function EstraiTelefonoOUT(Parametri As Dictionary(Of String, String)) As String
        Return Regista.Richiesta.Valore(Parametri, "calledNumber")
    End Function

    Public Shared Function NormalizzaNumero(Telefono As String) As String
        If Telefono.StartsWith("+39") Then
            Telefono = Telefono.Substring(3)
        End If
        Return Telefono
    End Function
End Class
