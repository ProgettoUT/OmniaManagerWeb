Imports System.Drawing

Public Enum StampaOptions
    StampaProdotto = &H0
    MostraAnteprima = &H1
    InviaEmail = &H2
    StampaAgenzia = &H4
    StampaCliente = &H8
    StampaSituazione = &H10
    StampaNote = &H20
    StampaFasiVendita = &H40
    StampaAnalisiRca = &H80
    StampaA3 = &H800000
End Enum

Public Class Copertina

    Private Enum Colore
        Nero = &H0
        Griglio = &H808080
    End Enum

    Protected Const MargineTp As Single = 297 - 15
    Protected Const MargineBt As Single = 15
    Protected Const MargineSx As Single = 10
    Protected Const MargineDx As Single = 210 - 10
    Protected Const Centro As Single = 95

    Protected VerticaleUno As Single = 85
    Protected VerticaleDue As Single = 165
    Protected VerticaleTre As Single = 183
    Protected Const ds As Single = 3
    Protected Const dy As Single = 3

    Protected FileName As String
    Protected pdf As Pdf
    Protected tab As Single() = {MargineSx + 1, VerticaleUno - 1, VerticaleDue - 1, VerticaleTre - 1, (VerticaleTre + MargineDx) / 2, MargineDx}
    Protected y As Single = 0
    Protected pagina As Integer = 0


    Public Overridable Sub StampaMostraEtInvia(anagrafica As Anagrafica, options As StampaOptions)
        Stampa(anagrafica, options)
        Mostra(options)
        'If (options And StampaOptions.InviaEmail) = StampaOptions.InviaEmail Then
        '    'MsgBox("Invio email da implementare ...")
        '    Dim email As New Email()
        '    email.SvuotaCartellaEmail()
        '    System.IO.File.Move(FileName, System.IO.Path.Combine(email.CartellaEmail, "anagrafica.pdf"))
        '    email.Invia(anagrafica.Cliente.Email, "", "", "anagrafica " & anagrafica.DescrizioneProdotto, "In allegato il anagrafica.")
        'End If
    End Sub

    Public Overridable Sub Mostra(options As StampaOptions)
        If (options And StampaOptions.MostraAnteprima) = StampaOptions.MostraAnteprima Then
            Process.Start(FileName)
        End If
    End Sub

    Public Overridable Sub Stampa(anagrafica As Anagrafica, options As StampaOptions)
        StampaInizio(anagrafica, options)

        StampaIntestazionePagina(anagrafica, options)
        StampaCliente(anagrafica, options)
        StampaSituazione(anagrafica, options)
        StampaNote(anagrafica, options)
        StampaFasiVendita(anagrafica, options)

        StampaIntestazionePagina(anagrafica, options)
        StampaAnalisiRca(anagrafica, options)

        StampaFine(anagrafica, options)
    End Sub

    Public Sub StampaInizio(anagrafica As Anagrafica, options As StampaOptions)

        FileName = System.IO.Path.GetTempPath & anagrafica.CodiceFiscale & ".pdf"
        ' Delete the file if it exists.
        If System.IO.File.Exists(FileName) Then
            Try
                System.IO.File.Delete(FileName)

            Catch ex As Exception
                FileName = Replace(System.IO.Path.GetTempFileName(), ".tmp", ".pdf")
            End Try
            System.IO.File.Delete(FileName)

        End If

        If (options And StampaOptions.StampaA3) = StampaOptions.StampaA3 Then
            pdf = New Pdf(pdf.pdfPaperSize.pdfA3)
        Else
            pdf = New Pdf(pdf.pdfPaperSize.pdfA4)
        End If
        pdf.Title = anagrafica.CodiceFiscale

        pdf.InitPDFFile(FileName)
        pdf.LoadFont("Fnt1", "TIMESNEWROMAN")
        pdf.LoadFont("FntI", "TIMESNEWROMAN", pdf.pdfFontStyle.pdfItalic)
        pdf.LoadFont("FntB", "TIMESNEWROMAN", pdf.pdfFontStyle.pdfBold)
        pdf.LoadFont("FntBI", "TIMESNEWROMAN", pdf.pdfFontStyle.pdfBoldItalic)

        pdf.LoadFont("FaN", "Arial")
        pdf.LoadFont("FaI", "Arial", pdf.pdfFontStyle.pdfItalic)
        pdf.LoadFont("FaB", "Arial", pdf.pdfFontStyle.pdfBold)

        'pdf.LoadImgFromBMPRecources("logoDitta", "LogoUnipol")
        pdf.LoadImgFromBMPRecources("Automobile", "Automobile")
        pdf.LoadImgFromBMPRecources("Moto", "Moto")
        pdf.LoadImgFromBMPRecources("Casa", "Casa")
        pdf.LoadImgFromBMPRecources("Infortuni", "Infortuni")
        pdf.LoadImgFromBMPRecources("Professione", "Professione")
        pdf.LoadImgFromBMPRecources("Risparmio", "Risparmio")
        pdf.LoadImgFromBMPRecources("Investimento", "Investimento")

        pdf.ScaleMode = pdf.pdfScaleMode.pdfMillimeter
    End Sub

    Public Sub StampaIntestazionePagina(anagrafica As Anagrafica, options As StampaOptions)
        If pagina > 0 Then
            pdf.EndPage()
        End If
        pdf.BeginPage()
        pagina += 1

        y = MargineTp

        'pdf.DrawImg("logoDitta", MargineSx, MargineTp, 40, 14)
        'pdf.DrawImg("logoProdotto", MargineDx - 40, MargineTp, 40, 10)

        'pdf.SetColorStroke(0)

        'pdf.SetColorFill(Color.Black)
        'If (options And StampaOptions.StampaAgenzia) = StampaOptions.StampaAgenzia Then
        '    With Anagrafica.Agenzia
        '        y = MargineTp
        '        If .Denominazione <> "" Then y -= ds : pdf.DrawText(105, y, .Denominazione, "FntBI", 12, pdf.pdfTextAlign.pdfCenter)
        '        'y -= ds : pdf.DrawText(105, y, "Agenzia Generale", "FntB", 8, Pdf.pdfTextAlign.pdfCenter)
        '        If .Indirizzo <> "" Then y -= ds : pdf.DrawText(105, y, .Indirizzo, "FntI", 8, pdf.pdfTextAlign.pdfCenter)
        '        If .Telefono <> "" Then y -= ds : pdf.DrawText(105, y, "Tel " & .Telefono, "FntI", 8, pdf.pdfTextAlign.pdfCenter)
        '        If .Fax <> "" Then y -= ds : pdf.DrawText(105, y, "Fax " & .Fax, "FntI", 8, pdf.pdfTextAlign.pdfCenter)
        '        If .Email <> "" Then y -= ds : pdf.DrawText(105, y, "e-mail: " & .Email, "FntI", 8, pdf.pdfTextAlign.pdfCenter)
        '        With Anagrafica.Intermediario
        '            If .Nominativo <> "" Then y -= ds : pdf.DrawText(105, y, .Nominativo, "FntI", 8, pdf.pdfTextAlign.pdfCenter)
        '        End With
        '        'If .Localita <> "" Then y = 60 * dy + 1 : pdf.DrawText(MargineSx, y, "anagrafica emesso dall'Agenzia di " & .Localita, "Fnt1", 8, Pdf.pdfTextAlign.pdfAlignLeft)
        '    End With
        'End If

        'y = 62 * dy
        'pdf.DrawText(MargineSx, y, Anagrafica.CodiceProdotto & " - " & Anagrafica.DescrizioneProdotto, "FntB", 8, pdf.pdfTextAlign.pdfAlignLeft)
        'pdf.DrawText(MargineDx, y, "Emesso il " & FormatDateTime(Date.Now, DateFormat.ShortDate), "Fnt1", 8, pdf.pdfTextAlign.pdfAlignRight)
        'y -= dy
        'pdf.DrawText(MargineSx, y, "Validità del anagrafica 60gg", "Fnt1", 8, pdf.pdfTextAlign.pdfAlignLeft)
        'pdf.DrawText(MargineDx, y, "Tariffe in vigore dal " & Anagrafica.DataEntrataVigore, "Fnt1", 8, pdf.pdfTextAlign.pdfAlignRight)
    End Sub

    Public Overridable Sub StampaCliente(anagrafica As Anagrafica, options As StampaOptions)
        If (options And StampaOptions.StampaCliente) = StampaOptions.StampaCliente Then
            Const FontSize = 10

            Dim MargineSx As Single = Copertina.MargineSx
            Dim MargineDx As Single = Copertina.MargineDx
            If (options And StampaOptions.StampaA3) = StampaOptions.StampaA3 Then
                MargineSx += 210
                MargineDx += 210
            End If

            Dim line1 As Single = MargineSx + 25
            Dim line2 As Single = MargineDx - 70
            Dim line3 As Single = MargineDx - 50

            pdf.SetColorStroke(Colore.Nero)
            pdf.SetLineWidth(0.1)

            pdf.DrawRect(MargineSx, y - 12 * dy, MargineDx, y - 10 * dy, pdf.pdfPathOptions.Stroked)
            pdf.DrawRect(MargineSx, y - 8 * dy, MargineDx, y - 6 * dy, pdf.pdfPathOptions.Stroked)
            pdf.DrawRect(MargineSx, y - 4 * dy, MargineDx, y - 2 * dy, pdf.pdfPathOptions.Stroked)
            pdf.DrawRect(MargineSx, y - 0 * dy, MargineDx, y - 2 * dy, pdf.pdfPathOptions.Stroked)

            pdf.DrawRect(MargineSx, y - 12 * dy, line1, y - 0 * dy, pdf.pdfPathOptions.Stroked)
            pdf.DrawRect(line2, y - 12 * dy, line3, y - 0 * dy, pdf.pdfPathOptions.Stroked)

            pdf.DrawRect(MargineSx, y - 12 * dy, MargineDx, y, pdf.pdfPathOptions.Stroked)

            y += 2

            With anagrafica
                y -= 2 * dy
                pdf.DrawText(1 + MargineSx, y, "Cliente", "Fnt1", FontSize, pdf.pdfTextAlign.pdfAlignLeft)
                pdf.DrawText(1 + line1, y, .Cliente.Nominativo, "FntB", FontSize, pdf.pdfTextAlign.pdfAlignLeft)

                If .Cliente.ProduttoreDescrizione <> "" Then
                    pdf.DrawText(1 + line2, y, "Subagente", "Fnt1", FontSize, pdf.pdfTextAlign.pdfAlignLeft)
                    pdf.DrawText(1 + line3, y, .Cliente.ProduttoreDescrizione, "FntB", FontSize, pdf.pdfTextAlign.pdfAlignLeft)
                End If

                y -= 2 * dy
                pdf.DrawText(1 + MargineSx, y, "Coniug./Conv.", "Fnt1", FontSize, pdf.pdfTextAlign.pdfAlignLeft)
                For Each familiare As TNucleoFamiliare In .Nucleofamiliari
                    If familiare.CodRelazione = "A" Then ' A = Coniuge
                        pdf.DrawText(1 + line1, y, familiare.Nome, "FntB", FontSize, pdf.pdfTextAlign.pdfAlignLeft)
                    End If
                Next

                pdf.DrawText(1 + line2, y, "Convenzione", "Fnt1", FontSize, pdf.pdfTextAlign.pdfAlignLeft)
                pdf.DrawText(1 + line3, y, .Soggetto.ConvenzioneDescrizione, "FntB", FontSize, pdf.pdfTextAlign.pdfAlignLeft)

                y -= 2 * dy
                pdf.DrawText(1 + MargineSx, y, "Figli", "Fnt1", FontSize, pdf.pdfTextAlign.pdfAlignLeft)
                Dim figli As String = ""
                For Each familiare As TNucleoFamiliare In .Nucleofamiliari
                    If familiare.CodRelazione = "C" Then ' C = Figli
                        figli &= ", " & familiare.Nome
                    End If
                Next
                If figli <> "" Then
                    pdf.DrawText(1 + line1, y, figli.Substring(2), "FntB", FontSize, pdf.pdfTextAlign.pdfAlignLeft)
                End If

                pdf.DrawText(1 + line2, y, "Cellulare", "Fnt1", FontSize, pdf.pdfTextAlign.pdfAlignLeft)
                pdf.DrawText(1 + line3, y, .Cliente.Cellulare, "FntB", FontSize, pdf.pdfTextAlign.pdfAlignLeft)

                y -= 2 * dy
                pdf.DrawText(1 + MargineSx, y, "Collegamenti", "Fnt1", FontSize, pdf.pdfTextAlign.pdfAlignLeft)
                Dim altri As String = ""
                For Each familiare As TNucleoFamiliare In .Nucleofamiliari
                    If familiare.CodRelazione <> "A" And familiare.CodRelazione <> "C" And familiare.Nome <> "" Then
                        altri &= ", " & familiare.Nome
                    End If
                Next
                If altri <> "" Then
                    pdf.DrawText(1 + line1, y, altri.Substring(2), "FntB", FontSize, pdf.pdfTextAlign.pdfAlignLeft)
                End If


                pdf.DrawText(1 + line2, y, "Telefono", "Fnt1", FontSize, pdf.pdfTextAlign.pdfAlignLeft)
                pdf.DrawText(1 + line3, y, .Cliente.Telefono1, "FntB", FontSize, pdf.pdfTextAlign.pdfAlignLeft)

                y -= 2 * dy
                pdf.DrawText(1 + MargineSx, y, "Email", "Fnt1", FontSize, pdf.pdfTextAlign.pdfAlignLeft)
                pdf.DrawText(1 + line1, y, .Cliente.Email, "FntB", FontSize, pdf.pdfTextAlign.pdfAlignLeft)

                pdf.DrawText(1 + line2, y, "Età'", "Fnt1", FontSize, pdf.pdfTextAlign.pdfAlignLeft)
                If .Cliente.Eta > 0 Then
                    pdf.DrawText(1 + line3, y, .Cliente.Eta, "FntB", FontSize, pdf.pdfTextAlign.pdfAlignLeft)
                End If

                y -= 2 * dy
                pdf.DrawText(1 + MargineSx, y, "Attività", "Fnt1", FontSize, pdf.pdfTextAlign.pdfAlignLeft)
                Dim attivita As String = ""
                For Each lavoro As TAttivita In .Attivitas
                    If lavoro.Descrizione <> "" Then
                        attivita &= ", " & lavoro.Descrizione
                    End If
                Next
                If attivita <> "" Then
                    pdf.DrawText(1 + line1, y, attivita.Substring(2), "FntB", FontSize, pdf.pdfTextAlign.pdfAlignLeft)
                End If

                pdf.DrawText(1 + line2, y, "Polizze", "Fnt1", FontSize, pdf.pdfTextAlign.pdfAlignLeft)
                If .Cliente.PolizzeVigore > 0 Then
                    pdf.DrawText(1 + line3, y, .Cliente.PolizzeVigore, "FntB", FontSize, pdf.pdfTextAlign.pdfAlignLeft)
                End If

                y -= 2

            End With
        End If
    End Sub

    Public Overridable Sub StampaSituazione(anagrafica As Anagrafica, options As StampaOptions)

        If (options And StampaOptions.StampaSituazione) = StampaOptions.StampaSituazione Then
            Dim MargineSx As Single = Copertina.MargineSx
            Dim MargineDx As Single = Copertina.MargineDx
            If (options And StampaOptions.StampaA3) = StampaOptions.StampaA3 Then
                MargineSx += 210
                MargineDx += 210
            End If

            Dim tab As Single() = {MargineSx + 1, MargineSx + 21, MargineSx + 41, MargineSx + 61, MargineSx + 81, MargineSx + 101, MargineSx + 121, MargineSx + 141}

            pdf.SetLineWidth(0.1)

            pdf.SetColorStroke(Colore.Griglio)

            For yy As Single = 0 To 6
                pdf.DrawRect(MargineSx + 20, y - 15 - yy * 8 * dy, MargineDx, y - 15 - yy * 8 * dy, pdf.pdfPathOptions.Stroked)
                pdf.DrawRect(MargineSx + 20, y - 21 - yy * 8 * dy, MargineDx, y - 21 - yy * 8 * dy, pdf.pdfPathOptions.Stroked)
                pdf.DrawRect(MargineSx + 20, y - 27 - yy * 8 * dy, MargineDx, y - 27 - yy * 8 * dy, pdf.pdfPathOptions.Stroked)
            Next

            pdf.SetColorStroke(0)

            y -= 1 * dy
            pdf.DrawText(tab(0), y - 4, "SITUAZIONE", "Fnt1", 8, pdf.pdfTextAlign.pdfAlignLeft)
            pdf.DrawText(tab(1), y - 4, "POLIZZA", "Fnt1", 8, pdf.pdfTextAlign.pdfAlignLeft)
            pdf.DrawText(tab(2), y - 4, "COMPAGNIA", "Fnt1", 8, pdf.pdfTextAlign.pdfAlignLeft)
            pdf.DrawText(tab(3), y - 4, "DOC", "Fnt1", 8, pdf.pdfTextAlign.pdfAlignLeft)
            pdf.DrawText(tab(4), y - 4, "SCADENZA", "Fnt1", 8, pdf.pdfTextAlign.pdfAlignLeft)
            pdf.DrawText(tab(5), y - 4, "DISDETTA", "Fnt1", 8, pdf.pdfTextAlign.pdfAlignLeft)
            pdf.DrawText(tab(6), y - 4, "PREVENTIVO", "Fnt1", 8, pdf.pdfTextAlign.pdfAlignLeft)
            pdf.DrawText(tab(7), y - 4, "VEICOLO/NOTE", "Fnt1", 8, pdf.pdfTextAlign.pdfAlignLeft)

            y -= 2 * dy
            pdf.DrawRect(MargineSx, y, MargineDx, y + 2 * dy, pdf.pdfPathOptions.Stroked)

            y -= 8 * dy
            pdf.DrawImg("Automobile", MargineSx + 2, y + 20, 15, 15)
            pdf.DrawRect(MargineSx, y, MargineDx, y + 8 * dy, pdf.pdfPathOptions.Stroked)

            y -= 8 * dy
            pdf.DrawImg("Moto", MargineSx + 2, y + 20, 15, 15)
            pdf.DrawRect(MargineSx, y, MargineDx, y + 8 * dy, pdf.pdfPathOptions.Stroked)

            y -= 8 * dy
            pdf.DrawImg("Casa", MargineSx + 2, y + 20, 15, 15)
            pdf.DrawRect(MargineSx, y, MargineDx, y + 8 * dy, pdf.pdfPathOptions.Stroked)

            y -= 8 * dy
            pdf.DrawImg("Infortuni", MargineSx + 2, y + 20, 15, 15)
            pdf.DrawRect(MargineSx, y, MargineDx, y + 8 * dy, pdf.pdfPathOptions.Stroked)

            y -= 8 * dy
            pdf.DrawImg("Professione", MargineSx + 2, y + 20, 15, 15)
            pdf.DrawRect(MargineSx, y, MargineDx, y + 8 * dy, pdf.pdfPathOptions.Stroked)

            y -= 8 * dy
            pdf.DrawImg("Risparmio", MargineSx + 2, y + 20, 15, 15)
            pdf.DrawRect(MargineSx, y, MargineDx, y + 8 * dy, pdf.pdfPathOptions.Stroked)

            y -= 8 * dy
            pdf.DrawImg("Investimento", MargineSx + 2, y + 20, 15, 15)
            pdf.DrawRect(MargineSx, y, MargineDx, y + 8 * dy, pdf.pdfPathOptions.Stroked)

            pdf.DrawRect(MargineSx + 20, y, MargineSx + 40, y + 58 * dy, pdf.pdfPathOptions.Stroked)
            pdf.DrawRect(MargineSx + 60, y, MargineSx + 80, y + 58 * dy, pdf.pdfPathOptions.Stroked)
            pdf.DrawRect(MargineSx + 100, y, MargineSx + 120, y + 58 * dy, pdf.pdfPathOptions.Stroked)
            pdf.DrawRect(MargineSx + 140, y, MargineSx + 140, y + 58 * dy, pdf.pdfPathOptions.Stroked)


            Dim s As Integer = 48 * dy
            For Each sezione As String In {"A", "B", "C", "D", "E", "F", "G"}
                Dim p As Integer = 19
                For Each polizza As TPolizza In anagrafica.PolizzeSituazione
                    If polizza.Sezione = sezione Then
                        With polizza
                            pdf.DrawText(tab(1), y + s + p, .Polizza, "Fnt1", 8, pdf.pdfTextAlign.pdfAlignLeft)
                            pdf.DrawText(tab(2), y + s + p, .Compagnia, "Fnt1", 8, pdf.pdfTextAlign.pdfAlignLeft)
                            pdf.DrawText(tab(3), y + s + p, .Doc, "Fnt1", 8, pdf.pdfTextAlign.pdfAlignLeft)
                            pdf.DrawText(tab(4), y + s + p, Format(.DataScadenza), "Fnt1", 8, pdf.pdfTextAlign.pdfAlignLeft)
                            pdf.DrawText(tab(5), y + s + p, Format(.DataDisdetta), "Fnt1", 8, pdf.pdfTextAlign.pdfAlignLeft)
                            pdf.DrawText(tab(6), y + s + p, Format(.DataPreventivo), "Fnt1", 8, pdf.pdfTextAlign.pdfAlignLeft)
                            pdf.DrawText(tab(7), y + s + p, .Marca, "Fnt1", 8, pdf.pdfTextAlign.pdfAlignLeft)
                        End With
                        p -= 6
                    End If
                Next
                s -= 8 * dy
            Next

        End If
    End Sub

    Public Overridable Sub StampaNote(anagrafica As Anagrafica, options As StampaOptions)
        If (options And StampaOptions.StampaNote) = StampaOptions.StampaNote Then
            Dim MargineSx As Single = Copertina.MargineSx
            Dim MargineDx As Single = Copertina.MargineDx
            If (options And StampaOptions.StampaA3) = StampaOptions.StampaA3 Then
                MargineSx += 210
                MargineDx += 210
            End If
            Dim dy As Single = 4.0

            pdf.SetColorStroke(Colore.Nero)

            y -= 2 * dy
            pdf.DrawText(MargineSx, y, "NOTE:", "Fnt1", 8, pdf.pdfTextAlign.pdfAlignLeft)

            pdf.SetLineWidth(0.1)
            pdf.SetColorStroke(Colore.Griglio)

            Dim notes As String() = "".Split(vbNewLine)

            If anagrafica.Soggetto.Note IsNot Nothing Then
                notes = anagrafica.Soggetto.Note.Split(vbNewLine)
            End If

            For i As Integer = 0 To 6
                y -= dy
                pdf.DrawRect(MargineSx, y, MargineDx, y, pdf.pdfPathOptions.Stroked)

                If i < notes.GetLength(0) Then
                    pdf.DrawText(MargineSx, y + 0.5, notes(i).Trim, "Fnt1", 8, pdf.pdfTextAlign.pdfAlignLeft)
                End If
            Next
        End If
    End Sub

    Public Overridable Sub StampaFasiVendita(anagrafica As Anagrafica, options As StampaOptions)
        If (options And StampaOptions.StampaFasiVendita) = StampaOptions.StampaFasiVendita Then
            Dim MargineSx As Single = Copertina.MargineSx
            Dim MargineDx As Single = Copertina.MargineDx
            If (options And StampaOptions.StampaA3) = StampaOptions.StampaA3 Then
                MargineSx += 210
                MargineDx += 210
            End If

            Dim tab As Single() = {MargineSx + 38, MargineSx + 76, MargineSx + 114, MargineSx + 152}
            Dim dy As Single = 4.0

            pdf.SetColorStroke(0)
            pdf.SetLineWidth(0.1)

            pdf.DrawRect(MargineSx, MargineBt, MargineDx, MargineBt + dy, pdf.pdfPathOptions.Stroked)
            pdf.DrawRect(MargineSx, MargineBt + dy, MargineDx, MargineBt + 2 * dy, pdf.pdfPathOptions.Stroked)
            pdf.DrawRect(MargineSx, MargineBt + 2 * dy, MargineDx, MargineBt + 3 * dy, pdf.pdfPathOptions.Stroked)

            pdf.DrawRect(tab(0), MargineBt, tab(1), MargineBt + 3 * dy, pdf.pdfPathOptions.Stroked)
            pdf.DrawRect(tab(2), MargineBt, tab(3), MargineBt + 3 * dy, pdf.pdfPathOptions.Stroked)

            Dim med As Single = MargineSx
            For Each fase As TFasiVendita In anagrafica.FasiVendita
                pdf.DrawText(med + 19, MargineBt + 2 * dy + 1, fase.Idioma.ToUpper, "FntB", 8, pdf.pdfTextAlign.pdfCenter)
                pdf.DrawText(med + 19, MargineBt + 1 * dy + 1, Format(fase.Data), "Fnt1", 8, pdf.pdfTextAlign.pdfCenter)
                pdf.DrawText(med + 19, MargineBt + 0 * dy + 1, fase.Utente, "Fnt1", 8, pdf.pdfTextAlign.pdfCenter)
                med += 38
            Next
        End If
    End Sub

    Public Overridable Sub StampaAnalisiRca(anagrafica As Anagrafica, options As StampaOptions)
        If (options And StampaOptions.StampaAnalisiRca) = StampaOptions.StampaAnalisiRca Then
            Const width As Single = 27.0
            Dim dy As Single = 10.0
            Dim dt1 As Single = 8.0
            Dim dt2 As Single = 3.0
            Dim TestoSx As Single = MargineSx + 0.5

            Dim tab As Single() = {MargineSx + 0, MargineSx + 1 * width, MargineSx + 2 * width, MargineSx + 3 * width, MargineSx + 4 * width, MargineSx + 5 * width, MargineSx + 6 * width, MargineSx + 7 * width}
            Dim lef As Single() = {TestoSx, TestoSx + 1 * width, TestoSx + 2 * width, TestoSx + 3 * width, TestoSx + 4 * width, TestoSx + 5 * width, TestoSx + 6 * width}
            Dim med As Single() = {MargineSx + 0.5 * width, MargineSx + 1.5 * width, MargineSx + 2.5 * width, MargineSx + 3.5 * width, MargineSx + 4.5 * width, MargineSx + 5.5 * width, MargineSx + 6.5 * width}
            pdf.SetLineWidth(0.1)


            pdf.DrawText(MargineSx, y, "ANALISI RCA IN SCADENZA", "FntB", 12, pdf.pdfTextAlign.pdfAlignLeft)

            For Each analisi As TAnalisiRca In anagrafica.AnalisiRca
                With analisi
                    y -= 1.5 * dy
                    pdf.DrawRect(tab(0), y, tab(1), y + 1 * dy, pdf.pdfPathOptions.Stroked)
                    pdf.DrawText(lef(0), y + dt1, "Polizza", "Fnt1", 6, pdf.pdfTextAlign.pdfAlignLeft)
                    pdf.DrawText(med(0), y + dt2, .Polizza, "FntB", 10, pdf.pdfTextAlign.pdfCenter)

                    pdf.DrawRect(tab(1), y, tab(2), y + 1 * dy, pdf.pdfPathOptions.Stroked)
                    pdf.DrawText(lef(1), y + dt1, "Scadenza", "Fnt1", 6, pdf.pdfTextAlign.pdfAlignLeft)
                    pdf.DrawText(med(1), y + dt2, Format(.DataScadenza), "FntB", 10, pdf.pdfTextAlign.pdfCenter)

                    pdf.DrawRect(tab(2), y, tab(3), y + 1 * dy, pdf.pdfPathOptions.Stroked)
                    pdf.DrawText(lef(2), y + dt1, "Premio old", "Fnt1", 6, pdf.pdfTextAlign.pdfAlignLeft)
                    pdf.DrawText(med(2), y + dt2, Format(.PremioOld), "Fnt1", 10, pdf.pdfTextAlign.pdfCenter)

                    pdf.DrawRect(tab(3), y, tab(4), y + 1 * dy, pdf.pdfPathOptions.Stroked)
                    pdf.DrawText(lef(3), y + dt1, "Premio new", "Fnt1", 6, pdf.pdfTextAlign.pdfAlignLeft)
                    pdf.DrawText(med(3), y + dt2, Format(.PremioNew), "Fnt1", 10, pdf.pdfTextAlign.pdfCenter)

                    pdf.DrawRect(tab(4), y, tab(5), y + 1 * dy, pdf.pdfPathOptions.Stroked)
                    pdf.DrawText(lef(4), y + dt1, "Differenza", "Fnt1", 6, pdf.pdfTextAlign.pdfAlignLeft)
                    pdf.DrawText(med(4), y + dt2, Format(.PremioDif), "Fnt1", 10, pdf.pdfTextAlign.pdfCenter)

                    pdf.DrawRect(tab(5), y, tab(6), y + 1 * dy, pdf.pdfPathOptions.Stroked)
                    pdf.DrawText(lef(5), y + dt1, "Convenzione", "Fnt1", 6, pdf.pdfTextAlign.pdfAlignLeft)
                    pdf.DrawText(med(5), y + dt2, .Convenzione, "Fnt1", 10, pdf.pdfTextAlign.pdfCenter)

                    pdf.DrawRect(tab(6), y, tab(7), y + 1 * dy, pdf.pdfPathOptions.Stroked)
                    pdf.DrawText(lef(6), y + dt1, "Guida esperta", "Fnt1", 6, pdf.pdfTextAlign.pdfAlignLeft)
                    pdf.DrawText(med(6), y + dt2, .GuidaEsperta, "Fnt1", 10, pdf.pdfTextAlign.pdfCenter)

                    y -= dy
                    pdf.DrawRect(tab(0), y, tab(1), y + 1 * dy, pdf.pdfPathOptions.Stroked)
                    pdf.DrawText(lef(0), y + dt1, "Finanziamento", "Fnt1", 6, pdf.pdfTextAlign.pdfAlignLeft)
                    pdf.DrawText(med(0), y + dt2, .Finanziamento, "Fnt1", 10, pdf.pdfTextAlign.pdfCenter)

                    pdf.DrawRect(tab(1), y, tab(2), y + 1 * dy, pdf.pdfPathOptions.Stroked)
                    pdf.DrawText(lef(1), y + dt1, "Unibox", "Fnt1", 6, pdf.pdfTextAlign.pdfAlignLeft)
                    If .Unibox IsNot Nothing Then
                        Try
                            pdf.DrawText(med(1), y + dt2, anagrafica.PianoCodici.Find(Function(x) x.Codice = .Unibox And x.Tipologia = "C").Idioma, "Fnt1", 10, pdf.pdfTextAlign.pdfCenter)
                        Catch
                        End Try
                    End If
                    pdf.DrawRect(tab(2), y, tab(3), y + 1 * dy, pdf.pdfPathOptions.Stroked)
                    pdf.DrawText(lef(2), y + dt1, "Riparazione", "Fnt1", 6, pdf.pdfTextAlign.pdfAlignLeft)
                    pdf.DrawText(med(2), y + dt2, .Riparazione, "Fnt1", 10, pdf.pdfTextAlign.pdfCenter)

                    pdf.DrawRect(tab(3), y, tab(4), y + 1 * dy, pdf.pdfPathOptions.Stroked)
                    pdf.DrawText(lef(3), y + dt1, "FlexIncendioFurto", "Fnt1", 6, pdf.pdfTextAlign.pdfAlignLeft)
                    pdf.DrawText(med(3), y + dt2, Format(.FlexIncendioFurto), "Fnt1", 10, pdf.pdfTextAlign.pdfCenter)

                    pdf.DrawRect(tab(4), y, tab(5), y + 1 * dy, pdf.pdfPathOptions.Stroked)
                    pdf.DrawText(lef(4), y + dt1, "Sinistro (Si/No)", "Fnt1", 6, pdf.pdfTextAlign.pdfAlignLeft)
                    pdf.DrawText(med(4), y + dt2, .SinistroSoN, "Fnt1", 10, pdf.pdfTextAlign.pdfCenter)

                    pdf.DrawRect(tab(5), y, tab(6), y + 1 * dy, pdf.pdfPathOptions.Stroked)
                    pdf.DrawText(lef(5), y + dt1, "Ultimo sinistro", "Fnt1", 6, pdf.pdfTextAlign.pdfAlignLeft)
                    pdf.DrawText(med(5), y + dt2, Format(.SinistroData), "Fnt1", 10, pdf.pdfTextAlign.pdfCenter)

                    pdf.DrawRect(tab(6), y, tab(7), y + 1 * dy, pdf.pdfPathOptions.Stroked)
                    pdf.DrawText(lef(6), y + dt1, "Malus", "Fnt1", 6, pdf.pdfTextAlign.pdfAlignLeft)
                    pdf.DrawText(med(6), y + dt2, .SinistroMalus, "Fnt1", 10, pdf.pdfTextAlign.pdfCenter)

                    y -= 1 * dy
                End With
            Next
        End If
    End Sub

    Public Sub StampaFine(anagrafica As Anagrafica, options As StampaOptions)
        pdf.EndPage()
        pdf.ClosePDFFile()
    End Sub

    Public Shared Function rg(r As Single, g As Single, b As Single) As Integer
        Return RGB(r * 255, g * 255, b * 255)
    End Function

    Shared Function Format(value As Decimal) As String
        If value = 0D Then Return ""
        Return FormatNumber(value, 2)
    End Function

    Shared Function Format(value As Date) As String
        If value = Date.MinValue Then Return ""
        Return value.ToString("dd/MM/yyyy")
    End Function

    Shared Function Formatta(valore As Boolean) As String
        If valore Then
            Return "Si"
        Else
            Return "No"
        End If
    End Function
End Class
