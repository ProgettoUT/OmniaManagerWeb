Class Tracciato
    Public Lunghezza As Integer
    Public ReadOnly Tabelle As New Tabelle
    Public ReadOnly Campi As New Campi
    Public ReadOnly CampiChiavi As New Campi
    Public Foglio As String

    Public IfCase As Boolean
    Public IfLength As Boolean
    Public DeleteFirst As Boolean
    Public Obsoleto As Boolean
    Public PerEsportazione As Boolean
    Public TipoRecord As String

    Public Function BuildKeyTracciato(ifcase As String, iflength As String) As String
        Me.IfCase = ifcase <> vbNullString
        Me.IfLength = iflength <> vbNullString

        BuildKeyTracciato = ""

        If Me.IfCase Then
            BuildKeyTracciato = "/" & ifcase
        End If

        If iflength Then
            BuildKeyTracciato &= "/L" & iflength
        End If
        Return BuildKeyTracciato
    End Function



    Public Sub WriteValore()
        Campi.WriteValore()
    End Sub

    Public Sub Buid()
        For Each oCampo In Campi.Values
            If oCampo.NomeChiave <> vbNullString Then
                CampiChiavi.Add(oCampo.Nome, oCampo)
            End If
        Next
    End Sub

    Public Sub ApplyValue(oTabella As Tabella, Optional index As Integer = 1)
        For Each oCampo In oTabella.Campi.Values
            If Campi.ContainsKey(oCampo.NomeRif) Then
                If oCampo.HasDefault AndAlso Campi(oCampo.NomeRif).ValoreOriginale.Trim.Length = 0 Then
                    oCampo.Valore = oCampo.DefaultSeNullo
                Else
                    oCampo.Valore = Campi(oCampo.NomeRif).ValoreOriginale
                End If
            ElseIf oTabella.PerOccorrenzaDi IsNot Nothing AndAlso Campi.ContainsKey(oTabella.PerOccorrenzaDi) Then
                With Campi(oTabella.PerOccorrenzaDi)
                    If .Campi(.Nome & index).Campi.ContainsKey(oCampo.NomeRif) Then
                        If oCampo.HasDefault AndAlso .Campi(.Nome & index).Campi(oCampo.NomeRif).ValoreOriginale.Trim.Length = 0 Then
                            oCampo.Valore = oCampo.DefaultSeNullo
                        Else
                            oCampo.Valore = .Campi(.Nome & index).Campi(oCampo.NomeRif).ValoreOriginale
                        End If
                    End If
                End With
            End If
        Next
    End Sub

    Public Sub ImpostaParametriChiaviInterne()

        For Each oCampo In CampiChiavi.Values
            For Each iCampo In oCampo.Campi.Values
                iCampo.Valore = Campi(iCampo.NomeRif).ValoreOriginale
            Next
        Next
    End Sub

    Public Function HaChiaviInterne() As Boolean
        HaChiaviInterne = Not (CampiChiavi Is Nothing)
    End Function

End Class
