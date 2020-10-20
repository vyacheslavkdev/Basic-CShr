using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ex3.Service;

namespace Ex3
{
    public partial class QuestionAddForm : Form
    {
        private List<IEventHandler> _handlers = null;

        public QuestionAddForm()
        {
            _handlers = new List<IEventHandler>();
            InitializeComponent();
        }

        public void AddEventHandler(IEventHandler service)
        {
            _handlers.Add(service);
        }

        public void UpdateForm()
        {
            Dispatch(FormEvents.UpdateForm);
        }

        private void FileNewMenuItem_Click(object sender, EventArgs e)
        {
            Dispatch(FormEvents.FileNewMenuClick);
        }

        private void FileOpenMenuItem_Click(object sender, EventArgs e)
        {
            Dispatch(FormEvents.FileOpenMenuClick);
        }

        private void FileMenuSaveItem_Click(object sender, EventArgs e)
        {
            Dispatch(FormEvents.FileSaveMenuClick);
        }
        
        private void FileMenuSaveAsItem_Click(object sender, EventArgs e)
        {
            Dispatch(FormEvents.FileSaveAsMenuClick);
        }

        private void FileMenuExitItem_Click(object sender, EventArgs e)
        {
            Dispatch(FormEvents.FileExitMenuClick);
            Close();
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            Dispatch(FormEvents.AboutMenuClick);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Dispatch(FormEvents.AddButtonClick);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Dispatch(FormEvents.SaveButtonClick);
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Dispatch(FormEvents.QuestNumberChanged);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Dispatch(FormEvents.DeleteButtonClick);
        }

        private void Dispatch(string eventName)
        {
            foreach (IEventHandler service in _handlers)
            {
                service.Handle(eventName);
            }
        }

        public TextBox QuestionTextField
        {
            get => QuestionTextBox;
            set => QuestionTextBox = value;
        }

        public NumericUpDown NumericStepper
        {
            get => NumericUpDown;
            set => NumericUpDown = value;
        }

        public CheckBox IsTrue
        {
            get => IsTrueCheckBox;
            set => IsTrueCheckBox = value;
        }
    }
}