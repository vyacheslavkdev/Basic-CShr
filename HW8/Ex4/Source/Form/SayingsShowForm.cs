using System;
using System.Windows.Forms;
using Ex4.Callback;
using Ex4.Model;

namespace Ex4
{
    public partial class SayingsShowForm : Form
    {
        public const string ShowEditorEvent = "showEditorEvent";
        
        private FormCallback _callback;
        private SayingsModel _sayings;
        
        public SayingsShowForm(FormCallback formCallback, SayingsModel sayings)
        {
            _callback = formCallback;
            _sayings = sayings;
            InitializeComponent();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            SayingLabel.Text = _sayings.GetSaying();
        }

        private void EditorMenuItem_Click(object sender, EventArgs e)
        {
            _callback(ShowEditorEvent);
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}