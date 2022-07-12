using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace DrawingCircle
{
    public class Circle : Shape, IShapeDraw
    {
        new public int _side = 60;
     
        public Circle(int x, int y, Pen color) : base(x, y, color)
        {

        }

       
        public override void Draw(Graphics graphics)
        {
            Pen pen1 = new Pen(Color.Black, 3);
         
            Rectangle rect = new Rectangle(
                    (int)(_x - _side/2),
                    (int)(_y - _side/2),
                    (int)(_side ),
                    (int)(_side));

            graphics.FillEllipse(Brushes.White, rect);
            graphics.DrawEllipse(_color, rect);

            if (!mark)
            {
                return;
            }
            graphics.DrawEllipse(new Pen(Brushes.Black, 3), rect);
        }
        override public void resize(int dsize, int maxX, int minX, int maxY, int minY)
        {
            if ((_side + dsize > 0)& (InWorkspace(maxX - _side/2, minX - _side/2, maxY - _side/2, minY - _side/2)))
            {
                _side = (this._side + dsize);
            }
        }
        public override bool isIn(int x, int y)
        {
            return (((_x - x) * (_x - x) + (_y - y) * (_y - y) <= _side * _side/4));
        }
    }

}
