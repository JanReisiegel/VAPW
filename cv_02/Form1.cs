using System.Runtime.ExceptionServices;

namespace cv_02
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private Color actualColor;
        A a;// = new A();
        public Form1()
        {
            a = new A();
            a.Cislo = -11;
            int h = a.Cislo;
            InitializeComponent();
            actualColor = panel1.BackColor;
        }

        private void Panel1_Click1(object sender, MouseEventArgs e)
        {
            int red = 0;
            int green = 0;
            int blue = 0;
            int alpha = 0;
            bool first = true;
            while(first || (actualColor == Color.FromArgb(red,green, blue, alpha)))
            {
                first = false;
                red = random.Next(0, 255);
                green = random.Next(0, 255);
                blue = random.Next(0, 255);
                alpha = random.Next(0, 255);
            }
            actualColor = Color.FromArgb(red, green, blue, alpha);
            panel1.BackColor = actualColor;
        }

        /*private void Panel1_Click(object sender, MouseEventArgs e)
        {
            panel1.BackColor = Color.Gold;
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(90, 60, 90);
        }*/
    }
}
