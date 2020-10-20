using System.Collections.Generic;

namespace Ex3.Model
{
    public class QuestionsModel
    {
        private string _fileName;
        private List<QuestionModel> _questions;

        public QuestionsModel(string fileName)
        {
            _fileName = fileName;
            _questions = new List<QuestionModel>();
            _questions.Add(new QuestionModel());
        }

        public QuestionsModel(string fileName, List<QuestionModel> questions)
        {
            _fileName = fileName;
            _questions = questions;
        }

        public string FileName
        {
            get => _fileName;
            set => _fileName = value;
        }

        public List<QuestionModel> Questions
        {
            get => _questions;
            set => _questions = value;
        }

        public void Add(QuestionModel question)
        {
            if (_questions != null && question != null)
            {
                _questions.Add(question);
            }
        }

        public void Update(int index, QuestionModel question)
        {
            _questions[index] = question;
        }

        public void Delete(int index)
        {
            if (_questions == null)
            {
                return;
            }

            if (index >= 0 && index < _questions.Count)
            {
                _questions.RemoveAt(index);
            }

            if (_questions.Count == 0)
            {
                _questions.Add(new QuestionModel());
            }
        }

        public QuestionModel this[int index]
        {
            get { return _questions[index]; }
        }

        public int Count => _questions.Count;

        public bool LastIsEmpty => _questions.Count <= 0 || _questions[_questions.Count - 1].Question.Equals("");

        public int IndexOf(QuestionModel question) => _questions.IndexOf(question);
    }
}