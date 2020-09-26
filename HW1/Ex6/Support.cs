/*
    Вячеслав Индорил

    6) *Создать класс с методами, которые могут пригодиться в вашей учебе (Print, Pause)
 */

using System;

namespace MySupport
{
    public class Support
    {
        public static void Main(string[] args) { }

        public static void CenterPrint(string[] args, bool isClear = true)
        {
            int xPos = Console.WindowWidth / 2;
            int yPos = Console.WindowHeight / 2;

            if (isClear) {
                ClearPrint(args, xPos, yPos);
            } else {
                Print(args, xPos, yPos);
            }

        }

        public static void ClearPrint(string[] args, int xPos, int yPos)
        {
            Console.Clear();

            Print(args, xPos, yPos);
        }

        public static void Print(string[] args, int xPos, int yPos)
        {
            if (yPos > 0)
            {
                for (int i = 0; i < yPos; i++)
                {
                    Console.WriteLine();
                }
            }

            string xOffset = "";
            if (xPos > 0)
            {
                for (int i = 0; i < xPos; i++)
                {
                    xOffset += " ";
                }
            }

            string text = "";
            for (int i = 0; i < args.Length; i++)
            {
                text += $"{xOffset}{args[i]}\n";
            }

            Console.WriteLine(text);
        }

        public static void Pause() {
            Console.ReadKey();
        }
    }
}
