Imports System.Data.OleDb
Imports System.IO
Imports System.Xml

Public Class FormAnalisiDb

    Private Log As Utx.ApplicationLog
    Private WithEvents Analisi As Utx.AnalisiDb

    Private Enum Errore
        TIPO_ERRATO
        LUNGHEZZA_DIVERSA
        CAMPO_NON_TROVATO
    End Enum

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(900, 500)
        Me.Font = Utx.AppFont.Normal
        Me.Icon = Risorse.Immagini.Icon("strumenti")
        Me.Text = "Analisi database agenzia"

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        Utx.NetFunc.DoppioBuffer(dgvAnalisi)
        With dgvAnalisi
            .AllowUserToAddRows = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .EditMode = DataGridViewEditMode.EditProgrammatically
        End With
        With LabelMessaggio
            .ForeColor = Color.Red
            .Font = Utx.AppFont.Bold
            .Text = ""
        End With
        ButtonCorreggi.Text = "Correggi errore"
        ButtonCorreggiTutto.Text = "Correggi tutto"
        ButtonAggiorna.Text = "Analizza Db"
        ButtonLog.Text = "Log"
        ButtonDbUno.Text = "Analizza DbUno"
        ButtonCsv.Text = "Esporta in CSV"
        ButtonMdb.Text = String.Format("Utilità MDB ({0})", IIf(File.Exists(Utx.Servizi.MdbPlus), "OK", "ND"))
        ButtonEsci.Text = "Esci"
    End Sub

    Private Sub FormAnalisiDb_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Refresh()
        'AnalisiDb()
    End Sub

    Private Sub ButtonCorreggi_Click(sender As Object, e As EventArgs) Handles ButtonCorreggi.Click
        Try
            If MsgBox("Procedere con la correzione dell'errore?", MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.YesNo, Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then
                Analisi.CorreggiCampo(dgvAnalisi.CurrentRow.Index)
            End If
        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonCorreggiTutto_Click(sender As Object, e As EventArgs) Handles ButtonCorreggiTutto.Click
        Try
            If MsgBox("Procedere con la correzione di tutti gli errori?", MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.YesNo, Utx.Globale.TitoloApp) = MsgBoxResult.Yes Then
                Analisi.CorreggiTutto()
                AnalisiDb()
            End If

        Catch ex As Exception
            Log.Errore(ex)
        End Try
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        Me.Close()
    End Sub

    Private Sub ButtonAggiorna_Click(sender As Object, e As EventArgs) Handles ButtonAggiorna.Click
        AnalisiDb()
    End Sub

    Private Sub AnalisiDb()
        Try
            Me.Text = "Analisi database agenzia " + Utx.Globale.AgenziaRichiesta.CodiceAgenzia

            Log = New Utx.ApplicationLog("AnalisiDb", Utx.Globale.Paths.CartellaLogs, Sovrascrivi:=True)

            Log.Info()
            Log.Info("Controllo database agenzia " & Utx.Globale.AgenziaRichiesta.CodiceAgenzia)
            Log.Info()

            Analisi = New Utx.AnalisiDb
            Analisi.Agenzia = Utx.Globale.AgenziaRichiesta.CodiceAgenzia
            Analisi.Log = Log

            With dgvAnalisi
                .DataSource = Nothing
                .DataSource = Analisi.AnalisiDb

                .Columns("Tipo modello").DefaultCellStyle.BackColor = Color.LightGreen
                .Columns("Tipo tabella").DefaultCellStyle.BackColor = Color.Gainsboro
                .Columns("Car.modello").DefaultCellStyle.BackColor = Color.LightGreen
                .Columns("Car.tabella").DefaultCellStyle.BackColor = Color.Gainsboro
                .Columns("Record").DefaultCellStyle.BackColor = Color.LightYellow
                .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            End With

            MsgBox(dgvAnalisi.CurrentRow.DataBoundItem.item("Campo").Value)

        Catch ex As Exception
            Log.Info(ex.Message)
        End Try
    End Sub

    Private Sub AnalisiDbUno(CodiceAgenzia As String)
        Try
            Me.Text = "Analisi DbUno agenzia " + CodiceAgenzia

            Log = New Utx.ApplicationLog("AnalisiDb", Utx.Globale.Paths.CartellaLogs, Sovrascrivi:=True)

            Log.Info()
            Log.Info("Controllo DbUno agenzia " & CodiceAgenzia)
            Log.Info()

            Analisi = New Utx.AnalisiDb
            Analisi.Agenzia = Utx.Globale.AgenziaRichiesta.CodiceAgenzia
            Analisi.Log = Log

            With dgvAnalisi
                .DataSource = Nothing
                .DataSource = Analisi.AnalisiDbUno(Utx.Globale.AgenziaRichiesta.CodiceAgenzia)

                .Columns("Tabella").DefaultCellStyle.BackColor = Color.PaleGreen
                .Columns("Record").DefaultCellStyle.BackColor = Color.LightYellow
                .AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            End With

        Catch ex As Exception
            Log.Info(ex.Message)
        End Try
    End Sub

    Private Sub LabelMessaggio_TextChanged(sender As Object, e As EventArgs) Handles LabelMessaggio.TextChanged
        LabelMessaggio.Refresh()
    End Sub

    Private Sub ButtonLog_Click(sender As Object, e As EventArgs) Handles ButtonLog.Click
        Process.Start(Log.FullPathLogFile)
    End Sub

    Private Sub ButtonCsv_Click(sender As Object, e As EventArgs) Handles ButtonCsv.Click
        Utx.NetFunc.Esporta2Csv(dgvAnalisi, IO.Path.Combine(Utx.Globale.UtenteCorrente.Desktop, "AnalisiDB"), Color.Khaki)
    End Sub

    Private Sub Analisi_Messaggio(TestoMessaggio As String) Handles Analisi.Messaggio
        LabelMessaggio.Text = TestoMessaggio
    End Sub

    Private Sub ButtonDbUno_Click(sender As Object, e As EventArgs) Handles ButtonDbUno.Click
        AnalisiDbUno(Utx.Globale.AgenziaRichiesta.CodiceAgenzia)
    End Sub

    Private Sub ButtonMdb_Click(sender As Object, e As EventArgs) Handles ButtonMdb.Click
        Utx.Servizi.ScaricaMdbPlus()
    End Sub
End Class

Public Class AnalisiDatabase

    'Private Shared Function getScript() As String
    '    Return CType(My.Resources.ResourceManager.GetObject("ScriptDataBase"), String).Replace("YESNO", "BIT")
    'End Function

    Public Shared Sub AnalisiCampi()
        Try
            Utx.Globale.Log.Info("Analisi corrispondenza campi DB-XML")

            Dim Doc As New XmlDocument
            Doc.LoadXml(Utx.GestioneDatabase.getScript)

            Dim Anomalie As Integer = 0

            For Each db As String In Directory.GetFiles(Path.Combine(Utx.Globale.Paths.CartellaDati, "02379"))
                Using c As New OleDb.OleDbConnection(Utx.ConnessioniDb.ConnectionString(Path.GetFileName(db)))
                    c.Open()
                    Dim tabelle As DataTable = c.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
                    'Dim f As New Utx.FormDebug(tabelle)
                    'f.ShowDialog()

                    For Each tbl As DataRow In tabelle.Rows
                        If tbl("TABLE_TYPE") = "TABLE" Then
                            Dim TabXml As XmlNode = Doc.SelectSingleNode(String.Format("//script/database[@tipo='{0}']/tabelle/sql[@tabella='[{1}]'][@operazione='create']",
                                                                    "agenzia", tbl("TABLE_NAME").ToLower))

                            If TabXml IsNot Nothing Then
                                Using cn As New OleDb.OleDbConnection(Utx.ConnessioniDb.ConnectionString(Path.GetFileName(db)))
                                    cn.Open()
                                    Dim colonne As DataTable = c.GetOleDbSchemaTable(OleDb.OleDbSchemaGuid.Columns, New Object() {Nothing, Nothing, tbl("TABLE_NAME"), Nothing})
                                    'Dim f As New Utx.FormDebug(colonne)
                                    'f.ShowDialog()

                                    For Each col As DataRow In colonne.Rows
                                        Try
                                            If TabXml.InnerText.ToLower.Contains("[" & col("COLUMN_NAME").ToString.ToLower & "]") = False Then
                                                Utx.Globale.Log.Info("Db: {0} - Tabella: {1} - Colonna mancante: {2} ({3} - {4})",
                                                   {Path.GetFileName(db), tbl("TABLE_NAME"), col("COLUMN_NAME"), col("DATA_TYPE"), col("CHARACTER_MAXIMUM_LENGTH").ToString})
                                                Anomalie += 1
                                            End If
                                        Catch ex As Exception
                                            MsgBox(ex.Message)
                                        End Try
                                    Next
                                End Using
                            End If
                        End If
                    Next
                End Using
            Next
            Utx.Globale.Log.Info("Anomalie campi trovate: {0}", {Anomalie})
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub
End Class