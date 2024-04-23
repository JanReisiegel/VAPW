namespace pr_08
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }
        List<Form> forms = new List<Form>();
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.MdiParent = this;
            f2.Show();
            forms.Add(f2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.LayoutMdi(MdiLayout.TileVertical);
        }
    }
}
