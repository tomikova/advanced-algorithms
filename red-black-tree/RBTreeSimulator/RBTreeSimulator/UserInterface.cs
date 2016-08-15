using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RBTreeSimulator
{
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
        }

        static Node root = null;
        
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                string[] numbers = sr.ReadLine().Split(' ');
                sr.Close();
                foreach (string number in numbers)
                {
                    int _number;
                    bool isNumber = Int32.TryParse(number, out _number);
                    if (!isNumber)
                    {
                        MessageBox.Show("'" + number + "' is not a number!");
                    }
                    else if (_number < 0)
                    {
                        MessageBox.Show("Number " + _number + " is not natural!");
                    }
                    else
                    {
                        Core.AddNode(_number, ref root);
                    }              
                }
                if (Graphics.G == null)
                {
                    Graphics.G = panel1.CreateGraphics();
                    Graphics.widthPanel = panel1.Width;
                }
                Graphics.Clear();
                Graphics.DrawTree(root, 1, 75, panel1.Width / 2);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Graphics.G == null)
            {
                Graphics.G = panel1.CreateGraphics();
                Graphics.widthPanel = panel1.Width;
            }
            int _number;
            bool isNumber = Int32.TryParse(textBox1.Text, out _number);
            if (!isNumber)
            {
                MessageBox.Show("'" + textBox1.Text + "' is not a number!");
            }
            else if (_number < 0)
            {
                MessageBox.Show("Number " + _number + " is not natural!");
            }
            else
            {
                Core.AddNode(_number, ref root);
                Graphics.Clear();
                Graphics.DrawTree(root, 1, 75, panel1.Width / 2);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Graphics.G != null)
            {
                Graphics.Clear();
                root = null;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int _number;
            bool isNumber = Int32.TryParse(textBox1.Text, out _number);
            if (!isNumber)
            {
                MessageBox.Show("'" + textBox1.Text + "' is not a number!");
            }
            else if (_number < 0)
            {
                MessageBox.Show("Number " + _number + " is not natural!");
            }
            else
            {
                Core.DeleteNode(_number, ref root);
                Graphics.Clear();
                Graphics.DrawTree(root, 1, 75, panel1.Width / 2);
            }
        }

        private void UserInterface_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                Graphics.Clear();
                Graphics.DrawTree(root, 1, 75, panel1.Width / 2);
            }
        }             
    }
}
