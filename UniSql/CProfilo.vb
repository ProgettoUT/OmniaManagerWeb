Public Enum EAutType
    AUT_LETTURA = &H1                'r
    AUT_SCRITTURA = &H2              'w
    AUT_ELIMINAZIONE = &H4           'd
    AUT_ESECUZIONE = &H8             'x
    AUT_DOWNLOAD = &H10              'l
    AUT_ESPORTAZIONE = &H20          'e

    AUT_CONTROLLO_COMPLETO = AUT_LETTURA + AUT_SCRITTURA + AUT_ELIMINAZIONE + AUT_ESECUZIONE + AUT_DOWNLOAD + AUT_ESPORTAZIONE
End Enum

Public Class CProfilo

    Public Property Nome As String
    Public Property Consenti As Long
    Public Property Nega As Long

    Public Sub SetProfilo(sConsenti As String, sNega As String)
        Dim nCons As Integer
        Dim nNega As Integer

        If InStr(1, sConsenti, "r") > 0 Then nCons = nCons Or EAutType.AUT_LETTURA
        If InStr(1, sConsenti, "w") > 0 Then nCons = nCons Or EAutType.AUT_SCRITTURA
        If InStr(1, sConsenti, "d") > 0 Then nCons = nCons Or EAutType.AUT_ELIMINAZIONE
        If InStr(1, sConsenti, "x") > 0 Then nCons = nCons Or EAutType.AUT_ESECUZIONE
        If InStr(1, sConsenti, "l") > 0 Then nCons = nCons Or EAutType.AUT_DOWNLOAD
        If InStr(1, sConsenti, "e") > 0 Then nCons = nCons Or EAutType.AUT_ESPORTAZIONE

        If InStr(1, sNega, "r") > 0 Then nNega = nNega Or EAutType.AUT_LETTURA
        If InStr(1, sNega, "w") > 0 Then nNega = nNega Or EAutType.AUT_SCRITTURA
        If InStr(1, sNega, "d") > 0 Then nNega = nNega Or EAutType.AUT_ELIMINAZIONE
        If InStr(1, sNega, "x") > 0 Then nNega = nNega Or EAutType.AUT_ESECUZIONE
        If InStr(1, sNega, "l") > 0 Then nNega = nNega Or EAutType.AUT_DOWNLOAD
        If InStr(1, sNega, "e") > 0 Then nNega = nNega Or EAutType.AUT_ESPORTAZIONE

        Consenti = nCons
        Nega = nNega
    End Sub

End Class
