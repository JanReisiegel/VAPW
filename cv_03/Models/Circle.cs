using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv_03.Models
{
    internal class Circle : Geometry
    {
		private int _radius;
		public int Radius
		{
			get { return _radius; }
			private set { _radius = value; }
		}

        public Circle(int ox, int oy, int radius) : base(ox, oy)
        {
            //OX = ox;
            //OY = oy;
            _radius = radius;
        }

        internal override void Draw(Graphics graphics)
        {
			graphics.DrawEllipse(new Pen(Color.Aqua, 15), OX - Radius, OY - Radius, 2 * Radius, 2 * Radius);
        }
    }
}
