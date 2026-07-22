<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEditSinistro
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelPolizza = New System.Windows.Forms.Label()
        Me.LabelSinistro = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TextBoxRamo = New System.Windows.Forms.TextBox()
        Me.TextBoxPolizza = New System.Windows.Forms.TextBox()
        Me.TextBoxSub = New System.Windows.Forms.TextBox()
        Me.TextBoxTarga = New System.Windows.Forms.TextBox()
        Me.TextBoxCF = New System.Windows.Forms.TextBox()
        Me.TextBoxContraente = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ButtonCompletaDati = New System.Windows.Forms.Button()
        Me.ButtonCercaCliente = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TextBoxAgenziaSinistro = New System.Windows.Forms.TextBox()
        Me.TextBoxEsercizio = New System.Windows.Forms.TextBox()
        Me.TextBoxNumero = New System.Windows.Forms.TextBox()
        Me.TextBoxDataSinistro = New System.Windows.Forms.TextBox()
        Me.TextBoxDataDenuncia = New System.Windows.Forms.TextBox()
        Me.TextBoxDataApertura = New System.Windows.Forms.TextBox()
        Me.TextBoxGestione = New System.Windows.Forms.TextBox()
        Me.TextBoxCLG = New System.Windows.Forms.TextBox()
        Me.TextBoxCodiceLiquidatore = New System.Windows.Forms.TextBox()
        Me.TextBoxLiquidatore = New System.Windows.Forms.TextBox()
        Me.TextBoxRamoSinistro = New System.Windows.Forms.TextBox()
        Me.TextBoxCodiceLegale = New System.Windows.Forms.TextBox()
        Me.TextBoxTipoSinistro = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBoxEvento = New System.Windows.Forms.TextBox()
        Me.ButtonOk = New System.Windows.Forms.Button()
        Me.ButtonAnnulla = New System.Windows.Forms.Button()
        Me.rbSinistriPropri = New System.Windows.Forms.RadioButton()
        Me.rbAltraCompagnia = New System.Windows.Forms.RadioButton()
        Me.tlpMain.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 4
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpMain.Controls.Add(Me.LabelPolizza, 0, 1)
        Me.tlpMain.Controls.Add(Me.LabelSinistro, 0, 3)
        Me.tlpMain.Controls.Add(Me.TableLayoutPanel1, 0, 2)
        Me.tlpMain.Controls.Add(Me.TableLayoutPanel2, 0, 4)
        Me.tlpMain.Controls.Add(Me.ButtonOk, 0, 5)
        Me.tlpMain.Controls.Add(Me.ButtonAnnulla, 3, 5)
        Me.tlpMain.Controls.Add(Me.rbSinistriPropri, 0, 0)
        Me.tlpMain.Controls.Add(Me.rbAltraCompagnia, 2, 0)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 6
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.45319!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.641096!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.17982!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.123828!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.99916!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.6029!))
        Me.tlpMain.Size = New System.Drawing.Size(562, 436)
        Me.tlpMain.TabIndex = 0
        '
        'LabelPolizza
        '
        Me.LabelPolizza.AutoSize = True
        Me.LabelPolizza.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tlpMain.SetColumnSpan(Me.LabelPolizza, 4)
        Me.LabelPolizza.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelPolizza.Location = New System.Drawing.Point(3, 71)
        Me.LabelPolizza.Name = "LabelPolizza"
        Me.LabelPolizza.Size = New System.Drawing.Size(556, 24)
        Me.LabelPolizza.TabIndex = 0
        Me.LabelPolizza.Text = "Label1"
        Me.LabelPolizza.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelSinistro
        '
        Me.LabelSinistro.AutoSize = True
        Me.LabelSinistro.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.tlpMain.SetColumnSpan(Me.LabelSinistro, 4)
        Me.LabelSinistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelSinistro.Location = New System.Drawing.Point(3, 213)
        Me.LabelSinistro.Name = "LabelSinistro"
        Me.LabelSinistro.Size = New System.Drawing.Size(556, 22)
        Me.LabelSinistro.TabIndex = 1
        Me.LabelSinistro.Text = "Label2"
        Me.LabelSinistro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 6
        Me.tlpMain.SetColumnSpan(Me.TableLayoutPanel1, 4)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.47177!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.11296!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.47176!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.47176!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.47176!))
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxRamo, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxPolizza, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxSub, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxTarga, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxCF, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TextBoxContraente, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonCompletaDati, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonCercaCliente, 4, 3)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 98)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(556, 112)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'TextBoxRamo
        '
        Me.TextBoxRamo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxRamo.Location = New System.Drawing.Point(92, 3)
        Me.TextBoxRamo.Name = "TextBoxRamo"
        Me.TextBoxRamo.Size = New System.Drawing.Size(64, 20)
        Me.TextBoxRamo.TabIndex = 0
        Me.TextBoxRamo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxPolizza
        '
        Me.TextBoxPolizza.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxPolizza.Location = New System.Drawing.Point(162, 3)
        Me.TextBoxPolizza.Name = "TextBoxPolizza"
        Me.TextBoxPolizza.Size = New System.Drawing.Size(120, 20)
        Me.TextBoxPolizza.TabIndex = 1
        Me.TextBoxPolizza.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxSub
        '
        Me.TextBoxSub.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxSub.Location = New System.Drawing.Point(377, 3)
        Me.TextBoxSub.Name = "TextBoxSub"
        Me.TextBoxSub.Size = New System.Drawing.Size(83, 20)
        Me.TextBoxSub.TabIndex = 2
        Me.TextBoxSub.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxTarga
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBoxTarga, 2)
        Me.TextBoxTarga.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxTarga.Location = New System.Drawing.Point(92, 31)
        Me.TextBoxTarga.Name = "TextBoxTarga"
        Me.TextBoxTarga.Size = New System.Drawing.Size(190, 20)
        Me.TextBoxTarga.TabIndex = 3
        '
        'TextBoxCF
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBoxCF, 2)
        Me.TextBoxCF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxCF.Location = New System.Drawing.Point(92, 59)
        Me.TextBoxCF.Name = "TextBoxCF"
        Me.TextBoxCF.Size = New System.Drawing.Size(190, 20)
        Me.TextBoxCF.TabIndex = 5
        '
        'TextBoxContraente
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.TextBoxContraente, 3)
        Me.TextBoxContraente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxContraente.Location = New System.Drawing.Point(92, 87)
        Me.TextBoxContraente.Name = "TextBoxContraente"
        Me.TextBoxContraente.Size = New System.Drawing.Size(279, 20)
        Me.TextBoxContraente.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 28)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Ramo/Polizza"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 28)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Targa"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 28)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Codice fiscale"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(3, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 28)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Contraente"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Location = New System.Drawing.Point(288, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 28)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Sub"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ButtonCompletaDati
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonCompletaDati, 3)
        Me.ButtonCompletaDati.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCompletaDati.Location = New System.Drawing.Point(288, 31)
        Me.ButtonCompletaDati.Name = "ButtonCompletaDati"
        Me.ButtonCompletaDati.Size = New System.Drawing.Size(265, 22)
        Me.ButtonCompletaDati.TabIndex = 4
        Me.ButtonCompletaDati.Text = "Button1"
        Me.ButtonCompletaDati.UseVisualStyleBackColor = True
        '
        'ButtonCercaCliente
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.ButtonCercaCliente, 2)
        Me.ButtonCercaCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCercaCliente.Location = New System.Drawing.Point(377, 87)
        Me.ButtonCercaCliente.Name = "ButtonCercaCliente"
        Me.ButtonCercaCliente.Size = New System.Drawing.Size(176, 22)
        Me.ButtonCercaCliente.TabIndex = 7
        Me.ButtonCercaCliente.Text = "Button1"
        Me.ButtonCercaCliente.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 6
        Me.tlpMain.SetColumnSpan(Me.TableLayoutPanel2, 4)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxAgenziaSinistro, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxEsercizio, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxNumero, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxDataSinistro, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxDataDenuncia, 5, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxDataApertura, 5, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxGestione, 5, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxCLG, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxCodiceLiquidatore, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxLiquidatore, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxRamoSinistro, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxCodiceLegale, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxTipoSinistro, 3, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label9, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Label11, 2, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label12, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label13, 4, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label14, 4, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label15, 4, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Label16, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TextBoxEvento, 3, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 238)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 5
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(556, 129)
        Me.TableLayoutPanel2.TabIndex = 3
        '
        'TextBoxAgenziaSinistro
        '
        Me.TextBoxAgenziaSinistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxAgenziaSinistro.Location = New System.Drawing.Point(95, 3)
        Me.TextBoxAgenziaSinistro.Name = "TextBoxAgenziaSinistro"
        Me.TextBoxAgenziaSinistro.Size = New System.Drawing.Size(86, 20)
        Me.TextBoxAgenziaSinistro.TabIndex = 0
        Me.TextBoxAgenziaSinistro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxEsercizio
        '
        Me.TextBoxEsercizio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxEsercizio.Location = New System.Drawing.Point(187, 3)
        Me.TextBoxEsercizio.Name = "TextBoxEsercizio"
        Me.TextBoxEsercizio.Size = New System.Drawing.Size(86, 20)
        Me.TextBoxEsercizio.TabIndex = 1
        Me.TextBoxEsercizio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxNumero
        '
        Me.TextBoxNumero.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxNumero.Location = New System.Drawing.Point(279, 3)
        Me.TextBoxNumero.Name = "TextBoxNumero"
        Me.TextBoxNumero.Size = New System.Drawing.Size(86, 20)
        Me.TextBoxNumero.TabIndex = 2
        Me.TextBoxNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxDataSinistro
        '
        Me.TextBoxDataSinistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxDataSinistro.Location = New System.Drawing.Point(463, 3)
        Me.TextBoxDataSinistro.Name = "TextBoxDataSinistro"
        Me.TextBoxDataSinistro.Size = New System.Drawing.Size(90, 20)
        Me.TextBoxDataSinistro.TabIndex = 10
        Me.TextBoxDataSinistro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxDataDenuncia
        '
        Me.TextBoxDataDenuncia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxDataDenuncia.Location = New System.Drawing.Point(463, 28)
        Me.TextBoxDataDenuncia.Name = "TextBoxDataDenuncia"
        Me.TextBoxDataDenuncia.Size = New System.Drawing.Size(90, 20)
        Me.TextBoxDataDenuncia.TabIndex = 11
        Me.TextBoxDataDenuncia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxDataApertura
        '
        Me.TextBoxDataApertura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxDataApertura.Location = New System.Drawing.Point(463, 53)
        Me.TextBoxDataApertura.Name = "TextBoxDataApertura"
        Me.TextBoxDataApertura.Size = New System.Drawing.Size(90, 20)
        Me.TextBoxDataApertura.TabIndex = 12
        Me.TextBoxDataApertura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxGestione
        '
        Me.TextBoxGestione.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxGestione.Location = New System.Drawing.Point(463, 103)
        Me.TextBoxGestione.Name = "TextBoxGestione"
        Me.TextBoxGestione.Size = New System.Drawing.Size(90, 20)
        Me.TextBoxGestione.TabIndex = 13
        Me.TextBoxGestione.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxCLG
        '
        Me.TextBoxCLG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxCLG.Location = New System.Drawing.Point(95, 28)
        Me.TextBoxCLG.Name = "TextBoxCLG"
        Me.TextBoxCLG.Size = New System.Drawing.Size(86, 20)
        Me.TextBoxCLG.TabIndex = 3
        Me.TextBoxCLG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxCodiceLiquidatore
        '
        Me.TextBoxCodiceLiquidatore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxCodiceLiquidatore.Location = New System.Drawing.Point(95, 53)
        Me.TextBoxCodiceLiquidatore.Name = "TextBoxCodiceLiquidatore"
        Me.TextBoxCodiceLiquidatore.Size = New System.Drawing.Size(86, 20)
        Me.TextBoxCodiceLiquidatore.TabIndex = 5
        Me.TextBoxCodiceLiquidatore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxLiquidatore
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.TextBoxLiquidatore, 2)
        Me.TextBoxLiquidatore.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxLiquidatore.Location = New System.Drawing.Point(187, 53)
        Me.TextBoxLiquidatore.Name = "TextBoxLiquidatore"
        Me.TextBoxLiquidatore.Size = New System.Drawing.Size(178, 20)
        Me.TextBoxLiquidatore.TabIndex = 6
        '
        'TextBoxRamoSinistro
        '
        Me.TextBoxRamoSinistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxRamoSinistro.Location = New System.Drawing.Point(95, 78)
        Me.TextBoxRamoSinistro.Name = "TextBoxRamoSinistro"
        Me.TextBoxRamoSinistro.Size = New System.Drawing.Size(86, 20)
        Me.TextBoxRamoSinistro.TabIndex = 7
        Me.TextBoxRamoSinistro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxCodiceLegale
        '
        Me.TextBoxCodiceLegale.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxCodiceLegale.Location = New System.Drawing.Point(95, 103)
        Me.TextBoxCodiceLegale.Name = "TextBoxCodiceLegale"
        Me.TextBoxCodiceLegale.Size = New System.Drawing.Size(86, 20)
        Me.TextBoxCodiceLegale.TabIndex = 9
        Me.TextBoxCodiceLegale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBoxTipoSinistro
        '
        Me.TextBoxTipoSinistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxTipoSinistro.Location = New System.Drawing.Point(279, 78)
        Me.TextBoxTipoSinistro.Name = "TextBoxTipoSinistro"
        Me.TextBoxTipoSinistro.Size = New System.Drawing.Size(86, 20)
        Me.TextBoxTipoSinistro.TabIndex = 8
        Me.TextBoxTipoSinistro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 25)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Numero sinistro"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Location = New System.Drawing.Point(3, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 25)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "CLG"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Location = New System.Drawing.Point(3, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 25)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Liquidatore"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Location = New System.Drawing.Point(3, 75)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 25)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Ramo sinistro"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Location = New System.Drawing.Point(3, 100)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 29)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Codice legale"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Location = New System.Drawing.Point(187, 75)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 25)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Tipo sinistro"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label12.Location = New System.Drawing.Point(371, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(86, 25)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Data sinistro"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label13.Location = New System.Drawing.Point(371, 25)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(86, 25)
        Me.Label13.TabIndex = 22
        Me.Label13.Text = "Data denuncia"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label14.Location = New System.Drawing.Point(371, 50)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(86, 25)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "Data apertura"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label15.Location = New System.Drawing.Point(371, 100)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(86, 29)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "Gestito da"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label16.Location = New System.Drawing.Point(187, 25)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(86, 25)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "Evento"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBoxEvento
        '
        Me.TextBoxEvento.Dock = System.Windows.Forms.DockStyle.Top
        Me.TextBoxEvento.Location = New System.Drawing.Point(279, 28)
        Me.TextBoxEvento.Name = "TextBoxEvento"
        Me.TextBoxEvento.Size = New System.Drawing.Size(86, 20)
        Me.TextBoxEvento.TabIndex = 4
        Me.TextBoxEvento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ButtonOk
        '
        Me.tlpMain.SetColumnSpan(Me.ButtonOk, 3)
        Me.ButtonOk.Location = New System.Drawing.Point(3, 373)
        Me.ButtonOk.Name = "ButtonOk"
        Me.ButtonOk.Size = New System.Drawing.Size(245, 30)
        Me.ButtonOk.TabIndex = 3
        Me.ButtonOk.Text = "Button1"
        Me.ButtonOk.UseVisualStyleBackColor = True
        '
        'ButtonAnnulla
        '
        Me.ButtonAnnulla.Location = New System.Drawing.Point(423, 373)
        Me.ButtonAnnulla.Name = "ButtonAnnulla"
        Me.ButtonAnnulla.Size = New System.Drawing.Size(121, 28)
        Me.ButtonAnnulla.TabIndex = 4
        Me.ButtonAnnulla.Text = "Button2"
        Me.ButtonAnnulla.UseVisualStyleBackColor = True
        '
        'rbSinistriPropri
        '
        Me.rbSinistriPropri.AutoSize = True
        Me.rbSinistriPropri.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.tlpMain.SetColumnSpan(Me.rbSinistriPropri, 2)
        Me.rbSinistriPropri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbSinistriPropri.Location = New System.Drawing.Point(3, 3)
        Me.rbSinistriPropri.Name = "rbSinistriPropri"
        Me.rbSinistriPropri.Size = New System.Drawing.Size(274, 65)
        Me.rbSinistriPropri.TabIndex = 0
        Me.rbSinistriPropri.TabStop = True
        Me.rbSinistriPropri.Text = "RadioButton1"
        Me.rbSinistriPropri.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbSinistriPropri.UseVisualStyleBackColor = True
        '
        'rbAltraCompagnia
        '
        Me.rbAltraCompagnia.AutoSize = True
        Me.rbAltraCompagnia.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.tlpMain.SetColumnSpan(Me.rbAltraCompagnia, 2)
        Me.rbAltraCompagnia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rbAltraCompagnia.Location = New System.Drawing.Point(283, 3)
        Me.rbAltraCompagnia.Name = "rbAltraCompagnia"
        Me.rbAltraCompagnia.Size = New System.Drawing.Size(276, 65)
        Me.rbAltraCompagnia.TabIndex = 1
        Me.rbAltraCompagnia.TabStop = True
        Me.rbAltraCompagnia.Text = "RadioButton2"
        Me.rbAltraCompagnia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbAltraCompagnia.UseVisualStyleBackColor = True
        '
        'FormEditSinistro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 436)
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "FormEditSinistro"
        Me.Text = "FormEditSinistro"
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelPolizza As System.Windows.Forms.Label
    Friend WithEvents LabelSinistro As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonOk As System.Windows.Forms.Button
    Friend WithEvents ButtonAnnulla As System.Windows.Forms.Button
    Friend WithEvents rbSinistriPropri As System.Windows.Forms.RadioButton
    Friend WithEvents rbAltraCompagnia As System.Windows.Forms.RadioButton
    Friend WithEvents TextBoxRamo As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPolizza As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxSub As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxTarga As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCF As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxContraente As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxAgenziaSinistro As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxEsercizio As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNumero As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxDataSinistro As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxDataDenuncia As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxDataApertura As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxGestione As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCLG As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCodiceLiquidatore As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxLiquidatore As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxRamoSinistro As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxCodiceLegale As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxTipoSinistro As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ButtonCompletaDati As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TextBoxEvento As System.Windows.Forms.TextBox
    Friend WithEvents ButtonCercaCliente As System.Windows.Forms.Button
End Class
