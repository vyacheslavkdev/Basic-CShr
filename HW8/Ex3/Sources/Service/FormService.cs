using System.Collections.Generic;
using Ex3.Model;
using Ex3.Sources.Config;

namespace Ex3.Service
{
    public class FormService : IEventHandler
    {
        private Dictionary<string, HandleFunction> _functions = null;

        public FormService()
        {
            _functions = new Dictionary<string, HandleFunction>();
            _functions.Add(FormEvents.AddButtonClick, OnAddButtonClick);
            _functions.Add(FormEvents.SaveButtonClick, OnSaveButtonClick);
            _functions.Add(FormEvents.DeleteButtonClick, OnDeleteButtonClick);
            _functions.Add(FormEvents.QuestNumberChanged, OnQuestNumberChange);
            _functions.Add(FormEvents.AboutMenuClick, OnAboutClick);
            _functions.Add(FormEvents.UpdateForm, OnUpdateFormEvent);
        }

        private void OnAddButtonClick()
        {
            if (!HasQuestions)
            {
                return;
            }

            if (Questions.LastIsEmpty)
            {
                SetFormQuestionNumber(Questions.Count - 1);
                return;
            }

            QuestionModel question = new QuestionModel();
            Questions.Add(question);
            SetFormQuestionNumber(Questions.IndexOf(question));
        }

        private void OnSaveButtonClick()
        {
            if (!HasQuestions)
            {
                return;
            }

            int index = GetFormQuestionNumber();
            QuestionModel question = Questions[index];
            question.Question = GetFormQuestionText();
            question.IsTrue = GetFromIsChecked();
            Questions.Update(index, question);
        }

        private void OnDeleteButtonClick()
        {
            if (!HasQuestions)
            {
                return;
            }

            int index = GetFormQuestionNumber();
            if (!IsIndexValid(index))
            {
                return;
            }

            Questions.Delete(index);

            if (index > 0)
            {
                SetFormQuestionNumber(index - 1);
                return;
            }

            if (HasQuestions)
            {
                FillFormByQuestion(Questions[index]);
            }
            else
            {
                ClearQuestionForm();
            }
        }

        private void OnQuestNumberChange()
        {
            UpdateForm();
        }

        private void OnAboutClick()
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.AboutTextLabel.Text = $"{Context.GetInstance().Config.Author}" +
                                            $"\n{Context.GetInstance().Config.Version}";
            aboutForm.ShowDialog();
        }

        private void OnUpdateFormEvent()
        {
            UpdateForm();
        }

        private void UpdateForm()
        {
            if (!HasQuestions)
            {
                return;
            }

            if (!IsIndexValid(GetFormQuestionNumber()))
            {
                SetFormQuestionNumber(Questions.Count - 1);
                return;
            }

            int questionNumber = GetFormQuestionNumber();
            QuestionModel question = Questions[questionNumber];
            if (question == null)
            {
                return;
            }

            FillFormByQuestion(question);
        }

        private void FillFormByQuestion(QuestionModel question)
        {
            SetFormQuestionText(question.Question);
            SetFromIsChecked(question.IsTrue);
        }

        private void ClearQuestionForm()
        {
            FillFormByQuestion(new QuestionModel());
        }

        private bool HasQuestions => Questions != null && Questions.Count > 0;

        private bool IsIndexValid(int index)
        {
            return index >= 0 && index < Questions.Count;
        }

        private void SetFormQuestionText(string text)
        {
            QuestionForm.QuestionTextField.Text = text;
        }

        private string GetFormQuestionText()
        {
            return QuestionForm.QuestionTextField.Text;
        }

        private void SetFromIsChecked(bool isChecked)
        {
            QuestionForm.IsTrue.Checked = isChecked;
        }

        private bool GetFromIsChecked()
        {
            return QuestionForm.IsTrue.Checked;
        }

        private void SetFormQuestionNumber(int number)
        {
            QuestionForm.NumericStepper.Value = number + 1;
        }

        private int GetFormQuestionNumber()
        {
            return (int) QuestionForm.NumericStepper.Value - 1;
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