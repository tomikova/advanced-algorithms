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
    public class Graphics
    {
        const int radius = 37;
        public static int widthPanel;
        public static System.Drawing.Graphics G = null;

        public static void DrawTree(Node node, int level, int y, int x)
        {
            if (node == null) { return; }
            int width;
            width = (int)widthPanel / (int)Math.Pow(2, (double)level);
            node.Graph = new DrawNode(y, x, node.value);
            Pen myPen = new Pen(System.Drawing.Color.Blue, 2);
            if (node.leftChild != null)
            {
                G.DrawLine(myPen, new Point(x, y), new Point(x - width / 2, y + radius + 30));
                DrawTree(node.leftChild, level + 1, y + radius + 30, x - width / 2);
            }
            if (node.rightChild != null)
            {
                G.DrawLine(myPen, new Point(x, y), new Point(x + width / 2, y + radius + 30));
                DrawTree(node.rightChild, level + 1, y + radius + 30, x + width / 2);
            }
            if (node.color == "R")
            {
                node.Graph.Draw(false);
            }
            else
            {
                node.Graph.Draw();
            }
        }

        public static void Clear()
        {
            if (G != null)
            {
                G.Clear(SystemColors.ControlLightLight);
            }
        }
    }
}
