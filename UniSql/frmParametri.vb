Imports System.Windows.Forms
Imports UniSql.CParametro
Imports System.Drawing

Public Class frmParametri

    Public Property Parametri As CParametri
    Private _conferma As Boolean


    Public ReadOnly Property Conferma() As Boolean
        Get
            Return _conferma
        End Get
    End Property

    Private Sub cmdAnnulla_Click() Handles cmdAnnulla.Click
        _conferma = False
        Me.Dispose()
    End Sub

    Private Sub cmdConferma_Click() Handles cmdConferma.Click
        Dim c As Control
        Dim param As CParametro

        ' Tutti i parametri obbligatori devono essere valorizzati
        For Each c In Frame_Ricerca.Controls
            If c.Tag <> vbNullString Then
                param = _Parametri(c.Tag)
                If param IsNot Nothing Then
                    If param.Obbligatorio = True Then
                        If TypeOf c Is TextBox Then
                            If Trim(c.Text) = "" _
                            Or TypeOf c Is ComboBox Then
                                MsgBox("Il Campo """ & param.Etichetta &
                                       """ dev'essere valorizzato obbligatoriamente.", vbCritical, "Errore")
                                c.Select()
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If
        Next

        ' Controllo Congruenza di tipo dei valori nei campi
        For Each c In Frame_Ricerca.Controls
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

                                MsgBox("Il Campo """ & param.Etichetta &
                                       """ dev'essere " & sMsg, vbCritical, "Errore")
                                c.Select()
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If
        Next

        ' Valorizzazione dei campi
        For Each c In Frame_Ricerca.Controls
            ValorizzaParametro(c)
        Next

        _conferma = True
        Hide()
    End Sub

    Private Function ValorizzaParametro(c As Control) As Boolean
        Dim param As CParametro

        If c.Tag <> vbNullString Then
            param = _Parametri(c.Tag)
            If param IsNot Nothing Then
                If TypeOf c Is TextBox Then
                    param.Valore = c.Text
                ElseIf TypeOf c Is DateTimePicker Then
                    param.Valore = c.Text
                ElseIf TypeOf c Is ComboBox Then
                    With DirectCast(c, ComboBox)
                        If .SelectedIndex < 0 And Trim(c.Text) <> vbNullString Then
                            param.Valore = Trim(c.Text)
                        ElseIf .SelectedIndex >= 0 Then
                            param.Valore = .SelectedValue
                        End If
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

    Private Sub frmParametri_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        'If Text.UBound > 0 Then
        'Text(1).Focus()
        'End If
    End Sub

    Private Sub frmParametri_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim l As Long 'Left
        Dim h As Long 'height
        Dim w As Long 'width
        Dim dh As Long 'variazione di height

        Dim sBox As String 'tipo controllo
        Dim sValue As String = ""
        Dim sCaption As String

        'Dim g As Graphics
        'g = Me.CreateGraphics
        'MsgBox("DpiX=" & g.DpiX & " DpiY=" & g.DpiY)

        ' 1440 twips  / 96 pix = 15 twips / pix
        '       inc        inc

        l = 150 / 15
        dh = 500 / 15
        h = -dh / 2
        w = Frame_Ricerca.Width - 2 * l

        Dim param As CParametro
        For Each param In _Parametri.Values
            With param
                If Not param.Nascosto Then
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

                    h += dh

                    Select Case sBox
                        Case "T" 'controllo TextBox
                            ' Carica il controllo
                            Dim txt = New System.Windows.Forms.TextBox()
                            Me.Frame_Ricerca.Controls.Add(txt)
                            With txt
                                .Text = sValue
                                '.ToolTipText = sCaption
                                .Tag = param.Key
                                .Location = New System.Drawing.Point(l, h + 13)
                                .Size = New System.Drawing.Size(w, 20)
                                'AddHandler .KeyPress, AddressOf TextBoxKeyPress
                                AddHandler .Validated, AddressOf ValuesChanged
                            End With

                            ' Carica la label
                            Dim lbl = New System.Windows.Forms.Label()
                            With lbl
                                Me.Frame_Ricerca.Controls.Add(lbl)
                                .AutoSize = True
                                .Location = New System.Drawing.Point(l, h)
                                .Size = New System.Drawing.Size(39, 13)
                                .Text = sCaption
                            End With

                        Case "D" 'controllo data pick
                            ' Carica il controllo
                            Dim txt = New System.Windows.Forms.DateTimePicker()
                            Me.Frame_Ricerca.Controls.Add(txt)
                            With txt
                                .Text = sValue
                                '.ToolTipText = sCaption
                                .Tag = param.Key
                                .Location = New System.Drawing.Point(l, h + 13)
                                .Size = New System.Drawing.Size(w, 20)
                                AddHandler .Validated, AddressOf ValuesChanged
                            End With

                            ' Carica la label
                            Dim lbl = New System.Windows.Forms.Label()
                            With lbl
                                Me.Frame_Ricerca.Controls.Add(lbl)
                                .AutoSize = True
                                .Location = New System.Drawing.Point(l, h)
                                .Size = New System.Drawing.Size(39, 13)
                                .Text = sCaption
                            End With

                        Case "C" ' Controllo ComboBox
                            ' Carica il controllo
                            Dim cmb = New System.Windows.Forms.ComboBox()
                            Me.Frame_Ricerca.Controls.Add(cmb)
                            With cmb
                                .DropDownStyle = ComboBoxStyle.DropDownList
                                .FormattingEnabled = True
                                .Tag = param.Key
                                If param.IsIndipendence Then
                                    RiempiComboBox(cmb, param, sValue)
                                End If
                                '.ToolTipText = sCaption
                                .Location = New System.Drawing.Point(l, h + 13)
                                .Size = New System.Drawing.Size(w, 20)
                                AddHandler .SelectedIndexChanged, AddressOf ValuesChanged
                            End With

                            ' Carica la label
                            Dim lbl = New System.Windows.Forms.Label()
                            With lbl
                                Me.Frame_Ricerca.Controls.Add(lbl)
                                .AutoSize = True
                                .Location = New System.Drawing.Point(l, h)
                                .Size = New System.Drawing.Size(39, 13)
                                .Text = sCaption
                            End With

                        Case "E" ' Controllo ComboBox - Edit
                            ' Carica il controllo
                            Dim cmb = New System.Windows.Forms.ComboBox()
                            Me.Frame_Ricerca.Controls.Add(cmb)
                            With cmb
                                .DropDownStyle = ComboBoxStyle.DropDown
                                .FormattingEnabled = True
                                .Tag = param.Key
                                If param.IsIndipendence Then
                                    RiempiComboBox(cmb, param, sValue)
                                End If
                                '.ToolTipText = sCaption
                                .Location = New System.Drawing.Point(l, h + 13)
                                .Size = New System.Drawing.Size(w, 20)

                                AddHandler .KeyPress, AddressOf ComboBoxKeyPress
                                AddHandler .SelectedIndexChanged, AddressOf ValuesChanged
                                AddHandler .Leave, AddressOf ValuesChanged
                            End With

                            ' Carica la label
                            Dim lbl = New System.Windows.Forms.Label()
                            With lbl
                                Me.Frame_Ricerca.Controls.Add(lbl)
                                .AutoSize = True
                                .Location = New System.Drawing.Point(l, h)
                                .Size = New System.Drawing.Size(39, 13)
                                .Text = sCaption
                            End With

                        Case "L" ' Controllo ListBoxBox

                            Dim lst = New System.Windows.Forms.ListBox()
                            Me.Frame_Ricerca.Controls.Add(lst)
                            With lst
                                .FormattingEnabled = True
                                .Tag = param.Key
                                If param.IsIndipendence Then
                                    RiempiListBox(lst, param, sValue)
                                End If
                                '.ToolTipText = sCaption
                                .Location = New System.Drawing.Point(l, h + 13)

                                If param.Altezza <= 0 Then param.Altezza = 5

                                .Size = New System.Drawing.Size(w, 4 + 15 * param.Altezza)
                                AddHandler .SelectedIndexChanged, AddressOf ListItemCheck
                            End With

                            ' Carica la label
                            Dim lbl = New System.Windows.Forms.Label()
                            With lbl
                                Me.Frame_Ricerca.Controls.Add(lbl)
                                .AutoSize = True
                                .Location = New System.Drawing.Point(l, h)
                                .Size = New System.Drawing.Size(39, 13)
                                .Text = sCaption
                            End With
                            h += 15 * (param.Altezza - 1)

                        Case "K" 'controllo CheckBox
                            ' Carica il controllo
                            Dim chk = New System.Windows.Forms.CheckBox()
                            Me.Frame_Ricerca.Controls.Add(chk)
                            With chk
                                .Text = sCaption
                                '.ToolTipText = sCaption
                                .Tag = param.Key
                                .Checked = (sValue = "true")

                                .Location = New System.Drawing.Point(l, h + 13)
                                .Size = New System.Drawing.Size(w, 20)
                                AddHandler .CheckedChanged, AddressOf ValuesChanged
                            End With
                    End Select
                End If
            End With
        Next

        Control_Click(Me.Controls(0))

        ' Altezza frame di ricerca
        h = h + dh + 150 / 15
        Frame_Ricerca.Height = h

        ' Posizione label contrassegno
        'lblContrassegno.Top = H

        ' Posizione frame di Azione
        'H = H + 700 / 15
        'lblLine.Top = H - 200/96
        'cmdConferma.Top = H
        'cmdAnnulla.Top = H


        ' Altezza complessiva della finestra
        h += Panel1.Height
        Me.Height = h + 50
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
                Dim rs = Utx.FunzioniDb.CreaDataTableReader(_Parametri.ReplaceParam(param.Elencovalori))
                If rs IsNot Nothing Then
                    While rs.Read()
                        items.Add(New SimpleItem(rs.GetValue(0).ToString, rs.GetValue(1).ToString))
                    End While
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

    Private Sub RiempiListBox(lst As ListBox, param As CParametro, sValue As String)
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
                Dim rs = Utx.FunzioniDb.CreaDataTableReader(_Parametri.ReplaceParam(param.Elencovalori))
                If rs IsNot Nothing Then
                    While rs.Read()
                        items.Add(New SimpleItem(rs.GetValue(0).ToString, rs.GetValue(1).ToString))
                    End While
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
                    For Each i As SimpleItem In lst.Items
                        If i.Codice = v Then
                            lst.SelectedItems.Add(i)
                            Exit For
                        End If
                    Next
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
                    Dim sCode As String = UCase(Trim(.Text))
                    For i As Integer = 0 To .Items.Count - 1
                        If .Items(0) = sCode Then
                            .SelectedIndex = i
                            Exit Sub
                        End If
                    Next
                End If
            End With
        End If
    End Sub

    Private Sub ListItemCheck(sender As Object, e As System.EventArgs)
        'If item = 0 Then
        '    For i = 1 To List(Index).ListCount - 1
        '        List(Index).Selected(i) = List(Index).Selected(0)
        '    Next
        'End If

        If ValorizzaParametro(sender) Then
            Control_Click(sender)
        End If
    End Sub

    Private Sub Control_Click(parent As Control)
        Static oneTime As Boolean
        Dim c As Control
        Dim param As CParametro

        If oneTime = False Then
            oneTime = True
            For Each c In Me.Frame_Ricerca.Controls
                If c.Tag <> vbNullString Then
                    If (c IsNot parent) Then
                        param = _Parametri(c.Tag)
                        If Not param Is Nothing Then
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