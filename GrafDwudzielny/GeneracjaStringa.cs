using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafDwudzielny
{
    class GeneracjaStringa
    {
        public static Form1 glowna = Form1.getInstance();
        static List<string> listaWierzcholkow = new List<string>();
        static int indexGlowny = 0;
        static int indexitemow = 0;
        static string komenda = "";


        public static string GenerujString()
        {
            string[] tabWierzcholkow = glowna.textBox1.Text.Split(',');
            string[] tabSasiedzi = glowna.textBox2.Text.Split(',');
            komenda = "";

                    foreach (string Wierzcholek in tabWierzcholkow)
                    {
                        sprawdzCzyIstnieje(Wierzcholek);
                        indexGlowny = indexitemow;

                        foreach (string item in tabSasiedzi)
                        {
                            sprawdzCzyIstnieje(item);
                            sprawdzMacierz();
                            Silnik.macierzSasiedztwa[indexGlowny][indexitemow]++;
                        }
                    }
                    for (int i = 0; i < Silnik.macierzSasiedztwa.Count; i++)
                    {
                        for (int j = 0; j < Silnik.macierzSasiedztwa.Count; j++)
                        {
                            for (int k = 0; k < Silnik.macierzSasiedztwa[i][j]; k++)
                            {
                        if (listaWierzcholkow[j] != "")
                        {
                            komenda += " " + listaWierzcholkow[i] + " -> " + listaWierzcholkow[j] + ";";

                        }
                        else
                        {
                            komenda += " " + listaWierzcholkow[i] + ";";
                        }
                  
                            }
                        }
                    }



            if (glowna.checkBox1.Checked==true)
            {
                return "digraph{"+ komenda + "}" ;
            }
            else
            {
                komenda = komenda.Replace("->", "--");
                return "graph{" + komenda + "}";
            }
        }



        static void sprawdzCzyIstnieje(string wierzcholek)
        {
            bool czyIstniejeWierzcholek = false;
            for (int i = 0; i < listaWierzcholkow.Count; i++)
            {
                if (listaWierzcholkow[i] == wierzcholek)
                {
                    czyIstniejeWierzcholek = true;
                    indexitemow = i;
                }
            }
            if (czyIstniejeWierzcholek == false)
            {
                listaWierzcholkow.Add(wierzcholek);
                indexitemow = listaWierzcholkow.Count - 1;
            }
        }
        static void sprawdzMacierz()
        {
            if (listaWierzcholkow.Count != Silnik.macierzSasiedztwa.Count)
            {
                for (int j = Silnik.macierzSasiedztwa.Count; j < listaWierzcholkow.Count; j++)
                {
                    List<int> tymczasowa = new List<int>();
                    for (int i = 0; i < Silnik.macierzSasiedztwa.Count; i++)
                    {
                        Silnik.macierzSasiedztwa[i].Add(0);
                        tymczasowa.Add(0);
                    }
                    tymczasowa.Add(0);
                    Silnik.macierzSasiedztwa.Add(tymczasowa);
                }
            }
        }
    }
}
