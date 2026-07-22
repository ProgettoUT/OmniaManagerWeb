Imports System.IO

Public Class UnitaDisco

    Private Const mDiscoRete As String = "M:\"
    Private Const mDiscoLocale As String = "U:\"

    'Sub New(ByVal Ambiente As GestioneDocumenti.TipoAmbiente)
    Sub New()
        If Ut.Setting.Ambiente = Ut.Setting.TipoAmbiente.PP Then
            mDisco = mDiscoLocale
        Else
            mDisco = mDiscoRete
        End If
    End Sub

    Private mDisco As String
    Public ReadOnly Property Disco() As String
        Get
            Return mDisco
        End Get
    End Property

    Public ReadOnly Property IsReady() As Boolean
        Get
            Return New DriveInfo(mDisco).IsReady
        End Get
    End Property

    Public ReadOnly Property IsReadyMessaggio() As Boolean
        Get
            If New DriveInfo(mDisco).IsReady Then
                Return True
            Else
                MsgBox(String.Format("L'unità disco {0} non è disponibile.",
                     mDisco), MsgBoxStyle.Exclamation, TitoloApp)

                Return False
            End If
        End Get
    End Property

End Class
