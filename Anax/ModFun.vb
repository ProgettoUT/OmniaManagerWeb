Option Explicit On
Imports System.Windows.Forms
Imports System.Drawing

Module ModFun
    Public gLastErrorDescription As String

    Public Const FORMATO_EURO As String = "#,##0.00"
    Public Const FORMATO_DATA As String = "dd/mm/yyyy"
    Public Const FORMATO_CAP As String = "00000"
    Public Const FORMATO_PRODOTTO As String = "00000"
    Public Const FORMATO_POLIZZA As String = "000000000"
    Public Const FORMATO_RAMO As String = "000"

    Public Const KEY_SETTINGS As String = "Settings"
    'Public Const PREFCHARFIELD = "["
    'Public Const POSTCHARFIELD = "]"

    Public Const DATA_MAX As Date = #12/31/9999#
    Public Const DATA_MIN As Date = #1/1/2001#


    Public Const BMP_OK16 As String = "OK16"
    Public Const BMP_KO16 As String = "KO16"

    Public Const DELIMITER As String = "~"

    Public Sub GotFocus(txt As TextBox)
        If txt.ReadOnly = False Then
            If txt.BackColor = SystemColors.Window Then
                txt.BackColor = Color.LightYellow
            End If
        End If
    End Sub

    Public Sub LostFocus(txt As TextBox)
        If txt.ReadOnly = False Then
            txt.BackColor = SystemColors.Window
        End If
    End Sub

    Public Sub ErrFocus(txt As TextBox)
        If txt.ReadOnly = False Then
            txt.BackColor = Color.Red
        End If
    End Sub


    Public Sub BooleanToCheckbox(chk As CheckBox, value As Boolean)
        chk.Checked = value
    End Sub

    Public Function CheckboxToBoolean(chk As CheckBox) As Boolean
        If chk.Checked = True Then
            CheckboxToBoolean = True
        Else
            CheckboxToBoolean = False
        End If
    End Function

    Public Sub CurrencyToLabel(txt As Label, value As Decimal)
        If value = 0 Then
            txt.Text = vbNullString
        Else
            txt.Text = Format(value, FORMATO_EURO)
        End If
    End Sub
    Public Sub CurrencyToTextBox(txt As TextBox, value As Decimal)
        If value = 0 Then
            txt.Text = vbNullString
        Else
            txt.Text = Format(value, FORMATO_EURO)
        End If
    End Sub
    Public Function TextBoxToCurrency(txt As TextBox) As Decimal
        Dim d As Decimal = 0
        Decimal.TryParse(txt.Text, d)
        Return d
    End Function

    Public Sub LongToTextBox(txt As TextBox, value As Long)
        'If value = 0 Then
        '    txt.Text = vbNullString
        'ElseIf txt.DataFormat.Format = "" Then
        '    txt.Text = value
        'Else
        '    txt.Text = Format(value, txt.DataFormat.Format)
        'End If
        If value = 0 Then
            txt.Text = vbNullString
        Else
            txt.Text = value
        End If
    End Sub

    Public Function TextBoxToLong(txt As TextBox) As Long
        Dim l As Long = 0
        Long.TryParse(txt.Text, l)
        Return l
    End Function

    Public Sub DateToLabel(txt As Label, value As Date)
        If value.Ticks = 0 Then
            txt.Text = vbNullString
        Else
            txt.Text = Format(value, FORMATO_DATA)
        End If
    End Sub
    Public Sub DateToTextBox(txt As TextBox, value As Date)
        If value.Ticks = 0 Then
            txt.Text = vbNullString
        Else
            txt.Text = Format(value, FORMATO_DATA)
        End If
    End Sub
    Public Function TextBoxToDate(txt As TextBox) As Date
        Dim d As Date
        Date.TryParse(txt.Text, d)
        Return d
    End Function

    Public Sub StringToLabel(txt As Label, value As String)
        'If txt.DataFormat.Format = "" Then
        '    txt = value
        'ElseIf value = "" Then
        '    txt = ""
        'Else
        '    txt = Format(value, txt.DataFormat.Format)
        'End If
        If value = "" Then
            txt.Text = ""
        Else
            txt.Text = value
        End If

    End Sub
    Public Sub StringToTextBox(txt As TextBox, value As String)
        'If txt.DataFormat.Format = "" Then
        '    txt.Text = value
        'ElseIf value = "" Then
        '    txt.Text = ""
        'Else
        '    txt.Text = Format(value, txt.DataFormat.Format)
        'End If
        If value = "" Then
            txt.Text = ""
        Else
            txt.Text = value
        End If
    End Sub

    Public Sub StringToTextBox(txt As MaskedTextBox, value As String)
        'If txt.DataFormat.Format = "" Then
        '    txt.Text = value
        'ElseIf value = "" Then
        '    txt.Text = ""
        'Else
        '    txt.Text = Format(value, txt.DataFormat.Format)
        'End If
        If value = "" Then
            txt.Text = ""
        Else
            txt.Text = value
        End If
    End Sub

    Public Function TextBoxToString(txt As TextBox) As String
        TextBoxToString = Trim(txt.Text)
    End Function

    Public Sub StringToComboBox(cmb As ComboBox, value As String)
        If value IsNot Nothing Then
            cmb.SelectedValue = value
        End If
    End Sub
    Public Function ComboBoxToString(cmb As ComboBox) As String
        Return cmb.SelectedValue
    End Function
    'Public Sub LongToComboBox( cmb As ComboBox,  value As Long)
    '    'comboSetSelected(cmb, value)
    'End Sub
    'Public Function ComboBoxToLong( cmb As ComboBox) As Long
    '    'ComboBoxToLong = CLng(comboGetSelected(cmb))
    'End Function


    Public Function ValidaString(txt As TextBox, pct As Panel, lbl As Label) As Boolean
        pct.Visible = False
        lbl.Visible = False
        ValidaString = True
    End Function

    Public Function ValidaCurrency(txt As TextBox, pct As Panel, lbl As Label) As Boolean
        Dim IsValido As Boolean

        Dim valore As String
        valore = Trim(txt.Text)

        IsValido = IsNumeric(valore) Or (valore = vbNullString)

        ValidaNotifica(pct, lbl, IsValido, "Importo non valido")

        ValidaCurrency = IsValido
    End Function

    Public Function ValidaLong(txt As TextBox, pct As Panel, lbl As Label) As Boolean
        Dim IsValido As Boolean

        Dim valore As String
        valore = Trim(txt.Text)

        IsValido = IsNumeric(valore) Or (valore = vbNullString)

        ValidaNotifica(pct, lbl, IsValido, "Formato non valido")

        ValidaLong = IsValido
    End Function

    Public Function ValidaDate(txt As TextBox, pct As Panel, lbl As Label) As Boolean
        Dim IsValido As Boolean

        Dim Data As String
        Data = Trim(txt.Text)

        If (IsNumeric(Data) And (Len(Data) = 8)) Then
            Data = Left(Data, 2) & "/" & Mid(Data, 3, 2) & "/" & Mid(Data, 5)
            txt.Text = Data
        End If

        IsValido = (IsDate(Data) And (Len(Data) = 10)) Or (Data = vbNullString)

        ValidaNotifica(pct, lbl, IsValido, "Data non valida (gg/mm/aaaa)")

        ValidaDate = IsValido
    End Function


    Public Function ValidaIndirizzoEmail(txt As TextBox, pct As Panel, lbl As Label) As Boolean
        Dim IsValido As Boolean
        Dim Email As String
        Dim i As Integer
        Dim j As Integer

        IsValido = True

        Email = Trim(txt.Text)
        If Email <> vbNullString Then
            i = InStr(1, Email, "@")
            If i = 0 Or i = 1 Or i = Len(Email) Then
                IsValido = False
            Else
                j = InStrRev(Email, ".")
                If j = 0 Or j = Len(Email) Or j <= 1 + i Then
                    IsValido = False
                End If
            End If
        End If

        ValidaNotifica(pct, lbl, IsValido, "Indirizzo Email non valido")

        ValidaIndirizzoEmail = IsValido
    End Function

    Public Function ValidaCellulare(txt As TextBox, pct As Panel, lbl As Label) As Boolean
        Dim IsValido As Boolean
        Dim Cellulare As String

        IsValido = True

        Cellulare = Trim(txt.Text)

        ValidaNotifica(pct, lbl, IsValido, "Numero Cellulare non valido")

        ValidaCellulare = IsValido
    End Function

    Public Function ValidaNotifica(pct As Panel, lbl As Label, IsValido As Boolean, Caption As String) As Boolean
        If IsValido Then
            'pct.Visible = False
            lbl.Visible = False
        Else
            'pct.Visible = True
            lbl.Visible = True
            lbl.Text = Caption
        End If
        Return False
    End Function

    Public Sub ComboBoxLoad(cmb As ComboBox, sql As String)
        Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(sql).DataTable
        cmb.DataSource = dt
        cmb.DisplayMember = dt.Columns(1).ColumnName
        cmb.ValueMember = dt.Columns(0).ColumnName
        cmb.SelectedItem = Nothing
    End Sub

    Public Sub ComboBoxLoad(cmbs As ComboBox(), sql As String)
        Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(sql).DataTable
        For Each cmb As ComboBox In cmbs
            cmb.DataSource = dt.Copy
            cmb.DisplayMember = dt.Columns(1).ColumnName
            cmb.ValueMember = dt.Columns(0).ColumnName
            cmb.SelectedItem = Nothing
        Next
    End Sub

    Public Sub ComboBoxLoad(cmb As DataGridViewComboBoxColumn, sql As String)
        Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(sql).DataTable
        cmb.DataSource = dt
        cmb.DisplayMember = dt.Columns(1).ColumnName
        cmb.ValueMember = dt.Columns(0).ColumnName

        cmb.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing
        cmb.DropDownWidth = 150
        cmb.FlatStyle = FlatStyle.Popup
    End Sub
End Module
