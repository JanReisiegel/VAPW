using System;
using System.Collections.Generic;
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

        protected Geometry(int ox, int oy)
        {
            _ox = ox;
            _oy = oy;
        }

        internal abstract void Draw(System.Drawing.Graphics graphics);
        internal void DrawPoint(System.Drawing.Graphics graphics)
        {
            Pen pen = new Pen(System.Drawing.Color.Red, 1);
            graphics.DrawLine(pen, OX, OY - 5, OX, OY + 5);
            graphics.DrawLine(pen, OX - 5, OY, OX + 5, OY);
        }
    }
}
