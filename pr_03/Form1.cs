using pr_03_c;

namespace pr_03
{
    public partial class Form1 : Form
    {
        Class1 cl;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Osoba os = new Osoba();
            os.name = cl;
        }
    }
}
