using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Zadejte jméno hráče A: ");
            Hrac hracA = new Hrac(Console.ReadLine());

            Console.Write("Zadejte jméno hráče B: ");
            Hrac hracB = new Hrac(Console.ReadLine());

            while (true)
            {
                Console.Clear(); // smaže obrazovku – nepovinné, ale přehledné

                // ZOBRAZENÍ SKÓRE
                Console.WriteLine("========== SKÓRE ==========");
                VypisSkore(hracA);
                VypisSkore(hracB);
                Console.WriteLine("============================\n");

                // MENU
                Console.WriteLine("1 - Bod pro hráče A");
                Console.WriteLine("2 - Bod pro hráče B");
                Console.WriteLine("3 - Restartovat hru");
                Console.WriteLine("4 - Konec");
                Console.Write("Zadej volbu: ");
                string volba = Console.ReadLine();

                switch (volba)
                {
                    case "1":
                        PridejBod(hracA, hracB);
                        break;
                    case "2":
                        PridejBod(hracB, hracA);
                        break;
                    case "3":
                        hracA.Body = hracB.Body = 0;
                        hracA.Gemy = hracB.Gemy = 0;
                        hracA.Sety = hracB.Sety = 0;
                        break;
                    case "4":
                        Console.WriteLine("Ukončuji hru...");
                        return;
                    default:
                        Console.WriteLine("Neplatná volba.");
                        break;
                }
                Console.ReadKey();
            }
        }
        static void VypisSkore(Hrac hrac)
        {
            Console.WriteLine(hrac.Jmeno + " | Body: " + PrelozSkore(hrac.Body) + " | Gemy: " + hrac.Gemy + " | Sety: " + hrac.Sety);
        }

        static string PrelozSkore(int body)
        {
            switch (body)
            {
                case 0: return "0";
                case 1: return "15";
                case 2: return "30";
                case 3: return "40";
                default: return "?";
            }
        }


        static void PridejBod(Hrac hrac, Hrac souper)
        {
            hrac.Body++;

            if (hrac.Body > 3 && souper.Body < 3)
            {
                Console.WriteLine($"{hrac.Jmeno} vyhrává gem!");
                hrac.Gemy++;
                hrac.Body = 0;
                souper.Body = 0;
            }
        }


        class Hrac
        {
            public string Jmeno { get; set; }
            public int Body { get; set; }
            public int Gemy {  get; set; }
            public int Sety { get; set; }

            public Hrac(string jmeno)
            {
                Jmeno = jmeno;
                Body = 0;
                Gemy = 0;
                Sety = 0;
            }

        }
    }
}
