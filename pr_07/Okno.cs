using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr_07
{
    public partial class Okno : Form
    {
        public Okno(string txt)
        {
            InitializeComponent();
            button1.Text = txt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void Okno_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(checkBox1.Checked)
            {
                e.Cancel = true;
            }
            if(checkBox2.Checked)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
            string s = @"C:" + System.IO.Path.DirectorySeparatorChar;
            s += "Users" + System.IO.Path.DirectorySeparatorChar;
        }
    }
}
