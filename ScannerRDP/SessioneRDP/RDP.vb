Public Class RDP

    Friend Event ChiamataRDP()

    Friend Sub Analisi(Testo As String)

        Try
            If Testo.ToUpper.StartsWith("UTSCAN:") Then

                'pulisco gli appunti
                Clipboard.Clear()

                'tolgo il tag iniziale
                Testo = Testo.Substring(7).Trim
                'elimino caratteri di controllo
                Testo = Testo.Replace(ControlChars.Lf, "").
                              Replace(ControlChars.Cr, "").
                              Replace(ControlChars.CrLf, "").Trim

                mChiamata = True
                mCliente = Testo.Split(";")(0)
                mPratica = Testo.Split(";")(1)
                mPathDestinazioneDoc = Testo.Split(";")(2)

                'genero l'evento che avvisa della chiamata
                RaiseEvent ChiamataRDP()
            Else
                mChiamata = False
                mCliente = ""
                mPratica = ""
                mPathDestinazioneDoc = ""
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private mCliente As String
    Public ReadOnly Property Cliente() As String
        Get
            Return mCliente
        End Get
    End Property

    Private mPratica As String
    Public ReadOnly Property Pratica() As String
        Get
            Return mPratica
        End Get
    End Property

    Private mPathDestinazioneDoc As String
    Public ReadOnly Property PathDestinazioneDoc() As String
        Get
            Return mPathDestinazioneDoc
        End Get
    End Property

    Private mChiamata As String
    Public ReadOnly Property Chiamata() As String
        Get
            Return mChiamata
        End Get
    End Property

End Class
