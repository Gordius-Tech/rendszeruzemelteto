using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Schumacher
{
    class Program
    {
        //a faljbeolvasáshoz kell
        struct sajat
        {
            public DateTime datum;
            public string nagydij;
            public int pozicio;
            public int korok;
            public int pontok;
            public string csapat;
            public string statusz;
        }
        static void Main(string[] args)
        {
            //2. feladat
            string[] fajl = File.ReadAllLines("Schumacher.csv");
            sajat[] adatok = new sajat[fajl.Length - 1];
            for (int i = 1; i < fajl.Length; i++)
            {
                string[] darabol = fajl[i].Split(';');
                adatok[i - 1].datum = Convert.ToDateTime(darabol[0]);
                adatok[i - 1].nagydij = darabol[1];
                adatok[i - 1].pozicio = Convert.ToInt32(darabol[2]);
                adatok[i - 1].korok = Convert.ToInt32(darabol[3]);
                adatok[i-1].pontok= Convert.ToInt32(darabol[4]);
                adatok[i - 1].csapat = darabol[5];
                adatok[i - 1].statusz = darabol[6];
            }
            
            //3. feladat
            Console.WriteLine("3. feladat: {0}", adatok.Length);
            
            //4. feladat
            Console.WriteLine("4. feladat: Magyar nagydíj helyezései");
            for (int i = 0; i < adatok.Length; i++)
            {
                if (adatok[i].statusz=="Finished" && adatok[i].nagydij== "Hungarian Grand Prix")
                {
                    Console.WriteLine("\t{0}: {1}. hely",adatok[i].datum.ToString("yyyy.MM.dd."),adatok[i].pozicio);
                }
            }

            //5. feladat
            Console.WriteLine("5. feladat: Hibastatisztika");
            List<string> hibak = new List<string>();
            for (int i = 0; i < adatok.Length; i++)
            {
                hibak.Add(adatok[i].statusz);
            }
            List<string> szurthibak = new List<string>();
            szurthibak = hibak.Distinct().ToList();
            int hibadb = 0;
            for (int i = 0; i < szurthibak.Count; i++)
            {
                for (int j = 0; j < hibak.Count; j++)
                {
                    //nem vizsgálja azokat az elemeket ami + jellel kezdődnek vagy a tartalma az lesz hogy Finished
                    if (szurthibak[i]==hibak[j] && szurthibak[i][0]!='+' && szurthibak[i]!="Finished")
                    {
                        hibadb++;
                    }
                }
                if (hibadb>2)
                {
                    Console.WriteLine("\t{0}:{1}",szurthibak[i],hibadb);
                }
                hibadb = 0;
            }

            Console.ReadKey();

        }
    }
}
