using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace vb2018
{
    class Program
    {
        
        //fajlbeolvasáshoz
        struct sajat
        {
            public string varos;
            public string nev1;
            public string nev2;
            public int ferohely;
        }
        static void Main(string[] args)
        {
           
            //2. feladat
            string[] fajl = File.ReadAllLines("vb2018.txt");
            sajat[] adatok = new sajat[fajl.Length - 1];
            for (int i = 1; i < fajl.Length; i++)
            {
                string[] darabol = fajl[i].Split(';');
                adatok[i - 1].varos = darabol[0];
                adatok[i - 1].nev1 = darabol[1];
                adatok[i - 1].nev2 = darabol[2];
                adatok[i - 1].ferohely = Convert.ToInt32(darabol[3]);
            }
            
            //3. feladat
            Console.WriteLine("3. feladat: Stadionok száma: {0}", adatok.Length);

            //4. feladat
            int index = 0, min = adatok[0].ferohely;
            for (int i = 1; i < adatok.Length; i++)
            {
                if (min>adatok[i].ferohely)
                {
                    index = i;
                    min = adatok[i].ferohely;
                }
            }
            Console.WriteLine("4. feladat: A legkevesebb férőhely");
            Console.WriteLine("\tVáros: {0}", adatok[index].varos);
            Console.WriteLine("\tStadion neve: {0}", adatok[index].nev1);
            Console.WriteLine("\tFérőhely: {0}", adatok[index].ferohely);

            //5. feladat
            double szum = 0;
            for (int i = 0; i < adatok.Length; i++)
            {
                szum += adatok[i].ferohely;
            }
            double atlag = szum / adatok.Length;
            Console.WriteLine("5. feladat: Átlagos férőhelyszám: {0:0.0}",atlag);

            //6. feladat
            int altnevdb = 0;
            for (int i = 0; i < adatok.Length; i++)
            {
                if (adatok[i].nev2!= "n.a.")
                {
                    altnevdb++;
                }
            }
            Console.WriteLine("6. feladat: Két névvel is ismert stadionok száma: {0}",altnevdb);

            //7. feladat

            string nev = "";
            Console.Write("7. feladat: Kérem a város nevét:");
            nev = Console.ReadLine();
            while (nev.Length<3)
            {
                Console.Write("7. feladat: Kérem a város nevét:");
                nev = Console.ReadLine();
            }
            
            //8. feladat
            nev = nev.ToUpper();
            bool volt = false;
            for (int i = 0; i < adatok.Length; i++)
            {
                if (adatok[i].varos.ToUpper()==nev)
                {
                    Console.WriteLine("8. feladat: A megadott város VB helyszín.");
                    volt = true;
                    break;
                }
            }
            if (volt == false)
            {
                Console.WriteLine("8. feladat: A megadott város nem VB helyszín.");
            }

            //9. feladat
            List<string> varosok = new List<string>();
            
            for (int i = 0; i < adatok.Length; i++)
            {
                varosok.Add(adatok[i].varos);
            }

            List<string> szurtvaros = new List<string>();
            szurtvaros = varosok.Distinct().ToList();
            Console.WriteLine("9. feladat: {0} különböző városban voltak mérkőzések.", szurtvaros.Count);


            Console.ReadKey();
        }
    }
}
