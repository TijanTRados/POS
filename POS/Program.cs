using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace POS
{
    class Program
    {
        static void Main(string[] args)
        {

            int izbor;
            Intro r = new Intro();
            Login l = new Login();
            Izbornik i = new Izbornik();

            r.intro();
            l.login();
            while (true)
            {
                izbor = i.glavni(l.korisnik);
                switch (izbor)
                {
                    case 0:
                        Console.Clear();
                        l.login();
                        break;
                    case 1: Console.Clear();
                        Kreiranjeracuna kreiraj = new Kreiranjeracuna();
                        kreiraj.Kreiranje(l.korisnik);
                        break;
                    case 2: Console.Clear();
                        xtotal xtotal = new xtotal();
                        xtotal.xtotalc();
                        break;
                    case 3: Console.Clear();
                        izvjesce z = new izvjesce();
                        z.izvjescec();
                        break;
                    case 4:
                        if (l.korisnik == "blagajnik") break;
                        Console.Clear();
                        Artikl a = new Artikl();
                        a.dodajartikl(l.korisnik);
                        break;
                    case 5:
                        if (l.korisnik == "blagajnik") break;
                        Console.Clear();
                        Racun rac = new POS.Racun();
                        rac.storniraj();
                        break;

                    default: break;

                }
            }
        }


    }
}
