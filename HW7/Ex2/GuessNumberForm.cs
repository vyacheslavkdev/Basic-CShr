using System;
using System.Windows.Forms;

namespace Ex2
{
    public partial class GuessNumberForm : Form
    {
        public delegate void Callback(int input);

        private int _number = 0;
        private int _input = 0;

        public GuessNumberForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            InitGame();
        }

        private void InitGame()
        {
            Random rnd = new Random();
            _number = rnd.Next(1, 101);
            GameLabel.Text = "Угадайте число от 1 до 100";
        }

        private void UpdateGame()
        {
            if (_number == _input)
            {
                GameLabel.Text = $"Вы угадали, это число {_number}";
            }
            else if (_number > _input)
            {
                GameLabel.Text = $"Правильное число больше {_input}";
            }
            else
            {
                GameLabel.Text = $"Правильное число меньше {_input}";
            }
        }

        private void GuessButton_Click(object sender, EventArgs e)
        {
            InputForm inputForm = new InputForm(InputCallback);
            inputForm.StartPosition = FormStartPosition.CenterScreen;
            inputForm.TopMost = true;
            inputForm.Show();
        }

        private void InputCallback(int input)
        {
            _input = input;
            UpdateGame();
        }
    }
}