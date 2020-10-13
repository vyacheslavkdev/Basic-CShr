/*
 * Вячеслав Индорил
 * Задача 1
    Изменить программу вывода таблицы функции так, чтобы можно было передавать 
    функции типа double (double, double). Продемонстрировать работу на функции 
    с функцией a*x^2 и функцией a*sin(x).
 */
using System;

namespace Ex1

{
    public delegate double Function (double a, double x);
    
    class DelegateWork
    {
        static double MultOnSqr(double a, double x)
        {
            return a * x * x;
        }

        static double MultOnSin(double a, double x)
        {
            return a * Math.Sin(x);
        }
        
        static void Main(string[] args)
        {
            PlotList(MultOnSqr, 5,-7.7,4.3, 0.7);
            PlotList(MultOnSin, 5,-7.7,4.3, 0.7);
        }

        static void PlotList(Function f, double a, double xStart, double xEnd, double step)
        {
            Console.WriteLine(f.Method.Name);
            double x = xStart;
            while (x <= xEnd)
            {
                Console.WriteLine($"{x,5:F}  {f(a, x),5:F}");

                x += step;
            }
            Console.WriteLine();
        }
    }
}