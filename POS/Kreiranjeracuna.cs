using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace POS
{
    class Kreiranjeracuna
    {

        public void Kreiranje(string korisnik)
        {
            Racun racun = new Racun();
            Izbornik i = new Izbornik();
            bool vrti = true;
            int izbor;
            
            int broj = 0;

            while (vrti)
            {
                float zbroj = 0;
                float pdv = 0;
                Console.Clear();
                    Console.WriteLine("*************************************************************************");
                    Console.WriteLine("|\t*Bagajna POS*\t\t\t\t\t\t\t|\n|\tDatum: {0}\t\t\t\t\t\t|\n|\tVrijeme: {1}\t\t\t\t\t\t\t|", DateTime.Now.ToString("dd.MM.yyyy"), DateTime.Now.ToString("HH:mm"));
                    Console.WriteLine("|\t\t\t\t\t\t\t\t\t|");
                    Console.WriteLine("|\tDobrodošao, {0}!\t\t\t\t\t\t|", korisnik);
                    Console.WriteLine("|\t*Connected with POS\t\t\t\t\t\t|");
                    Console.WriteLine("|\t\t\t\t\t\t\t\t\t|");
                    Console.WriteLine("|_______________________________________________________________________|\n");

                    Console.WriteLine("\t{0,3}{1,7}{2,15}{3,10}{4,10}", "#", "Šifra", "Naziv", "Količina", "Iznos");

                    if (racun.stavke != null)
                    {
                        foreach (Stavka s in racun.stavke)
                        {
                            Console.WriteLine("\t{0,3}{1,7}{2,15}{3,10}{4,8}kn", s.broj, s.sifra, s.naziv, s.kolicina, s.iznos.ToString("0.00"));
                            zbroj = zbroj + s.iznos;
                            pdv = pdv + s.pdvizracun;
                            
                        }
                    }

                    Console.WriteLine("\t_______________________________________________");
                    Console.WriteLine("\t{0,35}{1,8}kn", "Ukupno:", zbroj.ToString("0.00"));
                    
                    i.opcije(korisnik);
             
                
                string x = Console.ReadLine();
                if (x == "") continue;
                izbor = Int32.Parse(x);

                switch (izbor)
                {
                    case 0: return;
                    case 1: broj++;
                        Stavka s = new Stavka();
                        s.stavka(korisnik, broj);
                        racun.stavke.Add(s);
                        racun.brojstavki = broj;
                        break;

                    case 2:
                        if (racun.stavke == null)
                        {
                            Console.WriteLine("Ne postoji još ni jedna stavka na računu.");
                            Thread.Sleep(1000);
                            break;
                        }

                        Console.Clear();
                        Console.WriteLine("*************************************************************************");
                        Console.WriteLine("|\t*Bagajna POS*\t\t\t\t\t\t\t|\n|\tDatum: {0}\t\t\t\t\t\t|\n|\tVrijeme: {1}\t\t\t\t\t\t\t|", DateTime.Now.ToString("dd.MM.yyyy"), DateTime.Now.ToString("HH:mm"));
                        Console.WriteLine("|\t\t\t\t\t\t\t\t\t|");
                        Console.WriteLine("|\tDobrodošao, {0}!\t\t\t\t\t\t|", korisnik);
                        Console.WriteLine("|\t*Connected with POS\t\t\t\t\t\t|");
                        Console.WriteLine("|\t\t\t\t\t\t\t\t\t|");
                        Console.WriteLine("|_______________________________________________________________________|\n");

                        Console.WriteLine("\t{0,3}{1,7}{2,15}{3,10}{4,10}", "#", "Šifra", "Naziv", "Količina", "Iznos");

                        if (racun.stavke != null)
                        {
                            foreach (Stavka z in racun.stavke)
                            {
                                Console.WriteLine("\t{0,3}{1,7}{2,15}{3,10}{4,8}kn", z.broj, z.sifra, z.naziv, z.kolicina, z.iznos.ToString("0.00"));
                            }
                        }

                        Console.WriteLine("\t_______________________________________________");
                        Console.WriteLine("\t{0,35}{1,8}kn\n", "Ukupno:", zbroj.ToString("0.00"));

                        if (korisnik == "blagajnik")
                        {
                            Console.Write("\n\tPotrebna admin lozinka: ");
                            string admin = Console.ReadLine();
                            if (admin != "admin")
                            {
                                Console.Write("Netočna.");
                                Thread.Sleep(1000);
                                continue;
                            }
                        }
                        
                        Console.Write("\n\tKoju stavku želite obrisati?: ");
                        string t = Console.ReadLine();
                        if (t == "") continue;
                        int id = Int32.Parse(t);
                        racun.izbrisistavku(id);
                        broj--;
                        
                        
                        break;

                    case 3:
                        if (broj == 0)
                        {
                            Console.WriteLine("\n\tNemoguće proknjižiti prazan račun.");
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            Ucitavanje u = new Ucitavanje();
                            u.ucitajracune();

                            int brojrac = u.racuni[u.racuni.Count - 1].brojRacuna + 1;

                            racun.brojRacuna = brojrac;
                            racun.brojstavki = broj;
                            racun.datumvrijeme = DateTime.Now;
                            racun.ukupno = zbroj;
                            racun.PDV = pdv;

                            string upis = racun.brojRacuna.ToString() + " "+ racun.datumvrijeme.ToString("dd.MM.yyy HH:mm")+" " + racun.brojstavki.ToString()+" "; 

                            foreach(Stavka q in racun.stavke)
                            {
                                upis = upis + q.broj.ToString() + " " + q.sifra.ToString() + " " + q.naziv + " " + q.kolicina.ToString() + " " + q.cijena.ToString(" ") + " " + q.cijena.ToString() + " " + q.iznos.ToString() + " " + q.pdv.ToString() + " " + q.pdvizracun.ToString()+" ";
                            }

                            upis = upis + racun.ukupno.ToString() + " " + racun.PDV;
                            upis = upis.Replace("  ", " ");
                            upis = upis.Replace("  ", " ");
                            upis = upis.Replace("  ", " ");
                            upis = upis.Replace("  ", " ");
                            upis = upis.Replace("  ", " ");
                            upis = upis.Replace("  ", " ");

                            using (System.IO.StreamWriter file =new System.IO.StreamWriter("racuni.txt", true))
                            {
                                file.WriteLine(upis);
                            }

                            printer printer = new printer(racun);
                            vrti = false;
                            
                        }
                        break;

                    default:
                        break;
                }
            }
            

        }
    }
}
