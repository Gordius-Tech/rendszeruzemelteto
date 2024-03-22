using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bérek2020
{
    class Program
    {
        //fajlbeolvasáshoz
        struct sajat
        {
            public string nev;
            public string nem;
            public string reszleg;
            public int belepes;
            public int ber;
        }
        static void Main(string[] args)
        {
            //2. feladat
            string[] fajl = File.ReadAllLines("berek2020.txt");
            sajat[] adatok = new sajat[fajl.Length - 1];
            for (int i = 1; i < fajl.Length; i++)
            {
                string[] darabol = fajl[i].Split(';');
                adatok[i - 1].nev = darabol[0];
                adatok[i - 1].nem = darabol[1];
                adatok[i - 1].reszleg = darabol[2];
                adatok[i - 1].belepes = Convert.ToInt32(darabol[3]);
                adatok[i - 1].ber = Convert.ToInt32(darabol[4]);

            }
            //3. feladat
            int dolgozokszama = adatok.Length;
            Console.WriteLine("3. feladat: Dolgozók száma: {0} fő", dolgozokszama);

            //4. feladat
            double atlag = 0, szum=0;
            for (int i = 0; i < adatok.Length; i++)
            {
                szum += adatok[i].ber;
            }
            atlag = szum / adatok.Length;
            Console.WriteLine("4. feladat: Bérek átlaga: {0:0.0} eFt", atlag/1000);

            //5. feladat
            Console.Write("5. feladat: Kérem egy részleg nevét: ");
            string reszl = Console.ReadLine();

            //6. feladat
            bool vanilyen = false;
            int index = 0, max=0; //feltételezzük, hogy 0-tól nagyobb fizetése van mindenkinek
            for (int i = 0; i < adatok.Length; i++)
            {
                if (adatok[i].reszleg==reszl)
                {
                    vanilyen = true;
                    if (max < adatok[i].ber)
                    {
                        max = adatok[i].ber;
                        index = i;
                    }
                }
            }

            if (vanilyen)
            {
                Console.WriteLine("6. feladat: A legtöbbet kereső dolgozó a megadott részlegen");
                Console.WriteLine("\tNév: {0}", adatok[index].nev);
                Console.WriteLine("\tNeme: {0}", adatok[index].nem);
                Console.WriteLine("\tBelépés: {0}", adatok[index].belepes);
                Console.WriteLine("\tBér: {0} Forint", adatok[index].ber);
            }
            else
            {
                Console.WriteLine("6. feladat: A megadott részleg nem létezik a cégnél!");
            }

            //7. feladat
            Console.WriteLine("7. feladat: Statisztika");
            
            List<string> reszlegek = new List<string>();
            
            for (int i = 0; i < adatok.Length; i++)
            {
                reszlegek.Add(adatok[i].reszleg);
            }
            
            List<string> szurtreszleg = reszlegek.Distinct().ToList();

            int db = 0;
            for (int i = 0; i < szurtreszleg.Count; i++)
            {
                for (int j = 0; j < reszlegek.Count; j++)
                {
                    if (szurtreszleg[i]==reszlegek[j])
                    {
                        db++;
                    }
                }
                Console.WriteLine("\t{0} - {1} fő",szurtreszleg[i],db);
                db = 0;
            }
            Console.ReadKey();
        }
    }
}
