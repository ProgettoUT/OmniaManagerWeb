Public Class UniSql
    Public Function ShowGridAndGetDataTable(sNameObj As String, ByRef Annulla As Boolean,
                                            Optional ApplyButtonText As String = Nothing,
                                            Optional ApplyButtonTip As String = Nothing,
                                            Optional ApplyButtonImage As System.Drawing.Image = Nothing,
                                            Optional scalaX As Integer = 100,
                                            Optional scalaY As Integer = 100) As DataTable
        Dim sql = New UniSql().GetSqlAsObject(sNameObj)

        If sql Is Nothing Then
            Return Nothing
        Else
            Dim f As New frmGrid(scalaX, scalaY)
            f.ApplyButton(ApplyButtonText, ApplyButtonTip, ApplyButtonImage)

            f.ExecuteMfs(sql)
            f.AutoEsegui = True
            f.ShowDialog()
            Annulla = f.Annulla
            Return Utils.gridGetAsDataTable(f.grdResult)
        End If

    End Function
    'Public Function GetDataTable(sNameObj As String) As DataTable
    '    Dim sql As String = GetSqlAsString(sNameObj)

    '    If sql = vbNullString Then
    '        Return Nothing
    '    Else
    '        Return Utx.FunzioniDb.CreaDataTable(sql)
    '    End If
    'End Function

    'Public Function GetDataTable(sNameObj As String, parametri As Dictionary(Of String, String)) As DataTable
    '    Dim sql As String = GetSqlAsString(sNameObj, parametri)

    '    If sql = vbNullString Then
    '        Return Nothing
    '    Else
    '        Return Utx.FunzioniDb.CreaDataTable(sql)
    '    End If
    'End Function

    Public Function GetSqlAsString(sNameObj As String, parametri As Dictionary(Of String, String)) As String
        Dim msgHelp As String = ""
        Dim sql As CManifestoSql = GetSqlAsObject(sNameObj)

        If sql Is Nothing Then Return vbNullString

        If parametri IsNot Nothing Then
            For Each parametro In parametri
                If sql.Parametri.Exists(parametro.Key) And parametro.Value IsNot Nothing Then
                    sql.Parametri(parametro.Key).Valore = parametro.Value
                Else
                    msgHelp &= " ," & parametro.Key
                End If
            Next
        End If

        If msgHelp.Length > 0 Then
            msgHelp = String.Format("Parametri non trovati nell'estrazione: {0}{1}", vbNewLine, msgHelp.Substring(2)) & vbNewLine & vbNewLine
        End If

        If parametri Is Nothing OrElse parametri.Count = 0 OrElse msgHelp.Length > 0 Then
            msgHelp &= "Parametri definiti:" & vbNewLine
            For Each parametro In sql.Parametri
                msgHelp &= parametro.Key & " = " & parametro.Value.Valore & vbNewLine
            Next
            MsgBox(msgHelp, MsgBoxStyle.Exclamation, "Parametri estrazione")
            Return vbNullString
        End If

        Return sql.GetSql(False)
    End Function

    Public Function GetSqlAsString(sNameObj As String) As String
        Dim sql As CManifestoSql = GetSqlAsObject(sNameObj)

        If sql Is Nothing Then
            Return vbNullString
        Else
            Return sql.GetSql()
        End If
    End Function

    Public Function GetSqlAsObject(sNameObj As String) As CManifestoSql
        GetSqlAsObject = Nothing

        If sNameObj = vbNullString Then
            MsgBox("Nessun oggetto da eseguire", vbCritical + vbOKOnly)
            Return Nothing
        End If

        Dim objDir As String = "Queries"
        Dim objName As String = sNameObj

        Dim i As Integer = InStr(1, sNameObj, "\")
        If i > 0 Then
            objName = Mid(sNameObj, i + 1)
            objDir = Left(sNameObj, i - 1)
        End If

        Dim m As CManifestoSql = mgrMfs.ManifestoLoad(objDir, objName, Utente)

        If m IsNot Nothing Then
            If TypeOf m Is IProfilatore Then
                If m.GetAutorizzazioni(Utente) And EAutType.AUT_ESECUZIONE Then
                    If TypeOf m Is CManifestoSql Then
                        GetSqlAsObject = m
                    Else
                        MsgBox("Tipo di oggetto non gestito.", vbCritical, Utx.Globale.TitoloApp)
                    End If
                Else
                    MsgBox("Utente non autorizzato.", vbCritical, Utx.Globale.TitoloApp)
                End If
            Else
                MsgBox("Oggetto non eseguibile", vbCritical, Utx.Globale.TitoloApp)
            End If
        Else
            MsgBox("Estrazione """ & objName & """ non trovata", vbCritical)
        End If

        Return GetSqlAsObject
    End Function

    Public Function ExistObject(sNameObj As String) As Boolean

        If sNameObj = vbNullString Then Return False

        Dim objDir As String = "Queries"
        Dim objName As String = sNameObj

        If sNameObj.ToLower.StartsWith("queries\") Then
            Dim i As Integer
            i = InStr(1, sNameObj, "\")
            objName = Mid(sNameObj, i + 1)
            objDir = Left(sNameObj, i - 1)
        End If

        Dim m As CManifestoSql = mgrMfs.ManifestoLoad(objDir, objName, Utente)

        If m IsNot Nothing Then
            If m.GetAutorizzazioni(Utente) And EAutType.AUT_ESECUZIONE Then
                Return True
            End If
        End If

        Return False
    End Function

    Shared Sub New()

        If Utx.Globale.IdAppOk = False Then
            Utx.Globale.IdApp(System.Text.Encoding.UTF8.GetString(New Byte() {57, 60, 88, 93, 65, 58, 71}))
            Utx.Globale.Init()

            Dim Bag As Utx.Bag = Utx.NetFunc.CryptoDeserialize(Of Utx.Bag)(IO.Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "Utx.Bag"), "guido&st")

            With Bag
                Utx.Globale.Paths = .Paths
                Utx.Globale.ProfiloEnteGestore = .Ente
                Utx.Globale.UtenteCorrente = .Utente
                Utx.Globale.AgenziaRichiesta = .AgenziaRichiesta
            End With
        End If

        CARTELLA_OGGETTI = IO.Path.Combine(Utx.Globale.Paths.CartellaUnitoolsRete, "Oggetti\")
        CARTELLA_SETTING = IO.Path.Combine(CARTELLA_OGGETTI, "Setting\")

        IO.Directory.CreateDirectory(CARTELLA_OGGETTI)
        IO.Directory.CreateDirectory(CARTELLA_SETTING)
    End Sub

    Public Shared Function GetCartellaExe() As String
        Return Utx.Globale.Paths.CartellaApp
    End Function

    Public Function AggiornaCatalogoEstrazioni(forzaAggiornamento As Boolean) As Boolean
        UniAggio.Aggiorna(forzaAggiornamento)
        Return True
    End Function

    Public Function getEsploratore() As frmEsplora
        Return New frmEsplora()
    End Function
End Class
