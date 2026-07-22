Public Class P00000ST
    Protected Const MargineTp As Single = 297 - 10
    Protected Const MargineBt As Single = 10
    Protected Const MargineSx As Single = 10
    Protected Const MargineDx As Single = 210 - 10
    Protected VerticaleUno As Single = 80
    Protected VerticaleDue As Single = 170
    Protected VerticaleTre As Single = 188
    Protected Const ds As Single = 3
    Protected Const dy As Single = 4

    Protected FileName As String
    Protected pdf As Pdf
    Protected tab As Single() = {MargineSx + 1, VerticaleUno - 1, VerticaleDue - 1, VerticaleTre - 1, (VerticaleTre + MargineDx) / 2, MargineDx}
    Protected y As Single = 0
    Protected pagina As Integer = 0

    Private Shared sharedPdf As Pdf

    Private mNewFormato As Boolean

    Public Sub New()
        mNewFormato = False
    End Sub

    Public Sub New(NewFormato As Boolean)
        mNewFormato = NewFormato
    End Sub

    Public Shared Function rg(ByVal r As Single, ByVal g As Single, ByVal b As Single) As Integer
        Return RGB(r * 255, g * 255, b * 255)
    End Function

    Shared Function FormatEuro(ByVal value As Decimal) As String
        If value = 0D Then Return "-"
        Return FormatNumber(value, 2)
    End Function

    Shared Function FormatScelto(ByVal stato As StatoCopertura) As String
        If stato = StatoCopertura.attiva Then
            Return "Si"
        ElseIf stato = StatoCopertura.esclusa Then
            Return "No"
        Else
            Return "-"
        End If
    End Function

    Shared Function FormatSiNo(ByVal isattivo As Boolean) As String
        Return IIf(isattivo, "Si", "No")
    End Function

    Function Formatta(ByVal garanzia As Garanzia) As String
        Dim s As String = ""
        If garanzia IsNot Nothing Then
            With garanzia
                If String.IsNullOrEmpty(.CombinazioneStampa) = False Then
                    s = .CombinazioneStampa
                ElseIf mNewFormato Then
                    If .Limite > 0 Then
                        s += " - Limite " & FormatPercent(.Limite / 100.0)
                        If .Massimale > 0 Then
                            s += " Massimo " & FormatCurrency(.Massimale)
                        End If
                    ElseIf .Massimale = 999999 Then
                        s += " - Massimale illimitato"
                    ElseIf .Massimale > 0 Then
                        s += " - Massimale " & FormatCurrency(.Massimale)
                    End If

                    If .MassimalePerAnno > 0 Then
                        s += " - Limite annuale " & FormatCurrency(.MassimalePerAnno)
                    End If

                    If .Scoperto > 0 Then
                        s += " - Scoperto " & FormatPercent(.Scoperto / 100.0)
                        If .Franchigia > 0 Then
                            s += " Minimo " & FormatCurrency(.Franchigia)
                        End If
                    ElseIf .Franchigia > 0 Then
                        s += " - Franchigia " & FormatCurrency(.Franchigia)
                    End If

                    If s.Length > 3 Then s = s.Substring(3)
                Else
                    If .Massimale = 999999 Then
                        s += "Illimitato"
                    ElseIf .Massimale > 0 Then
                        s += FormatCurrency(.Massimale)
                    ElseIf .Scoperto > 0 Then
                        s += "Scoperto " & FormatPercent(.Scoperto / 100.0)
                        If .Franchigia > 0 Then
                            s += " minimo " & FormatCurrency(.Franchigia)
                        End If
                    ElseIf .Franchigia > 0 Then
                        s += "Franchigia " & FormatCurrency(.Franchigia)
                    ElseIf .Limite > 0 Then
                        s += "Limite " & FormatPercent(.Limite / 100.0)
                    End If
                End If
            End With
        End If

        Return Trim(s)
    End Function

    Shared Function Formatta(ByVal valore As Boolean) As String
        If valore Then
            Return "Si"
        Else
            Return "No"
        End If
    End Function

    Function Formatta(ByVal partita As Partita) As String
        Dim s As String = ""
        If partita IsNot Nothing Then
            With partita
                If .SommaAssicurata > 0 Then
                    If mNewFormato Then
                        s = "Somma assicurata " & FormatCurrency(.SommaAssicurata)
                    Else
                        s = FormatCurrency(.SommaAssicurata)
                    End If
                End If
            End With
        End If

        Return Trim(s)
    End Function

    Function Formatta(Copertura As CoperturaSingola) As String
        Dim s As String = ""

        If Copertura.IsBase And Copertura.Partita IsNot Nothing Then
            With Copertura.Partita
                If .SommaAssicurata > 0 Then
                    s = " - Somma assicurata " & FormatCurrency(.SommaAssicurata)
                End If
            End With
        End If

        If Copertura.Garanzia IsNot Nothing Then
            With Copertura.Garanzia
                If String.IsNullOrEmpty(.CombinazioneStampa) = False Then
                    s &= " - " & .CombinazioneStampa
                End If
                If .Limite > 0 Then
                    s &= " - Limite " & FormatPercent(.Limite / 100.0)
                    If .Massimale > 0 Then
                        s &= " Massimo " & FormatCurrency(.Massimale)
                    End If
                ElseIf .Massimale = 999999D Then
                    s &= " - Massimale illimitato"
                ElseIf .Massimale > 0 Then
                    s &= " - Massimale " & FormatCurrency(.Massimale)
                End If

                If .MassimalePerAnno > 0 Then
                    s &= " - Limite annuale " & FormatCurrency(.MassimalePerAnno)
                End If

                If .Scoperto > 0 Then
                    s &= " - Scoperto " & FormatPercent(.Scoperto / 100.0)
                    If .Franchigia > 0 Then
                        s &= " Minimo " & FormatCurrency(.Franchigia)
                    End If
                ElseIf .Franchigia > 0 Then
                    s &= " - Franchigia " & FormatCurrency(.Franchigia)
                End If
            End With
        End If

        If s.Length > 3 Then s = s.Substring(3)

        Return Trim(s)
    End Function

    Public Sub StampaInizio(ByVal preventivo As Prodotto, ByVal options As StampaOptions)
        Dim inizializza As Boolean = False

        If TypeOf preventivo Is Fascicolo Then
            sharedPdf = New Pdf()
            pdf = sharedPdf
            inizializza = True
        ElseIf (options And StampaOptions.StampaFascicolo) = 0 Then
            pdf = New Pdf()
            inizializza = True
        Else
            pdf = sharedPdf
        End If

        If inizializza = True Then
            FileName = System.IO.Path.GetTempPath & preventivo.DescrizioneProdotto & ".pdf"
            ' Delete the file if it exists.
            If System.IO.File.Exists(FileName) Then
                Try
                    System.IO.File.Delete(FileName)

                Catch ex As Exception
                    FileName = Replace(System.IO.Path.GetTempFileName(), ".tmp", ".pdf")
                End Try
                System.IO.File.Delete(FileName)

            End If
            pdf.Title = preventivo.DescrizioneProdotto

            pdf.InitPDFFile(FileName)
            pdf.LoadFont("Fnt1", "TIMESNEWROMAN")
            pdf.LoadFont("FntI", "TIMESNEWROMAN", UniQuota.Pdf.pdfFontStyle.pdfItalic)
            pdf.LoadFont("FntB", "TIMESNEWROMAN", UniQuota.Pdf.pdfFontStyle.pdfBold)
            pdf.LoadFont("FntBI", "TIMESNEWROMAN", UniQuota.Pdf.pdfFontStyle.pdfBoldItalic)

            pdf.LoadFont("FaN", "Arial")
            pdf.LoadFont("FaI", "Arial", UniQuota.Pdf.pdfFontStyle.pdfItalic)
            pdf.LoadFont("FaB", "Arial", UniQuota.Pdf.pdfFontStyle.pdfBold)

            pdf.LoadImgFromBMPRecources("logoDitta", "LogoUnipol")
            If TypeOf preventivo Is Fascicolo Then
                For Each p As Prodotto In CType(preventivo, Fascicolo).Prodotti
                    pdf.LoadImgFromBMPRecources(p.NamespaceProdotto, p.NamespaceProdotto)
                Next
            Else
                pdf.LoadImgFromBMPRecources(preventivo.NamespaceProdotto, preventivo.NamespaceProdotto)
            End If

            pdf.ScaleMode = pdf.pdfScaleMode.pdfMillimeter
        End If
    End Sub

    Public Sub StampaIntestazionePagina(ByVal preventivo As Prodotto, ByVal options As StampaOptions)
        If pagina > 0 Then
            pdf.EndPage()
        End If
        pdf.BeginPage()
        pagina += 1

        pdf.DrawImg("logoDitta", MargineSx, MargineTp, 40, 14)
        If Not TypeOf preventivo Is Fascicolo Then
            pdf.DrawImg(preventivo.NamespaceProdotto, MargineDx - 40, MargineTp, 40, 10)
        End If

        pdf.SetColorStroke(0)

        pdf.SetColorFill(Color.Black)
        If (options And StampaOptions.StampaAgenzia) = StampaOptions.StampaAgenzia Then
            With preventivo.Agenzia
                y = MargineTp
                If .Denominazione <> "" Then y -= ds : pdf.DrawText(105, y, "Agenzia di " & .Denominazione, "FntBI", 12, UniQuota.Pdf.pdfTextAlign.pdfCenter)
                If .Divisione <> "" Then y -= ds : pdf.DrawText(105, y, "Divisione " & .Divisione, "FntI", 8, UniQuota.Pdf.pdfTextAlign.pdfCenter)
                If .Indirizzo <> "" Then y -= ds : pdf.DrawText(105, y, .Indirizzo, "FntI", 8, UniQuota.Pdf.pdfTextAlign.pdfCenter)
                If .Localita <> "" Then
                    Dim address As String = ""
                    If .Cap <> "" Then address = .Cap & " - "
                    address &= .Localita
                    If .Provincia <> "" Then address &= " (" & .Provincia & ")"
                    y -= ds : pdf.DrawText(105, y, address, "FntI", 8, UniQuota.Pdf.pdfTextAlign.pdfCenter)
                End If

                If .Telefono <> "" Then y -= ds : pdf.DrawText(105, y, "Tel " & .Telefono, "FntI", 8, UniQuota.Pdf.pdfTextAlign.pdfCenter)
                If .Fax <> "" Then y -= ds : pdf.DrawText(105, y, "Fax " & .Fax, "FntI", 8, UniQuota.Pdf.pdfTextAlign.pdfCenter)
                If .Email <> "" Then y -= ds : pdf.DrawText(105, y, "e-mail: " & .Email, "FntI", 8, UniQuota.Pdf.pdfTextAlign.pdfCenter)

                ' 19 luglio 2017: tolgo le informazione dell'intermediario dalla stampa
                'If .NumeroIscrizioneIsvap <> "" Then y -= ds : pdf.DrawText(105, y, "Iscrizione RUI n. " & .NumeroIscrizioneIsvap, "FntI", 8, UniQuota.Pdf.pdfTextAlign.pdfCenter)
                'With preventivo.Intermediario
                '    If .Nominativo <> "" Then y -= ds : pdf.DrawText(105, y, .Nominativo, "FntI", 8, UniQuota.Pdf.pdfTextAlign.pdfCenter)
                'End With

                'If .Localita <> "" Then y = 60 * dy + 1 : pdf.DrawText(MargineSx, y, "Preventivo emesso dall'Agenzia di " & .Localita, "Fnt1", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
            End With
        End If

        y = 62 * dy
        If preventivo.CodiceProdotto < 9900 Then
            pdf.DrawText(MargineSx, y, preventivo.CodiceProdotto & " - " & preventivo.DescrizioneProdotto, "FntB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
        Else
            pdf.DrawText(MargineSx, y, preventivo.DescrizioneProdotto, "FntB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
        End If
        If Not TypeOf preventivo Is Fascicolo Then
            pdf.DrawText(MargineDx, y, "Tariffe in vigore dal " & preventivo.DataEntrataVigore, "Fnt1", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
        End If
        y -= dy
        If preventivo.GiorniValiditaPreventivo = 0 Then preventivo.GiorniValiditaPreventivo = 60
        pdf.DrawText(MargineSx, y, String.Format("Validità del preventivo {0}gg", preventivo.GiorniValiditaPreventivo), "Fnt1", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
        pdf.DrawText(MargineDx, y, "Emesso il " & FormatDateTime(Date.Now, DateFormat.ShortDate), "Fnt1", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
    End Sub

    Public Sub StampaSezioneCliente(ByVal preventivo As Prodotto, ByVal options As StampaOptions)
        If (options And StampaOptions.StampaCliente) = StampaOptions.StampaCliente Then

            Dim righe As Integer = 0
            With preventivo.Cliente
                If .Nominativo <> "" Then righe += 1
                If .Indirizzo <> "" Then righe += 1
                If .Localita <> "" Then righe += 1
                If .Telefono <> "" Then righe += 1
                If .Email <> "" Then righe += 1
                If .CodiceFiscale <> "" Then righe += 1
            End With

            If righe > 0 Then
                y -= 1
                pdf.SetLineWidth(0.5)
                pdf.SetColorFill(Color.Beige)
                pdf.DrawRect(MargineSx, y - righe * dy - 1, MargineDx, y - 1, UniQuota.Pdf.pdfPathOptions.Stroked + UniQuota.Pdf.pdfPathOptions.Filled)
                pdf.SetColorFill(Color.Black)

                With preventivo.Cliente
                    If .Nominativo <> "" Then y -= dy : pdf.DrawText(tab(0), y, .Nominativo, "Fnt1", 9, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                    If .Indirizzo <> "" Then y -= dy : pdf.DrawText(tab(0), y, .Indirizzo, "Fnt1", 9, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                    If .Localita <> "" Then y -= dy : pdf.DrawText(tab(0), y, .Cap & " " & .Localita & " " & .Provincia, "Fnt1", 9, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                    If .Telefono <> "" Then y -= dy : pdf.DrawText(tab(0), y, .Telefono, "Fnt1", 9, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                    If .Email <> "" Then y -= dy : pdf.DrawText(tab(0), y, .Email, "Fnt1", 9, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                    If .CodiceFiscale <> "" Then y -= dy : pdf.DrawText(tab(0), y, .CodiceFiscale, "Fnt1", 9, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                End With
                y = y - dy
            End If
        End If
    End Sub

    Public Sub StampaRiepilogoPremi(ByVal preventivo As Prodotto, ByVal options As StampaOptions)
        Try

            With preventivo
                pdf.SetColorFill(Color.Black)
                y -= 1
                Dim yA As Single = y

                If .RischioDirezione Then
                    y -= dy
                    pdf.DrawText(tab(0), y, "PREVENTIVO RISERVATO ALLA DIREZIONE", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                Else

                    y -= dy
                    pdf.DrawText(tab(0), y, "PREMIO ANNUO DELLE GARANZIE SCELTE", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                    pdf.DrawText(tab(3), y, FormatEuro(.ListinoLordo), "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)

                    If .ScontoTecnico <> 0D Then
                        y -= dy
                        pdf.DrawText(tab(0), y, "SCONTO ABBINAMENTO GARANZIE", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                        pdf.DrawText(tab(3), y, FormatEuro(-.ScontoTecnico), "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
                    End If

                    If .ScontoConvenzione <> 0 Then
                        y -= dy
                        pdf.DrawText(tab(0), y, "SCONTO CONVENZIONE (" & FormatEuro(100 * .Convenzione.Percentuale) & "%)", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                        pdf.DrawText(tab(3), y, FormatEuro(-.ScontoConvenzione), "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
                    End If

                    If .ScontoFlexi <> 0 Then
                        y -= dy
                        pdf.DrawText(tab(0), y, "SCONTO APPLICATO (" & FormatEuro(100 * .Flexi) & "%)", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                        pdf.DrawText(tab(3), y, FormatEuro(-.ScontoFlexi), "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
                    End If

                    If preventivo.Sconti IsNot Nothing Then
                        For Each Sconto As Sconto In preventivo.Sconti
                            If Sconto.LordoSconto > 0D Then
                                y -= dy
                                pdf.DrawText(tab(0), y, Sconto.Descrizione.ToUpper & " (" & FormatEuro(100 * Sconto.PecentualeSconto) & "%)", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                                pdf.DrawText(tab(3), y, FormatEuro(-Sconto.LordoSconto), "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
                            End If
                        Next
                    End If

                    y -= dy
                    pdf.DrawText(tab(0), y, "TOTALE PREMIO FINITO ANNUO", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                    pdf.DrawText(tab(3), y, FormatEuro(.PremioLordo), "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)

                    y -= dy
                    pdf.DrawText(tab(0), y, "DI CUI TASSE", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                    pdf.DrawText(tab(3), y, FormatEuro(.PremioTasse), "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)

                    If (.Frazionamento <> FrazionamentiEnum.Annuale And .Frazionamento <> FrazionamentiEnum.Temporaneo) Then
                        y -= dy
                        pdf.DrawText(tab(0), y, "FRAZIONAMENTO " & decodeFrazionamento(.Decode, .Frazionamento), "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                        pdf.DrawText(tab(3), y, FormatEuro(.Interessi), "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
                        y -= dy
                        pdf.DrawText(tab(0), y, "PREMIO DELLE GARANZIE SCELTE", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                        pdf.DrawText(tab(3), y, FormatEuro(.PremioAnnuo), "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
                    End If

                    y -= dy
                    pdf.DrawText(tab(0), y, "DURATA IN " & Choose(.Periodo, "ANNI", "MESI", "GIORNI"), "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                    pdf.DrawText(tab(3), y, .Durata, "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)

                    'y -= dy
                    'pdf.DrawText(tab(0), y, "RATA DI PREMIO", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                    'pdf.DrawText(tab(3), y, FormatEuro(.PremioPrimaRata), "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)

                    If (.Frazionamento <> FrazionamentiEnum.UnicoAnticipato And .Frazionamento <> FrazionamentiEnum.Temporaneo) Then
                        y -= dy
                        pdf.DrawText(tab(0), y, "RATA " & decodeFrazionamento(.Decode, .Frazionamento), "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                        pdf.DrawText(tab(3), y, FormatEuro(.PremioPrimaRata), "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
                    Else
                        y -= dy
                        pdf.DrawText(tab(0), y, "PRIMA RATA", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                        pdf.DrawText(tab(3), y, FormatEuro(.PremioPrimaRata), "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
                        y -= dy
                        pdf.DrawText(tab(0), y, "RATA SUCCESSIVA", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                        pdf.DrawText(tab(3), y, FormatEuro(.PremioRataSuccessiva), "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
                    End If
                End If

                pdf.DrawRect(MargineDx, y - 1, MargineSx, yA - 1, UniQuota.Pdf.pdfPathOptions.Stroked)
            End With
        Catch ex As Exception
        End Try
    End Sub

    Public Sub StampaFine(ByVal preventivo As Prodotto, ByVal options As StampaOptions)
        pdf.EndPage()
        If (options And StampaOptions.StampaFascicolo) = 0 Then
            pdf.ClosePDFFile()
        End If
    End Sub

    Public Sub StampaFineFascicolo()
        pdf.ClosePDFFile()
        sharedPdf = Nothing
    End Sub

    Public Overridable Sub StampaDettaglio(ByVal preventivo As Prodotto, ByVal options As StampaOptions)
        With preventivo
            StampaDettaglioInizio(preventivo, options)

            For Each Sezione As Sezione In .Sezioni
                StampaSezione(Sezione, options)
            Next

            StampaDettaglioFine(preventivo, options)
        End With
    End Sub

    Public Overridable Sub StampaDettaglioInizio(ByVal preventivo As Prodotto, ByVal options As StampaOptions)
        With preventivo
            y -= 1
            y -= dy
            pdf.SetLineWidth(0.5)
            pdf.SetColorFill(Color.Yellow)
            pdf.DrawRect(MargineSx, y - 1, MargineDx, y + dy - 1, UniQuota.Pdf.pdfPathOptions.Stroked + UniQuota.Pdf.pdfPathOptions.Filled)
            pdf.SetColorFill(Color.Black)
            pdf.SetLineWidth(0.25)
            pdf.DrawRect(VerticaleUno, y - 1, VerticaleDue, y + dy - 1, UniQuota.Pdf.pdfPathOptions.Stroked)
            pdf.DrawRect(VerticaleDue, y - 1, VerticaleTre, y + dy - 1, UniQuota.Pdf.pdfPathOptions.Stroked)

            pdf.DrawText(tab(0), y, "SETTORE/PARTITE/CLAUSOLE", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
            'pdf.DrawText(tab(1), y, "FORMA DI ASSICURAZIONE", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
            pdf.DrawText(tab(2), y, "MASSIMALE/LIMITI", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
            pdf.DrawText(tab(3), y, "PREMIO", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
            pdf.DrawText(tab(4), y, "SCELTO", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfCenter)
        End With
    End Sub

    Public Overridable Sub StampaDettaglioFine(ByVal preventivo As Prodotto, ByVal options As StampaOptions)
        With preventivo
            pdf.SetLineWidth(0.5)
            pdf.DrawRect(MargineSx, y - 1, MargineDx, y - 1, UniQuota.Pdf.pdfPathOptions.Stroked)
        End With
    End Sub

    Public Overridable Sub StampaSezione(ByVal Sezione As Sezione, ByVal options As StampaOptions)
        StampaCoperture(New CoperturaStampa(Sezione.Coperture), Sezione.Descrizione, options)
    End Sub

    Public Overridable Sub StampaSezione(ByVal Sezione As Sezione, ByVal Descrizione As String, ByVal options As StampaOptions)
        StampaCoperture(New CoperturaStampa(Sezione.Coperture), Descrizione, options)
    End Sub

    Public Overridable Sub StampaParametri(ByVal preventivo As Prodotto, ByVal options As StampaOptions)

    End Sub

    Public Overridable Sub StampaParametri(ByVal ParamArray parametro() As String)
        Dim meta As Single = MargineSx + (MargineDx - MargineSx) / 2.0
        Dim tab As Single() = {MargineSx + 1, meta - 1, meta + 1, MargineDx - 1}

        pdf.SetColorFill(Color.Black)
        y -= 1
        Dim yA As Single = y

        For i As Integer = 0 To parametro.GetUpperBound(0) Step 2
            If (1 + i) Mod 4 = 1 Then
                y -= dy
                pdf.DrawText(tab(0), y, parametro(i), "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                pdf.DrawText(tab(1), y, parametro(1 + i), "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
            Else
                pdf.DrawText(tab(2), y, parametro(i), "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                pdf.DrawText(tab(3), y, parametro(1 + i), "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
            End If
        Next

        pdf.DrawRect(MargineDx, y - 1, MargineSx, yA - 1, UniQuota.Pdf.pdfPathOptions.Stroked)
        pdf.DrawRect(meta, y - 1, meta, yA - 1, UniQuota.Pdf.pdfPathOptions.Stroked)

    End Sub

    Public Overridable Sub Stampa(ByVal preventivo As Prodotto, ByVal options As StampaOptions)
        StampaInizio(preventivo, options)
        StampaIntestazionePagina(preventivo, options)
        StampaSezioneCliente(preventivo, options)
        StampaParametri(preventivo, options)
        StampaDettaglio(preventivo, options)
        StampaRiepilogoPremi(preventivo, options)
        StampaFine(preventivo, options)
    End Sub

    Public Overridable Sub StampaMostraEtInvia(ByVal preventivo As Prodotto, ByVal options As StampaOptions)
        Stampa(preventivo, options)

        If (options And StampaOptions.StampaFascicolo) = 0 Then
            MostraEtInvia(preventivo, options)
        End If
    End Sub

    Public Sub MostraEtInvia(ByVal preventivo As Prodotto, ByVal options As StampaOptions)
        If (options And StampaOptions.MostraAnteprima) = StampaOptions.MostraAnteprima Then
            Process.Start(FileName)
        End If
        If (options And StampaOptions.InviaEmail) = StampaOptions.InviaEmail Then
            'MsgBox("Invio email da implementare ...")
            Dim email As New Email()
            email.SvuotaCartellaEmail()
            System.IO.File.Move(FileName, System.IO.Path.Combine(email.CartellaEmail, "Preventivo.pdf"))
            If email.Invia(preventivo.Cliente.Email, "", "", "Preventivo " & preventivo.DescrizioneProdotto, "In allegato il preventivo.") = True Then
                preventivo.EmailTo = preventivo.Cliente.Email
                preventivo.EmailDate = Today
            End If
        End If
    End Sub

    Public Overridable Sub StampaCoperture(ByVal Coperture As CoperturaComposta, ByVal Descrizione As String, ByVal options As StampaOptions)
        StampaCoperture(Coperture, Descrizione, Nothing, options)
    End Sub

    Public Overridable Sub StampaCoperture(ByVal Coperture As CoperturaComposta, ByVal Descrizione As String, ByVal Parametro As String, ByVal options As StampaOptions)
        If Descrizione IsNot Nothing Then
            y -= dy
            pdf.SetLineWidth(0.5)
            pdf.SetColorFill(Color.Khaki)
            pdf.DrawRect(MargineSx, y - 1, MargineDx, y + dy - 1, UniQuota.Pdf.pdfPathOptions.Stroked + UniQuota.Pdf.pdfPathOptions.Filled)
            pdf.SetColorFill(Color.Black)
            pdf.DrawText(tab(0), y, Descrizione, "FaB", 8, pdf.pdfTextAlign.pdfAlignLeft)
            If Parametro IsNot Nothing Then
                pdf.SetColorFill(Color.DarkRed)
                pdf.DrawText(tab(1), y, Parametro & " ", "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
                pdf.SetColorFill(Color.Black)
            End If
            pdf.DrawText(tab(3), y, FormatEuro(Coperture.ListinoLordo), "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)

            y -= 0.25
        End If
        For Each Copertura As CoperturaSingola In Coperture.CopertureSingole
            If Copertura.NonStampare = False Then
                y -= dy
                pdf.SetLineWidth(0.0)
                pdf.SetColorFill(Color.LightCyan)
                pdf.DrawRect(VerticaleUno, y - 1, VerticaleDue, y + dy - 1, UniQuota.Pdf.pdfPathOptions.Filled + UniQuota.Pdf.pdfPathOptions.Stroked)
                pdf.SetColorFill(Color.LightYellow)
                pdf.DrawRect(VerticaleDue, y - 1, VerticaleTre, y + dy - 1, UniQuota.Pdf.pdfPathOptions.Filled + UniQuota.Pdf.pdfPathOptions.Stroked)
                pdf.SetColorFill(Color.White)
                pdf.DrawRect(VerticaleTre, y - 1, MargineDx, y + dy - 1, UniQuota.Pdf.pdfPathOptions.Filled + UniQuota.Pdf.pdfPathOptions.Stroked)

                pdf.SetLineWidth(0.5)
                pdf.DrawRect(MargineDx, y - 1, MargineDx, y + dy - 1, UniQuota.Pdf.pdfPathOptions.Stroked)
                pdf.DrawRect(MargineSx, y - 1, MargineSx, y + dy - 1, UniQuota.Pdf.pdfPathOptions.Stroked)
                pdf.SetColorFill(Color.Black)

                With Copertura
                    If .Parametro0 IsNot Nothing Then
                        pdf.DrawText(tab(0), y, .Garanzia.Descrizione & " (" & .Parametro0 & ")", "FaB", 8, pdf.pdfTextAlign.pdfAlignLeft)
                    Else
                        pdf.DrawText(tab(0), y, .Garanzia.Descrizione, "FaB", 8, pdf.pdfTextAlign.pdfAlignLeft)
                    End If
                    If .Parametro1 IsNot Nothing Then
                        pdf.DrawText(tab(1), y, .Parametro1 & " ", "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
                    End If
                    If .Parametro2 IsNot Nothing Then
                        pdf.DrawText(1 + tab(1), y, .Parametro2 & " ", "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                    End If
                    If .Parametro3 IsNot Nothing Then
                        pdf.DrawText(tab(2), y, .Parametro3, "FaN", 8, pdf.pdfTextAlign.pdfAlignRight)
                    ElseIf mNewFormato Then
                        pdf.DrawText(tab(2), y, Formatta(Copertura), "FaN", 8, pdf.pdfTextAlign.pdfAlignRight)
                    ElseIf .IsBase Then
                        pdf.DrawText(tab(2), y, Formatta(.Partita), "FaN", 8, pdf.pdfTextAlign.pdfAlignRight)
                    Else
                        pdf.DrawText(tab(2), y, Formatta(.Garanzia), "FaN", 8, pdf.pdfTextAlign.pdfAlignRight)
                    End If
                    If .RischioDirezione Then
                        pdf.DrawText(tab(3), y, "R.D.", "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
                    Else
                        pdf.DrawText(tab(3), y, FormatEuro(.ListinoLordo), "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
                    End If
                    pdf.DrawText(tab(4), y, FormatScelto(.Stato), "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfCenter)

                    If .Garanzia.Garanzie IsNot Nothing Then
                        For Each Garanzia In .Garanzia.Garanzie
                            y -= dy
                            pdf.SetColorFill(Color.LightYellow)
                            pdf.SetLineWidth(0)
                            pdf.DrawRect(VerticaleUno, y - 1, VerticaleDue, y + dy - 1, UniQuota.Pdf.pdfPathOptions.Filled + UniQuota.Pdf.pdfPathOptions.Stroked)
                            pdf.DrawRect(VerticaleDue, y - 1, VerticaleTre, y + dy - 1, UniQuota.Pdf.pdfPathOptions.Filled + UniQuota.Pdf.pdfPathOptions.Stroked)
                            pdf.SetLineWidth(0.5)
                            pdf.DrawRect(MargineDx, y - 1, MargineDx, y + dy - 1, UniQuota.Pdf.pdfPathOptions.Stroked)
                            pdf.DrawRect(MargineSx, y - 1, MargineSx, y + dy - 1, UniQuota.Pdf.pdfPathOptions.Stroked)

                            pdf.SetColorFill(Color.Black)
                            pdf.DrawText(tab(0), y, " - " & Garanzia.Descrizione, "FaB", 8, pdf.pdfTextAlign.pdfAlignLeft)
                            pdf.DrawText(tab(2), y, Formatta(Garanzia), "FaN", 8, pdf.pdfTextAlign.pdfAlignRight)
                        Next
                    End If
                End With
            End If
        Next
    End Sub

    Private Function decodeFrazionamento(Decode As P00000DE, Frazionamento As FrazionamentiEnum) As String
        Try
            Return Decode.DecodeFrazionamenti(Frazionamento).ToUpper()
        Catch ex As Exception

        End Try
        Return ""
    End Function
End Class
