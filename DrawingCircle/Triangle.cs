using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Windows.Forms;


namespace DrawingCircle
{
    public class Triangle: Shape, IShapeDraw
    {
        private const int E = 1;
        new public int _side=60;
        Point[] vertices = new Point[3];
       
        public Triangle(int x, int y, Pen color) : base(x, y, color)
        {

        }
        public int get_side()
        {
            return _side;
        }
        public override void Draw(Graphics graphics)
        {
            var dx = (int)(0.5 * _side);
            var dy = (int)(_y + 2 * Math.Sqrt(3) * _side / 10);

            vertices[0] = new Point(_x, (int)(_y - 3 * Math.Sqrt(3) * _side / 10));
            vertices[1] = new Point(_x - dx, dy);
            vertices[2] = new Point(_x + dx, dy);

            graphics.FillPolygon(Brushes.White, vertices);

            

            Pen pen1 = new Pen(Brushes.Black, 3);
            graphics.DrawLines((mark ? pen1 : _color), vertices);
            graphics.DrawLine((mark ? pen1 : _color), vertices[2], vertices[0]);
        }

        public override bool isIn(int x, int y)
        {
             double ABCSquare = square(vertices[0], vertices[1], vertices[2]);
             Point[] vert = new Point[1];
             vert[0] = new Point(x, y);
             double ABDSquare = square(vert[0], vertices[1], vertices[2]);
             double BCDSquare = square(vertices[0], vert[0], vertices[2]);
             double CADSquare = square(vertices[0], vertices[1], vert[0]);

             return
                 ABCSquare + E >= ABDSquare + BCDSquare + CADSquare &&
                 ABCSquare - E <= ABDSquare + BCDSquare + CADSquare;
        }
        override public void resize(int dsize, int maxX, int minX, int maxY, int minY)
        {
            if (_side + dsize > 0)
            {
                if ((_side + dsize > 0) & (InWorkspace(maxX - _side / 2, minX - _side / 2, maxY - _side / 2, minY - _side / 2)))
                {
                    _side = (this._side + dsize);
                }
            }
        }
        private double distance(Point a, Point b)
        {
            return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));

        }
        private double square(Point a, Point b, Point c)
        {
            double ab = distance(a, b);
            double ac = distance(a, c);
            double cb = distance(c, b);

            double p = (ab + ac + cb) / 2;
            double square = Math.Sqrt((p - ab) * (p - ac) * (p - cb) * p);
            return square;
        }
    }
}
