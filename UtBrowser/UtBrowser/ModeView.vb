Imports System.Runtime.InteropServices
Imports System.Text

Public Class ModeView

    Private mWb As AxSHDocVw.AxWebBrowser
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
    Private Shared Function EnumChildWindows(ByVal hwndParent As HandleRef, ByVal lpEnumFunc As EnumChildrenCallback, ByVal lParam As HandleRef) As Boolean
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function SendMessage(ByVal hWnd As HandleRef, ByVal Msg As UInteger, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function RealGetWindowClass(ByVal hwnd As IntPtr, <Out()> ByVal pszType As StringBuilder, ByVal cchType As UInteger) As UInteger
    End Function

    Private Delegate Function EnumChildrenCallback(ByVal hwnd As IntPtr, ByVal lParam As IntPtr) As Boolean
    Private listViewHandle As HandleRef

    Sub New(ByRef f As Form, ByRef wb As AxSHDocVw.AxWebBrowser)
        mForm = f
        mWb = wb
    End Sub

    Private Sub FindListViewHandle()

        Me.listViewHandle = NullHandleRef

        Dim lpEnumFunc As EnumChildrenCallback = New EnumChildrenCallback(AddressOf EnumChildren)

        EnumChildWindows(New HandleRef(mWb, mWb.Handle), lpEnumFunc, NullHandleRef)

    End Sub

    Private Function EnumChildren(ByVal hwnd As IntPtr, ByVal lparam As IntPtr) As Boolean

        Dim sb As StringBuilder = New StringBuilder(100)

        RealGetWindowClass(hwnd, sb, 100)

        If sb.ToString() = ListViewClassName Then

            Me.listViewHandle = New HandleRef(Nothing, hwnd)

        End If

        Return True

    End Function

    Public Sub SetView(ByVal TipoVista As TipoViste)

        FindListViewHandle()
        SendMessage(Me.listViewHandle, LVM_SETVIEW, TipoVista, 0)

    End Sub

End Class
