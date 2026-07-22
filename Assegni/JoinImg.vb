Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.IO

Public Class JoinImg

    Shared hLib As Integer = 0

#Region "Kernel32.dll imports"

    <DllImport("kernel32.dll", EntryPoint:="LoadLibrary")>
    Private Shared Function LoadLibrary(<MarshalAs(UnmanagedType.LPStr)> lpLibFileName As String) As Integer
    End Function

    <DllImport("kernel32.dll", EntryPoint:="GetProcAddress")>
    Private Shared Function GetProcAddress(hModule As Integer,
                                           <MarshalAs(UnmanagedType.LPStr)> lpProcName As String) As IntPtr
    End Function

    <DllImport("kernel32.dll", EntryPoint:="FreeLibrary")>
    Private Shared Function FreeLibrary(hModule As Integer) As Boolean
    End Function

#End Region

#Region "delegates"

    <UnmanagedFunctionPointer(CallingConvention.Cdecl)>
    Private Delegate Function dJoinImg(<MarshalAs(UnmanagedType.LPStr)> ImageA As String,
                                       <MarshalAs(UnmanagedType.LPStr)> ImageB As String,
                                       <MarshalAs(UnmanagedType.LPStr)> ImageC As String,
                                       <MarshalAs(UnmanagedType.U4)> type As Integer,
                                       <MarshalAs(UnmanagedType.U4)> compression As Integer,
                                       <MarshalAs(UnmanagedType.U4)> npixels As Integer,
                                       <MarshalAs(UnmanagedType.U4)> mode As Integer) As Integer

    Shared pJoinImg As IntPtr
    Shared fJoinImg As dJoinImg

#End Region

#Region "Enum"

    Public Enum ImgType
        JPEG = 0
        BMP = 1
    End Enum

    Public Enum ImgPosition
        A_Over_B = 0
        B_Over_A = 1
    End Enum

    Public Enum JoinResult
        OK = 1
        ERR_JO_DIFFERENT_COLOR = -1 'The two image to join are not compatible
        ERR_JO_OUT_OF_MEMORY = -2 'Not enough memory
        ERR_JO_UNKNOWN_IMAGE_FORMAT = -3 'Unknown image file format
        ERR_JO_FILE_NOT_FOUND = -4 'Input file not found
        ERR_JO_WRONG_PARAMETER = -5 'Wrong parameter id
        ERR_JO_GENERIC_ERROR = -99 'Generic error
    End Enum

#End Region

    Public Shared Function LoadJoinImg() As Boolean
        If hLib = 0 Then
            If File.Exists(Path.Combine(Utx.Globale.Paths.CartellaApp, "joinimg.dll")) Then
                'per le installazioni del nuovo unitools
                hLib = LoadLibrary(Path.Combine(Utx.Globale.Paths.CartellaApp, "joinimg.dll"))
            Else
                'per le vecchie installazioni
                hLib = LoadLibrary(Path.Combine(Utx.Globale.Paths.CartellaApp, "DLL\joinimg.dll"))
            End If

            If hLib = 0 Then
                Return False
            End If

            pJoinImg = GetProcAddress(hLib, "JOINImagesExt")

            fJoinImg = DirectCast(Marshal.GetDelegateForFunctionPointer(pJoinImg, GetType(dJoinImg)), dJoinImg)
        End If

        Return True
    End Function

    Public Shared Sub FreeJoinImg()
        If hLib <> 0 Then
            FreeLibrary(hLib)
        End If
        hLib = 0
    End Sub

    ''' <summary>
    ''' Join two images
    ''' </summary>
    ''' <param name="ImageA">First input image file name (Jpg, Bmp or Tiff)</param>
    ''' <param name="ImageB">Second input image file name (Jpg, Bmp or Tiff)</param>
    ''' <param name="ImageC">Output image file name (Jpg, Bmp or Tiff)</param>
    ''' <param name="Type">File type for output image (ENUM ImgType)</param>
    ''' <param name="Compression">Jpeg quality in case of jpeg output</param>
    ''' <param name="NPixels">Pixels to add between ImageA and ImageB</param>
    ''' <param name="Mode">Mode (ENUM ImgPosition)</param>
    ''' <returns>ENUM JoinResult</returns>
    ''' <remarks></remarks>
    Public Shared Function JOINImagesExt(ByRef ImageA As String,
                                         ByRef ImageB As String,
                                         ByRef ImageC As String,
                                         ByVal Type As Integer,
                                         ByVal Compression As Integer,
                                         ByVal NPixels As Integer,
                                         ByVal Mode As Integer) As Integer
        If hLib = 0 Then
            Return -99
        Else
            Return fJoinImg(ImageA, ImageB, ImageC, Type, Compression, NPixels, Mode)
        End If
    End Function

    Public Shared Function ResultDesk(ByVal ErrorCode As Integer) As String
        Select Case ErrorCode
            Case JoinResult.OK
                Return "Ok"
            Case JoinResult.ERR_JO_DIFFERENT_COLOR
                Return "The two image to join are not compatible"
            Case JoinResult.ERR_JO_OUT_OF_MEMORY
                Return "Not enough memory"
            Case JoinResult.ERR_JO_UNKNOWN_IMAGE_FORMAT
                Return "Unknown image file format"
            Case JoinResult.ERR_JO_FILE_NOT_FOUND
                Return "Input file not found"
            Case JoinResult.ERR_JO_WRONG_PARAMETER
                Return "Wrong parameter id"
            Case JoinResult.ERR_JO_GENERIC_ERROR
                Return "Generic error"
            Case Else
                Return "Errore imprevisto"
        End Select
    End Function
End Class
