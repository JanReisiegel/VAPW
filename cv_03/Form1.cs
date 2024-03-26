using cv_03.Models;
using Rectangle = cv_03.Models.Rectangle;

namespace cv_03
{
    public partial class Form1 : Form
    {
        List<Geometry> geometries = new List<Geometry>();
        List<Point> points = new List<Point>();
        Pen pen = new Pen(Color.Black, 1);
        Geometry? selectedGeometry = null;
        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] { nameof(Circle), nameof(Rectangle), nameof(Polygon) });

        }

        private void button1_Click(object sender, EventArgs e)
        {

            geometries.Add(new Circle(100, 80, 25));
            geometries.Add(new Circle(150, 220, 50));
            geometries.Add(new Rectangle(50, 50, 100, 100));
            geometries.Add(new Rectangle(200, 200, 300, 300));
            geometries.Add(new Polygon(new List<Point> { new Point(100, 100), new Point(200, 100), new Point(150, 200), new Point(200, 200) }));
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            geometries.ForEach(g => g.DrawOrigin(e.Graphics));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(geometries.Count() != 0)
            {
                foreach (var g in geometries)
                {
                    if (e.Location.X >= g.OX - 10 && e.Location.X <= g.OX + 10 && e.Location.Y <= g.OY +10 && e.Location.Y >= g.OY - 10)
                    {
                        selectedGeometry = g;
                        break;
                    }
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                points.Add(e.Location);
            }
            if (points.Count == 2 && comboBox1.SelectedItem != null)
            {
                if (comboBox1.SelectedItem.ToString() == nameof(Circle))
                {
                    geometries.Add(new Circle(points[0].X, points[0].Y,
                        (int)Math.Sqrt(Math.Pow(points[1].X - points[0].X, 2) + Math.Pow(points[1].Y - points[0].Y, 2)), new Pen(panel1.BackColor, (int)numericUpDown1.Value)));
                    points.Clear();
                    Invalidate();
                }
                else if (comboBox1.SelectedItem.ToString() == nameof(Rectangle))
                {
                    geometries.Add(new Rectangle(points[0].X, points[0].Y, points[1].X, points[1].Y, new Pen(panel1.BackColor, (int)numericUpDown1.Value)));
                    points.Clear();
                    Invalidate();
                }
            }
            else if (points.Count > 2
                && e.Button == MouseButtons.Right
                && comboBox1.SelectedItem != null
                && comboBox1.SelectedItem.ToString() == nameof(Polygon))
            {
                geometries.Add(new Polygon(points, new Pen(panel1.BackColor, (int)numericUpDown1.Value)));
                points.Clear();
                Invalidate();
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            points.Clear();
            Invalidate();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            var dialog = colorDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                panel1.BackColor = colorDialog1.Color;
            }
        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            if (selectedGeometry != null)
            {
                selectedGeometry.MoveTo(e.Location);
            }
            else
            {
                foreach (var g in geometries)
                {
                    var isNear = (e.Location.X >= g.OX - 10 && e.Location.X <= g.OX + 10 && e.Location.Y >= g.OY - 10 && e.Location.Y <= g.OY + 10);
                    g.Selected = isNear;

                }
            }
            Invalidate();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            selectedGeometry = null;
        }
    }
}
