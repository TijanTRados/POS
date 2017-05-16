using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    class Izbornik
    {
        public int glavni(string korisnik)
        {
            string x;

            Console.Clear();
            Console.WriteLine("*************************************************************************");
            Console.WriteLine("|\t*Bagajna POS*\t\t\t\t\t\t\t|\n|\tDatum: {0}\t\t\t\t\t\t|\n|\tVrijeme: {1}\t\t\t\t\t\t\t|", DateTime.Now.ToString("dd.MM.yyyy"), DateTime.Now.ToString("HH:mm"));
            Console.WriteLine("|\t\t\t\t\t\t\t\t\t|");
            Console.WriteLine("|\tDobrodošao, {0}!\t\t\t\t\t\t|", korisnik);
            Console.WriteLine("|\t*Connected with POS\t\t\t\t\t\t|");
            Console.WriteLine("|\t\t\t\t\t\t\t\t\t|");
            Console.WriteLine("|_______________________________________________________________________|\n");

            Console.WriteLine("\tOdaberi redni broj opcije: \n");
            Console.WriteLine("\t\t1. Kreiranje računa\n");
            Console.WriteLine("\t\t2. X total (dnevni utržak)\n");
            Console.WriteLine("\t\t3. Izvješće po artiklu\n");
            if (korisnik == "admin")
            {
                Console.WriteLine("\t\t4. Dodaj artikal\n");
                Console.WriteLine("\t\t5. Storniraj račun\n");
            }
            Console.WriteLine("\t\t0. Logout\n");

            x= Console.ReadLine();

            if (x == "") return -1;

            return Int32.Parse(x);
        }

        public void opcije(string korisnik)
        {
            Console.WriteLine();
            Console.WriteLine("\tOdaberi redni broj opcije: \n");
            Console.WriteLine("\t\t1. Dodaj stavku\n");
            Console.WriteLine("\t\t2. Obriši stavku\n");
            Console.WriteLine("\t\t3. Proknjiži\n");
            Console.WriteLine("\t0. Odustani\n");

           
        }
    }
}
