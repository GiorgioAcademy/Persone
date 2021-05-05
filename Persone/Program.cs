using System;
using System.Collections.Generic;
using System.IO;

namespace Persone
{
    class Program
    {
        const string fileName = @"persone.txt";

        static void Salva(Dictionary<string, Persona> elenco)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (Persona p in elenco.Values)
                    sw.WriteLine(p.DatiTSV);
            }
        }

        static Dictionary<string, Persona> Carica()
        {
            Dictionary<string, Persona> elenco = new Dictionary<string, Persona>();

            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    string riga = sr.ReadLine();
                    string[] pezzi = riga.Split('\t');    // spezza la stringa in corrispondenza di tab
                    Persona p = new Persona(pezzi[0], pezzi[1], DateTime.Parse(pezzi[2]), pezzi[3]);
                    elenco.Add(p.CodiceFiscale, p);
                }
            }

            return elenco;
        }

        static void Main(string[] args)
        {
            // Dictionary<string, Persona> elenco = new Dictionary<string, Persona>();

            Dictionary<string, Persona> elenco = Carica();

            foreach (Persona p in elenco.Values)
                Console.WriteLine(p.Dati);

            //Persona p1 = new Persona("Pinco", "Pallino", new DateTime(1995, 4, 3), "ABCDEF");
            //Persona p2 = new Persona("Gino", "Pino", new DateTime(1995, 4, 3), "GPGPGP");
            //Persona p3 = new Persona("Luisa Maria", "Pia", new DateTime(1995, 4, 3), "MARPIA");
            //elenco.Add(p1.CodiceFiscale, p1);
            //elenco.Add(p2.CodiceFiscale, p2);
            //elenco.Add(p3.CodiceFiscale, p3);

            //List<Persona> lista = new List<Persona>();


            //Salva(elenco);

            //lista.Add(p1);
            //lista.Add(p2);
            //lista.Add(p3);

            Console.Write("Ricerca per codice fiscale: ");
            string cf = Console.ReadLine();

            if (elenco.ContainsKey(cf))
                Console.WriteLine(elenco[cf].Dati);
            else
                Console.WriteLine("Codice fiscale inesistente");

            //bool presente = false;
            //foreach (Persona p in lista)
            //    if (p.CodiceFiscale == cf)
            //    {
            //        Console.WriteLine(p.Dati);
            //        presente = true;
            //        break;
            //    }

            //if (!presente)
            //    Console.WriteLine("Codice fiscale inesistente");
        }
    }
}
