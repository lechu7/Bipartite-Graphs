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
        static List<int> Puste = new List<int>();

    

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
                            if (indexGlowny != indexitemow)
                            {

                                Silnik.macierzSasiedztwa[indexGlowny][indexitemow]++;
                            }
                        }
                    }
                    for (int i = 0; i < Silnik.macierzSasiedztwa.Count; i++)
                    {
                        for (int j = 0; j < Silnik.macierzSasiedztwa.Count; j++)
                        {
                            for (int k = 0; k < Silnik.macierzSasiedztwa[i][j]; k++)
                            {
                                    komenda += " " + listaWierzcholkow[i] + " -> " + listaWierzcholkow[j] + ";";                  
                            }
                        }
                    }
                    for (int m = 0; m < Puste.Count; m++)
                    {
                        komenda += " " + listaWierzcholkow[Puste[m]] + ";";
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
            if (wierzcholek != "")
            {
                bool czyIstniejeWierzcholek = false;
                for (int i = 0; i < listaWierzcholkow.Count; i++)
                {
                    if (listaWierzcholkow[i] == wierzcholek)
                    {
                        for (int m = 0; m < Puste.Count; m++)
                        {
                            if (Puste[m]==i)
                            {
                                Puste.RemoveAt(m);
                                break;
                            }
                        }
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
            else
            {
                Puste.Add(indexitemow);
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
