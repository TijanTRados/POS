using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace POS
{
    class Intro
    {
        public void intro()
        {
            Console.WriteLine(">Starting POS.exe...");
            Thread.Sleep(1000);
            Console.WriteLine(">POS.exe");
            Thread.Sleep(500);
            Console.Clear();

            Console.WriteLine("\n\n\n\n\n\n\t\t\t*****************************************************************");
            Console.WriteLine("\t\t\t*\t\t\t\t\t\t\t\t*");
            Console.WriteLine("\t\t\t*\t\t\t\t\t\t\t\t*");
            Console.WriteLine("\t\t\t*\t\t$$$$\t  $$\t  $$$ \t\t$   $\t\t*");
            Console.WriteLine("\t\t\t*\t\t$   $\t $  $\t $   $\t\t $ $\t\t*");
            Console.WriteLine("\t\t\t*\t\t$   $\t$    $\t $    \t\t  $\t\t*");
            Console.WriteLine("\t\t\t*\t\t$$$$\t$    $\t  $$$ \t\t $ $\t\t*");
            Console.WriteLine("\t\t\t*\t\t$\t$    $\t     $\t\t$   $\t\t*");
            Console.WriteLine("\t\t\t*\t\t$\t $  $\t $   $\t\t\t\t*");
            Console.WriteLine("\t\t\t*\t\t$\t  $$\t  $$$ \tv1.0.1.\t\t\t*");
            Console.WriteLine("\t\t\t*\t\t\t\t\t\t\t\t*");
            Console.WriteLine("\t\t\t*\t\t\t\t\t\t\t\t*");
            Console.WriteLine("\t\t\t*****************************************************************");
            Console.WriteLine("\t\t\t\t\t\t\tc All rights reserved .POS 2016\n");
            Console.Write("\tLoading.");

            

            for (int i=0;  i<90; i++)
            {
                Random r = new Random();
                Thread.Sleep(r.Next(10, 100));
                Console.Write(".");

            }
            Thread.Sleep(1000);

        }
    }
}
