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
    interface IShapeDraw
    {
        void MoveOn(int dx, int dy, int maxX, int minX, int maxY, int minY);
        void Draw(Graphics graphics);

    }
}
