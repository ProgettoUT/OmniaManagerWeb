Public Class Sinistri

    Sub New(IdSinistro As String)

        Try
            Dim Campi() As String

            'per contemplare sia i casi di stringa separata da . che da -
            If IdSinistro.Contains("-") Then
                Campi = IdSinistro.Split("-")
            Else
                Campi = IdSinistro.Split(".")
            End If

            If UBound(Campi) = 2 Then
                mCompagniaSinistro = CalcolaCompagniaSinistro()
                mAgenziaSinistro = Campi(0)
                mEsercizioSinistro = Campi(1)
                mNumeroSinistro = Campi(2)
            Else
                mCompagniaSinistro = Campi(0)
                mAgenziaSinistro = Campi(1)
                mEsercizioSinistro = Campi(2)
                mNumeroSinistro = Campi(3)
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

    End Sub

    Sub New(CompagniaSinistro As Integer,
            AgenziaSinistro As Integer,
            EsercizioSinistro As Integer,
            NumeroSinistro As Integer)

        Try
            mCompagniaSinistro = CompagniaSinistro.ToString
            mAgenziaSinistro = AgenziaSinistro.ToString.PadLeft(4, "0")
            mEsercizioSinistro = EsercizioSinistro.ToString
            mNumeroSinistro = NumeroSinistro.ToString.PadLeft(7, "0")

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

    End Sub

    Sub New(AgenziaSinistro As Integer,
            EsercizioSinistro As Integer,
            NumeroSinistro As Integer)

        Try
            mCompagniaSinistro = CalcolaCompagniaSinistro()
            mAgenziaSinistro = AgenziaSinistro.ToString.PadLeft(4, "0")
            mEsercizioSinistro = EsercizioSinistro.ToString
            mNumeroSinistro = NumeroSinistro.ToString.PadLeft(7, "0")

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try

    End Sub

    Private mCompagniaSinistro As String
    Public ReadOnly Property CompagniaSinistro() As String
        Get
            Return mCompagniaSinistro
        End Get
    End Property

    Private mAgenziaSinistro As String
    Public ReadOnly Property AgenziaSinistro() As String
        Get
            Return mAgenziaSinistro
        End Get
    End Property

    Private mEsercizioSinistro As String
    Public ReadOnly Property EsercizioSinistro() As String
        Get
            Return mEsercizioSinistro
        End Get
    End Property

    Private mNumeroSinistro As String
    Public ReadOnly Property NumeroSinistro() As String
        Get
            Return mNumeroSinistro
        End Get
    End Property

    Public ReadOnly Property AgenziaPolizza() As String
        Get
            Return GetEnvironmentVar("UNITOOLS_DOC_AGENZIAPOL_SINISTRO").PadLeft(5, "0")
        End Get
    End Property

    Public ReadOnly Property SubAgenziaSinistro() As String
        Get
            Return GetEnvironmentVar("UNITOOLS_DOC_SUB_SINISTRO").PadLeft(3, "0")
        End Get
    End Property

    Private Function CalcolaCompagniaSinistro() As String

        Try
            Dim Compagnia As String = GetEnvironmentVar("UNITOOLS_DOC_COMPAGNIA_SINISTRO")

            If Compagnia.Trim = "" Then

                Select Case Val(GetEnvironmentVar("UNITOOLS_DOC_AGENZIAPOL_SINISTRO"))

                    Case 1 To 9999
                        Return "1"

                    Case 10000 To 39999
                        Return "6"

                    Case Is > 70000
                        Return "7"

                    Case Else
                        Return "1"
                End Select
            Else
                Return Compagnia
            End If

        Catch ex As Exception
            Return "1"
        End Try

    End Function

    Public Function IdSinistroNormalizzato()

        Return String.Format("{0}-{1}-{2}-{3}",
                             mCompagniaSinistro,
                             mAgenziaSinistro.PadLeft(4, "0"),
                             mEsercizioSinistro,
                             mNumeroSinistro.PadLeft(7, "0"))
    End Function
End Class
