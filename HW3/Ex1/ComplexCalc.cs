/*
 * Вячеслав Индорил
 
 1)а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры.
   б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.
   в) Добавить диалог с использованием switch демонстрирующий работу класса.
 */

using System;

namespace Ex1
{
    class Complex
    {
        private double _re;
        private double _im;

        public Complex()
        {
            _re = 0;
            _im = 0;
        }

        public Complex(double re, double im)
        {
            Re = re;
            Im = im;
        }

        public Complex Plus(Complex x)
        {
            return new Complex(Re + x.Re, Im + x.Im);
        }

        public Complex Minus(Complex x)
        {
            return new Complex(Re - x.Re, Im - x.Im);
        }

        public Complex Mult(Complex x)
        {
            return new Complex(Re * x.Re - Im * x.Im, Im * x.Re + Re * x.Im);
        }

        public double Im
        {
            get => _im;
            set => _im = value;
        }

        public double Re
        {
            get => _re;
            set => _re = value;
        }

        public override string ToString()
        {
            return $"{Re}+{Im}i";
        }
    }

    class ComplexCalc
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Калькулятор комплексных чисел");

            while (true)
            {
                Console.Write("Выберите операцию: \"+\", \"-\", \"*\": ");
                string operation = Console.ReadLine();

                if (operation != "+" && operation != "-" && operation != "*")
                {
                    Console.WriteLine("Сначала нужно выбрать операцию.");
                    continue;
                }

                Complex c1 = WriteComplex("c1");
                Complex c2 = WriteComplex("c2");

                if (c1 != null || c2 != null)
                {
                    switch (operation)
                    {
                        case "+":
                            Console.WriteLine($"Сумма комплексных числе равна {c1.Plus(c2)}");
                            break;
                        case "-":
                            Console.WriteLine($"Разность комплексных числе равна {c1.Minus(c2)}");
                            break;
                        case "*":
                            Console.WriteLine($"Произведение комплексных числе hfdyj {c1.Mult(c2)}");
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка ввода. Операция невозможна.");
                }

                Console.WriteLine("Для выхода нажмите \"Q\", для продожения \"Enter\"");
                if (Console.ReadLine() == "Q")
                {
                    break;
                }
            }
        }

        private static Complex WriteComplex(string name)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Введите первый и второй элемент комплексоного числа {name} через \"Пробел\".");

                string[] complexInput = Console.ReadLine().Replace(".", ",").Split(" ");
                if (double.TryParse(complexInput[0], out var im) && double.TryParse(complexInput[1], out var re))
                {
                    Console.WriteLine($"Ввод числа {name} завершен.");
                    return new Complex(im, re);
                }

                Console.WriteLine("Ошибка ввода. Попробуйте еще раз.");
            }

            return null;
        }
    }
}