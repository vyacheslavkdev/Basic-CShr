using System;
using System.Windows.Forms;
using static Ex1.MultiplierWork;

namespace Ex1
{
    public partial class MultiplierForm : Form
    {
        private Function _plusCallback = null;
        private Function _multCallback = null;
        private Function _revertCallback = null;
        private Function _playCallback = null;

        public MultiplierForm(Function plusCallback, Function multCallback, Function revertCallback,
            Function playCallback)
        {
            _plusCallback = plusCallback;
            _multCallback = multCallback;
            _revertCallback = revertCallback;
            _playCallback = playCallback;

            InitializeComponent();
        }

        public void SwitchButtons(bool enable)
        {
            PlusButton.Enabled = enable;
            MultButton.Enabled = enable;
            RevertButton.Enabled = enable;
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            _plusCallback();
        }

        private void MultButton_Click(object sender, EventArgs e)
        {
            _multCallback();
        }

        private void RevertButton_Click(object sender, EventArgs e)
        {
            _revertCallback();
        }

        private void PlayMenuItem_Click(object sender, EventArgs e)
        {
            _playCallback();
        }
    }
}