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
    abstract public class Shape: IShapeDraw
    {
        public int _side=50;
        protected int _x;
        protected int _y;
        public bool mark = true;
        public Pen _color;
        
        public Shape()
        {        
        }

        public Shape(int x, int y, Pen color)
        {
            _x = x;
            _y = y;
            _color = color;
            
        }
        
        virtual public void MoveOn(int dx, int dy, int maxX, int minX, int maxY, int minY)
        {
            if (InWorkspace(maxX - dx, minX - dx, maxY - dy, minY - dy))
            {
                _x += dx;
                _y += dy;
            }
        }

        public Shape create_Shape(string code, int x, int y, Pen color)
        {
            Shape key = null;
            if (code == "круг")
            {
                key = new Circle(x, y, color);

            }
            if (code == "квадрат")
            {
                key = new Square(x, y, color);

            }
            if (code == "треугольник")
            {
                key = new Triangle(x, y, color);

            }
            return key;
        }

        abstract public void Draw(Graphics graphics);
        abstract public bool isIn(int x, int y);
        public bool InWorkspace(int maxX, int minX, int maxY, int minY)
        {
            return
                (_x+_side/2< maxX) &&
                (_x - _side/2> minX) &&
                (_y+ _side/2 < maxY) &&
                (_y - _side/2> minY);
        }

        abstract public void resize(int dsize, int maxX, int minX, int maxY, int minY);
       //{
            /*if((this._side + dsize > 0) )
            {
                this._side = (this._side + dsize);
            }*/
       //}
    }
}
