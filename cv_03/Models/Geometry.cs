using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv_03.Models
{
    public abstract class Geometry
    {
        private int _ox;
        public int OX
        {
            get { return _ox; }
            protected set { _ox = value; }
        }

        private int _oy;
        public int OY
        {
            get { return _oy; }
            protected set { _oy = value; }
        }

        private Pen _pen = new Pen(Color.Black, 1);
        protected Pen Pen
        {
            get { return _pen; }
            set { _pen = value; }
        } 

        private Color _fillColor = Color.White;
        protected Color FillColor
        {
            get { return _fillColor; }
            set { _fillColor = value; }
        }


        protected Geometry(int ox, int oy)
        {
            _ox = ox;
            _oy = oy;
        }

        internal abstract void Draw(System.Drawing.Graphics graphics);
        internal void DrawPoint(System.Drawing.Graphics graphics)
        {
            Pen pen = new Pen(Color.Black, 1);
            graphics.DrawLine(pen, OX, OY - 5, OX, OY + 5);
            graphics.DrawLine(pen, OX - 5, OY, OX + 5, OY);
        }
    }
}
