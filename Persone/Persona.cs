using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persone
{
    class Persona
    {
        public string Nome { get; }
        public string Cognome { get; }
        public DateTime DataDiNascita { get; }
        public string CodiceFiscale { get; }

        public Persona(string nome, string cognome, DateTime dataDiNascita, string codiceFiscale)
        {
            Nome = nome;
            Cognome = cognome;
            DataDiNascita = dataDiNascita;
            CodiceFiscale = codiceFiscale;
        }

        public int Eta { get 
            {
                //TimeSpan diff = DateTime.Today.Subtract(DataDiNascita);
                //return (int)(diff.Days / 365.25);

                // datadinascita 6/5/2000   20000505
                // 05/05/2021               20210505

                int anni = DateTime.Today.Year - DataDiNascita.Year;

                //if (DataDiNascita.Month < DateTime.Today.Month ||
                //    (DataDiNascita.Month == DateTime.Today.Month &&
                //    DataDiNascita.Day <= DateTime.Today.Day))
                //    return anni;
                //return anni - 1;

                //return ((DateTime.Today.Year * 10000 + 
                //    DateTime.Today.Month * 100 + 
                //    DateTime.Today.Day) -
                //    (DataDiNascita.Year * 10000 + 
                //    DataDiNascita.Month * 100 + 
                //    DataDiNascita.Day)) / 10000;

                DateTime dataCompleanno = new DateTime(DateTime.Today.Year,
                    DataDiNascita.Month, 1).AddDays(DataDiNascita.Day - 1);

                if (DateTime.Today < dataCompleanno)
                    return anni - 1;
                return anni;
            } 
        }

        public string DatiTSV  // CSV Comma Separated Values, TSV Tab Separated Values
        {
            get
            { return Nome + '\t' + Cognome + '\t' + DataDiNascita.ToShortDateString() + '\t' + CodiceFiscale; }
        }

        public string Dati
        {
            get
            { return Nome + ' ' + Cognome + ' ' + DataDiNascita.ToShortDateString() + ' ' + CodiceFiscale + ' ' + Eta; }
        }
    }
}
