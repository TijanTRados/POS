using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    class Racun
    {
        public int brojRacuna { get; set; }
        public DateTime datumvrijeme { get; set; }
        public int brojstavki { get; set; }

        public List<Stavka> stavke = new List<Stavka>();
        public float ukupno { get; set; }
        public float PDV { get; set; }

        public void izbrisistavku(int i)
        {
            this.stavke = this.stavke.Where(stavka => stavka.broj != i).ToList();
            int x = 1;

            foreach (Stavka s in this.stavke)
            {
                s.broj = x++;
            }
        }

        public void storniraj()
        {
            Ucitavanje u = new Ucitavanje();
            u.ucitajracune();

            Console.WriteLine("\t{0,12}{1,12}{2,10}{3,14}{4,8}", "broj računa", "datum", "Vrijeme", "Broj artikala", "Iznos");

            foreach (Racun r in u.racuni)
            {
                    Console.WriteLine("\t{0,12}{1,12}{2,10}{3,14}{4,8}", r.brojRacuna, r.datumvrijeme.ToString("dd.MM.yyyy"), r.datumvrijeme.ToString("HH:mm"), r.brojstavki, r.ukupno.ToString("0.00"));
            }
            Console.WriteLine("\t_________________________________________________________\n");

            Console.Write("\tUnesi broj računa koji želiš stornirati: ");
            string storno = Console.ReadLine();
            if (storno == "") return;

            bool ima = false;
            foreach (Racun r in u.racuni)
            {
                if (r.brojRacuna == Int32.Parse(storno)) ima = true;
            }

            List<Racun> racuni = new List<Racun>();

            racuni = u.racuni.Where(racun => racun.brojRacuna != Int32.Parse(storno)).ToList();
            List<string> novizapisi = new List<string>();

            foreach (Racun racun in racuni)
            {
                string upis = racun.brojRacuna.ToString() + " " + racun.datumvrijeme.ToString("dd.MM.yyy HH:mm") + " " + racun.brojstavki.ToString() + " ";

                foreach (Stavka q in racun.stavke)
                {
                    upis = upis + q.broj.ToString() + " " + q.sifra.ToString() + " " + q.naziv + " " + q.kolicina.ToString() + " " + q.cijena.ToString(" ") + " " + q.cijena.ToString() + " " + q.iznos.ToString() + " " + q.pdv.ToString() + " " + q.pdvizracun.ToString() + " ";
                }

                upis = upis + racun.ukupno.ToString() + " " + racun.PDV;
                upis = upis.Replace("  ", " ");
                upis = upis.Replace("  ", " ");
                upis = upis.Replace("  ", " ");
                upis = upis.Replace("  ", " ");
                upis = upis.Replace("  ", " ");
                upis = upis.Replace("  ", " ");

                novizapisi.Add(upis);

                
            }

            System.IO.File.WriteAllLines("racuni.txt", novizapisi);

            if (ima) Console.WriteLine("\tRačun broj {0} storniran.", storno);
            else Console.WriteLine("\tRačun broj {0} ne postoji.", storno);
            Console.Read();
        }


    }
}
