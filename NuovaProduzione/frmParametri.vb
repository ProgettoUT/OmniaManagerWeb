Imports System.IO

Public Class frmParametri

    Private Sub EnabledControls(value As Boolean)
        txtDataMin.Enabled = value
        txtDataMax.Enabled = value
        txtAnnoPrecedente.Enabled = value
        txtEscludiSostituzioniAuto.Enabled = value
        txtIncludiRegolazioni.Enabled = value
        txtSubAgenti.Enabled = value
        txtRamiGestione.Enabled = value
        comboBoxMacroRami.Enabled = value
        txtProdotti.Enabled = value
        txtConvenzioni.Enabled = value
        txtPdfColore.Enabled = value

        If value = True Then
            txtProdottiIncludi.Enabled = txtProdottiIncludi.Tag
            txtProdottiEscludi.Enabled = txtProdottiEscludi.Tag
            txtConvenzioniIncludi.Enabled = txtConvenzioniIncludi.Tag
            txtConvenzioniEscludi.Enabled = txtConvenzioniEscludi.Tag
        Else
            txtProdottiIncludi.Tag = txtProdottiIncludi.Enabled
            txtProdottiEscludi.Tag = txtProdottiEscludi.Enabled
            txtConvenzioniIncludi.Tag = txtConvenzioniIncludi.Enabled
            txtConvenzioniEscludi.Tag = txtConvenzioniEscludi.Enabled

            txtProdottiIncludi.Enabled = value
            txtProdottiEscludi.Enabled = value
            txtConvenzioniIncludi.Enabled = value
            txtConvenzioniEscludi.Enabled = value
        End If

        cmdAnnulla.Enabled = value
        cmdPdf.Enabled = value
        cmdExcell.Enabled = value

        If value = True Then
            Cursor.Current = Cursors.Default
        Else
            Cursor.Current = Cursors.WaitCursor
        End If
    End Sub

    Private Sub cmdPdf_Click(sender As System.Object, e As System.EventArgs) Handles cmdPdf.Click
        Dim sPdf As String
        Dim sSubAgenti As String = ""
        Dim sProduttori As String = ""
        Dim sRamiGestione As String = ""

        If ValidaInput() = False Then Exit Sub

        EnabledControls(False)

        Try

            If txtSubAgenti.CheckedIndices(0) > 0 Then
                For Each i As Item In txtSubAgenti.CheckedItems
                    If i.Key < 1000 Then
                        If sSubAgenti <> "" Then sSubAgenti &= ","
                        sSubAgenti &= i.Key
                    Else
                        If sProduttori <> "" Then sProduttori &= ","
                        sProduttori &= i.Key
                    End If
                Next
            End If

            If txtRamiGestione.CheckedIndices(0) > 0 Then
                For Each i As Item In txtRamiGestione.CheckedItems
                    If sRamiGestione <> "" Then sRamiGestione &= ","
                    sRamiGestione &= i.Key
                Next
            End If

            Dim sProdotti As String = IIf(txtProdotti.Text = txtProdotti.Tag, "", txtProdotti.Text)
            Dim sConvenzioni As String = IIf(txtConvenzioni.Text = txtConvenzioni.Tag, "", txtConvenzioni.Text)

            sPdf = CreaReport(txtDataMin.Value _
                            , txtDataMax.Value _
                            , txtAnnoPrecedente.Checked _
                            , ToArray(sSubAgenti) _
                            , ToArray(sProduttori) _
                            , ToArray(sRamiGestione) _
                            , txtEscludiSostituzioniAuto.Checked _
                            , txtIncludiRegolazioni.Checked _
                            , ToArray(sProdotti) _
                            , txtProdottiEscludi.Checked And sProdotti <> "" _
                            , ToArray(sConvenzioni) _
                            , txtConvenzioniEscludi.Checked And sConvenzioni <> "" _
                            , txtPdfColore.Checked)

            If sPdf <> vbNullString Then
                Process.Start(sPdf)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        EnabledControls(True)
    End Sub

    Private Sub cmdExcell_Click(sender As System.Object, e As System.EventArgs) Handles cmdExcell.Click
        Dim sSubAgenti As String = ""
        Dim sProduttori As String = ""
        Dim sRamiGestione As String = ""

        If ValidaInput() = False Then Exit Sub
        EnabledControls(False)

        Try
            If txtSubAgenti.CheckedIndices(0) > 0 Then
                For Each i As Item In txtSubAgenti.CheckedItems
                    If i.Key < 1000 Then
                        If sSubAgenti <> "" Then sSubAgenti &= ","
                        sSubAgenti &= i.Key
                    Else
                        If sProduttori <> "" Then sProduttori &= ","
                        sProduttori &= i.Key
                    End If
                Next
            End If

            If txtRamiGestione.CheckedIndices(0) > 0 Then
                For Each i As Item In txtRamiGestione.CheckedItems
                    If sRamiGestione <> "" Then sRamiGestione &= ","
                    sRamiGestione &= i.Key
                Next
            End If

            Dim sProdotti As String = IIf(txtProdotti.Text = txtProdotti.Tag, "", txtProdotti.Text)
            Dim sConvenzioni As String = IIf(txtConvenzioni.Text = txtConvenzioni.Tag, "", txtConvenzioni.Text)

            Dim sql As String = GeneraDettaglioProduzione _
                               (txtDataMin.Value _
                              , txtDataMax.Value _
                              , ToArray(sSubAgenti) _
                              , ToArray(sProduttori) _
                              , ToArray(sRamiGestione) _
                              , txtEscludiSostituzioniAuto.Checked _
                              , txtIncludiRegolazioni.Checked _
                              , ToArray(sProdotti) _
                              , txtProdottiEscludi.Checked _
                              , ToArray(sConvenzioni) _
                              , txtConvenzioniEscludi.Checked)

            Dim FileName As String = System.IO.Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "report." & Now.Ticks & ".csv")
            ' Imposta il file di output
            If Not System.IO.Directory.Exists(Utx.Globale.Paths.CartellaTempUtente) Then
                FileName = System.IO.Path.Combine(System.IO.Path.GetTempPath, "report." & Now.Ticks & ".csv")
            End If

            If File.Exists(FileName) Then
                File.Delete(FileName)
            End If

            Dim FileNumber As Integer = FreeFile()
            FileOpen(FileNumber, FileName, OpenMode.Output)

            'Print(FileNumber, "<html><body><table>")
            'With CreaRecordset(sql)
            '        Print(FileNumber, vbNewLine, "<tr>")
            '        For i As Integer = 0 To .FieldCount - 1
            '            Print(FileNumber, "<td><b>", .GetName(i), "</b></td>")
            '        Next
            '        Print(FileNumber, "</tr>", vbNewLine)
            '
            '    Do While .Read
            '        Print(FileNumber, vbNewLine, "<tr>")
            '        For i As Integer = 0 To .FieldCount - 1
            '            If .IsDBNull(i) Then
            '                Print(FileNumber, "<td></td>")
            '            Else
            '                Print(FileNumber, "<td>", .GetValue(i), "</td>")
            '            End If
            '        Next
            '        Print(FileNumber, "</tr>", vbNewLine)
            '    Loop
            'End With
            'Print(FileNumber, vbNewLine, "</table></body></html>")

            With Utx.FunzioniDb.CreaDataTableReader(sql)
                For i As Integer = 0 To .FieldCount - 1
                    Print(FileNumber, .GetName(i), ";")
                Next
                Print(FileNumber, vbNewLine)

                Do While .Read
                    For i As Integer = 0 To .FieldCount - 1
                        If .IsDBNull(i) Then
                            Print(FileNumber, ";")
                        Else
                            Print(FileNumber, .GetValue(i), ";")
                        End If
                    Next
                    Print(FileNumber, vbNewLine)
                Loop
            End With

            FileClose(FileNumber)

            If FileName <> vbNullString Then
                Process.Start(FileName)
                'Call Shell("rundll32.exe url.dll,FileProtocolHandler " & (FileName), AppWinStyle.MaximizedFocus)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        EnabledControls(True)
    End Sub

    Public Sub New()
        ' Chiamata richiesta da Progettazione Windows Form.
        InitializeComponent()

        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Font = Utx.AppFont.Normal

        InitializeControls()

        txtProdottiConvenzioni_Leave(txtProdotti, Nothing)
        txtProdottiConvenzioni_Leave(txtConvenzioni, Nothing)

