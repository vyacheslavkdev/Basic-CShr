/*
 * Вячеслав Индорил
 
 2) а)  С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). 
        Требуется подсчитать сумму всех нечётных положительных чисел. 
        Сами числа и сумму вывести на экран, используя tryParse.
 */

using System;

namespace Ex2
{
    class NumbersSum
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите чилса с клавиатуры. Для окончания ввода введите \"0\"");

            int sum = 0;
            string numbersText = "";

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
                        if (numbersText != "")
                        {
                            numbersText += " + ";
                        }

                        sum += input;
                        numbersText += input;
                    }
                }
            } while (true);

            Console.WriteLine($"{numbersText} = {sum}");
            Console.ReadKey();
        }
    }
}