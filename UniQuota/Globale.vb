Imports System.Environment

Module Globale
    Public CARTELLA_EXE As String
    Public CARTELLA_DATI As String
    Public RETEATTIVA As String
    Public CREDENZIALI As String
    Public EMAIL_MITTENTE As String
    Public EMAIL_SMTP As String
    Public POSTINO_GUID As String
    Public CLIENTE_CODICEFISCALE As String
    Public CARTELLA_PREVENTIVI As String
    Public CARTELLA_TEMP As String
    Public logCalcolo As String

    Public log As New Unilog
    Public licenza As Licenza
    Public LogNet As New NetLog

    Private helptip As New ToolTip
    Private rdtip As New ToolTip

    Private FontBold As System.Drawing.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Public LoginEssig As Utx.AutenticazioneEssig

    Sub New()

        If Utx.Globale.IdAppOk = False Then
            Utx.Globale.IdApp(System.Text.Encoding.UTF8.GetString(New Byte() {57, 60, 88, 93, 65, 58, 71}))
            Utx.Globale.Init()

            Dim Bag As Utx.Bag = Utx.NetFunc.CryptoDeserialize(Of Utx.Bag)(IO.Path.Combine(Utx.Globale.Paths.CartellaTempUtente, "Utx.Bag"), "guido&st")

            If Bag IsNot Nothing Then
                With Bag
                    Utx.Globale.Paths = .Paths
                    Utx.Globale.ProfiloEnteGestore = .Ente
                    Utx.Globale.UtenteCorrente = .Utente
                    Utx.Globale.AgenziaRichiesta = .AgenziaRichiesta
                End With
            End If
        End If

        LoginEssig = New Utx.AutenticazioneEssig

        'Utx.Globale.IdApp(System.Text.Encoding.UTF8.GetString(New Byte() {57, 60, 88, 93, 65, 58, 71}))
        'Utx.Globale.Paths = New Utx.ApplicationPath
        'Dim runpath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
        'runpath = New Uri(runpath).LocalPath
        'Utx.Globale.Paths.Inizializza(runpath, IIf(runpath.EndsWith("UT"), "X", "U"), "M")
        'Utx.Globale.UtenteCorrente = New Utx.Utente
        'Utx.Globale.ProfiloEnteGestore = New Utx.EnteGestore
        'Utx.Globale.AgenziaRichiesta = New Utx.Agenzia(Utx.Globale.ProfiloEnteGestore.AgenziaMadre)
        'Utx.Globale.SettingGlobale = New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.GLOBALE)
        'Utx.Globale.SettingInterop = New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.INTEROP)
        'Utx.Globale.SettingUtente = New Utx.ApplicationUserSetting(Utx.ApplicationUserSetting.TipoSetting.UTENTE)
        'Utx.Globale.LoginUniage = New Utx.AutenticazioneUeba
        'Utx.Globale.LoginEssig = New Utx.AutenticazioneEssig

        'leggi le abilitazioni e il profilo dell'agenzia
        'Utx.Globale.ProfiloEnteGestore.LeggiAbilitazioni()
        'Utx.Globale.ImpostaTitoloApp()

#If DEBUG Then
        System.Environment.SetEnvironmentVariable("UNITOOLS_CLIENTE_CODICEFISCALE", "PCRDNC67T26G393Q")
        'System.Environment.SetEnvironmentVariable("UNITOOLS_CLIENTE_CODICEFISCALE", "01941360487")
