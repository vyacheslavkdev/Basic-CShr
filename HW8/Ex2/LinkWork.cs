/*
 * Вячеслав Индорил
 * Задача 2
    Создайте простую форму на котором свяжите свойство Text элемента 
    TextBox со свойством Value элемента NumericUpDown
 */

using System;
using System.Windows.Forms;

namespace Ex2
{
    static class LinkWork
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LinkForm());
        }
    }
}