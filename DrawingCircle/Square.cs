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
    public class Square: Shape, IShapeDraw
    {
        new public int _side=60;
        public Square() : base ()
        {

        }
        public Square(int x,int y , Pen color) : base(x, y, color)
        {
            
        }
        override public void resize(int dsize, int maxX, int minX, int maxY, int minY)
        {
            if ((_side + dsize > 0)&(InWorkspace(maxX - _side, minX - _side, maxY - _side, minY - _side)))
            {
                _side = (this._side + dsize);
            }
        }
        public int get_side()
        {
            return _side;
        }
        public override void Draw(Graphics graphics)
        {
            Pen pen1 = new Pen(Color.Black, 2);
         
            Rectangle rect = new Rectangle(
                     (_x-_side / 2),
                     (_y - _side / 2),
                     _side,
                     _side);

            graphics.FillRectangle(Brushes.White, rect);

           // graphics.DrawRectangle(pen, rect);
            graphics.DrawRectangle((mark ?  pen1: _color),  rect);
        }

       
        public override bool isIn(int x, int y)
        {
            return Math.Abs(_x - x) * 2 < _side && Math.Abs(_y - y) * 2 < _side;
        }
    }
}