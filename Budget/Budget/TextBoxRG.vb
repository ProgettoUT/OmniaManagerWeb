Public Class TextBoxRG

    Inherits TextBox

    Public Event ModificaImportoRamo(ByRef Rg As TextBoxRG)

    Sub New()
        Me.BorderStyle = Windows.Forms.BorderStyle.Fixed3D
        Me.Dock = DockStyle.Fill
        Me.Text = ""
        Me.TextAlign = HorizontalAlignment.Right
    End Sub

    Private mRamoGestione As Integer
    Public Property RamoGestione() As Integer
        Get
            Return mRamoGestione
        End Get
        Set(value As Integer)
            mRamoGestione = value
            mComparto = Budget.Comparto.Comparto(mRamoGestione)
        End Set
    End Property

    Private mComparto As Integer
    Public ReadOnly Property Comparto() As Integer
        Get
            Return mComparto
        End Get
    End Property

    Private mImporto As Double
    Public Property Importo() As String
        Get
            Return mImporto
        End Get
        Set(value As String)
            If String.IsNullOrEmpty(Me.Text) OrElse mImporto <> value Then
                mImporto = value
                RaiseEvent ModificaImportoRamo(Me)
            End If
            Me.Text = Format(mImporto, "###,###,##0.00")
        End Set
    End Property

    Private mCalcoloTotali As Boolean = True
    Public Property CalcoloTotali() As Boolean
        Get
            Return mCalcoloTotali
        End Get
        Set(value As Boolean)
            mCalcoloTotali = value
        End Set
    End Property

    Private Sub TextBoxRG_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Me.Text = mImporto
        Me.BackColor = Color.Yellow
    End Sub

    Private Sub TextBoxRG_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        On Error Resume Next

        If IsNumeric(e.KeyChar) Then
        ElseIf e.KeyChar = "," Then
        ElseIf e.KeyChar = Chr(ConsoleKey.Backspace) Then
        ElseIf Asc(e.KeyChar) = ConsoleKey.Enter Then
            SendKeys.Send(Chr(ConsoleKey.Tab))
        ElseIf e.KeyChar = "." Then
            e.KeyChar = ","
        Else
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TextBoxRG_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        Me.BackColor = SystemColors.Window
    End Sub

    Private Sub TextBoxRG_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Validating
        If String.IsNullOrEmpty(Me.Text) Then
            Me.Importo = 0
        Else
            Me.Importo = Me.Text
        End If
    End Sub
End Class
