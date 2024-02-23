using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snooker
{
    class Program
    {
        struct sajat
        {
            public int hely;
            public string nev;
            public string orszag;
            public int nyeremeny;
        }


        static void Main(string[] args)
        {
            string[] fajl = File.ReadAllLines("snooker.txt");
            sajat[] adatok = new sajat[fajl.Length - 1];
            for (int i = 1; i < fajl.Length; i++)
            {
                string[] darabol = fajl[i].Split(';');
                adatok[i - 1].hely = int.Parse(darabol[0]);
                adatok[i - 1].nev = darabol[1];
                adatok[i - 1].orszag = darabol[2];
                adatok[i - 1].nyeremeny = int.Parse(darabol[3]);
                           
            }
            Console.WriteLine($"3. feladat: A világranglistán {adatok.Length} versenyző szerepel");
            double szum = 0;
            for (int i = 0; i < adatok.Length; i++)
            {
                szum += adatok[i].nyeremeny;
            }
            double atlag = szum / adatok.Length;
            Console.WriteLine("4. feladat: A versenyzők átlagosan {0:0.00} fontot kerestek", atlag);
            int max = -1;
            int index = -1;
            for (int i = 0; i < adatok.Length; i++)
            {
                if (adatok[i].orszag == "Kína" && adatok[i].nyeremeny > max)
                {
                    index = i;
                    max = adatok[i].nyeremeny;
                }
            }

            Console.WriteLine("5. feladat: A legjobban kereső kínai versenyző:");
            Console.WriteLine("\tHelyezés: {0}",adatok[index].hely);
            Console.WriteLine("\tNév: {0}", adatok[index].nev);
            Console.WriteLine("\tOrszág: {0}", adatok[index].orszag);
            Console.WriteLine("\tNyeremény összege: {0} Ft", adatok[index].nyeremeny*380);

            bool van_norveg = false;
            for (int i = 0; i < adatok.Length; i++)
            {
                if (adatok[i].orszag == "Norvégia")
                {
                    Console.WriteLine("6. feladat: A versenyzők között van norvég versenyző.");
                    van_norveg = true;
                    break;
                } 
            }
            if (van_norveg==false)
            {
                Console.WriteLine("6. feladat: A versenyzők között nincs norvég versenyző.");
            }

            List<string> orszagok = new List<string>();
            for (int i = 0; i < adatok.Length; i++)
            {
                orszagok.Add(adatok[i].orszag);
                
            }
            Console.WriteLine("7. feladat: Statisztika:");
            List<string> szurtorszagok = new List<string>();
            int db = 0;
            szurtorszagok = orszagok.Distinct().ToList();

            for (int i = 0; i < szurtorszagok.Count; i++)
            {
                db = 0;
                //    Console.WriteLine(szurtorszagok[i]);
                for (int j = 0; j < adatok.Length; j++)
                {
                    if (szurtorszagok[i]==adatok[j].orszag)
                    {
                        db++;
                    }
                }
                if (db>4)
                {
                    Console.WriteLine("\t{0} - {1} fő", szurtorszagok[i], db);
                }
                
            }




            Console.ReadKey();
        }
    }
}
