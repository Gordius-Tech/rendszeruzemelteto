using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lift
{
    class Program
    {
        //2-es feladathoz kell
        struct sajat
        {
            public DateTime idopont;
            public int kartyaszam;
            public int induloszint;
            public int celszint;
        }
        static void Main(string[] args)
        {
            
            //2. feladat
            string[] fajl = File.ReadAllLines("lift.txt");
            sajat[] adatok = new sajat[fajl.Length];
            
            for (int i = 0; i < fajl.Length; i++)
            {
                string[] darabol = fajl[i].Split(' ');
                adatok[i].idopont = Convert.ToDateTime(darabol[0]);
                adatok[i].kartyaszam = Convert.ToInt32(darabol[1]);
                adatok[i].induloszint = Convert.ToInt32(darabol[2]);
                adatok[i].celszint = Convert.ToInt32(darabol[3]);
            }

            //3. feladat
            int osszlift = adatok.Length;
            Console.WriteLine("3. feladat: Összes lifthasznalat: {0}", osszlift);

            //4. feladat
            Console.WriteLine("4. feladat: Időszak: {0} - {1}",adatok[0].idopont.ToString("yyyy.MM.dd"), adatok[adatok.Length-1].idopont.ToString("yyyy.MM.dd"));

            //5. feladat
            int max = adatok[0].celszint;
            for (int i = 1; i < adatok.Length; i++)
            {
                if (max < adatok[i].celszint)
                {
                    max = adatok[i].celszint;
                }
            }
            Console.WriteLine("5. feladat: Célszint max: {0}",max);

            //6. feladat
            Console.WriteLine("6. feladat:");
            Console.Write("\tKártya száma: ");
            string kartyaszam = Console.ReadLine();
            Console.Write("\tCélszint száma: ");
            string celszint = Console.ReadLine();
            int kszam = 0, celsz = 0;
            try
            {
                kszam = Convert.ToInt32(kartyaszam);
            }
            catch (Exception)
            {
                kszam = 5;
            }
            
            try
            {
                celsz = Convert.ToInt32(celszint);
            }
            catch (Exception)
            {
                celsz = 5;
            }

            //7. feladat
            bool volt = false;
            for (int i = 0; i < adatok.Length; i++)
            {
                if (adatok[i].kartyaszam==kszam && adatok[i].celszint==celsz)
                {
                    volt = true;
                    Console.WriteLine("7. feladat: A(z) {0} kártyával utaztak a(z) {1} emeletre!", kszam, celsz);
                    break;
                }
            }

            if (volt==false)
            {
                Console.WriteLine("7. feladat: A(z) {0} kártyával nem utaztak a(z) {1} emeletre!", kszam, celsz);
            }

            //8. feladat
            Console.WriteLine("8. feladat: Statisztika");
            List<string> napok = new List<string>();
            for (int i = 0; i < adatok.Length; i++)
            {
                napok.Add(adatok[i].idopont.ToString("yyyy.MM.dd"));
                
            }
            List<string> szurtnapok = new List<string>();
            szurtnapok = napok.Distinct().ToList();
            int db = 0;
            for (int i = 0; i < szurtnapok.Count; i++)
            {
                for (int j = 0; j < napok.Count; j++)
                {
                    if (szurtnapok[i]==napok[j])
                    {
                        db++;
                    }
                }
                Console.WriteLine("\t{0} - {1}x",szurtnapok[i],db);
                db = 0;
            }
            Console.ReadKey();
        }
    }
}
