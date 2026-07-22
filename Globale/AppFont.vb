Imports System.Drawing

<Serializable> _
Public Class AppFont

    Public Shared Function Normal() As Font
        Return New Font(FontName, FontSize, FontStyle.Regular)
    End Function

    Public Shared Function Normal(NewSize As Integer) As Font
        Return New Font(FontName, NewSize, FontStyle.Regular)
    End Function

    Public Shared Function Bold() As Font
        Return New Font(FontName, FontSize, FontStyle.Bold)
    End Function

    Public Shared Function Bold(NewSize As Integer) As Font
        Return New Font(FontName, NewSize, FontStyle.Bold)
    End Function

    Public Shared Function Italic() As Font
        Return New Font(FontName, FontSize, FontStyle.Italic)
    End Function

    Public Shared Function Italic(NewSize As Integer) As Font
        Return New Font(FontName, NewSize, FontStyle.Italic)
    End Function

    Public Shared Function Extra(NewSize As Integer, Style As FontStyle) As Font
        Return New Font(FontName, NewSize, Style)
    End Function

    Public Shared Function ButtonPadding() As Windows.Forms.Padding
        Return New Windows.Forms.Padding(10, 0, 10, 0)
    End Function

    Private Shared mFontName As String = "Tahoma"
    Public Shared Property FontName() As String
        Get
            Return mFontName
        End Get
        Set(value As String)
            mFontName = value
        End Set
    End Property

    Private Shared mFontSize As Integer = 9
    Public Shared Property FontSize() As Integer
        Get
            Return mFontSize
        End Get
        Set(value As Integer)
            mFontSize = value
        End Set
    End Property
End Class
