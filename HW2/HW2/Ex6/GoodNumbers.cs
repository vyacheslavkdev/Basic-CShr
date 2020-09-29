/*
 * Вячеслав Индорил
 
   *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000.
   «Хорошим» называется число, которое делится на сумму своих цифр. Реализовать подсчёт времени 
   выполнения программы, используя структуру DateTime.
 */

using System;

namespace Ex6
{
    class GoodNumbers
    {
        static void Main(string[] args)
        {
            Console.Write("Введите диапазон поиска счастливых чисел: ");
            if (!int.TryParse(Console.ReadLine(), out var input))
            {
                Console.Write("Ошибка. Введено не целое число.");
                return;
            }

            int goodNumbersCount = 0;

            DateTime start = DateTime.Now;
            for (int i = 1; i <= input; i++)
            {
                if (i % GetDigitsSum(i) == 0)
                {
                    goodNumbersCount++;
                }
            }

            DateTime stop = DateTime.Now;

            Console.WriteLine($"В диапазоне от 1 до {input}");
            Console.WriteLine($"колчичество \"Хороших\" чисел: {goodNumbersCount}");
            Console.WriteLine($"Время на расчеты: {stop - start}");
            Console.ReadKey();
        }

        private static int GetDigitsSum(int number)
        {
            int sum = 0;
            do
            {
                sum += number % 10;
                number /= 10;
            } while (number != 0);

            return sum;
        }
    }
}