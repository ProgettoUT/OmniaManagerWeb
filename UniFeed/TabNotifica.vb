Imports System.Text
Imports System.Windows.Forms

Public Class TabNotifica

    Dim Pagina As New TabPage
    Dim lb As New Label

    Sub New()

        Pagina.Name = "Dettaglio"
        Pagina.Text = Pagina.Name
        Pagina.Controls.Add(lb)

        lb.Dock = DockStyle.Fill
        lb.Padding = New Padding(5)

        Dim Notifica As New StringBuilder


        Notifica.AppendLine("Sono stati scaricati e pronti per l'importazione i seguenti aggiornamenti:")
        Notifica.AppendLine()

        If ContainsKey("00,16,17") Then
            Notifica.AppendLine("  - Clienti")
        End If
        If ContainsKey("01,02,05,06,07,08,70") Then
            Notifica.AppendLine("  - Polizze")
        End If
        If ContainsKey("14,15") Then
            Notifica.AppendLine("  - Quietanzamento")
        End If
        If ContainsKey("21,22,23,24,25,26,27,28,29,30,31") Then
            Notifica.AppendLine("  - Titoli")
        End If
        If ContainsKey("91, 92") Then
            Notifica.AppendLine("  - Sinistri")
        End If

        Notifica.AppendLine()
        Notifica.AppendLine("Per completare il processo entrare in Importa dati e rispondere SI alla richiesta di procedere con l'importazione.")

        lb.Text = Notifica.ToString
    End Sub

    Public ReadOnly Property NotificaDati() As TabPage
        Get
            Return Pagina
        End Get
    End Property

    Public Function ContainsKey(ByRef valori As String) As Boolean
        For Each valore As String In valori.Split(","c)
            If Globale.Report.DettaglioPerTipoRecord.ContainsKey(valore) Then
                Return True
            End If
        Next

        Return False
    End Function
End Class
