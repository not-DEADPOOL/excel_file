using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace aree_verdi
{
    class Program
    {
        struct Verde
        {
            public string tipologia;
            public string denominazione;
            public string settore;
            public bool recintato;
            public bool WC;
            public bool custodito;
            public int superficie;
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("Aree-di-verde-pubblico-nel-territorio-comunale-di-Vicenza.csv");
            string[] linee = new string[300];
            int p = 0,somma =0,n=300,conta_v=0,conta_dcr=0;
            double media;
            while (linee[p]!=null)
            {
                if (p == 0)
                {
                    sr.ReadLine();
                }
                else
                {
                    linee[p] = sr.ReadLine();
                    p++;
                }
            }
            Verde[] Righe = new Verde[300];
            for (int i = 0; i < Righe.Length; i++)
            {
                    Righe[i].tipologia=linee[i].Split(';')[0];
                    Righe[i].denominazione = linee[i].Split(';')[1];
                    Righe[i].settore = linee[i].Split(';')[2];
                    Righe[i].recintato = Convert.ToBoolean(linee[i].Split(';')[3]);
                    Righe[i].WC= Convert.ToBoolean(linee[i].Split(';')[4]);
                    Righe[i].custodito= Convert.ToBoolean(linee[i].Split(';')[5]);
                    Righe[i].superficie = Convert.ToInt32(linee[i].Split(';')[6]); 
            }
            for (int i = 0; i < Righe.Length; i++)
            {
                somma += Righe[i].superficie;
                conta_v += Righe[i].settore == "Infrastrutture - Verde Pubblico" ? 1 : 0;
                conta_dcr += Righe[i].settore == "Infrastrutture - Verde Pubblico" && Righe[i].WC && Righe[i].recintato && Righe[i].custodito ? 1 : 0;
            }
            media = somma / n;
            Console.WriteLine($"La media della sup. e' {media}.");
            Console.WriteLine($"Il num di aree verdi e' {conta_v}.");
            Console.WriteLine(Grande(Righe));
            Console.WriteLine($"Le aree verdi dotate di bagno,custodite e recinto sono {conta_dcr}.");
            Console.ReadKey();
        }

        static string Grande (Verde[] Righe)
        {
            int Massimo = int.MinValue;
            for (int i = 0; i < Righe.Length; i++)
            {
                Massimo = Righe[i].superficie > Massimo ? Righe[i].superficie : Massimo;
            }
            for (int i = 0; i < Righe.Length; i++)
            {
                if (Righe[i].superficie == Massimo)
                {
                    return $"Il parco parco più grande è {Righe[i].denominazione}";
                }
            }
            return "";
        }
    }
}
