Imports System.Drawing.Printing

Public Class Busta

    Private Const NO_DATA As Date = #1/1/2000#

    Private ReadOnly PrintDialog1 As New PrintDialog
    Public WithEvents PrintBuste As New PrintDocument
    Private DocBusta As DataTableReader
    Private mNumeroPagina As Integer
    Private mProgressivoStampa As Integer
    Private Shared DateDecadi As New Dictionary(Of String, Date)

    Public Enum Tipo
        RCASING
        RCACUM
        RAMIELE
        CAUZIONI
        GRANDINE
        VITA
        RIASS
    End Enum

    Sub New()
    End Sub

    Sub New(TipoBusta As String,
            DataBusta As Date,
            NumeroStampati As Integer)

        mTipoBusta = TipoBusta
        mDataBusta = DataBusta
        mNumeroStampati = NumeroStampati
    End Sub

    Private mDataBusta As Date
    Public Property DataBusta() As Date
        Get
            Return mDataBusta
        End Get
        Set(value As Date)
            mDataBusta = value
        End Set
    End Property

    Private mTipoBusta As String
    Public Property TipoBusta() As String
        Get
            Return mTipoBusta
        End Get
        Set(value As String)
            mTipoBusta = value
        End Set
    End Property

    Private mNumeroStampati As Integer
    Public Property NumeroStampati() As String
        Get
            Return mNumeroStampati
        End Get
        Set(value As String)
            mNumeroStampati = value
        End Set
    End Property

    Public ReadOnly Property DecadeCompleta() As Boolean
        Get
            Return (mDataBusta < Today)
        End Get
    End Property

    Public ReadOnly Property Descrizione() As String
        Get
            If mDataBusta >= Today Then
                Return String.Format("Busta {0} - Decade {1:d} - Stampati {2} - Non completa", mTipoBusta, mDataBusta, mNumeroStampati)
            Else
                Return String.Format("Busta {0} - Decade {1:d} - Stampati {2}", mTipoBusta, mDataBusta, mNumeroStampati)
            End If
        End Get
    End Property

    Public ReadOnly Property DescrizioneTipoBusta() As String
        Get
            Select Case mTipoBusta.ToUpper
                Case Tipo.RCASING.ToString
                    Return "Rca singole"
                Case Tipo.RCACUM.ToString
                    Return "Rca cumulative"
                Case Tipo.RAMIELE.ToString
                    Return "Rami elementari"
                Case Tipo.CAUZIONI.ToString
                    Return "Cauzioni"
                Case Tipo.GRANDINE.ToString
                    Return "Grandine"
                Case Tipo.VITA.ToString
                    Return "Vita"
                Case Else
                    Return "???"
            End Select
        End Get
    End Property

    Private Sub LeggiDocumentiBusta()
        Try
            Dim Query As String = String.Format("SELECT * FROM Buste 
                WHERE (DataBusta = '{0:dd/MM/yyyy}') AND (TipoBusta = '{1}') AND (Inviato = CAST(0 AS bit)) 
                ORDER BY Contraente", mDataBusta, mTipoBusta)
            DocBusta = Utx.FunzioniDb.CreaDataTableReader(Query)
        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Shared Sub AggiornaDateDecadi()
        Try
            Globale.Log.Info("Aggiornamento date decadi")

            Dim DataFineDecade As Date = Decade.DataFineDecade(Today)

            'inizializzo le date decadi per tipo busta con la data di riferimento
            DateDecadi.Clear()

            For Each t As String In [Enum].GetNames(GetType(Tipo))
                DateDecadi.Add(t.ToUpper, NO_DATA)
            Next

            'leggo le date decadi aperte e aggiorno il dizionario
            Dim Query As String = "SELECT TipoBusta,MIN(DataBusta) AS DecadeAperta 
                FROM Buste 
                WHERE CAST(Inviato as int) = 0
                GROUP BY TipoBusta"

            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(Query).DataTable

            For Each row As DataRow In dt.Rows
                If row("DecadeAperta") IsNot DBNull.Value Then
                    'ToUpper fondamentale perché le key del dizionario sono maiuscole
                    DateDecadi.Item(row("TipoBusta").ToString.ToUpper) = row("DecadeAperta")
                End If
            Next

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Shared Function DecadeCorrente(Tipo As String) As Date
        Try
            If DateDecadi.Item(Tipo.ToUpper) = NO_DATA Then
                'visualizzo il form per l'apertura della busta
                Using f As New FormAperturaBusta(Tipo)
                    f.ShowDialog()
                    'aggiorno la data nell'elenco delle decadi aperte
                    DateDecadi.Item(Tipo.ToUpper) = f.DecadeSelezionata
                End Using
            End If

            Return DateDecadi.Item(Tipo.ToUpper)

        Catch ex As Exception
            Return Decade.DataFineDecade(Today)
        End Try
    End Function

    Public Shared Function RamoGestione2TipoBusta(RamoGestione As Integer,
                                                  RamoPolizza As Integer) As String
        Select Case RamoGestione
            Case 1, 2
                Select Case RamoPolizza
                    Case 17, 130, 131, 230, 231 : Return "RcaCum"
                    Case Else : Return "RcaSing"
                End Select
            Case 3 To 12, 14, 15, 21, 22, 23 : Return "RamiEle"
            Case 18, 19, 20 : Return "Vita"
            Case 13 : Return "Cauzioni"
            Case 16 : Return "Grandine"
            Case Else : Return "ERRORE"
        End Select
    End Function

#Region "Stampa"
    Public Sub Stampa()

        LeggiDocumentiBusta()

        With PrintBuste
            .PrinterSettings = PrintDialog1.PrinterSettings
            .DocumentName = String.Format("Busta {0}", mTipoBusta)

            With .DefaultPageSettings.Margins
                .Left = 50
                .Top = 50
                .Right = 50
                .Bottom = 100
            End With

            mNumeroPagina = 0
            mProgressivoStampa = 0

            .Print()
        End With
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object,
                                         e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintBuste.PrintPage
        mNumeroPagina += 1
        'stampo una pagina
        Pagina(e)
    End Sub

    Private Sub Pagina(e As System.Drawing.Printing.PrintPageEventArgs)
        Dim f As New Font("Verdana", 8)
        Dim fg As New Font("Verdana", 8, FontStyle.Bold) 'grassetto
        Dim fGrande As New Font("Verdana", 12, FontStyle.Bold) 'grande

        Dim p1 As New Pen(Color.Black, 1)
        Dim p2 As New Pen(Color.Black, 2)

        Dim y As Single = e.MarginBounds.Top
        Dim Tab() As Int16 = {0, 30, 170, 360, 460, 500, 530, 610, e.MarginBounds.Size.Width}

        Dim Sx, Cx, Dx As New StringFormat
        Sx.Alignment = StringAlignment.Near
        Cx.Alignment = StringAlignment.Center
        Dx.Alignment = StringAlignment.Far

        Dim ea As New System.EventArgs

        'per debug
        'For k = 0 To 600 Step 10
        '    StampaStringa(k.ToString, k, y, f, e, Sx, True)
        'Next
        'ACapo(y, f, e, 1)

        IntestazionePagina(y, fg, fGrande, e)
        y += 10

        StampaStringa("Nr", Tab(0), y, fg, e, Sx)
        StampaStringa("Polizza", Tab(1), y, f, e, Sx)
        StampaStringa("Contraente", Tab(2), y, f, e, Sx)
        StampaStringa("Data FC", Tab(3), y, f, e, Sx)
        StampaStringa("Tip.car.", Tab(4), y, f, e, Cx)
        StampaStringa("App.", Tab(5), y, f, e, Cx)
        StampaStringa("Eff.App.", Tab(6), y, f, e, Sx)
        StampaStringa("Targa", Tab(7), y, f, e, Sx, True)
        e.Graphics.DrawLine(p1, e.MarginBounds.Left, y, e.MarginBounds.Right, y)

        e.HasMorePages = False

        Do While DocBusta.Read
            Try
                mProgressivoStampa += 1

                StampaStringa(mProgressivoStampa, Tab(0), y, f, e, Sx)
                StampaStringa(String.Format("{0}-{1}-{2}",
                                            DocBusta("Agenzia").ToString.PadLeft(5, "0"),
                                            DocBusta("Ramo").ToString.PadLeft(3, "0"),
                                            DocBusta("Polizza")), Tab(1), y, f, e, Sx)
                StampaStringa(DocBusta("Contraente"), Tab(2), y, f, e, Sx)
                StampaStringa(DocBusta("DataFogliocassa"), Tab(3), y, f, e, Sx)
                StampaStringa(DocBusta("TipoCarico"), Tab(4), y, f, e, Sx)
                StampaStringa(DocBusta("Appendice"), Tab(5), y, f, e, Sx)
                StampaStringa(DocBusta("EffettoAppendice"), Tab(6), y, f, e, Sx)
                StampaStringa(DocBusta("Targa"), Tab(7), y, f, e, Sx, True)

                If y > e.MarginBounds.Bottom Then
                    e.HasMorePages = True
                    Exit Do
                End If

            Catch ex As Exception
                ACapo(y, f, e, 1)
            End Try
        Loop

        e.Graphics.DrawLine(p1, e.MarginBounds.Left, y, e.MarginBounds.Right, y)
        ACapo(y, f, e, 1)

        StampaStringa(String.Format("Unitools - Stampato il {0}", Now), Tab(0), y, fg, e, Sx)
        StampaStringa(String.Format("Pagina {0}", mNumeroPagina), Tab(7), y, fg, e, Sx, True)
        ACapo(y, f, e, 2)

        'stampo righe x annotazioni
        StampaStringa("Annotazioni:", Tab(0), y, fg, e, Sx, True)

        Do While y < e.MarginBounds.Bottom
            e.Graphics.DrawLine(p1, e.MarginBounds.Left, y, e.MarginBounds.Right, y)
            ACapo(y, f, e, 3)
        Loop
    End Sub

    Private Sub IntestazionePagina(ByRef y As Single,
                                   fGrassetto As Font,
                                   fGrande As Font,
                                   e As System.Drawing.Printing.PrintPageEventArgs)

        Dim Sx, Cx, Dx As New StringFormat
        Sx.Alignment = StringAlignment.Near
        Cx.Alignment = StringAlignment.Center
        Dx.Alignment = StringAlignment.Far

        StampaStringa(String.Format("INVIO SIMPLI DI POLIZZA IN DIREZIONE ({0})", Me.DescrizioneTipoBusta), 0, y, fGrande, e, Sx, True)
        StampaStringa("In allegato si trasmettono i sottoelencati documenti:", 0, y, fGrassetto, e, Sx, True)
    End Sub

    Private Function StampaStringa(Testo As String, _
                                   x As Single, _
                                   ByRef y As Single, _
                                   f As Font, _
                                   e As System.Drawing.Printing.PrintPageEventArgs, _
                                   sf As StringFormat, _
                                   Optional ACapo As Boolean = False) As Single

        e.Graphics.DrawString(Testo,
                              f,
                              Brushes.Black,
                              e.MarginBounds.Left + x,
                              y,
                              sf)

        'la funzione restituisce la posizione corrente della x dopo la stampa della stringa
        If ACapo Then
            StampaStringa = 0
            y = y + f.GetHeight(e.Graphics)
        Else
            Select Case sf.Alignment
                Case StringAlignment.Near 'left
                    StampaStringa = x + e.Graphics.MeasureString(Testo, f).Width
                Case StringAlignment.Center
                    StampaStringa = x + e.Graphics.MeasureString(Testo, f).Width / 2
                Case Else   'StringAlignment.Far 'right
                    StampaStringa = x
            End Select
        End If
    End Function

    Private Sub ACapo(ByRef y As Single, _
                  f As Font, _
                  e As System.Drawing.Printing.PrintPageEventArgs, _
                  ACapo As Int16)

        y = y + ACapo * f.GetHeight(e.Graphics)
    End Sub
#End Region

End Class
