Imports System.IO

Module Funzioni

    'Public Sub ImpostaGrigliaStat()
    '    With frmMain.dgv1
    '        .Columns.Clear()
    '        .Font = New System.Drawing.Font("Tahoma", 9)
    '        .ReadOnly = True
    '        .AllowUserToAddRows = False
    '        .AllowUserToDeleteRows = False
    '        .AllowUserToOrderColumns = False
    '        .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '        'intestazione riga
    '        .Columns.Add("Desk", "Descrizione")

    '        'For k As Integer = frmMain.cboAnnoInizio.Text To frmMain.dtpFinoAl.Value.Year

    '        '    'anno
    '        '    Dim Colonna As String = k.ToString

    '        '    .Columns.Add(Colonna, Colonna)

    '        '    With .Columns(Colonna).DefaultCellStyle
    '        '        .Alignment = DataGridViewContentAlignment.MiddleCenter
    '        '        .BackColor = Color.Gold
    '        '    End With

    '        '    'diff numero
    '        '    Dim ColonnaDelta = Colonna + "Delta"

    '        '    .Columns.Add(ColonnaDelta, "Diff.Nr")

    '        '    With .Columns(ColonnaDelta).DefaultCellStyle
    '        '        .Alignment = DataGridViewContentAlignment.MiddleCenter
    '        '        .Format = "##,##0"
    '        '    End With

    '        '    'diff %
    '        '    Dim ColonnaPerc = Colonna + "Perc"

    '        '    .Columns.Add(ColonnaPerc, "Diff.%")

    '        '    With .Columns(ColonnaPerc).DefaultCellStyle
    '        '        .Alignment = DataGridViewContentAlignment.MiddleCenter
    '        '        .Format = "##0.00%"
    '        '    End With
    '        'Next
    '    End With

    'End Sub

    Friend Function DataFineMese(Data As Date) As Date
        Return New System.DateTime(Data.Year, _
                                   Data.Month, _
                                   System.DateTime.DaysInMonth(Data.Year, Data.Month)).Date
    End Function

    Friend Function DataInizioAnno(Data As Date) As Date
        Return New System.DateTime(Data.Year, 1, 1)
    End Function

    Friend Function DataInizioAnno(Anno As Integer) As Date
        Return New System.DateTime(Anno, 1, 1)
    End Function

    Friend Function DataFineAnno(Data As Date) As Date
        Return New System.DateTime(Data.Year, 12, 31)
    End Function

    Friend Function DataFineAnno(Anno As Integer) As Date
        Return New System.DateTime(Anno, 12, 31)
    End Function

    Friend Function WeekOfYear(DataRiferimento As Date) As Integer
        Try
            Return DateDiff(DateInterval.WeekOfYear, New DateTime(DataRiferimento.Year, 1, 1), DataRiferimento, , FirstWeekOfYear.Jan1)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Friend Function NumeroFile(PathDir As String) As Integer

        Try
            If Directory.Exists(PathDir) Then
                Return Directory.GetFiles(PathDir).Length()
            Else
                Return -1
            End If

        Catch ex As Exception
            Return -1
        End Try
    End Function
End Module
