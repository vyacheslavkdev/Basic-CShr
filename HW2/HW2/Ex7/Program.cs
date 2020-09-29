/*
 * Вячеслав Индорил
 
   a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
   б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
 */
using System;

namespace Ex7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число а: ");
            int a = int.Parse(Console.ReadLine());
            
            Console.Write("Введите число b: ");
            int b = int.Parse(Console.ReadLine());

            if (a < b)
            {
                ShowNumbers(a, b);
            }
            else
            {
                ShowNumbers(b, a);
            }

            Console.WriteLine($"\nСумма чисел от {a} до {b} = {AbSum(a, b)}");
            Console.ReadKey();
        }

        private static int AbSum(int a, int b)
        {
            if (a == b)
            {
                return a;
            }

            return a + AbSum(++a, b);
        }


        private static void ShowNumbers(int a, int b)
        {
            if (a == b)
            {
                Console.WriteLine($"{b} ");
            }
            else
            {
                Console.Write($"{a} ");
                a++;
                ShowNumbers(a, b);
            }
        }
    }
}