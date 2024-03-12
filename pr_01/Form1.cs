namespace pr_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Button button2 = new Button();
        int x = 10;
        private void button1_Click(object sender, EventArgs e)
        {
            Button button2 = new Button();
            button2.Location = new Point(x, 10);
            x += 100;
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 0;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2_Click;
            Controls.Add(button2);
        }

        private void Button2_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Blby dotaz", "???", MessageBoxButtons.CancelTryContinue);
        }
    }
}
