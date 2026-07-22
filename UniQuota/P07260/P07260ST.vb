Namespace P07260
    Public Class P07260ST
        Inherits P00000ST

        Public Sub New()
            MyBase.New(True)
        End Sub

        Public Overrides Sub StampaParametri(ByVal preventivo As Prodotto, ByVal options As StampaOptions)
            Dim meta As Single = MargineSx + (MargineDx - MargineSx) / 2.0
            Dim tab As Single() = {MargineSx + 1, meta - 1, meta + 1, MargineDx - 1}
            Dim decode As P07260DE = CType(preventivo.Decode, P07260DE)

            With CType(preventivo, YouCondominio)
                .CoperturaDanniAcquaPerditeOcculte.Parametro3 = decode.DecodeDanniAcquaFormaVendita(.DanniAcquaFormaVendita)

                pdf.SetColorFill(Color.Black)
                y -= 1
                Dim yA As Single = y

                y -= dy
                pdf.DrawText(tab(0), y, "Numero Fabbricati", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                pdf.DrawText(tab(1), y, .NumeroFabbricati, "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
                pdf.DrawText(tab(2), y, "Unità Immobiliari", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                pdf.DrawText(tab(3), y, .NumeroUnitaImmobiliari, "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
                y -= dy
                pdf.DrawText(tab(0), y, "Abitazioni", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                pdf.DrawText(tab(1), y, .NumeroUnitaAbitative, "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
                pdf.DrawText(tab(2), y, "Tipologia Fabbricato", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                pdf.DrawText(tab(3), y, decode.DecodeTipologiaFabbricato(.TipologiaFabbricato), "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
                y -= dy
                pdf.DrawText(tab(0), y, "Anno Costruzione", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                pdf.DrawText(tab(1), y, .AnnoCostruzione, "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
                pdf.DrawText(tab(2), y, "Provincia", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                pdf.DrawText(tab(3), y, Luogo.Province(.Provincia).Nome, "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
                y -= dy
                pdf.DrawText(tab(0), y, "Esercizi comerciali < 36%", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                pdf.DrawText(tab(1), y, Formatta(.CiSonoEserciziComerciali), "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
                pdf.DrawText(tab(2), y, "Adeguamento facoltativo", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                pdf.DrawText(tab(3), y, Formatta(.AdeguamentoFacoltativo), "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)

                y -= dy
                pdf.DrawText(tab(0), y, "Rifacimento Idrotermosanitari", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                pdf.DrawText(tab(1), y, Formatta(.RifacimentoIdrotermosanitari), "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)
                pdf.DrawText(tab(2), y, "Caratteristica costruttiva", "FaB", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignLeft)
                pdf.DrawText(tab(3), y, decode.DecodeCaratteristicaCostruttiva(.CaratteristicaCostruttiva), "FaN", 8, UniQuota.Pdf.pdfTextAlign.pdfAlignRight)

                pdf.DrawRect(MargineDx, y - 1, MargineSx, yA - 1, UniQuota.Pdf.pdfPathOptions.Stroked)
                pdf.DrawRect(meta, y - 1, meta, yA - 1, UniQuota.Pdf.pdfPathOptions.Stroked)
            End With
        End Sub

    End Class
End Namespace

