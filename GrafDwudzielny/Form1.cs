using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrafDwudzielny
{
    public partial class Form1 : Form
    {
        public static Form1 INSTANCE;
       private Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

        }

        public static Form1 getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new Form1();

            return INSTANCE;
        }

        private void button1_Click(object sender, EventArgs e)//DO EDYCJI ŻEBY SAMO SIĘ ROBIŁO CO DODANIE CZEGOŚ  // nie jestem pewnien czy to dobry pomysł
        {//BEZ WYSKAKUJĄCYCH OKIENEK TYLKO LABEL DODAć. //Popieram, to było tylko tymczasowe rozwiązanie ;)
          bool wynik= Silnik.sprawdz();
          MessageBox.Show(wynik.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = GeneracjaGrafu.generateGraph(GeneracjaStringa.GenerujString());
            textBox1.Text = "";
            textBox2.Text = "";
            checkBox1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Czyszczenie dopisz swoje RAFAŁ


            checkBox1.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            pictureBox1.Image = null;
            Silnik.macierzSasiedztwa = new List<List<int>>();
        }
    }
}
