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
        static string komenda = "";
        static List<string> listaWierzcholkow = new List<string>();
        static int indexGlowny = 0;
        static int indexitemow = 0;


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GenerujString()
        {
            string[] tabWierzcholkow = glowna.textBox1.Text.Split(',');
            string[] tabSasiedzi = glowna.textBox2.Text.Split(',');
            komenda = "";

            if (glowna.checkBox1.Checked == true)//czy graf skierowany
            {
                komenda += "digraph{";
                if (glowna.textBox1.Text != "" && glowna.textBox2.Text == "")//TU POPRAWIć GDY G SKIEROWANY I DODAJĘ TYLKO WIERZCHOŁEK
                {
                    sprawdzCzyIstnieje(glowna.textBox1.Text);
                    sprawdzMacierz();
                    //foreach (string Wierzcholek in tabWierzcholkow)
                    //{

                    //    indexGlowny = indexitemow;
                    //    sprawdzCzyIstnieje(glowna.textBox1.Text);
                    //    
                    //}
                    komenda += " " + glowna.textBox1.Text + ";";
                }


                else
                {

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
                                komenda += " " + listaWierzcholkow[i] + " -> " + listaWierzcholkow[j] + ";";
                            }
                        }
                    }

                }
            }
            else
            {


                if (glowna.textBox1.Text != "" && glowna.textBox2.Text == "")//TU POPRAWIć GDY G NIESKIEROWANY I DODAJĘ TYLKO WIERZCHOŁEK
                {
                    komenda += "graph{" + glowna.textBox1.Text;
                }



                else
                {
                    komenda += "graph{";

                    foreach (string Wierzcholek in tabWierzcholkow)
                    {
                        sprawdzCzyIstnieje(Wierzcholek);
                        indexGlowny = indexitemow;

                        foreach (string item in tabSasiedzi)
                        {
                            sprawdzCzyIstnieje(item);
                            sprawdzMacierz();
                            Silnik.macierzSasiedztwa[indexGlowny][indexitemow]++;
                            Silnik.macierzSasiedztwa[indexitemow][indexGlowny]++;
                        }
                    }

                    for (int i = 0; i < Silnik.macierzSasiedztwa.Count; i++)
                    {
                        for (int j = i; j < Silnik.macierzSasiedztwa.Count; j++)
                        {
                            for (int k = 0; k < Silnik.macierzSasiedztwa[i][j]; k++)
                            {
                                komenda += " " + listaWierzcholkow[i] + " -- " + listaWierzcholkow[j] + ";";
                            }
                        }
                    }
                }
            }
            komenda += "}";
            return komenda;
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
