Imports System.Windows.Forms
Imports System.Diagnostics

Public Module Globale
    Public ModelloPrivacyPath As String = ""

    Public Sub InizializzaControllo(controlli() As Button, Optional imagekey As String = Nothing)
        For Each c In controlli
            InizializzaControllo(c, imagekey)
        Next
    End Sub

    Public Sub InizializzaControllo(pulsante As Button,
                                    Optional imagekey As String = Nothing,
                                    Optional Tip As String = "")
        Dim p As New Utx.MyFlatButton
        With pulsante
            .Margin = p.Margin
            .FlatStyle = p.FlatStyle
            .FlatAppearance.BorderSize = p.FlatAppearance.BorderSize
            .FlatAppearance.BorderColor = p.FlatAppearance.BorderColor
            If imagekey IsNot Nothing Then
                .Image = Risorse.Immagini.Bitmap(imagekey)
            End If
        End With

        If Tip <> "" Then
            Dim tt As New ToolTip
            tt.SetToolTip(pulsante, Tip)
        End If
    End Sub

    Public Sub InizializzaControllo(etichetta As Label)
        etichetta.Font = Utx.AppFont.Bold
    End Sub

    Public Sub InizializzaControllo(controllo As TextBox)
        controllo.Font = Utx.AppFont.Bold
    End Sub

    Public Sub InizializzaControllo(controllo As ComboBox)
        controllo.Font = Utx.AppFont.Normal
        controllo.FlatStyle = FlatStyle.Flat
    End Sub

    Public Sub InizializzaControllo(controlli() As Control, Optional font As System.Drawing.Font = Nothing)
        For Each controllo As Control In controlli
            InizializzaControllo(controllo)
            If font IsNot Nothing Then
                controllo.Font = font
            End If
        Next
    End Sub

    Public Sub inizializzaControllo(controlli As Control.ControlCollection)
        For Each controllo As Control In controlli
            InizializzaControllo(controllo)
        Next
    End Sub

    Public Sub InizializzaControllo(controllo As Control)
        Select Case True
            Case controllo.Controls.Count > 0
                InizializzaControllo(controllo.Controls)
            Case TypeOf controllo Is TextBox
                InizializzaControllo(CType(controllo, TextBox))
            Case TypeOf controllo Is Label
                InizializzaControllo(CType(controllo, Label))
            Case TypeOf controllo Is Button
                InizializzaControllo(CType(controllo, Button))
            Case TypeOf controllo Is ComboBox
                InizializzaControllo(CType(controllo, ComboBox))
            Case controllo.Controls.Count > 0
                InizializzaControllo(controllo.Controls)
            Case Else 'imposta il font di default
                controllo.Font = Utx.AppFont.Normal
        End Select
    End Sub
End Module
