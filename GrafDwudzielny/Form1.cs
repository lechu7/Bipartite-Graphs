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
       
        }

        public static Form1 getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new Form1();

            return INSTANCE;
        }
        private void button1_Click(object sender, EventArgs e)
        {
         //   GeneracjaGrafu.generateGraph("digraph{a -> b; b -> c; c -> a;}");//Ten string będzie edytowany
            bool wynik= Silnik.sprawdz();
          MessageBox.Show(wynik.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = GeneracjaGrafu.generateGraph(GeneracjaStringa.GenerujString());
            checkBox1.Enabled = false;
        }
    }
}