#If DEBUG Then
        Me.Text &= " [Debug]"
#ElseIf VALUTAZIONE Then
    Me.Text &= " [Copia per valutazione]"
#End If
    End Sub

    Public Sub InitializeControls()
        Try
            Dim anno As Integer = Date.Today.Year
            Dim mese As Integer

            If Date.Today.Month = Date.Today.AddDays(1).Month Then
                mese = Date.Today.Month - 1
            Else
                mese = Date.Today.Month
            End If

            If mese = 0 Then
                mese = 12
                anno -= 1
            End If

            Dim data As New Date(anno, mese, 1)
            data.AddMonths(1).AddDays(-1)

            txtDataMin.Value = New Date(anno, 1, 1)
            txtDataMax.Value = data.AddMonths(1).AddDays(-1)

            With cmdHelp
                .Padding = Utx.AppFont.ButtonPadding
                .FlatStyle = FlatStyle.Flat
                .FlatAppearance.BorderColor = Color.Silver
                .Image = Risorse.Immagini.Bitmap("help")
            End With
            With cmdExcell
                .Padding = Utx.AppFont.ButtonPadding
                .FlatStyle = FlatStyle.Flat
                .FlatAppearance.BorderColor = Color.Silver
                .Image = Risorse.Immagini.Bitmap("excel")
            End With
            With cmdPdf
                .Padding = Utx.AppFont.ButtonPadding
                .FlatStyle = FlatStyle.Flat
                .FlatAppearance.BorderColor = Color.Silver
                .Image = Risorse.Immagini.Image("pdf")
            End With
            With cmdAnnulla
                .Padding = Utx.AppFont.ButtonPadding
                .FlatStyle = FlatStyle.Flat
                .FlatAppearance.BorderColor = Color.Silver
                .Image = Risorse.Immagini.Bitmap("esci")
            End With
