using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EU
{
    class Program
    {
            //2. feladathoz
        struct sajat
        {
            public string orszag;
            public DateTime csatlakozas;
        }
        static void Main(string[] args)
        {
            //2. feladat
            string[] fajl = File.ReadAllLines("Eucsatlakozas.txt");
            sajat[] adatok = new sajat[fajl.Length];
            for (int i = 0; i < fajl.Length; i++)
            {
                string[] darabol = fajl[i].Split(';');
                adatok[i].orszag = darabol[0];
                adatok[i].csatlakozas = Convert.ToDateTime(darabol[1]);
            }
        
            //3. feladat
            Console.WriteLine("3. feladat: EU tagállamok száma: {0} db",adatok.Length);
            
            //4. feladat
            int db = 0;
            for (int i = 0; i < adatok.Length; i++)
            {
                if (adatok[i].csatlakozas.Year==2007)
                {
                    db++;
                }
            }
            Console.WriteLine("4. feladta: 2007-ben {0} ország csatlakozott.", db);

            //5. feladat
            for (int i = 0; i < adatok.Length; i++)
            {
                if (adatok[i].orszag=="Magyarország")
                {
                    Console.WriteLine("5. feladat: Magyarország csatlakozásának dátuma: {0}", adatok[i].csatlakozas);
                    break;
                }
            }

            //6. feladat
            bool volt = false;
            for (int i = 0; i < adatok.Length; i++)
            {
                if (adatok[i].csatlakozas.Month==5)
                {
                    Console.WriteLine("6. feladat: Májusban volt csatlakozás!");
                    volt = true;
                    break;
                }
            }

            if (volt==false)
            {
                Console.WriteLine("6. feladat: Májusban nem volt csatlakozás!");
            }

            //7. feladat
            DateTime max = adatok[0].csatlakozas;
            int index = 0;
            for (int i = 0; i < adatok.Length; i++)
            {
                if (adatok[i].csatlakozas > max)
                {
                    max = adatok[i].csatlakozas;
                    index = i;
                }
            }
            Console.WriteLine("7. feladat: Legutoljára csatlakozott ország: {0}", adatok[index].orszag);
            
            //8. feladat
            Console.WriteLine("8. feladat: Statisztika");
            List<int> evek = new List<int>();
            for (int i = 0; i < adatok.Length; i++)
            {
                evek.Add(adatok[i].csatlakozas.Year);
            }
            List<int> szurtevek = new List<int>();
            szurtevek = evek.Distinct().ToList();
            int evdb = 0;
            for (int i = 0; i < szurtevek.Count; i++)
            {
                for (int j = 0; j < evek.Count; j++)
                {
                    if (szurtevek[i] == evek[j])
                    {
                        evdb++;
                    }
                }
                Console.WriteLine("\t{0} - {1} ország", szurtevek[i], evdb);
                evdb = 0;
            }

            Console.ReadKey();
        }
    }
}
