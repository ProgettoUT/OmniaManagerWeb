
Public Class RtfManager
    Private Const DESTINATARIO_CODICEFISCALE = "DESTINATARIO_CODICEFISCALE"
    Private Const DESTINATARIO_TITOLO = "DESTINATARIO_TITOLO"
    Private Const DESTINATARIO_QUALIFICA = "DESTINATARIO_QUALIFICA"
    Private Const DESTINATARIO_NOME = "DESTINATARIO_NOME"
    Private Const DESTINATARIO_PRESSO = "DESTINATARIO_PRESSO"
    Private Const DESTINATARIO_INDIRIZZO = "DESTINATARIO_INDIRIZZO"
    Private Const DESTINATARIO_LOCALITA = "DESTINATARIO_LOCALITA"
    Private Const DESTINATARIO_CAP = "DESTINATARIO_CAP"
    Private Const DESTINATARIO_PROVINCIA = "DESTINATARIO_PROVINCIA"

    Private Const POLIZZA_NUMERO = "POLIZZA_NUMERO"
    Private Const POLIZZA_SCADENZA = "POLIZZA_SCADENZA"
    Private Const POLIZZA_PREMIO = "POLIZZA_PREMIO"
    Private Const POLIZZA_TIPO = "POLIZZA_TIPO"
    Private Const TIPO_CARICO = "TIPO_CARICO"

    Private Const RTF_ELENCO_CON_PREMI = "ELENCO_CON_PREMI"
    Private Const RTF_ELENCO_SENZA_PREMI = "ELENCO_SENZA_PREMI"

    Private Const DATA_ODIERNA = "DATA_ODIERNA"

    Private fileRtf As String = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".rtf"
    Private writer As New IO.StreamWriter(fileRtf, False, Text.Encoding.GetEncoding(1252))
    Private hasTipoCarico As Boolean

    Public Shared Function Stampa(ByRef modello As String, estrazione As DataTable, aggrega As Boolean) As String
        Return New RtfManager().CreaRtf(modello, estrazione, aggrega)
    End Function

    Private Function CreaRtf(modello As String, estrazione As DataTable, aggrega As Boolean) As String
        hasTipoCarico = estrazione.Columns.Contains(TIPO_CARICO)
        modello = PreFormatta(modello)

        Dim destinatari = CreaDestinatari(estrazione, aggrega)
        StampaDocumentoInizio()
        For Each destinatario As DataRow In destinatari.Rows
            StampaPaginaInizio(destinatario)
            StampaPaginaCorpo(modello, destinatario)
            StampaPaginaFine(destinatario)
        Next
        StampaDocumentoFine()
        Return fileRtf
    End Function


    Private Function CreaDestinatari(estrazione As DataTable, aggrega As Boolean) As DataTable
        Dim destinatarioPrecedente As DataRow = Nothing
        Dim testataConPremi As String
        Dim testataSenzaPremi As String
        Dim elencoConPremi As String = ""
        Dim elencoSenzaPremi As String = ""
        Dim totale As Decimal = 0

        If hasTipoCarico Then
            '{\b\ul Oggetto:\par\par}
            testataConPremi = "{\ql\trowd\cellx1877\cellx3436\cellx6555\cellx8256\cellx9526"
            testataConPremi &= "\b1 Numero Polizza\intbl\cell Scadenza\intbl\cell Tipo Polizza\intbl\cell Tipo Carico\intbl\cell{\qr Premio\intbl\cell}\b0\row"
            testataConPremi &= "\trrh-113\cell\cell\cell\cell\cell\row\trrh0"

            testataSenzaPremi = "{\ql\trowd\cellx1877\cellx3436\cellx6555\cellx9526"
            testataSenzaPremi &= "\b1 Numero Polizza\intbl\cell Scadenza\intbl\cell Tipo Polizza\intbl\cell Tipo Carico\intbl\b0\cell\row"
            testataSenzaPremi &= "\trrh-113\cell\cell\cell\cell\row\trrh0"
        Else
            testataConPremi = "{\ql\trowd\cellx1877\cellx3436\cellx8256\cellx9526"
            testataConPremi &= "\b1 Numero Polizza\intbl\cell Scadenza\intbl\cell Tipo Polizza\intbl\cell{\qr Premio\intbl\cell}\b0\row"
            testataConPremi &= "\trrh-113\cell\cell\cell\cell\row\trrh0"

            testataSenzaPremi = "{\ql\trowd\cellx1877\cellx3436\cellx6555"
            testataSenzaPremi &= "\b1 Numero Polizza\intbl\cell Scadenza\intbl\cell Tipo Polizza\intbl\b0\cell\row"
            testataSenzaPremi &= "\trrh-113\cell\cell\cell\row\trrh0"
        End If

        If Not estrazione.Columns.Contains(RTF_ELENCO_CON_PREMI) Then
            estrazione.Columns.Add(RTF_ELENCO_CON_PREMI, GetType(String))
        End If

        If Not estrazione.Columns.Contains(RTF_ELENCO_SENZA_PREMI) Then
            estrazione.Columns.Add(RTF_ELENCO_SENZA_PREMI, GetType(String))
        End If
        If Not estrazione.Columns.Contains(DESTINATARIO_TITOLO) Then
            estrazione.Columns.Add(DESTINATARIO_TITOLO, GetType(String))
        End If

        Dim destinatari As DataTable = estrazione.Clone

        For Each destinatarioAttuale As DataRow In estrazione.Rows
            If destinatarioPrecedente Is Nothing Then
                destinatarioPrecedente = destinatarioAttuale
                elencoConPremi = testataConPremi & DettagioConPremi(destinatarioAttuale)
                elencoSenzaPremi = testataSenzaPremi & DettagioSenzaPremi(destinatarioAttuale)
                If destinatarioAttuale.Table.Columns.Contains(POLIZZA_PREMIO) Then
                    totale = destinatarioAttuale(POLIZZA_PREMIO)
                End If
            ElseIf (aggrega = True) AndAlso GetField(destinatarioPrecedente, DESTINATARIO_CODICEFISCALE).Equals(GetField(destinatarioAttuale, DESTINATARIO_CODICEFISCALE)) Then
                elencoConPremi &= DettagioConPremi(destinatarioAttuale)
                elencoSenzaPremi &= DettagioSenzaPremi(destinatarioAttuale)
                If destinatarioAttuale.Table.Columns.Contains(POLIZZA_PREMIO) Then
                    totale += destinatarioAttuale(POLIZZA_PREMIO)
                End If
            Else
                If hasTipoCarico Then
                    elencoConPremi &= String.Format("\cell\cell\cell\cell\cell\row\cell\cell\cell TOTALE\intbl\cell{{\qr {0}\intbl\cell}}\row}}\pard\qj", totale.ToString("#,##0.00"))
                Else
                    elencoConPremi &= String.Format("\cell\cell\cell\cell\row\cell\cell{{\qr TOTALE\intbl\cell}}{{\qr {0}\intbl\cell}}\row}}\pard\qj", totale.ToString("#,##0.00"))
                End If

                elencoSenzaPremi &= "}\pard\qj"
                destinatarioPrecedente(RTF_ELENCO_CON_PREMI) = elencoConPremi
                destinatarioPrecedente(RTF_ELENCO_SENZA_PREMI) = elencoSenzaPremi
                destinatarioPrecedente(DESTINATARIO_TITOLO) = GetDestinatatioTitolo(destinatarioPrecedente)

                destinatari.ImportRow(destinatarioPrecedente)
                destinatarioPrecedente = destinatarioAttuale
                elencoConPremi = testataConPremi & DettagioConPremi(destinatarioAttuale)
                elencoSenzaPremi = testataSenzaPremi & DettagioSenzaPremi(destinatarioAttuale)
                If destinatarioAttuale.Table.Columns.Contains(POLIZZA_PREMIO) Then
                    totale = destinatarioAttuale(POLIZZA_PREMIO)
                End If
            End If
        Next

        If hasTipoCarico Then
            elencoConPremi &= String.Format("\cell\cell\cell\cell\cell\row\cell\cell\cell TOTALE\intbl\cell{{\qr {0}\intbl\cell}}\row}}\pard\qj", totale.ToString("#,##0.00"))
        Else
            elencoConPremi &= String.Format("\cell\cell\cell\cell\row\cell\cell{{\qr TOTALE\intbl\cell}}{{\qr {0}\intbl\cell}}\row}}\pard\qj", totale.ToString("#,##0.00"))
        End If
        elencoSenzaPremi &= "}\pard\qj"

        destinatarioPrecedente(RTF_ELENCO_CON_PREMI) = elencoConPremi
        destinatarioPrecedente(RTF_ELENCO_SENZA_PREMI) = elencoSenzaPremi
        destinatarioPrecedente(DESTINATARIO_TITOLO) = GetDestinatatioTitolo(destinatarioPrecedente)
        destinatari.ImportRow(destinatarioPrecedente)

        For Each colonna As DataColumn In destinatari.Columns
            colonna.Caption = "#" & colonna.ColumnName.ToUpper & "#"
        Next

        Return destinatari
    End Function

    Private Function DettagioConPremi(destinatario As DataRow) As String
        If hasTipoCarico Then
            Return String.Format("\*{0}\intbl\cell {1}\intbl\cell {2}\intbl\cell {3}\intbl\cell{{\qr {4}\intbl\cell}}\row",
                                 GetField(destinatario, POLIZZA_NUMERO),
                                 GetField(destinatario, POLIZZA_SCADENZA),
                                 GetField(destinatario, POLIZZA_TIPO),
                                 GetField(destinatario, TIPO_CARICO),
                                 GetField(destinatario, POLIZZA_PREMIO))
        Else
            Return String.Format("\*{0}\intbl\cell {1}\intbl\cell {2}\intbl\cell{{\qr {3}\intbl\cell}}\row",
                                 GetField(destinatario, POLIZZA_NUMERO),
                                 GetField(destinatario, POLIZZA_SCADENZA),
                                 GetField(destinatario, POLIZZA_TIPO),
                                 GetField(destinatario, POLIZZA_PREMIO))
        End If
    End Function

    Private Function DettagioSenzaPremi(destinatario As DataRow) As String
        If hasTipoCarico Then
            Return String.Format("\*{0}\intbl\cell {1}\intbl\cell {2}\intbl\cell {3}\intbl\cell\row",
                                 GetField(destinatario, POLIZZA_NUMERO),
                                 GetField(destinatario, POLIZZA_SCADENZA),
                                 GetField(destinatario, POLIZZA_TIPO),
                                 GetField(destinatario, TIPO_CARICO))
        Else
            Return String.Format("\*{0}\intbl\cell {1}\intbl\cell {2}\intbl\cell\row",
                                 GetField(destinatario, POLIZZA_NUMERO),
                                 GetField(destinatario, POLIZZA_SCADENZA),
                                 GetField(destinatario, POLIZZA_TIPO))
        End If
    End Function

    Private Sub StampaPaginaInizio(destinatario As DataRow)
        Static paginaSuccessiva As Boolean

        If paginaSuccessiva = False Then
            paginaSuccessiva = True
        Else
            writer.Write("\page")
        End If

        writer.Write("{\pard\fs22\par\par\par\par\par\par\par\par\par") ' imposto carattere 11 per l'indirizzo
        'writer.Write("\tx5385") ' tab (ho tolto il tag \tab dalle righe successive)
        writer.Write("\lin5385") ' inizio paragrafo
        Write(" {0}\line", destinatario, DESTINATARIO_TITOLO)
        Write(" {0}\line", destinatario, DESTINATARIO_QUALIFICA)
        Write(" {0}\line", destinatario, DESTINATARIO_NOME)
        Write(" {0}\line", destinatario, DESTINATARIO_PRESSO)
        Write(" {0}\line", destinatario, DESTINATARIO_INDIRIZZO)
        Write(" {0}", destinatario, DESTINATARIO_CAP)
        Write(" {0}", destinatario, DESTINATARIO_LOCALITA)
        Write(" ({0})", destinatario, DESTINATARIO_PROVINCIA)

        writer.Write("\par\pard\qj ")

    End Sub

    Private Function GetField(datarow As DataRow, nomeCampo As String) As String
        If datarow.Table.Columns.Contains(nomeCampo) = False Then
            Return ""
        ElseIf TypeOf datarow(nomeCampo) Is Date Then
            Dim Data = CDate(datarow(nomeCampo))

            Return Data.ToString("dd MMM yyyy")
        ElseIf TypeOf datarow(nomeCampo) Is Double Then
            Dim Data = CDbl(datarow(nomeCampo))

            Return Data.ToString("#,##0.00")
        Else
            Return datarow(nomeCampo).ToString.Trim
        End If

    End Function

    Private Function GetDestinatatioTitolo(datarow As DataRow) As String
        If datarow.Table.Columns.Contains(DESTINATARIO_CODICEFISCALE) = False Then
            Return ""
        ElseIf Len(GetField(datarow, DESTINATARIO_CODICEFISCALE)) = 11 Then
            Return "Spett.le"
        ElseIf Mid(GetField(datarow, DESTINATARIO_CODICEFISCALE), 10, 2) > "40" Then
            Return "Gentile Signora"
        Else
            Return "Gentile Signore"
        End If

    End Function

    Private Sub Write(ByRef formato As String, ByRef datarow As DataRow, nomeCampo As String)
        If datarow.Table.Columns.Contains(nomeCampo) Then
            nomeCampo = datarow(nomeCampo).ToString.Trim
        Else
            nomeCampo = "MANCA " + nomeCampo
        End If
        If nomeCampo.Length > 0 Then
            writer.Write(String.Format(formato, nomeCampo))
        End If
    End Sub


    Private Sub StampaPaginaCorpo(modello As String, destinatario As DataRow)
        writer.Write(Replace(modello, destinatario))
    End Sub

    Private Sub StampaPaginaFine(destinatario As DataRow)
        Dim modelloPaginaFine = "}"
        writer.Write(Replace(modelloPaginaFine, destinatario))
    End Sub

    Private Sub StampaDocumentoInizio()
        writer.Write("{\rtf1\ansi\ansicpg1252\uc1\deff0\deflang1033\deflangfe1040")
        writer.Write("{\fonttbl{\f0\froman\fcharset0\fprq2 Calibri;}}")
        writer.Write("{\colortbl;\red0\green0\blue0;}")
        writer.Write("\paperw11906\paperh16838\margl850\margr850\margt850\margb850\widowctrl\ftnbj\aenddoc\hyphhotz283\hyphcaps0\viewkind1\viewscale100")
        writer.Write("\fet0\sectd\linex0\headery567\footery567\colsx709\sectdefaultcl\qj")
        writer.Write("\pard ")
    End Sub

    Private Sub StampaDocumentoFine()
        writer.Write("}")
        writer.Close()
    End Sub

    Private Function Replace(modello As String, destinatario As DataRow) As String
        For Each colonna As DataColumn In destinatario.Table.Columns
            If destinatario.IsNull(colonna) Then
                modello = modello.Replace(colonna.Caption, "")
            Else
                modello = modello.Replace(colonna.Caption, destinatario.Item(colonna))
            End If
        Next
        Return modello
    End Function

    Private Function PreFormatta(modello As String) As String
        modello = modello.Replace("#DATA_ODIERNA#", Today.ToString("dd MMMM yyyy"))
        modello = modello.Replace("###CITTA###", Utx.Globale.ProfiloEnteGestore.Localita)
        modello = modello.Replace("\", "\\").Replace("{", "\{").Replace("}", "\}")
        modello = modello.Replace("+g", "\b1 ").Replace("-g", "\b0 ")
        modello = modello.Replace("+c", "\i1 ").Replace("-c", "\i0 ")
        modello = modello.Replace("+s", "\ul1 ").Replace("-s", "\ul0 ")
        modello = modello.Replace("finepagina", "\page ")
        modello = modello.Replace("[]", "{\field{\*\fldinst SYMBOL 99 \\f ""Webdings"" \\s 11}}")
        '{\field{\*\fldinst SYMBOL 99 \\f "Webdings" \\s 11}{\fldrslt\f172\fs22}}}

        Dim righe As String() = modello.Split(vbNewLine)
        'righe(0) = "{\fs40\b " & righe(0) & "}"

        Return String.Join("\par ", righe)
    End Function
End Class
