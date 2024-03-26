﻿using System;
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

        public Circle(int ox, int oy, int radius) : base(ox, oy, false)
        {
            _radius = radius;
        }

        public Circle(int ox, int oy, int radius, System.Drawing.Pen pen) : this(ox, oy, radius)
        {
            Pen = pen;
        }

        public Circle(int ox, int oy, int radius, System.Drawing.Color penColor, int penWidth)
            : this(ox, oy, radius, new Pen(penColor, penWidth)) { }
        public Circle(int ox, int oy, int radius, Pen pen, System.Drawing.Color fillColor)
            : this(ox, oy, radius, pen)
        {
            FillColor = fillColor;
        }

        public Circle(int ox, int oy, int radius, System.Drawing.Color penColor, int penWidth, Color fillColor)
    : this(ox, oy, radius, new Pen(penColor, 1)) { }
        internal override void Draw(Graphics graphics)
        {
            base.Draw(graphics);
            this.DrawOrigin(graphics);
        }
        internal override void DrawOrigin(Graphics graphics)
        {
			graphics.DrawEllipse(Pen, OX - Radius, OY - Radius, 2 * Radius, 2 * Radius);
        }

        internal override void DrawHover(Graphics graphics)
        {
            this.DrawOrigin(graphics);
            Pen pen = new Pen(System.Drawing.Color.Red, 10);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            graphics.DrawRectangle(pen, OX - Radius, OY - Radius, 2 * Radius, 2 * Radius);
        }
    }
}
