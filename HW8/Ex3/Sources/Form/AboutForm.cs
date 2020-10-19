using System.Windows.Forms;

namespace Ex3
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        public Label AboutTextLabel
        {
            get => AboutLabel;
            set => AboutLabel = value;
        }
    }
}