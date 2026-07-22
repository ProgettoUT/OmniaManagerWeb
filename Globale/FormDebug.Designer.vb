<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDebug
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
        Me.tlpGriglia = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonEsci = New System.Windows.Forms.Button()
        Me.dgvDebug = New System.Windows.Forms.DataGridView()
        Me.LabelRecord = New System.Windows.Forms.Label()
        Me.LabelMessaggio = New System.Windows.Forms.Label()
        Me.ButtonCsv = New System.Windows.Forms.Button()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpComandi = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonCreaDb = New System.Windows.Forms.Button()
        Me.ButtonLiveUp = New System.Windows.Forms.Button()
        Me.ButtonAggiornamentoSinistri = New System.Windows.Forms.Button()
        Me.ButtonConsolidaDB = New System.Windows.Forms.Button()
        Me.ButtonCreaDbNote = New System.Windows.Forms.Button()
        Me.ButtonSIA = New System.Windows.Forms.Button()
        Me.ButtonCancellaExtra = New System.Windows.Forms.Button()
        Me.ButtonAttivaExtra = New System.Windows.Forms.Button()
        Me.ButtonMA2SIA = New System.Windows.Forms.Button()
        Me.ButtonSetting = New System.Windows.Forms.Button()
        Me.ButtonConsolidaMA = New System.Windows.Forms.Button()
        Me.ButtonMaxOnLine = New System.Windows.Forms.Button()
        Me.ButtonPostalizzazione = New System.Windows.Forms.Button()
        Me.tlpGriglia.SuspendLayout()
        CType(Me.dgvDebug, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpMain.SuspendLayout()
        Me.tlpComandi.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlpGriglia
        '
        Me.tlpGriglia.ColumnCount = 3
        Me.tlpGriglia.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlpGriglia.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.tlpGriglia.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.tlpGriglia.Controls.Add(Me.ButtonEsci, 2, 2)
        Me.tlpGriglia.Controls.Add(Me.dgvDebug, 0, 0)
        Me.tlpGriglia.Controls.Add(Me.LabelRecord, 0, 2)
        Me.tlpGriglia.Controls.Add(Me.LabelMessaggio, 0, 1)
        Me.tlpGriglia.Controls.Add(Me.ButtonCsv, 1, 2)
        Me.tlpGriglia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpGriglia.Location = New System.Drawing.Point(3, 3)
        Me.tlpGriglia.Name = "tlpGriglia"
        Me.tlpGriglia.RowCount = 3
        Me.tlpGriglia.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpGriglia.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.tlpGriglia.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tlpGriglia.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.tlpGriglia.Size = New System.Drawing.Size(710, 325)
        Me.tlpGriglia.TabIndex = 0
        '
        'ButtonEsci
        '
        Me.ButtonEsci.BackColor = System.Drawing.Color.Khaki
        Me.ButtonEsci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonEsci.Location = New System.Drawing.Point(251, 268)
        Me.ButtonEsci.Name = "ButtonEsci"
        Me.ButtonEsci.Size = New System.Drawing.Size(456, 54)
        Me.ButtonEsci.TabIndex = 0
        Me.ButtonEsci.Text = "Esci"
        Me.ButtonEsci.UseVisualStyleBackColor = False
        '
        'dgvDebug
        '
        Me.dgvDebug.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tlpGriglia.SetColumnSpan(Me.dgvDebug, 3)
        Me.dgvDebug.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDebug.Location = New System.Drawing.Point(3, 3)
        Me.dgvDebug.Name = "dgvDebug"
        Me.dgvDebug.Size = New System.Drawing.Size(704, 209)
        Me.dgvDebug.TabIndex = 1
        '
        'LabelRecord
        '
        Me.LabelRecord.AutoSize = True
        Me.LabelRecord.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelRecord.Location = New System.Drawing.Point(3, 265)
        Me.LabelRecord.Name = "LabelRecord"
        Me.LabelRecord.Size = New System.Drawing.Size(44, 60)
        Me.LabelRecord.TabIndex = 2
        Me.LabelRecord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelMessaggio
        '
        Me.LabelMessaggio.AutoSize = True
        Me.LabelMessaggio.BackColor = System.Drawing.Color.LightGreen
        Me.LabelMessaggio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpGriglia.SetColumnSpan(Me.LabelMessaggio, 3)
        Me.LabelMessaggio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelMessaggio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabelMessaggio.Location = New System.Drawing.Point(3, 215)
        Me.LabelMessaggio.Name = "LabelMessaggio"
        Me.LabelMessaggio.Size = New System.Drawing.Size(704, 50)
        Me.LabelMessaggio.TabIndex = 3
        Me.LabelMessaggio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButtonCsv
        '
        Me.ButtonCsv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCsv.Location = New System.Drawing.Point(53, 268)
        Me.ButtonCsv.Name = "ButtonCsv"
        Me.ButtonCsv.Size = New System.Drawing.Size(192, 54)
        Me.ButtonCsv.TabIndex = 4
        Me.ButtonCsv.Text = "Esporta in CSV"
        Me.ButtonCsv.UseVisualStyleBackColor = True
        '
        'tlpMain
        '
        Me.tlpMain.ColumnCount = 1
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Controls.Add(Me.tlpGriglia, 0, 0)
        Me.tlpMain.Controls.Add(Me.tlpComandi, 0, 1)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 2
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.tlpMain.Size = New System.Drawing.Size(716, 553)
        Me.tlpMain.TabIndex = 1
        '
        'tlpComandi
        '
        Me.tlpComandi.ColumnCount = 4
        Me.tlpComandi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpComandi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpComandi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpComandi.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpComandi.Controls.Add(Me.ButtonPostalizzazione, 0, 3)
        Me.tlpComandi.Controls.Add(Me.ButtonCreaDb, 2, 2)
        Me.tlpComandi.Controls.Add(Me.ButtonLiveUp, 3, 1)
        Me.tlpComandi.Controls.Add(Me.ButtonAggiornamentoSinistri, 1, 2)
        Me.tlpComandi.Controls.Add(Me.ButtonConsolidaDB, 0, 2)
        Me.tlpComandi.Controls.Add(Me.ButtonCreaDbNote, 2, 1)
        Me.tlpComandi.Controls.Add(Me.ButtonSIA, 2, 0)
        Me.tlpComandi.Controls.Add(Me.ButtonCancellaExtra, 1, 0)
        Me.tlpComandi.Controls.Add(Me.ButtonAttivaExtra, 0, 0)
        Me.tlpComandi.Controls.Add(Me.ButtonMA2SIA, 3, 0)
        Me.tlpComandi.Controls.Add(Me.ButtonSetting, 0, 1)
        Me.tlpComandi.Controls.Add(Me.ButtonConsolidaMA, 3, 2)
        Me.tlpComandi.Controls.Add(Me.ButtonMaxOnLine, 1, 1)
        Me.tlpComandi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpComandi.Location = New System.Drawing.Point(3, 334)
        Me.tlpComandi.Name = "tlpComandi"
        Me.tlpComandi.RowCount = 4
        Me.tlpComandi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpComandi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpComandi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpComandi.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.tlpComandi.Size = New System.Drawing.Size(710, 216)
        Me.tlpComandi.TabIndex = 1
        '
        'ButtonCreaDb
        '
        Me.ButtonCreaDb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCreaDb.Location = New System.Drawing.Point(357, 111)
        Me.ButtonCreaDb.Name = "ButtonCreaDb"
        Me.ButtonCreaDb.Size = New System.Drawing.Size(171, 48)
        Me.ButtonCreaDb.TabIndex = 11
        Me.ButtonCreaDb.Text = "Crea DB agenzia"
        Me.ButtonCreaDb.UseVisualStyleBackColor = True
        '
        'ButtonLiveUp
        '
        Me.ButtonLiveUp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonLiveUp.Location = New System.Drawing.Point(534, 57)
        Me.ButtonLiveUp.Name = "ButtonLiveUp"
        Me.ButtonLiveUp.Size = New System.Drawing.Size(173, 48)
        Me.ButtonLiveUp.TabIndex = 10
        Me.ButtonLiveUp.Text = "Aggiorna data LiveUp"
        Me.ButtonLiveUp.UseVisualStyleBackColor = True
        '
        'ButtonAggiornamentoSinistri
        '
        Me.ButtonAggiornamentoSinistri.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAggiornamentoSinistri.Location = New System.Drawing.Point(180, 111)
        Me.ButtonAggiornamentoSinistri.Name = "ButtonAggiornamentoSinistri"
        Me.ButtonAggiornamentoSinistri.Size = New System.Drawing.Size(171, 48)
        Me.ButtonAggiornamentoSinistri.TabIndex = 9
        Me.ButtonAggiornamentoSinistri.Text = "Aggiornamento sinistri"
        Me.ButtonAggiornamentoSinistri.UseVisualStyleBackColor = True
        '
        'ButtonConsolidaDB
        '
        Me.ButtonConsolidaDB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonConsolidaDB.Location = New System.Drawing.Point(3, 111)
        Me.ButtonConsolidaDB.Name = "ButtonConsolidaDB"
        Me.ButtonConsolidaDB.Size = New System.Drawing.Size(171, 48)
        Me.ButtonConsolidaDB.TabIndex = 8
        Me.ButtonConsolidaDB.Text = "Forza consolida DB"
        Me.ButtonConsolidaDB.UseVisualStyleBackColor = True
        '
        'ButtonCreaDbNote
        '
        Me.ButtonCreaDbNote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCreaDbNote.Location = New System.Drawing.Point(357, 57)
        Me.ButtonCreaDbNote.Name = "ButtonCreaDbNote"
        Me.ButtonCreaDbNote.Size = New System.Drawing.Size(171, 48)
        Me.ButtonCreaDbNote.TabIndex = 7
        Me.ButtonCreaDbNote.Text = "Crea Db note"
        Me.ButtonCreaDbNote.UseVisualStyleBackColor = True
        '
        'ButtonSIA
        '
        Me.ButtonSIA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSIA.Location = New System.Drawing.Point(357, 3)
        Me.ButtonSIA.Name = "ButtonSIA"
        Me.ButtonSIA.Size = New System.Drawing.Size(171, 48)
        Me.ButtonSIA.TabIndex = 0
        Me.ButtonSIA.Text = "Consulta server SIA"
        Me.ButtonSIA.UseVisualStyleBackColor = True
        '
        'ButtonCancellaExtra
        '
        Me.ButtonCancellaExtra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCancellaExtra.Location = New System.Drawing.Point(180, 3)
        Me.ButtonCancellaExtra.Name = "ButtonCancellaExtra"
        Me.ButtonCancellaExtra.Size = New System.Drawing.Size(171, 48)
        Me.ButtonCancellaExtra.TabIndex = 1
        Me.ButtonCancellaExtra.Text = "Cancella menù extra"
        Me.ButtonCancellaExtra.UseVisualStyleBackColor = True
        '
        'ButtonAttivaExtra
        '
        Me.ButtonAttivaExtra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAttivaExtra.Location = New System.Drawing.Point(3, 3)
        Me.ButtonAttivaExtra.Name = "ButtonAttivaExtra"
        Me.ButtonAttivaExtra.Size = New System.Drawing.Size(171, 48)
        Me.ButtonAttivaExtra.TabIndex = 2
        Me.ButtonAttivaExtra.Text = "Attiva menù extra"
        Me.ButtonAttivaExtra.UseVisualStyleBackColor = True
        '
        'ButtonMA2SIA
        '
        Me.ButtonMA2SIA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonMA2SIA.Location = New System.Drawing.Point(534, 3)
        Me.ButtonMA2SIA.Name = "ButtonMA2SIA"
        Me.ButtonMA2SIA.Size = New System.Drawing.Size(173, 48)
        Me.ButtonMA2SIA.TabIndex = 3
        Me.ButtonMA2SIA.Text = "Invia MA a SIA"
        Me.ButtonMA2SIA.UseVisualStyleBackColor = True
        '
        'ButtonSetting
        '
        Me.ButtonSetting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonSetting.Location = New System.Drawing.Point(3, 57)
        Me.ButtonSetting.Name = "ButtonSetting"
        Me.ButtonSetting.Size = New System.Drawing.Size(171, 48)
        Me.ButtonSetting.TabIndex = 4
        Me.ButtonSetting.Text = "Leggi setting agenzia"
        Me.ButtonSetting.UseVisualStyleBackColor = True
        '
        'ButtonConsolidaMA
        '
        Me.ButtonConsolidaMA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonConsolidaMA.Location = New System.Drawing.Point(534, 111)
        Me.ButtonConsolidaMA.Name = "ButtonConsolidaMA"
        Me.ButtonConsolidaMA.Size = New System.Drawing.Size(173, 48)
        Me.ButtonConsolidaMA.TabIndex = 5
        Me.ButtonConsolidaMA.Text = "Consolida MA"
        Me.ButtonConsolidaMA.UseVisualStyleBackColor = True
        '
        'ButtonMaxOnLine
        '
        Me.ButtonMaxOnLine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonMaxOnLine.Location = New System.Drawing.Point(180, 57)
        Me.ButtonMaxOnLine.Name = "ButtonMaxOnLine"
        Me.ButtonMaxOnLine.Size = New System.Drawing.Size(171, 48)
        Me.ButtonMaxOnLine.TabIndex = 6
        Me.ButtonMaxOnLine.Text = "Max utenti on line"
        Me.ButtonMaxOnLine.UseVisualStyleBackColor = True
        '
        'ButtonPostalizzazione
        '
        Me.ButtonPostalizzazione.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonPostalizzazione.Location = New System.Drawing.Point(3, 165)
        Me.ButtonPostalizzazione.Name = "ButtonPostalizzazione"
        Me.ButtonPostalizzazione.Size = New System.Drawing.Size(171, 48)
        Me.ButtonPostalizzazione.TabIndex = 12
        Me.ButtonPostalizzazione.Text = "Elimina blocco postalizzazione"
        Me.ButtonPostalizzazione.UseVisualStyleBackColor = True
        '
        'FormDebug
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 553)
        Me.Controls.Add(Me.tlpMain)
        Me.Name = "FormDebug"
        Me.Text = "Debug"
        Me.tlpGriglia.ResumeLayout(False)
        Me.tlpGriglia.PerformLayout()
        CType(Me.dgvDebug, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpMain.ResumeLayout(False)
        Me.tlpComandi.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlpGriglia As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonEsci As System.Windows.Forms.Button
    Friend WithEvents dgvDebug As System.Windows.Forms.DataGridView
    Friend WithEvents LabelRecord As System.Windows.Forms.Label
    Friend WithEvents LabelMessaggio As System.Windows.Forms.Label
    Friend WithEvents ButtonCsv As System.Windows.Forms.Button
    Friend WithEvents tlpMain As Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpComandi As Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonSIA As Windows.Forms.Button
    Friend WithEvents ButtonCancellaExtra As Windows.Forms.Button
    Friend WithEvents ButtonAttivaExtra As Windows.Forms.Button
    Friend WithEvents ButtonMA2SIA As Windows.Forms.Button
    Friend WithEvents ButtonSetting As Windows.Forms.Button
    Friend WithEvents ButtonConsolidaMA As Windows.Forms.Button
    Friend WithEvents ButtonMaxOnLine As Windows.Forms.Button
    Friend WithEvents ButtonCreaDbNote As Windows.Forms.Button
    Friend WithEvents ButtonConsolidaDB As Windows.Forms.Button
    Friend WithEvents ButtonAggiornamentoSinistri As Windows.Forms.Button
    Friend WithEvents ButtonLiveUp As Windows.Forms.Button
    Friend WithEvents ButtonCreaDb As Windows.Forms.Button
    Friend WithEvents ButtonPostalizzazione As Windows.Forms.Button
End Class
