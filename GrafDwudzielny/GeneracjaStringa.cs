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
        static string pamiec = "";
       public static List<string> listaWierzcholkow = new List<string>();
       static int indexGlowny = 0;
       static int indexitemow = 0;


        public static string GenerujString()
        {
            string [] tabSasiedzi = glowna.textBox2.Text.Split(',');
            komenda = "";

            if (glowna.checkBox1.Checked == true)//czy graf skierowany
            {
                komenda += "digraph{";

                sprawdzCzyIstnieje(glowna.textBox1.Text);
                indexGlowny = indexitemow;

                komenda += pamiec;
                foreach (string item in tabSasiedzi)
                {
                    sprawdzCzyIstnieje(item);
                    sprawdzMacierz();
                    Silnik.macierzSasiedztwa[indexGlowny][indexitemow]++;
                  komenda += " "+glowna.textBox1.Text +" -> "+item+";";
                    pamiec += " " + glowna.textBox1.Text + " -> " + item + ";";
                }

            }

            else
            {
                komenda += "graph{";

                sprawdzCzyIstnieje(glowna.textBox1.Text);
                indexGlowny = indexitemow;

                komenda += pamiec;
                foreach (string item in tabSasiedzi)
                {
                    sprawdzCzyIstnieje(item);
                    sprawdzMacierz();
                    Silnik.macierzSasiedztwa[indexGlowny][indexitemow]++;
                    Silnik.macierzSasiedztwa[indexitemow][indexGlowny]++;
                    komenda += " " + glowna.textBox1.Text + " -- " + item + ";";
                    pamiec += " " + glowna.textBox1.Text + " -- " + item + ";";
                }
            }

            komenda += "}";
            pamiec += glowna.textBox1.Text + ";";
            return komenda;
        }
      static  void sprawdzCzyIstnieje(string wierzcholek)
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
             //   komenda += glowna.textBox1.Text + ";";
                listaWierzcholkow.Add(wierzcholek);
                indexitemow = listaWierzcholkow.Count-1;
            }
        }
      static void sprawdzMacierz()
      {
          if (listaWierzcholkow.Count!=Silnik.macierzSasiedztwa.Count)
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
