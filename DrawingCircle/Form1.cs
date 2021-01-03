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
        bool ctrl_key = false;
        List<Circle> list = new List<Circle>();
        Storage<Circle> libr = new Storage<Circle>(50);
        private void unmarkAll()
        {
            for (int i = 0; i < libr._size; i++)
            {
                libr.get_Shape(i).mark = false;

            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < libr._size; i++)
                if (libr.get_Shape(i) != null)
                    libr.get_Shape(i).Draw(e);

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Circle circle = new Circle();
                libr.add(new Circle(e.X - 25, e.Y - 25));
                for (int i = 0; i < libr._size; ++i)
                {
                    Circle circle1 = libr.get_Shape(i);
                    if (circle1.isCircle(e))
                    {
                        unmarkAll();
                    }
                    circle1.mark = (circle1.mark ? false : true);
                    this.Invalidate();
                    return;
                }
                unmarkAll();

                //Circle newCircle = new Circle(e.X, e.Y);
                //libr.add(newCircle);
                this.Invalidate();
            }
            
            
            
            
            //Circle circle = new Circle();
            //libr.add(new Circle(e.X - 25, e.Y - 25));
            //this.Invalidate();
           /* bool flag = true;
            if (!(e.Button == MouseButtons.Left))
            {
                return;
            }
            if (SelectionMode_checkBox.Checked)
            {
                for (int i = (int)libr.get_size() - 1; i >= 0; i--)
                {
                    if (libr.get_Shape(i) == null)
                        continue;

                    if (ctrl_key)
                    {
                        if (libr.get_Shape(i).isCircle(e))
                        {
                            libr.get_Shape(i).mark = !libr.get_Shape(i).mark;
                            break;
                        }
                    }
                    else
                    {
                        if (libr.get_Shape(i).isCircle(e) && flag)
                        {
                            libr.get_Shape(i).mark = true;
                            flag = false;
                        }
                        else
                        {
                            libr.get_Shape(i).mark = false;
                        }
                    }

                }
            }

            else
            {
                for (int i = 0; i < libr.get_num(); i++)
                {
                    if (libr.get_num() == null)
                    {
                        continue;
                    }
                    libr.get_Shape(i).mark = false;
                }

                Circle cCircle = new Circle(e.X - 25, e.Y - 25);

                if (libr.get_num() == libr.get_size())
                {
                    libr.change_size(libr.get_num() + 1);
                }
                libr.adding(cCircle, libr.get_num());
            }
                this.Invalidate();*/
        }
        
        
    
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                ctrl_key = true;
            }

            if (e.KeyCode == Keys.Delete)
            {
                for (int i = 0; i < libr._size; ++i)
                {
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
            public bool mark=false;
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
                if (mark == false)
                {
                    Pen pen = new Pen(Color.Green);
                    e.Graphics.DrawEllipse(pen, _x, _y, _radius * 2, _radius * 2);
                }
                else
                {
                    Pen pen1 = new Pen(Color.Black);
                    e.Graphics.DrawEllipse(pen1, _x, _y, _radius * 2, _radius * 2);
                }
            }
            public bool isCircle(MouseEventArgs e)
            {
                return (((_x - e.X) * (_x - e.X) + (_y - e.Y) * (_y - e.Y) <= _radius * _radius));
            }
        }

     
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
        


