namespace pr_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Text = "???";
            label1.Visible = !label1.Visible;
            label1.Location = new Point(label1.Location.X + 10, label1.Location.Y);
            label1.Size = new Size(20, 20);

            if (checkBox1.Checked)
            {
                label1.Enabled = false;
            }
            else
            {
                label1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkBox1.CheckState = CheckState.Indeterminate; //tøetí stav checkboxu
            int a = (int)numericUpDown1.Value;
            //..
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            this.Text = str;
            double a;
            if (double.TryParse(str, out a) == false)
            {
                this.Text = ($"oprav vstup: {str} není èíslo!!");
            }//statická promìnná
            else
            {
                a = Math.Sqrt(1 + (a * a));
                label1.Text = $"výsledek: {a}";
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
