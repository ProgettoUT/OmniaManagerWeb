Public Class FormAttivita

    Sub New()

        ' Chiamata richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        Me.WindowState = FormWindowState.Normal
        Me.Size = New Size(320, 280)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Font = Utx.AppFont.Normal
        Me.Icon = Risorse.Immagini.Icon("consap")
        Me.Text = "Attività Consap"

        ImpostaControlli()
    End Sub

    Private mCodiceFiscale As String = ""
    Public Property CodiceFiscale() As String
        Get
            Return mCodiceFiscale
        End Get
        Set(value As String)
            mCodiceFiscale = value
        End Set
    End Property

    Private mIdSinistro As String
    Public Property IdSinistro() As String
        Get
            Return mIdSinistro
        End Get
        Set(value As String)
            mIdSinistro = value
        End Set
    End Property

    Private mRamo As Integer
    Public Property Ramo() As Integer
        Get
            Return mRamo
        End Get
        Set(value As Integer)
            mRamo = value
        End Set
    End Property

    Private mPolizza As Integer
    Public Property Polizza() As Integer
        Get
            Return mPolizza
        End Get
        Set(value As Integer)
            mPolizza = value
        End Set
    End Property

    Private mScadenzaPolizza As Date
    Public Property ScadenzaPolizza() As Date
        Get
            Return mScadenzaPolizza
        End Get
        Set(value As Date)
            mScadenzaPolizza = value
        End Set
    End Property

    Private mPolizzaSostituita As Boolean
    Public ReadOnly Property PolizzaSostituita() As Boolean
        Get
            Return mPolizzaSostituita
        End Get
    End Property

    Private Sub ImpostaControlli()
        LabelPolizza.Font = Utx.AppFont.Bold
        LabelScadenza.Font = Utx.AppFont.Bold
        With LabelHelp
            .ForeColor = Color.DarkSlateGray
            .Text = "Crea una attività con la scadenza indicata per ricordarvi di inoltrare alla CONSAP la richiesta dati al fine di valutare l'eventuale rimborso del sinistro"
            .TextAlign = ContentAlignment.MiddleLeft
        End With
        With ButtonCreaAttivita
            .FlatAppearance.MouseOverBackColor = Color.PaleGreen
            .Padding = New Padding(10, 0, 10, 0)
            .Image = Risorse.Immagini.Bitmap("clock")
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = "Crea attività Consap"
            .TextAlign = ContentAlignment.MiddleRight
        End With
    End Sub

    Private Sub FormAttivita_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            LabelPolizza.Text = String.Format("{0}/{1}", mRamo, mPolizza)
            Me.ScadenzaPolizza = CercaScadenza(mRamo, mPolizza)
            If mScadenzaPolizza = #1/1/1900# Then
                LabelScadenza.Text = "Non disponibile"
                LabelDeskPolizza.Text = "Non trovata"
                With dtpScadenzaAttivita
                    .MinDate = Today
                    .Value = Today
                End With
            Else
                If DateDiff(DateInterval.Day, Today, mScadenzaPolizza) < 60 Then
                    LabelScadenza.ForeColor = Utx.AppColor.RossoScuro
                End If
                LabelScadenza.Text = mScadenzaPolizza
                If mPolizzaSostituita = True Then
                    LabelDeskPolizza.Text = "Polizza (sostituita)"
                End If
                With dtpScadenzaAttivita
                    .MinDate = Today
                    .MaxDate = Utx.FunzioniData.MaxDate(mScadenzaPolizza, Today)
                    .Value = Utx.FunzioniData.MaxDate(.MinDate, mScadenzaPolizza.AddDays(-60)) 'default 60 giorni prima della scadenza
                End With
            End If

        Catch ex As Exception
            Globale.Log.Errore(ex)
            DialogResult = Windows.Forms.DialogResult.Abort
        End Try
    End Sub

    Private Sub ButtonCreaAttivita_Click(sender As Object, e As EventArgs) Handles ButtonCreaAttivita.Click
        Dim Attivita As New Utx.Nota
        With Attivita
            .NuovaNota = True
            .Tipo = Utx.Nota.TipoNota.ATTIVITA
            .IdNota = Replace(mIdSinistro, ".", "-")
            .CodiceFiscale = mCodiceFiscale
            .Utente = Utx.Globale.UtenteCorrente.UniageUser
            .DataModifica = Now
            .Testo = "Inviare richiesta CONSAP"
            .Allarme = dtpScadenzaAttivita.Value
            If .SalvaNota() = True Then
                Risorse.Suoni.Suona(Risorse.Suoni.SuoniUt.OK)
                Call New Utx.NotificaRapida().Visualizza("Attività creata correttamente")
            Else
                Call New Utx.NotificaRapida().VisualizzaErrore("Errore nella creazione dell'attività")
            End If
        End With
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Function CercaScadenza(Ramo As Integer, Polizza As Integer) As Date
        Try
            Dim sqlVigore As String = "SELECT DataScadenza FROM Polizze WHERE Ramo = {0} AND Polizza = {1}"
            Dim sqlCanc As String = "SELECT DataScadenza,RamoSost,PolizzaSost FROM MovPolizze WHERE Ramo = {0} AND Polizza = {1}"

            Debug.Print("{0}/{1}", Ramo, Polizza)
            Dim Scadenza As Date = Utx.WsCommand.ExecuteScalar(String.Format(sqlVigore, Ramo, Polizza), ValoreDefault:=#1/1/1900#).Valore

            If Scadenza = #1/1/1900# Then
                'la polizza non è stata trovata e quindi cerco nel cancellato
                Dim dr As DataTableReader = Utx.FunzioniDb.CreaDataTableReader(String.Format(sqlCanc, Ramo, Polizza))

                If dr.HasRows Then
                    'trovata
                    dr.Read()

                    If dr("PolizzaSost") > 0 Then
                        'sostituita: cambio ramo/polizza e interrogo di nuovo
                        mPolizzaSostituita = True
                        Scadenza = CercaScadenza(dr("RamoSost"), dr("PolizzaSost"))
                    End If
                End If
            End If

            Return Scadenza

        Catch ex As Exception
            Globale.Log.Errore(ex)
            Return #1/1/1900#
        End Try
    End Function

    Private Sub dtpScadenzaAttivita_ValueChanged(sender As Object, e As EventArgs) Handles dtpScadenzaAttivita.ValueChanged
        LabelScadenzaAttivita.Text = String.Format("Scadenza attività {0} giorni prima", DateDiff(DateInterval.Day, dtpScadenzaAttivita.Value, mScadenzaPolizza))
    End Sub
End Class