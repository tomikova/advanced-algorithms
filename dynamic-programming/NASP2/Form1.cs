using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NASP2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<Monitor> listMonitor = new List<Monitor>();
        public List<CPU> listCPU = new List<CPU>();
        public List<GCard> listGCard = new List<GCard>();
        public List<HardDisk> listHardDisk = new List<HardDisk>();

        Dynamic dynamicObj = null;

        private void button1_Click(object sender, EventArgs e)
        {
            KomponenteForm forma = new KomponenteForm(this);
            forma.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dynamicObj == null)
            {
                dynamicObj = new Dynamic((int)numericUpDown1.Value);
            }
            else
            {
                dynamicObj.budget = (int)numericUpDown1.Value;
                dynamicObj.totalValue = 0;
                dynamicObj.totalCost = 0;
                dynamicObj.bestChoice.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dynamicObj != null)
            {
                foreach (Komponenta komp1 in listMonitor)
                {
                    foreach (Komponenta komp2 in listCPU)
                    {
                        foreach (Komponenta komp3 in listGCard)
                        {
                            foreach (Komponenta komp4 in listHardDisk)
                            {
                                dynamicObj.Calculate(komp1, komp2, komp3, komp4);                            
                            }
                        }
                    }
                }

                string output = "Najbolji odabir: \n\n";

                foreach (Komponenta k in dynamicObj.bestChoice)
                {
                    output += "Naziv: " + k.naziv + "\n";
                    output += "Vrijednost: " + k.vrijednost.ToString() + "\n";
                    output += "Cijena: " + k.cijena.ToString() + "\n\n";
                }
                output += "Ukupna vrijednost: " + dynamicObj.totalValue.ToString() + "\n";
                output += "Ukupna potrošnja: " + dynamicObj.totalCost.ToString();

                MessageBox.Show(output);
            }
        }
    }
}
