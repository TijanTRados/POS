using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace POS
{
    class Artikl
    {
        public int sifra { get; set; }
        public string naziv { get; set; }
        public float cijena { get; set; }
        public string normativ { get; set; }
        public float stopaPDV { get; set; }

        public void dodajartikl(string korisnik)
        {
            Ucitavanje u = new Ucitavanje();
            u.ucitajartikle();
            Artikl novi = new POS.Artikl();
            int sifra = u.artikli[u.artikli.Count - 1].sifra+1;
            string upis = sifra.ToString()+" ";

            Console.Clear();
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("|\t*Bagajna POS*\t\t\t\t\t\t\t|\n|\tDatum: {0}\t\t\t\t\t\t|\n|\tVrijeme: {1}\t\t\t\t\t\t\t|", DateTime.Now.ToString("dd.MM.yyyy"), DateTime.Now.ToString("HH:mm"));
            Console.WriteLine("|\t\t\t\t\t\t\t\t\t|");
            Console.WriteLine("|\tDobrodošao, {0}!\t\t\t\t\t\t|", korisnik);
            Console.WriteLine("|\tpritisni ENTER za povratak\t\t\t\t\t|");
            Console.WriteLine("|\t\t\t\t\t\t\t\t\t|");
            Console.WriteLine("|_______________________________________________________________________|\n");

            Console.WriteLine("\tKreiranje novog artikla: \n");
            Console.Write("\t\tUnesi naziv: ");
            string x = Console.ReadLine();
            if (x == "") return;
            upis = upis + x +" ";

            Console.Write("\t\tUnesi cijenu (do dvije decimale, bez valute): ");
            x = Console.ReadLine();
            if (x == "") return;
            x = x.Replace(",", ".");
            x = x.Replace("kn", "");
            x = x.Replace("Kn", "");
            x = x.Replace("KN", "");
            try
            {
                float.Parse(x);
            }
            catch
            {
                Console.WriteLine("\tFormat nije valjan.");
                Thread.Sleep(1500);
                return;
            }
            upis = upis + x+" ";

            Console.Write("\t\tUnesi normativ (biraj: kg/kom): ");
            x = Console.ReadLine();
            if (x == "") return;
            upis = upis + x+" ";

            Console.Write("\t\tUnesi stopu PDV-a (kao decimalni broj, npr. 0.25): ");
            x = Console.ReadLine();
            if (x == "") return;
            x = x.Replace(",", ".");
            try
            {
                float.Parse(x);
            }
            catch
            {
                Console.WriteLine("\tFormat nije valjan.");
                Thread.Sleep(1500);
                return;
            }
            upis = upis + x;


            Console.Clear();

            Console.WriteLine("Oprez: ");
            Console.WriteLine("{0,7}{1,15}{2,11}{3,9}{4,6}", "Šifra", "Naziv", "Cijena", "Normativ", "PDV");
            Console.WriteLine("{0,7}{1,15}{2,11}{3,9}{4,6} - Dopušten format", "xxxxx", "Max15znakova", "0.00","kom/kg", "0.25");
            string[] xx = upis.Split(' ');
            Console.WriteLine("{0,7}{1,15}{2,11}{3,9}{4,6} - Vaš unos", xx[0], xx[1], xx[2], xx[3], xx[4]);

            Console.WriteLine("\nU bazu podataka namjeravate unijeti ovakav zapis - jeste li sigurni? D/N");

            string s = Console.ReadLine();
            if (s=="D" || s == "d")
            {
                Console.Write("\nPotrebna admin lozinka: ");
                string admin = Console.ReadLine();
                if (admin != "admin")
                {
                    Console.Write("Poništeno.");
                    Thread.Sleep(1000);
                    return;
                }
                using (System.IO.StreamWriter file = new System.IO.StreamWriter("artikli.txt", true))
                {
                    file.WriteLine(upis);
                }
                Console.WriteLine("Uspješno dodano.");
                Thread.Sleep(1000);
                return;
            }
            if (s=="N" || s== "n")
            {
                Console.WriteLine("Poništeno.");
                Thread.Sleep(1000);
                return;
            }
            Console.WriteLine("Poništeno.");
            Thread.Sleep(1000);
            return;
        }

    }

    
}
