Imports System.Xml
Imports System.Text
Imports System.IO

Public Class PaginaNews

    Private mRssNodes As XmlNodeList

    Sub New(Url As String, ForzaApertura As Boolean)
        Try
            If ForzaApertura = True Then
                mDataFlag = #1/1/2014#
            ElseIf File.Exists(FlagUtente) Then
                mDataFlag = CDate(File.ReadAllText(FlagUtente))
            Else
                mDataFlag = #1/1/2014#
            End If

        Catch ex As Exception
            mDataFlag = #1/1/2014#
        End Try

        LeggiFeed(Url)
    End Sub

    Private mDataFlag As Date
    Public ReadOnly Property DataFlag() As Date
        Get
            Return mDataFlag
        End Get
    End Property

    Private mEsistonoNews As Boolean
    Public ReadOnly Property EsistonoNews() As String
        Get
            Return mEsistonoNews
        End Get
    End Property

    Private mEsistonoBanner As Boolean
    Public ReadOnly Property EsistonoBanner() As Boolean
        Get
            Return mEsistonoBanner
        End Get
    End Property

    Private mLarghezzaBanner As Integer
    Public ReadOnly Property LarghezzaBanner() As Integer
        Get
            Return mLarghezzaBanner
        End Get
    End Property

    Private mAltezzaBanner As Integer
    Public ReadOnly Property AltezzaBanner() As Integer
        Get
            Return mAltezzaBanner
        End Get
    End Property

    Private mMillisecondi As Integer
    Public ReadOnly Property Millisecondi() As Integer
        Get
            Return mMillisecondi
        End Get
    End Property

    Private mLinkBanner As String
    Public ReadOnly Property LinkBanner() As String
        Get
            Return mLinkBanner
        End Get
    End Property

    Private mUltimaNews As Date
    Public ReadOnly Property UltimaNews() As String
        Get
            Return mUltimaNews
        End Get
    End Property

    Private mPagina As StringBuilder
    Public ReadOnly Property Pagina() As StringBuilder
        Get
            Try
                mPagina = New StringBuilder

                'creo la pagina
                Testata()

                For Each node As XmlNode In mRssNodes
                    Articolo(node)
                Next

                PiedePagina()

            Catch ex As Exception
                Utx.Globale.Log.Errore(ex)
            End Try

            Return mPagina
        End Get
    End Property

    Private Sub Testata()

        With mPagina
            .AppendLine("<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">")
            .AppendLine("<html xmlns=""http://www.w3.org/1999/xhtml"">")
            .AppendLine("<head>")
            .AppendLine("<title>Unitools notizie</title>")
            .AppendLine("<style type=""text/css"">p {margin:0;}")
            .AppendLine(".style1 {font-family: Calibri;}")
            .AppendLine(".style2 {font-family: Calibri;color: #3333FF;background-color: #DDDDDD;}")
            .AppendLine(".style3 {font-family: Calibri;color: #222222;background-color: #FF8000;}")
            .AppendLine(".style4 {font-family: Calibri;color: #222222;background-color: #FF8000;}")
            .AppendLine(".style5 {font-family: Calibri; font-size: small}")
            .AppendLine("</style>")
            .AppendLine("</head>")
            .AppendLine("<body>")
        End With
    End Sub

    Private Sub Articolo(ByRef node As XmlNode)

        Try
            Dim Data As Date = CDate(node.SelectSingleNode("pubDate").InnerText)
            Dim Titolo As String = node.SelectSingleNode("title").InnerText
            Dim Testo As String = node.SelectSingleNode("description").InnerText
            Dim Link As String = node.SelectSingleNode("link").InnerText

            'taglio il testo entro i 100 caratteri parola intera
            Testo = Left(Testo, 120)
            Testo = Left(Testo, InStrRev(Testo, Space(1)))

            With mPagina

                If Titolo.StartsWith("#", StringComparison.InvariantCultureIgnoreCase) Then
                    .AppendLine("<p class=""style3"">")
                    .AppendLine(String.Format("{0}</p>", Data))
                Else
                    .AppendLine("<p class=""style2"">")
                    .AppendLine(String.Format("{0}</p>", Data))
                End If

                .AppendLine("<p class=""style1"">")
                .AppendLine(String.Format("<strong>{0}</strong> <a href=""{1}"" target=""_blank"">leggi...</a></p>", Titolo, Link))
                .AppendLine(String.Format("<p class=""style5""> {0}...<br/><br/>", Testo))
            End With

        Catch ex As Exception
            Utx.Globale.Log.Info(ex.Message)
        End Try
    End Sub

    Private Sub PiedePagina()
        With mPagina
            .AppendLine("</body>")
            .AppendLine("</html>")
        End With
    End Sub

    Private Sub LeggiFeed(Url As String)
        Try
            Dim request As Net.HttpWebRequest
            Dim response As Net.HttpWebResponse

            request = Net.HttpWebRequest.Create(Url)
            request.Proxy = Utx.Globale.UniProxy.Proxy
            request.CachePolicy = New Net.Cache.RequestCachePolicy(Net.Cache.RequestCacheLevel.NoCacheNoStore)
            request.Timeout = 30000

            response = CType(request.GetResponse(), Net.HttpWebResponse)

            Dim xmlDoc As New XmlDocument()
            xmlDoc.Load(response.GetResponseStream)

            mRssNodes = xmlDoc.SelectNodes("/rss/channel/item")

#If DEBUG Then
            For Each n As XmlNode In mRssNodes
                Utx.Globale.Log.Info(n.SelectSingleNode("pubDate").InnerText)
            Next
#End If
            'il replace corregge un bug per il mese di marzo
            mUltimaNews = CDate(mRssNodes.Item(0).SelectSingleNode("pubDate").InnerText.Replace(" Mar ", "/03/"))

            'se ci sono news
            mEsistonoNews = (mUltimaNews > mDataFlag)

            If mEsistonoNews = True Then
                mEsistonoBanner = mRssNodes.Item(0).SelectSingleNode("title").InnerText.StartsWith("banner", StringComparison.InvariantCultureIgnoreCase)

#If DEBUG Then
                'esempio titolo: banner;500;150;30000 (banner;larghezza;altezza;millisecondi)
                'mEsistonoBanner = True
#End If

                If mEsistonoBanner = True Then

                    mLinkBanner = mRssNodes.Item(0).SelectSingleNode("description").InnerText

                    Try
                        mLarghezzaBanner = mRssNodes.Item(0).SelectSingleNode("title").InnerText.Split(";")(1)
                        mAltezzaBanner = mRssNodes.Item(0).SelectSingleNode("title").InnerText.Split(";")(2)
                        mMillisecondi = mRssNodes.Item(0).SelectSingleNode("title").InnerText.Split(";")(3)

                    Catch ex As Exception
                        mLarghezzaBanner = 0
                        mAltezzaBanner = 0
                        mMillisecondi = 30000
                    End Try

#If DEBUG Then
                    mLinkBanner = "http://www.utools.it/unitools/test/banner.htm"
                    mLarghezzaBanner = 540
                    mAltezzaBanner = 155
                    mMillisecondi = 5000
#End If
                Else
                    mLinkBanner = ""
                End If
            Else
                mEsistonoBanner = False
            End If

        Catch ex As System.Net.WebException
            'problemi di connessione
            Utx.Globale.Log.Info(ex.Message)

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Friend Function FlagUtente() As String
        Return String.Format("{0}\{1}.utwitt", Utx.Globale.Paths.CartellaSettingRete, Environment.UserName)
    End Function

    Friend Sub SalvaFlagUtente()
        File.WriteAllText(FlagUtente, mUltimaNews)
    End Sub

    Friend Sub CancellaFlagUtente()
        File.Delete(FlagUtente)
    End Sub

    Public Shared Sub ControlloTwitt(Optional ForzaApertura As Boolean = False)
        Try
            Utx.Globale.Log.Info("Controllo news...")

            'qui eventualmente va in forzatura
            Dim News As New PaginaNews("http://lnx.utools.it/utwitt/feed/", ForzaApertura)

            'se ci sono news
            If News.EsistonoBanner = True Then
                Utx.Globale.Log.Info(String.Format("Esistono banner. Ultimo twitt {0:G}", News.UltimaNews))

                News.SalvaFlagUtente()

                Utx.Globale.Log.Info("Visualizzo banner")

                Using f As New FormBanner
                    f.News = News
                    f.ShowDialog()
                End Using

            ElseIf News.EsistonoNews = True Then
                Utx.Globale.Log.Info(String.Format("Esistono news. Ultimo twitt {0:G}", News.UltimaNews))
                Utx.Globale.Log.Info("Visualizzo uTwitt")

                News.SalvaFlagUtente()

                Using f As New FormNotifica
                    f.News = News
                    f.ShowDialog()
                End Using
            Else
                Utx.Globale.Log.Info(String.Format("Non ci sono news. Ultimo twitt {0:G}", News.DataFlag))
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub
End Class
