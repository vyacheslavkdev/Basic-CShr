/*
 * Вячеслав Индорил
 * Задача 1
    а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.
    б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок. 
    Игрок должен получить это число за минимальное количество ходов.
    в) *Добавить кнопку «Отменить», которая отменяет последние ходы. Используйте обобщенный класс Stack.
    Вся логика игры должна быть реализована в классе с удвоителем.
 */

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ex1
{
    public static class MultiplierWork
    {
        public delegate void Function();

        private static Stack<Function> _steps = new Stack<Function>();

        private static MultiplierForm _form = null;
        private static int _number = 0;
        private static int _currentNumber = 1;
        private static int _stepsCount = 0;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _form = new MultiplierForm(Plus, Mult, Revert, Play);
            SetGameGoal();
            Application.Run(_form);
        }

        private static void SetGameGoal()
        {
            Random rnd = new Random();
            _number = rnd.Next(10, 100);
            _form.GameGoalLabel.Text = $"Цель игры получить число {_number}";
            UpdateCurrentNumberLabel();
        }

        private static void UpdateCurrentNumberLabel()
        {
            _form.CurrentNumberLabel.Text = $"Текущее число {_currentNumber}";
        }

        private static void CheckWin()
        {
            if (_number == _currentNumber)
            {
                _form.GameGoalLabel.Text = $"Победа! Количество шагов = {_stepsCount}";
                _form.SwitchButtons(false);
                _steps.Clear();
            }
            else if (_number < _currentNumber)
            {
                _form.GameGoalLabel.Text = "Вы проиграли!";
                _form.SwitchButtons(false);
                _steps.Clear();
            }
        }

        private static void Plus()
        {
            _currentNumber++;
            _steps.Push(RevertPlus);
            _stepsCount++;
            UpdateCurrentNumberLabel();
            CheckWin();
        }

        private static void RevertPlus()
        {
            _currentNumber--;
            _stepsCount++;
            UpdateCurrentNumberLabel();
            CheckWin();
        }

        private static void Mult()
        {
            _currentNumber *= 2;
            _stepsCount++;
            _steps.Push(RevertMult);
            UpdateCurrentNumberLabel();
            CheckWin();
        }

        private static void RevertMult()
        {
            _currentNumber /= 2;
            _stepsCount++;
            UpdateCurrentNumberLabel();
            CheckWin();
        }

        private static void Revert()
        {
            if (_steps.Count == 0)
            {
                return;
            }

            object function = _steps.Pop();
            ((Function) function)();
        }

        private static void Play()
        {
            SetGameGoal();
            _currentNumber = 1;
            _stepsCount = 0;
            _steps.Clear();
            _form.SwitchButtons(true);
            UpdateCurrentNumberLabel();
        }
    }
}