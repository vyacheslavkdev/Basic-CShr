using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Ex3.Model;
using Ex3.Sources.Config;

namespace Ex3.Service
{
    public class FileService : IEventHandler
    {
        private const string ConfigPath = "../../config.xml";
        private Dictionary<string, HandleFunction> _functions = null;

        public FileService()
        {
            _functions = new Dictionary<string, HandleFunction>();
            _functions.Add(FormEvents.FileOpenMenuClick, OnFileOpenClick);
            _functions.Add(FormEvents.FileNewMenuClick, OnFileNewClick);
            _functions.Add(FormEvents.FileSaveMenuClick, OnFileSaveClick);
            _functions.Add(FormEvents.FileSaveAsMenuClick, OnFileSaveAsClick);
        }
        
        public bool InitConfig()
        {
            try
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(ConfigModel));
                Stream fStream = new FileStream(ConfigPath, FileMode.Open, FileAccess.Read);
                ConfigModel configModel = (ConfigModel) xmlFormat.Deserialize(fStream);
                fStream.Close();

                Context.GetInstance().Config = configModel;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        private void OnFileOpenClick()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                List<QuestionModel> questions = Load(fileName);
                Context.GetInstance().UpdateQuestions(new QuestionsModel(fileName, questions));
                QuestionForm.UpdateForm();
            }
        }

        private void OnFileNewClick()
        {
            Context.GetInstance().UpdateQuestions(null);
            Context.GetInstance().GetQuestionsModel();
            QuestionForm.UpdateForm();
        }

        private void OnFileSaveClick()
        {
            if (Questions != null)
            {
                Save(Questions.FileName, Questions.Questions);
            }
        }

        private void OnFileSaveAsClick()
        {
            if (Questions != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                DialogResult dialogResult = saveFileDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;
                    List<QuestionModel> questions = Questions.Questions;
                    Context.GetInstance().UpdateQuestions(new QuestionsModel(fileName, questions));
                    Save(Questions.FileName, Questions.Questions);
                }
            }
        }

        private void Save(string fileName, List<QuestionModel> questions)
        {
            try
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<QuestionModel>));
                Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                xmlFormat.Serialize(fStream, questions);
                fStream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private List<QuestionModel> Load(string fileName)
        {
            try
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<QuestionModel>));
                Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                List<QuestionModel> questions = (List<QuestionModel>) xmlFormat.Deserialize(fStream);
                fStream.Close();
                return questions;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        private QuestionsModel Questions => Context.GetInstance().GetQuestionsModel();

        private QuestionAddForm QuestionForm => Context.GetInstance().GetQuestionAddForm();

        public void Handle(string eventName)
        {
            foreach (string key in _functions.Keys)
            {
                if (key == eventName && _functions.TryGetValue(key, out HandleFunction function))
                {
                    function();
                }
            }
        }
    }
}