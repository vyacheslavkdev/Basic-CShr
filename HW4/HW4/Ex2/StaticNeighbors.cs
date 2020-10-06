/*
 * Вячеслав Индорил
 * Задача 2
    Реализуйте задачу 1 в виде статического класса StaticClass;
    а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
    б) *Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;
    в)**Добавьте обработку ситуации отсутствия файла на диске.
 */

using System;
using System.IO;

namespace Ex2
{
    class StaticNeighbors
    {
        static void Main(string[] args)
        {
            string fileName = "../../data.txt";
            int[] array = Neigborns.ReadArrayFromFile(fileName);

            Neigborns.Calculate(array);
        }
    }

    public static class Neigborns
    {
        public static int[] ReadArrayFromFile(string fileName)
        {
            int[] res = null;
            try
            {
                string fileText = "";
                using (StreamReader streamReader = new StreamReader(fileName))
                {
                    while (!streamReader.EndOfStream)
                    {
                        fileText += $"{streamReader.ReadLine().Trim()} ";
                    }
                }

                string[] fileTextSplit = fileText.Split(" ");
                res = new int[fileTextSplit.Length];

                for (int i = 0; i < fileTextSplit.Length; i++)
                {
                    ShowElement(i, fileTextSplit[i]);

                    int.TryParse(fileTextSplit[i], out var parse);
                    res[i] = parse;
                }

                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Невозможно прочитать файл:");
                Console.WriteLine(e);
            }

            return res;
        }

        public static void Calculate(int[] array)
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

        private static void ShowElement(int i, string element)
        {
            Console.Write("{0, 7}", element);
            if ((i + 1) % 10 == 0)
            {
                Console.WriteLine();
            }
        }
    }
}