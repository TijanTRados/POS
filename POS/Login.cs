using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace POS
{
    class Login
    {
        public string korisnik = string.Empty;

        public void login()
        {
            Console.Clear();
            string[] lines = System.IO.File.ReadAllLines("login.txt");
            bool uspjesno = false;

            
    
            while (!uspjesno)
            {
                Console.Clear();
                Console.WriteLine("*************************************************************************");
                Console.WriteLine("|\t*Bagajna POS*\t\t\t\t\t\t\t|\n|\tDatum: {0}\t\t\t\t\t\t|\n|\tVrijeme: {1}\t\t\t\t\t\t\t|", DateTime.Now.ToString("dd.MM.yyyy"), DateTime.Now.ToString("HH:mm"));
                Console.WriteLine("|\t\t\t\t\t\t\t\t\t|");
                Console.WriteLine("|\t[Korisnici: admin; login: (\"admin\", \"admin\")            ]\t|\n|\t[           blagajnik; login: (\"blagajnik\", \"blagajnik\")]\t|");
                Console.WriteLine("|\t\t\t\t\t\t\t\t\t|");
                Console.WriteLine("|_______________________________________________________________________|\n");

                Console.WriteLine("\t*Unesi x za izlaz iz aplikacije.\n");
                Console.Write("\tUnesi korisničko ime: ");
                korisnik = Console.ReadLine();
                korisnik = korisnik.Replace(" ", "");
                if (korisnik == "x") Environment.Exit(1);
                Console.Write("\tUnesi lozinku: ");
                string lozinka = Console.ReadLine();
                lozinka = lozinka.Replace(" ", "");

                foreach (string line in lines)
                {
                    string[] provjera = line.Split(' ');
                    if (korisnik == provjera[0] && lozinka == provjera[1])
                    {
                        korisnik = provjera[0];
                        Console.WriteLine("\tDobrodošao, {0}! :)\n", korisnik);
                        uspjesno = true;
                    }
                }

                if (!uspjesno) Console.WriteLine("\tNeuspješna prijava.\n");
            }

            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("|\t*Bagajna POS*\t\t\t\t\t\t\t|\n|\tDatum: {0}\t\t\t\t\t\t|\n|\tVrijeme: {1}\t\t\t\t\t\t\t|", DateTime.Now.ToString("dd.MM.yyyy"), DateTime.Now.ToString("HH:mm"));
            Console.WriteLine("|\t\t\t\t\t\t\t\t\t|");
            Console.WriteLine("|\tDobrodošao, {0}!\t\t\t\t\t\t|", korisnik);
            Console.WriteLine("|\tUčitavanje korisnika...\t\t\t\t\t\t|");
            Console.WriteLine("|\t\t\t\t\t\t\t\t\t|");
            Console.WriteLine("|_______________________________________________________________________|\n");

            string pozdrav = "Zar nije danas lijep dan? Samo prodaja! Zapamti - od prodaje živiš! :) :)";
            foreach (char s in pozdrav)
            {
                Console.Write(s);
                Thread.Sleep(50);
            }

            Thread.Sleep(2000);
            Console.WriteLine("\nKorisnik učitan!");
            Thread.Sleep(1000);

        }
    }
}
