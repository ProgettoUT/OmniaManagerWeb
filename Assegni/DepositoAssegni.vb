Imports System.IO

Public Class DepositoAssegni

    Sub New()
        Try
            If (New DriveInfo("M")).IsReady Then
                mDepositoAssegni = "M:\Unitools\Documenti\I\Documenti personali\Assegni"
                Directory.CreateDirectory(mDepositoAssegni)
                mPronto = Directory.Exists(mDepositoAssegni)
            Else
                mPronto = False
            End If
        Catch ex As Exception
            mPronto = False
        End Try
    End Sub

    Private mPronto As Boolean
    Public ReadOnly Property Pronto() As Boolean
        Get
            Return mPronto
        End Get
    End Property

    Private mDepositoAssegni As String
    Public ReadOnly Property DepositoAssegni() As String
        Get
            Return mDepositoAssegni
        End Get
    End Property

    Private mCartellaAssegni As String
    Public ReadOnly Property CartellaAssegni(ByVal DataRiferimento As Date) As String
        Get
            'aggiungo l'anno al deposito
            mCartellaAssegni = Path.Combine(mDepositoAssegni, DataRiferimento.Year.ToString)
            'aggiungo il mese
            mCartellaAssegni = Path.Combine(mCartellaAssegni, DataRiferimento.Month.ToString.PadLeft(2, "0"))

            Directory.CreateDirectory(mCartellaAssegni)

            Return mCartellaAssegni
        End Get
    End Property

End Class
