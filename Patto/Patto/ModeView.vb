Imports System.Runtime.InteropServices
Imports System.Text

Public Class ModeView

    Private mWb As WebBrowser
    Private mForm As Form

    Public Enum TipoViste
        [LV_VIEW_ICON] = &H0
        [LV_VIEW_DETAILS] = &H1
        [LV_VIEW_SMALLICON] = &H2
        [LV_VIEW_LIST] = &H3
        [LV_VIEW_TILE] = &H4
    End Enum

    Private Const EM_HIDEBALLOONTIP As Integer = &H1504
    Private Const LVM_SETVIEW As Integer = &H108E

    Private Const ListViewClassName As String = "SysListView32"

    Private Shared ReadOnly NullHandleRef As HandleRef = New HandleRef(Nothing, IntPtr.Zero)

    <DllImport("user32.dll", ExactSpelling:=True)> _
    Private Shared Function EnumChildWindows(hwndParent As HandleRef, lpEnumFunc As EnumChildrenCallback, lParam As HandleRef) As Boolean
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function SendMessage(hWnd As HandleRef, Msg As UInteger, wParam As Integer, lParam As Integer) As Integer
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function RealGetWindowClass(hwnd As IntPtr, <Out()> pszType As StringBuilder, cchType As UInteger) As UInteger
    End Function

    Private Delegate Function EnumChildrenCallback(hwnd As IntPtr, lParam As IntPtr) As Boolean
    Private listViewHandle As HandleRef

    Sub New(ByRef f As Form, ByRef wb As WebBrowser)
        mForm = f
        mWb = wb
    End Sub

    Private Sub FindListViewHandle()

        Me.listViewHandle = NullHandleRef

        Dim lpEnumFunc As EnumChildrenCallback = New EnumChildrenCallback(AddressOf EnumChildren)

        EnumChildWindows(New HandleRef(mWb, mWb.Handle), lpEnumFunc, NullHandleRef)

    End Sub

    Private Function EnumChildren(hwnd As IntPtr, lparam As IntPtr) As Boolean

        Dim sb As StringBuilder = New StringBuilder(100)

        RealGetWindowClass(hwnd, sb, 100)

        If sb.ToString() = ListViewClassName Then

            Me.listViewHandle = New HandleRef(Nothing, hwnd)

        End If

        Return True

    End Function

    Public Sub SetView(TipoVista As TipoViste)

        FindListViewHandle()
        SendMessage(Me.listViewHandle, LVM_SETVIEW, TipoVista, 0)

    End Sub

End Class
