Imports System.Runtime.InteropServices

Public Module API

    Public Structure SW
        Const SW_NORMAL = 1
        Const SW_MAXIMIZE = 3
        Const SW_SHOW = 5
        Const SW_MINIMIZE = 6
        Const SW_RESTORE = 9
    End Structure

    <DllImport("user32.dll", SetLastError:=True)> _
    Public Function FindWindow(lpClassName As String, lpWindowName As String) As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Public Function ShowWindow(hwnd As IntPtr, nCmdShow As Integer) As Boolean
    End Function

    Public Declare Function SetForegroundWindow Lib "user32.dll" (hwnd As Integer) As IntPtr
    Public Declare Function IsIconic Lib "user32.dll" (hwnd As Integer) As Boolean
    '==================================

    Public Structure SWP
        Const SWP_NOSIZE As Integer = &H1
        Const SWP_NOMOVE As Integer = &H2
    End Structure
    Public ReadOnly HWND_TOPMOST As New IntPtr(-1)
    Public ReadOnly HWND_NOTOPMOST As New IntPtr(-2)

    <DllImport("user32.dll", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.StdCall)> _
    Public Function SetWindowPos(hWnd As IntPtr,
                                 hWndInsertAfter As IntPtr,
                                 X As Int32,
                                 Y As Int32,
                                 cx As Int32,
                                 cy As Int32,
                                 uFlags As Int32) As Boolean
    End Function
    '==================================
End Module
