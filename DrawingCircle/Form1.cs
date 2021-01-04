using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingCircle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool ctrl_key = false;
        //List<Circle> list = new List<Circle>();
        Storage<Circle> libr = new Storage<Circle>(3);
        //bool create;
        private void unmarkAll()
        {
            for (int i = 0; i < libr._size; i++)
            {
               if (libr.get_Shape(i) != null)
                    libr.get_Shape(i).mark = false;

            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < libr._size; i++)
            {
                if (libr.get_Shape(i) == null)
                {
                    continue;
                }
                libr.get_Shape(i).Draw(e);
            }
        }
       
        

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
             {
                 for (int i = 0; i != libr.get_size(); ++i)
                 {
                    //libr.get_Shape(i);
                    if (libr.get_Shape(i) == null)
                    {
                        continue;
                    }
                    if (libr.get_Shape(i).isCircle(e))
                    {
                        if (!ctrl_key)
                        {
                           unmarkAll();
                        }

                        libr.get_Shape(i).mark = (libr.get_Shape(i).mark ? false : true);
                        this.Invalidate();
                        return;
                    }

                }
                 unmarkAll();
                 Circle newCircle = new Circle(e.X, e.Y);
                 libr.add(newCircle);
                 this.Invalidate();
             }

        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                ctrl_key = false;
            }

            if (e.KeyCode == Keys.Delete)
            {
                for (int i = 0; i != libr.get_size(); ++i)
                {
                    if (libr.get_Shape(i) == null)
                    {
                        continue;
                    }

                    if ((libr.get_Shape(i).mark))
                    {
                        libr.delete_Shape(i);
                    }
                }
                this.Invalidate();
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            ctrl_key = false;
        }

        public class Circle
        {
            public int _radius=25;
            public int _x;
            public int _y;
            public bool mark=true;
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
                Pen pen1 = new Pen(Brushes.Black, 2);
                Pen pen = new Pen(Brushes.Green, 2);
                e.Graphics.DrawEllipse((mark ? pen : pen1), (_x - 25), (_y - 25), 2 * 25, 2 * 25);
                e.Graphics.FillEllipse(Brushes.White, (_x - 25), (_y - 25), 2 * 25, 2 * 25);
            }
            public bool isCircle(MouseEventArgs e)
            {
                return (((_x - e.X) * (_x - e.X) + (_y - e.Y) * (_y - e.Y) <= _radius * _radius));
            }
        }      
    }
}
        


