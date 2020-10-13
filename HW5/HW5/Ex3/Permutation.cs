/*
 * Вячеслав Индорил
 * Задача 3
    *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
    Например:
    badc являются перестановкой abcd.
 */

using System;
using System.Linq;

namespace Ex3
{
    class Permutation
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку 1:");
            string line1 = Console.ReadLine();

            Console.WriteLine("Введите строку 2:");
            string line2 = Console.ReadLine();

            if (line1.Length != line2.Length)
            {
                Console.WriteLine($"Строка \"{line2}\" не является перестановкой строки \"{line1}\"");
                return;
            }

            Console.WriteLine(SortLine(line1).Equals(SortLine(line2))
                ? $"Строка \"{line2}\" является перестановкой строки \"{line1}\""
                : $"Строка \"{line2}\" не является перестановкой строки \"{line1}\"");
        }

        static string SortLine(string line)
        {
            char[] chars = line.ToArray();
            for (int i = 0; i < chars.Length; i++)
            {
                int index = i;
                for (int j = index + 1; j < chars.Length; j++)
                {
                    if (chars[j] < chars[index])
                    {
                        index = j;
                    }
                }

                char tmp = chars[index];
                chars[i] = chars[index];
                chars[index] = tmp;
            }

            return chars.ToString();
        }
    }
}