#If DEBUG Then
            'txtDataMin.Value = #1/1/2010#
            'txtDataMax.Value = #1/31/2010#
#End If


            With txtRamiGestione.Items
                .Add(New Item("-1", "Tutti"), True)
                ''.Add(New Item("-2", "Danni"))
                ''.Add(New Item("-4", "Auto"))
                '.Add(New Item("1", "Responsabilita' Civile Auto"), True)
                '.Add(New Item("2", "Auto Rischi Diversi"), True)
                ''.Add(New Item("-5", "Rami Elementari"))
                ''.Add(New Item("-6", "Persone"))
                '.Add(New Item("3", "Infortuni"), True)
                '.Add(New Item("4", "Malattie"), True)
                '.Add(New Item("5", "Rischi Diversi Persone"), True)
                '.Add(New Item("21", "Tutela Legale"), True)
                '.Add(New Item("22", "Assistenza"), True)
                ''.Add(New Item("-7", "Aziende"))
                '.Add(New Item("6", "Incendio Rischi Ordinari"), True)
                '.Add(New Item("7", "Incendio Rischi Industriali"), True)
                '.Add(New Item("8", "Rischi Tecnologici"), True)
                '.Add(New Item("9", "Furto"), True)
                '.Add(New Item("10", "Responsabilita' Civile Generale"), True)
                ''.Add(New Item("-8", "Altri Rami"))
                '.Add(New Item("11", "Trasporti"), True)
                '.Add(New Item("12", "Aeronautica"), True)
                '.Add(New Item("13", "Cauzioni"), True)
                '.Add(New Item("14", "Credito"), True)
                '.Add(New Item("15", "Rischio Impiego"), True)
                '.Add(New Item("16", "Grandine"), True)
                '.Add(New Item("17", "Bestiame"), True)
                ''.Add(New Item("-3", "Vita"))
                '.Add(New Item("18", "Vita Individuali"), True)
                '.Add(New Item("19", "Vita Collettive"), True)
                '.Add(New Item("20", "Vita Fondi Pensione"), True)
                With Utx.FunzioniDb.CreaDataTableReader("SELECT TRIM(STR(RamoGestione)), DescRamoGest FROM RamoGest ORDER BY RamoGestione")
                    Do While .Read
                        txtRamiGestione.Items.Add(New Item(.GetString(0), .GetString(1)), True)
                    Loop
                End With
            End With

            With comboBoxMacroRami.Items
                .Add(New Item("T", "Tutti i rami"))
                .Add(New Item("A", "Rami auto"))
                .Add(New Item("E", "Rami elementari"))
                .Add(New Item("P", "Rami persone"))
                .Add(New Item("I", "Rami aziende"))
                .Add(New Item("R", "Altri Rami"))
                .Add(New Item("V", "Rami vita"))
            End With
            comboBoxMacroRami.SelectedIndex = 0

            txtSubAgenti.Items.Add(New Item("-1", "TUTTI"), True)
            With Utx.FunzioniDb.CreaDataTableReader("SELECT TRIM(STR(Cip)), FORMAT(Cip,'0000') + ' - ' + DeskCip 
                FROM Cip 
                WHERE Cip BETWEEN 1 AND 9999 
                GROUP BY Cip,DeskCip
                ORDER BY 2")
                Do While .Read
                    txtSubAgenti.Items.Add(New Item(.GetString(0), .GetString(1)), True)
                Loop
            End With

            ComboBoxGruppi.Items.Add(New ItemGroup("-1", "Tutti i produttori oppure Seleziona un gruppo ...", Nothing))
            With Utx.FunzioniDb.CreaDataTableReader("SELECT Gruppo,Descrizione,Cip 
                FROM GruppiCip 
                WHERE Descrizione > '' AND Cip > 0 
                ORDER BY 1, 3")
                Dim cips As New List(Of Integer)
                Dim gruppo As Integer = 0
                Dim desk As String = ""

                Do While .Read
                    If gruppo = 0 Then
                        gruppo = .GetInt32(0)
                        desk = .GetString(1)
                        cips.Add(.GetInt32(2))
                    ElseIf gruppo = .GetInt32(0) Then
                        cips.Add(.GetInt32(2))
                    Else
                        ComboBoxGruppi.Items.Add(New ItemGroup(gruppo, desk, cips))
                        gruppo = .GetInt32(0)
                        desk = .GetString(1)
                        cips = New List(Of Integer)
                        cips.Add(.GetInt32(2))
                    End If
                Loop
                ComboBoxGruppi.Items.Add(New ItemGroup(gruppo, desk, cips))
            End With
            ComboBoxGruppi.SelectedIndex = 0

            AddHandler txtRamiGestione.ItemCheck, AddressOf ListItemCheck
            AddHandler txtSubAgenti.ItemCheck, AddressOf ListItemCheck
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub ComboBoxGruppi_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBoxGruppi.SelectedIndexChanged
        With CType(ComboBoxGruppi.SelectedItem, ItemGroup)
            If .Key = -1 Then
                txtSubAgenti.SetItemChecked(0, True)
            Else
                For i As Integer = 1 To txtSubAgenti.Items.Count - 1
                    txtSubAgenti.SetItemChecked(i, .Cips.Contains(CInt(txtSubAgenti.Items(i).Key)))
                Next
            End If
        End With
    End Sub

    Private Sub comboBoxMacroRami_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles comboBoxMacroRami.SelectedIndexChanged
        With CType(comboBoxMacroRami.SelectedItem, Item)
            If .Key = "T" Then
                txtRamiGestione.SetItemChecked(0, True)
            Else
                txtRamiGestione.SetItemChecked(0, True)
                txtRamiGestione.SetItemChecked(0, False)
                If .Key = "A" Then
                    txtRamiGestione.SetItemChecked(1, True)
                    txtRamiGestione.SetItemChecked(2, True)
                End If
                If .Key = "E" Or .Key = "P" Then
                    txtRamiGestione.SetItemChecked(3, True)
                    txtRamiGestione.SetItemChecked(4, True)
                    txtRamiGestione.SetItemChecked(5, True)
                    txtRamiGestione.SetItemChecked(6, True)
                    txtRamiGestione.SetItemChecked(7, True)
                End If
                If .Key = "E" Or .Key = "I" Then
                    txtRamiGestione.SetItemChecked(8, True)
                    txtRamiGestione.SetItemChecked(9, True)
                    txtRamiGestione.SetItemChecked(10, True)
                    txtRamiGestione.SetItemChecked(11, True)
                    txtRamiGestione.SetItemChecked(12, True)
                End If
                If .Key = "E" Or .Key = "R" Then
                    txtRamiGestione.SetItemChecked(13, True)
                    txtRamiGestione.SetItemChecked(14, True)
                    txtRamiGestione.SetItemChecked(15, True)
                    txtRamiGestione.SetItemChecked(16, True)
                    txtRamiGestione.SetItemChecked(17, True)
                    txtRamiGestione.SetItemChecked(21, True)
                    txtRamiGestione.SetItemChecked(22, True)
                    txtRamiGestione.SetItemChecked(23, True)
                End If
                If .Key = "V" Then
                    txtRamiGestione.SetItemChecked(18, True)
                    txtRamiGestione.SetItemChecked(19, True)
                    txtRamiGestione.SetItemChecked(20, True)
                End If
            End If
        End With
    End Sub

    Private Function ToArray(stringa As String) As String()
        If stringa Is Nothing Or Trim(stringa) = "" Then Return Nothing
        Return stringa.Split(",")
    End Function

    Private Sub txtProdottiConvenzioni_Enter(sender As Object, e As System.EventArgs) Handles txtProdotti.Enter, txtConvenzioni.Enter
        With CType(sender, TextBox)
            If .Text = .Tag Then
                .Text = ""
            End If
        End With

        txtProdottiIncludi.Enabled = sender.Equals(txtProdotti)
        txtProdottiEscludi.Enabled = txtProdottiIncludi.Enabled

        txtConvenzioniIncludi.Enabled = sender.Equals(txtConvenzioni)
        txtConvenzioniEscludi.Enabled = txtConvenzioniIncludi.Enabled
    End Sub

    Private Sub txtProdottiConvenzioni_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtProdotti.KeyPress, txtConvenzioni.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(","c)) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtProdottiConvenzioni_Leave(sender As Object, e As System.EventArgs) Handles txtProdotti.Leave, txtConvenzioni.Leave
        With CType(sender, TextBox)
            If .Text = "" Then
                .Text = .Tag
            End If

            txtProdottiIncludi.Enabled = (txtProdotti.Text <> txtProdotti.Tag)
            txtProdottiEscludi.Enabled = txtProdottiIncludi.Enabled

            txtConvenzioniIncludi.Enabled = (txtConvenzioni.Text <> txtConvenzioni.Tag)
            txtConvenzioniEscludi.Enabled = txtConvenzioniIncludi.Enabled
        End With
    End Sub

    Private Sub cmdAnnulla_Click(sender As System.Object, e As System.EventArgs) Handles cmdAnnulla.Click
        Me.Close()
    End Sub

    Private Function ValidaInput() As Boolean
        If txtSubAgenti.CheckedIndices.Count = 0 Then
            MsgBox("Nessuna subagenzia selezionata", MsgBoxStyle.Exclamation)
            Return False
        End If

        If txtRamiGestione.CheckedIndices.Count = 0 Then
            MsgBox("Nessun ramo gestione selezionato", MsgBoxStyle.Exclamation)
            Return False
        End If

        Return True
    End Function

    Private Sub ListItemCheck(sender As System.Object, e As System.Windows.Forms.ItemCheckEventArgs)
        RemoveHandler txtRamiGestione.ItemCheck, AddressOf ListItemCheck
        RemoveHandler txtSubAgenti.ItemCheck, AddressOf ListItemCheck

        With CType(sender, CheckedListBox)
            If e.Index = 0 Then
                For i As Integer = 1 To .Items.Count - 1
                    .SetItemChecked(i, e.NewValue)
                Next
            ElseIf e.NewValue = CheckState.Unchecked Then
                .SetItemChecked(0, e.NewValue)
            End If
        End With

        AddHandler txtRamiGestione.ItemCheck, AddressOf ListItemCheck
        AddHandler txtSubAgenti.ItemCheck, AddressOf ListItemCheck
    End Sub

    Private Sub frmParametri_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If Directory.Exists(Utx.Globale.Paths.CartellaTempUtente) Then
            For Each file As String In Directory.GetFiles(Utx.Globale.Paths.CartellaTempUtente)
                If file.Contains("\report.") And file.EndsWith(".pdf") Then
                    Try
                        IO.File.Delete(file)
                    Catch ex As Exception
                    End Try
                End If
            Next
        End If
    End Sub

End Class

Class Item
    Public Key As String
    Public Text As String
    Public Sub New(Key As String, text As String)
        Me.Key = Key
        Me.Text = text
    End Sub

    Public Overrides Function ToString() As String
        Return Text
    End Function
End Class

Class ItemGroup
    Public Key As Integer
    Public Text As String
    Public Cips As List(Of Integer)

    Public Sub New(Key As Integer, text As String, cips As List(Of Integer))
        Me.Key = Key
        Me.Text = text
        Me.Cips = cips
    End Sub

    Public Overrides Function ToString() As String
        Return Text
    End Function
End Class

