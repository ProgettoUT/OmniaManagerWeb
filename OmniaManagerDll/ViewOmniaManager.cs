using System;
using System.IO;
using EO;
using System.Windows.Forms;
using System.Drawing;


namespace SplashUniarea
{
    public partial class Form1 : Form
    {
        public event EventHandler<OmniaManagerDll.EventoUniTools> lanciointerno;
        public event EventHandler<OmniaManagerDll.EventoUniTools> chiusurainterno;
        #region variabili per ridimensinamento e spostamento finestra


        int size_W = Screen.PrimaryScreen.Bounds.Width;

        int size_H = Screen.PrimaryScreen.WorkingArea.Height; //Screen.PrimaryScreen.Bounds.Height;

        bool Espanso = true;

        int pos_x = 0;
        int pos_y = 0;
        int final_x = (Screen.PrimaryScreen.Bounds.Width - 400);

        int step = 1000;


        #endregion

        //public static Unitools.InterfacciaMaschera UNI = null;

        string user = ""; // System.Environment.  UserName;
        string machine = System.Environment.MachineName;
        string dirUser = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        string compagnia = "", agenzia = "", codiceAgente = "", prefissoUtente = "";
        //List<string> utentiAgenzia = new List<string>();
        string dirUser1 = "", pathApplicazione = Application.StartupPath;
        //string codiceFiscaleInUniArea = "", applicazioniUtenteInUniArea = "";
        //string hostName = ""; // Retrive the Name of HOST
        //int tempoFullScreen = 0;

        string ut_utente = "";
        string ut_agenzia = "";
        string ut_codiceUtente = "";
        string ut_ruolo = "";
        string ut_codiceFiscale = "";
        bool ut_isAgente = false;
        public bool _PuoiChiudere = true;



        WebBrowser wb ; //new WebBrowser();
 
       // cUtility utility = new cUtility();

        string strHtmlTemplate = "", pathTemplate = "";

        string token = "";


        string cognomeNomeUtente = "", emailUtente = "";
        string global_divisione = "", global_logo_divisione = "";
        string _url = "";
 
        public Form1(string _codiceUtente,string _utente, string _ruolo, string _codiceFiscale, bool _isAgente)
        {
            
            user = ut_codiceUtente = _codiceUtente;
            ut_ruolo = _ruolo;
            ut_codiceFiscale = _codiceFiscale;
            ut_isAgente = _isAgente;
            cognomeNomeUtente = _utente;



            //Program.startSplash();



            //  this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            // System.Threading.Thread.Sleep(2500);

            wb = new WebBrowser();
           
            //bool init_DLL = UNI.InitUnitools();
            //if(!init_DLL)
            //     {
            //        MessageBox.Show("Inizializzazione DLL effettuata");
                  
            //        Program.chiudiSplash();
            //        Application.Exit();

            //    }
          

            agenzia = user.Substring(1, 5);
            compagnia = user.Substring(0, 1);

            //string fileConfig = "";

            if (user.Length != 8)
            {
                MessageBox.Show("Login utente non compatibile con le impostazioni");
                //System.Diagnostics.Process.Start(fileConfig);
                //Program.chiudiSplash();
                //Application.Exit();

            }

         



            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            agenzia = user.Substring(1, 5);
            compagnia = user.Substring(0, 1);


            EO.WebEngine.BrowserOptions options = new EO.WebEngine.BrowserOptions();
            options.AllowJavaScript = true;
            EO.WebEngine.EngineOptions.Default.SetDefaultBrowserOptions(options);

            webView1.JSExtInvoke += new EO.WebBrowser.JSExtInvokeHandler(WebView_JSExtInvoke);


            global_logo_divisione = "us_nodiv.png";


            _url = "strumenti";

        }

        void WebView_JSExtInvoke(object sender, EO.WebBrowser.JSExtInvokeArgs e)
        {
            string browserEngine = "", strIdApplicazione = "", strParam = "";
           

            switch (e.FunctionName)
            {

                 

               case "clickApplicazioneClient":

                    strIdApplicazione = e.Arguments[0] as string;
                    clickApplicazioneClient(strIdApplicazione);
                    break;
                case "clickEsciClient":
                    clickEsciClient();
                    break;
                case "inviaMailContatti":
                    strParam = e.Arguments[0] as string;

                    char[] c = { '|' };
                    string[] arr = strParam.Split(c);

                    inviaMailContatti(arr[0].ToString(), arr[1].ToString());
                    break;

                case "inviaRichiestaApplicazione":
                    strParam = e.Arguments[0] as string;
                    inviaRichiestaApplicazione(strParam);
                    break;

                case "registraUtente":
                    strParam = e.Arguments[0] as string;

                  
                    arr = strParam.Split('|');

                    registraUtente(arr[0].ToString(), arr[1].ToString());
                    break;
                case "Invia_Ticket":
                    Invia_Ticket();
                    break;
               

                case "openNewWindow":
                    strParam = e.Arguments[0] as string;
                    openNewWindow(strParam);
                    break;
                case "clickRefresh":
                    clickRefresh();
                    break;

                case "inviaMailStrumenti":
                    strParam = e.Arguments[0] as string;

                    char[] c2 = { '|' };
                    string[] arr2 = strParam.Split(c2);

                    inviaMailStrumenti(arr2[0].ToString(), arr2[1].ToString());
                    break;

            }
        }



