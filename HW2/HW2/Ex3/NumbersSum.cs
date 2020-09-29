/*
 * Вячеслав Индорил
 
 3)С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.
 */

using System;

namespace Ex3
{
    class NumbersSum
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите чилса с клавиатуры. Для окончания ввода введите \"0\"");

            int sum = 0;
            
            do
            {
                if (int.TryParse(Console.ReadLine(), out var input))
                {
                    if (input == 0)
                    {
                        break;
                    }

                    if (input > 0 && input % 2 != 0)
                    {
                        sum += input;
                    }
                }
            } while (true);

            Console.WriteLine($"Сумма положительных нечетных чисел = {sum}");
        }
    }
}