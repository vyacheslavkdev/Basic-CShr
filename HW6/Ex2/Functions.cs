/*
 * Вячеслав Индорил
 * Задача 2
    Модифицировать программу нахождения минимума функции так, чтобы можно 
    было передавать функцию в виде делегата. 
    а) Сделать меню с различными функциями и представить пользователю выбор, 
    для какой функции и на каком отрезке находить минимум. Использовать массив (или список) 
    делегатов, в котором хранятся различные функции.
    б) *Переделать функцию Load, чтобы она возвращала массив считанных значений. 
    Пусть она возвращает минимум через параметр (с использованием модификатора out). 
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace Ex2
{
    class Functions
    {
        private const string FileName = "../../result.bin";

        public delegate double Function(double x);

        private static List<Function> _functions = new List<Function>() {F, Sqr, Sqrt, Sin};

        private static int _funcChoice = 0;
        private static double _a = 0;
        private static double _b = 0;
        private static double _step = 0;

        static void Main(string[] args)
        {
            if (!Init())
            {
                Console.WriteLine("Ошибка ввода!");
                return;
            }

            GenerateFunctionResultFile(_functions[_funcChoice - 1], _a, _b, _step);
            double[] fileData = GetMinFromResultFile(out double min);

            Console.WriteLine($"Минимум функции на отрезке [{_a}:{_b}] = {min}");
        }

        private static bool Init()
        {
            Console.Write("Выберите функцию: ");
            foreach (Function function in _functions)
            {
                Console.WriteLine($"{_functions.IndexOf(function) + 1}) {function.Method.Name}");
            }

            string functionInput = Console.ReadLine();
            bool parseFuncInput = int.TryParse(functionInput, out _funcChoice);
            if (!parseFuncInput || _funcChoice <= 0 || _funcChoice > _functions.Count)
            {
                return false;
            }

            Console.WriteLine("Ведите нижнее и верхнее значение Х и шаг изменения Х через пробел");
            string dataInput = Console.ReadLine();
            if (dataInput == null)
            {
                return false;
            }

            string[] split = dataInput.Replace(".", ",").Split(" ");
            if (split.Length < 3 ||
                !double.TryParse(split[0], out _a)
                || !double.TryParse(split[1], out _b)
                || !double.TryParse(split[2], out _step))
            {
                return false;
            }

            return true;
        }

        public static void GenerateFunctionResultFile(Function f, double a, double b, double step)
        {
            FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(f(x));
                x += step;
            }

            bw.Close();
            fs.Close();
        }

        public static double[] GetMinFromResultFile(out double min)
        {
            FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            long elementsCount = fs.Length / sizeof(double);
            double[] res = new double[elementsCount];
            min = double.MaxValue;
            double d;
            for (int i = 0; i < elementsCount; i++)
            {
                d = bw.ReadDouble();
                res[i] = d;
                if (d < min)
                {
                    min = d;
                }
            }

            bw.Close();
            fs.Close();
            return res;
        }

        static double F(double x)
        {
            return x * x - 50 * x + 10;
        }

        static double Sqr(double x)
        {
            return x * x;
        }

        static double Sqrt(double x)
        {
            return x > 0 ? Math.Sqrt(x) : 0;
        }

        static double Sin(double x)
        {
            return Math.Sin(x);
        }
    }
}