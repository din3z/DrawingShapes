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
        
        Bitmap bitmap;
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(624, 384);
            graphics = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;

        }
        Graphics graphics;
        bool ctrl_key = false;
        Shape key;
        Pen color;
        Storage<Shape> libr = new Storage<Shape>(0);
        delegate void PressKeyDelegate(Storage<Shape> shapes);

        delegate void PressKeyDelegate2(int d);
        delegate void constructor();


        private void unmarkAll()
        {
            for (int i = 0; i < libr._size; i++)
            {
               if (libr.get_Shape(i) != null)
                    libr.get_Shape(i).mark = false;
            }
            
        }

        const int displacement = 10;
        Dictionary<Keys, (int dx, int dy)> KeysDxDy_Dictionary = new Dictionary<Keys, (int, int)>
        {
            [Keys.D] = (displacement, 0),
            [Keys.A] = (-displacement, 0),
            [Keys.S] = (0, displacement),
            [Keys.W] = (0, -displacement),
        };
        static void add(Storage<Shape> shapes)
        {
            for (int i = 0; i < shapes.get_size(); i++)
            {
                if (shapes.get_Shape(i) != null && shapes.get_Shape(i).mark)
                {
                   shapes.get_Shape(i).resizeOn(1);
                }
            }
        }
        static void sub(Storage<Shape> shapes)
        {
            for (int i = 0; i < shapes.get_size(); i++)
            {
                if (shapes.get_Shape(i) != null && shapes.get_Shape(i).mark)
                {
                    shapes.get_Shape(i).resizeOn(-1);
                }
            }
        }
        static void del(Storage<Shape> shapes)
        {
            for (int i = 0; i < shapes.get_size(); i++)
            {
                if (shapes.get_Shape(i) != null && shapes.get_Shape(i).mark)
                {
                    shapes.delete_Shape(i);
                }
            }
        }
        Dictionary<Keys, PressKeyDelegate> KeyDelegate_Dictionary = new Dictionary<Keys, PressKeyDelegate>
        {
            [Keys.L] = add,
            [Keys.R] = sub,
            [Keys.Delete] = del
        };

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            ctrl_key = e.Control;
            Keys key = e.KeyCode;

            if (KeysDxDy_Dictionary.TryGetValue(key, out (int dx, int dy) displacement))
            {
                for (int i = 0; i < libr.get_size(); i++)
                {

                    if (libr.get_Shape(i) != null && libr.get_Shape(i).mark)
                    {
                        libr.get_Shape(i).MoveOn(
                            displacement.dx, displacement.dy,
                            pictureBox1.Width,
                            0,
                            pictureBox1.Height,
                            0);
                    }
                }
            }

            if (KeyDelegate_Dictionary.TryGetValue(key, out PressKeyDelegate handler))
            {
                handler(libr);
            }

            pictureBox1.Invalidate();
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            ctrl_key = false;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
          
            if (e.Button == MouseButtons.Left)
            {
                 for (int i = 0; i != libr.get_size(); ++i)
                 {
                    
                     if (libr.get_Shape(i) == null)
                     {
                         continue;
                     }
                     if (libr.get_Shape(i).isIn(e.X, e.Y))
                     {
                         if (!ctrl_key)
                         {
                             unmarkAll();
                            //break;
                         }
                         libr.get_Shape(i).mark = !libr.get_Shape(i).mark;
                         pictureBox1.Invalidate();
                     
                         return;
                      
                     }

                 }
                unmarkAll();
                if ((string)comboColor.SelectedItem == "зеленый")
                {
                    color = new Pen(Color.Green);
                }
                if ((string)comboColor.SelectedItem == "красный")
                {
                    color = new Pen(Color.Red);
                }
                if ((string)comboColor.SelectedItem == "синий")
                {
                    color = new Pen(Color.Blue);
                }
                if ((string)comboShape.SelectedItem == "круг")
                {
                    key = new Circle(e.X, e.Y, color);
                }
                if ((string)comboShape.SelectedItem == "квадрат")
                {
                    key = new Square(e.X, e.Y, color);
                }
                if ((string)comboShape.SelectedItem == "треугольник")
                {
                    key = new Triangle(e.X, e.Y, color);
                }

                libr.add(key);
                pictureBox1.Invalidate();
               
            }

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            graphics.Clear(Color.White);
            for (int i = 0; i < libr._size; i++)
            {
                if (libr.get_Shape(i) != null)
                {
                    libr.get_Shape(i).Draw(graphics);
                }
                pictureBox1.Image = bitmap;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

    }
}
        


