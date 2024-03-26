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

        public Rectangle(int x1, int y1, int x2, int y2) :base((x1 + x2) / 2, (y2 + y1) / 2, false)
        {
			_width = Math.Abs(x2 - x1);
			_height = Math.Abs(y2 - y1);
        }
        public Rectangle(int x1, int y1, int x2, int y2, System.Drawing.Pen pen) : this(x1, y1, x2, y2)
        {
            Pen = pen;
        }
        public Rectangle(int x1, int y1, int x2, int y2, System.Drawing.Color penColor, int penWidth)
            : this(x1, y1, x2, y2, new System.Drawing.Pen(penColor, penWidth)) { }
        public Rectangle(int x1, int y1, int x2, int y2, System.Drawing.Pen pen, System.Drawing.Color fillColor)
            : this(x1, y1, x2, y2, pen)
        {
            FillColor = fillColor;
        }
        public Rectangle(int x1, int y1, int x2, int y2, System.Drawing.Color penColor, int penWidth, System.Drawing.Color fillColor)
            : this(x1, y1, x2, y2, new System.Drawing.Pen(penColor, penWidth), fillColor) { }

		internal override void DrawOrigin(Graphics graphics)
		{
			graphics.DrawRectangle(Pen, OX - Width / 2, OY - Height / 2, Width, Height);
		}
        internal override void Draw(Graphics graphics)
        {
            base.Draw(graphics);

            this.DrawOrigin(graphics);
        }
        internal override void DrawHover(Graphics graphics)
        {
            Pen pen = new Pen(System.Drawing.Color.Red, 1);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            graphics.DrawRectangle(pen, (OX - Width / 2) - 2, (OY - Height / 2) - 2, Width + 2, Height + 2);
        }
    }
}
