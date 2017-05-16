using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace POS
{
    class Stavka
    {
        public int broj { get; set; }
        public int sifra { get; set; }
        public string naziv { get; set; }
        public float kolicina { get; set; }
        public float cijena { get; set; }
        public float iznos { get; set; }
        public float pdv { get; set; }
        public float pdvizracun { get; set; }

        public void stavka(string korisnik, int broj)
        {

            Ucitavanje u = new Ucitavanje();
            u.ucitajartikle();
            bool neuspjesno = true;

            while (neuspjesno)
            {
                Console.Clear();
                Console.WriteLine("{0,7}{1,15}{2,11}{3,9}{4,6}", "Šifra", "Naziv", "Cijena", "Normativ", "PDV");
                Console.WriteLine("__________________________________________________\n");
                foreach (Artikl artikal in u.artikli)
                {

                    Console.WriteLine("{0,7}{1,15}{2,9}kn{3,9}{4,5}%", artikal.sifra, artikal.naziv, artikal.cijena, artikal.normativ, artikal.stopaPDV * 100);
                }
                Console.Write("\nUnesi šifru artikla: ");
                this.broj = broj;
                string h = Console.ReadLine();
                if (h == "") continue;
                this.sifra = Int32.Parse(h);

                foreach (Artikl artikal in u.artikli)
                {
                    if (artikal.sifra == this.sifra)
                    {
                        this.naziv = artikal.naziv;
                        this.cijena = artikal.cijena;
                        this.pdv = artikal.stopaPDV;
                        neuspjesno = false;
                        break;
                    }
                }
            }
            
            while (!neuspjesno)
            {
                Console.Write("Unesi količinu: ");
                string g = Console.ReadLine();
                g.Replace(",", ".");
                if (g == "") continue;
                this.kolicina = float.Parse(g, CultureInfo.InvariantCulture.NumberFormat);
                this.iznos = this.cijena * this.kolicina;
                this.pdvizracun = this.iznos * this.pdv;
                neuspjesno = true;
            }
            
        }

    }
}
