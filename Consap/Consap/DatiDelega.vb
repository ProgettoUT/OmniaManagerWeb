Imports System.IO
Imports System.Xml.Serialization

Public Class DatiDelega

    Sub New()
    End Sub

    Private mRagioneSociale As String
    Public Property RagioneSociale() As String
        Get
            Return mRagioneSociale
        End Get
        Set(value As String)
            mRagioneSociale = value
        End Set
    End Property

    Private mIndirizzo As String
    Public Property Indirizzo() As String
        Get
            Return mIndirizzo
        End Get
        Set(value As String)
            mIndirizzo = value
        End Set
    End Property

    Private mCap As String
    Public Property Cap() As String
        Get
            Return mCap
        End Get
        Set(value As String)
            mCap = value
        End Set
    End Property

    Private mCitta As String
    Public Property Citta() As String
        Get
            Return mCitta
        End Get
        Set(value As String)
            mCitta = value
        End Set
    End Property

    Private mProvincia As String
    Public Property Provincia() As String
        Get
            Return mProvincia
        End Get
        Set(value As String)
            mProvincia = value
        End Set
    End Property

    Private mCF As String
    Public Property CF() As String
        Get
            Return mCF
        End Get
        Set(value As String)
            mCF = value
        End Set
    End Property

    Private mTelefono As String
    Public Property Telefono() As String
        Get
            Return mTelefono
        End Get
        Set(value As String)
            mTelefono = value
        End Set
    End Property

    Private mEmail As String
    Public Property Email() As String
        Get
            Return mEmail
        End Get
        Set(value As String)
            mEmail = value
        End Set
    End Property

    Public Shared Function FileConsapXml() As String
        Return Path.Combine(Utx.Globale.Paths.CartellaSettingRete, "Consap.xml")
    End Function

    Public Function IndirizzoCompleto() As String
        Return String.Format("{1}{0}{2} {3} {4}", Environment.NewLine, mIndirizzo, mCap, mCitta, mProvincia)
    End Function

    Public Sub SalvaDati()
        Try
            'salvo dati delegato
            Dim ser As New XmlSerializer(GetType(DatiDelega))
            Using fs As New StreamWriter(FileConsapXml)
                ser.Serialize(fs, Me)
            End Using

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Shared Function Load() As DatiDelega
        If File.Exists(FileConsapXml) Then
            'leggo i dati
            Dim ser As New XmlSerializer(GetType(DatiDelega))
            Using fs As New StreamReader(FileConsapXml)
                Return ser.Deserialize(fs)
            End Using
        Else
            Return New DatiDelega
        End If
    End Function
End Class
