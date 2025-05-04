using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

using System;

namespace Tenis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Zadejte jméno hráče 1: ");
            string Jmeno1 = Console.ReadLine();
            Hrac hrac1 = new Hrac(Jmeno1);

            Console.Write("Zadejte jméno hráče 2: ");
            string Jmeno2 = Console.ReadLine();
            Hrac hrac2 = new Hrac(Jmeno2);

            while (true)
            {
                Console.Clear();
                Skore(hrac1);
                Skore(hrac2);

                Console.WriteLine("Menu:");
                Console.WriteLine("1 - Bod pro hráče A");
                Console.WriteLine("2 - Bod pro hráče B");
                Console.WriteLine("3 - Restartovat hru");
                Console.WriteLine("4 - Konec");
                Console.Write("Zadej volbu: ");
                string volba = Console.ReadLine();

                switch (volba)
                {
                    case "1":
                        Bod(hrac1, hrac2);
                        if (hrac1.Sety == 2)
                        {
                            hrac1.Sety++;
                            Console.WriteLine(hrac1.Jmeno + " vyhrál zápas!");
                            Vyhra(hrac1, hrac2);
                        }
                        else if (hrac2.Sety == 2)
                        {
                            hrac2.Sety++;
                            Console.WriteLine(hrac2.Jmeno + " vyhrál zápas!");
                            Vyhra(hrac1, hrac2);
                        }
                        break;
                    case "2":
                        Bod(hrac2, hrac1);
                        if (hrac1.Sety == 2)
                        {
                            Console.WriteLine(hrac1.Jmeno + " vyhrál zápas!");
                            Vyhra(hrac1, hrac2);
                        }
                        else if (hrac2.Sety == 2)
                        {
                            Console.WriteLine(hrac2.Jmeno + " vyhrál zápas!");
                            Vyhra(hrac1, hrac2);
                        }
                        break;
                    case "3":
                        hrac1.Reset();
                        hrac2.Reset();
                        Console.WriteLine("Hra byla resetována. Stiskněte libovolnou klávesu pro pokračování.");
                        Console.ReadKey();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Neplatná volba, zkuste to znovu.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void Skore(Hrac hrac)
        {
            string body;

            if (hrac.Adv)
                body = "Výhoda";
            else if (hrac.Body >= 3)
                body = "40";
            else
                body = SkoreConverter(hrac.Body);

            Console.WriteLine(hrac.Jmeno + " | Body: " + body + " | Gemy: " + hrac.Gemy + " | Sety: " + hrac.Sety);
        }

        static void Vyhra(Hrac hrac1, Hrac hrac2)
        {
            Console.WriteLine("Chcete spustit novou hru? (A - ano N - ne)");
            string vstup = Console.ReadLine();

            if (vstup == "A")
            {
                hrac1.Reset();
                hrac2.Reset();
            }
            else
            {
                Environment.Exit(0);
            }
        }


        static string SkoreConverter(int body)
        {
            if (body == 0) return "0";
            if (body == 1) return "15";
            if (body == 2) return "30";
            if (body == 3) return "40";
            return null;
        }

        static void Bod(Hrac hrac, Hrac souper)
        {
            if (hrac.Body == 3 && souper.Body == 3)
            {
                if (hrac.Adv)
                {
                    VyhraGem(hrac, souper);
                }
                else if (souper.Adv)
                {
                    souper.Adv = false;
                }
                else
                {
                    hrac.Adv = true;
                }

                return;
            }

            if (hrac.Body == 3 && souper.Body < 3)
            {
                VyhraGem(hrac, souper);
                return;
            }

            hrac.Body++;
        }

        static void VyhraGem(Hrac hrac, Hrac souper)
        {
            hrac.Gemy++;
            hrac.Body = 0;
            souper.Body = 0;
            hrac.Adv = false;
            souper.Adv = false;

            if (hrac.Gemy >= 6 && (hrac.Gemy - souper.Gemy) >= 2)
            {
                hrac.Sety++;
                hrac.Gemy = 0;
                souper.Gemy = 0;
            }
        }
    }

    class Hrac
    {
        public string Jmeno { get; set; }
        public int Body { get; set; }
        public int Gemy { get; set; }
        public int Sety { get; set; }
        public bool Adv { get; set; }

        public Hrac(string jmeno)
        {
            Jmeno = jmeno;
            Reset();
        }

        public void Reset()
        {
            Body = 0;
            Gemy = 0;
            Sety = 0;
            Adv = false;
        }
    }
}
