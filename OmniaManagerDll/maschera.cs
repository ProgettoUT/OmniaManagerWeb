using System;
using SplashUniarea;



namespace OmniaManagerDll
{
    public class Maschera
    {

        public event EventHandler<EventoUniTools> lancio;
        public event EventHandler<EventoUniTools> chiusura;

        public Form1 _maschera = null;
        public Settings settaggio = null;


        public enum MenuKey
            {
        //'portafoglio
        ANAG,
        ESTRAI,
        QUOTA,
        EVIDENZE,
        //'sinistri
        SCHEDASINISTRI,
        STATISTICHE,
        CONSAP,
        CAI,
        BAREMES,
        REFERENTI,
        //'postalizzazione
        ATTIVAPOST,
        CONFIGPOST,
        AVVISIPOST,
        TRACCIAPOST,
        //'quietanzamento
        MONITORQT,
        LISTEQT,
        BDA,
        //'adempimenti
        ADEMPIMENTI,
        BUSTE,
       // 'gestione
        BUDGET,
        NP,
        INCASSI,
        ARRETRATI,
        UNICONT,
        SISTEMA,
        CASSA,
        //'patto unipol
        VADEMECUM,
        PATTORCA,
        LIBERI,
        RAPPEL,
        //'contatti
        MAIL,
        COMUNICA,
        ACCOUNT,
        NOTIFICHE,
        LETTERE,
        //'utilità
        ASSEGNI,
        DOC_PERSONALI,
        DOC_AGENZIA,
        VISURE,
        SCANNER,
        CENTRALINO,
        INFOUT,
        LINK,
       // 'manutenzione
        ASSISTENZA,
        STRUMENTI,
        VEDILOG
    }

        public Maschera()
        {
            settaggio = new Settings();
        }

        public void Start()
        {
            //string _codiceUtente, string _ruolo, string _codiceFiscale, bool _isAgente
            _maschera = new Form1(settaggio.UniageUser, settaggio.Nome, settaggio.Ruolo, settaggio.CodiceFiscale, settaggio.IsAgente);
            _maschera.lanciointerno += _maschera_lanciointerno;
            _maschera.chiusurainterno += _maschera_chiusurainterno;

            //          // _maschera.Owner = this; // we want the new form to float on top of this one
            _maschera.Show();
            // _maschera.ShowDialog(); sostituita per ridimensinamento

        }

        private void _maschera_lanciointerno(object sender, EventoUniTools e)
        {

            EventoUniTools args = new EventoUniTools();
            args.Parametro = e.Parametro;
            OnEvento(args);
           
        }

        protected virtual void OnEvento(EventoUniTools e)
        {
            EventHandler<EventoUniTools> handler = lancio;

            if (handler != null)
            {
                handler(this, e);
            }
        }
        private void _maschera_chiusurainterno(object sender, EventoUniTools e)
        {

            EventoUniTools args = new EventoUniTools();
            args.Parametro = "richiesta_chiusura";
            OnEventoChiusura(args);

        }

        protected virtual void OnEventoChiusura(EventoUniTools e)
        {
            EventHandler<EventoUniTools> handler = chiusura;

            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
  


}
