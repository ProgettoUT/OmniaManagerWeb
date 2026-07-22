Public Class Report
    Public ArchiviTotaliCount As Integer
    Public ArchiviImportatiCount As Integer
    Public ArchiviMancantiCount As Integer
    Public ArchiviInStoricoCount As Integer
    Public ArchiviInArrivoCount As Integer
    Public ArchiviDisponibiliCount As Integer

    Public NumeroFileDaScaricare As Integer = 0
    Public NumeroFileScaricati As Integer = 0
    Public InizioDownload As DateTime
    Public FineDownload As DateTime

    Public NumeroFileDaScompattare As Integer = 0
    Public NumeroFileScompattati As Integer = 0

    Public NumeroFileDaImportare As Integer = 0
    Public NumeroFileImportati As Integer = 0
    Public NumeroFileNonImportati As Integer = 0

    Public NumeroRecordDaImportare As Integer = 0    'da ricavare dalla dimenzione
    Public NumeroRecordSenzaConsenso As Integer = 0  'totale righe di competenza
    Public NumeroRecordImportati As Integer = 0      'totale righe elaborati correttamente
    Public NumeroRecordScartati As Integer = 0       'righe che non sono definite nelle specifiche di importazione
    Public NumeroRecordNonImportati As Integer = 0   'righe per i quali si è verificato un errore di elaborazione
    Public NumeroRecordEsclusi As Integer = 0        'righe per i quali si è applicato il filtro
    Public NumeroRecordObsolete As Integer = 0        'righe per i quali sono obsolete

    Public DettaglioPerTipoRecord As New Dictionary(Of String, Dettaglio)
    Public InizioImportazione As DateTime
    Public FineImportazione As DateTime

    Public Overrides Function ToString() As String
        Dim s As String = vbNewLine & vbNewLine
        s &= "REPORT ELABORAZIONE ARCHIVI: " & vbNewLine
        s &= "TOTALI           : " & ArchiviTotaliCount & vbNewLine
        s &= "di cui " & vbNewLine
        s &= "  Importati      : " & ArchiviImportatiCount & vbNewLine
        s &= "  Mancanti       : " & ArchiviMancantiCount & vbNewLine
        s &= "  in Storico     : " & ArchiviInStoricoCount & vbNewLine
        s &= "  In Arrivo      : " & ArchiviInArrivoCount & vbNewLine
        s &= "  In Server      : " & ArchiviDisponibiliCount & vbNewLine & vbNewLine
        ' inserire dettagio file per codice
        ' sotto trace inserire l'elenco file presenti nel server

        s &= "REPORT IMPORTAZIONE: " & vbNewLine
        s &= "Inizio download               : " & InizioDownload & vbNewLine
        s &= "  Totale files da scaricare   : " & NumeroFileDaScaricare & vbNewLine
        s &= "  Numero files scaricati      : " & NumeroFileScaricati & vbNewLine
        s &= "Fine download                 : " & FineDownload & vbNewLine & vbNewLine

        s &= "Inizio importazione           : " & InizioImportazione & vbNewLine
        s &= "  Totale files da importare   : " & NumeroFileDaImportare & vbNewLine
        s &= "  Numero files importati      : " & NumeroFileImportati & vbNewLine
        s &= "  Numero files non importati  : " & NumeroFileNonImportati & vbNewLine
        s &= vbNewLine
        s &= "  Totale righe da importare   : " & NumeroRecordDaImportare & vbNewLine
        s &= "  Numero righe importati      : " & NumeroRecordImportati & vbNewLine
        s &= "  Numero righe escluse        : " & NumeroRecordEsclusi & vbNewLine
        s &= "  Numero righe senza consenso : " & NumeroRecordSenzaConsenso & vbNewLine
        s &= "  Numero righe non definite   : " & NumeroRecordScartati & vbNewLine
        s &= "  Numero righe obsolete       : " & NumeroRecordObsolete & vbNewLine
        s &= "  Numero righe con errori     : " & NumeroRecordNonImportati & vbNewLine
        s &= "Fine importazione             : " & FineImportazione & vbNewLine & vbNewLine

        For Each d In DettaglioPerTipoRecord
            s &= "DETTAGLIO RECORD:" & d.Key & vbNewLine
            With d.Value
                s &= "  Totale righe da importare   : " & .NumeroRecordDaImportare & vbNewLine
                s &= "  Numero righe importati      : " & .NumeroRecordImportati & vbNewLine
                s &= "  Numero righe escluse        : " & .NumeroRecordEsclusi & vbNewLine
                s &= "  Numero righe senza consenso : " & .NumeroRecordSenzaConsenso & vbNewLine
                s &= "  Numero righe non definite   : " & .NumeroRecordScartati & vbNewLine
                s &= "  Numero righe obsolete       : " & .NumeroRecordObsolete & vbNewLine
                s &= "  Numero righe con errori     : " & .NumeroRecordNonImportati & vbNewLine
            End With
        Next

        Return s
    End Function

    Class Dettaglio
        Public NumeroRecordDaImportare As Integer = 0    'da ricavare dalla dimenzione
        Public NumeroRecordSenzaConsenso As Integer = 0  'totale righe di non competenza
        Public NumeroRecordImportati As Integer = 0      'totale righe elaborati correttamente
        Public NumeroRecordScartati As Integer = 0       'righe che non sono definite nelle specifiche di importazione
        Public NumeroRecordNonImportati As Integer = 0   'righe per i quali si è verificato un errore di elaborazione
        Public NumeroRecordEsclusi As Integer = 0        'righe per i quali si è applicato il filtro
        Public NumeroRecordObsolete As Integer = 0        'righe obsolete

        Public Shared Operator +(d1 As Dettaglio, d2 As Dettaglio) As Dettaglio
            d1.NumeroRecordDaImportare += d2.NumeroRecordDaImportare
            d1.NumeroRecordSenzaConsenso += d2.NumeroRecordSenzaConsenso
            d1.NumeroRecordImportati += d2.NumeroRecordImportati
            d1.NumeroRecordScartati += d2.NumeroRecordScartati
            d1.NumeroRecordNonImportati += d2.NumeroRecordNonImportati
            d1.NumeroRecordEsclusi += d2.NumeroRecordEsclusi
            d1.NumeroRecordObsolete += d2.NumeroRecordObsolete
            Return d1
        End Operator
    End Class
End Class
