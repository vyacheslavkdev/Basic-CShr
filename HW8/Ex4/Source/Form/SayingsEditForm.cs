using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Ex4.Callback;

namespace Ex4
{
    public partial class SayingsEditForm : Form
    {
        public const string SaveSayingEvent = "saveSaying";
        public const string ClearSayingEvent = "clearSaying";

        private EventObject _eventObject = null;
        private FormCallback _formCallback = null;
        

        public SayingsEditForm(FormCallback formCallback)
        {
            _formCallback = formCallback;
            InitializeComponent();
        }

        private void SplitButton_Click(object sender, EventArgs e)
        {
            string text = InputBox.Text;
            string pattern = @"(\,\s)";
            Regex regex = new Regex(pattern);
            string[] split = regex.Split(text);
            if (split.Length < 3)
            {
                ResultLabel.Text = "Неудалось разбить поговорку на две части.";
                return;
            }

            _eventObject = new EventObject(split[0], split[2]);
            ResultLabel.Text = $"{split[0]}\n{split[2]}";
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            InputBox.Text = "";
            _formCallback(SaveSayingEvent, _eventObject);
        }

        private void ClearMenuItem_Click(object sender, EventArgs e)
        {
            _formCallback(ClearSayingEvent);
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
        }

        public class EventObject
        {
            private string _firstPart;
            private string _lastPart;

            public EventObject(string firstPart, string lastPart)
            {
                _firstPart = firstPart;
                _lastPart = lastPart;
            }

            public string FirstPart => _firstPart;

            public string LastPart => _lastPart;
        }
    }
}