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
            label5.Visible = false;

            checkBox1.Checked = true;
        }

        public static Form1 getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new Form1();

            return INSTANCE;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            label5.Visible = true;
            bool wynik = Silnik.sprawdz();
            switch (wynik)
            {
                case true:
                    label5.ForeColor = Color.Green;
                    label5.Text = "Podany graf jest bigrafem.";
                    break;
                case false:
                    label5.ForeColor = Color.Red;
                    label5.Text = "Podany graf nie jest bigrafem.";
                    break;
                default:
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                button1.Enabled = true;
                pictureBox1.Image = GeneracjaGrafu.generateGraph(GeneracjaStringa.GenerujString());
                textBox1.Text = "";
                textBox2.Text = "";
                checkBox1.Enabled = false;
                label5.Visible = false;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Czxy chcesz wyczyścic macierz?", "Czyszczenie", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                button1.Enabled = false;
                label5.Visible = false;
                checkBox1.Enabled = true;
                checkBox1.Checked = false;
                textBox1.Text = "";
                textBox2.Text = "";
                pictureBox1.Image = null;
                Silnik.macierzSasiedztwa = new List<List<int>>();
            }


        }

    }
}
