using System;
using System.ComponentModel;
using System.Windows.Forms;
using static Ex2.GuessNumberForm;

namespace Ex2
{
    public partial class InputForm : Form
    {
        private Callback _callback = null;
        
        public InputForm(Callback callback)
        {
            _callback = callback;
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(InputBox.Text, out int input))
            {
                _callback(input);
                Hide();
            }
            else
            {
                ErrorLabel.Text = "Введите число!";
                InputBox.Text = "";
            }
        }
    }
}