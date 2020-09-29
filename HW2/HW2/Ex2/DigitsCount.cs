/*
 * Вячеслав Индорил
 
 2)Написать метод подсчета количества цифр числа.
 */

using System;

namespace Ex2
{
    class DigitsCount
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            if (double.TryParse(Console.ReadLine().Replace(".", ","), out var number))
            {
                Console.WriteLine($"В числе {number} количество цифр = {Count(number)}");
            }
        }

        private static int Count(double number)
        {
            string numberChars = number.ToString();
            int count = 0;
            for (int i = 0; i < numberChars.Length; i++)
            {
                if (int.TryParse(numberChars[i].ToString(), out var digit))
                {
                    count++;
                }
            }

            return count;
        }
    }
}