using Ex3.Model;
using Ex3.Sources.Config;

namespace Ex3.Service
{
    public class Context
    {
        private const string DefaultDir = "../../";
        private const string DefaultFileName = "questions.xml";
        
        private static Context _instance = null;

        private static ConfigModel _config = null;

        private static FileService _fileService = null;
        private static FormService _formService = null;

        private static QuestionAddForm _questionAddForm = null;
        private static QuestionsModel _questions = null;

        static Context()
        {
        }

        public static Context GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Context();
            }

            return _instance;
        }

        public ConfigModel Config
        {
            get => _config;
            set => _config = value;
        }

        public FileService GetFileService()
        {
            if (_fileService == null)
            {
                _fileService = new FileService();
            }

            return _fileService;
        }
        
        public FormService GEtFormService()
        {
            if (_formService == null)
            {
                _formService = new FormService();
            }

            return _formService;
        }

        public QuestionAddForm GetQuestionAddForm()
        {
            if (_questionAddForm == null)
            {
                _questionAddForm = new QuestionAddForm();
            }

            return _questionAddForm;
        }

        public QuestionsModel GetQuestionsModel()
        {
            string defaultFileName = Config.DefaultDir + Config.DefaultFileName;
            if (_questions == null)
            {
                _questions = new QuestionsModel(defaultFileName);
            }

            return _questions;
        }

        public void UpdateQuestions(QuestionsModel questions)
        {
            _questions = questions;
        }
    }
}