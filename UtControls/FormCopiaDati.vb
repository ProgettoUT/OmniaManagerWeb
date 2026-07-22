Imports System.Windows.Forms
Imports System.Drawing

Public Class FormCopiaDati

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
        Me.Size = New Size(400, Screen.PrimaryScreen.WorkingArea.Height * 0.8)
        Me.MinimumSize = New Size(200, Screen.PrimaryScreen.WorkingArea.Height * 0.4)
        Me.Font = Utx.AppFont.Normal
        Me.Icon = Risorse.Immagini.Icon("copia")
        Me.Text = "Copia dati"

        ImpostaControlli()
    End Sub

    Private Sub ImpostaControlli()
        With CheckBoxCliente
            .BackColor = SystemColors.Control
            .Margin = New Padding(0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
            .FlatAppearance.CheckedBackColor = Color.PaleGreen
            .Text = "Cliente"
        End With
        With CheckBoxPolizze
            .BackColor = SystemColors.Control
            .Margin = New Padding(0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
            .FlatAppearance.CheckedBackColor = Color.PaleGreen
            .Text = "Polizze"
        End With
        With CheckBoxSinistri
            .BackColor = SystemColors.Control
            .Margin = New Padding(0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
            .FlatAppearance.CheckedBackColor = Color.PaleGreen
            .Text = "Sinistri"
        End With
        With ButtonCopia
            .BackColor = SystemColors.Control
            .Margin = New Padding(0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Text = "Copia dati selezionati"
        End With
        With ButtonSelezionaTutto
            .BackColor = SystemColors.Control
            .Margin = New Padding(0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .Text = "Seleziona tutto"
        End With
        With ButtonEsci
            .BackColor = SystemColors.Control
            .Margin = New Padding(0)
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 1
            .FlatAppearance.BorderColor = Color.Gainsboro
            .FlatAppearance.MouseOverBackColor = Color.LightSalmon
            .Text = "Esci"
        End With
        With CheckedListBoxDati
            .Margin = New Padding(0)
            .BorderStyle = BorderStyle.FixedSingle
            .CheckOnClick = True
            .IntegralHeight = False
        End With
    End Sub

    Private mCodiceFiscale As String
    Public Property CodiceFiscale() As String
        Get
            Return mCodiceFiscale
        End Get
        Set(value As String)
            mCodiceFiscale = value
        End Set
    End Property

    Private Sub FormCopiaDati_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler CheckBoxCliente.CheckedChanged, AddressOf CheckBoxCliente_CheckedChanged
        AddHandler CheckBoxPolizze.CheckedChanged, AddressOf CheckBoxCliente_CheckedChanged
        AddHandler CheckBoxSinistri.CheckedChanged, AddressOf CheckBoxCliente_CheckedChanged
    End Sub

    Private Sub FormCopiaDati_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If String.IsNullOrEmpty(mCodiceFiscale) Then
            MsgBox("Impossibile recuperare i dati. Codice fiscale non valido.", MsgBoxStyle.Information, Utx.Globale.TitoloApp)
            DialogResult = Windows.Forms.DialogResult.Cancel
        End If
        CheckBoxCliente.Checked = True
    End Sub

    Private Sub LeggiCliente()
        Try
            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(String.Format("SELECT * FROM Clienti WHERE CodiceFiscale = '{0}'",
                                                                                   mCodiceFiscale)).DataTable
            If dt.Rows.Count > 0 Then
                Dim dr As DataRow = dt.Rows(0)

                AddItem("> Cliente:")
                AddItem(dr("CodiceFiscale"))
                AddItem(dr("Cognome"))
                AddItem(dr("Nome"))
                AddItem(dr("Indirizzo"))
                AddItem(dr("Cap"))
                AddItem(dr("Localita"))
                AddItem(dr("Provincia"))
                AddItem(String.Format("Data di nascita: {0:dd/MM/yyyy}", dr("DataNascita")))
                AddItem(String.Format("Telefono: {0}", dr("Telefono1")))
                AddItem(String.Format("Telefono: {0}", dr("Telefono2")))
                AddItem(String.Format("Cellulare: {0}", dr("Cellulare")))
                AddItem(StrDup(30, "="))
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub LeggiPolizze()
        Try
            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(String.Format("SELECT * FROM Polizze WHERE CodiceFiscale = '{0}'",
                mCodiceFiscale)).DataTable
            If dt.Rows.Count > 0 Then

                For Each dr As DataRow In dt.Rows
                    AddItem(String.Format("> Polizza: {0}/{1}", dr("Ramo"), dr("Polizza")))
                    AddItem(String.Format("Targa: {0}", dr("Targa")))
                    AddItem(String.Format("Effetto: {0:dd/MM/yyyy}", dr("DataEffetto")))
                    AddItem(String.Format("Scadenza: {0:dd/MM/yyyy}", dr("DataScadenza")))
                    AddItem(String.Format("Prodotto: {0}", dr("CodiceProdotto")))
                    AddItem(String.Format("Convenzione: {0}", dr("Convenzione")))
                    AddItem(String.Format("Sub: {0}", dr("CodiceSubAgente")))
                    AddItem("=")
                Next
                AddItem(StrDup(30, "="))
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub LeggiSinistri()
        Try
            Dim dt As DataTable = Utx.WsCommand.ExecuteNonQuery(String.Format("SELECT * FROM SinistriDP WHERE CODICEFISCCONTRPOL = '{0}'
                UNION ALL SELECT * FROM SinistriDA WHERE CODICEFISCCONTRPOL = '{0}'", mCodiceFiscale)).DataTable

            If dt.Rows.Count > 0 Then

                For Each dr As DataRow In dt.Rows
                    AddItem(String.Format("> Sinistro: {0}-{1}-{2}-{3}", dr("Compagnia"), dr("AgenziaSinistro"),
                                          dr("EsercizioSinistro"), dr("NumeroSinistro")))
                    AddItem(String.Format("Data sinistro: {0:dd/MM/yyyy}", dr("DataSinistro")))
                    AddItem(String.Format("Polizza {0}/{1}", dr("RamoPolizza"), dr("Polizza")))
                    AddItem(String.Format("Targa assicurato: {0}", dr("TargaAssicurato")))
                    AddItem(String.Format("Danneggiato: {0}", dr("CognomeDanneggiato")))
                    AddItem(String.Format("Targa danneggiato: {0}", dr("TargaDanneggiato")))
                    AddItem("=")
                Next
                AddItem(StrDup(30, "="))
            End If

        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub AddItem(obj As Object)
        Dim str As String = Utx.FunzioniDb.NullToString(obj)
        If str.Trim.Length > 0 Then
            CheckedListBoxDati.Items.Add(str)
        End If
    End Sub

    Private Sub ButtonEsci_Click(sender As Object, e As EventArgs) Handles ButtonEsci.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub ButtonCopia_Click(sender As Object, e As EventArgs) Handles ButtonCopia.Click
        Try
            If CheckedListBoxDati.CheckedItems.Count > 0 Then
                Clipboard.Clear()

                Dim Testo As String = ""

                For Each r In CheckedListBoxDati.CheckedItems
                    Testo &= Trim(r) & Environment.NewLine
                Next

                Clipboard.SetText(Testo)

                DialogResult = Windows.Forms.DialogResult.OK
            End If
        Catch ex As Exception
            Utx.Globale.Log.Errore(ex)
        End Try
    End Sub

    Private Sub CheckBoxCliente_CheckedChanged(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        CheckedListBoxDati.Items.Clear()
        If CheckBoxCliente.Checked = True Then
            LeggiCliente()
        End If
        If CheckBoxPolizze.Checked = True Then
            LeggiPolizze()
        End If
        If CheckBoxSinistri.Checked = True Then
            LeggiSinistri()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonSelezionaTutto_Click(sender As Object, e As EventArgs) Handles ButtonSelezionaTutto.Click
        For k As Integer = 0 To CheckedListBoxDati.Items.Count - 1
            CheckedListBoxDati.SetItemChecked(k, True)
        Next
    End Sub
End Class