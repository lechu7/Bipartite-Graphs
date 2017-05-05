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
        static List<string> listaWierzcholkow = new List<string>();


        public static string GenerujString()
        {
            string [] tabSasiedzi = glowna.textBox2.Text.Split(',');
            komenda = "";

            if (glowna.checkBox1.Checked == true)//czy graf skierowany
            {
                komenda += "digraph{";
                bool czyIstniejeWierzcholek = false;
                for (int i = 0; i < listaWierzcholkow.Count; i++)
                {
                    if (listaWierzcholkow[i]==glowna.textBox1.Text)
                    {
                        czyIstniejeWierzcholek = true;
                    }
                }
                if (czyIstniejeWierzcholek == false)
                {
                    komenda+= glowna.textBox1.Text + ";";
                }

                listaWierzcholkow.Add(glowna.textBox1.Text);


                komenda += pamiec;
                foreach (string item in tabSasiedzi)
                {
                    listaWierzcholkow.Add(item);
                  komenda += " "+glowna.textBox1.Text +" -> "+item+";";
                    pamiec += " " + glowna.textBox1.Text + " -> " + item + ";";
                }

            }

            else
            {
                komenda += "graph{";       
                    bool czyIstniejeWierzcholek = false;
                for (int i = 0; i < listaWierzcholkow.Count; i++)
                {
                    if (listaWierzcholkow[i] == glowna.textBox1.Text)
                    {
                        czyIstniejeWierzcholek = true;
                    }
                }
                if (czyIstniejeWierzcholek == false)
                {
                    komenda += glowna.textBox1.Text + ";";
                }

                listaWierzcholkow.Add(glowna.textBox1.Text);

                komenda += pamiec;
                foreach (string item in tabSasiedzi)
                {
                    listaWierzcholkow.Add(item);
                    komenda += " " + glowna.textBox1.Text + " -- " + item + ";";
                    pamiec += " " + glowna.textBox1.Text + " -- " + item + ";";
                }
            }

            komenda += "}";
            pamiec += glowna.textBox1.Text + ";";
            return komenda;
        }
    }
}
