Imports System.IO

Public Class Esitati

    Friend Shared Sub ControlloFileEsitati(FileDati As String,
                                           ByRef e As ExportEventArgs)
        Try
            'controllo il formato del file scaricato. alcune volte vengono scaricati file html o comunque non congruenti
            If String.IsNullOrEmpty(FileDati) Then
                MsgBox("Non è stato possibile scaricare il file contenente i dati. Probabile errore non previsto in Essig Unipol/Unisalute.", MsgBoxStyle.Exclamation, Utx.Globale.TitoloApp)
                Globale.Log.Info("Non è stato possibile scaricare il file contenente i dati. Probabile errore non previsto in Essig Unipol/Unisalute.")
                e.Errore = True
            Else
                Using sr As New StreamReader(FileDati)
                    Dim Riga As String = sr.ReadLine

                    If Riga Is Nothing Then
                        e.Errore = False 'non c'è errore il file è vuoto
                    Else
                        If (Riga.ToUpper.StartsWith("TIPO;") = False) AndAlso
                           (Riga.ToUpper.StartsWith("NOINCASSI") = False) Then

                            Globale.Log.Info(String.Format("File dati non valido: {0}", Path.GetFileName(FileDati)))
                            Globale.Log.Info(String.Format("Intestazione file: {0}", Riga))

                            e.Messaggio = String.Format("File dati non valido:{0}{1}",
                                                        Environment.NewLine,
                                                        Path.GetFileName(FileDati))
                            e.Errore = True
                        End If
                    End If
                End Using
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
        End Try
    End Sub
End Class
