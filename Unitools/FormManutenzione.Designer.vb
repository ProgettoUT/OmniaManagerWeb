<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormManutenzione
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonAR = New UtControls.UtFlatButton()
        Me.ButtonBloccoAutomatismi = New UtControls.UtFlatButton()
        Me.ButtonUpdate = New UtControls.UtFlatButton()
        Me.ButtonImportaOmnia = New UtControls.UtFlatButton()
        Me.ButtonImportaDL = New UtControls.UtFlatButton()
        Me.ButtonAvviaOmnia = New UtControls.UtFlatButton()
        Me.ButtonAvviaDL = New UtControls.UtFlatButton()
        Me.ButtonRipristina = New UtControls.UtFlatButton()
        Me.ButtonChiavi = New UtControls.UtFlatButton()
        Me.ButtonCompatta = New UtControls.UtFlatButton()
        Me.ButtonChiaviDb = New UtControls.UtFlatButton()
        Me.ButtonDistinct = New UtControls.UtFlatButton()
        Me.ButtonLiveUpdate = New UtControls.UtFlatButton()
        Me.ButtonFileSIA = New UtControls.UtFlatButton()
        Me.ButtonAnalisiDb = New UtControls.UtFlatButton()
        Me.ButtonAnalisiFlusso = New UtControls.UtFlatButton()
        Me.LabelStato = New System.Windows.Forms.Label()
        Me.ButtonForzaTimer = New System.Windows.Forms.Button()
        Me.ButtonAnalisiMA = New UtControls.UtFlatButton()
        Me.ButtonBackup = New UtControls.UtFlatButton()
        Me.ButtonChiaviManutenzione = New UtControls.UtFlatButton()
        Me.ButtonAbilitazioni = New UtControls.UtFlatButton()
        Me.ButtonEssigReti = New UtControls.UtFlatButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAR, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonBloccoAutomatismi, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonUpdate, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonImportaOmnia, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonImportaDL, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAvviaOmnia, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAvviaDL, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonRipristina, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonChiavi, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonCompatta, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonChiaviDb, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonDistinct, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonLiveUpdate, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonFileSIA, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAnalisiDb, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAnalisiFlusso, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.LabelStato, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonForzaTimer, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAnalisiMA, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonBackup, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonChiaviManutenzione, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonAbilitazioni, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonEssigReti, 2, 4)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(713, 392)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ButtonAR
        '
        Me.ButtonAR.DefaultBorderSize = 0
        Me.ButtonAR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAR.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonAR.FlatAppearance.BorderSize = 0
        Me.ButtonAR.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAR.Location = New System.Drawing.Point(534, 365)
        Me.ButtonAR.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonAR.Name = "ButtonAR"
        Me.ButtonAR.Size = New System.Drawing.Size(179, 27)
        Me.ButtonAR.TabIndex = 23
        Me.ButtonAR.Text = "Assistenza remota"
        Me.ButtonAR.UseVisualStyleBackColor = True
        '
        'ButtonBloccoAutomatismi
        '
        Me.ButtonBloccoAutomatismi.DefaultBorderSize = 0
        Me.ButtonBloccoAutomatismi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonBloccoAutomatismi.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonBloccoAutomatismi.FlatAppearance.BorderSize = 0
        Me.ButtonBloccoAutomatismi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonBloccoAutomatismi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonBloccoAutomatismi.Location = New System.Drawing.Point(534, 292)
        Me.ButtonBloccoAutomatismi.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonBloccoAutomatismi.Name = "ButtonBloccoAutomatismi"
        Me.ButtonBloccoAutomatismi.Size = New System.Drawing.Size(179, 73)
        Me.ButtonBloccoAutomatismi.TabIndex = 22
        Me.ButtonBloccoAutomatismi.Text = "blocco auto"
        Me.ButtonBloccoAutomatismi.UseVisualStyleBackColor = True
        '
        'ButtonUpdate
        '
        Me.ButtonUpdate.DefaultBorderSize = 0
        Me.ButtonUpdate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonUpdate.FlatAppearance.BorderSize = 0
        Me.ButtonUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonUpdate.Location = New System.Drawing.Point(0, 0)
        Me.ButtonUpdate.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonUpdate.Name = "ButtonUpdate"
        Me.ButtonUpdate.Size = New System.Drawing.Size(178, 73)
        Me.ButtonUpdate.TabIndex = 0
        Me.ButtonUpdate.Text = "blocco update"
        Me.ButtonUpdate.UseVisualStyleBackColor = True
        '
        'ButtonImportaOmnia
        '
        Me.ButtonImportaOmnia.DefaultBorderSize = 0
        Me.ButtonImportaOmnia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonImportaOmnia.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonImportaOmnia.FlatAppearance.BorderSize = 0
        Me.ButtonImportaOmnia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonImportaOmnia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonImportaOmnia.Location = New System.Drawing.Point(178, 73)
        Me.ButtonImportaOmnia.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonImportaOmnia.Name = "ButtonImportaOmnia"
        Me.ButtonImportaOmnia.Size = New System.Drawing.Size(178, 73)
        Me.ButtonImportaOmnia.TabIndex = 1
        Me.ButtonImportaOmnia.Text = "consolida omnia"
        Me.ButtonImportaOmnia.UseVisualStyleBackColor = True
        '
        'ButtonImportaDL
        '
        Me.ButtonImportaDL.DefaultBorderSize = 0
        Me.ButtonImportaDL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonImportaDL.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonImportaDL.FlatAppearance.BorderSize = 0
        Me.ButtonImportaDL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonImportaDL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonImportaDL.Location = New System.Drawing.Point(534, 73)
        Me.ButtonImportaDL.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonImportaDL.Name = "ButtonImportaDL"
        Me.ButtonImportaDL.Size = New System.Drawing.Size(179, 73)
        Me.ButtonImportaDL.TabIndex = 2
        Me.ButtonImportaDL.Text = "consolida dl"
        Me.ButtonImportaDL.UseVisualStyleBackColor = True
        '
        'ButtonAvviaOmnia
        '
        Me.ButtonAvviaOmnia.DefaultBorderSize = 0
        Me.ButtonAvviaOmnia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAvviaOmnia.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonAvviaOmnia.FlatAppearance.BorderSize = 0
        Me.ButtonAvviaOmnia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonAvviaOmnia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAvviaOmnia.Location = New System.Drawing.Point(0, 73)
        Me.ButtonAvviaOmnia.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonAvviaOmnia.Name = "ButtonAvviaOmnia"
        Me.ButtonAvviaOmnia.Size = New System.Drawing.Size(178, 73)
        Me.ButtonAvviaOmnia.TabIndex = 3
        Me.ButtonAvviaOmnia.Text = "importa omnia"
        Me.ButtonAvviaOmnia.UseVisualStyleBackColor = True
        '
        'ButtonAvviaDL
        '
        Me.ButtonAvviaDL.DefaultBorderSize = 0
        Me.ButtonAvviaDL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAvviaDL.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonAvviaDL.FlatAppearance.BorderSize = 0
        Me.ButtonAvviaDL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonAvviaDL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAvviaDL.Location = New System.Drawing.Point(356, 73)
        Me.ButtonAvviaDL.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonAvviaDL.Name = "ButtonAvviaDL"
        Me.ButtonAvviaDL.Size = New System.Drawing.Size(178, 73)
        Me.ButtonAvviaDL.TabIndex = 4
        Me.ButtonAvviaDL.Text = "importa da download agenzie"
        Me.ButtonAvviaDL.UseVisualStyleBackColor = True
        '
        'ButtonRipristina
        '
        Me.ButtonRipristina.DefaultBorderSize = 0
        Me.ButtonRipristina.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonRipristina.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.ButtonRipristina.FlatAppearance.BorderSize = 0
        Me.ButtonRipristina.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonRipristina.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonRipristina.Location = New System.Drawing.Point(534, 0)
        Me.ButtonRipristina.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonRipristina.Name = "ButtonRipristina"
        Me.ButtonRipristina.Size = New System.Drawing.Size(179, 73)
        Me.ButtonRipristina.TabIndex = 5
        Me.ButtonRipristina.Text = "ripristino"
        Me.ButtonRipristina.UseVisualStyleBackColor = True
        '
        'ButtonChiavi
        '
        Me.ButtonChiavi.DefaultBorderSize = 0
        Me.ButtonChiavi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonChiavi.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonChiavi.FlatAppearance.BorderSize = 0
        Me.ButtonChiavi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonChiavi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonChiavi.Location = New System.Drawing.Point(534, 219)
        Me.ButtonChiavi.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonChiavi.Name = "ButtonChiavi"
        Me.ButtonChiavi.Size = New System.Drawing.Size(179, 73)
        Me.ButtonChiavi.TabIndex = 6
        Me.ButtonChiavi.Text = "setting"
        Me.ButtonChiavi.UseVisualStyleBackColor = True
        '
        'ButtonCompatta
        '
        Me.ButtonCompatta.DefaultBorderSize = 0
        Me.ButtonCompatta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCompatta.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonCompatta.FlatAppearance.BorderSize = 0
        Me.ButtonCompatta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonCompatta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCompatta.Location = New System.Drawing.Point(178, 146)
        Me.ButtonCompatta.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonCompatta.Name = "ButtonCompatta"
        Me.ButtonCompatta.Size = New System.Drawing.Size(178, 73)
        Me.ButtonCompatta.TabIndex = 7
        Me.ButtonCompatta.Text = "compatta db"
        Me.ButtonCompatta.UseVisualStyleBackColor = True
        '
        'ButtonChiaviDb
        '
        Me.ButtonChiaviDb.DefaultBorderSize = 0
        Me.ButtonChiaviDb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonChiaviDb.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonChiaviDb.FlatAppearance.BorderSize = 0
        Me.ButtonChiaviDb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonChiaviDb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonChiaviDb.Location = New System.Drawing.Point(356, 146)
        Me.ButtonChiaviDb.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonChiaviDb.Name = "ButtonChiaviDb"
        Me.ButtonChiaviDb.Size = New System.Drawing.Size(178, 73)
        Me.ButtonChiaviDb.TabIndex = 8
        Me.ButtonChiaviDb.Text = "chiavi db"
        Me.ButtonChiaviDb.UseVisualStyleBackColor = True
        '
        'ButtonDistinct
        '
        Me.ButtonDistinct.DefaultBorderSize = 0
        Me.ButtonDistinct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonDistinct.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonDistinct.FlatAppearance.BorderSize = 0
        Me.ButtonDistinct.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonDistinct.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDistinct.Location = New System.Drawing.Point(0, 146)
        Me.ButtonDistinct.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonDistinct.Name = "ButtonDistinct"
        Me.ButtonDistinct.Size = New System.Drawing.Size(178, 73)
        Me.ButtonDistinct.TabIndex = 9
        Me.ButtonDistinct.Text = "distinct"
        Me.ButtonDistinct.UseVisualStyleBackColor = True
        '
        'ButtonLiveUpdate
        '
        Me.ButtonLiveUpdate.DefaultBorderSize = 0
        Me.ButtonLiveUpdate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonLiveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonLiveUpdate.FlatAppearance.BorderSize = 0
        Me.ButtonLiveUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonLiveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonLiveUpdate.Location = New System.Drawing.Point(178, 0)
        Me.ButtonLiveUpdate.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonLiveUpdate.Name = "ButtonLiveUpdate"
        Me.ButtonLiveUpdate.Size = New System.Drawing.Size(178, 73)
        Me.ButtonLiveUpdate.TabIndex = 10
        Me.ButtonLiveUpdate.Text = "live update"
        Me.ButtonLiveUpdate.UseVisualStyleBackColor = True
        '
        'ButtonFileSIA
        '
        Me.ButtonFileSIA.DefaultBorderSize = 0
        Me.ButtonFileSIA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonFileSIA.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonFileSIA.FlatAppearance.BorderSize = 0
        Me.ButtonFileSIA.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonFileSIA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFileSIA.Location = New System.Drawing.Point(534, 146)
        Me.ButtonFileSIA.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonFileSIA.Name = "ButtonFileSIA"
        Me.ButtonFileSIA.Size = New System.Drawing.Size(179, 73)
        Me.ButtonFileSIA.TabIndex = 11
        Me.ButtonFileSIA.Text = "File inviati in contabilità"
        Me.ButtonFileSIA.UseVisualStyleBackColor = True
        '
        'ButtonAnalisiDb
        '
        Me.ButtonAnalisiDb.DefaultBorderSize = 0
        Me.ButtonAnalisiDb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnalisiDb.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonAnalisiDb.FlatAppearance.BorderSize = 0
        Me.ButtonAnalisiDb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonAnalisiDb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAnalisiDb.Location = New System.Drawing.Point(0, 219)
        Me.ButtonAnalisiDb.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonAnalisiDb.Name = "ButtonAnalisiDb"
        Me.ButtonAnalisiDb.Size = New System.Drawing.Size(178, 73)
        Me.ButtonAnalisiDb.TabIndex = 12
        Me.ButtonAnalisiDb.Text = "analisi db"
        Me.ButtonAnalisiDb.UseVisualStyleBackColor = True
        '
        'ButtonAnalisiFlusso
        '
        Me.ButtonAnalisiFlusso.DefaultBorderSize = 0
        Me.ButtonAnalisiFlusso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnalisiFlusso.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonAnalisiFlusso.FlatAppearance.BorderSize = 0
        Me.ButtonAnalisiFlusso.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonAnalisiFlusso.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAnalisiFlusso.Location = New System.Drawing.Point(178, 219)
        Me.ButtonAnalisiFlusso.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonAnalisiFlusso.Name = "ButtonAnalisiFlusso"
        Me.ButtonAnalisiFlusso.Size = New System.Drawing.Size(178, 73)
        Me.ButtonAnalisiFlusso.TabIndex = 13
        Me.ButtonAnalisiFlusso.Text = "analisi flusso"
        Me.ButtonAnalisiFlusso.UseVisualStyleBackColor = True
        '
        'LabelStato
        '
        Me.LabelStato.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.LabelStato, 2)
        Me.LabelStato.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelStato.Location = New System.Drawing.Point(3, 365)
        Me.LabelStato.Name = "LabelStato"
        Me.LabelStato.Size = New System.Drawing.Size(350, 27)
        Me.LabelStato.TabIndex = 14
        Me.LabelStato.Text = "Label1"
        '
        'ButtonForzaTimer
        '
        Me.ButtonForzaTimer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonForzaTimer.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonForzaTimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonForzaTimer.Location = New System.Drawing.Point(356, 365)
        Me.ButtonForzaTimer.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonForzaTimer.Name = "ButtonForzaTimer"
        Me.ButtonForzaTimer.Size = New System.Drawing.Size(178, 27)
        Me.ButtonForzaTimer.TabIndex = 15
        Me.ButtonForzaTimer.Text = "Forza esecuzione timer"
        Me.ButtonForzaTimer.UseVisualStyleBackColor = True
        '
        'ButtonAnalisiMA
        '
        Me.ButtonAnalisiMA.DefaultBorderSize = 0
        Me.ButtonAnalisiMA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAnalisiMA.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonAnalisiMA.FlatAppearance.BorderSize = 0
        Me.ButtonAnalisiMA.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonAnalisiMA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAnalisiMA.Location = New System.Drawing.Point(356, 219)
        Me.ButtonAnalisiMA.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonAnalisiMA.Name = "ButtonAnalisiMA"
        Me.ButtonAnalisiMA.Size = New System.Drawing.Size(178, 73)
        Me.ButtonAnalisiMA.TabIndex = 16
        Me.ButtonAnalisiMA.Text = "analisi file ma"
        Me.ButtonAnalisiMA.UseVisualStyleBackColor = True
        '
        'ButtonBackup
        '
        Me.ButtonBackup.DefaultBorderSize = 0
        Me.ButtonBackup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonBackup.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonBackup.FlatAppearance.BorderSize = 0
        Me.ButtonBackup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonBackup.Location = New System.Drawing.Point(356, 0)
        Me.ButtonBackup.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonBackup.Name = "ButtonBackup"
        Me.ButtonBackup.Size = New System.Drawing.Size(178, 73)
        Me.ButtonBackup.TabIndex = 17
        Me.ButtonBackup.Text = "Backup"
        Me.ButtonBackup.UseVisualStyleBackColor = True
        '
        'ButtonChiaviManutenzione
        '
        Me.ButtonChiaviManutenzione.DefaultBorderSize = 0
        Me.ButtonChiaviManutenzione.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonChiaviManutenzione.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonChiaviManutenzione.FlatAppearance.BorderSize = 0
        Me.ButtonChiaviManutenzione.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonChiaviManutenzione.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonChiaviManutenzione.Location = New System.Drawing.Point(0, 292)
        Me.ButtonChiaviManutenzione.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonChiaviManutenzione.Name = "ButtonChiaviManutenzione"
        Me.ButtonChiaviManutenzione.Size = New System.Drawing.Size(178, 73)
        Me.ButtonChiaviManutenzione.TabIndex = 18
        Me.ButtonChiaviManutenzione.Text = "Chiavi manutenzione"
        Me.ButtonChiaviManutenzione.UseVisualStyleBackColor = True
        '
        'ButtonAbilitazioni
        '
        Me.ButtonAbilitazioni.DefaultBorderSize = 0
        Me.ButtonAbilitazioni.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAbilitazioni.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonAbilitazioni.FlatAppearance.BorderSize = 0
        Me.ButtonAbilitazioni.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonAbilitazioni.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAbilitazioni.Location = New System.Drawing.Point(178, 292)
        Me.ButtonAbilitazioni.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonAbilitazioni.Name = "ButtonAbilitazioni"
        Me.ButtonAbilitazioni.Size = New System.Drawing.Size(178, 73)
        Me.ButtonAbilitazioni.TabIndex = 20
        Me.ButtonAbilitazioni.Text = "abilitazioni"
        Me.ButtonAbilitazioni.UseVisualStyleBackColor = True
        '
        'ButtonEssigReti
        '
        Me.ButtonEssigReti.DefaultBorderSize = 0
        Me.ButtonEssigReti.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEssigReti.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ButtonEssigReti.FlatAppearance.BorderSize = 0
        Me.ButtonEssigReti.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Moccasin
        Me.ButtonEssigReti.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEssigReti.Location = New System.Drawing.Point(356, 292)
        Me.ButtonEssigReti.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonEssigReti.Name = "ButtonEssigReti"
        Me.ButtonEssigReti.Size = New System.Drawing.Size(178, 73)
        Me.ButtonEssigReti.TabIndex = 21
        Me.ButtonEssigReti.Text = "essig reti"
        Me.ButtonEssigReti.UseVisualStyleBackColor = True
        '
        'FormManutenzione
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(713, 392)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FormManutenzione"
        Me.Text = "FormManutenzione"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonUpdate As UtControls.UtFlatButton
    Friend WithEvents ButtonImportaOmnia As UtControls.UtFlatButton
    Friend WithEvents ButtonImportaDL As UtControls.UtFlatButton
    Friend WithEvents ButtonAvviaOmnia As UtControls.UtFlatButton
    Friend WithEvents ButtonAvviaDL As UtControls.UtFlatButton
    Friend WithEvents ButtonRipristina As UtControls.UtFlatButton
    Friend WithEvents ButtonChiavi As UtControls.UtFlatButton
    Friend WithEvents ButtonCompatta As UtControls.UtFlatButton
    Friend WithEvents ButtonChiaviDb As UtControls.UtFlatButton
    Friend WithEvents ButtonDistinct As UtControls.UtFlatButton
    Friend WithEvents ButtonLiveUpdate As UtControls.UtFlatButton
    Friend WithEvents ButtonFileSIA As UtControls.UtFlatButton
    Friend WithEvents ButtonAnalisiDb As UtControls.UtFlatButton
    Friend WithEvents ButtonAnalisiFlusso As UtControls.UtFlatButton
    Friend WithEvents LabelStato As System.Windows.Forms.Label
    Friend WithEvents ButtonForzaTimer As System.Windows.Forms.Button
    Friend WithEvents ButtonAnalisiMA As UtControls.UtFlatButton
    Friend WithEvents ButtonBackup As UtControls.UtFlatButton
    Friend WithEvents ButtonChiaviManutenzione As UtControls.UtFlatButton
    Friend WithEvents ButtonAbilitazioni As UtControls.UtFlatButton
    Friend WithEvents ButtonEssigReti As UtControls.UtFlatButton
    Friend WithEvents ButtonBloccoAutomatismi As UtControls.UtFlatButton
    Friend WithEvents ButtonAR As UtControls.UtFlatButton
End Class
