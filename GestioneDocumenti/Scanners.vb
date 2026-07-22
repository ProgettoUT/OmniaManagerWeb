Imports System.ComponentModel

Public Class Scanners

    Public Event InizializzazioneCompletata(Ready As Boolean)

    Public ListaScanner As New List(Of Scanner)
    Public Const NO_SCANNER As String = "Periferiche non rilevate"

    Private Log As New Utx.ApplicationLog("Scanners")

    Sub New()
    End Sub

    Public Sub Init(Optional SelectSource As Boolean = False)
        If mIsBusy = False Then
            Dim tt As New Threading.Thread(Sub()
                                               RilevaScanner(SelectSource)
                                           End Sub)
            tt.Start()
        End If
    End Sub

    Private mScannerSelezionato As Scanner
    Public Property ScannerSelezionato() As Scanner
        Get
            Return mScannerSelezionato
        End Get
        Set(value As Scanner)
            Try
                'seleziono lo scanner
                mScannerSelezionato = value
                'contollo se supporta il duplex
                mScannerSelezionato.Duplex()
                Log.Info("scanner selezionato '{0}' - duplex {1}", {mScannerSelezionato.Name, mScannerSelezionato.Duplex})
            Catch ex As Exception
                Globale.Log.Errore(ex)
            End Try
        End Set
    End Property

    Private mReady As Boolean
    Public ReadOnly Property Ready() As Boolean
        Get
            Return mReady
        End Get
    End Property

    Private mIsBusy As Boolean
    Public ReadOnly Property IsBusy() As Boolean
        Get
            Return mIsBusy
        End Get
    End Property

    Public ReadOnly Property ScannerDisponibili() As Integer
        Get
            Return ListaScanner.Count
        End Get
    End Property

    Public Sub SalvaPredefinito()
        On Error Resume Next
        'scrivo il predefinito nel setting
        If mScannerSelezionato IsNot Nothing Then
            Utx.Globale.SettingUtente.AggiungiModifica(Utx.GestioneFlag.TipoFlag.SCANNER_PREDEFINITO, mScannerSelezionato.Name, True)
        End If
    End Sub

    Public Shared Function PerifericheTwain() As Integer
        Try
            Dim Tw As New Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain
            Tw.CloseSourceManager()
            Tw.IfThrowException = True
            Tw.SupportedDeviceType = Dynamsoft.DotNet.TWAIN.Enums.EnumSupportedDeviceType.SDT_TWAIN
            Return Tw.SourceCount
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Private Sub RilevaScanner(SelectSource As Boolean)
        Try
            Log.Info("leggo dispositivi twain disponibili nel sistema")
            mReady = False
            mIsBusy = True

            Using Twain As New Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain(Utx.Licenze.DynamicDotNetTwain_5_2_508_0)
                Twain.CloseSourceManager()

                Twain.IfThrowException = True
                Twain.SupportedDeviceType = Dynamsoft.DotNet.TWAIN.Enums.EnumSupportedDeviceType.SDT_TWAIN
                'Twain.IfThrowException = True

                'Dim NomePredefinito As String = Utx.Globale.SettingUtente.LeggiValore(Utx.GestioneFlag.TipoFlag.SCANNER_PREDEFINITO, NO_SCANNER)

                Try
                    ListaScanner.Clear()
                    Log.Info(Twain.SourceCount)

                    If Twain.SourceCount = 0 Then
                        If SelectSource = True Then
                            Twain.SelectSource()
                        End If

                        Log.Info("nessun dispositivo twain rilevato")
                        If Utx.ApplicationLog.LivelloLog = Utx.ApplicationLog.Livello.DEBUG Then
                            Call New Utx.NotificaRapida(Utx.FormNotifica.AltezzaNotifica.MEZZA).Visualizza("Nessun dispositivo TWAIN rilevato")
                        End If
                    Else
                        If Utx.ApplicationLog.LivelloLog = Utx.ApplicationLog.Livello.DEBUG Then
                            Call New Utx.NotificaRapida(Utx.FormNotifica.AltezzaNotifica.MEZZA).Visualizza(String.Format("Rilevati {0} dispositivi TWAIN", Twain.SourceCount))
                        End If

                        For i As Integer = 0 To Twain.SourceCount - 1
                            Log.Info("Dispositivo trovato: {0}", {Twain.SourceNameItems(i)})
                            ListaScanner.Add(New Scanner(i, Twain.SourceNameItems(i)))
                            'se lo scanner è l'ultimo che era stato impostato e salvato
                            'If (ListaScanner(i).Name <> NO_SCANNER) AndAlso (ListaScanner(i).Name = NomePredefinito) Then
                            '    ScannerSelezionato = ListaScanner(i)
                            'End If
                        Next
                    End If
                Catch ex As Exception
                    Utx.Globale.Log.Info(Twain.ErrorString)
                End Try
            End Using
            Log.Info("trovati {0} dispositivi TWAIN", {ListaScanner.Count})

            mReady = (ListaScanner.Count > 0)
            mIsBusy = False
            RaiseEvent InizializzazioneCompletata(mReady)

        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
            mReady = False
        End Try
    End Sub

    Public Sub RilevaScanner(Twain As Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain)
        Try
            Log.Info("leggo dispositivi twain disponibili nel sistema")
            mReady = False
            mIsBusy = True

            Twain.CloseSourceManager()

            Twain.IfThrowException = True
            Twain.SupportedDeviceType = Dynamsoft.DotNet.TWAIN.Enums.EnumSupportedDeviceType.SDT_TWAIN

            Try
                ListaScanner.Clear()
                Log.Info(Twain.SourceCount)

                If Twain.SourceCount = 0 Then
                    Log.Info("nessun dispositivo twain rilevato")
                    If Utx.ApplicationLog.LivelloLog = Utx.ApplicationLog.Livello.DEBUG Then
                        Call New Utx.NotificaRapida(Utx.FormNotifica.AltezzaNotifica.MEZZA).Visualizza("Nessun dispositivo TWAIN rilevato")
                    End If
                Else
                    If Utx.ApplicationLog.LivelloLog = Utx.ApplicationLog.Livello.DEBUG Then
                        Call New Utx.NotificaRapida(Utx.FormNotifica.AltezzaNotifica.MEZZA).Visualizza(String.Format("Rilevati {0} dispositivi TWAIN", Twain.SourceCount))
                    End If

                    For i As Integer = 0 To Twain.SourceCount - 1
                        Log.Info("Dispositivo trovato: {0}", {Twain.SourceNameItems(i)})
                        ListaScanner.Add(New Scanner(i, Twain.SourceNameItems(i)))
                    Next
                End If
            Catch ex As Exception
                Utx.Globale.Log.Info(Twain.ErrorString)
            End Try
            Log.Info("trovati {0} dispositivi TWAIN", {ListaScanner.Count})

            mReady = (ListaScanner.Count > 0)
            mIsBusy = False

        Catch ex As Exception
            Utx.Globale.Log.Info(ex)
            mReady = False
        End Try
    End Sub

    Friend Shared Function IsDuplex(IndiceScanner As Integer) As Boolean
        Using Twain As New Dynamsoft.DotNet.TWAIN.DynamicDotNetTwain(Utx.Licenze.DynamicDotNetTwain_5_2_508_0)
            Try
                If IndiceScanner >= 0 Then
                    Twain.SelectSourceByIndex(IndiceScanner)
                    Twain.OpenSource()

                    Return Twain.CapIfSupported(Dynamsoft.DotNet.TWAIN.Enums.TWCapability.CAP_DUPLEX)
                Else
                    Return False
                End If

            Catch ex As Exception
                Utx.Globale.Log.Info(String.Format("Errore {0}: {1}", Twain.ErrorCode, Twain.ErrorString))
                Return False
            Finally
                Twain.CloseSource()
            End Try
        End Using
    End Function
End Class

Public Class Scanner

    Sub New(Index As Integer, Name As String)
        mIndex = Index
        mName = Name
        mDuplex = ""
    End Sub

    Private mIndex As Integer
    Public Property Index() As Integer
        Get
            Return mIndex
        End Get
        Set(value As Integer)
            mIndex = value
        End Set
    End Property

    Private mName As String
    Public Property Name() As String
        Get
            Return mName
        End Get
        Set(value As String)
            mName = value
        End Set
    End Property

    Private mDuplex As String
    Public Function Duplex() As Boolean
        'se non è ancora stato rilevato controlla
        If String.IsNullOrEmpty(mDuplex) Then
            If Scanners.IsDuplex(mIndex) = True Then
                mDuplex = "S"
            Else
                mDuplex = "N"
            End If
        End If
        Return (mDuplex = "S")
    End Function
End Class