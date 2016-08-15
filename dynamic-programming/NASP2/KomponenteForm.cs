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
    public partial class KomponenteForm : Form
    {
        Form1 homeForm;
        public KomponenteForm(Form1 homeForm)
        {
            InitializeComponent();
            this.homeForm = homeForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Monitor":
                    Monitor monitor = new Monitor(textBox1.Text, (int)numericUpDown1.Value, (int)numericUpDown2.Value);
                    homeForm.listMonitor.Add(monitor);
                    break;
                case "Procesor":
                    CPU cpu = new CPU(textBox1.Text, (int)numericUpDown1.Value, (int)numericUpDown2.Value);
                    homeForm.listCPU.Add(cpu);
                    break;
                case "Grafička kartica":
                    GCard graficka = new GCard(textBox1.Text, (int)numericUpDown1.Value, (int)numericUpDown2.Value);
                    homeForm.listGCard.Add(graficka);
                    break;
                case "Tvrdi disk":
                   HardDisk disk = new HardDisk(textBox1.Text, (int)numericUpDown1.Value, (int)numericUpDown2.Value);
                   homeForm.listHardDisk.Add(disk); 
                   break;
                default:
                    break;
            }
        }
    }
}
