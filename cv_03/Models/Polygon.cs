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

        public Polygon(List<Point> points) : base((int)points.Average(p => p.X), (int)points.Average(p => p.Y))
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

        /* Metody pro získání středových souřadnic tvaru
        public Polygon(List<Point> points) : base(GetOX(points), GetOY(points))
        {
            this.points = points;
        }
        
        private static int GetOX(List<Point> points)
        {
            int sumX = 0;
            int n = points.Count;

            for (int i = 0; i < n; i++)
            {
                sumX += points[i].X;
            }

            return (sumX / n);
        }
        private static int GetOY(List<Point> points)
        {
            int sumY = 0;
            int n = points.Count;

            for (int i = 0; i < n; i++)
            {
                sumY += points[i].Y;
            }

            return (sumY / n);
        }*/

        internal override void Draw(Graphics graphics)
        {
            base.DrawPoint(graphics);
            graphics.DrawPolygon(Pen, points.ToArray());
        }
    }
}
