using System;
using System.Windows.Forms;

namespace Ex2
{
    public partial class LinkForm : Form
    {
        public LinkForm()
        {
            InitializeComponent();
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            textBox.Text = numericUpDown.Value.ToString();
        }
    }
}