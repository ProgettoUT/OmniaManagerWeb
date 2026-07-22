Public Class Abbinamento

    Sub New()
    End Sub

    Private mTotaleTitoli As Double
    Public Property TotaleTitoli() As Double
        Get
            Return mTotaleTitoli
        End Get
        Set(ByVal value As Double)
            mTotaleTitoli = value
        End Set
    End Property

    Private mAssegnoCorrente As Double
    Public Property AssegnoCorrente() As Double
        Get
            Return mAssegnoCorrente
        End Get
        Set(ByVal value As Double)
            mAssegnoCorrente = value
        End Set
    End Property

    Private mImportoTotaleAssegni As Double
    Public Property ImportoTotaleAssegni() As Double
        Get
            Return mImportoTotaleAssegni
        End Get
        Set(ByVal value As Double)
            mImportoTotaleAssegni = value
        End Set
    End Property

    Private mAssegnoResiduo As Double
    Public Property AssegnoResiduo() As Double
        Get
            Return mAssegnoResiduo
        End Get
        Set(ByVal value As Double)
            mAssegnoResiduo = value
        End Set
    End Property

    Public Sub Reset()
        mAssegnoCorrente = 0
        mAssegnoResiduo = 0
        mTotaleTitoli = 0
        mImportoTotaleAssegni = 0
    End Sub
End Class
