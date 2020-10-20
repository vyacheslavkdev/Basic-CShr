/*
 * Вячеслав Индорил
 * Задача 4
    *Используя полученные знания и класс TrueFalse в качестве шаблона, разработать
    собственную утилиту хранения данных (Например: Дни рождения, Траты, Напоминалка,
    Английские слова и другие).
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex4.Model;
using Ex4.Service;

namespace Ex4
{
    static class Sayings
    {
        private static SayingsShowForm _showForm = null;
        private static SayingsEditForm _editForm = null;

        private static FileService _fileService = null;
        
        private static SayingsModel _sayings = null;
            
        [STAThread]
        static void Main()
        {
            Init();
            ShowForm();
        }

        private static void Init()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            _fileService = new FileService();
            _sayings = _fileService.Load();
            
            _showForm = new SayingsShowForm(Callback, _sayings);
        }

        private static void ShowForm()
        {
            if (_showForm == null)
            {
                return;
            }

            Application.Run(_showForm);
        }

        private static void ShowEditor()
        {
            if (_editForm == null)
            {
                _editForm = new SayingsEditForm(Callback);
            }

            _editForm.ShowDialog();
        }

        private static void SaveSaying(object data)
        {
            if (data is SayingsEditForm.EventObject)
            {
                _sayings.AddItem((data as SayingsEditForm.EventObject).FirstPart, 
                    (data as SayingsEditForm.EventObject).LastPart);
                _fileService.Save(_sayings);
            }
        }

        private static void ClearSayings()
        {
            _sayings = _fileService.InitSayings();
        }

        private static void Callback(string eventName, object data = null)
        {
            if (eventName == SayingsShowForm.ShowEditorEvent)
            {
                ShowEditor();
            } else if (eventName == SayingsEditForm.SaveSayingEvent)
            {
                SaveSaying(data);
            } else if (eventName == SayingsEditForm.ClearSayingEvent)
            {
                ClearSayings();
            }
        }
    }
}