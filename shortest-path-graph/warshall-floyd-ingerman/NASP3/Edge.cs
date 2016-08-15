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
    public class Edge
    {
        public int value;
        public Point start;
        public Point end;

        public Edge(Point _start, Point _end, int _value)
        {
            this.start = _start;
            this.end = _end;
            this.value = _value;
        }

        public void Draw(Pen myPen, ref Graphics g)
        {
            g.DrawLine(myPen, start, end);
        }
    }
}
