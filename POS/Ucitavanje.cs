using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace POS
{
    class Ucitavanje
    {
        public List<Artikl> artikli = new List<Artikl>();

        public void ucitajartikle()
        {
            string[] lines = System.IO.File.ReadAllLines("artikli.txt");
            int i = 0;
            foreach (string line in lines)
            {
                Artikl novi = new Artikl();
                string[] sve = line.Split(' ');

                novi.sifra = Int32.Parse(sve[0]);
                novi.naziv = sve[1];
                novi.cijena = float.Parse(sve[2], CultureInfo.InvariantCulture.NumberFormat);
                novi.normativ = sve[3];
                novi.stopaPDV = float.Parse(sve[4], CultureInfo.InvariantCulture.NumberFormat);

                artikli.Add(novi);

                i++;
            }
        }

        public List<Racun> racuni = new List<Racun>();

        public void ucitajracune()
        {
            string[] lines = System.IO.File.ReadAllLines("racuni.txt");
            
            foreach (string line in lines)
            {
                if (line == "") return;
                string line2 = line.Replace(',', '.');
                Racun novi = new Racun();
                string[] sve = line2.Split(' ');

                novi.brojRacuna = Int32.Parse(sve[0]);
                novi.datumvrijeme = DateTime.Parse(sve[1]+" "+sve[2]);
                novi.brojstavki = Int32.Parse(sve[3]);

                for (int i=1; i<novi.brojstavki+1; i++)
                {
                    Stavka stavka = new Stavka();
                    int broj = (i - 1) * 8 + 4;
                    stavka.broj = Int32.Parse(sve[broj]);
                    stavka.sifra = Int32.Parse(sve[broj + 1]);
                    stavka.naziv = sve[6 + 8 * (i - 1)];
                    stavka.kolicina = float.Parse(sve[7 + 8 * (i - 1)], CultureInfo.InvariantCulture.NumberFormat);
                    stavka.cijena = float.Parse(sve[8 + 8 * (i - 1)], CultureInfo.InvariantCulture.NumberFormat);
                    stavka.iznos = float.Parse(sve[9 + 8 * (i - 1)], CultureInfo.InvariantCulture.NumberFormat);
                    stavka.pdv = float.Parse(sve[10 + 8 * (i - 1)], CultureInfo.InvariantCulture.NumberFormat);
                    stavka.pdvizracun= float.Parse(sve[11 + 8 * (i - 1)], CultureInfo.InvariantCulture.NumberFormat);
                    novi.stavke.Add(stavka);
                }

                novi.ukupno = float.Parse(sve[novi.brojstavki*8+4], CultureInfo.InvariantCulture.NumberFormat);
                novi.PDV = float.Parse(sve[novi.brojstavki*8+5], CultureInfo.InvariantCulture.NumberFormat);

                racuni.Add(novi);
            }
        }
    }
}
