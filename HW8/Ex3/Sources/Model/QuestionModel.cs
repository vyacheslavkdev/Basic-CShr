using System;

namespace Ex3.Model
{
    [Serializable]
    public class QuestionModel
    {
        private string _question;
        private bool _isTrue;

        public QuestionModel()
        {
            _question = "";
            _isTrue = false;
        }

        public QuestionModel(string question, bool isTrue)
        {
            _question = question;
            _isTrue = isTrue;
        }

        public string Question
        {
            get => _question;
            set => _question = value;
        }

        public bool IsTrue
        {
            get => _isTrue;
            set => _isTrue = value;
        }
    }
}