using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    class printer
    {
        public printer(Racun racun)
        {
            Console.Clear();
            Console.WriteLine("\n\tPOS.d.o.o\n");
            Console.WriteLine("\tRačun broj: {0}", racun.brojRacuna);
            Console.WriteLine("\tDatum: {0}\n\tVrijeme: {1}", racun.datumvrijeme.ToString("dd.MM.yyyy"), racun.datumvrijeme.ToString("HH:mm"));
            Console.WriteLine("\tBlagajnik: Ingrid M.\n");
            Console.WriteLine("\tBroj stavki: {0}", racun.brojstavki);
            Console.WriteLine("\t_______________________________________________\n");
            Console.WriteLine("\t{0,3}{1,7}{2,15}{3,10}{4,10}", "#", "Šifra", "Naziv", "Količina", "Iznos");
            foreach (Stavka s in racun.stavke)
            {
                Console.WriteLine("\t{0,3}{1,7}{2,15}{3,10}{4,8}kn", s.broj, s.sifra, s.naziv, s.kolicina, s.iznos.ToString("0.00"));
            }
            Console.WriteLine("\t_______________________________________________\n");
            Console.WriteLine("\t{0,35}{1,8}kn", "Ukupno:", racun.ukupno.ToString("0.00"));
            Console.WriteLine("\t{0,35}{1,8}kn\n\n", "PDV:", racun.PDV.ToString("0.00"));
            Console.WriteLine("\t\tHvala i dođite nam opet!");
            Console.Read();
        }
    }
}
