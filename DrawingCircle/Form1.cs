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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Circle> list = new List<Circle>();
        Storage<Circle> libr = new Storage<Circle>(50);

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < libr._size; i++)
                if (libr.get_Shape(i) != null)
                    libr.get_Shape(i).Draw(e);
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Circle circle = new Circle();
            libr.add(new Circle(e.X - 25, e.Y - 25));
            this.Invalidate();
            //if ((e.Button == MouseButtons.Right) && (circle.isCircle(e)==true))
            

        }
        public class Circle
        {
            public int _radius=25;
            public int _x;
            public int _y;
            public Circle()
            {
            }
            public Circle( int x, int y)
            {
                _x = x;
                _y = y;
            }
            public int get_x()
            {
                return _x;
            }
            public int get_y()
            {
                return _y;
            }
            public void Draw(PaintEventArgs e)
            {
                Pen pen = new Pen(Color.Green);
                e.Graphics.DrawEllipse(pen, _x, _y, _radius * 2, _radius * 2);
            }
            public bool isCircle(MouseEventArgs e)
            {
                return (((_x - e.X) * (_x - e.X) + (_y - e.Y) * (_y - e.Y) <= _radius * _radius));
            }
        }
    }
}
