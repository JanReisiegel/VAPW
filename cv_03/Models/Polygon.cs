using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv_03.Models
{
    internal class Polygon : Geometry
    {
        private List<Point> points = new List<Point>();
        public List<Point> Points
        {
            get { return points; }
            set { points = value; }
        }

        public Polygon(List<Point> points) : base((int)points.Average(p => p.X), (int)points.Average(p => p.Y), false)
        {
            points.ForEach(p => this.points.Add(p));
        }
        public Polygon(List<Point> points, System.Drawing.Pen pen) : this(points)
        {
            Pen = pen;
        }
        public Polygon(List<Point> points, System.Drawing.Color penColor, int penWidth) 
            : this(points, new System.Drawing.Pen(penColor, penWidth)) { }
        public Polygon(List<Point> points, System.Drawing.Pen pen, System.Drawing.Color fillColor)
            : this(points, pen)
        {
            FillColor = fillColor;
        }
        public Polygon(List<Point> points, System.Drawing.Color penColor, int penWidth, System.Drawing.Color fillColor)
            : this(points, new System.Drawing.Pen(penColor, penWidth), fillColor) { }
        internal override void Draw(Graphics graphics)
        {
            base.Draw(graphics);

            graphics.DrawPolygon(Pen, points.ToArray());
        }
        internal override void DrawHover(Graphics graphics)
        {
            Pen pen = new Pen(System.Drawing.Color.Gray, 1);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            var ltx = points.Min(p => p.X);
            var lty = points.Min(p => p.Y);
            var rbx = points.Max(p => p.X);
            var rby = points.Max(p => p.Y);
            graphics.DrawRectangle(pen, ltx - 2 - Pen.Width, lty - 2 - Pen.Width, rbx - ltx + 4 + (Pen.Width * 2), rby - lty + 4 + (Pen.Width * 2));
        }

        internal override void MoveTo(Point point)
        {
            points.ForEach(p =>
            {
                p.X += point.X - OX;
                p.Y += point.Y - OY;
            });
            base.MoveTo(point);
        }
    }
}
