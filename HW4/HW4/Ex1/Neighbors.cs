/*
 * Вячеслав Индорил
 * Задача 1
    Дан  целочисленный  массив  из 20 элементов.  Элементы  массива  могут принимать  целые  
    значения  от –10 000 до 10 000 включительно. Заполнить случайными числами.  Написать программу, 
    позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3. 
    В данной задаче под парой подразумевается два подряд идущих элемента массива. Например, 
    для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.
 */

using System;

namespace Ex1
{
    class Neighbors
    {
        static void Main(string[] args)
        {
            int[] array = new int[20];
            InitArray(array);
            Calculate(array);
        }

        private static void Calculate(int[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                var a = array[i];
                var b = array[i + 1];
                if ((a % 3 == 0 && b % 3 != 0)
                    || (a % 3 != 0 && b % 3 == 0))
                {
                    Console.Write($"[{a} {b}] ");
                    count++;
                }

                if ((i + 1) % 10 == 0)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine($"\nКоличество соседних элементов, в котором только один делится на 3 = {count}");
        }

        private static void InitArray(int[] array)
        {
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-10000, 10000);

                Console.Write("{0, 7}", array[i]);

                if ((i + 1) % 10 == 0)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
        }
    }
}