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
        Shape key;
        Pen color;
        Storage<Shape> libr = new Storage<Shape>(2);

        /*delegate void PressKeyDelegate(Storage<Shape> shapes);

        delegate void PressKeyDelegate2(int d);
        delegate void constructor();
        */

        private void unmarkAll()
        {
            for (int i = 0; i < libr._size; i++)
            {
               if (libr.get_Shape(i) != null)
                    libr.get_Shape(i).mark = false;
            }
            
        }

        const int delta = 5;
        /* Dictionary<Keys, (int dx, int dy)> KeysDxDy_Dictionary = new Dictionary<Keys, (int, int)>
        {
            [Keys.D] = (delta, 0),
            [Keys.A] = (-delta, 0),
            [Keys.S] = (0, delta),
            [Keys.W] = (0, -delta),
        };*/


       public void add(Storage<Shape> shapes)
        {
            for (int i = 0; i < shapes.get_size(); i++)
            {
                if (shapes.get_Shape(i) != null && shapes.get_Shape(i).mark)
                {
                   shapes.get_Shape(i).resize(1, pictureBox1.Width, 0, pictureBox1.Height, 0);
                }
            }
        }
        public void sub(Storage<Shape> shapes)
        {
            for (int i = 0; i < shapes.get_size(); i++)
            {
                if (shapes.get_Shape(i) != null && shapes.get_Shape(i).mark)
                {
                    shapes.get_Shape(i).resize(-1, pictureBox1.Width, 0, pictureBox1.Height, 0);
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

      /*  Dictionary<Keys, PressKeyDelegate> KeyDelegate_Dictionary = new Dictionary<Keys, PressKeyDelegate>
        {
            [Keys.Q] = add,
            [Keys.E] = sub,
            [Keys.Delete] = del
        };*/

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            ctrl_key = e.Control;
            Keys key = e.KeyCode;
            int dx=0, dy=0;
            //int res = 0;
            if (key == Keys.E)
                add(libr);
            if (e.KeyCode == Keys.Q)
                sub(libr);

            if (e.KeyCode == Keys.S)
                dy=dy+10;
            if (e.KeyCode == Keys.W)
                dy=dy-10;
            if (e.KeyCode == Keys.D)
                dx=dx+10;
            if (e.KeyCode == Keys.A)
                dx=dx-10;

            for (int i = 0; i< libr.get_size(); i++)
            {
                if (libr.get_Shape(i) != null && libr.get_Shape(i).mark)
                {                   
                    libr.get_Shape(i).MoveOn(
                        dx, dy,
                        pictureBox1.Width,
                        0,
                        pictureBox1.Height,
                        0);
                    
                }
            }
            if (e.KeyCode == Keys.Delete)
            {
                del(libr);
            }
            ctrl_key = e.Control;        
            pictureBox1.Invalidate();
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            ctrl_key = false;
        }

        public virtual Shape create_Shape(string code, int x, int y, Pen color) { return null; }



        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                 for (int i = libr.get_size()-1; i >-1; i--)
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
                         }
                         libr.get_Shape(i).mark = !libr.get_Shape(i).mark;
                         pictureBox1.Invalidate();                     
                         return;                      
                     }
                 }
                unmarkAll();
                if (comboColor.Text== ""){
                    MessageBox.Show("введите все поля");
                    return;
                }
                color = new Pen(Color.FromName((string)comboColor.SelectedItem));
                if ((string)comboShape.SelectedItem == "круг")
                {
                    key = new Circle(e.X, e.Y, color);
                }
                else if ((string)comboShape.SelectedItem == "квадрат")
                {
                    key = new Square(e.X, e.Y, color);
                }
                else if ((string)comboShape.SelectedItem == "треугольник")
                {
                    key = new Triangle(e.X, e.Y, color);
                }

                libr.add(key);
                pictureBox1.Invalidate();               
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            for (int i = 0; i < libr.get_size(); i++)
            {
                if (libr.get_Shape(i) != null && (!libr.get_Shape(i).mark/* || libr.get_Shape(i).mark*/))
                {
                    libr.get_Shape(i).Draw(e.Graphics);
                }
            }
           for (int i = 0; i < libr.get_size(); i++)
            {
                if (libr.get_Shape(i) != null && libr.get_Shape(i).mark)
                {
                    libr.get_Shape(i).Draw(e.Graphics);
                }
            }
        }             
    }
}
        


