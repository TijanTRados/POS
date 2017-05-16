using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    class izvjesce
    {
        public float broj = 0;
        
        public float iznos = 0;
        public string naziv { get; set; }

        public void izvjescec()
        {
            float suma = 0;
            int rang = 1;

            Ucitavanje u = new Ucitavanje();
            u.ucitajracune();

            Dictionary<int, izvjesce> rezultati = new Dictionary<int, izvjesce>();

            foreach(Racun r in u.racuni)
            {
                foreach(Stavka s in r.stavke)
                {
                    
                    suma += s.iznos;
                    if (!rezultati.ContainsKey(s.sifra))
                    {
                        izvjesce i = new izvjesce();
                        i.broj+= s.kolicina;
                        i.iznos += s.iznos;
                        i.naziv = s.naziv;
                        rezultati.Add(s.sifra, i);
                    }
                    
                    else
                    {
                        rezultati[s.sifra].broj++;
                        rezultati[s.sifra].iznos += s.iznos;
                    }
                }
            }

            u.ucitajartikle();

            Console.Clear();
            Console.WriteLine("\n\tPOS.d.o.o\n");
            Console.WriteLine("\t\t\tPRODAJA PO ARTIKLU\n");
            Console.WriteLine("\tDatum: {0}", DateTime.Now.ToString("dd.MM.yyyy"));
            Console.WriteLine("\tBlagajnik: Ingrid M.\n");
            Console.WriteLine("\tSortirano po vrijednosti:");
            Console.WriteLine("\t___________________________________________________\n");

            Console.WriteLine("\t{0,4}{1,7}{2,15}{3,15}{4,8}", "Rang", "Sifra", "Naziv", "Broj prodanih", "Iznos");

            int n = rezultati.Count;

            for (int g = 0; g< n; g++)
            {
                float max = 0;
                int maxkey = 0;

                foreach (KeyValuePair<int, izvjesce> i in rezultati)
                {
                    if (i.Value.iznos > max)
                    {
                        max = i.Value.iznos;
                        maxkey = i.Key;
                    }
                }

                if (maxkey == 0)
                {
                    Console.WriteLine("\tJoš uvijek nema zapisa.");
                    Console.Read();
                    return;
                }

                Console.WriteLine("\t{0,3}.{1,7}{2,15}{3,15}{4,8}kn", rang++, maxkey, rezultati[maxkey].naziv, rezultati[maxkey].broj, rezultati[maxkey].iznos.ToString("0.00"));
                rezultati.Remove(maxkey);
            }

            Console.WriteLine("\t___________________________________________________\n");

            Console.WriteLine("\t{0,47}kn", "Ukupan iznos maloprodaje: " + suma.ToString("0.00"));

            Console.Read();
        }
    }
}
