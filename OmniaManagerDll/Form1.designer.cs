namespace SplashUniarea
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.webControl1 = new EO.WinForm.WebControl();
            this.webView1 = new EO.WebBrowser.WebView();
            this.Riduci_Espandi = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // webControl1
            // 
            this.webControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webControl1.BackColor = System.Drawing.Color.White;
            this.webControl1.Location = new System.Drawing.Point(1, -1);
            this.webControl1.Name = "webControl1";
            this.webControl1.Size = new System.Drawing.Size(385, 690);
            this.webControl1.TabIndex = 0;
            this.webControl1.Text = "webControl1";
            this.webControl1.WebView = this.webView1;
            // 
            // webView1
            // 
            this.webView1.JSInitCode = "";
            this.webView1.ObjectForScripting = null;
            this.webView1.Url = "www.uniarea.it";
            this.webView1.BeforeNavigate += new EO.WebBrowser.BeforeNavigateHandler(this.webView1_BeforeNavigate);
            this.webView1.LoadCompleted += new EO.WebBrowser.LoadCompletedEventHandler(this.webView1_LoadCompleted);
            // 
            // Riduci_Espandi
            // 
            this.Riduci_Espandi.Location = new System.Drawing.Point(0, 0);
            this.Riduci_Espandi.Name = "Riduci_Espandi";
            this.Riduci_Espandi.Size = new System.Drawing.Size(56, 23);
            this.Riduci_Espandi.TabIndex = 3;
            this.Riduci_Espandi.Text = "Riduci";
            this.Riduci_Espandi.Click += new System.EventHandler(this.Riduci_Espandi_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(159, 509);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Chiama Funzione JS";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
           
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(384, 687);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Riduci_Espandi);
            this.Controls.Add(this.webControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 726);
            this.Name = "Form1";
            this.Text = "OmniaManager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private EO.WinForm.WebControl webControl1;
        public EO.WebBrowser.WebView webView1;
        private System.Windows.Forms.Button Riduci_Espandi;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer2;

    }
}

