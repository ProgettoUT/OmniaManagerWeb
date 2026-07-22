Imports System.Windows.Forms
Imports UniSql.CParametro

Public Class FrameParametri
    Public Event ParametroCambiato()
    Public Property Parametri As CParametri
    Public Property GroupboxRicerca As GroupBox

    Public Function Inizializza() As Boolean
        ParametriClear()
        ParametriLoad()
        Return Conferma()
    End Function

    Private Function Conferma() As Boolean
        Dim c As Control
        Dim param As CParametro

        ' Tutti i parametri obbligatori devono essere valorizzati
        For Each c In GroupboxRicerca.Controls
            If c.Tag <> vbNullString Then
                param = _Parametri(c.Tag)
                If param IsNot Nothing Then
                    If param.Obbligatorio = True Then
                        If TypeOf c Is TextBox Then
                            If Trim(c.Text) = "" _
                            Or TypeOf c Is ComboBox Then
                                MsgBox(String.Format("Il Campo {0} dev'essere valorizzato obbligatoriamente.", param.Etichetta),
                                       MsgBoxStyle.Critical, "Errore")
                                c.Select()
                                Return False
                            End If
                        End If
                    End If
                End If
            End If
        Next

        ' Controllo Congruenza di tipo dei valori nei campi
        For Each c In GroupboxRicerca.Controls
            If TypeOf c Is TextBox Then
                If c.Tag <> vbNullString Then
                    param = _Parametri(c.Tag)
                    If param IsNot Nothing Then
                        If c.Text <> vbNullString Then
                            If Not param.CheckParam(c.Text) Then
                                Dim sMsg As String = ""
                                If param.ParamType = EParamType.PT_DATA Then
                                    sMsg = "una data (gg/mm/aaaa)."
                                ElseIf param.ParamType = EParamType.PT_INTERO Then
                                    sMsg = "un numero intero."
                                ElseIf param.ParamType = EParamType.PT_VIRGOLA Then
                                    sMsg = "un numero."
                                End If

                                MsgBox(String.Format("Il Campo {0} dev'essere {1}", param.Etichetta, sMsg), MsgBoxStyle.Critical, "Errore")
                                c.Select()
                                Return False
                            End If
                        End If
                    End If
                End If
            End If
        Next
        ' Valorizzazione dei campi
        For Each c In GroupboxRicerca.Controls
            ValorizzaParametro(c)
        Next
        Return True
    End Function

    Private Function ValorizzaParametro(c As Control) As Boolean
        Dim param As CParametro

        If c.Tag <> vbNullString Then
            param = _Parametri(c.Tag)
            If param IsNot Nothing Then
                If TypeOf c Is TextBox Then
                    param.Valore = c.Text
                ElseIf TypeOf c Is DateTimePicker Then
                    param.Valore = CType(c, DateTimePicker).Value.ToString("dd/MM/yyyy")
                ElseIf TypeOf c Is ComboBox Then
                    With DirectCast(c, ComboBox)
                        If .SelectedIndex < 0 And Trim(c.Text) <> vbNullString Then
                            param.Valore = Trim(c.Text)
                        ElseIf .SelectedIndex >= 0 Then
                            param.Valore = .SelectedValue
                        End If
                    End With
                ElseIf TypeOf c Is CheckedListBox Then
                    With DirectCast(c, CheckedListBox)
                        Dim s As String = ""
                        For Each i As SimpleItem In .CheckedItems
                            s = s & ", " & i.Codice
                        Next
                        If s.Length > 2 Then s = s.Substring(2)
                        param.Valore = s
                    End With
                ElseIf TypeOf c Is ListBox Then
                    With DirectCast(c, ListBox)
                        Dim s As String = ""
                        With DirectCast(c, ListBox)
                            For Each i As Integer In .SelectedIndices
                                s = s & ", " & DirectCast(.Items(i), SimpleItem).Codice
                            Next
                            If s.Length > 2 Then s = s.Substring(2)
                        End With
                        param.Valore = s
                    End With
                ElseIf TypeOf c Is CheckBox Then
                    With DirectCast(c, CheckBox)
                        If param.ParamType = EParamType.PT_STRINGA Then

                            If .Checked Then
                                param.Valore = "S"
                            Else
                                param.Valore = "N"
                            End If
                        ElseIf param.ParamType = EParamType.PT_BOOLEAN Then
                            If .Checked Then
                                param.Valore = "true"
                            Else
                                param.Valore = "false"
                            End If
                        ElseIf param.ParamType = EParamType.PT_INTERO Then
                            If .Checked Then
                                param.Valore = "1"
                            Else
                                param.Valore = "0"
                            End If
                        End If
                    End With
                ElseIf TypeOf c Is RadioButton Then
                    With DirectCast(c, RadioButton)

                        If param.ParamType = EParamType.PT_STRINGA Then
                            If .Checked Then
                                param.Valore = "S"
                            Else
                                param.Valore = "N"
                            End If
                        ElseIf param.ParamType = EParamType.PT_BOOLEAN Then
                            If .Checked Then
                                param.Valore = "true"
                            Else
                                param.Valore = "false"
                            End If
                        ElseIf param.ParamType = EParamType.PT_INTERO Then
                            If .Checked Then
                                param.Valore = "1"
                            Else
                                param.Valore = "0"
                            End If
                        End If
                    End With
                End If
            End If
        End If

        ValorizzaParametro = True
    End Function

    Private Sub ParametriClear()
        Dim controlliDaEliminare As New List(Of Control)

        For Each controllo As Control In Me.GroupboxRicerca.Controls
            If controllo.Name <> "lblGridMsg" And controllo.Name <> "lblHelp" Then
                controlliDaEliminare.Add(controllo)
            End If
        Next

        For Each controllo As Control In controlliDaEliminare
            Me.GroupboxRicerca.Controls.Remove(controllo)
        Next
    End Sub

    Private Sub ParametriLoad()
        If ParametriBase.ParametriBase Is Nothing Then
            ParametriBase.LeggiParametriBase()
            ParametriBase.ThParametri.Join()
        End If

        Dim l As Long = 0 'Left
        Dim h As Long = 20 'height
        Dim w As Long = 0 'width
        Dim dh As Long = 30 'variazione di height

        Dim sBox As String 'tipo controllo
        Dim sValue As String = ""
        Dim sCaption As String

        Const UM As Integer = 8

        Dim nMaxWidth As Long = Screen.PrimaryScreen.Bounds.Width - 200 ' (Frame_Ricerca.Width - 200)
        GroupboxRicerca.Visible = False
        Dim param As CParametro
        For Each param In _Parametri.Values
            With param
                If .Nascosto Then
                    If .NuovaRiga Then
                        h += dh
                    End If
                Else
                    ' impostazione valori di default
                    If .Valore <> "" Then
                        sValue = .Valore
                    Else
                        Select Case .ParamType
                            Case EParamType.PT_STRINGA : sValue = ""         '1, 13 To 16
                            Case EParamType.PT_INTERO : sValue = ""          '2, 3, 4, 12, 17
                            Case EParamType.PT_DATA : sValue = CStr(Today)   '9, 10, 11
                            Case EParamType.PT_VIRGOLA : sValue = ""         '7
                            Case EParamType.PT_BOOLEAN : sValue = "false"    '5
                        End Select
                    End If

                    sCaption = IIf(.Obbligatorio, "*", "") & .Etichetta

                    sBox = "T"

                    If .ParamType = EParamType.PT_BOOLEAN Then
                        sBox = "K"
                    ElseIf .ParamType = EParamType.PT_DATA Then
                        sBox = "D"
                    Else
                        Select Case .EditType
                            Case EEditType.ET_LIST, EEditType.ET_SQL
                                If .MultiValore Then
                                    sBox = "L" ' ListBox
                                ElseIf .EditaValore Then
                                    sBox = "E" ' ComboBox - Text
                                Else
                                    sBox = "C" ' ComboBox - List
                                End If
                        End Select
                    End If

                    l += w

                    If .Larghezza = 0 Then
                        If .ParamType = EParamType.PT_BOOLEAN Then
                            w = 13
                        ElseIf .ParamType = EParamType.PT_DATA Then
                            w = 72
                        ElseIf .ParamType <> EParamType.PT_STRINGA Then
                            w = 132
                        Else
                            w = 254
                        End If
                    Else
                        w = UM * .Larghezza
                    End If

                    ' Carica la label
                    Dim lbl = New System.Windows.Forms.Label()
                    With lbl
                        Me.GroupboxRicerca.Controls.Add(lbl)
                        .Size = New System.Drawing.Size(40, 13)
                        .Text = sCaption
                        .AutoSize = True

                        If param.Sinistra > 0 Then
                            l = UM * (param.Sinistra - 20)
                        ElseIf l = 0 Then
                            l = 200
                        Else
                            l += 200
                        End If

                        If (l + w) > nMaxWidth Then
                            l = 200
                            param.NuovaRiga = True
                        End If

                        If param.NuovaRiga Then
                            h += dh
                        End If

                        .Location = New System.Drawing.Point(l - .Width, h + 4)
                    End With

                    Select Case sBox
                        Case "T" 'controllo TextBox
                            ' Carica il controllo
                            Dim txt = New System.Windows.Forms.TextBox()
                            Me.GroupboxRicerca.Controls.Add(txt)
                            With txt
                                .Text = sValue
                                '.ToolTipText = sCaption
                                .Tag = param.Key
                                .Location = New System.Drawing.Point(l, h)
                                .Size = New System.Drawing.Size(w, 21)
                                AddHandler .KeyPress, AddressOf TextBoxKeyPress
                                AddHandler .Leave, AddressOf ValuesChanged
                            End With

                        Case "D" 'controllo TextBox
                            ' Carica il controllo
                            Dim txt = New System.Windows.Forms.DateTimePicker()
                            Me.GroupboxRicerca.Controls.Add(txt)
                            With txt
                                .Text = sValue
                                .Format = DateTimePickerFormat.Short
                                '.ToolTipText = sCaption
                                .Tag = param.Key
                                .Location = New System.Drawing.Point(l, h)
                                .Size = New System.Drawing.Size(w, 21)
                                AddHandler .KeyPress, AddressOf TextBoxKeyPress
                                AddHandler .Leave, AddressOf ValuesChanged
                            End With

                        Case "C" ' Controllo ComboBox
                            ' Carica il controllo
                            Dim cmb = New System.Windows.Forms.ComboBox()
                            Me.GroupboxRicerca.Controls.Add(cmb)
                            With cmb
                                .DropDownStyle = ComboBoxStyle.DropDownList
                                .FormattingEnabled = True
                                .Tag = param.Key
                                If param.IsIndipendence Then
                                    RiempiComboBox(cmb, param, sValue)
                                End If
                                '.ToolTipText = sCaption
                                .Location = New System.Drawing.Point(l, h)
                                .Size = New System.Drawing.Size(w, 21)
                                AddHandler .SelectedIndexChanged, AddressOf ValuesChanged
                            End With

                        Case "E" ' Controllo ComboBox - Edit
                            ' Carica il controllo
                            Dim cmb = New System.Windows.Forms.ComboBox()
                            Me.GroupboxRicerca.Controls.Add(cmb)
                            With cmb
                                .DropDownStyle = ComboBoxStyle.DropDown
                                .FormattingEnabled = True
                                .Tag = param.Key
                                If param.IsIndipendence Then
                                    RiempiComboBox(cmb, param, sValue)
                                End If
                                '.ToolTipText = sCaption
                                .Location = New System.Drawing.Point(l, h)
                                .Size = New System.Drawing.Size(w, 21)

                                AddHandler .KeyPress, AddressOf ComboBoxKeyPress
                                AddHandler .SelectedIndexChanged, AddressOf ValuesChanged
                                AddHandler .Enter, AddressOf ValuesChanged
                            End With

                        Case "L" ' Controllo CheckedListBox
                            Dim lst = New System.Windows.Forms.CheckedListBox()
                            Me.GroupboxRicerca.Controls.Add(lst)
                            With lst
                                .FormattingEnabled = True
                                .Tag = param.Key
                                '.ToolTipText = sCaption
                                .Location = New System.Drawing.Point(l, h)

                                If param.Altezza <= 0 Then param.Altezza = 5

                                .Size = New System.Drawing.Size(w, 4 + 15 * param.Altezza)

                                If param.IsIndipendence Then
                                    RiempiListBox(lst, param, sValue)
                                End If
                                .CheckOnClick = True
                                AddHandler .ItemCheck, AddressOf ListItemCheck
                            End With

                            'h += 15 * (param.Altezza - 1)

                        Case "K" 'controllo CheckBox
                            ' Carica il controllo
                            Dim chk = New System.Windows.Forms.CheckBox()
                            Me.GroupboxRicerca.Controls.Add(chk)
                            With chk
                                '.Text = sCaption
                                '.ToolTipText = sCaption
                                .Tag = param.Key
                                .Checked = (sValue = "true")

                                .Location = New System.Drawing.Point(l, h + 2)
                                .Size = New System.Drawing.Size(w, 21)
                                AddHandler .CheckedChanged, AddressOf ValuesChanged
                            End With
                    End Select
                End If
            End With
        Next

        ' Altezza frame di ricerca
        h += dh
        GroupboxRicerca.Height = h + 30 '<- aggiunto ora

        ' Posizione label contrassegno
        'lblContrassegno.Top = H

        ' Posizione frame di Azione
        'H = H + 700 / 15
        'lblLine.Top = H - 200/96
        'cmdConferma.Top = H
        'cmdAnnulla.Top = H


        ' Altezza complessiva della finestra
        'h = h + Panel1.Height
        'Me.Height = h + 50

        Control_Click(GroupboxRicerca.Controls(0))

        GroupboxRicerca.Visible = True
        GroupboxRicerca.Refresh()

    End Sub

    Private Sub RiempiComboBox(Cmb As ComboBox, param As CParametro, sValue As String)
        Dim items As New List(Of SimpleItem)

        Select Case param.EditType
            Case EEditType.ET_LIST
                Dim sValues() As String = Split(param.Elencovalori, ";")
                If (1 + UBound(sValues)) Mod 2 = 0 Then
                    For i As Integer = 0 To UBound(sValues) Step 2
                        items.Add(New SimpleItem(sValues(i).Trim, sValues(1 + i)))
                    Next
                End If
            Case EEditType.ET_SQL
                If ParametriBase.ThParametri IsNot Nothing AndAlso ParametriBase.ThParametri.IsAlive Then
                    ParametriBase.ThParametri.Join()
                End If
                Dim dt As DataTable
                Select Case param.Key.ToLower
                    Case "@subagenzia", "@produttore", "@convenzione", "@prodotto", "@ramo", "@statocliente", "@storno", "@privacy", "@cip"
                        Utx.Globale.Log.Info("combo: " & param.Key)
                        dt = ParametriBase.ParametriBase.Tables(param.Key.Substring(1))
                    Case Else
                        dt = Utx.WsCommand.ExecuteNonQuery(_Parametri.ReplaceParam(param.Elencovalori)).DataTable
                End Select
                If dt IsNot Nothing Then
                    For Each row In dt.Rows
                        items.Add(New SimpleItem(row(0).ToString, row(1).ToString))
                    Next
                End If
        End Select

        Cmb.Items.Clear()
        Cmb.DataSource = items
        Cmb.ValueMember = "Codice"
        Cmb.DisplayMember = "Descrizione"

        If Cmb.Items.Count > 0 Then
            If sValue = vbNullString Then
                Cmb.SelectedIndex = 0
            Else
                Cmb.SelectedValue = sValue
            End If
        End If
    End Sub

    Private Sub RiempiListBox(lst As CheckedListBox, param As CParametro, sValue As String)
        Dim items As New List(Of SimpleItem)

        Select Case param.EditType
            Case EEditType.ET_LIST
                Dim sValues() As String = Split(param.Elencovalori, ";")
                If (1 + UBound(sValues)) Mod 2 = 0 Then
                    For i As Integer = 0 To UBound(sValues) Step 2
                        items.Add(New SimpleItem(sValues(i), sValues(1 + i)))
                    Next
                End If
            Case EEditType.ET_SQL
                If ParametriBase.ThParametri IsNot Nothing AndAlso ParametriBase.ThParametri.IsAlive Then
                    ParametriBase.ThParametri.Join()
                End If
                Dim dt As DataTable
                Select Case param.Key.ToLower
                    Case "@subagenzia", "@produttore", "@convenzione", "@prodotto", "@ramo", "@statocliente", "@storno"
                        Utx.Globale.Log.Info("list: " & param.Key)
                        dt = ParametriBase.ParametriBase.Tables(param.Key.Substring(1))
                    Case Else
                        dt = Utx.WsCommand.ExecuteNonQuery(_Parametri.ReplaceParam(param.Elencovalori)).DataTable
                End Select
                If dt IsNot Nothing Then
                    For Each row In dt.Rows
                        items.Add(New SimpleItem(row(0).ToString, row(1).ToString))
                    Next
                End If
        End Select

        'lst.Items.Clear()
        lst.DataSource = items
        lst.ValueMember = "Codice"
        lst.DisplayMember = "Descrizione"

        If lst.Items.Count > 0 Then
            If sValue = vbNullString Then
                lst.SelectedIndex = 0
            Else
                lst.SelectedItems.Clear()

                For Each v As String In sValue.Split(", ")
                    For i As Integer = 0 To lst.Items.Count - 1
                        If DirectCast(lst.Items(i), SimpleItem).Codice = v Then
                            lst.SetItemChecked(i, True)
                        End If
                    Next
                Next
            End If

            If lst.CheckedItems.Contains(lst.Items(0)) Then
                For i As Integer = 0 To lst.Items.Count - 1
                    If Not lst.CheckedItems.Contains(i) Then
                        lst.SetItemChecked(i, True)
                    End If
                Next
            End If

        End If
    End Sub

    Public Overridable Sub ValuesChanged(sender As System.Object, e As System.EventArgs)
        If ValorizzaParametro(sender) Then
            Control_Click(sender)
        End If
    End Sub

    Protected Sub TextBoxKeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = vbCr Then
            If ValorizzaParametro(sender) Then
                Control_Click(sender)
            End If
        End If
    End Sub

    Private Sub ComboBoxKeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = vbCr Then
            ValuesChanged(sender, Nothing)
        ElseIf e.KeyChar <> vbBack Then
            With DirectCast(sender, ComboBox)
                If .SelectedIndex < 0 Then
                    Dim sCode As String = UCase(Trim(.Text) & e.KeyChar)
                    For i As Integer = 0 To .Items.Count - 1
                        If DirectCast(.Items(i), SimpleItem).Codice = sCode Then
                            .SelectedIndex = i
                            e.Handled = True
                            Exit Sub
                        End If
                    Next
                End If
            End With
        End If
    End Sub

    Private Sub ListItemCheck(sender As Object, e As System.EventArgs)
        Dim clb = DirectCast(sender, CheckedListBox)
        RemoveHandler clb.ItemCheck, AddressOf ListItemCheck

        Dim arg = DirectCast(e, System.Windows.Forms.ItemCheckEventArgs)

        If arg.Index = 0 Then
            For i = 1 To clb.Items.Count - 1
                clb.SetItemCheckState(i, arg.NewValue)
            Next
        End If

        clb.SetItemCheckState(arg.Index, arg.NewValue)

        If ValorizzaParametro(sender) Then
            Control_Click(sender)
        End If

        AddHandler clb.ItemCheck, AddressOf ListItemCheck
    End Sub

    Private Sub ValueMemberChanged(sender As Object, e As EventArgs)
        MessageBox.Show("You are in the ListControl.ValueMemberChanged event.")
    End Sub


    Private Sub Control_Click(parent As Control)
        Static oneTime As Boolean
        Dim c As Control
        Dim param As CParametro

        If oneTime = False Then
            oneTime = True
            For Each c In Me.GroupboxRicerca.Controls
                If c.Tag <> vbNullString Then
                    If (c IsNot parent) Then
                        param = _Parametri(c.Tag)
                        If param IsNot Nothing Then
                            If Not param.IsIndipendence Then
                                If TypeOf c Is ListBox Then
                                    RiempiListBox(c, param, param.Valore)
                                ElseIf TypeOf c Is ComboBox Then
                                    RiempiComboBox(c, param, param.Valore)
                                End If
                            End If
                        End If
                    End If
                End If
            Next
            oneTime = False

            RaiseEvent ParametroCambiato()
        End If
    End Sub

    Private Class SimpleItem
        Property Codice As String
        Property Descrizione As String

        Public Sub New(codice As String, descrizione As String)
            _Codice = codice
            _Descrizione = descrizione
        End Sub
    End Class
End Class