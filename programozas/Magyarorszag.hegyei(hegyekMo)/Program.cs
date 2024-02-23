using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HegyekMo
{
    class Program
    {
        struct sajat
        {
            public string nev;
            public string hegyseg;
            public int magassag;
        }
        static void Main(string[] args)
        {
            string[] fajl = File.ReadAllLines("hegyekMo.txt");
            sajat[] adatok = new sajat[fajl.Length-1];
            
            for (int i = 1; i < fajl.Length; i++)
            {
                string[] darabol = fajl[i].Split(';');
                adatok[i-1].nev = darabol[0];
                adatok[i-1].hegyseg = darabol[1];
                adatok[i-1].magassag = Convert.ToInt32(darabol[2]);
            }
            Console.WriteLine("3. feladat: Hegycsúcsok száma: {0} db", adatok.Length);
            double szum = 0;
            for (int i = 0; i < adatok.Length; i++)
            {
                szum += adatok[i].magassag;
            }
            double atlag = szum / adatok.Length;
            Console.WriteLine("4. feladat: Hegycsúcsok átlagos magassága: {0:0.00} m",atlag);

            int index = 0;
            int max = adatok[0].magassag;

            for (int i = 1; i < adatok.Length; i++)
            {
                if (adatok[i].magassag> max)
                {
                    max = adatok[i].magassag;
                    index = i;
                }
            }
            Console.WriteLine("A legmagasabb hegycsúcs adatai:");
            Console.WriteLine("\tNév: {0}",adatok[index].nev);
            Console.WriteLine("\tHegység: {0}", adatok[index].hegyseg);
            Console.WriteLine("\tMagasság: {0} m", adatok[index].magassag);

            Console.Write("6. feladat: Kérek egy magasságot: ");
            int magas = Convert.ToInt32(Console.ReadLine());
            bool van = false;
            for (int i = 0; i < adatok.Length; i++)
            {
                if (adatok[i].magassag> magas && adatok[i].hegyseg=="Börzsöny")
                {
                    van = true;
                    Console.WriteLine("Van {0}m-nél magasabb hegycsúcs a Börzsönyben!", magas);
                    break;
                }
            }
            if (van == false)
            {
                Console.WriteLine("Nincs {0}m-nél magasabb hegycsúcs a Börzsönyben!", magas);
            }

            int db = 0;
            for (int i = 0; i < adatok.Length; i++)
            {
                if (adatok[i].magassag * 3.280839895>3000)
                {
                    db++;
                }
            }
            
            Console.WriteLine("7. feladat: 3000 lábnál magasabb hegycsúcsok száma: {0}",db);
            
            Console.WriteLine("8. feladat: Hegység statisztika");
            List<string> hegysegek = new List<string>();
            for (int i = 0; i < adatok.Length; i++)
            {
                hegysegek.Add(adatok[i].hegyseg);
            }
            List<string> szurthegysegek = new List<string>();
            szurthegysegek = hegysegek.Distinct().ToList();

            int hegysegdb = 0;
            for (int i = 0; i < szurthegysegek.Count; i++)
            {
                hegysegdb = 0;
                for (int j = 0; j < adatok.Length; j++)
                {
                    if (adatok[j].hegyseg==szurthegysegek[i])
                    {
                        hegysegdb++;
                    }
                }
                Console.WriteLine("\t{0} - {1} db", szurthegysegek[i], hegysegdb);
            }
            
            List<string> fajlba = new List<string>();
            fajlba.Add("Hegycsúcs neve;Magasság láb");
            double lab = 0;
            for (int i = 0; i < adatok.Length; i++)
            {
                if (adatok[i].hegyseg=="Bükk-vidék")
                {
                    lab = Math.Round(adatok[i].magassag * 3.280839895, 1);
                    fajlba.Add(adatok[i].nev + ';' + lab);
                }
            }
            Console.WriteLine("9. feladat: bukk-videk.txt");
            File.WriteAllLines("bukk-videk.txt", fajlba);
            Console.ReadKey();
        }
    }
}
