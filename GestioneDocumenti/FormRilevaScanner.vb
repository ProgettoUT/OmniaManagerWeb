Public Class FormRilevaScanner

    Sub New()

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
    End Sub

    Public Function PerifericheTwain() As Integer
        Try
            Twain.CloseSourceManager()
            Twain.IfThrowException = True
            Twain.SupportedDeviceType = Dynamsoft.DotNet.TWAIN.Enums.EnumSupportedDeviceType.SDT_TWAIN
            Return Twain.SourceCount
        Catch ex As Exception
            Return -1
        End Try
    End Function
End Class