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
    public class Node
    {
        Pen myPen = new Pen(System.Drawing.Color.Blue, 2);
        Pen myPen2 = new Pen(System.Drawing.Color.Red, 2);
        Brush brush = new SolidBrush(System.Drawing.Color.White);
        Brush brush2 = new SolidBrush(System.Drawing.Color.Olive);
        SolidBrush sb = new SolidBrush(Color.Black);
        SolidBrush sb2 = new SolidBrush(Color.Green);
        Graphics g;

        public int number;
        public Dictionary<int, Edge> listEdges;
        public int x, y;

        public Node(int _number, int _x, int _y, Dictionary<int,Edge> _listEdges, ref Graphics _g)
        {
            this.number = _number;
            this.x = _x;
            this.y = _y;
            this.listEdges = _listEdges;
            this.g = _g;
        }

        public void DrawNode()
        {
            g.FillEllipse(sb, new Rectangle(x, y, 40, 40));
            g.DrawString(number.ToString(), new Font("Helvetica", 12, FontStyle.Bold), brush, x+5, y+7);
        }

        public void DrawEdges(int num)
        {
            if (listEdges != null)
            {
                foreach (KeyValuePair<int, Edge> entry in listEdges)
                {
                    if (num == 0 || num != entry.Key)
                    {
                        entry.Value.Draw(myPen, ref g);
                    }
                    else
                    {
                        entry.Value.Draw(myPen2, ref g);
                    }
                    g.FillEllipse(sb2, new Rectangle(entry.Value.end.X - 7, entry.Value.end.Y-7, 10, 10));
                    g.DrawString(entry.Value.value.ToString(), new Font("Helvetica", 12, FontStyle.Bold), brush2, (entry.Value.start.X + entry.Value.end.X) / 2, (entry.Value.start.Y + entry.Value.end.Y) / 2);
                }
            }
        }
    }
}
