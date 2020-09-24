/*
    Вячеслав Индорил

    3)а) Написать программу, которая подсчитывает расстояние между точками с координатами 
        x1, y1 и x2,y2 по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). 
        Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой);
      б) *Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.
*/

using System;

namespace Ex3
{
    class Distance
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Расстаяние между точками."); 

            Console.WriteLine("Введите координаты первой точки через пробел");
            string pointOne = Console.ReadLine();
            string[] splitOne = pointOne.Replace(".",",").Split(" ");
            float x1 = float.Parse(splitOne[0]);
            float y1 = float.Parse(splitOne[1]);

            Console.WriteLine("Введите координаты второй точки через пробел");
            string pointTwo = Console.ReadLine();
            string[] splitTwo = pointTwo.Replace(".", ",").Split(" ");
            float x2 = float.Parse(splitTwo[0]);
            float y2 = float.Parse(splitTwo[1]);

            float distance = CalculateDistance(x1, y1, x2, y2);
            Console.WriteLine($"Расстаяние между точками = {distance:F2}");
        }

        private static float CalculateDistance(float x1, float y1, float x2, float y2)
        {
            double result = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return Convert.ToSingle(result);
        }
    }
}
