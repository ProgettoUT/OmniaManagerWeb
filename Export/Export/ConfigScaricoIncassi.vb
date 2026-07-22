Imports System.Data

Public Class ConfigScaricoIncassi

    Public Event Stato(e As ExportEventArgs)
    Public WithEvents e As New ExportEventArgs

    Friend Config As New Utx.ConfigSede

    Sub New()
        Try
            mEsecuzioneAutomatica = True 'di default in automatico

#If DEBUG Then
            'mCompagnia = 1
            'mAgenziaPrincipale = Utx.EnteGestore.StringaCodiciGestiti.Split(";")(0)
            'mSede = "00"
            'mCodiciGestiti = Utx.EnteGestore.StringaCodiciGestiti.Replace(";", "/")
            ''valori di default
            'mScaricaFile = False
            'mInizioPeriodo = Today
            'mCodiciDaScaricare = mCodiciGestiti
            For Each dr As DataRow In Config.AgenzieCollegate().Rows
                mCompagnia = dr("Compagnia")
                mAgenziaPrincipale = dr("Agenzia")
                mSede = dr("Sede")
                mCodiciGestiti = dr("Collegate")

                'valori di default
                mScaricaFile = False
                mInizioPeriodo = Today
                mCodiciDaScaricare = mCodiciGestiti
            Next
#Else
            'questa configurazione principale-sede>>collegate ha sempre una sola riga
            For Each dr As DataRow In Config.AgenzieCollegate().Rows
                mCompagnia = dr("Compagnia")
                mAgenziaPrincipale = dr("Agenzia")
                mSede = dr("Sede")
                mCodiciGestiti = dr("Collegate")

                'valori di default
                mScaricaFile = False
                mInizioPeriodo = Today
                mCodiciDaScaricare = mCodiciGestiti
            Next
#End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            e.Errore = True
        End Try
    End Sub

    Private mCompagnia As Integer
    Public Property Compagnia() As Integer
        Get
            Return mCompagnia
        End Get
        Set(value As Integer)
            mCompagnia = value
        End Set
    End Property

    Private mAgenziaPrincipale As String
    Public Property AgenziaPrincipale() As String
        Get
            Return mAgenziaPrincipale
        End Get
        Set(value As String)
            mAgenziaPrincipale = value
        End Set
    End Property

    Private mSede As String
    Public Property Sede() As String
        Get
            Return mSede
        End Get
        Set(value As String)
            mSede = value
        End Set
    End Property

    Private mCodiciGestiti As String
    Public Property CodiciGestiti() As String
        Get
            Return mCodiciGestiti
        End Get
        Set(value As String)
            mCodiciGestiti = value
        End Set
    End Property

    Private mCodiciDaScaricare As String
    Public Property CodiciDaScaricare() As String
        Get
            Return mCodiciDaScaricare
        End Get
        Set(value As String)
            mCodiciDaScaricare = value
        End Set
    End Property

    Private mScaricaFile As Boolean
    Public Property ScaricaFile() As Boolean
        Get
            Return mScaricaFile
        End Get
        Set(value As Boolean)
            mScaricaFile = value
        End Set
    End Property

    Private mInizioPeriodo As Date
    Public Property InizioPeriodo() As Date
        Get
            Return mInizioPeriodo
        End Get
        Set(value As Date)
            mInizioPeriodo = value
        End Set
    End Property

    Private mEsecuzioneAutomatica As Boolean
    Public Property EsecuzioneAutomatica() As Boolean
        Get
            Return mEsecuzioneAutomatica
        End Get
        Set(value As Boolean)
            mEsecuzioneAutomatica = value
        End Set
    End Property

    Private mErroreImportazione As Boolean
    Public Property ErroreImportazione() As Boolean
        Get
            Return mErroreImportazione
        End Get
        Set(value As Boolean)
            mErroreImportazione = value
        End Set
    End Property

    Private mForzatura As Boolean = False
    Public Property Forzatura() As Boolean
        Get
            Return mForzatura
        End Get
        Set(value As Boolean)
            mForzatura = value
        End Set
    End Property

    Private Sub e_CambiaStato() Handles e.CambiaStato
        RaiseEvent Stato(e)
    End Sub
End Class
