/*
 * Вячеслав Индорил
 
 1)Написать метод, возвращающий минимальное из трёх чисел.
 */

using System;
using System.Collections.Generic;
using MySupport;

namespace HW2
{
    class MinimalNumber
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите числа для сравнения через пробел");
            Console.WriteLine($"Минимальное число = {MinOfNumbers(Support.ReadNumbers(Console.ReadLine()))}");
        }

        private static double MinOfNumbers(double a, double b, double c)
        {
            if (a < b && a < c)
            {
                return a;
            }
            else
            {
                return b < c ? b : c;
            }
        }

        private static double MinOfNumbers(List<double> numbers)
        {
            if (numbers.Count == 3)
            {
                return MinOfNumbers(numbers[0], numbers[1], numbers[2]);
            }

            double min = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                if (min > numbers[i])
                {
                    min = numbers[i];
                }
            }

            return min;
        }
    }
}