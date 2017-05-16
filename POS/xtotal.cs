using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    class xtotal
    {
        public void xtotalc()
        {
            Ucitavanje u = new POS.Ucitavanje();
            u.ucitajracune();

            int brojracuna = 0;
            int i = 1;
            float ukupaniznos = 0;
            float ukupanPDV = 0;

            Console.Clear();
            Console.WriteLine("\n\tPOS.d.o.o\n");
            Console.WriteLine("\t\t\tX IZVJEŠĆE\n");
            Console.WriteLine("\tDatum: {0}", DateTime.Now.ToString("dd.MM.yyyy"));
            Console.WriteLine("\tBlagajnik: Ingrid M.\n");

            foreach(Racun r in u.racuni)
            {
                if(r.datumvrijeme.Date == DateTime.Now.Date)
                {
                    brojracuna++;
                    ukupaniznos += r.ukupno;
                    ukupanPDV += r.PDV;
                }
            }

            Console.WriteLine("\tBroj računa: {0}", brojracuna);
            Console.WriteLine("\t_______________________________________________\n");
            Console.WriteLine("\t{0,35}{1,8}kn", "Iznos ukupnog utrška:", ukupaniznos.ToString("0.00"));
            Console.WriteLine("\t{0,35}{1,8}kn\n", "Ukupan PDV:", ukupanPDV.ToString("0.00"));
            Console.WriteLine("\t_______________________________________________\n");

            Console.WriteLine("\t{0,2}{1,12}{2,10}{3,14}{4,8}", "#", "Broj računa", "Vrijeme", "Broj artikala", "Iznos");
        
            foreach (Racun r in u.racuni)
            {
                if (r.datumvrijeme.Date == DateTime.Now.Date)
                {
                    Console.WriteLine("\t{0,2}{1,12}{2,10}{3,14}{4,8}", i++, r.brojRacuna, r.datumvrijeme.ToString("HH:mm"), r.brojstavki, r.ukupno.ToString("0.00"));
                }
            }
            Console.WriteLine("\t_______________________________________________\n");
            Console.Read();
        }
    }
}
