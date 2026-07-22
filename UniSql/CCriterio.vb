Public Interface ICriterio
    Property Parametri As CParametri
    Function RunTime() As Boolean
    Function AskNewParametri() As Boolean
End Interface

Public Class CCriterio
    Implements ICriterio

    Public Property Parametri As CParametri Implements ICriterio.Parametri

    Public Function RunTime() As Boolean Implements ICriterio.RunTime
        Return (_Parametri IsNot Nothing)
    End Function

    Public Function AskNewParametri() As Boolean Implements ICriterio.AskNewParametri
        Dim frm As frmParametri
        Dim result As Boolean = False

        If RunTime() Then
            frm = New frmParametri
            frm.Parametri = _Parametri
            frm.ShowDialog()

            If frm.Conferma Then
                frm.Close()
                frm.Dispose()
                result = True
            End If

            frm = Nothing
            Windows.Forms.Application.DoEvents()
        End If
        Return result
    End Function
End Class
