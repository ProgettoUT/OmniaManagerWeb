Imports System.Windows.Forms
Imports System.Drawing

Public Class UtTabControl
    Inherits TabControl

    Public Enum TabColorStyle
        TRASPARENT
        CONTROL
        AZZURRO
        DODGER_BLUE
        ROSSO
        ROSSOGRIGIO
        VERDE
        VERDE_ACIDO
        ROSA
        GOLD
        ORANGE
    End Enum

    Public TabBackColor As Brush = Brushes.Gainsboro
    Public TabForeColor As Brush = Brushes.Black
    Public SelectedTabBackColor As Brush = Brushes.DodgerBlue
    Public SelectedTabForeColor As Brush = Brushes.White

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or
                 ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
        DoubleBuffered = True
        SizeMode = TabSizeMode.Fixed
        ItemSize = New Size(150, 25)
        HotTrack = False
        Appearance = TabAppearance.Buttons
        Alignment = TabAlignment.Top
        'deve essere reso visibile (in genere) con l'assegnazione di uno stile nell'evento show del form
        Me.Visible = False
    End Sub

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)

        For i As Integer = 0 To TabCount - 1
            Dim TabRectangle As Rectangle = GetTabRect(i)

            If i = SelectedIndex Then
                G.FillRectangle(SelectedTabBackColor, TabRectangle)
                G.DrawString(TabPages(i).Text, Font, SelectedTabForeColor, TabRectangle,
                             New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            Else
                G.FillRectangle(TabBackColor, TabRectangle)
                G.DrawString(TabPages(i).Text, Font, TabForeColor, TabRectangle,
                             New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            End If
        Next

        e.Graphics.DrawImage(B.Clone, 0, 0)
        G.Dispose()
        B.Dispose()

        MyBase.OnPaint(e)
    End Sub

    Private mColorStyle As TabColorStyle
    Public Property ColorStyle() As TabColorStyle
        Get
            Return mColorStyle
        End Get
        Set(value As TabColorStyle)
            mColorStyle = value

            Select Case mColorStyle
                Case TabColorStyle.TRASPARENT
                    TabForeColor = Brushes.Transparent
                    TabBackColor = Brushes.Transparent
                    SelectedTabForeColor = Brushes.Transparent
                    SelectedTabBackColor = Brushes.Transparent
                Case TabColorStyle.CONTROL
                    TabForeColor = Brushes.Black
                    TabBackColor = Brushes.Gainsboro
                    SelectedTabForeColor = Brushes.WhiteSmoke
                    SelectedTabBackColor = Brushes.Gray
                Case TabColorStyle.AZZURRO
                    TabForeColor = Brushes.Black
                    TabBackColor = Utx.AppBrush.GrigioAzzurro
                    SelectedTabForeColor = Brushes.White
                    SelectedTabBackColor = Utx.AppBrush.AzzurroScuro
                Case TabColorStyle.DODGER_BLUE
                    TabForeColor = Brushes.Black
                    TabBackColor = Utx.AppBrush.GrigioAzzurro
                    SelectedTabForeColor = Brushes.White
                    SelectedTabBackColor = Brushes.DodgerBlue
                Case TabColorStyle.ROSSO
                    TabForeColor = Brushes.Black
                    TabBackColor = Utx.AppBrush.GrigioAzzurro
                    SelectedTabForeColor = Brushes.White
                    SelectedTabBackColor = Utx.AppBrush.RossoScuro
                Case TabColorStyle.ROSSOGRIGIO
                    TabForeColor = Brushes.Black
                    TabBackColor = Brushes.Gainsboro
                    SelectedTabForeColor = Brushes.White
                    SelectedTabBackColor = Utx.AppBrush.RossoScuro
                Case TabColorStyle.VERDE
                    TabForeColor = Brushes.Black
                    TabBackColor = Brushes.Gainsboro
                    SelectedTabForeColor = Brushes.White
                    SelectedTabBackColor = Utx.AppBrush.VerdeOpaco
                Case TabColorStyle.VERDE_ACIDO
                    TabForeColor = Brushes.Black
                    TabBackColor = Brushes.Gainsboro
                    SelectedTabForeColor = Brushes.Black
                    SelectedTabBackColor = Utx.AppBrush.VerdeAcido
                Case TabColorStyle.ROSA
                    TabForeColor = Brushes.Black
                    TabBackColor = Brushes.Gainsboro
                    SelectedTabForeColor = Brushes.Black
                    SelectedTabBackColor = Brushes.Pink
                Case TabColorStyle.GOLD
                    TabForeColor = Brushes.Black
                    TabBackColor = Brushes.Gainsboro
                    SelectedTabForeColor = Brushes.Black
                    SelectedTabBackColor = Brushes.Gold
                Case TabColorStyle.ORANGE
                    TabForeColor = Brushes.Black
                    TabBackColor = Brushes.Gainsboro
                    SelectedTabForeColor = Brushes.Black
                    SelectedTabBackColor = Brushes.Orange
            End Select
            Me.Visible = True
        End Set
    End Property
End Class
