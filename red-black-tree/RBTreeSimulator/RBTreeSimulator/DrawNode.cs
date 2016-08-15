using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RBTreeSimulator
{
    public class DrawNode
    {
        private int x;
        private int y;
        private int value;

        public DrawNode(int height, int width, int value)
        {
            x = width;
            y = height;
            this.value = value;
        }

        public void Draw(bool colorSelect = true)
        {
            System.Drawing.Graphics G;
            G = Graphics.G;

            Rectangle myRectangle = new Rectangle(x - 15, y - 15, 37, 37);
            if (colorSelect)
            {
                G.FillEllipse(new SolidBrush(Color.Black), myRectangle);
            }
            else
            {
                G.FillEllipse(new SolidBrush(Color.Red), myRectangle);
            }
            Brush brush = new SolidBrush(System.Drawing.Color.White);
            G.DrawString(value.ToString(), new Font("Helvetica", 12, FontStyle.Bold), brush, x - 10, y - 8);
        }
    }
}
