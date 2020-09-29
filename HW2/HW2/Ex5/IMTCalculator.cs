/*
 * Вячеслав Индорил
 
 5) а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, 
    нужно ли человеку похудеть, набрать вес или всё в норме.
    б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
 */

using System;

namespace Ex5
{
    class IMTCalculator
    {
        private static double minImt = 18.5;
        private static double maxImt = 25;

        static void Main(string[] args)
        {
            Console.WriteLine("Расчет ИМТ.");
            Console.Write("Введите ваш рост в сантиметрах: ");
            string height = Console.ReadLine();

            Console.Write("Введите ваш вес в килограммах: ");
            string weight = Console.ReadLine();

            checkIMT(height, weight);
        }

        private static void checkIMT(string height, string weight)
        {
            double imt = double.Parse(weight) / Math.Pow(double.Parse(height) / 100, 2);

            if (imt >= minImt && imt <= maxImt)
            {
                Console.WriteLine($"Ваш ИМТ = {imt:F}. Ваш вес в норме.");
                return;
            }

            double weightDifference = GetWeightDifference(imt, double.Parse(height));
            if (imt < minImt)
            {
                Console.WriteLine($"Ваш ИМТ = {imt:F}. Вам стоит поправиться хотябы на {weightDifference:F}кг");
            }
            else
            {
                Console.WriteLine($"Ваш ИМТ = {imt:F}. Вам стоит похудеть хотябы на {weightDifference:F1}кг");
            }
        }

        private static double GetWeightDifference(double imt, double height)
        {
            double imtDif = imt < minImt ? minImt - imt : imt - maxImt;

            return imtDif * Math.Pow(height / 100, 2);
        }
    }
}