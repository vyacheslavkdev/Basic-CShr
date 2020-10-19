/*
 * Вячеслав Индорил
 * Задача 3
    а) Создать приложение, показанное на уроке, добавив в него защиту от 
    возможных ошибок (не создана база данных, обращение к несуществующему 
    вопросу, открытие слишком большого файла и т.д.).
    б) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов 
    и добавив другие «косметические» улучшения на свое усмотрение.
    в) Добавить в приложение меню «О программе» с информацией о программе 
    (автор, версия, авторские права и др.).
    г)* Добавить пункт меню Save As, в котором можно выбрать имя для 
    сохранения базы данных (элемент SaveFileDialog).
 */

using System;
using System.Windows.Forms;
using Ex3.Service;

namespace Ex3
{
    public static class BelieveOrNotBelieveEditor
    {
        [STAThread]
        static void Main()
        {
            if (!Context.GetInstance().GetFileService().InitConfig())
            {
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StartApplication();
        }

        private static void StartApplication()
        {
            QuestionAddForm questionAddForm = Context.GetInstance().GetQuestionAddForm();
            questionAddForm.AddEventHandler(Context.GetInstance().GEtFormService());
            questionAddForm.AddEventHandler(Context.GetInstance().GetFileService());
            Application.Run(questionAddForm);
        }
    }
}