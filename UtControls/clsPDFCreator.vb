'================================================================
' Descrizione.....: Classe per la generazione di file PDF 1.3
' Nome dei File...: clsPDFCreator.vb
' Data............: 03/07/2008
' Versione........: 1.2.5 (FREE)
' Sistema.........: VB.net 2003 - 2008
' Testato su......: Windows XP SP2
' Scritto da......: Luigi Micco ® eLLeMMe
' E-Mail..........: l(dot)micco(at)tiscali(dot)it
' Web site........: http://www.luigimicco.altervista.org
' Migration by....: Martin Ernst m(dot)ernst(at)wuerzburger(dot)com
'================================================================
' (C) 2003/08 Questo software è di libero utilizzo per scopi  NON
'             COMMERCIALI.  Qualsiasi altro  uso, senza  espressa
'             autorizzazione dell'autore non  è consentito. Se il
'             software viene  ridistributo,  non eliminare questa
'             nota.
'================================================================

Option Explicit On 

Public Class clsPDFCreator
	Private Const PDF_VERSION = "%PDF-1.3"
    Private Const AUTOR = "Luigi Micco & Martin Ernst"
	Private Const CREATOR = "clsPDFCreator FREE Version"
    Private Const COPYRIGHT = "© 2003-2008 Luigi Micco"

	' Enum
	Public Enum pdfPathOptions
		Stroked = &H1
		Closed = &H2
		Filled = &H4
		Nil = &H0
	End Enum

	Public Enum pdfColorSpace
		pdfRGB = 0
		pdfGrayScale = 1
	End Enum

	Public Enum pdfFontStyle
		pdfNormal = 0
		pdfBold = 1
		pdfItalic = 2
		pdfBoldItalic = 3
	End Enum

	Public Enum pdfTextAlign
		pdfAlignLeft = 0
		pdfAlignRight = 1
		pdfCenter = 2
	End Enum

	Public Enum pdfPaperSize
		pdfA4 = 0
		pdfA3 = 1
		pdf85x11 = 2
		pdf85x12 = 3
		pdfUser = &HFF
	End Enum

	Public Enum pdfScaleMode
		pdf72PxInch = 0
		pdfInch = 1
		pdfMillimeter = 2
		pdfCentimeter = 3
	End Enum

	Public Enum pdfPageOrientation
		pdfPortrait = 0
		pdfLandscape = 1
	End Enum

	Public Enum pdfObjectType
		pdfNull = &H0
		pdfFirstPage = &H1
		pdfEvenPages = &H2
		pdfOddPages = &H4
		pdfNotFirstPage = &H8
		pdfAllPages = pdfEvenPages Or pdfOddPages Or pdfFirstPage
	End Enum


	'Internal Variables
	Private mvarFileNumber As Int16
	Private mvarTitle As String
	Private mvarPaperSize As pdfPaperSize
	Private mvarPageWidth As Single
	Private mvarPageHeight As Single
	Private mvarScaleMode As pdfScaleMode
	Private mvarOrientation As pdfPageOrientation
	Private mvarPages As Int16
	Private mvarMargin As Single
	Private mvarFileName As String	'Copia locale.
	Private mvarEncodeASCII85 As Boolean
	Private strPage As String
	Private strFont As String
	Private strFontname As String
	Private strImg As String
	Private strObject As String
	Private strObjectForPage As String
	Private intResource As Int16
	Private intPages As Int16
	Private intObject As Int16
	Private intMaxObject As Int32
	Private intOffsetTemp As Int32
	Private intUsedFont As Int16

	Private mvarCharSpacing As Single
	Private mvarWordSpacing As Single
	Private mvarTextScaling As Single

	Private Class FontDescriptor
		Public BaseFont As String
		Public FirstChar As Byte
		Public LastChar As Byte
		Public Param As String
		Public Widths(255) As Int32
		Public MissingWidth As Int32
	End Class

	Private Class ObjDescriptor
		Public Name As String
		Public Options As pdfObjectType
	End Class

	'Data Arrays
	Private arrXREF() As String
	Private arrOBJECT() As ObjDescriptor
	Private arrFONT() As FontDescriptor

	Public Sub New()
		mvarFileNumber = 0
		mvarEncodeASCII85 = False
		Title = "(senza titolo)"
		mvarScaleMode = pdfScaleMode.pdf72PxInch
		PaperSize = pdfPaperSize.pdfA4
		mvarOrientation = pdfPageOrientation.pdfPortrait
		mvarMargin = 0
		mvarPages = 0
		intUsedFont = 0
	End Sub


	'
	Public WriteOnly Property EncodeASCII85() As Boolean
		Set(vData As Boolean)
			mvarEncodeASCII85 = vData
		End Set
	End Property

	'
	Public WriteOnly Property Margin() As Single
		Set(vData As Single)
			mvarMargin = ToSpace(vData)
		End Set
	End Property

	'
	Public WriteOnly Property PaperWidth() As Single
		Set(vData As Single)
			If mvarPaperSize <> pdfPaperSize.pdfUser Then mvarPaperSize = pdfPaperSize.pdfUser
			mvarPageWidth = ToSpace(vData)
		End Set
	End Property

	'
	Public WriteOnly Property PaperHeight() As Single
		Set(vData As Single)
			If mvarPaperSize <> pdfPaperSize.pdfUser Then mvarPaperSize = pdfPaperSize.pdfUser
			mvarPageHeight = ToSpace(vData)
		End Set
	End Property

	'
	Public ReadOnly Property Pages() As Int16
		Get
			Pages = mvarPages
		End Get
	End Property

	'
	Public WriteOnly Property ScaleMode() As pdfScaleMode
		Set(New_ScaleMode As pdfScaleMode)
			mvarScaleMode = New_ScaleMode
		End Set
	End Property

	'
	Public WriteOnly Property PaperSize() As pdfPaperSize
		Set(New_PaperSize As pdfPaperSize)
			mvarPaperSize = New_PaperSize

			Select Case mvarPaperSize
				Case pdfPaperSize.pdf85x12				 'Letter, 8 1/2 x 12 in.
					mvarPageWidth = 612
					mvarPageHeight = 864

				Case pdfPaperSize.pdf85x11				 'Letter, 8 1/2 x 11 in.
					mvarPageWidth = 612
					mvarPageHeight = 792

				Case pdfPaperSize.pdfA3				 'A3, 297 x 420 mm
					mvarPageWidth = 842
					mvarPageHeight = 1190.5

				Case pdfPaperSize.pdfA4				 'A4, 210 x 297 mm
					mvarPageWidth = 595.2
					mvarPageHeight = 842

				Case pdfPaperSize.pdfUser				 'User-defined

			End Select
		End Set
	End Property

	'
	Public WriteOnly Property Orientation() As pdfPageOrientation
		Set(NewOrientation As pdfPageOrientation)
			mvarOrientation = NewOrientation
		End Set
	End Property

	'
	Public WriteOnly Property Title() As String
		Set(New_Title As String)
			mvarTitle = New_Title
		End Set
	End Property


	'
	Public Sub InitPDFFile(Optional strFileName As String = "")

		If mvarFileNumber <> 0 Then FileClose(mvarFileNumber) : mvarFileNumber = 0


		If strFileName = "" Then strFileName = Environment.GetCommandLineArgs()(0) & "\..\~" & Hex(Val(Format(Now(), "dhhmmss") & Trim(Str(Int(Rnd() * 10))))) & ".pdf"

		mvarFileNumber = FreeFile()
		mvarFileName = strFileName
		FileOpen(mvarFileNumber, mvarFileName, OpenMode.Output)

		WriteObj(PDF_VERSION)

		' inizializza gli oggetti
		intMaxObject = 0

		' 1 Attribute
		InitObj(1)
		WriteObj("<<" & vbCrLf & _
		 "/Title (" & ToPdfStr(mvarTitle) & ")" & vbCrLf & _
		 "/Author (" & ToPdfStr(AUTOR) & ")" & vbCrLf & _
		 "/Creator  (" & ToPdfStr(CREATOR) & ")" & vbCrLf & _
		 "/Producer (" & ToPdfStr(COPYRIGHT) & ")" & vbCrLf & _
		 "/CreationDate (D:" & Format(Now(), "yyyymmddhhmmss") & "+01'00')" & vbCrLf & _
		 ">>")
		EndObj()

		' 2 Catalog
		InitObj(2)
		WriteObj("<<" & vbCrLf & _
		 "/Type /Catalog" & vbCrLf & _
		 "/Pages 3 0 R" & vbCrLf & _
		 "/PageLayout /OneColumn" & vbCrLf & _
		 "/PageMode /UseNone" & vbCrLf & _
		 "/Lang (it) " & vbCrLf & _
		 "/ViewerPreferences << /HideToolbar false " & _
		 "/DisplayDocTitle true " & _
		 "/HideWindowUI false >>" & vbCrLf & _
		 ">>")
		EndObj()

		' Lascia spazio per gli oggetti 3, 4
		intMaxObject = 4

	End Sub

	Public Sub ClosePDFFile()
		Dim i As Int16
		Dim intTemp As Int32

		' 4 Resource
		intResource = InitObj(4)
		WriteObj("<<" & vbCrLf & _
		 IIf(strFont <> "", "/Font <<" & vbCrLf & strFont & ">>" & vbCrLf, "") & _
		 "/ProcSet [/PDF /Text" & IIf(strImg <> "", " /ImageB /ImageC /ImageI", "") & " ]" & vbCrLf & _
		 IIf((strImg <> "") Or (strObject <> ""), "/XObject <<" & vbCrLf & strImg & vbCrLf & strObject & ">>" & vbCrLf, "") & _
		 ">>")
		EndObj()

		' 3 Page
		intPages = InitObj(3)
		WriteObj("<<" & vbCrLf & _
		 "/Type /Pages" & vbCrLf & _
		 "/Count " & mvarPages & vbCrLf & _
		 "/MediaBox [0 0 " & _
		  ToStr(mvarPageWidth) & " " & _
		  ToStr(mvarPageHeight) & "]" & vbCrLf & _
		 "/CropBox [" & ToStr(mvarMargin) & " " & _
		 ToStr(mvarMargin) & " " & _
		 ToStr(mvarPageWidth - mvarMargin) & " " & _
		 ToStr(mvarPageHeight - mvarMargin) & "]" & vbCrLf & _
		 IIf(mvarOrientation = pdfPageOrientation.pdfLandscape, "/Rotate 90", "") & vbCrLf & _
		 "/Kids [" & strPage & " ]" & vbCrLf & _
		 "/Resources " & CStr(intResource) & " 0 R" & vbCrLf & _
		 ">>")
		EndObj()

		intTemp = Seek(mvarFileNumber) - 1
		WriteObj("xref")
		WriteObj("0 " & CStr(intMaxObject + 1))
		WriteObj("0000000000 65535 f")
		For i = 1 To intMaxObject
			WriteObj(arrXREF(i))
		Next

		WriteObj("trailer" & vbCrLf & _
		 "<<" & vbCrLf & _
		 "/Size " & intMaxObject & vbCrLf & _
		 "/Info 1 0 R" & vbCrLf & _
		 "/Root 2 0 R" & vbCrLf & _
		 ">>")

		WriteObj("startxref" & vbCrLf & _
		 CStr(intTemp))

		Print(mvarFileNumber, "%%EOF", vbCrLf)
		FileClose(mvarFileNumber)
		mvarFileNumber = 0
	End Sub

	Private Function InitObj(Optional intObj As Int16 = 0) As Int16

		If intObj = 0 Then intObj = intMaxObject + 1
		If intObj > intMaxObject Then intMaxObject = intObj
		ReDim Preserve arrXREF(intMaxObject)

		arrXREF(intObj) = Right$("0000000000" & (Seek(mvarFileNumber) - 1), 10) & " 00000 n"
		WriteObj(CStr(intObj) & " 0 obj")
		InitObj = intObj
	End Function

	Private Sub EndObj()
		PrintLine(mvarFileNumber, "endobj")
	End Sub

	Private Sub WriteObj(strTemp As String)
		PrintLine(mvarFileNumber, strTemp)
	End Sub

	Public Function BeginPage() As Int16
		Dim intPage As Int16

		mvarPages = mvarPages + 1
		intPage = InitObj()
		WriteObj("<<" & vbCrLf & _
		 "/Type /Page" & vbCrLf & _
		 "/Parent 3 0 R" & vbCrLf & _
		 "/Contents " & CStr(intPage + 1) & " 0 R" & vbCrLf & _
		 ">>")
		EndObj()

		strPage = strPage & CStr(intPage) & " 0 R "

		InitObj(intPage + 1)
		WriteObj("<< /Length " & CStr(intPage + 2) & " 0 R >>" & vbCrLf & _
		 "stream")
		intOffsetTemp = Seek(mvarFileNumber)

		' Verifica se ci sono oggetti comuni da inserire sullo sfondo della pagina
		InsertObjectOnPage()

		mvarCharSpacing = 0
		mvarWordSpacing = 0
		mvarTextScaling = 100
		BeginPage = mvarPages
	End Function

	'
	Public Sub EndPage()

		intOffsetTemp = Seek(mvarFileNumber) - intOffsetTemp
		WriteObj("endstream")
		EndObj()

		' Scrive la lunghezza
		InitObj()
		WriteObj(CStr(intOffsetTemp))
		EndObj()
	End Sub

	'
	Public Sub SetWordSpacing(W As Single)
		mvarWordSpacing = W
		WriteObj(ToStr(mvarWordSpacing) & " Tw")
	End Sub

	'
	Public Sub SetCharSpacing(W As Single)
		mvarCharSpacing = W
		WriteObj(ToStr(mvarCharSpacing) & " Tc")
	End Sub

	'
	Public Sub SetTextHorizontalScaling(W As Single)
		mvarTextScaling = W
		WriteObj(ToStr(mvarTextScaling) & " Tz")
	End Sub

	'
	Public Sub SetTextRenderingMode(W As Single)
		If (W >= 0) And (W <= 2) Then WriteObj(ToStr(W) & " Tr")
	End Sub

	'
	Public Sub DrawText(x As Single, y As Single, _
	strTemp As String, _
	FontName As String, Fontsize As Single, _
	Optional Align As pdfTextAlign = pdfTextAlign.pdfAlignLeft, _
	Optional Rotate As Single = 0)
		Dim PI As Single
		Dim sTeta As Single
		Dim cTeta As Single
		Dim C As Single
		Dim l As Single

		Select Case Align
			Case pdfTextAlign.pdfAlignLeft

			Case pdfTextAlign.pdfAlignRight
				l = Length(strTemp, FontName, Fontsize)
				x = x - l
			Case pdfTextAlign.pdfCenter
				l = Length(strTemp, FontName, Fontsize)
				x = x - l / 2
		End Select

		WriteObj("BT")
		WriteObj("/" & FontName & " " & ToStr(Fontsize) & " Tf")
		If Rotate <> 0 Then
			PI = Math.PI
			C = PI / 180.0F
			sTeta = Math.Sin(C * Rotate)
			cTeta = Math.Cos(C * Rotate)
			WriteObj(ToStr(cTeta) & " " & ToStr(sTeta) & " " & _
			 ToStr(-sTeta) & " " & ToStr(cTeta) & _
			 " " & ToStr(ToSpace(x)) & " " & ToStr(ToSpace(y)) & " Tm")
		Else
			WriteObj(ToStr(ToSpace(x)) & " " & ToStr(ToSpace(y)) & " Td")
		End If

		WriteObj("(" & ToPdfStr(strTemp) & ") Tj")
		WriteObj("ET")
	End Sub

	'
	Public Sub SetColorStroke(rgb As Int32)
		Dim R As Byte
		Dim G As Byte
		Dim B As Byte

		If (rgb <= 0) And (rgb >= -255) Then
			WriteObj(ToStr(-rgb / 255) & " G")
		Else
			R = (rgb Mod 256)
			G = ((rgb \ 256) Mod 256)
			B = ((rgb \ 65536) Mod 256)
			WriteObj(ToStr(R / 255) & " " & ToStr(G / 255) & " " & ToStr(B / 255) & " RG")
		End If
	End Sub

	'
	Public Sub SetColorFill(rgb As Int32)
		Dim R As Byte
		Dim G As Byte
		Dim B As Byte

		If (rgb <= 0) And (rgb >= -255) Then
			WriteObj(ToStr(-rgb / 255) & " g")
		Else
			R = (rgb Mod 256)
			G = ((rgb \ 256) Mod 256)
			B = ((rgb \ 65536) Mod 256)
			WriteObj(ToStr(R / 255) & " " & ToStr(G / 255) & " " & ToStr(B / 255) & " rg")
		End If
	End Sub

	'
	Public Sub SetDash(dash_on As Single, Optional dash_off As Single = 0)
		If (dash_on = 0) And (dash_off = 0) Then
			WriteObj("[ ] 0 d")
		Else
			WriteObj("[" & ToStr(ToSpace(dash_on)) & " " & ToStr(ToSpace(dash_off)) & "] 0 d")
		End If
	End Sub

	'
	Public Sub SetLineWidth(W As Single)
		WriteObj(ToStr(ToSpace(W)) & " w")
	End Sub

	'
	Public Sub SetLineCap(W As Int16)
		If (W >= 0) And (W <= 2) Then WriteObj(ToStr(W) & " J")
	End Sub

	'
	Public Sub SetLineJoin(W As Int16)
		If (W >= 0) And (W <= 2) Then WriteObj(ToStr(W) & " j")
	End Sub

	'
	Public Sub SetMiterLimit(W As Single)
		If (W >= 1) Then WriteObj(ToStr(W) & " M")
	End Sub

	'
	Public Sub MoveTo(x As Single, y As Single)
		WriteObj(ToStr(ToSpace(x)) & " " & ToStr(ToSpace(y)) & " m")
	End Sub

	'
	Public Sub LineTo(x As Single, y As Single, _
	Optional Options As pdfPathOptions = pdfPathOptions.Stroked)
		WriteObj(ToStr(ToSpace(x)) & " " & ToStr(ToSpace(y)) & " l")
		Call Path(Options)
	End Sub

	Private Sub Path(Optional Options As pdfPathOptions = pdfPathOptions.Nil)

		If (Options And (pdfPathOptions.Filled Or pdfPathOptions.Stroked Or pdfPathOptions.Closed)) = (pdfPathOptions.Filled Or pdfPathOptions.Stroked Or pdfPathOptions.Closed) Then
			WriteObj("b")
		ElseIf (Options And (pdfPathOptions.Filled Or pdfPathOptions.Stroked)) = (pdfPathOptions.Filled Or pdfPathOptions.Stroked) Then
			WriteObj("B")
		ElseIf (Options And pdfPathOptions.Filled) = pdfPathOptions.Filled Then
			WriteObj("f")
		Else
			If (Options And pdfPathOptions.Closed) <> 0 Then WriteObj("h")
			If (Options And pdfPathOptions.Stroked) <> 0 Then WriteObj("S")
		End If

	End Sub

	'
	Public Sub Rectangle(x As Single, y As Single, _
	xdim As Single, ydim As Single, _
	Optional Options As pdfPathOptions = pdfPathOptions.Stroked, _
	Optional Ray As Single = 0)
		Dim sR As Single

		WriteObj("n")
		If Ray > 0 Then
			If Ray > (xdim / 2) Then Ray = xdim / 2
			If Ray > (ydim / 2) Then Ray = ydim / 2
			sR = 0.55 * Ray
			MoveTo(x + Ray, y)
			LineTo(x + xdim - Ray, y, pdfPathOptions.Nil)
			Curve((x + xdim - Ray + sR), y, x + xdim, y + Ray - sR, x + xdim, y + Ray, pdfPathOptions.Nil)
			LineTo(x + xdim, y + ydim - Ray, pdfPathOptions.Nil)
			Curve(x + xdim, y + ydim - Ray + sR, x + xdim - Ray + sR, y + ydim, x + xdim - Ray, y + ydim, pdfPathOptions.Nil)
			LineTo(x + Ray, y + ydim, pdfPathOptions.Nil)
			Curve(x + Ray - sR, y + ydim, x, y + ydim - Ray + sR, x, y + ydim - Ray, pdfPathOptions.Nil)
			LineTo(x, y + Ray, pdfPathOptions.Nil)
			Curve(x, y + Ray - sR, x + Ray - sR, y, x + Ray, y, pdfPathOptions.Nil)
		Else
			WriteObj(ToStr(ToSpace(x)) & " " & ToStr(ToSpace(y)) & " " & _
			 ToStr(ToSpace(xdim)) & " " & ToStr(ToSpace(ydim)) & " re")
		End If

		Call Path(Options)
	End Sub

	'
	Public Sub Curve(x1 As Single, y1 As Single, _
	X2 As Single, Y2 As Single, _
	X3 As Single, Y3 As Single, _
	Optional Options As pdfPathOptions = pdfPathOptions.Stroked)

		WriteObj(ToStr(ToSpace(x1)) & " " & ToStr(ToSpace(y1)) & " " & _
		 ToStr(ToSpace(X2)) & " " & ToStr(ToSpace(Y2)) & " " & _
		 ToStr(ToSpace(X3)) & " " & ToStr(ToSpace(Y3)) & " c")
		Call Path(Options)
	End Sub

	'
	Public Sub DrawCircle(x As Single, y As Single, _
	Ray As Single, _
	Optional Options As pdfPathOptions = pdfPathOptions.Stroked)

		MoveTo(x, y - Ray)
		Curve(x + 0.55 * Ray, y - Ray, x + Ray, y - 0.55 * Ray, x + Ray, y, pdfPathOptions.Nil)
		Curve(x + Ray, y + 0.55 * Ray, x + 0.55 * Ray, y + Ray, x, y + Ray, pdfPathOptions.Nil)
		Curve(x - 0.55 * Ray, y + Ray, x - Ray, y + 0.55 * Ray, x - Ray, y, pdfPathOptions.Nil)
		Curve(x - Ray, y - 0.55 * Ray, x - 0.55 * Ray, y - Ray, x, y - Ray, pdfPathOptions.Nil)
		Call Path(Options)
	End Sub

	'
	Public Sub Arc(x As Single, y As Single, _
	Ray As Single, _
	Optional StartAngle As Single = 0, _
	Optional EndAngle As Single = 360, _
	Optional Ratio As Single = 1, _
	Optional Pie As Boolean = False, _
	Optional Rotate As Single = 0, _
	Optional Quality As Int16 = 1, _
	Optional Options As pdfPathOptions = pdfPathOptions.Stroked)

		Dim i As Single
		Dim rad As Single
		Dim PI As Single
		Dim sTeta As Single
		Dim cTeta As Single
		Dim C As Single
		Dim x1, X2 As Single
		Dim y1, Y2 As Single

		WriteObj("n")
		MoveTo(x, y)
		If (Options And pdfPathOptions.Filled) <> 0 Then Pie = True
		PI = Math.PI
		C = PI / 180
		sTeta = Math.Sin(-C * Rotate)
		cTeta = Math.Cos(-C * Rotate)

		For i = StartAngle To EndAngle Step Quality
			rad = C * i
			X2 = Ray * Math.Cos(rad)
			Y2 = (Ray * Ratio) * Math.Sin(rad)

			x1 = X2 * cTeta + Y2 * sTeta
			y1 = -X2 * sTeta + Y2 * cTeta
			If (i = StartAngle) And (Not Pie) Then MoveTo(x + x1, y + y1)
			LineTo(x + x1, y + y1, pdfPathOptions.Nil)
		Next

		If Pie Then LineTo(x, y, pdfPathOptions.Nil)
		Call Path(Options)
	End Sub

	'
	Public Function LoadImgFromBMPFile(Name As String, _
	FileName As String, _
	Optional ColorSpace As pdfColorSpace = pdfColorSpace.pdfRGB) As Boolean
		Dim ImgBuf() As Byte = Nothing
		Dim ImgColor() As Byte = Nothing
		Dim blnFlag As Boolean
		Dim ImgWidth As Int32
		Dim ImgHeight As Int32
		Dim ImgBPP As Byte

		blnFlag = LeggeBMP(FileName, ImgBuf, ImgColor, ImgWidth, ImgHeight, ImgBPP, ColorSpace)
		If blnFlag Then LoadImgFromArray(Name, ImgBuf, ImgColor, ImgWidth, ImgHeight, ImgBPP, ColorSpace)
		LoadImgFromBMPFile = blnFlag
	End Function

	Private Function StrConv(buf() As Byte) As String
		Dim sb As New System.Text.StringBuilder
		Dim len As Integer = buf.Length - 1

		'everything here is 1-based
		For i As Integer = 1 To len
			sb.Append(ChrW(buf(i)))
		Next

		StrConv = sb.ToString()
	End Function


	'
	Public Sub LoadImgFromArray(Name As String, _
	 ByRef ImgBuf() As Byte, _
	 ByRef ImgColor() As Byte, _
	ImgWidth As Int32, _
	ImgHeight As Int32, _
	ImgBPP As Byte, _
	Optional ColorSpace As pdfColorSpace = pdfColorSpace.pdfRGB)

		Dim sPixel As String
		Dim sColor As String
		Dim i As Int16

		Dim strDevice As String
		Dim BPP As Byte

		BPP = 8 / ImgBPP

		i = InitObj()
		WriteObj("<<" & vbCrLf & _
		 "/Type /XObject" & vbCrLf & _
		 "/Subtype /Image" & vbCrLf & _
		 "/Name /" & Name & vbCrLf & _
		 "/Width " & CStr(ImgWidth) & vbCrLf & _
		 "/Height " & CStr(ImgHeight) & _
		 IIf(mvarEncodeASCII85, vbCrLf & "/Filter /ASCII85Decode", ""))

		strDevice = IIf(ColorSpace = pdfColorSpace.pdfRGB, "DeviceRGB", "DeviceGray")

		Select Case ImgBPP
			Case 24
				WriteObj("/BitsPerComponent 8" & vbCrLf & _
				 "/ColorSpace /" & strDevice & vbCrLf & _
				 "/Length " & CStr(i + 1) & " 0 R")

			Case 8, 4, 1
				WriteObj("/BitsPerComponent " & CStr(ImgBPP) & vbCrLf & _
				 "/ColorSpace [/Indexed /" & strDevice & " " & _
				 CStr((2 ^ ImgBPP) - 1) & " " & CStr(i + 2) & " 0 R]" & vbCrLf & _
				 "/Length " & CStr(i + 1) & " 0 R")

		End Select

		' Now I use StrConv: thanks to Adriano Belfiore <for_program(at)yahoo(dot)it>
		If mvarEncodeASCII85 Then sPixel = ToASCII85(ImgBuf) _
		Else sPixel = StrConv(ImgBuf)

		WriteObj(">>" & vbCrLf & _
		 "stream" & vbCrLf & _
		 sPixel & vbCrLf & _
		 "endstream")
		EndObj()

		strImg = strImg & "/" & Name & " " & CStr(i) & " 0 R " & vbCrLf

		InitObj()
		WriteObj(CStr(Len(sPixel) - IIf(mvarEncodeASCII85, 2, 0)))
		EndObj()

		If ImgBPP <= 8 Then
			InitObj()

			sColor = IIf(mvarEncodeASCII85, ToASCII85(ImgColor), StrConv(ImgColor))

			WriteObj("<<" & _
			 IIf(mvarEncodeASCII85, "/Filter /ASCII85Decode" & vbCrLf, "") & _
			 "/Length " & CStr(Len(sColor) - IIf(mvarEncodeASCII85, 2, 0)) & " >>" & vbCrLf & _
			 "stream" & vbCrLf & _
			 sColor & vbCrLf & _
			 "endstream")
			EndObj()
		End If


	End Sub



	'
	Public Sub DrawImg(Name As String, _
	DestX As Single, DestY As Single, _
	ImgWidth As Single, ImgHeight As Single)

		WriteObj("q" & vbCrLf & _
		 ToStr(ToSpace(ImgWidth)) & " " & " 0 0 -" & ToStr(ToSpace(ImgHeight)) & _
		 " " & ToStr(ToSpace(DestX)) & " " & ToStr(ToSpace(DestY)) & " cm" & vbCrLf & _
		 "/" & Name & " Do" & vbCrLf & _
		 "Q")

	End Sub

	' Carica 1 dei 14 font base Tipo1
	Public Sub LoadFontStandard(Name As String, BaseFont As String, _
	Optional Options As pdfFontStyle = pdfFontStyle.pdfNormal)
		Dim i As Int16
		Dim sTemp As String

		BaseFont = Replace(BaseFont, " ", "")
		If Options = pdfFontStyle.pdfBold Then
			sTemp = ",Bold"
		ElseIf Options = pdfFontStyle.pdfBoldItalic Then
			sTemp = ",BoldItalic"
		ElseIf Options = pdfFontStyle.pdfItalic Then
			sTemp = ",Italic"
		Else
			sTemp = ""
		End If

		i = InitObj()
		WriteObj("<< /Type /Font " & _
		 "/Subtype /Type1 " & _
		 "/Name /" & Name & " " & _
		 "/BaseFont /" & BaseFont & sTemp & " " & _
		 "/Encoding /WinAnsiEncoding >>")
		EndObj()
		strFont = strFont & "/" & Name & " " & CStr(i) & " 0 R " & vbCrLf
	End Sub

	' Carica un font tipo TrueType
	Public Sub LoadFont(Name As String, BaseFont As String, _
	Optional Options As pdfFontStyle = pdfFontStyle.pdfNormal)
		Dim i As Int16
		Dim j As Int16
		Dim sTemp As String

		intUsedFont = intUsedFont + 1
		ReDim Preserve arrFONT(intUsedFont)

		BaseFont = UCase(Replace(BaseFont, " ", ""))

		Select Case BaseFont
			Case "TIMESNEWROMAN"
				arrFONT(intUsedFont) = CreateFontTimes(Options)

			Case "COURIERNEW"
				arrFONT(intUsedFont) = CreateFontCourier(Options)

			Case "SYMBOL"
				arrFONT(intUsedFont) = CreateFontSymbol(Options)

			Case Else
				arrFONT(intUsedFont) = CreateFontArial(Options)

		End Select

		With arrFONT(intUsedFont)
			i = InitObj()
			WriteObj("<< /Type /Font " & vbCrLf & _
			 "/Subtype /TrueType" & vbCrLf & _
			 "/Name /" & Name & vbCrLf & _
			 "/BaseFont /" & .BaseFont & vbCrLf & _
			 "/FirstChar " & CStr(.FirstChar) & vbCrLf & _
			 "/LastChar " & CStr(.LastChar) & vbCrLf & _
			 "/FontDescriptor " & CStr(i + 1) & " 0 R" & vbCrLf & _
			 "/Encoding /WinAnsiEncoding" & vbCrLf & _
			 "/Widths [")

			sTemp = ""
			For j = .FirstChar To .LastChar
				sTemp = sTemp & ToStr(.Widths(j)) & " "
				If (((j - .FirstChar + 1) Mod 16) = 0) Or (j = .LastChar) Then
					WriteObj(sTemp)
					sTemp = ""
				End If
			Next

			WriteObj("] >>")
			EndObj()
			strFont = strFont & "/" & Name & " " & CStr(i) & " 0 R " & vbCrLf
			strFontname = strFontname & "<" & Name & ">" & Right("0000" & CStr(intUsedFont), 4) & ";"

			i = InitObj()
			WriteObj("<<" & vbCrLf & _
			 "/Type /FontDescriptor" & vbCrLf & _
			 "/FontName /" & .BaseFont & vbCrLf & _
			 .Param & vbCrLf & _
			 ">>")
			EndObj()
		End With
	End Sub


	Public Sub StartObject(Name As String, Optional Options As pdfObjectType = pdfObjectType.pdfNull)
		Dim i As Int16

		i = InitObj()
		WriteObj("<<" & vbCrLf & _
		 "/Type /XObject" & vbCrLf & _
		 "/Subtype /Form" & vbCrLf & _
		 "/FormType 1" & vbCrLf & _
		 "/Name /" & Name & vbCrLf & _
		 "/BBox [" & ToStr(mvarMargin) & " " & _
		 ToStr(mvarMargin) & " " & _
		 ToStr(mvarPageWidth - mvarMargin) & " " & _
		 ToStr(mvarPageHeight - mvarMargin) & "]" & vbCrLf & _
		 "/Matrix [1 0 0 1 0 0]" & vbCrLf & _
		 "/Length " & CStr(i + 1) & " 0 R >>" & vbCrLf & _
		 "stream")
		intOffsetTemp = Seek(mvarFileNumber)

		strObject = strObject & "/" & Name & " " & CStr(i) & " 0 R " & vbCrLf

		intObject = intObject + 1
		ReDim Preserve arrOBJECT(intObject)
		arrOBJECT(intObject) = New ObjDescriptor

		With arrOBJECT(intObject)
			.Name = Name
			.Options = Options
		End With

	End Sub

	Public Sub EndObject()

		intOffsetTemp = Seek(mvarFileNumber) - intOffsetTemp
		WriteObj("endstream")
		EndObj()

		' Scrive la lunghezza
		InitObj()
		WriteObj(CStr(intOffsetTemp))
		EndObj()
	End Sub

    Public Sub DrawObject(Name As String)
        WriteObj("/" & Name & " Do")
    End Sub

	' UTILITA': Funzioni di utilita'
	Private Function ToSpace(Valore As Single) As Single
        ' Convert value to 72 pixel per inch
		Select Case mvarScaleMode

			Case pdfScaleMode.pdf72PxInch
				ToSpace = Valore

			Case pdfScaleMode.pdfInch
				ToSpace = Valore * 72

            Case pdfScaleMode.pdfMillimeter
                ToSpace = (Valore * 72) / 25.4

            Case pdfScaleMode.pdfCentimeter
                ToSpace = (Valore * 72) / 2.54

            Case Else
                ToSpace = Valore
        End Select
    End Function

	Private Function ToUser(Valore As Single) As Single
        ' Convert value to 72 pixel per inch
		Select Case mvarScaleMode

			Case pdfScaleMode.pdf72PxInch
				ToUser = Valore

			Case pdfScaleMode.pdfInch
				ToUser = Valore / 72

            Case pdfScaleMode.pdfMillimeter
                ToUser = 25.4 * (Valore / 72)

            Case pdfScaleMode.pdfCentimeter
                ToUser = 2.54 * (Valore / 72)

            Case Else
                ToUser = Valore
        End Select
    End Function

	Private Function ToStr(Valore As Object, Optional Dec As Int16 = 3) As String
		ToStr = Replace(CStr(Math.Round(Valore, Dec)), ",", ".")
	End Function


	Public Function Length(Phrase As String, FontName As String, Fontsize As Single) As Single

		Dim k As Single
		Dim i As Int16
		Dim C As Byte
		Dim l As Int16
		Dim j As Single
		Dim UsedFont As Int16

		k = 0
		l = Len(Phrase)
		j = 0

		k = InStr(1, strFontname, "<" & FontName & ">", vbTextCompare)
		If k > 0 Then
			k = k + Len(FontName) + 2
			UsedFont = Val(Mid(strFontname, k, 4))

			With arrFONT(UsedFont)
				For i = 1 To l
					C = Asc(Mid(Phrase, i, 1))
					k = k + IIf((C >= .FirstChar) And (C <= .LastChar), .Widths(C), .MissingWidth)
					If C = 32 Then j = j + 1 ' conta gli spazi
				Next
			End With
			Length = ToUser(((k * Fontsize / 1000) + _
			 (j * mvarWordSpacing) + _
			 (l * mvarCharSpacing)) * _
			 (mvarTextScaling / 100))
        Else
            Length = 0
        End If
    End Function


	Private Function ToASCII85(ByRef InBuf() As Byte) As String

		Dim i As Byte

		Dim m As Double
		Dim q As Int32
		Dim l As Int32
		Dim k As Int32
		Dim j As Int32
		Dim lngLen As Int32

		Dim arrASCII() As Byte

		lngLen = UBound(InBuf)

		ReDim arrASCII(CInt(lngLen * 1.3) + 1)

		k = 1
		j = 1
		While k <= lngLen
			l = (lngLen - k) + 1
			m = 0

			For i = 1 To 4
				If i > l Then Exit For
				m = m + InBuf(k + i - 1) * (256 ^ (4 - i))
			Next

			If (m = 0) And (l = 4) Then
				arrASCII(j) = Asc("z")
				j = j + 1
			Else

				For i = 1 To 4
					q = Int(m / 85 ^ (5 - i))
					m = m - q * (85 ^ (5 - i))
					arrASCII(j + i - 1) = 33 + q
				Next

				arrASCII(j + 5 - 1) = 33 + m
				j = j + IIf(l < 4, l + 1, 5)
			End If

			k = k + 4
		End While

		ReDim Preserve arrASCII(j)

		ToASCII85 = StrConv(arrASCII) & "~>"
	End Function

	'
	Private Function LeggeBMP(FileName As String, _
	 ByRef ImgBuf() As Byte, _
	 ByRef ImgColor() As Byte, _
	 ByRef ImgWidth As Int32, _
	 ByRef ImgHeight As Int32, _
	 ByRef ImgBPP As Byte, _
	Optional ColorSpace As pdfColorSpace = pdfColorSpace.pdfRGB) As Boolean

		' BITMAPFILEHEADER_Type
		Dim bfType(1) As Byte		 ' The string ?BM? (hex value &H424D).
		Dim bfSize As Int32		  ' The size of the file, measured in [Bytes].
		Dim bfDummy As Int16		  ' Not used, set to zero.
		Dim bfOffBits As Int32		 ' The start offset of the bitmap data in the file.

		' BITMAPINFOHEADER
		Dim biSize As Int32		  ' 40 (the size of this structure).
		Dim biWidth As Int32		 ' The width of the bitmap in pixels.
		Dim biHeight As Int32		  ' The height of the bitmap in pixels.
		Dim biPlanes As Int16		 ' 1 (DIBs always have one plane).
		Dim biBitCount As Int16		 ' 1 for monochrome, 4 for 16 colors, 8 for 256 color, 24 for 24-bit RGB color.
		Dim biCompression As Int32		 ' Specifies the type of compression for compressed
		Dim biSizeImage As Int32		 ' The size of the image in bytes.
		Dim biXPelsPerMeter As Int32		 ' Number of horizontal pixels per meter for
		Dim biYPelsPerMeter As Int32		 ' Number of vertical pixels per meter for
		Dim biClrUsed As Int32		 ' Number of entries in the DIB color table
		Dim biClrImportant As Int32		  ' Number of entries in the DIB color table that


		Dim C As Int32
		Dim fb As Int16
		Dim XBMP As Int32
		Dim BPP As Byte
		Dim i As Int32
		Dim kk As Int32
		Dim blnFlag As Boolean
		Dim TempImg() As Byte
		Dim TempCol() As Byte		 ' RGBQUAD_Type
		Dim lngGray As Int32

		fb = FreeFile()
		FileOpen(fb, FileName, OpenMode.Binary)

		' BITMAPFILEHEADER
		FileGet(fb, bfType)
		FileGet(fb, bfSize)
		FileGet(fb, bfDummy)
		FileGet(fb, bfDummy)
		FileGet(fb, bfOffBits)

		LeggeBMP = False

		If System.Text.Encoding.ASCII.GetString(bfType) = "BM" Then

			' BITMAPINFOHEADER
			FileGet(fb, biSize)
			FileGet(fb, biWidth)
			FileGet(fb, biHeight)
			FileGet(fb, biPlanes)
			FileGet(fb, biBitCount)
			FileGet(fb, biCompression)
			FileGet(fb, biSizeImage)
			FileGet(fb, biXPelsPerMeter)
			FileGet(fb, biYPelsPerMeter)
			FileGet(fb, biClrUsed)
			FileGet(fb, biClrImportant)


			BPP = biBitCount

			If BPP <= 8 Then

				' legge la palette di colori
				'get the correct amount of bytes
				ReDim TempCol(((2 ^ BPP) * 4) - 1)
				FileGet(fb, TempCol)
				'shift to 1-based
				ReDim Preserve TempCol((2 ^ BPP) * 4)
				For j As Integer = TempCol.Length - 1 To 1 Step -1
					TempCol(j) = TempCol(j - 1)
				Next

				If ColorSpace = pdfColorSpace.pdfRGB Then
					ReDim ImgColor(3 * (2 ^ BPP))
					For C = 0 To (2 ^ BPP) - 1
						ImgColor(C * 3 + 1) = TempCol(C * 4 + 1)						 ' red
						ImgColor(C * 3 + 2) = TempCol(C * 4 + 2)						 ' green
						ImgColor(C * 3 + 3) = TempCol(C * 4 + 3)						 ' blue
					Next
				Else
					ReDim ImgColor((2 ^ BPP))
					For C = 0 To (2 ^ BPP) - 1
						lngGray = (0.33 * TempCol(C * 4 + 1) + 0.59 * TempCol(C * 4 + 2) + 0.11 * TempCol(C * 4 + 3))
						ImgColor(C + 1) = IIf(lngGray > 255, 255, lngGray)
					Next
				End If
			End If

			XBMP = ((biWidth * BPP / 8) + 3&) And &HFFFFFFFC			 ' [Bytes].

			ImgWidth = biWidth
			ImgHeight = biHeight
			ImgBPP = CByte(biBitCount)

			ReDim TempImg(biHeight * XBMP - 1)
			FileGet(fb, TempImg, bfOffBits + 1)
			FileClose(fb) : fb = 0
			ReDim Preserve TempImg(biHeight * XBMP)
			For j As Integer = TempImg.Length - 1 To 1 Step -1
				TempImg(j) = TempImg(j - 1)
			Next

			ReDim ImgBuf(biHeight * XBMP)
			kk = 0

			If BPP > 8 Then
				blnFlag = ((biWidth Mod 4) <> 0)

				If ColorSpace = pdfColorSpace.pdfRGB Then
					For C = 1 To UBound(TempImg) - 1 Step 3
						ImgBuf(3 * kk + 1) = TempImg(C + 2)
						ImgBuf(3 * kk + 2) = TempImg(C + 1)
						ImgBuf(3 * kk + 3) = TempImg(C)
						If (((kk + 1) Mod biWidth) = 0) And blnFlag Then C = C + (biWidth Mod 4)
						kk = kk + 1
					Next

				Else
					For C = 1 To UBound(TempImg) - 1 Step 3
						lngGray = 0.33 * TempImg(C + 2) + 0.59 * TempImg(C + 1) + 0.11 * TempImg(C)
						ImgBuf(kk + 1) = IIf(lngGray > 255, 255, lngGray)
						If (((kk + 1) Mod biWidth) = 0) And blnFlag Then C = C + (biWidth Mod 4)
						kk = kk + 1
					Next
					ReDim Preserve ImgBuf(kk)

				End If

			ElseIf BPP <= 8 Then
				blnFlag = (biWidth Mod IIf(BPP = 8, 4, 8)) <> 0
				For i = 1 To UBound(TempImg)
					ImgBuf(kk + 1) = TempImg(i)
					If ((kk + 1) Mod Int((biWidth + (8 / BPP) - 1) / (8 / BPP))) = 0 And blnFlag Then
						i = i + (XBMP - (i Mod XBMP))
					End If
					kk = kk + 1
				Next
				ReDim Preserve ImgBuf(kk)

			End If

			LeggeBMP = True
		End If

		If fb > 0 Then FileClose(fb) : fb = 0
	End Function

	Private Function ToPdfStr(Temp As String) As String
		ToPdfStr = Replace(Replace(Replace(Temp, "\", "\\"), "(", "\("), ")", "\)")
	End Function

	Private Function CreateFontCourier(Style As pdfFontStyle) As FontDescriptor
		Dim i As Int16
		Dim awTemp() As Int16 = Nothing
		Dim fdTemp As New FontDescriptor

		' Courier New
		With fdTemp
			.BaseFont = "CourierNew"
			.FirstChar = 32
			.LastChar = 255
			.MissingWidth = 600
		End With

		Select Case Style
			Case pdfFontStyle.pdfNormal
				awTemp = New Int16() {0, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, _
				600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, _
				600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, _
				600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600}
				fdTemp.Param = "/Flags 34 /FontBBox [-250 -300 720 1000] " & _
				 "/MissingWidth 600 /StemV 109 " & _
				 "/StemH 109 /ItalicAngle 0 /CapHeight 833 /XHeight 417 " & _
				 "/Ascent 833 /Descent -300 /Leading 133 " & _
				 "/MaxWidth 600 /AvgWidth 600"

			Case pdfFontStyle.pdfBold
				fdTemp.BaseFont = fdTemp.BaseFont & ",Bold"
				awTemp = New Int16() {0, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, _
				600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, _
				600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, _
				600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600}
				fdTemp.Param = "/Flags 16418 /FontBBox [-250 -300 720 1000] " & _
				 "/MissingWidth 600 /StemV 191 " & _
				 "/StemH 191 /ItalicAngle 0 /CapHeight 833 /XHeight 417 " & _
				 "/Ascent 833 /Descent -300 /Leading 133 " & _
				 "/MaxWidth 600 /AvgWidth 600"

			Case pdfFontStyle.pdfItalic
				fdTemp.BaseFont = fdTemp.BaseFont & ",Italic"
				awTemp = New Int16() {0, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, _
				600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, _
				600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, _
				600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600}
				fdTemp.Param = "/Flags 98 /FontBBox [-250 -300 720 1000] " & _
				 "/MissingWidth 600 /StemV 109 " & _
				 "/StemH 109 /ItalicAngle -11 /CapHeight 833 /XHeight 417 " & _
				 "/Ascent 833 /Descent -300 /Leading 133 " & _
				 "/MaxWidth 600 /AvgWidth 600"

			Case pdfFontStyle.pdfBoldItalic
				fdTemp.BaseFont = fdTemp.BaseFont & ",BoldItalic"
				awTemp = New Int16() {0, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, _
				600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, _
				600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, _
				600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600}
				fdTemp.Param = "/Flags 16482 /FontBBox [-250 -300 720 1000] " & _
				 "/MissingWidth 600 /StemV 191 " & _
				 "/StemH 191 /ItalicAngle -11 /CapHeight 833 /XHeight 417 " & _
				 "/Ascent 833 /Descent -300 /Leading 133 " & _
				 "/MaxWidth 600 /AvgWidth 600"
		End Select

		For i = fdTemp.FirstChar To fdTemp.LastChar
			fdTemp.Widths(i) = awTemp(i - fdTemp.FirstChar + 1)
		Next

		CreateFontCourier = fdTemp
	End Function

	Private Function CreateFontTimes(Style As pdfFontStyle) As FontDescriptor
		Dim i As Int16
		Dim awTemp() As Int16 = Nothing
		Dim fdTemp As New FontDescriptor

		' Times New Roman
		With fdTemp
			.BaseFont = "TimesNewRoman"
			.FirstChar = 32
			.LastChar = 255
			.MissingWidth = 333

		End With

		Select Case Style
			Case pdfFontStyle.pdfNormal
				awTemp = New Int16() {0, 250, 333, 408, 500, 500, 833, 778, 180, 333, 333, 500, 564, 250, 333, 250, 278, 500, 500, 500, 500, 500, 500, 500, 500, 500, 500, 278, 278, 564, 564, 564, 444, 921, 722, 667, 667, 722, 611, 556, 722, 722, 333, 389, 722, 611, 889, 722, 722, 556, 722, 667, 556, 611, 722, 722, 944, 722, 722, 611, 333, 278, 333, 469, 500, _
				 333, 444, 500, 444, 500, 444, 333, 500, 500, 278, 278, 500, 278, 778, 500, 500, 500, 500, 333, 389, 278, 500, 500, 722, 500, 500, 444, 480, 200, 480, 541, 778, 500, 778, 333, 500, 444, 1000, 500, 500, 333, 1000, 556, 333, 889, 778, 611, 778, 778, 333, 333, 444, 444, 350, 500, 1000, 333, 980, 389, 333, 722, 778, 444, 722, _
				 250, 333, 500, 500, 500, 500, 200, 500, 333, 760, 276, 500, 564, 333, 760, 500, 400, 549, 300, 300, 333, 576, 453, 250, 333, 300, 310, 500, 750, 750, 750, 444, 722, 722, 722, 722, 722, 722, 889, 667, 611, 611, 611, 611, 333, 333, 333, 333, 722, 722, 722, 722, 722, 722, 722, 564, 722, 722, 722, 722, 722, 722, 556, 500, _
				 444, 444, 444, 444, 444, 444, 667, 444, 444, 444, 444, 444, 278, 278, 278, 278, 500, 500, 500, 500, 500, 500, 500, 549, 500, 500, 500, 500, 500, 500, 500, 500}
				fdTemp.Param = "/Flags 34 /FontBBox [-250 -216 1200 1000] " & _
				 "/MissingWidth 333 /StemV 73 " & _
				 "/StemH 73 /ItalicAngle 0 /CapHeight 891 /XHeight 446 " & _
				 "/Ascent 891 /Descent -216 /Leading 149 " & _
				 "/MaxWidth 1000 /AvgWidth 401"

			Case pdfFontStyle.pdfBold
				fdTemp.BaseFont = fdTemp.BaseFont & ",Bold"
				awTemp = New Int16() {0, 250, 333, 555, 500, 500, 1000, 833, 278, 333, 333, 500, 570, 250, 333, 250, 278, 500, 500, 500, 500, 500, 500, 500, 500, 500, 500, 333, 333, 570, 570, 570, 500, 930, 722, 667, 722, 722, 667, 611, 778, 778, 389, 500, 778, 667, 944, 722, 778, 611, 778, 722, 556, 667, 722, 722, 1000, 722, 722, 667, 333, 278, 333, 581, 500, _
				 333, 500, 556, 444, 556, 444, 333, 500, 556, 278, 333, 556, 278, 833, 556, 500, 556, 556, 444, 389, 333, 556, 500, 722, 500, 500, 444, 394, 220, 394, 520, 778, 500, 778, 333, 500, 500, 1000, 500, 500, 333, 1000, 556, 333, 1000, 778, 667, 778, 778, 333, 333, 500, 500, 350, 500, 1000, 333, 1000, 389, 333, 722, 778, 444, 722, _
				 250, 333, 500, 500, 500, 500, 220, 500, 333, 747, 300, 500, 570, 333, 747, 500, 400, 549, 300, 300, 333, 576, 540, 250, 333, 300, 330, 500, 750, 750, 750, 500, 722, 722, 722, 722, 722, 722, 1000, 722, 667, 667, 667, 667, 389, 389, 389, 389, 722, 722, 778, 778, 778, 778, 778, 570, 778, 722, 722, 722, 722, 722, 611, 556, _
				 500, 500, 500, 500, 500, 500, 722, 444, 444, 444, 444, 444, 278, 278, 278, 278, 500, 556, 500, 500, 500, 500, 500, 549, 500, 556, 556, 556, 556, 500, 556, 500}
				fdTemp.Param = "/Flags 16418 /FontBBox [-250 -216 1201 1000] " & _
				 "/MissingWidth 333 /StemV 136 " & _
				 "/StemH 136 /ItalicAngle 0 /CapHeight 891 /XHeight 446 " & _
				 "/Ascent 891 /Descent -216 /Leading 149 " & _
				 "/MaxWidth 1001 /AvgWidth 401"

			Case pdfFontStyle.pdfItalic
				fdTemp.BaseFont = fdTemp.BaseFont & ",Italic"
				awTemp = New Int16() {0, 250, 333, 420, 500, 500, 833, 778, 214, 333, 333, 500, 675, 250, 333, 250, 278, 500, 500, 500, 500, 500, 500, 500, 500, 500, 500, 333, 333, 675, 675, 675, 500, 920, 611, 611, 667, 722, 611, 611, 722, 722, 333, 444, 667, 556, 833, 667, 722, 611, 722, 611, 500, 556, 722, 611, 833, 611, 556, 556, 389, 278, 389, 422, 500, _
				 333, 500, 500, 444, 500, 444, 278, 500, 500, 278, 278, 444, 278, 722, 500, 500, 500, 500, 389, 389, 278, 500, 444, 667, 444, 444, 389, 400, 275, 400, 541, 778, 500, 778, 333, 500, 556, 889, 500, 500, 333, 1000, 500, 333, 944, 778, 556, 778, 778, 333, 333, 556, 556, 350, 500, 889, 333, 980, 389, 333, 667, 778, 389, 556, _
				 250, 389, 500, 500, 500, 500, 275, 500, 333, 760, 276, 500, 675, 333, 760, 500, 400, 549, 300, 300, 333, 576, 523, 250, 333, 300, 310, 500, 750, 750, 750, 500, 611, 611, 611, 611, 611, 611, 889, 667, 611, 611, 611, 611, 333, 333, 333, 333, 722, 667, 722, 722, 722, 722, 722, 675, 722, 722, 722, 722, 722, 556, 611, 500, _
				 500, 500, 500, 500, 500, 500, 667, 444, 444, 444, 444, 444, 278, 278, 278, 278, 500, 500, 500, 500, 500, 500, 500, 549, 500, 500, 500, 500, 500, 444, 500, 444}
				fdTemp.Param = "/Flags 98 /FontBBox [-250 -216 1200 1000] " & _
				 "/MissingWidth 333 /StemV 73 " & _
				 "/StemH 73 /ItalicAngle -11 /CapHeight 891 /XHeight 446 " & _
				 "/Ascent 891 /Descent -216 /Leading 149 " & _
				 "/MaxWidth 1000 /AvgWidth 402"

			Case pdfFontStyle.pdfBoldItalic
				fdTemp.BaseFont = fdTemp.BaseFont & ",BoldItalic"
				awTemp = New Int16() {0, 250, 389, 555, 500, 500, 833, 778, 278, 333, 333, 500, 570, 250, 333, 250, 278, 500, 500, 500, 500, 500, 500, 500, 500, 500, 500, 333, 333, 570, 570, 570, 500, 832, 667, 667, 667, 722, 667, 667, 722, 778, 389, 500, 667, 611, 889, 722, 722, 611, 722, 667, 556, 611, 722, 667, 889, 667, 611, 611, 333, 278, 333, 570, 500, _
				 333, 500, 500, 444, 500, 444, 333, 500, 556, 278, 278, 500, 278, 778, 556, 500, 500, 500, 389, 389, 278, 556, 444, 667, 500, 444, 389, 348, 220, 348, 570, 778, 500, 778, 333, 500, 500, 1000, 500, 500, 333, 1000, 556, 333, 944, 778, 611, 778, 778, 333, 333, 500, 500, 350, 500, 1000, 333, 1000, 389, 333, 722, 778, 389, 611, _
				 250, 389, 500, 500, 500, 500, 220, 500, 333, 747, 266, 500, 606, 333, 747, 500, 400, 549, 300, 300, 333, 576, 500, 250, 333, 300, 300, 500, 750, 750, 750, 500, 667, 667, 667, 667, 667, 667, 944, 667, 667, 667, 667, 667, 389, 389, 389, 389, 722, 722, 722, 722, 722, 722, 722, 570, 722, 722, 722, 722, 722, 611, 611, 500, _
				 500, 500, 500, 500, 500, 500, 722, 444, 444, 444, 444, 444, 278, 278, 278, 278, 500, 556, 500, 500, 500, 500, 500, 549, 500, 556, 556, 556, 556, 444, 500, 444}
				fdTemp.Param = "/Flags 16482 /FontBBox [-250 -216 1200 1000] " & _
				 "/MissingWidth 333 /StemV 131 " & _
				 "/StemH 131 /ItalicAngle -11 /CapHeight 891 /XHeight 446 " & _
				 "/Ascent 891 /Descent -216 /Leading 149 " & _
				 "/MaxWidth 1000 /AvgWidth 412"
		End Select

		For i = fdTemp.FirstChar To fdTemp.LastChar
			fdTemp.Widths(i) = awTemp(i - fdTemp.FirstChar + 1)
		Next

		CreateFontTimes = fdTemp

	End Function


	Private Function CreateFontSymbol(Style As pdfFontStyle) As FontDescriptor
		Dim i As Int16
		Dim awTemp() As Int16 = Nothing
		Dim fdTemp As New FontDescriptor

		' Symbol
		With fdTemp
			.BaseFont = "Symbol"
			.FirstChar = 30
			.LastChar = 255
			.MissingWidth = 332
		End With

		Select Case Style
			Case pdfFontStyle.pdfNormal
				awTemp = New Int16() {0, 600, 600, 250, 333, 713, 500, 549, 833, 778, 439, 333, 333, 500, 549, 250, 549, 250, 278, 500, 500, 500, 500, 500, 500, 500, 500, 500, 500, 278, 278, 549, 549, 549, 444, 549, 722, 667, 722, 612, 611, 763, 603, 722, 333, 631, 722, 686, 889, 722, 722, 768, 741, 556, 592, 611, 690, 439, 768, 645, 795, 611, 333, 863, 333, _
				 658, 500, 500, 631, 549, 549, 494, 439, 521, 411, 603, 329, 603, 549, 549, 576, 521, 549, 549, 521, 549, 603, 439, 576, 713, 686, 493, 686, 494, 480, 200, 480, 549, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, _
				 600, 600, 600, 620, 247, 549, 167, 713, 500, 753, 753, 753, 753, 1042, 987, 603, 987, 603, 400, 549, 411, 549, 549, 713, 494, 460, 549, 549, 549, 549, 1000, 603, 1000, 658, 823, 686, 795, 987, 768, 768, 823, 768, 768, 713, 713, 713, 713, 713, 713, 713, 768, 713, 790, 790, 890, 823, 549, 250, 713, 603, 603, 1042, 987, 603, _
				 987, 603, 494, 329, 790, 790, 786, 713, 384, 384, 384, 384, 384, 384, 494, 494, 494, 494, 600, 329, 274, 686, 686, 686, 384, 384, 384, 384, 384, 384, 494, 494, 494, 600}
				fdTemp.Param = "/Flags 6 /FontBBox [-250 -220 1246 1005] " & _
				 "/MissingWidth 332 /StemV 109 " & _
				 "/StemH 109 /ItalicAngle 0 /CapHeight 1005 /XHeight 503 " & _
				 "/Ascent 1005 /Descent -220 /Leading 225 " & _
				 "/MaxWidth 1038 /AvgWidth 601"

			Case pdfFontStyle.pdfBold
				fdTemp.BaseFont = fdTemp.BaseFont & ",Bold"
				awTemp = New Int16() {0, 600, 600, 250, 333, 713, 500, 549, 833, 778, 439, 333, 333, 500, 549, 250, 549, 250, 278, 500, 500, 500, 500, 500, 500, 500, 500, 500, 500, 278, 278, 549, 549, 549, 444, 549, 722, 667, 722, 612, 611, 763, 603, 722, 333, 631, 722, 686, 889, 722, 722, 768, 741, 556, 592, 611, 690, 439, 768, 645, 795, 611, 333, 863, 333, _
				 658, 500, 500, 631, 549, 549, 494, 439, 521, 411, 603, 329, 603, 549, 549, 576, 521, 549, 549, 521, 549, 603, 439, 576, 713, 686, 493, 686, 494, 480, 200, 480, 549, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, _
				 600, 600, 600, 620, 247, 549, 167, 713, 500, 753, 753, 753, 753, 1042, 987, 603, 987, 603, 400, 549, 411, 549, 549, 713, 494, 460, 549, 549, 549, 549, 1000, 603, 1000, 658, 823, 686, 795, 987, 768, 768, 823, 768, 768, 713, 713, 713, 713, 713, 713, 713, 768, 713, 790, 790, 890, 823, 549, 250, 713, 603, 603, 1042, 987, 603, _
				 987, 603, 494, 329, 790, 790, 786, 713, 384, 384, 384, 384, 384, 384, 494, 494, 494, 494, 600, 329, 274, 686, 686, 686, 384, 384, 384, 384, 384, 384, 494, 494, 494, 600}
				fdTemp.Param = "/Flags 16390 /FontBBox [-250 -220 1246 1005] " & _
				 "/MissingWidth 332 /StemV 191 " & _
				 "/StemH 191 /ItalicAngle 0 /CapHeight 1005 /XHeight 503 " & _
				 "/Ascent 1005 /Descent -220 /Leading 225 " & _
				 "/MaxWidth 1038 /AvgWidth 600"

			Case pdfFontStyle.pdfItalic
				fdTemp.BaseFont = fdTemp.BaseFont & ",Italic"
				awTemp = New Int16() {0, 600, 600, 250, 333, 713, 500, 549, 833, 778, 439, 333, 333, 500, 549, 250, 549, 250, 278, 500, 500, 500, 500, 500, 500, 500, 500, 500, 500, 278, 278, 549, 549, 549, 444, 549, 722, 667, 722, 612, 611, 763, 603, 722, 333, 631, 722, 686, 889, 722, 722, 768, 741, 556, 592, 611, 690, 439, 768, 645, 795, 611, 333, 863, 333, _
				 658, 500, 500, 631, 549, 549, 494, 439, 521, 411, 603, 329, 603, 549, 549, 576, 521, 549, 549, 521, 549, 603, 439, 576, 713, 686, 493, 686, 494, 480, 200, 480, 549, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, _
				 600, 600, 600, 620, 247, 549, 167, 713, 500, 753, 753, 753, 753, 1042, 987, 603, 987, 603, 400, 549, 411, 549, 549, 713, 494, 460, 549, 549, 549, 549, 1000, 603, 1000, 658, 823, 686, 795, 987, 768, 768, 823, 768, 768, 713, 713, 713, 713, 713, 713, 713, 768, 713, 790, 790, 890, 823, 549, 250, 713, 603, 603, 1042, 987, 603, _
				 987, 603, 494, 329, 790, 790, 786, 713, 384, 384, 384, 384, 384, 384, 494, 494, 494, 494, 600, 329, 274, 686, 686, 686, 384, 384, 384, 384, 384, 384, 494, 494, 494, 600}
				fdTemp.Param = "/Flags 70 /FontBBox [-250 -220 1246 1005] " & _
				 "/MissingWidth 332 /StemV 109 " & _
				 "/StemH 109 /ItalicAngle -11 /CapHeight 1005 /XHeight 503 " & _
				 "/Ascent 1005 /Descent -220 /Leading 225 " & _
				 "/MaxWidth 1038 /AvgWidth 600"

			Case pdfFontStyle.pdfBoldItalic
				fdTemp.BaseFont = fdTemp.BaseFont & ",BoldItalic"
				awTemp = New Int16() {0, 600, 600, 250, 333, 713, 500, 549, 833, 778, 439, 333, 333, 500, 549, 250, 549, 250, 278, 500, 500, 500, 500, 500, 500, 500, 500, 500, 500, 278, 278, 549, 549, 549, 444, 549, 722, 667, 722, 612, 611, 763, 603, 722, 333, 631, 722, 686, 889, 722, 722, 768, 741, 556, 592, 611, 690, 439, 768, 645, 795, 611, 333, 863, 333, _
				 658, 500, 500, 631, 549, 549, 494, 439, 521, 411, 603, 329, 603, 549, 549, 576, 521, 549, 549, 521, 549, 603, 439, 576, 713, 686, 493, 686, 494, 480, 200, 480, 549, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, 600, _
				 600, 600, 600, 620, 247, 549, 167, 713, 500, 753, 753, 753, 753, 1042, 987, 603, 987, 603, 400, 549, 411, 549, 549, 713, 494, 460, 549, 549, 549, 549, 1000, 603, 1000, 658, 823, 686, 795, 987, 768, 768, 823, 768, 768, 713, 713, 713, 713, 713, 713, 713, 768, 713, 790, 790, 890, 823, 549, 250, 713, 603, 603, 1042, 987, 603, _
				 987, 603, 494, 329, 790, 790, 786, 713, 384, 384, 384, 384, 384, 384, 494, 494, 494, 494, 600, 329, 274, 686, 686, 686, 384, 384, 384, 384, 384, 384, 494, 494, 494, 600}
				fdTemp.Param = "/Flags 16454 /FontBBox [-250 -220 1246 1005] " & _
				 "/MissingWidth 332 /StemV 191 " & _
				 "/StemH 191 /ItalicAngle -11 /CapHeight 1005 /XHeight 503 " & _
				 "/Ascent 1005 /Descent -220 /Leading 225 " & _
				 "/MaxWidth 1038 /AvgWidth 600"
		End Select

		For i = fdTemp.FirstChar To fdTemp.LastChar
			fdTemp.Widths(i) = awTemp(i - fdTemp.FirstChar + 1)
		Next

		CreateFontSymbol = fdTemp

	End Function


	Private Function CreateFontArial(Style As pdfFontStyle) As FontDescriptor
		Dim i As Int16
		Dim awTemp() As Int16 = Nothing
		Dim fdTemp As New FontDescriptor

		' Arial
		With fdTemp
			.BaseFont = "Arial"
			.FirstChar = 32
			.LastChar = 255
			.MissingWidth = 272
		End With

		Select Case Style
			Case pdfFontStyle.pdfNormal
				awTemp = New Int16() {0, 278, 278, 355, 556, 556, 889, 667, 191, 333, 333, 389, 584, 278, 333, 278, 278, 556, 556, 556, 556, 556, 556, 556, 556, 556, 556, 278, 278, 584, 584, 584, 556, 1015, 667, 667, 722, 722, 667, 611, 778, 722, 278, 500, 667, 556, 833, 722, 778, 667, 778, 722, 667, 611, 722, 667, 944, 667, 667, 611, 278, 278, 278, 469, 556, _
				 333, 556, 556, 500, 556, 556, 278, 556, 556, 222, 222, 500, 222, 833, 556, 556, 556, 556, 333, 500, 278, 556, 500, 722, 500, 500, 500, 334, 260, 334, 584, 750, 556, 750, 222, 556, 333, 1000, 556, 556, 333, 1000, 667, 333, 1000, 750, 611, 750, 750, 222, 222, 333, 333, 350, 556, 1000, 333, 1000, 500, 333, 944, 750, 500, 667, _
				 278, 333, 556, 556, 556, 556, 260, 556, 333, 737, 370, 556, 584, 333, 737, 552, 400, 549, 333, 333, 333, 576, 537, 278, 333, 333, 365, 556, 834, 834, 834, 611, 667, 667, 667, 667, 667, 667, 1000, 722, 667, 667, 667, 667, 278, 278, 278, 278, 722, 722, 778, 778, 778, 778, 778, 584, 778, 722, 722, 722, 722, 667, 667, 611, _
				 556, 556, 556, 556, 556, 556, 889, 500, 556, 556, 556, 556, 278, 278, 278, 278, 556, 556, 556, 556, 556, 556, 556, 549, 611, 556, 556, 556, 556, 500, 556, 500}
				fdTemp.Param = "/Flags 32 /FontBBox [-250 -221 1190 1000] " & _
				 "/MissingWidth 272 /StemV 80 " & _
				 "/StemH 80 /ItalicAngle 0 /CapHeight 905 /XHeight 453 " & _
				 "/Ascent 905 /Descent -212 /Leading 150 " & _
				 "/MaxWidth 992 /AvgWidth 441"

			Case pdfFontStyle.pdfBold
				fdTemp.BaseFont = fdTemp.BaseFont & ",Bold"
				awTemp = New Int16() {0, 278, 333, 474, 556, 556, 889, 722, 238, 333, 333, 389, 584, 278, 333, 278, 278, 556, 556, 556, 556, 556, 556, 556, 556, 556, 556, 333, 333, 584, 584, 584, 611, 975, 722, 722, 722, 722, 667, 611, 778, 722, 278, 556, 722, 611, 833, 722, 778, 667, 778, 722, 667, 611, 722, 667, 944, 667, 667, 611, 333, 278, 333, 584, 556, _
				 333, 556, 611, 556, 611, 556, 333, 611, 611, 278, 278, 556, 278, 889, 611, 611, 611, 611, 389, 556, 333, 611, 556, 778, 556, 556, 500, 389, 280, 389, 584, 750, 556, 750, 278, 556, 500, 1000, 556, 556, 333, 1000, 667, 333, 1000, 750, 611, 750, 750, 278, 278, 500, 500, 350, 556, 1000, 333, 1000, 556, 333, 944, 750, 500, 667, _
				 278, 333, 556, 556, 556, 556, 280, 556, 333, 737, 370, 556, 584, 333, 737, 552, 400, 549, 333, 333, 333, 576, 556, 278, 333, 333, 365, 556, 834, 834, 834, 611, 722, 722, 722, 722, 722, 722, 1000, 722, 667, 667, 667, 667, 278, 278, 278, 278, 722, 722, 778, 778, 778, 778, 778, 584, 778, 722, 722, 722, 722, 667, 667, 611, _
				 556, 556, 556, 556, 556, 556, 889, 556, 556, 556, 556, 556, 278, 278, 278, 278, 611, 611, 611, 611, 611, 611, 611, 549, 611, 611, 611, 611, 611, 556, 611, 556}
				fdTemp.Param = "/Flags 16416 /FontBBox [-250 -212 1120 1000] " & _
				 "/MissingWidth 311 /StemV 153 " & _
				 "/StemH 153 /ItalicAngle 0 /CapHeight 905 /XHeight 453 " & _
				 "/Ascent 905 /Descent -212 /Leading 150 " & _
				 "/MaxWidth 933 /AvgWidth 479"
				fdTemp.MissingWidth = 311


			Case pdfFontStyle.pdfItalic
				fdTemp.BaseFont = fdTemp.BaseFont & ",Italic"
				awTemp = New Int16() {0, 278, 278, 355, 556, 556, 889, 667, 191, 333, 333, 389, 584, 278, 333, 278, 278, 556, 556, 556, 556, 556, 556, 556, 556, 556, 556, 278, 278, 584, 584, 584, 556, 1015, 667, 667, 722, 722, 667, 611, 778, 722, 278, 500, 667, 556, 833, 722, 778, 667, 778, 722, 667, 611, 722, 667, 944, 667, 667, 611, 278, 278, 278, 469, 556, _
				 333, 556, 556, 500, 556, 556, 278, 556, 556, 222, 222, 500, 222, 833, 556, 556, 556, 556, 333, 500, 278, 556, 500, 722, 500, 500, 500, 334, 260, 334, 584, 750, 556, 750, 222, 556, 333, 1000, 556, 556, 333, 1000, 667, 333, 1000, 750, 611, 750, 750, 222, 222, 333, 333, 350, 556, 1000, 333, 1000, 500, 333, 944, 750, 500, 667, _
				 278, 333, 556, 556, 556, 556, 260, 556, 333, 737, 370, 556, 584, 333, 737, 552, 400, 549, 333, 333, 333, 576, 537, 278, 333, 333, 365, 556, 834, 834, 834, 611, 667, 667, 667, 667, 667, 667, 1000, 722, 667, 667, 667, 667, 278, 278, 278, 278, 722, 722, 778, 778, 778, 778, 778, 584, 778, 722, 722, 722, 722, 667, 667, 611, _
				 556, 556, 556, 556, 556, 556, 889, 500, 556, 556, 556, 556, 278, 278, 278, 278, 556, 556, 556, 556, 556, 556, 556, 549, 611, 556, 556, 556, 556, 500, 556, 500}
				fdTemp.Param = "/Flags 96 /FontBBox [-250 -212 1134 1000] " & _
				 "/MissingWidth 259 /StemV 80 " & _
				 "/StemH 80 /ItalicAngle -11 /CapHeight 905 /XHeight 453 " & _
				 "/Ascent 905 /Descent -212 /Leading 150 " & _
				 "/MaxWidth 945 /AvgWidth 441"
				fdTemp.MissingWidth = 259

			Case pdfFontStyle.pdfBoldItalic
				fdTemp.BaseFont = fdTemp.BaseFont & ",BoldItalic"
				awTemp = New Int16() {0, 278, 333, 474, 556, 556, 889, 722, 238, 333, 333, 389, 584, 278, 333, 278, 278, 556, 556, 556, 556, 556, 556, 556, 556, 556, 556, 333, 333, 584, 584, 584, 611, 975, 722, 722, 722, 722, 667, 611, 778, 722, 278, 556, 722, 611, 833, 722, 778, 667, 778, 722, 667, 611, 722, 667, 944, 667, 667, 611, 333, 278, 333, 584, 556, _
				 333, 556, 611, 556, 611, 556, 333, 611, 611, 278, 278, 556, 278, 889, 611, 611, 611, 611, 389, 556, 333, 611, 556, 778, 556, 556, 500, 389, 280, 389, 584, 750, 556, 750, 278, 556, 500, 1000, 556, 556, 333, 1000, 667, 333, 1000, 750, 611, 750, 750, 278, 278, 500, 500, 350, 556, 1000, 333, 1000, 556, 333, 944, 750, 500, 667, _
				 278, 333, 556, 556, 556, 556, 280, 556, 333, 737, 370, 556, 584, 333, 737, 552, 400, 549, 333, 333, 333, 576, 556, 278, 333, 333, 365, 556, 834, 834, 834, 611, 722, 722, 722, 722, 722, 722, 1000, 722, 667, 667, 667, 667, 278, 278, 278, 278, 722, 722, 778, 778, 778, 778, 778, 584, 778, 722, 722, 722, 722, 667, 667, 611, _
				 556, 556, 556, 556, 556, 556, 889, 556, 556, 556, 556, 556, 278, 278, 278, 278, 611, 611, 611, 611, 611, 611, 611, 549, 611, 611, 611, 611, 611, 556, 611, 556}
				fdTemp.Param = "/Flags 16480 /FontBBox [-250 -212 1120 1000] " & _
				 "/MissingWidth 311 /StemV 153 " & _
				 "/StemH 153 /ItalicAngle -11 /CapHeight 905 /XHeight 453 " & _
				 "/Ascent 905 /Descent -212 /Leading 150 " & _
				 "/MaxWidth 933 /AvgWidth 479"
				fdTemp.MissingWidth = 311
		End Select

		For i = fdTemp.FirstChar To fdTemp.LastChar
			fdTemp.Widths(i) = awTemp(i - fdTemp.FirstChar + 1)
		Next

		CreateFontArial = fdTemp

	End Function

	' Verifica se ci sono oggetti comuni da inserire sulla pagina
	Private Sub InsertObjectOnPage()
		Dim i As Int16

		If intObject > 0 Then
			For i = 1 To intObject
				With arrOBJECT(i)
					If (((.Options And pdfObjectType.pdfAllPages) = pdfObjectType.pdfAllPages) Or _
					 (((.Options And pdfObjectType.pdfEvenPages) <> 0) And ((mvarPages Mod 2) = 0)) Or _
					 (((.Options And pdfObjectType.pdfOddPages) <> 0) And ((mvarPages Mod 2) <> 0)) And (Not _
					 (((.Options And pdfObjectType.pdfNotFirstPage) <> 0) And (mvarPages = 1)))) Then
						DrawObject(.Name)
					End If
				End With
			Next
		End If
	End Sub
End Class
