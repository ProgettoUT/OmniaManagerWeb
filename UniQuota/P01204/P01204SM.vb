Namespace P01204
    <Serializable()> Public Class P01204SM

        Public Function percentualeIPF05(ByVal gradoInvalidita As Integer) As Decimal
            If gradoInvalidita <= 5 Then
                Return 0
            ElseIf gradoInvalidita <= 14 Then
                Return gradoInvalidita - 5
            Else
                Return percentualeIPF00(gradoInvalidita)
            End If
        End Function

        Public Function percentualeIPF30(ByVal gradoInvalidita As Integer) As Decimal
            If gradoInvalidita <= 30 Then
                Return 0
            Else
                Return 100
            End If
        End Function

        Public Function percentualeIPF03(ByVal gradoInvalidita As Integer) As Decimal
            If gradoInvalidita <= 3 Then
                Return 0
            ElseIf gradoInvalidita <= 14 Then
                Return gradoInvalidita - 3
            Else
                Return percentualeIPF00(gradoInvalidita)
            End If
        End Function

        Public Function percentualeIPF00(ByVal gradoInvalidita As Integer) As Decimal
            If gradoInvalidita <= 30 Then
                Return gradoInvalidita
            ElseIf gradoInvalidita <= 49 Then
                Return Math.Ceiling(1.5D * gradoInvalidita)
            ElseIf gradoInvalidita <= 79 Then
                Return 100
            ElseIf gradoInvalidita <= 99 Then
                Return 150
            Else
                Return 250
            End If
        End Function

        Public Function percentualeIPFUS(ByVal gradoInvalidita As Integer) As Decimal
            If gradoInvalidita = 1 Then
                Return 0.3D
            ElseIf gradoInvalidita = 2 Then
                Return 0.6D
            ElseIf gradoInvalidita = 3 Then
                Return 1D
            ElseIf gradoInvalidita = 4 Then
                Return 1.5D
            Else
                Return percentualeIPF03(gradoInvalidita)
            End If
        End Function


        Public Function indennizzoIPF05(ByVal sommaAssicurata As Decimal, ByVal gradoInvalidita As Integer) As Decimal
            Return sommaAssicurata * percentualeIPF05(gradoInvalidita) / 100D
        End Function

        Public Function indennizzoIPF30(ByVal sommaAssicurata As Decimal, ByVal gradoInvalidita As Integer) As Decimal
            Return sommaAssicurata * percentualeIPF30(gradoInvalidita) / 100D
        End Function

        Public Function indennizzoIPF03(ByVal sommaAssicurata As Decimal, ByVal gradoInvalidita As Integer) As Decimal
            Return sommaAssicurata * percentualeIPF03(gradoInvalidita) / 100D
        End Function

        Public Function indennizzoIPF00(ByVal sommaAssicurata As Decimal, ByVal gradoInvalidita As Integer) As Decimal
            Return sommaAssicurata * percentualeIPF00(gradoInvalidita) / 100D
        End Function

        Public Function indennizzoIPFUS(ByVal sommaAssicurata As Decimal, ByVal gradoInvalidita As Integer) As Decimal
            Return sommaAssicurata * percentualeIPFUS(gradoInvalidita) / 100D
        End Function

        Public Function indennizzoIPFFD(ByVal sommaAssicurata As Decimal, ByVal gradoInvalidita As Integer) As Decimal
            Return sommaAssicurata * (percentualeIPF00(gradoInvalidita) + percentualeIPF03(gradoInvalidita) + percentualeIPF05(gradoInvalidita)) / 300D
        End Function


        Public Function GetTable(assicurato As assicurato, ByVal sommaAssicurata As Decimal, ByVal gradoInvalidita As Integer) As DataTable

            Dim costoF05 As Decimal = assicurato.CoperturaInfortuniIPClassic.PremioCrudo
            Dim costoF30 As Decimal = assicurato.CoperturaInfortuniIPTopTarget.PremioCrudo
            Dim costoF00 As Decimal = costoF05 + assicurato.CoperturaInfortuniFranchigia0.PremioCrudo
            Dim costoF03 As Decimal = costoF05 + assicurato.CoperturaInfortuniFranchigia3.PremioCrudo
            Dim costoFUS As Decimal = costoF05 + assicurato.CoperturaInfortuniFranchigiaPlus.PremioCrudo
            Dim costoFFD As Decimal = costoF05 + assicurato.CoperturaInfortuniFranchigiaDiff.PremioCrudo

            ' Create new DataTable instance.
            Dim table As New DataTable

            ' Create four typed columns in the DataTable.
            table.Columns.Add("Franchigia", GetType(String))
            table.Columns.Add("Indennizzo", GetType(Double))
            table.Columns.Add("Costo_Garanzia", GetType(Double))
            table.Columns.Add("Costo_Garanzia/Indennizzo", GetType(Double))
            table.Columns.Add("Risparmio", GetType(Double))
            table.Columns.Add("Somma Assicurata equivalente", GetType(Double))
            table.Columns.Add("Incremento", GetType(Double))
            table.Columns.Add("Totale", GetType(Double))

            ' Add five rows with those columns filled in the DataTable.
            AddRow(table, "Franchigia 0%", sommaAssicurata, indennizzoIPF00(sommaAssicurata, gradoInvalidita), costoF00, costoF00)
            AddRow(table, "Franchigia 3%", sommaAssicurata, indennizzoIPF03(sommaAssicurata, gradoInvalidita), costoF03, costoF00)
            AddRow(table, "Franchigia 5%", sommaAssicurata, indennizzoIPF05(sommaAssicurata, gradoInvalidita), costoF05, costoF00)
            AddRow(table, "Franchigia UnipolSai plus", sommaAssicurata, indennizzoIPFUS(sommaAssicurata, gradoInvalidita), costoFUS, costoF00)
            AddRow(table, "Franchigia Top target 30%", sommaAssicurata, indennizzoIPF30(sommaAssicurata, gradoInvalidita), costoF30, costoF00)
            AddRow(table, "Franchigie differenziate", sommaAssicurata, indennizzoIPFFD(sommaAssicurata, gradoInvalidita), costoFFD, costoF00)

            Return table
        End Function

        Public Sub AddRow(table As DataTable, franchigia As String, sommaAssicurata As Decimal, indennizzo As Decimal, costoGaranzia As Decimal, costoRiferimento As Decimal)
            If indennizzo = 0 Then
                table.Rows.Add(franchigia, indennizzo, costoGaranzia, Nothing,
                               costoRiferimento - costoGaranzia,
                               sommaAssicurata * costoRiferimento / costoGaranzia,
                               indennizzo * (costoRiferimento - costoGaranzia) / costoGaranzia,
                               indennizzo * costoRiferimento / costoGaranzia)
            Else
                table.Rows.Add(franchigia, indennizzo, costoGaranzia, 100 * costoGaranzia / indennizzo,
                               costoRiferimento - costoGaranzia,
                               sommaAssicurata * costoRiferimento / costoGaranzia,
                               indennizzo * (costoRiferimento - costoGaranzia) / costoGaranzia,
                               indennizzo * costoRiferimento / costoGaranzia)
            End If
        End Sub
    End Class
End Namespace
