Imports System.IO

Public Class FileSinistri

    Sub New(ByVal FileDati As String)

        'START FILE|AURORA|02379|05|01/09/2014|07/09/2014|7|1|1550|1|1306650|02379_sinistri_07_settembre_2014|N|N|N|09/09/2014
        Using sr As New StreamReader(FileDati, System.Text.Encoding.Default)
            Dim Campi() As String = sr.ReadLine.Split(Chr(124)) 'carattere pipe |

            mAgenzia = Campi(2)
            mTipoFile = Campi(3)
            mInizioPeriodo = CDate(Campi(4))
            mFinePeriodo = CDate(Campi(5))
            mGiorni = Campi(6)
            mNumeroRecord = Campi(8)
            mCreato = CDate(Campi(15))
        End Using

    End Sub

    Private mAgenzia As String
    Public ReadOnly Property Agenzia() As String
        Get
            Return mAgenzia
        End Get
    End Property

    Private mTipoFile As String
    Public ReadOnly Property TipoFile() As String
        Get
            Return mTipoFile
        End Get
    End Property

    Private mInizioPeriodo As Date
    Public ReadOnly Property InizioPeriodo() As Date
        Get
            Return mInizioPeriodo
        End Get
    End Property

    Private mFinePeriodo As Date
    Public ReadOnly Property FinePeriodo() As Date
        Get
            Return mFinePeriodo
        End Get
    End Property

    'la data file coincide con la data di fine periodo
    Public ReadOnly Property DataFile() As Date
        Get
            Return mFinePeriodo
        End Get
    End Property

    Private mGiorni As Integer
    Public ReadOnly Property Giorni() As Integer
        Get
            Return mGiorni
        End Get
    End Property

    Private mNumeroRecord As Integer
    Public ReadOnly Property NumeroRecord() As String
        Get
            Return mNumeroRecord
        End Get
    End Property

    Private mCreato As Date
    Public ReadOnly Property Creato() As Date
        Get
            Return mCreato
        End Get
    End Property

    Public ReadOnly Property DataConsolidamento() As Date
        Get
            If mFinePeriodo = DataFineMese(mFinePeriodo) Then
                Return mFinePeriodo
            Else
                Return DataFineMese(mFinePeriodo.AddMonths(-1))
            End If
        End Get
    End Property

    Friend Function TrovaSezione(ByVal sr As StreamReader, ByVal ID As String) As Boolean

        Do While Not sr.EndOfStream
            If sr.ReadLine.Contains(ID) Then Return True
        Loop

        Return False

    End Function

End Class
