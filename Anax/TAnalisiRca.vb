Public Class TAnalisiRca
    Inherits _TAnalisiRca

    Public ReadOnly Property PremioDif As Decimal
        Get
            Return PremioNew - PremioOld
        End Get
    End Property
End Class
