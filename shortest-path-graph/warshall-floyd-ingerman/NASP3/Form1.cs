using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NASP3
{
    public partial class Form1 : Form
    {
        public Graphics g;

        public Dictionary<int, Node> listNodes;

        public Form1()
        {
            InitializeComponent();
            listNodes = new Dictionary<int,Node>();
            g = panel1.CreateGraphics();

            Dictionary<int, Edge> dic = new Dictionary<int,Edge>();

            dic.Add(3, new Edge(new Point(40, 240), new Point(100, 240), 6));
            dic.Add(2, new Edge(new Point(40, 240), new Point(100, 120), 2));
            dic.Add(4, new Edge(new Point(40, 240), new Point(150, 360), 12));

            listNodes.Add(1,new Node(1, 0, 220, new Dictionary<int, Edge>(dic), ref g));
            dic.Clear();

            dic.Add(3, new Edge(new Point(120, 140), new Point(120, 220), 3));
            dic.Add(5, new Edge(new Point(140, 120), new Point(200, 120), 9));
            listNodes.Add(2,new Node(2, 100, 100, new Dictionary<int, Edge>(dic), ref g));
            dic.Clear();

            dic.Add(6, new Edge(new Point(140, 240), new Point(200, 240), 1));
            listNodes.Add(3,new Node(3, 100, 220, new Dictionary<int, Edge>(dic), ref g));
            dic.Clear();

            dic.Add(8, new Edge(new Point(190, 360), new Point(300, 240), -2));
            listNodes.Add(4,new Node(4, 150, 340, new Dictionary<int, Edge>(dic), ref g));
            dic.Clear();

            dic.Add(7, new Edge(new Point(240, 120), new Point(300, 120), 1));
            listNodes.Add(5,new Node(5, 200, 100, new Dictionary<int, Edge>(dic), ref g));
            dic.Clear();

            dic.Add(8, new Edge(new Point(240, 240), new Point(300, 240), 4));
            dic.Add(5, new Edge(new Point(220, 220), new Point(220, 140), 2));
            listNodes.Add(6,new Node(6, 200, 220, new Dictionary<int, Edge>(dic), ref g));
            dic.Clear();

            dic.Add(9, new Edge(new Point(340, 120), new Point(400, 120), 2));
            listNodes.Add(7,new Node(7, 300, 100, new Dictionary<int, Edge>(dic), ref g));
            dic.Clear();

            dic.Add(11, new Edge(new Point(340, 240), new Point(500, 240), 1));
            dic.Add(9, new Edge(new Point(340, 240), new Point(400, 120), 3));
            dic.Add(12, new Edge(new Point(340, 240), new Point(500, 360), -3));
            dic.Add(13, new Edge(new Point(340, 240), new Point(500, 480), -2));
            listNodes.Add(8,new Node(8, 300, 220, new Dictionary<int, Edge>(dic), ref g));
            dic.Clear();

            dic.Add(10, new Edge(new Point(440, 120), new Point(500, 120), -1));
            listNodes.Add(9,new Node(9, 400, 100, new Dictionary<int, Edge>(dic), ref g));
            dic.Clear();

            dic.Add(14, new Edge(new Point(540, 120), new Point(600, 120), 5));
            listNodes.Add(10,new Node(10, 500, 100, new Dictionary<int, Edge>(dic), ref g));
            dic.Clear();

            dic.Add(10, new Edge(new Point(520, 220), new Point(520, 140), 2));
            dic.Add(15, new Edge(new Point(540, 240), new Point(600, 240), -9));
            listNodes.Add(11,new Node(11, 500, 220, new Dictionary<int, Edge>(dic), ref g));
            dic.Clear();

            dic.Add(16, new Edge(new Point(540, 360), new Point(600, 360), 7));
            listNodes.Add(12,new Node(12, 500, 340, new Dictionary<int, Edge>(dic), ref g));
            dic.Clear();

            dic.Add(12, new Edge(new Point(520, 460), new Point(520, 380), 2));
            dic.Add(17, new Edge(new Point(540, 480), new Point(600, 480), 2));
            listNodes.Add(13,new Node(13, 500, 460, new Dictionary<int, Edge>(dic), ref g));
            dic.Clear();

            dic.Add(15, new Edge(new Point(620, 140), new Point(620, 220), 2));
            dic.Add(18, new Edge(new Point(640, 120), new Point(750, 240), -9));
            listNodes.Add(14,new Node(14, 600, 100, new Dictionary<int, Edge>(dic), ref g));
            dic.Clear();

            dic.Add(18, new Edge(new Point(640, 240), new Point(750, 240), 11));
            listNodes.Add(15,new Node(15, 600, 220, new Dictionary<int, Edge>(dic), ref g));
            dic.Clear();

            dic.Add(18, new Edge(new Point(640, 360), new Point(750, 240), -6));
            listNodes.Add(16,new Node(16, 600, 340, new Dictionary<int, Edge>(dic), ref g));
            dic.Clear();

            dic.Add(18, new Edge(new Point(640, 480), new Point(750, 240), 3));
            listNodes.Add(17,new Node(17, 600, 460, new Dictionary<int, Edge>(dic), ref g));
            dic.Clear();

            listNodes.Add(18,new Node(18, 750, 220, null, ref g));
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Draw();
        }

        private void Draw()
        {
            foreach (KeyValuePair<int,Node> entry in listNodes)
            {
                entry.Value.DrawNode();
                entry.Value.DrawEdges(0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int num1, num2;
            bool result1 = Int32.TryParse(textBox1.Text, out num1);
            bool result2 = Int32.TryParse(textBox2.Text, out num2);

            if (result1 && result2 && num1 < 19 && num1 > 0 & num2 < 19 && num2 > 0)
            {
                g.Clear(SystemColors.ControlLightLight);

                WFI obj = new WFI();

                obj.Calculate(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));

                int count = obj.numbers.Count;

                string path = "Ne postoji!";
                string distance = "N/A";

                if (count > 0)
                {
                    path = "";
                    for (int i = 0; i < count - 1; i++)
                    {
                        path += obj.numbers[i].ToString() + "->";
                        listNodes[obj.numbers[i]].DrawNode();
                        listNodes[obj.numbers[i]].DrawEdges(obj.numbers[i + 1]);
                    }
                    path += obj.numbers[count - 1].ToString();
                    distance = obj.result.ToString();
                    listNodes[obj.numbers[count - 1]].DrawNode();
                    listNodes[obj.numbers[count - 1]].DrawEdges(0);
                }

                foreach (KeyValuePair<int, Node> entry in listNodes)
                {
                    if (!obj.numbers.Contains(entry.Key))
                    {
                        entry.Value.DrawNode();
                        entry.Value.DrawEdges(0);
                    }
                }

                label5.Text = distance;
                label6.Text = path;
            }
            else
            {
                MessageBox.Show("Invalid input!");
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                Draw();
            }
        }

    }
}
