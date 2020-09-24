/*
     Вячеслав Индорил

    4)Написать программу обмена значениями двух переменных:
        а) с использованием третьей переменной;
	    б) *без использования третьей переменной.
 */

using System;

namespace Ex4
{
    class Exchange
    {
        static void Main(string[] args)
        {
            int a = 4;
            int b = 5;

            Console.WriteLine($"a = {a}, b = {b}");

            a += b;
            b -= a;
            b = -b;
            a -= b;

            Console.WriteLine($"\nExchange: \na = {a}, b = {b}");
        }
    }
}
