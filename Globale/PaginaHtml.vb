Imports System.IO
Imports System.Drawing
Imports System.Text

Public Class PaginaHtml

    Public Enum TextSize
        x_small = 62
        small = 80
        medium = 100
        large = 112
        x_large = 150
    End Enum
    Public Enum TextAlign
        left
        center
        right
    End Enum
    Public Structure Colori
        Const AZZURRO As String = "#3C70E8"
        Const ROSSO As String = "#FF0000"
        Const VERDE As String = "#33CC33"
        Const GRIGIO As String = "#999999"
        Const GIALLO As String = "#FFFF66"
        Const ARANCIO As String = "#FF9900"
    End Structure

    Private mRighe As List(Of String)
    Private mHeads As List(Of String)

    Sub New(NomeFile As String)
        mRighe = New List(Of String)
        mHeads = New List(Of String)
        mTitolo = ""
        mNomeFile = Path.Combine(Utx.Globale.Paths.CartellaTempUtente, NomeFile)
        mNomeFont = "Calibri"
        mBold = False
        mColore = "#000000"
        mSize = TextSize.medium
    End Sub

    Sub New(NomeFile As String, Cartella As String)
        mRighe = New List(Of String)
        mHeads = New List(Of String)
        mTitolo = ""
        mNomeFile = Path.Combine(Cartella, NomeFile)
        mNomeFont = "Calibri"
        mBold = False
        mColore = "#000000"
        mSize = TextSize.medium
    End Sub

    Private mNomeFile As String
    Public ReadOnly Property NomeFile() As String
        Get
            Return mNomeFile
        End Get
    End Property

    Private mNomeFont As String
    Public Property NomeFont() As String
        Get
            Return mNomeFont
        End Get
        Set(value As String)
            mNomeFont = value
        End Set
    End Property

    Private mColore As String
    Public Property Colore() As String
        Get
            Return mColore
        End Get
        Set(value As String)
            mColore = value
        End Set
    End Property

    Private mBold As Boolean
    Public Property Bold() As Boolean
        Get
            Return mBold
        End Get
        Set(value As Boolean)
            mBold = value
        End Set
    End Property

    Private mSize As TextSize
    Public Property Size() As TextSize
        Get
            Return mSize
        End Get
        Set(value As TextSize)
            mSize = value
        End Set
    End Property

    Private mTitolo As String
    Public Property Titolo() As String
        Get
            Return mTitolo
        End Get
        Set(value As String)
            mTitolo = value
        End Set
    End Property

    Private mTab As Integer
    Public Property Tab() As Integer
        Get
            Return mTab
        End Get
        Set(value As Integer)
            mTab = value
        End Set
    End Property

    Private mTabSize As Integer = 40
    Public Property TabSize() As Integer
        Get
            Return mTabSize
        End Get
        Set(value As Integer)
            mTabSize = value
        End Set
    End Property

    Private mAllineamento As TextAlign = TextAlign.left
    Public Property Allineamento() As TextAlign
        Get
            Return mAllineamento
        End Get
        Set(value As TextAlign)
            mAllineamento = value
        End Set
    End Property

    Public Sub AddRow(Optional Testo As String = " ",
                      Optional ColoreTesto As String = "#000000",
                      Optional Grassetto As Boolean = False)
        mRighe.Add(Me.HtmlRiga(Testo, ColoreTesto, Grassetto))
    End Sub

    Public Sub AddRow()
        mRighe.Add("<br/>")
    End Sub

    Public Sub AddHead(html As String)
        mHeads.Add(html)
    End Sub
    Public Sub AddHtml(html As String, Optional Ripetizioni As Integer = 1, Optional aCapo As Boolean = True)
        Dim Testo As String = ""
        For k As Integer = 1 To Ripetizioni
            Testo &= html & IIf(aCapo, Environment.NewLine, "")
        Next
        mRighe.Add(Testo)
    End Sub

    Public Sub AddHtml(html As String, ParamArray args() As Object)
        mRighe.Add(String.Format(html, args))
    End Sub

    Public Sub AddLine(Optional SpessorePx As Integer = 1)
        mRighe.Add(String.Format("<hr style=""width: 100%; height: {0}px;"" />", SpessorePx))
    End Sub

    Private Function TagSize() As String
        Return mSize.ToString("d") & "%"
    End Function

    Private Function HtmlRiga(Testo As String,
                              Optional ColoreTesto As String = "#000000",
                              Optional Grassetto As Boolean = False) As String
        Try
            Testo = Replace(Testo, vbCrLf, "<br/>")
            Return String.Format("<div style=""margin-left: {0}px; text-align: {1};"">" +
                                 "<span style=""font-family: {2};font-size: {3};color: {4};font-weight: {5}"">{6}</span></div>",
                                 (mTab * mTabSize).ToString,
                                 mAllineamento,
                                 mNomeFont,
                                 TagSize,
                                 ColoreTesto,
                                 IIf(Grassetto = True, "bold", "normal"),
                                 Utx.FunzioniDb.NullToString(Testo))

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return ex.Message
        End Try
    End Function

    Private Function HtmlTesta(Optional Titolo As String = "") As String
        Try
            Dim testa As New StringBuilder
            testa.AppendFormat("<!DOCTYPE html>{0}<html>{0}<title>{1}</title>{0}",
                               Environment.NewLine,
                               mTitolo)
            For Each riga In mHeads
                testa.AppendLine(riga)
            Next

            testa.AppendLine("<body>")

            Return testa.ToString

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
            Return ex.Message
        End Try
    End Function

    Private Function HtmlCoda() As String
        Return String.Format("</body>{0}</html>", Environment.NewLine)
    End Function

    Public Sub CreaFileHtml()
        Try
            'controllo estensione  file
            Select Case Path.GetExtension(mNomeFile).ToUpper
                Case ".HTM", ".HTML"
                    'ok
                Case Else
                    mNomeFile += ".html"
            End Select

            File.Delete(mNomeFile)

            Using sw As New StreamWriter(mNomeFile, False, Encoding.UTF8)
                'testata
                sw.WriteLine(HtmlTesta(mTitolo))
                'corpo
                For Each r As String In mRighe
                    sw.WriteLine(r)
                Next
                'coda
                sw.WriteLine(HtmlCoda())
            End Using

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub Sostituisci(Cerca As String, Sostituzione As String)
        Try
            For k = 0 To mRighe.Count - 1
                mRighe(k) = Replace(mRighe(k), Cerca, Sostituzione)
            Next
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Sub CancellaFile()
        File.Delete(mNomeFile)
    End Sub

    Public Sub Stampa()
        Try
            Shell(String.Format("rundll32.exe MSHTML.DLL PrintHTML ""{0}""", mNomeFile), AppWinStyle.NormalFocus, True)
            CancellaFile()

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Public Function CreaFilePdf() As String
        Return CreaFilePdf(mNomeFile, Path.ChangeExtension(mNomeFile, ".pdf"))
    End Function

    Public Shared Function CreaFilePdf(NomeFileHtml As String, NomeFilePdf As String) As String
        If Utx.Pdf.CreaPdfDaHtml(NomeFileHtml, NomeFilePdf) = True Then
            Return NomeFilePdf
        Else
            Return ""
        End If
    End Function
End Class
