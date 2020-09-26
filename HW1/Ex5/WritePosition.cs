/*
    Вячеслав Индорил

  5)а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
    б) *Сделать задание, только вывод организовать в центре экрана.
    в) **Сделать задание б с использованием собственных методов (например, Print(string ms, int x,int y).
 */

using System;
using MySupport;

namespace Ex5
{
    class WritePosition
    {
        static void Main(string[] args)
        {
            Console.Write("Введите ваше имя: ");
            string name = Console.ReadLine();

            Console.Write("Введите вашу фамилию: ");
            string surname = Console.ReadLine();

            Console.Write("Введите ваш город: ");
            string city = Console.ReadLine();

            //Print(new string[3] { name, surname, city}, 
            //    Console.WindowWidth / 2, 
            //    Console.WindowHeight / 2);
            //    Console.ReadKey();

            Support.CenterPrint(new string[3] {name, surname, city});

            Support.Pause();
        }

        private static void Print(string[] args, int xPos, int yPos) {
            Console.Clear();

            if (yPos > 0) {
                for (int i = 0; i < yPos; i++) {
                    Console.WriteLine();
                }
            }

            string xOffset = "";
            if (xPos > 0) {
                for (int i = 0; i < xPos; i++)
                {
                    xOffset += " ";
                }
            }

            string text = "";
            for (int i = 0; i < args.Length; i++) {
                text += $"{xOffset}{args[i]}\n";
            }

            Console.WriteLine(text);
        }
    }
}