   protected virtual void OnEvento(OmniaManagerDll.EventoUniTools e)
        {
            EventHandler<OmniaManagerDll.EventoUniTools> handler = lanciointerno;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnEventoChiusura(OmniaManagerDll.EventoUniTools e)
        {
            EventHandler<OmniaManagerDll.EventoUniTools> handler = chiusurainterno;

            if (handler != null)
            {
                handler(this, e);
            }
        }


        private void clickApplicazioneClient(string idApplicazione)
        {

            OmniaManagerDll.EventoUniTools args = new OmniaManagerDll.EventoUniTools();
            args.Parametro = idApplicazione;
            OnEvento(args);

            //if(idApplicazione == "1")
            //{
            //    UNI.FunzioneMenu(Unitools.InterfacciaMaschera.MenuKey.SCHEDASINISTRI);
            //    //UNI.VisualizzaMenuClassico(true);
            //}
            //else if (idApplicazione == "2")
            //{
            //    UNI.FunzioneMenu(Unitools.InterfacciaMaschera.MenuKey.STATISTICHE );
            //}
            //else if (idApplicazione == "3")
            //{
            //    UNI.FunzioneMenu(Unitools.InterfacciaMaschera.MenuKey.CAI);
            //}
            //else if (idApplicazione == "4")
            //{
            //    UNI.FunzioneMenu(Unitools.InterfacciaMaschera.MenuKey.BAREMES);
            //}
            //else if (idApplicazione == "5")
            //{
            //    UNI.FunzioneMenu(Unitools.InterfacciaMaschera.MenuKey.REFERENTI);
            //}
            //else if(idApplicazione ==  "Invia_Ticket")
            //{
            //    Invia_Ticket();
            //}



        }

        private void clickEsciClient()
        {

            //  MessageBox.Show("Esci");

            this.WindowState = FormWindowState.Minimized;

        }

        private void clickRefresh()
        {

           // webView1.LoadUrl(pathApplicazione + @"\PagineHtml\" + this.preparaPagina("strumenti"));

            

        }

        private void inviaMailContatti(string mittente, string testoMail)
        {




            //if (!utility.checkMail(mittente))
            //{
            //    MessageBox.Show("Indirizzo mail non valido");
            //    return;
            //}

            //string oggetto = "Richiesta contatti da 1000 & UniTools";
            //string corpo = "L'utente " + cognomeNomeUtente + " ha fatto la seguente richiesta:<br/>";
            //corpo += testoMail;


            //utility.InviaEmail(mittente, "info@uniarea.it", oggetto, corpo, true, "");

            //MessageBox.Show("Messaggio inviato");


        }

        private void inviaMailStrumenti(string mittente, string testoMail)
        {



            //if (!utility.checkMail(mittente))
            //{
            //    MessageBox.Show("Indirizzo mail non valido");
            //    return;
            //}

            //string oggetto = "Richiesta assistenza da 1000 & UniTools";
            //string corpo = "L'utente " + cognomeNomeUtente + " ha fatto la seguente richiesta:<br/>";
            //corpo += testoMail;


            //utility.InviaEmail(mittente, "info@uniarea.it", oggetto, corpo, true, "");

            //MessageBox.Show("Messaggio inviato");

        }

        private void inviaRichiestaApplicazione(string strDati)
        {

            //char[] c = { '|' };
            //string[] arr = strDati.Split(c);


            //if (!utility.checkMail(arr[0].ToString()))
            //{
            //    MessageBox.Show("Indirizzo mail non valido");
            //    return;
            //}

            //string oggetto = "Richiesta contatti da Supporto Strumenti e Apps";
            //string corpo = "L'utente " + cognomeNomeUtente + " ha fatto la seguente richiesta:<br/>";
            //corpo += "Oggetto richiesta: " + arr[1].ToString() + "<br/>";
            //corpo += arr[2].ToString();


            //utility.InviaEmail(arr[0].ToString(), "info@uniarea.it", oggetto, corpo, true, "");

            //MessageBox.Show("Messaggio inviato");


        }




        private void openNewWindow(string strUrl)
        {
            System.Diagnostics.Process.Start(strUrl);
            this.WindowState = FormWindowState.Minimized;


        }


        private void Form1_Load(object sender, EventArgs e)
        {


            this.Size = new System.Drawing.Size(size_W, size_H);
            this.DesktopLocation = new Point(0, 0);
            /////////// grandezza minima
            double w = Screen.PrimaryScreen.Bounds.Width;
            double p = 0.6;
            int size_W_init = (int) (w*p);
            double H = Screen.PrimaryScreen.WorkingArea.Height;
            int size_H_init = (int) (H*p); //Screen.PrimaryScreen.Bounds.Height;

            //int pos_x = 0;
            int pos_y = 0;
            int pos_x = (int)Screen.PrimaryScreen.Bounds.Width / 2;
            this.MinimumSize = new System.Drawing.Size(size_W_init, size_H_init);
            //this.Size = new System.Drawing.Size(size_W_init, size_H_init);
            //this.DesktopLocation = new Point(pos_x, pos_y);
            //this.Invalidate();
            this.Invalidate();

            int pos = 0;
            pos = dirUser.LastIndexOf(user);
            if (pos > 0)
                dirUser = dirUser.Substring(0, pos);


            compagnia = user.Substring(0, 1);
            agenzia = user.Substring(1, 5);
            codiceAgente = user;
            prefissoUtente = user.Substring(0, 6);

            dirUser1 = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);



            webView1.LoadUrl(pathApplicazione + @"\PagineHtml\" + this.preparaPagina("strumenti"));
        }



        private void webView1_BeforeNavigate(object sender, EO.WebBrowser.BeforeNavigateEventArgs e)
        {
            
            {



                string temp = e.NewUrl.ToString();
             

                if (temp.LastIndexOf("/index.html") > -1)
                {

                    webView1.LoadUrl(pathApplicazione + @"\PagineHtml\" + this.preparaPagina("strumenti"));

                }
                else if (temp.LastIndexOf("/sinistri.html")>-1)
                {
                  
                    webView1.LoadUrl(pathApplicazione + @"\PagineHtml\" + this.preparaPagina("sinistri"));

                }
                else if (temp.LastIndexOf("/registrazione.html") > -1)
                {


                    webView1.LoadUrl(pathApplicazione + @"\PagineHtml\" + this.preparaPagina("registrazione"));

                }
                else if (temp.LastIndexOf("/assistenza.html") > -1)
                {

                    webView1.LoadUrl(pathApplicazione + @"\PagineHtml\" + this.preparaPagina("assistenza"));

                }
                else if (temp.LastIndexOf("/contatti.html") > -1)
                {

                    webView1.LoadUrl(pathApplicazione + @"\PagineHtml\" + this.preparaPagina("contatti"));

                }
                else if (temp.LastIndexOf("/notizie.html") > -1)
                {

                    webView1.LoadUrl(pathApplicazione + @"\PagineHtml\" + this.preparaPagina("notizie"));

                }
                else if (temp.LastIndexOf("/index_mini.html") > -1)
                {

                    webView1.LoadUrl(pathApplicazione + @"\PagineHtml\" + this.preparaPagina("index_mini"));

                }
                else
                {
                    _url = temp;
                }

               
               

            }



        }


       
 

     
     

        private void Riduci_Espandi_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
          
            if (Espanso)
            {

                size_W = 400;
                pos_x = (Screen.PrimaryScreen.Bounds.Width - 400);

                this.Size = new System.Drawing.Size(size_W, size_H);
                this.DesktopLocation = new Point(pos_x, pos_y);
                //this.Size = new System.Drawing.Size(50, 65);
                //this.DesktopLocation = new Point(0, 0);
                Espanso = false;
                webView1.LoadUrl(pathApplicazione + @"\PagineHtml\" + this.preparaPagina("index_mini"));
               
                Riduci_Espandi.Text = "Espandi";

                this.Invalidate();
            }
            else
            {
                this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                this.DesktopLocation = new Point(0, 0);
                Espanso = true;
                webView1.LoadUrl(pathApplicazione + @"\PagineHtml\" + this.preparaPagina("strumenti"));

                Riduci_Espandi.Text = "Riduci";

                this.Invalidate();
            }

        }

     
       

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           

            OmniaManagerDll.EventoUniTools args = new OmniaManagerDll.EventoUniTools();
            args.Parametro = "";
            OnEventoChiusura(args);

            //if (MessageBox.Show("Sicuro di voler uscire da OmniaManager?", "OmniaManager",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            //    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.No)
           if(!_PuoiChiudere)
                {
                e.Cancel = true;
            }
        }

        private void setToken()
        {
            string g = DateTime.Today.Day.ToString();
            string m = DateTime.Today.Month.ToString();
            string a = DateTime.Today.Year.ToString();

            if (g.Length == 1)
                g = "0" + g;

            if (m.Length == 1)
                m = "0" + m;

            string s = "UA" + g + m + a;

            System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create();

            token = classMD5.GetMd5Hash(md5Hash, s);
        }


 


        #region preparazione pagina da vsualizzare all'utente

        /// <summary>
        /// Effettua i replace nel template, crea il file per l'utente e ritorna l'url della pagina da visualizzare
        /// </summary>
        /// <param name="nomeTemplate"></param>
        /// <returns></returns>
        private string preparaPagina(string nomeTemplate)
        {
            string paginaHtmlOutput = "";

            //this.setDataTableApplicazioni();

            string urlRitorno = "";
            int i = 0;

            if(nomeTemplate== "strumenti")
            {
                pathTemplate = pathApplicazione + @"\PagineHtml\index.html";

                StreamReader sr = new StreamReader(pathTemplate, System.Text.Encoding.UTF8);
                strHtmlTemplate = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();

                paginaHtmlOutput = strHtmlTemplate;
                paginaHtmlOutput = paginaHtmlOutput.Replace("{utente}", codiceAgente + " " + cognomeNomeUtente);
                paginaHtmlOutput = paginaHtmlOutput.Replace("{agenzia}", agenzia);
                paginaHtmlOutput = paginaHtmlOutput.Replace("{logoDivisione}", global_logo_divisione);
                //paginaHtmlOutput = paginaHtmlOutput.Replace("{emailMittente}", emailUtente);

                
            }
            else if (nomeTemplate == "sinistri")
            {
                pathTemplate = pathApplicazione + @"\PagineHtml\sinistri.html";

                StreamReader sr = new StreamReader(pathTemplate, System.Text.Encoding.UTF8);
                strHtmlTemplate = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();

                paginaHtmlOutput = strHtmlTemplate;
                paginaHtmlOutput = paginaHtmlOutput.Replace("{utente}", codiceAgente + " " + cognomeNomeUtente);
                paginaHtmlOutput = paginaHtmlOutput.Replace("{agenzia}", agenzia);
                paginaHtmlOutput = paginaHtmlOutput.Replace("{logoDivisione}", global_logo_divisione);
               
               
            }
            else if (nomeTemplate == "index_mini")
            {
                pathTemplate = pathApplicazione + @"\PagineHtml\index_mini.html";

                StreamReader sr = new StreamReader(pathTemplate, System.Text.Encoding.UTF8);
                strHtmlTemplate = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();

                paginaHtmlOutput = strHtmlTemplate;
                paginaHtmlOutput = paginaHtmlOutput.Replace("{utente}", codiceAgente + " " + cognomeNomeUtente);
                paginaHtmlOutput = paginaHtmlOutput.Replace("{agenzia}", agenzia);
                paginaHtmlOutput = paginaHtmlOutput.Replace("{logoDivisione}", global_logo_divisione);


            }
            else if (nomeTemplate == "assistenza")
            {
                pathTemplate = pathApplicazione + @"\PagineHtml\assistenza.html";

                StreamReader sr = new StreamReader(pathTemplate, System.Text.Encoding.UTF8);
                strHtmlTemplate = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();

                paginaHtmlOutput = strHtmlTemplate;
                paginaHtmlOutput = paginaHtmlOutput.Replace("{utente}", codiceAgente + " " + cognomeNomeUtente);
                paginaHtmlOutput = paginaHtmlOutput.Replace("{agenzia}", agenzia);
                paginaHtmlOutput = paginaHtmlOutput.Replace("{logoDivisione}", global_logo_divisione);
          

            }
            else if (nomeTemplate == "contatti")
            {
                pathTemplate = pathApplicazione + @"\PagineHtml\contatti.html";

                StreamReader sr = new StreamReader(pathTemplate, System.Text.Encoding.UTF8);
                strHtmlTemplate = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();

                paginaHtmlOutput = strHtmlTemplate;
                paginaHtmlOutput = paginaHtmlOutput.Replace("{utente}", codiceAgente + " " + cognomeNomeUtente);
                paginaHtmlOutput = paginaHtmlOutput.Replace("{agenzia}", agenzia);
                paginaHtmlOutput = paginaHtmlOutput.Replace("{logoDivisione}", global_logo_divisione);


            }
            else if (nomeTemplate == "notizie")
            {
                pathTemplate = pathApplicazione + @"\PagineHtml\notizie.html";

                StreamReader sr = new StreamReader(pathTemplate, System.Text.Encoding.UTF8);
                strHtmlTemplate = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();

                paginaHtmlOutput = strHtmlTemplate;
                paginaHtmlOutput = paginaHtmlOutput.Replace("{utente}", codiceAgente + " " + cognomeNomeUtente);
                paginaHtmlOutput = paginaHtmlOutput.Replace("{agenzia}", agenzia);
                paginaHtmlOutput = paginaHtmlOutput.Replace("{logoDivisione}", global_logo_divisione);


            }
            else if (nomeTemplate == "registrazione")
            {

                string strEmail = "", strTelefono = "";

                pathTemplate = pathApplicazione + @"\PagineHtml\registrazione.html";

                StreamReader sr = new StreamReader(pathTemplate, System.Text.Encoding.UTF8);
                strHtmlTemplate = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();

                paginaHtmlOutput = strHtmlTemplate;
                paginaHtmlOutput = paginaHtmlOutput.Replace("{utente}", codiceAgente + " " + cognomeNomeUtente);
                paginaHtmlOutput = paginaHtmlOutput.Replace("{agenzia}", agenzia);
                paginaHtmlOutput = paginaHtmlOutput.Replace("{logoDivisione}", global_logo_divisione);
                paginaHtmlOutput = paginaHtmlOutput.Replace("{nome}", cognomeNomeUtente);
                paginaHtmlOutput = paginaHtmlOutput.Replace("{codice_fiscale}", ut_codiceFiscale);
                paginaHtmlOutput = paginaHtmlOutput.Replace("{ruolo_professionale}", ut_ruolo);


                OmniaManagerDll.it.uniarea.ws.accessoCasa ws = new OmniaManagerDll.it.uniarea.ws.accessoCasa();

                string esito = ws.getDatiUtenteByCodiceFiscale(this.getToken(), ut_codiceFiscale);


                string[] arr = null;

                if (esito.LastIndexOf("|") > -1)
                {
                    arr = esito.Split('|');

                    strEmail = arr[0];
                    strTelefono= arr[1];

                }
                else
                {
                    arr = new string[1];
                    arr[0] = esito;
                }


                paginaHtmlOutput = paginaHtmlOutput.Replace("{email_personale}", strEmail);
                paginaHtmlOutput = paginaHtmlOutput.Replace("{telefono}", strTelefono);


            }


            StreamWriter sw = new StreamWriter(pathApplicazione + @"\PagineHtml\" + codiceAgente + ".html", false, System.Text.Encoding.UTF8);
            sw.Write(paginaHtmlOutput);
            sw.Close();
            sw.Dispose();

            urlRitorno = codiceAgente + ".html";


            //if (nomeTemplate == "strumenti")
            //{
            //    pathTemplate = pathApplicazione + @"\PagineHtml\template_strumenti.html";

            //    StreamReader sr = new StreamReader(pathTemplate, System.Text.Encoding.UTF8);
            //    strHtmlTemplate = sr.ReadToEnd();
            //    sr.Close();
            //    sr.Dispose();

            //    string paginaHtmlOutput = strHtmlTemplate;
            //    paginaHtmlOutput = paginaHtmlOutput.Replace("{utente}", codiceAgente + " " + cognomeNomeUtente);
            //    paginaHtmlOutput = paginaHtmlOutput.Replace("{agenzia}", agenzia);
            //    paginaHtmlOutput = paginaHtmlOutput.Replace("{logoDivisione}", global_logo_divisione);
            //    paginaHtmlOutput = paginaHtmlOutput.Replace("{emailMittente}", emailUtente);


            //    string fileConfig = "";
            //    fileConfig = Path.Combine(pathApplicazione, "UniareaImpostazioni.exe");
            //    Configuration configuration = ConfigurationManager.OpenExeConfiguration(fileConfig);



            //    #region scorro le chiavi del App.config

            //    ////string strApplicazioni = configuration.AppSettings.Settings["appuser_" + codiceAgente] == null ? string.Empty : configuration.AppSettings.Settings["appuser_" + codiceAgente].Value.ToString();
            //    //string strApplicazioni = applicazioniUtenteInUniArea;
            //    //char[] c = { '|' };
            //    //string[] arr_applicazioni = null;

            //    //if (strApplicazioni.Trim() != "")
            //    //{
            //    //    if (strApplicazioni.LastIndexOf("|") > -1)
            //    //        arr_applicazioni = strApplicazioni.Split(c);
            //    //    else
            //    //    {
            //    //        arr_applicazioni = new string[1];
            //    //        arr_applicazioni[0] = strApplicazioni;

            //    //    }


            //    //    for (i = 0; i < arr_applicazioni.Length; i++)
            //    //    {
            //    //        DataRow[] r = dtApplicazioni.Select("id='" + arr_applicazioni[i].ToString() + "'");
            //    //        if (r.Length > 0)
            //    //        {
            //    //            r[0]["utenteAbilitato"] = "1";
            //    //        }
            //    //    }
            //    //}

            //    #endregion


            //    string strHtmlRigheApplicazioni = "";
            //    //i = 0;
            //    ////string tmp="";
            //    //foreach (DataRow r in dtApplicazioni.Rows)
            //    //{



            //    //    i++;

            //    //    if (i == 1)
            //    //    {
            //    //        //strHtmlRigheApplicazioni += "<div class='row'>";
            //    //    }

            //    //    if (r["utenteAbilitato"].ToString() == "1")
            //    //    {


            //    //       //trHtmlRigheApplicazioni += "<div class='col-lg-3 col-xs-6'>";

            //    //        if (r["stato"].ToString() == "1")
            //    //            strHtmlRigheApplicazioni += r["htmlLogoApplicazione"].ToString();
            //    //        else
            //    //            strHtmlRigheApplicazioni += r["htmlLogoApplicazione_nonAttiva"].ToString();


            //    //        //strHtmlRigheApplicazioni += "</div>";
            //    //    }
            //    //    else
            //    //    {
            //    //        //strHtmlRigheApplicazioni += "<div class='col-lg-3 col-xs-6'>";

            //    //        if (r["stato"].ToString() == "0" || r["stato"].ToString() == "-1")
            //    //            strHtmlRigheApplicazioni += r["htmlLogoApplicazione_nonAttiva"].ToString();
            //    //        else
            //    //            strHtmlRigheApplicazioni += r["htmlLogoApplicazione_nonAttivaU"].ToString();

            //    //       // strHtmlRigheApplicazioni += "</div>";
            //    //    }



            //        //if (i == 4)
            //        //{
            //        //    i = 0;
            //        //   // strHtmlRigheApplicazioni += "</div>";
            //        //}
            //    }


            //    //if (i > 0 && i < 4)
            //    //{
            //    //   // strHtmlRigheApplicazioni += "</div>";
            //    //}



            //    //paginaHtmlOutput = paginaHtmlOutput.Replace("{applicazioni}", strHtmlRigheApplicazioni);




            //    //StreamWriter sw = new StreamWriter(pathApplicazione + @"\PagineHtml\" + codiceAgente + ".html", false, System.Text.Encoding.UTF8);
            //    //sw.Write(paginaHtmlOutput);
            //    //sw.Close();
            //    //sw.Dispose();

            //    //urlRitorno = codiceAgente + ".html";
            //}
            //else if (nomeTemplate == "servizi")
            //{

            //    {
            //        pathTemplate = pathApplicazione + @"\PagineHtml\template_" + nomeTemplate + ".html";
            //    }

            //    string strHtmlRigheApplicazioni = "", strHtmlRigaBanner="";

            //    StreamReader sr = new StreamReader(pathTemplate, System.Text.Encoding.UTF8);
            //    strHtmlTemplate = sr.ReadToEnd();
            //    sr.Close();
            //    sr.Dispose();

            //    string paginaHtmlOutput = strHtmlTemplate;
            //    paginaHtmlOutput = paginaHtmlOutput.Replace("{utente}", codiceAgente + " " + cognomeNomeUtente);
            //    paginaHtmlOutput = paginaHtmlOutput.Replace("{agenzia}", agenzia);
            //    paginaHtmlOutput = paginaHtmlOutput.Replace("{logoDivisione}", global_logo_divisione);

            //    if(!offLine)
            //    {

            //        string[] arr_servizi = null;
            //        char[] c = { '|' };
            //        string strServizi = "";
            //         strServizi = _ws.getServizi(token);



            //             if (strServizi.Trim() != "")
            //             {

            //                 if (strServizi.IndexOf("|") > -1)
            //                 {
            //                     arr_servizi = strServizi.Split(c);
            //                 }
            //                 else
            //                 {
            //                     arr_servizi = new string[1];
            //                     arr_servizi[0] = strServizi;
            //                 }


            //                 strHtmlRigheApplicazioni += "<div class='row'>";
            //                 int j = 0;

            //                 for (j = 0; j < arr_servizi.Length - 1; j++)
            //                 {
            //                     strHtmlRigheApplicazioni += arr_servizi[j].ToString();
            //                 }


            //                 strHtmlRigheApplicazioni += "</div>";

            //                 strHtmlRigaBanner = arr_servizi[4].ToString();


            //                 paginaHtmlOutput = paginaHtmlOutput.Replace("{servizi}", strHtmlRigheApplicazioni);
            //                 paginaHtmlOutput = paginaHtmlOutput.Replace("{riga_banner}", strHtmlRigaBanner);

            //             }

            //    }


            //        StreamWriter sw = new StreamWriter(pathApplicazione + @"\PagineHtml\" + codiceAgente + ".html", false, System.Text.Encoding.UTF8);
            //        sw.Write(paginaHtmlOutput);
            //        sw.Close();
            //        sw.Dispose();

            //        urlRitorno = codiceAgente + ".html";







            //}
            //else if (nomeTemplate == "utente")
            //{
            //    if (offLine)
            //    {
            //        pathTemplate = pathApplicazione + @"\PagineHtml\template_off_line.html";
            //    }
            //    else
            //    {
            //        pathTemplate = pathApplicazione + @"\PagineHtml\template_" + nomeTemplate + ".html";
            //    }


            //    StreamReader sr = new StreamReader(pathTemplate, System.Text.Encoding.UTF8);
            //    strHtmlTemplate = sr.ReadToEnd();
            //    sr.Close();
            //    sr.Dispose();

            //    string paginaHtmlOutput = strHtmlTemplate;
            //    paginaHtmlOutput = paginaHtmlOutput.Replace("{utente}", codiceAgente + " " + cognomeNomeUtente);
            //    paginaHtmlOutput = paginaHtmlOutput.Replace("{agenzia}", agenzia);
            //    paginaHtmlOutput = paginaHtmlOutput.Replace("{logoDivisione}", global_logo_divisione);
            //    paginaHtmlOutput = paginaHtmlOutput.Replace("{emailMittente}", emailUtente);


            //    if (!offLine)
            //    {

            //        string fileConfig = "";
            //        fileConfig = Path.Combine(pathApplicazione, "UniareaImpostazioni.exe");
            //        Configuration configuration = ConfigurationManager.OpenExeConfiguration(fileConfig);

            //        //string strCodiceFiscale = configuration.AppSettings.Settings["u_" + user + "_cf"] == null ? string.Empty : configuration.AppSettings.Settings["u_" + user + "_cf"].Value.ToString();

            //        string strCodiceFiscale = codiceFiscaleInUniArea;


            //        if (strCodiceFiscale != "")
            //        {
            //            #region replace valori campi testo

            //            string datiUtente = _ws.getDatiUtenti(token, strCodiceFiscale);

            //            StringReader sr2 = new StringReader(datiUtente);

            //            /*Interpreto la struttura xml in input*/

            //            DataSet ds = new DataSet("ds");

            //            ds.ReadXml(sr2);

            //            sr2.Close();
            //            sr2.Dispose();

            //            if (ds.Tables["utente"] != null) //#1
            //            {


            //                foreach (DataRow r in ds.Tables["utente"].Rows)
            //                {
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{nome}", r["nome"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{cognome}", r["cognome"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{codiceFiscale}", r["codiceFiscale"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{luogoNascita}", r["luogoNascita"].ToString());

            //                    if (r["dataNascita"].ToString().Trim() != "")
            //                        paginaHtmlOutput = paginaHtmlOutput.Replace("{dataNascita}", DateTime.Parse(r["dataNascita"].ToString()).ToShortDateString());
            //                    else
            //                        paginaHtmlOutput = paginaHtmlOutput.Replace("{dataNascita}", "");

            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{sesso}", r["sesso"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{numRui}", r["numRui"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{ruolo}", "");
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{dataRui}", "");
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{gruppoAgenti}", "");
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{indirizzo}", r["indirizzoSedeLegale"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{cap}", r["capSedeLegale"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{citta}", r["localitaSedeLegale"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{provincia}", r["provinciaSedeLegale"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{regione}", r["regione"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{telefono_1}", r["telefono"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{telefono_2}", r["telefono_2"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{fax}", r["fax"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{email}", r["email"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{email_2}", r["email_2"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{pec}", "");


            //                }
            //            }



            //            #endregion
            //        }
            //        else
            //        {
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{nome}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{cognome}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{codiceFiscale}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{luogoNascita}", "");

            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{dataNascita}", "");

            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{sesso}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{numRui}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{ruolo}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{dataRui}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{gruppoAgenti}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{indirizzo}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{cap}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{citta}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{provincia}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{regione}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{telefono_1}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{telefono_2}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{fax}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{email}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{email_2}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{pec}", "");
            //        }

            //    }





            //    StreamWriter sw = new StreamWriter(pathApplicazione + @"\PagineHtml\" + codiceAgente + ".html", false, System.Text.Encoding.UTF8);
            //    sw.Write(paginaHtmlOutput);
            //    sw.Close();
            //    sw.Dispose();

            //    urlRitorno = codiceAgente + ".html";
            //}
            //else if (nomeTemplate == "agenzia")
            //{
            //    if (offLine)
            //    {
            //        pathTemplate = pathApplicazione + @"\PagineHtml\template_off_line.html";
            //    }
            //    else
            //    {
            //        pathTemplate = pathApplicazione + @"\PagineHtml\template_" + nomeTemplate + ".html";
            //    }


            //    StreamReader sr = new StreamReader(pathTemplate, System.Text.Encoding.UTF8);
            //    strHtmlTemplate = sr.ReadToEnd();
            //    sr.Close();
            //    sr.Dispose();


            //    string fileConfig = "";
            //    fileConfig = Path.Combine(pathApplicazione, "UniareaImpostazioni.exe");
            //    Configuration configuration = ConfigurationManager.OpenExeConfiguration(fileConfig);

            //    //string strCodiceAgenzia = configuration.AppSettings.Settings["g_agenzia"] == null ? string.Empty : configuration.AppSettings.Settings["g_agenzia"].Value.ToString();
            //    //string strCodiceCompagnia = configuration.AppSettings.Settings["g_compagnia"] == null ? string.Empty : configuration.AppSettings.Settings["g_compagnia"].Value.ToString();


            //    string paginaHtmlOutput = strHtmlTemplate;
            //    paginaHtmlOutput = paginaHtmlOutput.Replace("{utente}", codiceAgente + " " + cognomeNomeUtente);
            //    paginaHtmlOutput = paginaHtmlOutput.Replace("{agenzia}", agenzia);
            //    paginaHtmlOutput = paginaHtmlOutput.Replace("{logoDivisione}", global_logo_divisione);
            //    paginaHtmlOutput = paginaHtmlOutput.Replace("{emailMittente}", emailUtente);
            //    paginaHtmlOutput = paginaHtmlOutput.Replace("{codiceCompagnia}", compagnia);



            //    if (!offLine)
            //    {

            //        #region replace valori campi testo

            //        string datiAgenzia = _ws.getDatiAgenzia(token, agenzia, compagnia);

            //        StringReader sr2 = new StringReader(datiAgenzia);

            //        /*Interpreto la struttura xml in input*/

            //        DataSet ds = new DataSet("ds");

            //        ds.ReadXml(sr2);

            //        sr2.Close();
            //        sr2.Dispose();


            //        if (agenzia != "")
            //        {
            //            if (ds.Tables["agenzia"] != null) //#1
            //            {


            //                foreach (DataRow r in ds.Tables["agenzia"].Rows)
            //                {
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{codiceAgenzia}", agenzia);
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{descrizione_agenzia}", r["descrizione"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{divisione}", r["nomeCompagnia"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{ragioneSociale}", r["ragioneSocialeEG"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{codiceFiscaleAziendale}", r["codiceFiscaleEG"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{piva}", r["partitaIvaEG"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{indirizzo}", r["indirizzoSedeLegale"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{cap}", r["capSedeLegale"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{citta}", r["localitaSedeLegale"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{provincia}", r["provinciaSedeLegale"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{regione}", r["regione"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{telefono}", r["telefono"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{telefono_2}", r["telefono_2"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{fax}", r["fax"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{email}", r["email"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{email_2}", r["email_2"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{pec}", r["pec"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{indirizzo_sedeLegale}", r["indirizzoSpedizioneMerce"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{cap_sedeLegale}", r["capSpedizioneMerce"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{citta_sedeLegale}", r["localitaSpedizioneMerce"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{provincia_sedeLegale}", r["provinciaSpedizioneMerce"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{regione_sedeLegale}", r["regioneSpedizioneMerce"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{telefono_sedeLegale}", r["telefonoSpedizioneMerce"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{telefono_2_sedeLegale}", r["telefono2SpedizioneMerce"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{fax_sedeLegale}", r["faxSpedizioneMerce"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{email_sedeLegale}", r["emailSpedizioneMerce"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{email_2_sedeLegale}", r["email2SpedizioneMerce"].ToString());
            //                    paginaHtmlOutput = paginaHtmlOutput.Replace("{pec_sedeLegale}", r["pecSpedizioneMerce"].ToString());


            //                }
            //            }
            //            else
            //            {
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{codiceAgenzia}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{agenzia}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{divisione}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{ragioneSociale}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{codiceFiscaleAziendale}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{piva}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{indirizzo}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{cap}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{citta}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{provincia}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{regione}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{telefono}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{telefono_2}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{fax}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{email}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{email_2}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{pec}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{indirizzo_sedeLegale}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{cap_sedeLegale}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{citta_sedeLegale}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{provincia_sedeLegale}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{regione_sedeLegale}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{telefono_sedeLegale}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{telefono_2_sedeLegale}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{fax_sedeLegale}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{email_sedeLegale}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{email_2_sedeLegale}", "");
            //                paginaHtmlOutput = paginaHtmlOutput.Replace("{pec_sedeLegale}", "");
            //            }

            //        }
            //        else
            //        {
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{codiceAgenzia}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{agenzia}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{divisione}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{ragioneSociale}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{codiceFiscaleAziendale}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{piva}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{indirizzo}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{cap}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{citta}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{provincia}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{regione}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{telefono}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{telefono_2}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{fax}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{email}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{email_2}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{pec}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{indirizzo_sedeLegale}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{cap_sedeLegale}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{citta_sedeLegale}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{provincia_sedeLegale}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{regione_sedeLegale}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{telefono_sedeLegale}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{telefono_2_sedeLegale}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{fax_sedeLegale}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{email_sedeLegale}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{email_2_sedeLegale}", "");
            //            paginaHtmlOutput = paginaHtmlOutput.Replace("{pec_sedeLegale}", "");
            //        }


            //        #endregion

            //    }

            //    StreamWriter sw = new StreamWriter(pathApplicazione + @"\PagineHtml\" + codiceAgente + ".html", false, System.Text.Encoding.UTF8);
            //    sw.Write(paginaHtmlOutput);
            //    sw.Close();
            //    sw.Dispose();

            //    urlRitorno = codiceAgente + ".html";
            //}
            //else if (nomeTemplate == "notizie")
            //{
            //    if (offLine)
            //    {
            //        pathTemplate = pathApplicazione + @"\PagineHtml\template_off_line.html";
            //    }
            //    else
            //    {
            //        pathTemplate = pathApplicazione + @"\PagineHtml\template_" + nomeTemplate + ".html";
            //    }


            //    StreamReader sr = new StreamReader(pathTemplate, System.Text.Encoding.UTF8);
            //    strHtmlTemplate = sr.ReadToEnd();
            //    sr.Close();
            //    sr.Dispose();

            //    string paginaHtmlOutput = strHtmlTemplate;
            //    paginaHtmlOutput = paginaHtmlOutput.Replace("{utente}", codiceAgente + " " + cognomeNomeUtente);
            //    paginaHtmlOutput = paginaHtmlOutput.Replace("{agenzia}", agenzia);
            //    paginaHtmlOutput = paginaHtmlOutput.Replace("{logoDivisione}", global_logo_divisione);


            //    if (!offLine)
            //    {
            //        char[] c = { '|' };
            //        string[] arr_notizie = null;
            //        string strNotizie = _ws.getNotizie(token);
            //        string strHtmlRigheNotizie = "";
            //        i = 0;

            //        if (strNotizie.Trim() != "")
            //        {
            //            if (strNotizie.LastIndexOf("|") > -1)
            //                arr_notizie = strNotizie.Split(c);
            //            else
            //            {
            //                arr_notizie = new string[1];
            //                arr_notizie[0] = strNotizie;

            //            }


            //            for (int j = 0; j < arr_notizie.Length; j++)
            //            {
            //                i++;

            //                if (i == 1)
            //                {
            //                    strHtmlRigheNotizie += "<div class='row'>";
            //                }


            //                strHtmlRigheNotizie += arr_notizie[j].ToString();

            //                if (i == 2)
            //                {
            //                    i = 0;
            //                    strHtmlRigheNotizie += "</div>";
            //                }
            //            }

            //        }

            //        paginaHtmlOutput = paginaHtmlOutput.Replace("{notizie}", strHtmlRigheNotizie);

            //    }

            //    StreamWriter sw = new StreamWriter(pathApplicazione + @"\PagineHtml\" + codiceAgente + ".html", false, System.Text.Encoding.UTF8);
            //    sw.Write(paginaHtmlOutput);
            //    sw.Close();
            //    sw.Dispose();

            //    urlRitorno = codiceAgente + ".html";
            //}
            //else if (nomeTemplate == "contatti")
            //{
            //    if (offLine)
            //    {
            //        pathTemplate = pathApplicazione + @"\PagineHtml\template_off_line.html";
            //    }
            //    else
            //    {
            //        pathTemplate = pathApplicazione + @"\PagineHtml\template_" + nomeTemplate + ".html";
            //    }


            //    StreamReader sr = new StreamReader(pathTemplate, System.Text.Encoding.UTF8);
            //    strHtmlTemplate = sr.ReadToEnd();
            //    sr.Close();
            //    sr.Dispose();

            //    string paginaHtmlOutput = strHtmlTemplate;
            //    paginaHtmlOutput = paginaHtmlOutput.Replace("{utente}", codiceAgente + " " + cognomeNomeUtente);
            //    paginaHtmlOutput = paginaHtmlOutput.Replace("{agenzia}", agenzia);
            //    paginaHtmlOutput = paginaHtmlOutput.Replace("{logoDivisione}", global_logo_divisione);
            //    paginaHtmlOutput = paginaHtmlOutput.Replace("{emailMittente}", emailUtente);


            //    StreamWriter sw = new StreamWriter(pathApplicazione + @"\PagineHtml\" + codiceAgente + ".html", false, System.Text.Encoding.UTF8);
            //    sw.Write(paginaHtmlOutput);
            //    sw.Close();
            //    sw.Dispose();

            //    urlRitorno = codiceAgente + ".html";
            //}
            //else
            //{
            //}

            return urlRitorno;
        }

        #endregion

        private void webView1_LoadCompleted(object sender, EO.WebBrowser.LoadCompletedEventArgs e)
        {

           
            this.Opacity = 100;
          
        }


        private void registraUtente(string email, string telefono)
        {
            OmniaManagerDll.it.uniarea.ws.accessoCasa ws = new OmniaManagerDll.it.uniarea.ws.accessoCasa();

           string esito = ws.registraUtente(this.getToken(), ut_codiceFiscale, "", cognomeNomeUtente, email, telefono, ut_ruolo, agenzia);

            if(esito=="0")
                MessageBox.Show("Errore in registraUtente");
            else
                MessageBox.Show("Registrazione effettuata");

        }


        private string getToken()
        {

            string valoreRitorno = "";
            string g = DateTime.Today.Day.ToString();
            string m = DateTime.Today.Month.ToString();
            string a = DateTime.Today.Year.ToString();

            if (g.Length == 1)
                g = "0" + g;

            if (m.Length == 1)
                m = "0" + m;




            string s = "UT" + g + m + a;

            System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create();

            return classMD5.GetMd5Hash(md5Hash, s).ToUpper();

        }

        private void Invia_Ticket()
        {

            OmniaManagerDll.it.uniarea.ws.accessoCasa ws = new OmniaManagerDll.it.uniarea.ws.accessoCasa();

            string esito = ws.getDatiUtenteByCodiceFiscale(this.getToken(), ut_codiceFiscale);
            string strEmail = "", strTelefono = "", strLogin = "", strPasswd = "";

            string[] arr = null;

            if (esito.LastIndexOf("|") > -1)
            {
                arr = esito.Split('|');
            }

            if(arr!=null && arr.Length > 3)
            {
                strEmail = arr[0];
                strTelefono = arr[1];
                strLogin = arr[2];
                strPasswd = arr[3];

            }


            if(strEmail.Trim()=="" || strTelefono.Trim() == "")
            {
                MessageBox.Show("Attenzione!!\r\nPer Continuare Confermare i dati nella pagina di registrazione", "Alert!!");

               // webView1.LoadUrl(pathApplicazione + @"\PagineHtml\" + this.preparaPagina("registrazione"));
               return;
            }
            else
            {
                if(strLogin.Trim() == "" || strPasswd.Trim() == "")
                {
                    ws.setDatiAccesso(this.getToken(), agenzia, ut_codiceFiscale, emailUtente, "", cognomeNomeUtente);
                }
            }


            esito = ws.getDatiUtenteByCodiceFiscale(this.getToken(), ut_codiceFiscale);

            if (esito.LastIndexOf("|") > -1)
            {
                arr = esito.Split('|');
            }

            if (arr != null && arr.Length > 3)
            {
                strEmail = arr[0];
                strTelefono = arr[1];
                strLogin = arr[2];
                strPasswd = arr[3];

            }

            string url = "http://otrs.uniarea.it/otrs/customer.pl?action=login&user=" + strEmail + "&password=" + strPasswd;

            System.Diagnostics.Process.Start(url);


        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(841, 564);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

      


     



    }




       

}
