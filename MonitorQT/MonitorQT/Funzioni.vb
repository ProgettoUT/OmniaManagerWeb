Imports System.IO

Module Funzioni

    Friend Function PcToCompagnia() As Int16
        If IsNumeric(Left(System.Environment.MachineName, 1)) Then
            Return 6
        Else
            Return 1
        End If
    End Function

    Friend Function DataUSA(DataIT As String) As String
        Try
            DataUSA = "#" + Format(CDate(DataIT), "MM/dd/yyyy") + "#"
        Catch ex As Exception
            ' sono compresi i casi "00-00-0000" e "99-99-9999" e stringa vuota
            DataUSA = "Null"
        End Try
    End Function

    Friend Function DataInizioMese(Data As Date) As Date
        Dim d As New System.DateTime(Data.Year, Data.Month, 1)
        DataInizioMese = d
    End Function

    Friend Function DataFineMese(Data As Date) As Date
        Dim d As New System.DateTime(Data.Year, Data.Month, System.DateTime.DaysInMonth(Data.Year, Data.Month))
        DataFineMese = d
    End Function

    Friend Function NumeroUSA(Numero As String) As String
        NumeroUSA = Replace(Numero, ",", ".")
    End Function

    Friend Function Coeff2Perc(Coefficiente As Double) As String
        If Coefficiente > 0 Then
            Return Format(1 - Coefficiente, "#0.00%")
        Else
            Return "-"
        End If
    End Function

    Friend Function CoefficienteFraz(Frazionamento As Int16) As Double
        Select Case Frazionamento
            Case 2
                CoefficienteFraz = 1.03
            Case 3
                CoefficienteFraz = 1.04
            Case 4
                CoefficienteFraz = 1.05
            Case Else
                CoefficienteFraz = 1
        End Select
    End Function

    Friend Function Zero() As String
        Zero = "0,00"
    End Function

    Friend Function FormIt(Importo As Double) As String
        FormIt = Format(Importo, "###,##0.00")
    End Function

    Friend Function TipoQuietanza(ByRef r As DataGridViewRow) As String
        Select Case r.Cells("TipoQT").Value
            Case "D"
                TipoQuietanza = "Divisionale"
            Case "K"
                TipoQuietanza = "Km sicuri"
            Case "M"
                TipoQuietanza = "Migrazione"
            Case Else
                TipoQuietanza = ""
        End Select
    End Function
End Module
