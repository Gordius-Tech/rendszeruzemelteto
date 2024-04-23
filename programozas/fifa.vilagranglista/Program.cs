using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FIFAvilagranglista
{
    class Program
    {
         //fájlbeolvasáshoz
        struct sajat
        {
            public string csapat;
            public int helyezes;
            public int valtozas;
            public int pontszam;
        }
         static void Main(string[] args)
        //2. feladat        
        {
            string[] fajl = File.ReadAllLines("fifa.txt");
            sajat[] adatok = new sajat[fajl.Length-1];
            for (int i = 1; i < fajl.Length; i++)
            {
                string[] darabol = fajl[i].Split(';');
                adatok[i - 1].csapat = darabol[0];
                adatok[i - 1].helyezes = Convert.ToInt32(darabol[1]);
                adatok[i - 1].valtozas = Convert.ToInt32(darabol[2]);
                adatok[i - 1].pontszam = Convert.ToInt32(darabol[3]);
            }

            //3. feladat
            int csapatszam = fajl.Length-1;
            Console.WriteLine("3. feladat: A világranglistán: {0} csapat szerepel", csapatszam);

            //4. feladat
            double szum = 0, atlag = 0;
            for (int i = 0; i < adatok.Length; i++)
            {
                szum += adatok[i].pontszam;
            }
            atlag = szum / adatok.Length;
            Console.WriteLine("4. feladat: A csapatok átlagos pontszáma: {0:0.00} pont", atlag);

            //5. feladat
            int max = adatok[0].valtozas;
            int index = 0;
            for (int i = 1; i < adatok.Length; i++)
            {
                if (adatok[i].valtozas>max)
                {
                    max = adatok[i].valtozas;
                    index = i;
                }
            }
            Console.WriteLine("5. feladat: A legtöbbet javító csapat:");
            Console.WriteLine("\tHelyezés: {0}",adatok[index].helyezes);
            Console.WriteLine("\tCsapat: {0}", adatok[index].csapat);
            Console.WriteLine("\tPontszám: {0}", adatok[index].pontszam);

            //6. feladat
            bool bennevan = false;
            for (int i = 0; i < adatok.Length; i++)
            {
                if (adatok[i].csapat=="Magyarország")
                {
                    Console.WriteLine("6. feladat: A csapatok között benne van Magyarország");
                    bennevan = true;
                    Console.WriteLine(i+1);
                    break;
                }
            }
            if (bennevan == false)
            {
                Console.WriteLine("6. feladat: A csapatok között nincs Magyarország");
            }

            //7. feladat
            Console.WriteLine("7. feladat: Statisztika");
            List<int> valtozasok = new List<int>();
            for (int i = 0; i < adatok.Length; i++)
            {
                valtozasok.Add(adatok[i].valtozas);
            }
            List<int> szurtvaltozas = valtozasok.Distinct().ToList();
            int db = 0;
            for (int i = 0; i < szurtvaltozas.Count; i++)
            {
                for (int j = 0; j < valtozasok.Count; j++)
                {
                    if (szurtvaltozas[i]==valtozasok[j])
                    {
                        db++;
                    }
                }
                if (db>1)
                {
                    Console.WriteLine("\t{0} helyet változott: {1} csapat",szurtvaltozas[i], db);
                }
                db = 0;
            }

            Console.ReadKey();
        }
    }
}