#End If

        CARTELLA_EXE = Utx.Globale.Paths.CartellaApp
        CARTELLA_DATI = Utx.Globale.Paths.CartellaUnitoolsRete
        RETEATTIVA = GetEnvironmentVariable("UNITOOLS_RETEATTIVA")
        CREDENZIALI = GetEnvironmentVariable("UNITOOLS_CREDENZIALI")
        EMAIL_MITTENTE = GetEnvironmentVariable("UNITOOLS_EMAIL_MITTENTE")
        EMAIL_SMTP = GetEnvironmentVariable("UNITOOLS_EMAIL_SMTP")
        POSTINO_GUID = GetEnvironmentVariable("UNITOOLS_POSTINO_GUID")
        CLIENTE_CODICEFISCALE = GetEnvironmentVariable("UNITOOLS_CLIENTE_CODICEFISCALE")
        CARTELLA_PREVENTIVI = System.IO.Path.Combine(CARTELLA_DATI, "Preventivi")
        CARTELLA_TEMP = Utx.Globale.Paths.CartellaTempUtente

        licenza = licenza.Load
    End Sub

    Public Enum ModalitaPreventivo
        Guidato
        ConScelta
    End Enum
    Public Enum ModalitaVisualizzazionePremi
        ListinoLordo
        ListinoNetto
        PremioLordo
        PremioNetto
    End Enum

    Public ModalitaQuotatore As ModalitaPreventivo = ModalitaPreventivo.ConScelta
    Public ModalitaVisualizzazione As ModalitaVisualizzazionePremi = ModalitaVisualizzazionePremi.ListinoLordo

    Public Function FormatEuro(ByVal value As Decimal) As String
        Return FormatNumber(value, 2)
    End Function

    Public Sub FormatEuro(ByVal label As System.Windows.Forms.Label, ByVal premio As Premio)
        If premio.RischioDirezione = StatoPremio.ClasseOK Then
            label.Text = FormatEuro(premio.PremioLabel)
            rdtip.SetToolTip(label, Nothing)
        ElseIf premio.RischioDirezione = StatoPremio.ClasseRD Then
            label.Text = "R.D."
            rdtip.SetToolTip(label, premio.DescrizioneRD)
        Else
            label.Text = "N.D."
            rdtip.SetToolTip(label, premio.DescrizioneRD)
        End If
    End Sub

    Public Property EnabledAndChecked(ByVal checkbox As CheckBox) As StatoCopertura
        Get
            If checkbox.Enabled = False Then
                EnabledAndChecked = StatoCopertura.Inapplicabile
            ElseIf checkbox.Checked = True Then
                EnabledAndChecked = StatoCopertura.attiva
            Else
                EnabledAndChecked = StatoCopertura.esclusa
            End If
        End Get
        Set(ByVal value As StatoCopertura)
            If value = StatoCopertura.Inapplicabile Then
                checkbox.Enabled = False
            ElseIf value = StatoCopertura.attiva Then
                checkbox.Enabled = True
                checkbox.Checked = True
            Else
                checkbox.Enabled = True
                checkbox.Checked = False
            End If
        End Set
    End Property

    Public Function Enable(ByVal stato As StatoCopertura) As Boolean
        If ModalitaQuotatore = ModalitaPreventivo.Guidato Then
            Return stato = StatoCopertura.attiva
        ElseIf ModalitaQuotatore = ModalitaPreventivo.ConScelta Then
            Return stato <> StatoCopertura.Inapplicabile
        Else
            Return False
        End If
    End Function

    Public Function EnableIfAttivo(ByVal stato As StatoCopertura) As Boolean
        Return (stato = StatoCopertura.attiva)
    End Function

    Public Sub txtBoxEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sender.SelectAll()
    End Sub


    Public Property IntegerBox(ByVal textbox As TextBox) As Integer
        Get
            Dim output As Integer = 0
            If Integer.TryParse(textbox.Text, output) Then
                Return output
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            textbox.Text = value
        End Set
    End Property

    Public Property CurrencyBox(ByVal textbox As TextBox) As Decimal
        Get
            Dim output As Decimal = 0D
            If Decimal.TryParse(textbox.Text, output) Then
                Return output
            Else
                Return 0D
            End If
        End Get
        Set(ByVal value As Decimal)
            textbox.Text = FormatEuro(value)
        End Set
    End Property

    Public Property PercentualeBox(ByVal textbox As TextBox) As Decimal
        Get
            Dim outtag As Decimal = 0D
            Decimal.TryParse(textbox.Tag, outtag)
            Return outtag
        End Get
        Set(ByVal value As Decimal)
            textbox.Tag = value
            textbox.Text = FormatNumber(value * 100D, 2)
        End Set
    End Property



    Public Sub AgganciaHelp(ByVal parent As Control, ByVal funzione As System.Windows.Forms.MouseEventHandler)
        For Each c As Control In parent.Controls
            If c.Controls.Count > 0 Then
                AgganciaHelp(c, funzione)
            ElseIf c.Tag IsNot Nothing And c.Tag <> vbNullString Then
                If TypeOf c Is Label Then
                    With CType(c, Label)
                        .Text = "     " & .Text
                        If .Tag <> "0" Then
                            .Cursor = Cursors.Help
                            AddHandler .MouseClick, funzione ' AddressOf Quotatore.ClickedHelp
                            .Image = My.Resources.help16
                            .ImageAlign = ContentAlignment.MiddleLeft
                            helptip.SetToolTip(c, "Click per visualizzare l'help.")
                        End If
                    End With
                End If
            End If
        Next
    End Sub

    Public Sub AttachCombo(ByVal combo As ComboBox, ByVal sourceDecode As Dictionary(Of String, Integer))
        Try
            With combo
                .DataSource = New BindingSource(sourceDecode, Nothing)
                .ValueMember = "Value"
                .DisplayMember = "Key"
                .SelectedIndex = 0
            End With
        Catch ex As Exception
        End Try
    End Sub

    Public Sub AttachCombo(ByVal combo As ComboBox, ByVal sourceDecode As Dictionary(Of Integer, String))
        AttachCombo(combo, New BindingSource(sourceDecode, Nothing))
    End Sub
    Public Sub AttachCombo(ByVal combo As ComboBox, ByVal sourceDecode As Dictionary(Of String, String))
        AttachCombo(combo, New BindingSource(sourceDecode, Nothing))
    End Sub
    Public Sub AttachCombo(ByVal combo As ComboBox, ByVal sourceDecode As Dictionary(Of Decimal, String))
        AttachCombo(combo, New BindingSource(sourceDecode, Nothing))
    End Sub
    Public Sub AttachCombo(ByVal combo As ComboBox, ByVal sourceDecode As Object)
        AttachCombo(combo, New BindingSource(sourceDecode, Nothing))
    End Sub

    Public Sub AttachCombo(ByVal combo As ComboBox, ByVal bindingSource As BindingSource)
        Try
            With combo
                .DataSource = bindingSource
                .ValueMember = "Key"
                .DisplayMember = "Value"
                .SelectedIndex = 0
            End With
        Catch ex As Exception
        End Try
    End Sub

    Public Function Arrotonda(ByVal d As Decimal) As Decimal
        'Return Math.Floor(d * 100D) / 100D
        'Return Math.Floor(d * 100D + 0.51D) / 100D
        'Return Math.Round(d, 2, MidpointRounding.ToEven)
        Return Math.Floor(d * 100D + 0.1D) / 100D
    End Function

    Public Function ArrotondaPerDifetto(ByVal d As Decimal) As Decimal
        Return Math.Floor(d * 100D) / 100D
    End Function
    Public Function ArrotondaPerEccesso(ByVal d As Decimal) As Decimal
        Return Math.Ceiling(d * 100D) / 100D
    End Function

    Public Function Scegli(ByVal indice As Integer, ByVal ParamArray array() As Decimal) As Decimal
        Return array(indice - 1)
    End Function

    Public Function IsOneOf(ByVal ParamArray intero() As Integer) As Boolean
        For i As Integer = 1 To intero.GetUpperBound(0)
            If intero(0) = intero(i) Then Return True
        Next

        Return False
    End Function

    Public Function IndexOf(ByVal valore As Decimal, ByVal ParamArray array() As Decimal) As Integer
        For i As Integer = 0 To array.GetUpperBound(0)
            If valore = array(i) Then Return 1 + i
        Next
        Return 0
    End Function

    Public Function Minimo(ByVal ParamArray decimale() As Decimal) As Decimal
        Minimo = decimale(0)
        For i As Integer = 1 To decimale.GetUpperBound(0)
            If Minimo > decimale(i) Then Minimo = decimale(i)
        Next
    End Function

    Public Function MinimoPiuVicino(ByVal ParamArray decimale() As Decimal) As Decimal
        For i As Integer = 1 To decimale.GetUpperBound(0)
            If decimale(0) > decimale(i) Then Return decimale(i - 1)
        Next
        Return decimale(1)
    End Function

    Public Sub cmbProvinciaSelectedIndexChanged(ByVal cmbProvincia As ComboBox, ByVal cmbComune As ComboBox)
        Dim comuni As New Dictionary(Of Integer, Comune)
        Dim siglaProvincia As String = CType(cmbProvincia.SelectedItem, KeyValuePair(Of ProvinciaEnum, Provincia)).Value.Sigla

        comuni.Add(0, Luogo.GetComuneNotSelected())

        If siglaProvincia <> vbNullString Then
            For Each comune As Comune In Luogo.Comuni.FindAll(Function(c As Comune) c.Provincia.Sigla = siglaProvincia)
                comuni.Add(comune.CodiceIstat, comune)
            Next
        End If
        AttachCombo(cmbComune, comuni)
    End Sub

    Public Function IsNullOrWhiteSpace(ByVal stringa As String) As Boolean
        If String.IsNullOrEmpty(stringa) Then Return True
        If stringa.Trim().Length = 0 Then Return True
        Return False
    End Function


    Public Sub AgganciaCheckAndLabel(ByVal tlps() As TableLayoutPanel)

        For Each tlp As TableLayoutPanel In tlps
            For row As Integer = 1 To tlp.RowCount
                Dim l As Control = tlp.GetControlFromPosition(1, row)
                Dim c As Control = tlp.GetControlFromPosition(0, row)

                If TypeOf l Is Label And TypeOf c Is CheckBox Then
                    AddHandler c.MouseEnter, AddressOf CheckMouseEnter
                    AddHandler c.MouseLeave, AddressOf CheckMouseLeave
                End If
            Next
        Next
    End Sub

    Private Sub CheckMouseEnter(sender As Object, e As EventArgs)
        Dim chk = CType(sender, CheckBox)
        Dim tlp = CType(chk.Parent, TableLayoutPanel)
        Dim lbl As Label = tlp.GetControlFromPosition(1, tlp.GetRow(sender))
        Dim prm As Label = tlp.GetControlFromPosition(4, tlp.GetRow(sender))
        lbl.ForeColor = Color.Red
        prm.ForeColor = Color.Red
        lbl.BackColor = Color.LightGreen
        prm.BackColor = Color.LightGreen
        chk.BackColor = Color.LightGreen
    End Sub

    Private Sub CheckMouseLeave(sender As Object, e As EventArgs)
        Dim chk = CType(sender, CheckBox)
        Dim tlp = CType(chk.Parent, TableLayoutPanel)
        Dim lbl As Label = tlp.GetControlFromPosition(1, tlp.GetRow(sender))
        Dim prm As Label = tlp.GetControlFromPosition(4, tlp.GetRow(sender))

        lbl.ForeColor = Nothing
        prm.ForeColor = Nothing
        lbl.BackColor = Nothing
        chk.BackColor = Nothing
        prm.BackColor = Nothing
    End Sub

    Public Sub HighlightCheckAndLabel(ByVal tlps() As TableLayoutPanel)
        If tlps IsNot Nothing Then
            For Each tlp As TableLayoutPanel In tlps
                For row As Integer = 1 To tlp.RowCount
                    Dim c As Control = tlp.GetControlFromPosition(0, row)
                    Dim l As Control = tlp.GetControlFromPosition(1, row)
                    Dim p As Control = tlp.GetControlFromPosition(4, row)

                    If TypeOf l Is Label And TypeOf p Is Label And TypeOf c Is CheckBox Then
                        Dim chk = CType(c, CheckBox)
                        Dim lbl = CType(l, Label)
                        Dim prm = CType(p, Label)

                        'lbl.Enabled = chk.Enabled
                        prm.Enabled = chk.Enabled

                        If chk.Enabled AndAlso chk.Checked Then
                            lbl.Font = FontBold
                            prm.Font = FontBold
                            lbl.ForeColor = Nothing
                        ElseIf chk.Enabled Then
                            lbl.Font = Nothing
                            prm.Font = Nothing
                            lbl.ForeColor = Nothing
                        Else
                            lbl.Font = Nothing
                            prm.Font = Nothing
                            lbl.ForeColor = SystemColors.GrayText
                        End If
                    ElseIf TypeOf l Is Label And p Is Nothing And c Is Nothing Then
                        l.Enabled = tlp.GetControlFromPosition(1, row - 1).Enabled
                    End If
                Next
            Next
        End If
    End Sub

    Public Sub SetDoubleBuffered(c As Control)
        c.GetType.InvokeMember("DoubleBuffered",
                             Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.SetProperty, Nothing, c,
                             New Object() {True})
    End Sub

End Module
