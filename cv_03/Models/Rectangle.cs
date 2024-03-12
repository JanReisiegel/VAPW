using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv_03.Models
{
    internal class Rectangle : Geometry
    {

		private int _width;

		public int Width
		{
			get { return _width; }
			set { _width = value; }
		}

        private int _height;

        public int Height
        {
            get { return _width; }
            set { _width = value; }
        }

        public Rectangle(int x1, int y1, int x2, int y2) :base((x1 + x2) / 2, (y2 + y1) / 2)
        {
			//OX = (x1 + x2) / 2;
			//OY = (y2 + y1) / 2;
			_width = Math.Abs(x2 - x1);
			_height = Math.Abs(y2 - y1);
        }

		internal override void Draw(Graphics graphics)
		{
			var pen = new Pen(Color.Lime, 15);
			graphics.DrawRectangle(pen, OX - Width / 2, OY - Height / 2, Width, Height);
		}
    }
}
