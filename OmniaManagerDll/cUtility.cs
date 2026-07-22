using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.OleDb;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Globalization;

namespace SplashUniarea
{
    class cUtility
    {
        //public OleDbConnection connetti()
        //{
        //    OleDbConnection conn;

        //    string pathDb = this.getPathApplicazione();

        //    if (this.isAmbienteSviluppo())
        //        pathDb += @"\..\..";



        //    string strConnDb = ConfigurationSettings.AppSettings["strConnDB"].ToString().Replace("{pathDb}", @"C:\Users\umberto-win7\Documents\Visual Studio 2010\Projects\WindowsFormsApplication1\WindowsFormsApplication1\Bin\Debug\..\..");

        //    conn = new OleDbConnection(strConnDb);
        //    conn.Open();

        //    return conn;

        //}


        //public void disconnetti(OleDbConnection conn)
        //{
        //    if (conn != null && conn.State == ConnectionState.Open)
        //        conn.Close();
        //}


        public string getPathApplicazione()
        {
            string path = "";
           
            path = Application.StartupPath;
            return path;
        }

        public Form IsFormAlreadyOpen(Type FormType)
        {
            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.GetType() == FormType)
                    return OpenForm;
            }

            return null;
        }


        public string[] splitIndirizziMail(string str_email)
        {
            char[] c = { ';' };
            string[] arr;

            if (str_email.Trim() == "")
                arr = new string[0];
            else
                arr = str_email.Split(c);


            return arr;


        }


        public bool checkMail(string str)
        {
            string[] arr = null;

            if (str.Trim() == "")
                return true;

            if (str.IndexOf(";") > -1)
            {
                arr = this.splitIndirizziMail(str);
            }
            else
            {
                arr = new string[1];
                arr[0] = str;
            }


            //Regex emailregexp = new Regex("(?<user>[^@]+)@(?<host>.+)");

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Match controllo = emailregexp.Match(arr[i].ToString().Trim());
            //    if (!controllo.Success)
            //        return false;

            //}


            for (int i = 0; i < arr.Length; i++)
            {

                if (!this.IsValidEmail(arr[i].ToString()))
                    return false;

            }


            return true;


        }

        private string DomainMapper(Match match)
        {
            bool invalid = false;   // usato nella validazione email

            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }

        private bool IsValidEmail(string strIn)
        {
            bool invalid = false; // usato nella validazione email
            invalid = false;

            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {

                strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper);
            }
            catch (Exception ex)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                      RegexOptions.IgnoreCase);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void InviaEmail(string mittente, string destinatario, string oggetto, string corpo, bool formatoHtml, string pathAllegato)
        {


            string strUsaSmtpEsterno = "1";
            string strSmtp = "smtp.aday.it";
            string strLoginSmtp = "support@aday.it";
            string strPasswordSmtp = "Support.01";
            string strPorta = "25";


            try
            {

                if (destinatario.Trim() !="")
                {
                    MailMessage objMail = new MailMessage();
                    objMail.From = new MailAddress(mittente);
                    objMail.To.Add(destinatario);
                    objMail.IsBodyHtml = formatoHtml;
                    objMail.Subject = oggetto;
                    objMail.Body = corpo;

                    if (pathAllegato.Trim() != "")
                    {

                        objMail.Attachments.Add(new System.Net.Mail.Attachment(pathAllegato));

                    }



                    if (strUsaSmtpEsterno == "1")
                    {
                        //Invio mail tramite smtp esterno
                        SmtpClient smtp = new SmtpClient(strSmtp);
                        smtp.Port = int.Parse(strPorta);
                        smtp.Credentials = new System.Net.NetworkCredential(strLoginSmtp, strPasswordSmtp);

                        smtp.Send(objMail);

                    }
                    else
                    {
                        //invio mail tramite smtp interno
                        SmtpClient smtp = new SmtpClient("localhost");
                        smtp.Send(objMail);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore in InviaEmail(): " + ex.Message + "\r" + ex.StackTrace);
            }

        }

        
    }
}
