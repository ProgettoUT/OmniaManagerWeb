using System;
using System.Collections.Generic;
using System.Text;

namespace OmniaManagerDll
{
    public class Settings
    {
        string m_AgenziaMadre = "";
        string m_CodiceSede = "";
        string m_UniageUser = "";
        string m_UniagePw = "";
        string m_CodiceFiscale = "";
        string m_Nome = "";
        bool m_IsAgente = false;
        string m_Ruolo = "";
        string m_DescrzioneRuolo = "";
        
        public string AgenziaMadre
        {
            set { m_AgenziaMadre = value; }
            get { return m_AgenziaMadre; }
        }

        public string CodiceSede
        {
            set { m_CodiceSede = value; }
            get { return m_CodiceSede; }
        }

        public string UniageUser
        {
            set { m_UniageUser = value; }
            get { return m_UniageUser; }
        }

        public string UniagePw
        {
            set { m_UniagePw = value; }
            get { return m_UniagePw; }
        }

        public string CodiceFiscale
        {
            set { m_CodiceFiscale = value; }
            get { return m_CodiceFiscale; }
        }

        public string Nome
        {
            set { m_Nome = value; }
            get { return m_Nome; }
        }

        public bool IsAgente
        {
            set { m_IsAgente = value; }
            get { return m_IsAgente; }
        }

        public string Ruolo
        {
            set { m_Ruolo = value; }
            get { return m_Ruolo; }
        }

        public string DescrzioneRuolo
        {
            set { m_DescrzioneRuolo = value; }
            get { return m_DescrzioneRuolo; }
        }

       
    }
}
